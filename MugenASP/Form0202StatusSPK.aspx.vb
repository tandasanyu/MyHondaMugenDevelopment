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

'10 Cari
'11 Posisi 0 Setuju Parts  
'12 Posisi 1 Setuju SM 



Partial Class Form04PurchaseOrder
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
                MultiViewMenu.ActiveViewIndex = 0

                '1. Cari Halaman3
                '2. Suku Cadang : Audit Save 
                '3. Suku Cadang : Head Save
                '4. Cari Halaman1
                '5. Cari Halaman2
                '6. Cari Halaman4
                '7. Suku Cadang : Auditor Save
                '8. Suku Cadang : Service Mgr Save
                '9. Suku Cadang : Account Save

                If Mid(lblAkses.Text, 2, 1) = "1" Or Mid(lblAkses.Text, 3, 1) = "1" Or Mid(lblAkses.Text, 7, 1) = "1" Or _
                   Mid(lblAkses.Text, 8, 1) = "1" Or Mid(lblAkses.Text, 9, 1) = "1" Then
                    LinkButton2.Enabled = True
                Else
                    LinkButton2.Text = LinkButton2.Text & "(No access)"
                    LinkButton2.Enabled = False
                End If


                LinkButtonSvc2.Enabled = False
                If Mid(lblAkses.Text, 6, 1) = "1" Then
                    LinkButtonSvc2.Enabled = True
                Else
                    LinkButtonSvc2.Text = LinkButtonSvc2.Text & "(No access)"
                End If
                LinkButtonSvc31.Enabled = False
                If Mid(lblAkses.Text, 5, 1) = "1" Then
                    LinkButtonSvc31.Enabled = True
                Else
                    LinkButtonSvc31.Text = LinkButtonSvc31.Text & "(No access)"
                End If
                LinkButtonSvc32.Enabled = False
                If Mid(lblAkses.Text, 4, 1) = "1" Then
                    LinkButtonSvc32.Enabled = True
                Else
                    LinkButtonSvc32.Text = LinkButtonSvc32.Text & "(No access)"
                End If
                LinkButton1.Enabled = False
                If Mid(lblAkses.Text, 1, 1) = "1" Then
                    LinkButton1.Enabled = True
                Else
                    LinkButton1.Text = LinkButton1.Text & "(No access)"
                End If


            Else
                MultiViewMenu.ActiveViewIndex = -1
                Call Msg_err("TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI")
            End If
        End If
    End Sub

    Sub Msg_err(ByVal mTest As String)
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


End Class
