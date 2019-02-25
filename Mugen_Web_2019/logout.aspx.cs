using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = (string)(Session["username"]);
               DateTime myDate = DateTime.Now;
        string strTgl = myDate.ToString("MM/dd/yyyy hh:mm:ss tt");
         string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("UPDATE tb_user SET online = 'N', lastlogout = '" +strTgl+ "' WHERE username = '" + str + "'", con);
                con.Open();

                
                            cmd.ExecuteNonQuery();
                             Session.Abandon();
                            Response.Redirect("default.aspx");
                     
                con.Close();
    }
}
