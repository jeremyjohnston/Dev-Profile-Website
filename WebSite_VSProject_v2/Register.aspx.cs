using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //make all error labels invisible on click, then make the relevant ones visible
        resetLabels(this);

        //SqlDataSource1.InsertCommand = "INSERT INTO Users VALUES ('" + TextBox1.Text + "','Test123',0,GETDATE(),'',1,'Answer','desc')";
        //SqlDataSource1.Insert();

        //check to see that all required fields are filled in
        ValidateFields();
        
    }
    private void ValidateFields()
    {
        if (UserTxt.Text.Trim().Equals("") || PasswordTxt1.Text.Trim().Equals("") || PasswordTxt2.Text.Trim().Equals("") || SecurityTxt.Text.Trim().Equals("") || FirstNameTxt.Text.Trim().Equals("") || LastNameTxt.Text.Equals(""))
        {
            ErrorLbl.Visible = true;
            ErrorLbl.Text = "Please fill in all required fields.";
            if (UserTxt.Text.Trim().Equals(""))
            {
                UsrLbl.Visible = true;
                UsrLbl.Text = "Required Field";
            }
            if (PasswordTxt1.Text.Trim().Equals(""))
            {
                PasswordLbl1.Visible = true;
                PasswordLbl1.Text = "Required Field";
            }
            if (PasswordTxt2.Text.Trim().Equals(""))
            {
                PasswordLbl2.Visible = true;
                PasswordLbl2.Text = "Required Field";
            }
            if (SecurityTxt.Text.Trim().Equals(""))
            {
                SecurityLbl.Visible = true;
                SecurityLbl.Text = "Required Field";
            }
            if (FirstNameTxt.Text.Trim().Equals(""))
            {
                FirstNameLbl.Visible = true;
                FirstNameLbl.Text = "Required Field";
            }
            if (LastNameTxt.Text.Trim().Equals(""))
            {
                LastNameLbl.Visible = true;
                LastNameLbl.Text = "Required Field";
            }
        }
        //now check that the passwords match
        else if (!PasswordTxt1.Text.Trim().Equals(PasswordTxt2.Text.Trim()))
        {
            ErrorLbl.Visible = true;
            ErrorLbl.Text = "Submission error: Passwords do not match.";
            PasswordLbl1.Visible = true;
            PasswordLbl1.Text = "Passwords do not match.";
        }
        //do everything else here
        else
        {
            ErrorLbl.Visible = true;
            ErrorLbl.Text = "So far so good!";

            //check if username (e-mail) already exists
           //SqlDataSource2.Select(DataSourceSelectArguments.Empty);
            
           //check file upload things, make sure they are working

        }
    }
    private void resetLabels(Control Page)
    {
        foreach (Control ctrl in Page.Controls)
        {
            if (ctrl is Label)
            {
                ((Label)(ctrl)).Visible = false;
            }
            else
            {
                if (ctrl.Controls.Count > 0)
                {
                    resetLabels(ctrl);
                }
            }
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void SqlDataSource1_Selecting1(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    
}
