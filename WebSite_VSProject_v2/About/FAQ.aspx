<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="About_FAQ" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Frequently Asked Questions (FAQ)</h1>
    <div style="padding-left:50px;">
        <asp:Repeater ID="rptFAQ" runat="server" onitemdatabound="rptFAQ_ItemDataBound" 
            DataSourceID="IGDZdb">
            <ItemTemplate>
                <h3><%#DataBinder.Eval(Container.DataItem,"Question") %></h3>
                <p style="padding-left:50px;"><%#DataBinder.Eval(Container.DataItem,"Answer") %></p>
            </ItemTemplate>
        </asp:Repeater>
        
        <asp:SqlDataSource ID="IGDZdb" runat="server" 
            ConnectionString="<%$ ConnectionStrings:IndyDevZoneConnectionString2 %>" 
            SelectCommand="SELECT * FROM [FAQs] WHERE ([isDeleted] = @isDeleted)">
            <SelectParameters>
                <asp:Parameter DefaultValue="false" Name="isDeleted" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>

