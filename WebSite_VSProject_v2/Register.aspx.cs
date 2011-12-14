using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class _Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //SqlDataSource1.InsertCommand = "INSERT INTO Users VALUES ('" + TextBox1.Text + "','Test123',0,GETDATE(),'',1,'Answer','desc')";
        //SqlDataSource1.Insert();

        //check to see that all required fields are filled in
        if (Page.IsValid)
        {
            

            //check if username (e-mail) already exists
            if (CheckUsernameUniqueness(UserTxt.Text))
            {
                //Username Check succeeds, move on to further checks or register user.

                //check file upload things, make sure they are working
                
            }
            else
            {
                //Username check fails, display message to user.

            }
        }
        
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
    
}
