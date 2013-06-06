using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public partial class Customer
{
    public Cart Cart { get; set; }

    /// <summary>
    /// Creates the transaction  based on the Cart property.
    /// </summary>
    /// <remarks>
    /// We may wish to have the code to save the transaction into the database here.
    /// </remarks>
    public Transaction CreateTransaction(WscDbDataContext db)
    {
        Transaction t = new Transaction();
        OrderLine tmp;
        foreach (CartItem item in Cart)
        {
            tmp = t.CreateOrderLine(db, item.Item, item.Quantity, item.Price, item.Message, item.PrintImage);
            db.OrderLines.InsertOnSubmit(tmp);
        }
        
        return t;
    }
}