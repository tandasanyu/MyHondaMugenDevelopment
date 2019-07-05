Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb.OleDbConnection
Imports System.Data.OleDb
Partial Class _Default
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim nopol As String = CType(Session.Item("nopol"), String)
        Dim GetData_Checklist As Integer
        Dim mSqlCommadstring As String = "Select * From TEMP_CHECKLIST where nopol='" + nopol + "'"
        Dim MyRecReadA As OleDbDataReader

        cnn = New OleDbConnection(strconn)
        GetData_Checklist = 0
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            MyRecReadA = cmd.ExecuteReader()
            GetData_Checklist = IIf(MyRecReadA.HasRows = True, 1, 0)
            While MyRecReadA.Read()
                nopol1.Text = nopol
                If MyRecReadA("kode") = "dA1" Then
                    askDepanKiriAtas.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "dA2" Then
                    askDepanTengahAtas.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "dA3" Then
                    askDepanKananAtas.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "dB1" Then
                    askDepanKiriBawah.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "dB2" Then
                    askDepanTengahBawah.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "dB3" Then
                    askDepanKananBawah.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "bA1" Then
                    askBelakangKiriAtas.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "bA2" Then
                    askBelakangTengahAtas.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "bA3" Then
                    askBelakangKananAtas.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "bB1" Then
                    askBelakangKiriBawah.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "bB2" Then
                    askBelakangTengahBawah.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "bB3" Then
                    askBelakangKananBawah.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kA1" Then
                    askKananAtas.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kT1" Then
                    askKananTengah1.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kT2" Then
                    askKananTengah2.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kT3" Then
                    askKananTengah3.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kT4" Then
                    askKananTengah4.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kT5" Then
                    askKananTengah5.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kT6" Then
                    askKananTengah6.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kT7" Then
                    askKananTengah7.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kT8" Then
                    askKananTengah8.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kB1" Then
                    askKananBawah1.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kB2" Then
                    askKananBawah2.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kB3" Then
                    askKananBawah3.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kB4" Then
                    askKananBawah4.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kB5" Then
                    askKananBawah5.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kB6" Then
                    askKananBawah6.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kB7" Then
                    askKananBawah7.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kB7" Then
                    askKananBawah7.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIA" Then
                    askKiriAtas.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIT1" Then
                    askKiriTengah1.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIT2" Then
                    askKiriTengah2.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIT3" Then
                    askKiriTengah3.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIT4" Then
                    askKiriTengah4.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIT5" Then
                    askKiriTengah5.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIT6" Then
                    askKiriTengah6.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIT7" Then
                    askKiriTengah7.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIT8" Then
                    askKiriTengah8.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIB1" Then
                    askKiriBawah1.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIB2" Then
                    askKiriBawah2.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIB3" Then
                    askKiriBawah3.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIB4" Then
                    askKiriBawah4.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIB5" Then
                    askKiriBawah5.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIB6" Then
                    askKiriBawah6.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "kIB7" Then
                    askKiriBawah7.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "aK1" Then
                    askAtasKanan1.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "aK2" Then
                    askAtasKanan2.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "aK3" Then
                    askAtasKanan3.Text = MyRecReadA("kondisi")
                End If


                If MyRecReadA("kode") = "aK4" Then
                    askAtasKanan4.Text = MyRecReadA("kondisi")
                End If


                If MyRecReadA("kode") = "aK5" Then
                    askAtasKanan5.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "aKI1" Then
                    askAtasKiri1.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "aKI2" Then
                    askAtasKiri2.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "aKI3" Then
                    askAtasKiri3.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "aKI4" Then
                    askAtasKiri4.Text = MyRecReadA("kondisi")
                End If

                If MyRecReadA("kode") = "aKI5" Then
                    askAtasKiri5.Text = MyRecReadA("kondisi")
                End If

            End While
            MyRecReadA.Close()
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class