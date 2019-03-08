using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["User"] == null)
        //{
        //    Response.Redirect("~/Login.aspx");
        //}
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        string username = TxtUsername.Text;
        string pswd = TxtPswd.Text;
        string SqlCmd = "select Username_Login,Password_Login, User_Posisi, User_Status, User_Level from Login_User where Username_login = '" + username + "' ";
        KelasKoneksi cn = new KelasKoneksi();
        List<String> aL = cn.KelasKoneksi_Login(SqlCmd);
        //Response.Write("<script>alert('Value : " + aL[0].ToString() + "')</script>");
        if (aL[2].ToString() == "1") {
            if (aL[3].ToString() == "HRD") {
                Session["Logged"] = "Yes";
                Session["User"] = username;
                Response.Redirect("~/PagesHRD/HomeHRD.aspx");
            }
        }
        else {
            Response.Write("<script>alert('User anda tidak aktif di sistem.')</script>");
        }

    }
}