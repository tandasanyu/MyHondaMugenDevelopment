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


Partial Class Form0202StatusSPK00Asli
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
            LblUserName.Text = ucase(x.ToString)
            mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0105'")
            TxtPartsLantai.Text = "KODE LANTAI"
            MultiViewSuportLaporan1dan2.ActiveViewIndex = -1
            TxtCabang.Text = lblArea1.Text
            If mFound = 1 Then
                MultiViewMenu.ActiveViewIndex = 0
                If Mid(lblAkses.Text, 4, 1) = "1" Then
                    MultiViewForm.ActiveViewIndex = 0
                    MultiViewSuportLaporan1dan2.ActiveViewIndex = 0
                ElseIf Mid(lblAkses.Text, 5, 1) = "1" Then
                    MultiViewForm.ActiveViewIndex = 1
                    MultiViewSuportLaporan1dan2.ActiveViewIndex = 0
                ElseIf Mid(lblAkses.Text, 6, 1) = "1" Then
                    MultiViewForm.ActiveViewIndex = 3
                Else '123 7
                    MultiViewForm.ActiveViewIndex = 2
                    Call Tampil(0, -1, -1, -1)
                    lblQueryServiceNamaPSM.Text = ""
                    lblQueryServiceHistPSM.Text = ""
                    lblQuerySalesHistPSM.Text = ""

                    lblQueryServiceNamaPuri.Text = ""
                    lblQueryServiceHistPuri.Text = ""

                    lblQueryServiceNamaPSM.Text = "TIDAK DIKETEMUKAN"
                    lblQueryServiceHistPSM.Text = ""
                    lblQuerySalesHistPSM.Text = ""

                    lblQueryServiceNamaPuri.Text = "TIDAK DIKETEMUKAN"
                    lblQueryServiceHistPuri.Text = ""
                    lblQuerySalesHistPuri.Text = ""

                End If
            Else
                MultiViewMenu.ActiveViewIndex = -1
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

    Sub Tampil(ByVal mFormQuery As Integer, ByVal mFormAudit As Integer, ByVal mTabelParts As Integer, ByVal mTabelAudit As Integer)
        MultiViewForm21Query.ActiveViewIndex = mFormQuery
        MultiViewForm22Audit.ActiveViewIndex = mFormAudit

        If mFormAudit = -1 Then
            MultiViewForm22AuditTombol.ActiveViewIndex = mFormAudit
            MultiViewForm22AuditNote2.ActiveViewIndex = mFormAudit
            MultiViewForm22AuditNote2Tombol.ActiveViewIndex = mFormAudit
            MultiViewForm22HeadPartsNote1.ActiveViewIndex = mFormAudit
            MultiViewForm22HeadPartsNote1Tombol.ActiveViewIndex = mFormAudit
            MultiViewForm22SM.ActiveViewIndex = mFormAudit
            MultiViewForm22SMTombol.ActiveViewIndex = mFormAudit
            MultiViewForm22ACCFIN.ActiveViewIndex = mFormAudit
            MultiViewForm22ACCFINTombol.ActiveViewIndex = mFormAudit

        ElseIf mFormAudit = 0 Then
            MultiViewForm22Audit.ActiveViewIndex = 0
            MultiViewForm22AuditTombol.ActiveViewIndex = IIf(Mid(lblAkses.Text, 2, 1) = "1", 0, -1)
            MultiViewForm22AuditNote2.ActiveViewIndex = 0
            MultiViewForm22AuditNote2Tombol.ActiveViewIndex = IIf(Mid(lblAkses.Text, 7, 1) = "1", 0, -1)
            MultiViewForm22HeadPartsNote1.ActiveViewIndex = 0
            MultiViewForm22HeadPartsNote1Tombol.ActiveViewIndex = IIf(Mid(lblAkses.Text, 3, 1) = "1", 0, -1)
            MultiViewForm22SM.ActiveViewIndex = 0
            MultiViewForm22SMTombol.ActiveViewIndex = IIf(Mid(lblAkses.Text, 8, 1) = "1", 0, -1)
            MultiViewForm22ACCFIN.ActiveViewIndex = 0
            MultiViewForm22ACCFINTombol.ActiveViewIndex = IIf(Mid(lblAkses.Text, 9, 1) = "1", 0, -1)
        End If

        If InStr(TxtCabang.Text, "112") <> 0 Then
            MultiViewTabelStokPart112.ActiveViewIndex = mTabelParts
            MultiViewTabelAudit112.ActiveViewIndex = mTabelAudit
        Else
            MultiViewTabelStokPart128.ActiveViewIndex = mTabelParts
            MultiViewTabelAudit128.ActiveViewIndex = mTabelAudit
        End If

    End Sub

    Protected Sub BtnLaporanServiceUnit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLaporanServiceUnit.Click
        If Mid(lblAkses.Text, 4, 1) = "1" Then
            MultiViewForm.ActiveViewIndex = 0
        Else
            MultiViewForm.ActiveViewIndex = -1
        End If

    End Sub
    Protected Sub BtnForm01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnForm01.Click
        MultiViewForm0.ActiveViewIndex = 0
        MultiViewSuportLaporan1dan2.ActiveViewIndex = 0
        MultiViewForm.ActiveViewIndex = 0
        Call Report_Transaksi_Service_Unit()
        LvWO.DataBind()
    End Sub
    Protected Sub BtnForm02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnForm02.Click
        MultiViewForm0.ActiveViewIndex = 1
    End Sub

    Protected Sub BtnLaporanServicePiutang_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLaporanServicePiutang.Click
        If Mid(lblAkses.Text, 5, 1) = "1" Then
            MultiViewSuportLaporan1dan2.ActiveViewIndex = 0
            MultiViewForm.ActiveViewIndex = 1
            Call Report_Web_SERVICE_ARPIUTANG()
            LVWOPiutang.DataBind()
        Else
            MultiViewForm.ActiveViewIndex = -1
        End If
    End Sub
    Protected Sub BtnAudit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAudit.Click
        If Mid(lblAkses.Text, 1, 1) = "1" Then
            MultiViewForm.ActiveViewIndex = 2
        Else
            MultiViewForm.ActiveViewIndex = -1
        End If
    End Sub
    Protected Sub BtnStatusMobil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStatusMobil.Click
        If Mid(lblAkses.Text, 6, 1) = "1" Then
            MultiViewForm.ActiveViewIndex = 3
        Else
            MultiViewForm.ActiveViewIndex = -1
        End If
    End Sub



    'Laporan1
    Function Report_Transaksi_Service_Unit() As Byte
        Dim mNama As String = ""
        Dim MyDealer As String = ""

        Report_Transaksi_Service_Unit = 0
        Try
            If CheckBoxPerbarui.Checked = True Then
                MySTRsql1 = "DELETE FROM TEMP_WEBREPORT WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='A'"
                Call UpdateDatabase_Tabel(MySTRsql1, "")
            End If

            Call MsgProses("Tunggu Sedang Proses Ambil Data Transaksi Service untuk Ps Munggu dan Puri", 1)
            For mProses = 1 To 2
                If mProses = 1 Then
                    MyDealer = "112"
                Else
                    MyDealer = "128"
                End If

                MySTRsql1 = "SELECT * FROM TEMP_WEBREPORT WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='A' AND WEBREPORT_DEALER='" & MyDealer & "' AND DATEDIFF(DAY,WEBREPORT_TGL,GETDATE())=0"
                If GetDataD_00NoFound01Found(MySTRsql1, "") <> 1 Then

                    MySTRsql1 = "DELETE FROM TEMP_WEBREPORT WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='A' AND WEBREPORT_DEALER='" & MyDealer & "'"
                    Call UpdateDatabase_Tabel(MySTRsql1, "")
                    LvWO.DataBind()

                    'Post Cari Faktur/Close  WOHDRPS_JNSKERJA=3 Bodyrepair
                    Call Report_Transaksi_Service_Unit_Step01("Svcs" & MyDealer, MyDealer)
                    'Post Cari Incoming WO
                    Call Report_Transaksi_Service_Unit_Step02("Svcs" & MyDealer, MyDealer)
                    'Post Cari Incoming Uang
                    Call Report_Transaksi_Service_Unit_Step03("Svcs" & MyDealer, MyDealer)
                    'Post Cari Incoming Uang
                    Call Report_Transaksi_Service_Unit_Step03("Svcs" & MyDealer, MyDealer)

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

                    Call InputReport(MyDealer, "SVC", "*============================", "A51Z1-FAKTUR", "")
                    Call InputReportSumary(MyDealer, " AND WEBREPORT_DEALER='" & MyDealer & "' AND SUBSTRING(WEBREPORT_GROUP,1,3)= 'A51' AND WEBREPORT_GROUP LIKE '%0-FKT' GROUP BY SUBSTRING(WEBREPORT_GROUP,1,3)", _
                                           "A51Z2-FAKTUR", "--- TOTAL FAKTUR BODYREPAIR JASA ------", "SUBSTRING(WEBREPORT_GROUP,1,3)")
                    Call InputReportSumary(MyDealer, " AND WEBREPORT_DEALER='" & MyDealer & "' AND SUBSTRING(WEBREPORT_GROUP,1,3)= 'A51' AND WEBREPORT_GROUP LIKE '%1-FKT' GROUP BY SUBSTRING(WEBREPORT_GROUP,1,3)", _
                                           "A51Z2-FAKTUR", "--- TOTAL FAKTUR BODYREPAIR PARTS ------", "SUBSTRING(WEBREPORT_GROUP,1,3)")
                    Call InputReport(MyDealer, "SVC", "**============================", "A51Z3", "")

                    Call InputReport(MyDealer, "SVC", "***============================", "A52Z-FAKTUR", "")
                    Call InputReport(MyDealer, "SVC", "****============================", "A539-FAKTUR", "")

                    Call InputReport(MyDealer, "SVC", "*****============================", "A7-FAKTUR", "")
                    Call InputReportSumary(MyDealer, " AND WEBREPORT_DEALER='" & MyDealer & "' AND SUBSTRING(WEBREPORT_GROUP,1,2)= 'A5' AND WEBREPORT_GROUP<>'A51Z2-FAKTUR' AND WEBREPORT_GROUP LIKE '%0-FKT' GROUP BY SUBSTRING(WEBREPORT_GROUP,1,2)", _
                                           "A8-FAKTUR", "--- TOTAL KESELURUHAN FAKTUR JASA  ------", "SUBSTRING(WEBREPORT_GROUP,1,2)")
                    Call InputReportSumary(MyDealer, " AND WEBREPORT_DEALER='" & MyDealer & "' AND SUBSTRING(WEBREPORT_GROUP,1,2)= 'A5' AND WEBREPORT_GROUP<>'A51Z2-FAKTUR' AND WEBREPORT_GROUP LIKE '%1-FKT' GROUP BY SUBSTRING(WEBREPORT_GROUP,1,2)", _
                                           "A8-FAKTUR", "--- TOTAL KESELURUHAN FAKTUR PARTS  ------", "SUBSTRING(WEBREPORT_GROUP,1,2)")
                    Call InputReport(MyDealer, "SVC", "******============================", "A9-FAKTUR", "")
                End If
            Next
            Call MsgProses("Proses Baca Data Selesai", 0)
            CheckBoxPerbarui.Checked = False
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


    'Laporan2
    Function Report_Web_SERVICE_ARPIUTANG() As Byte
        Report_Web_SERVICE_ARPIUTANG = 0
        Try
            Dim mDealer As String = "112"
            If CheckBoxPerbarui.Checked = True Then
                MySTRsql1 = "DELETE FROM TEMP_WEBREPORT WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='B'"
                Call UpdateDatabase_Tabel(MySTRsql1, "")
            End If

            Call MsgProses("Tunggu Sedang Proses Ambil Data Piutang Service untuk Ps Munggu dan Puri", 1)
            For mProses = 1 To 2
                If mProses = 1 Then
                    mDealer = "112"
                Else
                    mDealer = "128"
                End If
                MySTRsql1 = "SELECT * FROM TEMP_WEBREPORT WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='B' AND WEBREPORT_DEALER='" & mDealer & "' AND DATEDIFF(DAY,WEBREPORT_TGL,GETDATE())=0"
                If GetDataD_00NoFound01Found(MySTRsql1, "") <> 1 Then

                    MySTRsql1 = "DELETE FROM TEMP_WEBREPORT WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='B' AND WEBREPORT_DEALER='" & mDealer & "'"
                    Call UpdateDatabase_Tabel(MySTRsql1, "")

                    Call INSERT_SISAKREDITCURRENT(mDealer)

                    'Call INSERT_TMPTRXNPARTCURRENT()

                    'Post Cari Faktur/Close  WOHDRPS_JNSKERJA=3 Bodyrepair

                    Call InsertOK(" DATEDIFF(DAY,TRXNOLI_TGL,GETDATE()) <=0 ", "01", mDealer)
                    Call InsertOK(" DATEDIFF(DAY,TRXNOLI_TGL,GETDATE()) >0 AND DATEDIFF(DAY,TRXNOLI_TGL,GETDATE()) <= 7 ", "02", mDealer)
                    Call InsertOK(" DATEDIFF(DAY,TRXNOLI_TGL,GETDATE()) >7 AND DATEDIFF(DAY,TRXNOLI_TGL,GETDATE()) <= 15 ", "03", mDealer)
                    Call InsertOK(" DATEDIFF(DAY,TRXNOLI_TGL,GETDATE()) >15 AND DATEDIFF(DAY,TRXNOLI_TGL,GETDATE()) <= 23 ", "04", mDealer)
                    Call InsertOK(" DATEDIFF(DAY,TRXNOLI_TGL,GETDATE()) >23 AND DATEDIFF(DAY,TRXNOLI_TGL,GETDATE()) <= 31 ", "05", mDealer)
                    Call InsertOK(" DATEDIFF(DAY,TRXNOLI_TGL,GETDATE()) >31 ", "06", mDealer)

                    Call Report_Web_SERVICE_ARPIUTANG_Step1(mDealer)

                    Call Report_Web_SERVICE_ARPIUTANG_Step2(mDealer)

                End If
            Next
            Call MsgProses("Proses Baca Data Selesai", 0)
            CheckBoxPerbarui.Checked = False
            Report_Web_SERVICE_ARPIUTANG = 1
        Catch ex As Exception
            Report_Web_SERVICE_ARPIUTANG = 0
        End Try
    End Function
    Sub INSERT_SISAKREDITCURRENT(ByVal mServer As String)

        Dim mVOcher As String = "ZZZZ"

        MySTRsql1 = "DELETE FROM TEMP_TRXNOLI"
        Call UpdateDatabase_Tabel(MySTRsql1, "Svcs" & mServer)

        MySTRsql1 = "INSERT TEMP_TRXNOLI " & _
                    "SELECT WOHUT_TGFAK,WOHUT_FPOL,WOHUT_NOWO,WOHUT_FORG,WOHUT_RPKRE,'1','" & mVOcher & "',WOHUT_TGLUN,'' " & "FROM TRXN_WOHUT WHERE ISNULL(WOHUT_RPKRE,0) <> 0 "
        Call UpdateDatabase_Tabel(MySTRsql1, "Svcs" & mServer)

        MySTRsql1 = "INSERT TEMP_TRXNOLI " & _
                    "SELECT WOHDR_TGFAK,WOHDR_FNOPOL,WOHDR_NO,WOHDR_FORG,WOHDR_RPKREDIT,'2','" & mVOcher & "',NULL,'' " & "FROM TRXN_WOHDR WHERE WOHDR_SWO='1' AND WOHDR_JENISBY=7 AND (SELECT WOHUT_NOWO FROM TRXN_WOHUT WHERE WOHUT_NOWO=WOHDR_NO) IS NULL"
        Call UpdateDatabase_Tabel(MySTRsql1, "Svcs" & mServer)

        '             "TRXNOLI_KET2=(SELECT SUBSTRING(WOHDR_JNSKERJA+WOHDR_SA)  FROM TRXN_WOHDR WHERE WOHDR_NO=TRXNOLI_NOFAK)  " & _
        MySTRsql1 = "UPDATE TEMP_TRXNOLI SET " & _
                    "TRXNOLI_KET2=(SELECT WOHDR_SA  FROM TRXN_WOHDR WHERE WOHDR_NO=TRXNOLI_NOFAK)  " & _
                    "              " & _
                    "WHERE (SELECT WOHDR_NO FROM TRXN_WOHDR WHERE WOHDR_NO=TRXNOLI_NOFAK) IS NOT NULL"
        Call UpdateDatabase_Tabel(MySTRsql1, "Svcs" & mServer)

        '            "TRXNOLI_KET2=(SELECT SUBSTRING(WOHDRPS_JNSKERJA+WOHDRPS_SA) FROM TRXN_WOHDRPS WHERE WOHDRPS_NOWO=TRXNOLI_NOFAK)  " & _
        MySTRsql1 = "UPDATE TEMP_TRXNOLI SET " & _
                    "TRXNOLI_KET2=(SELECT WOHDRPS_SA FROM TRXN_WOHDRPS WHERE WOHDRPS_NOWO=TRXNOLI_NOFAK)  " & _
                    "              " & _
                    "WHERE (SELECT WOHDRPS_NOWO FROM TRXN_WOHDRPS WHERE WOHDRPS_NOWO=TRXNOLI_NOFAK) IS NOT NULL"
        Call UpdateDatabase_Tabel(MySTRsql1, "Svcs" & mServer)


        MySTRsql1 = "UPDATE TEMP_TRXNOLI SET " & _
                    "TRXNOLI_KET=(SELECT SUPPLIER_NAMA FROM TRXN_WOHDR,DATA_SUPPLIER WHERE WOHDR_NO=TRXNOLI_NOFAK AND WOHDR_KDTAGIH=SUPPLIER_KODE) " & _
                    "WHERE (SELECT WOHDR_NO FROM TRXN_WOHDR WHERE WOHDR_NO=TRXNOLI_NOFAK AND WOHDR_KDTAGIH <>'000') IS NOT NULL"
        Call UpdateDatabase_Tabel(MySTRsql1, "Svcs" & mServer)

        MySTRsql1 = "UPDATE TEMP_TRXNOLI SET " & _
                    "TRXNOLI_KET=(SELECT SUPPLIER_NAMA FROM TRXN_WOHDRPS,DATA_SUPPLIER WHERE WOHDRPS_NOWO=TRXNOLI_NOFAK AND WOHDRPS_KDTAGIH=SUPPLIER_KODE) " & _
                    "WHERE (SELECT WOHDRPS_NOWO FROM TRXN_WOHDRPS WHERE WOHDRPS_NOWO=TRXNOLI_NOFAK  AND WOHDRPS_KDTAGIH <>'000') IS NOT NULL"
        Call UpdateDatabase_Tabel(MySTRsql1, "Svcs" & mServer)

        Dim mTotal As Double
        Dim TotalService As Double
        Dim TotalDisc As Double
        Dim TotalParts As Double
        Dim TotalTemp As Double

        mTotal = 0

        Dim mpServer As String = "MyConnCloudDnet" & "Svcs" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand


        Dim mSqlCommadstring As String = "SELECT * FROM TEMP_TRXNOLI WHERE TRXNOLI_SP='2'"

        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mTotal = 0

                    TotalService = ndb(GetDataD_IsiField("SELECT WOHDR_TOTSERVICE as IsiField FROM TRXN_WOHDR WHERE WOHDR_NO='" & Trim(nSr(MyRecReadA("TRXNOLI_NOFAK"))) & "'", mServer))
                    TotalDisc = ndb(GetDataD_IsiField("SELECT WOHDR_DISC as IsiField FROM TRXN_WOHDR WHERE WOHDR_NO='" & Trim(nSr(MyRecReadA("TRXNOLI_NOFAK"))) & "'", mServer))
                    TotalParts = ndb(GetDataD_IsiField("SELECT WOHDR_TOTPARTS as IsiField FROM TRXN_WOHDR WHERE WOHDR_NO='" & Trim(nSr(MyRecReadA("TRXNOLI_NOFAK"))) & "'", mServer))

                    mTotal = nLg(Int(1.1 * ((ndb((TotalService)) - ndb((TotalDisc))) + ndb((TotalParts)))))

                    'mTotal = nDb((MyReadDataTbl2("TRXNOLI_QTY")))
                    TotalTemp = ndb(GetDataD_IsiField("SELECT SUM(WOLNS_RPLUN) AS IsiField FROM TRXN_WOLNS   WHERE   WOLNS_NOWO='" & Trim(nSr(MyRecReadA("TRXNOLI_NOFAK"))) & "' GROUP BY WOLNS_NOWO", mServer))
                    mTotal = mTotal - ndb(TotalTemp)

                    TotalTemp = ndb(GetDataD_IsiField("SELECT SUM(WOLNSPS_RPLUN) AS IsiField FROM TRXN_WOLNSPS WHERE WOLNSPS_NOWO='" & Trim(nSr(MyRecReadA("TRXNOLI_NOFAK"))) & "' GROUP BY WOLNSPS_NOWO", mServer))
                    mTotal = mTotal - ndb(TotalTemp)

                    TotalTemp = ndb(GetDataD_IsiField("SELECT SUM(LUNAS_RP) AS IsiField FROM TRXN_LUNAS   WHERE     LUNAS_NO='" & Trim(nSr(MyRecReadA("TRXNOLI_NOFAK"))) & "' AND LUNAS_SP='2' GROUP BY LUNAS_NO", mServer))
                    mTotal = mTotal - ndb(TotalTemp)

                    MySTRsql1 = "UPDATE TEMP_TRXNOLI SET TRXNOLI_QTY = " & mTotal & " WHERE TRXNOLI_NOFAK='" & Trim(nSr(MyRecReadA("TRXNOLI_NOFAK"))) & "'"
                    Call UpdateDatabase_Tabel(MySTRsql1, "Svcs" & mServer)
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Sub
    Function InsertOK(ByVal Query As String, ByVal mMode As String, ByVal mServer As String) As Byte
        Dim mpServer As String = "MyConnCloudDnet" & "Svcs" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mNama As String
        Dim mKode As String
        Dim mSqlCommadstring As String = "SELECT TRXNOLI_KET,TRXNOLI_KET2,SUM(TRXNOLI_QTY) as mKredit,(SELECT SUPPLIER_KODE FROM DATA_SUPPLIER WHERE SUPPLIER_NAMA=TRXNOLI_KET) as mKodeSup FROM TEMP_TRXNOLI " & _
             "WHERE " & Query & " GROUP BY TRXNOLI_KET,TRXNOLI_KET2"

        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mNama = IIf(nSr(MyRecReadA("mKodeSup")) = "", "PRIBADI", nSr(MyRecReadA("TRXNOLI_KET")))
                    mKode = IIf(nSr(MyRecReadA("mKodeSup")) = "", "000", nSr(MyRecReadA("mKodeSup")))
                    mSqlCommadstring = "WEBREPORT_" & mMode & "RP= ISNULL(WEBREPORT_" & mMode & "RP,0) + " & _
                              ndb(MyRecReadA("mKredit"))
                    Call InputReport(mServer, "SVC", mNama, "B-" & mKode & "/" & nSr(MyRecReadA("TRXNOLI_KET2")), mSqlCommadstring)
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Function
    Sub Report_Web_SERVICE_ARPIUTANG_Step1(ByVal mServer As String)
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                        "SELECT SUBSTRING(WEBREPORT_GROUP,1,5) as mKode," & _
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
                        " FROM TEMP_WEBREPORT WHERE WEBREPORT_DEALER='" & mServer & "' AND SUBSTRING(WEBREPORT_GROUP,1,1)= 'B' GROUP BY SUBSTRING(WEBREPORT_GROUP,1,5)"
        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    Call InputReport(mServer, "SVC", "---------------", "" & nSr(MyRecReadA("mKode")) & "/ZTOT1", "")


                    MySTRsql1 = "INSERT INTO TEMP_WEBREPORT (WEBREPORT_DEALER,WEBREPORT_DEPT,WEBREPORT_GROUP,WEBREPORT_NAMA," & _
                                "WEBREPORT_01QTY,WEBREPORT_01RP,WEBREPORT_02QTY,WEBREPORT_02RP,WEBREPORT_03QTY,WEBREPORT_03RP," & _
                                "WEBREPORT_04QTY,WEBREPORT_04RP,WEBREPORT_05QTY,WEBREPORT_05RP,WEBREPORT_06QTY,WEBREPORT_06RP," & _
                                "WEBREPORT_07QTY,WEBREPORT_07RP,WEBREPORT_08QTY,WEBREPORT_08RP,WEBREPORT_09QTY,WEBREPORT_09RP," & _
                                "WEBREPORT_10QTY,WEBREPORT_10RP,WEBREPORT_11QTY,WEBREPORT_11RP,WEBREPORT_12QTY,WEBREPORT_12RP,WEBREPORT_TGL) VALUES " & _
                                "('" & mServer & "','SVC','" & nSr(MyRecReadA("mKode")) & "/ZTOT2-GROUP" & "',''," & _
                                nLg(MyRecReadA("m01QTY")) & "," & nLg(MyRecReadA("m01RP")) & "," & nLg(MyRecReadA("m02QTY")) & "," & nLg(MyRecReadA("m02RP")) & "," & nLg(MyRecReadA("m03QTY")) & "," & nLg(MyRecReadA("m03RP")) & "," & _
                                nLg(MyRecReadA("m04QTY")) & "," & nLg(MyRecReadA("m04RP")) & "," & nLg(MyRecReadA("m05QTY")) & "," & nLg(MyRecReadA("m05RP")) & "," & nLg(MyRecReadA("m06QTY")) & "," & nLg(MyRecReadA("m06RP")) & "," & _
                                nLg(MyRecReadA("m07QTY")) & "," & nLg(MyRecReadA("m07RP")) & "," & nLg(MyRecReadA("m08QTY")) & "," & nLg(MyRecReadA("m08RP")) & "," & nLg(MyRecReadA("m09QTY")) & "," & nLg(MyRecReadA("m09RP")) & "," & _
                                nLg(MyRecReadA("m10QTY")) & "," & nLg(MyRecReadA("m10RP")) & "," & nLg(MyRecReadA("m11QTY")) & "," & nLg(MyRecReadA("m11RP")) & "," & nLg(MyRecReadA("m12QTY")) & "," & nLg(MyRecReadA("m12RP")) & "," & _
                                "GETDATE())"
                    Call UpdateDatabase_Tabel(mSqlCommadstring, "")

                    Call InputReport(mServer, "SVC", "---------------", "" & nSr(MyRecReadA("mKode")) & "/ZTOT3", "")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Sub
    Sub Report_Web_SERVICE_ARPIUTANG_Step2(ByVal mServer As String)
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                        "SELECT " & _
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
                        " FROM TEMP_WEBREPORT WHERE WEBREPORT_DEALER='" & mServer & "' AND SUBSTRING(WEBREPORT_GROUP,1,1)= 'B' AND NOT( WEBREPORT_GROUP like '%/ZTOT%')"
        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    Call InputReport(mServer, "SVC", "---------------", "B-ZTOTAL1", "")

                    MySTRsql1 = "INSERT INTO TEMP_WEBREPORT (WEBREPORT_DEALER,WEBREPORT_DEPT,WEBREPORT_GROUP,WEBREPORT_NAMA," & _
                                "WEBREPORT_01QTY,WEBREPORT_01RP,WEBREPORT_02QTY,WEBREPORT_02RP,WEBREPORT_03QTY,WEBREPORT_03RP," & _
                                "WEBREPORT_04QTY,WEBREPORT_04RP,WEBREPORT_05QTY,WEBREPORT_05RP,WEBREPORT_06QTY,WEBREPORT_06RP," & _
                                "WEBREPORT_07QTY,WEBREPORT_07RP,WEBREPORT_08QTY,WEBREPORT_08RP,WEBREPORT_09QTY,WEBREPORT_09RP," & _
                                "WEBREPORT_10QTY,WEBREPORT_10RP,WEBREPORT_11QTY,WEBREPORT_11RP,WEBREPORT_12QTY,WEBREPORT_12RP,WEBREPORT_TGL) VALUES " & _
                                "('" & mServer & "','SVC','B-ZTOTAL2-ALL',''," & _
                                nLg(MyRecReadA("m01QTY")) & "," & nLg(MyRecReadA("m01RP")) & "," & nLg(MyRecReadA("m02QTY")) & "," & nLg(MyRecReadA("m02RP")) & "," & nLg(MyRecReadA("m03QTY")) & "," & nLg(MyRecReadA("m03RP")) & "," & _
                                nLg(MyRecReadA("m04QTY")) & "," & nLg(MyRecReadA("m04RP")) & "," & nLg(MyRecReadA("m05QTY")) & "," & nLg(MyRecReadA("m05RP")) & "," & nLg(MyRecReadA("m06QTY")) & "," & nLg(MyRecReadA("m06RP")) & "," & _
                                nLg(MyRecReadA("m07QTY")) & "," & nLg(MyRecReadA("m07RP")) & "," & nLg(MyRecReadA("m08QTY")) & "," & nLg(MyRecReadA("m08RP")) & "," & nLg(MyRecReadA("m09QTY")) & "," & nLg(MyRecReadA("m09RP")) & "," & _
                                nLg(MyRecReadA("m10QTY")) & "," & nLg(MyRecReadA("m10RP")) & "," & nLg(MyRecReadA("m11QTY")) & "," & nLg(MyRecReadA("m11RP")) & "," & nLg(MyRecReadA("m12QTY")) & "," & nLg(MyRecReadA("m12RP")) & "," & _
                                "GETDATE())"
                    Call UpdateDatabase_Tabel(mSqlCommadstring, "")

                    Call InputReport(mServer, "SVC", "---------------", "B-ZTOTAL3", "")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Sub

    'Audit
    Function GetDataA_DetailParts(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnetSvcs" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetDataA_DetailParts = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_DetailParts = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                TxtPartsLantaiku.Text = (nSr(MyRecReadA("PARTS_LOKASI")))
                If TxtPartsLantaiku.Text = "NONE" Then
                    TxtPartsLantaiku.Enabled = True
                Else
                    TxtPartsLantaiku.Enabled = False
                End If
                LblPartsNo.Text = (nSr(MyRecReadA("PARTS_NO")))
                LblPartsNama.Text = (nSr(MyRecReadA("PARTS_NAMA")))
                LblPartsStk.Text = (nSr(MyRecReadA("PARTS_STOCK")))
                LblPartsPickup.Text = (nSr(MyRecReadA("PARTS_QYPESAN")))
                LblPartsActual.Text = Val(nSr(MyRecReadA("PARTS_STOCK"))) - Val(nSr(MyRecReadA("PARTS_QYPESAN")))
                TxtPartsAuditQty.Text = LblPartsActual.Text
                TxtPartsAuditNote.Text = ""
                LblPartsUserNma.Text = LblUserName.Text
                LblPartsUserTgl.Text = ""
                LblPartsStokTgl.Text = (nSr(MyRecReadA("mTGLSekarang")))
                LblPartsStatusSimpan.Text = ""

                lblHeadPartsTgl.Text = ""
                lblHeadPartsUser.Text = ""
                TxtHeadPartsNote.Text = ""

                TxtAuditorAdjemsnt.Text = ""
                TxtAuditorNote.Text = ""
                LblAuditorUser.Text = ""
                LblAuditorTgl.Text = ""

            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function GetDataA_DetailPartsAudit(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnetSvcs" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetDataA_DetailPartsAudit = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_DetailPartsAudit = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                TxtPartsLantaiku.Text = (nSr(MyRecReadA("PARTS_LOKASI")))
                If TxtPartsLantaiku.Text = "NONE" Then
                    TxtPartsLantaiku.Enabled = True
                Else
                    TxtPartsLantaiku.Enabled = False
                End If
                LblPartsNo.Text = (nSr(MyRecReadA("PARTS_NO")))
                LblPartsNama.Text = (nSr(MyRecReadA("PARTS_NAMA")))
                LblPartsStk.Text = (nSr(MyRecReadA("PARTS_STOCK")))
                LblPartsPickup.Text = (nSr(MyRecReadA("PARTS_QYPESAN")))
                LblPartsActual.Text = Val(nSr(MyRecReadA("PARTS_STOCK"))) - Val(nSr(MyRecReadA("PARTS_QYPESAN")))
                TxtPartsAuditQty.Text = (nSr(MyRecReadA("AUDITPART_QTY")))
                TxtPartsAuditNote.Text = (nSr(MyRecReadA("AUDITPART_CATATAN")))
                LblPartsUserNma.Text = (nSr(MyRecReadA("AUDITPART_USER")))
                LblPartsUserTgl.Text = (nSr(MyRecReadA("AUDITPART_TGL")))
                LblPartsStokTgl.Text = (nSr(MyRecReadA("mTGLSekarang")))
                LblPartsStatusSimpan.Text = ""

                TxtHeadPartsNote.Text = (nSr(MyRecReadA("AUDITPART_NOTE1")))
                lblHeadPartsTgl.Text = (nSr(MyRecReadA("AUDITPART_NOTE1TGL")))
                lblHeadPartsUser.Text = (nSr(MyRecReadA("AUDITPART_NOTE1USR")))

                TxtAuditorNote.Text = (nSr(MyRecReadA("AUDITPART_NOTE2")))
                TxtAuditorAdjemsnt.Text = (nSr(MyRecReadA("AUDITPART_NOTE2ADJ")))
                LblAuditorUser.Text = (nSr(MyRecReadA("AUDITPART_NOTE2USR")))
                LblAuditorTgl.Text = (nSr(MyRecReadA("AUDITPART_NOTE2TGL")))

            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Protected Sub lvStockPart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvStockPart.SelectedIndexChanged
        '    Call clearInput()
        LblPartsNo.Text = (lvStockPart.DataKeys(lvStockPart.SelectedIndex).Value.ToString)

        If GetDataA_DetailPartsAudit("SELECT *,GETDATE() as mTGLSekarang FROM DATA_PARTS,TEMP_AUDITPART WHERE PARTS_NO = AUDITPART_NO AND PARTS_NO='" & LblPartsNo.Text & "' AND AUDITPART_USER='" & LblUserName.Text & "'", TxtCabang.Text) <> 1 Then
            Call GetDataA_DetailParts("SELECT *,GETDATE() as mTGLSekarang  FROM DATA_PARTS WHERE PARTS_NO='" & LblPartsNo.Text & "'", TxtCabang.Text)
        End If
        LVDataAdudit.DataBind()
        Call Tampil(-1, 0, -1, 0)
    End Sub
    Protected Sub lvStockPart128_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvStockPart128.SelectedIndexChanged
        '    Call clearInput()
        LblPartsNo.Text = (lvStockPart128.DataKeys(lvStockPart128.SelectedIndex).Value.ToString)

        If GetDataA_DetailPartsAudit("SELECT *,GETDATE() as mTGLSekarang FROM DATA_PARTS,TEMP_AUDITPART WHERE PARTS_NO = AUDITPART_NO AND PARTS_NO='" & LblPartsNo.Text & "' AND AUDITPART_USER='" & LblUserName.Text & "'", TxtCabang.Text) <> 1 Then
            Call GetDataA_DetailParts("SELECT *,GETDATE() as mTGLSekarang  FROM DATA_PARTS WHERE PARTS_NO='" & LblPartsNo.Text & "'", TxtCabang.Text)
        End If

        LVDataAdudit128.DataBind()
        Call Tampil(-1, 0, -1, 0)

    End Sub



    Protected Sub LVDataAdudit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVDataAdudit.SelectedIndexChanged
        '    Call clearInput()
        LblPartsNo.Text = (lvStockPart.DataKeys(lvStockPart.SelectedIndex).Value.ToString)
        If GetDataA_DetailPartsAudit("SELECT *,GETDATE() as mTGLSekarang FROM DATA_PARTS,TEMP_AUDITPART WHERE PARTS_NO = AUDITPART_NO AND PARTS_NO='" & LblPartsNo.Text & "'", TxtCabang.Text) <> 1 Then
            Msg_err("Nomor Tersebut belum di Audit")
        End If
        LVDataAdudit.DataBind()
        Call Tampil(-1, 0, -1, 0)
    End Sub
    Protected Sub LVDataAdudit128_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVDataAdudit128.SelectedIndexChanged
        '    Call clearInput()
        LblPartsNo.Text = (lvStockPart128.DataKeys(lvStockPart128.SelectedIndex).Value.ToString)
        If GetDataA_DetailPartsAudit("SELECT *,GETDATE() as mTGLSekarang FROM DATA_PARTS,TEMP_AUDITPART WHERE PARTS_NO = AUDITPART_NO AND PARTS_NO='" & LblPartsNo.Text & "'", TxtCabang.Text) <> 1 Then
            Msg_err("Nomor Tersebut belum di Audit")
        End If
        LVDataAdudit128.DataBind()
        Call Tampil(-1, 0, -1, 0)

    End Sub





    Protected Sub ButtonTabelPartsGO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonTabelPartsGO.Click
        If TxtCabang.Text = "112" Then
            lvStockPart.DataBind()
        Else
            lvStockPart128.DataBind()
        End If
        Call Tampil(0, -1, 0, -1)
    End Sub

    Protected Sub ButtonTabelPartsSM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonTabelPartsSM.Click
        LblPartsNo.Text = ""

        TxtHeadPartsNote.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE1 as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        lblHeadPartsTgl.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE1TGL  as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        lblHeadPartsUser.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE1USR as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        CheckBoxHeadParts.Checked = IIf(GetDataD_IsiField("SELECT AUDITPART_NOTE1STATUS as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text) = "1", True, False)

        TxtHeadSMNote.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE3 as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        lblHeadSMTgl.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE3TGL as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        lblHeadSMUser.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE3USR as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        CheckBoxHeadSM.Checked = IIf(GetDataD_IsiField("SELECT AUDITPART_NOTE3STATUS as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text) = "1", True, False)

        TxtHeadAcctNote.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE4 as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        lblHeadAccTgl.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE4TGL as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        lblHeadAccUser.Text = GetDataD_IsiField("SELECT AUDITPART_NOTE4USR as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text)
        CheckBoxHeadAcct.Checked = IIf(GetDataD_IsiField("SELECT AUDITPART_NOTE4STATUS as IsiField FROM TEMP_AUDITPART ", TxtCabang.Text) = "1", True, False)

        If TxtCabang.Text = "112" Then
            LVDataAdudit.DataBind()
        Else
            LVDataAdudit128.DataBind()
        End If
        Call Tampil(-1, 0, -1, 0)
    End Sub


    Protected Sub BtnAuditSimpan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAuditSimpan.Click
        Dim mdate As String = ""
        Call UpdateDatabase_Tabel("DELETE FROM TEMP_AUDITPART WHERE AUDITPART_NO='" & LblPartsNo.Text & "' AND AUDITPART_USER='" & LblUserName.Text & "'", TxtCabang.Text)
        Dim mTxtSQL As String = "INSERT INTO TEMP_AUDITPART (AUDITPART_NO,AUDITPART_TGL,AUDITPART_TGLSTOK,AUDITPART_USER,AUDITPART_STOK,AUDITPART_PICKUP,AUDITPART_QTY,AUDITPART_CATATAN) VALUES " & _
                                "('" & LblPartsNo.Text & "',GETDATE()," & DtInSQL(CDate(LblPartsStokTgl.Text)) & ",'" & LblUserName.Text & "'," & Val(LblPartsStk.Text) & "," & Val(LblPartsPickup.Text) & "," & Val(TxtPartsAuditQty.Text) & ",'" & TxtPetik(TxtPartsAuditNote.Text) & "')"
        Call UpdateDatabase_Tabel(mTxtSQL, TxtCabang.Text)
        mdate = GetDataD_IsiField("SELECT MAX(AUDITPART_TGL) as IsiField FROM TEMP_AUDITPART WHERE AUDITPART_NO='" & LblPartsNo.Text & "'", TxtCabang.Text)
        If mdate <> "" Then
            mTxtSQL = "UPDATE DATA_PARTS SET PARTS_TGLAUDIT=" & DtInSQL(CDate(mdate)) & " "

            If TxtPartsLantaiku.Enabled = True And TxtPartsLantaiku.Text <> "NONE" Then
                mTxtSQL = ",PARTS_LOKASI='" & TxtPartsLantaiku.Text & "' "
            End If

            mdate = GetDataD_IsiField("SELECT SUM(AUDITPART_QTY) as IsiField FROM TEMP_AUDITPART WHERE AUDITPART_NO='" & LblPartsNo.Text & "'", TxtCabang.Text)
            mTxtSQL = mTxtSQL & ",PARTS_QTYAUDIT=" & Val(mdate) & " WHERE PARTS_NO='" & LblPartsNo.Text & "'"

            Call UpdateDatabase_Tabel(mTxtSQL, TxtCabang.Text)
            LblPartsStatusSimpan.Text = "Berhasil"

            LblPartsUserTgl.Text = Now()
            LblPartsUserNma.Text = LblUserName.Text

        End If
        If InStr(TxtCabang.Text, "112") <> 0 Then
            LVDataAdudit.DataBind()
        Else
            LVDataAdudit128.DataBind()
        End If

        If CheckBox1.Checked = True Then
            If InStr(TxtCabang.Text, "112") <> 0 Then
                lvStockPart.DataBind()
            Else
                lvStockPart128.DataBind()
            End If
            Call Tampil(0, -1, 0, -1)
        Else
            Call Tampil(-1, 0, -1, 0)
        End If
    End Sub

    Protected Sub BtnAdditorSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdditorSave.Click
        Dim mTxtSQL As String
        mTxtSQL = "UPDATE TEMP_AUDITPART SET " & _
                  "AUDITPART_NOTE2TGL=GETDATE(), " & _
                  "AUDITPART_NOTE2ADJ=" & Val(TxtAuditorAdjemsnt.Text) & ", " & _
                  "AUDITPART_NOTE2USR='" & LblAuditorUser.Text & "', " & _
                  "AUDITPART_NOTE2='" & TxtPetik(TxtAuditorNote.Text) & "' " & _
                  "WHERE AUDITPART_NO='" & LblPartsNo.Text & "'"
        If UpdateDatabase_Tabel(mTxtSQL, TxtCabang.Text) = 1 Then
            LblAuditorTgl.Text = Now()
            LblAuditorUser.Text = LblUserName.Text
            If InStr(TxtCabang.Text, "112") <> 0 Then
                LVDataAdudit.DataBind()
            Else
                LVDataAdudit128.DataBind()
            End If

        End If
        If CheckBox1.Checked = True Then
            If InStr(TxtCabang.Text, "112") <> 0 Then
                lvStockPart.DataBind()
            Else
                lvStockPart128.DataBind()
            End If
            Call Tampil(0, -1, 0, -1)
        Else
            Call Tampil(-1, 0, -1, 0)
        End If
    End Sub

    Protected Sub BtnHeadPartsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHeadPartsSave.Click
        Dim mTxtSQL As String
        mTxtSQL = "UPDATE TEMP_AUDITPART SET " & _
                  "AUDITPART_NOTE1TGL=GETDATE(), " & _
                  "AUDITPART_NOTE1USR='" & lblHeadPartsUser.Text & "', " & _
                  "AUDITPART_NOTE1STATUS='" & If(CheckBoxHeadParts.Checked = True, "1", "0") & "', " & _
                  "AUDITPART_NOTE1='" & TxtPetik(TxtHeadPartsNote.Text) & "' " & _
                  "WHERE AUDITPART_NO='" & LblPartsNo.Text & "'"
        If UpdateDatabase_Tabel(mTxtSQL, TxtCabang.Text) = 1 Then
            lblHeadPartsTgl.Text = Now()
            lblHeadPartsUser.Text = LblUserName.Text
            If InStr(TxtCabang.Text, "112") <> 0 Then
                LVDataAdudit.DataBind()
            Else
                LVDataAdudit128.DataBind()
            End If
        End If
        If CheckBox1.Checked = True Then
            If InStr(TxtCabang.Text, "112") <> 0 Then
                lvStockPart.DataBind()
            Else
                lvStockPart128.DataBind()
            End If
            Call Tampil(0, -1, 0, -1)
        Else
            Call Tampil(-1, 0, -1, 0)
        End If
    End Sub

    Protected Sub BtnHeadSMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHeadSMSave.Click
        If CheckBoxHeadParts.Checked = False Then
            Call Msg_err("Belum disetujui oleh Head Suku Cadang")
        End If

        Dim mTxtSQL As String
        mTxtSQL = "UPDATE TEMP_AUDITPART SET " & _
                  "AUDITPART_NOTE3TGL=GETDATE(), " & _
                  "AUDITPART_NOTE3USR='" & lblHeadPartsUser.Text & "', " & _
                  "AUDITPART_NOTE3STATUS='" & If(CheckBoxHeadSM.Checked = True, "1", "0") & "', " & _
                  "AUDITPART_NOTE3='" & TxtPetik(TxtHeadPartsNote.Text) & "' " & _
                  "WHERE AUDITPART_NO='" & LblPartsNo.Text & "'"
        If UpdateDatabase_Tabel(mTxtSQL, TxtCabang.Text) = 1 Then
            lblHeadSMTgl.Text = Now()
            lblHeadSMUser.Text = LblUserName.Text
            If InStr(TxtCabang.Text, "112") <> 0 Then
                LVDataAdudit.DataBind()
            Else
                LVDataAdudit128.DataBind()
            End If
        End If
        If CheckBox1.Checked = True Then
            If InStr(TxtCabang.Text, "112") <> 0 Then
                lvStockPart.DataBind()
            Else
                lvStockPart128.DataBind()
            End If
            Call Tampil(0, -1, 0, -1)
        Else
            Call Tampil(-1, 0, -1, 0)
        End If
    End Sub

    Protected Sub BtnHeadAccSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHeadAccSave.Click
        If CheckBoxHeadSM.Checked = False Then
            Call Msg_err("Belum disetujui oleh Servce Manager")
        End If

        Dim mTxtSQL As String
        mTxtSQL = "UPDATE TEMP_AUDITPART SET " & _
                  "AUDITPART_NOTE4TGL=GETDATE(), " & _
                  "AUDITPART_NOTE4USR='" & lblHeadPartsUser.Text & "', " & _
                  "AUDITPART_NOTE4STATUS='" & If(CheckBoxHeadSM.Checked = True, "1", "0") & "', " & _
                  "AUDITPART_NOTE4='" & TxtPetik(TxtHeadPartsNote.Text) & "' " & _
                  "WHERE AUDITPART_NO='" & LblPartsNo.Text & "'"
        If UpdateDatabase_Tabel(mTxtSQL, TxtCabang.Text) = 1 Then
            lblHeadPartsTgl.Text = Now()
            lblHeadPartsUser.Text = LblUserName.Text
            If InStr(TxtCabang.Text, "112") <> 0 Then
                LVDataAdudit.DataBind()
            Else
                LVDataAdudit128.DataBind()
            End If
        End If
        If CheckBox1.Checked = True Then
            If InStr(TxtCabang.Text, "112") <> 0 Then
                lvStockPart.DataBind()
            Else
                lvStockPart128.DataBind()
            End If
            Call Tampil(0, -1, 0, -1)
        Else
            Call Tampil(-1, 0, -1, 0)
        End If
    End Sub


    Protected Sub BtnAuditBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAuditBack.Click
        If InStr(TxtCabang.Text, "112") <> 0 Then
            lvStockPart.DataBind()
        Else
            lvStockPart128.DataBind()
        End If
        Call Tampil(0, -1, 0, -1)
    End Sub
    Protected Sub BtnAdditorBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdditorBack.Click
        If InStr(TxtCabang.Text, "112") <> 0 Then
            lvStockPart.DataBind()
        Else
            lvStockPart128.DataBind()
        End If
        Call Tampil(0, -1, 0, -1)
    End Sub
    Protected Sub BtnHeadPartsBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHeadPartsBack.Click
        If InStr(TxtCabang.Text, "112") <> 0 Then
            lvStockPart.DataBind()
        Else
            lvStockPart128.DataBind()
        End If
        Call Tampil(0, -1, 0, -1)
    End Sub
    Protected Sub BtnHeadSMBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHeadSMBack.Click
        If InStr(TxtCabang.Text, "112") <> 0 Then
            lvStockPart.DataBind()
        Else
            lvStockPart128.DataBind()
        End If
        Call Tampil(0, -1, 0, -1)
    End Sub
    Protected Sub BtnHeadAccBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHeadAccBack.Click
        If InStr(TxtCabang.Text, "112") <> 0 Then
            lvStockPart.DataBind()
        Else
            lvStockPart128.DataBind()
        End If
        Call Tampil(0, -1, 0, -1)
    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        lblQueryServiceNamaPSM.Text = "TIDAK DIKETEMUKAN"
        lblQueryServiceHistPSM.Text = ""
        lblQuerySalesHistPSM.Text = ""

        lblQueryServiceNamaPuri.Text = "TIDAK DIKETEMUKAN"
        lblQueryServiceHistPuri.Text = ""
        lblQuerySalesHistPuri.Text = ""

        Call GetDataA_DetailService("SELECT * FROM DATA_CUSTOMER,DATA_TYPE WHERE CUST_TYPE=TYPE_KODE AND CUST_NOPOL='" & TxtQueryServiceNopol.Text & "'", "112")
        Call GetDataA_DetailService("SELECT * FROM DATA_CUSTOMER,DATA_TYPE WHERE CUST_TYPE=TYPE_KODE AND CUST_NOPOL='" & TxtQueryServiceNopol.Text & "'", "128")

        Call GetDataA_DetailSales("SELECT * FROM TRXN_SURAT,TRXN_SPK,DATA_TYPE WHERE SURAT_SPK=SPK_NO AND SPK_CDTYPE=TYPE_TYPE AND SURAT_NOPOL='" & TxtQueryServiceNopol.Text & "'", "112")
        Call GetDataA_DetailSales("SELECT * FROM TRXN_SURAT,TRXN_SPK,DATA_TYPE WHERE SURAT_SPK=SPK_NO AND SPK_CDTYPE=TYPE_TYPE AND SURAT_NOPOL='" & TxtQueryServiceNopol.Text & "'", "128")

    End Sub
    Function GetDataA_DetailService(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        Dim mLokasi As String = mpServer
        mpServer = "MyConnCloudDnetSvcs" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetDataA_DetailService = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_DetailService = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                If mLokasi = "112" Then
                    lblQueryServiceNamaPSM.Text = (nSr(MyRecReadA("CUST_CNAME")))
                    lblQueryServiceHistPSM.Text = "TYPE " & (nSr(MyRecReadA("Type_NAMA"))) & " : " & _
                                                  "SERVICE TERAKHIR: " & IIf(DtFr(MyRecReadA("CUST_LAST"), "dd/MM/yy") = "", "NULL", DtFr(MyRecReadA("CUST_LAST"), "dd/MM/yy")) & " : " & _
                                                  "TOTAL SVC : " & nLg(MyRecReadA("CUST_FRQ")) & " "
                Else
                    lblQueryServiceNamaPuri.Text = (nSr(MyRecReadA("CUST_CNAME")))
                    lblQueryServiceHistPuri.Text = "TYPE " & (nSr(MyRecReadA("Type_NAMA"))) & " : " & _
                                                   "SERVICE TERAKHIR: " & IIf(DtFr(MyRecReadA("CUST_LAST"), "dd/MM/yy") = "", "NULL", DtFr(MyRecReadA("CUST_LAST"), "dd/MM/yy")) & " : " & _
                                                   "TOTAL SVC : " & nLg(MyRecReadA("CUST_FRQ")) & " "
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function
    Function GetDataA_DetailSales(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        Dim mLokasi As String = mpServer
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetDataA_DetailSales = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_DetailSales = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                If mLokasi = "112" Then
                    lblQuerySalesHistPSM.Text = "NO.POL." & nSr(MyRecReadA("SURAT_NOPOL")) & " : " & _
                                                "NAMA SPK " & (nSr(MyRecReadA("SPK_NAMA1"))) & " : " & _
                                                "TYPE " & (nSr(MyRecReadA("TYPE_NAMA")))

                Else
                    lblQuerySalesHistPSM.Text = "NO.POL." & nSr(MyRecReadA("SURAT_NOPOL")) & " : " & _
                                                "NAMA SPK " & (nSr(MyRecReadA("SPK_NAMA1"))) & " : " & _
                                                "TYPE " & (nSr(MyRecReadA("TYPE_NAMA")))
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
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






    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        LblTotalSvcPM1.Text = "0" : LblTotalSvcPM2.Text = "0" : LblTotalSvcPM3.Text = "0" : LblTotalSvcPM4.Text = "0" : LblTotalSvcPM5.Text = "0" : LblTotalSvcPM6.Text = "0"
        LblTotalSvcPMR1.Text = "0" : LblTotalSvcPMR2.Text = "0" : LblTotalSvcPMR3.Text = "0" : LblTotalSvcPMR4.Text = "0" : LblTotalSvcPMR5.Text = "0" : LblTotalSvcPMR6.Text = "0"
        LblTotalSvcRpr1.Text = "0" : LblTotalSvcRpr2.Text = "0" : LblTotalSvcRpr3.Text = "0" : LblTotalSvcRpr4.Text = "0" : LblTotalSvcRpr5.Text = "0" : LblTotalSvcRpr6.Text = "0"


        LblTotalAll1.Text = "0" : LblTotalAll2.Text = "0" : LblTotalAll3.Text = "0" : LblTotalAll4.Text = "0" : LblTotalAll5.Text = "0" : LblTotalAll6.Text = "0"
        LblTotalSvc1.Text = "0" : LblTotalSvc2.Text = "0" : LblTotalSvc3.Text = "0" : LblTotalSvc4.Text = "0" : LblTotalSvc5.Text = "0" : LblTotalSvc6.Text = "0"
        LblTotalBdy1.Text = "0" : LblTotalBdy2.Text = "0" : LblTotalBdy3.Text = "0" : LblTotalBdy4.Text = "0" : LblTotalBdy5.Text = "0" : LblTotalBdy6.Text = "0"
        LblPartSalesC1.Text = "0" : LblPartSalesC2.Text = "0" : LblPartSalesD1.Text = "0" : LblPartSalesD2.Text = "0"
        'WO Service

        Dim mSyarat1WO As String = "MONTH(WOHDR_TGWO)    =" & TxtSummaryServiceBln.Text & " AND YEAR(WOHDR_TGWO)=" & TxtSummaryServiceThn.Text & ""
        Dim mSyarat2WOPS As String = "MONTH(WOHDRPS_TGWO)  =" & TxtSummaryServiceBln.Text & " AND YEAR(WOHDRPS_TGWO)=" & TxtSummaryServiceThn.Text & ""
        Dim mSyarat3FK As String = "MONTH(WOHDR_TGFAK)   =" & TxtSummaryServiceBln.Text & " AND YEAR(WOHDR_TGFAK)=" & TxtSummaryServiceThn.Text & ""
        Dim mSyarat4FKPS As String = "MONTH(WOHDRPS_TGFAK) =" & TxtSummaryServiceBln.Text & " AND YEAR(WOHDRPS_TGFAK)=" & TxtSummaryServiceThn.Text & ""

        Dim mSyarat5BD As String = "WOHDR_JNSKERJA='3'"
        Dim mSyarat6BDPS As String = "WOHDRPS_JNSKERJA='3'"

        Dim mNilai1 As Double
        Dim mNilai2 As Double
        Dim mNilai3 As Double
        Dim mNilai4 As Double

        For mStep As Byte = 0 To 3
            mNilai1 = nLg(GetDataD_IsiField("select count(WOHDR_NO) as IsiField from trxn_wohdr where WOHDR_JNSKERJA='" & mStep & "' AND " & mSyarat1WO, TxtCabang.Text))
            mNilai1 = mNilai1 + nLg(GetDataD_IsiField("select count(WOHDRPS_NOWO) as IsiField from trxn_wohdrps where WOHDRPS_JNSKERJA='" & mStep & "' AND " & mSyarat2WOPS, TxtCabang.Text))
            If mStep = 0 Then
                LblTotalSvcPM1.Text = mNilai1
            ElseIf mStep = 1 Then
                LblTotalSvcPMR1.Text = mNilai1
            ElseIf mStep = 2 Then
                LblTotalSvcRpr1.Text = mNilai1
            ElseIf mStep = 3 Then
                LblTotalBdy1.Text = mNilai1
            End If
            If mStep <= 2 Then LblTotalSvc1.Text = nLg(LblTotalSvc1.Text) + mNilai1
            LblTotalAll1.Text = nLg(LblTotalAll1.Text) + mNilai1
        Next

        Dim mNilai1Tmp As Double
        Dim mNilai2Tmp As Double
        Dim mNilai3Tmp As Double
        Dim mNilai4Tmp As Double

        For mStep As Byte = 0 To 3
            mNilai1Tmp = 0 : mNilai2Tmp = 0 : mNilai3Tmp = 0 : mNilai4Tmp = 0
            Call GetDataD_IsiFieldMoreOneItem("select count(WOHDR_NO) as mFJumlah,SUM(WOHDR_TOTSERVICE) as mFTJasa, SUM(WOHDR_DISC) as mFTDisc, SUM(WOHDR_TOTPARTS)as mFTParts from trxn_wohdr where wohdr_jnskerja='" & mStep & "' AND " & mSyarat3FK, TxtCabang.Text, mNilai1, mNilai2, mNilai3, mNilai4)
            mNilai1 = mNilai1Tmp : mNilai2 = mNilai2Tmp : mNilai3 = mNilai3Tmp : mNilai4 = mNilai4Tmp

            mNilai1Tmp = 0 : mNilai2Tmp = 0 : mNilai3Tmp = 0 : mNilai4Tmp = 0
            Call GetDataD_IsiFieldMoreOneItem("select count(WOHDRPS_NOWO) as mFJumlah,SUM(CAST(WOHDRPS_TOTSERVICE AS FLOAT)) as mFTJasa, SUM(CAST(WOHDRPS_DISC AS FLOAT)) as mFTDisc, SUM(CAST(WOHDRPS_TOTPARTS AS FLOAT))as mFTParts from trxn_wohdrPS where wohdrps_jnskerja='" & mStep & "' AND " & mSyarat4FKPS, TxtCabang.Text, mNilai1, mNilai2, mNilai3, mNilai4)
            mNilai1 = mNilai1 + mNilai1Tmp : mNilai2 = mNilai2 + mNilai2Tmp : mNilai3 = mNilai3 + mNilai3Tmp : mNilai4 = mNilai4 + mNilai4Tmp

            If mStep = 0 Then
                LblTotalSvcPM2.Text = mNilai1            'Qty Fkt
                LblTotalSvcPM3.Text = mNilai2            'JmlJasa
                LblTotalSvcPM4.Text = mNilai3            'jmlDis
                LblTotalSvcPM5.Text = mNilai2 - mNilai3  'Jasa-Disc
                LblTotalSvcPM6.Text = mNilai4            'Parts
            ElseIf mStep = 1 Then
                LblTotalSvcPMR2.Text = mNilai1            'Qty Fkt
                LblTotalSvcPMR3.Text = mNilai2            'JmlJasa
                LblTotalSvcPMR4.Text = mNilai3            'jmlDis
                LblTotalSvcPMR5.Text = mNilai2 - mNilai3  'Jasa-Disc
                LblTotalSvcPMR6.Text = mNilai4            'Parts
            ElseIf mStep = 2 Then
                LblTotalSvcRpr2.Text = mNilai1            'Qty Fkt
                LblTotalSvcRpr3.Text = mNilai2            'JmlJasa
                LblTotalSvcRpr4.Text = mNilai3            'jmlDis
                LblTotalSvcRpr5.Text = mNilai2 - mNilai3  'Jasa-Disc
                LblTotalSvcRpr6.Text = mNilai4            'Parts
            ElseIf mStep = 3 Then
                LblTotalBdy2.Text = mNilai1               'Qty Fkt
                LblTotalBdy3.Text = mNilai2               'JmlJasa
                LblTotalBdy4.Text = mNilai3               'jmlDis
                LblTotalBdy5.Text = mNilai2 - mNilai3     'Jasa-Disc
                LblTotalBdy6.Text = mNilai4               'Parts
            End If
            If mStep <= 2 Then
                LblTotalSvc2.Text = nLg(LblTotalSvc2.Text) + mNilai1            'Qty Fkt
                LblTotalSvc3.Text = nLg(LblTotalSvc3.Text) + mNilai2            'JmlJasa
                LblTotalSvc4.Text = nLg(LblTotalSvc4.Text) + mNilai3            'jmlDis
                LblTotalSvc5.Text = nLg(LblTotalSvc5.Text) + (mNilai2 - mNilai3) 'Jasa-Disc
                LblTotalSvc6.Text = nLg(LblTotalSvc6.Text) + mNilai4            'Parts
            End If
            LblTotalAll2.Text = nLg(LblTotalAll2.Text) + mNilai1            'Qty Fkt
            LblTotalAll3.Text = nLg(LblTotalAll3.Text) + mNilai2            'JmlJasa
            LblTotalAll4.Text = nLg(LblTotalAll4.Text) + mNilai3            'jmlDis
            LblTotalAll5.Text = nLg(LblTotalAll5.Text) + (mNilai2 - mNilai3) 'Jasa-Disc
            LblTotalAll6.Text = nLg(LblTotalAll6.Text) + mNilai4            'Parts

        Next

        mNilai1 = nLg(GetDataD_IsiField("select SUM(PARTJUALD_QTY) as IsiField from trxn_PARTJUALD where (SUBSTRING(PARTJUALD_NOFAK,1,1)='C') AND MONTH(PARTJUALD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTJUALD_TGL)=" & TxtSummaryServiceThn.Text & "", TxtCabang.Text))
        LblPartSalesC1.Text = mNilai1
        mNilai1 = nLg(GetDataD_IsiField("select SUM(PARTAD_QTY) as IsiField from trxn_PARTAD where PARTAD_SP='2' AND (SUBSTRING(PARTAD_NOFAK,1,1)='C') AND MONTH(PARTAD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTAD_TGL)=" & TxtSummaryServiceThn.Text & "", TxtCabang.Text))
        LblPartSalesC1.Text = fLg(nLg(LblPartSalesC1.Text) + mNilai1)

        mNilai1 = ndb(GetDataD_IsiField("select SUM(PARTJUALD_RPSAL) as IsiField from trxn_PARTJUALD where (SUBSTRING(PARTJUALD_NOFAK,1,1)='C') AND MONTH(PARTJUALD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTJUALD_TGL)=" & TxtSummaryServiceThn.Text & "", TxtCabang.Text))
        LblPartSalesC2.Text = mNilai1
        mNilai1 = ndb(GetDataD_IsiField("select SUM(PARTAD_JUAL) as IsiField from trxn_PARTAD where PARTAD_SP='2' AND (SUBSTRING(PARTAD_NOFAK,1,1)='C') AND MONTH(PARTAD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTAD_TGL)=" & TxtSummaryServiceThn.Text & "", TxtCabang.Text))
        LblPartSalesC2.Text = fDb(ndb(LblPartSalesC2.Text) + mNilai1)
        '=======================
        mNilai1 = nLg(GetDataD_IsiField("select SUM(PARTJUALD_QTY) as IsiField from trxn_PARTJUALD where (SUBSTRING(PARTJUALD_NOFAK,1,1)='D') AND MONTH(PARTJUALD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTJUALD_TGL)=" & TxtSummaryServiceThn.Text & "", TxtCabang.Text))
        LblPartSalesD1.Text = mNilai1
        mNilai1 = nLg(GetDataD_IsiField("select SUM(PARTAD_QTY) as IsiField from trxn_PARTAD where PARTAD_SP='2' AND (SUBSTRING(PARTAD_NOFAK,1,1)='D') AND MONTH(PARTAD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTAD_TGL)=" & TxtSummaryServiceThn.Text & "", TxtCabang.Text))
        LblPartSalesD1.Text = fLg(nLg(LblPartSalesD1.Text) + mNilai1)

        mNilai1 = ndb(GetDataD_IsiField("select SUM(PARTJUALD_RPSAL) as IsiField from trxn_PARTJUALD where (SUBSTRING(PARTJUALD_NOFAK,1,1)='D') AND MONTH(PARTJUALD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTJUALD_TGL)=" & TxtSummaryServiceThn.Text & "", TxtCabang.Text))
        LblPartSalesD2.Text = mNilai1
        mNilai1 = ndb(GetDataD_IsiField("select SUM(PARTAD_JUAL) as IsiField from trxn_PARTAD where PARTAD_SP='2' AND (SUBSTRING(PARTAD_NOFAK,1,1)='D') AND MONTH(PARTAD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTAD_TGL)=" & TxtSummaryServiceThn.Text & "", TxtCabang.Text))
        LblPartSalesD2.Text = fDb(ndb(LblPartSalesD2.Text) + mNilai1)


    End Sub

    Function GetDataD_IsiFieldMoreOneItem(ByVal mSqlCommadstring As String, ByVal mpServer As String, ByRef mpNilai1 As Double, ByRef mpNilai2 As Double, ByRef mpNilai3 As Double, ByRef mpNilai4 As Double) As Integer
        mpServer = "MyConnCloudDnetSvcs" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetDataD_IsiFieldMoreOneItem = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadD = cmd.ExecuteReader()
            GetDataD_IsiFieldMoreOneItem = IIf(MyRecReadD.HasRows = True, 1, 0)
            If GetDataD_IsiFieldMoreOneItem = 1 Then
                While MyRecReadD.Read()
                    mpNilai1 = mpNilai1 + ndb(MyRecReadD("mFJumlah"))
                    mpNilai2 = mpNilai2 + ndb(MyRecReadD("mFTJasa"))
                    mpNilai3 = mpNilai3 + ndb(MyRecReadD("mFTDisc"))
                    mpNilai4 = mpNilai4 + ndb(MyRecReadD("mFTParts"))
                End While
            End If
            MyRecReadD.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Protected Sub ButtonPsm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPsm.Click
        If TxtCabang.Text = lblArea1.Text And lblArea2.Text <> "" Then
            TxtCabang.Text = lblArea2.Text
        Else
            TxtCabang.Text = lblArea1.Text
        End If
    End Sub
End Class
