using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PagesHRD_HomeHRD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            string val1;
            val1 = Request.QueryString["Menu"];
            if (val1 == null)
            {
                MultiViewHRD.ActiveViewIndex = 0;
            }
            else
            {
                if (val1 == "0") // MENU HOME
                {
                    MultiViewHRD.ActiveViewIndex = 0;
                }
                else if (val1 == "1") // MENU LIST LOWONGAN KERJA
                {
                    MultiViewHRD.ActiveViewIndex = 1;
                }
                else if (val1 == "2") // DATA PELAMAR (YANG SUDAH DI TERIMA)
                {
                    MultiViewHRD.ActiveViewIndex = 2;
                }
            }
        }
        else {
            Response.Redirect("~/Login.aspx");
        }
       
    }
    ////btn download foto
    //protected void linkbuttonFoto_Click(object sender, EventArgs e)
    //{

    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
    //    "alert('Download FOTO'); window.location='" +
    //    Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx?Menu=0';", true);
    //}
    //list string ID Lowongan
    //KUMPULAN FUNGSI DOWNLOAD BY BUTTON
    //*****  ListViewPelamarTerproses
    protected void LinkButtonForm2_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;
        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = ListViewPelamarTerproses.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString(); ///PagesHRD/FormPelamar.aspx
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"window.location='" +
        //Request.ApplicationPath + "../PagesHRD/FormPelamar.aspx?Id="+ DataKeyvalue + "';", true);
        Response.Write("<script language='javascript'>{window.open('../PagesHRD/FormPelamar.aspx?Id=" + DataKeyvalue + "');}</script>");
    }
    protected void LinkButtonFoto2_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = ListViewPelamarTerproses.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('Photo ID : "+ DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadFoto where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/Foto/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonKTP2_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = ListViewPelamarTerproses.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadKTP where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/KTP/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonNPWP2_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = ListViewPelamarTerproses.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadNPWP where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/NPWP/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonKK2_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = ListViewPelamarTerproses.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadKK where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/KK/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonIjazah2_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = ListViewPelamarTerproses.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadIjazah where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/Ijazah/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonNilai2_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = ListViewPelamarTerproses.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadTranskrip where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/Transkrip/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonLamaran2_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = ListViewPelamarTerproses.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadSLamaran where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/Lamaran/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonCV2_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = ListViewPelamarTerproses.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadCV where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/CV/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    //***
    protected void LinkButtonForm_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;
        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString(); ///PagesHRD/FormPelamar.aspx
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"window.location='" +
        //Request.ApplicationPath + "../PagesHRD/FormPelamar.aspx?Id="+ DataKeyvalue + "';", true);
        Response.Write("<script language='javascript'>{window.open('../PagesHRD/FormPelamar.aspx?Id=" + DataKeyvalue + "');}</script>");
    }
    protected void LinkButtonFoto_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('Photo ID : "+ DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadFoto where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/Foto/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonKTP_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadKTP where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/KTP/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonNPWP_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadNPWP where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/NPWP/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonKK_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadKK where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/KK/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonIjazah_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadIjazah where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/Ijazah/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonNilai_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadTranskrip where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/Transkrip/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonLamaran_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadSLamaran where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/Lamaran/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonCV_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        //"alert('KTP ID : " + DataKeyvalue + "');window.location='" +
        //Request.ApplicationPath + "../PagesHRD/HomeHRD.aspx';", true);
        string path = string.Empty;
        string filename = string.Empty;
        //open con
        KelasKoneksi cn = new KelasKoneksi();
        List<String> Path_Foto = cn.KelasKoneksi_SelectGlobal("select Path_Foto from Data_UploadCV where Id_lamaran = " + Convert.ToInt32(DataKeyvalue) + "", "7");
        if (Path_Foto.Count > 0)
        {
            path = "~/UploadFile/CV/" + Path_Foto[0] + "";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename = " + Path_Foto[0] + "");
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Tidak Di Temukan')", true);
        }
    }
    protected void LinkButtonProses_Click(object sender, EventArgs e) // status undangan = 1  jika di undang
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+DataKeyvalue+"')", true);
        KelasKoneksi cn = new KelasKoneksi();
        string Hasil = cn.KelasKoneksi_Update("Update Data_Lamaran set status_Undangan = 1 where Id_Lamaran ="+ DataKeyvalue + " ");
        if (Hasil == "1") {
            LvPelamarBaru.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sukses Memproses Pelamar, Silahkan Cek di Menu Pelamar untuk Detailnya')", true);
        } else {
            LvPelamarBaru.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Gagal Memproses Pelamar, terdapat Error : "+ Hasil + "')", true);
        }
    }
    protected void LinkButtonTolak_Click(object sender, EventArgs e) // status lamaran = 2 maka data di tolak
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + DataKeyvalue + "')", true);
        KelasKoneksi cn = new KelasKoneksi();
        string Hasil = cn.KelasKoneksi_Update("Update Data_Lamaran set status_Lamaran = 2 where Id_Lamaran =" + DataKeyvalue + " ");
        if (Hasil == "1")
        {
            LvPelamarBaru.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sukses Menolak Pelamar!')", true);
            
        }
        else
        {
            LvPelamarBaru.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Gagal Menolak Pelamar, terdapat Error : " + Hasil + "')", true);
        }
    }
    protected void LinkButtonUndang_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //Response.Write("<script>alert('"+DataKeyvalue+"')</script>");
        Response.Redirect("Undang_Interview.aspx?idlamaran="+DataKeyvalue+"");
        //get id login dari Data_Lamaran where id_lamaran dari listview values

        //get email dari Login_User where id_login (user_email)
    }
    protected void LinkButtonUndangpsikotest_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;

        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString();
        //Response.Write("<script>alert('"+DataKeyvalue+"')</script>");
        Response.Redirect("Undang_Psikotest.aspx?idlamaran=" + DataKeyvalue + "");
    }
    //***

        //fungsi download foto ***************************************************

    protected void BtnCoba_Click(object sender, EventArgs e)
    {
        
    }

    //list string ID Lowongan
       private List<int> ID_low
        {
            get
            {
                if (this.ViewState["ID_low"] == null)
                {
                    this.ViewState["ID_low"] = new List<int>();
                }
                return (List<int>)this.ViewState["ID_low"];
            }
        }

    //hapus lowongan - aktif
    protected void BtnHapus_Click(object sender, EventArgs e)
    {
        //get id from listview
        ID_low.Clear();
        foreach (ListViewDataItem item in LvListLowongan.Items)
        {
            CheckBox chkSelect = (CheckBox)item.FindControl("CheckBoxListLowongan");
            if (chkSelect != null)
            {
                int ID = Convert.ToInt32(chkSelect.Attributes["value"]);
                if (chkSelect.Checked && !this.ID_low.Contains(ID))
                {
                    this.ID_low.Add(ID);
                }
                else if (!chkSelect.Checked && this.ID_low.Contains(ID))
                {
                    this.ID_low.Remove(ID);
                }
            }
        }
        //
        if (ID_low != null && ID_low.Count > 0)
        {
            KelasKoneksi cn = new KelasKoneksi();



            int count = 0;
            foreach (int element in ID_low)
            {
                count++;
                //Response.Write("<script>alert('List ID Terpilih : " + element.ToString() + " ')</script>");
                string query_delete = "Delete from List_Lowongan where id_lowongan = '" + element + "'";
                string hasil = cn.KelasKoneksi_Delete(query_delete);
                if (hasil == "1")
                {
                    Response.Write("<script>alert('Berhasil Hapus Lowongan dengan ID : " + element + "')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Gagal Hapus Lowongan')</script>");
                }
            }

        }
        else
        {
            Response.Write("<script>alert('Harap Pilih Lowongan yang akan di Hapus ')</script>");
        }
        LvListLowongan.DataBind();
    }

    //nonaktifkan lowongan - aktif
    protected void BtnNonAktif_Click(object sender, EventArgs e)
    {
        ID_low.Clear();
        foreach (ListViewDataItem item in LvListLowongan.Items)
        {
            CheckBox chkSelect = (CheckBox)item.FindControl("CheckBoxListLowongan");
            if (chkSelect != null)
            {
                int ID = Convert.ToInt32(chkSelect.Attributes["value"]);
                if (chkSelect.Checked && !this.ID_low.Contains(ID))
                {
                    this.ID_low.Add(ID);
                }
                else if (!chkSelect.Checked && this.ID_low.Contains(ID))
                {
                    this.ID_low.Remove(ID);
                }
            }
        }
        if (ID_low != null && ID_low.Count > 0)
        {
            KelasKoneksi cn = new KelasKoneksi();
            

            int count = 0;
            foreach (int element in ID_low)
            {
                count++;
                //Response.Write("<script>alert('List ID Terpilih : " + element.ToString() + " ')</script>");
                string query_update = "update List_Lowongan set Status_Lowongan=0 where id_lowongan = '" + element + "'";
                string hasil = cn.KelasKoneksi_Update(query_update);
                if (hasil == "1") {
                    Response.Write("<script>alert('Berhasil NonAktifkan Lowongan dengan ID : "+element+"')</script>");
                } else
                {
                    Response.Write("<script>alert('Gagal NonAktifkan Lowongan')</script>");
                }
            }

        }
        else {
            Response.Write("<script>alert('Harap Pilih Lowongan yang akan di Non Aktifkkan ')</script>");
        }
        LvListLowongan.DataBind();
    }
    //aktifkan lowongan
    protected void BtnAktif_Click(object sender, EventArgs e)
    {
        ID_low.Clear();
        foreach (ListViewDataItem item in LvListLowongan.Items)
        {
            CheckBox chkSelect = (CheckBox)item.FindControl("CheckBoxListLowongan");
            if (chkSelect != null)
            {
                int ID = Convert.ToInt32(chkSelect.Attributes["value"]);
                if (chkSelect.Checked && !this.ID_low.Contains(ID))
                {
                    this.ID_low.Add(ID);
                }
                else if (!chkSelect.Checked && this.ID_low.Contains(ID))
                {
                    this.ID_low.Remove(ID);
                }
            }
        }
        if (ID_low != null && ID_low.Count > 0)
        {
            KelasKoneksi cn = new KelasKoneksi();


            int count = 0;
            foreach (int element in ID_low)
            {
                count++;
                //Response.Write("<script>alert('List ID Terpilih : " + element.ToString() + " ')</script>");
                string query_update = "update List_Lowongan set Status_Lowongan=1 where id_lowongan = '" + element + "'";
                string hasil = cn.KelasKoneksi_Update(query_update);
                if (hasil == "1")
                {
                    Response.Write("<script>alert('Berhasil Aktifkan Lowongan dengan ID : " + element + "')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Gagal Aktifkan Lowongan')</script>");
                }
            }

        }
        else
        {
            Response.Write("<script>alert('Harap Pilih Lowongan yang akan di  Aktifkkan ')</script>");
        }
        LvListLowongan.DataBind();
    }

    public string val1;


}