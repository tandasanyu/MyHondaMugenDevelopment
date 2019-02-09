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


Partial Class Default2
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
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM HRD -- VIEW DATA'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0 : LvDetailStaff.DataBind()
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM HRD -- ADD DATA'") = 1 Then
                    Button40.Visible = True
                Else
                    Button40.Visible = False
                End If
            Else
                MultiViewAkses.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub

    '============Start Hal Utama
    Protected Sub Button40_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button40.Click

        MultiViewAkses.ActiveViewIndex = 1
        Call ClearDetailStaff()
        Call ClearStatusStaff()
    End Sub
    Protected Sub LvDetailStaff_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailStaff.SelectedIndexChanged
        TxtStaffNIK.Text = (LvDetailStaff.DataKeys(LvDetailStaff.SelectedIndex).Value.ToString)
        'MsgBox(TxtStaffNIK.Text)
        Call GetData_STAFF("SELECT * FROM DATA_STAFF WHERE STAFF_NIK='" & TxtStaffNIK.Text & "'")
        Call AktifUtammaKlikDetailKaryawan()
    End Sub

    Protected Sub ButtonA1Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonA1Save.Click
        If Not IsDate(TxtStaffLahirTgl) Then
            LblErrorSaveA1.Text = ""
        End If

        If GetFindRecord_Server("SELECT * FROM DATA_STAFF WHERE STAFF_NIK='" & TxtStaffNIK.Text & "'") <> 1 Then
            If UpdateData_Server(InsertDataStaff, "A1") = 1 Then
                lblStaffNIK.Text = TxtStaffNIK.Text
            End If
        End If
        Call UpdateData_Server(EditDataStaff, "A1")
    End Sub
    Protected Sub ButtonA1Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonA1Del.Click
        Dim mSqlCommand As String = "DELETE FROM DATA_STAFF WHERE STAFF_NIK='" & TxtStaffNIK.Text & "'"
        Call UpdateData_Server(mSqlCommand, "A1")
    End Sub
    Protected Sub ButtonA1Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonA1Back.Click
        MultiViewAkses.ActiveViewIndex = 0
        LvDetailStaff.DataBind()
    End Sub

    Function InsertDataStaff() As String
        InsertDataStaff = "INSERT INTO DATA_STAFF (STAFF_NIK) VALUES ('" & TxtStaffNIK.Text & "')"
    End Function
    Function EditDataStaff() As String
        EditDataStaff = "UPDATE DATA_STAFF SET " & _
               "STAFF_NAMA='" & TxtPetik(TxtStaffNama.Text) & "',STAFF_LAHIRTMP='" & TxtPetik(TxtStaffLahirTmp.Text) & "',STAFF_LAHIRTGL=" & DtFrSQL(TxtStaffLahirTgl.Text) & ",STAFF_STATUS='" & DropDownList1.Text & "'," & _
               "STAFF_ALAMATJLN='" & TxtPetik(TxtStaffJalan.Text) & "',STAFF_ALAMATRT='" & TxtPetik(TxtStaffRT.Text) & "',STAFF_ALAMATRW='" & TxtPetik(TxtStaffRW.Text) & "'," & _
               "STAFF_ALAMATKEL='" & TxtPetik(TxtStaffKel.Text) & "',STAFF_ALAMATKAB='" & TxtPetik(TxtStaffKota.Text) & "',STAFF_ALAMATPOS='" & TxtStaffKodePos.Text & "'," & _
               "STAFF_EMAIL='" & TxtStaffEmail.Text & "'," & _
               "STAFF_NOKTP='" & TxtStaffNoKtp.Text & "'," & _
               "STAFF_SIMTYPE='" & TxtStaffSIMType.Text & "',STAFF_SIMNO='" & TxtStaffSIMNomor.Text & "'," & _
               "STAFF_NOBPJSKERJA='" & TxtStaffBPJSKerja.Text & "',STAFF_NOBPJSSEHAT='" & TxtStaffBPJSSehat.Text & "',STAFF_NPWP='" & TxtStaffNPWP.Text & "'," & _
               "STAFF_REKBCA='" & TxtStaffBCA.Text & "',STAFF_HP='" & TxtStaffNoHP.Text & "',STAFF_PHONE='" & TxtStaffNoTelepon.Text & "',STAFF_CONTACT='" & TxtStaffNoContact.Text & "'," & _
               "STAFF_STATUSKERJAMASUKK=" & DtFrSQL(TxtStatusKerjaMasuk.Text) & ", STAFF_STATUSKERJAJABATAN='" & TxtStatusKerjaJabatan.Text & "', " & _
               "STAFF_STATUSKERJADEPT='" & TxtStatusKerjaDept.Text & "', STAFF_STATUSKERJADIVISI='" & TxtStatusKerjaDivis.Text & "', " & _
               "STAFF_STATUSKERJALOKASI='" & TxtStatusKerjaTempat.Text & "', " & _
               "STAFF_STATUSKERJAMG='" & DropDownList2.Text & "', STAFF_STATUSKERJAMGTGL=" & DtFrSQL(TxtStatusKerjaMagangTglAkhir.Text) & ", " & _
               "STAFF_STATUSKERJAPC='" & DropDownList3.Text & "', STAFF_STATUSKERJAPCTGL=" & DtFrSQL(TxtStatusKerjaCobaTglAkhir.Text) & "," & _
               "STAFF_STATUSKERJAKT1='" & DropDownList4.Text & "', STAFF_STATUSKERJAKT1TGL=" & DtFrSQL(TxtStatusKerjaKontrak1TglAkhir.Text) & "," & _
               "STAFF_STATUSKERJAKT2='" & DropDownList5.Text & "', STAFF_STATUSKERJAKT2TGL=" & DtFrSQL(TxtStatusKerjaKontrak2TglAkhir.Text) & ", " & _
               "STAFF_STATUSKERJAKTG='" & DropDownList6.Text & "', STAFF_STATUSKERJAKTGTGL=" & DtFrSQL(TxtStatusKerjaAgenTglAkhir.Text) & "," & _
               "STAFF_STATUSKERJATGLANGKAT=" & DtFrSQL(TxtStatusKerjaTetap.Text) & ", " & _
               "STAFF_STATUSKERJATGLKELUAR=" & DtFrSQL(TxtStatusKerjaKeluar.Text) & ", STAFF_STATUSKERJAALSKELUAR='" & TxtPetik(TxtStatusKerjaAlasan.Text) & "'" & _
               "WHERE  STAFF_NIK='" & TxtStaffNIK.Text & "'"
        'MsgBox(EditDataStaff)
    End Function

    Sub HakDataKeryawan()
        Button40.Visible = False
        ButtonA1Upload.Visible = False : ButtonA1Save.Visible = False : ButtonA1Del.Visible = False

        BtnA110Master1.Visible = False
        BtnA111Save.Visible = False : BtnA111Del.Visible = False

        BtnA112Save.Visible = False : BtnA112Del.Visible = False

        BtnA110Master2.Visible = False
        BtnA113Save.Visible = False : BtnA113Del.Visible = False

        BtnA120Master.Visible = False
        BtnA12Save.Visible = False : BtnA12Del.Visible = False

        BtnA130Master.Visible = False
        BtnA13Save.Visible = False : BtnA13Del.Visible = False

        '=================================================
        BtnStandardTabel.Visible = False
        BtnStandard.Visible = False
        BtnStandardSave.Visible = False : BtnStandardDel.Visible = False

        BtnKpi40.Visible = False
        BtnKpi40Save.Visible = False : BtnKpi40Del.Visible = False

        BtnKpi41A.Visible = False
        BtnKpi41A.Visible = False : BtnKpi41A.Visible = False
        BtnKpi41B.Visible = False
        BtnKpi41B.Visible = False : BtnKpi41B.Visible = False

        BtnKpi42A.Visible = False
        BtnKpi42A.Visible = False : BtnKpi42A.Visible = False
        BtnKpi42.Visible = False
        BtnKpi42BSave.Visible = False

        BtnKpi43.Visible = False
        BtnKpi43Save.Visible = False

        BtnKpi44Setuju1.Visible = False : BtnKpi44Setuju2.Visible = False

    End Sub

    Sub ClearDetailStaff()
        TxtStaffNIK.Text = "" : lblStaffNIK.Text = ""
        TxtStaffNIK.Enabled = True
        TxtStaffNama.Text = ""
        TxtStaffLahirTmp.Text = "" : TxtStaffLahirTgl.Text = ""
        DropDownList1.SelectedIndex = -1
        TxtStaffJalan.Text = ""
        TxtStaffRT.Text = "" : TxtStaffRW.Text = ""
        TxtStaffKel.Text = "" : TxtStaffKota.Text = ""
        TxtStaffKodePos.Text = ""
        TxtStaffEmail.Text = ""
        TxtStaffNoKtp.Text = ""
        TxtStaffSIMType.Text = "" : TxtStaffSIMNomor.Text = ""
        TxtStaffBPJSKerja.Text = ""
        TxtStaffBPJSSehat.Text = ""
        TxtStaffNPWP.Text = ""
        TxtStaffBCA.Text = ""
        TxtStaffNoHP.Text = ""
        TxtStaffNoTelepon.Text = ""
        TxtStaffNoContact.Text = ""
    End Sub
    Sub ClearStatusStaff()
        TxtStatusKerjaMasuk.Text = ""
        TxtStatusKerjaJabatan.Text = ""
        TxtStatusKerjaDept.Text = ""
        TxtStatusKerjaDivis.Text = ""
        TxtStatusKerjaTempat.Text = ""
        DropDownList2.SelectedIndex = -1 : TxtStatusKerjaMagangTglAkhir.Text = ""
        DropDownList3.SelectedIndex = -1 : TxtStatusKerjaCobaTglAkhir.Text = ""
        DropDownList4.SelectedIndex = -1 : TxtStatusKerjaKontrak1TglAkhir.Text = ""
        DropDownList5.SelectedIndex = -1 : TxtStatusKerjaKontrak2TglAkhir.Text = ""
        DropDownList6.SelectedIndex = -1 : TxtStatusKerjaAgenTglAkhir.Text = ""
        TxtStatusKerjaTetap.Text = ""
        TxtStatusKerjaKeluar.Text = ""
        TxtStatusKerjaAlasan.Text = ""

        TxtLatihPelatih.Text = ""
        TxtLatihJenis.Text = ""
        TxtLatihNama.Text = ""
        TxtLatihTgl.Text = ""
        TxtLatihBiaya.Text = ""
        TxtLatihHasil.Text = ""
        'TdkTrpakai STAFFPK1_NIK,STAFFPK1_NOITEM,STAFFPK1_TARGET,STAFFPK1_PRESTASI,STAFFPK1_STATUS-->[A:Profesional Skil B:Proses kerja C:Absensi]
    End Sub

    Sub AktifUtammaKlikDetailKaryawan()
        MultiViewAkses.ActiveViewIndex = 1
        MultiView102Detail.ActiveViewIndex = -1
    End Sub

    '============end Hal Utama



    '============Start Pilihan Halaman
    Protected Sub Tab01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab01.Click
        MultiView102Detail.ActiveViewIndex = 0
        LVPendidikanFormal.DataBind()
        MultiView10201DidikFormalENtry.ActiveViewIndex = -1

        Call GetData_FORMALLanjutan("SELECT * FROM DATA_STAFFFO WHERE STAFFFO_TIPE='L' AND STAFFFO_NIK LIKE '" & TxtStaffNIK.Text & "'")

        LVPendidikanNonFormal.DataBind()
        MultiView10202DidikNonFormalEntry.ActiveViewIndex = -1

    End Sub
    Protected Sub Tab02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab02.Click
        MultiView102Detail.ActiveViewIndex = 1
        LVPengalamanKerja.DataBind()
        MultiViewKerjaEntry.ActiveViewIndex = -1
    End Sub
    Protected Sub Tab04_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab04.Click
        MultiView102Detail.ActiveViewIndex = 2
        LVPelatihan.DataBind()
        MultiViewPelatihanEntry.ActiveViewIndex = -1
    End Sub
    Protected Sub Tab05_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab05.Click
        MultiView102Detail.ActiveViewIndex = 3
        Call DeaktifTabel1()
    End Sub
    '============end Pilihan Halaman
    Sub DeaktifTabel1()
        MultiViewKpiMaster.ActiveViewIndex = 0 : LvKpiMasterSummary.DataBind()
        MultiViewKpiMasterEntry.ActiveViewIndex = -1

        MultiViewKPIMasterDetail.ActiveViewIndex = -1
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1

        MultiViewNilaiStandard.ActiveViewIndex = -1
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1

        MultiKPISkillATabel.ActiveViewIndex = -1
        MultiKPISkillAEntry.ActiveViewIndex = -1

        MultiKpiSkillBTabel.ActiveViewIndex = -1
        MultiKpiSkillBENtry.ActiveViewIndex = -1

        MultiViewProsesTabel.ActiveViewIndex = -1
        MultiViewProsesEntry.ActiveViewIndex = -1

        MultiViewPeopleTabel.ActiveViewIndex = -1
        MultiViewPeopleEntry.ActiveViewIndex = -1

        MultiViewDisiplin.ActiveViewIndex = -1
        MultiViewDisplinEntry.ActiveViewIndex = -1

        MultiViewOthers.ActiveViewIndex = -1
        '=============

    End Sub

    Sub ClikDetail_MultiViewKpiMaster()


        MultiViewProsesTabel.ActiveViewIndex = 0 : MultiViewProsesEntry.ActiveViewIndex = -1 : LVProses.DataBind()

        If lblKpiSummaryPosA.Text = "A" Then
            'Percobaan
            MultiKPISkillATabel.ActiveViewIndex = 0 : MultiKPISkillAEntry.ActiveViewIndex = -1 : LvSkillA.DataBind()
            MultiKpiSkillBTabel.ActiveViewIndex = -1 : MultiKpiSkillBENtry.ActiveViewIndex = -1
        Else
            'Karyawan
            MultiKPISkillATabel.ActiveViewIndex = -1 : MultiKPISkillAEntry.ActiveViewIndex = -1
            MultiKpiSkillBTabel.ActiveViewIndex = 0 : MultiKpiSkillBENtry.ActiveViewIndex = -1 : LvSkillB.DataBind()
        End If
        If lblKpiSummaryPosB.Text = "A" Then
            'Staff
            MultiViewPeopleTabel.ActiveViewIndex = -1 : MultiViewPeopleEntry.ActiveViewIndex = -1
            MultiViewDisiplin.ActiveViewIndex = 0 : MultiViewDisplinEntry.ActiveViewIndex = -1 : LvDisiplin.DataBind()
        Else
            'Atasan
            MultiViewPeopleTabel.ActiveViewIndex = 0 : MultiViewPeopleEntry.ActiveViewIndex = -1 : LVPeople.DataBind()
            MultiViewDisiplin.ActiveViewIndex = -1 : MultiViewDisplinEntry.ActiveViewIndex = -1
        End If
        MultiViewOthers.ActiveViewIndex = 0
    End Sub





    '============Start Hal 1
    Protected Sub BtnA110Master1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA110Master1.Click
        MultiView10201DidikFormalENtry.ActiveViewIndex = 0

    End Sub
    Protected Sub BtnA110Master2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA110Master2.Click
        MultiView10202DidikNonFormalEntry.ActiveViewIndex = 0
    End Sub
    Sub ClearPendidikanStaffFormal()
        TxtPendidikanTingkat.Text = ""
        TxtPendidikanNama.Text = ""
        TxtPendidikanJurusan.Text = ""
        TxtPendidikanTahun.Text = ""
        TxtPendidikanKet.Text = ""
        TxtPendidikanIjazah.Text = ""
    End Sub
    Sub ClearPendidikanStaffNonFormal()
        TxtDidikNonFormalTingkat.Text = ""
        TxtDidikNonFormalNama.Text = ""
        TxtDidikNonFormalJudul.Text = ""
        TxtDidikNonFormalTahun.Text = ""
    End Sub
    Sub ClearPendidikanLanjut()
        TxtPendidikanLanjutYN.Text = ""
        TxtPendidikanLanjutNama.Text = ""
        TxtPendidikanLanjutJurusan.Text = ""
        TxtPendidikanLanjutSMS.Text = ""
    End Sub

    Function InsertDataPendidikan(ByVal mStatus As String, ByVal mTingkat As String) As String
        'F=FORMAL N=Non Formal L=Lanjutkan
        InsertDataPendidikan = "INSERT INTO DATA_STAFFFO (STAFFFO_NIK,STAFFFO_TINGKAT,STAFFFO_TIPE) VALUES ('" & TxtStaffNIK.Text & "','" & mTingkat & "','" & mStatus & "')"
    End Function
    Function EditDataPendidikanFormal(ByVal mStatus As String) As String
        EditDataPendidikanFormal = "UPDATE DATA_STAFFFO SET " & _
                                    "STAFFFO_NAMA='" & TxtPendidikanNama.Text & "'," & _
                                    "STAFFFO_JURUSAN='" & TxtPendidikanJurusan.Text & "'," & _
                                    "STAFFFO_TAHUN='" & TxtPendidikanTahun.Text & "'," & _
                                    "STAFFFO_KET='" & TxtPendidikanKet.Text & "'," & _
                                    "STAFFFO_IJAZAH='" & TxtPendidikanIjazah.Text & "' " & _
                                    "WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TINGKAT='" & TxtPendidikanTingkat.Text & "' AND STAFFFO_TIPE='" & mStatus & "'"
    End Function
    Function EditDataPendidikanNonFormal(ByVal mStatus As String) As String
        EditDataPendidikanNonFormal = "UPDATE DATA_STAFFFO SET " & _
                                    "STAFFFO_NAMA='" & TxtDidikNonFormalNama.Text & "'," & _
                                    "STAFFFO_JURUSAN='" & TxtDidikNonFormalJudul.Text & "'," & _
                                    "STAFFFO_TAHUN='" & TxtDidikNonFormalTahun.Text & "'," & _
                                    "STAFFFO_KET=''," & _
                                    "STAFFFO_IJAZAH='N' " & _
                                    "WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TINGKAT='" & TxtDidikNonFormalTingkat.Text & "' AND STAFFFO_TIPE='" & mStatus & "'"
    End Function
    Function EditDataPendidikanLanjutan(ByVal mStatus As String) As String
        EditDataPendidikanLanjutan = "UPDATE DATA_STAFFFO SET " & _
                                    "STAFFFO_NAMA='" & TxtPendidikanLanjutJurusan.Text & "'," & _
                                    "STAFFFO_JURUSAN='" & TxtPendidikanJurusan.Text & "'," & _
                                    "STAFFFO_TAHUN=''," & _
                                    "STAFFFO_KET='" & TxtPendidikanLanjutSMS.Text & "'," & _
                                    "STAFFFO_IJAZAH='N' " & _
                                    "WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TIPE='" & mStatus & "'"
    End Function

    Protected Sub LVPendidikanFormal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVPendidikanFormal.SelectedIndexChanged
        TxtPendidikanTingkat.Text = (LVPendidikanFormal.DataKeys(LVPendidikanFormal.SelectedIndex).Value.ToString)
        Call GetData_FORMAL("SELECT * FROM DATA_STAFFFO WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TINGKAT='" & TxtPendidikanTingkat.Text & "' AND STAFFFO_TIPE='F'")
        MultiView10201DidikFormalENtry.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnA111Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA111Save.Click
        If GetFindRecord_Server("SELECT * FROM DATA_STAFFFO WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TINGKAT='" & TxtPendidikanTingkat.Text & "' AND STAFFFO_TIPE='F'") <> 1 Then
            If UpdateData_Server(InsertDataPendidikan("F", TxtPendidikanTingkat.Text), "A111") = 1 Then
                lblStaffNIK.Text = TxtStaffNIK.Text
            End If
        End If
        If lblStaffNIK.Text = TxtStaffNIK.Text Then
            Call UpdateData_Server(EditDataPendidikanFormal("F"), "A111")
        End If

        MultiView10201DidikFormalENtry.ActiveViewIndex = -1
        LVPendidikanFormal.DataBind()
    End Sub
    Protected Sub BtnA111del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA111Del.Click
        Dim mSqlCommand As String = "DELETE FROM DATA_STAFFFO WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TINGKAT='" & TxtPendidikanTingkat.Text & "' AND STAFFFO_TIPE='F'"
        Call UpdateData_Server(mSqlCommand, "A111")
        MultiView10201DidikFormalENtry.ActiveViewIndex = -1
        LVPendidikanFormal.DataBind()
    End Sub

    Protected Sub BtnA112Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA112Save.Click
        If GetFindRecord_Server("SELECT * FROM DATA_STAFFFO WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TIPE='L'") <> 1 Then
            If UpdateData_Server(InsertDataPendidikan("L", TxtPendidikanLanjutSMS.Text), "A112") = 1 Then
                lblStaffNIK.Text = TxtStaffNIK.Text
            End If
        End If
        If lblStaffNIK.Text = TxtStaffNIK.Text Then
            Call UpdateData_Server(EditDataPendidikanLanjutan("L"), "A112")
        End If

    End Sub
    Protected Sub BtnA112Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA112Del.Click
        Dim mSqlCommand As String = "DELETE FROM DATA_STAFFFO WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TIPE='L'"
        Call UpdateData_Server(mSqlCommand, "A112")
    End Sub

    Protected Sub LVPendidikanNonFormal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVPendidikanNonFormal.SelectedIndexChanged
        TxtDidikNonFormalTingkat.Text = (LVPendidikanNonFormal.DataKeys(LVPendidikanNonFormal.SelectedIndex).Value.ToString)
        Call GetData_NONFORMAL("SELECT * FROM DATA_STAFFFO WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TINGKAT='" & TxtDidikNonFormalTingkat.Text & "' AND STAFFFO_TIPE='N'")
        MultiView10202DidikNonFormalEntry.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnA113Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA113Save.Click
        If GetFindRecord_Server("SELECT * FROM DATA_STAFFFO WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TINGKAT='" & TxtDidikNonFormalTingkat.Text & "' AND STAFFFO_TIPE='N'") <> 1 Then
            If UpdateData_Server(InsertDataPendidikan("N", TxtDidikNonFormalTingkat.Text), "A113") = 1 Then
                lblStaffNIK.Text = TxtStaffNIK.Text
            End If
        End If
        If lblStaffNIK.Text = TxtStaffNIK.Text Then
            Call UpdateData_Server(EditDataPendidikanNonFormal("N"), "A113")
        End If

        MultiView10202DidikNonFormalEntry.ActiveViewIndex = -1
        LVPendidikanNonFormal.DataBind()
    End Sub
    Protected Sub BtnA113Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA113Del.Click
        Dim mSqlCommand As String = "DELETE FROM DATA_STAFFFO WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TINGKAT='" & TxtDidikNonFormalTingkat.Text & "' AND STAFFFO_TIPE='N'"
        Call UpdateData_Server(mSqlCommand, "A113")
        MultiView10202DidikNonFormalEntry.ActiveViewIndex = -1
        LVPendidikanNonFormal.DataBind()
    End Sub


    '============End Hal 1

    '============Start Hal 2
    Protected Sub BtnA120Master_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA120Master.Click
        MultiViewKerjaEntry.ActiveViewIndex = 0
        Call ClearPengalamanStaff()
    End Sub
    Sub ClearPengalamanStaff()
        TxtCompanyNama.Text = ""
        TxtCompanyAlamat.Text = ""
        TxtCompanyJabatan.Text = ""
        TxtCompanyMasuk.Text = ""
        TxtCompanyKeluar.Text = ""
    End Sub
    Function InsertDataPengalaman() As String
        InsertDataPengalaman = "INSERT INTO DATA_STAFFKR (STAFFKR_NIK,STAFFKR_NAMA) VALUES ('" & TxtStaffNIK.Text & "','" & TxtCompanyNama.Text & "')"

    End Function
    Function EditDataPengalaman() As String
        EditDataPengalaman = "UPDATE DATA_STAFFKR SET " & _
                                    "STAFFKR_ALAMAT='" & TxtCompanyAlamat.Text & "'," & _
                                    "STAFFKR_JABATAN='" & TxtCompanyJabatan.Text & "'," & _
                                    "STAFFKR_MASUK='" & TxtCompanyMasuk.Text & "'," & _
                                    "STAFFKR_KELUAR='" & TxtCompanyKeluar.Text & "'" & _
                                    "WHERE STAFFKR_NIK='" & TxtStaffNIK.Text & "' AND STAFFKR_NAMA='" & TxtCompanyNama.Text & "'"
    End Function

    Protected Sub LVPengalamanKerja_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVPengalamanKerja.SelectedIndexChanged
        TxtCompanyNama.Text = (LVPengalamanKerja.DataKeys(LVPengalamanKerja.SelectedIndex).Value.ToString)
        Call GetData_KERJA("SELECT * FROM DATA_STAFFKR WHERE STAFFKR_NIK='" & TxtStaffNIK.Text & "' AND STAFFKR_NAMA='" & TxtCompanyNama.Text & "'")
        MultiViewKerjaEntry.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnA12Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA12Save.Click
        If GetFindRecord_Server("SELECT * FROM DATA_STAFFKR WHERE STAFFKR_NIK='" & TxtStaffNIK.Text & "' AND STAFFKR_NAMA='" & TxtCompanyNama.Text & "'") <> 1 Then
            If UpdateData_Server(InsertDataPengalaman, "A12") = 1 Then
                lblStaffNIK.Text = TxtStaffNIK.Text
            End If
        End If
        If lblStaffNIK.Text = TxtStaffNIK.Text Then
            Call UpdateData_Server(EditDataPengalaman, "A12")
        End If

        MultiViewKerjaEntry.ActiveViewIndex = -1
        LVPengalamanKerja.DataBind()

    End Sub
    Protected Sub BtnA12Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA12Del.Click
        Dim mSqlCommand As String = "DELETE FROM DATA_STAFFKR WHERE STAFFKR_NIK='" & TxtStaffNIK.Text & "' AND STAFFKR_NAMA='" & TxtCompanyNama.Text & "'"
        Call UpdateData_Server(mSqlCommand, "A12")
        MultiViewKerjaEntry.ActiveViewIndex = -1
        LVPengalamanKerja.DataBind()
    End Sub

    '============End Hal 2

    '============Start Hal 3
    Protected Sub BtnA130Master_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA130Master.Click
        MultiViewPelatihanEntry.ActiveViewIndex = 0
    End Sub
    Sub ClearLatihanStaff()
        TxtLatihPelatih.Text = ""
        TxtLatihJenis.Text = ""
        TxtLatihNama.Text = ""
        TxtLatihTgl.Text = ""
        TxtLatihBiaya.Text = ""
        TxtLatihHasil.Text = ""
    End Sub
    Function InsertDataPelatihan() As String
        InsertDataPelatihan = "INSERT INTO DATA_STAFFPL(STAFFPL_NIK,STAFFPL_PELATIHAN) VALUES('" & TxtStaffNIK.Text & "','" & TxtLatihPelatih.Text & "')"
    End Function
    Function EditDataPelatihan() As String
        EditDataPelatihan = "UPDATE DATA_STAFFPL SET " & _
                                    "STAFFPL_JENIS='" & TxtLatihJenis.Text & "'," & _
                                    "STAFFPL_NAMA='" & TxtLatihNama.Text & "'," & _
                                    "STAFFPL_TGL='" & TxtLatihTgl.Text & "'," & _
                                    "STAFFPL_BIAYA='" & nLg(TxtLatihBiaya.Text) & "'," & _
                                    "STAFFPL_HASIL='" & TxtLatihHasil.Text & "' " & _
                                    "WHERE STAFFPL_NIK='" & TxtStaffNIK.Text & "' AND STAFFPL_PELATIHAN='" & TxtLatihPelatih.Text & "'"
    End Function

    Protected Sub LVPelatihan_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVPelatihan.SelectedIndexChanged
        TxtLatihPelatih.Text = (LVPelatihan.DataKeys(LVPelatihan.SelectedIndex).Value.ToString)
        Call GetData_PELATIHAN("SELECT * FROM DATA_STAFFPL WHERE STAFFPL_NIK='" & TxtStaffNIK.Text & "' AND STAFFPL_PELATIHAN='" & TxtLatihPelatih.Text & "'")
        MultiViewPelatihanEntry.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnA13Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA13Save.Click
        If GetFindRecord_Server("SELECT * FROM DATA_STAFFPL WHERE STAFFPL_NIK='" & TxtStaffNIK.Text & "' AND STAFFPL_NAMA='" & TxtLatihPelatih.Text & "'") <> 1 Then
            If UpdateData_Server(InsertDataPelatihan, "A13") = 1 Then
                lblStaffNIK.Text = TxtStaffNIK.Text
            End If
        End If
        If lblStaffNIK.Text = TxtStaffNIK.Text Then
            Call UpdateData_Server(EditDataPelatihan, "A13")
        End If

        MultiViewPelatihanEntry.ActiveViewIndex = -1
        LVPelatihan.DataBind()
    End Sub
    Protected Sub BtnA13Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA13Del.Click
        Dim mSqlCommand As String = "DELETE FROM DATA_STAFFKR WHERE STAFFKR_NIK='" & TxtStaffNIK.Text & "' AND STAFFKR_NAMA='" & TxtCompanyNama.Text & "'"
        Call UpdateData_Server(mSqlCommand, "A13")
        MultiViewPelatihanEntry.ActiveViewIndex = -1
        LVPelatihan.DataBind()
    End Sub
    '============End Hal 3

    '============Start Hal 4
    '40

    Protected Sub BtnStandardTabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardTabel.Click
        If MultiViewNilaiStandard.ActiveViewIndex = 0 Then
            BtnStandardTabel.Text = "Buka Tabel Nilai Standard"
            MultiViewNilaiStandard.ActiveViewIndex = -1
        Else
            BtnStandardTabel.Text = "Tutup Tabel Nilai Standard"
            MultiViewNilaiStandard.ActiveViewIndex = 0
            LVNilaiStandard.DataBind()
        End If
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
                                  "KPIN_NILAI='" & TxtStandardNilai.Text & "'," & _
                                  "KPIN_GROUP='" & TxtStandardGroup.Text & "' " & _
                                  "WHERE KPIN_TIPE='" & TxtStandardKode.Text & "'"
    End Function

    Sub clearTxtStandardJudul()
        TxtStandardKode.Text = ""
        TxtStandardJudul.Text = ""
        TxtStandardKet.Text = ""
        TxtStandardNilai.Text = ""
        TxtStandardGroup.Text = ""
    End Sub

    Protected Sub LVNilaiStandard_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVNilaiStandard.SelectedIndexChanged
        TxtStandardKode.Text = (LVNilaiStandard.DataKeys(LVNilaiStandard.SelectedIndex).Value.ToString)
        Call GetData_MASTERSTANDARD("SELECT * FROM DATA_KPIN  WHERE  KPIN_TIPE='" & TxtStandardKode.Text & "'")
        MultiViewNilaiStandardEntry.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnStandardSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardSave.Click
        If GetFindRecord_Server("SELECT * FROM DATA_KPIN  WHERE  KPIN_TIPE='" & TxtStandardKode.Text & "' AND KPIN_JUDUL='" & TxtPetik(TxtStandardJudul.Text) & "'") <> 1 Then
            If UpdateData_Server(InsertDataNilaiSTANDARD, "Std") = 1 Then

            End If
        End If
        Call UpdateData_Server(EditDataNilaiSTANDARD, "Std")
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1 : LVNilaiStandard.DataBind()
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
        Call GetData_MASTER("SELECT * FROM TRXN_KPIH WHERE KPIH_TAHUN='" & TxtKpiSummaryTahun.Text & "'")
        MultiViewKpiMasterEntry.ActiveViewIndex = 0
        MultiViewKPIMasterDetail.ActiveViewIndex = 0
        Call ClikDetail_MultiViewKpiMaster()

        Call clearnilaiOthers()
    End Sub
    Sub ClearTabelKPIMaster()
        TxtKpiSummaryTahun.Text = "" : lblKpiSummaryTahun.Text = ""
        TxtKpiSummaryPosA.Text = "" : lblKpiSummaryPosA.Text = ""
        TxtKpiSummaryPosB.Text = "" : lblKpiSummaryPosB.Text = ""
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
                      "KPIH_TIPEA='" & TxtKpiSummaryPosA.Text & "',KPIH_TIPEB='" & TxtKpiSummaryPosB.Text & "'," & _
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

        If TxtKpiSummaryPosB.Text = "B" Then
            mSqlCommand = "INSERT INTO TRXN_KPIDD " & _
                          "SELECT " & TxtStaffNIK.Text & ",0,0,0,0,'C','" & mTahun & "',KPIN_TIPE " & _
                          "FROM DATA_KPIN WHERE KPIN_GROUP='HEAD'"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
        Else
            mSqlCommand = "INSERT INTO TRXN_KPIDD " & _
                          "SELECT " & TxtStaffNIK.Text & ",0,0,0,0,'C','" & mTahun & "',KPIN_TIPE " & _
                          "FROM DATA_KPIN WHERE KPIN_GROUP='ABSEN'"
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

    Protected Sub BtnKpi40CopyBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40MasterBack.Click
        MultiViewKpiMasterEntry.ActiveViewIndex = -1
        Call DeaktifTabel1()
    End Sub







    '==Detail Kpi Berdasarkan Tahun==================================
    Protected Sub BtnKpi40_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40.Click
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = 0
        Call ClearTabelKPIDetail()
    End Sub
    Sub ClearTabelKPIDetail()
        TxtMasterKpiItem.Text = ""
        TxtMasterKpiTarget.Text = ""
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
        InsertDataNilaiKPI_Master = "INSERT INTO TRXN_KPID (KPID_NIK,KPID_TAHUN,KPID_ITEM,KPID_TYPEA) VALUES ('" & TxtStaffNIK.Text & "','" & lblKpiSummaryTahun.Text & "','" & TxtPetik(TxtMasterKpiItem.Text) & "','" & TxtPetik(lblKpiSummaryPosA.Text) & "')"
    End Function
    Function EditDataNilaiKPI_Master() As String
        'KPID_TYPEA=A Percobaan B Karyawan
        EditDataNilaiKPI_Master = "UPDATE TRXN_KPID SET " & _
                                  "KPID_TARGET=" & nLg(TxtMasterKpiTarget.Text) & "," & _
                                  "KPID_PRESTASI=" & nLg(TxtMasterKpiPrestasi.Text) & "," & _
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
                                  "WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & lblKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(TxtMasterKpiItem.Text) & "'"
    End Function
    Function EditDataNilaiKPI_Item(ByVal mItem As String, ByVal mNilaiStaff As Double, ByVal mNilaiHead As Double, ByVal mNilaiAkhir As Double) As String
        'KPID_TYPEA=A Percobaan B Karyawan
        EditDataNilaiKPI_Item = "UPDATE TRXN_KPID SET " & _
                                  "KPID_NILAISTAFF=" & nLg(mNilaiStaff) & "," & _
                                  "KPID_NILAIATASAN=" & nLg(mNilaiHead) & "," & _
                                  "KPID_NILAIAKHIR='" & mNilaiAkhir & "' " & _
                                  "WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & lblKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(mItem) & "'"
    End Function



    Protected Sub LVKPIMAster_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvKPIMasterDetail.SelectedIndexChanged
        TxtMasterKpiItem.Text = (LvKPIMasterDetail.DataKeys(LvKPIMasterDetail.SelectedIndex).Value.ToString)
        Call GetData_MASTERKPI("SELECT * FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & lblKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(TxtMasterKpiItem.Text) & "'")
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = 0
    End Sub

    Protected Sub BtnKpi40Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40Save.Click
        If GetFindRecord_Server("SELECT * FROM TRXN_KPIH WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPIH_TAHUN='" & lblKpiSummaryTahun.Text & "'") <> 1 Then
            Dim mSqlCommand As String = ""
            mSqlCommand = "INSERT INTO TRXN_KPIH " & _
                          "(KPIH_NIK,KPIH_TAHUN,KPIH_TIPEA,KPIH_TIPEB,KPIH_APPVUSER,KPIH_APPVUSERTGL,KPIH_APPVHEAD,KPIH_APPVHEADTGL,KPIH_APPVHRD,KPIH_APPVHRDTGL,KPIH_NILAI,KPIH_ABJAD,KPIH_NILAI1,KPIH_NILAI2,KPIH_NILAI3,KPIH_SP,KPIH_NILAISP,KPIH_NILAIPRC1,KPIH_NILAIPRC2,KPIH_NILAIPRC3) " & _
                          "VALUES ('" & TxtStaffNIK.Text & "','" & TxtKpiSummaryTahun.Text & "','" & TxtKpiSummaryPosA.Text & "','" & TxtKpiSummaryPosB.Text & "','',NULL,'',NULL,'',NULL,0,'',0,0,0,'',0,0,0,0)"
            Call UpdateData_Server(mSqlCommand, "Kpi40")
            Call nilailanjutan(TxtKpiSummaryTahun.Text)
        End If


        If GetFindRecord_Server("SELECT * FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & lblKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(TxtMasterKpiItem.Text) & "'") <> 1 Then
            If UpdateData_Server(InsertDataNilaiKPI_Master, "Kpi40") = 1 Then
            End If
        End If
        Call UpdateData_Server(EditDataNilaiKPI_Master, "Kpi40")

        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1 : LvKPIMasterDetail.DataBind()
    End Sub
    Protected Sub BtnKpi40Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40Del.Click
        Dim mSqlCommand As String = "DELETE FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & lblKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(TxtMasterKpiItem.Text) & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi40")
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1 : LvKPIMasterDetail.DataBind()
    End Sub

    '============================================================

    Function InsertDataNilaiKPI(ByVal mStatus As String, ByVal mItem As String, ByVal mGol As String) As String
        InsertDataNilaiKPI = "INSERT INTO TRXN_KPID (KPI_NIK,KPI_TAHUN,KPI_ITEM,KPI_TIPEA,KPI_TIPEB) VALUES ('" & TxtStaffNIK.Text & "','" & lblKpiSummaryTahun.Text & "','" & TxtPetik(mItem) & "','" & mStatus & "','" & mGol & "')"

    End Function

    Function EditDataNilaiKPI(ByVal mStatus As String, ByVal mItem As String, ByVal mTarget As String, ByVal mNilaiStaff As String, _
                                     ByVal mNilaiHead As String, ByVal mNilaiAkhir As String) As String
        'KPID_TYPEA=1 Percobaan ( 2 Karyawan
        'KPID_TYPEB=A Skill B Kerjaan C Disiplin D Nilai E Nilai
        EditDataNilaiKPI = "UPDATE TRXN_KPID SET " & _
                                  "KPI_TARGET=" & mTarget & "," & _
                                  "KPI_STAFF=" & mNilaiStaff & "," & _
                                  "KPI_ATASAN=" & mNilaiHead & "," & _
                                  "KPI_AKHIR=" & mNilaiAkhir & "," & _
                                  "KPI_TYPEA='' " & _
                                  "WHERE KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & lblKpiSummaryTahun.Text & "' AND KPI_KODEITEM ='" & TxtPetik(mItem) & "'"
    End Function



    '41A
    Protected Sub BtnKpi41A_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi41A.Click
        MultiKPISkillAEntry.ActiveViewIndex = 0
    End Sub
    Sub ClearTabelKPISkillA()
        LblSkillAItem.Text = ""
        lblSkillATarget.Text = ""
        TxtSkillASTaff.Text = ""
        TxtSkillAAtasan.Text = ""
        TxtSkillAkhir.Text = ""
    End Sub
    Protected Sub LVSkillA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvSkillA.SelectedIndexChanged
        LblSkillAItem.Text = (LvSkillA.DataKeys(LvSkillA.SelectedIndex).Value.ToString)
        Call GetData_MASTERKPISkillA("SELECT * FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & lblKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(LblSkillAItem.Text) & "'")
        MultiKPISkillAEntry.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnKpi41ASave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi41ASave.Click
        Call UpdateData_Server(EditDataNilaiKPI_Item(TxtPetik(LblSkillAItem.Text), nLg(TxtSkillASTaff.Text), nLg(TxtSkillAAtasan.Text), nLg(TxtSkillAkhir.Text)), "Kpi41A")
        MultiKPISkillAEntry.ActiveViewIndex = -1 : LvSkillA.DataBind()
    End Sub
    Protected Sub BtnKpi41ABack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi41ABack.Click
        MultiKPISkillAEntry.ActiveViewIndex = -1
    End Sub

    '41B
    Protected Sub BtnKpi41B_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi41B.Click
        MultiKpiSkillBENtry.ActiveViewIndex = 0
    End Sub
    Sub ClearTabelKPISkillB()
        LblSkilBItem.Text = ""
        TxtSkilBBobot.Text = ""
        TxtSkilBPrestasi.Text = ""
        TxtSkilBNilai.Text = ""
    End Sub
    Protected Sub LVSkillB_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvSkillB.SelectedIndexChanged
        LblSkilBItem.Text = (LvSkillB.DataKeys(LvSkillB.SelectedIndex).Value.ToString)
        Call GetData_MASTERKPISkillB("SELECT * FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & lblKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(LblSkilBItem.Text) & "'")
        MultiKpiSkillBENtry.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnKpi41BSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi41BSave.Click
        Call UpdateData_Server(EditDataNilaiKPI_Item(TxtPetik(LblSkilBItem.Text), nLg(TxtSkilBBobot.Text), nLg(TxtSkilBPrestasi.Text), nLg(TxtSkilBNilai.Text)), "Kpi41B")
        MultiKpiSkillBENtry.ActiveViewIndex = -1 : LvSkillB.DataBind()
    End Sub

    Protected Sub BtnKpi41BBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi41BBack.Click
        MultiKpiSkillBENtry.ActiveViewIndex = -1
    End Sub


    '42A:Proses
    Protected Sub BtnKpi42A_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi41A.Click
        MultiViewProsesEntry.ActiveViewIndex = 0
    End Sub
    Sub ClearTabelKPIKerjaA()
        LblProsesJudulJudul.Text = ""
        LblProsesKodeItem.Text = ""
        TxtProsesStaff.Text = ""
        TxtProsesHead.Text = ""
        TxtProsesAkhir.Text = ""
    End Sub

    Protected Sub LBKerjaA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVProses.SelectedIndexChanged
        LblProsesKodeItem.Text = (LVProses.DataKeys(LVProses.SelectedIndex).Value.ToString)
        Call GetData_MASTERKPIProses("SELECT * FROM TRXN_KPIDD,DATA_KPIN WHERE KPI_KODEITEM=KPIN_TIPE AND KPI_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & lblKpiSummaryTahun.Text & "' AND KPI_ITEM ='" & TxtPetik(LblProsesKodeItem.Text) & "'")
        MultiViewProsesEntry.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnKpi42ASave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi42ASave.Click
        Call UpdateData_Server(EditDataNilaiKPI("A", LblProsesKodeItem.Text, "", TxtProsesStaff.Text, TxtProsesHead.Text, TxtProsesAkhir.Text), "Kpi42A")
        MultiViewProsesEntry.ActiveViewIndex = -1
    End Sub
    Protected Sub BtnKpi42ABack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi42ABack.Click
        MultiViewProsesEntry.ActiveViewIndex = -1
    End Sub




    '42B
    Protected Sub BtnKpi42B_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi41B.Click
        MultiViewPeopleEntry.ActiveViewIndex = 0
    End Sub
    Sub ClearTabelKPIKerjaB()
        LblPeopleJudul.Text = ""
        LblPeopleKode.Text = ""
        TxtPeopleStaff.Text = ""
        TxtPeopleAtasan.Text = ""
        TxtPeopleAKhir.Text = ""
    End Sub
    Protected Sub LBKerjaB_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVPeople.SelectedIndexChanged
        LblPeopleKode.Text = (LVPeople.DataKeys(LVPeople.SelectedIndex).Value.ToString)
        Call GetData_MASTERKPIPeople("SELECT * FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & lblKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(LblPeopleKode.Text) & "'")
        MultiViewPeopleEntry.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnKpi42BSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi42BSave.Click
        Call UpdateData_Server(EditDataNilaiKPI("B", LblPeopleKode.Text, "", TxtPeopleStaff.Text, TxtPeopleAtasan.Text, TxtPeopleAKhir.Text), "Kpi42A")
        MultiViewPeopleEntry.ActiveViewIndex = -1
    End Sub
    Protected Sub BtnKpi42BDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi42BBack.Click
        MultiViewPeopleEntry.ActiveViewIndex = -1
    End Sub






    '43
    Protected Sub BtnKpi43_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi43.Click
        MultiViewDisplinEntry.ActiveViewIndex = 0
    End Sub
    Sub ClearTabelDisiplin()
        lblDisiplinKode.Text = ""
        lblDisiplinJudul.Text = ""
        TxtDisiplinNilai.Text = ""
    End Sub
    Protected Sub LvDisiplin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDisiplin.SelectedIndexChanged
        lblDisiplinKode.Text = (LvDisiplin.DataKeys(LvDisiplin.SelectedIndex).Value.ToString)
        Call GetData_MASTERKPIDisiplin("SELECT * FROM TRXN_KPID WHERE KPID_NIK='" & TxtStaffNIK.Text & "' AND KPID_TAHUN='" & lblKpiSummaryTahun.Text & "' AND KPID_ITEM ='" & TxtPetik(lblDisiplinKode.Text) & "'")
        MultiViewDisplinEntry.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnKpi43Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi43Save.Click
        Call UpdateData_Server(EditDataNilaiKPI("C", LblPeopleKode.Text, "", TxtPeopleStaff.Text, TxtPeopleAtasan.Text, TxtPeopleAKhir.Text), "Kpi42A")
        MultiViewDisplinEntry.ActiveViewIndex = -1
    End Sub
    Protected Sub BtnKpi43Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi43Back.Click
        MultiViewDisplinEntry.ActiveViewIndex = -1
    End Sub





    Sub clearnilaiOthers()
        TxtKpiPercenNilai1.Text = "0" : TxtKpiTotalNilai1.Text = "0"
        TxtKpiPercenNilai2.Text = "0" : TxtKpiTotalNilai2.Text = "0"
        TxtKpiPercenNilai3.Text = "0" : TxtKpiTotalNilai3.Text = "0"
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
                                    "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & lblKpiSummaryTahun.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi44")
    End Sub
    Protected Sub BtnKpi44Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi44Setuju2.Click
        Dim mSqlCommand As String = "UPDATE TRXN_KPIH SET " & _
                                    "" & _
                                    "WHERE KPIH_NIK='" & TxtStaffNIK.Text & "' AND KPI_TAHUN='" & lblKpiSummaryTahun.Text & "'"
        Call UpdateData_Server(mSqlCommand, "Kpi44")
    End Sub




    '============End Hal 4


    Function GetData_UserSecurity(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_UserSecurity = 0

        cnn = New OleDbConnection(strconn)
        'TxtCariSPV.Text = ""
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_UserSecurity = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                LblUserId.Text = nSr(MyRecReadA("USER_ID"))


                lblAkses.Text = nSr(MyRecReadA("AKSES_DATA"))
                lblArea1.Text = nSr(MyRecReadA("AKSES_AREA"))
                lblArea2.Text = lblArea1.Text
                If Len(lblArea1.Text) > 3 Then
                    lblArea1.Text = Mid(nSr(MyRecReadA("AKSES_AREA")), 1, 3)
                    lblArea2.Text = Mid(nSr(MyRecReadA("AKSES_AREA")), 4, 3)
                End If
                If lblAkses.Text <> "" Then
                    lblAkses.Visible = False
                    If Mid(lblAkses.Text, 2, 1) = "1" Then
                    ElseIf Mid(lblAkses.Text, 3, 1) = "1" Then
                    ElseIf Mid(lblAkses.Text, 4, 1) = "1" Then
                    ElseIf Mid(lblAkses.Text, 5, 1) = "1" Then
                    End If
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
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
                lblStaffNIK.Text = nSr(MyRecReadA("STAFF_NIK"))
                TxtStaffNIK.Enabled = False
                TxtStaffNama.Text = nSr(MyRecReadA("STAFF_NAMA"))
                TxtStaffLahirTmp.Text = nSr(MyRecReadA("STAFF_LAHIRTMP"))
                TxtStaffLahirTgl.Text = nSr(MyRecReadA("STAFF_LAHIRTGL"))
                DropDownList1.Text = nSr(MyRecReadA("STAFF_STATUS"))
                TxtStaffJalan.Text = nSr(MyRecReadA("STAFF_ALAMATJLN"))
                TxtStaffRT.Text = nSr(MyRecReadA("STAFF_ALAMATRT"))
                TxtStaffRW.Text = nSr(MyRecReadA("STAFF_ALAMATRW"))
                TxtStaffKodePos.Text = nSr(MyRecReadA("STAFF_ALAMATPOS"))
                TxtStaffEmail.Text = nSr(MyRecReadA("STAFF_EMAIL"))
                TxtStaffNoKtp.Text = nSr(MyRecReadA("STAFF_NOKTP"))
                TxtStaffSIMType.Text = nSr(MyRecReadA("STAFF_SIMTYPE"))
                TxtStaffSIMNomor.Text = nSr(MyRecReadA("STAFF_SIMNO"))
                TxtStaffBPJSKerja.Text = nSr(MyRecReadA("STAFF_NOBPJSKERJA"))
                TxtStaffBPJSSehat.Text = nSr(MyRecReadA("STAFF_NOBPJSSEHAT"))
                TxtStaffNPWP.Text = nSr(MyRecReadA("STAFF_NPWP"))
                TxtStaffBCA.Text = nSr(MyRecReadA("STAFF_REKBCA"))
                TxtStaffNoHP.Text = nSr(MyRecReadA("STAFF_HP"))
                TxtStaffNoTelepon.Text = nSr(MyRecReadA("STAFF_PHONE"))
                TxtStaffNoContact.Text = nSr(MyRecReadA("STAFF_CONTACT"))
                TxtStaffKel.Text = nSr(MyRecReadA("STAFF_ALAMATKEL"))
                TxtStaffKota.Text = nSr(MyRecReadA("STAFF_ALAMATKAB"))

                TxtStatusKerjaMasuk.Text = nSr(MyRecReadA("STAFF_STATUSKERJAMASUKK"))
                TxtStatusKerjaJabatan.Text = nSr(MyRecReadA("STAFF_STATUSKERJAJABATAN"))
                TxtStatusKerjaDept.Text = nSr(MyRecReadA("STAFF_STATUSKERJADEPT"))
                TxtStatusKerjaDivis.Text = nSr(MyRecReadA("STAFF_STATUSKERJADIVISI"))
                TxtStatusKerjaTempat.Text = nSr(MyRecReadA("STAFF_STATUSKERJALOKASI"))

                DropDownList2.Text = nSr(MyRecReadA("STAFF_STATUSKERJAMG"))
                TxtStatusKerjaMagangTglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAMGTGL"))

                DropDownList3.Text = nSr(MyRecReadA("STAFF_STATUSKERJAPC"))
                TxtStatusKerjaCobaTglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAPCTGL"))

                DropDownList4.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKT1"))
                TxtStatusKerjaKontrak1TglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKT1TGL"))

                DropDownList5.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKT2"))
                TxtStatusKerjaKontrak2TglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKT2TGL"))

                DropDownList6.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKTG"))
                TxtStatusKerjaAgenTglAkhir.Text = nSr(MyRecReadA("STAFF_STATUSKERJAKTGTGL"))

                TxtStatusKerjaTetap.Text = nSr(MyRecReadA("STAFF_STATUSKERJATGLANGKAT"))
                TxtStatusKerjaKeluar.Text = nSr(MyRecReadA("STAFF_STATUSKERJATGLKELUAR"))
                TxtStatusKerjaAlasan.Text = nSr(MyRecReadA("STAFF_STATUSKERJAALSKELUAR"))
                If (MyRecReadA("STAFF_FOTO") Is DBNull.Value) Then
                    Image1.Attributes("src") = "WEBDOWNLOAD\FOTOKARYAWAN\Icon.png"
                ElseIf (MyRecReadA("STAFF_FOTO") IsNot DBNull.Value) Then
                    Image1.Attributes("src") = "WEBDOWNLOAD\FOTOKARYAWAN\" & nSr(MyRecReadA("STAFF_FOTO"))
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function

    Function GetData_FORMAL(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_FORMAL = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()

                TxtPendidikanTingkat.Text = nSr(MyRecReadA("STAFFFO_TINGKAT"))
                TxtPendidikanNama.Text = nSr(MyRecReadA("STAFFFO_NAMA"))
                TxtPendidikanJurusan.Text = nSr(MyRecReadA("STAFFFO_JURUSAN"))
                TxtPendidikanTahun.Text = nSr(MyRecReadA("STAFFFO_TAHUN"))
                TxtPendidikanKet.Text = nSr(MyRecReadA("STAFFFO_KET"))
                TxtPendidikanIjazah.Text = nSr(MyRecReadA("STAFFFO_IJAZAH"))

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function
    Function GetData_NONFORMAL(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_NONFORMAL = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtDidikNonFormalTingkat.Text = nSr(MyRecReadA("STAFFFO_TINGKAT"))
                TxtDidikNonFormalNama.Text = nSr(MyRecReadA("STAFFFO_NAMA"))
                TxtDidikNonFormalJudul.Text = nSr(MyRecReadA("STAFFFO_JURUSAN"))
                TxtDidikNonFormalTahun.Text = nSr(MyRecReadA("STAFFFO_TAHUN"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function
    Function GetData_FORMALLanjutan(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_FORMALLanjutan = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()

                TxtPendidikanLanjutYN.Text = "Y"
                TxtPendidikanLanjutNama.Text = nSr(MyRecReadA("STAFFFO_NAMA"))
                TxtPendidikanLanjutJurusan.Text = nSr(MyRecReadA("STAFFFO_JURUSAN"))
                TxtPendidikanLanjutSMS.Text = nSr(MyRecReadA("STAFFFO_TINGKAT"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_KERJA(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_KERJA = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()

                TxtCompanyNama.Text = nSr(MyRecReadA("STAFFKR_NAMA"))
                TxtCompanyAlamat.Text = nSr(MyRecReadA("STAFFKR_ALAMAT"))
                TxtCompanyJabatan.Text = nSr(MyRecReadA("STAFFKR_JABATAN"))
                TxtCompanyMasuk.Text = nSr(MyRecReadA("STAFFKR_MASUK"))
                TxtCompanyKeluar.Text = nSr(MyRecReadA("STAFFKR_KELUAR"))

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_PELATIHAN(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_PELATIHAN = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtLatihPelatih.Text = nSr(MyRecReadA("STAFFPL_PELATIHAN"))
                TxtLatihJenis.Text = nSr(MyRecReadA("STAFFPL_JENIS"))
                TxtLatihNama.Text = nSr(MyRecReadA("STAFFPL_NAMA"))
                TxtLatihTgl.Text = nSr(MyRecReadA("STAFFPL_TGL"))
                TxtLatihBiaya.Text = nSr(MyRecReadA("STAFFPL_BIAYA"))
                TxtLatihHasil.Text = nSr(MyRecReadA("STAFFPL_HASIL"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

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
                TxtKpiSummaryPosB.Text = nSr(MyRecReadA("KPIH_TIPEB"))
                lblKpiSummaryPosB.Text = TxtKpiSummaryPosB.Text

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



    Function GetData_MASTERKPISkillA(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MASTERKPISkillA = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                LblSkillAItem.Text = nSr(MyRecReadA("KPID_ITEM"))
                lblSkillATarget.Text = nSr(MyRecReadA("KPID_TARGET"))
                TxtSkillASTaff.Text = nSr(MyRecReadA("KPID_NILAISTAFF"))
                TxtSkillAAtasan.Text = nSr(MyRecReadA("KPID_NILAIATASAN"))
                TxtSkillAkhir.Text = nSr(MyRecReadA("KPID_NILAIAKHIR"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_MASTERKPISkillB(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MASTERKPISkillB = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()

                LblSkilBItem.Text = nSr(MyRecReadA("KPID_ITEM"))
                TxtSkilBBobot.Text = nSr(MyRecReadA("KPID_NILAISTAFF"))
                TxtSkilBPrestasi.Text = nSr(MyRecReadA("KPID_NILAIATASAN"))
                TxtSkilBNilai.Text = nSr(MyRecReadA("KPID_NILAIAKHIR"))
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
                TxtProsesAkhir.Text = nSr(MyRecReadA("KPI_AKHIR"))

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
                TxtPeopleAKhir.Text = nSr(MyRecReadA("KPI_AKHIR"))
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
                TxtStandardNilai.Text = nSr(MyRecReadA("KPIN_NILAI"))

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

    Function UpdateData_Server(ByVal mSqlCommadstring As String, ByVal mPos As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        LblErrorSaveA1.Text = ""
        LblErrorSaveA111.Text = ""
        LblErrorSaveA112.Text = ""
        LblErrorSaveA113.Text = ""
        LblErrorSaveA12.Text = ""
        LblErrorSaveA13.Text = ""
        LblErrorSaveKpi40.Text = ""
        LblErrorSaveKpi41A.Text = ""
        LblErrorSaveKpi41B.Text = ""
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
        If Kode = "A1" Then
            LblErrorSaveA1.Text = Errormsg
        ElseIf Kode = "A111" Then
            LblErrorSaveA111.Text = Errormsg
        ElseIf Kode = "A112" Then
            LblErrorSaveA112.Text = Errormsg
        ElseIf Kode = "A113" Then
            LblErrorSaveA113.Text = Errormsg
        ElseIf Kode = "A12" Then
            LblErrorSaveA12.Text = Errormsg
        ElseIf Kode = "A13" Then
            LblErrorSaveA13.Text = Errormsg
        ElseIf Kode = "Kpi40" Then
            LblErrorSaveKpi40.Text = Errormsg
        ElseIf Kode = "Kpi41A" Then
            LblErrorSaveKpi41A.Text = Errormsg
        ElseIf Kode = "Kpi41B" Then
            LblErrorSaveKpi41B.Text = Errormsg
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


    Protected Sub ButtonA1Upload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonA1Upload.Click
        If Page.IsValid Then
            'If the Default.aspx validation is true (for example if the uploaded file is of correct file type, then process the rest of the script.
            Dim filereceived As String = FileUpload1.PostedFile.FileName
            Dim filename As String = Path.GetFileName(filereceived)
            Dim EditDataStafffoto As String
            EditDataStafffoto = "UPDATE DATA_STAFF SET STAFF_FOTO='" & filename & "' WHERE  STAFF_NIK='" & TxtStaffNIK.Text & "'"
            Call UpdateData_Server(EditDataStafffoto, "A1")
            Dim fileuploadpath As String = "C:\inetpub\wwwroot\MugenASPHRISO\WEBDOWNLOAD\FOTOKARYAWAN\"
            FileUpload1.PostedFile.SaveAs(Path.Combine(fileuploadpath, filename))
        End If
    End Sub


    Protected Sub BtnMasterTabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMasterTabel.Click
        LvDetailStaff.DataBind()
    End Sub

    '==============================================================================









    Protected Sub BtnA111Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA111Back.Click
        MultiView10201DidikFormalENtry.ActiveViewIndex = -1
        LVPendidikanFormal.DataBind()
    End Sub

    Protected Sub BtnA113Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA113Back.Click
        MultiView10202DidikNonFormalEntry.ActiveViewIndex = -1
        LVPendidikanNonFormal.DataBind()
    End Sub

    Protected Sub BtnA12Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA12Back.Click
        MultiViewKerjaEntry.ActiveViewIndex = -1
        LVProses.DataBind()
    End Sub

    Protected Sub BtnA13Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA13Back.Click
        MultiViewPelatihanEntry.ActiveViewIndex = -1
        LVPelatihan.DataBind()
    End Sub

    Protected Sub BtnStandardBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardBack.Click
        MultiViewNilaiStandardEntry.ActiveViewIndex = -1
        LVNilaiStandard.DataBind()
    End Sub

    Protected Sub BtnKpi40Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKpi40Back.Click
        MultiViewKPIMasterDetailENtry.ActiveViewIndex = -1
        LvKPIMasterDetail.DataBind()
    End Sub






End Class
