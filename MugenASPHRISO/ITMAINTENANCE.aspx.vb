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

Partial Class ITMAINTENANCE
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
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'FORM MAINTENANCE -- VIEW DATA'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM MAINTENANCE -- ADD DATA'") = 1 Then
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
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM MAINTENANCE -- ADD DATA'") = 1 Then
            MultiViewNilaiProgressEntry.ActiveViewIndex = 0
            MultiViewAkses.ActiveViewIndex = -1
            Call ClearPermintaan()
            If lblMaintenanceNo.Text = "" Then
                lblMaintenanceNo.Text = GetData_SearchNomor()
            End If
        Else
            Call Msg_err("Tidak boleh melakukan menu ini") : Exit Sub
        End If
    End Sub

    'Event  ketika simpan data jadwal maintenance
    Protected Sub BtnNilaiSMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave.Click
        If lblMaintenanceNo.Text = "" Then
            lblMaintenanceNo.Text = lblMaintenanceNo.Text
            UpdateData_Server(insertData)
        Else
            If GetFindRecord_Server("SELECT * FROM TRXN_MAINTENANCE WHERE MAINTENANCE_NO='" & lblMaintenanceNo.Text & "'") <> 1 Then
                If UpdateData_Server(insertData) = 1 Then
                    lblMaintenanceNo.Text = lblMaintenanceNo.Text
                End If
            End If
            Call UpdateData_Server(EDITData)

            LvDetailMaster.DataBind()
            MultiViewNilaiProgressEntry.ActiveViewIndex = -1
            MultiViewAkses.ActiveViewIndex = 0
        End If
    End Sub

    'Event ketika menekan tombol detail
    Protected Sub LvDetailMaster_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailMaster.SelectedIndexChanged
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM MAINTENANCE -- CLOSE DATA'") = 1 Then
            lblMaintenanceNo.Text = (LvDetailMaster.DataKeys(LvDetailMaster.SelectedIndex).Value.ToString)
            If CountData_Master("SELECT * FROM TRXN_MAINTENANCE WHERE MAINTENANCE_NO='" & lblMaintenanceNo.Text & "' AND MAINTENANCE_REALISASI IS NOT NULL") = 1 Then
                Response.Write("<script>alert('Jadwal Maintenance Sudah di Close!')</script>")
            Else
                TxtHasil.Text = ""
                TxtPerbaikan.Text = ""
                Call GetData_AddNomor("SELECT * FROM TRXN_MAINTENANCE WHERE MAINTENANCE_NO='" & lblMaintenanceNo.Text & "'")
                Call emailnotifawal_server("select emaildivisi from divisi where nmdivisi='IT'")
                MultiViewHasil.ActiveViewIndex = 0
                MultiViewAkses.ActiveViewIndex = -1
                MultiViewNilaiProgressEntry.ActiveViewIndex = -1
            End If
        Else
            Response.Write("<script>alert('Maaf, Anda Tidak Memiliki Hak Akses Untuk Menu Ini!')</script>")
        End If
    End Sub

    'Event  ketika simpan data hasil maintenance
    Protected Sub BtnNilaiSMSave2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave2.Click
        Call UpdateData_Server(EDITHasil)
        LvDetailMaster.DataBind()
        MultiViewNilaiProgressEntry.ActiveViewIndex = -1
        MultiViewHasil.ActiveViewIndex = -1
        MultiViewAkses.ActiveViewIndex = 0
    End Sub

    '-------------------------------------------------------------------------
    '|                      Kumpulan Fungsi                                  |
    '--------------------------------------------------------------------------
    Function insertData() As String
        insertData = "INSERT INTO TRXN_MAINTENANCE (MAINTENANCE_NO) VALUES ('" & lblMaintenanceNo.Text & "')"
    End Function

    Function EDITData() As String
        EDITData = "UPDATE TRXN_MAINTENANCE SET " & _
                        "MAINTENANCE_ID='" & TxtID.Text & "'," & _
                        "MAINTENANCE_IP='" & TxtNoIp.Text & "'," & _
                        "MAINTENANCE_NmPc='" & TxtNmComputer.Text & "'," & _
                        "MAINTENANCE_DEPT='" & DropDownList1.Text & "'," & _
                        "MAINTENANCE_JADWAL='" & TxtJadwal.Text & "'," & _
                        "MAINTENANCE_VALIDASISTAFF='" & LblUserName.Text & "'," & _
                        "MAINTENANCE_TGLVALIDASISTAFF='" & Now() & "'," & _
                        "MAINTENANCE_KEGIATAN='" & TxtKegiatan.Text & "'" & _
                        "WHERE  MAINTENANCE_NO='" & lblMaintenanceNo.Text & "'"
    End Function

    Function EDITHasil() As String
        EDITHasil = "UPDATE TRXN_MAINTENANCE SET " & _
                        "MAINTENANCE_REALISASI='" & Now() & "'," & _
                        "MAINTENANCE_HASIL='" & TxtHasil.Text & "'," & _
                        "MAINTENANCE_TINDAKAN='" & TxtPerbaikan.Text & "'" & _
                        "WHERE MAINTENANCE_NO='" & lblNO.Text & "'"
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
                lblNO.Text = nSr(MyRecReadA("MAINTENANCE_NO"))
                lblDepartemen.Text = nSr(MyRecReadA("MAINTENANCE_DEPT"))
                lblJadwal.Text = nSr(MyRecReadA("MAINTENANCE_JADWAL"))
                lblKeg.Text = nSr(MyRecReadA("MAINTENANCE_KEGIATAN"))
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

        mSqlCommadstring = "SELECT COUNT(MAINTENANCE_TGLVALIDASISTAFF) as maxPemohon from trxn_maintenance where DATEPART(month, MAINTENANCE_TGLVALIDASISTAFF) = '" + mBulan + "' AND DATEPART(year, MAINTENANCE_TGLVALIDASISTAFF) = '" + mTahun + "'"
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
                TxtID.Text = nSr(MyRecReadA("MAINTENANCE_ID"))
                TxtNoIp.Text = nSr(MyRecReadA("MAINTENANCE_IP"))
                TxtNmComputer.Text = nSr(MyRecReadA("MAINTENANCE_NmPc"))
                DropDownList1.Text = nSr(MyRecReadA("MAINTENANCE_DEPT"))
                TxtJadwal.Text = nSr(MyRecReadA("MAINTENANCE_JADWAL"))
                TxtKegiatan.Text = nSr(MyRecReadA("MAINTENANCE_KEGIATAN"))
                TxtHasil.Text = nSr(MyRecReadA("MAINTENANCE_HASIL"))
                TxtPerbaikan.Text = nSr(MyRecReadA("MAINTENANCE_TINDAKAN"))
                lblMaintenanceNo.Text = nSr(MyRecReadA("MAINTENANCE_NO"))
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
        TxtID.Text = ""
        TxtNoIp.Text = ""
        TxtNmComputer.Text = ""
        DropDownList1.Text = ""
        TxtJadwal.Text = ""
        TxtKegiatan.Text = ""
        TxtHasil.Text = ""
        TxtPerbaikan.Text = ""
        lblMaintenanceNo.Text = ""
    End Sub

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
                pesan.Subject = "Terdapat Dokumen Jadwal & Hasil Maintenance Program Yang Membutuhkan Persetujuan Anda"
                pesan.To.Add(email) 'email tujuan
                pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
                pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda memiliki sebuah permintaan persetujuan untuk dokumen Jadwal & Hasil Maintenance <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Lihat Daftar Approval</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
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
