﻿using System;
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
    public Transaction CreateTransaction()
    {
        Transaction t = new Transaction();
        foreach (CartItem item in Cart)
            t.AddOrderLine(item.Item, item.Quantity, item.Price, item.Message, item.PrintImage);
        return t;
    }
}