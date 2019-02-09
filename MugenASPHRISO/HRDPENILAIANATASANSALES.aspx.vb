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

Partial Class HRDPENILAIANATASANSALES
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

            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'FORM HRD -- PENILAIAN SALES'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0
                MultiViewNilaiStandardEntry.ActiveViewIndex = 0
                TahunPenilaian.Text = DateTime.Now.Year.ToString()
            Else
                MultiViewAkses.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
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
    Protected Sub BtnStandardSave_Click(sender As Object, e As EventArgs) Handles BtnStandardSave.Click
        If TxtStaffNIK.Text = "" And lblAtasan.Text = "" Then
            LabelError.Text = "Kode Sales / Nama Atasan Wajib Diisi"
        Else
            Call SaveTombol()
        End If

    End Sub


    Sub insertabel(ByVal mKPIN_KODE As String, ByVal mKPIN_USER As String, ByVal mKPIN_ATASAN As String, ByVal mKPIN_NILAI As String, ByVal mKPIN_TGL As String, ByVal mKPIN_NOTE As String)
        Dim myinsert = "insert INTO TRXN_KPIN (KPIN_USER,KPIN_ATASAN,KPIN_KODE,KPIN_NILAI,KPIN_TGL,KPIN_NOTE,KPIN_GROUP) VALUES " & _
                       "('" & mKPIN_USER & "','" & mKPIN_ATASAN & "','" & mKPIN_KODE & "','" & mKPIN_NILAI & "','" & Now() & "','" & mKPIN_NOTE & "','2')"
        Call UpdateData_Server(myinsert)
    End Sub

    Sub SaveTombol()
        Call UpdateData_Server("DELETE FROM TRXN_KPIN WHERE KPIN_USER='" & TxtStaffNIK.Text & "' AND KPIN_TAHUN like '%" & TahunPenilaian.Text & "%' AND KPIN_GROUP = '2'")
        If RadioButton01.Text = "" Then
            LabelError.Text = "Pertanyaan No 1 Wajib Diisi"
        Else
            Call insertabel("001", TxtStaffNIK.Text, lblAtasan.Text, RadioButton01.Text, "", "")
        End If

        If RadioButton02.Text = "" Then
            LabelError.Text = "Pertanyaan No 2 Wajib Diisi"
        Else
            Call insertabel("002", TxtStaffNIK.Text, lblAtasan.Text, RadioButton02.Text, "", "")
        End If

        If RadioButton03.Text = "" Then
            LabelError.Text = "Pertanyaan No 3 Wajib Diisi"
        Else
            Call insertabel("003", TxtStaffNIK.Text, lblAtasan.Text, RadioButton03.Text, "", "")
        End If

        If RadioButton04.Text = "" Then
            LabelError.Text = "Pertanyaan No 4 Wajib Diisi"
        Else
            Call insertabel("004", TxtStaffNIK.Text, lblAtasan.Text, RadioButton04.Text, "", "")
        End If

        If RadioButton05.Text = "" Then
            LabelError.Text = "Pertanyaan No 5 Wajib Diisi"
        Else
            Call insertabel("005", TxtStaffNIK.Text, lblAtasan.Text, RadioButton05.Text, "", "")
        End If

        If RadioButton06.Text = "" Then
            LabelError.Text = "Pertanyaan No 6 Wajib Diisi"
        Else
            Call insertabel("006", TxtStaffNIK.Text, lblAtasan.Text, RadioButton06.Text, "", "")
        End If

        If RadioButton07.Text = "" Then
            LabelError.Text = "Pertanyaan No 7 Wajib Diisi"
        Else
            Call insertabel("007", TxtStaffNIK.Text, lblAtasan.Text, RadioButton07.Text, "", "")
        End If

        If RadioButton08.Text = "" Then
            LabelError.Text = "Pertanyaan No 8 Wajib Diisi"
        Else
            Call insertabel("008", TxtStaffNIK.Text, lblAtasan.Text, RadioButton08.Text, "", "")
        End If

        If RadioButton09.Text = "" Then
            LabelError.Text = "Pertanyaan No 9 Wajib Diisi"
        Else
            Call insertabel("009", TxtStaffNIK.Text, lblAtasan.Text, RadioButton09.Text, "", "")
        End If

        If RadioButton10.Text = "" Then
            LabelError.Text = "Pertanyaan No 10 Wajib Diisi"
        Else
            Call insertabel("010", TxtStaffNIK.Text, lblAtasan.Text, RadioButton10.Text, "", "")
        End If

        If RadioButton11.Text = "" Then
            LabelError.Text = "Pertanyaan No 11 Wajib Diisi"
        Else
            Call insertabel("011", TxtStaffNIK.Text, lblAtasan.Text, RadioButton11.Text, "", "")
        End If

        If RadioButton12.Text = "" Then
            LabelError.Text = "Pertanyaan No 12 Wajib Diisi"
        Else
            Call insertabel("012", TxtStaffNIK.Text, lblAtasan.Text, RadioButton12.Text, "", "")
        End If

        If RadioButton13.Text = "" Then
            LabelError.Text = "Pertanyaan No 13 Wajib Diisi"
        Else
            Call insertabel("013", TxtStaffNIK.Text, lblAtasan.Text, RadioButton13.Text, "", "")
        End If

        If RadioButton14.Text = "" Then
            LabelError.Text = "Pertanyaan No 14 Wajib Diisi"
        Else
            Call insertabel("014", TxtStaffNIK.Text, lblAtasan.Text, RadioButton14.Text, "", "")
        End If

        If RadioButton15.Text = "" Then
            LabelError.Text = "Pertanyaan No 15 Wajib Diisi"
        Else
            Call insertabel("015", TxtStaffNIK.Text, lblAtasan.Text, RadioButton15.Text, "", "")
        End If

        If RadioButton16.Text = "" Then
            LabelError.Text = "Pertanyaan No 16 Wajib Diisi"
        Else
            Call insertabel("016", TxtStaffNIK.Text, lblAtasan.Text, RadioButton16.Text, "", "")
        End If

        If RadioButton17.Text = "" Then
            LabelError.Text = "Pertanyaan No 17 Wajib Diisi"
        Else
            Call insertabel("017", TxtStaffNIK.Text, lblAtasan.Text, RadioButton17.Text, "", "")
        End If

        If RadioButton18.Text = "" Then
            LabelError.Text = "Pertanyaan No 18 Wajib Diisi"
        Else
            Call insertabel("018", TxtStaffNIK.Text, lblAtasan.Text, RadioButton18.Text, "", "")
        End If

        If RadioButton19.Text = "" Then
            LabelError.Text = "Pertanyaan No 19 Wajib Diisi"
        Else
            Call insertabel("019", TxtStaffNIK.Text, lblAtasan.Text, RadioButton19.Text, "", "")
        End If
        If RadioButton20.Text = "" Then
            LabelError.Text = "Pertanyaan No 20 Wajib Diisi"
        Else
            Call insertabel("020", TxtStaffNIK.Text, lblAtasan.Text, RadioButton20.Text, "", "")
        End If
        Call insertabel("021", TxtStaffNIK.Text, lblAtasan.Text, "", "", TxtKomentar.Text)
        Response.Write("<script>alert('Anda telah sukses melakukan penilaian Atasan!')</script>")
        Response.Write("<script>window.location.href='Default.aspx';</script>")
    End Sub

    Function UpdateData_Server(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        LabelError.Text = ""
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
