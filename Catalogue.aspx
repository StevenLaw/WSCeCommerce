<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Catalogue.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        Height="30px" Width="93px" DataKeyNames="PID" 
        DataSourceID="LinqDataSource1">
        <Columns>
            <asp:ButtonField Text="Go to Product" />
            <asp:BoundField HeaderText="PID" DataField="PID" InsertVisible="False" 
                ReadOnly="True" SortExpression="PID" Visible="False"></asp:BoundField>
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
</asp:GridView>
<br />
<asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="WscDbDataContext" EntityTypeName="" TableName="Products">
</asp:LinqDataSource>
</asp:Content>

