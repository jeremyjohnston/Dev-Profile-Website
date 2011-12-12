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
        SqlDataSource1.InsertCommand = "INSERT INTO Users VALUES ('" + TextBox1.Text + "','Test123',0,GETDATE(),'',1,'Answer','desc')";
        SqlDataSource1.Insert();
    }
}
