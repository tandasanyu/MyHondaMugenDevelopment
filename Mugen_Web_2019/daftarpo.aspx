<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="daftarpo.aspx.cs" Inherits="daftarpo" %>

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
           .gridview{
    background-color:#507CD1;
   padding:2px;
   margin:5px auto;  
   font-family:Tahoma;
}
        .gridview a{
  margin:auto 1%;
  border-left: 1px solid #c0c0c0;
      background-color:#EFF3FB;
      padding:2px 7px 2px 7px;
      color:#333;
      text-decoration:none;
      -o-box-shadow:0px 1px 1px #666;
      -moz-box-shadow:0px 1px 1px #666;
      -webkit-box-shadow:0px 1px 1px #666;
      box-shadow:0px 1px 1px #666;
     
}
        .gridview a:hover{
    background-color:#c0c0c0;
    color:#fff;
}
        .gridview span{
    background-color:#c0c0c0;
    color:#fff;
     -o-box-shadow:1px 1px 1px #333;
      -moz-box-shadow:1px 1px 1px #333;
      -webkit-box-shadow:1px 1px 1px #333;
      box-shadow:1px 1px 1px #333;
      padding:2px 7px 2px 7px;
}

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
         <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Timer ID="Timer1" runat="server" OnTick="GetTime" Interval="1000" />
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
              <asp:TemplateField HeaderText="No. Purhase Order" SortExpression="POFMB_no_po">
                  <ItemTemplate>
                      <u><strong><asp:Label ID="Label1" runat="server" Text='<%# Bind("POFMB_no_po") %>'></asp:Label></strong></u><br />
                       <i> <asp:Label ID="Label4" runat="server" Text='<%# Bind("tglpo") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Vendor" SortExpression="vendor_nama">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label3" runat="server" Text='<%# Bind("vendor_nama") %>' style="font-weight:bold;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label4" runat="server" Text='<%# Bind("vendor_telp") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Shipment" SortExpression="POFMB_nama_shipper">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label3" runat="server" Text='<%# Bind("POFMB_shipping_method") %>' style="font-weight:bold;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label4" runat="server" Text='<%# Bind("POFMB_nama_shipper") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Payment" SortExpression="vendor_pkp">
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
           <pagerstyle cssclass="gridview"></pagerstyle>
          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditRowStyle BackColor="#2461BF" />
          <AlternatingRowStyle BackColor="White" />
      </asp:GridView>
       
      <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
          ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
          
          
          SelectCommand="SELECT *, convert(varchar, pofmb_tgl_po, 106) as tglpo FROM pofmb INNER JOIN dbvendor ON pofmb.pofmb_nama_vendor = dbvendor.vendor_nama ORDER BY POFMB_idpo DESC">
      </asp:SqlDataSource>
        
         </ContentTemplate>
</asp:UpdatePanel>
                     
                     </form>
                     </div>
                       <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
</asp:Content>

