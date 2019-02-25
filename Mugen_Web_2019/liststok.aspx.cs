using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userAkses = (string)(Session["username"]);
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        con.Open();
        
        DataSet ds1 = new DataSet();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- VIEW STOK'", con);

        da1.Fill(ds1);
        int count1 = ds1.Tables[0].Rows.Count;
        if (count1 == 0)
        {
            form1.Visible = false;
            lblNotif.Visible = true;
        }
        else
        {
            form1.Visible = true;
            lblNotif.Visible = false;
        }
        DataSet ds2 = new DataSet();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- HAND OVER STOK'", con);

        da2.Fill(ds2);
        int count2 = ds2.Tables[0].Rows.Count;
        if (count2 == 0)
        {
            btnKeluar.Visible = false;
            lblAlert.Visible = true;
        }
        else
        {
            btnKeluar.Visible = true;
            lblAlert.Visible = false;
        }
        DataSet ds3 = new DataSet();
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- APPROVAL STOK OUT'", con);

        da3.Fill(ds3);
        int count3 = ds3.Tables[0].Rows.Count;
        if (count3 == 0)
        {
            GridView2.Visible = false;
        }
        else
        {
            GridView2.Visible = true;
        }
        con.Close();
        if (Session["username"] != null)
        {
            
        }
        else
        {
            Response.Redirect("default.aspx");
        }

    }
    protected void GetTime(object sender, EventArgs e)
    {
        GridView1.DataBind();
        GridView2.DataBind();
    }
    protected void btnKeluar_Click(object sender, EventArgs e)
    {
        string jumlahKeluar = txtJumlahKeluar.Text;
        string idKeluar = txtIdKeluar.Text;
        string userKeluar = txtNamaKeluar.Text;
        string depKeluar = txtDivisi.Text;
        DateTime myDate = DateTime.Now;
        string tglKeluar = myDate.ToString("MM/dd/yyyy hh:mm:ss tt");
        string cs2 = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs2);
        SqlCommand cmd = new SqlCommand("UPDATE fmbbody SET jumlahkeluar = jumlahkeluar + '" + jumlahKeluar + "' WHERE idbody = '" + idKeluar + "'", con);
        SqlCommand cmd2 = new SqlCommand("INSERT INTO pofmbout (pofmbout_idbody, pofmbout_jumlahkeluar, pofmbout_tglkeluar, pofmbout_diserahkan, pofmbout_departemen) VALUES ('" + idKeluar + "', '" + jumlahKeluar + "', '" + tglKeluar + "', '" + userKeluar + "', '" + depKeluar + "')", con);
        con.Open();

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter("SELECT jumlahterima, jumlahkeluar, idbody FROM fmbbody WHERE idbody = '" + idKeluar + "' GROUP BY jumlahkeluar, jumlahterima, idbody HAVING(SUM(jumlahterima - jumlahkeluar)) < '1'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT jumlahterima, jumlahkeluar, idbody FROM fmbbody WHERE idbody = '" + idKeluar + "' GROUP BY jumlahterima, jumlahkeluar, idbody HAVING(SUM(jumlahterima - jumlahkeluar)) < '" + jumlahKeluar + "'", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                if(txtNamaKeluar.Text == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Silahkan isi nama orang yg ingin anda berikan barang !');</script>");
                }
                else if(txtJumlahKeluar.Text == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Silahkan isi jumlah barang yg ingin anda keluarkan !');</script>");
                }
                else if(txtIdKeluar.Text == ""){
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak mendapatkan Inisial Stok yang akan dikeluarkan !');</script>");
                }
                else if (txtDivisi.Text == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Pilih departemen anda !');</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Sukses ! Anda telah membuat pengajuan, menunggu approval');</script>");
                    cmd2.ExecuteNonQuery();
                }
               
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah stok yang ingin anda keluarkan lebih besar dari pada stok yang tersedia !');</script>");
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Anda tidak memiliki Stok untuk melakukan pengeluaran barang !');</script>");
        }
        con.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string jumlahKeluar = Request.QueryString["q3"];
        string idKeluar = Request.QueryString["q2"];
        string idPo = Request.QueryString["q"];
        string user = (string)(Session["username"]);
        DateTime myDate = DateTime.Now;
        string tglKeluar = myDate.ToString("MM/dd/yyyy hh:mm:ss tt");
        string cs2 = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs2);
        SqlCommand cmd = new SqlCommand("UPDATE fmbbody SET jumlahkeluar = jumlahkeluar + '" + jumlahKeluar + "' WHERE idbody = '" + idKeluar + "'", con);
        SqlCommand cmd2 = new SqlCommand("UPDATE pofmbout SET pofmbout_approval = '" + user + "', pofmbout_tglapproval = '" + tglKeluar + "' WHERE pofmbout_idpo = '" + idPo + "'", con);
        con.Open();

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter("SELECT jumlahterima, jumlahkeluar, idbody FROM fmbbody WHERE idbody = '" + idKeluar + "' GROUP BY jumlahkeluar, jumlahterima, idbody HAVING(SUM(jumlahterima - jumlahkeluar)) < '1'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT jumlahterima, jumlahkeluar, idbody FROM fmbbody WHERE idbody = '" + idKeluar + "' GROUP BY jumlahterima, jumlahkeluar, idbody HAVING(SUM(jumlahterima - jumlahkeluar)) < '" + jumlahKeluar + "'", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Sukses ! Stok telah terpotong');</script>");
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                Response.Redirect("liststok.aspx");

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah stok yang ingin anda keluarkan lebih besar dari pada stok yang tersedia !');</script>");
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Anda tidak memiliki Stok untuk melakukan pengeluaran barang !');</script>");
        }
        con.Close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string jumlahKeluar = Request.QueryString["q3"];
        string idKeluar = Request.QueryString["q2"];
        string idPo = Request.QueryString["q"];
        string user = (string)(Session["username"]);
        DateTime myDate = DateTime.Now;
        string tglKeluar = myDate.ToString("MM/dd/yyyy hh:mm:ss tt");
        string cs2 = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs2);
        SqlCommand cmd = new SqlCommand("DELETE FROM pofmbout WHERE pofmbout_idpo = '" + idPo + "'", con);
        con.Open();

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM pofmbout WHERE pofmbout_idpo = '" + idPo + "' AND pofmbout_approval IS NOT NULL", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("liststok.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Data anda sudah di approve !');</script>");
        }
        con.Close();
    }
}