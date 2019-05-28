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

public partial class Report_BP : System.Web.UI.Page
{
    public string wo;
    public string cabang;
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
        }
        else
        {
            LblAlamat.Text = "Jl. Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia";
            Lbltelp.Text = "Telp : (021) 797 3000 (Show Room), 797 2000 (Bengkel)";
            LblFax.Text = "Fax : (021) 7973834";
            LblHttp.Text = "Web : www.hondamugen.co.id";
        }
        LblAlamat.Visible = false;
        Lbltelp.Visible = false;
        LblFax.Visible = false;
        LblHttp.Visible = false;
        Label2.Visible = false;
        Label3.Visible = false;
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Wo : "+wo+" -- Cabang "+cabang+"')", true);

    }

    private DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["serviceConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            sda.Dispose();
            con.Dispose();
        }
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
            string imageURL = Server.MapPath(".") + "/Header.jpg";
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