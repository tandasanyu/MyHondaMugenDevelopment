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
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Xml




' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WebService

    Inherits System.Web.Services.WebService
    Public MyRecReadA As OleDbDataReader
    <WebMethod()>
    Function bill(ByVal c As String, bid As String, id As String, amt As String, lang As String, aid As String) _
    As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        'Dim RRN2 As Integer = Val(RRN)
        Dim MyRecReadA As OleDbDataReader
        cnn = New OleDbConnection(strconn)
        If c = 1 And amt = 0 Then

            Try
                cnn.Open()
                cmd = New OleDbCommand("SELECT * FROM TRXN_BILL where idCust='" & id & "'", cnn)
                MyRecReadA = cmd.ExecuteReader()
                If MyRecReadA.HasRows = True Then
                    MyRecReadA.Read()
                    Dim screenText As String
                    Dim mLength As Byte
                    If (MyRecReadA("response")) Is DBNull.Value Then
                        If lang = 1 Then
                            screenText = "BL TH"
                            mLength = 7
                        Else
                            screenText = "MM YY"
                            mLength = 8
                        End If
                        For mUlang As Byte = 1 To mLength
                            screenText = screenText + Chr(160)
                        Next
                        screenText = screenText + ": " + nSr(MyRecReadA("screen1"))

                        If Len(screenText) < 31 Then
                            For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen1"))))
                                screenText = screenText + Chr(160)
                            Next
                        End If


                        If nSr(MyRecReadA("screen2")) <> "" Then
                            screenText = screenText + nSr(MyRecReadA("screen2"))
                            If Len(nSr(MyRecReadA("screen2"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen2"))))
                                    screenText = screenText + Chr(160)
                                Next
                            End If
                        End If

                        If nSr(MyRecReadA("screen3")) <> "" Then
                            screenText = screenText + nSr(MyRecReadA("screen3"))
                            If Len(nSr(MyRecReadA("screen3"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen3"))))
                                    screenText = screenText + Chr(160)
                                Next
                            End If
                        End If
                        Call UpdateData_Server("UPDATE TRXN_BILL SET screenText ='" & screenText & "', idBiller ='" & bid & "', aid ='" & aid & "', response= 0 WHERE idCust = '" & id & "'")
                        Dim cn As OleDbConnection = New OleDbConnection(WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString)
                        cn.Open()
                        Dim cm As OleDbCommand = New OleDbCommand("SELECT idBiller, idCust, custName, replicate('0', 12- len(amount)) + cast (amount as varchar) as amount, replicate('0', 3- len(trxType)) + cast (trxType as varchar) as trxType, field1, replicate('0', 2- len(response)) + cast (response as varchar) as response, screenText FROM TRXN_BILL where idCust='" & id & "'", cn)
                        Dim rd As OleDbDataReader = cm.ExecuteReader()
                        Dim ds = New DataSet
                        ds.Tables.Add(New DataTable("TRXN_BILL"))
                        ds.Load(rd, LoadOption.Upsert, ds.Tables("TRXN_BILL"))
                        Return ds.GetXml()
                    Else
                        Dim xmlString = "<?xml version='1.0' encoding='ISO-8859-1'?><note>" & vbCrLf &
                                        " <response>014</response>" & vbCrLf &
                                        "</note>"
                        Dim xmlElem = XElement.Parse(xmlString)
                        Return xmlElem.ToString()
                    End If
                Else
                    Dim xmlString = "<?xml version='1.0' encoding='ISO-8859-1'?><note>" & vbCrLf &
                                        " <response>014</response>" & vbCrLf &
                                        "</note>"
                    Dim xmlElem = XElement.Parse(xmlString)
                    Return xmlElem.ToString()
                End If
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
            End Try

        ElseIf c = 2 And amt = 0 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand("SELECT * FROM TRXN_BILL where idCust='" & id & "'", cnn)
                MyRecReadA = cmd.ExecuteReader()
                If MyRecReadA.HasRows = True Then
                    MyRecReadA.Read()
                    If (MyRecReadA("response") = 0) And (MyRecReadA("response2") Is DBNull.Value) Then
                        Dim receiptText As String
                        Dim mLength As Byte
                        Dim jarak1 As Byte
                        Dim jarak2 As Byte
                        Dim jarak3 As Byte
                        Dim kalimat1 As String
                        Dim kalimat2 As String
                        Dim kalimat3 As String
                        'receiptText1 = nSr(MyRecReadA("screen1"))
                        If lang = 1 Then
                            receiptText = "BL TH"
                            mLength = 7
                            jarak1 = 5
                            jarak2 = 11
                            jarak3 = 25
                            kalimat1 = "MOHON SIMPAN STRUK INI"
                            kalimat2 = "SEBAGAI"
                            kalimat3 = "BUKTI PEMBAYARAN YANG SAH"
                        Else
                            receiptText = "MM YY"
                            mLength = 8
                            jarak1 = 10
                            jarak2 = 15
                            jarak3 = 25
                            kalimat1 = "PLEASE KEEP"
                            kalimat2 = "THIS RECEIPT AS VALID"
                            kalimat3 = "PROOF OF PAYMENT"
                        End If

                        For mUlang As Byte = 1 To mLength
                            receiptText = receiptText + Chr(160)
                        Next
                        receiptText = receiptText + ": " + nSr(MyRecReadA("screen1"))
                        If Len(receiptText) < 31 Then
                            For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen1"))))
                                receiptText = receiptText + Chr(160)
                            Next
                        End If

                        If nSr(MyRecReadA("screen2")) <> "" Then
                            receiptText = receiptText + nSr(MyRecReadA("screen2"))
                            If Len(nSr(MyRecReadA("screen2"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen3"))))
                                    receiptText = receiptText + Chr(160)
                                Next
                            End If
                        End If

                        If nSr(MyRecReadA("screen3")) <> "" Then
                            receiptText = receiptText + nSr(MyRecReadA("screen3"))
                            If Len(nSr(MyRecReadA("screen3"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen3"))))
                                    receiptText = receiptText + Chr(160)
                                Next
                            End If
                        End If

                        If nSr(MyRecReadA("screen4")) <> "" Then
                            receiptText = receiptText + nSr(MyRecReadA("screen4"))
                            If Len(nSr(MyRecReadA("screen4"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen4"))))
                                    receiptText = receiptText + Chr(160)
                                Next
                            End If
                        End If

                        If nSr(MyRecReadA("screen5")) <> "" Then
                            receiptText = receiptText + nSr(MyRecReadA("screen5"))
                            If Len(nSr(MyRecReadA("screen5"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen5"))))
                                    receiptText = receiptText + Chr(160)
                                Next
                            End If
                        End If

                        If nSr(MyRecReadA("screen6")) <> "" Then
                            receiptText = receiptText + nSr(MyRecReadA("screen6"))
                            If Len(nSr(MyRecReadA("screen6"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen6"))))
                                    receiptText = receiptText + Chr(160)
                                Next
                            End If
                        End If

                        For mUlang As Byte = 1 To jarak1
                            receiptText = receiptText + Chr(160)
                        Next
                        receiptText = receiptText + kalimat1
                        If Len(receiptText) < 31 Then
                            For mUlang As Byte = 1 To 31 - (Len(kalimat1))
                                receiptText = receiptText + Chr(160)
                            Next
                        End If

                        For mUlang As Byte = 1 To jarak2
                            receiptText = receiptText + Chr(160)
                        Next
                        receiptText = receiptText + kalimat2
                        If Len(receiptText) < 31 Then
                            For mUlang As Byte = 1 To 31 - (Len(kalimat2))
                                receiptText = receiptText + Chr(160)
                            Next
                        End If

                        For mUlang As Byte = 1 To jarak3
                            receiptText = receiptText + Chr(160)
                        Next
                        receiptText = receiptText + kalimat3
                        If Len(receiptText) < 31 Then
                            For mUlang As Byte = 1 To 31 - (Len(kalimat3))
                                receiptText = receiptText + Chr(160)
                            Next
                        End If

                        Call UpdateData_Server("UPDATE TRXN_BILL SET receiptText ='" & receiptText & "', response2 ='0',, tglPayment ='" & Now() & "' WHERE idCust = '" & id & "'")

                        Dim cn As OleDbConnection = New OleDbConnection(WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString)
                        cn.Open()
                        Dim cm As OleDbCommand = New OleDbCommand("SELECT idBiller, idCust, custName, trxType, replicate('0', 12- len(amount)) + cast (amount as varchar) as amount, field1, replicate('0', 2- len(response)) + cast (response as varchar) as response, refNo, RRN, screenText, receiptText FROM TRXN_BILL where idCust='" & id & "'", cn)
                        Dim rd As OleDbDataReader = cm.ExecuteReader()
                        If rd.HasRows = True Then
                            rd.Read()
                            Dim xmlString = "<?xml version='1.0' encoding='ISO-8859-1'?><note>" & vbCrLf &
                            "  <idBiller>" + nSr(rd("idBiller")) + "</idBiller>" & vbCrLf &
                            "  <idCust>" + nSr(rd("idCust")) + "</idCust>" & vbCrLf &
                            "  <custName>" + nSr(rd("custName")) + "</custName>" & vbCrLf &
                            "  <amount>" + nSr(rd("amount")) + "</amount>" & vbCrLf &
                            "  <response>" + nSr(rd("response")) + "</response>" & vbCrLf &
                            "  <refNo>" + nSr(rd("refNo")) + "</refNo>" & vbCrLf &
                            "  <RRN>" + nSr(rd("RRN")) + "</RRN>" & vbCrLf &
                            "  <screenText>" + nSr(rd("screenText")) + "</screenText>" & vbCrLf &
                            "  <receiptText>" + nSr(rd("receiptText")) + "</receiptText>" & vbCrLf &
                            "</note>"
                            Dim xmlElem = XElement.Parse(xmlString)
                            Return xmlElem.ToString()

                        End If
                        rd.Close()
                        cm.Dispose()
                        cn.Close()

                    Else
                        Dim xmlString = "<?xml version='1.0' encoding='ISO-8859-1'?><note>" & vbCrLf &
                                            " <response>096</response>" & vbCrLf &
                                            "</note>"
                        Dim xmlElem = XElement.Parse(xmlString)
                        Return xmlElem.ToString()
                    End If
                End If
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
            End Try
        End If
    End Function


    <WebMethod()>
    Function billing(ByVal c As String, bid As String, id As String, amt As String, lang As String, aid As String) _
    As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand

        Dim MyRecReadA As OleDbDataReader
        cnn = New OleDbConnection(strconn)
        If c = 1 And amt = 0 Then

            Try
                cnn.Open()
                cmd = New OleDbCommand("SELECT * FROM TRXN_BILL where idCust='" & id & "'", cnn)
                MyRecReadA = cmd.ExecuteReader()
                If MyRecReadA.HasRows = True Then
                    MyRecReadA.Read()
                    Dim screenText As String
                    Dim mLength As Byte
                    If (MyRecReadA("response")) Is DBNull.Value Then
                        If lang = 1 Then
                            screenText = "BL TH"
                            mLength = 7
                        Else
                            screenText = "MM YY"
                            mLength = 8
                        End If
                        For mUlang As Byte = 1 To mLength
                            screenText = screenText + Chr(160)
                        Next
                        screenText = screenText + ": " + nSr(MyRecReadA("screen1"))

                        If Len(screenText) < 31 Then
                            For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen1"))))
                                screenText = screenText + Chr(160)
                            Next
                        End If


                        If nSr(MyRecReadA("screen2")) <> "" Then
                            screenText = screenText + nSr(MyRecReadA("screen2"))
                            If Len(nSr(MyRecReadA("screen2"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen2"))))
                                    screenText = screenText + Chr(160)
                                Next
                            End If
                        End If

                        If nSr(MyRecReadA("screen3")) <> "" Then
                            screenText = screenText + nSr(MyRecReadA("screen3"))
                            If Len(nSr(MyRecReadA("screen3"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen3"))))
                                    screenText = screenText + Chr(160)
                                Next
                            End If
                        End If
                        Call UpdateData_Server("UPDATE TRXN_BILL SET screenText ='" & screenText & "', idBiller ='" & bid & "', aid ='" & aid & "', response= 0 WHERE idCust = '" & id & "'")

                        Dim cn As OleDbConnection = New OleDbConnection(WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString)
                        cn.Open()
                        Dim cm As OleDbCommand = New OleDbCommand("SELECT idBiller, idCust, custName, replicate('0', 12- len(amount)) + cast (amount as varchar) as amount, replicate('0', 3- len(trxType)) + cast (trxType as varchar) as trxType, field1, replicate('0', 2- len(response)) + cast (response as varchar) as response, screenText FROM TRXN_BILL where idCust='" & id & "'", cn)
                        Dim rd As OleDbDataReader = cm.ExecuteReader()
                        If rd.HasRows = True Then
                            rd.Read()
                            Dim xmlString = "<?xml version='1.0' encoding='ISO-8859-1'?><note>" & vbCrLf &
                                "  <idBiller>" + nSr(rd("idBiller")) + "</idBiller>" & vbCrLf &
                                "  <idCust>" + nSr(rd("idCust")) + "</idCust>" & vbCrLf &
                                "  <custName>" + nSr(rd("custName")) + "</custName>" & vbCrLf &
                                "  <amount>" + nSr(rd("amount")) + "</amount>" & vbCrLf &
                                "  <trxType>" + nSr(rd("trxType")) + "</trxType>" & vbCrLf &
                                "  <response>" + nSr(rd("response")) + "</response>" & vbCrLf &
                                "  <screenText>" + nSr(rd("screenText")) + "</screenText>" & vbCrLf &
                                "</note>"
                            Dim xmlElem = XElement.Parse(xmlString)
                            Return xmlElem.ToString()
                        End If
                        rd.Close()
                        cm.Dispose()
                        cn.Close()
                    Else
                        Dim xmlString = "<?xml version='1.0' encoding='ISO-8859-1'?><note>" & vbCrLf &
                                        " <response>014</response>" & vbCrLf &
                                        "</note>"
                        Dim xmlElem = XElement.Parse(xmlString)
                        Return xmlElem.ToString()
                    End If
                Else
                    Dim xmlString = "<?xml version='1.0' encoding='ISO-8859-1'?><note>" & vbCrLf &
                                        " <response>014</response>" & vbCrLf &
                                        "</note>"
                    Dim xmlElem = XElement.Parse(xmlString)
                    Return xmlElem.ToString()
                End If
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
            End Try
        End If
    End Function

    <WebMethod()>
    Function payment(ByVal c As String, bid As String, id As String, amt As String, lang As String, aid As String, ByVal tid As String, ByVal RRN As String) _
    As String
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim RRN2 As Integer = Val(RRN)
        Dim MyRecReadA As OleDbDataReader
        cnn = New OleDbConnection(strconn)
        If c = 2 And amt = 0 Then
            Try
                cnn.Open()
                cmd = New OleDbCommand("SELECT * FROM TRXN_BILL where idCust='" & id & "'", cnn)
                MyRecReadA = cmd.ExecuteReader()
                If MyRecReadA.HasRows = True Then
                    MyRecReadA.Read()
                    If (MyRecReadA("response") = 0) And (MyRecReadA("response2") Is DBNull.Value) Then
                        Dim receiptText As String
                        Dim mLength As Byte
                        Dim jarak1 As Byte
                        Dim jarak2 As Byte
                        Dim jarak3 As Byte
                        Dim kalimat1 As String
                        Dim kalimat2 As String
                        Dim kalimat3 As String
                        'receiptText1 = nSr(MyRecReadA("screen1"))
                        If lang = 1 Then
                            receiptText = "BL TH"
                            mLength = 7
                            jarak1 = 5
                            jarak2 = 11
                            jarak3 = 25
                            kalimat1 = "MOHON SIMPAN STRUK INI"
                            kalimat2 = "SEBAGAI"
                            kalimat3 = "BUKTI PEMBAYARAN YANG SAH"
                        Else
                            receiptText = "MM YY"
                            mLength = 8
                            jarak1 = 10
                            jarak2 = 15
                            jarak3 = 25
                            kalimat1 = "PLEASE KEEP"
                            kalimat2 = "THIS RECEIPT AS VALID"
                            kalimat3 = "PROOF OF PAYMENT"
                        End If

                        For mUlang As Byte = 1 To mLength
                            receiptText = receiptText + Chr(160)
                        Next
                        receiptText = receiptText + ": " + nSr(MyRecReadA("screen1"))
                        If Len(receiptText) < 31 Then
                            For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen1"))))
                                receiptText = receiptText + Chr(160)
                            Next
                        End If

                        If nSr(MyRecReadA("screen2")) <> "" Then
                            receiptText = receiptText + nSr(MyRecReadA("screen2"))
                            If Len(nSr(MyRecReadA("screen2"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen3"))))
                                    receiptText = receiptText + Chr(160)
                                Next
                            End If
                        End If

                        If nSr(MyRecReadA("screen3")) <> "" Then
                            receiptText = receiptText + nSr(MyRecReadA("screen3"))
                            If Len(nSr(MyRecReadA("screen3"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen3"))))
                                    receiptText = receiptText + Chr(160)
                                Next
                            End If
                        End If

                        If nSr(MyRecReadA("screen4")) <> "" Then
                            receiptText = receiptText + nSr(MyRecReadA("screen4"))
                            If Len(nSr(MyRecReadA("screen4"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen4"))))
                                    receiptText = receiptText + Chr(160)
                                Next
                            End If
                        End If

                        If nSr(MyRecReadA("screen5")) <> "" Then
                            receiptText = receiptText + nSr(MyRecReadA("screen5"))
                            If Len(nSr(MyRecReadA("screen5"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen5"))))
                                    receiptText = receiptText + Chr(160)
                                Next
                            End If
                        End If

                        If nSr(MyRecReadA("screen6")) <> "" Then
                            receiptText = receiptText + nSr(MyRecReadA("screen6"))
                            If Len(nSr(MyRecReadA("screen6"))) < 31 Then
                                For mUlang As Byte = 1 To 31 - (Len(nSr(MyRecReadA("screen6"))))
                                    receiptText = receiptText + Chr(160)
                                Next
                            End If
                        End If

                        For mUlang As Byte = 1 To jarak1
                            receiptText = receiptText + Chr(160)
                        Next
                        receiptText = receiptText + kalimat1
                        If Len(receiptText) < 31 Then
                            For mUlang As Byte = 1 To 31 - (Len(kalimat1))
                                receiptText = receiptText + Chr(160)
                            Next
                        End If

                        For mUlang As Byte = 1 To jarak2
                            receiptText = receiptText + Chr(160)
                        Next
                        receiptText = receiptText + kalimat2
                        If Len(receiptText) < 31 Then
                            For mUlang As Byte = 1 To 31 - (Len(kalimat2))
                                receiptText = receiptText + Chr(160)
                            Next
                        End If

                        For mUlang As Byte = 1 To jarak3
                            receiptText = receiptText + Chr(160)
                        Next
                        receiptText = receiptText + kalimat3
                        If Len(receiptText) < 31 Then
                            For mUlang As Byte = 1 To 31 - (Len(kalimat3))
                                receiptText = receiptText + Chr(160)
                            Next
                        End If

                        Call UpdateData_Server("UPDATE TRXN_BILL SET receiptText ='" & receiptText & "', response2 ='0', RRN ='" & RRN2 & "', tid ='" & tid & "', tglPayment ='" & Now() & "' WHERE idCust = '" & id & "'")

                        Dim cn As OleDbConnection = New OleDbConnection(WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString)
                        cn.Open()
                        Dim cm As OleDbCommand = New OleDbCommand("SELECT idBiller, idCust, custName, trxType, replicate('0', 12- len(amount)) + cast (amount as varchar) as amount, field1, replicate('0', 2- len(response)) + cast (response as varchar) as response, refNo, RRN, screenText, receiptText FROM TRXN_BILL where idCust='" & id & "'", cn)
                        Dim rd As OleDbDataReader = cm.ExecuteReader()
                        If rd.HasRows = True Then
                            rd.Read()
                            Dim xmlString = "<?xml version='1.0' encoding='ISO-8859-1'?><note>" & vbCrLf &
                            "  <idBiller>" + nSr(rd("idBiller")) + "</idBiller>" & vbCrLf &
                            "  <idCust>" + nSr(rd("idCust")) + "</idCust>" & vbCrLf &
                            "  <custName>" + nSr(rd("custName")) + "</custName>" & vbCrLf &
                            "  <amount>" + nSr(rd("amount")) + "</amount>" & vbCrLf &
                            "  <response>" + nSr(rd("response")) + "</response>" & vbCrLf &
                            "  <refNo>" + nSr(rd("refNo")) + "</refNo>" & vbCrLf &
                            "  <RRN>" + nSr(rd("RRN")) + "</RRN>" & vbCrLf &
                            "  <screenText>" + nSr(rd("screenText")) + "</screenText>" & vbCrLf &
                            "  <receiptText>" + nSr(rd("receiptText")) + "</receiptText>" & vbCrLf &
                            "</note>"
                            Dim xmlElem = XElement.Parse(xmlString)
                            Return xmlElem.ToString()

                        End If
                        rd.Close()
                        cm.Dispose()
                        cn.Close()

                    Else
                        Dim xmlString = "<?xml version='1.0' encoding='ISO-8859-1'?><note>" & vbCrLf &
                                            " <response>096</response>" & vbCrLf &
                                            "</note>"
                        Dim xmlElem = XElement.Parse(xmlString)
                        Return xmlElem.ToString()
                    End If
                End If
                MyRecReadA.Close()
                cmd.Dispose()
                cnn.Close()
            Catch ex As Exception
            End Try
        End If
    End Function

    <WebMethod()>
    Function GetCustomers(ByVal bid As Double, id As Double, amt As Double) As String
        Dim constr As String = ConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("SELECT idBiller, idCust, custName, replicate('0', 12- len(amount)) + cast (amount as varchar) as amount, replicate('0', 3- len(trxType)) + cast (trxType as varchar) as trxType, field1, replicate('0', 2- len(response)) + cast (response as varchar) as response, screenText FROM TRXN_BILL where idCust='" & id & "'")
                cmd.Connection = con
                Dim ds As New DataSet()
                Using sda As New SqlDataAdapter(cmd)
                    sda.Fill(ds, "TRXN_BILL")
                End Using

                Return ds.GetXml()
            End Using
        End Using
    End Function

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()>
    Public Function getTb(ByVal c As String, bid As String, id As String, amt As String, lang As String, aid As String) As DataSet

        Dim cn As OleDbConnection = New OleDbConnection(WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString)
        cn.Open()
        Dim cm As OleDbCommand = New OleDbCommand("SELECT idBiller, idCust, custName, replicate('0', 12- len(amount)) + cast (amount as varchar) as amount, replicate('0', 3- len(trxType)) + cast (trxType as varchar) as trxType, field1, replicate('0', 2- len(response)) + cast (response as varchar) as response, screenText FROM TRXN_BILL where idCust='" & id & "'", cn)
        Dim rd As OleDbDataReader = cm.ExecuteReader()
        Dim ds = New DataSet
        ds.Tables.Add(New DataTable("TRXN_BILL"))
        ds.Load(rd, LoadOption.Upsert, ds.Tables("TRXN_BILL"))
        Return ds

    End Function
    Function UpdateData_Server(ByVal mSqlCommadstring As String) As Byte
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        Dim cmd As OleDbCommand
        UpdateData_Server = 0
        cnn = New OleDbConnection(strconn)
        Try
            cnn.Open()
            cmd = New OleDbCommand(mSqlCommadstring, cnn)
            cmd.ExecuteNonQuery()
            UpdateData_Server = 1
            cmd.Dispose()
            cnn.Close()
        Catch ex As Exception

        End Try
    End Function

    Function nSr(ByRef nilai As Object) As String
        On Error GoTo ErrHand
        nSr = ""
        nSr = IIf(IsDBNull(nilai), "", nilai)
ErrHand:
    End Function

    Function nSg(ByRef nilai As Object) As Integer
        On Error GoTo ErrHand
        nSg = 0
        nSg = IIf(IsDBNull(nilai), 0, Val(nilai))
ErrHand:
    End Function


    '<WebMethod(MessageName:="Tagihan")>
    'Public Function Bill2(firstnumber As Integer, secondnumber As Integer) _
    'As String
    'Return firstnumber + secondnumber
    'End Function

    '<WebMethod()>
    'Public Function Bill2(firstnumber As Integer, secondnumber As Integer, thirdnumber As Integer) _
    ' As String
    'Return firstnumber + secondnumber + thirdnumber
    ' End Function

End Class