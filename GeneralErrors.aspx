<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GeneralErrors.aspx.cs" Inherits="GeneralErrors" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>General Error</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>General Error</h1>
    <div>
    An error occured. Please try again.
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
</asp:Content>

