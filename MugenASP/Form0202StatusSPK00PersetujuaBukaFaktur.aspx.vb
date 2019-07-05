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
'1. Cari Halaman3
'2. Audit Save 
'3. Head Parts Save
'4. Cari Halaman1
'5. Cari Halaman2
'6. Cari Halaman4
'7. Auditor Save
'8. SM Save
'9. Account Save

'10 Cari
'11 Posisi 0 Setuju Parts  
'12 Posisi 1 Setuju SM 

'SECURITYH_USER c 15
'SECURITYH_NOID c 30

Partial Class Form0202StatusSPK00PersetujuaBukaFaktur
    Inherits System.Web.UI.Page
    Public MyRecReadA As OleDbDataReader
    Public MyRecReadB As OleDbDataReader
    Public MyRecReadC As OleDbDataReader
    Public MyRecReadD As OleDbDataReader
    Public MyRecReadF As OleDbDataReader
    Dim MySTRsql1 As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("LblUser"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = "Master page label = " + mpLabel.Text
        End If

        If LblUserNameLvl1.Text = "" Then
            Dim x As String
            Dim mFound As Byte = 0
            x = DirectCast(Session("MainContent"), String)
            LblUserNameLvl1.Text = UCase(x.ToString)
            mFound = GetDataA_UserSecurity("SELECT * FROM DATA_SECURITYU,DATA_SECURITYWA WHERE RTRIM(USER_ACCESS)=RTRIM(AKSES_KODE) AND USER_NAMA= '" & LblUserNameLvl1.Text & "' AND USER_TIPE='WA' AND AKSES_MENU='0105'")
            If mFound = 1 Then
                MultiViewUtama.ActiveViewIndex = 0
                MultiViewPekerjaan.ActiveViewIndex = 0
                MultiViewParts.ActiveViewIndex = 0
                MultiView0S.ActiveViewIndex = 0
                MultiView1S.ActiveViewIndex = 0
                Call DefinisTabelPekerjaan()
                Call DefinisTabelParts()
                Call DefinisTabelMohon()
                Call TampilkanData()
                MultiView11a.ActiveViewIndex = 0

            Else
                MultiViewUtama.ActiveViewIndex = -1
                Call Msg_err("TIDAK DIPERBOLEHKAN UNTUK MENGAKSES MENU INI", 0)
            End If
        End If
        Call Msg_err("", "")
    End Sub

    Protected Sub DefinisTabelMohon()
        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn(10) {New DataColumn("Temp_WEBAPPV_NOMOHON"), New DataColumn("Temp_WEBAPPV_INPUT"), _
                                               New DataColumn("Temp_WEBAPPV_NOWO"), New DataColumn("Temp_WEBAPPV_JUDUL"), _
                                               New DataColumn("Temp_WEBAPPV_ALASAN"), New DataColumn("Temp_WEBAPPV_SETUJU"), _
                                               New DataColumn("Temp_WEBAPPV_BATAL"), New DataColumn("Temp_WEBAPPV_APPROVED"), _
                                               New DataColumn("Temp_WEBAPPV_APPROVEDP"), New DataColumn("Temp_WEBAPPV_USER"), New DataColumn("Temp_WEBAPPV_DLR")})
        ViewState("Mohon") = dt
        Me.BindGridMohon()
    End Sub

    Protected Sub BindGridMohon()
        LvTabelMohon.DataSource = DirectCast(ViewState("Mohon"), DataTable)
        LvTabelMohon.DataBind()
    End Sub
    Sub insertTabelMohon(ByVal Type As Byte, ByVal Temp_WEBAPPV_NOMOHON As String, ByVal Temp_WEBAPPV_INPUT As String, ByVal Temp_WEBAPPV_NOWO As String, ByVal Temp_WEBAPPV_JUDUL As String, ByVal Temp_WEBAPPV_ALASAN As String, ByVal Temp_WEBAPPV_SETUJU As String, ByVal Temp_WEBAPPV_BATAL As String, ByVal Temp_WEBAPPV_APPROVED As String, ByVal Temp_WEBAPPV_APPROVEDP As String, ByVal Temp_WEBAPPV_USER As String, ByVal Temp_WEBAPPV_DLR As String)
        Dim dt As DataTable = DirectCast(ViewState("Mohon"), DataTable)

        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Temp_WEBAPPV_NOMOHON, Temp_WEBAPPV_INPUT, Temp_WEBAPPV_NOWO, Temp_WEBAPPV_JUDUL, Temp_WEBAPPV_ALASAN, Temp_WEBAPPV_SETUJU, Temp_WEBAPPV_BATAL, Temp_WEBAPPV_APPROVED, Temp_WEBAPPV_APPROVEDP, Temp_WEBAPPV_USER, Temp_WEBAPPV_DLR)
        End If
        ViewState("Mohon") = dt
        Me.BindGridMohon()
    End Sub




    Protected Sub DefinisTabelPekerjaan()
        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn(2) {New DataColumn("Tmp_PekerjaanKode"), New DataColumn("Tmp_PekerjaanDesc"), New DataColumn("Tmp_PekerjaanHarga")})
        ViewState("Pekerjaan") = dt
        Me.BindGridPekerjaan()
    End Sub
    Protected Sub BindGridPekerjaan()
        LvTabelPekerjaan.DataSource = DirectCast(ViewState("Pekerjaan"), DataTable)
        LvTabelPekerjaan.DataBind()
    End Sub
    Sub insertTabelPekerjaan(ByVal Type As Byte, ByVal Tmp_PekerjaanKode As String, ByVal Tmp_PekerjaanNama As String, ByVal Tmp_PekerjaanHarga As String)
        Dim dt As DataTable = DirectCast(ViewState("Pekerjaan"), DataTable)
        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Tmp_PekerjaanKode, Tmp_PekerjaanNama, Tmp_PekerjaanHarga)
            MultiViewPekerjaan.ActiveViewIndex = 0
        End If
        ViewState("Pekerjaan") = dt
        Me.BindGridPekerjaan()
    End Sub

    Protected Sub DefinisTabelParts()
        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn(4) {New DataColumn("Tmp_PartsKode"), New DataColumn("Tmp_PartsNama"), New DataColumn("Tmp_PartsQty"), New DataColumn("Tmp_PartsHrg"), New DataColumn("Tmp_PartsTot")})
        ViewState("Parts") = dt
        Me.BindGridParts()
    End Sub
    Protected Sub BindGridParts()
        LvTabelParts.DataSource = DirectCast(ViewState("Parts"), DataTable)
        LvTabelParts.DataBind()
    End Sub
    Sub insertTabelParts(ByVal Type As Byte, ByVal Tmp_PartsKode As String, ByVal Tmp_PartsNama As String, ByVal Tmp_PartsQty As String, ByVal Tmp_PartsHrg As String, ByVal Tmp_PartsTot As String)
        Dim dt As DataTable = DirectCast(ViewState("Parts"), DataTable)
        If Type = 0 Then
            dt.Clear()
        Else
            dt.Rows.Add(Tmp_PartsKode, Tmp_PartsNama, Tmp_PartsQty, Tmp_PartsHrg, Tmp_PartsTot)
            MultiViewParts.ActiveViewIndex = 0
        End If
        ViewState("Parts") = dt
        Me.BindGridParts()
    End Sub

    Protected Sub BtnKembali_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKembali1.Click
        Call Msg_err("", "")
        MultiViewUtama.ActiveViewIndex = 0
    End Sub

    Sub ClearForm()
        Call insertTabelParts(0, "", "", "", "", "")
        Call insertTabelPekerjaan(0, "", "", "")

        LblMohonAlasan.Text = "" : LblMohonMasalah.Text = "" : LblMohonTgl.Text = "" : LblMohonUser.Text = ""

        LblNoFaktur.Text = "" : LblNoFakturP.Text = ""
        LblTglInput.Text = "" : LblTglFaktur.Text = ""
        LblTglPartInput.Text = "" : LblTglPartFaktur.Text = ""

        LblFakturNama.Text = "" : LblFakturNopol.Text = ""
        LblFakturSA.Text = ""
        LblFakturTagihNama.Text = "" : LblFakturTagihNo.Text = ""
        lblFakturNorangka.Text = "" : lblFakturTahun.Text = ""
        LblFakturTipe.Text = "" : LblFakturCdType.Text = ""
        LblFakturWarna.Text = ""
        LblApproved.Text = "" : LblApprovedP.Text = ""

        LblJasaItem.Text = ""
        LblRpJasa.Text = ""
        LblRpDisc.Text = ""

        LblRpParts.Text = ""
        LblRpDPP.Text = ""
        LblRpPPN.Text = ""
        LblRpTotal.Text = ""

        LblPartsItem.Text = ""
        LblPartsQty.Text = ""
        LblPartsTotal.Text = ""
        LblPartsDisc.Text = ""
        LblPartsDisc0.Text = ""
        LblPartsDPP.Text = ""

        Label15.Text = "" 'PPN
        Label22.Text = "" 'TOTAL 


        lblTglsetuju0.Text = "" : TxtCatatan0.Text = ""
        lblTglSetuju1.Text = "" : TxtCatatan1.Text = ""

    End Sub




    Protected Sub ButtonSetuju0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetuju0.Click
        BtnTolak0.Enabled = False
        Call Rubah_Status("SETUJU", 1)
        BtnTolak0.Enabled = True
    End Sub
    Protected Sub BtnTolak0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTolak0.Click
        Call Rubah_Status("TOLAK", 1)
    End Sub

    Protected Sub ButtonSetuju1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetuju1.Click
        BtnTolak1.Enabled = False
        Call Rubah_Status("SETUJU", 2)
        BtnTolak1.Enabled = True
    End Sub
    Protected Sub BtnTolak1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTolak1.Click
        Call Rubah_Status("TOLAK", 2)
    End Sub




    Sub Rubah_Status(ByVal mStatus As String, ByVal mLevel As Byte)
        Dim mError As String = ""
        Dim mIsi As String = ""

        If InStr(lblArea1Lvl1.Text, lblDealer.Text) = 0 And InStr(lblArea2Lvl1.Text, lblDealer.Text) = 0 Then
            mError = mError & ("Tidak bisa merubah untuk kode dealer " & lblDealer.Text)
        ElseIf LblFakturNopol.Text = "" And mStatus <> "TOLAK" Then
            mError = mError & ("Lihat di Kotak Masalah ")
        ElseIf Mid(lblAksesLvl1.Text, 11, 1) <> "1" And mLevel = 1 Then
            mError = mError & ("Anda Tidak diperbolehkan melakukan persetujuan oleh Head Parts .....")
        ElseIf Mid(lblAksesLvl1.Text, 12, 1) <> "1" And mLevel = 2 Then
            mError = mError & ("Anda Tidak diperbolehkan melakukan persetujuan oleh Service Manager .....")
        ElseIf (LblMohonMasalah.Text) <> "" And mStatus <> "TOLAK" Then
            mError = mError & ("Proses tidak bisa dilanjutkan lihat Masalahnya !!!!! .....")
        ElseIf MultiView0S.ActiveViewIndex = 0 And lblTglsetuju0.Text = "" And mLevel = 1 Then   'Head Parts
            If TxtCatatan0.Text = "" Then
                mError = mError & ("Catatan Head Parts belum diisi .....")
            Else
                mIsi = TxtCatatan0.Text
            End If
        ElseIf MultiView1S.ActiveViewIndex = 0 And lblTglSetuju1.Text = "" And mLevel = 2 Then   'SM Validasi
            If TxtCatatan1.Text = "" Then
                mError = mError & ("Catatan Service Manager belum diisi .....")
            Else
                mIsi = TxtCatatan1.Text
            End If

        End If

        If mError = "" And mIsi <> "" Then
            Call UpdateDataMohon(LblMohonNomor.Text, mStatus, mIsi, mLevel)
        Else
            Call Msg_err(IIf(mError = "", "SUDAH DIAKUKAN DISETUJUI/DITOLAK", mError), "LIHAT")
        End If
    End Sub
    Function UpdateDataMohon(ByVal mIdNo As String, ByVal mSetujuTolak As String, ByVal mCatatan As String, ByVal mPosisi As String) As Byte
        Call Msg_err("", "")
        UpdateDataMohon = 0
        Dim mTextSql As String = ""
        Dim mUpdateAprovedProses As String = ""

        If mPosisi = "1" And (lblTglsetuju0.Text = "") Then
            lblTglsetuju0.Text = UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi)
            If lblTglsetuju0.Text <> "" Then
                If InStr(LblApproved.Text, "0") <> 0 Then
                    mUpdateAprovedProses = "0"
                End If
                If InStr(LblApproved.Text, "1") <> 0 Then
                    mUpdateAprovedProses = mUpdateAprovedProses & mPosisi
                End If
            End If
        ElseIf mPosisi = "2" And lblTglSetuju1.Text = "" Then
            lblTglSetuju1.Text = UpdateSetujuDataUser(mIdNo, mSetujuTolak, mCatatan, mPosisi)
            If lblTglSetuju1.Text <> "" Then
                mUpdateAprovedProses = mPosisi
            End If
        End If

        If mUpdateAprovedProses <> "" Then

            Dim mPosTerakhir As String
            mPosTerakhir = ""
            If MultiView1S.ActiveViewIndex = 0 Then
                mPosTerakhir = "2"
            ElseIf MultiView0S.ActiveViewIndex = 0 Then
                mPosTerakhir = "1"
            End If
            Dim mSukses As Byte = 0

            If mPosTerakhir = mPosisi Or mSetujuTolak = "TOLAK" Then
                mSukses = Update_Tabel_SPKAH_Keputusan_Terakhir(mIdNo, mSetujuTolak, mCatatan, mUpdateAprovedProses)
            Else
                mTextSql = "UPDATE TRXN_WEBAPPV SET WEBAPPV_APPROVEDP=WEBAPPV_APPROVEDP + '" & "" & mUpdateAprovedProses & "' " & _
                           "WHERE WEBAPPV_NOMOHON = '" & LblMohonNomor.Text & "'"
                mSukses = UpdateDatabase_Tabel(mTextSql, "MyConnCloudDnetSvcM" & lblDealer.Text)
            End If

            If mSukses = 1 Then
                Dim mTujuanEmail As String = ""

                If lblDealer.Text = "112" Then
                    mTujuanEmail = "SA_service@hondamugen.co.id"
                Else
                    mTujuanEmail = "Bengkel_puri@hondamugen.co.id"
                End If
                If mPosisi = "0" Or mPosisi = "1" Then
                    If lblDealer.Text = "112" Then
                        mTujuanEmail = mTujuanEmail & ",Bengkel@hondamugen.co.id"
                    Else
                        mTujuanEmail = mTujuanEmail & ",didi.musdianto@hondamugen.co.id"
                    End If
                End If
                Call SendEmailProces(mTujuanEmail, "Permohonan persetujuan Batal Faktur Untuk No Faktur " & LblNoFaktur.Text & " Cabang " & lblDealer.Text, "", "", "Permohonan persetujuan Batal Faktur Untuk No Faktur " & LblNoFaktur.Text & " Cabang " & lblDealer.Text & " di tanggal " & Now() & " status " & mSetujuTolak & " Oleh " & LblUserNameLvl1.Text, 0)
            Else
                mTextSql = "DELETE from TRXN_WEBAPPVUSR where WEBAPPVUSR_NOMOHON ='" & LblMohonNomor.Text & "' and WEBAPPVUSR_USER ='" & LblUserNameLvl1.Text & "'"
                Call UpdateDatabase_Tabel(mTextSql, "MyConnCloudDnetSvcM" & lblDealer.Text)
                If mPosisi = "1" Then
                    lblTglsetuju0.Text = ""
                ElseIf mPosisi = "2" Then
                    lblTglSetuju1.Text = ""
                End If

            End If
        End If
    End Function
    Function UpdateSetujuDataUser(ByVal mpIdMohon As String, ByVal mREASON As String, ByVal mCatat As String, ByVal mPos As String) As String
        Call Msg_err("", "")
        Dim mDisetujuiOleh As String = mPos
        Dim UserNameJob As String = ""

        UpdateSetujuDataUser = ""


        If mPos = "1" Then
            If InStr(LblApproved.Text, "0") <> 0 Then
                mDisetujuiOleh = "0"
            End If
        End If
        UserNameJob = ""
        If InStr(LblMohonJudul.Text, "BATAL FAKTUR JASA") <> 0 And mDisetujuiOleh = "2" Then
            UserNameJob = mDisetujuiOleh
        ElseIf InStr(LblMohonJudul.Text, "BATAL") <> 0 And mDisetujuiOleh = "1" Then
            UserNameJob = mDisetujuiOleh
        ElseIf InStr(LblMohonJudul.Text, "HAPUS") <> 0 And mDisetujuiOleh = "0" Then
            UserNameJob = mDisetujuiOleh
        End If


        If UpdateDatabase_Tabel("INSERT INTO TRXN_WEBAPPVUSR " & _
                                "(WEBAPPVUSR_NOMOHON, WEBAPPVUSR_USER, WEBAPPVUSR_TGL, WEBAPPVUSR_CATATAN, WEBAPPVUSR_STATUS, WEBAPPVUSR_LEVEL, WEBAPPVUSR_LEVELJOB, WEBAPPVUSR_CLOSETGL, WEBAPPVUSR_CLOSEUSER) VALUES " & _
                                "('" & mpIdMohon & "','" & LblUserNameLvl1.Text & "',GETDATE(),'" & mCatat & "','" & _
                                IIf(mREASON = "TOLAK", "0", "1") & "','" & mDisetujuiOleh & "','" & UserNameJob & "',NULL,'')", _
                                 "MyConnCloudDnetSvcM" & lblDealer.Text) = 1 Then
            UpdateSetujuDataUser = Now() & "/" & LblUserNameLvl1.Text & "/" & mREASON
            If mDisetujuiOleh = "0" And InStr(LblApproved.Text, "1") <> 0 Then
                mDisetujuiOleh = "1"
                Call UpdateDatabase_Tabel("INSERT INTO TRXN_WEBAPPVUSR " & _
                                        "(WEBAPPVUSR_NOMOHON, WEBAPPVUSR_USER, WEBAPPVUSR_TGL, WEBAPPVUSR_CATATAN, WEBAPPVUSR_STATUS, WEBAPPVUSR_LEVEL, WEBAPPVUSR_LEVELJOB,WEBAPPVUSR_CLOSETGL, WEBAPPVUSR_CLOSEUSER) VALUES " & _
                                        "('" & mpIdMohon & "','" & LblUserNameLvl1.Text & "',GETDATE(),'" & mCatat & "','" & _
                                        IIf(mREASON = "TOLAK", "0", "1") & "','" & mDisetujuiOleh & "','" & mDisetujuiOleh & "',NULL,'')", _
                                        "MyConnCloudDnetSvcM" & lblDealer.Text)
            End If
        End If
    End Function
    Function Update_Tabel_SPKAH_Keputusan_Terakhir(ByVal mIdnom As String, ByVal Reason As String, ByVal mCatat As String, ByVal mPosTerakhir As String) As Byte
        Call Msg_err("", "")
        Dim mUpdateChange As String = ""
        Update_Tabel_SPKAH_Keputusan_Terakhir = 0
        Update_Tabel_SPKAH_Keputusan_Terakhir = UpdateDatabase_Tabel("UPDATE TRXN_WEBAPPV SET " & _
                                      IIf(Reason = "TOLAK", "WEBAPPV_BATAL=GETDATE(), ", "WEBAPPV_SETUJU=GETDATE(), ") & _
                                      "WEBAPPV_CHANGE1='" & LblJasaItem.Text & "',WEBAPPV_CHANGE2='" & LblRpJasa.Text & "',WEBAPPV_CHANGE3='" & LblRpDisc.Text & "', " & _
                                      "WEBAPPV_CHANGE4='" & LblPartsItem.Text & "',WEBAPPV_CHANGE5='" & LblPartsQty.Text & "',WEBAPPV_CHANGE6='" & LblPartsDPP.Text & "', " & _
                                      "WEBAPPV_APPROVEDP=WEBAPPV_APPROVEDP + '" & "" & mPosTerakhir & "' " & _
                                      "WHERE WEBAPPV_NOMOHON='" & mIdnom & "'", _
                                       "MyConnCloudDnetSvcM" & lblDealer.Text)
    End Function

    Sub Msg_err(ByVal mTest As String, ByVal mShow As String)
        lblMsgBox.Text = mTest
        If mTest = "" Then
            MultiViewError.ActiveViewIndex = 0
        Else
            MultiViewError.ActiveViewIndex = 0
        End If
        If mTest <> "" Then
            Response.Write("<script>alert('" & mTest & "')</script>")
        End If
        If mShow = "MASALAH" Then
            LblMohonMasalah.Text = LblMohonMasalah.Text & mTest
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call TampilkanData()
        MultiView11a.ActiveViewIndex = 0

        'Call SendEmailProces("e13nusas@gmail.com,mis@hondamugen.co.id", "Permohonan persetujuan Batal Faktur Untuk No Faktur " & LblNoFaktur.Text & " Cabang " & lblDealer.Text, "", "", "Permohonan persetujuan Batal Faktur Untuk No Faktur " & LblNoFaktur.Text & " Cabang " & lblDealer.Text & " di tanggal " & Now() & " status " & "TESt" & " Oleh " & LblUserNameLvl1.Text, 0)

    End Sub

    Sub TampilkanData()
        Dim mQuery As String = " (WEBAPPV_SETUJU IS NULL AND WEBAPPV_BATAL IS NULL)"
        Call insertTabelMohon(0, "", "", "", "", "", "", "", "", "", "", "")

        If Mid(lblAksesLvl1.Text, 11, 1) = "1" Then
            mQuery = mQuery & " AND (WEBAPPV_APPROVED like '%0%' OR WEBAPPV_APPROVED like '%1%')"
        ElseIf Mid(lblAksesLvl1.Text, 12, 1) = "1" Then
            mQuery = mQuery & " AND ((WEBAPPV_APPROVED like '2' AND WEBAPPV_APPROVEDP = '') or (WEBAPPV_APPROVED like '%2%' AND WEBAPPV_APPROVEDP <> ''))"
        End If

        Call GetDataMaster_Tabel_Pemohonan("SELECT * FROM TRXN_WEBAPPV WHERE " & mQuery, "MyConnCloudDnetSvcM" & lblArea1Lvl1.Text, lblArea1Lvl1.Text)
        If lblArea1Lvl1.Text <> lblArea2Lvl1.Text Then
            Call GetDataMaster_Tabel_Pemohonan("SELECT * FROM TRXN_WEBAPPV WHERE " & mQuery, "MyConnCloudDnetSvcM" & lblArea2Lvl1.Text, lblArea2Lvl1.Text)
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
            Call Msg_err(error_t.ToString, 1)
        End Try
    End Function


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
            Call UpdateDatabase_Tabel("UPDATE TRXN_OPTPO SET OPT_STATUSPROSES = '" & mResult & "' WHERE OPT_NODEALER='" & lblDealer.Text & "' AND OPT_NOSPK='" & LblNoFaktur.Text & "' AND OPT_CDASS='" & mKode & "'  AND (OPT_STATUSPROSES like '%" & mKeterangan & "%')", "")
        End If
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
    Function DtFrSQL(ByRef mNilai As Object) As String
        On Error GoTo ErrHand
        DtFrSQL = "NULL"
        If IsDate(mNilai) Then
            DtFrSQL = "'" & Format(CDate(mNilai), "yyyy-MM-dd HH:MM:ss") & "'"
        End If
ErrHand:
    End Function
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
                lblAksesLvl1.Text = nSr(MyRecReadA("AKSES_DATA"))
                lblArea1Lvl1.Text = nSr(MyRecReadA("AKSES_AREA"))
                lblArea2Lvl1.Text = lblArea1Lvl1.Text
                If Len(lblArea1Lvl1.Text) > 3 Then
                    lblArea1Lvl1.Text = Mid(nSr(MyRecReadA("AKSES_AREA")), 1, 3)
                    lblArea2Lvl1.Text = Mid(nSr(MyRecReadA("AKSES_AREA")), 4, 3)
                End If
            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err("error " & ex.Message, 0)
        End Try
    End Function
    Function UpdateDatabase_Tabel(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
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
            Call Msg_err(ex.Message, 0)
        End Try
    End Function
    Function GetDataD_IsiField(ByVal mSqlCommadstring As String, ByVal mpServer As String) As String
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
            Call Msg_err(ex.Message, 0)
        End Try
    End Function
    Function GetDataD_00NoFound01Found(ByVal mSqlCommadstring As String, ByVal mpServer As String) As Byte
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
            Call Msg_err(ex.Message, 0)
        End Try
    End Function



    '---------
    Function GetDataMaster_Tabel_Pemohonan(ByVal mSqlCommadstring As String, ByVal mServer As String, ByVal mDlr As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim lblMohonDetailAlasan As String = ""
        Call Msg_err("", "")
        GetDataMaster_Tabel_Pemohonan = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataMaster_Tabel_Pemohonan = IIf(MyRecReadA.HasRows = True, 1, 0)
            If GetDataMaster_Tabel_Pemohonan = 1 Then
                While MyRecReadA.Read()
                    Call insertTabelMohon(1, nSr(MyRecReadA("WEBAPPV_NOMOHON")), nSr(MyRecReadA("WEBAPPV_INPUT")), nSr(MyRecReadA("WEBAPPV_NOWO")), _
                                             nSr(MyRecReadA("WEBAPPV_JUDUL")), nSr(MyRecReadA("WEBAPPV_ALASAN")), nSr(MyRecReadA("WEBAPPV_SETUJU")), _
                                             nSr(MyRecReadA("WEBAPPV_BATAL")), nSr(MyRecReadA("WEBAPPV_APPROVED")), nSr(MyRecReadA("WEBAPPV_APPROVEDP")), _
                                             nSr(MyRecReadA("WEBAPPV_USER")), mDlr)
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetDataA_Tabel_Pemohonan(ByVal mSqlCommadstring As String, ByVal mServer As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim lblMohonDetailAlasan As String = ""
        Call Msg_err("", "")
        GetDataA_Tabel_Pemohonan = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_Pemohonan = IIf(MyRecReadA.HasRows = True, 1, 0)
            If GetDataA_Tabel_Pemohonan = 1 Then
                While MyRecReadA.Read()

                    LblMohonJudul.Text = nSr(MyRecReadA("WEBAPPV_JUDUL"))
                    LblMohonAlasan.Text = nSr(MyRecReadA("WEBAPPV_ALASAN"))
                    LblMohonMasalah.Text = ""
                    LblMohonTgl.Text = nSr(MyRecReadA("WEBAPPV_INPUT"))
                    LblMohonUser.Text = nSr(MyRecReadA("WEBAPPV_USER")) '---------------> Belum
                    LblNoFaktur.Text = nSr(MyRecReadA("WEBAPPV_NOWO"))
                    LblApproved.Text = nSr(MyRecReadA("WEBAPPV_APPROVED"))
                    LblApprovedP.Text = nSr(MyRecReadA("WEBAPPV_APPROVEDP"))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function
    Function GetDataA_Tabel_PemohonanSetuju(ByVal mSqlCommadstring As String, ByVal mServer As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim lblMohonDetailAlasan As String = ""
        Call Msg_err("", "")
        GetDataA_Tabel_PemohonanSetuju = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_PemohonanSetuju = IIf(MyRecReadA.HasRows = True, 1, 0)
            If GetDataA_Tabel_PemohonanSetuju = 1 Then
                While MyRecReadA.Read()
                    If nSr(MyRecReadA("WEBAPPVUSR_LEVEL")) = "0" Or nSr(MyRecReadA("WEBAPPVUSR_LEVEL")) = "1" Then
                        lblTglsetuju0.Text = nSr(MyRecReadA("WEBAPPVUSR_TGL"))
                        lblUserSetuju0.Text = nSr(MyRecReadA("WEBAPPVUSR_USER"))
                        TxtCatatan0.Text = ""
                        If nSr(MyRecReadA("WEBAPPVUSR_STATUS")) <> "" Then
                            TxtCatatan0.Text = IIf(nSr(MyRecReadA("WEBAPPVUSR_STATUS")) = "0", "TOLAK", "SETUJU")
                            TxtCatatan0.Text = TxtCatatan0.Text & nSr(MyRecReadA("WEBAPPVUSR_CATATAN"))
                        End If
                    End If
                    If nSr(MyRecReadA("WEBAPPVUSR_LEVEL")) = "2" Then
                        lblTglSetuju1.Text = nSr(MyRecReadA("WEBAPPVUSR_TGL"))
                        lblUserSetuju1.Text = nSr(MyRecReadA("WEBAPPVUSR_USER"))
                        TxtCatatan1.Text = ""
                        If nSr(MyRecReadA("WEBAPPVUSR_STATUS")) <> "" Then
                            TxtCatatan1.Text = IIf(nSr(MyRecReadA("WEBAPPVUSR_STATUS")) = "0", "TOLAK", "SETUJU")
                            TxtCatatan1.Text = TxtCatatan1.Text & nSr(MyRecReadA("WEBAPPVUSR_CATATAN"))
                        End If
                    End If


                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    '------------
    Function GetDataA_Faktur(ByVal mSqlCommadstring As String, ByVal mServer As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Faktur = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Faktur = IIf(MyRecReadA.HasRows = True, 1, 0)
            If GetDataA_Faktur = 1 Then
                While MyRecReadA.Read()
                    LblTglInput.Text = nSr(MyRecReadA("WOHDR_TGWO"))
                    LblTglFaktur.Text = nSr(MyRecReadA("WOHDR_TGFAK"))
                    LblFakturNama.Text = nSr(MyRecReadA("WOHDR_FORG"))
                    LblFakturNopol.Text = nSr(MyRecReadA("WOHDR_FNOPOL"))
                    LblFakturSA.Text = nSr(MyRecReadA("WOHDR_SA"))
                    lblFakturNorangka.Text = nSr(MyRecReadA("WOHDR_FNRK")) : lblFakturTahun.Text = nSr(MyRecReadA("WOHDR_FTH"))

                    LblFakturTagihNo.Text = nSr(MyRecReadA("WOHDR_KDTAGIH")) : LblFakturTagihNama.Text = nSr(MyRecReadA("SUPPLIER_NAMA"))
                    LblFakturTipe.Text = "" : LblFakturCdType.Text = nSr(MyRecReadA("WOHDR_FTYP"))
                    LblFakturWarna.Text = nSr(MyRecReadA("WOHDR_FWAR"))
                    LblKerja.Text = ""
                    If nSr(MyRecReadA("WOHDR_JNSKERJA")) = "0" Then
                        LblKerja.Text = "PM/Quick Service"
                    ElseIf nSr(MyRecReadA("WOHDR_JNSKERJA")) = "1" Then
                        LblKerja.Text = "PM-Repair"
                    ElseIf nSr(MyRecReadA("WOHDR_JNSKERJA")) = "2" Then
                        LblKerja.Text = "Repair"
                    ElseIf nSr(MyRecReadA("WOHDR_JNSKERJA")) = "3" Then
                        LblKerja.Text = "Body Repair"
                    End If
                    LblRpJasa.Text = nSr(MyRecReadA("WOHDR_TOTSERVICE"))
                    LblRpDisc.Text = nSr(MyRecReadA("WOHDR_DISC"))
                    LblRpParts.Text = nSr(MyRecReadA("WOHDR_TOTPARTS"))
                    LblRpDPP.Text = nLg(MyRecReadA("WOHDR_TOTSERVICE")) - nLg(MyRecReadA("WOHDR_DISC")) + nLg(MyRecReadA("WOHDR_TOTPARTS"))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "MASALAH")
        End Try
    End Function
    Function GetDataA_Tabel_Pekerjaan(ByVal mSqlCommadstring As String, ByVal mServer As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Tabel_Pekerjaan = 0

        cnn = New OleDbConnection(strconn)
        LblJasaItem.Text = ""
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Tabel_Pekerjaan = IIf(MyRecReadA.HasRows = True, 1, 0)
            If GetDataA_Tabel_Pekerjaan = 1 Then
                While MyRecReadA.Read()
                    LblJasaItem.Text = nLg(LblJasaItem.Text) + 1
                    Call insertTabelPekerjaan(1, nSr(MyRecReadA("WOKERJA_KERJACD")), nSr(MyRecReadA("WOKERJA_KERJADESC")), nSr(MyRecReadA("WOKERJA_HARGA")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    '------------
    Function GetDataA_PartFaktur(ByVal mSqlCommadstring As String, ByVal mServer As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_PartFaktur = 0

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_PartFaktur = IIf(MyRecReadA.HasRows = True, 1, 0)
            If GetDataA_PartFaktur = 1 Then
                While MyRecReadA.Read()

                    LblTglPartInput.Text = nSr(MyRecReadA("PARTJUALH_TGPRO"))
                    LblTglPartFaktur.Text = nSr(MyRecReadA("PARTJUALH_TGL"))
                    LblPartsItem.Text = nSr(MyRecReadA("PARTJUALH_TITEMS"))
                    LblPartsQty.Text = nSr(MyRecReadA("PARTJUALH_TQTY"))
                    LblPartsTotal.Text = nLg(MyRecReadA("PARTJUALH_JRP")) + nLg(MyRecReadA("PARTJUALH_RPD"))
                    LblPartsDisc.Text = nSr(MyRecReadA("PARTJUALH_RPD"))
                    LblPartsDisc0.Text = ""
                    LblPartsDPP.Text = nSr(MyRecReadA("PARTJUALH_JRP"))

                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "MASALAH")
        End Try
    End Function
    Function GetDataA_TabelParts(ByVal mSqlCommadstring As String, ByVal mServer As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_TabelParts = 0

        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_TabelParts = IIf(MyRecReadA.HasRows = True, 1, 0)
            If GetDataA_TabelParts = 1 Then
                While MyRecReadA.Read()
                    Call insertTabelParts(1, nSr(MyRecReadA("PARTJUALD_PN")), nSr(MyRecReadA("PARTJUALD_PNNAME")), nSr(MyRecReadA("PARTJUALD_QTY")), nSr(MyRecReadA("PARTJUALD_HGJUAL")), nSr(MyRecReadA("PARTJUALD_RPSAL")))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            Call Msg_err(ex.Message, "")
        End Try
    End Function

    Function GetDataA_Validasi_Faktur(ByVal mSqlCommadstring As String, ByVal mSqlFindFiled As String, ByVal mServer As String) As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings(mServer).ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Call Msg_err("", "")
        GetDataA_Validasi_Faktur = "0"
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetDataA_Validasi_Faktur = IIf(MyRecReadA.HasRows = True, 1, 0)
            If GetDataA_Validasi_Faktur = 1 Then
                While MyRecReadA.Read()
                    'LblNoSPK.Text = nSr(MyRecReadA("OPT_NOSPK"))
                End While
            End If
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
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
    Function InputDT(ByVal mYr As String, ByVal mMt As String, ByVal mDy As String, ByVal mHh As String, ByVal mMm As String, ByVal mSs As String, ByVal mDt As String) As Date
        If mDt <> "" And mYr = "" Then mYr = CStr(Year(CDate(mDt)))
        If mDt <> "" And mMt = "" Then mMt = CStr(Month(CDate(mDt)))
        If mDt <> "" And mDy = "" Then mDy = CStr(Microsoft.VisualBasic.Day(CDate(mDt)))
        If mDt <> "" And mHh = "" Then mHh = CStr(Hour(CDate(mDt)))
        If mDt <> "" And mMm = "" Then mMm = CStr(Minute(CDate(mDt)))
        If mDt <> "" And mSs = "" Then mSs = CStr(Second(CDate(mDt)))
        InputDT = New DateTime(mYr, mMt, mDy, mHh, mMm, mSs)
    End Function
    Function nSrNl(ByRef nilai As Object, ByRef mOutput As Object) As String
        If Not IsDBNull(nilai) Then
            nSrNl = nilai
        Else
            nSrNl = mOutput
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

    Sub TblMohonView_SelectedIndexChanging(ByVal sender As Object, ByVal e As ListViewSelectEventArgs)
        Dim item As ListViewItem = CType(LvTabelMohon.Items(e.NewSelectedIndex), ListViewItem)
        Dim mKode As Label = CType(item.FindControl("Lbl_WEBAPPV_NOMOHON"), Label)
        LblMohonNomor.Text = mKode.Text
        mKode = CType(item.FindControl("Lbl_WEBAPPV_DLR"), Label)
        lblDealer.Text = mKode.Text

        Call ClearForm()
        If LblMohonNomor.Text <> "" And lblDealer.Text <> "" Then
            Call Msg_err("", "")
            MultiViewUtama.ActiveViewIndex = 1
            MultiViewPekerjaan.ActiveViewIndex = 0
            MultiViewParts.ActiveViewIndex = 0
            MultiView0S.ActiveViewIndex = 0
            MultiView1S.ActiveViewIndex = 0

            Call GetDataA_Tabel_Pemohonan("SELECT * FROM TRXN_WEBAPPV WHERE WEBAPPV_NOMOHON='" & LblMohonNomor.Text & "'", "MyConnCloudDnetSvcM" & lblDealer.Text)
            If LblNoFaktur.Text <> "" Then
                Call GetDataA_Tabel_PemohonanSetuju("SELECT * FROM TRXN_WEBAPPVUSR WHERE WEBAPPVUSR_NOMOHON='" & LblMohonNomor.Text & "'", "MyConnCloudDnetSvcM" & lblDealer.Text)
                Call GetDataA_Faktur("SELECT * FROM TRXN_WOHDR,DATA_SUPPLIER  WHERE WOHDR_KDTAGIH=SUPPLIER_KODE AND WOHDR_NO='" & LblNoFaktur.Text & "'", "MyConnCloudDnetSvcs" & lblDealer.Text)
                Call GetDataA_Tabel_Pekerjaan("SELECT * FROM TRXN_WOKERJA WHERE WOKERJA_NOWO='" & LblNoFaktur.Text & "'", "MyConnCloudDnetSvcs" & lblDealer.Text)
                If IsNumeric(Left(LblNoFaktur.Text, 1)) Then
                    LblNoFakturP.Text = "B/" & LblNoFaktur.Text
                Else
                    LblNoFakturP.Text = LblNoFaktur.Text
                End If
                Call GetDataA_PartFaktur("SELECT * FROM TRXN_PARTJUALH WHERE PARTJUALH_NOFAK='" & LblNoFakturP.Text & "'", "MyConnCloudDnetSvcs" & lblDealer.Text)
                Call GetDataA_TabelParts("SELECT * FROM TRXN_PARTJUALD,DATA_PARTS WHERE PARTJUALD_PN=PARTS_NO AND  PARTJUALD_NOFAK='" & LblNoFakturP.Text & "'", "MyConnCloudDnetSvcs" & lblDealer.Text)
                If LblMohonMasalah.Text = "" And LblTglInput.Text = "" And LblTglPartInput.Text = "" Then
                    LblMohonMasalah.Text = "FAKTUR SUDAH DI POSTING TIDAKBISA DIBATALKAN"
                End If
            End If
        End If

    End Sub

    Protected Sub TblMohonView_PagePropertiesChanging(ByVal sender As Object, ByVal e As PagePropertiesChangingEventArgs)
        ' Clears the selection.
        LvTabelMohon.SelectedIndex = -1
    End Sub



    '    USE [SERVICESOTHERS]
    'CREATE TABLE [dbo].[TRXN_WEBAPPV]('
    '	[WEBAPPV_NOWO] [nvarchar](10) NULL,
    '	[WEBAPPV_JUDUL] [nvarchar](150) NULL,
    '	[WEBAPPV_DEALER] [nvarchar](3) NULL,
    '	[WEBAPPV_NOMOHON] [nvarchar](20) NULL,
    '	[WEBAPPV_PROSES] [smalldatetime] NULL,
    '	[WEBAPPV_INPUT] [smalldatetime] NULL,
    '	[WEBAPPV_SETUJU] [smalldatetime] NULL,
    '	[WEBAPPV_ALASAN] [nvarchar](200) NULL,
    '	[WEBAPPV_KODE] [nvarchar](5) NULL,
    '	[WEBAPPV_APPROVED] [nvarchar](10) NULL,
    '	[WEBAPPV_APPROVEDP] [nvarchar](10) NULL,
    '	[WEBAPPV_CHANGE1] [nvarchar](50) NULL,
    '	[WEBAPPV_CHANGE2] [nvarchar](50) NULL,
    '	[WEBAPPV_CHANGE3] [nvarchar](50) NULL



    '    USE [SERVICESOTHERS]
    'CREATE TABLE [dbo].[TRXN_WEBAPPVUSR](
    '	[WEBAPPVUSR_NOMOHON] [nvarchar](20) NULL,
    '	[WEBAPPVUSR_USER] [nvarchar](20) NULL,
    '	[WEBAPPVUSR_TGL] [smalldatetime] NULL,
    '	[WEBAPPVUSR_CATATAN] [nvarchar](150) NULL,
    '	[WEBAPPVUSR_STATUS] [nvarchar](1) NULL
End Class
