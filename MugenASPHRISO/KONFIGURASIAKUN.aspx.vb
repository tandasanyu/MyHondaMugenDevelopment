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

Partial Class KONFIGURASIAKUN
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
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'DATABASE KARYAWAN -- VIEW DATA'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0
                MultiViewNilaiStandardEntry.ActiveViewIndex = -1
            Else
                MultiViewAkses.ActiveViewIndex = -1
                MultiViewNilaiStandardEntry.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub

    Protected Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        TxtNIK.Text = (ListView1.DataKeys(ListView1.SelectedIndex).Value.ToString)
        Call GetData_MASTER("SELECT * FROM TB_USER  WHERE kdkaryawan='" & TxtNIK.Text & "'")
        MultiViewNilaiStandardEntry.ActiveViewIndex = 0
        MultiViewAkses.ActiveViewIndex = -1
    End Sub

    Protected Sub ListView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        TxtKode.Text = (ListView2.DataKeys(ListView2.SelectedIndex).Value.ToString)
        Call GetDataDivisi_MASTER("SELECT * FROM Divisi Where kddivisi='" & TxtKode.Text & "'")
        MultiViewNilaiStandardEntry2.ActiveViewIndex = 0
        MultiViewAkses.ActiveViewIndex = -1
    End Sub



    Function GetData_MASTER(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_MASTER = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtNama.Text = nSr(MyRecReadA("NAMAKARYAWAN"))
                TxtUsername.Text = nSr(MyRecReadA("USERNAME"))
                TxtPassword.Text = nSr(MyRecReadA("PASSWORD"))
                TxtAtasanLangsung.Text = MyRecReadA("KDDIVISI2")
                TxtAtasanLangsung2.Text = MyRecReadA("KDDIVISI3")
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Function GetDataDivisi_MASTER(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetDataDivisi_MASTER = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtNmDivisi.Text = nSr(MyRecReadA("NMDIVISI"))
                TxtEmail.Text = nSr(MyRecReadA("EMAILDIVISI"))
                TxtHead.Text = nSr(MyRecReadA("HEADDIVISI"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Protected Sub BtnStandardSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardSave.Click
        Call UpdateData_Server(EditDataNilaiSTANDARD)
        ListView1.DataBind()
        ListView2.DataBind()
        Response.Write("<script>alert('Anda telah sukses melakukan perubahan data Atasan!')</script>")
        Response.Write("<script>window.location.href='KONFIGURASIAKUN.aspx';</script>")

    End Sub
    Protected Sub BtnStandardDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardDelete.Click
        Call UpdateData_Server("DELETE FROM TB_USER WHERE KDKARYAWAN='" & TxtNIK.Text & "'")
        Response.Write("<script>alert('Data Berhasil Di hapus!')</script>")
        Response.Write("<script>window.location.href='KONFIGURASIAKUN.aspx';</script>")

    End Sub

    Protected Sub BtnStandardSave2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardSave2.Click
        If GetFindRecord_Server("SELECT * FROM DIVISI  WHERE  KDDIVISI='" & TxtKode.Text & "'") <> 1 Then
            Call UpdateData_Server("INSERT INTO DIVISI (kddivisi, nmdivisi, emaildivisi, headdivisi) VALUES ('" & TxtKode.Text & "','" & TxtNmDivisi.Text & "','" & TxtEmail.Text & "','" & TxtHead.Text & "')")
        End If
        Call UpdateData_Server(EditDataNilaiSTANDARD2)
        ListView2.DataBind()
        Response.Write("<script>alert('Anda telah sukses melakukan perubahan data Divisi!')</script>")
        Response.Write("<script>window.location.href='KONFIGURASIAKUN.aspx';</script>")
    End Sub
    Protected Sub BtnStandardDelete2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardDelete2.Click
        Call UpdateData_Server("DELETE FROM DIVISI WHERE KDDIVISI='" & TxtKode.Text & "'")
        Response.Write("<script>alert('Data Berhasil Di hapus!')</script>")
        Response.Write("<script>window.location.href='KONFIGURASIAKUN.aspx';</script>")

    End Sub

    Function EditDataNilaiSTANDARD() As String
        EditDataNilaiSTANDARD = "UPDATE tb_user SET " & _
                                "USERNAME='" & TxtUsername.Text & "'," & _
                                "PASSWORD='" & TxtPassword.Text & "'," & _
                                "KDDIVISI2='" & TxtAtasanLangsung.Text & "'," & _
                                "KDDIVISI3='" & TxtAtasanLangsung2.Text & "'" & _
                                "WHERE KDKARYAWAN='" & TxtNIK.Text & "'"
    End Function

    Function EditDataNilaiSTANDARD2() As String
        EditDataNilaiSTANDARD2 = "UPDATE divisi SET " & _
                                "NMDIVISI='" & TxtNmDivisi.Text & "'," & _
                                "EMAILDIVISI='" & TxtEmail.Text & "'," & _
                                "HEADDIVISI='" & TxtHead.Text & "'" & _
                                "WHERE KDDIVISI='" & TxtKode.Text & "'"
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
End Class
