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


Partial Class HRDFORMKARYAWAN
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
            Dim no As String = Request.QueryString("no")
            If no <> "" Then
                MultiViewAkses.ActiveViewIndex = 0
                Call GetData_STAFF("SELECT * FROM DATA_STAFF WHERE STAFF_NIK='" & no & "'")
                Call GetData_AKUN("SELECT * FROM TB_USER WHERE KDKARYAWAN='" & no & "'")
                Call GetData_FORMALLanjutan("SELECT * FROM DATA_STAFFFO WHERE STAFFFO_TIPE='L' AND STAFFFO_NIK LIKE '" & TxtStaffNIK.Text & "'")
                Call AktifUtammaKlikDetailKaryawan()
            Else
                Call GetData_STAFF2("SELECT * FROM TB_USER WHERE username='" & LblUserName.Text & "'")
                Call GetData_STAFF("SELECT * FROM DATA_STAFF WHERE STAFF_NIK='" & lblArea2.Text & "'")
                Call GetData_AKUN("SELECT * FROM TB_USER WHERE KDKARYAWAN='" & lblArea2.Text & "'")
                Call GetData_FORMALLanjutan("SELECT * FROM DATA_STAFFFO WHERE STAFFFO_TIPE='L' AND STAFFFO_NIK LIKE '" & TxtStaffNIK.Text & "'")
                Call AktifUtammaKlikDetailKaryawan()
            End If
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'DATABASE KARYAWAN -- VIEW DATA'") = 1 Then
                data_kerja.Visible = True
                data_akun.Visible = True
				ButtonA1Save.Visible = True
				ButtonKaryawan.Visible = False
            End If
        End If
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

        If GetFindRecord_Server2("SELECT * FROM tb_user WHERE kdkaryawan='" & TxtStaffNIK.Text & "'") <> 1 Then
            If UpdateData_Server2(InsertDataAkun, "A1") = 1 Then
                lblStaffNIK.Text = TxtStaffNIK.Text
            End If
        End If

        If GetFindRecord_Server("SELECT * FROM DATA_STAFFFO WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TIPE='L'") <> 1 Then
            If UpdateData_Server(InsertDataPendidikanLanjutan("L"), "A1") = 1 Then
                lblStaffNIK.Text = TxtStaffNIK.Text
            End If
            'Call UpdateData_Server(InsertDataPendidikanLanjutan("L"), "A112")
        End If

        Call UpdateData_Server(EditDataStaff, "A1")
        Call UpdateData_Server(EditDataPendidikanLanjutan("L"), "A112")
        Response.Write("<script>alert('Data Karyawan Berhasil Diperbarui!')</script>")
        Response.Write("<script>window.location.href='HRDFORMKARYAWAN.aspx?no=" + TxtStaffNIK.Text + "';</script>")
    End Sub
	
	Protected Sub ButtonKaryawan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonKaryawan.Click
        If Not IsDate(TxtStaffLahirTgl) Then
            LblErrorSaveA1.Text = ""
        End If

        Call UpdateData_Server(EditDataStaff2, "A1")
        Call UpdateData_Server(EditDataPendidikanLanjutan("L"), "A112")

        Response.Write("<script>alert('Data Karyawan Berhasil Diperbarui!')</script>")
        Response.Write("<script>window.location.href='HRDFORMKARYAWAN.aspx?no=" + TxtStaffNIK.Text + "';</script>")
    End Sub
	
	
    'Protected Sub ButtonA1Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonA1Del.Click
    'Dim mSqlCommand As String = "DELETE FROM DATA_STAFF WHERE STAFF_NIK='" & TxtStaffNIK.Text & "'"
    'Call UpdateData_Server(mSqlCommand, "A1")
    'End Sub

    Function InsertDataStaff() As String
        InsertDataStaff = "INSERT INTO DATA_STAFF (STAFF_NIK) VALUES ('" & TxtStaffNIK.Text & "')"
    End Function
    Function EditDataStaff() As String
        EditDataStaff = "UPDATE DATA_STAFF SET " & _
               "STAFF_NAMA='" & TxtPetik(TxtStaffNama.Text) & "',STAFF_LAHIRTMP='" & TxtPetik(TxtStaffLahirTmp.Text) & "',STAFF_LAHIRTGL=" & DtFrSQL(TxtStaffLahirTgl.Text) & ",STAFF_STATUS='" & DropDownList1.Text & "'," & _
               "STAFF_ALAMATJLN='" & TxtPetik(TxtStaffJalan.Text) & "',STAFF_ALAMATRT='" & TxtPetik(TxtStaffRT.Text) & "',STAFF_ALAMATRW='" & TxtPetik(TxtStaffRW.Text) & "'," & _
               "STAFF_ALAMATKEL='" & TxtPetik(TxtStaffKel.Text) & "',STAFF_ALAMATKAB='" & TxtPetik(TxtStaffKota.Text) & "',STAFF_ALAMATPOS='" & TxtStaffKodePos.Text & "'," & _
               "STAFF_EMAIL='" & TxtStaffEmail.Text & "',STAFF_JKEL='" & TxtPetik(TxtJkel.Text) & "',STAFF_DARAH='" & TxtPetik(TxtDarah.Text) & "',STAFF_AGAMA='" & TxtPetik(TxtAgama.Text) & "'," & _
               "STAFF_NOKTP='" & TxtStaffNoKtp.Text & "'," & _
               "STAFF_SIMTYPE='" & TxtStaffSIMType.Text & "',STAFF_SIMNO='" & TxtStaffSIMNomor.Text & "'," & _
               "STAFF_NOBPJSKERJA='" & TxtStaffBPJSKerja.Text & "',STAFF_NOBPJSSEHAT='" & TxtStaffBPJSSehat.Text & "',STAFF_NPWP='" & TxtStaffNPWP.Text & "'," & _
               "STAFF_REKBCA='" & TxtStaffBCA.Text & "',STAFF_HP='" & TxtStaffNoHP.Text & "',STAFF_PHONE='" & TxtStaffNoTelepon.Text & "',STAFF_CONTACT='" & TxtStaffNoContact.Text & "'," & _
               "STAFF_STATUSKERJAMASUKK=" & DtFrSQL(TxtStatusKerjaMasuk.Text) & ", STAFF_STATUSKERJAJABATAN='" & TxtStatusKerjaJabatan.Text & "', " & _
               "STAFF_STATUSKERJADEPT='" & TxtStatusKerjaDept.Text & "'," & _
               "STAFF_SUBJABATAN='" & Left(subJabatan.Text, 1) & "'," & _
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
	
	Function EditDataStaff2() As String
        EditDataStaff2 = "UPDATE DATA_STAFF SET " & _
               "STAFF_NAMA='" & TxtPetik(TxtStaffNama.Text) & "',STAFF_LAHIRTMP='" & TxtPetik(TxtStaffLahirTmp.Text) & "',STAFF_LAHIRTGL=" & DtFrSQL(TxtStaffLahirTgl.Text) & ",STAFF_STATUS='" & DropDownList1.Text & "'," & _
               "STAFF_ALAMATJLN='" & TxtPetik(TxtStaffJalan.Text) & "',STAFF_ALAMATRT='" & TxtPetik(TxtStaffRT.Text) & "',STAFF_ALAMATRW='" & TxtPetik(TxtStaffRW.Text) & "'," & _
               "STAFF_ALAMATKEL='" & TxtPetik(TxtStaffKel.Text) & "',STAFF_ALAMATKAB='" & TxtPetik(TxtStaffKota.Text) & "',STAFF_ALAMATPOS='" & TxtStaffKodePos.Text & "'," & _
               "STAFF_EMAIL='" & TxtStaffEmail.Text & "',STAFF_JKEL='" & TxtPetik(TxtJkel.Text) & "',STAFF_DARAH='" & TxtPetik(TxtDarah.Text) & "',STAFF_AGAMA='" & TxtPetik(TxtAgama.Text) & "'," & _
               "STAFF_NOKTP='" & TxtStaffNoKtp.Text & "'," & _
               "STAFF_SIMTYPE='" & TxtStaffSIMType.Text & "',STAFF_SIMNO='" & TxtStaffSIMNomor.Text & "'," & _
               "STAFF_NOBPJSKERJA='" & TxtStaffBPJSKerja.Text & "',STAFF_NOBPJSSEHAT='" & TxtStaffBPJSSehat.Text & "',STAFF_NPWP='" & TxtStaffNPWP.Text & "'," & _
               "STAFF_REKBCA='" & TxtStaffBCA.Text & "',STAFF_HP='" & TxtStaffNoHP.Text & "',STAFF_PHONE='" & TxtStaffNoTelepon.Text & "',STAFF_CONTACT='" & TxtStaffNoContact.Text & "'" & _
               "WHERE  STAFF_NIK='" & TxtStaffNIK.Text & "'"
        'MsgBox(EditDataStaff)
    End Function

    Sub HakDataKeryawan()

        ButtonA1Upload.Visible = False : ButtonA1Save.Visible = False


        BtnA111Save.Visible = False

        BtnA113Save.Visible = False

        BtnA12Save.Visible = False

        BtnA13Save.Visible = False
        '=================================================


    End Sub

    Sub ClearDetailStaff()
        TxtStaffNIK.Text = "" : lblStaffNIK.Text = ""
        TxtStaffNIK.Enabled = True
        TxtStaffNama.Text = ""
        TxtStaffLahirTmp.Text = "" : TxtStaffLahirTgl.Text = ""
        DropDownList1.SelectedIndex = -1
        TxtAgama.SelectedIndex = -1
        TxtDarah.SelectedIndex = -1
        TxtJkel.SelectedIndex = -1
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
        TxtStatusKerjaJabatan.SelectedIndex = -1
        TxtStatusKerjaDept.SelectedIndex = -1
        TxtStatusKerjaTempat.Text = ""
        subJabatan.Text = ""
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
        MultiViewAkses.ActiveViewIndex = 0
        MultiView102Detail.ActiveViewIndex = -1
    End Sub

    '============end Hal Utama



    '============Start Pilihan Halaman
    Protected Sub Tab01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab01.Click
        MultiView102Detail.ActiveViewIndex = 0
        MultiViewAkses.ActiveViewIndex = -1
        LVPendidikanFormal.DataBind()

        Call GetData_FORMALLanjutan("SELECT * FROM DATA_STAFFFO WHERE STAFFFO_TIPE='L' AND STAFFFO_NIK LIKE '" & TxtStaffNIK.Text & "'")

        LVPendidikanNonFormal.DataBind()

    End Sub
    Protected Sub Tab02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab02.Click
        MultiView102Detail.ActiveViewIndex = 1
        LVPengalamanKerja.DataBind()
        MultiViewAkses.ActiveViewIndex = -1

    End Sub
    Protected Sub Tab04_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab04.Click
        MultiView102Detail.ActiveViewIndex = 2
        LVPelatihan.DataBind()
        MultiViewAkses.ActiveViewIndex = -1

    End Sub
    Protected Sub Tab05_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab05.Click
        MultiViewAkses.ActiveViewIndex = 0
        MultiView102Detail.ActiveViewIndex = -1
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
        TxtPendidikanLanjutNama.Text = ""
        TxtPendidikanLanjutJurusan.Text = ""
        TxtPendidikanLanjutSemester.Text = ""
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

    Function InsertDataPendidikanLanjutan(ByVal mStatus As String) As String
        InsertDataPendidikanLanjutan = "INSERT INTO DATA_STAFFFO (STAFFFO_TIPE, STAFFFO_NIK) VALUES ('" & mStatus & "','" & TxtStaffNIK.Text & "')"
    End Function

    Function InsertDataAkun() As String

        InsertDataAkun = "INSERT INTO tb_user (kdkaryawan, namakaryawan, username, password, kddivisi) VALUES ('" & TxtStaffNIK.Text & "','" & TxtStaffNama.Text & "','" & txtUsername.Text & "','" & txtPassword.Text & "','')"
    End Function

    Function EditDataPendidikanLanjutan(ByVal mStatus As String) As String
        EditDataPendidikanLanjutan = "UPDATE DATA_STAFFFO SET " & _
                                    "STAFFFO_NAMA='" & TxtPendidikanLanjutNama.Text & "'," & _
                                    "STAFFFO_JURUSAN='" & TxtPendidikanLanjutJurusan.Text & "'," & _
                                    "STAFFFO_TAHUN=''," & _
                                    "STAFFFO_KET='" & TxtPendidikanLanjutSemester.Text & "'," & _
                                    "STAFFFO_IJAZAH='N' " & _
                                    "WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TIPE='" & mStatus & "'"
    End Function

    Protected Sub LVPendidikanFormal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVPendidikanFormal.SelectedIndexChanged
        Dim PendidikanTingkat As String = (LVPendidikanFormal.DataKeys(LVPendidikanFormal.SelectedIndex).Value.ToString)
        Dim mSqlCommand As String = "DELETE FROM DATA_STAFFFO WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TINGKAT='" & PendidikanTingkat & "' AND STAFFFO_TIPE='F'"
        Call UpdateData_Server(mSqlCommand, "A111")
        MultiViewAkses.ActiveViewIndex = -1
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
        Call ClearPendidikanStaffFormal()
        LVPendidikanFormal.DataBind()
        MultiViewAkses.ActiveViewIndex = -1
    End Sub


    'Protected Sub BtnA112Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA112Del.Click
    'Dim mSqlCommand As String = "DELETE FROM DATA_STAFFFO WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TIPE='L'"
    'Call UpdateData_Server(mSqlCommand, "A112")
    'End Sub

    Protected Sub LVPendidikanNonFormal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVPendidikanNonFormal.SelectedIndexChanged
        Dim DidikNonFormalTingkat As String = (LVPendidikanNonFormal.DataKeys(LVPendidikanNonFormal.SelectedIndex).Value.ToString)
        Dim mSqlCommand As String = "DELETE FROM DATA_STAFFFO WHERE STAFFFO_NIK='" & TxtStaffNIK.Text & "' AND STAFFFO_TINGKAT='" & DidikNonFormalTingkat & "' AND STAFFFO_TIPE='N'"
        Call UpdateData_Server(mSqlCommand, "A113")
        LVPendidikanNonFormal.DataBind()
        MultiViewAkses.ActiveViewIndex = -1
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
        ClearPendidikanStaffNonFormal()
        LVPendidikanNonFormal.DataBind()
        MultiViewAkses.ActiveViewIndex = -1
    End Sub



    '============End Hal 1

    '============Start Hal 2

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
        Dim CompanyNama As String = (LVPengalamanKerja.DataKeys(LVPengalamanKerja.SelectedIndex).Value.ToString)
        Dim mSqlCommand As String = "DELETE FROM DATA_STAFFKR WHERE STAFFKR_NIK='" & TxtStaffNIK.Text & "' AND STAFFKR_NAMA='" & CompanyNama & "'"
        Call UpdateData_Server(mSqlCommand, "A12")
        LVPengalamanKerja.DataBind()
        MultiViewAkses.ActiveViewIndex = -1
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
        Call ClearPengalamanStaff()
        LVPengalamanKerja.DataBind()
        MultiViewAkses.ActiveViewIndex = -1
    End Sub

    '============End Hal 2

    '============Start Hal 3

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
        Dim LatihPelatih As String = (LVPelatihan.DataKeys(LVPelatihan.SelectedIndex).Value.ToString)
        Dim mSqlCommand As String = "DELETE FROM DATA_STAFFPL WHERE STAFFPL_NIK='" & TxtStaffNIK.Text & "' AND STAFFPL_PELATIHAN='" & LatihPelatih & "'"
        Call UpdateData_Server(mSqlCommand, "A13")
        LVPelatihan.DataBind()
        MultiViewAkses.ActiveViewIndex = -1
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

        ClearLatihanStaff()
        LVPelatihan.DataBind()
        MultiViewAkses.ActiveViewIndex = -1
    End Sub

    '============End Hal 3

    '============Start Hal 4
    '40



    '============================================================






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
                If nLg(MyRecReadA("STAFF_SUBJABATAN")) = 0 Then
                    subJabatan.Text = "0 Operator"
                ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 1 Then
                    subJabatan.Text = "1 Staff"
                ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 2 Then
                    subJabatan.Text = "2 Leader"
                ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 3 Then
                    subJabatan.Text = "3 SPV"
                ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 4 Then
                    subJabatan.Text = "4 Ast. Manager"
                ElseIf nLg(MyRecReadA("STAFF_SUBJABATAN")) = 5 Then
                    subJabatan.Text = "5 Manager"
                End If
                'subJabatan.Text = nLg(MyRecReadA("STAFF_SUBJABATAN"))
                'subJabatan.SelectedIndex = nLg(MyRecReadA("STAFF_SUBJABATAN"))
                'subJabatan.Text = subJabatan.Items(nLg(MyRecReadA("STAFF_SUBJABATAN"))).Text
                TxtJkel.Text = nSr(MyRecReadA("STAFF_JKEL"))
                TxtDarah.Text = nSr(MyRecReadA("STAFF_DARAH"))
                TxtAgama.Text = nSr(MyRecReadA("STAFF_AGAMA"))

                TxtStatusKerjaMasuk.Text = nSr(MyRecReadA("STAFF_STATUSKERJAMASUKK"))
                TxtStatusKerjaJabatan.Text = nSr(MyRecReadA("STAFF_STATUSKERJAJABATAN"))
                TxtStatusKerjaDept.Text = nSr(MyRecReadA("STAFF_STATUSKERJADEPT"))
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

    Function GetData_AKUN(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_AKUN = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                txtUsername.Text = nSr(MyRecReadA("username"))
                txtUsername.ReadOnly = True
                txtPassword.Text = nSr(MyRecReadA("password"))
                txtPassword.ReadOnly = True
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
                TxtPendidikanLanjutNama.Text = nSr(MyRecReadA("STAFFFO_NAMA"))
                TxtPendidikanLanjutJurusan.Text = nSr(MyRecReadA("STAFFFO_JURUSAN"))
                TxtPendidikanLanjutSemester.Text = nSr(MyRecReadA("STAFFFO_KET"))
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
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
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
        LblErrorSaveA113.Text = ""
        LblErrorSaveA12.Text = ""
        LblErrorSaveA13.Text = ""
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

    Function UpdateData_Server2(ByVal mSqlCommadstring As String, ByVal mPos As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        LblErrorSaveA1.Text = ""
        LblErrorSaveA111.Text = ""
        LblErrorSaveA113.Text = ""
        LblErrorSaveA12.Text = ""
        LblErrorSaveA13.Text = ""
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
            Call ErrorIsi(mPos, ex.Message)
        End Try
    End Function

    Sub ErrorIsi(ByVal Kode As String, ByVal Errormsg As String)
        If Kode = "A1" Then
            LblErrorSaveA1.Text = Errormsg
        ElseIf Kode = "A111" Then
            LblErrorSaveA111.Text = Errormsg
        ElseIf Kode = "A113" Then
            LblErrorSaveA113.Text = Errormsg
        ElseIf Kode = "A12" Then
            LblErrorSaveA12.Text = Errormsg
        ElseIf Kode = "A13" Then
            LblErrorSaveA13.Text = Errormsg

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



    '==============================================================================


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
                lblArea2.Text = nSr(MyRecReadA("KDKARYAWAN"))

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function

    Protected Sub BtnUpdateTglKeluar_Click(sender As Object, e As EventArgs) Handles BtnUpdateTglKeluar.Click
        Dim var1 As String = ""
        Dim var2 As String = ""
        Dim query_update_recall As String = " update DATA_STAFF set STAFF_STATUSKERJATGLKELUAR=NULL,STAFF_STATUSKERJAALSKELUAR='" + var2 + "'  where staff_nik = '" & TxtStaffNIK.Text & "'"
        If UpdateData_Server(query_update_recall, "A1") = 1 Then
            Response.Write("<script>alert('Anda Recall Karyawan !')</script>")
            Response.Write("<script>window.location.href='HRDKARYAWAN.aspx';</script>")
        End If
    End Sub
End Class
