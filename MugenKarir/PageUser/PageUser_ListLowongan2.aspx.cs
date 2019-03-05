using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageUser_PageUser_ListLowongan2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string a = ListView1.SelectedValue.ToString();
        //Response.Write("<script>alert('Id Terpilih : "+a+"')</script>");
        Response.Redirect("PageUser_Register.aspx?posisi="+a+"");

    }
}