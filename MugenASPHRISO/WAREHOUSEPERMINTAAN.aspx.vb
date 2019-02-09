Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb

Partial Class WAREHOUSEPERMINTAAN
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

            If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM MINTA UNIT -- VIEW DATA'") = 1 Then
                MultiViewAkses.ActiveViewIndex = 0
                If GetData_UserSecurity("SELECT * FROM tb_userutility WHERE username = '" & LblUserName.Text & "' and hakakses = 'FORM MINTA UNIT -- ADD DATA'") = 1 Then
                    BtnMasterTabel.Visible = True
                Else
                    BtnMasterTabel.Visible = False
                End If
            Else
                MultiViewAkses.ActiveViewIndex = -1
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub

    '-------------------------------------------------------------------------
    '|                      Event pada button                                 |
    '--------------------------------------------------------------------------

    'Event ketika menekan tombol tambah data
    Protected Sub BtnMasterTabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMasterTabel.Click
        MultiViewNilaiProgressEntry.ActiveViewIndex = 0
        MultiViewAkses.ActiveViewIndex = -1
        Call ClearPermintaan()
        If lblMintaNo.Text = "" Then
            lblMintaNo.Text = GetData_SearchNomor()
        End If
    End Sub
    Protected Sub BtnNilaiSMSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave.Click
        If lblMintaNo.Text = "" Then
            lblMintaNo.Text = lblMintaNo.Text
            UpdateData_Server(insertData)
        Else
            If GetFindRecord_Server("SELECT * FROM TRXN_PERMINTAAN WHERE MINTA_NO='" & lblMintaNo.Text & "'") <> 1 Then
                If UpdateData_Server(insertData) = 1 Then
                    lblMintaNo.Text = lblMintaNo.Text
                End If
            End If

            Call UpdateData_Server(EDITData)

            LvDetailMaster.DataBind()
            Response.Write("<script>alert('Pengajuan Permintaan Unit anda berhasil dibuat!')</script>")
            Response.Write("<script>window.location.href='WAREHOUSEPERMINTAAN.aspx';</script>")
        End If
    End Sub

    '-------------------------------------------------------------------------
    '|                      Kumpulan Fungsi                                  |
    '--------------------------------------------------------------------------
    Function insertData() As String
        insertData = "INSERT INTO TRXN_PERMINTAAN (MINTA_NO) VALUES ('" & lblMintaNo.Text & "')"
    End Function

    Function EDITData() As String
        '                        "SDRLOG_JENIS='" & DropDownList2.Text& "'," & _
        EDITData = "UPDATE TRXN_PERMINTAAN SET " & _
                                "MINTA_JNSEVENT='" & DropDownList1.Text & "'," & _
                                "MINTA_TGLEVENT='" & txt_TglEvent.Text & "'," & _
                                "MINTA_LOKASI='" & Txt_LokasiEvent.Text & "'," & _
                                "MINTA_PJ='" & Txt_PenanggungJawab.Text & "'," & _
                                "MINTA_TGLTERIMA='" & txt_TglTerimaUnit.Text & "'," & _
                                "MINTA_TGLKEMBALI='" & txt_TglKembali.Text & "'," & _
                                "MINTA_TIPE='" & DropDownList2.Text & "'," & _
                                "MINTA_JENIS='" & txt_JnsMobil.Text & "'," & _
                                "MINTA_WARNA='" & DropDownList3.Text & "'," & _
                                "MINTA_RANGKA='" & txt_NoRangka.Text & "'," & _
                                "MINTA_MESIN='" & txt_NoMesin.Text & "'," & _
                                "MINTA_PEMBUAT='" & LblUserName.Text & "'," & _
                                "MINTA_TGLBUAT='" & Now() & "'" & _
                                "WHERE  MINTA_NO='" & lblMintaNo.Text & "'"
        '"SDRLOG_NO ='" & nSr(MyRecReadA("SDRLOG_NO")) & "'"
    End Function


    Function GetData_AddNomor(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_AddNomor = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                DropDownList1.Text = nSr(MyRecReadA("MINTA_JNSEVENT"))
                txt_TglEvent.Text = nSr(MyRecReadA("MINTA_TGLEVENT"))
                Txt_LokasiEvent.Text = nSr(MyRecReadA("MINTA_LOKASI"))
                Txt_PenanggungJawab.Text = nSr(MyRecReadA("MINTA_PJ"))
                txt_TglKembali.Text = nSr(MyRecReadA("MINTA_TGLKEMBALI"))
                DropDownList2.Text = nSr(MyRecReadA("MINTA_TIPE"))
                txt_JnsMobil.Text = nSr(MyRecReadA("MINTA_JENIS"))
                DropDownList3.Text = nSr(MyRecReadA("MINTA_WARNA"))
                txt_NoRangka.Text = nSr(MyRecReadA("MINTA_RANGKA"))
                txt_NoMesin.Text = nSr(MyRecReadA("MINTA_MESIN"))
                txt_TglTerimaUnit.Text = nSr(MyRecReadA("MINTA_TGLTERIMA"))
                lblMintaNo.Text = nSr(MyRecReadA("MINTA_NO"))
                'lblSDRId.Text = nSr(MyRecReadA("SDRLOG_TARGETR1"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
        End Try
    End Function


    Function GetData_Nomor() As String
        GetData_Nomor = GetData_SearchNomor()
        If GetData_Nomor <> "" Then
            If GetData_Nomor = "NO FOUND" Then
                GetData_Nomor = GetData_StartNomor()
            End If
        End If
        If GetData_Nomor = "" Then
            Call Msg_err("DATA TIDAK BERHASIL DISIMPAN")
        End If
    End Function
    Function GetData_SearchNomor() As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String

        Call Msg_err("")
        GetData_SearchNomor = ""
        Dim mTahun As String = Format(Now(), "yyyy")
        Dim mBulan As String = Format(Now(), "MM")

        'mSqlCommadstring = "SELECT NOMOR FROM TRXN_SPKAH WHERE CABANG='" & lblDealer.Text & "' AND NOT(NOMOR IS NULL OR NOMOR='') AND MONTH(TANGGAL_ENTRY)=MONTH(GETDATE()) AND YEAR(TANGGAL_ENTRY)=YEAR(GETDATE()) ORDER BY NOMOR DESC"
        mSqlCommadstring = "SELECT COUNT(MINTA_TGLBUAT) as maxPemohon from trxn_permintaan where DATEPART(month, MINTA_TGLBUAT) = '" + mBulan + "' AND DATEPART(year, MINTA_TGLBUAT) = '" + mTahun + "'"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            mFind = IIf(MyRecReadA.HasRows = True, 1, 0)
            If mFind = 0 Then
                GetData_SearchNomor = "NO FOUND"
            Else
                MyRecReadA.Read()
                If nSr(MyRecReadA("maxPemohon")) = "" Then
                    GetData_SearchNomor = "NO FOUND"
                Else
                    GetData_SearchNomor = Val(nSr(MyRecReadA("maxPemohon"))) + 1
                    GetData_SearchNomor = mTahun & mBulan & GetData_SearchNomor
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function
    Function GetData_StartNomor() As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String

        Call Msg_err("")
        GetData_StartNomor = ""
        mSqlCommadstring = "SELECT GETDATE() as mCurrDate"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            mFind = IIf(MyRecReadA.HasRows = True, 1, 0)
            If mFind = 0 Then GetData_StartNomor = "NO FOUND"
            While MyRecReadA.Read()
                GetData_StartNomor = lblArea1.Text & _
                                     Format((MyRecReadA("mCurrDate")), "yyMM") & _
                                     "0001"
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function


    Function GetData_Master(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetData_Master = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                DropDownList1.Text = nSr(MyRecReadA("MINTA_JNSEVENT"))
                txt_TglEvent.Text = nSr(MyRecReadA("MINTA_TGLEVENT"))
                Txt_LokasiEvent.Text = nSr(MyRecReadA("MINTA_LOKASI"))
                Txt_PenanggungJawab.Text = nSr(MyRecReadA("MINTA_PJ"))
                txt_TglKembali.Text = nSr(MyRecReadA("MINTA_TGLKEMBALI"))
                DropDownList2.Text = nSr(MyRecReadA("MINTA_TIPE"))
                txt_JnsMobil.Text = nSr(MyRecReadA("MINTA_JENIS"))
                DropDownList3.Text = nSr(MyRecReadA("MINTA_WARNA"))
                txt_NoRangka.Text = nSr(MyRecReadA("MINTA_RANGKA"))
                txt_NoMesin.Text = nSr(MyRecReadA("MINTA_MESIN"))
                txt_TglTerimaUnit.Text = nSr(MyRecReadA("MINTA_TGLTERIMA"))
                lblMintaNo.Text = nSr(MyRecReadA("MINTA_NO"))
            End If
            MyRecReadA.Close()
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
            MsgBox(ex.Message)
        End Try
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



    Sub ClearPermintaan()
        DropDownList1.Text = ""
        txt_TglEvent.Text = ""
        Txt_LokasiEvent.Text = ""
        Txt_PenanggungJawab.Text = ""
        txt_TglKembali.Text = ""
        DropDownList2.Text = ""
        txt_JnsMobil.Text = ""
        DropDownList3.Text = ""
        txt_NoRangka.Text = ""
        txt_NoMesin.Text = ""
        txt_TglTerimaUnit.Text = ""
        lblMintaNo.Text = ""
    End Sub

    '  Protected Sub BtnNilaiSMSave0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNilaiSMSave0.Click
    '  Dim mSqlTxt As String = "UPDATE TRXN_SDR SET SDRLOG_PEMOHONNAMA='" & TxtSDRPemohon.Text & "',SDRLOG_PEMOHONTGL=GETDATE()  WHERE SDRLOG_NO='" & lblSDRId.Text & "'"
    '   If TxtSDRPemohon.Text = "" Then
    '  mSqlTxt = "UPDATE TRXN_SDR SET SDRLOG_PEMOHONNAMA='" & TxtSDRPemohon.Text & "',SDRLOG_PEMOHONTGL=NULL  WHERE SDRLOG_NO='" & lblSDRId.Text & "'"
    'End If

    'End Sub



End Class
