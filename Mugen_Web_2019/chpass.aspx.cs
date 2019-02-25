using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class chpass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userSesi = (string)(Session["username"]);
        lblUsername.Text = userSesi;
    }

    protected void btnChPass_Click(object sender, EventArgs e)
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);

        string userSesi2 = (string)(Session["username"]);
        string passLama = txtPassLama.Text;
        string passBaru = txtPassBaru.Text;
        string passBaru2 = txtPassBaru2.Text;

        SqlCommand cmd = new SqlCommand("UPDATE tb_user SET password = '" + passBaru + "' WHERE username = '" + userSesi2 + "'", con);
        con.Open();

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_user WHERE username = '" + userSesi2 + "' AND password = '" + passLama + "'", con);

        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            lblPassLama.Text = "Password lama yang anda masukkan salah.";
            txtPassLama.Focus();
        }
        else
        {
           if(passBaru == passBaru2)
            {
                cmd.ExecuteNonQuery();
                lblSukses.Text = "Password anda telah berhasil di-ubah.";
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Password anda berhasil diubah ! ');</script>");
            }
           else
            {
                lblPassBaru2.Text = "Pengulangan password baru yang anda masukkan berbeda.";
            }
        }
        con.Close();

    }
}