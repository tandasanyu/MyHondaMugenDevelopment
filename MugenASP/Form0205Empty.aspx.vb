Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Imports System.Web.Security
'1.  Cari
'2.  Tambah
'3.  Forman
'4.  Spv Spare Parts
'5.  Head Service 
'6.  Spv Sales
'7.  Sales Manager
'8.  Admin Head
'9.  Head Accounting
'10. Spv Gudang
'11. Head IT
'12. Direktur

Partial Class Form03IjinKerja
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If

        Dim x As String
        x = DirectCast(Session("MainContent"), String)
        LblUserName.Text = x.ToString
        If GetData_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(User_access)=RTRIM(AKSES_KODE) AND User_nama= '" & LblUserName.Text & "' AND User_tipe='WA' AND AKSES_MENU='0101'") = 1 Then
            MultiView1a.ActiveViewIndex = 0
        Else
            lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
        End If
        Calendar1.Visible = False
        Calendar2.Visible = False
        CalenderMasuk.Visible = False
    End Sub

    Protected Sub ButtonMasuk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonMasuk.Click
        Calendar1.Visible = False
    End Sub

    Protected Sub Masuk_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CalenderMasuk.SelectionChanged
        TxtTglMasuk.Text = [CalenderMasuk].SelectedDate.ToString
    End Sub


    Protected Sub ButtonCalendar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCalendar1.Click
        Calendar1.Visible = False
    End Sub

    Protected Sub DateStart_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        TxtTglMulai.Text = [Calendar1].SelectedDate.ToString
    End Sub

    Protected Sub ButtonCalendar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCalendar2.Click
        Calendar2.Visible = False
    End Sub

    Protected Sub DateEnd_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar2.SelectionChanged
        TxtTglAkhir.Text = [Calendar2].SelectedDate.ToString
    End Sub


    Function GetData_Nomor() As String
        GetData_Nomor = GetData_SearchNomor()
        If GetData_Nomor <> "" Then
            If GetData_Nomor = "NO FOUND" Then
                GetData_Nomor = GetData_StartNomor()
            End If
        End If
        If GetData_Nomor = "" Then
            MsgBox("DATA TIDAK BERHASIL DISIMPAN")
        End If
    End Function
    Function GetData_SearchNomor() As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String

        GetData_SearchNomor = ""
        mSqlCommadstring = "SELECT KERJA_NOMOR FROM ABSEN_KERJA WHERE MONTH(KERJA_TGLMOHHON)=MONTH(GETDATE()) AND YEAR(KERJA_TGLMOHHON)=YEAR(GETDATE()) ORDER BY KERJA_NOMOR DESC"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            mFind = IIf(MyRecReadA.HasRows = True, 1, 0)
            If mFind = 0 Then GetData_SearchNomor = "NO FOUND"
            While MyRecReadA.Read()
                GetData_SearchNomor = Val(nSr(MyRecReadA("KERJA_NOMOR"))) + 1
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Function GetData_StartNomor() As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String

        GetData_StartNomor = ""
        mSqlCommadstring = "SELECT GETDATE() as mCurrDate"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            mFind = IIf(MyRecReadA.HasRows = True, 1, 0)
            If mFind = 0 Then GetData_StartNomor = "NO FOUND"
            While MyRecReadA.Read()
                GetData_StartNomor = Format(Year(MyRecReadA("mCurrDate")), "0#") & _
                                     Format(Month(MyRecReadA("mCurrDate")), "0#") & _
                                     "001"
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Function UpdateData_Tabel(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        UpdateData_Tabel = 0
        cnn = New OleDbConnection(strconn)
        MsgBox(mSqlCommadstring)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_Tabel = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Function GetData_Data(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Data = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Data = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                TxtUsername.Text = nSr(MyRecReadA("KERJA_USER"))
                LblTglSPK.Text = nSr(MyRecReadA("KERJA_TGLMOHHON"))
                DropDownDept.Text = nSr(MyRecReadA("KERJA_DEPT"))
                TxtTglMasuk.Text = nSr(MyRecReadA("KERJA_TGLMASUK"))
                TxtJmlharicuti.Text = nSr(MyRecReadA("KERJA_SISACUTI"))
                DropDownIjin.Text = nSr(MyRecReadA("KERJA_JENIS"))

                TxtTglMulai.Text = nSr(MyRecReadA("KERJA_TGLIJIN1"))
                TxtTglAkhir.Text = nSr(MyRecReadA("KERJA_TGLIJIN2"))
                TxtCatatann.Text = nSr(MyRecReadA("KERJA_CATATAN"))

                lblAkses.Text = nSr(MyRecReadA("KERJA_USERSETUJUA"))
                lblAkses.Text = nSr(MyRecReadA("KERJA_USERSETUJUATGL"))
                lblAkses.Text = nSr(MyRecReadA("KERJA_USERSETUJUACATATAN"))

                DropDownStatus1.Text = nSr(MyRecReadA("KERJA_USERSETUJUASTATUS"))
                lblAkses.Text = nSr(MyRecReadA("KERJA_USERSETUJUB"))
                lblAkses.Text = nSr(MyRecReadA("KERJA_USERSETUJUBTGL"))
                lblAkses.Text = nSr(MyRecReadA("KERJA_USERSETUJUBCATATAN"))
                DropDownStatus2.Text = nSr(MyRecReadA("KERJA_USERSETUJUBSTATUS"))

                lblNomor.Text = nSr(MyRecReadA("KERJA_NOMOR"))
                lblAkses.Text = nSr(MyRecReadA("KERJA_POSISI"))

            End While
            MyRecReadA.Close()
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
                lblAkses.Text = nSr(MyRecReadA("AKSES_DATA"))
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function

    Protected Sub BtnSetuju_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSetuju.Click
        If lblNomor.Text = "" Then
            lblNomor.Text = GetData_Nomor()
            'If lblNomor.Text <> "" Then
            'Dim mTxtSql As String
            'mTxtSql = "INSERT INTO ABSEN_KERJA " & _
            '         "(KERJA_USER, KERJA_DEPT, KERJA_TGLMOHHON, KERJA_TGLIJIN1, KERJA_TGLIJIN2, KERJA_CATATAN, KERJA_USERSETUJUA," & _
            '         " KERJA_USERSETUJUATGL, KERJA_USERSETUJUACATATAN, KERJA_USERSETUJUASTATUS, KERJA_USERSETUJUB, KERJA_USERSETUJUBTGL," & _
            '         " KERJA_USERSETUJUBCATATAN, KERJA_USERSETUJUBSTATUS, KERJA_SISACUTI, KERJA_TGLMASUK, KERJA_JENIS, KERJA_NOMOR,KERJA_POSISI) VALUE " & _
            '         "('" & "KERJA_USER, KERJA_DEPT" & "','" & "KERJA_TGLMOHHON" & "','" & "KERJA_TGLIJIN1" & "','" & "KERJA_TGLIJIN2" & "','" & "KERJA_CATATAN" & "','" & "KERJA_USERSETUJUA" & "'," & _
            '         " '" & "KERJA_USERSETUJUATGL" & "','" & "KERJA_USERSETUJUACATATAN" & "','" & "KERJA_USERSETUJUASTATUS" & "','" & "KERJA_USERSETUJUB" & "','" & "KERJA_USERSETUJUBTGL," & "'," & _
            '         " '" & "KERJA_USERSETUJUBCATATAN" & "','" & "KERJA_USERSETUJUBSTATUS" & "','" & "KERJA_SISACUTI" & "','" & "KERJA_TGLMASUK" & "','" & "KERJA_JENIS" & "','" & "KERJA_NOMOR" & "','" & "KERJA_POSISI" & "')"
            'C() 'all UpdateData_Tabel(mTxtSql)
            'End If
        End If
    End Sub

    Protected Sub BtnTolak_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTolak.Click
        Dim mTxtSql As String
        mTxtSql = "UPDATE ABSEN_KERJA SET KERJA_USERSETUJUA='', " & _
                  "KERJA_USERSETUJUATGL='', KERJA_USERSETUJUACATATAN='', KERJA_USERSETUJUASTATUS='', " & _
                  "WHERE KERJA_NOMOR=''"
        mTxtSql = "UPDATE ABSEN_KERJA SET KERJA_USERSETUJUB='', KERJA_USERSETUJUBTGL='', " & _
                  "KERJA_USERSETUJUBCATATAN='', KERJA_USERSETUJUBSTATUS='' " & _
                  "WHERE KERJA_NOMOR=''"
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        MultiView1a.ActiveViewIndex = 1
        If Mid(lblAkses.Text, 1, 1) = "1" Or Mid(lblAkses.Text, 2, 1) = "1" Then
            MultiView1a.ActiveViewIndex = 1
        Else
            MsgBox("TIDAK DIPERBOLEHKAN MENGAJUKAN PERMOHONAN ")
        End If

    End Sub

End Class
