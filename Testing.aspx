<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Testing.aspx.cs" Inherits="Testing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Item.Name") %>'></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Item.Name") %>'></asp:Label>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Item.Description") %>'></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Item.Name") %>'></asp:Label>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Message">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Item.Description") %>'></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Message") %>'></asp:Label>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Item.Description") %>'></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("Price", "{0:C}") %>'></asp:Label>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" 
                        Text='<%# Eval("LineTotal", "{0:C}") %>'></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="Label10" runat="server" 
                        Text='<%# Eval("LineTotal", "{0:C}") %>'></asp:Label>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
        </Columns>
        <SelectedRowStyle BackColor="#CCCCCC" />
    </asp:GridView>
    <br />
    <table class="style1">
        <tr>
            <td>
                Subtotal:</td>
            <td>
                <asp:Label ID="lblSubtotal" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Tax:
            </td>
            <td>
                <asp:Label ID="lblTax" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Total:</td>
            <td>
                <asp:Label ID="lblTotal" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="gvTest0" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Product.Name") %>'></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Product.Name") %>'></asp:Label>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Product.Description") %>'></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("Product.Description") %>'></asp:Label>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Message">
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("Message") %>'></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("Message") %>'></asp:Label>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="Label14" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("PriceAtSale", "{0:C}") %>'></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("PriceAtSale", "{0:C}") %>'></asp:Label>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <table class="style1">
        <tr>
            <td>
                Subtotal:</td>
            <td>
                <asp:Label ID="lblSubtotal0" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Tax:
            </td>
            <td>
                <asp:Label ID="lblTax0" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Total:</td>
            <td>
                <asp:Label ID="lblTotal0" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ldsCustomers">
        <Columns>
            <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" ReadOnly="True" 
                SortExpression="CustomerId" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" 
                SortExpression="UserName" />
            <asp:BoundField DataField="FName" HeaderText="FName" ReadOnly="True" 
                SortExpression="FName" />
            <asp:BoundField DataField="LName" HeaderText="LName" ReadOnly="True" 
                SortExpression="LName" />
            <asp:BoundField DataField="Address" HeaderText="Address" ReadOnly="True" 
                SortExpression="Address" />
            <asp:BoundField DataField="City" HeaderText="City" ReadOnly="True" 
                SortExpression="City" />
            <asp:BoundField DataField="ProvStateName" HeaderText="Province/State" 
                SortExpression="ProvStateName" />
            <asp:BoundField DataField="PostalZip" HeaderText="Postal/Zip" ReadOnly="True" 
                SortExpression="PostalZip" />
            <asp:BoundField DataField="Country" HeaderText="Country" ReadOnly="True" 
                SortExpression="Country" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" ReadOnly="True" 
                SortExpression="Phone" />
            <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" 
                SortExpression="Email" />
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="ldsCustomers" runat="server" 
        ContextTypeName="WscDbDataContext" EntityTypeName="" 
        Select="new (CustomerId, UserName, FName, LName, Address, City, PostalZip, Country, Phone, Email, Transactions, ProvinceState.Name As ProvStateName)" 
        TableName="Customers">
    </asp:LinqDataSource>
</asp:Content>

