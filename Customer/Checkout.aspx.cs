using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_pgCheckout : System.Web.UI.Page
{
    private List<GridViewItem> cart;

    private struct GridViewItem
    {
        public string Item { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public GridViewItem(string item, int quantity, double price)
            : this()
        {
            Item = item;
            Quantity = quantity;
            Price = price;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cart = new List<GridViewItem>();
            cart.Add(new GridViewItem("Number 1", 1, 4.0));
            cart.Add(new GridViewItem("Number 2", 2, 4.0));
            cart.Add(new GridViewItem("Number 3", 3, 4.0));
            cart.Add(new GridViewItem("Number 4", 4, 4.0));
            cart.Add(new GridViewItem("Number 5", 5, 4.0));
            GridViewItem tmp = new GridViewItem();
            tmp.Item = "SubTotal";
            tmp.Price = 20.00;
            cart.Add(tmp);
            tmp.Item = "Tax";
            tmp.Price = 20.00;
            cart.Add(tmp);
            tmp.Item = "Total";
            tmp.Price = 20.00;
            cart.Add(tmp);

            Session["Cart"] = cart;

            gvTransaction.DataSource = cart;
            gvTransaction.DataBind();
        }
        else
        {
            cart = (List<GridViewItem>)Session["Cart"];
        }
    }
}