using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Transaction
/// </summary>
public partial class Transaction
{
    public OrderLine CreateOrderLine(WscDbDataContext db, Product prod, int quantity, decimal price, string message, string image)
    {
        OrderLine tmp = new OrderLine() { 
            PID = prod.PID, 
            TransactionId = this.TransactionId,
            Completed = false, Quantity = quantity, 
            Product = prod, 
            PriceAtSale = price, 
            Transaction = this, 
            PrintImage = image, 
            Message = message };

        return tmp;
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