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
    }

    protected void gvCatalogue_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = gvCatalogue.SelectedIndex;
        string id = gvCatalogue.DataKeys[index]["PID"].ToString(); //Debug
        Response.Redirect("Item.aspx?id=" + id);

    }
}