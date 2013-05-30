<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PayPalTest.aspx.cs" Inherits="Admin_PayPalTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Return URL: <input type="text" name="returnUrl" id="returnUrl" value="" runat="server" /><br />
    Cancel URL: <input type="text" name="cancelUrl" id="cancelUrl" value="" runat="server" /><br />
    <asp:Button ID="Submit" runat="server" Text="Submit" onclick="Submit_Click" />
</asp:Content>

