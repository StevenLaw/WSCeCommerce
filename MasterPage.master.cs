using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // This is to ensure that the menus work in Chrome.  Menus are no longer used but this code is retained
        // just in case
        if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
        {
            Request.Browser.Adapters.Clear();
        }
        if (Session["CurrentCustomer"] != null)
            lnkCart.Text = "View Cart (" + ((Customer)Session["CurrentCustomer"]).Cart.Count + ")";
        else
            lnkCart.Text = "View Cart";
    }
}
