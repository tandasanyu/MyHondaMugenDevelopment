Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Partial Class editPassword

    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("username") = Nothing Then
            Response.Redirect("default.aspx")
        Else
            lblUsername.Text = CType(Session.Item("username"), String)
        End If
        ' If CType(Session.Item("username"), String) = "1" Then



        'End If
    End Sub



    Protected Sub simpan_Click(sender As Object, e As EventArgs)
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim GetData_Checklist As Integer
        Dim user As String = CType(Session.Item("username"), String)
        Dim passLama As String = txtPassLama.Text
        Dim passBaru As String = txtPassBaru.Text
        Dim passBaru2 As String = txtPassBaru2.Text
        If passBaru <> passBaru2 Then
            lblPassBaru2.Text = "Pengulangan password baru yang anda masukkan berbeda."
        Else
            Dim mSqlCommadstring As String = "Select * From PASSWB_USER where USER_Name='" + User + "' AND USER_Password='" + passLama + "' AND USER_CdLevel='MAA'"
            Dim MyRecReadA As OleDbDataReader
            cnn = New OleDbConnection(strconn)
            GetData_Checklist = 0

            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_Checklist = IIf(MyRecReadA.HasRows = True, 1, 0)
                If MyRecReadA.HasRows = True Then
					passBaru = passBaru.ToUpper()
                    Call ubahPassword_Tabel("UPDATE PASSWB_USER set USER_Password='" + passBaru + "' where USER_Name='" + user + "' AND USER_Password='" + passLama + "' AND USER_CdLevel='MAA'")
                    Response.Write("<script>alert('Password Berhasil Dirubah')</script>")
                    Response.Write("<script>window.location.href='editPassword.aspx';</script>")
                ElseIf MyRecReadA.HasRows = False And passBaru <> passBaru2 Then
                    lblPassLama.Text = "Password lama yang anda masukkan salah"
                Else
                    lblPassLama.Text = "Password lama yang anda masukkan salah"
                End If

                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Function ubahPassword_Tabel(ByVal mSqlCommadstring As String) As Byte

        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        ubahPassword_Tabel = 0
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            ubahPassword_Tabel = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Function
End Class
