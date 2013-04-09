<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Key" HeaderText="Item" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Value") %>' 
                        Height="22px" Width="67px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    Subtotal:
    <asp:Label ID="lblSubtotal" runat="server" Text="$20.00"></asp:Label>
    <br />
    Sales Tax:
    <asp:Label ID="lblTax" runat="server" Text="$20.00"></asp:Label>
    <br />
    Total:
    <asp:Label ID="lblTotal" runat="server" Text="$20.00"></asp:Label>
    <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update Cart" />
    <asp:Button ID="btnCheckout" runat="server" Text="Checkout" />
</asp:Content>

