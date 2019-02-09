Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb

Imports System.Web.Security
'1 Cari
Partial Class editpassword

    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim x As String
        x = DirectCast(Session("MainContent"), String)
        lblusername.Text = x.ToString


        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If

        Call Msg_err("")
    End Sub

    Protected Sub simpan_Click(sender As Object, e As EventArgs)
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim GetData_Checklist As Integer
        Dim user As String = lblUsername.Text
        Dim passLama As String = txtPassLama.Text
        Dim passBaru As String = txtPassBaru.Text
        Dim passBaru2 As String = txtPassBaru2.Text
        If passBaru <> passBaru2 Then
            lblPassBaru2.Text = "Pengulangan password baru yang anda masukkan berbeda."
        Else
            Dim mSqlCommadstring As String = "Select * From tb_user where username='" + user + "' AND password='" + passLama + "'"
            Dim MyRecReadA As OleDbDataReader
            cnn = New OleDbConnection(strconn)
            GetData_Checklist = 0

            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_Checklist = IIf(MyRecReadA.HasRows = True, 1, 0)
                If MyRecReadA.HasRows = True Then
                    Call ubahPassword_Tabel("UPDATE tb_user set password='" + passBaru + "' where username='" + user + "' AND password='" + passLama + "'")
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
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
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

    Function GetData_UserSecurity(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_UserSecurity = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_UserSecurity = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                lblArea1.Text = nSr(MyRecReadA("JABATAN"))
                If nSr(MyRecReadA("JABATAN")) = "Direksi" Then
                    lblArea1.Text = "D1"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Operational Support Manager" Then
                    lblArea1.Text = "D2"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SM Ps. Minggu" Then
                    lblArea1.Text = "D3"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SM Puri" Then
                    lblArea1.Text = "D4"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Service Manager Ps. Minggu" Then
                    lblArea1.Text = "D5"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Service Manager Puri" Then
                    lblArea1.Text = "D6"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Internal Auditor" Then
                    lblArea1.Text = "D7"
                ElseIf nSr(MyRecReadA("JABATAN")) = "WH Coordinator" Then
                    lblArea1.Text = "D8"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Ka. Sparepart Ps. Minggu" Then
                    lblArea1.Text = "D9"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Ka. Sparepart Puri" Then
                    lblArea1.Text = "D10"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SPV Sales Ps. Minggu" Then
                    lblArea1.Text = "D11"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SPV Sales Puri" Then
                    lblArea1.Text = "D12"
                ElseIf nSr(MyRecReadA("JABATAN")) = "QMR" Then
                    lblArea1.Text = "D13"
                ElseIf nSr(MyRecReadA("JABATAN")) = "ADH Ps. Minggu" Then
                    lblArea1.Text = "D14"
                ElseIf nSr(MyRecReadA("JABATAN")) = "ADH Puri" Then
                    lblArea1.Text = "D15"
                ElseIf nSr(MyRecReadA("JABATAN")) = "CC SPV" Then
                    lblArea1.Text = "D16"
                ElseIf nSr(MyRecReadA("JABATAN")) = "CC Puri" Then
                    lblArea1.Text = "D17"
                ElseIf nSr(MyRecReadA("JABATAN")) = "HRD & GA Head" Then
                    lblArea1.Text = "D18"
                ElseIf nSr(MyRecReadA("JABATAN")) = "GA Puri" Then
                    lblArea1.Text = "D19"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SPV HRD" Then
                    lblArea1.Text = "D20"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SPV GA" Then
                    lblArea1.Text = "D21"
                ElseIf nSr(MyRecReadA("JABATAN")) = "IT Head" Then
                    lblArea1.Text = "D22"
                ElseIf nSr(MyRecReadA("JABATAN")) = "IT Puri" Then
                    lblArea1.Text = "D23"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Purchasing" Then
                    lblArea1.Text = "D24"
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
        End Try
    End Function

    Sub Msg_err(ByVal mTest As String)
        lblMsgBox.Text = mTest
        If mTest = "" Then
            MultiViewError.ActiveViewIndex = 0
        Else
            MultiViewError.ActiveViewIndex = 0
        End If

    End Sub

    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function


    Function UserSecurity(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        UserSecurity = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                UserSecurity = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & Chr(13) & mSqlCommadstring)
        End Try
    End Function

    Function UpdateData_Server(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        UpdateData_Server = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_Server = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception

        End Try
    End Function
End Class
