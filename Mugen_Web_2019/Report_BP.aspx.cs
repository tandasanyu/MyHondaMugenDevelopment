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
    protected void Page_Load(object sender, EventArgs e)
    {
        wo = Request.QueryString["qnowo"];
        NoWo.Text = wo;
        LblWo.Text = wo;
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Wo : "+wo+"')", true);

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

    protected void BtnKirimEmail_Click(object sender, EventArgs e)
    {
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
        //PdfWriter.GetInstance(doc, Response.OutputStream);

        //doc.Open();


        //try
        //{
        //    //htmlparser.Parse(reader);
        //    ////doc.Close();
        //    //Response.Write(doc);
        //    //Response.End();
        //}
        //catch (Exception ex)
        //{ }
        //finally
        //{
        //    //doc.Close();
        //}
        //added************
        doc.Open();
        var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
        var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);

        //doc.Add(new Paragraph("Laporan Aktivitas Pekerjaan BP " + DateTime.Now.ToShortDateString() + "", titleFont));
        //doc.Add(new Paragraph("No WO : " + wo + "", titleFont));
        htmlparser.Parse(reader);

        writer.CloseStream = false;
        doc.Close();
        memoryStream.Position = 0;

        MailMessage mm = new MailMessage("tandasanyu@gmail.com", "tandasanyu@gmail.com")
        {
            Subject = "Laporan Aktivitas BP",
            IsBodyHtml = true,
            Body = "body"
        };

        mm.Attachments.Add(new Attachment(memoryStream, "ReportAktivitasBP_"+DateTime.Now.ToShortDateString()+"_"+wo+".pdf"));
        SmtpClient smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            Credentials = new NetworkCredential("tandasanyu.movie1@gmail.com", "herlambang17")

        };

        smtp.Send(mm);
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

        Document doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //string pdfFilePath = Server.MapPath(".") + "/img";

        HTMLWorker htmlparser = new HTMLWorker(doc);
        PdfWriter.GetInstance(doc, Response.OutputStream);

        doc.Open();

        var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
        var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);

        //doc.Add(new Paragraph("Laporan Aktivitas Pekerjaan BP "+DateTime.Now.ToShortDateString()+"", titleFont));
        //doc.Add(new Paragraph("No WO : "+wo+"", titleFont));
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