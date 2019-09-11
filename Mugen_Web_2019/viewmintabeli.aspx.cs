using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Net.Mail;

public partial class viewmintabeli : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string nomorBuktiDivisi = Request.QueryString["app0"];
        string nomorBukti = Request.QueryString["app1"];
        string nomorBuktiPurchasing = Request.QueryString["app2"];
        string nomorBuktiHeadPur = Request.QueryString["app3"];
        string nomorBuktiVpapp = Request.QueryString["app4"];
        lblDivNomor.Text = "No. " + nomorBuktiDivisi;
        lblNomor.Text = "No. " + nomorBukti;
        lblNoBuktiPurchasing.Text = "No. " + nomorBuktiPurchasing;
        lblNoHeadPur.Text = "No. " + nomorBuktiHeadPur;
        lblNoVpapp.Text = "No. " + nomorBuktiVpapp;
        string idReject = Request.QueryString["id"];
        string akses = Request.QueryString["aks"];
        txtIdreject.Text = idReject;
        txtIdRejectDiv.Text = idReject;
        txtIdRejAllDiv.Text = nomorBuktiDivisi;
        txtIdRejectPurchasing.Text = idReject;
        txtAppRejectAll.Text = nomorBukti;
        txtIdAppDiv.Text = nomorBuktiDivisi;
        txtAppApprove.Text = nomorBukti;
        txtIdAppPurchasing.Text = nomorBuktiPurchasing;
        txtIdRejectPurchasing.Text = idReject;
        txtIdRejectAllPurchasing.Text = nomorBuktiPurchasing;
   
        if (akses == "headapproval")
        {
            headApproval.Visible = true;
            purchasing.Visible = false;
            headPur.Visible = false;
            vpapp.Visible = false;
            divisiApproval.Visible = false;
        }
        else if (akses == "purchasing")
        {
            headApproval.Visible = false;
            purchasing.Visible = true;
            headPur.Visible = false;
            vpapp.Visible = false;
            divisiApproval.Visible = false;
        }
        else if (akses == "headpur")
        {
            headApproval.Visible = false;
            purchasing.Visible = false;
            headPur.Visible = true;
            vpapp.Visible = false;
            divisiApproval.Visible = false;
        }
        else if (akses == "vpapp")
        {
            headApproval.Visible = false;
            purchasing.Visible = false;
            headPur.Visible = false;
            vpapp.Visible = true;
            divisiApproval.Visible = false;
        }
        else if (akses == "divisiapproval")
        {
            headApproval.Visible = false;
            purchasing.Visible = false;
            headPur.Visible = false;
            vpapp.Visible = false;
            divisiApproval.Visible = true;
        }
        else {
            headApproval.Visible = false;
            purchasing.Visible = false;
            headPur.Visible = false;
            vpapp.Visible = false;
            divisiApproval.Visible = false;
            Response.Redirect("logout.aspx");
        }

        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp0 = Request.QueryString["app0"];
            string user = (string)(Session["username"]);
            command.CommandText = "SELECT SUM(jumlahitem*hargaitem) AS totalharga FROM [fmbbody] WHERE nobody = '" + ambApp0 + "' AND reject <> 'REJECT'";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalharga = reader["totalharga"].ToString();
                    if (totalharga == "")
                    {
                        lblDivTotal.Text = "0";
                    }
                    else
                    {
                        lblDivTotal.Text = decimal.Parse(totalharga).ToString("0,0,0");
                    }

                }
            }
        }
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp1 = Request.QueryString["app1"];
            string user = (string)(Session["username"]);
            command.CommandText = "SELECT SUM(jumlahitem*hargaitem) AS totalharga FROM [fmbbody] WHERE nobody = '" + ambApp1 + "' AND reject <> 'REJECT'";
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
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp2 = Request.QueryString["app2"];
            string user = (string)(Session["username"]);
            command.CommandText = "SELECT SUM(jumlahitem*hargaitem) AS totalharga FROM [fmbbody] WHERE nobody = '" + ambApp2 + "' AND reject <> 'REJECT'";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalharga = reader["totalharga"].ToString();
                    if (totalharga == "")
                    {
                        lblTotalPurchasing.Text = "0";
                    }
                    else
                    {
                        lblTotalPurchasing.Text = decimal.Parse(totalharga).ToString("0,0,0");
                    }

                }
            }
        }
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp3 = Request.QueryString["app3"];
            string user = (string)(Session["username"]);
            command.CommandText = "SELECT SUM(jumlahitem*hargaitem) AS totalharga FROM [fmbbody] WHERE nobody = '" + ambApp3 + "' AND reject <> 'REJECT'";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalharga = reader["totalharga"].ToString();
                    if (totalharga == "")
                    {
                        lblTotalHeadPur.Text = "0";
                    }
                    else
                    {
                        lblTotalHeadPur.Text = decimal.Parse(totalharga).ToString("0,0,0");
                    }

                }
            }
        }
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp4 = Request.QueryString["app4"];
            string user = (string)(Session["username"]);
            command.CommandText = "SELECT SUM(jumlahitem*hargaitem) AS totalharga FROM [fmbbody] WHERE nobody = '" + ambApp4 + "' AND reject <> 'REJECT'";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalharga = reader["totalharga"].ToString();
                    if (totalharga == "")
                    {
                        lblTotalVpapp.Text = "0";
                    }
                    else
                    {
                        lblTotalVpapp.Text = decimal.Parse(totalharga).ToString("0,0,0");
                    }

                }
            }
        }
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp0 = Request.QueryString["app0"];
            string user = (string)(Session["username"]);
            command.CommandText = "SELECT COUNT(idfmbhead) AS totalid, userfmb, CONVERT(VARCHAR, tglpemohonfmb,106) as tglmohon FROM [fmbhead] WHERE nofmbhead = '" + ambApp0 + "' AND rejecthead = 'N' AND disetujuifmb IS NULL GROUP BY userfmb, tglpemohonfmb";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalid = reader["totalid"].ToString();
                    string haMohon = reader["userfmb"].ToString();
                    string haTglMohon = reader["tglmohon"].ToString();
                    if (totalid == "0")
                    {
                        HyperLink22.Visible = false;
                        HyperLink23.Visible = false;
                        lblDivDibuat.Text = haMohon + " pada tgl " + haTglMohon;
                    }
                    else
                    {
                        HyperLink22.Visible = true;
                        HyperLink23.Visible = true;
                        lblDivDibuat.Text = haMohon + " pada tgl " + haTglMohon;
                    }

                }
            }
        }
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp1 = Request.QueryString["app1"];
            string user = (string)(Session["username"]);
            command.CommandText = "SELECT COUNT(idfmbhead) AS totalid, userfmb, CONVERT(VARCHAR, tglpemohonfmb,106) as tglmohon FROM [fmbhead] WHERE nofmbhead = '" + ambApp1 + "' AND rejecthead = 'N' AND disetujuifmb IS NULL GROUP BY userfmb, tglpemohonfmb";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalid = reader["totalid"].ToString();
                    string haMohon = reader["userfmb"].ToString();
                    string haTglMohon = reader["tglmohon"].ToString();
                    if (totalid == "0")
                    {
                        HyperLink2.Visible = false;
                        HyperLink4.Visible = false;
                        lblMohonHa.Text = haMohon + " pada tgl " + haTglMohon;
                    }
                    else
                    {
                        HyperLink2.Visible = true;
                        HyperLink4.Visible = true;
                        lblMohonHa.Text = haMohon + " pada tgl " + haTglMohon;
                    }

                }
            }
        }
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp2 = Request.QueryString["app2"];
            string user = (string)(Session["username"]);
            command.CommandText = "SELECT COUNT(idfmbhead) AS totalid, userfmb, CONVERT(VARCHAR, tglpemohonfmb,106) as tglmohon, disetujuifmb, CONVERT(VARCHAR, tgldisetujuifmb,106) as tglsetuju FROM [fmbhead] WHERE nofmbhead = '" + ambApp2 + "' AND rejecthead = 'N' AND disetujuifmb IS NOT NULL AND mengetahuifmb IS NULL GROUP BY userfmb, tglpemohonfmb, disetujuifmb, tgldisetujuifmb";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalid = reader["totalid"].ToString();
                    string pMohon = reader["userfmb"].ToString();
                    string pTglMohon = reader["tglmohon"].ToString();
                    string pSetuju = reader["disetujuifmb"].ToString();
                    string pTglSetuju = reader["tglsetuju"].ToString();
                    if (totalid == "0")
                    {
                        HyperLink6.Visible = false;
                        HyperLink7.Visible = false;
                        lblMohonPur.Text = pMohon + " pada tgl " + pTglMohon;
                        lblSetujuPur.Text = pSetuju + " pada tgl " + pTglSetuju;
                    }
                    else
                    {
                        HyperLink6.Visible = true;
                        HyperLink7.Visible = true;
                        lblMohonPur.Text = pMohon + " pada tgl " + pTglMohon;
                        lblSetujuPur.Text = pSetuju + " pada tgl " + pTglSetuju;
                    }

                }
            }
        }
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp3 = Request.QueryString["app3"];
            string user = (string)(Session["username"]);
            command.CommandText = "SELECT COUNT(idfmbhead) AS totalid, userfmb, CONVERT(VARCHAR, tglpemohonfmb,106) as tglmohon, disetujuifmb, CONVERT(VARCHAR, tgldisetujuifmb,106) as tglsetuju FROM [fmbhead] WHERE nofmbhead = '" + ambApp3 + "' AND rejecthead = 'N' AND disetujuifmb IS NOT NULL AND mengetahuifmb IS NOT NULL AND approveheadpurc IS NULL GROUP BY userfmb, tglpemohonfmb, disetujuifmb, tgldisetujuifmb";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalid = reader["totalid"].ToString();
                    string hpMohon = reader["userfmb"].ToString();
                    string hpTglMohon = reader["tglmohon"].ToString();
                    string hpSetuju = reader["disetujuifmb"].ToString();
                    string hpTglSetuju = reader["tglsetuju"].ToString();
                    if (totalid == "0")
                    {
                        HyperLink12.Visible = false;
                        HyperLink13.Visible = false;
                        lblPemohonHp.Text = hpMohon + " pada tgl " + hpTglMohon;
                        lblSetujuHp.Text = hpSetuju + " pada tgl " + hpTglSetuju;
                    }
                    else
                    {
                        HyperLink12.Visible = true;
                        HyperLink13.Visible = true;
                        lblPemohonHp.Text = hpMohon + " pada tgl " + hpTglMohon;
                        lblSetujuHp.Text = hpSetuju + " pada tgl " + hpTglSetuju;
                    }

                }
            }
        }
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp4 = Request.QueryString["app4"];
            string user = (string)(Session["username"]);
            command.CommandText = "SELECT COUNT(idfmbhead) AS totalid, userfmb, CONVERT(VARCHAR, tglpemohonfmb,106) as tglmohon,  disetujuifmb, CONVERT(VARCHAR, tgldisetujuifmb,106) as tglsetuju, approveheadpurc, CONVERT(VARCHAR, tglapproveheadpurc,106) as tglapproveheadpurc FROM [fmbhead] WHERE nofmbhead = '" + ambApp4 + "' AND rejecthead = 'N' AND disetujuifmb IS NOT NULL AND mengetahuifmb IS NOT NULL AND disetujui2fmb IS NULL GROUP BY userfmb, tglpemohonfmb, disetujuifmb, tgldisetujuifmb, approveheadpurc, tglapproveheadpurc";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalid = reader["totalid"].ToString();
                    string vpappSetuju = reader["disetujuifmb"].ToString();
                    string vpappTglSetuju = reader["tglsetuju"].ToString();
                    string vpappPemohon = reader["userfmb"].ToString();
                    string vpappTglPemohon = reader["tglmohon"].ToString();
                    string vpappHeadPurc = reader["approveheadpurc"].ToString();
                    string vpappTglHeadPurc = reader["tglapproveheadpurc"].ToString();
                    if (totalid == "0")
                    {
                        HyperLink16.Visible = false;
                        HyperLink17.Visible = false;
                        lblVpappBuat.Text = vpappPemohon + " pada tgl " + vpappTglPemohon;
                        lblVpappSetuju.Text = vpappSetuju + " pada tgl " + vpappTglSetuju;
                        lblVpappHeadPur.Text = vpappHeadPurc + " pada tgl " + vpappTglHeadPurc;
                    }
                    else
                    {
                        HyperLink16.Visible = true;
                        HyperLink17.Visible = true;
                        lblVpappBuat.Text = vpappPemohon + " pada tgl " + vpappTglPemohon;
                        lblVpappSetuju.Text = vpappSetuju + " pada tgl " + vpappTglSetuju;
                        lblVpappHeadPur.Text = vpappHeadPurc + " pada tgl " + vpappTglHeadPurc;
                    }

                }
            }
        }
    }
    protected void btnRejectDiv_Click(object sender, EventArgs e)
    {
        string alasan = txtAlasanRejectDiv.Text;
        string jumlahReject = txtJumlahRejectDiv.Text;
        string idreject = txtIdRejectDiv.Text;
        string app = Request.QueryString["app0"];
        string user = (string)(Session["username"]);

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("DELETE FROM fmbbody WHERE idbody = '" + idreject + "'", con);
        SqlCommand cmd2 = new SqlCommand("INSERT INTO fmbbody(nobody, namaitem, tujuanitem, jumlahitem, hargaitem, pusatbiaya, reject, alasanreject, rejectoleh, vendor) SELECT nobody, namaitem, tujuanitem, '" + jumlahReject + "', hargaitem, pusatbiaya, 'REJECT', '" + alasan + "', '" + user + "', vendor FROM fmbbody WHERE idbody = '" + idreject + "' ", con);
        SqlCommand cmd3 = new SqlCommand("DELETE FROM fmblamp WHERE nohead = '" + app + "'", con);
        SqlCommand cmd4 = new SqlCommand("UPDATE fmbhead SET rejecthead = 'Y', rejectheadoleh = '" + user + "', alasanrejecthead = '" + alasan + "' WHERE nofmbhead = '" + app + "'", con);
        SqlCommand cmd5 = new SqlCommand("UPDATE fmbbody SET jumlahitem = jumlahitem -  '" + jumlahReject + "' WHERE idbody = '" + idreject + "' AND reject = 'APPROVE'", con);

        con.Open();

        if(alasan == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan reject harus diisi !');</script>");
        }
        else {
        if(jumlahReject == "") {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus diisi !');</script>");
            }
        else {
        if (jumlahReject == "0")
           {
               ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
           }
        else { 
                DataSet ds3 = new DataSet();
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + app + "' AND rejecthead = 'N' AND divisiapprove IS NOT NULL", con);
        da3.Fill(ds3);
        int count3 = ds3.Tables[0].Rows.Count;
        if (count3 == 0)
        {
            DataSet ds4 = new DataSet();

            SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE (jumlahitem < '" + jumlahReject + "') AND idbody = '" + idreject + "'", con);
            da4.Fill(ds4);
            int count4 = ds4.Tables[0].Rows.Count;
            if (count4 == 0)
            {
                DataSet ds5 = new DataSet();

                SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE jumlahitem <= 1 AND idbody = '" + idreject + "'", con);
                da5.Fill(ds5);
                int count5 = ds5.Tables[0].Rows.Count;
                if (count5 == 0)
                {
                    cmd2.ExecuteNonQuery();
                    cmd5.ExecuteNonQuery();
                    Response.Redirect("viewmintabeli.aspx?app0=" + app + "&&aks=divisiapproval");

                }
                else
                {
                    DataSet ds2 = new DataSet();

                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + app + "' AND reject = 'APPROVE'", con);
                    da2.Fill(ds2);
                    int count2 = ds2.Tables[0].Rows.Count;
                    if (count2 <= 1)
                    {
                        cmd2.ExecuteNonQuery();
                        cmd4.ExecuteNonQuery();
                        cmd.ExecuteNonQuery();
                        Response.Redirect("approvemintabeli.aspx?q=divisiapproval");
                    }
                    else {
                        cmd2.ExecuteNonQuery();
                        cmd.ExecuteNonQuery();
                        Response.Redirect("viewmintabeli.aspx?app0=" + app + "&&aks=divisiapproval");
                    }

                }

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject lebih besar dari yg tersisa !');</script>");
            }

        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Data yang sudah diapprove tidak bisa reject kembali');</script>");
        }
            }
            }
        }
        con.Close();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string alasan = txtAlasanReject.Text;
        string jumlahReject = txtJumlahRejectHead.Text;
        string idreject = txtIdreject.Text;
        string app = Request.QueryString["app1"];
        string user = (string)(Session["username"]);

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("DELETE FROM fmbbody WHERE idbody = '" + idreject + "'", con);
        SqlCommand cmd2 = new SqlCommand("INSERT INTO fmbbody(nobody, namaitem, tujuanitem, jumlahitem, hargaitem, pusatbiaya, reject, alasanreject, rejectoleh, vendor) SELECT nobody, namaitem, tujuanitem, '" + jumlahReject + "', hargaitem, pusatbiaya, 'REJECT', '" + alasan + "', '" + user + "', vendor FROM fmbbody WHERE idbody = '" + idreject + "' ", con);
        SqlCommand cmd3 = new SqlCommand("DELETE FROM fmblamp WHERE nohead = '" + app + "'", con);
        SqlCommand cmd4 = new SqlCommand("UPDATE fmbhead SET rejecthead = 'Y', rejectheadoleh = '" + user + "', alasanrejecthead = '" + alasan + "' WHERE nofmbhead = '" + app + "'", con);
        SqlCommand cmd5 = new SqlCommand("UPDATE fmbbody SET jumlahitem = jumlahitem -  '" + jumlahReject + "' WHERE idbody = '" + idreject + "' AND reject = 'APPROVE'", con);
       
        con.Open();

        if (alasan == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan reject harus diisi !');</script>");
        }
        else {
            if (jumlahReject == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus diisi !');</script>");
            }
            else {
                if (jumlahReject == "0")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                }
                else {
                    DataSet ds3 = new DataSet();

                    SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + app + "' AND rejecthead = 'N' AND disetujuifmb IS NOT NULL", con);
                    da3.Fill(ds3);
                    int count3 = ds3.Tables[0].Rows.Count;
                    if (count3 == 0)
                    {
                        DataSet ds4 = new DataSet();

                        SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE (jumlahitem < '" + jumlahReject + "') AND idbody = '" + idreject + "'", con);
                        da4.Fill(ds4);
                        int count4 = ds4.Tables[0].Rows.Count;
                        if (count4 == 0)
                        {
                            DataSet ds5 = new DataSet();

                            SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE jumlahitem <= 1 AND idbody = '" + idreject + "'", con);
                            da5.Fill(ds5);
                            int count5 = ds5.Tables[0].Rows.Count;
                            if (count5 == 0)
                            {
                                cmd2.ExecuteNonQuery();
                                cmd5.ExecuteNonQuery();
                                Response.Redirect("viewmintabeli.aspx?app1=" + app + "&&aks=headapproval");

                            }
                            else
                            {
                                DataSet ds2 = new DataSet();

                                SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + app + "' AND reject = 'APPROVE'", con);
                                da2.Fill(ds2);
                                int count2 = ds2.Tables[0].Rows.Count;
                                if (count2 <= 1)
                                {
                                    cmd2.ExecuteNonQuery();
                                    cmd4.ExecuteNonQuery();
                                    cmd.ExecuteNonQuery();
                                    Response.Redirect("approvemintabeli.aspx?q=headapproval");
                                }
                                else {
                                    cmd2.ExecuteNonQuery();
                                    cmd.ExecuteNonQuery();
                                    Response.Redirect("viewmintabeli.aspx?app1=" + app + "&&aks=headapproval");
                                }

                            }

                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject lebih besar dari yg tersisa !');</script>");
                        }

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Data yang sudah diapprove tidak bisa reject kembali');</script>");
                    }
                }
            }
        }
        con.Close();

    }
    protected void btnRejectAllDiv_Click(object sender, EventArgs e)
    {
        string idRejectAll = txtIdRejAllDiv.Text;
        string alasanRejectAll = txtAlasanRejectAllDiv.Text;
        string userRejectAll = (string)(Session["username"]);

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbbody SET reject = 'REJECT', rejectoleh = '" + userRejectAll + "', alasanreject = '" + alasanRejectAll + "' WHERE nobody = '" + idRejectAll + "' AND reject = 'APPROVE'", con);
        SqlCommand cmd2 = new SqlCommand("UPDATE fmbhead SET rejecthead = 'Y', rejectheadoleh = '" + userRejectAll + "', alasanrejecthead = '" + alasanRejectAll + "' WHERE nofmbhead = '" + idRejectAll + "'", con);
        SqlCommand cmd3 = new SqlCommand("DELETE FROM fmblamp WHERE nohead = '" + idRejectAll + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + idRejectAll + "' AND reject = 'APPROVE'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda reject sudah tidak tersedia');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + idRejectAll + "' AND rejecthead = 'N' AND divisiapprove IS NULL", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda reject sudah tidak tersedia');</script>");
            }
            else
            {
                if (alasanRejectAll == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Alasan anda me-Reject harus diisi');</script>");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    Response.Redirect("approvemintabeli.aspx?q=divisiapproval");
                }
            }
        }
        con.Close();
    }
    protected void btnRejectAll_Click(object sender, EventArgs e)
    {
        string idRejectAll = txtAppRejectAll.Text;
        string alasanRejectAll = txtAlasanRejectAll.Text;
        string userRejectAll = (string)(Session["username"]);

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbbody SET reject = 'REJECT', rejectoleh = '" + userRejectAll + "', alasanreject = '" + alasanRejectAll + "' WHERE nobody = '" + idRejectAll + "' AND reject = 'APPROVE'", con);
        SqlCommand cmd2 = new SqlCommand("UPDATE fmbhead SET rejecthead = 'Y', rejectheadoleh = '" + userRejectAll + "', alasanrejecthead = '" + alasanRejectAll + "' WHERE nofmbhead = '" + idRejectAll + "'", con);
        SqlCommand cmd3 = new SqlCommand("DELETE FROM fmblamp WHERE nohead = '" + idRejectAll + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + idRejectAll + "' AND reject = 'APPROVE'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
             ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda reject sudah tidak tersedia');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + idRejectAll + "' AND rejecthead = 'N' AND disetujuifmb IS NULL", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda reject sudah tidak tersedia');</script>");
            }
            else
            {
                if (alasanRejectAll == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Alasan anda me-Reject harus diisi');</script>");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    Response.Redirect("approvemintabeli.aspx?q=headapproval");
                }
            }
        }
        con.Close();
    }
    protected void btnApproveDiv_Click(object sender, EventArgs e)
    {
        string idApproval = txtIdAppDiv.Text;
        string userApproval = (string)(Session["username"]);
        DateTime myDate = DateTime.Now;
        string hariIni2 = myDate.ToString("MM/dd/yyyy");

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbhead SET divisiapprove = '" + userApproval + "', tgldivisiapprove = '" + hariIni2 + "' WHERE nofmbhead = '" + idApproval + "' AND rejecthead = 'N'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + idApproval + "' AND rejecthead = 'N' AND divisiapprove IS NULL", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda Approve sudah tidak tersedia');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + idApproval + "' AND reject = 'APPROVE'", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda Approve sudah tidak tersedia');</script>");
            }
            else
            {
                if (idApproval == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Kesalahan prosedur dalam pengambilan data, hubungi IT');</script>");
                }
                else
                {
                                cmd.ExecuteNonQuery();
                                Response.Redirect("approvemintabeli.aspx?q=divisiapproval");
                }
            }
        }
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)// ini button untuk approval head 
    {
        string idApproval = txtAppApprove.Text;
        string nextApproval = drpNamaApprove.Text;
        string userApproval = (string)(Session["username"]);
        DateTime myDate = DateTime.Now;
        string hariIni2 = myDate.ToString("MM/dd/yyyy");

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbhead SET disetujuifmb = '" + userApproval + "', tgldisetujuifmb = '" + hariIni2 + "' WHERE nofmbhead = '" + idApproval + "' AND rejecthead = 'N'", con);
        SqlCommand cmd2 = new SqlCommand("UPDATE fmbhead SET namadivisi = '" + nextApproval + "' WHERE nofmbhead = '" + idApproval + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + idApproval + "' AND rejecthead = 'N' AND disetujuifmb IS NULL", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda Approve sudah tidak tersedia');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + idApproval + "' AND reject = 'APPROVE'", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda Approve sudah tidak tersedia');</script>");
            }
            else
            {
                if (nextApproval == " ")
                {
                    cmd.ExecuteNonQuery();
                    Response.Redirect("approvemintabeli.aspx?q=headapproval");
                }
                else
                {
                    using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT email FROM tb_user WHERE username = '" + nextApproval + "'";
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //string eMail = reader["email"].ToString();
                                
                                //MailAddress from = new MailAddress("hmugen1991@gmail.com");
                                //MailAddress to = new MailAddress("" + eMail + ",setiawan-it@hondamugen.co.id");
                                //MailMessage message = new MailMessage(from, to);
                                //message.Subject = "Permintaan Pembelian No." + idApproval + " Membutuhkan Persetujuan Anda.";
                                //message.Body = @"<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda memiliki sebuah permintaan persetujuan untuk pembuatan sebuah Purchase Order, dengan nomor permintaan: <strong><center> " + idApproval + " </center></strong><br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=approvemintabeli.aspx?q=headapproval' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Daftar Approval</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                                //message.IsBodyHtml = true;
                                //SmtpClient sc = new SmtpClient();
                                //sc.Host = "smtp.gmail.com";
                                //sc.Port = 587;
                                //sc.EnableSsl = true;
                                //sc.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
                                //sc.Send(message);
                                cmd.ExecuteNonQuery();
                                cmd2.ExecuteNonQuery();
                                Response.Redirect("approvemintabeli.aspx?q=headapproval");
                            }
                        }
                        connection.Close();
                    }
                   
                }
            }
        }
        con.Close(); 
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string idApprovalP = txtIdAppPurchasing.Text;
        string userApproval = (string)(Session["username"]);
        DateTime myDate = DateTime.Now;
        string hariIni2 = myDate.ToString("MM/dd/yyyy");

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbhead SET mengetahuifmb = '" + userApproval + "', tglmengetahuifmb = '" + hariIni2 + "' WHERE nofmbhead = '" + idApprovalP + "' AND rejecthead = 'N'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + idApprovalP + "' AND rejecthead = 'N' AND mengetahuifmb IS NULL", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda Approve sudah tidak tersedia');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + idApprovalP + "' AND reject = 'APPROVE'", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda Approve sudah tidak tersedia');</script>");
            }
            else
            {
                DataSet ds3 = new DataSet();

                SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + idApprovalP + "' AND reject = 'APPROVE' AND vendor = ''", con);
                da3.Fill(ds3);
                int count3 = ds3.Tables[0].Rows.Count;
                if (count3 == 0)
                {
                    DataSet ds4 = new DataSet();

                    SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + idApprovalP + "' AND hargaitem > '0' AND reject = 'APPROVE'", con);
                    da4.Fill(ds4);
                    int count4 = ds4.Tables[0].Rows.Count;
                    if (count4 == 0)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Anda tidak dapat melanjutkan karena Harga masih 0.');</script>");
                    }
                    else
                    {
                        if (idApprovalP == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Kesalahan prosedur dalam pengambilan data, hubungi IT');</script>");
                        }
                        else
                        {
                            MailAddress from = new MailAddress("hmugen1991@gmail.com");
                            MailAddress to = new MailAddress("tini@hondamugen.co.id, setiawan-it@hondamugen.co.id");
                            MailMessage message = new MailMessage(from, to);
                            message.Subject = "Permintaan Pembelian No." + idApprovalP + " Membutuhkan Persetujuan Anda.";
                            message.Body = @"<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda memiliki sebuah permintaan persetujuan untuk pembuatan sebuah Purchase Order, dengan nomor permintaan: <strong><center> " + idApprovalP + " </center></strong><br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=approvemintabeli.aspx?q=headpur' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Daftar Approval</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                            message.IsBodyHtml = true;
                            SmtpClient sc = new SmtpClient();
                            sc.Host = "smtp.gmail.com";
                            sc.Port = 587;
                            sc.EnableSsl = true;
                            sc.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
                            sc.Send(message);

                            cmd.ExecuteNonQuery();
                            Response.Redirect("approvemintabeli.aspx?q=purchasing");
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Anda belum mengisi nama vendor.');</script>");
                }
            }
        }
        con.Close(); 
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        string idRejectAll = txtIdRejectAllPurchasing.Text;
        string alasanRejectAll = txtAlasanRejectAllPurchasing.Text;
        string userRejectAll = (string)(Session["username"]);

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbbody SET reject = 'REJECT', rejectoleh = '" + userRejectAll + "', alasanreject = '" + alasanRejectAll + "' WHERE nobody = '" + idRejectAll + "' AND reject = 'APPROVE'", con);
        SqlCommand cmd2 = new SqlCommand("UPDATE fmbhead SET rejecthead = 'Y', rejectheadoleh = '" + userRejectAll + "', alasanrejecthead = '" + alasanRejectAll + "' WHERE nofmbhead = '" + idRejectAll + "'", con);
        SqlCommand cmd3 = new SqlCommand("DELETE FROM fmblamp WHERE nohead = '" + idRejectAll + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + idRejectAll + "' AND reject = 'APPROVE'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda reject sudah tidak tersedia');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + idRejectAll + "' AND rejecthead = 'N' AND disetujuifmb IS NOT NULL AND mengetahuifmb IS NULL", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda reject sudah tidak tersedia');</script>");
            }
            else
            {
                if (alasanRejectAll == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Alasan anda me-Reject harus diisi');</script>");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    Response.Redirect("approvemintabeli.aspx?q=purchasing");
                }
            }
        }
        con.Close();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string alasan = txtAlasanRejectPurchasing.Text;
        string idreject = txtIdRejectPurchasing.Text;
        string jumlahReject = txtJumlahRejectPurc.Text;
        string app = Request.QueryString["app2"];
        string user = (string)(Session["username"]);

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("DELETE FROM fmbbody WHERE idbody = '" + idreject + "'", con);
        SqlCommand cmd2 = new SqlCommand("INSERT INTO fmbbody(nobody, namaitem, tujuanitem, jumlahitem, hargaitem, pusatbiaya, reject, alasanreject, rejectoleh, vendor) SELECT nobody, namaitem, tujuanitem, '" + jumlahReject + "', hargaitem, pusatbiaya, 'REJECT', '" + alasan + "', '" + user + "', vendor FROM fmbbody WHERE idbody = '" + idreject + "' ", con);
        SqlCommand cmd3 = new SqlCommand("DELETE FROM fmblamp WHERE nohead = '" + app + "'", con);
        SqlCommand cmd4 = new SqlCommand("UPDATE fmbhead SET rejecthead = 'Y', rejectheadoleh = '" + user + "', alasanrejecthead = '" + alasan + "' WHERE nofmbhead = '" + app + "'", con);
        SqlCommand cmd5 = new SqlCommand("UPDATE fmbbody SET jumlahitem = jumlahitem -  '" + jumlahReject + "' WHERE idbody = '" + idreject + "' AND reject = 'APPROVE'", con);

        con.Open();


        DataSet ds3 = new DataSet();

        SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + app + "' AND rejecthead = 'N' AND mengetahuifmb IS NOT NULL", con);
        da3.Fill(ds3);
        int count3 = ds3.Tables[0].Rows.Count;
        if (count3 == 0)
        {
            DataSet ds4 = new DataSet();

            SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE (jumlahitem < '" + jumlahReject + "') AND idbody = '" + idreject + "'", con);
            da4.Fill(ds4);
            int count4 = ds4.Tables[0].Rows.Count;
            if (count4 == 0)
            {
                DataSet ds5 = new DataSet();

                SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE jumlahitem <= 1 AND idbody = '" + idreject + "'", con);
                da5.Fill(ds5);
                int count5 = ds5.Tables[0].Rows.Count;
                if (count5 == 0)
                {
                    DataSet ds55 = new DataSet();

                    SqlDataAdapter da55 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE jumlahitem = '" + jumlahReject + "' AND idbody = '" + idreject + "'", con);
                    da55.Fill(ds55);
                    int count55 = ds55.Tables[0].Rows.Count;
                    if (count55 == 0)
                    {
                        if (alasan == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                        }
                        else if (jumlahReject == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                        }
                        else if (jumlahReject == "0")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                        }
                        else {
                            cmd2.ExecuteNonQuery();
                            cmd.ExecuteNonQuery();
                            Response.Redirect("viewmintabeli.aspx?app2=" + app + "&&aks=purchasing");
                        }

                    }
                    else
                    {
                        DataSet ds22 = new DataSet();

                        SqlDataAdapter da22 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + app + "' AND reject = 'APPROVE'", con);
                        da22.Fill(ds22);
                        int count22 = ds22.Tables[0].Rows.Count;
                        if (count22 <= 1)
                        {
                            if (alasan == "")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                            }
                            else if (jumlahReject == "")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                            }
                            else if (jumlahReject == "0")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                            }
                            else {
                                cmd2.ExecuteNonQuery();
                                cmd4.ExecuteNonQuery();
                                cmd.ExecuteNonQuery();
                                Response.Redirect("approvemintabeli.aspx?q=purchasing");
                            }
                        }
                        else {
                            if (alasan == "")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                            }
                            else if (jumlahReject == "")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                            }
                            else if (jumlahReject == "0")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                            }
                            else {
                                cmd2.ExecuteNonQuery();
                                cmd.ExecuteNonQuery();
                                Response.Redirect("viewmintabeli.aspx?app2=" + app + "&&aks=purchasing");
                            }
                        }

                    }

                }
                else
                {
                    DataSet ds2 = new DataSet();

                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + app + "' AND reject = 'APPROVE'", con);
                    da2.Fill(ds2);
                    int count2 = ds2.Tables[0].Rows.Count;
                    if (count2 <= 1)
                    {
                        if (alasan == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                        }
                        else if (jumlahReject == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                        }
                        else if (jumlahReject == "0")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                        }
                        else {
                            cmd2.ExecuteNonQuery();
                            cmd4.ExecuteNonQuery();
                            cmd.ExecuteNonQuery();
                            Response.Redirect("approvemintabeli.aspx?q=purchasing");
                        }
                    }
                    else {
                        if (alasan == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                        }
                        else if (jumlahReject == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                        }
                        else if (jumlahReject == "0")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                        }
                        else {
                            cmd2.ExecuteNonQuery();
                            cmd.ExecuteNonQuery();
                            Response.Redirect("viewmintabeli.aspx?app2=" + app + "&&aks=purchasing");
                        }
                    }

                }

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject lebih besar dari yg tersisa !');</script>");
            }

        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Data yang sudah diapprove tidak bisa reject kembali');</script>");
        }

        con.Close();
    }
    protected void btnHarga_Click(object sender, EventArgs e)
    {
        string hargaItem = txtHarga.Text;
        string amblValueItem = Request.QueryString["id"];
        string amblValueNomor = Request.QueryString["app2"];
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbbody SET hargaitem = '" + hargaItem + "' WHERE nobody = '" + amblValueNomor + "' AND reject = 'APPROVE' AND idbody = '" + amblValueItem + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + amblValueNomor + "' AND rejecthead = 'N'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda tidak bisa setting harga, karena permintaan telah di Reject.');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + amblValueNomor + "' AND mengetahuifmb IS NULL", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda tidak bisa setting harga, karena permintaan telah di Approve.');</script>");
            }
            else
            {
                DataSet ds3 = new DataSet();
                SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + amblValueNomor + "' AND idbody = '" + amblValueItem + "' AND reject = 'APPROVE'", con);
                da3.Fill(ds3);
                int count3 = ds3.Tables[0].Rows.Count;
                if (count3 == 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda tidak bisa setting harga, karena permintaan telah di Reject.');</script>");
                }
                else
                {
                    if (hargaItem == "")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum mengisi harga baru');</script>");
                    }
                    else {
                        cmd.ExecuteNonQuery();
                        Response.Redirect("viewmintabeli.aspx?app2=" + amblValueNomor + "&&aks=purchasing");
                    }
                }
            }
        }
        con.Close();
    }
    protected void btnSetVendor_Click(object sender, EventArgs e)
    {
        string namaVendor = txtNamaVendor.Text;
        string amblValueItem = Request.QueryString["id"];
        string amblValueNomor = Request.QueryString["app2"];
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbbody SET vendor = '" + namaVendor + "' WHERE nobody = '" + amblValueNomor + "' AND reject = 'APPROVE' AND idbody = '" + amblValueItem + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + amblValueNomor + "' AND rejecthead = 'N'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda tidak bisa setting harga, karena permintaan telah di Reject.');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + amblValueNomor + "' AND mengetahuifmb IS NULL", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda tidak bisa setting harga, karena permintaan telah di Approve.');</script>");
            }
            else
            {
                DataSet ds3 = new DataSet();
                SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + amblValueNomor + "' AND idbody = '" + amblValueItem + "' AND reject = 'APPROVE'", con);
                da3.Fill(ds3);
                int count3 = ds3.Tables[0].Rows.Count;
                if (count3 == 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda tidak bisa setting harga, karena permintaan telah di Reject.');</script>");
                }
                else
                {
                    if (namaVendor == "")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum mengisi nama Vendor baru.');</script>");
                    }
                    else {
                        cmd.ExecuteNonQuery();
                        Response.Redirect("viewmintabeli.aspx?app2=" + amblValueNomor + "&&aks=purchasing");
                    }
                }
            }
        }
        con.Close();
    }

    protected void btnNama_Click(object sender, EventArgs e)
    {
        string namaBarang = txtNamaBarang.Text;
        string amblValueItem = Request.QueryString["id"];
        string amblValueNomor = Request.QueryString["app2"];
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbbody SET namaitem = '" + namaBarang + "' WHERE nobody = '" + amblValueNomor + "' AND reject = 'APPROVE' AND idbody = '" + amblValueItem + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + amblValueNomor + "' AND rejecthead = 'N'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda tidak bisa setting harga, karena permintaan telah di Reject.');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + amblValueNomor + "' AND mengetahuifmb IS NULL", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda tidak bisa setting harga, karena permintaan telah di Approve.');</script>");
            }
            else
            {
                DataSet ds3 = new DataSet();
                SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + amblValueNomor + "' AND idbody = '" + amblValueItem + "' AND reject = 'APPROVE'", con);
                da3.Fill(ds3);
                int count3 = ds3.Tables[0].Rows.Count;
                if (count3 == 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda tidak bisa setting harga, karena permintaan telah di Reject.');</script>");
                }
                else
                { 
                    if(namaBarang == "")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum mengisi nama yg anda ganti.');</script>");
                    }
                    else { 
                    cmd.ExecuteNonQuery();
                    Response.Redirect("viewmintabeli.aspx?app2=" + amblValueNomor + "&&aks=purchasing");
                    }
                }
            }
        }
        con.Close();
    }
    protected void btnNamaHeadpur_Click(object sender, EventArgs e)
    {
        string namaBarang = txtNamaBarangHeadpur.Text;
        string amblValueItem = Request.QueryString["id"];
        string amblValueNomor = Request.QueryString["app3"];
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbbody SET namaitem = '" + namaBarang + "' WHERE nobody = '" + amblValueNomor + "' AND reject = 'APPROVE' AND idbody = '" + amblValueItem + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + amblValueNomor + "' AND rejecthead = 'N'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda tidak bisa setting harga, karena permintaan telah di Reject.');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + amblValueNomor + "' AND approveheadpurc IS NULL", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda tidak bisa setting harga, karena permintaan telah di Approve.');</script>");
            }
            else
            {
                DataSet ds3 = new DataSet();
                SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + amblValueNomor + "' AND idbody = '" + amblValueItem + "' AND reject = 'APPROVE'", con);
                da3.Fill(ds3);
                int count3 = ds3.Tables[0].Rows.Count;
                if (count3 == 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda tidak bisa setting harga, karena permintaan telah di Reject.');</script>");
                }
                else
                {
                    if (namaBarang == "")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum mengisi nama yg anda ganti.');</script>");
                    }
                    else {
                        cmd.ExecuteNonQuery();
                        Response.Redirect("viewmintabeli.aspx?app3=" + amblValueNomor + "&&aks=headpur");
                    }
                }
            }
        }
        con.Close();
    }
    protected void btnApprovalHeadPur_Click(object sender, EventArgs e)
    {
        string idApproval = Request.QueryString["app3"];
        string userApproval = (string)(Session["username"]);
        DateTime myDate = DateTime.Now;
        string hariIni2 = myDate.ToString("MM/dd/yyyy");

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbhead SET approveheadpurc = '" + userApproval + "', tglapproveheadpurc = '" + hariIni2 + "' WHERE nofmbhead = '" + idApproval + "' AND rejecthead = 'N'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + idApproval + "' AND rejecthead = 'N' AND approveheadpurc IS NULL", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda Approve sudah tidak tersedia');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + idApproval + "' AND reject = 'APPROVE'", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda Approve sudah direject semua');</script>");
            }
            else
            {
                if (idApproval == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Kesalahan prosedur dalam pengambilan data, hubungi IT');</script>");
                }
                else
                {
                    DataSet dse = new DataSet();

                    SqlDataAdapter dae = new SqlDataAdapter("SELECT fmbhead.nofmbhead, fmbhead.pemohonfmb FROM fmbhead INNER JOIN fmbbody ON fmbhead.nofmbhead = fmbbody.nobody WHERE  fmbhead.nofmbhead = '" + idApproval + "' GROUP BY fmbhead.nofmbhead, fmbhead.pemohonfmb HAVING (SUM(fmbbody.hargaitem*fmbbody.jumlahitem) > 1999999)", con);
                    dae.Fill(dse);
                    int counte = dse.Tables[0].Rows.Count;
                    if (counte == 0)
                    {
                        cmd.ExecuteNonQuery();
                        Response.Redirect("approvemintabeli.aspx?q=headpur");
                    }
                    else { 
                    MailAddress from = new MailAddress("hmugen1991@gmail.com");
                    MailAddress to = new MailAddress("santo@hondamugen.co.id");
                    MailMessage message = new MailMessage(from, to);
                    message.Subject = "Permintaan pembelian no." + idApproval + "membutuhkan persetujuan anda.";
                    message.Body = @"<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda memiliki sebuah permintaan persetujuan untuk pembuatan sebuah Purchase Order, dengan nomor permintaan: <strong><center> " + idApproval + " </center></strong><br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=approvemintabeli.aspx?q=vpapp' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Daftar Approval</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>";
                    message.IsBodyHtml = true;
                    SmtpClient sc = new SmtpClient();
                    sc.Host = "smtp.gmail.com";
                    sc.Port = 587;
                    sc.EnableSsl = true;
                    sc.Credentials = new System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p");
                    sc.Send(message);
                        cmd.ExecuteNonQuery();
                        Response.Redirect("approvemintabeli.aspx?q=headpur");
                    }
                }
            }
        }
        con.Close(); 
    }
    protected void btnRejectAllHeadPur_Click(object sender, EventArgs e)
    {
        string idRejectAll = Request.QueryString["app3"];
        string alasanRejectAll = txtAlasanRejectAllHeadPur.Text;
        string userRejectAll = (string)(Session["username"]);

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbbody SET reject = 'REJECT', rejectoleh = '" + userRejectAll + "', alasanreject = '" + alasanRejectAll + "' WHERE nobody = '" + idRejectAll + "'", con);
        SqlCommand cmd2 = new SqlCommand("UPDATE fmbhead SET rejecthead = 'Y', rejectheadoleh = '" + userRejectAll + "', alasanrejecthead = '" + alasanRejectAll + "' WHERE nofmbhead = '" + idRejectAll + "'", con);
        SqlCommand cmd3 = new SqlCommand("DELETE FROM fmblamp WHERE nohead = '" + idRejectAll + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + idRejectAll + "' AND reject = 'APPROVE'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda reject sudah tidak tersedia');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + idRejectAll + "' AND rejecthead = 'N' AND disetujuifmb IS NOT NULL AND mengetahuifmb IS NOT NULL AND approveheadpurc IS NULL", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda reject sudah tidak tersedia');</script>");
            }
            else
            {
                if (alasanRejectAll == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Alasan anda me-Reject harus diisi');</script>");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    Response.Redirect("approvemintabeli.aspx?q=headpur");
                }
            }
        }
        con.Close();
    }
    protected void btnRejectHeadPur_Click(object sender, EventArgs e)
    {
        string alasan = txtAlasanRejectHeadPur.Text;
        string jumlahReject = txtJumlahRejectHeadpur.Text;
        string idreject = Request.QueryString["id"];
        string app = Request.QueryString["app3"];
        string user = (string)(Session["username"]);

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("DELETE FROM fmbbody WHERE idbody = '" + idreject + "'", con);
        SqlCommand cmd2 = new SqlCommand("INSERT INTO fmbbody(nobody, namaitem, tujuanitem, jumlahitem, hargaitem, pusatbiaya, reject, alasanreject, rejectoleh, vendor) SELECT nobody, namaitem, tujuanitem, '" + jumlahReject + "', hargaitem, pusatbiaya, 'REJECT', '" + alasan + "', '" + user + "', vendor FROM fmbbody WHERE idbody = '" + idreject + "' ", con);
        SqlCommand cmd3 = new SqlCommand("DELETE FROM fmblamp WHERE nohead = '" + app + "'", con);
        SqlCommand cmd4 = new SqlCommand("UPDATE fmbhead SET rejecthead = 'Y', rejectheadoleh = '" + user + "', alasanrejecthead = '" + alasan + "' WHERE nofmbhead = '" + app + "'", con);
        SqlCommand cmd5 = new SqlCommand("UPDATE fmbbody SET jumlahitem = jumlahitem -  '" + jumlahReject + "' WHERE idbody = '" + idreject + "' AND reject = 'APPROVE'", con);

        con.Open();


        DataSet ds3 = new DataSet();

        SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + app + "' AND rejecthead = 'N' AND approveheadpurc IS NOT NULL", con);
        da3.Fill(ds3);
        int count3 = ds3.Tables[0].Rows.Count;
        if (count3 == 0)
        {
            DataSet ds4 = new DataSet();

            SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE (jumlahitem < '" + jumlahReject + "') AND idbody = '" + idreject + "'", con);
            da4.Fill(ds4);
            int count4 = ds4.Tables[0].Rows.Count;
            if (count4 == 0)
            {
                DataSet ds5 = new DataSet();

                SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE jumlahitem <= 1 AND idbody = '" + idreject + "'", con);
                da5.Fill(ds5);
                int count5 = ds5.Tables[0].Rows.Count;
                if (count5 == 0)
                {
                    DataSet ds55 = new DataSet();

                    SqlDataAdapter da55 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE jumlahitem = '" + jumlahReject + "' AND idbody = '" + idreject + "'", con);
                    da55.Fill(ds55);
                    int count55 = ds55.Tables[0].Rows.Count;
                    if (count55 == 0)
                    {
                        if (alasan == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                        }
                        else if (jumlahReject == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                        }
                        else if (jumlahReject == "0")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                        }
                        else {
                            cmd2.ExecuteNonQuery();
                            cmd5.ExecuteNonQuery();
                            Response.Redirect("viewmintabeli.aspx?app3=" + app + "&&aks=headpur");
                        }

                    }
                    else
                    {
                        DataSet ds22 = new DataSet();

                        SqlDataAdapter da22 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + app + "' AND reject = 'APPROVE'", con);
                        da22.Fill(ds22);
                        int count22 = ds22.Tables[0].Rows.Count;
                        if (count22 <= 1)
                        {
                            if (alasan == "")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                            }
                            else if (jumlahReject == "")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                            }
                            else if (jumlahReject == "0")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                            }
                            else {
                                cmd2.ExecuteNonQuery();
                                cmd4.ExecuteNonQuery();
                                cmd.ExecuteNonQuery();
                                Response.Redirect("approvemintabeli.aspx?q=headpur");
                            }
                        }
                        else {
                            if (alasan == "")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                            }
                            else if (jumlahReject == "")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                            }
                            else if (jumlahReject == "0")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                            }
                            else {
                                cmd2.ExecuteNonQuery();
                                cmd.ExecuteNonQuery();
                                Response.Redirect("viewmintabeli.aspx?app3=" + app + "&&aks=headpur");
                            }
                        }

                    }

                }
                else
                {
                    DataSet ds2 = new DataSet();

                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + app + "' AND reject = 'APPROVE'", con);
                    da2.Fill(ds2);
                    int count2 = ds2.Tables[0].Rows.Count;
                    if (count2 <= 1)
                    {
                        if (alasan == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                        }
                        else if (jumlahReject == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                        }
                        else if (jumlahReject == "0")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                        }
                        else {
                            cmd2.ExecuteNonQuery();
                            cmd4.ExecuteNonQuery();
                            cmd.ExecuteNonQuery();
                            Response.Redirect("approvemintabeli.aspx?q=headpur");
                        }
                    }
                    else {
                        if (alasan == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                        }
                        else if (jumlahReject == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                        }
                        else if (jumlahReject == "0")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                        }
                        else {
                            cmd2.ExecuteNonQuery();
                            cmd.ExecuteNonQuery();
                            Response.Redirect("viewmintabeli.aspx?app3=" + app + "&&aks=headpur");
                        }
                    }

                }

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject lebih besar dari yg tersisa !');</script>");
            }

        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Data yang sudah diapprove tidak bisa reject kembali');</script>");
        }

        con.Close();
    }
    protected void btnApprovalVpapp_Click(object sender, EventArgs e)
    {
        string idApproval = Request.QueryString["app4"];
        string userApproval = (string)(Session["username"]);
        DateTime myDate = DateTime.Now;
        string hariIni2 = myDate.ToString("MM/dd/yyyy");

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbhead SET disetujui2fmb = '" + userApproval + "', tgldisetujui2fmb = '" + hariIni2 + "' WHERE nofmbhead = '" + idApproval + "' AND rejecthead = 'N'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + idApproval + "' AND rejecthead = 'N' AND disetujui2fmb IS NULL", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda Approve sudah tidak tersedia');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + idApproval + "' AND reject = 'APPROVE'", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda Approve sudah direject semua');</script>");
            }
            else
            {
                if (idApproval == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Kesalahan prosedur dalam pengambilan data, hubungi IT');</script>");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    Response.Redirect("approvemintabeli.aspx?q=vpapp");
                }
            }
        }
        con.Close();
    }
    protected void btnRejectVpapp_Click(object sender, EventArgs e)
    {
        string alasan = txtAlasanRejectVpapp.Text;
        string jumlahReject = txtJumlahRejectVpapp.Text;
        string idreject = Request.QueryString["id"];
        string app = Request.QueryString["app4"];
        string user = (string)(Session["username"]);

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("DELETE FROM fmbbody WHERE idbody = '" + idreject + "'", con);
        SqlCommand cmd2 = new SqlCommand("INSERT INTO fmbbody(nobody, namaitem, tujuanitem, jumlahitem, hargaitem, pusatbiaya, reject, alasanreject, rejectoleh, vendor) SELECT nobody, namaitem, tujuanitem, '" + jumlahReject + "', hargaitem, pusatbiaya, 'REJECT', '" + alasan + "', '" + user + "', vendor FROM fmbbody WHERE idbody = '" + idreject + "' ", con);
        SqlCommand cmd3 = new SqlCommand("DELETE FROM fmblamp WHERE nohead = '" + app + "'", con);
        SqlCommand cmd4 = new SqlCommand("UPDATE fmbhead SET rejecthead = 'Y', rejectheadoleh = '" + user + "', alasanrejecthead = '" + alasan + "' WHERE nofmbhead = '" + app + "'", con);
        SqlCommand cmd5 = new SqlCommand("UPDATE fmbbody SET jumlahitem = jumlahitem -  '" + jumlahReject + "' WHERE idbody = '" + idreject + "' AND reject = 'APPROVE'", con);

        con.Open();


        DataSet ds3 = new DataSet();

        SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + app + "' AND rejecthead = 'N' AND disetujui2fmb IS NOT NULL", con);
        da3.Fill(ds3);
        int count3 = ds3.Tables[0].Rows.Count;
        if (count3 == 0)
        {
            DataSet ds4 = new DataSet();

            SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE (jumlahitem < '" + jumlahReject + "') AND idbody = '" + idreject + "'", con);
            da4.Fill(ds4);
            int count4 = ds4.Tables[0].Rows.Count;
            if (count4 == 0)
            {
                DataSet ds5 = new DataSet();

                SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE jumlahitem <= 1 AND idbody = '" + idreject + "'", con);
                da5.Fill(ds5);
                int count5 = ds5.Tables[0].Rows.Count;
                if (count5 == 0)
                {
                    cmd2.ExecuteNonQuery();
                    cmd5.ExecuteNonQuery();
                    Response.Redirect("viewmintabeli.aspx?app4=" + app + "&&aks=vpapp");

                }
                else
                {
                    DataSet ds2 = new DataSet();

                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + app + "' AND reject = 'APPROVE'", con);
                    da2.Fill(ds2);
                    int count2 = ds2.Tables[0].Rows.Count;
                    if (count2 <= 1)
                    {
                        cmd2.ExecuteNonQuery();
                        cmd4.ExecuteNonQuery();
                        cmd.ExecuteNonQuery();
                        Response.Redirect("approvemintabeli.aspx?q=vpapp");
                    }
                    else {
                        cmd2.ExecuteNonQuery();
                        cmd.ExecuteNonQuery();
                        Response.Redirect("viewmintabeli.aspx?app4=" + app + "&&aks=vpapp");
                    }

                }

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject lebih besar dari yg tersisa !');</script>");
            }

        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Data yang sudah diapprove tidak bisa reject kembali');</script>");
        }

        con.Close();
    }
    protected void btnRejectAllVpapp_Click(object sender, EventArgs e)
    {
        string idRejectAll = Request.QueryString["app4"];
        string alasanRejectAll = txtAlasanRejectAllVpapp.Text;
        string userRejectAll = (string)(Session["username"]);

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbbody SET reject = 'REJECT', rejectoleh = '" + userRejectAll + "', alasanreject = '" + alasanRejectAll + "' WHERE nobody = '" + idRejectAll + "' AND reject = 'APPROVE'", con);
        SqlCommand cmd2 = new SqlCommand("UPDATE fmbhead SET rejecthead = 'Y', rejectheadoleh = '" + userRejectAll + "', alasanrejecthead = '" + alasanRejectAll + "' WHERE nofmbhead = '" + idRejectAll + "'", con);
        SqlCommand cmd3 = new SqlCommand("DELETE FROM fmblamp WHERE nohead = '" + idRejectAll + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + idRejectAll + "' AND reject = 'APPROVE'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda reject sudah tidak tersedia');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + idRejectAll + "' AND rejecthead = 'N' AND disetujui2fmb IS NULL", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data yang ingin anda reject sudah tidak tersedia');</script>");
            }
            else
            {
                if (alasanRejectAll == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Alasan anda me-Reject harus diisi');</script>");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    Response.Redirect("approvemintabeli.aspx?q=vpapp");
                }
            }
        }
        con.Close();
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                string app = Request.QueryString["app2"];
                string filename = System.IO.Path.GetFileName(FileUpload1.FileName);
                lblStatus.Text = "Upload status: berhasil!";
                string keTerangan = txtKet.Text;
                string user = (string)(Session["username"]);
                string lokasi = "lamp";
                DateTime toDay = DateTime.Now;
                string hariIni = toDay.ToString("MM/dd/yyyy hh:mm:ss tt");
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO fmblamp (nohead, lokasifile, keterangan, username, proses) VALUES ('" + app + "', '" + lokasi + "/" + filename + "', '" + keTerangan + "', '" + user + "', '" + user + "" + hariIni + "')", con);
                con.Open();
                if (keTerangan == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Anda belum mengisi keterangan dari lampiran !');</script>");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    FileUpload1.SaveAs(Server.MapPath("~/lamp/") + filename);
                    Response.Redirect("viewmintabeli.aspx?app2=" + app + "&&aks=purchasing");
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
