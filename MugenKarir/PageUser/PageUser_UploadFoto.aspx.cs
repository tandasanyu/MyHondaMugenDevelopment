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
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubmitFoto_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid )
        //{
        //    string filereceived = FileUpload1.PostedFile.FileName;
        //    string filename = Path.GetFileName(filereceived);
        //}
        string uploadFolder = Request.PhysicalApplicationPath + "UploadFile\\";
        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string nama = "Herlambang";
            //FileUpload1.SaveAs(uploadFolder + "Test" + extension);
            Label2.Text = "File Sukses TerUpload dengan Nama: " + "Foto_"+nama+"" + extension;
        }
        else
        {
            Label2.Text = "First select a file.";
        }
    }
}