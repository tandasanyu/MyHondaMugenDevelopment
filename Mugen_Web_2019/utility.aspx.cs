using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;


public partial class utilty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string hasilQuery = Request.QueryString["quser"];
        string idAkses = Request.QueryString["id"];
        string userAksesc = Request.QueryString["username"];
        txtHasilUsername.Text = hasilQuery;
        txtHasilUsername2.Text = hasilQuery;
        txtHasilUsername3.Text = hasilQuery;
        txtHasilUsername4.Text = hasilQuery;
        txtHapusAkses.Text = idAkses;
        txtHapusAkses2.Text = idAkses;
        txtHapusAkses3.Text = idAkses;
        txtHapusAkses4.Text = idAkses;
        Label8.Text = userAksesc;
        Label15.Text = userAksesc;
        Label24.Text = userAksesc;
        Label29.Text = userAksesc;
        //Label12.Visible = false;
        //Label18.Visible = false;
    }

    //global method (lbl 12 , lbl 18)
    public int GetUserInfoHRD(string sqlquery)
    {
        //int result; 
        //sqlquery = "Hi from another method";
        //if (sqlquery == "a")
        //{
        //     return result = 1;
        //}
        //else
        //{
        //     return result = 2;
        //}
        int result;
        
        SqlConnection cnn;
        SqlCommand cmd;
        string sql = null;
        SqlDataReader reader;
        string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["herlambangConnectionString"].ConnectionString;
        
        sql = sqlquery;

        cnn = new SqlConnection(connetionString);
        try
        {
            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{

            //}
            if (reader.HasRows) {
                 result =1;
            }
            else {
                 result = 0;
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }
        catch (Exception ex)
        {
            result = 9;
        }
        return result;
        

    }
    public int GetUserInfoPO(string sqlquery)
    {
        int result;

        SqlConnection cnn;
        SqlCommand cmd;
        string sql = null;
        SqlDataReader reader;
        string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;

        sql = sqlquery;

        cnn = new SqlConnection(connetionString);
        try
        {
            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{

            //}
            if (reader.HasRows)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }
        catch (Exception ex)
        {
            result = 9;
        }
        return result;


    }
    public int GetUserInfoSales(string sqlquery)
    {
        int result;

        SqlConnection cnn;
        SqlCommand cmd;
        string sql = null;
        SqlDataReader reader;
        string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["herlambangConnectionString2"].ConnectionString;

        sql = sqlquery;

        cnn = new SqlConnection(connetionString);
        try
        {
            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{

            //}
            if (reader.HasRows)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }
        catch (Exception ex)
        {
            result = 9;
        }
        return result;


    }
    int result;
    public void getCabangAksesSales(string query)
    {//cabang akses = 0 [no values found]
        
        SqlConnection cnn;
        SqlCommand cmd;
        
        SqlDataReader reader;
        string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["herlambangConnectionString2"].ConnectionString;

        //sql = "select cabang from tb_userutility where hakakses = '" +hakakses+"'";
        string q = query;
        cnn = new SqlConnection(connetionString);
        try
        {
            cnn.Open();
            cmd = new SqlCommand(query, cnn);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
               while (reader.Read())
                {
                    result = (int)reader["cabang"];
                    
                }
            }
            else
            {
                result  = 8;
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }
        catch (Exception ex)
        {
            result = 9;
        }
        //return result;
        
        
    }
    protected void Button6_Click(object sender, EventArgs e) {
        
        string usernm = txtUsername.Text;
        int getresult = GetUserInfoPO("Select username from tb_user where username ='"+ usernm + "'");
        if (getresult == 1) {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            Response.Redirect("utility.aspx");
        }
        if (getresult != 1)
        {
            Response.Write("<script>alert('Hasil = : " + getresult + "')</script>");
        }

        

    }//button untuk test saja
    protected void Button1_Click(object sender, EventArgs e)
    {
        string userName = txtUsername.Text;
        Response.Redirect("utility.aspx?quser=" + userName);
        Label12.Visible = true;
        Label18.Visible = true;
    }
    
    protected void Button2_Click(object sender, EventArgs e)//tambah hak akses po
    {
        string usernm = txtHasilUsername.Text;
        int getresult = GetUserInfoPO("Select username from tb_user where username ='" + usernm + "'");
        if (getresult != 1)
        {
            Response.Write("<script>alert('User yang anda pilih belum terdaftar pada database PO');window.location = 'utility.aspx';</script>");
            //Response.Redirect("utility.aspx");
        }
        if (getresult == 1)
        {
            //Response.Write("<script>alert('Hasil = : " + getresult + "')</script>");      
            //cek apakah user tersebut ada di database HRD user. Jika tidak , maka tampilkan error bahwa harus lakukan penambahan user baru bisa melakukan penambahan user HRD hak akses
            string userAkses = txtHasilUsername.Text;
            string hakAkses = txtHakAkses.Text;
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("INSERT INTO tb_userutility (username, hakakses) VALUES('" + userAkses + "','" + hakAkses + "')", con);
            con.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' AND hakAkses = '" + hakAkses + "'", con);
            da.Fill(ds);
            int count = ds.Tables[0].Rows.Count;
            if (count == 0)
            {
                        if (userAkses == "")
                          {
                              ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Username ID tidak boleh dikosongkan !');</script>");
                          }
                        else if (hakAkses == "")
                          {
                              ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Hak Akses tidak boleh dikosongkan !');</script>");
                          }
                        else
                        {
                            cmd.ExecuteNonQuery();
                            Response.Redirect("utility.aspx?quser=" + userAkses);
                        }
                }
            else
            {
                 ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('GAGAL ! Username dengan ID " +  userAkses + ". Sudah memiliki akses " + hakAkses +" !');</script>");
            }
            con.Close();
        }
    }

    protected void Button3_Click(object sender, EventArgs e)// hapus akses PO
    {
        string idAkses = txtHapusAkses.Text;
        string userAksessc = Request.QueryString["username"];
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("DELETE FROM tb_userutility WHERE idutility = '" + idAkses + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE idutility = '" + idAkses + "'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('GAGAL ! Data hak akses sudah tidak tersedia !');</script>");
        }
        else
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("utility.aspx?quser=" + userAksessc);
        }
        con.Close();
    }

    protected void Button5_Click(object sender, EventArgs e) // hapus akses HRD
    {
        string idAkses = txtHapusAkses2.Text;
        string userAksessc = Request.QueryString["username"];
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["herlambangConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("DELETE FROM tb_userutility WHERE idutility = '" + idAkses + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE idutility = '" + idAkses + "'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('GAGAL ! Data hak akses sudah tidak tersedia !');</script>");
        }
        else
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("utility.aspx?quser=" + userAksessc);
        }
        con.Close();
    }

    protected void Button4_Click(object sender, EventArgs e)//tambah hak akses hrd
    {
        string usernm = txtHasilUsername2.Text;
        int getresult = GetUserInfoHRD("Select username from tb_user where username ='" + usernm + "'");
        if (getresult != 1)
        {
            Response.Write("<script>alert('User yang anda pilih belum terdaftar pada database HRD');window.location = 'utility.aspx';</script>");
            //Response.Redirect("utility.aspx");
        }
        if (getresult == 1)
        {
            //cek apakah user tersebut ada di database HRD user. Jika tidak , maka tampilkan error bahwa harus lakukan penambahan user baru bisa melakukan penambahan user HRD hak akses
            string userAkses = txtHasilUsername2.Text;
            string hakAkses = TxtHakAksesHRD.Text;
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["herlambangConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("INSERT INTO tb_userutility (username, hakakses) VALUES('" + userAkses + "','" + hakAkses + "')", con);
            con.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' AND hakAkses = '" + hakAkses + "'", con);
            da.Fill(ds);
            int count = ds.Tables[0].Rows.Count;
            if (count == 0)
            {
                if (userAkses == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Username ID tidak boleh dikosongkan !');</script>");
                }
                else if (hakAkses == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Hak Akses tidak boleh dikosongkan !');</script>");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    Response.Redirect("utility.aspx?quser=" + userAkses);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('GAGAL ! Username dengan ID " + userAkses + ". Sudah memiliki akses " + hakAkses + " !');</script>");
            }
            con.Close();
        }
    }
    protected void Button9_Click(object sender, EventArgs e)//tambah hak akses Sales Warehouse
    {

        string var_final;
        string usernm = txtHasilUsername3.Text;
        int getresult = GetUserInfoSales("Select username from tb_user where username ='" + usernm + "'");
        if (getresult != 1)
        {
            Response.Write("<script>alert('User yang anda pilih belum terdaftar pada database Sales');window.location = 'utility.aspx';</script>");
            //Response.Redirect("utility.aspx");
        }

        if (getresult == 1)
        {
            //cek apakah user tersebut ada di database HRD user. Jika tidak , maka tampilkan error bahwa harus lakukan penambahan user baru bisa melakukan penambahan user HRD hak akses
            string userAkses = txtHasilUsername3.Text;
            string hakAkses = TxtHakAksesSales.Text;
            string cabang = RbCabang.Text;
            
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["herlambangConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            //old section code===============================================================================================================================================
            //SqlCommand cmd = new SqlCommand("INSERT INTO tb_userutility (username, hakakses, cabang) VALUES('" + userAkses + "','" + hakAkses + "', '" + var_final + "')", con);
            con.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE username = '" + userAkses + "' AND hakAkses = '" + hakAkses + "'", con);
            da.Fill(ds);
            int count = ds.Tables[0].Rows.Count;
            if (count == 0 )
            {
                int a = 1;
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Hak Akses Belum Ada, Penambahan Akan di Lakukan!');</script>");
                if (userAkses == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Username ID tidak boleh dikosongkan !');</script>");
                }
                else if (hakAkses == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Hak Akses tidak boleh dikosongkan !');</script>");
                }
                else if (RbCabang.SelectedIndex == -1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Pilih Cabang Tidak Boleh Kosong !');</script>");
                }
                else
                {
                    int b = a + 1;
                    SqlCommand cmd = new SqlCommand("INSERT INTO tb_userutility (username, hakakses, cabang) VALUES('" + userAkses + "','" + hakAkses + "', '" + cabang + "')", con);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("utility.aspx?quser=" + userAkses);
                }
            }
            else
            {
                int a = 1;
                if (userAkses == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Username ID tidak boleh dikosongkan !');</script>");
                }
                else if (hakAkses == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Hak Akses tidak boleh dikosongkan !');</script>");
                }
                else if (RbCabang.SelectedIndex == -1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Pilih Cabang Tidak Boleh Kosong !');</script>");
                }
                else
                {
                    int b = a + 1;
                    //new added code 

                    
                    getCabangAksesSales("select cabang from tb_userutility where hakakses = '"+hakAkses+"' and username ='"+ txtHasilUsername3.Text + "'");
                    int cabang_akses = result;
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Value Cabang Akses : "+ cabang_akses + "!');</script>");
                    //Response.Redirect("home.aspx");
                    if (cabang_akses == 112 || cabang_akses == 128 || cabang_akses == 112128 || cabang_akses == 128112)
                    {//berhasil mendapatkan value

                        if (cabang_akses == 112)//ketika kondisi cabang psm
                        {
                            int c = a + b;
                            //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Masuk Prose Penambahan Cabang PSM');</script>");
                            if (Convert.ToInt32(cabang) == cabang_akses)//kondisi rb sama dengan cabang yg ada -- hak akses di cabang ini sudah ada
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Hak Akses ini sudah ada di cabang Pasar Minggu. Proses Gagal !');</script>");
                            }
                            else //jalankan proses insert [cabang + cabang_akses]
                            {
                                //convert var cabang menjadi string
                                string var1 = Convert.ToString(cabang);
                                var_final = cabang_akses + var1;

                                //update data==========
                                SqlCommand cmd = new SqlCommand("update tb_userutility set cabang = '" + var_final + "' where username = '" + txtHasilUsername3.Text + "' and hakakses = '"+ hakAkses + "'", con);
                                //SqlCommand cmd = new SqlCommand("INSERT INTO tb_userutility (username, hakakses, cabang) VALUES('" + userAkses + "','" + hakAkses + "', '" + var_final + "')", con);
                                cmd.ExecuteNonQuery();
                                Response.Redirect("utility.aspx?quser=" + userAkses);


                            }
                        }
                        else if (cabang_akses == 128)//ketika kondisi cabang puri
                        {
                            int c = a + b;
                            //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Masuk Proses Penambahan Cabang Puri!');</script>");
                            if (Convert.ToInt32(cabang) == cabang_akses)//kondisi rb sama dengan cabang yg ada -- hak akses di cabang ini sudah ada
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Hak Akses ini sudah ada di cabang Puri. Proses Gagal !');</script>");
                            }
                            else //jalankan proses insert [cabang + cabang_akses]
                            {
                                //convert var cabang menjadi string
                                string var1 = Convert.ToString(cabang);
                                var_final = cabang_akses+var1 ;

                                //update data==========
                                SqlCommand cmd = new SqlCommand("update tb_userutility set cabang = '" + var_final + "' where username = '" + txtHasilUsername3.Text + "' and hakakses = '" + hakAkses + "'", con);
                                //SqlCommand cmd = new SqlCommand("INSERT INTO tb_userutility (username, hakakses, cabang) VALUES('" + userAkses + "','" + hakAkses + "', '" + var_final + "')", con);
                                cmd.ExecuteNonQuery();
                                Response.Redirect("utility.aspx?quser=" + userAkses);


                            }
                        }
                        else if (cabang_akses == 128112 || cabang_akses == 112128)//ketika kondisi cabang psm+puri
                        {
                            //aleert : hak akses ini telah ada di semua cabang
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Hak Akses ini sudah ada di semua cabang !');</script>");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert(' Error , Undefine Hak Akses Cabang!');</script>");
                        }
                    }
                    else//tidak berhasil mendapatkan value
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal Mendapatkan Value Cabang Hak Akses !" + cabang_akses + "');</script>");
                    }
                }

            }
            con.Close();
        }
    }
    //button 10 [tambah hak akses service]
    protected void Button10_Click(object sender, EventArgs e) {
    }
    protected void Button7_Click(object sender, EventArgs e)//button konfirmasi hapus hak akses sales warehouse 
    {
        string idAkses = txtHapusAkses3.Text;
        string userAksessc = Request.QueryString["username"];
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["herlambangConnectionString2"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("DELETE FROM tb_userutility WHERE idutility = '" + idAkses + "'", con);
        con.Open();

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_userutility WHERE idutility = '" + idAkses + "'", con);
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('GAGAL ! Data hak akses Sales Warehouse sudah tidak tersedia !');</script>");
        }
        else
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("utility.aspx?quser=" + userAksessc);
        }
        con.Close();
    }
}