using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageUser_PageUser_FormPertanyaan : System.Web.UI.Page
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
        IdLamar = Request.QueryString["IdLamaran"];
    }
    //kumpulan fungsi 
    public string InsertData_Pertanyaan(string DescSakit, string Keleb, string Kekur, string Keahli, string JobDesc, int HarapGaji, string Tunjangan, string SiapKerja, string Penempatan, string AlasanGabung, string TtgNMugen, string LingkunganKerja)
    {
        string Hasil = string.Empty;
        if (HarapGaji != 0  && DescSakit.Length != 0 && Keleb.Length != 0 && Kekur.Length != 0 && Keahli.Length != 0 && Keahli.Length != 0 && JobDesc.Length != 0 && Tunjangan.Length != 0 && SiapKerja.Length != 0 && Penempatan.Length != 0 && AlasanGabung.Length != 0 && TtgNMugen.Length != 0 && LingkunganKerja.Length != 0)
        {
            if (LingkunganKerja == "3") {
                LingkunganKerja = TextAreaLingkunganKerja.InnerText;
            }

            KelasKoneksi kn = new KelasKoneksi();
            int idLamaran = Convert.ToInt32(IdLamar);
            string SqlCmd = "insert into Data_Pertanyaan values ("+ idLamaran + ", '"+DescSakit+"', '"+Keleb+"', '"+Kekur+"', '"+Keahli+"', '"+JobDesc+"', "+HarapGaji+", '"+Tunjangan+"', "+Convert.ToInt32(SiapKerja)+", "+ Convert.ToInt32(Penempatan)+", '"+AlasanGabung+"', '"+TtgNMugen+"', '"+LingkunganKerja+"')";
            string Hasil_Insert = kn.KelasKoneksi_Insert(SqlCmd);
            if (Hasil_Insert == "1")
            {
                Hasil = "OK";
            }
            else
            {
                Hasil = Hasil_Insert;
            }
        }
        else
        {
            Hasil = "Harap Periksa Form Data Pertanyaan Anda";
        }
        return Hasil;
    }
    public int stats;
    protected void BtnSubmitPertanyaan_Click(object sender, EventArgs e)
    {
        string Hasil = string.Empty;
        
        string LingKerja = Convert.ToString(RadioButtonListLingkunganKerja.SelectedIndex);
        stats = 0;
        if (LingKerja == "3" && TextAreaLingkunganKerja.InnerText == "") {
            stats = 1;
        }
        if (stats == 0)
        {
            if (TxtAreaSakit.InnerText.Length >100 || TxtAreaKelebihan.InnerText.Length > 225 || TxtAreaKekurangan.InnerText.Length > 225 || TxtAreaKeahlian.InnerText.Length > 225 || TxtAreaJobDesc.InnerText.Length > 225 || TextareaTunjangan.InnerText.Length > 225 || TxtAreaAlasanBergabung.InnerText.Length > 225 || TxtAreaPengetahuanHonda.InnerText.Length > 225) {
                ShowAlertAndNavigate("Gagal menyimpan Data, Karakter yang anda Masukan Lebih dari 225 karakter", "../PageUser/PageUser_HomePelamar.aspx");
            } else {
                if (RadioButtonListSakit.SelectedValue == "Ya")
                {
                    Hasil = InsertData_Pertanyaan(TxtAreaSakit.InnerText, TxtAreaKelebihan.InnerText, TxtAreaKekurangan.InnerText, TxtAreaKeahlian.InnerText, TxtAreaJobDesc.InnerText, Convert.ToInt32(TxtGaji.Text), TextareaTunjangan.InnerText, Convert.ToString(RadioButtonListSiapBekerja.SelectedIndex), Convert.ToString(RadioButtonListPenempatan.SelectedIndex), TxtAreaAlasanBergabung.InnerText, TxtAreaPengetahuanHonda.InnerText, LingKerja);
                    if (Hasil == "OK")
                    {
                        //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                        ShowAlertAndNavigate("Berhasil Menyimpan Data", "../PageUser/PageUser_HomePelamar.aspx");
                    }
                    else
                    {
                        //Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan Error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                        ShowAlertAndNavigate("Gagal Menyimpan Data dengan Error : " + Hasil + "", "../PageUser/PageUser_HomePelamar.aspx");
                    }
                }
                else if (RadioButtonListSakit.SelectedValue == "Tidak")
                {
                    Hasil = InsertData_Pertanyaan("--", TxtAreaKelebihan.InnerText, TxtAreaKekurangan.InnerText, TxtAreaKeahlian.InnerText, TxtAreaJobDesc.InnerText, Convert.ToInt32(TxtGaji.Text), TextareaTunjangan.InnerText, Convert.ToString(RadioButtonListSiapBekerja.SelectedIndex), Convert.ToString(RadioButtonListPenempatan.SelectedIndex), TxtAreaAlasanBergabung.InnerText, TxtAreaPengetahuanHonda.InnerText, LingKerja);
                    if (Hasil == "OK")
                    {
                        //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                        ShowAlertAndNavigate("Berhasil Menyimpan Data", "../PageUser/PageUser_HomePelamar.aspx");
                    }
                    else
                    {
                        //Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan Error : " + Hasil + "');</script>");
                        ShowAlertAndNavigate("Gagal Menyimpan Data dengan Error : " + Hasil + "", "../PageUser/PageUser_HomePelamar.aspx");
                    }
                }
            }
        }
        else {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Gagal Menyimpan data, Harap Isi Text Lingkungan Kerja jika anda memilih poin Lainya')", true);
        }        
    }
    //FUNGSI UNTUK ALERT GLOBAL
    public void ShowAlertAndNavigate(string msg, string destination)
    {
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