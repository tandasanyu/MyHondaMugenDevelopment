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

Partial Class SALES_Form0104APPROVEDOKUMEN
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader
    Dim sFileDir As String = "E:\"
    Dim lMaxFileSize As Long = 4096
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

            '-------------------------------------------------------------------------
            '|                      Akses Approve Sistem ISO                         |
            '-------------------------------------------------------------------------

            'Akses Area Approve Panduan Mutu
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'ISO APPROVAL -- VIEW MENU'") = 1 Then
                MultiViewPanduanMutu.ActiveViewIndex = 0
            Else
                MultiViewPanduanMutu.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            'Akses Area Approve Diketahui SOP
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SOP -- DIKETAHUI APPROVAL'") = 1 Then
                MultiViewSOP.ActiveViewIndex = 0
            Else
                MultiViewSOP.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            'Akses Area Approve Disetujui SOP
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SOP -- DISETUJUI APPROVAL'") = 1 Then
                MultiViewSOP2.ActiveViewIndex = 0
            Else
                MultiViewSOP2.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            'Akses Area Approve Diketahui Instruksi Kerja
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM INSTRUKSI KERJA -- DIKETAHUI APPROVAL'") = 1 Then
                MultiViewInstruksi.ActiveViewIndex = 0
            Else
                MultiViewInstruksi.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            'Akses Area Approve Disetujui Instruksi Kerja
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM INSTRUKSI KERJA -- DISETUJUI APPROVAL'") = 1 Then
                MultiViewInstruksi2.ActiveViewIndex = 0
            Else
                MultiViewInstruksi2.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            '-------------------------------------------------------------------------
            '|                      Akses Approve Sistem IT                         |
            '-------------------------------------------------------------------------

            'Akses Area Validasi Backup Server
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM BACKUP -- VALIDASI'") = 1 Then
                MultiViewBackup.ActiveViewIndex = 0
            Else
                MultiViewBackup.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            'Akses Area Mengetahui Maintenance 
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM MAINTENANCE -- MENGETAHUI'") = 1 Then
                MultiViewMaintenance.ActiveViewIndex = 0
            Else
                MultiViewMaintenance.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            'Akses Area Validasi Verifikasi Program
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM VERIFIKASI -- VALIDASI'") = 1 Then
                MultiViewVerifikasi.ActiveViewIndex = 0
            Else
                MultiViewVerifikasi.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            'Akses Area Approval SDR Diketahui
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SDR -- DIKETAHUI'") = 1 Then
                MultiViewDiketahuiSDR.ActiveViewIndex = 0
                Call GetData_Diketahui("SELECT * FROM trxn_sdr WHERE SDRLOG_KETAHUINAMA = '" & LblUserName.Text & "'")
            Else
                MultiViewDiketahuiSDR.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            'Akses Area Approval SDR Disetujui
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SDR -- DISETUJUI'") = 1 Then
                MultiViewDisetujuiSDR.ActiveViewIndex = 0
            Else
                MultiViewDisetujuiSDR.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            'Akses Area Approval SDR Diuji
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SDR -- DIUJI'") = 1 Then
                MultiViewDiujiSDR.ActiveViewIndex = 0
            Else
                MultiViewDiujiSDR.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            '-------------------------------------------------------------------------
            '|                     Akses Approve Sistem Audit                         |
            '-------------------------------------------------------------------------

            'Akses Area Approval Berita Acara Diketahui 1
            If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM BERITA ACARA -- DIKETAHUI APPROVAL'") = 1 Then
                MultiViewBeritaAcara1.ActiveViewIndex = 0
            Else
                MultiViewBeritaAcara1.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            'Akses Area Approval Berita Acara Diketahui 2
            If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM BERITA ACARA -- DIKETAHUI2 APPROVAL'") = 1 Then
                MultiViewBeritaAcara2.ActiveViewIndex = 0
            Else
                MultiViewBeritaAcara2.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            'Akses Area Approval Berita Acara Disetujui
            If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM BERITA ACARA -- DISETUJUI APPROVAL'") = 1 Then
                MultiViewBeritaAcara3.ActiveViewIndex = 0
            Else
                MultiViewBeritaAcara3.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub

    '-------------------------------------------------------------------------
    '|                      Event pada button                                 |
    '--------------------------------------------------------------------------

    '----------------------------- Sistem ISO --------------------------------'

    'Approval panduan mutu
    Protected Sub LvDetailPanduanMutu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailPanduanMutu.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailPanduanMutu.DataKeys(LvDetailPanduanMutu.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_DISETUJUI='" & LblUserName.Text & "',DOKUMEN_TGLDISETUJUI=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesan()
        LvDetailPanduanMutu.DataBind()
    End Sub

    'Approval diketahui SOP
    Protected Sub LvDetailSOP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailSOP.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailSOP.DataKeys(LvDetailSOP.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI='" & LblUserName.Text & "',DOKUMEN_TGLDIKETAHUI=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesan()
        LvDetailPanduanMutu.DataBind()
    End Sub

    'Approval disetujui SOP
    Protected Sub LvDetailSOP2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailSOP2.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailSOP2.DataKeys(LvDetailSOP2.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_DISETUJUI='" & LblUserName.Text & "',DOKUMEN_TGLDISETUJUI=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesan()
        LvDetailPanduanMutu.DataBind()
    End Sub

    'Approval diketahui Instruksi Kerja
    Protected Sub LvDetailInstruksi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailInstruksi.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailInstruksi.DataKeys(LvDetailInstruksi.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI='" & LblUserName.Text & "',DOKUMEN_TGLDIKETAHUI=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesan()
        LvDetailPanduanMutu.DataBind()
    End Sub

    'Approval disetujui Instruksi Kerja
    Protected Sub LvDetailLvDetailInstruksi2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailInstruksi2.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailInstruksi2.DataKeys(LvDetailInstruksi2.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_DISETUJUI='" & LblUserName.Text & "',DOKUMEN_TGLDISETUJUI=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesan()
        LvDetailPanduanMutu.DataBind()
    End Sub

    '----------------------------- Sistem IT --------------------------------'

    'Validasi Backup Server
    Protected Sub LvDetailBackup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailBackup.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailBackup.DataKeys(LvDetailBackup.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_BACKUP SET BACKUP_HEADIT='" & LblUserName.Text & "',BACKUP_TGLHEADIT=GETDATE() WHERE BACKUP_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        LvDetailBackup.DataBind()
    End Sub

    'Validasi Head IT Maintenance Server
    Protected Sub LvDetailMaintenance_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailMaintenance.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailMaintenance.DataKeys(LvDetailMaintenance.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_MAINTENANCE SET MAINTENANCE_VALIDASIHEADIT='" & LblUserName.Text & "', MAINTENANCE_TGLVALIDASIHEADIT=GETDATE() WHERE MAINTENANCE_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        LvDetailMaintenance.DataBind()
    End Sub

    'Validasi User Maintenance Server
    Protected Sub LvDetailVerifikasi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailVerifikasi.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailVerifikasi.DataKeys(LvDetailVerifikasi.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_Verifikasi SET VERIFIKASI_VALIDASIUSER='" & LblUserName.Text & "', VERIFIKASI_TGLVALIDASIUSER=GETDATE() WHERE VERIFIKASI_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        LvDetailMaintenance.DataBind()
    End Sub

    'Approval SDR Diketahui 
    Protected Sub LvDetailDiketahuiSDR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailDiketahuiSDR.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailDiketahuiSDR.DataKeys(LvDetailDiketahuiSDR.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_SDR SET SDRLOG_KETAHUITGL=GETDATE()  WHERE SDRLOG_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesanSDR()
        LvDetailDiketahuiSDR.DataBind()
        LvDetailDisetujuiSDR.DataBind()
    End Sub

    'Approval SDR Disetujui
    Protected Sub LvDetailDisetujuiSDR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailDisetujuiSDR.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailDisetujuiSDR.DataKeys(LvDetailDisetujuiSDR.SelectedIndex).Value.ToString)
        Call GetData_SDR("SELECT * FROM TRXN_SDR WHERE SDRLOG_NO='" & lblBackupId & "'")
        MultiViewDisetujuiSDR2.ActiveViewIndex = 0
        MultiViewDisetujuiSDR.ActiveViewIndex = -1
    End Sub

    Protected Sub BtnNilaiSMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave.Click

        Dim lblBackupId As String = lblSDRId.Text
        Dim mSqlTxt As String = "UPDATE TRXN_SDR SET SDRLOG_SETUJUNAMA='" & LblUserName.Text & "',SDRLOG_SETUJUTGL='" & Now() & "', SDRLOG_TARGETR1='" & TxtSDREstimasiTgl.Text & "'  WHERE SDRLOG_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        MultiViewDisetujuiSDR2.ActiveViewIndex = -1
        MultiViewDisetujuiSDR.ActiveViewIndex = 0
        LvDetailDisetujuiSDR.DataBind()
        LvDetailDiujiSDR.DataBind()
    End Sub

    'Approval SDR Diuji
    Protected Sub LvDetailDiujiSDR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailDiujiSDR.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailDiujiSDR.DataKeys(LvDetailDiujiSDR.SelectedIndex).Value.ToString)
        Call GetData_SDR2("SELECT * FROM TRXN_SDR WHERE SDRLOG_NO='" & lblBackupId & "'")
        MultiViewDiujiSDR2.ActiveViewIndex = 0
        MultiViewDiujiSDR.ActiveViewIndex = -1
    End Sub

    Protected Sub BtnNilaiSMSave2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave2.Click

        Dim lblBackupId As String = lblSDRId1.Text
        Dim mSqlTxt As String = "UPDATE TRXN_SDR SET SDRLOG_UJINAMA='" & LblUserName.Text & "',SDRLOG_UJITGL='" & Now() & "', SDRLOG_TESTSTATUS='" & DropDownList3.Text & "', SDRLOG_TESTNOTE='" & TxtSDRCatatan.Text & "'  WHERE SDRLOG_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        MultiViewDisetujuiSDR2.ActiveViewIndex = -1
        MultiViewDisetujuiSDR.ActiveViewIndex = 0
        LvDetailDisetujuiSDR.DataBind()
        LvDetailDiujiSDR.DataBind()
    End Sub

    '----------------------------- Sistem Audit --------------------------------'

    'Approval Berita Acara Diketahui 
    Protected Sub LvDetailDiketahuiBeritaAcara_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailDiketahuiBeritaAcara.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailDiketahuiBeritaAcara.DataKeys(LvDetailDiketahuiBeritaAcara.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_TGLDIKETAHUI=GETDATE()  WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call emailapprove_server("select * from tb_user where jabatan='" & lblArea1.Text & "'")
        LvDetailDiketahuiBeritaAcara.DataBind()
    End Sub

    'Approval Berita Acara Diketahui2 
    Protected Sub LvDetailDiketahui2BeritaAcara_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailDiketahui2BeritaAcara.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailDiketahui2BeritaAcara.DataKeys(LvDetailDiketahui2BeritaAcara.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_TGLDIKETAHUI2=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call emailapprove_server("select * from tb_user where jabatan='QMR'")
        LvDetailDiketahui2BeritaAcara.DataBind()
    End Sub

    'Approval Berita Acara Disetujui
    Protected Sub LvDetailDisetujuiBeritaAcara_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailDisetujuiBeritaAcara.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailDisetujuiBeritaAcara.DataKeys(LvDetailDisetujuiBeritaAcara.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_DISETUJUI='" & LblUserName.Text & "',DOKUMEN_TGLDISETUJUI=GETDATE()  WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call emailnotif_server("select * from tb_user where jabatan='Operational Support Manager'")
        LvDetailDisetujuiBeritaAcara.DataBind()
    End Sub

    '-------------------------------------------------------------------------
    '|                      Kumpulan Fungsi                                  |
    '--------------------------------------------------------------------------
    Sub Msg_err(ByVal mTest As String)
        lblMsgBox.Text = mTest
        If mTest = "" Then
            MultiViewError.ActiveViewIndex = 0
        Else
            MultiViewError.ActiveViewIndex = 0
        End If
    End Sub

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
            MsgBox(ex.Message)
        End Try
    End Function

    Function GetData_SDR(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_SDR = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                lblSDRId.Text = nSr(MyRecReadA("SDRLOG_NO"))
                LblJns.Text = nSr(MyRecReadA("SDRLOG_JENIS"))
                LblPemohon.Text = nSr(MyRecReadA("SDRLOG_PEMOHONNAMA"))
                lblTujuan.Text = nSr(MyRecReadA("SDRLOG_TUJUAN"))
                LblDetail.Text = nSr(MyRecReadA("SDRLOG_DETAIL"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_SDR2(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_SDR2 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                lblSDRId1.Text = nSr(MyRecReadA("SDRLOG_NO"))
                lblJns1.Text = nSr(MyRecReadA("SDRLOG_JENIS"))
                lblTujuan1.Text = nSr(MyRecReadA("SDRLOG_TUJUAN"))
                lblDetail1.Text = nSr(MyRecReadA("SDRLOG_DETAIL"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
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
            Call Msg_err(ex.Message)
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
                lblArea1.Text = MyRecReadA("JABATAN")
            End While
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
        End Try
    End Function

    Function GetData_Diketahui(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Diketahui = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Diketahui = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                lblArea2.Text = MyRecReadA("SDRLOG_KETAHUINAMA")
            End While
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

    '-------------------------------------------------------------------------
    '|                      Fungsi Kirim Email Notif                         |
    '-------------------------------------------------------------------------

    'Email notif panduan mutu ke QMR bahwa dokumen telah disetujui Direksi 
    Sub KirimPesan()
        Dim pesan As New MailMessage
        pesan.Subject = "Dokumen Panduan Mutu Telah Disetujui"
        pesan.To.Add("linda@hondamugen.co.id") 'email tujuan
        pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
        pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Ada Dokumen Panduan Mutu yang sudah disetujui oleh Direksi <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Dokumen Panduan Mutu</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
        pesan.IsBodyHtml = True
        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p") 'isi dengan info akun gmail kalian
        SMTP.Port = "587"
        SMTP.Send(pesan)
    End Sub

    'Email notif laporan dan berita acara audit ke masing-masing Kepala Divisi dan QMR bahwa dokumen butuh persetujuan darinya 
    Function emailapprove_server(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        emailapprove_server = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            emailapprove_server = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                Dim email As String = nSr(MyRecReadA("email"))
                Dim pesan As New MailMessage
                pesan.Subject = "Terdapat Dokumen Laporan dan Berita Acara Audit/Stockopname Yang Membutuhkan Persetujuan Anda"
                pesan.To.Add(email) 'email tujuan
                pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
                pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda memiliki sebuah permintaan persetujuan untuk Dokumen Laporan dan Berita Acara Audit/Stockopname <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Daftar Approval</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
                pesan.IsBodyHtml = True
                Dim SMTP As New SmtpClient("smtp.gmail.com")
                SMTP.EnableSsl = True
                SMTP.Credentials = New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p") 'isi dengan info akun gmail kalian
                SMTP.Port = "587"
                SMTP.Send(pesan)
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    'Email notif CC laporan dan berita acara audit telah disetujui kepala divisi dan QMR ke Operational Support Manager
    Function emailnotif_server(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        emailnotif_server = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            emailnotif_server = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                Dim email As String = nSr(MyRecReadA("email"))
                Dim pesan As New MailMessage
                pesan.Subject = "Terdapat Dokumen Laporan dan Berita Acara Audit/Stockopname Baru"
                pesan.To.Add(email) 'email tujuan
                pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
                pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Ada Laporan dan Berita Acara Audit/Stockopname Baru <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Dokumen Laporan dan Berita Acara Audit/Stockopname</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
                pesan.IsBodyHtml = True
                Dim SMTP As New SmtpClient("smtp.gmail.com")
                SMTP.EnableSsl = True
                SMTP.Credentials = New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p") 'isi dengan info akun gmail kalian
                SMTP.Port = "587"
                SMTP.Send(pesan)
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    'Email notif SDR ke IT bahwa dokumen telah disetujui Head Divisi 
    Sub KirimPesanSDR()
        Dim pesan As New MailMessage
        pesan.Subject = "Terdapat Dokumen SDR Yang Membutuhkan Persetujuan Anda"
        pesan.To.Add("mis@hondamugen.co.id")
        'pesan.To.Add("komang@hondamugen.co.id") 'email tujuan
        pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
        pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Terdapat Dokumen SDR Yang Membutuhkan Persetujuan Anda <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Daftar Approval</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
        pesan.IsBodyHtml = True
        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p") 'isi dengan info akun gmail kalian
        SMTP.Port = "587"
        SMTP.Send(pesan)
    End Sub
End Class
