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

public partial class approvemintabeli : System.Web.UI.Page
{
    protected void GetTime(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string akses = Request.QueryString["q"];
        if (akses == "headapproval")
        {
            divisiApproval.Visible = false;
            headApproval.Visible = true;
            purChasing.Visible = false;
            headPur.Visible = false;
            vicePresident.Visible = false;
        }
        else if (akses == "purchasing")
        {
            divisiApproval.Visible = false;
            headApproval.Visible = false;
            purChasing.Visible = true;
            headPur.Visible = false;
            vicePresident.Visible = false;
        }
        else if (akses == "headpur")
        {
            divisiApproval.Visible = false;
            headApproval.Visible = false;
            purChasing.Visible = false;
            headPur.Visible = true;
            vicePresident.Visible = false;
        }
        else if (akses == "vpapp")
        {
            divisiApproval.Visible = false;
            headApproval.Visible = false;
            purChasing.Visible = false;
            headPur.Visible = false;
            vicePresident.Visible = true;
        }
        else if (akses == "divisiapproval")
        {
            divisiApproval.Visible = true;
            headApproval.Visible = false;
            purChasing.Visible = false;
            headPur.Visible = false;
            vicePresident.Visible = false;
        }
        else
        {
            divisiApproval.Visible = false;
            headApproval.Visible = false;
            purChasing.Visible = false;
            headPur.Visible = false;
            vicePresident.Visible = false;
            Response.Redirect("mintabeli.aspx");
        }

        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp1 = Request.QueryString["app1"];
            string user = (string)(Session["username"]);
            command.CommandText = "SELECT SUM(jumlahitem*hargaitem) AS totalharga FROM [fmbbody] WHERE nobody = '" + ambApp1 + "'";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string totalharga = reader["totalharga"].ToString();
                    if (totalharga == "")
                    {
                        lblTotal.Text = "0";
                    }
                    else
                    {
                        lblTotal.Text = decimal.Parse(totalharga).ToString("0,0,0");
                    }

                }
            }
        }
        using (var connection2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command2 = connection2.CreateCommand())
        {
            string ambApp2 = Request.QueryString["app2"];
            string user = (string)(Session["username"]);
            command2.CommandText = "SELECT SUM(jumlahitem*hargaitem) AS totalharga FROM [fmbbody] WHERE nobody = '" + ambApp2 + "'";
            connection2.Open();
            using (var reader2 = command2.ExecuteReader())
            {
                while (reader2.Read())
                {
                    string totalharga2 = reader2["totalharga"].ToString();
                    if (totalharga2 == "")
                    {
                        lblTotal2.Text = "0";
                    }
                    else
                    {
                        lblTotal2.Text = decimal.Parse(totalharga2).ToString("0,0,0");
                    }

                }
            }
        }
        using (var connection3 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command3 = connection3.CreateCommand())
        {
            string ambApp3 = Request.QueryString["app3"];
            string user = (string)(Session["username"]);
            command3.CommandText = "SELECT SUM(jumlahitem*hargaitem) AS totalharga FROM [fmbbody] WHERE nobody = '" + ambApp3 + "'";
            connection3.Open();
            using (var reader3 = command3.ExecuteReader())
            {
                while (reader3.Read())
                {
                    string totalharga3 = reader3["totalharga"].ToString();
                    if (totalharga3 == "")
                    {
                        lblTotal4.Text = "0";
                    }
                    else
                    {
                        lblTotal4.Text = decimal.Parse(totalharga3).ToString("0,0,0");
                    }

                }
            }
        }
    }
    protected void btnSelesai_Click(object sender, EventArgs e)
    {
        Response.Redirect("approvemintabeli.aspx");
    }
    protected void btnTambah_Click(object sender, EventArgs e)
    {
        string user = Session["username"].ToString();
        DateTime myDate = DateTime.Now;
        string tglSkrng = myDate.ToString("MM/dd/yyyy hh:mm:ss tt");
        string ambApp1 = Request.QueryString["app1"];

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbhead SET disetujuifmb = '" + user + "', tgldisetujuifmb = '" + tglSkrng + "' WHERE nofmbhead = '" + ambApp1 + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + ambApp1 + "' AND disetujuifmb IS NOT NULL", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
                    cmd.ExecuteNonQuery();
                    Response.Redirect("approvemintabeli.aspx");
        }
        else
        {
           
        }
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("approvemintabeli.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string user = Session["username"].ToString();
        DateTime myDate = DateTime.Now;
        string tglSkrng = myDate.ToString("MM/dd/yyyy hh:mm:ss tt");
        string ambApp2 = Request.QueryString["app2"];

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbhead SET mengetahuifmb = '" + user + "', tglmengetahuifmb = '" + tglSkrng + "' WHERE nofmbhead = '" + ambApp2 + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + ambApp2 + "' AND mengetahuifmb IS NOT NULL", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("approvemintabeli.aspx");
        }
        else
        {

        }
        con.Close();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("approvemintabeli.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string user = Session["username"].ToString();
        DateTime myDate = DateTime.Now;
        string tglSkrng = myDate.ToString("MM/dd/yyyy hh:mm:ss tt");
        string ambApp3 = Request.QueryString["app3"];

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("UPDATE fmbhead SET disetujui2fmb = '" + user + "', tgldisetujui2fmb = '" + tglSkrng + "' WHERE nofmbhead = '" + ambApp3 + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fmbhead WHERE nofmbhead = '" + ambApp3 + "' AND disetujui2fmb IS NOT NULL", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("approvemintabeli.aspx");
        }
        else
        {

        }
        con.Close();
    }
}
