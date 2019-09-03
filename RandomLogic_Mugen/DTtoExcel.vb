'FUNGSI DATA TABLE=====   
   Function getdataset(sql As String) As DataTable
        Dim ds As DataTable
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("MyConnCloudDnet2").ConnectionString
        Dim cnn As OleDbConnection
        cnn = New OleDbConnection(strconn)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, cnn)
        Try
            cnn.Open()
            ds = New DataTable
            da.Fill(ds)
        Catch ex As Exception
            ds = Nothing
        Finally
            cnn.Close()
            cnn.Dispose()
            da.Dispose()
        End Try
        Return ds
    End Function
	
'FUNGSI EXPORT TO EXCEL=====
    Public Sub ExportToExcel(ByVal dt As DataTable, ByVal filename As String)


        Dim response As HttpResponse = HttpContext.Current.Response
        response.Clear()
        response.Charset = ""
        response.ContentType = "application/vnd.ms-excel"
        response.AddHeader("Content-Disposition", "attachment;filename=""" & filename & """")

        Using sw As StringWriter = New StringWriter()

            Using htw As HtmlTextWriter = New HtmlTextWriter(sw)
                Dim dg As DataGrid = New DataGrid()
                dg.DataSource = dt
                dg.DataBind()
                dg.RenderControl(htw)
                response.Write(sw.ToString())
                response.[End]()
            End Using
        End Using
    End Sub
	
'FUNGSI BUTTON ========
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sqlds As String = "select * from data_izin_header"
        Dim ds As DataTable = getdataset(sqlds)
        Call ExportToExcel(ds, "Test.xls")
    End Sub
