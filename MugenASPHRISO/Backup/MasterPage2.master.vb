
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Public Event TxtUser_TextChanged As EventHandler


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.UserAgent.IndexOf("AppleWebKit") > 0 Then
            Request.Browser.Adapters.Clear()
        End If

        Dim mNilai As String
        If Request("myname") IsNot Nothing Then
            mNilai = Server.UrlEncode(Request.QueryString("myname"))
            If mNilai <> "" Then
                LblUser.Text = mNilai
                TxtUser.Text = mNilai
                Dim x As String
                x = LblUser.Text
                Session("MainContent") = x
            End If
        End If
    End Sub

    Protected Sub LoginStatus1_LoggingOut(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles LoginStatus1.LoggingOut
        FormsAuthentication.SignOut()
        Response.Redirect("login.aspx", True)
    End Sub


 
    Protected Sub TxtUser_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUser.TextChanged

    End Sub
End Class

