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


Partial Class Form0202StatusSPK02CustomerCallFriend
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
            If mFound = 1 Then
                MultiViewForm.ActiveViewIndex = 0
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

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        lblQueryServiceNamaPSM.Text = "TIDAK DIKETEMUKAN"
        lblQueryServiceHistPSM.Text = ""
        lblQuerySalesHistPSM.Text = ""
        lblQueryServiceRangkaPSM.Text = ""

        lblQueryServiceNamaPuri.Text = "TIDAK DIKETEMUKAN"
        lblQueryServiceHistPuri.Text = ""
        lblQuerySalesHistPuri.Text = ""
        lblQueryServiceRangkaPuri.Text = ""

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
                    lblQueryServiceRangkaPSM.Text = nSr(MyRecReadA("CUST_NORANGKA"))
                    lblQueryServiceHistPSM.Text = "TYPE " & (nSr(MyRecReadA("Type_NAMA"))) & " : " & _
                                                  "SERVICE TERAKHIR: " & IIf(DtFr(MyRecReadA("CUST_LAST"), "dd/MM/yy") = "", "NULL", DtFr(MyRecReadA("CUST_LAST"), "dd/MM/yy")) & " : " & _
                                                  "TOTAL SVC : " & nLg(MyRecReadA("CUST_FRQ")) & " "

                Else
                    lblQueryServiceNamaPuri.Text = (nSr(MyRecReadA("CUST_CNAME")))
                    lblQueryServiceRangkaPuri.Text = nSr(MyRecReadA("CUST_NORANGKA"))
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







End Class
