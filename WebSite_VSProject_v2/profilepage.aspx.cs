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



        protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //Account
            Label_display_useid.Text =TextBox_Useid.Text;
            TextBox_Useid.Visible = false;
            TextBox_Useid.Enabled = false;
            TextBox_Password.Visible = false;
            //Personal
            Label_display_name.Text =": " + TextBox_Name.Text;
            Label_display_address.Text =": " + TextBox_Address.Text;
            Label_display_phonenumber.Text=": " + TextBox_Phone.Text;
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
            
            //Project Description
            Label_display_projectdescription.Text=TextArea_ProjectDescription.InnerText;
           
            //Member List
            Label_display_memberlist.Text = TextArea_MemberList.InnerText;

            TextArea_MemberList.Visible = false;
            TextArea_ProjectDescription.Visible = false;
            Button1.Visible = false;
            
            
        }


       
}