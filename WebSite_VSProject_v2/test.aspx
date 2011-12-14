<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    This is a test page, insert instance to database and test
    <span class="Apple-style-span" 
        style="color: rgb(0, 0, 0); font-family: arial, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none; ">
    how to limit editing of a profile page to owning user but allow all to read 
    content.<br />
    <br />
    </span>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IndyDevZoneConnectionString2 %>" 
        SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IndyDevZoneConnectionString2 %>" 
        SelectCommand="SELECT * FROM [WorkInformations]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IndyDevZoneConnectionString2 %>" 
        SelectCommand="SELECT * FROM [Educations]"></asp:SqlDataSource>
</asp:Content>

