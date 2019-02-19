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

Partial Class HRDPENILAIANKARYAWAN
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader
    Dim sFileDir As String = "E:\"
    Dim lMaxFileSize As Long = 4096

    '====== Halaman Data Kpi setiap Tahun =======

    'Tampilan Data KPI karyawan setiap Tahun
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If

        If LblUserName.Text = "" Then
            Dim x As String
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = x.ToString

            Dim no As String = Request.QueryString("no")

            'Jika link membawa NIK
            If no <> "" Then
                Call GetData_STAFF("SELECT * FROM DATA_STAFF WHERE STAFF_NIK='" & no & "'")
                Call GetData_UserHead("Select kpih_appvhead, kpih_appvhead2, kpih_deadlinepk, kpih_deadlineatasan, kpih_deadlineatasan2 from trxn_kpih WHERE KPIH_NIK='" & TxtStaffNIK.Text & "'")
                Call GetData_STAFF3("SELECT * FROM TB_USER WHERE username='" & LblUserName.Text & "'")
                Call GetData_STAFF4("SELECT * FROM TB_USER WHERE kdKaryawan='" & no & "'")
            Else
                Call GetData_STAFF2("SELECT * FROM TB_USER WHERE username='" & LblUserName.Text & "'")
                Call GetData_STAFF4("SELECT * FROM TB_USER WHERE kdKaryawan='" & TxtStaffNIK.Text & "'")
                Call GetData_STAFF("SELECT * FROM DATA_STAFF WHERE STAFF_NIK='" & TxtStaffNIK.Text & "'")
                Call GetData_UserHead("Select kpih_appvhead, kpih_appvhead2, kpih_deadlinepk, kpih_deadlineatasan, kpih_deadlineatasan2 from trxn_kpih WHERE KPIH_NIK='" & TxtStaffNIK.Text & "'")
            End If

            'Jika user mempunyai akses login HRD
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- VIEW PK'") = 1 Then
                'Hak akses bu Octa
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- STAFF HRD EDIT'") = 1 And subJabatan.Text = "0" Or subJabatan.Text = "2" Or TxtNama.Text = TxtStaffNama.Text Then
                    Call HakLihatPK()
                End If
                'Hak Akses Bu Fia
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- SPV HRD EDIT'") = 1 And subJabatan.Text = "1" Or subJabatan.Text = "3" Then
                    Call HakLihatPK()
                End If
                'Hak Akses Bu Tini
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- HRD HEAD EDIT'") = 1 Then
                    Call HakLihatPK()
                End If

            ElseIf GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- PENILAIAN ATASAN KE BAWAHAN'") = 1 Then

                'Jika username = nama atasan maka
                If LblUserName.Text = TxtHead.Text Then
                    Call HakLihatPK()

                    'Jika username = nama atasan dari atasan langsung
                ElseIf LblUserName.Text = TxtHead2.Text Then
                    Call HakLihatPK()

                    'Jika user merupakan yang memiliki KPI
                ElseIf TxtNama.Text = TxtStaffNama.Text Then
                    Call HakLihatPK()

                Else
                    MultiViewAkses.ActiveViewIndex = 0
                    MultiViewKpiMaster.ActiveViewIndex = -1
                End If

                'Jika user merupakan pemilik PK
            ElseIf TxtNama.Text = TxtStaffNama.Text Then
                Call HakLihatPK()
            Else
                MultiViewAkses.ActiveViewIndex = 0
                MultiViewKpiMaster.ActiveViewIndex = -1
            End If
        End If
    End Sub

    'Aksi ketika HRD menekan tombol Tambah KPI karyawan
    Protected Sub BtnKpi40Master_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40Master.Click
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- VIEW PK'") = 1 Then
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- SETTING PK'") = 1 Then
                pengisian.Visible = True
                buttonMaster.Visible = True
                atasanlangsung.Visible = True
                atasanlangsung2.Visible = True
                copytahun.Visible = True
                BtnKpi40.Visible = True
                Call lockhrd()
            Else
                Call lockhrd()
            End If
        ElseIf LblUserName.Text = TxtHead.Text Then
            Call lockatasan()
        ElseIf LblUserName.Text = TxtHead2.Text Then
            Call lockatasan2()
        Else
            Call lockkaryawan()
        End If
        MultiViewKpiMasterEntry.ActiveViewIndex = 0
        MultiViewKpiMaster.ActiveViewIndex = -1
        Call ClearTabelKPIMaster()
    End Sub

    'Aksi ketika menekan tombol detail KPI dari karyawan
    Protected Sub LvKpiMasterSummary_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvKpiMasterSummary.SelectedIndexChanged
        TxtKpiSummaryTahun.Text = (LvKpiMasterSummary.DataKeys(LvKpiMasterSummary.SelectedIndex).Value.ToString)
        Call GetData_MASTER("SELECT * FROM TRXN_KPIH WHERE KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPIH_NIK='" & TxtStaffNIK.Text & "'")
        Call hitunghasil()

        'Jika username memiliki hak akses Head HRD
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- VIEW PK'") = 1 Then
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- SETTING PK'") = 1 Then
                pengisian.Visible = True
                buttonMaster.Visible = True
                atasanlangsung.Visible = True
                atasanlangsung2.Visible = True
                copytahun.Visible = True
                Call lockhrd()
            Else
                Call lockhrd()
            End If
        ElseIf LblUserName.Text = TxtHead.Text Then
            Call lockatasan()
        ElseIf LblUserName.Text = TxtHead2.Text Then
            Call lockatasan2()
        Else
            Call lockkaryawan()
        End If
        MultiViewKpiMasterEntry.ActiveViewIndex = 0
        MultiViewKPIMasterDetail.ActiveViewIndex = 0
        MultiViewKpiMaster.ActiveViewIndex = -1
        Call ClikDetail_MultiViewKpiMaster()
    End Sub

    'Aksi ketika HRD klik tombol Copy PK Tahun Sebelumnya
    Protected Sub BtnKpi40MasterCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40MasterCopy.Click
        Dim mSqlCommand As String

        'Hapus Yang Baru
        mSqlCommand = "DELETE TRXN_KPIH WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahunNext.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")

        mSqlCommand = "DELETE TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahunNext.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")

        mSqlCommand = "DELETE TRXN_KPIDD WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahunNext.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")

        'Copy Ke Yg Lama
        mSqlCommand = "INSERT INTO TRXN_KPIH " & _
                      "SELECT KPIH_NIK,'" & TxtKpiSummaryTahunNext.Text & "',KPIH_TIPEA,KPIH_TIPEB,KPIH_APPVUSER,KPIH_APPVUSERTGL,KPIH_APPVHEAD,KPIH_APPVHEADTGL,KPIH_APPVHRD,KPIH_APPVHRDTGL,KPIH_NILAI,KPIH_ABJAD,KPIH_NILAI1,KPIH_NILAI2,KPIH_NILAI3,KPIH_SP,KPIH_NILAISP,KPIH_NILAIPRC1,KPIH_NILAIPRC2,KPIH_NILAIPRC3 " & _
                      "FROM TRXN_KPIH WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")

        mSqlCommand = "INSERT INTO TRXN_KPID " & _
                      "SELECT KPID_NIK,'" & TxtKpiSummaryTahunNext.Text & "',KPID_ITEM,KPID_BULAN01,KPID_BULAN02,KPID_BULAN03,KPID_BULAN04,KPID_BULAN05,KPID_BULAN06,KPID_BULAN07,KPID_BULAN08,KPID_BULAN09,KPID_BULAN10,KPID_BULAN11,KPID_BULAN12,KPID_TARGET,KPID_PRESTASI,KPID_TYPEA,KPID_NILAISTAFF,KPID_NILAIATASAN,KPID_NILAIAKHIR " & _
                      "FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")

        mSqlCommand = "UPDATE TRXN_KPIH SET " & _
                      "KPIH_TIPEA='" & TxtKpiSummaryPosA.Text & "'," & _
                      "KPIH_APPVUSER='',KPIH_APPVUSERTGL=NULL," & _
                      "KPIH_APPVHEAD='',KPIH_APPVHEADTGL=NULL," & _
                      "KPIH_APPVHRD='',KPIH_APPVHRDTGL=NULL," & _
                      "KPIH_NILAI=0,KPIH_ABJAD='',KPIH_NILAI1=0,KPIH_NILAI2=0,KPIH_NILAI3=0,KPIH_SP='',KPIH_NILAISP=0,KPIH_NILAIPRC1=0,KPIH_NILAIPRC2=0,KPIH_NILAIPRC3=0 " & _
                      "FROM TRXN_KPIH WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahunNext.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")

        mSqlCommand = "UPDATE TRXN_KPID SET " & _
                      "KPID_BULAN01='',KPID_BULAN02='',KPID_BULAN03='',KPID_BULAN04='',KPID_BULAN05='',KPID_BULAN06=''," & _
                      "KPID_BULAN07='',KPID_BULAN08='',KPID_BULAN09='',KPID_BULAN10='',KPID_BULAN11='',KPID_BULAN12=''," & _
                      "KPID_PRESTASI=0,KPID_TYPEA='" & TxtKpiSummaryPosA.Text & "'," & _
                      "KPID_NILAISTAFF=0,KPID_NILAIATASAN=0,KPID_NILAIAKHIR=0 " & _
                      "FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahunNext.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")

        'Proses ada='A'
        '
        Call nilailanjutan(TxtKpiSummaryTahunNext.Text)

        TxtKpiSummaryTahun.Text = TxtKpiSummaryTahunNext.Text
        lblKpiSummaryTahun.Text = TxtKpiSummaryTahunNext.Text

        LvKpiMasterSummary.DataBind()
        MultiViewKPIMasterDetail.ActiveViewIndex = 0 : LvKPIMasterDetail.DataBind()
        Call ClikDetail_MultiViewKpiMaster()
    End Sub

    Sub nilailanjutan(ByVal mTahun As String)
        Dim mSqlCommand As String
        mSqlCommand = "INSERT INTO TRXN_KPIDD (kpi_nik,kpi_staff,kpi_atasan,kpi_akhir,kpi_tipeA,kpi_tahun,kpi_kodeitem,kpi_komentar,kpi_komentar2,kpi_kodeitemm)" & _
                      "SELECT " & TxtStaffNIK.Text & ",0,0,0,'A','" & mTahun & "',KPIN_TIPE,'','','' " & _
                      "FROM DATA_KPIN WHERE KPIN_GROUP='PROCESS'"
        'mSqlCommand = "INSERT INTO TRXN_KPIDD " & _
        '"SELECT " & TxtStaffNIK.Text & ",0,0,0,0,'A','" & mTahun & "',KPIN_TIPE,'','','' " & _
        '"FROM DATA_KPIN WHERE KPIN_GROUP='PROCESS'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")


        If TxtKpiSummaryPosA.Text = "D" Then
            mSqlCommand = "INSERT INTO TRXN_KPIDD " & _
                      "SELECT " & TxtStaffNIK.Text & ",0,0,0,0,'A','" & mTahun & "',KPIN_TIPE,'','','' " & _
                      "FROM DATA_KPIN WHERE KPIN_GROUP='PROCESS3'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        End If

        'If subJabatan.Text = "2" Then
        'mSqlCommand = "INSERT INTO TRXN_KPIDD " & _
        '   "SELECT " & TxtStaffNIK.Text & ",0,0,0,0,'A','" & mTahun & "',KPIN_TIPE,'','','' " & _
        ' "FROM DATA_KPIN WHERE KPIN_GROUP='PROCESS4'"
        'Call UpdateData_Server(mSqlCommand, "Kpi40")
        '  End If

        If TxtKpiSummaryPosA.Text = "A" Or TxtKpiSummaryPosA.Text = "B" Or TxtKpiSummaryPosA.Text = "C" Then
            mSqlCommand = "INSERT INTO TRXN_KPIDD (KPI_NIK,KPI_STAFF,KPI_ATASAN,KPI_AKHIR,KPI_TIPEA,KPI_TAHUN,KPI_KODEITEM,KPI_KOMENTAR,KPI_KOMENTAR2,KPI_KODEITEMM)" & _
                      "SELECT " & TxtStaffNIK.Text & ",0,0,0,'C','" & mTahun & "',KPIN_TIPE,'','','' " & _
                      "FROM DATA_KPIN WHERE KPIN_GROUP='ABSEN'"

            'mSqlCommand = "INSERT INTO TRXN_KPIDD " & _
            '"SELECT " & TxtStaffNIK.Text & ",0,0,0,0,'C','" & mTahun & "',KPIN_TIPE,'','','' " & _
            '"FROM DATA_KPIN WHERE KPIN_GROUP='ABSEN'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        End If
        If TxtKpiSummaryPosA.Text = "E" Then
            mSqlCommand = "INSERT INTO TRXN_KPIDD (KPI_NIK,KPI_STAFF,KPI_ATASAN,KPI_AKHIR,KPI_TIPEA,KPI_TAHUN,KPI_KODEITEM,KPI_KOMENTAR,KPI_KOMENTAR2,KPI_KODEITEMM)" & _
                      "SELECT " & TxtStaffNIK.Text & ",0,0,0,'C','" & mTahun & "',KPIN_TIPE,'','','' " & _
                      "FROM DATA_KPIN WHERE KPIN_GROUP='HEAD'"
            'mSqlCommand = "INSERT INTO TRXN_KPIDD " & _
            '"SELECT " & TxtStaffNIK.Text & ",0,0,0,0,'C','" & mTahun & "',KPIN_TIPE,'','','' " & _
            '"FROM DATA_KPIN WHERE KPIN_GROUP='HEAD'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        End If
    End Sub

    'Aksi ketika HRD klik tombol Simpan KPI
    Protected Sub BtnKpi40MasterNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40MasterNew.Click
        'periksa ada aau tidak
        lblKpiSummaryTahun.Text = TxtKpiSummaryTahun.Text
        lblKpiSummaryPosA.Text = TxtKpiSummaryPosA.Text

        If GetFindRecord_Server("SELECT * FROM TRXN_KPIH WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'") <> 1 Then
            Dim mSqlCommand As String = ""
            mSqlCommand = "INSERT INTO TRXN_KPIH " & _
                          "(KPIH_NIK,KPIH_TAHUN,KPIH_TIPEA,KPIH_APPVUSER,KPIH_APPVUSERTGL,KPIH_APPVHEAD,KPIH_APPVHEADTGL,KPIH_APPVHRD,KPIH_APPVHRDTGL,KPIH_NILAI,KPIH_ABJAD,KPIH_NILAI1,KPIH_NILAI2,KPIH_NILAI3,KPIH_SP,KPIH_NILAISP,KPIH_NILAIPRC1,KPIH_NILAIPRC2,KPIH_NILAIPRC3,KPIH_DEADLINEPK,KPIH_DEADLINEATASAN,KPIH_DEADLINEATASAN2) " & _
                          "VALUES ('" & TxtStaffNIK.Text & "','" & TxtKpiSummaryTahun.Text & "','" & TxtKpiSummaryPosA.Text & "','',NULL,'" & TxtHead.Text & "',NULL,'',NULL,0,'',0,0,0,'',0,0,0,0,'" & TxtDeadlinePK.Text & "','" & TxtDeadlineAtasan.Text & "','" & TxtDeadlineAtasan2.Text & "')"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
            Call nilailanjutan(TxtKpiSummaryTahun.Text)
        End If

        If GetFindRecord_Server("SELECT * FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(TxtMasterKpiTipe.Text) & "'") <> 1 Then
            If UpdateData_Server(InsertDataNilaiKPI_Master, "Kpi40") = 1 Then
            End If
        End If

        LvKPIMasterDetail.DataBind()
        LVProses.DataBind()
        LVPeople.DataBind()
        LvDisiplin.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = 0
        Call ClikDetail_MultiViewKpiMaster()
        'Call ClearTabelKPIDetail()
        'MultiViewKPIMasterDetail.ActiveViewIndex = 0 : MultiViewKPIMasterDetailENtry.ActiveViewIndex = 0
        'LvKPIMasterDetail.DataBind()
        'Call ClikDetail_MultiViewKpiMaster()
    End Sub

    'Aksi Ketika HRD klik tombol Delete PK
    Protected Sub BtnKpi40CopyDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40MasterDel.Click
        Dim mSqlCommand As String
        'Hapus Yang Baru
        mSqlCommand = "DELETE TRXN_KPIH WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")

        mSqlCommand = "DELETE TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")

        mSqlCommand = "DELETE TRXN_KPIDD WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")
        Call DeaktifTabel1()
        BtnKpi40Master.Visible = True
    End Sub

    Protected Sub cariDeskripsiKPI(sender As Object, e As EventArgs)
        Call deskripsiKPI("select KPIT_ITEM from data_kpit where kpit_tipe = '" & kodeKPI.Text & "'")
        MultiViewKpiMaster.ActiveViewIndex = -1
    End Sub



    '==Detail Kpi Berdasarkan Tahun==================================
    Protected Sub BtnKpi40_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40.Click
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = 0
        Call ClearTabelKPIDetail()
        Call DeaktifRaport()
        tambahKPI.Visible = True
        dataKPI.Visible = False
        penilaianbulanan.Visible = False
    End Sub
    Sub ClearTabelKPIDetail()
        TxtMasterKpiItem.Text = ""
        TxtMasterKpiTipe.Text = ""
        TxtMasterKpiTarget.Text = ""
        TxtMasterBobot.Text = ""
        TxtMasterKpiPrestasi.Text = ""
        TxtMasterKpiBln01.Text = ""
        TxtMasterKpiBln02.Text = ""
        TxtMasterKpiBln03.Text = ""
        TxtMasterKpiBln04.Text = ""
        TxtMasterKpiBln05.Text = ""
        TxtMasterKpiBln06.Text = ""
        TxtMasterKpiBln07.Text = ""
        TxtMasterKpiBln08.Text = ""
        TxtMasterKpiBln09.Text = ""
        TxtMasterKpiBln10.Text = ""
        TxtMasterKpiBln11.Text = ""
        TxtMasterKpiBln12.Text = ""
    End Sub

    Function InsertDataNilaiKPI_Master() As String
        InsertDataNilaiKPI_Master = "INSERT INTO TRXN_KPID (KPID_NIK,KPID_TAHUN,KPID_ITEM,KPID_TYPEA) Select '" & TxtStaffNIK.Text & "','" & TxtKpiSummaryTahun.Text & "',KPIT_TIPE,'" & TxtPetik(TxtKpiSummaryPosA.Text) & "' FROM DATA_KPIT WHERE KPIT_GROUP='" & TxtStatusKerjaJabatan.Text & "'"
    End Function
    Function EditDataNilaiKPI_Master() As String
        'KPID_TYPEA=A Percobaan B Karyawan
        EditDataNilaiKPI_Master = "UPDATE TRXN_KPID SET " & _
                                  "KPID_BULAN01='" & TxtMasterKpiBln01.Text & "'," & _
                                  "KPID_BULAN02='" & TxtMasterKpiBln02.Text & "'," & _
                                  "KPID_BULAN03='" & TxtMasterKpiBln03.Text & "'," & _
                                  "KPID_BULAN04='" & TxtMasterKpiBln04.Text & "'," & _
                                  "KPID_BULAN05='" & TxtMasterKpiBln05.Text & "'," & _
                                  "KPID_BULAN06='" & TxtMasterKpiBln06.Text & "'," & _
                                  "KPID_BULAN07='" & TxtMasterKpiBln07.Text & "'," & _
                                  "KPID_BULAN08='" & TxtMasterKpiBln08.Text & "'," & _
                                  "KPID_BULAN09='" & TxtMasterKpiBln09.Text & "'," & _
                                  "KPID_BULAN10='" & TxtMasterKpiBln10.Text & "'," & _
                                  "KPID_BULAN11='" & TxtMasterKpiBln11.Text & "'," & _
                                  "KPID_BULAN12='" & TxtMasterKpiBln12.Text & "' " & _
                                  "WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(TxtMasterKpiTipe.Text) & "'"
    End Function
    Function EditDataNilaiKPI_Item(ByVal mItem As String, ByVal mNilaiStaff As Double, ByVal mNilaiHead As Double, ByVal mNilaiAkhir As Double) As String
        'KPID_TYPEA=A Percobaan B Karyawan
        EditDataNilaiKPI_Item = "UPDATE TRXN_KPID SET " & _
                                  "KPID_NILAISTAFF=" & nLg(mNilaiStaff) & "," & _
                                  "KPID_NILAIATASAN=" & nLg(mNilaiHead) & "," & _
                                  "KPID_NILAIAKHIR='" & mNilaiAkhir & "' " & _
                                  "WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(mItem) & "'"
    End Function



    Protected Sub LVKPIMAster_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvKPIMasterDetail.SelectedIndexChanged
        TxtMasterKpiItem.Text = (LvKPIMasterDetail.DataKeys(LvKPIMasterDetail.SelectedIndex).Value.ToString)
        Call GetData_MASTERKPI("SELECT TRXN_KPID.KPID_NIK, TRXN_KPID.KPID_BOBOT, TRXN_KPID.KPID_NILAISTAFF, TRXN_KPID.KPID_NILAIAKHIR, DATA_KPIT.KPIT_ITEM, DATA_KPIT.KPIT_TIPE, DATA_KPIT.KPIT_BOBOT, DATA_KPIT.KPIT_TARGET, DATA_KPIT.KPIT_HITUNG, TRXN_KPID.KPID_PRESTASI, TRXN_KPID.KPID_TYPEA, TRXN_KPID.KPID_BULAN01,  TRXN_KPID.KPID_BULAN02, TRXN_KPID.KPID_BULAN03, TRXN_KPID.KPID_BULAN04, TRXN_KPID.KPID_BULAN05, TRXN_KPID.KPID_BULAN07, TRXN_KPID.KPID_BULAN06, TRXN_KPID.KPID_BULAN08, TRXN_KPID.KPID_BULAN09, TRXN_KPID.KPID_BULAN10, TRXN_KPID.KPID_BULAN11, TRXN_KPID.KPID_BULAN12 FROM TRXN_KPID, DATA_KPIT WHERE TRXN_KPID.KPID_NIK='" & TxtStaffNIK.Text & "' AND TRXN_KPID.KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND TRXN_KPID.KPID_ITEM ='" & TxtPetik(TxtMasterKpiItem.Text) & "' AND TRXN_KPID.KPID_ITEM = DATA_KPIT.KPIT_TIPE")
        Call DeaktifRaport()

    End Sub

    Protected Sub BtnKpi40Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40Save.Click
        Dim nilai1 As Integer = 0
        Dim bulan1 As Decimal
        Dim bulan2 As Decimal
        Dim bulan3 As Decimal
        Dim bulan4 As Decimal
        Dim bulan5 As Decimal
        Dim bulan6 As Decimal
        Dim bulan7 As Decimal
        Dim bulan8 As Decimal
        Dim bulan9 As Decimal
        Dim bulan10 As Decimal
        Dim bulan11 As Decimal
        Dim bulan12 As Decimal

        If TxtMasterKpiBln01.Text <> "N/A" Then
            nilai1 = nilai1 + 1
            bulan1 = TxtMasterKpiBln01.Text
        Else
            nilai1 = nilai1 + 0
            bulan1 = 0
        End If

        If TxtMasterKpiBln02.Text <> "N/A" Then
            nilai1 = nilai1 + 1
            bulan2 = TxtMasterKpiBln02.Text
        Else
            nilai1 = nilai1 + 0
            bulan2 = 0
        End If

        If TxtMasterKpiBln03.Text <> "N/A" Then
            nilai1 = nilai1 + 1
            bulan3 = TxtMasterKpiBln03.Text
        Else
            nilai1 = nilai1 + 0
            bulan3 = 0
        End If

        If TxtMasterKpiBln04.Text <> "N/A" Then
            nilai1 = nilai1 + 1
            bulan4 = TxtMasterKpiBln04.Text
        Else
            nilai1 = nilai1 + 0
            bulan4 = 0
        End If

        If TxtMasterKpiBln05.Text <> "N/A" Then
            nilai1 = nilai1 + 1
            bulan5 = TxtMasterKpiBln05.Text
        Else
            nilai1 = nilai1 + 0
            bulan5 = 0
        End If

        If TxtMasterKpiBln06.Text <> "N/A" Then
            nilai1 = nilai1 + 1
            bulan6 = TxtMasterKpiBln06.Text
        Else
            nilai1 = nilai1 + 0
            bulan6 = 0
        End If

        If TxtMasterKpiBln07.Text <> "N/A" Then
            nilai1 = nilai1 + 1
            bulan7 = TxtMasterKpiBln07.Text
        Else
            nilai1 = nilai1 + 0
            bulan7 = 0
        End If

        If TxtMasterKpiBln08.Text <> "N/A" Then
            nilai1 = nilai1 + 1
            bulan8 = TxtMasterKpiBln08.Text
        Else
            nilai1 = nilai1 + 0
            bulan8 = 0
        End If

        If TxtMasterKpiBln09.Text <> "N/A" Then
            nilai1 = nilai1 + 1
            bulan9 = TxtMasterKpiBln09.Text
        Else
            nilai1 = nilai1 + 0
            bulan9 = 0
        End If

        If TxtMasterKpiBln10.Text <> "N/A" Then
            nilai1 = nilai1 + 1
            bulan10 = TxtMasterKpiBln10.Text
        Else
            nilai1 = nilai1 + 0
            bulan10 = 0
        End If

        If TxtMasterKpiBln11.Text <> "N/A" Then
            nilai1 = nilai1 + 1
            bulan11 = TxtMasterKpiBln11.Text
        Else
            nilai1 = nilai1 + 0
            bulan11 = 0
        End If

        If TxtMasterKpiBln12.Text <> "N/A" Then
            nilai1 = nilai1 + 1
            bulan12 = TxtMasterKpiBln12.Text
        Else
            nilai1 = nilai1 + 0
            bulan12 = 0
        End If


        Dim total As Decimal
        total = (bulan1 + bulan2 + bulan3 + bulan4 + bulan5 + bulan6 + bulan7 + bulan8 + bulan9 + bulan10 + bulan11 + bulan12) / nilai1
        total = FormatNumber(total, 2)
        Dim bobot As Integer
        bobot = Val(TxtMasterBobot.Text)
        Dim totalRapot As Decimal
        totalRapot = FormatNumber(total * bobot) / 100
        totalRapot = FormatNumber(totalRapot, 2)
        Call UpdateData_Server(EditDataNilaiKPI_Master, "Kpi40")
        Dim mSqlCommand2 As String = ""
        mSqlCommand2 = "UPDATE TRXN_KPID SET KPID_NILAISTAFF='" & total & "', KPID_NILAIAKHIR='" & totalRapot & "' WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(TxtMasterKpiTipe.Text) & "'"
        Call UpdateData_Server(mSqlCommand2, "Kpi40")

        LvKPIMasterDetail.DataBind()

        LVProses.DataBind()

        LVPeople.DataBind()
        LvDisiplin.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = 0
        Call ClikDetail_MultiViewKpiMaster()
        Call hitunghasil()
    End Sub

    Protected Sub BtnKpi40ASave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40ASave.Click

        If GetFindRecord_Server("SELECT * FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_ITEM = '" & kodeKPI.Text & "'") <> 1 Then
            Dim mSqlCommand As String = ""
            mSqlCommand = "INSERT INTO TRXN_KPID " & _
                          "(KPID_NIK,KPID_TAHUN,KPID_TYPEA,KPID_ITEM) " & _
                          "VALUES ('" & TxtStaffNIK.Text & "','" & TxtKpiSummaryTahun.Text & "','" & TxtKpiSummaryPosA.Text & "','" & kodeKPI.Text & "')"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
            Response.Write("<script>alert('Anda telah sukses menambahkan Item PK!')</script>")
            Response.Write("<script>window.location.href='HRDPENILAIANKARYAWAN.aspx';</script>")
        Else
            Response.Write("<script>alert('Item PK untuk karyawan yang bersangkutan sudah ada!')</script>")
            MultiViewKpiMaster.ActiveViewIndex = -1
        End If
    End Sub


    Protected Sub BtnKpi40Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40Del.Click
        Dim mSqlCommand As String = "DELETE FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(TxtMasterKpiTipe.Text) & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1 : LvKPIMasterDetail.DataBind()
    End Sub

    '============================================================

    Function InsertDataNilaiKPI(ByVal mStatus As String, ByVal mItem As String, ByVal mGol As String) As String
        InsertDataNilaiKPI = "INSERT INTO TRXN_KPID (KPI_NIK,KPI_TAHUN,KPI_ITEM,KPI_TIPEA,KPI_TIPEB) VALUES ('" & TxtStaffNIK.Text & "','" & TxtKpiSummaryTahun.Text & "','" & TxtPetik(mItem) & "','" & mStatus & "','" & mGol & "')"

    End Function

    Function EditDataNilaiKPI(ByVal mStatus As String, ByVal mItem As String, ByVal mTarget As String, ByVal mNilaiStaff As String, _
                                     ByVal mNilaiHead As String, ByVal mNilaiAkhir As String, ByVal mNilaiAkhir2 As String) As String
        'KPID_TYPEA=1 Percobaan ( 2 Karyawan
        'KPID_TYPEB=A Skill B Kerjaan C Disiplin D Nilai E Nilai
        EditDataNilaiKPI = "UPDATE TRXN_KPIDD SET " & _
                                  "KPI_STAFF=" & mNilaiStaff & "," & _
                                  "KPI_ATASAN=" & mNilaiHead & "," & _
                                  "KPI_KOMENTAR='" & mNilaiAkhir & "'," & _
                                  "KPI_KOMENTAR2='" & mNilaiAkhir2 & "'," & _
                                  "KPI_TIPEA='" & mStatus & "' " & _
                                  "WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM ='" & TxtPetik(mItem) & "'"
    End Function

    Function EditDataNilaiKPI2(ByVal mStatus As String, ByVal mItem As String, ByVal mTarget As String, ByVal mNilai As String) As String
        'KPID_TYPEA=1 Percobaan ( 2 Karyawan
        'KPID_TYPEB=A Skill B Kerjaan C Disiplin D Nilai E Nilai
        EditDataNilaiKPI2 = "UPDATE TRXN_KPIDD SET " & _
                                  "KPI_AKHIR=" & mNilai & "," & _
                                  "KPI_TIPEA='" & mStatus & "' " & _
                                  "WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM ='" & TxtPetik(mItem) & "'"
    End Function

    '41A

    '41B

    '42A:Proses

    Sub ClearTabelKPIKerjaA()
        LblProsesJudulJudul.Text = ""
        LblProsesKodeItem.Text = ""
        TxtProsesStaff.Text = ""
        TxtProsesHead.Text = ""
        TxtProsesKomentar.Text = ""
        TxtProsesKomentar2.Text = ""
    End Sub

    'Protected Sub LvNorma_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvNorma.SelectedIndexChanged
    'LblProsesKodeItem.Text = (LvNorma.DataKeys(LvNorma.SelectedIndex).Value.ToString)
    'Call GetData_MASTERKPIProses("SELECT * FROM TRXN_KPIDD,DATA_KPIN WHERE KPI_KODEITEM=KPIN_TIPE AND KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM ='" & TxtPetik(LblProsesKodeItem.Text) & "'")
    'Call DeaktifProsesNorma()
    ' End Sub

    Protected Sub LBKerjaA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVProses.SelectedIndexChanged
        LblProsesKodeItem.Text = (LVProses.DataKeys(LVProses.SelectedIndex).Value.ToString)
        'Call GetData_MASTERKPIProses("SELECT * FROM TRXN_KPIDD,DATA_KPIN WHERE KPI_KODEITEM=KPIN_TIPE AND KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM ='" & TxtPetik(LblProsesKodeItem.Text) & "'")
        'Call DeaktifProses()
        Dim mKodeSub As String = ""
        LblProsesKodeItem.Text = (LVProses.DataKeys(LVProses.SelectedIndex).Value.ToString)
        mKodeSub = GetNo_Tipe2("SELECT * FROM DATA_KPIN WHERE KPIN_TIPE='" & LblProsesKodeItem.Text & "'")
        If FoundRecord_Tabel("SELECT * FROM TRXN_KPIDD WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM like '" & mKodeSub & "%'") = 0 Then

            Call Insert_TabelKPIN("SELECT * FROM DATA_KPIN WHERE KPIN_TIPE like '" & mKodeSub & "%' AND KPIN_LEVEL like '%" & subJabatan.Text & "%' order by kpin_tipe")
        End If
        Call DeaktifProsesNorma()
        MultiViewProsesEntry2.ActiveViewIndex = -1
    End Sub

    Protected Sub LvProses2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvProses2.SelectedIndexChanged
        LblProsesKodeItem2.Text = (LvProses2.DataKeys(LvProses2.SelectedIndex).Value.ToString)

        If LblProsesKodeItem.Text = "PR10" Then
            If LblUserName.Text = TxtHead.Text Then
                Call GetData_MASTERKPIProses2("SELECT * FROM TRXN_KPIDD,DATA_KPIN WHERE KPI_KODEITEM=KPIN_TIPE AND KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM ='" & TxtPetik(LblProsesKodeItem2.Text) & "'")
                Call GetData_NilaiBawahan("select avg(cast(kpin_nilai as int)*10) as nilai_bawahan from trxn_kpin where KPIN_ATASAN = '" & TxtStaffNama.Text & "' and kpin_kode <> '017' and kpin_tahun = '" & TxtKpiSummaryTahun.Text & "'")
                Call inputNilaiProses()
            ElseIf LblUserName.Text = TxtHead2.Text Then
                Call GetData_MASTERKPIProses2("SELECT * FROM TRXN_KPIDD,DATA_KPIN WHERE KPI_KODEITEM=KPIN_TIPE AND KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM ='" & TxtPetik(LblProsesKodeItem2.Text) & "'")
                Call GetData_NilaiBawahan("select avg(cast(kpin_nilai as int)*10) as nilai_bawahan from trxn_kpin where  KPIN_ATASAN = '" & TxtStaffNama.Text & "' and kpin_kode <> '017' and kpin_tahun = '" & TxtKpiSummaryTahun.Text & "'")
                Call inputNilaiProses()
            Else
                Response.Write("<script>alert('Anda tidak memiliki akses untuk merubah nilai Kepemimpinan!')</script>")
                Call DeaktifProsesNorma()
                MultiViewProsesEntry2.ActiveViewIndex = -1
            End If
        Else
            Call GetData_MASTERKPIProses("SELECT * FROM TRXN_KPIDD,DATA_KPIN WHERE KPI_KODEITEM=KPIN_TIPE AND KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM ='" & TxtPetik(LblProsesKodeItem2.Text) & "'")
            Call inputNilaiProses()
        End If
    End Sub

    Sub inputNilaiProses()
        Call DeaktifProsesNorma()
        MultiViewProsesEntry.ActiveViewIndex = 0
        prosesHeader.Visible = False
        MultiViewProsesEntry2.ActiveViewIndex = 0
        kembaliProses.Visible = False
        If LblProsesKodeItem2.Text = "B14" Then
            ket1.Text = "Di atas 100%"
            ket2.Text = "100% target"
            ket3.Text = "90% target"
            ket4.Text = "70% target"
            ket5.Text = "Di bawah 60%"
        Else
            ket1.Text = "Memuaskan"
            ket2.Text = "Sangat Mampu"
            ket3.Text = "Mampu"
            ket4.Text = "Kurang Mampu"
            ket5.Text = "Sangat Kurang Mampu"
        End If
    End Sub
    Protected Sub BtnKpi42ASave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi42ASave.Click
        'Call UpdateData_Server(EditDataNilaiKPI("A", LblProsesKodeItem.Text, "", TxtProsesStaff.Text, TxtProsesHead.Text, TxtProsesKomentar.Text, TxtProsesKomentar2.Text), "Kpi42A")
        Call UpdateData_Server3("UPDATE TRXN_KPIDD SET KPI_STAFF='" & TxtProsesStaff.Text & "' WHERE KPI_TIPEA='Z' AND KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN ='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM='" & LblProsesKodeItem2.Text & "' AND KPI_KODEITEMM='" & LblProsesKodeItem.Text & "'")
        LvProses2.DataBind()
        Call DeaktifProsesNorma()
        MultiViewProsesEntry2.ActiveViewIndex = -1
        kembaliProses.Visible = True
        prosesHeader.Visible = True
        TxtProsesStaff.SelectedIndex = -1
        'MultiViewKpiMasterEntry.ActiveViewIndex = 0
        'Call ClikDetail_MultiViewKpiMaster()

        'Call hitunghasil()
    End Sub

    Protected Sub KembaliProses_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles kembaliProses.Click
        'Call UpdateData_Server(EditDataNilaiKPI("A", LblProsesKodeItem.Text, "", TxtProsesStaff.Text, TxtProsesHead.Text, TxtProsesKomentar.Text, TxtProsesKomentar2.Text), "Kpi42A")
        'Call UpdateData_Server3("UPDATE TRXN_KPIDD SET KPI_STAFF='" & TxtProsesStaff.Text & "' WHERE KPI_TIPEA='Z' AND KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN ='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM='" & LblProsesKodeItem2.Text & "' AND KPI_KODEITEMM='" & LblProsesKodeItem.Text & "'")
        Call hitungproses()
        LVProses.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = 0
        Call ClikDetail_MultiViewKpiMaster()
        Call GetData_NILAIB("select round(avg(KPI_ATASAN),2) AS TOTAL_NILAI2 from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='A' AND KPI_NIK='" & TxtStaffNIK.Text & "' ")
        'Call ClikDetail_MultiViewKpiMaster()
        'Call DeaktifProsesNorma()
        'MultiViewProsesEntry2.ActiveViewIndex = -1
        'MultiViewKpiMasterEntry.ActiveViewIndex = 0
        'Call ClikDetail_MultiViewKpiMaster()

        'Yang tampil nanti
        '
        '


        'Call hitunghasil()
    End Sub

    Protected Sub BtnProsesAtasan1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnProsesAtasan1.Click
        If TxtProsesStaff.Text <> TxtProsesHead.Text And TxtProsesKomentar.Text = "" And LblUserName.Text <> "Santo" Then
            LblErrorSaveKpi42A.Text = "Atasan Wajib Memberikan Komentar Kenapa Nilai Yang Diberikan Berbeda Dengan Nilai Staff!"
            MultiViewKpiMaster.ActiveViewIndex = -1
        Else
            Call UpdateData_Server3("UPDATE TRXN_KPIDD SET KPI_ATASAN='" & TxtProsesHead.Text & "', KPI_KOMENTAR= '" & TxtProsesKomentar.Text & "' WHERE KPI_TIPEA='Z' AND KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN ='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM='" & LblProsesKodeItem2.Text & "'")
            'Call UpdateData_Server(EditDataNilaiKPI("A", LblProsesKodeItem.Text, "", TxtProsesStaff.Text, TxtProsesHead.Text, TxtProsesKomentar.Text, TxtProsesKomentar2.Text), "Kpi42A")
            LvProses2.DataBind()
            Call DeaktifProsesNorma()
            MultiViewProsesEntry2.ActiveViewIndex = -1
            kembaliProses.Visible = True
            prosesHeader.Visible = True
            TxtProsesHead.SelectedIndex = -1
            TxtProsesKomentar.Text = ""
        End If

    End Sub

    Protected Sub BtnProsesAtasan2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnProsesAtasan2.Click
        If LblProsesHead.Text <> TxtProsesHead.Text And TxtProsesKomentar2.Text = "" And LblUserName.Text <> "Santo" Then
            LblErrorSaveKpi42A.Text = "Atasan Wajib Memberikan Komentar Kenapa Nilai Yang Diberikan oleh Atasan Langsung Anda Rubah!"
            MultiViewKpiMaster.ActiveViewIndex = -1
        Else
            Call UpdateData_Server3("UPDATE TRXN_KPIDD SET KPI_ATASAN='" & TxtProsesHead.Text & "', KPI_KOMENTAR2= '" & TxtProsesKomentar2.Text & "' WHERE KPI_TIPEA='Z' AND KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN ='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM='" & LblProsesKodeItem2.Text & "'")
            'Call UpdateData_Server(EditDataNilaiKPI("A", LblProsesKodeItem.Text, "", TxtProsesStaff.Text, TxtProsesHead.Text, TxtProsesKomentar.Text, TxtProsesKomentar2.Text), "Kpi42A")
            LvProses2.DataBind()
            Call DeaktifProsesNorma()
            MultiViewProsesEntry2.ActiveViewIndex = -1
            kembaliProses.Visible = True
            prosesHeader.Visible = True
            TxtProsesHead.SelectedIndex = -1
            TxtProsesKomentar.Text = ""
        End If
    End Sub

    '42B

    Sub ClearTabelKPIKerjaB()
        LblPeopleJudul.Text = ""
        LblPeopleKode.Text = ""
        TxtPeopleStaff.Text = ""
        TxtPeopleAtasan.Text = ""
        TxtPeopleKomentar.Text = ""
    End Sub
    Protected Sub LBKerjaB_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVPeople.SelectedIndexChanged
        LblPeopleKode.Text = (LVPeople.DataKeys(LVPeople.SelectedIndex).Value.ToString)
        Call GetData_Bawahan("select avg(cast(kpin_nilai as int)*10) as nilai_bawahan from trxn_kpin, data_natasan where kpin_kode = natasan_kode and KPIN_ATASAN = '" & TxtStaffNama.Text & "' and kpin_tahun = '" & TxtKpiSummaryTahun.Text & "' and kpin_group=natasan_group and natasan_subgroup = '" & TxtPetik(LblPeopleKode.Text) & "'")
        Call GetData_MASTERKPIPeople("SELECT * FROM TRXN_KPIDD, DATA_KPIN WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM ='" & TxtPetik(LblPeopleKode.Text) & "' AND KPIN_TIPE=KPI_KODEITEM")
        Call DeaktifPeople()
    End Sub
    Protected Sub BtnKpi42BSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi42BSave.Click
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'PENILAIAN KARYAWAN -- PENILAIAN ATASAN KE BAWAHAN'") = 1 And LblUserName.Text = TxtHead.Text Then
            If TxtPeopleStaff.Text <> TxtPeopleAtasan.Text And TxtPeopleKomentar.Text = "" And LblUserName.Text <> "Santo" Then
                LblErrorSaveKpi42B.Text = "Atasan Wajib Memberikan Komentar Kenapa Nilai Yang Diberikan Berbeda Dengan Nilai Staff!"
                MultiViewKpiMaster.ActiveViewIndex = -1
            Else
                Call UpdateData_Server(EditDataNilaiKPI("C", LblPeopleKode.Text, "", TxtPeopleStaff.Text, TxtPeopleAtasan.Text, TxtPeopleKomentar.Text, ""), "Kpi42A")
                LVPeople.DataBind()
                MultiViewKpiMasterEntry.ActiveViewIndex = 0
                Call ClikDetail_MultiViewKpiMaster()
                Call hitunghasil()
            End If
        Else
            Call UpdateData_Server(EditDataNilaiKPI("C", LblPeopleKode.Text, "", TxtPeopleStaff.Text, TxtPeopleAtasan.Text, TxtPeopleKomentar.Text, ""), "Kpi42A")
            LVPeople.DataBind()
            MultiViewKpiMasterEntry.ActiveViewIndex = 0
            Call ClikDetail_MultiViewKpiMaster()
            Call hitunghasil()
        End If

    End Sub


    Sub clearnilaiOthers()
        TxtKpiTotalNilai1.Text = "0"
        TxtKpiTotalNilai2.Text = "0"
        TxtKpiTotalNilai3.Text = "0"
        LblNiaiAkhir1.Text = "0"
        LblNiaiAkhir2.Text = "0"
        LblNiaiAkhir3.Text = "0"
        LblNiaiAkhir4.Text = "0"
        hasilakhir.Text = "0"
        TxtNilaiSP.Text = "0"
        Call GetData_MASTEROthers("SELECT * FROM TRXN_KPIH WHERE KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'")
    End Sub
    Protected Sub BtnResetVerifikasiHead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnResetVerifikasiHead.Click
        If TxtKpiSummaryPosA.Text = "D" Then

            Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                    "KPIH_APPVHEADTGL = NULL " & _
                                    "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
            Call UpdateData_Server(mSqlCommand, "Kpi44")
        ElseIf TxtKpiSummaryPosA.Text = "A" Or TxtKpiSummaryPosA.Text = "B" Or TxtKpiSummaryPosA.Text = "C" Or TxtKpiSummaryPosA.Text = "E" Then

            Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                    "KPIH_APPVHEADTGL = NULL " & _
                                    "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
            Call UpdateData_Server(mSqlCommand, "Kpi44")
        End If
        Response.Write("<script>alert('Anda telah sukses melakukan reset Verifikasi Atasan Langsung untuk PK ini!')</script>")
        Response.Write("<script>window.location.href='HRDPENILAIANKARYAWAN.aspx?no=" + TxtStaffNIK.Text + "';</script>")
    End Sub

    Protected Sub BtnResetDeadline_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnResetDeadline.Click

        If TxtDeadlineAtasan2.Text = "" Then
            Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET KPIH_DEADLINEPK = '" & TxtDeadlinePK.Text & "', KPIH_DEADLINEATASAN = '" & TxtDeadlineAtasan.Text & "' WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
            Call UpdateData_Server(mSqlCommand, "Kpi44")
        Else
            Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET KPIH_DEADLINEPK = '" & TxtDeadlinePK.Text & "', KPIH_DEADLINEATASAN = '" & TxtDeadlineAtasan.Text & "', KPIH_DEADLINEATASAN2 = '" & TxtDeadlineAtasan2.Text & "' WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
            Call UpdateData_Server(mSqlCommand, "Kpi44")
        End If
        Response.Write("<script>alert('Anda telah sukses melakukan perubahan Tanggal Deadline untuk Karyawan ini!')</script>")
        Response.Write("<script>window.location.href='HRDPENILAIANKARYAWAN.aspx?no=" + TxtStaffNIK.Text + "';</script>")
    End Sub

    Protected Sub BtnKpi40MasterReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40MasterReset.Click
        If TxtKpiSummaryPosA.Text = "D" Then

            Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                    "KPIH_NILAI = NULL," & _
                                    "KPIH_NILAI1 = NULL," & _
                                    "KPIH_NILAI2 = NULL," & _
                                    "KPIH_KETERANGAN = NULL," & _
                                    "KPIH_APPVUSER = NULL," & _
                                    "KPIH_APPVUSERTGL = NULL," & _
                                    "KPIH_APPVHEADTGL = NULL," & _
                                    "KPIH_APPVHEADTGL2 = NULL " & _
                                    "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
            Call UpdateData_Server(mSqlCommand, "Kpi44")
        ElseIf TxtKpiSummaryPosA.Text = "A" Or TxtKpiSummaryPosA.Text = "B" Or TxtKpiSummaryPosA.Text = "C" Or TxtKpiSummaryPosA.Text = "E" Then

            Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                    "KPIH_NILAI = NULL," & _
                                    "KPIH_NILAI1 = NULL," & _
                                    "KPIH_NILAI2 = NULL," & _
                                    "KPIH_NILAI3 = NULL," & _
                                    "KPIH_KETERANGAN = NULL," & _
                                    "KPIH_APPVUSER = NULL," & _
                                    "KPIH_APPVUSERTGL = NULL," & _
                                    "KPIH_APPVHEADTGL = NULL," & _
                                    "KPIH_APPVHEADTGL2 = NULL " & _
                                    "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
            Call UpdateData_Server(mSqlCommand, "Kpi44")
        End If
        Response.Write("<script>alert('Anda telah sukses melakukan reset PK!')</script>")
        Response.Write("<script>window.location.href='HRDPENILAIANKARYAWAN.aspx?no=" + TxtStaffNIK.Text + "';</script>")
    End Sub
    Protected Sub BtnKpi44Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi44Setuju1.Click
        If GetFindRecord_Server2("select kpi_staff, KPI_KODEITEMM, KPIN_JUDUL from trxn_kpidd, data_kpin where (kpi_staff is null or kpi_staff = 0) and kpi_kodeitem like 'PR%' and kpi_nik='" & TxtStaffNIK.Text & "' and kpi_tahun='" & TxtKpiSummaryTahun.Text & "' and KPIN_TIPE=KPI_KODEITEMM") = 1 Then
            Response.Write("<script>alert('Anda Penilaian Item Proses Yang Belum Anda Isi dibagian " + TxtNotif.Text + ", Silahkan di cek kembali!')</script>")
            MultiViewKpiMasterEntry.ActiveViewIndex = 0
            Call ClikDetail_MultiViewKpiMaster()
        ElseIf GetFindRecord_Server2("select kpi_staff, KPI_KODEITEMM, KPIN_JUDUL from trxn_kpidd, data_kpin where (kpi_staff = 0 or kpi_staff is null)  and kpi_kodeitem like 'HD%' and kpi_nik='" & TxtStaffNIK.Text & "' and kpi_tahun='" & TxtKpiSummaryTahun.Text & "' and KPIN_TIPE=KPI_KODEITEM") = 1 Then
            Response.Write("<script>alert('Anda Penilaian Item People Management Yang Belum Anda Isi dibagian " + TxtNotif.Text + ", Silahkan di cek kembali!')</script>")
            MultiViewKpiMasterEntry.ActiveViewIndex = 0
            Call ClikDetail_MultiViewKpiMaster()
        Else
            If TxtKpiSummaryPosA.Text = "D" Then

                Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                    "KPIH_NILAI = " & hasilakhir.Text & "," & _
                                    "KPIH_NILAI1 = " & LblNiaiAkhir1.Text & "," & _
                                    "KPIH_NILAI2 = " & LblNiaiAkhir2.Text & "," & _
                                    "KPIH_KETERANGAN = '" & txtKategori.Text & "'," & _
                                    "KPIH_APPVUSER = '" & TxtStaffNama.Text & "'," & _
                                    "KPIH_APPVUSERTGL = '" & Now() & "' " & _
                                    "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
                Call UpdateData_Server(mSqlCommand, "Kpi44")

            ElseIf TxtKpiSummaryPosA.Text = "A" Or TxtKpiSummaryPosA.Text = "B" Or TxtKpiSummaryPosA.Text = "C" Or TxtKpiSummaryPosA.Text = "E" Then

                Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                    "KPIH_NILAI = " & hasilakhir.Text & "," & _
                                    "KPIH_NILAI1 = " & LblNiaiAkhir1.Text & "," & _
                                    "KPIH_NILAI2 = " & LblNiaiAkhir2.Text & "," & _
                                    "KPIH_NILAI3 = " & LblNiaiAkhir3.Text & "," & _
                                    "KPIH_KETERANGAN = '" & txtKategori.Text & "'," & _
                                    "KPIH_APPVUSER = '" & TxtStaffNama.Text & "'," & _
                                    "KPIH_APPVUSERTGL = '" & Now() & "' " & _
                                    "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
                Call UpdateData_Server(mSqlCommand, "Kpi44")
            End If
            Call emailatasanlangsung("select distinct emaildivisi from divisi where headdivisi = '" & TxtHead.Text & "'")
            Response.Write("<script>alert('Anda telah sukses melakukan verifikasi PK!')</script>")
        End If
        Response.Write("<script>window.location.href='HRDPENILAIANKARYAWAN.aspx';</script>")
    End Sub
    Protected Sub BtnKpi44Setuju2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi44Setuju2.Click
        If GetFindRecord_Server2("select kpi_atasan, KPI_KODEITEMM, KPIN_JUDUL from trxn_kpidd, DATA_KPIN where (kpi_atasan is null or kpi_atasan = 0) and kpi_kodeitem like 'PR%' and kpi_nik='" & TxtStaffNIK.Text & "' and kpi_tahun='" & TxtKpiSummaryTahun.Text & "' and KPIN_TIPE=KPI_KODEITEMM") = 1 Then
            Response.Write("<script>alert('Anda Penilaian Item Proses Yang Belum Anda Isi dibagian " + TxtNotif.Text + ", Silahkan di cek kembali!')</script>")
            MultiViewKpiMasterEntry.ActiveViewIndex = 0
            Call ClikDetail_MultiViewKpiMaster()
        ElseIf GetFindRecord_Server2("select kpi_atasan, KPI_KODEITEMM, KPIN_JUDUL from trxn_kpidd, data_kpin where (kpi_atasan = 0 or kpi_atasan is null)  and kpi_kodeitem like 'HD%' and kpi_nik='" & TxtStaffNIK.Text & "' and kpi_tahun='" & TxtKpiSummaryTahun.Text & "' and KPIN_TIPE=KPI_KODEITEM") = 1 Then
            Response.Write("<script>alert('Anda Penilaian Item People Management Yang Belum Anda Isi dibagian " + TxtNotif.Text + ", Silahkan di cek kembali!')</script>")
            MultiViewKpiMasterEntry.ActiveViewIndex = 0
            Call ClikDetail_MultiViewKpiMaster()
        Else
            If TxtKpiSummaryPosA.Text = "D" Then

                Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                        "KPIH_NILAI = " & hasilakhir.Text & "," & _
                                        "KPIH_NILAI1 = " & LblNiaiAkhir1.Text & "," & _
                                        "KPIH_NILAI2 = " & LblNiaiAkhir2.Text & "," & _
                                        "KPIH_KETERANGAN = '" & txtKategori.Text & "'," & _
                                        "KPIH_APPVHEADTGL = '" & Now() & "'" & _
                                        "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
                Call UpdateData_Server(mSqlCommand, "Kpi44")
            ElseIf TxtKpiSummaryPosA.Text = "A" Or TxtKpiSummaryPosA.Text = "B" Or TxtKpiSummaryPosA.Text = "C" Or TxtKpiSummaryPosA.Text = "E" Then
                Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                     "KPIH_NILAI = " & hasilakhir.Text & "," & _
                                     "KPIH_NILAI1 = " & LblNiaiAkhir1.Text & "," & _
                                     "KPIH_NILAI2 = " & LblNiaiAkhir2.Text & "," & _
                                     "KPIH_NILAI3 = " & LblNiaiAkhir3.Text & "," & _
                                     "KPIH_KETERANGAN = '" & txtKategori.Text & "'," & _
                                     "KPIH_APPVHEADTGL = '" & Now() & "'" & _
                                     "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
                Call UpdateData_Server(mSqlCommand, "Kpi44")
            End If
            If TxtHead2.Text <> "" Then
                Call emailatasanlangsung("select distinct emaildivisi from  divisi where headdivisi = '" & TxtHead2.Text & "'")
			else
				Call emailKPI("select staff_email from data_staff where staff_nik ='" & TxtStaffNIK.Text & "'")
			End If
            Call emailatasanlangsungselesai("select staff_email from data_staff where staff_nik ='" & TxtStaffNIK.Text & "'")
			Response.Write("<script>alert('Anda telah sukses melakukan verifikasi PK!')</script>")
            Response.Write("<script>window.location.href='HRDPENILAIANBAWAHAN.aspx';</script>")
        End If
    End Sub

    Protected Sub BtnKpi44Setuju3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi44Setuju3.Click
        If GetFindRecord_Server2("select kpi_atasan, KPI_KODEITEMM, KPIN_JUDUL from trxn_kpidd, DATA_KPIN where (kpi_atasan is null or kpi_atasan = 0) and kpi_kodeitem like 'PR%' and kpi_nik='" & TxtStaffNIK.Text & "' and kpi_tahun='" & TxtKpiSummaryTahun.Text & "' and KPIN_TIPE=KPI_KODEITEMM") = 1 Then
            Response.Write("<script>alert('Anda Penilaian Item Proses Yang Belum Anda Isi dibagian " + TxtNotif.Text + ", Silahkan di cek kembali!')</script>")
            MultiViewKpiMasterEntry.ActiveViewIndex = 0
            Call ClikDetail_MultiViewKpiMaster()
        ElseIf GetFindRecord_Server2("select kpi_atasan, KPI_KODEITEMM, KPIN_JUDUL from trxn_kpidd, Data_KPIN where (kpi_atasan = 0 or kpi_atasan is null)  and kpi_kodeitem like 'HD%' and kpi_nik='" & TxtStaffNIK.Text & "' and kpi_tahun='" & TxtKpiSummaryTahun.Text & "' and KPIN_TIPE=KPI_KODEITEM") = 1 Then
            Response.Write("<script>alert('Anda Penilaian Item People Management Yang Belum Anda Isi dibagian " + TxtNotif.Text + ", Silahkan di cek kembali!')</script>")
            MultiViewKpiMasterEntry.ActiveViewIndex = 0
            Call ClikDetail_MultiViewKpiMaster()
        Else
            If TxtKpiSummaryPosA.Text = "D" Then
                Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                        "KPIH_NILAI = " & hasilakhir.Text & "," & _
                                        "KPIH_NILAI1 = " & LblNiaiAkhir1.Text & "," & _
                                        "KPIH_NILAI2 = " & LblNiaiAkhir2.Text & "," & _
                                        "KPIH_KETERANGAN = '" & txtKategori.Text & "'," & _
                                        "KPIH_APPVHEADTGL2 = '" & Now() & "'" & _
                                        "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
                Call UpdateData_Server(mSqlCommand, "Kpi44")
            ElseIf TxtKpiSummaryPosA.Text = "A" Or TxtKpiSummaryPosA.Text = "B" Or TxtKpiSummaryPosA.Text = "C" Or TxtKpiSummaryPosA.Text = "E" Then
                Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                     "KPIH_NILAI = " & hasilakhir.Text & "," & _
                                     "KPIH_NILAI1 = " & LblNiaiAkhir1.Text & "," & _
                                     "KPIH_NILAI2 = " & LblNiaiAkhir2.Text & "," & _
                                     "KPIH_NILAI3 = " & LblNiaiAkhir3.Text & "," & _
                                     "KPIH_KETERANGAN = '" & txtKategori.Text & "'," & _
                                     "KPIH_APPVHEADTGL2 = '" & Now() & "'" & _
                                     "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
                Call UpdateData_Server(mSqlCommand, "Kpi44")
            End If
            Call emailatasandariatasanlangsungselesai("select staff_email from data_staff where staff_nik ='" & TxtStaffNIK.Text & "'")
            Call emailKPI("select staff_email from data_staff where staff_nik ='" & TxtStaffNIK.Text & "'")
			Response.Write("<script>alert('Anda telah sukses melakukan verifikasi PK!')</script>")
            Response.Write("<script>window.location.href='HRDPENILAIANKARYAWAN.aspx';</script>")
        End If
    End Sub


    Protected Sub BtnKpi44Setuju4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi44Setuju4.Click
        If TxtKpiSummaryPosA.Text = "D" Then

            Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                    "KPIH_NILAI = " & hasilakhir.Text & "," & _
                                    "KPIH_NILAI1 = " & LblNiaiAkhir1.Text & "," & _
                                    "KPIH_NILAI2 = " & LblNiaiAkhir2.Text & "," & _
                                    "KPIH_KETERANGAN = '" & txtKategori.Text & "'," & _
                                    "KPIH_APPVHRDTGL = '" & Now() & "'" & _
                                    "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
            Call UpdateData_Server(mSqlCommand, "Kpi44")
        ElseIf TxtKpiSummaryPosA.Text = "A" Or TxtKpiSummaryPosA.Text = "B" Or TxtKpiSummaryPosA.Text = "C" Or TxtKpiSummaryPosA.Text = "E" Then
            Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                 "KPIH_NILAI = " & hasilakhir.Text & "," & _
                                 "KPIH_NILAI1 = " & LblNiaiAkhir1.Text & "," & _
                                 "KPIH_NILAI2 = " & LblNiaiAkhir2.Text & "," & _
                                 "KPIH_NILAI3 = " & LblNiaiAkhir3.Text & "," & _
                                 "KPIH_KETERANGAN = '" & txtKategori.Text & "'," & _
                                 "KPIH_APPVHRDTGL = '" & Now() & "'" & _
                                 "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
            Call UpdateData_Server(mSqlCommand, "Kpi44")
        End If
        Call emailHRDSelesai("select staff_email from data_staff where staff_nik ='" & TxtStaffNIK.Text & "'")
        Response.Write("<script>alert('Anda telah sukses melakukan verifikasi PK!')</script>")
        Response.Write("<script>window.location.href='HRDPENILAIANKARYAWAN.aspx';</script>")
    End Sub

    Protected Sub ButtonRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRefresh.Click
        If TxtKpiSummaryPosA.Text = "D" Then
            Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                    "KPIH_NILAI = " & hasilakhir.Text & "," & _
                                    "KPIH_NILAI1 = " & LblNiaiAkhir1.Text & "," & _
                                    "KPIH_NILAI2 = " & LblNiaiAkhir2.Text & "," & _
                                    "KPIH_KETERANGAN = '" & txtKategori.Text & "' " & _
                                    "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
            Call UpdateData_Server(mSqlCommand, "Kpi44")
        ElseIf TxtKpiSummaryPosA.Text = "A" Or TxtKpiSummaryPosA.Text = "B" Or TxtKpiSummaryPosA.Text = "C" Or TxtKpiSummaryPosA.Text = "E" Then
            Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                 "KPIH_NILAI = " & hasilakhir.Text & "," & _
                                 "KPIH_NILAI1 = " & LblNiaiAkhir1.Text & "," & _
                                 "KPIH_NILAI2 = " & LblNiaiAkhir2.Text & "," & _
                                 "KPIH_NILAI3 = " & LblNiaiAkhir3.Text & "," & _
                                 "KPIH_KETERANGAN = '" & txtKategori.Text & "' " & _
                                 "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
            Call UpdateData_Server(mSqlCommand, "Kpi44")
        End If
        Response.Write("<script>window.location.href='HRDREPORTPENILAIANKARYAWAN.aspx';</script>")
    End Sub
    '============End Hal 4

    '============ Hak Akses
    Sub HakLihatPK()
        MultiViewAkses.ActiveViewIndex = 0
        MultiViewKpiMaster.ActiveViewIndex = 0
    End Sub

    Sub DeaktifTabel1()
        MultiViewKpiMaster.ActiveViewIndex = 0 : LvKpiMasterSummary.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = -1

        MultiViewKPIMasterDetail.ActiveViewIndex = -1
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1

        MultiViewProsesTabel.ActiveViewIndex = -1
        MultiViewProsesEntry.ActiveViewIndex = -1

        MultiViewPeopleTabel.ActiveViewIndex = -1
        MultiViewPeopleEntry.ActiveViewIndex = -1

        MultiViewDisiplin.ActiveViewIndex = -1

        MultiViewOthers.ActiveViewIndex = -1
        '=============
    End Sub

    Sub DeaktifTabel2()

        MultiViewKpiMaster.ActiveViewIndex = -1 : LvKpiMasterSummary.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = -1

        MultiViewKPIMasterDetail.ActiveViewIndex = -1
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1

        MultiViewProsesTabel.ActiveViewIndex = -1
        MultiViewProsesEntry.ActiveViewIndex = -1

        MultiViewPeopleTabel.ActiveViewIndex = -1
        MultiViewPeopleEntry.ActiveViewIndex = -1

        MultiViewDisiplin.ActiveViewIndex = -1

        MultiViewOthers.ActiveViewIndex = -1
        '=============
    End Sub

    Sub DeaktifRaport()

        MultiViewKpiMaster.ActiveViewIndex = -1 : LvKpiMasterSummary.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = -1

        MultiViewKPIMasterDetail.ActiveViewIndex = -1
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = 0

        MultiViewProsesTabel.ActiveViewIndex = -1
        MultiViewProsesEntry.ActiveViewIndex = -1

        MultiViewPeopleTabel.ActiveViewIndex = -1
        MultiViewPeopleEntry.ActiveViewIndex = -1

        MultiViewDisiplin.ActiveViewIndex = -1

        MultiViewOthers.ActiveViewIndex = -1
        '=============
    End Sub

    Sub DeaktifProses()

        MultiViewKpiMaster.ActiveViewIndex = -1 : LvKpiMasterSummary.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = -1

        MultiViewKPIMasterDetail.ActiveViewIndex = -1
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1

        MultiViewProsesTabel.ActiveViewIndex = -1
        MultiViewProsesEntry.ActiveViewIndex = 0

        MultiViewPeopleTabel.ActiveViewIndex = -1
        MultiViewPeopleEntry.ActiveViewIndex = -1

        MultiViewDisiplin.ActiveViewIndex = -1

        MultiViewOthers.ActiveViewIndex = -1
        '=============
    End Sub

    Sub DeaktifProsesNorma()
        formProses.Visible = True
        MultiViewKpiMaster.ActiveViewIndex = -1 : LvKpiMasterSummary.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = -1

        MultiViewKPIMasterDetail.ActiveViewIndex = -1
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1

        MultiViewProsesTabel.ActiveViewIndex = -1
        MultiViewProsesEntry.ActiveViewIndex = 0

        MultiViewPeopleTabel.ActiveViewIndex = -1
        MultiViewPeopleEntry.ActiveViewIndex = -1

        MultiViewDisiplin.ActiveViewIndex = -1

        MultiViewOthers.ActiveViewIndex = -1
        '=============
    End Sub

    Sub DeaktifDisiplin()

        MultiViewKpiMaster.ActiveViewIndex = -1 : LvKpiMasterSummary.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = -1

        MultiViewKPIMasterDetail.ActiveViewIndex = -1
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1

        MultiViewProsesTabel.ActiveViewIndex = -1
        MultiViewProsesEntry.ActiveViewIndex = -1

        MultiViewPeopleTabel.ActiveViewIndex = -1
        MultiViewPeopleEntry.ActiveViewIndex = -1

        MultiViewDisiplin.ActiveViewIndex = -1

        MultiViewOthers.ActiveViewIndex = -1
        '=============
    End Sub

    Sub DeaktifPeople()

        MultiViewKpiMaster.ActiveViewIndex = -1 : LvKpiMasterSummary.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = -1

        MultiViewKPIMasterDetail.ActiveViewIndex = -1
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1

        MultiViewProsesTabel.ActiveViewIndex = -1
        MultiViewProsesEntry.ActiveViewIndex = -1

        MultiViewPeopleTabel.ActiveViewIndex = -1
        MultiViewPeopleEntry.ActiveViewIndex = 0

        MultiViewDisiplin.ActiveViewIndex = -1

        MultiViewOthers.ActiveViewIndex = -1
        '=============
    End Sub

    Sub ClikDetail_MultiViewKpiMaster()

        MultiViewKpiMaster.ActiveViewIndex = -1
        MultiViewKPIMasterDetail.ActiveViewIndex = 0 : MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1 : LvKPIMasterDetail.DataBind()

        If TxtKpiSummaryPosA.Text = "A" Or TxtKpiSummaryPosA.Text = "B" Then
            'Karyawan

            MultiViewProsesTabel.ActiveViewIndex = 0 : MultiViewProsesEntry.ActiveViewIndex = -1 : LVProses.DataBind()
            MultiViewPeopleTabel.ActiveViewIndex = -1 : MultiViewPeopleEntry.ActiveViewIndex = -1
            MultiViewDisiplin.ActiveViewIndex = 0 : LvDisiplin.DataBind()

        ElseIf TxtKpiSummaryPosA.Text = "C" Then
            'Manager

            MultiViewProsesTabel.ActiveViewIndex = 0 : MultiViewProsesEntry.ActiveViewIndex = -1 : LVProses.DataBind()
            MultiViewPeopleTabel.ActiveViewIndex = -1 : MultiViewPeopleEntry.ActiveViewIndex = -1
            MultiViewDisiplin.ActiveViewIndex = 0 : LvDisiplin.DataBind()
        ElseIf TxtKpiSummaryPosA.Text = "D" Then
            'SPV No Team

            MultiViewProsesTabel.ActiveViewIndex = 0 : MultiViewProsesEntry.ActiveViewIndex = -1 : LVProses.DataBind()
            MultiViewPeopleTabel.ActiveViewIndex = -1 : MultiViewPeopleEntry.ActiveViewIndex = -1
            MultiViewDisiplin.ActiveViewIndex = -1 : LvDisiplin.DataBind()
        ElseIf TxtKpiSummaryPosA.Text = "E" Then
            'SPV Team

            MultiViewProsesTabel.ActiveViewIndex = 0 : MultiViewProsesEntry.ActiveViewIndex = -1 : LVProses.DataBind()
            MultiViewPeopleTabel.ActiveViewIndex = 0 : MultiViewPeopleEntry.ActiveViewIndex = -1
            MultiViewDisiplin.ActiveViewIndex = -1 : LvDisiplin.DataBind()
        End If
        MultiViewOthers.ActiveViewIndex = 0
    End Sub

    Sub lockkaryawan()
        Dim Datenow As Date = DateTime.Now.ToString("yyyy-MM-dd")
        'Jika user belum melakukan verifikasi
        If GetFindRecord_Server("SELECT * FROM TRXN_KPIH WHERE KPIH_APPVUSERTGL IS NULL AND  KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'") = 1 And TxtHead.Text <> LblUserName.Text And lblDeadlinePK.Text >= Datenow Then
            'KPI
            BtnKpi40Save.Visible = True

            'Proses
            kembaliProses.Visible = True
            BtnKpi42ASave.Visible = True
            BtnProsesAtasan1.Visible = False
            BtnProsesAtasan2.Visible = False
            TxtProsesStaff.Visible = True
            LblProsesStaff.Visible = False
            TxtProsesHead.Visible = False
            TxtProsesKomentar.ReadOnly = True
            TxtProsesKomentar2.ReadOnly = True

            'Halaman People Management
            BtnKpi42BSave.Visible = True
            nilaiBawahan.Visible = False
            TxtPeopleAtasan.ReadOnly = True
            TxtPeopleKomentar.ReadOnly = True

            BtnKpi44Setuju1.Visible = True
            BtnKpi44Setuju2.Visible = False
            BtnKpi44Setuju3.Visible = False

        Else
            'KPI
            BtnKpi40Save.Visible = False

            'Proses
            kembaliProses.Visible = False
            BtnKpi42ASave.Visible = False
            BtnProsesAtasan1.Visible = False
            BtnProsesAtasan2.Visible = False
            TxtProsesStaff.Visible = False
            LblProsesStaff.Visible = False
            TxtProsesHead.Visible = False
            TxtProsesKomentar.ReadOnly = True
            TxtProsesKomentar2.ReadOnly = True

            'Halaman People Management
            BtnKpi42BSave.Visible = False
            nilaiBawahan.Visible = False
            TxtPeopleAtasan.ReadOnly = True
            TxtPeopleKomentar.ReadOnly = True

            BtnKpi44Setuju1.Visible = False
            BtnKpi44Setuju2.Visible = False
            BtnKpi44Setuju3.Visible = False
        End If
    End Sub

    Sub lockatasan()
        Dim Datenow As Date = DateTime.Now.ToString("yyyy-MM-dd")
        'Jika staff sudah verifikasi
        If GetFindRecord_Server("SELECT * FROM TRXN_KPIH WHERE KPIH_APPVUSER IS NOT NULL AND KPIH_APPVUSERTGL IS NOT NULL AND KPIH_APPVHEADTGL IS NULL AND KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'") = 1 And TxtHead.Text = LblUserName.Text And lblDeadlineAtasan.Text >= Datenow Then
            'KPI
            BtnKpi40Save.Visible = True

            'Proses
            kembaliProses.Visible = True
            BtnKpi42ASave.Visible = False
            BtnProsesAtasan1.Visible = True
            BtnProsesAtasan2.Visible = False
            TxtProsesStaff.Visible = False
            LblProsesStaff.Visible = True
            TxtProsesKomentar2.ReadOnly = True

            'Halaman People Management
            BtnKpi42BSave.Visible = True
            nilaiBawahan.Visible = True

            If subJabatan.Text = "2" Then
                btnShow54.Visible = True
            End If
            If subJabatan.Text = "3" Or subJabatan.Text = "4" Or subJabatan.Text = "5" Then
                btnShow55.Visible = True
            End If

            BtnKpi44Setuju1.Visible = False
            BtnKpi44Setuju2.Visible = True
            BtnKpi44Setuju3.Visible = False
        Else
            'KPI
            BtnKpi40Save.Visible = False

            'Proses
            kembaliProses.Visible = False
            BtnKpi42ASave.Visible = False
            BtnProsesAtasan1.Visible = False
            BtnProsesAtasan2.Visible = False
            TxtProsesStaff.Visible = False
            LblProsesStaff.Visible = False
            TxtProsesKomentar2.ReadOnly = True
            TxtProsesKomentar.ReadOnly = True

            'Halaman People Management
            BtnKpi42BSave.Visible = False
            nilaiBawahan.Visible = False

            If subJabatan.Text = "2" Then
                btnShow54.Visible = True
            End If
            If subJabatan.Text = "3" Or subJabatan.Text = "4" Or subJabatan.Text = "5" Then
                btnShow55.Visible = True
            End If

            BtnKpi44Setuju1.Visible = False
            BtnKpi44Setuju2.Visible = False
            BtnKpi44Setuju3.Visible = False
        End If
    End Sub

    Sub lockatasan2()
        Dim Datenow As Date = DateTime.Now.ToString("yyyy-MM-dd")
        'Jika staff sudah verifikasi
        If GetFindRecord_Server("SELECT * FROM TRXN_KPIH WHERE KPIH_APPVUSER IS NOT NULL AND KPIH_APPVUSERTGL IS NOT NULL AND KPIH_APPVHEADTGL IS NOT NULL AND KPIH_APPVHEADTGL2 IS NULL AND  KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'") = 1 And TxtHead2.Text = LblUserName.Text And lblDeadlineAtasan2.Text >= Datenow Then
            'KPI
            BtnKpi40Save.Visible = True

            'Proses
            kembaliProses.Visible = True
            BtnKpi42ASave.Visible = False
            BtnProsesAtasan1.Visible = False
            BtnProsesAtasan2.Visible = True
            TxtProsesStaff.Visible = False
            LblProsesStaff.Visible = True
            TxtProsesKomentar.ReadOnly = True
            'Halaman People Management
            BtnKpi42BSave.Visible = True
            nilaiBawahan.Visible = True

            If subJabatan.Text = "2" Then
                btnShow54.Visible = True
            End If
            If subJabatan.Text = "3" Or subJabatan.Text = "4" Or subJabatan.Text = "5" Then
                btnShow55.Visible = True
            End If

            BtnKpi44Setuju1.Visible = False
            BtnKpi44Setuju2.Visible = False
            BtnKpi44Setuju3.Visible = True
        Else
            'KPI
            BtnKpi40Save.Visible = False

            'Proses
            kembaliProses.Visible = False
            BtnKpi42ASave.Visible = False
            BtnProsesAtasan1.Visible = False
            BtnProsesAtasan2.Visible = False
            TxtProsesStaff.Visible = False
            LblProsesStaff.Visible = False
            TxtProsesKomentar2.ReadOnly = True
            TxtProsesKomentar.ReadOnly = True

            'Halaman People Management
            BtnKpi42BSave.Visible = False
            nilaiBawahan.Visible = False

            If subJabatan.Text = "2" Then
                btnShow54.Visible = True
            End If
            If subJabatan.Text = "3" Or subJabatan.Text = "4" Or subJabatan.Text = "5" Then
                btnShow55.Visible = True
            End If

            BtnKpi44Setuju1.Visible = False
            BtnKpi44Setuju2.Visible = False
            BtnKpi44Setuju3.Visible = False
        End If
    End Sub

    Sub lockhrd()

        'Jika PK Sudah Di verifikasi atasan dari atasan langsung
        If GetFindRecord_Server("SELECT * FROM TRXN_KPIH WHERE KPIH_APPVUSER IS NOT NULL AND KPIH_APPVUSERTGL IS NOT NULL AND KPIH_APPVHEADTGL IS NOT NULL AND KPIH_APPVHEADTGL2 IS NOT NULL AND  KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'") = 1 Then
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- STAFF HRD EDIT'") = 1 Then
                If subJabatan.Text = "0" Or subJabatan.Text = "2" Then
                    Call EditKPI()
                    ButtonRefresh.Visible = True
                Else
                    Call NoEditKPI()
                End If
            ElseIf GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- SPV HRD EDIT'") = 1 Then
                If subJabatan.Text = "1" Or subJabatan.Text = "3" Then
                    Call EditKPI()
                    ButtonRefresh.Visible = True
                Else
                    Call NoEditKPI()
                End If
            ElseIf GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- HRD HEAD EDIT'") = 1 Then
                Call EditKPI()
                ButtonRefresh.Visible = True
            Else
                Call NoEditKPI()
            End If

            'Jika PK Sudah Di verifikasi atasan dari atasan langsung
        ElseIf GetFindRecord_Server("SELECT * FROM TRXN_KPIH WHERE KPIH_APPVUSER IS NOT NULL AND KPIH_APPVUSERTGL IS NOT NULL AND KPIH_APPVHEADTGL IS NOT NULL AND (KPIH_APPVHEAD2 IS NULL or KPIH_APPVHEAD2 = '') AND  KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'") = 1 Then
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- STAFF HRD EDIT'") = 1 Then
                If subJabatan.Text = "0" Or subJabatan.Text = "1" Then
                    Call EditKPI()
                    ButtonRefresh.Visible = True
                Else
                    Call NoEditKPI()
                End If
            ElseIf GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- SPV HRD EDIT'") = 1 Then
                If subJabatan.Text = "2" Or subJabatan.Text = "3" Then
                    Call EditKPI()
                    ButtonRefresh.Visible = True
                Else
                    Call NoEditKPI()
                End If
            ElseIf GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- HRD HEAD EDIT'") = 1 Then
                Call EditKPI()
                ButtonRefresh.Visible = True
            Else
                Call NoEditKPI()
            End If
            'Jika PK belum diverifikasi atasan dari atasan langsung
        ElseIf GetFindRecord_Server("SELECT * FROM TRXN_KPIH WHERE KPIH_APPVUSER IS NOT NULL AND KPIH_APPVUSERTGL IS NOT NULL AND KPIH_APPVHEADTGL IS NOT NULL AND (KPIH_APPVHEADTGL2 IS NULL or KPIH_APPVHEADTGL2 = '') AND  KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'") = 1 Then
            If LblUserName.Text = TxtHead2.Text Then
                Call lockatasan2()
                ButtonRefresh.Visible = True
            End If
            'Jika PK belum diverifikasi atasan langsung
        ElseIf GetFindRecord_Server("SELECT * FROM TRXN_KPIH WHERE KPIH_APPVUSER IS NOT NULL AND KPIH_APPVUSERTGL IS NOT NULL AND KPIH_APPVHEADTGL IS NULL and  KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'") = 1 Then
            If LblUserName.Text = TxtHead.Text Then
                Call lockatasan()
            End If
        Else
            Call NoEditKPI()
        End If
    End Sub

    Sub EditKPI()
		BtnKpi40.Visible = True
		
        BtnKpi40Save.Visible = True
        BtnKpi40Master.Visible = True
        BtnKpi44Setuju1.Visible = False
        BtnKpi44Setuju2.Visible = False
        BtnKpi44Setuju3.Visible = False
        BtnKpi44Setuju4.Visible = True


        'Proses
        kembaliProses.Visible = False
        BtnKpi42ASave.Visible = False
        BtnProsesAtasan1.Visible = False
        BtnProsesAtasan2.Visible = False
        TxtProsesStaff.Visible = False
        LblProsesStaff.Visible = True

        'Halaman People Management
        BtnKpi42BSave.Visible = False
    End Sub

    Sub NoEditKPI()
        BtnKpi40Master.Visible = False
        BtnKpi40Save.Visible = True
        BtnKpi44Setuju4.Visible = False


        kembaliProses.Visible = True
        BtnKpi42ASave.Visible = True
        BtnProsesAtasan1.Visible = False
        BtnProsesAtasan2.Visible = False
        BtnKpi42BSave.Visible = True
        TxtProsesStaff.Visible = True
        LblProsesStaff.Visible = False
		TxtProsesHead.Visible = False
		TxtProsesKomentar.ReadOnly = True
		TxtProsesKomentar2.ReadOnly = True
		
		TxtPeopleAtasan.ReadOnly = True
		TxtPeopleKomentar.ReadOnly = True


        BtnKpi44Setuju1.Visible = True
        BtnKpi44Setuju2.Visible = False
        BtnKpi44Setuju3.Visible = False

    End Sub

    Sub hitunghasil()

        Call GetData_MASTEROthers("SELECT * FROM TRXN_KPIH Where KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'")
        If TxtKpiSummaryPosA.Text = "A" Or TxtKpiSummaryPosA.Text = "B" Or TxtKpiSummaryPosA.Text = "C" Then
            TxtKpiPercenNilai1.Text = "50"
            TxtKpiPercenNilai2.Text = "40"
            TxtKpiPercenNilai3.Text = "10"
        ElseIf TxtKpiSummaryPosA.Text = "D" Then
            TxtKpiPercenNilai1.Text = "60"
            TxtKpiPercenNilai2.Text = "40"
        ElseIf TxtKpiSummaryPosA.Text = "E" Then
            TxtKpiPercenNilai1.Text = "50"
            TxtKpiPercenNilai2.Text = "20"
            TxtKpiPercenNilai3.Text = "30"
        End If

        If TxtKpiSummaryPosA.Text = "A" Or TxtKpiSummaryPosA.Text = "B" Or TxtKpiSummaryPosA.Text = "C" Then
            Total3.Text = "C. Nilai Disiplin"
            LblTotal.Text = "Total A + Total B + Total C"
            Call hitungabsen()
            Call GetData_NILAIA("SELECT SUM(NILAIAKHIR) AS TOTAL_NILAI1 FROM (Select Round(((DATA_KPIT.KPIT_BOBOT * TRXN_KPID.KPID_NILAISTAFF ) / 100),2) As NILAIAKHIR FROM TRXN_KPID, DATA_KPIT where KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPID_TYPEA='" & TxtKpiSummaryPosA.Text & "' AND KPID_NIK='" & TxtStaffNIK.Text & "' And TRXN_KPID.KPID_ITEM = DATA_KPIT.KPIT_TIPE ) AS TOTAL_NILAI1")
            Call GetData_NILAIB("select round(avg(KPI_ATASAN),2) AS TOTAL_NILAI2 from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='A' AND KPI_NIK='" & TxtStaffNIK.Text & "' ")
            Call GetData_NILAIC("select round(avg(KPI_AKHIR),2) AS TOTAL_NILAI3 from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_NIK='" & TxtStaffNIK.Text & "' and KPI_TIPEA='C'")
            LblNiaiAkhir1.Text = (Val(TxtKpiPercenNilai1.Text) * Val(TxtKpiTotalNilai1.Text)) / 100
            LblNiaiAkhir2.Text = (Val(TxtKpiPercenNilai2.Text) * Val(TxtKpiTotalNilai2.Text)) / 100
            LblNiaiAkhir3.Text = (Val(TxtKpiPercenNilai3.Text) * Val(TxtKpiTotalNilai3.Text)) / 100
            LblNiaiAkhir1.Text = FormatNumber(LblNiaiAkhir1.Text, 2)
            LblNiaiAkhir2.Text = FormatNumber(LblNiaiAkhir2.Text, 2)
            LblNiaiAkhir3.Text = FormatNumber(LblNiaiAkhir3.Text, 2)
            LblNiaiAkhir4.Text = Val(LblNiaiAkhir1.Text) + Val(LblNiaiAkhir2.Text) + Val(LblNiaiAkhir3.Text)
            hasilakhir.Text = Val(LblNiaiAkhir4.Text) - Val(TxtNilaiSP.Text)
            Call kategori()
        ElseIf TxtKpiSummaryPosA.Text = "D" Then
            nilaic.Visible = False
            LblTotal.Text = "Total A + Total B"
            Call GetData_NILAIA("SELECT SUM(NILAIAKHIR) AS TOTAL_NILAI1 FROM (Select Round(((DATA_KPIT.KPIT_BOBOT * TRXN_KPID.KPID_NILAISTAFF ) / 100),2) As NILAIAKHIR FROM TRXN_KPID, DATA_KPIT where KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPID_TYPEA='" & TxtKpiSummaryPosA.Text & "' AND KPID_NIK='" & TxtStaffNIK.Text & "' And TRXN_KPID.KPID_ITEM = DATA_KPIT.KPIT_TIPE ) AS TOTAL_NILAI1")
            Call GetData_NILAIB("Select round(avg(KPI_ATASAN),2) As TOTAL_NILAI2 from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='A' AND KPI_NIK='" & TxtStaffNIK.Text & "' ")
            LblNiaiAkhir1.Text = (Val(TxtKpiPercenNilai1.Text) * Val(TxtKpiTotalNilai1.Text)) / 100
            LblNiaiAkhir2.Text = (Val(TxtKpiPercenNilai2.Text) * Val(TxtKpiTotalNilai2.Text)) / 100
            LblNiaiAkhir1.Text = FormatNumber(LblNiaiAkhir1.Text, 2)
            LblNiaiAkhir2.Text = FormatNumber(LblNiaiAkhir2.Text, 2)
            LblNiaiAkhir4.Text = Val(LblNiaiAkhir1.Text) + Val(LblNiaiAkhir2.Text)
            hasilakhir.Text = Val(LblNiaiAkhir4.Text) - Val(TxtNilaiSP.Text)
            Call kategori()
        ElseIf TxtKpiSummaryPosA.Text = "E" Then
            Total3.Text = "C. Nilai People Management"
            LblTotal.Text = "Total A + Total B + Total C"
            Call GetData_NILAIA("SELECT SUM(NILAIAKHIR) AS TOTAL_NILAI1 FROM (Select Round(((DATA_KPIT.KPIT_BOBOT * TRXN_KPID.KPID_NILAISTAFF ) / 100),2) As NILAIAKHIR FROM TRXN_KPID, DATA_KPIT where KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPID_TYPEA='" & TxtKpiSummaryPosA.Text & "' AND KPID_NIK='" & TxtStaffNIK.Text & "' And TRXN_KPID.KPID_ITEM = DATA_KPIT.KPIT_TIPE ) AS TOTAL_NILAI1")
            Call GetData_NILAIB("select round(avg(KPI_ATASAN),2) AS TOTAL_NILAI2 from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='A' AND KPI_NIK='" & TxtStaffNIK.Text & "' ")
            Call GetData_NILAIC("select avg(KPI_ATASAN) AS TOTAL_NILAI3 from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_NIK='" & TxtStaffNIK.Text & "' and KPI_TIPEA='C'")
            LblTotal.Text = "Total A + Total B + Total C"
            LblNiaiAkhir1.Text = (Val(TxtKpiPercenNilai1.Text) * Val(TxtKpiTotalNilai1.Text)) / 100
            LblNiaiAkhir2.Text = (Val(TxtKpiPercenNilai2.Text) * Val(TxtKpiTotalNilai2.Text)) / 100
            LblNiaiAkhir3.Text = (Val(TxtKpiPercenNilai3.Text) * Val(TxtKpiTotalNilai3.Text)) / 100
            LblNiaiAkhir1.Text = FormatNumber(LblNiaiAkhir1.Text, 2)
            LblNiaiAkhir2.Text = FormatNumber(LblNiaiAkhir2.Text, 2)
            LblNiaiAkhir3.Text = FormatNumber(LblNiaiAkhir3.Text, 2)
            LblNiaiAkhir4.Text = FormatNumber(Val(LblNiaiAkhir1.Text) + Val(LblNiaiAkhir2.Text) + Val(LblNiaiAkhir3.Text), 0)
            hasilakhir.Text = Val(LblNiaiAkhir4.Text) - Val(TxtNilaiSP.Text)
            Call kategori()

        Else
            Call GetData_NILAIA("select round(sum(KPI_ATASAN),2) AS TOTAL_NILAI1 from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_NIK='" & TxtStaffNIK.Text & "' and KPI_TIPEA='A'")
            Call GetData_NILAIB("select round(avg(KPI_ATASAN),2) AS TOTAL_NILAI2 from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='A' AND KPI_NIK='" & TxtStaffNIK.Text & "' ")
            Call GetData_NILAIC("select avg(KPI_AKHIR) AS TOTAL_NILAI3 from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_NIK='" & TxtStaffNIK.Text & "' and KPI_TIPEA='C'")
            LblTotal.Text = "Total A + Total B + Total C"
            LblNiaiAkhir1.Text = (Val(TxtKpiPercenNilai1.Text) * Val(TxtKpiTotalNilai1.Text)) / 100
            LblNiaiAkhir2.Text = (Val(TxtKpiPercenNilai2.Text) * Val(TxtKpiTotalNilai2.Text)) / 100
            LblNiaiAkhir3.Text = (Val(TxtKpiPercenNilai3.Text) * Val(TxtKpiTotalNilai3.Text)) / 100
            LblNiaiAkhir4.Text = Val(LblNiaiAkhir1.Text) + Val(LblNiaiAkhir2.Text)
        End If
    End Sub

    Sub hitungproses()
        'Call GetData_MASTEROthers("SELECT * FROM TRXN_KPIH Where KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'")
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'PENILAIAN KARYAWAN -- PENILAIAN ATASAN KE BAWAHAN'") = 1 Then

            If LblUserName.Text = TxtHead.Text Then
                If tipeProses.Text = "Kepemimpinan" Then
                    Call GetDataProses("select KPI_KODEITEMM, (ISNULL(KPI_ATASAN,0))  as NIlaiTotal from TRXN_KPIDD where  KPI_tipeA='Z' and KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEMM ='" & LblProsesKodeItem.Text & "'")
                    Call UpdateData_Server3("UPDATE TRXN_KPIDD SET KPI_ATASAN='" & TxtTotal.Text & "' where  KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND  KPI_KODEITEM ='" & LblProsesKodeItem.Text & "'")
                Else
                    Call GetDataProses("select KPI_KODEITEMM, avg(ISNULL(KPI_ATASAN,0)) as NIlaiTotal from TRXN_KPIDD where  KPI_tipeA='Z' and KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEMM ='" & LblProsesKodeItem.Text & "' group by KPI_KODEITEMM")
                    Call UpdateData_Server3("UPDATE TRXN_KPIDD SET KPI_ATASAN='" & TxtTotal.Text & "' where  KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND  KPI_KODEITEM ='" & LblProsesKodeItem.Text & "'")
                End If

            ElseIf LblUserName.Text = TxtHead2.Text Then
                If tipeProses.Text = "Kepemimpinan" Then
                    Call GetDataProses("select KPI_KODEITEMM, avg(ISNULL(KPI_ATASAN,0)  as NIlaiTotal from TRXN_KPIDD where  KPI_tipeA='Z' and KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEMM ='" & LblProsesKodeItem.Text & "'")
                Else
                    Call GetDataProses("select KPI_KODEITEMM, avg(ISNULL(KPI_ATASAN,0)) as NIlaiTotal from TRXN_KPIDD where  KPI_tipeA='Z' and KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEMM ='" & LblProsesKodeItem.Text & "' group by KPI_KODEITEMM")
                    Call UpdateData_Server3("UPDATE TRXN_KPIDD SET KPI_ATASAN='" & TxtTotal.Text & "' where  KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND  KPI_KODEITEM ='" & LblProsesKodeItem.Text & "'")
                End If
            ElseIf TxtNama.Text = TxtStaffNama.Text Then
                If tipeProses.Text <> "Kepemimpinan" Then
                    Call GetDataProses("select KPI_KODEITEMM, avg(ISNULL(KPI_STAFF,0)) as NIlaiTotal from TRXN_KPIDD where  KPI_tipeA='Z' and KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEMM ='" & LblProsesKodeItem.Text & "' group by KPI_KODEITEMM")
                    Call UpdateData_Server3("UPDATE TRXN_KPIDD SET KPI_ATASAN='" & TxtTotal.Text & "' where  KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND  KPI_KODEITEM ='" & LblProsesKodeItem.Text & "'")
                End If
            End If
        Else
            Call GetDataProses("select KPI_KODEITEMM, avg(ISNULL(KPI_STAFF,0)) as NIlaiTotal from TRXN_KPIDD where  KPI_tipeA='Z' and KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEMM ='" & LblProsesKodeItem.Text & "' group by KPI_KODEITEMM")
            Call UpdateData_Server3("UPDATE TRXN_KPIDD SET KPI_ATASAN='" & TxtTotal.Text & "' where  KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND  KPI_KODEITEM ='" & LblProsesKodeItem.Text & "'")
        End If
    End Sub

    Sub kategori()
        If Val(hasilakhir.Text) < 70 Then
            txtKategori.Text = "Kurang"
        ElseIf Val(hasilakhir.Text) >= 70 And Val(hasilakhir.Text) <= 80 Then
            txtKategori.Text = "Cukup"
        ElseIf Val(hasilakhir.Text) > 80 And Val(hasilakhir.Text) <= 90 Then
            txtKategori.Text = "Baik"
        ElseIf Val(hasilakhir.Text) > 90 And Val(hasilakhir.Text) <= 95 Then
            txtKategori.Text = "Baik Sekali"
        ElseIf Val(hasilakhir.Text) > 95 Then
            txtKategori.Text = "Istimewa"
        End If

        If Val(hasilakhir.Text) < 70 Then
            txtKeputusan.Text = "Peringatan"
        ElseIf Val(hasilakhir.Text) >= 70 Then
            txtKeputusan.Text = "Tetap Menjadi Karyawan"
        End If
    End Sub
    Sub hitungabsen()
        Call GetData_Absen1("select KPI_STAFF from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_NIK='" & TxtStaffNIK.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB1'")
        Call GetData_Absen2("select KPI_STAFF from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_NIK='" & TxtStaffNIK.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB2'")
        Call GetData_Absen3("select KPI_STAFF from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_NIK='" & TxtStaffNIK.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB3'")
        Call GetData_Absen4("select KPI_STAFF from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_NIK='" & TxtStaffNIK.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB4'")
        Call GetData_Absen5("select KPI_STAFF from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_NIK='" & TxtStaffNIK.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB5'")
        Call GetData_Absen6("select KPI_STAFF from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_NIK='" & TxtStaffNIK.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB6'")
        Dim mSqlCommand As String = ""
        If Val(TxtAB1.Text) = 0 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='90' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB1'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB1.Text) = 1 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='70' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB1'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB1.Text) = 2 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='60' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB1'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB1.Text) >= 3 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='50' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB1'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        End If

        If Val(TxtAB2.Text) = 0 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='90' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB2'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB2.Text) = 1 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='70' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB2'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB2.Text) >= 2 And Val(TxtAB2.Text) <= 3 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='60' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB2'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB2.Text) >= 4 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='50' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB2'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        End If

        If Val(TxtAB3.Text) = 0 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='90' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB3'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB3.Text) = 1 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='80' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB3'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB3.Text) = 2 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='70' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB3'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB3.Text) = 3 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='60' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB3'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB3.Text) >= 4 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='50' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB3'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        End If

        If Val(TxtAB4.Text) = 0 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='90' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB4'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB4.Text) >= 1 And Val(TxtAB4.Text) <= 8 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='80' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB4'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB4.Text) >= 9 And Val(TxtAB4.Text) <= 16 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='70' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB4'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB4.Text) >= 17 And Val(TxtAB4.Text) <= 24 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='60' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB4'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB4.Text) >= 25 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='50' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB4'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        End If

        If Val(TxtAB5.Text) = 0 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='90' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB5'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB5.Text) = 1 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='80' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB5'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB5.Text) = 2 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='70' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB5'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB5.Text) = 3 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='60' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB5'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB5.Text) >= 4 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='50' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB5'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        End If

        If Val(TxtAB6.Text) = 0 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='90' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB6'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB6.Text) >= 1 And Val(TxtAB6.Text) <= 5 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='80' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB6'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB6.Text) >= 6 And Val(TxtAB6.Text) <= 10 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='70' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB6'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB6.Text) >= 11 And Val(TxtAB6.Text) <= 15 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='60' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB6'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        ElseIf Val(TxtAB6.Text) >= 16 Then
            mSqlCommand = "UPDATE TRXN_KPIDD SET KPI_AKHIR='50' WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='C' and KPI_KODEITEM='AB6'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        End If
        LvDisiplin.DataBind()
    End Sub
    Sub ClearTabelKPIMaster()
        TxtKpiSummaryTahun.Text = "" : lblKpiSummaryTahun.Text = ""
        TxtKpiSummaryPosA.Text = "" : lblKpiSummaryPosA.Text = ""
        TxtKpiSummaryTahunNext.Text = ""
    End Sub

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
                If nSr(MyRecReadA("JABATAN")) = "Direksi" Then
                    lblArea1.Text = "D1"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Operational Support Manager" Then
                    lblArea1.Text = "D2"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SM Ps. Minggu" Then
                    lblArea1.Text = "D3"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SM Puri" Then
                    lblArea1.Text = "D4"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Service Manager Ps. Minggu" Then
                    lblArea1.Text = "D5"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Service Manager Puri" Then
                    lblArea1.Text = "D6"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Internal Auditor" Then
                    lblArea1.Text = "D7"
                ElseIf nSr(MyRecReadA("JABATAN")) = "WH Coordinator" Then
                    lblArea1.Text = "D8"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Ka. Sparepart Ps. Minggu" Then
                    lblArea1.Text = "D9"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Ka. Sparepart Puri" Then
                    lblArea1.Text = "D10"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SPV Sales Ps. Minggu" Then
                    lblArea1.Text = "D11"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SPV Sales Puri" Then
                    lblArea1.Text = "D12"
                ElseIf nSr(MyRecReadA("JABATAN")) = "QMR" Then
                    lblArea1.Text = "D13"
                ElseIf nSr(MyRecReadA("JABATAN")) = "ADH Ps. Minggu" Then
                    lblArea1.Text = "D14"
                ElseIf nSr(MyRecReadA("JABATAN")) = "ADH Puri" Then
                    lblArea1.Text = "D15"
                ElseIf nSr(MyRecReadA("JABATAN")) = "CC SPV" Then
                    lblArea1.Text = "D16"
                ElseIf nSr(MyRecReadA("JABATAN")) = "CC Puri" Then
                    lblArea1.Text = "D17"
                ElseIf nSr(MyRecReadA("JABATAN")) = "HRD & GA Head" Then
                    lblArea1.Text = "D18"
                ElseIf nSr(MyRecReadA("JABATAN")) = "GA Puri" Then
                    lblArea1.Text = "D19"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SPV HRD" Then
                    lblArea1.Text = "D20"
                ElseIf nSr(MyRecReadA("JABATAN")) = "SPV GA" Then
                    lblArea1.Text = "D21"
                ElseIf nSr(MyRecReadA("JABATAN")) = "IT Head" Then
                    lblArea1.Text = "D22"
                ElseIf nSr(MyRecReadA("JABATAN")) = "IT Puri" Then
                    lblArea1.Text = "D23"
                ElseIf nSr(MyRecReadA("JABATAN")) = "Purchasing" Then
                    lblArea1.Text = "D24"
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
        End Try
    End Function

    Function GetData_UserHead(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_UserHead = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_UserHead = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                TxtHead.Text = nSr(MyRecReadA("KPIH_APPVHEAD"))
                lblDeadlinePK.Text = nSr(MyRecReadA("KPIH_DEADLINEPK"))
                lblDeadlineAtasan.Text = nSr(MyRecReadA("KPIH_DEADLINEATASAN"))
                lblDeadlineAtasan2.Text = nSr(MyRecReadA("KPIH_DEADLINEATASAN2"))
                TxtHead2.Text = nSr(MyRecReadA("KPIH_APPVHEAD2"))
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
        End Try
    End Function


    Sub InsertDataMasterKPI(ByVal mStatus As String)
        'Dim mSqlCommand As String = "INSERT INTO DATA_KPIN (KPIN_TIPE,KPIN_JUDUL,KPIN_DESC,KPIN_NILAI) VALUES ('" & TxtMasterKPIId.Text & "','" & TxtMasterKPIJudul.Text & "','" & TxtMasterKPIKet.Text & "','" & TxtMasterKPINilai.Text & "')   KPIN_TIPE='A:Tingah Laku STAFF B:Disiplin'"
    End Sub
    Sub InsertDataNilaiKPI(ByVal mStatus As String)
        'KPI_TIPEA = A(Percobaan) KPI_TIPEB=A,B,D
        'KPI_TIPEA = B(Tahunan)   KPI_TIPEB=A,B,C,D,E(SPK),
        'Dim mSqlCommand As String = "INSERT INTO TRXN_KPI (KPI_NIK,KPI_ITEM,KPI_TIPEA,KPI_TIPEB) ,KPI_TARGET,KPI_STAFF,KPI_ATASAN,KPI_AKHIR,KPI_TAHUN,KPI_JABATAN,KPI_TGL,KPI_APPVUSER,KPI_APPVUSERTGL,KPI_APPVHEAD,KPI_APPVHEADTGL,KPI_APPVHRD,KPI_APPVHRDTGL)"
    End Sub


    Function GetData_MASTER(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MASTER = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtKpiSummaryTahun.Text = nSr(MyRecReadA("KPIH_TAHUN"))
                TxtKpiSummaryPosA.Text = nSr(MyRecReadA("KPIH_TIPEA"))
                TxtDeadlinePK.Text = nSr(MyRecReadA("KPIH_DEADLINEPK"))
                TxtDeadlineAtasan.Text = nSr(MyRecReadA("KPIH_DEADLINEATASAN"))
                TxtDeadlineAtasan2.Text = nSr(MyRecReadA("KPIH_DEADLINEATASAN2"))
                lblKpiSummaryPosA.Text = TxtKpiSummaryPosA.Text


            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_NILAIA(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_NILAIA = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtKpiTotalNilai1.Text = MyRecReadA("TOTAL_NILAI1")
                nilaiPerforma.Text = MyRecReadA("TOTAL_NILAI1")
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_NILAIB(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_NILAIB = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtKpiTotalNilai2.Text = MyRecReadA("TOTAL_NILAI2")
                nilaiProses.Text = MyRecReadA("TOTAL_NILAI2")
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_NILAIC(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_NILAIC = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtKpiTotalNilai3.Text = MyRecReadA("TOTAL_NILAI3")
                nilaiPeople.Text = MyRecReadA("TOTAL_NILAI3")
                nilaiDisiplin.Text = MyRecReadA("TOTAL_NILAI3")
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetDataProses(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetDataProses = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtTotal.Text = MyRecReadA("NilaiTotal")
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_Absen1(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Absen1 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtAB1.Text = MyRecReadA("KPI_STAFF")

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_Absen2(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Absen2 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtAB2.Text = MyRecReadA("KPI_STAFF")

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_Absen3(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Absen3 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtAB3.Text = MyRecReadA("KPI_STAFF")

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_Absen4(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Absen4 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtAB4.Text = MyRecReadA("KPI_STAFF")

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_Absen5(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Absen5 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtAB5.Text = MyRecReadA("KPI_STAFF")

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_Absen6(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Absen6 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtAB6.Text = MyRecReadA("KPI_STAFF")

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try



    End Function

    Function GetData_MASTEROthers(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MASTEROthers = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtNilaiSP.Text = nSr(MyRecReadA("KPIH_NILAISP"))      'SP
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function


    Function deskripsiKPI(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        deskripsiKPI = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtKPI.Text = nSr(MyRecReadA("KPIT_ITEM"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function


    Function GetData_MASTERKPI(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MASTERKPI = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtMasterKpiItem.Text = nSr(MyRecReadA("KPIT_ITEM"))
                TxtMasterKpiTipe.Text = nSr(MyRecReadA("KPIT_TIPE"))
                TxtMasterKpiTarget.Text = nSr(MyRecReadA("KPIT_TARGET"))
                TxtMasterKpiPrestasi.Text = nSr(MyRecReadA("KPIT_HITUNG"))
                TxtMasterBobot.Text = nSr(MyRecReadA("KPIT_Bobot"))
                TxtMasterKpiBln01.Text = nSr(MyRecReadA("KPID_BULAN01"))
                TxtMasterKpiBln02.Text = nSr(MyRecReadA("KPID_BULAN02"))
                TxtMasterKpiBln03.Text = nSr(MyRecReadA("KPID_BULAN03"))
                TxtMasterKpiBln04.Text = nSr(MyRecReadA("KPID_BULAN04"))
                TxtMasterKpiBln05.Text = nSr(MyRecReadA("KPID_BULAN05"))
                TxtMasterKpiBln06.Text = nSr(MyRecReadA("KPID_BULAN06"))
                TxtMasterKpiBln07.Text = nSr(MyRecReadA("KPID_BULAN07"))
                TxtMasterKpiBln08.Text = nSr(MyRecReadA("KPID_BULAN08"))
                TxtMasterKpiBln09.Text = nSr(MyRecReadA("KPID_BULAN09"))
                TxtMasterKpiBln10.Text = nSr(MyRecReadA("KPID_BULAN10"))
                TxtMasterKpiBln11.Text = nSr(MyRecReadA("KPID_BULAN11"))
                TxtMasterKpiBln12.Text = nSr(MyRecReadA("KPID_BULAN12"))
                'KPID_TYPEA

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function


    'GetData_MASTERKPISkillA
    Function GetData_MASTERKPIProses(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MASTERKPIProses = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()

                LblProsesKodeItem2.Text = nSr(MyRecReadA("KPI_KODEITEM"))
                LblProsesJudulJudul2.Text = nSr(MyRecReadA("KPIN_DESC"))
                LblProsesJudulJudul.Text = nSr(MyRecReadA("KPIN_JUDUL"))
                TxtProsesStaff.Text = nSr(MyRecReadA("KPI_STAFF"))
                LblProsesStaff.Text = nSr(MyRecReadA("KPI_STAFF"))
                TxtProsesHead.Text = nSr(MyRecReadA("KPI_ATASAN"))
                LblProsesHead.Text = nSr(MyRecReadA("KPI_ATASAN"))
                TxtProsesKomentar.Text = nSr(MyRecReadA("KPI_KOMENTAR"))
                TxtProsesKomentar2.Text = nSr(MyRecReadA("KPI_KOMENTAR2"))

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_MASTERKPIProses2(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MASTERKPIProses2 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()

                LblProsesKodeItem2.Text = nSr(MyRecReadA("KPI_KODEITEM"))
                LblProsesJudulJudul2.Text = nSr(MyRecReadA("KPIN_DESC"))
                LblProsesJudulJudul.Text = nSr(MyRecReadA("KPIN_JUDUL"))
                TxtProsesHead.Text = nSr(MyRecReadA("KPI_ATASAN"))
                LblProsesHead.Text = nSr(MyRecReadA("KPI_ATASAN"))
                TxtProsesKomentar.Text = nSr(MyRecReadA("KPI_KOMENTAR"))
                TxtProsesKomentar2.Text = nSr(MyRecReadA("KPI_KOMENTAR2"))

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_NilaiBawahan(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_NilaiBawahan = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()

                Label64.Text = "Penilaian dari Bawahan"
                TxtProsesStaff.Visible = "False"
                LblProsesStaff.Visible = "True"
                LblProsesStaff.Text = nSr(MyRecReadA("NILAI_BAWAHAN"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_MASTERKPIPeople(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MASTERKPIPeople = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()

                LblPeopleKode.Text = nSr(MyRecReadA("KPI_KODEITEM"))
                LblPeopleJudul.Text = nSr(MyRecReadA("KPIN_JUDUL"))
                TxtPeopleStaff.Text = nSr(MyRecReadA("KPI_STAFF"))
                TxtPeopleAtasan.Text = nSr(MyRecReadA("KPI_ATASAN"))
                TxtPeopleKomentar.Text = nSr(MyRecReadA("KPI_KOMENTAR"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_Bawahan(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Bawahan = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()

                TxtPeopleBawahan.Text = nSr(MyRecReadA("nilai_bawahan"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_MASTERKPISP(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MASTERKPISP = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtNilaiSP.Text = nSr(MyRecReadA("KPI_TARGET"))
                'DropDownList7.Text = nSr(MyRecReadA("KPI_ITEM"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

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
            ' MsgBox(ex.Message)
        End Try
    End Function

    Function GetFindRecord_Server2(ByVal mSqlCommadstring As String) As Integer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetFindRecord_Server2 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                GetFindRecord_Server2 = 1
                MyRecReadA.Read()
                TxtNotif.Text = nSr(MyRecReadA("KPIN_JUDUL"))
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
                TxtStaffNIK.Text = nSr(MyRecReadA("STAFF_NIK"))

                TxtStaffNIK.Enabled = False
                TxtStaffNama.Text = nSr(MyRecReadA("STAFF_NAMA"))
                subJabatan.Text = nSr(MyRecReadA("STAFF_SUBJABATAN"))
                TxtStatusKerjaJabatan.Text = nSr(MyRecReadA("STAFF_STATUSKERJAJABATAN"))
                TxtStatusKerjaTempat.Text = nSr(MyRecReadA("STAFF_STATUSKERJALOKASI")) + " / " + nSr(MyRecReadA("STAFF_STATUSKERJADEPT"))

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function

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
                TxtStaffNIK.Text = nSr(MyRecReadA("KDKARYAWAN"))
                TxtNama.Text = nSr(MyRecReadA("NAMAKARYAWAN"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function

    Function GetData_STAFF3(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_STAFF3 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtNama.Text = nSr(MyRecReadA("NAMAKARYAWAN"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function

    Function GetData_STAFF4(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_STAFF4 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TXTUsername.Text = nSr(MyRecReadA("USERNAME"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function
    Function UpdateData_Server(ByVal mSqlCommadstring As String, ByVal mPos As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        LblErrorSaveKpi40.Text = ""

        LblErrorSaveKpi42A.Text = ""
        LblErrorSaveKpi42B.Text = ""
        LblErrorSaveKpi44.Text = ""
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
    Function UpdateData_Server3(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        LblErrorSaveKpi40.Text = ""

        LblErrorSaveKpi42A.Text = ""
        LblErrorSaveKpi42B.Text = ""
        LblErrorSaveKpi44.Text = ""
        UpdateData_Server3 = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_Server3 = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'TxtProsesStaff.Text = ""
    End Function
    Sub ErrorIsi(ByVal Kode As String, ByVal Errormsg As String)

        If Kode = "Kpi40" Then
            LblErrorSaveKpi40.Text = Errormsg

        ElseIf Kode = "Kpi42A" Then
            LblErrorSaveKpi42A.Text = Errormsg
        ElseIf Kode = "Kpi42B" Then
            LblErrorSaveKpi42B.Text = Errormsg
        ElseIf Kode = "Kpi44" Then
            LblErrorSaveKpi44.Text = Errormsg
        End If
    End Sub


    Function DtFrSQL(ByRef mNilai As Object) As String
        On Error GoTo ErrHand
        DtFrSQL = "NULL"
        If IsDate(mNilai) Then
            DtFrSQL = "'" & Format(CDate(mNilai), "yyyy-MM-dd HH:MM:ss") & "'"
        End If
        'MsgBox(DtFrSQL)
ErrHand:
    End Function



    Function nDb(ByVal Nilai As Object) As Double
        On Error GoTo ErrHand
        nDb = 0
        If Not IsDBNull(Nilai) Then
            nDb = Val(Format(Nilai, "###############.#0")) '13
        End If
ErrHand:
    End Function

    Function nLg(ByVal Nilai As Object) As Integer
        On Error GoTo ErrHand
        nLg = 0
        If Not IsDBNull(Nilai) Then
            nLg = Int(Val(Format(Nilai, "###############0"))) '10
        End If
ErrHand:
    End Function


    Function fLg(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        fLg = "0"
        nilai = Replace(nilai, ",", "")
        If IsNumeric(nilai) Then fLg = Format(Val(nilai), "###,###,###,###,##0") '10
ErrHand:
    End Function

    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function
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

    '==============================================================================

    Private Sub LvKPIMasterDetail_ItemUpdated(sender As Object, e As ListViewUpdatedEventArgs) Handles LvKPIMasterDetail.ItemUpdated

    End Sub


    Function emailatasanlangsung(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        emailatasanlangsung = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            emailatasanlangsung = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                Dim email As String = nSr(MyRecReadA("emaildivisi"))
                Dim pesan As New MailMessage
                pesan.Subject = "PK " + TxtStaffNama.Text + " Membutuhkan Verifikasi Anda"
                pesan.To.Add(email) 'email tujuan
                pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
                pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda memiliki sebuah permintaan verifikasi PK untuk karyawan bernama " + TxtStaffNama.Text + " <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk melakukan verifikasi</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
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

    Function emailatasanlangsungselesai(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        emailatasanlangsungselesai = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            emailatasanlangsungselesai = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                Dim email As String = nSr(MyRecReadA("staff_email"))
                Dim pesan As New MailMessage
                pesan.Subject = "PK Anda Telah di verifikasi oleh " + TxtHead.Text
                pesan.To.Add(email) 'email tujuan
                pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
                pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Status PK anda telah di verifikasi oleh " + TxtHead.Text + " <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk melihat PK</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
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

    Function emailatasandariatasanlangsungselesai(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        emailatasandariatasanlangsungselesai = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            emailatasandariatasanlangsungselesai = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                Dim email As String = nSr(MyRecReadA("staff_email"))
                Dim pesan As New MailMessage
                pesan.Subject = "PK Anda Telah di verifikasi oleh " + TxtHead2.Text
                pesan.To.Add(email) 'email tujuan
                pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
                pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Status PK anda telah di verifikasi oleh " + TxtHead2.Text + " <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk melihat PK</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
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

    Function emailHRDSelesai(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        emailHRDSelesai = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            emailHRDSelesai = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                Dim email As String = nSr(MyRecReadA("staff_email"))
                Dim pesan As New MailMessage
                pesan.Subject = "PK Anda Telah di verifikasi oleh HRD"
                pesan.To.Add(email) 'email tujuan
                pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
                pesan.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Status PK anda telah di verifikasi oleh HRD <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk melihat PK</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"
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

    Function emailKPI(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        emailKPI = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            emailKPI = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                Dim email As String = nSr(MyRecReadA("staff_email"))
                Dim pesan As New MailMessage
                pesan.Subject = "Ringkasan PK Anda" 
                pesan.To.Add(email) 'email tujuan
                pesan.From = New MailAddress("hmugen1991@gmail.com") 'email kalian
                Dim url As String = "http://office.hondamugen.co.id:8085/hrdpkoutput.aspx?no=" + TxtStaffNIK.Text
                pesan.Body = HttpContent(url)
                pesan.IsBodyHtml = True
                'pesan.UrlContentBase = url
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
	
	Protected Sub test_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles test.Click
        Call emailKPI("select staff_email from data_staff where staff_nik ='" & TxtStaffNIK.Text & "'")
		Response.Write("<script>alert('Ringksan PK Anda telah sukses dikirim ke email!')</script>")
    End Sub

    Private Function HttpContent(url As String) As String
        Dim objRequest As WebRequest = System.Net.HttpWebRequest.Create(url)
        Dim sr As New StreamReader(objRequest.GetResponse().GetResponseStream())
        Dim result As String = sr.ReadToEnd()
        sr.Close()
        Return result
    End Function

    Sub Msg_err(ByVal mTest As String)
        lblMsgBox.Text = mTest
        If mTest = "" Then
            MultiViewError.ActiveViewIndex = 0
        Else
            MultiViewError.ActiveViewIndex = 0
        End If
    End Sub

    Function GetNo_Tipe2(ByVal mSqlCommadstring As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetNo_Tipe2 = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                GetNo_Tipe2 = nSr(MyRecReadA("KPIN_TIPE2"))
                tipeProses.Text = nSr(MyRecReadA("KPIN_JUDUL"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function FoundRecord_Tabel(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        FoundRecord_Tabel = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                FoundRecord_Tabel = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function Insert_TabelKPIN(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Insert_TabelKPIN = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    Call UpdateData_Server2("INSERT INTO TRXN_KPIDD (KPI_KODEITEM,KPI_NIK,KPI_TAHUN,KPI_TIPEA,KPI_KODEITEMM) values (" & _
                                            "'" & nSr(MyRecReadA("KPIN_TIPE")) & "','" & TxtStaffNIK.Text & "','" & TxtKpiSummaryTahun.Text & "','Z','" & LblProsesKodeItem.Text & "')")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function UpdateData_Server2(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        UpdateData_Server2 = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_Server2 = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

End Class
