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



Partial Class HRDFORMIZIN
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader
    Public CountID As String 'variabel penghitung ID save Izin
    Public NameByNik As String
    Public idizin_pertama As String 'variabel get id izin ketika pertamakali save izin pengajuan
    Dim txt_tgl_cuti(0 To 11) As String
    Public staffEmailnotif As String
    Dim SubJabStaff As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If
        'LvDetailStaff2.Visible = False
        'LvDetailStaff.Visible = False
        If LblUserName.Text = "" Then
            Dim x As String
            Dim mFound As Byte = 0
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = x.ToString
            LabelTidakMasuk.Visible = False
            MultiViewHRDFormIzin.ActiveViewIndex = -1
            MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
            MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
            MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
            'Call GetData_IZIN_STAFF("SELECT IZIN_ID FROM DATA_IZIN WHERE IZIN_NIK='" & TxtStaffNIKMaster.Text & "'")
            Call GetData_STAFF2("SELECT * FROM TB_USER WHERE username='" & LblUserName.Text & "'")
            Call GetData_STAFF("SELECT * FROM DATA_STAFF WHERE STAFF_NIK='" & TxtStaffNIKMaster.Text & "'")
            'fungsi untuk mendapatkan atasan langsung dari staff yg sedang login dan menyimpan nya di txtappuserhead1
            Call GetData_UserHead("select STAFF_ATASAN1 from DATA_STAFF where STAFF_NIK = '" & TxtStaffNIKMaster.Text & "'", "1")
            'fungsi untuk mendapatkan atasan dari atasan langsung 
            Call GetData_UserHead("select STAFF_ATASAN2 from DATA_STAFF where STAFF_NIK = '" & TxtStaffNIKMaster.Text & "'", "3")
            'fungsi untuk konversi nik atasan ke nama atasan
            Call GetData_UserHead("select STAFF_NAMA from DATA_STAFF where STAFF_NIK = '" & TxtAppvHead1.Text & "'", "2")
            'fungsi untuk konversi nik atasan ke nama atasan dari atasan langsung
            Call GetData_UserHead("select STAFF_NAMA from DATA_STAFF where STAFF_NIK = '" & TxtAppvHead2.Text & "'", "4")
            'get data subjabatan dan 
            Call GetData_UserHead("select STAFF_NAMA from DATA_STAFF where STAFF_NIK = '" & TxtAppvHead2.Text & "'", "4")
            'belum bisa identifikasi atasan dari atasan langsung dan apakah satff tsb memiliki atasan dari atasan langsung untuk approval

            '======================================
            'this function give value to TxtHead2
            'Call GetData_UserHead(" Select KPIH_APPVHEAD from TRXN_KPIH where KPIH_NIK='" & TxtStaffNIKMaster.Text & "' AND KPIH_TAHUN='" & TahunPenilaian.Text & "'")

            'to get full name karyawan head
            'Call GetData_UserHead2(" Select NAMAKARYAWAN from TB_USER where username='" & TxtHead2.Text & "'")
            '======================================

            'Call GetData_CountID(" Select IZIN_ID from DATA_IZIN where IZIN_NIK='" & TxtStaffNIKMaster.Text & "'")

            'show year only from system
            TxtTahunCuti.Text = DateTime.Now.ToString("yyyy")
            TxtBulanCuti.Text = DateTime.Now.ToString("MM")

            'mendapatkan atasan satu tingkat di atas staff tersebut
            'TxtAppvHead1.Text = lblAtasan.Text


            'display default txttglcuti1
            'TxtTglCuti1.Visible = True
            'display readonly textbox tgl cuti 
            TxtTglCuti1.Attributes.Add("readonly", "true")
            TxtTglCuti2.Attributes.Add("readonly", "true")
            TxtTglCuti3.Attributes.Add("readonly", "true")
            TxtTglCuti4.Attributes.Add("readonly", "true")
            TxtTglCuti5.Attributes.Add("readonly", "true")
            TxtTglCuti6.Attributes.Add("readonly", "true")
            TxtTglCuti7.Attributes.Add("readonly", "true")
            TxtTglCuti8.Attributes.Add("readonly", "true")
            TxtTglCuti9.Attributes.Add("readonly", "true")
            TxtTglCuti10.Attributes.Add("readonly", "true")
            TxtTglCuti11.Attributes.Add("readonly", "true")
            TxtTglCuti12.Attributes.Add("readonly", "true")

            lblNIKDetail.Text = TxtStaffNIKMaster.Text
            lblNamaDetail.Text = TxtStaffNama.Text
            lblNamaDetail.Enabled = False
            lblNIKDetail.Enabled = False

            lblNikTdkMasuk.Text = TxtStaffNIKMaster.Text
            lblNamaTdkMasuk.Text = TxtStaffNama.Text
            lblNikTdkMasuk.Enabled = False
            lblNamaTdkMasuk.Enabled = False

            lblNikPlgCepat.Text = TxtStaffNIKMaster.Text
            lblNamaPlgCepat.Text = TxtStaffNama.Text
            lblNikPlgCepat.Enabled = False
            lblNamaPlgCepat.Enabled = False
            AlertFileGambar.Visible = False
            'hide mv  hrd form izin
            MultiViewHRDFormIzin.ActiveViewIndex = -1
            'hide mv  hrd form izin detail
            MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
            'hide mv detail and apprv
            MultiViewDetaildanAprrv.ActiveViewIndex = -1
            'hide mv detail table staff


            MultiViewAkses.ActiveViewIndex = 0
            MultiViewNilaiStandardEntry.ActiveViewIndex = -1
            MultiviewFormIzinDetail.ActiveViewIndex = 0
            MultiViewDDJenisIzin.ActiveViewIndex = -1
            'hide mv hrd form izin laporan
            MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
            MultiViewLihatListIzin.ActiveViewIndex = -1



        End If
    End Sub
    'fungsi komparasi tanggal input dengan tanggal saatini



    Function GetData_STAFF2(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_STAFF2 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtStaffNIKMaster.Text = nSr(MyRecReadA("KDKARYAWAN"))
                TxtNama.Text = nSr(MyRecReadA("NAMAKARYAWAN"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function
    Function GetData_IdIzinPengajuan(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
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

    Function GetData_STAFF(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        GetData_STAFF = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()

                'CountID = nSr(MyRecReadA("IZIN_ID"))
                'If CountID = "" Then
                '    lblNikCounter.Text = 0
                'ElseIf CountID >= 0 Then
                '    lblNikCounter.Text = CountID
                'End If


                TxtStaffNIKMaster.Text = nSr(MyRecReadA("STAFF_NIK"))
                'TahunPenilaian.Text = (DateTime.Now.Year.ToString() - 1)
                TxtStaffNIKMaster.Enabled = False
                TxtStaffNama.Text = nSr(MyRecReadA("STAFF_NAMA"))
                TxtStatusKerjaJabatan.Text = nSr(MyRecReadA("STAFF_STATUSKERJAJABATAN"))
                TxtStatusKerjaTempat.Text = nSr(MyRecReadA("STAFF_STATUSKERJALOKASI")) + " / " + nSr(MyRecReadA("STAFF_STATUSKERJADEPT"))
                DataSubJabatan.Text = nSr(MyRecReadA("STAFF_SUBJABATAN"))
                DataDepartemen.Text = nSr(MyRecReadA("STAFF_STATUSKERJADEPT"))
                DataNama.Text = nSr(MyRecReadA("STAFF_NAMA"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function

    'mengambil value user head1 
    Function GetData_UserHead(ByVal mSqlCommadstring As String, ByVal mPos As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_UserHead = 0

        cnn = New OleDbConnection(strconn)
        If mPos = 1 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_UserHead = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'lblAtasan.Text = nSr(MyRecReadA("STAFF_ATASAN")) 'textbox atasan
                    TxtAppvHead1.Text = nSr(MyRecReadA("STAFF_ATASAN1"))
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
                GetData_UserHead = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'lblAtasan.Text = nSr(MyRecReadA("STAFF_ATASAN")) 'textbox atasan
                    lblAtasan.Text = nSr(MyRecReadA("STAFF_NAMA"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 3 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_UserHead = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'lblAtasan.Text = nSr(MyRecReadA("STAFF_ATASAN")) 'textbox atasan
                    TxtAppvHead2.Text = nSr(MyRecReadA("STAFF_ATASAN2"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 4 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_UserHead = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'lblAtasan.Text = nSr(MyRecReadA("STAFF_ATASAN")) 'textbox atasan
                    lblAtasan2.Text = nSr(MyRecReadA("STAFF_NAMA"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 5 Then 'get email staff atasan
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_UserHead = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'lblAtasan.Text = nSr(MyRecReadA("STAFF_ATASAN")) 'textbox atasan
                    staffEmailnotif = nSr(MyRecReadA("STAFF_EMAIL"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        End If

    End Function

    'mengambil value user head12 
    Function GetData_UserHead12(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_UserHead12 = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_UserHead12 = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                'TxtAppvHead2.Text = nSr(MyRecReadA("KPIH_APPVHEAD"))

            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
        End Try
    End Function

    Function GetData_UserHead2(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_UserHead2 = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_UserHead2 = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                TxtHead.Text = nSr(MyRecReadA("NAMAKARYAWAN"))
                lblAtasan.Text = nSr(MyRecReadA("NAMAKARYAWAN"))
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
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


    Function GetFindRecord_Server(ByVal mSqlCommadstring As String) As Byte
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
            Else
                GetFindRecord_Server = 0
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function
    Function UpdateData_ServerCancel(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        'LabelError.Text = ""
        UpdateData_ServerCancel = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_ServerCancel = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function
    Protected Sub DropDownJenisiIzin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownJenisiIzin.SelectedIndexChanged
        'MultiViewNilaiStandardEntry.ActiveViewIndex = Convert.ToInt32(DropDownJenisiIzin.SelectedValue)
        Dim idx As Integer = Convert.ToInt32(DropDownJenisiIzin.SelectedValue)
        If idx = 0 Then 'untuk cuti
            MultiViewNilaiStandardEntry.ActiveViewIndex = 0
            LabelCuti.Visible = True
            LabelTidakMasuk.Visible = False
            DropDownListTidakMasuk.Visible = False
            DropDownListCuti.Visible = True
            UploadFile.Visible = False
            Label47.Visible = False
            AlertFileGambar.Visible = False
        ElseIf idx = 1 Then 'untuk tidak masuk kantor
            MultiViewNilaiStandardEntry.ActiveViewIndex = 0
            LabelCuti.Visible = False
            LabelTidakMasuk.Visible = True
            DropDownListCuti.Visible = False
            DropDownListTidakMasuk.Visible = True
            UploadFile.Visible = True
            Label47.Visible = True
            AlertFileGambar.Visible = True
        ElseIf idx = 2 Then 'untuk datang siang [izin terlambat]
            LabelDatangSiang.Visible = True
            LabelPulangCepat.Visible = False
            MultiViewNilaiStandardEntry.ActiveViewIndex = 3
            Label12.Visible = False
            Label40.Visible = True
            TxtIzinPulangCepat.Visible = False
            TxtIzinDatangTelat.Visible = True
            Label39.Visible = False
            Label41.Visible = True
            TxtIzinPulangCepatJam.Visible = False
            TxtIzinDatangTelatJam.Visible = True
            Label13.Visible = False
            Label42.Visible = True
            'alasankeluarkantor.Visible = True
            LabelAlertIzinTerlambat.Visible = True
            LabelAlertIzinTerlambat.Text = "Izin Datang Siang Maksimal 1 Setengah Jam, dari Jam Masuk Kantor"
            LabelAlertIzinKeluarKantor.Visible = False
        ElseIf idx = 3 Then 'untuk pulang cepat - [keluar kantor]
            LabelDatangSiang.Visible = False
            LabelPulangCepat.Visible = True
            MultiViewNilaiStandardEntry.ActiveViewIndex = 3
            Label12.Visible = True
            Label40.Visible = False
            TxtIzinPulangCepat.Visible = True
            TxtIzinDatangTelat.Visible = False
            Label39.Visible = True
            Label41.Visible = False
            TxtIzinPulangCepatJam.Visible = True
            TxtIzinDatangTelatJam.Visible = False
            Label13.Visible = True
            Label42.Visible = False
            'alasankeluarkantor.Visible = True
            LabelAlertIzinTerlambat.Visible = False
            LabelAlertIzinKeluarKantor.Visible = True
            LabelAlertIzinKeluarKantor.Text = "Izin Pulang Cepat Maksimal 1 Setengah Jam dari Jam Pulang Kantor"
        End If
        'hide detail izin staff yg dari table list izin staff
        MultiViewDetaildanAprrv.ActiveViewIndex = -1
        'hide tb data list izin staff
        MultiViewHRDFormIzin.ActiveViewIndex = -1
        'multiview menu hrd
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        'hide mv hrd form izin laporan
        MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
        'hide mv MultiViewHRDFormIzinMaster
        MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        'hide mv MultiViewHRDFormIzinDetail2
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        'hide mv MultiViewHRDFormIzinDecline
        MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide mv lihat list izin
        MultiViewLihatListIzin.ActiveViewIndex = -1


    End Sub

    Public tgl1 As Date
    Public email_staff_btnCuti As String
    Public dateListDead As List(Of DateTime) = New List(Of DateTime)() 'array temporary (berisi tgl merah liburan)
    'get tanggal libur by predefine
    Function GetData_ListTglPre(ByVal mSqlCommadstring As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

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
    Protected Sub BtnSaveCuti_Click(sender As Object, e As EventArgs) Handles BtnSaveCuti.Click
        Dim jnsizin2 As Integer = DropDownJenisiIzin.SelectedValue
        Dim dateList As List(Of DateTime) = New List(Of DateTime)() 'array asli dari user
        Dim dateListNotMinggu As List(Of DateTime) = New List(Of DateTime)() 'array datetime bukan minggu
        Dim dateListByHRD As List(Of DateTime) = New List(Of DateTime)() 'array final yang akan di insert
        If jnsizin2 = 0 Then
            '***********Proses Get List Tanggal**************************************************************
            'Dim alasandandetail As String
            Dim tgl_awal As DateTime = TextBox1.Text
            Dim tgl_akhir As DateTime = TextBox2.Text
            Dim thn1 As Integer = Convert.ToInt32(tgl_awal.ToString("yyyy")) 'tahun awal
            Dim thn2 As Integer = Convert.ToInt32(tgl_akhir.ToString("yyyy")) 'tahun akhir 
            Dim thn3 As Integer = Convert.ToInt32(DateTime.Now.ToString("yyyy")) 'tahun berjalan 
            'validasi tahun yg di ambil harus sama dari tgl awal dan tgl akhir 
            If thn1 = thn2 And thn1 <> thn3 Then
                'cek apakah saldo berjalan staff ini 2018 /2019
                Response.Write("<script>alert('Hanya di Perbolehkan mengambil Izin Di Tahun yang Sama dengan Tahun Berjalan')</script>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            Else
                Dim ts As TimeSpan = tgl_akhir.Subtract(tgl_awal)
                ''1=senin, 2=selasa, 3=rabu, 4=kamis, 5=jumat, 6=sabtu, 7=minggu


                '*****FIND DATEDIFF FUNCTION HOW TO WORK
                Dim DayInterval2 As String = DateDiff(DateInterval.Day, tgl_awal, tgl_akhir)
                'Response.Write("<script>alert('Jml Interval Hari:  " + DayInterval2 + "')</script>")
                '**********CHARM*******************
                '**assign date time range value to array
                For i As Integer = 0 To DayInterval2
                    dateList.Add(tgl_awal.AddDays(i))
                Next
                'Response.Write("<script>alert('Selesai Menyimpan Array.')</script>")
                '**display the value of array (sebelum eliminasi minggu)
                For i As Integer = 0 To DayInterval2
                    'Response.Write("<script>alert('Hari yang di ambil (Sebelum Eliminasi Minggu) :  " + dateList(i) + "')</script>")
                Next
                '**save date yg bukan minggu menjadi array baru 
                For Each item As DateTime In dateList
                    If item.DayOfWeek <> 0 Then
                        dateListNotMinggu.Add(item)
                    End If
                Next
                '**access by for each 
                For Each itemx As DateTime In dateListNotMinggu
                    'Response.Write("<script>alert('Hari yang di ambil (Setelah Eliminasi Minggu):  " + itemx + "')</script>")
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
                'ketika jumlah hari yang di ajukan = 0 maka gagal input izin
                Response.Write("<script>alert('Jumlah Hari yang di Ajukan:  " + Convert.ToString(dateListNotMinggu.Count) + "')</script>")
            End If
            '****************************proses izin cuti**************************************************************
            If TxtAlasanIzinDetail.Text = "" Then
                Response.Write("<script>alert('Data Alasan Detail Tidak Boleh Kosong! Ulangi Kembali')</script>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            Else
                Response.Write("<script>alert('Jenis izin yang di ajukan Cuti!')</script>")
                Try
                    If TxtEmailStaff.Text <> "" Then
                        Dim em As MailAddress = New MailAddress(TxtEmailStaff.Text)
                        Dim dt As String = DateTime.Now.ToString("yyyy")
                        Call UpdateData_Server("update DATA_STAFF set STAFF_EMAIL = '" & TxtEmailStaff.Text & "' where STAFF_NIK = '" & TxtStaffNIKMaster.Text & "' ", "")
                        'get nilai saldo cuti dari staff(saldo_cutiStaff) dan tahun berjalan saldo tersebut(saldo_tahun)
                        Call GetData_SaldoCutiStaff("select IZIN_SALDO, IZIN_TAHUN from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtStaffNIKMaster.Text & "'")

                        'Response.Write("<script>alert('Jml Saldo Anda : " + saldo_cutiStaff + " ')</script>")
                        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

                        If (TextBox1.Text = "") And (TextBox2.Text = "") Then
                            Response.Write("<script>alert('Data tanggal pengajuan tidak boleh kosong, proses di batalkan')</script>")
                            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        Else
                            'insert staff email ketika staff tersebut belum memiliki email
                            Dim jmltgl As Integer = Convert.ToInt32(dateListNotMinggu.Count) 'jml tgl cuti yang di ajukan 

                            If saldo_cutiStaff = "" Or saldo_cutiStaff <= 0 Then
                                Response.Write("<script>alert('Saldo Anda Kosong di tahun ini dan Belum bisa Mengajukan Cuti. Silahkan Hubungi HRD untuk Input Saldo Cuti')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            ElseIf saldo_cutiStaff = 1 And jmltgl > 1 Then
                                Response.Write("<script>alert('Saldo Izin anda 1 , Jml pengajuan cuti anda lebih dari 1. Proses Pengajuan Gagal!')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            ElseIf jmltgl > saldo_cutiStaff Then
                                'Response.Write("<script>alert('" + jmltgl + "" + saldo_cutiStaff + "')</script>")
                                Response.Write("<script>alert('Saldo Izin anda tidak mencukupi, Jml pengajuan cuti anda lebih dari Saldo Cuti anda. Proses Pengajuan Gagal!')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            ElseIf jmltgl = 0 Then
                                Response.Write("<script>alert('Tanggal yang Anda Ajukan adalah Tanggal Merah. Periksa Kembali Tanggal Pengajuan Anda!')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            Else
                                'revisi 15/10/2018
                                'Dim x As Integer = jmltglcuti.Text
                                'Dim tglarry As New List(Of String)
                                'tglarry.Add(TxtTglCuti1.Text)
                                'tglarry.Add(TxtTglCuti2.Text)
                                'tglarry.Add(TxtTglCuti3.Text)
                                'tglarry.Add(TxtTglCuti4.Text)
                                'tglarry.Add(TxtTglCuti5.Text)
                                'tglarry.Add(TxtTglCuti6.Text)
                                'tglarry.Add(TxtTglCuti7.Text)
                                'tglarry.Add(TxtTglCuti8.Text)
                                'tglarry.Add(TxtTglCuti9.Text)
                                'tglarry.Add(TxtTglCuti10.Text)
                                'tglarry.Add(TxtTglCuti11.Text)
                                'tglarry.Add(TxtTglCuti12.Text)


                                'insert data_izin_body untuk cuti
                                Dim JnsIzin As String = "Cuti"

                                Dim tgldead As DateTime = FormatDateTime(Now.AddDays(+6), DateFormat.ShortDate)
                                Dim datenowher As DateTime = FormatDateTime(Now, DateFormat.ShortDate)

                                'insert data_izin_body
                                'alasandandetail = TxtPetik(DropDownListCuti.Text) + " / " + TxtAlasanIzinDetail.Text
                                If UpdateData_Server("INSERT INTO DATA_IZIN_BODY (IZIN_ALASANDETAIL,IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtAlasanIzinDetail.Text & "','" & TxtBulanCuti.Text & "','" & TxtStaffNIKMaster.Text & "','" & TxtPetik(DropDownListCuti.Text) & "','" & JnsIzin & "','" & TxtTahunCuti.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "") = 1 Then
                                    Response.Write("<script>alert('Berhasil Input Data Izin Staff')</script>")
                                Else
                                    Response.Write("<script>alert('Gagal Input Data Izin Staff')</script>")
                                End If
                                'Call UpdateData_Server("INSERT INTO DATA_IZIN_BODY (IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_TAHUN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtStaffNIKMaster.Text & "','" & TxtPetik(DropDownListCuti.Text) & "','" & JnsIzin & "','" & TxtTahunCuti.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "")
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY order by izin_id desc")
                                Response.Write("<script>alert('Value : " + idizin_pertama + "')</script>")
                                'insert data_izin_detail (list tanggal yang di ajkuan)
                                For Each items As DateTime In dateListNotMinggu
                                    Call UpdateData_Server("insert into DATA_IZIN_DETAIL (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & TxtStaffNIKMaster.Text & "')", "")
                                Next
                                'For i As Integer = 0 To x - 1
                                '    'Response.Write("<script>alert('Value : " + tglarry(i) + "')</script>")
                                '    Call UpdateData_Server("insert into DATA_IZIN_DETAIL (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & Convert.ToDateTime(tglarry(i)) & "', '" & TxtStaffNIKMaster.Text & "')", "")
                                '    'Response.Write("<script>alert('Berhasil Input Data Detail Izin Staff')</script>")
                                'Next
                                '================call function to email atasan
                                Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NAMA ='" & lblAtasan.Text & "'", "5") 'get email atasan1 value dan menyimpan ke variabel : staffEmailnotif
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY order by izin_id desc")
                                'email ke atasan 1
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtStaffNama.Text + " dengan NIK " + TxtStaffNIKMaster.Text + " dan tanggal Pengajuan " + DateTime.Now + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            End If
                            'Response.Write("<script>alert('Data berhasil di Simpan " + jmltgl + " ')</script>")
                            'Response.Write("<script>alert('Data : " + txt_tgl_cuti(0) + "," + txt_tgl_cuti(1) + " ')</script>")
                        End If
                    Else
                        Response.Write("<script>alert('Email Tidak Boleh Kosong!')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If

                Catch ex As FormatException
                    Response.Write("<script>alert('Format Email Salah, Silahkan Input Ulang!')</script>")
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End Try
            End If
            '****************************proses izin cuti**************************************************************
        ElseIf jnsizin2 = 1 Then 'izin tidak masuk pengajuan kantor
            '***********Proses Get List Tanggal**************************************************************
            'Dim alasandandetail As String
            Dim tgl_awal As DateTime = TextBox1.Text
            Dim tgl_akhir As DateTime = TextBox2.Text
            Dim thn1 As Integer = Convert.ToInt32(tgl_awal.ToString("yyyy"))
            Dim thn2 As Integer = Convert.ToInt32(tgl_akhir.ToString("yyyy"))
            Dim thn3 As Integer = Convert.ToInt32(DateTime.Now.ToString("yyyy"))
            'validasi tahun yg di ambil harus sama dari tgl awal dan tgl akhir 
            If thn1 = thn2 And thn1 <> thn3 Then
                'cek apakah saldo berjalan staff ini 2018 /2019
                Response.Write("<script>alert('Hanya di Perbolehkan mengambil Izin Di Tahun yang Sama dengan Tahun Berjalan')</script>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            Else
                Dim ts As TimeSpan = tgl_akhir.Subtract(tgl_awal)
                ''1=senin, 2=selasa, 3=rabu, 4=kamis, 5=jumat, 6=sabtu, 7=minggu

                '*****FIND DATEDIFF FUNCTION HOW TO WORK
                Dim DayInterval2 As String = DateDiff(DateInterval.Day, tgl_awal, tgl_akhir)
                'Response.Write("<script>alert('Jml Interval Hari:  " + DayInterval2 + "')</script>")
                '**********CHARM*******************
                '**assign date time range value to array
                For i As Integer = 0 To DayInterval2
                    dateList.Add(tgl_awal.AddDays(i))
                Next
                'Response.Write("<script>alert('Selesai Menyimpan Array.')</script>")
                '**display the value of array (sebelum eliminasi minggu)
                For i As Integer = 0 To DayInterval2
                    'Response.Write("<script>alert('Hari yang di ambil (Sebelum Eliminasi Minggu) :  " + dateList(i) + "')</script>")
                Next
                '**save date yg bukan minggu menjadi array baru 
                For Each item As DateTime In dateList
                    If item.DayOfWeek <> 0 Then
                        dateListNotMinggu.Add(item)
                    End If
                Next
                '**access by for each 
                For Each itemx As DateTime In dateListNotMinggu
                    'Response.Write("<script>alert('Hari yang di ambil (Setelah Eliminasi Minggu):  " + itemx + "')</script>")
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
                'ketika jumlah hari yang di ajukan = 0 maka gagal input izin
                Response.Write("<script>alert('Jumlah Hari yang di Ajukan:  " + Convert.ToString(dateListNotMinggu.Count) + "')</script>")
            End If
            '*********************************izin tidak masuk kantor*******************************************
            If TxtAlasanIzinDetail.Text = "" Then
                Response.Write("<script>alert('Data Alasan Detail Tidak Boleh Kosong! Ulangi Kembali')</script>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            Else
                'Response.Write("<script>alert('tidak masuk!')</script>")
                Try
                    If TxtEmailStaff.Text <> "" Then
                        Dim em As MailAddress = New MailAddress(TxtEmailStaff.Text)
                        Dim dt As String = DateTime.Now.ToString("yyyy")
                        Call UpdateData_Server("update DATA_STAFF set STAFF_EMAIL = '" & TxtEmailStaff.Text & "' where STAFF_NIK = '" & TxtStaffNIKMaster.Text & "' ", "")
                        Call GetData_SaldoCutiStaff("select IZIN_SALDO, IZIN_TAHUN from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtStaffNIKMaster.Text & "'")

                        'Response.Write("<script>alert('Jml Saldo Anda : " + saldo_cutiStaff + " ')</script>")
                        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

                        If (TextBox1.Text = "") And (TextBox2.Text = "") Then
                            Response.Write("<script>alert('Data tanggal pengajuan tidak boleh kosong, proses di batalkan')</script>")
                            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        Else
                            'insert staff email ketika staff tersebut belum memiliki email
                            Dim jmltgl As Integer = Convert.ToInt32(dateListNotMinggu.Count) 'jml tgl cuti yang di ajukan 
                            'get nilai saldo cuti dari staff tsb .
                            If saldo_cutiStaff = "" Or saldo_cutiStaff <= 0 Then
                                Response.Write("<script>alert('Saldo Anda Kosong di tahun ini dan Belum bisa Mengajukan Cuti. Silahkan Hubungi HRD untuk Input Saldo Cuti')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            ElseIf saldo_cutiStaff = 1 And jmltgl > 1 Then
                                Response.Write("<script>alert('Saldo Izin anda 1 , Jml pengajuan cuti anda lebih dari 1. Proses Pengajuan Gagal!')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            ElseIf jmltgl > saldo_cutiStaff Then
                                'Response.Write("<script>alert('" + jmltgl + "" + saldo_cutiStaff + "')</script>")
                                Response.Write("<script>alert('Saldo Izin anda tidak mencukupi, Jml pengajuan cuti anda lebih dari Saldo Cuti anda. Proses Pengajuan Gagal!')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            ElseIf jmltgl = 0 Then
                                Response.Write("<script>alert('Tanggal yang Anda Ajukan adalah Tanggal Merah. Periksa Kembali Tanggal Pengajuan Anda!')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            Else
                                'revisi 15/10/2018
                                'Dim x As Integer = jmltglcuti.Text
                                'Dim tglarry As New List(Of String)
                                'tglarry.Add(TxtTglCuti1.Text)
                                'tglarry.Add(TxtTglCuti2.Text)
                                'tglarry.Add(TxtTglCuti3.Text)
                                'tglarry.Add(TxtTglCuti4.Text)
                                'tglarry.Add(TxtTglCuti5.Text)
                                'tglarry.Add(TxtTglCuti6.Text)
                                'tglarry.Add(TxtTglCuti7.Text)
                                'tglarry.Add(TxtTglCuti8.Text)
                                'tglarry.Add(TxtTglCuti9.Text)
                                'tglarry.Add(TxtTglCuti10.Text)
                                'tglarry.Add(TxtTglCuti11.Text)
                                'tglarry.Add(TxtTglCuti12.Text)


                                'insert data_izin_body untuk cuti
                                Dim JnsIzin As String = "Tidak Masuk Kantor"

                                Dim tgldead As DateTime = FormatDateTime(Now.AddDays(+6), DateFormat.ShortDate)
                                Dim datenowher As DateTime = FormatDateTime(Now, DateFormat.ShortDate)

                                'insert data_izin_body
                                'alasandandetail = TxtPetik(DropDownListTidakMasuk.Text) + " / " + TxtAlasanIzinDetail.Text

                                If UpdateData_Server("INSERT INTO DATA_IZIN_BODY (IZIN_ALASANDETAIL, IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtAlasanIzinDetail.Text & "','" & TxtBulanCuti.Text & "','" & TxtStaffNIKMaster.Text & "','" & TxtPetik(DropDownListTidakMasuk.Text) & "','" & JnsIzin & "','" & TxtTahunCuti.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "") = 1 Then
                                    'Response.Write("<script>alert('Jenis Tidak Masuk : " + DropDownListTidakMasuk.Text + "')</script>")
                                    '=======
                                    If Page.IsValid And DropDownListTidakMasuk.Text = "Sakit Surat Dokter" Then
                                        'If the Default.aspx validation is true (for example if the uploaded file is of correct file type, then process the rest of the script.
                                        Dim filereceived As String = FileUpload1.PostedFile.FileName
                                        Dim filename As String = Path.GetFileName(filereceived)
                                        Dim EditDataStafffoto As String
                                        If filereceived = "" Then 'validasi file upload tidak boleh kosong
                                            Response.Write("<script>alert('Anda Harus Mengupload File. Proses Pengajuan Tidak Masuk Kantor Gagal.')</script>")
                                            'get id top 1 idizin_pertama
                                            Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY order by izin_id desc")
                                            'delete id top 1 data izin body
                                            Dim deletepengajuangagal As String = "delete from data_izin_body where izin_id = '" & idizin_pertama & "'"
                                            Call UpdateData_Server(deletepengajuangagal, "")
                                            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                        Else
                                            'get data staff id 
                                            Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY order by izin_id desc")
                                            EditDataStafffoto = "UPDATE data_izin_body SET IZIN_FILEDETAIL='" & filename & "' WHERE  IZIN_ID='" & idizin_pertama & "'"
                                            Call UpdateData_Server(EditDataStafffoto, "")
                                            Dim fileuploadpath As String = "C:/inetpub/wwwroot/MugenASPHRISO/WEBDOWNLOAD/FOTOIZIN/"
                                            'Dim Fileuploadpath As String = "D:/Herlambang/September-Ongoing - Revisi Input Data Izin (Table)/TestFromUpload/LiveMUGENASP/MugenASPHRISO_10_22_018/img/imgstaff/"
                                            FileUpload1.PostedFile.SaveAs(Path.Combine(fileuploadpath, filename))
                                            'FileUpload1.SaveAs(Server.MapPath("~inetpub/wwwroot/MugenASPHRISO/WEBDOWNLOAD/FOTOIZIN") & filename)
                                            'FileUpload1.SaveAs(Server.MapPath("~") & filename)
                                            Response.Write("<script>alert('Berhasil Input Data Izin Staff')</script>")
                                        End If


                                        'Dim filename As String = Path.GetFileName(ImageFileUpload.FileName)
                                        'ImageFileUpload.SaveAs(Server.MapPath("~/nForum/uploads/") & filename)
                                    End If
                                    '=======
                                    'Response.Write("<script>alert('Berhasil Input Data Izin Staff')</script>")
                                Else
                                    Response.Write("<script>alert('Gagal Input Data Izin Staff')</script>")
                                End If
                                'Call UpdateData_Server("INSERT INTO DATA_IZIN_BODY (IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_TAHUN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & TxtStaffNIKMaster.Text & "','" & TxtPetik(DropDownListCuti.Text) & "','" & JnsIzin & "','" & TxtTahunCuti.Text & "','" & datenowher & "','" & tgldead & "','Pending')", "")
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY order by izin_id desc")
                                Response.Write("<script>alert('Value : " + idizin_pertama + "')</script>")
                                'insert data_izin_detail (list tanggal yang di ajkuan)
                                For Each items As DateTime In dateListNotMinggu
                                    Call UpdateData_Server("insert into DATA_IZIN_DETAIL (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & items & "', '" & TxtStaffNIKMaster.Text & "')", "")
                                Next
                                'insert data_izin_detail 
                                'For i As Integer = 0 To x - 1
                                '    'Response.Write("<script>alert('Value : " + tglarry(i) + "')</script>")
                                '    Call UpdateData_Server("insert into DATA_IZIN_DETAIL (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK) values ('" & idizin_pertama & "','" & Convert.ToDateTime(tglarry(i)) & "', '" & TxtStaffNIKMaster.Text & "')", "")
                                '    'Response.Write("<script>alert('Berhasil Input Data Detail Izin Staff')</script>")
                                'Next
                                '================call function to email atasan
                                Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NAMA ='" & lblAtasan.Text & "'", "5") 'get email atasan1 value dan menyimpan ke variabel : staffEmailnotif
                                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY order by izin_id desc")
                                'email ke atasan 1
                                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtStaffNama.Text + " dengan NIK " + TxtStaffNIKMaster.Text + " dan tanggal Pengajuan " + DateTime.Now + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            End If
                            'Response.Write("<script>alert('Data berhasil di Simpan " + jmltgl + " ')</script>")
                            'Response.Write("<script>alert('Data : " + txt_tgl_cuti(0) + "," + txt_tgl_cuti(1) + " ')</script>")
                        End If
                    Else
                        Response.Write("<script>alert('Email Tidak Boleh Kosong!')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If

                Catch ex As FormatException
                    Response.Write("<script>alert('Format Email Salah, Silahkan Input Ulang!')</script>")
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End Try
            End If
            '*********************************izin tidak masuk kantor*******************************************
        End If
    End Sub
    Public strtelatcepat As String
    Protected Sub BtnSaveIzinDatangTelatPulangCepat_Click(sender As Object, e As EventArgs) Handles BtnSaveIzinDatangTelatPulangCepat.Click
        Dim JnsIzinTelat As Integer = DropDownJenisiIzin.SelectedValue
        'TxtAlasanIzinPulangCepat  1= ke customer, 2= ke pameran, 3= lainlain [TxtIzinPulangCepatAlasan]
        'lblNikPlgCepat
        'lblNamaPlgCepat
        '********insert ke data_izin_detail dan body
        'Dim AlasanIzinStaff As String = TxtAlasanIzinPulangCepat.Text
        Dim tgldead As DateTime = FormatDateTime(Now.AddDays(+6), DateFormat.ShortDate) 'tanggal deadline
        Dim datenowher As DateTime = FormatDateTime(Now, DateFormat.ShortDate) 'tanggal hari ini
        Dim thn1 As Integer = DateTime.Now.ToString("yyyy")
        Dim bln1 As Integer = DateTime.Now.ToString("MM")

        'If AlasanIzinStaff = 1 Then
        '    strtelatcepat = "Ke Customer"
        'ElseIf AlasanIzinStaff = 2 Then
        '    strtelatcepat = "Ke Pameran"
        'ElseIf AlasanIzinStaff = 3 Then
        strtelatcepat = TxtAlasanIzinPulangCepat.Text
        'End If

        If JnsIzinTelat = 2 Then 'datang siang
            If TxtAlasanIzinPulangCepat.Text = "" Or TxtIzinDatangTelatJam.Text = "" Or TxtIzinDatangTelat.Text = "" Then
                Response.Write("<script>alert('Alasan / Jam / Tanggal tidak boleh kosong!')</script>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            Else
                Dim jnsizin = "Izin Terlambat"
                'insert data_izin_body
                If UpdateData_Server("INSERT INTO DATA_IZIN_BODY (IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & bln1 & "','" & lblNikPlgCepat.Text & "','" & strtelatcepat & "','" & jnsizin & "','" & thn1 & "','" & datenowher & "','" & tgldead & "','Pending')", "") = 1 Then
                    Response.Write("<script>alert('Berhasil Input Data Izin Staff')</script>")
                Else
                    Response.Write("<script>alert('Gagal Input Data Izin Staff')</script>")
                End If
                'get id izin terbaru untuk insert ke data izin detail
                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY order by izin_id desc")
                Response.Write("<script>alert('Value : " + idizin_pertama + "')</script>")
                'insert data izin detail
                Call UpdateData_Server("insert into DATA_IZIN_DETAIL (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK, IZIN_JAMDETAIL) values ('" & idizin_pertama & "','" & TxtIzinDatangTelat.Text & "', '" & lblNikPlgCepat.Text & "', '" & TxtIzinDatangTelatJam.Text & "')", "")

                '================call function to email atasan

                Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NAMA ='" & lblAtasan.Text & "'", "5") 'get email atasan1 value dan menyimpan ke variabel : staffEmailnotif
                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY order by izin_id desc")
                'email ke atasan 1
                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + lblNamaPlgCepat.Text + " dengan NIK " + lblNikPlgCepat.Text + " dan tanggal Pengajuan " + datenowher + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")


                '***************************************************************************************
                'Response.Write("<script>alert('Datang Siang : alasan = " + strtelatcepat + "')</script>")
                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                'TxtIzinDatangTelat
                'TxtIzinDatangTelatJam
            End If
        ElseIf JnsIzinTelat = 3 Then 'pulang cepat
            If TxtAlasanIzinPulangCepat.Text = "" Or TxtIzinPulangCepatJam.Text = "" Or TxtIzinPulangCepat.Text = "" Then
                Response.Write("<script>alert('Alasan / Jam / Tanggal tidak boleh kosong!')</script>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            Else
                Dim jnsizin = "Izin Keluar Kantor"
                'insert data_izin_body
                If UpdateData_Server("INSERT INTO DATA_IZIN_BODY (IZIN_BLNPENGAJUAN, IZIN_NIK, IZIN_ALASAN, IZIN_JENIS, IZIN_THNPENGAJUAN, IZIN_TGLPENGAJUAN, IZIN_TGLDEADLINE, IZIN_STATUS) VALUES ('" & bln1 & "','" & lblNikPlgCepat.Text & "','" & strtelatcepat & "','" & jnsizin & "','" & thn1 & "','" & datenowher & "','" & tgldead & "','Pending')", "") = 1 Then
                    Response.Write("<script>alert('Berhasil Input Data Izin Staff')</script>")
                Else
                    Response.Write("<script>alert('Gagal Input Data Izin Staff')</script>")
                End If
                'get id izin terbaru untuk insert ke data izin detail
                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY order by izin_id desc")
                Response.Write("<script>alert('Value : " + idizin_pertama + "')</script>")
                'insert data izin detail
                Call UpdateData_Server("insert into DATA_IZIN_DETAIL (IZIN_ID, IZIN_TGLDETAIL, IZIN_NIK, IZIN_JAMDETAIL) values ('" & idizin_pertama & "','" & TxtIzinPulangCepat.Text & "', '" & lblNikPlgCepat.Text & "', '" & TxtIzinPulangCepatJam.Text & "')", "")

                '================call function to email atasan

                Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NAMA ='" & lblAtasan.Text & "'", "5") 'get email atasan1 value dan menyimpan ke variabel : staffEmailnotif
                Call GetData_IdIzinPengajuan("select top 1 IZIN_ID from DATA_IZIN_BODY order by izin_id desc")
                'email ke atasan 1
                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + lblNamaPlgCepat.Text + " dengan NIK " + lblNikPlgCepat.Text + " dan tanggal Pengajuan " + datenowher + " dengan Id Izin " + idizin_pertama + " menunggu Approval anda! <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")


                '****************************************************************************************
                Response.Write("<script>alert('pulang Cepat : alasan = " + strtelatcepat + "')</script>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                'TxtIzinPulangCepat
                'TxtIzinPulangCepatJam
            End If

        End If
    End Sub


    'fungsi untuk kirim email ke atasan
    'KUMPULAN EMAIL FUNGSI==========================================================================================
    Function emailNotifikasi(isiPesan As String) As Byte
        Dim pesan As New MailMessage
        pesan.Subject = "test SMTP"
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

    Sub Msg_err(ByVal mTest As String)
        lblMsgBox.Text = mTest
        If mTest = "" Then
            MultiViewError.ActiveViewIndex = 0
        Else
            MultiViewError.ActiveViewIndex = 0
        End If
    End Sub



    Function InsertData_Izin() As String
        Dim JnsIzin As String
        'Dim IzinIDCount As String
        Dim appv_head1, appv_head2 As String

        appv_head1 = TxtAppvHead1.Text
        appv_head2 = TxtAppvHead2.Text

        If appv_head1 = "" Then
            appv_head1 = Nothing
        ElseIf appv_head2 = "" Then
            appv_head2 = "--"
        End If
        'Note : appvhead1 yg tersimpan adalah NIK nya bukan namanya 
        JnsIzin = "Cuti"
        InsertData_Izin = "INSERT INTO DATA_IZIN (IZIN_NIK, IZIN_NAMA, IZIN_SALDO_CUTI,IZIN_APPVSPV, IZIN_APPVMNG) VALUES ('" & TxtStaffNIKMaster.Text & "', '" & TxtStaffNama.Text & "',NULL,'" & appv_head1 & "', '" & appv_head2 & "')"

        'Response.Write("<script>alert('Data berhasil di Simpan ')</script>")

    End Function

    Function InsertData_ApprovalIzinStaff() As String
        InsertData_ApprovalIzinStaff = "update DATA_IZINDETAIL set IZIN_TGL_APPVSPV = '" & DateTime.Now & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "'"

        'Response.Write("<script>alert('Data berhasil di Simpan ')</script>")

    End Function
    '============================================================== miscellaneous Function=============================
    Function UpdateData_Server(ByVal mSqlCommadstring As String, ByVal mPos As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        LblErrorSaveCuti.Text = ""
        'LblErrorSaveA111.Text = ""
        'LblErrorSaveA113.Text = ""
        'LblErrorSaveA12.Text = ""
        'LblErrorSaveA13.Text = ""
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
            Call ErrorIsi(mPos, ex.Message)
        End Try
    End Function

    Sub ErrorIsi(ByVal Kode As String, ByVal Errormsg As String)
        If Kode = "I1" Then
            LblErrorSaveCuti.Text = Errormsg
            'ElseIf Kode = "A111" Then
            'LblErrorSaveA111.Text = Errormsg
            'ElseIf Kode = "A113" Then
            'LblErrorSaveA113.Text = Errormsg
            'ElseIf Kode = "A12" Then
            'LblErrorSaveA12.Text = Errormsg
            'ElseIf Kode = "A13" Then
            'LblErrorSaveA13.Text = Errormsg

        End If
    End Sub

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

    'fungsi yang berjalan ketika aksi dari linkbtn detail di klik pada tabel list izin
    Public nik_lvdetailizinstaff As String
    Public jml_izin As String
    Public nik_atasan1, nik_atasan2, nik_staff1, nameapv2, statusizin, tgldeadline As String
    Public nik_staffx As String
    Public tglapv1, tglapv2 As String
    Protected Sub LvDetailStaff_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailStaff.SelectedIndexChanged
        Dim id_izin As String = (LvDetailStaff.DataKeys(LvDetailStaff.SelectedIndex).Value.ToString)
        'untuk set div nya seperti semula, ketika user berpindah pindah value to show 
        'Response.Write("<script>alert('LvDetailStaff')</script>")
        divtgl1.Visible = True
        divtgl2.Visible = True
        divtgl3.Visible = True
        divtgl4.Visible = True
        divtgl5.Visible = True
        divtgl6.Visible = True
        divtgl7.Visible = True
        divtgl8.Visible = True
        divtgl9.Visible = True
        divtgl10.Visible = True
        divtgl11.Visible = True
        divtgl12.Visible = True
        'Response.Write("<script>alert('Nik yang login " + TxtStaffNIKMaster.Text + "')</script>")
        'Response.Write("<script>alert('Nik yang login " + nik_lvdetailizinstaff + "')</script>")

        'untuk User terkait masih blm bisa mengecek detil izin yang di ajukan

        'mencocokan user yg bisa mengakses hanya atasan 1 dan 2 dari staff tersebut 
        Call GetData_DetaiIzinStaff("select IZIN_NIK from DATA_IZIN_BODY where IZIN_ID = '" & id_izin & "'", "6") 'mendapatkan nilai NIK 
        Call GetData_DetaiIzinStaff("select STAFF_ATASAN1 from DATA_STAFF where STAFF_NIK = '" & nik_staff1 & "'", "4")
        Call GetData_DetaiIzinStaff("select STAFF_ATASAN2 from DATA_STAFF where STAFF_NIK = '" & nik_staff1 & "'", "5")
        'pengecekan apakah sudah di apprv atasan1
        Call GetData_DetaiIzinStaff("select IZIN_TGLAPPVSPV from DATA_IZIN_BODY where IZIN_ID = '" & id_izin & "'", "7")
        'pengecekan apakah sudah di apprv atasan2
        Call GetData_DetaiIzinStaff("select IZIN_TGLAPPVMNG, IZIN_STATUS from DATA_IZIN_BODY where IZIN_ID = '" & id_izin & "'", "8")
        'untuk staff tersebut melihat detail izin nya 
        Call GetData_DetaiIzinStaff("select IZIN_NIK_APPVMNG from DATA_IZIN_HEADER where IZIN_NIK = '" & nik_staff1 & "'", "9")
        'get jumlah pengajuan dari data_izin_detail by id izin
        Call GetData_DetaiIzinStaff("select count (izin_tgldetail) as JMLIZIN  from data_izin_detail where izin_id = '" & id_izin & "'", "15")

        Call GetData_DetaiIzinStaff(" Select * FROM DATA_IZIN_BODY WHERE IZIN_ID = '" & id_izin & "'", "1")
        Call GetData_DetaiIzinStaff(" Select * FROM DATA_IZIN_HEADER WHERE IZIN_NIK = '" & nik_lvdetailizinstaff & "'", "2")
        'tampilkan jml pengajuan tanggal array 
        Call GetData_ListTglIzin("select izin_tgldetail from data_izin_detail where izin_id = '" & id_izin & "'", "1")


        If imagedown <> "" Then
            TxtFileName.Text = imagedown
            Dim FileName As String = imagedown 'It 's a file name displayed on downloaded file on client side.
            'Dim unionname As String = "D:/Herlambang/September-Ongoing - Revisi Input Data Izin (Table)/LiveMUGENASP/MugenASPHRISO_10_22_018/img/imgstaff/" + FileName
            'ImageBuktiSuratSakit.ImageUrl = unionname
            LabelBuktiSuratSakit.Visible = True
            BtnDownloadDetailFile.Visible = True
            'Response.Write("<script>alert('URL: " + unionname + "')</script>")
            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        Else
            LabelBuktiSuratSakit.Visible = False
            BtnDownloadDetailFile.Visible = False
        End If

        'menampilkan data array ke textbox tgl
        If TxtDetailJmlPengajuan.Text = 1 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            divtgl2.Visible = False
            divtgl3.Visible = False
            divtgl4.Visible = False
            divtgl5.Visible = False
            divtgl6.Visible = False
            divtgl7.Visible = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 2 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            divtgl3.Visible = False
            divtgl4.Visible = False
            divtgl5.Visible = False
            divtgl6.Visible = False
            divtgl7.Visible = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 3 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            divtgl4.Visible = False
            divtgl5.Visible = False
            divtgl6.Visible = False
            divtgl7.Visible = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 4 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            divtgl5.Visible = False
            divtgl6.Visible = False
            divtgl7.Visible = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 5 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            divtgl6.Visible = False
            divtgl7.Visible = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 6 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            divtgl7.Visible = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 7 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            TxtDetailTglPengajuan7.Text = Convert.ToDateTime(ListTgl(6)).ToShortDateString
            TxtDetailTglPengajuan7.Enabled = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 8 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            TxtDetailTglPengajuan7.Text = Convert.ToDateTime(ListTgl(6)).ToShortDateString
            TxtDetailTglPengajuan7.Enabled = False
            TxtDetailTglPengajuan8.Text = Convert.ToDateTime(ListTgl(7)).ToShortDateString
            TxtDetailTglPengajuan8.Enabled = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 9 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            TxtDetailTglPengajuan7.Text = Convert.ToDateTime(ListTgl(6)).ToShortDateString
            TxtDetailTglPengajuan7.Enabled = False
            TxtDetailTglPengajuan8.Text = Convert.ToDateTime(ListTgl(7)).ToShortDateString
            TxtDetailTglPengajuan8.Enabled = False
            TxtDetailTglPengajuan9.Text = Convert.ToDateTime(ListTgl(8)).ToShortDateString
            TxtDetailTglPengajuan9.Enabled = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 10 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            TxtDetailTglPengajuan7.Text = Convert.ToDateTime(ListTgl(6)).ToShortDateString
            TxtDetailTglPengajuan7.Enabled = False
            TxtDetailTglPengajuan8.Text = Convert.ToDateTime(ListTgl(7)).ToShortDateString
            TxtDetailTglPengajuan8.Enabled = False
            TxtDetailTglPengajuan9.Text = Convert.ToDateTime(ListTgl(8)).ToShortDateString
            TxtDetailTglPengajuan9.Enabled = False
            TxtDetailTglPengajuan10.Text = Convert.ToDateTime(ListTgl(9)).ToShortDateString
            TxtDetailTglPengajuan10.Enabled = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 11 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            TxtDetailTglPengajuan7.Text = Convert.ToDateTime(ListTgl(6)).ToShortDateString
            TxtDetailTglPengajuan7.Enabled = False
            TxtDetailTglPengajuan8.Text = Convert.ToDateTime(ListTgl(7)).ToShortDateString
            TxtDetailTglPengajuan8.Enabled = False
            TxtDetailTglPengajuan9.Text = Convert.ToDateTime(ListTgl(8)).ToShortDateString
            TxtDetailTglPengajuan9.Enabled = False
            TxtDetailTglPengajuan10.Text = Convert.ToDateTime(ListTgl(9)).ToShortDateString
            TxtDetailTglPengajuan10.Enabled = False
            TxtDetailTglPengajuan11.Text = Convert.ToDateTime(ListTgl(10)).ToShortDateString
            TxtDetailTglPengajuan11.Enabled = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 12 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            TxtDetailTglPengajuan7.Text = Convert.ToDateTime(ListTgl(6)).ToShortDateString
            TxtDetailTglPengajuan7.Enabled = False
            TxtDetailTglPengajuan8.Text = Convert.ToDateTime(ListTgl(7)).ToShortDateString
            TxtDetailTglPengajuan8.Enabled = False
            TxtDetailTglPengajuan9.Text = Convert.ToDateTime(ListTgl(8)).ToShortDateString
            TxtDetailTglPengajuan9.Enabled = False
            TxtDetailTglPengajuan10.Text = Convert.ToDateTime(ListTgl(9)).ToShortDateString
            TxtDetailTglPengajuan10.Enabled = False
            TxtDetailTglPengajuan11.Text = Convert.ToDateTime(ListTgl(10)).ToShortDateString
            TxtDetailTglPengajuan11.Enabled = False
            TxtDetailTglPengajuan12.Text = Convert.ToDateTime(ListTgl(11)).ToShortDateString
            TxtDetailTglPengajuan12.Enabled = False
        End If
        'TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString

        'TxtTglCuti6.Text = ListTgl(5)
        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        'Dim date1 = Convert.ToDateTime(tgldeadline)
        'Dim date2 = DateTime.Now
        'Dim date3 = ((date2 - date1.Date).Days)

        'Response.Write("<script>alert('Selisih Tanggal " + date3 + "!')</script>")
        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        '==============================================
        'Response.Write("<script>alert('Jenis izin : " + txtDetailJenisIzin.Text + "')</script>")
        If txtDetailJenisIzin.Text = "Izin Terlambat" Or txtDetailJenisIzin.Text = "Izin Keluar Kantor" Then
            Call GetData_ListTglIzin("select izin_tgldetail, izin_jamdetail from data_izin_detail where izin_id = '" & id_izin & "'", "2")
            LabelJamPengajuan.Visible = True
            TxtDetailJamPengajuan.Visible = True
            TxtDetailJamPengajuan.Enabled = False
            TxtDetailAlasanPengajuan2.Visible = False
            LabelDetailAlasanPengajuan2.Visible = False

        Else
            LabelAlasanPengajuan.Visible = True
            TxtDetailAlasanPengajuan.Visible = True
            LabelJamPengajuan.Visible = False
            TxtDetailJamPengajuan.Visible = False
            If txtDetailJenisIzin.Text = "Cuti" Then
                TxtDetailAlasanPengajuan2.Visible = False
                LabelDetailAlasanPengajuan2.Visible = False
            Else
                TxtDetailAlasanPengajuan2.Visible = True
                LabelDetailAlasanPengajuan2.Visible = True
            End If

        End If
        '=============================================
        Dim a As Date = Convert.ToDateTime(TxtDetailDeadline.Text)
        Dim daretime As Date = DateTime.Now.AddDays(0).ToShortDateString()
        'Response.Write("<script>alert('Status izin : " + TxtDetailStatusPengajuan.Text + " ')</script>")
        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        If statusizin = "Pending" Or statusizin = "Disetujui Atasan" Then
            TxtDetailAlasanBtlStj.Enabled = True
        Else
            TxtDetailAlasanBtlStj.Enabled = False
        End If
        If daretime > a Then
            Response.Write("<script>alert('Tidak Bisa Melakukan Operasi. Sudah Lewat dari  Deadline')</script>")
            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        ElseIf daretime < a Or daretime = a Then
            'Response.Write("<script>alert('kurang dari atau sama dengan ')</script>")
            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            '=====GOLDEN 
            'cek nik login
            'Response.Write("<script>alert('Nik Login : " + TxtStaffNIKMaster.Text + " dan nik staff 1 : " + nik_staff1 + "')</script>")
            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            statusizin = TxtDetailStatusPengajuan.Text
            If TxtStaffNIKMaster.Text = nik_atasan1 And nameapv2 <> "--" Then
                'Response.Write("<script>alert('Atasan 1 dengan atasan 2 login')</script>")
                'case atasan 1 yg memiliki atasan lagi
                If tglapv1 = "" And statusizin = "Pending" Then 'pending dan di terima atasan
                    BtnSaveDetaildanApproval.Visible = True
                    BtnDeclineDetaildanApproval.Visible = True
                ElseIf statusizin = "Dibatalkan Staff" Or statusizin = "Dibatalkan HRD" Then
                    Response.Write("<script>alert('Data telah di Batalkan Staff atau HRD !')</script>")
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                Else
                    Response.Write("<script>alert('Data Sudah di Setujui / di Batalkan!')</script>")
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                End If
            ElseIf TxtStaffNIKMaster.Text = nik_atasan1 And nameapv2 = "--" Then
                'Response.Write("<script>alert('Atasan 1 tanpa atasan 2 login')</script>")
                'case atasan 1 tanpa atasan 2
                Response.Write("<script>alert('Status Izin : " + statusizin + "')</script>") '===================
                If tglapv1 = "" And statusizin = "Pending" Then
                    BtnSaveDetaildanApproval.Visible = True
                    BtnDeclineDetaildanApproval.Visible = True
                ElseIf statusizin = "Dibatalkan Staff" Or statusizin = "Dibatalkan HRD" Then
                    Response.Write("<script>alert('Data telah di Batalkan Staff atau HRD !')</script>")
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                Else
                    Response.Write("<script>alert('Data Sudah di Setujui / di Batalkan!')</script>")
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                End If
            ElseIf TxtStaffNIKMaster.Text = nik_staff1 Then
                BtnSaveDetaildanApproval.Visible = False
                'Response.Write("<script>alert('Staff login')</script>")
                If nameapv2 <> "--" Then
                    'Response.Write("<script>alert('Staff dengan 2 atasan login')</script>")
                    'untuk case staff dengan 2 atasan
                    If tglapv1 = "" And tglapv2 = "" And statusizin = "Pending" Then
                        Response.Write("<script>alert('Tgl apv 1 dan 2 masih kosong')</script>")
                        BtnDeclineDetaildanApproval.Visible = True
                    ElseIf tglapv1 <> "" And tglapv2 = "" And statusizin = "Disetujui Atasan" Then
                        Response.Write("<script>alert('Tgl apv 2 masih kosong')</script>")
                        BtnDeclineDetaildanApproval.Visible = True
                    ElseIf statusizin = "Dibatalkan Staff" Or statusizin = "Dibatalkan HRD" Then
                        Response.Write("<script>alert('Data telah di Batalkan Staff atau HRD !')</script>")
                        BtnSaveDetaildanApproval.Visible = False
                        BtnDeclineDetaildanApproval.Visible = False
                    Else
                        'Response.Write("<script>alert('Data Izin Anda sudah Di Setujui')</script>")
                        BtnDeclineDetaildanApproval.Visible = False
                    End If
                Else
                    'Response.Write("<script>alert('Staff dengan 1 atasan login: " + statusizin + "')</script>")
                    'untuk case staff dengan 1 atasan
                    Response.Write("<script>alert('Staff dengan 1 atasan login')</script>")
                    If tglapv1 <> "" Or statusizin = "Dibatalkan Manajer" Or statusizin = "Dibatalkan Staff" Or statusizin = "Disetujui Manajer" Then
                        BtnDeclineDetaildanApproval.Visible = False
                    Else
                        BtnDeclineDetaildanApproval.Visible = True
                    End If
                End If
            ElseIf TxtStaffNIKMaster.Text = nik_atasan2 And nameapv2 <> "--" Then
                'Response.Write("<script>alert('Atasan2  login')</script>")
                'Response.Write("<script>alert('Status Izin: " + statusizin + "')</script>")
                If statusizin = "Disetujui Manajer" And txtDetailJenisIzin.Text <> "Cuti" Then
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                    Response.Write("<script>alert('Anda Tidak Memiliki Hak Akses untuk Melihat Data Ini')</script>")
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End If
                'case atasan 2 login
                If tglapv1 <> "" And tglapv2 = "" And statusizin <> "Dibatalkan Manajer" Then 'and status izin apprv atasan 1
                    BtnSaveDetaildanApproval.Visible = True
                    BtnDeclineDetaildanApproval.Visible = True
                ElseIf tglapv1 <> "" And tglapv2 <> "" And statusizin = "Disetujui Manajer" Then
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                    Response.Write("<script>alert('Anda Sudah Approve data Ini')</script>")
                ElseIf statusizin = "Dibatalkan Atasan" Or statusizin = "Dibatalkan Staff" Then
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                    Response.Write("<script>alert('Data ini sudah di batalkan Atasan atasu Staff yang bersangkutan')</script>")
                ElseIf statusizin = "Dibatalkan Manajer" Then
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                    Response.Write("<script>alert('Data ini sudah Anda Batalkan')</script>")
                ElseIf statusizin = "Disetujui Manajer" Then
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                    Response.Write("<script>alert('Data ini sudah Di Setujui Manajer')</script>")
                Else
                    Response.Write("<script>alert('Anda Tidak Bisa Approve data karena atasan dari staff tersebut belum melakukan approval')</script>")
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End If
            Else
                Response.Write("<script>alert('Anda tidak memiliki akses untuk melihat data ini')</script>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            End If
        End If

        '===============================================

        '============================================================================================================================================
        'Response.Write("<script>alert('nik staff " + nik_staff1 + "')</script>")
        '==================REMAKE=======================================

        'hide mv  hrd form izin
        MultiViewHRDFormIzin.ActiveViewIndex = -1
        'hide mv  hrd form izin detail
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        'multiview keseluruhan
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        'multiview header default nama nik jabatan 
        MultiViewAkses.ActiveViewIndex = -1
        'multiview dropdown jenis izin
        MultiViewDDJenisIzin.ActiveViewIndex = -1

        'show data detail dan apprv

        'hide mv detail and apprv
        'MultiViewDetaildanAprrv.ActiveViewIndex = -1
        MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide mv hrd form izin laporan
        MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
        'hide lv lihat list izin
        MultiViewLihatListIzin.ActiveViewIndex = -1


    End Sub

    Public ListTgl As New List(Of String)()
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
                    ListTgl.Add(MyRecReadA("izin_tgldetail").ToString())
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
                GetData_ListTglIzin = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'this code ==
                    ListTgl.Add(MyRecReadA("izin_tgldetail").ToString())
                    TxtDetailJamPengajuan.Text = nSr(MyRecReadA("IZIN_JAMDETAIL"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        End If
    End Function

    Public imagedown As String
    'mengambil value id izin staff ketika di klik detail
    Function GetData_DetaiIzinStaff(ByVal mSqlCommadstring As String, ByVal mPos As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_DetaiIzinStaff = 0

        cnn = New OleDbConnection(strconn)

        If mPos = 1 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'pemanggilan 1 untuk table DATA_IZINDETAIL
                    TxtDetailJmlPengajuan.Enabled = False
                    TxtDetailIdIzin.Text = nSr(MyRecReadA("IZIN_ID"))
                    TxtDetailIdIzin.Enabled = False
                    TxtDetailTglPengajuanIzin.Text = nSr(MyRecReadA("IZIN_TGLPENGAJUAN"))
                    TxtDetailTglPengajuanIzin.Enabled = False
                    txtDetailJenisIzin.Text = nSr(MyRecReadA("IZIN_JENIS"))
                    txtDetailJenisIzin.Enabled = False
                    TxtDetailNik.Text = nSr(MyRecReadA("IZIN_NIK"))
                    TxtDetailNik.Enabled = False
                    nik_lvdetailizinstaff = nSr(MyRecReadA("IZIN_NIK"))
                    If txtDetailJenisIzin.Text = "Cuti" Then
                        TxtDetailAlasanPengajuan.Text = nSr(MyRecReadA("IZIN_ALASAN")) + " / " + nSr(MyRecReadA("IZIN_ALASANDETAIL"))
                        TxtDetailAlasanPengajuan.Enabled = False
                        'TxtDetailAlasanPengajuan2.Text = nSr(MyRecReadA("IZIN_ALASANDETAIL"))
                        TxtDetailAlasanPengajuan2.Visible = False
                        LabelDetailAlasanPengajuan2.Visible = False
                    Else
                        TxtDetailAlasanPengajuan.Text = nSr(MyRecReadA("IZIN_ALASAN"))
                        TxtDetailAlasanPengajuan.Enabled = False
                        TxtDetailAlasanPengajuan2.Text = nSr(MyRecReadA("IZIN_ALASANDETAIL"))
                        TxtDetailAlasanPengajuan2.Enabled = False
                    End If
                    TxtDetailStatusPengajuan.Text = nSr(MyRecReadA("IZIN_STATUS"))
                    TxtDetailStatusPengajuan.Enabled = False
                    TxtDetailDeadline.Text = nSr(MyRecReadA("IZIN_TGLDEADLINE"))
                    TxtDetailDeadline.Enabled = False
                    TxtDetailAlasanBtlStj.Text = nSr(MyRecReadA("IZIN_ALASANBTLSTJ"))
                    'If (MyRecReadA("IZIN_FILEDETAIL") Is DBNull.Value) Then
                    '    ImageBuktiSuratSakit.Attributes("src") = "D:/Herlambang/September-Ongoing - Revisi Input Data Izin (Table)/LiveMUGENASP/MugenASPHRISO_10_22_018/img/imgstaff/"
                    'ElseIf (MyRecReadA("IZIN_FILEDETAIL") IsNot DBNull.Value) Then
                    '    ImageBuktiSuratSakit.Attributes("src") = "D:/Herlambang/September-Ongoing - Revisi Input Data Izin (Table)/LiveMUGENASP/MugenASPHRISO_10_22_018/img/imgstaff/" & nSr(MyRecReadA("IZIN_FILEDETAIL"))
                    'End If
                    imagedown = nSr(MyRecReadA("IZIN_FILEDETAIL"))
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
                    'pemanggilan 2 untuk table DATA_IZIN
                    TxtDetailNama.Text = nSr(MyRecReadA("IZIN_NAMA"))
                    TxtDetailNama.Enabled = False
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 3 Then 'operasi ketika klik detail menu HRD - Table Staff
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'pemanggilan 2 untuk table DATA_IZIN
                    TxtHRDFormIzin_NIK.Text = nSr(MyRecReadA("STAFF_NIK"))
                    TxtHRDFormIzin_NIK.Enabled = False
                    TxtHRDFormIzin_Nama.Text = nSr(MyRecReadA("STAFF_NAMA"))
                    TxtHRDFormIzin_Nama.Enabled = False


                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 4 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    nik_atasan1 = nSr(MyRecReadA("STAFF_ATASAN1"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 5 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    nik_atasan2 = nSr(MyRecReadA("STAFF_ATASAN2"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 6 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    nik_staff1 = nSr(MyRecReadA("IZIN_NIK"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 7 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    tglapv1 = nSr(MyRecReadA("IZIN_TGLAPPVSPV"))
                    'tglapv2 = nSr(MyRecReadA("IZIN_TGL_APPVMNG"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 8 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    tglapv2 = nSr(MyRecReadA("IZIN_TGLAPPVMNG"))
                    statusizin = nSr(MyRecReadA("IZIN_STATUS"))
                    tgldeadline = nSr(MyRecReadA("IZIN_TGLDEADLINE"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 9 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    nameapv2 = nSr(MyRecReadA("IZIN_NIK_APPVMNG"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 10 Then 'menu detail cancel form izin by hrd
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    TxtDetailStaffCancelNIK.Text = nSr(MyRecReadA("IZIN_NIK"))
                    '-skip nama
                    TxtDetailStaffCancelJenisIzin.Text = nSr(MyRecReadA("IZIN_JENIS"))
                    TxtDetailStaffCancelTglPengajuan.Text = nSr(MyRecReadA("IZIN_TGLPENGAJUAN"))
                    txtDetailStaffCancelIzinStatus.Text = nSr(MyRecReadA("IZIN_STATUS"))
                    'TxtDetailStaffCancelJmlPengajuan.Text = nSr(MyRecReadA("IZIN_JMLPENGAJUAN"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 11 Then 'menu detail cancel form izin by hrd (untuk nama)
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    TxtDetailStaffCancelNama.Text = nSr(MyRecReadA("IZIN_NAMA"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 12 Then 'get saldo staff saat ini. (menu hrd - operasi saldo)
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    TxtHRDFormIzin_SaldoStaffSaatIni.Text = nSr(MyRecReadA("IZIN_SALDO")) 'hrd
                    saldo_izinFormIzin = nSr(MyRecReadA("IZIN_SALDO")) 'form izin
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 13 Then 'get nilai deadline tanggal
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    'deadlinetgl = nSr(MyRecReadA("IZIN_TGLDEADLINE"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 14 Then 'get email staff
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    email_staff_btnCuti = nSr(MyRecReadA("STAFF_EMAIL"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        ElseIf mPos = 15 Then 'get jml izintgldetail
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    jml_izin = nSr(MyRecReadA("JMLIZIN"))
                    TxtDetailJmlPengajuan.Text = jml_izin
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                'Call Msg_err(ex.Message)
            End Try
        End If

    End Function

    'Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
    '    MultiViewNilaiStandardEntry.ActiveViewIndex = Convert.ToInt32(DropDownList1.SelectedValue)
    'End Sub

    Protected Sub LbIzin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbIzin.Click
        '==not done yet
        'call method clear di akhir operasi save

        'MultiViewAkses.ActiveViewIndex = 0
        '0=cuti 1=tidak masuk 2=izin datang siang 3=izin pulang cepat
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        MultiViewDDJenisIzin.ActiveViewIndex = -1

        'hide mv  hrd form izin
        MultiViewHRDFormIzin.ActiveViewIndex = -1
        'hide mv  hrd form izin detail
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        'show table lis izin staff 1
        MultiViewTableListIzin.ActiveViewIndex = 0
        'hide mv sub jabatan, nik nama
        'MultiViewAkses.ActiveViewIndex = -1
        'hide mv apprv dan detail
        MultiViewDetaildanAprrv.ActiveViewIndex = -1
        'hide mv detail table staff

        '[hide hrd mv
        MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide mv hrd form izin laporan
        MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
        'hide lv lihat list izin
        MultiViewLihatListIzin.ActiveViewIndex = -1

    End Sub
    Dim saldo_izinFormIzin As Integer
    Protected Sub LblListIzin_Click(sender As Object, e As EventArgs) Handles LblListIzin.Click
        UploadFile.Visible = False
        Label47.Visible = False
        '==not done yet
        Dim dt As String = DateTime.Now.ToString("yyyy")
        DropDownListTidakMasuk.Visible = False
        'call method clear di akhir operasi save
        Call GetData_DetaiIzinStaff("select staff_email from data_staff where staff_nik ='" & TxtStaffNIKMaster.Text & "'", "14")
        TxtEmailStaff.Text = email_staff_btnCuti
        If email_staff_btnCuti = "" Then
            TxtEmailStaff.Enabled = True
        Else
            TxtEmailStaff.Enabled = False
        End If
        If GetData_DetaiIzinStaff("select izin_saldo from data_izin_header where izin_tahun='" & dt & "' and izin_nik = '" & TxtStaffNIKMaster.Text & "'", "12") = 1 And saldo_izinFormIzin <> 0 Then
            TxtSaldoCuti.Text = saldo_izinFormIzin
            TxtSaldoCuti.Enabled = False
        Else
            BtnSaveCuti.Visible = False
            Response.Write("<script>alert('Saldo Izin Anda Kosong. Hubungi HRD untuk input saldo izin tahun ini ')</script>")
            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        End If
        TxtSaldoCuti.Enabled = False
        MultiViewTableListIzin.ActiveViewIndex = -1
        MultiViewDDJenisIzin.ActiveViewIndex = 0
        TextBox1.Text = ""
        TextBox2.Text = ""
        AlertFileGambar.Visible = False

        'hide mv apprv dan detail
        MultiViewDetaildanAprrv.ActiveViewIndex = -1
        'hide mv  hrd form izin
        MultiViewHRDFormIzin.ActiveViewIndex = -1
        'hide mv  hrd form izin detail
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        'hide mv sub jabatan, nik nama
        'MultiViewAkses.ActiveViewIndex = -1

        '[hide hrd mv
        MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide mv hrd form izin laporan
        MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
        'hide lv lihat list izin
        MultiViewLihatListIzin.ActiveViewIndex = -1
    End Sub

    Function GetData_IZIN_STAFF(ByVal mSqlCommadstring As String) As Double 'fungsi untuk menampilkan data ke dalam textbox saat aksi detail di pilij 
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_IZIN_STAFF = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                'NOTE : 9/8/18 
                'BUATKAN TEXTBOX NIK DAN NAMA KETIKA DETAIL IZIN DI TAMPILKAN


                lblNIKDetail.Text = nSr(MyRecReadA("IZIN_NIK"))
                lblNIKDetail.Enabled = False
                lblNamaDetail.Text = nSr(MyRecReadA("IZIN_NAMA"))
                lblNamaDetail.Enabled = False
                'lblStaffNIK.Text = nSr(MyRecReadA("STAFF_NIK"))
                'TxtStaffNIKMaster.Enabled = False

                TxtJenisIzin.Visible = True
                DropDownJenisiIzin.Visible = False
                Dim JnsIzn As String
                JnsIzn = nSr(MyRecReadA("IZIN_JENIS"))
                TxtJenisIzin.Text = JnsIzn

                TxtTglCuti1.Visible = False
                'Dim tglLahir = Convert.ToDateTime(nSr(MyRecReadA("STAFF_LAHIRTGL"))).ToString("dd-MM-yyyy")
                'Dim izin_tgl1 = Convert.ToDateTime(nSr(MyRecReadA("IZIN_TGL1"))).ToString("dd-MM-yyyy")
                'Dim izin_tgl2 = Convert.ToDateTime(nSr(MyRecReadA("IZIN_TGL2"))).ToString("dd-MM-yyyy")
                'TxtStaffLahir.Text = nSr(MyRecReadA("STAFF_LAHIRTMP")) + " / " + tglLahir
                TxtTahunCuti.Text = nSr(MyRecReadA("IZIN_TAHUN_CUTI"))
                DropDownListCuti.Visible = False
                TxtAlasanIzin.Visible = True
                TxtAlasanIzin.Text = nSr(MyRecReadA("IZIN_ALASAN"))

                BtnSaveCuti.Visible = False
                'BtnApprv.Visible = True
                BtnClear.Visible = True

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function


    Protected Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        'Call Clearform()
        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

    End Sub


    '==============FUNGSI MENU HRD=================================================

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
    Protected Sub BtnOperasiSaldo_Click(sender As Object, e As EventArgs) Handles BtnOperasiSaldo.Click
        'show tb staff list 
        MultiViewHRDFormIzin.ActiveViewIndex = 0

        'hide Detail Aprrv
        MultiViewDetaildanAprrv.ActiveViewIndex = -1
        'MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        'hide detail operasi saldo 
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        'hide table list izin apprvd by mng
        MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide dd data izin
        MultiViewDDJenisIzin.ActiveViewIndex = -1
        'hide izin cuti mv
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        'hide btn sub menu hrd
        'MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        'hide detail cancel
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        'hide mv hrd form izin laporan
        MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
        'hide lv lihat list izin
        MultiViewLihatListIzin.ActiveViewIndex = -1
        SaldoIzinSemua.Visible = True
    End Sub
    Protected Sub Btnlaporan_Click(sender As Object, e As EventArgs) Handles Btnlaporan.Click
        'show tb staff list 
        MultiViewHRDFormIzin.ActiveViewIndex = -1

        'hide Detail Aprrv
        MultiViewDetaildanAprrv.ActiveViewIndex = -1
        'hide detail operasi saldo 
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        'hide table list izin apprvd by mng
        'MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide dd data izin
        MultiViewDDJenisIzin.ActiveViewIndex = -1
        'hide izin cuti mv
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        'hide btn sub menu hrd
        'MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        'hide detail cancel
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        'hide mv decline table 
        MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide lv lihat list izin
        MultiViewLihatListIzin.ActiveViewIndex = -1

    End Sub
    Protected Sub BtnPembatalanIzin_Click(sender As Object, e As EventArgs) Handles BtnPembatalanIzin.Click
        'show tb staff list 
        MultiViewHRDFormIzin.ActiveViewIndex = -1

        'hide Detail Aprrv
        MultiViewDetaildanAprrv.ActiveViewIndex = -1
        'hide detail operasi saldo 
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        'hide table list izin apprvd by mng
        'MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide dd data izin
        MultiViewDDJenisIzin.ActiveViewIndex = -1
        'hide izin cuti mv
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        'hide btn sub menu hrd
        'MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        'hide detail cancel
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        'hide mv hrd form izin laporan
        MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
        'hide lv lihat list izin
        MultiViewLihatListIzin.ActiveViewIndex = -1
    End Sub
    Protected Sub BtnDetailStaffHRDCancel_Click(sender As Object, e As EventArgs) Handles BtnDetailStaffHRDCancel.Click

        'get value of saldo izin terkini dari db 
        Call GetData_SaldoCutiStaff("select IZIN_SALDO, izin_tahun from DATA_IZIN_HEADER where IZIN_NIK ='" & TxtDetailStaffCancelNIK.Text & "'")
        'Response.Write("<script>alert('Jenjis Izin: " + TxtDetailStaffCancelJenisIzin.Text + "')</script>")

        If saldo_cutiStaff >= 0 Then
            'Response.Write("<script>alert('Jumlah Saldo Staff : " + saldo_cutiStaff + " dan" + TxtDetailStaffCancelJmlPengajuan.Text + "')</script>")
            If TxtDetailStaffCancelJmlPengajuan.Text <> 0 Then
                Convert.ToInt32(TxtDetailStaffCancelJmlPengajuan.Text)
                Dim final_saldo As String = Convert.ToInt32(saldo_cutiStaff) + Convert.ToInt32(TxtDetailStaffCancelJmlPengajuan.Text)
                'Response.Write("<script>alert('value : " + final_saldo + "')</script>")
                'if jenis izin cuti
                If TxtDetailStaffCancelJenisIzin.Text = "Cuti" Then
                    'Response.Write("<script>alert('Jenis Izin Cuti')</script>")
                    If UpdateData_Server1("update DATA_IZIN_BODY set IZIN_STATUS = 'Dibatalkan HRD' where IZIN_ID = '" & TxtDetailStaffCancelIdIzin.Text & "'", "") = 1 And UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO = '" & final_saldo & "' where IZIN_NIK ='" & TxtDetailStaffCancelNIK.Text & "' and IZIN_TAHUN='" & izinthn & "' ", "") = 1 Then
                        Response.Write("<script>alert('berhasil Membatalkan Izin dengan ID : " + TxtDetailStaffCancelIdIzin.Text + "!')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailStaffCancelNIK.Text & "'", "5") 'get email nama atasan 1 value dan menyimpan ke variabel : staffEmailnotif
                        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailStaffCancelNama.Text + " dengan NIK " + TxtDetailStaffCancelNIK.Text + " dan tanggal Pengajuan " + TxtDetailStaffCancelTglPengajuan.Text + " dengan Id Izin " + TxtDetailStaffCancelIdIzin.Text + " telah di batalkan Oleh HRD <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                    Else
                        Response.Write("<script>alert('Gagal Membatalkan Izin dengan ID : " + TxtDetailStaffCancelIdIzin.Text + "!')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If
                Else
                    'Response.Write("<script>alert('Jenis Izin Bukan Cuti')</script>")
                    If UpdateData_Server1("update DATA_IZIN_BODY set IZIN_STATUS = 'Dibatalkan HRD' where IZIN_ID = '" & TxtDetailStaffCancelIdIzin.Text & "'", "") = 1 Then
                        Response.Write("<script>alert('berhasil Membatalkan Izin dengan ID : " + TxtDetailStaffCancelIdIzin.Text + "!')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailStaffCancelNIK.Text & "'", "5") 'get email nama atasan 1 value dan menyimpan ke variabel : staffEmailnotif
                        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailStaffCancelNama.Text + " dengan NIK " + TxtDetailStaffCancelNIK.Text + " dan tanggal Pengajuan " + TxtDetailStaffCancelTglPengajuan.Text + " dengan Id Izin " + TxtDetailStaffCancelIdIzin.Text + " telah di batalkan Oleh HRD <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                    Else
                        Response.Write("<script>alert('Gagal Membatalkan Izin dengan ID : " + TxtDetailStaffCancelIdIzin.Text + "!')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If
                End If

            Else
                Response.Write("<script>alert('Pembatalan gagal karena jumlah pengajuan 0')</script>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            End If

        Else
            Response.Write("<script>alert('Saldo Izin Staff Kosong! Proses Cancel tidak Berhasil')</script>")
            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        End If


    End Sub
    Protected Sub ListViewHRDFormIzin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewHRDFormIzin.SelectedIndexChanged
        Dim staff_nikHRDFormIzin As String = (ListViewHRDFormIzin.DataKeys(ListViewHRDFormIzin.SelectedIndex).Value.ToString)


        'menampilkan saldo awal tahun
        Call GetData_DetaiIzinStaff(" Select * FROM DATA_STAFF WHERE STAFF_NIK = '" & staff_nikHRDFormIzin & "'", "3")
        'get saldo izin cuti staff saat ini 
        If GetData_DetaiIzinStaff("select izin_saldo from data_izin_header where izin_nik = '" & staff_nikHRDFormIzin & "'and IZIN_TAHUN='" & izinthn & "'", "12") = 1 And saldo_izinFormIzin <> 0 Then
            Response.Write("<script>alert('Saldo Izin Staff tidak kosong.')</script>")
            Label35.Visible = True
            TxtHRDFormIzin_SaldoStaffSaatIni.Visible = True
            TxtHRDFormIzin_SaldoStaffSaatIni.Enabled = False
        Else
            Response.Write("<script>alert('Saldo Izin Staff Kosong di tahun berjalan.! Harap Input Saldo izin staff tahun berjalan jika akan melakukan operasi saldo staff yang lain')</script>")
            TxtHRDFormIzin_SaldoStaffSaatIni.Visible = False
            Label35.Visible = False

        End If
        SaldoIzinSemua.visible = False

        'hide data detail izin staff
        MultiViewDetaildanAprrv.ActiveViewIndex = -1
        'hide drop down menu jenis izin
        MultiViewDDJenisIzin.ActiveViewIndex = -1
        'hide izin cuti detail pengajuan 
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        'hide hrd form izin decline
        MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hoide hrd master
        MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        'hide detail cancel
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        'hide mv hrd form izin laporan
        MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
        'hide lv lihat list izin
        MultiViewLihatListIzin.ActiveViewIndex = -1

    End Sub
    Protected Sub ListViewHRDPembatalanIzin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewHRDPembatalanIzin.SelectedIndexChanged
        Dim staff_IzinIDHRDFormIzinPembatalan As String = (ListViewHRDPembatalanIzin.DataKeys(ListViewHRDPembatalanIzin.SelectedIndex).Value.ToString)
        Response.Write("<script>alert('Id Izin yang di Click : " + staff_IzinIDHRDFormIzinPembatalan + "')</script>")
        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        'show tb staff list 
        MultiViewHRDFormIzin.ActiveViewIndex = -1

        'hide Detail Aprrv
        MultiViewDetaildanAprrv.ActiveViewIndex = -1
        'hide detail operasi saldo 
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        'hide table list izin apprvd by mng
        'MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide dd data izin
        MultiViewDDJenisIzin.ActiveViewIndex = -1
        'hide izin cuti mv
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        'hide btn sub menu hrd
        MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        'hide table cancel data izin staff
        'MultiViewHRDFormIzinDecline.ActiveViewIndex = -1

        'hide mv hrd form izin laporan
        MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
        'hide lv lihat list izin
        MultiViewLihatListIzin.ActiveViewIndex = -1

        'pass the value to detail cancel staff form izin by HRD
        Call GetData_DetaiIzinStaff(" Select IZIN_NIK, IZIN_JENIS, IZIN_TGlPENGAJUAN, IZIN_STATUS FROM DATA_IZIN_BODY WHERE IZIN_ID = '" & staff_IzinIDHRDFormIzinPembatalan & "'", "10")
        Call GetData_DetaiIzinStaff(" Select IZIN_NAMA FROM DATA_IZIN_HEADER WHERE IZIN_NIK = '" & TxtDetailStaffCancelNIK.Text & "'", "11")
        'get jml izin
        Call GetData_DetaiIzinStaff("select count (izin_tgldetail) as JMLIZIN  from data_izin_detail where izin_id = '" & staff_IzinIDHRDFormIzinPembatalan & "'", "15")
        TxtDetailStaffCancelJmlPengajuan.Text = jml_izin
        TxtDetailStaffCancelIdIzin.Text = staff_IzinIDHRDFormIzinPembatalan
        TxtDetailStaffCancelIdIzin.Enabled = False
        TxtDetailStaffCancelNIK.Enabled = False
        TxtDetailStaffCancelNama.Enabled = False
        TxtDetailStaffCancelJenisIzin.Enabled = False
        TxtDetailStaffCancelTglPengajuan.Enabled = False
        txtDetailStaffCancelIzinStatus.Enabled = False

    End Sub
    Protected Sub lblHrdFormIzin_Click(sender As Object, e As EventArgs) Handles lblHrdFormIzin.Click
        If DataDepartemen.Text = "HRD&GA" And TxtStaffNIKMaster.Text = "223" Or TxtStaffNIKMaster.Text = "531" Then 'bisa di tambahkan or dan and untuk spesifik staff yg bisa mengakses menu ini

            MultiViewTableListIzin.ActiveViewIndex = -1
            MultiViewDDJenisIzin.ActiveViewIndex = -1
            'hide mv apprv dan detail
            MultiViewDetaildanAprrv.ActiveViewIndex = -1
            'hide mv izin cuti 
            MultiViewNilaiStandardEntry.ActiveViewIndex = -1
            'hide detail hrd staff form izin
            MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
            'hide keseluruhan form izin dimenu hrd
            MultiViewHRDFormIzin.ActiveViewIndex = -1
            'hide table list izin yg telah di setujui manajer
            MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
            'hide detail cancel
            MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
            'hide mv hrd form izin laporan
            MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
            'hide lv lihat list izin
            MultiViewLihatListIzin.ActiveViewIndex = -1
        Else
            Response.Write("<script>alert('Anda Tidak Memiliki Izin untuk mengakses Menu Ini')</script>")
            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        End If
        'Response.Write("<script>alert('Nik yang login " + DataSubJabatan.Text + "/ " + DataDepartemen.Text + "/" + DataNama.Text + "')</script>")
    End Sub

    Protected Sub BtnSaveHRDFormIzin_Click(sender As Object, e As EventArgs) Handles BtnSaveHRDFormIzin.Click
        ' 1 = input saldo awal tahun, 2=cuti hari raya, 3=cuti besar, 4=pending cuti, 5=hutang cuti
        Dim datesvhrd As Integer = DateTime.Now.ToString("MM")
        Dim thn As Integer = Convert.ToInt32(TxtHRDFormIzinTahun.Text)
        Dim thn_1 As Integer = thn - 1
        Dim val1 As String

        If TxtHRDFormIzin_OperasiSaldo.Text <> "" And TxtHRDFormIzinTahun.Text <> "" Then
            If DDJenisOperasiSaldoCuti.SelectedValue = 1 Then
                'If datesvhrd = "12" Then
                val1 = "Input Saldo Awal tahun"
                GetData_DetaiIzinStaff("select STAFF_ATASAN1 from DATA_STAFF where STAFF_NIK='" & TxtHRDFormIzin_NIK.Text & "'", "4")
                GetData_DetaiIzinStaff("select STAFF_ATASAN2 from DATA_STAFF where STAFF_NIK='" & TxtHRDFormIzin_NIK.Text & "'", "5")
                If nik_atasan1 <> "" Then
                    If nik_atasan1 <> "" And nik_atasan2 = "" Then 'case untuk staff dengan 1 atasan
                        If GetFindRecord_Server("select IZIN_NIK from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "'") = 1 Then
                            Response.Write("<script>alert('Data Ditemukan , memperbarui saldo pada data tersebut')</script>")
                            If GetData_SaldoCutiStaff("select IZIN_SALDO, izin_tahun from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "' and IZIN_TAHUN='" & thn_1 & "'") = 1 Then

                                If datesvhrd <> 0 Then
                                    'insert history di izin_saldo : nominal akhir: nominal saldo berjalan di database
                                    If UpdateData_Server("insert into DATA_IZIN_SALDO (NIK, NOMINAL_AWAL, NOMINAL_AKHIR, TAHUN, KET, TGL) values ('" & TxtHRDFormIzin_NIK.Text & "','" & TxtHRDFormIzin_OperasiSaldo.Text & "','" & saldo_cutiStaff & "','" & thn & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ", "") = 1 Then
                                        Response.Write("<script>alert('Berhasil Insert Data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

                                    Else
                                        Response.Write("<script>alert('Gagal memperbarui data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                    End If
                                End If
                            End If

                            If UpdateData_Server("update DATA_IZIN_HEADER set IZIN_SALDO ='" & TxtHRDFormIzin_OperasiSaldo.Text & "', IZIN_TAHUN='" & TxtHRDFormIzinTahun.Text & "' where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "' ", "") = 1 Then
                                Response.Write("<script>alert('Berhasil Update Data staff dengan 1 atasan')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            Else
                                Response.Write("<script>alert('Gagal memperbarui data saldo izin ')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            End If
                        Else '============================================insert saldo izin
                            Response.Write("<script>alert('Data Tidak di temukan di table data izin, membuat data baru')</script>")
                            If UpdateData_Server("insert into DATA_IZIN_HEADER (IZIN_NIK, IZIN_NAMA, IZIN_SALDO, IZIN_TAHUN, IZIN_NIK_APPVSPV, IZIN_NIK_APPVMNG) values ('" & TxtHRDFormIzin_NIK.Text & "','" & TxtHRDFormIzin_Nama.Text & "','" & TxtHRDFormIzin_OperasiSaldo.Text & "','" & TxtHRDFormIzinTahun.Text & "', '" & nik_atasan1 & "','--') ", "") = 1 Then
                                If datesvhrd <> 0 Then 'history saldo : data_izin_saldo [ketika operasi saldo terjadi di bulan 12 maka otomatis akan masuk ke kondisi dibawah]
                                    'Response.Write("<script>alert('Bulan Desember')</script>")
                                    'nominal awal untuk saldo awal pertahun, nominal akhir hasil kalkulasi dari pengurangan nominal awal -apprv izin
                                    If UpdateData_Server("insert into DATA_IZIN_SALDO (NIK, NOMINAL_AWAL, TAHUN, KET, TGL) values ('" & TxtHRDFormIzin_NIK.Text & "','" & TxtHRDFormIzin_OperasiSaldo.Text & "','" & thn & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ", "") = 1 Then
                                        Response.Write("<script>alert('Berhasil Insert Data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

                                    Else
                                        Response.Write("<script>alert('Gagal memperbarui data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                    End If
                                End If
                                Response.Write("<script>alert('Berhasil input Saldo Izin staff dengan 1 atasan')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            Else
                                Response.Write("<script>alert('Gagal membuat data baru Saldo Cuti Awal Tahun untuk Staff : '" + TxtHRDFormIzin_Nama.Text + "'')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            End If
                        End If
                    ElseIf nik_atasan1 <> "" And nik_atasan2 <> "" Then 'case untuk staff dengan 2 atasan
                        'cek apakah record ini sudah ada, jika iya maka update
                        If GetFindRecord_Server("select IZIN_NIK from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "'") = 1 Then
                            Response.Write("<script>alert('Data Ditemukan ')</script>")
                            If GetData_SaldoCutiStaff("select IZIN_SALDO, izin_tahun from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "' and IZIN_TAHUN='" & thn_1 & "'") = 1 Then

                                If datesvhrd <> 0 Then
                                    'insert history di izin_saldo : nominal akhir: nominal saldo berjalan di database
                                    If UpdateData_Server("insert into DATA_IZIN_SALDO (NIK, NOMINAL_AWAL, NOMINAL_AKHIR, TAHUN, KET, TGL) values ('" & TxtHRDFormIzin_NIK.Text & "','" & TxtHRDFormIzin_OperasiSaldo.Text & "','" & saldo_cutiStaff & "','" & thn & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ", "") = 1 Then
                                        Response.Write("<script>alert('Berhasil Insert Data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

                                    Else
                                        Response.Write("<script>alert('Gagal memperbarui data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                    End If
                                End If
                            End If
                            If UpdateData_Server("update DATA_IZIN_HEADER set IZIN_SALDO ='" & TxtHRDFormIzin_OperasiSaldo.Text & "', IZIN_TAHUN='" & TxtHRDFormIzinTahun.Text & "' where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "' ", "") = 1 Then
                                Response.Write("<script>alert('Berhasil Update Data Saldo Izin staff dengan 2 atasan ')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            Else
                                Response.Write("<script>alert('Gagal Update Data Saldo Izin staff dengan 2 atasan ')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            End If
                        Else '============================================insert saldo izin
                            Response.Write("<script>alert('Data Tidak di temukan di table data izin')</script>")
                            If UpdateData_Server("insert into DATA_IZIN_HEADER (IZIN_NIK, IZIN_NAMA, IZIN_SALDO, IZIN_TAHUN, IZIN_NIK_APPVSPV, IZIN_NIK_APPVMNG) values ('" & TxtHRDFormIzin_NIK.Text & "','" & TxtHRDFormIzin_Nama.Text & "','" & TxtHRDFormIzin_OperasiSaldo.Text & "','" & TxtHRDFormIzinTahun.Text & "','" & nik_atasan1 & "','" & nik_atasan2 & "') ", "") = 1 Then
                                If datesvhrd <> 0 Then 'history saldo : data_izin_saldo [ketika operasi saldo terjadi di bulan 12 maka otomatis akan masuk ke kondisi dibawah]
                                    'Response.Write("<script>alert('Bulan Desember')</script>")

                                    If UpdateData_Server("insert into DATA_IZIN_SALDO (NIK, NOMINAL_AWAL, TAHUN, KET, TGL) values ('" & TxtHRDFormIzin_NIK.Text & "','" & TxtHRDFormIzin_OperasiSaldo.Text & "','" & thn & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ", "") = 1 Then
                                        Response.Write("<script>alert('Berhasil Insert Data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

                                    Else
                                        Response.Write("<script>alert('Gagal memperbarui data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                    End If
                                End If
                                Response.Write("<script>alert('Berhasil input Saldo Izin staff dengan 2 atasan')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            Else
                                Response.Write("<script>alert('Gagal Input Saldo Izin Awal Tahun untuk Staff : '" + TxtHRDFormIzin_Nama.Text + "'')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            End If
                        End If
                    Else
                        Response.Write("<script>alert('Data staff Atasan tidak di temukan')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If
                Else
                    Response.Write("<script>alert('Data Staff tersebut belum Memiliki Atasan')</script>")
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End If
                'input history saldo : tb = data_izin_saldo'


            ElseIf DDJenisOperasiSaldoCuti.SelectedValue = 2 Then
                val1 = "Cuti Hari Raya" 'mengurangi saldo
                'cek apakah record tsb sudah ada di tb data izin
                If GetFindRecord_Server("select IZIN_NIK from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "'") = 1 Then
                    'jika sudah ada, maka update cuti hari raya 
                    'get nilai saldo awal

                    If GetData_SaldoCutiStaff("select IZIN_SALDO, izin_tahun from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "' and IZIN_TAHUN='" & TxtHRDFormIzinTahun.Text & "'") = 1 Then
                        Response.Write("<script>alert('saldo cuti staff : " + saldo_cutiStaff + "')</script>")
                        If saldo_cutiStaff > 0 Then
                            If Convert.ToInt32(TxtHRDFormIzin_OperasiSaldo.Text) > Convert.ToInt32(saldo_cutiStaff) Then
                                'operasi gagal, saldo izin staff tidak kurang dari saldo cuti hari raya
                                Response.Write("<script>alert('operasi gagal, saldo izin staff  kurang dari saldo cuti hari raya ')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            Else
                                'jalankan operasi
                                Dim final_saldo As Integer = saldo_cutiStaff - TxtHRDFormIzin_OperasiSaldo.Text
                                'Convert.ToString(final_saldo)
                                'Response.Write("<script>alert('Saldo Final : " + final_saldo + "')</script>")
                                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                'insert history di izin_saldo
                                If datesvhrd <> 0 Then
                                    'insert history di izin_saldo 
                                    If UpdateData_Server("insert into DATA_IZIN_SALDO (NIK, NOMINAL_AWAL,NOMINAL_AKHIR, TAHUN, KET, TGL) values ('" & TxtHRDFormIzin_NIK.Text & "','" & saldo_cutiStaff & "','" & final_saldo & "','" & thn & "', '" & val1 & "', ,'" & DateTime.Now.ToShortDateString & "') ", "") = 1 Then
                                        Response.Write("<script>alert('Berhasil Insert Data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

                                    Else
                                        Response.Write("<script>alert('Gagal memperbarui data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                    End If
                                End If
                                If UpdateData_Server("update DATA_IZIN_HEADER set IZIN_SALDO ='" & final_saldo & "' where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "' ", "") = 1 Then
                                    Response.Write("<script>alert('Berhasil Update Cuti Hari Raya Data staff ')</script>")
                                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                Else
                                    Response.Write("<script>alert('Gagal Update Cuti Hari Raya Data staff ')</script>")
                                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                End If
                            End If
                        Else
                            'saldo cuti staff 0. operasi tidak dapat di lanjutkan
                            Response.Write("<script>alert('saldo cuti staff 0. operasi tidak dapat di lanjutkan ')</script>")
                            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        End If

                    Else
                        Response.Write("<script>alert('Gagal Mendapatkan Nilai Saldo Izin Staff, Hubungi IT ')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If

                Else 'jika belum, maka harus input saldo awal tahun
                    Response.Write("<script>alert('Data Tidak di Temukan, Harap Input Saldo Awal  Staff Tersebut terlebih dahulu!')</script>")
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End If

                'Response.Write("<script>alert('value DD " + val1 + "')</script>")
                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            ElseIf DDJenisOperasiSaldoCuti.SelectedValue = 3 Then
                val1 = "Cuti Besar" 'menambah saldo izin
                'cek apakah record tsb sudah ada di tb data izin
                If GetFindRecord_Server("select IZIN_NIK from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "'") = 1 Then
                    If GetData_SaldoCutiStaff("select IZIN_SALDO, izin_tahun from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "'") = 1 Then
                        If saldo_cutiStaff >= 0 Then
                            Convert.ToInt32(saldo_cutiStaff)
                            Convert.ToInt32(TxtHRDFormIzin_OperasiSaldo.Text)
                            Dim final_saldo As String = Convert.ToInt32(saldo_cutiStaff) + Convert.ToInt32(TxtHRDFormIzin_OperasiSaldo.Text)
                            'Convert.ToString(final_saldo)
                            If final_saldo < 0 Then
                                Response.Write("<script>alert('Operasi gagal, saldo tidak bisa kurang dari 0')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            Else
                                If datesvhrd <> 0 Then
                                    'insert history di izin_saldo 
                                    If UpdateData_Server("insert into DATA_IZIN_SALDO (NIK, NOMINAL_AWAL,NOMINAL_AKHIR, TAHUN, KET, TGL) values ('" & TxtHRDFormIzin_NIK.Text & "','" & saldo_cutiStaff & "','" & final_saldo & "','" & thn & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ", "") = 1 Then
                                        Response.Write("<script>alert('Berhasil Insert Data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

                                    Else
                                        Response.Write("<script>alert('Gagal memperbarui data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                    End If
                                End If
                                If UpdateData_Server("update DATA_IZIN_HEADER set IZIN_SALDO ='" & final_saldo & "' where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "' ", "") = 1 Then
                                    Response.Write("<script>alert('Berhasil Update Cuti Besar Data staff ')</script>")
                                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                Else
                                    Response.Write("<script>alert('Gagal Update Cuti Besar Data staff, hubungi IT')</script>")
                                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                End If
                            End If
                        Else
                            Response.Write("<script>alert('operasi tidak dapat di lanjutkan, saldo izin staff kurang dari 0 ')</script>")
                            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        End If
                    Else
                        Response.Write("<script>alert('Gagal mendapatkan saldo izin staff')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If
                Else 'jika belum, maka harus input saldo awal tahun
                    Response.Write("<script>alert('Tidak dapat melakukan operasi ini, Harap Input Saldo Awal Cuti Staff Tersebut terlebih dahulu!')</script>")
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End If
                'Response.Write("<script>alert('value DD " + val1 + "')</script>")
                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            ElseIf DDJenisOperasiSaldoCuti.SelectedValue = 4 Then
                val1 = "Pending Cuti" 'menambah saldo izin
                'cek apakah record tsb sudah ada di tb data izin
                If GetFindRecord_Server("select IZIN_NIK from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "'") = 1 Then
                    If GetData_SaldoCutiStaff("select IZIN_SALDO, izin_tahun from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "'") = 1 Then
                        If saldo_cutiStaff >= 0 Then
                            Convert.ToInt32(saldo_cutiStaff)
                            Convert.ToInt32(TxtHRDFormIzin_OperasiSaldo.Text)
                            Dim final_saldo As Integer = Convert.ToInt32(saldo_cutiStaff) + Convert.ToInt32(TxtHRDFormIzin_OperasiSaldo.Text)
                            'Convert.ToString(final_saldo)
                            If final_saldo < 0 Then
                                Response.Write("<script>alert('Operasi gagal, saldo tidak bisa kurang dari 0')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            Else
                                If datesvhrd <> 0 Then
                                    'insert history di izin_saldo 
                                    If UpdateData_Server("insert into DATA_IZIN_SALDO (NIK, NOMINAL_AWAL,NOMINAL_AKHIR, TAHUN, KET, TGL) values ('" & TxtHRDFormIzin_NIK.Text & "','" & saldo_cutiStaff & "','" & final_saldo & "','" & thn & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ", "") = 1 Then
                                        Response.Write("<script>alert('Berhasil Insert Data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

                                    Else
                                        Response.Write("<script>alert('Gagal memperbarui data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                    End If
                                End If
                                If UpdateData_Server("update DATA_IZIN_HEADER set IZIN_SALDO ='" & final_saldo & "' where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "' ", "") = 1 Then
                                    Response.Write("<script>alert('Berhasil Update Pending Cuti Data staff ')</script>")
                                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                Else
                                    Response.Write("<script>alert('Gagal Update Pending Cuti Data staff')</script>")
                                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                End If
                            End If
                        Else
                            Response.Write("<script>alert('operasi tidak dapat di lanjutkan, saldo izin staff kurang dari 0 ')</script>")
                            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        End If
                    Else
                        Response.Write("<script>alert('Gagal mendapatkan saldo izin staff')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If
                Else
                    Response.Write("<script>alert('operasi tidak dapat di lanjutkan, saldo izin staff masih kosong ')</script>")
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End If

                'Response.Write("<script>alert('value DD " + val1 + "')</script>")
                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            ElseIf DDJenisOperasiSaldoCuti.SelectedValue = 5 Then
                val1 = "Hutang Cuti" 'mengurangi saldo izin
                'cek apakah record tsb sudah ada di tb data izin
                If GetFindRecord_Server("select IZIN_NIK from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "'") = 1 Then
                    'jika sudah ada, maka update hutang cuti
                    'get nilai saldo awal
                    If GetData_SaldoCutiStaff("select IZIN_SALDO, izin_tahun from DATA_IZIN_HEADER where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "'") = 1 Then
                        If saldo_cutiStaff > 0 Then
                            Convert.ToInt32(saldo_cutiStaff)
                            Convert.ToInt32(TxtHRDFormIzin_OperasiSaldo.Text)
                            'Response.Write("<script>alert('Jumlah Saldo staff : " + saldo_cutiStaff + " dan saldo utang cuti : " + TxtHRDFormIzin_OperasiSaldo.Text + "')</script>")
                            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            If TxtHRDFormIzin_OperasiSaldo.Text > saldo_cutiStaff Then

                                Response.Write("<script>alert('Operasi gagal, pengurangan hutang cuti tidak bisa melebihi jumlah saldo izin staff')</script>")
                                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                            Else
                                Dim final_saldo As Integer = Convert.ToInt32(saldo_cutiStaff) - Convert.ToInt32(TxtHRDFormIzin_OperasiSaldo.Text)
                                'Convert.ToString(final_saldo)
                                If datesvhrd <> 0 Then
                                    'insert history di izin_saldo 
                                    If UpdateData_Server("insert into DATA_IZIN_SALDO (NIK, NOMINAL_AWAL,NOMINAL_AKHIR, TAHUN, KET, TGL) values ('" & TxtHRDFormIzin_NIK.Text & "','" & saldo_cutiStaff & "','" & final_saldo & "','" & thn & "', '" & val1 & "','" & DateTime.Now.ToShortDateString & "') ", "") = 1 Then
                                        Response.Write("<script>alert('Berhasil Insert Data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

                                    Else
                                        Response.Write("<script>alert('Gagal memperbarui data History Saldo ')</script>")
                                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                    End If
                                End If
                                If UpdateData_Server("update DATA_IZIN_HEADER set IZIN_SALDO ='" & final_saldo & "' where IZIN_NIK = '" & TxtHRDFormIzin_NIK.Text & "' ", "") = 1 Then
                                    Response.Write("<script>alert('Berhasil Update Hutang Cuti Data staff ')</script>")
                                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                Else
                                    Response.Write("<script>alert('Gagal Update Hutang Cuti Data staff')</script>")
                                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                                End If
                            End If
                        Else
                            'saldo cuti staff 0. operasi tidak dapat di lanjutkan
                            Response.Write("<script>alert('saldo izin staff 0. operasi tidak dapat di lanjutkan ')</script>")
                            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        End If

                    Else
                        Response.Write("<script>alert('Gagal Mendapatkan Nilai Saldo Awal Staff, Hubungi IT ')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If
                Else
                    Response.Write("<script>alert('operasi tidak dapat di lanjutkan, saldo izin staff masih kosong ')</script>")
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End If
            End If
        Else
            Response.Write("<script>alert('Nominal tidak boleh Kosong!')</script>")
            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        End If
        'Dim var1 As String =
        'Response.Write("<script>alert('Nik yang login " + DataSubJabatan.Text + "')</script>")
    End Sub
    '============ FUNGSI MENU APPROVAL============================================================================
    Public saldo_cutiStaff As String
    Public saldo_tahun As String
    Function GetData_SaldoCutiStaff(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        GetData_SaldoCutiStaff = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                saldo_cutiStaff = nSr(MyRecReadA("IZIN_SALDO"))
                saldo_tahun = nSr(MyRecReadA("IZIN_TAHUN"))
            End If
            MyRecReadA.Close()
            GetData_SaldoCutiStaff = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function
    Function UpdateData_Server1(ByVal mSqlCommadstring As String, ByVal mPos As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        UpdateData_Server1 = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_Server1 = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call ErrorIsi(mPos, ex.Message)
        End Try
    End Function


    Public spv, mng As String
    Function GetData_Appv(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        GetData_Appv = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                spv = nSr(MyRecReadA("IZIN_NIK_APPVSPV"))
                mng = nSr(MyRecReadA("IZIN_NIK_APPVMNG"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function
    'Public deadlinetgl As Date
    Public izinthn As String = DateTime.Now.ToString("yyyy")
    Protected Sub BtnSaveDetaildanApproval_Click(sender As Object, e As EventArgs) Handles BtnSaveDetaildanApproval.Click
        'get the date deadline and compare to date now find the different of days and month
        Call GetData_DetaiIzinStaff("select IZIN_TGLDEADLINE from DATA_IZINDETAIL where IZIN_ID =  '" & TxtDetailNik.Text & "'", "13")

        If txtDetailJenisIzin.Text = "Cuti" Then
            'get spv nik dan mng nik dari staff tsb
            Call GetData_Appv("select IZIN_NIK_APPVSPV, IZIN_NIK_APPVMNG from data_izin_header where izin_nik = '" & TxtDetailNik.Text & "'")
            'get nilai field saldo cuti 
            Call GetData_SaldoCutiStaff("select IZIN_SALDO, izin_tahun from DATA_IZIN_HEADER where IZIN_NIK ='" & TxtDetailNik.Text & "'")
            'cek nik login  apakah sama dengan atasan 1 dan 2 dari staff tersebut + cek apakah date time skrg < daet time deadline
            'Response.Write("<script>alert('spv :" + spv + " === mng: " + mng + "')</script>")
            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            'Response.Write("<script>alert('Jenis Izin Staff : Cuti')</script>")
            'Response.Write("<script>alert('SPV" + spv + " MNG" + mng + "')</script>")
            If spv = TxtStaffNIKMaster.Text And mng <> "" And mng <> "--" Then 'kondisi spv dengan 2 atasan
                Response.Write("<script>alert('staff dengan 2 atasan')</script>")
                Call UpdateData_Server1("update DATA_IZIN_BODY set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Atasan', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "' ", "")
                '==email notif ke atasan2 untuk approval
                Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & mng & "'", "5") 'get email nama atasan 1 value dan menyimpan ke variabel : staffEmailnotif
                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzin.Text + " telah di Approve oleh " + TxtStaffNama.Text + " sebagai atasan langsung dari staff tersebut. Anda di persilahkan untuk melakukan Aprroval sekarang <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            ElseIf spv = TxtStaffNIKMaster.Text And mng = "--" Then 'kondisi spv dengan 1 atasan
                Response.Write("<script>alert('spv : staff dengan 1 atasan saja ')</script>")
                'Response.Write("<script>alert('Jml Saldo :" + saldo_cutiStaff + " == JML pengajuan :" + TxtDetailJmlPengajuan.Text + " ')</script>")
                If saldo_cutiStaff <> "" Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                    If Convert.ToInt32(saldo_cutiStaff) <= Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                        Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin staff')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    Else
                        saldo_cutiStaff = saldo_cutiStaff - TxtDetailJmlPengajuan.Text
                        Call UpdateData_Server1("update DATA_IZIN_BODY set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "' ", "")
                        'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                        Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                        '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                        Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama staff  value dan menyimpan ke variabel : staffEmailnotif
                        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzin.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                        Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If

                Else
                    Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End If
                '============================
                'Call UpdateData_Server1("update DATA_IZINDETAIL set IZIN_TGL_APPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Atasan' where IZIN_NIK = '" & TxtDetailNik.Text & "' ", "")
                ''fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                'Call UpdateData_Server1("update DATA_IZIN set IZIN_SALDO_CUTI ='" + TxtDetailJmlPengajuan.Text + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' ", "")
                ''==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                'Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama staff  value dan menyimpan ke variabel : staffEmailnotif
                'Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzin.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk melakukan Approval</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                'Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            ElseIf mng = TxtStaffNIKMaster.Text Then '(Login dengan user atasan2)
                'Response.Write("<script>alert('Manager berhasil login   " + TxtStaffNama.Text + "')</script>")
                If saldo_cutiStaff <> "" Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                    If Convert.ToInt32(saldo_cutiStaff) <= Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                        Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin staff')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    Else
                        saldo_cutiStaff = saldo_cutiStaff - TxtDetailJmlPengajuan.Text
                        Call UpdateData_Server1("update DATA_IZIN_BODY set IZIN_TGLAPPVMNG = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "' ", "")
                        'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                        Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                        'email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                        Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama staff  value dan menyimpan ke variabel : staffEmailnotif
                        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzin.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                        Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If
                Else
                    Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End If
                '=======================
                'Call UpdateData_Server1("update DATA_IZINDETAIL set IZIN_TGL_APPVMNG = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer' where IZIN_NIK = '" & TxtDetailNik.Text & "' ", "")
                ''fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng

                'Call UpdateData_Server1("update DATA_IZIN set IZIN_SALDO_CUTI ='" + TxtDetailJmlPengajuan.Text + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' ", "")
                ''email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                'Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama staff  value dan menyimpan ke variabel : staffEmailnotif
                'Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzin.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk melakukan Approval</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                'Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            End If
            '***************************End of Apprvl Cuti **********************************************************************
        ElseIf txtDetailJenisIzin.Text = "Tidak Masuk Kantor" Then
            If TxtDetailAlasanPengajuan.Text = "Izin Potong Cuti" Or TxtDetailAlasanPengajuan.Text = "Sakit Potong Cuti" Then 'akan mengurangi saldo izin
                'get spv nik dan mng nik dari staff tsb
                Call GetData_Appv("select IZIN_NIK_APPVSPV, IZIN_NIK_APPVMNG from data_izin_header where izin_nik = '" & TxtDetailNik.Text & "'")
                'get nilai field saldo cuti 
                Call GetData_SaldoCutiStaff("select IZIN_SALDO, izin_tahun from DATA_IZIN_HEADER where IZIN_NIK ='" & TxtDetailNik.Text & "'")
                'cek nik login  apakah sama dengan atasan 1 dan 2 dari staff tersebut + cek apakah date time skrg < daet time deadline
                'Response.Write("<script>alert('spv :" + spv + " === mng: " + mng + "')</script>")
                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

                'If spv = TxtStaffNIKMaster.Text And mng <> "" And mng <> "--" Then 'kondisi spv dengan 2 atasan
                ''Response.Write("<script>alert('staff dengan 2 atasan')</script>")
                'Call UpdateData_Server1("update DATA_IZIN_BODY set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Atasan' , IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "' ", "")
                ''==email notif ke atasan2 untuk approval
                'Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & mng & "'", "5") 'get email nama atasan 1 value dan menyimpan ke variabel : staffEmailnotif
                'Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzin.Text + " telah di Approve oleh " + TxtStaffNama.Text + " sebagai atasan langsung dari staff tersebut. Anda di persilahkan untuk melakukan Aprroval sekarang <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                'Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                ''Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                'ElseIf spv = TxtStaffNIKMaster.Text And mng = "--" Then 'kondisi spv dengan 1 atasan
                'Response.Write("<script>alert('spv : staff dengan 1 atasan saja ')</script>")
                'Response.Write("<script>alert('Jml Saldo :" + saldo_cutiStaff + " == JML pengajuan :" + TxtDetailJmlPengajuan.Text + " ')</script>")
                If saldo_cutiStaff <> "" Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                        If Convert.ToInt32(saldo_cutiStaff) <= Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                            Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin staff')</script>")
                            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        Else
                            saldo_cutiStaff = saldo_cutiStaff - TxtDetailJmlPengajuan.Text
                            Call UpdateData_Server1("update DATA_IZIN_BODY set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer' , IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "' ", "")
                            'If DropDownListTidakMasuk.Text = "Izin Potong Cuti" Or DropDownListTidakMasuk.Text = "Sakit Potong Cuti" Then
                            'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                            Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                            'End If
                            '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                            Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama staff  value dan menyimpan ke variabel : staffEmailnotif
                            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzin.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                            Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        End If

                    Else
                        Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If
                    '============================

                    'ElseIf mng = TxtStaffNIKMaster.Text Then '(Login dengan user atasan2)
                    ''Response.Write("<script>alert('Manager berhasil login   " + TxtStaffNama.Text + "')</script>")
                    'If saldo_cutiStaff <> "" Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                    '    If Convert.ToInt32(saldo_cutiStaff) <= Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                    '        Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin staff')</script>")
                    '        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    '    Else
                    '        saldo_cutiStaff = saldo_cutiStaff - TxtDetailJmlPengajuan.Text
                    '        Call UpdateData_Server1("update DATA_IZIN_BODY set IZIN_TGLAPPVMNG = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer' , IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "' ", "")
                    '        'If DropDownListTidakMasuk.Text = "Izin Potong Cuti" Or DropDownListTidakMasuk.Text = "Sakit Potong Cuti" Then
                    '        'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                    '        Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                    '        'End If
                    '        'email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                    '        Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama staff  value dan menyimpan ke variabel : staffEmailnotif
                    '        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzin.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                    '        Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                    '        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    '    End If
                    'Else
                    '    Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                    '    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    'End If
                    ''=======================

                    'End If
                Else '[tidak masuk kantor]tidak mengurangi saldo izin**************************************************
                'get spv nik dan mng nik dari staff tsb
                Call GetData_Appv("select IZIN_NIK_APPVSPV, IZIN_NIK_APPVMNG from data_izin_header where izin_nik = '" & TxtDetailNik.Text & "'")
                'get nilai field saldo cuti 
                Call GetData_SaldoCutiStaff("select IZIN_SALDO, izin_tahun from DATA_IZIN_HEADER where IZIN_NIK ='" & TxtDetailNik.Text & "'")
                'cek nik login  apakah sama dengan atasan 1 dan 2 dari staff tersebut + cek apakah date time skrg < daet time deadline
                'Response.Write("<script>alert('spv :" + spv + " === mng: " + mng + "')</script>")
                'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

                'If spv = TxtStaffNIKMaster.Text And mng <> "" And mng <> "--" Then 'kondisi spv dengan 2 atasan
                ''Response.Write("<script>alert('staff dengan 2 atasan')</script>")
                'Call UpdateData_Server1("update DATA_IZIN_BODY set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Atasan', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "' ", "")
                ''==email notif ke atasan2 untuk approval
                'Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & mng & "'", "5") 'get email nama atasan 1 value dan menyimpan ke variabel : staffEmailnotif
                'Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzin.Text + " telah di Approve oleh " + TxtStaffNama.Text + " sebagai atasan langsung dari staff tersebut. Anda di persilahkan untuk melakukan Aprroval sekarang <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                'Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                ''Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                'ElseIf spv = TxtStaffNIKMaster.Text And mng = "--" Then 'kondisi spv dengan 1 atasan
                'Response.Write("<script>alert('spv : staff dengan 1 atasan saja ')</script>")
                'Response.Write("<script>alert('Jml Saldo :" + saldo_cutiStaff + " == JML pengajuan :" + TxtDetailJmlPengajuan.Text + " ')</script>")
                If saldo_cutiStaff <> "" Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                        If Convert.ToInt32(saldo_cutiStaff) <= Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                            Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin staff')</script>")
                            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        Else
                            saldo_cutiStaff = saldo_cutiStaff - TxtDetailJmlPengajuan.Text
                            Call UpdateData_Server1("update DATA_IZIN_BODY set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "' ", "")
                            'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                            'Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                            '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                            Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama staff  value dan menyimpan ke variabel : staffEmailnotif
                            Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzin.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                            Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        End If

                    Else
                        Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If
                    '============================

                    'ElseIf mng = TxtStaffNIKMaster.Text Then '(Login dengan user atasan2)
                    ''Response.Write("<script>alert('Manager berhasil login   " + TxtStaffNama.Text + "')</script>")
                    'If saldo_cutiStaff <> "" Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                    '    If Convert.ToInt32(saldo_cutiStaff) <= Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                    '        Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin staff')</script>")
                    '        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    '    Else
                    '        saldo_cutiStaff = saldo_cutiStaff - TxtDetailJmlPengajuan.Text
                    '        Call UpdateData_Server1("update DATA_IZIN_BODY set IZIN_TGLAPPVMNG = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "' ", "")
                    '        'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                    '        'Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                    '        'email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                    '        Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama staff  value dan menyimpan ke variabel : staffEmailnotif
                    '        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzin.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                    '        Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                    '        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    '    End If
                    'Else
                    '    Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                    '    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    'End If
                    ''=======================

                    'End If
                End If
        ElseIf txtDetailJenisIzin.Text = "Izin Keluar Kantor" Or txtDetailJenisIzin.Text = "Izin Terlambat" Then
            'get spv nik dan mng nik dari staff tsb
            Call GetData_Appv("select IZIN_NIK_APPVSPV, IZIN_NIK_APPVMNG from data_izin_header where izin_nik = '" & TxtDetailNik.Text & "'")
            'get nilai field saldo cuti 
            Call GetData_SaldoCutiStaff("select IZIN_SALDO, izin_tahun from DATA_IZIN_HEADER where IZIN_NIK ='" & TxtDetailNik.Text & "'")
            'cek nik login  apakah sama dengan atasan 1 dan 2 dari staff tersebut + cek apakah date time skrg < daet time deadline
            'Response.Write("<script>alert('spv :" + spv + " === mng: " + mng + "')</script>")
            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

            'If spv = TxtStaffNIKMaster.Text And mng <> "" And mng <> "--" Then 'kondisi spv dengan 2 atasan
            ''Response.Write("<script>alert('staff dengan 2 atasan')</script>")
            'Call UpdateData_Server1("update DATA_IZIN_BODY set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Atasan', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "' ", "")
            ''==email notif ke atasan2 untuk approval
            'Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & mng & "'", "5") 'get email nama atasan 1 value dan menyimpan ke variabel : staffEmailnotif
            'Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzin.Text + " telah di Approve oleh " + TxtStaffNama.Text + " sebagai atasan langsung dari staff tersebut. Anda di persilahkan untuk melakukan Aprroval sekarang <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
            'Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
            ''Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            'ElseIf spv = TxtStaffNIKMaster.Text And mng = "--" Then 'kondisi spv dengan 1 atasan
            'Response.Write("<script>alert('spv : staff dengan 1 atasan saja ')</script>")
            'Response.Write("<script>alert('Jml Saldo :" + saldo_cutiStaff + " == JML pengajuan :" + TxtDetailJmlPengajuan.Text + " ')</script>")
            If saldo_cutiStaff <> "" Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                    If Convert.ToInt32(saldo_cutiStaff) <= Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                        Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin staff')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    Else
                        saldo_cutiStaff = saldo_cutiStaff - TxtDetailJmlPengajuan.Text
                        Call UpdateData_Server1("update DATA_IZIN_BODY set IZIN_TGLAPPVSPV = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "' ", "")
                        'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                        'Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                        '==email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                        Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama staff  value dan menyimpan ke variabel : staffEmailnotif
                        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzin.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                        Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If

                Else
                    Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End If
                '============================
                'ElseIf mng = TxtStaffNIKMaster.Text Then '(Login dengan user atasan2)
                ''Response.Write("<script>alert('Manager berhasil login   " + TxtStaffNama.Text + "')</script>")
                'If saldo_cutiStaff <> "" Then 'buat pengecekan saldo izin <=jml pengajuan maka gagal acc
                '    If Convert.ToInt32(saldo_cutiStaff) <= Convert.ToInt32(TxtDetailJmlPengajuan.Text) Then
                '        Response.Write("<script>alert('Gagal melakukan Approval, jumlah pengajuan lebih dari jumlah saldo izin staff')</script>")
                '        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                '    Else
                '        saldo_cutiStaff = saldo_cutiStaff - TxtDetailJmlPengajuan.Text
                '        Call UpdateData_Server1("update DATA_IZIN_BODY set IZIN_TGLAPPVMNG = '" + DateTime.Now + "', IZIN_STATUS ='Disetujui Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "' ", "")
                '        'fungsi update nominal saldo cuti ketika satu pengajuan telah di acc mng
                '        'Call UpdateData_Server1("update DATA_IZIN_HEADER set IZIN_SALDO ='" + saldo_cutiStaff + "' where IZIN_NIK = '" + TxtDetailNik.Text + "' and IZIN_TAHUN='" & izinthn & "' ", "")
                '        'email notification ke staff kalo sudah di setujui oleh atasan langsung dan pengajuan nya di setujui
                '        Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama staff  value dan menyimpan ke variabel : staffEmailnotif
                '        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Selamat , pengajuan Izin dengan  tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dan Id Izin " + TxtDetailIdIzin.Text + " dengan Jenis Izin " + txtDetailJenisIzin.Text + "  Telah di Terima. Silahkan hubungi HRD untuk pengajuan pembatalan<br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                '        Response.Write("<script>alert('Berhasil approve izin dengan id  " + TxtDetailIdIzin.Text + "')</script>")
                '        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                '    End If
                'Else
                '    Response.Write("<script>alert('Gagal melakukan Approval, saldo izin kosong')</script>")
                '    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                'End If
                ''=======================

                'End If
            End If
        '==========
        'MultiViewAkses.ActiveViewIndex = 0
        '0=cuti 1=tidak masuk 2=izin datang siang 3=izin pulang cepat
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        MultiViewDDJenisIzin.ActiveViewIndex = -1

        'hide mv  hrd form izin
        MultiViewHRDFormIzin.ActiveViewIndex = -1
        'hide mv  hrd form izin detail
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        'show table lis izin staff 1
        MultiViewTableListIzin.ActiveViewIndex = 0
        'hide mv sub jabatan, nik nama
        'MultiViewAkses.ActiveViewIndex = -1
        'hide mv apprv dan detail
        MultiViewDetaildanAprrv.ActiveViewIndex = -1
        'hide mv detail table staff

        '[hide hrd mv
        MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide mv hrd form izin laporan
        MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
        'hide lv lihat list izin
        MultiViewLihatListIzin.ActiveViewIndex = -1
    End Sub

    'fungsi cek eksistensi tgl apv1 dan tglapv2
    ''===============DECLINE DATA
    ' nik_staff1 = nik staff yg bersangkutan - nik_atasan1 = nik spv - nik_atasan2 = nik mng
    Protected Sub BtnDeclineDetaildanApproval_Click(sender As Object, e As EventArgs) Handles BtnDeclineDetaildanApproval.Click
        Dim idDecline As String = TxtDetailIdIzin.Text
        '=======DATA IZIN TIDAK DI HAPUS. HANYA DI FLAG BAHWA IZIN TSB DI CANCEL OLEH SPV ATAU MANAGER ATAU HRD DENGAN NOTIF EMAIL
        'mencocokan user yg bisa mengakses hanya atasan 1 dan 2 dari staff tersebut 
        Call GetData_DetaiIzinStaff("select IZIN_NIK from DATA_IZIN_BODY where IZIN_ID = '" & idDecline & "'", "6")
        Call GetData_DetaiIzinStaff("select STAFF_ATASAN1 from DATA_STAFF where STAFF_NIK = '" & nik_staff1 & "'", "4")
        Call GetData_DetaiIzinStaff("select STAFF_ATASAN2 from DATA_STAFF where STAFF_NIK = '" & nik_staff1 & "'", "5")
        'pengecekan apakah sudah di atasan1 by tgl apv
        Call GetData_DetaiIzinStaff("select IZIN_TGLAPPVSPV from DATA_IZIN_BODY where IZIN_ID = '" & idDecline & "'", "7")
        'pengecekan apakah sudah di atasan2 by tgl apv
        Call GetData_DetaiIzinStaff("select IZIN_TGLAPPVMNG, IZIN_STATUS from DATA_IZIN_BODY where IZIN_ID = '" & idDecline & "'", "8")
        'get nameapv2
        Call GetData_DetaiIzinStaff("select IZIN_NIK_APPVMNG from DATA_IZIN_HEADER where IZIN_NIK = '" & nik_staff1 & "'", "9")
        'get saldo awal staff
        Call GetData_SaldoCutiStaff("select IZIN_SALDO, izin_tahun from DATA_IZIN_HEADER where IZIN_NIK ='" + TxtDetailNik.Text + "'")
        'Response.Write("<script>alert('nik staff1:" + nik_staff1 + " == nameapv2:" + nameapv2 + " == tglapv1:" + tglapv1 + " == tglapv2:" + tglapv2 + " nik atasan 1:" + nik_atasan1 + " dan 2 :" + nik_atasan2 + " ')</script>")
        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

        If TxtDetailAlasanBtlStj.Text <> "" Then
            If TxtStaffNIKMaster.Text = nik_staff1 Then 'untuk case staff yg login
                If nameapv2 = "--" And tglapv1 = "" Then 'untuk case staff dengan 1 atasan
                    'Response.Write("<script>alert('Staff dengan 1 atasan')</script>")
                    If saldo_cutiStaff >= 0 Then
                        saldo_cutiStaff = Convert.ToInt32(saldo_cutiStaff) + Convert.ToInt32(TxtDetailJmlPengajuan.Text)
                        Call UpdateData_ServerCancel("update DATA_IZIN_BODY set IZIN_STATUS ='Dibatalkan Staff', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "'")
                        'Call UpdateData_ServerCancel("update DATA_IZIN set IZIN_SALDO_CUTI ='" & saldo_cutiStaff & "' where IZIN_NIK ='" & TxtDetailNik.Text & "'")
                        Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama atasan 1 value dan menyimpan ke variabel : staffEmailnotif
                        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzin.Text + " telah di batalkan Staff yang Bersangkutan <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                        Response.Write("<script>alert('Anda Berhasil Membatalkan Pengajuan Izin staff dengan Nik : " + nik_staff1 + " dan Id Izin : " + TxtDetailIdIzin.Text + " ')</script>")
                        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    Else
                        Response.Write("<script>alert('Saldo Cuti anda kurang dari 0')</script>")
                    End If
                ElseIf nameapv2 <> "--" And tglapv1 = "" Or tglapv2 = "" Then 'untuk case staff dengan 2 atasan (special : tidak update saldo cuti karena blm di kurangi saldo cuti awal nya )
                    Call UpdateData_ServerCancel("update DATA_IZIN_BODY set IZIN_STATUS ='Dibatalkan Staff', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "'")
                    Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama atasan 1 value dan menyimpan ke variabel : staffEmailnotif
                    Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzin.Text + " telah di batalkan Staff yang Bersangkutan <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                    Response.Write("<script>alert('Anda Berhasil Membatalkan Pengajuan Izin staff dengan Nik : " + nik_staff1 + " dan Id Izin : " + TxtDetailIdIzin.Text + " ')</script>")
                    'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                Else
                    Response.Write("<script>alert('Anda tidak di Izinkan melakukan Pembatalan')</script>")
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End If
            ElseIf TxtStaffNIKMaster.Text = nik_atasan1 Then 'untuk case spv yg login
                If nameapv2 = "--" Then 'untuk case spv yg membatalkan staff dengan hanya 1 atasan (langsung update )
                    If saldo_cutiStaff >= 0 Then

                        Call UpdateData_ServerCancel("update DATA_IZIN_BODY set IZIN_STATUS ='Dibatalkan Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "'")
                        Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama atasan 1 value dan menyimpan ke variabel : staffEmailnotif
                        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzin.Text + " telah di batalkan Manajer anda <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                        'cek tgl aprv 1 kosong / tidak. kalo kosong maka jangan update saldo cuti 
                        'If tglapv1 = "" And statusizin = "Pending" Then 'dan izin status pending
                        '    'get sum of saldo staff then update saldo staff
                        '    'saldo_cutiStaff = Convert.ToInt32(saldo_cutiStaff) + Convert.ToInt32(TxtDetailJmlPengajuan.Text)
                        '    'Call UpdateData_ServerCancel("update DATA_IZIN set IZIN_SALDO_CUTI ='" & saldo_cutiStaff & "' where IZIN_NIK ='" & TxtDetailNik.Text & "'")
                        'Else
                        '    Response.Write("<script>alert('Pembatalan Gagal')</script>")
                        '    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                        'End If
                        'alert dialog
                        'Response.Write("<script>alert('Anda Berhasil Membatalkan Pengajuan Izin staff dengan Nik : " + nik_staff1 + " dan Id Izin : " + TxtDetailIdIzin.Text + " ')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    Else
                        Response.Write("<script>alert('Saldo Cuti anda Kurang dari 0')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If

                Else 'untuk case spv  dengan 2 atasan
                    If saldo_cutiStaff >= 0 Then
                        'update status di batalkan atasan
                        Call UpdateData_ServerCancel("update DATA_IZIN_BODY set IZIN_STATUS ='Dibatalkan Atasan', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "'")
                        Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama atasan 1 value dan menyimpan ke variabel : staffEmailnotif
                        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzin.Text + " telah di batalkan Atasan anda <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                        'Response.Write("<script>alert('Anda Berhasil Membatalkan Pengajuan Izin staff dengan Nik : " + nik_staff1 + " dan Id Izin : " + TxtDetailIdIzin.Text + " ')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    Else
                        Response.Write("<script>alert('Saldo Cuti anda Kurang dari 0')</script>")
                        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                    End If
                End If
            ElseIf TxtStaffNIKMaster.Text = nik_atasan2 Then 'untuk case atasan2 staff (langsung operasi saldo cuti staff)
                Call UpdateData_ServerCancel("update DATA_IZIN_BODY set IZIN_STATUS ='Dibatalkan Manajer', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "'")
                Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama atasan 1 value dan menyimpan ke variabel : staffEmailnotif
                Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzin.Text + " telah di batalkan Manajer anda <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
                'get sum of saldo staff then update saldo staff
                'saldo_cutiStaff = Convert.ToInt32(saldo_cutiStaff) + Convert.ToInt32(TxtDetailJmlPengajuan.Text)
                'Call UpdateData_ServerCancel("update DATA_IZIN set IZIN_SALDO_CUTI ='" & saldo_cutiStaff & "' where IZIN_NIK ='" & TxtDetailNik.Text & "'")
                'alert dialog
                'Response.Write("<script>alert('Anda Berhasil Membatalkan Pengajuan Izin staff dengan Nik : " + nik_staff1 + " dan Id Izin : " + TxtDetailIdIzin.Text + " ')</script>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            Else
                Response.Write("<script>alert('Anda tidak Memiliki Akses untuk menghapus data!')</script>")
            End If
        Else
            Response.Write("<script>alert('Alasan Pembatalan Tidak Boleh Kosong!')</script>")
            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        End If

        '==========
        'MultiViewAkses.ActiveViewIndex = 0
        '0=cuti 1=tidak masuk 2=izin datang siang 3=izin pulang cepat
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        MultiViewDDJenisIzin.ActiveViewIndex = -1

        'hide mv  hrd form izin
        MultiViewHRDFormIzin.ActiveViewIndex = -1
        'hide mv  hrd form izin detail
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        'show table lis izin staff 1
        MultiViewTableListIzin.ActiveViewIndex = 0
        'hide mv sub jabatan, nik nama
        'MultiViewAkses.ActiveViewIndex = -1
        'hide mv apprv dan detail
        MultiViewDetaildanAprrv.ActiveViewIndex = -1
        'hide mv detail table staff

        '[hide hrd mv
        MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide mv hrd form izin laporan
        MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
        'hide lv lihat list izin
        MultiViewLihatListIzin.ActiveViewIndex = -1
    End Sub


    '============test check box
    '    Protected Sub BtnGetChkValue_Click(sender As Object, e As EventArgs) Handles BtnGetChkValue.Click
    '        'For Each item As ListViewItem In ListViewHRDFormIzin.Items
    '        '    Dim ck As CheckBox = DirectCast(item.FindControl("CheckBox1"), CheckBox)
    '        '    If ck.Checked Then
    '        '        Try
    '        '            Response.Write("<script>alert('Checkbox checked')</script>")
    '        '            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    '        '        Catch error_t As Exception
    '        '            Response.Write("<script>alert('checkbox not checked')</script>")
    '        '            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    '        '        End Try

    '        '    End If
    '        '    If item.ItemType = ListViewItemType.DataItem Then
    '        '        Dim checkBox As CheckBox = CType(Row.FindControl("CheckBox1"), CheckBox)
    '        '    End If
    '        'Next
    '        For Each item In ListViewHRDFormIzin.Items
    '            Dim chk1 As CheckBox = item.FindControl("CheckBox1")
    '            If chk1.Checked Then
    '                Response.Write("<script>alert('Get value')</script>")
    '                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    '            Else
    '                Response.Write("<script>alert('Empty Value')</script>")
    '                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    '            End If
    '        Next

    '        'Dim chkSelect As CheckBox = CType(ListViewHRDFormIzin.FindControl("chkSelect"), CheckBox)
    '        'If chkSelect IsNot Nothing Then
    '        '    Dim ID As String = ListViewHRDFormIzin.DataKeys(ListViewHRDFormIzin.SelectedIndex).Value.ToString
    '        '    Response.Write("<script>alert('Value : " + ID + "')</script>")
    '        '    'next line of logic code
    '        'Else
    '        '    Response.Write("<script>alert('Empty Value')</script>")
    '        '    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    '        'End If
    '        'Response.Write("<script>alert('Empty Value')</script>")
    '        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    '    End Sub
    Protected Sub BtnBackDetaildanApproval_Click(sender As Object, e As EventArgs) Handles BtnBackDetaildanApproval.Click
        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    End Sub

    Protected Sub LvDetailStaff2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvDetailStaff2.SelectedIndexChanged
        Dim id_izin As String = (LvDetailStaff2.DataKeys(LvDetailStaff2.SelectedIndex).Value.ToString)
        'untuk set div nya seperti semula, ketika user berpindah pindah value to show 
        'Response.Write("<script>alert('LvDetailStaff2')</script>")
        divtgl1.Visible = True
        divtgl2.Visible = True
        divtgl3.Visible = True
        divtgl4.Visible = True
        divtgl5.Visible = True
        divtgl6.Visible = True
        divtgl7.Visible = True
        divtgl8.Visible = True
        divtgl9.Visible = True
        divtgl10.Visible = True
        divtgl11.Visible = True
        divtgl12.Visible = True
        'Response.Write("<script>alert('Nik yang login " + TxtStaffNIKMaster.Text + "')</script>")
        'Response.Write("<script>alert('Nik yang login " + nik_lvdetailizinstaff + "')</script>")

        'untuk User terkait masih blm bisa mengecek detil izin yang di ajukan

        'mencocokan user yg bisa mengakses hanya atasan 1 dan 2 dari staff tersebut 
        Call GetData_DetaiIzinStaff("select IZIN_NIK from DATA_IZIN_BODY where IZIN_ID = '" & id_izin & "'", "6") 'mendapatkan nilai NIK 
        Call GetData_DetaiIzinStaff("select STAFF_ATASAN1 from DATA_STAFF where STAFF_NIK = '" & nik_staff1 & "'", "4")
        Call GetData_DetaiIzinStaff("select STAFF_ATASAN2 from DATA_STAFF where STAFF_NIK = '" & nik_staff1 & "'", "5")
        'pengecekan apakah sudah di apprv atasan1
        Call GetData_DetaiIzinStaff("select IZIN_TGLAPPVSPV from DATA_IZIN_BODY where IZIN_ID = '" & id_izin & "'", "7")
        'pengecekan apakah sudah di apprv atasan2
        Call GetData_DetaiIzinStaff("select IZIN_TGLAPPVMNG, IZIN_STATUS from DATA_IZIN_BODY where IZIN_ID = '" & id_izin & "'", "8")
        'untuk staff tersebut melihat detail izin nya 
        Call GetData_DetaiIzinStaff("select IZIN_NIK_APPVMNG from DATA_IZIN_HEADER where IZIN_NIK = '" & nik_staff1 & "'", "9")
        'get jumlah pengajuan dari data_izin_detail by id izin
        Call GetData_DetaiIzinStaff("select count (izin_tgldetail) as JMLIZIN  from data_izin_detail where izin_id = '" & id_izin & "'", "15")

        Call GetData_DetaiIzinStaff(" Select * FROM DATA_IZIN_BODY WHERE IZIN_ID = '" & id_izin & "'", "1")
        Call GetData_DetaiIzinStaff(" Select * FROM DATA_IZIN_HEADER WHERE IZIN_NIK = '" & nik_lvdetailizinstaff & "'", "2")
        'tampilkan jml pengajuan tanggal array 
        Call GetData_ListTglIzin("select izin_tgldetail from data_izin_detail where izin_id = '" & id_izin & "'", "1")
        'Dim FileName As String = "115035.jpg" 'It 's a file name displayed on downloaded file on client side.
        'Dim unionname As String = "D:/Herlambang/September-Ongoing - Revisi Input Data Izin (Table)/LiveMUGENASP/MugenASPHRISO_10_22_018/img/" + FileName
        'Image1.ImageUrl = unionname
        'menampilkan data array ke textbox tgl
        If TxtDetailJmlPengajuan.Text = 1 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            divtgl2.Visible = False
            divtgl3.Visible = False
            divtgl4.Visible = False
            divtgl5.Visible = False
            divtgl6.Visible = False
            divtgl7.Visible = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 2 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            divtgl3.Visible = False
            divtgl4.Visible = False
            divtgl5.Visible = False
            divtgl6.Visible = False
            divtgl7.Visible = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 3 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            divtgl4.Visible = False
            divtgl5.Visible = False
            divtgl6.Visible = False
            divtgl7.Visible = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 4 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            divtgl5.Visible = False
            divtgl6.Visible = False
            divtgl7.Visible = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 5 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            divtgl6.Visible = False
            divtgl7.Visible = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 6 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            divtgl7.Visible = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 7 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            TxtDetailTglPengajuan7.Text = Convert.ToDateTime(ListTgl(6)).ToShortDateString
            TxtDetailTglPengajuan7.Enabled = False
            divtgl8.Visible = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 8 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            TxtDetailTglPengajuan7.Text = Convert.ToDateTime(ListTgl(6)).ToShortDateString
            TxtDetailTglPengajuan7.Enabled = False
            TxtDetailTglPengajuan8.Text = Convert.ToDateTime(ListTgl(7)).ToShortDateString
            TxtDetailTglPengajuan8.Enabled = False
            divtgl9.Visible = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 9 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            TxtDetailTglPengajuan7.Text = Convert.ToDateTime(ListTgl(6)).ToShortDateString
            TxtDetailTglPengajuan7.Enabled = False
            TxtDetailTglPengajuan8.Text = Convert.ToDateTime(ListTgl(7)).ToShortDateString
            TxtDetailTglPengajuan8.Enabled = False
            TxtDetailTglPengajuan9.Text = Convert.ToDateTime(ListTgl(8)).ToShortDateString
            TxtDetailTglPengajuan9.Enabled = False
            divtgl10.Visible = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 10 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            TxtDetailTglPengajuan7.Text = Convert.ToDateTime(ListTgl(6)).ToShortDateString
            TxtDetailTglPengajuan7.Enabled = False
            TxtDetailTglPengajuan8.Text = Convert.ToDateTime(ListTgl(7)).ToShortDateString
            TxtDetailTglPengajuan8.Enabled = False
            TxtDetailTglPengajuan9.Text = Convert.ToDateTime(ListTgl(8)).ToShortDateString
            TxtDetailTglPengajuan9.Enabled = False
            TxtDetailTglPengajuan10.Text = Convert.ToDateTime(ListTgl(9)).ToShortDateString
            TxtDetailTglPengajuan10.Enabled = False
            divtgl11.Visible = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 11 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            TxtDetailTglPengajuan7.Text = Convert.ToDateTime(ListTgl(6)).ToShortDateString
            TxtDetailTglPengajuan7.Enabled = False
            TxtDetailTglPengajuan8.Text = Convert.ToDateTime(ListTgl(7)).ToShortDateString
            TxtDetailTglPengajuan8.Enabled = False
            TxtDetailTglPengajuan9.Text = Convert.ToDateTime(ListTgl(8)).ToShortDateString
            TxtDetailTglPengajuan9.Enabled = False
            TxtDetailTglPengajuan10.Text = Convert.ToDateTime(ListTgl(9)).ToShortDateString
            TxtDetailTglPengajuan10.Enabled = False
            TxtDetailTglPengajuan11.Text = Convert.ToDateTime(ListTgl(10)).ToShortDateString
            TxtDetailTglPengajuan11.Enabled = False
            divtgl12.Visible = False
        ElseIf TxtDetailJmlPengajuan.Text = 12 Then
            TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString
            TxtDetailTglPengajuan1.Enabled = False
            TxtDetailTglPengajuan2.Text = Convert.ToDateTime(ListTgl(1)).ToShortDateString
            TxtDetailTglPengajuan2.Enabled = False
            TxtDetailTglPengajuan3.Text = Convert.ToDateTime(ListTgl(2)).ToShortDateString
            TxtDetailTglPengajuan3.Enabled = False
            TxtDetailTglPengajuan4.Text = Convert.ToDateTime(ListTgl(3)).ToShortDateString
            TxtDetailTglPengajuan4.Enabled = False
            TxtDetailTglPengajuan5.Text = Convert.ToDateTime(ListTgl(4)).ToShortDateString
            TxtDetailTglPengajuan5.Enabled = False
            TxtDetailTglPengajuan6.Text = Convert.ToDateTime(ListTgl(5)).ToShortDateString
            TxtDetailTglPengajuan6.Enabled = False
            TxtDetailTglPengajuan7.Text = Convert.ToDateTime(ListTgl(6)).ToShortDateString
            TxtDetailTglPengajuan7.Enabled = False
            TxtDetailTglPengajuan8.Text = Convert.ToDateTime(ListTgl(7)).ToShortDateString
            TxtDetailTglPengajuan8.Enabled = False
            TxtDetailTglPengajuan9.Text = Convert.ToDateTime(ListTgl(8)).ToShortDateString
            TxtDetailTglPengajuan9.Enabled = False
            TxtDetailTglPengajuan10.Text = Convert.ToDateTime(ListTgl(9)).ToShortDateString
            TxtDetailTglPengajuan10.Enabled = False
            TxtDetailTglPengajuan11.Text = Convert.ToDateTime(ListTgl(10)).ToShortDateString
            TxtDetailTglPengajuan11.Enabled = False
            TxtDetailTglPengajuan12.Text = Convert.ToDateTime(ListTgl(11)).ToShortDateString
            TxtDetailTglPengajuan12.Enabled = False
        End If

        If imagedown <> "" Then
            TxtFileName.Text = imagedown
            Dim FileName As String = imagedown 'It 's a file name displayed on downloaded file on client side.
            'Dim unionname As String = "D:/Herlambang/September-Ongoing - Revisi Input Data Izin (Table)/LiveMUGENASP/MugenASPHRISO_10_22_018/img/imgstaff/" + FileName
            'ImageBuktiSuratSakit.ImageUrl = unionname
            LabelBuktiSuratSakit.Visible = True
            BtnDownloadDetailFile.Visible = True
            'Response.Write("<script>alert('URL: " + unionname + "')</script>")
            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        Else
            LabelBuktiSuratSakit.Visible = False
            BtnDownloadDetailFile.Visible = False
        End If
        'TxtDetailTglPengajuan1.Text = Convert.ToDateTime(ListTgl(0)).ToShortDateString

        'TxtTglCuti6.Text = ListTgl(5)
        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        'Dim date1 = Convert.ToDateTime(tgldeadline)
        'Dim date2 = DateTime.Now
        'Dim date3 = ((date2 - date1.Date).Days)

        'Response.Write("<script>alert('Selisih Tanggal " + date3 + "!')</script>")
        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        '=============================================

        'LabelJamPengajuan.Visible = False
        'TxtDetailJamPengajuan.Visible = False
        If txtDetailJenisIzin.Text = "Izin Terlambat" Or txtDetailJenisIzin.Text = "Izin Keluar Kantor" Then
            Call GetData_ListTglIzin("select izin_tgldetail, izin_jamdetail from data_izin_detail where izin_id = '" & id_izin & "'", "2")
            LabelJamPengajuan.Visible = True
            TxtDetailJamPengajuan.Visible = True
            TxtDetailJamPengajuan.Enabled = False
            TxtDetailAlasanPengajuan2.Visible = False
            LabelDetailAlasanPengajuan2.Visible = False
            LabelAlasanPengajuan.Visible = True
            TxtDetailAlasanPengajuan.Visible = True

        Else
            LabelAlasanPengajuan.Visible = True
            TxtDetailAlasanPengajuan.Visible = True
            LabelJamPengajuan.Visible = False
            TxtDetailJamPengajuan.Visible = False
            If txtDetailJenisIzin.Text = "Cuti" Then
                TxtDetailAlasanPengajuan2.Visible = False
                LabelDetailAlasanPengajuan2.Visible = False
            Else
                TxtDetailAlasanPengajuan2.Visible = True
                LabelDetailAlasanPengajuan2.Visible = True
            End If

        End If
        '=============================================
        Dim a As Date = Convert.ToDateTime(TxtDetailDeadline.Text)
        Dim daretime As Date = DateTime.Now.AddDays(0).ToShortDateString()
        'Response.Write("<script>alert('Status izin : " + TxtDetailStatusPengajuan.Text + " ')</script>")
        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        If daretime > a Then
            Response.Write("<script>alert('Tidak Bisa Melakukan Operasi. Sudah Lewat dari  Deadline')</script>")
            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        ElseIf daretime < a Or daretime = a Then
            'Response.Write("<script>alert('kurang dari atau sama dengan ')</script>")
            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            '=====GOLDEN 
            'cek nik login
            'Response.Write("<script>alert('Nik Login : " + TxtStaffNIKMaster.Text + " dan nik staff 1 : " + nik_staff1 + "')</script>")
            'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            statusizin = TxtDetailStatusPengajuan.Text
            If statusizin = "Pending" Or statusizin = "Disetujui Atasan" Then
                TxtDetailAlasanBtlStj.Enabled = True
            Else
                TxtDetailAlasanBtlStj.Enabled = False
            End If

            If TxtStaffNIKMaster.Text = nik_atasan1 And nameapv2 <> "--" Then
                'Response.Write("<script>alert('Atasan 1 dengan atasan 2 login')</script>")
                'case atasan 1 yg memiliki atasan lagi
                If tglapv1 = "" And statusizin = "Pending" Then 'pending dan di terima atasan
                    BtnSaveDetaildanApproval.Visible = True
                    BtnDeclineDetaildanApproval.Visible = True
                ElseIf statusizin = "Dibatalkan Staff" Or statusizin = "Dibatalkan HRD" Then
                    Response.Write("<script>alert('Data telah di Batalkan Staff atau HRD !')</script>")

                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False

                Else
                    Response.Write("<script>alert('Data Sudah di Setujui / di Batalkan!')</script>")

                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False

                End If
            ElseIf TxtStaffNIKMaster.Text = nik_atasan1 And nameapv2 = "--" Then
                'Response.Write("<script>alert('Atasan 1 tanpa atasan 2 login')</script>")
                'case atasan 1 tanpa atasan 2
                Response.Write("<script>alert('Status Izin : " + statusizin + "')</script>") '===================
                If tglapv1 = "" And statusizin = "Pending" Then
                    BtnSaveDetaildanApproval.Visible = True
                    BtnDeclineDetaildanApproval.Visible = True
                ElseIf statusizin = "Dibatalkan Staff" Or statusizin = "Dibatalkan HRD" Then
                    Response.Write("<script>alert('Data telah di Batalkan Staff atau HRD !')</script>")

                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False

                Else
                    Response.Write("<script>alert('Data Sudah di Setujui / di Batalkan!')</script>")

                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                End If
            ElseIf TxtStaffNIKMaster.Text = nik_staff1 Then
                BtnSaveDetaildanApproval.Visible = False
                'Response.Write("<script>alert('Staff login')</script>")
                If nameapv2 <> "--" Then
                    'Response.Write("<script>alert('Staff dengan 2 atasan login')</script>")
                    'untuk case staff dengan 2 atasan
                    If tglapv1 = "" And tglapv2 = "" And statusizin = "Pending" Then
                        Response.Write("<script>alert('Status Izin : Pending')</script>")
                        BtnDeclineDetaildanApproval.Visible = True
                    ElseIf tglapv1 <> "" And tglapv2 = "" And statusizin = "Disetujui Atasan" Then
                        Response.Write("<script>alert('Tgl apv 2 masih kosong')</script>")
                        BtnDeclineDetaildanApproval.Visible = True
                    ElseIf statusizin = "Dibatalkan Staff" Or statusizin = "Dibatalkan HRD" Then
                        Response.Write("<script>alert('Data telah di Batalkan Staff atau HRD !')</script>")

                        BtnSaveDetaildanApproval.Visible = False
                        BtnDeclineDetaildanApproval.Visible = False
                    Else
                        'Response.Write("<script>alert('Data Izin Anda Sudah di Setujui')</script>")
                        BtnDeclineDetaildanApproval.Visible = False
                    End If
                Else
                    'Response.Write("<script>alert('Staff dengan 1 atasan login: " + statusizin + "')</script>")
                    'untuk case staff dengan 1 atasan
                    'Response.Write("<script>alert('Staff dengan 1 atasan login')</script>")
                    If tglapv1 <> "" Or statusizin = "Dibatalkan Manajer" Or statusizin = "Dibatalkan Staff" Or statusizin = "Disetujui Manajer" Then
                        BtnDeclineDetaildanApproval.Visible = False

                    Else
                        BtnDeclineDetaildanApproval.Visible = True
                    End If
                End If
            ElseIf TxtStaffNIKMaster.Text = nik_atasan2 And nameapv2 <> "--" Then
                'Response.Write("<script>alert('Atasan2  login ')</script>")
                'Response.Write("<script>alert('Status Izin: " + statusizin + "')</script>")

                'case atasan 2 login
                If tglapv1 <> "" And tglapv2 = "" And statusizin <> "Dibatalkan Manajer" Then 'and status izin apprv atasan 1
                    BtnSaveDetaildanApproval.Visible = True
                    BtnDeclineDetaildanApproval.Visible = True

                ElseIf tglapv1 <> "" And tglapv2 <> "" And statusizin = "Disetujui Manajer" Then
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                    Response.Write("<script>alert('Anda Sudah Approve data Ini')</script>")
                ElseIf statusizin = "Dibatalkan Atasan" Or statusizin = "Dibatalkan Staff" Then
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                    Response.Write("<script>alert('Data ini sudah di batalkan Atasan atas Staff yang bersangkutan')</script>")
                ElseIf statusizin = "Dibatalkan Manajer" Then
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                    Response.Write("<script>alert('Data ini sudah Anda Batalkan')</script>")
                ElseIf statusizin = "Disetujui Manajer" Then
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                    Response.Write("<script>alert('Data ini sudah Di Setujui Manajer')</script>")
                Else
                    Response.Write("<script>alert('Anda Tidak Bisa Approve data karena atasan dari staff tersebut belum melakukan approval')</script>")
                    BtnSaveDetaildanApproval.Visible = False
                    BtnDeclineDetaildanApproval.Visible = False
                    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
                End If
            Else
                Response.Write("<script>alert('Anda tidak memiliki akses untuk melihat data ini')</script>")
                Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
            End If
        End If

        '===============================================

        '============================================================================================================================================
        'Response.Write("<script>alert('nik staff " + nik_staff1 + "')</script>")
        '==================REMAKE=======================================

        'hide mv  hrd form izin
        MultiViewHRDFormIzin.ActiveViewIndex = -1
        'hide mv  hrd form izin detail
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        'multiview keseluruhan
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        'multiview header default nama nik jabatan 
        MultiViewAkses.ActiveViewIndex = -1
        'multiview dropdown jenis izin
        MultiViewDDJenisIzin.ActiveViewIndex = -1

        'show data detail dan apprv

        'hide mv detail and apprv
        'MultiViewDetaildanAprrv.ActiveViewIndex = -1
        MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide mv hrd form izin laporan
        MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
        'hide lv lihat list izin
        MultiViewLihatListIzin.ActiveViewIndex = -1
    End Sub
    Protected Sub BtnDownloadHistorySaldo_Click(sender As Object, e As EventArgs) Handles BtnDownloadHistorySaldo.Click
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=History_Saldo.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        ListViewHistorySaldo.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
        Response.Write("<script>alert('Sukses Mencetak History Saldo Staff')</script>")
        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    End Sub
    Protected Sub lblLihatListIzin_Click(sender As Object, e As EventArgs) Handles lblLihatListIzin.Click
        MultiViewDetaildanAprrv.ActiveViewIndex = -1
        MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        MultiViewHRDFormIzin.ActiveViewIndex = -1
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
        MultiViewDDJenisIzin.ActiveViewIndex = -1
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        MultiViewTableListIzin.ActiveViewIndex = -1
        TxtTglCariIzin.Text = DateTime.Now.ToShortDateString
		TxtTglCariIzin2.Text = DateTime.Now.ToShortDateString

    End Sub
    Protected Sub BtnCariLihatListIzin_Click(sender As Object, e As EventArgs) Handles BtnCariLihatListIzin.Click
        MultiViewDetaildanAprrv.ActiveViewIndex = -1
        MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        MultiViewHRDFormIzin.ActiveViewIndex = -1
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        MultiViewHRDFormIzinLaporan.ActiveViewIndex = -1
        MultiViewDDJenisIzin.ActiveViewIndex = -1
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        MultiViewTableListIzin.ActiveViewIndex = -1

    End Sub
    'Protected Sub BtnCetakCariList_Click(sender As Object, e As EventArgs) Handles BtnCetakCariList.Click
    '    Response.ClearContent()
    '    Response.AddHeader("content-disposition", "attachment; filename=Cari_Saldo.xls")
    '    Response.ContentType = "application/excel"
    '    Dim sw As New System.IO.StringWriter()
    '    Dim htw As New HtmlTextWriter(sw)
    '    ListView1.RenderControl(htw)
    '    Response.Write(sw.ToString())
    '    Response.[End]()
    '    Response.Write("<script>alert('Sukses Mencetak Cari Saldo Staff')</script>")
    '    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    'End Sub
    'Public Res As String
    'Private ReadOnly Property IDs As List(Of Integer)
    '    Get

    '        If Me.ViewState("IDs") Is Nothing Then
    '            Me.ViewState("IDs") = New List(Of Integer)()
    '        End If

    '        Return CType(Me.ViewState("IDs"), List(Of Integer))
    '    End Get
    'End Property

    'Protected Sub BtnGetChkValue_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    For Each item As ListViewDataItem In ListView1.Items
    '        Dim chkSelect As CheckBox = CType(item.FindControl("CheckBox1"), CheckBox)

    '        If chkSelect IsNot Nothing Then
    '            Dim ID As Integer = Convert.ToInt32(chkSelect.Attributes("value"))

    '            If chkSelect.Checked AndAlso Not Me.IDs.Contains(ID) Then
    '                Me.IDs.Add(ID)

    '            ElseIf Not chkSelect.Checked AndAlso Me.IDs.Contains(ID) Then
    '                Me.IDs.Remove(ID)
    '            End If
    '        End If
    '    Next
    '    'TextBox1.Text = Convert.ToString(IDs)
    '    ' Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
    'End Sub
    'Protected Sub BtnGetChkValue_Click(sender As Object, e As EventArgs) Handles BtnGetChkValue.Click
    '    For Each row As ListViewItem In ListViewHRDFormIzin.Items
    '        Dim cb As CheckBox = CType(row.FindControl("ChkBox"), CheckBox)

    '        If cb IsNot Nothing Then

    '            If cb.Checked = True Then
    '                Dim item As ListViewItem = ListViewHRDFormIzin.Items(ListViewHRDFormIzin.SelectedIndex)
    '                Dim c As String = item.FindControl("STAFF_NIK").ToString()
    '                Res = Res & "" + c
    '                Response.Write("<script>alert('Value check : " + Res + "')</script>")
    '            End If
    '        End If
    '    Next
    '    Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")

    '(ListViewHRDFormIzin.DataKeys(ListViewHRDFormIzin.SelectedIndex).Value.ToString)
    'End Sub

    'update semua saldo izin staff di tb data_izin_header
    Protected Sub BtnSaldoIzinSemua_Click(sender As Object, e As EventArgs) Handles BtnSaldoIzinSemua.Click
        Dim saldosemua, tahunsemua As String
        saldosemua = TxtSaldoIzinSemua.Text
        tahunsemua = TxtTahunIzinSemua.Text
        Dim dateshrt As String = DateTime.Now.ToShortDateString
        'insert data izin saldo
        Call UpdateData_Server("INSERT INTO data_izin_saldo (nik, NOMINAL_AWAL, NOMINAL_AKHIR, TAHUN, KET, TGL) SELECT IZIN_NIK, '-7', IZIN_SALDO, IZIN_TAHUN,'Input Saldo Awal tahun','" & dateshrt & "' FROM data_izin_header", "")
        'update data izin header
        If UpdateData_Server("update data_izin_header set izin_saldo = '" & saldosemua & "', izin_tahun = '" & tahunsemua & "' ", "") = 1 Then
            Response.Write("<script>alert('Berhasil Update Seluruh Saldo Izin Staff!')</script>")
            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        Else
            Response.Write("<script>alert('Gagal Update Seluruh Saldo Izin Staff!')</script>")
            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        End If
        Call UpdateData_Server("UPDATE data_izin_saldo SET data_izin_saldo.NOMINAL_AWAL = data_izin_header.IZIN_SALDO FROM data_izin_saldo, data_izin_header WHERE data_izin_saldo.NOMINAL_AWAL = '-7'", "")
        '************************get nik value from data_izin_header and keep in array list
        'update data izin saldo


    End Sub

    Protected Sub BtnDownloadDetailFile_Click(sender As Object, e As EventArgs) Handles BtnDownloadDetailFile.Click
        Call GetData_DetaiIzinStaff(" Select * FROM DATA_IZIN_BODY WHERE IZIN_ID = '" & TxtDetailNik.Text & "'", "1")
        Dim FileName As String = TxtFileName.Text 'It 's a file name displayed on downloaded file on client side.
        Dim unionname As String = "C:/inetpub/wwwroot/MugenASPHRISO/WEBDOWNLOAD/FOTOIZIN/" + FileName
        'Dim unionname As String = "D:/Herlambang/September-Ongoing - Revisi Input Data Izin (Table)/LiveMUGENASP/MugenASPHRISO_10_22_018/img/imgstaff/" + FileName
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
    Protected Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim id_izin As String = (ListView1.DataKeys(ListView1.SelectedIndex).Value.ToString)
        'get picture value from id_izin
        Call GetData_DetaiIzinStaff(" Select * FROM DATA_IZIN_BODY WHERE IZIN_ID = '" & id_izin & "'", "1")
        Dim FileName As String = imagedown 'TxtFileName.Text 'It 's a file name displayed on downloaded file on client side.
        If imagedown <> "" Then
            Dim unionname As String = "C:/inetpub/wwwroot/MugenASPHRISO/WEBDOWNLOAD/FOTOIZIN/" + FileName
            'Dim unionname As String = "D:/Herlambang/September-Ongoing - Revisi Input Data Izin (Table)/LiveMUGENASP/MugenASPHRISO_10_22_018/img/imgstaff/" + FileName
            Response.Write("<script>alert('\Url : " + unionname + "')</script>")
            Context.Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/jpg"
            Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName)
            Response.WriteFile(unionname)
            Response.Flush()
            Response.[End]()
        Else
            Response.Write("<script>alert('File Gambar tidak ditemukan!')</script>")
            Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        End If

    End Sub

    Protected Sub BtnCariLaporanIzin_Click(sender As Object, e As EventArgs) Handles BtnCariLaporanIzin.Click
        'show tb staff list 
        MultiViewHRDFormIzin.ActiveViewIndex = -1

        'hide Detail Aprrv
        MultiViewDetaildanAprrv.ActiveViewIndex = -1
        'hide detail operasi saldo 
        MultiViewHRDFormIzinDetail.ActiveViewIndex = -1
        'hide table list izin apprvd by mng
        'MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide dd data izin
        MultiViewDDJenisIzin.ActiveViewIndex = -1
        'hide izin cuti mv
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        'hide btn sub menu hrd
        'MultiViewHRDFormIzinMaster.ActiveViewIndex = -1
        'hide detail cancel
        MultiViewHRDFormIzinDetail2.ActiveViewIndex = -1
        'hide mv decline table 
        MultiViewHRDFormIzinDecline.ActiveViewIndex = -1
        'hide lv lihat list izin
        MultiViewLihatListIzin.ActiveViewIndex = -1
    End Sub
End Class
'============================================NOTE=================================================='
'1. staff dapat terus mengajukan Izin Cuti
'2. Staff HRD ketika akan update Saldo Cuti Tahunan, maka akan selalu di lakukan pengecekan
'    apakah staff tersebut telah memiliki pengajuan izin cuti yang telah di aprrove oleh kedua atasan nya.
'    JIKA YA : jml pengajuan yg di approve akan mengurangi nilai saldo awal tahun cuti yg akan di input
'    JIKA TIDAK : masukan jumlah saldo awal tahun cuti ke database tanpa ada pengecekan

'ketika staff mengajukan cuti 9insert ke db) maka akan ada pengecekan pada database DATA_IZIN jika record atas staff tersebut sudah ada maka 
'jangan insert data izin, hanya insert data_izindetail saja. 
'jika record data staff tersebut belum ada maka, insert data izin dengan nilai saldo cuti 'NULL'
