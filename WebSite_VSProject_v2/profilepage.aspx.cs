using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
public partial class profilepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Account
        TextBox_Useid.Enabled = false;
        TextBox_Password.Enabled = false;
        TextBox_Email.Enabled = false;
        //Personal

        TextBox_Name.Enabled = false;
        TextBox_Address.Enabled = false;
        TextBox_Phone.Enabled = false;
        //Education

        TextBox_StudentId.Enabled = false;
        TextBox_School.Enabled = false;
        TextBox_Major.Enabled = false;
        TextBox_EStartDate.Enabled = false;
        TextBox_EEndDate.Enabled = false;
        //Work

        TextBox_Company.Enabled = false;
        TextBox_Position.Enabled = false;
        TextBox_Description.Enabled = false;
        TextBox_WStartDate.Enabled = false;
        TextBox_WEndDate.Enabled = false;

        //Project Description

        TextBox_MemberList.Enabled =false;
        TextBox_ProjectDescription.Enabled = false;
        TextBox_ContactName.Enabled = false;
        TextBox_ContactPhoneName.Enabled = false;


    }

        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            UploadPicFile(FileUpload1);

        }


        internal readonly string AllowExt = "jpe|jpeg|jpg|png|tif|tiff|bmp|gif|wbmp|swf|psd";

        
        bool CheckValidExt(string sExt)
        {
            bool flag = false;
            string[] aExt = AllowExt.Split('|');
            foreach (string filetype in aExt)
            {
                if (filetype.ToLower() == sExt.Replace(".", ""))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        private void UploadPicFile(System.Web.UI.WebControls.FileUpload Fupload)
        {
              if (Fupload.HasFile)
                {
                    //file format
                    string sExt = Fupload.FileName.Substring(Fupload.FileName.LastIndexOf(".")).ToLower();
                    if (!CheckValidExt(sExt))
                    {
                        Label_imageUrl.Text = "(file format is not correct [ " + AllowExt + " ])";
                        return;
                    }
                    //file size
                    int intFileLength = Fupload.PostedFile.ContentLength;

                    if (intFileLength > 1000 * 1000)
                    {
                        this.Label_imageUrl.Text = "file is larger than 1G, can not upload";
                        return;
                    }
                    Random ran = new Random();
                    string UpDir = "UpFiles/" + DateTime.Now.ToString("yyyyMM"); 
                    Directory.CreateDirectory(Server.MapPath(UpDir));
                   string fileName = UpDir + "/" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + Convert.ToString(ran.Next(100, 999));

                    fileName = fileName + sExt;

                       
                  Fupload.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(fileName));
                  Image1.ImageUrl = fileName;
                        Label_imageUrl.Text = fileName + "upload！";
                    
                }
                else
                    Label_imageUrl.Text = "Choose source！";
                return;

          

        }



        
        protected void Button2_Click(object sender, EventArgs e)
        {
            //there may be time straint or some problems on exchanging data with database, 
            //In order to you can see the basic effect, so I also put label control on the page to show the change after modification.  


            //Account
            Label_display_useid.Text =": "+ TextBox_Useid.Text;           
            Label_display_email.Text = ": " + TextBox_Email.Text;         
            TextBox_Useid.Visible = false;
            //TextBox_Useid.Enabled = false;
            TextBox_Password.Visible = false;
            TextBox_Email.Visible = false;
            // update account
            SqlDataSource1.UpdateCommand = "Update Users SET  ProfilePictureLocation='"+Image1.ImageUrl+"', password ='" + TextBox_Password.Text + "', Email='" + TextBox_Email.Text + "' where pkUserID= '" + System.Convert.ToInt32(TextBox_Useid.Text) + "'";
            SqlDataSource1.Update();
            //-------------------------------------------------------------
            //Personal
            Label_display_name.Text =": " + TextBox_Name.Text;
            Label_display_address.Text =": " + TextBox_Address.Text;
            Label_display_phonenumber.Text=": " + TextBox_Phone.Text;
            
            //
            TextBox_Name.Visible = false;
            TextBox_Address.Visible = false;
            TextBox_Phone.Visible = false;
            
            //Education
            Label_display_studentid.Text =": " +TextBox_StudentId.Text;
            Label_display_school.Text = ": " + TextBox_School.Text;
            Label_display_major.Text = ": " + TextBox_Major.Text;
            Label_display_estartdate.Text = ": " + TextBox_EStartDate.Text;
            Label_display_eenddate.Text=": " + TextBox_EEndDate.Text;
             TextBox_StudentId.Visible = false;
            TextBox_School.Visible = false;
            TextBox_Major.Visible = false;
            TextBox_EStartDate.Visible = false;
            TextBox_EEndDate.Visible = false;
            //if not exist insert,  if exist update. Because time straint, otherwise, we should write a statement, set a flag, when user just register,
            //enter in profile page firstly, insert. Then when user enter next time, update,
            //how project table connect to users table,
            // has no time to update  other parts
            
           // SqlDataSource2.InsertCommand = "SET   IDENTITY_INSERT   Educations   ON";
           // SqlDataSource2.InsertCommand = " INSERT INTO Educations(StudentID, School, Major,  StartDate, EndDate, isDeleted, ModifiedDate) VALUES ('" + TextBox_StudentId.Text + "','" + TextBox_School.Text + "','" + TextBox_Major.Text + "', '" + TextBox_EStartDate.Text + "','" + TextBox_EEndDate.Text + "', 0, GETDATA())";
          //  SqlDataSource2.Insert();
            // SqlDataSource2.InsertCommand = "SET   IDENTITY_INSERT   Educations   OFF"; 

            SqlDataSource2.UpdateCommand = " Update Educations SET StudentID='" + TextBox_StudentId.Text + "', School='" + TextBox_School.Text + "',Major='" + TextBox_Major.Text + "', StartDate='" + TextBox_EStartDate.Text + "', EndDate='" + TextBox_EEndDate.Text + "', isDeleted=0, ModifiedDate=GETDATE() where fkUserID= '" + System.Convert.ToInt32(TextBox_Useid.Text) + "'";
            SqlDataSource2.Update();
            

            //Work
            Label_display_company.Text = ": " + TextBox_Company.Text;
            Label_display_position.Text = ": " + TextBox_Position.Text;
            Label_display_description.Text = ": " + TextBox_Description.Text;
            Label_display_wstartdate.Text =": "+ TextBox_WStartDate.Text;
            Label_display_wenddate.Text= ": " + TextBox_WEndDate.Text;
            TextBox_Company.Visible = false;
            TextBox_Position.Visible = false;
            TextBox_Description.Visible = false;
            TextBox_WStartDate.Visible = false;
            TextBox_WEndDate.Visible = false;

          //  SqlDataSource1.InsertCommand = "INSERT INTO WorkInformations VALUES ('" + TextBox_Company.Text + "','" + TextBox_Position.Text + "', '" + TextBox_Description.Text + "','" + TextBox_WStartDate.Text + "','" + TextBox_WEndDate.Text + "',0,GETDATE())";
          //  SqlDataSource1.Insert();

            SqlDataSource3.UpdateCommand = " Update  WorkInformations SET Company='" + TextBox_Company.Text + "', Position='" + TextBox_Position.Text + "', Description='" + TextBox_Position.Text + "', StartDate='" + TextBox_WStartDate.Text + "',EndDate='" + TextBox_WEndDate.Text + "',isDeleted=0, ModifiedDate=GETDATE() where fkUserID= '" + System.Convert.ToInt32(TextBox_Useid.Text) + "'";
                SqlDataSource3.Update();


            //Project Description
            Label_display_projectdescription.Text=TextBox_ProjectDescription.Text;

            //wait test
         
           
            //Member List
            Label_display_memberlist.Text = TextBox_MemberList.Text;

            TextBox_MemberList.Visible = false;
            TextBox_ProjectDescription.Visible = false;

            Label_display_contactname.Text = ": " + TextBox_ContactName.Text;
            Label_display_contactphonenumber.Text = ": " + TextBox_ContactPhoneName.Text;
            TextBox_ContactName.Visible = false;
            TextBox_ContactPhoneName.Visible = false;

            // wait test
           // SqlDataSource1.InsertCommand = "INSERT INTO UserProjects VALUES ('" + System.Convert.ToInt32(TextBox_Useid.Text) + "','" + System.Convert.ToInt32(TextBox_Useid.Text) + "','" + System.Convert.ToInt32(TextBox_Useid.Text) + "',0,GETDATE())";
           // SqlDataSource1.Insert();


            
        }

        protected void Button_Account_Click(object sender, EventArgs e)
        {

            TextBox_Useid.Enabled = true;
            TextBox_Password.Enabled = true;
            TextBox_Email.Enabled = true;
            TextBox_Useid.Visible = true;
            TextBox_Password.Visible = true;
            TextBox_Email.Visible = true;

        }

        protected void Button_Person_Click(object sender, EventArgs e)
        {
            TextBox_Name.Enabled = true;
            TextBox_Address.Enabled = true;
            TextBox_Phone.Enabled = true;
            TextBox_Name.Visible = true;
            TextBox_Address.Visible = true;
            TextBox_Phone.Visible = true;

        }
        protected void Button_Education_Click(object sender, EventArgs e)
        {
            TextBox_StudentId.Enabled = true;
            TextBox_School.Enabled = true;
            TextBox_Major.Enabled = true;
            TextBox_EStartDate.Enabled = true;
            TextBox_EEndDate.Enabled = true;

            TextBox_StudentId.Visible = true;
            TextBox_School.Visible = true;
            TextBox_Major.Visible = true;
            TextBox_EStartDate.Enabled = true;
            TextBox_EEndDate.Visible = true;
        }
        protected void Button_Work_Click(object sender, EventArgs e)
        {
            TextBox_Company.Enabled = true;
            TextBox_Position.Enabled = true;
            TextBox_Description.Enabled = true;
            TextBox_WStartDate.Enabled = true;
            TextBox_WEndDate.Enabled = true;
            
            TextBox_Company.Visible = true;
            TextBox_Position.Visible = true;
            TextBox_Description.Visible = true;
            TextBox_WStartDate.Visible = true;
            TextBox_WEndDate.Visible = true;
            
            
          

        }
        protected void Button_Project_Click(object sender, EventArgs e)
        {
            TextBox_MemberList.Enabled = true;
            TextBox_ProjectDescription.Enabled = true;
            TextBox_ContactPhoneName.Enabled = true;
            TextBox_ContactName.Enabled = true;

            TextBox_MemberList.Visible = true;
            TextBox_ProjectDescription.Visible = true;
            TextBox_ContactPhoneName.Visible = true;
            TextBox_ContactName.Visible = true;
        }
}