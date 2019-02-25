using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class outstandingpo : System.Web.UI.Page
{
    protected void GetTime(object sender, EventArgs e)
    {
        GridView5.DataBind();
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
