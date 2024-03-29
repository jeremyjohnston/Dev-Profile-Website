using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;

public partial class _Register : System.Web.UI.Page
{
    private String profilePicLoc = "";
    private String projectPicLoc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //SqlDataSource1.InsertCommand = "INSERT INTO Users VALUES ('" + TextBox1.Text + "','Test123',0,GETDATE(),'',1,'Answer','desc')";
        //SqlDataSource1.Insert();
        ErrorLbl.Visible = false;
        //check to see that all required fields are filled in
        if (Page.IsValid)
        {
            //check if username (e-mail) already exists
            if (CheckUsernameUniqueness(UserTxt.Text))
            {
                //Username Check succeeds, move on to further checks or register user.
                
                //check file upload things, make sure they are working
                bool uploadSuccess = true; //checks to see that the file uploaded successfully. if so, continue to inserting stuff into the database!
                
                if (FileUpload1.PostedFile.FileName != "")
                {
                    profilePicLoc = uploadPicture(FileUpload1);
                    if (profilePicLoc == null)
                        uploadSuccess = false;                    
                }
                if (FileUpload2.PostedFile.FileName != "") {
                    projectPicLoc = uploadPicture(FileUpload2);
                    if (projectPicLoc == null)
                        uploadSuccess = false;
                }
                
                if (uploadSuccess)
                {
                    //if uploads go through, insert everything into the table! 
                    insertValuesIntoTable();
                    Response.Redirect("~/Account/Login.aspx");


                }
                
            }
            else
            {
                //Username check fails, display message to user.
                ErrorLbl.Visible = true;
                ErrorLbl.Text = "Error: e-mail is already in use.";
            }
        }
        
    }

    /// <summary>
    /// Inserts all values into the user, userProjects, and Projects table. Uses stored procedures
    /// to coordinate the foreign keys for each table
    /// </summary>
    private void insertValuesIntoTable()
    {
        SqlConnection conn = new SqlConnection(SqlDataSource1.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.Clear();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "stp_CreateUserProject";
        cmd.Connection = conn;
        cmd.Parameters.AddWithValue("@Email", UserTxt.Text);
        cmd.Parameters.AddWithValue("@Password", PasswordTxt1.Text);
        cmd.Parameters.AddWithValue("@FirstName", FirstNameTxt.Text);
        cmd.Parameters.AddWithValue("@LastName", LastNameTxt.Text);
        cmd.Parameters.AddWithValue("@ProfilePictureLocation", profilePicLoc);
        cmd.Parameters.AddWithValue("@SecurityQuestionID", long.Parse(DropDownList1.SelectedValue));
        cmd.Parameters.AddWithValue("@SecurityAnswer", SecurityTxt.Text);
        cmd.Parameters.AddWithValue("@UserDescription", DescTxt.Text);
        cmd.Parameters.AddWithValue("@ProjectName", ProjNameTxt.Text);
        cmd.Parameters.AddWithValue("@ProjectDescription", ProjDescTxt.Text);
        cmd.Parameters.AddWithValue("@ProjectImageLocation", projectPicLoc);//projectPicLoc);
        cmd.Connection.Close();
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();


        //ErrorLbl.Visible = true;
        //ErrorLbl.Text = "yeah for some reason this isnt working :/";
    }
    /// <summary>
    /// Method to check desired username/email against database to insure unique. Returns true if email is unique and not in use, returns false if taken.
    /// </summary>
    /// <param name="userName">Desired username/email to be checked.</param>
    /// <returns>Returns true if email is unique and not in use, returns false if taken.</returns>
    private bool CheckUsernameUniqueness(string userName)
    {
        DataSet dsUserNames = new DataSet();
        StringBuilder sql = new StringBuilder("SELECT Email FROM Users WHERE isDeleted = 0");

        SqlCommand cmd = new SqlCommand(sql.ToString());
        SqlDataAdapter adapter = new SqlDataAdapter();
        cmd.Connection = new SqlConnection(SqlDataSource1.ConnectionString);
        adapter.SelectCommand = cmd;
        if (dsUserNames.Tables.Contains("tblUserNames"))
        {
            dsUserNames.Tables.Remove("tblUserNames");
        }
        adapter.Fill(dsUserNames, "tblUserNames");

        bool result = false;

        foreach (DataRow dr in dsUserNames.Tables["tblUserNames"].Rows)
        {
            result = (dr["Email"].ToString().ToLower() == userName.ToLower() || result);
        }

        return !result;

    }
  /// <summary>
  /// Uploads image provided by FileUpload controls to the server. 
  /// </summary>
  /// <param name="uploader">Desired FileUpload box to upload from</param>
  /// <returns>Returns the (unique, random) name of the file uploaded to the server.</returns>
    private String uploadPicture(FileUpload uploader) {
        //get directory where pictures will go
        String uploadDir = Path.Combine(Request.PhysicalApplicationPath, "Images");
        //get the extension and check that is correct
        String extension = Path.GetExtension(uploader.PostedFile.FileName);
        //check that file is an image
        switch (extension.ToLower())
        {
            case ".bmp":
            case ".gif":
            case ".jpg":
            case ".png":
                break;
            default:
                ErrorLbl.Visible = true;
                ErrorLbl.Text = "File must be an image.";
                return null;
        }
        //generate a unique filename for image so that it doesn't overwrite any existing images
        String imageName = Guid.NewGuid().ToString().Replace("-", string.Empty) + extension;
        String fullUploadPath = Path.Combine(uploadDir, imageName);
        String ServerPath = Request.Url.AbsoluteUri.Replace("Register.aspx", string.Empty) + "Images/" + imageName;
        try
        {
            //ErrorLbl.Visible = true;
            //ErrorLbl.Text = ServerPath;
            uploader.PostedFile.SaveAs(fullUploadPath);

        }
        catch (Exception e)
        {
            ErrorLbl.Visible = true;
            ErrorLbl.Text = e.Message;
            return null;
        }
        return ServerPath;
    }
    
}
