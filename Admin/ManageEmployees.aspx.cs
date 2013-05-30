using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_ManageEmployees : System.Web.UI.Page
{
    private void resetControls()
    {
        ddlEmployees.DataBind();
        ddlEmployees.Items.Insert(0, new ListItem("", ""));
        btnAddAdmin.Enabled = false;
        btnDelete.Enabled = false;
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            resetControls();
            Session["isUserAdmin"] = false;
        }
    }

    protected void ddlEmployees_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmployees.SelectedValue != "")
        {
            btnAddAdmin.Enabled = true;
            btnDelete.Enabled = true;

            if (Roles.IsUserInRole(ddlEmployees.SelectedItem.Text, "Administrator"))
            {
                btnAddAdmin.Text = "Remove Administration Role";
                Session["isUserAdmin"] = true;
            }
            else
            {
                btnAddAdmin.Text = "Add Administration Role";
                Session["isUserAdmin"] = false;
            }
        }
        Wizard.ActiveStepIndex = 0;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Membership.DeleteUser(ddlEmployees.SelectedItem.Text);

        resetControls();
    }

    protected void btnAddAdmin_Click(object sender, EventArgs e)
    {
        bool isUserAdmin = (bool)Session["isUserAdmin"];
        if (isUserAdmin)
            Roles.RemoveUserFromRole(ddlEmployees.SelectedItem.Text, "Administrator");
        else
            Roles.AddUserToRole(ddlEmployees.SelectedItem.Text, "Administrator");

        resetControls();
    }

    protected void Wizard_CreatedUser(object sender, EventArgs e)
    {
        Roles.AddUserToRole(Wizard.UserName, "Employee");

        resetControls();
    }
}