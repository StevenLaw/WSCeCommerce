using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PayPal.Manager;
using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;

public partial class Admin_PayPalTest : System.Web.UI.Page
{
    private string paymentAction = "ORDER";
    private string requestUrl = "http://localhost:10336/";


    protected void Page_Load(object sender, EventArgs e)
    {
        UriBuilder uriBuilder = new UriBuilder(requestUrl);
        uriBuilder.Path = Request.ApplicationPath
            + (Request.ApplicationPath.EndsWith("/") ? "" : "/")
            + "Catalogue.aspx";
        returnUrl.Value = uriBuilder.Uri.ToString();

        uriBuilder = new UriBuilder(requestUrl);
        uriBuilder.Path = Request.ApplicationPath
            + (Request.ApplicationPath.EndsWith("/") ? "" : "/")
            + "Default.aspx";
        cancelUrl.Value = uriBuilder.Uri.ToString();

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        SetExpressCheckoutRequestType request = new SetExpressCheckoutRequestType();

    }

    private void populateRequestObject(SetExpressCheckoutRequestType request)
    {
        SetExpressCheckoutRequestDetailsType ecDetails = new SetExpressCheckoutRequestDetailsType();
        if (returnUrl.Value != "")
        {
            ecDetails.ReturnURL = returnUrl.Value;
        }
        if (cancelUrl.Value != "")
        {
            ecDetails.CancelURL = cancelUrl.Value;
        }

        PaymentDetailsType paymentDetails = new PaymentDetailsType();
        ecDetails.PaymentDetails.Add(paymentDetails);

        CurrencyCodeType currency = (CurrencyCodeType)Enum.Parse(typeof(CurrencyCodeType), "CAD");

        // Set the Shipping Total Here
        paymentDetails.ShippingTotal = new BasicAmountType(currency, "12.00");

        // Set the total tax
        paymentDetails.TaxTotal = new BasicAmountType(currency, "5.00");

        paymentDetails.OrderDescription = "Engraved and or printed items";

        paymentDetails.PaymentAction = (PaymentActionCodeType)
                Enum.Parse(typeof(PaymentActionCodeType), "Sale");

        AddressType shipAddress = new AddressType();
    }
}