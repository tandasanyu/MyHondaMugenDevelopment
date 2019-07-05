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


Partial Class Form0202StatusSPK0301LaporanSummaryTrxn
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

            [Calendar1].Visible = False
            [Calendar2].Visible = False

            Call DefinisTabel_SA()
            Call DefinisTabel_Mekanik()


            mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0105'")
            If mFound = 1 Then
                MultiViewForm.ActiveViewIndex = 0
                MultiViewSuport.ActiveViewIndex = 0
                DropDownListGroupTipe.Text = "112"
                If lblArea1.Text <> "" Then DropDownListGroupTipe.Text = lblArea1.Text
            Else
                MultiViewForm.ActiveViewIndex = -1
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

    Protected Sub DefinisTabel_SA()
        Dim dt As New DataTable()


        dt.Columns.AddRange(New DataColumn(9) {New DataColumn("Temp_SACus"), New DataColumn("Temp_SAWO"), New DataColumn("Temp_SAUnit"), _
                                               New DataColumn("Temp_SAJasa"), New DataColumn("Temp_SAPotong"), New DataColumn("Temp_SAParts"), _
                                               New DataColumn("Temp_SAChemi"), New DataColumn("Temp_SAAkses"), New DataColumn("Temp_SAOil"), New DataColumn("Temp_SATotal")})

 

        ViewState("SA") = dt
        Me.BindGrid_SA()
    End Sub
    Protected Sub BindGrid_SA()
        LvTabelSummarySA.DataSource = DirectCast(ViewState("SA"), DataTable)
        LvTabelSummarySA.DataBind()
    End Sub
    Sub insertTabel_SA(ByVal Type As Byte, ByVal Temp_SACus As String, ByVal Temp_SAWO As String, ByVal Temp_SAUnit As String, ByVal Temp_SAJasa As String, ByVal Temp_SAPotong As String, ByVal Temp_SAParts As String, ByVal Temp_SAChemi As String, ByVal Temp_SAAkses As String, ByVal Temp_SAOil As String, ByVal Temp_SATotal As String)
        Dim dt As DataTable = DirectCast(ViewState("SA"), DataTable)
        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_SACus, Temp_SAWO, Temp_SAUnit, Temp_SAJasa, Temp_SAPotong, Temp_SAParts, Temp_SAChemi, Temp_SAAkses, Temp_SAOil, Temp_SATotal)
        End If
        ViewState("SA") = dt
        Me.BindGrid_SA()
    End Sub

    Protected Sub DefinisTabel_Mekanik()
        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn(9) {New DataColumn("Temp_TekhnisName"), New DataColumn("Temp_TekhnisPos"), New DataColumn("Temp_TekhnisWO"), _
                                               New DataColumn("Temp_TekhnisJasa"), New DataColumn("Temp_TekhnisPotong"), New DataColumn("Temp_TekhnisParts"), _
                                               New DataColumn("Temp_TekhnisChemi"), New DataColumn("Temp_TekhnisAkses"), New DataColumn("Temp_TekhnisOil"), New DataColumn("Temp_TekhnisTotal")})
        ViewState("MEKANIK") = dt
        Me.BindGrid_Mekanik()
    End Sub
    Protected Sub BindGrid_Mekanik()
        LvTabelSummaryMekanik.DataSource = DirectCast(ViewState("MEKANIK"), DataTable)
        LvTabelSummaryMekanik.DataBind()
    End Sub
    Sub insertTabel_Mekanik(ByVal Type As Byte, ByVal Temp_TekhnisName As String, ByVal Temp_TekhnisPos As String, ByVal Temp_TekhnisWO As String, ByVal Temp_TekhnisJasa As String, ByVal Temp_TekhnisPotong As String, ByVal Temp_TekhnisParts As String, ByVal Temp_TekhnisChemi As String, ByVal Temp_TekhnisAkses As String, ByVal Temp_TekhnisOil As String, ByVal Temp_TekhnisTotal As String)
        Dim dt As DataTable = DirectCast(ViewState("MEKANIK"), DataTable)
        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_TekhnisName, Temp_TekhnisPos, Temp_TekhnisWO, Temp_TekhnisJasa, Temp_TekhnisPotong, Temp_TekhnisParts, Temp_TekhnisChemi, Temp_TekhnisAkses, Temp_TekhnisOil, Temp_TekhnisTotal)
        End If
        ViewState("MEKANIK") = dt
        Me.BindGrid_Mekanik()
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

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtTglStart.Text = "" Or txtTglEnd.Text = "" Then
            Exit Sub
        End If

        txtTglStart.Text = InputDT("", "", "", "00", "00", "00", CDate(txtTglStart.Text))
        txtTglEnd.Text = InputDT("", "", "", "23", "59", "59", CDate(txtTglEnd.Text))
        If DropDownListGroupTipeReport.Text = "Summary Keseluruhan" Then
            MultiViewForm.ActiveViewIndex = 0
            Call INSERT_TMPPILIH_ALL()

        ElseIf DropDownListGroupTipeReport.Text = "Summary Per-Sales Advisor" Then
            MultiViewForm.ActiveViewIndex = 1
            Call INSERT_TMPPILIH_ServiceAdvisor("", txtTglStart.Text, txtTglEnd.Text, "Field", "Type", "Myscreen")
        ElseIf DropDownListGroupTipeReport.Text = "Summary Per-Mekanik" Then
            MultiViewForm.ActiveViewIndex = 2
            Call INSERT_TMPPILIH_Mekanik()
        End If
    End Sub



    Protected Sub INSERT_TMPPILIH_ALL()





        LblTotalSvcPM1.Text = "0" : LblTotalSvcPM2.Text = "0" : LblTotalSvcPM3.Text = "0" : LblTotalSvcPM4.Text = "0" : LblTotalSvcPM5.Text = "0" : LblTotalSvcPM6.Text = "0"
        LblTotalSvcPMR1.Text = "0" : LblTotalSvcPMR2.Text = "0" : LblTotalSvcPMR3.Text = "0" : LblTotalSvcPMR4.Text = "0" : LblTotalSvcPMR5.Text = "0" : LblTotalSvcPMR6.Text = "0"
        LblTotalSvcRpr1.Text = "0" : LblTotalSvcRpr2.Text = "0" : LblTotalSvcRpr3.Text = "0" : LblTotalSvcRpr4.Text = "0" : LblTotalSvcRpr5.Text = "0" : LblTotalSvcRpr6.Text = "0"


        LblTotalAll1.Text = "0" : LblTotalAll2.Text = "0" : LblTotalAll3.Text = "0" : LblTotalAll4.Text = "0" : LblTotalAll5.Text = "0" : LblTotalAll6.Text = "0"
        LblTotalSvc1.Text = "0" : LblTotalSvc2.Text = "0" : LblTotalSvc3.Text = "0" : LblTotalSvc4.Text = "0" : LblTotalSvc5.Text = "0" : LblTotalSvc6.Text = "0"
        LblTotalBdy1.Text = "0" : LblTotalBdy2.Text = "0" : LblTotalBdy3.Text = "0" : LblTotalBdy4.Text = "0" : LblTotalBdy5.Text = "0" : LblTotalBdy6.Text = "0"
        LblPartSalesC1.Text = "0" : LblPartSalesC2.Text = "0" : LblPartSalesD1.Text = "0" : LblPartSalesD2.Text = "0"
        'WO Service

        'Dim mSyarat1WO As String = "MONTH(WOHDR_TGWO)    =" & TxtSummaryServiceBln.Text & " AND YEAR(WOHDR_TGWO)=" & TxtSummaryServiceThn.Text & ""
        'Dim mSyarat2WOPS As String = "MONTH(WOHDRPS_TGWO)  =" & TxtSummaryServiceBln.Text & " AND YEAR(WOHDRPS_TGWO)=" & TxtSummaryServiceThn.Text & ""
        'Dim mSyarat3FK As String = "MONTH(WOHDR_TGFAK)   =" & TxtSummaryServiceBln.Text & " AND YEAR(WOHDR_TGFAK)=" & TxtSummaryServiceThn.Text & ""
        'Dim mSyarat4FKPS As String = "MONTH(WOHDRPS_TGFAK) =" & TxtSummaryServiceBln.Text & " AND YEAR(WOHDRPS_TGFAK)=" & TxtSummaryServiceThn.Text & ""

        Dim mSyarat1WO As String = "WOHDR_TGWO     >= '" & Format(CDate(txtTglStart.Text), "yyyy-MM-dd HH:mm:ss") & "' AND WOHDR_TGWO   <= '" & Format(CDate(txtTglEnd.Text), "yyyy-MM-dd HH:mm:ss") & "'"
        Dim mSyarat2WOPS As String = "WOHDRPS_TGWO >= '" & Format(CDate(txtTglStart.Text), "yyyy-MM-dd HH:mm:ss") & "' AND WOHDRPS_TGWO <= '" & Format(CDate(txtTglEnd.Text), "yyyy-MM-dd HH:mm:ss") & "'"

        Dim mSyarat3FK As String = "  WOHDR_TGFAK   >= '" & Format(CDate(txtTglStart.Text), "yyyy-MM-dd HH:mm:ss") & "' AND WOHDR_TGFAK   <= '" & Format(CDate(txtTglEnd.Text), "yyyy-MM-dd HH:mm:ss") & "'"
        Dim mSyarat4FKPS As String = "WOHDRPS_TGFAK >= '" & Format(CDate(txtTglStart.Text), "yyyy-MM-dd HH:mm:ss") & "' AND WOHDRPS_TGFAK <= '" & Format(CDate(txtTglEnd.Text), "yyyy-MM-dd HH:mm:ss") & "'"


        Dim mSyarat5BD As String = "WOHDR_JNSKERJA='3'"
        Dim mSyarat6BDPS As String = "WOHDRPS_JNSKERJA='3'"

        Dim mNilai1 As Double
        Dim mNilai2 As Double
        Dim mNilai3 As Double
        Dim mNilai4 As Double

        For mStep As Byte = 0 To 3
            mNilai1 = nLg(GetDataD_IsiField("select count(WOHDR_NO) as IsiField from trxn_wohdr where WOHDR_JNSKERJA='" & mStep & "' AND " & mSyarat1WO, DropDownListGroupTipe.Text))
            mNilai1 = mNilai1 + nLg(GetDataD_IsiField("select count(WOHDRPS_NOWO) as IsiField from trxn_wohdrps where WOHDRPS_JNSKERJA='" & mStep & "' AND " & mSyarat2WOPS, DropDownListGroupTipe.Text))
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
            Call GetDataD_IsiFieldMoreOneItem("select count(WOHDR_NO) as mFJumlah,SUM(WOHDR_TOTSERVICE) as mFTJasa, SUM(WOHDR_DISC) as mFTDisc, SUM(WOHDR_TOTPARTS)as mFTParts from trxn_wohdr where wohdr_jnskerja='" & mStep & "' AND " & mSyarat3FK, DropDownListGroupTipe.Text, mNilai1Tmp, mNilai2Tmp, mNilai3Tmp, mNilai4Tmp)
            mNilai1 = mNilai1Tmp : mNilai2 = mNilai2Tmp : mNilai3 = mNilai3Tmp : mNilai4 = mNilai4Tmp

            mNilai1Tmp = 0 : mNilai2Tmp = 0 : mNilai3Tmp = 0 : mNilai4Tmp = 0
            Call GetDataD_IsiFieldMoreOneItem("select count(WOHDRPS_NOWO) as mFJumlah,SUM(CAST(WOHDRPS_TOTSERVICE AS FLOAT)) as mFTJasa, SUM(CAST(WOHDRPS_DISC AS FLOAT)) as mFTDisc, SUM(CAST(WOHDRPS_TOTPARTS AS FLOAT))as mFTParts from trxn_wohdrPS where wohdrps_jnskerja='" & mStep & "' AND " & mSyarat4FKPS, DropDownListGroupTipe.Text, mNilai1Tmp, mNilai2Tmp, mNilai3Tmp, mNilai4Tmp)
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

        'mNilai1 = nLg(GetDataD_IsiField("select SUM(PARTJUALD_QTY) as IsiField from trxn_PARTJUALD where (SUBSTRING(PARTJUALD_NOFAK,1,1)='C') AND MONTH(PARTJUALD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTJUALD_TGL)=" & TxtSummaryServiceThn.Text & "", DropDownListGroupTipe.Text))
        'LblPartSalesC1.Text = mNilai1
        'mNilai1 = nLg(GetDataD_IsiField("select SUM(PARTAD_QTY) as IsiField from trxn_PARTAD where PARTAD_SP='2' AND (SUBSTRING(PARTAD_NOFAK,1,1)='C') AND MONTH(PARTAD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTAD_TGL)=" & TxtSummaryServiceThn.Text & "", DropDownListGroupTipe.Text))
        'LblPartSalesC1.Text = fLg(nLg(LblPartSalesC1.Text) + mNilai1)

        'mNilai1 = ndb(GetDataD_IsiField("select SUM(PARTJUALD_RPSAL) as IsiField from trxn_PARTJUALD where (SUBSTRING(PARTJUALD_NOFAK,1,1)='C') AND MONTH(PARTJUALD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTJUALD_TGL)=" & TxtSummaryServiceThn.Text & "", DropDownListGroupTipe.Text))
        'LblPartSalesC2.Text = mNilai1
        'mNilai1 = ndb(GetDataD_IsiField("select SUM(PARTAD_JUAL) as IsiField from trxn_PARTAD where PARTAD_SP='2' AND (SUBSTRING(PARTAD_NOFAK,1,1)='C') AND MONTH(PARTAD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTAD_TGL)=" & TxtSummaryServiceThn.Text & "", DropDownListGroupTipe.Text))
        'LblPartSalesC2.Text = fDb(ndb(LblPartSalesC2.Text) + mNilai1)
        '=======================
        'mNilai1 = nLg(GetDataD_IsiField("select SUM(PARTJUALD_QTY) as IsiField from trxn_PARTJUALD where (SUBSTRING(PARTJUALD_NOFAK,1,1)='D') AND MONTH(PARTJUALD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTJUALD_TGL)=" & TxtSummaryServiceThn.Text & "", DropDownListGroupTipe.Text))
        'LblPartSalesD1.Text = mNilai1
        'mNilai1 = nLg(GetDataD_IsiField("select SUM(PARTAD_QTY) as IsiField from trxn_PARTAD where PARTAD_SP='2' AND (SUBSTRING(PARTAD_NOFAK,1,1)='D') AND MONTH(PARTAD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTAD_TGL)=" & TxtSummaryServiceThn.Text & "", DropDownListGroupTipe.Text))
        'LblPartSalesD1.Text = fLg(nLg(LblPartSalesD1.Text) + mNilai1)

        'mNilai1 = ndb(GetDataD_IsiField("select SUM(PARTJUALD_RPSAL) as IsiField from trxn_PARTJUALD where (SUBSTRING(PARTJUALD_NOFAK,1,1)='D') AND MONTH(PARTJUALD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTJUALD_TGL)=" & TxtSummaryServiceThn.Text & "", DropDownListGroupTipe.Text))
        'LblPartSalesD2.Text = mNilai1
        'mNilai1 = ndb(GetDataD_IsiField("select SUM(PARTAD_JUAL) as IsiField from trxn_PARTAD where PARTAD_SP='2' AND (SUBSTRING(PARTAD_NOFAK,1,1)='D') AND MONTH(PARTAD_TGL) =" & TxtSummaryServiceBln.Text & " AND YEAR(PARTAD_TGL)=" & TxtSummaryServiceThn.Text & "", DropDownListGroupTipe.Text))
        'LblPartSalesD2.Text = fDb(ndb(LblPartSalesD2.Text) + mNilai1)

        mNilai1 = nLg(GetDataD_IsiField("select SUM(PARTJUALD_QTY) as IsiField from trxn_PARTJUALD where (SUBSTRING(PARTJUALD_NOFAK,1,1)='C') AND       PARTJUALD_TGL >= '" & Format(CDate(txtTglStart.Text), "yyyy-MM-dd hh:mm:ss") & "'  AND PARTJUALD_TGL <= '" & Format(CDate(txtTglEnd.Text), "yyyy-MM-dd hh:mm:ss") & "'", DropDownListGroupTipe.Text))
        LblPartSalesC1.Text = mNilai1
        mNilai1 = nLg(GetDataD_IsiField("select SUM(PARTAD_QTY) as IsiField from trxn_PARTAD where PARTAD_SP='2' AND (SUBSTRING(PARTAD_NOFAK,1,1)='C') AND PARTAD_TGL >= '" & Format(CDate(txtTglStart.Text), "yyyy-MM-dd hh:mm:ss") & "'  AND PARTAD_TGL <= '" & Format(CDate(txtTglEnd.Text), "yyyy-MM-dd hh:mm:ss") & "'", DropDownListGroupTipe.Text))
        LblPartSalesC1.Text = fLg(nLg(LblPartSalesC1.Text) + mNilai1)

        mNilai1 = ndb(GetDataD_IsiField("select SUM(PARTJUALD_RPSAL) as IsiField from trxn_PARTJUALD where (SUBSTRING(PARTJUALD_NOFAK,1,1)='C') AND      PARTJUALD_TGL >= '" & Format(CDate(txtTglStart.Text), "yyyy-MM-dd hh:mm:ss") & "' AND PARTJUALD_TGL   <= '" & Format(CDate(txtTglEnd.Text), "yyyy-MM-dd hh:mm:ss") & "'", DropDownListGroupTipe.Text))
        LblPartSalesC2.Text = mNilai1
        mNilai1 = ndb(GetDataD_IsiField("select SUM(PARTAD_JUAL) as IsiField from trxn_PARTAD where PARTAD_SP='2' AND (SUBSTRING(PARTAD_NOFAK,1,1)='C') AND PARTAD_TGL >= '" & Format(CDate(txtTglStart.Text), "yyyy-MM-dd hh:mm:ss") & "' AND PARTAD_TGL <= '" & Format(CDate(txtTglEnd.Text), "yyyy-MM-dd hh:mm:ss") & "'", DropDownListGroupTipe.Text))
        LblPartSalesC2.Text = fDb(ndb(LblPartSalesC2.Text) + mNilai1)
        '=======================
        mNilai1 = nLg(GetDataD_IsiField("select SUM(PARTJUALD_QTY) as IsiField from trxn_PARTJUALD where (SUBSTRING(PARTJUALD_NOFAK,1,1)='D') AND       PARTJUALD_TGL >= '" & Format(CDate(txtTglStart.Text), "yyyy-MM-dd hh:mm:ss") & "' AND PARTJUALD_TGL <= '" & Format(CDate(txtTglEnd.Text), "yyyy-MM-dd hh:mm:ss") & "'", DropDownListGroupTipe.Text))
        LblPartSalesD1.Text = mNilai1
        mNilai1 = nLg(GetDataD_IsiField("select SUM(PARTAD_QTY) as IsiField from trxn_PARTAD where PARTAD_SP='2' AND (SUBSTRING(PARTAD_NOFAK,1,1)='D') AND PARTAD_TGL >= '" & Format(CDate(txtTglStart.Text), "yyyy-MM-dd hh:mm:ss") & "' AND PARTAD_TGL    <= '" & Format(CDate(txtTglEnd.Text), "yyyy-MM-dd hh:mm:ss") & "'", DropDownListGroupTipe.Text))
        LblPartSalesD1.Text = fLg(nLg(LblPartSalesD1.Text) + mNilai1)

        mNilai1 = ndb(GetDataD_IsiField("select SUM(PARTJUALD_RPSAL) as IsiField from trxn_PARTJUALD where (SUBSTRING(PARTJUALD_NOFAK,1,1)='D') AND      PARTJUALD_TGL >= '" & Format(CDate(txtTglStart.Text), "yyyy-MM-dd hh:mm:ss") & "' AND PARTJUALD_TGL <= '" & Format(CDate(txtTglEnd.Text), "yyyy-MM-dd hh:mm:ss") & "'", DropDownListGroupTipe.Text))
        LblPartSalesD2.Text = mNilai1
        mNilai1 = ndb(GetDataD_IsiField("select SUM(PARTAD_JUAL) as IsiField from trxn_PARTAD where PARTAD_SP='2' AND (SUBSTRING(PARTAD_NOFAK,1,1)='D') AND PARTAD_TGL >= '" & Format(CDate(txtTglStart.Text), "yyyy-MM-dd hh:mm:ss") & "' AND PARTAD_TGL    <= '" & Format(CDate(txtTglEnd.Text), "yyyy-MM-dd hh:mm:ss") & "'", DropDownListGroupTipe.Text))
        LblPartSalesD2.Text = fDb(ndb(LblPartSalesD2.Text) + mNilai1)


    End Sub

    Sub INSERT_TMPPILIH_ServiceAdvisor(ByRef mVOcher As Object, ByRef mFilTgl1 As Object, ByRef mFilTgl2 As Object, ByRef Field As Object, ByRef mTYPE As Object, ByVal MyScreenCd As String)
        Dim mGO As Byte
        Dim mNamafile As String
        Dim mSP As String

        If Left(Field, 1) <> "_" Then
            MsgBox("PILIHAN CRITERIA SALAH TIDAK BISA DIPROSES ") : Exit Sub
        End If

        '            "WOHDR_NO=CONTROL_NOWO AND " & _ ,TEMP_CONTROL

        mNamafile = IIf(MyScreenCd = "0406B" Or MyScreenCd = "0406C" Or MyScreenCd = "04063" Or MyScreenCd = "04064", "4 ", " ")
        mNamafile = IIf(MyScreenCd = "0406B" Or MyScreenCd = "0406C" Or MyScreenCd = "04063" Or MyScreenCd = "04064", "4 ", " ")


        mSP = IIf(MyScreenCd = "0406B" Or MyScreenCd = "0406C" Or MyScreenCd = "0406I", "A", "1")


        MySTRsql1 = "INSERT TEMP_TRXNOLI" & mNamafile & _
                    "SELECT WOHDR_TGWO,WOHDR_FNOPOL,WOHDR_NO,WOHDR_JNSKERJA,0,'" & mSP & "','" & mVOcher & "',NULL" & IIf(MyScreenCd = "04061" Or MyScreenCd = "04062", ",(SELECT MAX(STAFF_NAMA) FROM TRXN_WOKERJA,DATA_STAFF WHERE WOKERJA_STAFFCD=STAFF_KODE AND WOKERJA_NOWO =WOHDR_NO)", ",'1'") & IIf(MyScreenCd = "04063" Or MyScreenCd = "04064" Or MyScreenCd = "0406B" Or MyScreenCd = "0406C", ",0,0,0,0", " ") & " FROM TRXN_WOHDR WHERE " & "DATEDIFF(dd,'" & DtIn(mFilTgl1) & "',WOHDR" & Field & ") >= 0 AND " & "DATEDIFF(dd,WOHDR" & Field & ",'" & DtIn(mFilTgl2) & "') >= 0 "
        mGO = UpdateDatabase_Tabel(MySTRsql1, DropDownListGroupTipe.Text)

        mSP = IIf(MyScreenCd = "0406B" Or MyScreenCd = "0406C" Or MyScreenCd = "0406I", "B", "1")

        MySTRsql1 = "INSERT TEMP_TRXNOLI" & mNamafile & "SELECT WOHDRPS_TGWO,WOHDRPS_FNOPOL,WOHDRPS_NOWO,WOHDRPS_JNSKERJA,0,'" & mSP & "','" & mVOcher & "',NULL" & IIf(MyScreenCd = "04061" Or MyScreenCd = "04062", ",(SELECT MAX(STAFF_NAMA) FROM TRXN_WOKERJAPS,DATA_STAFF WHERE WOKERJAPS_STAFFCD=STAFF_KODE AND WOKERJAPS_NOWO =WOHDRPS_NOWO)", ",'2'") & IIf(MyScreenCd = "04063" Or MyScreenCd = "04064" Or MyScreenCd = "0406B" Or MyScreenCd = "0406C", ",0,0,0,0", " ") & " FROM TRXN_WOHDRPS WHERE " & "DATEDIFF(dd,'" & DtIn(mFilTgl1) & "',WOHDRPS" & Field & ") >= 0 AND " & "DATEDIFF(dd,WOHDRPS" & Field & ",'" & DtIn(mFilTgl2) & "') >= 0 "
        mGO = UpdateDatabase_Tabel(MySTRsql1, DropDownListGroupTipe.Text)


        If MyScreenCd = "04063" Or MyScreenCd = "04064" Or MyScreenCd = "0406B" Or MyScreenCd = "0406C" Then
            'Summary SA WO & summary 170918 faktur & summary wo & summary detail faktur
            Call INSERT_TMPPILIH_Proses01A()

        ElseIf MyScreenCd = "04066" Then
            'detail kerja faktur overdue
            Call INSERT_TMPPILIH_Proses01B()

        ElseIf MyScreenCd = "0406L" Or MyScreenCd = "0406M" Then
            MySTRsql1 = "INSERT TEMP_TRXNOLI " & _
                        "SELECT TAGIHH_TGLKEMBALI,LUNAS_FPOL,LUNAS_NO,LUNAS_STATUS,LUNAS_RP,'2','" & mVOcher & "',LUNAS_TGLLUN,LUNAS_KET from TRXN_LUNAS,TRXN_TAGIHH,TEMP_TRXNOLI  WHERE LUNAS_NOTAGIH = TAGIHH_NO AND LUNAS_NO = TRXNOLI_NOFAK"
            mGO = UpdateDatabase_Tabel(MySTRsql1, DropDownListGroupTipe.Text)

            MySTRsql1 = "INSERT TEMP_TRXNOLI " & _
                        "SELECT TAGIHH_TGLKEMBALI,WOLNSPS_FPOL,WOLNSPS_NOWO,WOLNSPS_STATUS,WOLNSPS_RPLUN,'2','" & mVOcher & "',WOLNSPS_TGLUN,WOLNSPS_KETLUN FROM TRXN_WOLNSPS,TRXN_TAGIHH,TEMP_TRXNOLI  WHERE WOLNSPS_NOTAGIH = TAGIHH_NO AND WOLNSPS_NOWO=TRXNOLI_NOFAK"
            mGO = UpdateDatabase_Tabel(MySTRsql1, DropDownListGroupTipe.Text)

            MySTRsql1 = "INSERT TEMP_TRXNOLI " & _
                        "SELECT TAGIHH_TGLKEMBALI,WOLNS_FPOL,WOLNS_NOWO,WOLNS_STATUS,WOLNS_RPLUN,'2','" & mVOcher & "',WOLNS_TGLUN,WOLNS_KETLUN FROM TRXN_WOLNS,TRXN_TAGIHH,TEMP_TRXNOLI  WHERE WOLNS_NOTAGIH = TAGIHH_NO AND WOLNS_NOWO=TRXNOLI_NOFAK"
            mGO = UpdateDatabase_Tabel(MySTRsql1, DropDownListGroupTipe.Text)
        End If

        If mTYPE = "1" Then
            MySTRsql1 = "INSERT TEMP_DETAIL " & "SELECT WOKELUH_NOWO,WOKELUH_KELUH FROM TRXN_WOKELUH,TEMP_TRXNOLI WHERE " & "WOKELUH_NOWO=RTRIM(TRXNOLI_NOFAK) AND TRXNOLI_SP='1'"
            mGO = UpdateDatabase_Tabel(MySTRsql1, DropDownListGroupTipe.Text)
        ElseIf mTYPE = "2" Then
            MySTRsql1 = "INSERT TEMP_DETAIL " & "SELECT WOKERJA_NOWO,WOKERJA_KERJADESC FROM TRXN_WOKERJA,TEMP_TRXNOLI WHERE " & "WOKERJA_NOWO=RTRIM(TRXNOLI_NOFAK) AND TRXNOLI_SP='1'"
            mGO = UpdateDatabase_Tabel(MySTRsql1, DropDownListGroupTipe.Text)
            MySTRsql1 = "INSERT TEMP_DETAIL " & "SELECT WOKERJAPS_NOWO,WOKERJAPS_KERJADESC FROM TRXN_WOKERJAPS,TEMP_TRXNOLI WHERE " & "WOKERJAPS_NOWO=RTRIM(TRXNOLI_NOFAK) AND TRXNOLI_SP='1'"
            mGO = UpdateDatabase_Tabel(MySTRsql1, DropDownListGroupTipe.Text)
        ElseIf mTYPE = "3" Then
        End If
    End Sub

    Sub INSERT_TMPPILIH_Proses01A()
        Dim mpServer As String = "MyConnCloudDnet" & DropDownListGroupTipe.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TEMP_TRXNOLI4"

        Dim MySTRsql2 As String = ""

        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            'LblProses.Text = "---> Proses Baca data     "
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    MySTRsql2 = INSERT_TMPPILIH_Proses01A_1(nSr((MyRecReadA("TRXNOLI_NOFAK"))))
                    If MySTRsql2 = "" Then
                        INSERT_TMPPILIH_Proses01A_2(nSr((MyRecReadA("TRXNOLI_NOFAK"))))
                    End If
                    'mNamafile = nSr((MyRecReadA("TRXNOLI_SP")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()

            'LblProses.Text = "---> Proses Baca data Selesai     "
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Sub
    Function INSERT_TMPPILIH_Proses01A_1(ByVal mNofkt As String) As String
        Dim mpServer As String = "MyConnCloudDnet" & DropDownListGroupTipe.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT PARTS_Chemical,SUM(PARTJUALD_RPSAL)as mTotal FROM TRXN_PARTJUALD,DATA_PARTS WHERE PARTJUALD_PN=PARTS_NO AND PARTJUALD_NOFAK='B/" & mNofkt & "' GROUP BY PARTS_Chemical"

        INSERT_TMPPILIH_Proses01A_1 = ""
        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            'LblProses.Text = "---> Proses Baca data     "
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                While MyRecReadB.Read()
                    INSERT_TMPPILIH_Proses01A_1 = INSERT_TMPPILIH_Proses01A_1 & IIf(INSERT_TMPPILIH_Proses01A_1 = "", "", ",") & _
                                                  "TRXNOLI_TPART" & nLg((MyRecReadB("PARTS_Chemical"))) & "=" & ndb((MyRecReadB("mTotal")))
                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()

        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Function
    Function INSERT_TMPPILIH_Proses01A_2(ByVal mNofkt As String) As String
        Dim mpServer As String = "MyConnCloudDnet" & DropDownListGroupTipe.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT PARTS_Chemical,SUM(PARTAD_JUAL)as mTotal FROM TRXN_PARTAD,DATA_PARTS WHERE PARTAD_PN=PARTS_NO AND PARTAD_NOFAK='B/" & mNofkt & "' GROUP BY PARTS_Chemical"

        INSERT_TMPPILIH_Proses01A_2 = ""
        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            'LblProses.Text = "---> Proses Baca data     "
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                While MyRecReadB.Read()
                    INSERT_TMPPILIH_Proses01A_2 = INSERT_TMPPILIH_Proses01A_2 & IIf(INSERT_TMPPILIH_Proses01A_2 = "", "", ",") & _
                                                  "TRXNOLI_TPART" & nLg((MyRecReadB("PARTS_Chemical"))) & "=" & ndb((MyRecReadB("mTotal")))
                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()

        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Function


    Sub INSERT_TMPPILIH_Proses01B()
        Dim mpServer As String = "MyConnCloudDnet" & DropDownListGroupTipe.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TEMP_TRXNOLI"

        Dim mNilai As Byte

        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            'LblProses.Text = "---> Proses Baca data     "
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mNilai = INSERT_TMPPILIH_Proses01B_1(nSr((MyRecReadA("TRXNOLI_NOFAK"))), nSr((MyRecReadA("TRXNOLI_AN"))), DtIn((MyRecReadA("TRXNOLI_TGL"))), nSr((MyRecReadA("TRXNOLI_KET"))))

                    If mNilai < 3 Then
                        mNilai = INSERT_TMPPILIH_Proses01B_2(nSr((MyRecReadA("TRXNOLI_NOFAK"))), nSr((MyRecReadA("TRXNOLI_AN"))), DtIn((MyRecReadA("TRXNOLI_TGL"))), nSr((MyRecReadA("TRXNOLI_KET"))))
                    End If
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()

            'LblProses.Text = "---> Proses Baca data Selesai     "
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Sub
    Function INSERT_TMPPILIH_Proses01B_1(ByVal mNofkt As String, ByVal mNoPol As String, ByVal mTgl As String, ByVal mKet As String) As Byte
        Dim mpServer As String = "MyConnCloudDnet" & DropDownListGroupTipe.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_WOHDR WHERE WOHDR_NO<>'" & mNofkt & "' AND " & "WOHDR_FNOPOL='" & mNoPol & "' AND " & "DATEDIFF(day,WOHDR_TGWO,'" & mTgl & "') >= 0"

        Dim mVOcher As String = "99991"

        INSERT_TMPPILIH_Proses01B_1 = 0
        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                While MyRecReadB.Read() And INSERT_TMPPILIH_Proses01B_1 <= 1
                    MySTRsql1 = "INSERT TEMP_TRXNOLI " & _
                                "SELECT NULL,WOHDR_FNOPOL,WOHDR_NO,'" & mKet & "',0,'1','" & mVOcher & "',NULL,'1' FROM TRXN_WOHDR WHERE " & "WOHDR_NO='" & mNofkt & "'"
                    Call UpdateDatabase_Tabel(MySTRsql1, DropDownListGroupTipe.Text)
                    INSERT_TMPPILIH_Proses01B_1 = INSERT_TMPPILIH_Proses01B_1 + 1
                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()

        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Function
    Function INSERT_TMPPILIH_Proses01B_2(ByVal mNofkt As String, ByVal mNoPol As String, ByVal mTgl As String, ByVal mKet As String) As String
        Dim mpServer As String = "MyConnCloudDnet" & DropDownListGroupTipe.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_WOHDRPS WHERE WOHDRPS_NOWO<>'" & mNofkt & "' AND " & "WOHDRPS_FNOPOL='" & mNoPol & "' AND " & "DATEDIFF(day,WOHDRPS_TGWO,'" & mTgl & "') >= 0"

        Dim mVOcher As String = "99991"

        INSERT_TMPPILIH_Proses01B_2 = ""
        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                While MyRecReadB.Read() And INSERT_TMPPILIH_Proses01B_2 <= 1
                    MySTRsql1 = "INSERT TEMP_TRXNOLI " & _
                                "SELECT WOHDRPS_TGWO,WOHDRPS_FNOPOL,WOHDRPS_NOWO,'" & mKet & "',0,'1','" & mVOcher & "',NULL,'2' FROM TRXN_WOHDRPS WHERE " & "WOHDRPS_NOWO='" & mNofkt & "'"
                    Call UpdateDatabase_Tabel(MySTRsql1, DropDownListGroupTipe.Text)
                    INSERT_TMPPILIH_Proses01B_2 = INSERT_TMPPILIH_Proses01B_2 + 1
                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()

        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Function

    Sub ReportSummarySa_UnPost()
        Dim mpServer As String = "MyConnCloudDnet" & DropDownListGroupTipe.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_WOHDR,TEMP_TRXNOLI,DATA_PARTS,DATA_SUPPLIER WHERE " & _
                                         "WOHDR_NO=TRXNOLI_NOFAK AND TRXNOLI_AN=PARTS_NO AND " & _
                                         "WOHDR_KDTAGIH=SUPPLIER_KODE"
        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            'LblProses.Text = "---> Proses Baca data     "
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()

            'LblProses.Text = "---> Proses Baca data Selesai     "
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Sub
    Sub ReportSummarySa_Post()
        Dim mpServer As String = "MyConnCloudDnet" & DropDownListGroupTipe.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_WOHDRPS,TRXN_WOPARTS,DATA_PARTS,DATA_SUPPLIER WHERE " & _
                                         "WOHDRPS_NOWO=WOPARTS_NOWO AND WOHDRPS_KDTAGIH=SUPPLIER_KODE"
        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            'LblProses.Text = "---> Proses Baca data     "
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()

            'LblProses.Text = "---> Proses Baca data Selesai     "
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Sub

    Sub INSERT_TMPPILIH_Mekanik()
        Dim mpServer As String = "MyConnCloudDnet" & DropDownListGroupTipe.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_KERJA,TRXN_WOHDR,TRXN_WOPARTS,DATA_STAFF WHERE " & _
                                         "WOKERJA_NOWO=WOHDR_NO AND WOHDR_NO=WOPARTS_NOWO AND WOKERJA_STAFFCD=STAFF_KODE"
        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            'LblProses.Text = "---> Proses Baca data     "
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()

            'LblProses.Text = "---> Proses Baca data Selesai     "
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
    End Sub
    Sub ReportSummaryMekanik_Post()
        Dim mpServer As String = "MyConnCloudDnet" & DropDownListGroupTipe.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_KERJAPS,TRXN_WOHDRPS,TRXN_WOPARTS,DATA_STAFF WHERE " & _
                                         "WOKERJAPS_NOWO=WOHDRPS_NOWO AND WOHDRPS_NOWO=WOPARTS_NOWO AND WOKERJAPS_STAFFCD=STAFF_KODE"
        Call Msg_err("")
        cnn = New OleDbConnection(strconn)
        Try
            'LblProses.Text = "---> Proses Baca data     "
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()

            'LblProses.Text = "---> Proses Baca data Selesai     "
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring)
        End Try
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
    Function DtIn(ByVal Nilai As Object) As String
        DtIn = ""
        If Not IsDBNull(Nilai) Then
            DtIn = Format(CDate(Nilai), "yyyy-MM-dd HH:mm:ss")
        End If
    End Function

End Class
