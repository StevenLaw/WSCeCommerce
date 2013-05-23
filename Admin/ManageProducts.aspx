﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageProducts.aspx.cs" Inherits="Admin_ManageProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 625px;
            vertical-align: top;
        }
        .style2
        {
            width: 197px;
            vertical-align: top;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PID" DataSourceID="ldsProducts" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="PID" HeaderText="PID" InsertVisible="False" 
                ReadOnly="True" SortExpression="PID" />
            <asp:TemplateField HeaderText="Type" SortExpression="Type">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Type") %>' 
                        Width="26px"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Quantity") %>' 
                        Width="36px"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" SortExpression="Price">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Price") %>' 
                        Width="58px"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" />
            <asp:BoundField DataField="Image" HeaderText="ImageUrl" 
                SortExpression="Image" />
            <asp:TemplateField HeaderText="Image" Visible="False">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="100px" 
                        ImageUrl='<%# Eval("Image") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                        CommandName="Edit" Text="Edit" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="True" 
                        CommandName="Update" Text="Update" />
                    &nbsp;<br />
                    <asp:Button ID="Button2" runat="server" CausesValidation="False" 
                        CommandName="Cancel" Text="Cancel" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="ldsProducts" runat="server" 
        ContextTypeName="WscDbDataContext" EntityTypeName="" TableName="Products" 
        EnableDelete="True" EnableInsert="True" EnableUpdate="True">
    </asp:LinqDataSource>
    Insert New Product:<br />
    <table class="style1">
        <tr>
            <td class="style2">
                Product Type</td>
            <td>
                <asp:DropDownList ID="ddlType" runat="server" DataSourceID="ldsProductTypes" 
                    DataTextField="Name" DataValueField="PTId">
                </asp:DropDownList>
                <asp:LinqDataSource ID="ldsProductTypes" runat="server" 
                    ContextTypeName="WscDbDataContext" EntityTypeName="" Select="new (PTId, Name)" 
                    TableName="ProductTypes">
                </asp:LinqDataSource>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Name</td>
            <td >
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="*" 
                    Display="Dynamic" ValidationGroup="Add"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Initial Quantity</td>
            <td>
                <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtQty" ErrorMessage="*" 
                    Display="Dynamic" ValidationGroup="Add"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="txtQty" ErrorMessage="*Must be a number" 
                    Operator="DataTypeCheck" Type="Integer" Display="Dynamic" 
                    ValidationGroup="Add"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Price</td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtPrice" ErrorMessage="*" 
                    Display="Dynamic" ValidationGroup="Add"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                    ControlToValidate="txtPrice" ErrorMessage="*Must be a number" 
                    Operator="DataTypeCheck" Type="Currency" Display="Dynamic" 
                    ValidationGroup="Add"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Description</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Height="108px" 
                    TextMode="MultiLine" Width="202px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Image Upload</td>
            <td>
                <asp:FileUpload ID="fileImage" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Add Item" onclick="btnAdd_Click" 
        ValidationGroup="Add" />
    <br />
</asp:Content>

