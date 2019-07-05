Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Imports System.Web.Security
'1. Cari Halaman3
'2. Audit Save 
'3. Head Parts Save
'4. Cari Halaman1
'5. Cari Halaman2
'6. Cari Halaman4
'7. Auditor Save
'8. SM Save
'9. Account Save


Partial Class Form0202StatusSPK01AuditParts
    Inherits System.Web.UI.Page
    '1 Pencarian
    '2 Isi Audit
    '3 ..................

    Public MyRecReadA As OleDbDataReader
    Public MyRecReadB As OleDbDataReader
    Public MyRecReadC As OleDbDataReader
    Public MyRecReadD As OleDbDataReader
    Public MyRecReadF As OleDbDataReader
    Public MySTRsql1 As String
    Dim mErrorMySistem As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If
        lblAkses.Visible = False
        If LblUserName.Text = "" Then
            Dim x As String
            Dim mFound As Byte = 0
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = ucase(x.ToString)
            mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0105'")
            TxtPartsLantai.Text = "KODE LANTAI"
            MultiViewSuportLaporan1dan2.ActiveViewIndex = -1
            TxtCabang.Text = lblArea1.Text
            LVDataAduditExport.Visible = False
            LVDataAdudit128Export.Visible = False
            If mFound = 1 Then
                MultiViewSuportLaporan1dan2.ActiveViewIndex = 0
                MultiViewForm.ActiveViewIndex = 0
                Call Tampil(0, -1, -1, -1)
            Else
                MultiViewForm.ActiveViewIndex = -1
                Call Msg_err("TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI")
            End If
        End If
    End Sub

    Sub Msg_err(ByVal mTest As String)

        'Response.Write("<script>alert('" & mTest & "')</script>")

        lblMsgBox.Text = mTest
        If mTest = "" Then
            MultiViewError.ActiveViewIndex = 0
        Else
            MultiViewError.ActiveViewIndex = 0
        End If
        If mTest <> "" Then
            Response.Write("<script>alert('" & mTest & "')</script>")
        End If
    End Sub

    Sub MsgProses(ByVal mtext As String, ByVal Kunci As Byte)
        lblProsesBox.Text = mtext
    End Sub

    Sub Tampil(ByVal mFormQuery As Integer, ByVal mFormAudit As Integer, ByVal mTabelParts As Integer, ByVal mTabelAudit As Integer)
        MultiViewForm21Query.ActiveViewIndex = mFormQuery
        MultiViewForm22Audit.ActiveViewIndex = mFormAudit

        If mFormAudit = -1 Then
            MultiViewForm22AuditTombol.ActiveViewIndex = mFormAudit
            'MultiViewForm22AuditNote2.ActiveViewIndex = mFormAudit
            MultiViewForm22AuditNote2Tombol.ActiveViewIndex = mFormAudit
            'MultiViewForm22HeadPartsNote1.ActiveViewIndex = mFormAudit

            MultiViewForm22HeadPartsNote1Tombol.ActiveViewIndex = mFormAudit
            'MultiViewForm22SM.ActiveViewIndex = mFormAudit
            MultiViewForm22SMTombol.ActiveViewIndex = mFormAudit
            'MultiViewForm22ACCFIN.ActiveViewIndex = mFormAudit
            MultiViewForm22ACCFINTombol.ActiveViewIndex = mFormAudit

        ElseIf mFormAudit = 0 Then
            MultiViewForm22Audit.ActiveViewIndex = 0
            MultiViewForm22AuditTombol.ActiveViewIndex = IIf(Mid(lblAkses.Text, 2, 1) = "1", 0, -1)
            'MultiViewForm22AuditNote2.ActiveViewIndex = 0
            MultiViewForm22AuditNote2Tombol.ActiveViewIndex = IIf(Mid(lblAkses.Text, 7, 1) = "1", 0, -1)
            'MultiViewForm22HeadPartsNote1.ActiveViewIndex = 0
            MultiViewForm22HeadPartsNote1Tombol.ActiveViewIndex = IIf(Mid(lblAkses.Text, 3, 1) = "1", 0, -1)
            'MultiViewForm22SM.ActiveViewIndex = 0
            MultiViewForm22SMTombol.ActiveViewIndex = IIf(Mid(lblAkses.Text, 8, 1) = "1", 0, -1)
            'MultiViewForm22ACCFIN.ActiveViewIndex = 0
            MultiViewForm22ACCFINTombol.ActiveViewIndex = IIf(Mid(lblAkses.Text, 9, 1) = "1", 0, -1)
        End If

        If InStr(TxtCabang.Text, "112") <> 0 Then
            MultiViewTabelStokPart112.ActiveViewIndex = mTabelParts
            MultiViewTabelAudit112.ActiveViewIndex = mTabelAudit
        Else
            MultiViewTabelStokPart128.ActiveViewIndex = mTabelParts
            MultiViewTabelAudit128.ActiveViewIndex = mTabelAudit
        End If
        If MultiViewForm22SMTombol.ActiveViewIndex <> -1 Then
            If GetDataD_00NoFound01Found("SELECT * FROM TEMP_AUDITPART WHERE AUDITPART_NOTE1TGL IS NULL", TxtCabang.Text) = 1 Then
                MultiViewForm22SMTombol.ActiveViewIndex = 1
            End If

        End If
        If MultiViewForm22ACCFINTombol.ActiveViewIndex <> -1 Then
            If GetDataD_00NoFound01Found("SELECT * FROM TEMP_AUDITPART WHERE AUDITPART_NOTE3TGL IS NULL", TxtCabang.Text) = 1 Then
                MultiViewForm22ACCFINTombol.ActiveViewIndex = 1
            End If
        End If


    End Sub

    Function GetDataA_DetailParts(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnetSvcs" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetDataA_DetailParts = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_DetailParts = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                TxtPartsLantaiku.Text = (nSr(MyRecReadA("PARTS_LOKASI")))
                If TxtPartsLantaiku.Text = "NONE" Then
                    TxtPartsLantaiku.Enabled = True
                Else
                    TxtPartsLantaiku.Enabled = False
                End If
                LblPartsNo.Text = (nSr(MyRecReadA("PARTS_NO")))
                LblPartsNama.Text = (nSr(MyRecReadA("PARTS_NAMA")))
                LblPartsStk.Text = (nSr(MyRecReadA("PARTS_STOCK")))
                LblPartsPickup.Text = (nSr(MyRecReadA("PARTS_QYPESAN")))
                LblPartsActual.Text = Val(nSr(MyRecReadA("PARTS_STOCK"))) - Val(nSr(MyRecReadA("PARTS_QYPESAN")))
                TxtPartsAuditQty.Text = LblPartsActual.Text
                TxtPartsAuditNote.Text = ""
                LblPartsUserNma.Text = LblUserName.Text
                LblPartsUserTgl.Text = ""
                LblPartsStokTgl.Text = (nSr(MyRecReadA("mTGLSekarang")))
                LblPartsStatusSimpan.Text = ""

                lblHeadPartsTgl.Text = ""
                lblHeadPartsUser.Text = ""
                TxtHeadPartsNote.Text = ""

                TxtAuditorAdjemsnt.Text = ""
                TxtAuditorNote.Text = ""
                LblAuditorUser.Text = ""
                LblAuditorTgl.Text = ""

            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Sub clearCallPartno()
        LblPartsNo.Text = ""
        LblPartsNama.Text = ""
        LblPartsStk.Text = ""
        LblPartsPickup.Text = ""
        LblPartsActual.Text = ""
        TxtPartsAuditQty.Text = ""
        TxtPartsAuditNote.Text = ""
        LblPartsUserNma.Text = ""
        LblPartsUserTgl.Text = ""
        LblPartsStokTgl.Text = ""
        LblPartsStatusSimpan.Text = ""

        lblHeadPartsTgl.Text = ""
        lblHeadPartsUser.Text = ""
        TxtHeadPartsNote.Text = ""

        TxtAuditorAdjemsnt.Text = ""
        TxtAuditorNote.Text = ""
        LblAuditorUser.Text = ""
        LblAuditorTgl.Text = ""
    End Sub

    Function GetDataA_DetailPartsAudit(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnetSvcs" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetDataA_DetailPartsAudit = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_DetailPartsAudit = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                TxtPartsLantaiku.Text = (nSr(MyRecReadA("PARTS_LOKASI")))
                If TxtPartsLantaiku.Text = "NONE" Then
                    TxtPartsLantaiku.Enabled = True
                Else
                    TxtPartsLantaiku.Enabled = False
                End If
                LblPartsNo.Text = (nSr(MyRecReadA("PARTS_NO")))
                LblPartsNama.Text = (nSr(MyRecReadA("PARTS_NAMA")))
                LblPartsStk.Text = (nSr(MyRecReadA("PARTS_STOCK")))
                LblPartsPickup.Text = (nSr(MyRecReadA("PARTS_QYPESAN")))
                LblPartsActual.Text = Val(nSr(MyRecReadA("PARTS_STOCK"))) - Val(nSr(MyRecReadA("PARTS_QYPESAN")))
                TxtPartsAuditQty.Text = (nSr(MyRecReadA("AUDITPART_QTY")))
                TxtPartsAuditNote.Text = (nSr(MyRecReadA("AUDITPART_CATATAN")))
                LblPartsUserNma.Text = (nSr(MyRecReadA("AUDITPART_USER")))
                LblPartsUserTgl.Text = (nSr(MyRecReadA("AUDITPART_TGL")))
                LblPartsStokTgl.Text = (nSr(MyRecReadA("mTGLSekarang")))
                LblPartsStatusSimpan.Text = ""

                TxtHeadPartsNote.Text = (nSr(MyRecReadA("AUDITPART_NOTE1")))
                lblHeadPartsTgl.Text = (nSr(MyRecReadA("AUDITPART_NOTE1TGL")))
                lblHeadPartsUser.Text = (nSr(MyRecReadA("AUDITPART_NOTE1USR")))

                TxtAuditorNote.Text = (nSr(MyRecReadA("AUDITPART_NOTE2")))
                TxtAuditorAdjemsnt.Text = (nSr(MyRecReadA("AUDITPART_NOTE2ADJ")))
                LblAuditorUser.Text = (nSr(MyRecReadA("AUDITPART_NOTE2USR")))
                LblAuditorTgl.Text = (nSr(MyRecReadA("AUDITPART_NOTE2TGL")))

            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Protected Sub lvStockPart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvStockPart.SelectedIndexChanged
        '    Call clearInput()
        LblPartsNo.Text = (lvStockPart.DataKeys(lvStockPart.SelectedIndex).Value.ToString)

        If GetDataA_DetailPartsAudit("SELECT *,GETDATE() as mTGLSekarang FROM DATA_PARTS,TEMP_AUDITPART WHERE PARTS_NO = AUDITPART_NO AND PARTS_NO='" & LblPartsNo.Text & "' AND AUDITPART_USER='" & LblUserName.Text & "'", TxtCabang.Text) <> 1 Then
            Call GetDataA_DetailParts("SELECT *,GETDATE() as mTGLSekarang  FROM DATA_PARTS WHERE PARTS_NO='" & LblPartsNo.Text & "'", TxtCabang.Text)
        End If
        LVDataAdudit.DataBind()
        Call Tampil(-1, 0, -1, 0)
    End Sub
    Protected Sub lvStockPart128_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvStockPart128.SelectedIndexChanged
        '    Call clearInput()
        LblPartsNo.Text = (lvStockPart128.DataKeys(lvStockPart128.SelectedIndex).Value.ToString)

        If GetDataA_DetailPartsAudit("SELECT *,GETDATE() as mTGLSekarang FROM DATA_PARTS,TEMP_AUDITPART WHERE PARTS_NO = AUDITPART_NO AND PARTS_NO='" & LblPartsNo.Text & "' AND AUDITPART_USER='" & LblUserName.Text & "'", TxtCabang.Text) <> 1 Then
            Call GetDataA_DetailParts("SELECT *,GETDATE() as mTGLSekarang  FROM DATA_PARTS WHERE PARTS_NO='" & LblPartsNo.Text & "'", TxtCabang.Text)
        End If

        LVDataAdudit128.DataBind()
        Call Tampil(-1, 0, -1, 0)

    End Sub

    Protected Sub LVDataAdudit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVDataAdudit.SelectedIndexChanged
        '    Call clearInput()
        LblPartsNo.Text = (LVDataAdudit.DataKeys(LVDataAdudit.SelectedIndex).Value.ToString)
        If GetDataA_DetailPartsAudit("SELECT *,GETDATE() as mTGLSekarang FROM DATA_PARTS,TEMP_AUDITPART WHERE PARTS_NO = AUDITPART_NO AND PARTS_NO='" & LblPartsNo.Text & "'", TxtCabang.Text) <> 1 Then
            Msg_err("Nomor Tersebut belum di Audit")
        End If
        LVDataAdudit.DataBind()
        Call Tampil(-1, 0, -1, 0)
    End Sub
    Protected Sub LVDataAdudit128_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVDataAdudit128.SelectedIndexChanged
        '    Call clearInput()
        LblPartsNo.Text = (LVDataAdudit128.DataKeys(LVDataAdudit128.SelectedIndex).Value.ToString)
        If GetDataA_DetailPartsAudit("SELECT *,GETDATE() as mTGLSekarang FROM DATA_PARTS,TEMP_AUDITPART WHERE PARTS_NO = AUDITPART_NO AND PARTS_NO='" & LblPartsNo.Text & "'", TxtCabang.Text) <> 1 Then
            Msg_err("Nomor Tersebut belum di Audit")
        End If
        LVDataAdudit128.DataBind()
        Call Tampil(-1, 0, -1, 0)

    End Sub

    Protected Sub ButtonTabelPartsGO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonTabelPartsGO.Click
        Call clearCallPartno()
        If TxtCabang.Text = "112" Then
            lvStockPart.DataBind()
        Else
            lvStockPart128.DataBind()
        End If
        Call Tampil(0, -1, 0, -1)
    End Sub
    Protected Sub ButtonTabelPartsSM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonTabelPartsSM.Click
        Call clearCallPartno()

        LblPartsNo.Text = ""

        TxtHeadPartsNote.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE1 as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        lblHeadPartsTgl.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE1TGL  as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        lblHeadPartsUser.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE1USR as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        CheckBoxHeadParts.Checked = IIf(GetDataD_IsiField("SELECT AUDITPART_NOTE1STATUS as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text) = "1", True, False)

        TxtHeadSMNote.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE3 as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        lblHeadSMTgl.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE3TGL as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        lblHeadSMUser.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE3USR as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        CheckBoxHeadSM.Checked = IIf(GetDataD_IsiField("SELECT AUDITPART_NOTE3STATUS as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text) = "1", True, False)

        TxtHeadAcctNote.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE4 as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        lblHeadAccTgl.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE4TGL as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        lblHeadAccUser.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE4USR as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        CheckBoxHeadAcct.Checked = IIf(GetDataD_IsiField("SELECT AUDITPART_NOTE4STATUS as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text) = "1", True, False)

        If TxtCabang.Text = "112" Then
            LVDataAdudit.DataBind()
        Else
            LVDataAdudit128.DataBind()
        End If
        Call Tampil(-1, 0, -1, 0)
    End Sub

    Protected Sub BtnAuditSimpan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAuditSimpan.Click
        Dim mdate As String = ""
        Call UpdateDatabase_Tabel("DELETE FROM TEMP_AUDITPART WHERE AUDITPART_NO='" & LblPartsNo.Text & "' AND AUDITPART_USER='" & LblUserName.Text & "'", TxtCabang.Text)
        Dim mTxtSQL As String = "INSERT INTO TEMP_AUDITPART (AUDITPART_NO,AUDITPART_TGL,AUDITPART_TGLSTOK,AUDITPART_USER,AUDITPART_STOK,AUDITPART_PICKUP,AUDITPART_QTY,AUDITPART_CATATAN) VALUES " & _
                                "('" & LblPartsNo.Text & "',GETDATE()," & DtInSQL(CDate(LblPartsStokTgl.Text)) & ",'" & LblUserName.Text & "'," & Val(LblPartsStk.Text) & "," & Val(LblPartsPickup.Text) & "," & Val(TxtPartsAuditQty.Text) & ",'" & TxtPetik(TxtPartsAuditNote.Text) & "')"
        Call UpdateDatabase_Tabel(mTxtSQL, TxtCabang.Text)
        mdate = GetDataD_IsiField("SELECT MAX(AUDITPART_TGL) as IsiField FROM TEMP_AUDITPART WHERE AUDITPART_NO='" & LblPartsNo.Text & "'", TxtCabang.Text)
        If mdate <> "" Then
            mTxtSQL = "UPDATE DATA_PARTS SET PARTS_TGLAUDIT=" & DtInSQL(CDate(mdate)) & " "

            If TxtPartsLantaiku.Enabled = True And TxtPartsLantaiku.Text <> "NONE" Then
                mTxtSQL = ",PARTS_LOKASI='" & TxtPartsLantaiku.Text & "' "
            End If

            mdate = GetDataD_IsiField("SELECT SUM(AUDITPART_QTY) as IsiField FROM TEMP_AUDITPART WHERE AUDITPART_NO='" & LblPartsNo.Text & "'", TxtCabang.Text)
            mTxtSQL = mTxtSQL & ",PARTS_QTYAUDIT=" & Val(mdate) & " WHERE PARTS_NO='" & LblPartsNo.Text & "'"

            Call UpdateDatabase_Tabel(mTxtSQL, TxtCabang.Text)
            LblPartsStatusSimpan.Text = "Berhasil"

            LblPartsUserTgl.Text = Now()
            LblPartsUserNma.Text = LblUserName.Text

        End If
        If InStr(TxtCabang.Text, "112") <> 0 Then
            LVDataAdudit.DataBind()
        Else
            LVDataAdudit128.DataBind()
        End If

        If CheckBox1.Checked = True Then
            If InStr(TxtCabang.Text, "112") <> 0 Then
                lvStockPart.DataBind()
            Else
                lvStockPart128.DataBind()
            End If
            Call Tampil(0, -1, 0, -1)
        Else
            Call Tampil(-1, 0, -1, 0)
        End If
    End Sub
    Protected Sub BtnAdditorSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdditorSave.Click
        Dim mTxtSQL As String
        mTxtSQL = "UPDATE TEMP_AUDITPART SET " & _
                  "AUDITPART_NOTE2TGL=GETDATE(), " & _
                  "AUDITPART_NOTE2ADJ=" & Val(TxtAuditorAdjemsnt.Text) & ", " & _
                  "AUDITPART_NOTE2USR='" & LblAuditorUser.Text & "', " & _
                  "AUDITPART_NOTE2='" & TxtPetik(TxtAuditorNote.Text) & "' " & _
                  "WHERE AUDITPART_NO='" & LblPartsNo.Text & "'"
        If UpdateDatabase_Tabel(mTxtSQL, TxtCabang.Text) = 1 Then
            LblAuditorTgl.Text = Now()
            LblAuditorUser.Text = LblUserName.Text
            If InStr(TxtCabang.Text, "112") <> 0 Then
                LVDataAdudit.DataBind()
            Else
                LVDataAdudit128.DataBind()
            End If

        End If
        If CheckBox1.Checked = True Then
            If InStr(TxtCabang.Text, "112") <> 0 Then
                lvStockPart.DataBind()
            Else
                lvStockPart128.DataBind()
            End If
            Call Tampil(0, -1, 0, -1)
        Else
            Call Tampil(-1, 0, -1, 0)
        End If
    End Sub
    Protected Sub BtnHeadPartsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHeadPartsSave.Click
        Dim mTxtSQL As String

        mTxtSQL = "UPDATE TEMP_AUDITPART SET " & _
                  "AUDITPART_NOTE1TGL=GETDATE(), " & _
                  "AUDITPART_NOTE1USR='" & LblUserName.Text & "', " & _
                  "AUDITPART_NOTE1STATUS='" & If(CheckBoxHeadParts.Checked = True, "1", "0") & "', " & _
                  "AUDITPART_NOTE1='" & TxtPetik(TxtHeadPartsNote.Text) & "' "
        If TxtHeadPartsNote.Text = "" Then
            mTxtSQL = "" : Call Msg_err("Catatan Belum Diisi")
        ElseIf LblPartsNo.Text <> "" Then
            mTxtSQL = mTxtSQL & " WHERE AUDITPART_NO='" & LblPartsNo.Text & "'"
        ElseIf CheckBoxHeadParts.Checked = True Then
            mTxtSQL = mTxtSQL & " WHERE AUDITPART_NOTE1TGL IS NULL"
        Else
            mTxtSQL = "" : Call Msg_err("Data tidak ada yang berubah")
        End If
        If mTxtSQL <> "" Then
            If UpdateDatabase_Tabel(mTxtSQL, TxtCabang.Text) = 1 Then
                lblHeadPartsTgl.Text = Now()
                lblHeadPartsUser.Text = LblUserName.Text
                If InStr(TxtCabang.Text, "112") <> 0 Then
                    LVDataAdudit.DataBind()
                Else
                    LVDataAdudit128.DataBind()
                End If
            End If
            If CheckBox1.Checked = True Then
                If InStr(TxtCabang.Text, "112") <> 0 Then
                    lvStockPart.DataBind()
                Else
                    lvStockPart128.DataBind()
                End If
                Call Tampil(0, -1, 0, -1)
            Else
                Call Tampil(-1, 0, -1, 0)
            End If
        End If
    End Sub
    Protected Sub BtnHeadSMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHeadSMSave.Click
        If CheckBoxHeadParts.Checked = False Then
            Call Msg_err("Belum disetujui oleh Head Suku Cadang")
        End If

        Dim mTxtSQL As String
        mTxtSQL = "UPDATE TEMP_AUDITPART SET " & _
                  "AUDITPART_NOTE3TGL=GETDATE(), " & _
                  "AUDITPART_NOTE3USR='" & LblUserName.Text & "', " & _
                  "AUDITPART_NOTE3STATUS='" & If(CheckBoxHeadSM.Checked = True, "1", "0") & "', " & _
                  "AUDITPART_NOTE3='" & TxtPetik(TxtHeadSMNote.Text) & "' "
        If TxtHeadSMNote.Text = "" Then
            mTxtSQL = "" : Call Msg_err("Catatan Belum Diisi")
        ElseIf LblPartsNo.Text <> "" Then
            mTxtSQL = mTxtSQL & " WHERE AUDITPART_NO='" & LblPartsNo.Text & "'"
        ElseIf CheckBoxHeadSM.Checked = True Then
            mTxtSQL = mTxtSQL & " WHERE AUDITPART_NOTE3TGL IS NULL"
        Else
            mTxtSQL = "" : Call Msg_err("Data tidak ada yang berubah")
        End If
        If mTxtSQL <> "" Then
            If UpdateDatabase_Tabel(mTxtSQL, TxtCabang.Text) = 1 Then
                lblHeadSMTgl.Text = Now()
                lblHeadSMUser.Text = LblUserName.Text
                If InStr(TxtCabang.Text, "112") <> 0 Then
                    LVDataAdudit.DataBind()
                Else
                    LVDataAdudit128.DataBind()
                End If
            End If
            If CheckBox1.Checked = True Then
                If InStr(TxtCabang.Text, "112") <> 0 Then
                    lvStockPart.DataBind()
                Else
                    lvStockPart128.DataBind()
                End If
                Call Tampil(0, -1, 0, -1)
            Else
                Call Tampil(-1, 0, -1, 0)
            End If
        End If
    End Sub
    Protected Sub BtnHeadAccSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHeadAccSave.Click
        If CheckBoxHeadSM.Checked = False Then
            Call Msg_err("Belum disetujui oleh Servce Manager")
        End If

        Dim mTxtSQL As String
        mTxtSQL = "UPDATE TEMP_AUDITPART SET " & _
                  "AUDITPART_NOTE4TGL=GETDATE(), " & _
                  "AUDITPART_NOTE4USR='" & LblUserName.Text & "', " & _
                  "AUDITPART_NOTE4STATUS='" & If(CheckBoxHeadAcct.Checked = True, "1", "0") & "', " & _
                  "AUDITPART_NOTE4='" & TxtPetik(TxtHeadAcctNote.Text) & "' "
        If TxtHeadAcctNote.Text = "" Then
            mTxtSQL = ""
        ElseIf LblPartsNo.Text <> "" Then
            mTxtSQL = mTxtSQL & " WHERE AUDITPART_NO='" & LblPartsNo.Text & "'"
        ElseIf CheckBoxHeadAcct.Checked = True Then
            mTxtSQL = mTxtSQL & " WHERE AUDITPART_NOTE4TGL IS NULL"
        Else
            mTxtSQL = "" : Call Msg_err("Data tidak ada yang berubah")
        End If
        If mTxtSQL <> "" Then
            If UpdateDatabase_Tabel(mTxtSQL, TxtCabang.Text) = 1 Then
                lblHeadAccTgl.Text = Now()
                lblHeadAccUser.Text = LblUserName.Text
                If InStr(TxtCabang.Text, "112") <> 0 Then
                    LVDataAdudit.DataBind()
                Else
                    LVDataAdudit128.DataBind()
                End If
            End If
            If CheckBox1.Checked = True Then
                If InStr(TxtCabang.Text, "112") <> 0 Then
                    lvStockPart.DataBind()
                Else
                    lvStockPart128.DataBind()
                End If
                Call Tampil(0, -1, 0, -1)
            Else
                Call Tampil(-1, 0, -1, 0)
            End If
        End If
    End Sub
    Protected Sub BtnAuditBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAuditBack.Click
        If InStr(TxtCabang.Text, "112") <> 0 Then
            lvStockPart.DataBind()
        Else
            lvStockPart128.DataBind()
        End If
        Call Tampil(0, -1, 0, -1)
    End Sub
    Protected Sub BtnAdditorBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdditorBack.Click
        If InStr(TxtCabang.Text, "112") <> 0 Then
            lvStockPart.DataBind()
        Else
            lvStockPart128.DataBind()
        End If
        Call Tampil(0, -1, 0, -1)
    End Sub
    Protected Sub BtnHeadPartsBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHeadPartsBack.Click
        If InStr(TxtCabang.Text, "112") <> 0 Then
            lvStockPart.DataBind()
        Else
            lvStockPart128.DataBind()
        End If
        Call Tampil(0, -1, 0, -1)
    End Sub
    Protected Sub BtnHeadSMBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHeadSMBack.Click
        If InStr(TxtCabang.Text, "112") <> 0 Then
            lvStockPart.DataBind()
        Else
            lvStockPart128.DataBind()
        End If
        Call Tampil(0, -1, 0, -1)
    End Sub
    Protected Sub BtnHeadAccBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHeadAccBack.Click
        If InStr(TxtCabang.Text, "112") <> 0 Then
            lvStockPart.DataBind()
        Else
            lvStockPart128.DataBind()
        End If
        Call Tampil(0, -1, 0, -1)
    End Sub

    Function fLg(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        fLg = "0"
        If IsNumeric(nilai) Then fLg = Format(Val(nilai), "###,###,###,###,##0")
ErrHand:
    End Function
    Function nLg(ByRef nilai As Object) As Double
        On Error GoTo ErrHand
        nLg = 0
        If IsNumeric(nilai) Then nLg = Val(nilai) '10
ErrHand:
    End Function
    Function fDb(ByRef nilai As Object) As String
        fDb = "0.00"
        If Not IsDBNull(nilai) Then fDb = Format(nilai, "###,###,###,###,###.#0") '16
    End Function
    Function ndb(ByRef nilai As Object) As Double
        On Error GoTo ErrHand
        ndb = 0
        If IsNumeric(nilai) Then ndb = Val(nilai) '10
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
    Function DtFrSQL(ByRef mNilai As Object) As String
        On Error GoTo ErrHand
        DtFrSQL = "NULL"
        If IsDate(mNilai) Then
            DtFrSQL = "'" & Format(CDate(mNilai), "yyyy-MM-dd hh:mm:ss") & "'"
        End If
        'MsgBox(DtFrSQL)
ErrHand:
    End Function
    Function DtFr(ByRef mNilai As Object, ByRef mFormat As Object) As String
        DtFr = ""
        If Not IsDBNull(mNilai) Then
            DtFr = Format(mNilai, mFormat)
        End If
    End Function
    Function DtInSQL(ByRef nilai As Object) As String
        DtInSQL = "NULL"
        If Not IsDBNull(nilai) Then
            DtInSQL = "'" & Format(CDate(nilai), "yyyy-MM-dd HH:mm:ss") & "'"
        End If
    End Function



    Function GetDataA_UserSecurity(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetDataA_UserSecurity = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_UserSecurity = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                lblAkses.Text = nSr(MyRecReadA("AKSES_DATA"))
                lblArea1.Text = nSr(MyRecReadA("AKSES_AREA"))
                lblArea2.Text = lblArea1.Text
                If Len(lblArea1.Text) > 3 Then
                    lblArea1.Text = Mid(nSr(MyRecReadA("AKSES_AREA")), 1, 3)
                    lblArea2.Text = Mid(nSr(MyRecReadA("AKSES_AREA")), 4, 3)
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message)
        End Try
    End Function
    Function UpdateDatabase_Tabel(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        If mpServer = "" Then
            mpServer = "MyConnCloudDnet" & mpServer
        Else
            mpServer = "MyConnCloudDnetSvcs" & mpServer
        End If
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        UpdateDatabase_Tabel = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateDatabase_Tabel = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function
    Function GetDataD_IsiField(ByVal mSqlCommadstring As String, ByVal mpServer As String) As String
        If mpServer = "" Then
            mpServer = "MyConnCloudDnet" & mpServer
        Else
            mpServer = "MyConnCloudDnetSvcs" & mpServer
        End If
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        'GetData_IsiField = "UnReg"
        GetDataD_IsiField = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadD = cmd.ExecuteReader()
            If MyRecReadD.HasRows = True Then
                MyRecReadD.Read()
                GetDataD_IsiField = (nSr(MyRecReadD("IsiField")))
            End If
            MyRecReadD.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function
    Function GetDataD_00NoFound01Found(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        If mpServer = "" Then
            mpServer = "MyConnCloudDnet" & mpServer
        Else
            mpServer = "MyConnCloudDnetSvcs" & mpServer
        End If
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetDataD_00NoFound01Found = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadD = cmd.ExecuteReader()
            If MyRecReadD.HasRows = True Then
                GetDataD_00NoFound01Found = 1
            End If
            MyRecReadD.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Protected Sub ButtonPsm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPsm.Click
        If TxtCabang.Text = lblArea1.Text And lblArea2.Text <> "" Then
            TxtCabang.Text = lblArea2.Text
        Else
            TxtCabang.Text = lblArea1.Text
        End If
    End Sub

    Protected Sub ButtonExprotMutas112_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonExprotMutas112.Click
        LVDataAduditExport.Visible = True
        LVDataAduditExport.DataBind()
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=PARTSAUDIT112.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        LVDataAduditExport.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
        LVDataAduditExport.Visible = False
    End Sub

    Protected Sub ButtonExprotMutas128_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonExprotMutas128.Click
        LVDataAdudit128Export.Visible = True
        LVDataAdudit128Export.DataBind()

        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=PARTSAUDIT128.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        LVDataAdudit128Export.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
        LVDataAdudit128Export.Visible = True
    End Sub
End Class
