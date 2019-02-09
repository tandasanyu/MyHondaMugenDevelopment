Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Net.Mail
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization

Partial Class HRDPENILAIANATASANLEADER
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If

        If LblUserName.Text = "" Then
            Dim x As String
            Dim mFound As Byte = 0
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = x.ToString

            Call GetData_STAFF2("SELECT * FROM TB_USER WHERE username='" & LblUserName.Text & "'")
            Call GetData_STAFF("SELECT * FROM DATA_STAFF WHERE STAFF_NIK='" & TxtStaffNIK.Text & "'")
            Call GetData_UserHead(" Select divisi.kddivisi, divisi.headdivisi, tb_user.namakaryawan, tb_user.kdkaryawan from divisi, tb_user WHERE namakaryawan = '" & TxtStaffNama.Text & "' And divisi.kddivisi collate SQL_Latin1_General_CP1_CI_AS  = tb_user.kddivisi2 collate SQL_Latin1_General_CP1_CI_AS")
            Call GetData_UserHead2(" Select divisi.kddivisi, divisi.headdivisi, tb_user.namakaryawan, tb_user.kdkaryawan from divisi, tb_user WHERE namakaryawan = '" & TxtStaffNama.Text & "' And divisi.kddivisi collate SQL_Latin1_General_CP1_CI_AS  = tb_user.kddivisi3 collate SQL_Latin1_General_CP1_CI_AS")


            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'PENILAIAN KARYAWAN -- PENILAIAN BAWAHAN KE ATASAN (LEADER)'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0
                MultiViewNilaiStandardEntry.ActiveViewIndex = 0
            Else
                MultiViewAkses.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub

    Function GetData_STAFF2(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_STAFF2 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtStaffNIK.Text = nSr(MyRecReadA("KDKARYAWAN"))
                TxtNama.Text = nSr(MyRecReadA("NAMAKARYAWAN"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function
    Function GetData_STAFF(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_STAFF = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtStaffNIK.Text = nSr(MyRecReadA("STAFF_NIK"))
                TahunPenilaian.Text = DateTime.Now.Year.ToString()
                TxtStaffNIK.Enabled = False
                TxtStaffNIK.Enabled = False
                TxtStaffNama.Text = nSr(MyRecReadA("STAFF_NAMA"))
                TxtStatusKerjaJabatan.Text = nSr(MyRecReadA("STAFF_STATUSKERJAJABATAN"))
                TxtStatusKerjaTempat.Text = nSr(MyRecReadA("STAFF_STATUSKERJALOKASI")) + " / " + nSr(MyRecReadA("STAFF_STATUSKERJADEPT"))

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function

    Function GetData_UserHead(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_UserHead = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_UserHead = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                TxtHead.Text = nSr(MyRecReadA("HEADDIVISI"))
                lblAtasan.Text = nSr(MyRecReadA("HEADDIVISI"))
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
        End Try
    End Function

    Function GetData_UserHead2(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_UserHead2 = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_UserHead2 = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                TxtHead2.Text = nSr(MyRecReadA("HEADDIVISI"))

            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
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
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
        End Try
    End Function
    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function

    Function DtFrSQL(ByRef mNilai As Object) As String
        On Error GoTo ErrHand
        DtFrSQL = "NULL"
        If IsDate(mNilai) Then
            DtFrSQL = "'" & Format(CDate(mNilai), "yyyy-MM-dd HH:MM:ss") & "'"
        End If
        'MsgBox(DtFrSQL)
ErrHand:
    End Function

    Function GetFindRecord_Server(ByVal mSqlCommadstring As String) As Integer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetFindRecord_Server = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                GetFindRecord_Server = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function

    Protected Sub BtnStandardSave_Click(sender As Object, e As EventArgs) Handles BtnStandardSave.Click
        Call SaveTombol()
    End Sub

    Sub insertabel(ByVal mKPIN_KODE As String, ByVal mKPIN_USER As String, ByVal mKPIN_ATASAN As String, ByVal mKPIN_NILAI As String, ByVal mKPIN_TGL As String, ByVal mKPIN_NOTE As String)
        Dim myinsert = "insert INTO TRXN_KPIN (KPIN_USER,KPIN_ATASAN,KPIN_KODE,KPIN_NILAI,KPIN_TGL,KPIN_NOTE,KPIN_GROUP) VALUES " & _
                       "('" & mKPIN_USER & "','" & mKPIN_ATASAN & "','" & mKPIN_KODE & "','" & mKPIN_NILAI & "','" & Now() & "','" & mKPIN_NOTE & "','1')"
        Call UpdateData_Server(myinsert)
    End Sub

    Sub SaveTombol()
        Call UpdateData_Server("DELETE FROM TRXN_KPIN WHERE KPIN_USER='" & TxtStaffNama.Text & "' AND KPIN_TGL like '%" & TahunPenilaian.Text & "%' AND KPIN_GROUP = '1'")
        If RadioButton01.Text = "" Then
            LabelError.Text = "Pertanyaan No 1 Wajib Diisi"
        Else
            Call insertabel("001", TxtStaffNama.Text, lblAtasan.Text, RadioButton01.Text, "", "")
        End If

        If RadioButton02.Text = "" Then
            LabelError.Text = "Pertanyaan No 2 Wajib Diisi"
        Else
            Call insertabel("002", TxtStaffNama.Text, lblAtasan.Text, RadioButton02.Text, "", "")
        End If

        If RadioButton03.Text = "" Then
            LabelError.Text = "Pertanyaan No 3 Wajib Diisi"
        Else
            Call insertabel("003", TxtStaffNama.Text, lblAtasan.Text, RadioButton03.Text, "", "")
        End If

        If RadioButton04.Text = "" Then
            LabelError.Text = "Pertanyaan No 4 Wajib Diisi"
        Else
            Call insertabel("004", TxtStaffNama.Text, lblAtasan.Text, RadioButton04.Text, "", "")
        End If

        If RadioButton05.Text = "" Then
            LabelError.Text = "Pertanyaan No 5 Wajib Diisi"
        Else
            Call insertabel("005", TxtStaffNama.Text, lblAtasan.Text, RadioButton05.Text, "", "")
        End If

        If RadioButton06.Text = "" Then
            LabelError.Text = "Pertanyaan No 6 Wajib Diisi"
        Else
            Call insertabel("006", TxtStaffNama.Text, lblAtasan.Text, RadioButton06.Text, "", "")
        End If

        If RadioButton07.Text = "" Then
            LabelError.Text = "Pertanyaan No 7 Wajib Diisi"
        Else
            Call insertabel("007", TxtStaffNama.Text, lblAtasan.Text, RadioButton07.Text, "", "")
        End If

        If RadioButton08.Text = "" Then
            LabelError.Text = "Pertanyaan No 8 Wajib Diisi"
        Else
            Call insertabel("008", TxtStaffNama.Text, lblAtasan.Text, RadioButton08.Text, "", "")
        End If

        If RadioButton09.Text = "" Then
            LabelError.Text = "Pertanyaan No 9 Wajib Diisi"
        Else
            Call insertabel("009", TxtStaffNama.Text, lblAtasan.Text, RadioButton09.Text, "", "")
        End If

        If RadioButton10.Text = "" Then
            LabelError.Text = "Pertanyaan No 10 Wajib Diisi"
        Else
            Call insertabel("010", TxtStaffNama.Text, lblAtasan.Text, RadioButton10.Text, "", "")
        End If

        If RadioButton11.Text = "" Then
            LabelError.Text = "Pertanyaan No 11 Wajib Diisi"
        Else
            Call insertabel("011", TxtStaffNama.Text, lblAtasan.Text, RadioButton11.Text, "", "")
        End If

        If RadioButton12.Text = "" Then
            LabelError.Text = "Pertanyaan No 12 Wajib Diisi"
        Else
            Call insertabel("012", TxtStaffNama.Text, lblAtasan.Text, RadioButton12.Text, "", "")
        End If

        If RadioButton13.Text = "" Then
            LabelError.Text = "Pertanyaan No 13 Wajib Diisi"
        Else
            Call insertabel("013", TxtStaffNama.Text, lblAtasan.Text, RadioButton13.Text, "", "")
        End If

        If RadioButton14.Text = "" Then
            LabelError.Text = "Pertanyaan No 14 Wajib Diisi"
        Else
            Call insertabel("014", TxtStaffNama.Text, lblAtasan.Text, RadioButton14.Text, "", "")
        End If

        If RadioButton15.Text = "" Then
            LabelError.Text = "Pertanyaan No 15 Wajib Diisi"
        Else
            Call insertabel("015", TxtStaffNama.Text, lblAtasan.Text, RadioButton15.Text, "", "")
        End If

        If RadioButton16.Text = "" Then
            LabelError.Text = "Pertanyaan No 16 Wajib Diisi"
        Else
            Call insertabel("016", TxtStaffNama.Text, lblAtasan.Text, RadioButton16.Text, "", "")
        End If
        Call insertabel("017", TxtStaffNama.Text, lblAtasan.Text, "", "", TxtKomentar.Text)
        Response.Write("<script>alert('Anda telah sukses melakukan penilaian Atasan!')</script>")
        Response.Write("<script>window.location.href='HRDPENILAIANATASANLEADER.aspx';</script>")
    End Sub

    Function UpdateData_Server(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        LabelError.Text = ""
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
