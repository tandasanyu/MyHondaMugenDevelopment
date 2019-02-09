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
'Kode 104
'1 Cari
'2 Hapus dan Tambah Aksesoris
Partial Class SALES_Form0104PANDUANMUTU
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
            If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM PANDUAN MUTU -- EDIT DATA'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0
                LvDetailMaster.DataBind()
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM PANDUAN MUTU -- ADD DATA'") = 1 Then
                    Call ActiveButton()
                Else
                    Call DisableButton()
                End If
            ElseIf GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM PANDUAN MUTU -- VIEW DATA'") = 1 Then
                MultiViewPanduan.ActiveViewIndex = 0
                Call DisableButton()
            Else
                MultiViewUploadDokumen.ActiveViewIndex = -1
                MultiViewAkses.ActiveViewIndex = -1
                MultiViewDistribusiDokumen.ActiveViewIndex = -1
                MultiViewEditPanduanMutu.ActiveViewIndex = -1
                MultiViewFormEditDokumen.ActiveViewIndex = -1
                MultiViewObsolete.ActiveViewIndex = -1
                Call DisableButton()
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub

    '-------------------------------------------------------------------------
    '|                      Event pada button                                 |
    '--------------------------------------------------------------------------

    'Event ketika menekan tombol tambah data
    Protected Sub BtnMasterTabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMasterTabel.Click
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM PANDUAN MUTU -- ADD DATA'") = 1 Then
            LvDetailMaster.DataBind()
            MultiViewUploadDokumen.ActiveViewIndex = 0
            MultiViewAkses.ActiveViewIndex = -1
            MultiViewDistribusiDokumen.ActiveViewIndex = -1
            MultiViewEditPanduanMutu.ActiveViewIndex = -1
            MultiViewFormEditDokumen.ActiveViewIndex = -1
            MultiViewObsolete.ActiveViewIndex = -1
            Call ClearPermintaan()
            If lblBackupId.Text = "" Then
                lblBackupId.Text = GetData_SearchNomor()
            End If
        Else
            Call Msg_err("Tidak boleh melakukan menu ini") : Exit Sub
        End If
    End Sub

    'Event simpan ketika upload dokumen panduan mutu baru
    Protected Sub BtnNilaiSMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave.Click
        If GetFindRecord_Server("SELECT * FROM TRXN_DOKUMEN WHERE DOKUMEN_NO='" & lblBackupId.Text & "'") <> 1 Then
            lblBackupId.Text = lblBackupId.Text
            If status.Text = " Baru" Then
                Dim filereceived As String = FileUpload1.PostedFile.FileName
                Dim filename As String = Path.GetFileName(filereceived)
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT, DOKUMEN_STATUS) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'A', '" & LblUserName.Text & "','" & Now() & "',1)")
                Dim fileuploadpath As String = "C:\inetpub\wwwroot\MugenASPHRISO\WEBDOWNLOAD\DOKUMENISO\"
                FileUpload1.PostedFile.SaveAs(Path.Combine(fileuploadpath, filename))
                Call KirimPesan()
                LvDetailMaster.DataBind()
                MultiViewUploadDokumen.ActiveViewIndex = -1
                MultiViewAkses.ActiveViewIndex = 0
                MultiViewDistribusiDokumen.ActiveViewIndex = -1
                MultiViewEditPanduanMutu.ActiveViewIndex = -1
                MultiViewFormEditDokumen.ActiveViewIndex = -1
                MultiViewObsolete.ActiveViewIndex = -1
            ElseIf status.Text = " Obsolete Dokumen" Then
                Dim filereceived As String = FileUpload1.PostedFile.FileName
                Dim filename As String = Path.GetFileName(filereceived)
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMENO (DOKUMENO_NAMA,DOKUMENO_TGLTIDAKBERLAKU,DOKUMENO_LINK,DOKUMENO_DIBUAT, DOKUMENO_KETERANGAN) VALUES ('" & TxtNamaDokumen.Text & "','" & Now() & "','" & filename & "', '" & LblUserName.Text & "','" & TxtKeterangan.Text & "')")
                Dim fileuploadpath As String = "C:\inetpub\wwwroot\MugenASPHRISO\WEBDOWNLOAD\DOKUMENISO\"
                FileUpload1.PostedFile.SaveAs(Path.Combine(fileuploadpath, filename))
                ListObsolete.DataBind()
                MultiViewUploadDokumen.ActiveViewIndex = -1
                MultiViewAkses.ActiveViewIndex = -1
                MultiViewDistribusiDokumen.ActiveViewIndex = -1
                MultiViewEditPanduanMutu.ActiveViewIndex = -1
                MultiViewFormEditDokumen.ActiveViewIndex = -1
                MultiViewObsolete.ActiveViewIndex = 0
            End If

        End If
    End Sub

    'Event simpan ketika upload dokumen panduan mutu baru
    Protected Sub BtnNilaiSMSave3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSM3Save.Click
        If GetFindRecord_Server("SELECT * FROM TRXN_DOKUMEN WHERE DOKUMEN_NO='" & lblBackupId.Text & "'") = 1 Then
            lblBackupId.Text = lblBackupId.Text
            Dim filereceived As String = FileUpload2.PostedFile.FileName
            Dim filename As String = Path.GetFileName(filereceived)
            Call UpdateData_Server("DELETE FROM TRXN_DOKUMEND WHERE DOKUMEND_NO = '" & lblBackupId.Text & "'")
            Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET " & _
               "DOKUMEN_TGLDIKETAHUI='" & Now() & "'," & _
               "DOKUMEN_TGLDIBUAT='" & Now() & "'," & _
               "DOKUMEN_DISETUJUI=''," & _
               "DOKUMEN_TGLDISETUJUI=''," & _
               "DOKUMEN_KETERANGAN='" & lblKeterangan.Text & "'," & _
               "DOKUMEN_TGLDIBUATPERTAMA='" & tglAwal.Text & "'," & _
               "DOKUMEN_LINK='" & filename & "'," & _
               "DOKUMEN_LINKOBSOLETE='" & dokumenAwal.Text & "'" & _
               "WHERE DOKUMEN_NO ='" & lblBackupId.Text & "'")
            Dim fileuploadpath As String = "C:\inetpub\wwwroot\MugenASPHRISO\WEBDOWNLOAD\DOKUMENISO\"
            FileUpload2.PostedFile.SaveAs(Path.Combine(fileuploadpath, filename))
            Call KirimPesan()
        End If
        LvEdit.DataBind()
        MultiViewUploadDokumen.ActiveViewIndex = -1
        MultiViewAkses.ActiveViewIndex = -1
        MultiViewDistribusiDokumen.ActiveViewIndex = -1
        MultiViewEditPanduanMutu.ActiveViewIndex = 0
        MultiViewFormEditDokumen.ActiveViewIndex = -1
        MultiViewObsolete.ActiveViewIndex = -1
    End Sub

    'Event simpan ketika melakukan distribusi terhadap file panduan mutu yang sudah diapprove direksi
    Protected Sub BtnNilaiSM2Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSM2Save.Click
        If GetFindRecord_Server("SELECT * FROM TRXN_DOKUMEND WHERE DOKUMEND_NO='" & lblBackupId.Text & "'") = 1 Then
            lblBackupId.Text = lblBackupId.Text
            Call UpdateData_Server("DELETE FROM TRXN_DOKUMEND WHERE DOKUMEND_NO = '" & lblBackupId.Text & "'")
            If D1.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D1')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Direksi'")
            End If
            If D2.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D2')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Operational Support Manager'")
            End If
            If D3.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D3')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'SM Ps. Minggu'")
            End If
            If D4.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D4')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'SM Puri'")
            End If
            If D5.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D5')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Service Manager Ps. Minggu'")
            End If
            If D6.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D6')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Service Manager Puri'")
            End If
            If D7.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D7')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Internal Auditor'")
            End If
            If D8.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D8')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'WH Coordinator'")
            End If
            If D9.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D9')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Ka. Sparepart Ps. Minggu'")
            End If
            If D10.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D10')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Ka. Sparepart Puri'")
            End If
            If D11.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D11')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'SPV Sales Ps. Minggu'")
            End If
            If D12.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D12')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'SPV Sales Puri'")
            End If
            If D13.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D13')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'QMR'")
            End If
            If D14.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D14')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'ADH Ps. Minggu'")
            End If
            If D15.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D15')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'ADH Puri'")
            End If
            If D16.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D16')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'CC SPV'")
            End If
            If D17.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D17')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'CC Puri'")
            End If
            If D18.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D18')")
                Call emaildistribusi_server("select * from tb_user where jabatan = 'HRD & GA Head'")
            End If
            If D19.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D19')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'GA Puri'")
            End If
            If D20.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D20')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'SPV HRD'")
            End If
            If D21.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D21')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'SPV GA'")
            End If
            If D22.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D22')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'IT Head'")
            End If
            If D23.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D23')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'IT Puri'")
            End If
            If D24.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D24')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Purchasing'")
            End If
        ElseIf GetFindRecord_Server("SELECT * FROM TRXN_DOKUMEND WHERE DOKUMEND_NO='" & lblBackupId.Text & "'") <> 1 Then
            lblBackupId.Text = lblBackupId.Text
            Call UpdateData_Server("DELETE FROM TRXN_DOKUMEND WHERE DOKUMEND_NO = '" & lblBackupId.Text & "'")
            If D1.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D1')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Direksi'")
            End If
            If D2.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D2')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Operational Support Manager'")
            End If
            If D3.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D3')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'SM Ps. Minggu'")
            End If
            If D4.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D4')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'SM Puri'")
            End If
            If D5.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D5')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Service Manager Ps. Minggu'")
            End If
            If D6.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D6')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Service Manager Puri'")
            End If
            If D7.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D7')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Internal Auditor'")
            End If
            If D8.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D8')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'WH Coordinator'")
            End If
            If D9.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D9')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Ka. Sparepart Ps. Minggu'")
            End If
            If D10.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D10')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Ka. Sparepart Puri'")
            End If
            If D11.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D11')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'SPV Sales Ps. Minggu'")
            End If
            If D12.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D12')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'SPV Sales Puri'")
            End If
            If D13.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D13')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'QMR'")
            End If
            If D14.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D14')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'ADH Ps. Minggu'")
            End If
            If D15.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D15')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'ADH Puri'")
            End If
            If D16.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D16')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'CC SPV'")
            End If
            If D17.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D17')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'CC Puri'")
            End If
            If D18.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D18')")
                Call emaildistribusi_server("select * from tb_user where jabatan = 'HRD & GA Head'")
            End If
            If D19.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D19')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'GA Puri'")
            End If
            If D20.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D20')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'SPV HRD'")
            End If
            If D21.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D21')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'SPV GA'")
            End If
            If D22.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D22')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'IT Head'")
            End If
            If D23.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D23')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'IT Puri'")
            End If
            If D24.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D24')")
                Call emaildistribusi_server("select * from tb_user where jabatan= 'Purchasing'")
            End If
        End If
        LvDetailMaster.DataBind()
        MultiViewUploadDokumen.ActiveViewIndex = -1
        MultiViewAkses.ActiveViewIndex = 0
        MultiViewDistribusiDokumen.ActiveViewIndex = -1
        MultiViewEditPanduanMutu.ActiveViewIndex = -1
        MultiViewFormEditDokumen.ActiveViewIndex = -1
        MultiViewObsolete.ActiveViewIndex = -1
    End Sub

    'Event ketika menekan tombol distribusi dokumen
    Protected Sub LvDetailMaster_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailMaster.SelectedIndexChanged
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM PANDUAN MUTU -- EDIT DATA'") = 1 Then
            lblBackupId.Text = (LvDetailMaster.DataKeys(LvDetailMaster.SelectedIndex).Value.ToString)
            If CountData_Master("SELECT * FROM TRXN_DOKUMEN WHERE DOKUMEN_NO='" & lblBackupId.Text & "' AND DOKUMEN_DISETUJUI IS NULL OR DOKUMEN_DISETUJUI=''") = 1 Then
                'LvDetailMaster.Enabled = False
                'Call Msg_err("Dokumen Belum Disetujui Direksi") : Exit Sub
                Response.Write("<script>alert('Dokumen Panduan Mutu Belum Disetujui Direksi!')</script>") : Exit Sub
            Else
                Call ClearDistribusi()
                If CountData_Master("SELECT * FROM TRXN_DOKUMEND WHERE DOKUMEND_NO='" & lblBackupId.Text & "'") = 1 Then
                    Call GetData_Master("SELECT * FROM TRXN_DOKUMEN WHERE DOKUMEN_NO='" & lblBackupId.Text & "'")
                    Call GetData_Master2("SELECT * FROM TRXN_DOKUMEND WHERE DOKUMEND_NO='" & lblBackupId.Text & "'")
                Else
                    Call GetData_Master("SELECT * FROM TRXN_DOKUMEN WHERE DOKUMEN_NO='" & lblBackupId.Text & "'")
                End If
                MultiViewUploadDokumen.ActiveViewIndex = -1
                MultiViewAkses.ActiveViewIndex = -1
                MultiViewDistribusiDokumen.ActiveViewIndex = 0
                MultiViewEditPanduanMutu.ActiveViewIndex = -1
                MultiViewFormEditDokumen.ActiveViewIndex = -1
                MultiViewObsolete.ActiveViewIndex = -1

            End If
        Else
            Call Msg_err("Tidak boleh melakukan menu ini") : Exit Sub
        End If
    End Sub

    'Event ketika menekan tombol edit dokumen
    Protected Sub LvEdit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvEdit.SelectedIndexChanged
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM PANDUAN MUTU -- EDIT DATA'") = 1 Then
            lblBackupId.Text = (LvEdit.DataKeys(LvEdit.SelectedIndex).Value.ToString)
            Call GetData_Edit("SELECT * FROM TRXN_DOKUMEN WHERE DOKUMEN_NO='" & lblBackupId.Text & "'")
            MultiViewUploadDokumen.ActiveViewIndex = -1
            MultiViewAkses.ActiveViewIndex = -1
            MultiViewDistribusiDokumen.ActiveViewIndex = -1
            MultiViewEditPanduanMutu.ActiveViewIndex = -1
            MultiViewFormEditDokumen.ActiveViewIndex = 0
            MultiViewObsolete.ActiveViewIndex = -1
        Else
            Call Msg_err("Tidak boleh melakukan menu ini") : Exit Sub
        End If
    End Sub

    Protected Sub BtnMasterUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMasterUpdate.Click
        LvEdit.DataBind()
        MultiViewUploadDokumen.ActiveViewIndex = -1
        MultiViewAkses.ActiveViewIndex = -1
        MultiViewDistribusiDokumen.ActiveViewIndex = -1
        MultiViewEditPanduanMutu.ActiveViewIndex = 0
        MultiViewFormEditDokumen.ActiveViewIndex = -1
        MultiViewObsolete.ActiveViewIndex = -1
    End Sub

    Protected Sub BtnMasterObsolete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMasterObsolete.Click
        MultiViewUploadDokumen.ActiveViewIndex = -1
        MultiViewAkses.ActiveViewIndex = -1
        MultiViewDistribusiDokumen.ActiveViewIndex = -1
        MultiViewEditPanduanMutu.ActiveViewIndex = -1
        MultiViewFormEditDokumen.ActiveViewIndex = -1
        MultiViewObsolete.ActiveViewIndex = 0
        ListObsolete.DataBind()
    End Sub

    Protected Sub BtnMasterPanduan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMasterPanduan.Click
        MultiViewUploadDokumen.ActiveViewIndex = -1
        MultiViewAkses.ActiveViewIndex = 0
        MultiViewDistribusiDokumen.ActiveViewIndex = -1
        MultiViewEditPanduanMutu.ActiveViewIndex = -1
        MultiViewFormEditDokumen.ActiveViewIndex = -1
        MultiViewObsolete.ActiveViewIndex = -1
    End Sub

    Protected Sub BtnNilaiSMBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMBack.Click
        MultiViewUploadDokumen.ActiveViewIndex = -1
        MultiViewAkses.ActiveViewIndex = 0
        MultiViewDistribusiDokumen.ActiveViewIndex = -1
        MultiViewEditPanduanMutu.ActiveViewIndex = -1
        MultiViewFormEditDokumen.ActiveViewIndex = -1
        MultiViewObsolete.ActiveViewIndex = -1
    End Sub

    Protected Sub BtnNilaiSM3Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSM3Back.Click
        LvEdit.DataBind()
        MultiViewUploadDokumen.ActiveViewIndex = -1
        MultiViewAkses.ActiveViewIndex = -1
        MultiViewDistribusiDokumen.ActiveViewIndex = -1
        MultiViewEditPanduanMutu.ActiveViewIndex = 0
        MultiViewFormEditDokumen.ActiveViewIndex = -1
        MultiViewObsolete.ActiveViewIndex = -1
    End Sub

    '-------------------------------------------------------------------------
    '|                      Kumpulan Fungsi                                  |
    '--------------------------------------------------------------------------

    'Fungsi untuk melakukan penyimpanan data 
    Function insertData() As String
        insertData = "INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO) VALUES ('" & lblBackupId.Text & "')"
    End Function

    Protected Sub statusganti(sender As Object, e As EventArgs)
        If status.Text = " Baru" Then
            obsolete.Attributes("style") = "display:none"
        Else
            obsolete.Attributes("style") = "display:block"
        End If
    End Sub

    Function GetData_AddNomor(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_AddNomor = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtNamaDokumen.Text = nSr(MyRecReadA("DOKUMEN_NAMA"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_Nomor() As String
        GetData_Nomor = GetData_SearchNomor()
        If GetData_Nomor <> "" Then
            If GetData_Nomor = "NO FOUND" Then
                GetData_Nomor = GetData_StartNomor()
            End If
        End If
        If GetData_Nomor = "" Then
            Call Msg_err("DATA TIDAK BERHASIL DISIMPAN")
        End If
    End Function

    Function GetData_SearchNomor() As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String

        Call Msg_err("")
        GetData_SearchNomor = ""
        Dim mTahun As String = Format(Now(), "yyyy")
        Dim mBulan As String = Format(Now(), "MM")
        mSqlCommadstring = "SELECT COUNT(DOKUMEN_TGLDIBUAT) as maxPemohon from trxn_DOKUMEN where DATEPART(month, DOKUMEN_TGLDIBUAT) = '" + mBulan + "' AND DATEPART(year, DOKUMEN_TGLDIBUAT) = '" + mTahun + "'"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            mFind = IIf(MyRecReadA.HasRows = True, 1, 0)
            If mFind = 0 Then
                GetData_SearchNomor = "NO FOUND"
            Else
                MyRecReadA.Read()
                If nSr(MyRecReadA("maxPemohon")) = "" Then
                    GetData_SearchNomor = "NO FOUND"
                Else
                    GetData_SearchNomor = Val(nSr(MyRecReadA("maxPemohon"))) + 1
                    GetData_SearchNomor = mTahun & mBulan & GetData_SearchNomor
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function
    Function GetData_StartNomor() As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String

        Call Msg_err("")
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
                GetData_StartNomor = lblArea1.Text & _
                                     Format((MyRecReadA("mCurrDate")), "yyMM") & _
                                     "0001"
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function CountData_Master(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        CountData_Master = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                CountData_Master = 1
            Else
                CountData_Master = 0
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_Master(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Master = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                lblDokumenId.Text = nSr(MyRecReadA("DOKUMEN_NO"))
                NmDokumen.Text = nSr(MyRecReadA("DOKUMEN_NAMA"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_Master2(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Master2 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Master2 = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D1" Then
                    D1.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D2" Then
                    D2.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D2" Then
                    D2.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D3" Then
                    D3.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D4" Then
                    D4.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D5" Then
                    D5.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D6" Then
                    D6.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D7" Then
                    D7.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D8" Then
                    D8.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D9" Then
                    D9.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D10" Then
                    D10.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D11" Then
                    D11.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D12" Then
                    D12.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D13" Then
                    D13.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D14" Then
                    D14.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D15" Then
                    D15.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D16" Then
                    D16.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D17" Then
                    D17.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D18" Then
                    D18.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D19" Then
                    D19.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D20" Then
                    D20.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D21" Then
                    D21.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D22" Then
                    D22.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D23" Then
                    D23.Checked = True
                End If
                If nSr(MyRecReadA("DOKUMEND_DISTRIBUSI")) = "D24" Then
                    D24.Checked = True
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function
    Function GetData_Edit(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Edit = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                lblID.Text = nSr(MyRecReadA("DOKUMEN_NO"))
                lblNama.Text = nSr(MyRecReadA("DOKUMEN_NAMA"))
                dokumenAwal.Text = nSr(MyRecReadA("DOKUMEN_LINK"))
                tglAwal.Text = nSr(MyRecReadA("DOKUMEN_TGLDIBUAT"))
                lblKeterangan.Text = ""
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
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

    Function emaildistribusi_server(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        emaildistribusi_server = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            emaildistribusi_server = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                Dim email As String = nSr(MyRecReadA("email"))
                Dim pesan As New MailMessage
                pesan.Subject = "Terdapat Distribusi Dokumen Panduan Mutu Untuk Anda"
                pesan.To.Add(email) 'email tujuan
                pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
                pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda mendapat Distribusi Dokumen Panduan Mutu, silahkan di cek <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Dokumen</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
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
ErrHand:
    End Function

    Sub DisableButton()
        BtnMasterTabel.Visible = False
        BtnMasterPanduan.Visible = False
        BtnMasterObsolete.Visible = False
        BtnMasterUpdate.Visible = False
    End Sub

    Sub ActiveButton()
        BtnMasterTabel.Visible = True
        BtnMasterPanduan.Visible = True
        BtnMasterObsolete.Visible = True
        BtnMasterUpdate.Visible = True
    End Sub
    Sub ClearPermintaan()
        lblBackupId.Text = ""
        TxtNamaDokumen.Text = ""
    End Sub


    Sub ClearDistribusi()
        D1.Checked = False
        D2.Checked = False
        D3.Checked = False
        D4.Checked = False
        D5.Checked = False
        D6.Checked = False
        D7.Checked = False
        D8.Checked = False
        D9.Checked = False
        D10.Checked = False
        D11.Checked = False
        D12.Checked = False
        D13.Checked = False
        D14.Checked = False
        D15.Checked = False
        D16.Checked = False
        D17.Checked = False
        D18.Checked = False
        D19.Checked = False
        D20.Checked = False
        D21.Checked = False
        D22.Checked = False
        D23.Checked = False
        D24.Checked = False
    End Sub

    Sub KirimPesan()
        Dim pesan As New MailMessage
        pesan.Subject = "Terdapat Dokumen Panduan Mutu Baru Yang Membutuhkan Persetujuan Anda"
        pesan.To.Add("santo@hondamugen.co.id") 'email tujuan
        pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
        pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda memiliki sebuah permintaan persetujuan untuk Dokumen Panduan Mutu <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Daftar Approval</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
        pesan.IsBodyHtml = True
        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p") 'isi dengan info akun gmail kalian
        SMTP.Port = "587"
        SMTP.Send(pesan)
    End Sub

End Class
