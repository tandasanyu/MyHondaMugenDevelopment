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

Partial Class Form0203PerformanceSales03Leasing
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
            MultiView1Menu.ActiveViewIndex = 0
            If mFound = 1 Then
                Call Msg_err("", 0)
            Else
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
        Call Data_Performance_Leasing_to_Web()
        LvPerolehanLeasing.DataBind()
    End Sub



    'BtnLaporanLeasing
    Function Data_Performance_Leasing_to_Web() As Byte

        Dim mTgl1 As String = ""
        Dim mTgl2 As String = ""
        Dim mDealer As String = ""
        Dim MySTRsql1 As String
        Data_Performance_Leasing_to_Web = 0
        Try
            MySTRsql1 = "DELETE FROM REPORT_SPKLEASE"
            Call UpdateDatabase_Tabel(MySTRsql1, "")
            
            lblMsgBox.Text = "Tunggu Sedang Proses Ambil Data Perform Leasing untuk Ps Munggu dan Puri"
            For mProses = 1 To 2
                If mProses = 1 Then
                    mDealer = "112"
                Else
                    mDealer = "128"
                End If
                MySTRsql1 = "SELECT SPKLEASE_DEALER FROM REPORT_SPKLEASE WHERE SPKLEASE_DEALER='" & mDealer & "' AND DATEDIFF(DAY,SPKLEASE_CREATE,GETDATE())=0"
                If GetDataD_00NoFound01Found(MySTRsql1, "") <> 1 Then

                    MySTRsql1 = "DELETE FROM REPORT_SPKLEASE WHERE SPKLEASE_DEALER='" & mDealer & "'"
                    Call UpdateDatabase_Tabel(MySTRsql1, "")
                    LvPerolehanLeasing.DataBind()

                    For mBulan As Byte = 1 To Month(Now())
                        Call Insert_summaryLeasing1(mDealer, mBulan)
                    Next
                    Call Insert_summaryLeasing2(mDealer)
                End If
            Next
            lblMsgBox.Text = "Proses Baca Data Selesai"
            Data_Performance_Leasing_to_Web = 1
        Catch ex As Exception
            Data_Performance_Leasing_to_Web = 0
        End Try
    End Function
    Sub Insert_summaryLeasing1(ByVal mServer As String, ByVal mBln As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT MONTH(SPK_TglDO) as mNomonth,COUNT(SPK_CdLease) as mCNT,SPK_CdLease,Lease_nama FROM TRXN_SPK,DATA_LEASE WHERE SPK_CdLease=LEASE_Kode AND " & _
                                         "MONTH(SPK_TglDO) = " & mBln & " AND YEAR(SPK_TglDO) = " & Year(Now) & " " & _
                                         "GROUP BY MONTH(SPK_TglDO),SPK_CdLease,Lease_nama"
        Dim mTgl2 As String = Format(Now(), "yy") & Format(Val(mBln), "0#")
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mSqlCommadstring = "SELECT * FROM REPORT_SPKLEASE WHERE SPKLEASE_KODE='" & nSr(MyRecReadA("SPK_CdLease")) & "' AND SPKLEASE_DEALER='" & mServer & "'"
                    If GetDataD_00NoFound01Found(mSqlCommadstring, "") <> 1 Then
                        mSqlCommadstring = "INSERT INTO REPORT_SPKLEASE " & _
                                           "(SPKLEASE_CREATE,SPKLEASE_KODE,SPKLEASE_NAMA,SPKLEASE_YYMM,SPKLEASE_DEALER,SPKLEASE_CNT,SPKLEASE_CNT01,SPKLEASE_CNT02,SPKLEASE_CNT03,SPKLEASE_CNT04,SPKLEASE_CNT05,SPKLEASE_CNT06,SPKLEASE_CNT07,SPKLEASE_CNT08,SPKLEASE_CNT09,SPKLEASE_CNT10,SPKLEASE_CNT11,SPKLEASE_CNT12) VALUES " & _
                                           "(GETDATE(),'" & nSr(MyRecReadA("SPK_CdLease")) & "','" & nSr(MyRecReadA("Lease_nama")) & "','" & mTgl2 & "','" & mServer & "',0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)"
                        Call UpdateDatabase_Tabel(mSqlCommadstring, "")
                    End If
                    mSqlCommadstring = "UPDATE REPORT_SPKLEASE SET SPKLEASE_CNT" & Format(Val(mBln), "0#") & "=" & nLg(MyRecReadA("mCNT")) & ",SPKLEASE_CNT=SPKLEASE_CNT+" & nLg(MyRecReadA("mCNT")) & " " & _
                                       "WHERE SPKLEASE_KODE='" & nSr(MyRecReadA("SPK_CdLease")) & "' AND SPKLEASE_DEALER='" & mServer & "'"
                    Call UpdateDatabase_Tabel(mSqlCommadstring, "")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 1)
        End Try
    End Sub
    Sub Insert_summaryLeasing2(ByVal mServer As String)
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                    "SELECT SPKLEASE_DEALER," & _
                    "SUM(SPKLEASE_CNT) as mCNT," & _
                    "SUM(ISNULL(SPKLEASE_CNT01,0)) as mCNT01,SUM(ISNULL(SPKLEASE_CNT05,0)) as mCNT05,SUM(ISNULL(SPKLEASE_CNT09,0)) as mCNT09, " & _
                    "SUM(ISNULL(SPKLEASE_CNT02,0)) as mCNT02,SUM(ISNULL(SPKLEASE_CNT06,0)) as mCNT06,SUM(ISNULL(SPKLEASE_CNT10,0)) as mCNT10, " & _
                    "SUM(ISNULL(SPKLEASE_CNT03,0)) as mCNT03,SUM(ISNULL(SPKLEASE_CNT07,0)) as mCNT07,SUM(ISNULL(SPKLEASE_CNT11,0)) as mCNT11, " & _
                    "SUM(ISNULL(SPKLEASE_CNT04,0)) as mCNT04,SUM(ISNULL(SPKLEASE_CNT08,0)) as mCNT08,SUM(ISNULL(SPKLEASE_CNT12,0)) as mCNT12  " & _
                    "FROM REPORT_SPKLEASE WHERE SPKLEASE_DEALER='" & mServer & "' GROUP BY SPKLEASE_DEALER"

        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mSqlCommadstring = "INSERT INTO REPORT_SPKLEASE " & _
                                        "(SPKLEASE_CREATE,SPKLEASE_KODE,SPKLEASE_NAMA,SPKLEASE_YYMM,SPKLEASE_CNT,SPKLEASE_DEALER,SPKLEASE_CNT01,SPKLEASE_CNT02,SPKLEASE_CNT03,SPKLEASE_CNT04,SPKLEASE_CNT05,SPKLEASE_CNT06,SPKLEASE_CNT07,SPKLEASE_CNT08,SPKLEASE_CNT09,SPKLEASE_CNT10,SPKLEASE_CNT11,SPKLEASE_CNT12) VALUES " & _
                                        "(GETDATE(),'ZZZ','*TOTAL PER DEALER =====>',''," & nLg(MyRecReadA("mCNT")) & ",'" & mServer & "'," & _
                                        nLg(MyRecReadA("mCNT01")) & "," & nLg(MyRecReadA("mCNT02")) & "," & nLg(MyRecReadA("mCNT03")) & "," & _
                                        nLg(MyRecReadA("mCNT04")) & "," & nLg(MyRecReadA("mCNT05")) & "," & nLg(MyRecReadA("mCNT06")) & "," & _
                                        nLg(MyRecReadA("mCNT07")) & "," & nLg(MyRecReadA("mCNT08")) & "," & nLg(MyRecReadA("mCNT09")) & "," & _
                                        nLg(MyRecReadA("mCNT10")) & "," & nLg(MyRecReadA("mCNT11")) & "," & nLg(MyRecReadA("mCNT12")) & ")"
                    Call UpdateDatabase_Tabel(mSqlCommadstring, "")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 1)
        End Try
    End Sub

    Function InputReport(ByVal mp_DEALER As String, ByVal mp_DEPT As String, ByVal mp_NAMA As String, ByVal mp_GROUP As String, ByVal mp_Hitung As String) As Byte
        InputReport = 0
        Dim MySTRsql1 As String
        MySTRsql1 = "SELECT * FROM TEMP_WEBREPORT " & _
                    "WHERE WEBREPORT_DEALER='" & mp_DEALER & "' AND WEBREPORT_DEPT='" & mp_DEPT & "' AND WEBREPORT_GROUP='" & mp_GROUP & "' AND WEBREPORT_NAMA='" & mp_NAMA & "'"
        If GetDataD_00NoFound01Found(MySTRsql1, "") <> 1 Then
            MySTRsql1 = "INSERT INTO TEMP_WEBREPORT (WEBREPORT_DEALER,WEBREPORT_DEPT,WEBREPORT_GROUP,WEBREPORT_NAMA," & _
                        "WEBREPORT_01QTY,WEBREPORT_01RP,WEBREPORT_02QTY,WEBREPORT_02RP,WEBREPORT_03QTY,WEBREPORT_03RP," & _
                        "WEBREPORT_04QTY,WEBREPORT_04RP,WEBREPORT_05QTY,WEBREPORT_05RP,WEBREPORT_06QTY,WEBREPORT_06RP," & _
                        "WEBREPORT_07QTY,WEBREPORT_07RP,WEBREPORT_08QTY,WEBREPORT_08RP,WEBREPORT_09QTY,WEBREPORT_09RP," & _
                        "WEBREPORT_10QTY,WEBREPORT_10RP,WEBREPORT_11QTY,WEBREPORT_11RP,WEBREPORT_12QTY,WEBREPORT_12RP,WEBREPORT_TGL) VALUES " & _
                        "('" & mp_DEALER & "','" & mp_DEPT & "','" & mp_GROUP & "','" & mp_NAMA & "'," & _
                        "0,0,0,0,0,0," & _
                        "0,0,0,0,0,0," & _
                        "0,0,0,0,0,0," & _
                        "0,0,0,0,0,0,GETDATE())"
            Call UpdateDatabase_Tabel(MySTRsql1, "")
        End If
        If mp_Hitung <> "" Then
            MySTRsql1 = "UPDATE TEMP_WEBREPORT SET " & mp_Hitung & " " & _
                        "WHERE WEBREPORT_DEALER='" & mp_DEALER & "' AND WEBREPORT_DEPT='" & mp_DEPT & "' AND WEBREPORT_GROUP='" & mp_GROUP & "' AND WEBREPORT_NAMA='" & mp_NAMA & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")
        End If

    End Function



End Class
