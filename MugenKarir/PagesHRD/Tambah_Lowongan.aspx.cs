using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Linq;
//ADO NET NAME SPACE
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
public partial class PagesHRD_Tambah_Lowongan : System.Web.UI.Page
{
    //public List<int> ListTgl = new List<int>();
    //public List<DateTime> ListTgl_Pend = new List<DateTime>();
    //public List<string> ListTgl_seluruh = new List<string>();
    private SqlConnection conn;
    public string id = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        TxtTglPosting.Text = DateTime.Now.ToShortDateString();
    }
    //FUNGSI KONEKSII UNTUK INSERT


   //Button Submit Data Lamaran Baru
    protected void Submit(object sender, EventArgs e)
    {
        Posisi.Visible = false;
        Posisi.Text = TxtPosisi.Text;
        Hasil.Visible = false;
        Hasil.Text = tbxTinymce.Text;

        //perintah insert
        KelasKoneksi cn = new KelasKoneksi();
        string query_insert_lowongan;
        query_insert_lowongan = "Insert into List_Lowongan (Posisi,Kualifikasi,Status_Lowongan)values ('"+ TxtPosisi .Text+ "','"+ tbxTinymce .Text+ "',1)";
        var insert = cn.KelasKoneksi_Insert(query_insert_lowongan);
        if (insert == "1") {
            TxtPosisi.Text = "";
            tbxTinymce.Text = "";        
            ShowAlertAndNavigate("Berhasil Menambahkan Data Lowongan", "HomeHRD.aspx?Menu=1");
        }
        else {
            ShowAlertAndNavigate("Gagal Menambahkan Data Lowongan", "HomeHRD.aspx?Menu=1");
        }
    }
    
    protected void BtnOpencon_Click(object sender, EventArgs e)
    {
        KelasKoneksi cn = new KelasKoneksi();
        if (cn.KelasKoneksi_Open()=="1") {
            Response.Write("<script>alert('Koneksi Open')</script>");
        }
        else {
            Response.Write("<script>alert('Koneksi Gagal')</script>");
        }
        
        
    }
    
    protected void BtnClosecon_Click(object sender, EventArgs e)
    {
        //KelasKoneksi cn = new KelasKoneksi();
        //if (cn.KelasKoneksi_Close() == "1")
        //{
        //    Response.Write("<script>alert('Koneksi Close')</script>");
        //}
        //else
        //{
        //    Response.Write("<script>alert('Koneksi Gagal')</script>");
        //}

    }

    public void ShowAlertAndNavigate(string msg, string destination)
    {
        //string alert_redirect_Script = string.Format(@"<script type=""text/javascript"">
        //                               alert('{0}');
        //                                window.location.href = destination;
        //                               </script>", msg);
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alertredirectscript", alert_redirect_Script, false);
        string message = msg;
        string url = destination;
        string script = "window.onload = function(){ alert('";
        script += message;
        script += "');";
        script += "window.location = '";
        script += url;
        script += "'; }";
        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
    }
}