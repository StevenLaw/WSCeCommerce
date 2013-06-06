<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageProducts.aspx.cs" Inherits="Admin_ManageProducts" %>

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
        DataKeyNames="PID" DataSourceID="ldsProducts" AllowPaging="True" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="TextBox7" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Quantity") %>' 
                        Width="36px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator3" runat="server" 
                        ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="*Must be a number" 
                        Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" SortExpression="Price">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Price", "{0:C}") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Price", "{0:C}") %>' 
                        Width="58px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator4" runat="server" 
                        ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="*Invalid input" 
                        Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ImageUrl" SortExpression="Image">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Image") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
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
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    Display="Dynamic" ErrorMessage="*" ValidationGroup="Add"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
  <br />
    <asp:Button ID="btnAdd" runat="server" Text="Add Item" onclick="btnAdd_Click" 
        ValidationGroup="Add" />
    <br />
</asp:Content>

