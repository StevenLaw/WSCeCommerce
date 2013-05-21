<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <table class="style1">
            <tr>
                <td>
                    First name</td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Please enter your first name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Last name</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ErrorMessage="Please enter your last name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    User name</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ErrorMessage="Please enter your user name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Password</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ErrorMessage="Please enter your password"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Confirm password</td>
                <td class="style2">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ErrorMessage="Password doesn't match" ControlToCompare="txtPassword" 
                        ControlToValidate="txtConfirmPassword"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Address</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ErrorMessage="Please enter your address"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    City</td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ErrorMessage="Please enter your city"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Province/State</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ldsProvState" 
                        DataTextField="Name" DataValueField="PSCode">
                    </asp:DropDownList>
                    <asp:LinqDataSource ID="ldsProvState" runat="server" 
                        ContextTypeName="WscDbDataContext" EntityTypeName="" 
                        Select="new (PSCode, Name)" TableName="ProvinceStates">
                    </asp:LinqDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    Postal/Zip code</td>
                <td>
                    <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ErrorMessage="Please enter your postal/zip code"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Country</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Canada</asp:ListItem>
                        <asp:ListItem>United States</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Phone</td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ErrorMessage="Please enter your email address"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnRegister" runat="server" Text="Register" />
        <br />
        <br />
        <br />
        <br />
    </p>
</asp:Content>

