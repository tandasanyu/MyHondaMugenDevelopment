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


'1 Cari
'2 Posisi 0 Setuju SPV
'3 Posisi 1 Setuju SM 
'4 Posisi 2 Setuju OSM
'5 Posisi 3 Setuju DIR
'6 Posisi 4 Mengajukan Permohonan
'7 Pesrsetujuan repair Warehouse

'SECURITYH_USER c 15
'SECURITYH_NOID c 30

Partial Class Default2
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If

        If LblUserName.Text = "" Then
            Dim x As String
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = x.ToString
            If GetData_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0101'") = 1 Then
                MultiView1a.ActiveViewIndex = 0
                MultiView11a.ActiveViewIndex = 0
                Call UpdateData_Tabel("UPDATE TRXN_SPKAH SET SPV='' WHERE SPV IS NULL")
                Call UpdateData_Tabel("UPDATE TRXN_SPKAH SET APPROVALCODEP='0' WHERE JUDUL like 'ENTRY%' AND CABANG='" & lblArea1.Text & "' AND APPROVALCODEP='' AND (SPV='SC' OR SPV='FZ' OR SPV='UG')")
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

    Protected Sub TampilkanPermohona()

        Call ClearForm()
        If InStr(LblResultIdMohon.Text, "WB/APR/AS") = 0 Then
            Call GetData_Tabel_SPKAH_Header("SELECT * FROM TRXN_SPKAH WHERE TRXN_SPKAH.NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND JUDUL LIKE 'ENTRY%'")
        Else
            Call GetData_Tabel_SPKAH_HeaderAsesoris("SELECT * FROM TRXN_OPTPO WHERE OPT_NOMORMOHON='" & LblResultIdMohon.Text & "'")
        End If

        If InStr(LblResultIdMohon.Text, "EM/APR/WB") = 0 Then
            If LblNoSPK.Text <> "" Then
                Dim mCari As String = IIf(LblResultPosSetujuCurrent.Text <> "", "AND APPROVALCODEP='" & LblResultPosSetujuCurrent.Text & "'", "AND (APPROVALCODEP='" & LblResultPosSetujuCurrent.Text & "' OR APPROVALCODEP IS NULL)")
                Dim mNomor As String = IIf(lblNomorSetuju.Text <> "", "AND NOMOR='" & lblNomorSetuju.Text & "'", "AND (NOMOR='" & lblNomorSetuju.Text & "' OR NOMOR IS NULL)")
                'Detail Kendaraan
                If (InStr(LblResultIdMohon.Text, "WB/APR/AS") <> 0 Or InStr(LblResultIdMohon.Text, "WB/APR/DO") <> 0) And _
                   (TxtPosJab.Text = "0" Or TxtPosJab.Text = "1") Then
                    If TxtPosJab.Text = "0" Then
                        Call UpdateData_Tabel("UPDATE TRXN_OPTPO SET OPT_USERAPPV1='" & LblUserName.Text & "' WHERE OPT_STATUSPROSES='ENTRY' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV2 IS NULL AND OPT_TGLAPPV1 IS NULL ")
                    ElseIf TxtPosJab.Text = "1" Then
                        Call UpdateData_Tabel("UPDATE TRXN_OPTPO SET OPT_USERAPPV1='" & LblUserName.Text & "',OPT_TGLAPPV1=GETDATE(),OPT_APPROVALCODEP='0' WHERE OPT_STATUSPROSES like 'ENTRY%' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV1 IS NULL AND OPT_APPROVALCODEP='' AND (OPT_SPV='SC' OR OPT_SPV='FZ' OR OPT_SPV='UG')")
                        Call UpdateData_Tabel("UPDATE TRXN_OPTPO SET OPT_USERAPPV2='" & LblUserName.Text & "' WHERE OPT_STATUSPROSES='ENTRY' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV2 IS NULL AND OPT_TGLAPPV1 IS NOT NULL")

                    End If
                End If
                Call GetData_Tabel_SPKAD("SELECT * FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON='" & LblResultIdMohon.Text & "'")

                If Not (InStr(LblResultIdMohon.Text, "WB/APR/SD") <> 0 Or _
                        InStr(LblResultIdMohon.Text, "WB/APR/AS") <> 0 Or _
                        InStr(LblResultIdMohon.Text, "WB/APR/FT") <> 0 Or _
                        InStr(LblResultIdMohon.Text, "WB/APR/DO") <> 0) Then 'Selain Permohonan Maksimal Diskon
                    Call GetData_Tabel_SPKAH_Detail("SELECT * FROM TRXN_SPKAH WHERE CABANG='" & lblDealer.Text & "' AND TRXN_SPKAH.NOMOR_SPK='" & LblNoSPK.Text & "' AND APPROVALCODE='" & LblResultPosSetuju.Text & "' AND JUDUL LIKE 'ENTRY%' " & mCari & mNomor)
                    Call NomorMohonBaru_YangSudahAdaNomornya()
                    Call TabelError()
                    MultiViewENTRY.ActiveViewIndex = 0
                Else
                    'SD=Permohonan Khusus Polcy Max Diskon, AS=permohonan Aksesoris 
                    'FT=Permohonan Faktur                   DO=permohonan DO

                    If InStr(LblResultIdMohon.Text, "WB/APR/AS") = 0 Then
                        Call GetData_Tabel_SPKAH_Detail_PolcyDsikon("SELECT * FROM TRXN_SPKAH WHERE CABANG='" & lblDealer.Text & "' AND TRXN_SPKAH.NOMOR_SPK='" & LblNoSPK.Text & "' AND APPROVALCODE='" & LblResultPosSetuju.Text & "' AND TRXN_SPKAH.NOMOR_MOHON='" & LblResultIdMohon.Text & "' AND JUDUL LIKE 'ENTRY%' " & mCari & mNomor)
                        MultiViewENTRY.ActiveViewIndex = 1
                    Else
                        MultiViewENTRY.ActiveViewIndex = 1
                    End If
                    MultiViewENTRY.ActiveViewIndex = 1
                    MultiViewSetujuRangka.ActiveViewIndex = -1
                    MultiViewSetujuFaktur.ActiveViewIndex = -1

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
                    Call GetData_ErrorMsg(LblResultIdMohon.Text, "")
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
                        Call GetData_Faktur("SELECT * FROM TRXN_SPKAF WHERE SPKAF_NOMORMOHON='" & LblResultIdMohon.Text & "' AND SPKAF_NOMOR=''")
                    End If
                    If InStr(LblResultIdMohon.Text, "WB/APR/AS") <> 0 Then
                        MultiViewAsesorisHdiary.ActiveViewIndex = 0
                        MultiViewSetujuAsesoris.ActiveViewIndex = 0
                        LvAksesorisNonDO.DataBind()
                    End If
                End If
                '==========================================================
                Call GetData_Tabel_SPKAS("SELECT * FROM TRXN_SPKAS WHERE TRXN_SPKAS.SETUJU_NOMOR='" & LblResultNomor.Text & "'")
                Call GETType_MakDiscount()
                '==========================================================
                MultiViewHistoryPersetujuan.ActiveViewIndex = 0
                LVPersetujuan2.DataBind()
                '==========================================================
                If InStr(LblResultIdMohon.Text, "WB/APR/SD") <> 0 Then
                    'LblTotalSetuju.Text = (Val(IIf(TxtDisetujuiHargaDisc.Text = "", LblPengajuanHargaDisc.Text, TxtDisetujuiHargaDisc.Text)) - _
                    '                       Val(IIf(TxtDisetujuiHrgSubs.Text = "", LblPengajuanHargaSubs.Text, TxtDisetujuiHrgSubs.Text)) + _
                    '                       Val(IIf(TxtDisetujuiHrgKoms.Text = "", LblPengajuanHargaKoms.Text, TxtDisetujuiHrgKoms.Text)))
                    LblTotalSetuju.Text = (Val(TxtDisetujuiHrgDisc.Text) - Val(TxtDisetujuiHrgSubs.Text) + Val(TxtDisetujuiHrgKoms.Text))
                    LblTotalPengajuan.Text = (Val(LblPengajuanHargaDisc.Text) - Val(LblPengajuanHargaSubs.Text) + Val(LblPengajuanHargaKoms.Text))
                End If


                MultiView1a.ActiveViewIndex = 1
                If InStr(LblResultPosSetuju.Text, "0") Then MultiView0S.ActiveViewIndex = 0 Else MultiView0S.ActiveViewIndex = -1
                If InStr(LblResultPosSetuju.Text, "1") Then MultiView1S.ActiveViewIndex = 0 Else MultiView1S.ActiveViewIndex = -1
                If InStr(LblResultPosSetuju.Text, "2") Then MultiView2S.ActiveViewIndex = 0 Else MultiView2S.ActiveViewIndex = -1
                If InStr(LblResultPosSetuju.Text, "3") Then MultiView3S.ActiveViewIndex = 0 Else MultiView3S.ActiveViewIndex = -1
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
            Call GetData_Tabel_WAREHOUSE(mQuery, "")
            MultiView1a.ActiveViewIndex = 2
            MultiViewWH.ActiveViewIndex = 0
        End If
    End Sub

    Sub NomorMohonBaru_YangSudahAdaNomornya()
        If lblNomorSetuju.Text <> "" Then
            If GetFindRecord_Tabel("SELECT * FROM TRXN_SPKAH WHERE NOMOR='" & lblNomorSetuju.Text & "' AND JUDUL LIKE 'SETUJU%'") = 1 Then
                Dim mNomorBaru As String = ""
                mNomorBaru = GetData_Nomor()
                If mNomorBaru <> "" Then
                    ' ada ganti
                    Call UpdateData_Tabel("UPDATE TRXN_SPKAH SET NOMOR='" & mNomorBaru & "' WHERE NOMOR='" & lblNomorSetuju.Text & "' AND JUDUL LIKE 'ENTRY%'")
                    Call UpdateData_Tabel("INSERT INTO TRXN_SPKAS " & _
                                              "SELECT SETUJU_ENTRY,SETUJU_USER,SETUJU_POS,SETUJU_TANGGAL,SETUJU_STATUS,SETUJU_CATATAN,'" & mNomorBaru & "' FROM TRXN_SPKAS WHERE SETUJU_NOMOR='" & lblNomorSetuju.Text & "' AND SETUJU_POS='0'")
                    lblNomorSetuju.Text = mNomorBaru
                    LblResultNomor.Text = mNomorBaru
                End If
            End If
        End If
    End Sub


    Sub TabelError()
        LblBlockPesan.Text = ""
        LblBlockPesanR.Text = ""
        LblBlockPesanC.Text = ""
        If ChkBox1.Checked = True Then Call GetData_ErrorMsg(Lbl01Mhn.Text, Lbl01Mhn.Text)
        If ChkBox2.Checked = True Then Call GetData_ErrorMsg(Lbl02Mhn.Text, Lbl02Mhn.Text)
        If ChkBox3.Checked = True Then Call GetData_ErrorMsg(Lbl03Mhn.Text, Lbl03Mhn.Text)
        If ChkBox4.Checked = True Then Call GetData_ErrorMsg(Lbl04Mhn.Text, Lbl04Mhn.Text)
        If ChkBox5.Checked = True Then Call GetData_ErrorMsg(Lbl05Mhn.Text, Lbl05Mhn.Text)
        If ChkBox6.Checked = True Then Call GetData_ErrorMsg(Lbl06Mhn.Text, Lbl06Mhn.Text)
        If ChkBox7.Checked = True Then Call GetData_ErrorMsg(Lbl07Mhn.Text, Lbl07Mhn.Text)
        If ChkBox8.Checked = True Then Call GetData_ErrorMsg(Lbl08Mhn.Text, Lbl08Mhn.Text)
        If ChkBox9.Checked = True Then Call GetData_ErrorMsg(Lbl09Mhn.Text, Lbl09Mhn.Text)
        If ChkBox10.Checked = True Then Call GetData_ErrorMsg(Lbl10Mhn.Text, Lbl10Mhn.Text)
    End Sub


    Protected Sub BtnKembali_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKembali1.Click
        Call Msg_err("", "")
        MultiView1a.ActiveViewIndex = 0
    End Sub


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
                    ElseIf Mid(lblAkses.Text, 3, 1) = "1" Then
                        TxtPosJab.Text = "1"
                        TxtPosApv.Text = "0"
                    ElseIf Mid(lblAkses.Text, 4, 1) = "1" Then
                        TxtPosJab.Text = "2"
                        TxtPosApv.Text = "1"
                    ElseIf Mid(lblAkses.Text, 5, 1) = "1" Then
                        TxtPosJab.Text = "3"
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

    Sub ClearForm()
        LblNoSPK.Text = ""
        lblPengajuanTahun.Text = ""
        LblPengajuanHargaUnit.Text = ""
        LblPengajuanHargaDisc.Text = ""
        LblPengajuanHargaSubs.Text = ""
        LblPengajuanHargaKoms.Text = ""

        LblTglMHS.Text = ""
        LblTglDO.Text = ""
        LblTglCreateSPK.Text = ""
        LblTglSetujuSM.Text = ""
        LblNama.Text = ""
        LblSales.Text = "" : LblSalesSPV.Text = "" : LblSalesSPV0.Text = ""
        LblJns.Text = ""
        lblNorangka.Text = ""
        lblTipe.Text = ""

        LblHarga.Text = ""
        LblSubsidi.Text = ""
        LblKomisi.Text = ""
        LblMaxDisc.Text = ""
        LblBayar.Text = ""
        LblUangMuka.Text = ""
        LblTotal.Text = ""

        lblTnr.Text = ""
        lblTahun.Text = ""
        lblWarna.Text = ""
        LblDisc.Text = ""
        LblNoteDiskon.Text = "" : LblsetujuDiskon.Text = ""
        LblCdType.Text = ""
        LblSisa.Text = ""
        lblSetuju.Text = ""

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

        lblPolcyNomorMohon.Text = ""
        lblPolcyJudul.Text = ""
        lblPolcyAlasan.Text = ""
        lblPolcyTanggal.Text = ""
        lblPolcyUser.Text = ""
        TxtDisetujuiTahun.Text = "" : Label50.Text = ""
        lblDisetujuiHrgUnit.Text = ""
        TxtDisetujuiHrgDisc.Text = ""
        TxtDisetujuiHrgSubs.Text = ""
        TxtDisetujuiHrgKoms.Text = ""
        LblStatusUpdateSPK.Text = ""
        CheckAksesoris.Checked = False
        LblBlockPesan.Text = ""
        LblBlockPesanR.Text = ""
        LblBlockPesanC.Text = ""
        LblWarning.Text = ""
        TxtDisetujuiNoRangka.Text = "" : lblDisetujuiNoRangka.Text = "" : lblDisetujuiNoRangkaTmp.Text = ""
        LblAksesorisHdiary.Text = ""
        Call TabelKosong()
    End Sub

    Sub TabelKosong()
        Lbl01Mhn.Text = "" : Lbl01Judul.Text = "" : Lbl01Alasan.Text = "" : Lbl01Nilai.Text = "" : Lbl01Tanggal.Text = "" : Lbl01User.Text = "" : ChkBox1.Checked = False : ChkBox1.Visible = False : ChkBox1.Checked = False : ChkBox1.Text = ""
        Lbl02Mhn.Text = "" : Lbl02Judul.Text = "" : Lbl02Alasan.Text = "" : Lbl02Nilai.Text = "" : Lbl02Tanggal.Text = "" : Lbl02User.Text = "" : ChkBox2.Checked = False : ChkBox2.Visible = False : ChkBox2.Checked = False : ChkBox2.Text = ""
        Lbl03Mhn.Text = "" : Lbl03Judul.Text = "" : Lbl03Alasan.Text = "" : Lbl03Nilai.Text = "" : Lbl03Tanggal.Text = "" : Lbl03User.Text = "" : ChkBox3.Checked = False : ChkBox3.Visible = False : ChkBox3.Checked = False : ChkBox3.Text = ""
        Lbl04Mhn.Text = "" : Lbl04Judul.Text = "" : Lbl04Alasan.Text = "" : Lbl04Nilai.Text = "" : Lbl04Tanggal.Text = "" : Lbl04User.Text = "" : ChkBox4.Checked = False : ChkBox4.Visible = False : ChkBox4.Checked = False : ChkBox4.Text = ""
        Lbl05Mhn.Text = "" : Lbl04Judul.Text = "" : Lbl05Alasan.Text = "" : Lbl05Nilai.Text = "" : Lbl05Tanggal.Text = "" : Lbl05User.Text = "" : ChkBox5.Checked = False : ChkBox5.Visible = False : ChkBox5.Checked = False : ChkBox5.Text = ""
        Lbl06Mhn.Text = "" : Lbl05Judul.Text = "" : Lbl06Alasan.Text = "" : Lbl06Nilai.Text = "" : Lbl06Tanggal.Text = "" : Lbl06User.Text = "" : ChkBox6.Checked = False : ChkBox6.Visible = False : ChkBox6.Checked = False : ChkBox6.Text = ""
        Lbl07Mhn.Text = "" : Lbl06Judul.Text = "" : Lbl07Alasan.Text = "" : Lbl07Nilai.Text = "" : Lbl07Tanggal.Text = "" : Lbl07User.Text = "" : ChkBox7.Checked = False : ChkBox7.Visible = False : ChkBox7.Checked = False : ChkBox7.Text = ""
        Lbl08Mhn.Text = "" : Lbl08Judul.Text = "" : Lbl08Alasan.Text = "" : Lbl08Nilai.Text = "" : Lbl08Tanggal.Text = "" : Lbl08User.Text = "" : ChkBox8.Checked = False : ChkBox8.Visible = False : ChkBox8.Checked = False : ChkBox8.Text = ""
        Lbl09Mhn.Text = "" : Lbl09Judul.Text = "" : Lbl09Alasan.Text = "" : Lbl09Nilai.Text = "" : Lbl09Tanggal.Text = "" : Lbl09User.Text = "" : ChkBox9.Checked = False : ChkBox9.Visible = False : ChkBox9.Checked = False : ChkBox9.Text = ""
        Lbl10Mhn.Text = "" : Lbl10Judul.Text = "" : Lbl10Alasan.Text = "" : Lbl10Nilai.Text = "" : Lbl10Tanggal.Text = "" : Lbl10User.Text = "" : ChkBox10.Checked = False : ChkBox10.Visible = False : ChkBox10.Checked = False : ChkBox10.Text = ""
    End Sub

    Sub insert_tabel(ByVal pmLblMhn As String, ByVal pmLblJudul As String, ByVal pmLblAlasan As String, ByVal pmLblTanggal As String, ByVal pmLbluser As String, ByVal pmLblChange0 As String, ByVal pmLblChange1 As String, ByVal pmLblChange2 As String, ByVal pmLblChange3 As String)
        Dim mChange As String = ""
        If pmLblChange0 <> "" Then
            If InStr(pmLblJudul, "HARGA UNIT") <> 0 Or InStr(pmLblJudul, "MAKSIMAL DISKON") <> 0 Then
                mChange = mChange & "Unit Menjadi Rp." & pmLblChange0 & ","
            Else
                mChange = mChange & "Menjadi " & pmLblChange0 & ","
            End If
        End If
        If pmLblChange1 <> "" Then
            mChange = mChange & "Diskon Menjadi Rp." & pmLblChange1 & ","
        End If
        If pmLblChange2 <> "" Then
            mChange = mChange & "Subsidi Menjadi Rp." & pmLblChange2 & ","
        End If
        If pmLblChange3 <> "" Then
            mChange = mChange & "Komisi Menjadi Rp." & pmLblChange3 & ","
        End If
        If mChange <> "" Then
            mChange = "Ubah " & mChange
        End If

        If Lbl01Mhn.Text = "" Then
            Lbl01Mhn.Text = pmLblMhn : Lbl01Judul.Text = pmLblJudul : Lbl01Alasan.Text = pmLblAlasan : Lbl01Nilai.Text = mChange : Lbl01Tanggal.Text = pmLblTanggal : Lbl01User.Text = pmLbluser : ChkBox1.Checked = True : ChkBox1.Visible = True
        ElseIf Lbl02Mhn.Text = "" Then
            Lbl02Mhn.Text = pmLblMhn : Lbl02Judul.Text = pmLblJudul : Lbl02Alasan.Text = pmLblAlasan : Lbl02Nilai.Text = mChange : Lbl02Tanggal.Text = pmLblTanggal : Lbl02User.Text = pmLbluser : ChkBox2.Checked = True : ChkBox2.Visible = True
        ElseIf Lbl03Mhn.Text = "" Then
            Lbl03Mhn.Text = pmLblMhn : Lbl03Judul.Text = pmLblJudul : Lbl03Alasan.Text = pmLblAlasan : Lbl03Nilai.Text = mChange : Lbl03Tanggal.Text = pmLblTanggal : Lbl03User.Text = pmLbluser : ChkBox3.Checked = True : ChkBox3.Visible = True
        ElseIf Lbl04Mhn.Text = "" Then
            Lbl04Mhn.Text = pmLblMhn : Lbl04Judul.Text = pmLblJudul : Lbl04Alasan.Text = pmLblAlasan : Lbl04Nilai.Text = mChange : Lbl04Tanggal.Text = pmLblTanggal : Lbl04User.Text = pmLbluser : ChkBox4.Checked = True : ChkBox4.Visible = True
        ElseIf Lbl05Mhn.Text = "" Then
            Lbl05Mhn.Text = pmLblMhn : Lbl05Judul.Text = pmLblJudul : Lbl05Alasan.Text = pmLblAlasan : Lbl05Nilai.Text = mChange : Lbl05Tanggal.Text = pmLblTanggal : Lbl05User.Text = pmLbluser : ChkBox5.Checked = True : ChkBox5.Visible = True
        ElseIf Lbl06Mhn.Text = "" Then
            Lbl06Mhn.Text = pmLblMhn : Lbl06Judul.Text = pmLblJudul : Lbl06Alasan.Text = pmLblAlasan : Lbl06Nilai.Text = mChange : Lbl06Tanggal.Text = pmLblTanggal : Lbl06User.Text = pmLbluser : ChkBox6.Checked = True : ChkBox6.Visible = True
        ElseIf Lbl07Mhn.Text = "" Then
            Lbl07Mhn.Text = pmLblMhn : Lbl07Judul.Text = pmLblJudul : Lbl07Alasan.Text = pmLblAlasan : Lbl07Nilai.Text = mChange : Lbl07Tanggal.Text = pmLblTanggal : Lbl07User.Text = pmLbluser : ChkBox7.Checked = True : ChkBox7.Visible = True
        ElseIf Lbl08Mhn.Text = "" Then
            Lbl08Mhn.Text = pmLblMhn : Lbl08Judul.Text = pmLblJudul : Lbl08Alasan.Text = pmLblAlasan : Lbl08Nilai.Text = mChange : Lbl08Tanggal.Text = pmLblTanggal : Lbl08User.Text = pmLbluser : ChkBox8.Checked = True : ChkBox8.Visible = True
        ElseIf Lbl09Mhn.Text = "" Then
            Lbl09Mhn.Text = pmLblMhn : Lbl09Judul.Text = pmLblJudul : Lbl09Alasan.Text = pmLblAlasan : Lbl09Nilai.Text = mChange : Lbl09Tanggal.Text = pmLblTanggal : Lbl09User.Text = pmLbluser : ChkBox9.Checked = True : ChkBox9.Visible = True
        ElseIf Lbl10Mhn.Text = "" Then
            Lbl10Mhn.Text = pmLblMhn : Lbl10Judul.Text = pmLblJudul : Lbl10Alasan.Text = pmLblAlasan : Lbl10Nilai.Text = mChange : Lbl10Tanggal.Text = pmLblTanggal : Lbl10User.Text = pmLbluser : ChkBox10.Checked = True : ChkBox10.Visible = True
        End If
    End Sub

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



    Function GetData_Parameter(ByVal mSqlCommadstring As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetData_Parameter = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Parameter = IIf(MyRecReadA.HasRows = True, 1, 0)
            If GetData_Parameter = 1 Then
                MyRecReadA.Read()
                GetData_Parameter = (nSr(MyRecReadA("PARAMETER_NAMA")))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Sub GetData_ErrorMsg(ByVal mSqlCommadstring As String, ByVal mSqlJudul As String)
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


    Function GetData_Faktur(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetData_Faktur = 0

        cnn = New OleDbConnection(strconn)
        LblNamaFaktur.Text = ""
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Faktur = IIf(MyRecReadA.HasRows = True, 1, 0)
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

    Function cari_kode_mohon(ByVal mData1 As String, ByVal mData2 As String, ByVal mTipe As String) As String
        Dim mMohon1 As String
        Dim mMohon2 As String
        Call Msg_err("", "")
        mMohon1 = "" : mMohon2 = ""
        If InStr(mData1, "EM/APR/CD") <> 0 Or InStr(mData2, "ENTRY ALASAN CETAK DO BELUM LUNAS BAYAR TUNAI") <> 0 Then
            mMohon1 = "ENTRY ALASAN CETAK DO BELUM LUNAS BAYAR TUNAI"
            mMohon2 = "EM/APR/CD"
        ElseIf InStr(mData1, "EM/APR/RB") <> 0 Or InStr(mData2, "ENTRY ALASAN UBAH CARA BAYAR") <> 0 Then
            mMohon1 = "ENTRY ALASAN UBAH CARA BAYAR"
            mMohon2 = "EM/APR/RB"
        ElseIf InStr(mData1, "EM/APR/RH0") <> 0 Or InStr(mData2, "ENTRY ALASAN UBAH HARGA DISKON DAN UNIT") <> 0 Then
            mMohon1 = "ENTRY ALASAN UBAH HARGA DISKON DAN UNIT"
            mMohon2 = "EM/APR/RH0"
        ElseIf InStr(mData1, "EM/APR/RH1") <> 0 Then
        ElseIf InStr(mData2, "ENTRY TOTAL UBAH HARGA UNIT MENJADI") <> 0 Then
            mMohon1 = "ENTRY TOTAL UBAH HARGA UNIT MENJADI"
            mMohon2 = "EM/APR/RH1"
        ElseIf InStr(mData1, "EM/APR/RH2") <> 0 Or InStr(mData2, "ENTRY TOTAL UBAH HARGA DISKON MENJADI") <> 0 Then
            mMohon1 = "ENTRY TOTAL UBAH HARGA DISKON MENJADI"
            mMohon2 = "EM/APR/RH2"
        ElseIf InStr(mData1, "EM/APR/ST") <> 0 Or InStr(mData2, "OKE-SM ALASAN UBAH HARGA DISKON DAN UNIT") <> 0 Then
            mMohon1 = "OKE-SM ALASAN UBAH HARGA DISKON DAN UNIT"
            mMohon2 = "EM/APR/ST"
        ElseIf InStr(mData1, "EM/APR/KH") <> 0 Or InStr(mData2, "ENTRY ALASAN PERMOHONAN KIRIM UNIT KURANG 2 HARI") <> 0 Then
            mMohon1 = "ENTRY ALASAN PERMOHONAN KIRIM UNIT KURANG 2 HARI"
            mMohon2 = "EM/APR/KH"
        ElseIf InStr(mData1, "EM/APR/KL") <> 0 Or InStr(mData2, "ENTRY ALASAN PERMOHONAN KIRIM BELUM LUNAS") <> 0 Then
            mMohon1 = "ENTRY ALASAN PERMOHONAN KIRIM BELUM LUNAS"
            mMohon2 = "EM/APR/KL"
        ElseIf InStr(mData1, "WB/APR/TU") <> 0 Or InStr(mData2, "ENTRY ALASAN GANTI TIPE KENDARAAN") <> 0 Then
            mMohon1 = "ENTRY ALASAN GANTI TIPE KENDARAAN"
            mMohon2 = "WB/APR/TU"
        ElseIf InStr(mData1, "WB/APR/WU") <> 0 Or InStr(mData2, "ENTRY ALASAN GANTI WARNA KENDARAAN") <> 0 Then
            mMohon1 = "ENTRY ALASAN GANTI WARNA KENDARAAN"
            mMohon2 = "WB/APR/WU"
        ElseIf InStr(mData1, "WB/APR/KO") <> 0 Or InStr(mData2, "ENTRY ALASAN KOMISI") <> 0 Then
            mMohon1 = "ENTRY ALASAN KOMISI"
            mMohon2 = "WB/APR/KO"
        ElseIf InStr(mData1, "WB/APR/SI") <> 0 Or InStr(mData2, "ENTRY ALASAN SUBSIDI") <> 0 Then
            mMohon1 = "ENTRY ALASAN SUBSIDI"
            mMohon2 = "WB/APR/SI"
        ElseIf InStr(mData1, "WB/APR/DO") <> 0 Or InStr(mData2, "ENTRY ALASAN DO/ISI NOMOR RANGKA") <> 0 Then
            mMohon1 = "ENTRY ALASAN DO/ISI NOMOR RANGKA"
            mMohon2 = "WB/APR/DO"
        ElseIf InStr(mData1, "WB/APR/AS") <> 0 Or InStr(mData2, "ENTRY TAMBAH AKSESORIS") <> 0 Then
            mMohon1 = "ENTRY TAMBAH AKSESORIS"
            mMohon2 = "WB/APR/AS"
        ElseIf InStr(mData1, "WB/APR/RS") <> 0 Or InStr(mData2, "ENTRY RUBAH KODE SALES") <> 0 Then
            mMohon1 = "ENTRY RUBAH KODE SALES"
            mMohon2 = "WB/APR/RS"
        ElseIf InStr(mData1, "WB/APR/SD") <> 0 Or InStr(mData2, "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON") <> 0 Then
            mMohon1 = "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON"
            mMohon2 = "WB/APR/SD"
        ElseIf InStr(mData1, "WB/APR/FT") <> 0 Or InStr(mData2, "ENTRY ALASAN PEMBUATAN FAKTUR") <> 0 Then
            mMohon1 = "ENTRY ALASAN PEMBUATAN FAKTUR"
            mMohon2 = "WB/APR/FT"
        End If
        If mTipe = "JUDUL" Then
            cari_kode_mohon = mMohon1
        Else
            cari_kode_mohon = mMohon2
        End If
    End Function

    'layar End penngajuann permohonan



    Protected Sub ButtonSetuju0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetuju0.Click
        If Periksa_SPK_Gantung() = 1 Then
            lblTglsetuju0.Text = "Persetujuan tidak bisa dilanjutkan karena Ada SPK Gantung belum ada status kelanjutanya (Lihat di Status SPK)"
        Else
            Call Rubah_Status("SETUJU", 0)
        End If
    End Sub
    Protected Sub BtnTolak0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTolak0.Click
        Call Rubah_Status("TOLAK", 0)
    End Sub

    Protected Sub ButtonSetuju1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetuju1.Click
        Call Rubah_Status("SETUJU", 1)
    End Sub
    Protected Sub BtnTolak1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTolak1.Click
        Call Rubah_Status("TOLAK", 1)
    End Sub

    Protected Sub ButtonSetuju2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetuju2.Click
        Call Rubah_Status("SETUJU", 2)
    End Sub
    Protected Sub BtnTolak2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTolak2.Click
        Call Rubah_Status("TOLAK", 2)
    End Sub

    Protected Sub BtnSetuju3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetuju3.Click
        Call Rubah_Status("SETUJU", 3)
    End Sub
    Protected Sub BtnTolak3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTolak3.Click
        Call Rubah_Status("TOLAK", 3)
    End Sub

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
                Call GetDataRangka_TYPE("SELECT * FROM DATA_TYPE WHERE TYPE_Type='" & LblCdType.Text & "'")
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
                ElseIf CheckAksesoris.Checked = True And GetValidasi_Asesoris("SELECT * FROM TRXN_OPTPO WHERE OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_STATUSPROSES LIKE 'ENTRY%'", "OPT_TIPE") = 1 Then
                    mError = mError & ("Ada tipe unit Aksesoris Tidak sama dengan Tipe SPK.....")
                End If
            ElseIf InStr(lblPolcyNomorMohon.Text, "WB/APR/FT") <> 0 Then 'Pengajuan DO 
                'If LblCatatanUM.Text <> "" Then
                'mError = mError & ("Ada Kesalahan di uang muka.....")
                'End If
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
            ElseIf (MultiView0S.ActiveViewIndex = 0 And lblTglsetuju0.Text = "") Or _
                   (MultiView1S.ActiveViewIndex = 0 And lblTglSetuju1.Text = "") Then
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
                'ElseIf TxtDisetujuiTahun.Text <> "" And IsNumeric(TxtDisetujuiTahun.Text) = False Then
                '    mError = mError & ("Isi nilai Tahun dengan tipe numerik")
            Else
                mIsi = TxtCatatan3.Text
                mPos = "3"
            End If
        End If

        If mError = "" And mPos <> "" Then
            If MultiViewENTRY.ActiveViewIndex = 0 Then
                If ChkBox1.Checked = True And ChkBox1.Text = "" Then Call UpdateDataMohon(Lbl01Mhn.Text, Lbl01Judul.Text, Lbl01Alasan.Text, mStatus, mIsi, mPos, 1)
                If ChkBox2.Checked = True And ChkBox2.Text = "" Then Call UpdateDataMohon(Lbl02Mhn.Text, Lbl02Judul.Text, Lbl02Alasan.Text, mStatus, mIsi, mPos, 2)
                If ChkBox3.Checked = True And ChkBox3.Text = "" Then Call UpdateDataMohon(Lbl03Mhn.Text, Lbl03Judul.Text, Lbl03Alasan.Text, mStatus, mIsi, mPos, 3)
                If ChkBox4.Checked = True And ChkBox4.Text = "" Then Call UpdateDataMohon(Lbl04Mhn.Text, Lbl04Judul.Text, Lbl04Alasan.Text, mStatus, mIsi, mPos, 4)
                If ChkBox5.Checked = True And ChkBox5.Text = "" Then Call UpdateDataMohon(Lbl05Mhn.Text, Lbl05Judul.Text, Lbl05Alasan.Text, mStatus, mIsi, mPos, 5)
                If ChkBox6.Checked = True And ChkBox6.Text = "" Then Call UpdateDataMohon(Lbl06Mhn.Text, Lbl06Judul.Text, Lbl06Alasan.Text, mStatus, mIsi, mPos, 6)
                If ChkBox7.Checked = True And ChkBox7.Text = "" Then Call UpdateDataMohon(Lbl07Mhn.Text, Lbl07Judul.Text, Lbl07Alasan.Text, mStatus, mIsi, mPos, 7)
                If ChkBox8.Checked = True And ChkBox8.Text = "" Then Call UpdateDataMohon(Lbl08Mhn.Text, Lbl08Judul.Text, Lbl08Alasan.Text, mStatus, mIsi, mPos, 8)
                If ChkBox9.Checked = True And ChkBox9.Text = "" Then Call UpdateDataMohon(Lbl09Mhn.Text, Lbl09Judul.Text, Lbl09Alasan.Text, mStatus, mIsi, mPos, 9)
                If ChkBox10.Checked = True And ChkBox10.Text = "" Then Call UpdateDataMohon(Lbl10Mhn.Text, Lbl10Judul.Text, Lbl10Alasan.Text, mStatus, mIsi, mPos, 10)

            ElseIf MultiViewENTRY.ActiveViewIndex = 1 Then
                If (MultiViewSetujuFaktur.ActiveViewIndex <> 0 And MultiViewSetujuRangka.ActiveViewIndex <> 0) And _
                    MultiViewSetujuAsesoris.ActiveViewIndex = 0 Then 'Aksesoris
                    Call UpdateDataMohonAksesoris(lblPolcyNomorMohon.Text, lblPolcyJudul.Text, lblPolcyAlasan.Text, mStatus, mIsi, mPos, 0)
                ElseIf MultiViewSetujuRangka.ActiveViewIndex = 0 Then 'DO
                    Call UpdateDataMohon(lblPolcyNomorMohon.Text, lblPolcyJudul.Text, lblPolcyAlasan.Text, mStatus, mIsi, mPos, 99)
                    If CheckAksesoris.Checked = False Then
                        Call UpdateDataMohonAksesoris(lblPolcyNomorMohon.Text, lblPolcyJudul.Text, lblPolcyAlasan.Text, mStatus, mIsi, mPos, 1)
                    End If
                ElseIf MultiViewSetujuFaktur.ActiveViewIndex = 0 Then 'Faktur
                    Call UpdateDataMohon(lblPolcyNomorMohon.Text, lblPolcyJudul.Text, lblPolcyAlasan.Text, mStatus, mIsi, mPos, 99)
                Else
                    Call UpdateDataMohon(lblPolcyNomorMohon.Text, lblPolcyJudul.Text, lblPolcyAlasan.Text, mStatus, mIsi, mPos, 99)
                End If
            End If
        Else
            Call Msg_err(mError, "LIHAT")
        End If
    End Sub


    Function UpdateDataMohon(ByVal mIdNo As String, ByVal mEntry As String, ByVal mAlasan As String, ByVal mSetujuTolak As String, ByVal mCatatan As String, ByVal mPosisi As String, ByVal mBaRIS As Byte) As Byte
        Call Msg_err("", "")
        UpdateDataMohon = 0
        Dim mNomorSPKAH_SqlUpdate As String
        mNomorSPKAH_SqlUpdate = lblNomorSetuju.Text
        If mPosisi = "0" And lblTglsetuju0.Text = "" Then
            lblTglsetuju0.Text = UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi)
        ElseIf mPosisi = "1" And lblTglSetuju1.Text = "" Then
            lblTglSetuju1.Text = UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi)
        ElseIf mPosisi = "2" And lblTglSetuju2.Text = "" Then
            lblTglSetuju2.Text = UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi)
        ElseIf mPosisi = "3" And LblTglSetuju3.Text = "" Then
            LblTglSetuju3.Text = UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi)
        ElseIf mBaRIS <> 99 And lblTglsetuju0.Text <> "" Then
            UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi)
        End If

        If lblNomorSetuju.Text <> "" Then
            Dim mChangeHarga As String = ""
            If MultiViewENTRY.ActiveViewIndex = 1 Then
                If InStr(mIdNo, "WB/APR/SD") <> 0 Then  'Setuju Diskon
                    'mChangeHarga = ",CHANGE='" & TxtDisetujuiHrgUnit.Text & "',CHANGE1='" & TxtDisetujuiHrgDisc.Text & "',CHANGE2='" & TxtDisetujuiHrgSubs.Text & "',CHANGE3='" & TxtDisetujuiHrgKoms.Text & "' "
                    mChangeHarga = ",CHANGE1='" & TxtDisetujuiHrgDisc.Text & "',CHANGE2='" & TxtDisetujuiHrgSubs.Text & "',CHANGE3='" & TxtDisetujuiHrgKoms.Text & "',CHANGE4='" & TxtDisetujuiTahun.Text & "' "
                ElseIf InStr(mIdNo, "WB/APR/FT") <> 0 Then 'Setuju Faktur
                    If UpdateData_Tabel("UPDATE TRXN_SPKAF SET SPKAF_NOMOR='" & lblNomorSetuju.Text & "' WHERE SPKAF_NOMORMOHON = '" & mIdNo & "' AND SPKAF_NOMOR=''") = 1 Then
                        Call TandaResult(mBaRIS, mSetujuTolak)
                    End If
                    'mChangeHarga = ",CHANGE='" & TxtDisetujuiNoRangka.Text & "' "
                ElseIf InStr(mIdNo, "WB/APR/DO") <> 0 Then 'Setuju Faktur
                    If TxtDisetujuiNoRangka.Text = lblDisetujuiNoRangkaTmp.Text And _
                       lblDisetujuiNoRangkaTmp.Text <> "" And _
                       lblDisetujuiNoRangka.Text <> lblDisetujuiNoRangkaTmp.Text Then
                        mChangeHarga = ",CHANGE='" & TxtDisetujuiNoRangka.Text & "',TANGGAL_PROSES=NULL "
                    End If
                End If
            End If
            'ada ganti
            If mNomorSPKAH_SqlUpdate = "" Or (mNomorSPKAH_SqlUpdate <> "" And mBaRIS <> 99) Then
                mNomorSPKAH_SqlUpdate = "UPDATE TRXN_SPKAH SET APPROVALCODEP='" & lblPosSetuju.Text & mPosisi & "'" & mChangeHarga & ",NOMOR='" & lblNomorSetuju.Text & "' WHERE TRXN_SPKAH.NOMOR_MOHON = '" & mIdNo & "' AND NOMOR_SPK='" & LblNoSPK.Text & "' AND CABANG='" & lblDealer.Text & "'"
            Else
                mNomorSPKAH_SqlUpdate = "UPDATE TRXN_SPKAH SET APPROVALCODEP='" & lblPosSetuju.Text & mPosisi & "'" & mChangeHarga & " WHERE TRXN_SPKAH.NOMOR_MOHON = '" & mIdNo & "' AND NOMOR_SPK='" & LblNoSPK.Text & "' AND CABANG='" & lblDealer.Text & "' AND NOMOR='" & lblNomorSetuju.Text & "'"
            End If

            If UpdateData_Tabel(mNomorSPKAH_SqlUpdate) = 1 Then
                Call TandaResult(mBaRIS, mSetujuTolak)
            End If

            Dim mPosTerakhir As String
            mPosTerakhir = ""
            If MultiView3S.ActiveViewIndex = 0 Then
                mPosTerakhir = "3"
            ElseIf MultiView2S.ActiveViewIndex = 0 Then
                mPosTerakhir = "2"
            ElseIf MultiView1S.ActiveViewIndex = 0 Then
                mPosTerakhir = "1"
            ElseIf MultiView0S.ActiveViewIndex = 0 Then
                mPosTerakhir = "0"
            End If
            If mPosTerakhir = mPosisi Or mSetujuTolak = "TOLAK" Then
                Call Update_Tabel_SPKAH_Keputusan_Terakhir(mIdNo, mEntry, mSetujuTolak, mCatatan, mPosisi)
            End If
            If mPosTerakhir = "3" And mPosisi = "1" And mSetujuTolak = "SETUJU" And InStr(mIdNo, "WB/APR/SD") <> 0 Then

                Call SendEmailProces("Susanto.soetrisno@gmail.com", "Permohonan persetujuan melebihi Diskon tgl " & Now() & " NOMOR " & lblNomorSetuju.Text, "", "", "Permohonan persetujuan melebihi Diskon tgl " & Now())
                Call SendEmailProces("Susantosoetrisno@yahoo.com", "Permohonan persetujuan melebihi Diskon tgl " & Now() & " NOMOR " & lblNomorSetuju.Text, "", "", "Permohonan persetujuan melebihi Diskon tgl " & Now())

            End If
        End If
    End Function

    Function UpdateDataMohonAksesoris(ByVal mIdNo As String, ByVal mEntry As String, ByVal mAlasan As String, ByVal mSetujuTolak As String, ByVal mCatatan As String, ByVal mPosisi As String, ByVal mMode As Byte) As Byte
        Call Msg_err("", "")
        UpdateDataMohonAksesoris = 0

        Dim mPosTerakhir As String
        Dim mTxtSql As String
        mPosTerakhir = ""
        If MultiView3S.ActiveViewIndex = 0 Then
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
        If mPosisi = "0" And mMode = 0 Then
            Dim mReasonProsesSPV As String = IIf(mSetujuTolak = "TOLAK", ",OPT_STATUSPROSES='TOLAK-D'", "")
            mTxtSql = "UPDATE TRXN_OPTPO SET OPT_TGLAPPV1=GETDATE(),OPT_CATATAN1='" & TxtPetik(mCatatan) & "',OPT_STATUSAPPV1='" & mReason & "',OPT_APPROVALCODEP='0'" & mReasonProsesSPV & " " & _
                      "WHERE OPT_STATUSPROSES='ENTRY' AND OPT_USERAPPV1='" & LblUserName.Text & "' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV1 IS NULL AND OPT_TGLAPPV2 IS NULL"
        ElseIf mPosisi = "1" And mMode = 0 Then
            Dim mReasonProsesSM As String = IIf(mSetujuTolak = "TOLAK", ",OPT_STATUSPROSES='TOLAK-D'", ",OPT_STATUSPROSES='SETUJU-A'")
            mTxtSql = "UPDATE TRXN_OPTPO SET OPT_TGLAPPV2=GETDATE(),OPT_CATATAN2='" & TxtPetik(mCatatan) & "',OPT_STATUSAPPV2='" & mReason & "',OPT_APPROVALCODEP='01'" & mReasonProsesSM & " " & _
                      "WHERE OPT_STATUSPROSES='ENTRY' AND OPT_USERAPPV2='" & LblUserName.Text & "' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV2 IS NULL "
        ElseIf mPosisi = "0" And mMode = 1 Then
            mTxtSql = "UPDATE TRXN_OPTPO SET OPT_TGLAPPV1=GETDATE(),OPT_CATATAN1='" & TxtPetik(mCatatan) & "',OPT_STATUSAPPV1='" & mReason & "',OPT_APPROVALCODEP='0' " & _
                      "WHERE OPT_STATUSPROSES='ENTRY' AND OPT_USERAPPV1='" & LblUserName.Text & "' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV1 IS NULL AND OPT_TGLAPPV2 IS NULL"
        ElseIf mPosisi = "1" And mMode = 1 Then
            Dim mReasonProsesSMDO As String = IIf(mSetujuTolak = "TOLAK", "", ",OPT_STATUSPROSES='SETUJU-D'")
            mTxtSql = "UPDATE TRXN_OPTPO SET OPT_TGLAPPV2=GETDATE(),OPT_CATATAN2='" & TxtPetik(mCatatan) & "',OPT_STATUSAPPV2='" & mReason & "',OPT_APPROVALCODEP='01'" & mReasonProsesSMDO & _
                      "WHERE OPT_STATUSPROSES='ENTRY' AND OPT_USERAPPV2='" & LblUserName.Text & "' AND OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_TGLAPPV2 IS NULL "
        End If

        If mTxtSql <> "" Then
            If UpdateData_Tabel(mTxtSql) = 1 Then
                If mPosisi = "0" And lblTglsetuju0.Text = "" Then
                    lblTglsetuju0.Text = Now() & "/" & LblUserName.Text & "/" & mReason
                ElseIf mPosisi = "1" And lblTglSetuju1.Text = "" Then
                    lblTglSetuju1.Text = Now() & "/" & LblUserName.Text & "/" & mReason
                ElseIf mPosisi = "2" And lblTglSetuju2.Text = "" Then
                    lblTglSetuju2.Text = Now() & "/" & LblUserName.Text & "/" & mReason
                ElseIf mPosisi = "3" And LblTglSetuju3.Text = "" Then
                    LblTglSetuju3.Text = Now() & "/" & LblUserName.Text & "/" & mReason
                End If
            End If
        End If
        'M=grouping yg hendah disetujui oleh SPV SETUJU IS NULL

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

    Function UpdateSetujuDataUser(ByVal mpIdMohon As String, ByVal mREASON As String, ByVal mCatat As String, ByVal mPos As String) As String
        Call Msg_err("", "")
        UpdateSetujuDataUser = ""
        If lblNomorSetuju.Text = "" Then
            lblNomorSetuju.Text = GetData_Nomor()
        End If
        If lblNomorSetuju.Text <> "" Then
            mCatat = LblUserName.Text & "/" & mCatat
            If UpdateData_Tabel("INSERT INTO TRXN_SPKAS " & _
                                "(SETUJU_NOMOR,SETUJU_POS,SETUJU_ENTRY,SETUJU_USER,SETUJU_STATUS,SETUJU_CATATAN) VALUES ('" & _
                                lblNomorSetuju.Text & "','" & mPos & "',GETDATE(),'" & LblUserName.Text & "','" & _
                                IIf(mREASON = "TOLAK", "0", "1") & "','" & mCatat & "')") = 1 Then
                UpdateSetujuDataUser = Now() & "/" & LblUserName.Text & "/" & mREASON
            End If
        End If
    End Function

    Function Update_Tabel_SPKAH_Keputusan_Terakhir(ByVal mIdnom As String, ByVal mKetENtry As String, ByVal Reason As String, ByVal mCatat As String, ByVal mPos As String) As Byte
        Call Msg_err("", "")
        If Reason = "" Then
            If UpdateData_Tabel("UPDATE TRXN_SPKAH SET APPROVALCODEP='" & lblPosSetuju.Text & mPos & "' WHERE NOMOR='" & mIdnom & "'") = 1 Then
                'LblOlehSetuju0.Text = LblOlehSetuju0.Text & mPos
            End If
        Else
            Dim mIsis As String
            Dim mUpdateChange As String = ""

            mIsis = Replace(mKetENtry, "ENTRY", Reason)

            Update_Tabel_SPKAH_Keputusan_Terakhir = _
            UpdateData_Tabel("UPDATE TRXN_SPKAH SET " & _
                             "TANGGAL_SETUJU=GETDATE()," & _
                             "APPROVALCODEP='" & lblPosSetuju.Text & mPos & "'," & _
                             "JUDUL='" & mIsis & "'," & _
                             IIf(InStr(mIdnom, "WB/APR/SD") <> 0, "CHANGE1='" & TxtDisetujuiHrgDisc.Text & "',", "") & _
                             IIf(InStr(mIdnom, "WB/APR/SD") <> 0, "CHANGE2='" & TxtDisetujuiHrgSubs.Text & "',", "") & _
                             IIf(InStr(mIdnom, "WB/APR/SD") <> 0, "CHANGE3='" & TxtDisetujuiHrgKoms.Text & "',", "") & _
                             IIf(InStr(mIdnom, "WB/APR/SD") <> 0, "CHANGE4='" & TxtDisetujuiTahun.Text & "',", "") & _
                             "CATATAN='" & TxtPetik(mCatat) & "' " & _
                             "WHERE NOMOR_MOHON='" & mIdnom & "' AND JUDUL='" & mKetENtry & "'")
        End If
    End Function

    Function Update_Tabel_SPKH_HARGA(ByVal mIdnom As String, ByVal mKetENtry As String, ByVal Reason As String, ByVal mCatat As String, ByVal mPos As String) As Byte
        Call Msg_err("", "")
        If Reason = "" Then
            If UpdateData_Tabel("UPDATE TRXN_SPKAH SET APPROVALCODEP='" & lblPosSetuju.Text & mPos & "' WHERE NOMOR='" & mIdnom & "'") = 1 Then
                'LblOlehSetuju0.Text = LblOlehSetuju0.Text & mPos
            End If
        Else
            Dim mIsis As String
            mIsis = Replace(mKetENtry, "ENTRY", Reason)
            Update_Tabel_SPKH_HARGA = UpdateData_Tabel("UPDATE TRXN_SPKAH SET " & _
                                      "TANGGAL_SETUJU=GETDATE()," & _
                                      "APPROVALCODEP='" & lblPosSetuju.Text & mPos & "'," & _
                                      "JUDUL='" & mIsis & "'," & _
                                      IIf(InStr("123", mPos) <> 0, "CHANGE1='" & TxtDisetujuiHrgDisc.Text & "',", "") & _
                                      IIf(InStr("123", mPos) <> 0, "CHANGE2='" & TxtDisetujuiHrgSubs.Text & "',", "") & _
                                      IIf(InStr("123", mPos) <> 0, "CHANGE3='" & TxtDisetujuiHrgKoms.Text & "',", "") & _
                                      IIf(InStr("123", mPos) <> 0, "CHANGE4='" & TxtDisetujuiTahun.Text & "',", "") & _
                                      "CATATAN='" & TxtPetik(mCatat) & "' " & _
                                      "WHERE NOMOR_MOHON='" & mIdnom & "' AND JUDUL='" & mKetENtry & "'")
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
            Call UpdateData_Tabel("DELETE TRXN_SPKAH WHERE NOMOR_MOHON LIKE 'EM/APR/WB/TTK%'")
            If mReason = "TOLAK" Then
                Call UpdateData_Tabel("UPDATE TRXN_STOCKAREPAIR SET " & _
                                      "ASSREPAIR_TGLSETUJU=NULL," & _
                                      "ASSREPAIR_NOSETUJU='" & mReason & "'," & _
                                      "ASSREPAIR_KETERANGAN='" & Left("TOLAK:" & TxtWHCatatan.Text, 30) & "'," & _
                                      "ASSREPAIR_TGLWO=GETDATE()," & _
                                      "ASSREPAIR_TGLEMAILSTJ=GETDATE() " & _
                                      "WHERE ASSREPAIR_NORANGKA='" & LblWHNoRangka.Text & "' AND ASSREPAIR_TGLEMAIL IS NOT NULL AND " & _
                                      "(ASSREPAIR_NOSETUJU='' OR ASSREPAIR_NOSETUJU IS NULL) AND ASSREPAIR_RINCIAN='" & Trim(LblWHDetailKerjaan.Text) & "'")
            Else
                Call UpdateData_Tabel("UPDATE TRXN_STOCKAREPAIR SET " & _
                                      "ASSREPAIR_TGLSETUJU=GETDATE()," & _
                                      "ASSREPAIR_NOSETUJU='" & mReason & "'," & _
                                      "ASSREPAIR_KETERANGAN='" & Left("" & TxtWHCatatan.Text, 30) & "' " & _
                                      "WHERE ASSREPAIR_NORANGKA='" & LblWHNoRangka.Text & "' AND ASSREPAIR_TGLEMAIL IS NOT NULL AND " & _
                                      "(ASSREPAIR_NOSETUJU='' OR ASSREPAIR_NOSETUJU IS NULL) AND ASSREPAIR_RINCIAN='" & Trim(LblWHDetailKerjaan.Text) & "'")

            End If
        Else
            mlbrerro = mlbrerro & Chr(13) & ("Status Persetujuan belum berubah")
        End If
        If mlbrerro <> "" Then
            Call Msg_err(mlbrerro, "")
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

    End Sub

    Protected Sub Button3_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call UpdateDataMohon_BodyrepairWareHouse("SETUJU", 0)
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call UpdateDataMohon_BodyrepairWareHouse("TOLAK", 0)
    End Sub

    Protected Sub Button5_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Call Msg_err("", "")
        LVRepairWH.DataBind()
        MultiView11a.ActiveViewIndex = 2
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
                mCriteria = GetDataRangka_TYPE("SELECT * FROM DATA_TYPE WHERE TYPE_Type='" & LblCdType.Text & "'")
                If mCriteria <> "" Then
                    If IsNumeric(lblTahun.Text) Then
                        If Val(lblTahun.Text) >= 10 And Val(lblTahun.Text) <= 26 Then
                            mTahun = Mid("ABCDEFGHIJKLMNOPQRSTUVWXYZ", Val(lblTahun.Text) - 9, 1)
                        End If
                    End If
                    If mTahun <> "" Then
                        mCriteria = mCriteria & Mid("_______", 1, 6 - Len(mCriteria)) & mTahun
                        mCriteria = " AND TYPED_RANGKA LIKE '%" & mCriteria & "%'"
                    End If
                End If
            End If
            If mCriteria <> "" Then
                LblMaxDisc.Text = GetDataMaxDisc_TYPE("SELECT * FROM DATA_TYPED,DATA_TYPE WHERE  TYPED_TYPE=TYPE_TYPE AND TYPED_TYPE = '" & LblCdType.Text & "' AND DATEDIFF(DAY,TYPED_TANGGAL," & "'" & Format(CDate(mTanggal), "yyyy-MM-dd hh:mm:ss") & "'" & ") >= 0 " & mCriteria & " ORDER BY TYPED_TANGGAL DESC")
            End If
            If (Val(LblDisc.Text) + Val(LblKomisi.Text) - Val(LblSubsidi.Text)) > Val(LblMaxDisc.Text) Then
                LblNoteDiskon.Text = "Melebihi Ketentuan Diskon Maksimal"
            End If
        End If
    End Sub


    Function GetData_Tabel_SPKAH_Header(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetData_Tabel_SPKAH_Header = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Tabel_SPKAH_Header = IIf(MyRecReadA.HasRows = True, 1, 0)
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
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetData_Tabel_SPKAH_HeaderAsesoris(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetData_Tabel_SPKAH_HeaderAsesoris = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Tabel_SPKAH_HeaderAsesoris = IIf(MyRecReadA.HasRows = True, 1, 0)
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

    Function GetData_Tabel_SPKAH_Detail(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetData_Tabel_SPKAH_Detail = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Tabel_SPKAH_Detail = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                If Not (InStr(nSr(MyRecReadA("NOMOR_MOHON")), "WB/APR/SD") <> 0 Or _
                        InStr(nSr(MyRecReadA("NOMOR_MOHON")), "WB/APR/AS") <> 0 Or _
                        InStr(nSr(MyRecReadA("NOMOR_MOHON")), "WB/APR/FT") <> 0 Or _
                        InStr(nSr(MyRecReadA("NOMOR_MOHON")), "WB/APR/DO") <> 0) Then
                    Call insert_tabel(nSr(MyRecReadA("NOMOR_MOHON")), _
                                      nSr(MyRecReadA("JUDUL")), nSr(MyRecReadA("KETERANGAN")), _
                                      nSr(MyRecReadA("TANGGAL_ENTRY")), nSr(MyRecReadA("MYUSER")), nSr(MyRecReadA("CHANGE")), nSr(MyRecReadA("CHANGE1")), nSr(MyRecReadA("CHANGE2")), nSr(MyRecReadA("CHANGE3")))

                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetData_Tabel_SPKAH_Detail_PolcyDsikon(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetData_Tabel_SPKAH_Detail_PolcyDsikon = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Tabel_SPKAH_Detail_PolcyDsikon = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                lblPolcyNomorMohon.Text = nSr(MyRecReadA("NOMOR_MOHON"))
                lblPolcyJudul.Text = nSr(MyRecReadA("JUDUL"))
                lblPolcyAlasan.Text = nSr(MyRecReadA("KETERANGAN"))
                lblPolcyTanggal.Text = nSr(MyRecReadA("TANGGAL_ENTRY"))
                LblMohon.Text = nSr(MyRecReadA("TANGGAL_PROSES"))
                lblPolcyUser.Text = nSr(MyRecReadA("MYUSER"))
                TxtDisetujuiNoRangka.Text = nSr(MyRecReadA("CHANGE"))
                lblDisetujuiNoRangka.Text = TxtDisetujuiNoRangka.Text

                TxtDisetujuiTahun.Text = ""
                TxtDisetujuiHrgDisc.Text = "0"
                TxtDisetujuiHrgSubs.Text = "0"
                TxtDisetujuiHrgKoms.Text = "0"
                If InStr(nSr(MyRecReadA("NOMOR_MOHON")), "WB/APR/SD") <> 0 Then
                    lblDisetujuiHrgUnit.Text = LblHarga.Text
                    'If nSr(MyRecReadA("CHANGE")) <> "" Then
                    ' lblDisetujuiTahun.Text = nSr(MyRecReadA("CHANGE"))
                    'End If
                    If nSr(MyRecReadA("CHANGE1")) <> "" Then
                        TxtDisetujuiHrgDisc.Text = nSr(MyRecReadA("CHANGE1"))
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
                Else
                    TxtDisetujuiTahun.Text = lblTahun.Text
                    lblDisetujuiHrgUnit.Text = LblHarga.Text
                    TxtDisetujuiHrgDisc.Text = LblDisc.Text
                    TxtDisetujuiHrgSubs.Text = LblSubsidi.Text
                    TxtDisetujuiHrgKoms.Text = LblKomisi.Text
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetData_Tabel_SPKAD(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetData_Tabel_SPKAD = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Tabel_SPKAD = IIf(MyRecReadA.HasRows = True, 1, 0)
            LblDisc.Text = "0" : LblKomisi.Text = "0" : LblSubsidi.Text = "0" : LblJns0.Text = "" : lblRoad.Text = ""
            LblAksesorisHdiary.Text = ""
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

            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetData_Tabel_SPKAS(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetData_Tabel_SPKAS = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Tabel_SPKAS = IIf(MyRecReadA.HasRows = True, 1, 0)
            Dim mPos As String
            Dim mCatatan1 As String
            While MyRecReadA.Read()
                mPos = nSr(MyRecReadA("SETUJU_POS"))
                mCatatan1 = nSr(MyRecReadA("SETUJU_ENTRY")) & "/" & _
                                nSr(MyRecReadA("SETUJU_USER")) & "/" & _
                                IIf(nSr(MyRecReadA("SETUJU_STATUS")) = "1", "SETUJU", "DITOLAK")
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
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try

    End Function
    Function GetData_Tabel_WAREHOUSE(ByVal mSqlCommadstring As String, ByVal mNoWO As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetData_Tabel_WAREHOUSE = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Tabel_WAREHOUSE = IIf(MyRecReadA.HasRows = True, 1, 0)
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
                If InStr(nSr(MyRecReadA("KETERANGAN")), "SPK_SETUJU1") <> 0 Then
                    lblTglSetuju1.Text = nSr(MyRecReadA("KETERANGAN"))
                    TxtCatatan1.Text = nSr(MyRecReadA("NILAI"))
                End If

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
        GetData_Nomor = GetData_SearchNomor()
        If GetData_Nomor <> "" Then
            If GetData_Nomor = "NO FOUND" Then
                GetData_Nomor = GetData_StartNomor()
            End If
        End If
        If GetData_Nomor = "" Then
            Call Msg_err("DATA TIDAK BERHASIL DISIMPAN", "")
        End If
    End Function

    Function GetData_SearchNomor() As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String

        Call Msg_err("", "")
        GetData_SearchNomor = ""
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
                GetData_SearchNomor = "NO FOUND"
            Else
                MyRecReadA.Read()
                If nSr(MyRecReadA("mMaxNomor")) = "" Then
                    GetData_SearchNomor = "NO FOUND"
                Else
                    GetData_SearchNomor = Val(nSr(MyRecReadA("mMaxNomor"))) + 1
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetData_StartNomor() As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString

        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mSqlCommadstring As String
        Dim mFind As String

        Call Msg_err("", "")
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
                GetData_StartNomor = lblDealer.Text & _
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

    Function GetDataRangka_TYPE(ByVal mSqlCommadstring As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataRangka_TYPE = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                GetDataRangka_TYPE = (nSr(MyRecReadA("TYPE_CdRangka")))
                lblGroupTipe.Text = (nSr(MyRecReadA("TYPE_CdGroup")))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetDataMaxDisc_TYPE(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataMaxDisc_TYPE = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()
                GetDataMaxDisc_TYPE = Val(nSr(MyRecReadA("TYPED_Jumlah")))
                lblGroupTipe.Text = (nSr(MyRecReadA("TYPE_CdGroup")))
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function UpdateData_Tabel(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        UpdateData_Tabel = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_Tabel = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

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

    Function GetFindRecord_Tabel(ByVal mSqlCommadstring As String) As Integer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetFindRecord_Tabel = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                GetFindRecord_Tabel = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function Periksa_SPK_Gantung() As Byte
        Periksa_SPK_Gantung = 1
        Periksa_SPK_Gantung = GetFindRecord_Tabel("SELECT * FROM TRXN_SPKG WHERE " & _
                                                  "DATEDIFF(DAY,SPK_WarningTgl,GETDATE()) >= 7 AND " & _
                                                  "NOT(SPK_WarningStatus='0' OR SPK_WarningStatus='' OR SPK_WarningStatus IS NULL)")
    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call UpdateData_Tabel("UPDATE TRXN_SPKAH SET APPROVALCODEP='0' WHERE JUDUL like 'ENTRY%' AND CABANG='" & lblArea1.Text & "' AND APPROVALCODEP='' AND (SPV='SC' OR SPV='FZ' OR SPV='UG')")
        lvPersetujuan.DataBind()
        MultiView11a.ActiveViewIndex = 0
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call UpdateData_Tabel("UPDATE TRXN_OPTPO SET OPT_TGLAPPV1=GETDATE(),OPT_CATATAN1='SC',OPT_STATUSAPPV1='S',OPT_APPROVALCODEP='0' WHERE OPT_STATUSPROSES like 'ENTRY%' AND OPT_NODEALER='" & lblArea1.Text & "' AND (OPT_SPV='SC' OR OPT_SPV='FZ' OR OPT_SPV='UG') AND OPT_TGLAPPV1 IS NULL")
        LVPersetujuanAsesoris.DataBind()
        MultiView11a.ActiveViewIndex = 1
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
        If IsNumeric(nilai) Then nLg = Val(Format(nilai, "###############0")) '10
ErrHand:
    End Function


    Function UpdateData_Local_SPK(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        UpdateData_Local_SPK = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_Local_SPK = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
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

            Call UpdateData_Tabel("UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='ENTRY-D'  WHERE OPT_NOMORMOHON = '" & nNomor & "' AND OPT_STATUSPROSES='ENTRY'")
            Call UpdateData_Tabel("UPDATE TRXN_SPKAH SET TANGGAL_PROSES=NULL " & mChangeHarga & "  WHERE NOMOR_MOHON = '" & nNomor & "'")
            Call UpdateData_Tabel("DELETE FROM  TRXN_SPKAD WHERE NOMOR_MOHON= '" & nNomor & "'")
            Call UpdateData_Tabel("DELETE FROM  TRXN_SPKAHERR  WHERE SPKAHERR_NOM= '" & nNomor & "'")

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



    Function SendEmailProces(ByRef mEmailTo As Object, ByRef mJudul As Object, ByRef mFile As Object, ByRef mPath As Object, ByRef mSsage As Object) As Byte
        Dim strFrom As String = "hmugen1991@gmail.com"
        Try

            Using mm As New MailMessage(strFrom, mEmailTo)
                mm.Subject = mJudul
                mm.Body = mSsage
                mm.IsBodyHtml = False
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
            Call UpdateData_Tabel("UPDATE TRXN_OPTPO SET OPT_STATUSPROSES = '" & mResult & "' WHERE OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoSPK.Text & "' AND OPT_CDASS='" & mKode & "'  AND (OPT_STATUSPROSES like '%" & mKeterangan & "%')")
        End If
        LvAksesorisNonDO.DataBind()
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        If Mid(lblAkses.Text, 7, 1) = "1" Then
            LVRepairWH.DataBind()
            MultiView11a.ActiveViewIndex = 2
        Else
            Call Msg_err("Tidak diijinkan", "")
        End If
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
        Call GetData_Tabel_WAREHOUSE(mQuery, "")
        MultiView1a.ActiveViewIndex = 2
        MultiViewWH.ActiveViewIndex = 0

    End Sub


End Class
