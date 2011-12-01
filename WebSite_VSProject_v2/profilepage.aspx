<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Siteprofile.master" AutoEventWireup="true"
    CodeFile="profilepage.aspx.cs" Inherits="profilepage" %>
    
    <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
        <style type="text/css">
            #TextArea1
            {
                height: 139px;
                width: 430px;
            }
            #TextArea2
            {
                height: 147px;
                width: 430px;
            }
            #TextArea_ProjectDescription
            {
                height: 96px;
                width: 697px;
            }
            #TextArea_MemberList
            {
                width: 691px;
                height: 114px;
            }
            div
            {
                border: thin ridge #00CCFF; 
                text-align:left;
                
            }
            p
            {
                text-align:left;
                font-size: medium; 
                font-weight: bold; 
                color: #000000;
            }
               
        </style>

    <script language="javascript" type="text/javascript">

    </script>
</asp:Content>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2 style="text-align:center;">
         <strong>Welcome to INDIE GAME DEV ZONE</strong></h2>
    <p style="text-align:center;">
         We are Independent Game Development Zone </p>
    <p style="text-align:center;">
         Not userXXXX? 
         <asp:HyperLink ID="HyperLink_Logoff" runat="server" NavigateUrl="~/Default.aspx">Log Off</asp:HyperLink>
    </p>
    <asp:Image ID="Image1" runat="server" Height="230px" Width="150px" />
    <br />
    <asp:Label ID="Label_imageUrl" runat="server" Text="Label"></asp:Label>
    <br />

    <asp:Button ID="Button1" runat="server" onclick="btnFileUpload_Click" 
        Text="Upload Portrait" />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    
    <br />
    <br />
    
    <div style="border: thin ridge #00CCFF; text-align:left;" align="center">
        <p >Account Information</p>
        <asp:Button ID="Button3" runat="server" Text="Edit" />
        <br />
        <asp:Label ID="Label_Userid" runat="server" Text="UserID"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox_Useid" runat="server" Width="133px"></asp:TextBox>  
        <asp:Label ID="Label_display_useid" runat="server"></asp:Label>
        <br />  

        <asp:Label ID="Label_Password" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TextBox_Password"  TextMode="Password" runat="server" 
            Width="133px"></asp:TextBox>
        <asp:Label ID="Label_display_password"  runat="server"></asp:Label>
        <br />
    </div>
    <br />
    
    
    <br />
    <div  >
        <p>Personal Information</p>
        <asp:Button ID="Button4" runat="server" Text="Edit" />
        <br />
        <asp:Label ID="Label_Name" runat="server" Text="Name" Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox_Name" runat="server" Width="133px" 
           
            ></asp:TextBox>  
        <asp:Label ID="Label_display_name" runat="server"></asp:Label>
        <br />      
        <asp:Label ID="Label_Address" runat="server" Text="Address" Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox_Address" runat="server" Width="133px"></asp:TextBox>
        <asp:Label ID="Label_display_address" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label_Phone" runat="server" Text="PhoneNumber" Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox_Phone" runat="server" Width="133px"></asp:TextBox>
        <asp:Label ID="Label_display_phonenumber" runat="server"></asp:Label>
        <br />
        </div>
    <br />
    
    <br />
    <div>
        <p>Education Information</p>
        <asp:Button ID="Button5" runat="server" Text="Edit" />
        <br />
     <asp:Label ID="Label_StudentId" runat="server" Text="StudentID" Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox_StudentId" runat="server"></asp:TextBox>
        <asp:Label ID="Label_display_studentid" runat="server"></asp:Label>
        <br />
         <asp:Label ID="Label_School" runat="server" Text="School" Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox_School" runat="server"></asp:TextBox>
        <asp:Label ID="Label_display_school" runat="server"></asp:Label>
        <br />
         <asp:Label ID="Label_Major" runat="server" Text="Major" Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox_Major" runat="server"></asp:TextBox>
        <asp:Label ID="Label_display_major" runat="server"></asp:Label>
        <br />
         <asp:Label ID="Label_EStartDate" runat="server" Text="Start Date" 
            Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox_EStartDate" runat="server"></asp:TextBox>
        <asp:Label ID="Label_display_estartdate" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label_EEndDate" runat="server" Text="End Date" Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox_EEndDate" runat="server"></asp:TextBox>
        <asp:Label ID="Label_display_eenddate" runat="server"></asp:Label>
        <br />
        <br />
    </div>
    <br />
    
    <br />
    <div >
        <p>   Work Information</p>
        <asp:Button ID="Button6" runat="server" Text="Edit" />
        <br />
    <asp:Label ID="Label_Company" runat="server" Text="Company" Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox_Company" runat="server"></asp:TextBox>
        <asp:Label ID="Label_display_company" runat="server"></asp:Label>
        <br />
         <asp:Label ID="Label_Position" runat="server" Text="Position" Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox_Position" runat="server"></asp:TextBox>
        <asp:Label ID="Label_display_position" runat="server"></asp:Label>
        <br />
         <asp:Label ID="Label_Description" runat="server" Text="Description" 
            Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox_Description" runat="server"></asp:TextBox>
        <asp:Label ID="Label_display_description" runat="server"></asp:Label>
        <br />
         <asp:Label ID="Label_WStartDate" runat="server" Text="Start Date" 
            Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox_WStartDate" runat="server"></asp:TextBox>
        <asp:Label ID="Label_display_wstartdate" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label_WEndDate" runat="server" Text="End Date" Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox_WEndDate" runat="server"></asp:TextBox>
        <asp:Label ID="Label_display_wenddate" runat="server"></asp:Label>
        <br />
    </div>
    <br />
    
    <div  >
        <p>Project</p>
        <p>Project Description</p>
        <asp:Button ID="Button7" runat="server" Text="Edit" />
        <br />
        <textarea id="TextArea_ProjectDescription" name="S2" rows="6"  Runat="server" 
            cols="50"></textarea><br />
        <asp:Label ID="Label_display_projectdescription" runat="server"></asp:Label>
        <br />
        <p>MemberList</p>
        <asp:Button ID="Button8" runat="server" Text="Edit"  />
        <br />
        <textarea id="TextArea_MemberList" name="S1" rows="6"  Runat="server" cols="50"></textarea><br />
        <asp:Label ID="Label_display_memberlist" runat="server"></asp:Label>
        <br />
        <br />
        <p>Contacts</p>
        <asp:Button ID="Button9" runat="server" Text="Edit" />
        <br />
        <asp:Label ID="Label_ContactName" runat="server" Text="Contact Name"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox_ContactName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label_ContactPhoneNumber" runat="server" Text="Phone Number "></asp:Label>
        &nbsp;<asp:TextBox ID="TextBox_ContactPhoneName" runat="server"></asp:TextBox>
        <br />
        <br />
        <p>Demo</p>
    </div>
    <br />
    
    <br />
   <div  style="text-align:center;">
   <asp:Button ID="Button2" runat="server" Text="Save" onclick="Button2_Click" 
           style="height: 26px"/>

   
   </div>

    <br />

</asp:Content>