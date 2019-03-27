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
        if (HarapGaji != 0  && DescSakit != "" && Keleb != "" && Kekur != "" && Keahli != "" && Keahli != "" && JobDesc!="" && Tunjangan!="" && SiapKerja != "" && Penempatan != "" && AlasanGabung !="" && TtgNMugen!="" && LingkunganKerja!= "")
        {
            if (Convert.ToInt32(LingkunganKerja) == 3) {
                LingkunganKerja = TextAreaLingkunganKerja.InnerText;
            }

            KelasKoneksi kn = new KelasKoneksi();
            int idLamaran = Convert.ToInt32(IdLamar);
            string SqlCmd = "insert into Data_Pertanyaan values ("+ idLamaran + ", '"+DescSakit+"', '"+Keleb+"', '"+Kekur+"', '"+Keahli+"', '"+JobDesc+"', "+HarapGaji+", '"+Tunjangan+"', "+Convert.ToInt32(SiapKerja)+", "+ Convert.ToInt32(Penempatan)+", '"+AlasanGabung+"', '"+TtgNMugen+"', "+Convert.ToInt32(LingkunganKerja)+")";
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
    protected void BtnSubmitPertanyaan_Click(object sender, EventArgs e)
    {
        string Hasil = string.Empty;
        if (RadioButtonListSakit.SelectedValue == "Ya") {
             Hasil = InsertData_Pertanyaan(TxtAreaSakit.InnerText, TxtAreaKelebihan.InnerText, TxtAreaKekurangan.InnerText, TxtAreaKeahlian.InnerText, TxtAreaJobDesc.InnerText, Convert.ToInt32(TxtGaji.Text), TextareaTunjangan.InnerText, Convert.ToString(RadioButtonListSiapBekerja.SelectedIndex), Convert.ToString(RadioButtonListPenempatan.SelectedIndex), TxtAreaAlasanBergabung.InnerText, TxtAreaPengetahuanHonda.InnerText, Convert.ToString(RadioButtonListLingkunganKerja.SelectedIndex));
        } else if (RadioButtonListSakit.SelectedValue == "Tidak") {
             Hasil = InsertData_Pertanyaan("--", TxtAreaKelebihan.InnerText, TxtAreaKekurangan.InnerText, TxtAreaKeahlian.InnerText, TxtAreaJobDesc.InnerText, Convert.ToInt32(TxtGaji.Text), TextareaTunjangan.InnerText, Convert.ToString(RadioButtonListSiapBekerja.SelectedIndex), Convert.ToString(RadioButtonListPenempatan.SelectedIndex), TxtAreaAlasanBergabung.InnerText, TxtAreaPengetahuanHonda.InnerText, Convert.ToString(RadioButtonListLingkunganKerja.SelectedIndex));
        }
        if (Hasil == "OK") {
            Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
        } else {
            Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan Error : "+Hasil+"');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
        }
        
    }
}