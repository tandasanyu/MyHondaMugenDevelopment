using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageUser_PageUser_HomePelamar : System.Web.UI.Page
{
    public int status_DataDiri = 0;
    public int status_DataKeluarga = 0;
    public int status_RiwayatPendidikan = 0;
    public int status_PengalamanOrganisasi = 0; //tidak wajib
    public int status_RiwayatPekerjaan = 0;
    public int status_pertanyaan = 0;
    public int status_unggahfoto = 0;
    public int status_KTP = 0;
    public int status_NPWP = 0;//tidak wajib
    public int status_KK = 0;
    public int status_Ijazah = 0;
    public int status_Transkrip = 0;
    public int status_SLamaran = 0;
    public int status_CV = 0;
    public int idlamaran;
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = string.Empty;
        username = Convert.ToString(Session["User"]); // berisi username dari tb.login
        //get user_nama_login
        string user_nama;
        int id_login;
        string sql = "select user_nama_login, id_login from Login_User where Username_Login = '" + username + "'";
        KelasKoneksi cn = new KelasKoneksi();
        List<String> hasil = cn.KelasKoneksi_SelectGlobal(sql, "2");
        if (hasil.Count > 0)
        {
            user_nama = hasil[0];
            id_login = Convert.ToInt32(hasil[1]);
            string sql2 = "select id_lamaran, user_posisi from Data_Lamaran where user_nama = '" + user_nama + "' and id_login ="+id_login+"";
            List<String> hasil2 = cn.KelasKoneksi_SelectGlobal(sql2, "3");
            if (hasil2.Count > 0)
            {
                LblIdLamaran.Text = hasil2[0];
                LblPosisi.Text = hasil2[1];
                LblNamaPelamar.Text = user_nama;
                idlamaran = Convert.ToInt32(hasil2[0]);
            }

        }
        //ketika page load, makadi periksa setiap dokumen dengan nomor id lamaran berikut apakah ada. jika ada maka hide tombol
        if (Session["User"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        //cek data diri dengan idlamaran ada atau tidak
        string sql_cmdx = "select id_lamaran from data_diri where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(sql_cmdx))
        {
            Button1.Visible = false;
            LblBtnDataDiri.Visible = true;
            status_DataDiri = 1;
        }
        //cek data keluarga, data saudara dan data pasangan dengan idlamaran ada atau tidak
        string SqlCek2 = "select id_lamaran from data_keluarga where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek2))
        {
            BtnDataKeluarga.Visible = false;
            LblBtnDataKel.Visible = true;
            status_DataKeluarga = 1;
        }
        //cek riwayat pendidikan
        string SqlCek3 = "select id_lamaran from Data_PenFormal where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        string SqlCek4 = "select id_lamaran from Data_PenNon where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        string SqlCek5 = "select id_lamaran from Data_Bahasa where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek3) == true || cn.KelasKoneksi_CheckData(SqlCek4) == true || cn.KelasKoneksi_CheckData(SqlCek5) == true)
        {
            BtnRiwayatPendidikan.Visible = false;
            LblBtnRP.Visible = true;
            status_RiwayatPendidikan = 1;
        }
        //cek OrganisasiLeader // tidak wajib
        string SqlCek6 = "select id_lamaran from Data_Organisasi where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        string SqlCek7 = "select id_lamaran from Data_Leader where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek6) == true || cn.KelasKoneksi_CheckData(SqlCek7) == true)
        {
            BtnPengalaman.Visible = false;
            LblBtnPengalaman.Visible = true;
            status_PengalamanOrganisasi = 1;
        }
        //cek riwayat pekerjaan dan referensi
        string SqlCek8 = "select id_lamaran from Data_Pekerjaan where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        string SqlCek9 = "select id_lamaran from Data_Referensi where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek8) == true || cn.KelasKoneksi_CheckData(SqlCek9) == true)
        {
            BtnPkjRef.Visible = false;
            LblBtnPkjRef.Visible = true;
            status_RiwayatPekerjaan = 1;
        }
        //cek Pertanyaan
        string SqlCek10 = "select id_lamaran from Data_Pertanyaan where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek10) == true)
        {
            BtnPertanyaan.Visible = false;
            LblBtnPertanyaan.Visible = true;
            status_pertanyaan = 1;
        }
        //cek uPLOAD fOTO
        string SqlCek11 = "select id_lamaran from dATA_uPLOADfOTO where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek11) == true)
        {
            BtnFoto.Visible = false;
            LblBtnFoto.Visible = true;
            status_unggahfoto = 1;
        }
        //cek uPLOAD KTP
        string SqlCek12 = "select id_lamaran from data_uploadKTP where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek12) == true)
        {
            BtnKtp.Visible = false;
            LblBtnKtp.Visible = true;
            status_KTP = 1;
        }
        //cek uPLOAD NPWP // tidak wajib
        string SqlCek13 = "select id_lamaran from Data_UploadNPWP where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek13) == true)
        {
            BtnNpwp.Visible = false;
            LblBtnNpwp.Visible = true;
            status_NPWP = 1;
        }
        //cek uPLOAD KK--
        string SqlCek133 = "select id_lamaran from Data_UploadKK where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek133) == true)
        {
            BtnKK.Visible = false;
            LblBtnKK.Visible = true;
            status_KK = 1;
        }
        //cek uPLOAD Ijazah
        string SqlCek14 = "select id_lamaran from Data_UploadIjazah where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek14) == true)
        {
            BtnIjz.Visible = false;
            LblBtnIjz.Visible = true;
            status_Ijazah = 1;
        }
        //cek uPLOAD Transkrip
        string SqlCek15 = "select id_lamaran from Data_UploadTranskrip where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek15) == true)
        {
            BtnNilai.Visible = false;
            LblBtnNilai.Visible = true;
            status_Transkrip = 1;
        }
        //cek uPLOAD Lamaran
        string SqlCek16 = "select id_lamaran from Data_UploadSLamaran where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek16) == true)
        {
            BtnLamar.Visible = false;
            LblBtnLamar.Visible = true;
            status_SLamaran = 1;
        }
        //cek uPLOAD CV
        string SqlCek17 = "select id_lamaran from Data_UploadCV where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek17) == true)
        {
            BtnCV.Visible = false;
            LblBtnCV.Visible = true;
            status_CV = 1;
        }
        //cek uPLOAD Surat Ref
        string SqlCek18 = "select id_lamaran from Data_UploadSurat where id_lamaran = " + Convert.ToInt32(LblIdLamaran.Text) + "";
        if (cn.KelasKoneksi_CheckData(SqlCek18) == true)
        {
            BtnSuratRef.Visible = false;
            LblBtnSrt.Visible = true;
        }

    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Login.aspx");
    }
    //button data diri
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_FormDataDiri.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }

    protected void BtnDataKeluarga_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PaguUser_FormDataKeluarga.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }

    protected void BtnRiwayatPendidikan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_FormRiwayatPendidikan.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }

    protected void BtnPengalaman_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_FormPengalamanOrganisasiMemimpin.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }

    protected void BtnPkjRef_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_FormRiwayatPekerjaan.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }

    protected void BtnPertanyaan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_FormPertanyaan.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }

    protected void BtnFoto_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_UploadFoto.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }

    protected void BtnKtp_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_UploadKTP.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }

    protected void BtnNpwp_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_UploadNPWP.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }

    protected void BtnKK_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_UploadKK.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }

    protected void BtnIjz_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_UploadIjazah.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }

    protected void BtnNilai_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_UploadTranskrip.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }

    protected void BtnLamar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_UploadSuratLamaran.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }

    protected void BtnCV_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_UploadCV.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }
    protected void BtnSuratRef_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PageUser/PageUser_UploadSurat.aspx?IdLamaran=" + LblIdLamaran.Text + "");
    }
    //btn kirim lamaran 
    protected void BtnKirimLamaran_Click(object sender, EventArgs e)//status_PengalamanOrganisasi = 0; //tidak wajib //status_NPWP = 0;//tidak wajib
    {
        if (status_DataDiri == 1 && 
            status_DataKeluarga == 1 && 
            status_RiwayatPendidikan == 1 && 
            status_RiwayatPekerjaan == 1 &&
            status_pertanyaan == 1 &&
            status_unggahfoto == 1 &&
            status_KTP == 1 &&
            status_KK == 1 &&
            status_Ijazah == 1 &&
            status_Transkrip == 1 &&
            status_SLamaran == 1 &&
            status_CV == 1)
        {
            KelasKoneksi cn = new KelasKoneksi();
            string update_Data_lamaran =  cn.KelasKoneksi_Update(" update data_lamaran set status_lamaran = 1 where id_lamaran = "+ idlamaran + "");
            //get id login
            string sqlcmd = "select id_login from Data_Lamaran where id_lamaran = "+ idlamaran + "";
            List<String> get_idLogin = cn.KelasKoneksi_SelectGlobal(sqlcmd, "4");
            string update_Login_User = cn.KelasKoneksi_Update("update Login_User set User_Status = 0 where id_login="+Convert.ToInt32(get_idLogin[0]) +" ");
            //Response.Write("<script>alert('Lamaran Anda Telah Dikirim dan Akan segeran Di Proses. Tunggu Pengumuman Selanjutnya')</script>");
            Session.Clear();
            //Response.Redirect("~/Login.aspx");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
            "alert('Lamaran Anda Telah Dikirim dan Akan segeran Di Proses. Tunggu Pengumuman Selanjutnya'); window.location='" +
            Request.ApplicationPath + "../Login.aspx';", true);
        }
        else {
            Response.Write("<script>alert('Data Anda Belum Lengkap, Silahkan Lengkapi !')</script>");
        }
    }


}