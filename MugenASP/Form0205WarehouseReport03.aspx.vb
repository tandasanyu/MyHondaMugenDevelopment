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

Partial Class Form0205WarehouseReport03
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


            Call DefinisTabelBBM()
            MultiView1Menu.ActiveViewIndex = 0
            If mFound = 1 Then
                Call Msg_err("", 0)

                DropDownListGroupLokasi.Items.Clear()
                DropDownListGroupLokasi.Items.Add(lblArea1.Text)
                If lblArea2.Text <> "" Then DropDownListGroupLokasi.Items.Add(lblArea2.Text)

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
    Protected Sub DefinisTabelBBM()
        Dim dt As New DataTable()

        dt.Columns.AddRange(New DataColumn(12) {New DataColumn("Temp_PsgAksesorisNoWo"), New DataColumn("Temp_PsgAksesorisNmAs"), _
                                               New DataColumn("Temp_PsgAksesorisTipe"), New DataColumn("Temp_PsgAksesorisRngk"), _
                                               New DataColumn("Temp_PsgAksesorisSupl"), New DataColumn("Temp_PsgAksesorisTgWO"), New DataColumn("Temp_PsgAksesorisTgEm"), _
                                               New DataColumn("Temp_PsgAksesorisTgPg"), New DataColumn("Temp_PsgAksesorisInPg"), _
                                               New DataColumn("Temp_PsgAksesorisTgKm"), New DataColumn("Temp_PsgAksesorisTgTr"), _
                                               New DataColumn("Temp_PsgAksesorisDler"), New DataColumn("Temp_PsgAksesorisNoSP")})
        ViewState("BBM") = dt
        Me.BindGridBBM()
    End Sub

    Protected Sub BindGridBBM()
        LvTabelBBM.DataSource = DirectCast(ViewState("BBM"), DataTable)
        LvTabelBBM.DataBind()
    End Sub

    Sub insertTabelBBM(ByVal Type As Byte, ByVal Temp_PsgAksesorisNoWo As String, ByVal Temp_PsgAksesorisNmAs As String, ByVal Temp_PsgAksesorisTipe As String, ByVal Temp_PsgAksesorisRngk As String, ByVal Temp_PsgAksesorisSupl As String, ByVal Temp_PsgAksesorisTgWO As String, ByVal Temp_PsgAksesorisTgEm As String, ByVal Temp_PsgAksesorisTgPg As String, ByVal Temp_PsgAksesorisInPg As String, ByVal Temp_PsgAksesorisTgKm As String, ByVal Temp_PsgAksesorisTgTr As String, ByVal Temp_PsgAksesorisDler As String, ByVal Temp_PsgAksesorisNoSP As String)
        Dim dt As DataTable = DirectCast(ViewState("BBM"), DataTable)
        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_PsgAksesorisNoWo, Temp_PsgAksesorisNmAs, Temp_PsgAksesorisTipe, Temp_PsgAksesorisRngk, Temp_PsgAksesorisSupl, Temp_PsgAksesorisTgWO, Temp_PsgAksesorisTgEm, Temp_PsgAksesorisTgPg, Temp_PsgAksesorisInPg, Temp_PsgAksesorisTgKm, Temp_PsgAksesorisTgTr, Temp_PsgAksesorisDler, Temp_PsgAksesorisNoSP)
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
            mMm = IIf(mMm = "", "00", mMm)
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


    Sub Aksesoris_Berdasarakan_TglKirim(ByVal mQuery As String)
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                     "SELECT * " & _
                     "FROM TRXN_STOCKAKSESORIS,TRXN_STOCK,DATA_STANDARD,DATA_TYPE,DATA_SUPLIER,DATA_LOKASI WHERE " & _
                     "STOCKA_NORANGKA=STOCK_NORANGKA AND STOCK_CDTYPE=TYPE_TYPE AND STOCK_CDLOKASI=LOKASI_KODE AND " & _
                     "STOCKA_KDASS=STANDARD_KODE AND STANDARD_Kelompok='A' AND " & _
                     "STOCKA_KDSUPLIER= SUPLIER_KODE AND " & mQuery
        insertTabelBBM(0, "", "", "", "", "", "", "", "", "", "", "", "", "")
        Call Msg_err("", "1")
        cnn = New OleDbConnection(strconn)
        Try
            LblProses.Text = "---> Proses Baca data     "
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    'insertTabelBBM(1, nSr(MyRecReadA("STOCKA_NOWO")), nSr(MyRecReadA("STANDARD_NAMA")), nSr(MyRecReadA("TYPE_NAMA")), _
                    '                  nSr(MyRecReadA("STOCK_NORANGKA")), nSr(MyRecReadA("SUPLIER_NAMA")), DtFr(MyRecReadA("STOCKA_TGLWO")), "EMAIL", _
                    '                  DtFr(MyRecReadA("STOCKA_TGLPSG")), DtFr(MyRecReadA("STOCKA_TGLPSGI")), DtFr(MyRecReadA("STOCK_TGLKIRIM")), DtFr(MyRecReadA("STOCK_TGLTERIMA")), _
                    '                  nSr(MyRecReadA("LOKASI_KODEDLR")), "NO SPK")
                    insertTabelBBM(1, nSr(MyRecReadA("STOCKA_NOWO")), nSr(MyRecReadA("STANDARD_NAMA")), nSr(MyRecReadA("TYPE_NAMA")), _
                                      nSr(MyRecReadA("STOCK_NORANGKA")), nSr(MyRecReadA("SUPLIER_NAMA")), nSr(MyRecReadA("STOCKA_TGLWO")), "EMAIL", _
                                      nSr(MyRecReadA("STOCKA_TGLPSG")), nSr(MyRecReadA("STOCKA_TGLPSGI")), nSr(MyRecReadA("STOCK_TGLKIRIM")), nSr(MyRecReadA("STOCK_TGLTERIMA")), _
                                      nSr(MyRecReadA("LOKASI_KODEDLR")), "NO SPK")
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


    Sub DataAksesoris(ByVal mDealer As String, ByVal mQuery As String)
        Dim mpServer As String = "MyConnCloudDnet" & mDealer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT " & _
                                         "OPT_NOWO,OPT_NOSPK,STANDARD_NAMA,OPT_NORANGKA,SUPLIER_NAMA,OPTH_TGLWO,OPTH_TglSendWO,OPTH_TGLKERJABUKTI,OPTH_TGLINPUTBUKTI," & _
                                         "(SELECT TYPE_NAMA FROM TRXN_STOCK,DATA_TYPE WHERE STOCK_CDTYPE=TYPE_TYPE AND STOCK_NORANGKA=OPT_NORANGKA AND ISNULL(OPT_NORANGKA,'')<>'') as mfTYPE_NAMA," & _
                                         "(SELECT STOCK_KirimTGL  FROM TRXN_STOCK WHERE STOCK_NORANGKA=OPT_NORANGKA AND ISNULL(OPT_NORANGKA,'')<>'') as mfSTOCK_TGLKIRIM," & _
                                         "(SELECT STOCK_TGLTERIMA FROM TRXN_STOCK WHERE STOCK_NORANGKA=OPT_NORANGKA AND ISNULL(OPT_NORANGKA,'')<>'') as mfSTOCK_TGLTERIMA " & _
                                         "FROM TRXN_OPT,TRXN_OPTH,DATA_STANDARD,DATA_SUPLIER WHERE OPTH_CdSuplier=SUPLIER_Kode AND OPT_NOWO=OPTH_NOWO AND OPT_CdAssesoris=STANDARD_KODE AND STANDARD_Kelompok='A'" & IIf(mQuery = "", "", " AND ") & mQuery
        Call Msg_err("", 0)
        insertTabelBBM(0, "", "", "", "", "", "", "", "", "", "", "", "", "")

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    insertTabelBBM(1, nSr(MyRecReadA("OPT_NOWO")), nSr(MyRecReadA("STANDARD_NAMA")), nSr(MyRecReadA("mfTYPE_NAMA")), _
                                      nSr(MyRecReadA("OPT_NORANGKA")), nSr(MyRecReadA("SUPLIER_NAMA")), DtFr(MyRecReadA("OPTH_TGLWO")), DtFr(MyRecReadA("OPTH_TglSendWO")), _
                                      DtFr(MyRecReadA("OPTH_TGLKERJABUKTI")), DtFr(MyRecReadA("OPTH_TGLINPUTBUKTI")), DtFr(MyRecReadA("mfSTOCK_TGLKIRIM")), DtFr(MyRecReadA("mfSTOCK_TGLTERIMA")), _
                                      mDealer, nSr(MyRecReadA("OPT_NOSPK")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Sub


    Function DtFr(ByRef mNilai As Object) As String
        On Error GoTo ErrHand
        DtFr = ""
        If IsDate(mNilai) Then
            DtFr = Format(CDate(mNilai), "dd-MM-yy")
        End If
ErrHand:
    End Function

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtTglStart.Text <> "" And txtTglEnd.Text <> "" Then
            txtTglStart.Text = InputDT("", "", "", "00", "00", "00", CDate(txtTglStart.Text))
            txtTglEnd.Text = InputDT("", "", "", "23", "59", "00", CDate(txtTglEnd.Text))

            If DropDownListGroupCari.Text = "Tanggal Kirim" Then
                Call Aksesoris_Berdasarakan_TglKirim("datediff(day," & DtInSQL(CDate(txtTglStart.Text)) & ",STOCK_TGLKIRIM) >= 0 and datediff(day,STOCK_TGLKIRIM," & DtInSQL(CDate(txtTglEnd.Text)) & ") >= 0")
            Else
                Call DataAksesoris(DropDownListGroupLokasi.Text, "datediff(day," & DtInSQL(CDate(txtTglStart.Text)) & ",OPTH_TglSendWO) >= 0 and datediff(day,OPTH_TglSendWO," & DtInSQL(CDate(txtTglEnd.Text)) & ") >= 0")
            End If

        End If
    End Sub

    Protected Sub BtnCetak_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCetak.Click
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=GESEKRANGKA.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        LvTabelBBM.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub

End Class
