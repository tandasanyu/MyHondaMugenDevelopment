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
using System.Data.OleDb;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class tesPO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        txtAwal.Attributes.Add("readonly", "readonly");
        txtAkhir.Attributes.Add("readonly", "readonly");

        string userAkses = (string)(Session["username"]);
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        con.Open();
   
        DataSet ds3 = new DataSet();
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM PERMINTAAN PEMBELIAN -- LAPORAN'", con);

        da3.Fill(ds3);
        int count3 = ds3.Tables[0].Rows.Count;
        if (count3 == 0)
        {
            form1.Visible = false;
        }
        else
        {
           form1.Visible = true;
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string caBang = (string)(Session["kdcabang"]);
      
       if (txtAwal.Text == "")
        {
            lblError.Text = "Anda belum mengisi tanggal awal periode";
        }
        else if (txtAkhir.Text == "")
        {
            lblError.Text = "Anda belum mengisi tanggal akhir periode";
        }
        else if (txtCabang.Text == "")
        {
            lblError.Text = "Anda belum memilih cabang";
        }
        else {
            Response.Redirect("reportPO.aspx?tawl=" + txtAwal.Text + "&&takr=" + txtAkhir.Text + "&&cab=" + txtCabang.Text);
        }
       
    }
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
}
