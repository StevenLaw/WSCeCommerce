<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Catalogue.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        Height="30px" Width="93px">
        <Columns>
            <asp:BoundField HeaderText="Name"></asp:BoundField>
            <asp:BoundField HeaderText="Product Type"></asp:BoundField>
            <asp:BoundField HeaderText="Price"></asp:BoundField>
            <asp:BoundField HeaderText="Description"></asp:BoundField>
            <asp:ImageField HeaderText="Image">
            </asp:ImageField>
        </Columns>
</asp:GridView>
<br />
<asp:LinqDataSource ID="LinqDataSource1" runat="server">
</asp:LinqDataSource>
</asp:Content>

