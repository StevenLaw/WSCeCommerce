using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal.PayPalAPIInterfaceService.Model;
using PayPal.PayPalAPIInterfaceService;
using System.Configuration;


/// <summary>
/// The cart contents are displayed here for review purposes and the customer can choose where they 
/// want the items to be sent
/// </summary>
public partial class Customer_pgCheckout : System.Web.UI.Page
{
    private Cart cart;

    /// <summary>
    /// This is used to hold the data for the GridView
    /// </summary>
    private struct CheckoutItem
    {
        public string Item { get; set; }
        public string Message { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string LineTotal { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutItem"/> struct.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="message">The printing/engraving message.</param>
        /// <param name="quantity">The quantity of the items in the order.</param>
        /// <param name="price">The price.</param>
        /// <param name="lineTotal">The total of that particular item.</param>
        public CheckoutItem(string item, string message, string quantity, string price, string lineTotal)
            : this()
        {
            Item = item;
            Message = message;
            Quantity = quantity;
            Price = price;
            LineTotal = lineTotal;
        }
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <remarks>
    /// Sets the datasource for the GridView and adds the totals onto the end of it.
    /// </remarks>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <exception cref="Exception">Missing Cart unable to proceed</exception>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Retrieve the current user's username
            string username = System.Web.HttpContext.Current.User.Identity.Name;
            // Create an instance of the data context and retrieve the user with current username
            WscDbDataContext db = new WscDbDataContext();
            Customer currentUser = db.Customers.Where(c => (c.UserName == username)).Single();

            cart = (Cart)Session["CurrentCart"];
            if (cart == null)
                throw new Exception("Missing Cart unable to proceed");

            currentUser.Cart = cart;
            Session["CurrentCustomer"] = currentUser;

            List<CheckoutItem> source = new List<CheckoutItem>();

            // Transfer the contents of the cart into the CheckoutItem list
            foreach(CartItem item in cart)
            {
                source.Add(new CheckoutItem(item.Item.Name, 
                    item.Message, 
                    item.Quantity.ToString(), 
                    String.Format("{0:c}", item.Price), 
                    String.Format("{0:c}", item.LineTotal)
                    )
                );
            }

            decimal subTotal = cart.GetSubTotal();
            decimal tax = subTotal * 0.05m;
            decimal shipping = 12.0m;
            decimal total = subTotal + tax + shipping;

            Session["Total"] = total;

            // Add the totals to the GridView
            source.Add(new CheckoutItem("Subtotal", "", "", "", String.Format("{0:c}", subTotal)));
            source.Add(new CheckoutItem("Tax", "", "", "", String.Format("{0:c}", tax)));
            source.Add(new CheckoutItem("Shipping", "", "", "", String.Format("{0:c}", shipping)));
            source.Add(new CheckoutItem("Total", "", "", "", String.Format("{0:c}", total)));

            Session["Cart"] = cart;

            gvTransaction.DataSource = source;
            gvTransaction.DataBind();
            rbtnUseOwn.Checked = true;
        }
        else
        {
            cart = (Cart)Session["Cart"];
        }
    }


    /// <summary>
    /// Handles the CheckedChanged event of the all the Radio button control.
    /// </summary>
    /// <remarks>
    /// If the another address button is checked it will enable the address validators if it is not it will disable them
    /// </remarks>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnUseOther.Checked)
        {
            rfvName.Enabled = true;
            txtName.Enabled = true;
            rfvStreet.Enabled = true;
            txtStreet.Enabled = true;
            rfvCity.Enabled = true;
            txtCity.Enabled = true;
            ddlProvState.Enabled = true;
            ddlCountry.Enabled = true;
            rfvPostal.Enabled = true;
            txtPostal.Enabled = true;
        }
        else
        {
            rfvName.Enabled = false;
            txtName.Enabled = false;
            rfvStreet.Enabled = false;
            txtStreet.Enabled = false;
            rfvCity.Enabled = false;
            txtCity.Enabled = false;
            ddlProvState.Enabled = false;
            ddlCountry.Enabled = false;
            rfvPostal.Enabled = false;
            txtPostal.Enabled = false;
        }
    }

    /// <summary>
    /// This saves the data necessary to create the transaction and sends the request to PayPal
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnPayPal_Click(object sender, EventArgs e)
    {
        if (rbtnUseOther.Checked)
        {
            Session["AltAddress"] = 'Y';
            Address address = new Address() 
            { 
                Name = txtName.Text, 
                Address1 = txtStreet.Text, 
                City = txtCity.Text, 
                ProvState = ddlProvState.SelectedValue, 
                Country = ddlCountry.SelectedValue, 
                PostalZip = txtPostal.Text 
            };
            Session["Address"] = address;
        }
        else if (rbtnPickup.Checked)
            Session["AltAddress"] = 'S';
        else
            Session["AltAddress"] = null;

        // Create the request Object
        SetExpressCheckoutRequestType request = new SetExpressCheckoutRequestType();
        populateRequestObject(request);

        // Infoke the API
        SetExpressCheckoutReq wrapper = new SetExpressCheckoutReq();
        wrapper.SetExpressCheckoutRequest = request;
        // Creatte the PayPalAPIInterfaceDerviceDervice to make the API call
        PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();
        // # API call
        // Invoke the SetExpressCheckout method in service wrapper Object
        SetExpressCheckoutResponseType response = service.SetExpressCheckout(wrapper);

        //Check for API return status
        HttpContext currContext = HttpContext.Current;
        currContext.Items.Add("paymentDetails", request.SetExpressCheckoutRequestDetails.PaymentDetails);
        //setKeyResponseObjects(service, responce);

        GetExpressCheckoutDetailsReq getECWrapper = new GetExpressCheckoutDetailsReq();
        getECWrapper.GetExpressCheckoutDetailsRequest = new GetExpressCheckoutDetailsRequestType(response.Token);
        GetExpressCheckoutDetailsResponseType getECResponse = service.GetExpressCheckoutDetails(getECWrapper);

        GetExpressCheckoutDetailsRequestType getRequest = new GetExpressCheckoutDetailsRequestType();
        getRequest.Token = response.Token;
        GetExpressCheckoutDetailsReq getWrapper = new GetExpressCheckoutDetailsReq();
        getWrapper.GetExpressCheckoutDetailsRequest = getRequest;

        GetExpressCheckoutDetailsResponseType ecResponse = service.GetExpressCheckoutDetails(getWrapper);

        if (response.Ack.Equals(AckCodeType.FAILURE))
        {
            string errorString = "Failure to connect with PayPal<br />";
            List<ErrorType> errorMessages = (List<ErrorType>)response.Errors;
            foreach (ErrorType error in errorMessages)
                errorString += error.LongMessage + "<br />";
            throw new Exception(errorString);
        }
        else if (response.Ack.Equals(AckCodeType.SUCCESS) || response.Ack.Equals(AckCodeType.SUCCESSWITHWARNING))
        {
            string token = response.Token;
            Response.Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=" + token);
        }
    }

    /// <summary>
    /// Populates the request object.
    /// </summary>
    /// <param name="request">The request.</param>
    private void populateRequestObject(SetExpressCheckoutRequestType request)
    {
        Customer currentCustomer = (Customer)Session["CurrentCustomer"];

        SetExpressCheckoutRequestDetailsType ecDetails = new SetExpressCheckoutRequestDetailsType();

        string requestUrl = ConfigurationManager.AppSettings["HOSTING_ENDPOINT"].ToString();

        UriBuilder uriBuilder = new UriBuilder(requestUrl);
        uriBuilder.Path = Request.ApplicationPath
            + (Request.ApplicationPath.EndsWith("/") ? "" : "/")
            + "Customer/ConfirmTransaction.aspx";
        ecDetails.ReturnURL = uriBuilder.Uri.ToString();
        uriBuilder = new UriBuilder(requestUrl);
        uriBuilder.Path = Request.ApplicationPath
            + (Request.ApplicationPath.EndsWith("/") ? "" : "/")
            + "Default.aspx";
        ecDetails.CancelURL = uriBuilder.Uri.ToString();

        PaymentDetailsType paymentDetails = new PaymentDetailsType();
        ecDetails.PaymentDetails.Add(paymentDetails);

        paymentDetails.OrderDescription = "Engraved and or printed items";

        paymentDetails.PaymentAction = PaymentActionCodeType.SALE;

        Address address = new Address();
        if (rbtnUseOther.Checked)
        {
            address = (Address)Session["Address"];
        }
        else if (rbtnPickup.Checked)
            address = new Address()
            {
                Name = "Williams Specialty Company",
                Address1 = "100 Test Street",
                City = "Test City",
                ProvState = "AB",
                Country = "Canada",
                PostalZip = "X1X 1X1" 
            };
        else
            address = new Address()
            {
                Name = currentCustomer.FName + " " + currentCustomer.LName,
                Address1 = currentCustomer.Address,
                City = currentCustomer.City,
                ProvState = currentCustomer.ProvState,
                Country = currentCustomer.Country,
                PostalZip = currentCustomer.PostalZip 
            };
        AddressType shipAddress = new AddressType();
        shipAddress.Name = address.Name;
        shipAddress.Street1 = address.Address1;
        shipAddress.CityName = address.City;
        shipAddress.StateOrProvince = address.ProvState;
        if (address.Country == "Canada")
            shipAddress.Country = CountryCodeType.CA;
        if (address.Country == "United States")
            shipAddress.Country = CountryCodeType.US;
        shipAddress.PostalCode = address.PostalZip;

        ecDetails.PaymentDetails[0].ShipToAddress = shipAddress;

        // Set the currency to Canadian Dollars
        CurrencyCodeType currency = CurrencyCodeType.CAD;
        decimal orderTotal = 0m;

        // Set the Shipping Total Here
        paymentDetails.ShippingTotal = new BasicAmountType(currency, "12.00");
        orderTotal += 12.00m;

        // Set the total tax
        decimal tax = Math.Round(cart.GetSubTotal() * .05m, 2);
        paymentDetails.TaxTotal = new BasicAmountType(currency, tax.ToString());
        orderTotal += tax;

        foreach (CartItem item in cart)
        {
            PaymentDetailsItemType itemDetails = new PaymentDetailsItemType();
            itemDetails.Name = item.Item.Name + " - " + item.Message;
            string amount = Math.Round(item.Price, 2).ToString();
            itemDetails.Amount = new BasicAmountType(currency, amount);
            itemDetails.Quantity = item.Quantity;
            itemDetails.ItemCategory = ItemCategoryType.PHYSICAL;
            itemDetails.Description = item.Message;
            paymentDetails.PaymentDetailsItem.Add(itemDetails);
        }
        orderTotal += cart.GetSubTotal();
        string itemTotalString = Math.Round(cart.GetSubTotal(), 2).ToString();
        paymentDetails.ItemTotal = new BasicAmountType(currency, itemTotalString);
        orderTotal = cart.GetSubTotal() + tax + 12.00m;
        string orderTotalString = Math.Round(orderTotal, 2).ToString();
        paymentDetails.OrderTotal = new BasicAmountType(currency, orderTotalString);

        BillingCodeType billingCodeType = BillingCodeType.MERCHANTINITIATEDBILLING;
        BillingAgreementDetailsType baType = new BillingAgreementDetailsType(billingCodeType);
        baType.BillingAgreementDescription = "Test";
        ecDetails.BillingAgreementDetails.Add(baType);

        request.SetExpressCheckoutRequestDetails = ecDetails;
    }
}