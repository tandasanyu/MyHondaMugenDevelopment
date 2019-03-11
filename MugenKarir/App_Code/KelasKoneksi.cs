using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//ADO NET NAME SPACE
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections; //for array list
using System.Net.Mail;
using System.Net.Mime;

/// <summary>
/// Summary description for KelasKoneksi
/// </summary>
public class KelasKoneksi
{
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataReader reader;
    public string status_hasil;
    //fungsi coba coba 
    public string KelasKoneksi_Open()
    {
        
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        conn.Open();
        if (conn.State == ConnectionState.Open)
        {
            status_hasil = "1";
            return status_hasil;
        }
        else
        {
             status_hasil = "0";
            return status_hasil;
        }
    }
    public string KelasKoneksi_Close() {
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        conn.Close();
        if (conn.State == ConnectionState.Closed)
        {
            status_hasil = "1";
            return status_hasil;
        }
        else
        {
            status_hasil = "0";
            return status_hasil;
        }
    }
    //coba
    public string KelasKoneksi_LoginTest(string SqlCmd)
    {
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql = "";
        sql= SqlCmd;
        cmd = new SqlCommand(sql, conn);


        try
        {
            conn.Open();
            reader = cmd.ExecuteReader(); //Menggunakan data reader untuk select dan mengambil value nya 
            while (reader.Read())
            {
                status_hasil=reader.GetValue(1).ToString();


            }
            //status_hasil = "1";
            return status_hasil;
        }
        catch (SqlException ex)
        {
            status_hasil = "Terjadi error Ketika Test: " + ex.Message;
            return status_hasil;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }

    }


    /*Below Main Working Code*/

    //fungsi select global dengan arraylist
    public List<String> GlobalAr = new List<String>();
    public List<String> KelasKoneksi_SelectGlobal(string SqlCmd, string sub) {
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);
        SqlDataReader reader; //Menggunakan data reader untuk select dan mengambil value nya 


            GlobalAr.Clear();
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (sub == "1")
                    {
                        GlobalAr.Add(reader["Id_Lamaran"].ToString()); //0
                    }
                    else if (sub == "2")
                    {
                        GlobalAr.Add(reader["user_nama_login"].ToString()); //0
                    }
                    else if (sub == "3")
                    {
                        GlobalAr.Add(reader["id_lamaran"].ToString()); //0
                        GlobalAr.Add(reader["user_posisi"].ToString()); //0
                    }
                }
                //status_hasil = "1";

            }
            catch (SqlException ex)
            {
                status_hasil = "Terjadi error Ketika Select: " + ex.Message;
                GlobalAr.Clear();
                // return ArrayLogin;

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }

            return GlobalAr;

    }
    //fungsi email 
    public string email_otomatis(string e, string pesan)
    {
        string hasil = "";
        string subject = "PT. Mutra Usaha Gentaniaga (Honda Mugen) Email Notification"; ;
        string body = pesan;

        //****WORKING CODE**************************************************************
        SmtpClient client = new SmtpClient("smtp.gmail.com");
        client.Port = 587;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        try
        {
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
            client.EnableSsl = true;
            client.Credentials = credentials;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        //Creates a new message
        try
        {
            var mail = new MailMessage("hmugen1991@gmail.com", e);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;
            client.Send(mail);
        }
        //Failing to deliver the message or to authentication will throw an exception
        catch (Exception ex)
        {
            hasil = "Terdapat error Ketika Mengirim Email : " + ex.Message;
        }
        return hasil;
    }

    //fungsi untuk search login user
    public List<String> ArrayLogin = new List<String>(); // arrylist untuk login
    public List<String> ArrayDetailPelamar = new List<String>(); // arrylist untuk Detail Pelamar
    public List<String> KelasKoneksi_Login(string SqlCmd) {
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);
        SqlDataReader reader; //Menggunakan data reader untuk select dan mengambil value nya 

        try
        {
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read()) {
                ArrayLogin.Add(reader["Password_Login"].ToString()); //0
                ArrayLogin.Add(reader["User_Posisi"].ToString()); //1
                ArrayLogin.Add(reader["User_Status"].ToString()); //2
                ArrayLogin.Add(reader["User_Level"].ToString()); //3
                ArrayLogin.Add(reader["Username_Login"].ToString()); //4
            }
            //status_hasil = "1";
            return ArrayLogin;
        }
        catch (SqlException ex)
        {
            status_hasil = "Terjadi error Ketika Insert: " + ex.Message;
            ArrayLogin.Clear();
            return ArrayLogin;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }

    }
    //fungsi untuk select detail pelamar 
    public List<String> KelasKoneksi_DetailPelamar(string SqlCmd) {
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);
        SqlDataReader reader; //Menggunakan data reader untuk select dan mengambil value nya 

        try
        {
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ArrayDetailPelamar.Add(reader["User_Nama_Login"].ToString()); //0
                ArrayDetailPelamar.Add(reader["User_Posisi"].ToString()); //1
                ArrayDetailPelamar.Add(reader["Id_Login"].ToString()); //2 
                ArrayDetailPelamar.Add(reader["user_email"].ToString()); //3
            }
            //status_hasil = "1";
            return ArrayDetailPelamar;
        }
        catch (SqlException ex)
        {
            status_hasil = "Terjadi error Ketika Insert: " + ex.Message;
            ArrayDetailPelamar.Clear();
            return ArrayDetailPelamar;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }
    }

    //fungsi untuk insert
    public string KelasKoneksi_Insert(string SqlCmd) {
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);      
        string sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            status_hasil = "1";
        }
        catch (SqlException sqlEx)
        {
            status_hasil = "Terjadi error Ketika Insert: " + sqlEx.Message;
        }
        finally {
            cmd.Dispose();
            conn.Close();
        }
        

        return status_hasil;
    }

    //fungsi untuk update
    public string KelasKoneksi_Update(string SqlCmd) {
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);
        try
        {
            conn.Open();
            //cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            status_hasil = "1";
        }
        catch (SqlException sqlEx)
        {
            status_hasil = "Terjadi error Ketika Update: " + sqlEx.Message;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }
        return status_hasil;
    }

    //fungsi untuk Delete
    public string KelasKoneksi_Delete(string SqlCmd) {
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);
        try
        {
            conn.Open();
            //cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            status_hasil = "1";
        }
        catch (SqlException sqlEx)
        {
            status_hasil = "Terjadi error Ketika Delete: " + sqlEx.Message;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }
        return status_hasil;
    }
}

