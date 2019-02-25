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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string diVisi = (string)(Session["reportdivisi"]);
        string aWal = (string)(Session["reportawal"]);
        string akHir = (string)(Session["reportakhir"]);
        string caBang = (string)(Session["kdcabang"]);

        Label1.Text = diVisi;
        //Create report document
        ReportDocument crystalReport = new ReportDocument();

        //Load crystal report made in design view
        crystalReport.Load(Server.MapPath("CrystalReport1.rpt"));

        //Set DataBase Login Info
        crystalReport.SetDatabaseLogon("sayamugen", "mugensaya", "192.168.0.88", "MUGENSUPPORT");

        //Provide parameter values
        crystalReport.SetParameterValue("divisi", Label1.Text);
        crystalReport.SetParameterValue("awal", aWal);
        crystalReport.SetParameterValue("akhir", akHir);
        crystalReport.SetParameterValue("cabang", caBang);
        CrystalReportViewer1.ReportSource = crystalReport;
    }
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {
     
    }
}
