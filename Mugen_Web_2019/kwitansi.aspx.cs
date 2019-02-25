using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class kwitansi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string prosKw = Request.QueryString["proses"];
        string noKw = Request.QueryString["nokw"];
        string terimaKw = Request.QueryString["terimakw"];
        string jumlahKw = Request.QueryString["jumlahkw"];
        string terbilangKw = Request.QueryString["terbilangkw"];
        string untukKw = Request.QueryString["untukkw"];

        if (prosKw == "1") {
            input.Visible = false;
            hasil.Visible = true;
            lblNoKw.Text = noKw;
            lblTerimaKw.Text = terimaKw;
            lblJumlahKw.Text = jumlahKw;
            lblUntukKw.Text = untukKw;
            lblTerbilangKw.Text = "#"+terbilangKw+"#";
        }
        else
        {
            input.Visible = true;
            hasil.Visible = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string nomorKw = txtNomor.Text;
        string terimaKw = txtTerima.Text;
        string jumlahKw = txtJumlah.Text;
        string terbilangKw = txtTerbilang.Text;
        string untukKw = txtUntuk.Text;

        if(nomorKw == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('No Kwitansi belum diisi !');</script>");
        }
        else if(terimaKw == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Terima dari belum diisi !');</script>");
        }
        else if (jumlahKw == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Jumlah kwitansi belum diisi !');</script>");
        }
        else if (terbilangKw == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Terbilang belum diisi !');</script>");
        }
        else if (untukKw == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Untuk pembayaran belum diisi !');</script>");
        }
        else
        {
            Response.Redirect("kwitansi.aspx?proses=1&nokw=" + nomorKw + "&terimakw=" + terimaKw + "&jumlahkw=" + jumlahKw + "&terbilangkw=" + terbilangKw + "&untukkw=" + untukKw + "");
        }
       
    }
}