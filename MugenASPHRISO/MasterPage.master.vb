Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Public MyRecReadA As OleDbDataReader
    Public Event TxtUser_TextChanged As EventHandler

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim LblUserName = Session("MainContent")
        username.Text = Session("MainContent")
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        If LblUserName = "HRD112" Then
            dataKaryawan.Visible = False
            penilaianKaryawan.Visible = False
            batas1.Visible = False
            hakAkses.Visible = True
        End If

        If LblUserName = "TINI" Then
            hakAkses.Visible = True
        End If
        'Dim GetData_UserSecurity As Integer
        Dim mSqlCommadstring As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'ISO -- VIEW MENU'"
        Dim mSqlCommadstring1 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM ISO -- VIEW MENU'"
        Dim mSqlCommadstring2 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM PANDUAN MUTU -- VIEW DATA'"
        Dim mSqlCommadstring3 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM SOP -- VIEW MENU'"
        Dim mSqlCommadstring4 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM INSTRUKSI KERJA -- VIEW MENU'"
        Dim mSqlCommadstring5 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'APPROVAL -- VIEW MENU'"
        Dim mSqlCommadstring6 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'PENILAIAN KARYAWAN -- PENILAIAN ATASAN KE BAWAHAN'"
        Dim mSqlCommadstring7 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'IT -- VIEW MENU'"
        Dim mSqlCommadstring8 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM SDR -- VIEW MENU SDR'"
        Dim mSqlCommadstring9 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM LOGIN -- VIEW MENU LOGIN'"
        Dim mSqlCommadstring10 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM BACKUP -- VIEW DATA'"
        Dim mSqlCommadstring11 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM MAINTENANCE -- VIEW DATA'"
        Dim mSqlCommadstring12 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM VERIFIKASI -- VIEW DATA'"
        Dim mSqlCommadstring13 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM BERITA ACARA -- VIEW MENU'"
        Dim mSqlCommadstring14 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'WAREHOUSE -- VIEW MENU'"
        Dim mSqlCommadstring15 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM MINTA UNIT -- VIEW DATA'"
        Dim mSqlCommadstring16 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM FPTK -- VIEW MENU'"
        Dim mSqlCommadstring17 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'PENILAIAN KARYAWAN -- KONFIGURASI'"
        Dim mSqlCommadstring18 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'PENILAIAN KARYAWAN -- PENILAIAN BAWAHAN KE ATASAN (SPV)'"
        Dim mSqlCommadstring19 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'PENILAIAN KARYAWAN -- PENILAIAN BAWAHAN KE ATASAN (LEADER)'"
        Dim mSqlCommadstring20 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'PENILAIAN KARYAWAN -- VIEW REPORT'"
        Dim mSqlCommadstring21 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'DATABASE KARYAWAN -- VIEW DATA'"

        Dim MyRecReadA As OleDbDataReader

        cnn = New OleDbConnection(strconn)

        'GetData_UserSecurity = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                iso.Visible = True
            Else
                iso.visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                sasaran.Visible = True
            Else
                sasaran.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring2, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                panduanmutu.Visible = True
            Else
                panduanmutu.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring3, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                sop.Visible = True
            Else
                sop.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring4, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                instruksi.Visible = True
            Else
                instruksi.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring5, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                approval.Visible = True
            Else
                approval.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring6, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                penilaianBawahan.Visible = True
            Else
                penilaianBawahan.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring7, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                IT.Visible = True
            Else
                IT.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring8, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                sdr.Visible = True
            Else
                sdr.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring9, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                login.Visible = True
            Else
                login.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring10, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                backup.Visible = True
            Else
                backup.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring11, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                maintenance.Visible = True
            Else
                maintenance.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring12, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                verifikasi.Visible = True
            Else
                verifikasi.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring13, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                beritaacara.Visible = True
            Else
                beritaacara.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring14, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                Warehouse.Visible = True
            Else
                Warehouse.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring15, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                mintaunit.Visible = True
            Else
                mintaunit.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring16, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                formFPTK.Visible = True
                batas3.Visible = True
            Else
                formFPTK.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring17, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                itempenilaian.Visible = True
                normapenilaian.Visible = True
            Else
                itempenilaian.Visible = False
                normapenilaian.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring18, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                penilaianSPV.Visible = True
            Else
                penilaianSPV.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring19, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                penilaianLeader.Visible = True
            Else
                penilaianLeader.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring20, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                reportpenilaian.Visible = True
                batas2.Visible = True
            Else
                reportpenilaian.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring21, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                databaseKaryawan.Visible = True
                databaseJabatan.Visible = True
                konfigurasiAkun.Visible = True
                absensikaryawan.Visible = True
            Else
                databaseKaryawan.Visible = False
                databaseJabatan.Visible = False
                konfigurasiAkun.Visible = False
                absensikaryawan.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Sub

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

    Function GetData_UserSecurity(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_UserSecurity = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteReader()
            GetData_UserSecurity = IIf(MyRecReadA.HasRows = True, 1, 0)
            If MyRecReadA.HasRows = 1 Then
                backup.Visible = True
                login.Visible = True
                sdr.Visible = True
            Else
                backup.Visible = False
                login.Visible = False
                sdr.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
        End Try
    End Function
End Class

