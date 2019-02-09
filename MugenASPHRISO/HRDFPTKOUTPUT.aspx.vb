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

Partial Class HRDFPTKOUTPUT
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
                Call GetData_FPTK("SELECT * FROM TRXN_PTK WHERE PTK_ID='" & no & "'")
                MultiViewDetailFPTK.ActiveViewIndex = 0
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM FPTK -- DIKETAHUI'") = 1 And GetFindRecord_Server("SELECT [PTK_ID], [PTK_JABATAN], [PTK_DEPT], [PTK_CABANG], [PTK_PEMOHON], [PTK_TGLMOHON] FROM [TRXN_PTK] where [PTK_DIKETAHUI] IS NULL AND [PTK_TGLDIKETAHUI] IS NULL AND [PTK_TGLCLOSE] IS NULL AND [PTK_ID]='" & no & "'") = 1 Then
                    BtnNilaiSMSave.Visible = True
                Else
                    BtnNilaiSMSave.Visible = False
                End If

                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM FPTK -- DISETUJUI'") = 1 And GetFindRecord_Server("SELECT [PTK_ID], [PTK_JABATAN], [PTK_DEPT], [PTK_CABANG], [PTK_PEMOHON], [PTK_TGLMOHON] FROM [TRXN_PTK] where [PTK_DISETUJUI] IS NULL AND [PTK_TGLDISETUJUI] IS NULL AND [PTK_TGLCLOSE] IS NULL AND [PTK_ID]='" & no & "'") = 1 Then
                    BtnNilaiSMSave2.Visible = True
                Else
                    BtnNilaiSMSave2.Visible = False
                End If

                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM FPTK -- EDIT MPP'") = 1 Then
                    MultiViewMPP.ActiveViewIndex = 0
                Else
                    MultiViewMPP.ActiveViewIndex = -1
                End If
            End If
        End If

    End Sub

    '-------------------------------------------------------------------------
    '|                      Event pada button                                 |
    '--------------------------------------------------------------------------
    Protected Sub BtnNilaiSMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave.Click

        Dim lblBackupId As String = ptk_id.Text
        Dim mSqlTxt As String = "UPDATE TRXN_PTK SET PTK_DIKETAHUI='" & LblUserName.Text & "',PTK_TGLDIKETAHUI=GETDATE() WHERE PTK_ID='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        'Call KirimPesanSDR()
        Response.Write("<script>alert('Anda berhasil melakukan approval')</script>")
        Response.Write("<script>window.location.href='HRDFPTK.aspx';</script>")
    End Sub

    Protected Sub BtnNilaiSMSave2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave2.Click

        Dim lblBackupId As String = ptk_id.Text
        Dim mSqlTxt As String = "UPDATE TRXN_PTK SET PTK_DISETUJUI='" & LblUserName.Text & "',PTK_TGLDISETUJUI=GETDATE() WHERE PTK_ID='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        'Call KirimPesanSDR()
        Response.Write("<script>alert('Anda berhasil melakukan approval')</script>")
        Response.Write("<script>window.location.href='HRDFPTK.aspx';</script>")
    End Sub

    Protected Sub BtnNilaiSMSave3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave3.Click

        Dim lblBackupId As String = ptk_id.Text
        Dim mSqlTxt As String = "UPDATE TRXN_PTK SET PTK_MPP='" & TxtMPP.Text & "',PTK_AKTUAL='" & TxtAktual.Text & "',PTK_KURANG='" & TxtKurang.Text & "' WHERE PTK_ID='" & lblBackupId & "'"
        Call UpdateData_Server(mSqlTxt)
        'Call KirimPesanSDR()
        Response.Write("<script>alert('Tabel MPP berhasil diperbarui')</script>")
        Response.Write("<script>window.location.href='HRDFPTK.aspx';</script>")
    End Sub

    '-------------------------------------------------------------------------
    '|                      Kumpulan Fungsi                                  |
    '--------------------------------------------------------------------------


    Function GetData_FPTK(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_FPTK = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                ptk_id.Text = nSr(MyRecReadA("ptk_id"))
                ptk_pemohon.Text = nSr(MyRecReadA("ptk_pemohon"))
                lbl_tglmohon.Text = nSr(MyRecReadA("ptk_tglmohon"))
                ptk_tglmohon.Text = nSr(MyRecReadA("ptk_tglmohon"))
                ptk_jabatan.Text = nSr(MyRecReadA("ptk_jabatan"))
                ptk_dept.Text = nSr(MyRecReadA("ptk_dept"))
                ptk_cabang.Text = nSr(MyRecReadA("ptk_cabang"))
                ptk_tglbutuh.Text = nSr(MyRecReadA("ptk_tglbutuh"))
                ptk_jumlah.Text = nSr(MyRecReadA("ptk_jumlah"))

                If nSr(MyRecReadA("ptk_statuskaryawan")) = "1" Then
                    ptk_statuskaryawan1.Checked = True
                    ptk_statuskaryawan2.Checked = False
                ElseIf nSr(MyRecReadA("ptk_statuskaryawan")) = "2" Then
                    ptk_statuskaryawan2.Checked = True
                    ptk_statuskaryawan1.Checked = False
                Else
                    ptk_statuskaryawan2.Checked = False
                    ptk_statuskaryawan1.Checked = False
                End If

                If (MyRecReadA("PTK_DIKETAHUI") IsNot DBNull.Value) And (MyRecReadA("PTK_TGLDIKETAHUI") IsNot DBNull.Value) Then
                    ptk_diketahui.Text = nSr(MyRecReadA("PTK_DIKETAHUI"))
                    lbl_tgldiketahui.Text = nSr(MyRecReadA("PTK_TGLDIKETAHUI"))
                    lblAppDiketahui.Visible = True
                End If

                If (MyRecReadA("PTK_DISETUJUI") IsNot DBNull.Value) And (MyRecReadA("PTK_TGLDISETUJUI") IsNot DBNull.Value) Then
                    ptk_disetujui.Text = nSr(MyRecReadA("PTK_DISETUJUI"))
                    lbl_tgldisetujui.Text = nSr(MyRecReadA("PTK_TGLDISETUJUI"))
                    lblAppDisetujui.Visible = True
                End If

                If nSr(MyRecReadA("ptk_statuskaryawan")) = "1" Then
                    ptk_statuskaryawan1.Checked = True
                    ptk_statuskaryawan2.Checked = False
                ElseIf nSr(MyRecReadA("ptk_statuskaryawan")) = "2" Then
                    ptk_statuskaryawan2.Checked = True
                    ptk_statuskaryawan1.Checked = False
                Else
                    ptk_statuskaryawan2.Checked = False
                    ptk_statuskaryawan1.Checked = False
                End If

                If nSr(MyRecReadA("ptk_alasan")) = "1" Then
                    ptk_alasan1.Checked = True
                    ptk_alasan2.Checked = False
                    ptk_alasan3.Checked = False
                ElseIf nSr(MyRecReadA("ptk_alasan")) = "2" Then
                    ptk_alasan2.Checked = True
                    ptk_alasan1.Checked = False
                    ptk_alasan3.Checked = False
                ElseIf nSr(MyRecReadA("ptk_alasan")) = "3" Then
                    ptk_alasan3.Checked = True
                    ptk_alasan1.Checked = False
                    ptk_alasan2.Checked = False
                Else
                    ptk_alasan1.Checked = False
                    ptk_alasan2.Checked = False
                    ptk_alasan3.Checked = False
                End If

                ptk_alasandetail.Text = nSr(MyRecReadA("ptk_alasandetail"))

                If nSr(MyRecReadA("ptk_jkel")) = "1" Then
                    ptk_jkel.Text = "Laki-Laki"
                ElseIf nSr(MyRecReadA("ptk_jkel")) = "2" Then
                    ptk_jkel.Text = "Perempuan"
                Else
                    ptk_jkel.Text = "Laki-Laki / Perempuan"
                End If

                If nSr(MyRecReadA("ptk_pendidikan")) = "1" Then
                    ptk_pendidikan.Text = "SMA/K"
                ElseIf nSr(MyRecReadA("ptk_pendidikan")) = "2" Then
                    ptk_pendidikan.Text = "D1"
                ElseIf nSr(MyRecReadA("ptk_pendidikan")) = "2" Then
                    ptk_pendidikan.Text = "D2"
                ElseIf nSr(MyRecReadA("ptk_pendidikan")) = "2" Then
                    ptk_pendidikan.Text = "D3"
                Else
                    ptk_pendidikan.Text = "S1"
                End If
                ptk_jurusan.Text = nSr(MyRecReadA("ptk_jurusan"))
                ptk_umur.Text = nSr(MyRecReadA("ptk_umur"))

                If nSr(MyRecReadA("ptk_level")) = "1" Then
                    ptk_level1.Checked = True
                    ptk_level2.Checked = False
                    ptk_level3.Checked = False
                    ptk_level4.Checked = False
                ElseIf nSr(MyRecReadA("ptk_level")) = "2" Then
                    ptk_level2.Checked = True
                    ptk_level1.Checked = False
                    ptk_level3.Checked = False
                    ptk_level4.Checked = False
                ElseIf nSr(MyRecReadA("ptk_level")) = "3" Then
                    ptk_level3.Checked = True
                    ptk_level1.Checked = False
                    ptk_level2.Checked = False
                    ptk_level4.Checked = False
                ElseIf nSr(MyRecReadA("ptk_level")) = "4" Then
                    ptk_level4.Checked = True
                    ptk_level1.Checked = False
                    ptk_level2.Checked = False
                    ptk_level3.Checked = False
                Else
                    ptk_level1.Checked = False
                    ptk_level2.Checked = False
                    ptk_level3.Checked = False
                    ptk_level4.Checked = False
                End If

                ptk_pengalaman.Text = nSr(MyRecReadA("ptk_pengalaman"))
                ptk_ketrampilan.Text = nSr(MyRecReadA("ptk_ketrampilan"))
                ptk_ipk.Text = nSr(MyRecReadA("ptk_ipk"))
                If (MyRecReadA("ptk_sarancalon") IsNot DBNull.Value) Then
                    ptk_calon1.Checked = True
                    ptk_calon2.Checked = False
                    ptk_sarancalon.Text = nSr(MyRecReadA("ptk_sarancalon"))
                ElseIf (MyRecReadA("ptk_sarancalon") Is DBNull.Value) Then
                    ptk_calon2.Checked = True
                    ptk_calon1.Checked = False
                    ptk_sarancalon.Text = "-"
                Else
                    ptk_calon2.Checked = False
                    ptk_calon1.Checked = False
                    ptk_sarancalon.Text = ""
                End If
                lblmpp.Text = nSr(MyRecReadA("ptk_mpp"))
                lblaktual.Text = nSr(MyRecReadA("ptk_aktual"))
                lblkurang.Text = nSr(MyRecReadA("ptk_kurang"))

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
        mSqlCommadstring = "select headdivisi from divisi,tb_user where divisi.kddivisi = tb_user.kddivisi and username ='komang'"
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
    Sub KirimPesanSDR()
        Dim pesan As New MailMessage
        pesan.Subject = "Terdapat Dokumen SDR Yang Membutuhkan Persetujuan Anda"
        'pesan.To.Add("mis@hondamugen.co.id")
        pesan.To.Add("komang@hondamugen.co.id") 'email tujuan
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
