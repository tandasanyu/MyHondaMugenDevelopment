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
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;


public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userAkses = (string)(Session["username"]);
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'IT & GA -- VIEW MENU'", con);

        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            mnITGA.Visible = false;
        }
        else
        {
            mnITGA.Visible = true;
        }

        DataSet ds2 = new DataSet();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERBAIKAN HARDWARE & SOFTWARE -- VIEW MENU'", con);

        da2.Fill(ds2);
        int count2 = ds2.Tables[0].Rows.Count;
        if (count2 == 0)
        {
            mnHardSoft.Visible = false;
        }
        else
        {
            mnHardSoft.Visible = true;
        }
        DataSet ds3 = new DataSet();
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERBAIKAN HARDWARE & SOFTWARE -- LAPORAN'", con);

        da3.Fill(ds3);
        int count3 = ds3.Tables[0].Rows.Count;
        if (count3 == 0)
        {
            mnLapHardSoft.Visible = false;
        }
        else
        {
            mnLapHardSoft.Visible = true;
        }
        DataSet ds4 = new DataSet();
        SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- VIEW MENU'", con);

        da4.Fill(ds4);
        int count4 = ds4.Tables[0].Rows.Count;
        if (count4 == 0)
        {
            mnMintaBeli.Visible = false;
        }
        else
        {
            mnMintaBeli.Visible = true;
        }
        DataSet ds5 = new DataSet();
        SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'BODY & PAINT -- VIEW MENU'", con);

        da5.Fill(ds5);
        int count5 = ds5.Tables[0].Rows.Count;
        if (count5 == 0)
        {
            mnBody.Visible = false;
        }
        else
        {
            mnBody.Visible = true;
        }
        DataSet ds6 = new DataSet();
        SqlDataAdapter da6 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM JOB CONTROL FORMAN -- VIEW MENU'", con);

        da6.Fill(ds6);
        int count6 = ds6.Tables[0].Rows.Count;
        if (count6 == 0)
        {
            mnJobControl.Visible = false;
        }
        else
        {
            mnJobControl.Visible = true;
        }
        DataSet ds7 = new DataSet();
        SqlDataAdapter da7 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'POSS -- VIEW MENU'", con);

        da7.Fill(ds7);
        int count7 = ds7.Tables[0].Rows.Count;
        if (count7 == 0)
        {
            mnPoss.Visible = false;
        }
        else
        {
            mnPoss.Visible = true;
        }
        con.Close();


        DataSet ds8 = new DataSet();
        SqlDataAdapter da8 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM JOB CONTROL FORMAN PURI -- VIEW MENU'", con);

        da8.Fill(ds8);
        int count8 = ds8.Tables[0].Rows.Count;
        if (count8 == 0)
        {
            mnJobControlPuri.Visible = false;
        }
        else
        {
            mnJobControlPuri.Visible = true;
        }

        if (Session["username"] != null)
        {
            lblUsername.Text = "" + Session["username"];
        }
        else
        {
            Response.Redirect("default.aspx");
        }

        string user = (string)(Session["username"]);
        if (user == "KOMANG")
        {
            mnDatabase.Visible = true;
        }
        else if (user == "JUPRI")
        {
            mnDatabase.Visible = true;
        }
        else if (user == "AZIS")
        {
            mnDatabase.Visible = true;
        }
        else if (user == "EBNU")
        {
            mnDatabase.Visible = true;
        }
        else
        {
            mnDatabase.Visible = false;
        }
        con.Close();
        string userstat = (string)(Session["username"]);
        string ccsss = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection conek = new SqlConnection(ccsss);
        conek.Open();

        DataSet ddddssss = new DataSet();

        SqlDataAdapter dddddaaaa = new SqlDataAdapter("SELECT fmbhead.nofmbhead, SUM(fmbbody.hargaitem*fmbbody.jumlahitem) AS total, fmbhead.pemohonfmb FROM fmbhead INNER JOIN fmbbody ON fmbhead.nofmbhead = fmbbody.nobody INNER JOIN tb_user ON fmbhead.pemohonfmb = tb_user.username INNER JOIN divisi ON tb_user.kddivisi = divisi.kddivisi WHERE (headdivisi = '" + userstat + "' AND disetujuifmb IS NULL AND rejecthead = 'N') GROUP BY fmbhead.nofmbhead, fmbhead.pemohonfmb", conek);
        dddddaaaa.Fill(ddddssss);
        int countzx = ddddssss.Tables[0].Rows.Count;
        if (countzx == 0)
        {
            notifhead.Visible = false;
        }
        else {
            notifhead.Visible = true;
        }
        conek.Close();
        string userstat2 = (string)(Session["username"]);
        string ccssspurc = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection conekpurc = new SqlConnection(ccssspurc);
        conekpurc.Open();

        DataSet ddddsssspurc = new DataSet();

        SqlDataAdapter dddddaaaapurc = new SqlDataAdapter("SELECT fmbhead.nofmbhead, SUM(fmbbody.hargaitem*fmbbody.jumlahitem) AS total, fmbhead.pemohonfmb FROM fmbhead INNER JOIN fmbbody ON fmbhead.nofmbhead = fmbbody.nobody WHERE disetujuifmb IS NOT NULL AND mengetahuifmb IS NULL AND rejecthead = 'N' AND '" + userstat2 +"' = 'EKO' GROUP BY fmbhead.nofmbhead, fmbhead.pemohonfmb", conekpurc);
        dddddaaaapurc.Fill(ddddsssspurc);
        int countzxpurc = ddddsssspurc.Tables[0].Rows.Count;
        if (countzxpurc == 0)
        {
            notifpurc.Visible = false;
        }
        else {
            notifpurc.Visible = true;
        }
        conekpurc.Close();
        string userstat3 = (string)(Session["username"]);
        string ccssshpurc = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection conekhpurc = new SqlConnection(ccssshpurc);
        conekhpurc.Open();

        DataSet ddddsssshpurc = new DataSet();

        SqlDataAdapter dddddaaaahpurc = new SqlDataAdapter("SELECT fmbhead.nofmbhead, SUM(fmbbody.hargaitem*fmbbody.jumlahitem) AS total, fmbhead.pemohonfmb FROM fmbhead INNER JOIN fmbbody ON fmbhead.nofmbhead = fmbbody.nobody WHERE disetujuifmb IS NOT NULL AND mengetahuifmb IS NOT NULL AND approveheadpurc IS NULL AND rejecthead = 'N' AND '" + userstat3 + "' = 'TINI' GROUP BY fmbhead.nofmbhead, fmbhead.pemohonfmb", conekhpurc);
        dddddaaaahpurc.Fill(ddddsssshpurc);
        int countzxhpurc = ddddsssshpurc.Tables[0].Rows.Count;
        if (countzxhpurc == 0)
        {
            notifheadpur.Visible = false;
        }
        else {
            notifheadpur.Visible = true;
        }
        conekhpurc.Close();


    }
}
