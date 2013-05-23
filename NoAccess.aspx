<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoAccess.aspx.cs" Inherits="NoAccess" MasterPageFile="~/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>No access</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>401: Unauthorized</h1>
    <div>
   You are not authorized to access this page.
    </div>
</asp:Content>