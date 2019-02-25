using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class datalamp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button6_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
               
                string filename = System.IO.Path.GetFileName(FileUpload1.FileName);
                string keTerangan = txtKet.Text;
                string user = (string)(Session["username"]);
                string lokasi = "lamp";
                string app = drpVendor.Text;
                DateTime toDay = DateTime.Now;
                string hariIni = toDay.ToString("MM/dd/yyyy hh:mm:ss tt");
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO fmblamp (nohead, lokasifile, keterangan, username, proses) VALUES ('" + app + "', '" + lokasi + "/" + filename + "', '" + keTerangan + "', '" + user + "', '0')", con);
                con.Open();
                if (keTerangan == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Keterangan belum diisi !');</script>");
                }
                else if (app == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Vendor belum diisi !');</script>");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    FileUpload1.SaveAs(Server.MapPath("~/lamp/") + filename);
                    Response.Redirect("datalamp.aspx");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string cari = txtCari.Text;
        Response.Redirect("datalamp.aspx?q=" + cari);
    }
}