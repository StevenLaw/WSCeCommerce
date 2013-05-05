using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Collections;

public struct CartItem
{
    public Product Item { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Message { get; set; }
    public string PrintImage { get; set; }
    public decimal Total { get { return Quantity * Price; } }
}

/// <summary>
/// Contains a list of items that a customer plans on buying
/// </summary>
public class Cart : Collection<CartItem>, IEnumerable
{
	
    public Cart()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Adds the item.
    /// </summary>
    /// <param name="prod">The product.</param>
    /// <param name="qty">The quantity.</param>
    /// <param name="price">The price.</param>
    /// <param name="message">The message.</param>
    /// <param name="image">The image.</param>
    public void AddItem(Product prod, int qty, decimal price, string message, string image = "")
    {
        CartItem tmp = new CartItem
        {
            Item = prod,
            Quantity = qty,
            Price = price,
            Message = message,
            PrintImage = image
        };
        Add(tmp);
    }

    /// <summary>
    /// Removes the item.
    /// </summary>
    /// <param name="prod">The product to remove.</param>
    public void RemoveItem(Product prod)
    {
        foreach (CartItem item in this)
            if (item.Item == prod)
                Remove(item);
    }

    /// <summary>
    /// Edits the item with a new quantity.
    /// </summary>
    /// <param name="prod">The product to edit.</param>
    /// <param name="qty">The quantity to change to.</param>
    public void EditItem(Product prod, int qty)
    {
        CartItem tmp = new CartItem();
        int i;
        for (i = 0; i < Count; i++)
            if (this[i].Item == prod)
                tmp = this[i];
        if (tmp.Item != null)
        {
            tmp.Quantity = qty;
            Items[i] = tmp;
        }
    }

    /// <summary>
    /// Gets the sub total.
    /// </summary>
    /// <returns>The sub total of all of the items in the cart</returns>
    public decimal GetSubTotal()
    {
        decimal subTotal = 0;
        foreach (CartItem item in this)
            subTotal += item.Total;
        return subTotal;
    }

    /// <summary>
    /// Determines whether this instance is empty.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
    /// </returns>
    public bool IsEmpty()
    {
        if (this.Count == 0)
            return true;
        else
            return false;
    }
}