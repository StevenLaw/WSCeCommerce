using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Item : System.Web.UI.Page
{
    private Product item;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            WscDbDataContext db = new WscDbDataContext();
            item = db.Products.Where(i => (i.PID == id)).Single();
            imgProduct.ImageUrl = item.Image;
            lblName.Text = item.Name;
            lblDescription.Text = item.Description;
            titleElement.InnerText = item.Name;
        }
        else
        {
            throw new Exception("Missing Item Id");
        }
    }

    protected void btnCart_Click(object sender, EventArgs e)
    {
        string username = Page.User.Identity.Name;
        //lblDebug.Text = username;
        Customer currentCustomer;
        if (Session["CurrentCustomer"] == null)
        {
            WscDbDataContext db = new WscDbDataContext();
            if (username == "")
                currentCustomer = new Customer();
            else
                currentCustomer = db.Customers.Where(c => 
                    (c.UserName == username)).Single();
        }
        else 
            currentCustomer = (Customer) Session["CurrentCustomer"];
        if (currentCustomer.Cart == null)
            currentCustomer.Cart = new Cart();
        currentCustomer.Cart.AddItem(item, Convert.ToInt32(txtQty.Text), item.Price, txtMessage.Text);
    }
}