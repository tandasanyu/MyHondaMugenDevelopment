using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PagesHRD_HomeHRD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string val1;
        val1 = Request.QueryString["Menu"];
        if (val1 == null ) {
            MultiViewHRD.ActiveViewIndex = 0;
        }
        else {
            if (val1 == "0")
            {
                MultiViewHRD.ActiveViewIndex = 0;
            }
            else if (val1 == "1")
            {
                MultiViewHRD.ActiveViewIndex = 1;
            }
            else if (val1 == "2")
            {
                MultiViewHRD.ActiveViewIndex = 2;
            }
        }
       
    }
    protected void GetTime(object sender, EventArgs e)
    {
        Label1.Text = "Done";
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {

    }
}