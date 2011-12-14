using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string shangci = Request.UrlReferrer.ToString();
        Label1.Text = shangci;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Insert
        SqlDataSource1.InsertCommand = "INSERT INTO Users(Email, password, isDeleted, ModifiedDate, ProfilePictureLocation, fkSecurityQuestionID, SecurityAnswer,Description, FirstName, LastName) VALUES ('eeee@gmail.com', '666666', 0, GETDATE(), @ProfilePictureLocation, @fkSecurityQuestionID, @SecurityAnswer, @Description, @FirstName, @LastName)";
        SqlDataSource1.Insert();
        SqlDataSource2.InsertCommand = "INSERT INTO WorkInformations(fkUserID, Company, Position, Description, Description, StartDate, EndDate, isDeleted, ModifiedDate) VALUES (3, 'KFC', 'CEO', 'Cleaner', 'busy', CONVERT (DATETIME, '2011-05-04 00:00:00', 102), CONVERT (DATETIME, '2012-03-04 00:00:00', 102), 0, GETDATE())";
        SqlDataSource2.Insert();
        SqlDataSource3.InsertCommand = "INSERT INTO Educations(fkUserID, StudentID, School, Major, StartDate, EndDate, isDeleted, ModifiedDate) VALUES (3, '444444', 'SMU', 'CS', CONVERT (DATETIME, '2011-09-30 00:00:00', 102), CONVERT (DATETIME, '2015-03-03 00:00:00', 102), 0, GETDATE())";
            SqlDataSource3.Insert();

    }
}