
Partial Class Home
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim v1 As String = Request.QueryString("Name")
        'v1 = "112VYE"

        If v1 = "FAIZ" Or v1 = "JULIUS" Or v1 = "RONI" Or v1 = "DAVIDH" Or v1 = "HELMI" Or v1 = "IVAN" Or v1 = "SAHRUL" Or v1 = "BAYU" Or v1 = "FENDY" Or v1 = "MEGAH" Then
            FormPengajuanIzin.Visible = False
            LabelPengajuanIzin.Visible = False
            LblUsername_Home.text = v1
        ElseIf v1 = "" Then
            Response.Write("<script>alert('Gagal Mendapatkan UserName Login. Anda Tidak Bisa Akses Menu Apapun')</script>")
            LblUsername_Home.text = ""
        Else
            FormPengajuanIzin.Visible = True
            LabelPengajuanIzin.Visible = True
            LblUsername_Home.text = v1
        End If
    End Sub
    Public v1 As String




    Protected Sub FormPengajuanIzin_Click(sender As Object, e As ImageClickEventArgs) Handles FormPengajuanIzin.Click
    if LblUsername_Home.text="" then 
        Response.Write("<script>alert('Username Kosong / Gagal Mendapatkan Username')</script>")
        Response.Write("<script>window.location.href='http://office.hondamugen.co.id:8084';</script>")
    else 
        Response.Redirect("~/FormIzin.aspx?Name=" + LblUsername_Home.text + "")
    end if 
    End Sub
    Protected Sub ListPengajuanIzin_Click(sender As Object, e As ImageClickEventArgs) Handles ListPengajuanIzin.Click
        if LblUsername_Home.text="" then 
            Response.Write("<script>alert('Username Kosong / Gagal Mendapatkan Username')</script>")
        Response.Write("<script>window.location.href='http://office.hondamugen.co.id:8084';</script>")
    else 
        Response.Redirect("~/ListIzin.aspx?Name=" + LblUsername_Home.text + "")
    end if 
    End Sub
    Protected Sub LihatListIzin_Click(sender As Object, e As ImageClickEventArgs) Handles LihatListIzin.Click
        if LblUsername_Home.text="" then 
        Response.Write("<script>alert('Username Kosong / Gagal Mendapatkan Username')</script>")
        Response.Write("<script>window.location.href='http://office.hondamugen.co.id:8084';</script>")
    else 
        Response.Redirect("~/LihatIzin.aspx")
    end if 
    End Sub
End Class
