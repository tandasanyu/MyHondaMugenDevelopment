using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HalamanChat : System.Web.UI.Page
{
    public string userak_ = string.Empty;
    public string noWo = string.Empty;
    public string cab = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {


        userak_ = Request.QueryString["USERNAME"];  //(string)(Session["username"]);
        noWo = Request.QueryString["NOWO"]; //(string)(Session["noWo"]);
        cab = Request.QueryString["CAB"];
        if (userak_ == string.Empty || userak_ == null) {
            ShowAlert("default.aspx");
        } else {
            Label1.Text = "User: " + userak_ + "<br/> Nomor Wo : " + noWo;
        }
        DataTable ds = new DataTable();
        DataTable ds_2 = new DataTable();
        // CEK 112 ATAU 128
        if (cab == "112") {
            ds = PullData112("select * from DATA_HISTORY_CHAT where NOWO_CHAT = " + noWo + " and ID_CHAT > 0 order by ID_CHAT ASC");
            LvChat.DataSource = ds;
            LvChat.DataBind();
            //untuk bind data ke dropdownlist
            ds_2 = PullData112_("select ID_CHAT from DATA_HISTORY_CHAT where NOWO_CHAT = "+noWo+ " order by ID_CHAT ASC");
            DropDownListID.DataSource =ds_2;
            DropDownListID.DataBind(); DropDownListID.DataTextField = "ID_CHAT";
            DropDownListID.DataValueField = "ID_CHAT";
                DropDownListID.DataBind();
            DropDownListID.Items.Insert(0, new ListItem("Pilih ID", "0"));
        }
        else {
            ds = PullData("select * from DATA_HISTORY_CHAT where NOWO_CHAT = " + noWo + " and ID_CHAT > 0 order by ID_CHAT ASC");
            LvChat.DataSource = ds;
            LvChat.DataBind();
            //untuk bind data ke dropdownlist
            ds_2 = PullData_("select ID_CHAT from DATA_HISTORY_CHAT where NOWO_CHAT = " + noWo + " order by ID_CHAT ASC");
            DropDownListID.DataSource = ds_2;
            DropDownListID.DataTextField = "ID_CHAT";
            DropDownListID.DataValueField = "ID_CHAT";
                DropDownListID.DataBind();
            DropDownListID.Items.Insert(0, new ListItem("Pilih ID", "0"));
        }
    }
    public void ShowAlertAndNavigate(string msg, string destination)
    {
        string message = msg;
        string url = destination;
        string script = "window.onload = function(){ alert('";
        script += message;
        script += "');";
        script += "window.location = '";
        script += url;
        script += "'; }";
        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
    }
    public void ShowAlert(string destination)
    {
        string url = destination;
        Response.Write("<script language='javascript'>window.location.assign('" + destination + "');</script>");
    }
    //btn simpan chat
    protected void BtnSimpan_Click(object sender, EventArgs e)
    {
        string user_ = string.Empty;
        string nowo = string.Empty;
        string id = string.Empty;
        id = TextBoxID.Text;
        int jenis_chat;
        if (id != string.Empty) {
            id = TextBoxID.Text;
            jenis_chat = Convert.ToInt32(id);
        }
        else
        {
            id = string.Empty;
            jenis_chat = 0;
        }
        
        string isi_ = string.Empty;
        isi_ = Request.Form["TxtIsiChat"];
        if (user_ != null && nowo != null  && isi_ != string.Empty) {
            
            user_ = userak_;
            nowo = noWo;
            
            string sql = "insert into DATA_HISTORY_CHAT (USER_CHAT, ISI_CHAT, TGL_CHAT, NOWO_CHAT, PROSES_CHAT, JENIS_CHAT) values ('"+user_+"','"+isi_+"',GETDATE(),'"+nowo+"','test',"+jenis_chat+")";
            string hasil = string.Empty;
            if (cab == "112")
            {
                hasil = KelasKoneksi_CUD112(sql);
            }
            else {
                hasil = KelasKoneksi_CUD(sql);
            }
            if (hasil == "1") {
                //EmailStaff_spesial("Test Group Email", cab);
                if (cab == "112") {
                    ShowAlert("HalamanChat.aspx?USERNAME="+userak_+"&&NOWO="+noWo+"&&CAB="+cab+"");
                } else {
                    ShowAlert("HalamanChat.aspx?USERNAME=" + userak_ + "&&NOWO=" + noWo + "&&CAB=" + cab + "");
                }               
            }
            else {
                if (cab == "112") {
                    ShowAlertAndNavigate("Terjadi Kesalahan : " + hasil + "", "jobcontrolforman.aspx");
                } else {
                    ShowAlertAndNavigate("Terjadi Kesalahan : " + hasil + "", "jobcontrolformanpuri.aspx");
                }               
            }
        } else {
            if (cab == "112") {
                ShowAlertAndNavigate("Harap Cek Kembali, masih ada Pilihan yang Anda Kosongkan!", "jobcontrolforman.aspx");
            } else {
                ShowAlertAndNavigate("Harap Cek Kembali, masih ada Pilihan yang Anda Kosongkan!", "jobcontrolformanpuri.aspx");
            }        
        }
    }
    //*** KUMPULAN FUNGSI FUNGSI
    //fungsi untuk insert
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataReader reader;
    public string status_hasil;
    public string KelasKoneksi_CUD(string SqlCmd)
    {

        String strconn = WebConfigurationManager.ConnectionStrings["service128Connection"].ConnectionString;
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
            status_hasil = "Terjadi error Ketika Proses: " + sqlEx.Message;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }


        return status_hasil;
    }
    public string KelasKoneksi_CUD112(string SqlCmd)
    {

        String strconn = WebConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
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
            status_hasil = "Terjadi error Ketika Proses: " + sqlEx.Message;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }


        return status_hasil;
    }
    // fungsi get data 
    //fungsi pull data to datatable
    public DataTable PullData(string sql)
    {
        DataTable ds = new DataTable();
        String strconn = WebConfigurationManager.ConnectionStrings["service128Connection"].ConnectionString;
        conn = new SqlConnection(strconn);
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        try
        {
            conn.Open();
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            ds = null;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
            da.Dispose();
        }

        return ds;
    }
    public DataTable PullData_(string sql)
    {
        DataTable ds = new DataTable();
        String strconn = WebConfigurationManager.ConnectionStrings["service128Connection"].ConnectionString;
        conn = new SqlConnection(strconn);
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        try
        {
            conn.Open();
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            ds = null;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
            da.Dispose();
        }

        return ds;
    }
    public DataTable PullData112(string sql)
    {
        DataTable ds = new DataTable();
        String strconn = WebConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        try
        {
            conn.Open();
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            ds = null;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
            da.Dispose();
        }

        return ds;
    }
    public DataTable PullData112_(string sql)
    {
        DataTable ds = new DataTable();
        String strconn = WebConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        try
        {
            conn.Open();
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            ds = null;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
            da.Dispose();
        }

        return ds;
    }
    public bool EmailStaff_spesial(string pesan, string cabang)
    {
        string penerima112 = "budiarthe@gmail.com,muchlishidayat02@gmail.com";
        string penerima128= "081297686377rb@gmail.com,regiansyah.nozle@gmail.com";
        string penerima = string.Empty;

        if (cabang == "112") {
            penerima = penerima112;
        }
        else
        {
            penerima = penerima128;
        }
      
        //kirim email
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

        MailMessage mailMessage = new MailMessage("hmugen1991@gmail.com", penerima);
        mailMessage.Subject = "Body Repair Notification";
        mailMessage.Body = pesan;
        mailMessage.IsBodyHtml = true;
        try
        {
            smtpClient.Send(mailMessage);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}