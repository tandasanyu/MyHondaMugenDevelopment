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

Partial Class Form0203PerformanceSales01Salesman
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
                Call MsgProses("", 0)
            Else
                MultiViewQueryDlr.ActiveViewIndex = -1
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
    Sub MsgProses(ByVal mtext As String, ByVal Kunci As Byte)
        lblProsesBox.Text = mtext
        If Kunci = 1 Then
            BtnLaporanSalesman.Enabled = False
            BtnLaporanInsentive.Enabled = False
        Else
            BtnLaporanSalesman.Enabled = True
            BtnLaporanInsentive.Enabled = True
        End If
    End Sub
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
            Call Data_Performance_sales_to_Web()
            CheckBoxPerbarui.Checked = False
        End If
        LVInsentive.DataBind() : lvSPK.DataBind()
    End Sub

    Protected Sub BtnLaporanSalesman_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLaporanSalesman.Click
        MultiView1Menu.ActiveViewIndex = 0
        lvSPK.DataBind()
    End Sub
    Protected Sub BtnLaporanInsentive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLaporanInsentive.Click
        MultiView1Menu.ActiveViewIndex = 1
        LVInsentive.DataBind()
    End Sub
    Function Data_Performance_sales_to_Web() As Byte

        Dim mTgl1 As String = InputDT(Year(CDate(Now())), 1, 1, "00", "00", "00", "")
        Dim mTgl2 As String = InputDT(Year(CDate(Now())), Month(CDate(Now())), "1", "00", "00", "00", "")
        Data_Performance_sales_to_Web = 0
        Try
            Dim myDealer As String = "112"
            If Month(Now()) = 1 Then
                mTgl1 = InputDT(Year(CDate(Now())) - 1, 1, 1, "00", "00", "00", "")
                mTgl2 = InputDT(Year(CDate(Now())) - 1, 12, 31, "00", "00", "00", "")
            End If

            If CheckBoxPerbarui.Checked = True Then
                MySTRsql1 = "DELETE FROM DATA_SALESPERFORM"
                Call UpdateDatabase_Tabel(MySTRsql1, "")
            End If

            Call MsgProses("Tunggu Sedang Proses Ambil Data Perform Sales untuk Ps Munggu dan Puri", 1)
            For mProses = 1 To 2
                If mProses = 1 Then
                    myDealer = "112"
                Else
                    myDealer = "128"
                End If

                MySTRsql1 = "SELECT * FROM DATA_SALESPERFORM WHERE SALES_MUGEN='" & myDealer & "' AND ( SALES_CREATE IS NULL OR MONTH(SALES_CREATE)=MONTH(GETDATE()))"
                If GetDataD_00NoFound01Found(MySTRsql1, "") <> 1 Then
                    MySTRsql1 = "DELETE FROM DATA_SALESPERFORM WHERE SALES_MUGEN='" & myDealer & "'"
                    Call UpdateDatabase_Tabel(MySTRsql1, "")

                    LVInsentive.DataBind()
                    lvSPK.DataBind()

                    Call Data_Performance_sales01(myDealer, mTgl1, mTgl2)
                    Call Data_Performance_sales02(myDealer, mTgl1, mTgl2)
                    Call Data_Performance_sales03(myDealer, mTgl1, mTgl2)
                    Call Data_Performance_sales04(myDealer, mTgl1, mTgl2)
                End If
            Next
            Call MsgProses("Proses Baca Data Selesai", 0)
            CheckBoxPerbarui.Checked = False
            Data_Performance_sales_to_Web = 1
        Catch ex As Exception
            Data_Performance_sales_to_Web = 0
        End Try
    End Function
    Sub Input_data_SALES(ByVal mKode As String, ByVal mNama As String, ByVal mLokasi As String, ByVal mGroup As String, ByVal mKol1 As String, ByVal mKol2 As String, ByVal mNilai As String)
        MySTRsql1 = "SELECT * FROM DATA_SALESPERFORM WHERE SALES_KODE = '" & mKode & "' AND SALES_MUGEN = '" & mLokasi & "'"
        Try
            If GetDataD_00NoFound01Found(MySTRsql1, "") <> 1 Then
                MySTRsql1 = "INSERT INTO DATA_SALESPERFORM " & _
                                "(SALES_CREATE,SALES_KODE,SALES_NAMA,SALES_MUGEN,SALES_GROUP," & _
                                " SALES_01SP,SALES_02SP,SALES_03SP,SALES_04SP,SALES_05SP,SALES_06SP,SALES_07SP,SALES_08SP,SALES_09SP,SALES_10SP,SALES_11SP,SALES_12SP," & _
                                " SALES_01DO,SALES_02DO,SALES_03DO,SALES_04DO,SALES_05DO,SALES_06DO,SALES_07DO,SALES_08DO,SALES_09DO,SALES_10DO,SALES_11DO,SALES_12DO," & _
                                " SALES_01FK,SALES_02FK,SALES_03FK,SALES_04FK,SALES_05FK,SALES_06FK,SALES_07FK,SALES_08FK,SALES_09FK,SALES_10FK,SALES_11FK,SALES_12FK," & _
                                " SALES_01IN,SALES_02IN,SALES_03IN,SALES_04IN,SALES_05IN,SALES_06IN,SALES_07IN,SALES_08IN,SALES_09IN,SALES_10IN,SALES_11IN,SALES_12IN," & _
                                " SALES_01DMY,SALES_02DMY,SALES_03DMY,SALES_04DMY,SALES_05DMY,SALES_06DMY,SALES_07DMY,SALES_08DMY,SALES_09DMY,SALES_10DMY,SALES_11DMY,SALES_12DMY) VALUES " & _
                                "(GETDATE(),'" & mKode & "','" & mNama & "','" & mLokasi & "','" & mGroup & "',0,0,0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0,0,0 ,0,0,0,0,0,0,0,0,0,0,0,0 ,0,0,0,0,0,0,0,0,0,0,0,0 ,'','','','','','','','','','','','')"
                Call UpdateDatabase_Tabel(MySTRsql1, "")
            End If

            MySTRsql1 = "UPDATE DATA_SALESPERFORM SET SALES_" & Format(Val(mKol2), "0#") & mKol1 & "=" & mNilai & " WHERE SALES_KODE = '" & mKode & "' AND SALES_MUGEN = '" & mLokasi & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & MySTRsql1, 1)
        End Try
    End Sub
    Sub Data_Performance_sales01(ByVal mServer As String, ByVal mTgl1 As String, ByVal mTgl2 As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                                "SELECT MONTH(SPK_TANGGAL) as mNomonth,COUNT(SALES_Kode) as mCNT,SALES_Kode,SALES_Group,SALES_Nama FROM TRXN_SPK,DATA_SALESMAN WHERE SALES_Kode = SPK_CdSales AND " & _
                                "DATEDIFF(DAY," & DtInSQL(CDate(mTgl1)) & ",SPK_TANGGAL) >= 0  AND DATEDIFF(DAY,SPK_TANGGAL," & DtInSQL(CDate(mTgl2)) & ") >= 0 " & _
                                " GROUP BY MONTH(SPK_TANGGAL),SALES_Kode,SALES_Group,SALES_Nama"
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    Call Input_data_SALES(nSr(MyRecReadA("SALES_Kode")), nSr(MyRecReadA("SALES_Nama")), mServer, nSr(MyRecReadA("SALES_Group")), "SP", nSr(MyRecReadA("mNomonth")), nSr(MyRecReadA("mCNT")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 1)
        End Try
    End Sub
    Sub Data_Performance_sales02(ByVal mServer As String, ByVal mTgl1 As String, ByVal mTgl2 As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                                "SELECT MONTH(SPK_TglDO) as mNomonth,COUNT(SALES_Kode) as mCNT,SALES_Kode,SALES_Group,SALES_Nama FROM TRXN_SPK,DATA_SALESMAN WHERE SALES_Kode = SPK_CdSales AND " & _
                                "DATEDIFF(DAY," & DtInSQL(CDate(mTgl1)) & ",SPK_TglDO) >= 0  AND DATEDIFF(DAY,SPK_TglDO," & DtInSQL(CDate(mTgl2)) & ") >= 0 " & _
                                " GROUP BY MONTH(SPK_TglDO),SALES_Kode,SALES_Group,SALES_Nama"

        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    Call Input_data_SALES(nSr(MyRecReadA("SALES_Kode")), nSr(MyRecReadA("SALES_Nama")), mServer, nSr(MyRecReadA("SALES_Group")), "DO", nSr(MyRecReadA("mNomonth")), nSr(MyRecReadA("mCNT")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 1)
        End Try
    End Sub
    Sub Data_Performance_sales03(ByVal mServer As String, ByVal mTgl1 As String, ByVal mTgl2 As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                        "SELECT MONTH(SURAT_TGLFAK) as mNomonth,COUNT(SALES_Kode) as mCNT,SALES_Kode,SALES_Group,SALES_Nama FROM TRXN_SURAT,TRXN_SPK,DATA_SALESMAN WHERE SURAT_SPK=SPK_NO AND SPK_CdSales = SALES_Kode AND " & _
                        "DATEDIFF(DAY," & DtInSQL(CDate(mTgl1)) & ",SURAT_TGLFAK) >= 0  AND DATEDIFF(DAY,SURAT_TGLFAK," & DtInSQL(CDate(mTgl2)) & ") >= 0 " & _
                        " GROUP BY MONTH(SURAT_TGLFAK),SALES_Kode,SALES_Group,SALES_Nama"

        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    Call Input_data_SALES(nSr(MyRecReadA("SALES_Kode")), nSr(MyRecReadA("SALES_Nama")), mServer, nSr(MyRecReadA("SALES_Group")), "FK", nSr(MyRecReadA("mNomonth")), nSr(MyRecReadA("mCNT")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 1)
        End Try
    End Sub
    Sub Data_Performance_sales04(ByVal mServer As String, ByVal mTgl1 As String, ByVal mTgl2 As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                                "SELECT INSENTIVE_KDSALES,SALES_Group,SALES_Nama,SUM(INSENTIVE_NILAI) as mCNT,MONTH(INSENTIVE_BULAN) as mNomonth " & _
                                "FROM TEMP_INSENTIVE,DATA_SALESMAN WHERE " & _
                                "YEAR(INSENTIVE_BULAN)=" & Year(CDate(mTgl2)) & " AND INSENTIVE_KDSALES=SALES_Kode  " & _
                                "GROUP BY INSENTIVE_KDSALES,SALES_Group,SALES_Nama,YEAR(INSENTIVE_BULAN),MONTH(INSENTIVE_BULAN)"

        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    Call Input_data_SALES(nSr(MyRecReadA("INSENTIVE_KDSALES")), nSr(MyRecReadA("SALES_Nama")), mServer, nSr(MyRecReadA("SALES_Group")), "IN", nSr(MyRecReadA("mNomonth")), nSr(MyRecReadA("mCNT")))
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
