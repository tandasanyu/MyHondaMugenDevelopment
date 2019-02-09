Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
'https://regexlib.com



Imports System.Web.Security
Partial Class login
    Inherits System.Web.UI.Page

    'Public 
    Public sqlconn As SqlConnection
    Public sqlcmd As SqlCommand
    Public MyReadDataTbl1 As SqlDataReader
    Public cons As OleDb.OleDbConnection



    Public MyRecReadA As OleDbDataReader

    ' Public conn1 As 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Function BukaFile(ByVal mSqlCommadstring As String, ByVal mField As String, ByVal mParam As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        BukaFile = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            If InStr(mSqlCommadstring, "SELECT") = 0 Then
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                cmd.ExecuteNonQuery()
                BukaFile = 1
                cmd.Dispose()
            Else
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                BukaFile = IIf(MyRecReadA.HasRows = True, 1, 0)
                If BukaFile = 1 And mField <> "" Then
                    MyRecReadA.Read()
                    If nSr(MyRecReadA(mField)) <> mParam Then
                        BukaFile = 2
                    End If
                End If
                '        While MyRecReadA.Read()
                ' MsgBox(MyRecReadA.Item(0) & "  -  " & MyRecReadA.Item(1) & "  -  " & MyRecReadA.Item(2))
                ' End While
                MyRecReadA.Close()

                cmd.Dispose()
            End If

            cnn.Close()
        Catch ex As Exception
            LblError.Text = "error " & ex.Message
        End Try
    End Function

    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function



    Protected Sub cmdLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        'Memanggil metode RedirectFromLoginPage untuk secara otomatis membuat cookie otentikasi formulir dan mengarahkan pengguna ke halaman yang sesuai di cmdLogin_ServerClick peristiwa:
        'If ValidateUser(txtUserName.Text, txtUserPass.Text) Then
        'FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, CheckBox1.Checked)
        'Else
        'Response.Redirect("logon.aspx", True)
        'End If

        'Membuat otentikasi Tiket, mengenkripsinya, membuat cookie, tambahkan ke respons dan mengarahkan pengguna. Ini memberikan lebih banyak kontrol di bagaimana Anda membuat cookie. Anda dapat juga menyertakan data kustom dengan FormsAuthenticationTicket dalam hal ini.
        Dim strRedirect As String
        If ValidateUser(txtUserName.Text, txtUserPass.Text) Then
            Dim tkt As FormsAuthenticationTicket
            Dim cookiestr As String
            Dim ck As HttpCookie

            tkt = New FormsAuthenticationTicket(1, txtUserName.Text, DateTime.Now(), _
                  DateTime.Now.AddMinutes(30), CheckBox1.Checked, "your custom data")
            cookiestr = FormsAuthentication.Encrypt(tkt)

            ck = New HttpCookie(FormsAuthentication.FormsCookieName(), cookiestr)
            If (CheckBox1.Checked) Then ck.Expires = tkt.Expiration
            ck.Path = FormsAuthentication.FormsCookiePath()
            Response.Cookies.Add(ck)
            strRedirect = Request("ReturnURL")
            strRedirect = "default.aspx?myname=" + Server.UrlEncode(txtUserName.Text)
            If strRedirect <> "" Then
                Response.Redirect(strRedirect, True)
            Else
                strRedirect = "default.aspx?myname=" + Server.UrlEncode(txtUserName.Text)
                Response.Redirect(strRedirect, True)
            End If
        Else
            'strRedirect = "default.aspx?myname=" + Server.UrlEncode(txtUserName.Text)
            'Response.Redirect(strRedirect, True)
            'Response.Redirect("logon.aspx", True)
        End If
    End Sub

    Function gETnOemAYdEVICE() As String
        gETnOemAYdEVICE = ""
        Try

        Catch ex As Exception

        End Try
    End Function

    Private Function ValidateUser(ByVal userName As String, ByVal passWord As String) As Boolean
        'Dim conn As SqlConnection
        'Dim cmd As SqlCommand
        Dim lookupPassword As String

        lookupPassword = Nothing

        ' Check for an invalid userName.
        ' userName  must not be set to nothing and must be between one and 15 characters.
        If ((userName Is Nothing)) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.")
            Return False
        End If
        If ((userName.Length = 0) Or (userName.Length > 15)) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.")
            Return False
        End If

        ' Check for invalid passWord.
        ' passWord must not be set to nothing and must be between one and 25 characters.
        If (passWord Is Nothing) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.")
            Return False
        End If
        If ((passWord.Length = 0) Or (passWord.Length > 25)) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.")
            Return False
        End If

        Dim userfound As Byte = 0
        userfound = BukaFile("SELECT * FROM DATA_SECURITYU WHERE User_nama= '" & txtUserName.Text & "' AND User_Password= '" & txtUserPass.Text & "' AND User_tipe='HR'", "", "")

        If userfound = 1 Then       '1
            Return True
        ElseIf userfound = 2 Then   '2
            LblError.Text = ("Password Salah lihat email subject Password Sales atau Hubungi IT")
            Return False
            'PeriksaImey
            'Dim mNoImey As String = ""
            'mNoImey = GetDeviceID()
            'userfound = BukaFile("SELECT * FROM DATA_SECURITYH WHERE SECURITYH_USER= '" & txtUserName.Text & "' AND SECURITYH_NOID= '" & mNoImey & "'", "")
            'If userfound = 1 Then
            'Return True
            'Else
            'Return False
            'End If
        Else                        '0
            LblError.Text = ("Username / Password salah !")
            'System.Diagnostics.Trace.WriteLine("[ValidateUser] Nama Pemakai atau Kata kunci tidak diterima")
            Return False
        End If



        'buku        Try
        'buku
        'buku        ' Consult with your SQL Server administrator for an appropriate connection
        'buku        ' string to use to connect to your local SQL Server.
        'buku        conn = New SqlConnection("server=localhost;Integrated Security=SSPI;database=pubs")
        'buku        conn.Open()

        'buku        ' Create SqlCommand to select pwd field from the users table given a supplied userName.
        'buku        cmd = New SqlCommand("Select pwd from users where uname=@userName", conn)
        'buku        cmd.Parameters.Add("@userName", SqlDbType.VarChar, 25)
        'buku        cmd.Parameters("@userName").Value = userName


        'buku        ' Execute command and fetch pwd field into lookupPassword string.
        'buku        lookupPassword = cmd.ExecuteScalar()

        'buku        ' Cleanup command and connection objects.
        'buku        cmd.Dispose()
        'buku        conn.Dispose()




        'buku        Catch ex As Exception
        'buku        ' Add error handling here for debugging.
        'buku        ' This error message should not be sent back to the caller.
        'buku        System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " & ex.Message)
        'buku        End Try

        'buku        ' If no password found, return false.
        'buku        If (lookupPassword Is Nothing) Then
        'buku        ' You could write failed login attempts here to the event log for additional security.
        'buku        Return False
        'buku        End If

        'buku        ' Compare lookupPassword and input passWord by using a case-sensitive comparison.
        'buku        Return (String.Compare(lookupPassword, passWord, False) = 0)

    End Function


End Class
