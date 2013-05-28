using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_ManageProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            WscDbDataContext dbcontext = new WscDbDataContext();

            string name = txtName.Text;
            int quantity = Convert.ToInt32(txtQty.Text);
            decimal price = Convert.ToDecimal(txtPrice.Text);
            string description = txtDescription.Text;
            string image = Path.GetFileName(fileImage.PostedFile.FileName);
            fileImage.SaveAs(Server.MapPath("~/Images/" + image));
            int type = Convert.ToInt32(ddlType.SelectedValue);



            Product test = new Product();
            test.Name = name;
            test.Quantity = quantity;
            test.Price = price;
            test.Description = description;
            test.Image = "~/Images/" + image;
            test.Type = type;

            try
            {
                dbcontext.Products.InsertOnSubmit(test);
                dbcontext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("There was a database error:\n" + ex.Message);
            }

            GridView1.DataBind();
        }
    }
}