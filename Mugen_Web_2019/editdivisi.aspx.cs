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
       

        string uKode = Request.QueryString["reqid"];
        txtKode.Text = uKode;

        SqlConnection sconn = new SqlConnection(@"Data Source=192.168.0.88;Password=mugensaya;User ID=sayamugen;Initial Catalog=mugensupport;");
        sconn.Open();

        DataTable dt = new DataTable();
  
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM divisi WHERE kddivisi = '" + uKode + "'", sconn);
        da.Fill(dt);
        foreach (DataRow row in dt.Rows)
        {
            Label5.Text = row.Field<string>(1);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE divisi SET nmdivisi = '" + txtNama.Text + "' WHERE kddivisi = '" + txtKode.Text + "'", con);
        con.Open();

        DataSet ds = new DataSet();
        string nama = txtNama.Text;
        string kode = txtKode.Text;

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM divisi WHERE nmdivisi = '" + nama + "'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            if (nama == "")
                {
                    Label1.Text = "Nama tidak boleh kosong";
                }
                else
                {
                    if (kode == "")
                    { Label1.Text = "Kode tidak boleh kosong"; }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        Response.Redirect("divisi.aspx");
                    }
                }
        }
        else
        {
            Label1.Text = "Nama sudah digunakan";
        }
        con.Close();
    }
}
