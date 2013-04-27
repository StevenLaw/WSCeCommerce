using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Transaction
/// </summary>
public partial class Transaction
{
    public void AddOrderLine(Product prod, int quantity, double price, string message, string image)
    {

    }

    /// <summary>
    /// Gets the sub total.
    /// </summary>
    /// <returns>The calculated sub total</returns>
    public double GetSubTotal()
    {
        double tmp = (double)this.OrderLines.Sum(ol => ol.PriceAtSale);

        return tmp;
    }
}