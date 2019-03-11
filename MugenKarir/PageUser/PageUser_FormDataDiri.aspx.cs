using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageUser_PageUser_FormDataDiri : System.Web.UI.Page
{
    public string IdLamar;
    protected void Page_Load(object sender, EventArgs e)
    {
        //cek sesi
        if (Session["User"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        //get url param       
         IdLamar= Request.QueryString["IdLamaran"];
        Response.Write("<script language=javascript>alert('Value : "+IdLamar+"');</script>");
    }
    //method untuk insert
    public string InsertDataDiri() {
        string Hasil = string.Empty;
        //proses insert ke table data_diri*********** di buat method 
        
        return Hasil ="OK";
    }
    //BIG NOTE*****
    //telpon rumah tidak wajib di isi
    //validasi jika rbList Jenis alamat dipilih Berbeda dengan KTP maka text area bisa di isi dan di validasi tidak bole kosong
    public int s1, s2, s3,s4;
    public int nosim;
    protected void BtnSubmitFormDataDiri_Click(object sender, EventArgs e)
    {
        //validasi TTL berbeda / sama dengan KTP
        string nama = TxtNamaLengkap.Text;
        string tempatlahir = TxtTempatLahir.Text;
        string selectedValue = RadioButtonListAlamatTinggal.SelectedValue;
        string TTL_KTP;
        DateTime dateLahir = DateTime.ParseExact(TxtTglLahir.Text, "dd/MM/yyyy", null);
        string telp_rumah = TxtTeleponRumah.Text;
        string rek = TxtRekBca.Text;
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
            string rbList_JenKels = string.Empty;
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
            string rbList_JenSIM = string.Empty;
           
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
            string rbList_Agama = string.Empty;
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
                    Response.Write("<script language='javascript'>window.alert('Gagal Menyimpan Data');window.location='../PageUser/PageUser_HomePelamar.aspx';</script>");
                }
               
                //Response.Redirect("~/PageUser/PageUser_HomePelamar.aspx");

            }
            else if (rbList_Agama == "Kristen")
            {
                rbList_Agama = "2";
                InsertDataDiri();
            }
            else if (rbList_Agama == "Katolik")
            {
                rbList_Agama = "3";
                InsertDataDiri();
            }
            else if (rbList_Agama == "Hindu")
            {
                rbList_Agama = "4";
                InsertDataDiri();
            }
            else if (rbList_Agama == "Budha")
            {
                rbList_Agama = "5";
                InsertDataDiri();
            }
            else if (rbList_Agama == "Konghucu")
            {
                rbList_Agama = "6";
                InsertDataDiri();
            }

        } else {
            Response.Write("<script language=javascript>alert('Masih Ada Validasi yang Belum Terpenuhi. Silahkan Cek Kembali');</script>");
        }

    }
}