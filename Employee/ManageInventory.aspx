﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageInventory.aspx.cs" Inherits="Employee_ManageInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="WscDbDataContext" EntityTypeName="" TableName="Products">
    </asp:LinqDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" DataKeyNames="PID" DataSourceID="LinqDataSource1" 
        ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="PID" HeaderText="PID" InsertVisible="False" 
                ReadOnly="True" SortExpression="PID" />
            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                SortExpression="Quantity" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" />
            <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
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

