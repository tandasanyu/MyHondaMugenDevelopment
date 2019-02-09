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
Partial Class SALES_Form0104FORM
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
            If GetData_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='HR' AND AKSES_MENU='ISOA'") = 1 Then
                ' If GetData_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='HR' AND AKSES_MENU='MISI'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0
            Else
                MultiViewAkses.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub

    Protected Sub LvDetailMaster_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailMaster.SelectedIndexChanged
        'fungsi untuk menampilkan data dari pilihan yang dipilih
        If Mid(lblAkses.Text, 1, 1) = "1" Then
            lblBackupId.Text = (LvDetailMaster.DataKeys(LvDetailMaster.SelectedIndex).Value.ToString)
            'memanggil fungsi add nomor berdasarkan id
            Call GetData_AddNomor("SELECT * FROM TRXN_DOKUMEN WHERE DOKUMEN_NO='" & lblBackupId.Text & "'")
            MultiViewNilaiProgressEntry.ActiveViewIndex = 0
            'Call DetailMasterOn()
        Else
            Call Msg_err("Tidak boleh melakukan menu ini") : Exit Sub
        End If

    End Sub
    Protected Sub BtnNilaiSMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave.Click

        'fungsi simpan data

        If GetFindRecord_Server("SELECT * FROM TRXN_DOKUMEN WHERE DOKUMEN_NO='" & lblBackupId.Text & "'") <> 1 Then

            lblBackupId.Text = lblBackupId.Text
            Dim filereceived As String = FileUpload1.PostedFile.FileName
            Dim filename As String = Path.GetFileName(filereceived)

            If D1.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D1','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D2.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D2','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D3.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D3','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D4.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D4','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D5.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D5','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D6.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D6','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D7.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D7','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D8.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D8','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D9.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D9','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D10.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D10','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D11.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D11','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D12.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D12','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D13.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D13','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D14.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D14','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D15.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D15','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D16.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D16','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D17.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D17','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D18.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D18','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D19.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D19','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D20.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D20','" & LblUserName.Text & "','" & Now() & "')")
            End If

            Dim fileuploadpath As String = "C:\Users\mugen\Documents\Visual Studio 2015\WebSites\MugenOTHERSnEW\WEBDOWNLOAD\DOKUMENISO\"
            FileUpload1.PostedFile.SaveAs(Path.Combine(fileuploadpath, filename))

        Else
            lblBackupId.Text = lblBackupId.Text
            Call UpdateData_Server("DELETE FROM TRXN_DOKUMEN WHERE DOKUMEN_NO ='" & lblBackupId.Text & "'")
            Dim filereceived As String = FileUpload1.PostedFile.FileName
            Dim filename As String = Path.GetFileName(filereceived)

            If D1.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D1','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D2.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D2','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D3.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D3','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D4.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D4','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D5.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D5','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D6.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D6','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D7.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D7','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D8.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D8','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D9.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D9','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D10.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D10','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D11.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D11','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D12.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D12','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D13.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D13','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D14.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D14','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D15.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D15','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D16.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D16','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D17.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D17','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D18.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D18','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D19.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D19','" & LblUserName.Text & "','" & Now() & "')")
            End If
            If D20.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS,DOKUMEN_DISTRIBUSI, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'D', 'D20','" & LblUserName.Text & "','" & Now() & "')")
            End If

            Dim fileuploadpath As String = "C:\Users\mugen\Documents\Visual Studio 2015\WebSites\MugenOTHERSnEW\WEBDOWNLOAD\DOKUMENISO\"
            FileUpload1.PostedFile.SaveAs(Path.Combine(fileuploadpath, filename))
        End If



        LvDetailMaster.DataBind()
        MultiViewNilaiProgressEntry.ActiveViewIndex = -1
    End Sub

    Function insertData() As String
        insertData = "INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO) VALUES ('" & lblBackupId.Text & "')"
    End Function

    Function EDITData() As String
        '                        "SDRLOG_JENIS='" & DropDownList2.Text& "'," & _
        Dim filereceived As String = FileUpload1.PostedFile.FileName
        Dim filename As String = Path.GetFileName(filereceived)
        EDITData = "UPDATE TRXN_DOKUMEN SET " & _
                                "DOKUMEN_NAMA='" & TxtNamaDokumen.Text & "'," & _
                                "DOKUMEN_DIKETAHUI='" & LblUserName.Text & "'," & _
                                "DOKUMEN_TGLDIKETAHUI='" & Now() & "'," & _
                                "DOKUMEN_LINK='" & filename & "'," & _
                                "DOKUMEN_JENIS='D'" & _
                                "WHERE DOKUMEN_NO='" & lblBackupId.Text & "'"
        '"SDRLOG_NO ='" & nSr(MyRecReadA("SDRLOG_NO")) & "'"
        Dim fileuploadpath As String = "C:\Users\mugen\Documents\Visual Studio 2015\WebSites\MugenOTHERSnEW\WEBDOWNLOAD\DOKUMENISO\"
        FileUpload1.PostedFile.SaveAs(Path.Combine(fileuploadpath, filename))
    End Function


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

                'lblSDRId.Text = nSr(MyRecReadA("SDRLOG_TARGETR1"))
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

        'mSqlCommadstring = "SELECT NOMOR FROM TRXN_SPKAH WHERE CABANG='" & lblDealer.Text & "' AND NOT(NOMOR IS NULL OR NOMOR='') AND MONTH(TANGGAL_ENTRY)=MONTH(GETDATE()) AND YEAR(TANGGAL_ENTRY)=YEAR(GETDATE()) ORDER BY NOMOR DESC"
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
                lblBackupId.Text = nSr(MyRecReadA("DOKUMEN_NO"))
                TxtNamaDokumen.Text = nSr(MyRecReadA("DOKUMEN_NAMA"))
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
                lblAkses.Text = nSr(MyRecReadA("AKSES_DATA"))
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
        'MsgBox(DtFrSQL)
ErrHand:
    End Function


    Protected Sub BtnMasterTabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMasterTabel.Click
        If Mid(lblAkses.Text, 1, 1) = "1" Then
            MultiViewNilaiProgressEntry.ActiveViewIndex = 0
            Call ClearPermintaan()
            If lblBackupId.Text = "" Then
                lblBackupId.Text = GetData_SearchNomor()


            End If
        Else
            Call Msg_err("Tidak boleh melakukan menu ini") : Exit Sub
        End If
    End Sub
    Sub ClearPermintaan()
        lblBackupId.Text = ""

        TxtNamaDokumen.Text = ""

    End Sub

    '  Protected Sub BtnNilaiSMSave0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave0.Click
    '  Dim mSqlTxt As String = "UPDATE TRXN_SDR SET SDRLOG_PEMOHONNAMA='" & TxtSDRPemohon.Text & "',SDRLOG_PEMOHONTGL=GETDATE()  WHERE SDRLOG_NO='" & lblSDRId.Text & "'"
    '   If TxtSDRPemohon.Text = "" Then
    '  mSqlTxt = "UPDATE TRXN_SDR SET SDRLOG_PEMOHONNAMA='" & TxtSDRPemohon.Text & "',SDRLOG_PEMOHONTGL=NULL  WHERE SDRLOG_NO='" & lblSDRId.Text & "'"
    'End If

    'End Sub

    Protected Sub BtnNilaiSMSave2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave2.Click
        Dim mSqlTxt As String = "UPDATE TRXN_DOKUMEN SET DOKUMEN_DISETUJUI='" & LblUserName.Text & "',DOKUMEN_TGLDISETUJUI=GETDATE() WHERE DOKUMEN_NO='" & lblBackupId.Text & "'"
        Call UpdateData_Server(mSqlTxt)

        LvDetailMaster.DataBind()
        MultiViewNilaiProgressEntry.ActiveViewIndex = -1
    End Sub

End Class
