Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Partial Class formChecklistSUV
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("username") = Nothing Then
            Response.Redirect("default.aspx")
        Else
            tglMasuk.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")

        End If
        ' If CType(Session.Item("username"), String) = "1" Then
        'End If

    End Sub


    Protected Sub simpan_Click(sender As Object, e As EventArgs)
        Dim nopol1, kode, kondisi, keterangan, tglMasuk1, jawaban, ordometer1, catatan1 As String
        Dim battery, ukuranBanDepanKiri, kondisiBanDepanKiri1, ukuranBanDepanKanan, kondisiBanDepanKanan1, keteranganBanDepan1 As String
        Dim ukuranBanBelakangKiri, kondisiBanBelakangKiri1, ukuranBanBelakangKanan, kondisiBanBelakangKanan1, keteranganBanBelakang1, bensin1 As String
        Dim petugas As String = CType(Session.Item("username"), String)
        If nopol.Text = "" Then
            nopolNotice.Text = "No Polisi Wajib Diisi"
        ElseIf ordometer.Text = "" Then
            ordometerNotice.Text = "Ordometer Wajib Diisi"
        Else

            catatan1 = catatan.Text
            nopol1 = nopol.Text
            nopol1 = nopol1.ToUpper()
            tglMasuk1 = tglMasuk.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTH(nopol, tglMasuk, petugasAwal, kategori, catatan) VALUES('" + nopol1 + "','" + tglMasuk1 + "','" + petugas + "','1','" + catatan1 + "')")
            If kondisiBaterai.Text <> "" Then
                battery = kondisiBaterai.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','A','" + battery + "','" + tglMasuk1 + "')")
            End If

            If banDepanKiri.Text <> "" Then
                ukuranBanDepanKiri = banDepanKiri.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','B','" + ukuranBanDepanKiri + "','" + tglMasuk1 + "')")
            End If

            If kondisiBanDepanKiri.Text <> "" Then
                kondisiBanDepanKiri1 = kondisiBanDepanKiri.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','C','" + kondisiBanDepanKiri1 + "','" + tglMasuk1 + "')")
            End If

            If banDepanKanan.Text <> "" Then
                ukuranBanDepanKanan = banDepanKanan.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','D','" + ukuranBanDepanKanan + "','" + tglMasuk1 + "')")
            End If

            If kondisiBanDepanKanan.Text <> "" Then
                kondisiBanDepanKanan1 = kondisiBanDepanKanan.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','E','" + kondisiBanDepanKanan1 + "','" + tglMasuk1 + "')")
            End If

            If keteranganBanDepan.Text <> "" Then
                keteranganBanDepan1 = keteranganBanDepan.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','F','" + keteranganBanDepan1 + "','" + tglMasuk1 + "')")
            End If

            If banBelakangKiri.Text <> "" Then
                ukuranBanBelakangKiri = banBelakangKiri.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','G','" + ukuranBanBelakangKiri + "','" + tglMasuk1 + "')")
            End If

            If kondisiBanBelakangKiri.Text <> "" Then
                kondisiBanBelakangKiri1 = kondisiBanBelakangKiri.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','H','" + kondisiBanBelakangKiri1 + "','" + tglMasuk1 + "')")
            End If

            If banBelakangKanan.Text <> "" Then
                ukuranBanBelakangKanan = banBelakangKanan.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','I','" + ukuranBanBelakangKanan + "','" + tglMasuk1 + "')")
            End If

            If kondisiBanBelakangKanan.Text <> "" Then
                kondisiBanBelakangKanan1 = kondisiBanBelakangKanan.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','J','" + kondisiBanBelakangKanan1 + "','" + tglMasuk1 + "')")
            End If

            If keteranganBanBelakang.Text <> "" Then
                keteranganBanBelakang1 = keteranganBanBelakang.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','K','" + keteranganBanBelakang1 + "','" + tglMasuk1 + "')")
            End If

            If bensin.Text <> "" Then
                bensin1 = bensin.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','L','" + bensin1 + "','" + tglMasuk1 + "')")
            End If

            If ordometer.Text <> "" Then
                ordometer1 = ordometer.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','M','" + ordometer1 + "','" + tglMasuk1 + "')")
            End If

            If stnkMasuk.Checked Then
                kode = "AKS1"
                keterangan = stnk.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If kasetMasuk.Checked Then
                kode = "AKS2"
                keterangan = kaset.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If uangMasuk.Checked Then
                kode = "AKS3"
                keterangan = uang.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If pemantikApiMasuk.Checked Then
                kode = "AKS4"
                keterangan = pemantikApi.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If karpetMasuk.Checked Then
                kode = "AKS5"
                keterangan = karpet.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If bukuServiceMasuk.Checked Then
                kode = "AKS6"
                keterangan = bukuService.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If velgMasuk.Checked Then
                kode = "AKS7"
                keterangan = velg.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If bukuMasuk.Checked Then
                kode = "AKS8"
                keterangan = buku.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If toolKitMasuk.Checked Then
                kode = "AKS9"
                keterangan = toolKit.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If dongkrakMasuk.Checked Then
                kode = "AKS10"
                keterangan = dongkrak.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If banMasuk.Checked Then
                kode = "AKS11"
                keterangan = ban.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If coverBanMasuk.Checked Then
                kode = "AKS12"
                keterangan = coverBan.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If panelMasuk.Checked Then
                kode = "AKS13"
                keterangan = panel.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If powerWindowMasuk.Checked Then
                kode = "AKS14"
                keterangan = powerWindow.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If centralLockMasuk.Checked Then
                kode = "AKS15"
                keterangan = centralLock.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If wiperMasuk.Checked Then
                kode = "AKS16"
                keterangan = wiper.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If radioMasuk.Checked Then
                kode = "AKS17"
                keterangan = radio.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If cdMasuk.Checked Then
                kode = "AKS18"
                keterangan = cd.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If acMasuk.Checked Then
                kode = "AKS19"
                keterangan = ac.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If remTanganMasuk.Checked Then
                kode = "AKS20"
                keterangan = remTangan.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If Lain1.Checked Then
                kode = "AKS21"
                keterangan = keteranganLain1.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If Lain2.Checked Then
                kode = "AKS22"
                keterangan = keteranganLain2.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            If Lain3.Checked Then
                kode = "AKS23"
                keterangan = keteranganLain3.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk1 + "')")
            End If

            'Mengambil Input Data Kondisi Bagian Depan Atas' 
            If askDepanAtas1.Checked Then
                kode = "DA1"
                kondisi = depanAtas10.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askDepanAtas2.Checked Then
                kode = "DA2"
                kondisi = depanAtas20.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askDepanAtas3.Checked Then
                kode = "DA3"
                kondisi = depanAtas30.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askDepanAtas4.Checked Then
                kode = "DA4"
                kondisi = depanAtas40.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askDepanAtas5.Checked Then
                kode = "DA5"
                kondisi = depanAtas50.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            'Mengambil Input Data Kondisi Bagian Depan Tengah' 
            If askDepanTengah1.Checked Then
                kode = "DT1"
                kondisi = depanTengah10.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askDepanTengah2.Checked Then
                kode = "DT2"
                kondisi = depanTengah20.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askDepanTengah3.Checked Then
                kode = "DT3"
                kondisi = depanTengah30.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askDepanTengah4.Checked Then
                kode = "DT4"
                kondisi = depanTengah40.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askDepanTengah5.Checked Then
                kode = "DT5"
                kondisi = depanTengah50.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            'Mengambil Input Data Kondisi Bagian Depan Bawah' 
            If askDepanBawah1.Checked Then
                kode = "DB1"
                kondisi = depanBawah10.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askDepanBawah2.Checked Then
                kode = "DB2"
                kondisi = depanBawah20.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askDepanBawah3.Checked Then
                kode = "DB3"
                kondisi = depanBawah30.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askDepanBawah4.Checked Then
                kode = "DB4"
                kondisi = depanBawah40.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askDepanBawah5.Checked Then
                kode = "DB5"
                kondisi = depanBawah50.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If


            'Mengambil Input Data Kondisi Bagian Atas Kanan' 
            If askAtasKanan1.Checked Then
                kode = "AK1"
                kondisi = atasKanan10.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askAtasKanan2.Checked Then
                kode = "AK2"
                kondisi = atasKanan20.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askAtasKanan3.Checked Then
                kode = "AK3"
                kondisi = atasKanan30.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askAtasKanan4.Checked Then
                kode = "AK4"
                kondisi = atasKanan40.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askAtasKanan5.Checked Then
                kode = "AK5"
                kondisi = atasKanan50.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askAtasKanan6.Checked Then
                kode = "AK6"
                kondisi = atasKanan60.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askAtasKanan7.Checked Then
                kode = "AK7"
                kondisi = atasKanan70.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            'Mengambil Input Data Kondisi Bagian Atas Kiri' 
            If askAtasKiri1.Checked Then
                kode = "AKI1"
                kondisi = atasKiri10.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askAtasKiri2.Checked Then
                kode = "AKI2"
                kondisi = atasKiri20.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askAtasKiri3.Checked Then
                kode = "AKI3"
                kondisi = atasKiri30.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askAtasKiri4.Checked Then
                kode = "AKI4"
                kondisi = atasKiri40.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askAtasKiri5.Checked Then
                kode = "AKI5"
                kondisi = atasKiri50.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askAtasKiri6.Checked Then
                kode = "AKI6"
                kondisi = AtasKiri60.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askAtasKiri7.Checked Then
                kode = "AKI7"
                kondisi = AtasKiri70.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            'Mengambil Input Data Kondisi Bagian kanan Atas' 
            If askKananAtas.Checked Then
                kode = "KA"
                kondisi = kananAtas1.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            'Mengambil Input Data Kondisi Bagian Kanan Tengah' 
            If askKananTengah1.Checked Then
                kode = "KT1"
                kondisi = kananTengah10.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananTengah2.Checked Then
                kode = "KT2"
                kondisi = kananTengah20.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananTengah3.Checked Then
                kode = "KT3"
                kondisi = kananTengah30.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananTengah4.Checked Then
                kode = "KT4"
                kondisi = kananTengah40.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananTengah5.Checked Then
                kode = "KT5"
                kondisi = kananTengah50.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananTengah6.Checked Then
                kode = "KT6"
                kondisi = kananTengah60.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananTengah7.Checked Then
                kode = "KT7"
                kondisi = kananTengah70.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananTengah8.Checked Then
                kode = "KT8"
                kondisi = kananTengah80.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananTengah9.Checked Then
                kode = "KT9"
                kondisi = kananTengah90.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananTengah10.Checked Then
                kode = "KT10"
                kondisi = kananTengah100.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            'Mengambil Input Data Kondisi Bagian Kanan Bawah' 
            If askKananBawah1.Checked Then
                kode = "KB1"
                kondisi = kananBawah10.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananBawah2.Checked Then
                kode = "KB2"
                kondisi = kananBawah20.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananBawah3.Checked Then
                kode = "KB3"
                kondisi = kananBawah30.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananBawah4.Checked Then
                kode = "KB4"
                kondisi = kananBawah40.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananBawah5.Checked Then
                kode = "KB5"
                kondisi = kananBawah50.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananBawah6.Checked Then
                kode = "KB6"
                kondisi = kananBawah60.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananBawah7.Checked Then
                kode = "KB7"
                kondisi = kananBawah70.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananBawah8.Checked Then
                kode = "KB8"
                kondisi = kananBawah80.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananBawah9.Checked Then
                kode = "KB9"
                kondisi = kananBawah90.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKananBawah10.Checked Then
                kode = "KB10"
                kondisi = kananBawah100.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            'Mengambil Input Data Kondisi Bagian Kiri Atas' 
            If askKiriAtas.Checked Then
                kode = "KIA"
                kondisi = kiriAtas1.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            'Mengambil Input Data Kondisi Bagian Kiri Tengah' 
            If askKiriTengah1.Checked Then
                kode = "KIT1"
                kondisi = kiriTengah10.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriTengah2.Checked Then
                kode = "KIT2"
                kondisi = kiriTengah20.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriTengah3.Checked Then
                kode = "KIT3"
                kondisi = kiriTengah30.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriTengah4.Checked Then
                kode = "KIT4"
                kondisi = kiriTengah40.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriTengah5.Checked Then
                kode = "KIT5"
                kondisi = kiriTengah50.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriTengah6.Checked Then
                kode = "KIT6"
                kondisi = kiriTengah60.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriTengah7.Checked Then
                kode = "KIT7"
                kondisi = kiriTengah70.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriTengah8.Checked Then
                kode = "KIT8"
                kondisi = kiriTengah80.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriTengah9.Checked Then
                kode = "KIT9"
                kondisi = kiriTengah90.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriTengah10.Checked Then
                kode = "KIT10"
                kondisi = kiriTengah100.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            'Mengambil Input Data Kondisi Bagian Kiri Bawah' 
            If askKiriBawah1.Checked Then
                kode = "KIB1"
                kondisi = kiriBawah10.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriBawah2.Checked Then
                kode = "KIB2"
                kondisi = kiriBawah20.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriBawah3.Checked Then
                kode = "KIB3"
                kondisi = kiriBawah30.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriBawah4.Checked Then
                kode = "KIB4"
                kondisi = kiriBawah40.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriBawah5.Checked Then
                kode = "KIB5"
                kondisi = kiriBawah50.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriBawah6.Checked Then
                kode = "KIB6"
                kondisi = kiriBawah60.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriBawah7.Checked Then
                kode = "KIB7"
                kondisi = kiriBawah70.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriBawah8.Checked Then
                kode = "KIB8"
                kondisi = kiriBawah80.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriBawah9.Checked Then
                kode = "KIB9"
                kondisi = kiriBawah90.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askKiriBawah10.Checked Then
                kode = "KIB10"
                kondisi = kiriBawah100.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            'Mengambil Input Data Kondisi Bagian Belakang Atas' 
            If askBelakangAtas1.Checked Then
                kode = "BA1"
                kondisi = belakangAtas10.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangAtas2.Checked Then
                kode = "BA2"
                kondisi = belakangAtas20.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangAtas3.Checked Then
                kode = "BA3"
                kondisi = belakangAtas30.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangAtas4.Checked Then
                kode = "BA4"
                kondisi = belakangAtas40.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangAtas5.Checked Then
                kode = "BA5"
                kondisi = belakangAtas50.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangAtas6.Checked Then
                kode = "BA6"
                kondisi = belakangAtas60.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            'Mengambil Input Data Kondisi Bagian Belakang Tengah' 
            If askBelakangTengah1.Checked Then
                kode = "BT1"
                kondisi = belakangTengah10.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangTengah2.Checked Then
                kode = "BT2"
                kondisi = belakangTengah20.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangTengah3.Checked Then
                kode = "BT3"
                kondisi = belakangTengah30.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangTengah4.Checked Then
                kode = "BT4"
                kondisi = belakangTengah40.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangTengah5.Checked Then
                kode = "BT5"
                kondisi = belakangTengah50.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangTengah6.Checked Then
                kode = "BT6"
                kondisi = belakangTengah60.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            'Mengambil Input Data Kondisi Bagian Belakang Bawah' 
            If askBelakangBawah1.Checked Then
                kode = "BB1"
                kondisi = belakangBawah10.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangBawah2.Checked Then
                kode = "BB2"
                kondisi = belakangBawah20.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangBawah3.Checked Then
                kode = "BB3"
                kondisi = belakangBawah30.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangBawah4.Checked Then
                kode = "BB4"
                kondisi = belakangBawah40.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangBawah5.Checked Then
                kode = "BB5"
                kondisi = belakangBawah50.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If askBelakangBawah6.Checked Then
                kode = "BB6"
                kondisi = belakangBawah60.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk1 + "')")
            End If

            If Q1.Text <> "" Then
                kode = "Q1"
                jawaban = Q1.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk1 + "')")
            End If

            If Q2.SelectedIndex <> -1 Then
                kode = "Q2"
                jawaban = Q2Selections()
                jawaban = jawaban.Replace("&nbsp", " ")
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk1 + "')")
            End If

            If Q3.SelectedIndex <> -1 Then
                kode = "Q3"
                jawaban = Q3Selections()
                jawaban = jawaban.Replace("&nbsp", " ")
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk1 + "')")
            End If

            If Q4.SelectedIndex <> -1 Then
                kode = "Q4"
                jawaban = Q4Selections()
                jawaban = jawaban.Replace("&nbsp", " ")
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk1 + "')")
            End If

            If Q5.SelectedIndex <> -1 Then
                kode = "Q5"
                jawaban = Q5Selections()
                jawaban = jawaban.Replace("&nbsp", " ")
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk1 + "')")
            End If

            If Q6.SelectedIndex <> -1 Then
                kode = "Q6"
                jawaban = Q6Selections()
                jawaban = jawaban.Replace("&nbsp", " ")
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk1 + "')")
            End If

            If Q7.SelectedIndex <> -1 Then
                kode = "Q7"
                jawaban = Q7Selections()
                jawaban = jawaban.Replace("&nbsp", " ")
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk1 + "')")
            End If

            If Q8.SelectedIndex <> -1 Then
                kode = "Q8"
                jawaban = Q8Selections()
                jawaban = jawaban.Replace("&nbsp", " ")
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk1 + "')")
            End If

            If Q9.SelectedIndex <> -1 Then
                kode = "Q9"
                jawaban = Q9Selections()
                jawaban = jawaban.Replace("&nbsp", " ")
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk1 + "')")
            End If

            If Q10.Text <> "" Then
                kode = "Q10"
                jawaban = Q10.Text
                Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk1 + "')")
            End If

            Response.Write("<script>alert('Data Checklist Berhasil Di Simpan')</script>")
            Response.Write("<script>window.location.href='pilihJenisMobil.aspx';</script>")

        End If




    End Sub

    Protected Sub cariNopol(sender As Object, e As EventArgs)
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim GetData_Checklist As Integer
        Dim nopol1 As String = nopol.Text
        Dim mSqlCommadstring As String = "select * FROM DATA_CUSTOMER LEFT JOIN DATA_WARNING ON DATA_CUSTOMER.CUST_NORANGKA = DATA_WARNING.WARN_NORANGKA LEFT JOIN DATA_TYPE ON DATA_CUSTOMER.CUST_TYPE = DATA_TYPE.TYPE_KODE WHERE CUST_NOPOL ='" + nopol1 + "' AND CUST_NORANGKA<>''"
        Dim MyRecReadA As OleDbDataReader
        cnn = New OleDbConnection(strconn)
        GetData_Checklist = 0

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Checklist = IIf(MyRecReadA.HasRows = True, 1, 0)
            If MyRecReadA.HasRows = True Then
                While MyRecReadA.Read()
                    txt_nmCustomer.Attributes("style") = "display:block"
                    nmCustomer.Text = MyRecReadA("cust_cname")
                    txt_norangka.Attributes("style") = "display:block"
                    noRangka.Text = MyRecReadA("cust_norangka")
                    txt_typeMobil.Attributes("style") = "display:block"
                    typeMobil.Text = MyRecReadA("type_nama")
                    txt_textwarning.Attributes("style") = "display:block"
                    textwarning.Text = MyRecReadA("cust_textwarning")
                    txt_peringatan.Attributes("style") = "display:none"
                End While
            Else
                txt_norangka.Attributes("style") = "display:none"
                txt_textwarning.Attributes("style") = "display:none"
                txt_nmCustomer.Attributes("style") = "display:none"
                txt_typeMobil.Attributes("style") = "display:none"
                txt_peringatan.Attributes("style") = "display:block"
            End If

            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception

        End Try
        If nopol1 = "" Then
            txt_norangka.Attributes("style") = "display:none"
            txt_textwarning.Attributes("style") = "display:none"
            txt_nmCustomer.Attributes("style") = "display:none"
            txt_typeMobil.Attributes("style") = "display:none"
            txt_peringatan.Attributes("style") = "display:none"
        End If
    End Sub

    Private Function Q2Selections() As String
        Dim items As New List(Of String)()
        For i As Integer = 0 To Q2.Items.Count - 1
            If Q2.Items(i).Selected Then
                items.Add(Q2.Items(i).Text)

                'if you want values instead of text then items.Add(cblCourses.Items(i).Value)
            End If
        Next
        Return [String].Join(",", items.ToArray())
    End Function

    Private Function Q3Selections() As String
        Dim items As New List(Of String)()
        For i As Integer = 0 To Q3.Items.Count - 1
            If Q3.Items(i).Selected Then
                items.Add(Q3.Items(i).Text)

                'if you want values instead of text then items.Add(cblCourses.Items(i).Value)
            End If
        Next
        Return [String].Join(",", items.ToArray())
    End Function

    Private Function Q4Selections() As String
        Dim items As New List(Of String)()
        For i As Integer = 0 To Q4.Items.Count - 1
            If Q4.Items(i).Selected Then
                items.Add(Q4.Items(i).Text)

                'if you want values instead of text then items.Add(cblCourses.Items(i).Value)
            End If
        Next
        Return [String].Join(",", items.ToArray())
    End Function

    Private Function Q5Selections() As String
        Dim items As New List(Of String)()
        For i As Integer = 0 To Q5.Items.Count - 1
            If Q5.Items(i).Selected Then
                items.Add(Q5.Items(i).Text)

                'if you want values instead of text then items.Add(cblCourses.Items(i).Value)
            End If
        Next
        Return [String].Join(",", items.ToArray())
    End Function

    Private Function Q6Selections() As String
        Dim items As New List(Of String)()
        For i As Integer = 0 To Q6.Items.Count - 1
            If Q6.Items(i).Selected Then
                items.Add(Q6.Items(i).Text)

                'if you want values instead of text then items.Add(cblCourses.Items(i).Value)
            End If
        Next
        Return [String].Join(",", items.ToArray())
    End Function

    Private Function Q7Selections() As String
        Dim items As New List(Of String)()
        For i As Integer = 0 To Q7.Items.Count - 1
            If Q7.Items(i).Selected Then
                items.Add(Q7.Items(i).Text)

                'if you want values instead of text then items.Add(cblCourses.Items(i).Value)
            End If
        Next
        Return [String].Join(",", items.ToArray())
    End Function

    Private Function Q8Selections() As String
        Dim items As New List(Of String)()
        For i As Integer = 0 To Q8.Items.Count - 1
            If Q8.Items(i).Selected Then
                items.Add(Q8.Items(i).Text)

                'if you want values instead of text then items.Add(cblCourses.Items(i).Value)
            End If
        Next
        Return [String].Join(",", items.ToArray())
    End Function

    Private Function Q9Selections() As String
        Dim items As New List(Of String)()
        For i As Integer = 0 To Q9.Items.Count - 1
            If Q9.Items(i).Selected Then
                items.Add(Q9.Items(i).Text)

                'if you want values instead of text then items.Add(cblCourses.Items(i).Value)
            End If
        Next
        Return [String].Join(",", items.ToArray())
    End Function
    Function insertChecklist_Tabel(ByVal mSqlCommadstring As String) As Byte

        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        insertChecklist_Tabel = 0
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            insertChecklist_Tabel = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Function

End Class
