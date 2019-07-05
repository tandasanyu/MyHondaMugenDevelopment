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

'1. Cari
'2. Request Stock
'3' Ambil Rangka Stock
'4' Ambil Kirim Cross sell

'CREATE TABLE [dbo].[TRXN_SPKGR]('
'	[SPKGR_Cabang] [nvarchar](3) NULL,
'	[SPKGR_No] [nvarchar](6) NULL,
'	[SPKGR_User] [nvarchar](30) NULL,
'	[SPKGR_STATUS] [nvarchar](2) NULL,
'	[SPKGR_Catatan] [nvarchar](200) NULL,
'	[SPKGR_TglWarning] [smalldatetime] NULL
') ON [PRIMARY]



Partial Class Form05Keluhan
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader
    Public MyRecReadB As OleDbDataReader
    Public MyRecReadC As OleDbDataReader
    Public MyRecReadD As OleDbDataReader
    Public mRk1, mRk2, mRk3, mRk4, mRk5, mRk6, mRk7, mRk8, mRk9, mRk0, mRk11, mRkT As String
    Dim MySTRsql1 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If
        lblAkses.Visible = False
        If LblUserName.Text = "" Then
            Dim x As String
            Dim mFound As Byte = 0
            x = DirectCast(Session("MainContent"), String)
            LblUserName.Text = UCase(x.ToString)
            MultiView1a.ActiveViewIndex = -1
            lblAkses.Visible = False
            If Left(LblUserName.Text, 3) = "112" Or Left(LblUserName.Text, 3) = "128" Then
                mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYH,DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(SECURITYH_USER)=RTRIM(USER_NAMA) AND RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & Left(LblUserName.Text, 3) & "' AND SECURITYH_NOIDSALES='" & Right(LblUserName.Text, Len(LblUserName.Text) - 3) & "' AND USER_TIPE='WA' AND AKSES_MENU='0107'")
                If mFound = 1 Then
                    lblArea1.Text = Left(LblUserName.Text, 3)
                    lblArea2.Text = Left(LblUserName.Text, 3)
                End If
            Else
                mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserName.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0107'")
            End If
            If mFound = 1 Then
                MultiView1.ActiveViewIndex = 0
                If Mid(lblAkses.Text, 1, 1) <> "1" Then
                    BtnOrder.Visible = False
                Else
                    MultiView1a.ActiveViewIndex = 0
                    lvSummaryUnit.DataBind()
                End If
                If Mid(lblAkses.Text, 2, 1) = "1" Then
                    MultiView1a.ActiveViewIndex = 1
                    LblLokasi.Text = "%"
                    LblGroup.Text = "%"
                    LblTipeKode.Text = "%"
                    LblKelompokTabel.Text = "C"
                    LvStokDetail.DataBind()
                End If
                If Mid(lblAkses.Text, 3, 1) <> "1" Then
                    MultiView1a.ActiveViewIndex = 2
                End If
                LblKelompokTabel.Text = "C"

            Else
                MultiView1.ActiveViewIndex = -1
                MultiView1a.ActiveViewIndex = -1
                Call Msg_err("TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI")
            End If
        End If
        Call Msg_err("")
    End Sub

    Sub Msg_err(ByVal mTest As String)
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




    Protected Sub lvBerita_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvStokDetail.SelectedIndexChanged
        'Call GetData_Tabel_KELUH("")
    End Sub


    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai) Or String.IsNullOrEmpty(nilai), "", nilai)
ErrHand:
    End Function

    Protected Sub BtnOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOrder.Click
        MultiView1a.ActiveViewIndex = 0
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        MultiView1a.ActiveViewIndex = 1
        LblLokasi.Text = "%"
        LblGroup.Text = "%"
        LblTipeKode.Text = "%"
        LblKelompokTabel.Text = "C"
    End Sub


    Protected Sub LvSummaryUnit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSummaryUnit.SelectedIndexChanged
        Dim mKode As String = (lvSummaryUnit.DataKeys(lvSummaryUnit.SelectedIndex).Value.ToString)
        LblLokasi.Text = Mid(mKode, 1, 3)
        LblGroup.Text = Mid(mKode, 5, 3)
        LblTipeKode.Text = Mid(mKode, 9, 7)
        If InStr(LblTipeKode.Text, "99999") <> 0 Then
            LblTipeKode.Text = "%"
        End If
        LblKelompokTabel.Text = "%"
        LvStokDetail.DataBind()
        MultiView1a.ActiveViewIndex = 1

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        'If Mid(lblAkses.Text, 3, 1) <> "1" Then
        'Call Msg_err("Tidak diijinkan mengganti Alokasi")
        'Else
        MultiView1a.ActiveViewIndex = 2
        'End If
    End Sub


    Function nLg(ByRef nilai As Object) As Double
        On Error GoTo ErrHand
        nLg = 0
        If IsNumeric(nilai) Then nLg = Val(nilai) '10
ErrHand:
    End Function

    Function DtFrSQL(ByRef mNilai As Object) As String
        DtFrSQL = "NULL"
        Try
            If IsDate(mNilai) Then
                DtFrSQL = "'" & Format(CDate(mNilai), "yyyy-MM-dd HH:MM:ss") & "'"
            End If
        Catch ex As Exception

        End Try
    End Function





    Function SendEmailProces(ByRef mEmailTo As Object, ByRef mJudul As Object, ByRef mFile As Object, ByRef mPath As Object, ByRef mSsage As Object) As Byte
        Dim strFrom As String = "hmugen1991@gmail.com"
        Try

            Using mm As New MailMessage(strFrom, mEmailTo)
                mm.Subject = mJudul
                mm.Body = mSsage
                mm.IsBodyHtml = False
                'mm.Body = "<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div>" & _
                '          "<div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'>" & _
                '          "<div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Anda memiliki sebuah permintaan persetujuan " + mSsage + " <br/>" & _
                '          "<span style='color:blue;font-size:8pt;'></span>" & _
                '          "</div>" & _
                '          "<br/><center><a href='http://office.hondamugen.co.id:8084/Login.aspx?ReturnUrl=%2fdefault.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk melakukan persetujuan</a></center>" & _
                '          "<br/><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center>" & _
                '          "<br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center>" & _
                '          "<br/><br/>" & _
                '          "<br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong>" & _
                '          "<br/><strong>Honda Mugen Group</strong>" & _
                '          "<br/><i>PT. Mitrausaha Gentaniaga</i>" & _
                '          "<br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" & _
                '          "<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span>" & _
                '          "<br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" & _
                '          "<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a>" & _
                '          "<br/>" & _
                '          "</div>"
                'mm.IsBodyHtml = True

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


    Protected Sub BtnTukarStok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTukarStok.Click
        MultiViewENTRY.ActiveViewIndex = -1
        MultiView1a.ActiveViewIndex = 3
        LvRequestSTok.DataBind()
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
                If Len(lblArea1.Text) > 3 Then
                    lblArea1.Text = Mid(nSr(MyRecReadA("AKSES_AREA")), 1, 3)
                    lblArea2.Text = Mid(nSr(MyRecReadA("AKSES_AREA")), 4, 3)
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Function UpdateDatabase_Tabel(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

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
    Function GetDataD_IsiField(ByVal mSqlCommadstring As String, ByVal mpServer As String) As String
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
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
            Call Msg_err(ex.Message)
        End Try
    End Function
    Function GetDataD_00NoFound01Found(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
        mpServer = "MyConnCloudDnet" & mpServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mpServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
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
            Call Msg_err(ex.Message)
        End Try
    End Function


    Sub TblDetailStockView_SelectedIndexChanging(ByVal sender As Object, ByVal e As ListViewSelectEventArgs)
        Dim mErrorAda As String = ""
        Dim item As ListViewItem = CType(LvStokDetail.Items(e.NewSelectedIndex), ListViewItem)
        Dim mKodeTipe As Label = CType(item.FindControl("Lbl_TipeKode"), Label)

        LblTipeKode.Text = nSr(mKodeTipe.Text)
        mKodeTipe = CType(item.FindControl("Lbl_TipeNama"), Label) : LblTipeNama.Text = nSr(mKodeTipe.Text)
        mKodeTipe = CType(item.FindControl("Lbl_Dealer"), Label) : LblLokasi.Text = nSr(mKodeTipe.Text)
        mKodeTipe = CType(item.FindControl("Lbl_Warna"), Label) : LblWarnaNama.Text = nSr(mKodeTipe.Text)
        mKodeTipe = CType(item.FindControl("Lbl_Rangka"), Label) : LblNomorRangka.Text = nSr(mKodeTipe.Text)
        mKodeTipe = CType(item.FindControl("Lbl_TipeGroup"), Label) : LblGroup.Text = nSr(mKodeTipe.Text)
        LblWarnaKode.Text = GetDataD_IsiField("SELECT WARNA_KODE AS IsiField FROM DATA_WARNA WHERE WARNA_INT='" & LblWarnaNama.Text & "'", "")
        TxtPemohonNote.Text = ""
        TxtPemohonSPK.Text = ""
        If LblNomorRangka.Text <> "" Then
            Call DescRangka(LblNomorRangka.Text)
            LblTahun.Text = mRk8
            LblTahunNumerik.Text = IIf(Asc(mRk8) >= 74, (Asc(mRk8) - 56), (Asc(mRk8) - 55))
        End If

        '1 buka  2 Periksa Stock 3 Ambil Stok
        BtnPickupSedia.Visible = true
        BtnPickupReq.Visible = False
        BtnStockReq.Visible = False
        If Mid(lblAkses.Text, 2, 1) = "1" Or InStr(LblUserName.Text, 112) <> 0 Or InStr(LblUserName.Text, 128) <> 0 Then
            BtnPickupSedia.Visible = True
        End If
        If Mid(lblAkses.Text, 3, 1) = "1" Then
            BtnPickupReq.Visible = True
        End If
        
        LblWarningPickup1.Text = ""
        LblWarningPickup2.Text = ""
        TxtPemohonNote.Text = ""
        TxtPemohonSPK.Text = ""
        LblNorangkaTersedia.Text = ""
        If mErrorAda <> "" Then
            Call Msg_err(mErrorAda)
            LblLokasi.Text = "%"
            LblGroup.Text = "%"
            LblTipeKode.Text = "%"
            LblKelompokTabel.Text = "C"
        Else
            MultiViewENTRY.ActiveViewIndex = 0
            MultiView1a.ActiveViewIndex = 3
        End If
    End Sub

    Protected Sub LvRequestSTok_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvRequestSTok.SelectedIndexChanged
        Dim mErrorAda As String = ""
        Dim mKode As String = (LvRequestSTok.DataKeys(LvRequestSTok.SelectedIndex).Value.ToString)
    End Sub

    Protected Sub TblDetailStockView_PagePropertiesChanging(ByVal sender As Object, ByVal e As PagePropertiesChangingEventArgs)
        ' Clears the selection.
        LvStokDetail.SelectedIndex = -1
    End Sub



    Function ValidasiNospkAsal() As Byte
        ValidasiNospkAsal = 0
        Dim mServer As String = "MyConnCloudDnet" & IIf(LblLokasi.Text = "112", "128", "112")
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        LblWarningPickup1.Text = ""
        LblWarningPickup2.Text = ""
        Dim mSqlCommadstring As String = "SELECT SPK_NO,SPK_NAMA1,SPK_Direct,SPK_TGLDO,SPK_NORANGKA,SPK_CDLEASE,SPK_CdType,SPK_CdWarna,SPK_TAHUN," & _
                                         "(SELECT LEASE_STATUS FROM DATA_LEASE WHERE LEASE_KODE=SPK_CDLEASE) as mStatus_Lease," & _
                                         "(SELECT SUM(ISNULL(ARTRAN_JUMLAH,0)) FROM TRXN_ARTRAN WHERE ARTRAN_NOSPK=SPK_NO AND ISNULL(ARTRAN_NOWO,'')='') as mJumlah_Uang," & _
                                         "(SELECT SPKCANCEL_ALASAN FROM TRXN_SPKCANCEL WHERE SPKCANCEL_NO = SPK_NO) AS CancelAlasan " & _
                                         "FROM TRXN_SPK WHERE SPK_NO='" & TxtPemohonSPK.Text & "'"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                Dim mTahunRangka As String = ""
                While MyRecReadA.Read()
                    If nSr(MyRecReadA("SPK_TGLDO")) <> "" Then
                        LblWarningPickup1.Text = LblWarningPickup1.Text & "SPK INI SUDAH DO "
                    End If
                    If nSr(MyRecReadA("SPK_NORANGKA")) <> "" Then
                        LblWarningPickup1.Text = LblWarningPickup1.Text & "SPK INI SUDAH ADA NOMOR RANGKANYA (" & nSr(MyRecReadA("SPK_NORANGKA")) & ")"
                    End If
                    If nSr(MyRecReadA("SPK_CDLEASE")) = "K000" Or nSr(MyRecReadA("SPK_CDLEASE")) = "" Then
                        LblWarningPickup1.Text = LblWarningPickup1.Text & "LEASING BELUM ADA (" & nSr(MyRecReadA("SPK_CDLEASE")) & ")"
                    End If
                    If nSr(MyRecReadA("SPK_CdType")) <> LblTipeKode.Text Then
                        LblWarningPickup1.Text = LblWarningPickup1.Text & "KODE TIPE BERBEDA (" & nSr(MyRecReadA("SPK_CdType")) & ")"
                    End If
                    If nSr(MyRecReadA("SPK_CdWarna")) <> LblWarnaKode.Text Then
                        LblWarningPickup1.Text = LblWarningPickup1.Text & "KODE WARNA BERBEDA (" & nSr(MyRecReadA("SPK_CdWarna")) & ")"
                    End If
                    If nLg(MyRecReadA("mJumlah_Uang")) = 0 Then
                        If Not ((InStr(nSr(MyRecReadA("SPK_NAMA1")), "HONDA") <> 0 And nSr(MyRecReadA("SPK_Direct")) = "4") Or nSr(MyRecReadA("mStatus_Lease")) = "3") Then
                            If GetDataD_00NoFound01Found("SELECT * FROM TRXN_SPKD  WHERE SPKD_NO = '" & TxtPemohonSPK.Text & "' AND SPKD_NAMA like '%NO_SPK_RETAIL%' AND SPKD_NILAI like 'D%'", IIf(LblLokasi.Text = "112", "128", "112")) = 1 Then
                                LblWarningPickup1.Text = LblWarningPickup1.Text & "JUMLAH UANG MASUK NOL "
                            End If
                        End If
                    End If
                    If nSr(MyRecReadA("CancelAlasan")) <> "" Then
                        LblWarningPickup1.Text = LblWarningPickup1.Text & "SUDAH DIBATALKAN (ALASAN " & nSr(MyRecReadA("CancelAlasan")) & ")"
                    End If

                    mTahunRangka = nSr(MyRecReadA("SPK_TAHUN"))

                    If (Asc(Mid(LblNomorRangka.Text, 10, 1)) >= 74 And Val(mTahunRangka) <> (Asc(Mid(LblNomorRangka.Text, 10, 1)) - 56)) Or _
                       (Asc(Mid(LblNomorRangka.Text, 10, 1)) < 74 And Val(mTahunRangka) <> (Asc(Mid(LblNomorRangka.Text, 10, 1)) - 55)) Then
                        LblWarningPickup1.Text = LblWarningPickup1.Text & "TAHUN SPK BERBEDA DENGAN TAHUN RANGKA (" & mTahunRangka & " <> )"
                    End If

                    mSqlCommadstring = "SELECT STOCKF_NORANGKA as IsiField FROM TRXN_STOCKFAKTUR WHERE STOCKF_NOSPK ='" & TxtPemohonSPK.Text & "' AND STOCKF_BATALHMS IS NULL"
                    mTahunRangka = GetDataD_IsiField(mSqlCommadstring, IIf(LblLokasi.Text = "112", "128", "112"))
                    If mTahunRangka <> "" Then
                        LblWarningPickup1.Text = LblWarningPickup1.Text & "SEDANG DI FAKTUR H3S RANGKA (" & mTahunRangka & " <> )"
                    End If

                End While
            Else
                LblWarningPickup2.Text = "SPK TERSEBUT BELUM ADA"
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
            If LblWarningPickup1.Text = "" And LblWarningPickup2.Text = "" Then
                ValidasiNospkAsal = 1
            End If
        Catch ex As Exception
            Call Msg_err(ex.Message)
            LblWarningPickup2.Text = ex.Message
        End Try
    End Function


    Function Proses_SPK_Pickup_Rangka_To_Urut_TGLSPKHDIARY(ByVal mPlus As Byte, ByVal mKodeProses As String) As String
        'Tidak di proses : SPK_AVoucher=99->sdh DO 98->Batal SPK 97/96->Sdh Lewat Sebulan 
        '                  SPK_AVoucher=89 : Sudah SPKR Update 3 tahun 2017
        LblWarningPickup1.Text = ""
        LblWarningPickup2.Text = "SEDANG DI RANGKA OLEH :"
        Proses_SPK_Pickup_Rangka_To_Urut_TGLSPKHDIARY = ""
        Try
            'Periksa Lihat TTK tahun 2016 ke atas

            Dim MyFilter As String = ""
            If LblLokasi.Text = "128" Then
                MyFilter = MyFilter & " AND STOCK_CdLokasi <> 'G001' "
            End If
            '            "ORDER BY STOCK_CDTYPE,STOCK_CDWARNA,STOCK_TglTTK,STOCK_NORANGKA"
            'Januari Berdasarkan Tgl DO ImorA =STOCK_TglDOImoraHpm

            MySTRsql1 = "UPDATE TRXN_SPK SET SPK_AVoucher=99 WHERE ISNULL(SPK_AVoucher,0) <= 20 AND SPK_TGLDO IS NOT NULL"
            Call UpdateDatabase_Tabel(MySTRsql1, LblLokasi.Text)

            MySTRsql1 = "UPDATE TRXN_SPK SET SPK_AVoucher=98 WHERE ISNULL(SPK_AVoucher,0) <= 20 AND " & _
                        "(SELECT SPKCANCEL_NO FROM TRXN_SPKCANCEL WHERE SPKCANCEL_NO = SPK_NO) IS NOT NULL"
            Call UpdateDatabase_Tabel(MySTRsql1, LblLokasi.Text)

            MySTRsql1 = "UPDATE TRXN_SPK SET SPK_NORANGKA=''  WHERE " & _
                        "ISNULL(SPK_NORANGKA,'')<>'' AND SPK_TglDO IS NULL AND " & _
                        "SPK_CDTYPE='" & LblTipeKode.Text & "' AND SPK_CDWARNA='" & LblWarnaKode.Text & "' AND SUBSTRING(SPK_NORANGKA,10,1)='" & LblTahun.Text & "' AND " & _
                        "(SELECT COUNT(SPKR_NORANGKA) FROM TRXN_SPKR WHERE ISNULL(SPKR_DEALERST,'') = 'P' AND SPKR_NORANGKA=SPK_NORANGKA GROUP BY SPKR_NORANGKA) IS NULL"
            If UpdateDatabase_Tabel(MySTRsql1, LblLokasi.Text) = 1 Then
                MySTRsql1 = "SELECT *,GETDATE() as mDateNow,STOCK_DPP,STOCK_PPN," & _
                            "(SELECT STOCKF_NOSPK FROM TRXN_STOCKFAKTUR WHERE STOCKF_NORANGKA=STOCK_NORANGKA AND STOCKF_BATALHMS IS NULL) as mNospkFaktur " & _
                            "FROM TRXN_STOCK LEFT OUTER JOIN TRXN_SPK ON TRXN_STOCK.STOCK_NoRangka = TRXN_SPK.SPK_NoRangka WHERE " & _
                            "NOT(STOCK_NoRangka='' OR STOCK_NoRangka='BLANK') AND  (SPK_NODO IS NULL OR SPK_NODO='') AND (SPK_NORANGKA IS NULL OR SPK_NORANGKA='') AND " & _
                            "ISNULL((SELECT COUNT(DBNOTAINT_NORANGKA) as mJmlDBNOTA FROM TRXN_DBNOTAINTERNAL WHERE DBNOTAINT_NORANGKA = STOCK_NoRangka),0)=0 AND " & _
                            "STOCK_CDTYPE='" & LblTipeKode.Text & "' AND STOCK_CDWARNA='" & LblWarnaKode.Text & "' AND SUBSTRING(STOCK_NoRangka,10,1)='" & LblTahun.Text & "' " & _
                            MyFilter & _
                            "ORDER BY STOCK_CDTYPE,STOCK_CDWARNA,STOCK_TglDOImoraHpm,STOCK_NORANGKA"
                Call GetDataA_ListTabelStock(MySTRsql1, mPlus, LblLokasi.Text)

                MySTRsql1 = "DELETE FROM DATA_PARAMETER WHERE PARAMETER_NAMA='PICKUPRANGKA'"
                Call UpdateDatabase_Tabel(MySTRsql1, LblLokasi.Text)
                MySTRsql1 = "INSERT INTO DATA_PARAMETER(PARAMETER_NAMA,PARAMETER_NILAI) VALUES ('PICKUPRANGKA','" & mKodeProses & "')"
                Call UpdateDatabase_Tabel(MySTRsql1, LblLokasi.Text)
            End If
        Catch error_t As Exception
            Call Msg_err(error_t.Message)
        End Try
    End Function

    Function GetDataA_ListTabelStock(ByVal mSqlCommadstring As String, ByVal mPlus As String, ByVal mServer As String) As String
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim mJumlahStok As Integer = 0
        Dim mJumlahStokFiktif As Integer = 0
        Dim mJumlahStokSPK As Integer = 0
        Dim mJumlahStokBlok As Integer = 0


        Call Msg_err("")
        GetDataA_ListTabelStock = ""

        Dim mTidakBoleh As Byte
        Dim mSudahDiPickup As Byte



        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    'SPK_TGLSPK  = Tanggal Create SPK H-Diary
                    'SPK_TGLURT  = Tanggal Approved SM -------> Berdasarkan urut Approved
                    'SPK_Tanggal = Tanggal Input 

                    mTidakBoleh = 0

                    If nSr(MyRecReadA("STOCK_NoIndent")) = "1" Then 'Unit retun atau tidak dijual
                        mTidakBoleh = 1 : mJumlahStokBlok = mJumlahStokBlok + 1
                    ElseIf nSr(MyRecReadA("mNospkFaktur")) <> "" Then
                        mTidakBoleh = 1 : mJumlahStokFiktif = mJumlahStokFiktif + 1
                    ElseIf LblNorangkaTersedia.Text <> "" Then
                        mTidakBoleh = 1 : If mJumlahStokSPK = 0 Then mJumlahStokSPK = mJumlahStok

                    End If
                    mJumlahStok = mJumlahStok + 1

                    If mTidakBoleh = 0 Then
                        Call DescRangka(nSr(MyRecReadA("STOCK_NORANGKA")))
                        mSudahDiPickup = 0
                        If mSudahDiPickup = 0 Then
                            'Rubah Pencariannnya 2018
                            '            "SPK_TGLRANGKA IS NULL) AND (SPK_NORANGKA IS NULL OR SPK_NORANGKA='') AND " & _
                            'Menjadi
                            '(SPK_TglDO IS NULL) AND " & _
                            'UMUR RANGKA KREDIT DIATAS = 66
                            MySTRsql1 = "SELECT *,GETDATE() as mDateNow FROM TRXN_SPK LEFT OUTER JOIN TRXN_SPKCANCEL ON TRXN_SPK.SPK_NO = TRXN_SPKCANCEL.SPKCANCEL_NO WHERE " & _
                                        "(SPK_TglDO IS NULL) AND (SPKCANCEL_NO IS NULL) AND " & _
                                        "DATEDIFF(DAY,'2017-03-01 00:00:00',SPK_Tanggal) > =0  AND ISNULL(SPK_NORANGKA,'')='' AND " & _
                                        "SPK_CDTYPE='" & nSr(MyRecReadA("STOCK_CDTYPE")) & "' AND SPK_CDWARNA='" & nSr(MyRecReadA("STOCK_CDWARNA")) & "' AND SPK_TAHUN='" & LblTahunNumerik.Text & "' AND " & _
                                        "( (ISNULL(SPK_UMRRANGKA,0) < 7 AND SPK_CDLEASE='C001') OR (ISNULL(SPK_UMRRANGKA,0) < 14  AND SPK_CDLEASE<>'C001') ) AND " & _
                                        "ISNULL(SPK_AVoucher,0) <= 20 " & _
                                        "ORDER BY SPK_TGLURT"
                            LblNorangkaTersedia.Text = GetDataB_ListTabelSPK(MySTRsql1, nSr(MyRecReadA("STOCK_NORANGKA")), mPlus, nSr(MyRecReadA("mDateNow")), LblLokasi.Text)
                            LblNorangkaTersediaPPN.Text = nLg(MyRecReadA("STOCK_PPN"))
                            LblNorangkaTersediaDPP.Text = nLg(MyRecReadA("STOCK_DPP"))
                        End If
                    End If
                End While
            Else
                GetDataA_ListTabelStock = ""
            End If
            LblWarningPickup1.Text = "STOK YANG TERSEDIA " & mJumlahStok & " JUMLAH FAKTUR FIKTIF " & mJumlahStokFiktif & " URUTAN KE " & mJumlahStokSPK
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function GetDataB_ListTabelSPK(ByVal mSqlCommadstring As String, ByVal mRangka As String, ByVal mPlus As String, ByVal mTglNow As String, ByVal mServer As String) As String
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        GetDataB_ListTabelSPK = mRangka

        Dim mJumlahHari As Integer

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadB = cmd.ExecuteReader()
            If MyRecReadB.HasRows = True Then
                While MyRecReadB.Read() And GetDataB_ListTabelSPK <> ""
                    mJumlahHari = Input_dataC_STOCK_History(LblLokasi.Text, nSr(MyRecReadB("SPK_NO")), nSr(mRangka), "", nSr(MyRecReadB("mDateNow")), mPlus, "", "", nSr(MyRecReadB("SPK_CDLEASE")), "")
                    If mJumlahHari <> -1 Then
                        LblWarningPickup2.Text = LblWarningPickup2.Text & "," & nSr(MyRecReadB("SPK_NO"))
                        MySTRsql1 = "UPDATE TRXN_SPK SET SPK_TGLRANGKA=GETDATE(),SPK_NORANGKA='" & nSr(mRangka) & "',SPK_UMRRANGKA=" & IIf(mJumlahHari > 100, 100, mJumlahHari) & " WHERE SPK_NO='" & nSr(MyRecReadB("SPK_NO")) & "'"
                        Call UpdateDatabase_Tabel(MySTRsql1, LblLokasi.Text)
                        GetDataB_ListTabelSPK = ""
                    End If
                End While
            End If
            MyRecReadB.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
            GetDataB_ListTabelSPK = ""
        End Try
    End Function

    Function Input_dataC_STOCK_History(ByVal mServer As String, ByVal mSPK As String, ByVal mNorangka As String, ByVal mUPDATE As String, ByVal mTglDate As String, ByVal mTambah As Byte, ByVal mMugenDlr As String, ByVal mMugenTipe As String, ByVal mMugenWarna As String, ByVal mMugenST As String) As Integer
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        Input_dataC_STOCK_History = -1
        mTglDate = DateAdd(DateInterval.Day, mTambah, CDate(mTglDate))
        mTglDate = InputDT("", "", "", "00", "00", "00", CDate(mTglDate))
        MySTRsql1 = "DELETE FROM TRXN_SPKR WHERE SPKR_NOSPK='" & mSPK & "' AND DATEDIFF(DAY,SPKR_TANGGAL," & DtInSQL(CDate(mTglDate)) & ")=0"
        Input_dataC_STOCK_History = UpdateDatabase_Tabel(MySTRsql1, LblLokasi.Text)

        MySTRsql1 = "INSERT INTO TRXN_SPKR (SPKR_NOSPK,SPKR_NORANGKA,SPKR_TANGGAL,SPKR_STATUS,SPKR_DEALER,SPKR_CDTYPE,SPKR_CDWARNA,SPKR_DEALERST,SPKR_PROSES) VALUES ('" & mSPK & "','" & mNorangka & "'," & DtInSQL(CDate(mTglDate)) & ",'','" & mMugenDlr & "','" & mMugenTipe & "','" & mMugenWarna & "','" & mMugenST & "',GETDATE())"
        Input_dataC_STOCK_History = UpdateDatabase_Tabel(MySTRsql1, LblLokasi.Text)
        Input_dataC_STOCK_History = 0

        MySTRsql1 = "SELECT * FROM TRXN_SPKR WHERE SPKR_NOSPK='" & mSPK & "' ORDER BY SPKR_TANGGAL"
        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadC = cmd.ExecuteReader()
            If MyRecReadC.HasRows = True Then
                While MyRecReadC.Read()
                    Input_dataC_STOCK_History = Input_dataC_STOCK_History + GetTotalWorkingDays(nSr(MyRecReadC("SPKR_TANGGAL")), nSr(MyRecReadC("SPKR_TANGGAL")))
                End While
            End If
            MyRecReadC.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function InputDT(ByVal mYr As String, ByVal mMt As String, ByVal mDy As String, ByVal mHh As String, ByVal mMm As String, ByVal mSs As String, ByVal mDt As String) As Date
        Try

            If mDt <> "" And mYr = "" Then mYr = CStr(Year(CDate(mDt)))
            If mDt <> "" And mMt = "" Then mMt = CStr(Month(CDate(mDt)))
            If mDt <> "" And mDy = "" Then mDy = CStr(Microsoft.VisualBasic.Day(CDate(mDt)))
            If mDt <> "" And mHh = "" Then mHh = CStr(Hour(CDate(mDt)))
            If mDt <> "" And mMm = "" Then mMm = CStr(Minute(CDate(mDt)))
            If mDt <> "" And mSs = "" Then mSs = CStr(Second(CDate(mDt)))
            mHh = IIf(mHh = "", "00", mHh)
            mMm = IIf(mMm = "", "00", mHh)
            mSs = IIf(mSs = "", "00", mHh)
            InputDT = New DateTime(mYr, mMt, mDy, mHh, mMm, mSs)
        Catch ex As Exception

        End Try
    End Function

    Function GetTotalWorkingDays(ByVal mDatestart As String, ByVal mDateEnd As String) As Integer
        GetTotalWorkingDays = 0

        Dim mStart As DateTime = InputDT("", "", "", "00", "00", "00", CDate(mDatestart))
        Dim mEnd As DateTime = InputDT("", "", "", "00", "00", "00", CDate(mDateEnd))
        While mStart <= mEnd
            If Not (mStart.DayOfWeek = DayOfWeek.Saturday Or mStart.DayOfWeek <= DayOfWeek.Sunday Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-01-01 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-02-16 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-03-17 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-03-30 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-04-14 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-05-01 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-05-10 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-05-29 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-06-01 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-06-15 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-06-16 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-08-17 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-08-22 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-09-11 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-11-20 00:00:00")) = 0 Or _
                    DateDiff(DateInterval.Day, CDate(mStart), CDate("2018-12-25 00:00:00")) = 0) Then
                GetTotalWorkingDays = GetTotalWorkingDays + 1
            End If
            mStart = mStart.AddDays(1)
        End While
    End Function

    Function DtInSQL(ByRef nilai As Object) As String
        DtInSQL = "NULL"

        If Not IsDBNull(nilai) Then
            DtInSQL = "'" & Format(nilai, "yyyy-MM-dd HH:mm:ss") & "'"
        End If
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



    Function Data_Stock_to_WebServer(ByVal mStokLokasi As String) As Byte
        Dim mCatatan As String = ""
        Dim mKodeThn As String = ""
        Dim mwarna As String = ""
        Dim mTipe As String = ""
        Dim mNospk As String = ""
        Dim mAntrianTipeWarna As String = ""
        Dim mAntrianJumlah As Byte = 0
        Data_Stock_to_WebServer = 0

        Try

            MySTRsql1 = "DELETE FROM DATA_TYPEPERFORM WHERE TYPEP_MUGEN='" & mStokLokasi & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")


            'Hapus Detail Stok temporary di WEB
            MySTRsql1 = "DELETE FROM DATA_TYPESTOCK WHERE TYPESTOCK_CDDEALER='" & mStokLokasi & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            'Perbaiki data Stok Cancel yang dicabang
            MySTRsql1 = "UPDATE TRXN_STOCK SET STOCK_NORANGKA='BLANK' WHERE " & _
                        "(SELECT STOCKCANCEL_No from TRXN_STOCKCANCEL  where STOCKCANCEL_No=STOCK_NoTTK) IS NOT NULL AND STOCK_NoRangka <>'BLANK'"
            Call UpdateDatabase_Tabel(MySTRsql1, mStokLokasi)

            'Update nama stok yang sudah difaktur fiktif di H3S (Biasanya akhir bulan)
            MySTRsql1 = "UPDATE TRXN_STOCKFAKTUR SET STOCKF_NOSPK='FIKTIF' WHERE STOCKF_NOSPK=''"
            Call UpdateDatabase_Tabel(MySTRsql1, mStokLokasi)

            'Ambil data unit stok di masing masing cabang : TYPESTOCK_UPDATE="" ==================================================
            Call DataStockA(mStokLokasi, mStokLokasi)

            '===========================================================
            'Ambil Stok sudah DN tapi belum ada Stok ada 2 langkah  : TYPESTOCK_UPDATE="D"
            '1A. Rapihkan data DN yang sudah ada stok

            Call DataStockB1(mStokLokasi, mStokLokasi)

            '1B. Ambil Data DN jika sesuai dengan tipe isi kode tipe standard jika tidak isi 9999998  
            Call DataStockB2(mStokLokasi, mStokLokasi)

            '===========================================================

            'Kolom : DO Non SPJ
            'Stock Runing Stock (Sudah DO Belum Kirim)   : TYPESTOCK_UPDATE="R"
            'STOCK_KIRIMTGLTERIMAI/STOCK_KIRIMTGLTERIMA = Input Kirim Terima
            'STOCK_KirimNo='999999' Input SPJ di showowroo
            'STOCK_KirimTGLMHNI di Warehouse
            'Cari yang sudah SPJ tapi belum Mengajukan SPK (Kalau sudah diakses akan dihapus
            Call DataStockC(mStokLokasi, mStokLokasi)

            '==========================================================================================
            'Hapus saya
            'Hitung Alokasi.1 Yang ada alokasinya  "
            'Dim mStok As Integer = 0
            'Dim mStokBatal As Integer = 0
            'Dim mInputAlokasi As Integer = 0

            MySTRsql1 = "SELECT MAX(ALOKASIHPM_TANGGAL)as IsiField FROM TRXN_TYPEALOKASIHM WHERE ALOKASIHPM_STATUS='C'"
            Dim mTglAlokasi As String = GetDataD_IsiField(MySTRsql1, mStokLokasi)


            'Hitungan Lama Hapus saja
            'If mTglAolkasi <> "" Then
            'MySTRsql1 = "SELECT * FROM TRXN_TYPEALOKASIHM,DATA_TYPE " & _
            '            "WHERE ALOKASIHPM_CDTYPE=TYPE_TYPE AND ALOKASIHPM_STATUS='C' AND ALOKASIHPM_QTYMUGEN<>0 AND YEAR(ALOKASIHPM_TANGGAL)=" & Year(CDate(mTglAolkasi)) & " AND MONTH(ALOKASIHPM_TANGGAL)=" & Month(CDate(mTglAolkasi))
            'If ExecuteSQLServerSales1("",MySTRsql1, 1, 1, 0) = 1 Then
            'Do
            'mAlokasi = nLg(MyRecReadA("ALOKASIHPM_QTYMUGEN"))
            'Call Input_data_STOCK_Detail(nSr(MyRecReadA("ALOKASIHPM_CDTYPE")), nSr(MyRecReadA("ALOKASIHPM_CDWARNA")), "ALOKASI : " & nLg(mAlokasi), "", "", "", MyDealer, "A", "", "", "ALOKASI HPM BLN " & Format(CDate(mTglAolkasi), "MM/yy") & ":" & nLg(MyRecReadA("ALOKASIHPM_QTY")), mAlokasi, mDNET)
            'Loop While MyRecReadA.Read
            'End If : Call TutupTabelSales1(1)
            'End If

            'Ambil Data DO Imora yang belum ada TTK ==================================================
            '   Kolom : DO Imora Intransit
            '   TYPESTOCK_UPDATE = 'S'
            '==========================================================================================

            Call DataStockD(mTglAlokasi, mStokLokasi, mStokLokasi)

            '==========================================================================================
            Call DataStockE(mTglAlokasi, mStokLokasi, mStokLokasi)

            '==========================================================================================

            'Buat Summary
            '           "(TYPESTOCK_UPDATE IS NULL OR TYPESTOCK_UPDATE ='' OR TYPESTOCK_UPDATE ='D') AND " & _

            MySTRsql1 = "INSERT INTO DATA_TYPEPERFORM " & _
                        "SELECT " & _
                        "TYPESTOCK_CDTYPE,0,GETDATE()," & _
                        "0,NULL,0,NULL,0,NULL,0,NULL,0,NULL,0,NULL," & _
                        "0,NULL,0,NULL,0,NULL,0,NULL,0,NULL,0,NULL," & _
                        "TYPESTOCK_CDDEALER,0,TYPE_CdGroup,TYPE_Nama " & _
                        "FROM DATA_TYPESTOCK,DATA_TYPE WHERE " & _
                        "(TYPESTOCK_CDTYPE<>'9999998' AND TYPESTOCK_UPDATE<>'T') AND TYPESTOCK_CDDEALER='" & mStokLokasi & "' AND TYPESTOCK_CDTYPE=TYPE_TYPE " & _
                        "GROUP BY TYPESTOCK_CDDEALER,TYPE_CdGroup,TYPESTOCK_CDTYPE,TYPE_Nama"
            Call UpdateDatabase_Tabel(MySTRsql1, "")
            '            "(TYPESTOCK_CDTYPE<>'9999998') AND TYPESTOCK_CDDEALER='" & MyDealer & "' AND TYPESTOCK_CDTYPE=TYPE_TYPE " & _

            'Biasanya data DN non stok atau DO non Stok
            MySTRsql1 = "INSERT INTO DATA_TYPEPERFORM " & _
                        "SELECT " & _
                        "TYPESTOCK_CDTYPE,0,GETDATE()," & _
                        "0,NULL,0,NULL,0,NULL,0,NULL,0,NULL,0,NULL," & _
                        "0,NULL,0,NULL,0,NULL,0,NULL,0,NULL,0,NULL," & _
                        "TYPESTOCK_CDDEALER,0,'ZZZ',TYPESTOCK_DNTIPE " & _
                        "FROM DATA_TYPESTOCK,DATA_TYPE WHERE " & _
                        "TYPESTOCK_CDTYPE='9999998' AND TYPESTOCK_CDTYPE=TYPE_TYPE AND TYPESTOCK_CDDEALER='" & mStokLokasi & "' " & _
                        "GROUP BY TYPESTOCK_CDDEALER,TYPE_CdGroup,TYPESTOCK_CDTYPE,TYPESTOCK_DNTIPE"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '=========================TYPESTOCK_UPDATE='' =================================================================
            '<Semua>Ambil Stok Real/Admin + Yang Return STock
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_STOCK = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE IS NULL OR TYPESTOCK_UPDATE ='') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_CDTYPE=TYPEP_TYPE  GROUP BY TYPESTOCK_CDTYPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '<Semua>Ambil Stok Yang Return STock
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL11 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE IS NULL OR TYPESTOCK_UPDATE ='') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_CDTYPE=TYPEP_TYPE AND TYPESTOCK_CATATAN='UNIT RETURN' GROUP BY TYPESTOCK_CDTYPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET TYPEP_JUAL11 = NULL " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "' AND TYPEP_JUAL11=0"
            Call UpdateDatabase_Tabel(MySTRsql1, "")
            'Stock Realnya
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET TYPEP_STOCK = TYPEP_STOCK-TYPEP_JUAL11 " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "' AND TYPEP_JUAL11 > 0"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '=========================TYPESTOCK_UPDATE='' =================================================================
            '<Semua> SPK sudah ada rangka belum DO ambil dari data stok
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL01 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE IS NULL OR TYPESTOCK_UPDATE ='') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_CDTYPE=TYPEP_TYPE AND TYPESTOCK_NOSPK<>'' GROUP BY TYPESTOCK_CDTYPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '<Tahun rangka 2016> Ambil Stok Real/Admin
            'MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
            '            "TYPEP_JUAL02 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE IS NULL OR TYPESTOCK_UPDATE ='') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_CDTYPE=TYPEP_TYPE AND SUBSTRING(TYPESTOCK_NORANGKA,10,1)='G' GROUP BY TYPESTOCK_CDTYPE),0) " & _
            '            "WHERE TYPEP_MUGEN='" & mStokLokasi & "'"
            'Call ExecuteSQLServerSales1("",MySTRsql1, 5, 9, 9)

            '=========================TYPESTOCK_UPDATE='' =================================================================
            '<Tahun rangka 2016> Ambil Stok Real/Admin diganti menjadi 2017

            mKodeThn = "H"
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL02 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE IS NULL OR TYPESTOCK_UPDATE ='') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_CDTYPE=TYPEP_TYPE AND " & _
                        "SUBSTRING(TYPESTOCK_NORANGKA,10,1)='" & mKodeThn & "' GROUP BY TYPESTOCK_CDTYPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '<Tahun rangka 2016> SPK sudah ada rangka belum DO ambil dari data stok  diganti menjadi 2017
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL03 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE IS NULL OR TYPESTOCK_UPDATE ='') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_CDTYPE=TYPEP_TYPE AND TYPESTOCK_NOSPK<>'' AND " & _
                        "SUBSTRING(TYPESTOCK_NORANGKA,10,1)='" & mKodeThn & "' GROUP BY TYPESTOCK_CDTYPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '<Tahun rangka 2017> Ambil Stok Real/Admin  diganti menjadi 2018
            mKodeThn = "J"
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL04 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE IS NULL OR TYPESTOCK_UPDATE ='') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_CDTYPE=TYPEP_TYPE AND " & _
                        "SUBSTRING(TYPESTOCK_NORANGKA,10,1)='" & mKodeThn & "' GROUP BY TYPESTOCK_CDTYPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '<Tahun rangka 2017> SPK sudah ada rangka belum DO ambil dari data stok  diganti menjadi 2018
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL05 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE IS NULL OR TYPESTOCK_UPDATE ='') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_CDTYPE=TYPEP_TYPE AND TYPESTOCK_NOSPK<>'' AND " & _
                        "SUBSTRING(TYPESTOCK_NORANGKA,10,1)='" & mKodeThn & "' GROUP BY TYPESTOCK_CDTYPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '=========================TYPESTOCK_UPDATE='' =================================================================
            'Stock yang sudah difaktur fiktif
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL06 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE IS NULL OR TYPESTOCK_UPDATE ='') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_CDTYPE=TYPEP_TYPE AND TYPESTOCK_NOSPKFAKTUR<>'' GROUP BY TYPESTOCK_CDTYPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '=========================TYPESTOCK_UPDATE='R' =================================================================
            'Sudah DO belum SPJ/Kirim
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL07 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE ='R') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_CDTYPE=TYPEP_TYPE GROUP BY TYPESTOCK_CDTYPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '=========================TYPESTOCK_UPDATE='D' =================================================================
            'Sudah DN tapi stok blm terima
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL08 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE ='D') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_CDTYPE=TYPEP_TYPE AND TYPESTOCK_CDTYPE<>'9999998' GROUP BY TYPESTOCK_CDTYPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "' AND TYPEP_TYPE<>'9999998'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL08 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE ='D') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_DNTIPE=TYPEP_NAMA AND TYPESTOCK_CDTYPE='9999998' GROUP BY TYPESTOCK_DNTIPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "' AND TYPEP_TYPE='9999998'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '=========================TYPESTOCK_UPDATE='A' =================================================================
            'Alokasi
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL09 = ISNULL((SELECT SUM(TYPESTOCK_QTY) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE ='A') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_CDTYPE=TYPEP_TYPE GROUP BY TYPESTOCK_CDTYPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '=========================TYPESTOCK_UPDATE='S' =================================================================
            'DO Imora Blm terima
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL10 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE ='S') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_CDTYPE=TYPEP_TYPE AND TYPESTOCK_CDTYPE<>'9999998' GROUP BY TYPESTOCK_CDTYPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "' AND TYPEP_TYPE<>'9999998'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL10 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE ='S') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_DNTIPE=TYPEP_NAMA AND TYPESTOCK_CDTYPE='9999998' GROUP BY TYPESTOCK_DNTIPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "' AND TYPEP_TYPE='9999998'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '=======================Hapus R=Runing Stok ...Yng tdk dihapus 
            ' A=Alokasi, 
            'D=DO imora sdh ada di Finance  (Tipe bisa tidak ada yng tidak ada pakai 99998)
            'S=DO Imora Blm Kirim           (Tipe bisa tidak ada yng tidak ada pakai 99998)

            'Buat Summary Yang Tahun Lalu

            MySTRsql1 = "INSERT INTO DATA_TYPEPERFORM " & _
                        "SELECT " & _
                        "TYPESTOCK_CDTYPE,0,GETDATE()," & _
                        "0,NULL,0,NULL,0,NULL,0,NULL,0,NULL,0,NULL," & _
                        "0,NULL,0,NULL,0,NULL,0,NULL,0,NULL,0,NULL," & _
                        "TYPESTOCK_CDDEALER,0,TYPE_CdGroup,TYPESTOCK_DNTIPE " & _
                        "FROM DATA_TYPESTOCK,DATA_TYPE WHERE " & _
                        "(TYPESTOCK_UPDATE='T') AND TYPESTOCK_CDDEALER='" & mStokLokasi & "' AND TYPESTOCK_CDTYPE=TYPE_TYPE " & _
                        "GROUP BY TYPESTOCK_CDDEALER,TYPE_CdGroup,TYPESTOCK_CDTYPE,TYPESTOCK_DNTIPE"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '<Semua>Ambil Stok Real/Admin + Yang Return STock
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM SET " & _
                        "TYPEP_STOCK = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE ='T') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_DNTIPE=TYPEP_Nama GROUP BY TYPESTOCK_DNTIPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "' AND TYPEP_Nama like '2016%'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            '<Semua>Ambil Stok Yang Return STock
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET " & _
                        "TYPEP_JUAL11 = ISNULL((SELECT COUNT(TYPESTOCK_CDDEALER) FROM DATA_TYPESTOCK WHERE (TYPESTOCK_UPDATE ='T') AND TYPESTOCK_CDDEALER=TYPEP_MUGEN AND TYPESTOCK_DNTIPE=TYPEP_Nama AND TYPESTOCK_CATATAN='UNIT RETURN' GROUP BY TYPESTOCK_DNTIPE),0) " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "' AND TYPEP_Nama like '2016%'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET TYPEP_JUAL11 = NULL " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "' AND TYPEP_JUAL11=0 AND TYPEP_Nama like '2016%'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")
            'Stock Realnya
            MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET TYPEP_STOCK = TYPEP_STOCK-TYPEP_JUAL11 " & _
                        "WHERE TYPEP_MUGEN='" & mStokLokasi & "' AND TYPEP_JUAL11 > 0 AND TYPEP_Nama like '2016%'"
            Call UpdateDatabase_Tabel(MySTRsql1, "")






            MySTRsql1 = "DELETE FROM DATA_TYPESTOCK WHERE TYPESTOCK_CDDEALER='" & mStokLokasi & "' AND (TYPESTOCK_UPDATE='R')"
            Call UpdateDatabase_Tabel(MySTRsql1, "")
            '===========================================





            'If mDNET = "" Then
            'Call TulisDiTabel(4, "Dimulai Prosess Report .. STOK ")
            'Data_Performance_Type_Stock_to_Web = PrintReport_export("EMAILPERFRMSPK02.rpt", MyDealer + "EMSLPFA.XLS", "LAPORAN INSENTIVE" & Trim(MyDealer), "", "EXCEL", MyGFilter1)
            'Data_Performance_Type_Stock_to_Web = PrintReport_export("EMAILPERFRMSPK01.rpt", MyDealer + "EMSLPFB.XLS", "LAPORAN PERFORM SALES " & Trim(MyDealer), "", "EXCEL", MyGFilter1)
            'Call TulisDiTabel(4, "Selesai Prosess Report .. STOK ")
            'End If


            Call Akumlasi_Stock(mStokLokasi, "")
            Call Data_Stock_DBNOTA_to_WebServer(mStokLokasi, "")


            MySTRsql1 = "UPDATE DATA_TYPESTOCK SET TYPESTOCK_UPDATE='C' WHERE TYPESTOCK_CDDEALER='" & mStokLokasi & "' AND (TYPESTOCK_UPDATE='')"
            Call UpdateDatabase_Tabel(MySTRsql1, "")


            Dim mThn As String = ""
            If Year(Now) >= 2018 Then
                mThn = Chr(Year(Now) - 1944)
            Else
                mThn = Chr(Year(Now) - 1945)
            End If

            Call DataStockF(mStokLokasi, mStokLokasi)


            MySTRsql1 = "UPDATE DATA_TYPESTOCK SET TYPESTOCK_UPDATE='C' WHERE TYPESTOCK_CDDEALER='" & mStokLokasi & "' AND (TYPESTOCK_UPDATE='T')"
            Call UpdateDatabase_Tabel(MySTRsql1, "")

            Data_Stock_to_WebServer = 1
        Catch ex As Exception
            Data_Stock_to_WebServer = 0
        End Try
    End Function


    Function DataStockA(ByVal mLokasi As String, ByVal mServer As String) As Integer
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        DataStockA = -1

        'Persyaratan khusus untuk stok puri
        Dim mCatatan As String = ""
        Dim mAntrianTipeWarna As String = ""
        Dim mAntrianJumlah As Byte = 0
        Dim mNospk As String = ""
        Dim mwarna As String = ""
        Dim mTipe As String = ""


        Dim MyGFilter1 As String = ""
        If mLokasi = "128" Then
            MyGFilter1 = " AND STOCK_CdLokasi <> 'G001'"
        End If
        'Ambil data unit stok di masing masing cabang : TYPESTOCK_UPDATE="" ==================================================
        mAntrianTipeWarna = "" : mAntrianJumlah = 0
        MySTRsql1 = "SELECT *," & _
                    "(SELECT STOCKF_NOSPK FROM TRXN_STOCKFAKTUR WHERE STOCKF_NORANGKA=STOCK_NORANGKA) as mNospkFakturFiktif," & _
                    "(SELECT STOCKF_BATALHMS FROM TRXN_STOCKFAKTUR WHERE STOCKF_NORANGKA=STOCK_NORANGKA) as mBatalFakturFiktif " & _
                    "FROM TRXN_STOCK LEFT OUTER JOIN TRXN_SPK ON TRXN_STOCK.STOCK_NoRangka = TRXN_SPK.SPK_NoRangka WHERE " & _
                    "NOT(STOCK_NoRangka='' OR STOCK_NoRangka='BLANK') AND  (SPK_NODO IS NULL OR SPK_NODO='') AND " & _
                    "(SELECT COUNT(DBNOTAINT_NORANGKA) as mJmlDBNOTA FROM TRXN_DBNOTAINTERNAL WHERE DBNOTAINT_NORANGKA = STOCK_NoRangka)=0  " & MyGFilter1 & _
                    "ORDER BY STOCK_CDTYPE,STOCK_CDWARNA,STOCK_TglDOImoraHpm,STOCK_NORANGKA"
        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()

                    mNospk = nSr(MyRecReadA("SPK_NO"))
                    mCatatan = ""
                    If nSr(MyRecReadA("STOCK_NoIndent")) = "1" Then
                        mCatatan = "UNIT RETURN"
                        If nSr(MyRecReadA("STOCK_BlockPickup")) = "2" Then
                            mCatatan = "UNIT UTK " & If(mLokasi = "112", "128", "112")
                            MySTRsql1 = "SELECT SPKCABANG_NOSPK as IsiField FROM SPKCABANG_NORANGKA='" & nSr(MyRecReadA("STOCK_NORANGKA")) & "'"
                            mNospk = GetDataD_IsiField("", mLokasi)
                        Else
                            mCatatan = "UNIT RETURN"
                        End If
                    ElseIf mNospk = "" Then
                        If mAntrianTipeWarna = "" Or mAntrianTipeWarna <> (nSr(MyRecReadA("STOCK_CDTYPE")) + nSr(MyRecReadA("STOCK_CDWARNA"))) Then
                            Call DescRangka(nSr(MyRecReadA("STOCK_NORANGKA")))
                            MySTRsql1 = "SELECT COUNT(SPK_NO) as IsiField FROM TRXN_SPK LEFT OUTER JOIN TRXN_SPKCANCEL ON TRXN_SPK.SPK_NO = TRXN_SPKCANCEL.SPKCANCEL_NO WHERE " & _
                                        "(SPK_TglDO IS NULL) AND (SPKCANCEL_NO IS NULL) AND " & _
                                        "DATEDIFF(DAY,'2017-03-01 00:00:00',SPK_Tanggal) > =0  AND ISNULL(SPK_NORANGKA,'')='' AND " & _
                                        "SPK_CDTYPE='" & nSr(MyRecReadA("STOCK_CDTYPE")) & "' AND SPK_CDWARNA='" & nSr(MyRecReadA("STOCK_CDWARNA")) & "' AND SPK_TAHUN='" & mRkT & "' " & _
                                        "( (ISNULL(SPK_UMRRANGKA,0) < 7 AND SPK_CDLEASE='C001') OR (ISNULL(SPK_UMRRANGKA,0) < 14  AND SPK_CDLEASE<>'C001') ) AND " & _
                                        "ISNULL(SPK_AVoucher,0) <= 20 "
                            mCatatan = nLg(GetDataD_IsiField("", mLokasi))
                            If nLg(mCatatan) <> "" Then
                                mCatatan = "ANTRIAN SPK HARI INI " & mCatatan
                            End If
                            mAntrianTipeWarna = (nSr(MyRecReadA("STOCK_CDTYPE")) + nSr(MyRecReadA("STOCK_CDWARNA")))
                        End If
                    End If

                    'STOCK_TglDOImoraHpm Januari DI rubah Menjadi DO Imora
                    'Call Input_data_STOCK_Detail(nSr(MyRecReadA("STOCK_CDTYPE")), nSr(MyRecReadA("STOCK_CDWARNA")), nSr(MyRecReadA("STOCK_NORANGKA")), nSr(MyRecReadA("STOCK_TglTerima")), nSr(MyRecReadA("SPK_NO")), IIf(nSr(MyRecReadA("mBatalFakturFiktif")) = "", nSr(MyRecReadA("mNospkFakturFiktif")), ""), MyDealer, "", "", "", mCatatan, 0, mDNET)
                    If mCatatan = "" And nLg(MyRecReadA("SPK_UMRRANGKA")) <> 0 Then
                        mCatatan = "UMUR RANGKA SPK " & nLg(MyRecReadA("SPK_UMRRANGKA")) & " HARI)"
                    End If
                    If Mid(nSr(MyRecReadA("STOCK_NORANGKA")), 10, 1) = "G" Then

                        MySTRsql1 = "SELECT WARNA_INT as IsiField FROM DATA_WARNA WHERE WARNA_KODE='" & nSr(MyRecReadA("STOCK_CDWARNA")) & "'"
                        mwarna = GetDataD_IsiField("", mLokasi)

                        MySTRsql1 = "SELECT TYPE_Nama as IsiField FROM DATA_TYPE WHERE TYPE_TYPE='" & nSr(MyRecReadA("STOCK_CDTYPE")) & "'"
                        mTipe = GetDataD_IsiField("", mLokasi)

                        Call Input_data_STOCK_Detail(nSr(MyRecReadA("STOCK_CDTYPE")), nSr(MyRecReadA("STOCK_CDWARNA")), nSr(MyRecReadA("STOCK_NORANGKA")), nSr(MyRecReadA("STOCK_TglDOImoraHpm")), mNospk, IIf(nSr(MyRecReadA("mBatalFakturFiktif")) = "", nSr(MyRecReadA("mNospkFakturFiktif")), ""), mLokasi, "T", "2016:" & mTipe, mwarna, mCatatan, 0, "")

                    Else
                        Call Input_data_STOCK_Detail(nSr(MyRecReadA("STOCK_CDTYPE")), nSr(MyRecReadA("STOCK_CDWARNA")), nSr(MyRecReadA("STOCK_NORANGKA")), nSr(MyRecReadA("STOCK_TglDOImoraHpm")), mNospk, IIf(nSr(MyRecReadA("mBatalFakturFiktif")) = "", nSr(MyRecReadA("mNospkFakturFiktif")), ""), mLokasi, "", "", "", mCatatan, 0, "")
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

    Function DataStockB1(ByVal mLokasi As String, ByVal mServer As String) As Integer
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        DataStockB1 = 0

        MySTRsql1 = "SELECT * FROM TRXN_DBNOTA WHERE (SELECT STOCK_NORANGKA FROM TRXN_STOCK WHERE STOCK_NORANGKA=RANGKA) IS NOT NULL"
        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    MySTRsql1 = "DELETE FROM TRXN_DBNOTA WHERE RANGKA like '%" & nSr(MyRecReadA("rangka")) & "%'"
                    Call UpdateDatabase_Tabel(MySTRsql1, mLokasi)
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function DataStockB2(ByVal mLokasi As String, ByVal mServer As String) As Integer
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        DataStockB2 = 0

        '    TYPESTOCK_UPDATE = 'D'
        Dim mAda As Byte = 0
        Dim mKodetype As String = ""
        Dim mTotalDN As Integer = 0
        MySTRsql1 = "SELECT * FROM TRXN_DBNOTA WHERE (SELECT STOCK_NORANGKA FROM TRXN_STOCK WHERE STOCK_NORANGKA=RANGKA) IS NULL"

        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mTotalDN = mTotalDN + 1
                    Call DescRangka(nSr(MyRecReadA("rangka")))

                    MySTRsql1 = "SELECT COUNT(TYPE_CdRangka) as IsiField FROM DATA_TYPE WHERE TYPE_CdRangka='" & mRk4 & mRk5 & "' AND (TYPE_CdRangka1 like '" & mRk6 & mRk7 & "%' OR TYPE_CdRangka2 like '" & mRk6 & mRk7 & "%' OR TYPE_CdRangka3 like '" & mRk6 & mRk7 & "%')"
                    mAda = GetDataD_IsiField(MySTRsql1, mLokasi)
                    MySTRsql1 = "SELECT TYPE_TYPE as IsiField FROM DATA_TYPE WHERE TYPE_CdRangka='" & mRk4 & mRk5 & "' AND (TYPE_CdRangka1 like '" & mRk6 & mRk7 & "%' OR TYPE_CdRangka2 like '" & mRk6 & mRk7 & "%' OR TYPE_CdRangka3 like '" & mRk6 & mRk7 & "%')"
                    mKodetype = GetDataD_IsiField(MySTRsql1, mLokasi)
                    If mAda <> 1 Then
                        mKodetype = "9999998"
                    End If
                    Call Input_data_STOCK_Detail(mKodetype, "9999", nSr(MyRecReadA("rangka")), "", "", "", mLokasi, "D", nSr(MyRecReadA("type")), nSr(MyRecReadA("warna")), "SDH DN BELUM TERIMA", 0, "")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function DataStockC(ByVal mLokasi As String, ByVal mServer As String) As Integer
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        DataStockC = 0

        '    TYPESTOCK_UPDATE = 'D'
        Dim mAda As Byte = 0
        Dim mKodetype As String = ""
        Dim mTotalDN As Integer = 0
        MySTRsql1 = "SELECT * " & _
                    "FROM TRXN_SPK,TRXN_STOCK WHERE " & _
                    "SPK_NORANGKA=STOCK_NORANGKA AND DATEDIFF(day,'2016-06-01 00:00:00',SPK_TGLDO) >= 0 AND " & _
                    "(STOCK_KIRIMTGLTERIMAI IS NULL AND STOCK_KirimTGLMHNI IS NULL) AND (STOCK_KirimNo IS NULL OR STOCK_KirimNo <>'999999') " & _
                    "ORDER BY SPK_NO"

        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    Call Input_data_STOCK_Detail(nSr(MyRecReadA("STOCK_CDTYPE")), nSr(MyRecReadA("STOCK_CDWARNA")), nSr(MyRecReadA("STOCK_NORANGKA")), nSr(MyRecReadA("STOCK_TglDOImoraHpm")), nSr(MyRecReadA("SPK_NO")), "", mLokasi, "R", "", "", "", 0, "")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function DataStockD(ByVal mpTglAlokasi As String, ByVal mLokasi As String, ByVal mServer As String) As Integer
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        DataStockD = 0

        Dim mAlokasi As Integer = 0
        MySTRsql1 = "SELECT * FROM TRXN_TYPEALOKASIHM,DATA_TYPE " & _
                    "WHERE ALOKASIHPM_CDTYPE=TYPE_TYPE AND ALOKASIHPM_STATUS='C' AND ALOKASIHPM_QTY<>0 AND " & _
                    "YEAR(ALOKASIHPM_TANGGAL)=" & Year(CDate(mpTglAlokasi)) & " AND MONTH(ALOKASIHPM_TANGGAL)=" & Month(CDate(mpTglAlokasi))

        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mAlokasi = nLg(MyRecReadA("ALOKASIHPM_QTY"))
                    'mAlokasi = nLg(MyRecReadA("ALOKASIHPM_QTY")) - nLg(MyRecReadA("ALOKASIHPM_QTY"))
                    If nSr(MyRecReadA("ALOKASIHPM_CDTYPE")) = "0000103" Then
                        'MsgBox(mAlokasi)
                    End If
                    Call Input_data_STOCK_Detail(nSr(MyRecReadA("ALOKASIHPM_CDTYPE")), nSr(MyRecReadA("ALOKASIHPM_CDWARNA")), "ALOKASI : " & nLg(mAlokasi), "", "", "", mLokasi, "A", "", "", "ALOKASI HPM BLN " & Format(CDate(mpTglAlokasi), "MM/yy") & ":" & nLg(MyRecReadA("ALOKASIHPM_QTY")), mAlokasi, "")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function DataStockE(ByVal mpTglAlokasi As String, ByVal mLokasi As String, ByVal mServer As String) As Integer
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        DataStockE = 0

        Dim mKodeWarnaHMS As String = ""
        Dim mTotalDOImora As Integer = 0
        Dim mTotalDOAlokasi As Integer = 0
        Dim myear As String = ""


        Dim mAda As Byte = 0
        Dim mCatatan As String = ""
        Dim mKodetype As String = ""

        MySTRsql1 = "SELECT * FROM TRXN_STOCKDO WHERE STOCKDO_KODEDLR='" & mLokasi & "' AND " & _
                    "ISNUMERIC(STOCKDO_NODOSPL)<>0 AND " & _
                    "STOCKDO_TGDOSPL like '" & Month(mpTglAlokasi) & "/%" & Year(mpTglAlokasi) & "'"

        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    'NamaTypeImora.Text = nSr((MyReadDataTbl1("STOCKDO_TYPEDOSPL")))
                    'KodeTypeImora.Text = nSr((MyReadDataTbl1("STOCKDO_TYPEDOSPLCODE")))
                    'KodeWarnaImora.Text = nSr((MyReadDataTbl1("STOCKDO_WARNADOSPL")))
                    'NamaWarnaImora.Text = nSr((MyReadDataTbl1("STOCKDO_WARNADOSPLDESC")))

                    mTotalDOImora = mTotalDOImora + 1


                    Call DescRangka(nSr(MyRecReadA("STOCKDO_NORANGKA")))
                    mAda = 0 : mKodetype = "" : mKodeWarnaHMS = ""
                    MySTRsql1 = "SELECT COUNT(TYPE_CdRangka) as IsiField FROM DATA_TYPE WHERE TYPE_CdRangka='" & mRk4 & mRk5 & "' AND (TYPE_CdRangka1 like '" & mRk6 & mRk7 & "%' OR TYPE_CdRangka2 like '" & mRk6 & mRk7 & "%' OR TYPE_CdRangka3 like '" & mRk6 & mRk7 & "%')"
                    mAda = GetDataD_IsiField(MySTRsql1, mLokasi)
                    MySTRsql1 = "SELECT TYPE_TYPE as IsiField FROM DATA_TYPE WHERE TYPE_CdRangka='" & mRk4 & mRk5 & "' AND (TYPE_CdRangka1 like '" & mRk6 & mRk7 & "%' OR TYPE_CdRangka2 like '" & mRk6 & mRk7 & "%' OR TYPE_CdRangka3 like '" & mRk6 & mRk7 & "%')"
                    mKodetype = GetDataD_IsiField(MySTRsql1, mLokasi)
                    If mAda <> 1 Then
                        mKodetype = "9999997"
                        mKodeWarnaHMS = "9999"
                    Else
                        MySTRsql1 = "SELECT COUNT(WARNA_INT) as IsiField FROM DATA_WARNA WHERE WARNA_INT='" & nSr(MyRecReadA("STOCKDO_WARNADOSPLDESC")) & "'"
                        mAda = GetDataD_IsiField(MySTRsql1, mLokasi)
                        MySTRsql1 = "SELECT WARNA_KODE as IsiField FROM DATA_WARNA WHERE WARNA_INT='" & nSr(MyRecReadA("STOCKDO_WARNADOSPLDESC")) & "'"
                        mKodeWarnaHMS = GetDataD_IsiField(MySTRsql1, mLokasi)
                        If mAda <> 1 Then
                            mKodetype = "9999997"
                            mKodeWarnaHMS = "9999"
                        End If
                    End If
                    If nSr(MyRecReadA("STOCKDO_NOTTK")) = "" Then
                        'Intrasit
                        Call Input_data_STOCK_Detail(mKodetype, mKodeWarnaHMS, nSr(MyRecReadA("STOCKDO_NORANGKA")), "", "", "", mLokasi, "S", nSr(MyRecReadA("STOCKDO_TYPEDOSPL")), nSr(MyRecReadA("STOCKDO_WARNADOSPLDESC")), "DO IMORA BELUM TERIMA", 0, "")
                    End If


                    'Update DN Alokasi
                    mAda = 0
                    mTotalDOAlokasi = -1
                    MySTRsql1 = "SELECT COUNT(TYPESTOCK_CDDEALER) as IsiField FROM DATA_TYPESTOCK WHERE TYPESTOCK_CDDEALER='" & mLokasi & "' AND TYPESTOCK_CDTYPE='" & mKodetype & "'  AND TYPESTOCK_CDWARNA='" & mKodeWarnaHMS & "' AND TYPESTOCK_UPDATE  ='A'"
                    mAda = GetDataD_IsiField(MySTRsql1, mLokasi)
                    MySTRsql1 = "SELECT TYPESTOCK_QTY as IsiField FROM DATA_TYPESTOCK WHERE TYPESTOCK_CDDEALER='" & mLokasi & "' AND TYPESTOCK_CDTYPE='" & mKodetype & "'  AND TYPESTOCK_CDWARNA='" & mKodeWarnaHMS & "' AND TYPESTOCK_UPDATE  ='A'"
                    mTotalDOAlokasi = GetDataD_IsiField(MySTRsql1, mLokasi)
                    If mAda > 0 Then
                        MySTRsql1 = "UPDATE DATA_TYPESTOCK SET TYPESTOCK_QTY=" & mTotalDOAlokasi & " " & _
                                    "WHERE TYPESTOCK_CDDEALER='" & mLokasi & "' AND TYPESTOCK_CDTYPE='" & mKodetype & "'  AND TYPESTOCK_CDWARNA='" & mKodeWarnaHMS & "' AND TYPESTOCK_UPDATE  ='A'"
                        'Temp STop Call ExecuteSQLServerSales1("", MySTRsql1, mDNET, 9, 9)
                    Else
                        'Temp STop Call Input_data_STOCK_Detail(mKodetype, mKodeWarnaHMS, "ALOKASI : " & nLg(mTotalDOAlokasi), "", "", "", MyDealer, "A", "", "", "ALOKASI HPM BLN " & Format(CDate(mTglAlokasi), "MM/yy") & ":0", mTotalDOAlokasi, mDNET)
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

    Function Akumlasi_Stock(ByVal mLokasi As String, ByVal mServer As String) As Integer
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        Akumlasi_Stock = 0

        Dim mCdGroup As String = ""
        Dim mTotal As Integer = 0
        Dim mTotalDnBlmSTok As Integer = 0
        Dim mTotalAlokasi As Integer = 0
        Dim mTotalSPK As Integer = 0
        Dim mTotal16 As Integer = 0
        Dim mTotalSPK16 As Integer = 0
        Dim mTotal17 As Integer = 0
        Dim mTotalSPK17 As Integer = 0
        Dim mTotalSPKFaktur As Integer = 0
        Dim mTotalDOBlmTerima As Integer = 0
        Dim mTotalDOImoraBlmTerima As Integer = 0
        Dim mTotalUnitReturn As Integer = 0

        MySTRsql1 = "SELECT TYPE_CdGroup," & _
                    "SUM(TYPEP_STOCK) AS flTotal," & _
                    "SUM(TYPEP_JUAL01) AS flTotalSPK ," & _
                    "SUM(TYPEP_JUAL02) AS flTotalStk16, " & _
                    "SUM(TYPEP_JUAL03) AS flTotalSPK16, " & _
                    "SUM(TYPEP_JUAL04) AS flTotalStk17, " & _
                    "SUM(TYPEP_JUAL05) AS flTotalSPK17," & _
                    "SUM(TYPEP_JUAL06) AS flTotalFaktur," & _
                    "SUM(TYPEP_JUAL07) AS flDOBlmTerima," & _
                    "SUM(TYPEP_JUAL08) AS flTotalDNBlmStok," & _
                    "SUM(TYPEP_JUAL09) AS flTotalAlokasi," & _
                    "SUM(TYPEP_JUAL10) AS flTotalDOImora," & _
                    "SUM(TYPEP_JUAL11) AS flUnitRetun " & _
                    "FROM DATA_TYPEPERFORM,DATA_TYPE WHERE " & _
                    "TYPEP_TYPE=TYPE_TYPE AND TYPEP_MUGEN = '" & mLokasi & "' AND TYPE_CdGroup<>'ZZZ' GROUP BY TYPE_CdGroup"
        '                    "TYPEP_TYPE=TYPE_TYPE AND TYPEP_MUGEN = '" & mLokasi & "' AND TYPEP_STOCK <> 0 GROUP BY TYPE_CdGroup"

        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    mTotal = mTotal + nLg(MyRecReadA("flTotal"))
                    mTotalDnBlmSTok = mTotalDnBlmSTok + nLg(MyRecReadA("flTotalDNBlmStok"))
                    mTotalAlokasi = mTotalAlokasi + nLg(MyRecReadA("flTotalAlokasi"))
                    mTotalSPK = mTotalSPK + nLg(MyRecReadA("flTotalSPK"))
                    mTotal16 = mTotal16 + nLg(MyRecReadA("flTotalStk16"))
                    mTotalSPK16 = mTotalSPK16 + nLg(MyRecReadA("flTotalSpk16"))
                    mTotal17 = mTotal17 + nLg(MyRecReadA("flTotalStk17"))
                    mTotalSPK17 = mTotalSPK17 + nLg(MyRecReadA("flTotalSpk17"))
                    mTotalSPKFaktur = mTotalSPKFaktur + nLg(MyRecReadA("flTotalFaktur"))
                    mTotalDOBlmTerima = mTotalDOBlmTerima + nLg(MyRecReadA("flDOBlmTerima"))
                    mTotalDOImoraBlmTerima = mTotalDOImoraBlmTerima + nLg(MyRecReadA("flTotalDOImora"))
                    mTotalUnitReturn = mTotalUnitReturn + nLg(MyRecReadA("flUnitRetun"))
                    Call Input_data_STOCK("9999991", nSr(MyRecReadA("TYPE_CdGroup")), "*******************", " TYPEP_STOCK= NULL,TYPEP_JUAL01=NULL,TYPEP_JUAL02=NULL,TYPEP_JUAL03=NULL,TYPEP_JUAL04=NULL,TYPEP_JUAL05=NULL,TYPEP_JUAL06=NULL,TYPEP_JUAL07=NULL,TYPEP_JUAL08=NULL,TYPEP_JUAL09=NULL,TYPEP_JUAL10=NULL,TYPEP_JUAL11=NULL,TYPEP_STOCKTGL=GETDATE() ", " AND TYPEP_CdGroup='" & nSr(MyRecReadA("TYPE_CdGroup")) & "' ", mLokasi, "")
                    Call Input_data_STOCK("9999992", nSr(MyRecReadA("TYPE_CdGroup")), "******** TOTAL GROUP " & nSr(MyRecReadA("TYPE_CdGroup")), " TYPEP_STOCK= " & nLg(MyRecReadA("flTotal")) & ",TYPEP_JUAL01= " & nLg(MyRecReadA("flTotalSPK")) & ",TYPEP_JUAL02= " & nLg(MyRecReadA("flTotalStk16")) & ",TYPEP_JUAL03= " & nLg(MyRecReadA("flTotalSpk16")) & ",TYPEP_JUAL04= " & nLg(MyRecReadA("flTotalStk17")) & ",TYPEP_JUAL05= " & nLg(MyRecReadA("flTotalSpk17")) & ",TYPEP_JUAL06= " & nLg(MyRecReadA("flTotalFaktur")) & ",TYPEP_JUAL07= " & nLg(MyRecReadA("flDOBlmTerima")) & ",TYPEP_JUAL08= " & nLg(MyRecReadA("flTotalDNBlmStok")) & ",TYPEP_JUAL09= " & nLg(MyRecReadA("flTotalAlokasi")) & ",TYPEP_JUAL10= " & nLg(MyRecReadA("flTotalDOImora")) & ",TYPEP_JUAL11= " & nLg(MyRecReadA("flUnitRetun")) & ",TYPEP_STOCKTGL=GETDATE() ", " AND TYPEP_CdGroup='" & nSr(MyRecReadA("TYPE_CdGroup")) & "' ", mLokasi, "")
                    Call Input_data_STOCK("9999993", nSr(MyRecReadA("TYPE_CdGroup")), "*******************", " TYPEP_STOCK= NULL,TYPEP_JUAL01=NULL,TYPEP_JUAL02=NULL,TYPEP_JUAL03=NULL,TYPEP_JUAL04=NULL,TYPEP_JUAL05=NULL,TYPEP_JUAL06=NULL,TYPEP_JUAL07=NULL,TYPEP_JUAL08=NULL,TYPEP_JUAL09=NULL,TYPEP_JUAL10=NULL,TYPEP_JUAL11=NULL,TYPEP_STOCKTGL=GETDATE() ", " AND TYPEP_CdGroup='" & nSr(MyRecReadA("TYPE_CdGroup")) & "' ", mLokasi, "")
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
            Call Input_data_STOCK("9999994", "ZZZ", "***TOTAL KESELURUHAN " & mLokasi, " TYPEP_STOCK= " & nLg(mTotal) & ",TYPEP_JUAL01= " & nLg(mTotalSPK) & ",TYPEP_JUAL02= " & nLg(mTotal16) & ",TYPEP_JUAL03= " & nLg(mTotalSPK16) & ",TYPEP_JUAL04= " & nLg(mTotal17) & ",TYPEP_JUAL05= " & nLg(mTotalSPK17) & ",TYPEP_JUAL06= " & nLg(mTotalSPKFaktur) & ",TYPEP_JUAL07= " & nLg(mTotalDOBlmTerima) & ",TYPEP_JUAL08= " & nLg(mTotalDnBlmSTok) & ",TYPEP_JUAL09= " & nLg(mTotalAlokasi) & ",TYPEP_JUAL10= " & nLg(mTotalDOImoraBlmTerima) & ",TYPEP_JUAL11= " & nLg(mTotalUnitReturn) & ",TYPEP_STOCKTGL=GETDATE() ", " AND TYPEP_CdGroup='ZZZ' ", mLokasi, "")
            Call Input_data_STOCK("9999995", "ZZZ", "*******************", " TYPEP_STOCK= NULL,TYPEP_JUAL01=NULL,TYPEP_JUAL02=NULL,TYPEP_JUAL03=NULL,TYPEP_JUAL04=NULL,TYPEP_JUAL05=NULL,TYPEP_JUAL06=NULL,TYPEP_JUAL07=NULL,TYPEP_JUAL08=NULL,TYPEP_JUAL09=NULL,TYPEP_JUAL10=NULL,TYPEP_JUAL11=NULL,TYPEP_STOCKTGL=GETDATE() ", " AND TYPEP_CdGroup='ZZZ' ", mLokasi, "")

        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Sub Input_data_STOCK(ByVal mKode As String, ByVal mCdGroup As String, ByVal mNama As String, _
                     ByVal mUPDATE As String, ByVal mQuery As String, ByVal mLokasi As String, _
                     ByVal mDNETDatabase As Byte)
        MySTRsql1 = "SELECT * FROM DATA_TYPEPERFORM WHERE TYPEP_TYPE = '" & mKode & "' AND TYPEP_MUGEN = '" & mLokasi & "'  " & mQuery
        If GetDataD_00NoFound01Found(MySTRsql1, mDNETDatabase) <> 1 Then
            MySTRsql1 = "INSERT INTO DATA_TYPEPERFORM (" & _
                                "TYPEP_TYPE,TYPEP_STOCK,TYPEP_STOCKTGL," & _
                                "TYPEP_JUAL01,TYPEP_JUAL01TGL,TYPEP_JUAL02,TYPEP_JUAL02TGL,TYPEP_JUAL03,TYPEP_JUAL03TGL," & _
                                "TYPEP_JUAL04,TYPEP_JUAL04TGL,TYPEP_JUAL05,TYPEP_JUAL05TGL,TYPEP_JUAL06,TYPEP_JUAL06TGL," & _
                                "TYPEP_JUAL07,TYPEP_JUAL07TGL,TYPEP_JUAL08,TYPEP_JUAL08TGL,TYPEP_JUAL09,TYPEP_JUAL09TGL," & _
                                "TYPEP_JUAL10,TYPEP_JUAL10TGL,TYPEP_JUAL11,TYPEP_JUAL11TGL,TYPEP_JUAL12,TYPEP_JUAL12TGL," & _
                                "TYPEP_MUGEN,TYPEP_CdGroup,TYPEP_Nama) VALUES " & _
                                "('" & mKode & "',0,NULL," & _
                                "  0,NULL,0,NULL,0,NULL," & _
                                "  0,NULL,0,NULL,0,NULL," & _
                                "  0,NULL,0,NULL,0,NULL," & _
                                "  0,NULL,0,NULL,0,NULL,'" & mLokasi & "','" & mCdGroup & "','" & mNama & "')"
            Call UpdateDatabase_Tabel(MySTRsql1, "")
        End If
        MySTRsql1 = "UPDATE DATA_TYPEPERFORM SET " & mUPDATE & " WHERE TYPEP_TYPE = '" & mKode & "' " & mQuery & " AND TYPEP_MUGEN = '" & mLokasi & "'"
        Call UpdateDatabase_Tabel(MySTRsql1, "")
    End Sub

    Sub Input_data_STOCK_Detail(ByVal mKode As String, ByVal mWarna As String, ByVal mRangka As String, ByVal mTerima As String, ByVal mNOSPK As String, ByVal mNOSPKFaktur As String, ByVal mLokasi As String, ByVal mUpdate As String, ByVal mUpTipe As String, ByVal mUpWarna As String, ByVal mUpCatat As String, ByVal mJml As Integer, ByVal mDNETDatabase As Byte)
        If Not IsDate(mTerima) Then
            mTerima = "NULL"
        Else
            mTerima = DtInSQL(CDate(mTerima))
        End If
        MySTRsql1 = "INSERT INTO DATA_TYPESTOCK (" & _
                    "TYPESTOCK_CDDEALER,TYPESTOCK_CDTYPE,TYPESTOCK_CDWARNA,TYPESTOCK_NORANGKA,TYPESTOCK_TGL,TYPESTOCK_TGLTERIMA,TYPESTOCK_NOSPK,TYPESTOCK_NOSPKFAKTUR,TYPESTOCK_UPDATE,TYPESTOCK_DNTIPE,TYPESTOCK_DNWARNA,TYPESTOCK_CATATAN,TYPESTOCK_QTY) VALUES " & _
                    "('" & mLokasi & "','" & mKode & "','" & mWarna & "','" & mRangka & "',GETDATE()," & mTerima & ",'" & mNOSPK & "','" & mNOSPKFaktur & "','" & mUpdate & "','" & mUpTipe & "','" & mUpWarna & "','" & mUpCatat & "'," & mJml & ")"
        Call UpdateDatabase_Tabel(MySTRsql1, "")
    End Sub

    Function Data_Stock_DBNOTA_to_WebServer(ByVal mLokasi As String, ByVal mServer As String) As Integer
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        Data_Stock_DBNOTA_to_WebServer = 0

        '    TYPESTOCK_UPDATE = 'D'
        MySTRsql1 = "SELECT TYPE_CdGroup," & _
                    "SUM(TYPEP_JUAL08) AS flTotalDNBlmStok," & _
                    "SUM(TYPEP_JUAL10) AS flTotalDOImora " & _
                    "FROM DATA_TYPEPERFORM,DATA_TYPE WHERE " & _
                    "TYPEP_TYPE=TYPE_TYPE AND TYPEP_MUGEN = '" & mLokasi & "' AND TYPEP_TYPE='9999998' GROUP BY TYPE_CdGroup"

        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    Call Input_data_STOCK("999999A", nSr(MyRecReadA("TYPE_CdGroup")), "*******************", " TYPEP_STOCK= NULL,TYPEP_JUAL01=NULL,TYPEP_JUAL02=NULL,TYPEP_JUAL03=NULL,TYPEP_JUAL04=NULL,TYPEP_JUAL05=NULL,TYPEP_JUAL06=NULL,TYPEP_JUAL07=NULL,TYPEP_JUAL08=NULL,TYPEP_JUAL09=NULL,TYPEP_JUAL10=NULL,TYPEP_JUAL11=NULL,TYPEP_STOCKTGL=GETDATE() ", " AND TYPEP_CdGroup='" & nSr(MyRecReadA("TYPE_CdGroup")) & "' ", mLokasi, 5)
                    Call Input_data_STOCK("999999B", nSr(MyRecReadA("TYPE_CdGroup")), "TOTAL NON KODE" & mLokasi, " TYPEP_STOCK= 0,TYPEP_JUAL01= 0,TYPEP_JUAL02= 0,TYPEP_JUAL03= 0,TYPEP_JUAL04= 0,TYPEP_JUAL05= 0,TYPEP_JUAL06= 0,TYPEP_JUAL07= 0,TYPEP_JUAL08= " & nLg(MyRecReadA("flTotalDNBlmStok")) & ",TYPEP_JUAL09= 0,TYPEP_JUAL10= " & nLg(MyRecReadA("flTotalDOImora")) & ",TYPEP_JUAL11= 0,TYPEP_STOCKTGL=GETDATE() ", " AND TYPEP_CdGroup='" & nSr(MyRecReadA("TYPE_CdGroup")) & "' ", mLokasi, 5)
                    Call Input_data_STOCK("999999C", nSr(MyRecReadA("TYPE_CdGroup")), "*******************", " TYPEP_STOCK= NULL,TYPEP_JUAL01=NULL,TYPEP_JUAL02=NULL,TYPEP_JUAL03=NULL,TYPEP_JUAL04=NULL,TYPEP_JUAL05=NULL,TYPEP_JUAL06=NULL,TYPEP_JUAL07=NULL,TYPEP_JUAL08=NULL,TYPEP_JUAL09=NULL,TYPEP_JUAL10=NULL,TYPEP_JUAL11=NULL,TYPEP_STOCKTGL=GETDATE() ", " AND TYPEP_CdGroup='" & nSr(MyRecReadA("TYPE_CdGroup")) & "' ", mLokasi, 5)
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Function DataStockF(ByVal mLokasi As String, ByVal mServer As String) As Integer
        mServer = "MyConnCloudDnet" & mServer
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        DataStockF = 0

        Dim mRp As Double = 0
        Dim mThn As String = ""

        '    TYPESTOCK_UPDATE = 'D'
        MySTRsql1 = "SELECT * FROM DATA_TYPEPERFORM WHERE TYPEP_MUGEN='" & mLokasi & "'"

        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    If Year(Now) >= 2018 Then
                        mThn = Chr(Year(Now) - 1944)
                    Else
                        mThn = Chr(Year(Now) - 1945)
                    End If

                    For mIdx As Byte = 1 To 1
                        MySTRsql1 = "SELECT TYPED_Jumlah as IsiField FROM DATA_TYPED WHERE typed_type='" & nSr(MyRecReadA("typep_type")) & "' AND substring(typed_rangka,7,1)='" & mThn & "' ORDER BY TYPED_TANGGAL desc"
                        mRp = GetDataD_IsiField("", mLokasi)

                        MySTRsql1 = "UPDATE DATA_TYPEPERFORM  SET TYPEP_JUAL12 = " & mRp & " " & _
                                    "WHERE TYPEP_MUGEN='" & mLokasi & "' AND typep_type='" & nSr(MyRecReadA("typep_type")) & "'"
                        Call UpdateDatabase_Tabel(MySTRsql1, "")
                        mThn = Chr(Asc(mThn) - 1)
                    Next
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message)
        End Try
    End Function

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPickupReq.Click
        LblNorangkaTersedia.Text = "" : LblNorangkaTersediaDPP.Text = "" : LblNorangkaTersediaPPN.Text = "" : LblNorangkaTersediaDN.Text = "" : LblNorangkaTersediaTGLDN.Text = ""
        If LblLokasi.Text = lblArea1.Text Then
            Call Msg_err("Salah ambil lokasi rangka ")
        ElseIf TxtPemohonNote.Text = "" Then
            Call Msg_err("Catatan Pemohon belum diisi ")
        Else
            If ValidasiNospkAsal() = 1 Then
                LblNorangkaTersedia.Text = ""
                Call Proses_SPK_Pickup_Rangka_To_Urut_TGLSPKHDIARY(0, "")
                If LblNorangkaTersedia.Text <> "" Then
                    If GetDataD_00NoFound01Found("SELECT STOCK_NOTTK FROM TRXN_STOCK WHERE STOCK_NORANGKA='" & LblNorangkaTersedia.Text & "'", IIf(LblLokasi.Text = "112", "128", "112")) = 1 Then
                        LblWarningPickup1.Text = "Sudah mendapat rangka ini " & LblNorangkaTersedia.Text & " Namun sudah ada di Stok (Sudah pindahkan periksa stok)"
                        LblNorangkaTersedia.Text = ""
                    End If
                End If

                If LblNorangkaTersedia.Text <> "" Then
                    Call CreateDebetNota()
                    If LblNorangkaTersediaDN.Text <> "" Then
                        Call AddStok_MoveCabang()
                        If LblNorangkaTersediaNOTTK.Text <> "" Then
                            Dim mTxtInsert As String = "INSERT INTO TRXN_REQUESTSTOK(REQSTK_TGL,REQSTK_MHNDEALER,REQSTK_MHNUSER,REQSTK_MHNCDTIPE,REQSTK_MHNCDWARNA,REQSTK_MHNNOSPK,REQSTK_STJDEALER,REQSTK_STJNORANGKA,REQSTK_DNTGL,REQSTK_DN,REQSTK_NOTTK,REQSTK_NOTE) VALUES " & _
                                                       "(GETDATE(),'" & IIf(LblLokasi.Text = "112", "128", "112") & "','" & LblUserName.Text & "','" & LblTipeKode.Text & "','" & LblWarnaKode.Text & "','" & TxtPemohonSPK.Text & "','" & LblLokasi.Text & "','" & LblNorangkaTersedia.Text & "'," & IIf(LblNorangkaTersediaDN.Text = "", "NULL", "GETDATE()") & ",'" & LblNorangkaTersediaDN.Text & "','" & LblNorangkaTersediaNOTTK.Text & "','" & TxtPemohonNote.Text & "')"
                            If UpdateDatabase_Tabel(mTxtInsert, "") = 1 Then
                                Dim Judul As String = "Sukses diambil Rangka " & LblNorangkaTersedia.Text & " Tipe " & "" & LblTipeNama.Text & " Warna " & LblWarnaNama.Text & " Dari Lokasi " & LblLokasi.Text & " ke " & IIf(LblLokasi.Text = "112", "128", "112")
                                Dim Isi As String = "Tanggal Permohonan ambil Unit " & LblLokasi.Text & " Tipe " & "" & LblTipeNama.Text & " Warna " & LblWarnaNama.Text & " dengan rangka no " & LblNorangkaTersedia.Text & " Untuk spk " & TxtPemohonSPK.Text & " dengan catatan " & TxtPemohonNote.Text & " " & Chr(13) & _
                                                    "Nomor DN asal '" & LblNorangkaTersediaDN.Text & "' dan Nomor TTK tujuan '" & LblNorangkaTersediaNOTTK.Text & "' "

                                Call SendEmailProces("Faiz@Hondamugen.co.id", Judul, "", "", Isi)
                                Call SendEmailProces("Ugam@Hondamugen.co.id", Judul, "", "", Isi)
                                Call SendEmailProces("Sopan@Hondamugen.co.id", Judul, "", "", Isi)
                                Call SendEmailProces("acc_puri@Hondamugen.co.id", Judul, "", "", Isi)
                                LblWarningPickup1.Text = "Stok Berhasil di ambil ....."
                            End If
                        Else
                            MySTRsql1 = "DELETE FROM TRXN_DBNOTAINTERNAL WHERE DBNOTAINT_NO='" & LblNorangkaTersediaDN.Text & "'"
                            Call UpdateDatabase_Tabel(MySTRsql1, LblLokasi.Text)
                            LblWarningPickup1.Text = "Stok tidak Berhasil di ambil (Gagal TTK....."
                        End If
                    Else
                        LblWarningPickup1.Text = "Stok tidak Berhasil di ambil (Gagal Create DN....."
                    End If
                Else
                    LblWarningPickup1.Text = "Tidak Ada Stok Yang Kosong"
                End If
                If LblWarningPickup1.Text <> "" Then
                    Call Msg_err(LblWarningPickup1.Text)
                End If
                MultiViewENTRY.ActiveViewIndex = -1
                LvRequestSTok.DataBind()
            End If
        End If
        'Call Data_Stock_to_WebServer(LblLokasi.Text)
    End Sub


    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPickupSedia.Click
        LblNorangkaTersedia.Text = ""
        Call Proses_SPK_Pickup_Rangka_To_Urut_TGLSPKHDIARY(0, "")

    End Sub

    Protected Sub BtnStockReq_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStockReq.Click
        If LblLokasi.Text = lblArea1.Text Then
            'Call Data_Stock_to_WebServer(lblArea1.Text)
        Else
            Call Msg_err("Bukan Dealer Stok yang bersangkutan domisili")
        End If

    End Sub

    Protected Sub BtnPickupTutup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPickupTutup.Click
        MultiViewENTRY.ActiveViewIndex = -1
        MultiView1a.ActiveViewIndex = 1
    End Sub


    Function CreateDebetNota() As Byte
        CreateDebetNota = 0
        Dim mNoDebetNota As String = AddNomorWithYear("VOUCHER_DEBETNOTA", 5)
        If mNoDebetNota <> "" Then
            MySTRsql1 = "INSERT INTO TRXN_DBNOTAINTERNAL(DBNOTAINT_NO,DBNOTAINT_TANGGAL,DBNOTAINT_NORANGKA,DBNOTAINT_STATUS,DBNOTAINT_KDSUPLIER,DBNOTAINT_HARGA,DBNOTAINT_PPN,DBNOTAINT_STOK) VALUES " & _
                        "('" & mNoDebetNota & "',GETDATE(),'" & LblNorangkaTersedia.Text & "','','" & IIf(LblLokasi.Text = "112", "S028", "S002") & "'," & nLg((LblNorangkaTersediaDPP.Text)) & "," & nLg((LblNorangkaTersediaPPN.Text)) & ",'N')"
            CreateDebetNota = UpdateDatabase_Tabel(MySTRsql1, LblLokasi.Text)
            If CreateDebetNota = 1 Then
                LblNorangkaTersediaDN.Text = mNoDebetNota : LblNorangkaTersediaTGLDN.Text = Now()
            End If
        End If
    End Function

    Function AddNomorWithYear(ByVal mField As String, ByVal mPanjang As Byte) As String
        MySTRsql1 = "SELECT " & mField & " as IsiField FROM DATA_VOUCHER WHERE LEFT(" & mField & ",2) = RIGHT(STR(YEAR(GETDATE())),2)"
        AddNomorWithYear = GetDataD_IsiField(MySTRsql1, LblLokasi.Text)
        If AddNomorWithYear = "" Then
            AddNomorWithYear = Right(CStr(Year(CDate(Now()))), 2) & Mid("00000000000", 1, mPanjang - 3) & "1"
        Else
            AddNomorWithYear = Right(CStr(Year(CDate(Now()))), 2) & Format(Val(Right(AddNomorWithYear, Len(AddNomorWithYear) - 2)) + 1, Right("00000000", Len(AddNomorWithYear) - 2))
        End If
        If AddNomorWithYear <> "" Then
            MySTRsql1 = "UPDATE DATA_VOUCHER SET " & mField & "='" & AddNomorWithYear & "' WHERE VOUCHER_No='A'"
            Call UpdateDatabase_Tabel(MySTRsql1, LblLokasi.Text)
        End If
    End Function
    Function AddStok_MoveCabang() As Byte
        Dim mServer As String = "MyConnCloudDnet" & LblLokasi.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("")
        AddStok_MoveCabang = 0
        MySTRsql1 = "SELECT * FROM TRXN_DBNOTAINTERNAL,TRXN_STOCK WHERE DBNOTAINT_NORANGKA='" & LblNorangkaTersedia.Text & "' AND DBNOTAINT_NORANGKA=STOCK_NORANGKA AND DBNOTAINT_STATUS='' AND (DBNOTAINT_STOK IS NULL OR DBNOTAINT_STOK ='N')"
        cnn = New OleDbConnection(strconn)
        Try

            cnn.Open()
            cmd = New OleDbCommand(MySTRsql1, cnn)
            MyRecReadA = cmd.ExecuteReader()
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    Dim mNoTTk As String = nSr(MyRecReadA("STOCK_NoTTK"))
                    mNoTTk = Mid(mNoTTk, 1, 6) & "C"
                    Dim mCdSuplier As String = IIf(LblLokasi.Text = "112", "S002", "S028")

                    MySTRsql1 = "INSERT INTO TRXN_STOCK (" & _
                                "STOCK_NoTTK,STOCK_StsUpdate,STOCK_TglUpdate,STOCK_TglTTK," & _
                                "STOCK_NoRangka,STOCK_NoMesin,STOCK_CdType,STOCK_CdWarna,STOCK_CdSuplier," & _
                                "STOCK_Versi,STOCK_Tahun,STOCK_NoKunci," & _
                                "STOCK_Barter,STOCK_DoAuto,STOCK_TglAuto,STOCK_TglJT,STOCK_CdLokasi," & _
                                "STOCK_Keterangan,STOCK_DPP,STOCK_PBM,STOCK_PPN," & _
                                "STOCK_Var,STOCK_Surat,STOCK_Bunga,STOCK_PDisc,STOCK_BService,STOCK_Tglterima) "

                    MySTRsql1 = MySTRsql1 & "VALUES " & _
                                "('" & mNoTTk & "','C',GETDATE(),GETDATE(),'" & _
                                MyRecReadA("STOCK_NoRangka") & "','" & nSr(MyRecReadA("STOCK_NoMesin")) & "','" & nSr(MyRecReadA("STOCK_CdType")) & "','" & MyRecReadA("STOCK_CdWarna") & "','" & mCdSuplier & "','" & _
                                "N" & "','" & MyRecReadA("STOCK_Tahun") & "','" & nSr(MyRecReadA("STOCK_NoKunci")) & "','" & _
                                "Y" & "','',NULL,NULL,'" & MyRecReadA("STOCK_CdLokasi") & "','" & _
                                "CROSS SELL" & "',0,0,0,0,0,0,0,NULL,GETDATE())"
                    If UpdateDatabase_Tabel(MySTRsql1, IIf(LblLokasi.Text = "112", "128", "112")) = 1 Then
                        MySTRsql1 = "UPDATE TRXN_DBNOTAINTERNAL SET  DBNOTAINT_STOK='Y' WHERE DBNOTAINT_NORANGKA='" & LblNorangkaTersedia.Text & "'"
                        UpdateDatabase_Tabel(MySTRsql1, LblLokasi.Text)

                        MySTRsql1 = "UPDATE TRXN_SPK SET SPK_NORANGKA='" & LblNorangkaTersedia.Text & "' WHERE SPK_NO='" & TxtPemohonSPK.Text & "'"
                        UpdateDatabase_Tabel(MySTRsql1, IIf(LblLokasi.Text = "112", "128", "112"))

                        LblNorangkaTersediaNOTTK.Text = mNoTTk
                        AddStok_MoveCabang = 1
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

End Class
