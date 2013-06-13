using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Testing : System.Web.UI.Page
{
    private Cart test;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            test = new Cart();
            Product testProd = new Product()
            {
                PID = 1,
                Name = "Test 1",
                Price = 20.00M,
                Description = "this is a test product",
            };
            test.AddItem(testProd, 2, testProd.Price, "This is a test message");
            testProd = new Product()
            {
                PID = 2,
                Name = "Test 2",
                Price = 20.00M,
                Description = "this is a test product",
            };
            test.AddItem(testProd, 1, testProd.Price, "This is a test message");
            testProd = new Product()
            {
                PID = 3,
                Name = "Test 3",
                Price = 20.00M,
                Description = "this is a test product",
            };
            test.AddItem(testProd, 5, testProd.Price, "This is a test message");

            Session["TestCart"] = test;

            gvTest.DataSource = test;
            gvTest.DataBind();
            
        //    Customer c = new Customer() { Cart = test };
        //    Transaction t = c.CreateTransaction();

        //    var trans = t.OrderLines.AsEnumerable();

        //    gvTest0.DataSource = trans;
        //    gvTest0.DataBind();

        //    decimal subtotal0 = t.GetSubTotal();
        //    decimal tax0 = subtotal0 * 0.05m;
        //    decimal total0 = tax0 + subtotal0;
        //    lblSubtotal0.Text = String.Format("{0:C}", subtotal0);
        //    lblTax0.Text = String.Format("{0:C}", tax0);
        //    lblTotal0.Text = String.Format("{0:C}", total0);
        //}
        //else
        //{
        //    test = (Cart)Session["TestCart"];

        //    gvTest.DataSource = test;
        //    gvTest.DataBind();
        }

        decimal subtotal = test.GetSubTotal();
        decimal tax = subtotal * 0.05m;
        decimal total = tax + subtotal;
        lblSubtotal.Text = String.Format("{0:C}", subtotal);
        lblTax.Text = String.Format("{0:C}", tax);
        lblTotal.Text = String.Format("{0:C}", total);

        //Customer tst = new Customer();
        //string x = tst.ProvinceState.Name;

        OrderLine o = new OrderLine();
        //o.Product.Quantity
    }
}