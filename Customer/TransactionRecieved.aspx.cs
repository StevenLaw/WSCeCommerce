using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_TransactionRecieved : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <remarks>
    /// Retrieves the information put into the Session variable from the checkout page and uses 
    /// that to display the payment status of the transaction as well as the to create and insert 
    /// the transaction record
    /// </remarks>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <exception cref="Exception">
    /// The customer is missing.
    /// or
    /// There was a database error:\n + ex.Message
    /// </exception>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CurrentCustomer"] == null)
            throw new Exception("The customer is missing.");

        lblPaymentStatus.Text = Session["PaymentStatus"].ToString();

        Customer currentCustomer = (Customer)Session["CurrentCustomer"];

        WscDbDataContext db = new WscDbDataContext();

        Transaction transaction = new Transaction();
        db.Transactions.InsertOnSubmit(transaction);

        transaction.Customer = currentCustomer.CustomerId;
        transaction.DateOfSale = DateTime.Now;
        if (Session["AltAddress"] != null)
        {
            transaction.AltAddress = (char)Session["AltAddress"];
            if (Session["AltAddress"].Equals("Y"))
            {
                Address address = (Address)Session["Address"];
                transaction.Addresses.Add(new Address()
                    {
                        Name = address.Name,
                        Address1 = address.Address1,
                        City = address.City,
                        ProvState = address.ProvState,
                        Country = address.Country,
                        PostalZip = address.PostalZip 
                    });
            }
        }
        else
            transaction.AltAddress = null;

        OrderLine tmp;
        foreach (CartItem item in currentCustomer.Cart)
        {
            tmp = new OrderLine() 
            { 
                PID = item.Item.PID, 
                Message = item.Message, 
                PrintImage = item.PrintImage, 
                Transaction = transaction, 
                Quantity = item.Quantity, 
                PriceAtSale = item.Price, 
                Completed = false 
            };
            db.OrderLines.InsertOnSubmit(tmp);
        }

        try
        {
            //db.Transactions.InsertOnSubmit(transaction);
            db.SubmitChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("There was a database error:\n" + ex.Message);
        }

        currentCustomer.Cart = new Cart();
        Session["CurrentCustomer"] = currentCustomer;
        lblTransID.Text = transaction.TransactionId.ToString();
    }
}