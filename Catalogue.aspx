<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Catalogue.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title id="titleElement" runat="server"></title>
    
    <style type="text/css">
        .hidden
        {
            visibility: hidden;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="gvCatalogue" runat="server" AutoGenerateColumns="False" 
        Height="30px" Width="100%" DataKeyNames="PID" 
        DataSourceID="LinqDataSource1" AllowPaging="True" 
        onselectedindexchanged="gvCatalogue_SelectedIndexChanged" PageSize="5" 
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
        CellPadding="4" CellSpacing="2" ForeColor="Black">
        <Columns>
            <asp:CommandField SelectText="Go to Product" ShowSelectButton="True" />
            <asp:BoundField HeaderText="PID" DataField="PID" InsertVisible="False" 
                ReadOnly="True" SortExpression="PID" Visible="False">
            </asp:BoundField>
            <asp:BoundField HeaderText="Type" DataField="Type" SortExpression="Type" 
                Visible="False"></asp:BoundField>
            <asp:BoundField HeaderText="Name" DataField="Name" SortExpression="Name"></asp:BoundField>
            <asp:BoundField HeaderText="Quantity" DataField="Quantity" 
                SortExpression="Quantity"></asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" />
            <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" 
                Visible="False" />
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="100px" 
                        ImageUrl='<%# Eval("Image") %>' Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
</asp:GridView>
<br />
<asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="WscDbDataContext" EntityTypeName="" TableName="Products">
</asp:LinqDataSource>
</asp:Content>

