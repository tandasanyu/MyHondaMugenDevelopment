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


Partial Class Form0202StatusSPK0303LaporanPiutang
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
                LVWOPiutang.DataBind()
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

    Protected Sub ButtonPsm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPsm.Click
        If CheckBox1.Checked = True Then
            Call Report_Web_SERVICE_ARPIUTANG()
            CheckBox1.Checked = False
        End If
        LVWOPiutang.DataBind()
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

    'Laporan2
    Function Report_Web_SERVICE_ARPIUTANG() As Byte
        Report_Web_SERVICE_ARPIUTANG = 0
        Try
            Dim mDealer As String = "112"
            mDealer = DropDownListGroupTipe.Text

            MySTRsql1 = "DELETE FROM TEMP_WEBREPORT WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='B' AND WEBREPORT_DEALER='" & mDealer & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            Call MsgProses("Tunggu Sedang Proses Ambil Data Piutang Service untuk " & mDealer, 1)

            For mProses = 1 To 1
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
