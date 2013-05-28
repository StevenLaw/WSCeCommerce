<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title id="titleElement" runat="server"></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Image ID="imgProduct" runat="server" />
    
    <br />
    <asp:Label ID="lblName" runat="server" Font-Bold="True" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
    <br />
    
<asp:TextBox ID="txtMessage" runat="server" Height="171px" TextMode="MultiLine" 
    Width="497px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtMessage" Display="Dynamic" 
        ErrorMessage="An engraving/printing message is required"></asp:RequiredFieldValidator>
<br />
    <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtQty" Display="Dynamic" 
        ErrorMessage="A quantity is required"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToValidate="txtQty" Display="Dynamic" 
        ErrorMessage="Quantity must be a number" Operator="DataTypeCheck" 
        Type="Integer"></asp:CompareValidator>
    <br />
    <asp:Label ID="lblDebug" runat="server"></asp:Label>
<br />
<asp:Button ID="btnCart" runat="server" Text="Add To Cart" Width="133px" 
        onclick="btnCart_Click" />
</asp:Content>

