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
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class viewreq : System.Web.UI.Page
{
    protected void GetTime(object sender, EventArgs e)
    {
        GridView3.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string userAkses = (string)(Session["username"]);
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        con.Open();
        DataSet ds1 = new DataSet();
        SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- NEW PURCHASE ORDER'", con);

        da1.Fill(ds1);
        int count1 = ds1.Tables[0].Rows.Count;
        if (count1 == 0)
        {
           Button1.Visible = false;
        }
        else
        {
            Button1.Visible = true;
        }
        con.Close();

        string noBukti = Request.QueryString["q"];
        lblNoBukti.Text = "No. " + noBukti;
        txtNoReq.Text = noBukti;
        txtNoReq.Attributes.Add("readonly", "readonly");
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp1 = Request.QueryString["q"];
            command.CommandText = "SELECT count(idbody) AS totalitem FROM fmbbody WHERE nopurchaseorder IS NULL AND nobody = '" + noBukti + "' AND reject = 'APPROVE'";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalItem = reader["totalitem"].ToString();
                   if(totalItem == "0")
                    {
                        linkProsesPo.Visible = false;
                    }
                   else
                    {
                        linkProsesPo.Visible = true;
                    }
                    
                }
            }
        }
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp1 = Request.QueryString["q"];
            command.CommandText = "SELECT SUM(jumlahitem*hargaitem) AS totalharga, pemohonfmb, convert(varchar, tglpemohonfmb, 106) AS tglpemohonfmb, mengetahuifmb, convert(varchar, tglmengetahuifmb, 106) AS tglmengetahuifmb, approveheadpurc, convert(varchar, tglapproveheadpurc, 106) AS tglapproveheadpurc, disetujuifmb, convert(varchar, tgldisetujuifmb, 106) AS tgldisetujuifmb, disetujui2fmb, convert(varchar, tgldisetujui2fmb,106) AS tgldisetujui2fmb  FROM [fmbbody] INNER JOIN fmbhead ON fmbhead.nofmbhead = fmbbody.nobody WHERE nobody = '" + ambApp1 + "' AND reject = 'APPROVE' GROUP BY pemohonfmb, tglpemohonfmb, tglpemohonfmb, mengetahuifmb, tglmengetahuifmb, approveheadpurc, tglapproveheadpurc, disetujuifmb, tgldisetujuifmb, disetujui2fmb, tgldisetujui2fmb";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalharga = reader["totalharga"].ToString();
                    string pemohonFmb = reader["pemohonfmb"].ToString();
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
                        lblNamaPemohon.Text = pemohonFmb;
                        lblTglPemohon.Text = tglPemohonFmb;

                        if (disetujuiFmb == "")
                        {

                        }
                        else
                        {
                            lblNamaHead.Text = disetujuiFmb;
                            lblTglHead.Text = tglDisetujuiFmb;
                        }
                        if (mengetahuiFmb == "")
                        {
                            lblAppPurc.Visible = false;
                        }
                        else
                        {
                            lblNamaPurc.Text = mengetahuiFmb;
                            lblTglPurc.Text = tglMengetahuiFmb;
                            lblAppPurc.Visible = true;
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
                        lblNamaPemohon.Text = pemohonFmb;
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
                        if (mengetahuiFmb == "")
                        {
                            lblAppPurc.Visible = false;
                        }
                        else
                        {
                            lblNamaPurc.Text = mengetahuiFmb;
                            lblTglPurc.Text = tglMengetahuiFmb;
                            lblAppPurc.Visible = true;
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
        string noReq = txtNoReq.Text;
        string vendor = txtVendor.Text;
        string shipper = txtShipper.Text;
        string shippingMethod = txtShippingMethod.Text;
        string shippingTerm = txtShippingTerm.Text;
        string tOp = txtTop.Text;
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection connection = new SqlConnection(cs);
        DataSet ds = new DataSet();
        DateTime blnIni = DateTime.Now;
        string blnRini = blnIni.ToString("MM");
        string thnRini = blnIni.ToString("yyyy");
        string sql = "SELECT POFMB_no_po FROM pofmb WHERE DATEPART(month, POFMB_tgl_po) = '" + blnRini + "' AND DATEPART(year, POFMB_tgl_po) = '" + thnRini + "'";
        DateTime myDate = DateTime.Now;
        string strTime = myDate.ToString("yyyy/PO/MM-");
        string tglSkrng = myDate.ToString("MM/dd/yyyy hh:mm:ss tt");
        string pemohon = Session["username"].ToString();
        var maxWidth = 5;
        try
        {

            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(ds);
            string noaBukti = strTime + ds.Tables[0].Rows.Count.ToString().PadLeft(maxWidth, '0');
            if (vendor == "") {
                   ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Ada data yg kosong, Silahkan pilih data Vendor harus dipilih.');</script>");
               }
               else if(shipper == ""){
                   ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Ada data yang kosong, Silahkan pilih data Cabang Dealer harus dipilih');</script>");
               }
               else if (noReq == "")
               {
                   ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Kesalahan prosedur saat pengambilan data, proses tidak dapat dilanjutkan');</script>");
               }
               
               else if (shippingMethod == "") {
                   ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Ada data yang kosong, silahkan pilih metode penyampaian barang harus diisi');</script>");
               }
               else if (shippingMethod == "") {
                   ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Ada data yang kosong, silahkan isi metode prosedur pengiriman barang harus diisi');</script>");
               }
               else if (tOp == "")
               {
                   ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Ada datang yang kosong, silahkan isi metode pembayaran harus diisi');</script>");
               }
               else {

                  
                    if (shipper == "128")
                    {
                        string cs2 = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
                        SqlConnection con = new SqlConnection(cs2);
                        SqlCommand cmd = new SqlCommand("INSERT INTO pofmb (POFMB_no_po, POFMB_tgl_po, POFMB_nama_vendor, POFMB_nama_shipper, POFMB_telp_shipper, POFMB_fax_shipper, POFMB_email_shipper, POFMB_shipping_method, POFMB_shipping_term,  POFMB_term_of_payment) VALUES ('" + noaBukti + "', '" + tglSkrng + "', '" + vendor + "',  'PT. Mitrausaha Gentaniaga (MUGEN PURI)', '(021) 5835 8000 (Showroom)', '(021) 5835 7942', 'purchasing@hondamugen.co.id', '" + shippingMethod + "', '" + shippingTerm + "', '" + tOp + "')", con);
                        SqlCommand cmd2 = new SqlCommand("UPDATE fmbbody SET nopurchaseorder = '" + noaBukti + "' WHERE nobody = '" + noReq + "' AND reject = 'APPROVE' AND vendor = '" + txtVendor.Text + "'", con);
                        con.Open();
                        DataSet ds11 = new DataSet();

                        SqlDataAdapter da11 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + noReq + "' AND reject = 'APPROVE' AND vendor = '" + txtVendor.Text + "'", con);
                        da11.Fill(ds11);
                        int count11 = ds11.Tables[0].Rows.Count;
                        if (count11 == 0)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Data yang dibuat tidak tersedia !');</script>");

                        }
                        else
                        {
                            DataSet ds12 = new DataSet();
                            SqlDataAdapter da12 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + noReq + "' AND nopurchaseorder IS NULL AND vendor = '" + txtVendor.Text + "'", con);
                            da12.Fill(ds12);
                            int count12 = ds12.Tables[0].Rows.Count;
                            if (count12 == 0)
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Data yang dibuat sudah pernah dibuat Purchase Order !');</script>");

                            }
                            else
                            {
                                DataSet ds13 = new DataSet();
                                SqlDataAdapter da13 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + noReq + "' AND rejecthead = 'N'", con);
                                da13.Fill(ds13);
                                int count13 = ds13.Tables[0].Rows.Count;
                                if (count13 == 0)
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Permintaan tersebut telah direject !');</script>");

                                }
                                else
                                {
                                    DataSet ds14 = new DataSet();
                                    SqlDataAdapter da14 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + noReq + "' AND disetujuifmb IS NOT NULL", con);
                                    da14.Fill(ds14);
                                    int count14 = ds14.Tables[0].Rows.Count;
                                    if (count14 == 0)
                                    {
                                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Permintaan Pembelian belum di setujui oleh Kepala Divisi !');</script>");

                                    }
                                    else
                                    {
                                        DataSet ds15 = new DataSet();
                                        SqlDataAdapter da15 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + noReq + "' AND mengetahuifmb IS NOT NULL", con);
                                        da15.Fill(ds15);
                                        int count15 = ds15.Tables[0].Rows.Count;
                                        if (count15 == 0)
                                        {
                                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Permintaan Pembelian belum di setujui oleh Purchasing !');</script>");

                                        }
                                        else
                                        {
                                            DataSet ds16 = new DataSet();
                                            SqlDataAdapter da16 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + noReq + "' AND approveheadpurc IS NOT NULL", con);
                                            da16.Fill(ds16);
                                            int count16 = ds16.Tables[0].Rows.Count;
                                            if (count16 == 0)
                                            {
                                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Permintaan Pembelian belum di setujui oleh Kepala Purchasing !');</script>");

                                            }
                                            else
                                            {
                                                cmd.ExecuteNonQuery();
                                                cmd2.ExecuteNonQuery();
                                                Response.Redirect("printpo.aspx?q=" + noaBukti + "");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        con.Close();
                    }
                    else if (shipper == "112")
                    {
                        string cs2 = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
                        SqlConnection con = new SqlConnection(cs2);
                        SqlCommand cmd = new SqlCommand("INSERT INTO pofmb (POFMB_no_po, POFMB_tgl_po, POFMB_nama_vendor,  POFMB_nama_shipper, POFMB_telp_shipper, POFMB_fax_shipper, POFMB_email_shipper, POFMB_shipping_method, POFMB_shipping_term, POFMB_term_of_payment) VALUES ('" + noaBukti + "', '" + tglSkrng + "', '" + vendor + "', 'PT. Mitrausaha Gentaniaga (MUGEN PASAR MINGGU)', '(021) 797 3000 (Showroom)', '(021) 797 3834', 'purchasing@hondamugen.co.id', '" + shippingMethod + "', '" + shippingTerm + "', '" + tOp + "')", con);
                        SqlCommand cmd2 = new SqlCommand("UPDATE fmbbody SET nopurchaseorder = '" + noaBukti + "' WHERE nobody = '" + noReq + "' AND reject = 'APPROVE' AND vendor = '" + txtVendor.Text + "'", con);
                        con.Open();
                        DataSet ds11 = new DataSet();

                        SqlDataAdapter da11 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + noReq + "' AND reject = 'APPROVE' AND vendor = '" + txtVendor.Text + "'", con);
                        da11.Fill(ds11);
                        int count11 = ds11.Tables[0].Rows.Count;
                        if (count11 == 0)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Data yang dibuat tidak tersedia !');</script>");

                        }
                        else
                        {
                            DataSet ds12 = new DataSet();
                            SqlDataAdapter da12 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + noReq + "' AND nopurchaseorder IS NULL AND vendor = '" + txtVendor.Text + "'", con);
                            da12.Fill(ds12);
                            int count12 = ds12.Tables[0].Rows.Count;
                            if (count12 == 0)
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Data yang dibuat sudah pernah dibuat Purchase Order !');</script>");

                            }
                            else
                            {
                                DataSet ds13 = new DataSet();
                                SqlDataAdapter da13 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + noReq + "' AND rejecthead = 'N'", con);
                                da13.Fill(ds13);
                                int count13 = ds13.Tables[0].Rows.Count;
                                if (count13 == 0)
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Permintaan tersebut telah direject !');</script>");

                                }
                                else
                                {
                                    DataSet ds14 = new DataSet();
                                    SqlDataAdapter da14 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + noReq + "' AND disetujuifmb IS NOT NULL", con);
                                    da14.Fill(ds14);
                                    int count14 = ds14.Tables[0].Rows.Count;
                                    if (count14 == 0)
                                    {
                                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Permintaan Pembelian belum di setujui oleh Kepala Divisi !');</script>");

                                    }
                                    else
                                    {
                                        DataSet ds15 = new DataSet();
                                        SqlDataAdapter da15 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + noReq + "' AND mengetahuifmb IS NOT NULL", con);
                                        da15.Fill(ds15);
                                        int count15 = ds15.Tables[0].Rows.Count;
                                        if (count15 == 0)
                                        {
                                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Permintaan Pembelian belum di setujui oleh Purchasing !');</script>");

                                        }
                                        else
                                        {
                                            DataSet ds16 = new DataSet();
                                            SqlDataAdapter da16 = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + noReq + "' AND approveheadpurc IS NOT NULL", con);
                                            da16.Fill(ds16);
                                            int count16 = ds16.Tables[0].Rows.Count;
                                            if (count16 == 0)
                                            {
                                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Permintaan Pembelian belum di setujui oleh Kepala Purchasing !');</script>");

                                            }
                                            else
                                            {
                                                cmd.ExecuteNonQuery();
                                                cmd2.ExecuteNonQuery();
                                                Response.Redirect("printpo.aspx?q=" + noaBukti + "");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        con.Close();
                    }
                   
               }
        }
        catch (Exception ex)
        {
            txtTop.Text = "Error in execution " + ex.ToString();
        }
    }
}
