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

public partial class karyawan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
       
        string nik = txtNik.Text;
        string user = txtUser.Text;
        string pass = txtPass.Text;
        string ktp = txtKTP.Text;
        string nama = txtNama.Text;
        string divisi = txtDivisi.Text;
        string alamat2 = txtAlamat2.Text;
        string tempat = txtTempatlahir.Text;
        string tgllahir = txtTgllahir.Text;
        string agama = txtAgama.Text;
        string gender = txtGender.Text;
        string pendidikan = txtPendidikan.Text;
        string join = txtJoin.Text;
        string email = txtEmail.Text;
        string hp = txtHP.Text;
        string isistat = "Y";
        string isistat2 = "N";
        string kdCabang = txtKodecabang.Text;

        SqlCommand cmd = new SqlCommand("INSERT INTO tb_user (kdkaryawan, kdcabang, username, password, noktp, namakaryawan, kddivisi, alamatkaryawan, tptlahir, tgllahir, agama, gender, pendidikan, tgljoin, email, nohp, online, banned) VALUES ('" + nik + "', '" + kdCabang + "', '" + user + "', '" + pass + "', '" + ktp + "', '" + nama + "', '" + divisi + "', '" + alamat2 + "', '" + tempat + "', '" + tgllahir + "', '" + agama + "', '" + gender + "', '" + pendidikan + "', '" + join + "', '" + email + "', '" + hp + "', '" + isistat + "', '" + isistat2 + "')", con);
        SqlCommand cmd2 = new SqlCommand("INSERT INTO tb_userGeneral (username, kdcabang) values ('" + nama + "','88')", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_user WHERE kdkaryawan = '" + nik + "'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            DataSet ds2 = new DataSet();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM tb_user WHERE username = '" + user + "'", con);
            da2.Fill(ds2);
            int count2 = ds2.Tables[0].Rows.Count;
            if (count2 == 0)
            {
                if (nik == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('NIK tidak boleh kosong !');</script>");
                }
                else if (user == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Username tidak boleh kosong !');</script>");
                }
                else if (pass == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Password tidak boleh kosong !');</script>");
                }
                else if (ktp == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('No. KTP tidak boleh kosong !');</script>");
                }
                else if (nama == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Nama tidak boleh kosong !');</script>");
                }
                else if (divisi == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Divisi harus dipilih !');</script>");
                }
                else if (alamat2 == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Alamat tidak boleh kosong !');</script>");
                }
                else if (tempat == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Tempat lahir tidak boleh kosong !');</script>");
                }
                else if (tgllahir == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Tgl lahir tidak boleh kosong !');</script>");
                }
                else if (agama == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Agama harus dipilih !');</script>");
                }
                else if (gender == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gender tidak boleh kosong !');</script>");
                }
                else if (pendidikan == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Pendidikan terakhir tidak boleh kosong !!');</script>");
                }
                else if (join == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Tanggal join tidak boleh kosong !');</script>");
                }
                else if (email == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('e-Mail tidak boleh kosong !');</script>");
                }
                else if (hp == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Handphone tidak boleh kosong !');</script>");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    //insert ke tb_usergeneral
                    cmd2.ExecuteNonQuery();
                    Label15.Text = "Data berhasil disimpan";
                }
            }
            else
            {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Username tersebut sudah digunakan orang lain, cari username lain !');</script>");
                }
        }
        else
        {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('NIK sudah pernah diinput, coba di cek dahulu !');</script>");
            }
        con.Close();
    }
}
