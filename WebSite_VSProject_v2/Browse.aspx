<%@ Page Title="Browse Projects" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Browse.aspx.cs" Inherits="Browse" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>BROWSE</h2>
<p>
 
        Site-wide search :&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="SEARCH" />
</p>

    <p>
            <asp:SqlDataSource ID="IGDZdb" runat="server" 
            ConnectionString="<%$ ConnectionStrings:IndyDevZoneConnectionString2 %>" 
            SelectCommand="SELECT [ProjectName], [ProjectTags], [ProjectImageLocation] FROM [Projects]">
            </asp:SqlDataSource>


        <asp:GridView ID="GridView1" runat="server" DataSourceID="IGDZdb" 
           AutoGenerateColumns="False" GridLines="None" 
                onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>

                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" 
                    SortExpression="ProjectName"/>
                <asp:ImageField DataImageUrlField="ProjectImageLocation" 
                    DataImageUrlFormatString="~\Images\{0}.png" HeaderText="Project">
                </asp:ImageField>
                <asp:BoundField DataField="ProjectTags" HeaderText="ProjectTags" 
                    SortExpression="ProjectTags" />
            </Columns>
        </asp:GridView>

    <p>
        &nbsp;</p>
</asp:Content>
