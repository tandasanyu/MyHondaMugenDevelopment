using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.IO;

public partial class jobcontrolformanclo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string noWo2 = Request.QueryString["qnowo2"];
        Image2.ImageUrl = "lamp/" + noWo2 + ".jpg";
        string userAkses = (string)(Session["username"]);
        string css = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con2 = new SqlConnection(css);
        con2.Open();
        DataSet dss9 = new DataSet();
        SqlDataAdapter daa9 = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' and hakakses = 'FORM JOB CONTROL FOREMAN -- CLOSING'", con2);

        daa9.Fill(dss9);
        int count9 = dss9.Tables[0].Rows.Count;
        if (count9 == 0)
        {
            hakAksesclosing.Visible = false;
            hakAksesClosingTolak.Visible = true;
        }
        else
        {
            hakAksesclosing.Visible = true;
            hakAksesClosingTolak.Visible = false;
        }

    }
    protected void btnClosing_Click(object sender, EventArgs e)
    {
        string noWoClosing = Request.QueryString["qnowo2"];
        string userClosing = (string)(Session["username"]);
        string path = Server.MapPath("lamp/" + noWoClosing + ".jpg");
        FileInfo file = new FileInfo(path);
        DateTime toDay = DateTime.Now;
        string tglClosing = toDay.ToString("MM/dd/yyyy hh:mm:ss tt");
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("INSERT INTO TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_CATATAN, KERJABODY_LOKASI) VALUES ('" + noWoClosing + "', '" + tglClosing + "', '" + userClosing + "', '0', 'This closing note is automatically by system', '')", con);
        SqlCommand cmd2 = new SqlCommand("UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '0', CONTROLBR_TGLSELESAIA = '" + tglClosing + "' WHERE CONTROLBR_NOWO = '" + noWoClosing + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TEMP_KERJABODY WHERE KERJABODY_NOWO = '" + noWoClosing + "'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Tidak bisa di Closing karena tidak ada history pengerjaan !');</script>");
        }
        else
        {
            DataSet ds2 = new DataSet();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = '" + noWoClosing + "' AND CONTROLBR_TGLSELESAIA IS NULL", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data ini sudah pernah di closing !');</script>");
            }
            else
            {
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                file.Delete();
                Response.Redirect("jobcontrolforman.aspx");
            }
        }
        con.Close();
    }
}