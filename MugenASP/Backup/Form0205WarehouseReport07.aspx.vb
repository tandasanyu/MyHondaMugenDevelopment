﻿Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration

'1. Sales
'2. Insentive
'3.piutang
'4.per leasing
'5.surat-surat
'6.Uang muka
'7.SPK
'8.Faktur jadi

Partial Class Form0205WarehouseReport07
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader
    Public MyRecReadD As OleDbDataReader
    Public MySTRsql1 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If
        lblAkses.Visible = False
        If LblUserName.Text = "" Then
            Dim x As String
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = UCase(x.ToString)
            Dim mFound As Byte = 0
            If Left(LblUserName.Text, 3) = "112" Or Left(LblUserName.Text, 3) = "128" Then
                mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYH,DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(SECURITYH_USER)=RTRIM(USER_NAMA) AND RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & Left(LblUserName.Text, 3) & "' AND SECURITYH_NOIDSALES='" & Right(LblUserName.Text, Len(LblUserName.Text) - 3) & "' AND USER_TIPE='WA' AND AKSES_MENU='0108'")
                If mFound = 1 Then
                    lblArea1.Text = Left(LblUserName.Text, 3)
                    lblArea2.Text = Left(LblUserName.Text, 3)
                End If
            Else
                mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0108'")
            End If
            Button2.Visible = False : BtnCetak.Visible = False
            Button4.Visible = False : Button5.Visible = False


            MultiView1Menu.ActiveViewIndex = 0
            If mFound = 1 Then
                MultiVStock.ActiveViewIndex = -1
                Call Msg_err("", 0)
            Else
                MultiView1menu.ActiveViewIndex = -1
                Call Msg_err("TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI", 1)
            End If
        End If
    End Sub

    






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

    Function UpdateDatabase_Tabel(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
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
            Call Msg_err(ex.Message, 1)
        End Try
    End Function
    Function GetDataD_IsiField(ByVal mSqlCommadstring As String, ByVal mpServer As String) As String
        mpServer = "MyConnCloudDnet" & mpServer
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
            Call Msg_err(ex.Message, 1)
        End Try
    End Function
    Function GetDataD_00NoFound01Found(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
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
            Call Msg_err(ex.Message, 1)
        End Try
    End Function

    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function
    Function nLg(ByRef nilai As Object) As Double
        On Error GoTo ErrHand
        nLg = 0
        If IsNumeric(nilai) Then nLg = Val(nilai) '10
ErrHand:
    End Function
    Function TxtPetik(ByRef MyText As Object) As String
        Dim mPosStart As Byte
        TxtPetik = nSr(MyText)
        mPosStart = 1
        While InStr(mPosStart, TxtPetik, "'") <> 0
            mPosStart = InStr(mPosStart, TxtPetik, "'")
            TxtPetik = Mid(TxtPetik, 1, mPosStart) & "'" & "" & Mid(TxtPetik, mPosStart + 1, Len(TxtPetik) - mPosStart)
            mPosStart = mPosStart + 2
        End While
    End Function
    Function DtInSQL(ByRef nilai As Object) As String
        DtInSQL = "NULL"
        If Not IsDBNull(nilai) Then
            DtInSQL = "'" & Format(nilai, "yyyy-MM-dd HH:mm:ss") & "'"
        End If
    End Function
    Function DtInFormat(ByRef nilai As Object, ByRef mFrmt As Object) As String
        DtInFormat = "''"
        If Not IsDBNull(nilai) Then
            DtInFormat = "'" & Format(nilai, mFrmt) & "'"
        End If
    End Function
    Function nDb(ByRef nilai As Object) As Double
        nDb = 0
        If Not IsDBNull(nilai) Then nDb = Val(Format(nilai, "###############.#0")) '13
    End Function
    Function InputDT(ByVal mYr As String, ByVal mMt As String, ByVal mDy As String, ByVal mHh As String, ByVal mMm As String, ByVal mSs As String, ByVal mDt As String) As Date
        Try

            If mDt <> "" And mYr = "" Then mYr = CStr(Year(CDate(mDt)))
            If mDt <> "" And mMt = "" Then mMt = CStr(Month(CDate(mDt)))
            If mDt <> "" And mDy = "" Then mDy = CStr(Microsoft.VisualBasic.Day(CDate(mDt)))
            If mDt <> "" And mHh = "" Then mHh = CStr(Hour(CDate(mDt)))
            If mDt <> "" And mMm = "" Then mMm = CStr(Minute(CDate(mDt)))
            If mDt <> "" And mSs = "" Then mSs = CStr(Second(CDate(mDt)))
            mHh = IIf(mHh = "", "00", mHh)
            mMm = IIf(mMm = "", "00", mHh)
            mSs = IIf(mSs = "", "00", mHh)
            InputDT = New DateTime(mYr, mMt, mDy, mHh, mMm, mSs)
        Catch ex As Exception

        End Try
    End Function
    Sub Msg_err(ByVal mTest As String, ByVal m1Show2NoShow As Byte)
        lblMsgBox.Text = mTest
        If mTest = "" Then
            MultiViewError.ActiveViewIndex = -1
        Else
            MultiViewError.ActiveViewIndex = 0
        End If

        If mTest <> "" And m1Show2NoShow = 1 Then
            Response.Write("<script>alert('" & mTest & "')</script>")
        End If
    End Sub


    Sub StockUnit(ByVal mLokasi As String)
        Dim mpServer As String = "MyConnCloudDnet"
        Dim MyFilter As String = ""
        If mLokasi = "128" Then
            MyFilter = " AND STOCK_CdLokasi <> 'G001'"
        End If

        Dim mSqlCommadstring As String = _
                    "INSERT INTO TEMP_STOCKWAREHOSE " & _
                    "SELECT STOCK_NORANGKA " & _
                    "FROM TRXN_STOCK LEFT OUTER JOIN TRXN_SPK ON TRXN_STOCK.STOCK_NoRangka = TRXN_SPK.SPK_NoRangka WHERE " & _
                    "NOT(STOCK_NoRangka='' OR STOCK_NoRangka='BLANK') AND  (SPK_NODO IS NULL OR SPK_NODO='') AND (SPK_NORANGKA IS NULL OR SPK_NORANGKA='') AND " & _
                    "(SELECT COUNT(DBNOTAINT_NORANGKA) as mJmlDBNOTA FROM TRXN_DBNOTAINTERNAL WHERE DBNOTAINT_NORANGKA = STOCK_NoRangka)=0  " & MyFilter & _
                    "ORDER BY STOCK_CDTYPE,STOCK_CDWARNA,STOCK_TglDOImoraHpm,STOCK_NORANGKA"
        Call UpdateDatabase_Tabel(mSqlCommadstring, mLokasi)
    End Sub

    Sub StockUnitBelumKirimSudahDO(ByVal mLokasi As String)
        Dim mpServer As String = "MyConnCloudDnet"
        Dim MyFilter As String = ""
        If mLokasi = "128" Then
            MyFilter = " AND STOCK_CdLokasi <> 'G001'"
        End If

        Dim mSqlCommadstring As String = _
                    "INSERT INTO TEMP_STOCKWAREHOSE " & _
                    "SELECT STOCK_NORANGKA " & _
                    "FROM TRXN_STOCK LEFT OUTER JOIN TRXN_SPK ON TRXN_STOCK.STOCK_NoRangka = TRXN_SPK.SPK_NoRangka WHERE " & _
                    "NOT(STOCK_NoRangka='' OR STOCK_NoRangka='BLANK') AND  (SPK_NODO IS NULL OR SPK_NODO='') AND (SPK_NORANGKA IS NULL OR SPK_NORANGKA='') AND " & _
                    "(SELECT COUNT(DBNOTAINT_NORANGKA) as mJmlDBNOTA FROM TRXN_DBNOTAINTERNAL WHERE DBNOTAINT_NORANGKA = STOCK_NoRangka)=0  " & MyFilter & _
                    "ORDER BY STOCK_CDTYPE,STOCK_CDWARNA,STOCK_TglDOImoraHpm,STOCK_NORANGKA"
        Call UpdateDatabase_Tabel(mSqlCommadstring, mLokasi)
    End Sub


    Sub StockUnitBelumSPJ(ByVal mLokasi As String)
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim MyFilter As String = ""
        If mLokasi = "128" Then
            MyFilter = " AND STOCK_CdLokasi <> 'G001'"
        End If

        Dim mSqlCommadstring As String = _
                    "SELECT GETDATE() as mDateNow," & _
                    "STOCKWAREHOSE_NORANGKA " & _
                    "FROM TRXN_STOCK LEFT OUTER JOIN TRXN_SPK ON TRXN_STOCK.STOCK_NoRangka = TRXN_SPK.SPK_NoRangka WHERE " & _
                    "NOT(STOCK_NoRangka='' OR STOCK_NoRangka='BLANK') AND  NOT(SPK_NODO IS NULL OR SPK_NODO='') AND NOT(SPK_NORANGKA IS NULL OR SPK_NORANGKA='') AND " & _
                    "STOCK " & MyFilter & _
                    "ORDER BY STOCK_CDTYPE,STOCK_CDWARNA,STOCK_TglDOImoraHpm,STOCK_NORANGKA"

        Call Msg_err("", "1")
        cnn = New OleDbConnection(strconn)
        Try
            LblProses.Text = "---> Proses Baca data     "
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mSqlCommadstring = "INSERT INTO TRXN_STOCK () VALUES ('" & nSr(MyRecReadA("STOCK_NORANGKA")) & "')"
                    Call UpdateDatabase_Tabel(mSqlCommadstring, mLokasi)
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
            LblProses.Text = "---> Proses Baca data Selesai     "
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, "1")
        End Try
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call UpdateDatabase_Tabel("DELETE FROM TEMP_STOCKWAREHOSE", "112")
        Call UpdateDatabase_Tabel("DELETE FROM TEMP_STOCKWAREHOSE", "128")
        Call StockUnit("112")
        Call StockUnit("128")
        Call StockUnitBelumKirimSudahDO("112")
        Call StockUnitBelumKirimSudahDO("128")

        Button2.Visible = True : BtnCetak.Visible = True
        Button4.Visible = True : Button5.Visible = True
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        MultiVStock.ActiveViewIndex = 0

    End Sub
    Protected Sub BtnCetak_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCetak.Click
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=STOCKPSM.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        LVSTOCKPSM.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        MultiVStock.ActiveViewIndex = 1

    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=STOCKPURI.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        LVSTOCKPURI.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub
End Class
