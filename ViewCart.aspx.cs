using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (true)
        {
            SortedList<string, int> cart = new SortedList<string, int>();
            cart.Add("Test 1", 1);
            cart.Add("Test 2", 2);
            cart.Add("Test 3", 3);
            cart.Add("Test 4", 4);
            cart.Add("Test 5", 5);

            gvCart.DataSource = cart;
            gvCart.DataBind();
        }
    }
}