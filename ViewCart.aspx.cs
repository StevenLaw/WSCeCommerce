using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// The customer uses this page to view the current contents of their cart
/// </summary>
public partial class ViewCart : System.Web.UI.Page
{
    private Cart cart;
    private decimal taxRate = 0.05m;

    /// <summary>
    /// Sets the total values under the GridView.
    /// </summary>
    private void SetTotals()
    {
        decimal subTotal = cart.GetSubTotal();
        decimal tax = subTotal * taxRate;
        decimal total = subTotal + tax;

        lblSubtotal.Text = String.Format("{0:C}", subTotal);
        lblTax.Text = String.Format("{0:C}", tax);
        lblTotal.Text = String.Format("{0:C}", total);
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <remarks>
    /// <list type="number">
    /// <item>Retrieves the cart or redirects</item>
    /// <item>Retrieves the cart or redirects</item>
    /// <item>Binds the data source</item>
    /// </list>
    /// </remarks>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // If the CurrentCustomer Session variable exists retrieve the cart otherwise create it
        if (Session["CurrentCustomer"] != null)
        {
            cart = ((Customer)Session["CurrentCustomer"]).Cart;
        }
        else
        {
            Response.Redirect("~/EmptyCart.aspx");
        }

        // Make sure that the DataSource is set and bound
        if (!IsPostBack)
        {
            gvCart.DataSource = cart;
            gvCart.DataBind();
        }

        // If the cart is 0 redirect to the error page
        if (cart.Count == 0)
            Response.Redirect("~/EmptyCart.aspx");

        SetTotals();
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvCart control.
    /// </summary>
    /// <remarks>
    /// Removes an item from the cart and resets the value in the master view's view cart link <br />
    /// <br />
    /// If the resulting cart has no items it redirects to the empty cart page
    /// </remarks>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    /// <exception cref="Exception">There was a database error:  + ex.Message</exception>
    protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Try to remove the cart 
        try
        {
            cart.RemoveAt(e.RowIndex);
            gvCart.DataSource = cart;
            gvCart.DataBind();
        }
        catch (Exception ex)
        {
            throw new Exception("There was a database error: " + ex.Message);
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

    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <remarks>
    /// Iterates through the values in the textboxes in the GridView and updates all of the cart item's 
    /// quantities.
    /// </remarks>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        // Go through the GridView and set the quantity values in the cart to those in the GridView
        foreach (GridViewRow row in gvCart.Rows)
        {
            int index = row.RowIndex;
            // Retrieve the contents of the txtQuantity control from within the GridView and convert it to an int
            int newQty = Convert.ToInt32(((TextBox)row.FindControl("txtQuantity")).Text);
            cart.EditItem(cart[index].Item, newQty);
        }
        gvCart.DataSource = cart;
        gvCart.DataBind();
        SetTotals();
    }

    /// <summary>
    /// Handles the Click event of the btnCheckout control.
    /// </summary>
    /// <remarks>
    /// Saves the cart in a CurrentCart Session variable and redirects to the checkout page.
    /// </remarks>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        Session["CurrentCart"] = cart;
        Response.Redirect("~/Customer/Checkout.aspx", false);
    }
}