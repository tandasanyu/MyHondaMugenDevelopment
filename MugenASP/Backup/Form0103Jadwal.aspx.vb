Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Imports System.Web.Security
'1 Cari
Partial Class Form02Jadwal
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SelectCommand = "SELECT TRXN_STOCKMKIRIM.STOCKM_TGLMOHONINPUT, TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM, TRXN_STOCKMKIRIM.STOCKM_KIRIMTGLSETUJUI, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLKIRIM, TRXN_STOCKMKIRIM.STOCKM_NORANGKA, TRXN_STOCKMKIRIM.STOCKM_KDDEALER, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLTERIMA, TRXN_STOCKKKIRIM.STOCKK_KIRIMKETTERIMA FROM TRXN_STOCKMKIRIM LEFT OUTER JOIN TRXN_STOCK ON TRXN_STOCKMKIRIM.STOCKM_NORANGKA = TRXN_STOCK.STOCK_NoRangka LEFT OUTER JOIN TRXN_STOCKKKIRIM ON TRXN_STOCK.STOCK_NoRangka = TRXN_STOCKKKIRIM.STOCKK_NORANGKA WHERE (TRXN_STOCKMKIRIM.STOCKM_NORANGKA LIKE '%' + ? + '%')"

        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If

        Dim x As String
        x = DirectCast(Session("MainContent"), String)
        LblUserName.Text = x.ToString
        If GetData_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(User_access)=RTRIM(AKSES_KODE) AND User_nama= '" & LblUserName.Text & "' AND User_tipe='WA' AND AKSES_MENU='0103'") = 1 Then
            MultiView1a.ActiveViewIndex = 0
        Else
            lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
        End If

        [cDate].Visible = False
        txtDate.Text = Now()
    End Sub
    Sub Msg_err(ByVal mTest As String)
        lblMsgBox.Text = mTest
        If mTest = "" Then
            MultiViewError.ActiveViewIndex = 0
        Else
            MultiViewError.ActiveViewIndex = 0
        End If

    End Sub

    Protected Sub btnfilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfilter.Click
        MultiView1a.ActiveViewIndex = 0
    End Sub



    Protected Sub cDate_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [cDate].SelectionChanged
        txtDate.Text = [cDate].SelectedDate.ToString
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        [cDate].Visible = True
    End Sub



    Function GetData_UserSecurity(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_UserSecurity = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_UserSecurity = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                lblAkses.Text = nSr(MyRecReadA("AKSES_DATA"))
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function
    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function

End Class
