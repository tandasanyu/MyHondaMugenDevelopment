
Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub cari_Click(sender As Object, e As EventArgs)
        'Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Session("noRangka1") = noRangka.Text
        Response.Redirect("Default3.aspx", True)
    End Sub
End Class
