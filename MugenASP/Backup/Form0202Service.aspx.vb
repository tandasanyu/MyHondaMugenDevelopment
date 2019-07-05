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

Partial Class Form04PurchaseOrder
    '1 Pencarian
    '2 Isi Audit
    '3 ..................
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader
    Public MyRecReadB As OleDbDataReader
    Public MyRecReadC As OleDbDataReader
    Public MyRecReadD As OleDbDataReader
    Public MyRecReadF As OleDbDataReader
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
            LblUserName.Text = x.ToString
            mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0105'")
            TxtPartsLantai.Text = "KODE LANTAI"
            If mFound = 1 Then
                'Call GetDataA_LOKASI("SELECT PARTS_LOKASI FROM DATA_PARTS GROUP BY PARTS_LOKASI", lblArea1.Text)
                MultiViewForm.ActiveViewIndex = 2
                Call Tampil(0, -1, -1, -1)
            Else
                Call Msg_err("TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI", 0)
            End If
        End If
    End Sub

    Sub Msg_err(ByVal mTest As String, ByVal mErSystem As Byte)

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
        If mTest <> "" And mErSystem = 1 Then
            mErrorMySistem = mErrorMySistem & " " & mTest
        End If
    End Sub

    Sub Tampil(ByVal mFormQuery As Integer, ByVal mFormAudit As Integer, ByVal mTabelParts As Integer, ByVal mTabelAudit As Integer)
        MultiViewForm21Query.ActiveViewIndex = mFormQuery
        MultiViewForm22Audit.ActiveViewIndex = mFormAudit
        If lblArea1.Text = "112" Then
            MultiViewTabelStokPart112.ActiveViewIndex = mTabelParts
            MultiViewTabelAudit112.ActiveViewIndex = mTabelAudit
        Else
            MultiViewTabelStokPart128.ActiveViewIndex = mTabelParts
            MultiViewTabelAudit128.ActiveViewIndex = mTabelAudit
        End If

    End Sub


    Protected Sub BtnService1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnServce1.Click
        MultiViewMenu.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnService2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnServce2.Click
        MultiViewMenu.ActiveViewIndex = 1
    End Sub
    Protected Sub BtnService3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnServce3.Click
        MultiViewMenu.ActiveViewIndex = 2
    End Sub
    Protected Sub DropDownList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList3.SelectedIndexChanged
        TxtPartsLantai.Text = DropDownList3.Text
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
            Call Msg_err("error " & ex.Message, 0)
        End Try
    End Function
    Function UpdateDatabase_Tabel(ByVal mSqlCommadstring As String, ByVal mpServer As String, ByVal mpErrorSistem As Byte) As Byte
        mpServer = "MyConnCloudDnetSvcs" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
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
            Call Msg_err(ex.Message, mpErrorSistem)
        End Try
    End Function
    Function GetDataD_IsiField(ByVal mSqlCommadstring As String, ByVal mpServer As String, ByVal mpMerrorsis As Byte) As String
        mpServer = "MyConnCloudDnetSvcs" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
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
            Call Msg_err(ex.Message, mpMerrorsis)
        End Try
    End Function
    Function GetDataD_00NoFound01Found(ByVal mSqlCommadstring As String, ByVal mpServer As String, ByVal mpMerrorsis As Byte) As Byte
        mpServer = "MyConnCloudDnetSvcs" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
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
            Call Msg_err(ex.Message, mpMerrorsis)
        End Try
    End Function

    Function GetDataA_LOKASI(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnetSvcs" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        GetDataA_LOKASI = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_LOKASI = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                DropDownList3.Items.Add(nSr(MyRecReadA("PARTS_LOKASI")))
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function
    Function GetDataA_DetailParts(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnetSvcs" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        GetDataA_DetailParts = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_DetailParts = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                TxtPartsLantaiKu.Text = (nSr(MyRecReadA("PARTS_LOKASI")))
                If TxtPartsLantaiKu.Text = "NONE" Then
                    TxtPartsLantaiKu.Enabled = True
                Else
                    TxtPartsLantaiKu.Enabled = False
                End If
                LblPartsNo.Text = (nSr(MyRecReadA("PARTS_NO")))
                LblPartsNama.Text = (nSr(MyRecReadA("PARTS_NAMA")))
                LblPartsStk.Text = (nSr(MyRecReadA("PARTS_STOCK")))
                LblPartsPickup.Text = (nSr(MyRecReadA("PARTS_QYPESAN")))
                LblPartsActual.Text = Val(nSr(MyRecReadA("PARTS_STOCK"))) - Val(nSr(MyRecReadA("PARTS_QYPESAN")))
                TxtPartsAuditQty.Text = LblPartsActual.Text
                lblTempPartsAuditQty.Text = ""
                TxtPartsAuditNote.Text = ""
                LblPartsUserNma.Text = LblUserName.Text
                LblPartsUserTgl.Text = ""
                LblPartsStokTgl.Text = (nSr(MyRecReadA("mTGLSekarang")))
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function

    Function GetDataA_DetailPartsAudit(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnetSvcs" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        GetDataA_DetailPartsAudit = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_DetailPartsAudit = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                TxtPartsLantaiKu.Text = (nSr(MyRecReadA("PARTS_LOKASI")))
                If TxtPartsLantaiKu.Text = "NONE" Then
                    TxtPartsLantaiKu.Enabled = True
                Else
                    TxtPartsLantaiKu.Enabled = False
                End If
                LblPartsNo.Text = (nSr(MyRecReadA("PARTS_NO")))
                LblPartsNama.Text = (nSr(MyRecReadA("PARTS_NAMA")))
                LblPartsStk.Text = (nSr(MyRecReadA("PARTS_STOCK")))
                LblPartsPickup.Text = (nSr(MyRecReadA("PARTS_QYPESAN")))
                LblPartsActual.Text = Val(nSr(MyRecReadA("PARTS_STOCK"))) - Val(nSr(MyRecReadA("PARTS_QYPESAN")))
                TxtPartsAuditQty.Text = (nSr(MyRecReadA("AUDITPART_QTY")))
                lblTempPartsAuditQty.Text = (nSr(MyRecReadA("AUDITPART_QTY")))
                TxtPartsAuditNote.Text = (nSr(MyRecReadA("AUDITPART_CATATAN")))
                LblPartsUserNma.Text = (nSr(MyRecReadA("AUDITPART_USER")))
                LblPartsUserTgl.Text = (nSr(MyRecReadA("AUDITPART_TGL")))
                LblPartsStokTgl.Text = (nSr(MyRecReadA("mTGLSekarang")))
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function

    Protected Sub lvStockPart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvStockPart.SelectedIndexChanged
        '    Call clearInput()
        LblPartsNo.Text = (lvStockPart.DataKeys(lvStockPart.SelectedIndex).Value.ToString)

        If GetDataA_DetailPartsAudit("SELECT *,GETDATE() as mTGLSekarang FROM DATA_PARTS,TEMP_AUDITPART WHERE PARTS_NO = AUDITPART_NO AND PARTS_NO='" & LblPartsNo.Text & "' AND AUDITPART_USER='" & LblUserName.Text & "'", lblArea1.Text) <> 1 Then
            Call GetDataA_DetailParts("SELECT *,GETDATE() as mTGLSekarang  FROM DATA_PARTS WHERE PARTS_NO='" & LblPartsNo.Text & "'", lblArea1.Text)
        End If
        LVDataAdudit.DataBind()
        Call Tampil(-1, 0, -1, 0)
    End Sub
    Protected Sub ButtonTabelPartsGO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonTabelPartsGO.Click
        lvStockPart.DataBind()
        Call Tampil(0, -1, 0, -1)
    End Sub

    Protected Sub BtnAuditSimpan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAuditSimpan.Click
        Dim mdate As String = "GETDATE()"
        Call UpdateDatabase_Tabel("DELETE FROM TEMP_AUDITPART WHERE AUDITPART_NO='" & LblPartsNo.Text & "' AND AUDITPART_USER='" & LblUserName.Text & "'", lblArea1.Text, 0)
        Dim mTxtSQL As String = "INSERT INTO TEMP_AUDITPART (AUDITPART_NO,AUDITPART_TGL,AUDITPART_TGLSTOK,AUDITPART_USER,AUDITPART_STOK,AUDITPART_PICKUP,AUDITPART_QTY,AUDITPART_CATATAN) VALUES " & _
                                "('" & LblPartsNo.Text & "'," & mdate & "," & DtInSQL(CDate(LblPartsUserTgl.Text)) & ",'" & LblUserName.Text & "'," & Val(LblPartsStk.Text) & "," & Val(LblPartsPickup.Text) & "," & Val(TxtPartsAuditQty.Text) & ",'" & TxtPetik(TxtPartsAuditNote.Text) & "')"
        Call UpdateDatabase_Tabel(mTxtSQL, lblArea1.Text, 0)
        mdate = GetDataD_IsiField("SELECT MAX(AUDITPART_TGL) as IsiField FROM TEMP_AUDITPART WHERE AUDITPART_NO='" & LblPartsNo.Text & "'", lblArea1.Text, 0)
        If mdate <> "" Then
            mTxtSQL = "UPDATE DATA_PARTS SET PARTS_TGLAUDIT=" & DtInSQL(CDate(mdate)) & " "

            If TxtPartsLantaiKu.Enabled = True And TxtPartsLantaiKu.Text <> "NONE" Then
                mTxtSQL = ",PARTS_LOKASI='" & TxtPartsLantaiKu.Text & "' "
            End If

            mdate = GetDataD_IsiField("SELECT SUM(AUDITPART_QTY) as IsiField FROM TEMP_AUDITPART WHERE AUDITPART_NO='" & LblPartsNo.Text & "'", lblArea1.Text, 0)
            mTxtSQL = mTxtSQL & ",PARTS_QTYAUDIT=" & Val(mdate) & " WHERE PARTS_NO='" & LblPartsNo.Text & "'"

            Call UpdateDatabase_Tabel(mTxtSQL, lblArea1.Text, 0)
        End If

        LVDataAdudit.DataBind()
        Call Tampil(-1, 0, -1, 0)
    End Sub

    Protected Sub BtnAuditBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAuditBack.Click
        Call Tampil(0, -1, 0, -1)
    End Sub
End Class
