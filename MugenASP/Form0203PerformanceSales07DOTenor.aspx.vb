Imports System.Data
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

Partial Class Form0203PerformanceSales07DOTenor
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
            LblUserName.Text = ucase(x.ToString)
            Dim mFound As Byte = 0
            If Left(LblUserName.Text, 3) = "112" Or Left(LblUserName.Text, 3) = "128" Then
                mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYH,DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(SECURITYH_USER)=RTRIM(USER_NAMA) AND RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & Left(LblUserName.Text, 3) & "' AND SECURITYH_NOIDSALES='" & Right(LblUserName.Text, Len(LblUserName.Text) - 3) & "' AND USER_TIPE='WA' AND AKSES_MENU='0106'")
                If mFound = 1 Then
                    lblArea1.Text = Left(LblUserName.Text, 3)
                    lblArea2.Text = Left(LblUserName.Text, 3)
                End If
            Else
                mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0106'")
            End If


            Call DefinisTabelBBM()
            MultiView1Menu.ActiveViewIndex = 0
            If mFound = 1 Then
                Call Msg_err("", 0)

                DropDownListGroupTipe.Items.Clear()
                DropDownListGroupTipe.Items.Add(lblArea1.Text)
                If lblArea2.Text <> "" Then DropDownListGroupTipe.Items.Add(lblArea2.Text)

                DropDownListTxtBln.Items.Clear()
                DropDownListTxtBln.Items.Add("00")
                DropDownListTxtBln.Items.Add("01")
                DropDownListTxtBln.Items.Add("02")
                DropDownListTxtBln.Items.Add("03")
                DropDownListTxtBln.Items.Add("04")
                DropDownListTxtBln.Items.Add("05")
                DropDownListTxtBln.Items.Add("06")
                DropDownListTxtBln.Items.Add("07")
                DropDownListTxtBln.Items.Add("08")
                DropDownListTxtBln.Items.Add("09")
                DropDownListTxtBln.Items.Add("10")
                DropDownListTxtBln.Items.Add("11")
                DropDownListTxtBln.Items.Add("12")
                DropDownListTxtBln.Text = Format(Month(Now()), "0#")
                For mYear As Integer = Year(Now()) To (Year(Now()) - 10) Step -1
                    DropDownListTxtThn.Items.Add(mYear)
                Next
                DropDownListTxtThn.Text = Year(Now())
            Else
                MultiView1menu.ActiveViewIndex = -1
                Call Msg_err("TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI", 1)
            End If
        End If
    End Sub

    Protected Sub DefinisTabelBBM()
        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn(10) {New DataColumn("Temp_DOTTglDO"), New DataColumn("Temp_DOTNama1"), New DataColumn("Temp_DOTNama2"), New DataColumn("Temp_DOTPhone"), New DataColumn("Temp_DOTRangka"), _
                                                New DataColumn("Temp_DOTTipe"), New DataColumn("Temp_DOTDiskon"), New DataColumn("Temp_DOTLease"), New DataColumn("Temp_DOTTenor"), New DataColumn("Temp_DOTSales"), New DataColumn("Temp_DOTSPV")})
        ViewState("BBM") = dt
        Me.BindGridBBM()
    End Sub
    Protected Sub BindGridBBM()
        LvTabelBBM.DataSource = DirectCast(ViewState("BBM"), DataTable)
        LvTabelBBM.DataBind()
    End Sub


    Sub insertTabelBBM(ByVal Type As Byte, ByVal Temp_DOTTglDO As String, ByVal Temp_DOTNama1 As String, ByVal Temp_DOTNama2 As String, ByVal Temp_DOTPhone As String, ByVal Temp_DOTRangka As String, ByVal Temp_DOTTipe As String, ByVal Temp_DOTDiskon As String, ByVal Temp_DOTLease As String, ByVal Temp_DOTTenor As String, ByVal Temp_DOTSales As String, ByVal Temp_DOTSPV As String)
        Dim dt As DataTable = DirectCast(ViewState("BBM"), DataTable)
        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_DOTTglDO, Temp_DOTNama1, Temp_DOTNama2, Temp_DOTPhone, Temp_DOTRangka, Temp_DOTTipe, Temp_DOTDiskon, Temp_DOTLease, Temp_DOTTenor, Temp_DOTSales, Temp_DOTSPV)
        End If
        ViewState("BBM") = dt
        Me.BindGridBBM()
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
            mMm = IIf(mMm = "", "00", mmm)
            mSs = IIf(mSs = "", "00", mSs)
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

 
    Sub DOTenor(ByVal mServerku As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServerku
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
            "SELECT *," & _
            "(SELECT SALES_Nama FROM DATA_SALESMAN WHERE SALES_KODE=SPK_CDSALES) as mfldNamaSales," & _
            "(SELECT SALES_Nama FROM DATA_SALESMAN WHERE SALES_KODE=SPK_CDSSALES) as mfldNamaSPV " & _
            "FROM TRXN_SPK,DATA_TYPE,DATA_LEASE WHERE " & _
            "SPK_CDLEASE = LEASE_KODE And SPK_CDTYPE = TYPE_TYPE And "
        If DropDownListTxtBln.Text = "00" Then
            mSqlCommadstring = mSqlCommadstring & "Year(SPK_TGLDO) = " & Val(DropDownListTxtThn.Text) & ""
        Else
            mSqlCommadstring = mSqlCommadstring & "Year(SPK_TGLDO) = " & Val(DropDownListTxtThn.Text) & " And Month(SPK_TGLDO) = " & Val(DropDownListTxtBln.Text) & " "
        End If
        If YATermasuk.Checked = False Then
            mSqlCommadstring = mSqlCommadstring & " And NOT(SPK_NAMA1 LIKE '%HONDA%') "
        End If
        mSqlCommadstring = mSqlCommadstring & " ORDER BY YEAR(SPK_TGLDO),MONTH(SPK_TGLDO),SPK_CDSSALES,SPK_CDSALES"

        insertTabelBBM(0, "", "", "", "", "", "", "", "", "", "", "")


        Call Msg_err("", "1")
        cnn = New OleDbConnection(strconn)
        Try
            LblProses.Text = "---> Proses Baca data     "
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()

                    insertTabelBBM(1, nSr(MyRecReadA("SPK_TGLDO")), nSr(MyRecReadA("SPK_NAMA1")), nSr(MyRecReadA("SPK_NAMA2")), _
                                      "'" & nSr(MyRecReadA("SPK_FHP")), nSr(MyRecReadA("SPK_NORANGKA")), nSr(MyRecReadA("TYPE_NAMA")), _
                                      nSr(MyRecReadA("SPK_POTONGAN")), _
                                      nSr(MyRecReadA("LEASE_NAMA")), nSr(MyRecReadA("SPK_HRGASR")), nSr(MyRecReadA("mfldNamaSales")), nSr(MyRecReadA("SPK_CDSSALES")))

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

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call DOTenor(DropDownListGroupTipe.Text)
    End Sub

    Protected Sub BtnCetak_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCetak.Click
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=DOTENOR.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        LvTabelBBM.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub

End Class
