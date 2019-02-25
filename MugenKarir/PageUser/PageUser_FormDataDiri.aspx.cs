using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageUser_PageUser_FormDataDiri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    //BIG NOTE*****
    //telpon rumah tidak wajib di isi
    //validasi jika rbList Jenis alamat dipilih Berbeda dengan KTP maka text area bisa di isi dan di validasi tidak bole kosong

    protected void BtnSubmitFormDataDiri_Click(object sender, EventArgs e)
    {
        string nama = TxtNamaLengkap.Text;
        string tempatlahir = TxtTempatLahir.Text;
        string selectedValue = RadioButtonListAlamatTinggal.SelectedValue;
        string TTL_KTP;
        string tgl_lahir = TxtTglLahir.Text;
        if (selectedValue == "Berbeda dengan KTP") {
            TTL_KTP = TextAreaAamatKTP.InnerText;
        }
        else {
            TTL_KTP = TextAreaAlamatKTP.InnerText;
        }
        Response.Write("<script language=javascript>alert('" + nama + "--"+tempatlahir+"--"+ TTL_KTP + "--"+ tgl_lahir + "');</script>");
    }
}