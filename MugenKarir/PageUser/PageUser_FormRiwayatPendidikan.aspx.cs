using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageUser_PageUser_FormRiwayatPendidikan : System.Web.UI.Page
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
    //global variabel

    //kumpulan fungsi Insert
    public string InsertDataPenFormal(int par1, string par2, string par3, string par4, int par5, int par6, string par7, string par8)
    {
        string Hasil = string.Empty;
        int IdLam = par1;
        string jenjang = par2;
        string instansi = par3;
        string Kota = par4;
        int thn_m = par5;
        int thn_k = par6;
        string status = par7;
        string jurusan = par8;
        KelasKoneksi kn = new KelasKoneksi();
        string SqlCmd = "INSERT INTO Data_PenFormal VALUES ("+ IdLam + ",'"+jenjang+"', '"+instansi+"', '"+Kota+"', "+thn_m+", "+thn_k+", '"+status+"', '"+jurusan+"')";
        string Hasil_Insert = kn.KelasKoneksi_Insert(SqlCmd);
        if (Hasil_Insert == "1")
        {
            Hasil = "OK";
        }
        else
        {
            Hasil = Hasil_Insert;
        }
        return Hasil;
    }
    public string InsertDataPenNonFormal(int par1, string par2, int par3)
    {
        string Hasil = string.Empty;
        int IdLam = par1;
        string instansi = par2;
        int tahun = par3;
        KelasKoneksi kn = new KelasKoneksi();
        string SqlCmd = "INSERT INTO Data_PenNon VALUES ("+IdLam+", '"+instansi+"', "+tahun+")";
        string Hasil_Insert = kn.KelasKoneksi_Insert(SqlCmd);
        if (Hasil_Insert == "1")
        {
            Hasil = "OK";
        }
        else
        {
            Hasil = Hasil_Insert;
        }
        return Hasil;
    }
    public string InsertDataBahasa(int par1, string par2, string par3)
    {
        string Hasil = string.Empty;
        int idLamarx = par1;
        string Jenis = par2;
        string Penguasaan = par3;
        KelasKoneksi kn = new KelasKoneksi();
        string SqlCmd = "insert into Data_Bahasa values ("+ idLamarx + ", '"+Jenis+"', '"+Penguasaan+"')";
        string Hasil_Insert = kn.KelasKoneksi_Insert(SqlCmd);
        if (Hasil_Insert == "1")
        {
            Hasil = "OK";
        }
        else
        {
            Hasil = Hasil_Insert;
        }
        return Hasil;
    }
    //Fungsi Button
    protected void BtnSubmitRiwayatPendidikan_Click(object sender, EventArgs e)
    {
        //cek Pen Form
        string rBList_Formal = string.Empty;
        foreach (ListItem i in RadioButtonListPendidikanFormal.Items)
        {
            if (i.Selected == true)
            {
                rBList_Formal = i.Value;
            }
        }
        if (rBList_Formal == "SMP") {
            string Hasil = InsertDataPenFormal(Convert.ToInt32(IdLamar), TxtJenjangPendidikanSMP.Text, TxtNamaInstansiSMP.Text, TxtKotaSMP.Text, Convert.ToInt32(TxtTahunMasukSMP.Text), Convert.ToInt32(TxtTahunKeluarSMP.Text), DropDownListStatusKelulusanSMP.SelectedValue, TxtJurusanSMP.Text);
            if (Hasil == "OK")
            {
                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
        } else if (rBList_Formal == "SMA") {
            string Hasil = InsertDataPenFormal(Convert.ToInt32(IdLamar), TxtJenjangPendidikanSMP.Text, TxtNamaInstansiSMP.Text, TxtKotaSMP.Text, Convert.ToInt32(TxtTahunMasukSMP.Text), Convert.ToInt32(TxtTahunKeluarSMP.Text), DropDownListStatusKelulusanSMP.SelectedValue, TxtJurusanSMP.Text);
            if (Hasil == "OK")
            {
                string HasilSMA = InsertDataPenFormal(Convert.ToInt32(IdLamar), TxtJenjangPendidikanSMA.Text, TxtNamaInstansiSMA.Text, TxtKotaSMA.Text, Convert.ToInt32(TxtTahunMasukSMA.Text), Convert.ToInt32(TxtTahunKeluarSMA.Text), DropDownListStatusKelulusanSMA.SelectedValue, TxtJurusanSMA.Text);
                if (HasilSMA == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }

        } else if (rBList_Formal == "S1") {
            string Hasil = InsertDataPenFormal(Convert.ToInt32(IdLamar), TxtJenjangPendidikanSMP.Text, TxtNamaInstansiSMP.Text, TxtKotaSMP.Text, Convert.ToInt32(TxtTahunMasukSMP.Text), Convert.ToInt32(TxtTahunKeluarSMP.Text), DropDownListStatusKelulusanSMP.SelectedValue, TxtJurusanSMP.Text);
            if (Hasil == "OK")
            {
                string HasilSMA = InsertDataPenFormal(Convert.ToInt32(IdLamar), TxtJenjangPendidikanSMA.Text, TxtNamaInstansiSMA.Text, TxtKotaSMA.Text, Convert.ToInt32(TxtTahunMasukSMA.Text), Convert.ToInt32(TxtTahunKeluarSMA.Text), DropDownListStatusKelulusanSMA.SelectedValue, TxtJurusanSMA.Text);
                if (HasilSMA == "OK")
                {
                    string HasilS1 = InsertDataPenFormal(Convert.ToInt32(IdLamar), TxtJenjangPendidikanSarjana.Text, TxtNamaInstansiSarjana.Text, TxtKotaSarjana.Text, Convert.ToInt32(TxtTahunMasukSarjana.Text), Convert.ToInt32(TxtTahunKeluarSarjana.Text), DropDownListStatusKelulusanSarjana.SelectedValue, TxtJurusanSarjana.Text);
                    if (HasilS1 == "OK")
                    {
                        Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                    }
                    //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
        } else if (rBList_Formal == "S2") {
            string Hasil = InsertDataPenFormal(Convert.ToInt32(IdLamar), TxtJenjangPendidikanSMP.Text, TxtNamaInstansiSMP.Text, TxtKotaSMP.Text, Convert.ToInt32(TxtTahunMasukSMP.Text), Convert.ToInt32(TxtTahunKeluarSMP.Text), DropDownListStatusKelulusanSMP.SelectedValue, TxtJurusanSMP.Text);
            if (Hasil == "OK")
            {
                string HasilSMA = InsertDataPenFormal(Convert.ToInt32(IdLamar), TxtJenjangPendidikanSMA.Text, TxtNamaInstansiSMA.Text, TxtKotaSMA.Text, Convert.ToInt32(TxtTahunMasukSMA.Text), Convert.ToInt32(TxtTahunKeluarSMA.Text), DropDownListStatusKelulusanSMA.SelectedValue, TxtJurusanSMA.Text);
                if (HasilSMA == "OK")
                {
                    string HasilS1 = InsertDataPenFormal(Convert.ToInt32(IdLamar), TxtJenjangPendidikanSarjana.Text, TxtNamaInstansiSarjana.Text, TxtKotaSarjana.Text, Convert.ToInt32(TxtTahunMasukSarjana.Text), Convert.ToInt32(TxtTahunKeluarSarjana.Text), DropDownListStatusKelulusanSarjana.SelectedValue, TxtJurusanSarjana.Text);
                    if (HasilS1 == "OK")
                    {
                        string HasilS2 = InsertDataPenFormal(Convert.ToInt32(IdLamar), TxtJenjangPendidikanSarjana2.Text, TxtNamaInstansiSarjana2.Text, TxtKotaSarjana2.Text, Convert.ToInt32(TxtTahunMasukSarjana2.Text), Convert.ToInt32(TxtTahunKeluarSarjana2.Text), DropDownListStatusKelulusanSarjana2.SelectedValue, TxtJurusanSarjana2.Text);
                        if (HasilS2 == "OK")
                        {
                            Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + HasilS2 + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                        }
                        //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + HasilS1 + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                    }
                    //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + HasilSMA + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
        }
        // END OF PENDIDIKAN FORMAL
        // START OF NON FORMAL -- RadioButtonListPendidikanNon
        //cek pen non
        string rBList_NonFormal = string.Empty;
        foreach (ListItem i in RadioButtonListPendidikanNon.Items)
        {
            if (i.Selected == true)
            {
                rBList_NonFormal = i.Value;
            }
        }
        if (rBList_NonFormal == "1")
        {
            string Hasil = InsertDataPenNonFormal(Convert.ToInt32(IdLamar), TxtNamaInstansiNon1.Text, Convert.ToInt32(TxtTahunInstansiNon1.Text));
            if (Hasil == "OK")
            {
                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
        } else if (rBList_NonFormal == "2") {
            string Hasil = InsertDataPenNonFormal(Convert.ToInt32(IdLamar), TxtNamaInstansiNon1.Text, Convert.ToInt32(TxtTahunInstansiNon1.Text));
            if (Hasil == "OK")
            {
                string Hasil2 = InsertDataPenNonFormal(Convert.ToInt32(IdLamar), TxtNamaInstansiNon2.Text, Convert.ToInt32(TxtTahunInstansiNon2.Text));
                if (Hasil2 == "OK")
                {
                    //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil2 + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
        } else if ( rBList_NonFormal == "3") {
            string Hasil = InsertDataPenNonFormal(Convert.ToInt32(IdLamar), TxtNamaInstansiNon1.Text, Convert.ToInt32(TxtTahunInstansiNon1.Text));
            if (Hasil == "OK")
            {
                string Hasil2 = InsertDataPenNonFormal(Convert.ToInt32(IdLamar), TxtNamaInstansiNon2.Text, Convert.ToInt32(TxtTahunInstansiNon2.Text));
                if (Hasil2 == "OK")
                {
                    string Hasil3 = InsertDataPenNonFormal(Convert.ToInt32(IdLamar), TxtNamaInstansiNon3.Text, Convert.ToInt32(TxtTahunInstansiNon3.Text));
                    if (Hasil3 == "OK")
                    {
                        Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil3 + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                    }
                    //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil2 + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
        }
        // END OF PENDIDIKAN NO FORMAL
        // START OF Bahasa Asing --- RadioButtonListBahasa
        string rBList_Bahasa = string.Empty;
        foreach (ListItem i in RadioButtonListBahasa.Items)
        {
            if (i.Selected == true)
            {
                rBList_Bahasa = i.Value;
            }
        }
        if (rBList_Bahasa == "1")
        { //InsertDataBahasa
            string Hasil = InsertDataBahasa(Convert.ToInt32(IdLamar), TxtJenisBahasa1.Text, DropDownListPenguasaanBahasa1.SelectedValue);
            if (Hasil == "OK")
            {
                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
        } else if (rBList_Bahasa == "2") {
            string Hasil = InsertDataBahasa(Convert.ToInt32(IdLamar), TxtJenisBahasa1.Text, DropDownListPenguasaanBahasa1.SelectedValue);
            if (Hasil == "OK")
            {
                string Hasil2 = InsertDataBahasa(Convert.ToInt32(IdLamar), TxtJenisBahasa2.Text, DropDownListPenguasaanBahasa2.SelectedValue);
                if (Hasil2 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }

        } else if (rBList_Bahasa == "3") {
            string Hasil = InsertDataBahasa(Convert.ToInt32(IdLamar), TxtJenisBahasa1.Text, DropDownListPenguasaanBahasa1.SelectedValue);
            if (Hasil == "OK")
            {
                string Hasil2 = InsertDataBahasa(Convert.ToInt32(IdLamar), TxtJenisBahasa2.Text, DropDownListPenguasaanBahasa2.SelectedValue);
                if (Hasil2 == "OK")
                {
                    string Hasil3 = InsertDataBahasa(Convert.ToInt32(IdLamar), TxtJenisBahasa3.Text, DropDownListPenguasaanBahasa3.SelectedValue);
                    if (Hasil3 == "OK")
                    {
                        Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                    }
                    //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                //Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
        }
    }
}