using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Browse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Bind the data to the Page
        Page.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the currently selected row using the SelectedRow property.
        GridViewRow row = GridView1.SelectedRow;
    }
}
