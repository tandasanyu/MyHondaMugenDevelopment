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
Partial Class AUDITBERITAACARA
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
            If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM BERITA ACARA -- ADD+EDIT DATA'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0
                MultiViewData.ActiveViewIndex = -1
                MultiViewData2.ActiveViewIndex = -1
                LvDetailMaster.DataBind()
                BtnMasterTabel.Visible = True
            ElseIf GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM BERITA ACARA -- VIEW SEMUA DATA'") = 1 Then
                MultiViewData.ActiveViewIndex = -1
                MultiViewAkses.ActiveViewIndex = -1
                MultiViewData2.ActiveViewIndex = 0
                BtnMasterTabel.Visible = False
                LvDetailData.DataBind()
            ElseIf GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM BERITA ACARA -- VIEW DATA'") = 1 Then
                MultiViewData.ActiveViewIndex = 0
                MultiViewAkses.ActiveViewIndex = -1
                MultiViewData2.ActiveViewIndex = -1
                BtnMasterTabel.Visible = False
                LvDetailData.DataBind()
            Else
                MultiViewUploadDokumen.ActiveViewIndex = -1
                MultiViewData.ActiveViewIndex = -1
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
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM BERITA ACARA -- ADD+EDIT DATA'") = 1 Then
            LvDetailMaster.DataBind()
            MultiViewUploadDokumen.ActiveViewIndex = 0
            MultiViewAkses.ActiveViewIndex = -1
            MultiViewData.ActiveViewIndex = -1
            BtnMasterTabel.Visible = False
            Call ClearPermintaan()
            If lblBeritaAcaraId.Text = "" Then
                lblBeritaAcaraId.Text = GetData_SearchNomor()
            End If
        Else
            Call Msg_err("Tidak boleh melakukan menu ini") : Exit Sub
        End If
    End Sub

    'Event simpan ketika upload dokumen panduan mutu baru
    Protected Sub BtnNilaiSMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave.Click
        If lblBeritaAcaraId.Text = "" Then
            lblBeritaAcaraId.Text = lblBeritaAcaraId.Text
            UpdateData_Server(insertData)
        Else
            If GetFindRecord_Server("SELECT * FROM TRXN_DOKUMEN WHERE DOKUMEN_NO='" & lblBeritaAcaraId.Text & "'") <> 1 Then
                If UpdateData_Server(insertData) = 1 Then
                    lblBeritaAcaraId.Text = lblBeritaAcaraId.Text
                End If
            End If

            Call UpdateData_Server(EDITData)
            If D1.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI ='Admin Piutang B/P Ps.Minggu' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
                Call emailapprove_server("select * from tb_user where jabatan= 'Admin Piutang B/P Ps.Minggu'")
            End If
            If D2.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI ='Admin Piutang B/P Puri' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
                Call emailapprove_server("select * from tb_user where jabatan= 'Admin Piutang B/P Puri'")
            End If
            If D3.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI ='Admin Piutang Service Ps.Minggu' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
                Call emailapprove_server("select * from tb_user where jabatan= 'Admin Piutang Service Ps.Minggu'")
            End If
            If D4.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI ='Admin Piutang Service Puri' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
                Call emailapprove_server("select * from tb_user where jabatan= 'Admin Piutang Service Puri'")
            End If
            If D5.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI ='Admin Piutang Showroom Ps.Minggu' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
                Call emailapprove_server("select * from tb_user where jabatan= 'Admin Piutang Showroom Ps.Minggu'")
            End If
            If D6.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI ='Admin Piutang Showroom Puri' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
                Call emailapprove_server("select * from tb_user where jabatan= 'Admin Piutang Showroom Puri'")
            End If
            If D7.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI ='Admin Faktur Ps.Minggu' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
                Call emailapprove_server("select * from tb_user where jabatan= 'Admin Faktur Ps.Minggu'")
            End If
            If D8.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI ='Admin Faktur Puri' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
                Call emailapprove_server("select * from tb_user where jabatan= 'Admin Faktur Puri'")
            End If
            If D9.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI ='WH Coordinator' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
                Call emailapprove_server("select * from tb_user where jabatan= 'WH Coordinator'")
            End If
            If D10.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI ='Staff Spareparts' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
                Call emailapprove_server("select * from tb_user where jabatan= 'Staff Spareparts'")
            End If
            If D11.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI2 ='ADH Ps.Minggu' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
            End If
            If D12.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI2 ='ADH Puri' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
            End If
            If D13.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI2 ='SM PS. Minggu' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
            End If
            If D14.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI2 ='SM Puri' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
            End If
            If D15.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI2 ='Service Manager Ps.Minggu' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
            End If
            If D16.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI2 ='Service Manager Puri' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
            End If
            If D17.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI2 ='Ka. Sparepart Ps. Minggu' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
            End If
            If D18.Checked = True Then
                Call UpdateData_Server("UPDATE TRXN_DOKUMEN SET DOKUMEN_DIKETAHUI2 ='Ka. Sparepart Puri' WHERE DOKUMEN_NO = '" & lblBeritaAcaraId.Text & "'")
            End If
            LvDetailMaster.DataBind()
            MultiViewUploadDokumen.ActiveViewIndex = -1
        End If
    End Sub
    Protected Sub LvDetailMaster_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailMaster.SelectedIndexChanged
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM BERITA ACARA -- ADD+EDIT DATA'") = 1 Then
            lblBeritaAcaraId.Text = (LvDetailMaster.DataKeys(LvDetailMaster.SelectedIndex).Value.ToString)
            Call GetData_AddNomor("SELECT * FROM TRXN_DOKUMEN WHERE DOKUMEN_NO='" & lblBeritaAcaraId.Text & "'")
            MultiViewUploadDokumen.ActiveViewIndex = 0
            'Call DetailMasterOn()
        Else
            Call Msg_err("Tidak boleh melakukan menu ini") : Exit Sub
        End If

    End Sub

    Function insertData() As String
        insertData = "INSERT INTO TRXN_DOKUMEN (DOKUMEN_NO) VALUES ('" & lblBeritaAcaraId.Text & "')"
    End Function

    Function EDITData() As String
        Dim filereceived As String = FileUpload1.PostedFile.FileName
        Dim filename As String = Path.GetFileName(filereceived)
        Dim filereceived2 As String = FileUpload2.PostedFile.FileName
        Dim filename2 As String = Path.GetFileName(filereceived2)
        EDITData = "UPDATE TRXN_DOKUMEN SET " & _
                                "DOKUMEN_NAMA='" & TxtNamaDokumen.Text & "'," & _
                                "DOKUMEN_LINK='" & filename & "'," & _
                                "DOKUMEN_RINCIAN='" & filename2 & "'," & _
                                "DOKUMEN_CABANG='" & DropDownList1.Text & "'," & _
                                "DOKUMEN_DIBUAT='" & LblUserName.Text & "'," & _
                                "DOKUMEN_TGLDIBUAT='" & Now() & "'," & _
                                "DOKUMEN_JENIS='D'" & _
                                "WHERE DOKUMEN_NO='" & lblBeritaAcaraId.Text & "'"
        Dim fileuploadpath As String = "C:\inetpub\wwwroot\MugenASPHRISO\WEBDOWNLOAD\DOKUMENAUDIT "
        FileUpload1.PostedFile.SaveAs(Path.Combine(fileuploadpath, filename))
        FileUpload2.PostedFile.SaveAs(Path.Combine(fileuploadpath, filename2))
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
                lblBeritaAcaraId.Text = nSr(MyRecReadA("DOKUMEN_NO"))
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
                lblArea1.Text = nSr(MyRecReadA("JABATAN"))
                lblArea2.Text = nSr(MyRecReadA("JABATAN"))
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
        'MsgBox(DtFrSQL)
ErrHand:
    End Function


    Sub ClearPermintaan()
        lblBeritaAcaraId.Text = ""

        TxtNamaDokumen.Text = ""

    End Sub

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
End Class
