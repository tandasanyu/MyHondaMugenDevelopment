﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class jobcontrolformanedt : System.Web.UI.Page
{
    public string noWo;
    protected void Page_Load(object sender, EventArgs e)
    {
         noWo = Request.QueryString["qnowo"];
        Image1.ImageUrl = "lamp/" + noWo + ".jpg";
        string userAkses = (string)(Session["username"]);
        if (userAkses == "LINDA" || userAkses == "BUDI")
        {
            string hasil = Fungsi_GetValue("select KERJABODY_STATUS from TEMP_KERJABODY where KERJABODY_STATUS = 16 and KERJABODY_NOWO = "+noWo+"");
            string.IsNullOrEmpty(hasil);
            if (hasil == null || hasil == string.Empty ) {
                BtnReportBPPsm.Visible = false;
            } else {
                BtnReportBPPsm.Visible = true;
            }
            
        }
        else
        {
            BtnReportBPPsm.Visible = false;
        }
        string css = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con2 = new SqlConnection(css);
        con2.Open();
        DataSet dss6 = new DataSet();
        SqlDataAdapter daa6 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM JOB CONTROL FORMAN -- VIEW MENU'", con2);

        daa6.Fill(dss6);
        int count6 = dss6.Tables[0].Rows.Count;
        if (count6 == 0)
        {
            Form.Visible = false;
        }
        else
        {
            Form.Visible = true;
        }
        DataSet dss7 = new DataSet();
        SqlDataAdapter daa7 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM JOB CONTROL FOREMAN -- ADD HISTORY'", con2);

        daa7.Fill(dss7);
        int count7 = dss7.Tables[0].Rows.Count;
        if (count7 == 0)
        {
            addHistory.Visible = false;
        }
        else
        {
            addHistory.Visible = true;
        }
        DataSet dss8 = new DataSet();
        SqlDataAdapter daa8 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM JOB CONTROL FOREMAN -- DELETE HISTORY'", con2);

        daa8.Fill(dss8);
        int count8 = dss8.Tables[0].Rows.Count;
        if (count8 == 0)
        {
            lblPesanGagal.Visible = true;
            lblPesanBisa.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
        }
        else
        {
            lblPesanGagal.Visible = false;
            lblPesanBisa.Visible = true;
            Button2.Visible = true;
            Button2.Visible = true;
        }
        DataSet dss10 = new DataSet();
        SqlDataAdapter daa10 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM JOB CONTROL FOREMAN -- UNCLOSING'", con2);

        daa10.Fill(dss10);
        int count10 = dss10.Tables[0].Rows.Count;
        if (count10 == 0)
        {
            btnUnclosing.Visible = false;
        }
        else
        {
            btnUnclosing.Visible = true;
        }
        con2.Close();

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        DataSet ds2 = new DataSet();

        SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + noWo + "' AND CONTROLBR_TGLSELESAIA IS NULL", con);
        da2.Fill(ds2);
        int count2 = ds2.Tables[0].Rows.Count;
        if (count2 == 0)
        {
            inputHistory.Visible = false;
            btnUnclosing.Visible = true;
        }
        else
        {
            inputHistory.Visible = true;
            btnUnclosing.Visible = false;
        }
        //cek jika status sudah ada 16 maka tombol report muncul / sebaliknya jika belum

        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string noWoDel = Request.QueryString["qnowodel"];
        string tglWoDel = Request.QueryString["qtgldel"];
        string user = (string)(Session["username"]);
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("DELETE FROM TEMP_KERJABODY WHERE KERJABODY_NOWO = '" + noWoDel + "' AND KERJABODY_TANGGAL = '" + tglWoDel + "'", con);
        con.Open();
        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + noWoDel + "' AND CONTROLBR_TGLSELESAIA IS NULL", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman !');</script>");
        }
        else
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + noWoDel);
        }
        con.Close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string noWo = Request.QueryString["qnowodel"];
        Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + noWo);
    }
    protected void btnProses_Click(object sender, EventArgs e)
    {
        string userAkses = (string)(Session["username"]);
        if (userAkses == "MUCHLIS")
        {
            if (txtStatus.Text == "10" || txtStatus.Text == "11" || txtStatus.Text == "12" || txtStatus.Text == "13" || txtStatus.Text == "15" || txtStatus.Text == "14" || txtStatus.Text == "17" || txtStatus.Text == "18")
            {

                try
                {
                    string filename = System.IO.Path.GetFileName(txtFoto.FileName);
                    string catatanBp = txtCatatan.Text;
                    string lokasiBp = txtLokasi.Text;
                    string statusBp = txtStatus.Text;
                    string woBp = Request.QueryString["qnowo"];
                    string user = (string)(Session["username"]);
                    DateTime toDay = DateTime.Now;
                    string hariIni = toDay.ToString("MM/dd/yyyy hh:mm:ss");

                    string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI) VALUES ('" + woBp + "', '" + hariIni + "', '" + user + "', '" + statusBp + "', '" + catatanBp + "', '" + lokasiBp + "')", con);
                    SqlCommand cmd2 = new SqlCommand("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '" + statusBp + "' WHERE CONTROLBR_NOWO = '" + woBp + "'", con);
                    con.Open();
                    if (catatanBp == "")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Catatan anda belum diisi.');</script>");
                    }
                    else if (lokasiBp == "")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Lokasi Mobil belum anda isi.');</script>");
                    }
                    else if (statusBp == "")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Pilih status pengerjaan anda terlebih dahulu.');</script>");
                    }
                    else
                    {

                        DataSet ds2 = new DataSet();

                        SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + woBp + "' AND CONTROLBR_TGLSELESAIA IS NULL", con);
                        da2.Fill(ds2);
                        int count2 = ds2.Tables[0].Rows.Count;
                        if (count2 == 0)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman !');</script>");
                        }
                        else
                        {
                            txtFoto.SaveAs(Server.MapPath("~/lamp/") + woBp + ".jpg");
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + woBp);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    btnProses.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Status yang Anda Pilih Tidak Bisa di Proses. !');</script>");

            }
        }
        else if (userAkses == "BUDI")
        {
            if (txtStatus.Text == "01" || txtStatus.Text == "02" || txtStatus.Text == "03" || txtStatus.Text == "04" || txtStatus.Text == "05" || txtStatus.Text == "06" || txtStatus.Text == "07" || txtStatus.Text == "08" || txtStatus.Text == "09" || txtStatus.Text == "16")
            {

                try
                {
                    string filename = System.IO.Path.GetFileName(txtFoto.FileName);
                    string catatanBp = txtCatatan.Text;
                    string lokasiBp = txtLokasi.Text;
                    string statusBp = txtStatus.Text;
                    string woBp = Request.QueryString["qnowo"];
                    string user = (string)(Session["username"]);
                    DateTime toDay = DateTime.Now;
                    string hariIni = toDay.ToString("MM/dd/yyyy hh:mm:ss");

                    string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI) VALUES ('" + woBp + "', '" + hariIni + "', '" + user + "', '" + statusBp + "', '" + catatanBp + "', '" + lokasiBp + "')", con);
                    SqlCommand cmd2 = new SqlCommand("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '" + statusBp + "' WHERE CONTROLBR_NOWO = '" + woBp + "'", con);
                    con.Open();
                    if (catatanBp == "")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Catatan anda belum diisi.');</script>");
                    }
                    else if (lokasiBp == "")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Lokasi Mobil belum anda isi.');</script>");
                    }
                    else if (statusBp == "")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Pilih status pengerjaan anda terlebih dahulu.');</script>");
                    }
                    else
                    {

                        DataSet ds2 = new DataSet();

                        SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + woBp + "' AND CONTROLBR_TGLSELESAIA IS NULL", con);
                        da2.Fill(ds2);
                        int count2 = ds2.Tables[0].Rows.Count;
                        if (count2 == 0)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman !');</script>");
                        }
                        else
                        {
                            txtFoto.SaveAs(Server.MapPath("~/lamp/") + woBp + ".jpg");
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + woBp);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    btnProses.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Status yang Anda Pilih Tidak Bisa di Proses. !');</script>");

            }
        }



    }

    protected void btnUnclosing_Click(object sender, EventArgs e)
    {
        string noWounClosing = Request.QueryString["qnowo"];
        string userunClosing = (string)(Session["username"]);
        DateTime toDay = DateTime.Now;
        string tglunClosing = toDay.ToString("MM/dd/yyyy hh:mm:ss tt");
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI) VALUES ('" + noWounClosing + "', '" + tglunClosing + "', '" + userunClosing + "', '0', 'This unclosing note is automatically by system', '')", con);
        SqlCommand cmd2 = new SqlCommand("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '0', CONTROLBR_TGLSELESAIA = null WHERE CONTROLBR_NOWO = '" + noWounClosing + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TEMP_CONTROLBR WHERE CONTROLBR_TGLSELESAIA IS NOT NULL AND CONTROLBR_NOWO = '" + noWounClosing + "'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa di unClosing karena data ini tidak dalam status Closing !');</script>");
        }
        else
        {
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + noWounClosing);
        }
        con.Close();
    }

    protected void BtnReportBPPsm_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report_BP.aspx?qnowo=" + noWo + "&cabang=112");
    }
    //FUNGSI KONEKSI HERLAMBANG
    public string Fungsi_GetValue(string SqlCmd)
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        string status_hasil = string.Empty;
        String strconn = WebConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql =string.Empty;
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