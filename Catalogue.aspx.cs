using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gvCatalogue_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = gvCatalogue.SelectedRow.DataItemIndex;
        ;
        Response.Redirect("Item.aspx?id=" + id);

    }
}