using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageUser_PageUser_HomePelamar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = string.Empty;
        username = Convert.ToString(Session["User"]); // berisi username dari tb.login
        //get user_nama_login
        string user_nama;
        string sql = "select user_nama_login from Login_User where Username_Login = '" + username + "'";
        KelasKoneksi cn = new KelasKoneksi();
        List<String>  hasil = cn.KelasKoneksi_SelectGlobal(sql, "2");
        if (hasil.Count > 0 ) {
            user_nama = hasil[0];
            string sql2 = "select id_lamaran, user_posisi from Data_Lamaran where user_nama = '"+ user_nama + "'";
            List<String> hasil2 = cn.KelasKoneksi_SelectGlobal(sql2, "3");
            if (hasil2.Count > 0) {
                LblIdLamaran.Text = hasil2[0];
                LblPosisi.Text = hasil2[1];
                LblNamaPelamar.Text = user_nama;
            }
            
        }
        //ketika page load, makadi periksa setiap dokumen dengan nomor id lamaran berikut apakah ada. jika ada maka hide tombol
        if (Session["User"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        //Response.Write("<script language=javascript>alert('ID Lamaran : "+LblIdLamaran.Text+"');</script>");
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Login.aspx");
    }
    //button data diri
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/PageUser/PageUser_FormDataDiri.aspx?Nama=" + LblNamaPelamar.Text+"&Posisi="+LblPosisi.Text+"&IdLamaran="+LblIdLamaran.Text+"");
        Response.Redirect("~/PageUser/PageUser_FormDataDiri.aspx?IdLamaran=" + LblIdLamaran.Text +"");

    }
}