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
    Public kode As Integer
    Public namasales As String

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

            If Left(LblUserName.Text, 3) = "112" Or Left(LblUserName.Text, 3) = "128" Then
                mFound = GetData_UserSecurity("SELECT * FROM DATA_SECURITYH,DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(SECURITYH_USER)=RTRIM(USER_NAMA) AND RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & Left(LblUserName.Text, 3) & "' AND SECURITYH_NOIDSALES='" & Right(LblUserName.Text, Len(LblUserName.Text) - 3) & "' AND USER_TIPE='WA' AND AKSES_MENU='0102'")
                If mFound = 1 Then
                    lblArea1.Text = Left(LblUserName.Text, 3)
                    lblArea2.Text = Left(LblUserName.Text, 3)
                End If
            Else
                mFound = GetData_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0102'")
            End If
        End If
        Dim KODE_SALES As String = LblUserName.Text.Remove(0, 3) 'value vye
        If Left(LblUserName.Text, 3) = "112" Then
            kode = 112
            'get nama sales
            Call GetData_DetaiIzinStaff("select * from data_salesman where SALES_Kode = '" & KODE_SALES & "'", 1)
        Else
            kode = 128
            'get nama sales
            Call GetData_DetaiIzinStaff("select * from data_salesman where SALES_Kode = '" & KODE_SALES & "'", 1)
        End If


        MultiViewAkses.ActiveViewIndex = 0
        MultiViewNilaiStandardEntry.ActiveViewIndex = 0
        TahunPenilaian.Text = (DateTime.Now.Year.ToString() - 1)
		TxtStaffNIK.Text = Strings.Mid(lblusername.text, 4)
		
    End Sub

    Function GetData_DetaiIzinStaff(ByVal mSqlCommadstring As String, ByVal mPos As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet88st").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_DetaiIzinStaff = 0

        cnn = New OleDbConnection(strconn)

        If mPos = 1 Then 'get detail staff
            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_DetaiIzinStaff = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    nama.Text = nSr(MyRecReadA("sales_nama"))
                    jabatan.Text = nSr(MyRecReadA("sales_jabatan"))
                    grup.Text = nSr(MyRecReadA("sales_group"))
                    subjabatan.Text = nSr(MyRecReadA("sales_subjabatan"))
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As SqlException
                'Call Msg_err(ex.Message)
            End Try
        End If
    End Function
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
        Call SaveTombol()
    End Sub

    Public hasil As Boolean

    Sub insertabel(ByVal mKPIN_KODE As String, ByVal mKPIN_USER As String, ByVal mKPIN_ATASAN As String, ByVal mKPIN_NILAI As String, ByVal mKPIN_TGL As String, ByVal mKPIN_NOTE As String)
        Dim myinsert = "insert INTO TRXN_KPIN (KPIN_NIK,KPIN_TAHUN,KPIN_USER,KPIN_ATASAN,KPIN_KODE,KPIN_NILAI,KPIN_TGL,KPIN_NOTE,KPIN_GROUP) VALUES " & _
                       "('" & TxtStaffNIK.Text & "','" & TahunPenilaian.Text & "','" & mKPIN_USER & "','" & mKPIN_ATASAN & "','" & mKPIN_KODE & "','" & mKPIN_NILAI & "','" & Now() & "','" & mKPIN_NOTE & "','2')"
        'Call UpdateData_Server(myinsert)
        If UpdateData_Server(myinsert) = 1 Then
            hasil = True
            'Response.Write("<script>alert('Anda telah sukses melakukan penilaian Atasan!')</script>")
            'Response.Write("<script>window.location.href='Form0102Aksesoris.aspx';</script>")
        Else
            hasil = False
            'Response.Write("<script>alert('Anda Gagal melakukan penilaian Atasan!')</script>")
            'Response.Write("<script>window.location.href='Form0102Aksesoris.aspx';</script>")
        End If
    End Sub

    Sub SaveTombol()
        If lblAtasan.SelectedIndex = 0 Then
            Response.Write("<script>alert('Atasan Wajib Di Isi')</script>")
            Response.Write("<script>window.location.href='Form0102Aksesoris.aspx';</script>")
        Else
            Call UpdateData_Server("DELETE FROM TRXN_KPIN WHERE KPIN_USER='" & TxtStaffNIK.Text & "' AND KPIN_TAHUN like '%" & TahunPenilaian.Text & "%' AND KPIN_GROUP = '2'")
            If RadioButton01.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 1 Wajib Diisi!')</script>")
            ElseIf RadioButton02.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 2 Wajib Diisi!')</script>")
            ElseIf RadioButton03.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 3 Wajib Diisi!')</script>")
            ElseIf RadioButton04.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 4 Wajib Diisi!')</script>")
            ElseIf RadioButton05.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 5 Wajib Diisi!')</script>")
            ElseIf RadioButton06.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 6 Wajib Diisi!')</script>")
            ElseIf RadioButton07.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 7 Wajib Diisi!')</script>")
            ElseIf RadioButton08.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 8 Wajib Diisi!')</script>")
            ElseIf RadioButton09.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 9 Wajib Diisi!')</script>")
            ElseIf RadioButton10.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 10 Wajib Diisi!')</script>")
            ElseIf RadioButton11.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 11 Wajib Diisi!')</script>")
            ElseIf RadioButton12.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 12 Wajib Diisi!')</script>")
            ElseIf RadioButton13.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 13 Wajib Diisi!')</script>")
            ElseIf RadioButton14.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 14 Wajib Diisi!')</script>")
            ElseIf RadioButton15.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 15 Wajib Diisi!')</script>")
            ElseIf RadioButton16.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 16 Wajib Diisi!')</script>")
            ElseIf RadioButton17.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 17 Wajib Diisi!')</script>")
            ElseIf RadioButton18.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 18 Wajib Diisi!')</script>")
            ElseIf RadioButton19.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 19 Wajib Diisi!')</script>")
            ElseIf RadioButton20.Text = "" Then
                Response.Write("<script>alert('Pertanyaan No 20 Wajib Diisi!')</script>")
            ElseIf TxtKomentar.Text = "" Then
                Response.Write("<script>alert('Komentar Wajib Diisi!')</script>")
            Else
                Call insertabel("001", TxtStaffNIK.Text, lblAtasan.Text, RadioButton01.Text, "", "")
                Call insertabel("002", TxtStaffNIK.Text, lblAtasan.Text, RadioButton02.Text, "", "")
                Call insertabel("003", TxtStaffNIK.Text, lblAtasan.Text, RadioButton03.Text, "", "")
                Call insertabel("004", TxtStaffNIK.Text, lblAtasan.Text, RadioButton04.Text, "", "")
                Call insertabel("005", TxtStaffNIK.Text, lblAtasan.Text, RadioButton05.Text, "", "")
                Call insertabel("006", TxtStaffNIK.Text, lblAtasan.Text, RadioButton06.Text, "", "")
                Call insertabel("007", TxtStaffNIK.Text, lblAtasan.Text, RadioButton07.Text, "", "")
                Call insertabel("008", TxtStaffNIK.Text, lblAtasan.Text, RadioButton08.Text, "", "")
                Call insertabel("009", TxtStaffNIK.Text, lblAtasan.Text, RadioButton09.Text, "", "")
                Call insertabel("010", TxtStaffNIK.Text, lblAtasan.Text, RadioButton10.Text, "", "")
                Call insertabel("011", TxtStaffNIK.Text, lblAtasan.Text, RadioButton11.Text, "", "")
                Call insertabel("012", TxtStaffNIK.Text, lblAtasan.Text, RadioButton12.Text, "", "")
                Call insertabel("013", TxtStaffNIK.Text, lblAtasan.Text, RadioButton13.Text, "", "")
                Call insertabel("014", TxtStaffNIK.Text, lblAtasan.Text, RadioButton14.Text, "", "")
                Call insertabel("015", TxtStaffNIK.Text, lblAtasan.Text, RadioButton15.Text, "", "")
                Call insertabel("016", TxtStaffNIK.Text, lblAtasan.Text, RadioButton16.Text, "", "")
                Call insertabel("017", TxtStaffNIK.Text, lblAtasan.Text, RadioButton17.Text, "", "")
                Call insertabel("018", TxtStaffNIK.Text, lblAtasan.Text, RadioButton18.Text, "", "")
                Call insertabel("019", TxtStaffNIK.Text, lblAtasan.Text, RadioButton19.Text, "", "")
                Call insertabel("020", TxtStaffNIK.Text, lblAtasan.Text, RadioButton20.Text, "", "")
                Call insertabel("021", TxtStaffNIK.Text, lblAtasan.Text, "", "", TxtKomentar.Text)
                If hasil = True Then
                    Response.Write("<script>alert('Anda telah sukses melakukan penilaian Atasan!')</script>")
                    Response.Write("<script>window.location.href='Form0102Aksesoris.aspx';</script>")
                Else

                    Response.Write("<script>alert('Anda Gagal melakukan penilaian Atasan!')</script>")
                    Response.Write("<script>window.location.href='Form0102Aksesoris.aspx';</script>")
                End If
            End If
        End If

    End Sub

    Function UpdateData_Server(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet5").ConnectionString
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
