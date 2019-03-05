using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
//ADO NET NAME SPACE
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class PagesUser_PageUser_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string posisi = Request.QueryString["Posisi"];
        TxtPosisi.Text = posisi;
        TxtPosisi.ReadOnly = true;
    }
    //untuk fungsi pendukung captcha
    public class MyObject
    {
        public string success { get; set; }
    }
    public bool Validate()
    {
        string Response = Request["g-recaptcha-response"];//Getting Response String Append to Post Method
        bool Valid = false;
        //Request to Google Server
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create
        (" https://www.google.com/recaptcha/api/siteverify?secret=6LfYd5QUAAAAABIjga_sFUYQ49s2q5x5AXypqenX&response=" + Response);
        try
        {
            //Google recaptcha Response
            using (WebResponse wResponse = req.GetResponse())
            {

                using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                {
                    string jsonResponse = readStream.ReadToEnd();

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    MyObject data = js.Deserialize<MyObject>(jsonResponse);// Deserialize Json

                    Valid = Convert.ToBoolean(data.success);
                }
            }

            return Valid;
        }
        catch (WebException ex)
        {
            throw ex;
        }
    }
    protected void BtnDaftar_Click(object sender, EventArgs e)
    {
        //validasi captcha
        if (Validate())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lamaran Anda Telah di Simpan !')", true);
            //lblmsg.Text = "Valid Recaptcha";
            //lblmsg.ForeColor = System.Drawing.Color.Green;
        }

        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Gagal menyimpan, Harap Centang Captcha !')", true);
            //lblmsg.Text = "Not Valid Recaptcha";
            //lblmsg.ForeColor = System.Drawing.Color.Red;
        }
    }
}