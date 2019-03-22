using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data.OleDb;
using System.Web.Security;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Globalization;
using System.Configuration;

public partial class PageUser_PageUser_UploadFoto : System.Web.UI.Page
{
    public string IdLamar;
    protected void Page_Load(object sender, EventArgs e)
    {
        //ketika page load, makadi periksa setiap dokumen dengan nomor id lamaran berikut apakah ada. jika ada maka hide tombol
        if (Session["User"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        //get url param       
        IdLamar = Request.QueryString["IdLamaran"];
        //Response.Write("<script language=javascript>alert('Value : "+IdLamar+"');</script>");
    }

    protected void SubmitFoto_Click(object sender, EventArgs e)
    {
        //string uploadFolder = Request.PhysicalApplicationPath + "UploadFile\\";
        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string nama = IdLamar;
            //FileUpload1.SaveAs(uploadFolder + "Test" + extension);
            Label2.Visible = true;
            Label2.Text = "File Sukses TerUpload dengan Nama: " + "Foto_" + nama + "" + extension + " dengan User : " + Session["User"] + " ";
            //imgPath
            string imgPath = "~/UploadFile/Foto/" + nama + extension; 
            //Upload File 
            FileUpload1.SaveAs(Server.MapPath(imgPath));

            //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('File Tersimpan!')", true);

            byte[] theImage = new byte[FileUpload1.PostedFile.ContentLength];
            HttpPostedFile Image = FileUpload1.PostedFile;
            Image.InputStream.Read(theImage, 0, (int)FileUpload1.PostedFile.ContentLength);

            int length = theImage.Length;
            string fileName = FileUpload1.FileName.ToString();
            string type = FileUpload1.PostedFile.ContentType;

            int size = FileUpload1.PostedFile.ContentLength;
            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            {
                string Hasil; 
                KelasKoneksi cn = new KelasKoneksi();
                Hasil = cn.KelasKoneksi_Insert("Insert into Data_UploadFoto values ("+Convert.ToInt32(IdLamar) +",'"+nama+extension+"' )");
                if (Hasil == "1") {
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('File Berhasil di Upload!')", true);
                }
                else {
                    Label2.Text = "Terdapat Error! PESAN ERROR: " + Hasil + "";
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('Terdapat Error! PESAN ERROR: "+Hasil+"')", true);
                }
                
            }
        }
        else
        {
            Label2.Text = "First select a file.";
        }
    }
}