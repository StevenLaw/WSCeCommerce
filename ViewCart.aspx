<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .descriptor
        {
            width: 10ex;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" 
        onrowdeleting="gvCart_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Item" HeaderText="Item" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Quantity") %>' 
                        Height="22px" Width="67px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <div class="descriptor">Subtotal:</div>
    <asp:Label ID="lblSubtotal" runat="server" Text="$20.00"></asp:Label>
    <br />
    <div class="descriptor">Sales Tax:</div>
    <asp:Label ID="lblTax" runat="server" Text="$20.00"></asp:Label>
    <br />
    <div class="descriptor">Total:</div>
    <asp:Label ID="lblTotal" runat="server" Text="$20.00"></asp:Label>
    <br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update Cart" />
    <asp:Button ID="btnCheckout" runat="server" Text="Checkout" />
</asp:Content>

