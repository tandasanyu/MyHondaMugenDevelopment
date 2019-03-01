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

Partial Class HRDREPORTPENILAIANKARYAWAN
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If
        'define value get tahun 
        Dim thn As String = DateTime.Now.ToString("yyyy")
        Dim hasil As Integer = Convert.ToInt32(thn) - 1
        LabelThn.Text = hasil

        If LblUserName.Text = "" Then
            Dim x As String
            Dim mFound As Byte = 0
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = x.ToString
            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'PENILAIAN KARYAWAN -- VIEW REPORT'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0
                MultiViewNilaiStandardEntry.ActiveViewIndex = -1
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'PENILAIAN KARYAWAN -- DOWNLOAD REPORT KPI'") = 1 Then
                    btnKPI.Visible = True
                End If
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'PENILAIAN KARYAWAN -- DOWNLOAD REPORT PK'") = 1 Then
                    btnPK.Visible = True
                End If
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'PENILAIAN KARYAWAN -- DOWNLOAD REPORT PENILAIAN BAWAHAN KE ATASAN (LEADER)'") = 1 Then
                    btnLD.Visible = True
                End If
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'PENILAIAN KARYAWAN -- DOWNLOAD REPORT PENILAIAN BAWAHAN KE ATASAN (SPV)'") = 1 Then
                    btnSPV.Visible = True
                End If
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'PENILAIAN KARYAWAN -- DOWNLOAD KOMENTAR BAWAHAN KE ATASAN'") = 1 Then
                    btnKomen.Visible = True
                End If
            Else
                MultiViewAkses.ActiveViewIndex = -1
                MultiViewNilaiStandardEntry.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub

    Protected Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        TxtNIK.Text = (ListView1.DataKeys(ListView1.SelectedIndex).Value.ToString)
        Call GetData_MASTER("SELECT * FROM TRXN_KPIH, DATA_STAFF  WHERE  KPIH_NIK='" & TxtNIK.Text & "' AND KPIH_TAHUN IN ('2017',2018) AND KPIH_NIK = STAFF_NIK")
        MultiViewNilaiStandardEntry.ActiveViewIndex = 0
        MultiViewAkses.ActiveViewIndex = -1
    End Sub

    Protected Sub ListView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        TxtNIK.Text = (ListView2.DataKeys(ListView2.SelectedIndex).Value.ToString)
        Call GetData_MASTER("SELECT * FROM TRXN_KPIH, DATA_STAFF  WHERE  KPIH_NIK='" & TxtNIK.Text & "' AND KPIH_TAHUN IN ('2017',2018) AND KPIH_NIK = STAFF_NIK")
        MultiViewNilaiStandardEntry.ActiveViewIndex = 0
        MultiViewAkses.ActiveViewIndex = -1
    End Sub

    Protected Sub ListView3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView3.SelectedIndexChanged
        TxtNIK.Text = (ListView3.DataKeys(ListView3.SelectedIndex).Value.ToString)
        Call GetData_MASTER("SELECT * FROM TRXN_KPIH, DATA_STAFF  WHERE  KPIH_NIK='" & TxtNIK.Text & "' AND KPIH_TAHUN IN ('2017',2018) AND KPIH_NIK = STAFF_NIK")
        MultiViewNilaiStandardEntry.ActiveViewIndex = 0
        MultiViewAkses.ActiveViewIndex = -1
    End Sub

    Protected Sub ListView4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView4.SelectedIndexChanged
        TxtNIK.Text = (ListView4.DataKeys(ListView4.SelectedIndex).Value.ToString)
        Call GetData_MASTER("SELECT * FROM TRXN_KPIH, DATA_STAFF  WHERE  KPIH_NIK='" & TxtNIK.Text & "' AND KPIH_TAHUN IN ('2017',2018) AND KPIH_NIK = STAFF_NIK")
        MultiViewNilaiStandardEntry.ActiveViewIndex = 0
        MultiViewAkses.ActiveViewIndex = -1
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
                TxtAtasanLangsung.Text = nSr(MyRecReadA("KPIH_APPVHEAD"))
                TxtAtasanLangsung2.Text = nSr(MyRecReadA("KPIH_APPVHEAD2"))


            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function

    Protected Sub BtnStandardSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStandardSave.Click

        'Call UpdateData_Server(EditDataNilaiSTANDARD)
        'ListView1.DataBind()
        'ListView2.DataBind()
        'ListView3.DataBind()
        'ListView4.DataBind()
        'Response.Write("<script>alert('Anda telah sukses melakukan perubahan data Atasan!')</script>")


        Response.Write("<script>window.location.href='HRDREPORTPENILAIANKARYAWAN.aspx';</script>")

    End Sub

    Function EditDataNilaiSTANDARD() As String
        EditDataNilaiSTANDARD = "UPDATE TRXN_KPIH SET " & _
                                  "KPIH_APPVHEAD='" & TxtAtasanLangsung.Text & "'," & _
                                  "KPIH_APPVHEAD2='" & TxtAtasanLangsung2.Text & "'" & _
                                  "WHERE KPIH_NIK='" & TxtNIK.Text & "' AND KPIH_TAHUN in ('2017','2018')"
    End Function

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

    Protected Sub btnPK_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=Report PK.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        ListViewPK.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub

    Protected Sub btnKPI_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=Report KPI.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        ListViewKPI.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub

    Protected Sub btnSPV_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=Report Penilaian Bawahan ke Atasan (SPV).xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        ListViewSPV.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub

    Protected Sub btnLD_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=Report Penilaian Bawahan ke Atasan (Leader).xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        ListViewLD.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub

    Protected Sub btnKomen_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=Komentar Bawahan ke Atasan.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        ListViewKomen.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub
End Class
