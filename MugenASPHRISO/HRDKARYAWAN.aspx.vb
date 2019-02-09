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


Partial Class HRDKARYAWAN
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
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = x.ToString
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'DATABASE KARYAWAN -- VIEW DATA'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0 : LvDetailStaff.DataBind()
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'DATABASE KARYAWAN -- KONFIGURASI'") = 1 Then
                    Button40.Visible = True
                Else
                    Button40.Visible = False
                End If
            Else
                MultiViewAkses.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub

    '============Start Hal Utama
    Protected Sub Button40_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button40.Click
        Response.Redirect("HRDFORMKARYAWAN2.aspx", False)
    End Sub
    Protected Sub LvDetailStaff_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailStaff.SelectedIndexChanged
        TxtStaffNIK.Text = (LvDetailStaff.DataKeys(LvDetailStaff.SelectedIndex).Value.ToString) 'jika di comment, maka nik tidak muncul saat di klik detail
        'MsgBox(TxtStaffNIK.Text)
        Call GetData_STAFF("SELECT * FROM DATA_STAFF WHERE STAFF_NIK='" & TxtStaffNIK.Text & "'") ' jika di comment, maka data detail tidak muncul saat di klik detail
        'Call AktifUtammaKlikDetailKaryawan()
    End Sub

    Protected Sub ButtonA1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonA1.Click
        Response.Redirect("HRDFORMKARYAWAN.aspx?no=" & TxtStaffNIK.Text & "", False)
    End Sub

    Protected Sub ButtonA2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonA2.Click
        Response.Redirect("HRDPENILAIANKARYAWAN.aspx?no=" & TxtStaffNIK.Text & "", False)
    End Sub

    Sub ClearDetailStaff()
        TxtStaffNIK.Text = "" : lblStaffNIK.Text = ""
        TxtStaffNIK.Enabled = True
        TxtStaffNama.Text = ""
        TxtStaffLahir.Text = ""
        TxtAgama.Text = ""
        TxtDarah.Text = ""
        TxtJkel.Text = ""
        TxtStaffJalan.Text = ""
        TxtStaffRT.Text = ""
        TxtStaffKel.Text = "" : TxtStaffKota.Text = ""
        TxtStaffKodePos.Text = ""
        TxtStaffEmail.Text = ""
        TxtStaffNoKtp.Text = ""
        TxtStaffSIM.Text = ""
        TxtStaffBPJSKerja.Text = ""
        TxtStaffBPJSSehat.Text = ""
        TxtStaffNPWP.Text = ""
        TxtStaffBCA.Text = ""
        TxtStaffNoHP.Text = ""
        TxtStaffNoTelepon.Text = ""
        TxtStaffNoContact.Text = ""
    End Sub
    Sub ClearStatusStaff()
        TxtStatusKerjaMasuk.Text = ""
        TxtStatusKerjaJabatan.Text = ""
        TxtStatusKerjaDept.Text = ""
        TxtStatusKerjaTempat.Text = ""
        TxtStatusKerjaMagangTglAkhir.Text = ""
        TxtStatusKerjaCobaTglAkhir.Text = ""
        TxtStatusKerjaKontrak1TglAkhir.Text = ""
        TxtStatusKerjaKontrak2TglAkhir.Text = ""
        TxtStatusKerjaAgenTglAkhir.Text = ""
        TxtStatusKerjaTetap.Text = ""
        TxtStatusKerjaKeluar.Text = ""
        TxtStatusKerjaAlasan.Text = ""
        TxtStatusKerjaSubJabatan.Text = ""

        'TdkTrpakai STAFFPK1_NIK,STAFFPK1_NOITEM,STAFFPK1_TARGET,STAFFPK1_PRESTASI,STAFFPK1_STATUS-->[A:Profesional Skil B:Proses kerja C:Absensi]
    End Sub

    Sub AktifUtammaKlikDetailKaryawan()
        MultiViewAkses.ActiveViewIndex = 1

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

    Function GetData_STAFF(ByVal mSqlCommadstring As String) As Double 'fungsi untuk menampilkan data ke dalam textbox saat aksi detail di pilij 
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
                lblStaffNIK.Text = nSr(MyRecReadA("STAFF_NIK"))
                TxtStaffNIK.Enabled = False
                TxtStaffNama.Text = nSr(MyRecReadA("STAFF_NAMA"))
                Dim tglLahir = Convert.ToDateTime(nSr(MyRecReadA("STAFF_LAHIRTGL"))).ToString("dd-MM-yyyy")
                TxtStaffLahir.Text = nSr(MyRecReadA("STAFF_LAHIRTMP")) + " / " + tglLahir
                DropDownList1.Text = nSr(MyRecReadA("STAFF_STATUS"))
                TxtStaffJalan.Text = nSr(MyRecReadA("STAFF_ALAMATJLN"))
                TxtStaffRT.Text = nSr(MyRecReadA("STAFF_ALAMATRT")) + " / " + nSr(MyRecReadA("STAFF_ALAMATRW"))
                TxtStaffKodePos.Text = nSr(MyRecReadA("STAFF_ALAMATPOS"))
                TxtStaffEmail.Text = nSr(MyRecReadA("STAFF_EMAIL"))
                TxtStaffNoKtp.Text = nSr(MyRecReadA("STAFF_NOKTP"))
                TxtStaffSIM.Text = nSr(MyRecReadA("STAFF_SIMTYPE")) + " / " + nSr(MyRecReadA("STAFF_SIMNO"))
                TxtStaffBPJSKerja.Text = nSr(MyRecReadA("STAFF_NOBPJSKERJA"))
                TxtStaffBPJSSehat.Text = nSr(MyRecReadA("STAFF_NOBPJSSEHAT"))
                TxtStaffNPWP.Text = nSr(MyRecReadA("STAFF_NPWP"))
                TxtStaffBCA.Text = nSr(MyRecReadA("STAFF_REKBCA"))
                TxtJkel.Text = nSr(MyRecReadA("STAFF_JKEL"))
                TxtDarah.Text = nSr(MyRecReadA("STAFF_DARAH"))
                TxtAgama.Text = nSr(MyRecReadA("STAFF_AGAMA"))
                TxtStaffNoHP.Text = nSr(MyRecReadA("STAFF_HP"))
                TxtStaffNoTelepon.Text = nSr(MyRecReadA("STAFF_PHONE"))
                TxtStaffNoContact.Text = nSr(MyRecReadA("STAFF_CONTACT"))
                TxtStaffKel.Text = nSr(MyRecReadA("STAFF_ALAMATKEL"))
                TxtStaffKota.Text = nSr(MyRecReadA("STAFF_ALAMATKAB"))
                TxtStatusKerjaMasuk.Text = Convert.ToDateTime(nSr(MyRecReadA("STAFF_STATUSKERJAMASUKK"))).ToString("dd-MM-yyyy")
                TxtStatusKerjaJabatan.Text = nSr(MyRecReadA("STAFF_STATUSKERJAJABATAN"))
                TxtStatusKerjaDept.Text = nSr(MyRecReadA("STAFF_STATUSKERJADEPT"))
                TxtStatusKerjaTempat.Text = nSr(MyRecReadA("STAFF_STATUSKERJALOKASI"))
                If nLg(MyRecReadA("STAFF_SUBJABATAN")) = 0 Then
                    TxtStatusKerjaSubJabatan.Text = "0 - Operator"
                ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 1 Then
                    TxtStatusKerjaSubJabatan.Text = "1 - Staff"
                ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 2 Then
                    TxtStatusKerjaSubJabatan.Text = "2 - Leader"
                ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 3 Then
                    TxtStatusKerjaSubJabatan.Text = "3 - SPV"
                ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 4 Then
                    TxtStatusKerjaSubJabatan.Text = "4 - Ast. Manager"
                ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 5 Then
                    TxtStatusKerjaSubJabatan.Text = "5 - Manager"
                End If

                DropDownList2.Text = nSr(MyRecReadA("STAFF_STATUSKERJAMG"))
                TxtStatusKerjaMagangTglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAMGTGL"))

                DropDownList3.Text = nSr(MyRecReadA("STAFF_STATUSKERJAPC"))
                TxtStatusKerjaCobaTglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAPCTGL"))

                DropDownList4.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKT1"))
                TxtStatusKerjaKontrak1TglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKT1TGL"))

                DropDownList5.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKT2"))
                TxtStatusKerjaKontrak2TglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKT2TGL"))

                DropDownList6.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKTG"))
                TxtStatusKerjaAgenTglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKTGTGL"))

                TxtStatusKerjaTetap.Text = nSr(MyRecReadA("STAFF_STATUSKERJATGLANGKAT"))
                TxtStatusKerjaKeluar.Text = nSr(MyRecReadA("STAFF_STATUSKERJATGLKELUAR"))
                TxtStatusKerjaAlasan.Text = nSr(MyRecReadA("STAFF_STATUSKERJAALSKELUAR"))
                If (MyRecReadA("STAFF_FOTO") Is DBNull.Value) Then
                    Image1.Attributes("src") = "WEBDOWNLOAD\FOTOKARYAWAN\Icon.png"
                ElseIf (MyRecReadA("STAFF_FOTO") IsNot DBNull.Value) Then
                    Image1.Attributes("src") = "WEBDOWNLOAD\FOTOKARYAWAN\" & nSr(MyRecReadA("STAFF_FOTO"))
                End If
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
End Class
