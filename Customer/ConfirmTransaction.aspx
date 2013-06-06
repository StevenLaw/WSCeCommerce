<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConfirmTransaction.aspx.cs" Inherits="Customer_ConfirmTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Please Confirm Your Purchase</h1>
    Token: 
    <asp:Label ID="lblToken" runat="server" Text="Label"></asp:Label>
    <br />
    Payer ID:
    <asp:Label ID="lblPayerID" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnConfirm" runat="server" onclick="btnConfirm_Click" 
        Text="Confirm" />
</asp:Content>

