using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
//ADO NET NAME SPACE
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Net.Mail;
using System.Net.Mime;

public partial class PagesUser_PageUser_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string posisi = Request.QueryString["Posisi"];
        TxtPosisi.Text = posisi;
        TxtPosisi.ReadOnly = true;
    }
    //untuk fungsi pendukung captcha
    public class MyObject
    {
        public string success { get; set; }
    }

    public bool Validate()
    {
        string Response = Request["g-recaptcha-response"];//Getting Response String Append to Post Method
        bool Valid = false;
        //Request to Google Server
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create
        (" https://www.google.com/recaptcha/api/siteverify?secret=6LfYd5QUAAAAABIjga_sFUYQ49s2q5x5AXypqenX&response=" + Response);
        try
        {
            //Google recaptcha Response
            using (WebResponse wResponse = req.GetResponse())
            {

                using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                {
                    string jsonResponse = readStream.ReadToEnd();

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    MyObject data = js.Deserialize<MyObject>(jsonResponse);// Deserialize Json

                    Valid = Convert.ToBoolean(data.success);
                }
            }

            return Valid;
        }
        catch (WebException ex)
        {
            throw ex;
            
        }
    }
    protected void BtnDaftar_Click(object sender, EventArgs e)
    {
        //validasi captcha
        if (Validate())
        {
            //insert data regist calon pelamar
            KelasKoneksi cn = new KelasKoneksi();
            string str_u = TxtUsername.Text;
            str_u = str_u.Replace(" ", String.Empty);
            string str_p = TxtPswd.Text;
            str_p = str_p.Replace(" ", String.Empty);
            //insert Login_User
            string SqlCmd_InsertLogin_User = "Insert into Login_User (User_Nama_Login, Username_Login, Password_Login, User_Email, User_Posisi, user_status, User_Level) values ('"+TxtNama.Text+"','"+str_u+"','"+str_p+"','"+TxtEmail.Text+"','"+TxtPosisi.Text+"',1,'Pelamar')";
            string hasil_Login_User = cn.KelasKoneksi_Insert(SqlCmd_InsertLogin_User);
            if (hasil_Login_User == "1") {
                //get user_nama, user_posisi, id_login
                string SqlCmd_GetDetailPelamar = "select User_Nama_Login, User_Posisi, Id_Login, user_email from LOGIN_USER where Username_Login = '"+ str_u + "' and User_Level = 'Pelamar'";
                List<String> Hdp = cn.KelasKoneksi_DetailPelamar(SqlCmd_GetDetailPelamar);
                //insert Data_Lamaran
                string SqlCmd_InsertData_Lamaran = "Insert into Data_Lamaran (User_Nama,User_Posisi,Id_login) values ('"+Hdp[0].ToString()+"','"+Hdp[1]+"','"+Hdp[2]+"')";
                string hasil_Data_Lamaran = cn.KelasKoneksi_Insert(SqlCmd_InsertData_Lamaran);
                if (hasil_Data_Lamaran == "1") {
                    //call function email username dan password [str_u, str_p]
                    string str_ue = Hdp[3].ToString();
                    string hasil_email = cn.email_otomatis(str_ue, "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'> Selamat, Registrasi Anda Berhasil!<br/> Berikut Adalah Detail Akun Anda Untuk Login ; <br/> Username : "+str_u+" <br/>Password : "+str_p+"<br/> Jaga selalu Kerahasiaan Akun Anda. Honda Mugen Tidak Bertanggung Jawab atas Kelalaian yang di sebabkan Oleh Pengguna.  <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '></center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lamaran Anda Telah di Simpan !')", true);
                    //redirect ke home pelamar
                }
                else
                {
                    Response.Write("<script>alert('Terdapat Error Ketika Insert Data Lamaran : " + hasil_Data_Lamaran + "')</script>");
                }
            } else {
                Response.Write("<script>alert('Terdapat Error Ketika Insert Data Register Akun : "+ hasil_Login_User + "')</script>");
            }
        }

        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Gagal menyimpan, Harap Centang Captcha !')", true);
            //lblmsg.Text = "Not Valid Recaptcha";
            //lblmsg.ForeColor = System.Drawing.Color.Red;
        }
    }
}