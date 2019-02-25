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
      
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("INSERT INTO divisi (kddivisi, nmdivisi, emaildivisi) VALUES('" + txtKode.Text + "','" + txtNama.Text + "', '" + txtEmail.Text + "')", con);
        con.Open();

        DataSet ds = new DataSet();
        string kode = txtKode.Text;

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM divisi WHERE kddivisi = '" + kode + "'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
            if (count == 0)
            {
                DataSet ds2 = new DataSet();
                string nama = txtNama.Text;
                string email = txtEmail.Text;
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM divisi WHERE nmdivisi = '" + nama + "'", con);
                da2.Fill(ds2);
                int count2 = ds2.Tables[0].Rows.Count;
                if (count2 == 0)
                {
                    if (nama == "")
                    {
                        Label1.Text = "Nama tidak boleh kosong";
                    }
                    else
                    {
                        if (kode == "")
                        { Label1.Text = "Kode tidak boleh kosong"; }
                        else if (email == "")
                        { Label1.Text = "e-Mail tidak boleh kosong"; }
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
            }
            else
            {
                Label1.Text = "Kode sudah digunakan";
            }
        con.Close();
    }

    protected void btnCari_Click(object sender, EventArgs e)
    {

    }
}
