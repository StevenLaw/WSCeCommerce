using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Web.Security;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        WscDbDataContext dbcontext = new WscDbDataContext();

        //string fname = txtFirstName.Text;
        //string lname = txtLastName.Text;
        //string uname = CreateUserWizard1.UserName;
        //string password = CreateUserWizard1.Password;
        //string address = txtAddress.Text;
        //string city = txtCity.Text;
        //string code = txtPostalCode.Text;
        //string phone = txtPhone.Text;
        //string email = CreateUserWizard1.Email;

        
        Customer c = new Customer();

        c.FName = txtFirstName.Text;
        c.LName = txtLastName.Text;
        c.UserName = CreateUserWizard1.UserName;
        c.Address = txtAddress.Text;
        c.City = txtCity.Text;
        c.PostalZip = txtPostalCode.Text;
        c.Phone = txtPhone.Text;
        c.Email = CreateUserWizard1.Email;
        c.ProvState = DropDownList2.SelectedValue;
        c.Country = ddlCountry.SelectedValue;

        try
        {
            dbcontext.Customers.InsertOnSubmit(c);
            dbcontext.SubmitChanges();

            MailMessage mail = new MailMessage();
            mail.To.Add("wscproject@hotmail.com");
            mail.From = new MailAddress("wscproject@hotmail.com");
            mail.Subject = "Registration status";

            mail.Body = "Your registration with WSC specialty company was successful";

            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("cis407a", "password*!");
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }

        catch (Exception ex)
        {
            throw new Exception("There was a database error:\n" + ex.Message);
        }

        Roles.AddUserToRole(CreateUserWizard1.UserName, "Customer");
    }
}