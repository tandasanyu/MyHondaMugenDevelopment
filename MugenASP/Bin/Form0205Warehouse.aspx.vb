Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Imports System.Web.Security


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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If

        mSaveButon = 0
        If LblUserName.Text = "" Then
            Dim x As String
            Dim mFound As Byte = 0
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = x.ToString

            mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0108'")
            lblAkses.Text = "1111111111111111111"
            '    SelectCommand = "SELECT * FROM TRXN_STOCKMKIRIM LEFT OUTER JOIN TRXN_STOCK ON TRXN_STOCKMKIRIM.STOCKM_NORANGKA = TRXN_STOCK.STOCK_NoRangka LEFT OUTER JOIN TRXN_STOCKKKIRIM ON TRXN_STOCK.STOCK_NoRangka = TRXN_STOCKKKIRIM.STOCKK_NORANGKA WHERE (TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM = ?)"
            '    <asp:ControlParameter ControlID="txtDate" Name="STOCKM_TGLMOHONKIRIM" PropertyName="Text" Type="String" />

            Call ClearFrom()
            Call GetSupir_TTK()
            If mFound = 0 Then
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub

    Protected Sub BtnCal1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCal1.Click
        [Calendar1].Visible = IIf([Calendar1].Visible = True, False, True)
    End Sub
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar1].SelectionChanged, Calendar1.SelectionChanged
        txtDate.Text = [Calendar1].SelectedDate.ToString
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

    Protected Sub BtnCal8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall8.Click
        [Calendar8].Visible = IIf([Calendar8].Visible = True, False, True)
    End Sub
    Protected Sub Calendar8_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar8].SelectionChanged, Calendar8.SelectionChanged
        TxttglKeluar.Text = [Calendar8].SelectedDate.ToString
        [Calendar8].Visible = False
    End Sub

    Protected Sub BtnCal9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall9.Click
        [Calendar9].Visible = IIf([Calendar9].Visible = True, False, True)
    End Sub
    Protected Sub Calendar9_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar9].SelectionChanged, Calendar9.SelectionChanged
        TxttglKeluar.Text = [Calendar9].SelectedDate.ToString
        [Calendar9].Visible = False
    End Sub

    Protected Sub BtnCal10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall10.Click
        [Calendar10].Visible = IIf([Calendar10].Visible = True, False, True)
    End Sub
    Protected Sub Calendar10_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar10].SelectionChanged, Calendar10.SelectionChanged
        TxttglKeluar.Text = [Calendar10].SelectedDate.ToString
        [Calendar10].Visible = False
    End Sub

    Protected Sub BtnCal11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall11.Click
        [Calendar11].Visible = IIf([Calendar11].Visible = True, False, True)
    End Sub
    Protected Sub Calendar11_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar11].SelectionChanged, Calendar11.SelectionChanged
        TxttglKeluar.Text = [Calendar11].SelectedDate.ToString
        [Calendar11].Visible = False
    End Sub

    Protected Sub BtnCal12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall12.Click
        [Calendar12].Visible = IIf([Calendar12].Visible = True, False, True)
    End Sub
    Protected Sub Calendar12_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar12].SelectionChanged, Calendar12.SelectionChanged
        TxttglKeluar.Text = [Calendar12].SelectedDate.ToString
        [Calendar12].Visible = False
    End Sub

    Protected Sub BtnCal13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall13.Click
        [Calendar13].Visible = IIf([Calendar13].Visible = True, False, True)
    End Sub
    Protected Sub Calendar13_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar13].SelectionChanged, Calendar13.SelectionChanged
        TxttglKeluar.Text = [Calendar13].SelectedDate.ToString
        [Calendar13].Visible = False
    End Sub

    Protected Sub BtnCal14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCall14.Click
        [Calendar14].Visible = IIf([Calendar14].Visible = True, False, True)
    End Sub
    Protected Sub Calendar14_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar14].SelectionChanged, Calendar14.SelectionChanged
        TxttglKeluar.Text = [Calendar14].SelectedDate.ToString
        [Calendar14].Visible = False
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


    Sub GETSTOCK_GETTTK(ByVal mSearchTxt As String)
        Call GETSTOCK_DataStock(mSearchTxt, "")
        If TxtNoRangka.Text <> "" Then
            Call FIND_STOCKDOSUPLIER("STOCKDO_NORANGKA='" & UCase(TxtNoRangka.Text) & "' ", "")
            Call GETPERMOHONAN_DATA_SPK("STOCKM_NORANGKA='" & TxtNoRangka.Text & "'", "")
            Call GETPROSES_DATA_KIRIM("STOCKK_NORANGKA='" & TxtNoRangka.Text & "'", "")
            Call GETVOUCHER_DATA_BBM("STOCKV_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKV_TGLBATAL IS NULL", "")
            Call GETVOUCHER_DATA_AKSESORIS("STOCKA_NORANGKA='" & TxtNoRangka.Text & "'", "")
            If GETPERMOHONAN_DATA_ALAMAT_SPK_TUJUAN("STOCKA_NORANGKA='" & TxtNoRangka.Text & "'", "") <> 1 Then
                GETPERMOHONAN_DATA_ALAMAT_SPK("STOCKAKP_NORANGKA='" & TxtNoRangka.Text & "'", "")
            End If
            Call GETPERMOHONAN_DATA_ALAMAT_SPK2("STOCKAKP_NORANGKA='" & TxtNoRangka.Text & "'", "")


            Call GETWO_PERBAIKAN("ASSREPAIR_NORANGKA='" & TxtNoRangka.Text & "'", "")
            Call Get_Data_Warna_dan_type(TxtNoRangka.Text, "")

            Call Get_HistoryDealer_CrossSell(TxtNoRangka.Text, "")

            Call GETSTOCK_STCKRANGKA("STCK_NORANGKA='" & TxtNoRangka.Text & "'", "")
            Multi03Stok.ActiveViewIndex = 0
        End If
    End Sub



    Function GETSTOCK_DataStock(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = ""
        mSqlCommadstring = "SELECT *, " & _
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

                    TxtDTglDO.Text = nSr(MyRecReadA("STOCK_TglAuto"))
                    TxtNoDO.Text = nSr(MyRecReadA("STOCK_DoAuto"))
                    TxtDtglSuratJln.Text = nSr(MyRecReadA("STOCK_TglSJ"))
                    TxtcdLokasi.Text = nSr((MyRecReadA("STOCK_CdLokasi")))
                    lblcdLokasiTag.Text = TxtcdLokasi.Text
                    NamaLokasi.Text = nSr((MyRecReadA("NamaLokasi")))
                    Kodedealer.Text = nSr((MyRecReadA("Kodedealer")))
                    LblStatus.Text = "STATUS:" & nSr((MyRecReadA("STOCK_StsUpdate"))) & " / " & _
                                              "TANGGAL:" & nSr((MyRecReadA("STOCK_TglUpdate"))) & " / " & _
                                              "BERITA:" & nSr((MyRecReadA("STOCK_BERITA")))

                    TxtTglKirimMgn.Text = nSr((MyRecReadA("STOCK_KIRIMMUGENTGL")))
                    TxtNotKirimMgn.Text = nSr((MyRecReadA("STOCK_KIRIMMUGENKODE")))
                    TxtTglBukuSvc.Text = nSr((MyRecReadA("STOCK_BUKUSERVICE")))
                    TxtBukuSvc.Text = ""
                    TxtPDISPK.Text = nSr((MyRecReadA("STOCK_NOSPK")))
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
                                    "(SELECT DRIVER_NAMA FROM DATA_DRIVER,TRXN_STOCKKKIRIM WHERE DRIVER_KODE=STOCKK_DRIVER AND STOCKK_NORANGKA=STOCKM_NORANGKA) AS NamaDRIVE," & _
                                    "(SELECT STOCKK_DRIVER FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) AS KodeDRIVE," & _
                                    "(SELECT STOCKK_KIRIMTGLKIRIM FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) AS TanggalSPJ," & _
                                    "(SELECT STOCKK_KIRIMTGLTERIMA FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) AS TanggalTerima," & _
                                    "(SELECT STOCKK_KIRIMKETTERIMA FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) AS KeteranganTerima " & _
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
                    lblnospk.Text = nSr((MyRecReadA("STOCK_NOSPK")))
                    lblNoDO.Text = nSr((MyRecReadA("STOCK_DoDealer")))
                    LblSalesman.Text = nSr(MyRecReadA("STOCKM_SALES"))
                    lbllease.Text = nSr((MyRecReadA("STOCKM_LEASE")))

                    TxtBerita.Text = nSr((MyRecReadA("STOCKM_BERITA")))
                    TxtTglAdmin.Text = nSr((MyRecReadA("STOCKM_TGLMOHONKIRIM")))
                    TxtUsrAdmin.Text = nSr((MyRecReadA("STOCKM_USER")))
                    TxttglKirimSetujui.Text = nSr((MyRecReadA("STOCKM_KIRIMTGLSETUJUI")))
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
        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        GETPROSES_DATA_KIRIM = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    DropDownList2.Text = nSr((MyRecReadA("STOCKK_DRIVER")))
                    lblNmSupir.Text = nSr((MyRecReadA("NamaDRIVE")))
                    If TxttglKirimSetujui.Text = "" Then
                        TxttglKirimSetujui.Text = TxtTglAdmin.Text
                    End If
                    If nSr((MyRecReadA("STOCKK_KIRIMTGLPDI"))) <> "" Then
                        TxttglPDI.Text = ((MyRecReadA("STOCKK_KIRIMTGLPDI")))
                        TxttglPDINote.Text = ""
                    End If
                    If nSr((MyRecReadA("STOCKK_KIRIMTGLKIRIM"))) <> "" Then
                        TxttglKeluar.Text = ((MyRecReadA("STOCKK_KIRIMTGLKIRIM")))
                        TxttglKeluarNote.Text = ""
                    End If
                    If nSr((MyRecReadA("STOCKK_KIRIMTGLSECURITY"))) <> "" Then
                        TxtTglSecurity.Text = ((MyRecReadA("STOCKK_KIRIMTGLSECURITY")))
                        TxtTglSecurityNote.Text = nSr((MyRecReadA("STOCKK_KIRIMKETSECURITY")))
                    End If
                    'If nSr((MyRecReadA("STOCKK_KIRIMTGLBATAL"))) <> "" Then
                    'TxtTglBatal.Text = ((MyRecReadA("STOCKK_KIRIMTGLBATAL")))
                    'End If
                    If nSr((MyRecReadA("STOCKK_KIRIMTGLTERIMA"))) <> "" Then
                        TxttglTerima.Text = ((MyRecReadA("STOCKK_KIRIMTGLTERIMA")))
                        TxttglTerimaNote.Text = ((MyRecReadA("STOCKK_KIRIMKETTERIMA")))
                    End If
                    'If nSr((MyRecReadA("STOCKK_KIRIMTGLCATAT"))) <> "" Then
                    'TabelEdit.Items.Item(9).SubItems(1).Text = ((MyRecReadA("STOCKK_KIRIMTGLCATAT")))
                    'End If
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
        Call Msg_err("", 0)
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
                        If nSr((MyRecReadA("STOCKV_CRSELL"))) <> "S" Then
                            LblBBMVcr.Text = nSr((MyRecReadA("STOCKV_NOBBM")))
                            LblBBMNilai.Text = nSr((MyRecReadA("STOCKV_NILAI")))
                        Else
                            LblBBMCSVcr.Text = nSr((MyRecReadA("STOCKV_NOBBM")))
                            LblBBMCSNil.Text = nSr((MyRecReadA("STOCKV_NILAI")))
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

        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        GETPERMOHONAN_DATA_ALAMAT_SPK_TUJUAN = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    TxtNama.Text = nSr((MyRecReadA("STOCKA_NAMA")))
                    TxtAlamat.Text = nSr((MyRecReadA("STOCKA_ALAMAT")))
                    TxtKota.Text = nSr((MyRecReadA("STOCKA_KOTA")))
                    TxtNoHP.Text = nSr((MyRecReadA("STOCKA_PH")))
                    TxtPhone.Text = nSr((MyRecReadA("STOCKA_HP")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function GETPERMOHONAN_DATA_ALAMAT_SPK(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
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
                    TxtNama.Text = nSr((MyRecReadA("STOCKA_NAMA")))
                    TxtAlamat.Text = nSr((MyRecReadA("STOCKA_ALAMAT")))
                    TxtKota.Text = nSr((MyRecReadA("STOCKA_KOTA")))
                    TxtNoHP.Text = nSr((MyRecReadA("STOCKA_PH")))
                    TxtPhone.Text = nSr((MyRecReadA("STOCKA_HP")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Function GETPERMOHONAN_DATA_ALAMAT_SPK2(ByVal mSearchTxt As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String = ""
        mSearchTxt = IIf(mSearchTxt = "", "", " WHERE ") & mSearchTxt
        mSqlCommadstring = "SELECT * FROM TRXN_STOCKAKIRIMP " & mSearchTxt & " "
        Call Msg_err("", 0)
        'GetData_IsiField = "UnReg"
        GETPERMOHONAN_DATA_ALAMAT_SPK2 = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    LblIdSTNK.Text = nSr((MyRecReadA("STOCKAKP_SNAMA"))) & "     ALAMAT :  " & _
                                     nSr((MyRecReadA("STOCKAKP_SALAMAT"))) & " " & nSr((MyRecReadA("STOCKAKP_SKOTA"))) & _
                                     "     TELP : " & nSr((MyRecReadA("STOCKAKP_SPH"))) & " / " & nSr((MyRecReadA("STOCKAKP_SHP")))

                    LblIdSPK.Text = nSr((MyRecReadA("STOCKAKP_PNAMA"))) & "     ALAMAT :  " & _
                                    nSr((MyRecReadA("STOCKAKP_PALAMAT"))) & " " & nSr((MyRecReadA("STOCKAKP_PKOTA"))) & _
                                    "     TELP : " & nSr((MyRecReadA("STOCKAKP_PPH"))) & " / " & nSr((MyRecReadA("STOCKAKP_PHP")))
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

    Function UpdateSTOKBBM(ByRef mTYPE As Object, ByRef mCrossSell As String) As Byte
        Dim mNoBBM As String
        Dim mJumlah As Double
        Dim mFindNoVcr As Byte
        Dim myalasanku As String
        Dim MySTRsql1 As String
        UpdateSTOKBBM = 0 : MySTRsql1 = ""

        If mTYPE = 0 Then 'Batal Voucher
            myalasanku = ""
            If GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCKVKIRIM WHERE STOCKV_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKV_TGLBATAL IS NULL AND (STOCKV_ST ='B')", "", 0) = 1 Then
                If mCrossSell = "S" Then
                    If LblBBMCSAlasan.Visible = False Then
                        Msg_err("NOMOR RANGKA INI SUDAH PERNAH DIBAYARKAN BBM-NYA (KLAIM LEBIH DARI DUA KALI ALASAN DIBATALKAN DI KOTAK YANG SUDAH DISEDIAKAN", 1)
                        LblBBMCSAlasan.Text = "IS ALASAN DI SINI"
                        LblBBMCSAlasan.Visible = True : LblBBMCSVcr.Visible = False : LblBBMCSNil.Visible = False
                        Exit Function
                    Else
                        LblBBMCSAlasan.Visible = False : LblBBMCSVcr.Visible = True : LblBBMCSNil.Visible = True
                        myalasanku = LblBBMCSAlasan.Text
                    End If
                Else
                    If LblBBMAlasan.Visible = False Then
                        Msg_err("NOMOR RANGKA INI SUDAH PERNAH DIBAYARKAN BBM-NYA (KLAIM LEBIH DARI DUA KALI ALASAN DIBATALKAN DI KOTAK YANG SUDAH DISEDIAKAN", 1)
                        LblBBMAlasan.Text = "IS ALASAN DI SINI"
                        LblBBMAlasan.Visible = True : LblBBMVcr.Visible = False : LblBBMNilai.Visible = False
                        Exit Function
                    Else
                        LblBBMAlasan.Visible = False : LblBBMVcr.Visible = True : LblBBMNilai.Visible = True
                        myalasanku = LblBBMAlasan.Text
                    End If
                End If
                If myalasanku <> "" Then
                    Call UpdateDatabase_Tabel("INSERT INTO TRXN_STOCKHISTORY (STOCKH_NORANGKA,STOCKH_TANGGAL,STOCKH_STATUS,STOCKH_HISTORY,STOCKH_USER)  VALUES (" & _
                                    "'" & TxtNoRangka.Text & "',GETDATE(),'VB','" & myalasanku & "','" & LblUserName.Text & "')", "", 1)
                End If
            Else
                myalasanku = "OKE"
            End If

            If myalasanku <> "" Then
                MySTRsql1 = "UPDATE TRXN_STOCKVKIRIM SET STOCKV_TGLBATAL=GETDATE() WHERE STOCKV_NORANGKA='" & TxtNoRangka.Text & "' AND STOCKV_TGLBATAL IS NULL"
                If UpdateDatabase_Tabel(MySTRsql1, "", 0) <> 1 Then
                    Msg_err("UPDATE VOUCHER BBM ERROR", 1)
                Else
                    LblBBMVcr.Text = "" : LblBBMNilai.Text = ""
                    LblBBMCSVcr.Text = "" : LblBBMCSNil.Text = ""
                End If
            End If
        ElseIf (LblBBMVcr.Text = "" And mCrossSell = "") Or _
               (LblBBMCSVcr.Text = "" And mCrossSell = "S") Then 'Buat Baru Voucher

            mJumlah = 0 : mNoBBM = "" : mFindNoVcr = 0

            mNoBBM = GetDataD_IsiField("SELECT STOCKV_NOBBM as IsiField FROM TRXN_STOCKVKIRIM WHERE STOCKV_TGLBATAL IS NULL AND STOCKV_NORANGKA = '" & TxtNoRangka.Text & "'", "", 0)
            If mNoBBM <> "" Then
                mFindNoVcr = 1
            Else
                mNoBBM = GetDataD_IsiField("SELECT TYPE_CdGroup as IsiField FROM DATA_TYPE,TRXN_STOCK WHERE STOCK_CdType=TYPE_Type AND STOCK_NORANGKA='" & Trim(TxtNoRangka.Text) & "'", "", 0)
                mNoBBM = mNoBBM & GetDataD_IsiField("SELECT TYPE_CC as IsiField FROM DATA_TYPE,TRXN_STOCK WHERE STOCK_CdType=TYPE_Type AND STOCK_NORANGKA='" & Trim(TxtNoRangka.Text) & "'", "", 0)

                mJumlah = GetDataD_IsiField("SELECT PARAMETER_NILAI FROM DATA_PARAMETER WHERE PARAMETER_NAMA='VBBM" & mCrossSell & mNoBBM & "'", "", 0)

                If mJumlah > 0 Then
                    Dim mNovcrNew As String
                    mNovcrNew = GetDataD_IsiField("SELECT MAX(STOCKV_NOBBM) as mNovcr FROM TRXN_STOCKVKIRIM WHERE SUBSTRING(STOCKV_NOBBM,1,7)='" & Format(Now(), "YYMMDD") & "V'", "", 0)

                    If mNovcrNew = "" Then
                        mNoBBM = Format(Now(), "YYMMDD") & "V01"
                    Else
                        mNoBBM = Mid(mNovcrNew, 1, 7) & Format(Val(Mid(mNovcrNew, 8, 2)) + 1, "0#")
                    End If
                End If
            End If

            If mNoBBM <> "" Then
                If mFindNoVcr = 0 Then
                    MySTRsql1 = "INSERT INTO TRXN_STOCKVKIRIM(STOCKV_NORANGKA,STOCKV_NOBBM,STOCKV_NILAI,STOCKV_TGLBATAL,STOCKV_ST,STOCKV_CRSELL) VALUES " & _
                                "('" & TxtNoRangka.Text & "','" & mNoBBM & "'," & mJumlah & ",NULL,'','" & mCrossSell & "')"
                    If UpdateDatabase_Tabel(MySTRsql1, "", 1) = 1 Then
                        If mCrossSell <> "S" Then
                            LblBBMVcr.Text = mNoBBM
                            LblBBMNilai.Text = ndb(mJumlah)
                        Else
                            LblBBMCSVcr.Text = mNoBBM
                            LblBBMCSNil.Text = ndb(mJumlah)
                        End If
                    End If
                    'Call cetakBBM(TxtNoRangka.Text, mNoBBM)
                Else
                    Msg_err("SUDAH DIBUATKAN VOUCHER BBM NO " & mNoBBM, 1)
                End If
            End If
            'Buat Cetak ulang Voucher
        ElseIf LblBBMVcr.Text <> "" And mCrossSell <> "S" Then
            'Call cetakBBM(TxtNoRangka.Text, LblBBMVcr.Text)
        ElseIf LblBBMCSVcr.Text <> "" And mCrossSell = "S" Then
            'Call cetakBBM(TxtNoRangka.Text, LblBBMCSVcr.Text)
        End If
    End Function



    Function Data_Pengiriman(ByVal mNorangka As String) As Byte
        Dim mCariTxt As String
        Data_Pengiriman = 0
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
            Data_Pengiriman = GetDataD_00NoFound01Found(mCariTxt, "", 1)
            If Data_Pengiriman <> 1 Then
                'If FIND_MohonKirim("DATEDIFF(minute,STOCKM_TGLMOHONKIRIM,'" & FieldTgl(TxtTglAdmin.Text) & "') < 0 AND " & _
                '                  "DATEDIFF(day,STOCKM_TGLMOHONKIRIM,'" & FieldTgl(TxtTglAdmin.Text) & "') = 0 AND " & _
                '                  "STOCKM_NORANGKA='" & TxtNoRangka.Text & "' AND " & _
                '                  "(SELECT STOCKK_NORANGKA FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA=STOCKM_NORANGKA) IS NULL", "STOCKM_NORANGKA", 0) = 1 Then
                'If simpanALsan("S", "ADA TANGGAL PERMOHONAN KIRIM KENDARAAN SEBELUMNYA YANG BELUM DIISI SUPIR" & Chr(13) & _
                '               "JIKA INGIN MENDAHULU DARI TANGGAL PERMOHONAN" & Chr(13) & _
                '               "ISIKAN ALASANNYA", "ISI DRIVER") <> 1 Then mInputDriver = 0
                'End If
                Data_Pengiriman = UpdateDatabase_Tabel("INSERT INTO TRXN_STOCKKKIRIM (STOCKK_NORANGKA,STOCKK_STATUS) VALUES ('" & mNorangka & "','')", "", 1)
                If Data_Pengiriman = 1 Then
                    TxttglKirimSetujui.Text = TxtTglAdmin.Text
                    Call UpdateDatabase_Tabel("UPDATE TRXN_STOCKMKIRIM SET STOCKM_KIRIMTGLSETUJUI=" & FieldTgl(TxtTglAdmin.Text) & " WHERE STOCKM_NORANGKA='" & mNorangka & "'", "", 1)
                End If
            End If
        Else
            Msg_err("DATA TIDAK BISA DISIMPAN DATA PERMOHONAN TIDAK ADA ", 1)
        End If
        If Data_Pengiriman = 0 Then
            Msg_err("DATA TIDAK TERSIMPAN (CALL IT)", 1)
        End If
    End Function

    Function Simpan_Supir(ByVal mStatus As Byte) As Byte
        Simpan_Supir = 0
        If TxtTglBatal.Text <> "" Then
            Msg_err("SUPIR TIDAK BISA DIRUBAH KARENA SUDAH DIBATALKAN PENGIRIMANNYA", 1) : Exit Function
        ElseIf TxttglTerima.Text <> "" Then
            Msg_err("SUPIR TIDAK BISA DIRUBAH KARENA KENDARAAN SUDAH DITERIMA", 1) : Exit Function
        ElseIf TxttglKeluar.Text <> "" Then
            Msg_err("SUPIR TIDAK BISA DIRUBAH KARENA SUPIR TIDAK BISA DIRUBAH SUDAH DICETAK SPJ ...... ", 1) : Exit Function
        ElseIf DropDownList2.Text = "" Then
            Msg_err("KODE SUPIR TIDAK ADA !!!!!!!!!", 1) : Exit Function
        End If

        If Data_Pengiriman(TxtNoRangka.Text) = 1 Then
            Simpan_Supir = UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_DRIVER='" & UCase(DropDownList2.Text) & "' WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1)
        End If
    End Function

    Function Simpan_Setuju() As Byte
        Simpan_Setuju = 0
        If TxtTglBatal.Text <> "" Then
            Msg_err("SUPIR TIDAK BISA KARENA SUDAH DIBATALKAN PENGIRIMANNYA", 1) : Exit Function
        ElseIf TxttglTerima.Text <> "" Then
            Msg_err("SUPIR TIDAK BISA KARENA KENDARAAN SUDAH DITERIMA", 1) : Exit Function
        ElseIf DropDownList2.Text = "" Then
            Msg_err("KODE SUPIR TIDAK ADA !!!!!!!!!", 1) : Exit Function
        ElseIf TxttglKirimSetujui.Text = "" Then
            Msg_err("TANGGAL KIRIM BELUM DIISI !!!!!!!!!", 1) : Exit Function
        End If
        If simpanALsan(TxtNoRangka.Text, "RK", "ALASAN PERUBAHAN TANGGAL KIRIM ", TxtAlasanRubahTglKirim.Text, mTemplate) = 1 Then
            Simpan_Setuju = UpdateDatabase_Tabel("UPDATE TRXN_STOCKMKIRIM SET STOCKM_KIRIMTGLSETUJUI=" & FieldTgl(TxttglKirimSetujui.Text) & " WHERE STOCKM_NORANGKA='" & TxtNoRangka.Text & "'", "", 1)
            If Simpan_Setuju <> 1 Then
                Msg_err("SIMPAN GAGAL", 1)
                TxttglKirimSetujui.Text = mTemplate
            End If
        End If
    End Function

    Function SimpanPDI(ByVal mJenis As Byte) As Byte
        '1:sIMPAN   2:bATAL
        SimpanPDI = 0
        If TxtTglBatal.Text <> "" Then
            Msg_err("PDI TIDAK BISA KARENA SUDAH DIBATALKAN PENGIRIMANNYA", 1) : Exit Function
        ElseIf TxttglTerima.Text <> "" Then
            Msg_err("PDI TIDAK BISA KARENA KENDARAAN SUDAH DITERIMA", 1) : Exit Function
        ElseIf DropDownList2.Text = "" Then
            Msg_err("KODE SUPIR TIDAK ADA !!!!!!!!!", 1) : Exit Function
        ElseIf TxttglPDI.Text = "" Then
            Msg_err("TANGGAL PDI BELUM DIISI !!!!!!!!!", 1) : Exit Function
        End If
        If mJenis = 1 Then 'INPUT
            SimpanPDI = UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLPDI=" & nSrSQL(TxttglPDI.Text) & " WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1)
            If SimpanPDI = 1 Then
                TxttglPDINote.Text = "TEKAN DEL/DELETE UNTUK VALID PDI"
                'Cetak Call cetakPDI(TxtNoRangka.Text)
            Else
                TxttglPDINote.Text = "ERROR BELUM TERSIMPAN"
            End If
        Else              'BATAL'
            SimpanPDI = UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLPDI=NULL WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1)
            If SimpanPDI = 1 Then
                TxttglPDINote.Text = ""
            End If
        End If
    End Function

    Function SimpanSPJ(ByVal MSTATUS As Byte) As Byte
        '1/2 SIMPAN    0 : BATAL
        Dim MySTRsql0 As String
        Dim MySTRsql1 As String
        Dim MySTRsql2 As String
        Dim MySTRsql3 As String
        SimpanSPJ = 0
        If MSTATUS = 1 Then
            If GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCK WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "' AND STOCK_DOTGLGESEKRGKI IS NULL", "", 1) = 1 Then
                Msg_err("Periksa Kembali Gesek Nomor Rangka belum dilakukan, apakah sudah dilakukan dengan Benar ? ", 1)
            End If



            If Trim(TxtNama.Text) = "" Or DropDownList2.Text = "" Then
                Msg_err("Alamat Tujuan atau kode supir belum diisi ", 1) : Exit Function
            ElseIf TxttglKeluar.Text = "" Then
                Msg_err("TANGGAL KELUAR BELUM DIISI !!!!!!!!!", 1) : Exit Function
            End If
            TxttglKirimSetujui.Text = IIf(TxttglKirimSetujui.Text = "", Now, TxttglKirimSetujui.Text)
            MySTRsql0 = "UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLKIRIM=" & nSrSQL(TxttglKeluar.Text) & ",STOCKK_KIRIMTGLKIRIMI=GETDATE() " & _
                        "WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'"
            MySTRsql1 = "UPDATE TRXN_STOCK SET STOCK_TglKirim=" & nSrSQL(TxttglKeluar.Text) & " " & _
                        "WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'"
            MySTRsql2 = "DELETE FROM TRXN_STOCKAKIRIM WHERE STOCKA_NORANGKA='" & TxtNoRangka.Text & "'"
            MySTRsql3 = "INSERT INTO TRXN_STOCKAKIRIM (STOCKA_NORANGKA,STOCKA_NAMA,STOCKA_ALAMAT,STOCKA_KOTA,STOCKA_PH,STOCKA_HP,STOCKA_STKIRIM) VALUES ('" & _
                         TxtNoRangka.Text & "','" & TxtNama.Text & "','" & TxtAlamat.Text & "','" & TxtKota.Text & "','" & TxtPhone.Text & "','" & TxtNoHP.Text & "','')"


            If UpdateDatabase_Tabel(MySTRsql0, "", 1) = 1 Then
                Call UpdateDatabase_Tabel(MySTRsql0, "", 1)
                Call UpdateDatabase_Tabel(MySTRsql1, "", 1)
                Call UpdateDatabase_Tabel(MySTRsql2, "", 1)
                Call UpdateDatabase_Tabel(MySTRsql3, "", 1)
                'Cetak Call cetakSPJ(TxtNoRangka.Text, 1)
                TxttglKeluarNote.Text = "TEKAN DEL/DELETE UNTUK BATAL SPJ"
                'masukin ke manual cetak voucher Call UpdateSTOKBBM(1)
                SimpanSPJ = 1
            Else
                TxttglKeluar.Text = ""
            End If
        Else
            If TxttglTerima.Text <> "" Then
                Msg_err("BATAL TIDAK BISA KARENA KENDARAAN SUDAH DITERIMA", 1) : Exit Function
            End If
            MySTRsql1 = "UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLKIRIM=NULL " & _
                        "WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'"
            MySTRsql2 = "UPDATE TRXN_STOCK SET STOCK_TglKirim=NULL " & _
                        "WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'"
            MySTRsql3 = "DELETE FROM TRXN_STOCKAKIRIM WHERE STOCKA_NORANGKA='" & TxtNoRangka.Text & "'"
            If UpdateDatabase_Tabel(MySTRsql1, "", 1) = 1 Then
                Call UpdateDatabase_Tabel(MySTRsql1, "", 1)
                Call UpdateDatabase_Tabel(MySTRsql2, "", 1)
                Call UpdateDatabase_Tabel(MySTRsql3, "", 1)
                TxttglKeluar.Text = ""
                TxttglKeluarNote.Text = ""
                Call UpdateSTOKBBM(0, "")
                SimpanSPJ = 1
            End If
        End If
    End Function

    Function CmdValidOutHouse(ByVal mTYPE As Byte) As Byte
        '1 iNPUT  2: HAPUS
        CmdValidOutHouse = 0
        If mTYPE = 1 Then 'INPUT
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLSECURITY=GETDATE(),STOCKK_KIRIMKETSECURITY='SISTEM' WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) = 1 Then
                TxtTglSecurity.Text = Now()
                TxtTglSecurityNote.Text = "OLEH SISTEM TEKAN DEL/DELETE UNTUK VALID PDI"
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

    Function Simpan_Batal() As Byte
        Simpan_Batal = 0
        If TxtTglBatalNote.Text <> "" Then
            Msg_err("ALASAN BATAL BELUM DIISI ", 1) : Exit Function
        End If
        If simpanALsan(TxtNoRangka.Text, "BK", "ALASAN BATAL KIRIM", TxtTglBatalNote.Text, ": BTL TGL " & TxtTglBatal.Text & "/SPK:" & Kodedealer.Text & "-" & lblnospk.Text) = 1 Then
            Call UpdateDatabase_Tabel("DELETE FROM TRXN_STOCKMKIRIM WHERE STOCKM_NORANGKA='" & TxtNoRangka.Text & "'", "", 1)
            Call UpdateDatabase_Tabel("DELETE FROM TRXN_STOCKKKIRIM WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1)
            Call UpdateDatabase_Tabel("DELETE FROM TRXN_STOCKAKIRIMP where STOCKAKP_NORANGKA='" & TxtNoRangka.Text & "'", "", 1)
            TxtTglBatal.Text = Now()
        End If
    End Function

    Function CmdTerima(ByRef mStatus As Object) As Byte
        '1 INPUT 2 BATAL
        CmdTerima = 0
        If TxttglTerima.Text <> "" Then
            Msg_err("TANGGAL TERIMA BELUM DIISI", 1) : Exit Function
        ElseIf TxttglTerimaNote.Text <> "" Then
            Msg_err("NAMA PENERIMA BELUM DIISI", 1) : Exit Function
        End If

        If mStatus = 1 Then
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLTERIMAI=GETDATE(),STOCKK_KIRIMTGLTERIMA=" & nSrSQL(TxttglTerima.Text) & ",STOCKK_KIRIMKETTERIMA='" & TxttglTerimaNote.Text & "' WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) <> 1 Then
                Msg_err("TIDAK TERSIMPAN", 1)
            End If
        Else
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCKKKIRIM SET STOCKK_KIRIMTGLTERIMAI=GETDATE(),STOCKK_KIRIMTGLTERIMA=NULL,STOCKK_KIRIMKETTERIMA='' WHERE STOCKK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) = 1 Then
                TxtTglBatal.Text = "" : TxtTglBatalNote.Text = ""
            End If
        End If
        CmdTerima = 1
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

    Function SimpanTandaTerimaDealer(ByRef mStatus As Object) As Byte
        '1 INPUT 2 BATAL
        Dim MERROR As String
        Dim mKodeDLR As String = GetDataD_IsiField("SELECT LOKASI_KODEDLR as IsiField FROM DATA_LOKASI WHERE LOKASI_KODE='" & TxtNotKirimMgn.Text & "'", "", 0)
        Dim mKodeLOK As String = GetDataD_IsiField("SELECT LOKASI_NAMA as IsiField FROM DATA_LOKASI WHERE LOKASI_KODE='" & TxtNotKirimMgn.Text & "'", "", 0)
        SimpanTandaTerimaDealer = 0
        If mStatus = 1 Then
            'pERIKSA KODE DEALERNYA
            MERROR = ""
            If TxtNotKirimMgn.Text = "" Or TxtTglKirimMgn.Text = "" Then
                MERROR = ("Isikan tujuan pengiriman SW12 pasar minggu SW28 puri kembangan dan Tanggal Kirim")
            ElseIf Left(TxtNotKirimMgn.Text, 2) <> "SW" Then
                MERROR = ("Isikan tujuan pengiriman SW12 pasar minggu SW28 puri kembangan")
            ElseIf mKodeDLR <> "" Then
                If mKodeDLR <> Kodedealer.Text Then
                    Msg_err("Lokasi tujuan tidak sama dengan kepemilikan unit stok !!!!!!!! " & Chr(13) & _
                           "Stok punya kode dealer " & Kodedealer.Text & Chr(13) & _
                           "Tujuan Pengiriman Dealer adalah " & mKodeLOK, 1)
                Else
                    Msg_err("Tujuan Pengiriman Dealer adalah " & mKodeLOK, 1)
                End If
            Else
                Msg_err("Kode dealer tujuan salah salah ....", 1)
            End If
            If MERROR <> "" Then
                Msg_err(MERROR, 0)
                Exit Function
            End If
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCK SET STOCKK_KIRIMMUGENTGLI=GETDATE(),STOCK_KIRIMMUGENSTS='',STOCK_KIRIMMUGENTGL=" & nSrSQL(TxtTglKirimMgn.Text) & ",STOCK_KIRIMMUGENKODE='" & TxtNotKirimMgn.Text & "' WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) <> 1 Then
                Msg_err("TIDAK TERSIMPAN", 1)
                TxtTglKirimMgn.Text = ""
                TxtNotKirimMgn.Text = ""
            Else
                'Cetak Call cetakSPJdealer(TxtNoRangka.Text, 1)
            End If
        Else
            If UpdateDatabase_Tabel("UPDATE TRXN_STOCK SET STOCKK_KIRIMMUGENTGLI=GETDATE(),STOCK_KIRIMMUGENSTS='',STOCK_KIRIMMUGENTGL=NULL,STOCK_KIRIMMUGENKODE='' WHERE STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) = 1 Then
                TxtTglKirimMgn.Text = "" : TxtNotKirimMgn.Text = ""
            End If
        End If
        SimpanTandaTerimaDealer = 1
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
            FieldTgl = "'" & Format(CDate(mnilai), "yyyy-MM-dd HH:MM:SS") & "'"
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
        Call GETSTOCK_GETTTK("STOCK_NoTTK ='" & TxtNoTTK.Text & "'")
    End Sub


    Protected Sub ButtonCariTTK0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCariTTK0.Click
        If ButtonCariTTK0.Text = "ALAMAT STNK" Then
            ButtonCariTTK0.Text = "ALAMAT SPK"
            Call GETPERMOHONAN_DATA_ALAMAT_SPK("STOCKAKP_NORANGKA='" & TxtNoRangka.Text & "'", "K")
        Else
            ButtonCariTTK0.Text = "ALAMAT STNK"
            Call GETPERMOHONAN_DATA_ALAMAT_SPK("STOCKAKP_NORANGKA='" & TxtNoRangka.Text & "'", "S")
        End If
    End Sub

    Function ValidasiTombol(ByVal mTombol As Byte, ByVal mAction As Byte) As Byte
        Dim MySTRsql1 As String
        If mTombol <> 12 Then
            If GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCK WHERE STOCK_KIRIMMUGENTGL IS NOT NULL AND STOCK_NORANGKA='" & TxtNoRangka.Text & "'", "", 1) = 1 Then
                Msg_err("SUDAH DI KIRIM KE DEALER ", 1) : Exit Function
            End If
        End If

        If Not (mTombol = 7 Or mTombol = 8) Then
            ' ===> STOCKK_KIRIMTGLTERIMA
            MySTRsql1 = "SELECT STOCK_NOTTK as IsiField," & _
                        "(SELECT DRIVER_NAMA FROM DATA_DRIVER WHERE DRIVER_KODE=STOCKK_DRIVER) AS NamaDRIVE " & _
                        "FROM TRXN_STOCKKKIRIM,TRXN_STOCKMKIRIM,TRXN_STOCK WHERE STOCKK_NORANGKA=STOCKM_NORANGKA AND STOCKK_NORANGKA=STOCK_NORANGKA AND " & _
                        "STOCKK_KIRIMTGLTERIMA IS NULL AND DATEDIFF(day,STOCKK_KIRIMTGLKIRIM,GETDATE()) > 2 AND DATEDIFF(day,'2016-10-01 00:00:00',STOCKK_KIRIMTGLKIRIM) >= 0"
            MySTRsql1 = GetDataD_IsiField(MySTRsql1, "", 0)
            If MySTRsql1 <> "" Then
                Msg_err("ADA PENGIRIMAN UNIT KE CUSTOMER YANG BELUM DI ISI TANGGAL TERIMA YANG LEBIH DARI DUA HARI (PER TGL 01/10/2016) LIHAT DI REPORT" & MySTRsql1, 1) : Exit Function
            End If
        End If
        Dim SimpanEdit As Integer
        If mAction = 1 Then 'Save
            Select Case mTombol
                Case 3 : SimpanEdit = Simpan_Supir(1)
                Case 4 : SimpanEdit = Simpan_Setuju()
                Case 5 : SimpanEdit = SimpanPDI(1)
                Case 6 : SimpanEdit = SimpanSPJ(1)
                Case 7 : SimpanEdit = CmdValidOutHouse(1)
                Case 8 : SimpanEdit = Simpan_Batal()
                Case 9 : SimpanEdit = CmdTerima(1)
                Case 10 : SimpanEdit = CmdCatatan(1)
                Case 11 : SimpanEdit = UpdateSTOKBBM(1, "") 'Beda
                Case 13 : SimpanEdit = SimpanTandaTerimaDealer(1)
                Case 14 : SimpanEdit = SimpanBukuService(1)
                Case 15 : SimpanEdit = UpdateSTOKBBM(1, "S")

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
                Case 5 : Call SimpanPDI(0) ' mCol = 2
                Case 6 : Call SimpanSPJ(0) 'mCol = 2
                Case 7 : Call CmdValidOutHouse(0) ' mCol = 2
                Case 9 : Call CmdTerima(0) ' mCol = 2
                Case 10 : Call CmdCatatan(0) ' mCol = 2
                Case 11 : Call UpdateSTOKBBM(0, "") ' mCol = 2
                Case 13 : Call SimpanTandaTerimaDealer(0) ' mCol = 2
                Case 14 : Call SimpanBukuService(0) ' mCol = 2
                Case 15 : Call UpdateSTOKBBM(0, "S") ' mCol = 2

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


    Protected Sub BtnSmp01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp01.Click
        Call ValidasiTombol(1, 1)
    End Sub
    Protected Sub BtnSmp02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp02.Click
        Call ValidasiTombol(2, 1)
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
    Protected Sub BtnSmp11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp11.Click
        Call ValidasiTombol(11, 1)
    End Sub
    Protected Sub BtnSmp12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp12.Click
        Call ValidasiTombol(12, 1)
    End Sub
    Protected Sub BtnSmp13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp13.Click
        Call ValidasiTombol(13, 1)
    End Sub
    Protected Sub BtnSmp14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp14.Click
        Call ValidasiTombol(14, 1)
    End Sub
    Protected Sub BtnSmp15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSmp15.Click
        Call ValidasiTombol(15, 1)
    End Sub
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

    Protected Sub BtnBtl01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl01.Click
        Call ValidasiTombol(1, 2)
    End Sub
    Protected Sub BtnBtl02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl02.Click
        Call ValidasiTombol(2, 2)
    End Sub
    Protected Sub BtnBtl03_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl03.Click
        Call ValidasiTombol(3, 2)
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
    Protected Sub BtnBtl08_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl08.Click
        Call ValidasiTombol(8, 2)
    End Sub
    Protected Sub BtnBtl09_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl09.Click
        Call ValidasiTombol(9, 2)
    End Sub
    Protected Sub BtnBtl10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl10.Click
        Call ValidasiTombol(10, 2)
    End Sub
    Protected Sub BtnBtl11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl11.Click
        Call ValidasiTombol(11, 2)
    End Sub
    Protected Sub BtnBtl12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl12.Click
        Call ValidasiTombol(12, 2)
    End Sub
    Protected Sub BtnBtl13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl13.Click
        Call ValidasiTombol(13, 2)
    End Sub
    Protected Sub BtnBtl14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl14.Click
        Call ValidasiTombol(14, 2)
    End Sub
    Protected Sub BtnBtl15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBtl15.Click
        Call ValidasiTombol(15, 2)
    End Sub
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
            myalasanku = mKet
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
        Call Saveform()
    End Sub

    Protected Sub BtnTTKBatal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTTKBatal.Click
        Call CANCELRecord()
    End Sub


    Function Err_Save() As Byte
        Dim msg_errErr As String
        Dim mcdRangka As String
        msg_errErr = ""

        If TxtNoTTK.Text <> "" And TxtNoTTK.Text <> lblNoTTKTag.Text Then
            msg_errErr = msg_errErr & "KODE NO TTK YANG DI INPUT TIDAK BENAR" & Chr(13)
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

        If Trim(TxtCdType.Text) <> Trim(lblCdTypeTag.Text) Or Trim(TxtCdType.Text) = "" Then msg_errErr = msg_errErr & "TYPE TIDAK DIKETEMUKAN" & Chr(13)
        If Trim(TxtCdWarna.Text) <> Trim(lblCdWarnaTag.Text) Or Trim(TxtCdWarna.Text) = "" Then msg_errErr = msg_errErr & "WARNA TIDAK DIKETEMUKAN" & Chr(13)
        If Trim(TxtCdSuplier.Text) <> Trim(lblCdSuplierTag.Text) Or Trim(TxtCdSuplier.Text) = "" Then msg_errErr = msg_errErr & "SUPLIER TIDAK DIKETEMUKAN" & Chr(13)
        If Trim(TxtcdLokasi.Text) = "" Then msg_errErr = msg_errErr & "LOKASI TIDAK DIKETEMUKAN " & Chr(13)
        If Trim(TxtNoRangka.Text) = "" Then msg_errErr = msg_errErr & "NO. RANGKA BELUM BENAR" & Chr(13)
        If TxtNoMesin.Text = "" Then msg_errErr = msg_errErr & "NO MESIN BELUM DIISI " & Chr(13)

        'If KodeWarnaImora.Text <> "" And KodeWarnaImoraMugen.Text <> "" And _
        '   KodeWarnaImora.Text <> KodeWarnaImoraMugen.Text Then
        'msg_errErr = msg_errErr & "KODE WARNA TIDAK SAMA DGN WARNA IMORA (KOTAK HIJAU DAN KOTAK KUNING TIDAK SAMA) UNTUK MERUBAH WARNA INI (HUBUNGI IT) " & Chr(13) & _
        '            "WARNA IMORANNYA " & KodeWarnaImora.Tag & Chr(13)
        'End If

        If NamaWarna.Text <> "" And NamaWarnaImora.Text <> "" And _
           NamaWarna.Text <> NamaWarnaImora.Text Then
            msg_errErr = msg_errErr & "NAMA WARNA TIDAK SAMA DGN WARNA IMORA (KOTAK HIJAU DAN KOTAK KUNING TIDAK SAMA) UNTUK MERUBAH WARNA INI (HUBUNGI IT) " & Chr(13) & _
                                    "NAMA WARNA IMORANNYA " & NamaWarnaImora.Text & Chr(13)
        End If

        If NoBTL.Visible = True Then msg_errErr = msg_errErr & "NO. TTK INI SUDAH DIBATALKAN TIDAK BISA DISIMPAN " & Chr(13)

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
        If GetDataD_00NoFound01Found(mysqltxt, "", 0) = 1 Then msg_errErr = msg_errErr & "NO. RANGKA TERSEBUT SUDAH ADA (TERDAFTAR) " & Chr(13)
        If GetDataD_IsiField("SELECT TYPE_CdRangka as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0) <> "" Then
            Dim mAda As Byte = 0
            Dim mRangkaCari As String = ""
            mcdRangka = GetDataD_IsiField("SELECT TYPE_CdRangka  as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0) & _
                        GetDataD_IsiField("SELECT TYPE_CdRangka1 as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0)
            If InStr(1, TxtNoRangka.Text, mcdRangka) <> 0 Then
                mAda = 1
            Else
                mRangkaCari = mcdRangka
                mcdRangka = GetDataD_IsiField("SELECT TYPE_CdRangka  as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0) & _
                            GetDataD_IsiField("SELECT TYPE_CdRangka2 as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0)
                If InStr(1, TxtNoRangka.Text, mcdRangka) <> 0 Then
                    mAda = 1
                Else
                    mRangkaCari = mRangkaCari & "/" & mcdRangka
                    mcdRangka = GetDataD_IsiField("SELECT TYPE_CdRangka  as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0) & _
                                GetDataD_IsiField("SELECT TYPE_CdRangka3 as IsiField FROM DATA_TYPE WHERE TYPE_Type='" & TxtCdType.Text & "'", "", 0)
                    mRangkaCari = mRangkaCari & "/" & mcdRangka
                    If InStr(1, TxtNoRangka.Text, mcdRangka) <> 0 Then
                        mAda = 1
                    End If
                End If
            End If
            If mAda <> 1 Then
                msg_errErr = msg_errErr & "NO. RANGKA TIDAK SESUAI DENGAN TIPE KENDARAAN (TIDAK ADA NOMOR " & mRangkaCari & " DI NOMOR RANGKA) " & Chr(13)
            End If
        End If

        If msg_errErr <> "" Then
            Msg_err(msg_errErr, 0) : Err_Save = 1 : Exit Function
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
            Else
                Call Msg_err("No Access", 1)
            End If
        End If
    End Sub

    '==============================================
    Sub AddRecord()
        Dim iloop As Byte
        Dim QuerySqlSts As Byte
        For iloop = 1 To 6
            Select Case iloop
                Case 1 : QuerySqlSts = CREATE_NO()
                Case 2 : QuerySqlSts = INSERT_STOCK()
                Case 3 : Call UPDATE_DATA_WARNA()
                Case 4 : Call Save_DO_Gesek_Rangka()
                Case 5 : lblNoTTKTag.Text = TxtNoTTK.Text
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
        For iloop = 1 To 3
            Select Case iloop
                Case 1
                    Mfind = GETSTOCK_STATUS("STOCK_NoTTK ='" & TxtNoTTK.Text & "'", "")
                    If Mfind <> 0 Then QuerySqlSts = 1
                Case 2
                    If Mfind = 9 Then
                        QuerySqlSts = UPDATE_DATA_STOCK()
                    End If
                Case 3
                    If Mfind = 8 Or Mfind = 9 Then
                        QuerySqlSts = UPDATE_DATA_STOCK_BOLEH()
                    End If
                Case 4 : Call UPDATE_DATA_WARNA()
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
        For iloop = 0 To 10
            Select Case iloop
                Case 1
                    If Mid(lblAkses.Text, 3, 1) <> "1" Then
                        QuerySqlSts = 0
                    Else
                        QuerySqlSts = 1
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
        [Calendar9].Visible = False
        [Calendar10].Visible = False
        [Calendar11].Visible = False
        [Calendar12].Visible = False
        [Calendar13].Visible = False
        [Calendar14].Visible = False


        MultiViewTabelStok.ActiveViewIndex = -1
        MultiViewStockImora.ActiveViewIndex = -1
        MultiViewType.ActiveViewIndex = -1
        MultiViewWarna.ActiveViewIndex = -1
        MultiViewSuplier.ActiveViewIndex = -1
        MultiViewLokasi.ActiveViewIndex = -1

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
        TxtcdLokasi.Text = "" : lblcdLokasiTag.Text = "" : NamaLokasi.Text = "" : Kodedealer.Text = ""
        LblCrsSellMugen.Text = ""
        TxtKeterangan.Text = ""
        TxtAlasanBatal.Text = ""
        LblStatus.Text = ""

        TxtCdType.Enabled = True : TxtCdWarna.Enabled = True : TxtCdSuplier.Enabled = True : TxtTahun.Enabled = True


        TxtNama.Text = ""
        TxtAlamat.Text = ""
        TxtKota.Text = ""
        TxtNoHP.Text = ""
        TxtPhone.Text = ""

        TxtBerita.Text = ""
        TxtTglAdmin.Text = "" : TxtUsrAdmin.Text = ""
        DropDownList2.SelectedIndex = -1 : lblNmSupir.Text = ""
        TxtAlasanRubahTglKirim.Text = "" : TxtAlasanRubahTglKirim.Text = ""
        TxttglPDI.Text = "" : TxttglPDINote.Text = ""
        TxttglKeluar.Text = "" : TxttglKeluarNote.Text = ""
        TxtTglSecurity.Text = "" : TxtTglSecurityNote.Text = ""
        TxtTglBatal.Text = "" : TxtTglBatalNote.Text = ""
        TxttglTerima.Text = "" : TxttglTerimaNote.Text = ""
        TxttglCatatan.Text = "" : TxttglCatatanDsc.Text = ""
        LblBBMVcr.Text = "" : LblBBMNilai.Text = "" : LblBBMAlasan.Text = ""
        TxttglCetakDO.Text = ""
        TxtTglKirimMgn.Text = "" : TxtNotKirimMgn.Text = ""
        TxtTglBukuSvc.Text = "" : TxtBukuSvc.Text = ""
        LblBBMCSVcr.Text = "" : LblBBMCSNil.Text = "" : LblBBMCSAlasan.Text = ""
        TxtPDISPK.Text = ""
        TxtPDITransmisiNote.Text = ""
        TxtPDISupirTgl.Text = "" : TxtPDISupirNot.Text = ""
        TxtPDIPlatMJSNot.Text = ""
        TxtPDIKetTgl.Text = "" : TxtPDIKetera.Text = ""
        TxtPDILakbanTgl.Text = "" : TxtPDILakbanNot.Text = ""
        TxtPDIPoldaTgl.Text = "" : TxtPDIPoldaNot.Text = ""
        TxtNoSTCK.Text = ""

        lblnospk.Text = "" : lblNoDO.Text = "" : LblCdBranch.Text = ""
        LblSalesman.Text = "" : lbllease.Text = ""
        LblIdSPK.Text = "" : LblIdSTNK.Text = ""


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
        BtnPrintBBMR.Visible = True : BtnPrintBBM.Visible = False
        BtnPrintBBMDR.Visible = True : BtnPrintBBMD.Visible = False
        Call clearspj()
        btnPrintSPJR.Visible = True : btnPrintSPJ.Visible = False

        Call clearDataSTCK()
        'BtnPrintBBDR.Visible = True : BtnPrintBBMD.Visible = False

        Call clearDataPrintPDI()
        btnPrintPDIR.Visible = True : btnPrintPDI.Visible = False
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
        LblSPJ7ALAMAT21.Text = "" : LblSPJ7ALAMAT22.Text = ""
        LblSPJ7KOTA1.Text = "" : LblSPJ7KOTA2.Text = ""
        LblSPJ8PHONE1.Text = "" : LblSPJ8PHONE2.Text = ""
        LblSPJ9BIAYA.Text = ""
        LblSPJ10TGLJAMK.Text = "" : LblSPJ10PARAFS.Text = ""
        LblSPJ11TGLJAMT.Text = "" : LblSPJ11PARAFP.Text = ""
        LblSPJ12TGLSURAT.Text = ""
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
        TXTSQL_INSERT_STOCK = "INSERT INTO TRXN_STOCK(" & _
                   "STOCK_NoTTK,STOCK_TglTTK,STOCK_StsUpdate,STOCK_TglUpdate," & _
                   "STOCK_NoRangka,STOCK_NoMesin,STOCK_NoKunci,STOCK_CdType,STOCK_CdWarna,STOCK_CdSuplier," & _
                   "STOCK_Tahun,STOCK_DoAuto,STOCK_TglAuto,STOCK_TglSJ,STOCK_CdLokasi,STOCK_Keterangan,STOCK_Alasan," & _
                   "STOCK_DoDealer,STOCK_TglDoDealer,STOCK_TglCtkDoDealer,STOCK_TglKirim,STOCK_TglTerima,STOCK_TglDOImoraHpm) VALUES "
        TXTSQL_INSERT_STOCK = TXTSQL_INSERT_STOCK & " ('" & TxtNoTTK.Text & "',GETDATE(),'N',GETDATE(),'" & _
                   TxtNoRangka.Text & "','" & TxtNoMesin.Text & "','" & TxtNoKunci.Text & "','" & TxtCdType.Text & "','" & TxtCdWarna.Text & "','" & TxtCdSuplier.Text & "','" & _
                   TxtTahun.Text & "','" & TxtNoDO.Text & "'," & FieldTgl((TxtDTglDO.Text)) & "," & FieldTgl((TxtDtglSuratJln.Text)) & ",'" & TxtcdLokasi.Text & "','" & TxtPetik((TxtKeterangan.Text)) & "',''," & _
                   "'',NULL,NULL,NULL,NULL," & IIf(TxtDtTglDoIm.Text = "", FieldTgl((TxtDtTglDoIm.Text)), "NULL") & ")"
        MsgBox(TXTSQL_INSERT_STOCK)
    End Function

    Function INSERT_STOCK() As Byte
        Dim Mytxtsql1 As String = TXTSQL_INSERT_STOCK(TxtNoTTK.Text)
        INSERT_STOCK = UpdateDatabase_Tabel(Mytxtsql1, "", 0)
        If INSERT_STOCK <> 1 Then Call Msg_err("TIDAK BERHASIL DI SIMPAN", 1)
        lblTGLTTK.Text = Now()
    End Function

    Function UPDATE_DATA_STOCK() As Byte
        Dim Mytxtsql As String = "UPDATE TRXN_STOCK SET " & _
                   "STOCK_NoRangka='" & TxtNoRangka.Text & "'," & _
                   "STOCK_NoMesin='" & TxtPetik((TxtNoMesin.Text)) & "'," & _
                   "STOCK_CdType='" & TxtCdType.Text & "'," & _
                   "STOCK_CdWarna='" & TxtCdWarna.Text & "'," & _
                   "STOCK_CdSuplier='" & TxtCdSuplier.Text & "'," & _
                   "STOCK_Tahun='" & TxtTahun.Text & "'," & _
                   "STOCK_CdLokasi='" & TxtcdLokasi.Text & "' " & _
                   "WHERE STOCK_NoTTK='" & TxtNoTTK.Text & "'"
        UPDATE_DATA_STOCK = UpdateDatabase_Tabel(Mytxtsql, "", 2)
        lblNoRangkaTag.Text = TxtNoRangka.Text
    End Function

    Function UPDATE_DATA_STOCK_BOLEH() As Byte
        Dim Mytxtsql As String = "UPDATE TRXN_STOCK SET " & _
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
            Msg_err("SUDAH ADA DO DARI DEALER SEGERALAH MELAKUKAN GESEK NO RANGKA DATA DO : " & Chr(13) & _
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

                If nSr((MyRecReadA("STOCK_StsUpdate"))) = "T" Then
                    Msg_err("SUDAH DI KUNCI OLEH ADMIN CABANG TIDAK BISA DI RUBAH (YG BISA DIRUBAH KETERANGAN,TGL DO SUPLIER,NO KUNCI", 1)
                    GETSTOCK_STATUS = 8
                Else
                    GETSTOCK_STATUS = 9
                End If
                GETSTOCK_STATUS = 9
            End While
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
    End Sub
    Protected Sub BtnStok4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStok4.Click
        Multi03Stok.ActiveViewIndex = 3
    End Sub

    Protected Sub BtnF2NoTTK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnF2NoTTK.Click
        If MultiViewTabelStok.ActiveViewIndex = 0 Then
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
        If MultiViewStockImora.ActiveViewIndex = 0 Then
            MultiViewStockImora.ActiveViewIndex = -1
        Else
            MultiViewStockImora.ActiveViewIndex = 0 : LvDataStockDoImora.DataBind()
        End If
    End Sub
    Protected Sub LvDataStockDoImora_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDataStockDoImora.SelectedIndexChanged
        TxtNoRangka.Text = (LvDataStockDoImora.DataKeys(LvDataStockDoImora.SelectedIndex).Value.ToString)
        If TxtNoRangka.Text <> lblNoRangkaTag.Text Then
            If ValidasiNoRangka1() <> 1 Then
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
                          "FROM TRXN_STOCKDO WHERE STOCKDO_NORANGKA='" & UCase(TxtNoRangka.Text) & "' ORDER BY STOCKDO_NORANGKA"
        'If FIND_STOCKDOSUPLIER("STOCKDO_NORANGKA='" & UCase(TxtNoRangka.Text) & "' ") = 1 Then
        ValidasiNoRangka1 = 0
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                ValidasiNoRangka1 = 1
                While MyRecReadA.Read()
                    If nSr(MyRecReadA("NoTTK")) <> "" And TxtNoTTK.Text <> nSr(MyRecReadA("NoTTK")) Then
                        Msg_err(UCase("Nomor rangka " & TxtNoRangka.Text & " sudah ada ada no ttk " & nSr(MyRecReadA("NoTTK"))), 1)
                        TxtNoRangka.Text = lblNoRangkaTag.Text
                        Exit While
                    ElseIf (nSr(MyRecReadA("NoTTK")) = "") And _
                           Kodedealer.Text <> nSr((MyRecReadA("STOCKDO_KODEDLR"))) Then
                        Msg_err(UCase("Nomor rangka " & TxtNoRangka.Text & " punya kode dealer " & nSr((MyRecReadA("STOCKDO_KODEDLR"))) & " Periksa lokasi-nya sesuaikan dengan dealernya"), 1)
                        TxtNoRangka.Text = ""
                        TxtNoRangka.Text = lblNoRangkaTag.Text
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
                End While
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
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                ValidasiNoRangka2 = 1
                While MyRecReadA.Read()
                    If nSr(MyRecReadA("STOCK_NoTTK")) <> TxtNoTTK.Text Then
                        Msg_err(UCase("Nomor rangka " & TxtNoRangka.Text & " sudah ada ada no ttk " & nSr(MyRecReadA("STOCK_NoTTK"))), 0) : Exit Function
                        TxtNoRangka.Text = lblNoRangkaTag.Text
                    End If
                    Msg_err("No Rangka ini belum ada DO Suplier dari kantor cabang " & Chr(13) & _
                           "Penting !! Stock ini tidak akan diakui oleh Cabang sesuai dengan lokasinya sampai DO Supliernya di masukan", 1)
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function


    Protected Sub BtnF2type_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnF2Tipe.Click
        If MultiViewType.ActiveViewIndex = 0 Then
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
                GETType_TTK = 1
                While MyRecReadA.Read()
                    TxtCdType.Text = nSr((MyRecReadA("TYPE_Type")))
                    lblCdTypeTag.Text = TxtCdType.Text
                    'LblTypeKode.Text = nSr((MyRecReadA("TYPE_Merk"))) & "-"
                    'LblTypeKode.Text = LblTypeKode.Text & nSr((MyRecReadA("TYPE_Bentuk"))) & "-"
                    'LblTypeKode.Text = LblTypeKode.Text & nSr((MyRecReadA("TYPE_Produk")))
                    NamaType.Text = nSr((MyRecReadA("TYPE_Nama")))
                    lblMugenImoraType.Text = nSr((MyRecReadA("TYPE_Imora")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function


    Protected Sub BtnF2Warna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnF2Warna.Click
        If MultiViewWarna.ActiveViewIndex = 0 Then
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
                While MyRecReadA.Read()
                    TxtCdWarna.Text = nSr((MyRecReadA("WARNA_Kode")))
                    lblCdWarnaTag.Text = TxtCdWarna.Text
                    NamaWarna.Text = nSr((MyRecReadA("WARNA_Int")))
                    KodeWarnaImoraMugen.Text = nSr((MyRecReadA("WARNA_KODEHPM")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Protected Sub BtnF2Suplier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnF2Suplier.Click
        If MultiViewSuplier.ActiveViewIndex = 0 Then
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
                While MyRecReadA.Read()
                    TxtCdSuplier.Text = nSr((MyRecReadA("SUPLIER_Kode")))
                    lblCdSuplierTag.Text = TxtCdSuplier.Text
                    nmSuplier.Text = nSr((MyRecReadA("SUPLIER_Nama")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Protected Sub BtnF2Lokasi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnF2Lokasi.Click
        If MultiViewLokasi.ActiveViewIndex = 0 Then
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
                GetLokasi_TTK = 1
                While MyRecReadA.Read()
                    TxtcdLokasi.Text = nSr((MyRecReadA("LOKASI_Kode")))
                    lblcdLokasiTag.Text = nSr((MyRecReadA("LOKASI_Kode")))
                    NamaLokasi.Text = nSr((MyRecReadA("LOKASI_Nama")))
                    Kodedealer.Text = nSr((MyRecReadA("LOKASI_KodeDLR")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message & ":" & mSqlCommadstring, 0)
        End Try
    End Function

    Sub ValidasiLokasi()
        If GetLokasi_TTK(UCase(TxtcdLokasi.Text)) <> 1 Then
            TxtcdLokasi.Text = ""
        ElseIf TxtNoRangka.Text <> "" Then
            Dim mKodedlr As String = GetDataD_IsiField("SELECT STOCKDO_KODEDLR as IsiField FROM TRXN_STOCKDO WHERE STOCKDO_NORANGKA='" & UCase(TxtNoRangka.Text) & "'", "", 0)

            If mKodedlr <> "" Then
                If (Kodedealer.Text <> nSr(mKodedlr)) Then
                    Msg_err(UCase("Nomor rangka " & TxtNoRangka.Text & " punya kode dealer " & nSr(mKodedlr) & " Periksa lokasi-nya sesuaikan dengan dealernya"), 0)
                    TxtcdLokasi.Text = "" : Exit Sub
                End If
            Else
                Msg_err("No Rangka ini belum ada DO Suplier dari kantor cabang " & Chr(13) & _
                       "Penting !! Stock ini tidak akan diakui oleh Cabang sesuai dengan lokasinya sampai DO Supliernya di masukan", 1)
            End If
        End If
        If lblcdLokasiTag.Text = "" Then lblcdLokasiTag.Text = TxtcdLokasi.Text
    End Sub

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
                    DropDownList2.Items.Add(nSr((MyRecReadA("DRIVER_KODE"))) & "-" & nSr((MyRecReadA("DRIVER_NAMA"))))
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


    Protected Sub BtnPrintBBMR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintBBMR.Click
        BtnPrintBBM.Visible = True : BtnPrintBBMR.Visible = False : MultiViewCetak.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnPrintBBM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintBBM.Click
        BtnPrintBBM.Visible = False : BtnPrintBBMR.Visible = True : MultiViewCetak.ActiveViewIndex = -1
    End Sub
    Protected Sub BtnPrintBBMDR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintBBMDR.Click
        BtnPrintBBMD.Visible = True : BtnPrintBBMDR.Visible = False : MultiViewCetak.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnPrintBBMD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintBBMD.Click
        BtnPrintBBMD.Visible = False : BtnPrintBBMDR.Visible = True : MultiViewCetak.ActiveViewIndex = -1
    End Sub
    Protected Sub BtnPrintSPJR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintSPJR.Click
        btnPrintSPJ.Visible = True : btnPrintSPJR.Visible = False : MultiViewCetak.ActiveViewIndex = 1
    End Sub
    Protected Sub BtnPrintSPJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintSPJ.Click
        btnPrintSPJ.Visible = False : btnPrintSPJR.Visible = True : MultiViewCetak.ActiveViewIndex = -1
    End Sub
    Protected Sub BtnPrintPDIR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintPDIR.Click
        btnPrintPDI.Visible = True : btnPrintPDIR.Visible = False : MultiViewCetak.ActiveViewIndex = 3
    End Sub
    Protected Sub BtnPrintPDI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintPDI.Click
        btnPrintPDI.Visible = False : btnPrintPDIR.Visible = True : MultiViewCetak.ActiveViewIndex = -1
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        lvKirimmUnit.DataBind()
        MultiV4Jadwal.ActiveViewIndex = 0
    End Sub



    Protected Sub BtnPrintBBM_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintBBM.DataBinding
        BtnPrintBBM.Visible = False : BtnPrintBBMR.Visible = True : MultiViewCetak.ActiveViewIndex = -1

    End Sub

    Protected Sub BtnPrintBBM_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintBBM.Disposed
        BtnPrintBBM.Visible = True : BtnPrintBBMR.Visible = False : MultiViewCetak.ActiveViewIndex = -1

    End Sub

    Protected Sub BtnPrintBBM_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintBBM.Init
        BtnPrintBBM.Visible = True : BtnPrintBBMR.Visible = False : MultiViewCetak.ActiveViewIndex = -1
    End Sub

    Protected Sub BtnPrintBBM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintBBM.Load
        BtnPrintBBM.Visible = True : BtnPrintBBMR.Visible = False : MultiViewCetak.ActiveViewIndex = -1
    End Sub

    Protected Sub BtnPrintBBM_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintBBM.PreRender
        BtnPrintBBM.Visible = True : BtnPrintBBMR.Visible = False : MultiViewCetak.ActiveViewIndex = -1
    End Sub

    Protected Sub BtnPrintBBM_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintBBM.Unload
        BtnPrintBBM.Visible = True : BtnPrintBBMR.Visible = False : MultiViewCetak.ActiveViewIndex = -1
    End Sub
End Class
