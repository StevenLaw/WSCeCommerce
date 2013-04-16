using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

public struct CartItem
{
    public string Item { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}

/// <summary>
/// Summary description for Cart
/// </summary>
public class Cart : Collection<CartItem>
{
	
    public Cart()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void AddItem(Product prod, int qty, double price)
    {

    }

    public void RemoveItem(Product prod)
    {

    }

    public void EditItem(Product prod, int qty)
    {

    }

    public double GetSubTotal()
    {
        return 0.0;
    }

    public bool IsEmpty()
    {
        if (this.Count == 0)
            return true;
        else
            return false;
    }
}