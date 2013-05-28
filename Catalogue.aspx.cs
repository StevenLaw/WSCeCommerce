using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <remarks>
    /// Determines the category to be put into the title of the page from the cat GET variable from the 
    /// URL and retrieves the data source to display that category.  If there is no cat variable then it 
    /// sets the title to simply Catalogue and leaves the data source as the default
    /// </remarks>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <exception cref="Exception">Invalid category</exception>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["cat"] != null)
        {
            string tmp = Request.QueryString["cat"];
            string category;
            WscDbDataContext db = new WscDbDataContext();
            IQueryable<Product> categoryItems;
            switch (tmp)
            {
                case "P":
                    category = "Printable";
                    categoryItems = db.Products.Where(cat => (cat.ProductType.PTId == 3 ||
                        cat.ProductType.PTId == 4));
                    break;
                case "3":
                    category = "Shirts";
                    categoryItems = db.Products.Where(cat => (cat.ProductType.PTId == 3));
                    break;
                case "4":
                    category = "Mugs";
                    categoryItems = db.Products.Where(cat => (cat.ProductType.PTId == 4));
                    break;
                case "E":
                    category = "Engravable";
                    categoryItems = db.Products.Where(cat => (cat.ProductType.PTId == 1 ||
                        cat.ProductType.PTId == 2));
                    break;
                case "1":
                    category = "Trophies";
                    categoryItems = db.Products.Where(cat => (cat.ProductType.PTId == 1));
                    break;
                case "2":
                    category = "Plaques";

                    categoryItems = db.Products.Where(cat => (cat.ProductType.PTId == 2));
                    break;
                default:
                    throw new Exception("Invalid category");
            }
            titleElement.InnerText = "Catalogue - " + category;
            gvCatalogue.DataSource = categoryItems;
            gvCatalogue.DataSourceID = null;
            gvCatalogue.DataBind();
        }
        else
            titleElement.InnerText = "Catalogue";
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the gvCatalogue control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvCatalogue_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = gvCatalogue.SelectedIndex;
        string id = gvCatalogue.DataKeys[index]["PID"].ToString(); //Debug
        Response.Redirect("Item.aspx?id=" + id);

    }
}