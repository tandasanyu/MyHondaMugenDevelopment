Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Net.Mail
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization

Partial Class HRDHAKAKSES
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If

        If LblUserName.Text = "" Then
            Dim x As String
            Dim mFound As Byte = 0
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = x.ToString
            If LblUserName.Text = "TINI" Or LblUserName.Text = "HRD112" Then
                MultiViewAkses.ActiveViewIndex = 0
            Else
                MultiViewAkses.ActiveViewIndex = -1
            End If
        End If
    End Sub

    Protected Sub cariUsername(sender As Object, e As EventArgs)
        txtUsername.Text = Lbluser.Text
    End Sub
    Sub Msg_err(ByVal mTest As String)
        lblMsgBox.Text = mTest
        If mTest = "" Then
            MultiViewError.ActiveViewIndex = 0
        Else
            MultiViewError.ActiveViewIndex = 0
        End If
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
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
        End Try
    End Function
    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function

    Function DtFrSQL(ByRef mNilai As Object) As String
        On Error GoTo ErrHand
        DtFrSQL = "NULL"
        If IsDate(mNilai) Then
            DtFrSQL = "'" & Format(CDate(mNilai), "yyyy-MM-dd HH:MM:ss") & "'"
        End If
        'MsgBox(DtFrSQL)
ErrHand:
    End Function

    Protected Sub simpanAkses_Click(sender As Object, e As EventArgs) Handles simpanAkses.Click
        If Lbluser.Text = "" Then
            Response.Write("<script>alert('Nama user tidak boleh kosong!')</script>")
            MultiViewAkses.ActiveViewIndex = 0
        Else
            If GetFindRecord_Server("SELECT * FROM tb_userutility  WHERE  hakakses='" & txtHakakses.Text & "' and username ='" & Lbluser.Text & "'") <> 1 Then
                If UpdateData_Server(InsertDataNilaiSTANDARD) = 1 Then
                    Response.Write("<script>alert('Penambahan hak akses berhasil dilakukan!')</script>")
                    ListView2.DataBind()
                    MultiViewAkses.ActiveViewIndex = 0
                End If
            Else
                Response.Write("<script>alert('GAGAL! Penambahan hak akses untuk username tersebut telah diberikan sebelumnya')</script>")
                Response.Write("<script>window.location.href='HRDHAKAKSES.aspx';</script>")
            End If
        End If


    End Sub

    Function InsertDataNilaiSTANDARD() As String
        InsertDataNilaiSTANDARD = "INSERT INTO TB_USERUTILITY (username,hakakses) VALUES ('" & txtUsername.Text & "','" & txtHakakses.Text & "')"
    End Function

    Protected Sub ListView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Dim idutility As String = (ListView2.DataKeys(ListView2.SelectedIndex).Value.ToString)
        Call UpdateData_Server("DELETE FROM tb_userutility  WHERE username='" & Lbluser.Text & "' AND idutility = '" & idutility & "'")
        Response.Write("<script>alert('Hak akses untuk user ini berhasil dihapus!')</script>")
        ListView2.DataBind()
        MultiViewAkses.ActiveViewIndex = 0
    End Sub

    Function GetFindRecord_Server(ByVal mSqlCommadstring As String) As Integer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetFindRecord_Server = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                GetFindRecord_Server = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function

    Function UpdateData_Server(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        UpdateData_Server = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_Server = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function
End Class
