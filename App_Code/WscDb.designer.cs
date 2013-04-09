﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="WSCDatabase")]
public partial class WscDbDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertCustomer(Customer instance);
  partial void UpdateCustomer(Customer instance);
  partial void DeleteCustomer(Customer instance);
  partial void InsertTransaction(Transaction instance);
  partial void UpdateTransaction(Transaction instance);
  partial void DeleteTransaction(Transaction instance);
  partial void InsertOrderLine(OrderLine instance);
  partial void UpdateOrderLine(OrderLine instance);
  partial void DeleteOrderLine(OrderLine instance);
  partial void InsertProduct(Product instance);
  partial void UpdateProduct(Product instance);
  partial void DeleteProduct(Product instance);
  partial void InsertProductType(ProductType instance);
  partial void UpdateProductType(ProductType instance);
  partial void DeleteProductType(ProductType instance);
  partial void InsertProvinceState(ProvinceState instance);
  partial void UpdateProvinceState(ProvinceState instance);
  partial void DeleteProvinceState(ProvinceState instance);
  #endregion
	
	public WscDbDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["WSCDatabaseConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public WscDbDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public WscDbDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public WscDbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public WscDbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<Customer> Customers
	{
		get
		{
			return this.GetTable<Customer>();
		}
	}
	
	public System.Data.Linq.Table<Transaction> Transactions
	{
		get
		{
			return this.GetTable<Transaction>();
		}
	}
	
	public System.Data.Linq.Table<OrderLine> OrderLines
	{
		get
		{
			return this.GetTable<OrderLine>();
		}
	}
	
	public System.Data.Linq.Table<Product> Products
	{
		get
		{
			return this.GetTable<Product>();
		}
	}
	
	public System.Data.Linq.Table<ProductType> ProductTypes
	{
		get
		{
			return this.GetTable<ProductType>();
		}
	}
	
	public System.Data.Linq.Table<ProvinceState> ProvinceStates
	{
		get
		{
			return this.GetTable<ProvinceState>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Customer")]
public partial class Customer : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private decimal _CustomerId;
	
	private string _UserName;
	
	private string _FName;
	
	private string _LName;
	
	private string _Address;
	
	private string _City;
	
	private string _ProvState;
	
	private string _PostalZip;
	
	private string _Country;
	
	private string _Phone;
	
	private string _Email;
	
	private EntitySet<Transaction> _Transactions;
	
	private EntityRef<ProvinceState> _ProvinceState;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCustomerIdChanging(decimal value);
    partial void OnCustomerIdChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnFNameChanging(string value);
    partial void OnFNameChanged();
    partial void OnLNameChanging(string value);
    partial void OnLNameChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnCityChanging(string value);
    partial void OnCityChanged();
    partial void OnProvStateChanging(string value);
    partial void OnProvStateChanged();
    partial void OnPostalZipChanging(string value);
    partial void OnPostalZipChanged();
    partial void OnCountryChanging(string value);
    partial void OnCountryChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
	
	public Customer()
	{
		this._Transactions = new EntitySet<Transaction>(new Action<Transaction>(this.attach_Transactions), new Action<Transaction>(this.detach_Transactions));
		this._ProvinceState = default(EntityRef<ProvinceState>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerId", AutoSync=AutoSync.OnInsert, DbType="Decimal(6,0) NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public decimal CustomerId
	{
		get
		{
			return this._CustomerId;
		}
		set
		{
			if ((this._CustomerId != value))
			{
				this.OnCustomerIdChanging(value);
				this.SendPropertyChanging();
				this._CustomerId = value;
				this.SendPropertyChanged("CustomerId");
				this.OnCustomerIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
	public string UserName
	{
		get
		{
			return this._UserName;
		}
		set
		{
			if ((this._UserName != value))
			{
				this.OnUserNameChanging(value);
				this.SendPropertyChanging();
				this._UserName = value;
				this.SendPropertyChanged("UserName");
				this.OnUserNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string FName
	{
		get
		{
			return this._FName;
		}
		set
		{
			if ((this._FName != value))
			{
				this.OnFNameChanging(value);
				this.SendPropertyChanging();
				this._FName = value;
				this.SendPropertyChanged("FName");
				this.OnFNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string LName
	{
		get
		{
			return this._LName;
		}
		set
		{
			if ((this._LName != value))
			{
				this.OnLNameChanging(value);
				this.SendPropertyChanging();
				this._LName = value;
				this.SendPropertyChanged("LName");
				this.OnLNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="VarChar(150) NOT NULL", CanBeNull=false)]
	public string Address
	{
		get
		{
			return this._Address;
		}
		set
		{
			if ((this._Address != value))
			{
				this.OnAddressChanging(value);
				this.SendPropertyChanging();
				this._Address = value;
				this.SendPropertyChanged("Address");
				this.OnAddressChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_City", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
	public string City
	{
		get
		{
			return this._City;
		}
		set
		{
			if ((this._City != value))
			{
				this.OnCityChanging(value);
				this.SendPropertyChanging();
				this._City = value;
				this.SendPropertyChanged("City");
				this.OnCityChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProvState", DbType="NChar(2) NOT NULL", CanBeNull=false)]
	public string ProvState
	{
		get
		{
			return this._ProvState;
		}
		set
		{
			if ((this._ProvState != value))
			{
				if (this._ProvinceState.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnProvStateChanging(value);
				this.SendPropertyChanging();
				this._ProvState = value;
				this.SendPropertyChanged("ProvState");
				this.OnProvStateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostalZip", DbType="VarChar(7) NOT NULL", CanBeNull=false)]
	public string PostalZip
	{
		get
		{
			return this._PostalZip;
		}
		set
		{
			if ((this._PostalZip != value))
			{
				this.OnPostalZipChanging(value);
				this.SendPropertyChanging();
				this._PostalZip = value;
				this.SendPropertyChanged("PostalZip");
				this.OnPostalZipChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Country", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string Country
	{
		get
		{
			return this._Country;
		}
		set
		{
			if ((this._Country != value))
			{
				this.OnCountryChanging(value);
				this.SendPropertyChanging();
				this._Country = value;
				this.SendPropertyChanged("Country");
				this.OnCountryChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="NChar(14)")]
	public string Phone
	{
		get
		{
			return this._Phone;
		}
		set
		{
			if ((this._Phone != value))
			{
				this.OnPhoneChanging(value);
				this.SendPropertyChanging();
				this._Phone = value;
				this.SendPropertyChanged("Phone");
				this.OnPhoneChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(150) NOT NULL", CanBeNull=false)]
	public string Email
	{
		get
		{
			return this._Email;
		}
		set
		{
			if ((this._Email != value))
			{
				this.OnEmailChanging(value);
				this.SendPropertyChanging();
				this._Email = value;
				this.SendPropertyChanged("Email");
				this.OnEmailChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Customer_Transaction", Storage="_Transactions", ThisKey="CustomerId", OtherKey="Customer")]
	public EntitySet<Transaction> Transactions
	{
		get
		{
			return this._Transactions;
		}
		set
		{
			this._Transactions.Assign(value);
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProvinceState_Customer", Storage="_ProvinceState", ThisKey="ProvState", OtherKey="PSCode", IsForeignKey=true)]
	public ProvinceState ProvinceState
	{
		get
		{
			return this._ProvinceState.Entity;
		}
		set
		{
			ProvinceState previousValue = this._ProvinceState.Entity;
			if (((previousValue != value) 
						|| (this._ProvinceState.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._ProvinceState.Entity = null;
					previousValue.Customers.Remove(this);
				}
				this._ProvinceState.Entity = value;
				if ((value != null))
				{
					value.Customers.Add(this);
					this._ProvState = value.PSCode;
				}
				else
				{
					this._ProvState = default(string);
				}
				this.SendPropertyChanged("ProvinceState");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_Transactions(Transaction entity)
	{
		this.SendPropertyChanging();
		entity.Customer1 = this;
	}
	
	private void detach_Transactions(Transaction entity)
	{
		this.SendPropertyChanging();
		entity.Customer1 = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[Transaction]")]
public partial class Transaction : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private decimal _TransactionId;
	
	private System.Nullable<decimal> _Customer;
	
	private System.Nullable<System.DateTime> _DateOfSale;
	
	private EntitySet<OrderLine> _OrderLines;
	
	private EntityRef<Customer> _Customer1;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTransactionIdChanging(decimal value);
    partial void OnTransactionIdChanged();
    partial void OnCustomerChanging(System.Nullable<decimal> value);
    partial void OnCustomerChanged();
    partial void OnDateOfSaleChanging(System.Nullable<System.DateTime> value);
    partial void OnDateOfSaleChanged();
    #endregion
	
	public Transaction()
	{
		this._OrderLines = new EntitySet<OrderLine>(new Action<OrderLine>(this.attach_OrderLines), new Action<OrderLine>(this.detach_OrderLines));
		this._Customer1 = default(EntityRef<Customer>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionId", DbType="Decimal(10,0) NOT NULL", IsPrimaryKey=true)]
	public decimal TransactionId
	{
		get
		{
			return this._TransactionId;
		}
		set
		{
			if ((this._TransactionId != value))
			{
				this.OnTransactionIdChanging(value);
				this.SendPropertyChanging();
				this._TransactionId = value;
				this.SendPropertyChanged("TransactionId");
				this.OnTransactionIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Customer", DbType="Decimal(6,0)")]
	public System.Nullable<decimal> Customer
	{
		get
		{
			return this._Customer;
		}
		set
		{
			if ((this._Customer != value))
			{
				if (this._Customer1.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnCustomerChanging(value);
				this.SendPropertyChanging();
				this._Customer = value;
				this.SendPropertyChanged("Customer");
				this.OnCustomerChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateOfSale", DbType="DateTime")]
	public System.Nullable<System.DateTime> DateOfSale
	{
		get
		{
			return this._DateOfSale;
		}
		set
		{
			if ((this._DateOfSale != value))
			{
				this.OnDateOfSaleChanging(value);
				this.SendPropertyChanging();
				this._DateOfSale = value;
				this.SendPropertyChanged("DateOfSale");
				this.OnDateOfSaleChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Transaction_OrderLine", Storage="_OrderLines", ThisKey="TransactionId", OtherKey="TransactionId")]
	public EntitySet<OrderLine> OrderLines
	{
		get
		{
			return this._OrderLines;
		}
		set
		{
			this._OrderLines.Assign(value);
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Customer_Transaction", Storage="_Customer1", ThisKey="Customer", OtherKey="CustomerId", IsForeignKey=true)]
	public Customer Customer1
	{
		get
		{
			return this._Customer1.Entity;
		}
		set
		{
			Customer previousValue = this._Customer1.Entity;
			if (((previousValue != value) 
						|| (this._Customer1.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Customer1.Entity = null;
					previousValue.Transactions.Remove(this);
				}
				this._Customer1.Entity = value;
				if ((value != null))
				{
					value.Transactions.Add(this);
					this._Customer = value.CustomerId;
				}
				else
				{
					this._Customer = default(Nullable<decimal>);
				}
				this.SendPropertyChanged("Customer1");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_OrderLines(OrderLine entity)
	{
		this.SendPropertyChanging();
		entity.Transaction = this;
	}
	
	private void detach_OrderLines(OrderLine entity)
	{
		this.SendPropertyChanging();
		entity.Transaction = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OrderLine")]
public partial class OrderLine : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private decimal _TransactionId;
	
	private decimal _PID;
	
	private decimal _Quantity;
	
	private decimal _PriceAtSale;
	
	private EntityRef<Transaction> _Transaction;
	
	private EntityRef<Product> _Product;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTransactionIdChanging(decimal value);
    partial void OnTransactionIdChanged();
    partial void OnPIDChanging(decimal value);
    partial void OnPIDChanged();
    partial void OnQuantityChanging(decimal value);
    partial void OnQuantityChanged();
    partial void OnPriceAtSaleChanging(decimal value);
    partial void OnPriceAtSaleChanged();
    #endregion
	
	public OrderLine()
	{
		this._Transaction = default(EntityRef<Transaction>);
		this._Product = default(EntityRef<Product>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionId", DbType="Decimal(10,0) NOT NULL", IsPrimaryKey=true)]
	public decimal TransactionId
	{
		get
		{
			return this._TransactionId;
		}
		set
		{
			if ((this._TransactionId != value))
			{
				if (this._Transaction.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnTransactionIdChanging(value);
				this.SendPropertyChanging();
				this._TransactionId = value;
				this.SendPropertyChanged("TransactionId");
				this.OnTransactionIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PID", DbType="Decimal(5,0) NOT NULL", IsPrimaryKey=true)]
	public decimal PID
	{
		get
		{
			return this._PID;
		}
		set
		{
			if ((this._PID != value))
			{
				if (this._Product.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnPIDChanging(value);
				this.SendPropertyChanging();
				this._PID = value;
				this.SendPropertyChanged("PID");
				this.OnPIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Decimal(7,0) NOT NULL")]
	public decimal Quantity
	{
		get
		{
			return this._Quantity;
		}
		set
		{
			if ((this._Quantity != value))
			{
				this.OnQuantityChanging(value);
				this.SendPropertyChanging();
				this._Quantity = value;
				this.SendPropertyChanged("Quantity");
				this.OnQuantityChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PriceAtSale", DbType="Money NOT NULL")]
	public decimal PriceAtSale
	{
		get
		{
			return this._PriceAtSale;
		}
		set
		{
			if ((this._PriceAtSale != value))
			{
				this.OnPriceAtSaleChanging(value);
				this.SendPropertyChanging();
				this._PriceAtSale = value;
				this.SendPropertyChanged("PriceAtSale");
				this.OnPriceAtSaleChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Transaction_OrderLine", Storage="_Transaction", ThisKey="TransactionId", OtherKey="TransactionId", IsForeignKey=true)]
	public Transaction Transaction
	{
		get
		{
			return this._Transaction.Entity;
		}
		set
		{
			Transaction previousValue = this._Transaction.Entity;
			if (((previousValue != value) 
						|| (this._Transaction.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Transaction.Entity = null;
					previousValue.OrderLines.Remove(this);
				}
				this._Transaction.Entity = value;
				if ((value != null))
				{
					value.OrderLines.Add(this);
					this._TransactionId = value.TransactionId;
				}
				else
				{
					this._TransactionId = default(decimal);
				}
				this.SendPropertyChanged("Transaction");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_OrderLine", Storage="_Product", ThisKey="PID", OtherKey="PID", IsForeignKey=true)]
	public Product Product
	{
		get
		{
			return this._Product.Entity;
		}
		set
		{
			Product previousValue = this._Product.Entity;
			if (((previousValue != value) 
						|| (this._Product.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Product.Entity = null;
					previousValue.OrderLines.Remove(this);
				}
				this._Product.Entity = value;
				if ((value != null))
				{
					value.OrderLines.Add(this);
					this._PID = value.PID;
				}
				else
				{
					this._PID = default(decimal);
				}
				this.SendPropertyChanged("Product");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Product")]
public partial class Product : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private decimal _PID;
	
	private decimal _Type;
	
	private string _Name;
	
	private decimal _Quantity;
	
	private decimal _Price;
	
	private EntitySet<OrderLine> _OrderLines;
	
	private EntityRef<ProductType> _ProductType;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPIDChanging(decimal value);
    partial void OnPIDChanged();
    partial void OnTypeChanging(decimal value);
    partial void OnTypeChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnQuantityChanging(decimal value);
    partial void OnQuantityChanged();
    partial void OnPriceChanging(decimal value);
    partial void OnPriceChanged();
    #endregion
	
	public Product()
	{
		this._OrderLines = new EntitySet<OrderLine>(new Action<OrderLine>(this.attach_OrderLines), new Action<OrderLine>(this.detach_OrderLines));
		this._ProductType = default(EntityRef<ProductType>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PID", AutoSync=AutoSync.OnInsert, DbType="Decimal(5,0) NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public decimal PID
	{
		get
		{
			return this._PID;
		}
		set
		{
			if ((this._PID != value))
			{
				this.OnPIDChanging(value);
				this.SendPropertyChanging();
				this._PID = value;
				this.SendPropertyChanged("PID");
				this.OnPIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="Decimal(4,0) NOT NULL")]
	public decimal Type
	{
		get
		{
			return this._Type;
		}
		set
		{
			if ((this._Type != value))
			{
				if (this._ProductType.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnTypeChanging(value);
				this.SendPropertyChanging();
				this._Type = value;
				this.SendPropertyChanged("Type");
				this.OnTypeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string Name
	{
		get
		{
			return this._Name;
		}
		set
		{
			if ((this._Name != value))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._Name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Decimal(5,0) NOT NULL")]
	public decimal Quantity
	{
		get
		{
			return this._Quantity;
		}
		set
		{
			if ((this._Quantity != value))
			{
				this.OnQuantityChanging(value);
				this.SendPropertyChanging();
				this._Quantity = value;
				this.SendPropertyChanged("Quantity");
				this.OnQuantityChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Money NOT NULL")]
	public decimal Price
	{
		get
		{
			return this._Price;
		}
		set
		{
			if ((this._Price != value))
			{
				this.OnPriceChanging(value);
				this.SendPropertyChanging();
				this._Price = value;
				this.SendPropertyChanged("Price");
				this.OnPriceChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_OrderLine", Storage="_OrderLines", ThisKey="PID", OtherKey="PID")]
	public EntitySet<OrderLine> OrderLines
	{
		get
		{
			return this._OrderLines;
		}
		set
		{
			this._OrderLines.Assign(value);
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProductType_Product", Storage="_ProductType", ThisKey="Type", OtherKey="PTId", IsForeignKey=true)]
	public ProductType ProductType
	{
		get
		{
			return this._ProductType.Entity;
		}
		set
		{
			ProductType previousValue = this._ProductType.Entity;
			if (((previousValue != value) 
						|| (this._ProductType.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._ProductType.Entity = null;
					previousValue.Products.Remove(this);
				}
				this._ProductType.Entity = value;
				if ((value != null))
				{
					value.Products.Add(this);
					this._Type = value.PTId;
				}
				else
				{
					this._Type = default(decimal);
				}
				this.SendPropertyChanged("ProductType");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_OrderLines(OrderLine entity)
	{
		this.SendPropertyChanging();
		entity.Product = this;
	}
	
	private void detach_OrderLines(OrderLine entity)
	{
		this.SendPropertyChanging();
		entity.Product = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ProductType")]
public partial class ProductType : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private decimal _PTId;
	
	private string _Name;
	
	private char _Type;
	
	private EntitySet<Product> _Products;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPTIdChanging(decimal value);
    partial void OnPTIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnTypeChanging(char value);
    partial void OnTypeChanged();
    #endregion
	
	public ProductType()
	{
		this._Products = new EntitySet<Product>(new Action<Product>(this.attach_Products), new Action<Product>(this.detach_Products));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PTId", AutoSync=AutoSync.OnInsert, DbType="Decimal(4,0) NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public decimal PTId
	{
		get
		{
			return this._PTId;
		}
		set
		{
			if ((this._PTId != value))
			{
				this.OnPTIdChanging(value);
				this.SendPropertyChanging();
				this._PTId = value;
				this.SendPropertyChanged("PTId");
				this.OnPTIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string Name
	{
		get
		{
			return this._Name;
		}
		set
		{
			if ((this._Name != value))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._Name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="NChar(1) NOT NULL")]
	public char Type
	{
		get
		{
			return this._Type;
		}
		set
		{
			if ((this._Type != value))
			{
				this.OnTypeChanging(value);
				this.SendPropertyChanging();
				this._Type = value;
				this.SendPropertyChanged("Type");
				this.OnTypeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProductType_Product", Storage="_Products", ThisKey="PTId", OtherKey="Type")]
	public EntitySet<Product> Products
	{
		get
		{
			return this._Products;
		}
		set
		{
			this._Products.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_Products(Product entity)
	{
		this.SendPropertyChanging();
		entity.ProductType = this;
	}
	
	private void detach_Products(Product entity)
	{
		this.SendPropertyChanging();
		entity.ProductType = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ProvinceState")]
public partial class ProvinceState : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private string _PSCode;
	
	private string _Name;
	
	private EntitySet<Customer> _Customers;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPSCodeChanging(string value);
    partial void OnPSCodeChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
	
	public ProvinceState()
	{
		this._Customers = new EntitySet<Customer>(new Action<Customer>(this.attach_Customers), new Action<Customer>(this.detach_Customers));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PSCode", DbType="NChar(2) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
	public string PSCode
	{
		get
		{
			return this._PSCode;
		}
		set
		{
			if ((this._PSCode != value))
			{
				this.OnPSCodeChanging(value);
				this.SendPropertyChanging();
				this._PSCode = value;
				this.SendPropertyChanged("PSCode");
				this.OnPSCodeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
	public string Name
	{
		get
		{
			return this._Name;
		}
		set
		{
			if ((this._Name != value))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._Name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProvinceState_Customer", Storage="_Customers", ThisKey="PSCode", OtherKey="ProvState")]
	public EntitySet<Customer> Customers
	{
		get
		{
			return this._Customers;
		}
		set
		{
			this._Customers.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_Customers(Customer entity)
	{
		this.SendPropertyChanging();
		entity.ProvinceState = this;
	}
	
	private void detach_Customers(Customer entity)
	{
		this.SendPropertyChanging();
		entity.ProvinceState = null;
	}
}
#pragma warning restore 1591