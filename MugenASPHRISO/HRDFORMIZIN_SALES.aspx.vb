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
Imports System.Collections.Generic
Imports System.Web.UI.WebControls


Partial Class HRDFORMIZIN_SALES
    Inherits System.Web.UI.Page
    'global variabel
    Public lokasi As String
    Public MyRecReadA As OleDbDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'MultiViewMainSales.Visible = False
        btnoperasiSaldo.Visible = False
        PembatalanIzindanLaporanIzin.Visible = False
        BtnMaster.Visible = True
    End Sub
    Protected Sub BtnHome_Click(sender As Object, e As EventArgs) Handles BtnHome.Click
        btnoperasiSaldo.Visible = False
        PembatalanIzindanLaporanIzin.Visible = False
        BtnMaster.Visible = True
        MultiViewMainSales.ActiveViewIndex = -1
    End Sub
    Protected Sub BtnOperasiSaldoMaster_Click(sender As Object, e As EventArgs) Handles BtnOperasiSaldoMaster.Click
        btnoperasiSaldo.Visible = True
        BtnMaster.Visible = False
        MultiViewMainSales.ActiveViewIndex = -1
    End Sub
    Protected Sub BtnPembatalanLaporanIzinMaster_Click(sender As Object, e As EventArgs) Handles BtnPembatalanLaporanIzinMaster.Click
        PembatalanIzindanLaporanIzin.Visible = True
        BtnMaster.Visible = False
        MultiViewMainSales.ActiveViewIndex = -1
    End Sub
    Protected Sub Btn112_Click(sender As Object, e As EventArgs) Handles Btn112.Click
        MultiViewMainSales.ActiveViewIndex = 0
        BtnMaster.Visible = False
        btnoperasiSaldo.Visible = True
        ID_S.Clear()
    End Sub
    Protected Sub Btn128_Click(sender As Object, e As EventArgs) Handles Btn128.Click
        MultiViewMainSales.ActiveViewIndex = 1
        BtnMaster.Visible = False
        btnoperasiSaldo.Visible = True
        ID_S.Clear()
    End Sub
    'FUNGSI KONEKSI UNTUK MENU SALES=================================================
    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function
    ''fungsi delete di gridview1
    'Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

    '    Dim EmployeeID = GridViewCancel.DataKeys(e.RowIndex).Value.ToString()
    '    Response.Write("<script>alert('Value terpilih untuk delete : " + EmployeeID + "')</script>")
    '    'Dim Query = “delete Employee where Employee.EmployeeID = “ + EmployeeID
    '    'DataBind(Query)
    'End Sub

    'fungsi get email sales
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
    'fungsi email 
    Function emailNotifikasi(isiPesan As String, staffEmailnotif As String) As Byte
        Dim pesan As New MailMessage
        pesan.Subject = "Notifikasi Email Pengajuan Izin Sales"
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
    'fungsi get detail tgl pengajuan izin sales
    Function GetData_DedtailIzinSales(ByVal mSqlCommadstring As String, conns As String, ByVal mPos As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(conns).ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_DedtailIzinSales = 0

        cnn = New OleDbConnection(strconn)
        If mPos = 1 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DedtailIzinSales = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    TxtDetailStaffCancelNIK.Text = nSr(MyRecReadA("izin_nik"))
                    TxtDetailStaffCancelJenisIzin.Text = nSr(MyRecReadA("izin_jenis"))
                    TxtDetailStaffCancelTglPengajuan.Text = nSr(MyRecReadA("IZIN_TGlPENGAJUAN"))
                    txtDetailStaffCancelIzinStatus.Text = nSr(MyRecReadA("IZIN_STATUS"))
                    TxtAlasanpengajuan.Text = nSr(MyRecReadA("izin_alasan"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 2 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DedtailIzinSales = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    TxtDetailStaffCancelNama.Text = nSr(MyRecReadA("izin_nama"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        End If

    End Function
    Function GetData_ListTglIzin(ByVal mSqlCommadstring As String, ByVal mPos As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_ListTglIzin = 0

        cnn = New OleDbConnection(strconn)

        If mPos = 1 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_ListTglIzin = IIf(MyRecReadA.HasRows = True, 1, 0)
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
        ElseIf mPos = 3 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_ListTglIzin = IIf(MyRecReadA.HasRows = True, 1, 0)
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
        End If
    End Function
    'fungsi get detail saldo  sales 
    'fungsi identifikasi saldo real dari staff
    Public saldo_tahunan As Integer
    Public saldo_tahunanberlaku As DateTime
    Public saldo_pending As Integer
    Public saldo_pendingberlaku As DateTime
    Dim detailjenis_izin As String
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
    'fungsi get detail izin sales (untuk menu pembatalan izin di hrd)
    Public izin_thn, izin_pen As Integer

    'fungsi cek sales
    Function GetData_SalesExist(ByVal mSqlCommadstring As String, cstring As String) As Double

        Dim strconn As String = WebConfigurationManager.ConnectionStrings(cstring).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        GetData_SalesExist = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                'MyRecReadA.Read()
                'idizin_pertama = nSr(MyRecReadA("IZIN_ID"))
                GetData_SalesExist = 1
            Else
                GetData_SalesExist = 0
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function
    'fungsi cek status sales
    Public status_sales As String
    Function GetData_SalesExist2(ByVal mSqlCommadstring As String, cstring As String) As Double

        Dim strconn As String = WebConfigurationManager.ConnectionStrings(cstring).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        GetData_SalesExist2 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    status_sales = MyRecReadA("sales_aktif")
                End While
            Else
                GetData_SalesExist2 = 0
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function
    'fungsi crud 
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
        End Try
    End Function
    'fungsi get saldo izin sales
    Function GetData_SaldoCutiSales(ByVal mSqlCommadstring As String, ByVal Conns As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(Conns).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        GetData_SaldoCutiSales = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                saldo_cutiSales = MyRecReadA("IZIN_SALDO")
                saldo_tahun = MyRecReadA("IZIN_TAHUN")
            End If
            MyRecReadA.Close()
            GetData_SaldoCutiSales = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function
    'fungsi get nama sales
    Function GetData_ListNamaSales(ByVal mSqlCommadstring As String, ByVal scon As String, ByVal mPos As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(scon).ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_ListNamaSales = 0

        cnn = New OleDbConnection(strconn)

        If mPos = 1 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                'GetData_ListTNamaSales = IIf(MyRecReadA.HasRows = True, 1, 0)
                GetData_ListNamaSales = 1
                While MyRecReadA.Read()
                    'this code ==
                    ListNamaSales.Add(MyRecReadA("sales_nama"))
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
                'GetData_ListTNamaSales = IIf(MyRecReadA.HasRows = True, 1, 0)
                GetData_ListNamaSales = 1
                While MyRecReadA.Read()
                    'this code ==
                    ListNamaAtasanSales.Add(MyRecReadA("sales_group"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 3 Then 'GET TAHUN BERLAKU SALDO SALES
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                'GetData_ListTNamaSales = IIf(MyRecReadA.HasRows = True, 1, 0)
                GetData_ListNamaSales = 1
                While MyRecReadA.Read()
                    'this code ==
                    tahun_berlaku = Convert.ToInt32(MyRecReadA("izin_tahun"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        End If
    End Function
    'FUNGSI MENU SALES ==============================================================

    Private ReadOnly Property ID_S() As List(Of String)
        Get
            If Me.ViewState("ID_S") Is Nothing Then
                Me.ViewState("ID_S") = New List(Of String)()
            End If
            Return CType(Me.ViewState("ID_S"), List(Of String))
        End Get
    End Property
    Public ListNamaSales As List(Of String) = New List(Of String)() 'list array nama sales
    Public ListNamaAtasanSales As List(Of String) = New List(Of String)() 'list array nama atasan sales
    Public grid_menusls As List(Of String) = New List(Of String)() 'array 
    Protected Sub BtnGet112_Click(sender As Object, e As EventArgs) Handles BtnGet112.Click
        'clean gridview 
        GridViewListData.DataSource = Nothing
        GridViewListData.DataBind()
        'DEKLARASI VARIABEL LOKAL
        lokasi = "112"
        LblCabang.Text = lokasi
        For Each item As ListViewDataItem In ListView112.Items
            Dim chkSelect As CheckBox = CType(item.FindControl("CheckBox112"), CheckBox)
            If chkSelect IsNot Nothing Then
                Dim ID As String = Convert.ToString(chkSelect.Attributes("value"))
                If chkSelect.Checked AndAlso Not Me.ID_S.Contains(ID) Then
                    Me.ID_S.Add(ID)
                ElseIf Not chkSelect.Checked AndAlso Me.ID_S.Contains(ID) Then
                    Me.ID_S.Remove(ID)
                End If
            End If

        Next item
        If (ID_S IsNot Nothing AndAlso ID_S.Count > 0) Then
            'get nama sales by id 
            For Each item As String In ID_S
                If GetData_ListNamaSales("select sales_nama from data_salesman where SALES_Kode = '" + item + "'", "MyConnCloudDnet5", 1) = 1 Then 'wtsalestransaction

                Else
                    Response.Write("<script>alert('Gagal Mendapat Value Nama Sales!')</script>")
                    Exit For
                End If
            Next
            'Cek apakah hanya 1 sales yg dipilih
            If ID_S.Count = 1 Then
                TxtLaporanSaldoSales.Visible = True
                Dim NIK As String = "112" + ID_S(0)
                Using con As SqlConnection = New SqlConnection("Data Source=192.168.0.171;User ID=sa;Password=mugen112128;Initial Catalog=HRDWEB")
                    con.Open()
                    Dim cmd As SqlCommand = New SqlCommand("select * from DATA_IZIN_SALDO_SALES where NIK ='" + NIK + "' ", con)
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
                    GridViewLaporanIzinSales.DataSource = dr
                    GridViewLaporanIzinSales.DataBind()
                    con.Close()
                End Using
            Else
                TxtLaporanSaldoSales.Visible = False
            End If
            GridViewListData.DataSource = ListNamaSales
            GridViewListData.DataBind()
            MultiViewMainSales.ActiveViewIndex = 2

        Else
            Response.Write("<script>alert('Gagal Mendapat Value atau tidak ada Value yg di Pilih!')</script>")
            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        End If
        'ID_S.Clear()

    End Sub
    Protected Sub BtnGet128_Click(sender As Object, e As EventArgs) Handles BtnGet128.Click
        'DEKLARASI VARIABEL LOKAL
        lokasi = "128"
        LblCabang.Text = lokasi
        For Each item As ListViewDataItem In ListView128.Items
            Dim chkSelect As CheckBox = CType(item.FindControl("CheckBox128"), CheckBox)
            If chkSelect IsNot Nothing Then
                Dim ID As String = Convert.ToString(chkSelect.Attributes("value"))
                If chkSelect.Checked AndAlso Not Me.ID_S.Contains(ID) Then
                    Me.ID_S.Add(ID)
                ElseIf Not chkSelect.Checked AndAlso Me.ID_S.Contains(ID) Then
                    Me.ID_S.Remove(ID)
                End If
            End If

        Next item
        If (ID_S IsNot Nothing AndAlso ID_S.Count > 0) Then
            'get nama sales by id 
            For Each item As String In ID_S
                If GetData_ListNamaSales("select sales_nama from data_salesman where SALES_Kode = '" + item + "'", "MyConnCloudDnet6", 1) = 1 Then 'wtsalestransaction

                Else
                    Response.Write("<script>alert('Gagal Mendapat Value Nama Sales!')</script>")
                    Exit For
                End If
            Next
            'Cek apakah hanya 1 sales yg dipilih
            If ID_S.Count = 1 Then
                TxtLaporanSaldoSales.Visible = True
                Dim NIK As String = "128" + ID_S(0)
                Using con As SqlConnection = New SqlConnection("Data Source=192.168.0.171;User ID=sa;Password=mugen112128;Initial Catalog=HRDWEB")
                    con.Open()
                    Dim cmd As SqlCommand = New SqlCommand("select * from DATA_IZIN_SALDO_SALES where NIK ='" + NIK + "' ", con)
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
                    GridViewLaporanIzinSales.DataSource = dr
                    GridViewLaporanIzinSales.DataBind()
                    con.Close()
                End Using
            Else
                TxtLaporanSaldoSales.Visible = False
            End If
            'bind data to gridview
            GridViewListData.DataSource = ListNamaSales
            GridViewListData.DataBind()
            MultiViewMainSales.ActiveViewIndex = 2
        Else
            Response.Write("<script>alert('Gagal Mendapat Value atau tidak ada Value yg di Pilih!')</script>")
            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        End If
        'ID_S.Clear()

    End Sub
    'public variabel btndataoperasi
    Public saldo_cutiSales As Integer
    Public saldo_tahun As Integer
    Public tahun_berlaku As Integer

    Protected Sub TxtGetDataOperasi_Click(sender As Object, e As EventArgs) Handles TxtGetDataOperasi.Click
        Dim nik As String
        Dim status As String
        'clean array list 
        ListNamaSales.Clear()
        ListNamaAtasanSales.Clear()
        'lokal variabel 
        'penambahan field izin_saldo_berlaku
        Dim date_izin_saldo_berlaku As String = "-12-31 00:00:00"
        Dim tahun_saldo_berlaku As String = TxtTahunBerlakuSaldo.Text
        Dim izin_saldo_berlaku As DateTime = tahun_saldo_berlaku + date_izin_saldo_berlaku
        'Dim nama As String

        'di tambahkan cloud dnet 6 untuk 128

        If LblCabang.Text = "112" Then
            Response.Write("<script>alert('112!')</script>")
            'CALL TO GET NAMA SALES DAN ATASAN SALES
            For Each item As String In ID_S
                If GetData_ListNamaSales("select sales_nama from data_salesman where SALES_Kode = '" + item + "'", "MyConnCloudDnet5", 1) = 1 Then 'wtsalestransaction
                    'EMPTY ACTION
                Else
                    Response.Write("<script>alert('Gagal Mendapat Value Nama Sales!')</script>")
                    Exit For
                End If
                'GET DATA ATASAN SALES
                If GetData_ListNamaSales("select sales_group from data_salesman where SALES_Kode='" + item + "'", "MyConnCloudDnet5", 2) = 1 Then
                Else
                    Response.Write("<script>alert('Gagal Mendapat Value ID Atasan Sales!')</script>")
                    Exit For
                End If
            Next
            Dim val1 As String

            'Get dropdown jenis operasi=============================
            If DropDownListOperasiSaldoSales.SelectedValue = 1 Then 'input saldo awal tahun
                val1 = "INPUT SALDO AWAL TAHUN"
                For Each item In ID_S
                    Response.Write("<script>alert('Nama Sales = '', Nama Atasan Sales ='' , !')</script>")
                Next

                'LOOP TO ACCES NAMA DAN NIK SALES
                Dim x As Integer = 0
                'For Each item In ID_S
                '    Response.Write("<script>alert('Nik =" + item + " ----- Nama = " + ListNamaSales(x) + "')</script>")
                '    x = x + 1
                'Next
                'Response.Write("<script>alert('Input saldo awal tahun')</script>")
                'SET VALUE APPRV MANAGER
                Dim mng_id As String = "FAIZ"
                For Each item In ID_S
                    nik = "112" + item
                    'JIKA KONDISI DATA ADA MAKA UPDATE, JIKA TIDAK ADA MAKA INSERT
                    If GetData_SalesExist("select * from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + nik + "'", "MyConnCloudDnet2") = 1 Then
                        'CEK STATUS SALES [112]
                        'If GetData_SalesExist2("select sales_aktif from data_salesman where SALES_Kode = '" + item + "' ", "MyConnCloudDnet5") = 1 Then
                        '    If status_sales = "0" Then
                        '        status = "Aktif"
                        '    Else
                        '        status = "Non Aktif"
                        '    End If
                        'Else
                        '    status = "Tidak Ditemukan"
                        'End If

                        'AKTIF = UPDATE / NON = CANCEL UPDATE
                        'If status = "Aktif" Then
                        'update table izin saldo sales
                        'GET VALUE NOMINAL AWAL
                        If GetData_SaldoCutiSales("select izin_saldo, izin_tahun from data_izin_header_sales where izin_nik = '" + nik + "'", "MyConnCloudDnet2") = 1 Then
                        Else
                            Response.Write("<script>alert('Gagal Mendapatkan Saldo Cuti Sales, Ada Kesalahan Ketika Pencarian Data! Proses Berhenti')</script>")
                            Exit For
                        End If
                        'INSERT IZIN SALDO SALES UNTUK HISTORY===========================================
                        'NOTE : [nominal akhir : nominal yg ada pada server, nominal awal : nominal yg di inputkan hrd]
                        If UpdateData_Server("insert into data_izin_saldo_sales (nik, nominal_awal, nominal_akhir, tahun, ket, tgl) values ('" & nik & "','" & TxtNominalSaldo.Text & "','" & saldo_cutiSales & "','" & TxtTahunBerlakuSaldo.Text & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ") = 1 Then
                            Response.Write("<script>alert('berhasil insert data history saldo sales ')</script>")
                        Else
                            Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                            Exit For
                        End If
                        'update table izin header sales==================================================
                        If UpdateData_Server("update data_izin_header_sales set izin_saldo ='" & TxtNominalSaldo.Text & "',IZIN_SALDO_AWAL ='" & TxtNominalSaldo.Text & "', izin_tahun='" & TxtTahunBerlakuSaldo.Text & "', izin_saldo_cuti_tahunan_berlaku='" & izin_saldo_berlaku & "', izin_saldo_pc = NULL, izin_saldo_hc = NULL  where izin_nik = '" & nik & "'") = 1 Then
                            'empty
                        Else
                            Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                            Exit For
                        End If
                        'Else
                        '    Response.Write("<script>alert('Failed to update This Data " + item + ", Sales Tidak Aktif! Process Stop')</script>")
                        '    Exit For
                        'End If
                        'Response.Write("<script>alert('Data Exist!')</script>")
                    Else 'INSERT DATA=========================================================================
                        'Response.Write("<script>alert('This Data " + item + " Non Exist on System!')</script>")

                        'insert ke data_izin_header_sales
                        'cek apakah atasan sales = sc , jika ya maka izin appv mng = --
                        If ListNamaAtasanSales(x) = "SC" Then
                            If UpdateData_Server("insert into DATA_IZIN_HEADER_sales (izin_nik, izin_nama, izin_saldo, izin_tahun, izin_nik_appvspv, izin_nik_appvmng, izin_saldo_cuti_tahunan_berlaku, IZIN_SALDO_AWAL , izin_saldo_pc, izin_saldo_hc, izin_saldo_pc_berlaku)values ('" + nik + "','" + ListNamaSales(x) + "', '" & TxtNominalSaldo.Text & "', '" & TxtTahunBerlakuSaldo.Text & "', '" + mng_id + "', '--', '" + izin_saldo_berlaku + "','" & TxtNominalSaldo.Text & "', null, null, null) ") = 1 Then
                                x = x + 1
                            Else
                                Response.Write("<script>alert('Failed to Insert This Data " + item + "! Process Stop')</script>")
                                Exit For
                            End If
                        Else
                            If UpdateData_Server("insert into DATA_IZIN_HEADER_sales (izin_nik, izin_nama, izin_saldo, izin_tahun, izin_nik_appvspv, izin_nik_appvmng, izin_saldo_cuti_tahunan_berlaku, IZIN_SALDO_AWAL , izin_saldo_pc, izin_saldo_hc, izin_saldo_pc_berlaku)values ('" + nik + "','" + ListNamaSales(x) + "', '" & TxtNominalSaldo.Text & "', '" & TxtTahunBerlakuSaldo.Text & "', '" + ListNamaAtasanSales(x) + "', '" + mng_id + "', '" + izin_saldo_berlaku + "','" & TxtNominalSaldo.Text & "', null, null, null) ") = 1 Then
                                x = x + 1
                            Else
                                Response.Write("<script>alert('Failed to Insert This Data " + item + "! Process Stop')</script>")
                                Exit For
                            End If
                        End If
                        'INSERT IZIN SALDO SALES UNTUK HISTORY===========================================
                        'NOTE : [nominal akhir : nominal yg ada pada server, nominal awal : nominal yg di inputkan hrd]
                        If UpdateData_Server("insert into data_izin_saldo_sales (nik, nominal_awal, nominal_akhir, tahun, ket, tgl) values ('" & nik & "','" & TxtNominalSaldo.Text & "','0','" & TxtTahunBerlakuSaldo.Text & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ") = 1 Then
                            Response.Write("<script>alert('berhasil insert data history saldo sales ')</script>")
                        Else
                            Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                            Exit For
                        End If
                    End If
                Next
                Response.Write("<script>window.location.href='hrdformizin_sales.aspx';</script>")
            ElseIf DropDownListOperasiSaldoSales.SelectedValue = 2 Then 'cuti hari raya -- mengurangi saldo
                val1 = "INPUT CUTI HARI RAYA"
                Dim saldoCutiHariRaya_Input As String = TxtNominalSaldo.Text
                Dim saldoCutiHariRaya As Integer

                'cek apakah sales datanya ada di data_izin_header_sales, jika tidak maka roll back action
                For Each item In ID_S
                    nik = "112" + item
                    'cek apakah data izin tahun berjalan sesuai dengan tahun input user
                    If GetData_ListNamaSales("select izin_tahun from data_izin_header_sales where izin_nik ='" + nik + "'", "MyConnCloudDnet2", 3) Then
                        If tahun_berlaku = Convert.ToInt32(TxtTahunBerlakuSaldo.Text) Then
                            'Core Process
                            If GetData_SalesExist("select * from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                'get saldo berjalan -- 'GET VALUE NOMINAL AWAL
                                If GetData_SaldoCutiSales("select izin_saldo, izin_tahun from data_izin_header_sales where izin_nik = '" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                Else
                                    Response.Write("<script>alert('Gagal Mendapatkan Saldo Cuti Sales, Ada Kesalahan Ketika Pencarian Data! Proses Berhenti')</script>")
                                    Exit For
                                End If
                                'update saldo berjalan -- saldo_cutiSales
                                saldoCutiHariRaya = Convert.ToInt32(saldo_cutiSales) - Convert.ToInt32(saldoCutiHariRaya_Input)
                                If saldoCutiHariRaya > 0 And Convert.ToInt32(saldo_cutiSales) >= Convert.ToInt32(saldoCutiHariRaya_Input) Then
                                    'update process
                                    'NOTE : [nominal akhir : nominal yg ada pada server, nominal awal : nominal yg di inputkan hrd]
                                    If UpdateData_Server("insert into data_izin_saldo_sales (nik, nominal_awal, nominal_akhir, tahun, ket, tgl) values ('" & nik & "','" & saldoCutiHariRaya_Input & "','" & saldoCutiHariRaya & "','" & TxtTahunBerlakuSaldo.Text & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ") = 1 Then
                                        Response.Write("<script>alert('berhasil insert data history saldo sales ')</script>")
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                    'update data_izin_header sales==================================================
                                    If UpdateData_Server("update data_izin_header_sales set izin_saldo ='" & saldoCutiHariRaya & "'  where izin_nik = '" & nik & "'") = 1 Then
                                        'empty
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                Else
                                    'saldo izin sales kurang dari saldo yang anda inputkan
                                    Response.Write("<script>alert('saldo izin sales kurang dari saldo yang anda inputkan.Proses Batal')</script>")
                                    Exit For
                                End If
                            Else
                                Response.Write("<script>alert('Data Saldo Izin Sales tidak di temukan, Input Saldo Izin Terlebih Dahulu. Proses Stop')</script>")
                                Exit For
                            End If
                        Else
                            Response.Write("<script>alert('Tahun Berjalan Saldo berbeda dengan Tahun yang anda inputkan. Proses Stop')</script>")
                            Exit For
                        End If
                    Else
                        Response.Write("<script>alert('Gagal Mendapatkan tahun Berjalan Saldo Sales. Prose Stop')</script>")
                        Exit For
                    End If
                Next
                Response.Write(" < Script > window.location.href ='hrdformizin_sales.aspx';</script>")
            ElseIf DropDownListOperasiSaldoSales.SelectedValue = 3 Then 'cuti besar -- menambah saldo
                val1 = "INPUT CUTI BESAR"
                Dim saldoCutiHariRaya_Input As String = TxtNominalSaldo.Text
                Dim saldoCutiHariRaya As Integer
                'cek apakah sales datanya ada di data_izin_header_sales, jika tidak maka roll back action
                For Each item In ID_S
                    nik = "112" + item
                    'cek apakah data izin tahun berjalan sesuai dengan tahun input user
                    If GetData_ListNamaSales("select izin_tahun from data_izin_header_sales where izin_nik ='" + nik + "'", "MyConnCloudDnet2", 3) Then
                        If tahun_berlaku = Convert.ToInt32(TxtTahunBerlakuSaldo.Text) Then
                            'core process
                            If GetData_SalesExist("select * from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                'get saldo berjalan -- 'GET VALUE NOMINAL AWAL
                                If GetData_SaldoCutiSales("select izin_saldo, izin_tahun from data_izin_header_sales where izin_nik = '" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                Else
                                    Response.Write("<script>alert('Gagal Mendapatkan Saldo Cuti Sales, Ada Kesalahan Ketika Pencarian Data! Proses Berhenti')</script>")
                                    Exit For
                                End If
                                'update saldo berjalan -- saldo_cutiSales
                                saldoCutiHariRaya = Convert.ToInt32(saldo_cutiSales) + Convert.ToInt32(saldoCutiHariRaya_Input)
                                If saldoCutiHariRaya > 0 Then
                                    'update process
                                    'NOTE : [nominal akhir : nominal yg ada pada server, nominal awal : nominal yg di inputkan hrd]
                                    If UpdateData_Server("insert into data_izin_saldo_sales (nik, nominal_awal, nominal_akhir, tahun, ket, tgl) values ('" & nik & "','" & saldoCutiHariRaya_Input & "','" & saldoCutiHariRaya & "','" & TxtTahunBerlakuSaldo.Text & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ") = 1 Then
                                        Response.Write("<script>alert('berhasil insert data history saldo sales ')</script>")
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                    'update data_izin_header sales==================================================
                                    If UpdateData_Server("update data_izin_header_sales set izin_saldo ='" & saldoCutiHariRaya & "'  where izin_nik = '" & nik & "'") = 1 Then
                                        'empty
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                Else
                                    'saldo izin sales kurang dari saldo yang anda inputkan
                                    Response.Write("<script>alert('saldo izin sales kurang dari 0.Proses Batal')</script>")
                                    Exit For
                                End If
                            Else
                                Response.Write("<script>alert('Data Izin Sales tidak di temukan, Input Saldo Izin Terlebih Dahulu. Proses Stop')</script>")
                                Exit For
                            End If
                        Else
                            Response.Write("<script>alert('Tahun Berjalan Saldo berbeda dengan Tahun yang anda inputkan. Proses Stop')</script>")
                            Exit For
                        End If
                    Else
                        Response.Write("<script>alert('Gagal Mendapatkan tahun Berjalan Saldo Sales. Prose Stop')</script>")
                        Exit For
                    End If
                Next
                Response.Write("<script>window.location.href='hrdformizin_sales.aspx';</script>")
            ElseIf DropDownListOperasiSaldoSales.SelectedValue = 4 Then 'pending cuti -- menambah saldo
                val1 = "INPUT PENDING CUTI"
                Dim saldoCutiHariRaya_Input As String = TxtNominalSaldo.Text
                Dim saldoCutiHariRaya As Integer
                'cek apakah sales datanya ada di data_izin_header_sales, jika tidak maka roll back action
                For Each item In ID_S
                    nik = "112" + item
                    'cek apakah data izin tahun berjalan sesuai dengan tahun input user
                    If GetData_ListNamaSales("select izin_tahun from data_izin_header_sales where izin_nik ='" + nik + "'", "MyConnCloudDnet2", 3) Then
                        If tahun_berlaku = Convert.ToInt32(TxtTahunBerlakuSaldo.Text) Then
                            'core process
                            If GetData_SalesExist("select * from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                'get saldo berjalan -- 'GET VALUE NOMINAL AWAL
                                If GetData_SaldoCutiSales("select izin_saldo, izin_tahun from data_izin_header_sales where izin_nik = '" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                Else
                                    Response.Write("<script>alert('Gagal Mendapatkan Saldo Cuti Sales, Ada Kesalahan Ketika Pencarian Data! Proses Berhenti')</script>")
                                    Exit For
                                End If
                                'update saldo berjalan -- saldo_cutiSales
                                saldoCutiHariRaya = Convert.ToInt32(saldo_cutiSales) + Convert.ToInt32(saldoCutiHariRaya_Input)
                                If saldoCutiHariRaya > 0 Then
                                    'update process
                                    'NOTE : [nominal akhir : nominal yg ada pada server, nominal awal : nominal yg di inputkan hrd]
                                    If UpdateData_Server("insert into data_izin_saldo_sales (nik, nominal_awal, nominal_akhir, tahun, ket, tgl) values ('" & nik & "','" & saldoCutiHariRaya_Input & "','" & saldoCutiHariRaya & "','" & TxtTahunBerlakuSaldo.Text & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ") = 1 Then
                                        Response.Write("<script>alert('berhasil insert data history saldo sales ')</script>")
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                    'update data_izin_header sales==================================================
                                    If UpdateData_Server("update data_izin_header_sales set izin_saldo_pc = '" + saldoCutiHariRaya_Input + "', izin_saldo_pc_berlaku='" + TxtDeadlinePendingCuti.Text + "'  where izin_nik = '" & nik & "'") = 1 Then
                                        'empty
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                Else
                                    'saldo izin sales kurang dari saldo yang anda inputkan
                                    Response.Write("<script>alert('saldo izin sales kurang dari 0.Proses Batal')</script>")
                                    Exit For
                                End If
                            Else
                                Response.Write("<script>alert('Data Izin Sales tidak di temukan, Input Saldo Izin Terlebih Dahulu. Proses Stop')</script>")
                                Exit For
                            End If
                        Else
                            Response.Write("<script>alert('Tahun Berjalan Saldo berbeda dengan Tahun yang anda inputkan. Proses Stop')</script>")
                            Exit For
                        End If
                    Else
                        Response.Write("<script>alert('Gagal Mendapatkan tahun Berjalan Saldo Sales. Prose Stop')</script>")
                        Exit For
                    End If
                Next
                Response.Write("<script>window.location.href='hrdformizin_sales.aspx';</script>")
            ElseIf DropDownListOperasiSaldoSales.SelectedValue = 5 Then 'hutang cuti -- mengurangi saldo
                val1 = "INPUT HUTANG CUTI"
                Dim saldoCutiHariRaya_Input As String = TxtNominalSaldo.Text
                Dim saldoCutiHariRaya As Integer
                'cek apakah sales datanya ada di data_izin_header_sales, jika tidak maka roll back action
                For Each item In ID_S
                    nik = "112" + item
                    'cek apakah data izin tahun berjalan sesuai dengan tahun input user
                    If GetData_ListNamaSales("select izin_tahun from data_izin_header_sales where izin_nik ='" + nik + "'", "MyConnCloudDnet2", 3) Then
                        If tahun_berlaku = Convert.ToInt32(TxtTahunBerlakuSaldo.Text) Then
                            'core process
                            If GetData_SalesExist("select * from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                'get saldo berjalan -- 'GET VALUE NOMINAL AWAL
                                If GetData_SaldoCutiSales("select izin_saldo, izin_tahun from data_izin_header_sales where izin_nik = '" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                Else
                                    Response.Write("<script>alert('Gagal Mendapatkan Saldo Cuti Sales, Ada Kesalahan Ketika Pencarian Data! Proses Berhenti')</script>")
                                    Exit For
                                End If
                                'update saldo berjalan -- saldo_cutiSales
                                saldoCutiHariRaya = Convert.ToInt32(saldo_cutiSales) - Convert.ToInt32(saldoCutiHariRaya_Input)
                                If saldoCutiHariRaya > 0 Then
                                    'update process
                                    'NOTE : [nominal akhir : nominal yg ada pada server, nominal awal : nominal yg di inputkan hrd]
                                    If UpdateData_Server("insert into data_izin_saldo_sales (nik, nominal_awal, nominal_akhir, tahun, ket, tgl) values ('" & nik & "','" & saldoCutiHariRaya_Input & "','" & saldoCutiHariRaya & "','" & TxtTahunBerlakuSaldo.Text & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ") = 1 Then
                                        Response.Write("<script>alert('berhasil insert data history saldo sales ')</script>")
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                    'update data_izin_header sales==================================================
                                    If UpdateData_Server("update data_izin_header_sales set izin_saldo ='" & saldoCutiHariRaya & "', izin_saldo_hc = '" + saldoCutiHariRaya_Input + "'  where izin_nik = '" & nik & "'") = 1 Then
                                        'empty
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                Else
                                    'saldo izin sales kurang dari saldo yang anda inputkan
                                    Response.Write("<script>alert('saldo izin sales kurang dari 0.Proses Batal')</script>")
                                    Exit For
                                End If
                            Else
                                Response.Write("<script>alert('Data Izin Sales tidak di temukan, Input Saldo Izin Terlebih Dahulu. Proses Stop')</script>")
                                Exit For
                            End If
                        Else
                            Response.Write("<script>alert('Tahun Berjalan Saldo berbeda dengan Tahun yang anda inputkan. Proses Stop')</script>")
                            Exit For
                        End If
                    Else
                        Response.Write("<script>alert('Gagal Mendapatkan tahun Berjalan Saldo Sales. Prose Stop')</script>")
                        Exit For
                    End If
                Next
                Response.Write("<script>window.location.href='hrdformizin_sales.aspx';</script>")
            End If
        ElseIf LblCabang.Text = "128" Then
            Response.Write("<script>alert('128!')</script>")
            Dim val1 As String = "INPUT SALDO AWAL TAHUN"
            'CALL TO GET NAMA SALES DAN ATASAN SALES
            For Each item As String In ID_S
                If GetData_ListNamaSales("select sales_nama from data_salesman where SALES_Kode = '" + item + "'", "MyConnCloudDnet6", 1) = 1 Then 'wtsalestransaction
                    'EMPTY ACTION
                Else
                    Response.Write("<script>alert('Gagal Mendapat Value Nama Sales!')</script>")
                    Exit For
                End If
                'GET DATA ATASAN SALES
                If GetData_ListNamaSales("select sales_group from data_salesman where SALES_Kode='" + item + "'", "MyConnCloudDnet6", 2) = 1 Then
                Else
                    Response.Write("<script>alert('Gagal Mendapat Value ID Atasan Sales!')</script>")
                    Exit For
                End If
            Next
            'Get dropdown jenis operasi
            If DropDownListOperasiSaldoSales.SelectedValue = 1 Then 'input saldo awal tahun
                For Each item In ID_S
                    Response.Write("<script>alert('Nama Sales = '', Nama Atasan Sales ='' , !')</script>")
                Next

                'LOOP TO ACCES NAMA DAN NIK SALES
                Dim x As Integer = 0
                'For Each item In ID_S
                '    Response.Write("<script>alert('Nik =" + item + " ----- Nama = " + ListNamaSales(x) + "')</script>")
                '    x = x + 1
                'Next
                'Response.Write("<script>alert('Input saldo awal tahun')</script>")
                'SET VALUE APPRV MANAGER
                Dim mng_id As String = "UGAM"
                For Each item In ID_S
                    nik = "128" + item
                    'JIKA KONDISI DATA ADA MAKA UPDATE, JIKA TIDAK ADA MAKA INSERT
                    If GetData_SalesExist("select * from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + nik + "'", "MyConnCloudDnet2") = 1 Then
                        'CEK STATUS SALES [112]
                        'If GetData_SalesExist2("select sales_aktif from data_salesman where SALES_Kode = '" + item + "' ", "MyConnCloudDnet5") = 1 Then
                        '    If status_sales = "0" Then
                        '        status = "Aktif"
                        '    Else
                        '        status = "Non Aktif"
                        '    End If
                        'Else
                        '    status = "Tidak Ditemukan"
                        'End If

                        'AKTIF = UPDATE / NON = CANCEL UPDATE
                        'If status = "Aktif" Then
                        'update table izin saldo sales
                        'GET VALUE NOMINAL AWAL
                        If GetData_SaldoCutiSales("select izin_saldo, izin_tahun from data_izin_header_sales where izin_nik = '" + nik + "'", "MyConnCloudDnet2") = 1 Then
                        Else
                            Response.Write("<script>alert('Gagal Mendapatkan Saldo Cuti Sales, Ada Kesalahan Ketika Pencarian Data! Proses Berhenti')</script>")
                            Exit For
                        End If
                        'INSERT IZIN SALDO SALES UNTUK HISTORY===========================================
                        'NOTE : [nominal akhir : nominal yg ada pada server, nominal awal : nominal yg di inputkan hrd]
                        If UpdateData_Server("insert into data_izin_saldo_sales (nik, nominal_awal, nominal_akhir, tahun, ket, tgl) values ('" & nik & "','" & TxtNominalSaldo.Text & "','" & saldo_cutiSales & "','" & TxtTahunBerlakuSaldo.Text & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ") = 1 Then
                            Response.Write("<script>alert('berhasil insert data history saldo sales ')</script>")
                        Else
                            Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                            Exit For
                        End If
                        'update table izin header sales==================================================
                        If UpdateData_Server("update data_izin_header_sales set izin_saldo ='" & TxtNominalSaldo.Text & "',IZIN_SALDO_AWAL ='" & TxtNominalSaldo.Text & "', izin_tahun='" & TxtTahunBerlakuSaldo.Text & "', izin_saldo_cuti_tahunan_berlaku='" & izin_saldo_berlaku & "', izin_saldo_pc = NULL, izin_saldo_hc = NULL  where izin_nik = '" & nik & "'") = 1 Then
                            'empty
                        Else
                            Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                            Exit For
                        End If
                        'Else
                        '    Response.Write("<script>alert('Failed to update This Data " + item + ", Sales Tidak Aktif! Process Stop')</script>")
                        '    Exit For
                        'End If
                        'Response.Write("<script>alert('Data Exist!')</script>")
                    Else 'INSERT DATA=========================================================================
                        'Response.Write("<script>alert('This Data " + item + " Non Exist on System!')</script>")

                        'insert ke data_izin_header_sales
                        'cek apakah atasan sales = sc , jika ya maka izin appv mng = --
                        If ListNamaAtasanSales(x) = "SC" Then
                            If UpdateData_Server("insert into DATA_IZIN_HEADER_sales (izin_nik, izin_nama, izin_saldo, izin_tahun, izin_nik_appvspv, izin_nik_appvmng, izin_saldo_cuti_tahunan_berlaku, IZIN_SALDO_AWAL , izin_saldo_pc, izin_saldo_hc, izin_saldo_pc_berlaku)values ('" + nik + "','" + ListNamaSales(x) + "', '" & TxtNominalSaldo.Text & "', '" & TxtTahunBerlakuSaldo.Text & "', '" + mng_id + "', '--', '" + izin_saldo_berlaku + "','" & TxtNominalSaldo.Text & "', null, null, null) ") = 1 Then
                                x = x + 1
                            Else
                                Response.Write("<script>alert('Failed to Insert This Data " + item + "! Process Stop')</script>")
                                Exit For
                            End If
                        Else
                            If UpdateData_Server("insert into DATA_IZIN_HEADER_sales (izin_nik, izin_nama, izin_saldo, izin_tahun, izin_nik_appvspv, izin_nik_appvmng, izin_saldo_cuti_tahunan_berlaku, IZIN_SALDO_AWAL , izin_saldo_pc, izin_saldo_hc, izin_saldo_pc_berlaku)values ('" + nik + "','" + ListNamaSales(x) + "', '" & TxtNominalSaldo.Text & "', '" & TxtTahunBerlakuSaldo.Text & "', '" + ListNamaAtasanSales(x) + "', '" + mng_id + "', '" + izin_saldo_berlaku + "','" & TxtNominalSaldo.Text & "', null, null, null) ") = 1 Then
                                x = x + 1
                            Else
                                Response.Write("<script>alert('Failed to Insert This Data " + item + "! Process Stop')</script>")
                                Exit For
                            End If
                        End If
                        'INSERT IZIN SALDO SALES UNTUK HISTORY===========================================
                        'NOTE : [nominal akhir : nominal yg ada pada server, nominal awal : nominal yg di inputkan hrd]
                        If UpdateData_Server("insert into data_izin_saldo_sales (nik, nominal_awal, nominal_akhir, tahun, ket, tgl) values ('" & nik & "','" & TxtNominalSaldo.Text & "','0','" & TxtTahunBerlakuSaldo.Text & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ") = 1 Then
                            Response.Write("<script>alert('berhasil insert data history saldo sales ')</script>")
                        Else
                            Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                            Exit For
                        End If
                    End If
                Next
                Response.Write("<script>window.location.href='hrdformizin_sales.aspx';</script>")
            ElseIf DropDownListOperasiSaldoSales.SelectedValue = 2 Then 'cuti hari raya -- mengurangi saldo
                val1 = "INPUT CUTI HARI RAYA"
                Dim saldoCutiHariRaya_Input As String = TxtNominalSaldo.Text
                Dim saldoCutiHariRaya As Integer
                'cek apakah sales datanya ada di data_izin_header_sales, jika tidak maka roll back action
                For Each item In ID_S
                    nik = "128" + item
                    'cek apakah data izin tahun berjalan sesuai dengan tahun input user
                    If GetData_ListNamaSales("select izin_tahun from data_izin_header_sales where izin_nik ='" + nik + "'", "MyConnCloudDnet2", 3) Then
                        If tahun_berlaku = Convert.ToInt32(TxtTahunBerlakuSaldo.Text) Then
                            'core process
                            If GetData_SalesExist("select * from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                'get saldo berjalan -- 'GET VALUE NOMINAL AWAL
                                If GetData_SaldoCutiSales("select izin_saldo, izin_tahun from data_izin_header_sales where izin_nik = '" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                Else
                                    Response.Write("<script>alert('Gagal Mendapatkan Saldo Cuti Sales, Ada Kesalahan Ketika Pencarian Data! Proses Berhenti')</script>")
                                    Exit For
                                End If
                                'update saldo berjalan -- saldo_cutiSales
                                saldoCutiHariRaya = Convert.ToInt32(saldo_cutiSales) - Convert.ToInt32(saldoCutiHariRaya_Input)
                                If saldoCutiHariRaya > 0 And Convert.ToInt32(saldo_cutiSales) >= Convert.ToInt32(saldoCutiHariRaya_Input) Then
                                    'update process
                                    'NOTE : [nominal akhir : nominal yg ada pada server, nominal awal : nominal yg di inputkan hrd]
                                    If UpdateData_Server("insert into data_izin_saldo_sales (nik, nominal_awal, nominal_akhir, tahun, ket, tgl) values ('" & nik & "','" & saldoCutiHariRaya_Input & "','" & saldoCutiHariRaya & "','" & TxtTahunBerlakuSaldo.Text & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ") = 1 Then
                                        Response.Write("<script>alert('berhasil insert data history saldo sales ')</script>")
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                    'update data_izin_header sales==================================================
                                    If UpdateData_Server("update data_izin_header_sales set izin_saldo ='" & saldoCutiHariRaya & "'  where izin_nik = '" & nik & "'") = 1 Then
                                        'empty
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                Else
                                    'saldo izin sales kurang dari saldo yang anda inputkan
                                    Response.Write("<script>alert('saldo izin sales kurang dari saldo yang anda inputkan.Proses Batal')</script>")
                                    Exit For
                                End If
                            Else
                                Response.Write("<script>alert('Data Izin Sales tidak di temukan, Input Saldo Izin Terlebih Dahulu. Proses Stop')</script>")
                                Exit For
                            End If
                        Else
                            Response.Write("<script>alert('Tahun Berjalan Saldo berbeda dengan Tahun yang anda inputkan. Proses Stop')</script>")
                            Exit For
                        End If
                    Else
                        Response.Write("<script>alert('Gagal Mendapatkan tahun Berjalan Saldo Sales. Prose Stop')</script>")
                        Exit For
                    End If
                Next
                Response.Write("<script>window.location.href='hrdformizin_sales.aspx';</script>")
            ElseIf DropDownListOperasiSaldoSales.SelectedValue = 3 Then 'cuti besar -- menambah saldo
                val1 = "INPUT CUTI BESAR"
                Dim saldoCutiHariRaya_Input As String = TxtNominalSaldo.Text
                Dim saldoCutiHariRaya As Integer
                'cek apakah sales datanya ada di data_izin_header_sales, jika tidak maka roll back action
                For Each item In ID_S
                    nik = "128" + item
                    'cek apakah data izin tahun berjalan sesuai dengan tahun input user
                    If GetData_ListNamaSales("select izin_tahun from data_izin_header_sales where izin_nik ='" + nik + "'", "MyConnCloudDnet2", 3) Then
                        If tahun_berlaku = Convert.ToInt32(TxtTahunBerlakuSaldo.Text) Then
                            'core process
                            If GetData_SalesExist("select * from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                'get saldo berjalan -- 'GET VALUE NOMINAL AWAL
                                If GetData_SaldoCutiSales("select izin_saldo, izin_tahun from data_izin_header_sales where izin_nik = '" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                Else
                                    Response.Write("<script>alert('Gagal Mendapatkan Saldo Cuti Sales, Ada Kesalahan Ketika Pencarian Data! Proses Berhenti')</script>")
                                    Exit For
                                End If
                                'update saldo berjalan -- saldo_cutiSales
                                saldoCutiHariRaya = Convert.ToInt32(saldo_cutiSales) + Convert.ToInt32(saldoCutiHariRaya_Input)
                                If saldoCutiHariRaya > 0 Then
                                    'update process
                                    'NOTE : [nominal akhir : nominal yg ada pada server, nominal awal : nominal yg di inputkan hrd]
                                    If UpdateData_Server("insert into data_izin_saldo_sales (nik, nominal_awal, nominal_akhir, tahun, ket, tgl) values ('" & nik & "','" & saldoCutiHariRaya_Input & "','" & saldoCutiHariRaya & "','" & TxtTahunBerlakuSaldo.Text & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ") = 1 Then
                                        Response.Write("<script>alert('berhasil insert data history saldo sales ')</script>")
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                    'update data_izin_header sales==================================================
                                    If UpdateData_Server("update data_izin_header_sales set izin_saldo ='" & saldoCutiHariRaya & "'  where izin_nik = '" & nik & "'") = 1 Then
                                        'empty
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                Else
                                    'saldo izin sales kurang dari saldo yang anda inputkan
                                    Response.Write("<script>alert('saldo izin sales kurang dari 0.Proses Batal')</script>")
                                    Exit For
                                End If
                            Else
                                Response.Write("<script>alert('Data Izin Sales tidak di temukan, Input Saldo Izin Terlebih Dahulu. Proses Stop')</script>")
                                Exit For
                            End If
                        Else
                            Response.Write("<script>alert('Tahun Berjalan Saldo berbeda dengan Tahun yang anda inputkan. Proses Stop')</script>")
                            Exit For
                        End If
                    Else
                        Response.Write("<script>alert('Gagal Mendapatkan tahun Berjalan Saldo Sales. Prose Stop')</script>")
                        Exit For
                    End If
                Next
                Response.Write("<script>window.location.href='hrdformizin_sales.aspx';</script>")
            ElseIf DropDownListOperasiSaldoSales.SelectedValue = 4 Then 'pending cuti -- menambah saldo
                val1 = "INPUT PENDING CUTI"
                Dim saldoCutiHariRaya_Input As String = TxtNominalSaldo.Text
                Dim saldoCutiHariRaya As Integer
                'cek apakah sales datanya ada di data_izin_header_sales, jika tidak maka roll back action
                For Each item In ID_S
                    nik = "128" + item
                    'cek apakah data izin tahun berjalan sesuai dengan tahun input user
                    If GetData_ListNamaSales("select izin_tahun from data_izin_header_sales where izin_nik ='" + nik + "'", "MyConnCloudDnet2", 3) Then
                        If tahun_berlaku = Convert.ToInt32(TxtTahunBerlakuSaldo.Text) Then
                            'core process
                            If GetData_SalesExist("select * from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                'get saldo berjalan -- 'GET VALUE NOMINAL AWAL
                                If GetData_SaldoCutiSales("select izin_saldo, izin_tahun from data_izin_header_sales where izin_nik = '" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                Else
                                    Response.Write("<script>alert('Gagal Mendapatkan Saldo Cuti Sales, Ada Kesalahan Ketika Pencarian Data! Proses Berhenti')</script>")
                                    Exit For
                                End If
                                'update saldo berjalan -- saldo_cutiSales
                                saldoCutiHariRaya = Convert.ToInt32(saldo_cutiSales) + Convert.ToInt32(saldoCutiHariRaya_Input)
                                If saldoCutiHariRaya > 0 Then
                                    'update process
                                    'NOTE : [nominal akhir : nominal yg ada pada server, nominal awal : nominal yg di inputkan hrd]
                                    If UpdateData_Server("insert into data_izin_saldo_sales (nik, nominal_awal, nominal_akhir, tahun, ket, tgl) values ('" & nik & "','" & saldoCutiHariRaya_Input & "','" & saldoCutiHariRaya & "','" & TxtTahunBerlakuSaldo.Text & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ") = 1 Then
                                        Response.Write("<script>alert('berhasil insert data history saldo sales ')</script>")
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                    'update data_izin_header sales==================================================
                                    If UpdateData_Server("update data_izin_header_sales set izin_saldo_pc = '" + saldoCutiHariRaya_Input + "', izin_saldo_pc_berlaku='" + TxtDeadlinePendingCuti.Text + "'  where izin_nik = '" & nik & "'") = 1 Then
                                        'empty
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                Else
                                    'saldo izin sales kurang dari saldo yang anda inputkan
                                    Response.Write("<script>alert('saldo izin sales kurang dari 0.Proses Batal')</script>")
                                    Exit For
                                End If
                            Else
                                Response.Write("<script>alert('Data Izin Sales tidak di temukan, Input Saldo Izin Terlebih Dahulu. Proses Stop')</script>")
                                Exit For
                            End If
                        Else
                            Response.Write("<script>alert('Tahun Berjalan Saldo berbeda dengan Tahun yang anda inputkan. Proses Stop')</script>")
                            Exit For
                        End If
                    Else
                        Response.Write("<script>alert('Gagal Mendapatkan tahun Berjalan Saldo Sales. Prose Stop')</script>")
                        Exit For
                    End If
                Next
                Response.Write("<script>window.location.href='hrdformizin_sales.aspx';</script>")
            ElseIf DropDownListOperasiSaldoSales.SelectedValue = 5 Then 'hutang cuti -- mengurangi saldo
                val1 = "INPUT HUTANG CUTI"
                Dim saldoCutiHariRaya_Input As String = TxtNominalSaldo.Text
                Dim saldoCutiHariRaya As Integer
                'cek apakah sales datanya ada di data_izin_header_sales, jika tidak maka roll back action
                For Each item In ID_S
                    nik = "128" + item
                    'cek apakah data izin tahun berjalan sesuai dengan tahun input user
                    If GetData_ListNamaSales("select izin_tahun from data_izin_header_sales where izin_nik ='" + nik + "'", "MyConnCloudDnet2", 3) Then
                        If tahun_berlaku = Convert.ToInt32(TxtTahunBerlakuSaldo.Text) Then
                            'core process
                            If GetData_SalesExist("select * from DATA_IZIN_HEADER_sales where IZIN_NIK ='" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                'get saldo berjalan -- 'GET VALUE NOMINAL AWAL
                                If GetData_SaldoCutiSales("select izin_saldo, izin_tahun from data_izin_header_sales where izin_nik = '" + nik + "'", "MyConnCloudDnet2") = 1 Then
                                Else
                                    Response.Write("<script>alert('Gagal Mendapatkan Saldo Cuti Sales, Ada Kesalahan Ketika Pencarian Data! Proses Berhenti')</script>")
                                    Exit For
                                End If
                                'update saldo berjalan -- saldo_cutiSales
                                saldoCutiHariRaya = Convert.ToInt32(saldo_cutiSales) - Convert.ToInt32(saldoCutiHariRaya_Input)
                                If saldoCutiHariRaya > 0 Then
                                    'update process
                                    'NOTE : [nominal akhir : nominal yg ada pada server, nominal awal : nominal yg di inputkan hrd]
                                    If UpdateData_Server("insert into data_izin_saldo_sales (nik, nominal_awal, nominal_akhir, tahun, ket, tgl) values ('" & nik & "','" & saldoCutiHariRaya_Input & "','" & saldoCutiHariRaya & "','" & TxtTahunBerlakuSaldo.Text & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ") = 1 Then
                                        Response.Write("<script>alert('berhasil insert data history saldo sales ')</script>")
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                    'update data_izin_header sales==================================================
                                    If UpdateData_Server("update data_izin_header_sales set izin_saldo ='" & saldoCutiHariRaya & "', izin_saldo_hc = '" + saldoCutiHariRaya_Input + "'  where izin_nik = '" & nik & "'") = 1 Then
                                        'empty
                                    Else
                                        Response.Write("<script>alert('Failed to update This Data " + item + ", Ada Kesalahan Ketika Update Data! Proses Berhenti')</script>")
                                        Exit For
                                    End If
                                Else
                                    'saldo izin sales kurang dari saldo yang anda inputkan
                                    Response.Write("<script>alert('saldo izin sales kurang dari 0.Proses Batal')</script>")
                                    Exit For
                                End If
                            Else
                                Response.Write("<script>alert('Data Izin Sales tidak di temukan, Input Saldo Izin Terlebih Dahulu. Proses Stop')</script>")
                                Exit For
                            End If
                        Else
                            Response.Write("<script>alert('Tahun Berjalan Saldo berbeda dengan Tahun yang anda inputkan. Proses Stop')</script>")
                            Exit For
                        End If
                    Else
                        Response.Write("<script>alert('Gagal Mendapatkan tahun Berjalan Saldo Sales. Prose Stop')</script>")
                        Exit For
                    End If
                Next
                Response.Write("<script>window.location.href='hrdformizin_sales.aspx';</script>")
            End If
        Else
            Response.Write("<script>alert('Gagal Mendapatkan Value Cabang!')</script>")
        End If
    End Sub



    '***BUTTON PEMBATALAN IZIN SALES
    Protected Sub BtnPembatalanIzin_Click(sender As Object, e As EventArgs) Handles BtnPembatalanIzin.Click
        MultiViewMainSales.ActiveViewIndex = 3

    End Sub
    '***BUTTON LAPORAN IZIN SALES
    Protected Sub BtnLaporanIzin_Click(sender As Object, e As EventArgs) Handles BtnLaporanIzin.Click
        MultiViewMainSales.ActiveViewIndex = 4
    End Sub
    '***LISTVIEW DETAIL IZIN TERPILIH SALES
    Public ListTgl As New List(Of String)()
    Public ListTgl_Pend As New List(Of String)()
    Public ListTglKesel As New List(Of String)()
    Protected Sub ListViewHRDPembatalanIzin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewHRDPembatalanIzin.SelectedIndexChanged
        'get value terpilih  dari listview
        Dim sales_IzinIDHRDFormIzinPembatalan As String = (ListViewHRDPembatalanIzin.DataKeys(ListViewHRDPembatalanIzin.SelectedIndex).Value.ToString)
        'menampilkan detail izin terpilih sales 
        MultiViewMainSales.ActiveViewIndex = 5
        'pass the value to detail cancel staff form izin by HRD
        '***get detail pengajuan izin -- IZIN_NIK, IZIN_JENIS, IZIN_TGlPENGAJUAN, IZIN_STATUS -- DATA_IZIN_BODY_sales
        GetData_DedtailIzinSales("select IZIN_NIK, IZIN_JENIS, izin_alasan, IZIN_TGlPENGAJUAN, IZIN_STATUS from DATA_IZIN_BODY_sales WHERE IZIN_ID ='" + sales_IzinIDHRDFormIzinPembatalan + "' ", "MyConnCloudDnet2", "1")
        '***get nama dari pengaju izin tsb [IZIN_NAMA]
        GetData_DedtailIzinSales("select izin_nama from DATA_IZIN_HEADER_sales where izin_nik = '" + TxtDetailStaffCancelNIK.Text + "'", "MyConnCloudDnet2", "2")
        'logic hide object 
        TxtDetailStaffCancelIdIzin.Text = sales_IzinIDHRDFormIzinPembatalan
        TxtAlasanpengajuan.Enabled = False
        TxtDetailStaffCancelIdIzin.Enabled = False
        TxtDetailStaffCancelNIK.Enabled = False
        TxtDetailStaffCancelNama.Enabled = False
        TxtDetailStaffCancelJenisIzin.Enabled = False
        TxtDetailStaffCancelTglPengajuan.Enabled = False
        txtDetailStaffCancelIzinStatus.Enabled = False
        'get detail saldo staff terpilih 
        'call real saldo staff
        Call Real_saldoStaff("select IZIN_SALDO, IZIN_SALDO_CUTI_TAHUNAN_BERLAKU, IZIN_SALDO_PC, IZIN_SALDO_PC_BERLAKU from DATA_IZIN_HEADER_sales where IZIN_NIK ='" & TxtDetailStaffCancelNIK.Text & "'")
        'tampilkan jml pengajuan tanggal array 
        ListTgl.Clear()
        ListTgl_Pend.Clear()
        Call GetData_ListTglIzin("select izin_tgldetail from data_izin_detail_sales where izin_id = '" & sales_IzinIDHRDFormIzinPembatalan & "'", "1") 'list tgl
        Call GetData_ListTglIzin("select izin_tgldetail from DATA_IZIN_DETAILPC_sales where izin_id = '" & sales_IzinIDHRDFormIzinPembatalan & "'", "3") 'list tgl pending
        GridViewCancel.DataSource = ListTgl
        GridViewCancel.DataBind()
        GridViewCancelPend.DataSource = ListTgl_Pend
        GridViewCancelPend.DataBind()
        'gabungkan semua tanggal yang di pilih



        'logic hide object 
        If TxtAlasanpengajuan.Text = "Cuti" Then
            Label7.Visible = False
            If ListTgl.Count > 0 And ListTgl_Pend.Count > 0 Then
                BtnDetailStaffHRDCancelTahunan.Visible = True
                BtnDetailStaffHRDCancelPending.Visible = True
                Label59.Visible = True
                Label60.Visible = True
            ElseIf ListTgl.Count > 0 And ListTgl_Pend.Count = 0 Then
                BtnDetailStaffHRDCancelTahunan.Visible = True
                BtnDetailStaffHRDCancelPending.Visible = False
                Label59.Visible = False
                Label60.Visible = True
            ElseIf ListTgl.Count = 0 And ListTgl_Pend.Count > 0 Then
                BtnDetailStaffHRDCancelTahunan.Visible = False
                BtnDetailStaffHRDCancelPending.Visible = True
                Label59.Visible = True
                Label60.Visible = False
            ElseIf ListTgl.Count = 0 And ListTgl_Pend.Count = 0 Then
                BtnDetailStaffHRDCancelTahunan.Visible = False
                BtnDetailStaffHRDCancelPending.Visible = False
                Label59.Visible = False
                Label60.Visible = False
                BtnDetailStaffHRDCancel.Visible = False
                Label61.Visible = True
            End If
        Else
            BtnDetailStaffHRDCancelTahunan.Visible = False
            BtnDetailStaffHRDCancelPending.Visible = False
            Label59.Visible = False
            Label60.Visible = False
            Label7.Visible = True
        End If
    End Sub
    'note : meskipun sudah melewati tgl deadline, izin tetap bisa di kembalikan***************8
    '***cancel seluruhnya jika ada
    Protected Sub BtnDetailStaffHRDCancel_Click(sender As Object, e As EventArgs) Handles BtnDetailStaffHRDCancel.Click
        'Response.Write("<script>alert('Jenis izin : " + TxtDetailStaffCancelJenisIzin.Text + " --- ALASAN : " + TxtAlasanpengajuan.Text + "')</script>")
        'call real saldo staff
        Call Real_saldoStaff("select IZIN_SALDO, IZIN_SALDO_CUTI_TAHUNAN_BERLAKU, IZIN_SALDO_PC, IZIN_SALDO_PC_BERLAKU from DATA_IZIN_HEADER_sales where IZIN_NIK ='" & TxtDetailStaffCancelNIK.Text & "'")
        'get tgl pengajuan sales tersebut 
        ListTgl.Clear()
        ListTgl_Pend.Clear()
        Call GetData_ListTglIzin("select izin_tgldetail from data_izin_detail_sales where izin_id = '" & TxtDetailStaffCancelIdIzin.Text & "'", "1") 'list tgl
        Call GetData_ListTglIzin("select izin_tgldetail from DATA_IZIN_DETAILPC_sales where izin_id = '" & TxtDetailStaffCancelIdIzin.Text & "'", "3") 'list tgl pending
        'inisialisasi status
        Dim st As Integer = 0
        Dim sp As Integer = 0
        'get alasan pengajuan 
        If TxtAlasanpengajuan.Text = "Cuti" Or TxtAlasanpengajuan.Text = "Izin Potong Cuti" Or TxtAlasanpengajuan.Text = "Sakit Potong Cuti" Then 'mengembalikan saldo tahunan dan pending 
            'kembalikan saldo tahunan
            If ListTgl.Count > 0 Then
                'kalkulasi saldo tahunan 
                Dim saldo_thn As Integer = saldo_tahunan + ListTgl.Count
                'proses update dan //delete tgl tahunan 
                If UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_STATUS = 'Dibatalkan HRD' where IZIN_ID ='" + TxtDetailStaffCancelIdIzin.Text + "'") = 1 And UpdateData_Server("update DATA_IZIN_HEADER_sales set IZIN_SALDO = '" & saldo_thn & "' where IZIN_NIK ='" & TxtDetailStaffCancelNIK.Text & "' ") = 1 Then
                    'delete detail tanggal di DATA_IZIN_DETAIL_SALES
                    Call UpdateData_Server("delete from DATA_IZIN_DETAIL_SALES where izin_id ='" + TxtDetailStaffCancelIdIzin.Text + "'")
                    'alert berhasil update saldo tahunan sales
                    Response.Write("<script>alert('Berhasil Membatalkan Izin dengan ID : " + TxtDetailStaffCancelIdIzin.Text + "!')</script>")
                    st = 1
                End If
            End If
            '***cek dahulu apakah pending cuti masih berlaku -- jika ya : kembalikan saldo pending
            If DateTime.Now <= saldo_pendingberlaku Then
                If ListTgl_Pend.Count > 0 Then
                    'kalkulasi saldo pending
                    Dim saldo_pend As Integer = saldo_pending + ListTgl_Pend.Count
                    'proses update dan //delete tgl pending
                    If UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_STATUS = 'Dibatalkan HRD' where IZIN_ID ='" + TxtDetailStaffCancelIdIzin.Text + "'") = 1 And UpdateData_Server("update DATA_IZIN_HEADER_sales set  IZIN_SALDO_PC= '" & saldo_pend & "' where IZIN_NIK ='" & TxtDetailStaffCancelNIK.Text & "'") = 1 Then
                        'delete detail tanggal di DATA_IZIN_DETAILPC_SALES
                        Call UpdateData_Server("delete from DATA_IZIN_DETAILPC_SALES where izin_id ='" + TxtDetailStaffCancelIdIzin.Text + "'")
                        'alert berhasil update saldo pending sales
                        Response.Write("<script>alert('Berhasil Membatalkan Izin dengan ID : " + TxtDetailStaffCancelIdIzin.Text + "!')</script>")
                        sp = 1
                    End If
                End If
            End If
            '***fungsi email ke staff ybs
            If st = 1 Or sp = 1 Then
                '**EMAIL STAFF YG BERSANGKUTAN
                'get email staff by nama di 88 /180 // wtsalestransaction - data_salesman - sales_email
                Dim kodecab As Integer = TxtDetailStaffCancelNIK.Text.Substring(0, 3) 'get kode cabang dari nik 
                Dim conns As String
                If kodecab = 112 Then
                    conns = "MyConnCloudDnetWTSALES88"
                Else
                    conns = "MyConnCloudDnetWTSALES180"
                End If
                'email_sales
                'Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailStaffCancelNama.Text & "'", conns, 3)
                'Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailStaffCancelNama.Text + " dengan NIK " + TxtDetailStaffCancelNIK.Text + " dan tanggal Pengajuan " + TxtDetailStaffCancelTglPengajuan.Text + " dengan Id Izin " + TxtDetailStaffCancelIdIzin.Text + " telah di batalkan Oleh HRD <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
            End If
            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        Else 'tidak mengembalikan saldo izin tahunan dan pending jika ada
            If UpdateData_Server("update DATA_IZIN_BODY_SALES set IZIN_STATUS = 'Dibatalkan HRD' where IZIN_ID = '" & TxtDetailStaffCancelIdIzin.Text & "'") = 1 Then
                Response.Write("<script>alert('berhasil Membatalkan Izin dengan ID : " + TxtDetailStaffCancelIdIzin.Text + "!')</script>")
                'delete detail tanggal di DATA_IZIN_DETAIL_SALES
                Call UpdateData_Server("delete from DATA_IZIN_DETAIL_SALES where izin_id ='" + TxtDetailStaffCancelIdIzin.Text + "'")
                '**EMAIL STAFF YG BERSANGKUTAN
                'get email staff by nama di 88 /180 // wtsalestransaction - data_salesman - sales_email
                Dim kodecab As Integer = TxtDetailStaffCancelNIK.Text.Substring(0, 3) 'get kode cabang dari nik 
                Dim conns As String
                If kodecab = 112 Then
                    conns = "MyConnCloudDnetWTSALES88"
                Else
                    conns = "MyConnCloudDnetWTSALES180"
                End If
                'email_sales
                'Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailStaffCancelNama.Text & "'", conns, 3)
                'Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailStaffCancelNama.Text + " dengan NIK " + TxtDetailStaffCancelNIK.Text + " dan tanggal Pengajuan " + TxtDetailStaffCancelTglPengajuan.Text + " dengan Id Izin " + TxtDetailStaffCancelIdIzin.Text + " telah di batalkan Oleh HRD <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                Response.Write("<script>alert('Berhasil Membatalkan  Izin dengan ID : " + TxtDetailStaffCancelIdIzin.Text + "!')</script>")
            Else
                Response.Write("<script>alert('Gagal Membatalkan Izin dengan ID : " + TxtDetailStaffCancelIdIzin.Text + "!')</script>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            End If

        End If
        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    End Sub
    '***cancel pengajuan tgl tahunan
    Protected Sub BtnDetailStaffHRDCancelTahunan_Click(sender As Object, e As EventArgs) Handles BtnDetailStaffHRDCancelTahunan.Click
        'call real saldo staff
        Call Real_saldoStaff("select IZIN_SALDO, IZIN_SALDO_CUTI_TAHUNAN_BERLAKU, IZIN_SALDO_PC, IZIN_SALDO_PC_BERLAKU from DATA_IZIN_HEADER_sales where IZIN_NIK ='" & TxtDetailStaffCancelNIK.Text & "'")
        'get tgl pengajuan sales tersebut 
        ListTgl.Clear()
        ListTgl_Pend.Clear()
        Call GetData_ListTglIzin("select izin_tgldetail from data_izin_detail_sales where izin_id = '" & TxtDetailStaffCancelIdIzin.Text & "'", "1") 'list tgl
        Call GetData_ListTglIzin("select izin_tgldetail from DATA_IZIN_DETAILPC_sales where izin_id = '" & TxtDetailStaffCancelIdIzin.Text & "'", "3") 'list tgl pending
        'get alasan pengajuan 
        If TxtAlasanpengajuan.Text = "Cuti" Or TxtAlasanpengajuan.Text = "Izin Potong Cuti" Or TxtAlasanpengajuan.Text = "Sakit Potong Cuti" Then 'mengembalikan saldo tahunan dan pending 
            'kembalikan saldo tahunan
            If ListTgl.Count > 0 Then
                'kalkulasi saldo tahunan 
                Dim saldo_thn As Integer = saldo_tahunan + ListTgl.Count
                'proses update dan //delete tgl tahunan 
                If UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_STATUS = 'Dibatalkan HRD' where IZIN_ID ='" + TxtDetailStaffCancelIdIzin.Text + "'") = 1 And UpdateData_Server("update DATA_IZIN_HEADER_sales set IZIN_SALDO = '" & saldo_thn & "' where IZIN_NIK ='" & TxtDetailStaffCancelNIK.Text & "' ") = 1 Then
                    'delete detail tanggal di DATA_IZIN_DETAIL_SALES
                    Call UpdateData_Server("delete from DATA_IZIN_DETAIL_SALES where izin_id ='" + TxtDetailStaffCancelIdIzin.Text + "'")
                    'email staff
                    '**EMAIL STAFF YG BERSANGKUTAN
                    'get email staff by nama di 88 /180 // wtsalestransaction - data_salesman - sales_email
                    Dim kodecab As Integer = TxtDetailStaffCancelNIK.Text.Substring(0, 3) 'get kode cabang dari nik 
                    Dim conns As String
                    If kodecab = 112 Then
                        conns = "MyConnCloudDnetWTSALES88"
                    Else
                        conns = "MyConnCloudDnetWTSALES180"
                    End If
                    'email_sales
                    'Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailStaffCancelNama.Text & "'", conns, 3)
                    'Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailStaffCancelNama.Text + " dengan NIK " + TxtDetailStaffCancelNIK.Text + " dan tanggal Pengajuan " + TxtDetailStaffCancelTglPengajuan.Text + " dengan Id Izin " + TxtDetailStaffCancelIdIzin.Text + " telah di batalkan pengajuan izin memotong izin tahunan Oleh HRD <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                    'alert berhasil update saldo tahunan sales
                    Response.Write("<script>alert('Berhasil Membatalkan Tanggal Pengajuan Memotong Izin Tahunan,  Izin dengan ID : " + TxtDetailStaffCancelIdIzin.Text + "!')</script>")
                End If
            End If
        Else
            'izin ini tidak memotong saldo apapun
            Response.Write("<script>alert('izin tidak memotong saldo apapun. proses berhenti!')</script>")
        End If
        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    End Sub
    '**cancel pengajuan tanggal pending
    Protected Sub BtnDetailStaffHRDCancelPending_Click(sender As Object, e As EventArgs) Handles BtnDetailStaffHRDCancelPending.Click
        'call real saldo staff
        Call Real_saldoStaff("select IZIN_SALDO, IZIN_SALDO_CUTI_TAHUNAN_BERLAKU, IZIN_SALDO_PC, IZIN_SALDO_PC_BERLAKU from DATA_IZIN_HEADER_sales where IZIN_NIK ='" & TxtDetailStaffCancelNIK.Text & "'")
        'get tgl pengajuan sales tersebut 
        ListTgl.Clear()
        ListTgl_Pend.Clear()
        Call GetData_ListTglIzin("select izin_tgldetail from data_izin_detail_sales where izin_id = '" & TxtDetailStaffCancelIdIzin.Text & "'", "1") 'list tgl
        Call GetData_ListTglIzin("select izin_tgldetail from DATA_IZIN_DETAILPC_sales where izin_id = '" & TxtDetailStaffCancelIdIzin.Text & "'", "3") 'list tgl pending
        'get alasan pengajuan 
        If TxtAlasanpengajuan.Text = "Cuti" Or TxtAlasanpengajuan.Text = "Izin Potong Cuti" Or TxtAlasanpengajuan.Text = "Sakit Potong Cuti" Then 'mengembalikan saldo tahunan dan pending 
            '***cek dahulu apakah pending cuti masih berlaku -- jika ya : kembalikan saldo pending
            If DateTime.Now <= saldo_pendingberlaku Then
                If ListTgl_Pend.Count > 0 Then
                    'kalkulasi saldo pending
                    Dim saldo_pend As Integer = saldo_pending + ListTgl_Pend.Count
                    'proses update dan //delete tgl pending
                    If UpdateData_Server("update DATA_IZIN_BODY_sales set IZIN_STATUS = 'Dibatalkan HRD' where IZIN_ID ='" + TxtDetailStaffCancelIdIzin.Text + "'") = 1 And UpdateData_Server("update DATA_IZIN_HEADER_sales set  IZIN_SALDO_PC= '" & saldo_pend & "' where IZIN_NIK ='" & TxtDetailStaffCancelNIK.Text & "'") = 1 Then
                        'delete detail tanggal di DATA_IZIN_DETAILPC_SALES
                        Call UpdateData_Server("delete from DATA_IZIN_DETAILPC_SALES where izin_id ='" + TxtDetailStaffCancelIdIzin.Text + "'")
                        'email staff
                        '**EMAIL STAFF YG BERSANGKUTAN
                        'get email staff by nama di 88 /180 // wtsalestransaction - data_salesman - sales_email
                        Dim kodecab As Integer = TxtDetailStaffCancelNIK.Text.Substring(0, 3) 'get kode cabang dari nik 
                        Dim conns As String
                        If kodecab = 112 Then
                            conns = "MyConnCloudDnetWTSALES88"
                        Else
                            conns = "MyConnCloudDnetWTSALES180"
                        End If
                        'email_sales
                        'Call GetData_DetaiIzinSales("select sales_email from DATA_SALESMAN where sales_nama ='" & TxtDetailStaffCancelNama.Text & "'", conns, 3)
                        'Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailStaffCancelNama.Text + " dengan NIK " + TxtDetailStaffCancelNIK.Text + " dan tanggal Pengajuan " + TxtDetailStaffCancelTglPengajuan.Text + " dengan Id Izin " + TxtDetailStaffCancelIdIzin.Text + " telah di batalkan pengajuan izin memotong saldo izin pending Oleh HRD <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", email_sales)
                        'alert berhasil update saldo pending sales
                        Response.Write("<script>alert('Berhasil Membatalkan Tanggal Pengajuan Memotong Izin Pending, Izin dengan ID : " + TxtDetailStaffCancelIdIzin.Text + "!')</script>")
                    End If
                End If
            Else
                'saldo pending cuti sudah tidak berlaku. proses hapus gagal
                Response.Write("<script>alert('Saldo pending sudah tidak berlaku. proses pembatalan Izin dengan ID : " + TxtDetailStaffCancelIdIzin.Text + " gagal!')</script>")
            End If

        Else
            'izin ini tidak memotong saldo apapun
            Response.Write("<script>alert('izin tidak memotong saldo apapun. proses berhenti!')</script>")
        End If
        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    End Sub
    '***btn cari laporan izin 
    Protected Sub BtnCariLaporanIzin_Click(sender As Object, e As EventArgs) Handles BtnCariLaporanIzin.Click
        MultiViewMainSales.ActiveViewIndex = 4
    End Sub
    '***btn download laporan
    Protected Sub BtnFormIzinHRDLaporanIzin_Click(sender As Object, e As EventArgs) Handles BtnFormIzinHRDLaporanIzin.Click
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=Laporan_Izin.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        ListViewIzinLaporan.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
        Response.Write("<script>alert('Sukses Mencetak Laporan')</script>")
        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    End Sub
    '***BUTTON DOWNLOAD HISTORY SALDO
    Protected Sub TxtLaporanSaldoSales_Click(sender As Object, e As EventArgs) Handles TxtLaporanSaldoSales.Click
        GridViewLaporanIzinSales.AllowSorting = False
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=History_Saldo.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        GridViewLaporanIzinSales.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
        Response.Write("<script>alert('Sukses Mencetak History Saldo Staff')</script>")
        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    End Sub
    'You are calling GridView.RenderControl(htmlTextWriter), hence the page raises an exception that a Server-Control was rendered outside Of a Form.
    'You could avoid this execption by overriding
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub
    '***Button untuk cek saldo berjalan
    Protected Sub BtnCekSaldoSalesBerjalan_Click(sender As Object, e As EventArgs) Handles BtnCekSaldoSalesBerjalan.Click
        MultiViewMainSales.ActiveViewIndex = 6
    End Sub
    Protected Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    End Sub
End Class
