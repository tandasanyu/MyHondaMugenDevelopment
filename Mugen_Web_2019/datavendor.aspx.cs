using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp1 = Request.QueryString["id"];
            command.CommandText = "SELECT *  FROM dbvendor WHERE vendor_id = '" + ambApp1 + "'";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string vendorNama = reader["vendor_nama"].ToString();
                    string vendorTelp = reader["vendor_telp"].ToString();
                    string vendorFax = reader["vendor_fax"].ToString();
                    string vendorEmail = reader["vendor_email"].ToString();
                    string vendorKet = reader["vendor_keterangan"].ToString();

                    lblEmailV.Text = vendorEmail;
                    lblTelpV.Text = vendorTelp;
                    lblFaxV.Text = vendorFax;
                    lblNamaV.Text = vendorNama;
                    lblKetV.Text = vendorKet;
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string ambl = txtCari.Text;
        Response.Redirect("datavendor.aspx?q=" + ambl);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string namaVendor = txtNama.Text;
        string keteranganVendor = txtKeteranganVendor.Text;
        string badanVendor = drpBadan.Text;
        string kdTelp = txtKodet.Text;
        string noTelp = txtTelp.Text;
        string kdFax = txtKodef.Text;
        string noFax = txtFax.Text;
        string emailVendor = txtEmail.Text;
        string pkpVendor = drpStatus.Text;

        string cs2 = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs2);
        SqlCommand cmd = new SqlCommand("INSERT INTO dbvendor (vendor_nama, vendor_telp, vendor_fax, vendor_email, vendor_pkp, vendor_keterangan) VALUES ('" + namaVendor + ", " + badanVendor +  "', '(" + kdTelp + ")" + noTelp + "', '(" + kdFax + ")" + noFax + "', '" + emailVendor + "', '" + pkpVendor + "', '" + keteranganVendor + "')", con);
        con.Open();

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter("SELECT vendor_nama FROM dbvendor WHERE vendor_nama = '" + namaVendor + ", " + badanVendor + "'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            if (namaVendor == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Nama vendor belum diisi !');</script>");
            }
            else if(kdTelp == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! No Telepon Vendor belum diisi !');</script>");
            }
            else if (noTelp == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! No Telepon Vendor belum diisi !');</script>");
            }
            else if (kdFax == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! No Fax Vendor belum diisi, bila tidak ada isi angka  !');</script>");
            }
            else if (noFax == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! No Fax Vendor belum diisi, bila tidak ada isi angka 0 !');</script>");
            }
            else if (emailVendor == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! email Vendor belum diisi !');</script>");
            }
            else if (pkpVendor == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Status PKP Vendor belum diisi !');</script>");
            }
            else if (keteranganVendor == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Keterangan Vendor belum diisi !');</script>");
            }
            else {
                cmd.ExecuteNonQuery();
                Response.Redirect("datavendor.aspx");
            }
           }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Data vendor dengan nama " + namaVendor + " sudah pernah ada !');</script>");
        }
        con.Close();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string emailEdit = txtEmailVEdit.Text;
        string telEdit = txtTelVEdit.Text;
        string faxEdit = txtFaxVEdit.Text;
        string ketEdit = txtKetVEdit.Text;
        string idEdit = Request.QueryString["id"];
        string aksiEdit = drpEdit.Text;

        string cs2 = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs2);
        SqlCommand cmd = new SqlCommand("UPDATE dbvendor SET vendor_telp = '" + telEdit + "' WHERE vendor_id = '" + idEdit + "'", con);
        SqlCommand cmd2 = new SqlCommand("UPDATE dbvendor SET vendor_email = '" + emailEdit + "' WHERE vendor_id = '" + idEdit + "'", con);
        SqlCommand cmd3 = new SqlCommand("UPDATE dbvendor SET vendor_fax = '" + faxEdit + "' WHERE vendor_id = '" + idEdit + "'", con);
        SqlCommand cmd4 = new SqlCommand("UPDATE dbvendor SET vendor_keterangan = '" + ketEdit + "' WHERE vendor_id = '" + idEdit + "'", con);
        con.Open();
        if (aksiEdit == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Silahkan pilih Action yang ingin anda edit terlebih dahulu !');</script>");
        }
        else if (aksiEdit == "1")
        {
            if (emailEdit == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum mengisi email Vendor yang baru.');</script>");
            }
            else {
                cmd2.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Email Vendor telah berhasil diubah menjadi " + emailEdit + " !');</script>");
                Response.Redirect("datavendor.aspx");
            }
        }
        else if (aksiEdit == "2")
        {
            if (telEdit == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum mengisi Nomor Telpon baru.');</script>");
            }
            else {
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Nomor telpon telah berhasil diubah menjadi " + telEdit + " !');</script>");
                Response.Redirect("datavendor.aspx");
            }
        }
        else if (aksiEdit == "3")
        {
            if (faxEdit == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum mengisi Nomor Fax baru.');</script>");
            }
            else {
                cmd3.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Fax telah berhasil diubah menjadi " + faxEdit + " !');</script>");
                Response.Redirect("datavendor.aspx");
            }
        }
        else if (aksiEdit == "4")
        {
            if (emailEdit == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Email baru belum diisi.');</script>");
            }
            else if (telEdit == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Nomor telpon vendor belum diisi.');</script>");
            }
            else if (faxEdit == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Nomor fax vendor belum diisi.');</script>");
            }
            else {
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Data Vendor Berhasil di ubah!');</script>");
                Response.Redirect("datavendor.aspx");
            }
        }
        else if (aksiEdit == "5")
        {
            if (ketEdit == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Keterangan baru belum diisi.');</script>");
            }
            else {
                cmd4.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Keterangan Vendor Berhasil di ubah!');</script>");
                Response.Redirect("datavendor.aspx");
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('ERROR hubungi IT!');</script>");
        }
        con.Close();

    }
}