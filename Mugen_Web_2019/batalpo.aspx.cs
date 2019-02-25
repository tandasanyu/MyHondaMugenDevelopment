using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class batalpo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCariPo_Click(object sender, EventArgs e)
    {
        string noPoCari = txtCariPo.Text;
        Response.Redirect("batalpo.aspx?q=" + noPoCari);
    }

    protected void btnBtlPo_Click(object sender, EventArgs e)
    {
        string alasan = txtAlasanBatal.Text;
        string idreject = Request.QueryString["idbody"];
        string jumlahReject = txtJumlahBatal.Text;
        string app = Request.QueryString["nobody"];
        string nopo = Request.QueryString["q"];
        string user = (string)(Session["username"]);

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["setiawanConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("DELETE FROM fmbbody WHERE idbody = '" + idreject + "'", con);
        SqlCommand cmd2 = new SqlCommand("INSERT INTO fmbbody(nobody, namaitem, tujuanitem, jumlahitem, hargaitem, pusatbiaya, reject, alasanreject, rejectoleh, vendor, nopurchaseorder, kelompok) SELECT nobody, namaitem, tujuanitem, '" + jumlahReject + "', hargaitem, pusatbiaya, 'BATAL PO', '" + alasan + "', '" + user + "', vendor, nopurchaseorder, kelompok FROM fmbbody WHERE idbody = '" + idreject + "' ", con);
        SqlCommand cmd3 = new SqlCommand("DELETE FROM fmblamp WHERE nohead = '" + app + "'", con);
        SqlCommand cmd5 = new SqlCommand("UPDATE fmbbody SET jumlahitem = jumlahitem -  '" + jumlahReject + "' WHERE idbody = '" + idreject + "' AND reject = 'APPROVE'", con);

        con.Open();


        DataSet ds3 = new DataSet();

        SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + app + "' AND nopurchaseorder IS NULL", con);
        da3.Fill(ds3);
        int count3 = ds3.Tables[0].Rows.Count;
        if (count3 == 0)
        {
            DataSet ds4 = new DataSet();

            SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE (jumlahitem < '" + jumlahReject + "') AND idbody = '" + idreject + "'", con);
            da4.Fill(ds4);
            int count4 = ds4.Tables[0].Rows.Count;
            if (count4 == 0)
            {
                DataSet ds5 = new DataSet();

                SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE jumlahitem <= 1 AND idbody = '" + idreject + "'", con);
                da5.Fill(ds5);
                int count5 = ds5.Tables[0].Rows.Count;
                if (count5 == 0)
                {
                    DataSet ds55 = new DataSet();

                    SqlDataAdapter da55 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE jumlahitem = '" + jumlahReject + "' AND idbody = '" + idreject + "'", con);
                    da55.Fill(ds55);
                    int count55 = ds55.Tables[0].Rows.Count;
                    if (count55 == 0)
                    {
                        if (alasan == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                        }
                        else if (jumlahReject == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                        }
                        else if (jumlahReject == "0")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                        }
                        else {
                            cmd2.ExecuteNonQuery();
                            cmd5.ExecuteNonQuery();
                            Response.Redirect("batalpo.aspx?q=" + nopo + "&&idbody=" + idreject + "&&nobody=" + app + "#reject");
                        }

                    }
                    else
                    {
                        DataSet ds22 = new DataSet();

                        SqlDataAdapter da22 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + app + "' AND reject = 'APPROVE'", con);
                        da22.Fill(ds22);
                        int count22 = ds22.Tables[0].Rows.Count;
                        if (count22 <= 1)
                        {
                            if (alasan == "")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                            }
                            else if (jumlahReject == "")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                            }
                            else if (jumlahReject == "0")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                            }
                            else {
                                cmd2.ExecuteNonQuery();
                                cmd.ExecuteNonQuery();
                                Response.Redirect("batalpo.aspx?q=" + nopo + "&&idbody=" + idreject + "&&nobody=" + app + "#reject");
                            }
                        }
                        else {
                            if (alasan == "")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                            }
                            else if (jumlahReject == "")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                            }
                            else if (jumlahReject == "0")
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                            }
                            else {
                                cmd2.ExecuteNonQuery();
                                cmd.ExecuteNonQuery();
                                Response.Redirect("batalpo.aspx?q=" + nopo + "&&idbody=" + idreject + "&&nobody=" + app + "#reject");
                            }
                        }

                    }

                }
                else
                {
                    DataSet ds2 = new DataSet();

                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM fmbbody WHERE nobody = '" + app + "' AND reject = 'APPROVE'", con);
                    da2.Fill(ds2);
                    int count2 = ds2.Tables[0].Rows.Count;
                    if (count2 <= 1)
                    {
                        if (alasan == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                        }
                        else if (jumlahReject == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                        }
                        else if (jumlahReject == "0")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                        }
                        else {
                            cmd2.ExecuteNonQuery();
                            cmd.ExecuteNonQuery();
                            Response.Redirect("batalpo.aspx?q=" + nopo + "&&idbody=" + idreject + "&&nobody=" + app + "#reject");
                        }
                    }
                    else {
                        if (alasan == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Alasan anda belum terisi !');</script>");
                        }
                        else if (jumlahReject == "")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject belum diisi !');</script>");
                        }
                        else if (jumlahReject == "0")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda reject harus lebih dari 0 !');</script>");
                        }
                        else {
                            cmd2.ExecuteNonQuery();
                            cmd5.ExecuteNonQuery();
                            Response.Redirect("batalpo.aspx?q=" + nopo + "&&idbody=" + idreject + "&&nobody=" + app + "#reject");
                        }
                    }

                }

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! Jumlah item yang anda batalkan lebih besar dari jumlah yg tertera di PO !');</script>");
            }

        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Gagal ! tidak ada nomor purchase order !');</script>");
        }

        con.Close();
    }
}