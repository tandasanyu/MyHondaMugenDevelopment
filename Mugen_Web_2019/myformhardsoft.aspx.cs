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

public partial class myformhardsoft : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userAkses = (string)(Session["username"]);
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        con.Open();
        DataSet ds7 = new DataSet();
        SqlDataAdapter da7 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'PERMINTAAN SAYA --- VIEW MENU'", con);

        da7.Fill(ds7);
        int count7 = ds7.Tables[0].Rows.Count;
        if (count7 == 0)
        {
            form1.Visible = false;
        }
        else
        {
            form1.Visible = true;
        }
        con.Close();
        string uKode = Request.QueryString["id"];
        txtKode.Text = uKode;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string kodeHardsoft = txtKode.Text;
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE formhardsoft SET aktual = null, selesai = null, resulthardsoft = null WHERE idhardsoft = '" + txtKode.Text + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM formhardsoft WHERE idhardsoft = '" + txtKode.Text + "' AND aktual is not null AND deadline is not null AND resulthardsoft is not null", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Sudah pernah dibatalkan.');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM formhardsoft WHERE idhardsoft = '" + txtKode.Text + "' AND selesai >= DateAdd(hh, -24, GETDATE())", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Anda sudah tidak bisa re-Closing permintaan ini karena melebihi 24 jam dari tanggal selesai. Silahkan buat pengajuan baru !');</script>");
            }
            else
            {
                if (txtKode.Text == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Klik tombol re-closing ulang !');</script>");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    Response.Redirect("myformhardsoft.aspx");
                }
            }
        }
        con.Close();
    }
}
