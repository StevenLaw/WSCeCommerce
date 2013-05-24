using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Item : System.Web.UI.Page
{
    private Product item;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <remarks>
    /// Loads the product data from the database using the id GET variable in the URL
    /// </remarks>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <exception cref="Exception">
    /// Incorrect Item Id
    /// or
    /// Missing Item Id
    /// </exception>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            WscDbDataContext db = new WscDbDataContext();
            // If there is no item with that id go to the error page
            if (db.Products.Where(i => (i.PID == id)).Count() == 0) 
                throw new Exception("Incorrect Item Id");
            // Get the single item with that PID
            item = db.Products.Where(i => (i.PID == id)).Single();
            // Set the labels
            imgProduct.ImageUrl = item.Image;
            lblName.Text = item.Name;
            lblDescription.Text = item.Description;
            titleElement.InnerText = item.Name;
        }
        else
        {
            // If there is no id then go to the error page
            throw new Exception("Missing Item Id");
        }
    }

    /// <summary>
    /// Handles the Click event of the btnCart control.
    /// </summary>
    /// <remarks>
    /// if the current customer is not in the session variable then either create it or pull it from
    /// the database depending on whether or not the user is anonymous
    /// </remarks>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
        Session["CurrentCustomer"] = currentCustomer;

        // Set the link button in the master page to the correct text
        LinkButton link = (LinkButton) Master.FindControl("lnkCart");
        link.Text = "View Cart (" + ((Customer)Session["CurrentCustomer"]).Cart.Count + ")";
    }
}