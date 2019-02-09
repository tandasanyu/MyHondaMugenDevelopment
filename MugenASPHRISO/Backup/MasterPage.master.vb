Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Public MyRecReadA As OleDbDataReader
    Public Event TxtUser_TextChanged As EventHandler

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim LblUserName = Session("MainContent")

        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        'Dim GetData_UserSecurity As Integer
        Dim mSqlCommadstring As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'ISO -- VIEW MENU'"
        Dim mSqlCommadstring2 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM PANDUAN MUTU -- VIEW DATA'"
        Dim mSqlCommadstring3 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM SOP -- VIEW DATA'"
        Dim mSqlCommadstring4 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'FORM INSTRUKSI KERJA -- VIEW DATA'"
        Dim mSqlCommadstring5 As String = "SELECT * FROM tb_userutility WHERE username = '" + LblUserName + "' and hakakses = 'ISO APPROVAL -- VIEW MENU'"
        Dim MyRecReadA As OleDbDataReader

        cnn = New OleDbConnection(strconn)

        'GetData_UserSecurity = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                iso.Visible = True
            Else
                iso.visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring2, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                panduanmutu.Visible = True
            Else
                panduanmutu.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring3, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                sop.Visible = True
            Else
                sop.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring4, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                instruksi.Visible = True
            Else
                instruksi.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring5, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows Then
                approval.Visible = True
            Else
                approval.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try


    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.UserAgent.IndexOf("AppleWebKit") > 0 Then
            Request.Browser.Adapters.Clear()
        End If

        Dim mNilai As String
        If Request("myname") IsNot Nothing Then
            mNilai = Server.UrlEncode(Request.QueryString("myname"))
            If mNilai <> "" Then
                LblUser.Text = mNilai
                TxtUser.Text = mNilai
                Dim x As String
                x = LblUser.Text
                Session("MainContent") = x
            End If
        End If
    End Sub

    Protected Sub LoginStatus1_LoggingOut(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles LoginStatus1.LoggingOut
        FormsAuthentication.SignOut()
        Response.Redirect("login.aspx", True)
    End Sub



    Protected Sub TxtUser_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUser.TextChanged

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
            cmd.ExecuteReader()
            GetData_UserSecurity = IIf(MyRecReadA.HasRows = True, 1, 0)
            If MyRecReadA.HasRows = 1 Then
                backup.Visible = True
                login.Visible = True
                sdr.Visible = True
            Else
                backup.Visible = False
                login.Visible = False
                sdr.Visible = False
            End If
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
        End Try
    End Function
End Class

