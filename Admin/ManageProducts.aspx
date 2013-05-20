<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageProducts.aspx.cs" Inherits="Admin_ManageProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 425px;
        }
        .style2
        {
            width: 197px;
        }
        .style3
        {
            width: 197px;
            height: 23px;
        }
        .style4
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PID" DataSourceID="ldsProducts">
        <Columns>
            <asp:BoundField DataField="PID" HeaderText="PID" InsertVisible="False" 
                ReadOnly="True" SortExpression="PID" />
            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                SortExpression="Quantity" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" />
            <asp:BoundField DataField="Image" HeaderText="ImageUrl" 
                SortExpression="Image" />
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="100px" 
                        ImageUrl='<%# Eval("Image") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="ldsProducts" runat="server" 
        ContextTypeName="WscDbDataContext" EntityTypeName="" TableName="Products">
    </asp:LinqDataSource>
    New Product:<br />
    <table class="style1">
        <tr>
            <td class="style2">
                Product Type:</td>
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
            <td class="style3">
                Name</td>
            <td class="style4">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="&lt;br /&gt;Required Field"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Initial Quantity:</td>
            <td>
                <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="txtQty" ErrorMessage="&lt;br /&gt;Must be a number" 
                    Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtQty" ErrorMessage="&lt;br /&gt;Required Field"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Price</td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                    ControlToValidate="txtPrice" ErrorMessage="&lt;br /&gt;CompareValidator" 
                    Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtPrice" ErrorMessage="&lt;br /&gt;Required Field"></asp:RequiredFieldValidator>
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
                Image</td>
            <td>
                <asp:FileUpload ID="fileImage" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Add Item" />
    <br />
</asp:Content>

