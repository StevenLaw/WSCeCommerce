<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewTransaction.aspx.cs" Inherits="Employee_ViewTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinqDataSource ID="ldsTransactions" runat="server" 
        ContextTypeName="WscDbDataContext" EntityTypeName="" 
        TableName="Transactions" EnableUpdate="True">
    </asp:LinqDataSource>
    <asp:GridView ID="gvTransactions" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" DataSourceID="ldsTransactions" 
        ForeColor="Black" GridLines="Vertical" AllowPaging="True" 
        DataKeyNames="TransactionId" AllowSorting="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="TransactionId" HeaderText="Id" 
                ReadOnly="True" SortExpression="TransactionId" InsertVisible="False" />
            <asp:TemplateField HeaderText="Customer" SortExpression="Customer">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Customer1.FName") %>'></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Customer1.LName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Customer") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DateOfSale" HeaderText="DateOfSale" 
                SortExpression="DateOfSale" />
            <asp:BoundField DataField="ShipDate" HeaderText="ShipDate" 
                SortExpression="ShipDate" />
            <asp:BoundField DataField="AltAddress" HeaderText="AltAddress" 
                SortExpression="AltAddress" />
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
    <input type="hidden" id="transId" value=0 />
    Y indicates an alternate address
    <br />
    S indicates the customer would like to pick the item up in store<br />
    <br />
    Orders:<asp:LinqDataSource ID="ldsOrderLines" runat="server" 
        ContextTypeName="WscDbDataContext" EnableUpdate="True" EntityTypeName="" 
        TableName="OrderLines" Where="TransactionId == @TransactionId">
        <WhereParameters>
            <asp:ControlParameter ControlID="gvTransactions" DefaultValue="0" 
                Name="TransactionId" PropertyName="SelectedValue" Type="Decimal" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" DataKeyNames="TransactionId,PID" DataSourceID="ldsOrderLines" 
        ForeColor="Black" GridLines="Vertical" AllowPaging="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" 
                ReadOnly="True" SortExpression="TransactionId" Visible="False" />
            <asp:TemplateField HeaderText="Product" SortExpression="PID">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Product.Name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Product.Name") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" 
                SortExpression="Quantity" />
            <asp:TemplateField HeaderText="Availability">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Product.Quantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PriceAtSale" HeaderText="Price at Sale" 
                SortExpression="PriceAtSale" DataFormatString="{0:c}" ReadOnly="True" />
            <asp:CheckBoxField DataField="Completed" HeaderText="Completed" 
                SortExpression="Completed" />
            <asp:BoundField DataField="Message" HeaderText="Message" 
                SortExpression="Message" ReadOnly="True" />
            <asp:BoundField DataField="PrintImage" HeaderText="PrintImage" 
                SortExpression="PrintImage" ReadOnly="True" />
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
    <br />
    Alternate address if available:<br />
    <asp:LinqDataSource ID="ldsAddress" runat="server" 
        ContextTypeName="WscDbDataContext" EntityTypeName="" TableName="Addresses" 
        Where="TransactionID == @TransactionID">
        <WhereParameters>
            <asp:ControlParameter ControlID="gvTransactions" DefaultValue="0" 
                Name="TransactionID" PropertyName="SelectedValue" Type="Decimal" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:DetailsView ID="dvAddress" runat="server" AutoGenerateRows="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" DataKeyNames="AddressID,TransactionID" 
        DataSourceID="ldsAddress" ForeColor="Black" GridLines="Vertical" 
        HeaderText="Alternate Address" Height="50px" Width="304px">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Address1" HeaderText="Address1" 
                SortExpression="Address1" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
            <asp:BoundField DataField="ProvState" HeaderText="ProvState" 
                SortExpression="ProvState" />
            <asp:BoundField DataField="PostalZip" HeaderText="PostalZip" 
                SortExpression="PostalZip" />
            <asp:BoundField DataField="Country" HeaderText="Country" 
                SortExpression="Country" />
        </Fields>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
    </asp:DetailsView>
    <br />

</asp:Content>

