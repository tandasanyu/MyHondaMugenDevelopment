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
    public string nopol_bywo;
    public string status_unit = string.Empty;
    public string stsunit = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {   
        
        ListViewHistoryPengerjaan.DataBind();
         noWo = Request.QueryString["qnowo"];
        GetLastValue(noWo);
        //get nilai nopol berdasarkan wo
        nopol_bywo = Fungsi_GetValue("SELECT WOHDR_FNOPOL FROM TRXN_WOHDR WHERE WOHDR_NO =" + noWo + "");
        Image1.ImageUrl = "lamp/" + noWo + ".jpg";
        userAkses = (string)(Session["username"]);
        //UNTUK VALIDASI MEMUNCULKAN BTN REPORT
        if (userAkses == "LINDA" || userAkses == "MUCHLIS" || userAkses == "BAHRUR")
        {
            string hasil = Fungsi_GetValue("select KERJABODY_STATUS from TEMP_KERJABODY where KERJABODY_STATUS = 16 and KERJABODY_NOWO = "+noWo+"");
            string.IsNullOrEmpty(hasil);
            if (hasil == null || hasil == string.Empty ) {
                BtnReportBPPsm.Visible = false;
            } else {
                BtnReportBPPsm.Visible = true;
                txtCatatan.Visible = false;
                txtLokasi.Visible = false;
                LblLokasi.Visible = false;
                lblCatatan.Visible = false;
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
            btnUnclosing.Visible = false;
        }
        else
        {
            inputHistory.Visible = true;
            btnUnclosing.Visible = false;
        }
        //cek jika status sudah ada 16 maka tombol report muncul / sebaliknya jika belum
        //*** cek setiap tahap yang telah di lalui apakah ada. jika ya, maka check radiobutton checked -- Fungsi_GetValue
        string rb1 = string.Empty;
        string rb2 = string.Empty;
        string rb3 = string.Empty;
        string rb4 = string.Empty;
        string rb5 = string.Empty;
        string rb6 = string.Empty;
        string rb7 = string.Empty;
        string rb8 = string.Empty;
        string rb9 = string.Empty;
        string rb10 = string.Empty;
        string rb11 = string.Empty;
        string rb12= string.Empty;
        string rb13 = string.Empty;
        string rb14 = string.Empty;
        string rb15 = string.Empty;
        string rb16 = string.Empty;
        if (userAkses == "MUCHLIS" || userAkses == "BAHRUR"|| userAkses == "BUDI" || userAkses == "ROBYPURI")
        {
            Label10.Visible = false;
            TxtPembaruanEstimasi.Visible = false;
            //GvHistoryUpdateEstimasi.Visible = false;
            BtnUpdateEstimasi.Visible = false;
        }
        else
        {
            Label10.Visible = true;
            TxtPembaruanEstimasi.Visible = true;
            //GvHistoryUpdateEstimasi.Visible = true;
            BtnUpdateEstimasi.Visible = true;
        }
        //** get last value 
        string last_value = Fungsi_GetValue("select CONTROLBR_KETOKNILAI from TEMP_CONTROLBR where CONTROLBR_NOWO = "+noWo+"");
        //*** get allpassed value and store it in an arraylist
        List<String> PekerjaanBP = Select_ListArray("select kerjabody_status from TEMP_KERJABODY WHERE KERJABODY_NOWO = "+noWo+" order by kerjabody_status desc", "1");
        //*** eliminate same value 
        if (PekerjaanBP.Count != 0) {
            PekerjaanBP.RemoveAt(0);
            auto_checked(PekerjaanBP);
        }
        //get tgl estimasi
        string tglestimasi__ = Fungsi_GetValue("select CONTROLBR_TGLESELESAI from TEMP_CONTROLBR where CONTROLBR_NOWO = "+noWo+"");
        TglEstimasi.Text = tglestimasi__;
        //LblStsUnit
        stsunit = Fungsi_GetValue("select Flag from TEMP_CONTROLBR where CONTROLBR_NOWO = " + noWo + "");
        if (stsunit != string.Empty)
        {
            Label7.Visible = false;
            LblStsUnit.Text = "Mobil Unit : " + stsunit;
            ChkSAKePuri.Visible = false;
        }
        else {
            LblStsUnit.Visible = false;
            ChkSAKePuri.Visible = true;
        }
        //cek apakah ada history chat di wo tsb
        string result_chat = string.Empty;
        result_chat = Fungsi_GetValue("select count (id_chat) from DATA_HISTORY_CHAT where NOWO_CHAT = " + noWo + "");
        if (result_chat == "0")
        {
            Image2.Visible = false;
        }
        else
        {
            Image2.Visible = true;
        }
        //string result_qc_ok = string.Empty;
        //result_qc_ok = Fungsi_GetValue("select count(kerjabody_status) from TEMP_KERJABODY WHERE KERJABODY_NOWO = " + noWo + " and kerjabody_status = 11");
        //if (result_qc_ok == "0") {
        //    Div12.Visible = false;
        //    Div13.Visible = false;
        //    Div14.Visible = false;
        //    Div15.Visible = false;
        //    Div16.Visible = true;
        //}
    }
    //BTN DELETE TIDAK TERPAKAI
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
        if (userAkses == "MUCHLIS" || userAkses == "BAHRUR")
        {
            //test input by bahrur ketika vemdor belum input
            string result_ = string.Empty;
            result_ = getLastValue_special(noWo);
            //MENDAPATKAN VALUE CHECKLIST DETAIL CATATAN
            string detaicatatanBp = string.Empty;
            foreach (ListItem li in RbDetailCatatan.Items)
            {
                if (li.Selected)
                {
                    detaicatatanBp += li.Text + ",";
                }
            }
            if (result_ == string.Empty)
            {
                ShowAlertAndNavigate("Proses Gagal, Karena SA belum melakukan Input Data", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
            }
            else if (Convert.ToInt32(result_)<=15 && Convert.ToInt32(result_) >=10) //apakah <=15 & 
            {
                string last_value = string.Empty;
                last_value = Convert.ToString(LastValueAct(noWo));
                if (Convert.ToInt32(last_value) >= Convert.ToInt32(txtStatus.Text)) {
                    ShowAlertAndNavigate("Proses Gagal, Karena Input Proses yang Anda Pilih Sudah Ada / Sudah Di Lewati", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
                }
                else if ( txtStatus.Text == "11" || txtStatus.Text == "12" || txtStatus.Text == "13" || txtStatus.Text == "14" || txtStatus.Text == "15" || txtStatus.Text == "16")
                {

                    try
                    {
                        string filename = System.IO.Path.GetFileName(txtFoto.FileName);
                        string catatanBp = string.Empty;
                        catatanBp = txtCatatan.Text;
                        string lokasiBp = txtLokasi.Text;
                        string statusBp = txtStatus.Text;
                        string woBp = Request.QueryString["qnowo"];
                        string user = (string)(Session["username"]);
                        DateTime toDay = DateTime.Now;
                        string hariIni = toDay.ToString("MM/dd/yyyy hh:mm:ss");

                        //validasi
                        string status_hasil = Fungsi_CekStatus(woBp); // unit selesai oleh vendor (10)
                        if (status_hasil == "10up") //>=10
                        {
                            //bisa langsung 11 - 14
                            if (txtStatus.Text == "11" || txtStatus.Text == "12" || txtStatus.Text == "13" || txtStatus.Text == "14" || txtStatus.Text == "15" || txtStatus.Text == "16")
                            {
                                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
                                SqlConnection con = new SqlConnection(cs);
                                SqlCommand cmd = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI, KERJABODY_DETAILCATATAN) VALUES ('" + woBp + "', GETDATE(), '" + user + "', '" + statusBp + "', '" + catatanBp + "', '" + lokasiBp + "', '" + detaicatatanBp + "')", con);
                                SqlCommand cmd2 = new SqlCommand("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '" + statusBp + "' WHERE CONTROLBR_NOWO = '" + woBp + "'", con);
                                //command khusus input ketika status 
                                SqlCommand cmd3 = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI, KERJABODY_DETAILCATATAN) VALUES ('" + woBp + "', '" + hariIni + "', '" + user + "', '14', '" + catatanBp + "', '" + lokasiBp + "', '" + detaicatatanBp + "')", con);

                                con.Open();
                                if (catatanBp == "")
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Catatan anda belum diisi.');</script>");
                                    //catatanBp = null;
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

                                        bool status = EmailStaff(Convert.ToInt32(txtStatus.Text), Convert.ToInt32(noWo), nopol_bywo);
                                        if (statusBp == "11" || statusBp == "12" || statusBp == "14" || statusBp == "15")
                                        {
                                            //cmd3.ExecuteNonQuery();
                                            string sql_insert = "INSERT INTO TEMP_KERJABODY(KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI, KERJABODY_DETAILCATATAN) VALUES('" + woBp + "', GETDATE(), '" + user + "', '16', '" + catatanBp + "', '" + lokasiBp + "', '" + detaicatatanBp + "')";
                                            string sql_update = "UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '16' WHERE CONTROLBR_NOWO = '" + woBp + "'";
                                            trigger_action(sql_insert, sql_update);
                                            //email staff status 14
                                            bool status2 = EmailStaff(16, Convert.ToInt32(noWo), nopol_bywo);                                           
                                            string hasil = ClosingWo(noWo, userAkses);
                                            if (status2 == true)
                                            {
                                                ShowAlertAndNavigate("Berhasil Mengirim Email", "jobcontrolforman.aspx");
                                            }
                                        }
                                        //if (statusBp == "16")
                                        //{
                                        //    //string hasil = ClosingWo(noWo, userAkses);
                                        //    //if (hasil == "OK")
                                        //    //{
                                        //    //    ShowAlertAndNavigate("Berhasil Mengirim Email", "jobcontrolforman.aspx");
                                        //    //}
                                        //}
                                        if (status == true)
                                        {
                                            ShowAlertAndNavigate("Berhasil Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                                        }
                                        else
                                        {
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
                        else {
                            ShowAlertAndNavigate("Gagal Input Proses, Karena belum mencapai proses Unit Selesai Oleh Vendor", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                        }
                    //    else if (status_hasil == "10dw") {
                    //        // bisa isi di bawah 10
                    //        if (txtStatus.Text == "11" )
                    //        {
                    //            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
                    //            SqlConnection con = new SqlConnection(cs);
                    //            SqlCommand cmd = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI) VALUES ('" + woBp + "', '" + hariIni + "', '" + user + "', '" + statusBp + "', '" + catatanBp + "', '" + lokasiBp + "')", con);
                    //            SqlCommand cmd2 = new SqlCommand("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '" + statusBp + "' WHERE CONTROLBR_NOWO = '" + woBp + "'", con);
                    //            //command khusus input ketika status 
                    //            SqlCommand cmd3 = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI) VALUES ('" + woBp + "', '" + hariIni + "', '" + user + "', '14', '" + catatanBp + "', '" + lokasiBp + "')", con);

                    //            con.Open();
                    //            if (catatanBp == "")
                    //            {
                    //                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Catatan anda belum diisi.');</script>");
                    //                //catatanBp = null;
                    //            }
                    //            else if (lokasiBp == "")
                    //            {
                    //                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Lokasi Mobil belum anda isi.');</script>");
                    //            }
                    //            else if (statusBp == "")
                    //            {
                    //                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Pilih status pengerjaan anda terlebih dahulu.');</script>");
                    //            }
                    //            else
                    //            {

                    //                DataSet ds2 = new DataSet();

                    //                SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + woBp + "' AND CONTROLBR_TGLSELESAIA IS NULL", con);
                    //                da2.Fill(ds2);
                    //                int count2 = ds2.Tables[0].Rows.Count;
                    //                if (count2 == 0)
                    //                {
                    //                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman !');</script>");
                    //                }
                    //                else
                    //                {
                    //                    txtFoto.SaveAs(Server.MapPath("~/lamp/") + woBp + ".jpg");
                    //                    cmd.ExecuteNonQuery();
                    //                    cmd2.ExecuteNonQuery();
                    //                    if (statusBp == "11")
                    //                    {
                    //                        //cmd3.ExecuteNonQuery();
                    //                        string sql_insert = "INSERT INTO TEMP_KERJABODY(KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI) VALUES('" + woBp + "', '" + DateTime.Now.ToShortDateString() + "', '" + user + "', '16', '" + catatanBp + "', '" + lokasiBp + "')";
                    //                        string sql_update = "UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '16' WHERE CONTROLBR_NOWO = '" + woBp + "'";
                    //                        trigger_action(sql_insert, sql_update);
                    //                        //email staff status 14
                    //                        bool status2 = EmailStaff(16, Convert.ToInt32(noWo), nopol_bywo);
                    //                        ShowAlertAndNavigate("Berhasil Mengirim Email", "jobcontrolforman.aspx");
                    //                    }
                    //                    //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + woBp);
                    //                    bool status = EmailStaff(Convert.ToInt32(txtStatus.Text), Convert.ToInt32(noWo), nopol_bywo);
                    //                    if (status == true)
                    //                    {
                    //                        ShowAlertAndNavigate("Berhasil Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                    //                    }
                    //                    else
                    //                    {
                    //                        ShowAlertAndNavigate("Gagal Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                    //                    }
                    //                }
                    //            }
                    //            con.Close();
                    //        }
                    //        else {
                    //            //status yang anda pilih tidak dapat di input karena belum melewati tahap finishing.
                    //            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('status yang anda pilih tidak dapat di input karena belum melewati tahap finishing.');</script>");
                    //        }
                    //    } else if (status_hasil == "Empty")
                    //    {
                    //        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Proses yang anda pilih tidak dapat di input karena belum ada proses apapun yang berjalan sebelumnya.');</script>");
                    //    }
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
            else
            {
                ShowAlertAndNavigate("Wo yang Anda Pilih Belum Mencapai tahap Unit Selesai Oleh Vendor! Proses Gagal", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
            }
        }
        else if (userAkses == "BUDI" || userAkses =="ROBYPURI")
        {
            //get catatan detail yang di checklis
            string detaicatatanBp = string.Empty;
            foreach (ListItem li in RbDetailCatatan.Items)
            {
                if (li.Selected)
                {
                    detaicatatanBp += li.Text + ",";
                }
            }
            //****
            string result_ = string.Empty;
            result_ = getLastValue_special(noWo);
            if (result_ == string.Empty) {
                ShowAlertAndNavigate("Proses Gagal, Karena SA belum melakukan Input Data", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
            }
            else if (Convert.ToInt32(result_) < 2 && Convert.ToInt32(txtStatus.Text) > 2) {
                ShowAlertAndNavigate("Proses Gagal, Karena Anda Sebagai Vendor Belum Input Tahapan SERAH TERIMA UNIT di sistem!", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
            }
            else if (Convert.ToInt32(result_) > 10) {
                ShowAlertAndNavigate("Proses Gagal, Karena telah Melewati tahap Unit Selesai Oleh Vendor!", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
            }
            else if (Convert.ToInt32(result_) >= Convert.ToInt32(txtStatus.Text))
            {
                ShowAlertAndNavigate("Proses Gagal, Karena Proses yang Anda Pilih Sudah di Lewati / Sudah Ada!", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
            }
            else {
                if (txtStatus.Text == "02" || txtStatus.Text == "03" || txtStatus.Text == "04" || txtStatus.Text == "05" || txtStatus.Text == "06" || txtStatus.Text == "07" || txtStatus.Text == "08" || txtStatus.Text == "09" || txtStatus.Text == "10")
                {

                    try
                    {
                        string filename = System.IO.Path.GetFileName(txtFoto.FileName);
                        string catatanBp = string.Empty;
                        catatanBp = txtCatatan.Text;
                        string lokasiBp = txtLokasi.Text;
                        string statusBp = txtStatus.Text;
                        string woBp = Request.QueryString["qnowo"];
                        string user = (string)(Session["username"]);
                        DateTime toDay = DateTime.Now;
                        string hariIni = toDay.ToString("MM/dd/yyyy hh:mm:ss");

                        //validasi

                        //if (status_hasil == "10up" || userAkses == "ROBYPURI") //10up >=10
                        //{
                        //    string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
                        //    SqlConnection con = new SqlConnection(cs);
                        //    SqlCommand cmd = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI) VALUES ('" + woBp + "', '" + hariIni + "', '" + user + "', '" + statusBp + "', '" + catatanBp + "', '" + lokasiBp + "')", con);
                        //    SqlCommand cmd2 = new SqlCommand("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '" + statusBp + "' WHERE CONTROLBR_NOWO = '" + woBp + "'", con);
                        //    con.Open();
                        //    if (lokasiBp == "")
                        //    {
                        //        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Lokasi Mobil belum anda isi.');</script>");
                        //    }
                        //    else if (statusBp == "")
                        //    {
                        //        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Pilih status pengerjaan anda terlebih dahulu.');</script>");
                        //    }
                        //    else
                        //    {

                        //        DataSet ds2 = new DataSet();

                        //        SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + woBp + "' AND CONTROLBR_TGLSELESAIA IS NULL", con);
                        //        da2.Fill(ds2);
                        //        int count2 = ds2.Tables[0].Rows.Count;
                        //        if (count2 == 0)
                        //        {
                        //            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman !');</script>");
                        //        }
                        //        else
                        //        {
                        //            txtFoto.SaveAs(Server.MapPath("~/lamp/") + woBp + ".jpg");
                        //            cmd.ExecuteNonQuery();
                        //            cmd2.ExecuteNonQuery();
                        //            //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + woBp);
                        //            bool status = EmailStaff(Convert.ToInt32(txtStatus.Text), Convert.ToInt32(noWo), nopol_bywo);
                        //            if (status == true)
                        //            {
                        //                ShowAlertAndNavigate("Berhasil Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                        //            }
                        //            else
                        //            {
                        //                ShowAlertAndNavigate("Gagal Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                        //            }
                        //        }
                        //    }
                        //    con.Close();
                        //}
                        //if (status_hasil == "10up" && userAkses != "ROBYPURI") //10up>=10
                        //{
                        //    if (txtStatus.Text == "14") {
                        //        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
                        //        SqlConnection con = new SqlConnection(cs);
                        //        SqlCommand cmd = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI) VALUES ('" + woBp + "', '" + hariIni + "', '" + user + "', '" + statusBp + "', '" + catatanBp + "', '" + lokasiBp + "')", con);
                        //        SqlCommand cmd2 = new SqlCommand("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '" + statusBp + "' WHERE CONTROLBR_NOWO = '" + woBp + "'", con);
                        //        con.Open();
                        //        //if (catatanBp == "")
                        //        //{
                        //        //    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Catatan anda belum diisi.');</script>");
                        //        //    catatanBp = null;
                        //        //}
                        //        if (lokasiBp == "")
                        //        {
                        //            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Lokasi Mobil belum anda isi.');</script>");
                        //        }
                        //        else if (statusBp == "")
                        //        {
                        //            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Pilih status pengerjaan anda terlebih dahulu.');</script>");
                        //        }
                        //        else
                        //        {

                        //            DataSet ds2 = new DataSet();

                        //            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + woBp + "' AND CONTROLBR_TGLSELESAIA IS NULL", con);
                        //            da2.Fill(ds2);
                        //            int count2 = ds2.Tables[0].Rows.Count;
                        //            if (count2 == 0)
                        //            {
                        //                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman !');</script>");
                        //            }
                        //            else
                        //            {
                        //                txtFoto.SaveAs(Server.MapPath("~/lamp/") + woBp + ".jpg");
                        //                cmd.ExecuteNonQuery();
                        //                cmd2.ExecuteNonQuery();
                        //                //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + woBp);
                        //                bool status = EmailStaff(Convert.ToInt32(txtStatus.Text), Convert.ToInt32(noWo), nopol_bywo);
                        //                if (status == true)
                        //                {
                        //                    ShowAlertAndNavigate("Berhasil Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                        //                }
                        //                else
                        //                {
                        //                    ShowAlertAndNavigate("Gagal Mengirim Email", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                        //                }
                        //            }
                        //        }
                        //        con.Close();
                        //    }
                        //    else
                        //    {
                        //        //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Status yang Anda Pilih Tidak Bisa di Proses. Karena WO sudah masuk / melewati tahap finishing !');</script>");
                        //        ShowAlertAndNavigate("Gagal ! Status yang Anda Pilih Tidak Bisa di Proses. Karena WO sudah masuk / melewati tahap finishing !", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                        //    }

                        //}
                        //*** baru sampe sini 5/8/2019 -8.50am
                        string status_hasil = Fungsi_CekStatus(woBp);
                        if (status_hasil == "10dw") // yang di < 11 (Penilaian QC -OK)
                        {
                            if (userAkses == "ROBYPURI")
                            {
                                if (txtStatus.Text == "02" || txtStatus.Text == "03" || txtStatus.Text == "04" || txtStatus.Text == "05" || txtStatus.Text == "06" || txtStatus.Text == "07" || txtStatus.Text == "08" || txtStatus.Text == "09" || txtStatus.Text == "10")
                                {
                                    string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
                                    SqlConnection con = new SqlConnection(cs);
                                    SqlCommand cmd = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI, KERJABODY_DETAILCATATAN) VALUES ('" + woBp + "', GETDATE(), '" + user + "', '" + statusBp + "', '" + catatanBp + "', '" + lokasiBp + "', '" + detaicatatanBp + "')", con);
                                    SqlCommand cmd2 = new SqlCommand("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '" + statusBp + "' WHERE CONTROLBR_NOWO = '" + woBp + "'", con);
                                    con.Open();
                                    if (lokasiBp == "")
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
                                            //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman !');</script>");
                                            ShowAlertAndNavigate("Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman !", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                                        }
                                        else
                                        {
                                            txtFoto.SaveAs(Server.MapPath("~/lamp/") + woBp + ".jpg");
                                            cmd.ExecuteNonQuery();
                                            cmd2.ExecuteNonQuery();
                                            //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + woBp);
                                            bool status = EmailStaff(Convert.ToInt32(txtStatus.Text), Convert.ToInt32(noWo), nopol_bywo);
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
                                    ShowAlertAndNavigate("Gagal ! Status yang Anda Pilih Tidak Bisa di Proses. Anda Tidak Memiliki Hak untuk input proses tersebut !", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                                }
                            }
                            else
                            {
                                if (txtStatus.Text == "02" || txtStatus.Text == "03" || txtStatus.Text == "04" || txtStatus.Text == "05" || txtStatus.Text == "06" || txtStatus.Text == "07" || txtStatus.Text == "08" || txtStatus.Text == "09" || txtStatus.Text == "10")
                                {
                                    string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
                                    SqlConnection con = new SqlConnection(cs);
                                    SqlCommand cmd = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI, KERJABODY_DETAILCATATAN) VALUES ('" + woBp + "', GETDATE(), '" + user + "', '" + statusBp + "', '" + catatanBp + "', '" + lokasiBp + "', '" + detaicatatanBp + "')", con);
                                    SqlCommand cmd2 = new SqlCommand("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '" + statusBp + "' WHERE CONTROLBR_NOWO = '" + woBp + "'", con);
                                    con.Open();
                                    //if (catatanBp == "")
                                    //{
                                    //    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Catatan anda belum diisi.');</script>");
                                    //    catatanBp = null;
                                    //}
                                    if (lokasiBp == "")
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
                                            //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman !');</script>");
                                            ShowAlertAndNavigate("Gagal ! Tidak bisa di Delete karena WO ini sudah di Closing oleh Forman !", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                                        }
                                        else
                                        {
                                            txtFoto.SaveAs(Server.MapPath("~/lamp/") + woBp + ".jpg");
                                            cmd.ExecuteNonQuery();
                                            cmd2.ExecuteNonQuery();
                                            //Response.Redirect("jobcontrolformanedt.aspx?qnowo=" + woBp);
                                            bool status = EmailStaff(Convert.ToInt32(txtStatus.Text), Convert.ToInt32(noWo), nopol_bywo);
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
                                    ShowAlertAndNavigate("Gagal ! Status yang Anda Pilih Tidak Bisa di Proses. Anda Tidak Memiliki Hak untuk input proses tersebut !", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                                }
                            }
                        }
                        else if (status_hasil == "10up") {
                            ShowAlertAndNavigate("Unit Ini Telah Selesai Oleh Vendor, Proses Input Gagal", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
                        }
                        else if (status_hasil == "Empty")
                        {
                            ShowAlertAndNavigate("Proses yang anda pilih tidak dapat di input karena belum ada proses apapun yang berjalan sebelumnya.", "jobcontrolformanedt.aspx?qnowo=" + woBp + "");
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
                    ShowAlertAndNavigate("Gagal ! Status yang Anda Pilih Tidak Bisa di Proses. !", "jobcontrolforman.aspx");

                }
            }
        }
        // else untuk seluruh sa  psm
        else
        {
            string detaicatatanBp = string.Empty;
            foreach (ListItem li in RbDetailCatatan.Items)
            {
                if (li.Selected)
                {
                    detaicatatanBp += li.Text + ",";
                }
            }
            //
            //get value status apakah ada 02
            //cek apakah wo tsb ada status 2 nya.
            string Status_wo = string.Empty;
            string Status_wo2 = string.Empty;
            Status_wo = Fungsi_GetValue("select KERJABODY_STATUS from TEMP_KERJABODY WHERE KERJABODY_NOWO=" + noWo + " and KERJABODY_STATUS = '01'");
            if (txtStatus.Text == "01")
            {
                try
                {
                    string filename = System.IO.Path.GetFileName(txtFoto.FileName);
                    string catatanBp = string.Empty;
                    catatanBp = txtCatatan.Text;
                    string lokasiBp = txtLokasi.Text;
                    string statusBp = txtStatus.Text;
                    string woBp = Request.QueryString["qnowo"];
                    string user = (string)(Session["username"]);
                    //DateTime toDay = DateTime.Now.ToLongDateString;
                    //string hariIni = toDay.ToString("MM/dd/yyyy hh:mm:ss");
                    //cek apakah checklis ke puri true                    
                    if (ChkSAKePuri.Checked == true) {
                        status_unit = "Puri";
                    } else {
                        status_unit = "Psm";
                    }
                    //****
                    //cek value terakhir berapa

                    string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI, KERJABODY_DETAILCATATAN) VALUES ('" + woBp + "', GETDATE(), '" + user + "', '" + statusBp + "', '" + catatanBp + "', '" + lokasiBp + "', '" + detaicatatanBp + "')", con);
                    SqlCommand cmd2 = new SqlCommand("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '" + statusBp + "', Flag='"+status_unit+"' WHERE CONTROLBR_NOWO = '" + woBp + "'", con);
                    con.Open();
                    //if (catatanBp == "")
                    //{
                    //    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Catatan anda belum diisi.');</script>");
                    //    catatanBp = null;
                    //}
                    if (lokasiBp == "")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Lokasi Mobil belum anda isi.');</script>");
                    }
                    else if (statusBp == "")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Pilih status pengerjaan anda terlebih dahulu.');</script>");
                    }
                    else if (Status_wo == "01") {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda Tidak dapat memilih Tahap ini, karena mobil telah di serahkan SA ke driver / Puri');</script>");
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
                            string status_unit_ = string.Empty;
                            bool status;
                            if (status_unit == "Puri")
                            {
                                status = EmailStaff(02, Convert.ToInt32(noWo), nopol_bywo);
                                EmailStaff_spesialBahrur("DEAR BAHRUR, UNIT TELAH DI SERAHKAN SA KE PURI dengan nomor wo "+noWo+". silahkan cek web office.hondamugen untuk lebih jelasnya ");

                            }
                            else {
                                status = EmailStaff(01, Convert.ToInt32(noWo), nopol_bywo);

                            }
                             
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
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Status yang Anda Pilih Tidak Bisa di Proses. !');</script>");
                ShowAlertAndNavigate("Gagal ! Status yang Anda Pilih Tidak Bisa di Proses. !", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
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
    protected void BtnChat_Click(object sender, EventArgs e)
    {
        string userak_ = string.Empty;
        userak_ = (string)(Session["username"]);
        if (userak_ != string.Empty)
        {
            //Response.Redirect("HalamanChat.aspx");
            Session["noWo"] = noWo;
            ShowAlert("HalamanChat.aspx?USERNAME=" + userAkses + "&&NOWO=" + noWo + "&&CAB=112");
        }
        else
        {
            ShowAlertAndNavigate("Sesi Anda Telah Habis, Silahkan Login Kembali", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
        }
    }
    //fungsi get last value act 
    public int LastValueAct(string wo) {
        //get last value status dari TEMP_CONTROLBR dengan field CONTROLBR_KETOKNILAI dan wo CONTROLBR_NOWO
        string last_act = string.Empty;
        last_act = Fungsi_GetValue("select CONTROLBR_KETOKNILAI from TEMP_CONTROLBR where CONTROLBR_NOWO = " + wo + " ");

        if (last_act == string.Empty) {
            return 0;
        } else {
            return Convert.ToInt32(last_act);
        }
    }
    public void ShowAlert(string destination)
    {
        string url = destination;
        Response.Write("<script language='javascript'>window.location.assign('" + destination + "');</script>");
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

        string hasil = Fungsi_GetValue("select max(kerjabody_status) from temp_kerjabody where kerjabody_nowo = '" + wo + "' and kerjabody_status < 17");
        string.IsNullOrEmpty(hasil);
        if (hasil == null || hasil == string.Empty)
        {
            hasil_akhir = "Empty";
        }
        else
        {
            if (Convert.ToInt32(hasil) >= 10)
            {
                hasil_akhir = "10up";
            }
            else if (Convert.ToInt32(hasil) < 11)
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
            if (userAkses == userakhir || userAkses == "MUCHLIS" || userAkses == "BAHRUL")
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
        ShowAlertAndNavigate(pesan_global, "jobcontrolforman.aspx");
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
            DraftEmail_ = "UNIT SELESAI OLEH VENDOR";
        }
        else if (status == 11)
        {
            DraftEmail_ = "PENILAIAN QC - OK";
        }
        else if (status == 12)
        {
            DraftEmail_ = "PENILAIAN QC - NOT OK";
        }
        else if (status == 13)
        {
            DraftEmail_ = "PENILAIAN QC - REWORK";
        }
        else if (status == 14)
        {
            DraftEmail_ = "PENILAIAN QC - REWORK - OK";
        }
        else if (status == 15)
        {
            DraftEmail_ = "PENILAIAN QC - REWORK - NOT OK";
        }
        else if (status == 16)
        {
            DraftEmail_ = "PENYERAHAN UNIT QC KE SA BP";
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
    public bool EmailStaff(int status, int wo, string nopol)
    {
        //logic kirim ke siapa
        string email=string.Empty;
        string pesan = string.Empty;
        if (status == 1)
        {
            email = "ibudiarthe@gmail.com";
            string pesan_ = DraftEmail_bankStatus(status);
            pesan = "DEAR BUDI, " + pesan_ + ", dengan WO : " + wo + " & NOPOL : " + nopol + " silahkan cek web office.hondamugen untuk lebih jelasnya";
            //email = "tandasanyu.movie1@gmail.com";
            EmailStaff_spesial(pesan);

        }
        else if (status == 3 || status == 4 || status == 5 || status == 6 || status == 7 || status == 8 || status == 9) {
            //cek apakah wo tsb ada flag puri / psm
            string Status_wo = string.Empty;
            Status_wo = Fungsi_GetValue("select Flag from TEMP_CONTROLBR WHERE CONTROLBR_NOWO=" + noWo + "");
            if (Status_wo == "Psm") {
                email = "ibudiarthe@gmail.com";
                string pesan_ = DraftEmail_bankStatus(status);
                pesan = "DEAR BUDI, " + pesan_ + ", dengan WO : " + wo + " & NOPOL : " + nopol + " silahkan cek web office.hondamugen untuk lebih jelasnya";
                //email = "tandasanyu.movie1@gmail.com";
                EmailStaff_spesial(pesan);
            } else {
                email = "081297686377rb@gmail.com";
                string pesan_ = DraftEmail_bankStatus(status);
                pesan = "DEAR ROBY ada Unit yang di Kirim SA Pasar Minggu untuk Anda Kerjakan, " + pesan_ + ",dengan WO : " + wo + " & NOPOL : " + nopol + " silahkan cek web office.hondamugen untuk lebih jelasnya";
                EmailStaff_spesial(pesan);
            }
        }
        else if (status == 2)
        {
            //cek apakah wo tsb ada flag puri / psm
            string Status_wo = string.Empty;
            Status_wo = Fungsi_GetValue("select Flag from TEMP_CONTROLBR WHERE CONTROLBR_NOWO=" + noWo + "");
            if (Status_wo == "Psm")
            {
                email = "ibudiarthe@gmail.com";
                string pesan_ = DraftEmail_bankStatus(status);
                pesan = "DEAR BUDI, " + pesan_ + ", dengan WO : " + wo + " & NOPOL : " + nopol + " silahkan cek web office.hondamugen untuk lebih jelasnya";
                //email = "tandasanyu.movie1@gmail.com";
                EmailStaff_spesial(pesan);
            }
            else {
                email = "081297686377rb@gmail.com";
                string pesan_ = DraftEmail_bankStatus(status);
                pesan = "DEAR ROBY ada Unit yang di Kirim SA Pasar Minggu untuk Anda Kerjakan, " + pesan_ + ",dengan WO : " + wo + " & NOPOL : " + nopol + " silahkan cek web office.hondamugen untuk lebih jelasnya";
                EmailStaff_spesial(pesan);
            }
        }
        else if (status == 10 || status == 11 || status == 12 || status == 13 || status == 14 || status == 15 )
        {
            //cek apakah wo tsb ada flag puri / psm
            string Status_wo = string.Empty;
            Status_wo = Fungsi_GetValue("select Flag from TEMP_CONTROLBR WHERE CONTROLBR_NOWO=" + noWo + "");
            if (Status_wo == "Psm")
            {
                email = "muchlishidayat02@gmail.com";
                string pesan_ = DraftEmail_bankStatus(status);
                pesan = "DEAR MUCHLIS, " + pesan_ + ",dengan WO : " + wo + " & NOPOL : " + nopol + " silahkan cek web office.hondamugen untuk lebih jelasnya";
                EmailStaff_spesial(pesan);
            }
            else
            {
                email = "bahrurrojikin1@gmail.com";
                string pesan_ = DraftEmail_bankStatus(status);
                pesan = "DEAR BAHRUR, " + pesan_ + ",dengan WO : " + wo + " & NOPOL : " + nopol + " silahkan cek web office.hondamugen untuk lebih jelasnya";
                EmailStaff_spesial(pesan);
            }
        }
        else if (status == 16)
        {
            //KE SA TERKAIT
            string sql = "SELECT WOHDR_SA FROM TRXN_WOHDR WHERE (WOHDR_NO = " + noWo + ")";
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
            }
            else if (hasil_namasa == "TJAHYADI")
            {
                email = "tjahyadi03@yahoo.com";
            }
            else if (hasil_namasa == "WAHYUSA")
            {
                email = "wahyu.febriyansyah@gmail.com";
            }
            //email = "tandasanyu.movie4@gmail.com";
            string pesan_ = DraftEmail_bankStatus(status);
            pesan = "DEAR " + hasil_namasa + " ," + pesan_ + ", dengngan WO : " + wo + " & NOPOL : " + nopol + " silahkan cek web office.hondamugen.co.id untuk lebih jelasnya ";
            EmailStaff_spesial(pesan);
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
    //fungsi untuk email spesial (ke ritchard)
    public bool EmailStaff_spesial(string pesan)
    {
        //kirim email
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

        MailMessage mailMessage = new MailMessage("hmugen1991@gmail.com", "richard.nurtjahja@gmail.com");
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
    //untuk notifikasi ke bahrur ketika sa isi
    public bool EmailStaff_spesialBahrur(string pesan)
    {
        //kirim email
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

        MailMessage mailMessage = new MailMessage("hmugen1991@gmail.com", "bahrurrojikin1@gmail.com");
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
    //get last value to checked radiobutton
    public string GetLastValue(string wo) {
        string result = string.Empty;

        string status_kerja = string.Empty;
        string status_kerja1 = string.Empty;
        string sql = "SELECT CONTROLBR_KETOKNILAI FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + wo + "'";
        status_kerja1 = Fungsi_GetValue(sql);
        status_kerja = status_kerja1.Replace(" ", "");
        if (status_kerja == "1" || status_kerja=="01") {
            RB1.Checked = true;
        } else if (status_kerja == "2" || status_kerja == "02") {
            RB2.Checked = true;
        }
        else if (status_kerja == "3" || status_kerja == "03")
        {
            RB3.Checked = true;
        }
        else if (status_kerja == "4" || status_kerja == "04")
        {
            RB4.Checked = true;
        }
        else if (status_kerja == "5" || status_kerja == "05")
        {
            RB5.Checked = true;
        }
        else if (status_kerja == "6" || status_kerja == "06")
        {
            RB6.Checked = true;
        }
        else if (status_kerja == "7" || status_kerja == "07")
        {
            RB7.Checked = true;
        }
        else if (status_kerja == "8" || status_kerja == "08")
        {
            RB8.Checked = true;
        }
        else if (status_kerja == "9" || status_kerja == "09")
        {
            RB9.Checked = true;
        }
        else if (status_kerja == "10")
        {
            RB10.Checked = true;
        }
        else if (status_kerja == "11")
        {
            RB11.Checked = true;
        }
        else if (status_kerja == "12")
        {
            RB12.Checked = true;
        }
        else if (status_kerja == "13")
        {
            RB13.Checked = true;
        }
        else if (status_kerja == "14")
        {
            RB14.Checked = true;
        }
        else if (status_kerja == "15")
        {
            RB15.Checked = true;
        }
        else if (status_kerja == "16")
        {
            RB16.Checked = true;
        }
        return result;
    }
    //special function to insert and email if user give 10 for status
    public void trigger_action(string sql_insert, string sql_update) {
        //string status_ = string.Empty;

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand(sql_insert, con);
        SqlCommand cmd2 = new SqlCommand(sql_update, con);
        con.Open();
        cmd.ExecuteNonQuery();
        cmd2.ExecuteNonQuery();
        
        con.Close();

        //return status_;
    }
    //get radiobutton value
    protected void Button1_Click(object sender, EventArgs e)
    {
        string value = string.Empty;
        value = txtStatus.Text;
        ShowAlertAndNavigate(""+value+"", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
        
    }
    //fungsi get last value  -- TEMP_CONTROLBR
    public string getLastValue_special(string wo)
    {
        string result = string.Empty;
        string sql = "SELECT CONTROLBR_KETOKNILAI FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + wo + "'";
        result = Fungsi_GetValue(sql);
        return result;
    }
    public List<String> Result = new List<String>();
    public List<String> Select_ListArray(string SqlCmd, string sub)
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        string status_hasil = string.Empty;
        String strconn = WebConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);

        Result.Clear();
        try
        {
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (sub == "1")
                {
                    Result.Add(reader["kerjabody_status"].ToString()); //0
                }
                //status_hasil = "1";

            }
        }
        catch (SqlException ex)
        {
            //status_hasil = "Terjadi error Ketika Select: " + ex.Message;
            Result.Clear();
            // return ArrayLogin;

        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }

        return Result;

    }
    public void auto_checked (List<string> par1){

    }
    //FUNGSI UNTUK CLOSE ESTIMASI
    /*
             SqlCommand cmd = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI) VALUES ('" + noWoClosing + "', '" + tglClosing + "', '" + userClosing + "', '0', 'This closing note is automatically by system', '')", con);
        SqlCommand cmd2 = new SqlCommand("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '0', CONTROLBR_TGLSELESAIA = '" + tglClosing + "' WHERE CONTROLBR_NOWO = '" + noWoClosing + "'", con);
    */
    public string ClosingWo(string wo, string userClosing) {
        string hasil = string.Empty;
        string hasil2 = string.Empty;
        string sql1 = "INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI) VALUES ('" + wo + "',GETDATE(), '" + userClosing + "', '0', 'This closing note is automatically by system', '')";
        string sql2 = "UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '0', CONTROLBR_TGLSELESAIA = GETDATE() WHERE CONTROLBR_NOWO = '" + wo + "'";
        hasil = KelasKoneksi_CUD(sql1);
        hasil2 = KelasKoneksi_CUD(sql2);
        string final = string.Empty;
        if (hasil=="1" && hasil2 == "1") {
            final = "OK";
        }else
        {
            final = "NOT OK";
        }
        return final;      
    }
    protected void BtnUpdateEstimasi_Click(object sender, EventArgs e)
    {
        string updt_estimasi = string.Empty;
        updt_estimasi = TxtPembaruanEstimasi.Text;
        //cek apakah value status 17 di wo bersangklutan sudah lebih dari 3
        string hasil_ = Fungsi_GetValue("select count (kerjabody_status) as hasil from  TEMP_KERJABODY WHERE KERJABODY_NOWO = " + noWo + " and kerjabody_status = 17 ");
        if (Convert.ToInt32(hasil_) == 3 || Convert.ToInt32(hasil_) >= 3)
        {
            ShowAlertAndNavigate("Anda Sudah mencapai Batas Maksimal Pembaruan Estimasi (3 Kali)! Proses Gagal", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
        }
        else if (updt_estimasi == string.Empty)
        {
            ShowAlertAndNavigate("Tanggal Pembaruan Estimasi Wajib di Isi Proses Gagal", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
        }
        else
        {
            //ambil value terbaru di temp_controlbr 
            string last_value = Fungsi_GetValue("select CONTROLBR_TGLESELESAI from TEMP_CONTROLBR where CONTROLBR_NOWO ='" + noWo + "'");
            //update value terbaru di tem_controlbr
            string sql_ = "update TEMP_CONTROLBR set CONTROLBR_TGLESELESAI = '" + updt_estimasi + "' where CONTROLBR_NOWO ='" + noWo + "'";
            string result_updt = KelasKoneksi_CUD(sql_);
            if (result_updt == "1")
            {
                string sql_insert = "insert into TEMP_KERJABODY (KERJABODY_NOWO,KERJABODY_STATUS, KERJABODY_CATATAN) values ('" + noWo + "',17,'" + updt_estimasi + "')";
                string result_insert2 = KelasKoneksi_CUD(sql_insert);
                if (result_insert2 == "1")
                {
                    ShowAlertAndNavigate("Sukses Update Tanggal Estimasi & Simpan Histori Estimasi!", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
                }
                else
                {
                    ShowAlertAndNavigate("Gagal Simpan Histori Estimasi!", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
                }
            }
            else
            {
                ShowAlertAndNavigate("Gagal Update Tanggal Estimasi!", "jobcontrolformanedt.aspx?qnowo=" + noWo + "");
            }
            //string sqlcmd_ = " select CONTROLBR_TGLESELESAI from TEMP_CONTROLBR where CONTROLBR_NOWO ='" + wo + "'";
            //string result_estimasi = KelasKoneksi_CUD(sql_);
        }
    }


}