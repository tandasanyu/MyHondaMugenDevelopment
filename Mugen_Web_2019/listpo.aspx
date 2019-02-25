<%@ Page Language="C#" AutoEventWireup="true" CodeFile="listpo.aspx.cs" Inherits="listpo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
     <link href="css/datepicker.css" rel="stylesheet" />
    <title>List Item Under Purchase Order</title>
     <style type="text/css">
        .datepicker {z-index: 1050;}

          #popup {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}

.window 
{
position:relative;	
width: 25%;
top:100px;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: center;
margin: 2% auto;
}

#popup:target {
visibility: visible;
}
    </style>
    <script language=javascript>
    function upper(ustr)
    {
        var str=ustr.value;
        ustr.value=str.toUpperCase();
    }
   
function Angka(a)
{
	if(!/^[0-9.]+$/.test(a.value))
	{
	a.value = a.value.substring(0,a.value.length-1000);
	}
}

</script>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
       

<!-- Modal -->


        
 <div id="popup">
 <div class="window">
 <div class="panel panel-primary" style="width:100%;margin:5px;">
  <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-log-in"></span> Terima Barang <button class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</button></div>
  <div class="panel-body">
   <asp:TextBox ID="txtJumlahTerima" style="margin:5px;" class="form-control input-sm" onkeyup="Angka(this)" placeholder="Jumlah yang diterima.." runat="server" ></asp:TextBox>
 <asp:TextBox ID="txtTanggalTerima" style="margin:5px;width:100px;" class="form-control input-sm" 
          placeholder="Pilih tgl terima" data-provide="datepicker" 
          runat="server" onkeyup="readOnly()"></asp:TextBox>
      <asp:Button ID="btnTerima" runat="server" Text="TERIMA" class="btn btn-primary btn-sm" Style="font-weight:bold;" OnClick="btnTerima_Click" />
       </div></div>
  </div></div>

        <div class="kirih" style="float:left;width:20%;height:100px;padding:20px;">
         <asp:Image ID="Image1" runat="server" ImageUrl="~/img/hlogo.png" style="width:80px;height:60px;float:left;"/>
    </div>
    <div class="kirih" style="float:left;width:48%;height:100px;font-weight:bold;text-align:center;margin-right:20px;
    padding-top:50px;font-size:14pt;text-transform:uppercase;">
       <u> <asp:Label ID="Label1" runat="server" Text="List Barang Belum Terima" style="font-size:1.0em;"></asp:Label></u>  <br />
        <asp:Label ID="Label8" runat="server" Text="Setelah anda membuat purchase order, maka list barang akan masuk disini apabila barang belum diterima dari vendor." style="font-size:0.65em;font-weight:normal;"></asp:Label>    
        </div>
        <div class="kirih" style="float:right;width:25%;height:100px;margin-bottom:25px;">
        <asp:Label ID="Label2" runat="server" Text="Honda Mugen" style="font-weight:bold;font-size:1.0em;"></asp:Label><br />    
        <asp:Label ID="Label3" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:0.8em;"></asp:Label><br />    
        <asp:Label ID="Label4" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:0.8em;"></asp:Label><br />      
        <asp:Label ID="Label5" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:0.8em;"></asp:Label><br />      
        <asp:Label ID="Label6" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:0.8em;"></asp:Label><br />      
        <asp:Label ID="Label7" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:0.8em;"></asp:Label>            
     </div>
      
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="2" DataSourceID="SqlDataSource1" EnableModelValidation="True" ForeColor="#333333" GridLines="None" PageSize="50" Style="position:relative;margin-top:10px;padding:0;font-size:0.85em;font-family:arial;" class="table table-bordered">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                  <asp:TemplateField HeaderText="No." SortExpression="nofmbhead" HeaderStyle-Width="5">
                  <ItemTemplate>
                     <center><asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label></center> 
                  </ItemTemplate>
              </asp:TemplateField>
                <asp:TemplateField HeaderText="Nomor PO" SortExpression="POFMB_no_po" HeaderStyle-Width="130">
                    <ItemTemplate>
                        <u><asp:Label ID="Label1" runat="server" Text='<%# Bind("POFMB_no_po") %>' style="color:blue;font-weight:bold;"></asp:Label></u><br />
                        <i><asp:Label ID="Label2" runat="server" Text='<%# Bind("POFMB_tgl_po") %>' style="font-size:8pt;color:#666;"></asp:Label></i>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vendor" SortExpression="POFMB_nama_vendor" HeaderStyle-Width="180">
                    <ItemTemplate>
                        <u><asp:Label ID="Label3" runat="server" Text='<%# Bind("POFMB_nama_vendor") %>' Style="font-size:1.0em;"></asp:Label></u><br />
                        <i>Tel:<asp:Label ID="Label2" runat="server" Text='<%# Bind("vendor_telp") %>' style="font-size:8pt;color:#666;"></asp:Label></i>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ship to" SortExpression="POFMB_nama_shipper" HeaderStyle-Width="180">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("POFMB_nama_shipper") %>' Style="font-size:1.0em;"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" SortExpression="POFMB_shipping_method" HeaderStyle-Width="5">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("POFMB_shipping_method") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Order" SortExpression="jumlahitem" HeaderStyle-Width="5">
                    <ItemTemplate>
                        <center><asp:Label ID="Label7" runat="server" Text='<%# Bind("jumlahitem") %>' style="font-weight:bold;color:blue;font-size:1.35em;"></asp:Label></center>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Terima" SortExpression="jumlah" HeaderStyle-Width="5">
                    <ItemTemplate>
                        <center><asp:Label ID="Label7" runat="server" Text='<%# Bind("jumlahterima") %>' style="font-weight:bold;color:blue;font-size:1.35em;"></asp:Label></center>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sisa" SortExpression="jumlah" HeaderStyle-Width="5">
                    <ItemTemplate>
                        <center><asp:Label ID="Label7" runat="server" Text='<%# Bind("jumlah") %>' style="font-weight:bold;color:#d60000;font-size:1.35em;"></asp:Label></center>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nama Barang" SortExpression="namaitem">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" HeaderStyle-Width="50">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "?id=" + Eval("idbody") + "#popup" %>' runat="server"  Text="<span class='glyphicon glyphicon-log-in'></span>&nbsp;&nbsp;Terima" class="btn btn-primary btn-xs" style="font-weight:bold;"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT POFMB_no_po, POFMB_tgl_po, POFMB_nama_vendor, jumlahitem, POFMB_nama_shipper, SUM(jumlahitem - jumlahterima) AS jumlah, POFMB_shipping_method, namaitem,  idbody, vendor_telp, POFMB_shipping_term, jumlahterima FROM fmbbody INNER JOIN pofmb ON pofmb.POFMB_no_po = fmbbody.nopurchaseorder INNER JOIN dbvendor ON POFMB.POFMB_nama_vendor = dbvendor.vendor_nama  GROUP BY POFMB_no_po, jumlahitem, POFMB_tgl_po, vendor_telp, POFMB_nama_shipper, POFMB_shipping_method, namaitem,  idbody, POFMB_telp_vendor, POFMB_nama_vendor, POFMB_shipping_term, jumlahterima HAVING(SUM(jumlahitem - jumlahterima) IS NULL OR SUM(jumlahitem - jumlahterima) > 0)"></asp:SqlDataSource>
    </div>

       
    </form>
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
function readOnly() {
    document.getElementById("txtTanggalTerima").setAttribute("readonly", "true");
}
</script>
  
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
