
Partial Class pilihJenisMobil
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("username") = Nothing Then
            Response.Redirect("default.aspx")
        End If
    End Sub
End Class
