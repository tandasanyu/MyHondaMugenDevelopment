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

Partial Class HRDFORMIZIN
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

            MultiViewAkses.ActiveViewIndex = 0
            MultiViewNilaiStandardEntry.ActiveViewIndex = 0
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



    Sub insertabel(ByVal mKPIN_KODE As String, ByVal mKPIN_USER As String, ByVal mKPIN_ATASAN As String, ByVal mKPIN_NILAI As String, ByVal mKPIN_TGL As String, ByVal mKPIN_NOTE As String)
        Dim myinsert = "insert INTO TRXN_KPIN (KPIN_NIK,KPIN_TAHUN,KPIN_USER,KPIN_ATASAN,KPIN_KODE,KPIN_NILAI,KPIN_TGL,KPIN_NOTE,KPIN_GROUP) VALUES " & _
                       "('" & TxtStaffNIK.Text & "','" & TahunPenilaian.Text & "','" & mKPIN_USER & "','" & mKPIN_ATASAN & "','" & mKPIN_KODE & "','" & mKPIN_NILAI & "','" & Now() & "','" & mKPIN_NOTE & "','1')"
        Call UpdateData_Server(myinsert)
    End Sub


    Function UpdateData_Server(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        'LabelError.Text = ""
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
    Protected Sub DropDownJenisiIzin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownJenisiIzin.SelectedIndexChanged
        MultiViewNilaiStandardEntry.ActiveViewIndex = Convert.ToInt32(DropDownJenisiIzin.SelectedValue)
    End Sub
    Protected Sub BtnSaveCuti_Click(sender As Object, e As EventArgs) Handles BtnSaveCuti.Click
        Call UpdateData_Server(InsertData_Izin_Cuti, "C1")

        Response.Write("<script>alert('Data Izin Berhasil di Simpan!')</script>")
        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx?no=" + TxtStaffNIK.Text + "';</script>")
    End Sub

    Function InsertData_Izin_Cuti() As String
        If DropDownJenisiIzin.Text = 0 Then
            InsertData_Izin_Cuti = "INSERT INTO DATA_IZIN (IZIN_NIK, IZIN_NAMA, IZIN_JENIS, IZIN_TAHUN_CUTI, IZIN_ALASAN, IZIN_TGL1, IZIN_TGL2) VALUES ('" & TxtStaffNIK.Text & "', '" & TxtStaffNama.Text & "','Cuti','" & TxtTahunCuti.Text & "', '" & TxtPetik(DropDownListCuti.Text) & "', '" & TxtPetik(TxtTglCuti1.Text) & "', '" & TxtPetik(TxtTglCuti2.Text) & "')"
        End If

    End Function

    '============================================================== miscellaneous Function=============================
    Function UpdateData_Server(ByVal mSqlCommadstring As String, ByVal mPos As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        LblErrorSaveCuti.Text = ""
        'LblErrorSaveA111.Text = ""
        'LblErrorSaveA113.Text = ""
        'LblErrorSaveA12.Text = ""
        'LblErrorSaveA13.Text = ""
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
        If Kode = "I1" Then
            LblErrorSaveCuti.Text = Errormsg
            'ElseIf Kode = "A111" Then
            'LblErrorSaveA111.Text = Errormsg
            'ElseIf Kode = "A113" Then
            'LblErrorSaveA113.Text = Errormsg
            'ElseIf Kode = "A12" Then
            'LblErrorSaveA12.Text = Errormsg
            'ElseIf Kode = "A13" Then
            'LblErrorSaveA13.Text = Errormsg

        End If
    End Sub

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
    Protected Sub LvDetailStaff_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailStaff.SelectedIndexChanged
        TxtStaffNIK.Text = (LvDetailStaff.DataKeys(LvDetailStaff.SelectedIndex).Value.ToString) 'jika di comment, maka nik tidak muncul saat di klik detail
        'MsgBox(TxtStaffNIK.Text)
        Call GetData_IZIN_STAFF("SELECT * FROM DATA_IZIN WHERE IZIN_NIK='" & TxtStaffNIK.Text & "'") ' jika di comment, maka data detail tidak muncul saat di klik detail
        'Call AktifUtammaKlikDetailKaryawan()
    End Sub

    Function GetData_IZIN_STAFF(ByVal mSqlCommadstring As String) As Double 'fungsi untuk menampilkan data ke dalam textbox saat aksi detail di pilij 
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_IZIN_STAFF = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtStaffNIK.Text = nSr(MyRecReadA("IZIN_NIK"))
                'lblStaffNIK.Text = nSr(MyRecReadA("STAFF_NIK"))
                TxtStaffNIK.Enabled = False
                TxtStaffNama.Text = nSr(MyRecReadA("IZIN_NAMA"))
                'Dim tglLahir = Convert.ToDateTime(nSr(MyRecReadA("STAFF_LAHIRTGL"))).ToString("dd-MM-yyyy")
                'Dim izin_tgl1 = Convert.ToDateTime(nSr(MyRecReadA("IZIN_TGL1"))).ToString("dd-MM-yyyy")
                'Dim izin_tgl2 = Convert.ToDateTime(nSr(MyRecReadA("IZIN_TGL2"))).ToString("dd-MM-yyyy")
                'TxtStaffLahir.Text = nSr(MyRecReadA("STAFF_LAHIRTMP")) + " / " + tglLahir
                TxtSaldoCuti.Text = nSr(MyRecReadA("IZIN_SALDO_CUTI"))
                TxtTahunCuti.Text = nSr(MyRecReadA("IZIN_TAHUN_CUTI"))
                DropDownListCuti.Text = nSr(MyRecReadA("IZIN_ALASAN"))
                DropDownJenisiIzin.Text = nSr(MyRecReadA("IZIN_JENIS"))
                TxtTglCuti1.Text = nSr(MyRecReadA("IZIN_TGL1"))
                TxtTglCuti2.Text = nSr(MyRecReadA("IZIN_TGL2"))


                'DropDownList1.Text = nSr(MyRecReadA("STAFF_STATUS"))
                'TxtStaffJalan.Text = nSr(MyRecReadA("STAFF_ALAMATJLN"))
                'TxtStaffRT.Text = nSr(MyRecReadA("STAFF_ALAMATRT")) + " / " + nSr(MyRecReadA("STAFF_ALAMATRW"))
                'TxtStaffKodePos.Text = nSr(MyRecReadA("STAFF_ALAMATPOS"))
                'TxtStaffEmail.Text = nSr(MyRecReadA("STAFF_EMAIL"))
                'TxtStaffNoKtp.Text = nSr(MyRecReadA("STAFF_NOKTP"))
                'TxtStaffSIM.Text = nSr(MyRecReadA("STAFF_SIMTYPE")) + " / " + nSr(MyRecReadA("STAFF_SIMNO"))
                'TxtStaffBPJSKerja.Text = nSr(MyRecReadA("STAFF_NOBPJSKERJA"))
                'TxtStaffBPJSSehat.Text = nSr(MyRecReadA("STAFF_NOBPJSSEHAT"))
                'TxtStaffNPWP.Text = nSr(MyRecReadA("STAFF_NPWP"))
                'TxtStaffBCA.Text = nSr(MyRecReadA("STAFF_REKBCA"))
                'TxtJkel.Text = nSr(MyRecReadA("STAFF_JKEL"))
                'TxtDarah.Text = nSr(MyRecReadA("STAFF_DARAH"))
                'TxtAgama.Text = nSr(MyRecReadA("STAFF_AGAMA"))
                'TxtStaffNoHP.Text = nSr(MyRecReadA("STAFF_HP"))
                'TxtStaffNoTelepon.Text = nSr(MyRecReadA("STAFF_PHONE"))
                'TxtStaffNoContact.Text = nSr(MyRecReadA("STAFF_CONTACT"))
                'TxtStaffKel.Text = nSr(MyRecReadA("STAFF_ALAMATKEL"))
                'TxtStaffKota.Text = nSr(MyRecReadA("STAFF_ALAMATKAB"))
                'TxtStatusKerjaMasuk.Text = Convert.ToDateTime(nSr(MyRecReadA("STAFF_STATUSKERJAMASUKK"))).ToString("dd-MM-yyyy")
                'TxtStatusKerjaJabatan.Text = nSr(MyRecReadA("STAFF_STATUSKERJAJABATAN"))
                'TxtStatusKerjaDept.Text = nSr(MyRecReadA("STAFF_STATUSKERJADEPT"))
                'TxtStatusKerjaTempat.Text = nSr(MyRecReadA("STAFF_STATUSKERJALOKASI"))
                'If nLg(MyRecReadA("STAFF_SUBJABATAN")) = 0 Then
                '    TxtStatusKerjaSubJabatan.Text = "0 - Operator"
                'ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 1 Then
                '    TxtStatusKerjaSubJabatan.Text = "1 - Staff"
                'ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 2 Then
                '    TxtStatusKerjaSubJabatan.Text = "2 - Leader"
                'ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 3 Then
                '    TxtStatusKerjaSubJabatan.Text = "3 - SPV"
                'ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 4 Then
                '    TxtStatusKerjaSubJabatan.Text = "4 - Ast. Manager"
                'ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 5 Then
                '    TxtStatusKerjaSubJabatan.Text = "5 - Manager"
                'End If

                'DropDownList2.Text = nSr(MyRecReadA("STAFF_STATUSKERJAMG"))
                'TxtStatusKerjaMagangTglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAMGTGL"))

                'DropDownList3.Text = nSr(MyRecReadA("STAFF_STATUSKERJAPC"))
                'TxtStatusKerjaCobaTglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAPCTGL"))

                'DropDownList4.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKT1"))
                'TxtStatusKerjaKontrak1TglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKT1TGL"))

                'DropDownList5.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKT2"))
                'TxtStatusKerjaKontrak2TglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKT2TGL"))

                'DropDownList6.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKTG"))
                'TxtStatusKerjaAgenTglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKTGTGL"))

                'TxtStatusKerjaTetap.Text = nSr(MyRecReadA("STAFF_STATUSKERJATGLANGKAT"))
                'TxtStatusKerjaKeluar.Text = nSr(MyRecReadA("STAFF_STATUSKERJATGLKELUAR"))
                'TxtStatusKerjaAlasan.Text = nSr(MyRecReadA("STAFF_STATUSKERJAALSKELUAR"))
                'If (MyRecReadA("STAFF_FOTO") Is DBNull.Value) Then
                '    Image1.Attributes("src") = "WEBDOWNLOAD\FOTOKARYAWAN\Icon.png"
                'ElseIf (MyRecReadA("STAFF_FOTO") IsNot DBNull.Value) Then
                '    Image1.Attributes("src") = "WEBDOWNLOAD\FOTOKARYAWAN\" & nSr(MyRecReadA("STAFF_FOTO"))
                'End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function
End Class
