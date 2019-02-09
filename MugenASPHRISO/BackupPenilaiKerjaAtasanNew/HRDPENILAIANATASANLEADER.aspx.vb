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

Partial Class HRDPENILAIANATASANLEADER
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

            Call GetData_STAFF2("SELECT * FROM TB_USER WHERE username='" & LblUserName.Text & "'")
            Call GetData_STAFF("SELECT * FROM DATA_STAFF WHERE STAFF_NIK='" & TxtStaffNIK.Text & "'")
            Call GetData_UserHead(" Select divisi.kddivisi, divisi.headdivisi, tb_user.namakaryawan, tb_user.kdkaryawan from divisi, tb_user WHERE namakaryawan = '" & TxtStaffNama.Text & "' And divisi.kddivisi collate SQL_Latin1_General_CP1_CI_AS  = tb_user.kddivisi2 collate SQL_Latin1_General_CP1_CI_AS")
            Call GetData_UserHead2(" Select divisi.kddivisi, divisi.headdivisi, tb_user.namakaryawan, tb_user.kdkaryawan from divisi, tb_user WHERE namakaryawan = '" & TxtStaffNama.Text & "' And divisi.kddivisi collate SQL_Latin1_General_CP1_CI_AS  = tb_user.kddivisi3 collate SQL_Latin1_General_CP1_CI_AS")


            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' And hakakses = 'FORM HRD -- PENILAIAN LEADER'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0

            Else
                MultiViewAkses.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub

    Function GetData_STAFF2(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_STAFF2 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtStaffNIK.Text = nSr(MyRecReadA("KDKARYAWAN"))
                TxtNama.Text = nSr(MyRecReadA("NAMAKARYAWAN"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function
    Function GetData_STAFF(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_STAFF = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtStaffNIK.Text = nSr(MyRecReadA("STAFF_NIK"))

                TxtStaffNIK.Enabled = False
                TxtStaffNama.Text = nSr(MyRecReadA("STAFF_NAMA"))
                TxtStatusKerjaJabatan.Text = nSr(MyRecReadA("STAFF_STATUSKERJAJABATAN"))
                TxtStatusKerjaTempat.Text = nSr(MyRecReadA("STAFF_STATUSKERJALOKASI")) + " / " + nSr(MyRecReadA("STAFF_STATUSKERJADEPT"))

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Function

    Function GetData_UserHead(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_UserHead = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_UserHead = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                TxtHead.Text = nSr(MyRecReadA("HEADDIVISI"))

            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
        End Try
    End Function

    Function GetData_UserHead2(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_UserHead2 = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_UserHead2 = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                TxtHead2.Text = nSr(MyRecReadA("HEADDIVISI"))

            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            'Call Msg_err(ex.Message)
        End Try
    End Function

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
        Call SaveTombol()
    End Sub

    Sub insertabel(ByVal mKPIN_USER As String, ByVal mKPIN_ATASAN As String, ByVal mKPIN_KODE As String, ByVal mKPIN_NILAI As String, ByVal mKPIN_TGL As String, ByVal mKPIN_NOTE As String)
        Dim myinsert = "insertabel INTO (KPIN_USER,KPIN_ATASAN,KPIN_KODE,KPIN_NILAI,KPIN_TGL,KPIN_NOTE,KPIN_GROUP) VALUES " & _
                       "('" & mKPIN_USER & "','" & mKPIN_ATASAN & "','" & mKPIN_KODE & "','" & mKPIN_NILAI & "',GETDATE(),'" & mKPIN_NOTE & "','2')"

    End Sub

    Sub SaveTombol()
        Dim mNilai As Byte = 0
        mNilai = "0"
        If RadioButton011.Checked = True Then
            mNilai = 1
        ElseIf RadioButton012.Checked = True Then
            mNilai = 2
        ElseIf RadioButton013.Checked = True Then
            mNilai = 3
        ElseIf RadioButton014.Checked = True Then
            mNilai = 4
        ElseIf RadioButton015.Checked = True Then
            mNilai = 5
        ElseIf RadioButton016.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("001", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton021.Checked = True Then
            mNilai = 1
        ElseIf RadioButton022.Checked = True Then
            mNilai = 2
        ElseIf RadioButton023.Checked = True Then
            mNilai = 3
        ElseIf RadioButton024.Checked = True Then
            mNilai = 4
        ElseIf RadioButton025.Checked = True Then
            mNilai = 5
        ElseIf RadioButton026.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("002", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")

        mNilai = "0"
        If RadioButton031.Checked = True Then
            mNilai = 1
        ElseIf RadioButton032.Checked = True Then
            mNilai = 2
        ElseIf RadioButton033.Checked = True Then
            mNilai = 3
        ElseIf RadioButton034.Checked = True Then
            mNilai = 4
        ElseIf RadioButton035.Checked = True Then
            mNilai = 5
        ElseIf RadioButton036.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("003", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton041.Checked = True Then
            mNilai = 1
        ElseIf RadioButton042.Checked = True Then
            mNilai = 2
        ElseIf RadioButton043.Checked = True Then
            mNilai = 3
        ElseIf RadioButton044.Checked = True Then
            mNilai = 4
        ElseIf RadioButton045.Checked = True Then
            mNilai = 5
        ElseIf RadioButton046.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("004", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton051.Checked = True Then
            mNilai = 1
        ElseIf RadioButton052.Checked = True Then
            mNilai = 2
        ElseIf RadioButton053.Checked = True Then
            mNilai = 3
        ElseIf RadioButton054.Checked = True Then
            mNilai = 4
        ElseIf RadioButton055.Checked = True Then
            mNilai = 5
        ElseIf RadioButton056.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("005", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton061.Checked = True Then
            mNilai = 1
        ElseIf RadioButton062.Checked = True Then
            mNilai = 2
        ElseIf RadioButton063.Checked = True Then
            mNilai = 3
        ElseIf RadioButton064.Checked = True Then
            mNilai = 4
        ElseIf RadioButton065.Checked = True Then
            mNilai = 5
        ElseIf RadioButton066.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("006", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton071.Checked = True Then
            mNilai = 1
        ElseIf RadioButton072.Checked = True Then
            mNilai = 2
        ElseIf RadioButton073.Checked = True Then
            mNilai = 3
        ElseIf RadioButton074.Checked = True Then
            mNilai = 4
        ElseIf RadioButton075.Checked = True Then
            mNilai = 5
        ElseIf RadioButton076.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("007", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton081.Checked = True Then
            mNilai = 1
        ElseIf RadioButton082.Checked = True Then
            mNilai = 2
        ElseIf RadioButton083.Checked = True Then
            mNilai = 3
        ElseIf RadioButton084.Checked = True Then
            mNilai = 4
        ElseIf RadioButton085.Checked = True Then
            mNilai = 5
        ElseIf RadioButton086.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("008", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton091.Checked = True Then
            mNilai = 1
        ElseIf RadioButton092.Checked = True Then
            mNilai = 2
        ElseIf RadioButton093.Checked = True Then
            mNilai = 3
        ElseIf RadioButton094.Checked = True Then
            mNilai = 4
        ElseIf RadioButton095.Checked = True Then
            mNilai = 5
        ElseIf RadioButton096.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("009", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton101.Checked = True Then
            mNilai = 1
        ElseIf RadioButton102.Checked = True Then
            mNilai = 2
        ElseIf RadioButton103.Checked = True Then
            mNilai = 3
        ElseIf RadioButton104.Checked = True Then
            mNilai = 4
        ElseIf RadioButton105.Checked = True Then
            mNilai = 5
        ElseIf RadioButton106.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("010", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton111.Checked = True Then
            mNilai = 1
        ElseIf RadioButton112.Checked = True Then
            mNilai = 2
        ElseIf RadioButton113.Checked = True Then
            mNilai = 3
        ElseIf RadioButton114.Checked = True Then
            mNilai = 4
        ElseIf RadioButton115.Checked = True Then
            mNilai = 5
        ElseIf RadioButton116.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("011", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton121.Checked = True Then
            mNilai = 1
        ElseIf RadioButton122.Checked = True Then
            mNilai = 2
        ElseIf RadioButton123.Checked = True Then
            mNilai = 3
        ElseIf RadioButton124.Checked = True Then
            mNilai = 4
        ElseIf RadioButton125.Checked = True Then
            mNilai = 5
        ElseIf RadioButton126.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("012", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton131.Checked = True Then
            mNilai = 1
        ElseIf RadioButton132.Checked = True Then
            mNilai = 2
        ElseIf RadioButton133.Checked = True Then
            mNilai = 3
        ElseIf RadioButton134.Checked = True Then
            mNilai = 4
        ElseIf RadioButton135.Checked = True Then
            mNilai = 5
        ElseIf RadioButton136.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("013", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton141.Checked = True Then
            mNilai = 1
        ElseIf RadioButton142.Checked = True Then
            mNilai = 2
        ElseIf RadioButton143.Checked = True Then
            mNilai = 3
        ElseIf RadioButton144.Checked = True Then
            mNilai = 4
        ElseIf RadioButton145.Checked = True Then
            mNilai = 5
        ElseIf RadioButton146.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("014", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton151.Checked = True Then
            mNilai = 1
        ElseIf RadioButton152.Checked = True Then
            mNilai = 2
        ElseIf RadioButton153.Checked = True Then
            mNilai = 3
        ElseIf RadioButton154.Checked = True Then
            mNilai = 4
        ElseIf RadioButton155.Checked = True Then
            mNilai = 5
        ElseIf RadioButton156.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("015", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        If RadioButton161.Checked = True Then
            mNilai = 1
        ElseIf RadioButton162.Checked = True Then
            mNilai = 2
        ElseIf RadioButton163.Checked = True Then
            mNilai = 3
        ElseIf RadioButton164.Checked = True Then
            mNilai = 4
        ElseIf RadioButton165.Checked = True Then
            mNilai = 5
        ElseIf RadioButton166.Checked = True Then
            mNilai = 6
        End If
        Call insertabel("016", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", "")
        mNilai = "0"
        Call insertabel("001", TxtStaffNama.Text, lblAtasan.Text, mNilai, "", TxtKomentar.Text)

    End Sub

End Class
