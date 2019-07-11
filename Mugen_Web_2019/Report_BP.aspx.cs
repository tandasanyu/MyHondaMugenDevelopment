using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;

using iTextSharp.text.pdf;

using iTextSharp.text.html;

using System.IO;
using System.Text.RegularExpressions;
using iTextSharp.text.html.simpleparser;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Web.Configuration;

public partial class Report_BP : System.Web.UI.Page
{
    public string wo;
    public string cabang;
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        wo = Request.QueryString["qnowo"];
        cabang = Request.QueryString["cabang"];
        NoWo.Text = wo;
        LblWo.Text = wo;
        if (cabang == "112")
        {
            LblAlamat.Text = "Jl. Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia";
            Lbltelp.Text = "Telp : (021) 797 3000 (Show Room), 797 2000 (Bengkel)";
            LblFax.Text = "Fax : (021) 7973834";
            LblHttp.Text = "Web : www.hondamugen.co.id";
            TxtEmailReciever.Text = "richard.nurtjahja@gmail.com";
            TxtEmailReciever2.Text = "adm_bodyrepair@hondamugen.co.id";
            TxtEmailReciever.ReadOnly = true;
            TxtEmailReciever2.ReadOnly = true;
        }
        else
        {
            LblAlamat.Text = "Jl. Lingkar Luar Barat, Puri Kembangan Jakarta Barat 11610 - Indonesia";
            Lbltelp.Text = "Telp : Showroom (021) 5835 8000, Bengkel (021) 5835 9000";
            LblFax.Text = "Fax : (021) 5835 7942 ";
            LblHttp.Text = "Web : www.hondamugen.co.id";
            TxtEmailReciever.Text = "richard.nurtjahja@gmail.com";
            TxtEmailReciever2.Text = "Piutangservicepuri@hondamugen.co.id";
            TxtEmailReciever.ReadOnly = true;
            TxtEmailReciever2.ReadOnly = true;
        }
        LblAlamat.Visible = false;
        Lbltelp.Visible = false;
        LblFax.Visible = false;
        LblHttp.Visible = false;
        Label2.Visible = false;
        Label3.Visible = false;
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Wo : "+wo+" -- Cabang "+cabang+"')", true);
        if (cabang =="112") {
            //new process
            string sqlcmd_ = " select CONTROLBR_TGLESELESAI from TEMP_CONTROLBR where CONTROLBR_NOWO ='" + wo + "'";
            List<String> hasil = new List<String>();
            hasil = KelasKoneksi_SelectGlobal(sqlcmd_, "1", cabang);
            foreach (string data in hasil)
            {
                LblTanggalEstimasi.Text = data;
            }
            
            //new process
            DataSet ds = new DataSet();
            string sql = "SELECT [KERJABODY_NOWO], [KERJABODY_TANGGAL], [KERJABODY_USER],case [KERJABODY_STATUS]  WHEN 1 THEN 'DISERAHKAN SA KE VENDOR' when 2 then 'DISERAHKAN SA KE DRIVER' when 3 then 'DITERIMA' when 4 then 'BONGKAR' when 5 then 'KETOK' when 6 then 'DEMPUL' when 7 then 'CAT/OVEN' when 8 then 'POLES' when 9 then 'PEMASANGAN' when 10 then 'FINISHING' when 11 then 'PENILAIAN QC - OK' when 12 then 'PENILAIAN QC - NOT OK' when 13 then 'PENILAIAN QC - REWORK' when 14 then 'PENILAIAN QC - REWORK - OK' when 15 then 'PENILAIAN QC - REWORK - NOT OK' when 16 then 'PENYERAHAN UNIT QC KE SA BP' else 'UNCATEGORIZED' end AS statusval, case [KERJABODY_LOKASI] when 1 then 'lt. 1' when 2 then 'lt. 2' when 3 then 'lt. 3' when 4 then 'lt. 4' when 5 then 'lt. 5' when 6 then 'lt. 6' when 7 then 'lt. 7' when 8 then 'lt. 8' when 9 then 'lt. 9'  else '' END AS lokasimobil, [KERJABODY_CATATAN] FROM [TEMP_KERJABODY] WHERE ([KERJABODY_NOWO] = " + wo + ") ORDER BY KERJABODY_STATUS ASC";
            ds = getDataSet(sql, 1);
            LvReportBP.DataSource = ds;
            LvReportBP.DataBind();
        } else {
            //new process
            string sqlcmd_ = " select CONTROLBR_TGLESELESAI from TEMP_CONTROLBR where CONTROLBR_NOWO ='" + wo + "'";
            List<String> hasil = new List<String>();
            hasil = KelasKoneksi_SelectGlobal(sqlcmd_, "1", cabang);
            foreach (string data in hasil)
            {
                LblTanggalEstimasi.Text = data;
            }
            //new process
            DataSet ds = new DataSet();
            string sql = "SELECT [KERJABODY_NOWO], [KERJABODY_TANGGAL], [KERJABODY_USER],case [KERJABODY_STATUS]  WHEN 1 THEN 'DISERAHKAN SA KE VENDOR' when 2 then 'DISERAHKAN SA KE DRIVER' when 3 then 'DITERIMA' when 4 then 'BONGKAR' when 5 then 'KETOK' when 6 then 'DEMPUL' when 7 then 'CAT/OVEN' when 8 then 'POLES' when 9 then 'PEMASANGAN' when 10 then 'FINISHING' when 11 then 'PENILAIAN QC - OK' when 12 then 'PENILAIAN QC - NOT OK' when 13 then 'PENILAIAN QC - REWORK' when 14 then 'PENILAIAN QC - REWORK - OK' when 15 then 'PENILAIAN QC - REWORK - NOT OK' when 16 then 'PENYERAHAN UNIT QC KE SA BP' else 'UNCATEGORIZED' end AS statusval, case [KERJABODY_LOKASI] when 1 then 'lt. 1' when 2 then 'lt. 2' when 3 then 'lt. 3' when 4 then 'lt. 4' when 5 then 'lt. 5' when 6 then 'lt. 6' when 7 then 'lt. 7' when 8 then 'lt. 8' when 9 then 'lt. 9'  else '' END AS lokasimobil, [KERJABODY_CATATAN] FROM [TEMP_KERJABODY] WHERE ([KERJABODY_NOWO] = " + wo + ") ORDER BY KERJABODY_STATUS ASC";
            ds= getDataSet(sql, 2);
            LvReportBP.DataSource = ds;
            LvReportBP.DataBind();
        }

    }
    //fungsi read data from db 
    public List<String> GlobalAr = new List<String>();
    public string status;
    public List<String> KelasKoneksi_SelectGlobal(string SqlCmd, string sub, string cab)
    {
        //serviceConnection & service128Connection
        string connect = string.Empty;
        if (cab == "112") {
            connect = "serviceConnection";
        }
        else
        {
            connect = "service128Connection";
        }
        String strconn = WebConfigurationManager.ConnectionStrings[connect].ConnectionString;
        conn = new SqlConnection(strconn);
        string sql = SqlCmd;
        cmd = new SqlCommand(sql, conn);
        SqlDataReader reader; //Menggunakan data reader untuk select dan mengambil value nya 

        GlobalAr.Clear();
        try
        {
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (sub == "1")
                {
                    GlobalAr.Add(reader["CONTROLBR_TGLESELESAI"].ToString()); //0
                }        
            }
        }
        catch (SqlException ex)
        {
            status = "Terjadi error Ketika Select: " + ex.Message;
            GlobalAr.Clear();
            GlobalAr.Add(status);
            // return ArrayLogin;

        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }

        return GlobalAr;
    }
    //fungsi get data set untuk listview
    public DataSet getDataSet(string sql, int cabang)
    {
        string koneksi;
        DataSet ds = new DataSet();
        if (cabang == 1) {
            koneksi = "serviceConnection";
        } else {
            koneksi = "service128Connection";
        }
        String strconn = WebConfigurationManager.ConnectionStrings[koneksi].ConnectionString;
        conn = new SqlConnection(strconn);
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        try
        {
            conn.Open();
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            ds = null;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
            da.Dispose();
        }

        return ds;
    }

    protected void BtnKirimEmail_Click(object sender, EventArgs e) // bisa di eksekusi oleh user budi / linda ketika proses sudah sampe prosesnya budi
    {
        //cek state aktivitas bp sampai mana

            var doc = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
            //added**********
            StringWriter sw = new StringWriter();


            HtmlTextWriter w = new HtmlTextWriter(sw);
            print.RenderControl(w);


            string htmWrite = sw.GetStringBuilder().ToString();
            htmWrite = Regex.Replace(htmWrite, "</?(a|A).*?>", "");
            htmWrite = htmWrite.Replace("\r\n", "");
            StringReader reader = new StringReader(htmWrite);

            HTMLWorker htmlparser = new HTMLWorker(doc);
            //added************
            doc.Open();
            var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);

        //doc.Add(new Paragraph("Laporan Aktivitas Pekerjaan BP " + DateTime.Now.ToShortDateString() + "", titleFont));
        //doc.Add(new Paragraph("No WO : " + wo + "", titleFont));
        //add logo

        //end of add logo 
        //font
        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
        Font times = new Font(bfTimes, 10, Font.NORMAL);
        Font timesubhead = new Font(bfTimes, 12, Font.NORMAL);
        //****add img
        string imageURL = Server.MapPath(".") + "/honda.jpg";
        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
        //Resize image depend upon your need
        jpg.ScaleToFit(160f, 140f);
        //Give space before image
        //jpg.SpacingBefore = 0f;
        //Give some space after the image
        //jpg.SpacingAfter = 0f;
        //jpg.Alignment = Element.ALIGN_LEFT;

        jpg.SetAbsolutePosition(420, 690);//jpg.Alignment = 6; x/y
        doc.Add(jpg);

        if (cabang == "112")
        {
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Honda Mugen", timesubhead));
            doc.Add(new Paragraph("PT. Mitra Usaha Gentaniaga", times));
            doc.Add(new Paragraph("Jl. Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia", times));
            doc.Add(new Paragraph("Telp : (021) 797 3000 (Show Room), 797 2000 (Bengkel)", times));
            doc.Add(new Paragraph("Fax : (021) 79738341", times));
            doc.Add(new Paragraph("Web: www.hondamugen.co.id", times));
            //add by img

        }
        else
        {
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Honda Mugen", timesubhead));
            doc.Add(new Paragraph("PT. Mitra Usaha Gentaniaga", times));
            doc.Add(new Paragraph("Jl. Lingkar Luar Barat, Puri Kembangan Jakarta Barat 11610 - Indonesia", times));
            doc.Add(new Paragraph("Telp : (021) 5835 8000(Show Room), (021) 5835 9000 (Bengkel)", times));
            doc.Add(new Paragraph("Fax : (021) 5835 7942", times));
            doc.Add(new Paragraph("Web: www.hondamugen.co.id", times));

        }
        htmlparser.Parse(reader);

            writer.CloseStream = false;
            doc.Close();
            memoryStream.Position = 0;
            string penerima_2 = TxtEmailReciever2.Text;
            string penerima = TxtEmailReciever.Text + "," + penerima_2;
            
            //mailMessage.CC.Add(new MailAddress(cc)); //Adding CC email Id
            MailMessage mm = new MailMessage("hmugen1991@gmail.com", penerima )
            {
                Subject = "Laporan Aktivitas BP - " + DateTime.Now.ToShortDateString() + " - " + wo + "",
                
                IsBodyHtml = true,
                Body = "Berikut Telampir Laporan Aktivitas Body Paint untuk No. WO = " + wo + "."
                
            };

        
        mm.Attachments.Add(new Attachment(memoryStream, "ReportAktivitasBP_" + DateTime.Now.ToShortDateString() + "_" + wo + ".pdf"));
        SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("hmugen1991@gmail.com", "112m128p")

            };

            smtp.Send(mm);

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Berhasil Mengirim Laporan BP ke Email!')", true);
        
    }
    //



    protected void BtnDownload_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=TestReport.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);


        StringWriter sw = new StringWriter();


        HtmlTextWriter w = new HtmlTextWriter(sw);
        print.RenderControl(w);


        string htmWrite = sw.GetStringBuilder().ToString();
        htmWrite = Regex.Replace(htmWrite, "</?(a|A).*?>", "");
        htmWrite = htmWrite.Replace("\r\n", "");
        StringReader reader = new StringReader(htmWrite);

        Document doc = new Document(PageSize.A4, 36f, 36f, 0f, 0f);//10f, 10f, 100f, 0f
        //string pdfFilePath = Server.MapPath(".") + "/img";

        HTMLWorker htmlparser = new HTMLWorker(doc);
        PdfWriter.GetInstance(doc, Response.OutputStream);

        doc.Open();

        var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
        var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
        //font
        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
        Font times = new Font(bfTimes, 10, Font.NORMAL);
        Font timesubhead = new Font(bfTimes, 12, Font.NORMAL);
        //****add img
        //string imageURL = Server.MapPath(".") + "/honda.jpg";
        //iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
        ////Resize image depend upon your need
        //jpg.ScaleToFit(160f, 140f);
        ////Give space before image
        ////jpg.SpacingBefore = 0f;
        ////Give some space after the image
        ////jpg.SpacingAfter = 0f;
        ////jpg.Alignment = Element.ALIGN_LEFT;
        
        //jpg.SetAbsolutePosition(440, 720);//jpg.Alignment = 6; x/y
        //doc.Add(jpg);
        
        if (cabang=="112") {
            //doc.Add(new Paragraph(" "));
            //doc.Add(new Paragraph("Honda Mugen", timesubhead));
            //doc.Add(new Paragraph("PT. Mitra Usaha Gentaniaga", times));
            //doc.Add(new Paragraph("Jl. Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia", times));
            //doc.Add(new Paragraph("Telp : (021) 797 3000 (Show Room), 797 2000 (Bengkel)", times));
            //doc.Add(new Paragraph("Fax : (021) 79738341", times));
            //doc.Add(new Paragraph("Web: www.hondamugen.co.id", times));
            //add img
            //doc.Add(new Paragraph(" "));
            //doc.Add(new Paragraph("Honda Mugen", timesubhead));
            //doc.Add(new Paragraph("PT. Mitra Usaha Gentaniaga", times));
            //doc.Add(new Paragraph("Jl. Lingkar Luar Barat, Puri Kembangan Jakarta Barat 11610 - Indonesia", times));
            //doc.Add(new Paragraph("Telp : (021) 5835 8000(Show Room), (021) 5835 9000 (Bengkel)", times));
            //doc.Add(new Paragraph("Fax : (021) 5835 7942", times));
            //doc.Add(new Paragraph("Web: www.hondamugen.co.id", times));
            //*******************add by img
            string imageURL = Server.MapPath(".") + "/Header.jpg";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            //Resize image depend upon your need
            jpg.ScaleToFit(550,1000); //x/y
            //Give space before image
            //jpg.SpacingBefore = 0f;
            //Give some space after the image
            //jpg.SpacingAfter = 0f;
            //jpg.Alignment = Element.ALIGN_LEFT;

            jpg.SetAbsolutePosition(20, 690);//jpg.Alignment = 6; x/y
            doc.Add(jpg);
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
        } else {
            //doc.Add(new Paragraph(" "));
            //doc.Add(new Paragraph("Honda Mugen", timesubhead));
            //doc.Add(new Paragraph("PT. Mitra Usaha Gentaniaga", times));
            //doc.Add(new Paragraph("Jl. Lingkar Luar Barat, Puri Kembangan Jakarta Barat 11610 - Indonesia", times));
            //doc.Add(new Paragraph("Telp : (021) 5835 8000(Show Room), (021) 5835 9000 (Bengkel)", times));
            //doc.Add(new Paragraph("Fax : (021) 5835 7942", times));
            //doc.Add(new Paragraph("Web: www.hondamugen.co.id", times));
            //*******************add by img
            string imageURL = Server.MapPath(".") + "/Header2.jpg";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            //Resize image depend upon your need
            jpg.ScaleToFit(550, 1000); //x/y
            //Give space before image
            //jpg.SpacingBefore = 0f;
            //Give some space after the image
            //jpg.SpacingAfter = 0f;
            //jpg.Alignment = Element.ALIGN_LEFT;

            jpg.SetAbsolutePosition(20, 690);//jpg.Alignment = 6; x/y
            doc.Add(jpg);
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
        }

        //doc.Add(jpg);
        //*****add img
        try
        {
            htmlparser.Parse(reader);
            doc.Close();
            Response.Write(doc);
            Response.End();
        }
        catch (Exception ex)
        { }
        finally
        {
            doc.Close();
        }
    }
}