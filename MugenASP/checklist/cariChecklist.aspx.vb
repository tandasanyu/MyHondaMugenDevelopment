Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Partial Class cariChecklist
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("username") = Nothing Then
            Response.Redirect("default.aspx")
        Else
            'tglMasuk.Text = Format(Now, "yyyy-MM-dd")
            [Calendar1].Visible = False
        End If


    End Sub


    Protected Sub cari_Click(sender As Object, e As EventArgs) Handles cari.Click
        'Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Session("nopol1") = nopol.Text
        Session("tglMasuk1") = tglMasuk.Text
        Response.Redirect("viewChecklist.aspx", True)
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        [Calendar1].Visible = True
    End Sub



    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar1].SelectionChanged, Calendar1.SelectionChanged
        tglMasuk.Text = [Calendar1].SelectedDate.ToString("yyyy-MM-dd")
        [Calendar1].Visible = False
    End Sub



End Class
