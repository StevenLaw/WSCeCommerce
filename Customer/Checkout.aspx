<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Customer_pgCheckout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .descriptor
        {
            width: 20ex;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="gvTransaction" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <asp:RadioButton ID="rbtnUseOwn" runat="server" 
        Text="I would Like to use my own Address" GroupName="shipGroup" />
    <br />
    <asp:RadioButton ID="rbtnUseOther" runat="server" 
        Text="I would like to use another address" GroupName="shipGroup" />
    <br />
    <div class="descriptor">Name:</div>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <div class="descriptor">Street:</div>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <div class="descriptor">City:</div>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <br />
    <div class="descriptor">Province/State:</div>
    <asp:DropDownList ID="DropDownList1" runat="server" 
        DataSourceID="ldsProvinceState" DataTextField="Name" DataValueField="PSCode">
    </asp:DropDownList>
    <asp:LinqDataSource ID="ldsProvinceState" runat="server" 
        ContextTypeName="WscDbDataContext" EntityTypeName="" 
        Select="new (PSCode, Name)" TableName="ProvinceStates">
    </asp:LinqDataSource>
    <br />
    <div class="descriptor">Country:</div>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <br />
    <div class="descriptor">Postal/Zip Code:</div>
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    <br />
    <asp:RadioButton ID="rbtnPickup" runat="server" GroupName="shipGroup" 
        Text="I would like to pickup from the store" />
    <br />
    <asp:Button ID="btnPayPal" runat="server" Text="Pay with PayPal" />
    <asp:Button ID="btnReturn" runat="server" Text="Return to Cart" 
        PostBackUrl="~/ViewCart.aspx" />
</asp:Content>

