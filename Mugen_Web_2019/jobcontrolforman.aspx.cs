using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Web.Configuration;

public partial class jobcontrolforman : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
       
    }
    protected void GetTime(object sender, EventArgs e)
    {
        GridView6.DataBind();
        GridView2.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string hasil = txtCari.Text;
        Response.Redirect("jobcontrolforman.aspx?q=" + hasil);
    }

    protected void BtnLihatReport_Click(object sender, EventArgs e)
    {
        //cek apakah no wo tsb sudah ada status bernilai 16
        string Status_ = string.Empty;
        Status_ = Fungsi_GetValue("select KERJABODY_STATUS from TEMP_KERJABODY where KERJABODY_NOWO = " + TxtCariReport.Text+ " and KERJABODY_STATUS = 16 ");
        if (Status_ == "16") {
            Response.Redirect("Report_BP.aspx?qnowo=" + TxtCariReport.Text + "&&cabang=112");
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Nomor WO yang Anda Input Belum Mencapai Tahap Akhir QC');</script>");
            //ShowAlertAndNavigate("Nomor WO yang Anda Input Belum Mencapai Tahap Akhir QC", "jobcontrolforman.aspx");
        }
    }
    //FUNGSI UNTUK ALERT GLOBAL
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
    //FUNGSI get single value
    public string Fungsi_GetValue(string SqlCmd)
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        string status_hasil = string.Empty;
        String strconn = WebConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql = string.Empty;
        sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);


        try
        {
            conn.Open();
            reader = cmd.ExecuteReader(); //Menggunakan data reader untuk select dan mengambil value nya 
            while (reader.Read())
            {
                status_hasil = reader.GetValue(0).ToString();


            }
            //status_hasil = "1";
            return status_hasil;
        }
        catch (SqlException ex)
        {
            status_hasil = "Terjadi error Ketika Mengambil Data: " + ex.Message;
            return status_hasil;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }

    }
}