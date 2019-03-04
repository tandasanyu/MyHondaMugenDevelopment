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
        string val1;
        val1 = Request.QueryString["Menu"];
        if (val1 == null ) {
            MultiViewHRD.ActiveViewIndex = 0;
        }
        else {
            if (val1 == "0")
            {
                MultiViewHRD.ActiveViewIndex = 0;
            }
            else if (val1 == "1")
            {
                MultiViewHRD.ActiveViewIndex = 1;
            }
            else if (val1 == "2")
            {
                MultiViewHRD.ActiveViewIndex = 2;
            }
        }
       
    }


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
}