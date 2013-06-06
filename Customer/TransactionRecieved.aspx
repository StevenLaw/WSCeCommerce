<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TransactionRecieved.aspx.cs" Inherits="Customer_TransactionRecieved" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Your Transaction is: <asp:Label ID="lblPaymentStatus" runat="server" Text=""></asp:Label><br />
<br />
Your transaction id is:
<asp:Label ID="lblTransID" runat="server"></asp:Label>
</asp:Content>

