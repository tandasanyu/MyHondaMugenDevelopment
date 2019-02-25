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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userAkses = (string)(Session["username"]);
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        con.Open();
        DataSet ds1 = new DataSet();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- VIEW MENU'", con);

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
        DataSet ds2 = new DataSet();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- NEW DATA'", con);

        da2.Fill(ds2);
        int count2 = ds2.Tables[0].Rows.Count;
        if (count2 == 0)
        {
            Button1.Visible = false;
        }
        else
        {
            Button1.Visible = true;
        }
        DataSet ds3 = new DataSet();
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- HEAD APPROVAL'", con);

        da3.Fill(ds3);
        int count3 = ds3.Tables[0].Rows.Count;
        if (count3 == 0)
        {
            mnHeadApp.Visible = false;
        }
        else
        {
            mnHeadApp.Visible = true;
        }
        DataSet ds4 = new DataSet();
        SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- PURCHASE APPROVAL'", con);

        da4.Fill(ds4);
        int count4 = ds4.Tables[0].Rows.Count;
        if (count4 == 0)
        {
            mnPurcApp.Visible = false;
        }
        else
        {
            mnPurcApp.Visible = true;
        }
        DataSet ds5 = new DataSet();
        SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- HEAD PURCHASE APPROVAL'", con);

        da5.Fill(ds5);
        int count5 = ds5.Tables[0].Rows.Count;
        if (count5 == 0)
        {
            mnHPurcApp.Visible = false;
        }
        else
        {
            mnHPurcApp.Visible = true;
        }
        DataSet ds6 = new DataSet();
        SqlDataAdapter da6 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- VICE PRESIDENT APPROVAL'", con);

        da6.Fill(ds6);
        int count6 = ds6.Tables[0].Rows.Count;
        if (count6 == 0)
        {
            mnVpApp.Visible = false;
        }
        else
        {
            mnVpApp.Visible = true;
        }
        DataSet ds7 = new DataSet();
        SqlDataAdapter da7 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- NEW PURCHASE ORDER'", con);

        da7.Fill(ds7);
        int count7 = ds7.Tables[0].Rows.Count;
        if (count7 == 0)
        {
            mnNewPo.Visible = false;
            mnDaftarPO.Visible = false;
        }
        else
        {
            mnNewPo.Visible = true;
            mnDaftarPO.Visible = true;
        }
        DataSet ds8 = new DataSet();
        SqlDataAdapter da8 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- TERIMA BARANG'", con);

        da8.Fill(ds8);
        int count8 = ds8.Tables[0].Rows.Count;
        if (count8 == 0)
        {
           mnTerimaBarang.Visible = false;
        }
        else
        {
            mnTerimaBarang.Visible = true;
        }
        DataSet ds9 = new DataSet();
        SqlDataAdapter da9 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- VIEW STOK'", con);

        da9.Fill(ds9);
        int count9 = ds9.Tables[0].Rows.Count;
        if (count9 == 0)
        {
            mnViewStok.Visible = false;
        }
        else
        {
            mnViewStok.Visible = true;
        }
        DataSet ds10 = new DataSet();
        SqlDataAdapter da10 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- MASTER DATA'", con);

        da10.Fill(ds10);
        int count10 = ds10.Tables[0].Rows.Count;
        if (count10 == 0)
        {
            mnMaster.Visible = false;
        }
        else
        {
            mnMaster.Visible = true;
        }
        DataSet ds11 = new DataSet();
        SqlDataAdapter da11 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- DIVISI APPROVAL'", con);

        da11.Fill(ds11);
        int count11 = ds11.Tables[0].Rows.Count;
        if (count11 == 0)
        {
            mnDivisiApp.Visible = false;
        }
        else
        {
            mnDivisiApp.Visible = true;
        }
        con.Close();
        string noBukti = Request.QueryString["q"];
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp1 = Request.QueryString["q"];
            command.CommandText = "SELECT SUM(jumlahitem*hargaitem) AS totalharga, userfmb, convert(varchar, tglpemohonfmb, 106) as tglpemohonfmb, mengetahuifmb,  convert(varchar, tglmengetahuifmb, 106) as tglmengetahuifmb, approveheadpurc,  convert(varchar, tglapproveheadpurc, 106) AS tglapproveheadpurc, disetujuifmb,  convert(varchar, tgldisetujuifmb, 106) as tgldisetujuifmb, disetujui2fmb,  convert(varchar, tgldisetujui2fmb, 106) AS tgldisetujui2fmb  FROM [fmbbody] INNER JOIN fmbhead ON fmbhead.nofmbhead = fmbbody.nobody WHERE nobody = '" + ambApp1 + "' AND reject = 'APPROVE' GROUP BY userfmb, tglpemohonfmb, tglpemohonfmb, mengetahuifmb, tglmengetahuifmb, approveheadpurc, tglapproveheadpurc, disetujuifmb, tgldisetujuifmb, disetujui2fmb, tgldisetujui2fmb";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalharga = reader["totalharga"].ToString();
                    string userFmb = reader["userfmb"].ToString();
                    string tglPemohonFmb = reader["tglpemohonfmb"].ToString();
                    string disetujuiFmb = reader["disetujuifmb"].ToString();
                    string tglDisetujuiFmb = reader["tgldisetujuifmb"].ToString();
                    string mengetahuiFmb = reader["mengetahuifmb"].ToString();
                    string tglMengetahuiFmb = reader["tglmengetahuifmb"].ToString();
                    string headPurc = reader["approveheadpurc"].ToString();
                    string tglHeadPurc = reader["tglapproveheadpurc"].ToString();
                    string vicePresident = reader["disetujui2fmb"].ToString();
                    string tglVicePresident = reader["tgldisetujui2fmb"].ToString();

                    if (totalharga == "")
                    {
                        lblTotal.Text = "0";
                        lblNamaPemohon.Text = userFmb;
                        lblTglPemohon.Text = tglPemohonFmb;

                        if (disetujuiFmb == "")
                        {
                            lblAppHead.Visible = false;
                        }
                        else 
                        {
                            lblNamaHead.Text = disetujuiFmb;
                            lblTglHead.Text = tglDisetujuiFmb;
                            lblAppHead.Visible = true;
                        }
                       
                        if (headPurc == "")
                        {
                            lblAppHeadPurc.Visible = false;
                        }
                        else
                        {
                            lblNamaHeadPurc.Text = headPurc;
                            lblTglHeadPurc.Text = tglHeadPurc;
                            lblAppHeadPurc.Visible = true;
                        }
                        if (vicePresident == "")
                        {
                            lblAppVicep.Visible = false;
                        }
                        else
                        {
                            lblNamaVicep.Text = vicePresident;
                            lblTglVicep.Text = tglVicePresident;
                            lblAppVicep.Visible = true;
                        }
                    }
                    else
                    {
                        lblTotal.Text = decimal.Parse(totalharga).ToString("0,0,0");
                        lblNamaPemohon.Text = userFmb;
                        lblTglPemohon.Text = tglPemohonFmb;
                        if (disetujuiFmb == "")
                        {
                            lblAppHead.Visible = false;
                        }
                        else
                        {
                            lblNamaHead.Text = disetujuiFmb;
                            lblTglHead.Text = tglDisetujuiFmb;
                            lblAppHead.Visible = true;
                        }
                       
                        if (headPurc == "")
                        {
                            lblAppHeadPurc.Visible = false;
                        }
                        else
                        {
                            lblNamaHeadPurc.Text = headPurc;
                            lblTglHeadPurc.Text = tglHeadPurc;
                            lblAppHeadPurc.Visible = true;
                        }
                        if (vicePresident == "")
                        {
                            lblAppVicep.Visible = false;
                        }
                        else
                        {
                            lblNamaVicep.Text = vicePresident;
                            lblTglVicep.Text = tglVicePresident;
                            lblAppVicep.Visible = true;
                        }
                    }

                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("listmintabeli.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("mintabeli.aspx");
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        Response.Redirect("mintabeli.aspx?q2=" + drpView.Text +"");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                string app = Request.QueryString["q"];
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
                    Response.Redirect("mintabeli.aspx?q=" + app + "#lampiran");
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
