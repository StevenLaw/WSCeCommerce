using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


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
            decimal total = subTotal + tax;

            // Add the totals to the GridView
            source.Add(new CheckoutItem("Subtotal", "", "", "", String.Format("{0:c}", subTotal)));
            source.Add(new CheckoutItem("Tax", "", "", "", String.Format("{0:c}", tax)));
            source.Add(new CheckoutItem("Total", "", "", "", String.Format("{0:c}", total)));

            Session["Cart"] = cart;

            gvTransaction.DataSource = source;
            gvTransaction.DataBind();
        }
        else
        {
            cart = (Cart)Session["Cart"];
        }
    }
}