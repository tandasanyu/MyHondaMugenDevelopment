using System;
using System.Collections.Generic;
using System.Data;
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
        //get posisi
        string sql_posisi = "select user_posisi, id_lamaran from data_lamaran where id_lamaran = "+IdLamar+"";
        List<string> posisi = cn.KelasKoneksi_SelectGlobal(sql_posisi,"3");
        LblPosisi.Text = posisi[1].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('Id : "+IdLamar+"'); ", true);
        //**get data_diri
        string sql_datadiri = "select Nama_Lengkap from Data_Diri where id_lamaran = " + Convert.ToInt32(IdLamar) + "";
        //string sql_datadiri = "select * from data_diri b inner join Data_UploadCV a on b.Id_lamaran = a.Id_lamaran where where b.id_lamaran = " + Convert.ToInt32(IdLamar) + "";
        List<String> hasil_dataDiri = cn.KelasKoneksi_SelectGlobal(sql_datadiri, "6");
        
        if (hasil_dataDiri.Count != 0)
        {
            LblTTD.Text = hasil_dataDiri[0];      
        }
        //get 
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto, Date_Upload from Data_UploadCV where Id_lamaran = " + Convert.ToInt32(IdLamar) + "", "8");
        LblDate.Text = Path_Foto[1];
        //**get photo pelamar
        string sql = "select Path_Foto from Data_UploadFoto where id_lamaran = "+Convert.ToInt32(IdLamar) +"";
        List<String> hasil = cn.KelasKoneksi_SelectGlobal(sql, "5");
        if (hasil.Count != 0)
        {
            ImagePelamar.ImageUrl = "../UploadFile/Foto/"+hasil[0] +"";
        }
        //Checkboxlist Status Perkawinan (1=menikah, 2=lajang, 3=duda/janda)
        List <string> status_pernikahan = cn.KelasKoneksi_SelectGlobal("select status_pernikahan from data_pasangan where id_lamaran = "+ IdLamar + "", "11");

        if (status_pernikahan.Count == 0) {
            CheckBoxListStatusPerkawinan.SelectedIndex = 1;
        } else if (status_pernikahan[0].ToString() == "Menikah") {
            CheckBoxListStatusPerkawinan.SelectedIndex = 0;
        } else if (status_pernikahan[0].ToString() == "Duda/Janda") {
            CheckBoxListStatusPerkawinan.SelectedIndex = 2;
        }

        //get union value save in datatable 
        //DataTable dt_statuspernikahan = new DataTable();
        //string sqlcmd_statuspern = "select * from statuspernikahan where id_lamaran = "+IdLamar+""
        //dt_statuspernikahan = cn.PullData(sqlcmd_statuspern);

    }



}