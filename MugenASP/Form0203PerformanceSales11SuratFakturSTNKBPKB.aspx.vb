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

Partial Class Form0203PerformanceSales11SuratFakturSTNKBPKB
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader
    Public MyRecReadB As OleDbDataReader
    Public MyRecReadD As OleDbDataReader
    Public MySTRsql1 As String

    Dim MyIsiNOHP As String = ""
    Dim MyIsiNOPOL As String = ""
    Dim MyIsiNama As String = ""
    Dim MyIsiNOSPK As String = ""
    Dim MyIsiSALES As String = ""
    Dim MyIsiSPV As String = ""
    Dim MyIsiTGlJtp As String = ""


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

                [Calendar1].Visible = False
                [Calendar2].Visible = False

                txtTglEnd.Text = Now()
                txtTglStart.Text = DateAdd(DateInterval.Day, -2, Now())

            Else
                MultiView1Menu.ActiveViewIndex = -1
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
        dt.Columns.AddRange(New DataColumn(9) {New DataColumn("Temp_JUD"), New DataColumn("Temp_SPK"), New DataColumn("Temp_NAM"), New DataColumn("Temp_SAL"), New DataColumn("Temp_SPV"), _
                                               New DataColumn("Temp_NOM"), New DataColumn("Temp_TGJ"), New DataColumn("Temp_TGI"), New DataColumn("Temp_PIU"), New DataColumn("Temp_KET")})
        ViewState("BBM") = dt


        Me.BindGridBBM()
    End Sub
    Protected Sub BindGridBBM()
        LvTabelBBM.DataSource = DirectCast(ViewState("BBM"), DataTable)
        LvTabelBBM.DataBind()
    End Sub


    Sub insertTabelBBM(ByVal Type As Byte, ByVal Temp_JUD As String, ByVal Temp_SPK As String, ByVal Temp_NAM As String, ByVal Temp_SAL As String, ByVal Temp_SPV As String, ByVal Temp_NOM As String, ByVal Temp_TGJ As String, ByVal Temp_TGI As String, ByVal Temp_PIU As String, ByVal Temp_KET As String)
        Dim dt As DataTable = DirectCast(ViewState("BBM"), DataTable)
        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_JUD, Temp_SPK, Temp_NAM, Temp_SAL, Temp_SPV, Temp_NOM, Temp_TGJ, Temp_TGI, Temp_PIU, Temp_KET)
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

    Sub AmbilData(ByVal Pilihan As Byte, ByVal mQuery As String, ByVal mOrderby As String)
        insertTabelBBM(0, "", "", "", "", "", "", "", "", "", "")
        LblProses.Text = "---> Proses Baca data................"
        Call Surat_SuratJadi(lblArea1.Text, Pilihan, mQuery, mOrderby)
        LblProses.Text = "---> Proses Baca data Selesai........"
    End Sub


    Sub Surat_SuratJadi(ByVal mServerku As String, ByVal mTipe As Byte, ByVal mfQuery As String, ByVal mfOrder As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServerku
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mPiutangU As Double
        Dim mPiutangA As Double
        Dim mSqlCommadstring As String = _
        "SELECT " & _
        "SURAT_NOFAK, SURAT_TGLFAK, SURAT_TGLFAKI, SURAT_NOPOL, SURAT_JTPSTNK, SURAT_TGLSTNK, SURAT_BPKB, SURAT_BPKBTRMSPL, SURAT_TGLBPKB," & _
        "SPK_CDSALES, SPK_CDSSALES, SPK_NO, SPK_Nama1,SPK_Piutang,SPK_Potongan,SPK_HrgASS, " & _
        "(SELECT SUM(ARTRAN_JUMLAH) FROM TRXN_ARTRAN WHERE ARTRAN_NOSPK = SPK_NO AND (ARTRAN_NOWO='' OR (ARTRAN_NOWO IS NULL))) as mJumlBayarUnit,  " & _
        "(SELECT SUM(ARTRAN_JUMLAH) FROM TRXN_ARTRAN WHERE ARTRAN_NOSPK = SPK_NO AND NOT(ARTRAN_NOWO='' OR (ARTRAN_NOWO IS NULL))) as mJumlBayarAss  " & _
        "FROM TRXN_SURAT,TRXN_SPK where SURAT_SPK=SPK_NO  AND " & mfQuery & " ORDER BY " & mfOrder & " DESC"


        Call Msg_err("", "1")
        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read
                    mPiutangU = nDb(MyRecReadA("SPK_Piutang")) - nDb(MyRecReadA("SPK_Potongan")) - nDb(MyRecReadA("mJumlBayarUnit"))
                    mPiutangA = nDb(MyRecReadA("SPK_HrgASS")) - nDb(MyRecReadA("mJumlBayarass"))

                    If mTipe = 1 Then
                        insertTabelBBM(1, "FAKTUR JADI", nSr(MyRecReadA("SPK_NO")), nSr(MyRecReadA("SPK_NAMA1")), _
                                          nSr(MyRecReadA("SPK_CDSALES")), nSr(MyRecReadA("SPK_CDSSALES")), _
                                          nSr(MyRecReadA("SURAT_NOFAK")), nSr(MyRecReadA("SURAT_TGLFAK")), nSr(MyRecReadA("SURAT_TGLFAKI")), _
                                          mPiutangU + mPiutangA, "")
                    ElseIf mTipe = 2 Then
                        insertTabelBBM(1, "STNK JADI", nSr(MyRecReadA("SPK_NO")), nSr(MyRecReadA("SPK_NAMA1")), _
                                          nSr(MyRecReadA("SPK_CDSALES")), nSr(MyRecReadA("SPK_CDSSALES")), _
                                          nSr(MyRecReadA("SURAT_NOPOL")), nSr(MyRecReadA("SURAT_JTPSTNK")), nSr(MyRecReadA("SURAT_TGLSTNK")), _
                                          mPiutangU + mPiutangA, "")
                    ElseIf mTipe = 3 Then
                        insertTabelBBM(1, "BPKB JADI", nSr(MyRecReadA("SPK_NO")), nSr(MyRecReadA("SPK_NAMA1")), _
                                          nSr(MyRecReadA("SPK_CDSALES")), nSr(MyRecReadA("SPK_CDSSALES")), _
                                          nSr(MyRecReadA("SURAT_BPKB")), nSr(MyRecReadA("SURAT_BPKBTRMSPL")), nSr(MyRecReadA("SURAT_TGLBPKB")), _
                                          mPiutangU + mPiutangA, "")
                    End If

                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, "1")
        End Try
    End Sub

  



    Sub InputVariabelTanggal()
        txtTglStart.Text = InputDT("", "", "", "00", "00", "00", CDate(txtTglStart.Text))
        txtTglEnd.Text = InputDT("", "", "", "23", "59", "00", CDate(txtTglEnd.Text))
    End Sub



    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSuratFaktur.Click
        If txtTglStart.Text <> "" And txtTglEnd.Text <> "" Then
            Dim mQuery As String
            mQuery = "Datediff(day," & DtInSQL(CDate(txtTglStart.Text)) & ",SURAT_TGLFAKI) >= 0 and datediff(day,SURAT_TGLFAKI," & DtInSQL(CDate(txtTglEnd.Text)) & ") >= 0 " & _
                     IIf(TxtNoSPK.Text <> "", " AND SPK_NO='" & TxtNoSPK.Text & "' ", "") & _
                     IIf(TxtCdSales.Text <> "", " AND SPK_CDSALES='" & TxtCdSales.Text & "' ", "") & _
                     IIf(TxtCdSSales.Text <> "", " AND SPK_CDSSALES='" & TxtCdSSales.Text & "' ", "")
            Call AmbilData(1, mQuery, "SURAT_TGLFAKI")
        Else
            Call Msg_err("Isian Tanggal belum benar", 1)
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSuratSTNK.Click
        If txtTglStart.Text <> "" And txtTglEnd.Text <> "" Then
            Dim mQuery As String
            mQuery = "datediff(day," & DtInSQL(CDate(txtTglStart.Text)) & ",SURAT_TGLSTNK) >= 0 and datediff(day,SURAT_TGLSTNK," & DtInSQL(CDate(txtTglEnd.Text)) & ") >= 0" & _
                     IIf(TxtNoSPK.Text <> "", " AND SPK_NO='" & TxtNoSPK.Text & "' ", "") & _
                     IIf(TxtCdSales.Text <> "", " AND SPK_CDSALES='" & TxtCdSales.Text & "' ", "") & _
                     IIf(TxtCdSSales.Text <> "", " AND SPK_CDSSALES='" & TxtCdSSales.Text & "' ", "")
            Call AmbilData(2, mQuery, "SURAT_TGLSTNK")
        Else
            Call Msg_err("Isian Tanggal belum benar", 1)
        End If
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSuratBPKB.Click
        If txtTglStart.Text <> "" And txtTglEnd.Text <> "" Then
            Dim mQuery As String
            mQuery = "Datediff(day," & DtInSQL(CDate(txtTglStart.Text)) & ",SURAT_TGLBPKB) >= 0 and datediff(day,SURAT_TGLBPKB," & DtInSQL(CDate(txtTglEnd.Text)) & ") >= 0" & _
                     IIf(TxtNoSPK.Text <> "", " AND SPK_NO='" & TxtNoSPK.Text & "' ", "") & _
                     IIf(TxtCdSales.Text <> "", " AND SPK_CDSALES='" & TxtCdSales.Text & "' ", "") & _
                     IIf(TxtCdSSales.Text <> "", " AND SPK_CDSSALES='" & TxtCdSSales.Text & "' ", "")
            Call AmbilData(3, mQuery, "SURAT_TGLBPKB")
        Else
            Call Msg_err("Isian Tanggal belum benar", 1)
        End If
    End Sub

    'Protected Sub BtnCetak_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCetak.Click
    '   Response.ClearContent()
    '   Response.AddHeader("content-disposition", "attachment; filename=AsuransiJTP.xls")
    '   Response.ContentType = "application/excel"
    'Dim sw As New System.IO.StringWriter()
    'Dim htw As New HtmlTextWriter(sw)
    '    LvTabelBBM.RenderControl(htw)
    '    Response.Write(sw.ToString())
    '    Response.[End]()

    'End Sub
End Class
