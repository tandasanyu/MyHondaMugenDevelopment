using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class listpo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userAkses = (string)(Session["username"]);
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        con.Open();
        DataSet ds1 = new DataSet();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- TERIMA BARANG'", con);

        da1.Fill(ds1);
        int count1 = ds1.Tables[0].Rows.Count;
        if (count1 == 0)
        {
            form1.Visible = false;
        }
        else
        {
            form1.Visible = true;
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
   
    protected void btnTerima_Click(object sender, EventArgs e)
    {
        string jumlahTerima = txtJumlahTerima.Text;
        string tglTerima = txtTanggalTerima.Text;
        string idTerima = Request.QueryString["id"];
        string userTerima = (string)(Session["username"]);
        DateTime myDate = DateTime.Now;
        string cs2 = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs2);
        SqlCommand cmd = new SqlCommand("UPDATE fmbbody SET jumlahterima = jumlahterima + '" + jumlahTerima + "' WHERE idbody = '" + idTerima + "'", con);
        SqlCommand cmd2 = new SqlCommand("INSERT INTO pofmbrcv (pofmbrcv_idbody, pofmbrcv_jumlahterima, pofmbrcv_tglterima, pofmbrcv_terimaoleh) VALUES ('" + idTerima + "', '" + jumlahTerima + "', '" + tglTerima + "', '" + userTerima + "')", con);
        con.Open();
        
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter("SELECT jumlahterima, jumlahitem, idbody FROM fmbbody WHERE idbody = '" + idTerima + "' GROUP BY jumlahterima, jumlahitem, idbody HAVING(SUM(jumlahitem - jumlahterima)) < '1'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT jumlahterima, jumlahitem, idbody FROM fmbbody WHERE idbody = '" + idTerima + "' GROUP BY jumlahterima, jumlahitem, idbody HAVING(SUM(jumlahitem - jumlahterima)) < '" + jumlahTerima + "'", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                if (jumlahTerima == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Anda belum memasukkan jumlah barang yang anda terima !');</script>");
                }
                else if (jumlahTerima == "0")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa menerima dengan jumlah 0 !');</script>");
                }
                else if (tglTerima == "0")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Isi tanggal terima terlebih dahulu !');</script>");
                }
                else if (idTerima == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak mendapatkan Inisial Stok yang ingin anda terima !');</script>");
                }
                else {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Sukses ! Anda telah berhasil menerima barang, Stok anda telah bertambah " + txtJumlahTerima.Text + " !');</script>");
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    Response.Redirect("listpo.aspx");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah yg diterima lebih besar dari pada sisa !');</script>");
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Semua barang sudah diterima !');</script>");
        }
        con.Close();
    }
}