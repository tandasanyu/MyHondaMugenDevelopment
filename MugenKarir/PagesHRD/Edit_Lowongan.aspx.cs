using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PagesHRD_Edit_Lowongan : System.Web.UI.Page
{
    public string id = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        
         id = Request.QueryString["id"];
        if (id != string.Empty) {
            //cari data
            KelasKoneksi cn = new KelasKoneksi();
            List<string> data = cn.KelasKoneksi_SelectGlobal(" select * from List_Lowongan where id_lowongan = " + id + "", "12");
            TxtTglPosting.Text = Convert.ToDateTime(data[2].ToString()).ToShortDateString();
            Label2.Text = data[0].ToString();
            Label1.Text = data[1].ToString();
            if (data[3].ToString()=="0") {
                ShowAlertAndNavigate("Lowongan yang Anda pilih Tidak Aktif, maka Proses Edit tidak Dapat di Lakukan", "HomeHRD.aspx?Menu=1");
            }
        } else {
            ShowAlertAndNavigate("ID lowongan Kosong, Proses Gagal", "HomeHRD.aspx");
        }

    }
    protected void Submit(object sender, EventArgs e)
    {
        //perintah edit
        KelasKoneksi cn = new KelasKoneksi();
        string query_updateLowongan;
        string posisi = string.Empty;
        string kualifikasi = string.Empty;
        posisi = TxtPosisi.Text;
        kualifikasi = Convert.ToString(TextBox1.Text);

        if (posisi== string.Empty || kualifikasi == string.Empty) {
            ShowAlertAndNavigate("Posisi / Detail Lowongan Tidak Boleh Kosong!", "HomeHRD.aspx?Menu=1");
        } else {

            query_updateLowongan = "update List_Lowongan set Posisi = '" + posisi + "', Kualifikasi = '" + kualifikasi + "' where id_lowongan = " + id + "";
            //query_insert_lowongan = "Insert into List_Lowongan (Posisi,Kualifikasi,Status_Lowongan)values ('" + TxtPosisi.Text + "','" + tbxTinymce.Text + "',1)";
            var insert = cn.KelasKoneksi_Insert(query_updateLowongan);
            if (insert == "1")
            {
                ShowAlertAndNavigate("Berhasil Memperbarui Data Lowongan", "HomeHRD.aspx?Menu=1");
            }
            else
            {
                ShowAlertAndNavigate("Gagal Memperbarui Data Lowongan", "HomeHRD.aspx?Menu=1");
            }
        }
    }
    //fungsi untuk redirect 
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