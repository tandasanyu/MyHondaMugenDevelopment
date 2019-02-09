Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Partial Class viewChecklist
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("username") = Nothing Then
            Response.Redirect("default.aspx")
        Else

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
            ' tglMasuk.Text = tglMasuk1

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
                        bensin.Attributes("style") = "width:" & bensin1
                        textBensin.Text = bensin1
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

                    'Menampilkan kondisi checklist SUV bagian depan atas
                    If MyRecReadA("kategori") = "1" Then
                        If MyRecReadA("kode") = "DA1" Then
                            depanAtas1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA2" Then
                            depanAtas2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA3" Then
                            depanAtas3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA4" Then
                            depanAtas4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA5" Then
                            depanAtas5.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian depan tengah
                        If MyRecReadA("kode") = "DT1" Then
                            depanTengah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT2" Then
                            depanTengah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT3" Then
                            depanTengah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT4" Then
                            depanTengah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT5" Then
                            depanTengah5.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian depan bawah
                        If MyRecReadA("kode") = "DB1" Then
                            depanBawah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB2" Then
                            depanBawah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB3" Then
                            depanBawah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB4" Then
                            depanBawah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB5" Then
                            depanBawah5.Text = MyRecReadA("kondisi")
                        End If


                        'Menampilkan kondisi checklist bagian kanan atas
                        If MyRecReadA("kode") = "KA" Then
                            kananAtas.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kanan tengah
                        If MyRecReadA("kode") = "KT1" Then
                            kananTengah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT2" Then
                            kananTengah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT3" Then
                            kananTengah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT4" Then
                            kananTengah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT5" Then
                            kananTengah5.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT6" Then
                            kananTengah6.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT7" Then
                            kananTengah7.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT8" Then
                            kananTengah8.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT9" Then
                            kananTengah9.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT10" Then
                            kananTengah10.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kanan bawah
                        If MyRecReadA("kode") = "KB1" Then
                            kananBawah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB2" Then
                            kananBawah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB3" Then
                            kananBawah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB4" Then
                            kananBawah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB5" Then
                            kananBawah5.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB6" Then
                            kananBawah6.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB7" Then
                            kananBawah7.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB8" Then
                            kananBawah8.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB9" Then
                            kananBawah9.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB10" Then
                            kananBawah10.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian belakang atas
                        If MyRecReadA("kode") = "BA1" Then
                            belakangAtas1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA2" Then
                            belakangAtas2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA3" Then
                            belakangAtas3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA4" Then
                            belakangAtas4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA5" Then
                            belakangAtas5.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA6" Then
                            belakangAtas6.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian belakang tengah
                        If MyRecReadA("kode") = "BT1" Then
                            belakangTengah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT2" Then
                            belakangTengah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT3" Then
                            belakangTengah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT4" Then
                            belakangTengah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT5" Then
                            belakangTengah5.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT6" Then
                            belakangTengah6.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian belakang bawah
                        If MyRecReadA("kode") = "BB1" Then
                            belakangBawah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB2" Then
                            belakangBawah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB3" Then
                            belakangBawah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB4" Then
                            belakangBawah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB5" Then
                            belakangBawah5.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB6" Then
                            belakangBawah6.Text = MyRecReadA("kondisi")
                        End If


                        'Menampilkan kondisi checklist bagian kiri atas
                        If MyRecReadA("kode") = "KIA" Then
                            kiriAtas.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kiri tengah
                        If MyRecReadA("kode") = "KIT1" Then
                            kiriTengah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT2" Then
                            kiriTengah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT3" Then
                            kiriTengah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT4" Then
                            kiriTengah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT5" Then
                            kiriTengah5.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT6" Then
                            kiriTengah6.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT7" Then
                            kiriTengah7.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT8" Then
                            kiriTengah8.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT9" Then
                            kiriTengah9.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT10" Then
                            kiriTengah10.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kiri bawah
                        If MyRecReadA("kode") = "KIB1" Then
                            kiriBawah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB2" Then
                            kiriBawah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB3" Then
                            kiriBawah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB4" Then
                            kiriBawah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB5" Then
                            kiriBawah5.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB6" Then
                            kiriBawah6.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB7" Then
                            kiriBawah7.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB8" Then
                            kiriBawah8.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB9" Then
                            kiriBawah9.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB10" Then
                            kiriBawah10.Text = MyRecReadA("kondisi")
                        End If


                        'Menampilkan kondisi checklist bagian atas kanan
                        If MyRecReadA("kode") = "AK1" Then
                            atasKanan1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK2" Then
                            atasKanan2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK3" Then
                            atasKanan3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK4" Then
                            atasKanan4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK5" Then
                            atasKanan5.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK6" Then
                            atasKanan6.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK7" Then
                            atasKanan7.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian atas kiri
                        If MyRecReadA("kode") = "AKI1" Then
                            atasKiri1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI2" Then
                            atasKiri2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI3" Then
                            atasKiri3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI4" Then
                            atasKiri4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI5" Then
                            atasKiri5.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI6" Then
                            atasKiri6.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI7" Then
                            atasKiri7.Text = MyRecReadA("kondisi")
                        End If
                    End If
                    'Menampilkan kondisi checklist Sedan bagian depan atas

                    If MyRecReadA("kategori") = "2" Then
                        If MyRecReadA("kode") = "DA1" Then
                            askDepanAtas1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA2" Then
                            askDepanAtas2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA3" Then
                            askDepanAtas3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA4" Then
                            askDepanAtas4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DA5" Then
                            askDepanAtas5.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian depan tengah
                        If MyRecReadA("kode") = "DT1" Then
                            askDepanTengah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT2" Then
                            askDepanTengah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT3" Then
                            askDepanTengah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT4" Then
                            askDepanTengah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DT5" Then
                            askDepanTengah5.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian depan bawah
                        If MyRecReadA("kode") = "DB1" Then
                            askDepanBawah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB2" Then
                            askDepanBawah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB3" Then
                            askDepanBawah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB4" Then
                            askDepanBawah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "DB5" Then
                            askDepanBawah5.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian belakang atas
                        If MyRecReadA("kode") = "BA1" Then
                            askBelakangAtas1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA2" Then
                            askBelakangAtas2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA3" Then
                            askBelakangAtas3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA4" Then
                            askBelakangAtas4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BA5" Then
                            askBelakangAtas5.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian belakang tengah
                        If MyRecReadA("kode") = "BT1" Then
                            askBelakangTengah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT2" Then
                            askBelakangTengah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT3" Then
                            askBelakangTengah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT4" Then
                            askBelakangTengah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BT5" Then
                            askBelakangTengah5.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian belakang bawah
                        If MyRecReadA("kode") = "BB1" Then
                            askBelakangBawah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB2" Then
                            askBelakangBawah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB3" Then
                            askBelakangBawah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB4" Then
                            askBelakangBawah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "BB5" Then
                            askBelakangBawah5.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kanan atas
                        If MyRecReadA("kode") = "KA" Then
                            askKananAtas.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kanan tengah
                        If MyRecReadA("kode") = "KT1" Then
                            askKananTengah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT2" Then
                            askKananTengah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT3" Then
                            askKananTengah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT4" Then
                            askKananTengah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT5" Then
                            askKananTengah5.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT6" Then
                            askKananTengah6.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT7" Then
                            askKananTengah7.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT8" Then
                            askKananTengah8.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KT9" Then
                            askKananTengah9.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kanan bawah
                        If MyRecReadA("kode") = "KB1" Then
                            askKananBawah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB2" Then
                            askKananBawah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB3" Then
                            askKananBawah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB4" Then
                            askKananBawah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB5" Then
                            askKananBawah5.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB6" Then
                            askKananBawah6.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB7" Then
                            askKananBawah7.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB8" Then
                            askKananBawah8.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KB9" Then
                            askKananBawah9.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kiri atas
                        If MyRecReadA("kode") = "KIA" Then
                            askKiriAtas.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kiri tengah
                        If MyRecReadA("kode") = "KIT1" Then
                            askKiriTengah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT2" Then
                            askKiriTengah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT3" Then
                            askKiriTengah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT4" Then
                            askKiriTengah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT5" Then
                            askKiriTengah5.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT6" Then
                            askKiriTengah6.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT7" Then
                            askKiriTengah7.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT8" Then
                            askKiriTengah8.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIT9" Then
                            askKiriTengah9.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian kiri bawah
                        If MyRecReadA("kode") = "KIB1" Then
                            askKiriBawah1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB2" Then
                            askKiriBawah2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB3" Then
                            askKiriBawah3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB4" Then
                            askKiriBawah4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB5" Then
                            askKiriBawah5.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB6" Then
                            askKiriBawah6.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB7" Then
                            askKiriBawah7.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB8" Then
                            askKiriBawah8.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "KIB9" Then
                            askKiriBawah9.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian atas kanan
                        If MyRecReadA("kode") = "AK1" Then
                            askAtasKanan1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK2" Then
                            askAtasKanan2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK3" Then
                            askAtasKanan3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK4" Then
                            askAtasKanan4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AK5" Then
                            askAtasKanan5.Text = MyRecReadA("kondisi")
                        End If

                        'Menampilkan kondisi checklist bagian atas kiri
                        If MyRecReadA("kode") = "AKI1" Then
                            askAtasKiri1.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI2" Then
                            askAtasKiri2.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI3" Then
                            askAtasKiri3.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI4" Then
                            askAtasKiri4.Text = MyRecReadA("kondisi")
                        End If

                        If MyRecReadA("kode") = "AKI5" Then
                            askAtasKiri5.Text = MyRecReadA("kondisi")
                        End If
                    End If

                    If MyRecReadA("kode") = "Q1" Then
                        Q1.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q2" Then
                        Q2.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q3" Then
                        Q3.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q4" Then
                        Q4.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q5" Then
                        Q5.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q6" Then
                        Q6.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q7" Then
                        Q7.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q8" Then
                        Q8.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q9" Then
                        Q9.Text = MyRecReadA("jawaban")
                    End If

                    If MyRecReadA("kode") = "Q10" Then
                        Q10.Text = MyRecReadA("jawaban")
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
                    If (MyRecReadA("petugas") Is DBNull.Value) Then
                        nm_petugas.Text = MyRecReadA("petugasAwal")
                    ElseIf (MyRecReadA("petugas") IsNot DBNull.Value) Then
                        nm_petugas.Text = MyRecReadA("petugas")
                    End If
                    If (MyRecReadA("catatan") Is DBNull.Value) Then
                        catatan.Text = "Tidak Ada Catatan"
                    ElseIf (MyRecReadA("catatan") IsNot DBNull.Value) Then
                        catatan.Text = MyRecReadA("catatan")
                    End If
                    tglMasuk.Text = Format(MyRecReadA("tglMasuk"), "yyyy-MM-dd HH:mm:ss")

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

                    If (Session("username") = MyRecReadA("petugasAwal") And MyRecReadA("petugas") Is DBNull.Value) Then
                        update.Attributes("style") = "display:block"
                    ElseIf (Session("username") <> MyRecReadA("petugasAwal") And MyRecReadA("petugas") Is DBNull.Value) Then
                        update.Attributes("style") = "display:block"
                    ElseIf (Session("username") = MyRecReadA("petugas")) Then
                        update.Attributes("style") = "display:block"
                    Else
                        update.Attributes("style") = "display:none"
                        box.Attributes("style") = "display:block"
                        keterangan.Text = "Data Checklist Tidak Bisa dirubah lagi karena sudah dirubah oleh " + MyRecReadA("petugas")
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
    Protected Sub update_Click(sender As Object, e As EventArgs) Handles update.Click
        Session("nopol") = CType(Session.Item("nopol"), String)
        Session("tglMasuk1") = CType(Session.Item("tglMasuk1"), String)
        Response.Redirect("editChecklist.aspx", True)
    End Sub
End Class
