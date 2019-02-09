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

Partial Class APPROVEDOKUMEN
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
            'Response.Write("<script>alert('Selamat Datang : '" + LblArea1.Text + "'')</script>")
            'Akses Area Approve Panduan Mutu
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM PANDUAN MUTU -- DISETUJUI APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='A' AND [DOKUMEN_STATUS]=1 AND [DOKUMEN_DISETUJUI] IS NULL OR [DOKUMEN_DISETUJUI] =''") Then
                MultiViewPanduanMutu.ActiveViewIndex = 0
            Else
                MultiViewPanduanMutu.ActiveViewIndex = -1
            End If

            'Akses Area Approve Dibuat SOP (approval tgl di buat 1)
            If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM SOP -- DIBUAT APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_DIBUAT]= '" & LblArea1.Text & "' AND [DOKUMEN_JENIS]='B' AND [DOKUMEN_TGLDIBUAT] IS NULL") Then
                MultiViewSOP.ActiveViewIndex = 0
            Else
                MultiViewSOP.ActiveViewIndex = -1
            End If

            'Akses Area Approve Dibuat SOP (approval tgl di buat 2)
            If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM SOP -- DIBUAT APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_DIBUAT2]= '" & LblArea1.Text & "' AND [DOKUMEN_JENIS]='B' AND [DOKUMEN_TGLDIBUAT2] IS NULL") Then
                MultiViewSOP3.ActiveViewIndex = 0
            Else
                MultiViewSOP3.ActiveViewIndex = -1
            End If

            'Akses Area Approve Diketahui SOP (Approval Bu Linda)
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SOP -- DIKETAHUI APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='B' AND [DOKUMEN_DIKETAHUI] IS NULL AND [DOKUMEN_TGLDIBUAT] IS NOT NULL  AND [DOKUMEN_DEPARTMENT] NOT IN ('Service','Spare part')") Then
                'Response.Write("<script>alert('sop1')</script>")
                MultiViewSOP1.ActiveViewIndex = 0
                'If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SOP -- DIKETAHUI APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_DIBUAT2], [DOKUMEN_NAMA],  [DOKUMEN_KETERANGAN], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='B' AND [DOKUMEN_DIKETAHUI] IS NULL AND [DOKUMEN_DIBUAT] IS NOT NULL AND [DOKUMEN_TGLDIBUAT] IS NOT NULL  AND [DOKUMEN_DIBUAT2] IS NOT NULL AND [DOKUMEN_DEPARTMENT] IN ('Service','Spare part')") Then
                '    MultiViewSOP5.ActiveViewIndex = 0
                'Else
                '    MultiViewSOP5.ActiveViewIndex = -1
                'End If
            ElseIf GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SOP -- DIKETAHUI APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='B' AND [DOKUMEN_DIKETAHUI] IS NULL AND [DOKUMEN_TGLDIBUAT] IS NOT NULL AND [DOKUMEN_DIBUAT2] IS NULL  AND [DOKUMEN_DEPARTMENT] NOT IN ('Service','Spare part')") Then
                'Response.Write("<script>alert('sop2')</script>")
                MultiViewSOP4.ActiveViewIndex = 0
                'If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SOP -- DIKETAHUI APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_DIBUAT2], [DOKUMEN_NAMA],  [DOKUMEN_KETERANGAN], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='B' AND [DOKUMEN_DIKETAHUI] IS NULL AND [DOKUMEN_DIBUAT] IS NOT NULL AND [DOKUMEN_TGLDIBUAT] IS NOT NULL  AND [DOKUMEN_DIBUAT2] IS NOT NULL AND [DOKUMEN_DEPARTMENT] IN ('Service','Spare part')") Then
                '    MultiViewSOP5.ActiveViewIndex = 0
                'Else
                '    MultiViewSOP5.ActiveViewIndex = -1
                'End If
            ElseIf GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SOP -- DIKETAHUI APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_DIBUAT2], [DOKUMEN_NAMA],  [DOKUMEN_KETERANGAN], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='B' AND [DOKUMEN_DIKETAHUI] IS NULL AND [DOKUMEN_DIBUAT] IS NOT NULL AND [DOKUMEN_TGLDIBUAT] IS NOT NULL  AND [DOKUMEN_DIBUAT2] IS NOT NULL AND [DOKUMEN_DEPARTMENT] IN ('Service','Spare part')") Then
                MultiViewSOP5.ActiveViewIndex = 0
            Else

                MultiViewSOP1.ActiveViewIndex = -1
                MultiViewSOP5.ActiveViewIndex = -1
                'additional
                MultiViewSOP4.ActiveViewIndex = -1
            End If



            'Akses Area Approve Disetujui SOP (approval Pak Santo)
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SOP -- DISETUJUI APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='B' AND [DOKUMEN_DISETUJUI] IS NULL AND [DOKUMEN_DIKETAHUI] IS NOT NULL") Then
                MultiViewSOP2.ActiveViewIndex = 0
            Else
                MultiViewSOP2.ActiveViewIndex = -1
            End If

            'Akses Area Approve Dibuat Instruksi Kerja (Approval By Tgl Di Buat 1)
            If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM INSTRUKSI KERJA -- DIBUAT APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_DIBUAT]= '" & LblArea1.Text & "' AND [DOKUMEN_JENIS]='C' AND [DOKUMEN_TGLDIBUAT] IS NULL") Then
                MultiViewInstruksiKerja1.ActiveViewIndex = 0
            Else
                MultiViewInstruksiKerja1.ActiveViewIndex = -1
            End If

            'Akses Area Approve Dibuat Instruksi Kerja (Approval By Tgl Di Buat 2)
            If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM INSTRUKSI KERJA -- DIBUAT APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_DIBUAT2]= '" & LblArea1.Text & "' AND [DOKUMEN_JENIS]='C' AND [DOKUMEN_TGLDIBUAT2] IS NULL") Then
                MultiViewInstruksiKerja2.ActiveViewIndex = 0
            Else
                MultiViewInstruksiKerja2.ActiveViewIndex = -1
            End If

            'Akses Area Approve Diketahui Instruksi Kerja (approval by qmr)
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM INSTRUKSI KERJA -- DIKETAHUI APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='C' AND [DOKUMEN_DIKETAHUI] IS NULL AND [DOKUMEN_TGLDIBUAT] IS NOT NULL") Then
                MultiViewInstruksiKerja3.ActiveViewIndex = 0
            Else
                MultiViewInstruksiKerja3.ActiveViewIndex = -1
            End If

            'Akses Area Approve Disetujui Instruksi Kerja (by Direksi)
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM INSTRUKSI KERJA -- DISETUJUI APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='C' AND [DOKUMEN_DISETUJUI] IS NULL AND [DOKUMEN_DIKETAHUI] IS NOT NULL") Then
                MultiViewInstruksiKerja4.ActiveViewIndex = 0

            Else
                MultiViewInstruksiKerja4.ActiveViewIndex = -1
            End If

            '-------------------------------------------------------------------------
            '|                      Akses Approve Sistem IT                         |
            '-------------------------------------------------------------------------

            'Akses Area Validasi Backup Server
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM BACKUP -- VALIDASI'") = 1 And GetFindRecord_Server("SELECT [BACKUP_NO], [BACKUP_TGLBACKUP], [BACKUP_NODISK], [BACKUP_KETERANGAN], [BACKUP_ITSTAFF], [BACKUP_TGLITSTAFF] FROM [TRXN_BACKUP] WHERE [BACKUP_TGLHEADIT] IS NULL AND [BACKUP_HEADIT] IS NULL") Then
                MultiViewBackup.ActiveViewIndex = 0
            Else
                MultiViewBackup.ActiveViewIndex = -1
            End If

            'Akses Area Mengetahui Maintenance 
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM MAINTENANCE -- MENGETAHUI'") = 1 And GetFindRecord_Server("SELECT [MAINTENANCE_ID], [MAINTENANCE_NO], [MAINTENANCE_NMPC], [MAINTENANCE_IP], [MAINTENANCE_DEPT], [MAINTENANCE_JADWAL], [MAINTENANCE_REALISASI], [MAINTENANCE_KEGIATAN], [MAINTENANCE_HASIL], [MAINTENANCE_TINDAKAN], [MAINTENANCE_VALIDASISTAFF], [MAINTENANCE_TGLVALIDASISTAFF] FROM [TRXN_MAINTENANCE] WHERE [MAINTENANCE_VALIDASIHEADIT] IS NULL AND [MAINTENANCE_TGLVALIDASIHEADIT] IS NULL AND [MAINTENANCE_REALISASI] IS NOT NULL AND [MAINTENANCE_HASIL] IS NOT NULL AND [MAINTENANCE_TINDAKAN] IS NOT NULL") Then
                MultiViewMaintenance.ActiveViewIndex = 0
            Else
                MultiViewMaintenance.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If

            'Akses Area Validasi Verifikasi Program
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM VERIFIKASI -- VALIDASI'") = 1 And GetFindRecord_Server("SELECT [VERIFIKASI_NO], [VERIFIKASI_JADWAL], [VERIFIKASI_REALISASI], [VERIFIKASI_DEPARTEMEN], [VERIFIKASI_PROGRAM], [VERIFIKASI_HASIL], [VERIFIKASI_KETERANGAN], [VERIFIKASI_VALIDASIUSER], [VERIFIKASI_TGLVALIDASIUSER] FROM [TRXN_VERIFIKASI] WHERE ([VERIFIKASI_VALIDASIUSER2] =  '" & LblUserName.Text & "' AND [VERIFIKASI_VALIDASIUSER] IS NULL AND [VERIFIKASI_TGLVALIDASIUSER] IS NULL)") Then
                MultiViewVerifikasi.ActiveViewIndex = 0
                Call GetData_Validasi("SELECT * FROM divisi WHERE divisi.headdivisi = '" & LblUserName.Text & "'")
            Else
                MultiViewVerifikasi.ActiveViewIndex = -1
            End If

            'Akses Area Approval SDR Diketahui
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SDR -- DIKETAHUI'") = 1 And GetFindRecord_Server("SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_JENIS], [SDRLOG_PERMANEN], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] where ([SDRLOG_KETAHUINAMA] = '" & LblUserName.Text & "' AND [SDRLOG_KETAHUITGL] IS NULL AND [SDRLOG_JENIS] NOT in ('Login Email','Login Sistem'))") Then
                MultiViewDiketahuiSDR.ActiveViewIndex = 0
                Call GetData_Diketahui("SELECT * FROM trxn_sdr WHERE SDRLOG_KETAHUINAMA = '" & LblUserName.Text & "'")
            Else
                MultiViewDiketahuiSDR.ActiveViewIndex = -1
            End If

            'Akses Area Approval SDR Disetujui
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SDR -- DISETUJUI'") = 1 And GetFindRecord_Server("SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_JENIS], [SDRLOG_PERMANEN], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] where [SDRLOG_KETAHUITGL] IS NOT NULL and [SDRLOG_KETAHUINAMA] IS NOT NULL AND [SDRLOG_SETUJUNAMA] IS NULL AND [SDRLOG_SETUJUTGl] IS NULL AND [SDRLOG_JENIS] NOT in ('Login Email','Login Sistem')") Then
                MultiViewDisetujuiSDR.ActiveViewIndex = 0
            Else
                MultiViewDisetujuiSDR.ActiveViewIndex = -1
            End If

            'Akses Area Approval SDR Diuji
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SDR -- DIUJI'") = 1 And GetFindRecord_Server("SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_JENIS], [SDRLOG_TGLCLOSE], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] WHERE ([SDRLOG_PEMOHONNAMA] = '" & LblUserName.Text & "' AND [SDRLOG_KETAHUITGL] IS NOT NULL and [SDRLOG_KETAHUINAMA] IS NOT NULL AND [SDRLOG_SETUJUNAMA] IS NOT NULL AND [SDRLOG_SETUJUTGl] IS NOT NULL AND [SDRLOG_UJINAMA] IS NULL AND [SDRLOG_UJITGL] IS NULL AND [SDRLOG_TGLCLOSE] IS NOT NULL AND [SDRLOG_JENIS] NOT in ('Login Email','Login Sistem'))") Then
                MultiViewDiujiSDR.ActiveViewIndex = 0
            Else
                MultiViewDiujiSDR.ActiveViewIndex = -1
            End If

            'Akses Area Approval Login Diketahui
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM LOGIN -- DIKETAHUI'") = 1 And GetFindRecord_Server("SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_NMUSER], [SDRLOG_JENIS], [SDRLOG_PERMANEN], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] where ([SDRLOG_KETAHUINAMA] = '" & LblUserName.Text & "' AND [SDRLOG_KETAHUITGL] IS NULL AND [SDRLOG_JENIS] in ('Login Email','Login Sistem'))") Then
                MultiViewDiketahuiLogin.ActiveViewIndex = 0
                Call GetData_Diketahui("SELECT * FROM trxn_sdr WHERE SDRLOG_KETAHUINAMA = '" & LblUserName.Text & "'")
            Else
                MultiViewDiketahuiLogin.ActiveViewIndex = -1
            End If

            'Akses Area Approval Login Disetujui
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM LOGIN -- DISETUJUI'") = 1 And GetFindRecord_Server("SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_NMUSER], [SDRLOG_JENIS], [SDRLOG_PERMANEN], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] where [SDRLOG_KETAHUITGL] IS NOT NULL and [SDRLOG_KETAHUINAMA] IS NOT NULL AND [SDRLOG_SETUJUNAMA] IS NULL AND [SDRLOG_SETUJUTGl] IS NULL AND [SDRLOG_JENIS] in ('Login Email','Login Sistem')") Then
                MultiViewDisetujuiLogin.ActiveViewIndex = 0
            Else
                MultiViewDisetujuiLogin.ActiveViewIndex = -1
            End If

            'Akses Area Approval Login Diuji
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM LOGIN -- DIUJI'") = 1 And GetFindRecord_Server("SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_NMUSER], [SDRLOG_JENIS], [SDRLOG_TGLCLOSE], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] WHERE ([SDRLOG_PEMOHONNAMA] = '" & LblUserName.Text & "' AND [SDRLOG_KETAHUITGL] IS NOT NULL and [SDRLOG_KETAHUINAMA] IS NOT NULL AND [SDRLOG_SETUJUNAMA] IS NOT NULL AND [SDRLOG_SETUJUTGl] IS NOT NULL AND [SDRLOG_UJINAMA] IS NULL AND [SDRLOG_UJITGL] IS NULL AND [SDRLOG_TGLCLOSE] IS NOT NULL AND [SDRLOG_JENIS] in ('Login Email','Login Sistem'))") Then
                MultiViewDiujiLogin.ActiveViewIndex = 0
            Else
                MultiViewDiujiLogin.ActiveViewIndex = -1
            End If

            '-------------------------------------------------------------------------
            '|                     Akses Approve Sistem Audit                         |
            '-------------------------------------------------------------------------

            'Akses Area Approval Berita Acara Diketahui 1
            If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM BERITA ACARA -- DIKETAHUI APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE  ([DOKUMEN_DIKETAHUI] = '" & LblUserName.Text & "' AND [DOKUMEN_JENIS]='D' AND [DOKUMEN_TGLDIKETAHUI] IS NULL)") Then
                MultiViewBeritaAcara1.ActiveViewIndex = 0
            Else
                MultiViewBeritaAcara1.ActiveViewIndex = -1
            End If

            'Akses Area Approval Berita Acara Diketahui 2
            If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM BERITA ACARA -- DIKETAHUI2 APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE ([DOKUMEN_DIKETAHUI2] = '" & LblUserName.Text & "' AND [DOKUMEN_JENIS]='D' AND [DOKUMEN_TGLDIKETAHUI2] IS NULL)") Then
                MultiViewBeritaAcara2.ActiveViewIndex = 0
            Else
                MultiViewBeritaAcara2.ActiveViewIndex = -1
            End If

            'Akses Area Approval Berita Acara Disetujui
            If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM BERITA ACARA -- DISETUJUI APPROVAL'") = 1 And GetFindRecord_Server("SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK], [DOKUMEN_DIKETAHUI2], [DOKUMEN_TGLDIKETAHUI2] FROM [TRXN_DOKUMEN] WHERE  [DOKUMEN_JENIS]='D' AND [DOKUMEN_TGLDISETUJUI] IS NULL AND [DOKUMEN_DISETUJUI] IS NULL") Then
                MultiViewBeritaAcara3.ActiveViewIndex = 0
            Else
                MultiViewBeritaAcara3.ActiveViewIndex = -1
            End If

            '-------------------------------------------------------------------------
            '|                   Akses Approve Sistem Warehouse                      |
            '-------------------------------------------------------------------------

            'Akses Area Approval Warehouse Diketahui
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM MINTA UNIT -- DIKETAHUI'") = 1 And GetFindRecord_Server("SELECT [MINTA_NO], [MINTA_JNSEVENT], [MINTA_TGLEVENT], [MINTA_LOKASI], [MINTA_PJ], [MINTA_TGLTERIMA], [MINTA_TGLKEMBALI], [MINTA_TIPE], [MINTA_JENIS], [MINTA_WARNA], [MINTA_RANGKA], [MINTA_MESIN], [MINTA_PEMBUAT], [MINTA_TGLBUAT], [MINTA_DIKETAHUI], [MINTA_TGLDIKETAHUI] FROM [TRXN_PERMINTAAN] WHERE [MINTA_DIKETAHUI] IS NULL AND [MINTA_TGLDIKETAHUI] IS NULL") Then
                MultiViewPermintaan.ActiveViewIndex = 0
            Else
                MultiViewPermintaan.ActiveViewIndex = -1
            End If

            '-------------------------------------------------------------------------
            '|                   Akses Approve Sistem HRD                             |
            '-------------------------------------------------------------------------

            'Akses Area Approval FPTK Diketahui
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM FPTK -- DIKETAHUI'") = 1 And GetFindRecord_Server("SELECT [PTK_ID], [PTK_JABATAN], [PTK_DEPT], [PTK_CABANG], [PTK_PEMOHON] FROM [TRXN_PTK] where [PTK_DIKETAHUI] IS NULL AND [PTK_TGLDIKETAHUI] IS NULL") Then
                MultiViewFPTK1.ActiveViewIndex = 0
            Else
                MultiViewFPTK1.ActiveViewIndex = -1
            End If

            'Akses Area Approval FPTK Disetujui
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM FPTK -- DISETUJUI'") = 1 And GetFindRecord_Server("SELECT [PTK_ID], [PTK_JABATAN], [PTK_DEPT], [PTK_CABANG], [PTK_PEMOHON] FROM [TRXN_PTK] where [PTK_DIKETAHUI] IS NOT NULL AND [PTK_TGLDIKETAHUI] IS NOT NULL AND [PTK_DISETUJUI] IS NULL AND [PTK_TGLDISETUJUI] IS NULL") Then
                MultiViewFPTK2.ActiveViewIndex = 0
            Else
                MultiViewFPTK2.ActiveViewIndex = -1
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
        Call KirimPesan() 'notif email ke bu linda
        LvDetailPanduanMutu.DataBind()
    End Sub

    'Approval dibuat SOP (approval by staff yg memohon)
    Protected Sub LvDetailSOP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailSOP.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailSOP.DataKeys(LvDetailSOP.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_TGLDIBUAT=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesanSOPInfo()
        LvDetailPanduanMutu.DataBind()
    End Sub

	'Approval dibuat SOP
    Protected Sub LvDetailSOP3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailSOP3.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailSOP3.DataKeys(LvDetailSOP3.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_TGLDIBUAT2=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesanSOPInfo()
        LvDetailPanduanMutu.DataBind()
    End Sub

    'Approval diketahui SOP (Approval Bu Linda)
    Protected Sub LvDetailSOP1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailSOP1.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailSOP1.DataKeys(LvDetailSOP1.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI='" & LblUserName.Text & "',DOKUMEN_TGLDIKETAHUI=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesanSOPNotif()
        Call KirimPesanSOPNotif2()
        LvDetailPanduanMutu.DataBind()
    End Sub

    'Approval diketahui SOP (Approval Bu Linda)
    Protected Sub LvDetailSOP4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailSOP4.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailSOP4.DataKeys(LvDetailSOP4.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI='" & LblUserName.Text & "',DOKUMEN_TGLDIKETAHUI=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesanSOPNotif()
        Call KirimPesanSOPNotif2()
        LvDetailPanduanMutu.DataBind()
    End Sub

    Protected Sub LvDetailSOP5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailSOP5.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailSOP5.DataKeys(LvDetailSOP5.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI='" & LblUserName.Text & "',DOKUMEN_TGLDIKETAHUI=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesanSOPNotif()
        Call KirimPesanSOPNotif2()
        LvDetailPanduanMutu.DataBind()
    End Sub


    'Approval disetujui SOP (Approval Pak Santo)
    Protected Sub LvDetailSOP2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailSOP2.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailSOP2.DataKeys(LvDetailSOP2.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_DISETUJUI='" & LblUserName.Text & "',DOKUMEN_TGLDISETUJUI=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesanSOPInfo()
        LvDetailPanduanMutu.DataBind()
    End Sub

    'Approval dibuat Instruksi Kerja (by Tgl Di buat1)
    Protected Sub LvDetailInstruksi1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailInstruksi1.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailInstruksi1.DataKeys(LvDetailInstruksi1.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_TGLDIBUAT=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesanIKInfo()
        LvDetailPanduanMutu.DataBind()
    End Sub

    'Approval dibuat Instruksi Kerja (By Tgl Di Buat2)
    Protected Sub LvDetailInstruksi2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailInstruksi2.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailInstruksi2.DataKeys(LvDetailInstruksi2.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_TGLDIBUAT2=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesanIKInfo()
        LvDetailPanduanMutu.DataBind()
    End Sub
    'Approval diketahui Instruksi Kerja (By Bu Linda)
    Protected Sub LvDetailInstruksi3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailInstruksi3.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailInstruksi3.DataKeys(LvDetailInstruksi3.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI='" & LblUserName.Text & "',DOKUMEN_TGLDIKETAHUI=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesanIKNotif()
        Call KirimPesanIKNotif2()
        LvDetailPanduanMutu.DataBind()
    End Sub

    'Approval disetujui Instruksi Kerja (by Direksi) 
    Protected Sub LvDetailLvDetailInstruksi4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailInstruksi4.SelectedIndexChanged
        Dim lblBackupId As String = (LvDetailInstruksi4.DataKeys(LvDetailInstruksi4.SelectedIndex).Value.ToString)
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_DISETUJUI='" & LblUserName.Text & "',DOKUMEN_TGLDISETUJUI=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesanIKInfo()
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
            'MsgBox(ex.Message)
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

    Function GetData_Validasi(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Validasi = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Validasi = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                Label4.Text = MyRecReadA("headdivisi")
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
	
	 Sub KirimPesanSOPInfo()
        Dim pesan As New MailMessage
        pesan.Subject = "Terdapat Dokumen SOP Yang Telah Disetujui"
        pesan.To.Add("linda@hondamugen.co.id") 'email tujuan
        pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
        pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Ada Dokumen SOP yang sudah disetujui<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Dokumen SOP</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
        pesan.IsBodyHtml = True
        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p") 'isi dengan info akun gmail kalian
        SMTP.Port = "587"
        SMTP.Send(pesan)
    End Sub

    Sub KirimPesanSOPNotif()
        Dim pesan As New MailMessage
        pesan.Subject = "Terdapat Dokumen SOP Yang Membutuhkan Persetujuan Anda"
        pesan.To.Add("santo@hondamugen.co.id") 'email tujuan
        pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
        pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Ada Dokumen SOP yang membutuhkan persetujuan anda <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Dokumen SOP</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
        pesan.IsBodyHtml = True
        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p") 'isi dengan info akun gmail kalian
        SMTP.Port = "587"
        SMTP.Send(pesan)
    End Sub
    Sub KirimPesanSOPNotif2()
        Dim pesan As New MailMessage
        pesan.Subject = "Terdapat Dokumen SOP Yang Membutuhkan Persetujuan Anda"
        pesan.To.Add("susantosoetrisno@yahoo.com") 'email tujuan
        pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
        pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Ada Dokumen SOP yang membutuhkan persetujuan anda <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Dokumen SOP</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
        pesan.IsBodyHtml = True
        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p") 'isi dengan info akun gmail kalian
        SMTP.Port = "587"
        SMTP.Send(pesan)
    End Sub

    Sub KirimPesanIKInfo()
        Dim pesan As New MailMessage
        pesan.Subject = "Terdapat Dokumen Instruksi Kerja Yang Telah Disetujui"
        pesan.To.Add("linda@hondamugen.co.id") 'email tujuan
        pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
        pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Ada Dokumen Instruksi Kerja yang sudah disetujui<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Dokumen Instruksi Kerja</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
        pesan.IsBodyHtml = True
        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p") 'isi dengan info akun gmail kalian
        SMTP.Port = "587"
        SMTP.Send(pesan)
    End Sub

    Sub KirimPesanIKNotif()
        Dim pesan As New MailMessage
        pesan.Subject = "Terdapat Dokumen Instruksi Kerja Yang Membutuhkan Persetujuan Anda"
        pesan.To.Add("santo@hondamugen.co.id") 'email tujuan
        pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
        pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Ada Dokumen Instruksi Kerja yang membutuhkan persetujuan anda <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Dokumen Instruksi Kerja</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
        pesan.IsBodyHtml = True
        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p") 'isi dengan info akun gmail kalian
        SMTP.Port = "587"
        SMTP.Send(pesan)
    End Sub
    Sub KirimPesanIKNotif2()
        Dim pesan As New MailMessage
        pesan.Subject = "Terdapat Dokumen Instruksi Kerja Yang Membutuhkan Persetujuan Anda"
        pesan.To.Add("susantosoetrisno@yahoo.com") 'email tujuan
        pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
        pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Ada Dokumen Instruksi Kerja yang membutuhkan persetujuan anda <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Dokumen Instruksi Kerja</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
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
End Class
