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

'Kode 0101
'1 Cari
'2 Posisi 0 Setuju SPV
'3 Posisi 1 Setuju SM 
'4 Posisi 2 Setuju OSM
'5 Posisi 3 Setuju DIR
'6 Posisi 4 Mengajukan Permohonan
'7 Pesrsetujuan repair Warehouse
'8 Chating
'9 Posisi 2 Setuju ADH
'10 Posisi 3 Setuju ACCOUNT

'SECURITYH_USER c 15
'SECURITYH_NOID c 30

Partial Class Default2
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader
    Public MyRecReadB As OleDbDataReader
    Public MyRecReadC As OleDbDataReader
    Public MyRecReadD As OleDbDataReader
    Public MyRecReadF As OleDbDataReader
    Public mRk1, mRk2, mRk3, mRk4, mRk5, mRk6, mRk7, mRk8, mRk9, mRk0, mRk11 As String
    Dim MySTRsql1 As String

    Dim mTabelB100(10) As String
    Dim mTabelB101(10) As String
    Dim mTabelB102(10) As String
    Dim mTabelB103(10) As String
    Dim mTabelB104(10) As String
    Dim mTabelB105(10) As String
    Dim mTabelB106(10) As String
    Dim mTabelB107(10) As String
    Dim mTabelB108(10) As String
    Dim mTabelB109(10) As String
    Dim mTabelB110(10) As String
    Dim mTabelB111(10) As String
    Dim mBrsTabelB As Byte

    Dim mTabelB2A00(20) As String
    Dim mBrsTabelB2A As Byte
    Dim mTabelB2B00(20) As String
    Dim mBrsTabelB2B As Byte

    Dim mTabelB300(10) As String
    Dim mTabelB301(10) As String
    Dim mTabelB302(10) As String
    Dim mTabelB303(10) As String
    Dim mBrsTabelB3 As Byte

    Dim mRpModal As Double
    Dim mKdSuplier As String
    Dim mPcSuplier As Double = 0


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If

        If LblUserName.Text = "" Then
            Dim x As String
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = UCase(x.ToString)
            If GetData_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0101'") = 1 Then
                MultiView1a.ActiveViewIndex = 0
                MultiView11a.ActiveViewIndex = 0
                Call UpdateDatabase_Tabel("UPDATE TRXN_SPKAH SET SPV='' WHERE SPV IS NULL", "")
                Call UpdateDatabase_Tabel("UPDATE TRXN_SPKAH SET APPROVALCODEP='0' WHERE JUDUL like 'ENTRY%' AND CABANG='" & lblArea1.Text & "' AND APPROVALCODEP='' AND (SPV='SC' OR SPV='FZ' OR SPV='UG')", "")

                lblColomError.Text = "%"
                If Not (LblUserName.Text = "SANTO" Or LblUserName.Text = "UGAM" Or LblUserName.Text = "FAIZ") Then
                    'LblMaxDisc.Visible = False
                    'Label81.Visible = False
                ElseIf LblUserName.Text = "UGAM" Or LblUserName.Text = "FAIZ" Then
                    lblColomError.Text = "NULL"
                End If
                Call DefinisTabelPindahDana()
            Else
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
        Call Msg_err("", "")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim mpContentPlaceHolder As ContentPlaceHolder
        'Dim mpTextBox As TextBox
        'mpContentPlaceHolder = CType(Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        'If Not mpContentPlaceHolder Is Nothing Then
        'mpTextBox = CType(mpContentPlaceHolder.FindControl("TxtUser"), TextBox)
        'If Not mpTextBox Is Nothing Then
        'mpTextBox.Text = "TextBox found!"
        'End If
        'End If

        Call Msg_err("", "")

    End Sub

    Protected Sub lvBerita_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPersetujuan.SelectedIndexChanged
        Call Msg_err("", "")
        LblResultIdMohon.Text = (lvPersetujuan.DataKeys(lvPersetujuan.SelectedIndex).Value.ToString)
        Call TampilkanPermohona()
    End Sub

    Protected Sub lvBeritaAss_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVPersetujuanAsesoris.SelectedIndexChanged
        Call Msg_err("", "")
        LblResultIdMohon.Text = (LVPersetujuanAsesoris.DataKeys(LVPersetujuanAsesoris.SelectedIndex).Value.ToString)
        Call TampilkanPermohona()
    End Sub

    Protected Sub DefinisTabelPindahDana()
        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn(3) {New DataColumn("Temp_PindahDanaTipe"), New DataColumn("Temp_PindahDanaSpk"), New DataColumn("Temp_PindahDanaNama"), New DataColumn("Temp_PindahDanaNilai")})
        ViewState("PindahDana") = dt
        Me.BindGridPindahDana()
    End Sub
    Protected Sub BindGridPindahDana()
        LvTabelPindahDana.DataSource = DirectCast(ViewState("PindahDana"), DataTable)
        LvTabelPindahDana.DataBind()
    End Sub
    Sub insertTabelPindahDana(ByVal Type As Byte, ByVal Temp_PindahDanaTipe As String, ByVal Temp_PindahDanaSPK As String, ByVal Temp_PindahDanaNama As String, ByVal Temp_PindahDanaNilai As String)
        Dim dt As DataTable = DirectCast(ViewState("PindahDana"), DataTable)
        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_PindahDanaTipe, Temp_PindahDanaSPK, Temp_PindahDanaNama, Temp_PindahDanaNilai)
            MultiViewPindahDana.ActiveViewIndex = 0
        End If
        ViewState("PindahDana") = dt
        Me.BindGridPindahDana()
    End Sub

    Protected Sub TampilkanPermohona()

        Call ClearForm()
        If InStr(LblResultIdMohon.Text, "WB/APR/AS") = 0 Then
            Call GetDataA_Tabel_SPKAH_Header("SELECT * FROM TRXN_SPKAH WHERE TRXN_SPKAH.NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND JUDUL LIKE 'ENTRY%'")
        Else
            Call GetDataA_Tabel_SPKAH_HeaderAsesoris("SELECT * FROM TRXN_OPTPO WHERE OPT_NOMORMOHON='" & LblResultIdMohon.Text & "'")
        End If

        If InStr(LblResultIdMohon.Text, "EM/APR/WB") = 0 Then
            If LblNoSPK.Text <> "" Then
                Dim mCari As String = IIf(LblResultPosSetujuCurrent.Text <> "", "AND APPROVALCODEP='" & LblResultPosSetujuCurrent.Text & "'", "AND (APPROVALCODEP='" & LblResultPosSetujuCurrent.Text & "' OR APPROVALCODEP IS NULL)")
                Dim mNomor As String = IIf(lblNomorSetuju.Text <> "", "AND NOMOR='" & lblNomorSetuju.Text & "'", "AND (NOMOR='" & lblNomorSetuju.Text & "' OR NOMOR IS NULL)")
                mNomor = ""

                'Detail Kendaraan
                If (InStr(LblResultIdMohon.Text, "WB/APR/AS") <> 0 Or InStr(LblResultIdMohon.Text, "WB/APR/DO") <> 0) And _
                   (TxtPosJab.Text = "0" Or TxtPosJab.Text = "1") Then
                    If TxtPosJab.Text = "0" Then
                        Call UpdateDatabase_Tabel("UPDATE TRXN_OPTPO SET OPT_USERAPPV1='" & LblUserName.Text & "' WHERE OPT_STATUSPROSES='ENTRY' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV2 IS NULL AND OPT_TGLAPPV1 IS NULL ", "")
                    ElseIf TxtPosJab.Text = "1" Then
                        Call UpdateDatabase_Tabel("UPDATE TRXN_OPTPO SET OPT_USERAPPV1='" & LblUserName.Text & "',OPT_TGLAPPV1=GETDATE(),OPT_APPROVALCODEP='0' WHERE OPT_STATUSPROSES like 'ENTRY%' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV1 IS NULL AND OPT_APPROVALCODEP='' AND (OPT_SPV='SC' OR OPT_SPV='FZ' OR OPT_SPV='UG')", "")
                        Call UpdateDatabase_Tabel("UPDATE TRXN_OPTPO SET OPT_USERAPPV2='" & LblUserName.Text & "' WHERE OPT_STATUSPROSES='ENTRY' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV2 IS NULL AND OPT_TGLAPPV1 IS NOT NULL", "")
                    End If
                End If

                Call clearSPKAD()
                'Call GetDataA_Tabel_SPKAD("SELECT * FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON='" & LblResultIdMohon.Text & "'", )

                Dim mSw As Byte = 0

                If InStr(LblResultIdMohon.Text, "WB/APR/SW") <> 0 Then
                    mSw = 1
                    mSw = mSw + GetDataD_00NoFound01Found("SELECT * FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND KETERANGAN LIKE 'SPK_VA%' ", "")
                    If mSw = 1 Then
                        LblPindahDanaTipe.Text = "JENIS PINDAH DANA SPK KE SPK"
                    Else
                        LblPindahDanaTipe.Text = "JENIS PINDAH DANA VIRUAL ACCOUNT KE SPK"
                    End If
                End If

                'Call GetUpdate_Data_SPKD(LblNoSPK.Text, LblResultIdMohon.Text, lblDealer.Text)
                Call GetDataA_Tabel_SPKAD("SELECT * FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND NOT(KETERANGAN LIKE 'SPK_TJ%' OR KETERANGAN LIKE 'SPK_VA%') ORDER BY KETERANGAN", mSw)
                Call GetDataA_Tabel_SPK(LblNoSPK.Text, lblDealer.Text, 0)
                Call GetDataA_Tabel_H_DIary(LblNoSPK.Text, lblDealer.Text, 0)
                If mSw > 0 Then
                    Call insertTabelPindahDana(1, "", "", "-----------------", "")
                    Call insertTabelPindahDana(1, "", "", "JUMLAH YANG AKAN DI PINDAHKAN ", LblPindahDanaSPKJuml.Text)
                    Call insertTabelPindahDana(1, "", "", "-----------------", "")

                    Call GetDataA_Tabel_SPKAD("SELECT * FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND (KETERANGAN LIKE 'SPK_TJ%' OR KETERANGAN LIKE 'SPK_VA%')", mSw)
                End If


                If Not (InStr(LblResultIdMohon.Text, "WB/APR/SD") <> 0 Or _
                        InStr(LblResultIdMohon.Text, "WB/APR/AS") <> 0 Or _
                        InStr(LblResultIdMohon.Text, "WB/APR/FT") <> 0 Or _
                        InStr(LblResultIdMohon.Text, "WB/APR/DO") <> 0) Then 'Selain Permohonan Maksimal Diskon
                    Call GetDataA_Tabel_SPKAH_Detail("SELECT * FROM TRXN_SPKAH WHERE CABANG='" & lblDealer.Text & "' AND TRXN_SPKAH.NOMOR_SPK='" & LblNoSPK.Text & "' AND APPROVALCODE='" & LblResultPosSetuju.Text & "' AND JUDUL LIKE 'ENTRY%' " & mCari & mNomor)
                    Call TabelError()
                    MultiViewENTRY.ActiveViewIndex = 0
                Else
                    'SD=Permohonan Khusus Polcy Max Diskon, AS=permohonan Aksesoris 
                    'FT=Permohonan Faktur                   DO=permohonan DO

                    If InStr(LblResultIdMohon.Text, "WB/APR/AS") = 0 Then
                        Call GetDataA_Tabel_SPKAH_Detail_PolcyDsikon("SELECT * FROM TRXN_SPKAH WHERE CABANG='" & lblDealer.Text & "' AND TRXN_SPKAH.NOMOR_SPK='" & LblNoSPK.Text & "' AND APPROVALCODE='" & LblResultPosSetuju.Text & "' AND TRXN_SPKAH.NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND JUDUL LIKE 'ENTRY%' " & mCari & mNomor)
                        MultiViewENTRY.ActiveViewIndex = 1
                    Else
                        MultiViewENTRY.ActiveViewIndex = 1
                    End If
                    MultiViewENTRY.ActiveViewIndex = 1
                    MultiViewSetujuRangka.ActiveViewIndex = -1
                    MultiViewSetujuFaktur.ActiveViewIndex = -1
                    MultiViewHistoryChat.ActiveViewIndex = -1
                    MultiViewAsesorisHdiary.ActiveViewIndex = -1
                    MultiViewSetujuAsesoris.ActiveViewIndex = -1
                    MultiViewSetujuAsesorisSPK.ActiveViewIndex = -1

                    MultiViewRubahHarga.ActiveViewIndex = -1
                    MultiViewKondisiSPK.ActiveViewIndex = 0
                    CheckAksesoris.Visible = False
                    TxtDisetujuiTahun.Enabled = False : TxtDisetujuiTahun.Visible = False
                    TxtDisetujuiHrgDisc.Enabled = False
                    TxtDisetujuiHrgKoms.Enabled = False
                    TxtDisetujuiHrgSubs.Enabled = False
                    Call GetDataA_ErrorMsg(LblResultIdMohon.Text, "")
                    Label43.Visible = False
                    If InStr(LblResultIdMohon.Text, "WB/APR/SD") <> 0 Then
                        TxtDisetujuiTahun.Enabled = True
                        TxtDisetujuiHrgDisc.Enabled = True
                        TxtDisetujuiHrgKoms.Enabled = True
                        TxtDisetujuiHrgSubs.Enabled = True
                        Label43.Visible = True
                        MultiViewRubahHarga.ActiveViewIndex = 0
                        MultiViewAsesorisHdiary.ActiveViewIndex = 0
                        MultiViewSetujuAsesorisSPK.ActiveViewIndex = 0
                    End If
                    If InStr(LblResultIdMohon.Text, "WB/APR/DO") <> 0 Then
                        MultiViewSetujuRangka.ActiveViewIndex = 0
                        LvAksesorisNonDO.DataBind()
                        MultiViewAsesorisHdiary.ActiveViewIndex = 0
                        MultiViewSetujuAsesorisSPK.ActiveViewIndex = 0
                        CheckAksesoris.Visible = True
                    End If

                    If InStr(LblResultIdMohon.Text, "WB/APR/FT") <> 0 Or InStr(LblResultIdMohon.Text, "WB/APR/DO") <> 0 Then
                        MultiViewSetujuFaktur.ActiveViewIndex = 0
                        Call GetDataA_Faktur("SELECT * FROM TRXN_SPKAF WHERE SPKAF_NOMORMOHON='" & LblResultIdMohon.Text & "' AND SPKAF_NOMOR=''")
                    End If
                    If InStr(LblResultIdMohon.Text, "WB/APR/AS") <> 0 Then
                        MultiViewAsesorisHdiary.ActiveViewIndex = 0
                        MultiViewSetujuAsesoris.ActiveViewIndex = 0
                        LvAksesorisNonDO.DataBind()
                    End If
                End If
                '==========================================================
                Call GetDataA_Tabel_SPKAS("SELECT * FROM TRXN_SPKAS WHERE TRXN_SPKAS.SETUJU_NOMOR='" & LblResultNomor.Text & "'")
                Call GETType_MakDiscount()
                '==========================================================
                MultiViewHistoryPersetujuan.ActiveViewIndex = 0
                LVPersetujuan2.DataBind()
                '==========================================================
                If InStr(LblResultIdMohon.Text, "WB/APR/SD") <> 0 Then
                    LblTotalSetuju.Text = (Val(IIf(TxtDisetujuiHrgDisc.Text = "", nLg(LblPengajuanHargaDisc.Text), TxtDisetujuiHrgDisc.Text)) - _
                                           Val(IIf(TxtDisetujuiHrgSubs.Text = "", nLg(LblPengajuanHargaSubs.Text), TxtDisetujuiHrgSubs.Text)) + _
                                           Val(IIf(TxtDisetujuiHrgKoms.Text = "", nLg(LblPengajuanHargaKoms.Text), TxtDisetujuiHrgKoms.Text)))
                    Call UpdateTotalHarga()
                End If


                MultiView1a.ActiveViewIndex = 1
                If InStr(LblResultPosSetuju.Text, "0") Then MultiView0S.ActiveViewIndex = 0 Else MultiView0S.ActiveViewIndex = -1
                If InStr(LblResultPosSetuju.Text, "1") Then MultiView1S.ActiveViewIndex = 0 Else MultiView1S.ActiveViewIndex = -1
                If InStr(LblResultPosSetuju.Text, "2") Then MultiView2S.ActiveViewIndex = 0 Else MultiView2S.ActiveViewIndex = -1
                If InStr(LblResultPosSetuju.Text, "3") Then MultiView3S.ActiveViewIndex = 0 Else MultiView3S.ActiveViewIndex = -1
                If InStr(LblResultPosSetuju.Text, "4") Then MultiView4S.ActiveViewIndex = 0 Else MultiView4S.ActiveViewIndex = -1
                If InStr(LblResultPosSetuju.Text, "5") Then MultiView5S.ActiveViewIndex = 0 Else MultiView5S.ActiveViewIndex = -1
            Else
                Call Msg_err("PERSETUJUAN SUDAH DILAKUKAN ATAU BELUM ADA SPK", "")
            End If
        Else  'Pembuatan WO BodyRepair
            Dim mQuery As String
            Dim mNoMohon As String
            Dim mRgk As String = ""
            Dim mDlr As String = ""

            mNoMohon = Replace(LblResultIdMohon.Text, "EM/APR/WB/TTK", "")
            mNoMohon = Replace(mNoMohon, "-", "")

            mDlr = Mid(mNoMohon, 1, 3)
            mRgk = Mid(mNoMohon, 4, Len(mNoMohon) - 3)

            LblWHNoMohon.Text = LblResultIdMohon.Text

            mQuery = "SELECT * FROM TRXN_STOCKAREPAIR,TRXN_STOCK,DATA_TYPE,DATA_WARNA,DATA_LOKASI,DATA_SUPLIER " & _
                     "WHERE ASSREPAIR_NORANGKA=STOCK_NORANGKA AND STOCK_Cdtype=TYPE_type AND STOCK_Cdlokasi=lokasi_Kode AND STOCK_Cdwarna=WARNA_Kode AND ASSREPAIR_KODEDLR=SUPLIER_KODE AND " & _
                     "(ASSREPAIR_TGLEMAIL IS NOT NULL AND (ASSREPAIR_NOSETUJU='' OR ASSREPAIR_NOSETUJU IS NULL))  AND STOCK_NOTTK='" & mRgk & "'"
            Call GetDataA_Tabel_WAREHOUSE(mQuery, "")
            MultiView1a.ActiveViewIndex = 2
            MultiViewWH.ActiveViewIndex = 0
        End If
    End Sub

    Sub TabelError()
        LblBlockPesan.Text = ""
        LblBlockPesanR.Text = ""
        LblBlockPesanC.Text = ""
        If ChkBox1.Checked = True Then Call GetDataA_ErrorMsg(Lbl01Mhn.Text, Lbl01Mhn.Text)
        If ChkBox2.Checked = True Then Call GetDataA_ErrorMsg(Lbl02Mhn.Text, Lbl02Mhn.Text)
        If ChkBox3.Checked = True Then Call GetDataA_ErrorMsg(Lbl03Mhn.Text, Lbl03Mhn.Text)
        If ChkBox4.Checked = True Then Call GetDataA_ErrorMsg(Lbl04Mhn.Text, Lbl04Mhn.Text)
        If ChkBox5.Checked = True Then Call GetDataA_ErrorMsg(Lbl05Mhn.Text, Lbl05Mhn.Text)
        If ChkBox6.Checked = True Then Call GetDataA_ErrorMsg(Lbl06Mhn.Text, Lbl06Mhn.Text)
        If ChkBox7.Checked = True Then Call GetDataA_ErrorMsg(Lbl07Mhn.Text, Lbl07Mhn.Text)
        If ChkBox8.Checked = True Then Call GetDataA_ErrorMsg(Lbl08Mhn.Text, Lbl08Mhn.Text)
        If ChkBox9.Checked = True Then Call GetDataA_ErrorMsg(Lbl09Mhn.Text, Lbl09Mhn.Text)
        If ChkBox10.Checked = True Then Call GetDataA_ErrorMsg(Lbl10Mhn.Text, Lbl10Mhn.Text)
    End Sub


    Protected Sub BtnKembali_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKembali1.Click
        Call Msg_err("", "")
        MultiView1a.ActiveViewIndex = 0
    End Sub



    Sub ClearForm()
        Call insertTabelPindahDana(0, "", "", "", "")
        LblPindahDanaSPKAsal.Text = "" : LblPindahDanaSPKTuju.Text = ""
        LblNoSPK.Text = ""
        LblNoSPK.Visible = True
        LblNoSPK_KhususVA.Visible = False

        LblTglMHS.Text = ""
        LblTglDO.Text = ""
        LblTglCreateSPK.Text = ""
        LblTglSetujuSM.Text = ""

       
        '----------------------- Data ada di SPK

        'Pelanggan
        LblNama.Text = ""
        LblSales.Text = "" : LblSalesSPV.Text = "" : LblSalesSPV0.Text = ""

        'Unit
        LblCdType.Text = ""
        lblTipe.Text = ""
        lblGroupTipe.Text = ""
        lblWarna.Text = ""
        lblNorangka.Text = ""
        lblTahun.Text = ""
        lblRoad.Text = ""

        LblHarga.Text = "" : LblPaketCermat.Text = ""
        LblDisc.Text = "" : LblBedathn.Text = ""
        LblSubsidi.Text = "" : LblUangMuka.Text = ""
        LblKomisi.Text = ""
        LblTotal.Text = ""

        LblHDiaryNama.Text = "" : LblHDiaryNote.Text = ""
        LblHDiaryJenisByr.Text = "" : LblHDiaryAsuransi.Text = ""
        LblHDiaryAksesoris.Text = "" : LblHDiaryPaket.Text = ""
        LblHDiaryHarga.Text = "" : LblHDiaryDisc.Text = ""

        LblJns.Text = ""
        LblJns0.Text = ""
        LblBayar.Text = ""
        lblTnr.Text = ""
        LblSisa.Text = ""

        '----------------------- Data ada di SPK
        LblNoteDiskon.Text = "" : LblsetujuDiskon.Text = ""
        lblSetuju.Text = ""

        LblMaxDisc.Text = ""

        lblSetuju.Text = ""
        LblMohon.Text = "" : LblKirimCustomer.Text = "" : LblTerimaCustomer.Text = ""
        lblDealer.Text = "" : lblNomorSetuju.Text = ""
        lblTglsetuju0.Text = ""
        TxtCatatan0.Text = ""
        lblTglSetuju1.Text = ""
        TxtCatatan1.Text = ""
        lblTglSetuju2.Text = ""
        TxtCatatan2.Text = ""
        LblTglSetuju3.Text = ""
        TxtCatatan3.Text = ""
        LblTglSetuju4.Text = ""
        TxtCatatan4.Text = ""
        LblTglSetuju5.Text = ""
        TxtCatatan5.Text = ""

        lblPolcyNomorMohon.Text = ""
        lblPolcyJudul.Text = ""
        lblPolcyAlasan.Text = ""
        lblPolcyTanggal.Text = ""
        lblPolcyUser.Text = ""

        TxtDisetujuiTahun.Text = "" : Label50.Text = ""
        lblDisetujuiHrgUnit.Text = ""
        TxtDisetujuiHrgDisc.Text = "" : TxtDisetujuiHrgDisc0.Text = ""
        TxtDisetujuiHrgSubs.Text = ""
        TxtDisetujuiHrgKoms.Text = ""
        LblTotalSetuju.Text = ""

        lblPengajuanTahun.Text = ""
        LblPengajuanHargaUnit.Text = ""
        LblPengajuanHargaDisc.Text = ""
        LblPengajuanHargaSubs.Text = ""
        LblPengajuanHargaKoms.Text = ""
        LblTotalPengajuan.Text = ""


        lblPerubahanTahun.Text = ""
        LblPerubahanHargaUnit.Text = ""
        LblPerubahanHargaDisc.Text = ""
        LblPerubahanHargaSubs.Text = ""
        LblPerubahanHargaKoms.Text = ""
        LblTotalPerubahan.Text = ""

        LblStatusUpdateSPK.Text = ""
        CheckAksesoris.Checked = False
        LblBlockPesan.Text = ""
        LblBlockPesanR.Text = ""
        LblBlockPesanC.Text = ""
        LblWarning.Text = ""
        TxtDisetujuiNoRangka.Text = "" : LblNoteAsuransi.Text = "" : lblDisetujuiNoRangka.Text = "" : lblDisetujuiNoRangkaTmp.Text = ""
        LblAksesorisHdiary.Text = ""
        Call TabelKosong()
    End Sub

    Sub TabelKosong()
        LblPindahDanaSPKJuml.Text = ""
        Lbl01Mhn.Text = "" : Lbl01Apv.Text = "" : Lbl01ApvP.Text = "" : Lbl01Judul.Text = "" : Lbl01Alasan.Text = "" : Lbl01Nilai.Text = "" : Lbl01Tanggal.Text = "" : Lbl01User.Text = "" : ChkBox1.Checked = False : ChkBox1.Visible = False : ChkBox1.Checked = False : ChkBox1.Text = ""
        Lbl02Mhn.Text = "" : Lbl02Apv.Text = "" : Lbl02ApvP.Text = "" : Lbl02Judul.Text = "" : Lbl02Alasan.Text = "" : Lbl02Nilai.Text = "" : Lbl02Tanggal.Text = "" : Lbl02User.Text = "" : ChkBox2.Checked = False : ChkBox2.Visible = False : ChkBox2.Checked = False : ChkBox2.Text = ""
        Lbl03Mhn.Text = "" : Lbl03Apv.Text = "" : Lbl03ApvP.Text = "" : Lbl03Judul.Text = "" : Lbl03Alasan.Text = "" : Lbl03Nilai.Text = "" : Lbl03Tanggal.Text = "" : Lbl03User.Text = "" : ChkBox3.Checked = False : ChkBox3.Visible = False : ChkBox3.Checked = False : ChkBox3.Text = ""
        Lbl04Mhn.Text = "" : Lbl04Apv.Text = "" : Lbl04ApvP.Text = "" : Lbl04Judul.Text = "" : Lbl04Alasan.Text = "" : Lbl04Nilai.Text = "" : Lbl04Tanggal.Text = "" : Lbl04User.Text = "" : ChkBox4.Checked = False : ChkBox4.Visible = False : ChkBox4.Checked = False : ChkBox4.Text = ""
        Lbl05Mhn.Text = "" : Lbl05Apv.Text = "" : Lbl05ApvP.Text = "" : Lbl04Judul.Text = "" : Lbl05Alasan.Text = "" : Lbl05Nilai.Text = "" : Lbl05Tanggal.Text = "" : Lbl05User.Text = "" : ChkBox5.Checked = False : ChkBox5.Visible = False : ChkBox5.Checked = False : ChkBox5.Text = ""
        Lbl06Mhn.Text = "" : Lbl06Apv.Text = "" : Lbl06ApvP.Text = "" : Lbl05Judul.Text = "" : Lbl06Alasan.Text = "" : Lbl06Nilai.Text = "" : Lbl06Tanggal.Text = "" : Lbl06User.Text = "" : ChkBox6.Checked = False : ChkBox6.Visible = False : ChkBox6.Checked = False : ChkBox6.Text = ""
        Lbl07Mhn.Text = "" : Lbl07Apv.Text = "" : Lbl07ApvP.Text = "" : Lbl06Judul.Text = "" : Lbl07Alasan.Text = "" : Lbl07Nilai.Text = "" : Lbl07Tanggal.Text = "" : Lbl07User.Text = "" : ChkBox7.Checked = False : ChkBox7.Visible = False : ChkBox7.Checked = False : ChkBox7.Text = ""
        Lbl08Mhn.Text = "" : Lbl08Apv.Text = "" : Lbl08ApvP.Text = "" : Lbl08Judul.Text = "" : Lbl08Alasan.Text = "" : Lbl08Nilai.Text = "" : Lbl08Tanggal.Text = "" : Lbl08User.Text = "" : ChkBox8.Checked = False : ChkBox8.Visible = False : ChkBox8.Checked = False : ChkBox8.Text = ""
        Lbl09Mhn.Text = "" : Lbl09Apv.Text = "" : Lbl09ApvP.Text = "" : Lbl09Judul.Text = "" : Lbl09Alasan.Text = "" : Lbl09Nilai.Text = "" : Lbl09Tanggal.Text = "" : Lbl09User.Text = "" : ChkBox9.Checked = False : ChkBox9.Visible = False : ChkBox9.Checked = False : ChkBox9.Text = ""
        Lbl10Mhn.Text = "" : Lbl10Apv.Text = "" : Lbl10ApvP.Text = "" : Lbl10Judul.Text = "" : Lbl10Alasan.Text = "" : Lbl10Nilai.Text = "" : Lbl10Tanggal.Text = "" : Lbl10User.Text = "" : ChkBox10.Checked = False : ChkBox10.Visible = False : ChkBox10.Checked = False : ChkBox10.Text = ""
    End Sub

    Sub insert_tabel(ByVal pmLblMhn As String, ByVal pmLblApv As String, ByVal pmLblApvp As String, ByVal pmLblJudul As String, ByVal pmLblAlasan As String, ByVal pmLblTanggal As String, ByVal pmLblNomor As String, ByVal pmLbluser As String, ByVal pmLblChange0 As String, ByVal pmLblChange1 As String, ByVal pmLblChange2 As String, ByVal pmLblChange3 As String, ByVal pmLblChange4 As String)
        Dim mChange As String = Keterangan_perubahannya(pmLblJudul, pmLblChange0, pmLblChange1, pmLblChange2, pmLblChange3, pmLblChange4)

        If Lbl01Mhn.Text = "" Then
            Lbl01Mhn.Text = pmLblMhn : Lbl01Apv.Text = pmLblApv : Lbl01ApvP.Text = pmLblApvp : Lbl01Judul.Text = pmLblJudul : Lbl01Alasan.Text = pmLblAlasan : Lbl01Nilai.Text = mChange : Lbl01Tanggal.Text = pmLblTanggal : Lbl01Nomor.Text = pmLblNomor : Lbl01User.Text = pmLbluser : ChkBox1.Checked = True : ChkBox1.Visible = True
        ElseIf Lbl02Mhn.Text = "" Then
            Lbl02Mhn.Text = pmLblMhn : Lbl02Apv.Text = pmLblApv : Lbl02ApvP.Text = pmLblApvp : Lbl02Judul.Text = pmLblJudul : Lbl02Alasan.Text = pmLblAlasan : Lbl02Nilai.Text = mChange : Lbl02Tanggal.Text = pmLblTanggal : Lbl02Nomor.Text = pmLblNomor : Lbl02User.Text = pmLbluser : ChkBox2.Checked = True : ChkBox2.Visible = True
        ElseIf Lbl03Mhn.Text = "" Then
            Lbl03Mhn.Text = pmLblMhn : Lbl03Apv.Text = pmLblApv : Lbl03ApvP.Text = pmLblApvp : Lbl03Judul.Text = pmLblJudul : Lbl03Alasan.Text = pmLblAlasan : Lbl03Nilai.Text = mChange : Lbl03Tanggal.Text = pmLblTanggal : Lbl03Nomor.Text = pmLblNomor : Lbl03User.Text = pmLbluser : ChkBox3.Checked = True : ChkBox3.Visible = True
        ElseIf Lbl04Mhn.Text = "" Then
            Lbl04Mhn.Text = pmLblMhn : Lbl04Apv.Text = pmLblApv : Lbl04ApvP.Text = pmLblApvp : Lbl04Judul.Text = pmLblJudul : Lbl04Alasan.Text = pmLblAlasan : Lbl04Nilai.Text = mChange : Lbl04Tanggal.Text = pmLblTanggal : Lbl04Nomor.Text = pmLblNomor : Lbl04User.Text = pmLbluser : ChkBox4.Checked = True : ChkBox4.Visible = True
        ElseIf Lbl05Mhn.Text = "" Then
            Lbl05Mhn.Text = pmLblMhn : Lbl05Apv.Text = pmLblApv : Lbl05ApvP.Text = pmLblApvp : Lbl05Judul.Text = pmLblJudul : Lbl05Alasan.Text = pmLblAlasan : Lbl05Nilai.Text = mChange : Lbl05Tanggal.Text = pmLblTanggal : Lbl05Nomor.Text = pmLblNomor : Lbl05User.Text = pmLbluser : ChkBox5.Checked = True : ChkBox5.Visible = True
        ElseIf Lbl06Mhn.Text = "" Then
            Lbl06Mhn.Text = pmLblMhn : Lbl06Apv.Text = pmLblApv : Lbl06ApvP.Text = pmLblApvp : Lbl06Judul.Text = pmLblJudul : Lbl06Alasan.Text = pmLblAlasan : Lbl06Nilai.Text = mChange : Lbl06Tanggal.Text = pmLblTanggal : Lbl06Nomor.Text = pmLblNomor : Lbl06User.Text = pmLbluser : ChkBox6.Checked = True : ChkBox6.Visible = True
        ElseIf Lbl07Mhn.Text = "" Then
            Lbl07Mhn.Text = pmLblMhn : Lbl07Apv.Text = pmLblApv : Lbl07ApvP.Text = pmLblApvp : Lbl07Judul.Text = pmLblJudul : Lbl07Alasan.Text = pmLblAlasan : Lbl07Nilai.Text = mChange : Lbl07Tanggal.Text = pmLblTanggal : Lbl07Nomor.Text = pmLblNomor : Lbl07User.Text = pmLbluser : ChkBox7.Checked = True : ChkBox7.Visible = True
        ElseIf Lbl08Mhn.Text = "" Then
            Lbl08Mhn.Text = pmLblMhn : Lbl08Apv.Text = pmLblApv : Lbl08ApvP.Text = pmLblApvp : Lbl08Judul.Text = pmLblJudul : Lbl08Alasan.Text = pmLblAlasan : Lbl08Nilai.Text = mChange : Lbl08Tanggal.Text = pmLblTanggal : Lbl08Nomor.Text = pmLblNomor : Lbl08User.Text = pmLbluser : ChkBox8.Checked = True : ChkBox8.Visible = True
        ElseIf Lbl09Mhn.Text = "" Then
            Lbl09Mhn.Text = pmLblMhn : Lbl09Apv.Text = pmLblApv : Lbl09ApvP.Text = pmLblApvp : Lbl09Judul.Text = pmLblJudul : Lbl09Alasan.Text = pmLblAlasan : Lbl09Nilai.Text = mChange : Lbl09Tanggal.Text = pmLblTanggal : Lbl09Nomor.Text = pmLblNomor : Lbl09User.Text = pmLbluser : ChkBox9.Checked = True : ChkBox9.Visible = True
        ElseIf Lbl10Mhn.Text = "" Then
            Lbl10Mhn.Text = pmLblMhn : Lbl10Apv.Text = pmLblApv : Lbl10ApvP.Text = pmLblApvp : Lbl10Judul.Text = pmLblJudul : Lbl10Alasan.Text = pmLblAlasan : Lbl10Nilai.Text = mChange : Lbl10Tanggal.Text = pmLblTanggal : Lbl10Nomor.Text = pmLblNomor : Lbl10User.Text = pmLbluser : ChkBox10.Checked = True : ChkBox10.Visible = True
        End If
    End Sub

    Function Keterangan_perubahannya(ByVal mpJudul As String, ByVal mpChange0 As String, ByVal mpChange1 As String, ByVal mpChange2 As String, ByVal mpChange3 As String, ByVal mpChange4 As String) As String
        Keterangan_perubahannya = ""
        mpJudul = UCase(mpJudul)
        If InStr(mpJudul, "UBAH HARGA UNIT MENJADI") <> 0 Then
            Keterangan_perubahannya = "Ubah Harga Unit Menjadi Rp." & fLg(mpChange0) & ""
        ElseIf InStr(mpJudul, "UBAH HARGA DISKON MENJADI") <> 0 Then
            Keterangan_perubahannya = "Ubah Harga Diskon Menjadi Rp." & fLg(mpChange1) & ""
        ElseIf InStr(mpJudul, "SUBSIDI") <> 0 Then
            Keterangan_perubahannya = "Ubah Harga Subsidi Menjadi Rp." & fLg(mpChange2) & ""
        ElseIf InStr(mpJudul, "KOMISI") <> 0 Then
            Keterangan_perubahannya = "Ubah Harga Komisi Menjadi Rp." & fLg(mpChange3) & ""
        ElseIf InStr(mpJudul, "MELEBIHI MAKSIMAL DISKON") <> 0 Then
            Keterangan_perubahannya = "Ubah Harga Diskon Menjadi Rp." & fLg(mpChange1) & ",Harga subsidi Menjadi Rp." & fLg(mpChange2) & ",Harga Komisi Menjadi Rp." & fLg(mpChange3) & " "
        ElseIf InStr(mpJudul, "DO/ISI NOMOR RANGKA") <> 0 Then
            Keterangan_perubahannya = "Kunci Rangka DO SPK dengan no rangka " & mpChange0 & ""
        ElseIf InStr(mpJudul, "PAKET CERMAT") <> 0 Then
            Keterangan_perubahannya = "Paket cermat Rp." & fLg(mpChange0) & ""
        ElseIf InStr(mpJudul, "SELISIH HARGA UNIT BEDA TAHUN") <> 0 Then
            Keterangan_perubahannya = "Selisih harga unit karena beda tahun Rp." & fLg(mpChange0) & ""
        ElseIf InStr(mpJudul, "PERPANJANG MASA WAKTU UANG MUKA") <> 0 Then
            Keterangan_perubahannya = "Perpanjang/Tambah Umur Uang muka menjadi " & mpChange0 & " Hari"
        ElseIf InStr(mpJudul, "CANCEL SPK HMS") <> 0 Then
            Keterangan_perubahannya = "Permohoan SPK cancel di Sistem Mugen/HMS"
        ElseIf InStr(mpJudul, "PINDAH DANA ANTAR SPK") <> 0 Then
            Keterangan_perubahannya = "Pindah dana sebesar " & fLg(mpChange0) & " ke nomor spk " & mpChange1 & IIf(mpChange2 <> "", " (" & mpChange2 & "/" & mpChange3 & ")", "")
        ElseIf InStr(mpJudul, "KIRIM UNIT CUSTOMER") <> 0 Then
            Keterangan_perubahannya = "Tanggal Dan Jam Kirim [" & mpChange0 & "] Di kirim ke alamat " & mpChange1 & mpChange2 & mpChange3 & mpChange4
        End If
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


    'layar Start penngajuann permohonan

    Protected Sub ButtonSetuju0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetuju0.Click
        BtnTolak0.Enabled = False
        If Periksa_SPK_Gantung() = 1 Then
            lblTglsetuju0.Text = "Persetujuan tidak bisa dilanjutkan karena Ada SPK Gantung belum ada status kelanjutanya (Lihat di Status SPK)"
        Else
            Call Rubah_Status("SETUJU", 0)
        End If
        BtnTolak0.Enabled = True
    End Sub
    Protected Sub BtnTolak0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTolak0.Click
        Call Rubah_Status("TOLAK", 0)
    End Sub

    Protected Sub ButtonSetuju1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetuju1.Click
        BtnTolak1.Enabled = False
        Call Rubah_Status("SETUJU", 1)
        BtnTolak1.Enabled = True
    End Sub
    Protected Sub BtnTolak1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTolak1.Click
        Call Rubah_Status("TOLAK", 1)
    End Sub

    Protected Sub ButtonSetuju2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetuju2.Click
        BtnTolak2.Enabled = False
        Call Rubah_Status("SETUJU", 2)
        BtnTolak2.Enabled = True
    End Sub
    Protected Sub BtnTolak2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTolak2.Click
        Call Rubah_Status("TOLAK", 2)
    End Sub

    Protected Sub BtnSetuju3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetuju3.Click
        BtnTolak3.Enabled = False
        Call Rubah_Status("SETUJU", 3)
        BtnTolak3.Enabled = True
    End Sub
    Protected Sub BtnTolak3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTolak3.Click
        Call Rubah_Status("TOLAK", 3)
    End Sub
    Protected Sub BtnSetuju4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetuju4.Click
        BtnTolak4.Enabled = False
        Call Rubah_Status("SETUJU", 4)
        BtnTolak4.Enabled = True
    End Sub
    Protected Sub BtnTolak4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTolak4.Click
        Call Rubah_Status("TOLAK", 4)
    End Sub

    Protected Sub BtnSetuju5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetuju5.Click
        BtnTolak5.Enabled = False
        Call Rubah_Status("SETUJU", 5)
        BtnTolak5.Enabled = True
    End Sub
    Protected Sub BtnTolak5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTolak5.Click
        Call Rubah_Status("TOLAK", 5)
    End Sub

    Function GetValidasi_Asesoris(ByVal mSqlCommadstring As String, ByVal mSqlFindFiled As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetValidasi_Asesoris = "0"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If mSqlFindFiled = "OPT_TIPE" Then
                If MyRecReadA.HasRows = True Then
                    While MyRecReadA.Read()
                        If lblGroupTipe.Text <> (nSr(MyRecReadA("OPT_TIPE"))) Then
                            GetValidasi_Asesoris = "1"
                        End If
                    End While
                End If
            Else
                MyRecReadA.Read()
                GetValidasi_Asesoris = nSr(MyRecReadA("OPT_TIPE"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function


    Sub Rubah_Status(ByVal mStatus As String, ByVal mGol As Byte)
        Dim mError As String = ""
        Dim mIsi As String = ""
        Dim mPos As String = ""

        If MultiViewENTRY.ActiveViewIndex = 0 Then Call TabelError()

        If InStr(lblPolcyNomorMohon.Text, "WB/APR/DO") <> 0 Then 'Setuju Faktur
            If TxtDisetujuiNoRangka.Text = lblDisetujuiNoRangkaTmp.Text And _
               lblDisetujuiNoRangkaTmp.Text <> "" And _
               lblDisetujuiNoRangka.Text <> lblDisetujuiNoRangkaTmp.Text And mGol <= 1 Then
                LblBlockPesanR.Text = ""
            End If
        End If



        If MultiViewENTRY.ActiveViewIndex = 1 And mStatus = "SETUJU" Then
            'Kalau Batal SPK Bagaimana
            If InStr(lblPolcyNomorMohon.Text, "WB/APR/AS") <> 0 Then 'Pasang Aksesoris
                Call GetDataA_Rangka_TYPE("SELECT * FROM DATA_TYPE WHERE TYPE_Type='" & LblCdType.Text & "'")
                If LblTglDO.Text = "" Then
                    mError = mError & ("SPK Belum DO Tidak Bisa pasang Aksesoris .....")
                ElseIf GetValidasi_Asesoris("SELECT * FROM TRXN_OPTPO WHERE OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_STATUSPROSES LIKE 'ENTRY%'", "OPT_TIPE") = 1 Then
                    mError = mError & ("Ada tipe unit Aksesoris Tidak sama dengan Tipe SPK.....")
                End If
            ElseIf InStr(lblPolcyNomorMohon.Text, "WB/APR/DO") <> 0 Then 'Pengajuan DO 
                'Periksa persyaratanya
                If TxtDisetujuiNoRangka.Text = "" Then
                    mError = mError & ("Nomor rangka belum terisi.....")
                ElseIf LblTglDO.Text <> "" Then
                    mError = mError & ("Sudah DO (lihat tanggal DO dan rangka.....")
                ElseIf CheckAksesoris.Checked = True And GetDataA_Validasi_Asesoris("SELECT * FROM TRXN_OPTPO WHERE OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_STATUSPROSES LIKE 'ENTRY%'", "OPT_TIPE") = 1 Then
                    mError = mError & ("Ada tipe unit Aksesoris Tidak sama dengan Tipe SPK.....")
                End If
                If mGol = 1 Then
                    If GetDataD_00NoFound01Found("SELECT * FROM TRXN_OPTPO WHERE OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_STATUSPROSES LIKE 'ENTRY%' AND (OPT_USERAPPV1 IS NULL OR OPT_USERAPPV1='') AND NOT(OPT_SPV='SC' OR OPT_SPV='UG' OR OPT_SPV='FZ')", "") = 1 Then
                        mError = mError & ("Ada Aksesoris yang belum disetujui/Ditolak/Susulan oleh SPV.....")
                    End If
                End If

            ElseIf InStr(lblPolcyNomorMohon.Text, "WB/APR/FT") <> 0 Then 'Pengajuan DO 
                'If LblCatatanUM.Text <> "" Then
                'mError = mError & ("Ada Kesalahan di uang muka.....")
                'End If
            ElseIf InStr(lblPolcyNomorMohon.Text, "WB/APR/SD") <> 0 Then 'Maksimal diskon
                If (nLg(TxtDisetujuiHrgDisc0.Text) + nLg(LblPengajuanHargaDisc.Text)) < nLg(TxtDisetujuiHrgDisc.Text) Then
                    'mError = mError & ("Diskon tidak boleh lebih besar daripada diskon h_diary.....")
                End If
            End If
        End If


        If InStr(lblArea1.Text, lblDealer.Text) = 0 And InStr(lblArea2.Text, lblDealer.Text) = 0 Then
            mError = mError & ("Tidak bisa merubah untuk kode dealer " & lblDealer.Text)
        ElseIf LblNama.Text = "" And mStatus <> "TOLAK" Then
            mError = mError & ("Data Pembeli Belum lengkap ")
        ElseIf MultiViewENTRY.ActiveViewIndex = 0 And ChkBox1.Checked = False And ChkBox2.Checked = False And ChkBox3.Checked = False And ChkBox4.Checked = False And ChkBox5.Checked = False And _
               ChkBox6.Checked = False And ChkBox7.Checked = False And ChkBox8.Checked = False And ChkBox9.Checked = False And ChkBox10.Checked = False Then
            mError = mError & ("Tidak ada persetujuan/penolakan yang dipilih dari tabel")
        ElseIf Mid(lblAkses.Text, 2, 1) <> "1" And mGol = 0 Then
            mError = mError & ("Anda Tidak diperbolehkan melakukan persetujuan oleh Sales Supervicor .....")
        ElseIf Mid(lblAkses.Text, 3, 1) <> "1" And mGol = 1 Then
            mError = mError & ("Anda Tidak diperbolehkan melakukan persetujuan oleh Sales Manager .....")
        ElseIf Mid(lblAkses.Text, 4, 1) <> "1" And mGol = 2 Then
            mError = mError & ("Anda Tidak diperbolehkan melakukan persetujuan oleh OSM .....")
        ElseIf Mid(lblAkses.Text, 5, 1) <> "1" And mGol = 3 Then
            mError = mError & ("Anda Tidak diperbolehkan melakukan persetujuan oleh Direktur .....")
        ElseIf Mid(lblAkses.Text, 9, 1) <> "1" And mGol = 4 Then
            mError = mError & ("Anda Tidak diperbolehkan melakukan persetujuan oleh ADH .....")
        ElseIf Mid(lblAkses.Text, 10, 1) <> "1" And mGol = 5 Then
            mError = mError & ("Anda Tidak diperbolehkan melakukan persetujuan oleh Accounting .....")
        ElseIf (LblBlockPesan.Text & LblBlockPesanR.Text) <> "" And mStatus <> "TOLAK" Then
            mError = mError & ("Proses tidak bisa dilanjutkan lihat Catatan SPK !!!!! .....")
        ElseIf MultiView0S.ActiveViewIndex = 0 And lblTglsetuju0.Text = "" And mGol = 0 Then   'SPV Validasi
            If TxtCatatan0.Text = "" Then
                mError = mError & ("Catatan Persetujuan Sales Supervisor belum diisi .....")
            Else
                mIsi = TxtCatatan0.Text
                mPos = "0"
            End If
        ElseIf MultiView1S.ActiveViewIndex = 0 And lblTglSetuju1.Text = "" And mGol = 1 Then   'SM Validasi
            If TxtCatatan1.Text = "" Then
                mError = mError & ("Catatan Persetujuan Sales Manager belum diisi .....")
                'ElseIf (MultiView0S.ActiveViewIndex = 0 And lblTglsetuju0.Text = "") And mStatus <> "TOLAK" And InStr(lblPolcyNomorMohon.Text, "WB/APR/AS") = 0 Then
                '    mError = mError & ("Persetujuan yang sebelumnya belum dilakukan .....")
            Else
                mIsi = TxtCatatan1.Text
                mPos = "1"
            End If

        ElseIf MultiView2S.ActiveViewIndex = 0 And lblTglSetuju2.Text = "" And mGol = 2 Then   'OSM Validasi
            If TxtCatatan2.Text = "" Then
                mError = mError & ("Catatan Persetujuan OSM belum diisi .....")
            ElseIf (MultiView1S.ActiveViewIndex = 0 And lblTglSetuju1.Text = "") Then
                mError = mError & ("Persetujuan yang sebelunya belum dilakukan .....")
            Else
                mIsi = TxtCatatan2.Text
                mPos = "2"
            End If
        ElseIf MultiView3S.ActiveViewIndex = 0 And LblTglSetuju3.Text = "" And mGol = 3 Then   'DIR Validasi
            If TxtCatatan3.Text = "" Then
                mError = mError & ("Catatan Persetujuan Direktur belum diisi .....")
                'ElseIf TxtDisetujuiHrgUnit.Text <> "" And IsNumeric(TxtDisetujuiHrgUnit.Text) = False Then
                '    mError = mError & ("Isi nilai unit dengan tipe numerik atau Kosongkan.....")
            ElseIf TxtDisetujuiHrgDisc.Text <> "" And IsNumeric(TxtDisetujuiHrgDisc.Text) = False Then
                mError = mError & ("Isi nilai diskon dengan tipe numerik atau Kosongkan.....")
            ElseIf TxtDisetujuiHrgSubs.Text <> "" And IsNumeric(TxtDisetujuiHrgSubs.Text) = False Then
                mError = mError & ("Isi nilai subsidi dengan tipe numerik atau Kosongkan.....")
            ElseIf TxtDisetujuiHrgKoms.Text <> "" And IsNumeric(TxtDisetujuiHrgKoms.Text) = False Then
                mError = mError & ("Isi nilai komisi dengan tipe numerik atau Kosongkan.....")
            ElseIf (MultiView1S.ActiveViewIndex = 0 And lblTglSetuju1.Text = "") Then
                mError = mError & ("Persetujuan yang SM belum dilakukan .....")
            Else
                mIsi = TxtCatatan3.Text
                mPos = "3"
            End If
        ElseIf MultiView4S.ActiveViewIndex = 0 And LblTglSetuju4.Text = "" And mGol = 4 Then   'OSM Validasi
            If TxtCatatan4.Text = "" Then
                mError = mError & ("Catatan Persetujuan belum diisi .....")
            ElseIf (MultiView1S.ActiveViewIndex = 0 And lblTglSetuju1.Text = "") Then
                mError = mError & ("Persetujuan yang SM belum dilakukan .....")
            Else
                mIsi = TxtCatatan4.Text
                mPos = "4"
            End If
        ElseIf MultiView5S.ActiveViewIndex = 0 And LblTglSetuju5.Text = "" And mGol = 5 Then   'OSM Validasi
            If TxtCatatan5.Text = "" Then
                mError = mError & ("Catatan Persetujuan belum diisi .....")
            ElseIf (MultiView1S.ActiveViewIndex = 0 And lblTglSetuju1.Text = "") Or _
                   (MultiView4S.ActiveViewIndex = 0 And LblTglSetuju4.Text = "") Then
                mError = mError & ("Persetujuan yang ADH belum dilakukan .....")
            Else
                mIsi = TxtCatatan5.Text
                mPos = "5"
            End If
        End If

        If mError = "" And mPos <> "" Then
            If MultiViewENTRY.ActiveViewIndex = 0 Then
                If ChkBox1.Checked = True And ChkBox1.Text = "" Then Call UpdateDataMohon(Lbl01Mhn.Text, Lbl01Nomor.Text, Lbl01Judul.Text, Lbl01Alasan.Text, mStatus, mIsi, mPos, 1)
                If ChkBox2.Checked = True And ChkBox2.Text = "" Then Call UpdateDataMohon(Lbl02Mhn.Text, Lbl02Nomor.Text, Lbl02Judul.Text, Lbl02Alasan.Text, mStatus, mIsi, mPos, 2)
                If ChkBox3.Checked = True And ChkBox3.Text = "" Then Call UpdateDataMohon(Lbl03Mhn.Text, Lbl03Nomor.Text, Lbl03Judul.Text, Lbl03Alasan.Text, mStatus, mIsi, mPos, 3)
                If ChkBox4.Checked = True And ChkBox4.Text = "" Then Call UpdateDataMohon(Lbl04Mhn.Text, Lbl04Nomor.Text, Lbl04Judul.Text, Lbl04Alasan.Text, mStatus, mIsi, mPos, 4)
                If ChkBox5.Checked = True And ChkBox5.Text = "" Then Call UpdateDataMohon(Lbl05Mhn.Text, Lbl05Nomor.Text, Lbl05Judul.Text, Lbl05Alasan.Text, mStatus, mIsi, mPos, 5)
                If ChkBox6.Checked = True And ChkBox6.Text = "" Then Call UpdateDataMohon(Lbl06Mhn.Text, Lbl06Nomor.Text, Lbl06Judul.Text, Lbl06Alasan.Text, mStatus, mIsi, mPos, 6)
                If ChkBox7.Checked = True And ChkBox7.Text = "" Then Call UpdateDataMohon(Lbl07Mhn.Text, Lbl07Nomor.Text, Lbl07Judul.Text, Lbl07Alasan.Text, mStatus, mIsi, mPos, 7)
                If ChkBox8.Checked = True And ChkBox8.Text = "" Then Call UpdateDataMohon(Lbl08Mhn.Text, Lbl08Nomor.Text, Lbl08Judul.Text, Lbl08Alasan.Text, mStatus, mIsi, mPos, 8)
                If ChkBox9.Checked = True And ChkBox9.Text = "" Then Call UpdateDataMohon(Lbl09Mhn.Text, Lbl09Nomor.Text, Lbl09Judul.Text, Lbl09Alasan.Text, mStatus, mIsi, mPos, 9)
                If ChkBox10.Checked = True And ChkBox10.Text = "" Then Call UpdateDataMohon(Lbl10Mhn.Text, Lbl10Nomor.Text, Lbl10Judul.Text, Lbl10Alasan.Text, mStatus, mIsi, mPos, 10)
            ElseIf MultiViewENTRY.ActiveViewIndex = 1 Then
                If (MultiViewSetujuFaktur.ActiveViewIndex <> 0 And MultiViewSetujuRangka.ActiveViewIndex <> 0) And _
                    MultiViewSetujuAsesoris.ActiveViewIndex = 0 Then 'Aksesoris
                    Call UpdateDataMohonAksesoris(lblPolcyNomorMohon.Text, lblPolcyJudul.Text, lblPolcyAlasan.Text, mStatus, mIsi, mPos, 0)
                ElseIf MultiViewSetujuRangka.ActiveViewIndex = 0 Then 'DO
                    Call UpdateDataMohon(lblPolcyNomorMohon.Text, lblNomorSetuju.Text, lblPolcyJudul.Text, lblPolcyAlasan.Text, mStatus, mIsi, mPos, 99)
                    If CheckAksesoris.Checked = False Then
                        Call UpdateDataMohonAksesoris(lblPolcyNomorMohon.Text, lblPolcyJudul.Text, lblPolcyAlasan.Text, mStatus, mIsi, mPos, 1)
                    End If
                ElseIf MultiViewSetujuFaktur.ActiveViewIndex = 0 Then 'Faktur
                    Call UpdateDataMohon(lblPolcyNomorMohon.Text, lblNomorSetuju.Text, lblPolcyJudul.Text, lblPolcyAlasan.Text, mStatus, mIsi, mPos, 99)
                Else
                    Call UpdateDataMohon(lblPolcyNomorMohon.Text, lblNomorSetuju.Text, lblPolcyJudul.Text, lblPolcyAlasan.Text, mStatus, mIsi, mPos, 99)
                End If
            End If
        Else
            Call Msg_err(IIf(mError = "", "SUDAH DIAKUKAN DISETUJUI/DITOLAK", mError), "LIHAT")
        End If
    End Sub


    Function UpdateDataMohon(ByVal mIdNo As String, ByVal mNoUrut As String, ByVal mEntry As String, ByVal mAlasan As String, ByVal mSetujuTolak As String, ByVal mCatatan As String, ByVal mPosisi As String, ByVal mBaRIS As Byte) As Byte
        Call Msg_err("", "")
        UpdateDataMohon = 0
        Dim mTextSql As String = ""
        Dim mNomorSPKAH_SqlUpdate As String
        mNomorSPKAH_SqlUpdate = mNoUrut
        If mPosisi = "0" And (lblTglsetuju0.Text = "" Or (lblTglsetuju0.Text <> "" And mNoUrut = "")) Then
            lblTglsetuju0.Text = UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi, mBaRIS, mNoUrut, mIdNo)
        ElseIf mPosisi = "1" And (lblTglSetuju1.Text = "" Or (lblTglSetuju1.Text <> "" And mNoUrut = "")) Then
            lblTglSetuju1.Text = UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi, mBaRIS, mNoUrut, mIdNo)
        ElseIf mPosisi = "2" And (lblTglSetuju2.Text = "" Or (lblTglSetuju2.Text <> "" And mNoUrut = "")) Then
            lblTglSetuju2.Text = UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi, mBaRIS, mNoUrut, mIdNo)
        ElseIf mPosisi = "3" And (LblTglSetuju3.Text = "" Or (LblTglSetuju3.Text <> "" And mNoUrut = "")) Then
            LblTglSetuju3.Text = UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi, mBaRIS, mNoUrut, mIdNo)
        ElseIf mPosisi = "4" And (LblTglSetuju4.Text = "" Or (LblTglSetuju4.Text <> "" And mNoUrut = "")) Then
            LblTglSetuju4.Text = UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi, mBaRIS, mNoUrut, mIdNo)
        ElseIf mPosisi = "5" And (LblTglSetuju5.Text = "" Or (LblTglSetuju5.Text <> "" And mNoUrut = "")) Then
            LblTglSetuju5.Text = UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi, mBaRIS, mNoUrut, mIdNo)
            'ElseIf mBaRIS <> 99 And lblTglsetuju0.Text <> "" Then
            '    UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi, mBaRIS, mNoUrut)
        End If

        If mBaRIS <> 99 Then
            If mBaRIS = 1 Then mNoUrut = Lbl01Nomor.Text
            If mBaRIS = 2 Then mNoUrut = Lbl02Nomor.Text
            If mBaRIS = 3 Then mNoUrut = Lbl03Nomor.Text
            If mBaRIS = 4 Then mNoUrut = Lbl04Nomor.Text
            If mBaRIS = 5 Then mNoUrut = Lbl05Nomor.Text
            If mBaRIS = 6 Then mNoUrut = Lbl06Nomor.Text
            If mBaRIS = 7 Then mNoUrut = Lbl07Nomor.Text
            If mBaRIS = 8 Then mNoUrut = Lbl08Nomor.Text
            If mBaRIS = 9 Then mNoUrut = Lbl09Nomor.Text
            If mBaRIS = 10 Then mNoUrut = Lbl10Nomor.Text
        Else
            mNoUrut = lblNomorSetuju.Text
        End If
        mNomorSPKAH_SqlUpdate = mNoUrut

        If mNoUrut <> "" Then
            Dim mChangeHarga As String = ""
            If MultiViewENTRY.ActiveViewIndex = 1 Then
                If InStr(mIdNo, "WB/APR/SD") <> 0 Then  'Setuju Diskon,Subsidi dan komisi
                    mChangeHarga = ",CHANGE1='" & TxtDisetujuiHrgDisc.Text & "',CHANGE2='" & TxtDisetujuiHrgSubs.Text & "',CHANGE3='" & TxtDisetujuiHrgKoms.Text & "',CHANGE4='" & TxtDisetujuiTahun.Text & "' "
                ElseIf InStr(mIdNo, "WB/APR/FT") <> 0 Then 'Setuju hanya Faktur
                    If UpdateDatabase_Tabel("UPDATE TRXN_SPKAF SET SPKAF_NOMOR='" & mNoUrut & "' WHERE SPKAF_NOMORMOHON = '" & mIdNo & "' AND SPKAF_NOMOR=''", "") = 1 Then
                        Call TandaResult(mBaRIS, mSetujuTolak)
                    End If
                ElseIf InStr(mIdNo, "WB/APR/DO") <> 0 Then 'Setuju Faktur plus DO
                    If TxtDisetujuiNoRangka.Text = lblDisetujuiNoRangkaTmp.Text And _
                       lblDisetujuiNoRangkaTmp.Text <> "" And _
                       lblDisetujuiNoRangka.Text <> lblDisetujuiNoRangkaTmp.Text Then
                        mChangeHarga = ",CHANGE='" & TxtDisetujuiNoRangka.Text & "',TANGGAL_PROSES=NULL "
                    End If
                End If
            End If

            Dim mPosTerakhir As String
            mPosTerakhir = ""
            If MultiView5S.ActiveViewIndex = 0 Then
                mPosTerakhir = "5"
            ElseIf MultiView4S.ActiveViewIndex = 0 Then
                mPosTerakhir = "4"
            ElseIf MultiView3S.ActiveViewIndex = 0 Then
                mPosTerakhir = "3"
            ElseIf MultiView2S.ActiveViewIndex = 0 Then
                mPosTerakhir = "2"
            ElseIf MultiView1S.ActiveViewIndex = 0 Then
                mPosTerakhir = "1"
            ElseIf MultiView0S.ActiveViewIndex = 0 Then
                mPosTerakhir = "0"
            End If
            Dim mSukses As Byte = 0

            If mPosTerakhir = mPosisi Or mSetujuTolak = "TOLAK" Then
                If mSetujuTolak = "SETUJU" And InStr(mIdNo, "WB/APR/SW") <> 0 Then
                    If LblPindahDanaTipe.Text = "JENIS PINDAH DANA VIRUAL ACCOUNT KE SPK" Then
                        mSukses = UpdateVirtualAccount_PindahDana()
                    ElseIf LblPindahDanaTipe.Text = "JENIS PINDAH DANA SPK KE SPK" Then
                        mSukses = CreateVoucher_PindahDana()
                    ElseIf LblPindahDanaTipe.Text = "ENTRY PERMOHONAN KIRIM UNIT DEALER TEST" Then
                        Call Update_Stock_Warehouse_Centralize("", "", "")
                    End If

                    If mSukses = 1 Then
                        mSukses = Update_Tabel_SPKAH_Keputusan_Terakhir(mIdNo, mEntry, mSetujuTolak, mCatatan, mPosisi, mNomorSPKAH_SqlUpdate)
                    End If
                    'ElseIf mSetujuTolak = "SETUJU" And InStr(mIdNo, "WB/APR/MC") <> 0 Then
                    '    mSukses = Validasi_Kirim_Unit(lblDealer.Text, LblNoSPK.Text, Lbl01Nilai.Text)
                    '    If mSukses = 1 Then
                    ' mSukses = Update_Tabel_SPKAH_Keputusan_Terakhir(mIdNo, mEntry, mSetujuTolak, mCatatan, mPosisi, mNomorSPKAH_SqlUpdate)
                    ' End If
                Else
                    mSukses = Update_Tabel_SPKAH_Keputusan_Terakhir(mIdNo, mEntry, mSetujuTolak, mCatatan, mPosisi, mNomorSPKAH_SqlUpdate)
                End If
                If mSetujuTolak = "SETUJU" Then
                    Call GetData_Permohon_Persetujuan_Sudah_diSetuju(mIdNo, lblDealer.Text)
                End If
            Else
                If mNomorSPKAH_SqlUpdate = "" Then
                    mTextSql = "UPDATE TRXN_SPKAH SET " & _
                               "APPROVALCODEP='" & lblPosSetuju.Text & mPosisi & "'" & mChangeHarga & ",NOMOR='" & mNoUrut & "' " & _
                               "WHERE TRXN_SPKAH.NOMOR_MOHON = '" & mIdNo & "' AND NOMOR_SPK='" & LblNoSPK.Text & "' AND CABANG='" & lblDealer.Text & "' AND (NOMOR='' OR NOMOR IS NULL) AND JUDUL like 'ENTRY%'"
                Else
                    mTextSql = "UPDATE TRXN_SPKAH SET APPROVALCODEP='" & lblPosSetuju.Text & mPosisi & "'" & mChangeHarga & " " & _
                               "WHERE TRXN_SPKAH.NOMOR_MOHON = '" & mIdNo & "' AND NOMOR_SPK='" & LblNoSPK.Text & "' AND CABANG='" & lblDealer.Text & "' AND NOMOR='" & mNoUrut & "'"
                End If
                mSukses = UpdateDatabase_Tabel(mTextSql, "")
            End If

            If mSukses = 1 Then
                Call TandaResult(mBaRIS, mSetujuTolak)
                'If mPosTerakhir = "3" And mPosisi = "2" And mSetujuTolak = "SETUJU" And InStr(mIdNo, "WB/APR/SD") <> 0 Then
                If mPosisi = "2" And mSetujuTolak = "SETUJU" And InStr(mIdNo, "WB/APR/SD") <> 0 Then
                    Call SendEmailProces("soetrisnoSusanto@gmail.com", "Permohonan persetujuan melebihi Diskon tgl " & Now() & " NOMOR " & mNoUrut, "", "", "Permohonan persetujuan melebihi Diskon tgl " & Now(), 0)
                    'Call SendEmailProces("Susantosoetrisno@yahoo.com", "Permohonan persetujuan melebihi Diskon tgl " & Now() & " NOMOR " & mNoUrut, "", "", "Permohonan persetujuan melebihi Diskon tgl " & Now(), 0)
                ElseIf mPosisi = "1" And mSetujuTolak = "SETUJU" And InStr(mIdNo, "WB/APR/SD") <> 0 Then
                    Call SendEmailProces("royke@hondamugen.co.id", "Permohonan persetujuan melebihi Diskon tgl " & Now() & " NOMOR " & mNoUrut, "", "", "Permohonan persetujuan melebihi Diskon tgl " & Now(), 0)
                ElseIf mPosisi = "1" And mSetujuTolak = "SETUJU" And InStr(mIdNo, "WB/APR/SW") <> 0 Then
                    If lblDealer.Text = "112" Then
                        Call SendEmailProces("Adm@Hondamugen.co.id", "Pindah dana Sudah disetujui oleh SM " & Now() & " NOMOR " & mNoUrut, "", "", "Pindah dana Sudah disetujui oleh SM tgl " & Now() & " buka akses HmsWeb", 0)
                    Else
                        Call SendEmailProces("Adh_puri@Hondamugen.co.id", "Pindah dana Sudah disetujui oleh SM " & Now() & " NOMOR " & mNoUrut, "", "", "Pindah dana Sudah disetujui oleh SM tgl " & Now() & " buka akses HmsWeb", 0)
                    End If
                ElseIf mPosisi = "4" And mSetujuTolak = "SETUJU" And InStr(mIdNo, "WB/APR/SW") <> 0 Then
                    Call SendEmailProces("lukasfy@Hondamugen.co.id", "Pindah dana Sudah disetujui oleh Adh " & Now() & " NOMOR " & mNoUrut, "", "", "Pindah dana Sudah disetujui oleh Adh tgl " & Now() & " buka akses HmsWeb", 0)
                End If
            Else
                mTextSql = "DELETE from TRXN_SPKAS where SETUJU_NOMOR ='" & mNoUrut & "' and SETUJU_USER ='" & LblUserName.Text & "'"
                Call UpdateDatabase_Tabel(mTextSql, "")
                If mPosisi = "0" Then
                    lblTglsetuju0.Text = ""
                ElseIf mPosisi = "1" Then
                    lblTglSetuju1.Text = ""
                ElseIf mPosisi = "2" Then
                    lblTglSetuju2.Text = ""
                ElseIf mPosisi = "3" Then
                    LblTglSetuju3.Text = ""
                ElseIf mPosisi = "4" Then
                    LblTglSetuju4.Text = ""
                ElseIf mPosisi = "5" Then
                    LblTglSetuju5.Text = ""
                End If

            End If
        End If
    End Function


    Function UpdateSetujuDataUser(ByVal mpIdMohon As String, ByVal mREASON As String, ByVal mCatat As String, ByVal mPos As String, ByVal mBar As Byte, ByVal mUrut As String, ByVal mpID As String) As String
        Call Msg_err("", "")
        Dim mNomor_urut As String = mUrut
        Dim mDisetujuiOleh As Byte = 1
        UpdateSetujuDataUser = ""

        If mNomor_urut = "" Then
            mNomor_urut = GetData_Nomor()
            Dim mTextSql As String = "UPDATE TRXN_SPKAH SET NOMOR='" & mNomor_urut & "' " & _
                                     "WHERE TRXN_SPKAH.NOMOR_MOHON = '" & mpID & "' AND NOMOR_SPK='" & LblNoSPK.Text & "' AND CABANG='" & lblDealer.Text & "' AND (NOMOR='' OR NOMOR IS NULL)"
            Call UpdateDatabase_Tabel(mTextSql, "")

        End If
        If mPos = "0" Then
            mDisetujuiOleh = GetDataD_00NoFound01Found("SELECT * FROM TRXN_SPKAH WHERE NOMOR='" & mNomor_urut & "' AND SPV='" & LblUserId.Text & "'", "")
            If mDisetujuiOleh <> 1 Then
                UpdateSetujuDataUser = "ERR:BUKAN SPV"
                Exit Function
            End If
        End If


        If mNomor_urut <> "" Then
            mCatat = LblUserName.Text & "/" & mCatat
            If UpdateDatabase_Tabel("INSERT INTO TRXN_SPKAS " & _
                                "(SETUJU_NOMOR,SETUJU_POS,SETUJU_ENTRY,SETUJU_USER,SETUJU_STATUS,SETUJU_CATATAN) VALUES ('" & _
                                mNomor_urut & "','" & mPos & "',GETDATE(),'" & LblUserName.Text & "','" & _
                                IIf(mREASON = "TOLAK", "0", "1") & "','" & mCatat & "')", "") = 1 Then
                UpdateSetujuDataUser = Now() & "/" & LblUserName.Text & "/" & mREASON
                If mBar = 1 Then
                    Lbl01Nomor.Text = mNomor_urut
                ElseIf mBar = 2 Then
                    Lbl02Nomor.Text = mNomor_urut
                ElseIf mBar = 3 Then
                    Lbl03Nomor.Text = mNomor_urut
                ElseIf mBar = 4 Then
                    Lbl04Nomor.Text = mNomor_urut
                ElseIf mBar = 5 Then
                    Lbl05Nomor.Text = mNomor_urut
                ElseIf mBar = 6 Then
                    Lbl06Nomor.Text = mNomor_urut
                ElseIf mBar = 7 Then
                    Lbl07Nomor.Text = mNomor_urut
                ElseIf mBar = 8 Then
                    Lbl08Nomor.Text = mNomor_urut
                ElseIf mBar = 9 Then
                    Lbl09Nomor.Text = mNomor_urut
                ElseIf mBar = 10 Then
                    Lbl10Nomor.Text = mNomor_urut
                Else
                    lblNomorSetuju.Text = mNomor_urut
                End If
            End If
        End If
    End Function

    Sub TandaResult(ByVal mBar As Byte, ByVal mIsi As String)
        If mBar = 1 Then
            ChkBox1.Text = mIsi
        ElseIf mBar = 2 Then
            ChkBox2.Text = mIsi
        ElseIf mBar = 3 Then
            ChkBox3.Text = mIsi
        ElseIf mBar = 4 Then
            ChkBox4.Text = mIsi
        ElseIf mBar = 5 Then
            ChkBox5.Text = mIsi
        ElseIf mBar = 6 Then
            ChkBox6.Text = mIsi
        ElseIf mBar = 7 Then
            ChkBox7.Text = mIsi
        ElseIf mBar = 8 Then
            ChkBox8.Text = mIsi
        ElseIf mBar = 9 Then
            ChkBox9.Text = mIsi
        ElseIf mBar = 10 Then
            ChkBox10.Text = mIsi
        End If
    End Sub

    Function Update_Tabel_SPKAH_Keputusan_Terakhir(ByVal mIdnom As String, ByVal mKetENtry As String, ByVal Reason As String, ByVal mCatat As String, ByVal mPos As String, ByVal mNo As String) As Byte
        Call Msg_err("", "")
        Dim mIsis As String
        Dim mUpdateChange As String = ""

        mIsis = Replace(mKetENtry, "ENTRY", Reason)
        If Reason = "SETUJU" Then
            Dim mSetujuGantiRevisiLama, mSetujuGantiRevisiBaru As String
            mSetujuGantiRevisiLama = mKetENtry
            mSetujuGantiRevisiBaru = mKetENtry
            mSetujuGantiRevisiLama = Replace(mSetujuGantiRevisiLama, "ENTRY", "SETUJU")
            mSetujuGantiRevisiBaru = Replace(mSetujuGantiRevisiBaru, "ENTRY", "STJ-DIGANTI")
            Call UpdateDatabase_Tabel("UPDATE TRXN_SPKAH SET JUDUL='" & mSetujuGantiRevisiBaru & "' " & _
                                  "WHERE JUDUL='" & mSetujuGantiRevisiLama & "' AND NOMOR_MOHON='" & mIdnom & "' AND NOT(NOMOR='" & mNo & "')", "")
        End If

        Update_Tabel_SPKAH_Keputusan_Terakhir = _
        UpdateDatabase_Tabel("UPDATE TRXN_SPKAH SET " & _
                         "TANGGAL_SETUJU=GETDATE()," & _
                         "APPROVALCODEP='" & lblPosSetuju.Text & mPos & "'," & _
                         "JUDUL='" & mIsis & "'," & _
                         IIf(InStr(mIdnom, "WB/APR/SD") <> 0, "CHANGE1='" & TxtDisetujuiHrgDisc.Text & "',", "") & _
                         IIf(InStr(mIdnom, "WB/APR/SD") <> 0, "CHANGE2='" & TxtDisetujuiHrgSubs.Text & "',", "") & _
                         IIf(InStr(mIdnom, "WB/APR/SD") <> 0, "CHANGE3='" & TxtDisetujuiHrgKoms.Text & "',", "") & _
                         IIf(InStr(mIdnom, "WB/APR/SD") <> 0, "CHANGE4='" & TxtDisetujuiTahun.Text & "',", "") & _
                         "CATATAN='" & TxtPetik(mCatat) & "' " & _
                         "WHERE NOMOR_MOHON='" & mIdnom & "' AND JUDUL='" & mKetENtry & "' AND NOMOR='" & mNo & "'", "")

    End Function










    Function UpdateDataMohonAksesoris(ByVal mIdNo As String, ByVal mEntry As String, ByVal mAlasan As String, ByVal mSetujuTolak As String, ByVal mCatatan As String, ByVal mPosisi As String, ByVal mMode As Byte) As Byte
        Call Msg_err("", "")
        UpdateDataMohonAksesoris = 0

        Dim mPosTerakhir As String
        Dim mTxtSql As String
        mPosTerakhir = ""
        If MultiView5S.ActiveViewIndex = 0 Then
            mPosTerakhir = "5"
        ElseIf MultiView4S.ActiveViewIndex = 0 Then
            mPosTerakhir = "4"
        ElseIf MultiView3S.ActiveViewIndex = 0 Then
            mPosTerakhir = "3"
        ElseIf MultiView2S.ActiveViewIndex = 0 Then
            mPosTerakhir = "2"
        ElseIf MultiView1S.ActiveViewIndex = 0 Then
            mPosTerakhir = "1"
        ElseIf MultiView0S.ActiveViewIndex = 0 Then
            mPosTerakhir = "0"
        End If

        Dim mReason As String = IIf(mSetujuTolak = "TOLAK", "T", "S")


        mTxtSql = ""    '0 : setuju aksesoris tdk dengan DO     1 : setuju aksesoris dengan DO
        If mPosisi = "0" And mMode = 0 Then       '  SPV
            Dim mReasonProsesSPV As String = IIf(mReason = "T", ",OPT_STATUSPROSES='TOLAK-SPV'", "")
            mTxtSql = "UPDATE TRXN_OPTPO SET OPT_TGLAPPV1=GETDATE(),OPT_CATATAN1='" & TxtPetik(mCatatan) & "',OPT_STATUSAPPV1='" & mReason & "',OPT_APPROVALCODEP='0'" & mReasonProsesSPV & " " & _
                      "WHERE OPT_STATUSPROSES='ENTRY' AND OPT_USERAPPV1='" & LblUserName.Text & "' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV1 IS NULL AND OPT_TGLAPPV2 IS NULL"
        ElseIf mPosisi = "1" And mMode = 0 Then  '  SM
            Dim mReasonProsesSM As String = IIf(mReason = "T", ",OPT_STATUSPROSES='TOLAK-SM'", ",OPT_STATUSPROSES='SETUJU-A'")
            mTxtSql = "UPDATE TRXN_OPTPO SET OPT_TGLAPPV2=GETDATE(),OPT_CATATAN2='" & TxtPetik(mCatatan) & "',OPT_STATUSAPPV2='" & mReason & "',OPT_APPROVALCODEP='01'" & mReasonProsesSM & " " & _
                      "WHERE OPT_STATUSPROSES='ENTRY' AND OPT_USERAPPV2='" & LblUserName.Text & "' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV2 IS NULL "

        ElseIf mPosisi = "0" And mMode = 1 Then  '  SPV
            Dim mReasonProsesSPVDO As String = IIf(mReason = "T", ",OPT_STATUSPROSES='TOLAK-SPV'", "")
            mTxtSql = "UPDATE TRXN_OPTPO SET OPT_TGLAPPV1=GETDATE(),OPT_CATATAN1='" & TxtPetik(mCatatan) & "',OPT_STATUSAPPV1='" & mReason & "',OPT_APPROVALCODEP='0' " & mReasonProsesSPVDO & " " & _
                      "WHERE OPT_STATUSPROSES='ENTRY' AND OPT_USERAPPV1='" & LblUserName.Text & "' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV1 IS NULL AND OPT_TGLAPPV2 IS NULL"
        ElseIf mPosisi = "1" And mMode = 1 Then  '  SM
            Dim mReasonProsesSMDO As String = IIf(mReason = "T", ",OPT_STATUSPROSES='TOLAK-SM", ",OPT_STATUSPROSES='SETUJU-D'")
            mTxtSql = "UPDATE TRXN_OPTPO SET OPT_TGLAPPV2=GETDATE(),OPT_CATATAN2='" & TxtPetik(mCatatan) & "',OPT_STATUSAPPV2='" & mReason & "',OPT_APPROVALCODEP='01'" & mReasonProsesSMDO & " " & _
                      "WHERE OPT_STATUSPROSES='ENTRY' AND OPT_USERAPPV2='" & LblUserName.Text & "' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV2 IS NULL "
        End If

        If mTxtSql <> "" Then
            If UpdateDatabase_Tabel(mTxtSql, "") = 1 Then
                If mPosisi = "0" And lblTglsetuju0.Text = "" Then
                    lblTglsetuju0.Text = Now() & "/" & LblUserName.Text & "/" & mReason
                ElseIf mPosisi = "1" And lblTglSetuju1.Text = "" Then
                    lblTglSetuju1.Text = Now() & "/" & LblUserName.Text & "/" & mReason
                ElseIf mPosisi = "2" And lblTglSetuju2.Text = "" Then
                    lblTglSetuju2.Text = Now() & "/" & LblUserName.Text & "/" & mReason
                ElseIf mPosisi = "3" And LblTglSetuju3.Text = "" Then
                    LblTglSetuju3.Text = Now() & "/" & LblUserName.Text & "/" & mReason
                ElseIf mPosisi = "4" And LblTglSetuju4.Text = "" Then
                    LblTglSetuju4.Text = Now() & "/" & LblUserName.Text & "/" & mReason
                ElseIf mPosisi = "5" And LblTglSetuju5.Text = "" Then
                    LblTglSetuju5.Text = Now() & "/" & LblUserName.Text & "/" & mReason
                End If
            End If
        End If
        'M=grouping yg hendah disetujui oleh SPV SETUJU IS NULL

    End Function






    Function Update_Tabel_SPKH_HARGA(ByVal mIdnom As String, ByVal mKetENtry As String, ByVal Reason As String, ByVal mCatat As String, ByVal mPos As String) As Byte
        Call Msg_err("", "")
        If Reason = "" Then
            If UpdateDatabase_Tabel("UPDATE TRXN_SPKAH SET APPROVALCODEP='" & lblPosSetuju.Text & mPos & "' WHERE NOMOR='" & mIdnom & "'", "") = 1 Then
                'LblOlehSetuju0.Text = LblOlehSetuju0.Text & mPos
            End If
        Else
            Dim mIsis As String
            mIsis = Replace(mKetENtry, "ENTRY", Reason)
            Update_Tabel_SPKH_HARGA = UpdateDatabase_Tabel("UPDATE TRXN_SPKAH SET " & _
                                      "TANGGAL_SETUJU=GETDATE()," & _
                                      "APPROVALCODEP='" & lblPosSetuju.Text & mPos & "'," & _
                                      "JUDUL='" & mIsis & "'," & _
                                      IIf(InStr("123", mPos) <> 0, "CHANGE1='" & TxtDisetujuiHrgDisc.Text & "',", "") & _
                                      IIf(InStr("123", mPos) <> 0, "CHANGE2='" & TxtDisetujuiHrgSubs.Text & "',", "") & _
                                      IIf(InStr("123", mPos) <> 0, "CHANGE3='" & TxtDisetujuiHrgKoms.Text & "',", "") & _
                                      IIf(InStr("123", mPos) <> 0, "CHANGE4='" & TxtDisetujuiTahun.Text & "',", "") & _
                                      "CATATAN='" & TxtPetik(mCatat) & "' " & _
                                      "WHERE NOMOR_MOHON='" & mIdnom & "' AND JUDUL='" & mKetENtry & "'", "")
        End If
    End Function

    Function UpdateDataMohon_BodyrepairWareHouse(ByVal mReason As String, ByVal mGol As Byte) As Byte
        Dim mIsi As String
        Dim mPos As String
        Dim mlbrerro As String
        Call Msg_err("", "")
        mIsi = ""
        mPos = ""
        UpdateDataMohon_BodyrepairWareHouse = 0
        mlbrerro = ""


        If mlbrerro = "" Then
            Call UpdateDatabase_Tabel("DELETE TRXN_SPKAH WHERE NOMOR_MOHON LIKE 'EM/APR/WB/TTK%'", "")
            If mReason = "TOLAK" Then
                Call UpdateDatabase_Tabel("UPDATE TRXN_STOCKAREPAIR SET " & _
                                      "ASSREPAIR_TGLSETUJU=NULL," & _
                                      "ASSREPAIR_NOSETUJU='" & mReason & "'," & _
                                      "ASSREPAIR_KETERANGAN='" & Left("TOLAK:" & TxtWHCatatan.Text, 30) & "'," & _
                                      "ASSREPAIR_TGLWO=GETDATE()," & _
                                      "ASSREPAIR_TGLEMAILSTJ=GETDATE() " & _
                                      "WHERE ASSREPAIR_NORANGKA='" & LblWHNoRangka.Text & "' AND ASSREPAIR_TGLEMAIL IS NOT NULL AND " & _
                                      "(ASSREPAIR_NOSETUJU='' OR ASSREPAIR_NOSETUJU IS NULL) AND ASSREPAIR_RINCIAN='" & Trim(LblWHDetailKerjaan.Text) & "'", "")
            Else
                Call UpdateDatabase_Tabel("UPDATE TRXN_STOCKAREPAIR SET " & _
                                      "ASSREPAIR_TGLSETUJU=GETDATE()," & _
                                      "ASSREPAIR_NOSETUJU='" & mReason & "'," & _
                                      "ASSREPAIR_KETERANGAN='" & Left("" & TxtWHCatatan.Text, 30) & "' " & _
                                      "WHERE ASSREPAIR_NORANGKA='" & LblWHNoRangka.Text & "' AND ASSREPAIR_TGLEMAIL IS NOT NULL AND " & _
                                      "(ASSREPAIR_NOSETUJU='' OR ASSREPAIR_NOSETUJU IS NULL) AND ASSREPAIR_RINCIAN='" & Trim(LblWHDetailKerjaan.Text) & "'", "")

            End If
        Else
            mlbrerro = mlbrerro & Chr(13) & ("Status Persetujuan belum berubah")
        End If
        If mlbrerro <> "" Then
            Call Msg_err(mlbrerro, "")
        Else
            Call Msg_err("Permohoanan perbaikan/Repair unit berhasil " & mReason, "")
            LVRepairWH.DataBind()
            MultiView1a.ActiveViewIndex = 0
            MultiView11a.ActiveViewIndex = 2
            MultiViewWH.ActiveViewIndex = -1

        End If
    End Function



    Sub Msg_err(ByVal mTest As String, ByVal mShow As String)
        LblBlockPesanC.Text = ""
        lblMsgBox.Text = mTest
        lblerrorTombolSPK.Text = mTest
        If mTest = "" Then
            MultiViewError.ActiveViewIndex = 0
        Else
            MultiViewError.ActiveViewIndex = 0
        End If
        If mShow <> "" Then
            LblBlockPesanC.Text = mTest
        End If
        If mTest <> "" Then
            Response.Write("<script>alert('" & mTest & "')</script>")
        End If
    End Sub

    Protected Sub Button3_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call UpdateDataMohon_BodyrepairWareHouse("SETUJU", 0)

    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call UpdateDataMohon_BodyrepairWareHouse("TOLAK", 0)
    End Sub

    Protected Sub Button5_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        LVRepairWH.DataBind()
        MultiView1a.ActiveViewIndex = 0
        MultiView11a.ActiveViewIndex = 2
        MultiViewWH.ActiveViewIndex = -1
        Call Msg_err("", "")
    End Sub

    Sub GETType_MakDiscount()
        LblMaxDisc.Text = "0"
        LblNoteDiskon.Text = ""
        If LblCdType.Text <> "" And lblTahun.Text <> "" And LblTglCreateSPK.Text <> "" Then

            Dim mCriteria As String = ""
            Dim mTahun As String = ""
            Dim mTglDay As String = ""
            Dim mTglMth As String = ""
            Dim mTglyear As String = ""
            Dim mTanggal As Date
            Dim mTambahTahun As Byte = 0
            mTglDay = Mid(LblTglCreateSPK.Text, 9, 2)
            mTglMth = Mid(LblTglCreateSPK.Text, 6, 2)
            mTglyear = Mid(LblTglCreateSPK.Text, 1, 4)
            mTanggal = New Date(Val(mTglyear), Val(mTglMth), Val(mTglDay))

            Dim mRk1 As String = ""
            Dim mRk2 As String = ""
            Dim mRk3 As String = ""
            Dim mRk4 As String = ""
            Dim mRk5 As String = ""
            Dim mRk6 As String = ""
            Dim mRk7 As String = ""
            Dim mRk8 As String = ""
            Dim mRk9 As String = ""
            Dim mRk0 As String = ""
            Dim mRangka As String = ""

            If Len(lblNorangka.Text) >= 1 Then
                mRk1 = Mid(lblNorangka.Text, 1, 1) ' Benua   M:Asia
            End If
            If Len(lblNorangka.Text) >= 2 Then
                mRk2 = Mid(lblNorangka.Text, 2, 1) ' Negara  H:Indonesia
            End If
            If Len(lblNorangka.Text) >= 3 Then
                mRk3 = Mid(lblNorangka.Text, 3, 1) ' Dealer  R:Honda Prospect
            End If
            If Len(lblNorangka.Text) >= 4 Then
                mRk4 = Mid(lblNorangka.Text, 4, 3) ' Type
            End If
            If Len(lblNorangka.Text) >= 7 Then
                mRk5 = Mid(lblNorangka.Text, 7, 1) ' Transmisi 1,3(Ganjil) MT 1,3(Genap) AT
            End If
            If Len(lblNorangka.Text) >= 8 Then
                mRk6 = Mid(lblNorangka.Text, 8, 1) ' Kode Mesin
            End If
            If Len(lblNorangka.Text) >= 9 Then
                mRk7 = Mid(lblNorangka.Text, 9, 1) ' Kode tetap 0
            End If
            If Len(lblNorangka.Text) >= 10 Then
                mRk8 = Mid(lblNorangka.Text, 10, 1) ' Tahun Model 2000/Y ..../1 /2  2010/A..../1/2
            End If
            If Len(lblNorangka.Text) >= 11 Then
                mRk9 = Mid(lblNorangka.Text, 11, 1) ' Kode Pabrik J:Jakarta K:Karawang
            End If
            If Len(lblNorangka.Text) >= 12 Then
                mRk0 = Mid(lblNorangka.Text, 12, 6) ' Nomor Pembuatan
            End If


            mCriteria = "" : mTahun = ""
            If Len(lblNorangka.Text) >= 11 Then
                mRangka = Mid(lblNorangka.Text, 4, 8)
            Else
                mRangka = ""
            End If

            If mRangka <> "" Then
                mCriteria = " AND TYPED_RANGKA LIKE '%" & Mid(mRangka, 4, 8) & "%'"
            Else
                mCriteria = GetDataA_Rangka_TYPE("SELECT * FROM DATA_TYPE WHERE TYPE_Type='" & LblCdType.Text & "'")
                If mCriteria <> "" Then
                    If IsNumeric(lblTahun.Text) Then
                        mTambahTahun = 0
                        If Val(lblTahun.Text) >= 10 And Val(lblTahun.Text) <= 26 Then
                            If Val(lblTahun.Text) >= 18 Then
                                mTambahTahun = 1
                            End If
                            mTahun = Mid("ABCDEFGHIJKLMNOPQRSTUVWXYZ", (Val(lblTahun.Text) + mTambahTahun) - 9, 1)
                        End If
                    End If
                    If mTahun <> "" Then
                        mCriteria = mCriteria & Mid("_______", 1, 6 - Len(mCriteria)) & mTahun
                        mCriteria = " AND TYPED_RANGKA LIKE '%" & mCriteria & "%'"
                    End If
                End If
            End If
            If mCriteria <> "" Then
                LblMaxDisc.Text = GetDataA_MaxDisc_TYPE("SELECT * FROM DATA_TYPED,DATA_TYPE WHERE  TYPED_TYPE=TYPE_TYPE AND TYPED_TYPE = '" & LblCdType.Text & "' AND DATEDIFF(DAY,TYPED_TANGGAL," & "'" & Format(CDate(mTanggal), "yyyy-MM-dd hh:mm:ss") & "'" & ") >= 0 " & mCriteria & " ORDER BY TYPED_TANGGAL DESC")
            End If
            If (Val(LblDisc.Text) + Val(LblKomisi.Text) - Val(LblSubsidi.Text)) > Val(LblMaxDisc.Text) Then
                LblNoteDiskon.Text = "Melebihi Ketentuan Diskon Maksimal"
            End If
        End If
    End Sub




    Function Periksa_SPK_Gantung() As Byte
        Periksa_SPK_Gantung = 1
        Periksa_SPK_Gantung = GetDataD_00NoFound01Found("SELECT * FROM TRXN_SPKG WHERE " & _
                                                  "DATEDIFF(DAY,SPK_WarningTgl,GETDATE()) >= 7 AND " & _
                                                  "NOT(SPK_WarningStatus='0' OR SPK_WarningStatus='' OR SPK_WarningStatus IS NULL)", "")
    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call UpdateDatabase_Tabel("UPDATE TRXN_SPKAH SET APPROVALCODEP='0' WHERE JUDUL like 'ENTRY%' AND CABANG='" & lblArea1.Text & "' AND APPROVALCODEP='' AND (SPV='SC' OR SPV='FZ' OR SPV='UG')", "")
        lvPersetujuan.DataBind()
        MultiView11a.ActiveViewIndex = 0
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call UpdateDatabase_Tabel("UPDATE TRXN_OPTPO SET OPT_TGLAPPV1=GETDATE(),OPT_CATATAN1='SC',OPT_STATUSAPPV1='S',OPT_APPROVALCODEP='0' WHERE OPT_STATUSPROSES like 'ENTRY%' AND OPT_NODEALER='" & lblArea1.Text & "' AND (OPT_SPV='SC' OR OPT_SPV='FZ' OR OPT_SPV='UG') AND OPT_TGLAPPV1 IS NULL", "")
        LVPersetujuanAsesoris.DataBind()
        MultiView11a.ActiveViewIndex = 1
    End Sub
    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        If Mid(lblAkses.Text, 7, 1) = "1" Then
            LVRepairWH.DataBind()
            MultiView11a.ActiveViewIndex = 2
        Else
            Call Msg_err("Tidak diijinkan", "")
        End If
    End Sub

    Sub Send_Mailb(ByVal mSubject As String, ByVal mBody As String, ByVal strTo As String)
        Dim strFrom = "hmugen1991@gmail.com"
        Dim MailMsg As New MailMessage(New MailAddress(strFrom.Trim()), New MailAddress(strTo))

        Try
            MailMsg.BodyEncoding = Encoding.Default
            MailMsg.Subject = mSubject        '"This is a test"
            MailMsg.Body = mBody              '"This is a sample message using SMTP authentication"
            MailMsg.Priority = MailPriority.High
            MailMsg.IsBodyHtml = True


            Dim SmtpMail As New SmtpClient

            'SmtpMail.Host = "202.148.1.10"
            'SmtpMail.Host = "corporate-e.dnet.net"

            SmtpMail.Host = "mail.hondamugen.co.id"
            SmtpMail.UseDefaultCredentials = False
            SmtpMail.Port = 465
            SmtpMail.EnableSsl = True

            Dim basicAuthenticationInfo As New System.Net.NetworkCredential("websystem@hondamugen.co.id", "websystem112")
            SmtpMail.Credentials = basicAuthenticationInfo

            SmtpMail.Send(MailMsg)
        Catch ex As Exception
            Call Msg_err("Email to " & strTo & "error " & ex.Message, "")
        End Try

    End Sub

    Sub Send_MailError(ByVal mSubject As String, ByVal mBody As String, ByVal strTo As String)
        Dim strFrom = "websystem@hondamugen.co.id"
        Try

            Using mm As New MailMessage(strFrom, strTo)
                mm.Subject = mSubject
                mm.Body = mBody
                mm.IsBodyHtml = False
                Dim smtp As New SmtpClient()
                smtp.Host = "mail.hondamugen.co.id"
                smtp.Port = 465
                smtp.EnableSsl = True
                smtp.UseDefaultCredentials = True

                Dim NetworkCred As New System.Net.NetworkCredential("websystem@hondamugen.co.id", "websystem112")
                smtp.Credentials = NetworkCred

                smtp.Send(mm)
                'ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('Email sent.');", True)
            End Using
        Catch ex As Exception
            Call Msg_err("Email to " & strTo & "error " & ex.Message, "")
        End Try
    End Sub

    Sub Send_Mail(ByVal mSubject As String, ByVal mBody As String, ByVal strTo As String)
        Dim strFrom = "hmugen1991@gmail.com"
        Try

            Using mm As New MailMessage(strFrom, strTo)
                mm.Subject = mSubject
                mm.Body = mBody
                mm.IsBodyHtml = False
                Dim smtp As New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.UseDefaultCredentials = True
                smtp.Port = 587
                smtp.EnableSsl = True

                Dim NetworkCred As New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p")
                smtp.Credentials = NetworkCred

                smtp.Send(mm)
                mm.Dispose()
                'ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('Email sent.');", True)
            End Using
        Catch ex As Exception
            Call Msg_err("Email to " & strTo & " Err " & ex.Message, "")
        End Try
    End Sub


    Function nLg(ByRef nilai As Object) As Double
        On Error GoTo ErrHand
        nLg = 0
        nilai = Replace(nilai, ",", "")
        If IsNumeric(nilai) Then nLg = Val(nilai)
ErrHand:
    End Function

    Function fLg(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        fLg = "0"
        nilai = Replace(nilai, ",", "")
        If IsNumeric(nilai) Then fLg = Format(Val(nilai), "###,###,###,###,##0") '10
ErrHand:
    End Function



    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click

        Call Minta_data_Baru(Lbl01Mhn.Text)
        Call Minta_data_Baru(Lbl02Mhn.Text)
        Call Minta_data_Baru(Lbl03Mhn.Text)
        Call Minta_data_Baru(Lbl04Mhn.Text)
        Call Minta_data_Baru(Lbl05Mhn.Text)
        Call Minta_data_Baru(Lbl06Mhn.Text)
        Call Minta_data_Baru(Lbl07Mhn.Text)
        Call Minta_data_Baru(Lbl08Mhn.Text)
        Call Minta_data_Baru(Lbl09Mhn.Text)
        Call Minta_data_Baru(Lbl10Mhn.Text)
        If lblPolcyNomorMohon.Text <> "" Then
            Call Minta_data_Baru(lblPolcyNomorMohon.Text)
        End If
    End Sub
    Sub Minta_data_Baru(ByVal nNomor As String)
        Dim mChangeHarga As String = ""
        If nNomor <> "" Then
            If InStr(nNomor, "WB/APR/DO") <> 0 And _
               TxtDisetujuiNoRangka.Text <> lblDisetujuiNoRangkaTmp.Text And _
               TxtDisetujuiNoRangka.Text <> "" Then
                mChangeHarga = ",CHANGE='" & TxtDisetujuiNoRangka.Text & "' "
            End If

            Call UpdateDatabase_Tabel("UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='ENTRY-D'  WHERE OPT_NOMORMOHON = '" & nNomor & "' AND OPT_STATUSPROSES='ENTRY'", "")
            Call UpdateDatabase_Tabel("UPDATE TRXN_SPKAH SET TANGGAL_PROSES=NULL " & mChangeHarga & "  WHERE NOMOR_MOHON = '" & nNomor & "'", "")
            Call UpdateDatabase_Tabel("DELETE FROM  TRXN_SPKAD WHERE NOMOR_MOHON= '" & nNomor & "'", "")
            Call UpdateDatabase_Tabel("DELETE FROM  TRXN_SPKAHERR  WHERE SPKAHERR_NOM= '" & nNomor & "'", "")

            LblStatusUpdateSPK.Text = "Tunggu Maksimal 1.5 menit untuk server Mugen mengambil data SPK"
        End If
    End Sub

    Public Class WaMessageSender
        Private Const CLIENT_ID As String = "FREE_TRIAL_ACCOUNT"
        Private Const CLIENT_SECRET As String = "PUBLIC_SECRET"
        Private Const API_URL As String = "http://api.whatsmate.net/v1/whatsapp/queue/message"
        Public Function SendMessage(ByVal number As String, ByVal message As String) As Boolean
            Dim success As Boolean = True
            Dim webClient As New WebClient()
            Try
                Dim payloadObj As New Payload(number, message)
                Dim serializer As New JavaScriptSerializer()
                Dim postData As String = serializer.Serialize(payloadObj)

                webClient.Headers("content-type") = "application/json"
                webClient.Headers("X-WM-CLIENT-ID") = CLIENT_ID
                webClient.Headers("X-WM-CLIENT-SECRET") = CLIENT_SECRET

                Dim response As String = webClient.UploadString(API_URL, postData)
                Console.WriteLine(response)

            Catch webEx As WebException
                Dim res As HttpWebResponse = DirectCast(webEx.Response, HttpWebResponse)
                Dim stream As Stream = res.GetResponseStream()
                Dim reader As New StreamReader(stream)
                Dim body As String = reader.ReadToEnd()

                Console.WriteLine(res.StatusCode)
                Console.WriteLine(body)
                success = False

            End Try
            Return success
        End Function

    End Class


    Private Class Payload
        Public number As String
        Public message As String
        Sub New(ByVal NUM As String, ByVal MSG As String)
            number = NUM
            message = MSG
        End Sub
    End Class

    Sub PANGGILWA()
        Dim waSender As New WaMessageSender()
        waSender.SendMessage("08", "hey")
        Console.WriteLine("Press Enter to Exit")
        Console.ReadLine()
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


    'Get Data



    Function SendEmailProces(ByRef mEmailTo As Object, ByRef mJudul As Object, ByRef mFile As Object, ByRef mPath As Object, ByRef mSsage As Object, ByRef mTampilHTM As Byte) As Byte
        Dim strFrom As String = "hmugen1991@gmail.com"
        Try

            Using mm As New MailMessage(strFrom, mEmailTo)
                mm.Subject = mJudul

                'If mTampilHTM = 0 Then
                'mm.Body = mSsage
                'mm.IsBodyHtml = False
                'Else
                'mm.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda memiliki sebuah permintaan persetujuan " + mSsage + " <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8084/Login.aspx?ReturnUrl=%2fdefault.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk melakukan persetujuan</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>"

                mm.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div>" & _
                          "<div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>" & _
                          "<div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda memiliki sebuah permintaan persetujuan " + mSsage + " <br/>" & _
                          "<span style='color:blue;font-size:8pt;'></span>" & _
                          "</div>" & _
                          "<br/><center><a href='http://office.hondamugen.co.id:8084/Login.aspx?ReturnUrl=%2fdefault.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk melakukan persetujuan</a></center>" & _
                          "<br/><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center>" & _
                          "<br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center>" & _
                          "<br/><br/>" & _
                          "<br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong>" & _
                          "<br/><strong>Honda Mugen Group</strong>" & _
                          "<br/><i>PT. Mitrausaha Gentaniaga</i>" & _
                          "<br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" & _
                          "<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span>" & _
                          "<br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" & _
                          "<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a>" & _
                          "<br/>" & _
                          "</div>"

                mm.IsBodyHtml = True
                'End If



                If mFile <> "" Then
                    mFile = mPath & "RResult\" & mFile
                    mm.Attachments.Add(New Attachment(mFile))
                End If

                Dim smtp As New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.UseDefaultCredentials = True
                smtp.Port = 587
                smtp.EnableSsl = True

                Dim NetworkCred As New System.Net.NetworkCredential("hmugen1991@gmail.com", "112m128p")
                'Dim NetworkCred As New System.Net.NetworkCredential("bckphmugen1991@gmail.com", "128p112m")
                smtp.Credentials = NetworkCred

                smtp.Send(mm)
                mm.Dispose()
                'ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('Email sent.');", True)
            End Using
        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Function
    Protected Sub LvUnitStok_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvUnitStok.SelectedIndexChanged
        TxtDisetujuiNoRangka.Text = (LvUnitStok.DataKeys(LvUnitStok.SelectedIndex).Value.ToString)
        lblDisetujuiNoRangkaTmp.Text = TxtDisetujuiNoRangka.Text
    End Sub


    Protected Sub ButtonSimpan1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSimpan1.Click
        If TxtDisetujuiNoRangka.Text = "" Then
            TxtDisetujuiNoRangka.Text = "%"
        End If

    End Sub
    Protected Sub LvAksesorisNonDO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvAksesorisNonDO.SelectedIndexChanged
        Call Msg_err("", "")
        Call UpdateStatusAksesoris(LvAksesorisNonDO.DataKeys(LvAksesorisNonDO.SelectedIndex).Value.ToString)
        LvAksesorisNonDO.DataBind()
    End Sub

    Protected Sub LvDataAsesorisDO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDataAsesorisDO.SelectedIndexChanged
        Call Msg_err("", "")
        Call UpdateStatusAksesoris(LvDataAsesorisDO.DataKeys(LvDataAsesorisDO.SelectedIndex).Value.ToString)
        LvDataAsesorisDO.DataBind()
    End Sub

    Sub UpdateStatusAksesoris(ByVal pKodeAksesoris As String)
        Dim mKode As String
        Dim mKeterangan As String = ""
        Dim mResult As String = ""
        mKode = (pKodeAksesoris)
        If Len(mKode) > 5 Then
            mKeterangan = Mid(mKode, 6, Len(mKode) - 5)
            mKode = Mid(mKode, 1, 4)
        End If
        If InStr(mKeterangan, "TOLAK-SPV") <> 0 And TxtPosJab.Text = "0" Then
            mResult = "ENTRY"
        ElseIf InStr(mKeterangan, "TOLAK-SM") <> 0 And TxtPosJab.Text = "1" Then
            mResult = "ENTRY"
        ElseIf InStr(mKeterangan, "ENTRY") <> 0 And TxtPosJab.Text = "0" Then
            mResult = "TOLAK-SPV"
        ElseIf InStr(mKeterangan, "ENTRY") <> 0 And TxtPosJab.Text = "1" Then
            mResult = "TOLAK-SM"
        End If
        If mResult <> "" Then
            Call UpdateDatabase_Tabel("UPDATE TRXN_OPTPO SET OPT_STATUSPROSES = '" & mResult & "' WHERE OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_CDASS='" & mKode & "'  AND (OPT_STATUSPROSES like '%" & mKeterangan & "%')", "")
        End If
        LvAksesorisNonDO.DataBind()
    End Sub



    Protected Sub lvRepairWH_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVRepairWH.SelectedIndexChanged
        Call Msg_err("", "")
        Dim NoRangka As String = (LVRepairWH.DataKeys(LVRepairWH.SelectedIndex).Value.ToString)
        Call TampilkanPermohonb(NoRangka)
    End Sub
    Protected Sub TampilkanPermohonb(ByVal mRgk As String)


        Dim mQuery As String
        Dim mDlr As String = ""

        LblWHNoMohon.Text = LblResultIdMohon.Text
        mQuery = "SELECT * FROM TRXN_STOCKAREPAIR,TRXN_STOCK,DATA_TYPE,DATA_WARNA,DATA_LOKASI,DATA_SUPLIER " & _
                 "WHERE ASSREPAIR_NORANGKA=STOCK_NORANGKA AND STOCK_Cdtype=TYPE_type AND STOCK_Cdlokasi=lokasi_Kode AND STOCK_Cdwarna=WARNA_Kode AND ASSREPAIR_KODEDLR=SUPLIER_KODE AND " & _
                 "(ASSREPAIR_TGLEMAIL IS NOT NULL AND (ASSREPAIR_NOSETUJU='' OR ASSREPAIR_NOSETUJU IS NULL))  AND ASSREPAIR_NORANGKA='" & mRgk & "'"
        Call GetDataA_Tabel_WAREHOUSE(mQuery, "")
        MultiView1a.ActiveViewIndex = 2
        MultiViewWH.ActiveViewIndex = 0

    End Sub

    Protected Sub TxtDisetujuiHrgDisc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDisetujuiHrgDisc.TextChanged
        LblPerubahanHargaDisc.Text = fLg(TxtDisetujuiHrgDisc.Text)
        Call UpdateTotalHarga()
    End Sub
    Protected Sub TxtDisetujuiHrgsubs_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDisetujuiHrgSubs.TextChanged
        LblPerubahanHargaSubs.Text = fLg(TxtDisetujuiHrgSubs.Text)
        Call UpdateTotalHarga()
    End Sub
    Protected Sub TxtDisetujuiHrgkoms_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDisetujuiHrgKoms.TextChanged
        LblPerubahanHargaKoms.Text = fLg(TxtDisetujuiHrgKoms.Text)
        Call UpdateTotalHarga()
    End Sub
    Protected Sub TxtDisetujuiTahun_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDisetujuiTahun.TextChanged
        Call UpdateTotalHarga()
    End Sub

    Sub UpdateTotalHarga()

        LblTotalSetuju.Text = (nLg(TxtDisetujuiHrgDisc.Text) - nLg(TxtDisetujuiHrgSubs.Text) + nLg(TxtDisetujuiHrgKoms.Text))
        LblTotalPerubahan.Text = (nLg(LblPerubahanHargaDisc.Text) - nLg(LblPerubahanHargaSubs.Text) + nLg(LblPerubahanHargaKoms.Text))
        LblTotalPengajuan.Text = (nLg(LblPengajuanHargaDisc.Text) - nLg(LblPengajuanHargaSubs.Text) + nLg(LblPengajuanHargaKoms.Text))
        LblPengajuanHargaDisc.Text = fLg(LblPengajuanHargaDisc.Text)
        LblPengajuanHargaSubs.Text = fLg(LblPengajuanHargaSubs.Text)
        LblPengajuanHargaKoms.Text = fLg(LblPengajuanHargaKoms.Text)
        LblTotalPengajuan.Text = fLg(LblTotalPengajuan.Text)

        LblPerubahanHargaDisc.Text = fLg(LblPerubahanHargaDisc.Text)
        LblPerubahanHargaSubs.Text = fLg(LblPerubahanHargaSubs.Text)
        LblPerubahanHargaKoms.Text = fLg(LblPerubahanHargaKoms.Text)
        LblTotalPerubahan.Text = fLg(LblTotalPerubahan.Text)

        LblPengajuanHargaDisc.Text = fLg(LblPengajuanHargaDisc.Text)
        LblPengajuanHargaSubs.Text = fLg(LblPengajuanHargaSubs.Text)
        LblPengajuanHargaKoms.Text = fLg(LblPengajuanHargaKoms.Text)
        LblTotalPengajuan.Text = fLg(LblTotalPengajuan.Text)
    End Sub
    Protected Sub Button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click
        MultiView1a.ActiveViewIndex = 0
        MultiView11a.ActiveViewIndex = 0
    End Sub

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        If Mid(lblAkses.Text, 7, 1) = "1" Then
            'Button9.Text = "Mulai Percakapan"
            'txtChatTanggal.Text = "" : txtChatTanggal.Enabled = False
            'txtChatNo1.Text = "" : txtChatNo1.Enabled = False
            'txtChatNo2.Text = "" : txtChatNo2.Enabled = False
            'txtChatUser.Text = "" : txtChatUser.Enabled = False
            'TxtChatMsg.Text = "" : TxtChatMsg.Enabled = False
            'LVChat.DataBind()
            'MultiView1a.ActiveViewIndex = 3
            'Call SendEmailProces("mis@hondamugen.co.id", "Subject ini hanya test", "", "", "COba ya yang ini", 1)

        Else
            Call SendEmailProces("soetrisnoSusanto@gmail.com", "TEST " & Now(), "", "", "Test Email Permohonan persetujuan melebihi Diskon tgl " & Now(), 0)
            Call Msg_err("Tidak diijinkan", "")
        End If
    End Sub

    Protected Sub Button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim mBodyMsg As String
        If Button9.Text = "Mulai Percakapan" Then
            Button9.Text = "Simpan"
            txtChatTanggal.Text = ""
            txtChatNo1.Text = ""
            txtChatNo2.Text = ""
            txtChatUser.Text = ""
            TxtChatMsg.Text = "" : TxtChatMsg.Enabled = True
        Else
            Button9.Text = "Mulai Percakapan"
            If txtChatNo1.Text = "" Then
                txtChatNo1.Text = GetData_NomorChat()
            End If
            If txtChatNo1.Text <> "" Then
                If UpdateDatabase_Tabel("INSERT INTO TRXN_SPKAHCHT (CHAT_DEALER,CHAT_NO,CHAT_TGL,CHAT_USER,CHAT_TEXT,CHAT_NOMOHON) VALUES ('" & _
                                         lblArea1.Text & "','" & txtChatNo1.Text & "',GETDATE(),'" & LblUserName.Text & "','" & TxtChatMsg.Text & "','" & txtChatNo2.Text & "')", "") = 1 Then
                    LVChat.DataBind()


                    mBodyMsg = txtChatNo1.Text & " " & LblUserName.Text & " Pesan : " & TxtChatMsg.Text & Chr(13) & _
                               "Untuk membalas percakapan ini Klik hmsweb.hondamugen.co.id"
                    'http://hmsweb.hondamugen.co.id/Form0101ApprovalSPK.aspx
                    'http://hmsweb.hondamugen.co.id/Login.aspx?ReturnUrl=%2fForm0101ApprovalSPK.aspx
                    mBodyMsg = mBodyMsg & Chr(13) & _
                               "Pesan Chat Sebelumnya : " & Chr(13) & _
                               GetData_ChatMessage("SELECT * FROM TRXN_SPKAHCHT WHERE CHAT_NO='" & txtChatNo1.Text & "' AND CHAT_TEXT<>'" & TxtChatMsg.Text & "' ORDER BY CHAT_TGL DESC")

                    If UCase(LblUserName.Text) <> "SANTO" Then
                        Call SendEmailProces("soetrisnoSusanto@gmail.com", "Percakapan NOMOR CHAT " & txtChatNo1.Text, "", "", mBodyMsg, 0)
                    Else
                        If lblArea1.Text = "112" Then
                            Call SendEmailProces("Faiz@hondamugen.co.id", "Percakapan NOMOR CHAT " & txtChatNo1.Text, "", "", mBodyMsg, 0)
                        Else
                            Call SendEmailProces("Ugam@hondamugen.co.id", "Percakapan NOMOR CHAT " & txtChatNo1.Text, "", "", mBodyMsg, 0)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Protected Sub Button10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.Click
        Button9.Text = "Mulai Percakapan"
        txtChatNo1.Enabled = True
        txtChatNo2.Enabled = True
        txtChatUser.Enabled = True
        TxtChatMsg.Enabled = True
    End Sub

    Protected Sub lvChat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVChat.SelectedIndexChanged
        Call Msg_err("", "")
        txtChatNo1.Text = (LVChat.DataKeys(LVChat.SelectedIndex).Value.ToString)
        Call GetDataA_Chat("SELECT * FROM TRXN_SPKAHCHT WHERE CHAT_NO='" & txtChatNo1.Text & "'", 0)
    End Sub

    Function nDb(ByRef nilai As Object) As Double
        nDb = 0
        If Not IsDBNull(nilai) Then nDb = Val(nilai) '13
    End Function
    Function FieldTgl(ByRef nilai As Object) As String
        FieldTgl = DtInSQL(nilai)
    End Function
    Function DtInSQL(ByRef nilai As Object) As String
        DtInSQL = "NULL"

        If Not IsDBNull(nilai) Then
            DtInSQL = "'" & Format(nilai, "yyyy-MM-dd HH:mm:ss") & "'"
        End If
    End Function


    Function GetData_UserSecurity(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetData_UserSecurity = 0

        cnn = New OleDbConnection(strconn)
        'TxtCariSPV.Text = ""
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_UserSecurity = IIf(MyRecReadA.HasRows = True, 1, 0)
            TxtPosJab.Text = ""
            While MyRecReadA.Read()
                LblUserId.Text = nSr(MyRecReadA("USER_ID"))

                TxtCariSPV.Text = LblUserId.Text

                lblAkses.Text = nSr(MyRecReadA("AKSES_DATA"))
                lblArea1.Text = nSr(MyRecReadA("AKSES_AREA"))
                lblArea2.Text = lblArea1.Text
                If Len(lblArea1.Text) > 3 Then
                    lblArea1.Text = Mid(nSr(MyRecReadA("AKSES_AREA")), 1, 3)
                    lblArea2.Text = Mid(nSr(MyRecReadA("AKSES_AREA")), 4, 3)
                End If
                If lblAkses.Text <> "" Then
                    lblAkses.Visible = False
                    If Mid(lblAkses.Text, 2, 1) = "1" Then
                        TxtPosJab.Text = "0"
                        TxtPosApv.Text = ""
                        TxtCariSPV.Enabled = False
                    ElseIf Mid(lblAkses.Text, 3, 1) = "1" Then
                        TxtPosJab.Text = "1"
                        TxtPosApv.Text = "0"
                    ElseIf Mid(lblAkses.Text, 4, 1) = "1" Then
                        TxtPosJab.Text = "2"
                        TxtPosApv.Text = "1"
                    ElseIf Mid(lblAkses.Text, 5, 1) = "1" Then
                        TxtPosJab.Text = "3"
                        TxtPosApv.Text = "2"
                    ElseIf Mid(lblAkses.Text, 9, 1) = "1" Then
                        TxtPosJab.Text = "4"
                        TxtPosApv.Text = "1"
                    ElseIf Mid(lblAkses.Text, 10, 1) = "1" Then
                        TxtPosJab.Text = "5"
                        TxtPosApv.Text = "1"
                    End If
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function UpdateDatabase_Tabel(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
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
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetDataD_IsiField(ByVal mSqlCommadstring As String, ByVal mpServer As String) As String
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
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
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetDataD_00NoFound01Found(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
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
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Sub GetDataA_ErrorMsg(ByVal mSqlCommadstring As String, ByVal mSqlJudul As String)
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        mSqlCommadstring = "SELECT * FROM TRXN_SPKAHERR WHERE SPKAHERR_NOM='" & mSqlCommadstring & "'"
        cnn = New OleDbConnection(strconn)
        LblNamaFaktur.Text = ""
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            While MyRecReadA.Read()
                LblBlockPesan.Text = LblBlockPesan.Text & IIf(mSqlJudul = "", "", "[" & mSqlJudul & "] ") & nSr(MyRecReadA("SPKAHERR_DESC"))
                LblBlockPesanR.Text = LblBlockPesanR.Text & IIf(mSqlJudul = "", "", "[" & mSqlJudul & "] ") & nSr(MyRecReadA("SPKAHERR_DESCR"))
                LblBlockPesanC.Text = ""
            End While
            If LblBlockPesan.Text <> "" Or LblBlockPesanR.Text <> "" Then
                LblWarning.Text = "Periksa Catatan SPK dibawah ini  !!!!  Jika ada maka Proses sebaiknya tidak dilanjutkan....... "
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Sub

    Function GetDataA_Faktur(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Faktur = 0

        cnn = New OleDbConnection(strconn)
        LblNamaFaktur.Text = ""
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Faktur = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                'LblNamaFaktur.Text = LblNamaFaktur.Text & nSr(MyRecReadA("SPKAF_NOMORMOHON")) & "  /  "
                LblNamaFaktur.Text = LblNamaFaktur.Text & nSr(MyRecReadA("SPKAF_NOMOR")) & "  /  "
                LblNamaFaktur.Text = LblNamaFaktur.Text & nSr(MyRecReadA("SPKAF_NOKTP")) & "  /  "
                LblNamaFaktur.Text = LblNamaFaktur.Text & nSr(MyRecReadA("SPKAF_DOK")) & "  /  "
                LblNamaFaktur.Text = LblNamaFaktur.Text & nSr(MyRecReadA("SPKAF_NAMA")) & "  /  "
                LblNamaFaktur.Text = LblNamaFaktur.Text & nSr(MyRecReadA("SPKAF_ALAMAT")) & "  /  "
                LblNamaFaktur.Text = LblNamaFaktur.Text & nSr(MyRecReadA("SPKAF_KOTA")) & "  /  "
                LblNamaFaktur.Text = LblNamaFaktur.Text & nSr(MyRecReadA("SPKAF_POS")) & "  /  "
                LblNamaFaktur.Text = LblNamaFaktur.Text & nSr(MyRecReadA("SPKAF_NOHP")) & "  /  "
                LblNamaFaktur.Text = LblNamaFaktur.Text & nSr(MyRecReadA("SPKAF_LAHIR")) & "  /  "
                LblNamaFaktur.Text = LblNamaFaktur.Text & nSr(MyRecReadA("SPKAF_AGAMA")) & "  /  "
                LblNamaFaktur.Text = LblNamaFaktur.Text & nSr(MyRecReadA("SPKAF_NOPOL")) & "  /  "
                LblNamaFaktur.Text = LblNamaFaktur.Text & nSr(MyRecReadA("SPKAF_NOTE")) & "  /  "
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetDataA_Tabel_SPKAH_Header(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Tabel_SPKAH_Header = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_SPKAH_Header = IIf(MyRecReadA.HasRows = True, 1, 0)
            lblDealer.Text = ""
            While MyRecReadA.Read()
                LblNoSPK.Text = nSr(MyRecReadA("NOMOR_SPK"))
                LblSalesSPV.Text = nSr(MyRecReadA("SPV"))
                lblNomorSetuju.Text = nSr(MyRecReadA("NOMOR"))
                lblPosSetuju.Text = nSr(MyRecReadA("APPROVALCODEP"))
                LblResultIdMohon.Text = nSr(MyRecReadA("NOMOR_MOHON"))
                lblDealer.Text = nSr(MyRecReadA("CABANG"))
                LblWHJenisMohon.Text = nSr(MyRecReadA("JUDUL"))

                LblResultPosSetuju.Text = nSr(MyRecReadA("APPROVALCODE"))
                LblResultPosSetujuCurrent.Text = nSr(MyRecReadA("APPROVALCODEP"))
                LblResultNomor.Text = nSr(MyRecReadA("NOMOR"))

                If nSr(MyRecReadA("TANGGAL_SETUJU")) <> "" Then
                    LblResultTglDisetujui.Text = " DISETUJUI : " & nSr(MyRecReadA("TANGGAL_SETUJU"))
                    LblResultTglAmbilData.Text = " DIPROSES :  " & nSr(MyRecReadA("TANGGAL_PROSES"))
                    LblResultKeputusan.Text = nSr(MyRecReadA("JUDUL"))
                    LblResultAlasan.Text = nSr(MyRecReadA("KETERANGAN"))
                    LblResultCatatanKeputusan.Text = nSr(MyRecReadA("CATATAN"))
                End If
                If InStr(LblWHJenisMohon.Text, "PINDAH DANA") <> 0 Then
                    LblPindahDanaSPKJuml.Text = nSr(MyRecReadA("CHANGE"))
                    LblPindahDanaSPKAsal.Text = nSr(MyRecReadA("NOMOR_SPK"))
                    LblPindahDanaSPKTuju.Text = nSr(MyRecReadA("CHANGE1"))
                    Call insertTabelPindahDana(1, "", "", "NOMOR VOUCHER  ", nSr(MyRecReadA("CHANGE2")) & "/" & nSr(MyRecReadA("CHANGE3")))
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetDataA_Tabel_SPKAH_HeaderAsesoris(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Tabel_SPKAH_HeaderAsesoris = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_SPKAH_HeaderAsesoris = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                LblNoSPK.Text = nSr(MyRecReadA("OPT_NOSPK"))
                LblSalesSPV.Text = nSr(MyRecReadA("OPT_SPV"))

                lblNomorSetuju.Text = ""
                lblPosSetuju.Text = ""
                LblResultIdMohon.Text = nSr(MyRecReadA("OPT_NOMORMOHON"))
                lblPolcyNomorMohon.Text = LblResultIdMohon.Text
                lblDealer.Text = nSr(MyRecReadA("OPT_NODEALER"))
                LblWHJenisMohon.Text = "ENTRY PERMOHONAN APPROVED AKSESORIS"
                LblResultPosSetuju.Text = nSr(MyRecReadA("OPT_APPROVALCODE"))
                LblResultPosSetujuCurrent.Text = nSr(MyRecReadA("OPT_APPROVALCODEP"))

                LblResultNomor.Text = ""

            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetDataA_Tabel_SPKAH_Detail(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim lblMohonDetailAlasan As String = ""
        Call Msg_err("", "")
        GetDataA_Tabel_SPKAH_Detail = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_SPKAH_Detail = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                If Not (InStr(nSr(MyRecReadA("NOMOR_MOHON")), "WB/APR/SD") <> 0 Or _
                        InStr(nSr(MyRecReadA("NOMOR_MOHON")), "WB/APR/AS") <> 0 Or _
                        InStr(nSr(MyRecReadA("NOMOR_MOHON")), "WB/APR/FT") <> 0 Or _
                        InStr(nSr(MyRecReadA("NOMOR_MOHON")), "WB/APR/DO") <> 0) Then
                    lblMohonDetailAlasan = nSr(MyRecReadA("KETERANGAN"))
                    If InStr(nSr(MyRecReadA("JUDUL")), "DANA ANTAR SPK") <> 0 Then
                        lblMohonDetailAlasan = lblMohonDetailAlasan & " [" & _
                                               "PINDAH TRANSAKSI KE SPK " & nSr(MyRecReadA("CHANGE1")) & _
                                               " SEBESAR " & nSr(MyRecReadA("CHANGE")) & "]"
                    End If
                    Call insert_tabel(nSr(MyRecReadA("NOMOR_MOHON")), nSr(MyRecReadA("APPROVALCODE")), nSr(MyRecReadA("APPROVALCODEP")), _
                                      nSr(MyRecReadA("JUDUL")), lblMohonDetailAlasan, _
                                      nSr(MyRecReadA("TANGGAL_ENTRY")), nSr(MyRecReadA("NOMOR")), nSr(MyRecReadA("MYUSER")), nSr(MyRecReadA("CHANGE")), nSr(MyRecReadA("CHANGE1")), nSr(MyRecReadA("CHANGE2")), nSr(MyRecReadA("CHANGE3")), nSr(MyRecReadA("CHANGE4")))
                    'If InStr(nSr(MyRecReadA("JUDUL")), "PINDAH DANA") <> 0 Then
                    'Call GetData_Tabel_SPKAD_PINDAH_DANA("SELECT * FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON='" & nSr(MyRecReadA("NOMOR_MOHON")) & "'")
                    'End If
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetDataA_Tabel_SPKAH_Detail_PolcyDsikon(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Tabel_SPKAH_Detail_PolcyDsikon = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_SPKAH_Detail_PolcyDsikon = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                lblPolcyNomorMohon.Text = nSr(MyRecReadA("NOMOR_MOHON"))
                lblPolcyJudul.Text = nSr(MyRecReadA("JUDUL"))
                lblPolcyAlasan.Text = nSr(MyRecReadA("KETERANGAN"))
                lblPolcyTanggal.Text = nSr(MyRecReadA("TANGGAL_ENTRY"))
                LblMohon.Text = nSr(MyRecReadA("TANGGAL_PROSES"))
                lblPolcyUser.Text = nSr(MyRecReadA("MYUSER"))
                TxtDisetujuiNoRangka.Text = nSr(MyRecReadA("CHANGE"))
                LblNoteAsuransi.Text = nSr(MyRecReadA("CHANGE1"))
                lblDisetujuiNoRangka.Text = TxtDisetujuiNoRangka.Text

                TxtDisetujuiTahun.Text = ""
                TxtDisetujuiHrgDisc.Text = "0" : TxtDisetujuiHrgDisc0.Text = "0"
                TxtDisetujuiHrgSubs.Text = "0"
                TxtDisetujuiHrgKoms.Text = "0"

                If InStr(nSr(MyRecReadA("NOMOR_MOHON")), "WB/APR/SD") <> 0 Then
                    lblDisetujuiHrgUnit.Text = LblHarga.Text
                    'If nSr(MyRecReadA("CHANGE")) <> "" Then
                    ' lblDisetujuiTahun.Text = nSr(MyRecReadA("CHANGE"))
                    'End If
                    If nSr(MyRecReadA("CHANGE1")) <> "" Then
                        TxtDisetujuiHrgDisc.Text = nSr(MyRecReadA("CHANGE1"))
                        TxtDisetujuiHrgDisc0.Text = nSr(MyRecReadA("RUPIAH"))
                    End If
                    If nSr(MyRecReadA("CHANGE2")) <> "" Then
                        TxtDisetujuiHrgSubs.Text = nSr(MyRecReadA("CHANGE2"))
                    End If
                    If nSr(MyRecReadA("CHANGE3")) <> "" Then
                        TxtDisetujuiHrgKoms.Text = nSr(MyRecReadA("CHANGE3"))
                    End If
                    If nSr(MyRecReadA("CHANGE4")) <> "" Then
                        TxtDisetujuiTahun.Text = nSr(MyRecReadA("CHANGE4"))
                    End If
                    LblPerubahanHargaUnit.Text = fLg(lblDisetujuiHrgUnit.Text)
                    LblPerubahanHargaDisc.Text = fLg(TxtDisetujuiHrgDisc.Text)
                    LblPerubahanHargaSubs.Text = fLg(TxtDisetujuiHrgSubs.Text)
                    LblPerubahanHargaKoms.Text = fLg(TxtDisetujuiHrgKoms.Text)
                    lblPerubahanTahun.Text = TxtDisetujuiTahun.Text
                Else
                    TxtDisetujuiTahun.Text = lblTahun.Text
                    lblDisetujuiHrgUnit.Text = LblHarga.Text
                    TxtDisetujuiHrgDisc.Text = LblDisc.Text
                    TxtDisetujuiHrgSubs.Text = LblSubsidi.Text
                    TxtDisetujuiHrgKoms.Text = LblKomisi.Text

                    LblPerubahanHargaUnit.Text = fLg(lblDisetujuiHrgUnit.Text)
                    LblPerubahanHargaDisc.Text = fLg(TxtDisetujuiHrgDisc.Text)
                    LblPerubahanHargaSubs.Text = fLg(TxtDisetujuiHrgSubs.Text)
                    LblPerubahanHargaKoms.Text = fLg(TxtDisetujuiHrgKoms.Text)
                    lblPerubahanTahun.Text = TxtDisetujuiTahun.Text

                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Sub clearSPKAD()
        LblPindahDanaTipe.Text = ""
        LblDisc.Text = "0" : LblKomisi.Text = "0" : LblSubsidi.Text = "0" : LblJns0.Text = "" : lblRoad.Text = ""
        LblAksesorisHdiary.Text = ""
        LblPindahDanaSPKNama.Text = ""
        MultiViewPindahDana.ActiveViewIndex = -1

    End Sub

    Function GetDataA_Tabel_SPKAD(ByVal mSqlCommadstring As String, ByVal mType As Byte) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Tabel_SPKAD = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_SPKAD = IIf(MyRecReadA.HasRows = True, 1, 0)


            While MyRecReadA.Read()
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TGLIN" Then LblTglMHS.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TGLDO" Then LblTglDO.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TGLCR" Then LblTglCreateSPK.Text = nSr(MyRecReadA("NILAI")) 'Tanggal Creat SPK
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TGLAP" Then LblTglSetujuSM.Text = nSr(MyRecReadA("NILAI")) 'Tanggal Disetujui
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_NAMA" Then LblNama.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_SALES" Then LblSales.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_IDSALES" Then LblSalesSPV0.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_JNS" Then LblJns.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_JNSCD" Then LblJns0.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_ROAD" Then lblRoad.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TNR" Then lblTnr.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_RANGKA" Then lblNorangka.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_THN" Then lblTahun.Text = nSr(MyRecReadA("NILAI"))

                If nSr(MyRecReadA("KETERANGAN")) = "SPK_CDTIPE" Then LblCdType.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TIPE" Then lblTipe.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_WARNA" Then lblWarna.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_PCERMATM" Then LblPaketCermat.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_PCERMATJ" Then LblBedathn.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_HARGA" Then LblHarga.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_DISC" Then LblDisc.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_SUBSIDI" Then LblSubsidi.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_KOMISI" Then LblKomisi.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_AKSESORIS" Then
                    LblAksesorisHdiary.Text = LblAksesorisHdiary.Text & nSr(MyRecReadA("NILAI"))
                End If

                lblPengajuanTahun.Text = lblTahun.Text
                LblPengajuanHargaUnit.Text = LblHarga.Text
                LblPengajuanHargaDisc.Text = LblDisc.Text()
                LblPengajuanHargaSubs.Text = LblSubsidi.Text()
                LblPengajuanHargaKoms.Text = LblKomisi.Text()

                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TOTAL" Then LblTotal.Text = nSr(MyRecReadA("NILAI"))

                If nSr(MyRecReadA("KETERANGAN")) = "SPK_BAYAR" Then LblBayar.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_SISA" Then LblSisa.Text = nSr(MyRecReadA("NILAI"))

                'LblCatatanNorangka.Text = "" : LblCatatanSPK.Text = "" : LblCatatanCRVL.Text = "" : LblUangMuka.Text = "0" : LblCatatanUM.Text = ""

                LblsetujuDiskon.Text = ""
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_UM" Then LblUangMuka.Text = nSr(MyRecReadA("NILAI"))
                'If nSr(MyRecReadA("KETERANGAN")) = "SPK_CRVALID" Then LblCatatanCRVL.Text = nSr(MyRecReadA("NILAI"))
                'If nSr(MyRecReadA("KETERANGAN")) = "RANGKA_NOTE" Then LblCatatanNorangka.Text = nSr(MyRecReadA("NILAI"))
                'If nSr(MyRecReadA("KETERANGAN")) = "SPK_NOTE" Then LblCatatanSPK.Text = nSr(MyRecReadA("NILAI"))
                'If nSr(MyRecReadA("KETERANGAN")) = "DP_NOTE" Then LblCatatanUM.Text = nSr(MyRecReadA("NILAI"))

                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TGLKIRIM" Then LblKirimCustomer.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TGLTERIMA" Then LblTerimaCustomer.Text = nSr(MyRecReadA("NILAI"))

                If nSr(MyRecReadA("KETERANGAN")) = "SPK_HRGSETUJU" Then LblsetujuDiskon.Text = nSr(MyRecReadA("NILAI"))
                'Tidak dipakai
                If InStr(nSr(MyRecReadA("KETERANGAN")), "SPK_SETUJU0") <> 0 Then
                    lblTglsetuju0.Text = nSr(MyRecReadA("KETERANGAN"))
                    TxtCatatan0.Text = nSr(MyRecReadA("NILAI"))
                End If
                If InStr(nSr(MyRecReadA("KETERANGAN")), "SPK_SETUJU1") <> 0 Then
                    lblTglSetuju1.Text = nSr(MyRecReadA("KETERANGAN"))
                    TxtCatatan1.Text = nSr(MyRecReadA("NILAI"))
                End If
                If InStr(nSr(MyRecReadA("KETERANGAN")), "SPK_SETUJU2") <> 0 Then
                    lblTglSetuju2.Text = nSr(MyRecReadA("KETERANGAN"))
                    TxtCatatan2.Text = nSr(MyRecReadA("NILAI"))
                End If
                If InStr(nSr(MyRecReadA("KETERANGAN")), "SPK_SETUJU3") <> 0 Then
                    LblTglSetuju3.Text = nSr(MyRecReadA("KETERANGAN"))
                    TxtCatatan3.Text = nSr(MyRecReadA("NILAI"))
                End If
                If InStr(nSr(MyRecReadA("KETERANGAN")), "SPK_SETUJU4") <> 0 Then
                    LblTglSetuju4.Text = nSr(MyRecReadA("KETERANGAN"))
                    TxtCatatan4.Text = nSr(MyRecReadA("NILAI"))
                End If
                If InStr(nSr(MyRecReadA("KETERANGAN")), "SPK_SETUJU5") <> 0 Then
                    LblTglSetuju5.Text = nSr(MyRecReadA("KETERANGAN"))
                    TxtCatatan5.Text = nSr(MyRecReadA("NILAI"))
                End If

                If nSr(MyRecReadA("KETERANGAN")) = "SPK_NAMA" Then LblPindahDanaSPKNama.Text = nSr(MyRecReadA("NILAI"))
                
                If mType > 0 Then
                    If nSr(MyRecReadA("KETERANGAN")) = "SPK_TGLDO" Then Call insertTabelPindahDana(1, IIf(mType = 1, "ASAL", "TUJUAN"), IIf(mType = 1, LblNoSPK.Text, LblPindahDanaSPKTuju.Text), "Tanggal DO", nSr(MyRecReadA("NILAI")))
                    If nSr(MyRecReadA("KETERANGAN")) = "SPK_NAMA" Then Call insertTabelPindahDana(1, IIf(mType = 1, "ASAL", "TUJUAN"), IIf(mType = 1, LblNoSPK.Text, LblPindahDanaSPKTuju.Text), "Nama", nSr(MyRecReadA("NILAI")))
                    If nSr(MyRecReadA("KETERANGAN")) = "SPK_BAYAR" Then Call insertTabelPindahDana(1, IIf(mType = 1, "ASAL", "TUJUAN"), IIf(mType = 1, LblNoSPK.Text, LblPindahDanaSPKTuju.Text), "Total Bayar", nSr(MyRecReadA("NILAI")))
                    If nSr(MyRecReadA("KETERANGAN")) = "SPK_ALAMAT" Then Call insertTabelPindahDana(1, IIf(mType = 1, "ASAL", "TUJUAN"), IIf(mType = 1, LblNoSPK.Text, LblPindahDanaSPKTuju.Text), "Alamat", nSr(MyRecReadA("NILAI")))
                    If nSr(MyRecReadA("KETERANGAN")) = "SPK_EMAIL" Then Call insertTabelPindahDana(1, IIf(mType = 1, "ASAL", "TUJUAN"), IIf(mType = 1, LblNoSPK.Text, LblPindahDanaSPKTuju.Text), "Email", nSr(MyRecReadA("NILAI")))
                    If nSr(MyRecReadA("KETERANGAN")) = "SPK_NOHP" Then Call insertTabelPindahDana(1, IIf(mType = 1, "ASAL", "TUJUAN"), IIf(mType = 1, LblNoSPK.Text, LblPindahDanaSPKTuju.Text), "No Handphone", nSr(MyRecReadA("NILAI")))

                End If

                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJNOSPK" Then Call insertTabelPindahDana(1, "TUJUAN", LblPindahDanaSPKTuju.Text, "Nomor SPK", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJTGLDO" Then Call insertTabelPindahDana(1, "TUJUAN", LblPindahDanaSPKTuju.Text, "Tanggal DO", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJNAMA" Then Call insertTabelPindahDana(1, "TUJUAN", LblPindahDanaSPKTuju.Text, "Nama", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJBAYAR" Then Call insertTabelPindahDana(1, "TUJUAN", LblPindahDanaSPKTuju.Text, "Total Bayar", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJALAMAT" Then Call insertTabelPindahDana(1, "TUJUAN", LblPindahDanaSPKTuju.Text, "Alamat", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJEMAIL" Then Call insertTabelPindahDana(1, "TUJUAN", LblPindahDanaSPKTuju.Text, "Email", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJNOHP" Then Call insertTabelPindahDana(1, "TUJUAN", LblPindahDanaSPKTuju.Text, "No Handphone", nSr(MyRecReadA("NILAI")))

                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_NOREJECT" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", LblPindahDanaSPKTuju.Text, "Nomor Virtual Account", "20035" & nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_PEMOHON" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", LblPindahDanaSPKTuju.Text, "Pemohon", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_NAMA" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", LblPindahDanaSPKTuju.Text, "Nama", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_EMAIL" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", LblPindahDanaSPKTuju.Text, "Email", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_HP" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", LblPindahDanaSPKTuju.Text, "No Handphone", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_TGLPAYMENT" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", LblPindahDanaSPKTuju.Text, "Tgl Payment", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_PAYMENT" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", LblPindahDanaSPKTuju.Text, "Jumlah", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_SPKDETAIL" Then
                    LblNoSPK_KhususVA.Text = nSr(MyRecReadA("NILAI"))
                    LblNoSPK_KhususVA.Visible = True
                    LblNoSPK.Visible = False
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetDataA_Tabel_SPK(ByVal mNOSPK As String, ByVal mServer As Byte, ByVal mType As Byte) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Tabel_SPK = 0

        cnn = New OleDbConnection(strconn)

        Dim Mytxtsql As String = "SELECT *, " & _
            "(SELECT STOCK_Kirimtgl       FROM TRXN_STOCK     WHERE STOCK_NORANGKA=SPK_NORANGKA) AS mfTglKirimUnit," & _
            "(SELECT STOCK_Kirimtglterima FROM TRXN_STOCK     WHERE STOCK_NORANGKA=SPK_NORANGKA) AS mfTglKirimUnitTerima," & _
            "(SELECT SPKCANCEL_NO         FROM TRXN_SPKCANCEL WHERE SPKCANCEL_NO = SPK_NO)       AS mfNoCancel," & _
            "(SELECT SUM(ISNULL(ARTRAN_JUMLAH,0)) as mfBayar0 FROM TRXN_ARTRAN WHERE ARTRAN_NOSPK=SPK_No AND ISNULL(ARTRAN_NOWO,'')='' ) as mBayar   " & _
            "FROM TRXN_SPK,DATA_SALESMAN,DATA_LEASE,DATA_TYPE,DATA_WARNA WHERE " & _
            "SPK_CdSales=Sales_Kode AND SPK_Cdlease=Lease_Kode AND SPK_CdType=TYPE_Type AND SPK_CdWarna=WARNA_Kode AND SPK_NO='" & mNOSPK & "'"


        Try
            cnn.Open()
            cmd = New OleDbCommand(Mytxtsql, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_SPK = IIf(MyRecReadA.HasRows = True, 1, 0)
            If GetDataA_Tabel_SPK = 1 Then
                If MyRecReadA.Read() Then
                    LblTglMHS.Text = DtFr(MyRecReadA("SPK_Tanggal"), "yyyy-MM-dd")
                    LblTglCreateSPK.Text = DtFr(MyRecReadA("SPK_TGLSPK"), "yyyy-MM-dd")
                    LblTglSetujuSM.Text = DtFr(MyRecReadA("SPK_TGLURT"), "yyyy-MM-dd")
                    LblTglDO.Text = DtFr(MyRecReadA("SPK_TglDO"), "yyyy-MM-dd")


                    LblNama.Text = nSr(MyRecReadA("SPK_NAMA1"))
                    LblSales.Text = nSr(MyRecReadA("Sales_Nama"))
                    LblSalesSPV.Text = nSr(MyRecReadA("SPK_CdSales")) : LblSalesSPV0.Text = nSr(MyRecReadA("SPK_CdSSales"))

                    'Unit
                    LblCdType.Text = nSr(MyRecReadA("SPK_CDTYPE"))
                    lblTipe.Text = nSr(MyRecReadA("TYPE_Nama"))
                    lblGroupTipe.Text = nSr(MyRecReadA("TYPE_CdGroup"))
                    lblWarna.Text = nSr(MyRecReadA("WARNA_Int"))
                    lblNorangka.Text = nSr(MyRecReadA("SPK_NoRangka"))
                    lblTahun.Text = nSr(MyRecReadA("SPK_Tahun"))
                    lblRoad.Text = nSr(MyRecReadA("SPK_Road"))

                    LblHarga.Text = nSr(MyRecReadA("SPK_Piutang")) : LblPaketCermat.Text = nSr(MyRecReadA("SPK_PaketCermat"))
                    LblDisc.Text = nSr(MyRecReadA("SPK_Potongan")) : LblBedathn.Text = nSr(MyRecReadA("SPK_PaketCermatJ"))
                    LblSubsidi.Text = nSr(MyRecReadA("SPK_HrgADM"))

                    LblKomisi.Text = nSr(MyRecReadA("SPK_Komisi"))
                    LblTotal.Text = (nLg(MyRecReadA("SPK_Piutang")) - nLg(MyRecReadA("SPK_Potongan")))

                    LblJns.Text = nSr(MyRecReadA("SPK_Cdlease"))
                    LblJns0.Text = nSr(MyRecReadA("LEASE_Nama"))
                    lblTnr.Text = nSr(MyRecReadA("SPK_HrgASR"))
                    LblBayar.Text = nLg(MyRecReadA("mBayar"))
                    LblSisa.Text = nLg(nLg(MyRecReadA("SPK_Piutang")) - nLg(MyRecReadA("SPK_Potongan")) - nLg(MyRecReadA("mBayar")))





                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
            Call GetDataA_Tabel_SPK_BAYAR(mNOSPK, mServer, 0)
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function



    Function GetDataA_Tabel_H_DIary(ByVal mNOSPK As String, ByVal mServer As Byte, ByVal mType As Byte) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Tabel_H_DIary = 0

        cnn = New OleDbConnection(strconn)

        Dim Mytxtsql As String = "SELECT * FROM TRXN_SPKD WHERE SPKD_NO='" & mNOSPK & "'"


        Try
            cnn.Open()
            cmd = New OleDbCommand(Mytxtsql, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_H_DIary = IIf(MyRecReadA.HasRows = True, 1, 0)
            If GetDataA_Tabel_H_DIary = 1 Then
                While MyRecReadA.Read()
                    If InStr(nSr(MyRecReadA("SPKD_NAMA")), "NAMA_PEMESAN") <> 0 Then
                        LblHDiaryNama.Text = nSr(MyRecReadA("SPKD_NILAI"))
                    ElseIf InStr(nSr(MyRecReadA("SPKD_NAMA")), "KETERANGAN_PROSPECT") <> 0 Then
                        LblHDiaryNote.Text = nSr(MyRecReadA("SPKD_NILAI"))
                    ElseIf InStr(nSr(MyRecReadA("SPKD_NAMA")), "HARGA") <> 0 Then
                        LblHDiaryHarga.Text = nSr(MyRecReadA("SPKD_NILAI"))
                    ElseIf InStr(nSr(MyRecReadA("SPKD_NAMA")), "DISC") <> 0 Then
                        LblHDiaryDisc.Text = nSr(MyRecReadA("SPKD_NILAI"))
                    ElseIf InStr(nSr(MyRecReadA("SPKD_NAMA")), "JENIS_PEMBAYARAN") <> 0 Then
                        LblHDiaryJenisByr.Text = nSr(MyRecReadA("SPKD_NILAI"))
                    ElseIf InStr(nSr(MyRecReadA("SPKD_NAMA")), "ASURANSI") <> 0 Then
                        LblHDiaryAsuransi.Text = nSr(MyRecReadA("SPKD_NILAI"))
                    ElseIf InStr(nSr(MyRecReadA("SPKD_NAMA")), "AKSESORIS") <> 0 Then
                        LblHDiaryAksesoris.Text = nSr(MyRecReadA("SPKD_NILAI"))
                    ElseIf InStr(nSr(MyRecReadA("SPKD_NAMA")), "NAMA PAKET") <> 0 Then
                        LblHDiaryPaket.Text = nSr(MyRecReadA("SPKD_NILAI"))
                    End If
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
            Call GetDataA_Tabel_SPK_BAYAR(mNOSPK, mServer, 0)
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function




    Function GetDataA_Tabel_SPK_BAYAR(ByVal mNOSPK As String, ByVal mServer As Byte, ByVal mType As Byte) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        mNOSPK = 0

        cnn = New OleDbConnection(strconn)

        Dim Mytxtsql As String = "SELECT SPKB_NILAI AS IsiField FROM TRXN_SPKB WHERE SPKB_NO='" & mNOSPK & "' AND SPKB_NAMA like '%UANG MUKA%'"

        GetDataA_Tabel_SPK_BAYAR = 0
        Try
            cnn.Open()
            cmd = New OleDbCommand(Mytxtsql, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_SPK_BAYAR = IIf(MyRecReadA.HasRows = True, 1, 0)
            If GetDataA_Tabel_SPK_BAYAR = 1 Then
                If MyRecReadA.Read() Then
                    LblUangMuka.Text = nSr(MyRecReadA("IsiField"))
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetDataA_Tabel_SPKAS(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Tabel_SPKAS = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_SPKAS = IIf(MyRecReadA.HasRows = True, 1, 0)
            Dim mPos As String
            Dim mCatatan1 As String
            While MyRecReadA.Read()
                mPos = nSr(MyRecReadA("SETUJU_POS"))
                mCatatan1 = nSr(MyRecReadA("SETUJU_ENTRY")) & "/" & _
                                nSr(MyRecReadA("SETUJU_USER")) & "/" & _
                                IIf(nSr(MyRecReadA("SETUJU_STATUS")) = "1", "SETUJU", "DITOLAK")
                If InStr(lblPosSetuju.Text, mPos) = 0 Then
                    mCatatan1 = ""
                End If
                If mPos = "0" Then
                    lblTglsetuju0.Text = mCatatan1
                    TxtCatatan0.Text = nSr(MyRecReadA("SETUJU_CATATAN"))
                ElseIf mPos = "1" Then
                    lblTglSetuju1.Text = mCatatan1
                    TxtCatatan1.Text = nSr(MyRecReadA("SETUJU_CATATAN"))
                ElseIf mPos = "2" Then
                    lblTglSetuju2.Text = mCatatan1
                    TxtCatatan2.Text = nSr(MyRecReadA("SETUJU_CATATAN"))
                ElseIf mPos = "3" Then
                    LblTglSetuju3.Text = mCatatan1
                    TxtCatatan3.Text = nSr(MyRecReadA("SETUJU_CATATAN"))
                ElseIf mPos = "4" Then
                    LblTglSetuju4.Text = mCatatan1
                    TxtCatatan4.Text = nSr(MyRecReadA("SETUJU_CATATAN"))
                ElseIf mPos = "5" Then
                    LblTglSetuju5.Text = mCatatan1
                    TxtCatatan5.Text = nSr(MyRecReadA("SETUJU_CATATAN"))
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try

    End Function
    Function GetDataA_Tabel_WAREHOUSE(ByVal mSqlCommadstring As String, ByVal mNoWO As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Tabel_WAREHOUSE = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_WAREHOUSE = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                LblWHTglMohon.Text = nSr(MyRecReadA("ASSREPAIR_TGLEMAIL"))
                LblWHTglInput.Text = nSr(MyRecReadA("ASSREPAIR_TGLINPUT"))
                LblWHTglSetuju.Text = nSr(MyRecReadA("ASSREPAIR_TGLSETUJU"))
                LblWHTglWo.Text = nSr(MyRecReadA("ASSREPAIR_TGLWO"))
                'LblWHNoMohon.Text = mNoWO

                LblWHNoRangka.Text = nSr(MyRecReadA("STOCK_NORANGKA"))
                LblWHTipe.Text = nSr(MyRecReadA("TYPE_NAMA"))
                LblWHWarna.Text = nSr(MyRecReadA("WARNA_INT"))
                LblWHHarga.Text = nSr(MyRecReadA("ASSREPAIR_HARGA"))
                LblWHBengkel.Text = nSr(MyRecReadA("SUPLIER_NAMA"))
                LblWHKeterangan.Text = nSr(MyRecReadA("ASSREPAIR_KETERANGAN"))
                LblWHDetailKerjaan.Text = nSr(MyRecReadA("ASSREPAIR_RINCIAN"))
                'If InStr(nSr(MyRecReadA("KETERANGAN")), "SPK_SETUJU1") <> 0 Then
                'lblTglSetuju1.Text = nSr(MyRecReadA("KETERANGAN"))
                'TxtCatatan1.Text = nSr(MyRecReadA("NILAI"))
                'End If

            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetData_Nomor() As String
        Call Msg_err("", "")
        GetData_Nomor = GetDataA_SearchNomor()
        If GetData_Nomor <> "" Then
            If GetData_Nomor = "NO FOUND" Then
                GetData_Nomor = GetDataA_StartNomor()
            End If
        End If
        If GetData_Nomor = "" Then
            Call Msg_err("DATA TIDAK BERHASIL DISIMPAN", "")
        End If
    End Function
    Function GetDataA_SearchNomor() As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String

        Call Msg_err("", "")
        GetDataA_SearchNomor = ""
        Dim mTahun As String = Format(Now(), "yy")
        Dim mBulan As String = Format(Now(), "MM")

        'mSqlCommadstring = "SELECT NOMOR FROM TRXN_SPKAH WHERE CABANG='" & lblDealer.Text & "' AND NOT(NOMOR IS NULL OR NOMOR='') AND MONTH(TANGGAL_ENTRY)=MONTH(GETDATE()) AND YEAR(TANGGAL_ENTRY)=YEAR(GETDATE()) ORDER BY NOMOR DESC"
        mSqlCommadstring = "SELECT MAX(NOMOR) as mMaxNomor FROM TRXN_SPKAH WHERE CABANG='" & lblDealer.Text & "' AND NOMOR like '" & lblDealer.Text & mTahun & mBulan & "%'"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            mFind = IIf(MyRecReadA.HasRows = True, 1, 0)
            If mFind = 0 Then
                GetDataA_SearchNomor = "NO FOUND"
            Else
                MyRecReadA.Read()
                If nSr(MyRecReadA("mMaxNomor")) = "" Then
                    GetDataA_SearchNomor = "NO FOUND"
                Else
                    GetDataA_SearchNomor = Val(nSr(MyRecReadA("mMaxNomor"))) + 1
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetDataA_StartNomor() As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String

        Call Msg_err("", "")
        GetDataA_StartNomor = ""
        mSqlCommadstring = "SELECT GETDATE() as mCurrDate"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            mFind = IIf(MyRecReadA.HasRows = True, 1, 0)
            If mFind = 0 Then GetDataA_StartNomor = "NO FOUND"
            While MyRecReadA.Read()
                GetDataA_StartNomor = lblDealer.Text & _
                                     Format((MyRecReadA("mCurrDate")), "yyMM") & _
                                     "0001"
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetDataA_Rangka_TYPE(ByVal mSqlCommadstring As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Rangka_TYPE = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                GetDataA_Rangka_TYPE = (nSr(MyRecReadA("TYPE_CdRangka")))
                lblGroupTipe.Text = (nSr(MyRecReadA("TYPE_CdGroup")))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetDataA_MaxDisc_TYPE(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_MaxDisc_TYPE = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                GetDataA_MaxDisc_TYPE = Val(nSr(MyRecReadA("TYPED_Jumlah")))
                lblGroupTipe.Text = (nSr(MyRecReadA("TYPE_CdGroup")))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetDataA_Validasi_Asesoris(ByVal mSqlCommadstring As String, ByVal mSqlFindFiled As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Validasi_Asesoris = "0"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If mSqlFindFiled = "OPT_TIPE" Then
                If MyRecReadA.HasRows = True Then
                    While MyRecReadA.Read()
                        If lblGroupTipe.Text <> (nSr(MyRecReadA("OPT_TIPE"))) Then
                            GetDataA_Validasi_Asesoris = "1"
                        End If
                    End While
                End If
            Else
                MyRecReadA.Read()
                GetDataA_Validasi_Asesoris = nSr(MyRecReadA("OPT_TIPE"))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetData_NomorChat() As String
        Call Msg_err("", "")
        GetData_NomorChat = GetDataA_SearchNomorChat()
        If GetData_NomorChat <> "" Then
            If GetData_NomorChat = "NO FOUND" Then
                GetData_NomorChat = GetDataA_StartNomorChat()
            End If
        End If
        If GetData_NomorChat = "" Then
            Call Msg_err("DATA TIDAK BERHASIL DISIMPAN", "")
        End If
    End Function
    Function GetDataA_SearchNomorChat() As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String

        Call Msg_err("", "")
        GetDataA_SearchNomorChat = ""
        Dim mTahun As String = Format(Now(), "yy")
        Dim mBulan As String = Format(Now(), "MM")
        Dim mHari As String = Format(Now(), "dd")

        mSqlCommadstring = "SELECT MAX(CHAT_NO) as mMaxNomor FROM TRXN_SPKAHCHT WHERE CHAT_NO like '" & mTahun & mBulan & mHari & "%'"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            mFind = IIf(MyRecReadA.HasRows = True, 1, 0)
            If mFind = 0 Then
                GetDataA_SearchNomorChat = "NO FOUND"
            Else
                MyRecReadA.Read()
                If nSr(MyRecReadA("mMaxNomor")) = "" Then
                    GetDataA_SearchNomorChat = "NO FOUND"
                Else
                    GetDataA_SearchNomorChat = Val(nSr(MyRecReadA("mMaxNomor"))) + 1
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetDataA_StartNomorChat() As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String

        Call Msg_err("", "")
        GetDataA_StartNomorChat = ""
        mSqlCommadstring = "SELECT GETDATE() as mCurrDate"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            mFind = IIf(MyRecReadA.HasRows = True, 1, 0)
            If mFind = 0 Then GetDataA_StartNomorChat = "NO FOUND"
            While MyRecReadA.Read()
                GetDataA_StartNomorChat = lblDealer.Text & _
                                     Format((MyRecReadA("mCurrDate")), "yyMMdd") & _
                                     "01"
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetDataA_Chat(ByVal mSqlCommadstring As String, ByVal mType As Byte) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Chat = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                'CHAT_DEALER
                LblChatDlr.Text = nSr(MyRecReadA("CHAT_DEALER"))
                txtChatTanggal.Text = nSr(MyRecReadA("CHAT_TGL"))
                txtChatNo1.Text = nSr(MyRecReadA("CHAT_NO"))
                txtChatNo2.Text = nSr(MyRecReadA("CHAT_NOMOHON"))
                txtChatUser.Text = nSr(MyRecReadA("CHAT_USER"))
                TxtChatMsg.Text = "" : TxtChatMsg.Enabled = True
                If mType = 1 Then
                    TxtChatMsg.Text = nSr(MyRecReadA("CHAT_TEXT"))
                Else
                    Button9.Text = "Simpan"
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetData_ChatMessage(ByVal mSqlCommadstring As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetData_ChatMessage = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                GetData_ChatMessage = GetData_ChatMessage & nSr(MyRecReadA("CHAT_TGL")) & " Pesan: " & nSr(MyRecReadA("CHAT_TEXT")) & Chr(13)
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function


    Function CreateVoucher_PindahDana() As Byte
        Dim QuerySqlSts As Byte = 0
        Dim mNOKw As String = ""
        Dim mNOVCR As String = ""
        Dim mNoaccount As String = "020100"

        CreateVoucher_PindahDana = 0
        Try
            For iloop As Byte = 0 To 19
                Select Case iloop
                    Case 0 : QuerySqlSts = ValidasiSPKAsalDana()
                    Case 1
                        MySTRsql1 = "SELECT  CHANGE2 as IsiField FROM TRXN_SPKAH WHERE NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND NOMOR='" & lblNomorSetuju.Text & "'"
                        mNOKw = GetDataD_IsiField(MySTRsql1, "")
                        If mNOKw = "" Then
                            mNOKw = CREATE_NO1() : QuerySqlSts = IIf(mNOKw = "", 0, 1)
                        Else
                            MySTRsql1 = "DELETE FROM TRXN_KWITANSI  WHERE KWITANSI_No='" & mNOKw & "'"
                            Call UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text)
                            MySTRsql1 = "DELETE FROM TRXN_KWITANSIB WHERE KWITANSIB_No='" & mNOKw & "'"
                            Call UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text)
                        End If
                    Case 2 : QuerySqlSts = UPDATE_SPKAHKWITANSI(mNOKw)
                    Case 3 : QuerySqlSts = INSERT_KWITANSI(mNOKw, LblPindahDanaSPKAsal.Text, LblPindahDanaSPKNama.Text, "PINDAH DANA; SPK: " & LblPindahDanaSPKAsal.Text & ":Rp.-" & fLg(nLg(LblPindahDanaSPKJuml.Text)) & "; SPK " & LblPindahDanaSPKTuju.Text & ":Rp." & fLg(nLg(LblPindahDanaSPKJuml.Text)), "0")
                    Case 4 : QuerySqlSts = INSERT_KWITANSIB(nLg(LblPindahDanaSPKJuml.Text) * -1, mNOKw, LblPindahDanaSPKAsal.Text)
                    Case 5 : QuerySqlSts = INSERT_KWITANSIB(nLg(LblPindahDanaSPKJuml.Text), mNOKw, LblPindahDanaSPKTuju.Text)
                    Case 6 : QuerySqlSts = UpdateDataSPKC(LblPindahDanaSPKAsal.Text, "KWITANSI " & mNOKw & " PINDAH DANA ANTAR SPK")
                    Case 7

                        MySTRsql1 = "SELECT  CHANGE3 as IsiField FROM TRXN_SPKAH WHERE NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND NOMOR='" & lblNomorSetuju.Text & "'"
                        mNOVCR = GetDataD_IsiField(MySTRsql1, "")
                        If mNOVCR = "" Then
                            mNOVCR = CREATE_NO2() : QuerySqlSts = IIf(mNOVCR = "", 0, 1)
                        Else
                            MySTRsql1 = "DELETE FROM TRXN_ARTRAN WHERE ARTRAN_VCR='" & mNOVCR & "' AND ARTRAN_STATUS='" & mNoaccount & "'"
                            Call UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text)
                        End If
                    Case 8 : QuerySqlSts = UPDATE_SPKAHVOUCHER(mNOVCR)
                    Case 9 : QuerySqlSts = INSERT_TRANC(mNoaccount, mNOVCR)
                    Case 10 : QuerySqlSts = UPDATE_KWITANSI_BLANK(mNoaccount, mNOVCR)
                    Case 13 : QuerySqlSts = UPDATE_KWITANSI_VCR_TabelA(mNoaccount, mNOVCR, mNOKw, lblDealer.Text)
                End Select
                If QuerySqlSts <> 1 Then Exit For
            Next
            CreateVoucher_PindahDana = QuerySqlSts
        Catch ex As Exception

        End Try

    End Function
    Function UpdateVirtualAccount_PindahDana() As Byte
        MySTRsql1 = "UPDATE TRXN_VIRTUALACC SET VIRTUAL_NO='" & LblPindahDanaSPKTuju.Text & "' WHERE VIRTUAL_NO='" & LblPindahDanaSPKAsal.Text & "' AND VIRTUAL_HMSDOCTGL IS NULL AND VIRTUAL_TGLPYMT IS NOT NULL"
        UpdateVirtualAccount_PindahDana = UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text)
    End Function


    Function ValidasiSPKAsalDana() As Byte
        Dim mJmlh As Double
        ValidasiSPKAsalDana = 0
        Try
            mJmlh = nDb(GetDataD_IsiField("SELECT ARTRAN_NOSPK, SUM(ISNULL(ARTRAN_JUMLAH,0)) as IsiField FROM TRXN_ARTRAN " & _
                                          "WHERE ARTRAN_NOSPK='" & LblNoSPK.Text & "' GROUP BY ARTRAN_NOSPK", lblDealer.Text))
            If mJmlh >= nDb(LblPindahDanaSPKJuml.Text) Then
                ValidasiSPKAsalDana = 1
            Else
                Call Msg_err("Error Jumlah Transaksi asal lebih kecil dari dana yang akan dipindahkan", "")
            End If
        Catch ex As Exception
            Call Msg_err("Error Jumlah Transaksi asal", "")
        End Try
    End Function
    Function CREATE_NO1() As String
        CREATE_NO1 = ""
        CREATE_NO1 = GetdataA_AddNomor("VOUCHER_KWREAL", 7, lblDealer.Text)
    End Function
    Function GetdataA_AddNomor(ByVal mField As String, ByVal mPanjang As Byte, ByVal mServer As String) As String
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mNomor As String
        Dim mSqlCommadstring As String = "SELECT " & mField & " FROM DATA_VOUCHER WHERE VOUCHER_No='A'"
        Call Msg_err("", "")
        GetdataA_AddNomor = ""
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                If MyRecReadA.Read Then
                    Dim mNomorfiled As String
                    Dim mNomorfiledNum As String
                    Dim mPanjang2 As Byte

                    mNomorfiled = nSr(MyRecReadA(mField))
                    mPanjang = Len(mNomorfiled) : mPanjang2 = 0
                    If Not IsNumeric(Right(mNomorfiled, 1)) Then
                        mPanjang2 = 1
                    End If
                    mPanjang = mPanjang - mPanjang2

                    mNomorfiledNum = Left(mNomorfiled, mPanjang)
                    mNomorfiledNum = Val(mNomorfiledNum) + 1
                    mNomor = Mid("0000000000", 1, mPanjang - Len(mNomorfiledNum))
                    mNomor = mNomor & mNomorfiledNum & Right(mNomorfiled, mPanjang2)

                    MySTRsql1 = "UPDATE DATA_VOUCHER SET " & mField & "='" & mNomor & "' WHERE VOUCHER_No='A'"
                    If UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text) = 1 Then
                        GetdataA_AddNomor = mNomor
                    End If
                End If
            Else
                MySTRsql1 = "INSERT INTO DATA_VOUCHER( VOUCHER_No," & mField & ") VALUES ('A','" & (Mid("0000000000", 1, mPanjang - 1) & "1") & "')"
                If UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text) = 1 Then
                    GetdataA_AddNomor = Mid("0000000000", 1, mPanjang - 1) & "1"
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function UPDATE_SPKAHKWITANSI(ByVal mpTxtNoKw As String) As Byte
        MySTRsql1 = "UPDATE TRXN_SPKAH SET CHANGE2='" & mpTxtNoKw & "' WHERE NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND NOMOR='" & lblNomorSetuju.Text & "'"
        UPDATE_SPKAHKWITANSI = UpdateDatabase_Tabel(MySTRsql1, "")
    End Function
    Function UPDATE_SPKAHVOUCHER(ByVal mpTxtNoVCR As String) As Byte
        MySTRsql1 = "UPDATE TRXN_SPKAH SET CHANGE3='" & mpTxtNoVCR & "' WHERE NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND NOMOR='" & lblNomorSetuju.Text & "'"
        UPDATE_SPKAHVOUCHER = UpdateDatabase_Tabel(MySTRsql1, "")
    End Function
    Function INSERT_KWITANSI(ByVal mpTxtNoKw As String, ByVal mpNOSPK As String, ByVal mpNAMA As String, ByVal mpNOte As String, ByVal mpJumlah As String) As Byte
        MySTRsql1 = "INSERT INTO TRXN_KWITANSI(KWITANSI_No,KWITANSI_Tgl,KWITANSI_NoSPK,KWITANSI_NoWO,KWITANSI_NOTTK," & _
                   "KWITANSI_Nama,KWITANSI_Keterangan,KWITANSI_Jumlah,KWITANSI_Status,KWITANSI_Tipe,KWITANSI_JnsTagih) VALUES " & _
                   "('" & mpTxtNoKw & "',GETDATE(),'" & mpNOSPK & "','','','" & TxtPetik(mpNAMA) & "','" & TxtPetik(mpNOte) & "',0,'R','6','3')"
        INSERT_KWITANSI = UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text)
    End Function
    Function INSERT_KWITANSIB(ByVal mpKWITANSIB_Bayar As Double, ByVal mpKWITANSIB_No As String, ByVal mpKWITANSIB_NOSPK As String) As Byte
        MySTRsql1 = "INSERT INTO TRXN_KWITANSIB(KWITANSIB_NoWO,KWITANSIB_CdAss,KWITANSIB_Bayar,KWITANSIB_No,KWITANSIB_TipeUM,KWITANSIB_NOSPK) VALUES " & _
                       "('',''," & mpKWITANSIB_Bayar & ",'" & mpKWITANSIB_No & "','','" & mpKWITANSIB_NOSPK & "')"
        INSERT_KWITANSIB = UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text)
    End Function
    Function UpdateDataSPKC(ByVal mNOSPK As String, ByVal mpNAMA As String) As Byte
        MySTRsql1 = "UPDATE TRXN_SPKC SET SPKC_NAMA='" & mpNAMA & "' WHERE SPKC_NO='" & mNOSPK & "' AND (SPKC_NAMA='PROSES KWITANSI PINDAH DANA ANTAR SPK' OR SPKC_NAMA='ENTRY PINDAH DANA ANTAR SPK')"
        UpdateDataSPKC = UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text)
    End Function


    Function CREATE_NO2() As String
        CREATE_NO2 = ""
        CREATE_NO2 = Getdata_AddVoucher("ACCOUNT_NoVcr1", "020100", lblDealer.Text)
    End Function
    Function Getdata_AddVoucher(ByVal mField As String, ByVal mAcc As String, ByVal mServer As String) As String
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mNomor As String
        MySTRsql1 = "SELECT " & mField & " FROM DATA_ACCOUNT WHERE ACCOUNT_No='" & mAcc & "'"
        Call Msg_err("", "")
        Getdata_AddVoucher = ""
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                If MyRecReadA.Read Then
                    mNomor = ""
                    Select Case UCase(mField)
                        Case UCase("ACCOUNT_NoVcr1")
                            If (MyRecReadA("ACCOUNT_NoVcr1") = Mid("9999999999", 1, 7 - 1)) Or nSr(MyRecReadA("ACCOUNT_NoVcr1")) = "" Then
                                mNomor = (Mid("0000000000", 1, 7 - 1) & "1")
                            Else
                                mNomor = (Mid("0000000000", 1, 7 - Len(Trim(Str(Val(MyRecReadA("ACCOUNT_NoVcr1")) + 1)))) & Val(MyRecReadA("ACCOUNT_NoVcr1")) + 1)
                            End If
                        Case UCase("ACCOUNT_NoVcr2")

                            If (MyRecReadA("ACCOUNT_NoVcr2") = Mid("9999999999", 1, 7 - 1)) Or nSr(MyRecReadA("ACCOUNT_NoVcr2")) = "" Then
                                mNomor = (Mid("0000000000", 1, 7 - 1) & "1")
                            Else
                                mNomor = (Mid("0000000000", 1, 7 - Len(Trim(Str(Val(MyRecReadA("ACCOUNT_NoVcr2")) + 1)))) & Val(MyRecReadA("ACCOUNT_NoVcr2")) + 1)
                            End If
                    End Select

                    MySTRsql1 = "UPDATE DATA_ACCOUNT SET " & mField & "='" & mNomor & "' WHERE ACCOUNT_No='" & mAcc & "'"
                    If UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text) = 1 Then
                        Getdata_AddVoucher = mNomor
                    End If
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function INSERT_TRANC(ByVal mAcc As String, ByVal mVcr As String) As Byte
        INSERT_TRANC = 0
        MySTRsql1 = "SELECT * FROM TRXN_TRANSC WHERE TRANSC_ENTRY='B' AND TRANSC_ACC ='" & mAcc & "' AND " & "TRANSC_VCR='" & mVcr & "'"
        'isian_belum_lengkap()
        If GetDataD_00NoFound01Found(MySTRsql1, lblDealer.Text) = 1 Then
            INSERT_TRANC = EDIT_TRANC(mAcc, mVcr, _
                                     TxtPetik(LblPindahDanaSPKNama.Text) & "(KWITANSI SWITCHING PEMBAYARAN)", _
                                     "BAYAR UNIT [" & LblPindahDanaSPKAsal.Text & "] = -" & fLg(LblPindahDanaSPKJuml.Text) & ";BAYAR UNIT [" & LblPindahDanaSPKTuju.Text & "] = " & fLg(LblPindahDanaSPKJuml.Text) & ";", _
                                     "GETDATE()", "", "", 0)
        Else
            INSERT_TRANC = ADD_TRANC(mAcc, mVcr, _
                                     TxtPetik(LblPindahDanaSPKNama.Text) & "(KWITANSI SWITCHING PEMBAYARAN)", _
                                     "BAYAR UNIT [" & LblPindahDanaSPKAsal.Text & "] = -" & fLg(LblPindahDanaSPKJuml.Text) & ";BAYAR UNIT [" & LblPindahDanaSPKTuju.Text & "] = " & fLg(LblPindahDanaSPKJuml.Text) & ";", _
                                     "GETDATE()", "", "", 0)


        End If
    End Function
    Function EDIT_TRANC(ByVal mAcc As String, ByVal mVcr As String, ByVal mNama As String, ByVal mNote As String, ByVal mTgl As String, ByVal mCOA As String, ByVal mDEPT As String, ByVal mJml As Double) As Byte
        MySTRsql1 = "UPDATE TRXN_TRANSC SET " & _
                    "TRANSC_NAMA='" & Microsoft.VisualBasic.Left(TxtPetik(mNama), 50) & "'," & _
                    "TRANSC_KET1='" & TxtPetik(Mid(mNote, 1, 50)) & "'," & "TRANSC_KET2='" & TxtPetik(Mid(mNote, 51, 50)) & "'," & _
                    "TRANSC_JUMLAH=" & nDb(mJml) & "," & "TRANSC_STAT='D',TRANSC_TGL=" & mTgl & ",TRANSC_GLACCOUNT='" & mCOA & "',TRANSC_DEPT='" & mDEPT & "' " & _
                    "WHERE TRANSC_ACC ='" & mAcc & "' AND " & "TRANSC_VCR='" & mVcr & "' AND TRANSC_ENTRY='B'"
        EDIT_TRANC = UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text)
    End Function
    Function ADD_TRANC(ByVal mAcc As String, ByVal mVcr As String, ByVal mNama As String, ByVal mNote As String, ByVal mTgl As String, ByVal mCOA As String, ByVal mDEPT As String, ByVal mJml As Double) As Byte
        MySTRsql1 = "INSERT INTO TRXN_TRANSC(TRANSC_ACC,TRANSC_VCR,TRANSC_TGL,TRANSC_ENTRY," & "TRANSC_NAMA,TRANSC_KET1,TRANSC_KET2,TRANSC_JUMLAH,TRANSC_STAT,TRANSC_GLACCOUNT,TRANSC_DEPT,TRANSC_USER) VALUES ('" & _
                     mAcc & "','" & mVcr & "'," & mTgl & ",'B','" & Microsoft.VisualBasic.Left(TxtPetik(mNama), 50) & "','" & _
                     TxtPetik(Mid(mNama, 1, 50)) & "','" & TxtPetik(Mid(mNama, 51, 50)) & "'," & nDb(mJml) & ",'D','" & mCOA & "','" & mDEPT & "','HMSWEB')"
        ADD_TRANC = UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text)
    End Function
    Function UPDATE_KWITANSI_BLANK(ByVal mAcc As String, ByVal mVcr As String) As Byte
        MySTRsql1 = "UPDATE TRXN_KWITANSI SET KWITANSI_Acc='', KWITANSI_NoVocr='' " & "WHERE KWITANSI_NoVocr='" & mVcr & "' AND KWITANSI_Acc='" & mAcc & "'"
        UPDATE_KWITANSI_BLANK = UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text)
    End Function
    Function UPDATE_KWITANSI_VCR_TabelA(ByVal mAcc As String, ByVal mVcr As String, ByVal mNoKwitansi As Object, ByVal mServer As String) As Byte
        mServer = "MyConnCloudDnet" & mServer

        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        UPDATE_KWITANSI_VCR_TabelA = 0
        MySTRsql1 = "SELECT * FROM TRXN_KWITANSI WHERE KWITANSI_No='" & mNoKwitansi & "' AND KWITANSI_Status='R'"
        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read
                    UPDATE_KWITANSI_VCR_TabelA = UPDATE_KWITANSI_VCR_TabelB(mAcc, mVcr, mNoKwitansi, mServer)
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
            If UPDATE_KWITANSI_VCR_TabelA = 1 Then
                MySTRsql1 = "UPDATE TRXN_KWITANSI SET KWITANSI_Acc='" & mAcc & "', KWITANSI_NoVocr='" & mVcr & "' " & " WHERE KWITANSI_No='" & mNoKwitansi & "' AND KWITANSI_Status='R'"
                Call UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text)
            End If
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function UPDATE_KWITANSI_VCR_TabelB(ByVal mAcc As String, ByVal mVcr As String, ByVal mNoKwitansi As Object, ByVal mServer As String) As Byte
        Dim mAdaBarisError As Byte
        Dim mAdaBarisGakError As Byte
        UPDATE_KWITANSI_VCR_TabelB = 0
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        MySTRsql1 = "SELECT * FROM TRXN_KWITANSIB  WHERE KWITANSIB_No='" & mNoKwitansi & "' AND ISNULL(KWITANSIB_NOSPK,'')<>''"
        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                mAdaBarisError = 0 : mAdaBarisGakError = 0
                While MyRecReadB.Read
                    If INSERT_ARTRAN(nSr(MyRecReadB("KWITANSIB_NOSPK")), nDb(MyRecReadB("KWITANSIB_Bayar")), "BANK", nSr(MyRecReadB("KWITANSIB_NoWO")), "", "", mAcc, mVcr, Now()) = 1 Then
                        mAdaBarisGakError = mAdaBarisGakError + 1
                    Else
                        mAdaBarisError = mAdaBarisError + 1
                    End If
                End While
            End If
            If (mAdaBarisError <> 0 Or mAdaBarisGakError = 0) Then
                UPDATE_KWITANSI_VCR_TabelB = 0
            Else
                UPDATE_KWITANSI_VCR_TabelB = 1
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function INSERT_ARTRAN(ByVal mSPK As String, ByVal mNilai As Double, ByVal mKet As String, ByVal mNOWO As String, ByVal mD As String, ByVal mTitip As String, ByVal mACC As String, ByVal mVCR As String, ByVal mTGL As String) As Byte
        mNOWO = IIf(mD = "" Or mD = "0000", "", mNOWO)
        MySTRsql1 = "INSERT INTO TRXN_ARTRAN(ARTRAN_NOSPK,ARTRAN_VCR,ARTRAN_STATUS,ARTRAN_TGL,ARTRAN_JUMLAH,ARTRAN_KET,ARTRAN_NOWO,ARTRAN_CdAss) VALUES " & _
                    "('" & mSPK & "','" & mVCR & "','" & mACC & "'," & FieldTgl(CDate(mTGL)) & "," & mNilai & ",'" & mKet & "','" & mNOWO & "','" & mD & "')"
        INSERT_ARTRAN = UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text)
    End Function

    Protected Sub Button14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button14.Click
        MySTRsql1 = "UPDATE TRXN_SPKAH SET CHANGE='" & TxtDisetujuiNoRangka.Text & "' WHERE " & _
                    "NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND JUDUL like 'ENTRY%'"
        '"NOMOR_MOHON='" & lblPolcyNomorMohon.Text & "' AND NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND NOMOR='" & LblResultNomor.Text & "'"
        If UpdateDatabase_Tabel(MySTRsql1, "") = 1 Then
            Call Msg_err("Update Rangka berhasil data akan di update terlebih dahulu", "")
            Call UpdateDatabase_Tabel("UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='ENTRY-D'  WHERE OPT_NOMORMOHON = '" & lblPolcyNomorMohon.Text & "' AND OPT_STATUSPROSES='ENTRY'", "")
            Call UpdateDatabase_Tabel("UPDATE TRXN_SPKAH SET TANGGAL_PROSES=NULL  WHERE NOMOR_MOHON = '" & lblPolcyNomorMohon.Text & "'", "")
            Call UpdateDatabase_Tabel("DELETE FROM  TRXN_SPKAD WHERE NOMOR_MOHON= '" & lblPolcyNomorMohon.Text & "'", "")
            Call UpdateDatabase_Tabel("DELETE FROM  TRXN_SPKAHERR  WHERE SPKAHERR_NOM= '" & lblPolcyNomorMohon.Text & "'", "")

        End If

        MultiView1a.ActiveViewIndex = 0
    End Sub

    Function GetData_Permohon_Persetujuan_Sudah_diSetuju(ByVal Cari As String, ByVal mLokasi As String) As Byte  'Baru belum diupdate VB.net
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim mNoMohon As String
        Dim mJudul As String
        Dim mJudulEdit As String
        Dim mAdaData As Byte
        Dim mTemp As String = ""
        Dim mInst As String
        Dim mNilaiCHange As String
        Dim mNilaiCHange1 As String
        Dim mNilaiCHange2 As String
        Dim mNilaiCHange3 As String
        Dim mSelisihHarga As Double = 0
        Dim mAppvSPV As String
        Dim ApprovalterakhirSiapa As String
        Dim mDiffHrgSPK As Double = 0

        mNilaiCHange = "" : mNilaiCHange1 = "" : mNilaiCHange2 = "" : mNilaiCHange3 = "" : mInst = ""

        Call UpdateSTJ_Dan_lainNya(mLokasi)

        Cari = "TANGGAL_SETUJU IS NOT NULL AND STATUS IS NULL  AND CABANG='" & mLokasi & "' AND NOMOR_MOHON='" & Cari & "'"
        MySTRsql1 = "SELECT *," & _
                    "(select COUNT(SETUJU_NOMOR) from TRXN_SPKAS WHERE SETUJU_POS=0 AND  SETUJU_NOMOR=NOMOR) as mQty," & _
                    "(select MAX(SETUJU_USER ) from TRXN_SPKAS WHERE SETUJU_POS=0 AND  SETUJU_NOMOR=NOMOR) as mNama," & _
                    "(select MIN(SETUJU_ENTRY) from TRXN_SPKAS WHERE SETUJU_POS=0 AND  SETUJU_NOMOR=NOMOR) as mTgl " & _
                    "FROM TRXN_SPKAH WHERE NOMOR_SPK<>'099999' AND " & Cari & " ORDER BY NOMOR_SPK,TANGGAL_SETUJU"
        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadF = cmd.ExecuteReader()
            If MyRecReadF.HasRows = True Then
                While MyRecReadF.Read
                    mNoMohon = nSr(MyRecReadF("NOMOR_MOHON"))
                    mJudul = cari_kode_mohon(mNoMohon, "JUDUL", mLokasi)
                    ApprovalterakhirSiapa = Right(nSr(MyRecReadF("APPROVALCODE")), 1)

                    mAdaData = 0
                    If nSr(MyRecReadF("TANGGAL_PROSES")) = "" Then
                        'Validasi Melengkapi Data
                    ElseIf InStr(nSr(MyRecReadF("JUDUL")), "SETUJU") <> 0 And _
                           InStr(nSr(MyRecReadF("APPROVALCODEP")), ApprovalterakhirSiapa) = 0 Then
                        MySTRsql1 = "UPDATE TRXN_SPKAH SET STATUS=NULL,TANGGAL_SETUJU=NULL,NOMOR='',APPROVALCODEP='',JUDUL=REPLACE(JUDUL,'SETUJU','ENTRY') " & _
                                    "WHERE NOMOR_MOHON='" & mNoMohon & "' AND NOMOR='" & nSr(MyRecReadF("NOMOR")) & "' AND JUDUL='" & nSr(MyRecReadF("JUDUL")) & "'"
                        Call UpdateDatabase_Tabel(MySTRsql1, "")
                    Else
                        mJudulEdit = nSr(MyRecReadF("JUDUL"))
                        If InStr(mJudulEdit, "SETUJU") <> 0 Then
                            mJudulEdit = mJudul 'Entry
                        End If

                        If InStr(mJudul, "MELEBIHI MAKSIMAL") <> 0 Then
                            mNilaiCHange = nLg(MyRecReadF("CHANGE"))
                            mNilaiCHange1 = nLg(MyRecReadF("CHANGE1"))
                            mNilaiCHange2 = nLg(MyRecReadF("CHANGE2"))
                            mNilaiCHange3 = nLg(MyRecReadF("CHANGE3"))
                        ElseIf InStr(mJudul, "HARGA UNIT") <> 0 Then
                            mNilaiCHange = nSr(MyRecReadF("CHANGE"))
                            mTemp = Nilai_DataSPKC(nSr(MyRecReadF("NOMOR_SPK")), "SPK_Piutang", mLokasi)
                        ElseIf InStr(mJudul, "HARGA DISKON") <> 0 Then
                            mNilaiCHange1 = nSr(MyRecReadF("CHANGE1"))
                            mTemp = Nilai_DataSPKC(nSr(MyRecReadF("NOMOR_SPK")), "SPK_Potongan", mLokasi)
                        ElseIf InStr(mJudul, "PINDAH") <> 0 Then
                            mNilaiCHange = nSr(MyRecReadF("CHANGE"))
                            mNilaiCHange1 = nSr(MyRecReadF("CHANGE1"))
                        ElseIf InStr(mJudul, "SUBSIDI") <> 0 Then
                            mNilaiCHange2 = nSr(MyRecReadF("CHANGE2"))
                            mTemp = Nilai_DataSPKC(nSr(MyRecReadF("NOMOR_SPK")), "SPK_HrgADM", mLokasi)
                        ElseIf InStr(mJudul, "KOMISI") <> 0 Then
                            mNilaiCHange3 = nSr(MyRecReadF("CHANGE3"))
                            mTemp = Nilai_DataSPKC(nSr(MyRecReadF("NOMOR_SPK")), "SPK_Komisi", mLokasi)
                        ElseIf InStr(mJudul, "KOMISI") <> 0 Then
                            mNilaiCHange3 = nSr(MyRecReadF("CHANGE3"))
                            mTemp = Nilai_DataSPKC(nSr(MyRecReadF("NOMOR_SPK")), "SPK_Komisi", mLokasi)
                        Else
                            mNilaiCHange = nSr(MyRecReadF("CHANGE"))
                        End If

                        Call AddSaveDataSPKC(nSr(MyRecReadF("NOMOR_SPK")), mJudul, nSr(MyRecReadF("CHANGE")), TxtPetik(nSr(MyRecReadF("KETERANGAN"))), mLokasi, "ADD")

                        mAppvSPV = "NULL"
                        If nSr(MyRecReadF("mTgl")) <> "" Then
                            mAppvSPV = DtInSQL(MyRecReadF("mTgl"))
                        Else
                            mAppvSPV = DtInSQL(MyRecReadF("TANGGAL_SETUJU"))
                        End If

                        MySTRsql1 = "UPDATE TRXN_SPKC SET " & _
                                    "SPKC_CHANGE='" & mNilaiCHange & "'," & _
                                    "SPKC_CHANGE1='" & mNilaiCHange1 & "'," & _
                                    "SPKC_CHANGE2='" & mNilaiCHange2 & "'," & _
                                    "SPKC_CHANGE3='" & mNilaiCHange3 & "'," & _
                                    "SPKC_TEMP='" & mTemp & "'," & _
                                    "SPKC_INPUT =" & DtInSQL(MyRecReadF("TANGGAL_ENTRY")) & "," & _
                                    "SPKC_PROSES =" & DtInSQL(MyRecReadF("TANGGAL_PROSES")) & "," & _
                                    "SPKC_NILAITGL =" & DtInSQL(MyRecReadF("TANGGAL_SETUJU")) & "," & _
                                    "SPKC_SPVTGL =" & mAppvSPV & "," & _
                                    "SPKC_NAMA ='" & mJudulEdit & "' " & _
                                    "WHERE SPKC_NO='" & nSr(MyRecReadF("NOMOR_SPK")) & "' AND SPKC_NAMA='" & mJudul & "'"
                        If UpdateDatabase_Tabel(MySTRsql1, mLokasi) = 1 Then
                            '============================================================
                            If InStr(nSr(MyRecReadF("JUDUL")), "TOLAK") <> 0 Then
                                MySTRsql1 = "UPDATE TRXN_SPKAH SET STATUS=GETDATE() WHERE NOMOR_MOHON='" & mNoMohon & "' AND STATUS IS NULL AND NOMOR='" & nSr(MyRecReadF("NOMOR")) & "' AND JUDUL='" & nSr(MyRecReadF("JUDUL")) & "'"
                                Call UpdateDatabase_Tabel(MySTRsql1, "")

                            ElseIf InStr(nSr(MyRecReadF("JUDUL")), "MELEBIHI MAKSIMAL") <> 0 And _
                                   InStr(nSr(MyRecReadF("JUDUL")), "SETUJU") <> 0 And _
                                   InStr(nSr(MyRecReadF("APPROVALCODEP")), "3") <> 0 Then
                                Call GetData_Setuju_Maksimal_Diskon(mLokasi, nSr(MyRecReadF("NOMOR_SPK")), nSr(MyRecReadF("JUDUL")), mNoMohon, _
                                                                    mNilaiCHange, mNilaiCHange1, mNilaiCHange2, mNilaiCHange3, _
                                                                    nSr(MyRecReadF("KETERANGAN")), mJudulEdit)

                            ElseIf InStr(nSr(MyRecReadF("JUDUL")), "ALASAN DO/ISI NOMOR RANGKA") <> 0 And _
                                   InStr(nSr(MyRecReadF("JUDUL")), "SETUJU") <> 0 Then
                                If GetData_Setuju_DO(mLokasi, mNilaiCHange, mNoMohon, nSr(MyRecReadF("NOMOR_SPK"))) = 1 Then
                                    Call CreateWorkOrderAksesoris(mLokasi, nSr(MyRecReadF("NOMOR_SPK")))
                                End If

                            ElseIf InStr(nSr(MyRecReadF("JUDUL")), "WAKTU UANG MUKA") <> 0 And _
                                   InStr(nSr(MyRecReadF("JUDUL")), "SETUJU") <> 0 Then
                                Call GetData_Setuju_PerpajangUangMuka(mLokasi, nSr(MyRecReadF("NOMOR_SPK")), mNoMohon, nSr(MyRecReadF("CHANGE")))

                            ElseIf (InStr(nSr(MyRecReadF("JUDUL")), "HARGA UNIT") <> 0 Or _
                                    InStr(nSr(MyRecReadF("JUDUL")), "HARGA DISKON") <> 0 Or _
                                    InStr(nSr(MyRecReadF("JUDUL")), "KOMISI") <> 0 Or _
                                    InStr(nSr(MyRecReadF("JUDUL")), "SUBSIDI") <> 0) _
                                    And InStr(nSr(MyRecReadF("JUDUL")), "WKWK SETUJU") <> 0 Then
                                Call GetData_Setuju_Perubahan_Harga(mLokasi, nSr(MyRecReadF("NOMOR_SPK")), nSr(MyRecReadF("JUDUL")), nSr(MyRecReadF("CHNAGE")), mNoMohon)

                            ElseIf InStr(nSr(MyRecReadF("JUDUL")), "ENTRY ALASAN PEMBUATAN FAKTUR") <> 0 And _
                                   InStr(nSr(MyRecReadF("JUDUL")), "SETUJU") <> 0 Then

                            ElseIf InStr(nSr(MyRecReadF("JUDUL")), "CANCEL SPK") <> 0 And _
                                   InStr(nSr(MyRecReadF("JUDUL")), "SETUJU") <> 0 Then
                                Call GetData_Setuju_Batal_SPK(mLokasi, nSr(MyRecReadF("NOMOR_SPK")), mNoMohon)
                            Else
                                If FindSaveDataSPKC(nSr(MyRecReadF("NOMOR_SPK")), mJudul, nSr(MyRecReadF("CHANGE")), TxtPetik(nSr(MyRecReadF("KETERANGAN"))), mLokasi) = 1 Then
                                    MySTRsql1 = "UPDATE TRXN_SPKAH SET STATUS=GETDATE() WHERE NOMOR_MOHON='" & mNoMohon & "' AND STATUS IS NULL"
                                    Call UpdateDatabase_Tabel(MySTRsql1, "")
                                End If
                            End If
                        End If
                    End If
                End While
            End If
            MyRecReadF.Close()
            cmd.Dispose()
            cnn.Close()
            If mInst = "1" Then
                Call GetData_Permohon_Persetujuan_Sudah_diSetuju_B(mLokasi)
            End If
            GetData_Permohon_Persetujuan_Sudah_diSetuju = 1
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function UpdateSTJ_Dan_lainNya(ByVal mfDealer As String) As Byte
        UpdateSTJ_Dan_lainNya = 0

        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mError As String
        Dim mNilai As String

        MySTRsql1 = "SELECT * FROM TRXN_SPKAH WHERE JUDUL like 'STJ%DO/ISI NOMOR RANGKA%' AND CABANG='" & mfDealer & "' ORDER BY NOMOR_SPK"
        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                While MyRecReadB.Read
                    mError = ""
                    MySTRsql1 = "SELECT COUNT(NOMOR_MOHON) as IsiField FROM TRXN_SPKAH WHERE (JUDUL like 'STJ%DO/ISI NOMOR RANGKA%') AND NOMOR_MOHON='" & nSr(MyRecReadB("NOMOR_MOHON")) & "' GROUP BY NOMOR_MOHON"
                    mNilai = GetDataD_IsiField(MySTRsql1, "")
                    If nLg(mNilai) > 1 Then
                        mError = "JANGAN"
                    End If

                    MySTRsql1 = "SELECT * FROM TRXN_SPK WHERE SPK_TGLDO IS NOT NULL AND SPK_NO='" & nSr(MyRecReadB("NOMOR_SPK")) & "'"
                    If GetDataD_00NoFound01Found(MySTRsql1, mfDealer) = 1 Then
                        mError = "SUDAH DO"
                    ElseIf mError <> "JANGAN" Then
                        MySTRsql1 = "SELECT SPKCANCEL_NO FROM TRXN_SPKCANCEL WHERE SPKCANCEL_NO='" & nSr(MyRecReadB("NOMOR_SPK")) & "'"
                        If GetDataD_00NoFound01Found(MySTRsql1, mfDealer) <> 1 Then
                            mError = "SETUJU"
                        End If
                    End If

                    If Not (mError = "" Or mError = "JANGAN") Then
                        MySTRsql1 = "UPDATE TRXN_SPKAH SET STATUS=NULL, JUDUL = '" & mError & " ALASAN DO/ISI NOMOR RANGKA' WHERE " & _
                                    "CABANG='" & mfDealer & "' AND " & _
                                    "JUDUL = '" & nSr(MyRecReadB("JUDUL")) & "' AND " & _
                                    "NOMOR_MOHON='" & nSr(MyRecReadB("NOMOR_MOHON")) & "'"
                        Call UpdateDatabase_Tabel(MySTRsql1, "")
                    End If
                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()

            MySTRsql1 = "UPDATE TRXN_SPKAH SET STATUS=NULL WHERE " & _
                        "CABANG='" & mfDealer & "' AND JUDUL = 'SETUJU ALASAN DO/ISI NOMOR RANGKA' AND " & _
                        "(STATUS IS NOT NULL) AND (CHANGE4='' OR CHANGE4 IS NULL) AND " & _
                        "DATEDIFF(DAY,STATUS,'2017-07-17 00:00:00') <= 0"
            'Call ExecuteSQLServerSales2(MySTRsql1, 5, 1, 1)
            UpdateSTJ_Dan_lainNya = 1
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function cari_kode_mohon(ByVal mNomorMohon As String, ByVal mTipe As String, ByVal mServer As String) As String
        Dim mMohon1 As String
        Dim MySTRsql1 As String
        mMohon1 = ""
        cari_kode_mohon = ""
        If mTipe = "JUDUL" Then
            MySTRsql1 = "SELECT * FROM DATA_PARAMETER WHERE PARAMETER_NAMA like 'APPRVC%'"
            mMohon1 = Cari_kode_mohon2(MySTRsql1, mNomorMohon, mServer)
            If mMohon1 <> "" Then
                MySTRsql1 = "SELECT PARAMETER_NILAI AS IsiField FROM DATA_PARAMETER WHERE PARAMETER_NAMA LIKE '" & mMohon1 & "%'"
                cari_kode_mohon = GetDataD_IsiField(MySTRsql1, mServer)
            End If
        Else
            'Cari Kode

            MySTRsql1 = "SELECT * FROM DATA_PARAMETER WHERE PARAMETER_NAMA like 'APPRVL%' AND PARAMETER_NILAI LIKE '%" & mNomorMohon & "%'"
            mMohon1 = Cari_kode_mohon3(MySTRsql1, mServer)
            If mMohon1 <> "" Then
                MySTRsql1 = "SELECT PARAMETER_NILAI AS IsiField FROM DATA_PARAMETER WHERE PARAMETER_NAMA LIKE '%" & mMohon1 & "%'"
                cari_kode_mohon = GetDataD_IsiField(MySTRsql1, mServer)
            End If
        End If
    End Function
    Function Cari_kode_mohon2(ByVal mSqlText As String, ByVal mpNomorMohon As String, ByVal mServer As String) As String
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Cari_kode_mohon2 = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlText, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If (MyRecReadA.HasRows = True) Then
                While MyRecReadA.Read()
                    If InStr(mpNomorMohon, nSr(MyRecReadA("PARAMETER_NILAI"))) <> 0 Then
                        Cari_kode_mohon2 = Replace(nSr(MyRecReadA("PARAMETER_NAMA")), "APPRVC", "APPRVL") & "0"
                    End If
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 0)
        End Try

    End Function
    Function Cari_kode_mohon3(ByVal mSqlText As String, ByVal mServer As String) As String
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Cari_kode_mohon3 = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlText, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If (MyRecReadA.HasRows = True) Then
                While MyRecReadA.Read()
                    Cari_kode_mohon3 = Mid(nSr(MyRecReadA("PARAMETER_NAMA")), 1, 8)
                    Cari_kode_mohon3 = Replace(Cari_kode_mohon3, "APPRVL", "APPRVC")
                End While
            End If

            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 0)
        End Try

    End Function

    Function GetData_Setuju_Maksimal_Diskon(ByVal mpServer As String, _
                                            ByVal mpNoSPK As String, _
                                            ByVal mpJudul As String, _
                                            ByVal mpNoMohon As String, _
                                            ByVal mpNilaiCHange As String, _
                                            ByVal mpNilaiCHange1 As String, _
                                            ByVal mpNilaiCHange2 As String, _
                                            ByVal mpNilaiCHange3 As String, _
                                            ByVal mpKeterangan As String, _
                                            ByVal mpJudulEdit As String) As Byte
        GetData_Setuju_Maksimal_Diskon = 0
        Try
            MySTRsql1 = ""
            If nLg(mpNilaiCHange) >= 0 Then
                'MySTRsql1 = MySTRsql1 & "SPK_Piutang=" & nLg(mNilaiCHange) & ", "
            End If
            If nLg(mpNilaiCHange1) >= 0 Then
                MySTRsql1 = MySTRsql1 & "SPK_Potongan=" & nLg(mpNilaiCHange1) & ", "
            End If
            If nLg(mpNilaiCHange2) >= 0 Then
                MySTRsql1 = MySTRsql1 & "SPK_HrgADM=" & nLg(mpNilaiCHange2) & ", "
            End If
            If nLg(mpNilaiCHange3) >= 0 Then
                MySTRsql1 = MySTRsql1 & "SPK_Komisi=" & nLg(mpNilaiCHange3) & ", "
            End If

            MySTRsql1 = "UPDATE TRXN_SPK SET " & MySTRsql1 & " SPK_PROGRAM='A0' WHERE SPK_NO='" & mpNoSPK & "'"
            If UpdateDatabase_Tabel(MySTRsql1, mpServer) = 1 Then

                MySTRsql1 = "UPDATE TRXN_SPKC SET SPKC_NAMA ='" & Replace(mpJudul, "SETUJU", "SAVEMD") & "' " & _
                            "WHERE SPKC_NO='" & mpNoSPK & "' AND SPKC_NILAI='" & mpKeterangan & "' AND SPKC_NAMA='" & mpJudulEdit & "'"
                Call UpdateDatabase_Tabel(MySTRsql1, mpServer)

                MySTRsql1 = "UPDATE TRXN_SPKC SET SPKC_NAMA =REPLACE(SPKC_NAMA,'ENTRY','SAVEMD') WHERE " & _
                            "SPKC_NO='" & mpNoSPK & "' AND " & _
                            "SPKC_NAMA LIKE '%ENTRY%' AND " & _
                            "(SPKC_NAMA LIKE '%HARGA DISKON%' OR " & _
                            " SPKC_NAMA LIKE '%KOMISI%' OR SPKC_NAMA LIKE '%SUBSIDI%')"
                Call UpdateDatabase_Tabel(MySTRsql1, mpServer)
                'Melebihi diskon
                MySTRsql1 = "UPDATE TRXN_SPKAH SET STATUS=GETDATE() WHERE NOMOR_MOHON='" & mpNoMohon & "' AND STATUS IS NULL"
                Call UpdateDatabase_Tabel(MySTRsql1, "")
            End If
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetData_Setuju_DO(ByVal mServer As String, _
                               ByVal mpNilaiCHange As String, _
                               ByVal mpNoMohon As String, _
                               ByVal mpNoSPK As String) As Byte
        GetData_Setuju_DO = 0
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand


        Dim merrordo As String = ""
        MySTRsql1 = "SELECT * , " & _
                    "(SELECT DBNOTAINT_NORANGKA FROM TRXN_DBNOTAINTERNAL WHERE DBNOTAINT_NORANGKA=STOCK_NORANGKA)  AS mfCrossSell, " & _
                    "(SELECT SPK_NORANGKA       FROM TRXN_SPK WHERE STOCK_NORANGKA=SPK_NORANGKA) AS mfSPKNoRangka, " & _
                    "(SELECT SPK_NO             FROM TRXN_SPK WHERE STOCK_NORANGKA=SPK_NORANGKA) AS mfSPKNoSPK, " & _
                    "(SELECT SPK_TGLDO          FROM TRXN_SPK WHERE STOCK_NORANGKA=SPK_NORANGKA) AS mfSPKTglDO," & _
                    "(SELECT STOCKF_NOSPK FROM TRXN_STOCKFAKTUR WHERE STOCKF_NORANGKA=STOCK_NORANGKA) as mFldSPKFaktur," & _
                    "(SELECT STOCKF_INPUTH3S FROM TRXN_STOCKFAKTUR WHERE STOCKF_NORANGKA=STOCK_NORANGKA) as mFldSPKH3S," & _
                    "(SELECT STOCKF_BATALH3S FROM TRXN_STOCKFAKTUR WHERE STOCKF_NORANGKA=STOCK_NORANGKA) as mFldSPKFakturBATAL " & _
                    "FROM TRXN_STOCK WHERE STOCK_NORANGKA='" & mpNilaiCHange & "'"
        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                If MyRecReadB.Read Then
                    If nSr(MyRecReadB("mfCrossSell")) <> "" Then
                        merrordo = "RANGKA INI SEDANG DI CROSS SELL ANTAR MUGEN "
                    ElseIf nSr(MyRecReadB("mfSPKTglDO")) <> "" And nSr(MyRecReadB("mfSPKNoSPK")) <> nSr(mpNoSPK) Then
                        merrordo = "RANGKA INI SDH DO SPK " & nSr(MyRecReadB("mfSPKNoSPK"))
                    ElseIf nSr(MyRecReadB("mfSPKNoRangka")) <> "" And _
                          nSr(MyRecReadB("mfSPKNoSPK")) <> nSr(mpNoSPK) Then
                        merrordo = "RANGKA INI SDG DIPESAN SPK " & nSr(MyRecReadB("mfSPKNoSPK"))
                    ElseIf nSr(MyRecReadB("mFldSPKFakturBATAL")) = "" And _
                        nSr(MyRecReadB("mFldSPKH3S")) <> "" And nSr(MyRecReadB("mFldSPKFaktur")) <> nSr(mpNoSPK) Then
                        merrordo = "SDH FAKTUR H3S OLEH SPK " & IIf(nSr(MyRecReadB("mFldSPKFaktur")) = "", "SPK FIKTIF", nSr(MyRecReadB("mFldSPKFaktur"))) & " "
                    ElseIf nSr(MyRecReadB("STOCK_NoIndent")) = "1" Then
                        If nSr(MyRecReadB("STOCK_BlockPickup")) = "2" Then
                            merrordo = "RANGKA INI SDG DIALOKASIKAN UNTUK MUGEN " & If(mServer = "112", "128", "112")
                        Else
                            merrordo = "RANGKA INI SDG PROSES RETURN (CALL ADMIN)"
                        End If
                    ElseIf nSr(MyRecReadB("mfSPKNoRangka")) = "" Or _
                           nSr(MyRecReadB("mfSPKNoSPK")) = nSr(mpNoSPK) Then
                        merrordo = GetData_Setuju_DOA(mServer, mpNoSPK, nSr(MyRecReadB("STOCK_CDTYPE")), nSr(MyRecReadB("STOCK_CDWARNA")), mpNoMohon)
                    End If
                Else
                    merrordo = "RANGKA INI TDK ADA DI STOK"
                End If

                If merrordo = "" Then
                    MySTRsql1 = "UPDATE TRXN_SPK SET SPK_NORANGKA='" & mpNilaiCHange & "' WHERE SPK_NO='" & nSr(mpNoSPK) & "'"
                    If UpdateDatabase_Tabel(MySTRsql1, mServer) = 1 Then

                        Dim mNODO As String = GetdataA_AddNomor("VOUCHER_NODO", 6, lblDealer.Text) 'AddNomor("VOUCHER_NODO", 6)

                        If mNODO <> "" Then
                            MySTRsql1 = "UPDATE TRXN_SPK SET SPK_NODO='" & mNODO & "',SPK_TGLDO=GETDATE() WHERE SPK_NO='" & nSr(mpNoSPK) & "'"
                            Call UpdateDatabase_Tabel(MySTRsql1, mServer)

                            MySTRsql1 = "UPDATE TRXN_SPKC SET SPKC_NAMA =REPLACE(SPKC_NAMA,'ENTRY','SAVEMD') WHERE " & _
                                        "SPKC_NO='" & nSr(mpNoSPK) & "' AND " & _
                                        "SPKC_NAMA LIKE '%ENTRY ALASAN DO/ISI NOMOR RANGKA%'"
                            Call UpdateDatabase_Tabel(MySTRsql1, mServer)
                            'DO
                            MySTRsql1 = "UPDATE TRXN_SPKAH SET STATUS=GETDATE(),CHANGE4='" & mNODO & "' WHERE NOMOR_MOHON='" & mpNoMohon & "' AND STATUS IS NULL"
                            Call UpdateDatabase_Tabel(MySTRsql1, "")
                            GetData_Setuju_DO = 1

                        End If
                    End If
                ElseIf merrordo <> "SPK INI TIDAK ADA DI MUGEN" Then
                    MySTRsql1 = "DELETE FROM TRXN_SPKAHERR WHERE SPKAHERR_NOM='" & mpNoMohon & "'"
                    Call UpdateDatabase_Tabel(MySTRsql1, "")
                    MySTRsql1 = "INSERT INTO TRXN_SPKAHERR (SPKAHERR_NOM,SPKAHERR_DESC,SPKAHERR_DESCR) VALUES ('" & mpNoMohon & "','" & TxtPetik(merrordo) & "','" & TxtPetik(merrordo) & "')"
                    Call UpdateDatabase_Tabel(MySTRsql1, "")
                End If
                '============================================================
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetData_Setuju_DOA(ByVal mfServer As String, _
                                ByVal mfNoSPK As String, _
                                ByVal mfTipe As String, _
                                ByVal mfWarna As String, _
                                ByVal mfNoMohon As String) As String
        GetData_Setuju_DOA = ""
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mfServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        MySTRsql1 = "SELECT * ," & _
                    "(SELECT SPKCANCEL_NO FROM TRXN_SPKCANCEL WHERE SPKCANCEL_NO=SPK_NO)  AS mfSPKCANCEL " & _
                    "FROM TRXN_SPK WHERE SPK_NO='" & Trim(nSr(mfNoSPK)) & "'"
        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadC = cmd.ExecuteReader()
            If MyRecReadC.HasRows = True Then
                If MyRecReadC.Read Then
                    If nSr(MyRecReadC("mfSPKCANCEL")) <> "" Then
                        GetData_Setuju_DOA = GetData_Setuju_DOA & "SPK INI SUDAH DIBATALKAN"
                    End If
                    If nSr(MyRecReadC("SPK_CDTYPE")) <> mfTipe Then
                        GetData_Setuju_DOA = GetData_Setuju_DOA & "TIPE SPK TDK SAMA STOK "
                    End If
                    If nSr(MyRecReadC("SPK_CDWARNA")) <> mfWarna Then
                        GetData_Setuju_DOA = GetData_Setuju_DOA & "WARNA SPK TDK SAMA STOK "
                    End If
                    If nSr(MyRecReadC("SPK_NODO")) <> "" Then
                        GetData_Setuju_DOA = GetData_Setuju_DOA & "SPK INI SUDAH DO "
                        MySTRsql1 = "UPDATE TRXN_SPKC SET SPKC_NAMA =REPLACE(SPKC_NAMA,'ENTRY','SAVEMD') WHERE " & _
                                    "SPKC_NO='" & nSr(mfNoSPK) & "' AND " & _
                                    "SPKC_NAMA LIKE '%ENTRY ALASAN DO/ISI NOMOR RANGKA%'"
                        Call UpdateDatabase_Tabel(MySTRsql1, mfServer)
                        'DO
                        MySTRsql1 = "UPDATE TRXN_SPKAH SET STATUS=GETDATE(),CHANGE4='" & nSr(MyRecReadC("SPK_NODO")) & "' WHERE NOMOR_MOHON='" & mfNoMohon & "' AND STATUS IS NULL"
                        Call UpdateDatabase_Tabel(MySTRsql1, "")
                    End If
                Else
                    GetData_Setuju_DOA = GetData_Setuju_DOA & "SPK INI TIDAK ADA DI MUGEN"
                End If
            Else
                GetData_Setuju_DOA = GetData_Setuju_DOA & "SPK INI TIDAK ADA DI MUGEN"
            End If
            MyRecReadC.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetData_Setuju_PerpajangUangMuka(ByVal mfServer As String, ByVal mfNospk As String, ByVal mfNomohon As String, ByVal mfChange As String) As Byte
        GetData_Setuju_PerpajangUangMuka = 0
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mfServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim mMasterUmur As Integer = 30
        MySTRsql1 = "SELECT * FROM TRXN_SPKCANCEL WHERE SPKCANCEL_NO='" & mfNospk & "'"

        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                If MyRecReadB.Read Then
                    If nLg(MyRecReadB("SPKCANCEL_UMUR")) <> 0 Then mMasterUmur = 0
                    MySTRsql1 = "UPDATE TRXN_SPKCANCEL SET SPKCANCEL_UMUR=ISNOLL(SPKCANCEL_UMUR,0)+" & (mMasterUmur + nLg(mfChange)) & " WHERE SPKCANCEL_NO='" & mfNospk & "'"
                    Call UpdateDatabase_Tabel(MySTRsql1, mfServer)
                End If
            End If
            MySTRsql1 = "UPDATE TRXN_SPKAH SET STATUS=GETDATE() WHERE NOMOR_MOHON='" & mfNomohon & "' AND STATUS IS NULL"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
            GetData_Setuju_PerpajangUangMuka = 1
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetData_Setuju_Perubahan_Harga(ByVal mfServer As String, _
                                            ByVal mfNOMOR_SPK As String, _
                                            ByVal mfJUDUL As String, _
                                            ByVal mfCHANGE As String, _
                                            ByVal mfNoMohon As String) As Byte
        GetData_Setuju_Perubahan_Harga = 0
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mfServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim mperrordo As String = ""

        MySTRsql1 = "SELECT * FROM TRXN_SPK WHERE SPK_NO='" & nSr(mfNOMOR_SPK) & "'"
        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                If MyRecReadB.Read Then
                    If nSr(MyRecReadB("SPK_TGLDO")) <> "" Then
                        mperrordo = mperrordo & ",SUDAH DO TDK BISA DIRUBAH"
                    End If
                    Dim mErrorMaksimalDisc As String = "DONT SHOW"
                    Dim mHargaUnit As Double = nLg(MyRecReadB("SPK_PIUTANG"))
                    Dim mHargaDisc As Double = nLg(MyRecReadB("SPK_POTONGAN"))
                    Dim mHargaSubs As Double = nLg(MyRecReadB("SPK_KOMISI"))
                    Dim mHargaKoms As Double = nLg(MyRecReadB("SPK_HRGADM"))

                    If InStr(nSr(mfJUDUL), "HARGA UNIT") <> 0 Then
                        mHargaUnit = nLg(mfCHANGE)
                    ElseIf InStr(nSr(mfJUDUL), "HARGA DISKON") <> 0 Then
                        mHargaDisc = nLg(mfCHANGE)
                    ElseIf InStr(nSr(mfJUDUL), "SUBSIDI") <> 0 Then
                        mHargaSubs = nLg(mfCHANGE)
                    ElseIf InStr(nSr(mfJUDUL), "KOMISI") <> 0 Then
                        mHargaKoms = nLg(mfCHANGE)
                    End If
                    Dim mDiffHrgSPK As Double = 0

                    If check_Makdiskon(mHargaUnit, mHargaDisc, mHargaKoms, mHargaSubs, _
                                       "", nSr(MyRecReadB("SPK_CDTYPE")), nSr(MyRecReadB("SPK_TGLDO")), nSr(MyRecReadB("SPK_TGLSPK")), nSr(MyRecReadB("SPK_NO")), nSr(MyRecReadB("SPK_NORANGKA")), nSr(MyRecReadB("SPK_TAHUN")), nSr(MyRecReadB("SPK_NAMA1")), mErrorMaksimalDisc, mDiffHrgSPK) = 0 Then
                        mperrordo = mperrordo & "," & mErrorMaksimalDisc & " "
                    End If

                    If mperrordo = "" Then
                        If InStr(nSr(mfJUDUL), "HARGA UNIT") <> 0 Then
                            MySTRsql1 = "UPDATE TRXN_SPK SET SPK_PIUTANG=" & "" & " WHERE SPK_NO='" & mfNOMOR_SPK & "'"
                        ElseIf InStr(nSr(mfJUDUL), "HARGA DISKON") <> 0 Then
                            MySTRsql1 = "UPDATE TRXN_SPK SET SPK_POTONGAN=" & "" & " WHERE SPK_NO='" & mfNOMOR_SPK & "'"
                        ElseIf InStr(nSr(mfJUDUL), "SUBSIDI") <> 0 Then
                            MySTRsql1 = "UPDATE TRXN_SPK SET SPK_HRGADM=" & "" & " WHERE SPK_NO='" & mfNOMOR_SPK & "'"
                        ElseIf InStr(nSr(mfJUDUL), "KOMISI") <> 0 Then
                            MySTRsql1 = "UPDATE TRXN_SPK SET SPK_KOMISI=" & "" & " WHERE SPK_NO='" & mfNOMOR_SPK & "'"
                        End If
                        If UpdateDatabase_Tabel(MySTRsql1, mfServer) = 1 Then
                            mperrordo = Replace(mfJUDUL, "SETUJU", "ENTRY")
                            MySTRsql1 = "UPDATE TRXN_SPKC SET SPKC_NAMA =REPLACE(SPKC_NAMA,'ENTRY','SAVESY') WHERE " & _
                                        "SPKC_NO='" & mfNOMOR_SPK & "' AND " & _
                                        "SPKC_NAMA LIKE '%" & mperrordo & "%'"
                            Call UpdateDatabase_Tabel(MySTRsql1, mfServer)
                            'Rubah Harga
                            MySTRsql1 = "UPDATE TRXN_SPKAH SET STATUS=GETDATE() WHERE NOMOR_MOHON='" & mfNoMohon & "' AND STATUS IS NULL"
                            Call UpdateDatabase_Tabel(MySTRsql1, "")
                        End If

                    Else
                        MySTRsql1 = "UPDATE TRXN_SPKAH SET JUDUL=REPLACE(JUDUL,'SETUJU','ENTRY') WHERE NOMOR_MOHON='" & mfNoMohon & "' AND STATUS IS NULL AND JUDUL like '%" & mfJUDUL & "%'"
                        Call UpdateDatabase_Tabel(MySTRsql1, "")
                        MySTRsql1 = "DELETE FROM TRXN_SPKAHERR WHERE SPKAHERR_NOM='" & mfNoMohon & "'"
                        Call UpdateDatabase_Tabel(MySTRsql1, "")
                        MySTRsql1 = "INSERT INTO TRXN_SPKAHERR (SPKAHERR_NOM,SPKAHERR_DESC,SPKAHERR_DESCR) VALUES ('" & mfNoMohon & "','" & TxtPetik(mperrordo) & "','" & TxtPetik(mperrordo) & "')"
                        Call UpdateDatabase_Tabel(MySTRsql1, "")
                    End If
                End If
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function check_Makdiskon( _
                 ByVal mfHargaUnit As Double, ByVal mfDisc As Double, ByVal mfKoms As Double, ByVal mfSubs As Double, _
                 ByVal mfPaket As String, ByVal mfType As String, _
                 ByVal mfTglDO As String, ByVal mfTglSPK As String, _
                 ByVal mfNOSPK As String, ByVal mfNORANGKA As String, _
                 ByVal mfTahun As String, ByVal mfNama As String, ByRef mfErrorMsg As String, ByRef mfDiffHrg As String) As Double
        Dim mNilai As String
        Dim mPembanding As Double
        Dim mMaxDisc As Double
        Dim mMaxDiff As Double
        Dim mShowError As String
        mShowError = mfErrorMsg

        mNilai = "" : check_Makdiskon = 0 : mMaxDisc = 0 : mMaxDiff = 0 : mfErrorMsg = ""
        mPembanding = (nDb(mfDisc) + nDb(mfKoms) - nDb(mfSubs))
        If mfTglSPK = "" Then Exit Function
        If mfPaket <> "" Then
            '**Error
            check_Makdiskon = 1 : Exit Function
        End If
        mMaxDiff = GETType_Differeny_Web_Mail(mfType, mfNORANGKA, mfTahun, mfTglSPK, Month(CDate(mfTglSPK)))
        If check_Makdiskon <> 1 Then
            If mfTglDO = "" Then
                mMaxDisc = GETType_MakDiscount_Web_Mail(mfType, mfNORANGKA, mfTahun, mfTglSPK, Month(CDate(mfTglSPK)))
            Else
                mMaxDisc = GETType_MakDiscount_Web_Mail(mfType, mfNORANGKA, mfTahun, mfTglSPK, Month(CDate(Now())))
            End If
            If mPembanding > (mMaxDisc + mMaxDiff) Then
                check_Makdiskon = 0
            Else
                check_Makdiskon = 1
            End If
        End If
        If check_Makdiskon <> 1 Then
            If mShowError = "" Then
                'MsgBox("TOTAL DARI (POTONGAN+SUBSIDI+KOMISI) = Rp." & fDb(mPembanding) & " TDK BOLEH LBH DARI MAX Rp." & fDb(mMaxDisc))
            Else
                mfErrorMsg = "TOTAL(POTONGAN+SUBSIDI+KOMISI)=Rp." & nDb(mPembanding) & " LBH DARI (MAX+Selisi Harga) Rp." & nDb(mMaxDisc) & "+ Rp." & nDb(mMaxDiff)
                'mfErrorMsg = "TOTAL(POTONGAN+SUBSIDI+KOMISI)=Rp." & fDb(mPembanding) & " LBH DARI (Diskon Standard Mugen+Selisi Harga) "
            End If
        ElseIf mfHargaUnit <= 50000000 And InStr(mfNama, "HONDA") = 0 Then
            check_Makdiskon = 0
            If mShowError = "" Then
                'MsgBox("HARGA UNIT BELUM DIISI DENGAN BENAR")
            Else
                mfErrorMsg = "HARGA UNIT BELUM DIISI DENGAN BENAR"
            End If
        End If
    End Function
    Function GETType_MakDiscount_Web_Mail(ByVal mfType As String, ByVal mfRangka As String, ByVal mfTahun As String, ByVal mfTgl As String, ByVal mBln As Byte) As Double
        Dim mCriteria As String
        Dim mTahun As String
        Dim mTambahTahun As Byte = 0
        Call DescRangka(mfRangka)
        GETType_MakDiscount_Web_Mail = 0
        mCriteria = "" : mTahun = ""
        If mfRangka <> "" Then
            mCriteria = "TYPED_RANGKA LIKE '%" & Mid(mfRangka, 4, 8) & "%'"
        Else
            mCriteria = ""
            mCriteria = GetDataD_IsiField("SELECT TYPE_CdRangka AS IsiField FROM DATA_TYPE WHERE TYPE_Type='" & mfType & "'", lblDealer.Text)


            If Val(mfTahun) >= 10 Then
                mTambahTahun = 0
                If Val(mfTahun) >= 18 Then mTambahTahun = 1
                mTahun = Mid("ABCDEFGHIJKLMNOPQRSTUVWXYZ", (Val(mfTahun) + mTambahTahun) - 9, 1)
            End If
            If mCriteria <> "" Then
                'mCriteria = mCriteria & Mid("???????", 1, 7 - Len(mCriteria)) & mTahun
                mCriteria = mCriteria & Mid("_______", 1, 6 - Len(mCriteria)) & mTahun
            Else
                mCriteria = "???????" & mTahun
            End If
            mCriteria = "TYPED_RANGKA LIKE '%" & mCriteria & "%'"
        End If

        GETType_MakDiscount_Web_Mail = nLg(GetDataD_IsiField("SELECT TYPED_Jumlah AS IsiField FROM DATA_TYPED,DATA_TYPE WHERE  TYPED_TYPE=TYPE_TYPE AND TYPED_TYPE = '" & mfType & "' AND " & mCriteria & " AND DATEDIFF(DAY,TYPED_TANGGAL," & DtInSQL(mfTgl) & ") >= 0 ORDER BY TYPED_TANGGAL DESC", lblDealer.Text))

    End Function
    Function GETType_Differeny_Web_Mail(ByVal mfType As String, ByVal mfRangka As String, ByVal mfTahun As String, ByVal mfTgl As String, ByVal mBln As Byte) As Double
        Dim mCriteria As String
        Dim mTahun As String
        Dim mTambahTahun As Byte = 0
        Call DescRangka(mfRangka)
        GETType_Differeny_Web_Mail = 0
        mCriteria = "" : mTahun = ""
        If mfRangka <> "" Then
            mCriteria = "TYPED_RANGKA LIKE '%" & Mid(mfRangka, 4, 8) & "%'"
        Else
            mCriteria = ""
            mCriteria = GetDataD_IsiField("SELECT TYPE_CdRangka AS IsiField FROM DATA_TYPE WHERE TYPE_Type='" & mfType & "'", lblDealer.Text)

            If Val(mfTahun) >= 10 Then
                mTambahTahun = 0
                If Val(mfTahun) >= 18 Then mTambahTahun = 1
                mTahun = Mid("ABCDEFGHIJKLMNOPQRSTUVWXYZ", (Val(mfTahun) + mTambahTahun) - 9, 1)
            End If
            If mCriteria <> "" Then
                'mCriteria = mCriteria & Mid("_______", 1, 6 - Len(mCriteria)) & mTahun
                mCriteria = mCriteria & Mid("???????", 1, 7 - Len(mCriteria)) & mTahun
            Else
                mCriteria = "???????" & mTahun
            End If
            mCriteria = "TYPED_RANGKA LIKE '%" & mCriteria & "%'"
        End If
        mCriteria = Replace(mCriteria, "TYPED_", "TYPESH_")

        Dim mNilai As String = GetDataD_IsiField("SELECT TYPESH_Jumlah AS IsiField FROM DATA_TYPESH,DATA_TYPE WHERE  TYPESH_TYPE=TYPE_TYPE AND TYPESH_TYPE = '" & mfType & "' AND " & mCriteria & " AND DATEDIFF(DAY," & DtInSQL(mfTgl) & ",TYPESH_TANGGAL) >= 0 ORDER BY TYPESH_TANGGAL DESC", lblDealer.Text)
        GETType_Differeny_Web_Mail = nLg(mNilai)

    End Function
    Sub DescRangka(ByVal mRangka As String)
        mRk1 = "" : mRk2 = "" : mRk3 = "" : mRk4 = "" : mRk5 = "" : mRk6 = "" : mRk7 = "" : mRk8 = "" : mRk9 = "" : mRk0 = "" : mRk11 = ""
        If Len(mRangka) >= 15 Then
            'MHR -> CKD CBU -> MRH
            mRk1 = Mid(mRangka, 1, 1) ' Benua   M:Asia
            mRk2 = Mid(mRangka, 2, 1) ' Negara  H:Indonesia
            mRk3 = Mid(mRangka, 3, 1) ' Dealer  R:Honda Prospect
            mRk4 = Mid(mRangka, 4, 3) ' Type
            mRk5 = Mid(mRangka, 7, 1) ' Transmisi 1,3(Ganjil) MT 2,3(Genap) AT
            mRk6 = Mid(mRangka, 8, 1) ' Kode Mesin
            mRk7 = Mid(mRangka, 9, 1) ' Kode tetap 0
            mRk8 = Mid(mRangka, 10, 1) ' Tahun Model 2000/Y ..../1 /2  2010/A..../1/2
            mRk9 = Mid(mRangka, 11, 1) ' Kode Pabrik J:Jakarta K:Karawang
            mRk0 = Mid(mRangka, 12, 6) ' Nomor Pembuatan
        End If
    End Sub



    Function GetData_Setuju_Batal_SPK(ByVal mfServer As String, ByVal mNOMOR_SPK As String, ByVal mfNoMohon As String) As Byte
        GetData_Setuju_Batal_SPK = 0
        'MySTRsql1 = "INSERT INTO TRXN_SPKCANCEL (SPKCANCEL_NO,SPKCANCEL_ALASAN,SPKCANCEL_TGL,SPKCANCEL_NORANGKA,SPKCANCEL_USER) " & _
        '            "VALUES ('" & mNOMOR_SPK & "')"
        'Call UpdateDatabase_Tabel(MySTRsql1, mfServer)
        MySTRsql1 = "UPDATE TRXN_SPKAH SET STATUS=GETDATE() WHERE NOMOR_MOHON='" & mfNoMohon & "' AND STATUS IS NULL"
        Call UpdateDatabase_Tabel(MySTRsql1, "")
        GetData_Setuju_Batal_SPK = 1
    End Function

    Function AddSaveDataSPKC(ByVal mNOSPK As String, ByVal mNAMA As String, ByVal mCHANGE As String, ByVal mNILAI1 As String, ByVal mLokasi As String, ByVal mForWhat As String) As Byte
        If mForWhat = "ADD" Then
            Dim MySTRsql1 As String = "DELETE FROM TRXN_SPKC WHERE SPKC_NO='" & mNOSPK & "' AND SPKC_NAMA='" & mNAMA & "'"
            AddSaveDataSPKC = UpdateDatabase_Tabel(MySTRsql1, mLokasi)
            If AddSaveDataSPKC = 1 Then
                MySTRsql1 = "INSERT INTO TRXN_SPKC(SPKC_NO,SPKC_NAMA,SPKC_NILAI,SPKC_CHANGE,SPKC_NILAITGL,SPKC_INPUT,SPKC_PROSES,SPKC_ST) VALUES " & _
                            "('" & mNOSPK & "','" & mNAMA & "','" & mNILAI1 & "','" & mCHANGE & "',NULL,GETDATE(),GETDATE(),NULL)"
                AddSaveDataSPKC = UpdateDatabase_Tabel(MySTRsql1, mLokasi)
            End If
        End If
    End Function
    Function Nilai_DataSPKC(ByVal mNOSPK As String, ByVal mNAMA As String, ByVal mpSrvr As String) As String
        Nilai_DataSPKC = GetDataD_IsiField("SELECT " & mNAMA & " as IsiField FROM TRXN_SPK WHERE SPK_NO='" & mNOSPK & "'", mpSrvr)
    End Function

    Function GetData_Permohon_Persetujuan_Sudah_diSetuju_B(ByVal mServer As String) As Byte
        GetData_Permohon_Persetujuan_Sudah_diSetuju_B = 0
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mNilai As String = ""
        MySTRsql1 = "SELECT * FROM TRXN_SPKAH WHERE CABANG='" & mServer & "' AND " & _
                    "(SELECT COUNT(NOMOR_MOHON) FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON=TRXN_SPKAH.NOMOR_MOHON GROUP BY TRXN_SPKAD.NOMOR_MOHON) IS NOT NULL AND " & _
                    "(SELECT COUNT(NOMOR_MOHON) FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON=TRXN_SPKAH.NOMOR_MOHON AND TRXN_SPKAD.KETERANGAN='SPK_TGLCR' GROUP BY TRXN_SPKAD.NOMOR_MOHON) IS NULL"
        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                While MyRecReadB.Read
                    MySTRsql1 = "SELECT SPK_TGLSPK as IsiField FROM TRXN_SPK WHERE SPK_NO='" & nSr(MyRecReadB("NOMOR_SPK")) & "'"
                    mNilai = GetDataD_IsiField(MySTRsql1, mServer)
                    If mNilai <> "" Then
                        MySTRsql1 = "INSERT INTO TRXN_SPKAD(NOMOR_MOHON,KETERANGAN,NILAI) VALUES ('" & nSr(MyRecReadB("NOMOR_MOHON")) & "','SPK_TGLCR','" & DtFr(mNilai, "yyyy-MM-dd") & "')"
                        Call UpdateDatabase_Tabel(MySTRsql1, "")

                        MySTRsql1 = "SELECT SPK_TGLURT as IsiField FROM TRXN_SPK WHERE SPK_NO='" & nSr(MyRecReadB("NOMOR_SPK")) & "'"
                        mNilai = GetDataD_IsiField(MySTRsql1, mServer)
                        MySTRsql1 = "INSERT INTO TRXN_SPKAD(NOMOR_MOHON,KETERANGAN,NILAI) VALUES ('" & nSr(MyRecReadB("NOMOR_MOHON")) & "','SPK_TGLAP','" & DtFr(mNilai, "yyyy-MM-dd") & "')"
                        Call UpdateDatabase_Tabel(MySTRsql1, "")

                        MySTRsql1 = "SELECT SPK_CDTYPE as IsiField FROM TRXN_SPK WHERE SPK_NO='" & nSr(MyRecReadB("NOMOR_SPK")) & "'"
                        mNilai = GetDataD_IsiField("", mServer)
                        MySTRsql1 = "INSERT INTO TRXN_SPKAD(NOMOR_MOHON,KETERANGAN,NILAI) VALUES ('" & nSr(MyRecReadB("NOMOR_MOHON")) & "','SPK_CDTIPE','" & nSr(mNilai) & "')"
                        Call UpdateDatabase_Tabel(MySTRsql1, "")
                    End If
                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
            GetData_Permohon_Persetujuan_Sudah_diSetuju_B = 1
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function DtFr(ByRef mNilai As Object, ByRef mFormat As Object) As String
        DtFr = ""
        If Not IsDBNull(mNilai) Then
            DtFr = Microsoft.VisualBasic.Format(mNilai, mFormat)
        End If
    End Function

    Function FindSaveDataSPKC(ByVal mNOSPK As String, ByVal mNAMA As String, ByVal mTGLSETUJU As String, ByVal mNILAI1 As String, ByVal mlokasi As String) As Byte
        MySTRsql1 = "SELECT SPKC_NO FROM TRXN_SPKC WHERE SPKC_NO='" & mNOSPK & "' AND SPKC_NAMA='" & mNAMA & "' AND SPKC_NILAI='" & mNILAI1 & "' AND " & _
                    "SPKC_NILAITGL IS NOT NULL"
        FindSaveDataSPKC = GetDataD_00NoFound01Found(MySTRsql1, mlokasi)
    End Function
    Function InputDT(ByVal mYr As String, ByVal mMt As String, ByVal mDy As String, ByVal mHh As String, ByVal mMm As String, ByVal mSs As String, ByVal mDt As String) As Date
        If mDt <> "" And mYr = "" Then mYr = CStr(Year(CDate(mDt)))
        If mDt <> "" And mMt = "" Then mMt = CStr(Month(CDate(mDt)))
        If mDt <> "" And mDy = "" Then mDy = CStr(Microsoft.VisualBasic.Day(CDate(mDt)))
        If mDt <> "" And mHh = "" Then mHh = CStr(Hour(CDate(mDt)))
        If mDt <> "" And mMm = "" Then mMm = CStr(Minute(CDate(mDt)))
        If mDt <> "" And mSs = "" Then mSs = CStr(Second(CDate(mDt)))
        InputDT = New DateTime(mYr, mMt, mDy, mHh, mMm, mSs)
    End Function

    'S P J unit
    Function Update_Stock_Warehouse_Centralize(ByVal mRangka As String, ByVal mNOSPK As String, ByVal mTGLMOHON As String) As Byte
        Dim mIloop As Byte
        Dim mTxtErr As String
        Dim mTglServer As String
        Dim mFind As Byte
        Update_Stock_Warehouse_Centralize = 0
        mTxtErr = ""
        mIloop = 0 : mFind = 0 : mTglServer = ""
        mTglServer = GetDataD_IsiField("SELECT GETDATE() as IsiField FROM TRXN_STOCK,DATA_LOKASI,DATA_SUPLIER,DATA_TYPE,DATA_WARNA WHERE " & _
                                       "STOCK_CdLokasi=LOKASI_Kode AND " & _
                                       "STOCK_CdSuplier=SUPLIER_Kode AND " & _
                                       "STOCK_CdType=TYPE_Type AND " & _
                                "STOCK_CdWarna=WARNA_Kode AND " & _
                                "STOCK_NoRangka='" & mRangka & "'", "WAREHOUSE")
        If mTglServer = "" Then
            mTxtErr = "Nomor Rangka tersebut tidak ada digudang"
        Else
            mTxtErr = GetDataD_IsiField("SELECT STOCKM_TGLMOHONKIRIM as IsiField " & _
                                        "FROM TRXN_STOCKMKIRIM,TRXN_STOCK,DATA_LOKASI,DATA_SUPLIER,DATA_TYPE,DATA_WARNA " & _
                                        "WHERE " & _
                                        "STOCKM_NoRangka=STOCK_NoRangka AND " & _
                                        "STOCK_CdLokasi=LOKASI_Kode AND " & _
                                        "STOCK_CdSuplier=SUPLIER_Kode AND " & _
                                        "STOCK_CdType=TYPE_Type AND " & _
                                        "STOCK_CdWarna=WARNA_Kode AND " & _
                                        "STOCKM_NORANGKA='" & mRangka & "'", "WAREHOUSE")
            If mTxtErr <> "" Then
                mTxtErr = "SUDAH MENGAJUKAN PERMOHONAN KIRIM KENDARAAN TANGGAL " & mTxtErr
            End If
        End If
        If mTxtErr <> "" Then
            MsgBox(mTxtErr)
        Else
            Call Proses_input_Kirim_Warehouse(mRangka, "TglMohon", lblArea1.Text)
        End If
    End Function
    Function Proses_input_Kirim_Warehouse(ByVal mpNoRangka As String, ByVal mpTglMohon As String, ByVal mfServer As String) As Byte
        Proses_input_Kirim_Warehouse = 0
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mfServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mErrorku As String = ""
        MySTRsql1 = "SELECT * FROM TRXN_SPK,TRXN_SURAT,DATA_SALESMAN,DATA_LEASE WHERE " & _
                    "SURAT_SPK=SPK_NO AND SPK_CDSALES=SALES_KODE AND SPK_CDLEASE=LEASE_KODE AND SPK_NORANGKA='" & mpNoRangka & "'"

        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                If MyRecReadA.Read Then
                    Dim mErrorStatus As Byte
                    For mIloop = 1 To 12
                        Select Case mIloop
                            Case 1 : mErrorStatus = DeleteDataWarehouse_Kirim(mpNoRangka)
                            Case 2 : mErrorStatus = InsertDataWarehouse_Kirim(mpNoRangka, mpTglMohon, _
                                                    nSr(MyRecReadA("SPK_CdSales")) & " (" & nSr(MyRecReadA("SALES_Nama")) & ")", _
                                                    nSr(MyRecReadA("SALES_NOHP1")), _
                                                    nSr(MyRecReadA("SPK_CdLease")) & " (" & nSr(MyRecReadA("LEASE_Nama")) & ")")
                            Case 3 : mErrorStatus = InsertDataWarehouse_Alamat(mpNoRangka, _
                                                    nSr(MyRecReadA("SPK_NAMA1")), TxtPetik(MyRecReadA("SPK_Alamat")), nSr(MyRecReadA("SPK_Kota")), nSr(MyRecReadA("SPK_Phone")), Mid(nSr(MyRecReadA("SPK_FHP")), 1, 20), _
                                                    TxtPetik(nSr(MyRecReadA("SPK_Nama2"))), TxtPetik(nSr((MyRecReadA("SURAT_ALAMAT1"))) & nSr((MyRecReadA("SURAT_ALAMAT2")))), nSr(MyRecReadA("SURAT_KOTA")), nSr(MyRecReadA("SPK_Phone")), nSr(MyRecReadA("SURAT_NOHP")), "K/S")
                            Case 4 : mErrorStatus = UpdateDataWarehouse_KirimStock(mpNoRangka, nSr(MyRecReadA("SPK_NO")), nSr(MyRecReadA("SPK_NODO")), nSr(MyRecReadA("SPK_TGLDO")))
                            Case 5 : mErrorStatus = UpdateDataWarehouse_DoImora(mpNoRangka, nSr(MyRecReadA("STOCK_NOMESIN")))
                            Case 6 : mErrorStatus = UpdateDataWarehouse_KirimAksesoris(mpNoRangka, lblArea1.Text)
                            Case 7 : mErrorStatus = UpdateDataSPK(nSr(MyRecReadA("SPK_NO")), mpTglMohon)
                            Case 8 : mErrorStatus = UPDATE_STOCK(mpNoRangka, "NULL", mpTglMohon, "GETDATE()", mpTglMohon)
                            Case 10 : Call AddSaveDataSPKC_SPJ(nSr(MyRecReadA("SPK_NO")), "ENTRY ALASAN PERMOHONAN KIRIM UNIT KURANG 2 HARI", "", "", "SUDAH OK KIRIM UNIT KURANG 2 HARI", "UPDATE NAMA")
                            Case 11 : Call AddSaveDataSPKC_SPJ(nSr(MyRecReadA("SPK_NO")), "ENTRY ALASAN PERMOHONAN KIRIM UNIT KURANG 1 HARI", "", "", "SUDAH OK KIRIM UNIT KURANG 1 HARI", "UPDATE NAMA")
                            Case 12 : Call AddSaveDataSPKC_SPJ(nSr(MyRecReadA("SPK_NO")), "ENTRY ALASAN PERMOHONAN KIRIM BELUM LUNAS", "", "", "SUDAH OK KIRIM BELUM LUNAS", "UPDATE NAMA")
                        End Select
                        If mErrorStatus <> 1 Then
                            mErrorku = "PROSESS PENGIRIMAN DATA KE WAREHOUSE TIDAK BERHASIL ..." : Exit For
                        End If
                    Next
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function DeleteDataWarehouse_Kirim(ByVal mpRangka As String) As Byte
        MySTRsql1 = "DELETE FROM  TRXN_STOCKMKIRIM WHERE STOCKM_NORANGKA='" & mpRangka & "'"
        DeleteDataWarehouse_Kirim = UpdateDatabase_Tabel(MySTRsql1, "WARHOUSE")
        MySTRsql1 = "DELETE FROM  TRXN_STOCKAKIRIM WHERE STOCKA_NORANGKA='" & mpRangka & "'"
        DeleteDataWarehouse_Kirim = UpdateDatabase_Tabel(MySTRsql1, "WARHOUSE")
    End Function
    Function InsertDataWarehouse_Kirim(ByVal mpRangka As String, ByVal mpDTglkIRIMmohon As String, ByVal mpSales As String, ByVal mpHPSales As String, ByVal mpLease As String) As Byte
        MySTRsql1 = "INSERT INTO TRXN_STOCKMKIRIM " & _
                   "(STOCKM_NORANGKA,STOCKM_KDDEALER," & _
                   " STOCKM_TGLMOHONKIRIM,STOCKM_TGLMOHONINPUT,STOCKM_KIRIMTGLSETUJUI," & _
                   " STOCKM_BERITA,STOCKM_SALES,STOCKM_LEASE,STOCKM_USER,STOCKM_APPTGLDO,STOCKM_USRTGLDO) VALUES " & _
                   "('" & mpRangka & "','" & lblArea1.Text & "'," & _
                   "" & DtFrSQL((mpDTglkIRIMmohon)) & ",GETDATE(),NULL,'','" & mpSales & " HP:" & mpHPSales & "','" & Mid(mpLease, 1, 30) & "','WebApp',NULL,'')"
        InsertDataWarehouse_Kirim = UpdateDatabase_Tabel(MySTRsql1, "WARHOUSE")
    End Function
    Function InsertDataWarehouse_Alamat(ByVal mpRangka As String, _
             ByVal STOCKAKP_PNAMA As String, ByVal STOCKAKP_PALAMAT As String, ByVal STOCKAKP_PKOTA As String, ByVal STOCKAKP_PPH As String, ByVal STOCKAKP_PHP As String, _
             ByVal STOCKAKP_SNAMA As String, ByVal STOCKAKP_SALAMAT As String, ByVal STOCKAKP_SKOTA As String, ByVal STOCKAKP_SPH As String, ByVal STOCKAKP_SHP As String, ByVal STOCKAKP_STATUS As String) As Byte
        InsertDataWarehouse_Alamat = 0
        MySTRsql1 = "DELETE FROM TRXN_STOCKAKIRIMP WHERE STOCKAKP_NORANGKA='" & mpRangka & "'"
        Call UpdateDatabase_Tabel(MySTRsql1, "WARHOUSE")
        MySTRsql1 = "INSERT INTO TRXN_STOCKAKIRIMP " & _
                    "(STOCKAKP_NORANGKA," & _
                    " STOCKAKP_PNAMA,STOCKAKP_PALAMAT,STOCKAKP_PKOTA,STOCKAKP_PPH,STOCKAKP_PHP," & _
                    " STOCKAKP_SNAMA,STOCKAKP_SALAMAT,STOCKAKP_SKOTA,STOCKAKP_SPH,STOCKAKP_SHP," & _
                    " STOCKAKP_STATUS) VALUES " & _
                    "('" & mpRangka & "'," & _
                    "'," & STOCKAKP_PNAMA & "','" & STOCKAKP_PALAMAT & "','" & STOCKAKP_PKOTA & "','" & STOCKAKP_PPH & "','" & STOCKAKP_PHP & "'," & _
                    "'," & STOCKAKP_SNAMA & "','" & STOCKAKP_SALAMAT & "','" & STOCKAKP_SKOTA & "','" & STOCKAKP_SPH & "','" & STOCKAKP_SHP & "','" & STOCKAKP_STATUS & "')"
        'mfKirimKe= K/S
        InsertDataWarehouse_Alamat = UpdateDatabase_Tabel(MySTRsql1, "WARHOUSE")
    End Function
    Function UpdateDataWarehouse_KirimStock(ByVal mpRangka As String, ByVal mpNoSPK As String, ByVal mpNoDO As String, ByVal mpTglDO As String) As Byte
        MySTRsql1 = "UPDATE TRXN_STOCK SET " & _
                    "STOCK_NOSPK='" & mpNoSPK & "',STOCK_DoDealer='" & mpNoDO & "',STOCK_TglDoDealer=" & DtFrSQL((mpTglDO)) & "," & _
                    "STOCK_TglCtkDoDealer=NULL,STOCK_TglKirim=NULL,STOCK_TglTerima=NULL " & _
                    "WHERE STOCK_NoRangka='" & mpRangka & "'"
        UpdateDataWarehouse_KirimStock = UpdateDatabase_Tabel(MySTRsql1, "WARHOUSE")
    End Function
    Function UpdateDataWarehouse_KirimAksesoris(ByVal mpRangka As String, ByVal mfServer As String) As Byte
        UpdateDataWarehouse_KirimAksesoris = 0
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mfServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mTxtErrAsesoris As String
        mTxtErrAsesoris = ""

        MySTRsql1 = "UPDATE TRXN_STOCKAKSESORIS SET STOCKA_ALASAN='TDK DIORDER [PERIKSA]' WHERE STOCKA_NORANGKA='" & mpRangka & "' AND NOT (STOCKA_NOWO IS NULL OR STOCKA_NOWO='' OR STOCKA_NOWO='000000A')"
        Call UpdateDatabase_Tabel(MySTRsql1, "WARHOUSE")

        MySTRsql1 = "SELECT *," & _
                    "(SELECT SUPLIER_Nama FROM TRXN_OPTH,DATA_SUPLIER WHERE OPTH_CdSuplier=SUPLIER_Kode AND OPTH_NoWO=OPT_NoWO) AS mNamaSuplier," & _
                    "(SELECT SUPLIER_Nama FROM DATA_SUPLIER WHERE OPT_CdSuplier=SUPLIER_Kode) AS mNamaSuplier2," & _
                    "(SELECT SUM(IIF(ISNULL(OPTD_Harga),0,OPTD_Harga)) FROM TRXN_OPTD WHERE OPTD_NoWO = OPT_NoWO AND OPTD_CdAssesoris=OPT_CdAssesoris) AS mHrgSuplier  " & _
                    "FROM TRXN_OPT,TRXN_OPTH,DATA_STANDARD WHERE OPT_NOWO=OPTH_NOWO AND OPT_CdAssesoris=STANDARD_Kode AND " & _
                    "OPT_NORANGKA='" & mpRangka & "'"
        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadC = cmd.ExecuteReader()
            If MyRecReadC.HasRows = True Then
                If MyRecReadC.Read Then
                    If GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCKAKSESORIS WHERE STOCKA_NORANGKA='" & mpRangka & "' AND STOCKA_KDASS='" & MyRecReadC("OPT_CdAssesoris") & "'", "WAREHOUSE") <> 1 Then
                        MySTRsql1 = "INSERT INTO TRXN_STOCKAKSESORIS " & _
                                   "(STOCKA_NORANGKA,STOCKA_NOWO,STOCKA_KDASS,STOCKA_QTY,STOCKA_KDSUPLIER," & _
                                   " STOCKA_TGLWO,STOCKA_TGLSUPLIER,STOCKA_TGLPSG,STOCKA_TGLPSGI,STOCKA_BERITA,STOCKA_NAMA,STOCKA_ALASAN) VALUES " & _
                                   "('" & mpRangka & "','" & nSr(MyRecReadC("OPT_NoWO")) & "','" & nSr(MyRecReadC("STANDARD_Kode")) & "',1,'" & nSr(MyRecReadC("OPTH_CdSuplier")) & "'," & _
                                   FieldTgl(MyRecReadC("OPTH_Tglwo")) & "," & FieldTgl(MyRecReadC("OPTH_TglSendWO")) & ",NULL,NULL," & _
                                   "'" & nSr((MyRecReadC("OPT_Desc"))) & " ','" & nSr((MyRecReadC("OPTH_Keterangan"))) & "','')"
                        If UpdateDatabase_Tabel(MySTRsql1, "WARHOUSE") = 1 Then
                            MySTRsql1 = "UPDATE TRXN_OPTH SET OPTH_MOHONPASANG=GETDATE() WHERE OPTH_NOWO ='" & MyRecReadC("OPT_NoWO") & "'"
                            Call UpdateDatabase_Tabel(MySTRsql1, lblArea1.Text)
                        Else
                            mTxtErrAsesoris = "Permohonan Untuk Pasang Asesoris Gagal (Error Conection) NO WO " & nSr((MyRecReadC("OPT_CdAssesoris")))
                        End If
                    Else
                        MySTRsql1 = "UPDATE TRXN_STOCKAKSESORIS SET STOCKA_ALASAN='' WHERE STOCKA_NORANGKA='" & mpRangka & "' AND STOCKA_KDASS='" & MyRecReadC("OPT_CdAssesoris") & "'"
                        Call UpdateDatabase_Tabel(MySTRsql1, "WARHOUSE")
                    End If

                End If
            End If
            MyRecReadC.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try

        UpdateDataWarehouse_KirimAksesoris = 1
    End Function
    Function UpdateDataWarehouse_DoImora(ByVal mpRangka As String, ByVal mpMesin As String) As Byte
        If GetDataD_00NoFound01Found("SELECT * FROM TRXN_STOCKDO WHERE STOCKDO_NORANGKA='" & mpRangka & "'", "WAREHOUSE") <> 1 Then
            MySTRsql1 = "INSERT INTO TRXN_STOCKDO " & _
                       "(STOCKDO_NORANGKA,STOCKDO_NOMESIN,STOCKDO_KODEDLR,STOCKDO_NODOSPL,STOCKDO_TGDOSPL) VALUES " & _
                       "('" & mpRangka & "','" & mpMesin & "','" & lblArea1.Text & "','MUGEN',GETDATE())"
            UpdateDataWarehouse_DoImora = UpdateDatabase_Tabel(MySTRsql1, "WARHOUSE")
        Else
            UpdateDataWarehouse_DoImora = 1
        End If
    End Function
    Function UpdateDataSPK(ByVal mNOSPK As String, ByVal mTglMohon As String) As Byte
        '           "SPK_CETAKDOSTOCK=" & FieldTgl(CDate(mTglMohon)) & "," & _
        MySTRsql1 = "UPDATE TRXN_SPK SET " & _
                    "SPK_CETAKDOSTOCK=NULL," & _
                    "SPK_MOHONKIRIM=" & FieldTgl(CDate(mTglMohon)) & "," & _
                    "SPK_MOHONINPUT=GETDATE() " & _
                    "WHERE SPK_No ='" & mNOSPK & "'"
        UpdateDataSPK = UpdateDatabase_Tabel(MySTRsql1, lblArea1.Text)
    End Function
    Function UPDATE_STOCK(ByVal mpRangka As String, ByVal mDateTR As String, ByVal mDateMA As String, ByVal mDateMI As String, ByVal mDateMW As String) As Byte
        MySTRsql1 = "UPDATE TRXN_STOCK SET " & _
                   IIf(mDateTR <> "", "STOCK_KirimTGLTerima=" & mDateTR & ",", "") & _
                   "STOCK_KirimTGLMHNA= " & mDateMA & "," & _
                   "STOCK_KirimTGLMHNI= " & mDateMI & "," & _
                   "STOCK_KirimTGLMHNW= " & mDateMW & " " & "WHERE STOCK_NoRangka ='" & mpRangka & "'"
        UPDATE_STOCK = UpdateDatabase_Tabel(MySTRsql1, lblArea1.Text)
    End Function
    Function AddSaveDataSPKC_SPJ(ByVal mNOSPK As String, ByVal mNAMA As String, ByVal mNILAI1 As String, ByVal mNILAITgl2 As String, ByVal mInput As String, ByVal mSts As String) As String
        AddSaveDataSPKC_SPJ = 0
        If GetDataD_00NoFound01Found("SELECT * FROM TRXN_SPKC WHERE SPKC_NO='" & mNOSPK & "' AND SPKC_NAMA='" & mNAMA & "'", lblArea1.Text) = 1 Then
            AddSaveDataSPKC_SPJ = UpdateDatabase_Tabel("UPDATE TRXN_SPKC SET SPKC_ST=GETDATE(),SPKC_NAMA='" & mInput & "',SPKC_TEMP='SYSTEM' WHERE SPKC_NO='" & mNOSPK & "' AND SPKC_NAMA='" & mNAMA & "'", lblArea1.Text)
        End If
    End Function


    Function CreateOrderAksesoris(ByVal mServer As String, ByVal mpNoSPK As String) As Byte
        CreateOrderAksesoris = 0
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim merrordo As String = ""
        MySTRsql1 = "SELECT * FROM TRXN_OPTPO WHERE OPT_NODEALER='" & mServer & "' AND OPT_NOSPK='" & mpNoSPK & "' AND (OPT_STATUSPROSES='SETUJU-D' OR OPT_STATUSPROSES='SETUJU-A') ORDER BY OPT_NOSPK"

        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)
        Dim MGROUP As String
        Dim MASALSETUJU As String

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                While MyRecReadB.Read
                    MGROUP = ""
                    MASALSETUJU = IIf(nSr(MyRecReadB("OPT_STATUSPROSES")) = "='SETUJU-D'", "HWEBDO", "HWEBAP")

                    MySTRsql1 = "SELECT * FROM TRXN_SPK WHERE SPK_NO='" & nSr(MyRecReadB("OPT_NOSPK")) & "' AND SPK_TGLDO IS NOT NULL"
                    If GetDataD_00NoFound01Found(MySTRsql1, mServer) = 1 Then
                        If nSr(MyRecReadB("OPT_CDASS")) = "0303" Or nSr(MyRecReadB("OPT_CDASS")) = "0728" Or nSr(MyRecReadB("OPT_CDASS")) = "0729" Then
                            MGROUP = "A" 'Upping, Asuransi
                        Else
                            MySTRsql1 = "SELECT STANDARD_KELOMPOK as IsiField FROM DATA_STANDARD WHERE STANDARD_KODE='" & nSr(MyRecReadB("OPT_CDASS")) & "'"
                            MGROUP = GetDataD_IsiField(MySTRsql1, mServer)
                        End If
                        MySTRsql1 = "SELECT * FROM TRXN_OPT WHERE OPT_NOSPK='" & nSr(MyRecReadB("OPT_NOSPK")) & "' AND OPT_CdAssesoris='" & nSr(MyRecReadB("OPT_CDASS")) & "'"
                        If GetDataD_00NoFound01Found(MySTRsql1, mServer) = 0 Then
                            MySTRsql1 = "INSERT INTO TRXN_OPT(OPT_TglWOI,OPT_NoSPK,OPT_NoRangka,OPT_Unit,OPT_NoWO,OPT_CdAssesoris,OPT_HrgJual,OPT_TglJTP,OPT_Status,OPT_StsPaket,OPT_NOVCRDISC,OPT_PASANG,OPT_DESC) VALUES " & _
                                        "(GETDATE(),'" & nSr(MyRecReadB("OPT_NOSPK")) & "','',1,'','" & nSr(MyRecReadB("OPT_CDASS")) & "'," & IIf(nSr(MyRecReadB("OPT_STATUS")) = "1", nDb(MyRecReadB("OPT_HARGACUST")), 0) & "," & _
                                        "NULL,'" & IIf(nSr(MyRecReadB("OPT_STATUS")) = "0", "0", "1") & "','','" & MASALSETUJU & "','Y','" & TxtPetik(nSr(MyRecReadB("OPT_KETERANGAN"))) & "')"
                            Call UpdateDatabase_Tabel(MySTRsql1, mServer)
                        End If

                        If MGROUP = "A" Then

                            MySTRsql1 = "UPDATE TRXN_OPT SET OPT_TglWOI=GETDATE() WHERE OPT_NOSPK='" & nSr(MyRecReadB("OPT_NOSPK")) & "' AND OPT_CdAssesoris='" & nSr(MyRecReadB("OPT_CDASS")) & "' AND OPT_TglWOI IS NULL"
                            Call UpdateDatabase_Tabel(MySTRsql1, mServer)

                            MySTRsql1 = "UPDATE TRXN_OPT SET OPT_TglWOA=" & DtInSQL(MyRecReadB("OPT_TGLAPPV2")) & " WHERE OPT_NOSPK='" & nSr(MyRecReadB("OPT_NOSPK")) & "' AND OPT_CdAssesoris='" & nSr(MyRecReadB("OPT_CDASS")) & "' AND OPT_TglWOA IS NULL AND (OPT_NOWO='' OR OPT_NOWO IS NULL)"
                            Call UpdateDatabase_Tabel(MySTRsql1, mServer)

                            MySTRsql1 = "UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='SETUJU' WHERE OPT_NODEALER='" & mServer & "' AND OPT_CDASS='" & nSr(MyRecReadB("OPT_CDASS")) & "' AND OPT_NOSPK='" & nSr(MyRecReadB("OPT_NOSPK")) & "'"
                            Call UpdateDatabase_Tabel(MySTRsql1, "")
                        End If
                    End If
                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try

    End Function

    Function CreateWorkOrderAksesoris(ByVal mServer As String, ByVal mpNoSPK As String) As Byte
        CreateWorkOrderAksesoris = 0
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim merrordo As String = ""
        MySTRsql1 = "AND (ISNULL(OPT_NOWO) OR OPT_NOWO='') AND NOT ISNULL(OPT_TGLWOI) AND NOT ISNULL(OPT_TGLWOA) AND OPT_NOSPK=''"

        MySTRsql1 = "SELECT *," & _
                   "(SELECT SUPLIER_Nama FROM DATA_SUPLIER WHERE OPT_CdSuplier=SUPLIER_Kode) as mFSuplierNm," & _
                   "(SELECT STOCK_KirimTGL FROM TRXN_SPK,TRXN_STOCK WHERE SPK_NORANGKA=STOCK_NORANGKA AND (SPK_NO=OPT_NoSPK)) as mFTglTerima," & _
                   "(SELECT TYPE_Type FROM DATA_TYPE,TRXN_SPK WHERE TYPE_Type=SPK_CdType AND (SPK_NO=OPT_NoSPK)) as mFTypeKode," & _
                   "(SELECT TYPE_CdGroup FROM DATA_TYPE,TRXN_SPK WHERE TYPE_Type=SPK_CdType AND (SPK_NO=OPT_NoSPK)) as mFTypeGroup," & _
                   "(SELECT TYPE_Nama FROM DATA_TYPE,TRXN_SPK WHERE TYPE_Type=SPK_CdType AND (SPK_NO=OPT_NoSPK)) as mFTypeNama," & _
                   "(SELECT SUPLIER_Nama FROM TRXN_OPTH,DATA_SUPLIER WHERE OPTH_CdSuplier=SUPLIER_Kode AND OPTH_NoWO=OPT_NoWO) AS mNamaSuplierOPTH," & _
                   "(SELECT OPTH_CdSuplier FROM TRXN_OPTH WHERE OPTH_NoWO=OPT_NoWO) AS mKdSuplierOPTH," & _
                   "(SELECT OPTH_TGLWO FROM TRXN_OPTH WHERE OPTH_NOWO=OPT_Nowo) as mFTglWO," & _
                   "(SELECT OPTH_TglSendWO FROM TRXN_OPTH WHERE OPTH_NOWO=OPT_Nowo) as mFTglSnd," & _
                   "(SELECT OPTH_TglRcvWO FROM TRXN_OPTH WHERE OPTH_NOWO=OPT_Nowo) as mFTglRcv," & _
                   "(SELECT OPTH_TglBTL FROM TRXN_OPTH WHERE OPTH_NOWO=OPT_Nowo) as mFTglBtl," & _
                   "(SELECT OPTH_MOHONPASANG FROM TRXN_OPTH WHERE OPTH_NOWO=OPT_Nowo) as mFTglWhs," & _
                   "(SELECT OPTH_TglKerjaBukti FROM TRXN_OPTH WHERE OPTH_NOWO=OPT_Nowo) as mFTglPsg " & _
                   "FROM TRXN_OPT,DATA_STANDARD,TRXN_SPK,TRXN_STOCK " & _
                   "WHERE OPT_CdAssesoris=STANDARD_Kode AND OPT_NoSPK=SPK_NO AND SPK_NORANGKA=STOCK_NORANGKA AND " & _
                   "(STANDARD_Biaya<>'A' or (STANDARD_Kode='0303') or (STANDARD_Kode='0728') or (STANDARD_Kode='0729')) " & MySTRsql1 & " " & _
                   "ORDER BY OPT_NoSPK,OPT_CdAssesoris,OPT_CdSuplier"
        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            Dim lblNoSPK As String
            Dim lblNorangka As String
            Dim LblNama As String
            Dim lblNoMesin As String
            Dim LblTipe As String
            Dim MyTipeG As String = ""
            Dim MyTipeK As String = ""

            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                mBrsTabelB = 0
                While MyRecReadB.Read

                    lblNoSPK = nSr(MyRecReadB("OPT_NOSPK"))
                    lblNorangka = nSr(MyRecReadB("SPK_Norangka"))
                    LblNama = nSr(MyRecReadB("SPK_Nama1"))
                    lblNoMesin = nSr(MyRecReadB("STOCK_NOMESIN"))
                    LblTipe = "[" & Mid(nSr(MyRecReadB("CdType1")), 1, 1) & "-" & Mid(nSr(MyRecReadB("CdType1")), 2, 1) & "-" & Mid(nSr(MyRecReadB("CdType1")), 3, 1) & nSr(MyRecReadB("SPK_CdType")) & "] " & nSrNl(MyRecReadB("NamaType"), "SUDAH TIDAK TERDAFTAR") & " " & " [" & nSr(MyRecReadB("SPK_CdWarna")) & "] " & nSrNl(MyRecReadB("NamaWarna"), "SUDAH TIDAK TERDAFTAR")
                    MyTipeG = nSr(MyRecReadB("mFTypeGroup"))
                    MyTipeK = nSr(MyRecReadB("SPK_CdType"))
                    mBrsTabelB = mBrsTabelB + 1
                    mTabelB100(mBrsTabelB) = "" : mTabelB101(mBrsTabelB) = "" : mTabelB102(mBrsTabelB) = "" : mTabelB103(mBrsTabelB) = ""
                    mTabelB104(mBrsTabelB) = "" : mTabelB105(mBrsTabelB) = "" : mTabelB106(mBrsTabelB) = "" : mTabelB107(mBrsTabelB) = ""
                    mTabelB108(mBrsTabelB) = "" : mTabelB109(mBrsTabelB) = "" : mTabelB110(mBrsTabelB) = "" : mTabelB111(mBrsTabelB) = ""


                    mTabelB100(mBrsTabelB) = CStr(mBrsTabelB)
                    mTabelB102(mBrsTabelB) = nSr(MyRecReadB("OPT_CdAssesoris"))
                    mTabelB103(mBrsTabelB) = nSr(MyRecReadB("STANDARD_Nama"))
                    mTabelB104(mBrsTabelB) = nSr(MyRecReadB("OPT_Unit"))
                    mTabelB105(mBrsTabelB) = "0"
                    mTabelB109(mBrsTabelB) = nSr(MyRecReadB("STANDARD_GROUP"))
                    mTabelB110(mBrsTabelB) = nSr(MyRecReadB("OPT_Desc"))


                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
            If mBrsTabelB > 0 Then Call HitungModalPerSuplier(mServer, MyTipeK, MyTipeG)
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Sub HitungModalPerSuplier(ByVal pServer As String, ByVal pMyTipeK As String, ByVal pMyTipeG As String)
        'ada di notepad test.txt
    End Sub

    Function nSrNl(ByRef nilai As Object, ByRef mOutput As Object) As String
        If Not IsDBNull(nilai) Then
            nSrNl = nilai
        Else
            nSrNl = mOutput
        End If
    End Function

    Function FindAksesoris(ByVal mServer As String, ByVal mQuery As String, ByVal mpKodeAss As String, ByVal mpJml As Integer, ByVal mpMyTipeK As String, ByVal mpMyTipeG As String, ByVal mpStandard As Integer) As Byte
        FindAksesoris = 0
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim merrordo As String = ""
        MySTRsql1 = "SELECT * FROM DATA_STANDARD WHERE STANDARDH_CdAss='" & mpKodeAss & "' AND " & mQuery

        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                mBrsTabelB = 0
                While MyRecReadB.Read
                    If mpStandard = 0 Or (mpStandard = 1 And nDb(MyRecReadB("STANDARD_Harga")) <> 0) Then
                        mRpModal = nDb(MyRecReadB("STANDARDH_Harga"))
                        mKdSuplier = nSr(MyRecReadB("STANDARDH_CdSuplier"))
                        mPcSuplier = nDb(MyRecReadB("SUPLIER_PercenModalJual"))
                        mPcSuplier = 0
                        'Modal Kali Unit

                        If mpStandard = 1 And _
                          (nSr(MyRecReadB("STANDARD_CdSuplier")) = "" Or (nSr(MyRecReadB("STANDARD_TypeGroup")) <> "" And nSr(MyRecReadB("STANDARD_TypeGroup")) <> mpMyTipeG) Or (nSr(MyRecReadB("STANDARD_Type")) <> "" And nSr(MyRecReadB("STANDARD_Type")) <> mpMyTipeK)) Then
                            mRpModal = 0
                        End If
                        Call Periksa_Kode_Suplier((1 + mPcSuplier) * mRpModal * nDb(mpJml), mKdSuplier, IIf(nDb(MyRecReadB("STANDARDH_max")) < 0, "*", ""))
                    End If

                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Sub Periksa_Kode_Suplier(ByVal rpmodal As Double, ByVal kodeS As String, ByVal Bintang As String)
        Dim mNoCol As Short
        Dim mLoop1 As Short
        mNoCol = 0
        If rpmodal = 0 Then Exit Sub
        If mBrsTabelB2A > 2 Then
            For mLoop1 = 3 To mBrsTabelB2A
                If mTabelB2A00(mLoop1) = kodeS Then
                    mNoCol = mLoop1
                End If
            Next
        End If
        If mNoCol = 0 Then
            mBrsTabelB2A = mBrsTabelB2A + 1
            mTabelB2A00(mBrsTabelB2A) = kodeS
            mNoCol = mBrsTabelB2A
        End If
        mTabelB2B00(mBrsTabelB2A) = nDb(rpmodal) & Bintang
    End Sub


    Function GetUpdate_Data_SPKD(ByVal mpNo_SPK As String, ByVal mNoMohon_SPK As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand


        Call Msg_err("", 0)
        GetUpdate_Data_SPKD = 0

        MySTRsql1 = "SELECT * , " & _
                    "(SELECT STOCK_Kirimtgl       FROM TRXN_STOCK     WHERE STOCK_NORANGKA=SPK_NORANGKA) AS mfTglKirimUnit," & _
                    "(SELECT STOCK_Kirimtglterima FROM TRXN_STOCK     WHERE STOCK_NORANGKA=SPK_NORANGKA) AS mfTglKirimUnitTerima," & _
                    "(SELECT SPKCANCEL_NO         FROM TRXN_SPKCANCEL WHERE SPKCANCEL_NO = SPK_NO)       AS mfNoCancel," & _
                    "(SELECT SUM(ISNULL(ARTRAN_JUMLAH,0)) as mfBayar0 FROM TRXN_ARTRAN WHERE ARTRAN_NOSPK=SPK_No AND ISNULL(ARTRAN_NOWO,'')='' ) as mBayar   " & _
                    "FROM TRXN_SPK,DATA_SALESMAN,DATA_LEASE,DATA_TYPE,DATA_WARNA WHERE " & _
                    "SPK_CdSales=Sales_Kode AND SPK_Cdlease=Lease_Kode AND SPK_CdType=TYPE_Type AND SPK_CdWarna=WARNA_Kode AND SPK_NO='" & mpNo_SPK & "'"


        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetUpdate_Data_SPKD = IIf(MyRecReadA.HasRows = True, 1, 0)
            Dim mDesc As String = ""
            If MyRecReadA.Read Then

                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_TGLIN", DtFr(MyRecReadA("SPK_Tanggal"), "yyyy-MM-dd"), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_TGLCR", DtFr(MyRecReadA("SPK_TGLSPK"), "yyyy-MM-dd"), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_TGLAP", DtFr(MyRecReadA("SPK_TGLURT"), "yyyy-MM-dd"), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_CDTIPE", nSr(MyRecReadA("SPK_CDTYPE")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_TGLDO", DtFr(MyRecReadA("SPK_TglDO"), "yyyy-MM-dd"), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_NAMA", TxtPetik(MyRecReadA("SPK_Nama1")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_SALES", TxtPetik(MyRecReadA("Sales_Nama")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_IDSALES", TxtPetik(MyRecReadA("SPK_CdSales")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_JNS", nSr(MyRecReadA("LEASE_Nama")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_JNSCD", nSr(MyRecReadA("SPK_Cdlease")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_ROAD", nSr(MyRecReadA("SPK_Road")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_TNR", nLg(MyRecReadA("SPK_HrgASR")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_RANGKA", nSr(MyRecReadA("SPK_NoRangka")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_THN", nSr(MyRecReadA("SPK_Tahun")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_TIPE", nSr(MyRecReadA("TYPE_Nama")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_WARNA", nSr(MyRecReadA("WARNA_Int")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_HARGA", nLg(MyRecReadA("SPK_Piutang")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_PCERMATM", nLg(MyRecReadA("SPK_PaketCermat")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_PCERMATJ", nLg(MyRecReadA("SPK_PaketCermatJ")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_SUBSIDIS", nLg(MyRecReadA("SPK_SubsidiSls")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_DISC", nLg(MyRecReadA("SPK_Potongan")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_TOTAL", (nLg(MyRecReadA("SPK_Piutang")) - nLg(MyRecReadA("SPK_Potongan"))), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_KOMISI", nLg(MyRecReadA("SPK_Komisi")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_SUBSIDI", nLg(MyRecReadA("SPK_HrgADM")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_BAYAR", nLg(MyRecReadA("mBayar")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_SISA", nLg(nLg(MyRecReadA("SPK_Piutang")) - nLg(MyRecReadA("SPK_Potongan")) - nLg(MyRecReadA("mBayar"))), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_HRGSETUJU", nSr(MyRecReadA("SPK_PaketCermat")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_CRVALID", nSr(MyRecReadA("SPK_APPRVCR")), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_TGLKIRIM", DtFr(MyRecReadA("mfTglKirimUnit"), "yyyy-MM-dd"), "DODOL")
                Call Update_tabel_spkad(mNoMohon_SPK, "SPK_TGLTERIMA", DtFr(MyRecReadA("mfTglKirimUnitTerima"), "yyyy-MM-dd"), "DODOL")
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()

        Catch ex As Exception
            Call Msg_err(ex.Message, 1)
        End Try

    End Function

    Function Update_tabel_spkad(ByVal mNOM As String, ByVal mJUD As String, ByVal mNIL As String, ByVal mNOMORURUT As String) As Byte
        Dim MySTRsql1 As String = ""
        MySTRsql1 = "DELETE FROM TRXN_SPKAD WHERE NOMOR_MOHON='" & mNOM & "' AND KETERANGAN='" & mJUD & "' AND ISNULL(NOMOR,'')='" & mNOMORURUT & "'"
        Update_tabel_spkad = UpdateDatabase_Tabel(MySTRsql1, "")
        MySTRsql1 = "INSERT INTO TRXN_SPKAD(NOMOR_MOHON,KETERANGAN,NILAI,NOMOR) VALUES ('" & mNOM & "','" & mJUD & "','" & Left(mNIL, 50) & "','" & mNOMORURUT & "')"
        Update_tabel_spkad = UpdateDatabase_Tabel(MySTRsql1, "")

    End Function

    Protected Sub ButtonDataSPKPErmohonan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDataSPKPErmohonan.Click
        Dim mSw As Byte = 0
        If InStr(LblResultIdMohon.Text, "WB/APR/SW") <> 0 Then
            mSw = 1
            mSw = mSw + GetDataD_00NoFound01Found("SELECT * FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND KETERANGAN LIKE 'SPK_VA%' ", "")
        End If
        Call GetDataA_Tabel_SPKAD("SELECT * FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND NOT(KETERANGAN LIKE 'SPK_TJ%' OR KETERANGAN LIKE 'SPK_VA%') ORDER BY KETERANGAN", mSw)
    End Sub




End Class
