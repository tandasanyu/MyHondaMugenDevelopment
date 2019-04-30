using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageUser_PageUser_FormPengalamanOrganisasiMemimpin : System.Web.UI.Page
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
    public int FinalOrg1;
    public int FinalOrg2;
    public int FinalLead;
    public string err1, err2, err3;
    public string InsertData_Organisasi(int idlamaran, string NamaOrg, int TahunOrg)
    {
        string Hasil = string.Empty;
        int idLamar = idlamaran;
        string Nama = NamaOrg;
        int? Tahun = TahunOrg;

        KelasKoneksi kn = new KelasKoneksi();
        if (Nama == "" || Tahun == null) {
            Hasil = "Nama / Tahun Organisasi tidak boleh Kosong";
        } else {
            string SqlCmd = "insert into Data_Organisasi values (" + idLamar + ", '" + Nama + "', " + Tahun + ")";
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
        return Hasil;
    }
    public string InsertData_Memimpin(int idlamaran, string Pengalaman)
    {
        string Hasil = string.Empty;
        int idLamar = idlamaran;
        string PengOrg = Pengalaman;
        KelasKoneksi kn = new KelasKoneksi();
        if (PengOrg == "") {
            Hasil = "Pengalaman Organisasi Wajib di Isi";
        }
        else {
            string SqlCmd = "insert into Data_Leader values (" + idLamar + ", '" + PengOrg + "')";
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
        return Hasil;
    }
    protected void BtnSubmitOrganisasiMemimpin_Click(object sender, EventArgs e)
    {
        FinalOrg1 = 0;
        FinalOrg2 = 0;
        FinalLead = 0;

        err1 = "--";
        err2 = "--";
        err3 = "--";
        //cek ada berapa pengalaman organsasi 
        string rBList_PengOrg = string.Empty;
        foreach (ListItem i in RadioButtonListOrganisasi.Items)
        {
            if (i.Selected == true)
            {
                rBList_PengOrg = i.Value;
            }
        }
        if (rBList_PengOrg == "1")
        {
            if (TxtNamaOrganisasi1.Text.Length !=0 || TxtTahunOrganisasi1.Text.Length != 0) {
                err1 = "Nama Organisasi / Tahun Organisasi Wajib di Isi";
            } else {
                string Hasil = InsertData_Organisasi(Convert.ToInt32(IdLamar), TxtNamaOrganisasi1.Text, Convert.ToInt32(TxtTahunOrganisasi1.Text));
                if (Hasil == "OK")
                {
                    FinalOrg1 = 1;
                    //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    err1 = "Terdapat Error Ketika Menambahkan Data Organisasi 1 dengan Pesan : '" + Hasil + "'";
                    //Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
        }
        else if (rBList_PengOrg == "2")
        {
            if (TxtNamaOrganisasi1.Text.Length != 0 || TxtTahunOrganisasi1.Text.Length != 0)
            {
                err1 = "Nama Organisasi / Tahun Organisasi Wajib di Isi";
            }
            else {
                string Hasil = InsertData_Organisasi(Convert.ToInt32(IdLamar), TxtNamaOrganisasi1.Text, Convert.ToInt32(TxtTahunOrganisasi1.Text));
                if (Hasil == "OK")
                {
                    if (TxtNamaOrganisasi2.Text.Length != 0 || TxtTahunOrganisasi2.Text.Length != 0) {
                        err2 = "Nama Organisasi ke-2/ Tahun Organisasi ke-2 Wajib di Isi";
                    } else {
                        string Hasil2 = InsertData_Organisasi(Convert.ToInt32(IdLamar), TxtNamaOrganisasi2.Text, Convert.ToInt32(TxtTahunOrganisasi2.Text));
                        if (Hasil2 == "OK")
                        {
                            FinalOrg2 = 1;
                            //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                        }
                        else
                        {
                            err2 = "Terdapat Error Ketika Menambahkan Data Organisasi 2 dengan Pesan : '" + Hasil2 + "'";
                            //Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil2 + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                        }
                    }
                    //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    err1 = "Terdapat Error Ketika Menambahkan Data Organisasi 1 dengan Pesan : '" + Hasil + "'";
                    //Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
        }
        //cek ada pengalaman memimpin tidak 
        string rBList_Leader = string.Empty;
        foreach (ListItem i in RadioButtonListMemimpin.Items)
        {
            if (i.Selected == true)
            {
                rBList_Leader = i.Value;
            }
        }
        if (rBList_Leader == "Ada")
        {
            if (TxtMemimpin1.Text == "") {
                err3 = "Data Memimpin Wajib di Isi";
            } else {
                string HasilL = InsertData_Memimpin(Convert.ToInt32(IdLamar), TxtMemimpin1.Text);
                if (HasilL == "OK")
                {
                    FinalLead = 1;
                    //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    err3 = "Terapat Error ketika Menyimpan data Pengalaman Memimpin, dengan Pesan Error : '" + HasilL + "'";
                    //Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + HasilL + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
        }
        if (FinalLead == 1 || FinalOrg1 == 1 || FinalOrg2 == 1)
        {
            Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
        }
        else {
            Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : "+err1+" dan "+err2+" dan "+err3+"');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
        }
    }
}