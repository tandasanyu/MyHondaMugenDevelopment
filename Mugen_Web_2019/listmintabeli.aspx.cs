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



public partial class mintabeli : System.Web.UI.Page
{
 
    protected void Page_Load(object sender, EventArgs e)
    {
        string userAkses = (string)(Session["username"]);
        string cs2 = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con2 = new SqlConnection(cs2);
        con2.Open();
        DataSet ds1 = new DataSet();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- NEW DATA'", con2);

        da1.Fill(ds1);
        int count1 = ds1.Tables[0].Rows.Count;
        if (count1 == 0)
        {
            form1.Visible = false;
        }
        else
        {
            form1.Visible = true;
        }
       

        con2.Close();
        if (Session["username"] != null)
        {
            txtUser.Text = "" + Session["username"];
        }

        string uKode = Request.QueryString["id"];
        if (uKode == "")
        {
        }
        else
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("DELETE FROM fmb WHERE idfmb = '" + uKode + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
       
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string user = (string)(Session["username"]);
            command.CommandText = "SELECT SUM(jumlahitem*hargaitem) AS totalharga FROM [fmb] WHERE username = '" + user + "'";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalharga = reader["totalharga"].ToString();
                    if (totalharga == "")
                    {
                        lblTotal.Text = "0";
                    }
                    else
                    {
                        lblTotal.Text = decimal.Parse(totalharga).ToString("0,0,0");
                    }

                }
            }
        }
        
        SqlConnection sconn = new SqlConnection(@"Data Source=192.168.0.88;Password=mugensaya;User ID=sayamugen;Initial Catalog=mugensupport;");
        sconn.Open();

        DataSet ds = new DataSet();
        string userss = (string)(Session["username"]);
        SqlDataAdapter da = new SqlDataAdapter("SELECT namaitem FROM fmb WHERE username = '" + userss + "'", sconn);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            btnSelesai.Visible = false;
        }
        else
        {
            btnSelesai.Visible = true;
        }
        sconn.Close();

    }


    protected void Button1_Click1(object sender, EventArgs e)
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);

        string barang = txtBarang.Text;
        string tujuan = txtTujuan.Text;
        string jumlah = txtJumlah.Text;
        string harga = txtHarga.Text;
        string user = txtUser.Text;
        string pusatBiaya = txtPusat.Text;
        string tujM = DrpTuj.Text;

        SqlCommand cmd = new SqlCommand("INSERT INTO fmb (username, namaitem, tujuanitem, jumlahitem, hargaitem, pusatbiaya, kelompok) VALUES ('" + user + "', '" + barang + "', '" + tujuan + "', '" + jumlah + "', '" + harga + "', '" + pusatBiaya + "', '" + tujM + "')", con);
        con.Open();


        if (barang == "")
        {
            Label12.Text = "Nama Barang harus diisi.";
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal menambah item, Nama barang tidak diisi !');</script>");
        }
        else if (tujuan == "")
        {
            Label12.Text = "Tujuan beli harus diisi.";
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal menambah item, Tujuan pembelian tidak diisi !');</script>");
        }
        else if (jumlah == "")
        {
            Label12.Text = "Jumlah barang harus diisi.";
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal menambah item, Jumlah barang tidak diisi !');</script>");
        }
        else if (jumlah == "0")
        {
            Label12.Text = "Jumlah 0 tidak perlu diisi.";
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal menambah item, Jumlah barang yang anda masukkan 0. Minimal memiliki jumlah 1 barang !');</script>");
        }
        else if (harga == "")
        {
            Label12.Text = "Harga barang harus diisi.";
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal menambah item, Harga tidak diisi. Apabila anda tidak mengetahui harga bisa mengisikan dengan angka 0');</script>");
        }
        else if (user == "")
        {
            Label12.Text = "U Not Have Access Broo..";
        }
        else if (pusatBiaya == "")
        {
            Label12.Text = "Masih kosong pusat biaya nya.. Ayo diisi..";
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal menambah item, Pusat biaya tidak diisi !');</script>");
        }
        else
        {
            cmd.ExecuteNonQuery();
            Label12.Text = "Data berhasil disimpan.";
            Response.Redirect("listmintabeli.aspx");
        }



        con.Close();
    }
    protected void btnSelesai_Click(object sender, EventArgs e)
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection connection = new SqlConnection(cs);
        DataSet ds = new DataSet();
        DateTime blnIni = DateTime.Now;
        string blnRini = blnIni.ToString("MM");
        string thnRini = blnIni.ToString("yyyy");
        string sql = "SELECT nofmbhead FROM fmbhead WHERE DATEPART(month, tglpemohonfmb) = '" + blnRini + "' AND DATEPART(year, tglpemohonfmb) = '" + thnRini + "'";
        DateTime myDate = DateTime.Now;
        string strTime = myDate.ToString("yyyy/INQ/MM-");
        string tglSkrng = myDate.ToString("MM/dd/yyyy hh:mm:ss tt");
        string pemohon = Session["username"].ToString();
        string namaSiapa = txtNama.Text;
        var maxWidth = 5;
        try
        {

            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(ds);
            string nomor = ds.Tables[0].Rows.Count.ToString().PadLeft(maxWidth, '0');

            string nobukti = strTime + ds.Tables[0].Rows.Count.ToString().PadLeft(maxWidth, '0');
            SqlCommand cmd = new SqlCommand("INSERT INTO fmbhead (nofmbhead, pemohonfmb, tglpemohonfmb, rejecthead, userfmb) VALUES('" + nobukti + "', '" + pemohon + "', '" + tglSkrng + "', 'N', '" + namaSiapa + "')", connection);
            SqlCommand cmd2 = new SqlCommand("INSERT INTO fmbbody (namaitem, tujuanitem, jumlahitem, hargaitem, pusatbiaya, reject, vendor, kelompok, nobody) SELECT namaitem, tujuanitem, jumlahitem, hargaitem, pusatbiaya, 'APPROVE', vendor, kelompok, '" + nobukti + "' FROM fmb WHERE username = '" + pemohon + "'", connection);
            SqlCommand cmd3 = new SqlCommand("DELETE FROM fmb WHERE username = '" + pemohon + "'", connection);
            SqlCommand cmd4 = new SqlCommand("INSERT INTO fmblamp (lokasifile, proses, keterangan, username, nohead) SELECT lokasifile, proses, keterangan, username, '" + nobukti + "' FROM templamp WHERE username = '" + pemohon + "'", connection);
            SqlCommand cmd5 = new SqlCommand("DELETE FROM templamp WHERE username = '" + pemohon + "'", connection);

            if (namaSiapa == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Mohon isikan nama yang mengajukan terlebih dahulu !');</script>");
                txtNama.Focus();
            }
            else {
                using (var connection2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
                using (var command2 = connection2.CreateCommand())
                {
                    string user = (string)(Session["username"]);
                    command2.CommandText = "select emaildivisi from fmb INNER JOIN tb_user ON fmb.username = tb_user.username INNER JOIN divisi ON tb_user.kddivisi = divisi.kddivisi WHERE fmb.username = '" + pemohon + "'";
                    connection2.Open();
                    using (var reader2 = command2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            string emaildivisi = reader2["emaildivisi"].ToString();

                            MailAddress from = new MailAddress("hmugen1991@gmail.com");
                            MailAddress to = new MailAddress("" + emaildivisi + ",setiawan-it@hondamugen.co.id");
                            MailMessage message = new MailMessage(from, to);
                            message.Subject = "Terdapat Permintaan Pembelian Baru Membutuhkan Persetujuan Anda";
                            message.Body = @"<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda memiliki sebuah permintaan persetujuan untuk pembuatan sebuah Purchase Order, dengan nomor permintaan: <strong><center>  </center></strong><br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://192.168.0.3:8080/default.aspx?goto=approvemintabeli.aspx?q=approvaldivisi' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Daftar Approval</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                            message.IsBodyHtml = true;
                            SmtpClient sc = new SmtpClient();
                            sc.Host = "smtp.gmail.com";
                            sc.Port = 587;
                            sc.EnableSsl = true;
                            sc.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
                            sc.Send(message);

                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            cmd3.ExecuteNonQuery();
                            cmd4.ExecuteNonQuery();
                            cmd5.ExecuteNonQuery();
                            Response.Redirect("mintabeli.aspx");
                        }
                    }
                    connection2.Close();
                }
            }
            connection.Close();
        }

        catch (Exception ex)
        {
            Label2.Text = "Error in execution " + ex.ToString();
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                string filename = System.IO.Path.GetFileName(FileUpload1.FileName);
                lblStatus.Text = "Upload status: berhasil!";
                string keTerangan = txtKet.Text;
                string user = (string)(Session["username"]);
                string lokasi = "lamp";
                DateTime toDay = DateTime.Now;
                string hariIni = toDay.ToString("MM/dd/yyyy hh:mm:ss tt");
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO templamp (lokasifile, keterangan, username, proses) VALUES ('" + lokasi + "/" + filename + "', '" + keTerangan + "', '" + user + "', '" + user + "" + hariIni + "')", con);
                con.Open();
                if (keTerangan == "")
                {
                    lblStatus.Text = "Keterangan lampiran tolong diisi";
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    FileUpload1.SaveAs(Server.MapPath("~/lamp/") + filename);
                    Response.Redirect("listmintabeli.aspx#lampiran");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }
   
}
