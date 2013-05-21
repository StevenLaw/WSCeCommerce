﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewTransaction.aspx.cs" Inherits="Employee_ViewTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="WscDbDataContext" EnableDelete="True" EnableInsert="True" 
        EnableUpdate="True" EntityTypeName="" TableName="OrderLines">
    </asp:LinqDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" DataKeyNames="TransactionId,PID" DataSourceID="LinqDataSource1" 
        ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" 
                ReadOnly="True" SortExpression="TransactionId" />
            <asp:BoundField DataField="PID" HeaderText="PID" ReadOnly="True" 
                SortExpression="PID" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                SortExpression="Quantity" />
            <asp:BoundField DataField="PriceAtSale" HeaderText="PriceAtSale" 
                SortExpression="PriceAtSale" />
            <asp:BoundField DataField="Completed" HeaderText="Completed" 
                SortExpression="Completed" />
            <asp:BoundField DataField="Message" HeaderText="Message" 
                SortExpression="Message" />
            <asp:BoundField DataField="PrintImage" HeaderText="PrintImage" 
                SortExpression="PrintImage" />
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

