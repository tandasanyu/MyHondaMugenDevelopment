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
using System.Net.Mail;

public partial class jobcontrolformanedt : System.Web.UI.Page
{
    public string noWo;
    public string userAkses;
    protected void Page_Load(object sender, EventArgs e)
    {
        ListViewHistoryPengerjaan.DataBind();
         noWo = Request.QueryString["qnowo"];
        Image1.ImageUrl = "lamp/" + noWo + ".jpg";
        userAkses = (string)(Session["username"]);
        if (userAkses == "LINDA" || userAkses == "MUCHLIS")
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
            if (txtStatus.Text == "10" || txtStatus.Text == "11" || txtStatus.Text == "12" || txtStatus.Text == "13" || txtStatus.Text == "15" || txtStatus.Text == "16" )
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

                    //validasi
                    string status_hasil = Fungsi_CekStatus(woBp);
                    if (status_hasil == "10up")
                    {
                        //bisa langsung 11 - 14
                        if (txtStatus.Text == "10"||txtStatus.Text == "11" || txtStatus.Text == "12" || txtStatus.Text == "13" || txtStatus.Text == "15" || txtStatus.Text == "16")
                        {
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
                                    bool status = EmailStaff(Convert.ToInt32(txtStatus.Text));
                                    if (status == true)
                                    {
                                        ShowAlertAndNavigate("Berhasil Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                                    }
                                    else {
                                        ShowAlertAndNavigate("Gagal Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                                    }
                                    //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + woBp);
                                }
                            }
                            con.Close();
                        }
                        else
                        {
                            //status yang anda pilih tidak dapat di input karena proses sudah melewati tahap finishing.
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('status yang anda pilih tidak dapat di input karena proses sudah melewati tahap finishing');</script>");
                        }
                    }
                    else if (status_hasil == "10dw") {
                        // bisa isi di bawah 10
                        if (txtStatus.Text == "10")
                        {
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
                                    //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + woBp);
                                    bool status = EmailStaff(Convert.ToInt32(txtStatus.Text));
                                    if (status == true)
                                    {
                                        ShowAlertAndNavigate("Berhasil Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                                    }
                                    else
                                    {
                                        ShowAlertAndNavigate("Gagal Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                                    }
                                }
                            }
                            con.Close();
                        }
                        else {
                            //status yang anda pilih tidak dapat di input karena belum melewati tahap finishing.
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('status yang anda pilih tidak dapat di input karena belum melewati tahap finishing.');</script>");
                        }
                    } else if (status_hasil == "Empty")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Proses yang anda pilih tidak dapat di input karena belum ada proses apapun yang berjalan sebelumnya.');</script>");
                    }
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
            if ( txtStatus.Text == "02" || txtStatus.Text == "03" || txtStatus.Text == "04" || txtStatus.Text == "05" || txtStatus.Text == "06" || txtStatus.Text == "07" || txtStatus.Text == "08" || txtStatus.Text == "09" || txtStatus.Text == "14")
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

                    //validasi
                    string status_hasil = Fungsi_CekStatus(woBp);
                    if (status_hasil == "10up")
                    {
                        if (txtStatus.Text == "14") {
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
                                    //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + woBp);
                                    bool status = EmailStaff(Convert.ToInt32(txtStatus.Text));
                                    if (status == true)
                                    {
                                        ShowAlertAndNavigate("Berhasil Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                                    }
                                    else
                                    {
                                        ShowAlertAndNavigate("Gagal Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                                    }
                                }
                            }
                            con.Close();
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Status yang Anda Pilih Tidak Bisa di Proses. Karena WO sudah masuk / melewati tahap finishing !');</script>");
                        }
                    }
                    else if (status_hasil == "10dw")
                    {
                        if (txtStatus.Text == "02" || txtStatus.Text == "03" || txtStatus.Text == "04" || txtStatus.Text == "05" || txtStatus.Text == "06" || txtStatus.Text == "07" || txtStatus.Text == "08" || txtStatus.Text == "09")
                        {
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
                                    //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + woBp);
                                    bool status = EmailStaff(Convert.ToInt32(txtStatus.Text));
                                    if (status == true)
                                    {
                                        ShowAlertAndNavigate("Berhasil Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                                    }
                                    else
                                    {
                                        ShowAlertAndNavigate("Gagal Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                                    }
                                }
                            }
                            con.Close();
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Status yang Anda Pilih Tidak Bisa di Proses. WO tersebut belum mencapai tahap finishing !');</script>");
                        }
                    }
                    else if (status_hasil == "Empty")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Proses yang anda pilih tidak dapat di input karena belum ada proses apapun yang berjalan sebelumnya.');</script>");
                    }
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
        }// else untuk seluruh sa  psm
        else
        {
            if (txtStatus.Text == "01")
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
                            //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + woBp);
                            bool status = EmailStaff(Convert.ToInt32(txtStatus.Text));
                            if (status == true)
                            {
                                ShowAlertAndNavigate("Berhasil Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                            }
                            else
                            {
                                ShowAlertAndNavigate("Gagal Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                            }
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    btnProses.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else {
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
        Response.Redirect("Report_BP.aspx?qnowo=" + noWo + "&&cabang=112");
        //Response.Redirect("ReportBP_Master.aspx?qnowo=" + noWo + "&&cabang=128");
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
    //FUNGSI GET MULTIPLE VALUE 
    public List<string> Fungsi_gettop2(string SqlCmd, string sub) {
        List<String> GlobalAr = new List<String>();
        string status = string.Empty;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;

        String strconn = WebConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);

        GlobalAr.Clear();
        try
        {
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (sub == "1")
                {
                    GlobalAr.Add(reader["kerjabody_status"].ToString()); //0
                }
            }
        }
        catch (SqlException ex)
        {
            status = "Terjadi error Ketika Select: " + ex.Message;
            GlobalAr.Clear();
            GlobalAr.Add(status);
            // return ArrayLogin;

        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }

        return GlobalAr;
}
    //FUNGSI CUD
    //fungsi untuk update
    public string KelasKoneksi_CUD(string SqlCmd)
    {
        string status;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        String strconn = WebConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);
        try
        {
            conn.Open();
            //cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            status = "1";
        }
        catch (SqlException sqlEx)
        {
            status = "Terjadi error : " + sqlEx.Message;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }
        return status;
    }
    //FUNGSI CEK APAKAH ADA STATUS 10
    public string Fungsi_CekStatus(string wo)
    {
        string hasil_akhir = string.Empty;

        string hasil = Fungsi_GetValue("select max(kerjabody_status) from temp_kerjabody where kerjabody_nowo = '" + wo + "'");
        string.IsNullOrEmpty(hasil);
        if (hasil == null || hasil == string.Empty)
        {
            hasil_akhir = "Empty";
        }
        else
        {
            if (Convert.ToInt32(hasil) >= 9)
            {
                hasil_akhir = "10up";
            }
            else if (Convert.ToInt32(hasil) < 10)
            {
                hasil_akhir = "10dw";
            }
        }

        return hasil_akhir;
    }
    //NEW CODE FOR DELETE METHOD
    //list string ID Lowongan
    private List<int> ID_bar
    {
        get
        {
            if (this.ViewState["ID_bar"] == null)
            {
                this.ViewState["ID_bar"] = new List<int>();
            }
            return (List<int>)this.ViewState["ID_bar"];
        }
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        //string koneksi
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        //get listview item chk
        foreach (ListViewDataItem item in ListViewHistoryPengerjaan.Items)
        {
            CheckBox chkSelect = (CheckBox)item.FindControl("chkbar");
            if (chkSelect != null)
            {
                int ID = Convert.ToInt32(chkSelect.Attributes["value"]);
                if (chkSelect.Checked && !this.ID_bar.Contains(ID))
                {
                    this.ID_bar.Add(ID);
                }
                else if (!chkSelect.Checked && this.ID_bar.Contains(ID))
                {
                    this.ID_bar.Remove(ID);
                }
            }
        }
        /*Validasi Sebelum Delete
        ada 2 test case : 
            a.jika status 01, ketika delete maka update ke ketok menjadi null
            b.jika status di atas 01 ketika delete maka update ke ketok menjadi satus satu tingkat di bawahnya (select max)
        Validasi Sebelum Delete*/
        //get value status terakhir dengan wo tsb
        string status_kerja = string.Empty;
        string sql = "SELECT CONTROLBR_KETOKNILAI FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + noWo + "'";
        status_kerja = Fungsi_GetValue(sql);
        if (status_kerja != string.Empty || status_kerja != null)
        {
            //ketika data statuskerja tidak kosong, maka simpan ke variabel
            string status_ketok = status_kerja;
            int var1 = Convert.ToInt32(status_ketok) - 1;
            int var2 = var1;
            //PROSES DELETE
            //cek apakah yg delete adalah user yg input status terakhir
            string sql_userakhir = "select KERJABODY_USER from temp_kerjabody WHERE KERJABODY_NOWO = " + noWo + " and KERJABODY_STATUS = (select MAX(KERJABODY_STATUS)from TEMP_KERJABODY where KERJABODY_NOWO = " + noWo + ")";
            string userakhir = Fungsi_GetValue(sql_userakhir);
            if (userAkses == userakhir || userAkses == "MUCHLIS" || userAkses == "BUDI")
            {
                if (ID_bar.Count > 1)
                {
                    // 
                    ID_bar.Clear();
                    string err_kelebihan = "maaf anda hanya bisa memilih satu status untuk di delete dalam satu waktu";
                    Response.Write("<script language='javascript'>window.alert('Error : " + err_kelebihan + "');window.location='../jobcontrolformanedt.aspx?qnowo=" + noWo + "';</script>");
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('maaf anda hanya bisa memilih satu status untuk di delete dalam satu waktu');</script>");

                    //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + noWo);
                }
                else if (ID_bar.Count == 1)
                {
                    //begin delete
                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("DELETE FROM TEMP_KERJABODY WHERE KERJABODY_NOWO = '" + noWo + "' AND IDkrj_body = " + ID_bar[0] + "", con);
                    con.Open();

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + noWo + "' AND CONTROLBR_TGLSELESAIA IS NULL", con);
                    da.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;
                    if (count == 0)
                    {
                        Response.Write("<script language='javascript'>window.alert('Error : Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman');window.location='../jobcontrolformanedt.aspx?qnowo=" + noWo + "';</script>");
                        //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman !');</script>");
                    }
                    else
                    {
                        //cmd.ExecuteNonQuery();
                        //delete 
                        string sql_delete = "DELETE FROM TEMP_KERJABODY WHERE KERJABODY_NOWO = '" + noWo + "' AND IDkrj_body = " + ID_bar[0] + "";
                        string hasildelete = string.Empty;
                        hasildelete =  KelasKoneksi_CUD(sql_delete);
                        if (hasildelete == "1")
                        {
                            //get status terakhir dari tabel status ketok
                            string sql_statusakhir = "select KERJABODY_STATUS from temp_kerjabody WHERE KERJABODY_NOWO = " + noWo + " and KERJABODY_STATUS = (select MAX(KERJABODY_STATUS)from TEMP_KERJABODY where KERJABODY_NOWO = " + noWo + ")";
                            string statusakhir = string.Empty;
                            statusakhir = Fungsi_GetValue(sql_statusakhir);
                            //update status ketok ke status sebelum terakhir / null
                            if (statusakhir == string.Empty || statusakhir == null)
                            {
                                // gagal update status ketok karena status ketok sudah kosong
                                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('maaf anda hanya bisa memilih satu status untuk di delete dalam satu waktu');</script>");
                                //update ke null
                                string hasil = KelasKoneksi_CUD("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = null WHERE CONTROLBR_NOWO = " + noWo + "");
                                if (hasil == "1")
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Berhasil Delete Status Pekerjaan BP');</script>");
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Berhasil Delete Status Pekerjaan BP dan Gagal Update Status Ketok Akhir BP dengan error: " + hasil + "');</script>");
                                }
                            }
                            else
                            {
                                //get top 2 value 
                                List<string> hasil_top2;
                                /*select top(2) kerjabody_status  from TEMP_KERJABODY where KERJABODY_NOWO = '476898' order by IDkrj_body desc*/
                                // cek record apakah lebih dari 1
                                string jmlrecord = Fungsi_GetValue("select count(kerjabody_status)  from TEMP_KERJABODY where KERJABODY_NOWO = '" + noWo + "'");
                                if (Convert.ToInt32(jmlrecord) > 1)
                                {
                                    string sql_top2 = "select top(1) kerjabody_status  from TEMP_KERJABODY where KERJABODY_NOWO = '" + noWo + "' order by IDkrj_body desc";
                                    hasil_top2 = Fungsi_gettop2(sql_top2, "1");
                                    /*hasil_top2.RemoveAt(0)*/
                                    ;
                                    string hasil = KelasKoneksi_CUD("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = " + hasil_top2[0] + " WHERE CONTROLBR_NOWO = " + noWo + "");
                                    if (hasil == "1")
                                    {
                                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Berhasil Delete Status Pekerjaan BP');</script>");
                                    }
                                    else
                                    {
                                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Berhasil Delete Status Pekerjaan BP dan Gagal Update Status Ketok Akhir BP dengan error: " + hasil + "');</script>");
                                    }
                                }
                                else if (Convert.ToInt32(jmlrecord) == 1)
                                {
                                    string sql_top2 = "select top(1) kerjabody_status  from TEMP_KERJABODY where KERJABODY_NOWO = '" + noWo + "' order by IDkrj_body desc";
                                    hasil_top2 = Fungsi_gettop2(sql_top2, "1");
                                    string hasil = KelasKoneksi_CUD("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = " + hasil_top2[0] + " WHERE CONTROLBR_NOWO = " + noWo + "");
                                    if (hasil == "1")
                                    {
                                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Berhasil Delete Status Pekerjaan BP');</script>");
                                    }
                                    else
                                    {
                                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Berhasil Delete Status Pekerjaan BP dan Gagal Update Status Ketok Akhir BP dengan error: " + hasil + "');</script>");
                                    }
                                }
                            }
                        }
                        else
                        {
                            // delete gagal. error : 
                            Response.Write("<script language='javascript'>window.alert('Delete gagal dengan error : "+hasildelete+"');</script>");
                            // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Proses Delete Gagal, dengan error : " + hasildelete + "');</script>");
                        }
                    }
                    con.Close();
                    //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + noWo);
                }
                else
                {
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data Kosong, Proses Delete Gagal');</script>");
                    Response.Write("<script language='javascript'>window.alert('Error : Data kosong, proses delete gagal');</script>");
                    //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + noWo);
                }
            }
            else
            {
                string pesan = "anda tidak bisa menghapus status ini, karena bukan anda yang melakukan input status ini!";
                Response.Write("<script language='javascript'>window.alert('Error : "+pesan+"');</script>");
                //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + noWo);
            }
        }
    }
    //listview delete
    protected void ListViewHistoryPengerjaan_SelectedIndexChanged(object sender, EventArgs e)
    {
        string pesan_global = string.Empty;
        string id = ListViewHistoryPengerjaan.SelectedDataKey.Value.ToString();
        int id_ = Convert.ToInt32(id);
        //Response.Write("<script language='javascript'>window.alert('Error : " + id + "');</script>");
        //string koneksi
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        /*Validasi Sebelum Delete
        ada 2 test case : 
            a.jika status 01, ketika delete maka update ke ketok menjadi null
            b.jika status di atas 01 ketika delete maka update ke ketok menjadi satus satu tingkat di bawahnya (select max)
        Validasi Sebelum Delete*/
        //get value status terakhir dengan wo tsb
        string status_kerja = string.Empty;
        string sql = "SELECT CONTROLBR_KETOKNILAI FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + noWo + "'";
        status_kerja = Fungsi_GetValue(sql);
        if (status_kerja != string.Empty || status_kerja != null)
        {
            //ketika data statuskerja tidak kosong, maka simpan ke variabel
            string status_ketok = status_kerja;
            int var1 = Convert.ToInt32(status_ketok) - 1;
            int var2 = var1;
            //PROSES DELETE
            //cek apakah yg delete adalah user yg input status terakhir
            string sql_userakhir = "select KERJABODY_USER from temp_kerjabody WHERE KERJABODY_NOWO = " + noWo + " and KERJABODY_STATUS = (select MAX(KERJABODY_STATUS)from TEMP_KERJABODY where KERJABODY_NOWO = " + noWo + ")";
            string userakhir = Fungsi_GetValue(sql_userakhir);
            if (userAkses == userakhir || userAkses == "MUCHLIS")
            {
                //begin delete
                SqlConnection con = new SqlConnection(cs);
                //SqlCommand cmd = new SqlCommand("DELETE FROM TEMP_KERJABODY WHERE KERJABODY_NOWO = '" + noWo + "' AND IDkrj_body = " + ID_bar[0] + "", con);
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + noWo + "' AND CONTROLBR_TGLSELESAIA IS NULL", con);
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count == 0)
                {
                    //Response.Write("<script language='javascript'>window.alert('Error : Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman');window.location='../jobcontrolformanedt.aspx?qnowo=" + noWo + "';</script>");
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman !');</script>");
                    pesan_global = "Error : Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman";
                }
                else
                {
                    //cmd.ExecuteNonQuery();
                    //cek jml record jika 1 tidak bisa delete
                    string cek_jmlstatus = Fungsi_GetValue("select count(kerjabody_status)  from TEMP_KERJABODY where KERJABODY_NOWO = '" + noWo + "'");
                    if (Convert.ToInt32(cek_jmlstatus) <2 ) {
                        pesan_global = "Anda Tidak Bisa melakukan proses delete, karena status tidak bisa kosong!";
                    } else if (Convert.ToInt32(cek_jmlstatus) >1) {
                        //delete 
                        string sql_delete = "DELETE FROM TEMP_KERJABODY WHERE KERJABODY_NOWO = '" + noWo + "' AND IDkrj_body = " + id_ + "";
                        string hasildelete = string.Empty;
                        hasildelete = KelasKoneksi_CUD(sql_delete);
                        if (hasildelete == "1")
                        {
                            //get status terakhir dari tabel status ketok
                            string sql_statusakhir = "select KERJABODY_STATUS from temp_kerjabody WHERE KERJABODY_NOWO = " + noWo + " and KERJABODY_STATUS = (select MAX(KERJABODY_STATUS)from TEMP_KERJABODY where KERJABODY_NOWO = " + noWo + ")";
                            string statusakhir = string.Empty;
                            statusakhir = Fungsi_GetValue(sql_statusakhir);
                            //update status ketok ke status sebelum terakhir / null
                            if (statusakhir == string.Empty || statusakhir == null)
                            {
                                // gagal update status ketok karena status ketok sudah kosong
                                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('maaf anda hanya bisa memilih satu status untuk di delete dalam satu waktu');</script>");
                                //update ke null
                                string hasil = KelasKoneksi_CUD("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = null WHERE CONTROLBR_NOWO = " + noWo + "");
                                if (hasil == "1")
                                {
                                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Berhasil Delete Status Pekerjaan BP');</script>");
                                    pesan_global = "Berhasil Delete Status Pekerjaan BP";
                                }
                                else
                                {
                                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Berhasil Delete Status Pekerjaan BP dan Gagal Update Status Ketok Akhir BP dengan error: " + hasil + "');</script>");
                                    pesan_global = "Berhasil Delete Status Pekerjaan BP dan Gagal Update Status Ketok Akhir BP dengan error: " + hasil + "";
                                }
                            }
                            else
                            {
                                //get top 2 value 
                                List<string> hasil_top2;
                                /*select top(2) kerjabody_status  from TEMP_KERJABODY where KERJABODY_NOWO = '476898' order by IDkrj_body desc*/
                                // cek record apakah lebih dari 1
                                string jmlrecord = Fungsi_GetValue("select count(kerjabody_status)  from TEMP_KERJABODY where KERJABODY_NOWO = '" + noWo + "'");
                                if (Convert.ToInt32(jmlrecord) > 1)
                                {
                                    string sql_top2 = "select top(1) kerjabody_status  from TEMP_KERJABODY where KERJABODY_NOWO = '" + noWo + "' order by IDkrj_body desc";
                                    hasil_top2 = Fungsi_gettop2(sql_top2, "1");
                                    /*hasil_top2.RemoveAt(0)*/
                                    
                                    string hasil = KelasKoneksi_CUD("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = " + hasil_top2[0] + " WHERE CONTROLBR_NOWO = " + noWo + "");
                                    if (hasil == "1")
                                    {
                                        pesan_global="Berhasil Delete Status Pekerjaan BP'";
                                    }
                                    else
                                    {
                                        pesan_global = "Berhasil Delete Status Pekerjaan BP dan Gagal Update Status Ketok Akhir BP dengan error: " + hasil + "'";
                                    }
                                }
                                else if (Convert.ToInt32(jmlrecord) == 1)
                                {
                                    string sql_top2 = "select top(1) kerjabody_status  from TEMP_KERJABODY where KERJABODY_NOWO = '" + noWo + "' order by IDkrj_body desc";
                                    hasil_top2 = Fungsi_gettop2(sql_top2, "1");
                                    string hasil = KelasKoneksi_CUD("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = " + hasil_top2[0] + " WHERE CONTROLBR_NOWO = " + noWo + "");
                                    if (hasil == "1")
                                    {
                                        pesan_global = "Berhasil Delete Status Pekerjaan BP";
                                    }
                                    else
                                    {
                                        pesan_global = "Berhasil Delete Status Pekerjaan BP dan Gagal Update Status Ketok Akhir BP dengan error: " + hasil + "'";
                                    }
                                }
                            }
                        }
                        else
                        {
                            // delete gagal. error : 
                            //Response.Write("<script language='javascript'>window.alert('Delete gagal dengan error : " + hasildelete + "');</script>");
                            pesan_global = "Delete gagal dengan error : " + hasildelete + "";
                            // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Proses Delete Gagal, dengan error : " + hasildelete + "');</script>");
                        }
                    }
 
                }
                con.Close();
                //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + noWo);

            }
            else
            {
                //string pesan = "anda tidak bisa menghapus status ini, karena bukan anda yang melakukan input status ini!";
                //Response.Write("<script language='javascript'>window.alert('Error : " + pesan + "');</script>");
                //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + noWo);
                pesan_global = "anda tidak bisa menghapus status ini, karena bukan anda yang melakukan input status ini!";
            }
        }
        /*======*/


        //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa di unClosing karena data ini tidak dalam status Closing !"+ noWo + "');</script>");
        //Response.Write("<script language='javascript'>window.alert('"+pesan_global+"');</script>");
        //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + noWo);
        ShowAlertAndNavigate(pesan_global, "jobcontrolformanedt.aspx?qnowo="+noWo+"");
    }
    //FUNGSI UNTUK DRAFTPESAN
    public string DraftEmail_;
    public string DraftEmail_bankStatus(int status)
    {


        if (status == 1)
        {
            DraftEmail_ = "UNIT TELAH DI SERAHKAN SA KE VENDOR";
        }
        else if (status == 2)
        {
            DraftEmail_ = "UNIT TELAH DI TERIMA VENDOR";
        }
        else if (status == 3)
        {
            DraftEmail_ = "UNIT TELAH DI BONGKAR VENDOR";
        }
        else if (status == 4)
        {
            DraftEmail_ = "UNIT TELAH DI KETOK VENDOR";
        }
        else if (status == 5)
        {
            DraftEmail_ = "UNIT TELAH DI DEMPUL VENDOR";
        }
        else if (status == 6)
        {
            DraftEmail_ = "UNIT TELAH DI CAT / OVEN VENDOR";
        }
        else if (status == 7)
        {
            DraftEmail_ = "UNIT TELAH DI POLES VENDOR";
        }
        else if (status == 8)
        {
            DraftEmail_ = "UNIT TELAH DI PEMASANGAN VENDOR";
        }
        else if (status == 9)
        {
            DraftEmail_ = "UNIT TELAH DI FINISHING VENDOR";
        }
        else if (status == 10)
        {
            DraftEmail_ = "UNIT TELAH DI NILAI QC (OK) ";
        }
        else if (status == 11)
        {
            DraftEmail_ = "UNIT TELAH DI NILAI QC (REWORK) ";
        }
        else if (status == 12)
        {
            DraftEmail_ = "UNIT TELAH DI NILAI QC (HASIL REWORK) ";
        }
        else if (status == 13)
        {
            DraftEmail_ = "UNIT TELAH DI NILAI QC , TERDAPAT CATATAN SILAHKAN DI CEK DI WEB";
        }
        else if (status == 14)
        {
            DraftEmail_ = "UNIT TELAH DI SERAHKAN DARI VENDOR KE QC ";
        }
        else if (status == 15)
        {
            DraftEmail_ = "PROSES PENYERAHAN UNIT QC DARI VENDOR TELAH SELESAI";
        }
        else if (status == 16)
        {
            DraftEmail_ = "PROSES PENYERAHAN UNIT QC KE SA BP";
        }

        return DraftEmail_;
    }
    //FUNGSI UNTUK ALERT GLOBAL
    public void ShowAlertAndNavigate(string msg, string destination)
    {
        //string alert_redirect_Script = string.Format(@"<script type=""text/javascript"">
        //                               alert('{0}');
        //                                window.location.href = destination;
        //                               </script>", msg);
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alertredirectscript", alert_redirect_Script, false);
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
    //FUNGSI UNTUK EMAIL
    public bool EmailStaff(int status) {
        //logic kirim ke siapa
        string email=string.Empty;
        string pesan = string.Empty;
        if (status == 1 || status == 2|| status ==3 || status ==4|| status ==5|| status== 6|| status ==7|| status ==8) {
            email = "budiarthe@gmail.com";
            //email = "tandasanyu.movie1@gmail.com";
            string pesan_ = DraftEmail_bankStatus(status);
            pesan = "DEAR BUDI, " + pesan_ + ", silahkan cek web office.hondamugen untuk lebih jelasnya";
        } else if (status == 9 || status == 10 || status == 11 || status == 12) {
            //JIKA STATUS 10 MAKA KIRIM KE BUDI / ROBY
            if (status == 10)
            {
                email = "budiarthe@gmail.com";
                //email = "tandasanyu.movie1@gmail.com";
                string pesan__ = DraftEmail_bankStatus(status);
                pesan = "DEAR BUDI, " + pesan__ + ", silahkan cek web office.hondamugen untuk lebih jelasnya";
            }
            else {
                //email = "tandasanyu.movie2@gmail.com";
                email = "muchlishidayat02@gmail.com";
                string pesan_ = DraftEmail_bankStatus(status);
                pesan = "DEAR MUCHLIS, " + pesan_ + ", silahkan cek web office.hondamugen untuk lebih jelasnya";
            }
        } else if (status == 13) {
            email = "budiarthe@gmail.com";
            //email = "tandasanyu.movie1@gmail.com";
            string pesan_ = DraftEmail_bankStatus(status);
            pesan = "DEAR BUDI, " + pesan_ + ", silahkan cek web office.hondamugen untuk lebih jelasnya";
        } else if (status == 14 || status== 15) {
            //email = "tandasanyu.movie2@gmail.com";
            email = "muchlishidayat02@gmail.com";
            string pesan_ = DraftEmail_bankStatus(status);
            pesan = "DEAR MUCHLIS, " + pesan_ + ", silahkan cek web office.hondamugen untuk lebih jelasnya";
        } else if (status == 16) {
            //KE SA TERKAIT
            string sql="SELECT WOHDR_SA FROM TRXN_WOHDR WHERE (WOHDR_NO = " + noWo + ")";
            string hasil_namasa = Fungsi_GetValue(sql);
            if (hasil_namasa == "SUWANDI")
            {
                email = "bodyrepair_suwandi @hondamugen.co.id";
            }
            else if (hasil_namasa == "AGUS")
            {
                email = "bpmugen.agus @gmail.com";
            }
            else if (hasil_namasa == "SANDY")
            {
                email = "BODYREPAIR_SANDY@HONDAMUGEN.CO.ID";
            }
            else if (hasil_namasa == "MARWAN") //----128{}
            {
                email = "marwan3103@gmail.com";
            } else if (hasil_namasa == "TJAHYADI") {
                email = "tjahyadi03 @yahoo.com";
            } else if (hasil_namasa=="WAHYUSA") {
                email = "wahyu.febriyansyah@gmail.com";
            }
            //email = "tandasanyu.movie4@gmail.com";
            string pesan_ = DraftEmail_bankStatus(status);
            pesan = "DEAR " + hasil_namasa + " ," + pesan_ + ", silahkan cek web office.hondamugen untuk lebih jelasnya ";
        }

        //kirim email
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

        MailMessage mailMessage = new MailMessage("hmugen1991@gmail.com", email);
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