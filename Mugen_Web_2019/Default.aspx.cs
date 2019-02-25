using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection sconn = new SqlConnection(@"Data Source=192.168.0.88;Password=mugensaya;User ID=sayamugen;Initial Catalog=mugensupport;");
        sconn.Open();

        DataSet ds = new DataSet();
        string user = txtUsername.Text;
        string pass = txtPassword.Text;

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_user WHERE username = '" +user+ "' AND password = '" +pass+"'", sconn);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
            if (count == 0)
            {
                Label1.Text = "Username / Password salah !";
            }
            else
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT kddivisi, kdcabang FROM [tb_user] WHERE username = '" + txtUsername.Text + "'";
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string kddivisi = reader["kddivisi"].ToString();
                            string kdcabang = reader["kdcabang"].ToString();
                            Session["kddivisi"] = kddivisi;
                            Session["kdcabang"] = kdcabang;

                        Session["username"] = txtUsername.Text;
                        DateTime myDate = DateTime.Now;
                        string strTgl = myDate.ToString("MM/dd/yyyy hh:mm:ss tt");
                        string auth = Request.QueryString["goto"];
                        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
                        SqlConnection con = new SqlConnection(cs);
                        SqlCommand cmd = new SqlCommand("UPDATE tb_user SET online = 'Y', lastlogin = '" + strTgl + "' WHERE username = '" + txtUsername.Text + "'", con);
                        con.Open();

                        if (auth == null)
                        {
                            cmd.ExecuteNonQuery();
                            Response.Redirect("home.aspx");
                        }
                        else
                        {
                            cmd.ExecuteNonQuery();
                            Response.Redirect("" + auth + "");
                        }

                        con.Close();
                    }
                    }
                    connection.Close();
                }
            
            }
        sconn.Close();
    }
}
