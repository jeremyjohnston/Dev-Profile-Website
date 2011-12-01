<%@ Page Title="Browse Projects" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Browse.aspx.cs" Inherits="Browse" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        BROWSE</h2>
<p>
        Site-wide search :&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="SEARCH" />
</p>
    <p>
        
        <asp:Table ID="Table1" runat="server" Height="150px" Width="529px" 
            Caption="Browse Projects" CellPadding="5" CellSpacing="10">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"><asp:Image ID="Image1" runat="server" BorderColor="#1892BB" BorderStyle="Solid" ImageUrl="~/Images/project-1.png" /></asp:TableCell>
                <asp:TableCell runat="server"><asp:Image ID="Image2" runat="server" BorderColor="#1892BB" BorderStyle="Solid" ImageUrl="~/Images/project-2.png" /></asp:TableCell>
                <asp:TableCell runat="server"><asp:Image ID="Image3" runat="server" BorderColor="#1892BB" BorderStyle="Solid" ImageUrl="~/Images/project-3.png" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"><a href="profilepage.aspx"><asp:Image ID="Image4" runat="server" BorderColor="#1892BB" BorderStyle="Solid" ImageUrl="~/Images/project-1.png" /></a></asp:TableCell>
                <asp:TableCell runat="server"><a href="profilepage.aspx"><asp:Image ID="Image5" runat="server" BorderColor="#1892BB" BorderStyle="Solid" ImageUrl="~/Images/project-2.png" /></a></asp:TableCell>
                <asp:TableCell runat="server"><a href="profilepage.aspx"><asp:Image ID="Image6" runat="server" BorderColor="#1892BB" BorderStyle="Solid" ImageUrl="~/Images/project-3.png" /></a></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
