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

public partial class printpo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      string nmrPo =  Request.QueryString["q"];
        lblNoPo.Text = nmrPo;
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "SELECT *, convert(varchar, pofmb_tgl_po, 106) AS tgl_po FROM pofmb INNER JOIN fmbbody ON pofmb.POFMB_no_po = fmbbody.nopurchaseorder INNER JOIN fmbhead ON fmbbody.nobody = fmbhead.nofmbhead INNER JOIN dbvendor ON pofmb.pofmb_nama_vendor = dbvendor.vendor_nama WHERE POFMB_no_po = '" + nmrPo + "'";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tglPo = reader["tgl_po"].ToString();
                    string nmVendor = reader["POFMB_nama_vendor"].ToString();
                    string telVendor = reader["vendor_telp"].ToString();
                    string faxVendor = reader["vendor_fax"].ToString();
                    string alamatVendor = reader["vendor_alamat"].ToString();
                    string emailVendor = reader["vendor_email"].ToString();
                    string nmShipper = reader["POFMB_nama_shipper"].ToString();
                    string telShipper = reader["POFMB_telp_shipper"].ToString();
                    string faxShipper = reader["POFMB_fax_shipper"].ToString();
                    string emailShipper = reader["POFMB_email_shipper"].ToString();
                    string shippingMethod = reader["POFMB_shipping_method"].ToString();
                    string shippingTerm = reader["POFMB_shipping_term"].ToString();
                    string shippingDate = reader["POFMB_shipping_date"].ToString();
                    string termOfPayment = reader["POFMB_term_of_payment"].ToString();
                    string noReq = reader["nofmbhead"].ToString();
                    string pemohonFmb = reader["userfmb"].ToString();
                    string approvalHead = reader["disetujuifmb"].ToString();
                    string approvalPurc = reader["mengetahuifmb"].ToString();
                    string headPurc = reader["approveheadpurc"].ToString();

                    lblTglPo.Text = tglPo;
                    lblNamaVendor.Text = nmVendor;
                    lblTelpVendor.Text = telVendor;
                    lblAlamatVendor.Text = alamatVendor;
                    lblFaxVendor.Text = faxVendor;
                    lblEmailVendor.Text = emailVendor;
                    lblNamaShipper.Text = nmShipper;
                    lblTelpShipper.Text = telShipper;
                    lblFaxShipper.Text = faxShipper;
                    lblEmailShipper.Text = emailShipper;
                    lblShippingMethod.Text = shippingMethod;
                    lblShippingTerm.Text = shippingTerm;
                    lblShippingDate.Text = shippingDate;
                    lblTermOfPayment.Text = termOfPayment;
                    lblReqNo.Text = noReq;
                    lblPemohon.Text = pemohonFmb;
                    lblHeaddiv.Text = approvalHead;
                    lblPurc.Text = approvalPurc;
                    lblHeadPurc.Text = headPurc;
                }
            }
        }
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "SELECT vendor_pkp, sum(cast(jumlahitem * hargaitem as BIGINT) / 1.1) as total FROM fmbbody INNER JOIN pofmb ON fmbbody.nopurchaseorder = pofmb.POFMB_no_po INNER JOIN dbvendor ON pofmb.pofmb_nama_vendor = dbvendor.vendor_nama WHERE nopurchaseorder = '" + nmrPo + "' GROUP BY vendor_pkp";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string statusPkp = reader["vendor_pkp"].ToString();
                    string totalSum = reader["total"].ToString();
                    if(statusPkp == "PKP")
                    {
                        lblTotalDpp.Text = decimal.Parse(totalSum).ToString("0,0,0");
                    }
                    else if (statusPkp == "NON PKP")
                    {
                        lblTotalDpp.Text = "0";
                    }

                }
            }
        }
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "SELECT vendor_pkp, sum(cast(jumlahitem * hargaitem as BIGINT) /1.1) * 0.1  as total FROM fmbbody INNER JOIN pofmb ON fmbbody.nopurchaseorder = pofmb.POFMB_no_po INNER JOIN dbvendor ON pofmb.pofmb_nama_vendor = dbvendor.vendor_nama WHERE nopurchaseorder = '" + nmrPo + "' GROUP BY vendor_pkp";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string statusPkp = reader["vendor_pkp"].ToString();
                    string totalSum = reader["total"].ToString();
                    if (statusPkp == "PKP")
                    {
                        lblTotalPpn.Text = decimal.Parse(totalSum).ToString("0,0,0");
                    }
                    else if (statusPkp == "NON PKP")
                    {
                        lblTotalPpn.Text = "0";
                    }

                }
            }
        }
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "SELECT POFMB_status_pkp, sum(jumlahitem * hargaitem) as total FROM fmbbody INNER JOIN pofmb ON fmbbody.nopurchaseorder = pofmb.POFMB_no_po WHERE nopurchaseorder = '" + nmrPo + "' AND rejectoleh IS NULL GROUP BY POFMB_status_pkp";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalSum = reader["total"].ToString();
                    lblTotalSum.Text = decimal.Parse(totalSum).ToString("0,0,0");
                }
            }
        }
    }
}
