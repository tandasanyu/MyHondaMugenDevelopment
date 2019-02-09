
Partial Class Default3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        noRangka.Text = Request.QueryString("noRangka1")
        'Request.QueryString["noRangka1"]
        'CType(Session.Item("noRangka1"), String)
    End Sub

End Class
