<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="daftarpobatal.aspx.cs" Inherits="daftarpobatal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen :: Waiting Purchase Order</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
     <link href="css/datepicker.css" rel="stylesheet" />
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
    <style>
         #price {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}

.windowprice
{
position:relative;	
width: 25%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}

#price:target {
visibility: visible;
}
   
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
     <div class="container-fluid">
     <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
  <li><a href="mintabeli.aspx"><span class="glyphicon glyphicon-comment"></span>&nbsp;&nbsp;Form Permintaan Pembelian</a></li>
 <li><span class="glyphicon glyphicon-list-alt"></span>&nbsp;&nbsp;Purchase Order</li>
  <li><span class="glyphicon glyphicon-list-alt"></span>&nbsp;&nbsp;Daftar Purchase Order</li>
</ol>
      <asp:GridView ID="GridView5" runat="server" AllowPaging="True" 
          AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource5" 
             class="table table-bordered" 
             style="width:100%;margin:0px;padding:0px;font-size:9pt;" CellPadding="4" 
             ForeColor="#333333" GridLines="None">
          <RowStyle BackColor="#EFF3FB" />
          <Columns>
           <asp:TemplateField HeaderText="No." SortExpression="total" HeaderStyle-Width="5">
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="No. Purhase Order" SortExpression="nofmbhead">
                  <ItemTemplate>
                      <u><strong><asp:Label ID="Label1" runat="server" Text='<%# Bind("POFMB_no_po") %>'></asp:Label></strong></u><br />
                       <i> <asp:Label ID="Label4" runat="server" Text='<%# Bind("tglpo") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Vendor" SortExpression="pemohonfmb">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label3" runat="server" Text='<%# Bind("vendor_nama") %>' style="font-weight:bold;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label4" runat="server" Text='<%# Bind("vendor_telp") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Shipment" SortExpression="disetujuifmb">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label3" runat="server" Text='<%# Bind("POFMB_shipping_method") %>' style="font-weight:bold;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label4" runat="server" Text='<%# Bind("POFMB_nama_shipper") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Payment" SortExpression="disetujuifmb">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label3" runat="server" Text='<%# Bind("vendor_pkp") %>' style="font-weight:bold;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label4" runat="server" Text='<%# Bind("POFMB_term_of_payment") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderStyle-Width="5">
                  <ItemTemplate>
                      <asp:HyperLink ID="HyperLink1" runat="server" 
                          NavigateUrl='<%# "printpo.aspx?q=" + Eval("POFMB_no_po") %>' Target="_blank" Text="<span class='glyphicon glyphicon-exclamation-sign'></span>&nbsp;Lihat PO" class="btn btn-primary btn-sm" style="font-weight:bold;"></asp:HyperLink>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditRowStyle BackColor="#2461BF" />
          <AlternatingRowStyle BackColor="White" />
      </asp:GridView>
       
      <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
          ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
          
          
          SelectCommand="SELECT *, convert(varchar, pofmb_tgl_po, 106) as tglpo FROM pofmb INNER JOIN dbvendor ON pofmb.pofmb_nama_vendor = dbvendor.vendor_nama INNER JOIN fmbbody ON pofmb.POFMB_no_po = fmbbody.nopurchaseorder WHERE rejectoleh IS NOT NULL ORDER BY POFMB_idpo DESC">
      </asp:SqlDataSource>          
                     </form>
                     </div>
                       <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
</asp:Content>

