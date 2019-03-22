using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageUser_PaguUser_FormDataKeluarga : System.Web.UI.Page
{
    public string IdLamar;
    public string hasil;
    protected void Page_Load(object sender, EventArgs e)
    {
        //cek sesi
        if (Session["User"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        //get url param       
        IdLamar = Request.QueryString["IdLamaran"];
        //Response.Write("<script language=javascript>alert('Value : "+IdLamar+"');</script>");
    }
    //method untuk insert
    public string InsertDataKeluarga(string sql)
    {
        string Hasil = string.Empty;
        //proses insert ke table Data_Keluarga*********** di buat method 
        KelasKoneksi kn = new KelasKoneksi();
        string SqlCmd = sql;
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
    public string InsertDataAnak(string sql)
    {        
        string Hasil = string.Empty;
        //string idLamaran = par1;
        //string Nm = par2;
        //string JenKel = par3;
        //string usia = par4;
        //string pen = par5;
        //string pek = par6;

        //proses insert ke table Data_Keluarga*********** di buat method 
        KelasKoneksi kn = new KelasKoneksi();
        string SqlCmd = sql;
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
    public string InsertDataSaudara(string par1, string par2, string par3, string par4, string par5, string par6)
    {
        string Hasil = string.Empty;
        string IdLamaran = par1;
        string NmSaudara = par2;
        string JenKelSaudara = par3;
        string UsiaSaudara = par4;
        string pen_s = par5;
        string pek_s = par6;      
        //proses insert ke table Data_Keluarga*********** di buat method 
        KelasKoneksi kn = new KelasKoneksi();
        string SqlCmd =  "insert into Data_Saudara values (" + Convert.ToInt32(IdLamaran) + ", '" + NmSaudara + "', " + Convert.ToInt32(JenKelSaudara) + ", " + Convert.ToInt32(UsiaSaudara) + ", " + Convert.ToInt32(pen_s) + ", " + Convert.ToInt32(pek_s) + ")";
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
    public string InsertDataPasangan(string sql)
    {
        string Hasil = string.Empty;
        //proses insert ke table Data_Keluarga*********** di buat method 
        KelasKoneksi kn = new KelasKoneksi();
        string SqlCmd = sql;
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
    protected void BtnSubmitFormDataKeluarga_Click(object sender, EventArgs e)
    {
        //**KONDISI TIDAK PUNYA SAUDARA KANDUNG======================================================================================
        //***KONDISI KETIKA TIDAK PUNYA SAUDARA KANDUNG & BELUM MENIKAH
        if (RadioButtonListPunyaAnak.SelectedValue == "Tidak" && RadioButtonListStatusPerkawinan.SelectedValue == "Belum Menikah")
        {
            //Insert data Keluarga
            string SqlCmd = "insert into Data_Keluarga values (" + Convert.ToInt32(IdLamar) + ",'" + TxtNamaAyah.Text + "', '" + TxtNamaIbu.Text + "', " + Convert.ToInt32(DropDownListPendidikanAyah.SelectedIndex) + ", " + Convert.ToInt32(TxtUsiaAyah.Text) + ", " + Convert.ToInt32(DropDownListPekerjaanAyah.SelectedIndex) + ", " + Convert.ToInt32(DropDownListPendidikanIbu.SelectedIndex) + "," + Convert.ToInt32(TxtUsiaIbu.Text) + ", " + Convert.ToInt32(DropDownListPekerjaanIbu.SelectedIndex) + ")";
            string Hasil = InsertDataKeluarga(SqlCmd);
            if (Hasil == "OK")
            {
                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
        }
        //***KONDISI KETIKA TIDAK PUNYA SAUDARA KANDUNG & SUDAH MENIKAH
        else if (RadioButtonListPunyaAnak.SelectedValue == "Tidak" && RadioButtonListStatusPerkawinan.SelectedValue == "Menikah") {
            //Insert data Keluarga -- YA
            string SqlCmd = "insert into Data_Keluarga values (" + Convert.ToInt32(IdLamar) + ",'" + TxtNamaAyah.Text + "', '" + TxtNamaIbu.Text + "', " + Convert.ToInt32(DropDownListPendidikanAyah.SelectedIndex) + ", " + Convert.ToInt32(TxtUsiaAyah.Text) + ", " + Convert.ToInt32(DropDownListPekerjaanAyah.SelectedIndex) + ", " + Convert.ToInt32(DropDownListPendidikanIbu.SelectedIndex) + "," + Convert.ToInt32(TxtUsiaIbu.Text) + ", " + Convert.ToInt32(DropDownListPekerjaanIbu.SelectedIndex) + ")";
            string Hasil = InsertDataKeluarga(SqlCmd);
            if (Hasil == "OK")
            {
                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            //insert data saudara kandung -- TIDAK
            //INSERT DATA PASANGAN -- YA
            //**Cek value Pendidikan dan Pekerjaan Pasangan
            int pen_p = Convert.ToInt32(DropDownListPendidikanSuamiIstri.SelectedValue);
            int pek_p = Convert.ToInt32(DropDownListPekerjaanSuamiIstri.SelectedValue);
            if (pen_p != 0 && pek_p != 0)
            {
                string SqlCmdPasangan = "insert into Data_Pasangan values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaSuamiIstri.Text + "', " + Convert.ToInt32(TxtUsiaSuamiIstri.Text) + ", " + pen_p + ", " + pek_p + ")";
                string HasilPasangan = InsertDataPasangan(SqlCmdPasangan);
                if (HasilPasangan == "OK")
                {
                    //cek apakah memiliki anak
                    if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "1")
                    {//***KONDISI MEMILIKI ANAK1
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA = Convert.ToInt32(DropDownListJenisKelaminAnak1.SelectedValue);
                        int pen_a = Convert.ToInt32(DropDownListPendidikanAnak1.SelectedValue);
                        int pek_a = Convert.ToInt32(DropDownListPekerjaanAnak1.SelectedValue);
                        int usia_a = Convert.ToInt32(TxtUsiaAnak1.Text);
                        if (jenkelA != 0 && pen_a != 0 && pek_a != 0) {
                            string SqlCmdAnak1 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak1.Text + "', "+jenkelA+", "+usia_a+", "+pen_a+", "+pek_a+")";
                            string HasilAnak1 = InsertDataAnak(SqlCmdAnak1);
                            if (HasilAnak1 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 1');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 1, dengan Error : "+HasilAnak1+"');</script>");
                            }
                        } else {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 1 Wajib Di Isi');</script>");
                        }
                    }
                    else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "2")
                    {
                        //***KONDISI MEMILIKI ANAK1
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA = Convert.ToInt32(DropDownListJenisKelaminAnak1.SelectedValue);
                        int pen_a = Convert.ToInt32(DropDownListPendidikanAnak1.SelectedValue);
                        int pek_a = Convert.ToInt32(DropDownListPekerjaanAnak1.SelectedValue);
                        int usia_a = Convert.ToInt32(TxtUsiaAnak1.Text);
                        if (jenkelA != 0 && pen_a != 0 && pek_a != 0)
                        {
                            string SqlCmdAnak1 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak1.Text + "', " + jenkelA + ", " + usia_a + ", " + pen_a + ", " + pek_a + ")";
                            string HasilAnak1 = InsertDataAnak(SqlCmdAnak1);
                            if (HasilAnak1 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 1');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 1, dengan Error : " + HasilAnak1 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 1 Wajib Di Isi');</script>");
                        }
                        //***KONDISI MEMILIKI ANAK2
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA2 = Convert.ToInt32(DropDownListJenisKelaminAnak2.SelectedValue);
                        int pen_a2 = Convert.ToInt32(DropDownListPendidikanAnak2.SelectedValue);
                        int pek_a2 = Convert.ToInt32(DropDownListPekerjaanAnak2.SelectedValue);
                        int usia_a2 = Convert.ToInt32(TxtUsiaAnak2.Text);
                        if (jenkelA2 != 0 && pen_a2 != 0 && pek_a2 != 0)
                        {
                            string SqlCmdAnak2 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak2.Text + "', " + jenkelA2 + ", " + usia_a2 + ", " + pen_a2 + ", " + pek_a2 + ")";
                            string HasilAnak2 = InsertDataAnak(SqlCmdAnak2);
                            if (HasilAnak2 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 2');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 2, dengan Error : " + HasilAnak2 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 2 Wajib Di Isi');</script>");
                        }
                    }
                    else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "3")
                    {
                        //***KONDISI MEMILIKI ANAK1
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA = Convert.ToInt32(DropDownListJenisKelaminAnak1.SelectedValue);
                        int pen_a = Convert.ToInt32(DropDownListPendidikanAnak1.SelectedValue);
                        int pek_a = Convert.ToInt32(DropDownListPekerjaanAnak1.SelectedValue);
                        int usia_a = Convert.ToInt32(TxtUsiaAnak1.Text);
                        if (jenkelA != 0 && pen_a != 0 && pek_a != 0)
                        {
                            string SqlCmdAnak1 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak1.Text + "', " + jenkelA + ", " + usia_a + ", " + pen_a + ", " + pek_a + ")";
                            string HasilAnak1 = InsertDataAnak(SqlCmdAnak1);
                            if (HasilAnak1 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 1');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 1, dengan Error : " + HasilAnak1 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 1 Wajib Di Isi');</script>");
                        }
                        //***KONDISI MEMILIKI ANAK2
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA2 = Convert.ToInt32(DropDownListJenisKelaminAnak2.SelectedValue);
                        int pen_a2 = Convert.ToInt32(DropDownListPendidikanAnak2.SelectedValue);
                        int pek_a2 = Convert.ToInt32(DropDownListPekerjaanAnak2.SelectedValue);
                        int usia_a2 = Convert.ToInt32(TxtUsiaAnak2.Text);
                        if (jenkelA2 != 0 && pen_a2 != 0 && pek_a2 != 0)
                        {
                            string SqlCmdAnak2 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak2.Text + "', " + jenkelA2 + ", " + usia_a2 + ", " + pen_a2 + ", " + pek_a2 + ")";
                            string HasilAnak2 = InsertDataAnak(SqlCmdAnak2);
                            if (HasilAnak2 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 2');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 2, dengan Error : " + HasilAnak2 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 2 Wajib Di Isi');</script>");
                        }
                        //***KONDISI MEMILIKI ANAK3
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA3 = Convert.ToInt32(DropDownListJenisKelaminAnak3.SelectedValue);
                        int pen_a3 = Convert.ToInt32(DropDownListPendidikanAnak3.SelectedValue);
                        int pek_a3 = Convert.ToInt32(DropDownListPekerjaanAnak3.SelectedValue);
                        int usia_a3 = Convert.ToInt32(TxtUsiaAnak3.Text);
                        if (jenkelA3 != 0 && pen_a3 != 0 && pek_a3 != 0)
                        {
                            string SqlCmdAnak3 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak3.Text + "', " + jenkelA3 + ", " + usia_a3 + ", " + pen_a3 + ", " + pek_a3 + ")";
                            string HasilAnak3 = InsertDataAnak(SqlCmdAnak3);
                            if (HasilAnak3 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 2');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 2, dengan Error : " + HasilAnak3 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 2 Wajib Di Isi');</script>");
                        }
                    }
                    else
                    {//***KONDISI TIDAK MEMILIKI ANAK

                    }
                    //end of menyimpan data anak
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }//end of menyimpan data pasangan
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Pasangan dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else {
                Response.Write("<script language='javascript'>window.alert('Pendidikan dan Pekerjaan Pasangan Wajib di Pilih');</script>");
            }
        }
        //***KONDISI KETIKA TIDAK PUNYA SAUDARA KANDUNG & DUDA / JANDA
        else if (RadioButtonListPunyaAnak.SelectedValue == "Tidak" && RadioButtonListStatusPerkawinan.SelectedValue == "Duda/Janda")
        {
            //Insert data Keluarga -- YA
            string SqlCmd = "insert into Data_Keluarga values (" + Convert.ToInt32(IdLamar) + ",'" + TxtNamaAyah.Text + "', '" + TxtNamaIbu.Text + "', " + Convert.ToInt32(DropDownListPendidikanAyah.SelectedIndex) + ", " + Convert.ToInt32(TxtUsiaAyah.Text) + ", " + Convert.ToInt32(DropDownListPekerjaanAyah.SelectedIndex) + ", " + Convert.ToInt32(DropDownListPendidikanIbu.SelectedIndex) + "," + Convert.ToInt32(TxtUsiaIbu.Text) + ", " + Convert.ToInt32(DropDownListPekerjaanIbu.SelectedIndex) + ")";
            string Hasil = InsertDataKeluarga(SqlCmd);
            if (Hasil == "OK")
            {
                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            //insert data saudara kandung -- TIDAK
            //INSERT DATA PASANGAN -- YA
            //**Cek value Pendidikan dan Pekerjaan Pasangan
            int pen_p = Convert.ToInt32(DropDownListPendidikanSuamiIstri.SelectedValue);
            int pek_p = Convert.ToInt32(DropDownListPekerjaanSuamiIstri.SelectedValue);
            if (pen_p != 0 && pek_p != 0)
            {
                string SqlCmdPasangan = "insert into Data_Pasangan values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaSuamiIstri.Text + "', " + Convert.ToInt32(TxtUsiaSuamiIstri.Text) + ", " + pen_p + ", " + pek_p + ")";
                string HasilPasangan = InsertDataPasangan(SqlCmdPasangan);
                if (HasilPasangan == "OK")
                {
                    //cek apakah memiliki anak
                    if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "1")
                    {//***KONDISI MEMILIKI ANAK1
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA = Convert.ToInt32(DropDownListJenisKelaminAnak1.SelectedValue);
                        int pen_a = Convert.ToInt32(DropDownListPendidikanAnak1.SelectedValue);
                        int pek_a = Convert.ToInt32(DropDownListPekerjaanAnak1.SelectedValue);
                        int usia_a = Convert.ToInt32(TxtUsiaAnak1.Text);
                        if (jenkelA != 0 && pen_a != 0 && pek_a != 0)
                        {
                            string SqlCmdAnak1 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak1.Text + "', " + jenkelA + ", " + usia_a + ", " + pen_a + ", " + pek_a + ")";
                            string HasilAnak1 = InsertDataAnak(SqlCmdAnak1);
                            if (HasilAnak1 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 1');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 1, dengan Error : " + HasilAnak1 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 1 Wajib Di Isi');</script>");
                        }
                    }
                    else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "2")
                    {
                        //***KONDISI MEMILIKI ANAK1
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA = Convert.ToInt32(DropDownListJenisKelaminAnak1.SelectedValue);
                        int pen_a = Convert.ToInt32(DropDownListPendidikanAnak1.SelectedValue);
                        int pek_a = Convert.ToInt32(DropDownListPekerjaanAnak1.SelectedValue);
                        int usia_a = Convert.ToInt32(TxtUsiaAnak1.Text);
                        if (jenkelA != 0 && pen_a != 0 && pek_a != 0)
                        {
                            string SqlCmdAnak1 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak1.Text + "', " + jenkelA + ", " + usia_a + ", " + pen_a + ", " + pek_a + ")";
                            string HasilAnak1 = InsertDataAnak(SqlCmdAnak1);
                            if (HasilAnak1 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 1');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 1, dengan Error : " + HasilAnak1 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 1 Wajib Di Isi');</script>");
                        }
                        //***KONDISI MEMILIKI ANAK2
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA2 = Convert.ToInt32(DropDownListJenisKelaminAnak2.SelectedValue);
                        int pen_a2 = Convert.ToInt32(DropDownListPendidikanAnak2.SelectedValue);
                        int pek_a2 = Convert.ToInt32(DropDownListPekerjaanAnak2.SelectedValue);
                        int usia_a2 = Convert.ToInt32(TxtUsiaAnak2.Text);
                        if (jenkelA2 != 0 && pen_a2 != 0 && pek_a2 != 0)
                        {
                            string SqlCmdAnak2 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak2.Text + "', " + jenkelA2 + ", " + usia_a2 + ", " + pen_a2 + ", " + pek_a2 + ")";
                            string HasilAnak2 = InsertDataAnak(SqlCmdAnak2);
                            if (HasilAnak2 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 2');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 2, dengan Error : " + HasilAnak2 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 2 Wajib Di Isi');</script>");
                        }
                    }
                    else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "3")
                    {
                        //***KONDISI MEMILIKI ANAK1
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA = Convert.ToInt32(DropDownListJenisKelaminAnak1.SelectedValue);
                        int pen_a = Convert.ToInt32(DropDownListPendidikanAnak1.SelectedValue);
                        int pek_a = Convert.ToInt32(DropDownListPekerjaanAnak1.SelectedValue);
                        int usia_a = Convert.ToInt32(TxtUsiaAnak1.Text);
                        if (jenkelA != 0 && pen_a != 0 && pek_a != 0)
                        {
                            string SqlCmdAnak1 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak1.Text + "', " + jenkelA + ", " + usia_a + ", " + pen_a + ", " + pek_a + ")";
                            string HasilAnak1 = InsertDataAnak(SqlCmdAnak1);
                            if (HasilAnak1 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 1');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 1, dengan Error : " + HasilAnak1 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 1 Wajib Di Isi');</script>");
                        }
                        //***KONDISI MEMILIKI ANAK2
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA2 = Convert.ToInt32(DropDownListJenisKelaminAnak2.SelectedValue);
                        int pen_a2 = Convert.ToInt32(DropDownListPendidikanAnak2.SelectedValue);
                        int pek_a2 = Convert.ToInt32(DropDownListPekerjaanAnak2.SelectedValue);
                        int usia_a2 = Convert.ToInt32(TxtUsiaAnak2.Text);
                        if (jenkelA2 != 0 && pen_a2 != 0 && pek_a2 != 0)
                        {
                            string SqlCmdAnak2 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak2.Text + "', " + jenkelA2 + ", " + usia_a2 + ", " + pen_a2 + ", " + pek_a2 + ")";
                            string HasilAnak2 = InsertDataAnak(SqlCmdAnak2);
                            if (HasilAnak2 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 2');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 2, dengan Error : " + HasilAnak2 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 2 Wajib Di Isi');</script>");
                        }
                        //***KONDISI MEMILIKI ANAK3
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA3 = Convert.ToInt32(DropDownListJenisKelaminAnak3.SelectedValue);
                        int pen_a3 = Convert.ToInt32(DropDownListPendidikanAnak3.SelectedValue);
                        int pek_a3 = Convert.ToInt32(DropDownListPekerjaanAnak3.SelectedValue);
                        int usia_a3 = Convert.ToInt32(TxtUsiaAnak3.Text);
                        if (jenkelA3 != 0 && pen_a3 != 0 && pek_a3 != 0)
                        {
                            string SqlCmdAnak3 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak3.Text + "', " + jenkelA3 + ", " + usia_a3 + ", " + pen_a3 + ", " + pek_a3 + ")";
                            string HasilAnak3 = InsertDataAnak(SqlCmdAnak3);
                            if (HasilAnak3 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 2');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 2, dengan Error : " + HasilAnak3 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 2 Wajib Di Isi');</script>");
                        }
                    }
                    //else
                    //{//***KONDISI TIDAK MEMILIKI ANAK

                    //}
                    //end of menyimpan data anak
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }//end of menyimpan data pasangan
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Pasangan dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Pendidikan dan Pekerjaan Pasangan Wajib di Pilih');</script>");
            }
            //if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "1")
            //{//***KONDISI MEMILIKI ANAK1

            //}
            //else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "2")
            //{//***KONDISI MEMILIKI ANAK2

            //}
            //else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "3")
            //{//***KONDISI MEMILIKI ANAK3

            //}
            //else
            //{//***KONDISI TIDAK MEMILIKI ANAK

            //}
        }
        //***KETIKA PUNYA SAUDARA KANDUNG===========================================================================================
        else         //***KONDISI KETIKA  PUNYA SAUDARA KANDUNG & BELUM MENIKAH
        if (RadioButtonListPunyaAnak.SelectedValue == "Ya" && RadioButtonListStatusPerkawinan.SelectedValue == "Belum Menikah")
        {
            //Insert data Keluarga -- YA
            string SqlCmd = "insert into Data_Keluarga values (" + Convert.ToInt32(IdLamar) + ",'" + TxtNamaAyah.Text + "', '" + TxtNamaIbu.Text + "', " + Convert.ToInt32(DropDownListPendidikanAyah.SelectedIndex) + ", " + Convert.ToInt32(TxtUsiaAyah.Text) + ", " + Convert.ToInt32(DropDownListPekerjaanAyah.SelectedIndex) + ", " + Convert.ToInt32(DropDownListPendidikanIbu.SelectedIndex) + "," + Convert.ToInt32(TxtUsiaIbu.Text) + ", " + Convert.ToInt32(DropDownListPekerjaanIbu.SelectedIndex) + ")";
            string Hasil = InsertDataKeluarga(SqlCmd);
            if (Hasil == "OK")
            {
                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            //insert data saudara kandung -- YA
            string SqlCmd_Kandung = string.Empty;
            if (RadioButtonListJmlAnak.SelectedIndex==0) {//UNTUK 1 SK
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                if (HasilSK1 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 1) // UNTUK 2 SK
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 2)//UNTUK 3 SK
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 3)//UNTUK 4 SK
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 4)//UNTUK 5 SK
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                string HasilSK5 = InsertDataSaudara(IdLamar, TxtNamaSK5.Text, Convert.ToString(DropDownListJenisKelaminSK5.SelectedValue), TxtUsiaSK5.Text, Convert.ToString(DropDownListPendidikanSK5.SelectedValue), Convert.ToString(DropDownListPekerjaanSK5.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK" && HasilSK5 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 5) //UNTUK 6 SK
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                string HasilSK5 = InsertDataSaudara(IdLamar, TxtNamaSK5.Text, Convert.ToString(DropDownListJenisKelaminSK5.SelectedValue), TxtUsiaSK5.Text, Convert.ToString(DropDownListPendidikanSK5.SelectedValue), Convert.ToString(DropDownListPekerjaanSK5.SelectedValue));
                string HasilSK6 = InsertDataSaudara(IdLamar, TxtNamaSK6.Text, Convert.ToString(DropDownListJenisKelaminSK6.SelectedValue), TxtUsiaSK6.Text, Convert.ToString(DropDownListPendidikanSK6.SelectedValue), Convert.ToString(DropDownListPekerjaanSK6.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK" && HasilSK5 == "OK" && HasilSK6 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 6) //UNTUK 7 SK
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                string HasilSK5 = InsertDataSaudara(IdLamar, TxtNamaSK5.Text, Convert.ToString(DropDownListJenisKelaminSK5.SelectedValue), TxtUsiaSK5.Text, Convert.ToString(DropDownListPendidikanSK5.SelectedValue), Convert.ToString(DropDownListPekerjaanSK5.SelectedValue));
                string HasilSK6 = InsertDataSaudara(IdLamar, TxtNamaSK6.Text, Convert.ToString(DropDownListJenisKelaminSK6.SelectedValue), TxtUsiaSK6.Text, Convert.ToString(DropDownListPendidikanSK6.SelectedValue), Convert.ToString(DropDownListPekerjaanSK6.SelectedValue));
                string HasilSK7 = InsertDataSaudara(IdLamar, TxtNamaSK7.Text, Convert.ToString(DropDownListJenisKelaminSK7.SelectedValue), TxtUsiaSK7.Text, Convert.ToString(DropDownListPendidikanSK7.SelectedValue), Convert.ToString(DropDownListPekerjaanSK7.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK" && HasilSK5 == "OK" && HasilSK6 == "OK" && HasilSK7 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 7)//UNTUK 8 SK
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                string HasilSK5 = InsertDataSaudara(IdLamar, TxtNamaSK5.Text, Convert.ToString(DropDownListJenisKelaminSK5.SelectedValue), TxtUsiaSK5.Text, Convert.ToString(DropDownListPendidikanSK5.SelectedValue), Convert.ToString(DropDownListPekerjaanSK5.SelectedValue));
                string HasilSK6 = InsertDataSaudara(IdLamar, TxtNamaSK6.Text, Convert.ToString(DropDownListJenisKelaminSK6.SelectedValue), TxtUsiaSK6.Text, Convert.ToString(DropDownListPendidikanSK6.SelectedValue), Convert.ToString(DropDownListPekerjaanSK6.SelectedValue));
                string HasilSK7 = InsertDataSaudara(IdLamar, TxtNamaSK7.Text, Convert.ToString(DropDownListJenisKelaminSK7.SelectedValue), TxtUsiaSK7.Text, Convert.ToString(DropDownListPendidikanSK7.SelectedValue), Convert.ToString(DropDownListPekerjaanSK7.SelectedValue));
                string HasilSK8 = InsertDataSaudara(IdLamar, TxtNamaSK8.Text, Convert.ToString(DropDownListJenisKelaminSK8.SelectedValue), TxtUsiaSK8.Text, Convert.ToString(DropDownListPendidikanSK8.SelectedValue), Convert.ToString(DropDownListPekerjaanSK8.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK" && HasilSK5 == "OK" && HasilSK6 == "OK" && HasilSK7 == "OK" && HasilSK8 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
        }
        //***KONDISI KETIKA  PUNYA SAUDARA KANDUNG & SUDAH MENIKAH
        else if (RadioButtonListPunyaAnak.SelectedValue == "Ya" && RadioButtonListStatusPerkawinan.SelectedValue == "Menikah")
        {
            //Insert data Keluarga -- YA
            string SqlCmd = "insert into Data_Keluarga values (" + Convert.ToInt32(IdLamar) + ",'" + TxtNamaAyah.Text + "', '" + TxtNamaIbu.Text + "', " + Convert.ToInt32(DropDownListPendidikanAyah.SelectedIndex) + ", " + Convert.ToInt32(TxtUsiaAyah.Text) + ", " + Convert.ToInt32(DropDownListPekerjaanAyah.SelectedIndex) + ", " + Convert.ToInt32(DropDownListPendidikanIbu.SelectedIndex) + "," + Convert.ToInt32(TxtUsiaIbu.Text) + ", " + Convert.ToInt32(DropDownListPekerjaanIbu.SelectedIndex) + ")";
            string Hasil = InsertDataKeluarga(SqlCmd);
            if (Hasil == "OK")
            {
                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            //insert data saudara kandung -- YA
            string SqlCmd_Kandung = string.Empty;
            if (RadioButtonListJmlAnak.SelectedIndex == 0)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                if (HasilSK1 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 1)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 2)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 3)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 4)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                string HasilSK5 = InsertDataSaudara(IdLamar, TxtNamaSK5.Text, Convert.ToString(DropDownListJenisKelaminSK5.SelectedValue), TxtUsiaSK5.Text, Convert.ToString(DropDownListPendidikanSK5.SelectedValue), Convert.ToString(DropDownListPekerjaanSK5.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK" && HasilSK5 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 5)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                string HasilSK5 = InsertDataSaudara(IdLamar, TxtNamaSK5.Text, Convert.ToString(DropDownListJenisKelaminSK5.SelectedValue), TxtUsiaSK5.Text, Convert.ToString(DropDownListPendidikanSK5.SelectedValue), Convert.ToString(DropDownListPekerjaanSK5.SelectedValue));
                string HasilSK6 = InsertDataSaudara(IdLamar, TxtNamaSK6.Text, Convert.ToString(DropDownListJenisKelaminSK6.SelectedValue), TxtUsiaSK6.Text, Convert.ToString(DropDownListPendidikanSK6.SelectedValue), Convert.ToString(DropDownListPekerjaanSK6.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK" && HasilSK5 == "OK" && HasilSK6 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 6)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                string HasilSK5 = InsertDataSaudara(IdLamar, TxtNamaSK5.Text, Convert.ToString(DropDownListJenisKelaminSK5.SelectedValue), TxtUsiaSK5.Text, Convert.ToString(DropDownListPendidikanSK5.SelectedValue), Convert.ToString(DropDownListPekerjaanSK5.SelectedValue));
                string HasilSK6 = InsertDataSaudara(IdLamar, TxtNamaSK6.Text, Convert.ToString(DropDownListJenisKelaminSK6.SelectedValue), TxtUsiaSK6.Text, Convert.ToString(DropDownListPendidikanSK6.SelectedValue), Convert.ToString(DropDownListPekerjaanSK6.SelectedValue));
                string HasilSK7 = InsertDataSaudara(IdLamar, TxtNamaSK7.Text, Convert.ToString(DropDownListJenisKelaminSK7.SelectedValue), TxtUsiaSK7.Text, Convert.ToString(DropDownListPendidikanSK7.SelectedValue), Convert.ToString(DropDownListPekerjaanSK7.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK" && HasilSK5 == "OK" && HasilSK6 == "OK" && HasilSK7 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 7)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                string HasilSK5 = InsertDataSaudara(IdLamar, TxtNamaSK5.Text, Convert.ToString(DropDownListJenisKelaminSK5.SelectedValue), TxtUsiaSK5.Text, Convert.ToString(DropDownListPendidikanSK5.SelectedValue), Convert.ToString(DropDownListPekerjaanSK5.SelectedValue));
                string HasilSK6 = InsertDataSaudara(IdLamar, TxtNamaSK6.Text, Convert.ToString(DropDownListJenisKelaminSK6.SelectedValue), TxtUsiaSK6.Text, Convert.ToString(DropDownListPendidikanSK6.SelectedValue), Convert.ToString(DropDownListPekerjaanSK6.SelectedValue));
                string HasilSK7 = InsertDataSaudara(IdLamar, TxtNamaSK7.Text, Convert.ToString(DropDownListJenisKelaminSK7.SelectedValue), TxtUsiaSK7.Text, Convert.ToString(DropDownListPendidikanSK7.SelectedValue), Convert.ToString(DropDownListPekerjaanSK7.SelectedValue));
                string HasilSK8 = InsertDataSaudara(IdLamar, TxtNamaSK8.Text, Convert.ToString(DropDownListJenisKelaminSK8.SelectedValue), TxtUsiaSK8.Text, Convert.ToString(DropDownListPendidikanSK8.SelectedValue), Convert.ToString(DropDownListPekerjaanSK8.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK" && HasilSK5 == "OK" && HasilSK6 == "OK" && HasilSK7 == "OK" && HasilSK8 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            //INSERT DATA PASANGAN -- YA
            //**Cek value Pendidikan dan Pekerjaan Pasangan
            int pen_p = Convert.ToInt32(DropDownListPendidikanSuamiIstri.SelectedValue);
            int pek_p = Convert.ToInt32(DropDownListPekerjaanSuamiIstri.SelectedValue);
            if (pen_p != 0 && pek_p != 0)
            {
                string SqlCmdPasangan = "insert into Data_Pasangan values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaSuamiIstri.Text + "', " + Convert.ToInt32(TxtUsiaSuamiIstri.Text) + ", " + pen_p + ", " + pek_p + ")";
                string HasilPasangan = InsertDataPasangan(SqlCmdPasangan);
                if (HasilPasangan == "OK")
                {
                    //cek apakah memiliki anak
                    if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "1")
                    {//***KONDISI MEMILIKI ANAK1
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA = Convert.ToInt32(DropDownListJenisKelaminAnak1.SelectedValue);
                        int pen_a = Convert.ToInt32(DropDownListPendidikanAnak1.SelectedValue);
                        int pek_a = Convert.ToInt32(DropDownListPekerjaanAnak1.SelectedValue);
                        int usia_a = Convert.ToInt32(TxtUsiaAnak1.Text);
                        if (jenkelA != 0 && pen_a != 0 && pek_a != 0)
                        {
                            string SqlCmdAnak1 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak1.Text + "', " + jenkelA + ", " + usia_a + ", " + pen_a + ", " + pek_a + ")";
                            string HasilAnak1 = InsertDataAnak(SqlCmdAnak1);
                            if (HasilAnak1 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 1');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 1, dengan Error : " + HasilAnak1 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 1 Wajib Di Isi');</script>");
                        }
                    }
                    else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "2")
                    {
                        //***KONDISI MEMILIKI ANAK1
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA = Convert.ToInt32(DropDownListJenisKelaminAnak1.SelectedValue);
                        int pen_a = Convert.ToInt32(DropDownListPendidikanAnak1.SelectedValue);
                        int pek_a = Convert.ToInt32(DropDownListPekerjaanAnak1.SelectedValue);
                        int usia_a = Convert.ToInt32(TxtUsiaAnak1.Text);
                        if (jenkelA != 0 && pen_a != 0 && pek_a != 0)
                        {
                            string SqlCmdAnak1 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak1.Text + "', " + jenkelA + ", " + usia_a + ", " + pen_a + ", " + pek_a + ")";
                            string HasilAnak1 = InsertDataAnak(SqlCmdAnak1);
                            if (HasilAnak1 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 1');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 1, dengan Error : " + HasilAnak1 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 1 Wajib Di Isi');</script>");
                        }
                        //***KONDISI MEMILIKI ANAK2
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA2 = Convert.ToInt32(DropDownListJenisKelaminAnak2.SelectedValue);
                        int pen_a2 = Convert.ToInt32(DropDownListPendidikanAnak2.SelectedValue);
                        int pek_a2 = Convert.ToInt32(DropDownListPekerjaanAnak2.SelectedValue);
                        int usia_a2 = Convert.ToInt32(TxtUsiaAnak2.Text);
                        if (jenkelA2 != 0 && pen_a2 != 0 && pek_a2 != 0)
                        {
                            string SqlCmdAnak2 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak2.Text + "', " + jenkelA2 + ", " + usia_a2 + ", " + pen_a2 + ", " + pek_a2 + ")";
                            string HasilAnak2 = InsertDataAnak(SqlCmdAnak2);
                            if (HasilAnak2 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 2');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 2, dengan Error : " + HasilAnak2 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 2 Wajib Di Isi');</script>");
                        }
                    }
                    else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "3")
                    {
                        //***KONDISI MEMILIKI ANAK1
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA = Convert.ToInt32(DropDownListJenisKelaminAnak1.SelectedValue);
                        int pen_a = Convert.ToInt32(DropDownListPendidikanAnak1.SelectedValue);
                        int pek_a = Convert.ToInt32(DropDownListPekerjaanAnak1.SelectedValue);
                        int usia_a = Convert.ToInt32(TxtUsiaAnak1.Text);
                        if (jenkelA != 0 && pen_a != 0 && pek_a != 0)
                        {
                            string SqlCmdAnak1 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak1.Text + "', " + jenkelA + ", " + usia_a + ", " + pen_a + ", " + pek_a + ")";
                            string HasilAnak1 = InsertDataAnak(SqlCmdAnak1);
                            if (HasilAnak1 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 1');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 1, dengan Error : " + HasilAnak1 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 1 Wajib Di Isi');</script>");
                        }
                        //***KONDISI MEMILIKI ANAK2
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA2 = Convert.ToInt32(DropDownListJenisKelaminAnak2.SelectedValue);
                        int pen_a2 = Convert.ToInt32(DropDownListPendidikanAnak2.SelectedValue);
                        int pek_a2 = Convert.ToInt32(DropDownListPekerjaanAnak2.SelectedValue);
                        int usia_a2 = Convert.ToInt32(TxtUsiaAnak2.Text);
                        if (jenkelA2 != 0 && pen_a2 != 0 && pek_a2 != 0)
                        {
                            string SqlCmdAnak2 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak2.Text + "', " + jenkelA2 + ", " + usia_a2 + ", " + pen_a2 + ", " + pek_a2 + ")";
                            string HasilAnak2 = InsertDataAnak(SqlCmdAnak2);
                            if (HasilAnak2 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 2');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 2, dengan Error : " + HasilAnak2 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 2 Wajib Di Isi');</script>");
                        }
                        //***KONDISI MEMILIKI ANAK3
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA3 = Convert.ToInt32(DropDownListJenisKelaminAnak3.SelectedValue);
                        int pen_a3 = Convert.ToInt32(DropDownListPendidikanAnak3.SelectedValue);
                        int pek_a3 = Convert.ToInt32(DropDownListPekerjaanAnak3.SelectedValue);
                        int usia_a3 = Convert.ToInt32(TxtUsiaAnak3.Text);
                        if (jenkelA3 != 0 && pen_a3 != 0 && pek_a3 != 0)
                        {
                            string SqlCmdAnak3 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak3.Text + "', " + jenkelA3 + ", " + usia_a3 + ", " + pen_a3 + ", " + pek_a3 + ")";
                            string HasilAnak3 = InsertDataAnak(SqlCmdAnak3);
                            if (HasilAnak3 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 2');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 2, dengan Error : " + HasilAnak3 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 2 Wajib Di Isi');</script>");
                        }
                    }
                    //else
                    //{//***KONDISI TIDAK MEMILIKI ANAK

                    //}
                    //end of menyimpan data anak
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }//end of menyimpan data pasangan
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Pasangan dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Pendidikan dan Pekerjaan Pasangan Wajib di Pilih');</script>");
            }
            //if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "1")
            //{//***KONDISI MEMILIKI ANAK1

            //}
            //else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "2")
            //{//***KONDISI MEMILIKI ANAK2

            //}
            //else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "3")
            //{//***KONDISI MEMILIKI ANAK3

            //}
            //else
            //{//***KONDISI TIDAK MEMILIKI ANAK

            //}
        }
        //***KONDISI KETIKA  PUNYA SAUDARA KANDUNG & DUDA / JANDA
        else if (RadioButtonListPunyaAnak.SelectedValue == "Ya" && RadioButtonListStatusPerkawinan.SelectedValue == "Duda/Janda")
        {
            //Insert data Keluarga
            string SqlCmd = "insert into Data_Keluarga values (" + Convert.ToInt32(IdLamar) + ",'" + TxtNamaAyah.Text + "', '" + TxtNamaIbu.Text + "', " + Convert.ToInt32(DropDownListPendidikanAyah.SelectedIndex) + ", " + Convert.ToInt32(TxtUsiaAyah.Text) + ", " + Convert.ToInt32(DropDownListPekerjaanAyah.SelectedIndex) + ", " + Convert.ToInt32(DropDownListPendidikanIbu.SelectedIndex) + "," + Convert.ToInt32(TxtUsiaIbu.Text) + ", " + Convert.ToInt32(DropDownListPekerjaanIbu.SelectedIndex) + ")";
            string Hasil = InsertDataKeluarga(SqlCmd);
            if (Hasil == "OK")
            {
                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
            }
            //insert data saudara kandung -- YA
            string SqlCmd_Kandung = string.Empty;
            if (RadioButtonListJmlAnak.SelectedIndex == 0)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                if (HasilSK1 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 1)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 2)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 3)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 4)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                string HasilSK5 = InsertDataSaudara(IdLamar, TxtNamaSK5.Text, Convert.ToString(DropDownListJenisKelaminSK5.SelectedValue), TxtUsiaSK5.Text, Convert.ToString(DropDownListPendidikanSK5.SelectedValue), Convert.ToString(DropDownListPekerjaanSK5.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK" && HasilSK5 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 5)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                string HasilSK5 = InsertDataSaudara(IdLamar, TxtNamaSK5.Text, Convert.ToString(DropDownListJenisKelaminSK5.SelectedValue), TxtUsiaSK5.Text, Convert.ToString(DropDownListPendidikanSK5.SelectedValue), Convert.ToString(DropDownListPekerjaanSK5.SelectedValue));
                string HasilSK6 = InsertDataSaudara(IdLamar, TxtNamaSK6.Text, Convert.ToString(DropDownListJenisKelaminSK6.SelectedValue), TxtUsiaSK6.Text, Convert.ToString(DropDownListPendidikanSK6.SelectedValue), Convert.ToString(DropDownListPekerjaanSK6.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK" && HasilSK5 == "OK" && HasilSK6 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 6)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                string HasilSK5 = InsertDataSaudara(IdLamar, TxtNamaSK5.Text, Convert.ToString(DropDownListJenisKelaminSK5.SelectedValue), TxtUsiaSK5.Text, Convert.ToString(DropDownListPendidikanSK5.SelectedValue), Convert.ToString(DropDownListPekerjaanSK5.SelectedValue));
                string HasilSK6 = InsertDataSaudara(IdLamar, TxtNamaSK6.Text, Convert.ToString(DropDownListJenisKelaminSK6.SelectedValue), TxtUsiaSK6.Text, Convert.ToString(DropDownListPendidikanSK6.SelectedValue), Convert.ToString(DropDownListPekerjaanSK6.SelectedValue));
                string HasilSK7 = InsertDataSaudara(IdLamar, TxtNamaSK7.Text, Convert.ToString(DropDownListJenisKelaminSK7.SelectedValue), TxtUsiaSK7.Text, Convert.ToString(DropDownListPendidikanSK7.SelectedValue), Convert.ToString(DropDownListPekerjaanSK7.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK" && HasilSK5 == "OK" && HasilSK6 == "OK" && HasilSK7 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (RadioButtonListJmlAnak.SelectedIndex == 7)
            {
                string HasilSK1 = InsertDataSaudara(IdLamar, TxtNamaSK1.Text, Convert.ToString(DropDownListJenisKelaminSK1.SelectedValue), TxtUsiaSK1.Text, Convert.ToString(DropDownListPendidikanSK1.SelectedValue), Convert.ToString(DropDownListPekerjaanSK1.SelectedValue));
                string HasilSK2 = InsertDataSaudara(IdLamar, TxtNamaSK2.Text, Convert.ToString(DropDownListJenisKelaminSK2.SelectedValue), TxtUsiaSK2.Text, Convert.ToString(DropDownListPendidikanSK2.SelectedValue), Convert.ToString(DropDownListPekerjaanSK2.SelectedValue));
                string HasilSK3 = InsertDataSaudara(IdLamar, TxtNamaSK3.Text, Convert.ToString(DropDownListJenisKelaminSK3.SelectedValue), TxtUsiaSK3.Text, Convert.ToString(DropDownListPendidikanSK3.SelectedValue), Convert.ToString(DropDownListPekerjaanSK3.SelectedValue));
                string HasilSK4 = InsertDataSaudara(IdLamar, TxtNamaSK4.Text, Convert.ToString(DropDownListJenisKelaminSK4.SelectedValue), TxtUsiaSK4.Text, Convert.ToString(DropDownListPendidikanSK4.SelectedValue), Convert.ToString(DropDownListPekerjaanSK4.SelectedValue));
                string HasilSK5 = InsertDataSaudara(IdLamar, TxtNamaSK5.Text, Convert.ToString(DropDownListJenisKelaminSK5.SelectedValue), TxtUsiaSK5.Text, Convert.ToString(DropDownListPendidikanSK5.SelectedValue), Convert.ToString(DropDownListPekerjaanSK5.SelectedValue));
                string HasilSK6 = InsertDataSaudara(IdLamar, TxtNamaSK6.Text, Convert.ToString(DropDownListJenisKelaminSK6.SelectedValue), TxtUsiaSK6.Text, Convert.ToString(DropDownListPendidikanSK6.SelectedValue), Convert.ToString(DropDownListPekerjaanSK6.SelectedValue));
                string HasilSK7 = InsertDataSaudara(IdLamar, TxtNamaSK7.Text, Convert.ToString(DropDownListJenisKelaminSK7.SelectedValue), TxtUsiaSK7.Text, Convert.ToString(DropDownListPendidikanSK7.SelectedValue), Convert.ToString(DropDownListPekerjaanSK7.SelectedValue));
                string HasilSK8 = InsertDataSaudara(IdLamar, TxtNamaSK8.Text, Convert.ToString(DropDownListJenisKelaminSK8.SelectedValue), TxtUsiaSK8.Text, Convert.ToString(DropDownListPendidikanSK8.SelectedValue), Convert.ToString(DropDownListPekerjaanSK8.SelectedValue));
                if (HasilSK1 == "OK" && HasilSK2 == "OK" && HasilSK3 == "OK" && HasilSK4 == "OK" && HasilSK5 == "OK" && HasilSK6 == "OK" && HasilSK7 == "OK" && HasilSK8 == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Saudara Kandung ');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            //INSERT DATA PASANGAN -- YA
            //**Cek value Pendidikan dan Pekerjaan Pasangan
            int pen_p = Convert.ToInt32(DropDownListPendidikanSuamiIstri.SelectedValue);
            int pek_p = Convert.ToInt32(DropDownListPekerjaanSuamiIstri.SelectedValue);
            if (pen_p != 0 && pek_p != 0)
            {
                string SqlCmdPasangan = "insert into Data_Pasangan values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaSuamiIstri.Text + "', " + Convert.ToInt32(TxtUsiaSuamiIstri.Text) + ", " + pen_p + ", " + pek_p + ")";
                string HasilPasangan = InsertDataPasangan(SqlCmdPasangan);
                if (HasilPasangan == "OK")
                {
                    //cek apakah memiliki anak
                    if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "1")
                    {//***KONDISI MEMILIKI ANAK1
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA = Convert.ToInt32(DropDownListJenisKelaminAnak1.SelectedValue);
                        int pen_a = Convert.ToInt32(DropDownListPendidikanAnak1.SelectedValue);
                        int pek_a = Convert.ToInt32(DropDownListPekerjaanAnak1.SelectedValue);
                        int usia_a = Convert.ToInt32(TxtUsiaAnak1.Text);
                        if (jenkelA != 0 && pen_a != 0 && pek_a != 0)
                        {
                            string SqlCmdAnak1 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak1.Text + "', " + jenkelA + ", " + usia_a + ", " + pen_a + ", " + pek_a + ")";
                            string HasilAnak1 = InsertDataAnak(SqlCmdAnak1);
                            if (HasilAnak1 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 1');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 1, dengan Error : " + HasilAnak1 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 1 Wajib Di Isi');</script>");
                        }
                    }
                    else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "2")
                    {
                        //***KONDISI MEMILIKI ANAK1
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA = Convert.ToInt32(DropDownListJenisKelaminAnak1.SelectedValue);
                        int pen_a = Convert.ToInt32(DropDownListPendidikanAnak1.SelectedValue);
                        int pek_a = Convert.ToInt32(DropDownListPekerjaanAnak1.SelectedValue);
                        int usia_a = Convert.ToInt32(TxtUsiaAnak1.Text);
                        if (jenkelA != 0 && pen_a != 0 && pek_a != 0)
                        {
                            string SqlCmdAnak1 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak1.Text + "', " + jenkelA + ", " + usia_a + ", " + pen_a + ", " + pek_a + ")";
                            string HasilAnak1 = InsertDataAnak(SqlCmdAnak1);
                            if (HasilAnak1 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 1');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 1, dengan Error : " + HasilAnak1 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 1 Wajib Di Isi');</script>");
                        }
                        //***KONDISI MEMILIKI ANAK2
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA2 = Convert.ToInt32(DropDownListJenisKelaminAnak2.SelectedValue);
                        int pen_a2 = Convert.ToInt32(DropDownListPendidikanAnak2.SelectedValue);
                        int pek_a2 = Convert.ToInt32(DropDownListPekerjaanAnak2.SelectedValue);
                        int usia_a2 = Convert.ToInt32(TxtUsiaAnak2.Text);
                        if (jenkelA2 != 0 && pen_a2 != 0 && pek_a2 != 0)
                        {
                            string SqlCmdAnak2 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak2.Text + "', " + jenkelA2 + ", " + usia_a2 + ", " + pen_a2 + ", " + pek_a2 + ")";
                            string HasilAnak2 = InsertDataAnak(SqlCmdAnak2);
                            if (HasilAnak2 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 2');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 2, dengan Error : " + HasilAnak2 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 2 Wajib Di Isi');</script>");
                        }
                    }
                    else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "3")
                    {
                        //***KONDISI MEMILIKI ANAK1
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA = Convert.ToInt32(DropDownListJenisKelaminAnak1.SelectedValue);
                        int pen_a = Convert.ToInt32(DropDownListPendidikanAnak1.SelectedValue);
                        int pek_a = Convert.ToInt32(DropDownListPekerjaanAnak1.SelectedValue);
                        int usia_a = Convert.ToInt32(TxtUsiaAnak1.Text);
                        if (jenkelA != 0 && pen_a != 0 && pek_a != 0)
                        {
                            string SqlCmdAnak1 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak1.Text + "', " + jenkelA + ", " + usia_a + ", " + pen_a + ", " + pek_a + ")";
                            string HasilAnak1 = InsertDataAnak(SqlCmdAnak1);
                            if (HasilAnak1 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 1');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 1, dengan Error : " + HasilAnak1 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 1 Wajib Di Isi');</script>");
                        }
                        //***KONDISI MEMILIKI ANAK2
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA2 = Convert.ToInt32(DropDownListJenisKelaminAnak2.SelectedValue);
                        int pen_a2 = Convert.ToInt32(DropDownListPendidikanAnak2.SelectedValue);
                        int pek_a2 = Convert.ToInt32(DropDownListPekerjaanAnak2.SelectedValue);
                        int usia_a2 = Convert.ToInt32(TxtUsiaAnak2.Text);
                        if (jenkelA2 != 0 && pen_a2 != 0 && pek_a2 != 0)
                        {
                            string SqlCmdAnak2 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak2.Text + "', " + jenkelA2 + ", " + usia_a2 + ", " + pen_a2 + ", " + pek_a2 + ")";
                            string HasilAnak2 = InsertDataAnak(SqlCmdAnak2);
                            if (HasilAnak2 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 2');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 2, dengan Error : " + HasilAnak2 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 2 Wajib Di Isi');</script>");
                        }
                        //***KONDISI MEMILIKI ANAK3
                        //Cek tidak boleh kosong jenkel, pendidikan, pekerjaan
                        int jenkelA3 = Convert.ToInt32(DropDownListJenisKelaminAnak3.SelectedValue);
                        int pen_a3 = Convert.ToInt32(DropDownListPendidikanAnak3.SelectedValue);
                        int pek_a3 = Convert.ToInt32(DropDownListPekerjaanAnak3.SelectedValue);
                        int usia_a3 = Convert.ToInt32(TxtUsiaAnak3.Text);
                        if (jenkelA3 != 0 && pen_a3 != 0 && pek_a3 != 0)
                        {
                            string SqlCmdAnak3 = "insert into Data_Anak values (" + Convert.ToInt32(IdLamar) + ", '" + TxtNamaAnak3.Text + "', " + jenkelA3 + ", " + usia_a3 + ", " + pen_a3 + ", " + pek_a3 + ")";
                            string HasilAnak3 = InsertDataAnak(SqlCmdAnak3);
                            if (HasilAnak3 == "OK")
                            {
                                Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan data Anak 2');</script>");
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan data Anak 2, dengan Error : " + HasilAnak3 + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>window.alert('JenKel, Pendidikan dan Pekerjaan Anak 2 Wajib Di Isi');</script>");
                        }
                    }
                    //else
                    //{//***KONDISI TIDAK MEMILIKI ANAK

                    //}
                    //end of menyimpan data anak
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }//end of menyimpan data pasangan
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data Pasangan dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Pendidikan dan Pekerjaan Pasangan Wajib di Pilih');</script>");
            }
            //if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "1")
            //{//***KONDISI MEMILIKI ANAK1

            //}
            //else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "2")
            //{//***KONDISI MEMILIKI ANAK2

            //}
            //else if (RadioButtonListJumlahAnakPerKawinan.SelectedValue == "3")
            //{//***KONDISI MEMILIKI ANAK3

            //}
            //else
            //{//***KONDISI TIDAK MEMILIKI ANAK

            //}
        }
    }
}