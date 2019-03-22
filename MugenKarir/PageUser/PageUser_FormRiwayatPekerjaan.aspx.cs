using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageUser_PageUser_FormRiwayatPekerjaan : System.Web.UI.Page
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
    //kumpulan fungsi insert 
    public string InsertData_Riwayat(string NamaPt, string AlamatPt, string TelpPt, string NamaAtasan, string GajiAw,
        string AlasanK, string TglMasuk, string TglKeluar, string Jab, string JobDesk, string GajiAk)
    {
        string Hasil = string.Empty;
        if (GajiAw != "" && GajiAk != "" && NamaPt !="" && AlamatPt != "" && TelpPt != "" && NamaAtasan != "" && AlasanK !=""
            && TglMasuk != "" && TglKeluar != "" && Jab != "" && JobDesk != "" )
        {
            
            int idLamaran = Convert.ToInt32(IdLamar);
            string NamaPT = NamaPt;
            string AlamatPT = AlamatPt;
            string TelpPT = TelpPt;
            string Atasan = NamaAtasan;
            int GajiAwl = Convert.ToInt32(GajiAw); //
            string Alasan = AlasanK;
            string TglM = TglMasuk;
            string TglK = TglKeluar;
            string Jabat = Jab;
            string JD = JobDesk;
            int GajiAkh = Convert.ToInt32(GajiAk); //
            KelasKoneksi kn = new KelasKoneksi();
            string SqlCmd = "insert into Data_Pekerjaan values (" + idLamaran + ", '" + NamaPT + "', '" + AlamatPT + "', '" + TelpPT + "', '" + Atasan + "', " + GajiAwl + ", '" + Alasan + "', '" + TglM + "', '" + TglK + "', '" + Jabat + "', '" + JD + "', " + GajiAkh + ")";
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
        else {
            Hasil = "Proses Gagal, Harap Cek Kembali Form Riwayat Pekerjaan Anda anda";
        }
        return Hasil;
    }
    public string InsertData_Referensi(string NamaRef, string AlamatRef, string TelpRef, string PekerjaanRef, int Hub)
    {
        string Hasil = string.Empty;
        if (Hub != 0 && NamaRef != "" && AlamatRef != "" && TelpRef != "" && PekerjaanRef != "")
        {
            KelasKoneksi kn = new KelasKoneksi();
            int idLamaran = Convert.ToInt32(IdLamar);
            string SqlCmd = "insert into Data_Referensi values (" + idLamaran + ", '" + NamaRef + "', '" + AlamatRef + "', '" + TelpRef + "', '" + PekerjaanRef + "', " + Hub + ")";
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
        else {
            Hasil = "Harap Periksa Form Data Referensi Anda";
        }
        return Hasil;
    }

    //BTn Submit Data Riwayat Pekerjaan
    public string Hasil_Final = string.Empty;
    public string Hasil_Final2 = string.Empty;
    protected void Button1_Click(object sender, EventArgs e)
    {//Response.Write("<script language='javascript'>window.alert('Data yang di Pilih : "+ Riwayat + "');window.location='../PageUser/PageUser_FormRiwayatPekerjaan.aspx';</script>");
        //CEK RadioButtonListRiwayatPekerjaan
        string Riwayat = RadioButtonListRiwayatPekerjaan.SelectedValue;
        string hasil_1 = string.Empty;
        string hasil_2 = string.Empty;
        string hasil_3 = string.Empty;
        //untuk refernsi pekerjaan
        string ref_1 = string.Empty;
        string ref_2 = string.Empty;
        string ref_3 = string.Empty;

        if (Riwayat == "1")
        {
            //if (TxtNamaPerusahaan1.Text == "" && TxtAlamatPerusahaan1.InnerText == "" && TxtTelpKantor1.Text == "" && TxtNamaAtasan1.Text == "" && TxtGajiAwal1.Text == "" && TxtAlasanKeluar1.Text == "" && TxtWaktuMasuk1.Text == "" && TxtJabatan1.Text == "" && TxtJobDesk1.Text == "" && TxtGajiAkhir1.Text == "")
            //{
            //    Response.Write("<script language='javascript'>window.alert('Periksa Kembali Data RiwayatPekerjaan Anda, Lengkapi yang Belum di Isi');</script>");
            //}
            //else
            //{
            //Control myControl1 = FindControl("TxtNamaPerusahaan1");
            if (string.IsNullOrEmpty(TxtNamaPerusahaan1.Text) && string.IsNullOrEmpty(TxtAlamatPerusahaan1.InnerText) && string.IsNullOrEmpty(TxtTelpKantor1.Text) && string.IsNullOrEmpty(TxtNamaAtasan1.Text) && string.IsNullOrEmpty(TxtGajiAwal1.Text) && string.IsNullOrEmpty(TxtAlasanKeluar1.Text) && string.IsNullOrEmpty(TxtWaktuMasuk1.Text) && string.IsNullOrEmpty(TxtWaktuKeluar1.Text) && string.IsNullOrEmpty(TxtJabatan1.Text) && string.IsNullOrEmpty(TxtJobDesk1.Text) && string.IsNullOrEmpty(TxtGajiAkhir1.Text)) 
            {
                Response.Write("<script language='javascript'>window.alert('Masih ada data yang Kosong pada Form Riwayat Pekerjaan. Proses Simpan data Riwayat Pekerjaan di Batalkan');</script>");
            }
            else
            {
                hasil_1 = InsertData_Riwayat(TxtNamaPerusahaan1.Text, TxtAlamatPerusahaan1.InnerText, TxtTelpKantor1.Text, TxtNamaAtasan1.Text, TxtGajiAwal1.Text, TxtAlasanKeluar1.Text, TxtWaktuMasuk1.Text, TxtWaktuKeluar1.Text, TxtJabatan1.Text, TxtJobDesk1.Text, TxtGajiAkhir1.Text);
                if (hasil_1 == "OK")
                {
                    //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');</script>");
                    Hasil_Final = "OK";
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Terdapat Error ! : " + hasil_1 + "');</script>");
                }
            }
            //}        
        } else if (Riwayat == "2")
        {
            if (string.IsNullOrEmpty(TxtNamaPerusahaan1.Text) && string.IsNullOrEmpty(TxtAlamatPerusahaan1.InnerText) && string.IsNullOrEmpty(TxtTelpKantor1.Text) && string.IsNullOrEmpty(TxtNamaAtasan1.Text) && string.IsNullOrEmpty(TxtGajiAwal1.Text) && string.IsNullOrEmpty(TxtAlasanKeluar1.Text) && string.IsNullOrEmpty(TxtWaktuMasuk1.Text) && string.IsNullOrEmpty(TxtWaktuKeluar1.Text) && string.IsNullOrEmpty(TxtJabatan1.Text) && string.IsNullOrEmpty(TxtJobDesk1.Text) && string.IsNullOrEmpty(TxtGajiAkhir1.Text))
            {
                Response.Write("<script language='javascript'>window.alert('Masih ada data yang Kosong pada Form Riwayat Pekerjaan. Proses Simpan data Riwayat Pekerjaan di Batalkan');</script>");
            }
            else
            {
                //simpan data
                if (string.IsNullOrEmpty(TxtNamaPerusahaan2.Text) && string.IsNullOrEmpty(TxtAlamatPerusahaan2.InnerText) && string.IsNullOrEmpty(TxtTelpKantor2.Text) && string.IsNullOrEmpty(TxtNamaAtasan2.Text) && string.IsNullOrEmpty(TxtGajiAwal2.Text) && string.IsNullOrEmpty(TxtAlasanKeluar2.Text) && string.IsNullOrEmpty(TxtWaktuMasuk2.Text) && string.IsNullOrEmpty(TxtWaktuKeluar2.Text) && string.IsNullOrEmpty(TxtJabatan2.Text) && string.IsNullOrEmpty(TxtJobDesk2.Text) && string.IsNullOrEmpty(TxtGajiAkhir2.Text))
                {
                    Response.Write("<script language='javascript'>window.alert('Masih ada data yang Kosong pada Form Riwayat Pekerjaan. Proses Simpan data Riwayat Pekerjaan di Batalkan');</script>");
                }
                else
                {
                    //simpan data
                    hasil_1 = InsertData_Riwayat(TxtNamaPerusahaan1.Text, TxtAlamatPerusahaan1.InnerText, TxtTelpKantor1.Text, TxtNamaAtasan1.Text, TxtGajiAwal1.Text, TxtAlasanKeluar1.Text, TxtWaktuMasuk1.Text, TxtWaktuKeluar1.Text, TxtJabatan1.Text, TxtJobDesk1.Text, TxtGajiAkhir1.Text);
                    if (hasil_1 == "OK")
                    {
                        //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');</script>");
                        hasil_2 = InsertData_Riwayat(TxtNamaPerusahaan2.Text, TxtAlamatPerusahaan2.InnerText, TxtTelpKantor2.Text, TxtNamaAtasan2.Text, TxtGajiAwal2.Text, TxtAlasanKeluar2.Text, TxtWaktuMasuk2.Text, TxtWaktuKeluar2.Text, TxtJabatan2.Text, TxtJobDesk2.Text, TxtGajiAkhir2.Text);
                        if (hasil_2 == "OK")
                        {
                            Hasil_Final = "OK";
                            //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');</script>");
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('Terdapat Error ! : " + hasil_2 + "');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>window.alert('Terdapat Error ! : " + hasil_1 + "');</script>");
                    }
                }
            }

        }
        else if (Riwayat == "3")
        {
            //validasi 1
            if (string.IsNullOrEmpty(TxtNamaPerusahaan1.Text) && string.IsNullOrEmpty(TxtAlamatPerusahaan1.InnerText) && string.IsNullOrEmpty(TxtTelpKantor1.Text) && string.IsNullOrEmpty(TxtNamaAtasan1.Text) && string.IsNullOrEmpty(TxtGajiAwal1.Text) && string.IsNullOrEmpty(TxtAlasanKeluar1.Text) && string.IsNullOrEmpty(TxtWaktuMasuk1.Text) && string.IsNullOrEmpty(TxtWaktuKeluar1.Text) && string.IsNullOrEmpty(TxtJabatan1.Text) && string.IsNullOrEmpty(TxtJobDesk1.Text) && string.IsNullOrEmpty(TxtGajiAkhir1.Text))
            {
                Response.Write("<script language='javascript'>window.alert('Masih ada data yang Kosong pada Form Riwayat Pekerjaan. Proses Simpan data Riwayat Pekerjaan di Batalkan');</script>");
            }
            else
            {
                //validasi 2
                if (string.IsNullOrEmpty(TxtNamaPerusahaan2.Text) && string.IsNullOrEmpty(TxtAlamatPerusahaan2.InnerText) && string.IsNullOrEmpty(TxtTelpKantor2.Text) && string.IsNullOrEmpty(TxtNamaAtasan2.Text) && string.IsNullOrEmpty(TxtGajiAwal2.Text) && string.IsNullOrEmpty(TxtAlasanKeluar2.Text) && string.IsNullOrEmpty(TxtWaktuMasuk2.Text) && string.IsNullOrEmpty(TxtWaktuKeluar2.Text) && string.IsNullOrEmpty(TxtJabatan2.Text) && string.IsNullOrEmpty(TxtJobDesk2.Text) && string.IsNullOrEmpty(TxtGajiAkhir2.Text))
                {
                    Response.Write("<script language='javascript'>window.alert('Masih ada data yang Kosong pada Form Riwayat Pekerjaan. Proses Simpan data Riwayat Pekerjaan di Batalkan');</script>");
                }
                else
                {   //validasi 3
                    if (string.IsNullOrEmpty(TxtNamaPerusahaan3.Text) && string.IsNullOrEmpty(TxtAlamatPerusahaan3.InnerText) && string.IsNullOrEmpty(TxtTelpKantor3.Text) && string.IsNullOrEmpty(TxtNamaAtasan3.Text) && string.IsNullOrEmpty(TxtGajiAwal3.Text) && string.IsNullOrEmpty(TxtAlasanKeluar3.Text) && string.IsNullOrEmpty(TxtWaktuMasuk3.Text) && string.IsNullOrEmpty(TxtWaktuKeluar3.Text) && string.IsNullOrEmpty(TxtJabatan3.Text) && string.IsNullOrEmpty(TxtJobDesk3.Text) && string.IsNullOrEmpty(TxtGajiAkhir3.Text))
                    {
                        Response.Write("<script language='javascript'>window.alert('Masih ada data yang Kosong pada Form Riwayat Pekerjaan. Proses Simpan data Riwayat Pekerjaan di Batalkan');</script>");
                    }
                    else
                    {
                        //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');</script>");
                        hasil_1 = InsertData_Riwayat(TxtNamaPerusahaan1.Text, TxtAlamatPerusahaan1.InnerText, TxtTelpKantor1.Text, TxtNamaAtasan1.Text, TxtGajiAwal1.Text, TxtAlasanKeluar1.Text, TxtWaktuMasuk1.Text, TxtWaktuKeluar1.Text, TxtJabatan1.Text, TxtJobDesk1.Text, TxtGajiAkhir1.Text);
                        if (hasil_1 == "OK")
                        {
                            hasil_2 = InsertData_Riwayat(TxtNamaPerusahaan2.Text, TxtAlamatPerusahaan2.InnerText, TxtTelpKantor2.Text, TxtNamaAtasan2.Text, TxtGajiAwal2.Text, TxtAlasanKeluar2.Text, TxtWaktuMasuk2.Text, TxtWaktuKeluar2.Text, TxtJabatan2.Text, TxtJobDesk2.Text, TxtGajiAkhir2.Text);
                            if (hasil_2 == "OK")
                            {
                                //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');</script>");
                                hasil_3 = InsertData_Riwayat(TxtNamaPerusahaan3.Text, TxtAlamatPerusahaan3.InnerText, TxtTelpKantor3.Text, TxtNamaAtasan3.Text, TxtGajiAwal3.Text, TxtAlasanKeluar3.Text, TxtWaktuMasuk3.Text, TxtWaktuKeluar3.Text, TxtJabatan3.Text, TxtJobDesk3.Text, TxtGajiAkhir3.Text);
                                if (hasil_3 == "OK")
                                {
                                    Hasil_Final = "OK";
                                    //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');</script>");
                                }
                                else
                                {
                                    Response.Write("<script language='javascript'>window.alert('Terdapat Error ! : " + hasil_3 + "');</script>");
                                }
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Terdapat Error ! : " + hasil_2 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('Terdapat Error ! : " + hasil_1 + "');</script>");
                        }
                    }
                }
            }
        }
        //Response.Write("<script language='javascript'>window.alert('Data yang di Pilih : "+ Riwayat + "');</script>");

        //CEK RadioButtonListReferensi
        string Ref = RadioButtonListReferensi.SelectedValue;
        if (Ref == "1")
        {
                ref_1 = InsertData_Referensi(TxtNamaReferensi1.Text, TxtAlamatReferensi1.Text, TxtNoTelpReferensi1.Text, DropDownListPekerjaan1.SelectedValue, DropDownListHubungan1.SelectedIndex);
                if (ref_1 == "OK") {
                    Hasil_Final2 = "OK";
                    //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');</script>");
                } else {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Dengan Error : "+ref_1+"');</script>");
                }
        } else if (Ref == "2") {
            ref_1 = InsertData_Referensi(TxtNamaReferensi1.Text, TxtAlamatReferensi1.Text, TxtNoTelpReferensi1.Text, DropDownListPekerjaan1.SelectedValue, DropDownListHubungan1.SelectedIndex);
            ref_2 = InsertData_Referensi(TxtNamaReferensi2.Text, TxtAlamatReferensi2.Text, TxtNoTelpReferensi2.Text, DropDownListPekerjaan2.SelectedValue, DropDownListHubungan2.SelectedIndex);
            if (ref_1 == "OK")
            {
                //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');</script>");
                if (ref_2 == "OK")
                {
                    Hasil_Final2 = "OK";
                    //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Dengan Error :"+ref_2+"');</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Dengan Error : " + ref_1 + "');</script>");
            }
        }
        //Response.Write("<script language='javascript'>window.alert('Data yang di Pilih : " + Ref + "');</script>");
        if (Hasil_Final == "OK" || Hasil_Final2 == "OK") {
            Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
        }
    }
}