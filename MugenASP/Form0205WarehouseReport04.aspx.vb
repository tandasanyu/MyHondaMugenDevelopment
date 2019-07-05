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

Partial Class Form0205WarehouseReport04
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


            Call DefinisTabelSPK()
            Call DefinisTabelASS()
            MultiView1menu.ActiveViewIndex = 0
            If mFound = 1 Then
                Call Msg_err("", 0)

                DropDownListGroupTipe.Items.Clear()
                DropDownListGroupTipe.Items.Add(lblArea1.Text)
                If lblArea2.Text <> "" Then DropDownListGroupTipe.Items.Add(lblArea2.Text)

                [Calendar1].Visible = False
                [Calendar2].Visible = False
            Else
                MultiView1menu.ActiveViewIndex = -1
                Call Msg_err("TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI", 1)
            End If
        End If
    End Sub

    Protected Sub BtnCal1Start_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCal1Start.Click
        [Calendar1].Visible = IIf([Calendar1].Visible = True, False, True)
    End Sub
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar1].SelectionChanged, Calendar1.SelectionChanged
        txtTglStart.Text = [Calendar1].SelectedDate.ToString
        [Calendar1].Visible = False
    End Sub
    Protected Sub BtnCal1End_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCal1End.Click
        [Calendar2].Visible = IIf([Calendar2].Visible = True, False, True)
    End Sub
    Protected Sub Calendar2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar2].SelectionChanged, Calendar2.SelectionChanged
        txtTglEnd.Text = [Calendar2].SelectedDate.ToString
        [Calendar2].Visible = False
    End Sub
    Protected Sub DefinisTabelSPK()
        Dim dt As New DataTable()

        dt.Columns.AddRange(New DataColumn(10) {New DataColumn("Temp_DOSpk"), New DataColumn("Temp_DODlr"), _
                                               New DataColumn("Temp_DOTgl"), New DataColumn("Temp_DOSPJ"), _
                                               New DataColumn("Temp_DOTrm"), New DataColumn("Temp_DONam"), _
                                               New DataColumn("Temp_DOSls"), New DataColumn("Temp_DOSpv"), _
                                               New DataColumn("Temp_DOTip"), New DataColumn("Temp_DOWar"), _
                                               New DataColumn("Temp_DORgk")})




        ViewState("SPK") = dt
        Me.BindGridSPK()
    End Sub

    Protected Sub BindGridSPK()
        LvTabelSPK.DataSource = DirectCast(ViewState("SPK"), DataTable)
        LvTabelSPK.DataBind()
    End Sub

    Sub insertTabelSPK(ByVal Type As Byte, ByVal Temp_DORgk As String, ByVal Temp_DOSpk As String, ByVal Temp_DODlr As String, ByVal Temp_DOTgl As String, ByVal Temp_DOSPJ As String, ByVal Temp_DOTrm As String, ByVal Temp_DONam As String, ByVal Temp_DOSls As String, ByVal Temp_DOSpv As String, ByVal Temp_DOTip As String, ByVal Temp_DOWar As String)
        Dim dt As DataTable = DirectCast(ViewState("SPK"), DataTable)
        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_DOSpk, Temp_DODlr, Temp_DOTgl, Temp_DOSPJ, Temp_DOTrm, Temp_DONam, Temp_DOSls, Temp_DOSpv, Temp_DOTip, Temp_DOWar, Temp_DORgk)
        End If
        ViewState("SPK") = dt
        Me.BindGridSPK()
    End Sub


    Protected Sub DefinisTabelASS()
        Dim dt As New DataTable()

        dt.Columns.AddRange(New DataColumn(6) {New DataColumn("Temp_WOSpk"), New DataColumn("Temp_WODlr"), _
                                               New DataColumn("Temp_WONom"), New DataColumn("Temp_WONam"), _
                                               New DataColumn("Temp_WOSls"), New DataColumn("Temp_WOSpv"), _
                                               New DataColumn("Temp_WOSup")})
        ViewState("ASS") = dt
        Me.BindGridASS()
    End Sub

    Protected Sub BindGridASS()
        LvTabelASS.DataSource = DirectCast(ViewState("ASS"), DataTable)
        LvTabelASS.DataBind()
    End Sub

    Sub insertTabelASS(ByVal Type As Byte, ByVal Temp_WOSpk As String, ByVal Temp_WODlr As String, ByVal Temp_WONom As String, ByVal Temp_WONam As String, ByVal Temp_WOSls As String, ByVal Temp_WOSpv As String, ByVal Temp_WOSup As String)
        Dim dt As DataTable = DirectCast(ViewState("SPK"), DataTable)
        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_WOSpk, Temp_WODlr, Temp_WONom, Temp_WONam, Temp_WOSls, Temp_WOSpv, Temp_WOSup)
        End If
        ViewState("ASS") = dt
        Me.BindGridASS()
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

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtTglStart.Text <> "" And txtTglEnd.Text <> "" Then
            txtTglStart.Text = InputDT("", "", "", "00", "00", "00", CDate(txtTglStart.Text))
            txtTglEnd.Text = InputDT("", "", "", "00", "00", "00", CDate(txtTglEnd.Text))
            Call DOSPK("datediff(day," & DtInSQL(CDate(txtTglStart.Text)) & ",SPK_TGLDO) >= 0 and datediff(day,SPK_TGLDO," & DtInSQL(CDate(txtTglEnd.Text)) & ") >= 0")
        End If
        MultiView1.ActiveViewIndex = 0
    End Sub
    Sub DOSPK(ByVal mQuery As String)
        Dim mpServer As String = "MyConnCloudDnet" & DropDownListGroupTipe.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                     "SELECT * " & _
                     "FROM TRXN_SPK,TRXN_STOCK,DATA_TYPE,DATA_WARNA,DATA_SALESMAN WHERE " & _
                     "SPK_NORANGKA=STOCK_NORANGKA AND SPK_CDTYPE=TYPE_TYPE AND SPK_CDWARNA=WARNA_KODE AND " & _
                     "SPK_CDSALES=SALES_KODE AND " & mQuery & " ORDER BY SPK_TGLDO"
        insertTabelSPK(0, "", "", "", "", "", "", "", "", "", "", "")
        Call Msg_err("", "1")
        cnn = New OleDbConnection(strconn)
        Try
            LblProses.Text = "---> Proses Baca data     "
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    insertTabelSPK(1, nSr(MyRecReadA("SPK_NORANGKA")), nSr(MyRecReadA("SPK_NO")), DropDownListGroupTipe.Text, nSr(MyRecReadA("SPK_TGLDO")), nSr(MyRecReadA("SPK_MOHONKIRIM")), nSr(MyRecReadA("STOCK_KirimTglTerima")), _
                                      nSr(MyRecReadA("SPK_NAMA1")), nSr(MyRecReadA("SALES_NAMA")), nSr(MyRecReadA("SPK_CDSSALES")), _
                                      nSr(MyRecReadA("TYPE_NAMA")), nSr(MyRecReadA("WARNA_INT")))
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


    Sub ASSSPK(ByVal mSPK As String, ByVal mSLS As String, ByVal mSPV As String)
        Dim mpServer As String = "MyConnCloudDnet" & DropDownListGroupTipe.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                     "SELECT * ," & _
                     "(SELECT SUPLIER_Nama  FROM TRXN_OPTH,DATA_SUPLIER WHERE OPTH_Cdsuplier=Suplier_kode and opth_nowo=opt_nowo) as nmSuplier " & _
                     "FROM TRXN_OPT,DATA_STANDARD  WHERE  " & _
                     "OPT_CDASSESORIS=STANDARD_KODE AND STANDARD_KELOMPOK='A' AND OPT_NOSPK='" & mSPK & "'"
        insertTabelASS(0, "", "", "", "", "", "", "")
        Call Msg_err("", "1")
        cnn = New OleDbConnection(strconn)
        Try
            LblProses.Text = "---> Proses Baca data     "
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    insertTabelASS(1, mSPK, DropDownListGroupTipe.Text, nSr(MyRecReadA("OPT_NOWO")), _
                                      nSr(MyRecReadA("STANDARD_NAMA")), mSLS, mSPV, nSr(MyRecReadA("nmSuplier")))
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


    Protected Sub BtnCetak_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCetak.Click
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=GESEKRANGKA.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        LvTabelSPK.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        MultiView1.ActiveViewIndex = 0

    End Sub
    Sub TblDetailStockView_SelectedIndexChanging(ByVal sender As Object, ByVal e As ListViewSelectEventArgs)
        Dim mErrorAda As String = ""
        Dim mDlr As String
        Dim mSPK As String
        Dim mSPV As String
        Dim mSLS As String

        Dim item As ListViewItem = CType(LvTabelSPK.Items(e.NewSelectedIndex), ListViewItem)
        Dim mKodeTipe As Label = CType(item.FindControl("Lbl_DODlr"), Label)
        mDlr = nSr(mKodeTipe.Text)

        mKodeTipe = CType(item.FindControl("lbl_DOSpk"), Label)
        mSPK = nSr(mKodeTipe.Text)

        mKodeTipe = CType(item.FindControl("lbl_DOSls"), Label)
        mSLS = nSr(mKodeTipe.Text)

        mKodeTipe = CType(item.FindControl("lbl_DOSpv"), Label)
        mSPV = nSr(mKodeTipe.Text)

        MultiView1.ActiveViewIndex = 1
        Call ASSSPK(mSPK, mSLS, mSPV)
    End Sub
    Protected Sub TblDetailStockView_PagePropertiesChanging(ByVal sender As Object, ByVal e As PagePropertiesChangingEventArgs)
        ' Clears the selection.
        LvTabelSPK.SelectedIndex = -1
    End Sub
End Class
