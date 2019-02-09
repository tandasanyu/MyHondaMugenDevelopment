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
            If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM PANDUAN MUTU -- VIEW DATA'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM PANDUAN MUTU -- ADD DATA'") = 1 Then
                    BtnMasterTabel.Visible = True
                Else
                    BtnMasterTabel.Visible = False
                End If
            Else
                MultiViewAkses.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub

    '-------------------------------------------------------------------------
    '|                      Event pada button                                 |
    '--------------------------------------------------------------------------

    'Event ketika menekan tombol tambah data
    Protected Sub BtnMasterTabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMasterTabel.Click
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM PANDUAN MUTU -- VIEW DATA'") = 1 Then
            MultiViewUploadDokumen.ActiveViewIndex = 0
            MultiViewDistribusiDokumen.ActiveViewIndex = -1
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
            Dim filereceived As String = FileUpload1.PostedFile.FileName
            Dim filename As String = Path.GetFileName(filereceived)
            Call UpdateData_Server("INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO,DOKUMEN_NAMA,DOKUMEN_DIKETAHUI,DOKUMEN_TGLDIKETAHUI,DOKUMEN_LINK,DOKUMEN_JENIS, DOKUMEN_DIBUAT, DOKUMEN_TGLDIBUAT) VALUES ('" & lblBackupId.Text & "','" & TxtNamaDokumen.Text & "','" & LblUserName.Text & "','" & Now() & "','" & filename & "', 'A', '" & LblUserName.Text & "','" & Now() & "')")
            Dim fileuploadpath As String = "C:\inetpub\wwwroot\MugenASPHRISO\WEBDOWNLOAD\DOKUMENISO\"
            FileUpload1.PostedFile.SaveAs(Path.Combine(fileuploadpath, filename))
            'Call KirimPesan() : Exit Sub
        End If
        LvDetailMaster.DataBind()
        MultiViewUploadDokumen.ActiveViewIndex = -1
        MultiViewDistribusiDokumen.ActiveViewIndex = -1
    End Sub

    'Event simpan ketika melakukan distribusi terhadap file panduan mutu yang sudah diapprove direksi
    Protected Sub BtnNilaiSM2Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSM2Save.Click
        If GetFindRecord_Server("SELECT * FROM TRXN_DOKUMEND WHERE DOKUMEND_NO='" & lblBackupId.Text & "'") <> 1 Then
            lblBackupId.Text = lblBackupId.Text
            If D1.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D1')")
            End If
            If D2.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D2')")
            End If
            If D3.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D3')")
            End If
            If D4.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D4')")
            End If
            If D5.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D5')")
            End If
            If D6.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D6')")
            End If
            If D7.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D7')")
            End If
            If D8.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D8')")
            End If
            If D9.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D9')")
            End If
            If D10.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D10')")
            End If
            If D11.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D11')")
            End If
            If D12.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D12')")
            End If
            If D13.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D13')")
            End If
            If D14.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D14')")
            End If
            If D15.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D15')")
            End If
            If D16.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D16')")
            End If
            If D17.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D17')")
            End If
            If D18.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D18')")
            End If
            If D19.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D19')")
            End If
            If D20.Checked Then
                Call UpdateData_Server("INSERT INTO TRXN_DOKUMEND (DOKUMEND_NO, DOKUMEND_DISTRIBUSI) VALUES ('" & lblBackupId.Text & "', 'D20')")
            End If
        End If
        LvDetailMaster.DataBind()
        MultiViewUploadDokumen.ActiveViewIndex = -1
        MultiViewDistribusiDokumen.ActiveViewIndex = -1
    End Sub

    'Event ketika menekan tombol distribusi dokumen
    Protected Sub LvDetailMaster_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailMaster.SelectedIndexChanged
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM PANDUAN MUTU -- EDIT DATA'") = 1 Then
            lblBackupId.Text = (LvDetailMaster.DataKeys(LvDetailMaster.SelectedIndex).Value.ToString)
            Call GetData_Master("SELECT * FROM TRXN_DOKUMEN WHERE DOKUMEN_NO='" & lblBackupId.Text & "'")
            MultiViewDistribusiDokumen.ActiveViewIndex = 0
            MultiViewUploadDokumen.ActiveViewIndex = -1
        Else
            Call Msg_err("Tidak boleh melakukan menu ini") : Exit Sub
        End If
    End Sub

    '-------------------------------------------------------------------------
    '|                      Kumpulan Fungsi                                  |
    '--------------------------------------------------------------------------

    'Fungsi untuk melakukan penyimpanan data 
    Function insertData() As String
        insertData = "INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO) VALUES ('" & lblBackupId.Text & "')"
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
                ElseIf nSr(MyRecReadA("JABATAN")) = "Opeational Support Manager" Then
                    lblArea1.Text = "D2"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SM Ps. Minggu" Then
                    lblArea1.Text = "D3"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SM Puri" Then
                    lblArea1.Text = "D4"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Service Manager Ps. Minggu" Then
                    lblArea1.Text = "D5"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Service Manager Puri" Then
                    lblArea1.Text = "D6"
                ElseIf nSr(MyRecReadA("JABATAN")) = "HRD & GA Head" Then
                    lblArea1.Text = "D7"
                ElseIf nSr(MyRecReadA("JABATAN")) = "GA Puri" Then
                    lblArea1.Text = "D8"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Ka. Sparepart Ps. Minggu" Then
                    lblArea1.Text = "D9"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Ka. Sparepart Puri" Then
                    lblArea1.Text = "D10"
                ElseIf nSr(MyRecReadA("JABATAN")) = "QMR" Then
                    lblArea1.Text = "D11"
                ElseIf nSr(MyRecReadA("JABATAN")) = "ADH Ps. Minggu" Then
                    lblArea1.Text = "D12"
                ElseIf nSr(MyRecReadA("JABATAN")) = "ADH Puri" Then
                    lblArea1.Text = "D13"
                ElseIf nSr(MyRecReadA("JABATAN")) = "CC SPV" Then
                    lblArea1.Text = "D14"
                ElseIf nSr(MyRecReadA("JABATAN")) = "CC Puri" Then
                    lblArea1.Text = "D15"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Internal Auditor" Then
                    lblArea1.Text = "D16"
                ElseIf nSr(MyRecReadA("JABATAN")) = "WH Coordinator" Then
                    lblArea1.Text = "D17"
                ElseIf nSr(MyRecReadA("JABATAN")) = "IT HEAD" Then
                    lblArea1.Text = "D18"
                ElseIf nSr(MyRecReadA("JABATAN")) = "IT Puri" Then
                    lblArea1.Text = "D19"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Purchasing" Then
                    lblArea1.Text = "D20"
                End If
            End While
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
ErrHand:
    End Function



    Sub ClearPermintaan()
        lblBackupId.Text = ""

        TxtNamaDokumen.Text = ""

    End Sub

    'Sub KirimPesan()
    'Dim pesan As New MailMessage
    'pesan.Subject = "Terdapat Dokumen Panduan Mutu Baru Yang Membutuhkan Persetujuan Anda"
    'pesan.To.Add("komang@hondamugen.co.id") 'email tujuan
    'pesan.From = New MailAddress("komanganom@gmail.com") 'email kalian
    'pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda memiliki sebuah permintaan persetujuan untuk Dokumen Panduan Mutu <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://192.168.0.9:8080/default.aspx?goto=approvemintabeli.aspx?q=approvaldivisi' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Daftar Approval</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
    'pesan.IsBodyHtml = True
    'Dim SMTP As New SmtpClient("smtp.gmail.com")
    'SMTP.EnableSsl = True
    'SMTP.Credentials = New System.Net.NetworkCredential("komanganom@gmail.com", "abuserin") 'isi dengan info akun gmail kalian
    'SMTP.Port = "587"
    'SMTP.Send(pesan)
    'End Sub

End Class
