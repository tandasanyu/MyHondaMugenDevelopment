using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageUser_PageUser_FormDataDiri : System.Web.UI.Page
{
    public string IdLamar;
    public string rbList_JenKels = string.Empty;
    public string rbList_Agama = string.Empty;
    public string rbList_JenSIM = string.Empty;
    public string selectedValue;
    public string TTL_KTP;
    public string Alamat;
    public string telp_rumah;
    public int nosim;
    public string rek;
    //public DateTime dateLahir = DateTime.ParseExact(TxtTglLahir.Text, "dd/MM/yyyy", null);
    protected void Page_Load(object sender, EventArgs e)
    {
        //cek sesi
        if (Session["User"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        //get url param       
         IdLamar= Request.QueryString["IdLamaran"];
        //Response.Write("<script language=javascript>alert('Value : "+IdLamar+"');</script>");
    }
    //method untuk insert
    public string InsertDataDiri() {
        string Hasil = string.Empty;
        Alamat = TextAreaAlamatKTP.InnerText;
        //proses insert ke table data_diri*********** di buat method 
        KelasKoneksi kn = new KelasKoneksi();
        string SqlCmd = "Insert into Data_Diri (Id_lamaran, Nama_Lengkap, Nama_Panggilan, Tempat_Lahir, Tgl_Lahir, JenKel, Agama, Alamat_KTP, Alamat_Tinggal, No_Telp, No_HP, Email, Hobi, No_KTP, No_NPWP, No_Jamsos, Jen_SIM, No_SIM, NoRekBCA) values (" + Convert.ToInt32(IdLamar)+", '"+TxtNamaLengkap.Text+"', '"+TxtNamaPanggilan.Text+"', '"+TxtTempatLahir.Text+ "', convert(date,'"+TxtTglLahir.Text+"',105), " + Convert.ToInt32(rbList_JenKels) +",  " + Convert.ToInt32(rbList_Agama) + ",'"+ Alamat + "', '"+TTL_KTP+"', '"+telp_rumah +"', '"+TxtHandphone.Text+"', '"+TxtEmail.Text+"', '"+TxtHobi.Text+"', '"+TxtNoKTP.Text+"', '"+TxtNPWP.Text+"', '"+TxtJamsos.Text+"', "+Convert.ToInt32(rbList_JenSIM) +", "+nosim+", "+rek+")";
        string Hasil_Insert = kn.KelasKoneksi_Insert(SqlCmd);
        if (Hasil_Insert == "1")
        {
            Hasil = "OK";
        }
        else {
            Hasil = Hasil_Insert;
        }
        return Hasil;
    }
    //BIG NOTE*****
    //telpon rumah tidak wajib di isi
    //validasi jika rbList Jenis alamat dipilih Berbeda dengan KTP maka text area bisa di isi dan di validasi tidak bole kosong
    public int s1, s2, s3,s4;
    
    protected void BtnSubmitFormDataDiri_Click(object sender, EventArgs e)
    {
        //validasi TTL berbeda / sama dengan KTP
        string nama = TxtNamaLengkap.Text;
        string tempatlahir = TxtTempatLahir.Text;
        selectedValue = RadioButtonListAlamatTinggal.SelectedValue;
        
        
        telp_rumah = TxtTeleponRumah.Text;
         rek = TxtRekBca.Text;
        //validasi rek bca
        if (rek == "")
        {
            rek = "0";
            s3 = 1;
        }
        else
        {
            rek = TxtRekBca.Text;
            s3 = 1;
        }
        //validasi telp rumah
        if (telp_rumah == "")
        {
            telp_rumah = "0";
            s1 = 1;
        }
        else {
            s1 = 1;
        }
        //validasi ktp
        if (selectedValue == "Berbeda dengan KTP") {         
            TTL_KTP = TextAreaAamatKTP.InnerText;
            if (TTL_KTP == "")
            {
                s2 = 0;
                Response.Write("<script language=javascript>alert('Alamat Berbeda dengan KTP Wajib di Isi');</script>");
                
            }
            else {
                s2 = 1;
            }
        }
        else {
            TTL_KTP = TextAreaAlamatKTP.InnerText;
            if (TTL_KTP == "")
            {
                s2 = 0;
                Response.Write("<script language=javascript>alert('Alamat Berbeda dengan KTP Wajib di Isi');</script>");
               
            }
            else {
                s2 = 1;
            }
        }
        //validasi TxtSIM - jika radiobuttonList != tidak ada maka TxtNomorSIM wajib di isi
        string rBList_Email = string.Empty;
        foreach (ListItem i in RadioButtonListSIM.Items)
        {
            if (i.Selected == true)
            {
                rBList_Email = i.Value;               
            }
        }
        if (rBList_Email != "Tidak Ada")
        {
            if (TxtNomorSIM.Text == "")
            {
                s4 = 0;
                Response.Write("<script language=javascript>alert('Nomor SIM Wajib di Isi');</script>");
            }
            else
            {
                s4 = 1;
            }
        }
        else {
            s4 = 1;
        }
        if (s1==1 && s2==1 && s4==1 && s3 == 1) {
            //***validasi data sebelum insert
            //******validasi data jenkel

            foreach (ListItem i in RadioButtonListJenisKelamin.Items) {
                if (i.Selected == true)
                {
                    rbList_JenKels = i.Value;
                }
            }
            if (rbList_JenKels == "Pria") {
                rbList_JenKels = "1";
            }
            else {
                rbList_JenKels = "2";
            }
            //** validasi jenis sim  RadioButtonListSIM
            
           
            foreach (ListItem i in RadioButtonListSIM.Items)
            {
                if (i.Selected == true)
                {
                    rbList_JenSIM = i.Value;
                }
            }
            if (rbList_JenSIM == "SIM A")
            {
                rbList_JenSIM = "1";
                nosim = Convert.ToInt32(TxtNomorSIM.Text);
            }
            else if (rbList_JenSIM == "SIM C")
            {
                rbList_JenSIM = "2";
                nosim = Convert.ToInt32(TxtNomorSIM.Text);
            }
            else if (rbList_JenSIM == "Tidak Ada") {
                rbList_JenSIM = "0";
                nosim  = 0;
            }
            //***validasi agama RadioButtonListAgama

            foreach (ListItem i in RadioButtonListAgama.Items)
            {
                if (i.Selected == true)
                {
                    rbList_Agama = i.Value;
                }
            }
            if (rbList_Agama == "Islam")
            {
                rbList_Agama = "1";
                string Hasil = InsertDataDiri();
                if (Hasil == "OK") {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : "+Hasil+"');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (rbList_Agama == "Kristen")
            {
                rbList_Agama = "2";
                string Hasil = InsertDataDiri();
                if (Hasil == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (rbList_Agama == "Katolik")
            {
                rbList_Agama = "3";
                string Hasil = InsertDataDiri();
                if (Hasil == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (rbList_Agama == "Hindu")
            {
                rbList_Agama = "4";
                string Hasil = InsertDataDiri();
                if (Hasil == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (rbList_Agama == "Budha")
            {
                rbList_Agama = "5";
                string Hasil = InsertDataDiri();
                if (Hasil == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }
            else if (rbList_Agama == "Konghucu")
            {
                rbList_Agama = "6";
                string Hasil = InsertDataDiri();
                if (Hasil == "OK")
                {
                    Response.Write("<script language='javascript'>window.alert('Berhasil Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data dengan error : " + Hasil + "');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
            }

        } else {
            Response.Write("<script language=javascript>alert('Masih Ada Validasi yang Belum Terpenuhi. Silahkan Cek Kembali');</script>");
        }

    }
}