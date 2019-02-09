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
            Call GetData_UserHead(" Select KPIH_APPVHEAD from TRXN_KPIH where KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TahunPenilaian.Text & "'")
            Call GetData_UserHead2(" Select NAMAKARYAWAN from TB_USER where username='" & TxtHead2.Text & "'")


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
                TahunPenilaian.Text = (DateTime.Now.Year.ToString() - 1)
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
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

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
                TxtHead2.Text = nSr(MyRecReadA("KPIH_APPVHEAD"))

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
                TxtHead.Text = nSr(MyRecReadA("NAMAKARYAWAN"))
                lblAtasan.Text = nSr(MyRecReadA("NAMAKARYAWAN"))
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
        Dim myinsert = "insert INTO TRXN_KPIN (KPIN_NIK,KPIN_TAHUN,KPIN_USER,KPIN_ATASAN,KPIN_KODE,KPIN_NILAI,KPIN_TGL,KPIN_NOTE,KPIN_GROUP) VALUES " & _
                       "('" & TxtStaffNIK.Text & "','" & TahunPenilaian.Text & "','" & mKPIN_USER & "','" & mKPIN_ATASAN & "','" & mKPIN_KODE & "','" & mKPIN_NILAI & "','" & Now() & "','" & mKPIN_NOTE & "','1')"
        Call UpdateData_Server(myinsert)
    End Sub

    Sub SaveTombol()
        Call UpdateData_Server("DELETE FROM TRXN_KPIN WHERE KPIN_USER='" & TxtStaffNama.Text & "' AND KPIN_TAHUN like '%" & TahunPenilaian.Text & "%' AND KPIN_GROUP = '1'")
        If RadioButton01.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 1 Wajib Diisi!')</script>")
        ElseIf RadioButton02.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 2 Wajib Diisi!')</script>")
        ElseIf RadioButton03.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 3 Wajib Diisi!')</script>")
        ElseIf RadioButton04.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 4 Wajib Diisi!')</script>")
        ElseIf RadioButton05.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 5 Wajib Diisi!')</script>")
        ElseIf RadioButton06.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 6 Wajib Diisi!')</script>")
        ElseIf RadioButton07.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 7 Wajib Diisi!')</script>")
        ElseIf RadioButton08.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 8 Wajib Diisi!')</script>")
        ElseIf RadioButton09.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 9 Wajib Diisi!')</script>")
        ElseIf RadioButton10.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 10 Wajib Diisi!')</script>")
        ElseIf RadioButton11.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 11 Wajib Diisi!')</script>")
        ElseIf RadioButton12.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 12 Wajib Diisi!')</script>")
        ElseIf RadioButton13.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 13 Wajib Diisi!')</script>")
        ElseIf RadioButton14.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 14 Wajib Diisi!')</script>")
        ElseIf RadioButton15.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 15 Wajib Diisi!')</script>")
        ElseIf RadioButton16.Text = "" Then
            Response.Write("<script>alert('Pertanyaan No 16 Wajib Diisi!')</script>")
        ElseIf TxtKomentar.Text = "" Then
            Response.Write("<script>alert('Komentar Wajib Diisi!')</script>")
        Else
            Call insertabel("001", TxtStaffNama.Text, lblAtasan.Text, RadioButton01.Text, "", "")
            Call insertabel("002", TxtStaffNama.Text, lblAtasan.Text, RadioButton02.Text, "", "")
            Call insertabel("003", TxtStaffNama.Text, lblAtasan.Text, RadioButton03.Text, "", "")
            Call insertabel("004", TxtStaffNama.Text, lblAtasan.Text, RadioButton04.Text, "", "")
            Call insertabel("005", TxtStaffNama.Text, lblAtasan.Text, RadioButton05.Text, "", "")
            Call insertabel("006", TxtStaffNama.Text, lblAtasan.Text, RadioButton06.Text, "", "")
            Call insertabel("007", TxtStaffNama.Text, lblAtasan.Text, RadioButton07.Text, "", "")
            Call insertabel("008", TxtStaffNama.Text, lblAtasan.Text, RadioButton08.Text, "", "")
            Call insertabel("009", TxtStaffNama.Text, lblAtasan.Text, RadioButton09.Text, "", "")
            Call insertabel("010", TxtStaffNama.Text, lblAtasan.Text, RadioButton10.Text, "", "")
            Call insertabel("011", TxtStaffNama.Text, lblAtasan.Text, RadioButton11.Text, "", "")
            Call insertabel("012", TxtStaffNama.Text, lblAtasan.Text, RadioButton12.Text, "", "")
            Call insertabel("013", TxtStaffNama.Text, lblAtasan.Text, RadioButton13.Text, "", "")
            Call insertabel("014", TxtStaffNama.Text, lblAtasan.Text, RadioButton14.Text, "", "")
            Call insertabel("015", TxtStaffNama.Text, lblAtasan.Text, RadioButton15.Text, "", "")
            Call insertabel("016", TxtStaffNama.Text, lblAtasan.Text, RadioButton16.Text, "", "")
            Call insertabel("017", TxtStaffNama.Text, lblAtasan.Text, "", "", TxtKomentar.Text)
            Response.Write("<script>alert('Anda telah sukses melakukan penilaian Atasan!')</script>")
            Response.Write("<script>window.location.href='HRDPENILAIANATASANLEADER.aspx';</script>")
        End If
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
