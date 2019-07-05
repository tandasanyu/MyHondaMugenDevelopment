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

Partial Class Form0203PerformanceSales08JTPAsuransi
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
                MultiView1Menu.ActiveViewIndex = -1
                Call Msg_err("TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI", 1)
            End If
        End If
    End Sub

    Protected Sub DefinisTabelBBM()
        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn(9) {New DataColumn("Temp_SPK"), New DataColumn("Temp_RGK"), New DataColumn("Temp_NAMA"), New DataColumn("Temp_NOHP"), New DataColumn("Temp_NOWO"), _
                                                New DataColumn("Temp_TGWO"), New DataColumn("Temp_JTPA"), New DataColumn("Temp_ASUR"), New DataColumn("Temp_NSLS"), New DataColumn("Temp_NSPV")})
        ViewState("BBM") = dt
        Me.BindGridBBM()
    End Sub
    Protected Sub BindGridBBM()
        LvTabelBBM.DataSource = DirectCast(ViewState("BBM"), DataTable)
        LvTabelBBM.DataBind()
    End Sub


    Sub insertTabelBBM(ByVal Type As Byte, ByVal Temp_SPK As String, ByVal Temp_RGK As String, ByVal Temp_NAMA As String, ByVal Temp_NOHP As String, ByVal Temp_NOWO As String, ByVal Temp_TGWO As String, ByVal Temp_JTPA As String, ByVal Temp_ASUR As String, ByVal Temp_NSLS As String, ByVal Temp_NSPV As String)
        Dim dt As DataTable = DirectCast(ViewState("BBM"), DataTable)
        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_SPK, Temp_RGK, Temp_NAMA, Temp_NOHP, Temp_NOWO, Temp_TGWO, Temp_JTPA, Temp_ASUR, Temp_NSLS, Temp_NSPV)
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

    Sub asuransi_Perpanjang()
        insertTabelBBM(0, "", "", "", "", "", "", "", "", "", "")
        MySTRsql1 = "DELETE FROM TEMP_REPORT7"
        'Call UpdateDatabase_Tabel(MySTRsql1, "")
        LblProses.Text = "---> Proses Baca data     "
        Call Msg_err("Tunggu proses baca sampai selesai ,OK berarti mulai", 1)
        Call PerpanjangAsuransi_FromWOaSURANSIFrom_NoTAX(lblArea1.Text)
        Call PerpanjangAsuransi_FromWOaSURANSIFrom_TAX(lblArea1.Text)
        Call PerpanjangAsuransi_FromSPKLEASING(lblArea1.Text)
        LblProses.Text = "---> Proses Baca data Selesai     "
    End Sub


    Sub PerpanjangAsuransi_FromWOaSURANSIFrom_NoTAX(ByVal mServerku As String)
        Dim mpServer As String = "MyConnCloudDnetNT" & mServerku
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        'MySTRsql1 = "SELECT * FROM TRXN_OPT WHERE DATEDIFF('d'," & FieldTgl(CDate(mpDateServerNext)) & ",OPT_TglJTP) = 30 AND NOT ISNULL(OPT_TglJTP)"
        Dim mSqlCommadstring As String = "SELECT OPT_NOWO,OPT_NoRangka,OPT_NoSPK,OPT_CDASSESORIS,OPT_TglJTP,STANDARD_Nama,OPTH_TglWO FROM TRXN_OPT,TRXN_OPTH,DATA_STANDARD WHERE OPT_NOWO=OPTH_NOWO AND OPT_CDASSESORIS=STANDARD_Kode AND MONTH(OPT_TglJTP) = " & Val(DropDownListTxtBln.Text) & " AND YEAR(OPT_TglJTP) = " & Val(DropDownListTxtThn.Text) & " AND (OPT_TglJTP IS NOT NULL)"

        Dim mTotalSend As Integer = 0
        Dim mTotalSave As Integer = 0
        mTotalSend = 0 : mTotalSave = 0

        Call Msg_err("", "1")
        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read
                    MyIsiNOHP = "" : MyIsiNOPOL = "" : MyIsiNama = "" : MyIsiNOSPK = "" : MyIsiSALES = "" : MyIsiSPV = "" : MyIsiTGlJtp = ""
                    Call GETNOHP(IIf(Len(nSr(MyRecReadA("OPT_NoSPK"))) = 6, "SPK_NO='" & nSr(MyRecReadA("OPT_NoSPK")) & "'", "SPK_NORANGKA='" & nSr(MyRecReadA("OPT_NoRangka")) & "'"), "NT" & mServerku, "POL")
                    If MyIsiNOHP = "" Then
                        Call GETNOHP(IIf(Len(nSr(MyRecReadA("OPT_NoSPK"))) = 6, "SPK_NO='" & nSr(MyRecReadA("OPT_NoSPK")) & "'", "SPK_NORANGKA='" & nSr(MyRecReadA("OPT_NoRangka")) & "'"), "" & mServerku, "POL")
                    End If
                    If MyIsiNOHP <> "" And nSr(MyRecReadA("OPT_NOWO")) <> "" Then
                        insertTabelBBM(1, "'" & MyIsiNOSPK, nSr(MyRecReadA("OPT_NORANGKA")), MyIsiNOPOL & " : " & MyIsiNama, _
                                          "'" & MyIsiNOHP, nSr(MyRecReadA("OPT_NOWO")), nSr(MyRecReadA("OPTH_TglWO")), nSr(MyRecReadA("OPT_TglJTP")), _
                                          nSr(MyRecReadA("STANDARD_Nama")), MyIsiSALES, MyIsiSPV)

                        mTotalSend = mTotalSend + 1
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

    Sub PerpanjangAsuransi_FromWOaSURANSIFrom_TAX(ByVal mServerku As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServerku
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_OPT,TRXN_OPTH,DATA_STANDARD WHERE OPT_NOWO=OPTH_NOWO AND OPT_CDASSESORIS=STANDARD_Kode AND MONTH(OPT_TglJTP) = " & Val(DropDownListTxtBln.Text) & " AND YEAR(OPT_TglJTP) = " & Val(DropDownListTxtThn.Text) & " AND (OPT_TglJTP IS NOT NULL)"

        Dim mTotalSend As Integer = 0
        Dim mTotalSave As Integer = 0
        mTotalSend = 0 : mTotalSave = 0

        Call Msg_err("", "1")
        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read
                    MyIsiNOHP = "" : MyIsiNOPOL = "" : MyIsiNama = "" : MyIsiNOSPK = "" : MyIsiSALES = "" : MyIsiSPV = "" : MyIsiTGlJtp = ""
                    Call GETNOHP(IIf(Len(nSr(MyRecReadA("OPT_NoSPK"))) = 6, "SPK_NO='" & nSr(MyRecReadA("OPT_NoSPK")) & "'", "SPK_NORANGKA='" & nSr(MyRecReadA("OPT_NoRangka")) & "'"), "" & mServerku, "POL")
                    If MyIsiNOHP <> "" And nSr(MyRecReadA("OPT_NOWO")) <> "" Then
                        'mTotalSend = mTotalSend + 1
                        insertTabelBBM(1, "'" & MyIsiNOSPK, nSr(MyRecReadA("OPT_NORANGKA")), MyIsiNOPOL & " : " & MyIsiNama, _
                                       "'" & MyIsiNOHP, nSr(MyRecReadA("OPT_NOWO")), nSr(MyRecReadA("OPTH_TglWO")), nSr(MyRecReadA("OPT_TglJTP")), nSr(MyRecReadA("STANDARD_Nama")), MyIsiSALES, MyIsiSPV)
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

    Sub PerpanjangAsuransi_FromSPKLEASING(ByVal mServerku As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServerku
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_SPK,DATA_LEASE,DATA_SALESMAN WHERE SPK_CDSALES=SALES_KODE AND SPK_CDLEASE=LEASE_KODE AND NOT(LEASE_STATUS='3' OR LEASE_KODE='C001') AND " & _
                    "SPK_TGLDO IS NOT NULL AND ISNULL(SPK_HRGASR,0) > 0 AND NOT(SPK_NAMA1 like '%HONDA%') AND " & _
                    "YEAR(DateAdd(Day, (SPK_HRGASR * 360), SPK_TGLDO)) = " & Val(DropDownListTxtThn.Text) & " AND " & _
                    "MONTH(DATEADD(DAY,(SPK_HRGASR * 360),SPK_TGLDO)) = " & Val(DropDownListTxtBln.Text) & " "

        Dim mTotalSend As Integer = 0
        Dim mTotalSave As Integer = 0
        mTotalSend = 0 : mTotalSave = 0

        Call Msg_err("", "1")
        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read
                    MyIsiNOHP = "" : MyIsiNOPOL = "" : MyIsiNama = "" : MyIsiNOSPK = "" : MyIsiSALES = "" : MyIsiSPV = "" : MyIsiTGlJtp = ""
                    Call GETNOHP("SPK_NO='" & nSr(MyRecReadA("SPK_NO")) & "'", "" & mServerku, "POL")
                    MyIsiTGlJtp = DateAdd("D", (MyRecReadA("SPK_HRGASR") * 360), MyRecReadA("SPK_TGLDO"))
                    mTotalSend = mTotalSend + 1
                    insertTabelBBM(1, "'" & MyIsiNOSPK, nSr(MyRecReadA("SPK_NORANGKA")), MyIsiNOPOL & " : " & MyIsiNama, _
                                      "'" & MyIsiNOHP, "SPK", nSr(MyRecReadA("SPK_TGLDO")), nSr(CDate(MyIsiTGlJtp)), " LEASING :" & nSr(MyRecReadA("LEASE_NAMA")), MyIsiSALES, MyIsiSPV)

                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, "1")
        End Try
    End Sub


    Function GETNOHP(ByVal mfQuery As String, ByVal mServerku As String, ByVal mCho As String) As String

        Dim mpServer As String = "MyConnCloudDnet" & mServerku
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        GETNOHP = ""
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_SPK,TRXN_SURAT,DATA_SALESMAN WHERE SPK_CDSALES=SALES_KODE AND SPK_NO=SURAT_SPK AND " & mfQuery

        Dim mTotalSend As Integer = 0
        Dim mTotalSave As Integer = 0
        mTotalSend = 0 : mTotalSave = 0

        Call Msg_err("", "1")
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                If MyRecReadB.Read Then
                    'If nSr(MyRecReadB("SURAT_NOHP")) <> "" Then
                    MyIsiNOHP = MyRecReadB("SURAT_NOHP") : MyIsiNOPOL = MyRecReadB("SURAT_NOPOL")
                    MyIsiNama = MyRecReadB("SPK_NAMA2") : MyIsiNOSPK = MyRecReadB("SPK_NO")
                    MyIsiSALES = MyRecReadB("SALES_NAMA") : MyIsiSPV = MyRecReadB("SPK_CDSSALES")
                    MyIsiTGlJtp = ""
                    'If nSr(MyRecReadB("SPK_SMSFLAG1")) <> "" Then
                    'GETNOHP = ""
                    'Else
                    'ElseIf mCho = "HP" Or mCho = "HPS" Then
                    'GETNOHP = MyRecReadB("SURAT_NOHP")
                    'ElseIf mCho = "SPK" Then
                    'GETNOHP = MyRecReadB("SPK_NO")
                    'ElseIf mCho = "POL" Then
                    'GETNOHP = MyRecReadB("SURAT_NOPOL")
                    'ElseIf mCho = "NMS" Then
                    'GETNOHP = MyRecReadB("SPK_NAMA2")
                    ' ElseIf mCho = "SLS" Then
                    'GETNOHP = MyRecReadB("SALES_NAMA")
                    'ElseIf mCho = "SPV" Then
                    'GETNOHP = MyRecReadB("SPK_CDSSALES")
                    'End If

                    'End If
                End If
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
            'If GETNOHP = "" And mCho <> "POL" Then GETNOHP = GETNOHP2(mfQuery, mServerku, mCho)
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, "1")
        End Try
    End Function

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTampilkan.Click
        Call asuransi_Perpanjang()
    End Sub

    Protected Sub BtnCetak_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCetak.Click
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=AsuransiJTP.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        LvTabelBBM.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()

    End Sub
End Class
