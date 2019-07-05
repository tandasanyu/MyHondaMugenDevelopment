Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Imports System.Web.Security
'1. Cari Halaman3
'2. Audit Save 
'3. Head Parts Save
'4. Cari Halaman1
'5. Cari Halaman2
'6. Cari Halaman4
'7. Auditor Save
'8. SM Save
'9. Account Save


Partial Class Form0202StatusSPK0302LaporanDetailTrxn
    Inherits System.Web.UI.Page
    '1 Pencarian
    '2 Isi Audit
    '3 ..................

    Public MyRecReadA As OleDbDataReader
    Public MyRecReadB As OleDbDataReader
    Public MyRecReadC As OleDbDataReader
    Public MyRecReadD As OleDbDataReader
    Public MyRecReadF As OleDbDataReader
    Public MySTRsql1 As String
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
            LblUserName.Text = UCase(x.ToString)
            mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0105'")
            If mFound = 1 Then
                DropDownListGroupTipe.Text = "112"
                If lblArea1.Text <> "" Then DropDownListGroupTipe.Text = lblArea1.Text
                MultiViewSearching.ActiveViewIndex = 0
                MultiViewForm0.ActiveViewIndex = 0

                LvWO.DataBind()
            Else
                MultiViewSearching.ActiveViewIndex = -1
                MultiViewForm0.ActiveViewIndex = -1
                Call Msg_err("TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI")
            End If
        End If
    End Sub

    Sub Msg_err(ByVal mTest As String)

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
    End Sub

    Sub MsgProses(ByVal mtext As String, ByVal Kunci As Byte)
        lblProsesBox.Text = mtext
    End Sub

    Protected Sub DropDownListGroupTipe_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListGroupTipe.SelectedIndexChanged
        LvWO.DataBind()
    End Sub
    Protected Sub ButtonPsm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPsm.Click
        If CheckBox1.Checked = True Then
            Call Report_Transaksi_Service_Unit()
            CheckBox1.Checked = False
        End If
        LvWO.DataBind()
    End Sub




    'Laporan1
    Function Report_Transaksi_Service_Unit() As Byte
        Dim mNama As String = ""
        Dim mDealer As String = "112"
        mDealer = DropDownListGroupTipe.Text

        Report_Transaksi_Service_Unit = 0
        Try
            MySTRsql1 = "DELETE FROM TEMP_WEBREPORT WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='A'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            Call MsgProses("Tunggu Sedang Proses Ambil Data Transaksi Service untuk Ps Munggu dan Puri", 1)
            For mProses = 1 To 1
                
                MySTRsql1 = "SELECT * FROM TEMP_WEBREPORT WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='A' AND WEBREPORT_DEALER='" & mDealer & "' AND DATEDIFF(DAY,WEBREPORT_TGL,GETDATE())=0"
                If GetDataD_00NoFound01Found(MySTRsql1, "") <> 1 Then

                    MySTRsql1 = "DELETE FROM TEMP_WEBREPORT WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='A' AND WEBREPORT_DEALER='" & mDealer & "'"
                    Call UpdateDatabase_Tabel(MySTRsql1, "")
                    LvWO.DataBind()

                    'Post Cari Faktur/Close  WOHDRPS_JNSKERJA=3 Bodyrepair
                    Call Report_Transaksi_Service_Unit_Step01("Svcs" & mDealer, mDealer)
                    'Post Cari Incoming WO
                    Call Report_Transaksi_Service_Unit_Step02("Svcs" & mDealer, mDealer)
                    'Post Cari Incoming Uang
                    Call Report_Transaksi_Service_Unit_Step03("Svcs" & mDealer, mDealer)
                    'Post Cari Incoming Uang
                    Call Report_Transaksi_Service_Unit_Step03("Svcs" & mDealer, mDealer)

                    'Call InputReport(MyDealer, "SVC", "*==============================", "A11Z1-WO", mUPDATE)
                    'Call InputReportSumary(MyDealer, " AND SUBSTRING(WEBREPORT_GROUP,1,3)= 'A11' GROUP BY SUBSTRING(WEBREPORT_GROUP,1,3)", _
                    '                       "A11Z2-WO", "--- INCOMING UNIT BODY REPAIR---", "SUBSTRING(WEBREPORT_GROUP,1,3)")
                    'Call InputReport(MyDealer, "SVC", "**==============================", "A11Z3-WO", mUPDATE)
                    '
                    '
                    'Call InputReport(MyDealer, "SVC", "***=============================", "A12Z-WO", mUPDATE)
                    'Call InputReport(MyDealer, "SVC", "****============================", "A13Z-WO", mUPDATE)

                    'Call InputReportSumary(MyDealer, " AND WEBREPORT_DEALER='" & MyDealer & "' AND SUBSTRING(WEBREPORT_GROUP,1,2)= 'A1' AND WEBREPORT_GROUP<>'A11Z2-WO' GROUP BY SUBSTRING(WEBREPORT_GROUP,1,2)", _
                    '                       "A14-WO", "--- INCOMING UNIT KESELURUHAN  ------", "SUBSTRING(WEBREPORT_GROUP,1,2)")
                    'Call InputReport(MyDealer, "SVC", "*****============================", "A15-WO", mUPDATE)

                    Call InputReport(mDealer, "SVC", "*============================", "A51Z1-FAKTUR", "")
                    Call InputReportSumary(mDealer, " AND WEBREPORT_DEALER='" & mDealer & "' AND SUBSTRING(WEBREPORT_GROUP,1,3)= 'A51' AND WEBREPORT_GROUP LIKE '%0-FKT' GROUP BY SUBSTRING(WEBREPORT_GROUP,1,3)", _
                                           "A51Z2-FAKTUR", "--- TOTAL FAKTUR BODYREPAIR JASA ------", "SUBSTRING(WEBREPORT_GROUP,1,3)")
                    Call InputReportSumary(mDealer, " AND WEBREPORT_DEALER='" & mDealer & "' AND SUBSTRING(WEBREPORT_GROUP,1,3)= 'A51' AND WEBREPORT_GROUP LIKE '%1-FKT' GROUP BY SUBSTRING(WEBREPORT_GROUP,1,3)", _
                                           "A51Z2-FAKTUR", "--- TOTAL FAKTUR BODYREPAIR PARTS ------", "SUBSTRING(WEBREPORT_GROUP,1,3)")
                    Call InputReport(mDealer, "SVC", "**============================", "A51Z3", "")

                    Call InputReport(mDealer, "SVC", "***============================", "A52Z-FAKTUR", "")
                    Call InputReport(mDealer, "SVC", "****============================", "A539-FAKTUR", "")

                    Call InputReport(mDealer, "SVC", "*****============================", "A7-FAKTUR", "")
                    Call InputReportSumary(mDealer, " AND WEBREPORT_DEALER='" & mDealer & "' AND SUBSTRING(WEBREPORT_GROUP,1,2)= 'A5' AND WEBREPORT_GROUP<>'A51Z2-FAKTUR' AND WEBREPORT_GROUP LIKE '%0-FKT' GROUP BY SUBSTRING(WEBREPORT_GROUP,1,2)", _
                                           "A8-FAKTUR", "--- TOTAL KESELURUHAN FAKTUR JASA  ------", "SUBSTRING(WEBREPORT_GROUP,1,2)")
                    Call InputReportSumary(mDealer, " AND WEBREPORT_DEALER='" & mDealer & "' AND SUBSTRING(WEBREPORT_GROUP,1,2)= 'A5' AND WEBREPORT_GROUP<>'A51Z2-FAKTUR' AND WEBREPORT_GROUP LIKE '%1-FKT' GROUP BY SUBSTRING(WEBREPORT_GROUP,1,2)", _
                                           "A8-FAKTUR", "--- TOTAL KESELURUHAN FAKTUR PARTS  ------", "SUBSTRING(WEBREPORT_GROUP,1,2)")
                    Call InputReport(mDealer, "SVC", "******============================", "A9-FAKTUR", "")
                End If
            Next
            Call MsgProses("Proses Baca Data Selesai", 0)
            Report_Transaksi_Service_Unit = 1
        Catch ex As Exception
            Report_Transaksi_Service_Unit = 0
        End Try

    End Function

    Sub Report_Transaksi_Service_Unit_Step01(ByVal mServer As String, ByVal mDLR As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mUrut2 As String
        Dim mNama As String

        Dim mSqlCommadstring As String = "SELECT MONTH(WOHDRPS_TGFAK) as mfmonth,WOHDRPS_KDTAGIH,SUPPLIER_NAMA,WOHDRPS_JNSKERJA,count(WOHDRPS_NOWO) as mCNT,SUM(WOHDRPS_TOTSERVICE) as mSVC,SUM(WOHDRPS_DISC) as mDSC,SUM(WOHDRPS_TOTPARTS) as mPRT " & _
                    "FROM TRXN_WOHDRPS, DATA_SUPPLIER " & _
                    "WHERE WOHDRPS_KDTAGIH=SUPPLIER_KODE AND year(WOHDRPS_TGFAK)=YEAR(GETDATE()) group by MONTH(WOHDRPS_TGFAK),WOHDRPS_KDTAGIH,SUPPLIER_NAMA,WOHDRPS_JNSKERJA"
        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mUrut2 = IIf(nSr(MyRecReadA("WOHDRPS_KDTAGIH")) = "000" And nSr(MyRecReadA("WOHDRPS_JNSKERJA")) <> "3", "3", IIf(nSr(MyRecReadA("WOHDRPS_KDTAGIH")) = "A10", "2", "1"))

                    mNama = nSr(MyRecReadA("SUPPLIER_NAMA")) & _
                            IIf(nSr(MyRecReadA("WOHDRPS_JNSKERJA")) = "3" And nSr(MyRecReadA("WOHDRPS_KDTAGIH")) = "000", "/BODYREPAIR", "") & IIf(mUrut2 <> 1, " ----", "")


                    mSqlCommadstring = "WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "QTY= " & _
                              "ISNULL(WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "QTY,0) + " & _
                              nLg(MyRecReadA("mCNT")) & "," & _
                              "WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "RP= " & _
                              "ISNULL(WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "RP,0) + " & _
                              nLg(MyRecReadA("mSVC")) - nLg(MyRecReadA("mDSC"))
                    Call InputReport(mDLR, "SVC", mNama & "/JASA", "A5" & mUrut2 & nSr(MyRecReadA("WOHDRPS_KDTAGIH")) & "0-FKT", "")

                    mSqlCommadstring = "WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "RP= " & _
                              "ISNULL(WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "RP,0) + " & _
                              nLg(MyRecReadA("mPRT"))
                    Call InputReport(mDLR, "SVC", mNama & "/PARTS", "A5" & mUrut2 & nSr(MyRecReadA("WOHDRPS_KDTAGIH")) & "1-FKT", "")  'A7 A8 A9
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Sub
    Sub Report_Transaksi_Service_Unit_Step02(ByVal mServer As String, ByVal mDLR As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mUrut2 As String
        Dim mNama As String

        Dim mSqlCommadstring As String = "SELECT MONTH(WOHDRPS_TGWO) as mfmonth,WOHDRPS_KDTAGIH,SUPPLIER_NAMA,WOHDRPS_JNSKERJA,count(WOHDRPS_NOWO) as mCNT " & _
            "FROM TRXN_WOHDRPS, DATA_SUPPLIER " & _
            "WHERE WOHDRPS_KDTAGIH=SUPPLIER_KODE AND year(WOHDRPS_TGWO)=YEAR(GETDATE()) group by MONTH(WOHDRPS_TGWO),WOHDRPS_KDTAGIH,SUPPLIER_NAMA,WOHDRPS_JNSKERJA"

        mSqlCommadstring = "SELECT MONTH(WOHDRPS_TGWO) as mfmonth,WOHDRPS_FNRK,count(WOHDRPS_FNRK) as mCNT " & _
                    "FROM TRXN_WOHDRPS " & _
                    "WHERE year(WOHDRPS_TGWO)=YEAR(GETDATE()) group by MONTH(WOHDRPS_TGWO),WOHDRPS_FNRK"
        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mUrut2 = "1"
                    'mNama = nSr(MyRecReadA("WOHDRPS_JNSKERJA"))
                    mNama = "INCOMING UNIT "
                    mSqlCommadstring = "WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "QTY= " & _
                              "ISNULL(WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "QTY,0) + 1 "
                    Call InputReport(mDLR, "SVC", mNama, "A1-UNIT", mSqlCommadstring) 'A2 A3 A4
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Sub
    Sub Report_Transaksi_Service_Unit_Step03(ByVal mServer As String, ByVal mDLR As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mUrut2 As String
        Dim mNama As String


        Dim mSqlCommadstring As String = "select MONTH(WOHDR_TGFAK)as mfmonth,WOHDR_KDTAGIH,SUPPLIER_NAMA,WOHDR_JNSKERJA,count(WOHDR_NO) as mCNT,SUM(WOHDR_TOTSERVICE) as mSVC,SUM(WOHDR_DISC) as mDSC,SUM(WOHDR_TOTPARTS)as mPRT " & _
                    "from TRXN_WOHDR, DATA_SUPPLIER " & _
                    "WHERE WOHDR_KDTAGIH=SUPPLIER_KODE AND year(WOHDR_TGFAK)=YEAR(GETDATE()) group by MONTH(WOHDR_TGFAK),WOHDR_KDTAGIH,SUPPLIER_NAMA,WOHDR_JNSKERJA"
        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mUrut2 = IIf(nSr(MyRecReadA("WOHDR_KDTAGIH")) = "000" And nSr(MyRecReadA("WOHDR_JNSKERJA")) <> "3", "3", IIf(nSr(MyRecReadA("WOHDR_KDTAGIH")) = "A10", "2", "1"))
                    mNama = nSr(MyRecReadA("SUPPLIER_NAMA")) & _
                            IIf(nSr(MyRecReadA("WOHDR_JNSKERJA")) = "3" And nSr(MyRecReadA("WOHDR_KDTAGIH")) = "000", "/BODYREPAIR", "") & IIf(mUrut2 <> 1, " ----", "")

                    mSqlCommadstring = "WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "QTY= " & _
                              "ISNULL(WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "QTY,0) + " & _
                              nLg(MyRecReadA("mCNT")) & "," & _
                              "WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "RP= " & _
                              "ISNULL(WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "RP,0) + " & _
                              nLg(MyRecReadA("mSVC")) - nLg(MyRecReadA("mDSC"))
                    Call InputReport(mDLR, "SVC", mNama & "/JASA", "A5" & mUrut2 & nSr(MyRecReadA("WOHDR_KDTAGIH")) & "0-FKT", mSqlCommadstring)

                    mSqlCommadstring = "WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "RP= " & _
                              "ISNULL(WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "RP,0) + " & _
                              nLg(MyRecReadA("mPRT"))
                    Call InputReport(mDLR, "SVC", mNama & "/PARTS", "A5" & mUrut2 & nSr(MyRecReadA("WOHDR_KDTAGIH")) & "1-FKT", mSqlCommadstring)

                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Sub
    Sub Report_Transaksi_Service_Unit_Step04(ByVal mServer As String, ByVal mDLR As String)
        Dim mpServer As String = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mUrut2 As String
        Dim mNama As String

        Dim mSqlCommadstring As String = "SELECT MONTH(WOHDR_TGWO) as mfmonth,WOHDR_FNRK,count(WOHDR_FNRK) as mCNT " & _
                    "FROM TRXN_WOHDR " & _
                    "WHERE year(WOHDR_TGWO)=YEAR(GETDATE()) group by MONTH(WOHDR_TGWO),WOHDR_FNRK"

        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mUrut2 = "1"
                    'mNama = nSr(MyRecReadA("WOHDRPS_JNSKERJA"))
                    mNama = "INCOMING UNIT "
                    mSqlCommadstring = "WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "QTY= " & _
                              "ISNULL(WEBREPORT_" & Format(nLg(MyRecReadA("mfmonth")), "0#") & "QTY,0) + 1"
                    Call InputReport(mDLR, "SVC", mNama, "A1-UNIT", mSqlCommadstring) 'A2 A3 A4
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
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
    Function InputReportSumary(ByVal mp_DEALER As String, ByVal mp_Query As String, ByVal mp_Group As String, ByVal mp_Judul As String, ByVal mp_Groupby As String) As Byte
        Dim MySTRsql2 As String
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
        MySTRsql1 = "SELECT " & _
                     mp_Groupby & "," & _
                     "SUM(WEBREPORT_01QTY) as m01QTY,SUM(WEBREPORT_01RP) as m01RP," & _
                     "SUM(WEBREPORT_02QTY) as m02QTY,SUM(WEBREPORT_02RP) as m02RP," & _
                     "SUM(WEBREPORT_03QTY) as m03QTY,SUM(WEBREPORT_03RP) as m03RP," & _
                     "SUM(WEBREPORT_04QTY) as m04QTY,SUM(WEBREPORT_04RP) as m04RP," & _
                     "SUM(WEBREPORT_05QTY) as m05QTY,SUM(WEBREPORT_05RP) as m05RP," & _
                     "SUM(WEBREPORT_06QTY) as m06QTY,SUM(WEBREPORT_06RP) as m06RP," & _
                     "SUM(WEBREPORT_07QTY) as m07QTY,SUM(WEBREPORT_07RP) as m07RP," & _
                     "SUM(WEBREPORT_08QTY) as m08QTY,SUM(WEBREPORT_08RP) as m08RP," & _
                     "SUM(WEBREPORT_09QTY) as m09QTY,SUM(WEBREPORT_09RP) as m09RP," & _
                     "SUM(WEBREPORT_10QTY) as m10QTY,SUM(WEBREPORT_10RP) as m10RP," & _
                     "SUM(WEBREPORT_11QTY) as m11QTY,SUM(WEBREPORT_11RP) as m11RP," & _
                     "SUM(WEBREPORT_12QTY) as m12QTY,SUM(WEBREPORT_12RP) as m12RP" & _
                     " FROM TEMP_WEBREPORT WHERE WEBREPORT_DEALER='" & mp_DEALER & "' "

        MySTRsql2 = MySTRsql1 & mp_Query

        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    MySTRsql1 = "INSERT INTO TEMP_WEBREPORT (WEBREPORT_DEALER,WEBREPORT_DEPT,WEBREPORT_GROUP,WEBREPORT_NAMA," & _
                                "WEBREPORT_01QTY,WEBREPORT_01RP,WEBREPORT_02QTY,WEBREPORT_02RP,WEBREPORT_03QTY,WEBREPORT_03RP," & _
                                "WEBREPORT_04QTY,WEBREPORT_04RP,WEBREPORT_05QTY,WEBREPORT_05RP,WEBREPORT_06QTY,WEBREPORT_06RP," & _
                                "WEBREPORT_07QTY,WEBREPORT_07RP,WEBREPORT_08QTY,WEBREPORT_08RP,WEBREPORT_09QTY,WEBREPORT_09RP," & _
                                "WEBREPORT_10QTY,WEBREPORT_10RP,WEBREPORT_11QTY,WEBREPORT_11RP,WEBREPORT_12QTY,WEBREPORT_12RP,WEBREPORT_TGL) VALUES " & _
                                "('" & mp_DEALER & "','SVC','" & mp_Group & "','" & mp_Judul & "'," & _
                                nLg(MyRecReadA("m01QTY")) & "," & nLg(MyRecReadA("m01RP")) & "," & nLg(MyRecReadA("m02QTY")) & "," & nLg(MyRecReadA("m02RP")) & "," & nLg(MyRecReadA("m03QTY")) & "," & nLg(MyRecReadA("m03RP")) & "," & _
                                nLg(MyRecReadA("m04QTY")) & "," & nLg(MyRecReadA("m04RP")) & "," & nLg(MyRecReadA("m05QTY")) & "," & nLg(MyRecReadA("m05RP")) & "," & nLg(MyRecReadA("m06QTY")) & "," & nLg(MyRecReadA("m06RP")) & "," & _
                                nLg(MyRecReadA("m07QTY")) & "," & nLg(MyRecReadA("m07RP")) & "," & nLg(MyRecReadA("m08QTY")) & "," & nLg(MyRecReadA("m08RP")) & "," & nLg(MyRecReadA("m09QTY")) & "," & nLg(MyRecReadA("m09RP")) & "," & _
                                nLg(MyRecReadA("m10QTY")) & "," & nLg(MyRecReadA("m10RP")) & "," & nLg(MyRecReadA("m11QTY")) & "," & nLg(MyRecReadA("m11RP")) & "," & nLg(MyRecReadA("m12QTY")) & "," & nLg(MyRecReadA("m12RP")) & "," & _
                                "GETDATE())"
                    Call UpdateDatabase_Tabel(MySTRsql2, "")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try


    End Function


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
            Call Msg_err("error " & ex.Message)
        End Try
    End Function
    Function UpdateDatabase_Tabel(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        If mpServer = "" Then
            mpServer = "MyConnCloudDnet" & mpServer
        Else
            mpServer = "MyConnCloudDnetSvcs" & mpServer
        End If
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
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
            Call Msg_err(ex.Message)
        End Try
    End Function
    Function GetDataD_IsiField(ByVal mSqlCommadstring As String, ByVal mpServer As String) As String
        If mpServer = "" Then
            mpServer = "MyConnCloudDnet" & mpServer
        Else
            mpServer = "MyConnCloudDnetSvcs" & mpServer
        End If
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
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
            Call Msg_err(ex.Message)
        End Try
    End Function
    Function GetDataD_00NoFound01Found(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        If mpServer = "" Then
            mpServer = "MyConnCloudDnet" & mpServer
        Else
            mpServer = "MyConnCloudDnetSvcs" & mpServer
        End If
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
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
            Call Msg_err(ex.Message)
        End Try
    End Function

End Class
