using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCart : System.Web.UI.Page
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

            Session["Cart"] = cart;
            
            gvCart.DataSource = cart;
            gvCart.DataBind();
        }
        else
        {
            cart = (List<GridViewItem>)Session["Cart"];
        }
    }

    protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            cart.RemoveAt(e.RowIndex);
            gvCart.DataSource = cart;
            gvCart.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}