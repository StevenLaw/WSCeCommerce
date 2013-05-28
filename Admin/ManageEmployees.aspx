<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageEmployees.aspx.cs" Inherits="Admin_ManageEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:DropDownList ID="ddlEmployees" runat="server" 
    DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="UserId">
</asp:DropDownList>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    SelectCommand="SELECT aspnet_Users.UserId, aspnet_Users.UserName FROM aspnet_Users INNER JOIN aspnet_UsersInRoles ON aspnet_Users.UserId = aspnet_UsersInRoles.UserId INNER JOIN aspnet_Roles ON aspnet_UsersInRoles.RoleId = aspnet_Roles.RoleId WHERE (aspnet_Roles.RoleName = @role)">
    <SelectParameters>
        <asp:Parameter DefaultValue="Employee" Name="role" />
    </SelectParameters>
</asp:SqlDataSource>
    <br />
    <asp:Button ID="btnDelete" runat="server" Text="Delete User" />
    <br />
    <br />
    <asp:Button ID="btnAddAdmin" runat="server" Text="Add Administration Role" />
    <br />
    <br />
    Add User:<br />
    <asp:CreateUserWizard ID="Wizard" runat="server">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" />
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
    </asp:CreateUserWizard>
    <br />
</asp:Content>

