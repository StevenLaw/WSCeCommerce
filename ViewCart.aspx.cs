using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCart : System.Web.UI.Page
{
    private Cart cart;
    private decimal taxRate = 0.05m;

    private void SetTotals()
    {
        decimal subTotal = cart.GetSubTotal();
        decimal tax = subTotal * taxRate;
        decimal total = subTotal + tax;

        lblSubtotal.Text = String.Format("{0:C}", subTotal);
        lblTax.Text = String.Format("{0:C}", tax);
        lblTotal.Text = String.Format("{0:C}", total);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CurrentCustomer"] != null)
        {
            cart = ((Customer)Session["CurrentCustomer"]).Cart;
        }
        else
        {
            Response.Redirect("~/EmptyCart.aspx");
        }

        if (!IsPostBack)
        {
            gvCart.DataSource = cart;
            gvCart.DataBind();
        }

        if (cart.Count == 0)
            Response.Redirect("~/EmptyCart.aspx");

        SetTotals();
    }

    protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            cart.RemoveAt(e.RowIndex);
            gvCart.DataSource = cart;
            gvCart.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

        if (cart.Count == 0)
            Response.Redirect("~/EmptyCart.aspx");
        else
        {
            // Set the link button in the master page to the correct text
            LinkButton link = (LinkButton)Master.FindControl("lnkCart");
            link.Text = "View Cart (" + cart.Count + ")";
        }

        SetTotals();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvCart.Rows)
        {
            int index = row.RowIndex;
            int newQty = Convert.ToInt32(((TextBox)row.FindControl("txtQuantity")).Text);
            cart.EditItem(cart[index].Item, newQty);
        }
        gvCart.DataSource = cart;
        gvCart.DataBind();
        SetTotals();
    }
}