Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
'1 Cari
'2 Hapus dan Tambah Aksesoris
Partial Class SALES_Form0104Diskontypemaksimal
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If

        If TxtTampilan.Text = "1" Then
            Call UpdateData_Tabel_Tipe("DELETE FROM DATA_TYPEDTEMP")
            Call GetData_Tabel_TYPEMPORARYA("SELECT * FROM DATA_TYPE,DATA_TYPED WHERE TYPED_TYPE=TYPE_TYPE AND TYPED_ST='' AND TYPE_Aktif='0'  ORDER BY TYPED_Type,TYPED_Rangka,TYPED_Tanggal DESC ")
        End If

        If LblUserName.Text = "" Then
            Dim x As String
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = x.ToString

            If GetData_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(User_access)=RTRIM(AKSES_KODE) AND User_nama= '" & LblUserName.Text & "' AND User_tipe='WA' AND AKSES_MENU='0104'") = 1 Then
                MultiView1a.ActiveViewIndex = 0
                MultiView2a.ActiveViewIndex = TxtTampilan.Text
                If TxtCariKodeTahunSUmmary.Text = "" Then
                    TxtCariKodeTahunSUmmary.Text = "H"
                End If
            Else
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If


    End Sub

    Protected Sub lvBerita_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBerita.SelectedIndexChanged
        If Mid(lblAkses.Text, 2, 1) = "1" Then
            lblTipeKode.Text = (lvBerita.DataKeys(lvBerita.SelectedIndex).Value.ToString)
            Call GetData_Tabel_TYPE("SELECT *,GETDATE() as mTGL FROM DATA_TYPE,DATA_TYPED WHERE DATA_TYPE.TYPE_Type = DATA_TYPED.TYPED_Type AND DATA_TYPED.TYPED_ST<>'X' AND DATA_TYPE.TYPE_TYPE='" & lblTipeKode.Text & "' ORDER BY TYPED_RANGKA,TYPED_TANGGAL DESC")
            MultiView1a.ActiveViewIndex = 1
        End If
    End Sub

    Protected Sub lvGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVGroup.SelectedIndexChanged
        If Mid(lblAkses.Text, 2, 1) = "1" Then
            lblTipeKode.Text = (LVGroup.DataKeys(LVGroup.SelectedIndex).Value.ToString)
            Call GetData_Tabel_TYPE("SELECT *,GETDATE() as mTGL FROM DATA_TYPE,DATA_TYPED WHERE DATA_TYPE.TYPE_Type = DATA_TYPED.TYPED_Type AND DATA_TYPED.TYPED_ST<>'X' AND DATA_TYPE.TYPE_TYPE='" & lblTipeKode.Text & "' ORDER BY TYPED_RANGKA,TYPED_TANGGAL DESC")
            MultiView1a.ActiveViewIndex = 1
        End If
    End Sub


    Sub Msg_err(ByVal mTest As String)
        lblMsgBox.Text = mTest
        If mTest = "" Then
            MultiViewError.ActiveViewIndex = 0
        Else
            MultiViewError.ActiveViewIndex = 0
        End If
        MultiView1a.ActiveViewIndex = 1

    End Sub

    Sub clearTabel()
        Lbl01OldMax.Text = "" : Lbl01OldTgl.Text = ""
        Lbl02OldMax.Text = "" : Lbl02OldTgl.Text = ""
        Lbl03OldMax.Text = "" : Lbl03OldTgl.Text = ""
        Lbl04OldMAx.Text = "" : Lbl04OldTgl.Text = ""

        Lbl01NewKey1.Text = "" : Lbl01NewThn.Text = "" : Txt01NewMax.Text = "" : Txt01NewMax.Visible = False : Button11.Visible = False : Button12.Visible = False : Txt01NewTgl.Text = "" : ImgBntCalc.Visible = False : Txt01NewTgl.Visible = False
        Lbl02NewKey1.Text = "" : Lbl02NewThn.Text = "" : Txt02NewMax.Text = "" : Txt02NewMax.Visible = False : Button21.Visible = False : Button22.Visible = False : Txt02NewTgl.Text = "" : ImageButton1.Visible = False : Txt02NewTgl.Visible = False
        Lbl03NewKey1.Text = "" : Lbl03NewThn.Text = "" : Txt03NewMax.Text = "" : Txt03NewMax.Visible = False : Button31.Visible = False : Button32.Visible = False : Txt03NewTgl.Text = "" : ImageButton3.Visible = False : Txt03NewTgl.Visible = False
        Lbl04NewKey1.Text = "" : Lbl04NewThn.Text = "" : Txt04NewMax.Text = "" : Txt04NewMax.Visible = False : Button41.Visible = False : Button42.Visible = False : Txt04NewTgl.Text = "" : ImageButton2.Visible = False : Txt04NewTgl.Visible = False
    End Sub

    Function GetData_Tabel_TYPE(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mKeyRangka As String
        GetData_Tabel_TYPE = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Tabel_TYPE = IIf(MyRecReadA.HasRows = True, 1, 0)
            mKeyRangka = ""
            Call clearTabel()
            While MyRecReadA.Read()

                lblTipeKode.Text = nSr(MyRecReadA("TYPE_TYPE"))
                lblTipeNama.Text = nSr(MyRecReadA("TYPE_NAMA"))
                lblGroup.Text = nSr(MyRecReadA("TYPE_CDGROUP"))
                LblAktif.Text = nSr(MyRecReadA("TYPE_AKTIF"))

                If mKeyRangka <> nSr(MyRecReadA("TYPED_RANGKA")) Then
                    If Lbl01NewKey1.Text = "" Then
                        Lbl01NewKey1.Text = nSr(MyRecReadA("TYPED_RANGKA")) : Lbl01NewThn.Text = Tahun(nSr(MyRecReadA("TYPED_RANGKA"))) : Lbl01OldMax.Text = nSr(MyRecReadA("TYPED_JUMLAH")) : Lbl01OldTgl.Text = nSr(MyRecReadA("TYPED_TANGGAL"))
                        Txt01NewMax.Text = "0" : Txt01NewTgl.Text = ""
                        Txt01NewMax.Visible = True : Txt01NewTgl.Visible = True : ImgBntCalc.Visible = True
                        Button11.Visible = True : Button12.Visible = True

                    ElseIf Lbl02NewKey1.Text = "" Then
                        Lbl02NewKey1.Text = nSr(MyRecReadA("TYPED_RANGKA")) : Lbl02NewThn.Text = Tahun(nSr(MyRecReadA("TYPED_RANGKA"))) : Lbl02OldMax.Text = nSr(MyRecReadA("TYPED_JUMLAH")) : Lbl02OldTgl.Text = nSr(MyRecReadA("TYPED_TANGGAL"))
                        Txt02NewMax.Text = "0" : Txt02NewTgl.Text = ""
                        Txt02NewMax.Visible = True : Txt02NewTgl.Visible = True : ImageButton1.Visible = True
                        Button21.Visible = True : Button22.Visible = True

                    ElseIf Lbl03NewKey1.Text = "" Then
                        Lbl03NewKey1.Text = nSr(MyRecReadA("TYPED_RANGKA")) : Lbl03NewThn.Text = Tahun(nSr(MyRecReadA("TYPED_RANGKA"))) : Lbl03OldMax.Text = nSr(MyRecReadA("TYPED_JUMLAH")) : Lbl03OldTgl.Text = nSr(MyRecReadA("TYPED_TANGGAL"))
                        Txt03NewMax.Text = "0" : Txt03NewTgl.Text = ""
                        Txt03NewMax.Visible = True : Txt03NewTgl.Visible = True : ImageButton3.Visible = True
                        Button31.Visible = True : Button32.Visible = True

                    ElseIf Lbl04NewKey1.Text = "" Then
                        Lbl04NewKey1.Text = nSr(MyRecReadA("TYPED_RANGKA")) : Lbl04NewThn.Text = Tahun(nSr(MyRecReadA("TYPED_RANGKA"))) : Lbl04OldMAx.Text = nSr(MyRecReadA("TYPED_JUMLAH")) : Lbl04OldTgl.Text = nSr(MyRecReadA("TYPED_TANGGAL"))
                        Txt04NewMax.Text = "0" : Txt04NewTgl.Text = ""
                        Txt04NewMax.Visible = True : Txt04NewTgl.Visible = True : ImageButton2.Visible = True
                        Button41.Visible = True : Button42.Visible = True
                    End If
                    mKeyRangka = nSr(MyRecReadA("TYPED_RANGKA"))
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function GetData_Tabel_TYPEMPORARYA(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mKeyRangka, MySqlasString As String
        GetData_Tabel_TYPEMPORARYA = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Tabel_TYPEMPORARYA = IIf(MyRecReadA.HasRows = True, 1, 0)
            mKeyRangka = ""

            While MyRecReadA.Read()
                If mKeyRangka <> (nSr(MyRecReadA("TYPED_TYPE")) + nSr(MyRecReadA("TYPED_Rangka"))) Then
                    MySqlasString = "INSERT INTO DATA_TYPEDTEMP (TYPED_TYPE,TYPED_TANGGAL,TYPED_JUMLAH,TYPED_RANGKA,TYPED_ST,TYPED_112,TYPED_128,TYPED_TglInput,TYPED_UserInput) VALUES " & _
                                    "('" & nSr(MyRecReadA("TYPED_TYPE")) & "'," & DtFrSQL(nSr(MyRecReadA("TYPED_TANGGAL"))) & "," & nSr(MyRecReadA("TYPED_JUMLAH")) & ",'" & nSr(MyRecReadA("TYPED_RANGKA")) & "','" & nSr(MyRecReadA("TYPED_ST")) & "','','',GETDATE(),'WEB')"
                    Call UpdateData_Tabel_Tipe(MySqlasString)
                    mKeyRangka = (nSr(MyRecReadA("TYPED_TYPE")) + nSr(MyRecReadA("TYPED_Rangka")))
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function Tahun(ByVal mNilai As String) As String
        Dim mThn As String
        Tahun = ""
        mThn = Mid(mNilai, 7, 1)
        Tahun = Str(1945 + Asc(mThn))
    End Function



    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKembali1.Click
        MultiView1a.ActiveViewIndex = 0
    End Sub

    Function UpdateData_Tabel_Tipe(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        UpdateData_Tabel_Tipe = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_Tabel_Tipe = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
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


    Sub mSimpan(ByVal mTipe As String, ByVal mNo As Integer)
        Dim MySqlasString As String = ""
        If Mid(lblAkses.Text, 2, 1) <> "1" Then
            Call Msg_err("Anda tidak diperbolehkan merubah data diskon")
        Else
            Dim mTgl As String = ""
            Dim mJml As String = "0"
            Dim mRangka As String = ""
            Dim mErrorDesc As String = ""
            Dim mThn As String = ""
            If mNo = 1 Then
                mTgl = Txt01NewTgl.Text
                mJml = Txt01NewMax.Text
                mRangka = Lbl01NewKey1.Text
            ElseIf mNo = 2 Then
                mTgl = Txt02NewTgl.Text
                mJml = Txt02NewMax.Text
                mRangka = Lbl02NewKey1.Text
            ElseIf mNo = 3 Then
                mTgl = Txt03NewTgl.Text
                mJml = Txt03NewMax.Text
                mRangka = Lbl03NewKey1.Text
            ElseIf mNo = 4 Then
                mTgl = Txt04NewTgl.Text
                mJml = Txt04NewMax.Text
                mRangka = Lbl04NewKey1.Text
            End If
            mThn = Mid(mRangka, 7, 1)

            If Not IsNumeric(mJml) Or Val(mJml) <= 0 Then
                mErrorDesc = "Jumlah Bukan Numeric"
            End If
            If Not IsDate(mTgl) Then
                mErrorDesc = mErrorDesc & ", Bukan fromat Tanggal di kolom tanggal"
            End If
            If mThn = "" And mTipe <> "" Then
                mErrorDesc = mErrorDesc & ", Tidak ada Kode tahun untuk rangka tersebut"
            End If

            If mErrorDesc <> "" Then
                Call Msg_err(mErrorDesc)
            Else
                If mTipe = "" Then
                    MySqlasString = "UPDATE DATA_TYPED SET TYPED_ST='X',TYPED_112='',TYPED_128='' WHERE TYPED_TYPE='" & lblTipeKode.Text & "' AND TYPED_RANGKA='" & mRangka & "' AND DATEDIFF(DAY,TYPED_TANGGAL," & DtFrSQL(mTgl) & ")=0 "
                Else
                    MySqlasString = "UPDATE DATA_TYPED SET TYPED_ST='X',TYPED_112='',TYPED_128='' " & _
                                    "WHERE DATEDIFF(DAY,TYPED_TANGGAL," & DtFrSQL(mTgl) & ")=0 AND SUBSTRING(TYPED_RANGKA,7,1)='" & mThn & "' AND " & _
                                    "(SELECT TYPE_Type FROM DATA_TYPE WHERE TYPE_Type=TYPEd_Type AND TYPE_CdGroup='" & lblGroup.Text & "') IS NOT NULL"
                End If
                If UpdateData_Tabel_Tipe(MySqlasString) = 1 Then
                    If mTipe = "" Then
                        MySqlasString = "INSERT INTO DATA_TYPED (TYPED_TYPE,TYPED_TANGGAL,TYPED_JUMLAH,TYPED_RANGKA,TYPED_ST,TYPED_112,TYPED_128,TYPED_TglInput,TYPED_UserInput) VALUES " & _
                                        "('" & lblTipeKode.Text & "'," & DtFrSQL(mTgl) & "," & mJml & ",'" & mRangka & "','','','',GETDATE(),'WEB')"
                    Else
                        MySqlasString = "INSERT INTO DATA_TYPED " & _
                                        "SELECT TYPED_TYPE," & DtFrSQL(mTgl) & "," & mJml & ",TYPED_RANGKA,'','','',GETDATE(),'WEB' FROM DATA_TYPED,DATA_TYPE WHERE TYPED_Type=TYPE_Type AND TYPE_Aktif='0' AND TYPE_CdGroup='" & lblGroup.Text & "' AND SUBSTRING(TYPED_RANGKA,7,1)='" & mThn & "' GROUP BY TYPED_TYPE,TYPED_RANGKA"
                    End If
                    If UpdateData_Tabel_Tipe(MySqlasString) = 1 Then
                        Call Msg_err("Sukses tersimpan")
                    End If
                End If
            End If
        End If
    End Sub

    Function DtFrSQL(ByRef mNilai As Object) As String
        On Error GoTo ErrHand
        DtFrSQL = "NULL"
        If IsDate(mNilai) Then
            DtFrSQL = "'" & Format(CDate(mNilai), "yyyy-MM-dd HH:MM:ss") & "'"
        End If
        'MsgBox(DtFrSQL)
ErrHand:
    End Function

    Protected Sub Button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click
        Call mSimpan("", 1)
    End Sub

    Protected Sub Button12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button12.Click
        Call mSimpan("A", 1)
    End Sub

    Protected Sub Button21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button21.Click
        Call mSimpan("", 2)
    End Sub

    Protected Sub Button22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button22.Click
        Call mSimpan("A", 2)
    End Sub

    Protected Sub Button31_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button31.Click
        Call mSimpan("", 3)
    End Sub

    Protected Sub Button32_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button32.Click
        Call mSimpan("A", 3)
    End Sub

    Protected Sub Button41_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button41.Click
        Call mSimpan("", 4)
    End Sub

    Protected Sub Button42_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button42.Click
        Call mSimpan("A", 4)
    End Sub




End Class
