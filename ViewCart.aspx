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
        onrowdeleting="gvCart_RowDeleting" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
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
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
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

