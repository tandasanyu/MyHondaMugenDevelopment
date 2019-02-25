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
public partial class deadlinehardsoft : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userAkses = (string)(Session["username"]);
        string cs2 = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con2 = new SqlConnection(cs2);
        con2.Open();
        DataSet ds2 = new DataSet();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'DAFTAR PERMINTAAN -- VIEW MENU'", con2);

        da2.Fill(ds2);
        int count2 = ds2.Tables[0].Rows.Count;
        if (count2 == 0)
        {
            form1.Visible = false;
        }
        else
        {
            form1.Visible = true;
        }
        DataSet ds3 = new DataSet();
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'DAFTAR PERMINTAAN -- VIEW DATA'", con2);

        da3.Fill(ds3);
        int count3 = ds3.Tables[0].Rows.Count;
        if (count3 == 0)
        {
            GridView1.Visible = false;
        }
        else
        {
            GridView1.Visible = true;
        }
        DataSet ds4 = new DataSet();
        SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'DAFTAR PERMINTAAN -- SWAP'", con2);

        da4.Fill(ds4);
        int count4 = ds4.Tables[0].Rows.Count;
        if (count4 == 0)
        {
            txtSwap.Visible = false;
            drpUnitkerja.Visible = false;
            Button2.Visible = false;
        }
        else
        {
            txtSwap.Visible = true;
            drpUnitkerja.Visible = true;
            Button2.Visible = true;
        }
        DataSet ds5 = new DataSet();
        SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'DAFTAR PERMINTAAN -- SET DEADLINE'", con2);

        da5.Fill(ds5);
        int count5 = ds5.Tables[0].Rows.Count;
        if (count5 == 0)
        {
            txtKode.Visible = false;
            txtTanggal.Visible = false;
            Button1.Visible = false;
        }
        else
        {
            txtKode.Visible = true;
            txtTanggal.Visible = true;
            Button1.Visible = true;
        }
        DataSet ds6 = new DataSet();
        SqlDataAdapter da6 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'DAFTAR PERMINTAAN -- REJECT'", con2);

        da6.Fill(ds6);
        int count6 = ds6.Tables[0].Rows.Count;
        if (count6 == 0)
        {
            
        }
        else
        {
           
        }
        con2.Close();
        string uKode = Request.QueryString["id"];
        txtKode.Text = uKode;
        string swapId = Request.QueryString["swapid"];
        txtSwap.Text = swapId;
        string rejId = Request.QueryString["rejId"];
        if (rejId == "")
        {
        }
        else
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("UPDATE formhardsoft SET resulthardsoft = 'REJECTED' WHERE idhardsoft = '" + rejId + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        txtTanggal.Attributes.Add("readonly", "readonly");

        SqlConnection sconn = new SqlConnection(@"Data Source=192.168.0.88;Password=mugensaya;User ID=sayamugen;Initial Catalog=mugensupport;");
        sconn.Open();

        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM formhardsoft WHERE idhardsoft = '" + swapId + "'", sconn);
        da.Fill(dt);
        foreach (DataRow row in dt.Rows)
        {
            Label6.Text = row.Field<string>(8);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE formhardsoft SET deadline = '" + txtTanggal.Text + "', realdeadline = GETDATE() WHERE idhardsoft = '" + txtKode.Text + "'", con);
        con.Open();

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM formhardsoft WHERE idhardsoft = '" + txtKode.Text + "' AND deadline is null", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Sudah di set deadline terlebih dahulu sebelum anda.');</script>");
        }
        else
        {
            if (txtKode.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Silahkan klik tombol Set Deadline ulang !');</script>");
            }
            else
            {
                if (txtTanggal.Text == "")
                { ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Anda belum mengisi tanggal Deadline pengerjaan.');</script>"); }
                else
                {
                    cmd.ExecuteNonQuery();
                    Response.Redirect("deadlinehardsoft.aspx");
                }
            }
        }
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string tujuanDivisi = drpUnitkerja.Text;
        string swapid = txtSwap.Text;
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE formhardsoft SET tujuandivisi = '" + tujuanDivisi + "' WHERE idhardsoft = '" + swapid + "'", con);
        con.Open();

         if (swapid == "")
            {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Anda klik ulang tombol Swap !');</script>");
        }
            else
            {
                if (tujuanDivisi == "")
                { ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Mohon untuk mengisi unit kerja yang menjadi tujuan SWAP !');</script>"); }
                else
                {
                    cmd.ExecuteNonQuery();
                    Response.Redirect("deadlinehardsoft.aspx");
                }
            }
        
        con.Close();
    }
}
