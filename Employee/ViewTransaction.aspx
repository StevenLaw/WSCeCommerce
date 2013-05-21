<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewTransaction.aspx.cs" Inherits="Employee_ViewTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="WscDbDataContext" EntityTypeName="" 
        TableName="OrderLines" 
        
        Select="new (TransactionId, PriceAtSale, Quantity, PID, Completed, Message, Product, Transaction)" 
        EnableDelete="True" EnableInsert="True" EnableUpdate="True">
    </asp:LinqDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" DataSourceID="LinqDataSource1" 
        ForeColor="Black" GridLines="Vertical" AllowPaging="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" 
                ReadOnly="True" SortExpression="TransactionId" />
            <asp:BoundField DataField="PriceAtSale" HeaderText="PriceAtSale" ReadOnly="True" 
                SortExpression="PriceAtSale" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                SortExpression="Quantity" ReadOnly="True" />
            <asp:BoundField DataField="PID" HeaderText="PID" 
                SortExpression="PID" ReadOnly="True" />
            <asp:BoundField DataField="Completed" HeaderText="Completed" 
                SortExpression="Completed" ReadOnly="True" />
            <asp:BoundField DataField="Message" HeaderText="Message" ReadOnly="True" 
                SortExpression="Message" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <br />
    <br />

</asp:Content>

