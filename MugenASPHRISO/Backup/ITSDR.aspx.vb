﻿Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Net.Mail
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization

Partial Class ITSDR
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
            lblArea2.Text = x.ToString
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'FORM SDR -- VIEW SEMUA DATA'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0
                MultiViewJudul.ActiveViewIndex = 0
                MultiViewAkses2.ActiveViewIndex = -1
            ElseIf GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'FORM SDR -- VIEW DATA'") = 1 Then
                MultiViewAkses2.ActiveViewIndex = 0
                MultiViewJudul.ActiveViewIndex = 0
                MultiViewAkses.ActiveViewIndex = -1
            Else
                MultiViewAkses.ActiveViewIndex = -1
                MultiViewAkses2.ActiveViewIndex = -1
                MultiViewJudul.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub

    '-------------------------------------------------------------------------
    '|                      Event pada button                                 |
    '--------------------------------------------------------------------------

    'Event ketika menekan tombol tambah data
    Protected Sub BtnMasterTabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMasterTabel.Click
        MultiViewNilaiProgressEntry.ActiveViewIndex = 0
        MultiViewAkses.ActiveViewIndex = -1
        MultiViewAkses2.ActiveViewIndex = -1
        MultiViewJudul.ActiveViewIndex = -1
        Call ClearPermintaan()
        If lblSDRId.Text = "" Then
            lblSDRId.Text = GetData_SearchNomor()
            lblSDRHead.Text = GetData_Head()
        End If
    End Sub

    'Event  ketika simpan data SDR
    Protected Sub BtnNilaiSMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave.Click

        If lblSDRId.Text = "" Then
            lblSDRId.Text = lblSDRId.Text
            UpdateData_Server(insertData)
        Else
            If GetFindRecord_Server("SELECT * FROM TRXN_SDR WHERE SDRLOG_NO='" & lblSDRId.Text & "'") <> 1 Then
                If UpdateData_Server(insertData) = 1 Then
                    lblSDRId.Text = lblSDRId.Text
                End If
            End If
            If DropDownList2.Text = "Permanen" Then
                Call UpdateData_Server(EDITData)
                Call emailnotifawal_server("select emaildivisi from tb_user, divisi where tb_user.kddivisi2 = divisi.kddivisi and username='" & LblUserName.Text & "'")
            Else
                Call UpdateData_Server(EDITData2)
                Call emailnotifawal_server("select emaildivisi from tb_user, divisi where tb_user.kddivisi2 = divisi.kddivisi and username='" & LblUserName.Text & "'")
            End If

            LvDetailMaster.DataBind()
            Response.Write("<script>alert('Dokumen SDR anda berhasil dibuat!')</script>")
            Response.Write("<script>window.location.href='ITSDR.aspx';</script>")
        End If
    End Sub

    'Event ketika menekan tombol Close SDR
    Protected Sub LvDetailMaster_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailMaster.SelectedIndexChanged
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM SDR -- VIEW SEMUA DATA'") = 1 Then
            lblSDRId.Text = (LvDetailMaster.DataKeys(LvDetailMaster.SelectedIndex).Value.ToString)
            If GetFindRecord_Server("SELECT * FROM TRXN_SDR where SDRLOG_NO='" & lblSDRId.Text & "' AND SDRLOG_TGLCLOSE is null AND SDRLOG_KETAHUITGL is not null AND SDRLOG_KETAHUITGL is not null AND SDRLOG_SETUJUTGL is not null") Then
                Dim mSqlTxt As String = "UPDATE TRXN_SDR SET SDRLOG_TGLCLOSE='" & Now() & "' WHERE SDRLOG_NO='" & lblSDRId.Text & "'"
                Call UpdateData_Server(mSqlTxt)
                Call emailnotifakhir_server("select * from tb_user where username='" & LblUserName.Text & "'")
                LvDetailMaster.DataBind()
            ElseIf GetFindRecord_Server("SELECT * FROM TRXN_SDR where SDRLOG_NO='" & lblSDRId.Text & "' AND SDRLOG_KETAHUITGL is null AND SDRLOG_KETAHUITGL is null AND SDRLOG_SETUJUTGL is null") Then
                Response.Write("<script>alert('SDR Belum Di Approve Head Department/IT Head Department!')</script>") : Exit Sub
            Else
                Response.Write("<script>alert('SDR sudah di close!')</script>") : Exit Sub
            End If
        Else
            Call Msg_err("Tidak boleh melakukan menu ini") : Exit Sub
        End If
    End Sub


    '-------------------------------------------------------------------------
    '|                      Kumpulan Fungsi                                  |
    '--------------------------------------------------------------------------
    Function insertData() As String
        insertData = "INSERT INTO TRXN_SDR (SDRLOG_NO) VALUES ('" & lblSDRId.Text & "')"
    End Function

    Function EDITData() As String
        EDITData = "UPDATE TRXN_SDR SET " & _
                                "SDRLOG_JENIS='" & DropDownList1.Text & "'," & _
                                "SDRLOG_PERMANEN='" & DropDownList2.Text & "'," & _
                                "SDRLOG_TUJUAN='" & TxtSDRTujuan.Text & "'," & _
                                "SDRLOG_DETAIL='" & TxtSDRDetail.Text & "'," & _
                                "SDRLOG_PEMOHONTGL='" & Now() & "'," & _
                                "SDRLOG_KETAHUINAMA='" & lblSDRHead.Text & "'," & _
                                "SDRLOG_PEMOHONNAMA='" & LblUserName.Text & "'" & _
                                "WHERE  SDRLOG_NO='" & lblSDRId.Text & "'"
    End Function

    Function EDITData2() As String
        EDITData2 = "UPDATE TRXN_SDR SET " & _
                                "SDRLOG_JENIS='" & DropDownList1.Text & "'," & _
                                "SDRLOG_WAKTUMULAI=" & DtFrSQL(TxtSDRTglmulai.Text) & ", SDRLOG_WAKTUSELESAI=" & DtFrSQL(TxtSDRTglSelesai.Text) & ", SDRLOG_TUJUAN='" & TxtSDRTujuan.Text & "'," & _
                                "SDRLOG_DETAIL='" & TxtSDRDetail.Text & "'," & _
                                "SDRLOG_PEMOHONTGL='" & Now() & "'," & _
                                "SDRLOG_KETAHUINAMA='" & lblSDRHead.Text & "'," & _
                                "SDRLOG_PEMOHONNAMA='" & LblUserName.Text & "'" & _
                                "WHERE  SDRLOG_NO='" & lblSDRId.Text & "'"
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
        mSqlCommadstring = "SELECT COUNT(SDRLOG_PEMOHONTGL) as maxPemohon from trxn_sdr where DATEPART(month, SDRLOG_PEMOHONTGL) = '" + mBulan + "' AND DATEPART(year, SDRLOG_PEMOHONTGL) = '" + mTahun + "'"
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

    Function GetData_Head() As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String

        Call Msg_err("")
        GetData_Head = ""

        'mSqlCommadstring = "SELECT NOMOR FROM TRXN_SPKAH WHERE CABANG='" & lblDealer.Text & "' AND NOT(NOMOR IS NULL OR NOMOR='') AND MONTH(TANGGAL_ENTRY)=MONTH(GETDATE()) AND YEAR(TANGGAL_ENTRY)=YEAR(GETDATE()) ORDER BY NOMOR DESC"
        mSqlCommadstring = "select headdivisi from divisi,tb_user where divisi.kddivisi collate SQL_Latin1_General_CP1_CI_AS = tb_user.kddivisi2 collate SQL_Latin1_General_CP1_CI_AS and username ='" & LblUserName.Text & "'"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            mFind = IIf(MyRecReadA.HasRows = True, 1, 0)
            If mFind = 0 Then
                GetData_Head = "NO FOUND"
            Else
                MyRecReadA.Read()
                GetData_Head = nSr(MyRecReadA("headdivisi"))
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

    Protected Sub jWaktu(sender As Object, e As EventArgs)
        If DropDownList2.Text = "Permanen" Then
            tanggal.Attributes("style") = "display:none"
        Else
            tanggal.Attributes("style") = "display:block"
        End If
    End Sub

    Sub ClearPermintaan()
        DropDownList1.Text = ""
        'DropDownList2.Text = nSr(MyRecReadA("SDRLOG_JENIS"))
        DropDownList2.Text = ""
        TxtSDRTglmulai.Text = ""
        TxtSDRTglSelesai.Text = ""
        TxtSDRTujuan.Text = ""
        TxtSDRDetail.Text = ""
        lblSDRId.Text = ""
    End Sub

    Function emailnotifawal_server(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        emailnotifawal_server = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            emailnotifawal_server = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                Dim email As String = nSr(MyRecReadA("emaildivisi"))
                Dim pesan As New MailMessage
                pesan.Subject = "Terdapat Dokumen SDR Yang Membutuhkan Persetujuan Anda"
                pesan.To.Add(email) 'email tujuan
                pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
                pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda memiliki sebuah permintaan persetujuan untuk Dokumen SDR <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Daftar Approval</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
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

    Function emailnotifakhir_server(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        emailnotifakhir_server = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            emailnotifakhir_server = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                Dim email As String = nSr(MyRecReadA("email"))
                Dim pesan As New MailMessage
                pesan.Subject = "Permintaan SDR Anda Sudah Selesai"
                pesan.To.Add(email) 'email tujuan
                pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
                pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Permintaan SDR anda telah selesai dikerjakan. Silahkan lakukan pengujian dan validasi SDR anda <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk validasi SDR anda</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
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
