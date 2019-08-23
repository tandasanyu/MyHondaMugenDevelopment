using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;

public partial class formhardsoft : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userAkses = (string)(Session["username"]);
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        con.Open();
        DataSet ds2 = new DataSet();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERBAIKAN HARDWARE & SOFTWARE -- VIEW MENU'", con);

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
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERBAIKAN HARDWARE & SOFTWARE -- VIEW DATA'", con);

        da3.Fill(ds3);
        int count3 = ds3.Tables[0].Rows.Count;
        if (count3 == 0)
        {
            GridView1.Visible = false;
        }
        else
        {
            GridView1.Visible = true;
        }
        DataSet ds4 = new DataSet();
        SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERBAIKAN HARDWARE & SOFTWARE -- NEW DATA'", con);

        da4.Fill(ds4);
        int count4 = ds4.Tables[0].Rows.Count;
        if (count4 == 0)
        {
            HyperLink2.Visible = false;
            Button1.Visible = false;
        }
        else
        {
            HyperLink2.Visible = true;
            Button1.Visible = true;
        }
        DataSet ds5 = new DataSet();
        SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'DAFTAR PERMINTAAN -- VIEW MENU'", con);

        da5.Fill(ds5);
        int count5 = ds5.Tables[0].Rows.Count;
        if (count5 == 0)
        {
            HyperLink3.Visible = false;
        }
        else
        {
            HyperLink3.Visible = true;
        }
        DataSet ds6 = new DataSet();
        SqlDataAdapter da6 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'PROSES PERBAIKAN -- VIEW MENU'", con);

        da6.Fill(ds6);
        int count6 = ds6.Tables[0].Rows.Count;
        if (count6 == 0)
        {
            HyperLink4.Visible = false;
        }
        else
        {
            HyperLink4.Visible = true;
        }
        DataSet ds7 = new DataSet();
        SqlDataAdapter da7 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'PERMINTAAN SAYA --- VIEW MENU'", con);

        da7.Fill(ds7);
        int count7 = ds7.Tables[0].Rows.Count;
        if (count7 == 0)
        {
            HyperLink5.Visible = false;
        }
        else
        {
            HyperLink5.Visible = true;
        }
        con.Close();

        if (Session["username"] != null)
        {

        }
        else
        {
            Response.Redirect("default.aspx");
        }
        txtTanggal.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt");

        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string user = (string)(Session["username"]);
            string cabang = (string)(Session["kdcabang"]);
            if (user == "GA128")
            {
                command.CommandText = "SELECT COUNT(idhardsoft) AS total FROM [formhardsoft] WHERE ([resulthardsoft] IS NULL) AND ([deadline] IS NULL) AND ([cabangtujuan] = '" + cabang + "') AND ([tujuandivisi] <> 'IT')";
            }
            else if (user == "GA112")
            {
                command.CommandText = "SELECT COUNT(idhardsoft) AS total FROM [formhardsoft] WHERE ([resulthardsoft] IS NULL) AND ([deadline] IS NULL) AND ([cabangtujuan] = '" + cabang + "') AND ([tujuandivisi] <> 'IT')";
            }
            else if (user == "IT128")
            {
                command.CommandText = "SELECT COUNT(idhardsoft) AS total FROM [formhardsoft] WHERE ([resulthardsoft] IS NULL) AND ([deadline] IS NULL) AND ([cabangtujuan] = '" + cabang + "') AND ([tujuandivisi] <> 'GA')";
            }
            else if (user == "IT112")
            {
                command.CommandText = "SELECT COUNT(idhardsoft) AS total FROM [formhardsoft] WHERE ([resulthardsoft] IS NULL) AND ([deadline] IS NULL) AND ([cabangtujuan] = '" + cabang + "') AND ([tujuandivisi] <> 'GA')";
            }
            else
            {
                command.CommandText = "SELECT COUNT(idhardsoft) AS total FROM [formhardsoft] WHERE ([resulthardsoft] IS NULL) AND ([deadline] IS NULL) AND ([cabangtujuan] = '" + cabang + "')";
            }
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalharga = reader["total"].ToString();
                    if (totalharga == "")
                    {
                        lblBtn1.Text = "0";
                    }
                    else
                    {
                        lblBtn1.Text = totalharga;
                    }

                }
            }
            connection.Close();
        }
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string user = (string)(Session["username"]);
            string cabang = (string)(Session["kdcabang"]);
            if (user == "GA128")
            {
                command.CommandText = "SELECT COUNT(idhardsoft) AS total FROM [formhardsoft] WHERE ([resulthardsoft] IS NULL) AND ([deadline] IS NOT NULL) AND ([cabangtujuan] = '" + cabang + "') AND ([tujuandivisi] <> 'IT')";
            }
            else if (user == "GA112")
            {
                command.CommandText = "SELECT COUNT(idhardsoft) AS total FROM [formhardsoft] WHERE ([resulthardsoft] IS NULL) AND ([deadline] IS NOT NULL) AND ([cabangtujuan] = '" + cabang + "') AND ([tujuandivisi] <> 'IT')";
            }
            else if (user == "IT128")
            {
                command.CommandText = "SELECT COUNT(idhardsoft) AS total FROM [formhardsoft] WHERE ([resulthardsoft] IS NULL) AND ([deadline] IS NOT NULL) AND ([cabangtujuan] = '" + cabang + "') AND ([tujuandivisi] <> 'GA')";
            }
            else if (user == "IT112")
            {
                command.CommandText = "SELECT COUNT(idhardsoft) AS total FROM [formhardsoft] WHERE ([resulthardsoft] IS NULL) AND ([deadline] IS NOT NULL) AND ([cabangtujuan] = '" + cabang + "') AND ([tujuandivisi] <> 'GA')";
            }
            else
            {
                command.CommandText = "SELECT COUNT(idhardsoft) AS total FROM [formhardsoft] WHERE ([resulthardsoft] IS NULL) AND ([deadline] IS NOT NULL) AND ([cabangtujuan] = '" + cabang + "')";
            }
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalharga = reader["total"].ToString();
                    if (totalharga == "")
                    {
                        lblBtn2.Text = "0";
                    }
                    else
                    {
                        lblBtn2.Text = totalharga;
                    }

                }
            }
            connection.Close();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);

        string tglm = txtTanggal.Text;
        string masalah = txtMasalah.Text;
        string tujuan = txtTujuan.Text;
        string user = txtUser.Text;
        string iduser = Session["username"].ToString();
        string cAsal = Session["kdcabang"].ToString();
        string cTujuan = txtCabang.Text;

        SqlCommand cmd = new SqlCommand("INSERT INTO formhardsoft (tujuandivisi, tglajukan, userhardsoft, userpengaju, masalah, cabangasal, cabangtujuan) VALUES('" + tujuan + "', '" + tglm + "', '" + iduser + "', '" + user + "', '" + masalah + "', '" + cAsal + "', '" + cTujuan + "')", con);
        con.Open();

        if (tglm == "")
        {
            Label1.Text = "Tanggal tidak boleh kosong";
        }
        else if (masalah == "")
        {
            Label1.Text = "Tolong isi keluhan, tidak boleh kosong";
        }
        else if (cTujuan == "")
        {
            Label1.Text = "Tolong isi cabang tujuan, tidak boleh kosong";
        }
        else if (user == "")
        {
            Label1.Text = "Tolong isi nama yang membuat permintaan, tidak boleh kosong";
        }
        else
        {
            if (tujuan == "IT")
            {
                if (cTujuan == "112")
                {
                    MailAddress from = new MailAddress("hmugen1991@gmail.com");
                    MailAddress to = new MailAddress("jupri@hondamugen.co.id");
                    MailMessage message = new MailMessage(from, to);
                    message.Body = @"<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>e-Mail ini adalah konfirmasi pemberitahuan bahwa ada perbaikan yang baru diajukan sebagai berikut:<br/><br/><div style='margin:0 auto;background: #FFEFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:8pt;'>Diajukan oleh : " + user + "<br/>Masalah : " + masalah + "</div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=deadlinehardsoft.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Lihat Daftar Permintaan</a></center><br></br>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.<br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                    message.IsBodyHtml = true;
                    SmtpClient sc = new SmtpClient();
                    message.Subject = "[HONDA MUGEN] Konfirmasi Perbaikan Hardware & Software";
                    sc.Host = "smtp.gmail.com";
                    sc.Port = 587;
                    sc.EnableSsl = true;
                    sc.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
                    sc.Send(message);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("formhardsoft.aspx");
                }
                else if (cTujuan == "128")
                {
                    MailAddress from = new MailAddress("hmugen1991@gmail.com");
                    MailAddress to = new MailAddress("azis@hondamugen.co.id");
                    MailMessage message = new MailMessage(from, to);
                    message.Body = @"<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>e-Mail ini adalah konfirmasi pemberitahuan bahwa ada perbaikan yang baru diajukan sebagai berikut:<br/><br/><div style='margin:0 auto;background: #FFEFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:8pt;'>Diajukan oleh : " + user + "<br/>Masalah : " + masalah + "</div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=deadlinehardsoft.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Lihat Daftar Permintaan</a></center><br></br>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.<br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                    message.IsBodyHtml = true;
                    SmtpClient sc = new SmtpClient();
                    message.Subject = "[HONDA MUGEN] Konfirmasi Perbaikan Hardware & Software";
                    sc.Host = "smtp.gmail.com";
                    sc.Port = 587;
                    sc.EnableSsl = true;
                    sc.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
                    sc.Send(message);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("formhardsoft.aspx");
                }
            }
            else if (tujuan == "GA")
            {
                if (cTujuan == "112")
                {
                    string bod_email = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>e-Mail ini adalah konfirmasi pemberitahuan bahwa ada perbaikan yang baru diajukan sebagai berikut:<br/><br/><div style='margin:0 auto;background: #FFEFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:8pt;'>Diajukan oleh : " + user + "<br/>Masalah : " + masalah + "</div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=deadlinehardsoft.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Lihat Daftar Permintaan</a></center><br></br>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.<br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                    string kirim_email = FungsiEmail("anangyusuf46@gmail.com, ga_puri@hondamugen.co.id", bod_email);
                    //MailAddress from = new MailAddress("hmugen1991@gmail.com");
                    //MailAddress to = new MailAddress("yusufanang20@gmail.com, tandasanyu.movie1@gmail.com");
                    //MailMessage message = new MailMessage(from, to);
                    //message.Body = @"<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>e-Mail ini adalah konfirmasi pemberitahuan bahwa ada perbaikan yang baru diajukan sebagai berikut:<br/><br/><div style='margin:0 auto;background: #FFEFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:8pt;'>Diajukan oleh : " + user + "<br/>Masalah : " + masalah + "</div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=deadlinehardsoft.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Lihat Daftar Permintaan</a></center><br></br>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.<br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                    //message.IsBodyHtml = true;
                    //SmtpClient sc = new SmtpClient();
                    //message.Subject = "[HONDA MUGEN] Konfirmasi Perbaikan Hardware & Software";
                    //sc.Host = "smtp.gmail.com";
                    //sc.Port = 587;
                    //sc.EnableSsl = true;
                    //sc.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
                    //sc.Send(message);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("formhardsoft.aspx");
                }
                else if (cTujuan == "128")
                {
                    //MailAddress from = new MailAddress("hmugen1991@gmail.com");
                    //MailAddress to = new MailAddress("ga_puri@hondamugen.co.id");
                    //MailMessage message = new MailMessage(from, to);
                    //message.Body = @"<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>e-Mail ini adalah konfirmasi pemberitahuan bahwa ada perbaikan yang baru diajukan sebagai berikut:<br/><br/><div style='margin:0 auto;background: #FFEFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:8pt;'>Diajukan oleh : " + user + "<br/>Masalah : " + masalah + "</div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=deadlinehardsoft.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Lihat Daftar Permintaan</a></center><br></br>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.<br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                    //message.IsBodyHtml = true;
                    //SmtpClient sc = new SmtpClient();
                    //message.Subject = "[HONDA MUGEN] Konfirmasi Perbaikan Hardware & Software";
                    //sc.Host = "smtp.gmail.com";
                    //sc.Port = 587;
                    //sc.EnableSsl = true;
                    //sc.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
                    //sc.Send(message);
                    string bod_email = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>e-Mail ini adalah konfirmasi pemberitahuan bahwa ada perbaikan yang baru diajukan sebagai berikut:<br/><br/><div style='margin:0 auto;background: #FFEFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:8pt;'>Diajukan oleh : " + user + "<br/>Masalah : " + masalah + "</div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=deadlinehardsoft.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Lihat Daftar Permintaan</a></center><br></br>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.<br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                    string kirim_email = FungsiEmail("ga_puri@hondamugen.co.id", bod_email);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("formhardsoft.aspx");
                }
            }
            else if (tujuan == "IT & GA")
            {
                if (cTujuan == "112")
                {
                    //MailAddress from = new MailAddress("hmugen1991@gmail.com");
                    //MailAddress to = new MailAddress("herlambang@hondamugen.co.id, ga@hondamugen.co.id, jupri@hondamugen.co.id");
                    //MailMessage message = new MailMessage(from, to);
                    //message.Body = @"<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>e-Mail ini adalah konfirmasi pemberitahuan bahwa ada perbaikan yang baru diajukan sebagai berikut:<br/><br/><div style='margin:0 auto;background: #FFEFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:8pt;'>Diajukan oleh : " + user + "<br/>Masalah : " + masalah + "</div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=deadlinehardsoft.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Lihat Daftar Permintaan</a></center><br></br>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.<br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                    //message.IsBodyHtml = true;
                    //SmtpClient sc = new SmtpClient();
                    //message.Subject = "[HONDA MUGEN] Konfirmasi Perbaikan Hardware & Software";
                    //sc.Host = "smtp.gmail.com";
                    //sc.Port = 587;
                    //sc.EnableSsl = true;
                    //sc.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
                    //sc.Send(message);
                    string bod_email = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>e-Mail ini adalah konfirmasi pemberitahuan bahwa ada perbaikan yang baru diajukan sebagai berikut:<br/><br/><div style='margin:0 auto;background: #FFEFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:8pt;'>Diajukan oleh : " + user + "<br/>Masalah : " + masalah + "</div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=deadlinehardsoft.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Lihat Daftar Permintaan</a></center><br></br>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.<br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                    string kirim_email = FungsiEmail("herlambang@hondamugen.co.id, ga@hondamugen.co.id, jupri@hondamugen.co.id", bod_email);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("formhardsoft.aspx");
                }
                else if (cTujuan == "128")
                {
                    //MailAddress from = new MailAddress("hmugen1991@gmail.com");
                    //MailAddress to = new MailAddress("stiiawanchen94@gmail.com, ga_puri@hondamugen.co.id, azis@hondamugen.co.id");
                    //MailMessage message = new MailMessage(from, to);
                    //message.Body = @"<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>e-Mail ini adalah konfirmasi pemberitahuan bahwa ada perbaikan yang baru diajukan sebagai berikut:<br/><br/><div style='margin:0 auto;background: #FFEFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:8pt;'>Diajukan oleh : " + user + "<br/>Masalah : " + masalah + "</div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=deadlinehardsoft.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Lihat Daftar Permintaan</a></center><br></br>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.<br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                    //message.IsBodyHtml = true;
                    //SmtpClient sc = new SmtpClient();
                    //message.Subject = "[HONDA MUGEN] Konfirmasi Perbaikan Hardware & Software";
                    //sc.Host = "smtp.gmail.com";
                    //sc.Port = 587;
                    //sc.EnableSsl = true;
                    //sc.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
                    //sc.Send(message);
                    string bod_email = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>e-Mail ini adalah konfirmasi pemberitahuan bahwa ada perbaikan yang baru diajukan sebagai berikut:<br/><br/><div style='margin:0 auto;background: #FFEFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:8pt;'>Diajukan oleh : " + user + "<br/>Masalah : " + masalah + "</div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=deadlinehardsoft.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Lihat Daftar Permintaan</a></center><br></br>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.<br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                    string kirim_email = FungsiEmail("stiiawanchen94@gmail.com, ga_puri@hondamugen.co.id, azis@hondamugen.co.id", bod_email);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("formhardsoft.aspx");
                }
            }
        }

        con.Close();
    }


    protected void drpView_SelectedIndexChanged(object sender, EventArgs e)
    {
    
        Response.Redirect("formhardsoft.aspx?q2=" + drpView.Text + "");
    }
    //fungsi email
    public string FungsiEmail(string e, string pesan)
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
}
