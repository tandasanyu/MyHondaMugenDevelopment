Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Imports System.Web.Security

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
    Dim mSaveButon As Byte
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

            If Left(LblUserName.Text, 3) = "112" Or Left(LblUserName.Text, 3) = "128" Then
                mFound = GetData_UserSecurity("SELECT * FROM DATA_SECURITYH,DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(SECURITYH_USER)=RTRIM(USER_NAMA) AND RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & Left(LblUserName.Text, 3) & "' AND SECURITYH_NOIDSALES='" & Right(LblUserName.Text, Len(LblUserName.Text) - 3) & "' AND USER_TIPE='WA' AND AKSES_MENU='0102'")
                If mFound = 1 Then
                    lblArea1.Text = Left(LblUserName.Text, 3)
                    lblArea2.Text = Left(LblUserName.Text, 3)
                End If
            Else
                mFound = GetData_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0102'")
            End If


            If mFound = 1 Then
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
                Call GetData_Tabel_Parameter("SELECT * FROM DATA_PARAMETER WHERE PARAMETER_NAMA like 'APPRVL__0%' ORDER BY PARAMETER_NAMA")
                DropDownList3.Items.Add("ENTRY SPK BARU")

                DropDownList4.Items.Clear()
                DropDownList4.Items.Add("ISLAM")
                DropDownList4.Items.Add("KATHOLIK")
                DropDownList4.Items.Add("KRISTEN")
                DropDownList4.Items.Add("BUDHA")
                DropDownList4.Items.Add("HINDU")
                DropDownList4.Items.Add("LAIN-LAIN")

                LblNoMohon.Text = ""
                [cDate].Visible = False
                [Calendar1].Visible = False
                MultiViewMhnMaster.ActiveViewIndex = 0
            Else
                lblAkses.Text = "TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI"
            End If
        End If
    End Sub
    Sub Msg_err(ByVal mTest As String)

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

    End Sub

    Function GetData_Tabel_Parameter(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetData_Tabel_Parameter = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Tabel_Parameter = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                If InStr(nSr(MyRecReadA("PARAMETER_NILAI")), "ENTRY ALASAN UBAH HARGA DISKON DAN UNIT") = 0 Then
                    DropDownList3.Items.Add(nSr(MyRecReadA("PARAMETER_NILAI")))
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Protected Sub btnfilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfilter.Click
        MultiV1WAss.ActiveViewIndex = 0
    End Sub

    Sub PermohonanFormNonAktif()

        MultiViewMhnMaster.ActiveViewIndex = -1
        MultiViewMhnDetail.ActiveViewIndex = -1
        MultiViewAdmin.ActiveViewIndex = -1

        MultiViewMhnInpDO.ActiveViewIndex = -1

        MultiViewMhnInpFaktur.ActiveViewIndex = -1
        MultiViewMhnInpHrgUnit.ActiveViewIndex = -1
        MultiViewMhnInpHrgDisc.ActiveViewIndex = -1
        MultiViewMhnInpHrgSubs.ActiveViewIndex = -1
        MultiViewMhnInpHrgKoms.ActiveViewIndex = -1
        MultiViewMhnInpTahun.ActiveViewIndex = -1

        MultiViewMhnInpLain.ActiveViewIndex = -1
        MultiViewMhnDataPemohon.ActiveViewIndex = -1
        MultiViewMobilBekas.ActiveViewIndex = -1

        MultiViewAssInputSPK.ActiveViewIndex = -1
        MultiViewAssTblStandard.ActiveViewIndex = -1
        MultiViewAssData.ActiveViewIndex = -1
        MultiUpdateDataAksesoris.ActiveViewIndex = -1
        MultiViewAssTombol.ActiveViewIndex = -1
        MultiViewAssTabel.ActiveViewIndex = -1
        MultiViewAssInpTabel.ActiveViewIndex = -1 : Button8.Visible = True : Button9.Visible = False
        MultiViewTombolSPK.ActiveViewIndex = -1
        MultiViewMhnTabelUbahSPK.ActiveViewIndex = -1
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
        Button3.Visible = False
        Button2.Visible = True
    End Sub
    Protected Sub BtnLihatAss_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLihatAss.Click
        MultiView1a.ActiveViewIndex = 0
    End Sub
    Protected Sub BtnLihatJdwl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLihatJdwl.Click
        MultiView1a.ActiveViewIndex = 3
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        MultiV4Jadwal.ActiveViewIndex = 0
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


    '================================Purchase order Aksesoris
    Protected Sub ButtonSimpan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSimpan.Click
        Dim mTxtInsert As String = ""
        Call Msg_err("")
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
        If GetDataSearching(mTxtInsert) = 1 Then
            Call Msg_err("AKSESORIS INI SUDAH DISETUJUI ATAU DALAM PROSES PENGAJUAN (ENTRY)")
        Else
            mTxtInsert = "INSERT INTO TRXN_OPTPO " & _
                         "(OPT_NOMORMOHON,OPT_NOMOR,OPT_NODEALER,OPT_USER,OPT_SPV,OPT_TGL,OPT_NOSPK,OPT_TIPE," & _
                         " OPT_CDASS,OPT_STATUS,OPT_QTY,OPT_HARGAJUAL,OPT_HARGACUST,OPT_KETERANGAN," & _
                         " OPT_TGLAPPV1,OPT_STATUSAPPV1,OPT_CATATAN1,OPT_USERAPPV1,OPT_TGLAPPV2,OPT_STATUSAPPV2,OPT_CATATAN2,OPT_USERAPPV2,OPT_STATUSPROSES,OPT_NOWO,OPT_APPROVALCODE,OPT_APPROVALCODEP,OPT_ERROR) VALUES " & _
                         "('" & LblNoMohon.Text & "','','" & lblArea1.Text & "','" & LblUserName.Text & "','',GETDATE(),'" & txtnospk.Text & "','" & DropDownList1.Text & "'," & _
                         " '" & LblAksesorisKode.Text & "','" & IIf(DropDownList2.Text = "BAYAR", "1", "0") & "'," & nLg(TxtAksesorisQty.Text) & "," & nLg(LblAksesorisModal.Text) & "," & IIf(DropDownList2.Text = "BAYAR", nLg(TxtHargaAss.Text), "0") & ",'" & TxtPetik(TxtCatatan.Text) & "'," & _
                         " NULL,'','','',NULL,'','','','ENTRY-D','','" & LblApproved.Text & "','','')"
            If UpdateDatabase_Tabel(mTxtInsert) = 1 Then
                Call Msg_err("Data Permohonan sudah tersimpan ......")
                Call ClearInputAsesoris()
                LvPO.DataBind()

                mTxtInsert = "UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='TOLAK-0' WHERE OPT_NODEALER='" & lblArea1.Text & "' AND OPT_NOSPK='" & txtnospk.Text & "' AND OPT_CDASS='" & LblAksesorisKode.Text & "' AND (OPT_STATUSPROSES like '%TOLAK-SPV%')"
                Call UpdateDatabase_Tabel(mTxtInsert)
                mTxtInsert = "UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='TOLAK-1' WHERE OPT_NODEALER='" & lblArea1.Text & "' AND OPT_NOSPK='" & txtnospk.Text & "' AND OPT_CDASS='" & LblAksesorisKode.Text & "' AND (OPT_STATUSPROSES like '%TOLAK-SM%')"
                Call UpdateDatabase_Tabel(mTxtInsert)

                mTxtInsert = "UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='ENTRY-D' WHERE OPT_NOMORMOHON='" & LblNoMohon.Text & "' AND OPT_STATUSPROSES ='ENTRY'"
                Call UpdateDatabase_Tabel(mTxtInsert)
                mTxtInsert = "DELETE FROM TRXN_SPKAD WHERE NOMOR_MOHON='" & LblNoMohon.Text & "'"
                Call UpdateDatabase_Tabel(mTxtInsert)
                mTxtInsert = "DELETE FROM TRXN_SPKAHERR  WHERE SPKAHERR_NOM='" & LblNoMohon.Text & "'"
                Call UpdateDatabase_Tabel(mTxtInsert)
            End If
        End If
    End Sub
    Function GetDataPOAsesoris(ByVal mSqlCommadstring As String, ByVal mKodeAss As String, ByVal mKodeTipe As String, ByVal mGET As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetDataPOAsesoris = ""
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    If mGET = "VAL" Then
                        If mKodeAss = (nSr(MyRecReadA("OPT_CDASS"))) Then
                            GetDataPOAsesoris = "1"
                            LblErrorSave.Text = "Kode Asesoris Sudah Ada"
                        ElseIf mKodeTipe <> (nSr(MyRecReadA("OPT_TIPE"))) Then
                            GetDataPOAsesoris = "1"
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
                        GetDataPOAsesoris = (nSr(MyRecReadA(mKodeTipe)))
                    Else
                        GetDataPOAsesoris = "1"
                    End If
                End While

            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function
    Function UpdateDatabase_Tabel(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
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
            Call Msg_err(ex.Message)
        End Try
    End Function



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
        GetDataMasterAsesoris("SELECT * FROM DATA_STANDARD WHERE STANDARD_KODE='" & LblAksesorisKode.Text & "'")
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
            LblAksesorisModal.Text = GetDataMasterHarga(MySTRsql1)
        End If
    End Sub
    Protected Sub LvPO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvPO.SelectedIndexChanged
        LblAksesorisKode.Text = (LvPO.DataKeys(LvPO.SelectedIndex).Value.ToString)
        Call GetDataPOAsesoris("SELECT * FROM TRXN_OPTPO,DATA_STANDARD WHERE OPT_CDASS=STANDARD_KODE AND OPT_NODEALER='" & lblArea1.Text & "' AND OPT_NOSPK='" & txtnospk.Text & "' AND OPT_CDASS='" & LblAksesorisKode.Text & "'", "", "", "GET")
        If UCase(LblUserName.Text) = "ITPSMOK" Or UCase(LblUserName.Text) = "ITPURIOK" Then
            CheckBoxUpdateAss.Checked = False : CheckBoxUpdateAss1.Checked = False : CheckBoxUpdateAss2.Checked = False
            CheckBoxUpdateAss.Text = "UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='SETUJU-A' WHERE OPT_STATUSPROSES like 'SETUJU%' AND  OPT_NOMORMOHON='" & LblNomorMohonOPT.Text & "'"
            CheckBoxUpdateAss1.Text = "UPDATE TRXN_OPTPO SET OPT_NOSPK='BATAL-' WHERE OPT_NOSPK='" & txtnospk.Text & "' AND OPT_NODEALER='" & lblArea1.Text & "'"
            CheckBoxUpdateAss2.Text = "DELETE FROM TRXN_SPKAHERR WHERE SPKAHERR_NOM='" & LblNomorMohonOPT.Text & "'"
            MultiUpdateDataAksesoris.ActiveViewIndex = 0
        End If
    End Sub

    Function GetDataSearching(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetDataSearching = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                GetDataSearching = 1
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function GetDataMasterAsesoris(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetDataMasterAsesoris = 0
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
            Call Msg_err(ex.Message)
        End Try
    End Function
    Function GetDataMasterHargaOld(ByVal mSqlCommadstring As String) As Double
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
        GetDataMasterHargaOld = 0
        Call Msg_err("")
        GetDataMasterHargaOld = 0
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
                    GetDataMasterHargaOld = (nLg(MyRecReadA("STANDARDH_JualPasar")))
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
                        GetDataMasterHargaOld = mHargaStandard : Exit For
                    ElseIf (GetDataMasterHargaOld > mHargaStandard And mNomModalSuplier(mPanjangArary) > 0) Or _
                    GetDataMasterHargaOld = 0 Then
                        GetDataMasterHargaOld = mHargaStandard
                    End If
                Next
            End If
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function GetDataMasterHarga(ByVal mSqlCommadstring As String) As Double
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



        GetDataMasterHarga = 0
        Call Msg_err("")
        GetDataMasterHarga = 0
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
                GetDataMasterHarga = mRpMugen
            Else
                LblAksesorisDesc.Text = mSuplierAktif
            End If
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function
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
        If GetDataPOAsesoris("SELECT * FROM TRXN_OPTPO WHERE OPT_NODEALER='" & lblArea1.Text & "' AND OPT_NOSPK='" & txtnospk.Text & "' AND OPT_CDASS='" & LblAksesorisKode.Text & "' AND (OPT_TGLAPPV1 IS NOT NULL AND OPT_TGLAPPV2 IS NOT NULL)", "", "", "") = "1" Then
            Call Msg_err("Tidak Bisa dihapus sudah disetujui SM (untuk pembatalan segera lapor purchasing ......")
        Else
            Dim mTxtInsert As String = "DELETE FROM TRXN_OPTPO WHERE OPT_NODEALER='" & lblArea1.Text & "' AND OPT_NOSPK='" & txtnospk.Text & "' AND OPT_CDASS='" & LblAksesorisKode.Text & "' AND (OPT_NOWO='' OR OPT_NOWO IS NULL)"
            If UpdateDatabase_Tabel(mTxtInsert) = 1 Then
                'mTxtInsert = "DELETE FROM TRXN_SPKAD WHERE NOMOR_MOHON='" & LblNoMohon.Text & "'"
                'Call UpdateDatabase_Tabel(mTxtInsert)
                'mTxtInsert = "DELETE FROM TRXN_SPKAHERR  WHERE SPKAHERR_NOM='" & LblNoMohon.Text & "'"
                'Call UpdateDatabase_Tabel(mTxtInsert)
                Call Msg_err("Data Permohonan sudah terhapus ......")
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
        MultiViewMobilBekas.ActiveViewIndex = -1
        MultiViewMhnInpDO.ActiveViewIndex = -1
        MultiViewMhnInpFaktur.ActiveViewIndex = -1
        MultiViewMhnInpHrgUnit.ActiveViewIndex = -1 : TxtChangeHargaUnit.Text = ""
        MultiViewMhnInpHrgDisc.ActiveViewIndex = -1 : TxtChangeHargaDisc.Text = ""
        MultiViewMhnInpHrgSubs.ActiveViewIndex = -1 : TxtChangeHargaSubs.Text = ""
        MultiViewMhnInpHrgKoms.ActiveViewIndex = -1 : TxtChangeHargaKoms.Text = ""
        MultiViewMhnInpLain.ActiveViewIndex = -1
        MultiViewMhnInpTahun.ActiveViewIndex = -1 : TxtChangeTahun.Text = "" : TxtChangeTahun.Visible = False

        MultiViewMhnInpPaketCermat.ActiveViewIndex = -1 : TxtChangePaketCermatM.Text = "" 
        MultiViewMhnInpBedaThn.ActiveViewIndex = -1 : TxtChangeBedaThn.Text = ""
        MultiViewMhnInpSwitch.ActiveViewIndex = -1 : txtNoSPKSWTuju.Text = "" : txtNoSPKSWNom.Text = ""

        MultiViewMhnInpSubsidiSales.ActiveViewIndex = -1 : TxtChangeSubsidiSales.Text = ""
        MultiViewMhnInpBatalSPKHMS.ActiveViewIndex = -1 : TxtChangeSPKBatal.Text = ""

        TxtFakturNama.Text = "" : TxtFakturAlamat.Text = "" : TxtFakturKota.Text = "" : TxtFakturPos.Text = ""
        TxtFakturNoHP.Text = "" : TxtFakturNoKTP.Text = "" : TxtTglLahir.Text = ""
        TxtFakturNoPolisi.Text = "" : TxtNOTE.Text = ""
        CheckFktLamp1.Checked = False : CheckFktLamp2.Checked = False : CheckFktLamp3.Checked = False : CheckFktLamp4.Checked = False : CheckFktLamp5.Checked = False

        Call ClearInputDataSPKMobilSecond()

        TxtNilaiBaru.Text = ""
        'If DropDownList3.Text = "ENTRY TOTAL UBAH HARGA UNIT MENJADI" Or _
        '   DropDownList3.Text = "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON" Then
        If DropDownList3.Text = "ENTRY TOTAL UBAH HARGA UNIT MENJADI"  Then
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

        If DropDownList3.Text = "ENTRY PAKET CERMAT" Then
            MultiViewMhnInpPaketCermat.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY ALASAN PROSES CANCEL SPK HMS" Then
            MultiViewMhnInpBatalSPKHMS.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY SELISIH HARGA UNIT BEDA TAHUN" Then
            MultiViewMhnInpBedaThn.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY PINDAH UANG MUKA ANTAR SPK" Then
            MultiViewMhnInpSwitch.ActiveViewIndex = 0
        End If

        'If DropDownList3.Text = "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON" Then
        'MultiViewMhnInpSwitch.ActiveViewIndex = 0
        'End If

        If DropDownList3.Text = "ENTRY ALASAN DO/ISI NOMOR RANGKA" Then
            MultiViewMhnInpDO.ActiveViewIndex = 0
            MultiViewMhnInpFaktur.ActiveViewIndex = 0
            MultiViewAssTabel.ActiveViewIndex = 0
            MultiViewAssInpTabel.ActiveViewIndex = 0 : Button8.Visible = True : Button9.Visible = False
            txtnospk.Text = Txt_NoSPKMohon.Text
            If Txt_NoSPKMohon.Text <> "" Then
                LvPO.DataBind()
            End If
        End If
        If DropDownList3.Text = "ENTRY ALASAN PEMBUATAN FAKTUR" Then
            MultiViewMhnInpFaktur.ActiveViewIndex = 0
        End If
        If DropDownList3.Text = "ENTRY SPK BARU" Then
            MultiViewMobilBekas.ActiveViewIndex = 0
        End If

        If MultiViewMhnInpDO.ActiveViewIndex = -1 And _
            MultiViewMhnInpFaktur.ActiveViewIndex = -1 And _
            MultiViewMhnInpHrgUnit.ActiveViewIndex = -1 And _
            MultiViewMhnInpHrgDisc.ActiveViewIndex = -1 And _
            MultiViewMhnInpHrgSubs.ActiveViewIndex = -1 And _
            MultiViewMhnInpHrgKoms.ActiveViewIndex = -1 And _
            MultiViewMhnInpPaketCermat.ActiveViewIndex = -1 And _
            MultiViewMhnInpBatalSPKHMS.ActiveViewIndex = -1 And _
            MultiViewMhnInpBedaThn.ActiveViewIndex = -1 And _
            MultiViewMhnInpSwitch.ActiveViewIndex = -1 And _
            MultiViewMobilBekas.ActiveViewIndex = -1 Then
            TxtNilaiBaru.Visible = True
            MultiViewMhnInpLain.ActiveViewIndex = 0
        End If
        If DropDownList3.Text <> "ENTRY SPK BARU" Then
            MultiViewTombolSPK.ActiveViewIndex = 0
        End If
        MultiViewMhnTabelUbahSPK.ActiveViewIndex = 0
    End Sub

    Protected Sub Txt_NoSPKMohon_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_NoSPKMohon.TextChanged
        MultiViewMhnInpDO.ActiveViewIndex = -1
        If DropDownList3.Text = "ENTRY ALASAN DO/ISI NOMOR RANGKA" And Txt_NoSPKMohon.Text <> "" Then
            MultiViewMhnInpDO.ActiveViewIndex = 0
        End If
        LvPermohonan.DataBind()
    End Sub

    Protected Sub ButtonTgl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn1.Click
        [cDate].Visible = True
    End Sub

    Protected Sub cDate_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [cDate].SelectionChanged
        TxtTglLahir.Text = [cDate].SelectedDate.ToString
        [cDate].Visible = False
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
        TxtChangeTahun.Text = "" : TxtChangeTahun.Visible = False
        TxtNilaiBaru.Text = ""

        lblPemohon.Text = LblUserName.Text
    End Sub

    Sub ClearInputDataSPKMobilSecond()

        LblMobkasNoSPK.Text = ""
        TxtMobkasNama.Text = "" : TxtMobkasAlamat.Text = "" : TxtMobkasKota.Text = "" : TxtMobkasPos.Text = ""
        TxtMobkasTglLahir.Text = "" : DropDownListAgama.SelectedIndex = -1
        TxtMobkasPhone.Text = "" : TxtMobkasHp.Text = "" : TxtMobkasEmail.Text = ""
        DropDownListStatus.SelectedIndex = -1
        TxtMobkasTipe.Text = "" : TxtMobkasTipeN.Text = ""
        TxtMobkasWarna.Text = "" : TxtMobkasWarnaN.Text = ""
        TxtMobkasTahun.Text = "" : DropDownRoad.SelectedIndex = 0
        TxtMobkasRangka.Text = "" : TxtMobkasMesin.Text = ""
        TxtMobkasSales.Text = "" : TxtMobkasSPV.Text = ""

        TxtMobkasHrgJual.Text = "0" : TxtMobkasHrgKomisi.Text = "0" : TxtMobkasHrgPot.Text = "0" : TxtMobkasHrgSubsidi.Text = "0"
        LblMobKasTotalJual.Text = "0"
        TxtMobkasHrgAks.Text = "0"

        TxtMobkasLease.Text = "" : TxtMobkasLeaseJangka.Text = "" : TxtMobkasJTP.Text = ""
        TxtMobkasKeterangan.Text = ""

        TxtMobkasFNama.Text = ""
        TxtMobkasFAlamat.Text = "" : TxtMobkasFKota.Text = "" : TxtMobkasFPos.Text = ""
        TxtMobkasFHp.Text = "" : TxtMobkasFPhone.Text = ""
        DropDownListFagama.SelectedIndex = -1 : TxtMobkasFTglLahir.Text = ""

        TxtMobkasSuplier.Text = "" : lblMobkasSales.Text = ""
        TxtMobkasModal.Text = "0" : TxtMobkasModalPPN.Text = "0"


    End Sub


    '===============================
    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        [Calendar1].Visible = True
    End Sub
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Calendar1].SelectionChanged, Calendar1.SelectionChanged
        txtDate.Text = [Calendar1].SelectedDate.ToString
        [Calendar1].Visible = False
    End Sub
    '===============================


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
            DtFrSQL = "'" & Format(CDate(mNilai), "yyyy-MM-dd HH:MM:ss") & "'"
        End If
        'MsgBox(DtFrSQL)
ErrHand:
    End Function


    'Permohonan Selain Asesori
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim mAroval As String
        Dim mArovalP As String
        Dim mOrEmail1 As String = ""
        Dim mOrEmail2 As String = ""

        Call Msg_err("")

        If Txt_NoSPKMohon.Text = "" Or txtalasanmohon.Text = "" Or DropDownList3.Text = "" Then
            Call Msg_err("ISIAN BELUM LENGKAP ") : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY TAMBAH AKSESORIS" Then
            Call Msg_err("PERMOHONAN PASANG AKSESORIS MUNGGUNAKAN FORM ASESORIS") : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY TOTAL UBAH HARGA UNIT MENJADI" And _
           (Not IsNumeric(TxtChangeHargaUnit.Text) Or Val(TxtChangeHargaUnit.Text) < 0 Or TxtChangeHargaUnit.Text = "") Then
            Call Msg_err("ISIAN HARGA PERUBAHAN UNIT BELUM DIISI") : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY PAKET CERMAT" And _
           (Not IsNumeric(TxtChangePaketCermatM.Text) Or Val(TxtChangePaketCermatM.Text) < 0 Or TxtChangePaketCermatM.Text = "") Then
            Call Msg_err("ISIAN HARGA PAKET CERMAT BELUM DIISI") : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY ALASAN PROSES CANCEL SPK HMS" And _
           (Not IsNumeric(TxtChangeSPKBatal.Text) Or Val(TxtChangeSPKBatal.Text) < 0 Or TxtChangeSPKBatal.Text = "") Then
            Call Msg_err("ISIAN NOMOR SPK BELUM DIISI DENGAN BENAR") : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY SELISIH HARGA UNIT BEDA TAHUN" And _
           (Not IsNumeric(TxtChangeBedaThn.Text) Or Val(TxtChangeBedaThn.Text) < 0 Or TxtChangeBedaThn.Text = "") Then
            Call Msg_err("ISIAN HARGA SELISIH HARGA UNIT BEDA TAHUN") : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY TOTAL UBAH HARGA DISKON MENJADI" And _
               (Not IsNumeric(TxtChangeHargaDisc.Text) Or Val(TxtChangeHargaDisc.Text) < 0 Or TxtChangeHargaDisc.Text = "") Then
            Call Msg_err("ISIAN HARGA PERUBAHAN DISKON/POTONGAN BELUM DIISI") : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY ALASAN SUBSIDI" And _
               (Not IsNumeric(TxtChangeHargaSubs.Text) Or Val(TxtChangeHargaSubs.Text) < 0 Or TxtChangeHargaSubs.Text = "") Then
            Call Msg_err("ISIAN HARGA PERUBAHAN SUBSIDI BELUM DIISI") : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY ALASAN KOMISI" And _
               (Not IsNumeric(TxtChangeHargaKoms.Text) Or Val(TxtChangeHargaKoms.Text) < 0 Or TxtChangeHargaKoms.Text = "") Then
            Call Msg_err("ISIAN HARGA PERUBAHAN KOMISI BELUM DIISI") : Exit Sub
            'txtNoSPKSWAsal.Text = "" : txtNoSPKSWTuju.Text = "" : txtNoSPKSWNom.Text
        ElseIf DropDownList3.Text = "ENTRY PINDAH UANG MUKA ANTAR SPK" And _
               (Not IsNumeric(txtNoSPKSWTuju.Text) Or Val(txtNoSPKSWTuju.Text) <= 0 Or _
                Not IsNumeric(txtNoSPKSWNom.Text) Or Val(txtNoSPKSWNom.Text) <= 0) Then
            Call Msg_err("ISIAN PINDAH UANG MUKA ANTAR SPK SALAH PERIKSA NOMOR SPK DAN JUMLAH") : Exit Sub
        ElseIf DropDownList3.Text = "ENTRY ALASAN DO/ISI NOMOR RANGKA" And (Len(TxtChangeNorangka.Text) <= 10) Then
            Call Msg_err("ISIAN NOMOR RANGKA BELUM DIISI") : Exit Sub
        ElseIf (DropDownList3.Text = "ENTRY ALASAN DO/ISI NOMOR RANGKA" Or DropDownList3.Text = "ENTRY ALASAN PEMBUATAN FAKTUR") And _
               (TxtFakturNama.Text = "" Or TxtFakturAlamat.Text = "" Or TxtFakturKota.Text = "" Or TxtFakturPos.Text = "" Or TxtFakturNoHP.Text = "" Or _
                TxtFakturNoKTP.Text = "" Or TxtTglLahir.Text = "" Or DropDownList2.Text = "" Or TxtFakturNoPolisi.Text = "" Or _
                (CheckFktLamp1.Checked = False And CheckFktLamp2.Checked = False And CheckFktLamp3.Checked = False And CheckFktLamp4.Checked = False And CheckFktLamp5.Checked = False)) Then
            Call Msg_err("ISIAN DATA FAKTUR BELUM LENGKAP") : Exit Sub
        ElseIf Len(Txt_NoSPKMohon.Text) <> 6 Then
            Call Msg_err("PANJANG NOMOR SPK TIDAK SESUAI DENGAN FORMAT (PANJANG 6 DIGIT)") : Exit Sub

        End If
        mAroval = GetData_Parameter("SELECT * FROM DATA_PARAMETER WHERE PARAMETER_NAMA like 'APPRVL%0%' AND PARAMETER_NILAI like '" & DropDownList3.Text & "' ORDER BY PARAMETER_NAMA")
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

            Call UpdateData_Tabel_SPK("UPDATE TRXN_SPKAH SET JUDUL=replace(JUDUL,'ENTRY','BATAL')  WHERE JUDUL LIKE 'ENTRY%' AND (NOMOR_MOHON like '%" & mNomorMohon & "%' OR NOMOR_MOHON like '%" & mOrEmail1 & "%' OR NOMOR_MOHON like '%" & mOrEmail2 & "%')")
            Call UpdateData_Tabel_SPK("DELETE FROM TRXN_SPKAF WHERE SPKAF_NOMORMOHON='" & mNomorMohon & "'")
            Dim mTxtInsert As String

            mTxtInsert = "'" & TxtPetik(Left(Trim(TxtNilaiBaru.Text), 20)) & "','','','',''"
            If DropDownList3.Text = "ENTRY TOTAL UBAH HARGA UNIT MENJADI" Then
                mTxtInsert = "'" & TxtPetik(Left(Trim(TxtChangeHargaUnit.Text), 20)) & "','','','',''"
            ElseIf DropDownList3.Text = "ENTRY TOTAL UBAH HARGA DISKON MENJADI" Then
                mTxtInsert = "'','" & TxtPetik(Left(Trim(TxtChangeHargaDisc.Text), 20)) & "','','',''"
            ElseIf DropDownList3.Text = "ENTRY ALASAN SUBSIDI" Then
                mTxtInsert = "'','','" & TxtPetik(Left(Trim(TxtChangeHargaSubs.Text), 20)) & "','',''"
            ElseIf DropDownList3.Text = "ENTRY ALASAN KOMISI" Then
                mTxtInsert = "'','','','" & TxtPetik(Left(Trim(TxtChangeHargaKoms.Text), 20)) & "',''"
            ElseIf DropDownList3.Text = "ENTRY ALASAN MELEBIHI MAKSIMAL DISKON" Then
                mTxtInsert = "'" & TxtPetik(Left(Trim(TxtChangeHargaUnit.Text), 20)) & "','" & TxtPetik(Left(Trim(TxtChangeHargaDisc.Text), 20)) & "','" & _
                             TxtPetik(Left(Trim(TxtChangeHargaSubs.Text), 20)) & "','" & TxtPetik(Left(Trim(TxtChangeHargaKoms.Text), 20)) & "','" & TxtChangeTahun.Text & "'"
            ElseIf DropDownList3.Text = "ENTRY ALASAN DO/ISI NOMOR RANGKA" Then
                mTxtInsert = "'" & UCase(TxtPetik(Left(Trim(TxtChangeNorangka.Text), 20))) & "','','','',''"
            ElseIf DropDownList3.Text = "ENTRY PAKET CERMAT" Then
                mTxtInsert = "'" & UCase(TxtPetik(Left(Trim(TxtChangePaketCermatM.Text), 20))) & "','','','',''"
            ElseIf DropDownList3.Text = "ENTRY ALASAN PROSES CANCEL SPK HMS" Then
                mTxtInsert = "'" & UCase(TxtPetik(Left(Trim(TxtChangeSPKBatal.Text), 20))) & "','','','',''"
            ElseIf DropDownList3.Text = "ENTRY SELISIH HARGA UNIT BEDA TAHUN" Then
                mTxtInsert = "'" & UCase(TxtPetik(Left(Trim(TxtChangeBedaThn.Text), 20))) & "','','','',''"
            ElseIf DropDownList3.Text = "ENTRY PINDAH UANG MUKA ANTAR SPK" Then
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
                         "(NOMOR_MOHON,NOMOR_SPK,JUDUL,KETERANGAN,TANGGAL_PROSES,TANGGAL_ENTRY,CABANG,CATATAN,APPROVALCODE,APPROVALCODEP,RUPIAH,CHANGE,CHANGE1,CHANGE2,CHANGE3,CHANGE4,MYUSER,SPV) VALUES ('" & _
                         mNomorMohon & "','" & Txt_NoSPKMohon.Text & "','" & DropDownList3.Text & "','" & TxtPetik(txtalasanmohon.Text) & "',NULL,GETDATE(),'" & lblArea1.Text & "','','" & mAroval & "','" & mArovalP & "',0," & mTxtInsert & ",'" & Mid(LblUserName.Text, 1, 10) & "','')"

            If UpdateData_Tabel_SPK(mTxtInsert) = 1 Then


                mTxtInsert = "DELETE FROM TRXN_SPKAD WHERE NOMOR_MOHON='" & mNomorMohon & "'"
                Call UpdateData_Tabel_SPK(mTxtInsert)
                mTxtInsert = "DELETE FROM TRXN_SPKAHERR  WHERE SPKAHERR_NOM='" & mNomorMohon & "'"
                Call UpdateData_Tabel_SPK(mTxtInsert)

                Call Msg_err("Data Permohonan sudah tersimpan ......")
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
                    Call UpdateData_Tabel_SPK(mTxtInsert)
                End If

                If lblArea1.Text = "112" Then
                    'Call SendEmailProces("Faiz@hondamugen.co.id", "Permohonan persetujuan melebihi Diskon tgl " & Now(), "", "", "Permohonan persetujuan melebihi Diskon tgl " & Now())
                Else
                    'Call SendEmailProces("Ugam@hondamugen.co.id", "Permohonan persetujuan melebihi Diskon tgl " & Now(), "", "", "Permohonan persetujuan melebihi Diskon tgl " & Now())
                End If
            End If
        Else
            Call Msg_err("TIDAK TERSIMPAN USER YANG MENYETUJUI BELUM ADA ATAU NOMOR MOHON")
        End If

        'MultiView1a.ActiveViewIndex = 1
        'MultiView1a.ActiveViewIndex = 2
        MultiView1a.ActiveViewIndex = 2
        LvPermohonan.DataBind()

    End Sub

    Function cari_kode_mohon(ByVal mData1 As String, ByVal mData2 As String, ByVal mTipe As String) As String
        Dim mMohon1 As String
        Dim mMohon2 As String
        Call Msg_err("")
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
        ElseIf InStr(mData1, "WB/APR/PC") <> 0 Or InStr(mData2, "ENTRY PAKET CERMAT") <> 0 Then
            mMohon1 = "ENTRY PAKET CERMAT"
            mMohon2 = "WB/APR/PC"
        ElseIf InStr(mData1, "WB/APR/BT") <> 0 Or InStr(mData2, "ENTRY SELISIH HARGA UNIT BEDA TAHUN") <> 0 Then
            mMohon1 = "ENTRY SELISIH HARGA UNIT BEDA TAHUN"
            mMohon2 = "WB/APR/BT"
        ElseIf InStr(mData1, "EM/APR/BS") <> 0 Or InStr(mData2, "ENTRY ALASAN PROSES CANCEL SPK HMS") <> 0 Then
            mMohon1 = "ENTRY ALASAN PROSES CANCEL SPK HMS"
            mMohon2 = "EM/APR/BS"
        ElseIf InStr(mData1, "WB/APR/BH") <> 0 Or InStr(mData2, "ENTRY PENGAJUAN BATAL H3S") <> 0 Then
            mMohon1 = "ENTRY PENGAJUAN BATAL H3S"
            mMohon2 = "WB/APR/BH"
        ElseIf InStr(mData1, "WB/APR/SW") <> 0 Or InStr(mData2, "ENTRY PINDAH UANG MUKA ANTAR SPK") <> 0 Then
            mMohon1 = "ENTRY PINDAH UANG MUKA ANTAR SPK"
            mMohon2 = "WB/APR/SW"
        End If
        If mTipe = "JUDUL" Then
            cari_kode_mohon = mMohon1
        Else
            cari_kode_mohon = mMohon2
        End If
    End Function

    Function GetData_Parameter(ByVal mSqlCommadstring As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
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
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function UpdateData_Tabel_SPK(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        UpdateData_Tabel_SPK = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_Tabel_SPK = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Protected Sub LvUnitStok_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvUnitStok.SelectedIndexChanged
        TxtChangeNorangka.Text = (LvUnitStok.DataKeys(LvUnitStok.SelectedIndex).Value.ToString)
    End Sub

    Protected Sub ButtonSimpan1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSimpan1.Click
        LvUnitStok.DataBind()
    End Sub

    Protected Sub LvPermohonan_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvPermohonan.SelectedIndexChanged
        Dim mKode As String
        mKode = (LvPermohonan.DataKeys(LvPermohonan.SelectedIndex).Value.ToString)

        MultiViewMhnMaster.ActiveViewIndex = -1
        MultiViewMhnDetail.ActiveViewIndex = 0
        If UCase(LblUserName.Text) = "ITPSMOK" Or UCase(LblUserName.Text) = "ITPURIOK" Then
            MultiViewAdmin.ActiveViewIndex = 0
        End If

        Button3.Visible = True
        Button2.Visible = False

        'Dim InputDT As Date = New DateTime(Year(mKode), Month(mKode), Day(mKode), Hour(mKode), Minute(mKode), Second(mKode))



        'mKode = Format(CDate(InputDT), "yyyy-MM-dd HH:mm:ss")
        If LblNomormohon.Text <> "" Then
            LblNomor.Text = "" : LblAskSPV.Text = "" : LblAskSM.Text = "" : LblAskOSM.Text = "" : LblAskDIR.Text = "" : LblStatusAkhir.Text = ""

            Call GetDataMasterDetail("SELECT * FROM TRXN_SPKAH WHERE NOMOR_SPK='" & Txt_NoSPKMohon.Text & "' AND JUDUL='" & mKode & "' AND CABANG='" & lblArea1.Text & "'")
            Call GetData_Tabel_SPKAD("SELECT * FROM TRXN_SPKAD WHERE TRXN_SPKAD.NOMOR_MOHON='" & LblNomormohon.Text & "'")
            If LblNomor.Text <> "" Then
                Call GetData_Tabel_SPKASK("SELECT * FROM TRXN_SPKAS WHERE TRXN_SPKAS.SETUJU_NOMOR='" & LblNomor.Text & "'")
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

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        MultiViewMhnDetail.ActiveViewIndex = -1
        MultiViewAdmin.ActiveViewIndex = -1
        MultiViewMhnMaster.ActiveViewIndex = 0
        Button3.Visible = False
        Button2.Visible = True
    End Sub

    Function GetDataMasterDetail(ByVal mSqlCommadstring As String) As Double
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Call Msg_err("")
        GetDataMasterDetail = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            lblMohonDetailTgl.Text = ""
            lblMohonDetailSPK.Text = ""
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

                    If InStr(nSr(MyRecReadA("JUDUL")), "MAKSIMAL") <> 0 Then
                        lblMohonDetailJudul1.Text = "Potongan"
                        lblMohonDetailNilai1.Text = nLg(MyRecReadA("CHANGE1"))
                        lblMohonDetailJudul2.Text = "Subidi"
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
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function GetData_Tabel_SPKAD(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetData_Tabel_SPKAD = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Tabel_SPKAD = IIf(MyRecReadA.HasRows = True, 1, 0)

            LblNama.Text = "" : LblSales.Text = "" : LblSalesSPV.Text = "" : LblSalesSPV0.Text = ""
            LblCdType.Text = "" : LblCdTypeNamaDetail.Text = "" : lblGroupTipeNamaDetail.Text = ""
            LblWarnaNamaDetail.Text = ""

            lblNorangka.Text = "" : lblTahun.Text = ""
            LblHarga.Text = "" : LblDisc.Text = "" : LblSubsidi.Text = "" : LblKomisi.Text = "" : LblTotal.Text = ""

            LblJns.Text = "" : LblJns0.Text = "" : lblRoad.Text = "" : lblTnr.Text = ""
            LblBayar.Text = "" : LblBayarUM.Text = ""


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
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function


    Function GetData_Tabel_SPKASK(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetData_Tabel_SPKASK = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Tabel_SPKASK = IIf(MyRecReadA.HasRows = True, 1, 0)
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
            Call Msg_err(ex.Message)
        End Try
    End Function

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        If (InStr(lblMohonDetailTipe.Text, "ENTRY") Or InStr(lblMohonDetailTipe.Text, "BATAL")) <> 0 And LblNomormohon.Text <> "" Then
            Call UpdateData_Tabel_SPK("UPDATE TRXN_SPKAH SET TANGGAL_PROSES=NULL  WHERE NOMOR_MOHON = '" & LblNomormohon.Text & "'")
            Call UpdateData_Tabel_SPK("DELETE FROM  TRXN_SPKAD WHERE NOMOR_MOHON= '" & LblNomormohon.Text & "'")
            Call UpdateData_Tabel_SPK("DELETE FROM  TRXN_SPKAHERR  WHERE SPKAHERR_NOM= '" & LblNomormohon.Text & "'")
            LblStatusUpdateSPK.Text = "Tunggu Maksimal 1.5 menit untuk server Mugen mengambil data SPK"
        End If
        LvPermohonan.DataBind()
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        If (InStr(lblMohonDetailTipe.Text, "ENTRY") <> 0 Or InStr(lblMohonDetailTipe.Text, "BATAL") <> 0) And LblNomormohon.Text <> "" Then
            Call UpdateData_Tabel_SPK("UPDATE TRXN_SPKAHERR SET " & _
                                      "SPKAHERR_DESC =replace(SPKAHERR_DESC,',ADA PERMOHONAN RUBAH DATA DI HMS DISETUJUI TAPI BLM DIRUBAH','')," & _
                                      "SPKAHERR_DESCR =replace(SPKAHERR_DESCR,',ADA PERMOHONAN RUBAH DATA DI HMS DISETUJUI TAPI BLM DIRUBAH','') " & _
                                      "WHERE SPKAHERR_NOM = '" & LblNomormohon.Text & "'")
        End If
        LvPermohonan.DataBind()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If LblNomorMohonOPT.Text <> "" Then
            Call UpdateData_Tabel_SPK("UPDATE TRXN_OPTPO SET OPT_STATUSPROSES='ENTRY-D'  WHERE OPT_NOMORMOHON = '" & LblNomorMohonOPT.Text & "' AND (OPT_STATUSPROSES='ENTRY' OR OPT_STATUSPROSES='0')")
            Call UpdateData_Tabel_SPK("DELETE FROM  TRXN_SPKAD WHERE NOMOR_MOHON= '" & LblNomorMohonOPT.Text & "'")
            Call UpdateData_Tabel_SPK("DELETE FROM  TRXN_SPKAHERR  WHERE SPKAHERR_NOM= '" & LblNomorMohonOPT.Text & "'")
            LblStatusUpdateOPT.Text = "Tunggu Maksimal 1.5 menit untuk server Mugen mengambil data SPK"
        Else
            LblStatusUpdateOPT.Text = "Tidak ada permohonan yang akan di update data SPKnya"
        End If
        LvPO.DataBind()
    End Sub

    Protected Sub ButtonRefreshAsesoris_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRefreshAsesoris.Click
        LvPO.DataBind()
    End Sub

    Protected Sub ButtonSPKrefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSPKrefresh.Click
        LvPermohonan.DataBind()
        MultiViewMhnTabelUbahSPK.ActiveViewIndex = 0
    End Sub

    Protected Sub Button8Cad_Click()
        If InStr(lblMohonDetailTipe.Text, "SETUJU") <> 0 And LblNomormohon.Text <> "" Then
            'Call UpdateData_Tabel_SPK("UPDATE TRXN_SPKAH SET STATUS=NULL  WHERE NOMOR_MOHON = '" & LblNomormohon.Text & "'")
        End If
        LvPermohonan.DataBind()
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


    Protected Sub Button10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.Click
        If LblMobkasNoSPK.Text = "" Then
            'Mytxtsql = "INSERT INTO TRXN_SPK(" & "SPK_No,SPK_Tanggal,SPK_CdCustomer," & "SPK_Nama1,SPK_Nama2,SPK_FHP2,SPK_Alamat,SPK_Kota,SPK_Kodepos,SPK_Phone,SPK_Agama,SPK_TglLahir,SPK_NPWP,SPK_PKP,SPK_FHP,SPK_FEmail,SPK_PINBB," & "SPK_NoRangka,SPK_CdType,SPK_CdWarna,SPK_Tahun,SPK_Road," & "SPK_STSPPN,SPK_STSFPAJAK,SPK_NOFPAJAK,SPK_TGLFPAJAK,SPK_Keterangan," & "SPK_Piutang,SPK_CdLease,SPK_NOVCRDISC,SPK_Potongan,SPK_HrgJadi,SPK_HrgDP," & "SPK_HrgADM,SPK_HrgAngsur,SPK_HrgASR,SPK_Hari," & "SPK_CdSales,SPK_CdSSales,SPK_Direct,SPK_TGLSPK,SPK_TGLURT,SPK_MVoucher,SPK_KdRef) VALUES ('"
            'Mytxtsql = Mytxtsql & txtnospk.Text & "',GETDATE(),'" & TxtCdCust.Text & "','" & TxtPetik((TxtNama.Text)) & "','" & TxtPetik((TxtNmSTNK.Text)) & "','" & TxtSTNKNoHP.Text & "','" & TxtPetik((TxtAlamat.Text)) & "','" & TxtPetik((TxtKota.Text)) & "','" & TxtPetik((TxtKodePos.Text)) & "','" & TxtPetik((TxtPhone.Text)) & "','" & Val(CStr(CboAgama.SelectedIndex)) + 1 & "','" & DTPTglLahir.Value & "','" & TxtPetik((TxtNPWP.Text)) & "','" & IIf(CboPKP.SelectedIndex = 0, "P", "N") & "','" & TxtNoHP.Text & "','" & TxtEmail.Text & "','" & TxtPinBB.Text & "','" & TxtNoRangka.Text & "','" & TxtCdType.Text & "','" & TxtCdWarna.Text & "','" & TxtPetik((TxtTahun.Text)) & "','" & IIf(OptionOn.Checked = True, "N", "F") & "','" & IIf(CboPPN.SelectedIndex = 0, "B", "K") & "','" & IIf(CboPajak.SelectedIndex = 0, "Y", "N") & "','" & TxtPetik((TxtNoFStd.Text)) & "'," & IIf(TxtNoFStd.Text = "", "NULL", FieldTgl((DTglFPajak.Value))) & ",'" & TxtPetik((TxtKeterangan.Text)) & "'," & ndb((TxtHarga.Text)) & ",'" & TxtCdLease.Text & "','" & TxtPetik((TxtNoSlipD.Text)) & "'," & ndb((TxtDisc.Text)) & "," & ndb((TxtBBN.Text)) & "," & ndb((TxtDP.Text)) & "," & nLg((TxtTotSubsidi.Text)) & ",0," & nLg((txtAsuransi.Text)) & "," & ndb((TxtHari.Text)) & ",'" & TxtCdSales.Text & "','" & TxtCdSSales.Text & "','" & CboDirect.SelectedIndex & "'," & FieldTgl(DTglSPKKERTAS.Value) & ",GETDATE()," & ndb((TxtTotVoucher.Text)) & ",'" & CboRefer.SelectedIndex & "')"

        End If
    End Sub

    Protected Sub ButtonAdmin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAdmin.Click
        If CheckBoxUpdateSPK.Checked = True Then
            Call UpdateData_Tabel_SPK(CheckBoxUpdateSPK.Text)
            LblStatusAkhir.Text = ""
        End If
        If CheckBoxUpdateSPK1.Checked = True Then
            Call UpdateData_Tabel_SPK(CheckBoxUpdateSPK1.Text)
        End If
        If CheckBoxUpdateSPK2.Checked = True Then
            Call UpdateData_Tabel_SPK(CheckBoxUpdateSPK2.Text)
        End If
    End Sub

    Protected Sub Button12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button12.Click
        If CheckBoxUpdateAss.Checked = True Then
            Call UpdateData_Tabel_SPK(CheckBoxUpdateAss.Text)
        End If
        If CheckBoxUpdateAss1.Checked = True Then
            Call UpdateData_Tabel_SPK(CheckBoxUpdateAss1.Text)
        End If
        If CheckBoxUpdateAss2.Checked = True Then
            Call UpdateData_Tabel_SPK(CheckBoxUpdateAss2.Text)
        End If
    End Sub


End Class

