
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
Partial Class ListIzin
    Inherits System.Web.UI.Page
    'select sales_nama, sales_email from data_salesman  where sales_nama ='faiz'And SALES_Jabatan = 0 [SALES NAMA = UGAM DI 180 / FAIZ DI 88]
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Get Username Login
        'Dim v1 As String = "FAIZ" 'Request.QueryString("Name")
        Dim v1 As String = Request.QueryString("Name")
        LabelUsernameLogin.Text = v1

        If v1 = "FAIZ" Or v1 = "UGAM" Then
            MultiViewListIzin.ActiveViewIndex = 1 'view bawahan
        ElseIf v1 = "JULIUS" Or v1 = "RONI" Or v1 = "DAVIDH" Or v1 = "HELMI" Or v1 = "IVAN" Or v1 = "SAHRUL" Or v1 = "BAYU" Or v1 = "FENDY" Or v1 = "MEGAH" Or v1 = "MICHAEL" Then
            Call GetData_DetaiIzinStaff("select user_id from DATA_SECURITYU where User_nama ='" + v1 + "'", "SalesWarehouseSecurityU", 1)
            LabelUsernameLoginID.Text = ID_Spv
            MultiViewListIzin.ActiveViewIndex = 2 'view bawahan spv
        Else
            Dim potong_cabang As String = v1.Substring(0, 3) 'get 3 char from start
            Dim potong_kode As String = v1.Remove(0, 3)
            If potong_cabang = "112" Then
                Call GetData_DetaiIzinStaff("select sales_nama from data_salesman where SALES_Kode = '" + potong_kode + "'", "MyConnCloudDnetWTSALES88", 2)
                LabelNama.Text = nama_sales
            ElseIf potong_cabang = "128" Then
                Call GetData_DetaiIzinStaff("select sales_nama from data_salesman where SALES_Kode = '" + potong_kode + "'", "MyConnCloudDnetWTSALES180", 2)
                LabelNama.Text = nama_sales
            End If

            MultiViewListIzin.ActiveViewIndex = 0 'view staff
        End If
        'LabelUsernameLoginID
    End Sub
    'Global variabel 
    Public MyRecReadA As OleDbDataReader
    Dim ID_Spv As String
    Dim nama_sales As String
    'Kumpulan Fungsi Koneksi**********************************************************
    'fUNGSI GET SALDO SALES
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
    'Fungsi cegah nilai null
    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function
    'Fungsi CRUD Database
    Function UpdateData_Server(ByVal mSqlCommadstring As String, conns As String) As Byte
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
            'Call ErrorIsi(mPos, ex.Message)
        End Try
    End Function
    'Fungsi Notifikasi Email
    Function emailNotifikasi(isiPesan As String, staffEmailnotif As String) As Byte
        Dim pesan As New MailMessage
        pesan.Subject = "Notifikasi Pengajuan Izin Sales"
        pesan.To.Add(staffEmailnotif) 'email tujuan
        pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
        pesan.Body = isiPesan
        pesan.IsBodyHtml = True
        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p") 'isi dengan info akun gmail kalian
        SMTP.Port = "587"
        SMTP.Send(pesan)
    End Function

    'Function emailNotifikasi(isiPesan As String, staffEmailnotif As String) As Byte
    '    Response.Write("<script>alert('Berhasil Email')</script>")
    'End Function
    '==+++++++++++++++++++++++++++++++++++++++++++++

    'fungsi get jenis izin
    Public izin_jenisApv As String
    Public izin_alasanApv As String
    Public izin_tgldeadlineApv As String
    Public email_sales As String
    Public imagedown As String
    Function GetData_DetaiIzinSales(ByVal mSqlCommadstring As String, conns As String, ByVal mPos As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(conns).ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_DetaiIzinSales = 0

        cnn = New OleDbConnection(strconn)

        If mPos = 1 Then 'get usernama
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinSales = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    izin_jenisApv = MyRecReadA("izin_jenis")
                    izin_alasanApv = MyRecReadA("izin_alasan")
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
                GetData_DetaiIzinSales = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    izin_tgldeadlineApv = MyRecReadA("izin_tgldeadline")
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 3 Then ' get email sales
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinSales = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    email_sales = MyRecReadA("sales_email")
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 4 Then ' get file download
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinSales = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    imagedown = nSr(MyRecReadA("IZIN_FILEDETAIL"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        End If
    End Function


    'Fungsi Get Detail Sales
    'Public variabel
    Public ListTgl As New List(Of String)()
    Public ListTgl_Pend As New List(Of String)()
    Public DeadlinePc As DateTime
    Public TglAju As DateTime
    Public emailSalesAktif As String
    Public izin_jenisSales As String
    Public izin_alasanSales As String
    Function GetData_DetaiIzinStaff(ByVal mSqlCommadstring As String, conns As String, ByVal mPos As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(conns).ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_DetaiIzinStaff = 0

        cnn = New OleDbConnection(strconn)

        If mPos = 1 Then 'get usernama
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    ID_Spv = MyRecReadA("user_id")
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
                    nama_sales = MyRecReadA("sales_nama")
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 3 Then ' untuk mendapatkan detil dari izin sales
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    TxtDetailTglPengajuanIzin.Text = MyRecReadA("izin_tglpengajuan") 'tgl pengajuan izin
                    TxtDetailNik.Text = MyRecReadA("izin_nik") 'nik pengajuan izin
                    If txtDetailJenisIzin.Text = "Cuti" Then
                        'Response.Write("<script>alert('Cuti')</script>")
                        TxtDetailAlasanPengajuan.Text = nSr(MyRecReadA("IZIN_ALASAN")) '+ " / " + nSr(MyRecReadA("IZIN_ALASANDETAIL")
                        AlasanCuti.Text = nSr(MyRecReadA("IZIN_ALASAN"))
                        'TxtDetailAlasanPengajuan.Text = nSr(MyRecReadA("IZIN_ALASANDETAIL"))
                        'TxtDetailAlasanPengajuan.Enabled = False
                        'TxtDetailAlasanPengajuan2.Text = nSr(MyRecReadA("IZIN_ALASANDETAIL"))
                        TxtDetailAlasanPengajuan2.Visible = False
                        LabelDetailAlasanPengajuan2.Visible = False
                        TxtDetailTglPengajuanIzin.Visible = False
                    Else
                        'Response.Write("<script>alert('Selain Cuti')</script>")
                        TxtDetailAlasanPengajuan.Text = nSr(MyRecReadA("IZIN_ALASAN"))
                        'TxtDetailAlasanPengajuan.Enabled = False
                        TxtDetailAlasanPengajuan2.Text = nSr(MyRecReadA("IZIN_ALASANDETAIL"))
                        TxtDetailAlasanPengajuan2.Visible = False
                        LabelDetailAlasanPengajuan2.Visible = False

                    End If
                    TxtDetailNama.Text = LabelNama.Text 'nama pengajuan izin
                    txtDetailJenisIzin.Text = MyRecReadA("izin_jenis") 'detail jenis izin
                    TxtDetailStatusPengajuan.Text = MyRecReadA("izin_status") 'status izin
                    TxtDetailDeadline.Text = MyRecReadA("izin_tgldeadline") 'deadline izin
                    TxtDetailAlasanBtlStj.Text = nSr(MyRecReadA("IZIN_ALASANBTLSTJ"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 4 Then ' untuk mendapatkan detil izin jam pengajuan dari izin sales
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    TxtDetailJamPengajuan.Text = MyRecReadA("izin_jamdetail") 'tgl pengajuan izin      
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 5 Then ' untuk mendapatkan detil tanggal yang di ajukan
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'this code ==
                    ListTgl.Add(MyRecReadA("izin_tgldetail").ToShortDateString)
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 6 Then ' untuk mendapatkan detil tanggal yang di ajukan [pending cuti]
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'this code ==
                    ListTgl_Pend.Add(MyRecReadA("izin_tgldetail").ToShortDateString)
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 7 Then ' untuk mendapatkan detil SPV DAN MNG SALES
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'this code ==
                    mng = MyRecReadA("izin_nik_appvmng")
                    spv = MyRecReadA("izin_nik_appvspv")
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 8 Then ' untuk mendapatkan email sales
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'this code ==
                    emailSalesAktif = MyRecReadA("SALES_Email")
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 9 Then ' untuk mendapatkan nama sales
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'this code ==
                    TxtDetailNama.Text = MyRecReadA("izin_nama")
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 10 Then ' untuk mendapatkan detil izin cuti sales
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'this code ==
                    izin_jenisSales = MyRecReadA("izin_jenis")
                    izin_alasanSales = MyRecReadA("izin_alasan")
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        End If

    End Function
    'Public Variabel untuk eliminasi Pc dan Not PC
    Public arr_pc As List(Of DateTime) = New List(Of DateTime)()
    Public arr_notpc As List(Of DateTime) = New List(Of DateTime)()
    Public arr_temp As List(Of DateTime) = New List(Of DateTime)()
    Public arr_temp2 As List(Of DateTime) = New List(Of DateTime)()
    Protected Sub ListViewSales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewSales.SelectedIndexChanged
        Dim id_terpilih As String = (ListViewSales.DataKeys(ListViewSales.SelectedIndex).Value.ToString)
        '*** validasi deadline tgl
        Call GetData_DetaiIzinSales("select izin_tgldeadline from data_izin_body_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 2)
        If DateTime.Now <= izin_tgldeadlineApv Then
            LabelUserLogin.Text = "Sales"
            TxtDetailIdIzinSales.Text = id_terpilih
            MultiViewListIzin.ActiveViewIndex = 3
            'cek apakah izin tsb masih aktif [tgl skrg < = tgl jatuh tempo]
            Call GetData_DetaiIzinStaff("select * from data_izin_body_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 3)
            'get nama sales
            Call GetData_DetaiIzinStaff("select izin_nama from data_izin_header_sales where izin_nik = '" + TxtDetailNik.Text + "'", "MyConnCloudDnet171", 9)

            If txtDetailJenisIzin.Text = "Cuti" Or txtDetailJenisIzin.Text = "Tidak Masuk Kantor" Then
                'Response.Write("<script>alert('Cuti dan Tidak Masuk Kantor')</script>")
                'GET LIST TGL tahunan
                Call GetData_DetaiIzinStaff("select * from data_izin_detail_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 5)
                'GET LIST TGL pending cuti
                Call GetData_DetaiIzinStaff("select * from DATA_IZIN_DETAILPC_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 6)
                'GET JML PENGAJUAN 
                TxtDetailJmlPengajuan.Text = Convert.ToInt32(ListTgl.Count + ListTgl_Pend.Count)
                GridViewTglSales.DataSource = ListTgl
                GridViewTglSales.DataBind()
                GridViewTglPending.DataSource = ListTgl_Pend
                GridViewTglPending.DataBind()
                If TxtDetailAlasanPengajuan.Text = "Sakit Surat Dokter" Then
                    LabelBuktiSuratSakit.Visible = True
                    BtnDownloadDetailFile.Visible = True
                Else
                    LabelBuktiSuratSakit.Visible = False
                    BtnDownloadDetailFile.Visible = False
                End If
                Label57.Visible = True 'memotong cuti tahunan
                Label58.Visible = True 'memotong cuti pending
                TxtDetailJamPengajuan.Visible = False
                LabelJamPengajuan.Visible = False
                'hide download 
                'LabelBuktiSuratSakit.Visible = False
                'BtnDownloadDetailFile.Visible = False
                'Logic filter display button decline by staff
                If TxtDetailStatusPengajuan.Text = "Pending" Then
                    BtnDeclineDetaildanApproval.Visible = True
                Else
                    BtnDeclineDetaildanApproval.Visible = False
                End If
                ''get  izin jam detail
                'Call GetData_DetaiIzinStaff("select * from data_izin_detail_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 4)
                ''display jml pengajuan

            Else 'SELAIN CUTI DAN TIDAK MASUK KANTOR
                'Response.Write("<script>alert('Jenis : " + txtDetailJenisIzin.Text + "')</script>")
                'Response.Write("<script>alert('Selain Cuti dan Tidak Masuk Kantor')</script>")
                'GET LIST TGL tahunan
                Call GetData_DetaiIzinStaff("select * from data_izin_detail_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 5)
                'GET LIST TGL pending cuti
                Call GetData_DetaiIzinStaff("select * from DATA_IZIN_DETAILPC_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 6)
                'GET JML PENGAJUAN 
                TxtDetailJmlPengajuan.Text = Convert.ToInt32(ListTgl.Count + ListTgl_Pend.Count)
                GridViewTglSales.DataSource = ListTgl
                GridViewTglSales.DataBind()
                GridViewTglPending.DataSource = ListTgl_Pend
                GridViewTglPending.DataBind()
                If txtDetailJenisIzin.Text = "Izin Terlambat" Then
                    LabelBuktiSuratSakit.Visible = True
                    BtnDownloadDetailFile.Visible = True
                Else
                    'Response.Write("<script>alert('Selain Keluar Kantor')</script>")
                    LabelBuktiSuratSakit.Visible = False
                    BtnDownloadDetailFile.Visible = False
                End If
                'Logic filter display button decline by staff
                If TxtDetailStatusPengajuan.Text = "Pending" Then
                    'Response.Write("<script>alert('Status Pengajuan : " + TxtDetailStatusPengajuan.Text + "')</script>")
                    BtnDeclineDetaildanApproval.Visible = True
                    BtnSaveDetaildanApproval.Visible = True
                Else
                    BtnDeclineDetaildanApproval.Visible = False
                    BtnSaveDetaildanApproval.Visible = False
                End If
                'get  izin jam detail
                Call GetData_DetaiIzinStaff("select * from data_izin_detail_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 4)
                'Display Jam Pengajuan 
                TxtDetailJamPengajuan.Visible = True
                LabelJamPengajuan.Visible = True
                '
            End If
            'get tgl deadline pc jika ada
            'Call GetData_DetaiIzinStaff("select * from data_izin_HEADER_SALES where izin_NIK = '" + TxtDetailNik.Text + "'", "MyConnCloudDnet171", 5)
        Else
            Response.Write("<script>alert('Pengajuan Izin ini, sudah lewat deadline. Kembali ke menu utama')</script>")
            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
        End If
    End Sub
    Protected Sub LvDetailBawahan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvDetailBawahan.SelectedIndexChanged
        Dim id_terpilih As String = (LvDetailBawahan.DataKeys(LvDetailBawahan.SelectedIndex).Value.ToString)

        '*** validasi deadline tgl
        Call GetData_DetaiIzinSales("select izin_tgldeadline from data_izin_body_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 2)
        If DateTime.Now <= izin_tgldeadlineApv Then
            LabelUserLogin.Text = "SM"
            TxtDetailIdIzinSales.Text = id_terpilih
            MultiViewListIzin.ActiveViewIndex = 3

            'cek apakah izin tsb masih aktif [tgl skrg < = tgl jatuh tempo]
            Call GetData_DetaiIzinStaff("select * from data_izin_body_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 3)
            'get nama sales
            Call GetData_DetaiIzinStaff("select izin_nama from data_izin_header_sales where izin_nik = '" + TxtDetailNik.Text + "'", "MyConnCloudDnet171", 9)

            'Response.Write("<script>alert('')</script>")
            If txtDetailJenisIzin.Text = "Cuti" Or txtDetailJenisIzin.Text = "Tidak Masuk Kantor" Then
                'GET LIST TGL tahunan
                Call GetData_DetaiIzinStaff("select * from data_izin_detail_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 5)
                'GET LIST TGL pending cuti
                Call GetData_DetaiIzinStaff("select * from DATA_IZIN_DETAILPC_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 6)
                'GET SPV DAN MNG SALES
                Call GetData_DetaiIzinStaff("select izin_nik_appvmng, izin_nik_appvspv from data_izin_header_sales where izin_nik ='" + TxtDetailNik.Text + "'", "MyConnCloudDnet171", 7)
                'GET JML PENGAJUAN 
                TxtDetailJmlPengajuan.Text = Convert.ToInt32(ListTgl.Count + ListTgl_Pend.Count)
                GridViewTglSales.DataSource = ListTgl
                GridViewTglSales.DataBind()
                GridViewTglPending.DataSource = ListTgl_Pend
                GridViewTglPending.DataBind()
                '================================================================
                'Response.Write("<script>alert('cuti dan tidak masuk kantor ====== Status pengajuan : " + TxtDetailStatusPengajuan.Text + " dan Manager : " + mng + "')</script>")
                If TxtDetailStatusPengajuan.Text = "Pending" And mng = "--" Then 'untuk satu atasan
                    BtnDeclineDetaildanApproval.Visible = True
                    BtnSaveDetaildanApproval.Visible = True
                ElseIf TxtDetailStatusPengajuan.Text = "Disetujui Atasan" And mng <> "--" Then 'untuk 2 atasan
                    BtnDeclineDetaildanApproval.Visible = True
                    BtnSaveDetaildanApproval.Visible = True
                Else
                    BtnDeclineDetaildanApproval.Visible = False
                    BtnSaveDetaildanApproval.Visible = False
                End If

                '================================================================
                If TxtDetailAlasanPengajuan.Text = "Sakit Surat Dokter" Then
                    LabelBuktiSuratSakit.Visible = True
                    BtnDownloadDetailFile.Visible = True
                Else
                    LabelBuktiSuratSakit.Visible = False
                    BtnDownloadDetailFile.Visible = False
                End If
                '***Perbaikan untuk selain cuti maka tidak ada label memotong nya 
                'Response.Write("<script>alert('Jenis Pengajuan " + txtDetailJenisIzin.Text + " dan alasan pengajuan " + TxtDetailAlasanPengajuan.Text + "')</script>")
                If txtDetailJenisIzin.Text = "Cuti" And TxtDetailAlasanPengajuan.Text = "Cuti" Then
                    Label57.Visible = True 'memotong cuti tahunan
                    Label58.Visible = True 'memotong cuti pending
                Else
                    Label57.Visible = False 'memotong cuti tahunan
                    Label58.Visible = False 'memotong cuti pending
                End If
                TxtDetailJamPengajuan.Visible = False
                LabelJamPengajuan.Visible = False
            Else 'SELAIN CUTI DAN TIDAK MASUK KANTOR
                'Response.Write("<script>alert('SELAIN CUTI DAN TIDAK MASUK KANTOR ====== Status pengajuan : " + TxtDetailStatusPengajuan.Text + " dan Manager : " + mng + "')</script>")
                'GET LIST TGL tahunan
                Call GetData_DetaiIzinStaff("select * from data_izin_detail_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 5)
                'GET LIST TGL pending cuti
                Call GetData_DetaiIzinStaff("select * from DATA_IZIN_DETAILPC_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 6)
                'GET SPV DAN MNG SALES
                Call GetData_DetaiIzinStaff("select izin_nik_appvmng, izin_nik_appvspv from data_izin_header_sales where izin_nik ='" + TxtDetailNik.Text + "'", "MyConnCloudDnet171", 7)
                'GET JML PENGAJUAN 
                TxtDetailJmlPengajuan.Text = Convert.ToInt32(ListTgl.Count + ListTgl_Pend.Count)
                GridViewTglSales.DataSource = ListTgl
                GridViewTglSales.DataBind()
                GridViewTglPending.DataSource = ListTgl_Pend
                GridViewTglPending.DataBind()
                '================================================================
                'Response.Write("<script>alert('Status pengajuan : " + TxtDetailStatusPengajuan.Text + " dan Manager : " + mng + "')</script>")
                If TxtDetailStatusPengajuan.Text = "Pending" And mng = "--" Then 'untuk satu atasan
                    BtnDeclineDetaildanApproval.Visible = True
                    BtnSaveDetaildanApproval.Visible = True
                ElseIf TxtDetailStatusPengajuan.Text = "Disetujui Atasan" And mng <> "--" Then 'untuk 2 atasan
                    BtnDeclineDetaildanApproval.Visible = True
                    BtnSaveDetaildanApproval.Visible = True
                Else
                    BtnDeclineDetaildanApproval.Visible = False
                    BtnSaveDetaildanApproval.Visible = False
                End If

                '================================================================
                If txtDetailJenisIzin.Text = "Izin Terlambat" Then
                    LabelBuktiSuratSakit.Visible = True
                    BtnDownloadDetailFile.Visible = True
                Else
                    LabelBuktiSuratSakit.Visible = False
                    BtnDownloadDetailFile.Visible = False
                End If
                'get  izin jam detail
                Call GetData_DetaiIzinStaff("select * from data_izin_detail_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 4)
                'Display Jam Pengajuan 
                TxtDetailJamPengajuan.Visible = True
                LabelJamPengajuan.Visible = True
            End If
        Else
            Response.Write("<script>alert('Pengajuan Izin ini, sudah lewat deadline. Kembali ke menu utama')</script>")
            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
        End If
    End Sub
    Protected Sub ListViewDetailBawahanSPV_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewDetailBawahanSPV.SelectedIndexChanged
        Dim id_terpilih As String = (ListViewDetailBawahanSPV.DataKeys(ListViewDetailBawahanSPV.SelectedIndex).Value.ToString)
        '*** validasi deadline tgl
        Call GetData_DetaiIzinSales("select izin_tgldeadline from data_izin_body_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 2)
        If DateTime.Now <= izin_tgldeadlineApv Then
            LabelUserLogin.Text = "SPV"
            TxtDetailIdIzinSales.Text = id_terpilih
            MultiViewListIzin.ActiveViewIndex = 3
            'cek apakah izin tsb masih aktif [tgl skrg < = tgl jatuh tempo]
            'cek apakah izin tsb masih aktif [tgl skrg < = tgl jatuh tempo]
            Call GetData_DetaiIzinStaff("select * from data_izin_body_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 3)
            'get nama sales
            Call GetData_DetaiIzinStaff("select izin_nama from data_izin_header_sales where izin_nik = '" + TxtDetailNik.Text + "'", "MyConnCloudDnet171", 9)

            If txtDetailJenisIzin.Text = "Cuti" Or txtDetailJenisIzin.Text = "Tidak Masuk Kantor" Then
                'Response.Write("<script>alert('Cuti dan Tidak Masuk Kantor')</script>")
                'GET LIST TGL tahunan
                Call GetData_DetaiIzinStaff("select * from data_izin_detail_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 5)
                'GET LIST TGL pending cuti
                Call GetData_DetaiIzinStaff("select * from DATA_IZIN_DETAILPC_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 6)
                'GET JML PENGAJUAN 
                TxtDetailJmlPengajuan.Text = Convert.ToInt32(ListTgl.Count + ListTgl_Pend.Count)
                GridViewTglSales.DataSource = ListTgl
                GridViewTglSales.DataBind()
                GridViewTglPending.DataSource = ListTgl_Pend
                GridViewTglPending.DataBind()
                If TxtDetailAlasanPengajuan.Text = "Sakit Surat Dokter" Then
                    LabelBuktiSuratSakit.Visible = True
                    BtnDownloadDetailFile.Visible = True
                Else
                    LabelBuktiSuratSakit.Visible = False
                    BtnDownloadDetailFile.Visible = False
                End If
                Label57.Visible = True 'memotong cuti tahunan
                Label58.Visible = True 'memotong cuti pending
                TxtDetailJamPengajuan.Visible = False
                LabelJamPengajuan.Visible = False
                'hide download 
                'LabelBuktiSuratSakit.Visible = False
                'BtnDownloadDetailFile.Visible = False
                'Logic filter display button decline by staff
                If TxtDetailStatusPengajuan.Text = "Pending" Then
                    'Response.Write("<script>alert('Status Pengajuan : " + TxtDetailStatusPengajuan.Text + "')</script>")
                    BtnDeclineDetaildanApproval.Visible = True
                    BtnSaveDetaildanApproval.Visible = True
                Else
                    BtnDeclineDetaildanApproval.Visible = False
                    BtnSaveDetaildanApproval.Visible = False
                End If
                ''get  izin jam detail
                'Call GetData_DetaiIzinStaff("select * from data_izin_detail_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 4)
                ''display jml pengajuan

            Else 'SELAIN CUTI DAN TIDAK MASUK KANTOR
                'Response.Write("<script>alert('Jenis : " + txtDetailJenisIzin.Text + "')</script>")
                'Response.Write("<script>alert('Selain Cuti dan Tidak Masuk Kantor')</script>")
                'GET LIST TGL tahunan
                Call GetData_DetaiIzinStaff("select * from data_izin_detail_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 5)
                'GET LIST TGL pending cuti
                Call GetData_DetaiIzinStaff("select * from DATA_IZIN_DETAILPC_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 6)
                'GET JML PENGAJUAN 
                TxtDetailJmlPengajuan.Text = Convert.ToInt32(ListTgl.Count + ListTgl_Pend.Count)
                GridViewTglSales.DataSource = ListTgl
                GridViewTglSales.DataBind()
                GridViewTglPending.DataSource = ListTgl_Pend
                GridViewTglPending.DataBind()
                If txtDetailJenisIzin.Text = "Izin Terlambat" Then
                    LabelBuktiSuratSakit.Visible = True
                    BtnDownloadDetailFile.Visible = True
                Else
                    'Response.Write("<script>alert('Selain Keluar Kantor')</script>")
                    LabelBuktiSuratSakit.Visible = False
                    BtnDownloadDetailFile.Visible = False
                End If
                'Logic filter display button decline by staff
                If TxtDetailStatusPengajuan.Text = "Pending" Then
                    'Response.Write("<script>alert('Status Pengajuan : " + TxtDetailStatusPengajuan.Text + "')</script>")
                    BtnDeclineDetaildanApproval.Visible = True
                    BtnSaveDetaildanApproval.Visible = True
                Else
                    BtnDeclineDetaildanApproval.Visible = False
                    BtnSaveDetaildanApproval.Visible = False
                End If
                'get  izin jam detail
                Call GetData_DetaiIzinStaff("select * from data_izin_detail_sales where izin_id = '" + id_terpilih + "'", "MyConnCloudDnet171", 4)
                'Display Jam Pengajuan 
                TxtDetailJamPengajuan.Visible = True
                LabelJamPengajuan.Visible = True
                '
            End If
        Else
            Response.Write("<script>alert('Pengajuan Izin ini, sudah lewat deadline. Kembali ke menu utama')</script>")
            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
        End If
    End Sub
    'Button Approval
    Public mng As String ' menampung nilai manager sales
    Public spv As String 'menampung nilai spv sales
    Public email_atasan As String
    Protected Sub BtnSaveDetaildanApproval_Click(sender As Object, e As EventArgs) Handles BtnSaveDetaildanApproval.Click
        'get alasan 
        Dim alasan As String = TxtDetailAlasanBtlStj.Text
        'Get Who's Login 
        Dim user_on As String = LabelUsernameLogin.Text 'FAIZ/DAVIDH/112VYE
        Dim user_id As String = LabelUsernameLoginID.Text '-/DH/
        Dim user_nama As String = LabelNama.Text 'Untuk nama sales
        'get status pengajuan 
        Dim status_pengajuan As String = TxtDetailStatusPengajuan.Text
        Dim Login_user As String = LabelUserLogin.Text 'Sales / SM /SPV
        'LabelUsernameLoginID.text untuk id ketika spv login /DH/. TAPI KETIKA MNG / SALES LOGIN VALUENYA ""
        Dim jenis_izin As String = txtDetailJenisIzin.Text
        'get spv mng sales terpilih[mng, spv]
        Call GetData_DetaiIzinStaff("select izin_nik_appvmng, izin_nik_appvspv from data_izin_header_sales where izin_nik ='" + TxtDetailNik.Text + "'", "MyConnCloudDnet171", 7)
        'Get Alasan Cuti [izin-jenisSales, izin_alasanSales]
        Call GetData_DetaiIzinStaff("select * from data_izin_body_sales where izin_id ='" + TxtDetailIdIzinSales.Text + "'", "MyConnCloudDnet171", 10)
        'get saldo tahunan dan saldo pending sales[saldo_tahunan/saldo_tahunanberlaku/saldo_pending/saldo_pendingberlaku]
        Real_saldoStaff("select IZIN_SALDO, IZIN_SALDO_CUTI_TAHUNAN_BERLAKU, IZIN_SALDO_PC, IZIN_SALDO_PC_BERLAKU from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + TxtDetailNik.Text + "'")
        'get jenis permohonan izin berdasarkan id izin[izin_jenisApv]
        Call GetData_DetaiIzinSales("select izin_jenis, izin_alasan  from data_izin_body_sales where izin_id = '" + TxtDetailIdIzinSales.Text + "'", "MyConnCloudDnet171", 1)
        'Response.Write("<script>alert('SPV :" + spv + " == MNG : " + mng + "')</script>")
        'Response.Write("<script>alert('Login User : " + Login_user + "')</script>")
        '**jika datetime null = 1/1/0001 , jika integer null = 0
        'Response.Write("<script>alert('PC berlaku = " + saldo_pendingberlaku.ToShortDateString + "  PC Juml=" + Convert.ToString(saldo_pending) + "')</script>")
        'Response.Write("<script>alert('TH Berlaku = " + saldo_tahunanberlaku.ToShortDateString + " TH Jml = " + Convert.ToString(saldo_tahunan) + "')</script>")
        '***validasi login user 
        If Login_user = "SPV" Then
            '***validasi jenis izin 
            If jenis_izin = "Cuti" Then 'untuk cuti 
                '***validasi jenis cuti 
                If izin_alasanApv <> "Cuti" Then '***Bukan Cuti Biasa 
                    '***validasi apakah spv terpilih sama dengan user yg sedang masuk
                    If spv = user_id And TxtDetailStatusPengajuan.Text = "Pending" Then
                        'get spv nik dan mng nik dari staff tsb[*]-spv/mng
                        'get nilai field saldo cuti [*][saldo_tahunan/saldo_tahunanberlaku/saldo_pending/saldo_pendingberlaku]
                        'validasi dealdine [sudah di lv masing masing]
                        'validasi alasan approve
                        If TxtDetailAlasanBtlStj.Text <> "" Then
                            'process -- disetujui atasan
                            Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Atasan', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                            '==email notif ke atasan2 untuk approval
                            '***email notif ke atasan2 untuk approval
                            If mng = "FAIZ" Then
                                email_atasan = "faiz@hondamugen.co.id"
                            ElseIf mng = "UGAM" Then
                                email_atasan = "ugam77@gmail.com"
                            End If
                            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzinSales.Text + " telah di Approve oleh " + LabelUsernameLogin.Text + " sebagai atasan langsung dari staff tersebut dengan Alasan : " + alasan + ". Anda di persilahkan untuk melakukan Aprroval sekarang <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_atasan)
                            Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        Else
                            Response.Write("<script>alert('Alasan Persetujuan Wajib di Isi')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        End If
                    Else
                        'empty / karena jika status bukan pending tombol appv tidak muncul untuk spv
                    End If
                Else '***Cuti Biasa -- belum mengurangi saldo karena ini spv
                    '***validasi apakah spv terpilih sama dengan user yg sedang masuk
                    If spv = user_id And TxtDetailStatusPengajuan.Text = "Pending" Then
                        'get spv nik dan mng nik dari staff tsb[*]SPV/MNG
                        'get nilai field saldo cuti  [saldo_tahunan/saldo_tahunanberlaku/saldo_pending/saldo_pendingberlaku]
                        'validasi dealdine [sudah di lv masing masing]
                        'validasi alasan approve
                        If TxtDetailAlasanBtlStj.Text <> "" Then
                            'process -- disetujui atasan
                            Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Atasan', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                            '==email notif ke atasan2 untuk approval
                            If mng = "FAIZ" Then
                                email_atasan = "faiz@hondamugen.co.id"
                            ElseIf mng = "UGAM" Then
                                email_atasan = "ugam77@gmail.com"
                            End If
                            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzinSales.Text + " telah di Approve oleh " + LabelUsernameLogin.Text + " sebagai atasan langsung dari staff tersebut dengan Alasan : " + alasan + ". Anda di persilahkan untuk melakukan Aprroval sekarang <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_atasan)
                            Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        Else
                            Response.Write("<script>alert('Alasan Persetujuan Wajib di Isi')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        End If
                    Else
                        'empty / karena jika status bukan pending tombol appv tidak muncul untuk spv
                    End If
                End If
            ElseIf jenis_izin = "Tidak Masuk Kantor" Then 'untuk tidak masuk kantor -- 'Proses appv hanya sampai spv-tidak sampai SM
                '***validasi apakah spv terpilih sama dengan user yg sedang masuk
                If spv = user_id And TxtDetailStatusPengajuan.Text = "Pending" Then
                    '***********CEK LAGI APAKAH VALUE YG DI TANGKAP SUDAH BENAR***************************
                    If TxtDetailAlasanPengajuan.Text = "Izin Potong Cuti" Or TxtDetailAlasanPengajuan.Text = "Sakit Potong Cuti" Then 'akan mengurangi saldo izin\
                        'get spv nik dan mng nik dari staff tsb[*]spv/mng
                        'get nilai field saldo cuti [*] [saldo_tahunan/saldo_tahunanberlaku/saldo_pending/saldo_pendingberlaku]
                        If saldo_tahunan <> 0 Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                            If saldo_tahunan < Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                                Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin Tahunan Sales')</script>")
                                Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                            Else
                                Dim saldo_calc As Integer = saldo_tahunan - Convert.ToInt32(TxtDetailJmlPengajuan.Text)
                                '**validasi alasan setuju
                                If TxtDetailAlasanBtlStj.Text <> "" Then
                                    Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer' , IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                                    'If DropDownListTidakMasuk.Text = "Izin Potong Cuti" Or DropDownListTidakMasuk.Text = "Sakit Potong Cuti" Then
                                    'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                                    Call UpdateData_Server("update DATA_IZIN_HEADER_sales set IZIN_SALDO ='" & saldo_calc & "' where IZIN_NIK = '" + TxtDetailNik.Text + "' ", "MyConnCloudDnet171")
                                    'End If
                                    '==email notification ke sales kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                                    '***get code cabang 
                                    Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                                    Dim conns As String
                                    If kodecab = 112 Then
                                        conns = "MyConnCloudDnetWTSALES88"
                                    Else
                                        conns = "MyConnCloudDnetWTSALES180"
                                    End If

                                    'email_sales
                                    Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                                    Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima dengan Alasan : " + alasan + ". Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                                    Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                                    Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                                Else
                                    Response.Write("<script>alert('Alasan Persetujuan Wajib di Isi')</script>")
                                    Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                                End If
                            End If
                        Else
                            Response.Write("<script>alert('Gagal melakukan Approval, saldo izin tahunan kosong')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        End If
                    Else 'tidak mengurangi saldo izin
                        'get spv nik dan mng nik dari staff tsb[*]SPV/MNG
                        'get nilai field saldo cuti [*] [saldo_tahunan/saldo_tahunanberlaku/saldo_pending/saldo_pendingberlaku]
                        If saldo_tahunan <> 0 Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                            If saldo_tahunan < Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                                Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin Tahunan Sales')</script>")
                                Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                            Else
                                Dim saldo_calc As Integer = saldo_tahunan - Convert.ToInt32(TxtDetailJmlPengajuan.Text)
                                Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                                'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                                'Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                                '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                                '***get code cabang 
                                Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                                Dim conns As String
                                If kodecab = 112 Then
                                    conns = "MyConnCloudDnetWTSALES88"
                                Else
                                    conns = "MyConnCloudDnetWTSALES180"
                                End If
                                'email_sales
                                Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima dengan Alasan : " + alasan + ". Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                                Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                                Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                            End If

                        Else
                            Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        End If
                    End If
                End If
            ElseIf jenis_izin = "Izin Keluar Kantor" Or jenis_izin = "Izin Terlambat" Then 'untuk izin keluar dan izin terlambat
                '***validasi apakah spv terpilih sama dengan user yg sedang masuk
                If spv = user_id And TxtDetailStatusPengajuan.Text = "Pending" Then
                    'get spv nik dan mng nik dari staff tsb[*]spv/mng
                    'get nilai field saldo cuti [*][saldo_tahunan/saldo_tahunanberlaku/saldo_pending/saldo_pendingberlaku]

                    If saldo_tahunan <> 0 Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                        If saldo_tahunan < Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                            Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin sales')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        Else
                            Dim saldo_calc As Integer = saldo_tahunan - Convert.ToInt32(TxtDetailJmlPengajuan.Text)
                            Call UpdateData_Server("update DATA_IZIN_BODY_SALES set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                            'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                            'Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                            '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                            '***get code cabang 
                            Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                            Dim conns As String
                            If kodecab = 112 Then
                                conns = "MyConnCloudDnetWTSALES88"
                            Else
                                conns = "MyConnCloudDnetWTSALES180"
                            End If
                            'email_sales
                            Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima dengan Alasan : " + alasan + ". Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                            Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        End If

                    Else
                        Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                        Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                    End If
                End If
            End If
        ElseIf Login_user = "SM" Then
            ''CEK CURRENT STATUS ========================================================
            'Response.Write("<script>alert('Login User : " + Login_user + "')</script>")
            ''CEK CURRENT STATUS ========================================================

            '***validasi jenis izin 
            If jenis_izin = "Cuti" Then 'untuk cuti 
                '***validasi jenis cuti 
                If izin_alasanApv <> "Cuti" Then 'Bukan Cuti Biasa -- Tidak Memotong Saldo, karena bukan cuti biasa
                    '***validasi apakah spv terpilih sama dengan user yg sedang masuk
                    If spv = user_on And mng = "--" And TxtDetailStatusPengajuan.Text = "Pending" Then 'kondisi ketika mng --- ' case 1 atasan
                        'Response.Write("<script>alert('Bukan Cuti Biasa  -- Proses Persetujuan MNG')</script>")
                        '***coreprocess
                        'Response.Write("<script>alert('spv : staff dengan 1 atasan saja ')</script>")
                        'Response.Write("<script>alert('Jml Saldo :" + saldo_cutiStaff + " == JML pengajuan :" + TxtDetailJmlPengajuan.Text + " ')</script>")
                        If saldo_tahunan <> 0 Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                            If saldo_tahunan < Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                                Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin sales')</script>")
                                Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                            Else
                                'Dim saldo_calc As Integer = saldo_tahunan - Convert.ToInt32(TxtDetailJmlPengajuan.Text)
                                Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                                'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                                'Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                                '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                                '***get code cabang 
                                Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                                Dim conns As String
                                If kodecab = 112 Then
                                    conns = "MyConnCloudDnetWTSALES88"
                                Else
                                    conns = "MyConnCloudDnetWTSALES180"
                                End If
                                'email_sales
                                Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima dengan Alasan : " + alasan + ". Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                                'Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                                Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                            End If
                        Else
                            Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        End If
                        '============================ END OF CASE 1 ATASAN
                    ElseIf spv <> user_on And mng = user_on And TxtDetailStatusPengajuan.Text = "Disetujui Atasan" Then 'case 2 atasan
                        'process - disetujui manajer
                        'Response.Write("<script>alert('Bukan Cuti Biasa  -- Proses Persetujuan MNG')</script>")
                        '***coreprocess
                        If saldo_tahunan <> 0 Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                            If saldo_tahunan < Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                                Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin sales')</script>")
                                Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                            Else
                                Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVMNG = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                                'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                                'Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                                'email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                                '***get code cabang 
                                Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                                Dim conns As String
                                If kodecab = 112 Then
                                    conns = "MyConnCloudDnetWTSALES88"
                                Else
                                    conns = "MyConnCloudDnetWTSALES180"
                                End If
                                'email_sales
                                Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima dengan Alasan : " + alasan + ". Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                                Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                                Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                            End If
                        Else
                            Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        End If
                    End If
                    '==========================================END OF CASE 2 ATASAN cuti tidak mengurangi saldo
                Else 'Cuti Biasa -- MENGURANGI SALDO =======================================================
                    '***validasi apakah spv terpilih sama dengan user yg sedang masuk
                    If spv = user_on And mng = "--" And TxtDetailStatusPengajuan.Text = "Pending" Then 'kondisi ketika mng --- 'case 1 atasan
                        'process 'process - disetujui manajer
                        'Response.Write("<script>alert('Cuti Biasa  -- Proses Persetujuan MNG')</script>")
                        '***coreprocess
                        'listdate untuk menampung semua tanggal ketika retrive dari database
                        Dim textBoxes As List(Of DateTime) = New List(Of DateTime)
                        'list date time jika ada yg sebelum tgl saldo pc berlaku
                        Dim sblmpc As List(Of DateTime) = New List(Of DateTime)()
                        'list date time jika ada yg setelah tgl saldo pc berlaku
                        Dim stlhpc As List(Of DateTime) = New List(Of DateTime)()
                        Dim jml_saldo_staff As Integer
                        '*** delete
                        '***logic ketika saldo tahunan dan saldo pending masih berlaku
                        If saldo_tahunanberlaku >= DateTime.Now Then
                            If saldo_pendingberlaku >= DateTime.Now Then
                                jml_saldo_staff = saldo_tahunan + saldo_pending
                            End If
                        End If
                        '***logic ketika saldo tahunan berlaku dan saldo pending hangus
                        If saldo_tahunanberlaku >= DateTime.Now Then
                            If saldo_pendingberlaku < DateTime.Now Then
                                jml_saldo_staff = saldo_tahunan
                            End If
                        End If
                        '*** delete
                        '***clear array
                        ListTgl.Clear()
                        ListTgl_Pend.Clear()
                        '***get new list tgl pending dan tgl tahunan value to array
                        'GET LIST TGL tahunan
                        Call GetData_DetaiIzinStaff("select * from data_izin_detail_sales where izin_id = '" + TxtDetailIdIzinSales.Text + "'", "MyConnCloudDnet171", 5)
                        'GET LIST TGL pending cuti
                        Call GetData_DetaiIzinStaff("select * from DATA_IZIN_DETAILPC_sales where izin_id = '" + TxtDetailIdIzinSales.Text + "'", "MyConnCloudDnet171", 6)
                        '**GET ALL DATE YG DI AJUKAN [ListTgl, ListTgl_Pend]

                        '***DELETE
                        '*** add each tgl item ke list array textbox untuk di satukan 
                        'For Each ITEMx As String In ListTgl
                        '    'Response.Write("<script>alert('List Tgl : " + ITEMx + "')</script>")
                        '    textBoxes.Add(ITEMx)
                        'Next
                        'For Each ITEM As String In ListTgl_Pend
                        '    'Response.Write("<script>alert('ListTgl_Pend: " + ITEM + "')</script>")
                        '    textBoxes.Add(ITEM)
                        'Next
                        '***DELETE

                        '***==================ADDE NEW CODE
                        '***logic memilih ketika saldo tahunan tidak kosong
                        '***update sesuai dengan jml saldo sales 
                        If saldo_tahunan < ListTgl.Count Then
                            Response.Write("<script>alert('Saldo Izin Tahunan Sales tersebut kurang dari Jumlah Pengajuan Tanggal. Proses Approval gagal!')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        ElseIf saldo_tahunan >= ListTgl.Count And saldo_tahunan <> 0 Then
                            Dim saldo_update_thn As Integer = saldo_tahunan - ListTgl.Count
                            Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                            'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                            Call UpdateData_Server("update DATA_IZIN_HEADER_sales set IZIN_SALDO ='" & saldo_update_thn & "' where IZIN_NIK = '" & TxtDetailNik.Text & "'  ", "MyConnCloudDnet171")
                            '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                            '***get code cabang 
                            Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                            Dim conns As String
                            If kodecab = 112 Then
                                conns = "MyConnCloudDnetWTSALES88"
                            Else
                                conns = "MyConnCloudDnetWTSALES180"
                            End If
                            'email_sales
                            Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima dengan Alasan : " + alasan + ". Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                            Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        End If
                        If saldo_pending < ListTgl_Pend.Count Then
                            Response.Write("<script>alert('Saldo Pending Cuti Sales Tersebut kurang dari jumlah pengajuan yang memotong saldo pending cuti.Proses Pengurangan Saldo Cuti Gagal')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        ElseIf saldo_pending >= sblmpc.Count And saldo_pending <> 0 Then
                            Dim saldo_update_thn As Integer = saldo_pending - ListTgl_Pend.Count
                            Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                            'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                            Call UpdateData_Server("update DATA_IZIN_HEADER_sales set IZIN_SALDO_PC ='" & saldo_update_thn & "' where IZIN_NIK = '" & TxtDetailNik.Text & "' ", "MyConnCloudDnet171")
                            '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                            '***get code cabang 
                            Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                            Dim conns As String
                            If kodecab = 112 Then
                                conns = "MyConnCloudDnetWTSALES88"
                            Else
                                conns = "MyConnCloudDnetWTSALES180"
                            End If
                            'email_sales
                            Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima dengan Alasan : " + alasan + ". Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                            Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        End If

                        '==================================================================BEGIN PROCESS OLD
                        '***Logic di bawah ini di gunakan untuk eliminasi otomatis by system sesuai jumlah saldo izin tahunan.  Izin yang masuk hanya akan di terima sesuai jumlah saldo berjalan
                        '***logic eliminasi isi list array. Pisahkan menjadi tgl pc dan stlh pc
                        'If saldo_tahunanberlaku >= DateTime.Now And saldo_tahunan <> 0 Then
                        '    For i As Integer = 0 To Convert.ToInt32(TxtDetailJmlPengajuan.Text) - 1
                        '        If textBoxes(i) <= saldo_pendingberlaku Then 'logic eliminasi isi list textboxes yg sebelum pc berlaku
                        '            'masuk ke list array pc
                        '            sblmpc.Add(textBoxes(i))
                        '        ElseIf textBoxes(i) >= saldo_pendingberlaku Then 'logic eliminasi isi list textboxes yg setelah pc berlaku (masukan ke list baru) 
                        '            'masuk ke list array tahunan
                        '            stlhpc.Add(textBoxes(i))
                        '        End If
                        '    Next
                        '    '***Process 1///////////////////////////////////////////////////////////////////////////////////
                        '    '***cek apakah tgl yg di ajukan lebih dari jml saldo izin tahunan. jika lebih maka gagal proses save
                        '    If stlhpc.Count > saldo_tahunan Then
                        '        'Response.Write("<script>alert('Jumlah Tanggal yang anda ajukan lebih dari jumlah saldo izin tahunan anda. Tanggal tersebut akan di hapus. Silahkan cek detail nya pada Menu List Izin - Staff!')</script>")
                        '        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        '        '[remove tgl yang lebih dari jml saldo tahunan]CEK APAKAH ADA TGL YG LEBIH DARI JML SALDO TAHUNAN
                        '        If saldo_tahunan < stlhpc.Count Then
                        '            Dim x As String = stlhpc.Count - saldo_tahunan
                        '            'Response.Write("<script>alert('remove tgl : " + x + "')</script>")
                        '            Dim d As Integer
                        '            For d = stlhpc.Count - 1 To stlhpc.Count - x Step -1
                        '                If stlhpc(d) <= saldo_tahunanberlaku Then
                        '                    'Response.Write("<script>alert('remove tgl : " + arr_notpc(d) + "')</script>")
                        '                    stlhpc.RemoveAt(d)
                        '                End If
                        '            Next
                        '        End If
                        '    ElseIf sblmpc.Count > saldo_pending Then
                        '        'Response.Write("<script>alert('Tgl yang anda ajukan, lebih dari jumlah pending cuti anda. sisa pengajuan akan mengurangi saldo cuti tahunan anda!')</script>")
                        '        'cek selisih saldo pending dengan tgl pengajuan pending [a]. 
                        '        Dim selisihpending As Integer
                        '        selisihpending = sblmpc.Count - saldo_pending
                        '        'cek selisih saldo tahunan dan tgl yg di ambil pada saldo tahunan[b]. 
                        '        'Response.Write("<script>alert('Selisih pending : " + selisihpending + "')</script>")
                        '        Dim selisihtahunan As Integer
                        '        selisihtahunan = saldo_tahunan - stlhpc.Count
                        '        'Response.Write("<script>alert('Selisih Tahunan : " + selisihtahunan + "')</script>")
                        '        If selisihtahunan = 0 Then
                        '            'Response.Write("<script>alert('Selisih Tahunan = 0')</script>")
                        '            'sisa saldo tahunan tidak ada. atau 0 ' jika 0 maka proses gagal
                        '            Response.Write("<script>alert('Saldo Cuti Tahunan Staff Telah habis. Pengurangan saldo cuti tahunan gagal. Proses pengajuan gagal!')</script>")
                        '            Response.Write("<script>window.location.href='home.aspx';</script>")
                        '        ElseIf selisihtahunan > 0 Then
                        '            If selisihpending = selisihtahunan Then 'jika [a] dam [b] sama maka pindahkan
                        '                'simpan nilai nya di array temporary
                        '                'For Each item As DateTime In arr_pc
                        '                '    arr_temp.Add(item)
                        '                'Next
                        '                For i As Integer = 0 To selisihpending - 1
                        '                    arr_temp.Add(sblmpc(i))
                        '                Next
                        '                'remove tgl tersebut di arr_pc
                        '                Dim d, x As Integer
                        '                For x = 0 To arr_temp.Count - 1
                        '                    For d = sblmpc.Count - 1 To 0 Step -1
                        '                        If sblmpc(d) = arr_temp(x) Then
                        '                            sblmpc.RemoveAt(d)
                        '                        End If
                        '                    Next
                        '                Next
                        '                'add tgl tersebut di arr_notpc
                        '                For a As Integer = 0 To arr_temp.Count - 1
                        '                    stlhpc.Add(arr_temp(a))
                        '                Next
                        '            Else ' jika tidak maka proses gagal
                        '                Response.Write("<script>alert('Proses pengurangan saldo cuti gagal, karena jumlah selisih pending cuti dan selisih izin tidak sama!')</script>")
                        '                Response.Write("<script>window.location.href='home.aspx';</script>")
                        '            End If
                        '        End If
                        '    End If
                        '    '***Process 2 /////////////////////////////////////////////////////////////////////
                        '    '***update sesuai dengan jml saldo sales 
                        '    If saldo_tahunan < stlhpc.Count Then
                        '        Response.Write("<script>alert('Saldo Izin Tahunan Sales tersebut kurang dari Jumlah Pengajuan Tanggal. Proses Approval gagal!')</script>")
                        '        Response.Write("<script>window.location.href='home.aspx';</script>")
                        '    ElseIf saldo_tahunan >= stlhpc.Count Then
                        '        Dim saldo_update_thn As Integer = saldo_tahunan - stlhpc.Count
                        '        Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                        '        'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                        '        Call UpdateData_Server("update DATA_IZIN_HEADER_sales set IZIN_SALDO ='" & saldo_update_thn & "' where IZIN_NIK = '" & TxtDetailNik.Text & "'  ", "MyConnCloudDnet171")
                        '        '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                        '        '***get code cabang 
                        '        Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                        '        Dim conns As String
                        '        If kodecab = 112 Then
                        '            conns = "MyConnCloudDnetWTSALES88"
                        '        Else
                        '            conns = "MyConnCloudDnetWTSALES180"
                        '        End If
                        '        'email_sales
                        '        Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                        '        'Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                        '        'Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                        '        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        '    End If
                        '    If saldo_pending < sblmpc.Count Then
                        '        Response.Write("<script>alert('Saldo Pending Cuti Sales Tersebut kurang dari jumlah pengajuan yang memotong saldo pending cuti.Proses Pengurangan Saldo Cuti Gagal')</script>")
                        '        Response.Write("<script>window.location.href='home.aspx';</script>")
                        '    ElseIf saldo_pending >= sblmpc.Count Then
                        '        Dim saldo_update_thn As Integer = saldo_pending - sblmpc.Count
                        '        Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                        '        'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                        '        Call UpdateData_Server("update DATA_IZIN_HEADER_sales set IZIN_SALDO_PC ='" & saldo_update_thn & "' where IZIN_NIK = '" & TxtDetailNik.Text & "' ", "MyConnCloudDnet171")
                        '        '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                        '        '***get code cabang 
                        '        Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                        '        Dim conns As String
                        '        If kodecab = 112 Then
                        '            conns = "MyConnCloudDnetWTSALES88"
                        '        Else
                        '            conns = "MyConnCloudDnetWTSALES180"
                        '        End If
                        '        'email_sales
                        '        Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                        '        'Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                        '        'Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                        '        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        '    End If
                        'Else
                        '    Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                        '    Response.Write("<script>window.location.href='home.aspx';</script>")
                        'End If
                        '==================================================================END PROCESS OLD
                        'Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                        'Response.Write("<script>window.location.href='home.aspx';</script>")
                    ElseIf spv <> user_on And mng = user_on And TxtDetailStatusPengajuan.Text = "Disetujui Atasan" Then 'case 2 atasan
                        'process - disetujui manajer -- CUTI BIASA CASE MANAJER LOGIN APPROVAL
                        'Response.Write("<script>alert('Cuti Biasa  -- Proses Persetujuan MNG')</script>")
                        '***coreprocess
                        Dim textBoxes As List(Of DateTime) = New List(Of DateTime)
                        'list date time jika ada yg sebelum tgl saldo pc berlaku
                        Dim sblmpc As List(Of DateTime) = New List(Of DateTime)()
                        'list date time jika ada yg setelah tgl saldo pc berlaku
                        Dim stlhpc As List(Of DateTime) = New List(Of DateTime)()
                        Dim jml_saldo_staff As Integer
                        '***logic ketika saldo tahunan dan saldo pending masih berlaku
                        If saldo_tahunanberlaku >= DateTime.Now Then
                            If saldo_pendingberlaku >= DateTime.Now Then
                                jml_saldo_staff = saldo_tahunan + saldo_pending
                            End If
                        End If
                        '***logic ketika saldo tahunan berlaku dan saldo pending hangus
                        If saldo_tahunanberlaku >= DateTime.Now Then
                            If saldo_pendingberlaku < DateTime.Now Then
                                jml_saldo_staff = saldo_tahunan
                            End If
                        End If
                        '***clear array
                        ListTgl.Clear()
                        ListTgl_Pend.Clear()
                        '***get new list tgl pending dan tgl tahunan value to array
                        'GET LIST TGL tahunan
                        Call GetData_DetaiIzinStaff("select * from data_izin_detail_sales where izin_id = '" + TxtDetailIdIzinSales.Text + "'", "MyConnCloudDnet171", 5)
                        'GET LIST TGL pending cuti
                        Call GetData_DetaiIzinStaff("select * from DATA_IZIN_DETAILPC_sales where izin_id = '" + TxtDetailIdIzinSales.Text + "'", "MyConnCloudDnet171", 6)

                        '***==================ADDE NEW CODE
                        '***logic memilih ketika saldo tahunan tidak kosong
                        '***update sesuai dengan jml saldo sales 
                        If saldo_tahunan < ListTgl.Count Then
                            Response.Write("<script>alert('Saldo Izin Tahunan Sales tersebut kurang dari Jumlah Pengajuan Tanggal. Proses Approval gagal!')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        ElseIf saldo_tahunan >= ListTgl.Count And saldo_tahunan <> 0 Then
                            Dim saldo_update_thn As Integer = saldo_tahunan - ListTgl.Count
                            Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVMNG = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                            'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                            Call UpdateData_Server("update DATA_IZIN_HEADER_sales set IZIN_SALDO ='" & saldo_update_thn & "' where IZIN_NIK = '" & TxtDetailNik.Text & "'  ", "MyConnCloudDnet171")
                            '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                            '***get code cabang 
                            Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                            Dim conns As String
                            If kodecab = 112 Then
                                conns = "MyConnCloudDnetWTSALES88"
                            Else
                                conns = "MyConnCloudDnetWTSALES180"
                            End If
                            'email_sales
                            Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima dengan Alasan : " + alasan + ". Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                            Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        End If
                        If saldo_pending < ListTgl_Pend.Count Then
                            Response.Write("<script>alert('Saldo Pending Cuti Sales Tersebut kurang dari jumlah pengajuan yang memotong saldo pending cuti.Proses Pengurangan Saldo Cuti Gagal')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        ElseIf saldo_pending >= sblmpc.Count And saldo_pending <> 0 Then
                            Dim saldo_update_thn As Integer = saldo_pending - ListTgl_Pend.Count
                            Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVMNG = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                            'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                            Call UpdateData_Server("update DATA_IZIN_HEADER_sales set IZIN_SALDO_PC ='" & saldo_update_thn & "' where IZIN_NIK = '" & TxtDetailNik.Text & "' ", "MyConnCloudDnet171")
                            '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                            '***get code cabang 
                            Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                            Dim conns As String
                            If kodecab = 112 Then
                                conns = "MyConnCloudDnetWTSALES88"
                            Else
                                conns = "MyConnCloudDnetWTSALES180"
                            End If
                            'email_sales
                            Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima dengan Alasan : " + alasan + ". Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                            Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        End If

                        '***OLD CODE LOGIC =========================================================================
                        '*** add each tgl item ke list array textbox untuk di satukan 
                        'For Each ITEMx As String In ListTgl
                        '    'Response.Write("<script>alert('List Tgl : " + ITEMx + "')</script>")
                        '    textBoxes.Add(ITEMx)
                        'Next
                        'For Each ITEM As String In ListTgl_Pend
                        '    'Response.Write("<script>alert('ListTgl_Pend: " + ITEM + "')</script>")
                        '    textBoxes.Add(ITEM)
                        'Next
                        ''***logic eliminasi isi list array. Pisahkan menjadi tgl pc dan stlh pc
                        'If saldo_tahunanberlaku >= DateTime.Now And saldo_tahunan <> 0 Then
                        '    For i As Integer = 0 To Convert.ToInt32(TxtDetailJmlPengajuan.Text) - 1
                        '        If textBoxes(i) <= saldo_pendingberlaku Then 'logic eliminasi isi list textboxes yg sebelum pc berlaku
                        '            'masuk ke list array pc
                        '            sblmpc.Add(textBoxes(i))
                        '        ElseIf textBoxes(i) >= saldo_pendingberlaku Then 'logic eliminasi isi list textboxes yg setelah pc berlaku (masukan ke list baru) 
                        '            'masuk ke list array tahunan
                        '            stlhpc.Add(textBoxes(i))
                        '        End If
                        '    Next
                        'Else
                        '    Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                        '    Response.Write("<script>window.location.href='home.aspx';</script>")
                        'End If
                        ''***cek apakah tgl yg di ajukan lebih dari jml saldo izin tahunan. jika lebih maka gagal proses save
                        'If stlhpc.Count > saldo_tahunan Then
                        '    'Response.Write("<script>alert('Jumlah Tanggal yang anda ajukan lebih dari jumlah saldo izin tahunan anda. Tanggal tersebut akan di hapus. Silahkan cek detail nya pada Menu List Izin - Staff!')</script>")
                        '    'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        '    '[remove tgl yang lebih dari jml saldo tahunan]CEK APAKAH ADA TGL YG LEBIH DARI JML SALDO TAHUNAN
                        '    If saldo_tahunan < stlhpc.Count Then
                        '        Dim x As String = stlhpc.Count - saldo_tahunan
                        '        'Response.Write("<script>alert('remove tgl : " + x + "')</script>")
                        '        Dim d As Integer
                        '        For d = stlhpc.Count - 1 To stlhpc.Count - x Step -1
                        '            If stlhpc(d) <= saldo_tahunanberlaku Then
                        '                'Response.Write("<script>alert('remove tgl : " + arr_notpc(d) + "')</script>")
                        '                stlhpc.RemoveAt(d)
                        '            End If
                        '        Next
                        '    End If
                        'ElseIf sblmpc.Count > saldo_pending Then
                        '    'Response.Write("<script>alert('Tgl yang anda ajukan, lebih dari jumlah pending cuti anda. sisa pengajuan akan mengurangi saldo cuti tahunan anda!')</script>")
                        '    'cek selisih saldo pending dengan tgl pengajuan pending [a]. 
                        '    Dim selisihpending As Integer
                        '    selisihpending = sblmpc.Count - saldo_pending
                        '    'cek selisih saldo tahunan dan tgl yg di ambil pada saldo tahunan[b]. 
                        '    'Response.Write("<script>alert('Selisih pending : " + selisihpending + "')</script>")
                        '    Dim selisihtahunan As Integer
                        '    selisihtahunan = saldo_tahunan - stlhpc.Count
                        '    'Response.Write("<script>alert('Selisih Tahunan : " + selisihtahunan + "')</script>")
                        '    If selisihtahunan = 0 Then
                        '        'Response.Write("<script>alert('Selisih Tahunan = 0')</script>")
                        '        'sisa saldo tahunan tidak ada. atau 0 ' jika 0 maka proses gagal
                        '        Response.Write("<script>alert('Saldo Cuti Tahunan Staff Telah habis. Pengurangan saldo cuti tahunan gagal. Proses pengajuan gagal!')</script>")
                        '        Response.Write("<script>window.location.href='home.aspx';</script>")
                        '    ElseIf selisihtahunan > 0 Then
                        '        If selisihpending = selisihtahunan Then 'jika [a] dam [b] sama maka pindahkan
                        '            'simpan nilai nya di array temporary
                        '            'For Each item As DateTime In arr_pc
                        '            '    arr_temp.Add(item)
                        '            'Next
                        '            For i As Integer = 0 To selisihpending - 1
                        '                arr_temp.Add(sblmpc(i))
                        '            Next
                        '            For Each item As DateTime In sblmpc
                        '                For Each itemz As DateTime In arr_temp
                        '                    If item = itemz Then
                        '                        'Response.Write("<script>alert('Ini tgl yg dipindahkan " + itemz + "')</script>")
                        '                    End If
                        '                Next
                        '            Next
                        '            'remove tgl tersebut di arr_pc
                        '            Dim d, x As Integer
                        '            For x = 0 To arr_temp.Count - 1
                        '                For d = sblmpc.Count - 1 To 0 Step -1
                        '                    If sblmpc(d) = arr_temp(x) Then
                        '                        sblmpc.RemoveAt(d)
                        '                    End If
                        '                Next
                        '            Next
                        '            'add tgl tersebut di arr_notpc
                        '            For a As Integer = 0 To arr_temp.Count - 1
                        '                stlhpc.Add(arr_temp(a))
                        '            Next
                        '        Else ' jika tidak maka proses gagal
                        '            Response.Write("<script>alert('Proses pengurangan saldo cuti gagal, karena jumlah selisih pending cuti dan selisih izin tidak sama!')</script>")
                        '            Response.Write("<script>window.location.href='home.aspx';</script>")
                        '        End If
                        '    End If
                        'End If
                        ''***update sesuai dengan jumlah index pada masing masing array
                        'If saldo_tahunan < stlhpc.Count Then
                        '    Response.Write("<script>alert('Saldo Izin Tahunan Sales tersebut kurang dari Jumlah Pengajuan Tanggal. Proses Approval gagal!')</script>")
                        'ElseIf saldo_tahunan >= stlhpc.Count Then
                        '    Dim saldo_update_thn As Integer = saldo_tahunan - stlhpc.Count
                        '    Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVMNG = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "")
                        '    'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                        '    Call UpdateData_Server("update DATA_IZIN_HEADER_sales set IZIN_SALDO ='" & saldo_update_thn & "' where IZIN_NIK = '" & TxtDetailNik.Text & "'  ", "MyConnCloudDnet171")
                        '    '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                        '    '***get code cabang 
                        '    Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                        '    Dim conns As String
                        '    If kodecab = 112 Then
                        '        conns = "MyConnCloudDnetWTSALES88"
                        '    Else
                        '        conns = "MyConnCloudDnetWTSALES180"
                        '    End If
                        '    'email_sales
                        '    Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                        '    'Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                        '    'Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                        '    'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        'End If
                        'If saldo_pending < sblmpc.Count Then
                        '    Response.Write("<script>alert('Saldo Pending Cuti Sales Tersebut kurang dari ')</script>")
                        'ElseIf saldo_pending >= sblmpc.Count Then
                        '    Dim saldo_update_thn As Integer = saldo_pending - sblmpc.Count
                        '    Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVMNG = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                        '    'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                        '    Call UpdateData_Server("update DATA_IZIN_HEADER_sales set IZIN_SALDO_PC ='" & saldo_update_thn & "' where IZIN_NIK = '" & TxtDetailNik.Text & "'  ", "MyConnCloudDnet171")
                        '    '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                        '    '***get code cabang 
                        '    Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                        '    Dim conns As String
                        '    If kodecab = 112 Then
                        '        conns = "MyConnCloudDnetWTSALES88"
                        '    Else
                        '        conns = "MyConnCloudDnetWTSALES180"
                        '    End If
                        '    'email_sales
                        '    Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                        '    'Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                        '    'Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                        '    'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        'End If
                        'Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                    End If
                End If
            ElseIf jenis_izin = "Tidak Masuk Kantor" Then 'untuk tidak masuk kantor -- hanya sampai spv ( 1 atasan saj / atasan langsungnya [sc])
                '***validasi apakah spv terpilih sama dengan user yg sedang masuk
                If spv = user_on And TxtDetailStatusPengajuan.Text = "Pending" Then 'kondisi ketika mng --- 'case 1 atasan
                    'process 'process - disetujui manajer
                    'Response.Write("<script>alert('Cuti Biasa  -- Proses Persetujuan MNG')</script>")
                    If TxtDetailAlasanPengajuan.Text = "Izin Potong Cuti" Or TxtDetailAlasanPengajuan.Text = "Sakit Potong Cuti" Then 'akan mengurangi saldo izin
                        'get spv nik dan mng nik dari staff tsb[*]spv/mng
                        'get nilai field saldo cuti [*] [saldo_tahunan/saldo_tahunanberlaku/saldo_pending/saldo_pendingberlaku]
                        '***coreprocess
                        If saldo_tahunan <> 0 Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                            If saldo_tahunan <= Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                                Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin sales')</script>")
                                Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                            Else
                                Dim jmlpengajuan As Integer = Convert.ToInt32(TxtDetailJmlPengajuan.Text)
                                Dim saldo_calc As Integer = saldo_tahunan - jmlpengajuan
                                '**validasi alasan setuju
                                If TxtDetailAlasanBtlStj.Text <> "" Then
                                    Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer' , IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                                    'If DropDownListTidakMasuk.Text = "Izin Potong Cuti" Or DropDownListTidakMasuk.Text = "Sakit Potong Cuti" Then
                                    'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                                    Call UpdateData_Server("update DATA_IZIN_HEADER_sales set IZIN_SALDO ='" & saldo_calc & "' where IZIN_NIK = '" + TxtDetailNik.Text + "'  ", "MyConnCloudDnet171")
                                    'End If
                                    '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                                    '***get code cabang 
                                    Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                                    Dim conns As String
                                    If kodecab = 112 Then
                                        conns = "MyConnCloudDnetWTSALES88"
                                    Else
                                        conns = "MyConnCloudDnetWTSALES180"
                                    End If
                                    'email_sales
                                    Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                                    Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima dengan Alasan : " + alasan + ". Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                                    Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                                    Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                                Else
                                    Response.Write("<script>alert('Alasan Approve Wajib di Isi. Proses Approval Gagal. Ulangi Kembali')</script>")
                                    Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                                End If
                            End If

                        Else
                            Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        End If
                    Else 'selain izin potong cuti dan sakit potong cuti -- tidak mengurangi saldo izin
                        'get spv nik dan mng nik dari staff tsb[*]spv/mng
                        'get nilai field saldo cuti [*] [saldo_tahunan/saldo_tahunanberlaku/saldo_pending/saldo_pendingberlaku]
                        '***coreprocess
                        If saldo_tahunan <> 0 Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                            'If saldo_tahunan <= Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                            'Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin Sales')</script>")
                            'Response.Write("<script>window.location.href='home.aspx';</script>")
                            'Else
                            'saldo_cutiStaff = saldo_cutiStaff - TxtDetailJmlPengajuan.Text
                            Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                            'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                            'Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                            '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                            '***get code cabang 
                            Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                            Dim conns As String
                            If kodecab = 112 Then
                                conns = "MyConnCloudDnetWTSALES88"
                            Else
                                conns = "MyConnCloudDnetWTSALES180"
                            End If
                            'email_sales
                            Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima dengan Alasan : " + alasan + ". Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                            Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                            'End If
                        Else
                            Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        End If
                    End If
                ElseIf mng = user_on And TxtDetailStatusPengajuan.Text = "Disetujui Atasan" Then 'case 2 atasan
                    'process - disetujui manajer
                    'Response.Write("<script>alert('Cuti Biasa  -- Proses Persetujuan MNG')</script>")
                    If TxtDetailAlasanPengajuan.Text = "Izin Potong Cuti" Or TxtDetailAlasanPengajuan.Text = "Sakit Potong Cuti" Then 'akan mengurangi saldo izin
                        'get spv nik dan mng nik dari staff tsb[*]spv/mng
                        'get nilai field saldo cuti [*] [saldo_tahunan/saldo_tahunanberlaku/saldo_pending/saldo_pendingberlaku]
                    Else
                        'empty
                    End If
                End If
            ElseIf jenis_izin = "Izin Keluar Kantor" Or jenis_izin = "Izin Terlambat" Then 'untuk izin keluar dan izin terlambat
                '***validasi apakah spv terpilih sama dengan user yg sedang masuk
                If spv = user_on And TxtDetailStatusPengajuan.Text = "Pending" Then 'kondisi ketika mng --- 'case 1 atasan
                    'process 'process - disetujui manajer
                    'Response.Write("<script>alert('Cuti Biasa  -- Proses Persetujuan MNG')</script>")
                    'get spv nik dan mng nik dari staff tsb[*]spv/mng
                    'get nilai field saldo cuti [*][saldo_tahunan/saldo_tahunanberlaku/saldo_pending/saldo_pendingberlaku]
                    '***coreprocess
                    If saldo_tahunan <> 0 Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                        If saldo_tahunan <= Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                            Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin Sales')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        Else
                            Dim saldo_calc As Integer = saldo_tahunan - Convert.ToInt32(TxtDetailJmlPengajuan.Text)
                            '**validasi alasan setuju
                            If TxtDetailAlasanBtlStj.Text <> "" Then
                                Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "' ", "MyConnCloudDnet171")
                                'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                                'Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                                '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                                '***get code cabang 
                                Dim kodecab As Integer = TxtDetailNik.Text.Substring(0, 3) 'get kode cabang dari nik 
                                Dim conns As String
                                If kodecab = 112 Then
                                    conns = "MyConnCloudDnetWTSALES88"
                                Else
                                    conns = "MyConnCloudDnetWTSALES180"
                                End If
                                'email_sales
                                Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailNama.Text & "'", conns, 3)
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzinSales.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima dengan Alasan : " + alasan + ". Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                                Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzinSales.Text + "')</script>")
                                Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                            Else
                                Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                                Response.Write("<script>window.location.href='home.aspx';</script>")
                            End If
                        End If
                    Else
                        Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                        Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                    End If
                ElseIf mng = user_on And TxtDetailStatusPengajuan.Text = "Disetujui Atasan" Then 'case 2 atasan
                    'process - disetujui manajer
                    'Response.Write("<script>alert('Cuti Biasa  -- Proses Persetujuan MNG')</script>")
                End If
            End If
        End If
    End Sub
    'Button Decline
    Protected Sub BtnDeclineDetaildanApproval_Click(sender As Object, e As EventArgs) Handles BtnDeclineDetaildanApproval.Click
        'get alasan 
        Dim alasan As String = TxtDetailAlasanBtlStj.Text
        'Get Who's Login 
        Dim user_on As String = LabelUsernameLogin.Text 'FAIZ/DAVIDH/112VYE
        Dim user_id As String = LabelUsernameLoginID.Text '-/DH/
        Dim user_nama As String = LabelNama.Text 'Untuk nama sales
        'get status pengajuan 
        Dim status_pengajuan As String = TxtDetailStatusPengajuan.Text
        Dim Login_user As String = LabelUserLogin.Text 'Sales / SM /SPV
        'LabelUsernameLoginID.text untuk id ketika spv login /DH/. TAPI KETIKA MNG / SALES LOGIN VALUENYA ""
        Dim jenis_izin As String = txtDetailJenisIzin.Text
        'get spv mng sales terpilih[mng, spv]
        Call GetData_DetaiIzinStaff("select izin_nik_appvmng, izin_nik_appvspv from data_izin_header_sales where izin_nik ='" + TxtDetailNik.Text + "'", "MyConnCloudDnet171", 7)
        'Get Alasan Cuti [izin-jenisSales, izin_alasanSales]
        Call GetData_DetaiIzinStaff("select * from data_izin_body_sales where izin_id ='" + TxtDetailIdIzinSales.Text + "'", "MyConnCloudDnet171", 10)
        'get saldo tahunan dan saldo pending sales[saldo_tahunan/saldo_tahunanberlaku/saldo_pending/saldo_pendingberlaku]
        Real_saldoStaff("select IZIN_SALDO, IZIN_SALDO_CUTI_TAHUNAN_BERLAKU, IZIN_SALDO_PC, IZIN_SALDO_PC_BERLAKU from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + TxtDetailNik.Text + "'")
        'get jenis permohonan izin berdasarkan id izin[izin_jenisApv]
        Call GetData_DetaiIzinSales("select izin_jenis, izin_alasan  from data_izin_body_sales where izin_id = '" + TxtDetailIdIzinSales.Text + "'", "MyConnCloudDnet171", 1)
        '***validasi alasan tidak boleh kosong
        If TxtDetailAlasanBtlStj.Text <> "" Then
            If Login_user = "Sales" Then
                '***validasi apakah nik terpilih merupakan nik yang sama dengan nik yg login sebagai sales
                If LabelUsernameLogin.Text = TxtDetailNik.Text Then
                    '***validasi apakah status izin = Pending. Else nya gagal batal
                    If TxtDetailStatusPengajuan.Text = "Pending" Then 'sales hanya bisa melakukan pembatalan saat pengajuan izin yang bersangkutan statusnya pending
                        If saldo_tahunan >= 0 Then
                            Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_STATUS ='Dibatalkan Sales', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "'", "MyConnCloudDnet171")
                            '***email ke staff tsb cari berdasarkan txtdetailnik
                            Dim potong_kode As String = TxtDetailNik.Text.Remove(0, 3)
                            Dim server_sales As String
                            If potong_kode = "112" Then
                                server_sales = "MyConnCloudDnetWTSALES88"
                            Else
                                server_sales = "MyConnCloudDnetWTSALES180"
                            End If
                            Call GetData_DetaiIzinStaff("select sales_email from data_salesman where SALES_Kode = '" + potong_kode + "'", server_sales, 8)
                            'emailSalesAktif
                            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzinSales.Text + " telah di batalkan Sales yang Bersangkutan dengan Alasan : " + alasan + " <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailSalesAktif)
                            Response.Write("<script>alert('Anda Berhasil Membatalkan Pengajuan Izin Sales !')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        Else
                            Response.Write("<script>alert('Saldo Cuti anda kurang dari 0 atau tidak ada.')</script>")
                        End If
                    Else
                        Response.Write("<script>alert('Gagal Melakukan Pembatalan, Status Izin sudah Tidak Pending!')</script>")
                        Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                    End If
                End If
            ElseIf Login_user = "SPV" Then 'hanya untuk spv dengan 1 atasan langsung (dh - faiz)
                '***validasi apakah status izin = Pending 
                If TxtDetailStatusPengajuan.Text = "Pending" Then
                    If saldo_tahunan >= 0 Then
                        If spv = user_id Then
                            'update status di batalkan atasan
                            Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_STATUS ='Dibatalkan Atasan', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "'", "MyConnCloudDnet171")
                            '***email staff
                            Dim potong_kode As String = TxtDetailNik.Text.Remove(0, 3)
                            Dim server_sales As String
                            If potong_kode = "112" Then
                                server_sales = "MyConnCloudDnetWTSALES88"
                            Else
                                server_sales = "MyConnCloudDnetWTSALES180"
                            End If
                            Call GetData_DetaiIzinStaff("select sales_email from data_salesman where SALES_Kode = '" + potong_kode + "'", server_sales, 8)
                            'emailSalesAktif
                            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzinSales.Text + " telah di batalkan Atasan anda dengan Alasan : " + alasan + " <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailSalesAktif)
                            Response.Write("<script>alert('Anda Berhasil Membatalkan Pengajuan Izin Sales !')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        Else
                            Response.Write("<script>alert('Gagal Melakukan Pembatalan, Anda Bukan SPV dari Sales Ini!')</script>")
                            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                        End If
                    Else
                        Response.Write("<script>alert('Gagal Melakukan Pembatalan, Saldo tahunan sales kosong/tidak ada!')</script>")
                        Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                    End If
                Else
                    Response.Write("<script>alert('Gagal Melakukan Pembatalan, Status Izin sudah Di Setujui Manajer!')</script>")
                    Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                End If
            ElseIf Login_user = "SM" Then
                '***validasi mng yg login sama dengan mng dari izin tsb (hanya untuk izin yg mng nya <> --)
                'if spv = user_on / else if mng = user_on
                If spv = user_on Then
                    '***validasi apakah status izin = Disetujui Atasan 
                    If TxtDetailStatusPengajuan.Text = "Pending" Then
                        Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_STATUS ='Dibatalkan Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "'", "MyConnCloudDnet171")
                        '***email staff
                        Dim potong_kode As String = TxtDetailNik.Text.Remove(0, 3)
                        Dim server_sales As String
                        If potong_kode = "112" Then
                            server_sales = "MyConnCloudDnetWTSALES88"
                        Else
                            server_sales = "MyConnCloudDnetWTSALES180"
                        End If
                        Call GetData_DetaiIzinStaff("select sales_email from data_salesman where SALES_Kode = '" + potong_kode + "'", server_sales, 8)
                        'emailSalesAktif
                        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzinSales.Text + " telah di batalkan Manajer anda dengan Alasan : " + alasan + " <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailSalesAktif)
                        Response.Write("<script>alert('Anda Berhasil Membatalkan Pengajuan Izin Sales !')</script>")
                        Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                    Else
                        Response.Write("<script>alert('Gagal Melakukan Pembatalan, status izin tersebut bukan pending!')</script>")
                        Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                    End If
                ElseIf mng = user_on Then
                    '***validasi apakah status izin = Disetujui Atasan 
                    If TxtDetailStatusPengajuan.Text = "Disetujui Atasan" Then
                        Call UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_STATUS ='Dibatalkan Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzinSales.Text & "'", "MyConnCloudDnet171")
                        '***email staff
                        Dim potong_kode As String = TxtDetailNik.Text.Remove(0, 3)
                        Dim server_sales As String
                        If potong_kode = "112" Then
                            server_sales = "MyConnCloudDnetWTSALES88"
                        Else
                            server_sales = "MyConnCloudDnetWTSALES180"
                        End If
                        Call GetData_DetaiIzinStaff("select sales_email from data_salesman where SALES_Kode = '" + potong_kode + "'", server_sales, 8)
                        'emailSalesAktif
                        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzinSales.Text + " telah di batalkan Manajer anda dengan Alasan : " + alasan + " <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", emailSalesAktif)
                        Response.Write("<script>alert('Anda Berhasil Membatalkan Pengajuan Izin Sales !')</script>")
                        Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                    Else
                        Response.Write("<script>alert('Gagal Melakukan Pembatalan!')</script>")
                        Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
                    End If
                End If
            End If
        Else
            Response.Write("<script>alert('Alasan Pembatalan Tidak Boleh Kosong!')</script>")
            Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
        End If


    End Sub
    'Button Kembali
    Protected Sub BtnBackDetaildanApproval_Click(sender As Object, e As EventArgs) Handles BtnBackDetaildanApproval.Click
        Response.Write("<script>window.location.href='home.aspx?Name=" + LabelUsernameLogin.Text + "';</script>")
    End Sub
    Protected Sub BtnDownloadDetailFile_Click(sender As Object, e As EventArgs) Handles BtnDownloadDetailFile.Click
        'GET IMAGE FILE NAME BY ID IZIN DI TABLE BODY SALES
        Call GetData_DetaiIzinSales("select IZIN_FILEDETAIL  from data_izin_body_sales where izin_id = '" + TxtDetailIdIzinSales.Text + "'", "MyConnCloudDnet171", 4)

        Dim FileName As String = imagedown 'It 's a file name displayed on downloaded file on client side.
        Dim unionname As String = "D:\Herlambang\Data_IzinSales_14_1_2019\img\FileUpload\" + FileName
        'Dim unionname As String = "D:/Herlambang/November-Ongoing - Revisi Input Data Izin (Table)/LiveMUGENASP/TestFromUpload/MugenASPHRISO_10_22_018/img/imgstaff/" + FileName
        Response.Write("<script>alert('\Url : " + unionname + "')</script>")
        Context.Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/jpg"
        'Response.ContentType = "image/jpg" 'Response.ContentType = "application/octet-stream"
        Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName)
        'Response.TransmitFile(Server.MapPath(unionname))


        Response.WriteFile(unionname)
        Response.Flush()
        Response.[End]()
        'Response.WriteFile(unionname) work
        'Response.TransmitFile(unionname) work
        '=================
        'Response.ContentType = ContentType
        'Response.AppendHeader("Content-Disposition", "attachment; filename=" & Path.GetFileName(FileName))
        'Response.WriteFile(unionname)
        'Response.[End]()

    End Sub
End Class
