Imports OnBarcode.Barcode.BarcodeScanner
Imports System.Drawing
Partial Class Default4
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Create a BarcodeReader object
        Dim barcodes As [String]() As String = String.Format(BarcodeScanner.Scan("code128-image.gif", BarcodeType.Code128))
    End Sub
End Class
