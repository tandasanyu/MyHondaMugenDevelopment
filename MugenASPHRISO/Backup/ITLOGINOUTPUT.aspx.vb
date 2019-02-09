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

Partial Class ITLOGINOUTPUT
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If

        If LblUserName.Text = "" Then
            Dim no As String = Request.QueryString("no")

            Dim x As String
            Dim mFound As Byte = 0
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = x.ToString
            If no <> "" Then
                Call GetData_SDR("SELECT * FROM TRXN_SDR WHERE SDRLOG_NO='" & no & "'")
                MultiViewDetailSDR.ActiveViewIndex = 0
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM LOGIN -- DIKETAHUI'") = 1 And GetFindRecord_Server("SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_JENIS], [SDRLOG_PERMANEN], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] where ([SDRLOG_KETAHUINAMA] =  '" & LblUserName.Text & "' AND [SDRLOG_KETAHUITGL] IS NULL AND [SDRLOG_NO]='" & no & "')") = 1 Then
                    BtnNilaiSMSave.Visible = True
                Else
                    BtnNilaiSMSave.Visible = False
                End If

                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM LOGIN -- DISETUJUI'") = 1 And GetFindRecord_Server("SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_JENIS], [SDRLOG_PERMANEN], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] where [SDRLOG_KETAHUITGL] IS NOT NULL and [SDRLOG_KETAHUINAMA] IS NOT NULL AND [SDRLOG_SETUJUNAMA] IS NULL AND [SDRLOG_SETUJUTGl] IS NULL AND [SDRLOG_NO]='" & no & "'") = 1 Then
                    MultiViewDisetujuiSDR.ActiveViewIndex = 0
                Else
                    MultiViewDisetujuiSDR.ActiveViewIndex = -1
                End If

                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM LOGIN -- DIUJI'") = 1 And GetFindRecord_Server("SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_JENIS], [SDRLOG_TGLCLOSE], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] WHERE ([SDRLOG_PEMOHONNAMA] = '" & LblUserName.Text & "' AND [SDRLOG_KETAHUITGL] IS NOT NULL and [SDRLOG_KETAHUINAMA] IS NOT NULL AND [SDRLOG_SETUJUNAMA] IS NOT NULL AND [SDRLOG_SETUJUTGl] IS NOT NULL AND [SDRLOG_UJINAMA] IS NULL AND [SDRLOG_UJITGL] IS NULL AND [SDRLOG_TGLCLOSE] IS NOT NULL AND [SDRLOG_NO]='" & no & "')") = 1 Then
                    MultiViewDiujiSDR.ActiveViewIndex = 0
                Else
                    MultiViewDiujiSDR.ActiveViewIndex = -1
                End If
            End If
        End If

    End Sub

    '-------------------------------------------------------------------------
    '|                      Event pada button                                 |
    '--------------------------------------------------------------------------
    Protected Sub BtnNilaiSMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave.Click

        Dim lblBackupId As String = no.Text
        Dim mSqlTxt As String = "UPDATE TRXN_SDR SET SDRLOG_KETAHUITGL=GETDATE()  WHERE SDRLOG_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        Call KirimPesanLogin()
        MultiViewDisetujuiSDR.ActiveViewIndex = -1
        Response.Write("<script>alert('Anda berhasil melakukan approval')</script>")
        Response.Write("<script>window.location.href='ITLOGIN.aspx';</script>")
    End Sub

    Protected Sub BtnNilaiSM2Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSM2Save.Click

        Dim lblBackupId As String = no.Text
        Dim mSqlTxt As String = "UPDATE TRXN_SDR SET SDRLOG_SETUJUNAMA='" & LblUserName.Text & "',SDRLOG_SETUJUTGL='" & Now() & "', SDRLOG_TARGETR1='" & TxtSDREstimasiTgl.Text & "'  WHERE SDRLOG_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        MultiViewDisetujuiSDR.ActiveViewIndex = -1
        Response.Write("<script>alert('Anda berhasil melakukan approval')</script>")
        Response.Write("<script>window.location.href='ITLOGIN.aspx';</script>")
    End Sub

    Protected Sub BtnNilaiSM3Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSM3Save.Click
        Dim lblBackupId As String = no.Text
        Dim mSqlTxt As String = "UPDATE TRXN_SDR SET SDRLOG_UJINAMA='" & LblUserName.Text & "',SDRLOG_UJITGL='" & Now() & "', SDRLOG_TESTSTATUS='" & DropDownList3.Text & "', SDRLOG_TESTNOTE='" & TxtSDRCatatan.Text & "'  WHERE SDRLOG_NO='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        MultiViewDiujiSDR.ActiveViewIndex = -1
        Response.Write("<script>alert('Anda berhasil melakukan approval testing SDR terhadap permohonan yang anda ajukan')</script>")
        Response.Write("<script>window.location.href='ITLOGIN.aspx';</script>")
    End Sub

    '-------------------------------------------------------------------------
    '|                      Kumpulan Fungsi                                  |
    '--------------------------------------------------------------------------


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
                no.Text = nSr(MyRecReadA("SDRLOG_NO"))

                If nSr(MyRecReadA("SDRLOG_JENIS")) = "Login Sistem" Then
                    Jenis1.Checked = True
                    Jenis2.Checked = False
                ElseIf nSr(MyRecReadA("SDRLOG_JENIS")) = "Login Email" Then
                    Jenis2.Checked = True
                    Jenis1.Checked = False
                End If

                If nSr(MyRecReadA("SDRLOG_TIPE")) = "Tambah" Then
                    StatusA1.Checked = True
                    StatusA2.Checked = False
                    StatusA3.Checked = False
                ElseIf nSr(MyRecReadA("SDRLOG_TIPE")) = "Rubah" Then
                    StatusA2.Checked = True
                    StatusA1.Checked = False
                    StatusA3.Checked = False
                ElseIf nSr(MyRecReadA("SDRLOG_TIPE")) = "Hapus" Then
                    StatusA3.Checked = True
                    StatusA1.Checked = False
                    StatusA2.Checked = False
                End If

                If nSr(MyRecReadA("SDRLOG_PERMANEN")) = "Permanen" Then
                    JWaktu1.Checked = True
                    JWaktu2.Checked = False
                Else
                    JWaktu2.Checked = True
                    JWaktu1.Checked = False
                    tgl1.Text = nSr(MyRecReadA("SDRLOG_WAKTUMULAI"))
                    tgl2.Text = nSr(MyRecReadA("SDRLOG_WAKTUSELESAI"))
                End If

                tujuan.Text = nSr(MyRecReadA("SDRLOG_TUJUAN"))

                tglUji.Text = nSr(MyRecReadA("SDRLOG_UJITGL"))
                nmUser.Text = nSr(MyRecReadA("SDRLOG_NMUSER"))


                If nSr(MyRecReadA("SDRLOG_TESTSTATUS")) = "Puas" Then
                    status1.Checked = True
                    status2.Checked = False
                ElseIf nSr(MyRecReadA("SDRLOG_TESTSTATUS")) = "Tidak Puas" Then
                    status2.Checked = True
                    status1.Checked = False
                Else
                    status2.Checked = False
                    status1.Checked = False
                End If

                keterangan.Text = nSr(MyRecReadA("SDRLOG_TESTNOTE"))


                lblNamaPemohon.Text = nSr(MyRecReadA("SDRLOG_PEMOHONNAMA"))
                lblTglPemohon.Text = nSr(MyRecReadA("SDRLOG_PEMOHONTGL"))


                If (MyRecReadA("SDRLOG_KETAHUITGL") IsNot DBNull.Value) And (MyRecReadA("SDRLOG_KETAHUINAMA") IsNot DBNull.Value) Then
                    lblNamaDiketahui.Text = nSr(MyRecReadA("SDRLOG_KETAHUINAMA"))
                    lblTglDiketahui.Text = nSr(MyRecReadA("SDRLOG_KETAHUITGL"))
                    lblAppDiketahui.Visible = True
                End If

                If (MyRecReadA("SDRLOG_SETUJUNAMA") IsNot DBNull.Value) And (MyRecReadA("SDRLOG_SETUJUTGL") IsNot DBNull.Value) Then
                    lblNamaDisetujui.Text = nSr(MyRecReadA("SDRLOG_SETUJUNAMA"))
                    lblTglDisetujui.Text = nSr(MyRecReadA("SDRLOG_SETUJUTGL"))
                    lblAppDisetujui.Visible = True
                End If

                If (MyRecReadA("SDRLOG_UJINAMA") IsNot DBNull.Value) And (MyRecReadA("SDRLOG_UJITGL") IsNot DBNull.Value) Then

                    lblNamaDiuji.Text = nSr(MyRecReadA("SDRLOG_UJINAMA"))
                    lblTglDiuji.Text = nSr(MyRecReadA("SDRLOG_UJITGL"))
                    lblAppDiuji.Visible = True
                End If

                tglEstimasi.Text = nSr(MyRecReadA("SDRLOG_TARGETR1"))
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
        mSqlCommadstring = "select headdivisi from divisi,tb_user where divisi.kddivisi = tb_user.kddivisi2 and username ='komang'"
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
            GetFindRecord_Server = IIf(MyRecReadA.HasRows = True, 1, 0)
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

    'Email notif SDR ke IT bahwa dokumen telah disetujui Head Divisi 
    Sub KirimPesanLogin()
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
