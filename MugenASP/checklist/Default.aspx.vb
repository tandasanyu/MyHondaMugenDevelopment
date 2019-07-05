Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Partial Class _Default
    Inherits System.Web.UI.Page
 

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("username") = ""
    End Sub
  

    Protected Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        Dim user, pass As String
        'ngelempar data nopol dan tglMasuk ke File tampilan viewChecklist
        user = username.Text
        pass = password.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        'lemparan data nopol dan tanggal masuk dari file cariChecklist

        Dim GetData_user As Integer
        Dim mSqlCommadstring As String = "Select * From PASSWB_USER where USER_Name='" + user + "' AND USER_Password='" + pass + "' AND USER_CdLevel='MAA'"
        Dim MyRecReadA As OleDbDataReader


        cnn = New OleDbConnection(strconn)
        GetData_user = 0

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                Session("username") = user
                Server.Transfer("pilihJenisMobil.aspx", True)
            Else
                peringatan.Text = "Username / Password Salah!"
            End If

            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            peringatan.Text = "Username / Password Salah!"
        End Try
    End Sub
End Class