using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PagesHRD_Undang_Psikotest : System.Web.UI.Page
{
    public string val1 = string.Empty;
    public string emailori = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            KelasKoneksi cn = new KelasKoneksi();
            val1 = Request.QueryString["idlamaran"];
            //get user posisi
            List<string> userposisi = cn.KelasKoneksi_SelectGlobal("select user_posisi, id_login from Data_Lamaran where id_lamaran = " + val1 + " ", "9");
            LblPosisi.Text = userposisi[0].ToString();
            //get email 
            List<string> email = cn.KelasKoneksi_SelectGlobal("select user_email from Login_User where id_login = " + userposisi[1].ToString() + "", "10");
            emailori = email[0].ToString();
            //Response.Write("<script>alert('"+ emailori + "')</script>");

        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
        MultiViewUndangPsikotest.ActiveViewIndex = 0;
    }
    public string isiemail = string.Empty;
    protected void BtnKirim_Click(object sender, EventArgs e)
    {
        string emailbod = Convert.ToString(Session["HTMLEmailBody"]);
        string subject = Convert.ToString(Session["SubjectEmail"]);
        KelasKoneksi cn = new KelasKoneksi();
        string status = cn.email_otomatis2(emailori, emailbod, subject);
        if (status == "OK")
        {
            Session["HTMLEmailBody"] = null;//set specific session to null
            Session["SubjectEmail"] = null;//set specific session to null
            Response.Write("<script>alert('Berhasil Kirim Email Undangan Psikotest Pelamar Baru')</script>");
        }
        else
        {
            Response.Write("<script>alert('Gagal Kirim Email dengan error : " + status + "')</script>");
        }
    }

    protected void BtnPreview_Click(object sender, EventArgs e)
    {
        if (TxtHariTgl.Text.Length != 0 && TxtPukul.Text.Length != 0 && TxtBertemu.Text.Length != 0)
        {
            MultiViewUndangPsikotest.ActiveViewIndex = 1;

            DateTime date = Convert.ToDateTime(TxtHariTgl.Text);
            int days = Convert.ToInt32(date.DayOfWeek);
            string trueday = string.Empty;
            if (days == 0)
            {
                trueday = "Minggu";
            }
            else if (days == 1)
            {
                trueday = "Senin";
            }
            else if (days == 2)
            {
                trueday = "Selasa";
            }
            else if (days == 3)
            {
                trueday = "Rabu";
            }
            else if (days == 4)
            {
                trueday = "Kamis";
            }
            else if (days == 5)
            {
                trueday = "Jumat";
            }
            else if (days == 6)
            {
                trueday = "Sabtu";
            }
            isiemail = "<br /><br /><p>Selamat Siang Bapak/Ibu,</p><p>Kami telah mereview CV singkat anda dan ingin mengundang Anda untuk bisa menghadiri Psikotest posisi <b>" + LblPosisi.Text + "</b> yang akan diselenggarakan pada :</p><br /><div><div><p><b>Hari / Tanggal </b>: " + trueday + "-" + TxtHariTgl.Text + "</p></div></div><div ><div ><p><b>Waktu</b> : " + TxtPukul.Text + "</p></div></div><div ><div ><p><b>Alamat</b> : " + DDAlamat.SelectedValue + "</p></div></div><div ><div ><p><b>Membawa</b> : CV Lengkap, Alat Tulis (Penghapus, Pensil HB, Pulpen)</p></div></div><div ><div ><p><b>Bertemu</b> : " + TxtBertemu.Text + "</p></div></div><br /><p>Harap untuk membalas email ini untuk konfirmasi kehadiran anda, atau bisa menghubungi nomor What’s App berikut 089649750950</p><p>Terima Kasih</p><br /><br /><br /><p>Regards, </p><b><p>Retno Syifa Fauziah</p></b><p>Staff Recruitment HONDA MUGEN</p><p>PT. Mitrausaha Gentaniaga</p><p>Jl. Raya Pasar Minggu No. 10 Jakarta Selatan 12740</p><p>Tlp. (021) 797 2000 (Bengkel), (021) 797 3000 (Showroom)</p><p>Ext. 167</p><p>Email : recruitment@hondamugen.co.id</p>";
            webcontent.InnerHtml = isiemail;
            this.Session["HTMLEmailBody"] = isiemail;
            this.Session["SubjectEmail"] = TxtSubject.Text;
        }
        else
        {
            Response.Write("<script>alert('Masih Ada Field yang Kurang, Harap di Isi!')</script>");
        }
    }
}