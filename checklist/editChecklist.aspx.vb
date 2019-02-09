Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Partial Class editChecklist
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("username") = Nothing Then
            Response.Redirect("default.aspx")
        ElseIf tglMasuk.Text = "" Then

            Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
            Dim cnn As OleDbConnection
            Dim cmd As OleDbCommand
            'lemparan data nopol dan tanggal masuk dari file cariChecklist
            Dim nopol1 As String = CType(Session.Item("nopol1"), String)
            Dim tglMasuk1 As String = CType(Session.Item("tglMasuk1"), String)
            Dim GetData_Checklist As Integer
            Dim mSqlCommadstring As String = "Select * From TEMP_CHECKLISTD INNER JOIN TEMP_CHECKLISTH ON TEMP_CHECKLISTD.nopol = TEMP_CHECKLISTH.nopol where TEMP_CHECKLISTD.nopol='" + nopol1 + "' AND DATEDIFF (day,TEMP_CHECKLISTD.tglMasuk,'" + tglMasuk1 + "')=0"
            Dim mSqlCommadstring2 As String = "select * FROM DATA_CUSTOMER LEFT JOIN DATA_WARNING ON DATA_CUSTOMER.CUST_NORANGKA = DATA_WARNING.WARN_NORANGKA LEFT JOIN DATA_TYPE ON DATA_CUSTOMER.CUST_TYPE = DATA_TYPE.TYPE_KODE LEFT JOIN TEMP_CHECKLISTH ON  DATA_CUSTOMER.CUST_NOPOL = TEMP_CHECKLISTH.nopol  WHERE CUST_NOPOL ='" + nopol1 + "' AND CUST_NORANGKA<>'' AND DATEDIFF (day,tglMasuk,'" + tglMasuk1 + "')=0"
            Dim mSqlCommadstring3 As String = "Select * From TEMP_CHECKLISTH where nopol='" + nopol1 + "' AND DATEDIFF (day,tglMasuk,'" + tglMasuk1 + "')=0"
            Dim MyRecReadA As OleDbDataReader

            'ngelempar data nopol dan tglMasuk ke File tampilan viewChecklist
            nopol.Text = nopol1

            cnn = New OleDbConnection(strconn)
            GetData_Checklist = 0

            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring2, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_Checklist = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    nmCustomer.Text = MyRecReadA("cust_cname")
                    noRangka.Text = MyRecReadA("cust_norangka")
                    typeMobil.Text = MyRecReadA("type_nama")
                    textwarning.Text = MyRecReadA("cust_textwarning")
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                peringatan.Text = "Terdapat Error di Detail Pemilik"
            End Try

            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_Checklist = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()

                    'Menampilkan data bensin
                    If MyRecReadA("kode") = "L" Then
                        Dim bensin1 As String = MyRecReadA("keterangan")
                        bensin.Text = bensin1
                    End If

                    'Menampilkan data ordometer
                    If MyRecReadA("kode") = "M" Then
                        ordometer.Text = MyRecReadA("keterangan")
                    End If

                    'Menampilkan data kondisi baterai
                    If MyRecReadA("kode") = "A" Then
                        kondisiBaterai.Text = MyRecReadA("keterangan")
                    End If

                    'Menampilkan data ban depan
                    If MyRecReadA("kode") = "B" Then
                        banDepanKiri.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "C" Then
                        kondisiBanDepanKiri.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "D" Then
                        banDepanKanan.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "E" Then
                        kondisiBanDepanKanan.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "F" Then
                        keteranganBanDepan.Text = MyRecReadA("keterangan")
                    End If

                    'Menampilkan data ban belakang
                    If MyRecReadA("kode") = "G" Then
                        banBelakangKiri.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "H" Then
                        kondisiBanBelakangKiri.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "I" Then
                        banBelakangKanan.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "J" Then
                        kondisiBanBelakangKanan.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "K" Then
                        keteranganBanBelakang.Text = MyRecReadA("keterangan")
                    End If

                    'Menampilkan data aksesoris
                    If MyRecReadA("kode") = "AKS1" Then
                        stnkMasuk.Checked = True
                        stnk.Attributes("style") = "display:block"
                        stnk.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS2" Then
                        kasetMasuk.Checked = True
                        kaset.Attributes("style") = "display:block"
                        kaset.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS3" Then
                        uangMasuk.Checked = True
                        uang.Attributes("style") = "display:block"
                        uang.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS4" Then
                        pemantikApiMasuk.Checked = True
                        pemantikApi.Attributes("style") = "display:block"
                        pemantikApi.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS5" Then
                        karpetMasuk.Checked = True
                        karpet.Attributes("style") = "display:block"
                        karpet.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS6" Then
                        bukuServiceMasuk.Checked = True
                        bukuService.Attributes("style") = "display:block"
                        bukuService.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS7" Then
                        velgMasuk.Checked = True
                        velg.Attributes("style") = "display:block"
                        velg.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS8" Then
                        bukuMasuk.Checked = True
                        buku.Attributes("style") = "display:block"
                        buku.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS9" Then
                        toolKitMasuk.Checked = True
                        toolKit.Attributes("style") = "display:block"
                        toolKit.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS10" Then
                        dongkrakMasuk.Checked = True
                        dongkrak.Attributes("style") = "display:block"
                        dongkrak.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS11" Then
                        banMasuk.Checked = True
                        ban.Attributes("style") = "display:block"
                        ban.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS12" Then
                        coverBanMasuk.Checked = True
                        coverBan.Attributes("style") = "display:block"
                        coverBan.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS13" Then
                        panelMasuk.Checked = True
                        panel.Attributes("style") = "display:block"
                        panel.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS14" Then
                        powerWindowMasuk.Checked = True
                        powerWindow.Attributes("style") = "display:block"
                        powerWindow.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS15" Then
                        centralLockMasuk.Checked = True
                        centralLock.Attributes("style") = "display:block"
                        centralLock.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS16" Then
                        wiperMasuk.Checked = True
                        wiper.Attributes("style") = "display:block"
                        wiper.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS17" Then
                        radioMasuk.Checked = True
                        radio.Attributes("style") = "display:block"
                        radio.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS18" Then
                        cdMasuk.Checked = True
                        cd.Attributes("style") = "display:block"
                        cd.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS19" Then
                        acMasuk.Checked = True
                        ac.Attributes("style") = "display:block"
                        ac.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS20" Then
                        remTanganMasuk.Checked = True
                        remTangan.Attributes("style") = "display:block"
                        remTangan.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS21" Then
                        Lain1.Checked = True
                        keteranganLain1.Attributes("style") = "display:block"
                        keteranganLain1.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS22" Then
                        Lain2.Checked = True
                        keteranganLain2.Attributes("style") = "display:block"
                        keteranganLain2.Text = MyRecReadA("keterangan")
                    End If

                    If MyRecReadA("kode") = "AKS23" Then
                        Lain3.Checked = True
                        keteranganLain3.Attributes("style") = "display:block"
                        keteranganLain3.Text = MyRecReadA("keterangan")
                    End If

                    'Menampilkan kondisi checklist SUV bagian depan atas
                    If MyRecReadA("kategori") = "1" Then
                        If MyRecReadA("kode") = "DA1" Then
                            askDepanAtas1A.Checked = True
                            depanAtas1A.Attributes("style") = "display:block; position:absolute; margin-left:100px; margin-top:-50px;"
                            depanAtas1A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA2" Then
                            askDepanAtas2A.Checked = True
                            depanAtas2A.Attributes("style") = "display:block; position:absolute; margin-left:155px; margin-top:-50px;"
                            depanAtas2A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA3" Then
                            askDepanAtas3A.Checked = True
                            depanAtas3A.Attributes("style") = "display:block; position:absolute; margin-left:205px; margin-top:-50px;"
                            depanAtas3A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA4" Then
                            askDepanAtas4A.Checked = True
                            depanAtas4A.Attributes("style") = "display:block; position:absolute; margin-left:255px; margin-top:-50px;"
                            depanAtas4A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA5" Then
                            askDepanAtas5A.Checked = True
                            depanAtas5A.Attributes("style") = "display:block; position:absolute; margin-left:305px; margin-top:-50px;"
                            depanAtas5A.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian depan tengah
                        If MyRecReadA("kode") = "DT1" Then
                            askDepanTengah1A.Checked = True
                            depanTengah1A.Attributes("style") = "display:block; position:absolute; margin-left:130px; margin-top:-40px;"
                            depanTengah1A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT2" Then
                            askDepanTengah2A.Checked = True
                            depanTengah2A.Attributes("style") = "display:block; position:absolute; margin-left:180px; margin-top:-40px;"
                            depanTengah2A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT3" Then
                            askDepanTengah3A.Checked = True
                            depanTengah3A.Attributes("style") = "display:block; position:absolute; margin-left:230px; margin-top:-40px;"
                            depanTengah3A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT4" Then
                            askDepanTengah4A.Checked = True
                            depanTengah4A.Attributes("style") = "display:block; position:absolute; margin-left:280px; margin-top:-40px;"
                            depanTengah4A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT5" Then
                            askDepanTengah5A.Checked = True
                            depanTengah5A.Attributes("style") = "display:block; position:absolute; margin-left:330px; margin-top:-40px;"
                            depanTengah5A.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian depan bawah
                        If MyRecReadA("kode") = "DB1" Then
                            askDepanBawah1A.Checked = True
                            depanBawah1A.Attributes("style") = "display:block; position:absolute; margin-left:75px;"
                            depanBawah1A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB2" Then
                            askDepanBawah2A.Checked = True
                            depanBawah2A.Attributes("style") = "display:block; position:absolute; margin-left:125px;"
                            depanBawah2A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB3" Then
                            askDepanBawah3A.Checked = True
                            depanBawah3A.Attributes("style") = "display:block; position:absolute; margin-left:175px;"
                            depanBawah3A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB4" Then
                            askDepanBawah4A.Checked = True
                            depanBawah4A.Attributes("style") = "display:block; position:absolute; margin-left:225px;"
                            depanBawah4A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB5" Then
                            askDepanBawah5A.Checked = True
                            depanBawah5A.Attributes("style") = "display:block; position:absolute; margin-left:275px;"
                            depanBawah5A.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian belakang atas
                        If MyRecReadA("kode") = "BA1" Then
                            askBelakangAtas1A.Checked = True
                            belakangAtas1A.Attributes("style") = "display:block; position:absolute; margin-left:100px; margin-top:-45px;"
                            belakangAtas1A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA2" Then
                            askBelakangAtas2A.Checked = True
                            belakangAtas2A.Attributes("style") = "display:block; position:absolute; margin-left:150px; margin-top:-45px;"
                            belakangAtas2A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA3" Then
                            askBelakangAtas3A.Checked = True
                            belakangAtas3A.Attributes("style") = "display:block; position:absolute; margin-left:190px; margin-top:-45px;"
                            belakangAtas3A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA4" Then
                            askBelakangAtas4A.Checked = True
                            belakangAtas4A.Attributes("style") = "display:block; position:absolute; margin-left:230px; margin-top:-45px;"
                            belakangAtas4A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA5" Then
                            askBelakangAtas5A.Checked = True
                            belakangAtas5A.Attributes("style") = "display:block; position:absolute; margin-left:270px; margin-top:-45px;"
                            belakangAtas5A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA6" Then
                            askBelakangAtas6A.Checked = True
                            belakangAtas6A.Attributes("style") = "display:block; position:absolute; margin-left:310px; margin-top:-45px;"
                            belakangAtas6A.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian belakang tengah
                        If MyRecReadA("kode") = "BT1" Then
                            askBelakangTengah1A.Checked = True
                            belakangTengah1A.Attributes("style") = "display:block; position:absolute; margin-left:100px; margin-top:-5px;"
                            belakangTengah1A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT2" Then
                            askBelakangTengah2A.Checked = True
                            belakangTengah2A.Attributes("style") = "display:block; position:absolute; margin-left:150px; margin-top:-5px;"
                            belakangTengah2A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT3" Then
                            askBelakangTengah3A.Checked = True
                            belakangTengah3A.Attributes("style") = "display:block; position:absolute; margin-left:190px; margin-top:-5px;"
                            belakangTengah3A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT4" Then
                            askBelakangTengah4A.Checked = True
                            belakangTengah4A.Attributes("style") = "display:block; position:absolute; margin-left:230px; margin-top:-5px;"
                            belakangTengah4A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT5" Then
                            askBelakangTengah5A.Checked = True
                            belakangTengah5A.Attributes("style") = "display:block; position:absolute; margin-left:270px; margin-top:-5px;"
                            belakangTengah5A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT6" Then
                            askBelakangTengah6A.Checked = True
                            belakangTengah6A.Attributes("style") = "display:block; position:absolute; margin-left:310px; margin-top:-5px;"
                            belakangTengah6A.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian belakang bawah
                        If MyRecReadA("kode") = "BB1" Then
                            askBelakangBawah1A.Checked = True
                            belakangBawah1A.Attributes("style") = "display:block; position:absolute; margin-left:100px;"
                            belakangBawah1A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB2" Then
                            askBelakangBawah2A.Checked = True
                            belakangBawah2A.Attributes("style") = "display:block; position:absolute; margin-left:150px;"
                            belakangBawah2A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB3" Then
                            askBelakangBawah3A.Checked = True
                            belakangBawah3A.Attributes("style") = "display:block; position:absolute; margin-left:190px;"
                            belakangBawah3A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB4" Then
                            askBelakangBawah4A.Checked = True
                            belakangBawah4A.Attributes("style") = "display:block; position:absolute; margin-left:230px;"
                            belakangBawah4A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB5" Then
                            askBelakangBawah5A.Checked = True
                            belakangBawah5A.Attributes("style") = "display:block; position:absolute; margin-left:270px;"
                            belakangBawah5A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB6" Then
                            askBelakangBawah6A.Checked = True
                            belakangBawah6A.Attributes("style") = "display:block; position:absolute; margin-left:310px;"
                            belakangBawah6A.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kanan atas
                        If MyRecReadA("kode") = "KA" Then
                            askKananAtasA.Checked = True
                            kananAtasA.Attributes("style") = "display:block; position:absolute; margin-left:205px; margin-top:-45px;"
                            kananAtasA.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kanan tengah
                        If MyRecReadA("kode") = "KT1" Then
                            askKananTengah1A.Checked = True
                            kananTengah1A.Attributes("style") = "display:block; position:absolute; margin-left:40px; margin-top:-45px;"
                            kananTengah1A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT2" Then
                            askKananTengah2A.Checked = True
                            kananTengah2A.Attributes("style") = "display:block; position:absolute; margin-left:100px; margin-top:-45px;"
                            kananTengah2A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT3" Then
                            askKananTengah3A.Checked = True
                            kananTengah3A.Attributes("style") = "display:block; position:absolute; margin-left:135px; margin-top:-70px;"
                            kananTengah3A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT4" Then
                            askKananTengah4A.Checked = True
                            kananTengah4A.Attributes("style") = "display:block; position:absolute; margin-left:160px; margin-top:-45px;"
                            kananTengah4A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT5" Then
                            askKananTengah5A.Checked = True
                            kananTengah5A.Attributes("style") = "display:block; position:absolute;  margin-left:190px; margin-top:-70px;"
                            kananTengah5A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT6" Then
                            askKananTengah6A.Checked = True
                            kananTengah6A.Attributes("style") = "display:block; position:absolute; margin-left:220px; margin-top:-45px;"
                            kananTengah6A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT7" Then
                            askKananTengah7A.Checked = True
                            kananTengah7A.Attributes("style") = "display:block; position:absolute; margin-left:250px; margin-top:-70px;"
                            kananTengah7A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT8" Then
                            askKananTengah8A.Checked = True
                            kananTengah8A.Attributes("style") = "display:block; position:absolute; margin-left:280px; margin-top:-45px;"
                            kananTengah8A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT9" Then
                            askKananTengah9A.Checked = True
                            kananTengah9A.Attributes("style") = "display:block; position:absolute; margin-left:310px; margin-top:-70px;"
                            kananTengah9A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT10" Then
                            askKananTengah10A.Checked = True
                            kananTengah10A.Attributes("style") = "display:block; position:absolute; margin-left:350px; margin-top:-45px;"
                            kananTengah10A.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kanan bawah
                        If MyRecReadA("kode") = "KB1" Then
                            askKananBawah1A.Checked = True
                            kananBawah1A.Attributes("style") = "display:block; position:absolute; margin-left:40px; margin-top:0px;"
                            kananBawah1A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB2" Then
                            askKananBawah2A.Checked = True
                            kananBawah2A.Attributes("style") = "display:block; position:absolute; margin-left:90px; margin-top:0px;"
                            kananBawah2A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB3" Then
                            askKananBawah3A.Checked = True
                            kananBawah3A.Attributes("style") = "display:block; position:absolute; margin-left:135px; margin-top:20px;"
                            kananBawah3A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB4" Then
                            askKananBawah4A.Checked = True
                            kananBawah4A.Attributes("style") = "display:block; position:absolute; margin-left:170px; margin-top:0px;"
                            kananBawah4A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB5" Then
                            askKananBawah5A.Checked = True
                            kananBawah5A.Attributes("style") = "display:block; position:absolute; margin-left:195px; margin-top:25px;"
                            kananBawah5A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB6" Then
                            askKananBawah6A.Checked = True
                            kananBawah6A.Attributes("style") = "display:block; position:absolute; margin-left:230px; margin-top:0px;"
                            kananBawah6A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB7" Then
                            askKananBawah7A.Checked = True
                            kananBawah7A.Attributes("style") = "display:block; position:absolute; margin-left:260px; margin-top:25px;"
                            kananBawah7A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB8" Then
                            askKananBawah8A.Checked = True
                            kananBawah8A.Attributes("style") = "display:block; position:absolute; margin-left:295px; margin-top:0px;"
                            kananBawah8A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB9" Then
                            askKananBawah9A.Checked = True
                            kananBawah9A.Attributes("style") = "display:block; position:absolute; margin-left:335px; margin-top:25px;"
                            kananBawah9A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB10" Then
                            askKananBawah10A.Checked = True
                            kananBawah10A.Attributes("style") = "display:block; position:absolute; margin-left:375px; margin-top:0px;"
                            kananBawah10A.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kiri atas
                        If MyRecReadA("kode") = "KIA" Then
                            askKiriAtasA.Checked = True
                            kiriAtasA.Attributes("style") = "display:block; position:absolute; margin-left:215px; margin-top:-45px;"
                            kiriAtasA.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kiri tengah
                        If MyRecReadA("kode") = "KIT1" Then
                            askKiriTengah1A.Checked = True
                            kiriTengah1A.Attributes("style") = "display:block; position:absolute; margin-left:60px; margin-top:-55px;"
                            kiriTengah1A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT2" Then
                            askKiriTengah2A.Checked = True
                            kiriTengah2A.Attributes("style") = "display:block; position:absolute; margin-left:100px; margin-top:-80px;"
                            kiriTengah2A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT3" Then
                            askKiriTengah3A.Checked = True
                            kiriTengah3A.Attributes("style") = "display:block; position:absolute; margin-left:135px; margin-top:-55px;"
                            kiriTengah3A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT4" Then
                            askKiriTengah4A.Checked = True
                            kiriTengah4A.Attributes("style") = "display:block; position:absolute; margin-left:160px; margin-top:-80px;"
                            kiriTengah4A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT5" Then
                            askKiriTengah5A.Checked = True
                            kiriTengah5A.Attributes("style") = "display:block; position:absolute; margin-left:195px; margin-top:-55px;"
                            kiriTengah5A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT6" Then
                            askKiriTengah6A.Checked = True
                            kiriTengah6A.Attributes("style") = "display:block; position:absolute; margin-left:220px;  margin-top:-80px;"
                            kiriTengah6A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT7" Then
                            askKiriTengah7A.Checked = True
                            kiriTengah7A.Attributes("style") = "display:block; position:absolute; margin-left:260px;  margin-top:-55px;"
                            kiriTengah7A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT8" Then
                            askKiriTengah8A.Checked = True
                            kiriTengah8A.Attributes("style") = "display:block; position:absolute; margin-left:290px; margin-top:-80px;"
                            kiriTengah8A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT9" Then
                            askKiriTengah9A.Checked = True
                            kiriTengah9A.Attributes("style") = "display:block; position:absolute; margin-left:320px; margin-top:-105px;"
                            kiriTengah9A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT10" Then
                            askKiriTengah10A.Checked = True
                            kiriTengah10A.Attributes("style") = "display:block; position:absolute; margin-left:370px; margin-top:-45px;"
                            kiriTengah10A.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kiri bawah
                        If MyRecReadA("kode") = "KIB1" Then
                            askKiriBawah1A.Checked = True
                            kiriBawah1A.Attributes("style") = "display:block; position:absolute; margin-left:35px; margin-top:0px;"
                            kiriBawah1A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB2" Then
                            askKiriBawah2A.Checked = True
                            kiriBawah2A.Attributes("style") = "display:block; position:absolute; margin-left:85px; margin-top:0px;"
                            kiriBawah2A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB3" Then
                            askKiriBawah3A.Checked = True
                            kiriBawah3A.Attributes("style") = "display:block; position:absolute; margin-left:125px; margin-top:25px;"
                            kiriBawah3A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB4" Then
                            askKiriBawah4A.Checked = True
                            kiriBawah4A.Attributes("style") = "display:block; position:absolute;  margin-left:150px; margin-top:0px;"
                            kiriBawah4A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB5" Then
                            askKiriBawah5A.Checked = True
                            kiriBawah5A.Attributes("style") = "display:block; position:absolute; margin-left:185px; margin-top:25px;"
                            kiriBawah5A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB6" Then
                            askKiriBawah6A.Checked = True
                            kiriBawah6A.Attributes("style") = "display:block; position:absolute; margin-left:215px; margin-top:0px;"
                            kiriBawah6A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB7" Then
                            askKiriBawah7A.Checked = True
                            kiriBawah7A.Attributes("style") = "display:block; position:absolute; margin-left:250px; margin-top:25px;"
                            kiriBawah7A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB8" Then
                            askKiriBawah8A.Checked = True
                            kiriBawah8A.Attributes("style") = "display:block; position:absolute; margin-left:280px;"
                            kiriBawah8A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB9" Then
                            askKiriBawah9A.Checked = True
                            kiriBawah9A.Attributes("style") = "display:block; position:absolute; margin-left:320px; margin-top:25px;"
                            kiriBawah9A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB10" Then
                            askKiriBawah10A.Checked = True
                            kiriBawah10A.Attributes("style") = "display:block; position:absolute; margin-left:380px; margin-top:0px;"
                            kiriBawah10A.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian atas kiri
                        If MyRecReadA("kode") = "AKI1" Then
                            askAtasKiri1A.Checked = True
                            atasKiri1A.Attributes("style") = "display:block; position:absolute; margin-left:60px; margin-top:-45px;"
                            atasKiri1A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI2" Then
                            askAtasKiri2A.Checked = True
                            atasKiri2A.Attributes("style") = "display:block; position:absolute; margin-left:105px; margin-top:-75px;"
                            atasKiri2A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI3" Then
                            askAtasKiri3A.Checked = True
                            atasKiri3A.Attributes("style") = "display:block; position:absolute; margin-left:140px; margin-top:-45px;"
                            atasKiri3A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI4" Then
                            askAtasKiri4A.Checked = True
                            atasKiri4A.Attributes("style") = "display:block; position:absolute; margin-left:175px; margin-top:-75px;"
                            atasKiri4A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI5" Then
                            askAtasKiri5A.Checked = True
                            atasKiri5A.Attributes("style") = "display:block; position:absolute; margin-left:210px; margin-top:-45px;"
                            atasKiri5A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI6" Then
                            askAtasKiri6A.Checked = True
                            AtasKiri6A.Attributes("style") = "display:block; position:absolute; margin-left:245px; margin-top:-75px;"
                            AtasKiri6A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI7" Then
                            askAtasKiri7A.Checked = True
                            AtasKiri7A.Attributes("style") = "display:block; position:absolute; margin-left:350px; margin-top:-45px;"
                            AtasKiri7A.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian atas kanan
                        If MyRecReadA("kode") = "AK1" Then
                            askAtasKanan1A.Checked = True
                            atasKanan1A.Attributes("style") = "display:block; position:absolute; margin-left:65px; margin-top:5px;"
                            atasKanan1A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK2" Then
                            askAtasKanan2A.Checked = True
                            atasKanan2A.Attributes("style") = "display:block; position:absolute; margin-left:105px; margin-top:30px;"
                            atasKanan2A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK3" Then
                            askAtasKanan3A.Checked = True
                            atasKanan3A.Attributes("style") = "display:block; position:absolute; margin-left:145px; margin-top:5px;"
                            atasKanan3A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK4" Then
                            askAtasKanan4A.Checked = True
                            atasKanan4A.Attributes("style") = "display:block; position:absolute; margin-left:180px; margin-top:30px;"
                            atasKanan4A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK5" Then
                            askAtasKanan5A.Checked = True
                            atasKanan5A.Attributes("style") = "display:block; position:absolute; margin-left:210px; margin-top:5px;"
                            atasKanan5A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK6" Then
                            askAtasKanan6A.Checked = True
                            atasKanan6A.Attributes("style") = "display:block; position:absolute; margin-left:250px; margin-top:30px;"
                            atasKanan6A.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK7" Then
                            askAtasKanan7A.Checked = True
                            atasKanan7A.Attributes("style") = "display:block; position:absolute; margin-left:340px; margin-top:5px;"
                            atasKanan7A.Text = MyRecReadA("kondisi")
                        End If
                    End If

                    'Menampilkan kondisi checklist Sedan bagian depan atas

                    If MyRecReadA("kategori") = "2" Then
                        If MyRecReadA("kode") = "DA1" Then
                            askDepanAtas1B.Checked = True
                            depanAtas1B.Attributes("style") = "display:block; position:absolute; margin-left:100px; margin-top:-50px;"
                            depanAtas1B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA2" Then
                            askDepanAtas2B.Checked = True
                            depanAtas2B.Attributes("style") = "display:block; position:absolute; margin-left:155px; margin-top:-50px; "
                            depanAtas2B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA3" Then
                            askDepanAtas3B.Checked = True
                            depanAtas3B.Attributes("style") = "display:block; position:absolute; margin-left:205px; margin-top:-50px;"
                            depanAtas3B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA4" Then
                            askDepanAtas4B.Checked = True
                            depanAtas4B.Attributes("style") = "display:block; position:absolute; margin-left:255px; margin-top:-50px;"
                            depanAtas4B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA5" Then
                            askDepanAtas5B.Checked = True
                            depanAtas5B.Attributes("style") = "display:block; position:absolute; margin-left:305px; margin-top:-50px;"
                            depanAtas5B.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian depan tengah
                        If MyRecReadA("kode") = "DT1" Then
                            askDepanTengah1B.Checked = True
                            depanTengah1B.Attributes("style") = "display:block; position:absolute; margin-left:130px; margin-top:-40px;"
                            depanTengah1B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT2" Then
                            askDepanTengah2B.Checked = True
                            depanTengah2B.Attributes("style") = "display:block; position:absolute; margin-left:180px; margin-top:-40px;"
                            depanTengah2B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT3" Then
                            askDepanTengah3B.Checked = True
                            depanTengah3B.Attributes("style") = "display:block; position:absolute; margin-left:230px; margin-top:-40px;"
                            depanTengah3B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT4" Then
                            askDepanTengah4B.Checked = True
                            depanTengah4B.Attributes("style") = "display:block; position:absolute; margin-left:280px; margin-top:-40px;"
                            depanTengah4B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT5" Then
                            askDepanTengah5B.Checked = True
                            depanTengah5B.Attributes("style") = "display:block; position:absolute; margin-left:330px; margin-top:-40px;"
                            depanTengah5B.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian depan bawah
                        If MyRecReadA("kode") = "DB1" Then
                            askDepanBawah1B.Checked = True
                            depanBawah1B.Attributes("style") = "display:block; position:absolute; margin-left:75px;"
                            depanBawah1B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB2" Then
                            askDepanBawah2B.Checked = True
                            depanBawah2B.Attributes("style") = "display:block; position:absolute; margin-left:125px;"
                            depanBawah2B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB3" Then
                            askDepanBawah3B.Checked = True
                            depanBawah3B.Attributes("style") = "display:block; position:absolute; margin-left:175px;"
                            depanBawah3B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB4" Then
                            askDepanBawah4B.Checked = True
                            depanBawah4B.Attributes("style") = "display:block; position:absolute; margin-left:225px;"
                            depanBawah4B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB5" Then
                            askDepanBawah5B.Checked = True
                            depanBawah5B.Attributes("style") = "display:block; position:absolute; margin-left:275px;"
                            depanBawah5B.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian belakang atas
                        If MyRecReadA("kode") = "BA1" Then
                            askBelakangAtas1B.Checked = True
                            belakangAtas1B.Attributes("style") = "display:block; position:absolute; margin-left:100px; margin-top:-50px"
                            belakangAtas1B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA2" Then
                            askBelakangAtas2B.Checked = True
                            belakangAtas2B.Attributes("style") = "display:none; position:absolute; margin-left:155px; margin-top:-50px; "
                            belakangAtas2B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA3" Then
                            askBelakangAtas3B.Checked = True
                            belakangAtas3B.Attributes("style") = "display:block; position:absolute; margin-left:205px; margin-top:-50px; "
                            belakangAtas3B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA4" Then
                            askBelakangAtas4B.Checked = True
                            belakangAtas4B.Attributes("style") = "display:block; position:absolute; margin-left:250px; margin-top:-50px;"
                            belakangAtas4B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA5" Then
                            askBelakangAtas5B.Checked = True
                            belakangAtas5B.Attributes("style") = "display:block; position:absolute; margin-left:300px; margin-top:-50px; "
                            belakangAtas5B.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian belakang tengah
                        If MyRecReadA("kode") = "BT1" Then
                            askBelakangTengah1B.Checked = True
                            belakangTengah1B.Attributes("style") = "display:block; position:absolute; margin-left:130px; margin-top:-40px;"
                            belakangTengah1B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT2" Then
                            askBelakangTengah2B.Checked = True
                            belakangTengah2B.Attributes("style") = "display:block; position:absolute; margin-left:180px; margin-top:-40px;"
                            belakangTengah2B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT3" Then
                            askBelakangTengah3B.Checked = True
                            belakangTengah3B.Attributes("style") = "display:block; position:absolute; margin-left:230px; margin-top:-40px;"
                            belakangTengah3B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT4" Then
                            askBelakangTengah4B.Checked = True
                            belakangTengah4B.Attributes("style") = "display:block; position:absolute; margin-left:280px; margin-top:-40px;"
                            belakangTengah4B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT5" Then
                            askBelakangTengah5B.Checked = True
                            belakangTengah5B.Attributes("style") = "display:block; position:absolute; margin-left:330px; margin-top:-40px;"
                            belakangTengah5B.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian belakang bawah
                        If MyRecReadA("kode") = "BB1" Then
                            askBelakangBawah1B.Checked = True
                            belakangBawah1B.Attributes("style") = "display:block; position:absolute; margin-left:100px;"
                            belakangBawah1B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB2" Then
                            askBelakangBawah2B.Checked = True
                            belakangBawah2B.Attributes("style") = "display:block; position:absolute; margin-left:150px;"
                            belakangBawah2B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB3" Then
                            askBelakangBawah3B.Checked = True
                            belakangBawah3B.Attributes("style") = "display:block; position:absolute; margin-left:200px; "
                            belakangBawah3B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB4" Then
                            askBelakangBawah4B.Checked = True
                            belakangBawah4B.Attributes("style") = "display:block; position:absolute; margin-left:250px;"
                            belakangBawah4B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB5" Then
                            askBelakangBawah5B.Checked = True
                            belakangBawah5B.Attributes("style") = "display:block; position:absolute; margin-left:300px;"
                            belakangBawah5B.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kanan atas
                        If MyRecReadA("kode") = "KA" Then
                            askKananAtasB.Checked = True
                            kananAtasB.Attributes("style") = "display:block; position:absolute; margin-left:205px; margin-top:-45px;"
                            kananAtasB.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kanan tengah
                        If MyRecReadA("kode") = "KT1" Then
                            askKananTengah1B.Checked = True
                            kananTengah1B.Attributes("style") = "display:block; position:absolute; margin-left:60px; margin-top:-45px;"
                            kananTengah1B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT2" Then
                            askKananTengah2B.Checked = True
                            kananTengah2B.Attributes("style") = "display:block; position:absolute; margin-left:130px; margin-top:-45px;"
                            kananTengah2B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT3" Then
                            askKananTengah3B.Checked = True
                            kananTengah3B.Attributes("style") = "display:block; position:absolute; margin-left:165px; margin-top:-70px;"
                            kananTengah3B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT4" Then
                            askKananTengah4B.Checked = True
                            kananTengah4B.Attributes("style") = "display:block; position:absolute; margin-left:190px; margin-top:-45px;"
                            kananTengah4B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT5" Then
                            askKananTengah5B.Checked = True
                            kananTengah5B.Attributes("style") = "display:block; position:absolute;  margin-left:220px; margin-top:-70px;"
                            kananTengah5B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT6" Then
                            askKananTengah6B.Checked = True
                            kananTengah6B.Attributes("style") = "display:block; position:absolute; margin-left:250px; margin-top:-45px;"
                            kananTengah6B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT7" Then
                            askKananTengah7B.Checked = True
                            kananTengah7B.Attributes("style") = "display:block; position:absolute; margin-left:280px; margin-top:-70px;"
                            kananTengah7B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT8" Then
                            askKananTengah8B.Checked = True
                            kananTengah8B.Attributes("style") = "display:block; position:absolute; margin-left:320px; margin-top:-45px;"
                            kananTengah8B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT9" Then
                            askKananTengah9B.Checked = True
                            kananTengah9B.Attributes("style") = "display:block; position:absolute; margin-left:340px; margin-top:-70px;"
                            kananTengah9B.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kanan bawah
                        If MyRecReadA("kode") = "KB1" Then
                            askKananBawah1B.Checked = True
                            kananBawah1B.Attributes("style") = "display:block; position:absolute; margin-left:45px; margin-top:0px;"
                            kananBawah1B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB2" Then
                            askKananBawah2B.Checked = True
                            kananBawah2B.Attributes("style") = "display:block; position:absolute; margin-left:95px; margin-top:0px;"
                            kananBawah2B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB3" Then
                            askKananBawah3B.Checked = True
                            kananBawah3B.Attributes("style") = "display:block; position:absolute; margin-left:135px; margin-top:25px;"
                            kananBawah3B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB4" Then
                            askKananBawah4B.Checked = True
                            kananBawah4B.Attributes("style") = "display:block; position:absolute; margin-left:175px; margin-top:0px;"
                            kananBawah4B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB5" Then
                            askKananBawah5B.Checked = True
                            kananBawah5B.Attributes("style") = "display:block; position:absolute; margin-left:200px; margin-top:25px;"
                            kananBawah5B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB6" Then
                            askKananBawah6B.Checked = True
                            kananBawah6B.Attributes("style") = "display:block; position:absolute; margin-left:235px; margin-top:0px;"
                            kananBawah6B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB7" Then
                            askKananBawah7B.Checked = True
                            kananBawah7B.Attributes("style") = "display:block; position:absolute; margin-left:265px; margin-top:25px;"
                            kananBawah7B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB8" Then
                            askKananBawah8B.Checked = True
                            kananBawah8B.Attributes("style") = "display:block; position:absolute; margin-left:300px; margin-top:0px;"
                            kananBawah8B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB9" Then
                            askKananBawah9B.Checked = True
                            kananBawah9B.Attributes("style") = "display:block; position:absolute; margin-left:350px; margin-top:25px;"
                            kananBawah9B.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kiri atas
                        If MyRecReadA("kode") = "KIA" Then
                            askKiriAtasB.Checked = True
                            kiriAtasB.Attributes("style") = "display:block; position:absolute; margin-left:220px; margin-top:-45px;"
                            kiriAtasB.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kiri tengah
                        If MyRecReadA("kode") = "KIT1" Then
                            askKiriTengah1B.Checked = True
                            kiriTengah1B.Attributes("style") = "display:block; position:absolute; margin-left:60px; margin-top:-55px;"
                            kiriTengah1B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT2" Then
                            askKiriTengah2B.Checked = True
                            kiriTengah2B.Attributes("style") = "display:block; position:absolute; margin-left:130px; margin-top:-80px;"
                            kiriTengah2B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT3" Then
                            askKiriTengah3B.Checked = True
                            kiriTengah3B.Attributes("style") = "display:block; position:absolute; margin-left:165px; margin-top:-55px;"
                            kiriTengah3B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT4" Then
                            askKiriTengah4B.Checked = True
                            kiriTengah4B.Attributes("style") = "display:block; position:absolute; margin-left:190px; margin-top:-80px;"
                            kiriTengah4B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT5" Then
                            askKiriTengah5B.Checked = True
                            KiriTengah5B.Attributes("style") = "display:block; position:absolute; margin-left:220px; margin-top:-55px;"
                            KiriTengah5B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT6" Then
                            askKiriTengah6B.Checked = True
                            kiriTengah6B.Attributes("style") = "display:block; position:absolute; margin-left:250px;  margin-top:-80px; "
                            kiriTengah6B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT7" Then
                            askKiriTengah7B.Checked = True
                            kiriTengah7B.Attributes("style") = "display:block; position:absolute; margin-left:280px; margin-top:-55px;"
                            kiriTengah7B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT8" Then
                            askKiriTengah8B.Checked = True
                            kiriTengah8B.Attributes("style") = "display:block; position:absolute; margin-left:340px; margin-top:-40px;"
                            kiriTengah8B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT9" Then
                            askKiriTengah9B.Checked = True
                            kiriTengah9B.Attributes("style") = "display:block; position:absolute; margin-left:380px; margin-top:-30px;"
                            kiriTengah9B.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kiri bawah
                        If MyRecReadA("kode") = "KIB1" Then
                            askKiriBawah1B.Checked = True
                            kiriBawah1B.Attributes("style") = "display:block; position:absolute; margin-left:45px; margin-top:0px;"
                            kiriBawah1B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB2" Then
                            askKiriBawah2B.Checked = True
                            kiriBawah2B.Attributes("style") = "display:block; position:absolute; margin-left:95px;"
                            kiriBawah2B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB3" Then
                            askKiriBawah3B.Checked = True
                            kiriBawah3B.Attributes("style") = "display:block; position:absolute; margin-left:135px; margin-top:25px;"
                            kiriBawah3B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB4" Then
                            askKiriBawah4B.Checked = True
                            kiriBawah4B.Attributes("style") = "display:block; position:absolute;  margin-left:175px; margin-top:0px;"
                            kiriBawah4B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB5" Then
                            askKiriBawah5B.Checked = True
                            kiriBawah5B.Attributes("style") = "display:block; position:absolute; margin-left:210px; margin-top:25px;"
                            kiriBawah5B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB6" Then
                            askKiriBawah6B.Checked = True
                            kiriBawah6B.Attributes("style") = "display:block; position:absolute; margin-left:245px; margin-top:0px;"
                            kiriBawah6B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB7" Then
                            askKiriBawah7B.Checked = True
                            kiriBawah7B.Attributes("style") = "display:block; position:absolute; margin-left:275px; margin-top:25px;"
                            kiriBawah7B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB8" Then
                            askKiriBawah8B.Checked = True
                            kiriBawah8B.Attributes("style") = "display:block; position:absolute; margin-left:310px;"
                            kiriBawah8B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB9" Then
                            askKiriBawah9B.Checked = True
                            kiriBawah9B.Attributes("style") = "display:block; position:absolute; margin-left:360px; margin-top:25px;"
                            kiriBawah9B.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian atas kiri
                        If MyRecReadA("kode") = "AKI1" Then
                            askAtasKiri1B.Checked = True
                            atasKiri1B.Attributes("style") = "display:block; position:absolute; margin-left:60px; margin-top:-45px;"
                            atasKiri1B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI2" Then
                            askAtasKiri2B.Checked = True
                            atasKiri2B.Attributes("style") = "display:block; position:absolute; margin-left:135px; margin-top:-45px;"
                            atasKiri2B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI3" Then
                            askAtasKiri3B.Checked = True
                            atasKiri3B.Attributes("style") = "display:block; position:absolute; margin-left:185px; margin-top:-45px;"
                            atasKiri3B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI4" Then
                            askAtasKiri4B.Checked = True
                            atasKiri4B.Attributes("style") = "display:block; position:absolute; margin-left:240px; margin-top:-45px;"
                            atasKiri4B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI5" Then
                            askAtasKiri5B.Checked = True
                            atasKiri5B.Attributes("style") = "display:block; position:absolute; margin-left:355px; margin-top:-45px;"
                            atasKiri5B.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian atas kanan
                        If MyRecReadA("kode") = "AK1" Then
                            askAtasKanan1B.Checked = True
                            atasKanan1B.Attributes("style") = "display:block; position:absolute; margin-left:55px; margin-top:5px;"
                            atasKanan1B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK2" Then
                            askAtasKanan2B.Checked = True
                            atasKanan2B.Attributes("style") = "display:block; position:absolute; margin-left:135px; margin-top:5px;"
                            atasKanan2B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK3" Then
                            askAtasKanan3B.Checked = True
                            atasKanan3B.Attributes("style") = "display:block; position:absolute; margin-left:190px; margin-top:5px;"
                            atasKanan3B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK4" Then
                            askAtasKanan4B.Checked = True
                            atasKanan4B.Attributes("style") = "display:block; position:absolute; margin-left:240px; margin-top:5px;"
                            atasKanan4B.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK5" Then
                            askAtasKanan5B.Checked = True
                            atasKanan5B.Attributes("style") = "display:block; position:absolute; margin-left:360px; margin-top:5px;"
                            atasKanan5B.Text = MyRecReadA("kondisi")
                        End If
                    End If

                    If MyRecReadA("kode") = "Q1" Then
                        Q11.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q2" Then
                        Q22.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q3" Then
                        Q33.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q4" Then
                        Q44.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q5" Then
                        Q55.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q6" Then
                        Q66.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q7" Then
                        Q77.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q8" Then
                        Q88.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q9" Then
                        Q99.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q10" Then
                        Q100.Text = MyRecReadA("jawaban")
                    End If

                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                peringatan.Text = "Terdapat Error di Detail Checklist / Noise"
            End Try

            Try
                cnn.Open()
                cmd = New OleDbCommand(mSqlCommadstring3, cnn)
                MyRecReadA = cmd.ExecuteReader()
                GetData_Checklist = IIf(MyRecReadA.HasRows = True, 1, 0)
                While MyRecReadA.Read()
                    tglMasuk.Text = Format(MyRecReadA("tglMasuk"), "yyyy-MM-dd HH:mm:ss")
                    nm_petugas.Text = MyRecReadA("petugasAwal")
                    If (MyRecReadA("catatan") Is DBNull.Value) Then
                        catatan.Text = ""
                    ElseIf (MyRecReadA("catatan") IsNot DBNull.Value) Then
                        catatan.Text = MyRecReadA("catatan")
                    End If
                    If (MyRecReadA("kategori") = "1") Then
                        depanAccord.Visible = False
                        depanCRV.Visible = True
                        atasAccord.Visible = False
                        atasCRV.Visible = True
                        kiriAccord.Visible = False
                        kiriCRV.Visible = True
                        kananAccord.Visible = False
                        kananCRV.Visible = True
                        belakangAccord.Visible = False
                        belakangCRV.Visible = True
                    ElseIf (MyRecReadA("kategori") = "2") Then
                        depanAccord.Visible = True
                        depanCRV.Visible = False
                        atasAccord.Visible = True
                        atasCRV.Visible = False
                        kiriAccord.Visible = True
                        kiriCRV.Visible = False
                        kananAccord.Visible = True
                        kananCRV.Visible = False
                        belakangAccord.Visible = True
                        belakangCRV.Visible = False
                    End If
                End While
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
                peringatan.Text = "Terdapat Error di Detail Noise"
                'Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub Simpan_Click(sender As Object, e As EventArgs) Handles Simpan.Click
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim nopol1 As String = CType(Session.Item("nopol1"), String)
        Dim tglMasuk1 As String = CType(Session.Item("tglMasuk1"), String)
        Dim GetData_Checklist As Integer
        Dim mSqlCommadstring As String = "Select * From TEMP_CHECKLISTD INNER JOIN TEMP_CHECKLISTH ON TEMP_CHECKLISTD.nopol = TEMP_CHECKLISTH.nopol where TEMP_CHECKLISTD.nopol='" + nopol1 + "' AND DATEDIFF (day,TEMP_CHECKLISTD.tglMasuk,'" + tglMasuk1 + "')=0"

        Dim MyRecReadA As OleDbDataReader

        Call UpdateData_Tabel("DELETE FROM TEMP_CHECKLISTD WHERE nopol='" & nopol.Text & "' AND DATEDIFF (day,tglMasuk,'" & tglMasuk.Text & "')=0")
        Dim kode, kondisi, keterangan, jawaban, ordometer1 As String
        Dim battery, ukuranBanDepanKiri, kondisiBanDepanKiri1, ukuranBanDepanKanan, kondisiBanDepanKanan1, keteranganBanDepan1 As String
        Dim ukuranBanBelakangKiri, kondisiBanBelakangKiri1, ukuranBanBelakangKanan, kondisiBanBelakangKanan1, keteranganBanBelakang1, bensin1 As String


        Dim tglUpdate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Dim petugas As String = CType(Session.Item("username"), String)
        Dim catatan1 As String = catatan.Text
        If (petugas <> nm_petugas.Text) Then
            Call insertChecklist_Tabel("UPDATE TEMP_CHECKLISTH set tglUpdate= '" + tglUpdate + "', petugas='" + petugas + "' , catatan='" + catatan1 + "' where nopol = '" + nopol1 + "' AND DATEDIFF (day,tglMasuk,'" + tglMasuk1 + "')=0")
        Else
            Call insertChecklist_Tabel("UPDATE TEMP_CHECKLISTH set tglUpdate= '" + tglUpdate + "', catatan='" + catatan1 + "' where nopol = '" + nopol1 + "' AND DATEDIFF (day,tglMasuk,'" + tglMasuk1 + "')=0")
        End If


        If ordometer.Text = "" Then
            ordometerNotice.Text = "Ordometer Wajib Diisi"
        End If

        If kondisiBaterai.Text <> "" Then
            battery = kondisiBaterai.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','A','" + battery + "','" + tglMasuk.Text + "')")
        End If

        If banDepanKiri.Text <> "" Then
            ukuranBanDepanKiri = banDepanKiri.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','B','" + ukuranBanDepanKiri + "','" + tglMasuk.Text + "')")
        End If

        If kondisiBanDepanKiri.Text <> "" Then
            kondisiBanDepanKiri1 = kondisiBanDepanKiri.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','C','" + kondisiBanDepanKiri1 + "','" + tglMasuk.Text + "')")
        End If

        If banDepanKanan.Text <> "" Then
            ukuranBanDepanKanan = banDepanKanan.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','D','" + ukuranBanDepanKanan + "','" + tglMasuk.Text + "')")
        End If

        If kondisiBanDepanKanan.Text <> "" Then
            kondisiBanDepanKanan1 = kondisiBanDepanKanan.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','E','" + kondisiBanDepanKanan1 + "','" + tglMasuk.Text + "')")
        End If

        If keteranganBanDepan.Text <> "" Then
            keteranganBanDepan1 = keteranganBanDepan.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','F','" + keteranganBanDepan1 + "','" + tglMasuk.Text + "')")
        End If

        If banBelakangKiri.Text <> "" Then
            ukuranBanBelakangKiri = banBelakangKiri.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','G','" + ukuranBanBelakangKiri + "','" + tglMasuk.Text + "')")
        End If

        If kondisiBanBelakangKiri.Text <> "" Then
            kondisiBanBelakangKiri1 = kondisiBanBelakangKiri.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','H','" + kondisiBanBelakangKiri1 + "','" + tglMasuk.Text + "')")
        End If

        If banBelakangKanan.Text <> "" Then
            ukuranBanBelakangKanan = banBelakangKanan.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','I','" + ukuranBanBelakangKanan + "','" + tglMasuk.Text + "')")
        End If

        If kondisiBanBelakangKanan.Text <> "" Then
            kondisiBanBelakangKanan1 = kondisiBanBelakangKanan.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','J','" + kondisiBanBelakangKanan1 + "','" + tglMasuk.Text + "')")
        End If

        If keteranganBanBelakang.Text <> "" Then
            keteranganBanBelakang1 = keteranganBanBelakang.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','K','" + keteranganBanBelakang1 + "','" + tglMasuk.Text + "')")
        End If

        If bensin.Text <> "" Then
            bensin1 = bensin.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','L','" + bensin1 + "','" + tglMasuk.Text + "')")
        End If

        If ordometer.Text <> "" Then
            ordometer1 = ordometer.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','M','" + ordometer1 + "','" + tglMasuk.Text + "')")
        End If

        If stnkMasuk.Checked Then
            kode = "AKS1"
            keterangan = stnk.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If kasetMasuk.Checked Then
            kode = "AKS2"
            keterangan = kaset.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If uangMasuk.Checked Then
            kode = "AKS3"
            keterangan = uang.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If pemantikApiMasuk.Checked Then
            kode = "AKS4"
            keterangan = pemantikApi.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If karpetMasuk.Checked Then
            kode = "AKS5"
            keterangan = karpet.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If bukuServiceMasuk.Checked Then
            kode = "AKS6"
            keterangan = bukuService.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If velgMasuk.Checked Then
            kode = "AKS7"
            keterangan = velg.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If bukuMasuk.Checked Then
            kode = "AKS8"
            keterangan = buku.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If toolKitMasuk.Checked Then
            kode = "AKS9"
            keterangan = toolKit.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If dongkrakMasuk.Checked Then
            kode = "AKS10"
            keterangan = dongkrak.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If banMasuk.Checked Then
            kode = "AKS11"
            keterangan = ban.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If coverBanMasuk.Checked Then
            kode = "AKS12"
            keterangan = coverBan.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If panelMasuk.Checked Then
            kode = "AKS13"
            keterangan = panel.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If powerWindowMasuk.Checked Then
            kode = "AKS14"
            keterangan = powerWindow.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If centralLockMasuk.Checked Then
            kode = "AKS15"
            keterangan = centralLock.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If wiperMasuk.Checked Then
            kode = "AKS16"
            keterangan = wiper.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If radioMasuk.Checked Then
            kode = "AKS17"
            keterangan = radio.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If cdMasuk.Checked Then
            kode = "AKS18"
            keterangan = cd.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If acMasuk.Checked Then
            kode = "AKS19"
            keterangan = ac.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
        End If

        If remTanganMasuk.Checked Then
            kode = "AKS20"
            keterangan = remTangan.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, keterangan, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + keterangan + "','" + tglMasuk.Text + "')")
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

        If askDepanAtas1A.Checked Then
            kode = "DA1"
            kondisi = depanAtas1A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanAtas2A.Checked Then
            kode = "DA2"
            kondisi = depanAtas2A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanAtas3A.Checked Then
            kode = "DA3"
            kondisi = depanAtas3A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanAtas4A.Checked Then
            kode = "DA4"
            kondisi = depanAtas4A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanAtas5A.Checked Then
            kode = "DA5"
            kondisi = depanAtas5A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Depan Tengah' 
        If askDepanTengah1A.Checked Then
            kode = "DT1"
            kondisi = depanTengah1A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanTengah2A.Checked Then
            kode = "DT2"
            kondisi = depanTengah2A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanTengah3A.Checked Then
            kode = "DT3"
            kondisi = depanTengah3A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanTengah4A.Checked Then
            kode = "DT4"
            kondisi = depanTengah4A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanTengah5A.Checked Then
            kode = "DT5"
            kondisi = depanTengah5A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Depan Bawah' 
        If askDepanBawah1A.Checked Then
            kode = "DB1"
            kondisi = depanBawah1A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanBawah2A.Checked Then
            kode = "DB2"
            kondisi = depanBawah2A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanBawah3A.Checked Then
            kode = "DB3"
            kondisi = depanBawah3A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanBawah4A.Checked Then
            kode = "DB4"
            kondisi = depanBawah4A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanBawah5A.Checked Then
            kode = "DB5"
            kondisi = depanBawah5A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Belakang Atas' 
        If askBelakangAtas1A.Checked Then
            kode = "BA1"
            kondisi = belakangAtas1A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangAtas2A.Checked Then
            kode = "BA2"
            kondisi = belakangAtas2A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangAtas3A.Checked Then
            kode = "BA3"
            kondisi = belakangAtas3A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangAtas4A.Checked Then
            kode = "BA4"
            kondisi = belakangAtas4A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangAtas5A.Checked Then
            kode = "BA5"
            kondisi = belakangAtas5A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangAtas6A.Checked Then
            kode = "BA6"
            kondisi = belakangAtas6A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Belakang Tengah' 
        If askBelakangTengah1A.Checked Then
            kode = "BT1"
            kondisi = belakangTengah1A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangTengah2A.Checked Then
            kode = "BT2"
            kondisi = belakangTengah2A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangTengah3A.Checked Then
            kode = "BT3"
            kondisi = belakangTengah3A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangTengah4A.Checked Then
            kode = "BT4"
            kondisi = belakangTengah4A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangTengah5A.Checked Then
            kode = "BT5"
            kondisi = belakangTengah5A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangTengah6A.Checked Then
            kode = "BT6"
            kondisi = belakangTengah6A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Belakang Bawah' 
        If askBelakangBawah1A.Checked Then
            kode = "BB1"
            kondisi = belakangBawah1A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangBawah2A.Checked Then
            kode = "BB2"
            kondisi = belakangBawah2A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangBawah3A.Checked Then
            kode = "BB3"
            kondisi = belakangBawah3A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangBawah4A.Checked Then
            kode = "BB4"
            kondisi = belakangBawah4A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangBawah5A.Checked Then
            kode = "BB5"
            kondisi = belakangBawah5A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangBawah6A.Checked Then
            kode = "BB6"
            kondisi = belakangBawah6A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian kanan Atas' 
        If askKananAtasA.Checked Then
            kode = "KA1"
            kondisi = kananAtasA.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Kanan Tengah' 
        If askKananTengah1A.Checked Then
            kode = "KT1"
            kondisi = kananTengah1A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah2A.Checked Then
            kode = "KT2"
            kondisi = kananTengah2A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah3A.Checked Then
            kode = "KT3"
            kondisi = kananTengah3A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah4A.Checked Then
            kode = "KT4"
            kondisi = kananTengah4A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah5A.Checked Then
            kode = "KT5"
            kondisi = kananTengah5A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah6A.Checked Then
            kode = "KT6"
            kondisi = kananTengah6A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah7A.Checked Then
            kode = "KT7"
            kondisi = kananTengah7A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah8A.Checked Then
            kode = "KT8"
            kondisi = kananTengah8A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah9A.Checked Then
            kode = "KT9"
            kondisi = kananTengah9A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah10A.Checked Then
            kode = "KT10"
            kondisi = kananTengah10A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Kanan Bawah' 
        If askKananBawah1A.Checked Then
            kode = "KB1"
            kondisi = kananBawah1A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah2A.Checked Then
            kode = "KB2"
            kondisi = kananBawah2A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah3A.Checked Then
            kode = "KB3"
            kondisi = kananBawah3A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah4A.Checked Then
            kode = "KB4"
            kondisi = kananBawah4A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah5A.Checked Then
            kode = "KB5"
            kondisi = kananBawah5A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah6A.Checked Then
            kode = "KB6"
            kondisi = kananBawah6A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah7A.Checked Then
            kode = "KB7"
            kondisi = kananBawah7A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah8A.Checked Then
            kode = "KB8"
            kondisi = kananBawah8A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah9A.Checked Then
            kode = "KB9"
            kondisi = kananBawah9A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah10A.Checked Then
            kode = "KB10"
            kondisi = kananBawah10A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Kiri Atas' 
        If askKiriAtasA.Checked Then
            kode = "KIA"
            kondisi = kiriAtasA.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Kiri Tengah' 
        If askKiriTengah1A.Checked Then
            kode = "KIT1"
            kondisi = kiriTengah1A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah2A.Checked Then
            kode = "KIT2"
            kondisi = kiriTengah2A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah3A.Checked Then
            kode = "KIT3"
            kondisi = kiriTengah3A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah4A.Checked Then
            kode = "KIT4"
            kondisi = kiriTengah4A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah5A.Checked Then
            kode = "KIT5"
            kondisi = kiriTengah5A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah6A.Checked Then
            kode = "KIT6"
            kondisi = kiriTengah6A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah7A.Checked Then
            kode = "KIT7"
            kondisi = kiriTengah7A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah8A.Checked Then
            kode = "KIT8"
            kondisi = kiriTengah8A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah9A.Checked Then
            kode = "KIT9"
            kondisi = kiriTengah9A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah10A.Checked Then
            kode = "KIT10"
            kondisi = kiriTengah10A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Kiri Bawah' 
        If askKiriBawah1A.Checked Then
            kode = "KIB1"
            kondisi = kiriBawah1A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah2A.Checked Then
            kode = "KIB2"
            kondisi = kiriBawah2A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah3A.Checked Then
            kode = "KIB3"
            kondisi = kiriBawah3A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah4A.Checked Then
            kode = "KIB4"
            kondisi = kiriBawah4A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah5A.Checked Then
            kode = "KIB5"
            kondisi = kiriBawah5A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah6A.Checked Then
            kode = "KIB6"
            kondisi = kiriBawah6A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah7A.Checked Then
            kode = "KIB7"
            kondisi = kiriBawah7A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah8A.Checked Then
            kode = "KIB8"
            kondisi = kiriBawah8A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah9A.Checked Then
            kode = "KIB9"
            kondisi = kiriBawah9A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah10A.Checked Then
            kode = "KIB10"
            kondisi = kiriBawah10A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Atas Kanan' 
        If askAtasKanan1A.Checked Then
            kode = "AK1"
            kondisi = atasKanan1A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKanan2A.Checked Then
            kode = "AK2"
            kondisi = atasKanan2A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKanan3A.Checked Then
            kode = "AK3"
            kondisi = atasKanan3A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKanan4A.Checked Then
            kode = "AK4"
            kondisi = atasKanan4A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKanan5A.Checked Then
            kode = "AK5"
            kondisi = atasKanan5A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKanan6A.Checked Then
            kode = "AK6"
            kondisi = atasKanan6A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKanan7A.Checked Then
            kode = "AK7"
            kondisi = atasKanan7A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Atas Kiri' 
        If askAtasKiri1A.Checked Then
            kode = "AKI1"
            kondisi = atasKiri1A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKiri2A.Checked Then
            kode = "AKI2"
            kondisi = atasKiri2A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKiri3A.Checked Then
            kode = "AKI3"
            kondisi = atasKiri3A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKiri4A.Checked Then
            kode = "AKI4"
            kondisi = atasKiri4A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKiri5A.Checked Then
            kode = "AKI5"
            kondisi = atasKiri5A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKiri6A.Checked Then
            kode = "AKI6"
            kondisi = AtasKiri6A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKiri7A.Checked Then
            kode = "AKI7"
            kondisi = AtasKiri7A.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanAtas1B.Checked Then
            kode = "DA1"
            kondisi = depanAtas1B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanAtas2B.Checked Then
            kode = "DA2"
            kondisi = depanAtas2B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Inputan Data Sedan

        'Mengambil Input Data Kondisi Bagian Depan Atas' 
        If askDepanAtas3B.Checked Then
            kode = "DA3"
            kondisi = depanAtas3B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanAtas4B.Checked Then
            kode = "DA4"
            kondisi = depanAtas4B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanAtas5B.Checked Then
            kode = "DA5"
            kondisi = depanAtas5B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Depan Tengah' 
        If askDepanTengah1B.Checked Then
            kode = "DT1"
            kondisi = depanTengah1B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanTengah2B.Checked Then
            kode = "DT2"
            kondisi = depanTengah2B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanTengah3B.Checked Then
            kode = "DT3"
            kondisi = depanTengah3B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanTengah4B.Checked Then
            kode = "DT4"
            kondisi = depanTengah4B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanTengah5B.Checked Then
            kode = "DT5"
            kondisi = depanTengah5B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Depan Bawah' 
        If askDepanBawah1B.Checked Then
            kode = "DB1"
            kondisi = depanBawah1B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanBawah2B.Checked Then
            kode = "DB2"
            kondisi = depanBawah2B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanBawah3B.Checked Then
            kode = "DB3"
            kondisi = depanBawah3B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanBawah4B.Checked Then
            kode = "DB4"
            kondisi = depanBawah4B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askDepanBawah5B.Checked Then
            kode = "DB5"
            kondisi = depanBawah5B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Belakang Atas' 
        If askBelakangAtas1B.Checked Then
            kode = "BA1"
            kondisi = belakangAtas1B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangAtas2B.Checked Then
            kode = "BA2"
            kondisi = belakangAtas2B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangAtas3B.Checked Then
            kode = "BA3"
            kondisi = belakangAtas3B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangAtas4B.Checked Then
            kode = "BA4"
            kondisi = belakangAtas4B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangAtas5B.Checked Then
            kode = "BA5"
            kondisi = belakangAtas5B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Belakang Tengah' 
        If askBelakangTengah1B.Checked Then
            kode = "BT1"
            kondisi = belakangTengah1B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangTengah2B.Checked Then
            kode = "BT2"
            kondisi = belakangTengah2B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangTengah3B.Checked Then
            kode = "BT3"
            kondisi = belakangTengah3B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangTengah4B.Checked Then
            kode = "BT4"
            kondisi = belakangTengah4B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangTengah5B.Checked Then
            kode = "BT5"
            kondisi = belakangTengah5B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Belakang Bawah' 
        If askBelakangBawah1B.Checked Then
            kode = "BB1"
            kondisi = belakangBawah1B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangBawah2B.Checked Then
            kode = "BB2"
            kondisi = belakangBawah2B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangBawah3B.Checked Then
            kode = "BB3"
            kondisi = belakangBawah3B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangBawah4B.Checked Then
            kode = "BB4"
            kondisi = belakangBawah4B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askBelakangBawah5B.Checked Then
            kode = "BB5"
            kondisi = belakangBawah5B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian kanan Atas' 
        If askKananAtasB.Checked Then
            kode = "KA1"
            kondisi = kananAtasB.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Kanan Tengah' 
        If askKananTengah1B.Checked Then
            kode = "KT1"
            kondisi = kananTengah1B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah2B.Checked Then
            kode = "KT2"
            kondisi = kananTengah2B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah3B.Checked Then
            kode = "KT3"
            kondisi = kananTengah3B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah4B.Checked Then
            kode = "KT4"
            kondisi = kananTengah4B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah5B.Checked Then
            kode = "KT5"
            kondisi = kananTengah5B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah6B.Checked Then
            kode = "KT6"
            kondisi = kananTengah6B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah7B.Checked Then
            kode = "KT7"
            kondisi = kananTengah7B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah8B.Checked Then
            kode = "KT8"
            kondisi = kananTengah8B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananTengah9B.Checked Then
            kode = "KT9"
            kondisi = kananTengah9B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Kanan Bawah' 
        If askKananBawah1B.Checked Then
            kode = "KB1"
            kondisi = kananBawah1B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah2B.Checked Then
            kode = "KB2"
            kondisi = kananBawah2B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah3B.Checked Then
            kode = "KB3"
            kondisi = kananBawah3B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah4B.Checked Then
            kode = "KB4"
            kondisi = kananBawah4B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah5B.Checked Then
            kode = "KB5"
            kondisi = kananBawah5B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah6B.Checked Then
            kode = "KB6"
            kondisi = kananBawah6B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah7B.Checked Then
            kode = "KB7"
            kondisi = kananBawah7B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah8B.Checked Then
            kode = "KB8"
            kondisi = kananBawah8B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKananBawah9B.Checked Then
            kode = "KB9"
            kondisi = kananBawah9B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Kiri Atas' 
        If askKiriAtasB.Checked Then
            kode = "KIA"
            kondisi = kiriAtasB.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Kiri Tengah' 
        If askKiriTengah1B.Checked Then
            kode = "KIT1"
            kondisi = kiriTengah1B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah2B.Checked Then
            kode = "KIT2"
            kondisi = kiriTengah2B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah3B.Checked Then
            kode = "KIT3"
            kondisi = kiriTengah3B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah4B.Checked Then
            kode = "KIT4"
            kondisi = kiriTengah4B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah5B.Checked Then
            kode = "KIT5"
            kondisi = KiriTengah5B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah6B.Checked Then
            kode = "KIT6"
            kondisi = kiriTengah6B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah7B.Checked Then
            kode = "KIT7"
            kondisi = kiriTengah7B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah8B.Checked Then
            kode = "KIT8"
            kondisi = kiriTengah8B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriTengah9B.Checked Then
            kode = "KIT9"
            kondisi = kiriTengah9B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Kiri Bawah' 
        If askKiriBawah1B.Checked Then
            kode = "KIB1"
            kondisi = kiriBawah1B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah2B.Checked Then
            kode = "KIB2"
            kondisi = kiriBawah2B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah3B.Checked Then
            kode = "KIB3"
            kondisi = kiriBawah3B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah4B.Checked Then
            kode = "KIB4"
            kondisi = kiriBawah4B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah5B.Checked Then
            kode = "KIB5"
            kondisi = kiriBawah5B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah6B.Checked Then
            kode = "KIB6"
            kondisi = kiriBawah6B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah7B.Checked Then
            kode = "KIB7"
            kondisi = kiriBawah7B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah8B.Checked Then
            kode = "KIB8"
            kondisi = kiriBawah8B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askKiriBawah9B.Checked Then
            kode = "KIB9"
            kondisi = kiriBawah9B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Atas Kanan' 
        If askAtasKanan1B.Checked Then
            kode = "AK1"
            kondisi = atasKanan1B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKanan2B.Checked Then
            kode = "AK2"
            kondisi = atasKanan2B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKanan3B.Checked Then
            kode = "AK3"
            kondisi = atasKanan3B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKanan4B.Checked Then
            kode = "AK4"
            kondisi = atasKanan4B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKanan5B.Checked Then
            kode = "AK5"
            kondisi = atasKanan5B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Mengambil Input Data Kondisi Bagian Atas Kiri' 
        If askAtasKiri1B.Checked Then
            kode = "AKI1"
            kondisi = atasKiri1B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKiri2B.Checked Then
            kode = "AKI2"
            kondisi = atasKiri2B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKiri3B.Checked Then
            kode = "AKI3"
            kondisi = atasKiri3B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKiri4B.Checked Then
            kode = "AKI4"
            kondisi = atasKiri4B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        If askAtasKiri5B.Checked Then
            kode = "AKI5"
            kondisi = atasKiri5B.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, kondisi, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + kondisi + "','" + tglMasuk.Text + "')")
        End If

        'Input pertanyaan Noise
        If Q1.Text <> "" Then
            kode = "Q1"
            jawaban = Q1.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk.Text + "')")
        End If

        If Q2.Text <> "" Then
            kode = "Q2"
            jawaban = Q2Selections()
            jawaban = jawaban.Replace("&nbsp", " ")
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk.Text + "')")
        End If

        If Q3.Text <> "" Then
            kode = "Q3"
            jawaban = Q3Selections()
            jawaban = jawaban.Replace("&nbsp", " ")
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk.Text + "')")
        End If

        If Q4.Text <> "" Then
            kode = "Q4"
            jawaban = Q4Selections()
            jawaban = jawaban.Replace("&nbsp", " ")
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk.Text + "')")
        End If

        If Q5.Text <> "" Then
            kode = "Q5"
            jawaban = Q5Selections()
            jawaban = jawaban.Replace("&nbsp", " ")
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk.Text + "')")
        End If

        If Q6.Text <> "" Then
            kode = "Q6"
            jawaban = Q6Selections()
            jawaban = jawaban.Replace("&nbsp", " ")
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk.Text + "')")
        End If

        If Q7.Text <> "" Then
            kode = "Q7"
            jawaban = Q7Selections()
            jawaban = jawaban.Replace("&nbsp", " ")
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk.Text + "')")
        End If

        If Q8.Text <> "" Then
            kode = "Q8"
            jawaban = Q8Selections()
            jawaban = jawaban.Replace("&nbsp", " ")
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk.Text + "')")
        End If

        If Q9.Text <> "" Then
            kode = "Q9"
            jawaban = Q9Selections()
            jawaban = jawaban.Replace("&nbsp", " ")
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk.Text + "')")
        End If

        If Q10.Text <> "" Then
            kode = "Q10"
            jawaban = Q10.Text
            Call insertChecklist_Tabel("INSERT INTO TEMP_CHECKLISTD(nopol, kode, jawaban, tglMasuk) VALUES('" + nopol1 + "','" + kode + "','" + jawaban + "','" + tglMasuk.Text + "')")
        End If

        Response.Write("<script>alert('Data Checklist Berhasil Di Simpan')</script>")
        Response.Write("<script>window.location.href='cariChecklist.aspx';</script>")


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

    Function UpdateData_Tabel(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
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
            MsgBox(ex.Message)
        End Try
    End Function

    Function UpdateData_Tabel2(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        UpdateData_Tabel2 = 0
        cnn = New OleDbConnection(strconn)

        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_Tabel2 = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
End Class

