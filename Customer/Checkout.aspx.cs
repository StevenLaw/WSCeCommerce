using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_pgCheckout : System.Web.UI.Page
{
    private Cart cart;

    private struct CheckoutItem
    {
        public string Item { get; set; }
        public string Message { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string Total { get; set; }

        public CheckoutItem(string item, string message, string quantity, string price, string total)
            : this()
        {
            Item = item;
            Message = message;
            Quantity = quantity;
            Price = price;
            Total = total;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string username = System.Web.HttpContext.Current.User.Identity.Name;
            WscDbDataContext db = new WscDbDataContext();
            Customer currentUser = db.Customers.Where(c => (c.UserName == username)).Single();

            cart = (Cart)Session["CurrentCart"];
            if (cart == null)
                throw new Exception("Missing Cart unable to proceed");

            currentUser.Cart = cart;
            Session["CurrentCustomer"] = currentUser;

            List<CheckoutItem> source = new List<CheckoutItem>();

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