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
    //***
    protected void LinkButtonForm_Click(object sender, EventArgs e)
    {
        var button = sender as LinkButton;
        // Get the selected listview item
        ListViewItem item = button.NamingContainer as ListViewItem;
        // Get the datakey from listview
        // Change the listview id and datakey name here
        string DataKeyvalue = LvPelamarBaru.DataKeys[item.DataItemIndex].Values["Id_lamaran"].ToString(); ///PagesHRD/FormPelamar.aspx
        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        "window.location='" +
        Request.ApplicationPath + "../PagesHRD/FormPelamar.aspx?Id=6';", true);
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
        path = "~/UploadFile/Foto/" + DataKeyvalue + ".jpg";
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("content-disposition", "filename = " + DataKeyvalue + ".jpg");
        Response.TransmitFile(Server.MapPath(path));
        Response.End();
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
        path = "~/UploadFile/KTP/" + DataKeyvalue + ".jpg";
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("content-disposition", "filename = " + DataKeyvalue + ".jpg");
        Response.TransmitFile(Server.MapPath(path));
        Response.End();
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