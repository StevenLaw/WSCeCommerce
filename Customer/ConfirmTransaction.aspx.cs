using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;

public partial class Customer_ConfirmTransaction : System.Web.UI.Page
{
    private string token;
    private string payerID;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <remarks>
    /// Retrieves the token and the PayerID from the request sent back from PayPal
    /// </remarks>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <exception cref="Exception">
    /// Missing PayPal Token
    /// or
    /// Missing PayPay Payer ID
    /// </exception>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["token"] != null)
        {
            token = Request.Params["token"];
            lblToken.Text = token;
        }
        else
            throw new Exception("Missing PayPal Token");
        if (Request.Params["PayerID"] != null)
        {
            payerID = Request.Params["PayerID"];
            lblPayerID.Text = payerID;
        }
        else
            throw new Exception("Missing PayPay Payer ID");

        if (Session["Total"] != null)
            lblOrderTotal.Text = "Order Total: " + Session["Total"].ToString();
    }

    /// <summary>
    /// Handles the Click event of the btnConfirm control.
    /// </summary>
    /// <remarks>
    /// Retrieves the transaction details using GetExpressCheckoutDetailsRequest and then checks if the 
    /// transaction was sucessful or not then performs the DoExpressCheckout API call
    /// </remarks>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <exception cref="Exception">
    /// </exception>
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        // Creatte the PayPalAPIInterfaceDerviceDervice to make the API call
        PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();
        GetExpressCheckoutDetailsReq getECWrapper = new GetExpressCheckoutDetailsReq();
        getECWrapper.GetExpressCheckoutDetailsRequest = new GetExpressCheckoutDetailsRequestType(token);
        GetExpressCheckoutDetailsResponseType getECResponse = service.GetExpressCheckoutDetails(getECWrapper);

        GetExpressCheckoutDetailsRequestType getRequest = new GetExpressCheckoutDetailsRequestType();
        getRequest.Token = token;
        GetExpressCheckoutDetailsReq getWrapper = new GetExpressCheckoutDetailsReq();
        getWrapper.GetExpressCheckoutDetailsRequest = getRequest;

        GetExpressCheckoutDetailsResponseType response = service.GetExpressCheckoutDetails(getWrapper);

        if (response.Ack.Equals(AckCodeType.FAILURE) || response.Ack.Equals(AckCodeType.FAILUREWITHWARNING))
        {
            string errorString = "Failure to connect with PayPal<br />";
            List<ErrorType> errorMessages = (List<ErrorType>)response.Errors;
            foreach (ErrorType error in errorMessages)
                errorString += error.LongMessage + "<br />";
            throw new Exception(errorString);
        }
        else if (response.Ack.Equals(AckCodeType.SUCCESS) || response.Ack.Equals(AckCodeType.SUCCESS))
        {
            // Create request object
            DoExpressCheckoutPaymentRequestType request = new DoExpressCheckoutPaymentRequestType();
            DoExpressCheckoutPaymentRequestDetailsType requestDetails = new DoExpressCheckoutPaymentRequestDetailsType();
            request.DoExpressCheckoutPaymentRequestDetails = requestDetails;

            requestDetails.PaymentDetails = getECResponse.GetExpressCheckoutDetailsResponseDetails.PaymentDetails;
            // (Required) The timestamped token value that was returned in the SetExpressCheckout response and passed in the GetExpressCheckoutDetails request.
            requestDetails.Token = token;
            // (Required) Unique PayPal buyer account identification number as returned in the GetExpressCheckoutDetails response
            requestDetails.PayerID = payerID;
            // (Required) How you want to obtain payment. It is one of the following values:
            // * Authorization – This payment is a basic authorization subject to settlement with PayPal Authorization and Capture.
            // * Order – This payment is an order authorization subject to settlement with PayPal Authorization and Capture.
            // * Sale – This is a final sale for which you are requesting payment.
            // Note: You cannot set this value to Sale in the SetExpressCheckout request and then change this value to Authorization in the DoExpressCheckoutPayment request.
            requestDetails.PaymentAction = PaymentActionCodeType.SALE;

            // Invoke the API
            DoExpressCheckoutPaymentReq wrapper = new DoExpressCheckoutPaymentReq();
            wrapper.DoExpressCheckoutPaymentRequest = request;
            // # API call 
            // Invoke the DoExpressCheckoutPayment method in service wrapper object
            DoExpressCheckoutPaymentResponseType doECResponse = service.DoExpressCheckoutPayment(wrapper);

            if (doECResponse.Ack.Equals(AckCodeType.FAILURE) || doECResponse.Ack.Equals(AckCodeType.FAILUREWITHWARNING))
            {
                string errorString = "Failure to connect with PayPal<br />";
                List<ErrorType> errorMessages = (List<ErrorType>)doECResponse.Errors;
                foreach (ErrorType error in errorMessages)
                    errorString += error.LongMessage + "<br />";
                throw new Exception(errorString);
            }
            else if (doECResponse.Ack.Equals(AckCodeType.SUCCESS) || doECResponse.Ack.Equals(AckCodeType.SUCCESSWITHWARNING))
            {
                Session["PaymentStatus"] = doECResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo[0].PaymentStatus.ToString();
                Server.Transfer("~/Customer/TransactionRecieved.aspx");
            }
        }
    }
}