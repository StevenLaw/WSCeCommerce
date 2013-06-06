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
        onrowdeleting="gvCart_RowDeleting" CellPadding="4" ForeColor="Black" 
        GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" 
        BorderStyle="None" BorderWidth="1px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Item" HeaderText="Item" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' 
                        Height="22px" Width="67px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" />
            <asp:BoundField DataField="Message" HeaderText="Message" />
            <asp:BoundField DataField="LineTotal" DataFormatString="{0:c}" 
                HeaderText="Line Total" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
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
    <asp:Button ID="btnUpdate" runat="server" Text="Update Cart" 
        onclick="btnUpdate_Click" />
    <asp:Button ID="btnCheckout" runat="server" Text="Checkout" Height="26px" 
        onclick="btnCheckout_Click" />
</asp:Content>

