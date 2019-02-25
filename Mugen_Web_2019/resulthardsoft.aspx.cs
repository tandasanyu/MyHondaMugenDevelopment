using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;

public partial class resulthardsoft : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userAkses = (string)(Session["username"]);
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        con.Open();
        DataSet ds2 = new DataSet();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'PROSES PERBAIKAN -- VIEW MENU'", con);

        da2.Fill(ds2);
        int count2 = ds2.Tables[0].Rows.Count;
        if (count2 == 0)
        {
            form1.Visible = false;
        }
        else
        {
            form1.Visible = true;
        }
        DataSet ds3 = new DataSet();
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'PROSES PERBAIKAN -- PENDING'", con);

        da3.Fill(ds3);
        int count3 = ds3.Tables[0].Rows.Count;
        if (count3 == 0)
        {
            txtIdpending.Visible = false;
            txtTglpending.Visible = false;
            btnPending.Visible = false;
        }
        else
        {
            txtIdpending.Visible = true;
            txtTglpending.Visible = true;
            btnPending.Visible = true;
        }
        DataSet ds4 = new DataSet();
        SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'PROSES PERBAIKAN -- HISTORY'", con);

        da4.Fill(ds4);
        int count4 = ds4.Tables[0].Rows.Count;
        if (count4 == 0)
        {
            txtIdmemo.Visible = false;
            txtTanggal.Visible = false;
            txtUser.Visible = false;
            txtResult.Visible = false;
            Button2.Visible = false;
            GridView2.Visible = false;
        }
        else
        {
            txtIdmemo.Visible = true;
            txtTanggal.Visible = true;
            txtUser.Visible = true;
            txtResult.Visible = true;
            Button2.Visible = true;
            GridView2.Visible = true;
        }
        DataSet ds5 = new DataSet();
        SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'PROSES PERBAIKAN -- CLOSING'", con);

        da5.Fill(ds5);
        int count5 = ds5.Tables[0].Rows.Count;
        if (count5 == 0)
        {
            txtKode.Visible = false;
            Button1.Visible = false;
        }
        else
        {
            txtKode.Visible = true;
            Button1.Visible = true;
        }
        con.Close();

        if (Session["username"] != null)
        {
            txtUser.Text = "" + Session["username"];
        }
        txtTanggal.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt");
        string uKode = Request.QueryString["id"];
        txtKode.Text = uKode;
        string idPending = Request.QueryString["idpend"];
        txtIdpending.Text = idPending;
        string idMemo = Request.QueryString["idmemo"];
        txtIdmemo.Text = idMemo;
        txtTglpending.Attributes.Add("readonly", "readonly");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string kodeHardsoft = txtKode.Text;
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE formhardsoft SET resulthardsoft = 'SELESAI', selesai = GETDATE(), aktual = GETDATE() WHERE idhardsoft = '" + kodeHardsoft + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM bodyhardsoft WHERE idhardsoftbody = '" + kodeHardsoft + "'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Proses closing tidak bisa dilakukan karena belum ada History pekerjaan.');</script>");
        }
        else
        {
            if (txtKode.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum memilih data yang ingin anda closing.');</script>");
            }
            else
            {
                if (txtKode.Text == "")
                { ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Hubungi IT kegagalan pengambilan data.');</script>"); }
                else
                {
                    
                    using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM formhardsoft INNER JOIN tb_user ON formhardsoft.userhardsoft = tb_user.username INNER JOIN divisi ON tb_user.kddivisi = divisi.kddivisi WHERE idhardsoft = '" + kodeHardsoft + "'";
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string email = reader["emaildivisi"].ToString();
                                string masalah = reader["masalah"].ToString();
                                string kodeSaya = reader["idhardsoft"].ToString();
                                string user = reader["userhardsoft"].ToString();
                                string tglajukan = reader["tglajukan"].ToString();
                                string selesaikan = reader["resulthardsoft"].ToString();
                                if (email == "")
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak dapat diproses karena e-mail divisi tidak terdaftar.');</script>");
                                }
                                else
                                {
                                    MailAddress from = new MailAddress("hmugen1991@gmail.com");
                                    MailAddress to = new MailAddress("stiiawanchen94@gmail.com," + email);
                                    MailMessage message = new MailMessage(from, to);
                                    message.Subject = "[HONDA MUGEN] Konfirmasi Perbaikan Hardware & Software";
                                    message.Body = @"<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>e-Mail ini adalah konfirmasi pemberitahuan bahwa, pengajuan perbaikan Hardware & Software anda telah selesai kami proses.<br/><br/>Silahkan lakukan re-Closing pada menu Permintaan Saya apabila dirasa pekerjaan belum selesai sesuai keinginan, apabila tidak ada keluhan/Re-Closing kembali dalam waktu 1 x 24 Jam maka kami anggap pekerjaan selesai.<br/><br/><div style='margin:0 auto;background: #FFEFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:8pt;'><u>Detail keluhan</u>:<br/>" + masalah + "<br/><span style='color:blue;font-size:8pt;'>(" + user + ":" + tglajukan + ")</span></div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=myformhardsoft.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Lihat Permintaan Saya</a></center><br><br/>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.<br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                                    message.IsBodyHtml = true;
                                    SmtpClient sc = new SmtpClient();
                                    sc.Host = "smtp.gmail.com";
                                    sc.Port = 587;
                                    sc.EnableSsl = true;
                                    sc.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
                                    sc.Send(message);
                                    cmd.ExecuteNonQuery();
                                    Response.Redirect("resulthardsoft.aspx");
                                }

                            }
                        }
                    }
                }
            }
        }
        con.Close();
    }
    protected void btnPending_Click(object sender, EventArgs e)
    {
        string kodeHardsoft = txtKode.Text;
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM formhardsoft WHERE idhardsoft = '" + txtIdpending.Text + "' AND resulthardsoft is null", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Data yang anda pilih sudah pernah di repair.');</script>");
        }
        else
        {
            if (txtIdpending.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Klik lagi data yang mau dipending !');</script>");
            }
            else
            {
                if (txtTglpending.Text == "")
                { ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Anda belum mengisi tanggal Deadline baru.');</script>"); }
                else
                {

                    using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM formhardsoft  WHERE idhardsoft = '" + txtIdpending.Text + "'";
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tglajukan = reader["tglajukan"].ToString();
                                string userhardsoft = reader["userhardsoft"].ToString();
                                string masalah = reader["masalah"].ToString();
                                string userpengaju = reader["userpengaju"].ToString();
                                string tujuandivisi = reader["tujuandivisi"].ToString();
                                string cabangAsal = reader["cabangasal"].ToString();
                                string cabangTujuan = reader["cabangtujuan"].ToString();

                                SqlCommand cmd = new SqlCommand("UPDATE formhardsoft SET resulthardsoft = 'PENDING' WHERE idhardsoft = '" + txtIdpending.Text + "'", con);
                                SqlCommand cmd2 = new SqlCommand("INSERT INTO formhardsoft (tglajukan, userhardsoft, masalah, userpengaju, tujuandivisi, deadline, cabangasal, cabangtujuan) VALUES ('" + tglajukan + "', '" + userhardsoft + "', '" + masalah + "&nbsp;(PENDING)', '" + userpengaju + "', '" + tujuandivisi + "', '" + txtTglpending.Text + "', '" + cabangAsal + "', '" + cabangTujuan + "')", con);
                     
                                    cmd.ExecuteNonQuery();
                                    cmd2.ExecuteNonQuery();
                                    Response.Redirect("resulthardsoft.aspx");
                                

                            }
                        }
                    }
                }
            }
        }
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string kdhardsoft = txtIdmemo.Text;
        string tglHard = txtTanggal.Text;
        string userName = txtUser.Text;
        string result = txtResult.Text;

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("INSERT INTO bodyhardsoft (idhardsoftbody, usernote, tglnote, pesannote) VALUES ('" + kdhardsoft + "', '" + userName + "', '" + tglHard + "', '" + result + "')", con);
        con.Open();
        if (result == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Anda belum menulis result pekerjaan anda.');</script>");
        }
        else
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("resulthardsoft.aspx");
        }
        con.Close();
    }
}
