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

Partial Class Form0203PerformanceSales02PiutangSPK
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
            MultiViewQuerySpv.ActiveViewIndex = 0
            MultiView1Menu.ActiveViewIndex = 0
            If mFound = 1 Then
                Call Msg_err("", 0)
                CheckBoxPerbarui.Checked = False
                'Call MsgProses("", 0)
            Else
                MultiViewQuerySpv.ActiveViewIndex = -1
                MultiView1Menu.ActiveViewIndex = -1
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

    Protected Sub ButtonPsm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPsm.Click
        If CheckBoxPerbarui.Checked = True Then
            Call ARPiutangEmail()
            CheckBoxPerbarui.Checked = False
        End If
        LvAR.DataBind()
    End Sub

    Function ARPiutangEmail() As Byte

        ARPiutangEmail = 0
        Try
            Dim mDealer As String = "112"

            If CheckBoxPerbarui.Checked = True Then
                MySTRsql1 = "DELETE FROM DATA_ARSTOCK"
                Call UpdateDatabase_Tabel(MySTRsql1, "")
            End If
            'Call MsgProses("Tunggu Sedang Proses Ambil Data Piutang Sales untuk Ps Munggu dan Puri", 1)
            For mProses = 1 To 2
                If mProses = 1 Then
                    mDealer = "112"
                Else
                    mDealer = "128"
                End If

                MySTRsql1 = "SELECT * FROM DATA_ARSTOCK  WHERE ARSTOCK_DEALER='" & mDealer & "' AND DATEDIFF(DAY,ARSTOCK_CREATE,GETDATE())=0"
                If GetDataD_00NoFound01Found(MySTRsql1, "") <> 1 Then

                    MySTRsql1 = "DELETE FROM TEMP_REPORT3A"
                    Call UpdateDatabase_Tabel(MySTRsql1, mDealer)
                    MySTRsql1 = "DELETE FROM DATA_ARSTOCK WHERE ARSTOCK_DEALER='" & mDealer & "'"
                    Call UpdateDatabase_Tabel(MySTRsql1, "")
                    LvAR.DataBind()

                    MySTRsql1 = "INSERT INTO TEMP_REPORT3A(TEMP3A_NOSPK,TEMP3A_BAYARU,TEMP3A_BAYARA,TEMP3A_BAYART,TEMP3A_TGL) " & _
                                "SELECT SPK_NO," & _
                                "(SELECT sum(ARTRAN_JUMLAH) as jml from trxn_artran WHERE ARTRAN_nospk =SPK_NO AND (ARTRAN_NOWO='' OR (ARTRAN_NOWO IS NULL)))," & _
                                "(SELECT sum(ARTRAN_JUMLAH) as jml from trxn_artran WHERE ARTRAN_nospk =SPK_NO AND NOT (ARTRAN_NOWO='' OR (ARTRAN_NOWO IS NULL)))," & _
                                "(SELECT sum(ARTRAN_JUMLAH) as jml from trxn_artran WHERE ARTRAN_nospk =SPK_NO)," & _
                                "(SELECT MAX(OPTH_TGLWO) as mTGL FROM TRXN_OPT,TRXN_OPTH WHERE OPTH_NOWO=OPT_NOWO AND OPT_NOSPK=SPK_NO AND OPT_STATUS='A' GROUP BY OPT_NOSPK) " & _
                                "FROM TRXN_SPK " & _
                                "WHERE NOT(SPK_NoDO IS NULL Or SPK_NoDO='') AND " & _
                                "(((ISNULL(SPK_PIUTANG,0) + ISNULL(SPK_HrgASS,0)) - ISNULL(SPK_POTONGAN,0)) - ISNULL((SELECT sum(ARTRAN_JUMLAH) as jml from trxn_artran WHERE ARTRAN_nospk =SPK_NO ),0)) > 0 "
                    Call UpdateDatabase_Tabel(MySTRsql1, mDealer)

                    Call ARPiutangEmail_Step01(mDealer)
                    Call ARPiutangEmail_Step02(mDealer)
                    Call ARPiutangEmail_Step03(mDealer)

                End If
            Next
            'Call MsgProses("Proses Baca Data Selesai", 0)
            CheckBoxPerbarui.Checked = False
            ARPiutangEmail = 1
        Catch ex As Exception
            ARPiutangEmail = 0
        End Try
    End Function
    Sub ARPiutangEmail_Step01(ByVal mServer As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim mJtp As String
        Dim mhari As Integer
        Dim mJumlah, mJumlahCR, mJumlahW1, mJumlahW2, mJumlahW3, mJumlahW4, mJumlahW0 As Double
        Dim mSqlCommadstring As String = "SELECT * FROM TEMP_REPORT3A,TRXN_SPK,TRXN_STOCK,DATA_LEASE WHERE TEMP3A_NOSPK=SPK_NO AND SPK_NORANGKA=STOCK_NORANGKA AND LEASE_KODE=SPK_CDLEASE"
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mJtp = DateAdd(DateInterval.Day, nLg(MyRecReadA("SPK_HARI")), MyRecReadA("SPK_TGLDO"))
                    mhari = DateDiff(DateInterval.Day, CDate(mJtp), Now())
                    mJumlah = (nLg(MyRecReadA("SPK_PIUTANG")) - nLg(MyRecReadA("SPK_POTONGAN")) + nLg(MyRecReadA("SPK_HrgASS"))) - (nLg(MyRecReadA("TEMP3A_BAYARU")) + nLg(MyRecReadA("TEMP3A_BAYARA")))
                    mJumlahCR = 0 : mJumlahW1 = 0 : mJumlahW2 = 0 : mJumlahW3 = 0 : mJumlahW4 = 0 : mJumlahW0 = 0
                    If mhari <= 0 Then
                        mJumlahCR = mJumlah
                    ElseIf mhari <= 7 Then
                        mJumlahW1 = mJumlah
                    ElseIf mhari <= 15 Then
                        mJumlahW2 = mJumlah
                    ElseIf mhari <= 23 Then
                        mJumlahW3 = mJumlah
                    ElseIf mhari <= 31 Then
                        mJumlahW4 = mJumlah
                    Else
                        mJumlahW0 = mJumlah
                    End If

                    MySTRsql1 = "INSERT INTO DATA_ARSTOCK (ARSTOCK_DEALER,ARSTOCK_NOSPK,ARSTOCK_TGLSPK,ARSTOCK_TGLDO,ARSTOCK_TGLTERIMA,ARSTOCK_NAMA,ARSTOCK_CDTYPE,ARSTOCK_TAHUN,ARSTOCK_KDSLS,ARSTOCK_KDSPV,ARSTOCK_LEASE,ARSTOCK_TEMPO,ARSTOCK_ARCURR,ARSTOCK_ARWK01,ARSTOCK_ARWK02,ARSTOCK_ARWK03,ARSTOCK_ARWK04,ARSTOCK_ARWK99,ARSTOCK_HARI,ARSTOCK_KETERANGAN,ARSTOCK_PIUTANGU,ARSTOCK_PIUTANGA,ARSTOCK_BAYARU,ARSTOCK_BAYARA,ARSTOCK_TGL,ARSTOCK_CREATE) VALUES " & _
                                "('" & mServer & "','" & nSr(MyRecReadA("SPK_NO")) & "'," & DtInFormat(MyRecReadA("SPK_TGLSPK"), "dd/MM/yy") & "," & DtInFormat(MyRecReadA("SPK_TGLDO"), "dd/MM/yy") & "," & DtInFormat(MyRecReadA("STOCK_KirimTglTerima"), "dd/MM/yy") & "," & _
                                "'" & nSr(MyRecReadA("SPK_NAMA1")) & "','" & nSr(MyRecReadA("SPK_CDTYPE")) & "','" & nSr(MyRecReadA("SPK_TAHUN")) & "','" & nSr(MyRecReadA("SPK_CDSALES")) & "','" & nSr(MyRecReadA("SPK_CDSSALES")) & "','" & nSr(MyRecReadA("LEASE_SINGKATAN")) & "'," & _
                                "" & DtInFormat(mJtp, "dd/MM/yy") & "," & mJumlahCR & "," & mJumlahW1 & "," & mJumlahW2 & "," & mJumlahW3 & "," & mJumlahW4 & "," & mJumlahW0 & "," & mhari & ",'" & nSr(MyRecReadA("SPK_KETERANGAN")) & "'," & _
                                "" & (nLg(MyRecReadA("SPK_PIUTANG")) - nLg(MyRecReadA("SPK_POTONGAN"))) & "," & nLg(MyRecReadA("SPK_HrgASS")) & "," & _
                                "" & nLg(MyRecReadA("TEMP3A_BAYARU")) & "," & nLg(MyRecReadA("TEMP3A_BAYARA")) & "," & DtInFormat(Now(), "dd/MM/yy:HH") & ",GETDATE())"
                    Call UpdateDatabase_Tabel(MySTRsql1, "")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 1)
        End Try
    End Sub
    Sub ARPiutangEmail_Step02(ByVal mServer As String)
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT ARSTOCK_KDSPV,SUM(ARSTOCK_ARCURR) AS flTotalCr,SUM(ARSTOCK_ARWK01) AS flTotalW1 ,SUM(ARSTOCK_ARWK02) AS flTotalW2, SUM(ARSTOCK_ARWK03) AS flTotalW3, SUM(ARSTOCK_ARWK04) AS flTotalW4, SUM(ARSTOCK_ARWK99) AS flTotalW9,SUM(ARSTOCK_PIUTANGU-ARSTOCK_BAYARU) AS flTotalPU,SUM(ARSTOCK_PIUTANGA-ARSTOCK_BAYARA) AS flTotalPA  FROM DATA_ARSTOCK WHERE ARSTOCK_DEALER = '" & mServer & "' GROUP BY ARSTOCK_KDSPV"
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    MySTRsql1 = "INSERT INTO DATA_ARSTOCK (ARSTOCK_DEALER,ARSTOCK_NOSPK,ARSTOCK_TGLSPK,ARSTOCK_TGLDO,ARSTOCK_TGLTERIMA,ARSTOCK_NAMA,ARSTOCK_CDTYPE,ARSTOCK_TAHUN,ARSTOCK_KDSLS,ARSTOCK_KDSPV,ARSTOCK_LEASE,ARSTOCK_TEMPO,ARSTOCK_ARCURR,ARSTOCK_ARWK01,ARSTOCK_ARWK02,ARSTOCK_ARWK03,ARSTOCK_ARWK04,ARSTOCK_ARWK99,ARSTOCK_HARI,ARSTOCK_KETERANGAN,ARSTOCK_PIUTANGU,ARSTOCK_PIUTANGA,ARSTOCK_BAYARU,ARSTOCK_BAYARA,ARSTOCK_TGL) VALUES " & _
                                "('" & mServer & "','----','----','----','----'," & _
                                "'TOTAL PER SPV ----->','9999999','--','--','" & nSr(MyRecReadA("ARSTOCK_KDSPV")) & "T','----'," & _
                                "'----'," & nLg(MyRecReadA("flTotalCr")) & "," & nLg(MyRecReadA("flTotalW1")) & "," & nLg(MyRecReadA("flTotalW2")) & "," & nLg(MyRecReadA("flTotalW3")) & "," & nLg(MyRecReadA("flTotalW4")) & "," & nLg(MyRecReadA("flTotalW9")) & ",0,'<----- SUB TOTAL PER SPV'," & _
                                "" & nLg(MyRecReadA("flTotalPU")) & "," & nLg(MyRecReadA("flTotalPA")) & "," & _
                                "0,0,'')"
                    Call UpdateDatabase_Tabel(MySTRsql1, "")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 1)
        End Try
    End Sub
    Sub ARPiutangEmail_Step03(ByVal mServer As String)
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT ARSTOCK_DEALER,SUM(ARSTOCK_ARCURR) AS flTotalCr,SUM(ARSTOCK_ARWK01) AS flTotalW1 ,SUM(ARSTOCK_ARWK02) AS flTotalW2, SUM(ARSTOCK_ARWK03) AS flTotalW3, SUM(ARSTOCK_ARWK04) AS flTotalW4, SUM(ARSTOCK_ARWK99) AS flTotalW9,SUM(ARSTOCK_PIUTANGU-ARSTOCK_BAYARU) AS flTotalPU,SUM(ARSTOCK_PIUTANGA-ARSTOCK_BAYARA) AS flTotalPA  FROM DATA_ARSTOCK WHERE ARSTOCK_DEALER = '" & mServer & "' AND  ARSTOCK_NOSPK<>'----' GROUP BY ARSTOCK_DEALER"
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    MySTRsql1 = "INSERT INTO DATA_ARSTOCK (ARSTOCK_DEALER,ARSTOCK_NOSPK,ARSTOCK_TGLSPK,ARSTOCK_TGLDO,ARSTOCK_TGLTERIMA,ARSTOCK_NAMA,ARSTOCK_CDTYPE,ARSTOCK_TAHUN,ARSTOCK_KDSLS,ARSTOCK_KDSPV,ARSTOCK_LEASE,ARSTOCK_TEMPO,ARSTOCK_ARCURR,ARSTOCK_ARWK01,ARSTOCK_ARWK02,ARSTOCK_ARWK03,ARSTOCK_ARWK04,ARSTOCK_ARWK99,ARSTOCK_HARI,ARSTOCK_KETERANGAN,ARSTOCK_PIUTANGU,ARSTOCK_PIUTANGA,ARSTOCK_BAYARU,ARSTOCK_BAYARA,ARSTOCK_TGL) VALUES " & _
                                "('" & mServer & "','----','----','----','----'," & _
                                "'TOTAL PER DEALER ----->','9999999','--','--','ZZZ','----'," & _
                                "'----'," & nLg(MyRecReadA("flTotalCr")) & "," & nLg(MyRecReadA("flTotalW1")) & "," & nLg(MyRecReadA("flTotalW2")) & "," & nLg(MyRecReadA("flTotalW3")) & "," & nLg(MyRecReadA("flTotalW4")) & "," & nLg(MyRecReadA("flTotalW9")) & ",0,'<----- SUB TOTAL PER DEALER'," & _
                                "" & nLg(MyRecReadA("flTotalPU")) & "," & nLg(MyRecReadA("flTotalPA")) & "," & _
                                "0,0,'')"
                    Call UpdateDatabase_Tabel(MySTRsql1, "")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 1)
        End Try
    End Sub



End Class
