using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//ADO NET NAME SPACE
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Summary description for KelasKoneksi
/// </summary>
public class KelasKoneksi
{
    SqlConnection conn;
    SqlCommand cmd;
    public string status_hasil;
    public string KelasKoneksi_Open()
    {
        
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        conn.Open();
        if (conn.State == ConnectionState.Open)
        {
            status_hasil = "1";
            return status_hasil;
        }
        else
        {
             status_hasil = "0";
            return status_hasil;
        }
    }
    public string KelasKoneksi_Close() {
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        conn.Close();
        if (conn.State == ConnectionState.Closed)
        {
            status_hasil = "1";
            return status_hasil;
        }
        else
        {
            status_hasil = "0";
            return status_hasil;
        }
    }

    /*Below Main Working Code*/
    //fungsi untuk insert
    public string KelasKoneksi_Insert(string SqlCmd) {
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);      
        string sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            status_hasil = "1";
        }
        catch (SqlException sqlEx)
        {
            status_hasil = "Terjadi error Ketika Insert: " + sqlEx.Message;
        }
        finally {
            cmd.Dispose();
            conn.Close();
        }
        

        return status_hasil;
    }

    //fungsi untuk update
    public string KelasKoneksi_Update(string SqlCmd) {
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);
        try
        {
            conn.Open();
            //cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            status_hasil = "1";
        }
        catch (SqlException sqlEx)
        {
            status_hasil = "Terjadi error Ketika Update: " + sqlEx.Message;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }
        return status_hasil;
    }

    //Kelas Koneksi Delete
    public string KelasKoneksi_Delete(string SqlCmd) {
        String strconn = WebConfigurationManager.ConnectionStrings["MugenKarirConnection"].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);
        try
        {
            conn.Open();
            //cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            status_hasil = "1";
        }
        catch (SqlException sqlEx)
        {
            status_hasil = "Terjadi error Ketika Delete: " + sqlEx.Message;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }
        return status_hasil;
    }
}

