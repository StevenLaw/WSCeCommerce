﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" 
        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt">
        <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
    </asp:Login>
</asp:Content>

