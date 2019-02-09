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

'Kode 0101
'1 Hak Lihat Hanya Diri Sendiri
'2 Hak Lihat Semuanya
'3 Hak Menambah/Menghapus/Mengedit Data Karyawan
'4 Hak Menambah/Menghapus/Mengedit KPI


Partial Class HRDITEMPENILAIANKARYAWAN
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader
    Dim sFileDir As String = "E:\"
    Dim lMaxFileSize As Long = 4096

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
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
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- KONFIGURASI'") = 1 Then
                MultiViewNilaiStandard.ActiveViewIndex = 0
                LVNilaiStandard.DataBind()
            Else
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If


    End Sub

    '============Start Hal Utama

    Sub HakDataKeryawan()
        '=================================================

        BtnStandard.Visible = False
        BtnStandardSave.Visible = False : BtnStandardDel.Visible = False




    End Sub



    '============end Pilihan Halaman

    Sub DeaktifTabel1()


        MultiViewNilaiStandard.ActiveViewIndex = -1
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1



        '=============

    End Sub

    Sub DeaktifRaport()


        MultiViewNilaiStandard.ActiveViewIndex = -1
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1


        '=============

    End Sub


    Protected Sub BtnStandard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandard.Click
        MultiViewNilaiStandardEntry.ActiveViewIndex = 0
        MultiViewNilaiStandard.ActiveViewIndex = -1
        Call clearTxtStandardJudul()
    End Sub

    Function InsertDataNilaiSTANDARD() As String
        InsertDataNilaiSTANDARD = "INSERT INTO DATA_KPIT (KPIT_TIPE) VALUES ('" & TxtStandardKode.Text & "')"
    End Function

    Function EditDataNilaiSTANDARD() As String
        'KPID_TYPEA=1 Percobaan 2 Karyawan
        EditDataNilaiSTANDARD = "UPDATE DATA_KPIT SET " & _
                                  "KPIT_ITEM='" & TxtStandardJudul.Text & "'," & _
                                  "KPIT_BOBOT='" & TxtStandardKet.Text & "'," & _
                                  "KPIT_TARGET='" & TxtStandardTarget.Text & "'," & _
                                  "KPIT_HITUNG='" & TxtStandardHitung.Text & "'," & _
                                  "KPIT_GROUP='" & TxtStandardGroup.Text & "' " & _
                                  "WHERE KPIT_TIPE='" & TxtStandardKode.Text & "'"
    End Function

    Sub clearTxtStandardJudul()
        TxtStandardKode.Text = ""
        TxtStandardJudul.Text = ""
        TxtStandardKet.Text = ""
        TxtStandardTarget.Text = ""
        TxtStandardHitung.Text = ""
        TxtStandardGroup.Text = ""
    End Sub

    Protected Sub LVNilaiStandard_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVNilaiStandard.SelectedIndexChanged
        TxtStandardKode.Text = (LVNilaiStandard.DataKeys(LVNilaiStandard.SelectedIndex).Value.ToString)
        Call GetData_MASTERSTANDARD("SELECT * FROM DATA_KPIT  WHERE  KPIT_TIPE='" & TxtStandardKode.Text & "'")
        MultiViewNilaiStandardEntry.ActiveViewIndex = 0
        MultiViewNilaiStandard.ActiveViewIndex = -1

    End Sub
    Protected Sub BtnStandardSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardSave.Click
        If GetFindRecord_Server("SELECT * FROM DATA_KPIT  WHERE CONVERT(VARCHAR, KPIT_TIPE)='" & TxtStandardKode.Text & "'") <> 1 Then
            If UpdateData_Server(InsertDataNilaiSTANDARD, "Std") = 1 Then

            End If
        End If
        Call UpdateData_Server(EditDataNilaiSTANDARD, "Std")
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1 : LVNilaiStandard.DataBind()
        MultiViewNilaiStandard.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnStandardDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardDel.Click
        Dim mSqlCommand As String = "DELETE FROM DATA_KPIT  WHERE  KPIT_TIPE='" & TxtStandardKode.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Std")
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1 : LVNilaiStandard.DataBind()
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






    Function GetData_MASTERSTANDARD(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MASTERSTANDARD = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtStandardKode.Text = nSr(MyRecReadA("KPIT_TIPE"))
                TxtStandardGroup.Text = nSr(MyRecReadA("KPIT_GROUP"))
                TxtStandardJudul.Text = nSr(MyRecReadA("KPIT_ITEM"))
                TxtStandardKet.Text = nSr(MyRecReadA("KPIT_BOBOT"))
                TxtStandardTarget.Text = nSr(MyRecReadA("KPIT_TARGET"))
                TxtStandardHitung.Text = nSr(MyRecReadA("KPIT_HITUNG"))


            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetFindRecord_Server(ByVal mSqlCommadstring As String) As Integer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
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


    Function DtFrSQL(ByRef mNilai As Object) As String
        On Error GoTo ErrHand
        DtFrSQL = "NULL"
        If IsDate(mNilai) Then
            DtFrSQL = "'" & Format(CDate(mNilai), "yyyy-MM-dd HH:MM:ss") & "'"
        End If
        'MsgBox(DtFrSQL)
ErrHand:
    End Function

    Function nLg(ByRef nilai As Object) As Double
        On Error GoTo ErrHand
        nLg = 0
        nilai = Replace(nilai, ",", "")
        If IsNumeric(nilai) Then nLg = Val(nilai)
ErrHand:
    End Function

    Function fLg(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        fLg = "0"
        nilai = Replace(nilai, ",", "")
        If IsNumeric(nilai) Then fLg = Format(Val(nilai), "###,###,###,###,##0") '10
ErrHand:
    End Function

    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function
    Function TxtPetik(ByRef MyText As String) As String
        Dim mPosStart As Byte
        TxtPetik = IIf(IsDBNull(MyText), "", Trim(MyText))
        mPosStart = 1
        While InStr(mPosStart, TxtPetik, "'") <> 0
            mPosStart = InStr(mPosStart, TxtPetik, "'")
            TxtPetik = Mid(TxtPetik, 1, mPosStart) & "'" & "" & Mid(TxtPetik, mPosStart + 1, Len(TxtPetik) - mPosStart)
            mPosStart = mPosStart + 2
        End While
    End Function




    '==============================================================================



    Function UpdateData_Server(ByVal mSqlCommadstring As String, ByVal mPos As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand


        LblErrorSaveStandard.Text = ""
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
            Call ErrorIsi(mPos, ex.Message)
        End Try
    End Function


    Sub ErrorIsi(ByVal Kode As String, ByVal Errormsg As String)

        Kode = "Std"
        LblErrorSaveStandard.Text = Errormsg

    End Sub


    Protected Sub BtnStandardBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardBack.Click
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        LVNilaiStandard.DataBind()
    End Sub





End Class
