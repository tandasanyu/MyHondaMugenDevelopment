using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PagesHRD_FormPelamar : System.Web.UI.Page
{
    public string IdLamar;
    protected void Page_Load(object sender, EventArgs e)
    {
        //ketika page load, makadi periksa setiap dokumen dengan nomor id lamaran berikut apakah ada. jika ada maka hide tombol
        if (Session["User"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        //get url param       
        IdLamar = Request.QueryString["Id"];
        LblIdLamaran.Text = IdLamar;
        KelasKoneksi cn = new KelasKoneksi();

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('Id : "+IdLamar+"'); ", true);
        //**get data_diri
        string sql_datadiri = "select * from Data_Diri where id_lamaran = " + Convert.ToInt32(IdLamar) + "";
        List<String> hasil_dataDiri = cn.KelasKoneksi_SelectGlobal(sql_datadiri, "6");
        if (hasil_dataDiri.Count != 0)
        {
            //DPNama.Text = hasil_dataDiri[0];
            //DPPanggil.Text = hasil_dataDiri[1];
            //DPTTL.Text = hasil_dataDiri[2]+"/"+hasil_dataDiri[3];
            //if (hasil_dataDiri[3] == "1") { DPJenkel.Text = "Pria"; } else { DPJenkel.Text = "Wanita"; };


        }
        //**get photo pelamar
        string sql = "select Path_Foto from Data_UploadFoto where id_lamaran = "+Convert.ToInt32(IdLamar) +"";
        List<String> hasil = cn.KelasKoneksi_SelectGlobal(sql, "5");
        if (hasil.Count != 0)
        {
            ImagePelamar.ImageUrl = "../UploadFile/Foto/"+hasil[0] +"";
        }
       
    }
}