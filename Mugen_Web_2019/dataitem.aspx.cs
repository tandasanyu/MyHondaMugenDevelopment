using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class dataitem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
            string ambApp1 = Request.QueryString["id"];
            command.CommandText = "SELECT *  FROM dbitem WHERE item_id = '" + ambApp1 + "'";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string vendorItem = reader["item_vendor"].ToString();
                    string namaItem = reader["item_nama"].ToString();
                    string hargaItem = reader["item_harga"].ToString();

                    lblVendor.Text = vendorItem;
                    lblNama.Text = namaItem;
                    lblHarga.Text = "Rp." + decimal.Parse(hargaItem).ToString("0,0,0") + ",-";
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string harga = txtHarga.Text;
        string vendor = drpVendor.Text;
        string nama = txtNama.Text;

        string cs2 = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs2);
        SqlCommand cmd = new SqlCommand("INSERT INTO dbitem (item_vendor, item_nama, item_harga) VALUES ('" + vendor + "', '" + nama + "', '" + harga + "')", con);
        con.Open();

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter("SELECT item_nama FROM dbitem WHERE item_nama = '" + nama + "' AND item_vendor = '" + vendor + "'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            if (nama == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Nama barang belum diisi !');</script>");
            }
            else if (vendor == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Nama vendor belum dipilih !');</script>");
            }
            else if (harga == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Harga barang  belum diisi !');</script>");
            }
            else {
                cmd.ExecuteNonQuery();
                Response.Redirect("dataitem.aspx");
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Data Barang dengan nama " + nama + " sudah pernah ada !');</script>");
        }
        con.Close();

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string hargaEdit = txtHargaEdit.Text;
        string vendorEdit = drpVendorEdit.Text;
        string namaEdit = txtNamaEdit.Text;
        string aksiEdit = drpEdit.Text;
        string idEdit = Request.QueryString["id"];


        string cs2 = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs2);
        SqlCommand cmd = new SqlCommand("UPDATE dbitem SET item_nama = '" + namaEdit + "' WHERE item_id = '" + idEdit + "'", con);
        SqlCommand cmd2 = new SqlCommand("UPDATE dbitem SET item_vendor = '" + vendorEdit + "' WHERE item_id = '" + idEdit + "'", con);
        SqlCommand cmd3 = new SqlCommand("UPDATE dbitem SET item_harga = '" + hargaEdit + "' WHERE item_id = '" + idEdit + "'", con);
        con.Open();
        if(aksiEdit == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Silahkan pilih Action yang ingin anda edit terlebih dahulu !');</script>");
        }
        else if(aksiEdit == "1")
        {
            if (vendorEdit == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum memilih vendor baru.');</script>");
            }
            else {
                cmd2.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Vendor telah berhasil diubah menjadi " + vendorEdit + " !');</script>");
                Response.Redirect("dataitem.aspx");
            }
         }
        else if (aksiEdit == "2")
        {
            if (namaEdit == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum mengisi Nama barang baru.');</script>");
            }
            else {
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Nama barang telah berhasil diubah menjadi " + namaEdit + " !');</script>");
                Response.Redirect("dataitem.aspx");
            }
        }
        else if (aksiEdit == "3")
        {
            if (hargaEdit == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum mengisi Harga baru.');</script>");
            }
            else {
                cmd3.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Harga telah berhasil diubah menjadi " + hargaEdit + " !');</script>");
                Response.Redirect("dataitem.aspx");
            }
        }
        else if (aksiEdit == "4")
        {
            if (hargaEdit == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum mengisi Harga baru.');</script>");
            }
            else if (namaEdit == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum mengisi Nama barang baru.');</script>");
            }
            else if (vendorEdit == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Anda belum mengisi Vendor.');</script>");
            }
            else {
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Harga telah berhasil diubah menjadi " + hargaEdit + " !');</script>");
                Response.Redirect("dataitem.aspx");
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('ERROR hubungi IT!');</script>");
        }
        con.Close();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string asal = txtCari.Text;
        Response.Redirect("dataitem.aspx?q=" + asal );
    }
}