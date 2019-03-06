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

    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        string username = TxtUsername.Text;
        string pswd = TxtPswd.Text; 
        string SqlCmd = "select Username_Login,Password_Login, User_Posisi, User_Status, from Login_User where Username_login = '"+username+"' ";
        KelasKoneksi cn = new KelasKoneksi();
        cn.KelasKoneksi_Login(SqlCmd);
        ArrayList aL = cn.ArrayLogin;

        foreach (string item in aL) {
            Response.Write("<script>alert('Value : "+item+"')</script>");
        }
        
    }
}