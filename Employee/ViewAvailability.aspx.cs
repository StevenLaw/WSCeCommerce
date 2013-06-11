using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employee_ViewAvailability : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WscDbDataContext db = new WscDbDataContext();
            var availability = from o in db.OrderLines
                               from p in db.Products
                               where o.PID == p.PID
                               group new {o,p} by new { p.PID, p.Name, p.Quantity } into a
                               select new { 
                                   ProductId = a.Key.PID,
                                   Name = a.Key.Name,
                                   Available = a.Key.Quantity,
                                   Required = a.Sum(ol => ol.o.Quantity)
                               };

            gvAvailability.DataSource = availability;
            gvAvailability.DataBind();
        }
    }
}