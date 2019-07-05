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

'1: Input Sales
'2: ?
'3: Khusu Croselling

'mhndetail
'Admin
'MultiViewAssTabel
'Tombol

'                    CREATE TABLE [dbo].[TRXN_OPTPO](
'	[OPT_NODEALER] [nvarchar](3) NULL,'
'	[OPT_USER] [nvarchar](10) NULL,
'	[OPT_TGL] [smalldatetime] NULL,
'	[OPT_NOSPK] [nvarchar](6) NULL,
'	[OPT_TIPE] [nvarchar](3) NULL,
'	[OPT_CDASS] [nvarchar](4) NULL,
'	[OPT_STATUS] [nvarchar](1) NULL,
'	[OPT_HARGAJUAL] [float] NULL,
'	[OPT_HARGACUST] [float] NULL,
'	[OPT_KETERANGAN] [nvarchar](50) NULL,
'	[OPT_TGLAPPV1] [smalldatetime] NULL,
'	[OPT_STATUSAPPV1] [nvarchar](1) NULL,
'	[OPT_CATATAN1] [nvarchar](50) NULL,
'	[OPT_TGLAPPV2] [smalldatetime] NULL,
'	[OPT_STATUSAPPV2] [nvarchar](1) NULL,
'	[OPT_CATATAN2] [nvarchar](50) NULL,
'	[OPT_STATUSPROSES] [nvarchar](1) NULL,
'	[OPT_NOWO] [nvarchar](7) NULL
') ON [PRIMARY]
'DATA_STANDARD
'Kode 0102
'1 Cari
'2 Tambah adan hapus aksesoris

Partial Class Form02Aksesoris
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader
    Public MyRecReadB As OleDbDataReader
    Public MyRecReadC As OleDbDataReader
    Public MyRecReadD As OleDbDataReader
    Public MyRecReadF As OleDbDataReader
    Public mRk1, mRk2, mRk3, mRk4, mRk5, mRk6, mRk7, mRk8, mRk9, mRk0, mRk11 As String
    Dim mSaveButon As Byte
    Dim mErrorMySistem As String

    Dim RpDanaText As String
    Dim AsalSPKNamaText As String
    Dim AsalSPKNoText As String
    Dim TujuSPKNoText As String

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
            lblDealer.Text = ""
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = ucase(x.ToString)

            If Left(LblUserName.Text, 3) = "112" Or Left(LblUserName.Text, 3) = "128" Then
                mFound = GetDataA_UserSecurity("SELECT *,GETDATE() as mfTgl FROM DATA_SECURITYH,DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(SECURITYH_USER)=RTRIM(USER_NAMA) AND RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & Left(LblUserName.Text, 3) & "' AND SECURITYH_NOIDSALES='" & Right(LblUserName.Text, Len(LblUserName.Text) - 3) & "' AND USER_TIPE='WA' AND AKSES_MENU='0102'")
                If mFound = 1 Then
                    lblArea1.Text = Left(LblUserName.Text, 3)
                    lblArea2.Text = Left(LblUserName.Text, 3)
                    lblDealer.Text = lblArea1.Text

                End If
            Else
                mFound = GetDataA_UserSecurity("SELECT *,GETDATE() as mfTgl FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0102'")
                lblDealer.Text = lblArea1.Text
            End If
            LblUserName.Text = UCase(LblUserName.Text)

            LblTglSystem.Text = GetDataD_IsiField("SELECT GETDATE() as IsiField ", "", 0)

            If mFound = 1 Then
                MultiView3.ActiveViewIndex = 0
                MultiView1a.ActiveViewIndex = 2
                DropDownList1.Items.Clear()
                DropDownList1.Items.Add("NON")
                DropDownList1.Items.Add("BRI")
                DropDownList1.Items.Add("MOB")
                DropDownList1.Items.Add("BRV")
                DropDownList1.Items.Add("HRV")
                DropDownList1.Items.Add("CRV")
                DropDownList1.Items.Add("FRD")
                DropDownList1.Items.Add("CIT")
                DropDownList1.Items.Add("CIV")
                DropDownList1.Items.Add("ACC")
                DropDownList1.Items.Add("ODY")
                DropDownList1.Items.Add("CRZ")
                DropDownList1.Items.Add("JAZ")

                DropDownList2.Items.Clear()
                DropDownList2.Items.Add("BAYAR")
                DropDownList2.Items.Add("TIDAK BAYAR")

                DropDownList3.Items.Clear()
                Call GetDataA_AddlistTipePermohonan("SELECT * FROM DATA_PARAMETER WHERE PARAMETER_NAMA like 'APPRVL__0%' ORDER BY PARAMETER_NAMA")

                DropDownList4.Items.Clear()
                DropDownList4.Items.Add("ISLAM")
                DropDownList4.Items.Add("KATHOLIK")
                DropDownList4.Items.Add("KRISTEN")
                DropDownList4.Items.Add("BUDHA")
                DropDownList4.Items.Add("HINDU")
                DropDownList4.Items.Add("LAIN-LAIN")

                LblNoMohon.Text = ""
                [CalenderLahir].Visible = False
                [Calendar1Kirim].Visible = False
                [CalendarKirimMove].Visible = False
                [CalendarMoveTerima].Visible = False
                [CalendarMoveKembali].Visible = False
                MultiViewMhnMaster.ActiveViewIndex = 0
                Call DefinisTabelPindahDana()
                Dim dt As New DataTable()
                dt.Columns.AddRange(New DataColumn(11) {New DataColumn("Temp_Judul"), New DataColumn("Temp_TANGGAL_CREATE"), New DataColumn("Temp_TANGGAL_PROSES"), New DataColumn("Temp_NOMOR_MOHON"), New DataColumn("Temp_URUT"), New DataColumn("Temp_MYUSER"), New DataColumn("Temp_SPV"), New DataColumn("Temp_APPROVALCODE"), New DataColumn("Temp_APPROVALCODEP"), New DataColumn("Temp_CHANGE"), New DataColumn("Temp_KETERANGAN"), New DataColumn("Temp_SPKAHERR_DESC")})
                ViewState("Keluhan") = dt
                Me.BindGrid()
            Else
                MultiView3.ActiveViewIndex = -1
                MultiView1a.ActiveViewIndex = -1
                Call Msg_err("TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU ]", 0)
            End If
        End If
    End Sub
    Sub Msg_err(ByVal mTest As String, ByVal mErSystem As Byte)

        'Response.Write("<script>alert('" & mTest & "')</script>")

        lblMsgBox.Text = mTest
        lblerrorTombolSPK.Text = mTest
        lblErrorTombolAsesoris.Text = mTest
        If mTest = "" Then
            MultiViewError.ActiveViewIndex = 0
        Else
            MultiViewError.ActiveViewIndex = 0
        End If
        If mTest <> "" Then
            Response.Write("<script>alert('" & mTest & "')</script>")
        End If
        If mTest <> "" And mErSystem = 1 Then
            mErrorMySistem = mErrorMySistem & " " & mTest
        End If
    End Sub

    Protected Sub ButtonTgl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCalenderLahir.Click
        [CalenderLahir].Visible = True
    End Sub
    Protected Sub CalenderLahir_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [CalenderLahir].SelectionChanged
        TxtTglLahir.Text = [CalenderLahir].SelectedDate.ToString
        [CalenderLahir].Visible = False
    End Sub

    Protected Sub BtnCalendarKirim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCalenderKirim.Click
        [Calendar1Kirim].Visible = True
    End Sub
    Protected Sub Calendar1Kirim_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar1Kirim].SelectionChanged
        TxtKirimTgl.Text = [Calendar1Kirim].SelectedDate.ToString
        [Calendar1Kirim].Visible = False
    End Sub

    Protected Sub BtnKirimMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKirimMove.Click
        [CalendarKirimMove].Visible = True
    End Sub
    Protected Sub CalendarKirimMove_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [CalendarKirimMove].SelectionChanged
        TxtKirimMoveTgl.Text = [CalendarKirimMove].SelectedDate.ToString
        [CalendarKirimMove].Visible = False
    End Sub

    Protected Sub BtnMoveTerima_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKirimMove.Click
        [CalendarMoveTerima].Visible = True
    End Sub
    Protected Sub CalendarMoveTerima_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [CalendarMoveTerima].SelectionChanged
        TxtKirimMoveTerima.Text = [CalendarMoveTerima].SelectedDate.ToString
        [CalendarMoveTerima].Visible = False
    End Sub

    Protected Sub BtnMoveKembali_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMoveKembali.Click
        [CalendarMoveKembali].Visible = True
    End Sub

    Protected Sub CalendarMoveKembali_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [CalendarMoveKembali].SelectionChanged
        TxtKirimMoveKembali.Text = [CalendarKirimMove].SelectedDate.ToString
        [CalendarMoveKembali].Visible = False
    End Sub


    Protected Sub btnfilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfilter.Click
        MultiV1WAss.ActiveViewIndex = 0
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
        End If
        ViewState("PindahDana") = dt
        Me.BindGridPindahDana()
    End Sub
    Sub PermohonanFormNonAktif()

        MultiViewMhnMaster.ActiveViewIndex = -1
        MultiViewMhnDetail.ActiveViewIndex = -1
        MultiViewAdmin.ActiveViewIndex = -1

        MultiViewMhnInpDO.ActiveViewIndex = -1
        MultiViewMhnInpDONoDealer.ActiveViewIndex = -1
        MultiViewMhnInpDODealer.ActiveViewIndex = -1

        MultiViewMhnInpFaktur.ActiveViewIndex = -1
        MultiViewMhnInpHrgUnit.ActiveViewIndex = -1
        MultiViewMhnInpHrgDisc.ActiveViewIndex = -1
        MultiViewMhnInpHrgSubs.ActiveViewIndex = -1
        MultiViewMhnInpHrgKoms.ActiveViewIndex = -1
        MultiViewMhnNumerik.ActiveViewIndex = -1  '--------------->Dipakai Oleh Ubah Tahun unit, Seleisih Paket cermat,Seleisih Beda Tahun
        MultiViewMhnInpLain.ActiveViewIndex = -1
        MultiViewMhnDataPemohon.ActiveViewIndex = -1
        MultiViewMhnTglKirim.ActiveViewIndex = -1
        MultiViewMhnTglKirimSub.ActiveViewIndex = -1
        MultiViewMhnTglKirimPameran.ActiveViewIndex = -1

        MultiViewAssInputSPK.ActiveViewIndex = -1
        MultiViewAssTblStandard.ActiveViewIndex = -1
        MultiViewAssData.ActiveViewIndex = -1
        MultiUpdateDataAksesoris.ActiveViewIndex = -1
        MultiViewAssTombol.ActiveViewIndex = -1
        MultiViewAssTabel.ActiveViewIndex = -1
        MultiViewAssInpTabel.ActiveViewIndex = -1 : Button8.Visible = True : Button9.Visible = False
        MultiViewTombolSPK.ActiveViewIndex = -1
        MultiViewMhnTabelUbahSPK.ActiveViewIndex = -1
        MultiViewMhnTabelUbahSPKR1.ActiveViewIndex = -1

        MultiViewMhnInpLease.ActiveViewIndex = -1

    End Sub

    Protected Sub BtnOrderAss_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOrderAss.Click
        MultiView1a.ActiveViewIndex = 2
        Call ClearInputAsesoris()
        Call PermohonanFormNonAktif()
        MultiViewAssInputSPK.ActiveViewIndex = 0
        'MultiViewAssTblStandard.ActiveViewIndex = 0
        MultiViewAssData.ActiveViewIndex = 0
        MultiViewAssTombol.ActiveViewIndex = 0
        MultiViewAssTabel.ActiveViewIndex = 0

    End Sub

    Protected Sub BtnRubahSPK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRubahSPK.Click
        MultiView1a.ActiveViewIndex = 2

        Call PermohonanFormNonAktif()

        MultiViewMhnMaster.ActiveViewIndex = 0
        MultiViewMhnDataPemohon.ActiveViewIndex = 0
        MultiViewMhnTabelUbahSPK.ActiveViewIndex = 0
        MultiViewMhnTabelUbahSPKR1.ActiveViewIndex = 0
        Button3.Visible = False
        BtnSaveMohon.Visible = True
    End Sub

    Protected Sub BtnLihatAss_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLihatAss.Click
        MultiView1a.ActiveViewIndex = 0
    End Sub
    Protected Sub Button14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVirtualAccount.Click
        Call ClearInputDataVA()
        MultiView1a.ActiveViewIndex = 1
        MultiViewTabelVA.ActiveViewIndex = -1
    End Sub


    '================================Purchase order Aksesoris
    Protected Sub ButtonSimpan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSimpan.Click
        Dim mTxtInsert As String = ""
        Call Msg_err("", 0)
        LblErrorSave.Text = ""

        If nLg(TxtAksesorisQty.Text) <= 0 Then
            LblErrorSave.Text = "Jumlah Belum Diisi"
        End If

        If txtnospk.Text = "" Or DropDownList1.Text = "" Or LblAksesorisKode.Text = "" Then
            LblErrorSave.Text = "Isian Nomor SPK atau Tipe kendaraan belum lengkap atau Jenis"
        End If

        '        If (nLg(TxtAksesorisQty.Text) * nLg(TxtHargaAss.Text)) < (nLg(TxtAksesorisQty.Text) * nLg(LblAksesorisModal.Text)) And DropDownList2.Text = "BAYAR" And _
        '   nLg(TxtAksesorisQty.Text) <= 0 And nLg(TxtAksesorisQty.Text) = 1 Then

        If (nLg(TxtAksesorisQty.Text) * nLg(TxtHargaAss.Text)) < (nLg(TxtAksesorisQty.Text) * nLg(LblAksesorisModal.Text)) And DropDownList2.Text = "BAYAR" Then
            LblErrorSave.Text = LblErrorSave.Text & ",Harga Jual kurang dari harga jual standard "
        End If

        If nLg(LblAksesorisModal.Text) = 0 And DropDownList2.Text = "BAYAR" Then
            LblErrorSave.Text = LblErrorSave.Text & ",Harga Modal Standard Kosong "
        End If

        If nLg(TxtHargaAss.Text) = 0 And DropDownList2.Text = "BAYAR" Then
            LblErrorSave.Text = LblErrorSave.Text & ",Status Bayar Harga Jual Belum diisi "
        End If

        If LblWarna.Text <> "" And TxtCatatan.Text = "" Then
            LblErrorSave.Text = LblErrorSave.Text & ",Warna Belum diisi dicatatan "
        End If
        If LblErrorSave.Text <> "" Then
            Exit Sub
        End If
        LblApproved.Text = "01"
        'OPT_STATUSAPPV1
        'OPT_STATUSPROSES=    
        '                  ENTRY-D : Minta Data, 
        '                  ENTRY   : Sudah Di Ambil
        '                  TOLAK   : Ditolak
        '                  SETUJU-D: Setuju belum ditarik WO
        '                  SETUJU  : Setuju Sudah ditarik WO

        'OPT_USERAPPV1='', OPT_USERAPPV2=''
        LblNoMohon.Text = lblArea1.Text & "/" & txtnospk.Text & "/" & "WB/APR/AS"


        mTxtInsert = "SELECT * FROM TRXN_OPTPO WHERE OPT_NODEALER='" & lblArea1.Text & "' AND OPT_NOSPK='" & txtnospk.Text & "' AND OPT_CDASS='" & LblAksesorisKode.Text & "' AND (OPT_STATUSPROSES like '%ENTRY%' OR OPT_STATUSPROSES like '%SETUJU%')"
        If GetDataD_00NoFound01Found(mTxtInsert, "", 0) = 1 Then
            Call Msg_err("AKSESORIS INI SUDAH DISETUJUI ATAU DALAM PROSES PENGAJUAN (ENTRY)", 0)
        Else
            mTxtInsert = "INSERT INTO TRXN_OPTPO " & _
                         "(OPT_NOMORMOHON,OPT_NOMOR,OPT_NODEALER,OPT_USER,OPT_SPV,OPT_TGL,OPT_NOSPK,OPT_TIPE," & _
                         " OPT_CDASS,OPT_STATUS,OPT_QTY,OPT_HARGAJUAL,OPT_HARGACUST,OPT_KETERANGAN," & _
                         " OPT_TGLAPPV1,OPT_STATUSAPPV1,OPT_CATATAN1,OPT_USERAPPV1,OPT_TGLAPPV2,OPT_STATUSAPPV2,OPT_CATATAN2,OPT_USERAPPV2,OPT_STATUSPROSES,OPT_NOWO,OPT_APPROVALCODE,OPT_APPROVALCODEP,OPT_ERROR) VALUES " & _
                         "('" & LblNoMohon.Text & "','','" & lblArea1.Text & "','" & LblUserName.Text & "','',GETDATE(),'" & txtnospk.Text & "','" & DropDownList1.Text & "'," & _
                         " '" & LblAksesorisKode.Text & "','" & IIf(DropDownList2.Text = "BAYAR", "1", "0") & "'," & nLg(TxtAksesorisQty.Text) & "," & nLg(LblAksesorisModal.Text) & "," & IIf(DropDownList2.Text = "BAYAR", nLg(TxtHargaAss.Text), "0") & ",'" & TxtPetik(TxtCatatan.Text) & "'," & _
                         " NULL,'','','',NULL,'','','','ENTRY-D','','" & LblApproved.Text & "','','')"
            If UpdateDatabase_Tabel(mTxtInsert, "", 0) = 1 Then
                Call Msg_err("Data Pemohonan sudah tersimpan ......", 0)
                Call ClearInputAsesoris()
                LvPO.DataBind()

                mTxtInsert = "UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='TOLAK-0' WHERE OPT_NODEALER='" & lblArea1.Text & "' AND OPT_NOSPK='" & txtnospk.Text & "' AND OPT_CDASS='" & LblAksesorisKode.Text & "' AND (OPT_STATUSPROSES like '%TOLAK-SPV%')"
                Call UpdateDatabase_Tabel(mTxtInsert, "", 0)
                mTxtInsert = "UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='TOLAK-1' WHERE OPT_NODEALER='" & lblArea1.Text & "' AND OPT_NOSPK='" & txtnospk.Text & "' AND OPT_CDASS='" & LblAksesorisKode.Text & "' AND (OPT_STATUSPROSES like '%TOLAK-SM%')"
                Call UpdateDatabase_Tabel(mTxtInsert, "", 0)

                mTxtInsert = "UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='ENTRY-D' WHERE OPT_NOMORMOHON='" & LblNoMohon.Text & "' AND OPT_STATUSPROSES ='ENTRY'"
                Call UpdateDatabase_Tabel(mTxtInsert, "", 0)
                mTxtInsert = "DELETE FROM TRXN_SPKAD WHERE NOMOR_MOHON='" & LblNoMohon.Text & "'"
                Call UpdateDatabase_Tabel(mTxtInsert, "", 0)
                mTxtInsert = "DELETE FROM TRXN_SPKAHERR  WHERE SPKAHERR_NOM='" & LblNoMohon.Text & "'"
                Call UpdateDatabase_Tabel(mTxtInsert, "", 0)
                Call UpdateDataENTRYAKSESORIS(LblNoMohon.Text, "")
            End If
        End If
    End Sub



    Sub ClearInputAsesoris()
        LblAksesorisKode.Text = ""
        LblAksesorisNama.Text = ""
        LblAksesorisDesc.Text = ""
        LblAksesorisQty.Text = ""
        LblAksesorisModal.Text = ""
        TxtHargaAss.Text = ""
        TxtAksesorisQty.Text = ""
        TxtCatatan.Text = ""
        LblStatusUpdateOPT.Text = ""
        LblWarna.Text = ""
    End Sub
    Protected Sub LvDataMasterAss_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvDataMasterAss.SelectedIndexChanged
        LblAksesorisKode.Text = (LvDataMasterAss.DataKeys(LvDataMasterAss.SelectedIndex).Value.ToString)
        LblWarna.Text = ""
        LblAksesorisNama.Text = ""
        LblAksesorisDesc.Text = ""
        LblAksesorisQty.Text = ""
        LblAksesorisModal.Text = ""
        TxtHargaAss.Text = ""
        TxtAksesorisQty.Text = ""
        TxtCatatan.Text = ""
        LblStatusUpdateOPT.Text = ""
        Call GetDataA_MasterAsesoris("SELECT * FROM DATA_STANDARD WHERE STANDARD_KODE='" & LblAksesorisKode.Text & "'")
        If LblAksesorisNama.Text <> "" Then

            'Call GetDataMasterHarga("STANDARDH_CdAss='" & LblAksesorisKode.Text & "' AND " & "( STANDARDH_CdType='" & MyTipeK & "' OR STANDARDH_GroupType='" & MyTipeG & "')")
            Dim MySTRsql1 As String = "SELECT *," & _
                                      "(SELECT TYPE_NAMA FROM DATA_Type WHERE Type_Type=STANDARDH_CdType) as mNamaType," & _
                                      "(SELECT TYPE_Group FROM DATA_Type WHERE Type_Type=STANDARDH_CdType) as mNamaTypeGroup1," & _
                                      "(SELECT TYPE_Group FROM DATA_Type WHERE TYPE_Group=STANDARDH_GroupType GROUP BY TYPE_Group) as mNamaTypeGroup2 " & _
                                      "FROM DATA_STANDARDH,DATA_STANDARD,DATA_SUPLIER " & _
                                      "WHERE STANDARDH_CdSuplier=SUPLIER_Kode AND STANDARDH_CdAss=STANDARD_Kode AND " & _
                                      "      (STANDARDH_JUALPASAR > 0 OR STANDARDH_MAX < 0) AND " & _
                                      "      STANDARDH_CdAss='" & LblAksesorisKode.Text & "' AND " & _
                                      "      STANDARDH_GroupType='" & LblTipe.Text & "' " & _
                                      "ORDER BY STANDARDH_JUALPASAR,STANDARDH_CdSuplier"
            LblAksesorisModal.Text = GetDataA_MasterHarga(MySTRsql1)
        End If
    End Sub
    Protected Sub LvPO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvPO.SelectedIndexChanged
        LblAksesorisKode.Text = (LvPO.DataKeys(LvPO.SelectedIndex).Value.ToString)
        Call GetDataA_POAsesoris("SELECT * FROM TRXN_OPTPO,DATA_STANDARD WHERE OPT_CDASS=STANDARD_KODE AND OPT_NODEALER='" & lblArea1.Text & "' AND OPT_NOSPK='" & txtnospk.Text & "' AND OPT_CDASS='" & LblAksesorisKode.Text & "'", "", "", "GET")
        If UCase(LblUserName.Text) = "ITPSMOK" Or UCase(LblUserName.Text) = "ITPURIOK" Then
            CheckBoxUpdateAss.Checked = False : CheckBoxUpdateAss1.Checked = False : CheckBoxUpdateAss2.Checked = False
            CheckBoxUpdateAss.Text = "UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='SETUJU-A' WHERE OPT_STATUSPROSES like 'SETUJU%' AND  OPT_NOMORMOHON='" & LblNomorMohonOPT.Text & "'"
            CheckBoxUpdateAss1.Text = "UPDATE TRXN_OPTPO SET opt_nomormohon=REPLACE(opt_nomormohon,'/WB/','/BT/'),OPT_NOSPK='BATAL-' WHERE OPT_NOSPK='" & txtnospk.Text & "' AND OPT_NODEALER='" & lblArea1.Text & "'"
            CheckBoxUpdateAss2.Text = "DELETE FROM TRXN_SPKAHERR WHERE SPKAHERR_NOM='" & LblNomorMohonOPT.Text & "'"
            MultiUpdateDataAksesoris.ActiveViewIndex = 0
        End If
    End Sub


    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Call ClearInputAsesoris()
    End Sub
    Protected Sub txtnospk_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnospk.TextChanged
        LvPO.DataBind()
    End Sub
    Protected Sub ButtonSimpan0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSimpan0.Click
        MultiViewAssTblStandard.ActiveViewIndex = 0
        LblTipe.Text = DropDownList1.Text
    End Sub
    Protected Sub BtnKembali2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKembali2.Click
        MultiView1a.ActiveViewIndex = 0
    End Sub
    Protected Sub ButtonHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonHapus.Click
        If GetDataA_POAsesoris("SELECT * FROM TRXN_OPTPO WHERE OPT_NODEALER='" & lblArea1.Text & "' AND OPT_NOSPK='" & txtnospk.Text & "' AND OPT_CDASS='" & LblAksesorisKode.Text & "' AND (OPT_TGLAPPV1 IS NOT NULL AND OPT_TGLAPPV2 IS NOT NULL)", "", "", "") = "1" Then
            Call Msg_err("Tidak Bisa dihapus sudah disetujui SM (untuk pembatalan segera lapor purchasing ......", 0)
        Else
            Dim mTxtInsert As String = "DELETE FROM TRXN_OPTPO WHERE OPT_NODEALER='" & lblArea1.Text & "' AND OPT_NOSPK='" & txtnospk.Text & "' AND OPT_CDASS='" & LblAksesorisKode.Text & "' AND (OPT_NOWO='' OR OPT_NOWO IS NULL)"
            If UpdateDatabase_Tabel(mTxtInsert, "", 0) = 1 Then
                'mTxtInsert = "DELETE FROM TRXN_SPKAD WHERE NOMOR_MOHON='" & LblNoMohon.Text & "'"
                'Call UpdateDatabase_Tabel(mTxtInsert)
                'mTxtInsert = "DELETE FROM TRXN_SPKAHERR  WHERE SPKAHERR_NOM='" & LblNoMohon.Text & "'"
                'Call UpdateDatabase_Tabel(mTxtInsert)
                Call Msg_err("Data Pemohonan sudah terhapus ......", 0)
                Call ClearInputAsesoris()
                LvPO.DataBind()
            End If
        End If
    End Sub


    '==============================
    Protected Sub DropDownList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList3.SelectedIndexChanged
        Call DropDownList3_DO()
    End Sub

    Sub DropDownList3_DO()
        MultiViewMhnInpDO.ActiveViewIndex = -1
        MultiViewMhnInpDONoDealer.ActiveViewIndex = -1
        MultiViewMhnInpDODealer.ActiveViewIndex = -1
        MultiViewMhnInpFaktur.ActiveViewIndex = -1
        MultiViewMhnInpHrgUnit.ActiveViewIndex = -1 : TxtChangeHargaUnit.Text = ""
        MultiViewMhnInpHrgDisc.ActiveViewIndex = -1 : TxtChangeHargaDisc.Text = ""
        MultiViewMhnInpHrgSubs.ActiveViewIndex = -1 : TxtChangeHargaSubs.Text = ""
        MultiViewMhnInpHrgKoms.ActiveViewIndex = -1 : TxtChangeHargaKoms.Text = ""
        MultiViewMhnInpLain.ActiveViewIndex = -1
        MultiViewMhnNumerik.ActiveViewIndex = -1
        MultiViewMhnInpLease.ActiveViewIndex = -1
        MultiViewMhnTglKirim.ActiveViewIndex = -1
        MultiViewMhnTglKirimSub.ActiveViewIndex = -1
        MultiViewMhnTglKirimPameran.ActiveViewIndex = -1

        LblJudulNumerik.Text = ""
        TxtChangeNilaiNum.Text = "" : TxtChangeNilaiNum.Visible = False
        '--------------->Dipakai Oleh Ubah Tahun unit, Seleisih Paket cermat,Seleisih Beda Tahun

        MultiViewMhnInpSwitch.ActiveViewIndex = -1 : txtNoSPKSWTuju.Text = "" : txtNoSPKSWNom.Text = ""

        MultiViewMhnInpSubsidiSales.ActiveViewIndex = -1 : TxtChangeSubsidiSales.Text = ""
        MultiViewMhnInpBatalSPKHMS.ActiveViewIndex = -1 : TxtChangeSPKBatal.Text = ""

        TxtFakturNama.Text = "" : TxtFakturAlamat.Text = "" : TxtFakturKota.Text = "" : TxtFakturPos.Text = ""
        TxtFakturNoHP.Text = "" : TxtFakturNoKTP.Text = "" : TxtTglLahir.Text = ""
        TxtFakturNoPolisi.Text = "" : TxtNOTE.Text = ""
        CheckFktLamp1.Checked = False : CheckFktLamp2.Checked = False : CheckFktLamp3.Checked = False : CheckFktLamp4.Checked = False : CheckFktLamp5.Checked = False
        ChkDiskonLuckDp.Checked = False

        TxtNilaiBaru.Text = ""
        'If DropDownList3.Text = "ENTRY TOTAL UBAH HARGA UNIT MENJADI" Or _
        '   DropDownList3.Text = "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON" Then
        If DropDownList3.Text = "ENTRY TOTAL UBAH HARGA UNIT MENJADI" Then
            MultiViewMhnInpHrgUnit.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY TOTAL UBAH HARGA DISKON MENJADI" Or DropDownList3.Text = "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON" Then
            MultiViewMhnInpHrgDisc.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY ALASAN SUBSIDI" Or DropDownList3.Text = "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON" Then
            MultiViewMhnInpHrgSubs.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY ALASAN KOMISI" Or DropDownList3.Text = "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON" Then
            MultiViewMhnInpHrgKoms.ActiveViewIndex = 0
        End If

        If DropDownList3.Text = "ENTRY PERMOHONAN KIRIM UNIT CUSTOMER" Then
            TxtKirimTgl.Text = "" : DpDJamKirim.Text = "08"
            TxtKirimNama.Text = "" : TxtKirimAlamat.Text = "" : TxtKirimKota.Text = "" : TxtKirimNamaHP.Text = ""
            LblKirimJenis.Text = "" : LblKirimTglDO.Text = ""
            LblKirimRangka.Text = "" : LblKirimNoDO.Text = ""
            LblKirimTipe.Text = "" : LblKirimWarna.Text = ""

            MultiViewMhnTglKirim.ActiveViewIndex = 0
            MultiViewMhnTglKirimSub.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY PERMOHONAN KIRIM UNIT PAMERAN" Then
            TxtKirimMoveTgl.Text = "" : TxtKirimMoveTerima.Text = "" : TxtKirimMoveKembali.Text = ""
            TxtKirimMoveLok.Text = "" : TxtKirimMoveRgk.Text = ""
            TxtKirimMoveNmSl.Text = "" : TxtKirimMoveNmSl.Text = ""
            TxtKirimMoveNmSp.Text = "" : TxtKirimMoveNmTjb.Text = ""
            LblKirimmoveMsn.Text = "" : LblKirimmoveTpy.Text = "" : LblKirimmoveWrn.Text = ""
            MultiViewMhnTglKirimPameran.ActiveViewIndex = 0
            MultiViewMhnTglKirimSub.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY PERMOHONAN KIRIM UNIT DEALER" Then
            TxtKirimTgl.Text = "" : DpDJamKirim.Text = "08"
            TxtKirimNama.Text = "" : TxtKirimAlamat.Text = "" : TxtKirimKota.Text = "" : TxtKirimNamaHP.Text = ""
            LblKirimJenis.Text = "" : LblKirimTglDO.Text = ""
            LblKirimRangka.Text = "" : LblKirimNoDO.Text = ""
            LblKirimTipe.Text = "" : LblKirimWarna.Text = ""

            MultiViewMhnTglKirim.ActiveViewIndex = 0
            MultiViewMhnTglKirimSub.ActiveViewIndex = -1
        End If


        If DropDownList3.Text = "ENTRY PAKET CERMAT" Then
            LblJudulNumerik.Text = "Harga Modal Paket Cermat" : TxtChangeNilaiNum.Visible = True
            TxtChangeNilaiNum.Text = "" : TxtChangeNilaiNum.MaxLength = 17
            MultiViewMhnNumerik.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY SELISIH HARGA UNIT BEDA TAHUN" Then
            LblJudulNumerik.Text = "Harga Selisih beda tahun" : TxtChangeNilaiNum.Visible = True
            TxtChangeNilaiNum.Text = "" : TxtChangeNilaiNum.MaxLength = 17
            MultiViewMhnNumerik.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY PERPANJANG MASA WAKTU UANG MUKA" Then
            LblJudulNumerik.Text = "Jumlah Hari kerja perpanjang Uang Muka" : TxtChangeNilaiNum.Visible = True
            TxtChangeNilaiNum.Text = "" : TxtChangeNilaiNum.MaxLength = 2
            MultiViewMhnNumerik.ActiveViewIndex = 0

        End If


        If DropDownList3.Text = "ENTRY ALASAN PROSES CANCEL SPK HMS" Then
            MultiViewMhnInpBatalSPKHMS.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY PINDAH DANA ANTAR SPK" Then
            MultiViewMhnInpSwitch.ActiveViewIndex = 0
        End If

        'If DropDownList3.Text = "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON" Then
        'MultiViewMhnInpSwitch.ActiveViewIndex = 0
        'End If

        If DropDownList3.Text = "ENTRY ALASAN DO/ISI NOMOR RANGKA" Then
            MultiViewMhnInpDO.ActiveViewIndex = 0
            MultiViewMhnInpDONoDealer.ActiveViewIndex = 0
            MultiViewMhnInpDODealer.ActiveViewIndex = -1
            MultiViewMhnInpFaktur.ActiveViewIndex = 0
            MultiViewAssTabel.ActiveViewIndex = 0
            MultiViewAssInpTabel.ActiveViewIndex = 0 : Button8.Visible = True : Button9.Visible = False
            RadioBtnAsrNo.Checked = True 'RadioBtnAsrYs.Checked = False
            txtnospk.Text = Txt_NoSPKMohon.Text : TxtDOAsr.Text = ""

            If Txt_NoSPKMohon.Text <> "" Then
                LvPO.DataBind()
            End If
        End If
        If DropDownList3.Text = "ENTRY ALASAN DO/DEALER NOMOR RANGKA" Then
            MultiViewMhnInpDO.ActiveViewIndex = 0
            MultiViewMhnInpDONoDealer.ActiveViewIndex = -1
            MultiViewMhnInpDODealer.ActiveViewIndex = 0
            RadioBtnDoDealer2.Checked = True
            txtnospk.Text = Txt_NoSPKMohon.Text
            If Txt_NoSPKMohon.Text <> "" Then
                LvPO.DataBind()
            End If
        End If

        If DropDownList3.Text = "ENTRY ALASAN PEMBUATAN FAKTUR" Then
            MultiViewMhnInpFaktur.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY SPK BARU" Then
            'MultiViewMobilBekas.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY ALASAN UBAH CARA BAYAR" Then
            MultiViewMhnInpLease.ActiveViewIndex = 0
            TxtCdLease.Text = ""
            LblNamaLease.Text = ""
        End If
        If MultiViewMhnInpDO.ActiveViewIndex = -1 And _
            MultiViewMhnInpFaktur.ActiveViewIndex = -1 And _
            MultiViewMhnInpHrgUnit.ActiveViewIndex = -1 And _
            MultiViewMhnInpHrgDisc.ActiveViewIndex = -1 And _
            MultiViewMhnInpHrgSubs.ActiveViewIndex = -1 And _
            MultiViewMhnInpHrgKoms.ActiveViewIndex = -1 And _
            MultiViewMhnNumerik.ActiveViewIndex = -1 And _
            MultiViewMhnTglKirim.ActiveViewIndex = -1 And _
            MultiViewMhnTglKirimPameran.ActiveViewIndex = -1 And _
            MultiViewMhnInpBatalSPKHMS.ActiveViewIndex = -1 And _
            MultiViewMhnInpSwitch.ActiveViewIndex = -1 And _
            MultiViewMhnInpLease.ActiveViewIndex = -1 Then
            TxtNilaiBaru.Visible = True
            MultiViewMhnInpLain.ActiveViewIndex = 0
        End If
        If DropDownList3.Text <> "ENTRY SPK BARU" Then
            MultiViewTombolSPK.ActiveViewIndex = 0
        End If
        MultiViewMhnTabelUbahSPK.ActiveViewIndex = 0
        MultiViewMhnTabelUbahSPKR1.ActiveViewIndex = 0
    End Sub

    Protected Sub Txt_NoSPKMohon_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_NoSPKMohon.TextChanged
        MultiViewMhnInpDO.ActiveViewIndex = -1
        If DropDownList3.Text = "ENTRY ALASAN DO/ISI NOMOR RANGKA" And Txt_NoSPKMohon.Text <> "" Then
            MultiViewMhnInpDO.ActiveViewIndex = 0
        End If
        insertTabelPermohonan(0, "", "", "", "", "", "", "", "", "", "", "", "")
        Call GetDataA_TabelPermohonan("")
    End Sub




    Sub ClearInputDataSPK()
        Txt_NoSPKMohon.Text = ""
        DropDownList3.Text = ""
        txtalasanmohon.Text = ""
        TxtChangeNorangka.Text = ""
        CheckFktLamp1.Checked = False
        CheckFktLamp2.Checked = False
        CheckFktLamp3.Checked = False
        CheckFktLamp4.Checked = False
        CheckFktLamp5.Checked = False
        TxtFakturNama.Text = ""
        TxtFakturNoKTP.Text = ""
        TxtFakturAlamat.Text = ""
        TxtFakturKota.Text = ""
        TxtFakturPos.Text = ""
        TxtFakturNoHP.Text = ""
        TxtTglLahir.Text = ""
        DropDownList4.Text = ""
        TxtFakturNoPolisi.Text = ""
        TxtNOTE.Text = ""
        TxtChangeHargaUnit.Text = ""
        TxtChangeHargaDisc.Text = ""
        TxtChangeHargaSubs.Text = ""
        TxtChangeHargaKoms.Text = ""
        TxtChangeNilaiNum.Text = "" : TxtChangeNilaiNum.Visible = False
        TxtNilaiBaru.Text = ""

        lblPemohon.Text = LblUserName.Text
    End Sub

    Sub ClearInputDataVA()
        TxtVANoSPK.Text = ""
        TxtVANama.Text = ""
        TxtVANoHP.Text = ""
        TxtVAEmail.Text = ""
        TxtVAJumlah.Text = ""
        LblVANomor.Text = ""
        LblVANomor0.Text = ""
        LblVANomor1.Text = ""
        LblVAError.Text = ""

    End Sub
    '===============================

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
ErrHand:
    End Function


    'Permohonan Selain Asesori
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSaveMohon.Click
        Dim mAroval As String
        Dim mArovalP As String
        Dim mOrEmail1 As String = ""
        Dim mOrEmail2 As String = ""
        Dim mRupiah As Double = 0
        Call Msg_err("", 0)

        If Txt_NoSPKMohon.Text = "" Or txtalasanmohon.Text = "" Or DropDownList3.Text = "" Then
            Call Msg_err("ISIAN BELUM LENGKAP ", 0) : Exit Sub
        ElseIf Len(Txt_NoSPKMohon.Text) <> 6 Then
            Call Msg_err("PANJANG NOMOR SPK TIDAK SESUAI DENGAN FORMAT (PANJANG 6 DIGIT)", 0) : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY TAMBAH AKSESORIS" Then
            Call Msg_err("PERMOHONAN PASANG AKSESORIS MUNGGUNAKAN FORM ASESORIS", 0) : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY TOTAL UBAH HARGA UNIT MENJADI" And _
           (Not IsNumeric(TxtChangeHargaUnit.Text) Or Val(TxtChangeHargaUnit.Text) < 0 Or TxtChangeHargaUnit.Text = "") Then
            Call Msg_err("ISIAN HARGA PERUBAHAN UNIT BELUM DIISI", 0) : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY PERMOHONAN KIRIM UNIT CUSTOMER" Then
            If Validasi_Kirim_unit(0, TxtKirimTgl.Text, DpDJamKirim.Text) <> "" Then Exit Sub
        ElseIf DropDownList3.Text = "ENTRY PERMOHONAN KIRIM UNIT PAMERAN" And (TxtKirimMoveTgl.Text = "") Then
            Call Msg_err("ISIAN TANGGAL ATAU JAM KIRIM BELUM DIISI", 0) : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY PERMOHONAN KIRIM UNIT DEALER" And (TxtKirimTgl.Text = "") Then
            Call Msg_err("ISIAN TANGGAL ATAU JAM KIRIM BELUM DIISI", 0) : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY PERMOHONAN KIRIM UNIT DEALER" And (Mid(lblAkses.Text, 3, 1) <> "1") Then
            Call Msg_err("TIDAK DIIJINKAN UNTUK ENTRY PERMOHONAN KIRIM UNIT DEALER", 0) : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY PAKET CERMAT" And _
           (Not IsNumeric(TxtChangeNilaiNum.Text) Or Val(TxtChangeNilaiNum.Text) <= 0 Or TxtChangeNilaiNum.Text = "") Then
            Call Msg_err("ISIAN HARGA PAKET CERMAT BELUM DIISI", 0) : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY SELISIH HARGA UNIT BEDA TAHUN" And _
           (Not IsNumeric(TxtChangeNilaiNum.Text) Or Val(TxtChangeNilaiNum.Text) <= 0 Or TxtChangeNilaiNum.Text = "") Then
            Call Msg_err("ISIAN HARGA SELISIH HARGA UNIT BEDA TAHUN", 0) : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY PERPANJANG MASA WAKTU UANG MUKA" And _
           (Not IsNumeric(TxtChangeNilaiNum.Text) Or Val(TxtChangeNilaiNum.Text) <= 0 Or TxtChangeNilaiNum.Text = "") Then
            Call Msg_err("ISIAN JUMLAH HARI AKAN DIPERPANJANG", 0) : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY ALASAN PROSES CANCEL SPK HMS" And _
           (Not IsNumeric(TxtChangeSPKBatal.Text) Or Val(TxtChangeSPKBatal.Text) < 0 Or TxtChangeSPKBatal.Text = "") Then
            Call Msg_err("ISIAN NOMOR SPK BELUM DIISI DENGAN BENAR", 0) : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY TOTAL UBAH HARGA DISKON MENJADI" And _
               (Not IsNumeric(TxtChangeHargaDisc.Text) Or Val(TxtChangeHargaDisc.Text) < 0 Or TxtChangeHargaDisc.Text = "") Then
            Call Msg_err("ISIAN HARGA PERUBAHAN DISKON/POTONGAN BELUM DIISI", 0) : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY ALASAN SUBSIDI" And _
               (Not IsNumeric(TxtChangeHargaSubs.Text) Or Val(TxtChangeHargaSubs.Text) < 0 Or TxtChangeHargaSubs.Text = "") Then
            Call Msg_err("ISIAN HARGA PERUBAHAN SUBSIDI BELUM DIISI", 0) : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY ALASAN KOMISI" And _
               (Not IsNumeric(TxtChangeHargaKoms.Text) Or Val(TxtChangeHargaKoms.Text) < 0 Or TxtChangeHargaKoms.Text = "") Then
            Call Msg_err("ISIAN HARGA PERUBAHAN KOMISI BELUM DIISI", 0) : Exit Sub
            'txtNoSPKSWAsal.Text = "" : txtNoSPKSWTuju.Text = "" : txtNoSPKSWNom.Text
        ElseIf DropDownList3.Text = "ENTRY PINDAH DANA ANTAR SPK" And _
               (Not IsNumeric(txtNoSPKSWTuju.Text) Or Val(txtNoSPKSWTuju.Text) <= 0 Or _
                Not IsNumeric(txtNoSPKSWNom.Text) Or Val(txtNoSPKSWNom.Text) <= 0) Then
            Call Msg_err("ISIAN PINDAH UANG MUKA ANTAR SPK SALAH PERIKSA NOMOR SPK DAN JUMLAH", 0) : Exit Sub

        ElseIf DropDownList3.Text = "ENTRY ALASAN DO/ISI NOMOR RANGKA" Then
            If Validasi_DO(Txt_NoSPKMohon.Text, TxtChangeNorangka.Text) <> "" Then Exit Sub
        ElseIf DropDownList3.Text = "ENTRY ALASAN DO/DEALER NOMOR RANGKA" Then
            If Validasi_DODealer(Txt_NoSPKMohon.Text, TxtChangeNorangka.Text) <> "" Then Exit Sub
        ElseIf DropDownList3.Text = "ENTRY ALASAN UBAH CARA BAYAR" Then
            If ValidasiCarabayarSPK(Txt_NoSPKMohon.Text, TxtCdLease.Text, lblArea1.Text) = 0 Then Exit Sub
        End If


        If (DropDownList3.Text = "ENTRY ALASAN DO/ISI NOMOR RANGKA" Or DropDownList3.Text = "ENTRY ALASAN PEMBUATAN FAKTUR") And _
               (TxtFakturNama.Text = "" Or TxtFakturAlamat.Text = "" Or TxtFakturKota.Text = "" Or TxtFakturPos.Text = "" Or TxtFakturNoHP.Text = "" Or _
                TxtFakturNoKTP.Text = "" Or TxtTglLahir.Text = "" Or DropDownList2.Text = "" Or TxtFakturNoPolisi.Text = "" Or _
                (CheckFktLamp1.Checked = False And CheckFktLamp2.Checked = False And CheckFktLamp3.Checked = False And CheckFktLamp4.Checked = False And CheckFktLamp5.Checked = False)) Then
            Call Msg_err("ISIAN DATA FAKTUR BELUM LENGKAP", 0) : Exit Sub
        End If

        mAroval = GetDataD_IsiField("SELECT PARAMETER_NAMA as IsiField FROM DATA_PARAMETER WHERE PARAMETER_NAMA like 'APPRVL%0%' AND PARAMETER_NILAI like '" & DropDownList3.Text & "' ORDER BY PARAMETER_NAMA", "", 0)
        If mAroval <> "" Then
            If Len(mAroval) > Len("APPRVL_A0") Then
                mAroval = Right(mAroval, Len(mAroval) - Len("APPRVL_A0"))
            Else
                mAroval = ""
            End If
        End If
        Dim mNomorMohon As String = cari_kode_mohon("", DropDownList3.Text, "NOMOR")

        If mAroval <> "" And mNomorMohon <> "" Then
            mOrEmail1 = mNomorMohon & "/SPK-" & lblArea1.Text & "-" & Txt_NoSPKMohon.Text    'Email
            mOrEmail2 = lblArea1.Text & Txt_NoSPKMohon.Text & "/" & mNomorMohon          'Lama
            mNomorMohon = lblArea1.Text & "/" & Txt_NoSPKMohon.Text & "/" & mNomorMohon      'Baru

            Call UpdateDatabase_Tabel("UPDATE TRXN_SPKAH SET JUDUL=replace(JUDUL,'ENTRY','BATAL')  WHERE JUDUL LIKE 'ENTRY%' AND (NOMOR_MOHON like '%" & mNomorMohon & "%' OR NOMOR_MOHON like '%" & mOrEmail1 & "%' OR NOMOR_MOHON like '%" & mOrEmail2 & "%')", "", 0)
            Call UpdateDatabase_Tabel("DELETE FROM TRXN_SPKAF WHERE SPKAF_NOMORMOHON='" & mNomorMohon & "'", "", 0)
            Dim mTxtInsert As String

            If DropDownList3.Text = "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON" And ChkDiskonLuckDp.Checked = True Then
                mRupiah = 1000000 'txtalasanmohon.Text = ChkDiskonLuckDp.Text
            End If

            mTxtInsert = "'" & TxtPetik(Left(Trim(TxtNilaiBaru.Text), 20)) & "','','','',''"

            If DropDownList3.Text = "ENTRY ALASAN UBAH CARA BAYAR" Then
                mTxtInsert = "'" & TxtCdLease.Text & "','','','',''"
            ElseIf DropDownList3.Text = "ENTRY TOTAL UBAH HARGA UNIT MENJADI" Then
                mTxtInsert = "'" & TxtPetik(Left(Trim(TxtChangeHargaUnit.Text), 20)) & "','','','',''"
            ElseIf DropDownList3.Text = "ENTRY TOTAL UBAH HARGA DISKON MENJADI" Then
                mTxtInsert = "'','" & TxtPetik(Left(Trim(TxtChangeHargaDisc.Text), 20)) & "','','',''"
            ElseIf DropDownList3.Text = "ENTRY ALASAN SUBSIDI" Then
                mTxtInsert = "'','','" & TxtPetik(Left(Trim(TxtChangeHargaSubs.Text), 20)) & "','',''"
            ElseIf DropDownList3.Text = "ENTRY ALASAN KOMISI" Then
                mTxtInsert = "'','','','" & TxtPetik(Left(Trim(TxtChangeHargaKoms.Text), 20)) & "',''"
            ElseIf DropDownList3.Text = "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON" Then
                mTxtInsert = "'" & TxtPetik(Left(Trim(TxtChangeHargaUnit.Text), 20)) & "','" & TxtPetik(Left(Trim(TxtChangeHargaDisc.Text), 20)) & "','" & _
                             TxtPetik(Left(Trim(TxtChangeHargaSubs.Text), 20)) & "','" & TxtPetik(Left(Trim(TxtChangeHargaKoms.Text), 20)) & "','" & TxtChangeNilaiNum.Text & "'"

            ElseIf DropDownList3.Text = "ENTRY ALASAN DO/ISI NOMOR RANGKA" Then
                mTxtInsert = "'" & UCase(TxtPetik(Left(Trim(TxtChangeNorangka.Text), 20))) & "','" & IIf(RadioBtnAsrNo.Checked = True, "ASURANSI:TDK", IIf(RadioBtnAsrYs.Checked = True, "ASURANSI:YA", "")) & "','" & IIf(nLg(TxtDOAsr.Text) > 0, TxtDOAsr.Text, "") & "','',''"
            ElseIf DropDownList3.Text = "ENTRY ALASAN DO/DEALER NOMOR RANGKA" Then
                mTxtInsert = "'" & UCase(TxtPetik(Left(Trim(TxtChangeNorangka.Text), 20))) & "','" & IIf(RadioBtnDoDealer1.Checked = True, "TIDAK BARTER", IIf(RadioBtnDoDealer2.Checked = True, "BARTER", "")) & "','" & "" & "','',''"

            ElseIf DropDownList3.Text = "ENTRY PERMOHONAN KIRIM UNIT CUSTOMER" Then
                mTxtInsert = Format(CDate(TxtKirimTgl.Text), "dd-MM-yyyy") & ":" & DpDJamKirim.Text
                Dim mAlamatKirim As String
                mAlamatKirim = TxtKirimNama.Text & "}" & TxtKirimAlamat.Text & "}" & TxtKirimKota.Text & "}" & TxtKirimNamaHP.Text
                mTxtInsert = "'" & mTxtInsert & "','" & _
                             Mid(mAlamatKirim, 1, 50) & "','" & _
                             IIf(Len(mAlamatKirim) > 50, Mid(mAlamatKirim, 51, 50), "") & "','" & _
                             IIf(Len(mAlamatKirim) > 100, Mid(mAlamatKirim, 101, 50), "") & "','" & _
                             IIf(Len(mAlamatKirim) > 150, Mid(mAlamatKirim, 151, 50), "") & "'"
            ElseIf DropDownList3.Text = "ENTRY PERMOHONAN KIRIM UNIT PAMERAN" Then
                mTxtInsert = Format(CDate(TxtKirimTgl.Text), "dd-MM-yyyy") & ":" & Format(DpDJamKirim.Text, "0#")
                mTxtInsert = "'" & mTxtInsert & "','','','',''"
            ElseIf DropDownList3.Text = "ENTRY PERMOHONAN KIRIM UNIT DEALER" Then
                mTxtInsert = Format(CDate(TxtKirimTgl.Text), "dd-MM-yyyy") & ":" & DpDJamKirim.Text
                mTxtInsert = "'" & mTxtInsert & "','','','',''"
            ElseIf DropDownList3.Text = "ENTRY PAKET CERMAT" Then
                mTxtInsert = "'" & UCase(TxtPetik(Left(Trim(TxtChangeNilaiNum.Text), 20))) & "','','','',''"
            ElseIf DropDownList3.Text = "ENTRY SELISIH HARGA UNIT BEDA TAHUN" Then
                mTxtInsert = "'" & UCase(TxtPetik(Left(Trim(TxtChangeNilaiNum.Text), 20))) & "','','','',''"
            ElseIf DropDownList3.Text = "ENTRY PERPANJANG MASA WAKTU UANG MUKA" Then
                mTxtInsert = "'" & UCase(TxtPetik(Left(Trim(TxtChangeNilaiNum.Text), 20))) & "','','','',''"
            ElseIf DropDownList3.Text = "ENTRY ALASAN PROSES CANCEL SPK HMS" Then
                mTxtInsert = "'" & UCase(TxtPetik(Left(Trim(TxtChangeSPKBatal.Text), 20))) & "','','','',''"
            ElseIf DropDownList3.Text = "ENTRY PINDAH DANA ANTAR SPK" Then
                mTxtInsert = "'" & UCase(TxtPetik(Left(Trim(txtNoSPKSWNom.Text), 20))) & "','" & UCase(TxtPetik(Left(Trim(txtNoSPKSWTuju.Text), 20))) & "','','',''"
            End If
            If (InStr(mAroval, "0") = 0) Then
                mAroval = "0" & mAroval
            End If
            mArovalP = ""
            If (InStr(LblUserName.Text, lblArea1.Text) = 0) Then
                mArovalP = "0"
            End If

            mTxtInsert = "INSERT INTO TRXN_SPKAH " & _
                         "(NOMOR_MOHON,NOMOR_SPK,JUDUL,KETERANGAN,TANGGAL_PROSES,TANGGAL_ENTRY,CABANG,CATATAN,APPROVALCODE,APPROVALCODEP,RUPIAH," & _
                         "CHANGE,CHANGE1,CHANGE2,CHANGE3,CHANGE4,MYUSER,SPV) VALUES ('" & _
                         mNomorMohon & "','" & Txt_NoSPKMohon.Text & "','" & DropDownList3.Text & "','" & TxtPetik(txtalasanmohon.Text) & "',NULL,GETDATE(),'" & lblArea1.Text & "','','" & mAroval & "','" & mArovalP & "'," & mRupiah & "," & _
                         mTxtInsert & ",'" & Mid(LblUserName.Text, 1, 10) & "','')"

            If UpdateDatabase_Tabel(mTxtInsert, "", 0) = 1 Then
                If DropDownList3.Text = "ENTRY PERMOHONAN KIRIM UNIT DEALER" And _
                   InStr(TxtKirimNama.Text, "HONDA") <> 0 And _
                   LblKirimJenis.Text = "CROSS SELL" And Mid(lblAkses.Text, 3, 1) = "1" Then
                    'Langusng Bisa SPJ
                Else
                    mTxtInsert = "DELETE FROM TRXN_SPKAD WHERE NOMOR_MOHON='" & mNomorMohon & "'"
                    Call UpdateDatabase_Tabel(mTxtInsert, "", 0)
                    mTxtInsert = "DELETE FROM TRXN_SPKAHERR  WHERE SPKAHERR_NOM='" & mNomorMohon & "'"
                    Call UpdateDatabase_Tabel(mTxtInsert, "", 0)

                    Call Msg_err("Data Pemohonan sudah tersimpan ......", 0)
                    If DropDownList3.Text = "ENTRY ALASAN PEMBUATAN FAKTUR" Or DropDownList3.Text = "ENTRY ALASAN DO/ISI NOMOR RANGKA" Then
                        Dim mDoc As String = ""
                        Dim mAg As String = ""

                        mDoc = mDoc & IIf(CheckFktLamp1.Checked = True, "0", "1")
                        mDoc = mDoc & IIf(CheckFktLamp2.Checked = True, "0", "1")
                        mDoc = mDoc & IIf(CheckFktLamp3.Checked = True, "0", "1")
                        mDoc = mDoc & IIf(CheckFktLamp4.Checked = True, "0", "1")
                        mDoc = mDoc & IIf(CheckFktLamp5.Checked = True, "0", "1")
                        mAg = "6"
                        If DropDownList2.Text = "ISLAM" Then mAg = "1"
                        If DropDownList2.Text = "KATHOLIK" Then mAg = "2"
                        If DropDownList2.Text = "KRISTEN" Then mAg = "3"
                        If DropDownList2.Text = "BUDHA" Then mAg = "4"
                        If DropDownList2.Text = "HINDU" Then mAg = "5"
                        mTxtInsert = "INSERT INTO TRXN_SPKAF (SPKAF_NOMORMOHON,SPKAF_NOMOR,SPKAF_NOKTP,SPKAF_DOK,SPKAF_NAMA,SPKAF_ALAMAT,SPKAF_KOTA," & _
                                     "SPKAF_POS,SPKAF_NOHP,SPKAF_LAHIR,SPKAF_AGAMA,SPKAF_NOPOL,SPKAF_NOTE) VALUES ('" & _
                                     mNomorMohon & "','','" & TxtFakturNoKTP.Text & "','" & mDoc & "','" & TxtPetik(TxtFakturNama.Text) & "','" & TxtPetik(TxtFakturAlamat.Text) & "','" & TxtPetik(TxtFakturKota.Text) & "'," & _
                                     "'" & TxtFakturPos.Text & "','" & TxtFakturNoHP.Text & "'," & DtFrSQL(TxtTglLahir.Text) & ",'" & mAg & "','" & TxtFakturNoPolisi.Text & "','" & TxtNOTE.Text & "')"
                        Call UpdateDatabase_Tabel(mTxtInsert, "", 0)
                    End If

                    If lblArea1.Text = "112" Then
                        'Call SendEmailProces("Faiz@hondamugen.co.id", "Permohonan persetujuan melebihi Diskon tgl " & Now(), "", "", "Permohonan persetujuan melebihi Diskon tgl " & Now())
                    Else
                        'Call SendEmailProces("Ugam@hondamugen.co.id", "Permohonan persetujuan melebihi Diskon tgl " & Now(), "", "", "Permohonan persetujuan melebihi Diskon tgl " & Now())
                    End If
                    Call UpdateDataENTRYSPK(mNomorMohon, "")
                End If
            Else
                Call Msg_err("TIDAK TERSIMPAN USER YANG MENYETUJUI BELUM ADA ATAU NOMOR MOHON", 0)
            End If
        End If

        'MultiView1a.ActiveViewIndex = 1
        'MultiView1a.ActiveViewIndex = 2
        MultiView1a.ActiveViewIndex = 2
        insertTabelPermohonan(0, "", "", "", "", "", "", "", "", "", "", "", "")
        Call GetDataA_TabelPermohonan("")

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
        ElseIf InStr(mpJudul, "DO/DEALER NOMOR RANGKA") <> 0 Then
            Keterangan_perubahannya = "Kunci Rangka DO SPK Crossel dengan no rangka " & mpChange0 & ""
        ElseIf InStr(mpJudul, "PAKET CERMAT") <> 0 Then
            Keterangan_perubahannya = "Paket cermat Rp." & fLg(mpChange0) & ""
        ElseIf InStr(mpJudul, "SELISIH HARGA UNIT BEDA TAHUN") <> 0 Then
            Keterangan_perubahannya = "Selisih harga unit karena beda tahun Rp." & fLg(mpChange0) & ""
        ElseIf InStr(mpJudul, "PERPANJANG MASA WAKTU UANG MUKA") <> 0 Then
            Keterangan_perubahannya = "Perpanjang/Tambah Umur Uang muka menjadi " & fLg(mpChange0) & " Hari"
        ElseIf InStr(mpJudul, "CANCEL SPK HMS") <> 0 Then
            Keterangan_perubahannya = "Permohoan SPK cancel di Sistem Mugen/HMS"
        ElseIf InStr(mpJudul, "PINDAH DANA ANTAR SPK") <> 0 Then
            Keterangan_perubahannya = "Pindah dana sebesar " & fLg(mpChange0) & " ke nomor spk " & mpChange1
        ElseIf InStr(mpJudul, "KIRIM UNIT CUSTOMER") <> 0 Then
            Keterangan_perubahannya = "Tanggal Dan Jam Kirim " & mpChange0 & " Di kirim ke alamat " & mpChange1 & mpChange2 & mpChange3 & mpChange4
        End If
    End Function

    Function cari_kode_mohon(ByVal mData1 As String, ByVal mData2 As String, ByVal mTipe As String) As String
        Dim mMohon1 As String
        Dim mMohon2 As String
        Call Msg_err("", 0)
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
        ElseIf InStr(mData1, "WB/APR/DD") <> 0 Or InStr(mData2, "ENTRY ALASAN DO/DEALER NOMOR RANGKA") <> 0 Then
            mMohon1 = "ENTRY ALASAN DO/DEALER NOMOR RANGKA"
            mMohon2 = "WB/APR/DD"

        ElseIf InStr(mData1, "WB/APR/AS") <> 0 Or InStr(mData2, "ENTRY TAMBAH AKSESORIS") <> 0 Then
            mMohon1 = "ENTRY TAMBAH AKSESORIS"  'Sudah Off
            mMohon2 = "WB/APR/AS"               'Sudah Off

        ElseIf InStr(mData1, "EM/APR/KH") <> 0 Or InStr(mData2, "ENTRY ALASAN PERMOHONAN KIRIM UNIT KURANG 2 HARI") <> 0 Then
            mMohon1 = "ENTRY ALASAN PERMOHONAN KIRIM UNIT KURANG 2 HARI"
            mMohon2 = "EM/APR/KH"
        ElseIf InStr(mData1, "EM/APR/KL") <> 0 Or InStr(mData2, "ENTRY ALASAN PERMOHONAN KIRIM BELUM LUNAS") <> 0 Then
            mMohon1 = "ENTRY ALASAN PERMOHONAN KIRIM BELUM LUNAS"
            mMohon2 = "EM/APR/KL"
        ElseIf InStr(mData1, "WB/APR/MP") <> 0 Or InStr(mData2, "ENTRY PERMOHONAN KIRIM UNIT PAMERAN") <> 0 Then
            mMohon1 = "ENTRY PERMOHONAN KIRIM UNIT PAMERAN"
            mMohon2 = "WB/APR/MP"
        ElseIf InStr(mData1, "WB/APR/MD") <> 0 Or InStr(mData2, "ENTRY PERMOHONAN KIRIM UNIT DEALER") <> 0 Then
            mMohon1 = "ENTRY PERMOHONAN KIRIM UNIT DEALER"
            mMohon2 = "WB/APR/MD"
        ElseIf InStr(mData1, "WB/APR/MC") <> 0 Or InStr(mData2, "ENTRY PERMOHONAN KIRIM UNIT CUSTOMER") <> 0 Then
            mMohon1 = "ENTRY PERMOHONAN KIRIM UNIT CUSTOMER"
            mMohon2 = "WB/APR/MC"
        ElseIf InStr(mData1, "WB/APR/RS") <> 0 Or InStr(mData2, "ENTRY RUBAH KODE SALES") <> 0 Then
            mMohon1 = "ENTRY RUBAH KODE SALES"
            mMohon2 = "WB/APR/RS"
        ElseIf InStr(mData1, "WB/APR/SD") <> 0 Or InStr(mData2, "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON") <> 0 Then
            mMohon1 = "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON"
            mMohon2 = "WB/APR/SD"
        ElseIf InStr(mData1, "WB/APR/FT") <> 0 Or InStr(mData2, "ENTRY ALASAN PEMBUATAN FAKTUR") <> 0 Then
            mMohon1 = "ENTRY ALASAN PEMBUATAN FAKTUR"
            mMohon2 = "WB/APR/FT"
        ElseIf InStr(mData1, "WB/APR/PC") <> 0 Or InStr(mData2, "ENTRY PAKET CERMAT") <> 0 Then
            mMohon1 = "ENTRY PAKET CERMAT"
            mMohon2 = "WB/APR/PC"
        ElseIf InStr(mData1, "WB/APR/BT") <> 0 Or InStr(mData2, "ENTRY SELISIH HARGA UNIT BEDA TAHUN") <> 0 Then
            mMohon1 = "ENTRY SELISIH HARGA UNIT BEDA TAHUN"
            mMohon2 = "WB/APR/BT"
        ElseIf InStr(mData1, "WB/APR/BT") <> 0 Or InStr(mData2, "ENTRY PERPANJANG MASA WAKTU UANG MUKA") <> 0 Then
            mMohon1 = "ENTRY PERPANJANG MASA WAKTU UANG MUKA"
            mMohon2 = "WB/APR/UM"
        ElseIf InStr(mData1, "EM/APR/BS") <> 0 Or InStr(mData2, "ENTRY ALASAN PROSES CANCEL SPK HMS") <> 0 Then
            mMohon1 = "ENTRY ALASAN PROSES CANCEL SPK HMS"
            mMohon2 = "EM/APR/BS"
        ElseIf InStr(mData1, "WB/APR/BH") <> 0 Or InStr(mData2, "ENTRY PENGAJUAN BATAL H3S") <> 0 Then
            mMohon1 = "ENTRY PENGAJUAN BATAL H3S"
            mMohon2 = "WB/APR/BH"
        ElseIf InStr(mData1, "WB/APR/SW") <> 0 Or InStr(mData2, "ENTRY PINDAH DANA ANTAR SPK") <> 0 Then
            mMohon1 = "ENTRY PINDAH DANA ANTAR SPK"
            mMohon2 = "WB/APR/SW"
        End If
        If mTipe = "JUDUL" Then
            cari_kode_mohon = mMohon1
        Else
            cari_kode_mohon = mMohon2
        End If
    End Function


    Protected Sub LvUnitStok_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvUnitStok.SelectedIndexChanged
        TxtChangeNorangka.Text = (LvUnitStok.DataKeys(LvUnitStok.SelectedIndex).Value.ToString)
    End Sub

    Protected Sub ButtonSimpan1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSimpan1.Click
        LvUnitStok.DataBind()
    End Sub


    Sub TblPermohoananView_SelectedIndexChanging(ByVal sender As Object, ByVal e As ListViewSelectEventArgs)
        Dim item As ListViewItem = CType(LvTabelPermohoanan.Items(e.NewSelectedIndex), ListViewItem)
        Dim mKode As Label = CType(item.FindControl("Lbl_Judul"), Label)
        Dim mSw As Byte
        If String.IsNullOrEmpty(mKode.Text) Then
            Return
        End If

        MultiViewMhnDetailSub.ActiveViewIndex = 0
        MultiViewMhnMaster.ActiveViewIndex = -1
        MultiViewMhnDetail.ActiveViewIndex = 0
        If UCase(LblUserName.Text) = "ITPSMOK" Or UCase(LblUserName.Text) = "ITPURIOK" Then
            MultiViewAdmin.ActiveViewIndex = 0
        End If

        Button3.Visible = True
        BtnSaveMohon.Visible = False

        'Dim InputDT As Date = New DateTime(Year(mKode), Month(mKode), Day(mKode), Hour(mKode), Minute(mKode), Second(mKode))
        'mKode = Format(CDate(InputDT), "yyyy-MM-dd HH:mm:ss")

        If LblNomormohon.Text <> "" Then
            LblNomor.Text = "" : LblAskSPV.Text = "" : LblAskSM.Text = "" : LblAskOSM.Text = "" : LblAskDIR.Text = "" : LblStatusAkhir.Text = ""
            Call insertTabelPindahDana(0, "", "", "", "")
            Call CleAR_SPKAD()
            Call GetDataA_MasterDetail("SELECT * FROM TRXN_SPKAH WHERE NOMOR_SPK='" & Txt_NoSPKMohon.Text & "' AND JUDUL='" & mKode.Text & "' AND CABANG='" & lblArea1.Text & "'")
            mSw = 0
            If InStr(LblNomormohon.Text, "WB/APR/SW") <> 0 Then
                mSw = 1
                mSw = mSw + GetDataD_00NoFound01Found("SELECT * FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON='" & LblNomormohon.Text & "' AND KETERANGAN LIKE 'SPK_VA%' ", "", 1)
            End If

            Call GetDataA_Tabel_SPKAD("SELECT * FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON='" & LblNomormohon.Text & "' AND NOT(KETERANGAN LIKE 'SPK_TJ%' OR KETERANGAN LIKE 'SPK_VA%') ORDER BY KETERANGAN", mSw)
            If mSw > 0 Then
                Call insertTabelPindahDana(1, "", "", "-----------------", "")
                Call insertTabelPindahDana(1, "", "", "JUMLAH YANG AKAN DI PINDAHKAN ", lblMohonDetailNilai1.Text)
                Call insertTabelPindahDana(1, "", "", "-----------------", "")

                Call GetDataA_Tabel_SPKAD("SELECT * FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON='" & LblNomormohon.Text & "' AND (KETERANGAN LIKE 'SPK_TJ%' OR KETERANGAN LIKE 'SPK_VA%')", mSw)
            End If
            If LblNomor.Text <> "" Then
                Call GetDataA_Tabel_SPKASK("SELECT * FROM TRXN_SPKAS WHERE TRXN_SPKAS.SETUJU_NOMOR='" & LblNomor.Text & "'")
            End If

            CheckBoxUpdateSPK.Checked = False
            CheckBoxUpdateSPK1.Checked = False
            CheckBoxUpdateSPK2.Checked = False

            CheckBoxUpdateSPK.Text = "UPDATE TRXN_SPKAH SET STATUS=NULL WHERE NOMOR_MOHON ='" & LblNomormohon.Text & "' AND NOMOR='" & LblNomor.Text & "' AND JUDUL LIKE '%" & lblMohonDetailTipe.Text & "%'"
            If InStr(CheckBoxUpdateSPK.Text, "STJ-DIGANTI") <> 0 Then
                CheckBoxUpdateSPK.Text = "UPDATE TRXN_SPKAH SET STATUS=NULL,JUDUL=REPLACE(JUDUL,'STJ-DIGANTI','SETUJU') WHERE NOMOR_MOHON ='" & LblNomormohon.Text & "' AND NOMOR='" & LblNomor.Text & "' AND JUDUL LIKE '%" & lblMohonDetailTipe.Text & "%'"
            End If
            CheckBoxUpdateSPK1.Text = "DELETE FROM TRXN_SPKAS WHERE SETUJU_POS='1' AND SETUJU_NOMOR='" & LblNomor.Text & "'"
            CheckBoxUpdateSPK2.Text = "DELETE FROM TRXN_SPKAHERR WHERE SPKAHERR_NOM='" & LblNomormohon.Text & "'"

        End If


        'Dim discontinued As DateTime = DateTime.Parse(l.Text)
        'If discontinued < DateTime.Now Then
        'Message.Text = "You cannot select a discontinued item."
        'e.Cancel = True
        'End If
    End Sub

    Protected Sub TblPermohoananView_PagePropertiesChanging(ByVal sender As Object, ByVal e As PagePropertiesChangingEventArgs)
        ' Clears the selection.
        LvTabelPermohoanan.SelectedIndex = -1
    End Sub






    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        MultiViewMhnDetail.ActiveViewIndex = -1
        MultiViewAdmin.ActiveViewIndex = -1
        MultiViewMhnMaster.ActiveViewIndex = 0
        Button3.Visible = False
        BtnSaveMohon.Visible = True
    End Sub


    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        If (InStr(lblMohonDetailTipe.Text, "ENTRY") Or InStr(lblMohonDetailTipe.Text, "BATAL")) <> 0 And LblNomormohon.Text <> "" Then
            Call UpdateDatabase_Tabel("UPDATE TRXN_SPKAH SET TANGGAL_PROSES=NULL  WHERE NOMOR_MOHON = '" & LblNomormohon.Text & "'", "", 0)
            Call UpdateDatabase_Tabel("DELETE FROM  TRXN_SPKAD WHERE NOMOR_MOHON= '" & LblNomormohon.Text & "'", "", 0)
            Call UpdateDatabase_Tabel("DELETE FROM  TRXN_SPKAHERR  WHERE SPKAHERR_NOM= '" & LblNomormohon.Text & "'", "", 0)
            LblStatusUpdateSPK.Text = "Tunggu Maksimal 1.5 menit untuk server Mugen mengambil data SPK"
            Call UpdateDataENTRYSPK(LblNomormohon.Text, "")
        End If
        insertTabelPermohonan(0, "", "", "", "", "", "", "", "", "", "", "", "")
        Call GetDataA_TabelPermohonan("")
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        If (InStr(lblMohonDetailTipe.Text, "ENTRY") <> 0 Or InStr(lblMohonDetailTipe.Text, "BATAL") <> 0) And LblNomormohon.Text <> "" Then
            Call UpdateDatabase_Tabel("UPDATE TRXN_SPKAHERR SET " & _
                                      "SPKAHERR_DESC =replace(SPKAHERR_DESC,',ADA PERMOHONAN RUBAH DATA DI HMS DISETUJUI TAPI BLM DIRUBAH','')," & _
                                      "SPKAHERR_DESCR =replace(SPKAHERR_DESCR,',ADA PERMOHONAN RUBAH DATA DI HMS DISETUJUI TAPI BLM DIRUBAH','') " & _
                                      "WHERE SPKAHERR_NOM = '" & LblNomormohon.Text & "'", "", 0)
            Call UpdateDatabase_Tabel("DELETE FROM TRXN_SPKAHERR WHERE SPKAHERR_DESC ='' AND SPKAHERR_DESCR = '' AND SPKAHERR_NOM = '" & LblNomormohon.Text & "'", "", 0)

        End If
        insertTabelPermohonan(0, "", "", "", "", "", "", "", "", "", "", "", "")
        Call GetDataA_TabelPermohonan("")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If LblNomorMohonOPT.Text <> "" Then
            Call UpdateDatabase_Tabel("UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='ENTRY-D'  WHERE OPT_NOMORMOHON = '" & LblNomorMohonOPT.Text & "' AND (OPT_STATUSPROSES='ENTRY' OR OPT_STATUSPROSES='0')", "", 0)
            Call UpdateDatabase_Tabel("DELETE FROM  TRXN_SPKAD WHERE NOMOR_MOHON= '" & LblNomorMohonOPT.Text & "'", "", 0)
            Call UpdateDatabase_Tabel("DELETE FROM  TRXN_SPKAHERR  WHERE SPKAHERR_NOM= '" & LblNomorMohonOPT.Text & "'", "", 0)
            LblStatusUpdateOPT.Text = "Tunggu Maksimal 1.5 menit untuk server Mugen mengambil data SPK"
            Call UpdateDataENTRYAKSESORIS(LblNomorMohonOPT.Text, "")
        Else
            LblStatusUpdateOPT.Text = "Tidak ada permohonan yang akan di update data SPKnya"
        End If
        LvPO.DataBind()
    End Sub

    Protected Sub ButtonRefreshAsesoris_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRefreshAsesoris.Click
        LvPO.DataBind()
    End Sub

    Protected Sub ButtonSPKrefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSPKrefresh.Click
        MultiViewMhnTabelUbahSPK.ActiveViewIndex = 0
        MultiViewMhnTabelUbahSPKR1.ActiveViewIndex = 0

        insertTabelPermohonan(0, "", "", "", "", "", "", "", "", "", "", "", "")
        Call GetDataA_TabelPermohonan("")
    End Sub

    Protected Sub Button8Cad_Click()
        If InStr(lblMohonDetailTipe.Text, "SETUJU") <> 0 And LblNomormohon.Text <> "" Then
            'Call UpdateDatabase_Tabel("UPDATE TRXN_SPKAH SET STATUS=NULL  WHERE NOMOR_MOHON = '" & LblNomormohon.Text & "'")
        End If
        insertTabelPermohonan(0, "", "", "", "", "", "", "", "", "", "", "", "")
        Call GetDataA_TabelPermohonan("")
    End Sub

    Protected Sub ButtonSimpan2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSimpan2.Click
        MultiViewMhnDetail.ActiveViewIndex = -1
        MultiViewAdmin.ActiveViewIndex = -1
    End Sub

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        MultiViewAssInputSPK.ActiveViewIndex = 0
        MultiViewAssTblStandard.ActiveViewIndex = 0
        MultiViewAssData.ActiveViewIndex = 0
        MultiViewAssTombol.ActiveViewIndex = 0
        Button8.Visible = False
        Button9.Visible = True
    End Sub
    Protected Sub Button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.Click
        MultiViewAssInputSPK.ActiveViewIndex = -1
        MultiViewAssTblStandard.ActiveViewIndex = -1
        MultiViewAssData.ActiveViewIndex = -1
        MultiUpdateDataAksesoris.ActiveViewIndex = -1
        MultiViewAssTombol.ActiveViewIndex = -1
        Button8.Visible = True
        Button9.Visible = False
    End Sub




    Protected Sub ButtonAdmin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAdmin.Click
        If CheckBoxUpdateSPK.Checked = True Then
            Call UpdateDatabase_Tabel(CheckBoxUpdateSPK.Text, "", 0)
            LblStatusAkhir.Text = ""
        End If
        If CheckBoxUpdateSPK1.Checked = True Then
            Call UpdateDatabase_Tabel(CheckBoxUpdateSPK1.Text, "", 0)
        End If
        If CheckBoxUpdateSPK2.Checked = True Then
            Call UpdateDatabase_Tabel(CheckBoxUpdateSPK2.Text, "", 0)
        End If
    End Sub

    Protected Sub Button12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button12.Click
        If CheckBoxUpdateAss.Checked = True Then
            Call UpdateDatabase_Tabel(CheckBoxUpdateAss.Text, "", 0)
        End If
        If CheckBoxUpdateAss1.Checked = True Then
            Call UpdateDatabase_Tabel(CheckBoxUpdateAss1.Text, "", 0)
            Call UpdateDatabase_Tabel("", "", 0)
        End If
        If CheckBoxUpdateAss2.Checked = True Then
            Call UpdateDatabase_Tabel(CheckBoxUpdateAss2.Text, "", 0)
        End If
    End Sub



    Protected Sub BindGrid()
        LvTabelPermohoanan.DataSource = DirectCast(ViewState("Permohonan"), DataTable)
        LvTabelPermohoanan.DataBind()
    End Sub

    Sub insertTabelPermohonan(ByVal Type As Byte, ByVal Temp_Nomor As String, ByVal Temp_Judul As String, ByVal Temp_TANGGAL_PROSES As String, ByVal Temp_NOMOR_MOHON As String, ByVal Temp_URUT As String, ByVal Temp_MYUSER As String, ByVal Temp_SPV As String, ByVal Temp_APPROVALCODE As String, ByVal Temp_APPROVALCODEP As String, ByVal Temp_CHANGE As String, ByVal Temp_KETERANGAN As String, ByVal Temp_SPKAHERR_DESC As String)
        Dim dt As DataTable = DirectCast(ViewState("Keluhan"), DataTable)

        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_Nomor, Temp_Judul, Temp_TANGGAL_PROSES, Temp_NOMOR_MOHON, Temp_URUT, Temp_MYUSER, Temp_SPV, Temp_APPROVALCODE, Temp_APPROVALCODEP, Temp_CHANGE, Temp_KETERANGAN, Temp_SPKAHERR_DESC)
        End If
        ViewState("Permohonan") = dt
        Me.BindGrid()
    End Sub



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
                LblTglSystem.Text = nSr(MyRecReadA("mfTgl"))
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
            Call Msg_err(ex.Message, mpErrorSistem)
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
            Call Msg_err(ex.Message, mpMerrorsis)
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
            Call Msg_err(ex.Message, mpMerrorsis)
        End Try
    End Function

    Function GetDataA_AddlistTipePermohonan(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        GetDataA_AddlistTipePermohonan = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_AddlistTipePermohonan = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                If InStr(nSr(MyRecReadA("PARAMETER_NILAI")), "ENTRY ALASAN UBAH HARGA DISKON DAN UNIT") = 0 Then
                    DropDownList3.Items.Add(nSr(MyRecReadA("PARAMETER_NILAI")))
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function

    Function GetDataA_POAsesoris(ByVal mSqlCommadstring As String, ByVal mKodeAss As String, ByVal mKodeTipe As String, ByVal mGET As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        GetDataA_POAsesoris = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    If mGET = "VAL" Then
                        If mKodeAss = (nSr(MyRecReadA("OPT_CDASS"))) Then
                            GetDataA_POAsesoris = "1"
                            LblErrorSave.Text = "Kode Asesoris Sudah Ada"
                        ElseIf mKodeTipe <> (nSr(MyRecReadA("OPT_TIPE"))) Then
                            GetDataA_POAsesoris = "1"
                            LblErrorSave.Text = "Group Tipe tidak sama"
                        End If
                    ElseIf mGET = "GET" Then
                        LblAksesorisKode.Text = (nSr(MyRecReadA("OPT_CDASS")))
                        LblAksesorisNama.Text = (nSr(MyRecReadA("STANDARD_NAMA")))
                        LblAksesorisDesc.Text = (nSr(MyRecReadA("STANDARD_Desc")))
                        LblAksesorisModal.Text = (nSr(MyRecReadA("OPT_HARGAJUAL")))
                        TxtHargaAss.Text = (nSr(MyRecReadA("OPT_HARGACUST")))
                        TxtCatatan.Text = (nSr(MyRecReadA("OPT_KETERANGAN")))
                        LblNomorMohonOPT.Text = (nSr(MyRecReadA("OPT_NOMORMOHON")))
                    ElseIf mGET = "DATA" Then
                        GetDataA_POAsesoris = (nSr(MyRecReadA(mKodeTipe)))
                    Else
                        GetDataA_POAsesoris = "1"
                    End If
                End While

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function

    Function GetDataA_MasterAsesoris(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        GetDataA_MasterAsesoris = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                MyRecReadA.Read()

                LblAksesorisKode.Text = (nSr(MyRecReadA("STANDARD_KODE")))
                LblAksesorisNama.Text = (nSr(MyRecReadA("STANDARD_Nama")))
                LblAksesorisDesc.Text = (nSr(MyRecReadA("STANDARD_Desc")))
                TxtAksesorisQty.Text = "1"
                If (nSr(MyRecReadA("STANDARD_Warna"))) = "Y" Then
                    LblWarna.Text = "Aksesoris memerlukan pilih warna isi warna harus dicantumkan di Catatan"
                End If

                LblAksesorisModal.Text = "" 'Cari Yang Paling Murah
                TxtHargaAss.Text = ""

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function
    'Tidak terpakai
    Function GetDataA_MasterHargaOld(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mKodeSuplier(99) As String
        Dim mNomModalSuplier(99) As Double
        Dim mPrcModalSuplier(99) As Double
        Dim mFstModalSuplier(99) As Integer

        Dim mAkuModalSuplier(99) As Double
        Dim mMaxModalSuplier(99) As Double
        Dim mPanjangArary As Integer = 0
        Dim mPilihArary As Integer = 0
        GetDataA_MasterHargaOld = 0
        Call Msg_err("", 0)
        GetDataA_MasterHargaOld = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mPanjangArary = mPanjangArary + 1
                    mKodeSuplier(mPanjangArary) = (nSr(MyRecReadA("STANDARD_KODE")))
                    mNomModalSuplier(mPanjangArary) = (nLg(MyRecReadA("STANDARDH_Harga")))
                    mPrcModalSuplier(mPanjangArary) = (ndb(MyRecReadA("SUPLIER_PercenModalJual")))
                    mFstModalSuplier(mPanjangArary) = 0
                    If (nLg(MyRecReadA("STANDARDH_max"))) < 0 Then
                        mFstModalSuplier(mPanjangArary) = 1
                    End If
                    GetDataA_MasterHargaOld = (nLg(MyRecReadA("STANDARDH_JualPasar")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()

            Dim mHargaStandard As Double = 0
            If mPanjangArary > 0 Then
                mHargaStandard = mNomModalSuplier(mPanjangArary) * (1 + (ndb(mPrcModalSuplier(mPanjangArary) / 100)))
                For myNoItem As Integer = 1 To mPanjangArary
                    If mFstModalSuplier(mPanjangArary) = 1 Then
                        GetDataA_MasterHargaOld = mHargaStandard : Exit For
                    ElseIf (GetDataA_MasterHargaOld > mHargaStandard And mNomModalSuplier(mPanjangArary) > 0) Or _
                    GetDataA_MasterHargaOld = 0 Then
                        GetDataA_MasterHargaOld = mHargaStandard
                    End If
                Next
            End If
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function

    Function GetDataA_MasterHarga(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim mPilihSupl As Byte
        Dim mRpModal As Double
        Dim mRpMugen As Double
        Dim mRpModalPilihan As Double
        Dim mRpMugenPilihan As Double
        Dim mKdSuplPilihan As String
        Dim mSuplierAktif As String

        Dim mSuplierkode(99) As String
        Dim mSuplierAku(99) As Double
        Dim mSuplierMax(99) As Double



        GetDataA_MasterHarga = 0
        Call Msg_err("", 0)
        GetDataA_MasterHarga = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            mPilihSupl = 0
            mRpModal = 0 : mRpMugen = 0
            mRpModalPilihan = 0 : mRpMugenPilihan = 0
            mKdSuplPilihan = ""
            mSuplierAktif = ""
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    If nSr(MyRecReadA("SUPLIER_Aktif")) <> "1" Then
                        If mRpMugen = 0 Or _
                           (mRpMugen = nLg(MyRecReadA("STANDARDH_JualPasar"))) Then
                            mPilihSupl = mPilihSupl + 1
                            mSuplierkode(mPilihSupl) = nSr(MyRecReadA("STANDARDH_CdSuplier"))
                            mSuplierAku(mPilihSupl) = nLg(MyRecReadA("STANDARDH_Aku"))
                            mSuplierMax(mPilihSupl) = nLg(MyRecReadA("STANDARDH_Max"))
                            mRpModal = nLg(MyRecReadA("STANDARDH_Harga"))
                            mRpMugen = nLg(MyRecReadA("STANDARDH_JualPasar"))
                        End If
                        If nLg(MyRecReadA("STANDARDH_Max")) < 0 Then
                            mPilihSupl = 1
                            mKdSuplPilihan = nSr(MyRecReadA("STANDARDH_CdSuplier"))
                            mRpModalPilihan = nLg(MyRecReadA("STANDARDH_Harga"))
                            mRpMugenPilihan = nLg(MyRecReadA("STANDARDH_JualPasar"))
                            mSuplierkode(1) = nSr(MyRecReadA("STANDARDH_CdSuplier"))
                            mSuplierAku(1) = nLg(MyRecReadA("STANDARDH_Aku"))
                            mSuplierMax(1) = nLg(MyRecReadA("STANDARDH_Max"))
                        End If
                    Else
                        mSuplierAktif = "SUPLIER SUDAH TIDAK AKTIF LAGI"
                    End If
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
            If mPilihSupl > 0 Then
                If mKdSuplPilihan <> "" Then
                    mRpModal = mRpModalPilihan
                    mRpMugen = mRpMugenPilihan
                ElseIf mPilihSupl = 1 Then
                    mKdSuplPilihan = mSuplierkode(1)
                    mRpModal = mRpModal
                    mRpMugen = mRpMugen
                ElseIf mPilihSupl > 1 Then
                    For mLoopFind As Byte = 1 To mPilihSupl
                        If mSuplierAku(mLoopFind) < mSuplierMax(mLoopFind) Then
                            mKdSuplPilihan = mSuplierkode(mLoopFind)
                        End If
                    Next
                End If
            End If
            If mKdSuplPilihan <> "" Then
                GetDataA_MasterHarga = mRpMugen
            Else
                LblAksesorisDesc.Text = mSuplierAktif
            End If
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function


    Function GetDataA_MasterDetail(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Call Msg_err("", 0)
        GetDataA_MasterDetail = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            lblMohonDetailTgl.Text = ""
            lblMohonDetailSPK.Text = ""
            lblMohonDetailInfoSPK.Text = ""
            lblMohonDetailTipe.Text = ""
            lblMohonDetailAlasan.Text = ""
            LblStatusUpdateSPK.Text = ""
            LblNomormohon.Text = ""
            LblUpdateDataSPK.Text = ""
            lblMohonDetailJudul1.Text = ""
            lblMohonDetailNilai1.Text = ""
            lblMohonDetailJudul2.Text = ""
            lblMohonDetailNilai2.Text = ""
            lblMohonDetailJudul3.Text = ""
            lblMohonDetailNilai3.Text = ""
            lblMohonDetailJudul4.Text = ""
            lblMohonDetailNilai4.Text = ""
            lblMohonDetailProsesPersetujuan.Text = ""
            lblMohonDetailProsesPersetujuanAkhir.Text = ""
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    lblMohonDetailTgl.Text = nSr(MyRecReadA("TANGGAL_ENTRY"))
                    lblMohonDetailSPK.Text = nSr(MyRecReadA("NOMOR_SPK"))
                    lblMohonDetailTipe.Text = nSr(MyRecReadA("JUDUL"))
                    lblMohonDetailAlasan.Text = nSr(MyRecReadA("KETERANGAN"))
                    If InStr(nSr(MyRecReadA("JUDUL")), "DANA ANTAR SPK") <> 0 Then
                        lblMohonDetailAlasan.Text = lblMohonDetailAlasan.Text & " [" & _
                                                    "PINDAH TRANSAKSI KE SPK " & nSr(MyRecReadA("CHANGE1")) & _
                                                    " SEBESAR " & nSr(MyRecReadA("CHANGE")) & "]"
                    End If
                    LblNomormohon.Text = nSr(MyRecReadA("NOMOR_MOHON"))
                    LblUpdateDataSPK.Text = nSr(MyRecReadA("TANGGAL_PROSES"))
                    LblNomor.Text = nSr(MyRecReadA("NOMOR"))
                    LblStatusAkhir.Text = nSr(MyRecReadA("STATUS")) & "    [" & nSr(MyRecReadA("CHANGE4")) & "]"
                    lblDealer.Text = nSr(MyRecReadA("CABANG"))
                    If InStr(nSr(MyRecReadA("APPROVALCODE")), "0") <> 0 Then
                        lblMohonDetailProsesPersetujuan.Text = lblMohonDetailProsesPersetujuan.Text & "->SPV"
                    End If
                    If InStr(nSr(MyRecReadA("APPROVALCODE")), "1") <> 0 Then
                        lblMohonDetailProsesPersetujuan.Text = lblMohonDetailProsesPersetujuan.Text & "->SM"
                    End If
                    If InStr(nSr(MyRecReadA("APPROVALCODE")), "2") <> 0 Then
                        lblMohonDetailProsesPersetujuan.Text = lblMohonDetailProsesPersetujuan.Text & "->OPS"
                    End If
                    If InStr(nSr(MyRecReadA("APPROVALCODE")), "3") <> 0 Then
                        lblMohonDetailProsesPersetujuan.Text = lblMohonDetailProsesPersetujuan.Text & "->DIR"
                    End If

                    If InStr(nSr(MyRecReadA("APPROVALCODEP")), "3") <> 0 Then
                        lblMohonDetailProsesPersetujuanAkhir.Text = "->DIR"
                    ElseIf InStr(nSr(MyRecReadA("APPROVALCODEP")), "2") <> 0 Then
                        lblMohonDetailProsesPersetujuanAkhir.Text = "->OPS"
                    ElseIf InStr(nSr(MyRecReadA("APPROVALCODEP")), "1") <> 0 Then
                        lblMohonDetailProsesPersetujuanAkhir.Text = "->SM"
                    ElseIf InStr(nSr(MyRecReadA("APPROVALCODEP")), "0") <> 0 Then
                        lblMohonDetailProsesPersetujuanAkhir.Text = "->SPV"
                    Else
                        lblMohonDetailProsesPersetujuanAkhir.Text = "Belum disetujui sama sekali"
                    End If

                    If InStr(nSr(MyRecReadA("JUDUL")), "PINDAH DANA") <> 0 Then
                        TujuSPKNoText = nSr(MyRecReadA("CHANGE1"))
                    End If


                    If InStr(nSr(MyRecReadA("JUDUL")), "MAKSIMAL") <> 0 Then
                        lblMohonDetailJudul1.Text = "Potongan"
                        lblMohonDetailNilai1.Text = nLg(MyRecReadA("CHANGE1"))
                        lblMohonDetailJudul2.Text = "Subsidi"
                        lblMohonDetailNilai2.Text = nLg(MyRecReadA("CHANGE2"))
                        lblMohonDetailJudul3.Text = "Komisi"
                        lblMohonDetailNilai3.Text = nLg(MyRecReadA("CHANGE3"))
                        lblMohonDetailJudul4.Text = "Tahun"
                        lblMohonDetailNilai4.Text = nLg(MyRecReadA("CHANGE4"))
                    Else
                        lblMohonDetailJudul1.Text = "Nilai Perubahannya"
                        lblMohonDetailNilai1.Text = nSr(MyRecReadA("CHANGE"))
                    End If
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function
    Sub CleAR_SPKAD()
        LblNama.Text = "" : LblSales.Text = "" : LblSalesSPV.Text = "" : LblSalesSPV0.Text = ""
        LblCdType.Text = "" : LblCdTypeNamaDetail.Text = "" : lblGroupTipeNamaDetail.Text = ""
        LblWarnaNamaDetail.Text = ""

        lblNorangka.Text = "" : lblTahun.Text = ""
        LblHarga.Text = "" : LblDisc.Text = "" : LblSubsidi.Text = "" : LblKomisi.Text = "" : LblTotal.Text = ""

        LblJns.Text = "" : LblJns0.Text = "" : lblRoad.Text = "" : lblTnr.Text = ""
        LblBayar.Text = "" : LblBayarUM.Text = ""
        AsalSPKNoText = "" : AsalSPKNamaText = "" : TujuSPKNoText = ""

    End Sub



    Function GetDataA_Tabel_SPKAD(ByVal mSqlCommadstring As String, ByVal mType As Byte) As Byte
        'mType : 0 bukan swithing 1 bukan swithing SPK 2 bukan swithing Virtual account
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        GetDataA_Tabel_SPKAD = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_SPKAD = IIf(MyRecReadA.HasRows = True, 1, 0)

            While MyRecReadA.Read()
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
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TIPE" Then LblCdTypeNamaDetail.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_WARNA" Then LblWarnaNamaDetail.Text = nSr(MyRecReadA("NILAI"))

                If nSr(MyRecReadA("KETERANGAN")) = "SPK_PCERMATM" Then LblPaketCermat.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_PCERMATJ" Then LblBedaThn.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_HARGA" Then LblHarga.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_DISC" Then LblDisc.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_SUBSIDI" Then LblSubsidi.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_KOMISI" Then LblKomisi.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TOTAL" Then LblTotal.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_BAYAR" Then LblBayar.Text = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_UM" Then LblBayarUM.Text = nSr(MyRecReadA("NILAI"))

                'dodol
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_NAMA" Then AsalSPKNamaText = nSr(MyRecReadA("NILAI"))
                If mType > 0 Then
                    If nSr(MyRecReadA("KETERANGAN")) = "SPK_TGLDO" Then Call insertTabelPindahDana(1, IIf(mType = 1, "ASAL", "TUJUAN"), IIf(mType = 1, Txt_NoSPKMohon.Text, TujuSPKNoText), "Tanggal DO", nSr(MyRecReadA("NILAI")))
                    If nSr(MyRecReadA("KETERANGAN")) = "SPK_NAMA" Then Call insertTabelPindahDana(1, IIf(mType = 1, "ASAL", "TUJUAN"), IIf(mType = 1, Txt_NoSPKMohon.Text, TujuSPKNoText), "Nama", nSr(MyRecReadA("NILAI")))
                    If nSr(MyRecReadA("KETERANGAN")) = "SPK_BAYAR" Then Call insertTabelPindahDana(1, IIf(mType = 1, "ASAL", "TUJUAN"), IIf(mType = 1, Txt_NoSPKMohon.Text, TujuSPKNoText), "Total Bayar", nSr(MyRecReadA("NILAI")))
                    If nSr(MyRecReadA("KETERANGAN")) = "SPK_ALAMAT" Then Call insertTabelPindahDana(1, IIf(mType = 1, "ASAL", "TUJUAN"), IIf(mType = 1, Txt_NoSPKMohon.Text, TujuSPKNoText), "Alamat", nSr(MyRecReadA("NILAI")))
                    If nSr(MyRecReadA("KETERANGAN")) = "SPK_EMAIL" Then Call insertTabelPindahDana(1, IIf(mType = 1, "ASAL", "TUJUAN"), IIf(mType = 1, Txt_NoSPKMohon.Text, TujuSPKNoText), "Email", nSr(MyRecReadA("NILAI")))
                    If nSr(MyRecReadA("KETERANGAN")) = "SPK_NOHP" Then Call insertTabelPindahDana(1, IIf(mType = 1, "ASAL", "TUJUAN"), IIf(mType = 1, Txt_NoSPKMohon.Text, TujuSPKNoText), "No Handphone", nSr(MyRecReadA("NILAI")))
                End If
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJNOSPK" Then TujuSPKNoText = nSr(MyRecReadA("NILAI"))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJNOSPK" Then Call insertTabelPindahDana(1, "TUJUAN", TujuSPKNoText, "Nomor SPK", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJTGLDO" Then Call insertTabelPindahDana(1, "TUJUAN", TujuSPKNoText, "Tanggal DO", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJNAMA" Then Call insertTabelPindahDana(1, "TUJUAN", TujuSPKNoText, "Nama", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJBAYAR" Then Call insertTabelPindahDana(1, "TUJUAN", TujuSPKNoText, "Total Bayar", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJALAMAT" Then Call insertTabelPindahDana(1, "TUJUAN", TujuSPKNoText, "Alamat", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJEMAIL" Then Call insertTabelPindahDana(1, "TUJUAN", TujuSPKNoText, "Email", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_TJNOHP" Then Call insertTabelPindahDana(1, "TUJUAN", TujuSPKNoText, "No Handphone", nSr(MyRecReadA("NILAI")))

                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_NOREJECT" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", TujuSPKNoText, "Nomor Virtual Account", "20035" & nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_PEMOHON" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", TujuSPKNoText, "Pemohon", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_NAMA" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", TujuSPKNoText, "Nama", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_EMAIL" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", TujuSPKNoText, "Email", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_HP" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", TujuSPKNoText, "No Handphone", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_TGLPAYMENT" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", TujuSPKNoText, "Tgl Payment", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_PAYMENT" Then Call insertTabelPindahDana(1, "ASAL VA REJECT", TujuSPKNoText, "Jumlah", nSr(MyRecReadA("NILAI")))
                If nSr(MyRecReadA("KETERANGAN")) = "SPK_VA_SPKDETAIL" Then lblMohonDetailSPK.Text = nSr(MyRecReadA("NILAI"))

                If TujuSPKNoText <> "" Then
                    AsalSPKNoText = Txt_NoSPKMohon.Text
                End If
            End While
            If TujuSPKNoText = "" Then
                AsalSPKNamaText = ""
            End If

            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function

    Function GetDataA_Tabel_SPKASK(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        GetDataA_Tabel_SPKASK = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_SPKASK = IIf(MyRecReadA.HasRows = True, 1, 0)
            Dim mDesc As String = ""
            While MyRecReadA.Read()
                mDesc = "TGL : " & nSr(MyRecReadA("SETUJU_ENTRY")) & _
                        ", STATUS :" & IIf(nSr(MyRecReadA("SETUJU_STATUS")) = "1", "SETUJU", "TOLAK") & _
                        ", OLEH :" & nSr(MyRecReadA("SETUJU_USER")) & _
                        ", CATATAN :" & nSr(MyRecReadA("SETUJU_CATATAN"))
                If nSr(MyRecReadA("SETUJU_POS")) = "0" Then
                    LblAskSPV.Text = LblAskSPV.Text & "- " & mDesc & ""
                ElseIf nSr(MyRecReadA("SETUJU_POS")) = "1" Then
                    LblAskSM.Text = LblAskSM.Text & "- " & mDesc & ""
                ElseIf nSr(MyRecReadA("SETUJU_POS")) = "2" Then
                    LblAskOSM.Text = LblAskOSM.Text & "- " & mDesc & ""
                ElseIf nSr(MyRecReadA("SETUJU_POS")) = "3" Then
                    LblAskDIR.Text = LblAskDIR.Text & "- " & mDesc & ""
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function

    Function GetDataA_TabelPermohonan(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mRincian As String = ""
        Dim mRincianError As String = ""
        Call Msg_err("", 0)
        GetDataA_TabelPermohonan = 0


        mSqlCommadstring = "SELECT TANGGAL_ENTRY,NOMOR_SPK, JUDUL, KETERANGAN, TANGGAL_SETUJU, TANGGAL_ENTRY, TANGGAL_PROSES, NOMOR_MOHON, CABANG, CATATAN, STATUS, APPROVALCODE, NOMOR, APPROVALCODEP, " & _
                           "RUPIAH, CHANGE, MYUSER, Mail, CHANGE1, CHANGE2, CHANGE3,CHANGE4, SPV, SPKAHERR_DESC, SPKAHERR_DESCR " & _
                           "FROM TRXN_SPKAH LEFT OUTER JOIN TRXN_SPKAHERR ON TRXN_SPKAH.NOMOR_MOHON = TRXN_SPKAHERR.SPKAHERR_NOM " & _
                           "WHERE (TRXN_SPKAH.NOMOR_SPK LIKE '%" & Txt_NoSPKMohon.Text & "%') AND ((TRXN_SPKAH.CABANG LIKE '%" & lblArea1.Text & "%') OR " & _
                           "(TRXN_SPKAH.CABANG LIKE '%" & lblArea2.Text & "%')) ORDER BY TRXN_SPKAH.TANGGAL_ENTRY DESC"


        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_TabelPermohonan = IIf(MyRecReadA.HasRows = True, 1, 0)
            Dim mDesc As String = ""
            While MyRecReadA.Read()
                mRincian = Keterangan_perubahannya(nSr(MyRecReadA("JUDUL")), nSr(MyRecReadA("CHANGE")), nSr(MyRecReadA("CHANGE1")), nSr(MyRecReadA("CHANGE2")), nSr(MyRecReadA("CHANGE3")), nSr(MyRecReadA("CHANGE4")))
                mRincianError = nSr(MyRecReadA("SPKAHERR_DESC")) & nSr(MyRecReadA("SPKAHERR_DESCR"))
                Call insertTabelPermohonan(1, nSr(MyRecReadA("JUDUL")), nSr(MyRecReadA("TANGGAL_ENTRY")), nSr(MyRecReadA("TANGGAL_PROSES")), nSr(MyRecReadA("NOMOR_MOHON")), nSr(MyRecReadA("NOMOR")), _
                                           nSr(MyRecReadA("MYUSER")), nSr(MyRecReadA("SPV")), nSr(MyRecReadA("APPROVALCODE")), nSr(MyRecReadA("APPROVALCODEP")), nSr(mRincian), nSr(MyRecReadA("KETERANGAN")), mRincianError)
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function

    '===================================================Update Data
    'Ikutin Sukses Test
    Function DtFr(ByRef mNilai As Object, ByRef mFormat As Object) As String
        DtFr = ""
        If Not IsDBNull(mNilai) Then
            DtFr = Format(mNilai, mFormat)
        End If
    End Function

    Function DtInSQL(ByRef nilai As Object) As String
        DtInSQL = "NULL"
        If Not IsDBNull(nilai) Then
            DtInSQL = "'" & Format(CDate(nilai), "yyyy-MM-dd HH:mm:ss") & "'"
        End If
    End Function

    Function fDb(ByRef nilai As Object) As String
        fDb = "0.00"
        If Not IsDBNull(nilai) Then fDb = Format(nilai, "###,###,###,###,###.#0") '16
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

    Function UpdateDataENTRYAKSESORIS(ByVal mNomorMohon As String, ByVal mServer As String) As Byte
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim MyRecReadF As OleDbDataReader

        Dim mSPV As String
        Dim mDiffHrgSPK As String = ""
        Dim MySTRsql1 As String = "SELECT OPT_NODEALER,OPT_NOMORMOHON,OPT_NOSPK,OPT_USER FROM TRXN_OPTPO WHERE OPT_NOMORMOHON='" & mNomorMohon & "' AND OPT_STATUSPROSES='ENTRY-D' GROUP BY OPT_NODEALER,OPT_NOMORMOHON,OPT_NOSPK,OPT_USER"
        mErrorMySistem = ""
        UpdateDataENTRYAKSESORIS = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadF = cmd.ExecuteReader()
            UpdateDataENTRYAKSESORIS = IIf(MyRecReadF.HasRows = True, 1, 0)
            If UpdateDataENTRYAKSESORIS = 1 Then
                While MyRecReadF.Read()
                    mSPV = ""
                    lblDealer.Text = nSr(MyRecReadF("OPT_NODEALER"))
                    If GetDataA_InputDataDetail_SPKD(nSr(MyRecReadF("OPT_NOSPK")), "", nSr(MyRecReadF("OPT_NOMORMOHON")), nSr(MyRecReadF("OPT_USER")), _
                                            "", "", "", "", 0, mSPV, mDiffHrgSPK, lblDealer.Text) = 0 Then
                        MySTRsql1 = "UPDATE TRXN_OPTPO SET OPT_ERROR='DATA BELUM ADA DI MUGEN' WHERE OPT_NOMORMOHON='" & nSr(MyRecReadF("OPT_NOMORMOHON")) & "' AND OPT_STATUSPROSES='ENTRY-D'"
                    Else
                        MySTRsql1 = "UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='ENTRY',OPT_SPV='" & mSPV & "' WHERE OPT_NOMORMOHON='" & nSr(MyRecReadF("OPT_NOMORMOHON")) & "' AND OPT_STATUSPROSES='ENTRY-D'"
                    End If
                    Call UpdateDatabase_Tabel(MySTRsql1, "", 0)
                End While
            End If
            MyRecReadF.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 0)
        End Try

    End Function

    Function UpdateDataENTRYSPK(ByVal mNomorMohon As String, ByVal mServer As String) As Byte
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim MyRecReadF As OleDbDataReader

        Dim mKodeSpV As String
        Dim mDiffHrgSPK As String = ""
        Dim mJudul As String = ""
        Dim mAdaData As Byte = 0
        Dim MySTRsql1 As String = "SELECT *," & _
            "(select COUNT(SETUJU_NOMOR) from TRXN_SPKAS WHERE SETUJU_POS=0 AND  SETUJU_NOMOR=NOMOR) as mQty," & _
            "(select MAX(SETUJU_USER ) from TRXN_SPKAS WHERE SETUJU_POS=0 AND  SETUJU_NOMOR=NOMOR) as mNama," & _
            "(select MIN(SETUJU_ENTRY) from TRXN_SPKAS WHERE SETUJU_POS=0 AND  SETUJU_NOMOR=NOMOR) as mTgl " & _
            "FROM TRXN_SPKAH WHERE " & _
            "JUDUL LIKE 'ENTRY%'  AND NOMOR_MOHON='" & mNomorMohon & "'" ' AND ISNULL(NOMOR,'') = ''
        mErrorMySistem = ""

        UpdateDataENTRYSPK = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadF = cmd.ExecuteReader()
            UpdateDataENTRYSPK = IIf(MyRecReadF.HasRows = True, 1, 0)
            If UpdateDataENTRYSPK = 1 Then
                While MyRecReadF.Read()
                    mKodeSpV = "" : mDiffHrgSPK = ""
                    mAdaData = 0
                    mJudul = cari_kode_mohon(nSr(MyRecReadF("NOMOR_MOHON")), "JUDUL")

                    If GetDataA_InputDataDetail_SPKD(nSr(MyRecReadF("NOMOR_SPK")), nSr(MyRecReadF("CHANGE")), nSr(MyRecReadF("NOMOR_MOHON")), nSr(MyRecReadF("MYUSER")), _
                                                     nSr(MyRecReadF("CHANGE1")), nSr(MyRecReadF("CHANGE2")), nSr(MyRecReadF("CHANGE3")), nSr(MyRecReadF("CHANGE4")), ndb(MyRecReadF("RUPIAH")), _
                                                     mKodeSpV, mDiffHrgSPK, lblDealer.Text) = 0 Then
                        MySTRsql1 = "UPDATE TRXN_SPKAH SET " & _
                                    "TANGGAL_PROSES =GETDATE(),CATATAN='DATA BELUM ADA DI MUGEN',SPV='" & mKodeSpV & "' " & _
                                    IIf(InStr(mJudul, "DO/ISI") <> 0, ",CHANGE3=" & ndb(mDiffHrgSPK), "") & "  " & _
                                    IIf(InStr(mJudul, "KIRIM UNIT CUSTOMER") <> 0, ",APPROVALCODE='" & mDiffHrgSPK & "'", "") & "  " & _
                                    "WHERE NOMOR_MOHON='" & nSr(MyRecReadF("NOMOR_MOHON")) & "' AND JUDUL LIKE 'ENTRY%' AND TANGGAL_PROSES IS NULL"   'TANGGAL_PROSES IS NULL AND 
                    Else
                        MySTRsql1 = "UPDATE TRXN_SPKAH SET TANGGAL_PROSES =GETDATE(),CATATAN='',SPV='" & mKodeSpV & "' " & _
                                    IIf(InStr(mJudul, "DO/ISI") <> 0, ",CHANGE3=" & ndb(mDiffHrgSPK), "") & "  " & _
                                    IIf(InStr(mJudul, "KIRIM UNIT CUSTOMER") <> 0, ",APPROVALCODE='" & mDiffHrgSPK & "'", "") & "  " & _
                                    "WHERE NOMOR_MOHON='" & nSr(MyRecReadF("NOMOR_MOHON")) & "' AND (JUDUL LIKE 'ENTRY%' OR JUDUL LIKE 'SETUJU%') AND TANGGAL_PROSES IS NULL" '
                        mAdaData = 1
                    End If
                    Call UpdateDatabase_Tabel(MySTRsql1, "", 0)

                    If mAdaData = 1 Then
                        Call AddSaveDataSPKC(nSr(MyRecReadF("NOMOR_SPK")), nSr(MyRecReadF("JUDUL")), nSr(MyRecReadF("CHANGE")), nSr(MyRecReadF("KETERANGAN")))
                        MySTRsql1 = "UPDATE TRXN_SPKC SET " & _
                                    "SPKC_INPUT =" & DtInSQL(MyRecReadF("TANGGAL_ENTRY")) & "," & _
                                    "SPKC_PROSES =" & DtInSQL(MyRecReadF("TANGGAL_PROSES")) & "," & _
                                    "SPKC_NILAITGL =" & DtInSQL(MyRecReadF("TANGGAL_SETUJU")) & " " & _
                                    "WHERE SPKC_NO='" & nSr(MyRecReadF("NOMOR_SPK")) & "' AND SPKC_NAMA='" & mJudul & "'"
                        Call UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text, 0)
                    End If
                End While
            End If
            MyRecReadF.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 0)
        End Try

    End Function

    Function AddSaveDataSPKC(ByVal mNOSPK As String, ByVal mNAMA As String, ByVal mCHANGE As String, ByVal mNILAI1 As String) As Byte
        Dim MySTRsql1 As String = "DELETE FROM TRXN_SPKC WHERE SPKC_NO='" & mNOSPK & "' AND SPKC_NAMA='" & mNAMA & "'"
        Call UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text, 1)
        If AddSaveDataSPKC = 1 Then
            MySTRsql1 = "INSERT INTO TRXN_SPKC(SPKC_NO,SPKC_NAMA,SPKC_NILAI,SPKC_CHANGE,SPKC_NILAITGL,SPKC_INPUT,SPKC_PROSES,SPKC_ST) VALUES " & _
                        "('" & mNOSPK & "','" & mNAMA & "','" & mNILAI1 & "','" & mCHANGE & "',NULL,GETDATE(),GETDATE(),NULL)"
            Call UpdateDatabase_Tabel(MySTRsql1, lblDealer.Text, 1)
        End If
    End Function

    Function GetDataA_InputDataDetail_SPKD(ByVal mpNo_SPK As String, ByVal mChangeOrRangka As String, ByVal mNoMohon_SPK As String, ByVal mUser As String, _
                      ByVal mpChange1 As String, ByVal mpChange2 As String, ByVal mpCHange3 As String, ByVal mpCHange4 As String, ByVal mpRupiah As Double, _
                      ByRef mSPV As String, ByRef mSelisihHrg As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mRincian As String = ""
        Dim mRincianError As String = ""
        Call Msg_err("", 0)
        GetDataA_InputDataDetail_SPKD = 0
        Dim mRunErrorSub As String = ""
        Dim mRunOkeSub As String = ""
        Dim mRunOke As String
        Dim mWarna As String = ""
        Dim mTipe As String = ""
        Dim mErrorCCO As String = ""
        Dim mSalah As String = ""
        Dim mSalahR As String = ""
        Dim mSalahA As String = ""
        Dim mErrorNPWP As String = ""
        Dim mDiffHrg As Double = 0

        Dim mlblHarga As Double
        Dim mlblDisc As Double
        Dim mlblKomisi As Double
        Dim mlblsubsidi As Double
        Dim mlblpaket As String = ""
        Dim mlblType As String = ""
        Dim mlbltglDO As String = ""
        Dim mLblTglSPKKERTAS As String = ""
        Dim mTxtNama As String = ""
        Dim mTxtNamaHonda As String
        Dim mLblTahun As String = ""
        Dim mLblProgram As String = ""
        Dim mNama1 As String = ""
        Dim mroad As String = ""

        Dim mSPKBayar As Double
        Dim asesoris As String
        Dim mLeasing As String = ""
        Dim mLeasSts As String = ""

        Dim mSlsSPK As String = ""
        Dim mSpvSPK As String = ""
        Dim mJabSLS As String = ""

        Dim mSwitchingSPKRejectHDiary As String = ""

        Dim MySTRsql1 As String

        Dim mGetNilai As String = ""

        mSelisihHrg = ""
        mRunOke = ""
        GetDataA_InputDataDetail_SPKD = 0
        mTxtNamaHonda = ""

        MySTRsql1 = "DELETE FROM TRXN_SPKAD WHERE NOMOR_MOHON like '" & mNoMohon_SPK & "'"
        Call UpdateDatabase_Tabel(MySTRsql1, "", 0)

        MySTRsql1 = "DELETE FROM TRXN_SPKAHERR WHERE SPKAHERR_NOM like '%" & mNoMohon_SPK & "%'"
        Call UpdateDatabase_Tabel(MySTRsql1, "", 0)




        'Jika SPK DI reject HDiary

        mSwitchingSPKRejectHDiary = ""
        If InStr(mNoMohon_SPK, "WB/APR/SW") <> 0 Then
            If GetDataD_00NoFound01Found("SELECT SPK_NO FROM TRXN_SPK WHERE SPK_NO='" & mpNo_SPK & "'", lblDealer.Text, 0) = 0 Then
                mSwitchingSPKRejectHDiary = mpNo_SPK
                mpNo_SPK = mpChange1
            End If
        End If

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
            GetDataA_InputDataDetail_SPKD = IIf(MyRecReadA.HasRows = True, 1, 0)
            Dim mDesc As String = ""
            If MyRecReadA.Read Then
                mLeasing = "" : mLeasSts = ""
                mSalah = "" : mSalahR = "" : mNama1 = "" : mroad = "" : mLblTahun = "" : mLblProgram = ""
                mSPKBayar = 0
                GetDataA_InputDataDetail_SPKD = 1
                mTipe = nSr(MyRecReadA("SPK_CDTYPE"))
                mWarna = nSr(MyRecReadA("SPK_CDWARNA"))
                mSPV = nSr(MyRecReadA("SPK_CDSSALES"))
                mlblHarga = ndb((MyRecReadA("SPK_Piutang")))
                mlblDisc = ndb((MyRecReadA("SPK_Potongan")))
                mlblKomisi = nLg((MyRecReadA("SPK_Komisi")))
                mlblsubsidi = nLg((MyRecReadA("SPK_HrgADM")))
                mlblpaket = nSr((MyRecReadA("SPK_PROGRAM")))
                mlblType = nSr((MyRecReadA("SPK_CdType")))
                mlbltglDO = nSr(MyRecReadA("SPK_TglDO"))
                mLblTglSPKKERTAS = nSr(MyRecReadA("SPK_TGLSPK"))
                mTxtNama = nSr((MyRecReadA("SPK_Nama1")))
                mLblTahun = nSr(MyRecReadA("SPK_Tahun"))
                mLblProgram = nSr(MyRecReadA("SPK_PROGRAM"))
                mNama1 = nSr(MyRecReadA("SPK_NAMA1"))
                mroad = nSr(MyRecReadA("SPK_Road"))
                mLeasing = nSr(MyRecReadA("SPK_CdLease"))
                mLeasSts = nSr(MyRecReadA("LEASE_Status"))
                mJabSLS = nSr(MyRecReadA("SALES_JABATAN"))
                If InStr(nSr(MyRecReadA("SPK_Nama1")), "HONDA") <> 0 Then
                    mErrorCCO = "1" : mTxtNamaHonda = "A"
                Else
                    mErrorCCO = nSr(MyRecReadA("SPK_APPRVCR"))
                End If
                If mErrorCCO <> "1" Then
                    mErrorCCO = ",SPK BELUM DIVALIDASI CCO "
                Else
                    mErrorCCO = ""
                End If

                mErrorNPWP = ""
                If nSr(MyRecReadA("SPK_Direct")) = "2" And nSr(MyRecReadA("SPK_NPWP")) = "" Then
                    'mErrorNPWP = ",STATUSNYA PERUSAHAAN HARUS DIISI NPWP"
                End If
                If mLeasing = "K000" And (InStr(1, mNoMohon_SPK, "EM/APR/BH") = 0 And InStr(1, mNoMohon_SPK, "EM/APR/RB")) Then
                    mSalah = mSalah & ",CARA PEMBAYARAN LEASING/TUNAI BELUM DIISI "
                End If


                mUser = UCase(mUser)
                mSPV = UCase(mSPV)
                mSlsSPK = mUser
                mSpvSPK = mSPV
                mSPKBayar = nLg(MyRecReadA("mBayar"))
                If InStr(1, mNoMohon_SPK, "WB/APR/DD") = 0 And InStr(1, mNoMohon_SPK, "WB/APR/MD") = 0 Then
                    If mUser <> mSPV And (InStr(mUser, "112") <> 0 Or InStr(mUser, "128") <> 0) Then
                        If InStr(mUser, lblDealer.Text) <> 0 And Len(mUser) > 3 Then
                            mUser = Right(mUser, Len(mUser) - 3)
                            If mUser <> nSr(MyRecReadA("SPK_CdSales")) Then
                                mSalah = mSalah & ",USER PEMOHON BUKAN SALES SPK "
                            End If
                        Else
                            mSalah = mSalah & ",USER PEMOHON BUKAN SALES SPK "
                        End If
                    ElseIf Not (InStr(mUser, "112") <> 0 Or InStr(mUser, "128") <> 0) Then
                        mSalah = mSalah & ",USER PEMOHON HARUS SALES "
                    End If
                End If
                'Unit,Diskon,Unit/Diskon,Subsidi,Komisi,Diskon maksimal

                If nSr(MyRecReadA("mfNoCancel")) <> "" And Not (InStr(1, mNoMohon_SPK, "WB/APR/UM") <> 0 Or InStr(1, mNoMohon_SPK, "WB/APR/SW") <> 0) Then
                    mSalah = mSalah & ",SPK SUDAH DIBATALKAN"
                ElseIf nSr(MyRecReadA("mfNoCancel")) <> "" And (InStr(1, mNoMohon_SPK, "WB/APR/UM") <> 0) And nLg(MyRecReadA("mBayar")) <= 0 Then
                    mSalah = mSalah & ",UANG MUKA SUDAH KOSONG"
                ElseIf nSr(MyRecReadA("mfNoCancel")) = "" And (InStr(1, mNoMohon_SPK, "WB/APR/UM") <> 0) Then
                    mSalah = mSalah & ",SPK BELUM DI BATALKAN"
                Else
                    If mlbltglDO = "" And InStr(1, mNoMohon_SPK, "WB/APR/AS") = 0 And InStr(1, mNoMohon_SPK, "WB/APR/BH") = 0 Then
                        If nLg(MyRecReadA("SPK_UMRRANGKA")) = 0 Then ' Yang ada duitnya
                            If DateDiff(DateInterval.Day, CDate(MyRecReadA("SPK_TGLSPK")), Now()) > 60 Then
                                'mSalah = mSalah & ",SPK TIDAK AKTIF LEBIH DARI SATU BULAN (BUAT H-DIARY BARU/BATALKAN H3S)"
                            End If
                        ElseIf nLg(MyRecReadA("SPK_UMRRANGKA")) > 7 Then
                            If DateDiff(DateInterval.Day, CDate(MyRecReadA("SPK_TGLSPK")), Now()) > 40 Then
                                'mSalah = mSalah & ",SPK TIDAK AKTIF LEBIH DARI SATU BULAN (BUAT H-DIARY BARU/BATALKAN H3S)"
                            End If
                        End If
                    End If
                End If

                If nSr(MyRecReadA("SPK_TglDO")) <> "" And _
                   (InStr(1, mNoMohon_SPK, "EM/APR/RH1") <> 0 Or _
                    InStr(1, mNoMohon_SPK, "EM/APR/RH2") <> 0 Or _
                    InStr(1, mNoMohon_SPK, "EM/APR/RH0") <> 0 Or _
                    InStr(1, mNoMohon_SPK, "EM/APR/SI") <> 0 Or _
                    InStr(1, mNoMohon_SPK, "EM/APR/KO") <> 0 Or _
                    InStr(1, mNoMohon_SPK, "EM/APR/PC") <> 0 Or _
                    InStr(1, mNoMohon_SPK, "WB/APR/SD") <> 0) Then
                    mSalah = mSalah & ",SUDAH DO HARGA TIDAK BISA DIRUBAH "
                End If

                If nSr(MyRecReadA("SPK_Tahun")) = "" And (InStr(1, mNoMohon_SPK, "WB/APR/SD") <> 0) Then
                    mSalah = mSalah & ",TAHUN BELUM DIISI "
                End If
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_TGLIN", DtFr(MyRecReadA("SPK_Tanggal"), "yyyy-MM-dd"))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_TGLCR", DtFr(MyRecReadA("SPK_TGLSPK"), "yyyy-MM-dd"))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_TGLAP", DtFr(MyRecReadA("SPK_TGLURT"), "yyyy-MM-dd"))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_CDTIPE", nSr(MyRecReadA("SPK_CDTYPE")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_TGLDO", DtFr(MyRecReadA("SPK_TglDO"), "yyyy-MM-dd"))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_NAMA", TxtPetik(MyRecReadA("SPK_Nama1")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_SALES", TxtPetik(MyRecReadA("Sales_Nama")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_IDSALES", TxtPetik(MyRecReadA("SPK_CdSales")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_JNS", nSr(MyRecReadA("LEASE_Nama")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_JNSCD", nSr(MyRecReadA("SPK_Cdlease")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_ROAD", nSr(MyRecReadA("SPK_Road")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_TNR", nLg(MyRecReadA("SPK_HrgASR")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_RANGKA", nSr(MyRecReadA("SPK_NoRangka")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_THN", nSr(MyRecReadA("SPK_Tahun")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_TIPE", nSr(MyRecReadA("TYPE_Nama")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_WARNA", nSr(MyRecReadA("WARNA_Int")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_HARGA", nLg(MyRecReadA("SPK_Piutang")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_PCERMATM", nLg(MyRecReadA("SPK_PaketCermat")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_PCERMATJ", nLg(MyRecReadA("SPK_PaketCermatJ")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_SUBSIDIS", nLg(MyRecReadA("SPK_SubsidiSls")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_DISC", nLg(MyRecReadA("SPK_Potongan")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_TOTAL", (nLg(MyRecReadA("SPK_Piutang")) - nLg(MyRecReadA("SPK_Potongan"))))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_KOMISI", nLg(MyRecReadA("SPK_Komisi")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_SUBSIDI", nLg(MyRecReadA("SPK_HrgADM")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_BAYAR", nLg(MyRecReadA("mBayar")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_SISA", nLg(nLg(MyRecReadA("SPK_Piutang")) - nLg(MyRecReadA("SPK_Potongan")) - nLg(MyRecReadA("mBayar"))))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_HRGSETUJU", nSr(MyRecReadA("SPK_PaketCermat")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_CRVALID", nSr(MyRecReadA("SPK_APPRVCR")))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_TGLKIRIM", DtFr(MyRecReadA("mfTglKirimUnit"), "yyyy-MM-dd"))
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_TGLTERIMA", DtFr(MyRecReadA("mfTglKirimUnitTerima"), "yyyy-MM-dd"))
                If InStr(mNoMohon_SPK, "WB/APR/SW") <> 0 Then
                    mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_ALAMAT", nSr(MyRecReadA("SPK_Alamat")))
                End If
                If mSwitchingSPKRejectHDiary <> "" Then
                    mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_VA_SPKDETAIL", mpNo_SPK)
                    mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_EMAIL", TxtPetik(MyRecReadA("SPK_FEmail")))
                    mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_NOHP", TxtPetik(MyRecReadA("SPK_FHP")))
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()

            If InStr(mRunOke, "1") <> 0 Then
                GetDataA_InputDataDetail_SPKD = 1
            End If

            'Periksa / Validasi data general

            If GetDataA_InputDataDetail_SPKD = 1 Then
                MySTRsql1 = "SELECT * FROM TRXN_SPKAH WHERE NOMOR_SPK LIKE '" & mpNo_SPK & "' AND CABANG='" & lblDealer.Text & "' AND NOMOR_MOHON like '%WB/APR/SD%' AND JUDUL like 'SETUJU%'"
                If (InStr(1, mNoMohon_SPK, "EM/APR/RH1") <> 0 Or InStr(1, mNoMohon_SPK, "EM/APR/RH2") <> 0 Or InStr(1, mNoMohon_SPK, "EM/APR/RH0") <> 0 Or _
                    InStr(1, mNoMohon_SPK, "WB/APR/KO") <> 0 Or InStr(1, mNoMohon_SPK, "WB/APR/SI") <> 0 Or _
                    InStr(1, mNoMohon_SPK, "WB/APR/SD") <> 0 Or InStr(1, mNoMohon_SPK, "WB/APR/PC") <> 0 Or InStr(1, mNoMohon_SPK, "WB/APR/BT") <> 0) And _
                   GetDataD_00NoFound01Found(MySTRsql1, "", 0) = 1 Then
                    mSalah = mSalah & ",SUDAH PERNAH DISETUJUI MAKSIMAL DISKON SM HUBUNGI DIREKTUR "
                Else
                    Dim no_spk_retail As String = GetDataD_IsiField("SELECT SPKD_NILAI as IsiField FROM TRXN_SPKD WHERE SPKD_NO='" & mpNo_SPK & "' AND SPKD_NAMA like '%no_spk_retail%'", lblDealer.Text, 1)

                    If no_spk_retail = "" Then
                        mSalah = mSalah & ", BELUM DIAMBIL DI H-DIARY (HUB-ADMIN STOK)"
                        GetDataA_InputDataDetail_SPKD = 0
                    Else
                        If InStr(1, mNoMohon_SPK, "EM/APR/RH1") <> 0 Then
                            Dim Harga_unitHdiary As String = GetDataD_IsiField("SELECT SPKD_NILAI as IsiField FROM TRXN_SPKD WHERE SPKD_NO='" & mpNo_SPK & "' AND SPKD_NAMA like '%.HARGA'", lblDealer.Text, 1)
                            If ndb(Harga_unitHdiary) > ndb(mChangeOrRangka) Then
                                mSalah = mSalah & ", HARGA UNIT TIDAK BOLEH LEBIH KECIL DARI HARGA H-DIARY "
                            ElseIf ndb(mlblHarga) > ndb(mChangeOrRangka) Then
                                mSalah = mSalah & ", HARGA UNIT TIDAK BOLEH LEBIH KECIL DARI SPK "
                            End If
                        ElseIf (InStr(1, mNoMohon_SPK, "EM/APR/RH0") <> 0 Or _
                            InStr(1, mNoMohon_SPK, "WB/APR/TU") <> 0 Or _
                            InStr(1, mNoMohon_SPK, "WB/APR/WU") <> 0) Then
                            'InStr(1, mNoMohon_SPK, "EM/APR/RH2") <> 0 Or _ 'Diskon diperbolehkan asal lebih kecil
                            mSalah = mSalah & ", GANTI WARNA/TIPE/DISKON/HARGA TDK DIPERBOLEHKAN "
                            If Mid(no_spk_retail, 1, 1) = "D" Then
                                mSalah = mSalah & " (BUAT H-DIARY BARU)"
                            Else
                                mSalah = mSalah & " (HUBUNGI SPV ATAU SM)"
                            End If
                            GetDataA_InputDataDetail_SPKD = 0
                        End If
                    End If
                End If
            End If
            If GetDataA_InputDataDetail_SPKD = 1 Then
                MySTRsql1 = "SELECT SPKB_NILAI AS IsiField FROM TRXN_SPKB WHERE SPKB_NO='" & mpNo_SPK & "' AND SPKB_NAMA like '%UANG MUKA%'"
                mGetNilai = GetDataD_IsiField(MySTRsql1, lblDealer.Text, 1)
                mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_UM", nLg(mGetNilai))

                asesoris = ""
                If (InStr(1, mNoMohon_SPK, "WB/APR/DO") <> 0 Or _
                    InStr(1, mNoMohon_SPK, "WB/APR/AS") <> 0 Or _
                    InStr(1, mNoMohon_SPK, "WB/APR/SD") <> 0) Then
                    MySTRsql1 = "SELECT SPKD_NILAI AS IsiField FROM TRXN_SPKD WHERE SPKD_NO='" & mpNo_SPK & "' AND SPKD_NAMA like '%AKSES%'"
                    asesoris = GetDataD_IsiField(MySTRsql1, lblDealer.Text, 1)
                End If

                If asesoris <> "" Then
                    asesoris = TxtPetik(Trim(asesoris))
                    While Len(asesoris) > 0
                        mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_AKSESORIS", Left(asesoris, 50))
                        If Len(asesoris) <= 50 Then
                            asesoris = ""
                        Else
                            asesoris = Right(asesoris, Len(asesoris) - 50)
                        End If
                    End While
                End If

                If InStr(1, mNoMohon_SPK, "WB/APR/SD") <> 0 Or InStr(1, mNoMohon_SPK, "EM/APR/RH2") <> 0 Then
                    MySTRsql1 = "SELECT SPKD_NILAI AS IsiField FROM TRXN_SPKD where SPKD_NAMA like '%DISC%' AND SPKD_NO='" & mpNo_SPK & "'"
                    Dim mDiskon As String = GetDataD_IsiField(MySTRsql1, lblDealer.Text, 1)
                    If (nLg(mDiskon) + mpRupiah) < nLg(mpChange1) Then
                        'mSalah = mSalah & ",JUMLAH DISKON LEBIH BESAR DENGAN YANG TERCANTUM DI-HDIARY " & fLg(mDiskon)
                    End If
                ElseIf InStr(1, mNoMohon_SPK, "WB/APR/DO") <> 0 Then 'Mau DO periksa maksimal diskon
                    Dim mErrorMaksimalDisc As String
                    mErrorMaksimalDisc = "DONT SHOW"
                    mDiffHrg = 0
                    If mTxtNamaHonda <> "A" And _
                       check_Makdiskon(mlblHarga, mlblDisc, mlblKomisi, mlblsubsidi, _
                                       mlblpaket, mlblType, mlbltglDO, mLblTglSPKKERTAS, mpNo_SPK, mChangeOrRangka, mLblTahun, mTxtNama, mErrorMaksimalDisc, mDiffHrg) = 0 Then
                        mSalah = mSalah & "," & mErrorMaksimalDisc & " "
                        mSelisihHrg = ndb(mDiffHrg)
                    End If
                ElseIf InStr(1, mNoMohon_SPK, "WB/APR/SW") <> 0 Then 'Mau Swithcing
                    If mSwitchingSPKRejectHDiary = "" Then
                        If mlbltglDO <> "" Then
                            mSalah = mSalah & ",SPK ASAL DANA SUDAH DO"
                        End If

                        MySTRsql1 = "SELECT SPKD_NILAI AS IsiField FROM TRXN_SPKD where SPKD_NAMA like '%KTP%' AND SPKD_NO='" & mpNo_SPK & "'"
                        mGetNilai = GetDataD_IsiField(MySTRsql1, lblDealer.Text, 1)
                        mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_NOKTP", mGetNilai)


                        MySTRsql1 = "SELECT SPKD_NILAI AS IsiField FROM TRXN_SPKD where SPKD_NAMA like '%KTP%' AND SPKD_NO='" & mpChange1 & "'"
                        mGetNilai = GetDataD_IsiField(MySTRsql1, lblDealer.Text, 1)
                        mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon_SPK, "SPK_TJNOKTP", mGetNilai)

                        MySTRsql1 = "SELECT *," & _
                                    "(SELECT COUNT(SPKCANCEL_NO) FROM TRXN_SPKCANCEL WHERE SPKCANCEL_NO=SPK_NO) as mBatal," & _
                                    "(SELECT STOCK_Kirimtgl       FROM TRXN_STOCK     WHERE STOCK_NORANGKA=SPK_NORANGKA) AS mfTglKirimUnit," & _
                                    "(SELECT STOCK_Kirimtglterima FROM TRXN_STOCK     WHERE STOCK_NORANGKA=SPK_NORANGKA) AS mfTglKirimUnitTerima," & _
                                    "(SELECT SUM(ISNULL(ARTRAN_JUMLAH,0)) as mfBayar0 FROM TRXN_ARTRAN WHERE ARTRAN_NOSPK=SPK_No AND (ISNULL(ARTRAN_NOWO,'')='')) as mBayar   " & _
                                    "FROM TRXN_SPK WHERE SPK_NO LIKE '" & mpChange1 & "'"
                        mRunOkeSub = "" : mRunErrorSub = ""
                        If GetDataB_ValidA_DataSPKTujuan(MySTRsql1, mNoMohon_SPK, mpChange1, mUser, mRunOkeSub, mRunErrorSub, lblDealer.Text) <> 1 Then
                            mRunErrorSub = "SPK TUJUAN TIDAK ADA DI DATABASE HMS (BELUM DI AMBIL DARI HDIARY)"
                        End If
                        mRunOke = mRunOke & mRunOkeSub
                        mSalah = mSalah & mRunErrorSub
                        If mSPKBayar < nLg(mChangeOrRangka) Then
                            mSalah = mSalah & ",NOMINAL LEBIH BESAR DARI UANG YANG AKAN DIPINDAHKAN"
                        End If
                    Else
                        'Periksa Virtual Account
                        mSalah = mSalah & GetDataVAReject_BasedSPK(mNoMohon_SPK, mpNo_SPK, mSwitchingSPKRejectHDiary, nLg(mChangeOrRangka))
                    End If
                End If
                If InStr(1, mNoMohon_SPK, "WB/APR/DO") <> 0 Or InStr(1, mNoMohon_SPK, "WB/APR/DD") <> 0 Then

                    mSalah = mSalah & mErrorNPWP
                    mSalah = mSalah & mErrorCCO

                    MySTRsql1 = "SELECT *," & _
                                "(SELECT SPK_NO FROM TRXN_SPK WHERE SPK_NORANGKA=STOCK_NORANGKA) as mFldSPK," & _
                                "(SELECT SPK_NODO FROM TRXN_SPK WHERE SPK_NORANGKA=STOCK_NORANGKA) as mFldSPKDO," & _
                                "(SELECT STOCKF_NOSPK FROM TRXN_STOCKFAKTUR WHERE STOCKF_NORANGKA=STOCK_NORANGKA) as mFldSPKFaktur," & _
                                "(SELECT STOCKF_INPUTH3S FROM TRXN_STOCKFAKTUR WHERE STOCKF_NORANGKA=STOCK_NORANGKA) as mFldSPKH3S," & _
                                "(SELECT STOCKF_BATALH3S FROM TRXN_STOCKFAKTUR WHERE STOCKF_NORANGKA=STOCK_NORANGKA) as mFldSPKFakturBATAL " & _
                                "FROM TRXN_STOCK WHERE STOCK_NORANGKA='" & mChangeOrRangka & "'"
                    mRunOkeSub = "" : mRunErrorSub = ""
                    Call GetDataB_ValidB_DataSTOCK(MySTRsql1, mpNo_SPK, mTipe, mWarna, mChangeOrRangka, _
                                lblDealer.Text, mLblTahun, mLblProgram, mRunOkeSub, mRunErrorSub, lblDealer.Text)
                    mSalahR = mSalahR & mRunErrorSub

                    If Not (InStr(1, mNama1, "HONDA") = 1 Or mroad = "F") Then
                        MySTRsql1 = "SELECT * FROM TRXN_SPKB WHERE SPKB_NO='" & mpNo_SPK & "' AND SPKB_NAMA LIKE '%ENTRY TANGGAL TERIMA DOKUMEN BUAT FAKTUR%'"
                        If GetDataD_00NoFound01Found(MySTRsql1, lblDealer.Text, 1) <> 1 Then
                            mSalahR = mSalahR & ",DOKUMEN FAKTUR BELUM DITERImA OLEH ADMIn FAKTUR"
                        End If

                        'MySTRsql1 = "SELECT * FROM TRXN_SPKB WHERE SPKB_NO='" & mpNo_SPK & "' AND SPKB_NAMA LIKE '%ENTRY TANGGAL EMAIL DOKUMEN BUAT FAKTUR%'"
                        'If GetDataD_00NoFound01Found(MySTRsql1, lblDealer.Text, 1) <> 1 Then
                        ' mSalahR = mSalahR & ",DOKUMEN FAKTUR BELUM DIEMAIL KE ADMIN FAKTUR PUSAT"
                        'End If


                    End If

                End If
                'tambahan
                If InStr(1, mNoMohon_SPK, "WB/APR/DO") <> 0 Then 'Periksa ada permohonana tidak
                    MySTRsql1 = "SELECT * FROM TRXN_SPKC WHERE " & _
                                "SPKC_NO='" & mpNo_SPK & "' AND " & _
                                "SPKC_NAMA LIKE '%ENTRY%' AND SPKC_NILAITGL IS NOT NULL AND " & _
                                "NOT(SPKC_NAMA LIKE '%CETAK DO%' OR SPKc_NAMA LIKE '%KIRIM%' OR SPKC_NAMA LIKE '%ALASAN DO%' OR SPKC_NAMA LIKE '%AKSESORIS%' OR SPKC_NAMA LIKE '%KODE SALES%' OR SPKC_NAMA LIKE '%ACCOUNT%'  OR SPKC_NAMA LIKE '%FAKTUR%')"
                    If GetDataD_00NoFound01Found(MySTRsql1, lblDealer.Text, 1) = 1 Then
                        mSalahR = mSalahR & ",ADA PERMOHONAN RUBAH DATA DI HMS DISETUJUI TAPI BLM DIRUBAH"
                    End If
                End If
                If InStr(1, mNoMohon_SPK, "WB/APR/DO") <> 0 Then 'Periksa Sudah Mengajukan Kaca Film Belum
                    MySTRsql1 = "SELECT OPT_NOSPK FROM TRXN_OPTPO,DATA_STANDARD WHERE OPT_CDASS=STANDARD_Kode AND STANDARD_Biaya='K' and OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & mpNo_SPK & "'"
                    If GetDataD_00NoFound01Found(MySTRsql1, "", 1) <> 1 Then
                        MySTRsql1 = "SELECT OPT_NOSPK FROM TRXN_OPT,DATA_STANDARD WHERE OPT_CdAssesoris=STANDARD_Kode AND STANDARD_Biaya='K' AND OPT_NOSPK='" & mpNo_SPK & "'"
                        If GetDataD_00NoFound01Found(MySTRsql1, lblDealer.Text, 1) <> 1 Then
                            mSalah = mSalah & ",BELUM MENGAJUKAN PEMASANG KACA FILM"
                        End If
                    End If
                End If

                If InStr(1, mNoMohon_SPK, "WB/APR/BT") <> 0 Then
                    If nLg(mChangeOrRangka) > 10000000 Then
                        mSalahR = mSalahR & ",SELISIH HARGA TIDAK BOLEH LEBIH DARI 10 JT"
                    ElseIf (nLg(mLblTahun) >= nLg(Format(Now(), "yy"))) Then
                        mSalahR = mSalahR & ",TAHUN SPK SAMA DENGAN ATAU LEBIH BESAR DARI " & Format(Now(), "yy")
                    End If
                End If

                If InStr(1, mNoMohon_SPK, "EM/APR/BS") <> 0 Then
                    MySTRsql1 = "SELECT * ," & _
                                "(SELECT SUM(ISNULL(ARTRAN_JUMLAH,0)) as mfBayar0 FROM TRXN_ARTRAN WHERE ARTRAN_NOSPK=SPK_No AND (ARTRAN_NOWO='' OR ISNULL(ARTRAN_NOWO))) as mBayar " & _
                                "FROM TRXN_SPK WHERE SPK_NO='" & mChangeOrRangka & "'"
                    mRunOkeSub = "" : mRunErrorSub = ""
                    Call GetDataB_ValidB_BATALSPK(MySTRsql1, mSlsSPK, mSpvSPK, mRunOkeSub, mRunErrorSub, "")
                    mSalah = mSalah & mRunOkeSub
                    mSalahR = mSalahR & mRunErrorSub

                End If
                If mTxtNamaHonda <> "A" And _
                  (InStr(mNoMohon_SPK, "WB/APR/FT") <> 0 Or InStr(mNoMohon_SPK, "WB/APR/DO") <> 0 Or _
                   InStr(mNoMohon_SPK, "WB/APR/AS") <> 0) Then
                    'mErrorCCO = VALIDASI_PEMBAYARAN(mpNo_SPK, 100, "N", "GET ERROR")
                    mErrorCCO = GetDataE_VALIDASI_PEMBAYARAN(mpNo_SPK, 30, "N", "GET ERROR", lblDealer.Text)
                    If mErrorCCO <> "" Then
                        mSalah = mSalah & "," & Left(mErrorCCO, 50) & " "
                    End If
                End If
                mSalahA = ""


                If InStr(1, mNoMohon_SPK, "WB/APR/AS") <> 0 Then
                    Dim mMukas As Integer = 0
                    MySTRsql1 = "UPDATE TRXN_OPTPO SET OPT_ERROR='' WHERE OPT_NOMORMOHON='" & mNoMohon_SPK & "' AND OPT_STATUSPROSES='ENTRY-D'"
                    Call UpdateDatabase_Tabel(MySTRsql1, "", 0)

                    If GetDataD_00NoFound01Found("SELECT * FROM TRXN_SPKD WHERE SPKD_NO='" & mpNo_SPK & "' AND SPKD_NAMA='01.NO_SPK_RETAIL' AND (SPKD_NILAI like 'I%' OR SPKD_NILAI like 'P%')", lblDealer.Text, 1) = 1 Then
                        mMukas = 10000000
                    End If


                    If mlbltglDO = "" Then
                        MySTRsql1 = "UPDATE TRXN_OPTPO SET OPT_ERROR='BELUM DO' WHERE OPT_NOMORMOHON='" & mNoMohon_SPK & "' AND OPT_STATUSPROSES='ENTRY-D'"
                        Call UpdateDatabase_Tabel(MySTRsql1, "", 0)
                    ElseIf mlbltglDO <> "" And (mSPKBayar) < (5000000 - mMukas) And Not (mLeasing = "L032" Or mLeasSts = "3") Then
                        MySTRsql1 = "UPDATE TRXN_OPTPO SET OPT_ERROR='UANG MASUK HRS MINIMAL 5 JUTA' WHERE OPT_NOMORMOHON='" & mNoMohon_SPK & "' AND OPT_STATUSPROSES='ENTRY-D'"
                        Call UpdateDatabase_Tabel(MySTRsql1, "", 0)
                    Else
                        MySTRsql1 = "SELECT * FROM TRXN_OPTPO WHERE OPT_NOMORMOHON='" & mNoMohon_SPK & "' AND OPT_STATUSPROSES='ENTRY-D'"
                        mRunOkeSub = "" : mRunErrorSub = ""
                        Call GetDataB_ValidCAksesoris(MySTRsql1, mpNo_SPK, mNoMohon_SPK, mRunOkeSub, mRunErrorSub, lblDealer.Text)
                    End If
                End If

            ElseIf InStr(1, mNoMohon_SPK, "WB/APR/SW") <> 0 Then 'Mau Swithcing Spk Asal Direject di H-Diary
                'dodoal_MyRecReadB_MyRecReadC()
            Else
                mSalah = mSalah & ",DATA SPK BELUM LENGKAP"
            End If

            'Spesial untuk yang error Batal H3S tidak usah ada 
            If InStr(1, mNoMohon_SPK, "WB/APR/BH") <> 0 Then
                MySTRsql1 = "SELECT STOCKF_INPUTH3S,STOCKF_BATALH3S FROM TRXN_STOCKFAKTUR WHERE STOCKF_NOSPK='" & mpNo_SPK & "' AND STOCKF_BATALH3S IS NULL"
                If mlbltglDO <> "" Then
                    mSalah = mSalah & ",SPK SUDAH DI DO TIDAK BISA BATAL H3S"
                ElseIf GetDataD_00NoFound01Found(MySTRsql1, lblDealer.Text, 1) = 1 Then
                    mSalah = mSalah & ",SPK INI SEDANG PROSES DI FAKTUR H3S"
                End If
            End If

            If InStr(1, mNoMohon_SPK, "WB/APR/MC") <> 0 Then
                Dim mTGlKtgld As String = Mid(mChangeOrRangka, 1, 2) 'dd-MM-yyyy:HH
                Dim mTGlKtglm As String = Mid(mChangeOrRangka, 4, 2)
                Dim mTGlKtgly As String = Mid(mChangeOrRangka, 7, 4)
                Dim mTGlKtglj As String = Mid(mChangeOrRangka, 12, 2)
                mSelisihHrg = IIf(mJabSLS = "2", "1", "0") & "4"
                mTGlKtgld = InputDT(mTGlKtgly, mTGlKtglm, mTGlKtgld, "00", "00", "00", "")
                mSalah = mSalah & Validasi_Kirim_unit(1, mTGlKtgld, mTGlKtglj)
            End If

            If (mSalah & mSalahR & mErrorMySistem) <> "" Then
                If mSalah = "DATA TIDAK ADA DI SISTEM MUGEN (BELUM MASUK DARI HDIARY)" Then
                    MySTRsql1 = "DELETE FROM TRXN_SPKAHERR WHERE SPKAHERR_NOM like '" & Left(mNoMohon_SPK, 10) & "%'"
                    Call UpdateDatabase_Tabel(MySTRsql1, "", 0)
                    MySTRsql1 = "SELECT NOMOR_MOHON FROM TRXN_SPKAH WHERE NOMOR_SPK='" & mpNo_SPK & "' AND CABANG='" & lblDealer.Text & "' GROUP BY NOMOR_MOHON"
                    Call GetDataB_ValidD_AsesorisDnet(MySTRsql1, mSalah & mErrorMySistem, mSalahR, mRunOkeSub, mRunErrorSub, "")
                Else
                    MySTRsql1 = "INSERT INTO TRXN_SPKAHERR (SPKAHERR_NOM,SPKAHERR_DESC,SPKAHERR_DESCR) VALUES ('" & mNoMohon_SPK & "','" & Left(TxtPetik(mSalah & mErrorMySistem), 300) & "','" & Left(TxtPetik(mSalahR), 200) & "')"
                    Call UpdateDatabase_Tabel(MySTRsql1, "", 0)
                End If
            End If
        Catch ex As Exception
            Call Msg_err(ex.Message, 1)
        End Try

    End Function

    Function cari_kode_mohon(ByVal mData As String, ByVal mTipe As String) As String
        Dim mMohon1 As String
        Dim MySTRsql1 As String
        mMohon1 = ""
        cari_kode_mohon = ""
        If mTipe = "JUDUL" Then
            'Cari Judul
            MySTRsql1 = "SELECT * FROM DATA_PARAMETER WHERE PARAMETER_NAMA like 'APPRVC%'"
            mMohon1 = GetDataA_cari_kode_mohon2(MySTRsql1, mData, "")
            If mMohon1 <> "" Then
                MySTRsql1 = "SELECT PARAMETER_NILAI AS IsiField FROM DATA_PARAMETER WHERE PARAMETER_NAMA LIKE '" & mMohon1 & "%'"
                cari_kode_mohon = GetDataD_IsiField(MySTRsql1, "", 0)
            End If
        Else
            'Cari Kode

            MySTRsql1 = "SELECT * FROM DATA_PARAMETER WHERE PARAMETER_NAMA like 'APPRVL%' AND PARAMETER_NILAI LIKE '%" & mData & "%'"
            mMohon1 = GetDataA_cari_kode_mohon3(MySTRsql1, mData, "")
            If mMohon1 <> "" Then

                MySTRsql1 = "SELECT PARAMETER_NILAI AS IsiField FROM DATA_PARAMETER WHERE PARAMETER_NAMA LIKE '%" & mMohon1 & "%'"
                cari_kode_mohon = GetDataD_IsiField(MySTRsql1, "", 0)
            End If
        End If
    End Function
    Function GetDataA_cari_kode_mohon2(ByVal mSqlText As String, ByVal mpData As String, ByVal mServer As String) As String
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        GetDataA_cari_kode_mohon2 = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlText, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_cari_kode_mohon2 = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                If InStr(mpData, nSr(MyRecReadA("PARAMETER_NILAI"))) <> 0 Then
                    GetDataA_cari_kode_mohon2 = Replace(nSr(MyRecReadA("PARAMETER_NAMA")), "APPRVC", "APPRVL") & "0"
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 0)
        End Try

    End Function
    Function GetDataA_cari_kode_mohon3(ByVal mSqlText As String, ByVal mpData As String, ByVal mServer As String) As String
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        GetDataA_cari_kode_mohon3 = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlText, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_cari_kode_mohon3 = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                GetDataA_cari_kode_mohon3 = Mid(nSr(MyRecReadA("PARAMETER_NAMA")), 1, 8)
                GetDataA_cari_kode_mohon3 = Replace(GetDataA_cari_kode_mohon3, "APPRVL", "APPRVC")
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 0)
        End Try

    End Function

    Function Tambah_tabel_spkad(ByVal mNOM As String, ByVal mJUD As String, ByVal mNIL As String) As Byte
        Dim MySTRsql1 As String = "INSERT INTO TRXN_SPKAD(NOMOR_MOHON,KETERANGAN,NILAI) VALUES ('" & mNOM & "','" & mJUD & "','" & Left(mNIL, 50) & "')"
        Tambah_tabel_spkad = UpdateDatabase_Tabel(MySTRsql1, "", 0)
    End Function

    Function check_Makdiskon(ByVal mfHargaUnit As Double, ByVal mfDisc As Double, ByVal mfKoms As Double, ByVal mfSubs As Double, _
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
        mPembanding = (ndb(mfDisc) + ndb(mfKoms) - ndb(mfSubs))
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
                check_Makdiskon = 0 'Tidak Boleh
            Else
                check_Makdiskon = 1  'Boleh
            End If
        End If
        If check_Makdiskon <> 1 Then
            If mShowError = "" Then
                'MsgBox("TOTAL DARI (POTONGAN+SUBSIDI+KOMISI) = Rp." & fDb(mPembanding) & " TDK BOLEH LBH DARI MAX Rp." & fDb(mMaxDisc))
            Else
                mfErrorMsg = "TOTAL(POTONGAN-SUBSIDI+KOMISI)=Rp." & fDb(mPembanding) & " LBH DARI (MAX+Selisi Harga) Rp." & fDb(mMaxDisc) & "+ Rp." & fDb(mMaxDiff)
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
            mCriteria = GetDataD_IsiField("SELECT TYPE_CdRangka AS IsiField FROM DATA_TYPE WHERE TYPE_Type='" & mfType & "'", lblDealer.Text, 1)


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

        GETType_MakDiscount_Web_Mail = nLg(GetDataD_IsiField("SELECT TYPED_Jumlah AS IsiField FROM DATA_TYPED,DATA_TYPE WHERE  TYPED_TYPE=TYPE_TYPE AND TYPED_TYPE = '" & mfType & "' AND " & mCriteria & " AND DATEDIFF(DAY,TYPED_TANGGAL," & DtInSQL(mfTgl) & ") >= 0 ORDER BY TYPED_TANGGAL DESC", lblDealer.Text, 1))

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
            mCriteria = GetDataD_IsiField("SELECT TYPE_CdRangka AS IsiField FROM DATA_TYPE WHERE TYPE_Type='" & mfType & "'", lblDealer.Text, 1)

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

        Dim mNilai As String = GetDataD_IsiField("SELECT TYPESH_Jumlah AS IsiField FROM DATA_TYPESH,DATA_TYPE WHERE  TYPESH_TYPE=TYPE_TYPE AND TYPESH_TYPE = '" & mfType & "' AND " & mCriteria & " AND DATEDIFF(DAY," & DtInSQL(mfTgl) & ",TYPESH_TANGGAL) >= 0 ORDER BY TYPESH_TANGGAL DESC", lblDealer.Text, 1)
        GETType_Differeny_Web_Mail = nLg(mNilai)

    End Function

    Function GetDataB_ValidA_DataSPKTujuan(ByVal mSqlCommadstring As String, ByVal pmNoMhnPSK As String, ByVal pmChange1 As String, ByVal pmUser As String, ByRef mRun1 As String, ByRef mErr1 As String, ByVal mServer As String) As Byte
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        GetDataB_ValidA_DataSPKTujuan = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                GetDataB_ValidA_DataSPKTujuan = 1
                If MyRecReadB.Read Then
                    If nSr(MyRecReadB("SPK_CDSALES")) <> pmUser Then
                        mErr1 = mErr1 & ",SPK TUJUAN KODE SALESNYA BERBEDA DGN SPK ASAL "
                    End If

                    If nLg(MyRecReadB("mBatal")) <> 0 Then
                        mErr1 = mErr1 & ",SPK TUJUAN SUDAH DIBATALKAN"
                    End If

                    mRun1 = mRun1 & Tambah_tabel_spkad(pmNoMhnPSK, "SPK_TJNOSPK", pmChange1)
                    mRun1 = mRun1 & Tambah_tabel_spkad(pmNoMhnPSK, "SPK_TJTGLDO", DtFr(MyRecReadB("SPK_TglDO"), "yyyy-MM-dd"))
                    mRun1 = mRun1 & Tambah_tabel_spkad(pmNoMhnPSK, "SPK_TJNAMA", TxtPetik(MyRecReadB("SPK_Nama1")))
                    mRun1 = mRun1 & Tambah_tabel_spkad(pmNoMhnPSK, "SPK_TJALAMAT", nSr(MyRecReadB("SPK_Alamat")) & " " & nSr(MyRecReadB("SPK_Kota")))
                    mRun1 = mRun1 & Tambah_tabel_spkad(pmNoMhnPSK, "SPK_TJBAYAR", nLg(MyRecReadB("mBayar")))
                    mRun1 = mRun1 & Tambah_tabel_spkad(pmNoMhnPSK, "SPK_TJEMAIL", TxtPetik(MyRecReadB("SPK_FEmail")))
                    mRun1 = mRun1 & Tambah_tabel_spkad(pmNoMhnPSK, "SPK_TJNOHP", TxtPetik(MyRecReadB("SPK_FHP")))
                End If
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 1)
        End Try
    End Function

    Function GetDataB_ValidB_DataSTOCK(ByVal mSqlCommadstring As String, _
                    ByVal pmNoPSK As String, ByVal pmTipe As String, ByVal pmWarna As String, ByVal pmChangeOrRangka As String, ByVal mDealer As String, _
                    ByVal pmTahun As String, ByVal pmProgram As String, _
                    ByRef mRun1 As String, ByRef mErr1 As String, ByVal mServer As String) As String
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        GetDataB_ValidB_DataSTOCK = ""
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                If MyRecReadB.Read Then
                    'Warna dan Tipe Diperiksa
                    If nSr(MyRecReadB("STOCK_CDTYPE")) <> pmTipe Then
                        mErr1 = mErr1 & ",TIPE SPK BERBEDA DGN RANGKA "
                    End If
                    If nSr(MyRecReadB("STOCK_CDWARNA")) <> pmWarna Then
                        mErr1 = mErr1 & ",WARNA SPK BERBEDA DGN RANGKA "
                    End If
                    If nSr(MyRecReadB("STOCK_NoIndent")) = "1" Then
                        If nSr(MyRecReadB("STOCK_BlockPickup")) = "2" Then
                            mErr1 = mErr1 & "RANGKA INI SDG DIALOKASIKAN MUGEN " & If(mDealer = "112", "128", "112")
                        Else
                            mErr1 = mErr1 & "RANGKA INI SDG PROSES RETURN (CALL ADMIN STOK)"
                        End If
                    End If
                    If nSr(MyRecReadB("mFldSPK")) <> "" And nSr(MyRecReadB("mFldSPK")) <> pmNoPSK Then
                        mErr1 = mErr1 & ",RANGKA DIPESAN OLEH SPK " & nSr(MyRecReadB("mfldSPK")) & " "
                        'If nSr(MyRecReadb("mFldSPKDO")) <> "" Then
                        'mErr1 = mErr1 & ",RANGKA DIPESAN OLEH SPK " & nSr(MyRecReadb("mfldSPK")) & " "
                        'Else
                        'mErr1 = mErr1 & ",RANGKA DIPESAN OLEH SPK " & nSr(MyRecReadb("mfldSPK")) & " "
                        'End If
                    ElseIf nSr(MyRecReadB("mFldSPK")) <> "" And nSr(MyRecReadB("mFldSPK")) = pmNoPSK And nSr(MyRecReadB("mFldSPKDO")) <> "" Then
                        mErr1 = mErr1 & ",SUDAH DO OLEH SPK " & nSr(MyRecReadB("mFldSPK")) & " "
                    End If

                    If nSr(MyRecReadB("mFldSPKFakturBATAL")) = "" And _
                       nSr(MyRecReadB("mFldSPKH3S")) <> "" And nSr(MyRecReadB("mFldSPKFaktur")) <> pmNoPSK Then
                        mErr1 = mErr1 & ",SDH FAKTUR H3S OLEH SPK " & IIf(nSr(MyRecReadB("mFldSPKFaktur")) = "", "SPK FIKTIF", nSr(MyRecReadB("mFldSPKFaktur"))) & " "
                    End If
                    If (Asc(Mid(pmChangeOrRangka, 10, 1)) >= 74 And Val(pmTahun) <> (Asc(Mid(pmChangeOrRangka, 10, 1)) - 56)) Or _
                       (Asc(Mid(pmChangeOrRangka, 10, 1)) < 74 And Val(pmTahun) <> (Asc(Mid(pmChangeOrRangka, 10, 1)) - 55)) Then
                        mErr1 = mErr1 & ",TAHUN SPK BERBEDA TAHUN RANGKANYA "
                        If pmProgram <> "" Then
                            mErr1 = mErr1 & ",SUDAH DISETUJUI MAKSIMAL DISKON TAPI TAHUN SPK BERBEDA RANGKANYA,(PERSETUJUAN AKAN BATAL JIKA RUBAH THN SPK) "
                        End If
                    End If
                End If
            Else
                mErr1 = mErr1 & ",RANGKA BELUM ADA DI STOK "
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 1)
        End Try
    End Function

    Function GetDataB_ValidB_BATALSPK(ByVal mSqlCommadstring As String, _
                ByVal mpSlsSPK As String, ByVal mpSpvSPK As String, ByRef mErr1 As String, ByRef mErr2 As String, ByVal mServer As String) As Byte
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        mErr1 = ""
        GetDataB_ValidB_BATALSPK = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                GetDataB_ValidB_BATALSPK = 1
                If MyRecReadB.Read Then
                    If mpSlsSPK <> mpSpvSPK And (InStr(mpSlsSPK, "112") <> 0 Or InStr(mpSlsSPK, "128") <> 0) Then
                        If InStr(mpSlsSPK, lblDealer.Text) <> 0 And Len(mpSlsSPK) > 3 Then
                            mpSlsSPK = Right(mpSlsSPK, Len(mpSlsSPK) - 3)
                            If mpSlsSPK <> nSr(MyRecReadA("SPK_CdSales")) Then
                                mErr1 = mErr1 & ",USER PEMOHON BUKAN SALES SPK BATAL"
                            End If
                        Else
                            mErr1 = mErr1 & ",USER PEMOHON BUKAN SALES SPK BATAL"
                        End If
                    ElseIf Not (InStr(mpSlsSPK, "112") <> 0 Or InStr(mpSlsSPK, "128") <> 0) Then
                        mErr1 = mErr1 & ",USER PEMOHON HARUS SALES "
                    End If
                    If 0 <> ndb(MyRecReadA("mBayar")) Then
                        mErr2 = mErr2 & ",Masih ada uang DownPaymentnya"
                    End If
                End If
            Else
                mErr1 = mErr1 & ",RANGKA BELUM ADA DI STOK "
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 1)
        End Try
    End Function

    Function GetDataE_VALIDASI_PEMBAYARAN(ByVal mpNospk As String, ByVal mpPercent As Double, ByVal mpAss As String, ByVal mpTipe As String, ByVal mpServer As String) As String
        Dim mCustomBayarUnit As Double
        Dim mCustomBayarAss As Double
        Dim UangMuka As Double
        Dim mSyarat As String
        Dim mMukas As Double
        Dim MyRecReadE As OleDbDataReader

        mSyarat = ""

        mCustomBayarUnit = ndb(JmlBayarARTRAN("ARTRAN_NOSPK='" & mpNospk & "' AND (ARTRAN_CdAss='0000' OR ISNULL(ARTRAN_CdAss,'')='')"))
        mCustomBayarAss = ndb(JmlBayarARTRAN("ARTRAN_NOSPK='" & mpNospk & "' AND NOT(ARTRAN_CdAss='0000' OR ISNULL(ARTRAN_CdAss,'')='')"))

        GetDataE_VALIDASI_PEMBAYARAN = ""
        mMukas = 0

        If GetDataD_00NoFound01Found("SELECT * FROM TRXN_SPKD WHERE SPKD_NO='" & mpNospk & "' AND SPKD_NAMA='01.NO_SPK_RETAIL' AND (SPKD_NILAI like 'I%')", lblArea1.Text, 1) = 1 Then
            mMukas = 10000000
        ElseIf GetDataD_00NoFound01Found("SELECT * FROM TRXN_SPKD WHERE SPKD_NO='" & mpNospk & "' AND SPKD_NAMA='01.NO_SPK_RETAIL' AND (SPKD_NILAI like 'P%')", lblArea1.Text, 1) = 1 Then
            mMukas = Val(AddSaveDataSPKB(mpNospk, "UANG MASUK DI PAMERAN", "", "", "", "CARI"))
        End If

        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        Dim MySTRsql2 As String = "SELECT * FROM TRXN_SPK,DATA_LEASE WHERE SPK_CDLEASE=LEASE_KODE AND SPK_NO='" & mpNospk & "'"
        cnn = New OleDbConnection(strconn)


        Try
            cnn.Open()
            cmd = New OleDbCommand(MySTRsql2, cnn)
            MyRecReadE = cmd.ExecuteReader()
            If MyRecReadE.HasRows = True Then
                While MyRecReadE.Read
                    If mMukas = 0 Then
                        If nSr(MyRecReadE("SPK_KDREF")) = "12" Then
                            mMukas = 10000000
                        End If
                    End If
                    UangMuka = 0
                    If nSr(MyRecReadE("SPK_CdLease")) = "C001" Then  'Cash dari persen disetting
                        UangMuka = nLg(MyRecReadE("SPK_Piutang")) - nLg(MyRecReadE("SPK_Potongan"))
                        UangMuka = UangMuka * (mpPercent / 100)
                        If (UangMuka - (mCustomBayarUnit + mMukas)) > 0 Then
                            mSyarat = mpPercent & "% DARI HARGA JUAL SEBESAR " & fLg(UangMuka)
                            GetDataE_VALIDASI_PEMBAYARAN = "KARENA BELUM LUNAS, PELUNASAN HARUS " & mpPercent & "% HARGA JUAL !!!!  \n"
                        End If
                    ElseIf Not (nSr(MyRecReadE("SPK_CdLease")) = "C001" Or nSr(MyRecReadE("SPK_CdLease")) = "L032" Or nSr(MyRecReadE("LEASE_Status")) = "3") Then 'Non Cash harus lunas DP
                        If AddSaveDataSPKB(mpNospk, "TANGGAL P.O. LEASING", "", "", "", "CARITANGGAL") = "" Then
                            mSyarat = "100% DARI UANG MUKA (BELUM DIMASUKAN PO LEASING)"
                            GetDataE_VALIDASI_PEMBAYARAN = GetDataE_VALIDASI_PEMBAYARAN & ("KARENA TANGGAL PO LEASING BELUM DIISI !!!!") & Chr(13)
                        Else
                            UangMuka = Val(AddSaveDataSPKB(mpNospk, "TOTAL UANG MUKA", "", "", "", "CARI"))
                            If UangMuka <= 0 Then
                                mSyarat = "100% DARI HARGA UANG MUKA SEBESAR ? "
                                GetDataE_VALIDASI_PEMBAYARAN = GetDataE_VALIDASI_PEMBAYARAN & ("KARENA UANG MUKA BELUM DIISI !!!!") & Chr(13)
                            ElseIf (UangMuka - (mCustomBayarUnit + mMukas)) > 0 Then
                                mSyarat = "100% DARI HARGA UANG MUKA SEBESAR " & fLg(UangMuka)
                                GetDataE_VALIDASI_PEMBAYARAN = GetDataE_VALIDASI_PEMBAYARAN & "KARENA BELUM LUNAS UANG MUKA / DOWN-PAYMENT !!!!  \n"
                            End If
                        End If
                    End If
                    'If (nLg(MyRecReadC("SPK_HrgASS")) - mCustomBayarAss) > 0 And mpAss = "Y" Then
                    'VALIDASI_PEMBAYARAN = VALIDASI_PEMBAYARAN & "KARENA BELUM LUNAS PEMBAYARAN ASESORIS !!!!  \n"
                    'End If
                End While
            End If
            MyRecReadE.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 1)
        End Try
    End Function

    Function GetDataB_ValidCAksesoris(ByVal mSqlCommadstring As String, _
                ByVal pmNoPSK As String, ByVal pmNoMohon_SPK As String, _
                ByRef mRun1 As String, ByRef mErr1 As String, ByVal mServer As String) As String
        Dim mpServer = "MyConnCloudDnet"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        Dim MySTRsql2 As String
        GetDataB_ValidCAksesoris = ""
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                While MyRecReadB.Read
                    MySTRsql2 = "SELECT * FROM TRXN_OPT WHERE (OPT_NOSPK='" & pmNoPSK & "' OR (OPT_NORANGKA='' AND NOT(ISNULL(OPT_NORANGKA,'')=''))) AND OPT_CDASSESORIS='" & nSr(MyRecReadB("OPT_CDASS")) & "' AND ISNULL(OPT_NOWO,'')<>''"
                    MySTRsql2 = "SELECT * FROM TRXN_OPT WHERE OPT_NOSPK='" & pmNoPSK & "' AND OPT_CDASSESORIS='" & nSr(MyRecReadB("OPT_CDASS")) & "' AND ISNULL(OPT_NOWO,'')<>''"
                    Call GetDataC_ValidC_AAksesoris(MySTRsql2, pmNoMohon_SPK, nSr(MyRecReadB("OPT_CDASS")), mRun1, mErr1, mServer)
                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function
    Function GetDataC_ValidC_AAksesoris(ByVal mSqlCommadstring As String, _
                    ByVal pmNoMohon_SPK As String, ByVal pmCDASS As String, _
                    ByRef mRun1 As String, ByRef mErr1 As String, ByVal mServer As String) As String
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mRincian As String = ""
        Dim mRincianError As String = ""
        Call Msg_err("", 0)
        Dim MySTRsql3 As String
        GetDataC_ValidC_AAksesoris = ""
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadC = cmd.ExecuteReader()
            If MyRecReadC.HasRows = True Then
                While MyRecReadC.Read
                    MySTRsql3 = "UPDATE TRXN_OPTPO SET OPT_NOWO='" & nSr(MyRecReadC("OPT_NOWO")) & "',OPT_ERROR='SUDAH ADA NO WO' WHERE OPT_NOMORMOHON='" & pmNoMohon_SPK & "' AND OPT_CDASS='" & pmCDASS & "'"
                    Call UpdateDatabase_Tabel(MySTRsql3, "", 0)
                End While
            End If
            MyRecReadC.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function
    Function GetDataB_ValidD_AsesorisDnet(ByVal mSqlCommadstring As String, _
            ByVal pmError As String, ByVal pmErrorR As String, _
            ByRef mRun1 As String, ByRef mErr1 As String, ByVal pmServer As String) As String
        pmServer = "MyConnCloudDnet" & pmServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(pmServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        Dim MySTRsql2 As String
        GetDataB_ValidD_AsesorisDnet = ""
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                While MyRecReadB.Read
                    MySTRsql2 = "INSERT INTO TRXN_SPKAHERR (SPKAHERR_NOM,SPKAHERR_DESC,SPKAHERR_DESCR) VALUES ('" & nSr(MyRecReadB("NOMOR_MOHON")) & "','" & Left(TxtPetik(pmError), 300) & "','" & Left(TxtPetik(pmErrorR), 200) & "')"
                    Call UpdateDatabase_Tabel(MySTRsql2, "", 0)
                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function

    Function JmlBayarARTRAN(ByVal mQuery As String) As Double
        JmlBayarARTRAN = nLg(GetDataD_IsiField("SELECT ARTRAN_NOSPK, SUM(ISNULL(ARTRAN_JUMLAH, 0)) as IsiField FROM TRXN_ARTRAN WHERE " & mQuery & " GROUP BY ARTRAN_NOSPK", lblArea1.Text, 1))
    End Function

    Function AddSaveDataSPKB(ByVal mNOSPK As String, ByVal mNAMA As String, ByVal mNILAI1 As String, ByVal mNILAI2 As String, ByVal mInput As String, ByVal mSts As String) As String
        On Error GoTo ErrHand
        AddSaveDataSPKB = ""
        If mSts = "CARI" Then
            AddSaveDataSPKB = GetDataD_IsiField("SELECT SPKB_NILAI AS IsiField FROM TRXN_SPKB WHERE SPKB_NO='" & mNOSPK & "' AND SPKB_NAMA like '%" & mNAMA & "%'", lblArea1.Text, 1)
        ElseIf mSts = "CARITANGGAL" Then
            AddSaveDataSPKB = GetDataD_IsiField("SELECT SPKB_NILAITGL AS IsiField FROM TRXN_SPKB WHERE SPKB_NO='" & mNOSPK & "' AND SPKB_NAMA like '%" & mNAMA & "%'", lblArea1.Text, 1)
        End If
        Exit Function
ErrHand:
    End Function

    Protected Sub BtnVASave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVASave.Click
        Dim mErr As String = ""
        If Not IsNumeric(TxtVANoSPK.Text) Or TxtVANoSPK.Text = "" Or TxtVANama.Text = "" Or TxtVAEmail.Text = "" Or TxtVANoHP.Text = "" Then
            Call Msg_err("Isian Data belum lengkap ", 0) : Exit Sub
        ElseIf nLg(TxtVAJumlah.Text) < 50000 Then
            Call Msg_err("Minimum transaksi Rp. 50.000  ............ ", 0) : Exit Sub
        End If
        'Dim mBoleh As Byte = GetDataVA_CariDataSPK(0)

        Call GetDataVA_UpdatePaymnt()
        Call GetDataVA_Create()
        Call GetDataVA_BasedSPK()
        If lblArea1.Text = "112" Then
            ListViewVA112.DataBind()
            MultiViewTabelVA.ActiveViewIndex = 0
        Else
            ListViewVA128.DataBind()
            MultiViewTabelVA.ActiveViewIndex = 1
        End If

    End Sub
    Protected Sub BtnVACheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVACheck.Click
        If TxtVANoSPK.Text = "" Then
            Call Msg_err("No SPK Belum DiIsian ..................", 0) : Exit Sub
        Else
            Call GetDataVA_UpdatePaymnt()
            Call Pengakuan_Transaksi_Virtual_Account()
            Call GetDataVA_BasedSPK()
            If lblArea1.Text = "112" Then
                ListViewVA112.DataBind()
                MultiViewTabelVA.ActiveViewIndex = 0
            Else
                ListViewVA128.DataBind()
                MultiViewTabelVA.ActiveViewIndex = 1
            End If

        End If
    End Sub

    Protected Sub BtnVAEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVAEmail.Click
        Call SendEMailVA()
    End Sub
    Sub SendEMailVA()
        If LblVANomor.Text <> "" And TxtVAEmail.Text <> "" Then
            Call SendEmailProcesVA(TxtVAEmail.Text, "Nomor Transaksi Virtual Honda Mugen", "", "", LblVANomor.Text, LblVANomor1.Text)
            Call Msg_err("Email teleh terkirim .............", 0)
        Else
            Call Msg_err("Periksa Email dan isian data-datanya ", 0)
        End If
    End Sub

    Protected Sub BtnVAClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVAClear.Click
        Call ClearInputDataVA()
        MultiViewTabelVA.ActiveViewIndex = -1
    End Sub

    Function GetDataVA_UpdatePaymnt() As String
        Dim pmServer As String = "MyConnCloudDnetVA112"
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(pmServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)

        GetDataVA_UpdatePaymnt = ""
        Dim mSqlCommadstring As String = "SELECT * FROM Trxn_Bill WHERE Dealer='" & lblArea1.Text & "' AND Dept='1' AND tglPayment IS NOT NULL  AND tglReadPaym IS NULL ORDER BY refNo"
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read
                    mSqlCommadstring = "UPDATE Trxn_VIRTUALACC SET " & _
                                       "VIRTUAL_STATUS=0," & _
                                       "VIRTUAL_TGLPYMT=GETDATE()," & _
                                       "VIRTUAL_TGLPYMTVA=" & DtFrSQL(MyRecReadA("tglPayment")) & "," & _
                                       "VIRTUAL_RRN='" & nSr(MyRecReadA("RRN")) & "'," & _
                                       "VIRTUAL_TID='" & nSr(MyRecReadA("TID")) & "'," & _
                                       "VIRTUAL_AID=" & nSr(MyRecReadA("AID")) & " " & _
                                       "WHERE VIRTUAL_REF=" & nLg(MyRecReadA("refNo"))
                    If UpdateDatabase_Tabel(mSqlCommadstring, lblArea1.Text, 0) = 1 Then
                        mSqlCommadstring = "UPDATE Trxn_Bill SET tglReadPaym=GETDATE()  WHERE Dealer='" & lblArea1.Text & "' AND Dept='1' AND refNo=" & nSr(MyRecReadA("refNo")) & ""
                        Call UpdateDatabase_Tabel(mSqlCommadstring, "VA112", 0)
                    End If
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function


    Function GetDataVAReject_BasedSPK(ByVal mNoMohon As String, ByVal mNospkTujuan As String, ByVal mSPKReject As String, ByVal mJumlah As Double) As String
        Dim pmServer As String = "MyConnCloudDnet" & lblArea1.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(pmServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mRunOke As String = ""

        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)

        GetDataVAReject_BasedSPK = ""
        Dim mSqlCommadstring As String = "select * from trxn_virtualacc,TRXN_VIRTUALACCD where virtual_ref=virtuald_ref and VIRTUAL_NOKODE='A' AND VIRTUAL_NO='" & mSPKReject & "' AND VIRTUAL_TGLPYMT IS NOT NULL AND VIRTUAL_HMSDOCTGL IS NULL ORDER BY VIRTUAL_REF"
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                Dim mTotalVA As Double = 0
                While MyRecReadA.Read
                    mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon, "SPK_VA_NOREJECT", nSr((MyRecReadA("VIRTUAL_ACCOUNT"))))
                    mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon, "SPK_VA_PEMOHON", nSr((MyRecReadA("VIRTUALD_PEMOHON"))))
                    mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon, "SPK_VA_NAMA", nSr((MyRecReadA("VIRTUALD_NAMA"))))
                    mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon, "SPK_VA_EMAIL", nSr((MyRecReadA("VIRTUALD_EMAIL"))))
                    mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon, "SPK_VA_HP", nSr((MyRecReadA("VIRTUALD_HP"))))
                    mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon, "SPK_VA_TGLPAYMENT", nSr((MyRecReadA("VIRTUAL_TGLPYMT"))))
                    mRunOke = mRunOke & Tambah_tabel_spkad(mNoMohon, "SPK_VA_PAYMENT", nSr((MyRecReadA("VIRTUAL_JUMLAH"))))
                    mTotalVA = mTotalVA + nLg((MyRecReadA("VIRTUAL_JUMLAH")))
                    If nSr((MyRecReadA("VIRTUALD_PEMOHON"))) <> LblUserName.Text Then
                        GetDataVAReject_BasedSPK = GetDataVAReject_BasedSPK & ",SALES PEMOHON BUKAN PEMILIK VIRTUAL ACC"
                    End If
                End While
                If mTotalVA <> mJumlah Then
                    GetDataVAReject_BasedSPK = GetDataVAReject_BasedSPK & ",JUMLAH KLAIM BEDA TOTAL VIRTUAL ACC"
                End If
            Else
                GetDataVAReject_BasedSPK = GetDataVAReject_BasedSPK & ",TDK ADA NOMOR VIRTUAL ACCOUNT YG GANTUNG"
            End If

            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            GetDataVAReject_BasedSPK = ex.Message
            Call Msg_err(ex.Message, 0)
        End Try
    End Function


    Function GetDataVA_BasedSPK() As String
        Dim pmServer As String = "MyConnCloudDnet" & lblArea1.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(pmServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)

        GetDataVA_BasedSPK = ""
        Dim mSqlCommadstring As String = "SELECT *," & _
                                         "(SELECT VIRTUALD_NAMA    FROM Trxn_VIRTUALACCD WHERE VIRTUALD_REF=VIRTUAL_REF) as mfNama," & _
                                         "(SELECT VIRTUALD_PEMOHON FROM Trxn_VIRTUALACCD WHERE VIRTUALD_REF=VIRTUAL_REF) as mfUser," & _
                                         "(SELECT VIRTUALD_EMAIL   FROM Trxn_VIRTUALACCD WHERE VIRTUALD_REF=VIRTUAL_REF) as mfEmail," & _
                                         "(SELECT VIRTUALD_HP      FROM Trxn_VIRTUALACCD WHERE VIRTUALD_REF=VIRTUAL_REF) as mfHP " & _
                                         "FROM Trxn_VIRTUALACC WHERE VIRTUAL_NOKODE='A' AND VIRTUAL_NO='" & TxtVANoSPK.Text & "' AND (VIRTUAL_STATUS = '80' OR VIRTUAL_TGLPYMT IS NOT NULL) ORDER BY VIRTUAL_REF"
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            LblVAError.Text = ""
            TxtVANama.Text = ""
            TxtVAJumlah.Text = ""
            TxtVAEmail.Text = ""
            TxtVANoHP.Text = ""
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read
                    If nSr(MyRecReadA("VIRTUAL_TGLPYMT")) = "" Then
                        TxtVANama.Text = nSr((MyRecReadA("mfNama")))
                        TxtVAJumlah.Text = nLg((MyRecReadA("VIRTUAL_JUMLAH")))
                        TxtVAEmail.Text = nSr((MyRecReadA("mfEmail")))
                        TxtVANoHP.Text = nSr((MyRecReadA("mfHP")))
                    End If
                    LblVAError.Text = LblVAError.Text & _
                                     "  NO VA 20035" & nSr((MyRecReadA("VIRTUAL_ACCOUNT"))) & _
                                     "  NAMA  " & nSr((MyRecReadA("mfNama"))) & _
                                     "  PEMOHON  " & nSr((MyRecReadA("mfUser"))) & _
                                     "  BAYAR TGL " & IIf(nSr(MyRecReadA("VIRTUAL_TGLPYMT")) = "", "BELUM", nSr(MyRecReadA("VIRTUAL_TGLPYMT"))) & _
                                     "  JUMLAH Rp." & fLg((MyRecReadA("VIRTUAL_JUMLAH")))
                    LblVANomor.Text = "20035" & nSr((MyRecReadA("VIRTUAL_ACCOUNT")))
                    LblVANomor0.Text = " Jumlah Yang harus dibayarkan Rp. "
                    LblVANomor1.Text = nLg((MyRecReadA("VIRTUAL_JUMLAH")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function

    Function GetDataVA_Create() As String
        Dim pmServer As String = "MyConnCloudDnet" & lblArea1.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(pmServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)

        Dim mNoVirtual As String = IIf(lblArea1.Text = "112", "1", "2") & TxtVANoSPK.Text

        Dim mTxtCodeUniq As String = "S0"
        Dim mNoTransaksiUniq As String = "A"
        Dim mSqlCommadstring As String
        Dim mRef As String

        mSqlCommadstring = "UPDATE Trxn_VIRTUALACC SET VIRTUAL_STATUS=81 WHERE " & _
                           "VIRTUAL_NO='" & TxtVANoSPK.Text & "' AND VIRTUAL_NOKODE='" & mNoTransaksiUniq & "' " & _
                           "AND VIRTUAL_TGLPYMT IS NULL"
        Call UpdateDatabase_Tabel(mSqlCommadstring, lblArea1.Text, 0)

        mSqlCommadstring = "INSERT INTO  Trxn_VIRTUALACC " & _
                           "(VIRTUAL_NOKODE,VIRTUAL_NO,VIRTUAL_KODE,VIRTUAL_ACCOUNT,VIRTUAL_JUMLAH,VIRTUAL_STATUS,VIRTUAL_TGL,VIRTUAL_TGLPYMT,VIRTUAL_NOGROUP) VALUES " & _
                           "('" & mNoTransaksiUniq & "','" & TxtVANoSPK.Text & "','" & mTxtCodeUniq & "','" & mNoVirtual & "'," & nLg(TxtVAJumlah.Text) & ",NULL,GETDATE(),NULL,'')"
        Call UpdateDatabase_Tabel(mSqlCommadstring, lblArea1.Text, 0)


        GetDataVA_Create = ""
        cnn = New OleDbConnection(strconn)

        mSqlCommadstring = "SELECT * FROM Trxn_VIRTUALACC WHERE VIRTUAL_NOKODE='" & mNoTransaksiUniq & "' AND VIRTUAL_NO='" & TxtVANoSPK.Text & "' AND VIRTUAL_STATUS IS NULL ORDER BY VIRTUAL_REF"
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read

                    If GetDataD_00NoFound01Found("SELECT * FROM Trxn_VIRTUALACCD WHERE VIRTUALD_REF='" & nSr((MyRecReadA("VIRTUAL_REF"))) & "'", lblArea1.Text, 0) <> 1 Then
                        mSqlCommadstring = "INSERT INTO  Trxn_VIRTUALACCD " & _
                                           "(VIRTUALD_REF,VIRTUALD_NAMA,VIRTUALD_PEMOHON,VIRTUALD_EMAIL,VIRTUALD_HP) VALUES " & _
                                           "('" & nSr((MyRecReadA("VIRTUAL_REF"))) & "','" & TxtPetik(TxtVANama.Text) & "','" & LblUserName.Text & "','" & TxtVAEmail.Text & "','" & TxtPetik(TxtVANoHP.Text) & "')"
                        Call UpdateDatabase_Tabel(mSqlCommadstring, lblArea1.Text, 0)
                    End If
                    mSqlCommadstring = "DELETE FROM Trxn_Bill WHERE Dealer='" & lblArea1.Text & "' AND Dept='1' AND " & _
                                       "idCust=" & nSr((MyRecReadA("VIRTUAL_ACCOUNT"))) & " AND (tglPayment IS NULL)"
                    If UpdateDatabase_Tabel(mSqlCommadstring, "VA112", 0) = 1 Then
                        mRef = ""
                        mSqlCommadstring = "INSERT INTO  Trxn_Bill " & _
                                    "(idBiller,idCust,custName,amount,amount1,amount2,trxType," & _
                                    " field1,field2,field3,response,response2,screenText,refNo,RRN,receiptText," & _
                                    " tid,aid,screen1,screen2,screen3,screen4,screen5,screen6,urutan,tglPayment,tglCreate,Dealer,Dept) " & _
                                    " VALUES " & _
                                    "(NULL," & mNoVirtual & ",'" & TxtVANama.Text & "'," & nLg(TxtVAJumlah.Text) & ",0,0,2," & _
                                    "NULL,NULL,NULL,NULL,NULL,'','" & nSr((MyRecReadA("VIRTUAL_REF"))) & "',NULL,''," & _
                                    "'',NULL,'','','','','','','',Null,GETDATE(),'" & lblArea1.Text & "','1')"
                        If UpdateDatabase_Tabel(mSqlCommadstring, "VA112", 0) = 1 Then
                            mRef = "80"
                        Else
                            mRef = "89"
                        End If
                        GetDataVA_Create = nSr((MyRecReadA("VIRTUAL_REF")))
                        mSqlCommadstring = "UPDATE Trxn_VIRTUALACC SET VIRTUAL_STATUS=" & mRef & " WHERE VIRTUAL_REF=" & GetDataVA_Create
                        Call UpdateDatabase_Tabel(mSqlCommadstring, lblArea1.Text, 0)
                    End If
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function

    Function SendEmailProcesVA(ByRef mEmailTo As Object, ByRef mJudul As Object, ByRef mFile As Object, ByRef mPath As Object, ByRef mVANOM As Object, ByRef mVAJML As Object) As Byte
        Dim strFrom As String = "hmugen1991@gmail.com"
        Try


            Using mm As New MailMessage(strFrom, mEmailTo)
                mm.Subject = mJudul
                'mm.Body = mSsage
                'mm.IsBodyHtml = False

                Dim mAlamat1 As String = ""
                Dim mAlamat2 As String = ""
                Dim mAlamat3 As String = ""
                Dim mAlamat4 As String = ""
                Dim mIsi As String = "<br/>Kepada yang terhormat Bapak/Ibu " & _
                                     "<br/>Terima kasih Anda telah melakukan transaksi di Honda mugen berikut ini nomor virtual account BCA untuk pembayaran uang muka :"

                If lblArea1.Text = "112" Then
                    mAlamat1 = "Honda Mugen Pasar Minggu"
                    mAlamat2 = "Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia"
                    mAlamat3 = "Telp : (021) 797 3000 (Show Room), 797 2000 (Bengkel)"
                    mAlamat4 = "Fax  : (021) 797 3834"
                Else
                    mAlamat1 = "Honda Mugen Puri"
                    mAlamat2 = "Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia"
                    mAlamat3 = "Telp : (021) 5835 8000 (Show Room), 5835 9000 (Bengkel)"
                    mAlamat4 = "Fax  : (021) 5835 7942"
                End If

                mm.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Transaksi Virtual Account BCA Honda Mugen</div>" & _
                          "<div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>" & _
                          "<div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'> " & mIsi & " <br/>" & _
                          "<span style='color:blue;font-size:8pt;'></span>" & _
                          "</div>" & _
                          "<br/><center style='color: blue; '>** Nomor Virtual Account " & mVANOM & " **</center>" & _
                          "<br/><center style='color: blue; '>** Jumlah Rp." & mVAJML & " **</center>" & _
                          "<br/><center style='color: blue; '>** Nama Perusahaan/Produk adalah HONDA MUGEN **</center>" & _
                          "<br/>Atas perhatian dan kerjasamanya kami ucapkan terimakasih." & _
                          "<br/><br/>" & _
                          "<br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong>" & _
                          "<br/><strong>" & mAlamat1 & "</strong>" & _
                          "<br/><span style='font-size:9pt;color:#666;'>" & mAlamat2 & "</span>" & _
                          "<br/>" & mAlamat3 & "" & _
                          "<br/>" & mAlamat4 & "<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a>" & _
                          "<br/>" & _
                          "</div>"
                mm.IsBodyHtml = True


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
            Call Msg_err(error_t.Message, 0)
        End Try
    End Function

    Function GetDataVA_CariDataSPK(ByVal mShow As Byte) As Byte
        Dim pmServer As String = "MyConnCloudDnet" & lblArea1.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(pmServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        GetDataVA_CariDataSPK = 0

        Dim mSqlCommadstring As String = "SELECT SPK_Nama1,SPK_FEmail,SPK_FHP,SPK_CDSALES," & _
                                         "(SELECT SPKCANCEL_ALASAN FROM Trxn_SPKCANCEL WHERE SPKCANCEL_NO=SPK_NO) as mfALASANBATAL " & _
                                         "FROM TRXN_SPK WHERE SPK_NO='" & TxtVANoSPK.Text & "'"
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            LblVAError.Text = ""
            TxtVANama.Text = ""
            TxtVAEmail.Text = ""
            TxtVANoHP.Text = ""
            If MyRecReadA.HasRows = True Then
                If MyRecReadA.Read = True Then
                    GetDataVA_CariDataSPK = 1
                    If nSr(MyRecReadA("mfALASANBATAL")) <> "" Then
                        Call Msg_err("SPK SUDAH DIBATALKAN DENGAN ALASAN " & nSr((MyRecReadA("mfALASANBATAL"))), 0)
                        GetDataVA_CariDataSPK = 2
                    ElseIf InStr(LblUserName.Text, nSr((MyRecReadA("SPK_CDSALES")))) = 0 Then
                        Call Msg_err("BUKAN SALES PEMILIK SPK TERSEBUT ........... KODE SALES " & nSr((MyRecReadA("SPK_CDSALES"))), 0)
                        GetDataVA_CariDataSPK = 2
                    ElseIf mShow = 1 Then
                        TxtVANama.Text = nSr((MyRecReadA("SPK_Nama1")))
                        TxtVAEmail.Text = nSr((MyRecReadA("SPK_FEmail")))
                        TxtVANoHP.Text = nSr((MyRecReadA("SPK_FHP")))
                    End If


                End If
            Else
                Call Msg_err("DATA SPK BELUM ADA DI MUGEN .................", 0)
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function

    Protected Sub Button13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button13.Click
        If TxtVANoSPK.Text <> "" Then
            Call GetDataVA_CariDataSPK(1)
        End If
    End Sub

    '=============================================================
    Sub Pengakuan_Transaksi_Virtual_Account()
        If TxtVANoSPK.Text <> "" Then
            Dim mKodesales As String = GetDataD_IsiField("SELECT SPK_CDSALES AS FROM TRXN_SPK WHERE SPK_NO='" & TxtVANoSPK.Text & "'", lblArea1.Text, 0)
            If InStr(LblUserName.Text, mKodesales) <> 0 Then
                Call Proses_Create_Kwitansi_Virtual_Account(TxtVANoSPK.Text)
                Call Proses_Create_Voucher_Virtual_Account(TxtVANoSPK.Text)
            End If

        End If
    End Sub
    Function Proses_Create_Kwitansi_Virtual_Account(ByVal mNospk As String) As Byte
        Dim pmServer As String = "MyConnCloudDnet" & lblArea1.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(pmServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Proses_Create_Kwitansi_Virtual_Account = 0

        Dim mNama As String = ""
        Dim mKet As String = ""



        Dim mSqlCommadstring As String = "SELECT * FROM Trxn_VIRTUALACC WHERE VIRTUAL_NO='" & mNospk & "' AND VIRTUAL_TGLPYMT IS NOT NULL AND (VIRTUAL_NOGROUP='' or VIRTUAL_NOGROUP IS NULL)  ORDER BY VIRTUAL_TGLPYMTVA"

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            LblVAError.Text = ""
            TxtVANama.Text = ""
            TxtVAEmail.Text = ""
            TxtVANoHP.Text = ""
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read
                    mKet = "PEMBAYARAN UANG MUKA UTK PEMBELIAN KENDARAAN HONDA "
                    mNama = GetDataD_IsiField("SELECT SPK_NAMA1 AS IsiField FROM TRXN_SPK WHERE SPK_NO='" & TxtVANoSPK.Text & "'", lblArea1.Text, 0)
                    If mNama <> "" Then
                        mKet = mKet & GetDataD_IsiField("SELECT TYPE_Nama AS IsiField FROM TRXN_SPK,DATA_TYPE WHERE SPK_CDTYPE= TYPE_TYPE AND SPK_NO='" & TxtVANoSPK.Text & "'", lblArea1.Text, 0)
                        Call CreateKwitansi(nSr(MyRecReadA("VIRTUAL_TGLPYMTVA")), nSr(MyRecReadA("VIRTUAL_TGLPYMT")), _
                                            nSr(MyRecReadA("VIRTUAL_REF")), nSr(MyRecReadA("VIRTUAL_NO")), _
                                            mNama, mKet, _
                                            ndb(MyRecReadA("VIRTUAL_JUMLAH")))
                    Else
                        Exit Function
                        'Belum ketarik dari H-Diary
                        mNama = GetDataD_IsiField("SELECT VIRTUALD_NAMA FROM  TRXN_VIRTUALACCD WHERE VIRTUALD_REF='" & Trim(nSr(MyRecReadA("VIRTUAL_REF"))) & "'", lblArea1.Text, 0)
                        If mNama <> "" Then
                            Call CreateKwitansi(nSr(MyRecReadA("VIRTUAL_TGLPYMTVA")), nSr(MyRecReadA("VIRTUAL_TGLPYMT")), _
                                                nSr(MyRecReadA("VIRTUAL_REF")), nSr(MyRecReadA("VIRTUAL_NO")), _
                                                mNama, mKet, _
                                                ndb(MyRecReadA("VIRTUAL_JUMLAH")))
                        End If
                    End If
                End While
            Else
                'Call Msg_err("DATA SPK BELUM ADA DI MUGEN .................", 0)
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function
    Sub CreateKwitansi(ByVal mTglPaym As String, ByVal mTglPaymI As String, _
                   ByVal mNoRef As String, ByVal mNospk As String, ByVal mNama As String, ByVal mKet As String, ByVal mJml As Double)
        Dim iloop As Byte
        Dim QuerySqlSts As Byte = 0
        Dim mNoKW As String = ""
        For iloop = 1 To 5
            Select Case iloop
                Case 1
                    mNoKW = CREATE_NOKW()
                    QuerySqlSts = IIf(mNoKW = "", 0, 1)
                Case 2 : QuerySqlSts = INSERT_KWITANSI(mNoKW, mTglPaym, mNospk, mNama, mKet, mJml)
                Case 3 : QuerySqlSts = INSERT_KWITANSIB(mNoKW, mJml, mNospk)
                Case 4 : QuerySqlSts = UPDATE_VIRTUALACCOUNT_KWITANSI(mNoRef, mNoKW)
                    'Case 5 : Call LoginDOING(MyTglHariIni, "", "ADDI KWITANSI:" & mNoKW, "")
            End Select
            If QuerySqlSts <> 1 Then Exit For
        Next
        If QuerySqlSts <> 1 Then
            Call Msg_err("error", 0)
        End If
    End Sub
    Function CREATE_NOKW() As String
        CREATE_NOKW = ""
        CREATE_NOKW = GetdataD_AddNomor("VOUCHER_KWREAL", 7, lblArea1.Text)
    End Function
    Function GetdataD_AddNomor(ByVal mField As String, ByVal mPanjang As Byte, ByVal mServer As String) As String
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim mNomor As String
        Dim mSqlCommadstring As String = "SELECT " & mField & " FROM DATA_VOUCHER WHERE VOUCHER_No='A'"
        Call Msg_err("", 0)
        GetdataD_AddNomor = ""
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadD = cmd.ExecuteReader()
            If MyRecReadD.HasRows = True Then
                If MyRecReadD.Read Then
                    Dim mNomorfiled As String
                    Dim mNomorfiledNum As String
                    Dim mPanjang2 As Byte

                    mNomorfiled = nSr(MyRecReadD(mField))
                    mPanjang = Len(mNomorfiled) : mPanjang2 = 0
                    If Not IsNumeric(Right(mNomorfiled, 1)) Then
                        mPanjang2 = 1
                    End If
                    mPanjang = mPanjang - mPanjang2

                    mNomorfiledNum = Left(mNomorfiled, mPanjang)
                    mNomorfiledNum = Val(mNomorfiledNum) + 1
                    mNomor = Mid("0000000000", 1, mPanjang - Len(mNomorfiledNum))
                    mNomor = mNomor & mNomorfiledNum & Right(mNomorfiled, mPanjang2)

                    mSqlCommadstring = "UPDATE DATA_VOUCHER SET " & mField & "='" & mNomor & "' WHERE VOUCHER_No='A'"
                    If UpdateDatabase_Tabel(mSqlCommadstring, lblArea1.Text, 0) = 1 Then
                        GetdataD_AddNomor = mNomor
                    End If
                End If
            Else
                mSqlCommadstring = "INSERT INTO DATA_VOUCHER( VOUCHER_No," & mField & ") VALUES ('A','" & (Mid("0000000000", 1, mPanjang - 1) & "1") & "')"
                If UpdateDatabase_Tabel(mSqlCommadstring, lblArea1.Text, 0) = 1 Then
                    GetdataD_AddNomor = Mid("0000000000", 1, mPanjang - 1) & "1"
                End If
            End If
            MyRecReadD.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function INSERT_KWITANSI(ByVal TxtNoKw As String, ByVal DtpTglKw As String, ByVal TxtNoSPK As String, ByVal TxtNama As String, ByVal TxtKeterangan As String, ByVal TxtJumlah As Double) As Byte
        Dim Mytxtsql As String = "INSERT INTO TRXN_KWITANSI(KWITANSI_No,KWITANSI_Tgl,KWITANSI_NoSPK,KWITANSI_NoWO,KWITANSI_NOTTK," & _
                   "KWITANSI_Nama,KWITANSI_Keterangan,KWITANSI_Jumlah,KWITANSI_Status,KWITANSI_Tipe,KWITANSI_JnsTagih) VALUES " & _
                   "('" & TxtNoKw & "'," & DtFrSQL((DtpTglKw)) & ",'" & TxtNoSPK & "','','','" & TxtPetik((TxtNama)) & "','" & TxtPetik((TxtKeterangan)) & "'," & ndb((TxtJumlah)) & ",'R','1','1')"
        INSERT_KWITANSI = UpdateDatabase_Tabel(Mytxtsql, lblArea1.Text, 0)
    End Function
    Function INSERT_KWITANSIB(ByVal mNOKwitansi As String, ByVal mJml As Double, ByVal mNOSPK As String) As Byte
        Dim Mytxtsql As String = "INSERT INTO TRXN_KWITANSIB(KWITANSIB_NoWO,KWITANSIB_CdAss,KWITANSIB_Bayar,KWITANSIB_No,KWITANSIB_TipeUM,KWITANSIB_NOSPK) VALUES " & _
                       "('',''," & ndb(mJml) & ",'" & mNOKwitansi & "','1','" & mNOSPK & "')"
        INSERT_KWITANSIB = UpdateDatabase_Tabel(Mytxtsql, lblArea1.Text, 0)
    End Function
    Function UPDATE_VIRTUALACCOUNT_KWITANSI(ByVal mpNoRef As String, ByVal mpNoKW As String) As Byte
        Dim Mytxtsql As String = "UPDATE Trxn_VIRTUALACC SET VIRTUAL_NOGROUP='" & mpNoKW & "' WHERE VIRTUAL_REF=" & mpNoRef & ""
        UPDATE_VIRTUALACCOUNT_KWITANSI = UpdateDatabase_Tabel(Mytxtsql, lblArea1.Text, 0)
    End Function

    Function Proses_Create_Voucher_Virtual_Account(ByVal mNospk As String) As Byte
        Dim pmServer As String = "MyConnCloudDnet" & lblArea1.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(pmServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)
        Proses_Create_Voucher_Virtual_Account = 0

        Dim mNama As String = ""
        Dim mKet As String = ""
        Dim QrySqlSts As Byte
        Dim iloop As Byte
        Dim mNoVcr As String = ""
        Dim mAccnt As String = "020400"

        Dim mSqlCommadstring As String = "SELECT * FROM Trxn_VIRTUALACC,TRXN_KWITANSI WHERE VIRTUAL_NOGROUP=KWITANSI_No AND KWITANSI_Status='R' AND VIRTUAL_NO='" & mNospk & "' AND " & _
                                         "VIRTUAL_TGLPYMT IS NOT NULL AND VIRTUAL_HMSDOCTGL IS NULL AND NOT(VIRTUAL_NOGROUP='' or VIRTUAL_NOGROUP IS NULL) " & _
                                         "ORDER BY VIRTUAL_TGLPYMTVA"
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            LblVAError.Text = ""
            TxtVANama.Text = ""
            TxtVAEmail.Text = ""
            TxtVANoHP.Text = ""
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read
                    QrySqlSts = 1
                    For iloop = 0 To 5
                        Select Case iloop
                            Case 0
                                If nSr(MyRecReadA("VIRTUAL_HMSDOCNO")) = "" Then
                                    mNoVcr = CREATE_NOvcr()
                                Else
                                    mNoVcr = nSr(MyRecReadA("VIRTUAL_HMSDOCNO"))
                                    Call HAPUS_ARTRAN(mAccnt, mNoVcr)
                                End If
                                QrySqlSts = IIf(mNoVcr = "", 0, 1)
                            Case 1
                                Call UPDATE_VIRTUALACCOUNT_VOUCHER("", mNoVcr, nSr(MyRecReadA("VIRTUAL_REF")))
                            Case 2
                                QrySqlSts = INSERT_TRANC(nSr(MyRecReadA("VIRTUAL_TGLPYMT")), mAccnt, mNoVcr, _
                                                         nSr(MyRecReadA("KWITANSI_Nama")), nSr(MyRecReadA("KWITANSI_Keterangan")), ndb(MyRecReadA("KWITANSI_Jumlah")))
                            Case 3
                                QrySqlSts = UPDATE_KWITANSI_VCR(nSr(MyRecReadA("KWITANSI_NO")), nSr(MyRecReadA("KWITANSI_Tipe")), nSr(MyRecReadA("KWITANSI_NoSPK")), nSr(MyRecReadA("VIRTUAL_TGLPYMT")), mAccnt, mNoVcr)
                            Case 4
                                Call UPDATE_VIRTUALACCOUNT_VOUCHER(nSr(MyRecReadA("VIRTUAL_TGLPYMT")), "", nSr(MyRecReadA("VIRTUAL_REF")))
                                'Case 4 : Call LoginDOING(MyTglHariIni, "02034", "ADDI VCR BANK:" & mNoVcr, "")
                        End Select
                        If QrySqlSts <> 1 Then
                            Call Msg_err("Error step " & iloop, 0)
                        End If
                    Next
                End While
            Else
                'Call Msg_err("DATA SPK BELUM ADA DI MUGEN .................", 0)
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function
    Function CREATE_NOvcr() As String
        CREATE_NOvcr = AddVoucher("ACCOUNT_NoVcr1", "020400")
    End Function
    Function AddVoucher(ByVal mField As String, ByVal mAcc As String) As String
        Dim pmServer As String = "MyConnCloudDnet" & lblArea1.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(pmServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)

        Dim mNomor As String
        mNomor = ""
        AddVoucher = ""
        Dim mSqlCommadstring As String = "SELECT " & mField & " FROM DATA_ACCOUNT WHERE ACCOUNT_No='" & mAcc & "'"

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            LblVAError.Text = ""
            TxtVANama.Text = ""
            TxtVAEmail.Text = ""
            TxtVANoHP.Text = ""
            If MyRecReadB.HasRows = True Then
                If MyRecReadB.Read Then
                    Select Case UCase(mField)
                        Case UCase("ACCOUNT_NoVcr1")

                            If (MyRecReadB("ACCOUNT_NoVcr1") = Mid("9999999999", 1, 7 - 1)) Or nSr(MyRecReadB("ACCOUNT_NoVcr1")) = "" Then
                                mNomor = (Mid("0000000000", 1, 7 - 1) & "1")
                            Else
                                mNomor = (Mid("0000000000", 1, 7 - Len(Trim(Str(Val(MyRecReadB("ACCOUNT_NoVcr1")) + 1)))) & Val(MyRecReadB("ACCOUNT_NoVcr1")) + 1)
                            End If
                        Case UCase("ACCOUNT_NoVcr2")

                            If (MyRecReadB("ACCOUNT_NoVcr2") = Mid("9999999999", 1, 7 - 1)) Or nSr(MyRecReadB("ACCOUNT_NoVcr2")) = "" Then
                                mNomor = (Mid("0000000000", 1, 7 - 1) & "1")
                            Else
                                mNomor = (Mid("0000000000", 1, 7 - Len(Trim(Str(Val(MyRecReadB("ACCOUNT_NoVcr2")) + 1)))) & Val(MyRecReadB("ACCOUNT_NoVcr2")) + 1)
                            End If
                    End Select

                    If UpdateDatabase_Tabel("UPDATE DATA_ACCOUNT SET " & mField & "='" & mNomor & "' WHERE ACCOUNT_No='" & mAcc & "'", lblArea1.Text, 0) = 1 Then
                        AddVoucher = mNomor
                    End If
                End If

            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function



    Function INSERT_TRANC(ByVal mp1Tgl As String, ByVal mp1Acc As String, ByVal mp1Vcr As String, ByVal mp1Nama As String, ByVal mp1Keterangan As String, ByVal mp1Jumlah As Double) As Byte
        INSERT_TRANC = 0
        Dim Mytxtsql As String = "SELECT * FROM TRXN_TRANSC WHERE TRANSC_ENTRY='B' AND TRANSC_ACC ='" & mp1Acc & "' AND " & "TRANSC_VCR='" & mp1Vcr & "'"
        If GetDataD_00NoFound01Found(Mytxtsql, lblArea1.Text, 0) = 1 Then
            INSERT_TRANC = INSERT_TRANC_EDIT(mp1Tgl, mp1Acc, mp1Vcr, mp1Nama, mp1Keterangan, mp1Jumlah)
        Else
            INSERT_TRANC = INSERT_TRANC_ADD(mp1Tgl, mp1Acc, mp1Vcr, mp1Nama, mp1Keterangan, mp1Jumlah)
        End If
    End Function
    Function INSERT_TRANC_EDIT(ByVal mp2Tgl As String, ByVal mp2Acc As String, ByVal mp2Vcr As String, ByVal mp2Nama As String, ByVal mp2Keterangan As String, ByVal mp2Jumlah As Double) As Byte
        Dim Mytxtsql As String = "UPDATE TRXN_TRANSC SET " & _
                   "TRANSC_NAMA='" & Microsoft.VisualBasic.Left(TxtPetik(mp2Nama), 50) & "'," & _
                   "TRANSC_KET1='" & TxtPetik(Mid(mp2Keterangan, 1, 50)) & "'," & "TRANSC_KET2='" & TxtPetik(Mid(mp2Keterangan, 51, 50)) & "'," & _
                   "TRANSC_JUMLAH=" & ndb(mp2Jumlah) & "," & _
                   "TRANSC_STAT='D',TRANSC_TGL=" & DtFrSQL(CDate(mp2Tgl)) & "," & _
                   "TRANSC_GLACCOUNT='',TRANSC_DEPT='' " & _
                   "WHERE TRANSC_ACC ='" & mp2Acc & "' AND " & "TRANSC_VCR='" & mp2Vcr & "' AND TRANSC_ENTRY='B'"
        INSERT_TRANC_EDIT = UpdateDatabase_Tabel(Mytxtsql, lblArea1.Text, 0)
    End Function
    Function INSERT_TRANC_ADD(ByVal mp2Tgl As String, ByVal mp2Acc As String, ByVal mp2Vcr As String, ByVal mp2Nama As String, ByVal mp2Keterangan As String, ByVal mp2Jumlah As Double) As Byte
        Dim Mytxtsql As String = "INSERT INTO TRXN_TRANSC(TRANSC_ACC,TRANSC_VCR,TRANSC_TGL,TRANSC_ENTRY," & _
                   "TRANSC_NAMA,TRANSC_KET1,TRANSC_KET2,TRANSC_JUMLAH,TRANSC_STAT,TRANSC_GLACCOUNT,TRANSC_DEPT,TRANSC_USER) VALUES " & _
                   "('" & mp2Acc & "','" & mp2Vcr & "'," & DtFrSQL(CDate(mp2Tgl)) & ",'B','" & _
                   Microsoft.VisualBasic.Left(TxtPetik(mp2Nama), 50) & "','" & TxtPetik(Mid(mp2Keterangan, 1, 50)) & "','" & TxtPetik(Mid(mp2Keterangan, 51, 50)) & "'," & ndb(mp2Jumlah) & ",'D','','','SYSTEM')"
        INSERT_TRANC_ADD = UpdateDatabase_Tabel(Mytxtsql, lblArea1.Text, 0)
    End Function
    Function UPDATE_KWITANSI_VCR(ByRef mNoKwitansi As String, ByRef mTipeKwitansi As String, ByRef mSPKKwitansi As String, _
                                 ByVal mp1Tgl As String, ByVal mp1Acc As String, ByVal mp1Vcr As String) As Byte
        Dim pmServer As String = "MyConnCloudDnet" & lblArea1.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(pmServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)

        Dim mNilai As Double
        Dim mTipeUM As String
        Dim mAdaKelompokSurat As Byte
        Dim mAdaKelompokUnit As Byte
        Dim mInsertTransaksiNoSPK As String = ""
        UPDATE_KWITANSI_VCR = 1

        mNilai = 0
        mAdaKelompokSurat = 0
        mAdaKelompokUnit = 0

        Dim mSqlCommadstring As String = "SELECT *," & _
                                        "(SELECT STANDARD_Kelompok FROM DATA_STANDARD WHERE STANDARD_Kode=KWITANSIB_CdAss) As mfKelompok " & _
                                        "FROM TRXN_KWITANSIB  WHERE KWITANSIB_No='" & mNoKwitansi & "'"
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            LblVAError.Text = ""
            TxtVANama.Text = ""
            TxtVAEmail.Text = ""
            TxtVANoHP.Text = ""
            If MyRecReadB.HasRows = True Then
                While MyRecReadB.Read
                    mTipeUM = IIf(nSr((MyRecReadB("KWITANSIB_TipeUM"))) = "1", "1", "")
                    If mTipeKwitansi <> "6" Then
                        mInsertTransaksiNoSPK = mSPKKwitansi
                    Else
                        mInsertTransaksiNoSPK = nSr((MyRecReadB("KWITANSIB_NOSPK")))
                    End If
                    If INSERT_ARTRAN_VA(mp1Tgl, mp1Acc, mp1Vcr, mInsertTransaksiNoSPK, ndb((MyRecReadB("KWITANSIB_Bayar"))), "VIRTUAL ACCOUNT", nSr((MyRecReadB("KWITANSIB_NoWO"))), nSr((MyRecReadB("KWITANSIB_CdAss"))), "1", IIf(Microsoft.VisualBasic.Left(nSr((MyRecReadB("KWITANSIB_CdAss"))), 1) <> "T", "", "T")) = 1 Then
                        mNilai = mNilai + ndb((MyRecReadB("KWITANSIB_Bayar")))
                        If Microsoft.VisualBasic.Left(nSr((MyRecReadB("KWITANSIB_CdAss"))), 1) <> "T" Then
                            If nSr((MyRecReadB("KWITANSIB_NoWO"))) = "" Then
                                Call INSERT_ARMAST(mInsertTransaksiNoSPK, mNilai, "ARMAST_BAYAR", "")
                            Else
                                Call INSERT_ARMAST(mInsertTransaksiNoSPK, mNilai, "ARMAST_BAYARD", "")
                            End If
                        End If
                    End If
                    If nSr(MyRecReadB("KWITANSIB_CdAss")) = "0000" Then
                        mAdaKelompokUnit = 1
                    ElseIf nSr(MyRecReadB("KWITANSIB_CdAss")) = "S" Then
                        mAdaKelompokSurat = 1
                    End If
                End While

                If mNilai > 0 And (mAdaKelompokUnit = 1 Or mAdaKelompokSurat = 0) And mInsertTransaksiNoSPK <> "" Then
                    '                    Call SMSARTRAN(mInsertTransaksiNoSPK, mNilai, "", mTipeUM)
                End If
            Else
                Call Msg_err("DATA SPK BELUM ADA DI MUGEN .................", 0)
            End If

            Dim Mytxtsql As String = "UPDATE TRXN_KWITANSI SET KWITANSI_Acc='" & mp1Acc & "', KWITANSI_NoVocr='" & mp1Vcr & "' " & " WHERE KWITANSI_No='" & mNoKwitansi & "' AND KWITANSI_Status='R'"
            Call UpdateDatabase_Tabel(Mytxtsql, lblArea1.Text, 0)

            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function
    Function INSERT_ARTRAN_VA(ByVal mp2tGL As String, ByVal mp2Acc As String, ByVal mp2Vcr As String, ByVal mSPK As String, ByVal mNilai As Double, ByVal mKet As String, ByVal mNOWO As String, ByVal mD As String, ByVal m3Type As String, ByVal mTitip As String) As Byte
        mNOWO = IIf(mD = "" Or mD = "0000", "", mNOWO)
        Dim Mytxtsql As String = "INSERT INTO TRXN_ARTRAN" & mTitip & "(ARTRAN_NOSPK,ARTRAN_VCR,ARTRAN_TGL,ARTRAN_JUMLAH,ARTRAN_KET,ARTRAN_STATUS,ARTRAN_NOWO,ARTRAN_CdAss) VALUES " & _
                   "('" & mSPK & "','" & mp2Vcr & "'," & DtFrSQL(CDate(mp2tGL)) & "," & mNilai & ",'" & mKet & "','" & mp2Acc & "','" & mNOWO & "','" & mD & "')"
        INSERT_ARTRAN_VA = UpdateDatabase_Tabel(Mytxtsql, lblArea1.Text, 0)
    End Function

    Sub HAPUS_ARTRAN(ByVal mNO_ACC As String, ByVal mNO_VCR As String)
        Dim Mytxtsql As String = "DELETE FROM TRXN_ARTRAN WHERE ARTRAN_VCR='" & mNO_VCR & "' AND ARTRAN_STATUS='" & mNO_ACC & "'"
        Call UpdateDatabase_Tabel(Mytxtsql, lblArea1.Text, 0)
    End Sub


    Function UPDATE_VIRTUALACCOUNT_VOUCHER(ByVal mp2tGL As String, ByVal mp2Vcr As String, ByVal mp2Noref As String) As Byte
        Dim Mytxtsql As String
        If mp2tGL <> "" Then
            Mytxtsql = "UPDATE TRXN_VIRTUALACC SET VIRTUAL_HMSDOCTGL=" & DtFrSQL(CDate(mp2tGL)) & " WHERE VIRTUAL_REF=" & mp2Noref & ""
        Else
            Mytxtsql = "UPDATE TRXN_VIRTUALACC SET VIRTUAL_HMSDOCNO='" & mp2Vcr & "' WHERE VIRTUAL_REF=" & mp2Noref & ""
        End If
        Call UpdateDatabase_Tabel(Mytxtsql, lblArea1.Text, 0)
    End Function

    Function INSERT_ARMAST(ByVal mNOSPK As String, ByVal mNilai As Double, ByVal mKetField1 As String, ByVal mKetField2 As String) As Byte
        INSERT_ARMAST = 0
        If GetDataD_00NoFound01Found("SELECT * FROM TRXN_ARMAST WHERE ARMAST_NOSPK='" & mNOSPK & "'", lblArea1.Text, 0) = 1 Then
            If mKetField2 <> "" Then
                INSERT_ARMAST = UpdateDatabase_Tabel("UPDATE TRXN_ARMAST SET " & mKetField2 & "=" & mNilai & " WHERE ARMAST_NOSPK='" & mNOSPK & "'", lblArea1.Text, 0)
            Else
                INSERT_ARMAST = UpdateDatabase_Tabel("UPDATE TRXN_ARMAST SET " & mKetField1 & "=ISNULL(" & mKetField1 & ",'') +" & mNilai & " WHERE ARMAST_NOSPK='" & mNOSPK & "'", lblArea1.Text, 0)
            End If
        Else
            If mKetField2 <> "" Then mKetField1 = mKetField2
            INSERT_ARMAST = UpdateDatabase_Tabel("INSERT INTO TRXN_ARMAST (ARMAST_NOSPK," & mKetField1 & ") VALUES ('" & mNOSPK & "'," & mNilai & ")", lblArea1.Text, 0)
        End If
    End Function
    '=============================================================

    Function ValidasiCarabayarSPK(ByVal mpNoSPK As String, ByVal mpCDLEASE As String, ByVal mpDealer As String) As Byte
        ValidasiCarabayarSPK = 0
        If (TxtCdLease.Text = "" Or LblNamaLease.Text = "") Then
            ValidasiCarabayarSPK = 0
            Call Msg_err("Isian data belum ada kode lease atau namanya", 0)
        End If


        Dim mKodeSekarang As String = ""
        Dim mKodeBaru As String = ""

        mKodeSekarang = "K"
        Dim MySTRsql1 As String = "SELECT SPK_CDLEASE FROM TRXN_SPK,DATA_LEASE WHERE SPK_CDLEASE=LEASE_KODE AND (SPK_CDLEASE='C001' OR LEASE_Status='3') AND SPK_NO LIKE '" & mpNoSPK & "'"
        If GetDataD_00NoFound01Found(MySTRsql1, mpDealer, 0) = 1 Then
            mKodeSekarang = "T"
        Else
            mKodeSekarang = "K"
        End If

        mKodeBaru = "K"
        MySTRsql1 = "SELECT LEASE_KODE FROM DATA_LEASE WHERE (LEASE_KODE='C001' OR LEASE_Status='3') AND LEASE_KODE LIKE '" & mpCDLEASE & "'"
        If GetDataD_00NoFound01Found(MySTRsql1, mpDealer, 0) = 1 Then
            mKodeBaru = "T"
        Else
            mKodeBaru = "K"
        End If

        If mKodeSekarang <> mKodeBaru Then
            If mKodeSekarang = "T" Then
                Call Msg_err("Status Pembayaran sekarang Tunai, Tidak diperbolehkan untuk diganti menjadi kredit (Buat SPK Baru)", 0)
            Else
                Call Msg_err("Status Pembayaran sekarang Kredit, Tidak diperbolehkan untuk diganti menjadi Tunai (Buat SPK Baru)", 0)
            End If
        Else
            ValidasiCarabayarSPK = 1
        End If
    End Function

    Protected Sub LVLeasing_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVLeasing.SelectedIndexChanged
        TxtCdLease.Text = (LVLeasing.DataKeys(LVLeasing.SelectedIndex).Value.ToString)
        If TxtCdLease.Text <> "" Then
            LblNamaLease.Text = GetDataD_IsiField("SELECT LEASE_NAMA as IsiField FROM DATA_LEASE WHERE LEASE_KODE='" & TxtCdLease.Text & "'", "112", 0)
        End If
    End Sub

    Protected Sub Button10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.Click
        LVLeasing.DataBind()
    End Sub

    Protected Sub BtnKirimAlamatSPK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKirimAlamatSPK.Click
        Call GetDatacUSTOMER_BasedSPK(1)
    End Sub

    Protected Sub BtnKirimAlamatSTNK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKirimAlamatSTNK.Click
        Call GetDatacUSTOMER_BasedSPK(2)
    End Sub

    Function GetDatacUSTOMER_BasedSPK(ByVal MTIE As Byte) As String
        Dim pmServer As String = "MyConnCloudDnet" & lblArea1.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(pmServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        cnn = New OleDbConnection(strconn)

        GetDatacUSTOMER_BasedSPK = ""
        Dim mSqlCommadstring As String
        If MTIE = 1 Then
            mSqlCommadstring = "SELECT * FROM TRXN_SPK,DATA_TYPE,DATA_WARNA  WHERE SPK_CDTYPE=TYPE_TYPE AND SPK_CDWARNA=WARNA_KODE AND SPK_NO='" & Txt_NoSPKMohon.Text & "'"
        Else
            mSqlCommadstring = "SELECT * FROM TRXN_SURAT WHERE SURAT_SPK='" & Txt_NoSPKMohon.Text & "' AND " & "((SURAT_STATUS)<>'B' OR ISNULL(SURAT_STATUS))"
        End If

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            LblVAError.Text = ""
            TxtVANama.Text = ""
            TxtVAJumlah.Text = ""
            TxtVAEmail.Text = ""
            TxtVANoHP.Text = ""
            If MyRecReadA.HasRows = True Then
                If MyRecReadA.Read Then
                    If MTIE = 1 Then
                        TxtKirimNama.Text = nSr((MyRecReadA("SPK_Nama1")))
                        TxtKirimAlamat.Text = nSr((MyRecReadA("SPK_Alamat")))
                        TxtKirimKota.Text = nSr((MyRecReadA("SPK_Kota")))
                        TxtKirimNamaHP.Text = nSr((MyRecReadA("SPK_FHP")))

                        LblKirimJenis.Text = nSr(MyRecReadA("SPK_Direct")) : LblKirimTglDO.Text = nSr(MyRecReadA("SPK_TglDO"))
                        LblKirimRangka.Text = nSr(MyRecReadA("SPK_NORANGKA")) : LblKirimNoDO.Text = nSr(MyRecReadA("SPK_NODO"))
                        LblKirimTipe.Text = nSr(MyRecReadA("TYPE_NAMA")) : LblKirimWarna.Text = nSr(MyRecReadA("WARNA_INT"))

                        If LblKirimJenis.Text = "4" Then
                            LblKirimJenis.Text = "CROSS SELL"
                        Else
                            LblKirimJenis.Text = "SELL"
                        End If

                    Else

                        TxtKirimNama.Text = nSr((MyRecReadA("SURAT_NAMA")))
                        TxtKirimAlamat.Text = nSr((MyRecReadA("SURAT_ALAMAT1"))) & nSr((MyRecReadA("SURAT_ALAMAT2")))
                        TxtKirimKota.Text = nSr((MyRecReadA("SURAT_KOTA")))
                        TxtKirimNamaHP.Text = nSr((MyRecReadA("SURAT_NOHP")))

                    End If
                End If
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, 0)
        End Try
    End Function

    Function Validasi_Kirim_unit(ByVal mOke As Byte, ByVal mpTgl As String, ByVal mpJam As String) As String
        Dim mErrorCCO As String = ""

        Validasi_Kirim_unit = ""
        If Not IsDate(mpTgl) Then
            mErrorCCO = mErrorCCO & "FORMAT ISIAN SALAH PILIH BANTUAN DENGAN TOMBOL KALENDER (DISAMPING)"
        ElseIf (mpTgl = "") Or mpJam = "" Or (Val(mpJam) < 8 Or Val(mpJam) > 16) Then
            mErrorCCO = mErrorCCO & "ISIAN TANGGAL ATAU JAM KIRIM SALAH"
        ElseIf DateDiff(DateInterval.Day, CDate(LblTglSystem.Text), CDate(mpTgl)) < 0 Then
            mErrorCCO = mErrorCCO & "ISIAN TANGGAL KURANG DARI TANGGAL HARI INI"
        End If
        If mErrorCCO <> "" Then
            Call Msg_err(mErrorCCO, 0) : Validasi_Kirim_unit = mErrorCCO : Exit Function
        End If

        Validasi_Kirim_unit = ""

        'Validasi Data
        If GetDataD_00NoFound01Found("SELECT * FROM TRXN_SPK WHERE SPK_NO='" & Txt_NoSPKMohon.Text & "' AND SPK_TGLDO IS NOT NULL", lblArea1.Text, 1) = 1 Then
            mErrorCCO = GetDataE_VALIDASI_PEMBAYARAN(Txt_NoSPKMohon.Text, 100, "Y", "", lblArea1.Text)
            If mErrorCCO <> "" Then
                If GetDataD_00NoFound01Found("SELECT SPKC_NILAITGL FROM TRXN_SPKC WHERE SPKC_NO='" & Txt_NoSPKMohon.Text & "' AND SPKC_NAMA like '%ENTRY ALASAN PERMOHONAN KIRIM BELUM LUNAS%' AND SPKC_NILAITGL IS NOT NULL", lblArea1.Text, 0) = 1 Then
                    mErrorCCO = ""
                ElseIf GetDataD_00NoFound01Found("SELECT SPKC_NILAITGL FROM TRXN_SPKC WHERE SPKC_NO='" & Txt_NoSPKMohon.Text & "' AND SPKC_NAMA like '%ENTRY ALASAN CETAK DO BELUM LUNAS BAYAR TUNAI%' AND SPKC_NILAITGL IS NOT NULL", lblArea1.Text, 0) = 1 Then
                    mErrorCCO = ""
                End If
            End If

            Dim mNilaiSPK As String
            Dim mNilaiSPK2 As String

            mNilaiSPK = GetDataD_IsiField("SELECT SPK_Direct as IsiField  FROM TRXN_SPK,TRXN_STOCK WHERE SPK_NORANGKA = STOCK_NORANGKA AND SPK_NO='" & Txt_NoSPKMohon.Text & "'", lblArea1.Text, 0)

            LblTglSystem.Text = GetDataD_IsiField("SELECT GETDATE() as IsiField ", lblArea1.Text, 0)



            Dim mSelisih As Integer = 2
            If Hour(CDate(LblTglSystem.Text)) >= 14 Then
                mSelisih = 3
            End If

            Dim mJumlahSelsish As Integer = 0
            mJumlahSelsish = GetTotalWorkingDays(LblTglSystem.Text, CDate(mpTgl))


            'If DateDiff(Microsoft.VisualBasic.DateInterval.Day, InputDT("", "", "", "00", "00", "00", CDate(LblTglSystem.Text)), InputDT("", "", "", "00", "00", "00", CDate(mpTgl))) <= 2 Then
            If mJumlahSelsish <= mSelisih Then
                If mNilaiSPK <> "4" Then
                    If GetDataD_00NoFound01Found("SELECT SPKC_NILAITGL FROM TRXN_SPKC WHERE SPKC_NO='" & Txt_NoSPKMohon.Text & "' AND SPKC_NAMA like '%ENTRY ALASAN PERMOHONAN KIRIM UNIT KURANG 1 HARI%' AND SPKC_NILAITGL IS NOT NULL", lblArea1.Text, 0) = 0 And _
                       GetDataD_00NoFound01Found("SELECT SPKC_NILAITGL FROM TRXN_SPKC WHERE SPKC_NO='" & Txt_NoSPKMohon.Text & "' AND SPKC_NAMA like '%ENTRY ALASAN PERMOHONAN KIRIM UNIT KURANG 2 HARI%' AND SPKC_NILAITGL IS NOT NULL", lblArea1.Text, 0) = 0 Then
                        mErrorCCO = mErrorCCO & Chr(13) & _
                                    UCase("Selisih hari kerja adalah " & mJumlahSelsish & " Harus lebih dari " & mSelisih & IIf(mSelisih = 3, " karena di buat di atas Jam 14.00 (Berdasarkan Jam Server) ", "")) & Chr(13) & _
                                    UCase("Mengajukan permohonan 'ENTRY ALASAN PERMOHONAN KIRIM UNIT KURANG 2 HARI' ") & Chr(13)
                    End If
                End If
            End If
            mNilaiSPK = GetDataD_IsiField("SELECT STOCK_CdLokasi as IsiField  FROM TRXN_SPK,TRXN_STOCK WHERE SPK_NORANGKA = STOCK_NORANGKA AND SPK_NO='" & Txt_NoSPKMohon.Text & "'", lblArea1.Text, 0)
            mNilaiSPK2 = GetDataD_IsiField("SELECT STOCK_TGLTERIMA as IsiField  FROM TRXN_SPK,TRXN_STOCK WHERE SPK_NORANGKA = STOCK_NORANGKA AND SPK_NO='" & Txt_NoSPKMohon.Text & "'", lblArea1.Text, 0)
            If Microsoft.VisualBasic.Left(mNilaiSPK, 1) = "S" Then
                'mErrorCCO = mErrorCCO & Chr(13) & UCase("- Lokasi ada di dealer tidak bisa mengajukan permohonan ke Warehouse")
            End If
            If Microsoft.VisualBasic.Left(mNilaiSPK, 1) <> "S" And mNilaiSPK2 = "" Then
                mErrorCCO = mErrorCCO & Chr(13) & UCase("- Unit belum diterima oleh Warehouse")
            End If

            'mTgl DTglkIRIMmohon.Value = InputDT("", "", "", "00", "00", "00", DTglkIRIMmohon.Value)
            'LblTglSystem.Text 

            If Validasi_BBN(Txt_NoSPKMohon.Text, lblArea1.Text) = 0 Then
                mErrorCCO = mErrorCCO & Chr(13) & UCase("- Harga BBN belum diisi atau belum dibuatkan WO BBN adalah spk ON THE ROAD (Contact Admin)")
            End If

            'Pending If Blok_terima_kendaraan_Yang_SPJ_Dealer() = 1 Then
            'Pending mTxtErr = mTxtErr & Chr(13) & "Tanggal Terima belum dilakukan yang sudah SPJ di Dealer"
            'Pending End If

            mNilaiSPK = GetDataD_IsiField("SELECT SPK_CdLease as IsiField  FROM TRXN_SPK,TRXN_STOCK WHERE SPK_NORANGKA = STOCK_NORANGKA AND SPK_NO='" & Txt_NoSPKMohon.Text & "'", lblArea1.Text, 0)
            If Not (mNilaiSPK = "C001" Or mNilaiSPK = "L032" Or mNilaiSPK = "3") Then 'Non Cash harus lunas DP
                If AddSaveDataSPKB(Txt_NoSPKMohon.Text, "TERIMA DOKUMEN LEASING", "", "", "", "CARITANGGAL") = "" Then
                    mErrorCCO = mErrorCCO & Chr(13) & UCase("- Pembayaran leasing Admin belum input terima dokumen leasing")
                End If
            End If
        Else
            mErrorCCO = mErrorCCO & "SPK TERSEBUT BELUM DO "
        End If
        If mErrorCCO <> "" Then
            If mOke = 0 Then
                Call Msg_err(mErrorCCO, 0) : Validasi_Kirim_unit = ""
            Else
                Validasi_Kirim_unit = mErrorCCO
            End If
        Else
            Validasi_Kirim_unit = ""
        End If
    End Function

    Function Validasi_DO(ByVal mpNoSPK As String, ByVal mpNoRgk As String) As String
        Dim mErrorCCO As String = ""
        Validasi_DO = ""
        If Len(mpNoRgk) <= 10 Then
            mErrorCCO = mErrorCCO & "Nomor Rangka Salah"
        ElseIf GetDataD_00NoFound01Found("SELECT * FROM TRXN_SPK WHERE SPK_NO='" & mpNoSPK & "' AND SPK_Cdlease='C001'", "", 0) = 1 Then
            If (RadioBtnAsrNo.Checked = False And RadioBtnAsrYs.Checked = False) Or (RadioBtnAsrYs.Checked = True And nLg(TxtDOAsr.Text) <= 0) Then
                mErrorCCO = mErrorCCO & "Pertanyaan sudah ada asuransi ya atau tidak dan jumlah jika YA ..Belum diisi"
            End If
        End If
        If mErrorCCO <> "" Then
            Call Msg_err(mErrorCCO, 0) : Validasi_DO = mErrorCCO
        End If
    End Function

    Function Validasi_DODealer(ByVal mpNoSPK As String, ByVal mpNoRgk As String) As String
        Dim mErrorCCO As String = ""
        Validasi_DODealer = ""

        If Len(mpNoRgk) <= 10 Then
            mErrorCCO = mErrorCCO & "Nomor Rangka Salah"
        ElseIf GetDataD_00NoFound01Found("SELECT * FROM TRXN_SPK WHERE SPK_NO='" & mpNoSPK & "' AND SPK_NAMA1 like '%HONDA%'", lblDealer.Text, 0) <> 1 Then
            mErrorCCO = mErrorCCO & "Bukan SPK Crosseling dealer"
        ElseIf (RadioBtnDoDealer1.Checked = False And RadioBtnDoDealer1.Checked = False) Then
            mErrorCCO = mErrorCCO & "Pertanyaan Jual Putus atau Barter Belum diisi"
        ElseIf Mid(lblAkses.Text, 3, 1) <> "1" Then
            mErrorCCO = mErrorCCO & "Tidak diperbolehkan buat DO dealer/CrosSell"
        End If
        If mErrorCCO <> "" Then
            Call Msg_err(mErrorCCO, 0) : Validasi_DODealer = mErrorCCO
        End If
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


    Function Validasi_BBN(ByVal mpNospk As String, ByVal mpDlr As String) As Byte
        '0 Error 1 OK
        Validasi_BBN = 1
        Dim mType As String = GetDataD_IsiField("SELECT SPK_CDTYPE as IsiField FROM TRXN_SPK WHERE SPK_Road='N' AND SPK_NO='" & mpNospk & "'", mpDlr, 0)
        If mType <> "" Then
            Validasi_BBN = 0
            If ndb(GetDataD_IsiField("SELECT SPK_HrgJadi as IsiField FROM TRXN_SPK WHERE SPK_Road='N' AND SPK_NO='" & mpNospk & "'", mpDlr, 0)) > 100000 Then
                Validasi_BBN = 1
            ElseIf ndb(GetDataD_IsiField("SELECT OPTD_Harga as IsiField FROM TRXN_OPTD,TRXN_OPT WHERE OPTD_NOWO=OPT_NOWO AND OPTD_CdAssesoris=OPT_CdAssesoris AND OPTD_CdAssesoris='0022' AND OPT_NOSPK='" & mpNospk & "'", mpDlr, 0)) > 100000 Then
                Validasi_BBN = 1
            End If
            If Validasi_BBN = 0 Then
                Dim mnilaiBBNStandard As Double = ndb(GetDataD_IsiField("SELECT TYPE_Surat as IsiField FROM DATA_TYPE WHERE TYPE_TYPE='" & mType & "'", mpDlr, 0))
                If mnilaiBBNStandard > 100000 Then
                    If UpdateDatabase_Tabel("UPDATE TRXN_SPK SET SPK_HrgJadi = " & mnilaiBBNStandard & " WHERE SPK_Road='N' AND SPK_NO='" & mpNospk & "'", mpDlr, 0) = 1 Then
                        Validasi_BBN = 1
                    End If
                End If
            End If
        End If
    End Function
    Function Nilai_DataSPK(ByVal mNOSPK As String, ByVal mNAMA As String, ByVal mServer As String) As String
        Nilai_DataSPK = ""
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Nilai_DataSPK = ""
        Dim Mytxtsql As String

        Mytxtsql = "SELECT * FROM TRXN_SPK WHERE SPK_NO='" & mNOSPK & "'"

        Call Msg_err("", "")
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(Mytxtsql, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                While MyRecReadB.Read
                    Nilai_DataSPK = nSr(MyRecReadB(mNAMA))
                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Protected Sub Button2_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("http://office.hondamugen.co.id:8087/Home.aspx?Name=" + LblUserName.Text + "")
    End Sub


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

    Function GetTotalWorkingDays(ByVal mDatestart As String, ByVal mDateEnd As String) As Integer
        GetTotalWorkingDays = 0

        Dim mStart As DateTime = InputDT("", "", "", "00", "00", "00", CDate(mDatestart))
        Dim mEnd As DateTime = InputDT("", "", "", "00", "00", "00", CDate(mDateEnd))
        While mStart <= mEnd
            If Not (mStart.DayOfWeek <= DayOfWeek.Sunday Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2019-01-01 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2019-02-05 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2019-03-07 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2019-04-03 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2019-04-19 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2019-05-01 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2019-05-30 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2019-06-01 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2019-06-05 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2019-06-06 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2019-08-17 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2019-11-09 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2019-12-25 00:00:00")) = 0) Then
                GetTotalWorkingDays = GetTotalWorkingDays + 1
            End If
            mStart = mStart.AddDays(1)
        End While
    End Function


    Function GetDataA_Tabel_SPK(ByVal mNOSPK As String, ByVal mServer As String, ByVal mType As Byte) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet" & mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", 0)
        GetDataA_Tabel_SPK = 0

        cnn = New OleDbConnection(strconn)

        MultiViewMhnDetailSub.ActiveViewIndex = -1
        lblMohonDetailTgl.Text = "" : LblNomormohon.Text = "" : LblNomor.Text = "" : lblMohonDetailTipe.Text = "" : lblMohonDetailAlasan.Text = ""
        lblMohonDetailProsesPersetujuan.Text = "" : lblMohonDetailProsesPersetujuanAkhir.Text = "" : LblStatusAkhir.Text = ""
        lblMohonDetailNilai1.Text = "" : lblMohonDetailNilai2.Text = "" : lblMohonDetailNilai3.Text = "" : lblMohonDetailNilai4.Text = ""
        LblUpdateDataSPK.Text = "" : LblAskSPV.Text = "" : LblAskSM.Text = "" : LblAskOSM.Text = "" : LblAskDIR.Text = ""

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
                    lblDealer.Text = mServer
                    lblMohonDetailSPK.Text = Txt_NoSPKMohon.Text
                    lblMohonDetailInfoSPK.Text = "  Tgl Input :" & DtFr(MyRecReadA("SPK_Tanggal"), "yyyy-MM-dd") & _
                                                 "  Tgl H-Diary :" & DtFr(MyRecReadA("SPK_TGLSPK"), "yyyy-MM-dd") & _
                                                 "  Tgl Aprvd H-Diary :" & DtFr(MyRecReadA("SPK_TGLURT"), "yyyy-MM-dd") & _
                                                 "  Tgl DO :" & DtFr(MyRecReadA("SPK_TglDO"), "yyyy-MM-dd")


                    LblNama.Text = nSr(MyRecReadA("SPK_NAMA1"))
                    LblSales.Text = nSr(MyRecReadA("Sales_Nama"))
                    LblSalesSPV.Text = nSr(MyRecReadA("SPK_CdSales")) : LblSalesSPV0.Text = nSr(MyRecReadA("SPK_CdSSales"))

                    'Unit
                    LblCdType.Text = nSr(MyRecReadA("SPK_CDTYPE"))
                    LblCdTypeNamaDetail.Text = nSr(MyRecReadA("TYPE_Nama"))
                    LblWarnaNamaDetail.Text = nSr(MyRecReadA("WARNA_Int"))
                    lblNorangka.Text = nSr(MyRecReadA("SPK_NoRangka"))
                    lblTahun.Text = nSr(MyRecReadA("SPK_Tahun"))
                    lblRoad.Text = nSr(MyRecReadA("SPK_Road"))

                    LblHarga.Text = nSr(MyRecReadA("SPK_Piutang")) : LblPaketCermat.Text = nSr(MyRecReadA("SPK_PaketCermat"))
                    LblDisc.Text = nSr(MyRecReadA("SPK_Potongan")) : LblBedaThn.Text = nSr(MyRecReadA("SPK_PaketCermatJ"))
                    LblSubsidi.Text = nSr(MyRecReadA("SPK_HrgADM"))

                    LblKomisi.Text = nSr(MyRecReadA("SPK_Komisi"))
                    LblTotal.Text = (nLg(MyRecReadA("SPK_Piutang")) - nLg(MyRecReadA("SPK_Potongan")))

                    LblJns.Text = nSr(MyRecReadA("SPK_Cdlease"))
                    LblJns0.Text = nSr(MyRecReadA("LEASE_Nama"))
                    lblTnr.Text = nSr(MyRecReadA("SPK_HrgASR"))
                    LblBayar.Text = nLg(MyRecReadA("mBayar"))

                    LblBayar.Text = nLg(MyRecReadA("mBayar")) & " Sisa " & (nLg(MyRecReadA("SPK_Piutang")) - nLg(MyRecReadA("SPK_Potongan")) - nLg(MyRecReadA("mBayar")))

                End If
                MultiViewMhnDetail.ActiveViewIndex = 0
            Else
                Call Msg_err("SPK tidak ada di HMS Mugen", 1)
                MultiViewMhnDetail.ActiveViewIndex = -1
            End If
            MyRecReadA.Close()

            If GetDataA_Tabel_SPK = 1 Then
                LblBayarUM.Text = ""
                Mytxtsql = "SELECT SPKB_NILAI AS IsiField FROM TRXN_SPKB WHERE SPKB_NO='" & Txt_NoSPKMohon.Text & "' AND SPKB_NAMA like '%UANG MUKA%'"
                LblBayarUM.Text = GetDataD_IsiField(Mytxtsql, lblDealer.Text, 1)
            End If


            cmd.Dispose()
            cnn.Close()
            'Mebuh Call GetDataA_Tabel_SPK_BAYAR(mNOSPK, mServer, 0)
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function


    Protected Sub ButtonLoadSPK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonLoadSPK.Click
        Call PermohonanFormNonAktif()
        Call GetDataA_Tabel_SPK(Txt_NoSPKMohon.Text, lblArea1.Text, 0)
    End Sub

    Sub BarterCHangeYa()
        If RadioBtnDoDealer1.Checked = True Then
            RadioBtnDoDealer1.Checked = True
            RadioBtnDoDealer2.Checked = False
        Else
            RadioBtnDoDealer1.Checked = False
            RadioBtnDoDealer2.Checked = True
        End If
    End Sub
    Sub BarterCHangeTdk()
        If RadioBtnDoDealer1.Checked = True Then
            RadioBtnDoDealer1.Checked = False
            RadioBtnDoDealer2.Checked = True
        Else
            RadioBtnDoDealer1.Checked = True
            RadioBtnDoDealer2.Checked = False
        End If
    End Sub

    Sub AsuransiYA()
        If RadioBtnAsrYs.Checked = True Then
            RadioBtnAsrYs.Checked = True
            RadioBtnAsrNo.Checked = False
        Else
            RadioBtnAsrYs.Checked = False
            RadioBtnAsrNo.Checked = True
        End If
    End Sub
    Sub AsuransiTDK()
        If RadioBtnAsrYs.Checked = True Then
            RadioBtnAsrYs.Checked = False
            RadioBtnAsrNo.Checked = True
        Else
            RadioBtnAsrYs.Checked = True
            RadioBtnAsrNo.Checked = False
        End If
    End Sub
End Class

