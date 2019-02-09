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
Imports System.Globalization
Imports System.Configuration
Partial Class FormIzin
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim v1 As String = Request.QueryString("Name")
        Dim v1 As String = Request.QueryString("Name") '112VYE
        'Response.Write("<script>alert('ID : = " + v1 + "!')</script>")
        'Response.Write("<script>window.location.href='HOME.aspx';</script>")

        Dim KODE_SALES As String = v1.Remove(0, 3) 'value vye
        If KODE_SALES.Length = 3 Then
            Dim KODE_CABANG As String = v1.Remove(3, 3)
        Else
            Dim KODE_CABANG As String = v1.Remove(3, 2)
        End If


        'Dim elimin As String = v1.Substring(3) '===eko'
        'Dim usr_real As String = elimin.Substring(0, 3)
        kodesales.Text = KODE_SALES 'vye
        'cari  username dan cek di sales warehouse [Select Case* From DATA_SECURITYH Where SECURITYH_NOIDSALES = 'EKO']
        '========
        'get detail di [select * from data_salesman where SALES_Kode = 'EKO']
        'Dim query1 As String = "select * from data_salesman where SALES_Kode = '" & usr_real & "'"
        Call GetData_DetaiIzinStaff("select * from data_salesman where SALES_Kode = '" & KODE_SALES & "'", 1)
        Call GetData_DetaiIzinStaff("select sales_email from data_salesman where Sales_Kode = '" & grup.Text & "'", 2)
        cabang.Text = v1 '112VYE
        TxtBulanCuti.Text = DateTime.Now.ToString("MM")
        MultiView1.ActiveViewIndex = -1

    End Sub
    Public MyRecReadA As OleDbDataReader

    'Protected Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
    '    Dim usr As String = hidden.Text
    '    Dim elimin As String = usr.Substring(4) '===eko'
    '    Dim usr_real As String = elimin.Substring(0, 3)
    '    kodesales.Text = usr_real
    '    'cari  username dan cek di sales warehouse [Select Case* From DATA_SECURITYH Where SECURITYH_NOIDSALES = 'EKO']
    '    '========
    '    'get detail di [select * from data_salesman where SALES_Kode = 'EKO']
    '    'Dim query1 As String = "select * from data_salesman where SALES_Kode = '" & usr_real & "'"
    '    Call GetData_DetaiIzinStaff("select * from data_salesman where SALES_Kode = '" & usr_real & "'", 1)
    'End Sub

    'Kumpulan Fungsi dan Public Variabel Nya===========================================================================================================
    'Fungsi entah untuk apa 
    Function TxtPetik(ByRef MyText As String) As String
        Dim mPosStart As Byte
        TxtPetik = IIf(IsDBNull(MyText), "", Trim(MyText))
        mPosStart = 1
        While InStr(mPosStart, TxtPetik, "'") <> 0
            mPosStart = InStr(mPosStart, TxtPetik, "'")
            TxtPetik = Mid(TxtPetik, 1, mPosStart) & "'" & "" & Mid(TxtPetik, mPosStart + 1, Len(TxtPetik) - mPosStart)
            mPosStart = mPosStart + 2
        End While
    End Function
    'Fungsi Email
    Function emailNotifikasi(isiPesan As String, emailstaff As String) As Byte
        Dim pesan As New MailMessage
        pesan.Subject = "Notifikasi Pengajuan Izin Sales"
        pesan.To.Add(emailstaff) 'email tujuan
        pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
        pesan.Body = isiPesan
        pesan.IsBodyHtml = True
        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p") 'isi dengan info akun gmail kalian
        SMTP.Port = "587"
        SMTP.Send(pesan)
    End Function
    'Fungsi Get Detail Sales
    Function GetData_DetaiIzinStaff(ByVal mSqlCommadstring As String, ByVal mPos As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet88st").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_DetaiIzinStaff = 0

        cnn = New OleDbConnection(strconn)

        If mPos = 1 Then 'get detail staff
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    nama.Text = nSr(MyRecReadA("sales_nama"))
                    jabatan.Text = nSr(MyRecReadA("sales_jabatan"))
                    grup.Text = nSr(MyRecReadA("sales_group"))
                    subjabatan.Text = nSr(MyRecReadA("sales_subjabatan"))
                    email.Text = nSr(MyRecReadA("sales_email"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 2 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    emailatasan.Text = nSr(MyRecReadA("sales_email"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        End If
    End Function
    'additional connection function
    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function
    'Fungi CUD data pada 171
    Function UpdateData_Server(ByVal mSqlCommadstring As String, conns As String) As Byte
        '1=CRERATE , 2=UPDATE
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(conns).ConnectionString
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
            Response.Write("<script>alert('Error Pada Proses Update Data ke Server. Proses Gagal')</script>")
        End Try
    End Function
    '****FUNGSI UNTUK MENDAPATKAN STATUS PENGAJUAN IZIN TERBARU 
    Public STATUS As String
    Public ID_Staff As String

    Function GetData_StatusIzin(ByVal mSqlCommadstring As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_StatusIzin = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_StatusIzin = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                'this code ==
                STATUS = MyRecReadA("izin_status")
                ID_Staff = MyRecReadA("izin_id")
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As SqlException
            'Call Msg_err(ex.Message)
        End Try
    End Function
    'Fungsi Get ID Izin Terbaru
    Public idizin_pertama As String
    Function GetData_IdIzinPengajuan(ByVal mSqlCommadstring As String, conns As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(conns).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        GetData_IdIzinPengajuan = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                idizin_pertama = nSr(MyRecReadA("IZIN_ID"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function
    'Fungsi Get Password Sales - MyConnCloudDnet88sw'
    Public pswd_sales As String
    Function GetData_PswdSales(ByVal mSqlCommadstring As String, conns As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(conns).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        GetData_PswdSales = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                pswd_sales = nSr(MyRecReadA("SECURITYH_PASS"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function
    'Fungsi Get List Tgl Merah di Tahun Berjalan
    Public dateListDead As List(Of DateTime) = New List(Of DateTime)() 'array temporary (berisi tgl merah liburan)
    Function GetData_ListTglPre(ByVal mSqlCommadstring As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet171").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_ListTglPre = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_ListTglPre = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                'this code ==
                dateListDead.Add(MyRecReadA("tgl_libur"))
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As SqlException
            'Call Msg_err(ex.Message)
        End Try
    End Function
    'fungsi untuk mendapatkan saldo detail dari satu staff
    Public saldo_tahunan As Integer
    Public saldo_tahunanberlaku As DateTime
    Public saldo_pending As Integer
    Public saldo_pendingberlaku As DateTime
    Function Real_saldoStaff(ByVal mSqlCommadstring As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Real_saldoStaff = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            Real_saldoStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                saldo_tahunan = nSr(MyRecReadA("IZIN_SALDO")) 'saldo izin aktif
                saldo_tahunanberlaku = nSr(MyRecReadA("IZIN_SALDO_CUTI_TAHUNAN_BERLAKU")) 'saldo izin aktif (tanggal)
                saldo_pending = nSr(MyRecReadA("IZIN_SALDO_PC")) 'saldo pending cuti
                saldo_pendingberlaku = nSr(MyRecReadA("IZIN_SALDO_PC_BERLAKU")) 'saldo pending cuti (tanggal)
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
        End Try
    End Function

    'Kumpulan Button =================================================================================================
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MultiView1.ActiveViewIndex = 0
        LabelJenisIzin.Text = "Cuti"
        txtCutiPengajuan1.Text = ""
        TxtCutiPengajuan2.Text = ""
        DropDownListTidakMasukKantor.Visible = False
        DropDownListCutiAlasan.Visible = True
        uploadfile.Visible = False
        lblCuti.Visible = True
        lblTidakMasukKantor.Visible = False
        If email.Text = "" Then
            TxtCutiEmail.Text = ""
        Else
            TxtCutiEmail.Text = email.Text
            TxtCutiEmail.ReadOnly = True
        End If
        TxtCutiTahun.Text = DateTime.Now.ToString("yyyy")
        TxtCutiNama.Text = nama.Text
        Dim dateskrg As DateTime = DateTime.Now.ToShortDateString 'datetime hari ini
        'buat validasi untuk hide tombol simpan pengajuan cuti , tidak masuk kantor, telat, pulang cepat ketika sales saldo izin nya 0 atau data nya tidak ada. Hide Tombol Submit
        If Real_saldoStaff("select IZIN_SALDO, IZIN_SALDO_CUTI_TAHUNAN_BERLAKU, IZIN_SALDO_PC, IZIN_SALDO_PC_BERLAKU from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + cabang.Text + "'") = 1 Then
            If saldo_pending + saldo_tahunan > 0 Then 'cek apakah saldo tahunan masih ada. jika 0 maka tidak bisa mengajukan izin 
                If saldo_tahunanberlaku >= dateskrg Then 'cek apakah saldo tahunan masih berlaku
                    If dateskrg <= saldo_pendingberlaku Then 'jika masih berlaku maka cek apakah saldo pending masih berlaku
                        'kondisi dimana saldo pending masih berlaku
                        TxtCutiSaldoPending.Text = saldo_pending
                        TxtCutiSaldoPendingBerlaku.Text = saldo_pendingberlaku
                        TxtCutiSaldoIzin.Text = saldo_tahunan
                        TxtCutiSaldoIzinBerlaku.Text = saldo_tahunanberlaku
                    Else
                        'Response.Write("<script>alert('kondisi dimana saldo pending tidak berlaku. dan saldo final adalah saldo izin berlaku')</script>")
                        'kondisi dimana saldo pending tidak berlaku. dan saldo final adalah saldo izin berlaku
                        TxtCutiSaldoPending.Visible = False
                        TxtCutiSaldoPendingBerlaku.Visible = False
                        TxtCutiSaldoIzin.Text = saldo_tahunan
                        TxtCutiSaldoIzinBerlaku.Text = saldo_tahunanberlaku
                    End If
                Else
                    Response.Write("<script>alert('Saldo Izin Tahunan anda telah habisa masa berlakunya. Silahkan Lapor HRD!')</script>")
                    'Response.Write("<script>window.location.href='HOME.aspx';</script>")
                    BtnCuti.Visible = False
                End If
            Else
                Response.Write("<script>alert('Saldo Izin anda Kosong. Anda Tidak Bisa Mengajukan Izin')</script>")
                BtnCuti.Visible = False
            End If
        Else
                Response.Write("<script>alert('Saldo Izin Anda Tidak di Temukan . Hubungi HRD untuk input saldo izin tahun ini ')</script>")
            Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
        End If
    End Sub
    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'MultiView1.ActiveViewIndex = 1
        LabelJenisIzin.Text = "Tidak Masuk Kantor"
        MultiView1.ActiveViewIndex = 0
        DropDownListCutiAlasan.Visible = False
        DropDownListTidakMasukKantor.Visible = True
        uploadfile.Visible = True
        lblCuti.Visible = False
        lblTidakMasukKantor.Visible = True
        If email.Text = "" Then
            TxtCutiEmail.Text = ""
        Else
            TxtCutiEmail.Text = email.Text
            TxtCutiEmail.ReadOnly = True
        End If
        TxtCutiTahun.Text = DateTime.Now.ToString("yyyy")
        TxtCutiNama.Text = nama.Text
        Dim dateskrg As DateTime = DateTime.Now.ToShortDateString 'datetime hari ini
        'buat validasi untuk hide tombol simpan pengajuan cuti , tidak masuk kantor, telat, pulang cepat ketika sales saldo izin nya 0 atau data nya tidak ada. Hide Tombol Submit
        If Real_saldoStaff("select IZIN_SALDO, IZIN_SALDO_CUTI_TAHUNAN_BERLAKU, IZIN_SALDO_PC, IZIN_SALDO_PC_BERLAKU from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + cabang.Text + "'") = 1 Then
            If saldo_pending + saldo_tahunan > 0 Then 'cek apakah saldo tahunan masih ada. jika 0 maka tidak bisa mengajukan izin 
                If saldo_tahunanberlaku >= dateskrg Then 'cek apakah saldo tahunan masih berlaku
                    If dateskrg <= saldo_pendingberlaku Then 'jika masih berlaku maka cek apakah saldo pending masih berlaku
                        'kondisi dimana saldo pending masih berlaku
                        TxtCutiSaldoPending.Text = saldo_pending
                        TxtCutiSaldoPendingBerlaku.Text = saldo_pendingberlaku
                        TxtCutiSaldoIzin.Text = saldo_tahunan
                        TxtCutiSaldoIzinBerlaku.Text = saldo_tahunanberlaku
                    Else
                        'Response.Write("<script>alert('kondisi dimana saldo pending tidak berlaku. dan saldo final adalah saldo izin berlaku')</script>")
                        'kondisi dimana saldo pending tidak berlaku. dan saldo final adalah saldo izin berlaku
                        TxtCutiSaldoPending.Visible = False
                        TxtCutiSaldoPendingBerlaku.Visible = False
                        TxtCutiSaldoIzin.Text = saldo_tahunan
                        TxtCutiSaldoIzinBerlaku.Text = saldo_tahunanberlaku
                    End If
                Else
                    Response.Write("<script>alert('Saldo Izin Tahunan anda telah habisa masa berlakunya. Silahkan Lapor HRD!')</script>")
                    'Response.Write("<script>window.location.href='HOME.aspx';</script>")
                    BtnCuti.Visible = False
                End If
            Else
                Response.Write("<script>alert('Saldo Izin anda Kosong. Anda Tidak Bisa Mengajukan Izin')</script>")
                BtnCuti.Visible = False
            End If
        Else
                Response.Write("<script>alert('Saldo Izin Anda Tidak di Temukan / Kosong. Hubungi HRD untuk input saldo izin tahun ini ')</script>")
            Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
        End If
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MultiView1.ActiveViewIndex = 1
        LabelJenisIzin.Text = "Terlambat"
        LblTerlambat.Visible = True
        LblKeluarKantor.Visible = False
        Div2.Visible = True
        TxtTerlambatkeluarWaktuKeluar.Visible = False
        TxtTerlambatkeluarWaktuTerlambat.Visible = True
        TxtTerlambatkeluarNama.Text = nama.Text

        Dim dateskrg As DateTime = DateTime.Now.ToShortDateString 'datetime hari ini
        'buat validasi untuk hide tombol simpan pengajuan cuti , tidak masuk kantor, telat, pulang cepat ketika sales saldo izin nya 0 atau data nya tidak ada. Hide Tombol Submit
        If Real_saldoStaff("select IZIN_SALDO, IZIN_SALDO_CUTI_TAHUNAN_BERLAKU, IZIN_SALDO_PC, IZIN_SALDO_PC_BERLAKU from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + cabang.Text + "'") = 1 Then
            If saldo_tahunanberlaku >= dateskrg Then 'cek apakah saldo tahunan masih berlaku
                If dateskrg <= saldo_pendingberlaku Then 'jika masih berlaku maka cek apakah saldo pending masih berlaku
                    'kondisi dimana saldo pending masih berlaku
                    TxtCutiSaldoPending.Text = saldo_pending
                    TxtCutiSaldoPendingBerlaku.Text = saldo_pendingberlaku
                    TxtCutiSaldoIzin.Text = saldo_tahunan
                    TxtCutiSaldoIzinBerlaku.Text = saldo_tahunanberlaku
                Else
                    'Response.Write("<script>alert('kondisi dimana saldo pending tidak berlaku. dan saldo final adalah saldo izin berlaku')</script>")
                    'kondisi dimana saldo pending tidak berlaku. dan saldo final adalah saldo izin berlaku
                    TxtCutiSaldoPending.Visible = False
                    TxtCutiSaldoPendingBerlaku.Visible = False
                    TxtCutiSaldoIzin.Text = saldo_tahunan
                    TxtCutiSaldoIzinBerlaku.Text = saldo_tahunanberlaku
                End If
            Else
                Response.Write("<script>alert('Saldo Izin Tahunan anda telah habisa masa berlakunya. Silahkan Lapor HRD!')</script>")
                'Response.Write("<script>window.location.href='HOME.aspx';</script>")
                BtnTerlambat.Visible = False
            End If
        Else
            Response.Write("<script>alert('Saldo Izin Anda Tidak di Temukan / Kosong. Hubungi HRD untuk input saldo izin tahun ini ')</script>")
            Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
        End If
    End Sub
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MultiView1.ActiveViewIndex = 1
        LabelJenisIzin.Text = "Keluar Kantor"
        LblTerlambat.Visible = False
        LblKeluarKantor.Visible = True
        Div2.Visible = False
        TxtTerlambatkeluarWaktuKeluar.Visible = True
        TxtTerlambatkeluarWaktuTerlambat.Visible = False
        TxtTerlambatkeluarNama.Text = nama.Text

        Dim dateskrg As DateTime = DateTime.Now.ToShortDateString 'datetime hari ini
        'buat validasi untuk hide tombol simpan pengajuan cuti , tidak masuk kantor, telat, pulang cepat ketika sales saldo izin nya 0 atau data nya tidak ada. Hide Tombol Submit
        If Real_saldoStaff("select IZIN_SALDO, IZIN_SALDO_CUTI_TAHUNAN_BERLAKU, IZIN_SALDO_PC, IZIN_SALDO_PC_BERLAKU from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + cabang.Text + "'") = 1 Then
            If saldo_tahunanberlaku >= dateskrg Then 'cek apakah saldo tahunan masih berlaku
                If dateskrg <= saldo_pendingberlaku Then 'jika masih berlaku maka cek apakah saldo pending masih berlaku
                    'kondisi dimana saldo pending masih berlaku
                    TxtCutiSaldoPending.Text = saldo_pending
                    TxtCutiSaldoPendingBerlaku.Text = saldo_pendingberlaku
                    TxtCutiSaldoIzin.Text = saldo_tahunan
                    TxtCutiSaldoIzinBerlaku.Text = saldo_tahunanberlaku
                Else
                    'Response.Write("<script>alert('kondisi dimana saldo pending tidak berlaku. dan saldo final adalah saldo izin berlaku')</script>")
                    'kondisi dimana saldo pending tidak berlaku. dan saldo final adalah saldo izin berlaku
                    TxtCutiSaldoPending.Visible = False
                    TxtCutiSaldoPendingBerlaku.Visible = False
                    TxtCutiSaldoIzin.Text = saldo_tahunan
                    TxtCutiSaldoIzinBerlaku.Text = saldo_tahunanberlaku
                End If
            Else
                Response.Write("<script>alert('Saldo Izin Tahunan anda telah habisa masa berlakunya. Silahkan Lapor HRD!')</script>")
                'Response.Write("<script>window.location.href='HOME.aspx';</script>")
                BtnTerlambat.Visible = False
            End If
        Else
            Response.Write("<script>alert('Saldo Izin Anda Tidak di Temukan / Kosong. Hubungi HRD untuk input saldo izin tahun ini ')</script>")
            Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
        End If
    End Sub
    'variabel public BtnCuti
    Public jenis_izin As String
    Public arr_pc As List(Of DateTime) = New List(Of DateTime)()
    Public arr_notpc As List(Of DateTime) = New List(Of DateTime)()
    Public arr_temp As List(Of DateTime) = New List(Of DateTime)()
    'BERLAKU UNTUK PROSES PENGAJUAN CUTI DAN TIDAK MASUK KANTOR [DENGAN UPLOAD]
    Protected Sub BtnCuti_Click(sender As Object, e As EventArgs) Handles BtnCuti.Click
        '***buat validasi jika staff tsb pada izin pengajuan terbarunya ststus bukan disetujui manajer
        Dim nik_staff As String = cabang.Text
        Call GetData_StatusIzin("select top 1 izin_id, IZIN_NIK, IZIN_STATUS from data_izin_body_sales where izin_nik = '" + nik_staff + "' ORDER BY izin_id DESC ")
        If STATUS = "Pending" Or STATUS = "Disetujui Atasan" Then
            Response.Write("<script>alert('Anda Tidak Dapat Melakukan Pengajuan, Karena Izin anda dengan id = " + ID_Staff + " Belum di Setujui Manajer')</script>")
            Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
        ElseIf STATUS = "Disetujui Manajer" Or STATUS = "Dibatalkan Atasan" Or STATUS = "Dibatalkan Manajer" Or STATUS = "Dibatalkan Sales" Then
            '***TAMBAH VALIDASI UNTUK INPUT PASSWORD ULANG 
            'call method get password berdasarkan username login
            Call GetData_PswdSales("select SECURITYH_PASS from data_securityh where SECURITYH_NOIDSALES = '" + kodesales.Text + "'", "MyConnCloudDnet88sw")
            If TxtPswdValidCuti.Text = pswd_sales Then
                'lokal variabel 
                Dim dateList As List(Of DateTime) = New List(Of DateTime)() 'array list tgl dari user
                Dim dateListNotMinggu As List(Of DateTime) = New List(Of DateTime)() 'array datetime bukan minggu
                Dim dateListInputDB As List(Of DateTime) = New List(Of DateTime)() 'array final yang akan di insert
                Dim JCuti_P As String ' untuk menampung jenis cuti 

                'Support Process
                '***Proses Get List Tanggal
                Dim tgl_awal As DateTime = Convert.ToDateTime(txtCutiPengajuan1.Text)
                Dim tgl_akhir As DateTime = Convert.ToDateTime(TxtCutiPengajuan2.Text)
                Dim thn1 As Integer = Convert.ToInt32(tgl_awal.ToString("yyyy")) 'tahun awal
                Dim thn2 As Integer = Convert.ToInt32(tgl_akhir.ToString("yyyy")) 'tahun akhir 
                Dim thn3 As Integer = Convert.ToInt32(DateTime.Now.ToString("yyyy")) 'tahun berjalan 
                '***validasi tahun yg di ambil harus sama dari tgl awal dan tgl akhir 
                If thn1 = thn2 And thn1 <> thn3 Then
                    'cek apakah saldo berjalan staff ini 2018 /2019
                    Response.Write("<script>alert('Hanya di Perbolehkan mengambil Izin Di Tahun yang Sama dengan Tahun Berjalan')</script>")
                    Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                Else
                    Dim ts As TimeSpan = tgl_akhir.Subtract(tgl_awal)
                    ''0=senin, 1=selasa, 2=rabu, 3=kamis, 4=jumat, 5=sabtu, 6=minggu
                    '*****Temukan Jumlah Hari yang Di Ajukan 
                    Dim DayInterval2 As String = DateDiff(DateInterval.Day, tgl_awal, tgl_akhir)
                    '**Input Hari yang di ajukan ke dalam array -- assign date time range value to array
                    For i As Integer = 0 To DayInterval2
                        dateList.Add(tgl_awal.AddDays(i))
                    Next
                    '**save date setelah eliminasi hari minggu menjadi array baru 
                    For Each item As DateTime In dateList
                        If item.DayOfWeek <> 0 Then
                            dateListNotMinggu.Add(item)
                        End If
                    Next
                    '**get date time blocked by predefine
                    Call GetData_ListTglPre("select * from data_izin_libur")
                    '**remove arraylist dateListNotMinggu yg data nya sama dengan array list dateListDead
                    Dim d, x As Integer
                    For x = 0 To dateListDead.Count - 1
                        For d = dateListNotMinggu.Count - 1 To 0 Step -1
                            If dateListNotMinggu(d) = dateListDead(x) Then
                                dateListNotMinggu.RemoveAt(d)
                            End If
                        Next
                    Next
                    '**tampilkan tgl fix untuk insert ke database (dateListNotMinggu)
                    For Each items As DateTime In dateListNotMinggu
                        'Response.Write("<script>alert('Hari Fix :  " + items + "')</script>")
                    Next
                End If
                '***Validasi Alasan Detail Cuti dan tgl pengajuan
                '***Tambahkan Validasi jika saldo 0
                If TxtCutiAlasanDetail.Text = "" Then
                    Response.Write("<script>alert('Data Alasan Detail pada Pengajuan Tidak Boleh Kosong! Ulangi Kembali')</script>")
                    Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                Else
                    Dim jmltgl As Integer = Convert.ToInt32(dateListNotMinggu.Count) 'jml tgl cuti yang di ajukan 
                    'Core Process
                    jenis_izin = LabelJenisIzin.Text
                    If jenis_izin = "Tidak Masuk Kantor" Then 'Proses Pengajuan Tidak Masuk Kantor Down below*****************************************************************************************************************************************************************************************************************************
                        '***Local Variabel
                        Dim JnsIzin As String = "Tidak Masuk Kantor"
                        Dim tgldead As DateTime = FormatDateTime(Now.AddDays(+6), DateFormat.ShortDate)
                        Dim datenowher As DateTime = FormatDateTime(Now, DateFormat.ShortDate)
                        '**Process Insert Tidak Masuk Kantor
                        If UpdateData_Server("INSERT INTO DATA_IZIN_BODY_sales (IZIN_ALASANDETAIL, IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtCutiAlasanDetail.Text & "','" & TxtBulanCuti.Text & "','" & cabang.Text & "','" & TxtPetik(DropDownListTidakMasukKantor.Text) & "','" & JnsIzin & "','" & TxtCutiTahun.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "MyConnCloudDnet2") = 1 Then
                            'Response.Write("<script>alert('Jenis Tidak Masuk : " + DropDownListTidakMasuk.Text + "')</script>")
                            '=======
                            If Page.IsValid And DropDownListTidakMasukKantor.Text = "Sakit Surat Dokter" Then
                                'If the Default.aspx validation is true (for example if the uploaded file is of correct file type, then process the rest of the script.
                                Dim filereceived As String = FileUpload1.PostedFile.FileName
                                Dim filename As String = Path.GetFileName(filereceived)
                                Dim EditDataStafffoto As String
                                If filereceived = "" Then 'validasi file upload tidak boleh kosong
                                    Response.Write("<script>alert('Anda Harus Mengupload File. Proses Pengajuan Tidak Masuk Kantor Gagal.')</script>")
                                    'get id top 1 idizin_pertama
                                    Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                    'delete id top 1 data izin body
                                    Dim deletepengajuangagal As String = "delete from data_izin_body_sales where izin_id = '" & idizin_pertama & "'"
                                    Call UpdateData_Server(deletepengajuangagal, "MyConnCloudDnet2")
                                    Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                                Else
                                    'get data staff id 
                                    Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                    EditDataStafffoto = "UPDATE data_izin_body_sales SET IZIN_FILEDETAIL='" & filename & "' WHERE  IZIN_ID='" & idizin_pertama & "'"
                                    Call UpdateData_Server(EditDataStafffoto, "MyConnCloudDnet2")

                                    'Dim fileuploadpath As String = "D:\Herlambang\Data_IzinSales_14_1_2019\img\FileUpload"
                                    'C:\inetpub\wwwroot\Data_IzinSales_14_1_2019\img\FileUpload
                                    Dim fileuploadpath As String = "C:\inetpub\wwwroot\Data_IzinSales_14_1_2019\img\FileUpload\"
                                    'Dim Fileuploadpath As String = "D:/Herlambang/November-Ongoing - Revisi Input Data Izin (Table)/LiveMUGENASP/TestFromUpload/MugenASPHRISO_10_22_018/img/imgstaff/"
                                    FileUpload1.PostedFile.SaveAs(Path.Combine(fileuploadpath, filename))
                                    'FileUpload1.SaveAs(Server.MapPath("~inetpub/wwwroot/MugenASPHRISO/WEBDOWNLOAD/FOTOIZIN") & filename)
                                    'FileUpload1.SaveAs(Server.MapPath("~") & filename)
                                    Response.Write("<script>alert('Berhasil Input Data Izin Sales')</script>")
                                End If
                                'Dim filename As String = Path.GetFileName(ImageFileUpload.FileName)
                                'ImageFileUpload.SaveAs(Server.MapPath("~/nForum/uploads/") & filename)
                            End If
                            '=======
                            Response.Write("<script>alert('Berhasil Input Data Izin Sales')</script>")
                        Else
                            Response.Write("<script>alert('Gagal Input Data Izin Sales')</script>")
                        End If
                        'Call UpdateData_Server("INSERT INTO DATA_IZIN_BODY (IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_TAHUN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtStaffNIKMaster.Text & "','" & TxtPetik(DropDownListCuti.Text) & "','" & JnsIzin & "','" & TxtTahunCuti.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "")
                        Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                        'Response.Write("<script>alert('Value : " + idizin_pertama + "')</script>")
                        'insert data_izin_detail (list tanggal yang di ajkuan)
                        For Each items As DateTime In dateListNotMinggu
                            Call UpdateData_Server("insert into DATA_IZIN_DETAIL_sales (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & cabang.Text & "')", "MyConnCloudDnet2")
                        Next
                        'insert data_izin_detail 
                        'For i As Integer = 0 To x - 1
                        '    'Response.Write("<script>alert('Value : " + tglarry(i) + "')</script>")
                        '    Call UpdateData_Server("insert into DATA_IZIN_DETAIL (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & Convert.ToDateTime(tglarry(i)) & "', '" & TxtStaffNIKMaster.Text & "')", "")
                        '    'Response.Write("<script>alert('Berhasil Input Data Detail Izin Staff')</script>")
                        'Next
                        '================call function to email atasan
                        Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                        'email ke atasan 1
                        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + nama.Text + " dengan NIK " + cabang.Text + " dan tanggal Pengajuan " + DateTime.Now + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailatasan.Text)
                        Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                    Else '***Proses Pengajuan Cuti -- Down below*****************************************************************************************************************************************************************************************************************************
                        'validasi jenis cuti 
                        JCuti_P = DropDownListCutiAlasan.Text
                        If JCuti_P = "Cuti" Then 'cuti biasa
                            'Response.Write("<script>alert('Cuti')</script>")
                            Dim JnsIzin As String = "Cuti"
                            Dim tgldead As DateTime = FormatDateTime(Now.AddDays(+6), DateFormat.ShortDate) 'tanggal deadline appv
                            Dim datenowher As DateTime = FormatDateTime(Now, DateFormat.ShortDate) 'tanggal pengajuan izin
                            'get detail saldo staff

                            'pisahkan tanggal yang di ajukan menjadi tanggal pending cuti dan not pending cuti ke dalam array

                            For Each item As DateTime In dateListNotMinggu
                                Call Real_saldoStaff("select IZIN_SALDO, IZIN_SALDO_CUTI_TAHUNAN_BERLAKU, IZIN_SALDO_PC, IZIN_SALDO_PC_BERLAKU from DATA_IZIN_HEADER_SALES where IZIN_NIK ='" & cabang.Text & "'")
                                Dim a As Integer = saldo_tahunan
                                Dim b As DateTime = saldo_tahunanberlaku
                                Dim c As Integer = saldo_pending
                                Dim d As DateTime = saldo_pendingberlaku
                                If item <= saldo_pendingberlaku Then
                                    arr_pc.Add(item)
                                    'Response.Write("<script>alert('add db---" + item + "!')</script>")
                                    'buat logic [jika tgl pengajuan di pending cuti melebihi saldo pending cuti. tanggal yg melebihi akan di masukan ke tgl pengajuan saldo tahunan]
                                ElseIf item > saldo_pendingberlaku And item <= saldo_tahunanberlaku Then
                                    arr_notpc.Add(item)
                                End If
                            Next
                            '*********************test case
                            'For Each item In arr_pc
                            '    Response.Write("<script>alert('pc terpilih--" + item + "!')</script>")
                            'Next
                            'For Each item In arr_notpc
                            '    Response.Write("<script>alert('npc terpilih---" + item + "!')</script>")
                            'Next
                            '*********************test case

                            'case 1 : cek apakah arr_pc > saldo_pending, jika ya maka pindahkan jml tanggal ke arry_temp_pc. jika tidak maka keep arr_pc
                            'case 2 : cek apakah arr_notpc > saldo_tahunan, jika ya maka hapus tgl di arr_not pc sesuai jumlah  
                            'NEW ADDED LOGIC=================================================
                            'case 1 : cek apakah arr_pc > saldo_pending, jika ya maka pindahkan jml tanggal ke arry_temp_pc. jika tidak maka keep arr_pc
                            ''If arr_pc.Count > saldo_pending Then
                            ''    Dim selisih_pc As Integer
                            ''    selisih_pc = arr_pc.Count - saldo_pending '5-1=4
                            ''    'pindahkan ke arr_temp
                            ''    For i As Integer = 0 To selisih_pc - 1
                            ''        arr_temp.Add(arr_pc(i))
                            ''    Next
                            ''    'remove tgl tersebut di arr_pc
                            ''    Dim d, x As Integer
                            ''    For x = 0 To arr_temp.Count - 1
                            ''        For d = arr_pc.Count - 1 To 0 Step -1
                            ''            If arr_pc(d) = arr_temp(x) Then
                            ''                arr_pc.RemoveAt(d)
                            ''            End If
                            ''        Next
                            ''    Next
                            ''    'sekarang posisi arr_pc = saldo_pending. dan arr_temp berisi sisa tgl yg di luar jml saldo pending
                            ''End If
                            ''**hapus arr_notpc yg melebihi jml saldo_tahunan
                            ''If arr_notpc.Count > saldo_tahunan Then
                            ''    Dim x As Integer = arr_notpc.Count - saldo_tahunan
                            ''    Dim d As Integer
                            ''    For d = arr_notpc.Count - 1 To arr_notpc.Count - x Step -1
                            ''        If arr_notpc(d) <= saldo_tahunanberlaku Then
                            ''            'Response.Write("<script>alert('remove tgl : " + arr_notpc(d) + "')</script>")
                            ''            arr_notpc.RemoveAt(d)
                            ''        End If
                            ''    Next
                            ''    'sekarang posisi arr_notpc = saldo_tahunan
                            ''    'cek jika arr_temp.count >0 Y=REMOVE arr_notpc sesuai jumlah arr_tem.count //
                            ''    If arr_temp.Count > 0 Then
                            ''        Dim z As Integer = arr_temp.Count
                            ''        For d = arr_notpc.Count - 1 To arr_notpc.Count - z Step -1
                            ''            'If arr_notpc(d) <= saldo_tahunanberlaku Then
                            ''            'Response.Write("<script>alert('remove tgl : " + arr_notpc(d) + "')</script>")
                            ''            arr_notpc.RemoveAt(d)
                            ''            'End If
                            ''        Next
                            ''    End If
                            ''    'masukan tgl lebihan arr_pc ke arr_notpc
                            ''    For Each item In arr_temp
                            ''        arr_notpc.Add(item)
                            ''    Next
                            ''ElseIf arr_notpc.Count <= saldo_tahunan Then  'jika arr_notpc <=saldotahunan and arr_tem > 0 
                            ''    If arr_temp.Count > 0 Then
                            ''        'tambahkan arr_temp ke arr_notpc
                            ''        For Each item In arr_temp
                            ''            arr_notpc.Add(item)
                            ''        Next
                            ''        'loop semua index dengan for dan berhenti ketika variabel a nilainya selisih saldo tahunan dengan arr_notpc
                            ''        Dim q As Integer
                            ''        Dim w As Integer
                            ''        Dim r As Integer = 0
                            ''        If arr_notpc.Count > saldo_tahunan Then
                            ''            w = arr_notpc.Count - saldo_tahunan
                            ''        End If
                            ''        For q = arr_notpc.Count - 1 To 0 Step -1
                            ''            If r <= w Then
                            ''                If arr_notpc(q) <= saldo_tahunanberlaku And arr_notpc(q) > saldo_pendingberlaku Then
                            ''                    'remove
                            ''                    arr_notpc.RemoveAt(q)
                            ''                    r = r + 1
                            ''                End If
                            ''            Else
                            ''            End If
                            ''        Next
                            ''    End If
                            ''End If
                            'VeryNew added logic========================================
                            'cek array pc apakah lebih dari jml saldo pc, jika ya = save ke arr_temp dan delete di arr_pc
                            If arr_pc.Count > saldo_pending Then
                                Dim selisihpending As Integer = arr_pc.Count - saldo_pending
                                For i As Integer = 0 To selisihpending - 1
                                    arr_temp.Add(arr_pc(i))
                                Next
                                'remove tgl tersebut di arr_pc
                                Dim d, x As Integer
                                For x = 0 To arr_temp.Count - 1
                                    For d = arr_pc.Count - 1 To 0 Step -1
                                        If arr_pc(d) = arr_temp(x) Then
                                            arr_pc.RemoveAt(d)
                                        End If
                                    Next
                                Next 'sekarang kondisi arr_pc = saldo pc
                            End If
                            'cek array not pc apakah lebih dari jml saldo not pc, jika ya remove
                            If arr_notpc.Count > saldo_tahunan Then
                                Dim selisihtahun As Integer = arr_notpc.Count - saldo_tahunan
                                For d = arr_notpc.Count - 1 To arr_notpc.Count - selisihtahun Step -1
                                    arr_notpc.RemoveAt(d)
                                Next
                            End If
                            'cek apakah arr_temp memiliki value -- comment 'jika arr_notpc <> 0
                            If arr_temp.Count > 0 And arr_temp.Count < saldo_tahunan And arr_notpc.Count <> 0 Then
                                'remove tgl tersebut di arr_notpc
                                Dim d As Integer
                                For d = arr_notpc.Count - 1 To arr_notpc.Count - arr_temp.Count Step -1
                                    arr_notpc.RemoveAt(d)
                                Next
                                'masukan tgl arr_temp ke arr_notpc
                                For a As Integer = 0 To arr_temp.Count - 1
                                    arr_notpc.Add(arr_temp(a))
                                Next
                            End If
                            'jika arr_notpc = 0 
                            If arr_temp.Count > 0 And arr_notpc.Count = 0 Then
                                'input tgl arr_temp ke arr_notpc sebanyak jml saldo tahunan, di validasi dulu apakah arr_temp lebih besar = dari saldo tahunan
                                If arr_temp.Count >= saldo_tahunan Then
                                    For a As Integer = 0 To saldo_tahunan - 1
                                        arr_notpc.Add(arr_temp(a))
                                    Next
                                End If
                            End If
                            '*********************test case
                            'Response.Write("<script>alert('pc--" + Convert.ToString(arr_pc.Count) + "!')</script>")
                            'Response.Write("<script>alert('Npc--" + Convert.ToString(arr_notpc.Count) + "!')</script>")
                            'Response.Write("<script>alert('tmp--" + Convert.ToString(arr_temp.Count) + "!')</script>")
                            'For Each item In arr_pc
                            '    Response.Write("<script>alert('pc--" + item + "!')</script>")
                            'Next
                            'For Each item In arr_temp
                            '    Response.Write("<script>alert('temp--" + item + "!')</script>")
                            'Next
                            'For Each item In arr_notpc
                            '    Response.Write("<script>alert('npc---" + item + "!')</script>")
                            'Next
                            '*********************test case
                            '***coreprocess
                            'validasi apakah arr_pc = saldo pc dan arr_npc = saldo_thn
                            If arr_pc.Count = saldo_pending And arr_notpc.Count = saldo_tahunan Then
                                '******proses insert data pengajuan***************************************************
                                '2 variabel mewakili jml saldo izin tahunan dan saldo pending cuti. untuk dikurangi dengan saldo yg berjalan di database
                                Dim saldo_tahunanfinal As Integer
                                Dim saldo_cutifinal As Integer
                                saldo_tahunanfinal = arr_notpc.Count
                                saldo_cutifinal = arr_pc.Count

                                '***********************insert data_izin_body
                                If UpdateData_Server("INSERT INTO DATA_IZIN_BODY_sales (IZIN_ALASANDETAIL,IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtCutiAlasanDetail.Text & "','" & TxtBulanCuti.Text & "','" & cabang.Text & "','" & TxtPetik(DropDownListCutiAlasan.Text) & "','" & JnsIzin & "','" & TxtCutiTahun.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "MyConnCloudDnet2") = 1 Then
                                    Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                    Response.Write("<script>alert('ID IZIN ANDA : " + idizin_pertama + "')</script>")

                                    'insert data_izin_detail (list tanggal yang di ajkuan)
                                    If saldo_tahunanfinal <> 0 Then
                                        For Each items As DateTime In arr_notpc
                                            Call UpdateData_Server("insert into DATA_IZIN_DETAIL_sales (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & cabang.Text & "')", "MyConnCloudDnet2")
                                        Next
                                    End If
                                    If saldo_cutifinal <> 0 Then
                                        For Each items As DateTime In arr_pc
                                            Call UpdateData_Server("insert into DATA_IZIN_DETAILPC_sales (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & cabang.Text & "')", "MyConnCloudDnet2")
                                        Next
                                    End If
                                    Response.Write("<script>alert('Berhasil Input Data Izin sales')</script>")
                                Else
                                    Response.Write("<script>alert('Gagal Input Data Izin sales')</script>")
                                End If
                                '*************************NOTIFIKASI EMAIL
                                ''================call function to email atasan
                                'Get ID IZIN Terbaru****
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                'Response.Write("<script>alert('ID Izin Terbaru : " + idizin_pertama + "')</script>")
                                'Response.Write("<script>alert('Email Atasan = " + emailatasan.Text + "')</script>")
                                'email ke atasan 1***
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + nama.Text + " dengan NIK " + cabang.Text + " dan tanggal Pengajuan " + DateTime.Now + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailatasan.Text)
                                '****CLEAR ARRAY LIST
                                arr_notpc.Clear()
                                arr_pc.Clear()
                                arr_temp.Clear()
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            Else
                                'gagal update, tgl yg di ajukan lebih dari saldo tahunan dan saldo pending cuti
                            End If



                            ''DICOMMENT =============================================================================================
                            ''cek apakah tgl yg di ajukan lebih dari jml saldo izin tahunan. jika lebih maka gagal proses save
                            'If arr_notpc.Count > saldo_tahunan Then 'MENGHAPUS TGL YANG LEBIH DARI JML SALDO TAHUNAN
                            '    Response.Write("<script>alert('Jumlah Tanggal yang anda ajukan lebih dari jumlah saldo izin tahunan anda. Tanggal tersebut akan di hapus. Silahkan cek detail nya pada Menu List Izin !')</script>")
                            '    'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            '    '[remove tgl yang lebih dari jml saldo tahunan]CEK APAKAH ADA TGL YG LEBIH DARI JML SALDO TAHUNAN
                            '    If saldo_tahunan < arr_notpc.Count Then
                            '        Dim x As String = arr_notpc.Count - saldo_tahunan
                            '        'Response.Write("<script>alert('remove tgl : " + x + "')</script>")
                            '        Dim d As Integer
                            '        For d = arr_notpc.Count - 1 To arr_notpc.Count - x Step -1
                            '            If arr_notpc(d) <= saldo_tahunanberlaku Then
                            '                'Response.Write("<script>alert('remove tgl : " + arr_notpc(d) + "')</script>")
                            '                arr_notpc.RemoveAt(d)
                            '            End If
                            '        Next
                            '    End If
                            'ElseIf arr_pc.Count > saldo_pending Then
                            '    Response.Write("<script>alert('Tgl yang anda ajukan, lebih dari jumlah pending cuti anda. sisa pengajuan akan mengurangi saldo cuti tahunan anda!')</script>")
                            '    'cek selisih saldo pending dengan tgl pengajuan pending [a]. 
                            '    Dim selisihpending As Integer
                            '    selisihpending = saldo_pending - arr_pc.Count
                            '    'cek selisih saldo tahunan dan tgl yg di ambil pada saldo tahunan[b]. 
                            '    'Response.Write("<script>alert('Selisih pending : " + selisihpending + "')</script>")
                            '    Dim selisihtahunan As Integer
                            '    selisihtahunan = saldo_tahunan - arr_notpc.Count
                            '    'Response.Write("<script>alert('Selisih Tahunan : " + selisihtahunan + "')</script>")
                            '    If selisihtahunan < 0 And selisihpending < 0 Then
                            '        'Response.Write("<script>alert('Selisih Tahunan = 0')</script>")
                            '        'sisa saldo tahunan tidak ada. atau 0 ' jika 0 maka proses gagal
                            '        Response.Write("<script>alert('Saldo Cuti Tahunan anda Telah habis. Pengurangan saldo cuti tahunan gagal. Proses pengajuan gagal!')</script>")
                            '        Response.Write("<script>window.location.href='home.aspx';</script>")
                            '    ElseIf selisihtahunan >= 0 And selisihpending >= 0 Then
                            '        If selisihpending = selisihtahunan Then 'jika [a] dam [b] sama maka pindahkan
                            '            'simpan nilai nya di array temporary
                            '            'For Each item As DateTime In arr_pc
                            '            '    arr_temp.Add(item)
                            '            'Next
                            '            '*** masukan array PC ke array temporary
                            '            For i As Integer = 0 To selisihpending - 1
                            '                arr_temp.Add(arr_pc(i))
                            '            Next
                            '            'For Each item As DateTime In arr_pc
                            '            '    For Each itemz As DateTime In arr_temp
                            '            '        If item = itemz Then
                            '            '            'Response.Write("<script>alert('Ini tgl yg dipindahkan " + itemz + "')</script>")
                            '            '        End If
                            '            '    Next
                            '            'Next

                            '            'remove tgl tersebut di arr_pc
                            '            Dim d, x As Integer
                            '            For x = 0 To arr_temp.Count - 1
                            '                For d = arr_pc.Count - 1 To 0 Step -1
                            '                    If arr_pc(d) = arr_temp(x) Then
                            '                        arr_pc.RemoveAt(d)
                            '                    End If
                            '                Next
                            '            Next
                            '            'add tgl tersebut di arr_notpc
                            '            For a As Integer = 0 To arr_temp.Count - 1
                            '                arr_notpc.Add(arr_temp(a))
                            '            Next
                            '            '** validasi input saldo pc dan not pc harus <= saldo pending dan saldo tahunan

                            '            '******proses insert data pengajuan***************************************************
                            '            '2 variabel mewakili jml saldo izin tahunan dan saldo pending cuti. untuk dikurangi dengan saldo yg berjalan di database
                            '            Dim saldo_tahunanfinal As Integer
                            '            Dim saldo_cutifinal As Integer
                            '            saldo_tahunanfinal = arr_notpc.Count
                            '            saldo_cutifinal = arr_pc.Count

                            '            '***********************insert data_izin_body
                            '            If UpdateData_Server("INSERT INTO DATA_IZIN_BODY_sales (IZIN_ALASANDETAIL,IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtCutiAlasanDetail.Text & "','" & TxtBulanCuti.Text & "','" & cabang.Text & "','" & TxtPetik(DropDownListCutiAlasan.Text) & "','" & JnsIzin & "','" & TxtCutiTahun.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "MyConnCloudDnet2") = 1 Then
                            '                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                            '                Response.Write("<script>alert('ID IZIN ANDA : " + idizin_pertama + "')</script>")

                            '                'insert data_izin_detail (list tanggal yang di ajkuan)
                            '                If saldo_tahunanfinal <> 0 Then
                            '                    For Each items As DateTime In arr_notpc
                            '                        Call UpdateData_Server("insert into DATA_IZIN_DETAIL_sales (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & cabang.Text & "')", "MyConnCloudDnet2")
                            '                    Next
                            '                End If
                            '                If saldo_cutifinal <> 0 Then
                            '                    For Each items As DateTime In arr_pc
                            '                        Call UpdateData_Server("insert into DATA_IZIN_DETAILPC_sales (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & cabang.Text & "')", "MyConnCloudDnet2")
                            '                    Next
                            '                End If
                            '                Response.Write("<script>alert('Berhasil Input Data Izin sales')</script>")
                            '            Else
                            '                Response.Write("<script>alert('Gagal Input Data Izin sales')</script>")
                            '            End If
                            '            '*************************NOTIFIKASI EMAIL
                            '            ''================call function to email atasan
                            '            'Get ID IZIN Terbaru****
                            '            Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                            '            'Response.Write("<script>alert('ID Izin Terbaru : " + idizin_pertama + "')</script>")
                            '            'Response.Write("<script>alert('Email Atasan = " + emailatasan.Text + "')</script>")
                            '            'email ke atasan 1***
                            '            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + nama.Text + " dengan NIK " + cabang.Text + " dan tanggal Pengajuan " + DateTime.Now + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailatasan.Text)
                            '            '****CLEAR ARRAY LIST
                            '            arr_notpc.Clear()
                            '            arr_pc.Clear()
                            '            arr_temp.Clear()
                            '            Response.Write("<script>window.location.href='home.aspx';</script>")
                            '        Else ' jika tidak maka proses gagal '
                            '            Response.Write("<script>alert('Proses pengurangan saldo cuti gagal, karena jumlah selisih pending cuti dan selisih izin tidak sama!')</script>")
                            '            Response.Write("<script>window.location.href='home.aspx';</script>")
                            '        End If
                            '    End If
                            'End If
                            ''*********************test case
                            ''For Each item In arr_notpc
                            ''    Response.Write("<script>alert('tgl not pc : " + item + "!')</script>")
                            ''Next
                            ''For Each item In arr_pc
                            ''    Response.Write("<script>alert('tgl pc : " + item + "!')</script>")
                            ''Next
                            ''*********************test case


                            ''**BELUM TEST PENGAJUAN DENGAN KONDISI PENDING CUTI ADA
                        ElseIf JCuti_P = "Cuti2" Then 'Cuti Melahirkan
                            Dim AlsIzin As String = "Cuti Melahirkan"
                            Dim tglMelahirkan1 As DateTime = tgl_awal
                            Dim tglMelahirkan2 As DateTime = tgl_awal.AddDays(90) ' Pengajuan Cuti Otomatis akan bertambah 90 Hari sesuai dengan tanggal awal yang di ajukan 
                            Dim dateListMelahirkan As List(Of DateTime) = New List(Of DateTime)() 'array tgl melahirkan
                            dateListMelahirkan.Add(tglMelahirkan1)
                            dateListMelahirkan.Add(tglMelahirkan2)
                            Dim tgldead As DateTime = FormatDateTime(Now.AddDays(+6), DateFormat.ShortDate) 'tanggal deadline appv
                            Dim datenowher As DateTime = FormatDateTime(Now, DateFormat.ShortDate) 'tanggal pengajuan izin

                            'insert data_izin_body
                            'alasandandetail = TxtPetik(DropDownListCuti.Text) + " / " + TxtAlasanIzinDetail.Text
                            If UpdateData_Server("INSERT INTO DATA_IZIN_BODY_SALES (IZIN_ALASANDETAIL,IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtCutiAlasanDetail.Text & "','" & TxtBulanCuti.Text & "','" & cabang.Text & "','" & AlsIzin & "','Cuti','" & TxtCutiTahun.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "MyConnCloudDnet2") = 1 Then
                                Response.Write("<script>alert('Berhasil Input Data Izin sales')</script>")
                            Else
                                Response.Write("<script>alert('Gagal Input Data Izin sales')</script>")
                            End If
                            'get latest data_izin_body record
                            Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_SALES order by izin_id desc", "MyConnCloudDnet2")
                            Response.Write("<script>alert('ID IZIN ANDA : " + idizin_pertama + "')</script>")
                            'insert data_izin_detail (list tanggal yang di ajkuan)
                            For Each items As DateTime In dateListMelahirkan
                                Call UpdateData_Server("insert into DATA_IZIN_DETAIL_SALES (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & cabang.Text & "')", "MyConnCloudDnet2")
                            Next
                            '================call function to email atasan
                            Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                            'email ke atasan 1
                            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + nama.Text + " dengan NIK " + cabang.Text + " dan tanggal Pengajuan " + DateTime.Now + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailatasan.Text)
                            Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                        ElseIf JCuti_P = "Cuti3" Then 'Cuti Istimewa -- Menikah
                            If jmltgl > 3 Then 'Pembatasan Jumlah tanggal 
                                Response.Write("<script>alert('Tanggal yang anda ajukan lebih dari batas pengajuan Cuti Menikah (3 Hari)')</script>")
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            Else
                                'insert data_izin_body untuk cuti
                                Dim AlsIzin As String = "Cuti Istimewa -- Menikah"
                                Dim tgldead As DateTime = FormatDateTime(Now.AddDays(+6), DateFormat.ShortDate) 'tanggal deadline appv
                                Dim datenowher As DateTime = FormatDateTime(Now, DateFormat.ShortDate) 'tanggal pengajuan izin
                                '***insert data_izin_body
                                'alasandandetail = TxtPetik(DropDownListCuti.Text) + " / " + TxtAlasanIzinDetail.Text
                                If UpdateData_Server("INSERT INTO DATA_IZIN_BODY_sales (IZIN_ALASANDETAIL,IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtCutiAlasanDetail.Text & "','" & TxtBulanCuti.Text & "','" & cabang.Text & "','" & AlsIzin & "','Cuti','" & TxtCutiTahun.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "MyConnCloudDnet2") = 1 Then
                                    Response.Write("<script>alert('Berhasil Input Data Izin sales')</script>")
                                Else
                                    Response.Write("<script>alert('Gagal Input Data Izin sales')</script>")
                                End If
                                'Call UpdateData_Server("INSERT INTO DATA_IZIN_BODY (IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_TAHUN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtStaffNIKMaster.Text & "','" & TxtPetik(DropDownListCuti.Text) & "','" & JnsIzin & "','" & TxtTahunCuti.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "")
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                Response.Write("<script>alert('ID IZIN ANDA : " + idizin_pertama + "')</script>")
                                '***insert data_izin_detail (list tanggal yang di ajkuan)
                                For Each items As DateTime In dateListNotMinggu
                                    Call UpdateData_Server("insert into DATA_IZIN_DETAIL_sales (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & cabang.Text & "')", "MyConnCloudDnet2")
                                Next

                                '================call function to email atasan
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                'email ke atasan 1
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + nama.Text + " dengan NIK " + cabang.Text + " dan tanggal Pengajuan " + DateTime.Now + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailatasan.Text)
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            End If
                        ElseIf JCuti_P = "Cuti4" Then 'Cuti Istimewa -- Orang Tua / Mertua Meninggal
                            If jmltgl > 1 Then
                                Response.Write("<script>alert('Tanggal yang anda ajukan lebih dari batas pengajuan Cuti Orangtua Meninggal (1 Hari)')</script>")
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            Else
                                'Response.Write("<script>alert('Tanggal yang anda ajukan Cocok')</script>")
                                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                Dim AlsIzin As String = "Cuti Istimewa -- Orang Tua/Mertua Meninggal"

                                Dim tgldead As DateTime = FormatDateTime(Now.AddDays(+6), DateFormat.ShortDate) 'tanggal deadline appv
                                Dim datenowher As DateTime = FormatDateTime(Now, DateFormat.ShortDate) 'tanggal pengajuan izin

                                'insert data_izin_body
                                'alasandandetail = TxtPetik(DropDownListCuti.Text) + " / " + TxtAlasanIzinDetail.Text
                                If UpdateData_Server("INSERT INTO DATA_IZIN_BODY_sales (IZIN_ALASANDETAIL,IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtCutiAlasanDetail.Text & "','" & TxtBulanCuti.Text & "','" & cabang.Text & "','" & AlsIzin & "','Cuti','" & TxtCutiTahun.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "MyConnCloudDnet2") = 1 Then
                                    Response.Write("<script>alert('Berhasil Input Data Izin sales')</script>")
                                Else
                                    Response.Write("<script>alert('Gagal Input Data Izin sales')</script>")
                                End If
                                'Call UpdateData_Server("INSERT INTO DATA_IZIN_BODY (IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_TAHUN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtStaffNIKMaster.Text & "','" & TxtPetik(DropDownListCuti.Text) & "','" & JnsIzin & "','" & TxtTahunCuti.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "")
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                Response.Write("<script>alert('ID IZIN ANDA : " + idizin_pertama + "')</script>")
                                'insert data_izin_detail (list tanggal yang di ajkuan)
                                For Each items As DateTime In dateListNotMinggu
                                    Call UpdateData_Server("insert into DATA_IZIN_DETAIL_sales (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & cabang.Text & "')", "MyConnCloudDnet2")
                                Next

                                '================call function to email atasan
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                'email ke atasan 1
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + nama.Text + " dengan NIK " + cabang.Text + " dan tanggal Pengajuan " + DateTime.Now + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailatasan.Text)
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            End If
                        ElseIf JCuti_P = "Cuti5" Then 'Cuti Istimewa -- Bencana Alam
                            If jmltgl > 1 Then
                                Response.Write("<script>alert('Tanggal yang anda ajukan lebih dari batas pengajuan Cuti Bencana Alam (1 Hari)')</script>")
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            Else
                                'Response.Write("<script>alert('Tanggal yang anda ajukan Cocok')</script>")
                                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                Dim AlsIzin As String = "Cuti Istimewa -- Bencana Alam"

                                Dim tgldead As DateTime = FormatDateTime(Now.AddDays(+6), DateFormat.ShortDate) 'tanggal deadline appv
                                Dim datenowher As DateTime = FormatDateTime(Now, DateFormat.ShortDate) 'tanggal pengajuan izin

                                'insert data_izin_body
                                If UpdateData_Server("INSERT INTO DATA_IZIN_BODY_sales (IZIN_ALASANDETAIL,IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtCutiAlasanDetail.Text & "','" & TxtBulanCuti.Text & "','" & cabang.Text & "','" & AlsIzin & "','Cuti','" & TxtCutiTahun.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "MyConnCloudDnet2") = 1 Then
                                    Response.Write("<script>alert('Berhasil Input Data Izin Sales')</script>")
                                Else
                                    Response.Write("<script>alert('Gagal Input Data Izin Sales')</script>")
                                End If
                                'Call UpdateData_Server("INSERT INTO DATA_IZIN_BODY (IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_TAHUN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtStaffNIKMaster.Text & "','" & TxtPetik(DropDownListCuti.Text) & "','" & JnsIzin & "','" & TxtTahunCuti.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "")
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                Response.Write("<script>alert('ID IZIN ANDA : " + idizin_pertama + "')</script>")
                                'insert data_izin_detail (list tanggal yang di ajkuan)
                                For Each items As DateTime In dateListNotMinggu
                                    Call UpdateData_Server("insert into DATA_IZIN_DETAIL_sales (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & cabang.Text & "')", "MyConnCloudDnet2")
                                Next

                                '================call function to email atasan
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                'email ke atasan 1
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + nama.Text + " dengan NIK " + cabang.Text + " dan tanggal Pengajuan " + DateTime.Now + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailatasan.Text)
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            End If
                        ElseIf JCuti_P = "Cuti6" Then 'Cuti Istimewa -- Keluarga Meninggal SeAtap
                            If jmltgl > 1 Then
                                Response.Write("<script>alert('Tanggal yang anda ajukan lebih dari batas pengajuan Cuti Keluarga Meninggal (1 Hari)')</script>")
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            Else
                                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                Dim AlsIzin As String = "Cuti Istimewa -- Keluarga Meninggal SeAtap"

                                Dim tgldead As DateTime = FormatDateTime(Now.AddDays(+6), DateFormat.ShortDate) 'tanggal deadline appv
                                Dim datenowher As DateTime = FormatDateTime(Now, DateFormat.ShortDate) 'tanggal pengajuan izin

                                'insert data_izin_body
                                'alasandandetail = TxtPetik(DropDownListCuti.Text) + " / " + TxtAlasanIzinDetail.Text
                                If UpdateData_Server("INSERT INTO DATA_IZIN_BODY_sales (IZIN_ALASANDETAIL,IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtCutiAlasanDetail.Text & "','" & TxtBulanCuti.Text & "','" & cabang.Text & "','" & AlsIzin & "','Cuti','" & TxtCutiTahun.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "MyConnCloudDnet2") = 1 Then
                                    Response.Write("<script>alert('Berhasil Input Data Izin sales')</script>")
                                Else
                                    Response.Write("<script>alert('Gagal Input Data Izin sales')</script>")
                                End If
                                'Call UpdateData_Server("INSERT INTO DATA_IZIN_BODY (IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_TAHUN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtStaffNIKMaster.Text & "','" & TxtPetik(DropDownListCuti.Text) & "','" & JnsIzin & "','" & TxtTahunCuti.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "")
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                Response.Write("<script>alert('ID IZIN ANDA : " + idizin_pertama + "')</script>")
                                'insert data_izin_detail (list tanggal yang di ajkuan)
                                For Each items As DateTime In dateListNotMinggu
                                    Call UpdateData_Server("insert into DATA_IZIN_DETAIL_sales (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & cabang.Text & "')", "MyConnCloudDnet2")
                                Next

                                '================call function to email atasan
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY order by izin_id desc", "MyConnCloudDnet2")
                                'email ke atasan 1
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + nama.Text + " dengan NIK " + cabang.Text + " dan tanggal Pengajuan " + DateTime.Now + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailatasan.Text)
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            End If
                        ElseIf JCuti_P = "Cuti7" Then 'Cuti Istimewa -- Khitanan / Baptisan Anak
                            If jmltgl > 2 Then
                                Response.Write("<script>alert('Tanggal yang anda ajukan lebih dari batas pengajuan Cuti Khitan / Baptis (2 Hari)')</script>")
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            Else
                                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                Dim AlsIzin As String = "Cuti Istimewa -- Khitanan/Baptisan Anak"

                                Dim tgldead As DateTime = FormatDateTime(Now.AddDays(+6), DateFormat.ShortDate) 'tanggal deadline appv
                                Dim datenowher As DateTime = FormatDateTime(Now, DateFormat.ShortDate) 'tanggal pengajuan izin

                                'insert data_izin_body
                                'alasandandetail = TxtPetik(DropDownListCuti.Text) + " / " + TxtAlasanIzinDetail.Text
                                If UpdateData_Server("INSERT INTO DATA_IZIN_BODY_sales (IZIN_ALASANDETAIL,IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtCutiAlasanDetail.Text & "','" & TxtBulanCuti.Text & "','" & cabang.Text & "','" & AlsIzin & "','Cuti','" & TxtCutiTahun.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "MyConnCloudDnet2") = 1 Then
                                    Response.Write("<script>alert('Berhasil Input Data Izin sales')</script>")
                                Else
                                    Response.Write("<script>alert('Gagal Input Data Izin sales')</script>")
                                End If
                                'Call UpdateData_Server("INSERT INTO DATA_IZIN_BODY (IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_TAHUN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtStaffNIKMaster.Text & "','" & TxtPetik(DropDownListCuti.Text) & "','" & JnsIzin & "','" & TxtTahunCuti.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "")
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                Response.Write("<script>alert('ID IZIN ANDA : " + idizin_pertama + "')</script>")
                                'insert data_izin_detail (list tanggal yang di ajkuan)
                                For Each items As DateTime In dateListNotMinggu
                                    Call UpdateData_Server("insert into DATA_IZIN_DETAIL_sales (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & cabang.Text & "')", "MyConnCloudDnet2")
                                Next

                                '================call function to email atasan
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                'email ke atasan 1
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + nama.Text + " dengan NIK " + cabang.Text + " dan tanggal Pengajuan " + DateTime.Now + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailatasan.Text)
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            End If
                        ElseIf JCuti_P = "Cuti8" Then 'Cuti Istimewa -- Pernikahan Anak
                            If jmltgl > 2 Then
                                Response.Write("<script>alert('Tanggal yang anda ajukan lebih dari batas pengajuan Cuti Pernikahan Anak (2 Hari)')</script>")
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            Else
                                'Response.Write("<script>alert('Tanggal yang anda ajukan Cocok')</script>")
                                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                Dim AlsIzin As String = "Cuti Istimewa -- Pernikahan Anak"

                                Dim tgldead As DateTime = FormatDateTime(Now.AddDays(+6), DateFormat.ShortDate) 'tanggal deadline appv
                                Dim datenowher As DateTime = FormatDateTime(Now, DateFormat.ShortDate) 'tanggal pengajuan izin

                                'insert data_izin_body
                                'alasandandetail = TxtPetik(DropDownListCuti.Text) + " / " + TxtAlasanIzinDetail.Text
                                If UpdateData_Server("INSERT INTO DATA_IZIN_BODY_sales (IZIN_ALASANDETAIL,IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtCutiAlasanDetail.Text & "','" & TxtBulanCuti.Text & "','" & cabang.Text & "','" & AlsIzin & "','Cuti','" & TxtCutiTahun.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "MyConnCloudDnet2") = 1 Then
                                    Response.Write("<script>alert('Berhasil Input Data Izin sales')</script>")
                                Else
                                    Response.Write("<script>alert('Gagal Input Data Izin sales')</script>")
                                End If
                                'Call UpdateData_Server("INSERT INTO DATA_IZIN_BODY (IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_TAHUN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtStaffNIKMaster.Text & "','" & TxtPetik(DropDownListCuti.Text) & "','" & JnsIzin & "','" & TxtTahunCuti.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "")
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                Response.Write("<script>alert('ID IZIN ANDA : " + idizin_pertama + "')</script>")
                                'insert data_izin_detail (list tanggal yang di ajkuan)
                                For Each items As DateTime In dateListNotMinggu
                                    Call UpdateData_Server("insert into DATA_IZIN_DETAIL_sales (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & cabang.Text & "')", "MyConnCloudDnet2")
                                Next

                                '================call function to email atasan
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                'email ke atasan 1
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + nama.Text + " dengan NIK " + cabang.Text + " dan tanggal Pengajuan " + DateTime.Now + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailatasan.Text)
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            End If
                        End If
                    End If
                End If
                'here
            Else
                Response.Write("<script>alert('Password yang anda masukan berbeda dengan password login anda! Proses Pengajuan Gagal')</script>")
                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
            End If
        End If
    End Sub
    'BERLAKU UNTUK PENGAJUAN TERLAMBAT [DENGAN UPLOAD] DAN KELUAR KANTOR 
    Protected Sub BtnTerlambat_Click(sender As Object, e As EventArgs) Handles BtnTerlambat.Click
        '***buat validasi jika staff tsb pada izin pengajuan terbarunya ststus bukan disetujui manajer
        Dim nik_staff As String = cabang.Text
        Call GetData_StatusIzin("select top 1 izin_id, IZIN_NIK, IZIN_STATUS from data_izin_body_sales where izin_nik = '" + nik_staff + "' ORDER BY izin_id DESC ")
        'Response.Write("<script>alert('Status izin : " + STATUS + "!')</script>")

        If STATUS = "Pending" Or STATUS = "Disetujui Atasan" Then
            Response.Write("<script>alert('Anda Tidak Dapat Melakukan Pengajuan, Karena Izin anda dengan id = " + ID_Staff + " Belum di Setujui Manajer')</script>")
            Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
        ElseIf STATUS = "Disetujui Manajer" Or STATUS = "Dibatalkan Atasan" Or STATUS = "Dibatalkan Sales" Or STATUS = "Dibatalkan Manajer" Then
            '***TAMBAH VALIDASI UNTUK INPUT PASSWORD ULANG 
            'call method get password berdasarkan username login
            Call GetData_PswdSales("select SECURITYH_PASS from data_securityh where SECURITYH_NOIDSALES = '" + kodesales.Text + "'", "MyConnCloudDnet88sw")
            If TxtPswdValidCuti.Text = pswd_sales Then
                'Dim JnsIzinTelat As Integer = DropDownJenisiIzin.SelectedValue
                '********insert ke data_izin_detail dan body
                'Dim AlasanIzinStaff As String = TxtAlasanIzinPulangCepat.Text
                Dim tgldead As DateTime = FormatDateTime(Now.AddDays(+6), DateFormat.ShortDate) 'tanggal deadline
                Dim datenowher As DateTime = FormatDateTime(Now, DateFormat.ShortDate) 'tanggal hari ini
                Dim thn1 As Integer = DateTime.Now.ToString("yyyy")
                Dim bln1 As Integer = DateTime.Now.ToString("MM")
                'strtelatcepat = TxtAlasanIzinPulangCepat.Text
                'End If
                jenis_izin = LabelJenisIzin.Text
                If jenis_izin = "Terlambat" Then
                    'Response.Write("<script>alert('Terlambat')</script>")
                    If TxtTerlambatKeluarAlasan.Text = "" Or TxtTerlambatkeluarWaktuTerlambat.Text = "" Or TxtTerlambatkeluarTanggal.Text = "" Then
                        Response.Write("<script>alert('Alasan / Jam / Tanggal tidak boleh kosong!')</script>")
                        Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                    Else
                        '***Lokal Variabel
                        Dim jnsizin = "Izin Terlambat"
                        '***Insert ke data_izin_body_sales
                        If UpdateData_Server("INSERT INTO DATA_IZIN_BODY_sales (IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & bln1 & "','" & cabang.Text & "','" & TxtTerlambatKeluarAlasan.Text & "','" & jnsizin & "','" & thn1 & "','" & datenowher & "','" & tgldead & "','Pending')", "MyConnCloudDnet2") = 1 Then
                            'Response.Write("<script>alert('Berhasil Input Data Izin Staff')</script>")
                        Else
                            Response.Write("<script>alert('Gagal Input Data Izin Staff')</script>")
                        End If
                        '***FUNGSI UPLOAD DOKUMEN**********************
                        If Page.IsValid Then
                            'If the Default.aspx validation is true (for example if the uploaded file is of correct file type, then process the rest of the script.
                            Dim filereceived As String = FileUpload2.PostedFile.FileName
                            Dim filename As String = Path.GetFileName(filereceived)
                            Dim EditDataStafffoto As String
                            If filereceived = "" Then 'validasi file upload tidak boleh kosong
                                Response.Write("<script>alert('Anda Harus Mengupload File. Proses Pengajuan Tidak Masuk Kantor Gagal.')</script>")
                                'get id top 1 idizin_pertama
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                'delete id top 1 data izin body
                                Dim deletepengajuangagal As String = "delete from data_izin_body_sales where izin_id = '" & idizin_pertama & "'"
                                Call UpdateData_Server(deletepengajuangagal, "MyConnCloudDnet2")
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                            Else
                                'get data staff id 
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                EditDataStafffoto = "UPDATE DATA_IZIN_BODY_sales SET IZIN_FILEDETAIL='" & filename & "' WHERE  IZIN_ID='" & idizin_pertama & "'"
                                Call UpdateData_Server(EditDataStafffoto, "MyConnCloudDnet2")
                                Dim fileuploadpath As String = "C:\inetpub\wwwroot\Data_IzinSales_14_1_2019\img\FileUpload\"
                                'Dim fileuploadpath As String = "C:/inetpub/wwwroot/MugenASPHRISO/WEBDOWNLOAD/FOTOIZIN/"
                                'Dim Fileuploadpath As String = "D:/Herlambang/November-Ongoing - Revisi Input Data Izin (Table)/LiveMUGENASP/TestFromUpload/MugenASPHRISO_10_22_018/img/imgstaff"
                                FileUpload2.PostedFile.SaveAs(Path.Combine(fileuploadpath, filename))
                                'FileUpload1.SaveAs(Server.MapPath("~inetpub/wwwroot/MugenASPHRISO/WEBDOWNLOAD/FOTOIZIN") & filename)
                                'FileUpload1.SaveAs(Server.MapPath("~") & filename)
                                '**************get id izin terbaru untuk insert ke data izin detail
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                Response.Write("<script>alert('ID IZIN ANDA : " + idizin_pertama + "')</script>")
                                '***insert data izin detail
                                Call UpdateData_Server("insert into DATA_IZIN_DETAIL_SALES (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK, IZIN_JAMDETAIL) values ('" & idizin_pertama & "','" & TxtTerlambatkeluarTanggal.Text & "', '" & cabang.Text & "', '" & TxtTerlambatkeluarWaktuTerlambat.Text & "')", "MyConnCloudDnet2")
                                '***email Atasan1
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                                'email ke atasan 1
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + nama.Text + " dengan NIK " + cabang.Text + " dan tanggal Pengajuan " + datenowher + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailatasan.Text)
                                Response.Write("<script>alert('Berhasil Input Data Izin Sales')</script>")
                                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                                '***************************************************************************************                      
                            End If
                        Else
                            'EMPTY
                        End If
                    End If
                ElseIf jenis_izin = "Keluar Kantor" Then
                    'Response.Write("<script>alert('Kelaur Kantor')</script>")
                    If TxtTerlambatKeluarAlasan.Text = "" Or TxtTerlambatkeluarTanggal.Text = "" Or TxtTerlambatkeluarWaktuKeluar.Text = "" Then
                        Response.Write("<script>alert('Alasan / Jam / Tanggal tidak boleh kosong!')</script>")
                        Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                    Else
                        Dim jnsizin = "Izin Keluar Kantor"
                        'insert data_izin_body
                        If UpdateData_Server("INSERT INTO DATA_IZIN_BODY_SALES (IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & bln1 & "','" & cabang.Text & "','" & TxtTerlambatKeluarAlasan.Text & "','" & jnsizin & "','" & thn1 & "','" & datenowher & "','" & tgldead & "','Pending')", "MyConnCloudDnet2") = 1 Then
                            Response.Write("<script>alert('Berhasil Input Data Izin Sales')</script>")
                        Else
                            Response.Write("<script>alert('Gagal Input Data Izin Sales')</script>")
                        End If
                        'get id izin terbaru untuk insert ke data izin detail
                        Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                        Response.Write("<script>alert('ID IZIN ANDA : " + idizin_pertama + "')</script>")
                        'insert data izin detail
                        Call UpdateData_Server("insert into DATA_IZIN_DETAIL_sales (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK, IZIN_JAMDETAIL) values ('" & idizin_pertama & "','" & TxtTerlambatkeluarTanggal.Text & "', '" & cabang.Text & "', '" & TxtTerlambatkeluarWaktuKeluar.Text & "')", "MyConnCloudDnet2")
                        '================call function to email atasan
                        Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY_sales order by izin_id desc", "MyConnCloudDnet2")
                        'email ke atasan 1
                        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + nama.Text + " dengan NIK " + cabang.Text + " dan tanggal Pengajuan " + datenowher + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailatasan.Text)
                        Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
                    End If
                End If
                'here
            Else
                Response.Write("<script>alert('Password yang anda masukan berbeda dengan password login anda! Proses Pengajuan Gagal')</script>")
                Response.Write("<script>window.location.href='HOME.aspx?Name=" + cabang.Text + "';</script>")
            End If
        End If
    End Sub
End Class
