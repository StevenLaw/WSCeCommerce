<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Picture<br />
Name<br />
Description<br />
<br />
<asp:TextBox ID="btnMessage" runat="server" Height="171px" TextMode="MultiLine" 
    Width="497px"></asp:TextBox>
<br />
<br />
<asp:Button ID="btnCart" runat="server" Text="Add To Cart" Width="133px" />
</asp:Content>

