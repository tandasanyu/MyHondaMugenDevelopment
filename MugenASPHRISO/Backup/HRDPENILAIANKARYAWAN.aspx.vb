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

'Kode 0101
'1 Hak Lihat Hanya Diri Sendiri
'2 Hak Lihat Semuanya
'3 Hak Menambah/Menghapus/Mengedit Data Karyawan
'4 Hak Menambah/Menghapus/Mengedit KPI


Partial Class HRDPENILAIANKARYAWAN
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader
    Dim sFileDir As String = "E:\"
    Dim lMaxFileSize As Long = 4096

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

            MultiViewKpiMaster.ActiveViewIndex = 0
                MultiViewAkses.ActiveViewIndex = 0
                Dim no As String = Request.QueryString("no")
            If no <> "" Then
                Call GetData_STAFF("SELECT * FROM DATA_STAFF WHERE STAFF_NIK='" & no & "'")
            Else
                Call GetData_STAFF2("SELECT * FROM TB_USER WHERE username='" & LblUserName.Text & "'")
                Call GetData_STAFF("SELECT * FROM DATA_STAFF WHERE STAFF_NIK='" & TxtStaffNIK.Text & "'")
            End If

            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM HRD -- ADD DATA'") = 1 Then
                BtnStandard.Visible = True
                BtnKpi40Master.Visible = True
                BtnStandardTabel.Visible = True
                BtnKpi40.Visible = True
                BtnKpi40MasterCopy.Visible = True
                BtnKpi40MasterNew.Visible = True
                BtnKpi40MasterDel.Visible = True
                TxtMasterKpiItem.ReadOnly = False
                TxtMasterBobot.ReadOnly = False
                TxtMasterKpiPrestasi.ReadOnly = False
                TxtKpiSummaryTahun.ReadOnly = False
                TxtKpiSummaryPosA.ReadOnly = False
                TxtKpiSummaryTahunNext.ReadOnly = False
                penilaianbulanan.Visible = False
  
            Else
                BtnStandard.Visible = False
                BtnKpi40Master.Visible = False
                BtnStandardTabel.Visible = False
                BtnKpi40.Visible = False
                BtnKpi40MasterCopy.Visible = False
                BtnKpi40MasterNew.Visible = False
                BtnKpi40MasterDel.Visible = False
                TxtKpiSummaryTahun.ReadOnly = True
                TxtKpiSummaryPosA.ReadOnly = True
                TxtKpiSummaryTahunNext.ReadOnly = True
                TxtMasterBobot.ReadOnly = True
                TxtMasterKpiItem.ReadOnly = True
                TxtMasterKpiPrestasi.ReadOnly = True

                TxtMasterKpiTarget.ReadOnly = True

            End If

        End If
    End Sub

    '============Start Hal Utama

    Sub HakDataKeryawan()
        '=================================================
        BtnStandardTabel.Visible = False
        BtnStandard.Visible = False
        BtnStandardSave.Visible = False : BtnStandardDel.Visible = False

        BtnKpi40.Visible = False
        BtnKpi40Save.Visible = False : BtnKpi40Del.Visible = False


        BtnKpi42BSave.Visible = False


        BtnKpi43Save.Visible = False

        BtnKpi44Setuju1.Visible = False : BtnKpi44Setuju2.Visible = False

    End Sub



    '============end Pilihan Halaman

    Sub DeaktifTabel1()
        MultiViewKpiMaster.ActiveViewIndex = 0 : LvKpiMasterSummary.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = -1

        MultiViewKPIMasterDetail.ActiveViewIndex = -1
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1

        MultiViewNilaiStandard.ActiveViewIndex = -1
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1


        MultiViewProsesTabel.ActiveViewIndex = -1
        MultiViewProsesEntry.ActiveViewIndex = -1

        MultiViewPeopleTabel.ActiveViewIndex = -1
        MultiViewPeopleEntry.ActiveViewIndex = -1

        MultiViewDisiplin.ActiveViewIndex = -1
        MultiViewDisplinEntry.ActiveViewIndex = -1

        MultiViewOthers.ActiveViewIndex = -1
        '=============

    End Sub

    Sub DeaktifRaport()

        MultiViewKpiMaster.ActiveViewIndex = -1 : LvKpiMasterSummary.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = -1

        MultiViewKPIMasterDetail.ActiveViewIndex = -1
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = 0

        MultiViewNilaiStandard.ActiveViewIndex = -1
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1


        MultiViewProsesTabel.ActiveViewIndex = -1
        MultiViewProsesEntry.ActiveViewIndex = -1

        MultiViewPeopleTabel.ActiveViewIndex = -1
        MultiViewPeopleEntry.ActiveViewIndex = -1

        MultiViewDisiplin.ActiveViewIndex = -1
        MultiViewDisplinEntry.ActiveViewIndex = -1

        MultiViewOthers.ActiveViewIndex = -1
        '=============

    End Sub


    Sub DeaktifProses()

        MultiViewKpiMaster.ActiveViewIndex = -1 : LvKpiMasterSummary.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = -1

        MultiViewKPIMasterDetail.ActiveViewIndex = -1
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1

        MultiViewNilaiStandard.ActiveViewIndex = -1
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1


        MultiViewProsesTabel.ActiveViewIndex = -1
        MultiViewProsesEntry.ActiveViewIndex = 0

        MultiViewPeopleTabel.ActiveViewIndex = -1
        MultiViewPeopleEntry.ActiveViewIndex = -1

        MultiViewDisiplin.ActiveViewIndex = -1
        MultiViewDisplinEntry.ActiveViewIndex = -1

        MultiViewOthers.ActiveViewIndex = -1
        '=============

    End Sub

    Sub DeaktifDisiplin()

        MultiViewKpiMaster.ActiveViewIndex = -1 : LvKpiMasterSummary.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = -1

        MultiViewKPIMasterDetail.ActiveViewIndex = -1
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1

        MultiViewNilaiStandard.ActiveViewIndex = -1
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1


        MultiViewProsesTabel.ActiveViewIndex = -1
        MultiViewProsesEntry.ActiveViewIndex = -1

        MultiViewPeopleTabel.ActiveViewIndex = -1
        MultiViewPeopleEntry.ActiveViewIndex = -1

        MultiViewDisiplin.ActiveViewIndex = -1
        MultiViewDisplinEntry.ActiveViewIndex = 0

        MultiViewOthers.ActiveViewIndex = -1
        '=============

    End Sub

    Sub DeaktifPeople()

        MultiViewKpiMaster.ActiveViewIndex = -1 : LvKpiMasterSummary.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = -1

        MultiViewKPIMasterDetail.ActiveViewIndex = -1
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1

        MultiViewNilaiStandard.ActiveViewIndex = -1
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1


        MultiViewProsesTabel.ActiveViewIndex = -1
        MultiViewProsesEntry.ActiveViewIndex = -1

        MultiViewPeopleTabel.ActiveViewIndex = -1
        MultiViewPeopleEntry.ActiveViewIndex = 0

        MultiViewDisiplin.ActiveViewIndex = -1
        MultiViewDisplinEntry.ActiveViewIndex = -1

        MultiViewOthers.ActiveViewIndex = -1
        '=============

    End Sub

    Sub ClikDetail_MultiViewKpiMaster()

        MultiViewKpiMaster.ActiveViewIndex = -1
        MultiViewKPIMasterDetail.ActiveViewIndex = 0 : MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1 : LvKPIMasterDetail.DataBind()

        If TxtKpiSummaryPosA.Text = "A" Then
            'Percobaan

            MultiViewProsesTabel.ActiveViewIndex = 0 : MultiViewProsesEntry.ActiveViewIndex = -1 : LVProses.DataBind()

            MultiViewPeopleTabel.ActiveViewIndex = -1 : MultiViewPeopleEntry.ActiveViewIndex = -1
            MultiViewDisiplin.ActiveViewIndex = -1 : MultiViewDisplinEntry.ActiveViewIndex = -1 : LvDisiplin.DataBind()
        ElseIf TxtKpiSummaryPosA.Text = "B" Then
            'Karyawan

            MultiViewProsesTabel.ActiveViewIndex = 0 : MultiViewProsesEntry.ActiveViewIndex = -1 : LVProses.DataBind()
            MultiViewPeopleTabel.ActiveViewIndex = -1 : MultiViewPeopleEntry.ActiveViewIndex = -1
            MultiViewDisiplin.ActiveViewIndex = 0 : MultiViewDisplinEntry.ActiveViewIndex = -1 : LvDisiplin.DataBind()

        ElseIf TxtKpiSummaryPosA.Text = "C" Then
            'Manager

            MultiViewProsesTabel.ActiveViewIndex = 0 : MultiViewProsesEntry.ActiveViewIndex = -1 : LVProses.DataBind()
            MultiViewPeopleTabel.ActiveViewIndex = -1 : MultiViewPeopleEntry.ActiveViewIndex = -1
            MultiViewDisiplin.ActiveViewIndex = -1 : MultiViewDisplinEntry.ActiveViewIndex = -1 : LvDisiplin.DataBind()
        ElseIf TxtKpiSummaryPosA.Text = "D" Then
            'SPV No Team

            MultiViewProsesTabel.ActiveViewIndex = 0 : MultiViewProsesEntry.ActiveViewIndex = -1 : LVProses.DataBind()
            MultiViewPeopleTabel.ActiveViewIndex = -1 : MultiViewPeopleEntry.ActiveViewIndex = -1
            MultiViewDisiplin.ActiveViewIndex = -1 : MultiViewDisplinEntry.ActiveViewIndex = -1 : LvDisiplin.DataBind()
        ElseIf TxtKpiSummaryPosA.Text = "E" Then
            'SPV Team

            MultiViewProsesTabel.ActiveViewIndex = 0 : MultiViewProsesEntry.ActiveViewIndex = -1 : LVProses.DataBind()
            MultiViewPeopleTabel.ActiveViewIndex = 0 : MultiViewPeopleEntry.ActiveViewIndex = -1
            MultiViewDisiplin.ActiveViewIndex = -1 : MultiViewDisplinEntry.ActiveViewIndex = -1 : LvDisiplin.DataBind()
        End If
        MultiViewOthers.ActiveViewIndex = 0
    End Sub


    Protected Sub BtnStandardTabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardTabel.Click

        MultiViewNilaiStandard.ActiveViewIndex = 0
        MultiViewKpiMaster.ActiveViewIndex = -1
    End Sub

    Protected Sub BtnStandardTabel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardTabel2.Click

        MultiViewNilaiStandard.ActiveViewIndex = -1
        MultiViewKpiMaster.ActiveViewIndex = 0
    End Sub

    Protected Sub BtnStandard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandard.Click
        MultiViewNilaiStandardEntry.ActiveViewIndex = 0
    End Sub

    Function InsertDataNilaiSTANDARD() As String
        InsertDataNilaiSTANDARD = "INSERT INTO DATA_KPIN (KPIN_TIPE) VALUES ('" & TxtStandardKode.Text & "')"
    End Function

    Function EditDataNilaiSTANDARD() As String
        'KPID_TYPEA=1 Percobaan 2 Karyawan
        EditDataNilaiSTANDARD = "UPDATE DATA_KPIN SET " & _
                                  "KPIN_DESC='" & TxtStandardKet.Text & "'," & _
                                  "KPIN_JUDUL='" & TxtStandardJudul.Text & "'," & _
                                  "KPIN_NILAI6='" & TxtStandardNilai6.Text & "'," & _
                                  "KPIN_NILAI7='" & TxtStandardNilai7.Text & "'," & _
                                  "KPIN_NILAI8='" & TxtStandardNilai8.Text & "'," & _
                                  "KPIN_NILAI9='" & TxtStandardNilai9.Text & "'," & _
                                  "KPIN_NILAI10='" & TxtStandardNilai10.Text & "'," & _
                                  "KPIN_GROUP='" & TxtStandardGroup.Text & "' " & _
                                  "WHERE KPIN_TIPE='" & TxtStandardKode.Text & "'"
    End Function

    Sub clearTxtStandardJudul()
        TxtStandardKode.Text = ""
        TxtStandardJudul.Text = ""
        TxtStandardKet.Text = ""
        TxtStandardNilai6.Text = ""
        TxtStandardNilai7.Text = ""
        TxtStandardNilai8.Text = ""
        TxtStandardNilai9.Text = ""
        TxtStandardNilai10.Text = ""
        TxtStandardGroup.Text = ""
    End Sub

    Protected Sub LVNilaiStandard_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVNilaiStandard.SelectedIndexChanged
        TxtStandardKode.Text = (LVNilaiStandard.DataKeys(LVNilaiStandard.SelectedIndex).Value.ToString)
        Call GetData_MASTERSTANDARD("SELECT * FROM DATA_KPIN  WHERE  KPIN_TIPE='" & TxtStandardKode.Text & "'")
        MultiViewNilaiStandardEntry.ActiveViewIndex = 0
        MultiViewNilaiStandard.ActiveViewIndex = -1
        MultiViewKpiMaster.ActiveViewIndex = -1
    End Sub
    Protected Sub BtnStandardSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardSave.Click
        If GetFindRecord_Server("SELECT * FROM DATA_KPIN  WHERE  KPIN_TIPE='" & TxtStandardKode.Text & "' AND KPIN_JUDUL='" & TxtPetik(TxtStandardJudul.Text) & "'") <> 1 Then
            If UpdateData_Server(InsertDataNilaiSTANDARD, "Std") = 1 Then

            End If
        End If
        Call UpdateData_Server(EditDataNilaiSTANDARD, "Std")
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1 : LVNilaiStandard.DataBind()
        MultiViewNilaiStandard.ActiveViewIndex = 0
        MultiViewKpiMaster.ActiveViewIndex = -1
    End Sub
    Protected Sub BtnStandardDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardDel.Click
        Dim mSqlCommand As String = "DELETE FROM DATA_KPIN  WHERE  KPIN_TIPE='" & TxtStandardKode.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Std")
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1 : LVNilaiStandard.DataBind()
    End Sub

    'Data Tabel Kpi setiap Tahun



    '==Summmary Kpi semua tahun=================================

    Protected Sub LvKpiMasterSummary_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvKpiMasterSummary.SelectedIndexChanged
        TxtKpiSummaryTahun.Text = (LvKpiMasterSummary.DataKeys(LvKpiMasterSummary.SelectedIndex).Value.ToString)

        Call GetData_MASTER("SELECT * FROM TRXN_KPIH WHERE KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPIH_NIK='" & TxtStaffNIK.Text & "'")



        If TxtKpiSummaryPosA.Text = "A" Then
            TxtKpiPercenNilai1.Text = "60"
            TxtKpiPercenNilai2.Text = "40"
        ElseIf TxtKpiSummaryPosA.Text = "B" Or TxtKpiSummaryPosA.Text = "C" Then
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
        If TxtKpiSummaryPosA.Text = "A" Then
            nilaic.Visible = False
            LblTotal.Text = "Total A + Total B"
            Call GetData_NILAIA("select avg(KPID_NILAIAKHIR) AS TOTAL_NILAI1 from TRXN_KPID where KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPID_TYPEA='A' AND KPID_NIK='" & TxtStaffNIK.Text & "'")
            Call GetData_NILAIB("select round(avg(KPI_ATASAN),2) AS TOTAL_NILAI2 from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' and KPI_TIPEA='A' AND KPI_NIK='" & TxtStaffNIK.Text & "' ")
            LblNiaiAkhir1.Text = (Val(TxtKpiPercenNilai1.Text) * Val(TxtKpiTotalNilai1.Text)) / 100
            LblNiaiAkhir2.Text = (Val(TxtKpiPercenNilai2.Text) * Val(TxtKpiTotalNilai2.Text)) / 100
            LblNiaiAkhir4.Text = Val(LblNiaiAkhir1.Text) + Val(LblNiaiAkhir2.Text)
        Else
            Call GetData_NILAIA("select avg(KPI_ATASAN) AS TOTAL_NILAI1 from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_NIK='" & TxtStaffNIK.Text & "' and KPI_TIPEA='A'")
            Call GetData_NILAIB("select avg(KPI_ATASAN) AS TOTAL_NILAI2 from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_NIK='" & TxtStaffNIK.Text & "' and KPI_TIPEA='B'")
            Call GetData_NILAIC("select avg(KPI_AKHIR) AS TOTAL_NILAI3 from TRXN_KPIDD where KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_NIK='" & TxtStaffNIK.Text & "' and KPI_TIPEA='C'")
            LblTotal.Text = "Total A + Total B + Total C"
        End If



        MultiViewKpiMasterEntry.ActiveViewIndex = 0
        MultiViewKPIMasterDetail.ActiveViewIndex = 0
        MultiViewKpiMaster.ActiveViewIndex = -1
        Call ClikDetail_MultiViewKpiMaster()


    End Sub
    Sub ClearTabelKPIMaster()
        TxtKpiSummaryTahun.Text = "" : lblKpiSummaryTahun.Text = ""
        TxtKpiSummaryPosA.Text = "" : lblKpiSummaryPosA.Text = ""
        TxtKpiSummaryTahunNext.Text = ""
    End Sub
    Protected Sub BtnKpi40Master_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40Master.Click
        MultiViewKpiMasterEntry.ActiveViewIndex = 0
        Call ClearTabelKPIMaster()
    End Sub



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
        mSqlCommand = "INSERT INTO TRXN_KPIDD " & _
                      "SELECT " & TxtStaffNIK.Text & ",0,0,0,0,'A','" & mTahun & "',KPIN_TIPE " & _
                      "FROM DATA_KPIN WHERE KPIN_GROUP='PROCESS'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")

        If TxtKpiSummaryPosA.Text = "A" Then
            mSqlCommand = "INSERT INTO TRXN_KPIDD " & _
                      "SELECT " & TxtStaffNIK.Text & ",0,0,0,0,'A','" & mTahun & "',KPIN_TIPE " & _
                      "FROM DATA_KPIN WHERE KPIN_GROUP='PROCESS2'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        End If
        If TxtKpiSummaryPosA.Text = "D" Then
            mSqlCommand = "INSERT INTO TRXN_KPIDD " & _
                      "SELECT " & TxtStaffNIK.Text & ",0,0,0,0,'A','" & mTahun & "',KPIN_TIPE " & _
                      "FROM DATA_KPIN WHERE KPIN_GROUP='PROCESS3'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        End If
        If TxtKpiSummaryPosA.Text = "B" Or TxtKpiSummaryPosA.Text = "C" Then
            mSqlCommand = "INSERT INTO TRXN_KPIDD " & _
                      "SELECT " & TxtStaffNIK.Text & ",0,0,0,0,'C','" & mTahun & "',KPIN_TIPE " & _
                      "FROM DATA_KPIN WHERE KPIN_GROUP='ABSEN'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        End If
        If TxtKpiSummaryPosA.Text = "E" Then
            mSqlCommand = "INSERT INTO TRXN_KPIDD " & _
                      "SELECT " & TxtStaffNIK.Text & ",0,0,0,0,'C','" & mTahun & "',KPIN_TIPE " & _
                      "FROM DATA_KPIN WHERE KPIN_GROUP='HEAD'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        End If


    End Sub

    Protected Sub BtnKpi40MasterNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40MasterNew.Click
        'periksa ada aau tidak
        lblKpiSummaryTahun.Text = TxtKpiSummaryTahun.Text
        lblKpiSummaryPosA.Text = TxtKpiSummaryPosA.Text

        Call ClearTabelKPIDetail()
        MultiViewKPIMasterDetail.ActiveViewIndex = 0 : MultiViewKPIMasterDetailENtry.ActiveViewIndex = 0
        LvKPIMasterDetail.DataBind()
        Call ClikDetail_MultiViewKpiMaster()
    End Sub

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
    End Sub

    'Protected Sub BtnKpi40CopyBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40MasterBack.Click
    '  MultiViewKpiMasterEntry.ActiveViewIndex = -1
    ' Call DeaktifTabel1()
    ' End Sub







    '==Detail Kpi Berdasarkan Tahun==================================
    Protected Sub BtnKpi40_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40.Click
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = 0
        Call ClearTabelKPIDetail()
    End Sub
    Sub ClearTabelKPIDetail()
        TxtMasterKpiItem.Text = ""
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
        InsertDataNilaiKPI_Master = "INSERT INTO TRXN_KPID (KPID_NIK,KPID_TAHUN,KPID_ITEM,KPID_TYPEA) VALUES ('" & TxtStaffNIK.Text & "','" & TxtKpiSummaryTahun.Text & "','" & TxtPetik(TxtMasterKpiItem.Text) & "','" & TxtPetik(lblKpiSummaryPosA.Text) & "')"
    End Function
    Function EditDataNilaiKPI_Master() As String
        'KPID_TYPEA=A Percobaan B Karyawan
        EditDataNilaiKPI_Master = "UPDATE TRXN_KPID SET " & _
                                  "KPID_TARGET='" & TxtMasterKpiTarget.Text & "'," & _
                                  "KPID_PRESTASI='" & TxtMasterKpiPrestasi.Text & "'," & _
                                  "KPID_BOBOT='" & TxtMasterBobot.Text & "'," & _
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
                                  "WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(TxtMasterKpiItem.Text) & "'"
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
        Call GetData_MASTERKPI("SELECT * FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(TxtMasterKpiItem.Text) & "'")
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
        totalRapot = (total * bobot) / 100

        If GetFindRecord_Server("SELECT * FROM TRXN_KPIH WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'") <> 1 Then
            Dim mSqlCommand As String = ""
            mSqlCommand = "INSERT INTO TRXN_KPIH " & _
                          "(KPIH_NIK,KPIH_TAHUN,KPIH_TIPEA,KPIH_APPVUSER,KPIH_APPVUSERTGL,KPIH_APPVHEAD,KPIH_APPVHEADTGL,KPIH_APPVHRD,KPIH_APPVHRDTGL,KPIH_NILAI,KPIH_ABJAD,KPIH_NILAI1,KPIH_NILAI2,KPIH_NILAI3,KPIH_SP,KPIH_NILAISP,KPIH_NILAIPRC1,KPIH_NILAIPRC2,KPIH_NILAIPRC3) " & _
                          "VALUES ('" & TxtStaffNIK.Text & "','" & TxtKpiSummaryTahun.Text & "','" & TxtKpiSummaryPosA.Text & "','',NULL,'',NULL,'',NULL,0,'',0,0,0,'',0,0,0,0)"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
            Call nilailanjutan(TxtKpiSummaryTahun.Text)
        End If


        If GetFindRecord_Server("SELECT * FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(TxtMasterKpiItem.Text) & "'") <> 1 Then
            If UpdateData_Server(InsertDataNilaiKPI_Master, "Kpi40") = 1 Then
            End If
        End If
        Call UpdateData_Server(EditDataNilaiKPI_Master, "Kpi40")
        Dim mSqlCommand2 As String = ""
        mSqlCommand2 = "UPDATE TRXN_KPID SET KPID_NILAISTAFF='" & total & "', KPID_NILAIAKHIR='" & totalRapot & "' WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(TxtMasterKpiItem.Text) & "'"
        Call UpdateData_Server(mSqlCommand2, "Kpi40")

        LvKPIMasterDetail.DataBind()

        LVProses.DataBind()

        LVPeople.DataBind()
        LvDisiplin.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = 0
        Call ClikDetail_MultiViewKpiMaster()
    End Sub


    Protected Sub BtnKpi40Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40Del.Click
        Dim mSqlCommand As String = "DELETE FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(TxtMasterKpiItem.Text) & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1 : LvKPIMasterDetail.DataBind()
    End Sub

    '============================================================

    Function InsertDataNilaiKPI(ByVal mStatus As String, ByVal mItem As String, ByVal mGol As String) As String
        InsertDataNilaiKPI = "INSERT INTO TRXN_KPID (KPI_NIK,KPI_TAHUN,KPI_ITEM,KPI_TIPEA,KPI_TIPEB) VALUES ('" & TxtStaffNIK.Text & "','" & TxtKpiSummaryTahun.Text & "','" & TxtPetik(mItem) & "','" & mStatus & "','" & mGol & "')"

    End Function

    Function EditDataNilaiKPI(ByVal mStatus As String, ByVal mItem As String, ByVal mTarget As String, ByVal mNilaiStaff As String, _
                                     ByVal mNilaiHead As String, ByVal mNilaiAkhir As String) As String
        'KPID_TYPEA=1 Percobaan ( 2 Karyawan
        'KPID_TYPEB=A Skill B Kerjaan C Disiplin D Nilai E Nilai
        EditDataNilaiKPI = "UPDATE TRXN_KPIDD SET " & _
                                  "KPI_STAFF=" & mNilaiStaff & "," & _
                                  "KPI_ATASAN=" & mNilaiHead & "," & _
                                  "KPI_KOMENTAR='" & mNilaiAkhir & "'," & _
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
    End Sub

    Protected Sub LBKerjaA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVProses.SelectedIndexChanged
        LblProsesKodeItem.Text = (LVProses.DataKeys(LVProses.SelectedIndex).Value.ToString)
        Call GetData_MASTERKPIProses("SELECT * FROM TRXN_KPIDD,DATA_KPIN WHERE KPI_KODEITEM=KPIN_TIPE AND KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM ='" & TxtPetik(LblProsesKodeItem.Text) & "'")
        Call DeaktifProses()
    End Sub
    Protected Sub BtnKpi42ASave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi42ASave.Click
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'FORM HRD -- PENILAIAN BAWAHAN'") = 1 Then
            If TxtProsesStaff.Text <> TxtProsesHead.Text And TxtProsesKomentar.Text = "" Then
                LblErrorSaveKpi42A.Text = "Atasan Wajib Memberikan Komentar Kenapa Nilai Yang Diberikan Berbeda Dengan Nilai Staff!"
                MultiViewKpiMaster.ActiveViewIndex = -1
            Else
                Call UpdateData_Server(EditDataNilaiKPI("A", LblProsesKodeItem.Text, "", TxtProsesStaff.Text, TxtProsesHead.Text, TxtProsesKomentar.Text), "Kpi42A")
                LVProses.DataBind()
                MultiViewKpiMasterEntry.ActiveViewIndex = 0
                Call ClikDetail_MultiViewKpiMaster()
            End If
        Else
            Call UpdateData_Server(EditDataNilaiKPI("A", LblProsesKodeItem.Text, "", TxtProsesStaff.Text, TxtProsesHead.Text, TxtProsesKomentar.Text), "Kpi42A")
            LVProses.DataBind()
            MultiViewKpiMasterEntry.ActiveViewIndex = 0
            Call ClikDetail_MultiViewKpiMaster()
        End If

    End Sub
    Protected Sub BtnKpi42ABack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi42ABack.Click
        LVProses.DataBind()
        MultiViewProsesEntry.ActiveViewIndex = -1
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
        Call GetData_MASTERKPIPeople("SELECT * FROM TRXN_KPIDD, DATA_KPIN WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM ='" & TxtPetik(LblPeopleKode.Text) & "' AND KPIN_TIPE=KPI_KODEITEM")
        Call DeaktifPeople()
    End Sub
    Protected Sub BtnKpi42BSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi42BSave.Click
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'FORM HRD -- PENILAIAN BAWAHAN'") = 1 Then
            If TxtPeopleStaff.Text <> TxtPeopleAtasan.Text And TxtPeopleKomentar.Text = "" Then
                LblErrorSaveKpi42B.Text = "Atasan Wajib Memberikan Komentar Kenapa Nilai Yang Diberikan Berbeda Dengan Nilai Staff!"
                MultiViewKpiMaster.ActiveViewIndex = -1
            Else
                Call UpdateData_Server(EditDataNilaiKPI("C", LblPeopleKode.Text, "", TxtPeopleStaff.Text, TxtPeopleAtasan.Text, TxtPeopleKomentar.Text), "Kpi42A")
                LVPeople.DataBind()
                MultiViewKpiMasterEntry.ActiveViewIndex = 0
                Call ClikDetail_MultiViewKpiMaster()
            End If
        Else
            Call UpdateData_Server(EditDataNilaiKPI("C", LblPeopleKode.Text, "", TxtPeopleStaff.Text, TxtPeopleAtasan.Text, TxtPeopleKomentar.Text), "Kpi42A")
            LVPeople.DataBind()
            MultiViewKpiMasterEntry.ActiveViewIndex = 0
            Call ClikDetail_MultiViewKpiMaster()
        End If
    End Sub
    Protected Sub BtnKpi42BDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi42BBack.Click
        MultiViewPeopleEntry.ActiveViewIndex = -1
    End Sub






    '43

    Sub ClearTabelDisiplin()
        lblDisiplinKode.Text = ""
        lblDisiplinJudul.Text = ""
        TxtDisiplinNilai.Text = ""
    End Sub
    Protected Sub LvDisiplin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDisiplin.SelectedIndexChanged
        lblDisiplinKode.Text = (LvDisiplin.DataKeys(LvDisiplin.SelectedIndex).Value.ToString)
        Call GetData_MASTERKPIDisiplin("SELECT * FROM TRXN_KPIDD, data_kpin WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "' AND KPI_KODEITEM ='" & TxtPetik(lblDisiplinKode.Text) & "' AND KPIN_TIPE= KPI_KODEITEM")
        Call DeaktifDisiplin()
    End Sub
    Protected Sub BtnKpi43Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi43Save.Click
        Call UpdateData_Server(EditDataNilaiKPI2("C", lblDisiplinKode.Text, "", TxtDisiplinNilai.Text), "Kpi42A")
        LvDisiplin.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = 0
        Call ClikDetail_MultiViewKpiMaster()
    End Sub
    Protected Sub BtnKpi43Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi43Back.Click
        MultiViewDisplinEntry.ActiveViewIndex = -1
    End Sub





    Sub clearnilaiOthers()
        TxtKpiTotalNilai1.Text = "0"
        TxtKpiTotalNilai2.Text = "0"
        TxtKpiTotalNilai3.Text = "0"
        LblNiaiAkhir1.Text = "0"
        LblNiaiAkhir2.Text = "0"
        LblNiaiAkhir3.Text = "0"
        LblNiaiAkhir4.Text = "0"
        LblNiaiAkhir5.Text = "0"
        LblNiaiAkhir6.Text = "0"
        LblNiaiAkhir7.Text = "0"
        TxtNilaiSP.Text = "0"
        Call GetData_MASTEROthers("SELECT * FROM TRXN_KPIH WHERE KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'")
    End Sub

    Protected Sub BtnKpi44Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi44Setuju1.Click
        Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                    "KPIH_NILAI1=" & TxtKpiPercenNilai1.Text & "," & _
                                    "KPIH_NILAI2=" & TxtKpiPercenNilai2.Text & "," & _
                                    "KPIH_NILAI3=" & TxtKpiPercenNilai3.Text & "," & _
                                    "KPIH_NILAIPRC1=" & TxtKpiTotalNilai1.Text & "," & _
                                    "KPIH_NILAIPRC2=" & TxtKpiTotalNilai2.Text & "," & _
                                    "KPIH_NILAIPRC3=" & TxtKpiTotalNilai3.Text & "," & _
                                    "KPIH_SP=" & TxtNilaiSP.Text & "," & _
                                    "KPIH_NILAISP=" & LblNiaiAkhir5.Text & "," & _
                                    "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi44")
    End Sub
    Protected Sub BtnKpi44Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi44Setuju2.Click
        Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                    "" & _
                                    "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & TxtKpiSummaryTahun.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi44")
    End Sub




    '============End Hal 4


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
                TxtKpiPercenNilai1.Text = nSr(MyRecReadA("KPIH_NILAIPRC1")) : TxtKpiTotalNilai1.Text = nSr(MyRecReadA("KPIH_NILAI1"))
                TxtKpiPercenNilai2.Text = nSr(MyRecReadA("KPIH_NILAIPRC2")) : TxtKpiTotalNilai2.Text = nSr(MyRecReadA("KPIH_NILAI2"))
                TxtKpiPercenNilai3.Text = nSr(MyRecReadA("KPIH_NILAIPRC3")) : TxtKpiTotalNilai3.Text = nSr(MyRecReadA("KPIH_NILAI3"))
                LblNiaiAkhir1.Text = "0"
                LblNiaiAkhir2.Text = "0"
                LblNiaiAkhir3.Text = "0"
                LblNiaiAkhir4.Text = "0"  'Total

                TxtNilaiSP.Text = nSr(MyRecReadA("KPIH_SP"))      'SP
                LblNiaiAkhir5.Text = nSr(MyRecReadA("KPIH_NILAISP"))  'Nilai SP
                LblNiaiAkhir6.Text = "0"  'Nilai Akhir
                LblNiaiAkhir7.Text = "0"  'Grade 
                TxtNilaiSP.Text = "0"

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
                TxtMasterKpiItem.Text = nSr(MyRecReadA("KPID_ITEM"))
                TxtMasterKpiTarget.Text = nSr(MyRecReadA("KPID_TARGET"))
                TxtMasterKpiPrestasi.Text = nSr(MyRecReadA("KPID_PRESTASI"))
                TxtMasterBobot.Text = nSr(MyRecReadA("KPID_Bobot"))
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

                LblProsesKodeItem.Text = nSr(MyRecReadA("KPI_KODEITEM"))
                LblProsesJudulJudul.Text = nSr(MyRecReadA("KPIN_JUDUL"))
                TxtProsesStaff.Text = nSr(MyRecReadA("KPI_STAFF"))
                TxtProsesHead.Text = nSr(MyRecReadA("KPI_ATASAN"))
                TxtProsesKomentar.Text = nSr(MyRecReadA("KPI_KOMENTAR"))

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

    Function GetData_MASTERKPIDisiplin(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MASTERKPIDisiplin = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                lblDisiplinKode.Text = nSr(MyRecReadA("KPI_KODEITEM"))
                lblDisiplinJudul.Text = nSr(MyRecReadA("KPIN_JUDUL"))
                TxtDisiplinNilai.Text = nSr(MyRecReadA("KPI_AKHIR"))

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
                DropDownList7.Text = nSr(MyRecReadA("KPI_ITEM"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_MASTERSTANDARD(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MASTERSTANDARD = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtStandardKode.Text = nSr(MyRecReadA("KPIN_TIPE"))
                TxtStandardGroup.Text = nSr(MyRecReadA("KPIN_GROUP"))
                TxtStandardJudul.Text = nSr(MyRecReadA("KPIN_JUDUL"))
                TxtStandardKet.Text = nSr(MyRecReadA("KPIN_DESC"))
                TxtStandardNilai6.Text = nSr(MyRecReadA("KPIN_NILAI6"))
                TxtStandardNilai7.Text = nSr(MyRecReadA("KPIN_NILAI7"))
                TxtStandardNilai8.Text = nSr(MyRecReadA("KPIN_NILAI8"))
                TxtStandardNilai9.Text = nSr(MyRecReadA("KPIN_NILAI9"))
                TxtStandardNilai10.Text = nSr(MyRecReadA("KPIN_NILAI10"))

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
                TxtStatusKerjaDept.Text = nSr(MyRecReadA("STAFF_STATUSKERJADEPT")) + " / " + nSr(MyRecReadA("STAFF_STATUSKERJAJABATAN"))
                TxtStatusKerjaTempat.Text = nSr(MyRecReadA("STAFF_STATUSKERJALOKASI"))

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
        LblErrorSaveKpi43.Text = ""
        LblErrorSaveKpi44.Text = ""
        LblErrorSaveStandard.Text = ""
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

        If Kode = "Kpi40" Then
            LblErrorSaveKpi40.Text = Errormsg

        ElseIf Kode = "Kpi42A" Then
            LblErrorSaveKpi42A.Text = Errormsg
        ElseIf Kode = "Kpi42B" Then
            LblErrorSaveKpi42B.Text = Errormsg
        ElseIf Kode = "Kpi43" Then
            LblErrorSaveKpi43.Text = Errormsg
        ElseIf Kode = "Kpi44" Then
            LblErrorSaveKpi44.Text = Errormsg
        ElseIf Kode = "Std" Then
            LblErrorSaveStandard.Text = Errormsg
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

    Function nLg(ByRef nilai As Object) As Double
        On Error GoTo ErrHand
        nLg = 0
        nilai = Replace(nilai, ",", "")
        If IsNumeric(nilai) Then nLg = Val(nilai)
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








    Protected Sub BtnStandardBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardBack.Click
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        LVNilaiStandard.DataBind()
    End Sub

    Protected Sub BtnKpi40Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40Back.Click
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1
        LvKPIMasterDetail.DataBind()
    End Sub






End Class
