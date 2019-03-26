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

Partial Class HRDFPTK
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
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'FORM FPTK -- VIEW SEMUA DATA'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0
                MultiViewJudul.ActiveViewIndex = 0
                MultiViewAkses2.ActiveViewIndex = -1
            ElseIf GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'FORM FPTK -- VIEW DATA'") = 1 Then
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
        Dim ptk_idx As String = String.Empty
        MultiViewNilaiProgressEntry.ActiveViewIndex = 0
        MultiViewAkses.ActiveViewIndex = -1
        MultiViewAkses2.ActiveViewIndex = -1
        MultiViewJudul.ActiveViewIndex = -1
        Call ClearPermintaan()
        If ptk_id.Text = "" Then
            ptk_id.Text = GetData_SearchNomor()
            'Tambahkan Fungsi cek PTK_ID apakah sudah ada atau belum di database
            '**cek apakah ptk_id tsb ada di database 
            '**********
            Dim ptk_yes As String = GetData_SearchPTKID(ptk_id.Text, 2)
            Select Case ptk_yes
                Case "FOUND"
                    ptk_id.Text = "PTK" + manipulation_ptk(ptk_id.Text)
                    Exit Select
                Case "NO FOUND"
                    ptk_id.Text = GetData_SearchNomor()
                    Exit Select
            End Select
            Response.Write("<script>alert('PTKID : " + ptk_id.Text + "')</script>")
        End If
    End Sub
    'fungsi manipulasi ptkid
    Function manipulation_ptk(ByVal user_ptk As String) As String
        Dim hasil As String = String.Empty
        Dim ptk_idx As String = String.Empty
        hasil = user_ptk.Remove(0, 3) '--hanya angka saja
        ptk_idx = Convert.ToInt32(hasil) + 1
        manipulation_ptk = ptk_idx
        '****
    End Function
    'fungsi select ptk id berdasarkan input ptki id yg di berikan 
    Function GetData_SearchPTKID(ByVal user_ptk As String, ByVal cab As Integer) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String
        Call Msg_err("")
        GetData_SearchPTKID = ""
        Dim var1 As String

        If cab = 1 Then
            mSqlCommadstring = "select ptk_id from TRXN_PTK where ptk_id ='" + user_ptk + "'"
            cnn = New OleDbConnection(strconn)
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                mFind = IIf(MyRecReadA.HasRows = True, 1, 0)
                If mFind = 0 Then
                    GetData_SearchPTKID = "NO FOUND"
                Else
                    MyRecReadA.Read()
                    var1 = nSr(MyRecReadA("ptk_id"))
                    'pecah ptk dan nomornya
                    GetData_SearchPTKID = var1
                End If
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                Call Msg_err(ex.Message)
            End Try
        ElseIf cab = 2 Then
            mSqlCommadstring = "select ptk_id from TRXN_PTK where ptk_id ='" + user_ptk + "'"
            cnn = New OleDbConnection(strconn)
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                mFind = IIf(MyRecReadA.HasRows = True, 1, 0)
                If mFind = 0 Then
                    GetData_SearchPTKID = "NO FOUND"
                Else
                    GetData_SearchPTKID = "FOUND"
                End If
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                Call Msg_err(ex.Message)
            End Try
        End If
    End Function
    '
    'Event  ketika simpan data SDR
    Protected Sub BtnNilaiSMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave.Click
        If ptk_id.Text = "" Then
            ptk_id.Text = ptk_id.Text
            UpdateData_Server(insertData)
        Else
            If GetFindRecord_Server("SELECT * FROM TRXN_PTK WHERE PTK_ID='" & ptk_id.Text & "'") <> 1 Then
                If UpdateData_Server(insertData) = 1 Then
                    ptk_id.Text = ptk_id.Text
                End If
            End If

            If ptk_calon.Text = "Tidak" Then
                Dim mSqlTxt As String = "UPDATE TRXN_PTK SET PTK_SARANCALON = NULL WHERE  PTK_ID='" & ptk_id.Text & "'"
                Call UpdateData_Server(mSqlTxt)
            Else
                Dim mSqlTxt As String = "UPDATE TRXN_PTK SET PTK_SARANCALON='" & ptk_sarancalon.Text & "' WHERE  PTK_ID='" & ptk_id.Text & "'"
                Call UpdateData_Server(mSqlTxt)
            End If
            Call UpdateData_Server(EDITData)

            LvDetailMaster.DataBind()
            Response.Write(" <script> alert('FPTK Berhasil Dibuat')</script>")
            Response.Write("<script>window.location.href='HRDFPTK.aspx';</script>")
            End If
    End Sub

    'Event ketika menekan tombol Close SDR
    Protected Sub LvDetailMaster_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailMaster.SelectedIndexChanged
        ptk_id.Text = (LvDetailMaster.DataKeys(LvDetailMaster.SelectedIndex).Value.ToString)
        If GetFindRecord_Server("SELECT * FROM TRXN_PTK where PTK_TGLCLOSE is null AND PTK_DIKETAHUI is not null AND PTK_TGLDIKETAHUI is not null AND PTK_DISETUJUI is not null AND PTK_TGLDISETUJUI is not null AND PTK_ID='" & ptk_id.Text & "'") Then
            Dim mSqlTxt As String = "UPDATE TRXN_PTK SET PTK_TGLCLOSE='" & Now() & "' WHERE PTK_ID='" & ptk_id.Text & "'"
            Call UpdateData_Server(mSqlTxt)
            LvDetailMaster.DataBind()
            Response.Write("<script>alert('FPTK berhasil di close!')</script>") : Exit Sub
        ElseIf GetFindRecord_Server("SELECT * FROM TRXN_PTK where PTK_ID='" & ptk_id.Text & "' AND PTK_DIKETAHUI is null AND PTK_TGLDIKETAHUI is null AND PTK_DISETUJUI is null AND PTK_TGLDISETUJUI is null") Then
            Response.Write("<script>alert('FPTK Belum Di Approve HRD&GA Head / Direksi!')</script>") : Exit Sub
        Else
            Response.Write("<script>alert('FPTK sudah di close!')</script>") : Exit Sub
        End If
    End Sub


    '-------------------------------------------------------------------------
    '|                      Kumpulan Fungsi                                  |
    '--------------------------------------------------------------------------
    Function insertData() As String
        insertData = "INSERT INTO TRXN_PTK (PTK_ID) VALUES ('" & ptk_id.Text & "')"
    End Function

    Function EDITData() As String
        EDITData = "UPDATE TRXN_PTK SET " & _
                                "PTK_JABATAN='" & ptk_jabatan.Text & "'," & _
                                "PTK_DEPT='" & ptk_dept.Text & "'," & _
                                "PTK_CABANG='" & ptk_cabang.Text & "'," & _
                                "PTK_TGLMOHON='" & ptk_tglminta.Text & "'," & _
                                "PTK_TGLBUTUH='" & ptk_tglbutuh.Text & "'," & _
                                "PTK_JUMLAH='" & ptk_jumlah.Text & "'," & _
                                "PTK_STATUSKARYAWAN='" & ptk_statuskaryawan.SelectedValue & "'," & _
                                "PTK_ALASAN='" & ptk_alasan.Text & "'," & _
                                "PTK_ALASANDETAIL='" & ptk_alasandetail.Text & "'," & _
                                "PTK_JKEL='" & ptk_jkel.SelectedValue & "'," & _
                                "PTK_PENDIDIKAN='" & ptk_pendidikan.Text & "'," & _
                                "PTK_JURUSAN='" & ptk_jurusan.Text & "'," & _
                                "PTK_UMUR='" & ptk_umur.Text & "'," & _
                                "PTK_LEVEL='" & ptk_level.Text & "'," & _
                                "PTK_PENGALAMAN='" & ptk_pengalaman.Text & "'," & _
                                "PTK_KETRAMPILAN='" & ptk_ketrampilan.Text & "'," & _
                                "PTK_IPK='" & ptk_ipk.Text & "'," & _
                                "PTK_PEMOHON='" & LblUserName.Text & "' " & _
                                "WHERE  PTK_ID='" & ptk_id.Text & "'"
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
        mSqlCommadstring = "SELECT COUNT(PTK_TGLMOHON) as maxPemohon from trxn_PTK where DATEPART(year, PTK_TGLMOHON) = '" + mTahun + "'"
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
                    GetData_SearchNomor = "PTK" & mTahun & mBulan & GetData_SearchNomor
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



    Sub ClearPermintaan()
        ptk_jabatan.Text = ""
        ptk_dept.Text = ""
        ptk_cabang.Text = ""
        ptk_tglbutuh.Text = ""
        ptk_jumlah.Text = ""
        ptk_statuskaryawan.Text = ""
        ptk_alasan.Text = ""
        ptk_alasandetail.Text = ""
        ptk_jkel.Text = ""
        ptk_pendidikan.Text = ""
        ptk_jurusan.Text = ""
        ptk_umur.Text = ""
        ptk_level.Text = ""
        ptk_pengalaman.Text = ""
        ptk_ketrampilan.Text = ""
        ptk_ipk.Text = ""
        ptk_calon.Text = ""
        ptk_sarancalon.Text = ""
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

    Protected Sub calon(sender As Object, e As EventArgs)
        If ptk_calon.Text = "Ya" Then
            sarancalon.Attributes("style") = "display:block"
        Else
            sarancalon.Attributes("style") = "display:none"
        End If
    End Sub
    'Penambahan Fungsi Baru [14/3/19]
    Private ReadOnly Property ID_S() As List(Of String)
        Get
            If Me.ViewState("ID_S") Is Nothing Then
                Me.ViewState("ID_S") = New List(Of String)()
            End If
            Return CType(Me.ViewState("ID_S"), List(Of String))
        End Get
    End Property
    Protected Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        'Get checked data
        For Each item As ListViewDataItem In LvDetailMaster.Items
            Dim chkSelect As CheckBox = CType(item.FindControl("CheckBox112"), CheckBox)
            If chkSelect IsNot Nothing Then
                Dim ID As String = Convert.ToString(chkSelect.Attributes("value"))
                If chkSelect.Checked AndAlso Not Me.ID_S.Contains(ID) Then
                    Me.ID_S.Add(ID)
                ElseIf Not chkSelect.Checked AndAlso Me.ID_S.Contains(ID) Then
                    Me.ID_S.Remove(ID)
                End If
            End If
        Next
        ''
        If (ID_S IsNot Nothing AndAlso ID_S.Count > 0) Then
            For Each item As String In ID_S
                'delete trxn_ptl berdasarkan PTK_ID
                If UpdateData_Server("delete from trxn_ptk where PTK_ID ='" + item + "'") = 1 Then
                    LvDetailMaster.DataBind()
                    Response.Write("<script>alert('Berhasil Menghapus Data dengan ID : " + item + "!')</script>")
                End If
            Next
        End If
    End Sub
End Class
