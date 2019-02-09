Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb

Imports System.Web.Security
'1 Cari
Partial Class Form0100Changepassword

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
        If GetData_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(User_access)=RTRIM(AKSES_KODE) AND User_nama= '" & lblusername.Text & "' AND User_tipe='WA' AND AKSES_MENU='0000'") <> 1 Then
            BtnSetuju.Visible = False
        Else
            lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
        End If
        Call Msg_err("")
    End Sub

    Function GetData_UserSecurity(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetData_UserSecurity = 0

        cnn = New OleDbConnection(strconn)
        lblAkses.Text = ""
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_UserSecurity = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                lblAkses.Text = nSr(MyRecReadA("AKSES_DATA"))
                lblArea1.Text = nSr(MyRecReadA("AKSES_AREA"))
                lblArea2.Text = lblArea1.Text
                If Len(lblArea1.Text) > 3 Then
                    lblArea1.Text = Mid(nSr(MyRecReadA("AKSES_AREA")), 1, 3)
                    lblArea2.Text = Mid(nSr(MyRecReadA("AKSES_AREA")), 4, 3)
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
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


    Protected Sub BtnSetuju_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSetuju.Click
        If UserSecurity("SELECT * FROM DATA_SECURITYU WHERE User_nama= '" & lblusername.Text & "' AND User_Password= '" & Txtkuncilama.Text & "' AND User_tipe='WA'") = 1 Then
            If UserSecurity("UPDATE DATA_SECURITYU SET User_Password = '" & Txtkuncibaru.Text & "' WHERE User_nama= '" & lblusername.Text & "' AND User_Password= '" & Txtkuncilama.Text & "' AND User_access<>'08' AND User_tipe='WA'") = 1 Then
                Call Msg_err("kata kunci lama berhasil dirubah .......")
            End If
        Else
            Call Msg_err("kata kunci lama salah .......")
        End If
    End Sub


    Function UserSecurity(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        UserSecurity = 0

        cnn = New OleDbConnection(strconn)
        Try
            If InStr(mSqlCommadstring, "SELECT") = 0 Then
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                cmd.ExecuteNonQuery()
                UserSecurity = 1
                cmd.Dispose()
                cnn.Close()
            Else
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                UserSecurity = IIf(MyRecReadA.HasRows = True, 1, 0)
                MyRecReadA.Read()
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            End If
        Catch ex As Exception
            Call Msg_err(ex.Message & Chr(13) & mSqlCommadstring)
        End Try
    End Function

End Class
