Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Imports System.Web.Security

Partial Class Form02Aksesoris
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

            'If GetData_UserSecurity("SELECT * FROM tb_user inner join tb_userutility on tb_user.username collate SQL_Latin1_General_CP1_CI_AS = tb_userutility.username collate SQL_Latin1_General_CP1_CI_AS WHERE tb_user.username = '" & LblUserName.Text & "' And tb_userutility.hakakses = 'FORM PANDUAN MUTU -- VIEW DATA'") = 1 Then
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM ISO -- VIEW DATA'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM ISO -- ADD DATA'") = 1 Then
                    BtnA.Visible = True
                Else
                    BtnA.Visible = False
                End If
            Else
                MultiViewAkses.ActiveViewIndex = -1
                    lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
                End If
            End If
    End Sub
    Sub Msg_err(ByVal mTest As String)
        lblMsgBox.Text = mTest
        If mTest = "" Then
            MultiViewError.ActiveViewIndex = 0
        Else
            MultiViewError.ActiveViewIndex = 0
        End If
    End Sub

    '==========================Master tabel sasaran mutu per divisi
    Sub DetailMasterOn()
        MultiViewActionPlane.ActiveViewIndex = 0 : MultiViewActionPlaneENtry.ActiveViewIndex = -1
        LVActionPlane.DataBind()
        MultiViewNilaiProgress.ActiveViewIndex = 0 : MultiViewNilaiProgressEntry.ActiveViewIndex = -1
        LVNilaiSasaranMutu.DataBind()
    End Sub
    Sub DetailMasterOf()
        MultiViewActionPlane.ActiveViewIndex = -1 : MultiViewActionPlaneENtry.ActiveViewIndex = -1
        MultiViewNilaiProgress.ActiveViewIndex = -1 : MultiViewNilaiProgressEntry.ActiveViewIndex = -1
    End Sub

    Protected Sub Btn0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnA.Click
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM ISO -- ADD DATA'") = 1 Then
            MultiViewMasterIsi.ActiveViewIndex = 0
            Call ClearSasaranMutu()
        Else
            Call Msg_err("Tidak boleh melakukan menu ini") : Exit Sub
        End If
    End Sub
    Sub ClearSasaranMutu()
        TxtID.Text = "" : TxtID.Enabled = True
        TxtSMDep.Text = ""
        TxtSMDesc.Text = ""
        TxtSMTarget.Text = ""
        TxtSMUser.Text = ""
        TxtSMPembuat.Text = ""
        TxtSMTglOn.Text = ""
        TxtSMTglOff.Text = ""
    End Sub
    Protected Sub LvDetailMaster_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDetailMaster.SelectedIndexChanged
        If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM ISO -- EDIT DATA'") = 1 Then
            TxtID.Text = (LvDetailMaster.DataKeys(LvDetailMaster.SelectedIndex).Value.ToString)
            Call GetData_MasterSM("SELECT * FROM TRXN_ISOASM WHERE MUTU_ID='" & TxtID.Text & "'")
            MultiViewMasterIsi.ActiveViewIndex = 0
            Call DetailMasterOn()
        Else
            Call Msg_err("Tidak boleh melakukan menu ini") : Exit Sub
        End If

    End Sub
    Protected Sub ButtonA1Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonASave.Click
        If GetFindRecord_Tabel("SELECT * FROM TRXN_ISOASM WHERE MUTU_ID='" & TxtID.Text & "'") <> 1 Then
            If UpdateData_Tabel(InsertDataMaster, "A") = 1 Then
                TxtID.Enabled = False
            End If
        End If
        Call UpdateData_Tabel(EditDataMaster, "A")
        MultiViewMasterIsi.ActiveViewIndex = -1 : LvDetailMaster.DataBind()
    End Sub
    Protected Sub ButtonA1Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonADel.Click
        Dim mSqlCommand As String = "DELETE FROM TRXN_ISOASM WHERE MUTU_ID='" & TxtID.Text & "'"
        Call UpdateData_Tabel(mSqlCommand, "A")
        MultiViewMasterIsi.ActiveViewIndex = -1 : LvDetailMaster.DataBind()
        Call DetailMasterOf()
    End Sub
    Protected Sub ButtonA1Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonABack.Click
        Call DetailMasterOf()
    End Sub
    Function InsertDataMaster() As String
        InsertDataMaster = "INSERT INTO TRXN_ISOASM (MUTU_ID) VALUES ('" & TxtID.Text & "')"
    End Function
    Function EditDataMaster() As String
        EditDataMaster = "UPDATE TRXN_ISOASM SET " & _
                         "MUTU_SASARANMUTU='" & TxtSMDesc.Text & "'," & _
                         "MUTU_DEPT='" & TxtSMDep.Text & "'," & _
                         "MUTU_TARGET='" & TxtSMTarget.Text & "'," & _
                         "MUTU_ON=" & DtFrSQL(TxtSMTglOn.Text) & "," & _
                         "MUTU_OFF=" & DtFrSQL(TxtSMTglOff.Text) & "," & _
                         "MUTU_USER='" & TxtSMUser.Text & "'," & _
                         "MUTU_CREATE='" & TxtSMPembuat.Text & "' " & _
                         "WHERE  MUTU_ID='" & TxtID.Text & "'"
    End Function

    '==========================Action Plane
    Protected Sub BtnB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnB.Click
        MultiViewActionPlaneENtry.ActiveViewIndex = 0
        Call ClearActionPlan()
    End Sub
    Sub ClearActionPlan()
        TxtActionPlan.Text = ""
        TxtUrutan.Text = ""
        TxtActionPlan.Visible = True
        LblActionPlan.Text = ""

    End Sub
    Protected Sub LVActionPlane_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVActionPlane.SelectedIndexChanged

        TxtUrutan.Text = (LVActionPlane.DataKeys(LVActionPlane.SelectedIndex).Value.ToString)
        Call GetData_MasterActionPlan("SELECT * FROM TRXN_ISOBPLAN WHERE MUTUP_ID='" & TxtID.Text & "' AND MUTUP_URUTAN='" & TxtUrutan.Text & "'")
        MultiViewActionPlaneENtry.ActiveViewIndex = 0
    End Sub
    Protected Sub ButtonBSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBSave.Click
        If GetFindRecord_Tabel("SELECT * FROM TRXN_ISOBPLAN WHERE MUTUP_ID='" & TxtID.Text & "' AND MUTUP_Plan='" & TxtActionPlan.Text & "'") <> 1 Then
            If UpdateData_Tabel(InsertDataActionPlan, "B") = 1 Then
            End If
        End If
        Call UpdateData_Tabel(EditDataAction, "B")
        MultiViewActionPlaneENtry.ActiveViewIndex = -1 : LVActionPlane.DataBind()
    End Sub

    Protected Sub ButtonB1Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonBDel.Click
        Dim mSqlCommand As String = "DELETE FROM TRXN_ISOBPLAN WHERE MUTUP_ID='" & TxtID.Text & "' AND MUTUP_URUTAN='" & TxtUrutan.Text & "'"
        Call UpdateData_Tabel(mSqlCommand, "B")
        MultiViewActionPlaneENtry.ActiveViewIndex = -1 : LVActionPlane.DataBind()
    End Sub

    Function EditDataAction() As String
        EditDataAction = "UPDATE TRXN_ISOBPLAN SET " & _
                         "MUTUP_URUTAN='" & TxtUrutan.Text & "'" & _
                         "WHERE MUTUP_ID='" & TxtID.Text & "' AND MUTUP_PLAN='" & TxtActionPlan.Text & "'"
    End Function


    Protected Sub ButtonBBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBBack.Click
        MultiViewActionPlaneENtry.ActiveViewIndex = -1
    End Sub
    Function InsertDataActionPlan() As String
        InsertDataActionPlan = "INSERT INTO TRXN_ISOBPLAN (MUTUP_ID, MUTUP_URUTAN, MUTUP_PLAN) VALUES ('" & TxtID.Text & "','" & TxtUrutan.Text & "','" & TxtActionPlan.Text & "')"
    End Function

    '==========================Progress Sasaran Mutu
    Protected Sub BtnNilai_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSM.Click
        MultiViewNilaiProgressEntry.ActiveViewIndex = 0
        Call ClearNilaiProgressSM()
    End Sub
    Sub ClearNilaiProgressSM()
        lblSasaranMutuProgress.Text = ""
        TxtSasaranMutuProgress.Text = ""
        TxtSasaranMutuTarget.Text = ""
        TxtSasaranMutuActual.Text = ""
        TxtSasaranMutuHitung.Text = ""
    End Sub
    Sub SasaranMutuOn()
        MultiViewMasalah.ActiveViewIndex = 0 : MultiViewMasalahENtry.ActiveViewIndex = -1 : LvMasalah.DataBind()
        MultiViewKoreksi.ActiveViewIndex = 0 : MultiViewKoreksiEntry.ActiveViewIndex = -1 : LVKoreksi.DataBind()
        MultiViewPerbaikan.ActiveViewIndex = 0 : MultiViewPerbaikanEntry.ActiveViewIndex = -1 : LvPerbaikan.DataBind()
    End Sub
    Sub SasaranMutuOf()
        MultiViewMasalah.ActiveViewIndex = 0 : MultiViewMasalahENtry.ActiveViewIndex = -1
        MultiViewKoreksi.ActiveViewIndex = 0 : MultiViewKoreksiEntry.ActiveViewIndex = -1
        MultiViewPerbaikan.ActiveViewIndex = 0 : MultiViewPerbaikanEntry.ActiveViewIndex = -1
    End Sub

    Protected Sub LVNilaiSasaranMutu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVNilaiSasaranMutu.SelectedIndexChanged
        lblSasaranMutuProgress.Text = (LVNilaiSasaranMutu.DataKeys(LVNilaiSasaranMutu.SelectedIndex).Value.ToString)
        TxtSasaranMutuProgress.Text = lblSasaranMutuProgress.Text
        GetData_MasterNilai("SELECT * FROM TRXN_ISOENILAI WHERE MUTUN_ID='" & TxtID.Text & "' AND YEAR(MUTUN_PROGRESS)=" & Year(CDate(lblSasaranMutuProgress.Text)) & " AND MONTH(MUTUN_PROGRESS)=" & Month(CDate(lblSasaranMutuProgress.Text)) & "")
        MultiViewNilaiProgressEntry.ActiveViewIndex = 0
        Call SasaranMutuOn()
    End Sub

    Protected Sub BtnNilaiSMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave.Click
        lblSasaranMutuProgress.Text = ""
        If lblSasaranMutuProgress.Text = TxtSasaranMutuProgress.Text And lblSasaranMutuProgress.Text <> "" Then
            LblErrorSaveC.Text = "Tanggal Progress tidak bisa dirubah"
        Else
            lblSasaranMutuProgress.Text = TxtSasaranMutuProgress.Text
            If GetFindRecord_Tabel("SELECT * FROM TRXN_ISOENILAI WHERE MUTUN_ID='" & TxtID.Text & "' AND YEAR(MUTUN_PROGRESS)=" & Year(CDate(lblSasaranMutuProgress.Text)) & " AND MONTH(MUTUN_PROGRESS)=" & Month(CDate(lblSasaranMutuProgress.Text)) & "") <> 1 Then
                If UpdateData_Tabel(InsertDataNilai, "C") = 1 Then
                End If
            End If
            Call UpdateData_Tabel(EditDataNilai, "C")
        End If

        MultiViewNilaiProgressEntry.ActiveViewIndex = -1 : LVNilaiSasaranMutu.DataBind()
        Call SasaranMutuOf()
    End Sub

    Protected Sub BtnNilaiSMDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMDel.Click
        If GetFindRecord_Tabel("SELECT * FROM TRXN_ISOENILAI WHERE MUTUN_ID='" & TxtID.Text & "' AND YEAR(MUTUN_PROGRESS)=" & Year(CDate(lblSasaranMutuProgress.Text)) & " AND MONTH(MUTUN_PROGRESS)=" & Month(CDate(lblSasaranMutuProgress.Text)) & " AND MUTUN_CREATEUSERTGL IS NULL AND MUTUN_CREATEMGMTGL IS NULL") = 1 Then
            Dim mSqlCommand As String = "DELETE FROM TRXN_ISOENILAI WHERE MUTUN_ID='" & TxtID.Text & "' AND YEAR(MUTUN_PROGRESS)=" & Year(CDate(lblSasaranMutuProgress.Text)) & " AND MONTH(MUTUN_PROGRESS)=" & Month(CDate(lblSasaranMutuProgress.Text)) & ""
            Call UpdateData_Tabel(mSqlCommand, "C")
            'Masalah
            mSqlCommand = "DELETE FROM TRXN_ISOCMASALAH] WHERE MUTUM_ID='" & TxtID.Text & "' AND YEAR(MUTUM_PROGRESS)=" & Year(CDate(lblSasaranMutuProgress.Text)) & " AND MONTH(MUTUN_PROGRESS)=" & Month(CDate(lblSasaranMutuProgress.Text)) & ""
            Call UpdateData_Tabel(mSqlCommand, "C")
            'Koreksi
            mSqlCommand = "DELETE FROM TRXN_ISODTINDAKAN] WHERE MUTUT_TIPE='A' AND MUTUT_ID='" & TxtID.Text & "' AND YEAR(MUTUT_PROGRESS)=" & Year(CDate(lblSasaranMutuProgress.Text)) & " AND MONTH(MUTUN_PROGRESS)=" & Month(CDate(lblSasaranMutuProgress.Text)) & ""
            Call UpdateData_Tabel(mSqlCommand, "C")
            'Tindakan
            mSqlCommand = "DELETE FROM TRXN_ISODTINDAKAN] WHERE MUTUT_TIPE='C' AND MUTUT_ID='" & TxtID.Text & "' AND YEAR(MUTUT_PROGRESS)=" & Year(CDate(lblSasaranMutuProgress.Text)) & " AND MONTH(MUTUN_PROGRESS)=" & Month(CDate(lblSasaranMutuProgress.Text)) & ""
            Call UpdateData_Tabel(mSqlCommand, "C")

            MultiViewNilaiProgressEntry.ActiveViewIndex = -1 : LVNilaiSasaranMutu.DataBind()
        End If
        Call SasaranMutuOf()
    End Sub

    Protected Sub BtnNilaiSMBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMBack.Click
        MultiViewNilaiProgressEntry.ActiveViewIndex = -1
        Call SasaranMutuOf()
    End Sub

    Function InsertDataNilai() As String
        InsertDataNilai = "INSERT INTO TRXN_ISOENILAI (MUTUN_ID,MUTUN_PROGRESS) VALUES ('" & TxtID.Text & "'," & DtFrSQL(lblSasaranMutuProgress.Text) & ")"
    End Function
    Function EditDataNilai() As String
        Dim mBaca1 As String = ""
        Dim mBaca2 As String = ""
        If Len(TxtSasaranMutuHitung.Text) > 200 Then
            mBaca1 = Left(TxtSasaranMutuHitung.Text, 200)
            mBaca2 = Right(TxtSasaranMutuHitung.Text, Len(TxtSasaranMutuHitung.Text) - 200)
        Else
            mBaca1 = TxtSasaranMutuHitung.Text
        End If
        EditDataNilai = ""
        EditDataNilai = "UPDATE TRXN_ISOENILAI SET " & _
                             "MUTUN_TARGET=" & ndb(TxtSasaranMutuTarget.Text) & "," & _
                             "MUTUN_ACTUAL=" & ndb(TxtSasaranMutuActual.Text) & "," & _
                             "MUTUN_CARAHITUNG1='" & mBaca1 & "'," & _
                             "MUTUN_CARAHITUNG2='" & mBaca2 & "' " & _
                             "WHERE MUTUN_ID='" & TxtID.Text & "' AND YEAR(MUTUN_PROGRESS)=" & Year(CDate(TxtSasaranMutuProgress.Text)) & " AND MONTH(MUTUN_PROGRESS)=" & Month(CDate(lblSasaranMutuProgress.Text)) & ""
    End Function

    Protected Sub BtnNilaiSMSave0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave0.Click
        Dim mSqlCommand As String = ""
        If Mid(lblAkses.Text, 3, 1) <> "1" Then
            LblErrorSaveD.Text = "Tidak boleh melakukan persetujuan Head" : Exit Sub
        End If

        mSqlCommand = "UPDATE TRXN_ISOENILAI SET " & _
                          "MUTUN_CREATEUSER='" & nSr(LblUserName.Text) & "'," & _
                          "MUTUN_CREATEUSERTGL='" & Now() & "'" & _
                          "WHERE MUTUN_ID='" & TxtID.Text & "' AND YEAR(MUTUN_PROGRESS)=" & Year(CDate(TxtSasaranMutuProgress.Text)) & " AND MONTH(MUTUN_PROGRESS)=" & Month(CDate(lblSasaranMutuProgress.Text)) & ""
        Call UpdateData_Tabel(mSqlCommand, "D")

        LVNilaiSasaranMutu.DataBind()
    End Sub

    Protected Sub BtnNilaiSMSave1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave1.Click
        Dim mSqlCommand As String = ""
        If Mid(lblAkses.Text, 4, 1) <> "1" Then
            LblErrorSaveD.Text = "Tidak boleh melakukan persetujuan Wakil Manajemen" : Exit Sub
        End If

        mSqlCommand = "UPDATE TRXN_ISOENILAI SET " & _
                          "MUTUN_CREATEMGM='" & nSr(LblUserName.Text) & "'," & _
                          "MUTUN_CREATEMGMTGL='" & Now() & "'" & _
                          "WHERE MUTUN_ID='" & TxtID.Text & "' AND YEAR(MUTUN_PROGRESS)=" & Year(CDate(TxtSasaranMutuProgress.Text)) & " AND MONTH(MUTUN_PROGRESS)=" & Month(CDate(lblSasaranMutuProgress.Text)) & ""
        Call UpdateData_Tabel(mSqlCommand, "D")

        LVNilaiSasaranMutu.DataBind()
    End Sub

    '==========================Akar Masalah
    Protected Sub BtnD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnD.Click
        MultiViewMasalahENtry.ActiveViewIndex = 0
        Call ClearMasalah()
    End Sub
    Sub ClearMasalah()
        TxtMasalahDesc.Text = ""
    End Sub

    Protected Sub LvMasalah_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvMasalah.SelectedIndexChanged
        TxtMasalahDesc.Text = (LvMasalah.DataKeys(LvMasalah.SelectedIndex).Value.ToString)
        Dim mSqlCommand As String = "DELETE FROM TRXN_ISOCMASALAH WHERE MUTUM_ID='" & TxtID.Text & "' AND YEAR(MUTUM_PROGRESS)=" & Year(lblSasaranMutuProgress.Text) & " AND MONTH(MUTUM_PROGRESS)=" & Month(lblSasaranMutuProgress.Text) & " AND MUTUM_MASALAH='" & TxtMasalahDesc.Text & "'"
        Call UpdateData_Tabel(mSqlCommand, "D")
        LvMasalah.DataBind()
    End Sub
    Protected Sub ButtonDSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDSave.Click
        If GetFindRecord_Tabel("SELECT * FROM TRXN_ISOCMASALAH WHERE MUTUM_ID='" & TxtID.Text & "' AND YEAR(MUTUM_PROGRESS)=" & Year(lblSasaranMutuProgress.Text) & " AND MONTH(MUTUM_PROGRESS)=" & Month(lblSasaranMutuProgress.Text) & " AND MUTUM_MASALAH='" & lblSasaranMutuProgress.Text & "'") <> 1 Then
            If UpdateData_Tabel(InsertDataMasalah, "D") = 1 Then
            End If
        Else
            LblErrorSaveC.Text = "Data sudah ada di Tabel"
        End If
        MultiViewMasalahENtry.ActiveViewIndex = -1 : LvMasalah.DataBind()
    End Sub
    Protected Sub ButtonDBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDBack.Click
        MultiViewMasalahENtry.ActiveViewIndex = -1
    End Sub
    Function InsertDataMasalah() As String
        InsertDataMasalah = "INSERT INTO TRXN_ISOCMASALAH (MUTUM_ID,MUTUM_PROGRESS,MUTUM_MASALAH) VALUES ('" & TxtID.Text & "'," & DtFrSQL(lblSasaranMutuProgress.Text) & ",'" & TxtMasalahDesc.Text & "')"
    End Function

    '==========================Koreksi
    Protected Sub BtnE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnE.Click
        MultiViewKoreksiEntry.ActiveViewIndex = 0
        Call ClearKoreksi()
    End Sub
    Sub ClearKoreksi()
        TxtKoreksiTindakan.Text = ""
        TxtKoreksiPIC.Text = ""
        TxtKoreksiDue.Text = ""
    End Sub
    Protected Sub LvKoreksi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVKoreksi.SelectedIndexChanged
        TxtKoreksiTindakan.Text = (LVKoreksi.DataKeys(LVKoreksi.SelectedIndex).Value.ToString)
        Dim mSqlCommand As String = "DELETE FROM TRXN_ISODTINDAKAN WHERE MUTUT_TIPE='A' AND MUTUT_ID='" & TxtID.Text & "' AND YEAR(MUTUT_PROGRESS)=" & Year(lblSasaranMutuProgress.Text) & " AND MONTH(MUTUT_PROGRESS)=" & Month(lblSasaranMutuProgress.Text) & " AND MUTUT_TINDAKAN='" & TxtKoreksiTindakan.Text & "'"
        Call UpdateData_Tabel(mSqlCommand, "D")
        MultiViewKoreksiEntry.ActiveViewIndex = -1 : LVKoreksi.DataBind()
    End Sub
    Protected Sub BtnESave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnESave.Click
        If GetFindRecord_Tabel("SELECT * FROM TRXN_ISODTINDAKAN WHERE MUTUT_TIPE='A' AND MUTUT_ID='" & TxtID.Text & "' AND YEAR(MUTUT_PROGRESS)=" & Year(lblSasaranMutuProgress.Text) & " AND MONTH(MUTUT_PROGRESS)=" & Month(lblSasaranMutuProgress.Text) & " AND MUTUT_TINDAKAN='" & TxtKoreksiTindakan.Text & "'") <> 1 Then
            If UpdateData_Tabel(InsertDataKoreksi("A", TxtKoreksiTindakan.Text, TxtKoreksiPIC.Text, TxtKoreksiDue.Text), "D") = 1 Then
                MultiViewKoreksiEntry.ActiveViewIndex = -1 : LVKoreksi.DataBind()
            End If
        Else
            LblErrorSaveE.Text = "Data sudah ada di Tabel"
        End If
    End Sub
    Protected Sub BtnEBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEBack.Click
        MultiViewKoreksiEntry.ActiveViewIndex = -1
    End Sub

    Function InsertDataKoreksi(ByVal mTipe As String, ByVal mNote As String, ByVal mPIC As String, ByVal mDue As String) As String
        InsertDataKoreksi = "INSERT INTO TRXN_ISODTINDAKAN (MUTUT_TIPE,MUTUT_ID,MUTUT_PROGRESS,MUTUT_TINDAKAN,MUTUT_PIC,MUTUT_DUE) VALUES ('" & mTipe & "','" & TxtID.Text & "'," & DtFrSQL(lblSasaranMutuProgress.Text) & ",'" & mNote & "','" & mPIC & "'," & DtFrSQL(mDue) & ")"
    End Function

    '==========================Perbaikan
    Protected Sub BtnF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnF.Click
        MultiViewPerbaikanEntry.ActiveViewIndex = 0
        Call Clearperbaikan()
    End Sub
    Sub Clearperbaikan()
        TxtPerbaikanTindakan.Text = ""
        TxtPerbaikanPIC.Text = ""
        TxtPerbaikanDue.Text = ""
    End Sub
    Protected Sub LvPerbaikan_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvPerbaikan.SelectedIndexChanged
        TxtPerbaikanTindakan.Text = (LvPerbaikan.DataKeys(LvPerbaikan.SelectedIndex).Value.ToString)
        Dim mSqlCommand As String = "DELETE FROM TRXN_ISODTINDAKAN WHERE MUTUT_TIPE='C' AND MUTUT_ID='" & TxtID.Text & "' AND YEAR(MUTUT_PROGRESS)=" & Year(lblSasaranMutuProgress.Text) & " AND MONTH(MUTUT_PROGRESS)=" & Month(lblSasaranMutuProgress.Text) & " AND MUTUT_TINDAKAN='" & TxtPerbaikanTindakan.Text & "'"
        Call UpdateData_Tabel(mSqlCommand, "D")
        MultiViewPerbaikanEntry.ActiveViewIndex = -1 : LvPerbaikan.DataBind()
    End Sub
    Protected Sub BtnFSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFSave.Click
        If GetFindRecord_Tabel("SELECT * FROM TRXN_ISODTINDAKAN WHERE MUTUT_TIPE='C' AND MUTUT_ID='" & TxtID.Text & "' AND YEAR(MUTUT_PROGRESS)=" & Year(lblSasaranMutuProgress.Text) & " AND MONTH(MUTUT_PROGRESS)=" & Month(lblSasaranMutuProgress.Text) & " AND MUTUT_TINDAKAN='" & TxtPerbaikanTindakan.Text & "'") <> 1 Then
            If UpdateData_Tabel(InsertDataKoreksi("B", TxtPerbaikanTindakan.Text, TxtPerbaikanPIC.Text, TxtPerbaikanDue.Text), "D") = 1 Then
                MultiViewPerbaikanEntry.ActiveViewIndex = -1 : LVKoreksi.DataBind()
            End If
        Else
            LblErrorSaveF.Text = "Data sudah ada di Tabel"
        End If
    End Sub
    Protected Sub BtnFBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFBack.Click
        MultiViewPerbaikanEntry.ActiveViewIndex = -1
    End Sub



    Function GetData_MasterSM(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MasterSM = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtID.Text = nSr(MyRecReadA("MUTU_ID")) : TxtID.Enabled = False
                TxtSMDep.Text = nSr(MyRecReadA("MUTU_DEPT"))
                TxtSMDesc.Text = nSr(MyRecReadA("MUTU_SASARANMUTU"))
                TxtSMTarget.Text = nSr(MyRecReadA("MUTU_TARGET"))
                TxtSMUser.Text = nSr(MyRecReadA("MUTU_USER"))
                TxtSMPembuat.Text = nSr(MyRecReadA("MUTU_CREATE"))
                TxtSMTglOn.Text = nSr(MyRecReadA("MUTU_ON"))
                TxtSMTglOff.Text = nSr(MyRecReadA("MUTU_OFF"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function
    Function GetData_MasterActionPlan(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MasterActionPlan = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtActionPlan.Visible = False
                LblActionPlan.Text = nSr(MyRecReadA("MUTUP_PLAN"))
                TxtUrutan.Text = nSr(MyRecReadA("MUTUP_URUTAN"))
                GetData_MasterActionPlan = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function
    Function GetData_MasterNilai(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MasterNilai = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                lblSasaranMutuProgress.Text = nSr(MyRecReadA("MUTUN_PROGRESS"))
                TxtSasaranMutuProgress.Text = nSr(MyRecReadA("MUTUN_PROGRESS"))
                TxtSasaranMutuTarget.Text = nSr(MyRecReadA("MUTUN_TARGET"))
                TxtSasaranMutuActual.Text = nSr(MyRecReadA("MUTUN_ACTUAL"))
                TxtSasaranMutuHitung.Text = nSr(MyRecReadA("MUTUN_CARAHITUNG1")) & nSr(MyRecReadA("MUTUN_CARAHITUNG2"))

                'LblSasaranMutuStjATgl.Text = nSr(MyRecReadA("MUTUN_CREATEUSERTGL"))
                'TxtSasaranMutuStjAUser.Text = nSr(MyRecReadA("MUTUN_CREATEUSER"))

                'TxtSasaranMutuStjBTgl.Text = nSr(MyRecReadA("MUTUN_CREATEMGMTGL"))
                'TxtSasaranMutuStjBUser.Text = nSr(MyRecReadA("MUTUN_CREATEMGM"))

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetData_MasterMasalah(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MasterMasalah = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtMasalahDesc.Text = nSr(MyRecReadA("MUTUM_MASALAH"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
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
            ' Call Msg_err(ex.Message)
        End Try
    End Function
    Function GetFindRecord_Tabel(ByVal mSqlCommadstring As String) As Integer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetFindRecord_Tabel = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                GetFindRecord_Tabel = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Function UpdateData_Tabel(ByVal mSqlCommadstring As String, ByVal mPos As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        UpdateData_Tabel = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_Tabel = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call ErrorIsi(mPos, ex.Message)
        End Try
    End Function
    Sub ErrorIsi(ByVal Kode As String, ByVal Errormsg As String)
        If Kode = "A" Then
            LblErrorSaveA.Text = Errormsg
        ElseIf Kode = "B" Then
            LblErrorSaveB.Text = Errormsg
        ElseIf Kode = "C" Then
            LblErrorSaveC.Text = Errormsg
        ElseIf Kode = "D" Then
            LblErrorSaveD.Text = Errormsg
        ElseIf Kode = "E" Then
            LblErrorSaveE.Text = Errormsg
        ElseIf Kode = "F" Then
            LblErrorSaveF.Text = Errormsg
        End If
    End Sub
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
    Function GetNumerikTxt(ByVal mNilaiku As String) As String
        GetNumerikTxt = Replace(mNilaiku, ",", "")
    End Function
    Function nLg(ByRef nilai As Object) As Double
        On Error GoTo ErrHand
        nilai = GetNumerikTxt(nilai)
        nLg = 0
        If IsNumeric(nilai) Then nLg = Val(nilai) '10
ErrHand:
    End Function
    Function ndb(ByRef nilai As Object) As Double
        On Error GoTo ErrHand
        ndb = 0
        nilai = GetNumerikTxt(nilai)
        If IsNumeric(nilai) Then ndb = Val(nilai) '10
ErrHand:
    End Function


End Class

