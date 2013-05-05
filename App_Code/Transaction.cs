using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Transaction
/// </summary>
public partial class Transaction
{
    public void AddOrderLine(Product prod, int quantity, decimal price, string message, string image)
    {
        this.OrderLines.Add(new OrderLine() { Product = prod, Quantity = quantity, PriceAtSale = price, 
            Message = message, PrintImage = image });
    }

    /// <summary>
    /// Gets the sub total.
    /// </summary>
    /// <returns>The calculated sub total</returns>
    public decimal GetSubTotal()
    {
        decimal tmp = this.OrderLines.Sum(ol => ol.PriceAtSale * ol.Quantity);

        return tmp;
    }
}