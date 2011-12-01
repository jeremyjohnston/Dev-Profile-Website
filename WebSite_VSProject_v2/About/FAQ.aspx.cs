using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class About_FAQ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Note - This is only used in place of database.  Once the DB is connected this will be pulled with a query.
        DataTable dtFAQ = new DataTable();
        dtFAQ.Columns.Add(new DataColumn("Question", Type.GetType("System.String")));
        dtFAQ.Columns.Add(new DataColumn("Answer", Type.GetType("System.String")));

        DataRow drQuestion1 = dtFAQ.NewRow();
        drQuestion1["Question"] = "What is Indie Game Dev Zone?";
        drQuestion1["Answer"] = "Indie Game Dev Zone, or IGDZ, is an independent website which provides a place for developers of 'Indie' games can create profiles, post projects, and follow/network with other developers and their projects.";
        DataRow drQuestion2 = dtFAQ.NewRow();
        drQuestion2["Question"] = "Can anyone join Indie Game Dev Zone?";
        drQuestion2["Answer"] = "Yes! Accounts are free and registration is simple.";
        DataRow drQuestion3 = dtFAQ.NewRow();
        drQuestion3["Question"] = "Is Indie Game Dev Zone only for 'Game' developers?";
        drQuestion3["Answer"] = "No.  Although the creators of IGDZ initially planned the site with game developers in mind, it can be the home of just about any kind of indie developer wishing to share his or her craft!";
        DataRow drQuestion4 = dtFAQ.NewRow();
        drQuestion4["Question"] = "Can you upload videos to IGDZ?";
        drQuestion4["Answer"] = "Absolutely! IGDZ allows for uploading most common content formats, including but not limited to: videos, images, text files, source code, compiled demos, etc.";
        DataRow drQuestion5 = dtFAQ.NewRow();
        drQuestion5["Question"] = "Question 5?";
        drQuestion5["Answer"] = "Here is a dummy answer for some place text.  If the site was more fully developed with an actual client-base then as questions become more frequently asked they could be added here.";

        dtFAQ.Rows.Add(drQuestion1);
        dtFAQ.Rows.Add(drQuestion2);
        dtFAQ.Rows.Add(drQuestion3);
        dtFAQ.Rows.Add(drQuestion4);
        dtFAQ.Rows.Add(drQuestion5);

        rptFAQ.DataSource = dtFAQ;
        rptFAQ.DataBind();

    }
    protected void rptFAQ_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
}