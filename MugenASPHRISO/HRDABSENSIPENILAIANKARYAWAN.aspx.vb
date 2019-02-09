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

Partial Class ABSENSIKARYAWAN
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
        Call GetData_MASTER("Select * from(SELECT staff_nama, kpi_nik, kpi_kodeitem, kpi_staff FROM trxn_kpidd, data_staff where kpi_staff Is Not NULL And kpi_nik=staff_nik And kpi_nik='" & TxtNIK.Text & "') As a pivot (max (kpi_staff) For kpi_kodeitem In([AB1],[AB2],[AB3],[AB4],[AB5],[AB6])) As nilai")
        MultiViewAkses.ActiveViewIndex = -1
        MultiViewNilaiStandardEntry.ActiveViewIndex = 0
    End Sub

    Function GetData_MASTER(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
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
                TxtNama.Text = nSr(MyRecReadA("STAFF_NAMA"))
                AB1.Text = nSr(MyRecReadA("AB1"))
                AB2.Text = nSr(MyRecReadA("AB2"))
                AB3.Text = nSr(MyRecReadA("AB3"))
                AB4.Text = nSr(MyRecReadA("AB4"))
                AB5.Text = nSr(MyRecReadA("AB5"))
                AB6.Text = nSr(MyRecReadA("AB6"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function


    Protected Sub BtnStandardSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardSave.Click
        Dim thn_raw As Integer = Convert.ToInt32(DateTime.Now.ToString("yyyy")) - 1
        Dim thn_absolut As String = Convert.ToString(thn_raw)
        Call UpdateData_Server("Update TRXN_KPIDD set KPI_STAFF='" & AB1.Text & "' WHERE KPI_NIK = '" & TxtNIK.Text & "' AND KPI_TAHUN='" + thn_absolut + "' AND KPI_TIPEA = 'C' AND KPI_KODEITEM= 'AB1'")
        Call UpdateData_Server("Update TRXN_KPIDD set KPI_STAFF='" & AB2.Text & "' WHERE KPI_NIK = '" & TxtNIK.Text & "' AND KPI_TAHUN='" + thn_absolut + "' AND KPI_TIPEA = 'C' AND KPI_KODEITEM= 'AB2'")
        Call UpdateData_Server("Update TRXN_KPIDD set KPI_STAFF='" & AB3.Text & "' WHERE KPI_NIK = '" & TxtNIK.Text & "' AND KPI_TAHUN='" + thn_absolut + "' AND KPI_TIPEA = 'C' AND KPI_KODEITEM= 'AB3'")
        Call UpdateData_Server("Update TRXN_KPIDD set KPI_STAFF='" & AB4.Text & "' WHERE KPI_NIK = '" & TxtNIK.Text & "' AND KPI_TAHUN='" + thn_absolut + "' AND KPI_TIPEA = 'C' AND KPI_KODEITEM= 'AB4'")
        Call UpdateData_Server("Update TRXN_KPIDD set KPI_STAFF='" & AB5.Text & "' WHERE KPI_NIK = '" & TxtNIK.Text & "' AND KPI_TAHUN='" + thn_absolut + "' AND KPI_TIPEA = 'C' AND KPI_KODEITEM= 'AB5'")
        Call UpdateData_Server("Update TRXN_KPIDD set KPI_STAFF='" & AB6.Text & "' WHERE KPI_NIK = '" & TxtNIK.Text & "' AND KPI_TAHUN='" + thn_absolut + "' AND KPI_TIPEA = 'C' AND KPI_KODEITEM= 'AB6'")
        Response.Write("<script>alert('Anda sukses mengupdate data Absen Karyawan!')</script>")
        Response.Write("<script>window.location.href='HRDABSENSIPENILAIANKARYAWAN.aspx';</script>")
    End Sub

    Function UpdateData_Server(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
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
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
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
