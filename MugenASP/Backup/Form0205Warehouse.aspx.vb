Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Imports System.Web.Security

Imports VB = Microsoft.VisualBasic
Imports System.Drawing.Printing
'Akses 
'1 : only read
'2 : Only save stok
'3 : only Batal stok
'4 : Save  SPJ               ' BtnSmp06 BtnBtl06  btnPrintSPJ-----SPJ
'5 : Batal SPJ
'6 : Batal Kirim             ' BtnSmp08 -------> Batal Kirim
'7 : Simpan Terima           ' BtnSmp09 BtnBtl09 ----> Terima Unit
'8 : Batal Terima
'9 : Print BBM               'BtnSmp11 BtnBtl11  BtnPrintBBM ----------->Voucher Mugen
'10: Batal BBM
'11: Kirim Mugen              BtnSmp13 BtnBtl13 kriim mugen
'12: Batal Kirim Mugen        
'13: Cetak Voucher BBM CRS    BtnSmp15 BtnBtl15 BtnPrintBBMD Voucher kirim muhge
'14: Batal Voucher BBM CRS
'15: Perbaikan
'16: Pasang Aksesoris
'17: Hanya lihat Akses jadwal kirim
'18: Status Rangka
'19: Validasi Stok Setelah diinput

Partial Class Form0205Warehouse
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader
    Public MyRecReadB As OleDbDataReader
    Public MyRecReadC As OleDbDataReader
    Public MyRecReadD As OleDbDataReader
    Public MyRecReadF As OleDbDataReader
    Public mRk1, mRk2, mRk3, mRk4, mRk5, mRk6, mRk7, mRk8, mRk9, mRk0, mRk11 As String
    Dim mSaveButon As Byte
    Dim mErrorMySistem As String
    Dim mTemplate As String
    Dim TextToPrint As String = ""
    Dim jumlahkarakter As Integer = 40

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If
        lblAkses.Visible = False
        mSaveButon = 0
        If LblUserName.Text = "" Then
            Dim x As String
            Dim mFound As Byte = 0
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = UCase(x.ToString)

            If Left(LblUserName.Text, 3) = "112" Or Left(LblUserName.Text, 3) = "128" Then
                mFound = GetDataA_UserSecurity("SELECT *,GETDATE() as mfTgl FROM DATA_SECURITYH,DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(SECURITYH_USER)=RTRIM(USER_NAMA) AND RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & Left(LblUserName.Text, 3) & "' AND SECURITYH_NOIDSALES='" & Right(LblUserName.Text, Len(LblUserName.Text) - 3) & "' AND USER_TIPE='WA' AND AKSES_MENU='0108'")
                If mFound = 1 Then
                    lblArea1.Text = Left(LblUserName.Text, 3)
                    lblArea2.Text = Left(LblUserName.Text, 3)
                End If
            Else
                mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0108'")
            End If
            LblUserName.Text = UCase(LblUserName.Text)

            If mFound = 1 Then
                '    SelectCommand = "SELECT * FROM TRXN_STOCKMKIRIM LEFT OUTER JOIN TRXN_STOCK ON TRXN_STOCKMKIRIM.STOCKM_NORANGKA = TRXN_STOCK.STOCK_NoRangka LEFT OUTER JOIN TRXN_STOCKKKIRIM ON TRXN_STOCK.STOCK_NoRangka = TRXN_STOCKKKIRIM.STOCKK_NORANGKA WHERE (TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM = ?)"
                '    <asp:ControlParameter ControlID="txtDate" Name="STOCKM_TGLMOHONKIRIM" PropertyName="Text" Type="String" />
                MultiView1.ActiveViewIndex = 0
                MultiViewWarehouse.ActiveViewIndex = 0

                Call DefinisTabelBBM()
                Call DefinisTabelAksesoris()
                Call DefinisTabelHistory()
                Call ClearFrom()
                TxtDateGesek.Text = Now()
                LblDateGesekD.Text = Day(CDate(TxtDateGesek.Text))
                LblDateGesekM.Text = Month(CDate(TxtDateGesek.Text))
                LblDateGesekY.Text = Year(CDate(TxtDateGesek.Text))

                '   <asp:ControlParameter ControlID="txtDate" Name="STOCKM_TGLMOHONKIRIM" PropertyName="Text" Type="String" />

                txtTglKirim.Text = Now()
                LblTglKirimDD.Text = Day(CDate(txtTglKirim.Text))
                LblTglKirimMM.Text = Month(CDate(txtTglKirim.Text))
                LblTglKirimYY.Text = Year(CDate(txtTglKirim.Text))
                lvKirimmUnit.DataBind()

                BtnTTKSave.Enabled = False : BtnTTKBatal.Enabled = False
                If Mid(lblAkses.Text, 17, 1) = "1" Then
                    BtnHal1.Visible = True : BtnHal2.Visible = False : BtnHal3.Visible = False : BtnHal4.Visible = False : BtnHal5.Visible = False
                End If

                If Mid(lblAkses.Text, 2, 1) = "1" Or Mid(lblAkses.Text, 15, 1) = "1" Then
                    BtnTTKSave.Enabled = True
                End If
                If Mid(lblAkses.Text, 3, 1) = "1" Then
                    BtnTTKBatal.Enabled = True
                End If

                BtnSmp06.Enabled = False
                If Mid(lblAkses.Text, 4, 1) = "1" Or Mid(lblAkses.Text, 11, 1) = "1" Then
                    BtnSmp06.Enabled = True
                End If
                BtnBtl06.Enabled = False
                If Mid(lblAkses.Text, 5, 1) = "1" Or Mid(lblAkses.Text, 12, 1) = "1" Then
                    BtnBtl06.Enabled = True
                End If

                btnPrintSPJ.Enabled = IIf(Mid(lblAkses.Text, 4, 1) = "1", True, False)

                BtnSmp08.Enabled = IIf(Mid(lblAkses.Text, 6, 1) = "1", True, False)

                BtnSmp09.Enabled = IIf(Mid(lblAkses.Text, 7, 1) = "1", True, False)
                BtnBtl09.Enabled = IIf(Mid(lblAkses.Text, 8, 1) = "1", True, False)

                BtnBBM2Add.Enabled = IIf(Mid(lblAkses.Text, 9, 1) = "1" Or Mid(lblAkses.Text, 13, 1) = "1", True, False)
                BtnBBM5Ctk.Enabled = IIf(Mid(lblAkses.Text, 9, 1) = "1" Or Mid(lblAkses.Text, 13, 1) = "1", True, False)
                BtnBBM3Del.Enabled = IIf(Mid(lblAkses.Text, 10, 1) = "1" Or Mid(lblAkses.Text, 14, 1) = "1", True, False)




                BtnPasangAss.Enabled = IIf(Mid(lblAkses.Text, 16, 1) = "1", True, False)
                BtnBtlPasangAss.Enabled = IIf(Mid(lblAkses.Text, 16, 1) = "1", True, False)

                Call GetSupir_TTK()
                DDListBBMTp.Items.Clear()
                DDListBBMTp.Items.Add("CUSTOMER")
                DDListBBMTp.Items.Add("CROSS-SELL")
                DDListBBMTp.Items.Add("PAMERAN")
                DDListBBMTp.Items.Add("UNIT")
                DDListBBMTp.Items.Add("PERTAMINA")
                DropDownListJnsKirim.Items.Clear()
                DropDownListJnsKirim.Items.Add("CUSTOMER")
                DropDownListJnsKirim.Items.Add("PAMERAN")
                DropDownListJnsKirim.Items.Add("SHOWROOM")
            Else
                Call Msg_err("TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI", 1)
                MultiView1.ActiveViewIndex = -1
                MultiViewWarehouse.ActiveViewIndex = -1
            End If
        End If
    End Sub
    Sub Msg_err(ByVal mTest As String, ByVal mShow As Byte)

        'Response.Write("<script>alert('" & mTest & "')</script>")

        If mTest = "" Then
            MultiViewError.ActiveViewIndex = 0
            lblMsgBox.Text = ""
        Else
            MultiViewError.ActiveViewIndex = 0
        End If
        If mTest <> "" Then
            Response.Write("<script>alert('" & mTest & "')</script>")
        End If
        If mTest <> "" And mShow <> 1 Then
            lblMsgBox.Text = mTest
        End If
    End Sub

    Protected Sub DefinisTabelBBM()
        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn(8) {New DataColumn("Temp_BBMNo"), New DataColumn("Temp_BBMTg"), New DataColumn("Temp_BBMBt"), New DataColumn("Temp_BBMCr"), New DataColumn("Temp_BBMTT"), New DataColumn("Temp_BBMTTg"), New DataColumn("Temp_BBMJm"), New DataColumn("Temp_BBMTp"), New DataColumn("Temp_BBMNt")})
        ViewState("BBM") = dt
        Me.BindGridBBM()
    End Sub
    Protected Sub BindGridBBM()
        LvTabelBBM.DataSource = DirectCast(ViewState("BBM"), DataTable)
        LvTabelBBM.DataBind()
    End Sub
    Sub insertTabelBBM(ByVal Type As Byte, ByVal Temp_BBMNo As String, ByVal Temp_BBMTg As String, ByVal Temp_BBMBt As String, ByVal Temp_BBMCr As String, ByVal Temp_BBMTT As String, ByVal Temp_BBMTTg As String, ByVal Temp_BBMJm As String, ByVal Temp_BBMTp As String, ByVal Temp_BBMNt As String)
        Dim dt As DataTable = DirectCast(ViewState("BBM"), DataTable)
        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_BBMNo, Temp_BBMTg, Temp_BBMBt, Temp_BBMCr, Temp_BBMTT, Temp_BBMTTg, Temp_BBMJm, Temp_BBMTp, Temp_BBMNt)
        End If
        ViewState("BBM") = dt
        Me.BindGridBBM()
    End Sub


    Protected Sub DefinisTabelAksesoris()
        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn(8) {New DataColumn("Temp_Judul"), New DataColumn("Temp_TANGGAL_CREATE"), New DataColumn("Temp_TANGGAL_PROSES"), New DataColumn("Temp_NOMOR_MOHON"), New DataColumn("Temp_URUT"), New DataColumn("Temp_SPL"), New DataColumn("Temp_MYUSER"), New DataColumn("Temp_SPV"), New DataColumn("Temp_APPROVALCODE")})
        ViewState("Aksesoris") = dt
        Me.BindGridAksesoris()
    End Sub
    Protected Sub BindGridAksesoris()
        LvTabelAksesoris.DataSource = DirectCast(ViewState("Aksesoris"), DataTable)
        LvTabelAksesoris.DataBind()
    End Sub
    Sub insertTabelAksesoris(ByVal Type As Byte, ByVal Temp_Nomor As String, ByVal Temp_Judul As String, ByVal Temp_TANGGAL_PROSES As String, ByVal Temp_NOMOR_MOHON As String, ByVal Temp_URUT As String, ByVal Temp_SPL As String, ByVal Temp_MYUSER As String, ByVal Temp_SPV As String, ByVal Temp_APPROVALCODE As String)
        Dim dt As DataTable = DirectCast(ViewState("Aksesoris"), DataTable)

        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_Nomor, Temp_Judul, Temp_TANGGAL_PROSES, Temp_NOMOR_MOHON, Temp_URUT, Temp_SPL, Temp_MYUSER, Temp_SPV, Temp_APPROVALCODE)
        End If
        ViewState("Aksesoris") = dt
        Me.BindGridAksesoris()
    End Sub



    Protected Sub DefinisTabelHistory()
        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn(4) {New DataColumn("Temp_HistRgk"), New DataColumn("Temp_HistTgl"), New DataColumn("Temp_HistUser"), _
                                               New DataColumn("Temp_HistNote"), New DataColumn("Temp_HistSts")})
        ViewState("History") = dt
        Me.BindGridHistory()
    End Sub
    Protected Sub BindGridHistory()
        LvTabelHistoryRangka.DataSource = DirectCast(ViewState("History"), DataTable)
        LvTabelHistoryRangka.DataBind()
    End Sub
    Sub insertTabelHistory(ByVal Type As Byte, ByVal Temp_HistRgk As String, ByVal Temp_HistTgl As String, ByVal Temp_HistUser As String, ByVal Temp_HistNote As String, ByVal Temp_HistSts As String)
        Dim dt As DataTable = DirectCast(ViewState("History"), DataTable)
        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_HistRgk, Temp_HistTgl, Temp_HistUser, Temp_HistNote, Temp_HistSts)
        End If
        ViewState("History") = dt
        Me.BindGridHistory()
    End Sub



    Protected Sub BtnAddpsg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPasangAss.Click
        If LblAksesorpsg.Text <> "" Then
            Msg_err("Sudah terpasang", 1)
        ElseIf TxtIsiTglPasang.Text = "" Then
            Msg_err("Tanggal Pasang Belum diisi terpasang", 1)
        Else
            Call SimpanNOWO("")
        End If
    End Sub
    Protected Sub BtnAddBtlpsg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtlPasangAss.Click
        If LblAksesorpsg.Text = "" Then
            Msg_err("Belum terpasang", 1)
        ElseIf TxtAksesorpsg.Text = "" Then
            Msg_err("Alasan Batal terpasang belum diisi", 1)
        Else
            Call SimpanNOWO(TxtAksesorpsg.Text)
        End If
    End Sub


    Function SimpanNOWO(ByVal mKet As String) As Byte
        SimpanNOWO = 0
        SimpanNOWO = GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCKAKSESORIS WHERE STOCKA_NORANGKA='" & TxtNoRangka.Text & "' AND " & "STOCKA_KDASS='" & LblAksesorKode.Text & "'", "", 1)
        If SimpanNOWO <> 1 Then
            SimpanNOWO = InsertIntoDataAksesoris(LblAksesorDlr.Text)
        End If
        Dim MySTRsql1 As String
        Dim MySTRsql2 As String
        If SimpanNOWO = 1 Then
            If mKet <> "" Then
                MySTRsql1 = "UPDATE TRXN_STOCKAKSESORIS SET " & "STOCKA_TGLPSG=NULL,STOCKA_TGLPSGI=GETDATE(),STOCKA_NOBUKTI='',STOCKA_ALASAN='" & mKet & "' "
                MySTRsql2 = "UPDATE TRXN_OPTH SET OPTH_NOBUKTI='',OPTH_TGLINPUTBUKTI=NULL,OPTH_TGLKERJABUKTI=NULL WHERE OPTH_NOWO='" & LblAksesorWO.Text & "'"
            Else
                MySTRsql1 = "UPDATE TRXN_STOCKAKSESORIS SET " & "STOCKA_TGLPSG=" & nSrSQL(TxtIsiTglPasang.Text) & ",STOCKA_TGLPSGI=GETDATE(),STOCKA_NOBUKTI='PASANG'" & ",STOCKA_ALASAN='' "
                MySTRsql2 = "UPDATE TRXN_OPTH SET OPTH_NOBUKTI='PASANG',OPTH_TGLINPUTBUKTI=GETDATE(),OPTH_TGLKERJABUKTI=" & nSrSQL(TxtIsiTglPasang.Text) & " WHERE OPTH_NOWO='" & LblAksesorWO.Text & "'"
            End If
            MySTRsql1 = MySTRsql1 & " WHERE STOCKA_NORANGKA='" & TxtNoRangka.Text & "' AND " & "STOCKA_KDASS='" & LblAksesorKode.Text & "'"
            If UpdateDatabase_Tabel(MySTRsql1, "", 1) = 1 Then
                Call UpdateDatabase_Tabel(MySTRsql2, LblAksesorDlr.Text, 1)
                If mKet <> "" Then
                    LblAksesorpsg.Text = ""
                Else
                    LblAksesorpsg.Text = TxtIsiTglPasang.Text
                End If

            End If
        End If

    End Function

    Function InsertIntoDataAksesoris(ByVal Mydealer As String) As Byte
        Dim mpServer As String = "MyConnCloudDnet" & Mydealer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                    "SELECT OPT_CdAssesoris,OPT_NOWO,OPT_NOSPK,OPT_NORANGKA,OPT_NoVcrDisc,OPT_UNIT,OPTH_Tglwo,OPTH_TglRcvWO,SUPLIER_Nama,OPTH_KETERANGAN,STANDARD_NAMA " & _
                    "FROM TRXN_OPT,TRXN_OPTH,TRXN_SPK,DATA_SUPLIER,DATA_STANDARD " & _
                    "WHERE OPT_NORANGKA='" & TxtNoRangka.Text & "' AND OPT_CdAssesoris=STANDARD_Kode AND OPTH_CdSuplier=SUPLIER_Kode AND OPT_NOWO=OPTH_NOWO AND OPT_NoRangka=SPK_NoRangka ORDER BY OPT_NOWO" ' AND NOT ISNULL(OPTH_TglSendWO)  AND ISNULL(OPTH_MOHONPASANG) 
        Call Msg_err("", 0)
        InsertIntoDataAksesoris = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                If nSr(MyRecReadA("OPTH_TglSendWO")) = "" Then
                    Call Msg_err("Work Order belum di Email ke suplier", 0)
                Else
                    InsertIntoDataAksesoris = 1
                    mSqlCommadstring = "INSERT INTO TRXN_STOCKAKSESORIS(STOCKA_NORANGKA,STOCKA_NOWO,STOCKA_KDASS,STOCKA_QTY,STOCKA_KDSUPLIER,STOCKA_TGLWO,STOCKA_TGLSUPLIER,STOCKA_TGLPSG,STOCKA_TGLPSGI,STOCKA_BERITA,STOCKA_ALASAN,STOCKA_NAMA) VALUES ('" & _
                                nSr(MyRecReadA("OPT_NORANGKA")) & "','" & _
                                nSr(MyRecReadA("OPT_NOWO")) & "','" & _
                                nSr(MyRecReadA("OPT_CdAssesoris")) & "'," & _
                                nLg(MyRecReadA("OPT_UNIT")) & ",'" & _
                                nSr(MyRecReadA("OPTH_CdSuplier")) & "'," & _
                                DtFrSQL(MyRecReadA("OPTH_Tglwo")) & "," & _
                                DtFrSQL(MyRecReadA("OPTH_TglRcvWO")) & ",NULL,NULL,'" & _
                                TxtPetik(MyRecReadA("OPTH_KETERANGAN")) & "','','" & nSr(MyRecReadA("STANDARD_NAMA")) & "')"
                    Call UpdateDatabase_Tabel(mSqlCommadstring, "", 1)
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function



    Sub TblAksesorisView_SelectedIndexChanging(ByVal sender As Object, ByVal e As ListViewSelectEventArgs)
        Dim item As ListViewItem = CType(LvTabelAksesoris.Items(e.NewSelectedIndex), ListViewItem)
        Dim mKode As Label = CType(item.FindControl("Lbl_Judul"), Label)
        LblAksesorDlr.Text = mKode.Text

        mKode = CType(item.FindControl("Lbl_CREATE"), Label)
        LblAksesorWO.Text = mKode.Text

        mKode = CType(item.FindControl("Lbl_USER"), Label)
        LblAksesorKode.Text = mKode.Text

        mKode = CType(item.FindControl("Lbl_SPV"), Label)
        LblAksesorNama.Text = mKode.Text

        mKode = CType(item.FindControl("Lbl_APRVCODE"), Label)
        LblAksesorNote.Text = mKode.Text

        mKode = CType(item.FindControl("Lbl_URUT"), Label)
        LblAksesorpsg.Text = mKode.Text
        TxtAksesorpsg.Text = ""

        lblIsiTglPasang.Visible = IIf(LblAksesorpsg.Text = "", True, False)
        TxtIsiTglPasang.Visible = IIf(LblAksesorpsg.Text = "", True, False)
        BtnCall16.Visible = IIf(LblAksesorpsg.Text = "", True, False)
        Calendar16.Visible = False


    End Sub

    Protected Sub TblAksesorisView_PagePropertiesChanging(ByVal sender As Object, ByVal e As PagePropertiesChangingEventArgs)
        ' Clears the selection.
        LvTabelAksesoris.SelectedIndex = -1
    End Sub

    Sub TblBBMView_SelectedIndexChanging(ByVal sender As Object, ByVal e As ListViewSelectEventArgs)
        Dim item As ListViewItem = CType(LvTabelBBM.Items(e.NewSelectedIndex), ListViewItem)
        Dim mKode As Label = CType(item.FindControl("Lbl_BBMNo"), Label)
        TxtNoVcrBBM.Text = mKode.Text

        mKode = CType(item.FindControl("Lbl_BBMBt"), Label)
        If mKode.Text <> "" Then
            TxtNoVcrBBM.Text = ""
            Call Msg_err("Sudah dibatalkan", 0)
        Else
            mKode = CType(item.FindControl("Lbl_BBMTg"), Label)
            LblBBMTg.Text = mKode.Text

            mKode = CType(item.FindControl("Lbl_BBMJm"), Label)
            LblBBMJm.Text = mKode.Text

            mKode = CType(item.FindControl("Lbl_BBMTp"), Label)

            DDListBBMTp.Text = mKode.Text

            mKode = CType(item.FindControl("Lbl_BBMNt"), Label)


            TxtBBMCt.Text = mKode.Text
            TxtBBMCt.Visible = True
            DDListBBMTp.Enabled = False
            BtnBBM2Add.Visible = False
        End If

    End Sub

    Protected Sub TblBBMView_PagePropertiesChanging(ByVal sender As Object, ByVal e As PagePropertiesChangingEventArgs)
        ' Clears the selection.
        LvTabelBBM.SelectedIndex = -1
    End Sub


    Sub TblPengirimanView_SelectedIndexChanging(ByVal sender As Object, ByVal e As ListViewSelectEventArgs)
        Dim item As ListViewItem = CType(LvTabelAksesoris.Items(e.NewSelectedIndex), ListViewItem)
        Dim mKode As Label = CType(item.FindControl("Lbl_Judul"), Label)
        LblAksesorDlr.Text = mKode.Text

        mKode = CType(item.FindControl("LblKirim_CREATE"), Label)
        LblAksesorWO.Text = mKode.Text

        mKode = CType(item.FindControl("LblKirim_USER"), Label)
        LblAksesorKode.Text = mKode.Text

        mKode = CType(item.FindControl("LblKirim_SPV"), Label)
        LblAksesorNama.Text = mKode.Text

        mKode = CType(item.FindControl("LblKirim_APRVCODE"), Label)
        LblAksesorNote.Text = mKode.Text

        mKode = CType(item.FindControl("LblKirim_URUT"), Label)
        LblAksesorpsg.Text = mKode.Text
        TxtAksesorpsg.Text = ""

        lblIsiTglPasang.Visible = IIf(LblAksesorpsg.Text = "", True, False)
        TxtIsiTglPasang.Visible = IIf(LblAksesorpsg.Text = "", True, False)
        BtnCall16.Visible = IIf(LblAksesorpsg.Text = "", True, False)
        Calendar16.Visible = False


    End Sub

    Protected Sub TblPengirimanView_PagePropertiesChanging(ByVal sender As Object, ByVal e As PagePropertiesChangingEventArgs)
        ' Clears the selection.
        LvTabelAksesoris.SelectedIndex = -1
    End Sub


    Protected Sub BtnCal1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCal1.Click
        [Calendar1].Visible = IIf([Calendar1].Visible = True, False, True)
    End Sub
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar1].SelectionChanged, Calendar1.SelectionChanged
        txtTglKirim.Text = [Calendar1].SelectedDate.ToString

        If txtTglKirim.Text <> "" Then
            LblTglKirimDD.Text = Day(CDate(txtTglKirim.Text))
            LblTglKirimMM.Text = Month(CDate(txtTglKirim.Text))
            LblTglKirimYY.Text = Year(CDate(txtTglKirim.Text))
        End If
        [Calendar1].Visible = False
    End Sub

    Protected Sub BtnCal2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCal2.Click
        [Calendar2].Visible = IIf([Calendar2].Visible = True, False, True)
    End Sub
    Protected Sub Calendar2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar2].SelectionChanged, Calendar2.SelectionChanged
        TxtDtTglDoIm.Text = [Calendar2].SelectedDate.ToString
        [Calendar2].Visible = False
    End Sub

    Protected Sub BtnCal3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCal3.Click
        [Calendar3].Visible = IIf([Calendar3].Visible = True, False, True)
    End Sub
    Protected Sub Calendar3_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar3].SelectionChanged, Calendar3.SelectionChanged
        TxtDTglDO.Text = [Calendar3].SelectedDate.ToString
        [Calendar3].Visible = False
    End Sub

    Protected Sub BtnCal4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCal4.Click
        [Calendar4].Visible = IIf([Calendar4].Visible = True, False, True)
    End Sub
    Protected Sub Calendar4_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar4].SelectionChanged, Calendar4.SelectionChanged
        TxtDtglSuratJln.Text = [Calendar4].SelectedDate.ToString
        [Calendar4].Visible = False
    End Sub

    Protected Sub BtnCal5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall5.Click
        [Calendar5].Visible = IIf([Calendar5].Visible = True, False, True)
    End Sub
    Protected Sub Calendar5_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar5].SelectionChanged, Calendar5.SelectionChanged
        TxttglKirimSetujui.Text = [Calendar5].SelectedDate.ToString
        [Calendar5].Visible = False
    End Sub

    Protected Sub BtnCal6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall6.Click
        [Calendar6].Visible = IIf([Calendar6].Visible = True, False, True)
    End Sub
    Protected Sub Calendar6_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar6].SelectionChanged, Calendar6.SelectionChanged
        TxttglPDI.Text = [Calendar6].SelectedDate.ToString
        [Calendar6].Visible = False
    End Sub

    Protected Sub BtnCal7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall7.Click
        [Calendar7].Visible = IIf([Calendar7].Visible = True, False, True)
    End Sub
    Protected Sub Calendar7_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar7].SelectionChanged, Calendar7.SelectionChanged
        TxttglKeluar.Text = [Calendar7].SelectedDate.ToString
        [Calendar7].Visible = False
    End Sub

    Protected Sub BtnCal8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGesek.Click
        [Calendar8].Visible = IIf([Calendar8].Visible = True, False, True)
    End Sub
    Protected Sub Calendar8_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar8].SelectionChanged, Calendar8.SelectionChanged
        TxtDateGesek.Text = [Calendar8].SelectedDate.ToString
        If TxtDateGesek.Text <> "" Then
            LblDateGesekD.Text = Day(CDate(TxtDateGesek.Text))
            LblDateGesekM.Text = Month(CDate(TxtDateGesek.Text))
            LblDateGesekY.Text = Year(CDate(TxtDateGesek.Text))
        End If
        [Calendar8].Visible = False
    End Sub

    Protected Sub BtnCal15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCal15.Click
        [Calendar15].Visible = IIf([Calendar15].Visible = True, False, True)
    End Sub
    Protected Sub Calendar15_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar15].SelectionChanged, Calendar15.SelectionChanged
        TxtGesekRangkaActual.Text = [Calendar15].SelectedDate.ToString
        [Calendar15].Visible = False
    End Sub


    Protected Sub BtnCal10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall10.Click
        [Calendar10].Visible = IIf([Calendar10].Visible = True, False, True)
    End Sub
    Protected Sub Calendar10_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar10].SelectionChanged, Calendar10.SelectionChanged
        TxttglTerima.Text = [Calendar10].SelectedDate.ToString
        [Calendar10].Visible = False
    End Sub



    Protected Sub BtnCal12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall12.Click
        [Calendar12].Visible = IIf([Calendar12].Visible = True, False, True)
    End Sub
    Protected Sub Calendar12_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar12].SelectionChanged, Calendar12.SelectionChanged
        TxtTglBukuSvc.Text = [Calendar12].SelectedDate.ToString
        [Calendar12].Visible = False
    End Sub

    Protected Sub BtnCal13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall13.Click
        [Calendar13].Visible = IIf([Calendar13].Visible = True, False, True)
    End Sub
    Protected Sub Calendar13_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar13].SelectionChanged, Calendar13.SelectionChanged
        TxtPDILakbanTgl.Text = [Calendar13].SelectedDate.ToString
        [Calendar13].Visible = False
    End Sub

    Protected Sub BtnCal14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall14.Click
        [Calendar14].Visible = IIf([Calendar14].Visible = True, False, True)
    End Sub

    Protected Sub Calendar14_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar14].SelectionChanged, Calendar14.SelectionChanged
        TxtPDIPoldaTgl.Text = [Calendar14].SelectedDate.ToString
        [Calendar14].Visible = False
    End Sub

    Protected Sub BtnCall16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall16.Click
        [Calendar16].Visible = IIf([Calendar16].Visible = True, False, True)
    End Sub

    Protected Sub Calendar16_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar16].SelectionChanged, Calendar16.SelectionChanged
        TxtIsiTglPasang.Text = [Calendar16].SelectedDate.ToString
        [Calendar16].Visible = False
    End Sub



    Protected Sub lvKirimmUnit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvKirimmUnit.SelectedIndexChanged
        If Mid(lblAkses.Text, 17, 1) = "1" Then

        Else
            Dim mNomorangaka As String = (lvKirimmUnit.DataKeys(lvKirimmUnit.SelectedIndex).Value.ToString)
            Call GETSTOCK_GETTTK("STOCK_Norangka ='" & mNomorangaka & "'")
            MultiViewWarehouse.ActiveViewIndex = 2
            Multi03Stok.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub lvKirimmUnitMOVE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvKirimUnitMove.SelectedIndexChanged
        If Mid(lblAkses.Text, 17, 1) = "1" Then

        Else
            Dim mNomorangaka As String = (LvKirimUnitMove.DataKeys(LvKirimUnitMove.SelectedIndex).Value.ToString)
            Call GETSTOCK_GETTTK("STOCK_Norangka ='" & mNomorangaka & "'")
            MultiViewWarehouse.ActiveViewIndex = 2
            Multi03Stok.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub LvJdwNoSPJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvJdwNoSPJ.SelectedIndexChanged
        If Mid(lblAkses.Text, 17, 1) = "1" Then
        Else
            Dim mNomorangaka As String = (LvJdwNoSPJ.DataKeys(LvJdwNoSPJ.SelectedIndex).Value.ToString)
            Call GETSTOCK_GETTTK("STOCK_Norangka ='" & mNomorangaka & "'")
            MultiViewWarehouse.ActiveViewIndex = 2
            Multi03Stok.ActiveViewIndex = 0
        End If
    End Sub




    Function GETSTOCK_GETTTK(ByVal mSearchTxt As String) As Byte
        GETSTOCK_GETTTK = 0
        Call GETSTOCK_DataStock(mSearchTxt, "")

        If TxtNoRangka.Text <> "" Then
            GETSTOCK_GETTTK = 1
            Call FIND_STOCKDOSUPLIER("STOCKDO_NORANGKA='" & UCase(TxtNoRangka.Text) & "' ", "")
            Call GETPERMOHONAN_DATA_SPK("STOCKM_NORANGKA='" & TxtNoRangka.Text & "'", "")
            If LblUsrAdmin.Text <> "" Then
                Call GETPROSES_DATA_KIRIM("STOCKK_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKK_JENIS='1' AND STOCKK_STATUS=''", "")
                LblKirimJenis.Text = "CUSTOMER"
            End If
            Call GETVOUCHER_DATA_BBM("STOCKV_NORANGKA='" & TxtNoRangka.Text & "'", "")
            'Tidak Usah Call GETVOUCHER_DATA_AKSESORIS("STOCKA_NORANGKA='" & TxtNoRangka.Text & "'", "")
            ButtonCariTTK0.Visible = False
            If GETPERMOHONAN_DATA_ALAMAT_SPK_TUJUAN("STOCKA_NORANGKA='" & TxtNoRangka.Text & "'", "") <> 1 Then
                GETPERMOHONAN_DATA_ALAMAT_SPK("STOCKAKP_NORANGKA='" & TxtNoRangka.Text & "'", "", "")
            End If
            Call GETWO_PERBAIKAN("ASSREPAIR_NORANGKA='" & TxtNoRangka.Text & "'", "")
            Call Get_Data_Warna_dan_type(TxtNoRangka.Text, "")

            Call Get_HistoryDealer_CrossSell(TxtNoRangka.Text, "")

            Call GETSTOCK_STCKRANGKA("STCK_NORANGKA='" & TxtNoRangka.Text & "'", "")
            Multi03Stok.ActiveViewIndex = 0
        End If
        LvUnitKirimPerRangka.DataBind()
    End Function



    Function GETSTOCK_DataStock(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = ""
        mSqlCommadstring = "SELECT *, " & _
                              "(SELECT TYPE_Nama     FROM DATA_TYPE WHERE TYPE_Type = STOCK_CdType) AS NamaType, " & _
                              "(SELECT TYPE_Aktif    FROM DATA_TYPE WHERE TYPE_Type = STOCK_CdType) AS NamaTypeAktif, " & _
                              "(SELECT TYPE_IMORA    FROM DATA_TYPE WHERE TYPE_Type = STOCK_CdType) AS KodeTypeImora, " & _
                              "(SELECT TYPE_CdRangka FROM DATA_TYPE WHERE TYPE_Type = STOCK_CdType) AS NoCdRangka, " & _
                              "(SELECT WARNA_Int     FROM DATA_WARNA WHERE WARNA_Kode = STOCK_CdWarna) AS NamaWarna, " & _
                              "(SELECT WARNA_Aktif   FROM DATA_WARNA WHERE WARNA_Kode = STOCK_CdWarna) AS NamaWarnaAktif, " & _
                              "(SELECT WARNA_KODEHPM FROM DATA_WARNA WHERE WARNA_Kode = STOCK_CdWarna) AS NamaWarnaHPM, " & _
                              "(SELECT SUPLIER_Nama  FROM DATA_SUPLIER WHERE SUPLIER_Kode = STOCK_CdSuplier) AS NamaSuplier, " & _
                              "(SELECT LOKASI_Nama   FROM DATA_LOKASI WHERE LOKASI_Kode = STOCK_CdLokasi) AS NamaLokasi, " & _
                              "(SELECT LOKASI_KODEDLR FROM DATA_LOKASI WHERE LOKASI_Kode = STOCK_CdLokasi) AS Kodedealer, " & _
                              "(SELECT LOKASI_IPServer FROM DATA_LOKASI WHERE LOKASI_Kode = STOCK_CdLokasi) AS NamaServer " & _
                              "FROM TRXN_STOCK LEFT OUTER JOIN TRXN_STOCKKKIRIM ON TRXN_STOCK.STOCK_NoRangka = TRXN_STOCKKKIRIM.STOCKK_NORANGKA " & IIf(Trim(mSearchTxt) <> "", " WHERE " & mSearchTxt, " ") & " ORDER BY STOCK_NoTTK"
        Call Msg_err("", 0)
        GETSTOCK_DataStock = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                GETSTOCK_DataStock = 1
                While MyRecReadA.Read()
                    LblTagLokasi0.Text = ""
                    TxtNoTTK.Text = nSr((MyRecReadA("STOCK_NoTTK")))
                    lblNoTTKTag.Text = TxtNoTTK.Text
                    lblTGLTTK.Text = nSr(MyRecReadA("STOCK_TglTTK"))
                    TxtNoRangka.Text = nSr((MyRecReadA("STOCK_NoRangka")))
                    lblNoRangkaTag.Text = TxtNoRangka.Text
                    TxtNoMesin.Text = nSr((MyRecReadA("STOCK_NoMesin")))
                    TxtCdType.Text = nSr((MyRecReadA("STOCK_CdType")))
                    lblCdTypeTag.Text = TxtCdType.Text
                    NamaType.Text = nSr((MyRecReadA("NamaType")))
                    lblMugenImoraType.Text = nSr((MyRecReadA("KodeTypeImora")))
                    TxtCdWarna.Text = nSr((MyRecReadA("STOCK_CdWarna")))
                    lblCdWarnaTag.Text = TxtCdWarna.Text

                    NamaWarna.Text = nSr((MyRecReadA("NamaWarna")))
                    KodeWarnaImoraMugen.Text = nSr((MyRecReadA("NamaWarnaHPM")))
                    TxtTahun.Text = nSr((MyRecReadA("STOCK_Tahun")))
                    TxtNoKunci.Text = nSr((MyRecReadA("STOCK_NoKunci")))
                    TxtKeterangan.Text = nSr((MyRecReadA("STOCK_Keterangan")))
                    TxtCdSuplier.Text = nSr((MyRecReadA("STOCK_CdSuplier")))
                    lblCdSuplierTag.Text = TxtCdSuplier.Text
                    nmSuplier.Text = nSr((MyRecReadA("NamaSuplier")))
                    TxtDtTglDoIm.Text = ""
                    If nSr(MyRecReadA("STOCK_TglDOImoraHpm")) <> "" Then
                        TxtDtTglDoIm.Text = nSr(MyRecReadA("STOCK_TglDOImoraHpm"))
                    End If

                    LblPeriksaUser.Text = nSr(MyRecReadA("STOCK_ValidUser")) : LblPeriksaTgl.Text = nSr(MyRecReadA("STOCK_ValidTgl"))

                    TxtDTglDO.Text = nSr(MyRecReadA("STOCK_TglAuto"))
                    TxtNoDO.Text = nSr(MyRecReadA("STOCK_DoAuto"))
                    TxtDtglSuratJln.Text = nSr(MyRecReadA("STOCK_TglSJ"))
                    TxtcdLokasi.Text = nSr((MyRecReadA("STOCK_CdLokasi")))
                    LblTagLokasi.Text = TxtcdLokasi.Text
                    lblcdLokasiTag.Text = TxtcdLokasi.Text
                    NamaLokasi.Text = nSr((MyRecReadA("NamaLokasi")))
                    Kodedealer.Text = nSr((MyRecReadA("Kodedealer")))
                    KodedealerTag.Text = Kodedealer.Text
                    LblStatus.Text = "STATUS:" & nSr((MyRecReadA("STOCK_StsUpdate"))) & " / " & _
                                              "TANGGAL:" & nSr((MyRecReadA("STOCK_TglUpdate"))) & " / " & _
                                              "BERITA:" & nSr((MyRecReadA("STOCK_BERITA")))

                    TxttglKeluar.Text = nSr((MyRecReadA("STOCK_KIRIMMUGENTGL")))
                    LblAksesorDlr.Text = nSr((MyRecReadA("STOCK_KIRIMMUGENKODE")))

                    TxtTglBukuSvc.Text = nSr((MyRecReadA("STOCK_BUKUSERVICE")))
                    TxtBukuSvc.Text = ""
                    TxtPDISPK.Text = nSr((MyRecReadA("STOCK_NOSPK")))

                    CheckBoxBlokSales.Checked = IIf(nSr(MyRecReadA("STOCK_BlockPickup")) = "1" And nSr(MyRecReadA("STOCK_StsUpdate")) <> "P", True, False)
                    LblTagChekBlokSales1.Text = IIf(nSr(MyRecReadA("STOCK_BlockPickup")) = "1" And nSr(MyRecReadA("STOCK_StsUpdate")) <> "P", "1", "")

                    CheckBoxBlokUnit.Checked = IIf(nSr(MyRecReadA("STOCK_BlockPickup")) = "1" And nSr(MyRecReadA("STOCK_StsUpdate")) = "P", True, False)
                    LblTagChekBlokUnit1.Text = IIf(nSr(MyRecReadA("STOCK_BlockPickup")) = "1" And nSr(MyRecReadA("STOCK_StsUpdate")) = "P", "1", "")

                    'LblStatus.Text = nSr((MyRecReadA("STOCK_Alasan")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function FIND_STOCKDOSUPLIER(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = ""
        mSqlCommadstring = "SELECT *, " & _
                           "(SELECT STOCK_NOTTK FROM TRXN_STOCK WHERE STOCK_NoRangka = STOCKDO_NORANGKA) AS NoTTK " & _
                          "FROM TRXN_STOCKDO " & IIf(Trim(mSearchTxt) <> "", " WHERE " & mSearchTxt, " ") & " ORDER BY STOCKDO_NORANGKA"
        Call Msg_err("", 0)
        FIND_STOCKDOSUPLIER = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    NamaWarnaImora.Text = nSr((MyRecReadA("STOCKDO_WARNADOSPLDESC")))
                    NamaTypeImora.Text = nSr((MyRecReadA("STOCKDO_TYPEDOSPL")))
                    KodeTypeImora.Text = nSr((MyRecReadA("STOCKDO_TYPEDOSPLCODE")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function GETPERMOHONAN_DATA_SPK(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = ""
        mSearchTxt = IIf(mSearchTxt = "", "", " AND ") & mSearchTxt
        mSqlCommadstring = "SELECT *," & _
                                    "(SELECT DRIVER_NAMA FROM DATA_DRIVER,TRXN_STOCKKKIRIM WHERE DRIVER_KODE=STOCKK_DRIVER AND STOCKK_NORANGKA=STOCKM_NORANGKA AND STOCKK_JENIS='1') AS NamaDRIVE," & _
                                    "(SELECT STOCKK_DRIVER FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA AND STOCKK_JENIS='1') AS KodeDRIVE," & _
                                    "(SELECT STOCKK_KIRIMTGLKIRIM FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA AND STOCKK_JENIS='1') AS TanggalSPJ," & _
                                    "(SELECT STOCKK_KIRIMTGLTERIMA FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA AND STOCKK_JENIS='1') AS TanggalTerima," & _
                                    "(SELECT STOCKK_KIRIMKETTERIMA FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA AND STOCKK_JENIS='1') AS KeteranganTerima " & _
                                     "FROM TRXN_STOCKMKIRIM,TRXN_STOCK WHERE STOCKM_NORANGKA=STOCK_NORANGKA " & mSearchTxt & " ORDER BY STOCKM_NORANGKA"
        Call Msg_err("", 0)
        GETPERMOHONAN_DATA_SPK = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    LblCdBranch.Text = nSr((MyRecReadA("STOCKM_KDDEALER")))
                    lblnospkDO.Text = nSr((MyRecReadA("STOCK_NOSPK"))) & "/" & nSr((MyRecReadA("STOCK_DoDealer")))
                    LblSalesman.Text = nSr(MyRecReadA("STOCKM_SALES"))
                    lbllease.Text = nSr((MyRecReadA("STOCKM_LEASE")))

                    TxtBerita.Text = nSr((MyRecReadA("STOCKM_BERITA")))
                    lblTglAdmin.Text = nSr((MyRecReadA("STOCKM_TGLMOHONKIRIM")))
                    LblUsrAdmin.Text = nSr((MyRecReadA("STOCKM_USER")))
                    TxttglKirimSetujui.Text = nSr((MyRecReadA("STOCKM_KIRIMTGLSETUJUI")))
                    LblCetakDOTgl.Text = nSr((MyRecReadA("STOCKM_APPTGLDO")))
                    LblCetakDOUsr.Text = nSr((MyRecReadA("STOCKM_APPUSRDO")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function GETPROSES_DATA_KIRIM(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = ""
        mSearchTxt = IIf(mSearchTxt = "", "", " AND ") & mSearchTxt
        mSqlCommadstring = "SELECT *," & _
                           "(SELECT DRIVER_NAMA FROM DATA_DRIVER WHERE DRIVER_KODE=STOCKK_DRIVER) AS NamaDRIVE " & _
                           "FROM TRXN_STOCKKKIRIM,TRXN_STOCKMKIRIM,TRXN_STOCK WHERE STOCKK_NORANGKA=STOCKM_NORANGKA AND STOCKK_NORANGKA=STOCK_NORANGKA " & mSearchTxt & " ORDER BY STOCKK_NORANGKA"
        mSqlCommadstring = "SELECT *," & _
                           "(SELECT DRIVER_NAMA FROM DATA_DRIVER WHERE DRIVER_KODE=STOCKK_DRIVER) AS NamaDRIVE  " & _
                           "FROM TRXN_STOCKKKIRIM,TRXN_STOCK WHERE STOCKK_NORANGKA=STOCK_NORANGKA " & mSearchTxt & " ORDER BY STOCKK_NORANGKA"

        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        GETPROSES_DATA_KIRIM = 0
        LblKirimInputDanKirim.Text = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    DropDownList2.Text = nSr((MyRecReadA("STOCKK_DRIVER")))
                    'For mLoop As Byte = 1 To DropDownList2.Items.Count - 1
                    'If nSr(DropDownList2.Items.Item(mLoop).Text) = nSr((MyRecReadA("STOCKK_DRIVER"))) Then
                    'DropDownList2.SelectedIndex = mLoop
                    'End If
                    'Next
                    lblNmSupir.Text = nSr((MyRecReadA("NamaDRIVE")))
                    If TxttglKirimSetujui.Text = "" Then
                        TxttglKirimSetujui.Text = lblTglAdmin.Text
                    End If
                    If nSr((MyRecReadA("STOCKK_KIRIMTGLPDI"))) <> "" Then
                        TxttglPDI.Text = ((MyRecReadA("STOCKK_KIRIMTGLPDI")))
                        TxttglPDINote.Text = ""
                    End If

                    LblKirimNo.Text = nSr((MyRecReadA("STOCKK_NOKIRIM")))
                    LblKirimInputDanKirim.Text = "    KIRIM/INPUT : " & ((MyRecReadA("STOCKK_KIRIMTGLKIRIM"))) & "  [ " & ((MyRecReadA("STOCKK_KIRIMTGLKIRIMI"))) & " ]"

                    If nSr((MyRecReadA("STOCKK_JENIS"))) = "1" Then
                        LblKirimJenis.Text = "CUSTOMER"
                    ElseIf nSr((MyRecReadA("STOCKK_JENIS"))) = "2" Then
                        LblKirimJenis.Text = "PAMERAN"
                    ElseIf nSr((MyRecReadA("STOCKK_JENIS"))) = "3" Then
                        LblKirimJenis.Text = "SHOWROOM"
                    End If
                    TxtKirimOngkos.Text = nSr((MyRecReadA("STOCKK_BIAYA")))
                    TxtKirimDealer.Text = nSr((MyRecReadA("STOCKK_TOMUGEN")))

                    If nSr((MyRecReadA("STOCKK_KIRIMTGLKIRIM"))) <> "" Then
                        TxttglKeluar.Text = ((MyRecReadA("STOCKK_KIRIMTGLKIRIM")))
                        TxttglKeluarNote.Text = ""
                    End If
                    If nSr((MyRecReadA("STOCKK_KIRIMTGLSECURITY"))) <> "" Then
                        TxtTglSecurity.Text = ((MyRecReadA("STOCKK_KIRIMTGLSECURITY")))
                        TxtTglSecurityNote.Text = nSr((MyRecReadA("STOCKK_KIRIMKETSECURITY")))
                    End If


                    If nSr((MyRecReadA("STOCKK_KIRIMTGLTERIMA"))) <> "" Then
                        TxttglTerima.Text = ((MyRecReadA("STOCKK_KIRIMTGLTERIMA")))
                        TxttglTerimaNote.Text = ((MyRecReadA("STOCKK_KIRIMKETTERIMA")))
                        lbltglterimai.Text = ((MyRecReadA("STOCKK_KIRIMTGLTERIMAI")))
                    End If
                    If nSr((MyRecReadA("STOCKK_DRIVERNM"))) <> "" Then
                        TxttglKeluarNote.Text = nSr((MyRecReadA("STOCKK_DRIVERNM")))
                    End If
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
            TxttglCatatan.Text = ""
            TxttglCatatanDsc.Text = GetDataD_IsiField("SELECT STOCKH_HISTORY as IsiField FROM TRXN_STOCKHISTORY WHERE STOCKH_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKH_STATUS='C0'", "", 0)
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function GETVOUCHER_DATA_BBM(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_STOCKVKIRIM " & IIf(Trim(mSearchTxt) <> "", " WHERE " & mSearchTxt, " ")
        Dim mTipe As String
        Call Msg_err("", 0)
        Call insertTabelBBM(0, "", "", "", "", "", "", "", "", "")

        'GetData_IsiField = "UnReg"
        GETVOUCHER_DATA_BBM = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    If nSr((MyRecReadA("STOCKV_NOBBM"))) <> "" Then
                        mTipe = "CUSTOMER"
                        If nSr((MyRecReadA("STOCKV_CRSELL"))) = "0" Then
                            mTipe = "CUSTOMER"
                        ElseIf nSr((MyRecReadA("STOCKV_CRSELL"))) = "1" Or nSr((MyRecReadA("STOCKV_CRSELL"))) = "S" Then
                            mTipe = "CROSS-SELL"
                        ElseIf nSr((MyRecReadA("STOCKV_CRSELL"))) = "2" Then
                            mTipe = "PAMERAN"
                        ElseIf nSr((MyRecReadA("STOCKV_CRSELL"))) = "3" Then
                            mTipe = "UNIT"
                        ElseIf nSr((MyRecReadA("STOCKV_CRSELL"))) = "4" Then
                            mTipe = "PERTAMINA"
                        End If
                        Call insertTabelBBM(1, nSr((MyRecReadA("STOCKV_NOBBM"))), nSr((MyRecReadA("STOCKV_CETAK"))), nSr((MyRecReadA("STOCKV_TGLBATAL"))), nSr((MyRecReadA("STOCKV_CREATE"))), nSr((MyRecReadA("STOCKV_TTT"))), nSr((MyRecReadA("STOCKV_TTTTgl"))), nSr((MyRecReadA("STOCKV_NILAI"))), mTipe, nSr((MyRecReadA("STOCKV_Note"))))

                        'If nSr((MyRecReadA("STOCKV_CRSELL"))) <> "S" Then
                        'LblBBMVcr.Text = nSr((MyRecReadA("STOCKV_NOBBM")))
                        'LblBBMNilai.Text = nSr((MyRecReadA("STOCKV_NILI")))
                        'Else
                        'LblBBMCSVcr.Text = nSr((MyRecReadA("STOCKV_NOBBM")))
                        'LblBBMCSNil.Text = nSr((MyRecReadA("STOCKV_NILAI")))
                        ' End If
                    End If
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function GETVOUCHER_DATA_AKSESORIS(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = ""
        mSearchTxt = IIf(mSearchTxt = "", "", " AND ") & mSearchTxt
        mSqlCommadstring = "SELECT *," & _
                                    "(SELECT STANDARD_NAMA FROM DATA_STANDARD WHERE STANDARD_KODE=STOCKA_KDASS) AS NamaAksesoris, " & _
                                    "(SELECT SUPLIER_NAMA FROM DATA_SUPLIER WHERE SUPLIER_KODE=STOCKA_KDSUPLIER) AS NamaSuplier  " & _
                                    " FROM TRXN_STOCKAKSESORIS,TRXN_STOCK WHERE STOCKA_NORANGKA=STOCK_NORANGKA " & mSearchTxt & " "
        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        GETVOUCHER_DATA_AKSESORIS = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    'Call InsertTabelAksesoris()
                    'TabelASS.Items.Item(MyNoBrs).Text = nSr((MyRecReadA("STOCKA_KDASS")))
                    'TabelASS.Items.Item(MyNoBrs).SubItems(1).Text = IIf(nSr(MyRecReadA("NamaAksesoris")) <> "", nSr(MyRecReadA("NamaAksesoris")), "AKSESORIS TDK TERDAFTAR")
                    'TabelASS.Items.Item(MyNoBrs).SubItems(2).Text = nSr((MyRecReadA("STOCKA_QTY")))
                    'TabelASS.Items.Item(MyNoBrs).SubItems(3).Text = nSr((MyRecReadA("STOCKA_NOWO")))
                    'TabelASS.Items.Item(MyNoBrs).SubItems(4).Text = nSrNl((MyRecReadA("STOCKA_TGLWO")), "")
                    'TabelASS.Items.Item(MyNoBrs).SubItems(5).Text = nSrNl((MyRecReadA("STOCKA_TGLSUPLIER")), "")
                    'TabelASS.Items.Item(MyNoBrs).SubItems(6).Text = nSrNl((MyRecReadA("STOCKA_TGLPSG")), "")
                    'TabelASS.Items.Item(MyNoBrs).SubItems(7).Text = nSr((MyRecReadA("STOCKA_BERITA")))
                    'TabelASS.Items.Item(MyNoBrs).SubItems(8).Text = nSr((MyRecReadA("STOCKA_NAMA")))
                    'TabelASS.Items.Item(MyNoBrs).SubItems(9).Text = IIf(nSr(MyRecReadA("NamaSuplier")) <> "", nSr(MyRecReadA("NamaSuplier")), "SUPLIER TDK TERDAFTAR")
                    'TabelASS.Items.Item(MyNoBrs).SubItems(10).Text = nSrNl((MyRecReadA("STOCKA_TGLPSGI")), "")
                    'TabelASS.Items.Item(MyNoBrs).SubItems(11).Text = nSr((MyRecReadA("STOCKA_ALASAN")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function GETPERMOHONAN_DATA_ALAMAT_SPK_TUJUAN(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = ""
        mSearchTxt = IIf(mSearchTxt = "", "", " WHERE ") & mSearchTxt
        mSqlCommadstring = "SELECT *  FROM TRXN_STOCKAKIRIM " & mSearchTxt & " "
        TxtNama.Text = ""
        TxtAlamat.Text = ""
        TxtKota.Text = ""
        TxtNoHP.Text = ""
        TxtPhone.Text = ""

        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        ButtonCariTTK0.Visible = False
        GETPERMOHONAN_DATA_ALAMAT_SPK_TUJUAN = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                If MyRecReadA.Read Then
                    GETPERMOHONAN_DATA_ALAMAT_SPK_TUJUAN = 1
                    Label249.Text = "ALAMAT KIRIM"
                    TxtNama.Text = nSr((MyRecReadA("STOCKA_NAMA")))
                    TxtAlamat.Text = nSr((MyRecReadA("STOCKA_ALAMAT")))
                    TxtKota.Text = nSr((MyRecReadA("STOCKA_KOTA")))
                    TxtNoHP.Text = nSr((MyRecReadA("STOCKA_PH")))
                    TxtPhone.Text = nSr((MyRecReadA("STOCKA_HP")))
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function GETPERMOHONAN_DATA_ALAMAT_SPK(ByVal mSearchTxt As String, ByVal mpSts As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = ""
        mSearchTxt = IIf(mSearchTxt = "", "", " WHERE ") & mSearchTxt
        mSqlCommadstring = "SELECT *  FROM TRXN_STOCKAKIRIMP " & mSearchTxt & " "
        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        GETPERMOHONAN_DATA_ALAMAT_SPK = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()


                    If mpSts = "" Then mpSts = nSr((MyRecReadA("STOCKAKP_STATUS")))
                    If mpSts = "S" Then
                        Label249.Text = "ALAMAT KIRIM"
                        TxtNama.Text = nSr((MyRecReadA("STOCKAKP_SNAMA")))
                        TxtAlamat.Text = nSr((MyRecReadA("STOCKAKP_SALAMAT")))
                        TxtKota.Text = nSr((MyRecReadA("STOCKAKP_SKOTA")))
                        TxtNoHP.Text = nSr((MyRecReadA("STOCKAKP_SPH")))
                        TxtPhone.Text = nSr((MyRecReadA("STOCKAKP_SHP")))
                    Else
                        Label249.Text = "ALAMAT KIRIM"
                        TxtNama.Text = nSr((MyRecReadA("STOCKAKP_PNAMA")))
                        TxtAlamat.Text = nSr((MyRecReadA("STOCKAKP_PALAMAT")))
                        TxtKota.Text = nSr((MyRecReadA("STOCKAKP_PKOTA")))
                        TxtNoHP.Text = nSr((MyRecReadA("STOCKAKP_PPH")))
                        TxtPhone.Text = nSr((MyRecReadA("STOCKAKP_PHP")))
                    End If


                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function


    Function GETPERMOHONAN_DATA_ALAMAT_ACTUAL_BASED_SPK(ByVal mNoRANGKA As String, ByVal mSTK As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = ""

        If mSTK = "SPK" Then
            mSqlCommadstring = "SELECT * FROM TRXN_SPK WHERE SPK_NORANGKA='" & mNoRANGKA & "'"
        Else
            mSqlCommadstring = "SELECT *  FROM TRXN_SURAT,TRXN_SPK WHERE SURAT_SPK=SPK_NO AND SPK_NORANGKA='" & mNoRANGKA & "'"
        End If
        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        GETPERMOHONAN_DATA_ALAMAT_ACTUAL_BASED_SPK = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    ButtonCariTTK0.Visible = True
                    If mSTK = "SPK" Then
                        Label249.Text = "ALAMAT SPK"
                        TxtNama.Text = nSr((MyRecReadA("SPK_NAMA1")))
                        TxtAlamat.Text = nSr((MyRecReadA("SPK_ALAMAT")))
                        TxtKota.Text = nSr((MyRecReadA("SPK_Kota")))
                        TxtNoHP.Text = nSr((MyRecReadA("SPK_FHP")))
                        TxtPhone.Text = nSr((MyRecReadA("SPK_Phone")))
                    Else
                        Label249.Text = "ALAMAT STNK"
                        TxtNama.Text = nSr((MyRecReadA("SPK_NAMA2")))
                        TxtAlamat.Text = nSr((MyRecReadA("SURAT_ALAMAT1"))) & nSr((MyRecReadA("SURAT_ALAMAT2")))
                        TxtKota.Text = nSr((MyRecReadA("SURAT_KOTA")))
                        TxtNoHP.Text = nSr((MyRecReadA("SURAT_NOHP")))
                        TxtPhone.Text = nSr((MyRecReadA("SPK_FHP")))
                    End If
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function


    Function GETWO_PERBAIKAN(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_STOCKAREPAIR WHERE " & mSearchTxt & " AND ASSREPAIR_TGLEMAIL IS NULL"

        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        GETWO_PERBAIKAN = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    'If nSr((MyRecReadA("ASSREPAIR_KDASS"))) = "9007" Then
                    'RadioButton1.Checked = True
                    'ElseIf nSr((MyRecReadA("ASSREPAIR_KDASS"))) = "9008" Then
                    'RadioButton2.Checked = True
                    'ElseIf nSr((MyRecReadA("ASSREPAIR_KDASS"))) = "9009" Then
                    'RadioButton3.Checked = True
                    'End If
                    'If nSr((MyRecReadA("ASSREPAIR_KODEDLR"))) = "U902" Then
                    'ComboBox1.SelectedIndex = 0
                    'Else
                    'ComboBox1.SelectedIndex = 1
                    'End If

                    'TxtKetWO.Text = nSr((MyRecReadA("ASSREPAIR_KETERANGAN")))
                    'TxtRepairRemark.Text = nSr((MyRecReadA("ASSREPAIR_RINCIAN")))
                    'lblTglMohonRepair.Text = nSr((MyRecReadA("ASSREPAIR_TGLINPUT")))
                    'TxtHarga.Text = fLg((MyRecReadA("ASSREPAIR_HARGA")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function
    Function Get_Data_Warna_dan_type(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_STOCKDO WHERE STOCKDO_NORANGKA='" & mSearchTxt & "'"
        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        Get_Data_Warna_dan_type = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                Get_Data_Warna_dan_type = 1
                While MyRecReadA.Read()
                    KodeTypeImora.Text = nSr((MyRecReadA("STOCKDO_TYPEDOSPLCODE")))
                    NamaTypeImora.Text = nSr((MyRecReadA("STOCKDO_TYPEDOSPL")))
                    KodeWarnaImora.Text = nSr((MyRecReadA("STOCKDO_WARNADOSPL")))
                    KodeWarnaImoraTag.Text = GetDataD_IsiField("SELECT WARNA_Int as IsiField FROM DATA_WARNA WHERE WARNA_KODEHPM='" & KodeWarnaImora.Text & "'", "", 0)
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
            Get_Data_Warna_dan_type_Next(mSearchTxt, "")
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function Get_Data_Warna_dan_type_Next(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_STOCKPDI WHERE PDI_NORANGKA='" & mSearchTxt & "'"


        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        Get_Data_Warna_dan_type_Next = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                Get_Data_Warna_dan_type_Next = 1
                While MyRecReadA.Read()
                    TxtPDITransmisiNote.Text = nSr((MyRecReadA("PDI_TRANSMISI")))
                    TxtPDISupirNot.Text = nSr((MyRecReadA("PDI_DRIVER")))
                    TxtPDIPlatMJSNot.Text = nSr((MyRecReadA("PDI_PLATMJS")))
                    TxtPDIKetera.Text = nSr((MyRecReadA("PDI_KETERANGAN")))
                    TxtPDILakbanTgl.Text = nSr((MyRecReadA("pdi_tglgeseklakban")))
                    TxtPDIPoldaTgl.Text = nSr((MyRecReadA("pdi_tglgesekpolda")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function Get_HistoryDealer_CrossSell(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_STOCKHISTORY WHERE STOCKH_NORANGKA='" & mSearchTxt & "' AND STOCKH_STATUS='CM'"
        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        Get_HistoryDealer_CrossSell = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                Get_HistoryDealer_CrossSell = 1
                While MyRecReadA.Read()
                    LblCrsSellMugen.Text = nSr(MyRecReadA("STOCKH_HISTORY")) & _
                                              ", TGL " & nSr(MyRecReadA("STOCKH_TANGGAL"))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function
    Function GETSTOCK_STCKRANGKA(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_STOCKSTCK " & IIf(Trim(mSearchTxt) <> "", " WHERE " & mSearchTxt, " ")
        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        GETSTOCK_STCKRANGKA = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    TxtNoSTCK.Text = nSr((MyRecReadA("STCK_NO")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function UpdateSTOKBBM(ByRef mAdd_Atau_Batal As String, ByRef mNoVcr As String, ByRef mTipe As String) As Byte
        Dim mNoBBM As String
        Dim mJumlah As Double
        Dim mFindNoVcr As Byte
        Dim MySTRsql1 As String
        Dim mTipeVcr As String = ""
        Dim mBBMNilaiode As String = ""
        mTipeVcr = "0"
        If mTipe = "CUSTOMER" Then
            mTipeVcr = "0"
        ElseIf mTipe = "CROSS-SELL" Then
            mTipeVcr = "1" : mBBMNilaiode = "S"
        ElseIf mTipe = "PAMERAN" Then
            mTipeVcr = "2"
        ElseIf mTipe = "UNIT" Then
            mTipeVcr = "3"
        ElseIf mTipe = "PERTAMINA" Then
            mTipeVcr = "4"
        End If
        UpdateSTOKBBM = 0 : MySTRsql1 = ""

        If mAdd_Atau_Batal = 0 Then 'Batal Voucher
            mFindNoVcr = 1

            If mNoVcr = "" Then
                MySTRsql1 = MySTRsql1 & "ALASAN DIBATALKAN BELUM DIISI"
            ElseIf TxtBBMABt.Text = "" Then
                UpdateSTOKBBM = 0 : MySTRsql1 = MySTRsql1 & "ALASAN DIBATALKAN BELUM DIISI"
            ElseIf GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCKVKIRIM WHERE STOCKV_NOBBM='" & mNoVcr & "' AND STOCKV_TGLBATAL IS NULL AND (STOCKV_ST ='B')", "", 0) = 1 Then
                UpdateSTOKBBM = 0 : MySTRsql1 = MySTRsql1 & "NOMOR BBM INI SUDAH PERNAH DIBAYARKAN BBM-NYA (KLAIM LEBIH DARI DUA KALI ALASAN DIBATALKAN DI KOTAK YANG SUDAH DISEDIAKAN"
            ElseIf GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCKVKIRIM WHERE STOCKV_NOBBM='" & mNoVcr & "' AND STOCKV_TTTTgl IS NOT NULL", "", 0) = 1 Then
                UpdateSTOKBBM = 0 : MySTRsql1 = MySTRsql1 & "NOMOR BBM INI SUDAH PERNAH DIBAYARKAN BBM-NYA (KLAIM LEBIH DARI DUA KALI ALASAN DIBATALKAN DI KOTAK YANG SUDAH DISEDIAKAN"
            End If
            If MySTRsql1 <> "" Then
                mFindNoVcr = 0
                Msg_err(MySTRsql1, 1)
            End If

            If mFindNoVcr = 1 Then
                If mNoVcr = "" Then
                    MySTRsql1 = "UPDATE TRXN_STOCKVKIRIM SET STOCKV_TGLBATAL=GETDATE() WHERE STOCKV_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKV_CRSELL='0'"
                Else
                    MySTRsql1 = "UPDATE TRXN_STOCKVKIRIM SET STOCKV_TGLBATAL=GETDATE() WHERE STOCKV_NOBBM='" & mNoVcr & "'"
                End If
                If UpdateDatabase_Tabel(MySTRsql1, "", 0) <> 1 Then
                    Msg_err("UPDATE VOUCHER BBM ERROR", 1)
                Else
                    Call UpdateDatabase_Tabel("INSERT INTO TRXN_STOCKHISTORY (STOCKH_NORANGKA,STOCKH_TANGGAL,STOCKH_STATUS,STOCKH_HISTORY,STOCKH_USER)  VALUES (" & _
                                    "'" & TxtNoRangka.Text & "',GETDATE(),'VB','" & TxtBBMABt.Text & "','" & LblUserName.Text & "')", "", 1)
                End If
            Else
                Msg_err(MySTRsql1, 1)
            End If

        ElseIf mTipe <> "PERTAMINA" And mAdd_Atau_Batal <> 0 And TxtNoVcrBBM.Text <> "" Then
            Msg_err("No Voucher BBM harus kosong ", 1)
        ElseIf mTipe = "PERTAMINA" And mAdd_Atau_Batal <> 0 And TxtNoVcrBBM.Text = "" Then
            Msg_err("No Voucher BBM harus harus diisi", 1)
        ElseIf mAdd_Atau_Batal <> 0 Then 'Buat Baru Voucher
            mJumlah = 0 : mNoBBM = "" : mFindNoVcr = 0
            If mTipe <> "PERTAMINA" Then
                mNoBBM = GetDataD_IsiField("SELECT STOCKV_NOBBM as IsiField FROM TRXN_STOCKVKIRIM WHERE STOCKV_TGLBATAL IS NULL AND STOCKV_CRSELL='" & mTipeVcr & "' AND STOCKV_NORANGKA = '" & TxtNoRangka.Text & "'", "", 0)
            Else
                mNoBBM = TxtNoVcrBBM.Text
            End If
            If mNoBBM <> "" Then
                mFindNoVcr = 1
                If mTipe = "PERTAMINA" Then
                    mFindNoVcr = GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCKVKIRIM WHERE STOCKV_TGLBATAL IS NULL AND STOCKV_NOBBM='" & TxtNoVcrBBM.Text & "'", "", 0)
                    mJumlah = "25000"
                End If
            Else
                mNoBBM = GetDataD_IsiField("SELECT TYPE_CdGroup as IsiField FROM DATA_TYPE,TRXN_STOCK WHERE STOCK_CdType=TYPE_Type AND STOCK_NORANGKA='" & Trim(TxtNoRangka.Text) & "'", "", 0)
                mNoBBM = mNoBBM & GetDataD_IsiField("SELECT TYPE_CC as IsiField FROM DATA_TYPE,TRXN_STOCK WHERE STOCK_CdType=TYPE_Type AND STOCK_NORANGKA='" & Trim(TxtNoRangka.Text) & "'", "", 0)
                mJumlah = nLg(GetDataD_IsiField("SELECT PARAMETER_NILAI as IsiField FROM DATA_PARAMETER WHERE PARAMETER_NAMA='VBBM" & mBBMNilaiode & mNoBBM & "'", "", 0))
                If mTipeVcr = "1" Or mTipeVcr = "2" Or mTipeVcr = "3" Then
                    mJumlah = 50000
                End If
                If mJumlah > 0 Then
                    Dim mNovcrNew As String
                    mNovcrNew = GetDataD_IsiField("SELECT MAX(STOCKV_NOBBM) as IsiField FROM TRXN_STOCKVKIRIM WHERE SUBSTRING(STOCKV_NOBBM,1,7)='" & Format(Now(), "yyMMdd") & "V'", "", 0)
                    If mNovcrNew = "" Then
                        mNoBBM = Format(Now(), "yyMMdd") & "V01"
                    Else
                        mNoBBM = Mid(mNovcrNew, 1, 7) & Format(Val(Mid(mNovcrNew, 8, 2)) + 1, "0#")
                    End If
                End If
            End If

            If mNoBBM <> "" Then
                If mFindNoVcr = 0 Then
                    'STOCKV_TTT,STOCKV_TTTTgl,STOCKV_TTTDlr,STOCKV_CRSELL,STOCKV_TTTDlr
                    MySTRsql1 = "INSERT INTO TRXN_STOCKVKIRIM(STOCKV_NORANGKA,STOCKV_NOBBM,STOCKV_NILAI,STOCKV_TGLBATAL,STOCKV_ST,STOCKV_CRSELL,STOCKV_TTT,STOCKV_TTTTgl,STOCKV_TTTDlr,STOCKV_Note,STOCKV_CREATE) VALUES " & _
                                "('" & TxtNoRangka.Text & "','" & mNoBBM & "'," & mJumlah & ",NULL,'','" & mTipeVcr & "','',NULL,'','" & TxtBBMCt.Text & "',GETDATE())"
                    If UpdateDatabase_Tabel(MySTRsql1, "", 1) = 1 Then
                        TxtNoVcrBBM.Text = mNoBBM
                        LblBBMJm.Text = ndb(mJumlah)
                        LblBBMTg.Text = Now()
                    End If
                Else
                    Msg_err("SUDAH DIBUATKAN VOUCHER BBM NO " & mNoBBM, 1)
                End If
            End If
        End If
        Call GETVOUCHER_DATA_BBM("STOCKV_NORANGKA='" & TxtNoRangka.Text & "'", "")

    End Function




    Function Simpan_Setuju() As Byte
        Simpan_Setuju = 0
        If LblTglInputHapusMohon.Text <> "" Then
            Msg_err("SUPIR TIDAK BISA KARENA SUDAH DIBATALKAN PENGIRIMANNYA", 1) : Exit Function
        ElseIf TxttglTerima.Text <> "" Then
            Msg_err("SUPIR TIDAK BISA KARENA KENDARAAN SUDAH DITERIMA", 1) : Exit Function
        ElseIf lblNmSupir.Text = "" Then
            Msg_err("KODE SUPIR TIDAK ADA !!!!!!!!!", 1) : Exit Function
        ElseIf TxttglKirimSetujui.Text = "" Then
            Msg_err("TANGGAL KIRIM BELUM DIISI !!!!!!!!!", 1) : Exit Function
        End If
        If simpanALsan(TxtNoRangka.Text, "RK", "ALASAN PERUBAHAN TANGGAL KIRIM ", TxtAlasanRubahTglKirim.Text, mTemplate) = 1 Then
            TxtAlasanRubahTglKirim.Text = "PINDAH TGL KIRIM :" & TxtAlasanRubahTglKirim.Text
            Simpan_Setuju = UpdateDatabase_Tabel("UPDATE TRXN_STOCKMKIRIM SET STOCKM_BERITA='" & TxtAlasanRubahTglKirim.Text & "',STOCKM_KIRIMTGLSETUJUI=" & FieldTgl(TxttglKirimSetujui.Text) & " WHERE STOCKM_NORANGKA='" & TxtNoRangka.Text & "'", "", 1)
            If Simpan_Setuju <> 1 Then
                Msg_err("SIMPAN GAGAL", 1)
                TxttglKirimSetujui.Text = ""
            Else
                Msg_err("SIMPAN PERUBAHAN TANGGA KIRIM BERHASIL", 1)
                TxtAlasanRubahTglKirim.Text = ""
            End If
        Else
            TxttglKirimSetujui.Text = ""
        End If
    End Function
    Function SimpanPDI(ByVal mJenis As Byte) As Byte
        '1:sIMPAN   2:bATAL
        SimpanPDI = 0
        If LblTglInputHapusMohon.Text <> "" Then
            TxttglPDI.Text = ""
            Msg_err("PDI TIDAK BISA KARENA SUDAH DIBATALKAN PENGIRIMANNYA", 1) : Exit Function
        ElseIf TxttglTerima.Text <> "" Then
            TxttglPDI.Text = ""
            Msg_err("PDI TIDAK BISA KARENA KENDARAAN SUDAH DITERIMA", 1) : Exit Function
        ElseIf lblNmSupir.Text = "" Then
            TxttglPDI.Text = ""
            Msg_err("KODE SUPIR TIDAK ADA !!!!!!!!!", 1) : Exit Function
        ElseIf TxttglPDI.Text = "" Then
            Msg_err("TANGGAL PDI BELUM DIISI !!!!!!!!!", 1) : Exit Function
        End If
        If mJenis = 1 Then 'INPUT
            SimpanPDI = UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLPDI=" & nSrSQL(TxttglPDI.Text) & " WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1)
            If SimpanPDI = 1 Then
                TxttglPDINote.Text = "TANGGAL PDI BERHASIL DISIMPAN TEKAN BATAL UNTUK BATAL PDI"
                'Cetak Call cetakPDI(TxtNoRangka.Text)
            Else
                TxttglPDI.Text = ""
                TxttglPDINote.Text = "ERROR TANGGAL PDI TIDAK BERHASIL DISIMPAN "
            End If
        Else              'BATAL'
            SimpanPDI = UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLPDI=NULL WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1)
            If SimpanPDI = 1 Then
                TxttglPDI.Text = ""
                TxttglPDINote.Text = "SUDAH BERHASIL DI BATALKAN"
            End If
        End If
    End Function

    'Otak Atik SPJ

    Function Simpan_SPJ_Kirim_Unit(ByVal MSTATUS As Byte) As Byte
        Dim mError As String = ""
        If TxtNoRangka.Text = "" Or TxtNoTTK.Text = "" Then
            mError = mError & Chr(13) & "Isian norangka atau nomor TTK kosong ......"
        End If
        If TxttglKeluar.Text = "" Then
            mError = mError & Chr(13) & "Tanggal keluar belum diisi !!!!!!!!!"
        End If

        If LblKirimJenis.Text = "" Then
            mError = mError & Chr(13) & "Isian Jenis Pengiriman kosong ......"
        End If
        If TxtKirimOngkos.Text = "" Then
            mError = mError & Chr(13) & "Isian Biaya Pengiriman kosong ......"
        End If
        If TxtKirimOngkos.Text = "" Or Not IsNumeric(TxtKirimOngkos.Text) Then
            mError = mError & Chr(13) & "Ongkos Kirim belum diisi "
        End If

        If LblKirimJenis.Text = "CUSTOMER" Then
            If Not ((Mid(lblAkses.Text, 4, 1) = "1" And MSTATUS = 1) Or (Mid(lblAkses.Text, 5, 1) = "1" And MSTATUS = 2)) Then
                mError = mError & Chr(13) & "Tidak diijinkan untuk merubah SPJ jenis customer ...."
            End If
            If MSTATUS = 1 Then
                If GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCK WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "' AND STOCK_DOTGLGESEKRGKI IS NULL", "", 1) = 1 Then
                    Msg_err("Periksa Kembali Gesek Nomor Rangka belum dilakukan, apakah sudah dilakukan dengan Benar ? ", 1)
                End If
                If LblKirimNo.Text = "" Then
                    mError = mError & Chr(13) & "Pilihan supir belum tersimpan/No Kirim Belum ada ...."
                End If
                If Trim(TxtNama.Text) = "" Or lblNmSupir.Text = "" Then
                    TxttglKeluar.Text = ""
                    mError = mError & Chr(13) & "Alamat Tujuan atau kode supir belum diisi "
                End If
            End If
        Else
            'BtnSmp13.Enabled = IIf(Mid(lblAkses.Text, 11, 1) = "1", True, False) BtnBtl13.Enabled = IIf(Mid(lblAkses.Text, 12, 1) = "1", True, False)

            If Not ((Mid(lblAkses.Text, 11, 1) = "1" And MSTATUS = 1) Or (Mid(lblAkses.Text, 12, 1) = "1" And MSTATUS <> "1")) Then
                mError = mError & Chr(13) & "Tidak diijinkan untuk merubah SPJ jenis bukan customer ...."
            End If
            If lblNmSupir.Text = "" Then
                mError = mError & Chr(13) & "Kode supir belum diisi "
            End If
            If TxttglKeluarNote.Text = "" Then
                mError = mError & Chr(13) & "Keterangan tujuan belum diisi "
            End If

            If LblKirimJenis.Text = "SHOWROOM" Then
                If TxtKirimDealer.Text = "" Then
                    mError = mError & Chr(13) & "Kode dealer tujuan belum diisi "
                End If
                Dim mKodeDLR As String = GetDataD_IsiField("SELECT LOKASI_KODEDLR as IsiField FROM DATA_LOKASI WHERE LOKASI_KODE='" & TxtKirimDealer.Text & "'", "", 0)
                Dim mKodeLOK As String = GetDataD_IsiField("SELECT LOKASI_NAMA as IsiField FROM DATA_LOKASI WHERE LOKASI_KODE='" & TxtKirimDealer.Text & "'", "", 0)
                If TxtKirimDealer.Text = "" Or TxttglKeluar.Text = "" Then
                    mError = mError & Chr(13) & "Isikan tujuan pengiriman SW12 pasar minggu SW28 puri kembangan dan Tanggal Kirim"
                ElseIf Left(UCase(TxtKirimDealer.Text), 2) <> "SW" Then
                    mError = mError & Chr(13) & "Isikan tujuan pengiriman SW12 pasar minggu SW28 puri kembangan"
                ElseIf mKodeDLR <> "" Then
                    If mKodeDLR <> Kodedealer.Text Then
                        If GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCK WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'", mKodeDLR, 1) <> 1 Then
                            mError = mError & Chr(13) & "Lokasi tujuan tidak sama dengan kepemilikan unit stok !!!!!!!!  \n " & _
                                     "Stok punya kode dealer " & Kodedealer.Text & Chr(13) & _
                                     "Tujuan Pengiriman Dealer adalah " & mKodeLOK
                        End If
                    Else
                        'mError = mError & Chr(13) & "Tujuan Pengiriman Dealer adalah " & mKodeLOK
                    End If
                Else
                    mError = mError & Chr(13) & "Kode dealer tujuan salah salah ...."
                End If
            Else
                TxtKirimDealer.Text = ""
            End If
        End If

        If MSTATUS = 0 Then mError = ""

        If mError <> "" Then
            Call Msg_err(mError, 0)
        Else
            If LblKirimJenis.Text = "CUSTOMER" Then
                Call SimpanSPJCustomer(MSTATUS, LblKirimJenis.Text)
            Else
                Call SimpanSPJCustomer(MSTATUS, LblKirimJenis.Text)
            End If
        End If

    End Function

    'Update doaang STOCKK
    Function SimpanSPJCustomer(ByVal MSTATUS As Byte, ByVal mJenisKirim As String) As Byte
        '1/2 SIMPAN    0 : BATAL
        Dim MySTRsql0 As String
        Dim MySTRsql1 As String
        Dim MySTRsql2 As String
        Dim MySTRsql3 As String
        SimpanSPJCustomer = 0


        If MSTATUS = 1 Then
            TxttglKirimSetujui.Text = IIf(TxttglKirimSetujui.Text = "", Now, TxttglKirimSetujui.Text)
            If mJenisKirim <> "CUSTOMER" Then
                Call Insert_KirimKendaraan(TxtNoRangka.Text)
            End If
            If LblKirimNo.Text <> "" Then
                MySTRsql0 = "UPDATE TRXN_STOCKKKIRIM SET " & _
                            IIf(mJenisKirim <> "CUSTOMER", "STOCKK_DRIVERNM='" & TxttglKeluarNote.Text & "',", "") & _
                            "STOCKK_DRIVER='" & UCase(DropDownList2.Text) & "',STOCKK_BIAYA=0, STOCKK_KIRIMTGLKIRIM=" & nSrSQL(TxttglKeluar.Text) & ",STOCKK_KIRIMTGLKIRIMI=GETDATE() WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKK_NOKIRIM='" & LblKirimNo.Text & "'"
                If UpdateDatabase_Tabel(MySTRsql0, "", 1) = 1 Then
                    If mJenisKirim = "CUSTOMER" Then
                        MySTRsql1 = "UPDATE TRXN_STOCKMKIRIM SET STOCKM_KIRIMTGLSETUJUI=" & FieldTgl(TxttglKeluar.Text) & " WHERE STOCKM_NORANGKA='" & TxtNoRangka.Text & "'"
                        Call UpdateDatabase_Tabel(MySTRsql1, "", 1)

                        MySTRsql1 = "UPDATE TRXN_STOCK SET STOCK_TglKirim=" & nSrSQL(TxttglKeluar.Text) & " WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'"
                        Call UpdateDatabase_Tabel(MySTRsql1, "", 1)
                        MySTRsql2 = "DELETE FROM TRXN_STOCKAKIRIM WHERE STOCKA_NORANGKA='" & TxtNoRangka.Text & "'"
                        Call UpdateDatabase_Tabel(MySTRsql2, "", 1)


                        MySTRsql3 = "INSERT INTO TRXN_STOCKAKIRIM (STOCKA_NORANGKA,STOCKA_NAMA,STOCKA_ALAMAT,STOCKA_KOTA,STOCKA_PH,STOCKA_HP,STOCKA_STKIRIM) VALUES ('" & _
                                     TxtNoRangka.Text & "','" & TxtNama.Text & "','" & TxtAlamat.Text & "','" & TxtKota.Text & "','" & TxtPhone.Text & "','" & TxtNoHP.Text & "','')"
                        Call UpdateDatabase_Tabel(MySTRsql3, "", 1)
                        'Cetak Call cetakSPJ(TxtNoRangka.Text, 1)
                    Else

                    End If
                    'TxttglKeluarNote.Text = ""
                    Msg_err("TANGGAL SPJ BERHASIL DISIMPAN TEKAN BATAL UNTUK BATAL SPJ", 1)
                    'masukin ke manual cetak voucher Call UpdateSTOKBBM(1)
                    SimpanSPJCustomer = 1
                Else
                    TxttglKeluar.Text = "" : TxttglKeluarNote.Text = ""
                    Msg_err("TANGGAL SPJ TIDAK BERHASIL DISIMPAN)", 1)
                End If
            Else
                Msg_err("DATA TIDAK TERSIMPAN (CALL IT TIDAK ADA NOMOR KIRINYA)", 1)
            End If
        Else
            If TxttglTerima.Text <> "" Then
                Msg_err("BATAL TIDAK BISA KARENA KENDARAAN SUDAH DITERIMA", 1) : Exit Function
            ElseIf TxttglKeluarNote.Text = "" Then
                Msg_err("ISIKAN ALASAN BATAL DI CATATAN", 1) : Exit Function
            End If
            MySTRsql1 = "UPDATE TRXN_STOCKKKIRIM SET STOCKK_BIAYA=0,STOCKK_KIRIMTGLKIRIM=NULL WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKK_NOKIRIM='" & LblKirimNo.Text & "'"
            If UpdateDatabase_Tabel(MySTRsql1, "", 1) = 1 Then
                If mJenisKirim = "CUSTOMER" Then
                    MySTRsql2 = "UPDATE TRXN_STOCK SET STOCK_TglKirim=NULL WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'"
                    Call UpdateDatabase_Tabel(MySTRsql2, "", 1)

                    MySTRsql3 = "DELETE FROM TRXN_STOCKAKIRIM WHERE STOCKA_NORANGKA='" & TxtNoRangka.Text & "'"
                    Call UpdateDatabase_Tabel(MySTRsql3, "", 1)

                    MySTRsql3 = "DELETE from TRXN_STOCKKKIRIM WHERE STOCKK_NOKIRIM ='" & LblKirimNo.Text & "'"
                    Call UpdateDatabase_Tabel(MySTRsql3, "", 1)

                    Call UpdateDatabase_Tabel("INSERT INTO TRXN_STOCKHISTORY (STOCKH_NORANGKA,STOCKH_TANGGAL,STOCKH_STATUS,STOCKH_HISTORY,STOCKH_USER)  VALUES (" & _
                                             "'" & TxtNoRangka.Text & "',GETDATE(),'BS','" & Left("No " & LblKirimNo.Text & " JNS " & LblKirimJenis.Text & ":" & TxttglKeluarNote.Text, 190) & "','" & LblUserName.Text & "')", "", 1)
                    TxttglKeluar.Text = ""
                    Call UpdateSTOKBBM(0, "", "CUSTOMER")
                    Call Msg_err("BATAL TANGGAL SPJ BERHASIL DISIMPAN", 1)
                End If
                SimpanSPJCustomer = 1
            End If
        End If
    End Function

    Function CmdTerima(ByRef mStatus As Object) As Byte
        '1 INPUT 2 BATAL
        If LblKirimJenis.Text = "SHOWROOM" Then
            Call SimpanTandaTerimaDealer(mStatus)
        Else
            Call SimpanTandaTerima(mStatus)
        End If
    End Function


    Function InfoBelumTerima() As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim mSqlCommadstring As String = ""
        ' ===> STOCKK_KIRIMTGLTERIMA
        'If UpdateDatabase_Tabel("UPDATE TRXN_STOCK SET STOCKK_KIRIMMUGENTGLI=GETDATE(),STOCK_KIRIMMUGENSTS='',STOCK_KIRIMMUGENTGL=" & nSrSQL(TxttglKeluar.Text) & ",STOCK_KIRIMMUGENKODE='" & LblAksesorDlr.Text & "' WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) <> 1 Then

        'Salah
        mSqlCommadstring = "SELECT STOCK_NORANGKA as IsiField," & _
                    "(SELECT DRIVER_NAMA FROM DATA_DRIVER WHERE DRIVER_KODE=STOCKK_DRIVER) AS NamaDRIVE " & _
                    "FROM TRXN_STOCKKKIRIM,TRXN_STOCKMKIRIM,TRXN_STOCK WHERE STOCKK_NORANGKA=STOCKM_NORANGKA AND STOCKK_NORANGKA=STOCK_NORANGKA AND " & _
                    "STOCK_KIRIMMUGENTGL IS NULL AND " & _
                    "STOCKK_KIRIMTGLTERIMA IS NULL AND DATEDIFF(day,STOCKK_KIRIMTGLKIRIM,GETDATE()) > 2 AND DATEDIFF(day,'2018-01-01 00:00:00',STOCKK_KIRIMTGLKIRIM) >= 0 "  '703648
        'Bener
        mSqlCommadstring = "SELECT STOCKK_JENIS,STOCK_NORANGKA,STOCKK_KIRIMTGLKIRIM " & _
                           "FROM TRXN_STOCKKKIRIM,TRXN_STOCKMKIRIM,TRXN_STOCK WHERE STOCKK_NORANGKA=STOCKM_NORANGKA AND STOCKK_NORANGKA=STOCK_NORANGKA AND " & _
                           "((STOCK_KIRIMMUGENTGL IS NULL AND STOCKK_JENIS='3') OR (STOCKK_KIRIMTGLTERIMA IS NULL AND STOCKK_JENIS<>'3')) AND " & _
                           "DATEDIFF(day,STOCKK_KIRIMTGLKIRIM,GETDATE()) > 2 AND DATEDIFF(day,'2018-01-01 00:00:00',STOCKK_KIRIMTGLKIRIM) >= 0 ORDER BY STOCKK_KIRIMTGLKIRIM"

        InfoBelumTerima = 0
        cnn = New OleDbConnection(strconn)

        Dim myErrorMessage As String = ""
        Dim mSave As Byte = 0
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            InfoBelumTerima = IIf(MyRecReadA.HasRows = True, 1, 0)
            If InfoBelumTerima = 1 Then
                While MyRecReadA.Read()
                    If nSr(MyRecReadA("STOCK_NORANGKA")) <> TxtNoRangka.Text Then
                        If nSr(MyRecReadA("STOCKK_JENIS")) = "1" Then
                            myErrorMessage = myErrorMessage & "TGL " & DtFr(MyRecReadA("STOCKK_KIRIMTGLKIRIM")) & " KIRIM CUSTOMER : " & nSr(MyRecReadA("STOCK_NORANGKA")) & "  \n "
                        Else
                            myErrorMessage = myErrorMessage & "TGL " & DtFr(MyRecReadA("STOCKK_KIRIMTGLKIRIM")) & " KIRIM SHOWROOM : " & nSr(MyRecReadA("STOCK_NORANGKA")) & "  \n "

                        End If
                    End If
                End While
            End If

            If myErrorMessage <> "" Then
                InfoBelumTerima = 1
                Call Msg_err("KIRIM UNIT BELUM DIISI TANGGAL TERIMA LEBIH DARI DUA HARI (PER TGL 01/01/2018) :  \n " & myErrorMessage, 1)
            Else
                InfoBelumTerima = 0
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 1)
        End Try
    End Function

    Function InfoBelumStockValidasi() As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim mSqlCommadstring As String = ""
        mSqlCommadstring = "SELECT STOCK_NOTTK,STOCK_NORANGKA,STOCK_TglTTK " & _
                           "FROM TRXN_STOCK WHERE ISNULL(STOCK_ValidUser,'')='' AND " & _
                           "DATEDIFF(day,STOCK_TglTTK,GETDATE()) > 2 AND DATEDIFF(day,'2019-01-01 00:00:00',STOCK_TglTTK) >= 0 ORDER BY STOCK_NORANGKA"
        InfoBelumStockValidasi = 0
        cnn = New OleDbConnection(strconn)

        Dim myErrorMessage As String = ""
        Dim mSave As Byte = 0
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            InfoBelumStockValidasi = IIf(MyRecReadA.HasRows = True, 1, 0)
            If InfoBelumTerima() = 1 Then
                While MyRecReadA.Read()
                    If nSr(MyRecReadA("STOCK_NORANGKA")) <> TxtNoRangka.Text Then
                        myErrorMessage = myErrorMessage & " NO TTK : " & nSr(MyRecReadA("STOCK_NOTTK")) & " RANGKA " & DtFr(MyRecReadA("STOCK_NORANGKA")) & " TGL " & DtFr(MyRecReadA("STOCK_TglTTK")) & "  \n "
                    End If
                End While
            End If

            If myErrorMessage <> "" Then
                InfoBelumStockValidasi = 1
                Call Msg_err("KIRIM UNIT BELUM DIISI TANGGAL TERIMA LEBIH DARI DUA HARI (PER TGL 01/01/2018) :  \n " & myErrorMessage, 1)
            Else
                InfoBelumStockValidasi = 0
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 1)
        End Try
    End Function







    'Inset doaang STOCKK
    Function SimpanTandaTerima(ByRef mStatus As Object) As Byte
        '1 INPUT 2 BATAL
        SimpanTandaTerima = 0
        If TxttglTerima.Text = "" Then
            Msg_err("TANGGAL TERIMA BELUM DIISI", 1) : Exit Function
        ElseIf TxttglTerimaNote.Text = "" Then
            Msg_err("NAMA PENERIMA BELUM DIISI (KOTAK DIBAWAH TANGGAL)", 1) : Exit Function
        ElseIf LblKirimNo.Text = "" Then
            Msg_err("NOMOR KIRIM BELUM ADA (KIRIM CUSTOMER)...", 1) : Exit Function
        End If

        If mStatus = 1 Then
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLTERIMAI=GETDATE(),STOCKK_KIRIMTGLTERIMA=" & nSrSQL(TxttglTerima.Text) & ",STOCKK_KIRIMKETTERIMA='" & TxttglTerimaNote.Text & "' WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKK_NOKIRIM='" & LblKirimNo.Text & "'", "", 1) <> 1 Then
                Msg_err("TIDAK TERSIMPAN", 1)
            Else
                Msg_err("TANGGAL TERIMA BERHASIL DISIMPAN", 1)
            End If
        Else
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLTERIMAI=GETDATE(),STOCKK_KIRIMTGLTERIMA=NULL,STOCKK_KIRIMKETTERIMA='' WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKK_NOKIRIM='" & LblKirimNo.Text & "'", "", 1) = 1 Then
                lbltglterimai.Text = "" : TxtTglBatalNote.Text = ""
            End If
        End If
        SimpanTandaTerima = 1
    End Function


    Function SimpanTandaTerimaDealer(ByRef mStatus As Object) As Byte
        '1 INPUT 2 BATAL
        Dim MERROR As String
        SimpanTandaTerimaDealer = 0
        If mStatus = 1 Then
            'pERIKSA KODE DEALERNYA
            MERROR = ""
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCK SET STOCKK_KIRIMMUGENTGLI=GETDATE(),STOCK_KIRIMMUGENSTS='',STOCK_KIRIMMUGENTGL=" & nSrSQL(TxttglTerima.Text) & ",STOCK_KIRIMMUGENKODE='" & TxtKirimDealer.Text & "' WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) <> 1 Then
                Msg_err("TIDAK TERSIMPAN", 1)
            Else
                Call UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLTERIMAI=GETDATE(),STOCKK_KIRIMTGLTERIMA=" & nSrSQL(TxttglTerima.Text) & ",STOCKK_KIRIMKETTERIMA='" & TxttglTerimaNote.Text & "' WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKK_NOKIRIM='" & LblKirimNo.Text & "'", "", 1)
            End If
        Else
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCK SET STOCKK_KIRIMMUGENTGLI=GETDATE(),STOCK_KIRIMMUGENSTS='',STOCK_KIRIMMUGENTGL=NULL,STOCK_KIRIMMUGENKODE='' WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) = 1 Then
                lbltglterimai.Text = "" : TxtTglBatalNote.Text = ""
                Call UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLTERIMAI=GETDATE(),STOCKK_KIRIMTGLTERIMA=NULL,STOCKK_KIRIMKETTERIMA='' WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKK_NOKIRIM='" & LblKirimNo.Text & "'", "", 1)
            End If
        End If
        SimpanTandaTerimaDealer = 1
    End Function

    'Hanya Untuk Pengiriman Customer
    Function Data_Pengiriman_Customer(ByVal mNorangka As String, ByVal mTyipe As String) As Byte
        'Ketika input nama Supir
        Dim mCariTxt As String
        Data_Pengiriman_Customer = 0

        mCariTxt = "SELECT *," & _
                   "(SELECT DRIVER_NAMA FROM DATA_DRIVER,TRXN_STOCKKKIRIM WHERE DRIVER_KODE=STOCKK_DRIVER AND STOCKK_NORANGKA=STOCKM_NORANGKA) AS NamaDRIVE," & _
                   "(SELECT STOCKK_DRIVER FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) AS KodeDRIVE," & _
                   "(SELECT STOCKK_KIRIMTGLKIRIM FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) AS TanggalSPJ," & _
                   "(SELECT STOCKK_KIRIMTGLTERIMA FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) AS TanggalTerima," & _
                   "(SELECT STOCKK_KIRIMKETTERIMA FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) AS KeteranganTerima " & _
                   "FROM TRXN_STOCKMKIRIM,TRXN_STOCK WHERE STOCKM_NORANGKA=STOCK_NORANGKA AND STOCKM_NORANGKA='" & mNorangka & "' ORDER BY STOCKM_NORANGKA"
        If GetDataD_00NoFound01Found(mCariTxt, "", 1) = 1 Then
            mCariTxt = "SELECT *," & _
                       "(SELECT DRIVER_NAMA FROM DATA_DRIVER WHERE DRIVER_KODE=STOCKK_DRIVER) AS NamaDRIVE " & _
                       "FROM TRXN_STOCKKKIRIM,TRXN_STOCKMKIRIM,TRXN_STOCK WHERE STOCKK_NORANGKA=STOCKM_NORANGKA AND STOCKK_NORANGKA=STOCK_NORANGKA AND STOCKK_NORANGKA='" & mNorangka & "' AND STOCKK_JENIS='" & mTyipe & "'  ORDER BY STOCKK_NORANGKA"
            Data_Pengiriman_Customer = GetDataD_00NoFound01Found(mCariTxt, "", 1)
            If Data_Pengiriman_Customer <> 1 Then
                Data_Pengiriman_Customer = Insert_KirimKendaraan(mNorangka)
            End If
        Else
            Msg_err("DATA TIDAK BISA DISIMPAN DATA PERMOHONAN TIDAK ADA ", 1)
        End If
        If Data_Pengiriman_Customer = 0 Then
            Msg_err("DATA TIDAK TERSIMPAN (CALL IT)", 1)
        End If
    End Function

    Function Insert_KirimKendaraan(ByVal mNoRangkaku As String) As Byte
        'Disimpan supir
        Insert_KirimKendaraan = 0
        Dim jnskirim As String = ""
        If LblKirimJenis.Text = "CUSTOMER" Then
            jnskirim = "1"
        ElseIf LblKirimJenis.Text = "PAMERAN" Then
            jnskirim = "2"
        ElseIf LblKirimJenis.Text = "SHOWROOM" Then
            jnskirim = "3"
        End If
        If GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCKMKIRIM WHERE ISNULL(STOCKK_STATUS,'')='' AND STOCKK_KIRIMTGLTERIMA IS NULL AND STOCKM_NORANGKA='" & mNoRangkaku & "'", "", 0) = 1 Then
            Msg_err("Ada pengiriman kendaraan yang belum diisi terima lihat di tabel pengiriman ", 0) : Exit Function
        End If
        LblKirimInputDanKirim.Text = ""
        LblKirimNo.Text = GetDataD_IsiField("SELECT MAX(STOCKK_NOKIRIM) as IsiField FROM TRXN_STOCKKKIRIM WHERE SUBSTRING(STOCKK_NOKIRIM,1,4)='" & Format(Now(), "yyMM") & "'", "", 0)
        If LblKirimNo.Text = "" Then
            LblKirimNo.Text = Format(Now(), "yyMM") & "001"
        Else
            LblKirimNo.Text = Mid(LblKirimNo.Text, 1, 4) & Format(Val(Mid(LblKirimNo.Text, 5, 3)) + 1, "0##")
        End If
        If LblKirimNo.Text <> "" Then
            Insert_KirimKendaraan = UpdateDatabase_Tabel("INSERT INTO TRXN_STOCKKKIRIM (STOCKK_NOKIRIM,STOCKK_JENIS,STOCKK_BIAYA,STOCKK_NORANGKA,STOCKK_TOMUGEN,STOCKK_STATUS) " & _
                                                         "VALUES ('" & LblKirimNo.Text & "','" & jnskirim & "',0,'" & mNoRangkaku & "','" & TxtKirimDealer.Text & "','')", "", 1)
            If Insert_KirimKendaraan = 1 Then
                TxttglKirimSetujui.Text = lblTglAdmin.Text

                Insert_KirimKendaraan = UpdateDatabase_Tabel("UPDATE TRXN_STOCKMKIRIM SET STOCKM_KIRIMTGLSETUJUI=" & FieldTgl(lblTglAdmin.Text) & " WHERE STOCKM_NORANGKA='" & mNoRangkaku & "'", "", 1)

            End If
            LvUnitKirimPerRangka.DataBind()
        Else
            Call Msg_err("Crreate NOmor error ", 0)
        End If
    End Function

    Function Data_PengirimanOld(ByVal mNorangka As String) As Byte
        Dim mCariTxt As String
        Data_PengirimanOld = 0

        mCariTxt = "SELECT *," & _
                                    "(SELECT DRIVER_NAMA FROM DATA_DRIVER,TRXN_STOCKKKIRIM WHERE DRIVER_KODE=STOCKK_DRIVER AND STOCKK_NORANGKA=STOCKM_NORANGKA) AS NamaDRIVE," & _
                                    "(SELECT STOCKK_DRIVER FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) AS KodeDRIVE," & _
                                    "(SELECT STOCKK_KIRIMTGLKIRIM FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) AS TanggalSPJ," & _
                                    "(SELECT STOCKK_KIRIMTGLTERIMA FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) AS TanggalTerima," & _
                                    "(SELECT STOCKK_KIRIMKETTERIMA FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) AS KeteranganTerima " & _
                                     "FROM TRXN_STOCKMKIRIM,TRXN_STOCK WHERE STOCKM_NORANGKA=STOCK_NORANGKA AND STOCKM_NORANGKA='" & mNorangka & "' ORDER BY STOCKM_NORANGKA"
        If GetDataD_00NoFound01Found(mCariTxt, "", 1) = 1 Then
            mCariTxt = "SELECT *," & _
                       "(SELECT DRIVER_NAMA FROM DATA_DRIVER WHERE DRIVER_KODE=STOCKK_DRIVER) AS NamaDRIVE " & _
                       "FROM TRXN_STOCKKKIRIM,TRXN_STOCKMKIRIM,TRXN_STOCK WHERE STOCKK_NORANGKA=STOCKM_NORANGKA AND STOCKK_NORANGKA=STOCK_NORANGKA AND STOCKK_NORANGKA='" & mNorangka & "' ORDER BY STOCKK_NORANGKA"
            Data_PengirimanOld = GetDataD_00NoFound01Found(mCariTxt, "", 1)
            If Data_PengirimanOld <> 1 Then
                'If FIND_MohonKirim("DATEDIFF(minute,STOCKM_TGLMOHONKIRIM,'" & FieldTgl(TxtTglAdmin.Text) & "') < 0 AND " & _
                '                  "DATEDIFF(day,STOCKM_TGLMOHONKIRIM,'" & FieldTgl(TxtTglAdmin.Text) & "') = 0 AND " & _
                '                  "STOCKM_NORANGKA='" & TxtNoRangka.Text & "' AND " & _
                '                  "(SELECT STOCKK_NORANGKA FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) IS NULL", "STOCKM_NORANGKA", 0) = 1 Then
                'If simpanALsan("S", "ADA TANGGAL PERMOHONAN KIRIM KENDARAAN SEBELUMNYA YANG BELUM DIISI SUPIR \n " & _
                '               "JIKA INGIN MENDAHULU DARI TANGGAL PERMOHONAN \n " & _
                '               "ISIKAN ALASANNYA", "ISI DRIVER") <> 1 Then mInputDriver = 0
                'End If
                LblKirimInputDanKirim.Text = ""
                LblKirimNo.Text = GetDataD_IsiField("SELECT MAX(STOCKK_NOKIRIM) as IsiField FROM TRXN_STOCKVKIRIM WHERE SUBSTRING(STOCKK_NOKIRIM,1,4)='" & Format(Now(), "yyMM") & "'", "", 0)
                If LblKirimNo.Text = "" Then
                    LblKirimNo.Text = Format(Now(), "yyMM") & "001"
                Else
                    LblKirimNo.Text = Mid(LblKirimNo.Text, 1, 4) & Format(Val(Mid(LblKirimNo.Text, 5, 3)) + 1, "0##")
                End If

                If LblKirimNo.Text <> "" Then
                    Data_PengirimanOld = Insert_KirimKendaraan(mNorangka)
                Else
                    Call Msg_err("Crreate NOmor error ", 0)
                End If

            End If
        Else
            Msg_err("DATA TIDAK BISA DISIMPAN DATA PERMOHONAN TIDAK ADA ", 1)
        End If
        If Data_PengirimanOld = 0 Then
            Msg_err("DATA TIDAK TERSIMPAN (CALL IT)", 1)
        End If
    End Function

    'End Otak Atik SPJ
    Protected Sub LvUnitKirimPerRangka_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvUnitKirimPerRangka.SelectedIndexChanged
        LblKirimNo.Text = (LvUnitKirimPerRangka.DataKeys(LvUnitKirimPerRangka.SelectedIndex).Value.ToString)
        LblKirimInputDanKirim.Text = ""
        Call GETPROSES_DATA_KIRIM("STOCKK_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKK_NOKIRIM='" & LblKirimNo.Text & "' AND STOCKK_STATUS=''", "")
    End Sub


    Function Simpan_Supir(ByVal mStatus As Byte) As Byte
        Simpan_Supir = 0

        lblNmSupir.Text = GetDataD_IsiField("SELECT DRIVER_NAMA as IsiField FROM DATA_DRIVER WHERE DRIVER_KODE='" & UCase(DropDownList2.Text) & "'", "", 0)
        If LblTglInputHapusMohon.Text <> "" Then
            Msg_err("SUPIR TIDAK BISA DIRUBAH KARENA SUDAH DIBATALKAN PENGIRIMANNYA", 1) : Exit Function
        ElseIf TxttglTerima.Text <> "" Then
            Msg_err("SUPIR TIDAK BISA DIRUBAH KARENA KENDARAAN SUDAH DITERIMA", 1) : Exit Function
        ElseIf TxttglKeluar.Text <> "" And LblKirimNo.Text <> "" Then
            Msg_err("SUPIR TIDAK BISA DIRUBAH KARENA SUPIR TIDAK BISA DIRUBAH SUDAH DICETAK SPJ ...... ", 1) : Exit Function
        ElseIf lblNmSupir.Text = "" Then
            Msg_err("KODE SUPIR TIDAK ADA !!!!!!!!!", 1) : Exit Function
        ElseIf LblUsrAdmin.Text <> "" And LblKirimJenis.Text = "PAMERAN" And LblKirimNo.Text = "" Then
            Msg_err("SUDAH PROSES KIRIM CUSTOMER TIDAK BOLEH MEMBUAT SPJ YANG NON CUSTOMER !!!!!!!!!", 1) : Exit Function
        ElseIf LblKirimNo.Text = "" Then
            If GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCKKKIRIM WHERE " & _
                                         "STOCKK_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKK_KIRIMTGLTERIMA IS NULL AND STOCKK_STATUS<>'' ORDER BY STOCKK_NORANGKA", "", 1) = 1 Then
                Msg_err("LIHAT DI TABEL ADA SURAT PERINTA JALAN YANG MASIH AKTI BELUM DITERIMA !!!!!!!!!", 1) : Exit Function
            End If
        End If

        If LblKirimJenis.Text = "CUSTOMER" Then
            If Data_Pengiriman_Customer(TxtNoRangka.Text, "1") = 1 Then
                Simpan_Supir = UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_DRIVER='" & UCase(DropDownList2.Text) & "' WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1)
                If Simpan_Supir = 1 Then
                    Msg_err("ISIAN SUPIR BERHASIL DISIMPAN", 1)
                    lblNmSupir.Text = GetDataD_IsiField("SELECT DRIVER_NAMA as IsiField FROM DATA_DRIVER WHERE DRIVER_KODE='" & UCase(DropDownList2.Text) & "'", "", 0)
                End If
            End If
        Else

        End If
    End Function


    Function CmdValidOutHouse(ByVal mTYPE As Byte) As Byte
        '1 iNPUT  2: HAPUS
        CmdValidOutHouse = 0
        If mTYPE = 1 Then 'INPUT
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLSECURITY=GETDATE(),STOCKK_KIRIMKETSECURITY='SISTEM' WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) = 1 Then
                TxtTglSecurity.Text = Now()
                TxtTglSecurityNote.Text = "TERSIMPAN PERIKSA SECURITY DENGAN TANGGAL SISTEM TEKAN BATAL UNTUK BATAL VALID PDI"
                CmdValidOutHouse = 1
            End If
        Else 'BATAL
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLSECURITY=NULL,STOCKK_KIRIMKETSECURITY='' WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) = 1 Then
                TxtTglSecurity.Text = ""
                TxtTglSecurityNote.Text = ""
                CmdValidOutHouse = 1
            End If
        End If
    End Function

    Function Simpan_HapusDataPermohonan() As Byte
        Simpan_HapusDataPermohonan = 0
        If TxtTglBatalNote.Text = "" Then
            Msg_err("ALASAN BATAL BELUM DIISI ", 1) : Exit Function
        End If
        If simpanALsan(TxtNoRangka.Text, "BK", "ALASAN BATAL KIRIM", TxtTglBatalNote.Text, ": BTL TGL " & Format(Now(), "dd/MM/yy") & "/SPK:" & Kodedealer.Text & "-" & Left(lblnospkDO.Text, 6)) = 1 Then
            Call UpdateDatabase_Tabel("DELETE FROM TRXN_STOCKMKIRIM WHERE STOCKM_NORANGKA='" & TxtNoRangka.Text & "'", "", 1)
            Call UpdateDatabase_Tabel("DELETE FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKK_NOKIRIM='" & LblKirimNo.Text & "'", "", 1)
            Call UpdateDatabase_Tabel("DELETE FROM TRXN_STOCKAKIRIMP where STOCKAKP_NORANGKA='" & TxtNoRangka.Text & "'", "", 1)
            LblTglInputHapusMohon.Text = Now()
        End If
    End Function


    Function CmdCatatan(ByVal mCat As Byte) As Byte
        CmdCatatan = 0
        If TxttglCatatanDsc.Text <> "" Then
            Msg_err("CATATAN BELUM DIISI", 1) : Exit Function
        End If
        If mCat = 0 Then
            Call UpdateDatabase_Tabel("DELETE FROM TRXN_STOCKHISTORY WHERE STOCKH_STATUS='C0' AND STOCKH_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKA_STATUS='C'", "", 1)
            CmdCatatan = 1
        Else
            If simpanALsan(TxtNoRangka.Text, "C0", "CATATAN ", TxttglCatatanDsc.Text, TxttglCatatanDsc.Text) = 1 Then
                CmdCatatan = 1
            End If
        End If
    End Function



    Function SimpanBukuService(ByRef mStatus As Object) As Byte
        '1 INPUT 2 BATAL
        SimpanBukuService = 0
        If TxtTglBukuSvc.Text <> "" Then
            Msg_err("Tanggal Buku Service belum diisi", 1) : Exit Function
        End If

        If mStatus = 1 Then
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCK SET STOCK_BUKUSERVICE=" & nSrSQL(TxtTglBukuSvc.Text) & " WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) <> 1 Then
                TxtTglBukuSvc.Text = ""
                TxtBukuSvc.Text = "TIDAK TERSIMPAN"
            Else
                TxtBukuSvc.Text = "TERSIMPAN"
            End If
        Else
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCK SET STOCK_BUKUSERVICE=NULL,STOCK_KIRIMMUGENKODE='' WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) = 1 Then
                TxtTglBukuSvc.Text = "" : TxtBukuSvc.Text = "BERHASIL DIHAPUS"
            Else
                TxtBukuSvc.Text = "TIDAK BERHASIL DIHAPUS"
            End If
        End If
        SimpanBukuService = 1
    End Function

    Function SimpanDataTabel(ByRef mRow As Integer, ByRef mCol As Integer, ByVal mNilai As String) As Byte
        Dim MySTRsql1 As String
        SimpanDataTabel = 0

        If mCol = 2 Then 'Tanggal
            If mNilai = "" Then
                Msg_err("TANGGAL BELUM DIISI", 1) : Exit Function
            End If
            mNilai = nSrSQL(mNilai)
        ElseIf mCol = 19 Then 'Tanggal
            If mNilai = "Y" Or mNilai = "N" Then
                Msg_err("ISI Y untuk Ya atau T untuk Tidak", 1) : Exit Function
            End If
        End If

        If mRow = 16 Then 'TabelEdit.Items.Item(mRow).Text = "00. PDI NO SPK" Then
            MySTRsql1 = "UPDATE TRXN_STOCK SET STOCK_NOSPK='" & mNilai & "' WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'"
            SimpanDataTabel = UpdateDatabase_Tabel(MySTRsql1, "", 1)
        Else
            If GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCKPDI WHERE PDI_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) <> 1 Then
                SimpanDataTabel = UpdateDatabase_Tabel("INSERT INTO TRXN_STOCKPDI (PDI_NORANGKA) VALUES ('" & TxtNoRangka.Text & "')", "", 1)
            End If
            MySTRsql1 = ""
            If mRow = 17 Then 'TabelEdit.Items.Item(mRow).Text = "00. PDI TRANSMISI" Then
                MySTRsql1 = "PDI_TRANSMISI='" & mNilai & "' "
            ElseIf mRow = 18 Then 'If TabelEdit.Items.Item(mRow).Text = "00. PDI NAMA SUPIR" Then
                MySTRsql1 = "PDI_DRIVER='" & mNilai & "' "
            ElseIf mRow = 19 Then 'TabelEdit.Items.Item(mRow).Text = "00. PDI PLAT MJS [Y]A [T]IDAK" Then
                MySTRsql1 = "PDI_PLATMJS='" & mNilai & "' "
            ElseIf mRow = 20 Then 'TabelEdit.Items.Item(mRow).Text = "00. PDI KETERANGAN" Then
                MySTRsql1 = "PDI_KETERANGAN='" & TxtPetik(mNilai) & "' "
            ElseIf mRow = 21 Then 'TabelEdit.Items.Item(mRow).Text = "00. PDI GESEKAN LAKBAN*" Then
                MySTRsql1 = "PDI_TGLGESEKLAKBAN=" & mNilai & " "
            ElseIf mRow = 22 Then 'TabelEdit.Items.Item(mRow).Text = "00. PDI GESEKAN POLDA*" Then
                MySTRsql1 = "PDI_TGLGESEKPOLDA=" & mNilai & " "
            End If
            If MySTRsql1 <> "" Then
                MySTRsql1 = "UPDATE TRXN_STOCKPDI SET " & MySTRsql1 & " WHERE PDI_NORANGKA='" & TxtNoRangka.Text & "'"
                SimpanDataTabel = UpdateDatabase_Tabel(MySTRsql1, "", 1)
            End If
        End If
    End Function

    Function SimpanDataTabelSTCK(ByVal mCode1 As String, ByVal mCode2 As String) As Byte
        Dim mNilai As Integer = 0
        Dim mRangka As String = ""

        Dim Cari1 As String = "SELECT * FROM TRXN_STOCKSTCK WHERE STCK_NO='" & TxtNoSTCK.Text & "' AND STCK_NORANGKA<>'" & TxtNoRangka.Text & "' AND NOT(STCK_NORANGKA='' OR STCK_NORANGKA IS NULL)"
        Dim Cari2 As String = "SELECT * FROM TRXN_STOCKSTCK WHERE STCK_NO='" & TxtNoSTCK.Text & "' AND (STCK_NORANGKA='' OR STCK_NORANGKA IS NULL OR STCK_NORANGKA='" & TxtNoRangka.Text & "')"


        If TxttglKeluar.Text = "" Then
            Msg_err("TANGGAL KELUAR BELUM TERISI", 1) : Exit Function
        ElseIf TxtNoSTCK.Text = "" Then
            Msg_err("NOMOR STCK BELUM TERISI", 1) : Exit Function
        ElseIf TxtNoRangka.Text = "" Then
            Msg_err("NOMOR RANGKA BELUM TERISI", 1) : Exit Function
        ElseIf GetDataD_00NoFound01Found(Cari1, "", 1) = 1 Then
            Msg_err("NOMOR STCK INI SUDAH TERPAKAI OLEH RANGA LAIN", 1) : Exit Function
        ElseIf GetDataD_00NoFound01Found(Cari2, "", 1) = 1 Then
            If mCode1 = "1" Then
                mNilai = -1
                mRangka = TxtNoRangka.Text
            Else
                mNilai = 0
                mRangka = ""
            End If
            SimpanDataTabelSTCK = UpdateDatabase_Tabel(Edit_STCK(TxtNoSTCK.Text, mRangka, nSrSQL(TxttglKeluar.Text), mNilai, "2", mCode2), "", 1)
            If mCode1 = "1" Then
                'Blm Bisa Call cetakStck(TxtNoRangka.Text, "1")
            End If
            Label24.Text = GETSTOCK_QTYSTCK("WHERE (STCK_NORANGKA='' OR STCK_NORANGKA IS NULL)")
        Else
            Msg_err("NOMOR STCK TIDAK ADA", 1) : Exit Function
        End If
    End Function

    Function GETSTOCK_QTYSTCK(ByVal mSearchTxt As String) As String
        GETSTOCK_QTYSTCK = nLg(GetDataD_IsiField("SELECT SUM(STCK_QTY) as IsiField FROM TRXN_STOCKSTCK WHERE (STCK_NORANGKA='' OR STCK_NORANGKA IS NULL)", "", 0))
    End Function


    Function Insert_STCK(ByVal mNoSTCK As String, ByVal mNoPOL As String) As String
        Insert_STCK = "INSERT INTO TRXN_STOCKSTCK(STCK_NO,STCK_NOPOL,STCK_TGLINPUT) VALUES ('" & mNoSTCK & "','" & mNoPOL & "',GETDATE())"
    End Function

    Function Edit_STCK(ByVal mNoSTCK As String, ByVal mNoRGk As String, ByVal mNoKirim As String, ByVal mQty As Integer, ByVal mStatus As String, ByVal mNote As String) As String
        'STATUS  1=STock 2=NonSTock 3=Batal/Hangus 4=Batal/Tdk Hangus
        Edit_STCK = "UPDATE TRXN_STOCKSTCK SET " & _
                    "STCK_TGLKIRIM=" & IIf(mNoRGk = "", "NULL", mNoKirim) & "," & _
                    "STCK_NORANGKA='" & mNoRGk & "'," & _
                    "STCK_STATUS='" & mStatus & "'," & _
                    "STCK_QTY=" & mQty * 1 & "," & _
                    "STCK_NOTE='" & mNote & "' " & _
                    "WHERE STCK_NO='" & mNoSTCK & "'"
    End Function


    Function fLg(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        fLg = "0"
        If IsNumeric(nilai) Then fLg = Format(Val(nilai), "###,###,###,###,##0")
ErrHand:
    End Function
    Function nLg(ByRef nilai As Object) As Double
        On Error GoTo ErrHand
        nLg = 0
        If IsNumeric(nilai) Then nLg = Val(nilai) '10
ErrHand:
    End Function
    Function ndb(ByRef nilai As Object) As Double
        On Error GoTo ErrHand
        ndb = 0
        If IsNumeric(nilai) Then ndb = Val(nilai) '10
ErrHand:
    End Function
    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function
    Function TxtPetik(ByRef MyText As String) As String
        Dim mPosStart As Byte
        TxtPetik = IIf(IsDBNull(MyText), "", Trim(MyText))
        mPosStart = 1
        While InStr(mPosStart, TxtPetik, "'") <> 0
            mPosStart = InStr(mPosStart, TxtPetik, "'")
            TxtPetik = Mid(TxtPetik, 1, mPosStart) & "'" & "" & Mid(TxtPetik, mPosStart + 1, Len(TxtPetik) - mPosStart)
            mPosStart = mPosStart + 2
        End While
    End Function
    Function DtFrSQL(ByRef mNilai As Object) As String
        On Error GoTo ErrHand
        DtFrSQL = "NULL"
        If IsDate(mNilai) Then
            DtFrSQL = "'" & Format(CDate(mNilai), "yyyy-MM-dd hh:mm:ss") & "'"
        End If
        'msg_err(DtFrSQL)
ErrHand:
    End Function
    Function nSrSQL(ByRef Nilai As Object) As String
        On Error GoTo ErrHand
        nSrSQL = "NULL"
        If IsDate(Nilai) Then
            nSrSQL = "'" & Format(CDate(Nilai), "yyyy-MM-dd hh:mm:ss") & "'"
        End If
ErrHand:
    End Function
    Function FieldTgl(ByRef mnilai As Object) As String
        On Error GoTo ErrHand
        FieldTgl = "NULL"
        If IsDate(mnilai) Then
            FieldTgl = "'" & Format(CDate(mnilai), "yyyy-MM-dd hh:mm:ss") & "'"
        End If
ErrHand:
    End Function

    Function GetDataA_UserSecurity(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        GetDataA_UserSecurity = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_UserSecurity = IIf(MyRecReadA.HasRows = True, 1, 0)
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
            Call Msg_err("error " & ex.Message, 0)
        End Try
    End Function
    Function UpdateDatabase_Tabel(ByVal mSqlCommadstring As String, ByVal mpServer As String, ByVal mpErrorSistem As Byte) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        UpdateDatabase_Tabel = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateDatabase_Tabel = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, mpErrorSistem)
        End Try
    End Function
    Function GetDataD_IsiField(ByVal mSqlCommadstring As String, ByVal mpServer As String, ByVal mpMerrorsis As Byte) As String
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        GetDataD_IsiField = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadD = cmd.ExecuteReader()
            If MyRecReadD.HasRows = True Then
                MyRecReadD.Read()
                GetDataD_IsiField = (nSr(MyRecReadD("IsiField")))
            End If
            MyRecReadD.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, mpMerrorsis)
        End Try
    End Function
    Function GetDataD_00NoFound01Found(ByVal mSqlCommadstring As String, ByVal mpServer As String, ByVal mpMerrorsis As Byte) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        GetDataD_00NoFound01Found = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadD = cmd.ExecuteReader()
            If MyRecReadD.HasRows = True Then
                GetDataD_00NoFound01Found = 1
            End If
            MyRecReadD.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, mpMerrorsis)
        End Try
    End Function

    Protected Sub ButtonCariTTK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCariTTK.Click
        If TxtNoTTK.Text <> "" Then Call GETSTOCK_GETTTK("STOCK_NoTTK ='" & TxtNoTTK.Text & "'")
    End Sub


    Protected Sub ButtonCariTTK0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCariTTK0.Click
        Dim MySTRsql As String = ""
        If Label249.Text = "ALAMAT SPK" And TxtNama.Text <> "" Then
            If GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCKAKIRIM WHERE STOCKAKP_NORANGKA='" & TxtNoRangka.Text & "'", "", 0) = 0 Then
                MySTRsql = "INSERT INTO TRXN_STOCKAKIRIM (STOCKA_NORANGKA,STOCKA_NAMA,STOCKA_ALAMAT,STOCKA_KOTA,STOCKA_PH,STOCKA_HP,STOCKA_STKIRIM) VALUES ('" & _
                             TxtNoRangka.Text & "','" & TxtNama.Text & "','" & TxtAlamat.Text & "','" & TxtKota.Text & "','" & TxtPhone.Text & "','" & TxtNoHP.Text & "','S')"
                Call UpdateDatabase_Tabel(MySTRsql, "", 1)
            Else
                MySTRsql = "UPDATE TRXN_STOCKAKIRIM SET STOCKA_NAMA='" & TxtNama.Text & "',STOCKA_ALAMAT='" & TxtAlamat.Text & "',STOCKA_KOTA='" & TxtKota.Text & "',STOCKA_PH='" & TxtPhone.Text & "',STOCKA_HP='" & TxtNoHP.Text & "',STOCKA_STKIRIM='S' WHERE STOCKA_NORANGKA='" & TxtNoRangka.Text & "'"
                Call UpdateDatabase_Tabel(MySTRsql, "", 1)
            End If
        ElseIf Label249.Text = "ALAMAT STNK" And TxtNama.Text <> "" Then
            If GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCKAKIRIM WHERE STOCKA_NORANGKA='" & TxtNoRangka.Text & "'", "", 0) = 0 Then
                MySTRsql = "INSERT INTO TRXN_STOCKAKIRIM (STOCKA_NORANGKA,STOCKA_NAMA,STOCKA_ALAMAT,STOCKA_KOTA,STOCKA_PH,STOCKA_HP,STOCKA_STKIRIM) VALUES ('" & _
                             TxtNoRangka.Text & "','" & TxtNama.Text & "','" & TxtAlamat.Text & "','" & TxtKota.Text & "','" & TxtPhone.Text & "','" & TxtNoHP.Text & "','K')"
                Call UpdateDatabase_Tabel(MySTRsql, "", 1)
            Else
                MySTRsql = "UPDATE TRXN_STOCKAKIRIM SET STOCKA_NAMA='" & TxtNama.Text & "',STOCKA_ALAMAT='" & TxtAlamat.Text & "',STOCKA_KOTA='" & TxtKota.Text & "',STOCKA_PH='" & TxtPhone.Text & "',STOCKA_HP='" & TxtNoHP.Text & "',STOCKA_STKIRIM='K' WHERE STOCKA_NORANGKA='" & TxtNoRangka.Text & "'"
                Call UpdateDatabase_Tabel(MySTRsql, "", 1)
            End If
        End If
    End Sub








    Function ValidasiTombol(ByVal mTombol As Byte, ByVal mAction As Byte) As Byte
        'If mTombol <> 12 Then
        If LblKirimJenis.Text = "SHOWROOM" Then
            If GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCK WHERE STOCK_KIRIMMUGENTGL IS NOT NULL AND STOCKK_JENIS = '3' AND STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) = 1 Then
                'Msg_err("SUDAH DI KIRIM KE DEALER ", 1) : Exit Function
                Msg_err("UNIT SUDAH PERNAH DI KIRIM KE DEALER ", 1)
            End If
        End If

        If Not (mTombol = 7 Or mTombol = 8 Or mTombol = 9 Or mTombol = 13) And mAction = 1 Then 'Bukan Terima dan terima mugen
            If InfoBelumTerima() = 1 Then
                Exit Function
            ElseIf InfoBelumStockValidasi() = 1 Then
                Exit Function
                'ElseIf InfoBelumPermohonanYang belumadaSPJNYa() = 1 Then
                '    Exit Function
            Else
                'Dim mySqlCommand As String = "SELECT COUNT(TRXN_STOCKMKIRIM.STOCKM_KDDEALER) as IsiField " & _
                '                             "FROM TRXN_STOCKMKIRIM LEFT OUTER JOIN TRXN_STOCK ON TRXN_STOCKMKIRIM.STOCKM_NORANGKA = TRXN_STOCK.STOCK_NoRangka " & _
                '                             "LEFT OUTER JOIN TRXN_STOCKKKIRIM ON TRXN_STOCK.STOCK_NoRangka = TRXN_STOCKKKIRIM.STOCKK_NORANGKA " & _
                '                             "WHERE(Year(TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM) >= 2018) And (TRXN_STOCKKKIRIM.STOCKK_NORANGKA Is NULL) And " & _
                '                             "DATEDIFF(DAY,TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM,GETDATE()) > 0 "
                'Dim Mjumlah As Integer = nLg(GetDataD_IsiField(mySqlCommand, "", 1))
                '
                'If Mjumlah > 0 Then
                'Tunggu Diperbaiki
                'Call Msg_err("ADA PERMOHONAN KIRIM TANGGAL KEMARIN YANG BELUM DIBUATKAN SPJ \n LIHAT TABEL KE TIGA DI JADWAL PENGIRIMAN", 1)
                'Exit Function
                'End If
            End If
        End If

        Dim SimpanEdit As Integer
        If mAction = 1 Then 'Save
            Select Case mTombol
                Case 3 : SimpanEdit = Simpan_Supir(1)
                Case 4 : SimpanEdit = Simpan_Setuju()
                Case 5 : SimpanEdit = SimpanPDI(1)
                Case 6 : SimpanEdit = Simpan_SPJ_Kirim_Unit(1)
                Case 7 : SimpanEdit = CmdValidOutHouse(1)
                Case 8 : SimpanEdit = Simpan_HapusDataPermohonan()
                Case 9 : SimpanEdit = CmdTerima(1)
                Case 10 : SimpanEdit = CmdCatatan(1)
                    'Pindah di tabel Case 11 : SimpanEdit = UpdateSTOKBBM(1, "") 'Beda
                    'Gabung di SPJ Case 13 : SimpanEdit = SimpanTandaTerimaDealer(1)
                Case 14 : SimpanEdit = SimpanBukuService(1)
                    'Pindah di tabel Case 15 : SimpanEdit = UpdateSTOKBBM(1, "S")

                Case 16 : SimpanEdit = SimpanDataTabel(mTombol, 4, TxtPDISPK.Text)  'di no SPK
                Case 17 : SimpanEdit = SimpanDataTabel(mTombol, 4, TxtPDITransmisiNote.Text) 'Transmisi
                Case 18 : SimpanEdit = SimpanDataTabel(mTombol, 4, TxtPDISupirNot.Text) 'Supir
                Case 19 : SimpanEdit = SimpanDataTabel(mTombol, 4, TxtPDIPlatMJSNot.Text)  'Plat MJS
                Case 20 : SimpanEdit = SimpanDataTabel(mTombol, 4, TxtPDIKetera.Text)  'Keterangan
                Case 21 : SimpanEdit = SimpanDataTabel(mTombol, 2, TxtPDILakbanTgl.Text)            'Gesekan lakban
                Case 22 : SimpanEdit = SimpanDataTabel(mTombol, 2, TxtPDIPoldaTgl.Text)            'Gesekan Poda
                    'Case "00. PDI NO SPK" : SimpanEdit = SimpanDataTabel(mBaris, mCol, TabelEdit.Items.Item(mBaris).SubItems(mCol - 2).Text)
                Case 23 : SimpanEdit = SimpanDataTabelSTCK("1", "TERPAKAI")                                         'STCK
            End Select
        Else                'Batal
            Select Case mTombol
                Case 5 : Call SimpanPDI(0)              ' mCol = 2 / Batal PDI         
                Case 6 : Call Simpan_SPJ_Kirim_Unit(0)  ' mCol = 2 / Batal SPJ
                Case 7 : Call CmdValidOutHouse(0)       ' mCol = 2 / Batal 
                Case 9 : Call CmdTerima(0)              ' mCol = 2 / Batal Terima
                Case 10 : Call CmdCatatan(0)            ' mCol = 2 / Batal Catatan
                    'Pindah di tabel Case 11 : Call UpdateSTOKBBM(0, "") ' mCol = 2
                    'Gabung di SPJ Case 13 : Call SimpanTandaTerimaDealer(0) ' mCol = 2
                Case 14 : Call SimpanBukuService(0) ' mCol = 2
                    'Pindah di tabel Case 15 : Call UpdateSTOKBBM(0, "S") ' mCol = 2

                Case 16 : Call SimpanDataTabel(mTombol, 3, "")
                Case 17 : Call SimpanDataTabel(mTombol, 3, "")
                Case 18 : Call SimpanDataTabel(mTombol, 3, "")
                Case 19 : Call SimpanDataTabel(mTombol, 3, "")
                Case 20 : Call SimpanDataTabel(mTombol, 3, "")
                Case 21 : Call SimpanDataTabel(mTombol, 2, "")
                Case 22 : Call SimpanDataTabel(mTombol, 2, "")
                Case 23 : Call SimpanDataTabelSTCK("2", "BATAL")
            End Select
            'If mCol = 1 Then
            'TabelEdit.Items.Item(TabelEdit.FocusedItem.Index).SubItems(1).Text = ""
            'TabelEdit.Items.Item(TabelEdit.FocusedItem.Index).SubItems(2).Text = ""
            'End If
        End If

    End Function

    Sub IsiData(ByVal mTombol As Byte, ByVal mIsi1 As String, ByVal mIsi2 As String)

    End Sub


    Protected Sub BtnSmp03_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp03.Click
        Call ValidasiTombol(3, 1)
    End Sub
    Protected Sub BtnSmp04_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp04.Click
        Call ValidasiTombol(4, 1)
    End Sub
    Protected Sub BtnSmp05_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp05.Click
        Call ValidasiTombol(5, 1)
    End Sub
    Protected Sub BtnSmp06_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp06.Click
        Call ValidasiTombol(6, 1)
    End Sub
    Protected Sub BtnSmp07_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp07.Click
        Call ValidasiTombol(7, 1)
    End Sub
    Protected Sub BtnSmp08_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp08.Click
        Call ValidasiTombol(8, 1)
    End Sub
    Protected Sub BtnSmp09_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp09.Click
        Call ValidasiTombol(9, 1)
    End Sub
    Protected Sub BtnSmp10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp10.Click
        Call ValidasiTombol(10, 1)
    End Sub
    'Protected Sub BtnSmp11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp11.Click
    '    Call ValidasiTombol(11, 1)
    'End Sub
    Protected Sub BtnSmp12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp12.Click
        Call ValidasiTombol(12, 1)
    End Sub
    Protected Sub BtnSmp14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp14.Click
        Call ValidasiTombol(14, 1)
    End Sub
    'Protected Sub BtnSmp15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp15.Click
    '    Call ValidasiTombol(15, 1)
    'End Sub
    Protected Sub BtnSmp16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp16.Click
        Call ValidasiTombol(16, 1)
    End Sub
    Protected Sub BtnSmp17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp17.Click
        Call ValidasiTombol(17, 1)
    End Sub
    Protected Sub BtnSmp18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp18.Click
        Call ValidasiTombol(18, 1)
    End Sub
    Protected Sub BtnSmp19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp19.Click
        Call ValidasiTombol(19, 1)
    End Sub
    Protected Sub BtnSmp120_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp20.Click
        Call ValidasiTombol(20, 1)
    End Sub
    Protected Sub BtnSmp21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp21.Click
        Call ValidasiTombol(21, 1)
    End Sub
    Protected Sub BtnSmp22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp22.Click
        Call ValidasiTombol(22, 1)
    End Sub
    Protected Sub BtnSmp23_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp23.Click
        Call ValidasiTombol(23, 1)
    End Sub


    Protected Sub BtnBtl04_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl04.Click
        Call ValidasiTombol(4, 2)
    End Sub
    Protected Sub BtnBtl05_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl05.Click
        Call ValidasiTombol(5, 2)
    End Sub
    Protected Sub BtnBtl06_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl06.Click
        Call ValidasiTombol(6, 2)
    End Sub
    Protected Sub BtnBtl07_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl07.Click
        Call ValidasiTombol(7, 2)
    End Sub

    Protected Sub BtnBtl09_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl09.Click
        Call ValidasiTombol(9, 2)
    End Sub
    Protected Sub BtnBtl10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl10.Click
        Call ValidasiTombol(10, 2)
    End Sub
    'Protected Sub BtnBtl11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl11.Click
    '    Call ValidasiTombol(11, 2)
    'End Sub
    Protected Sub BtnBtl12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl12.Click
        Call ValidasiTombol(12, 2)
    End Sub
    Protected Sub BtnBtl14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl14.Click
        Call ValidasiTombol(14, 2)
    End Sub
    'Protected Sub BtnBtl15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl15.Click
    '    Call ValidasiTombol(15, 2)
    'End Sub
    Protected Sub BtnBtl16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl16.Click
        Call ValidasiTombol(16, 2)
    End Sub
    Protected Sub BtnBtl17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl17.Click
        Call ValidasiTombol(17, 2)
    End Sub
    Protected Sub BtnBtl18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl18.Click
        Call ValidasiTombol(18, 2)
    End Sub
    Protected Sub BtnBtl19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl19.Click
        Call ValidasiTombol(19, 2)
    End Sub
    Protected Sub BtnBtl120_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl20.Click
        Call ValidasiTombol(20, 2)
    End Sub
    Protected Sub BtnBtl21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl21.Click
        Call ValidasiTombol(21, 2)
    End Sub
    Protected Sub BtnBtl22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl22.Click
        Call ValidasiTombol(22, 2)
    End Sub
    Protected Sub BtnBtl23_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl23.Click
        Call ValidasiTombol(23, 2)
    End Sub

    Function simpanALsan(ByRef mNorangka As Object, ByRef mST As Object, ByRef mJud As Object, ByRef mJudNilai As Object, ByRef mKet As Object) As Byte
        'difinisi ST
        'RK = Rubah Tanggal Kirim
        'BK = Batal Kirim
        'C0 = Catatan
        'BR = Batal no rangka
        Dim myalasanku As String = ""
        simpanALsan = 0
        If mJudNilai = "" Then
            Msg_err("TIDAK MENGISIKAN ALASANNYA " & mJud, 1)
        Else
            myalasanku = mJudNilai
        End If
        If myalasanku <> "" Then
            simpanALsan = UpdateDatabase_Tabel("INSERT INTO TRXN_STOCKHISTORY (STOCKH_NORANGKA,STOCKH_TANGGAL,STOCKH_STATUS,STOCKH_HISTORY,STOCKH_USER)  VALUES (" & _
                                     "'" & mNorangka & "',GETDATE(),'" & mST & "','" & myalasanku & "','" & LblUserName.Text & "')", "", 1)
        End If
    End Function

    Protected Sub BtnTTKClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTTKClear.Click
        Call ClearFrom()
    End Sub

    Protected Sub BtnTTKSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTTKSave.Click


        If Multi03Stok.ActiveViewIndex = 0 Then
            If Mid(lblAkses.Text, 2, 1) = "1" Then
                Call Saveform()
            Else
                Call Msg_err("No access save Stok", 1)
            End If
        ElseIf Multi03Stok.ActiveViewIndex = 2 Then
            If Mid(lblAkses.Text, 15, 1) = "1" Then
                Call SaveformRepair()
            Else
                Call Msg_err("No access save Repair", 2)
            End If
        End If

    End Sub

    Protected Sub BtnTTKBatal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTTKBatal.Click
        Call CANCELRecord()
    End Sub


    Function Err_Save() As Byte
        Dim msg_errErr As String
        Dim mcdRangka As String
        msg_errErr = ""

        If TxtNoTTK.Text <> "" And TxtNoTTK.Text <> lblNoTTKTag.Text Then
            msg_errErr = msg_errErr & "KODE NO TTK YANG DI INPUT TIDAK BENAR /n"
        End If

        If Trim(TxtCdType.Text) <> Trim(lblCdTypeTag.Text) Then
            Call GETType_TTK("TYPE_Type ='" & UCase(TxtCdType.Text) & "'")
        End If
        If Trim(TxtCdWarna.Text) <> Trim(lblCdWarnaTag.Text) Then
            Call GETWarna_TTK("(WARNA_Kode) ='" & UCase(TxtCdWarna.Text) & "'")
        End If
        If Trim(TxtCdSuplier.Text) <> Trim(lblCdSuplierTag.Text) Then
            Call GetSuplier_TTK("SUPLIER_Kode LIKE '" & "%" & TxtCdSuplier.Text & "%" & "'")
        End If
        If Trim(TxtcdLokasi.Text) <> Trim(lblcdLokasiTag.Text) Then
            Call GetLokasi_TTK(UCase(TxtcdLokasi.Text))
        End If

        If Trim(TxtCdType.Text) <> Trim(lblCdTypeTag.Text) Or Trim(TxtCdType.Text) = "" Then msg_errErr = msg_errErr & "TYPE TIDAK DIKETEMUKAN  \n"
        If Trim(TxtCdWarna.Text) <> Trim(lblCdWarnaTag.Text) Or Trim(TxtCdWarna.Text) = "" Then msg_errErr = msg_errErr & "WARNA TIDAK DIKETEMUKAN  \n"
        If Trim(TxtCdSuplier.Text) <> Trim(lblCdSuplierTag.Text) Or Trim(TxtCdSuplier.Text) = "" Then msg_errErr = msg_errErr & "SUPLIER TIDAK DIKETEMUKAN  \n"
        If Trim(TxtcdLokasi.Text) = "" Then msg_errErr = msg_errErr & "LOKASI TIDAK DIKETEMUKAN   \n"
        If Trim(TxtNoRangka.Text) = "" Then msg_errErr = msg_errErr & "NO. RANGKA BELUM BENAR  \n"
        If TxtNoMesin.Text = "" Then msg_errErr = msg_errErr & "NO MESIN BELUM DIISI   \n"
        If TxtDTglDO.Text = "" Then msg_errErr = msg_errErr & "TANGGAL TERIMA UNIT BELUM DIISI   \n"
        If Trim(KodedealerTag.Text) <> Trim(Kodedealer.Text) And KodedealerTag.Text <> "" And InStr(NamaLokasi.Text, "CROS") = 0 Then msg_errErr = msg_errErr & "LOKASI TIDAK DIKETEMUKAN   \n"

        If CheckBoxBlokSales.Checked = True And CheckBoxBlokUnit.Checked = True Then msg_errErr = msg_errErr & "PILIH STATUS RANGKA SALAH SATU ATAU TIDAK SEMUANNYA   \n"

        'If KodeWarnaImora.Text <> "" And KodeWarnaImoraMugen.Text <> "" And _
        '   KodeWarnaImora.Text <> KodeWarnaImoraMugen.Text Then
        'msg_errErr = msg_errErr & "KODE WARNA TIDAK SAMA DGN WARNA IMORA (KOTAK HIJAU DAN KOTAK KUNING TIDAK SAMA) UNTUK MERUBAH WARNA INI (HUBUNGI IT)  \n " & _
        '            "WARNA IMORANNYA " & KodeWarnaImora.Tag & Chr(13)
        'End If

        If NamaWarna.Text <> "" And NamaWarnaImora.Text <> "" And _
           NamaWarna.Text <> NamaWarnaImora.Text Then
            msg_errErr = msg_errErr & "NAMA WARNA TIDAK SAMA DGN WARNA IMORA (KOTAK HIJAU DAN KOTAK KUNING TIDAK SAMA) UNTUK MERUBAH WARNA INI (HUBUNGI IT) \n " & _
                                    "NAMA WARNA IMORANNYA " & NamaWarnaImora.Text & Chr(13)
        End If

        If GetDataD_00NoFound01Found("SELECT * FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "' AND TYPE_Aktif ='1'", "", 0) = 1 Then
            msg_errErr = msg_errErr & "TIPE KENDARAAN SUDAH DI NON AKTIFKAN " & NamaType.Text & Chr(13)
        End If
        If GetDataD_00NoFound01Found("SELECT * FROM DATA_WARNA WHERE WARNA_Kode='" & TxtCdType.Text & "' AND WARNA_Aktif ='1'", "", 0) = 1 Then
            msg_errErr = msg_errErr & "WARNA KENDARAAN SUDAH DI NON AKTIFKAN " & NamaWarna.Text & Chr(13)
        End If



        If NoBTL.Visible = True Then msg_errErr = msg_errErr & "NO. TTK INI SUDAH DIBATALKAN TIDAK BISA DISIMPAN   \n"

        Dim mysqltxt As String = "SELECT *, " & _
                      "(SELECT TYPE_Nama FROM DATA_TYPE WHERE TYPE_Type = STOCK_CdType) AS NamaType, " & _
                      "(SELECT TYPE_IMORA FROM DATA_TYPE WHERE TYPE_Type = STOCK_CdType) AS KodeTypeImora, " & _
                      "(SELECT TYPE_CdRangka FROM DATA_TYPE WHERE TYPE_Type = STOCK_CdType) AS NoCdRangka, " & _
                      "(SELECT WARNA_Int FROM DATA_WARNA WHERE WARNA_Kode = STOCK_CdWarna) AS NamaWarna, " & _
                      "(SELECT WARNA_KODEHPM FROM DATA_WARNA WHERE WARNA_Kode = STOCK_CdWarna) AS NamaWarnaHPM, " & _
                      "(SELECT SUPLIER_Nama FROM DATA_SUPLIER WHERE SUPLIER_Kode = STOCK_CdSuplier) AS NamaSuplier, " & _
                      "(SELECT LOKASI_Nama FROM DATA_LOKASI WHERE LOKASI_Kode = STOCK_CdLokasi) AS NamaLokasi, " & _
                      "(SELECT LOKASI_KODEDLR FROM DATA_LOKASI WHERE LOKASI_Kode = STOCK_CdLokasi) AS Kodedealer, " & _
                      "(SELECT LOKASI_IPServer FROM DATA_LOKASI WHERE LOKASI_Kode = STOCK_CdLokasi) AS NamaServer " & _
                      "FROM TRXN_STOCK WHERE STOCK_NoRangka='" & TxtNoRangka.Text & "' AND STOCK_NoTTK <> '" & TxtNoTTK.Text & "' ORDER BY STOCK_NoTTK"

        ' FIND_STOCK("STOCK_NoRangka='" & TxtNoRangka.Text & "' AND STOCK_NoTTK <> '" & TxtNoTTK.Text & "'")
        If GetDataD_00NoFound01Found(mysqltxt, "", 0) = 1 Then msg_errErr = msg_errErr & "NO. RANGKA TERSEBUT SUDAH ADA (TERDAFTAR)   \n"
        If GetDataD_IsiField("SELECT TYPE_CdRangka as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0) <> "" Then
            Dim mAda As Byte = 0
            Dim mRangkaCari As String = ""
            mcdRangka = GetDataD_IsiField("SELECT TYPE_CdRangka  as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0) & _
                        GetDataD_IsiField("SELECT TYPE_CdRangka1 as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0)
            If InStr(1, UCase(TxtNoRangka.Text), mcdRangka) <> 0 Then
                mAda = 1
            Else
                mRangkaCari = mcdRangka
                mcdRangka = GetDataD_IsiField("SELECT TYPE_CdRangka  as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0) & _
                            GetDataD_IsiField("SELECT TYPE_CdRangka2 as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0)
                If InStr(1, UCase(TxtNoRangka.Text), mcdRangka) <> 0 Then
                    mAda = 1
                Else
                    mRangkaCari = mRangkaCari & "/" & mcdRangka
                    mcdRangka = GetDataD_IsiField("SELECT TYPE_CdRangka  as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0) & _
                                GetDataD_IsiField("SELECT TYPE_CdRangka3 as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0)
                    mRangkaCari = mRangkaCari & "/" & mcdRangka
                    If InStr(1, UCase(TxtNoRangka.Text), mcdRangka) <> 0 Then
                        mAda = 1
                    End If
                End If
            End If
            If mAda <> 1 Then
                'msg_errErr = msg_errErr & "NO. RANGKA TIDAK SESUAI DENGAN TIPE KENDARAAN (TIDAK ADA NOMOR " & mRangkaCari & " DI NOMOR RANGKA)   \n"
                Call Msg_err("NO. RANGKA TIDAK SESUAI DENGAN TIPE KENDARAAN (TIDAK ADA NOMOR " & mRangkaCari & " DI NOMOR RANGKA) ", 1)
            End If
        End If

        If TxtNoTTK.Text = "" And LblTagLokasi0.Text = "" Then

            Dim mNilai As String = GetDataD_IsiField("SELECT STOCKDO_KODEDLR as IsiField FROM TRXN_STOCKDO WHERE STOCKDO_NORANGKA='" & TxtNoRangka.Text & "'", "", 0)
            If mNilai = "" Then
                msg_errErr = "PERIKSA KEMBALI NOMOR RANGKA INI TIDAK ADA DI DAFTAR DATABASE DO IMORA \n " & _
                             "(JIKA DATA SUDAH BENAR KLIK SIMPAN SEKALI LAGI DATA AKAN KIRIM KE DEALER SESUAI DENGAN LOKASI STOK)"
            ElseIf mNilai <> Kodedealer.Text Then
                msg_errErr = "PERIKSA KEMBALI NOMOR RANGKA INI ADA DI DO IMORA UNTUK LOKASI " & mNilai & "TIDAK SESUAI DENGAN LOKASI " & Kodedealer.Text & Chr(13) & _
                       "(JIKA DATA SUDAH BENAR KLIK SIMPAN SEKALI LAGI DATA AKAN KIRIM KE DEALER SESUAI DENGAN LOKASI STOK)  \n"
            End If
            LblTagLokasi0.Text = "X"
        End If

        'If InfoBelumStockValidasi() = 1 Then
        'msg_errErr = msg_errErr & "PERIKSA KEMBALI VALIDASI STOK \n"
        'End If


        If msg_errErr <> "" Then
            Err_Save = 1
            Msg_err(msg_errErr, 0)
        Else
            Err_Save = 0
        End If
    End Function


    Sub Saveform()
        If Err_Save() = 0 Then
            'Call UPDATE_DATA_WARNA()
            If TxtNoTTK.Text = "" Then
                If Mid(lblAkses.Text, 1, 1) = "1" Then Call AddRecord() Else Call Msg_err("No Access", 1)
            ElseIf Mid(lblAkses.Text, 2, 1) = "1" Then
                Call editRecord()
                Call InsertStockIntoCabang()

            Else
                Call Msg_err("No Access", 1)
            End If
        End If
    End Sub

    '==============================================
    Sub AddRecord()
        Dim iloop As Byte
        Dim QuerySqlSts As Byte
        For iloop = 1 To 5
            Select Case iloop
                Case 0

                Case 1 : QuerySqlSts = CREATE_NO()
                Case 2 : QuerySqlSts = INSERT_STOCK()
                Case 3 : Call UPDATE_DATA_WARNA()
                Case 4 : Call Save_DO_Gesek_Rangka()
                Case 5
                    lblNoTTKTag.Text = TxtNoTTK.Text : LblTagLokasi.Text = TxtcdLokasi.Text
                    Call InsertStockIntoCabang()

                    'Case 3 : Call LoginDOING(MyDateStr, "03001", TxtNoTTK.Text & ":TTK.ADD", "")
            End Select
            If QuerySqlSts <> 1 Then
                '_StatusBar1_Panel1.Text = "ERROR NO.TTK " & TxtNoTTK.Text & "," & iloop
                Exit Sub
            End If
        Next
        '_StatusBar1_Panel1.Text = "OK NO.TTK " & TxtNoTTK.Text
    End Sub

    Sub editRecord()
        Dim Mfind As Byte
        Dim iloop As Byte
        Dim QuerySqlSts As Byte
        For iloop = 1 To 6
            Select Case iloop
                Case 1
                    Mfind = GETSTOCK_STATUS("STOCK_NoTTK ='" & TxtNoTTK.Text & "'", "")
                    If Mfind <> 0 Then QuerySqlSts = 1

                Case 2
                    If Mfind = 9 Then
                        QuerySqlSts = UPDATE_DATA_STOCK()  'Belum di transfer
                    End If
                Case 3
                    If Mfind = 8 Or Mfind = 9 Then
                        QuerySqlSts = UPDATE_DATA_STOCK_BOLEH() 'belu dan sudah ditransfer
                    End If
                Case 4
                    If LblTagChekBlokUnit1.Text = "1" And CheckBoxBlokUnit.Checked = False Then
                        Call UPDATE_DATA_STOCK_STATUS()
                        Call InsertStockIntoCabang()
                        LblTagChekBlokUnit1.Text = "0"
                    ElseIf LblTagChekBlokSales1.Text <> IIf(CheckBoxBlokSales.Checked = True, "1", "0") Then
                        Call UpdateDatabase_Tabel("UPDATE TRXN_STOCK SET STOCK_BlockPickup='" & IIf(CheckBoxBlokSales.Checked = True, "1", "0") & "' WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "112", 0)
                        Call UpdateDatabase_Tabel("UPDATE TRXN_STOCK SET STOCK_BlockPickup='" & IIf(CheckBoxBlokSales.Checked = True, "1", "0") & "' WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "128", 0)
                        LblTagChekBlokSales1.Text = IIf(CheckBoxBlokSales.Checked = True, "1", "0")
                    End If
                Case 5
                    If LblTagLokasi.Text <> TxtcdLokasi.Text And Mid(lblAkses.Text, 18, 1) = "1" Then
                        Call UpdateDatabase_Tabel("UPDATE TRXN_STOCK SET STOCK_CDLOKASI='" & TxtcdLokasi.Text & "' WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "112", 0)
                        Call UpdateDatabase_Tabel("UPDATE TRXN_STOCK SET STOCK_CDLOKASI='" & TxtcdLokasi.Text & "' WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "128", 0)
                    End If
                    LblTagLokasi.Text = TxtcdLokasi.Text
                Case 20 : Call UPDATE_DATA_WARNA()
            End Select
            If QuerySqlSts <> 1 And iloop = 1 Then Msg_err("Tidak bisa disimpan data tidak tersedia .....", 1)
            If QuerySqlSts <> 1 Then
                '_StatusBar1_Panel1.Text = "ERROR : NO.TTK " & TxtNoTTK.Text & iloop
                Exit Sub
            End If
        Next
        '_StatusBar1_Panel1.Text = "OK. NO.TTK " & TxtNoTTK.Text & " " & mxString & " YANG SUDAH BERUBAH ..."
    End Sub
    '009552
    Sub CANCELRecord()
        Dim iloop As Byte
        Dim QuerySqlSts As Byte
        QuerySqlSts = 1
        For iloop = 0 To 5
            Select Case iloop
                Case 1
                    If Mid(lblAkses.Text, 3, 1) <> "1" Then
                        QuerySqlSts = 0
                    Else
                        QuerySqlSts = 1
                    End If
                    If TxtAlasanBatal.Text = "" And QuerySqlSts = 1 Then
                        Call Msg_err("Alasan Batal TTK belum diinput", 0) : QuerySqlSts = 0
                    End If
                Case 2
                    If GETSTOCK_STATUS("STOCK_NoRangka='" & TxtNoRangka.Text & "'", "") <> 9 Then
                        Exit Sub
                    End If
                Case 3 : QuerySqlSts = INSERT_STOCKCANCEL()
                Case 4
                    'Case 9 : Call LoginDOING(MyDateStr, "03001", TxtNoTTK.Text & ":TTK.CNC", "")
            End Select
            If QuerySqlSts <> 1 Then
                '_StatusBar1_Panel1.Text = "ERRO NO.TTK " & TxtNoTTK.Text & iloop
                Exit Sub
            End If
        Next
        TxtNoRangka.Text = "" : lblNoRangkaTag.Text = ""
        TxtNoMesin.Text = "" : TxtNoKunci.Text = ""
        '_StatusBar1_Panel1.Text = "OK NO.TTK " & TxtNoTTK.Text
    End Sub

    Function InsertStockIntoCabang() As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim mSqlCommadstring As String = "SELECT *, " & _
                                         "(SELECT STOCKDO_KODEDLR FROM TRXN_STOCKDO WHERE STOCKDO_NORANGKA=STOCK_NORANGKA) as mfInputDOSUplier " & _
                                         "FROM TRXN_STOCK,DATA_LOKASI WHERE STOCK_CdLokasi=LOKASI_Kode AND STOCK_NORANGKA='" & TxtNoRangka.Text & "' AND STOCK_StsUpdate='N'"
        InsertStockIntoCabang = 0
        cnn = New OleDbConnection(strconn)

        Dim mLokasiDlr As String
        Dim mSave As Byte = 0
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            InsertStockIntoCabang = IIf(MyRecReadA.HasRows = True, 1, 0)
            If InsertStockIntoCabang = 1 Then
                If MyRecReadA.Read Then
                    If Len(nSr(MyRecReadA("STOCK_NORANGKA"))) > 10 Then
                        mLokasiDlr = nSr(MyRecReadA("LOKASI_KodeDLR"))

                        If nSr(MyRecReadA("mfInputDOSUplier")) = mLokasiDlr Or _
                           (nSr(MyRecReadA("mfInputDOSUplier")) = "" And DateDiff(DateInterval.Day, CDate("2018-09-01 00:00:00"), CDate(MyRecReadA("STOCK_TglTTK"))) >= 0) Then

                            If GetDataD_00NoFound01Found("SELECT STOCK_NORANGKA FROM TRXN_STOCK WHERE STOCK_NORANGKA='" & UCase(nSr(MyRecReadA("STOCK_NORANGKA"))) & "'", mLokasiDlr, 0) = 0 Then
                                mSqlCommadstring = "INSERT INTO TRXN_STOCK (" & _
                                            "STOCK_NoTTK,STOCK_StsUpdate,STOCK_TglUpdate,STOCK_TglTTK," & _
                                            "STOCK_NoRangka,STOCK_NoMesin,STOCK_CdType,STOCK_CdWarna,STOCK_CdSuplier," & _
                                            "STOCK_Versi,STOCK_Tahun,STOCK_NoKunci," & _
                                            "STOCK_Barter,STOCK_DoAuto,STOCK_TglAuto,STOCK_TglJT,STOCK_CdLokasi," & _
                                            "STOCK_Keterangan,STOCK_DPP,STOCK_PBM,STOCK_PPN," & _
                                            "STOCK_Var,STOCK_Surat,STOCK_Bunga,STOCK_PDisc,STOCK_BService,STOCK_Tglterima,STOCK_BlockPickup) "

                                mSqlCommadstring = mSqlCommadstring & "VALUES " & _
                                            "('" & nSr(MyRecReadA("STOCK_NoTTK")) & "','W',GETDATE()," & FieldTgl(MyRecReadA("STOCK_TglTTK")) & "," & _
                                            "'" & nSr(MyRecReadA("STOCK_NORANGKA")) & "','" & nSr(MyRecReadA("STOCK_NoMesin")) & "','" & nSr(MyRecReadA("STOCK_CdType")) & "'," & _
                                            "'" & nSr(MyRecReadA("STOCK_CdWarna")) & "','" & nSr(MyRecReadA("STOCK_CdSuplier")) & "','N','" & nSr(MyRecReadA("STOCK_Tahun")) & "'," & _
                                            "'" & nSr(MyRecReadA("STOCK_NoKunci")) & "','Y','',NULL,NULL,'" & nSr(MyRecReadA("STOCK_CdLokasi")) & "','" & _
                                            nSr(MyRecReadA("STOCK_Keterangan")) & "',0,0,0,0,0,0,0,NULL," & FieldTgl(MyRecReadA("STOCK_TglAuto")) & ",'" & nSr(MyRecReadA("STOCK_BlockPickup")) & "')"
                                If UpdateDatabase_Tabel(mSqlCommadstring, mLokasiDlr, 0) = 1 Then
                                    mSqlCommadstring = "UPDATE TRXN_STOCK SET STOCK_StsUpdate='T' WHERE STOCK_NORANGKA='" & nSr(MyRecReadA("STOCK_NORANGKA")) & "'"
                                    Call UpdateDatabase_Tabel(mSqlCommadstring, "", 0)
                                    mSave = 1
                                End If

                            Else
                                mSave = UpdateStokWarehouse(mLokasiDlr, nSr(MyRecReadA("STOCK_NORANGKA")), nSr(MyRecReadA("STOCK_CdLokasi")), FieldTgl(MyRecReadA("STOCK_TglAuto")))
                            End If
                        End If
                        If nSr(MyRecReadA("mfInputDOSUplier")) = "" And mSave = 1 Then
                            mSqlCommadstring = "INSERT INTO TRXN_STOCKDO (" & _
                                        "STOCKDO_NORANGKA,STOCKDO_NOMESIN,STOCKDO_KODEDLR,STOCKDO_NODOSPL,STOCKDO_TGDOSPL,STOCKDO_TGDOSPLI) VALUES " & _
                                        "('" & nSr(MyRecReadA("STOCK_NORANGKA")) & "','" & nSr(MyRecReadA("STOCK_NoMesin")) & "','" & mLokasiDlr & "','SISTEM','SISTEM',GETDATE())"
                            Call UpdateDatabase_Tabel(mSqlCommadstring, "", 0)
                        End If
                    End If
                    LblStatus.Text = "STATUS:" & nSr((MyRecReadA("STOCK_StsUpdate"))) & " / " & _
                                     "TANGGAL:" & nSr((MyRecReadA("STOCK_TglUpdate"))) & " / " & _
                                     "BERITA:" & nSr((MyRecReadA("STOCK_BERITA")))
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 1)
        End Try
    End Function

    Function UpdateStokWarehouse(ByVal mDlr As String, ByVal mRangka As String, ByVal mpSTOCK_CdLokasi As String, ByVal mpSTOCK_TglAuto As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mDlr).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT *, " & _
                                         "(SELECT SPK_NAMA1 FROM TRXN_SPK WHERE SPK_NORANGKA=STOCK_NORANGKA) as mSPK_NAMA1," & _
                                         "(SELECT SPK_KOTA FROM TRXN_SPK WHERE SPK_NORANGKA=STOCK_NORANGKA) as mSPK_KOTA," & _
                                         "(SELECT SPK_TGLDO FROM TRXN_SPK WHERE SPK_NORANGKA=STOCK_NORANGKA) as mSPK_TGLDO " & _
                                         "FROM TRXN_STOCK WHERE STOCK_NORANGKA='" & UCase(mRangka) & "'"
        UpdateStokWarehouse = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            UpdateStokWarehouse = IIf(MyRecReadB.HasRows = True, 1, 0)
            If UpdateStokWarehouse = 1 Then
                If MyRecReadB.Read Then
                    mSqlCommadstring = "UPDATE TRXN_STOCK SET STOCK_StsUpdate='T'," & _
                                "STOCK_NoMesin='" & nSr(MyRecReadB("STOCK_NoMesin")) & "'," & _
                                "STOCK_CdSuplier='" & nSr(MyRecReadB("STOCK_CdSuplier")) & "'," & _
                                "STOCK_Tahun='" & nSr(MyRecReadB("STOCK_Tahun")) & "'," & _
                                "STOCK_NoKunci='" & nSr(MyRecReadB("STOCK_NoKunci")) & "'," & _
                                "STOCK_DOSPKNama='" & TxtPetik(Left(nSr(MyRecReadB("mSPK_NAMA1")), 30)) & "'," & _
                                "STOCK_DOSPKKota='" & nSr(MyRecReadB("mSPK_KOTA")) & "'," & _
                                "STOCK_TglDoDealer=" & FieldTgl(MyRecReadB("mSPK_TGLDO")) & "," & _
                                "STOCK_NODEALER='" & mDlr & "'," & _
                                "STOCK_Berita='SDH ADA DI ADM TGL " & Format(MyRecReadB("STOCK_TglTTK"), "DD-MM-YYYY") & "' " & _
                                "WHERE STOCK_NORANGKA='" & mRangka & "'"
                    Call UpdateDatabase_Tabel(mSqlCommadstring, "", 0)

                    mSqlCommadstring = "UPDATE TRXN_STOCK SET " & _
                                       "STOCK_CDLOKASI='" & mpSTOCK_CdLokasi & "', " & _
                                       "STOCK_Tglterima=" & mpSTOCK_TglAuto & " " & _
                                       "WHERE STOCK_NORANGKA='" & mRangka & "'"
                    Call UpdateDatabase_Tabel(mSqlCommadstring, mDlr, 0)
                End If
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 1)
        End Try
    End Function



    Sub SaveformRepair()
        Dim kdasesoris As String
        Dim mError As String
        Dim mWebMail As String
        Dim MySTRsql1 As String
        If TxtNoTTK.Text = "" Then Exit Sub
        kdasesoris = ""





        If Trim(RadioButtonList1.Text) = "Sevice Repair" Then
            kdasesoris = "9007"
        ElseIf Trim(RadioButtonList1.Text) = "Body Repair" Then
            kdasesoris = "9008"
        ElseIf Trim(RadioButtonList1.Text) = "Service dan Bodyrepair" Then
            kdasesoris = "9009"
        End If
        mError = ""
        If DropDownList1.Text = "" Then
            mError = mError & ("BENGKEL TUJUAN BELUM DIISI") & Chr(13)
        ElseIf TxtKetWO.Text = "" And RadioButtonList2.Text = "Bukan Beban Kantor" Then
            mError = mError & ("KETERANGAN BEBAN LAIN LAIN BELUM DIISI") & Chr(13)
        ElseIf TxtRepairRemark.Text = "" Then
            mError = mError & ("RINCIAN BELUM DIISI") & Chr(13)
        ElseIf kdasesoris = "" Then
            mError = mError & ("JENIS PEKERAANBELUM DIISI") & Chr(13)
        ElseIf TxtKetWO.Text = "" And RadioButtonList2.Text = "Beban Kantor" Then
            Msg_err("ISI KETERANGAN WO MENJADI BEBAN KANTOR", 1)
        End If
        mWebMail = ""
        lblStRepair.Text = ""

        MySTRsql1 = "DELETE FROM TRXN_STOCKAREPAIR WHERE ASSREPAIR_NORANGKA='" & TxtNoRangka.Text & "' AND (ASSREPAIR_TGLWO IS NULL)"
        Call UpdateDatabase_Tabel(MySTRsql1, "", 0)

        mWebMail = GetRepairMail() 'Functoin

        If InStr(lblStRepair.Text, "SETUJU") <> 0 Then
            mError = mError & ("SUDAH DISETUJUI OLEH SM TIDAK BISA DIUPDATE")
        ElseIf InStr(lblStRepair.Text, "EMAIL") <> 0 Then
            mError = mError & ("SUDAH DI EMAIL TIDAK BISA DIUPDATE")
        End If
        If mError <> "" Then
            Msg_err(mError, 1) : Exit Sub
        End If


        MySTRsql1 = "SELECT * FROM TRXN_STOCKAREPAIR WHERE ASSREPAIR_NORANGKA='" & TxtNoRangka.Text & "' AND ASSREPAIR_TGLWO IS NULL"
        If GetDataD_00NoFound01Found(MySTRsql1, "", 0) <> 1 Then
            MySTRsql1 = "INSERT INTO TRXN_STOCKAREPAIR(ASSREPAIR_NORANGKA,ASSREPAIR_TGLINPUT) VALUES ('" & TxtNoRangka.Text & "',GETDATE())"
            Call UpdateDatabase_Tabel(MySTRsql1, "", 0)
            lblTglMohonRepair.Text = Now()
        End If


        If RadioButtonList2.Text = "Beban Kantor" Then
            TxtKetWO.Text = "BEBAN KANTOR"
        End If
        MySTRsql1 = "UPDATE TRXN_STOCKAREPAIR SET " & _
                        "ASSREPAIR_KODEDLR='" & Left(DropDownList1.Text, 4) & "'," & _
                        "ASSREPAIR_KETERANGAN='" & TxtKetWO.Text & "'," & _
                        "ASSREPAIR_KDASS='" & kdasesoris & "'," & _
                        "ASSREPAIR_HARGA='" & nLg(TxtHarga.Text) & "'," & _
                        "ASSREPAIR_RINCIAN='" & TxtRepairRemark.Text & "' " & _
                        "WHERE ASSREPAIR_NORANGKA='" & TxtNoRangka.Text & "' AND ASSREPAIR_TGLWO IS NULL"
        Call UpdateDatabase_Tabel(MySTRsql1, "", 0)

        If mWebMail <> "" Then
            If ChkBRepair.Checked = True Then
                mWebMail = ""
            Else
                Call Msg_err("SUDAH PERNAH MENGAJUKAN PERMOHONAN JIKA AKAN DIAJUKAN KEMBALI/DIAJUKAN ULANG CHECK LIST DI PENGAJUAN ULANG", 1)
            End If
        End If
        If mWebMail = "" Then
            MySTRsql1 = "UPDATE TRXN_STOCKAREPAIR SET ASSREPAIR_TGLEMAIL=GETDATE() " & _
                        "WHERE ASSREPAIR_NORANGKA='" & TxtNoRangka.Text & "' AND ASSREPAIR_TGLEMAIL IS NULL"
            Call UpdateDatabase_Tabel(MySTRsql1, "", 0)
        End If
    End Sub

    Function GetRepairMail() As String
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_STOCKAREPAIR WHERE ASSREPAIR_NORANGKA='" & TxtNoRangka.Text & "' AND (ASSREPAIR_TGLWO IS NULL)"

        Call Msg_err("", 0)
        GetRepairMail = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                lblStRepair.Text = IIf(nSr((MyRecReadA("ASSREPAIR_TGLEMAIL"))) <> "", "TANGGAL EMAIL " & nSr((MyRecReadA("ASSREPAIR_TGLEMAIL"))) & "  ", "") & _
                                   IIf(nSr((MyRecReadA("ASSREPAIR_TGLSETUJU"))) <> "", "TANGGAL SETUJU " & nSr((MyRecReadA("ASSREPAIR_TGLSETUJU"))) & "  ", "")
                GetRepairMail = nSr(MyRecReadA("ASSREPAIR_TGLEMAIL"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Sub isidataperbaikan()

        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_STOCKAREPAIR WHERE ASSREPAIR_NORANGKA='" & TxtNoRangka.Text & "' AND (ASSREPAIR_TGLWO IS NULL)"

        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                lblTglMohonRepair.Text = nSr((MyRecReadA("ASSREPAIR_TGLINPUT")))

                If UCase(nSr((MyRecReadA("ASSREPAIR_KDASS")))) = "9007" Then
                    RadioButtonList1.Text = "Sevice Repair"
                ElseIf UCase(nSr((MyRecReadA("ASSREPAIR_KDASS")))) = "9008" Then
                    RadioButtonList1.Text = "Body Repair"
                ElseIf UCase(nSr((MyRecReadA("ASSREPAIR_KDASS")))) = "9009" Then
                    RadioButtonList1.Text = "Service dan Bodyrepair"
                End If
                TxtRepairRemark.Text = nSr((MyRecReadA("ASSREPAIR_RINCIAN")))
                TxtKetWO.Text = nSr((MyRecReadA("ASSREPAIR_KETERANGAN")))
                TxtHarga.Text = fLg((MyRecReadA("ASSREPAIR_HARGA")))

                If TxtKetWO.Text = "BEBAN KANTOR" Then
                    RadioButtonList2.Text = "Beban Kantor"            'on 
                Else
                    RadioButtonList2.Text = "Bukan Beban Kantor"      'of  
                End If


                If nSr((MyRecReadA("ASSREPAIR_KODEDLR"))) = "U902" Then
                    DropDownList1.Text = "U902-SERVICE & BODYREPAIR PASAR MINGGU"
                Else
                    DropDownList1.Text = "U903-SERVICE & BODYREPAIR PURI KEMBANGAN"
                End If

                lblStRepair.Text = IIf(nSr((MyRecReadA("ASSREPAIR_TGLEMAIL"))) <> "", "TANGGAL EMAIL " & nSr((MyRecReadA("ASSREPAIR_TGLEMAIL"))) & "  ", "") & _
                                   IIf(nSr((MyRecReadA("ASSREPAIR_TGLSETUJU"))) <> "", "TANGGAL SETUJU " & nSr((MyRecReadA("ASSREPAIR_TGLSETUJU"))) & "  ", "")
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try


    End Sub


    '==============================================
    Sub ClearFrom()
        'If TxtNoTTK.Text <> "" Then Call ClearLockRecord(TxtNoTTK.Text, "03001")
        [Calendar1].Visible = False
        [Calendar2].Visible = False
        [Calendar3].Visible = False
        [Calendar4].Visible = False
        [Calendar5].Visible = False
        [Calendar6].Visible = False
        [Calendar7].Visible = False
        [Calendar8].Visible = False
        [Calendar10].Visible = False
        [Calendar12].Visible = False
        [Calendar13].Visible = False
        [Calendar14].Visible = False
        [Calendar15].Visible = False
        [Calendar16].Visible = False


        MultiViewTabelStok.ActiveViewIndex = -1
        MultiViewStockImora.ActiveViewIndex = -1
        MultiViewType.ActiveViewIndex = -1
        MultiViewWarna.ActiveViewIndex = -1
        MultiViewSuplier.ActiveViewIndex = -1
        MultiViewLokasi.ActiveViewIndex = -1
        LblTagLokasi0.Text = ""
        TxtNoTTK.Text = "" : lblNoTTKTag.Text = ""
        lblTGLTTK.Text = Now()
        NoBTL.Text = "" : DTglTemp.Text = ""

        TxtNoRangka.Text = "" : lblNoRangkaTag.Text = ""
        TxtNoMesin.Text = ""

        TxtCdType.Text = "" : lblCdTypeTag.Text = "" : NamaType.Text = "" : lblMugenImoraType.Text = "" : NamaTypeImora.Text = "" : KodeTypeImora.Text = ""
        TxtCdWarna.Text = "" : lblCdWarnaTag.Text = "" : NamaWarna.Text = "" : KodeWarnaImoraMugen.Text = "" : KodeWarnaImora.Text = "" : NamaWarnaImora.Text = ""
        TxtNoKunci.Text = ""
        TxtTahun.Text = "" : TxtDtTglDoIm.Text = ""
        TxtDtglSuratJln.Text = "" : TxtNoDO.Text = ""
        TxtCdSuplier.Text = "" : lblCdSuplierTag.Text = "" : nmSuplier.Text = "" : TxtDTglDO.Text = ""
        TxtcdLokasi.Text = "" : lblcdLokasiTag.Text = "" : NamaLokasi.Text = "" : Kodedealer.Text = "" : KodedealerTag.Text = ""
        LblTagLokasi.Text = ""
        LblCrsSellMugen.Text = ""
        TxtKeterangan.Text = ""
        TxtAlasanBatal.Text = ""
        LblStatus.Text = ""

        TxtCdType.Enabled = True : TxtCdWarna.Enabled = True : TxtCdSuplier.Enabled = True : TxtTahun.Enabled = True

        LblPeriksaUser.Text = "" : LblPeriksaTgl.Text = ""

        TxtNama.Text = ""
        TxtAlamat.Text = ""
        TxtKota.Text = ""
        TxtNoHP.Text = ""
        TxtPhone.Text = ""

        TxtBerita.Text = ""
        lblTglAdmin.Text = "" : LblUsrAdmin.Text = ""
        LblCetakDOTgl.Text = "" : LblCetakDOUsr.Text = ""
        DropDownList2.SelectedIndex = -1 : lblNmSupir.Text = ""

        TxtAlasanRubahTglKirim.Text = "" : TxtAlasanRubahTglKirim.Text = ""
        TxttglPDI.Text = "" : TxttglPDINote.Text = ""

        DropDownListJnsKirim.SelectedIndex = -1
        LblKirimJenis.Text = "" : LblKirimNo.Text = "" : LblKirimInputDanKirim.Text = ""

        TxttglKeluar.Text = "" : TxttglKeluarNote.Text = "" : TxtKirimOngkos.Text = ""
        TxtKirimDealer.Text = ""

        LblTglInputHapusMohon.Text = "" : TxtTglBatalNote.Text = ""

        TxttglTerima.Text = "" : TxttglTerimaNote.Text = "" : lbltglterimai.Text = ""

        TxttglCatatan.Text = "" : TxttglCatatanDsc.Text = ""

        TxtTglSecurity.Text = "" : TxtTglSecurityNote.Text = ""
        TxttglCetakDO.Text = ""
        TxttglKeluar.Text = "" : LblAksesorDlr.Text = ""
        TxtTglBukuSvc.Text = "" : TxtBukuSvc.Text = ""
        TxtPDISPK.Text = ""
        TxtPDITransmisiNote.Text = ""
        TxtPDISupirTgl.Text = "" : TxtPDISupirNot.Text = ""
        TxtPDIPlatMJSNot.Text = ""
        TxtPDIKetTgl.Text = "" : TxtPDIKetera.Text = ""
        TxtPDILakbanTgl.Text = "" : TxtPDILakbanNot.Text = ""
        TxtPDIPoldaTgl.Text = "" : TxtPDIPoldaNot.Text = ""
        TxtNoSTCK.Text = ""

        lblnospkDO.Text = "" : LblCdBranch.Text = ""
        LblSalesman.Text = "" : lbllease.Text = ""

        CheckBoxBlokSales.Checked = False : LblTagChekBlokSales1.Text = ""
        CheckBoxBlokUnit.Checked = False : LblTagChekBlokUnit1.Text = ""

        Kodedealer.Text = ""
        NoBTL.Visible = False

        Call clearstck()


        '_StatusBar1_Panel1.Text = ""
        'ScreenDelivery.Enabled = False
        'If Mid(MyAccess, 13, 1) = "1" Then
        'ScreenDelivery.Enabled = True
        'End If
        '============

        lblTglMohonRepair.Text = ""
        'RadioButton1.Checked = True
        TxtKetWO.Text = ""
        TxtRepairRemark.Text = ""
        TxtHarga.Text = 0
        lblStRepair.Text = ""
        Call clearBBM()
        'BtnPrintBBMR.Visible = True : BtnPrintBBM.Visible = False
        'BtnPrintBBMDR.Visible = True : BtnPrintBBMD.Visible = False
        Call clearspj()
        'btnPrintSPJR.Visible = True : btnPrintSPJ.Visible = False

        Call clearDataSTCK()
        'BtnPrintBBDR.Visible = True : BtnPrintBBMD.Visible = False

        Call clearDataPrintPDI()
        'btnPrintPDIR.Visible = True : btnPrintPDI.Visible = False

        insertTabelBBM(0, "", "", "", "", "", "", "", "", "")
        TxtNoVcrBBM.Text = "" : LblBBMTg.Text = "" : DDListBBMTp.Text = "CUSTOMER" : LblBBMJm.Text = "" : TxtBBMCt.Text = ""
        LblKirimNo.Text = "" : LblKirimInputDanKirim.Text = "" : lblNmSupir.Text = ""
    End Sub
    Sub clearstck()
        TxtSTCKNO.Text = ""
        TxtSTCKNOTag.Text = ""
        TxtSTCKNopol.Text = ""
        LblSTCKNRGK.Text = ""
        LblSTCKINPT.Text = ""
        TxtSTCKSEND.Text = ""
        LblSTCKStatus.Text = ""
        TxtSTCKQTY.Text = ""
        TxtSTCKNOTE.Text = ""
        Label24.Text = ""
    End Sub
    Sub clearBBM()

        lblCetakBBMCompany.Text = ""
        lblCetakBBMCompany1.Text = ""
        lblCetakBBMCompany2.Text = ""
        lblCetakBBMIsiColA2.Text = ""
        lblCetakBBMIsiColA4.Text = ""
        lblCetakBBMIsiColB2.Text = ""
        lblCetakBBMIsiColC2.Text = ""
        lblCetakBBMIsiColC4.Text = ""
        lblCetakBBMIsiColD2.Text = ""
        lblCetakBBMIsiColD4.Text = ""
        lblCetakBBMIsiColE1.Text = ""
        lblCetakBBMIsiColf1.Text = ""

    End Sub
    Sub clearspj()
        LblSPJ1NOSPK.Text = "" : LblSPJ1NODO.Text = ""
        LblSPJ2RGK.Text = "" : LblSPJ2SALES.Text = ""
        LblSPJ3TIPE.Text = "" : LblSPJ3TGLM.Text = ""
        LblSPJ4WARNA.Text = "" : LblSPJ4TGLK.Text = ""
        LblSPJ5NAMA1.Text = "" : LblSPJ5NAMA2.Text = ""
        LblSPJ6ALAMAT11.Text = "" : LblSPJ6ALAMAT12.Text = ""
        LblSPJ7KOTA1.Text = "" : LblSPJ7KOTA2.Text = ""
        Label233.Text = ""
        LblSPJ12TGLSURAT.Text = ""
    End Sub
    Sub clearspjNoCust()
        LblSPJNS1NoRangka.Text = "" : LblSPJNS1NoMesin.Text = ""
        LblSPJNS2Tipe.Text = "" : LblSPJNS2Supir.Text = ""
        LblSPJNS3Warna.Text = "" : LblSPJNS3Kirim.Text = ""
        LblSPJNS4Catatan.Text = ""
        LblSPJNSTGLSURAT.Text = ""
    End Sub

    Sub clearDataSTCK()
        Label120.Text = ""
        Label121.Text = ""
        Label122.Text = ""
        lblSTCK01SPK.Text = ""
        lblSTCK02RGK.Text = ""
        lblSTCK03TIPE.Text = ""
        lblSTCK04TGLK.Text = ""
        lblSTCK05TGLI.Text = ""
        lblSTCK06ALAMAT.Text = ""
        lblSTCK07TGLSURAT.Text = ""
    End Sub
    Sub clearDataPrintPDI()
        Label165.Text = "" : Label166.Text = "" : Label167.Text = ""
        LbPDISPK.Text = "" : LbPDIDO.Text = "" : LbPDIRGK.Text = "" : LbPDISALES.Text = "" : LbPDITIPE.Text = ""
        LbPDITGLM.Text = "" : LbPDIWARNA.Text = "" : LbPDITGLK.Text = ""

        Label180.Text = ""
    End Sub



    Function CREATE_NO() As Byte
        CREATE_NO = 1
        TxtNoTTK.Text = AddNomor("VOUCHER_TTKR", 7)
        If TxtNoTTK.Text = "" Then
            CREATE_NO = 0 : Call Msg_err("No voucher VOUCHER_TTKR error", 1)
        End If
    End Function

    Function AddNomor(ByVal mField As String, ByVal mPanjang As Byte) As String
        Dim mNomor As String
        Dim mIsiField As String
        AddNomor = ""
        Try

            mNomor = ""
            AddNomor = ""
            mIsiField = GetDataD_IsiField("SELECT " & mField & " as IsiField FROM DATA_VOUCHER", "", 0)
            If mIsiField = "" Then
                If UpdateDatabase_Tabel("INSERT INTO DATA_VOUCHER(" & mField & ") VALUES ('" & (Mid("0000000000", 1, mPanjang - 2) & "1W") & "')", "", 1) = 1 Then
                    AddNomor = Mid("0000000000", 1, mPanjang - 2) & "1W"
                End If
            Else
                Select Case UCase(mField)
                    Case "VOUCHER_TTKR" 'NO TTK
                        If (mIsiField = Mid("9999999999", 1, mPanjang - 1)) Or nSr(mIsiField) = "" Then
                            mNomor = (Mid("0000000000", 1, mPanjang - 2) & "1W")
                        Else
                            mNomor = (Mid("0000000000", 1, mPanjang - 1 - Len(Trim(Str(Val(mIsiField) + 1)))) & Val(mIsiField) + 1) & "W"
                        End If
                    Case "VOUCHER_BTLT" 'Nomor urut batal TTK
                        If nSr(mIsiField) = "" Or (nSr(mIsiField) = Mid("99999999999", 1, mPanjang)) Then
                            mNomor = (Mid("0000000000", 1, mPanjang - 1) & "1")
                        Else
                            mNomor = (Mid("0000000000", 1, mPanjang - Len(Trim(Str(Val(mIsiField) + 1)))) & Val(mIsiField) + 1)
                        End If
                End Select
                If UpdateDatabase_Tabel("UPDATE DATA_VOUCHER SET " & mField & "='" & mNomor & "'", "", 0) = 1 Then
                    AddNomor = mNomor
                End If
            End If

        Catch ex As Exception
            Msg_err(ex.Message, 0)
        End Try
    End Function

    Function TXTSQL_INSERT_STOCK(ByVal mNoTTK As String) As String
        Dim mstatus As String = ""

        If CheckBoxBlokUnit.Checked = True Then
            mstatus = "P"
        Else
            mstatus = "N"
        End If


        TxtNoRangka.Text = UCase(Trim(TxtNoRangka.Text))
        TXTSQL_INSERT_STOCK = "INSERT INTO TRXN_STOCK(" & _
                   "STOCK_NoTTK,STOCK_TglTTK,STOCK_StsUpdate,STOCK_TglUpdate," & _
                   "STOCK_NoRangka,STOCK_NoMesin,STOCK_NoKunci,STOCK_CdType,STOCK_CdWarna,STOCK_CdSuplier," & _
                   "STOCK_Tahun,STOCK_DoAuto,STOCK_TglAuto,STOCK_TglSJ,STOCK_CdLokasi,STOCK_Keterangan,STOCK_Alasan," & _
                   "STOCK_DoDealer,STOCK_TglDoDealer,STOCK_TglCtkDoDealer,STOCK_TglKirim,STOCK_TglTerima,STOCK_TglDOImoraHpm,STOCK_USER,STOCK_BlockPickup) VALUES "
        TXTSQL_INSERT_STOCK = TXTSQL_INSERT_STOCK & " ('" & TxtNoTTK.Text & "',GETDATE(),'" & mstatus & "',GETDATE(),'" & _
                   TxtNoRangka.Text & "','" & TxtNoMesin.Text & "','" & TxtNoKunci.Text & "','" & TxtCdType.Text & "','" & TxtCdWarna.Text & "','" & TxtCdSuplier.Text & "','" & _
                   TxtTahun.Text & "','" & TxtNoDO.Text & "'," & FieldTgl((TxtDTglDO.Text)) & "," & FieldTgl((TxtDtglSuratJln.Text)) & ",'" & TxtcdLokasi.Text & "','" & TxtPetik((TxtKeterangan.Text)) & "',''," & _
                   "'',NULL,NULL,NULL,NULL," & IIf(TxtDtTglDoIm.Text = "", FieldTgl((TxtDtTglDoIm.Text)), "NULL") & ",'" & LblUserName.Text & "','" & IIf(CheckBoxBlokSales.Checked = True Or CheckBoxBlokUnit.Checked = True, "1", "0") & "')"
    End Function

    Function INSERT_STOCK() As Byte
        Dim Mytxtsql1 As String = TXTSQL_INSERT_STOCK(TxtNoTTK.Text)
        INSERT_STOCK = UpdateDatabase_Tabel(Mytxtsql1, "", 0)
        If INSERT_STOCK <> 1 Then Call Msg_err("TIDAK BERHASIL DI SIMPAN", 1)
        lblTGLTTK.Text = Now()
        KodedealerTag.Text = Kodedealer.Text
    End Function

    Function UPDATE_DATA_STOCK_STATUS() As Byte
        Dim Mytxtsql As String = "UPDATE TRXN_STOCK SET " & _
                   "STOCK_BlockPickup='0'," & _
                   "STOCK_CdLokasi='" & TxtcdLokasi.Text & "' " & _
                   "WHERE STOCK_NoTTK='" & TxtNoTTK.Text & "'"
        UPDATE_DATA_STOCK_STATUS = UpdateDatabase_Tabel(Mytxtsql, "", 2)
    End Function


    Function UPDATE_DATA_STOCK() As Byte
        Dim Mytxtsql As String = "UPDATE TRXN_STOCK SET " & _
                   "STOCK_NoRangka='" & TxtNoRangka.Text & "'," & _
                   "STOCK_NoMesin='" & TxtPetik((TxtNoMesin.Text)) & "'," & _
                   "STOCK_CdType='" & TxtCdType.Text & "'," & _
                   "STOCK_CdWarna='" & TxtCdWarna.Text & "'," & _
                   "STOCK_CdSuplier='" & TxtCdSuplier.Text & "'," & _
                   "STOCK_Tahun='" & TxtTahun.Text & "'," & _
                   "STOCK_BlockPickup='" & IIf(CheckBoxBlokSales.Checked = True Or CheckBoxBlokUnit.Checked = True, "1", "0") & "'," & _
                   "STOCK_CdLokasi='" & TxtcdLokasi.Text & "' " & _
                   "WHERE STOCK_NoTTK='" & TxtNoTTK.Text & "'"
        UPDATE_DATA_STOCK = UpdateDatabase_Tabel(Mytxtsql, "", 2)
        lblNoRangkaTag.Text = TxtNoRangka.Text
    End Function

    Function UPDATE_DATA_STOCK_BOLEH() As Byte
        Dim Mytxtsql As String = "UPDATE TRXN_STOCK SET " & _
                   "STOCK_Cdlokasi='" & TxtcdLokasi.Text & "'," & _
                   "STOCK_NoKunci='" & TxtPetik((TxtNoKunci.Text)) & "'," & _
                   "STOCK_DoAuto='" & TxtNoDO.Text & "'," & _
                   "STOCK_TglAuto=" & FieldTgl((TxtDTglDO.Text)) & "," & _
                   "STOCK_TglSJ=" & FieldTgl((TxtDtglSuratJln.Text)) & "," & _
                   "STOCK_TglDOImoraHpm=" & IIf(TxtDtTglDoIm.Text = "", FieldTgl((TxtDtTglDoIm.Text)), "NULL") & "," & _
                   "STOCK_Keterangan='" & TxtPetik((TxtKeterangan.Text)) & "' " & _
                   "WHERE STOCK_NoTTK='" & TxtNoTTK.Text & "'"
        UPDATE_DATA_STOCK_BOLEH = UpdateDatabase_Tabel(Mytxtsql, "", 2)

        Mytxtsql = "UPDATE TRXN_STOCK SET " & _
                   "STOCK_StsUpdate='N'," & _
                   "STOCK_Keterangan='" & TxtPetik((TxtKeterangan.Text)) & "' " & _
                   "WHERE STOCK_NoTTK='" & TxtNoTTK.Text & "'"
        'UPDATE_DATA_STOCK_BOLEH = ExecuteSQL(Mytxtsql, 21, "", 2)
    End Function


    Function INSERT_STOCKCANCEL() As Byte
        INSERT_STOCKCANCEL = simpanALsan(TxtNoRangka.Text, "BR", "ALASAN BATAL STOCK ", TxtAlasanBatal.Text, " DLR:" & LblCdBranch.Text & " Typ:" & TxtCdType.Text & " Wrn:" & TxtCdWarna.Text & " TTK:" & TxtNoTTK.Text)
        If INSERT_STOCKCANCEL = 1 Then
            Dim Mytxtsql As String = "DELETE FROM TRXN_STOCK WHERE STOCK_NoTTK='" & TxtNoTTK.Text & "'"
            INSERT_STOCKCANCEL = UpdateDatabase_Tabel(Mytxtsql, "", 2)
        Else
            Call Msg_err("STOCKCANCEL GAGAL ", 1)
        End If
    End Function

    Function UPDATE_DATA_WARNA() As Byte
        UPDATE_DATA_WARNA = 0
        If KodeWarnaImora.Text = "" Then
            Exit Function
        ElseIf KodeWarnaImoraMugen.Text <> "" Then
            Exit Function
        End If

        Dim Mytxtsql As String = "UPDATE DATA_WARNA SET WARNA_KODEHPM='" & KodeWarnaImora.Text & "' " & _
                   "WHERE WARNA_Kode='" & TxtCdWarna.Text & "'"
        UPDATE_DATA_WARNA = UpdateDatabase_Tabel(Mytxtsql, "", 2)
        lblNoRangkaTag.Text = TxtNoRangka.Text
    End Function

    Function Save_DO_Gesek_Rangka() As Byte
        Dim Mytxtsql As String

        Dim mnama As String = GetDataD_IsiField("SELECT GESEK_SPKNAMA as IsiField FROM TRXN_STOCKGESEK WHERE GESEK_NORANGKA='" & Trim(TxtNoRangka.Text) & "'", "", 0)
        Dim mKota As String = GetDataD_IsiField("SELECT GESEK_SPKKOTA as IsiField FROM TRXN_STOCKGESEK WHERE GESEK_NORANGKA='" & Trim(TxtNoRangka.Text) & "'", "", 0)
        Dim mDelr As String = GetDataD_IsiField("SELECT GESEK_DEALER as IsiField FROM TRXN_STOCKGESEK WHERE GESEK_NORANGKA='" & Trim(TxtNoRangka.Text) & "'", "", 0)
        Dim mTgDO As String = GetDataD_IsiField("SELECT GESEK_TGLDO as IsiField FROM TRXN_STOCKGESEK WHERE GESEK_NORANGKA='" & Trim(TxtNoRangka.Text) & "'", "", 0)

        If mnama <> "" Then
            Msg_err("SUDAH ADA DO DARI DEALER SEGERALAH MELAKUKAN GESEK NO RANGKA DATA DO :  \n " & _
                   "NAMA   : " & mnama & Chr(13) & _
                   "KOTA   : " & mKota & Chr(13) & _
                   "DEALER : " & mDelr & Chr(13) & _
                   "TGL DO : " & mTgDO & Chr(13), 1)
            Mytxtsql = "UPDATE TRXN_STOCK SET " & _
                       "STOCK_DOSPKNAMA='" & TxtPetik(mnama) & "'," & _
                       "STOCK_DOSPKKOTA='" & TxtPetik(mKota) & "'," & _
                       "STOCK_TGLDODEALER=" & FieldTgl(mTgDO) & "," & _
                       "STOCK_NODEALER='" & mDelr & "' " & _
                       "WHERE STOCK_NORANGKA='" & Trim(TxtNoRangka.Text) & "'"
            If UpdateDatabase_Tabel(Mytxtsql, "", 0) = 1 Then
                Mytxtsql = "DELETE FROM TRXN_STOCKGESEK WHERE GESEK_NORANGKA='" & Trim(TxtNoRangka.Text) & "'"
                Call UpdateDatabase_Tabel(Mytxtsql, "", 1)
            End If
        End If
    End Function










    Function GETSTOCK_STATUS(ByVal mSearchTxt As String, ByVal mTitipanTxt As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT *, " & _
                              "(SELECT TYPE_Nama FROM DATA_TYPE WHERE TYPE_Type = STOCK_CdType) AS NamaType, " & _
                              "(SELECT TYPE_IMORA FROM DATA_TYPE WHERE TYPE_Type = STOCK_CdType) AS KodeTypeImora, " & _
                              "(SELECT TYPE_CdRangka FROM DATA_TYPE WHERE TYPE_Type = STOCK_CdType) AS NoCdRangka, " & _
                              "(SELECT WARNA_Int FROM DATA_WARNA WHERE WARNA_Kode = STOCK_CdWarna) AS NamaWarna, " & _
                              "(SELECT WARNA_KODEHPM FROM DATA_WARNA WHERE WARNA_Kode = STOCK_CdWarna) AS NamaWarnaHPM, " & _
                              "(SELECT SUPLIER_Nama FROM DATA_SUPLIER WHERE SUPLIER_Kode = STOCK_CdSuplier) AS NamaSuplier, " & _
                              "(SELECT LOKASI_Nama FROM DATA_LOKASI WHERE LOKASI_Kode = STOCK_CdLokasi) AS NamaLokasi, " & _
                              "(SELECT LOKASI_KODEDLR FROM DATA_LOKASI WHERE LOKASI_Kode = STOCK_CdLokasi) AS Kodedealer, " & _
                              "(SELECT LOKASI_IPServer FROM DATA_LOKASI WHERE LOKASI_Kode = STOCK_CdLokasi) AS NamaServer " & _
                              "FROM TRXN_STOCK LEFT OUTER JOIN TRXN_STOCKKKIRIM ON TRXN_STOCK.STOCK_NoRangka = TRXN_STOCKKKIRIM.STOCKK_NORANGKA " & IIf(Trim(mSearchTxt) <> "", " WHERE " & mSearchTxt, " ") & " ORDER BY STOCK_NoTTK"
        GETSTOCK_STATUS = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GETSTOCK_STATUS = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                LblStatus.Text = "STATUS:" & nSr((MyRecReadA("STOCK_StsUpdate"))) & " / " & _
                                 "TANGGAL:" & nSr((MyRecReadA("STOCK_TglUpdate"))) & " / " & _
                                 "BERITA:" & nSr((MyRecReadA("STOCK_BERITA")))
                If nSr(MyRecReadA("STOCK_StsUpdate")) = "T" Then
                    GETSTOCK_STATUS = 8 'Sudah ditransfer
                    If GetDataD_00NoFound01Found("SELECT STOCK_NORANGKA FROM TRXN_STOCK STOCK_NORANGKA " & nSr((MyRecReadA("STOCK_NORANGKA"))) & "'", Kodedealer.Text, 0) <> 1 Then
                        GETSTOCK_STATUS = 9  'Sudah dihapus
                    End If
                Else
                    GETSTOCK_STATUS = 9  'Belum ditransfer
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 1)
        End Try
    End Function

    Function Download_From_Warehouse_Stok_dan_TerimaUnitCustomer(ByVal mNoRangka As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mLokasi As String = ""
        Dim mSqlCommadstring As String = _
                    "SELECT *," & _
                    "(SELECT STOCKDO_KODEDLR FROM TRXN_STOCKDO WHERE STOCKDO_NORANGKA=STOCK_NORANGKA) as mfInputDOSUplier " & _
                    "FROM TRXN_STOCK,DATA_LOKASI WHERE STOCK_CdLokasi=LOKASI_Kode AND STOCK_NORANGKA='" & mNoRangka & "' AND STOCK_StsUpdate='N'"


        Download_From_Warehouse_Stok_dan_TerimaUnitCustomer = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            Download_From_Warehouse_Stok_dan_TerimaUnitCustomer = IIf(MyRecReadA.HasRows = True, 1, 0)
            If Download_From_Warehouse_Stok_dan_TerimaUnitCustomer = 1 Then
                Dim mSave As Integer = 0
                While MyRecReadA.Read()
                    mLokasi = UCase(nSr(MyRecReadA("LOKASI_KodeDLR")))
                    mSave = 0
                    mSqlCommadstring = "SELECT *," & _
                                "(SELECT SPK_NAMA1 FROM TRXN_SPK WHERE SPK_NORANGKA=STOCK_NORANGKA) as mSPK_NAMA1," & _
                                "(SELECT SPK_KOTA FROM TRXN_SPK WHERE SPK_NORANGKA=STOCK_NORANGKA) as mSPK_KOTA," & _
                                "(SELECT SPK_TGLDO FROM TRXN_SPK WHERE SPK_NORANGKA=STOCK_NORANGKA) as mSPK_TGLDO " & _
                                "FROM TRXN_STOCK WHERE STOCK_NORANGKA='" & UCase(nSr(MyRecReadA("STOCK_NORANGKA"))) & "'"
                    If GetDataD_00NoFound01Found(mSqlCommadstring, mLokasi, 0) <> 1 Then
                        If nSr(MyRecReadA("mfInputDOSUplier")) = mLokasi Or _
                           (nSr(MyRecReadA("mfInputDOSUplier")) = "" And DateDiff(DateInterval.Day, CDate("2018-09-01 00:00:00"), CDate(MyRecReadA("STOCK_TglTTK"))) >= 0) Then
                            mSqlCommadstring = "INSERT INTO TRXN_STOCK (" & _
                                        "STOCK_NoTTK,STOCK_StsUpdate,STOCK_TglUpdate,STOCK_TglTTK," & _
                                        "STOCK_NoRangka,STOCK_NoMesin,STOCK_CdType,STOCK_CdWarna,STOCK_CdSuplier," & _
                                        "STOCK_Versi,STOCK_Tahun,STOCK_NoKunci," & _
                                        "STOCK_Barter,STOCK_DoAuto,STOCK_TglAuto,STOCK_TglJT,STOCK_CdLokasi," & _
                                        "STOCK_Keterangan,STOCK_DPP,STOCK_PBM,STOCK_PPN," & _
                                        "STOCK_Var,STOCK_Surat,STOCK_Bunga,STOCK_PDisc,STOCK_BService,STOCK_Tglterima) "

                            mSqlCommadstring = mSqlCommadstring & "VALUES " & _
                                        "('" & nSr(MyRecReadA("STOCK_NoTTK")) & "','W',GETDATE()," & FieldTgl(MyRecReadA("STOCK_TglTTK")) & ",'" & _
                                        MyRecReadA("STOCK_NoRangka") & "','" & TxtPetik((MyRecReadA("STOCK_NoMesin"))) & "','" & MyRecReadA("STOCK_CdType") & "','" & MyRecReadA("STOCK_CdWarna") & "','" & MyRecReadA("STOCK_CdSuplier") & "','" & _
                                        "N" & "','" & MyRecReadA("STOCK_Tahun") & "','" & TxtPetik(MyRecReadA("STOCK_NoKunci")) & "','" & _
                                        "Y" & "','',NULL,NULL,'" & nSr(MyRecReadA("STOCK_CdLokasi")) & "','" & _
                                        nSr(MyRecReadA("STOCK_Keterangan")) & "',0,0,0," & _
                                        "0,0,0,0,NULL," & FieldTgl(MyRecReadA("STOCK_TglAuto")) & ")"

                            mSave = UpdateDatabase_Tabel(mSqlCommadstring, mLokasi, "")
                            If mSave = 1 Then
                                mSqlCommadstring = "UPDATE TRXN_STOCK SET STOCK_StsUpdate='T' " & _
                                            "WHERE STOCK_NORANGKA='" & nSr(MyRecReadA("STOCK_NORANGKA")) & "'"
                                Call UpdateDatabase_Tabel(mSqlCommadstring, "", "")
                            End If
                        End If

                    Else
                        mSave = Download_From_Warehouse_Stok_dan_TerimaUnitCustomerDealer(mLokasi, nSr(MyRecReadA("STOCK_NORANGKA")))

                        mSqlCommadstring = "UPDATE TRXN_STOCK SET " & _
                                    "STOCK_CDLOKASI='" & nSr(MyRecReadA("STOCK_CDLOKASI")) & "', " & _
                                    "STOCK_Tglterima=" & FieldTgl(MyRecReadA("STOCK_TglAuto")) & " " & _
                                    "WHERE STOCK_NORANGKA='" & nSr(MyRecReadA("STOCK_NORANGKA")) & "'"
                        mSave = UpdateDatabase_Tabel(mSqlCommadstring, mLokasi, "")

                        mSave = 1

                        If nSr(MyRecReadA("mfInputDOSUplier")) = "" Then
                            mSqlCommadstring = "INSERT INTO TRXN_STOCKDO (" & _
                                        "STOCKDO_NORANGKA,STOCKDO_NOMESIN,STOCKDO_KODEDLR,STOCKDO_NODOSPL,STOCKDO_TGDOSPL,STOCKDO_TGDOSPLI) VALUES " & _
                                        "('" & nSr(MyRecReadA("STOCK_NORANGKA")) & "','" & nSr(MyRecReadA("STOCK_NOMESIN")) & "'," & _
                                        "'" & mLokasi & "','SISTEM','SISTEM',GETDATE())"
                            Call UpdateDatabase_Tabel(mSqlCommadstring, "", "")
                        End If
                    End If
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 1)
        End Try

    End Function

    Function Download_From_Warehouse_Stok_dan_TerimaUnitCustomerDealer(ByVal mLokasi As String, ByVal mRangka As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                                "SELECT *," & _
                                "(SELECT SPK_NAMA1 FROM TRXN_SPK WHERE SPK_NORANGKA=STOCK_NORANGKA) as mSPK_NAMA1," & _
                                "(SELECT SPK_KOTA FROM TRXN_SPK WHERE SPK_NORANGKA=STOCK_NORANGKA) as mSPK_KOTA," & _
                                "(SELECT SPK_TGLDO FROM TRXN_SPK WHERE SPK_NORANGKA=STOCK_NORANGKA) as mSPK_TGLDO " & _
                                "FROM TRXN_STOCK WHERE STOCK_NORANGKA='" & UCase(mRangka) & "'"


        Download_From_Warehouse_Stok_dan_TerimaUnitCustomerDealer = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            Download_From_Warehouse_Stok_dan_TerimaUnitCustomerDealer = IIf(MyRecReadB.HasRows = True, 1, 0)
            If Download_From_Warehouse_Stok_dan_TerimaUnitCustomerDealer = 1 Then
                Dim mSave As Integer = 0
                While MyRecReadB.Read()
                    mSqlCommadstring = "UPDATE TRXN_STOCK SET STOCK_StsUpdate='T'," & _
                                "STOCK_NoMesin='" & nSr(MyRecReadB("STOCK_NoMesin")) & "'," & _
                                "STOCK_CdSuplier='" & nSr(MyRecReadB("STOCK_CdSuplier")) & "'," & _
                                "STOCK_Tahun='" & nSr(MyRecReadB("STOCK_Tahun")) & "'," & _
                                "STOCK_NoKunci='" & nSr(MyRecReadB("STOCK_NoKunci")) & "'," & _
                                "STOCK_DOSPKNama='" & TxtPetik(Left(nSr(MyRecReadB("mSPK_NAMA1")), 30)) & "'," & _
                                "STOCK_DOSPKKota='" & nSr(MyRecReadB("mSPK_KOTA")) & "'," & _
                                "STOCK_TglDoDealer=" & FieldTgl(MyRecReadB("mSPK_TGLDO")) & "," & _
                                "STOCK_NODEALER='" & mLokasi & "'," & _
                                "STOCK_Berita='SDH ADA DI ADM TGL " & Format(MyRecReadB("STOCK_TglTTK"), "DD-MM-YYYY") & "' " & _
                                "WHERE STOCK_NORANGKA='" & mRangka & "'"
                    mSave = UpdateDatabase_Tabel(mSqlCommadstring, "", "")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 1)
        End Try

    End Function


    Protected Sub BtnStok1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStok1.Click
        Multi03Stok.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnStok2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStok2.Click
        Multi03Stok.ActiveViewIndex = 1
    End Sub
    Protected Sub BtnStok3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStok3.Click
        Multi03Stok.ActiveViewIndex = 2
        Call isidataperbaikan()
    End Sub
    Protected Sub BtnStok4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStok4.Click
        Multi03Stok.ActiveViewIndex = 3
    End Sub

    Protected Sub BtnF2NoTTK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnF2NoTTK.Click
        Dim mCari As Byte = 0
        If TxtNoTTK.Text <> "" Then
            mCari = GETSTOCK_GETTTK("STOCK_NoTTK ='" & TxtNoTTK.Text & "'")
        End If
        If mCari = 1 Then
            MultiViewTabelStok.ActiveViewIndex = -1
        Else
            MultiViewTabelStok.ActiveViewIndex = 0 : LvDataTabelStok.DataBind()
        End If
    End Sub
    Protected Sub LvDataTabelStok_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDataTabelStok.SelectedIndexChanged
        TxtNoTTK.Text = (LvDataTabelStok.DataKeys(LvDataTabelStok.SelectedIndex).Value.ToString)
        Call GETSTOCK_GETTTK("STOCK_NoTTK ='" & TxtNoTTK.Text & "'")
        MultiViewTabelStok.ActiveViewIndex = -1
    End Sub

    Protected Sub BtnF2NoRangka_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnF2NoRangka.Click
        If ValidasiNoRangka1() <> 1 Then
            LvDataStockDoImora.DataBind()
            MultiViewStockImora.ActiveViewIndex = 0
            'TxtNoRangka.Text = "" : lblNoRangkaTag.Text = TxtNoRangka.Text
        Else
            MultiViewStockImora.ActiveViewIndex = -1
        End If
    End Sub
    Protected Sub LvDataStockDoImora_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDataStockDoImora.SelectedIndexChanged
        TxtNoRangka.Text = (LvDataStockDoImora.DataKeys(LvDataStockDoImora.SelectedIndex).Value.ToString)
        If TxtNoRangka.Text <> lblNoRangkaTag.Text Then
            If ValidasiNoRangka1() = 1 Then
                Call ValidasiNoRangka2()
            End If
        End If
        MultiViewStockImora.ActiveViewIndex = -1
    End Sub
    Function ValidasiNoRangka1() As Byte
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim mSqlCommadstring As String = "SELECT *, " & _
                                         "(SELECT STOCK_NOTTK FROM TRXN_STOCK WHERE STOCK_NoRangka = STOCKDO_NORANGKA) AS NoTTK " & _
                                         "FROM TRXN_STOCKDO WHERE STOCKDO_NORANGKA like '" & UCase(TxtNoRangka.Text) & "' ORDER BY STOCKDO_NORANGKA"

        ValidasiNoRangka1 = 0
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                ValidasiNoRangka1 = 1
                If MyRecReadA.Read() = True Then
                    If nSr(MyRecReadA("NoTTK")) <> "" And TxtNoTTK.Text <> nSr(MyRecReadA("NoTTK")) Then
                        Msg_err(UCase("Nomor rangka " & TxtNoRangka.Text & " sudah ada ada no ttk " & nSr(MyRecReadA("NoTTK"))), 1)
                        ValidasiNoRangka1 = 0
                    ElseIf (nSr(MyRecReadA("NoTTK")) = "") And _
                           Kodedealer.Text <> nSr((MyRecReadA("STOCKDO_KODEDLR"))) Then
                        Msg_err(UCase("Nomor rangka " & TxtNoRangka.Text & " punya kode dealer " & nSr((MyRecReadA("STOCKDO_KODEDLR"))) & " Periksa lokasi-nya sesuaikan dengan dealernya"), 1)
                        ValidasiNoRangka1 = 0
                    Else
                        LblCdBranch.Text = nSr((MyRecReadA("STOCKDO_KODEDLR")))
                        TxtNoMesin.Text = nSr((MyRecReadA("STOCKDO_NOMESIN")))
                        NamaTypeImora.Text = nSr((MyRecReadA("STOCKDO_TYPEDOSPL")))
                        KodeTypeImora.Text = nSr((MyRecReadA("STOCKDO_TYPEDOSPLCODE")))
                        KodeWarnaImora.Text = nSr((MyRecReadA("STOCKDO_WARNADOSPL")))
                        NamaWarnaImora.Text = nSr((MyRecReadA("STOCKDO_WARNADOSPLDESC")))
                        If GetDataD_00NoFound01Found("SELECT * FROM DATA_WARNA WHERE WARNA_Int='" & NamaWarnaImora.Text & "'", "", 0) = 1 Then
                            KodeWarnaImoraTag.Text = NamaWarna.Text
                            KodeWarnaImoraTag.Text = GetDataD_IsiField("SELECT WARNA_Int as IsiField FROM DATA_WARNA WHERE WARNA_Int='" & NamaWarnaImora.Text & "'", "", 0)
                            TxtCdWarna.Text = GetDataD_IsiField("SELECT WARNA_Kode as IsiField FROM DATA_WARNA WHERE WARNA_Int='" & NamaWarnaImora.Text & "'", "", 0)
                            lblCdWarnaTag.Text = TxtCdWarna.Text
                            NamaWarna.Text = NamaWarnaImora.Text
                        Else
                            If KodeWarnaImora.Text <> "" Then
                                KodeWarnaImoraTag.Text = GetDataD_IsiField("SELECT WARNA_Int as IsiField FROM DATA_WARNA WHERE WARNA_KODEHPM='" & KodeWarnaImora.Text & "'", "", 0)
                            ElseIf NamaWarnaImora.Text <> "" Then
                                KodeWarnaImoraTag.Text = GetDataD_IsiField("SELECT WARNA_Int as IsiField FROM DATA_WARNA WHERE WARNA_Int='" & NamaWarnaImora.Text & "'", "", 0)
                            End If
                        End If
                    End If
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function
    Function ValidasiNoRangka2() As Byte
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        'If FIND_STOCK("STOCK_NoRangka ='" & TxtNoRangka.Text & "'") = 1 Then
        Dim mSqlCommadstring As String = "SELECT *, " & _
                              "(SELECT TYPE_Nama FROM DATA_TYPE WHERE TYPE_Type = STOCK_CdType) AS NamaType, " & _
                              "(SELECT TYPE_IMORA FROM DATA_TYPE WHERE TYPE_Type = STOCK_CdType) AS KodeTypeImora, " & _
                              "(SELECT TYPE_CdRangka FROM DATA_TYPE WHERE TYPE_Type = STOCK_CdType) AS NoCdRangka, " & _
                              "(SELECT WARNA_Int FROM DATA_WARNA WHERE WARNA_Kode = STOCK_CdWarna) AS NamaWarna, " & _
                              "(SELECT WARNA_KODEHPM FROM DATA_WARNA WHERE WARNA_Kode = STOCK_CdWarna) AS NamaWarnaHPM, " & _
                              "(SELECT SUPLIER_Nama FROM DATA_SUPLIER WHERE SUPLIER_Kode = STOCK_CdSuplier) AS NamaSuplier, " & _
                              "(SELECT LOKASI_Nama FROM DATA_LOKASI WHERE LOKASI_Kode = STOCK_CdLokasi) AS NamaLokasi, " & _
                              "(SELECT LOKASI_KODEDLR FROM DATA_LOKASI WHERE LOKASI_Kode = STOCK_CdLokasi) AS Kodedealer, " & _
                              "(SELECT LOKASI_IPServer FROM DATA_LOKASI WHERE LOKASI_Kode = STOCK_CdLokasi) AS NamaServer " & _
                              "FROM TRXN_STOCK LEFT OUTER JOIN TRXN_STOCKKKIRIM ON TRXN_STOCK.STOCK_NoRangka = TRXN_STOCKKKIRIM.STOCKK_NORANGKA AND STOCK_NoRangka ='" & TxtNoRangka.Text & "' ORDER BY STOCK_NoTTK"
        ValidasiNoRangka2 = 0

        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                ValidasiNoRangka2 = 1
                While MyRecReadB.Read()
                    If nSr(MyRecReadB("STOCK_NoTTK")) <> TxtNoTTK.Text Then
                        Msg_err(UCase("Nomor rangka " & TxtNoRangka.Text & " sudah ada ada no ttk " & nSr(MyRecReadB("STOCK_NoTTK"))), 0) : Exit Function
                        TxtNoRangka.Text = lblNoRangkaTag.Text
                    End If
                    Msg_err("No Rangka ini belum ada DO Suplier dari kantor cabang  \n " & _
                           "Penting !! Stock ini tidak akan diakui oleh Cabang sesuai dengan lokasinya sampai DO Supliernya di masukan", 1)
                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function


    Protected Sub BtnF2type_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnF2Tipe.Click
        Dim mCari As Byte = 0
        If TxtCdType.Text <> "" Then
            mCari = GETType_TTK("TYPE_Type ='" & UCase(TxtCdType.Text) & "'")
        End If
        If mCari = 1 Then
            MultiViewType.ActiveViewIndex = -1
        Else
            MultiViewType.ActiveViewIndex = 0 : LvDataType.DataBind()
        End If
    End Sub
    Protected Sub LvDataType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDataType.SelectedIndexChanged
        TxtCdType.Text = (LvDataType.DataKeys(LvDataType.SelectedIndex).Value.ToString)
        Call GETType_TTK("TYPE_Type ='" & UCase(TxtCdType.Text) & "'")
        MultiViewType.ActiveViewIndex = -1
    End Sub
    Function GETType_TTK(ByVal mSearchTxt As String) As Byte
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        'If FIND_STOCK("STOCK_NoRangka ='" & TxtNoRangka.Text & "'") = 1 Then
        Dim mSqlCommadstring As String = "SELECT * FROM DATA_TYPE WHERE " & mSearchTxt
        GETType_TTK = 0

        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtCdType.Text = nSr((MyRecReadA("TYPE_Type")))
                lblCdTypeTag.Text = TxtCdType.Text
                'LblTypeKode.Text = nSr((MyRecReadA("TYPE_Merk"))) & "-"
                'LblTypeKode.Text = LblTypeKode.Text & nSr((MyRecReadA("TYPE_Bentuk"))) & "-"
                'LblTypeKode.Text = LblTypeKode.Text & nSr((MyRecReadA("TYPE_Produk")))
                NamaType.Text = nSr((MyRecReadA("TYPE_Nama")))
                lblMugenImoraType.Text = nSr((MyRecReadA("TYPE_Imora")))
                GETType_TTK = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function


    Protected Sub BtnF2Warna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnF2Warna.Click
        Dim mCari As Byte = 0
        If TxtCdWarna.Text <> "" Then
            mCari = GETWarna_TTK("(WARNA_Kode) ='" & UCase(TxtCdWarna.Text) & "'")
        End If
        If mCari = 1 Then
            MultiViewWarna.ActiveViewIndex = -1
        Else
            MultiViewWarna.ActiveViewIndex = 0 : LvWarna.DataBind()
        End If
    End Sub
    Protected Sub LvWarna_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvWarna.SelectedIndexChanged
        TxtCdWarna.Text = (LvWarna.DataKeys(LvWarna.SelectedIndex).Value.ToString)
        Call GETWarna_TTK("(WARNA_Kode) ='" & UCase(TxtCdWarna.Text) & "'")
        MultiViewWarna.ActiveViewIndex = -1
    End Sub
    Function GETWarna_TTK(ByVal mSearchTxt As String) As Byte
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        'If FIND_STOCK("STOCK_NoRangka ='" & TxtNoRangka.Text & "'") = 1 Then
        Dim mSqlCommadstring As String = "SELECT * FROM DATA_WARNA WHERE " & mSearchTxt
        GETWarna_TTK = 0
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtCdWarna.Text = nSr((MyRecReadA("WARNA_Kode")))
                lblCdWarnaTag.Text = TxtCdWarna.Text
                NamaWarna.Text = nSr((MyRecReadA("WARNA_Int")))
                KodeWarnaImoraMugen.Text = nSr((MyRecReadA("WARNA_KODEHPM")))
                GETWarna_TTK = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Protected Sub BtnF2Suplier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnF2Suplier.Click
        Dim mCari As Byte = 0
        If TxtCdSuplier.Text <> "" Then
            mCari = GetSuplier_TTK("SUPLIER_Kode LIKE '" & "%" & TxtCdSuplier.Text & "%" & "'")
        End If
        If mCari = 1 Then
            MultiViewSuplier.ActiveViewIndex = -1
        Else
            MultiViewSuplier.ActiveViewIndex = 0 : LvSuplier.DataBind()
        End If
    End Sub
    Protected Sub LvSuplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvSuplier.SelectedIndexChanged
        TxtCdSuplier.Text = (LvSuplier.DataKeys(LvSuplier.SelectedIndex).Value.ToString)
        Call GetSuplier_TTK("SUPLIER_Kode LIKE '" & "%" & TxtCdSuplier.Text & "%" & "'")
        MultiViewSuplier.ActiveViewIndex = -1
    End Sub
    Function GetSuplier_TTK(ByVal mSearchTxt As String) As Byte
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        'If FIND_STOCK("STOCK_NoRangka ='" & TxtNoRangka.Text & "'") = 1 Then
        Dim mSqlCommadstring As String = "SELECT * FROM DATA_SUPLIER WHERE " & mSearchTxt
        GetSuplier_TTK = 0
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtCdSuplier.Text = nSr((MyRecReadA("SUPLIER_Kode")))
                lblCdSuplierTag.Text = TxtCdSuplier.Text
                nmSuplier.Text = nSr((MyRecReadA("SUPLIER_Nama")))
                GetSuplier_TTK = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Protected Sub BtnF2Lokasi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnF2Lokasi.Click
        Dim mCari As Byte = 0
        If TxtcdLokasi.Text <> "" Then
            mCari = ValidasiLokasi()
        End If
        If mCari = 1 Then
            MultiViewLokasi.ActiveViewIndex = -1
        Else
            MultiViewLokasi.ActiveViewIndex = 0 : LvLokasi.DataBind()
        End If
    End Sub
    Protected Sub LvLokasi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvLokasi.SelectedIndexChanged
        TxtcdLokasi.Text = (LvLokasi.DataKeys(LvLokasi.SelectedIndex).Value.ToString)
        Call ValidasiLokasi()
        MultiViewLokasi.ActiveViewIndex = -1
    End Sub

    Function GetLokasi_TTK(ByVal mSearchTxt As String) As Byte
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM DATA_LOKASI WHERE (LOKASI_Kode) ='" & mSearchTxt & "'"
        GetLokasi_TTK = 0
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                TxtcdLokasi.Text = nSr((MyRecReadA("LOKASI_Kode")))
                lblcdLokasiTag.Text = nSr((MyRecReadA("LOKASI_Kode")))
                NamaLokasi.Text = nSr((MyRecReadA("LOKASI_Nama")))
                Kodedealer.Text = nSr((MyRecReadA("LOKASI_KodeDLR")))
                GetLokasi_TTK = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function ValidasiLokasi() As Byte
        ValidasiLokasi = 0
        If GetLokasi_TTK(UCase(TxtcdLokasi.Text)) <> 1 Then
            TxtcdLokasi.Text = ""
        ElseIf TxtNoRangka.Text <> "" Then
            Dim mKodedlr As String = GetDataD_IsiField("SELECT STOCKDO_KODEDLR as IsiField FROM TRXN_STOCKDO WHERE STOCKDO_NORANGKA='" & UCase(TxtNoRangka.Text) & "'", "", 0)

            If mKodedlr <> "" Then
                If (Kodedealer.Text <> nSr(mKodedlr)) And InStr(NamaLokasi.Text, "CROS") = 0 Then
                    Msg_err(UCase("Nomor rangka " & TxtNoRangka.Text & " punya kode dealer " & nSr(mKodedlr) & " Periksa lokasi-nya sesuaikan dengan dealernya"), 0)
                    TxtcdLokasi.Text = "" : Exit Function
                Else
                    ValidasiLokasi = 1
                End If
            Else
                Msg_err("No Rangka ini belum ada DO Suplier dari kantor cabang  \n " & _
                       "Penting !! Stock ini tidak akan diakui oleh Cabang sesuai dengan lokasinya sampai DO Supliernya di masukan", 1)
                ValidasiLokasi = 1
            End If
        End If
        If lblcdLokasiTag.Text = "" Then lblcdLokasiTag.Text = TxtcdLokasi.Text
    End Function

    Function GetSupir_TTK() As Byte
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM DATA_DRIVER"
        GetSupir_TTK = 0
        DropDownList2.Items.Clear()
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                GetSupir_TTK = 1
                While MyRecReadA.Read()
                    DropDownList2.Items.Add(nSr(MyRecReadA("DRIVER_KODE")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Protected Sub BtnHal1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHal1.Click
        MultiViewWarehouse.ActiveViewIndex = 0
    End Sub

    Protected Sub BtnHal2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHal2.Click
        MultiViewWarehouse.ActiveViewIndex = 1
    End Sub

    Protected Sub BtnHal3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHal3.Click
        MultiViewWarehouse.ActiveViewIndex = 2
        Multi03Stok.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnHal4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHal4.Click
        MultiViewWarehouse.ActiveViewIndex = 3
    End Sub
    Protected Sub BtnHal5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHal5.Click
        MultiViewWarehouse.ActiveViewIndex = 4
    End Sub
    Protected Sub BtnHal6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnHal6.Click
        If Mid(lblAkses.Text, 19, 1) = "1" Then
            MultiViewWarehouse.ActiveViewIndex = 5
        End If
    End Sub

    Protected Sub BtnStok6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStok6.Click
        Multi03Stok.ActiveViewIndex = 5
        Call History(TxtNoRangka.Text)
    End Sub

    Sub History(ByVal mRgk As String)
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                     "SELECT * FROM TRXN_STOCKHISTORY   WHERE  " & _
                     "STOCKH_NORANGKA='" & mRgk & "'"
        insertTabelHistory(0, "", "", "", "", "")
        Call Msg_err("", "1")
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    insertTabelHistory(1, nSr(MyRecReadA("STOCKH_NORANGKA")), nSr(MyRecReadA("STOCKH_TANGGAL")), _
                                       nSr(MyRecReadA("STOCKH_USER")), nSr(MyRecReadA("STOCKH_HISTORY")), _
                                       nSr(MyRecReadA("STOCKH_STATUS")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, "1")
        End Try
    End Sub


    Function GETType_CetakBBM(ByVal mVcrBBM As String) As Byte
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
        "select * FROM TRXN_STOCKVKIRIM,TRXN_STOCK,DATA_TYPE,DATA_WARNA,DATA_LOKASI WHERE " & _
        "STOCKV_NORANGKA=STOCK_NORANGKA AND STOCK_CDTYPE=TYPE_Type AND STOCK_CDWARNA=WARNA_Kode AND STOCK_CdLokasi =LOKASI_Kode AND " & _
        "STOCKV_NOBBM='" & mVcrBBM & "' AND STOCKV_TGLBATAL IS NULL"

        GETType_CetakBBM = 0
        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                lblCetakBBMIsiColA2.Text = nSr(MyRecReadA("STOCKV_NOBBM"))
                lblCetakBBMIsiColA4.Text = Mid(nSr(MyRecReadA("STOCKV_NOBBM")), 5, 2) + "/" + Mid(nSr(MyRecReadA("STOCKV_NOBBM")), 3, 2) + "/" + Mid(nSr(MyRecReadA("STOCKV_NOBBM")), 1, 2)
                lblCetakBBMIsiColB2.Text = nSr(MyRecReadA("STOCK_NoRangka")) & " - " & nSr(MyRecReadA("STOCK_NoMesin"))
                lblCetakBBMIsiColB4.Text = nSr(MyRecReadA("LOKASI_KODEDLR"))
                lblCetakBBMIsiColC2.Text = nSr(MyRecReadA("TYPE_NAMA"))
                lblCetakBBMIsiColC4.Text = "_______________"
                lblCetakBBMIsiColD2.Text = nSr(MyRecReadA("WARNA_INT"))
                lblCetakBBMIsiColD4.Text = DDListBBMTp.Text & " : " & nSr(MyRecReadA("STOCKV_Note"))
                lblCetakBBMIsiColE1.Text = "Rp." & fLg(nLg(MyRecReadA("STOCKV_NILAI")))
                GETType_CetakBBM = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function


    Protected Sub BtnPrintSPJR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintSPJR.Click
        'btnPrintSPJ.Visible = True : btnPrintSPJR.Visible = False
        'dodolSPJ() 'Check Tanggal SPJ harus lebih besar dari tgl sekarang
        If LblKirimJenis.Text = "CUSTOMER" Then
            MultiViewCetak.ActiveViewIndex = 1
            Call clearspj()
            Label86.Text = "PT MITRAUSAHA GENTANIAGA"
            Label87.Text = "HONDA MUGEN"
            Label88.Text = "SURAT PERINTAH JALAN KE " & LblKirimJenis.Text
            Call GETType_CetakSPJ_Customer(TxtNoRangka.Text)
            LblSPJ12TGLSURAT.Text = "Jakarta," & Format(Now(), "dd/MM/yyyy")
        Else
            Call clearspjNoCust()
            MultiViewCetak.ActiveViewIndex = 5
            Label33.Text = "PT MITRAUSAHA GENTANIAGA"
            Label34.Text = "HONDA MUGEN"
            Label35.Text = "SURAT PERINTAH JALAN KE " & LblKirimJenis.Text
            Call GETType_CetakSPJ_NonCustomer(TxtNoRangka.Text)
            LblSPJNSTGLSURAT.Text = "Jakarta," & Format(Now(), "dd/MM/yyyy")
        End If
    End Sub
    Protected Sub BtnPrintSPJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintSPJ.Click
        'btnPrintSPJ.Visible = False : btnPrintSPJR.Visible = True
        MultiViewCetak.ActiveViewIndex = -1
    End Sub
    Function GETType_CetakSPJ_NonCustomer(ByVal mRangka As String) As Byte
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
        "select * FROM TRXN_STOCKKKIRIM,TRXN_STOCK,DATA_DRIVER,DATA_TYPE,DATA_WARNA WHERE " & _
        "STOCKK_NORANGKA=STOCK_NoRangka AND STOCKK_DRIVER=DRIVER_KODE  AND STOCK_CDTYPE=TYPE_Type AND STOCK_CDWARNA=WARNA_Kode AND STOCKK_NORANGKA='" & mRangka & "' AND STOCKK_NOKIRIM='" & LblKirimNo.Text & "'"
        GETType_CetakSPJ_NonCustomer = 0
        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                LblSPJNS1NoDoc.Text = nSr(MyRecReadA("STOCKK_NOKIRIM"))
                LblSPJNS1NoRangka.Text = nSr(MyRecReadA("STOCK_NORANGKA")) : LblSPJNS1NoMesin.Text = nSr(MyRecReadA("STOCK_NOMESIN"))
                LblSPJNS2Tipe.Text = nSr(MyRecReadA("TYPE_NAMA")) : LblSPJNS2Supir.Text = nSr(MyRecReadA("DRIVER_KODE"))
                LblSPJNS3Warna.Text = nSr(MyRecReadA("WARNA_INT")) : LblSPJNS3Kirim.Text = nSr(MyRecReadA("STOCKK_KIRIMTGLKIRIM"))
                LblSPJNS4Catatan.Text = nSr(MyRecReadA("STOCKK_DRIVERNM"))
                LblSPJNS4Ongkos.Text = "Biaya Transportasi Rp." & nSr(MyRecReadA("STOCKK_BIAYA"))
                GETType_CetakSPJ_NonCustomer = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function GETType_CetakSPJ_Customer(ByVal mRangka As String) As Byte
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
        "select * FROM TRXN_STOCKAKIRIMP,TRXN_STOCKAKIRIM,TRXN_STOCKKKIRIM,TRXN_STOCKMKIRIM,TRXN_STOCK,DATA_DRIVER,DATA_TYPE,DATA_WARNA WHERE " & _
        "STOCKAKP_NORANGKA=STOCKA_NORANGKA AND STOCKA_NORANGKA = STOCKK_NORANGKA AND " & _
        "STOCKK_NORANGKA=STOCKM_NORANGKA AND STOCKM_NORANGKA=STOCK_NoRangka AND " & _
        "STOCKK_DRIVER=DRIVER_KODE  AND STOCK_CDTYPE=TYPE_Type AND STOCK_CDWARNA=WARNA_Kode AND STOCKK_NORANGKA='" & mRangka & "'"
        GETType_CetakSPJ_Customer = 0
        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()

                LblSPJ1NODoc.Text = nSr(MyRecReadA("STOCKK_NOKIRIM"))
                LblSPJ1NOSPK.Text = nSr(MyRecReadA("STOCK_NOSPK")) : LblSPJ1NODO.Text = nSr(MyRecReadA("STOCK_DODEALER"))
                LblSPJ2RGK.Text = nSr(MyRecReadA("STOCK_NORANGKA")) : LblSPJ2SALES.Text = nSr(MyRecReadA("STOCKM_SALES"))
                LblSPJ3TIPE.Text = nSr(MyRecReadA("TYPE_NAMA")) : LblSPJ3TGLM.Text = nSr(MyRecReadA("DRIVER_KODE"))
                LblSPJ4WARNA.Text = nSr(MyRecReadA("WARNA_EXT")) : LblSPJ4TGLK.Text = nSr(MyRecReadA("DRIVER_KODE"))
                LblSPJ5NAMA1.Text = nSr(MyRecReadA("STOCKA_NAMA")) : LblSPJ5NAMA2.Text = "________________"
                LblSPJ6ALAMAT11.Text = Mid(nSr(MyRecReadA("STOCKA_ALAMAT")), 1, 50) : LblSPJ6ALAMAT12.Text = "________________"
                LblSPJ7KOTA1.Text = nSr(MyRecReadA("STOCKA_KOTA")) : LblSPJ7KOTA2.Text = "............."
                Label233.Text = "SPK: " + nSr(MyRecReadA("STOCKAKP_PPH")) & "/" & nSr(MyRecReadA("STOCKAKP_PHP")) & _
                                     "STNK: " + nSr(MyRecReadA("STOCKAKP_SPH")) & "/" & nSr(MyRecReadA("STOCKAKP_SHP"))
                LblSPJ8Biaya.Text = "Biaya Transportasi Rp." & nSr(MyRecReadA("STOCKK_BIAYA"))
                GETType_CetakSPJ_Customer = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function



    Protected Sub BtnPrintPDIR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintPDIR.Click
        'btnPrintPDI.Visible = True : btnPrintPDIR.Visible = False
        MultiViewCetak.ActiveViewIndex = 3
        Label165.Text = "PT MITRAUSAHA GENTANIAGA"
        Label166.Text = "HONDA MUGEN"
        Label167.Text = "FORM PDI"
        Call GETType_CetakPDI(TxtNoRangka.Text)
        Label180.Text = "Jakarta," & Format(Now(), "dd/MM/yyyy")
    End Sub
    Protected Sub BtnPrintPDI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintPDI.Click
        btnPrintPDI.Visible = False : btnPrintPDIR.Visible = True : MultiViewCetak.ActiveViewIndex = -1
    End Sub
    Function GETType_CetakPDI(ByVal mRangka As String) As Byte
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
        "select * FROM TRXN_STOCKAKSESORIS,TRXN_STOCK,TRXN_STOCKKKIRIM,TRXN_STOCKMKIRIM,DATA_TYPE,DATA_WARNA WHERE " & _
        "STOCKAKSESORIS_NORANGKA=STOCK_NORANGKA AND STOCK_NORANGKA=STOCKM_NORANGKA AND STOCKM_NORANGKA = STOCKK_NORANGKA AND " & _
        "STOCK_CDTYPE=TYPE_Type AND STOCK_CDWARNA=WARNA_Kode AND STOCKK_NORANGKA='" & mRangka & "'"
        GETType_CetakPDI = 0
        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                LbPDISPK.Text = nSr(MyRecReadA("STOCK_NOSPK")) : LbPDIDO.Text = nSr(MyRecReadA("STOCK_DODEALER"))
                LbPDIRGK.Text = nSr(MyRecReadA("STOCK_NORANGKA")) : LbPDISALES.Text = nSr(MyRecReadA("STOCKM_SALES"))
                LbPDITIPE.Text = nSr(MyRecReadA("TYPE_NAMA")) : LblSPJ3TGLM.Text = nSr(MyRecReadA("STOCKM_TGLMOHONINPUT"))
                LbPDIWARNA.Text = nSr(MyRecReadA("WARNA_EXT")) : LbPDITGLM.Text = nSr(MyRecReadA("STOCKM_TGLMOHONKIRIM"))
                GETType_CetakPDI = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        lvKirimmUnit.DataBind()
        MultiV4Jadwal.ActiveViewIndex = 0
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TxtDateGesek.Text <> "" Then
            Call DataGesekRangka("112")
            Call DataGesekRangka("128")
            LVGesekRangka.DataBind()
        End If
    End Sub


    Sub DataGesekRangka(ByVal Mydealer As String)
        Dim mpServer As String = "MyConnCloudDnet" & Mydealer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_SPK WHERE DATEDIFF(day,SPK_TGLDO," & FieldTgl(CDate(TxtDateGesek.Text)) & ") = 0"
        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mSqlCommadstring = "UPDATE TRXN_STOCK SET " & "STOCK_NAMA='" & TxtPetik(Left(nSr(MyRecReadA("SPK_NAMA1")), 30)) & "'," & "STOCK_KOTA='" & nSr(MyRecReadA("SPK_KOTA")) & "'," & "STOCK_TGLDODEALER=" & FieldTgl(MyRecReadA("SPK_TGLDO")) & "," & "STOCK_KODEDEALER='" & Mydealer & "' " & "WHERE STOCK_NoRangka='" & nSr(MyRecReadA("SPK_NORANGKA")) & "' " 'AND ISNULL(STOCK_TGLDODEALER)
                    Call UpdateDatabase_Tabel(mSqlCommadstring, "", 0)
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Sub

    Protected Sub LVGesekRangka_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVGesekRangka.SelectedIndexChanged
        Dim mNomorangaka As String = (LVGesekRangka.DataKeys(LVGesekRangka.SelectedIndex).Value.ToString)
        If TxtGesekRangkaActual.Text <> "" Then
            Call UpdateDataGesekRangka(mNomorangaka)
            LVGesekRangka.DataBind()
        Else
            Msg_err("Tanggal Update ranga belum diisi", 1)
        End If

    End Sub
    Sub UpdateDataGesekRangka(ByVal mNorangka As String)
        Dim mpServer As String = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_STOCK WHERE STOCK_NORANGKA='" & mNorangka & "'"
        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    If nSr(MyRecReadA("STOCK_DOTGLGESEKRGK")) = "" Then
                        mSqlCommadstring = "UPDATE TRXN_STOCK SET STOCK_DOTGLGESEKRGKI=GETDATE(),STOCK_DOTGLGESEKRGK=" & FieldTgl(CDate(TxtGesekRangkaActual.Text)) & " " & _
                                           "WHERE STOCK_NORANGKA='" & mNorangka & "'"
                    Else
                        mSqlCommadstring = "UPDATE TRXN_STOCK SET STOCK_DOTGLGESEKRGKI=NULL,STOCK_DOTGLGESEKRGK=NULL " & _
                                           "WHERE STOCK_NORANGKA='" & mNorangka & "'"
                    End If
                    Call UpdateDatabase_Tabel(mSqlCommadstring, "", 0)
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Sub


    Sub DataAksesorisBasedNoRangka(ByVal Mydealer As String)
        Dim mpServer As String = "MyConnCloudDnet" & Mydealer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT OPT_NOWO,OPTH_TGLWO,OPTH_TglSendWO,OPTH_TglKerjaBukti,OPT_CdAssesoris,STANDARD_NAMA,OPT_Desc,STANDARD_NAMA,SUPLIER_NAMA FROM TRXN_OPT,TRXN_OPTH,DATA_STANDARD,DATA_SUPLIER WHERE OPTH_CdSuplier=SUPLIER_Kode AND OPT_NOWO=OPTH_NOWO AND OPT_CdAssesoris=STANDARD_KODE AND STANDARD_Kelompok='A' AND OPT_NORANGKA='" & TxtNoRangka.Text & "'"
        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    insertTabelAksesoris(1, Mydealer, nSr(MyRecReadA("OPT_NOWO")), nSr(MyRecReadA("OPTH_TGLWO")), nSr(MyRecReadA("OPTH_TglSendWO")), nSr(MyRecReadA("OPTH_TglKerjaBukti")), nSr(MyRecReadA("SUPLIER_NAMA")), nSr(MyRecReadA("OPT_CdAssesoris")), nSr(MyRecReadA("STANDARD_NAMA")), nSr(MyRecReadA("OPT_Desc")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Sub


    Protected Sub BtnStok5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStok5.Click
        insertTabelAksesoris(0, "", "", "", "", "", "", "", "", "")
        LblAksesorDlr.Text = ""
        LblAksesorWO.Text = ""
        LblAksesorKode.Text = ""
        LblAksesorNama.Text = ""
        LblAksesorNote.Text = ""
        LblAksesorpsg.Text = ""
        TxtAksesorpsg.Text = ""
        lblIsiTglPasang.Visible = False
        TxtIsiTglPasang.Visible = False
        BtnCall16.Visible = False
        Calendar16.Visible = False
        Call insertTabelAksesoris(0, "", "", "", "", "", "", "", "", "")
        If TxtNoRangka.Text <> "" Then
            Call DataAksesorisBasedNoRangka("112")
            Call DataAksesorisBasedNoRangka("128")
        End If
        Multi03Stok.ActiveViewIndex = 4

    End Sub

    Protected Sub LvValidInputUnit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvValidInputUnit.SelectedIndexChanged
        Dim mNomorangaka As String = (LvValidInputUnit.DataKeys(LvValidInputUnit.SelectedIndex).Value.ToString)
        If mNomorangaka <> "" Then
            Call UpdateDataValidUnit(mNomorangaka)
            LVGesekRangka.DataBind()
        Else
            Msg_err("Rangka Kosong", 1)
        End If

    End Sub

    Sub UpdateDataValidUnit(ByVal mNorangka As String)

        Dim MySTRsql As String = ""
        If GetDataD_IsiField("SELECT STOCK_USER as IsiField  FROM TRXN_STOCK STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) = "" Then
            MySTRsql = "UPDATE TRXN_STOCK SET STOCK_VALID=GETDATE(),STOCK_USER='" & LblUserName.Text & "' WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'"
        Else
            MySTRsql = "UPDATE TRXN_STOCK SET STOCK_VALID=NULL,STOCK_USER='' WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'"
        End If
        Call UpdateDatabase_Tabel(MySTRsql, "", 1)
    End Sub


    Protected Sub btnGetdataDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetdataDO.Click
        'dodolDO() 'Check Tanggal DO harus lebih besar cetak SPJ terlebih dahulu
        MultiViewCetak.ActiveViewIndex = 4
        If Label249.Text <> "ALAMAT KIRIM" Then
            Call Msg_err("PILIHAN ALAMAT KIRIM BELUM TERPILIH", 0)
        Else
            Call isikolomAksesorisClear()
            If LblCetakDOTgl.Text <> "" Then
                Call CetakDO1(LblCdBranch.Text, TxtNoRangka.Text)
                If LblCetakDO_Rangka.Text <> "" Then
                    Call CetakASS1(LblCdBranch.Text, TxtNoRangka.Text)
                End If
                Call CetakASS2(LblCdBranch.Text, TxtCdType.Text)
                If LblCetakDO_SPKNo.Text <> "" Then
                    Call CetakASS3(LblCdBranch.Text, LblCetakDO_SPKNo.Text)
                End If
                Call CetakASS4(LblCdBranch.Text, TxtNoRangka.Text)
            Else
                Call Msg_err("Belu disetujui untuk cetak DO call ADH", 1)
            End If
        End If
    End Sub

    Sub CetakDO1(ByVal Mydealer As String, ByVal mNorangka As String)
        Dim mpServer As String = "MyConnCloudDnet" & Mydealer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_SPK,TRXN_STOCK,DATA_TYPE,DATA_WARNA,DATA_LEASE,DATA_SALESMAN WHERE " & _
                                         "SPK_NORANGKA=STOCK_NORANGKA AND STOCK_CDTYPE=TYPE_TYPE AND STOCK_CDWARNA=WARNA_KODE AND SPK_CDLEASE=LEASE_KODE AND SPK_CDSALES=SALES_KODE AND SPK_NORANGKA='" & mNorangka & "'"
        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                If MyRecReadA.Read Then
                    If Mydealer = "112" Then
                        'LblCetakDO_JdlHonda.Text = "HONDA MUGEN PASAR MINGGU"
                        'LblCetakDO_JdlJalan.Text = "Jl Raya Pasar Minggu No 10 Jakarta 12740"
                    Else
                        'LblCetakDO_JdlHonda.Text = "HONDA MUGEN PURI"
                        'LblCetakDO_JdlJalan.Text = "Jl Lingkar Luar Barat Puri kembanagn Jakarta 11610"
                    End If

                    LblCetakDO_DONo.Text = nSr(MyRecReadA("SPK_NODO"))
                    LblCetakDO_DOTgl.Text = Format(CDate(MyRecReadA("SPK_TGLDO")), "dd-MM-yy")

                    If TxtNama.Text = "" Then
                        LblCetakDO_SPKNama.Text = nSr(MyRecReadA("SPK_NAMA1"))
                        LblCetakDO_SPKAlamat1.Text = nSr(MyRecReadA("SPK_ALAMAT"))
                        LblCetakDO_SPKAlamat2.Text = "KOTA " & nSr(MyRecReadA("SPK_KOTA")) & " TELP : " & nSr(MyRecReadA("SPK_Phone"))
                    Else
                        LblCetakDO_SPKNama.Text = TxtNama.Text
                        LblCetakDO_SPKAlamat1.Text = TxtAlamat.Text
                        LblCetakDO_SPKAlamat2.Text = "KOTA " & TxtKota.Text & " TLP: " & TxtNoHP.Text & "/" & TxtPhone.Text
                    End If

                    LblCetakDO_SPKNPWP.Text = nSr(MyRecReadA("SPK_NPWP"))
                    LblCetakDO_SPKPIutang.Text = nSr(MyRecReadA("SPK_PIUTANG"))
                    LblCetakDO_SPKNo.Text = nSr(MyRecReadA("SPK_NO"))
                    LblCetakDO_SPKTgl.Text = Format(CDate(MyRecReadA("SPK_TANGGAL")), "dd-MM-yy")
                    LblCetakDO_SPKTTKNo.Text = nSr(MyRecReadA("STOCK_NOTTK"))
                    LblCetakDO_SPKTTKTgl.Text = Format(CDate(MyRecReadA("STOCK_TGLTTK")), "dd-MM-yy")
                    LblCetakDO_Sales.Text = nSr(MyRecReadA("SALES_NAMA"))
                    LblCetakDO_Lease.Text = nSr(MyRecReadA("LEASE_NAMA"))

                    LblCetakDO_Terbilang.Text = HurufNumeric(ndb(MyRecReadA("SPK_PIUTANG")))

                    LblCetakDO_Type.Text = "HONDA/" & nSr(MyRecReadA("STOCK_Tahun"))
                    LblCetakDO_Rangka.Text = nSr(MyRecReadA("STOCK_NORANGKA"))

                    LblCetakDO_Tipe.Text = nSr(MyRecReadA("TYPE_NAMA"))
                    LblCetakDO_Mesin.Text = nSr(MyRecReadA("STOCK_NOMESIN"))

                    LblCetakDO_Warna.Text = nSr(MyRecReadA("WARNA_INT"))
                    LblCetakDO_Surat.Text = IIf(nSr(MyRecReadA("SPK_Road")) = "N", "   ********", "             ********")
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Sub

    Sub CetakASS1(ByVal Mydealer As String, ByVal mNorangka As String)
        Dim mpServer As String = "MyConnCloudDnet" & Mydealer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * FROM TRXN_ACCS,DATA_STANDARD WHERE ACCS_NoRangka ='" & mNorangka & "' AND ACCS_CdAssesoris=STANDARD_Kode AND NOT(STANDARD_Biaya='A' OR STANDARD_Biaya='M' OR STANDARD_Biaya='N' OR STANDARD_Biaya='P')"
        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    If nSr((MyRecReadA("STANDARD_Nama"))) <> "" Then
                        If MyRecReadA("ACCS_Status") <> "P" Then
                            Call isikolomAksesoris(MyRecReadA("STANDARD_Nama"), "S")
                        Else
                            Call isikolomAksesoris(MyRecReadA("STANDARD_Nama"), "T")
                        End If
                    End If
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Sub
    Sub CetakASS2(ByVal Mydealer As String, ByVal mNoType As String)
        Dim mpServer As String = "MyConnCloudDnet" & Mydealer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT STANDARD_Nama FROM DATA_DACCS,DATA_STANDARD WHERE DACCS_ASSESORISCD=STANDARD_KODE AND DACCS_type ='" & mNoType & "'"

        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    Call isikolomAksesoris(MyRecReadA("STANDARD_Nama"), "S")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Sub
    Sub CetakASS3(ByVal Mydealer As String, ByVal mNoSPK As String)
        Dim mpServer As String = "MyConnCloudDnet" & Mydealer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = _
                "SELECT *," & _
                "(SELECT OPTH_Tglwo FROM TRXN_OPTH WHERE OPTH_NoWO = OPT_NoWO) AS mTglWO," & _
                "(SELECT OPTH_TglKerjaBukti FROM TRXN_OPTH WHERE OPTH_NOWO=OPT_Nowo) as mFTglPsg," & _
                "(SELECT OPTH_CdSuplier FROM TRXN_OPTH WHERE OPTH_NoWO=OPT_NoWO) AS mKdSuplier," & _
                "(SELECT SUPLIER_Nama FROM TRXN_OPTH,DATA_SUPLIER WHERE OPTH_CdSuplier=SUPLIER_Kode AND OPTH_NoWO=OPT_NoWO) AS mNamaSuplier," & _
                "(SELECT SUPLIER_Nama FROM DATA_SUPLIER WHERE OPT_CdSuplier=SUPLIER_Kode) AS mNamaSuplier2," & _
                "(SELECT SUM(ISNULL(OPTD_Harga,0)) FROM TRXN_OPTD WHERE OPTD_NoWO = OPT_NoWO AND OPTD_CdAssesoris=OPT_CdAssesoris) AS mHrgSuplier  " & _
                "FROM TRXN_OPT,DATA_STANDARD WHERE OPT_CdAssesoris=STANDARD_Kode AND OPT_NoSPK ='" & mNoSPK & "' AND STANDARD_CETAK='Y'"
        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    If nSr((MyRecReadA("STANDARD_Nama"))) <> "" Then
                        If nSr((MyRecReadA("OPT_NoWO"))) <> "" Then
                            Call isikolomAksesoris(MyRecReadA("STANDARD_Nama"), "T")
                        End If
                    End If
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Sub
    Sub CetakASS4(ByVal Mydealer As String, ByVal mNorangka As String)
        Dim mpServer As String = "MyConnCloudDnet" & Mydealer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = "SELECT * " & "FROM TRXN_OPT,DATA_STANDARD WHERE OPT_NoRangka ='" & mNorangka & "' AND OPT_CdAssesoris=STANDARD_Kode AND NOT(STANDARD_Biaya='A' OR STANDARD_Biaya='O' OR STANDARD_Biaya='M' OR STANDARD_Biaya='N' OR STANDARD_Biaya='P')"
        Call Msg_err("", 0)

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    Do
                        Call isikolomAksesoris(MyRecReadA("STANDARD_Nama"), "T")
                    Loop While MyRecReadA.Read
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Sub


    Sub isikolomAksesoris(ByVal mnilai As String, ByVal mGroup As String)
        mnilai = Trim(Left(mnilai, 15))
        mnilai = CariisikolomAksesoris(mnilai)
        If mnilai = "" Then Exit Sub

        If LblCetakDO_Ass11.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass11.Text = mnilai
        ElseIf LblCetakDO_Ass12.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass12.Text = mnilai
        ElseIf LblCetakDO_Ass13.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass13.Text = mnilai
        ElseIf LblCetakDO_Ass14.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass14.Text = mnilai
        ElseIf LblCetakDO_Ass21.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass21.Text = mnilai
        ElseIf LblCetakDO_Ass22.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass22.Text = mnilai
        ElseIf LblCetakDO_Ass23.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass23.Text = mnilai
        ElseIf LblCetakDO_Ass24.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass24.Text = mnilai
        ElseIf LblCetakDO_Ass31.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass31.Text = mnilai
        ElseIf LblCetakDO_Ass32.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass32.Text = mnilai
        ElseIf LblCetakDO_Ass33.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass33.Text = mnilai
        ElseIf LblCetakDO_Ass34.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass34.Text = mnilai
        ElseIf LblCetakDO_Ass41.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass41.Text = mnilai
        ElseIf LblCetakDO_Ass42.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass42.Text = mnilai
        ElseIf LblCetakDO_Ass43.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass43.Text = mnilai
        ElseIf LblCetakDO_Ass44.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass44.Text = mnilai
        ElseIf LblCetakDO_Ass51.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass51.Text = mnilai
        ElseIf LblCetakDO_Ass52.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass52.Text = mnilai
        ElseIf LblCetakDO_Ass53.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass53.Text = mnilai
        ElseIf LblCetakDO_Ass54.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass54.Text = mnilai
        ElseIf LblCetakDO_Ass61.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass61.Text = mnilai
        ElseIf LblCetakDO_Ass62.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass62.Text = mnilai
        ElseIf LblCetakDO_Ass63.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass63.Text = mnilai
        ElseIf LblCetakDO_Ass64.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass64.Text = mnilai
        ElseIf LblCetakDO_Ass71.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass71.Text = mnilai
        ElseIf LblCetakDO_Ass72.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass72.Text = mnilai
        ElseIf LblCetakDO_Ass73.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass73.Text = mnilai
        ElseIf LblCetakDO_Ass74.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass74.Text = mnilai
        ElseIf LblCetakDO_Ass81.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass81.Text = mnilai
        ElseIf LblCetakDO_Ass82.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass82.Text = mnilai
        ElseIf LblCetakDO_Ass23.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass83.Text = mnilai
        ElseIf LblCetakDO_Ass84.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass84.Text = mnilai
        ElseIf LblCetakDO_Ass91.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass91.Text = mnilai
        ElseIf LblCetakDO_Ass92.Text = "" And mGroup = "S" Then
            LblCetakDO_Ass92.Text = mnilai
        ElseIf LblCetakDO_Ass93.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass93.Text = mnilai
        ElseIf LblCetakDO_Ass94.Text = "" And mGroup = "T" Then
            LblCetakDO_Ass94.Text = mnilai
        End If
    End Sub

    Function CariisikolomAksesoris(ByVal mpnilai As String) As String
        CariisikolomAksesoris = mpnilai
        If LblCetakDO_Ass11.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass12.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass13.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass14.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass21.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass22.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass23.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass24.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass31.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass32.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass33.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass34.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass41.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass42.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass43.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass44.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass51.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass52.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass53.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass54.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass61.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass62.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass63.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass64.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass71.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass72.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass73.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass74.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass81.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass82.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass23.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass84.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass91.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass92.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass93.Text = mpnilai Then
            CariisikolomAksesoris = ""
        ElseIf LblCetakDO_Ass94.Text = mpnilai Then
            CariisikolomAksesoris = ""
        End If
    End Function




    Sub isikolomAksesorisClear()
        LblCetakDO_Ass11.Text = "" : LblCetakDO_Ass12.Text = "" : LblCetakDO_Ass13.Text = "" : LblCetakDO_Ass14.Text = ""
        LblCetakDO_Ass21.Text = "" : LblCetakDO_Ass22.Text = "" : LblCetakDO_Ass23.Text = "" : LblCetakDO_Ass24.Text = ""
        LblCetakDO_Ass31.Text = "" : LblCetakDO_Ass32.Text = "" : LblCetakDO_Ass33.Text = "" : LblCetakDO_Ass34.Text = ""
        LblCetakDO_Ass41.Text = "" : LblCetakDO_Ass42.Text = "" : LblCetakDO_Ass43.Text = "" : LblCetakDO_Ass44.Text = ""
        LblCetakDO_Ass51.Text = "" : LblCetakDO_Ass52.Text = "" : LblCetakDO_Ass53.Text = "" : LblCetakDO_Ass54.Text = ""
        LblCetakDO_Ass61.Text = "" : LblCetakDO_Ass62.Text = "" : LblCetakDO_Ass63.Text = "" : LblCetakDO_Ass64.Text = ""
        LblCetakDO_Ass71.Text = "" : LblCetakDO_Ass72.Text = "" : LblCetakDO_Ass73.Text = "" : LblCetakDO_Ass74.Text = ""
        LblCetakDO_Ass81.Text = "" : LblCetakDO_Ass82.Text = "" : LblCetakDO_Ass83.Text = "" : LblCetakDO_Ass84.Text = ""
        LblCetakDO_Ass91.Text = "" : LblCetakDO_Ass92.Text = "" : LblCetakDO_Ass93.Text = "" : LblCetakDO_Ass94.Text = ""
    End Sub

    Function HurufNumeric(ByRef mNilai As Object) As String
        Dim mPos1 As Byte
        Dim mPos2 As Byte
        Dim mLength As Byte
        Dim ulangan As Byte
        Dim ulangi As Byte
        Dim mSatuan1 As String
        Dim mSatuan2 As String
        Dim mAngka As String
        Dim mChar As String
        Dim mDec As String
        Dim mTextNumeric As String
        mTextNumeric = mNilai
        If Not IsNumeric(mTextNumeric) Then
            HurufNumeric = "BUKAN ANGKA " : Exit Function
        ElseIf Val(mTextNumeric) = 0 Then
            HurufNumeric = "NOL " : Exit Function
        Else

            mDec = ""
            If Left(mTextNumeric, 1) = "-" Then mTextNumeric = Mid(mTextNumeric, 2, Len(mTextNumeric) - 1)
            If InStr(1, mTextNumeric, ".") <> 0 Then
                mDec = Right(mTextNumeric, Len(mTextNumeric) - InStr(1, mTextNumeric, "."))
                mTextNumeric = Left(mTextNumeric, InStr(1, mTextNumeric, ".") - 1)
            End If
            HurufNumeric = "" : mSatuan2 = ""
            ulangi = IIf(mDec = "", 1, 2)
            For ulangan = 1 To ulangi
                If ulangan = 2 Then
                    mTextNumeric = mDec
                End If
                mLength = Len(mTextNumeric)
                mPos1 = 1
                While mPos1 <= mLength
                    mSatuan1 = ""
                    If (mLength - mPos1 - 8) > 0 Then
                        mSatuan1 = "Milliar" : mPos2 = (mLength - mPos1 - 8)
                    ElseIf (mLength - mPos1 - 5) > 0 Then
                        mSatuan1 = "Juta" : mPos2 = (mLength - mPos1 - 5)
                    ElseIf (mLength - mPos1 - 2) > 0 Then
                        mSatuan1 = "Ribu" : mPos2 = (mLength - mPos1 - 2)
                        If CDbl(Mid(mTextNumeric, mPos1, 1)) = 1 And mPos2 = 1 Then mSatuan1 = "Seribu"
                    Else
                        mPos2 = (mLength - mPos1 + 1)
                    End If
                    If Val(Mid(mTextNumeric, mPos1, mPos2)) > 0 Then
                        If mSatuan1 = "Seribu" Then
                            mPos2 = 0 : mPos1 = mPos1 + 1
                        End If
                        While mPos2 <> 0
                            mChar = Mid(mTextNumeric, mPos1, 1)
                            mAngka = ""
                            Select Case mChar
                                Case "1" : mAngka = IIf(mSatuan2 = "Belas", "Sebelas", "Satu")
                                Case "2" : mAngka = IIf(mSatuan2 = "Belas", "Dua Belas", "Dua")
                                Case "3" : mAngka = IIf(mSatuan2 = "Belas", "Tiga Belas", "Tiga")
                                Case "4" : mAngka = IIf(mSatuan2 = "Belas", "Empat Belas", "Empat")
                                Case "5" : mAngka = IIf(mSatuan2 = "Belas", "Lima Belas", "Lima")
                                Case "6" : mAngka = IIf(mSatuan2 = "Belas", "Enam Belas", "Enam")
                                Case "7" : mAngka = IIf(mSatuan2 = "Belas", "Tujuh Belas", "Tujuh")
                                Case "8" : mAngka = IIf(mSatuan2 = "Belas", "Delapan Belas", "Delapan")
                                Case "9" : mAngka = IIf(mSatuan2 = "Belas", "Sembilan Belas", "Sembilan")
                                Case "0" : mAngka = IIf(mSatuan2 = "Belas", "Sepuluh", "")
                            End Select
                            mSatuan2 = ""
                            If mChar <> "0" Then
                                If mPos2 = 3 Then
                                    If mChar = "1" Then
                                        mSatuan2 = "Seratus" : mAngka = ""
                                    Else
                                        mSatuan2 = "Ratus"
                                    End If
                                ElseIf mPos2 = 2 Then
                                    If mChar = "1" Then
                                        mSatuan2 = "Belas"
                                    Else
                                        mSatuan2 = "Puluh"
                                    End If
                                End If
                            End If
                            If mSatuan2 <> "Belas" Then
                                HurufNumeric = Trim(HurufNumeric) & " " & Trim(mAngka) & " " & Trim(mSatuan2)
                            End If
                            mPos1 = mPos1 + 1
                            mPos2 = mPos2 - 1
                        End While
                        HurufNumeric = Trim(HurufNumeric) & " " & Trim(mSatuan1)
                    Else
                        mPos1 = mPos1 + 3
                    End If
                End While
                If ulangan = 2 Then
                    HurufNumeric = UCase(HurufNumeric) & "SEN"
                Else
                    If HurufNumeric <> "" Then
                        HurufNumeric = UCase(HurufNumeric) & "RUPIAH"
                    End If
                End If
            Next
        End If
    End Function



    Protected Sub BtnBBM1Clr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBBM1Clr.Click
        TxtNoVcrBBM.Text = "" : LblBBMTg.Text = "" : DDListBBMTp.SelectedIndex = 0 : LblBBMJm.Text = "" : TxtBBMCt.Text = ""
        BtnBBM2Add.Visible = True
        DDListBBMTp.Enabled = True
    End Sub
    Protected Sub BtnBBM2add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBBM2Add.Click
        If Mid(lblAkses.Text, 9, 1) = "1" And DDListBBMTp.Text = "CUSTOMER" Then
            Call UpdateSTOKBBM(1, TxtNoVcrBBM.Text, DDListBBMTp.Text)
        ElseIf Mid(lblAkses.Text, 13, 1) = "1" And DDListBBMTp.Text <> "CUSTOMER" Then
            Call UpdateSTOKBBM(1, TxtNoVcrBBM.Text, DDListBBMTp.Text)
        Else
            Call Msg_err("TIDAK DIIJINKAN UNTUK MEMBUAT VOUCHER BBM", 0)
        End If
    End Sub
    Protected Sub BtnBBM3Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBBM3Del.Click
        If Mid(lblAkses.Text, 10, 1) = "1" And DDListBBMTp.Text = "CUSTOMER" Then
            Call UpdateSTOKBBM(0, TxtNoVcrBBM.Text, DDListBBMTp.Text)
        ElseIf Mid(lblAkses.Text, 14, 1) = "1" And DDListBBMTp.Text <> "CUSTOMER" Then
            Call UpdateSTOKBBM(0, TxtNoVcrBBM.Text, DDListBBMTp.Text)
        Else
            Call Msg_err("TIDAK DIIJINKAN UNTUK MEMBUAT VOUCHER BBM", 0)
        End If

    End Sub
    Protected Sub BtnBBM4Fil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBBM4Fil.Click
        MultiViewCetak.ActiveViewIndex = 0
        lblCetakBBMCompany.Text = "PT MITRAUSAHA GENTANIAGA"
        lblCetakBBMCompany1.Text = "HONDA MUGEN"
        lblCetakBBMCompany2.Text = "VOUCHER BBM"
        Call GETType_CetakBBM(TxtNoVcrBBM.Text)
        lblCetakBBMIsiColf1.Text = "Jakarta," & Format(Now(), "dd/MM/yyyy")
    End Sub


    Protected Sub BtnAlmKirim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAlmKirim.Click
        ButtonCariTTK0.Visible = False
        If GETPERMOHONAN_DATA_ALAMAT_SPK_TUJUAN("STOCKA_NORANGKA='" & TxtNoRangka.Text & "'", "") <> 1 Then
            GETPERMOHONAN_DATA_ALAMAT_SPK("STOCKAKP_NORANGKA='" & TxtNoRangka.Text & "'", "", "")
        End If
    End Sub

    Protected Sub BtnSPKKirim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSPKKirim.Click
        Call GETPERMOHONAN_DATA_ALAMAT_ACTUAL_BASED_SPK(TxtNoRangka.Text, "SPK", LblCdBranch.Text)
    End Sub
    Protected Sub BtnSTNKirim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSTNKirim.Click
        Call GETPERMOHONAN_DATA_ALAMAT_ACTUAL_BASED_SPK(TxtNoRangka.Text, "STNK", LblCdBranch.Text)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        MultiViewWarehouse.ActiveViewIndex = 5
    End Sub


    Protected Sub DropDownListJnsKirim_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListJnsKirim.SelectedIndexChanged
        If LblKirimNo.Text = "" Then
            LblKirimJenis.Text = DropDownListJnsKirim.Text
        Else
            Call Msg_err("Tidak Bisa dirubah hanya bisa dibatalkan", 0)
        End If
    End Sub

    Function DtFr(ByRef mNilai As Object) As String
        On Error GoTo ErrHand
        DtFr = ""
        If IsDate(mNilai) Then
            DtFr = Format(CDate(mNilai), "dd-MM-yy")
        End If
ErrHand:
    End Function

    Protected Sub BtnValidNotOkHead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnValidNotOkHead.Click
        If Mid(lblAkses.Text, 19, 1) = "1" Then
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCK SET STOCK_ValidUser='" & LblUserName.Text & "',STOCK_ValidTgl=GETDATE() WHERE STOCK_NOTTK='" & TxtNoTTK.Text & "' AND STOCK_ValidTgl IS NULL ", "", 1) = 1 Then
                LblPeriksaUser.Text = LblUserName.Text : LblPeriksaTgl.Text = Now()
            End If
        Else
            Call Msg_err("Tidak di perbolehkan merubah data", 1)
        End If
    End Sub

    Protected Sub BtnValidOkHead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnValidOkHead.Click
        If Mid(lblAkses.Text, 19, 1) = "1" Then
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCK SET STOCK_ValidUser='',STOCK_ValidTgl=NULL WHERE STOCK_NOTTK='" & TxtNoTTK.Text & "' AND STOCK_ValidTgl IS NOT NULL ", "", 1) = 1 Then
                LblPeriksaUser.Text = "" : LblPeriksaTgl.Text = ""
            End If
        Else
            Call Msg_err("Tidak di perbolehkan merubah data", 1)
        End If
    End Sub

End Class
