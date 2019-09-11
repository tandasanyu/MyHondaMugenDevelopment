<%@ Page Language="C#" Debug="true" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewmintabeli.aspx.cs" Inherits="viewmintabeli" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen :: Buat Permintaan Pembelian</title>
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
#barang {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowbarang
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
#barang:target {
visibility: visible;
}
#barangheadpur {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowbarangheadpur
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
#barangheadpur:target {
visibility: visible;
}
#lampiran {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowlampiran 
{
position:relative;	
width: 50%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#lampiran:target {
visibility: visible;
}
#lampiranvpapp {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowlampiranvpapp
{
position:relative;	
width: 50%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#lampiranvpapp:target {
visibility: visible;
}
#lampiranpurchasing {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowlampiranpurchasing
{
position:relative;	
width: 50%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#lampiranpurchasing:target {
visibility: visible;
}
#rejectalldivisi {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowrejectalldivisi
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#rejectalldivisi:target {
visibility: visible;
}
#rejectall {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowrejectall
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#rejectall:target {
visibility: visible;
}
#rejectallpurchasing {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowrejectallpurchasing
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#rejectallpurchasing:target {
visibility: visible;
}
#rejectallheadpur {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowrejectallheadpur
#rejectallheadpur:target {
visibility: visible;
}
#rejectallvpapp {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowrejectallvpapp
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#rejectallvpapp:target {
visibility: visible;
}
#reject {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowreject
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#reject:target {
visibility: visible;
}
#rejectdivisi {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowrejectdivisi
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#rejectdivisi:target {
visibility: visible;
}
#rejectpurchasing {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowrejectpurchasing
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#rejectpurchasing:target {
visibility: visible;
}
#approve {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowapprove
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#approve:target {
visibility: visible;
}
#approvedivisi {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowapprovedivisi
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#approvedivisi:target {
visibility: visible;
}
#approvevpapp {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowapprovevpapp
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#approvevpapp:target {
visibility: visible;
}
#approvepurchasing {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowapprovepurchasing
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#approvepurchasing:target {
visibility: visible;}
#approveheadpur {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowapproveheadpur
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#approveheadpur:target {
visibility: visible;}
#vendor {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowvendor
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#vendor:target {
visibility: visible;
}
#rejectheadpur {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowrejectheadpur
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#rejectheadpur:target {
visibility: visible;
}
#rejectvpapp {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
.windowrejectvpapp
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}
#rejectvpapp:target {
visibility: visible;
}
#lampiranheadpur {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}
#lampiranheadpur:target {
visibility: visible;
}
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
     <div class="container-fluid">
     <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
  <li><a href="#"><span class="glyphicon glyphicon-edit"></span>&nbsp;&nbsp;Apply Form</a></li>
  <li><span class="glyphicon glyphicon-comment"></span>&nbsp;&nbsp;Approval</li>
</ol>
<div id="divisiApproval" runat="server">
            <div class="kirih" style="float:left;width:25%;height:100px;padding:20px;">
                <asp:Image ID="Image5" runat="server" ImageUrl="~/img/hlogo.png" style="width:80px;height:60px;float:left;"/>
            </div>
         <div class="kirih" style="float:left;width:50%;height:100px;font-weight:bold;text-align:center;padding-top:50px;font-size:14pt;text-transform:uppercase;">
                 <asp:Label ID="Label89" runat="server" Text="Permintaan Pembelian"></asp:Label> <br />
                 <asp:Label ID="lblDivNomor" runat="server" Text="" style="color:Blue;font-size:12pt;text-transform:normal;"></asp:Label>       
         </div>
        <div class="kirih" style="float:left;width:25%;height:100px;">
                 <asp:Label ID="Label91" runat="server" Text="Honda Mugen" style="font-weight:bold;"></asp:Label><br />    
                 <asp:Label ID="Label92" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:8pt;"></asp:Label><br />    
                 <asp:Label ID="Label93" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:8pt;"></asp:Label><br />      
                 <asp:Label ID="Label94" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:8pt;"></asp:Label><br />      
                 <asp:Label ID="Label95" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:8pt;"></asp:Label><br />      
                 <asp:Label ID="Label96" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:8pt;"></asp:Label>            
        </div>
        <asp:HyperLink ID="HyperLink22" runat="server" style="margin-left:5px;font-weight:bold;font-family:Tahoma;" class="btn btn-success btn-sm" NavigateUrl="#approvedivisi"><span class="glyphicon glyphicon-ok"></span> APPROVE</asp:HyperLink>
        <asp:HyperLink ID="HyperLink23" runat="server" style="margin-bottom:5px;margin-top:5px;font-weight:bold;font-family:Tahoma;" class="btn btn-danger btn-sm" NavigateUrl="#rejectalldivisi"><span class="glyphicon glyphicon-remove"></span> REJECT ALL</asp:HyperLink>
        
        <div class="row" style="background:linear-gradient(#f5f5f5, #c0c0c0);margin:5px;font-size:8pt;font-family:Verdana;border-bottom:1px solid #d60000;">
                 <div class="col-md-3">Dibuat, <asp:label runat="server" ID="lblDivDibuat" text="" style="color:blue;"></asp:label> </div>
                 <div class="col-md-3">Disetujui, <asp:label runat="server"  text="<i class='glyphicon glyphicon-info-sign'></i> Menunggu.." style="color:blue;"></asp:label> </div>
                 <div class="col-md-3">Mengetahui, <asp:label runat="server" text="<i class='glyphicon glyphicon-info-sign'></i> Menunggu.." style="color:blue;"></asp:label> </div>
                 <div class="col-md-3">Disetujui, <asp:label runat="server" text="<i class='glyphicon glyphicon-info-sign'></i> Menunggu.." style="color:blue;"></asp:label> </div>
        </div>
         <asp:GridView ID="GridView17" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource18" class="table table-bordered" style="margin:5px;font-size:9pt;" CellPadding="4" ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
                 <itemtemplate>
                     <%# Container.DataItemIndex + 1 %>
                 </ItemTemplate>
                    <headerstyle HorizontalAlign="Center" />
             </asp:TemplateField>
                 <asp:TemplateField HeaderText="Vendor" SortExpression="vendor">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("vendor") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama Barang" SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Beli" SortExpression="tujuanitem">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Minta" SortExpression="tujuanitem">
                   <ItemTemplate>
                        <asp:Label ID="Label81" runat="server" Text='<%# Bind("kelompokisi") %>' style="font-size:9pt;"></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Pusat Biaya" SortExpression="pusatbiaya">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("pusatbiaya") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qty" SortExpression="jumlahitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("jumlahitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("hargaitem","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total" SortExpression="Total" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("totl","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:HyperLink ID="linkRejectItem" runat="server" NavigateUrl='<%# "viewmintabeli.aspx?app0=" + Eval("nobody") + "&&id=" + Eval("idbody") + "&&aks=divisiapproval#rejectdivisi"  %>' 
                             Target="_self" Text="<span class='glyphicon glyphicon-ban-circle'></span>&nbsp;Reject" class="btn btn-danger btn-xs" style="font-weight:bold;"></asp:HyperLink>
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
         
                     <asp:SqlDataSource ID="SqlDataSource18" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT [idbody], case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [nobody], [namaitem], [vendor], [tujuanitem], [jumlahitem], [hargaitem], [reject], [alasanreject], [rejectoleh], [pusatbiaya], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody) AND reject = 'APPROVE'">
                              <SelectParameters>
                             <asp:QueryStringParameter Name="nobody" QueryStringField="app0" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                      <table style="width:70%;float:left;margin-left:5px;font-size:8pt;color:blue;font-family:Verdana;">
                      <tr><td>Note : Untuk pembelian diatas Rp. 2.000.000,- harus mendapat persetujuan dari Vice President Director</td></tr>
                        </table>
                     <table style="width:26%;float:right;border:1px solid #c0c0c0;" border="1">
                     <tr><td style="width:50%;padding:5px;text-align:right;font-weight:bold;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">TOTAL :</td>
                     <td style="width:50%;padding:5px;text-align:center;font-weight:bold;font-size:12pt;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">
                     <asp:Label ID="lblDivTotal" runat="server" Text=""></asp:Label>
                     </td></tr></table>
    <table style="float:left;width:100%;font-family:Verdana;font-size:8pt;text-align:center;font-weight:bold;color:#c60000;"><tr><td>Daftar Barang yg ditolak</td></tr></table>
      <center> <div id="spoiler">
<div><input style="font-size: 11px; padding: 2px;" onclick="if (this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display != '') { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = ''; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = 'none'; this.innerText = ''; this.value = 'Sembunyikan'; } else { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = 'none'; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = ''; this.innerText = ''; this.value = 'Tampilkan'; }" name="button" type="button" value="Tampilkan" /></div>
<div id="show" style="border: 1px solid white; display: none; margin: 5px; padding: 2px; width: 98%;">
    <asp:GridView ID="GridView18" runat="server" AutoGenerateColumns="False" 
                         DataSourceID="SqlDataSource9" 
                         class="table table-bordered table-striped" style="margin:5px;font-size:8pt;" EnableModelValidation="True" CellPadding="2" ForeColor="#333333" GridLines="None">
             <AlternatingRowStyle BackColor="White" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vendor" SortExpression="vendor">
                     <ItemTemplate>
                         <asp:Label ID="Label41" runat="server" Text='<%# Bind("vendor") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama Barang" SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label42" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Beli" SortExpression="tujuanitem">
                     <ItemTemplate>
                         <asp:Label ID="Label43" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Minta" SortExpression="tujuanitem">
                   <ItemTemplate>
                        <asp:Label ID="Label82" runat="server" Text='<%# Bind("kelompokisi") %>' style="font-size:9pt;"></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Pusat Biaya" SortExpression="pusatbiaya">
                     <ItemTemplate>
                         <asp:Label ID="Label44" runat="server" Text='<%# Bind("pusatbiaya") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Status" SortExpression="reject" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label45" runat="server" Text='<%# Bind("reject") %>' style="font-family:tahoma;font-weight:bold;color:#c60000;"></asp:Label><br />
                           </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                 </asp:TemplateField>
                     <asp:TemplateField HeaderText="Reject oleh" SortExpression="reject" HeaderStyle-Width="100">
                     <ItemTemplate>
                          <asp:Label ID="Label52" runat="server" Text='<%# Eval("rejectoleh") + "," %>' style="color:Blue;font-size:8pt;"></asp:Label>
                        </ItemTemplate>

<HeaderStyle Width="100px"></HeaderStyle>
                 </asp:TemplateField>
                     <asp:TemplateField HeaderText="Alasan" SortExpression="reject" HeaderStyle-Width="200">
                     <ItemTemplate>
                           <asp:Label ID="Label56" runat="server" Text='<%# Eval("alasanreject")  %>' style="color:Blue;font-size:8pt;"></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="200px"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qty" SortExpression="jumlahitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label48" runat="server" Text='<%# Bind("jumlahitem") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label49" runat="server" Text='<%# Bind("hargaitem","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="12px"></HeaderStyle>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total" SortExpression="Total" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label50" runat="server" Text='<%# Bind("totl","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="12px"></HeaderStyle>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
         </asp:GridView>
         </div><div id="hide"></div></div>
      
                     <asp:SqlDataSource ID="SqlDataSource19" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT [idbody], case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [nobody], [namaitem], [vendor], [tujuanitem], [jumlahitem], [hargaitem], [reject], [alasanreject], [rejectoleh], [pusatbiaya], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody) AND reject = 'REJECT'">
                              <SelectParameters>
                             <asp:QueryStringParameter Name="nobody" QueryStringField="app0" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                     </div>
<div id="headApproval" runat="server">
<div class="kirih" style="float:left;width:25%;height:100px;padding:20px;">
         <asp:Image ID="Image1" runat="server" ImageUrl="~/img/hlogo.png" style="width:80px;height:60px;float:left;"/>
    </div>
    <div class="kirih" style="float:left;width:50%;height:100px;font-weight:bold;text-align:center;
    padding-top:50px;font-size:14pt;text-transform:uppercase;">
        <asp:Label ID="Label1" runat="server" Text="Permintaan Pembelian"></asp:Label> <br />
         <asp:Label ID="lblNomor" runat="server" Text="" style="color:Blue;font-size:12pt;text-transform:normal;"></asp:Label>       
        </div>
        <div class="kirih" style="float:left;width:25%;height:100px;">
        <asp:Label ID="Label2" runat="server" Text="Honda Mugen" style="font-weight:bold;"></asp:Label><br />    
        <asp:Label ID="Label3" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:8pt;"></asp:Label><br />    
        <asp:Label ID="Label4" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label5" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label6" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label7" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:8pt;"></asp:Label>            
     </div>
         <asp:HyperLink ID="HyperLink2" runat="server" 
                 style="margin-left:5px;font-weight:bold;font-family:Tahoma;" 
                 class="btn btn-success btn-sm" NavigateUrl="#approve"><span class="glyphicon glyphicon-ok"></span> APPROVE</asp:HyperLink>
          <asp:HyperLink ID="HyperLink4" runat="server" style="margin-bottom:5px;margin-top:5px;font-weight:bold;font-family:Tahoma;" 
                 class="btn btn-danger btn-sm" NavigateUrl="#rejectall"><span class="glyphicon glyphicon-remove"></span> REJECT ALL</asp:HyperLink>
         <asp:HyperLink ID="HyperLink3" runat="server" style="margin-bottom:5px;margin-top:5px;font-weight:bold;font-family:Tahoma;" 
                 class="btn btn-warning btn-sm" NavigateUrl="#lampiran"><span class="glyphicon glyphicon-paperclip"></span> LAMPIRAN</asp:HyperLink>
        
                 <div class="row" style="background:linear-gradient(#f5f5f5, #c0c0c0);margin:5px;font-size:8pt;font-family:Verdana;border-bottom:1px solid #d60000;">
                     <div class="col-md-3">Dibuat, <asp:label runat="server" ID="lblMohonHa" text="" style="color:blue;"></asp:label> </div>
                     <div class="col-md-3">Disetujui, <asp:label runat="server"  text="<i class='glyphicon glyphicon-refresh'></i> Dalam proses anda saat ini.." style="color:blue;"></asp:label> </div>
                     <div class="col-md-3">Mengetahui, <asp:label runat="server" text="<i class='glyphicon glyphicon-info-sign'></i> Menunggu.." style="color:blue;"></asp:label> </div>
                     <div class="col-md-3">Disetujui, <asp:label runat="server" text="<i class='glyphicon glyphicon-info-sign'></i> Menunggu.." style="color:blue;"></asp:label> </div>
                 </div>
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                         DataSourceID="SqlDataSource1" 
                         class="table table-bordered" style="margin:5px;font-size:9pt;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vendor" SortExpression="vendor">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("vendor") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama Barang" SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Beli" SortExpression="tujuanitem">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Minta" SortExpression="tujuanitem">
                   <ItemTemplate>
                        <asp:Label ID="Label81" runat="server" Text='<%# Bind("kelompokisi") %>' style="font-size:9pt;"></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Pusat Biaya" SortExpression="pusatbiaya">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("pusatbiaya") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qty" SortExpression="jumlahitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("jumlahitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("hargaitem","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total" SortExpression="Total" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("totl","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:HyperLink ID="linkRejectItem" runat="server" NavigateUrl='<%# "viewmintabeli.aspx?app1=" + Eval("nobody") + "&&id=" + Eval("idbody") + "&&aks=headapproval#reject"  %>' 
                             Target="_self" Text="<span class='glyphicon glyphicon-ban-circle'></span>&nbsp;Reject" class="btn btn-danger btn-xs" style="font-weight:bold;"></asp:HyperLink>
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
         
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT [idbody], case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [nobody], [namaitem], [vendor], [tujuanitem], [jumlahitem], [hargaitem], [reject], [alasanreject], [rejectoleh], [pusatbiaya], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody) AND reject = 'APPROVE'">
                              <SelectParameters>
                             <asp:QueryStringParameter Name="nobody" QueryStringField="app1" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                      <table style="width:70%;float:left;margin-left:5px;font-size:8pt;color:blue;font-family:Verdana;">
                      <tr><td>Note : Untuk pembelian diatas Rp. 2.000.000,- harus mendapat persetujuan dari Vice President Director</td></tr>
                        </table>
                     <table style="width:26%;float:right;border:1px solid #c0c0c0;" border="1">
                     <tr><td style="width:50%;padding:5px;text-align:right;font-weight:bold;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">TOTAL :</td>
                     <td style="width:50%;padding:5px;text-align:center;font-weight:bold;font-size:12pt;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">
                     <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                     </td></tr></table>
    <table style="float:left;width:100%;font-family:Verdana;font-size:8pt;text-align:center;font-weight:bold;color:#c60000;"><tr><td>Daftar Barang yg ditolak</td></tr></table>
      <center> <div id="spoiler">
<div><input style="font-size: 11px; padding: 2px;" onclick="if (this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display != '') { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = ''; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = 'none'; this.innerText = ''; this.value = 'Sembunyikan'; } else { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = 'none'; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = ''; this.innerText = ''; this.value = 'Tampilkan'; }" name="button" type="button" value="Tampilkan" /></div>
<div id="show" style="border: 1px solid white; display: none; margin: 5px; padding: 2px; width: 98%;">
    <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="False" 
                         DataSourceID="SqlDataSource9" 
                         class="table table-bordered table-striped" style="margin:5px;font-size:8pt;" EnableModelValidation="True" CellPadding="2" ForeColor="#333333" GridLines="None">
             <AlternatingRowStyle BackColor="White" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vendor" SortExpression="vendor">
                     <ItemTemplate>
                         <asp:Label ID="Label41" runat="server" Text='<%# Bind("vendor") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama Barang" SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label42" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Beli" SortExpression="tujuanitem">
                     <ItemTemplate>
                         <asp:Label ID="Label43" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Minta" SortExpression="tujuanitem">
                   <ItemTemplate>
                        <asp:Label ID="Label82" runat="server" Text='<%# Bind("kelompokisi") %>' style="font-size:9pt;"></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Pusat Biaya" SortExpression="pusatbiaya">
                     <ItemTemplate>
                         <asp:Label ID="Label44" runat="server" Text='<%# Bind("pusatbiaya") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Status" SortExpression="reject" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label45" runat="server" Text='<%# Bind("reject") %>' style="font-family:tahoma;font-weight:bold;color:#c60000;"></asp:Label><br />
                           </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                 </asp:TemplateField>
                     <asp:TemplateField HeaderText="Reject oleh" SortExpression="reject" HeaderStyle-Width="100">
                     <ItemTemplate>
                          <asp:Label ID="Label52" runat="server" Text='<%# Eval("rejectoleh") + "," %>' style="color:Blue;font-size:8pt;"></asp:Label>
                        </ItemTemplate>

<HeaderStyle Width="100px"></HeaderStyle>
                 </asp:TemplateField>
                     <asp:TemplateField HeaderText="Alasan" SortExpression="reject" HeaderStyle-Width="200">
                     <ItemTemplate>
                           <asp:Label ID="Label56" runat="server" Text='<%# Eval("alasanreject")  %>' style="color:Blue;font-size:8pt;"></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="200px"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qty" SortExpression="jumlahitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label48" runat="server" Text='<%# Bind("jumlahitem") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label49" runat="server" Text='<%# Bind("hargaitem","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="12px"></HeaderStyle>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total" SortExpression="Total" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label50" runat="server" Text='<%# Bind("totl","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="12px"></HeaderStyle>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
         </asp:GridView>
         </div><div id="hide"></div></div>
      
                     <asp:SqlDataSource ID="SqlDataSource9" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT [idbody], case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [nobody], [namaitem], [vendor], [tujuanitem], [jumlahitem], [hargaitem], [reject], [alasanreject], [rejectoleh], [pusatbiaya], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody) AND reject = 'REJECT'">
                              <SelectParameters>
                             <asp:QueryStringParameter Name="nobody" QueryStringField="app1" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                     </div>
<div id="purchasing" runat="server">
<div class="kirih" style="float:left;width:25%;height:100px;padding:20px;">
         <asp:Image ID="Image2" runat="server" ImageUrl="~/img/hlogo.png" style="width:80px;height:60px;float:left;"/>
    </div>
    <div class="kirih" style="float:left;width:50%;height:100px;font-weight:bold;text-align:center;
    padding-top:50px;font-size:14pt;text-transform:uppercase;">
        <asp:Label ID="Label12" runat="server" Text="Permintaan Pembelian"></asp:Label> <br />
         <asp:Label ID="lblNoBuktiPurchasing" runat="server" Text="" style="color:Blue;font-size:12pt;text-transform:normal;"></asp:Label>       
        </div>
        <div class="kirih" style="float:left;width:25%;height:100px;">
        <asp:Label ID="Label14" runat="server" Text="Honda Mugen" style="font-weight:bold;"></asp:Label><br />    
        <asp:Label ID="Label15" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:8pt;"></asp:Label><br />    
        <asp:Label ID="Label16" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label17" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label18" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label19" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:8pt;"></asp:Label>            
     </div>
         <asp:HyperLink ID="HyperLink6" runat="server" 
                 style="margin-left:5px;font-weight:bold;font-family:Tahoma;" 
                 class="btn btn-success btn-sm" NavigateUrl="#approvepurchasing"><span class="glyphicon glyphicon-ok"></span> APPROVE</asp:HyperLink>
          <asp:HyperLink ID="HyperLink7" runat="server" style="margin-bottom:5px;margin-top:5px;font-weight:bold;font-family:Tahoma;" 
                 class="btn btn-danger btn-sm" NavigateUrl="#rejectallpurchasing"><span class="glyphicon glyphicon-remove"></span> REJECT ALL</asp:HyperLink>
         <asp:HyperLink ID="HyperLink8" runat="server" style="margin-bottom:5px;margin-top:5px;font-weight:bold;font-family:Tahoma;" 
                 class="btn btn-warning btn-sm" NavigateUrl="#lampiranpurchasing"><span class="glyphicon glyphicon-paperclip"></span> LAMPIRAN</asp:HyperLink>
        
                  <div class="row" style="background:linear-gradient(#f5f5f5, #c0c0c0);margin:5px;font-size:8pt;font-family:Verdana;border-bottom:1px solid #d60000;">
                     <div class="col-md-3">Dibuat, <asp:label runat="server" ID="lblMohonPur" text="" style="color:blue;"></asp:label> </div>
                     <div class="col-md-3">Disetujui, <asp:label runat="server" ID="lblSetujuPur" text="" style="color:blue;"></asp:label> </div>
                     <div class="col-md-3">Mengetahui, <asp:label runat="server" text="<i class='glyphicon glyphicon-info-sign'></i> Menunggu.." style="color:blue;"></asp:label> </div>
                     <div class="col-md-3">Disetujui, <asp:label runat="server" text="<i class='glyphicon glyphicon-info-sign'></i> Menunggu.." style="color:blue;"></asp:label> </div>
                 </div>
         <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                         DataSourceID="SqlDataSource3" 
                         class="table table-bordered" style="margin:5px;font-size:9pt;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vendor" SortExpression="vendor">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("vendor") %>' style="font-size:9pt;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama Barang" SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("namaitem") %>' style="font-size:9pt;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Beli" SortExpression="tujuanitem">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("tujuanitem") %>' style="font-size:9pt;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Minta" SortExpression="tujuanitem">
                   <ItemTemplate>
                        <asp:Label ID="Label83" runat="server" Text='<%# Bind("kelompokisi") %>' style="font-size:9pt;"></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Pusat Biaya" SortExpression="pusatbiaya">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("pusatbiaya") %>' style="font-size:9pt;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qty" SortExpression="jumlahitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("jumlahitem") %>' style="font-size:9pt;font-family:Verdana;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("hargaitem","{0:0,0}") %>' style="font-size:9pt;font-family:Verdana;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total" SortExpression="Total" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("totl","{0:0,0}") %>' style="font-size:9pt;font-family:Verdana;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderStyle-Width="225">
                     <ItemTemplate>
                       <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl='<%# "viewmintabeli.aspx?app2=" + Eval("nobody") + "&&id=" + Eval("idbody") + "&&aks=purchasing#vendor"  %>' 
                             Target="_self" Text="<span class='glyphicon glyphicon-briefcase'></span>&nbsp;Vendor" class="btn btn-primary btn-xs" style="font-weight:bold;"></asp:HyperLink>
                          <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl='<%# "viewmintabeli.aspx?app2=" + Eval("nobody") + "&&id=" + Eval("idbody") + "&&aks=purchasing#barang"  %>' 
                             Target="_self" Text="<span class='glyphicon glyphicon-gift'></span>&nbsp;Barang" class="btn btn-info btn-xs" style="font-weight:bold;"></asp:HyperLink>
                         <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "viewmintabeli.aspx?app2=" + Eval("nobody") + "&&id=" + Eval("idbody") + "&&aks=purchasing#price"  %>' 
                             Target="_self" Text="<span class='glyphicon glyphicon-usd'></span>&nbsp;Pricing" class="btn btn-warning btn-xs" style="font-weight:bold;"></asp:HyperLink>
                             <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl='<%# "viewmintabeli.aspx?app2=" + Eval("nobody") + "&&id=" + Eval("idbody") + "&&aks=purchasing#rejectpurchasing"  %>' 
                             Target="_self" Text="<span class='glyphicon glyphicon-ban-circle'></span>&nbsp;Reject" class="btn btn-danger btn-xs" style="font-weight:bold;"></asp:HyperLink>

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
         
                     <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT [idbody], case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [nobody], [namaitem], [vendor], [tujuanitem], [jumlahitem], [hargaitem], [reject], [alasanreject], [rejectoleh], [pusatbiaya], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody2) AND reject = 'APPROVE'">
                              <SelectParameters>
                             <asp:QueryStringParameter Name="nobody2" QueryStringField="app2" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                      <table style="width:70%;float:left;margin-left:5px;font-size:8pt;color:blue;font-family:Verdana;">
                      <tr><td>Note : Untuk pembelian diatas Rp. 2.000.000,- harus mendapat persetujuan dari Vice President Director</td>
                      </tr>
                        </table>
                     <table style="width:26%;float:right;border:1px solid #c0c0c0;" border="1">
                     <tr><td style="width:50%;padding:5px;text-align:right;font-weight:bold;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">TOTAL :</td>
                     <td style="width:50%;padding:5px;text-align:center;font-weight:bold;font-size:12pt;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">
                     <asp:Label ID="lblTotalPurchasing" runat="server" Text=""></asp:Label>
                     </td></tr></table>
     <table style="float:left;width:100%;font-family:Verdana;font-size:8pt;text-align:center;font-weight:bold;color:#c60000;"><tr><td>Daftar Barang yg ditolak</td></tr></table>
      <center> <div id="spoiler">
<div><input style="font-size: 11px; padding: 2px;" onclick="if (this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display != '') { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = ''; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = 'none'; this.innerText = ''; this.value = 'Sembunyikan'; } else { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = 'none'; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = ''; this.innerText = ''; this.value = 'Tampilkan'; }" name="button" type="button" value="Tampilkan" /></div>
<div id="show" style="border: 1px solid white; display: none; margin: 5px; padding: 2px; width: 98%;">
    <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="False" 
                         DataSourceID="SqlDataSource10" 
                         class="table table-bordered table-striped" style="margin:5px;font-size:8pt;" EnableModelValidation="True" CellPadding="2" ForeColor="#333333" GridLines="None">
             <AlternatingRowStyle BackColor="White" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vendor" SortExpression="vendor">
                     <ItemTemplate>
                         <asp:Label ID="Label46" runat="server" Text='<%# Bind("vendor") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama Barang" SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label47" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Beli" SortExpression="tujuanitem">
                     <ItemTemplate>
                         <asp:Label ID="Label51" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Minta" SortExpression="tujuanitem">
                   <ItemTemplate>
                        <asp:Label ID="Label84" runat="server" Text='<%# Bind("kelompokisi") %>' style="font-size:9pt;"></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Pusat Biaya" SortExpression="pusatbiaya">
                     <ItemTemplate>
                         <asp:Label ID="Label53" runat="server" Text='<%# Bind("pusatbiaya") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Status" SortExpression="reject" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label54" runat="server" Text='<%# Bind("reject") %>' style="font-family:tahoma;font-weight:bold;color:#c60000;"></asp:Label><br />
                           </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                 </asp:TemplateField>
                     <asp:TemplateField HeaderText="Reject oleh" SortExpression="reject" HeaderStyle-Width="100">
                     <ItemTemplate>
                          <asp:Label ID="Label55" runat="server" Text='<%# Eval("rejectoleh") + "," %>' style="color:Blue;font-size:8pt;"></asp:Label>
                        </ItemTemplate>

<HeaderStyle Width="100px"></HeaderStyle>
                 </asp:TemplateField>
                     <asp:TemplateField HeaderText="Alasan" SortExpression="reject" HeaderStyle-Width="200">
                     <ItemTemplate>
                           <asp:Label ID="Label57" runat="server" Text='<%# Eval("alasanreject")  %>' style="color:Blue;font-size:8pt;"></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="200px"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qty" SortExpression="jumlahitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label58" runat="server" Text='<%# Bind("jumlahitem") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label59" runat="server" Text='<%# Bind("hargaitem","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="12px"></HeaderStyle>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total" SortExpression="Total" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label60" runat="server" Text='<%# Bind("totl","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="12px"></HeaderStyle>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
         </asp:GridView>
         </div><div id="hide"></div></div>
      
                     <asp:SqlDataSource ID="SqlDataSource10" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT [idbody], case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [nobody], [namaitem], [vendor], [tujuanitem], [jumlahitem], [hargaitem], [reject], [alasanreject], [rejectoleh], [pusatbiaya], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody) AND reject = 'REJECT'">
                              <SelectParameters>
                             <asp:QueryStringParameter Name="nobody" QueryStringField="app2" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                     </div>
<div id="headPur" runat="server">
<div class="kirih" style="float:left;width:25%;height:100px;padding:20px;">
         <asp:Image ID="Image3" runat="server" ImageUrl="~/img/hlogo.png" style="width:80px;height:60px;float:left;"/>
    </div>
    <div class="kirih" style="float:left;width:50%;height:100px;font-weight:bold;text-align:center;
    padding-top:50px;font-size:14pt;text-transform:uppercase;">
        <asp:Label ID="Label22" runat="server" Text="Permintaan Pembelian"></asp:Label> <br />
         <asp:Label ID="lblNoHeadPur" runat="server" Text="" style="color:Blue;font-size:12pt;text-transform:normal;"></asp:Label>       
        </div>
        <div class="kirih" style="float:left;width:25%;height:100px;">
        <asp:Label ID="Label24" runat="server" Text="Honda Mugen" style="font-weight:bold;"></asp:Label><br />    
        <asp:Label ID="Label25" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:8pt;"></asp:Label><br />    
        <asp:Label ID="Label26" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label27" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label28" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label29" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:8pt;"></asp:Label>            
     </div>
         <asp:HyperLink ID="HyperLink12" runat="server" 
                 style="margin-left:5px;font-weight:bold;font-family:Tahoma;" 
                 class="btn btn-success btn-sm" NavigateUrl="#approveheadpur"><span class="glyphicon glyphicon-ok"></span> APPROVE</asp:HyperLink>
          <asp:HyperLink ID="HyperLink13" runat="server" style="margin-bottom:5px;margin-top:5px;font-weight:bold;font-family:Tahoma;" 
                 class="btn btn-danger btn-sm" NavigateUrl="#rejectallheadpur"><span class="glyphicon glyphicon-remove"></span> REJECT ALL</asp:HyperLink>
         <asp:HyperLink ID="HyperLink14" runat="server" style="margin-bottom:5px;margin-top:5px;font-weight:bold;font-family:Tahoma;" 
                 class="btn btn-warning btn-sm" NavigateUrl="#lampiranheadpur"><span class="glyphicon glyphicon-paperclip"></span> LAMPIRAN</asp:HyperLink>
        
                 <div class="row" style="background:linear-gradient(#f5f5f5, #c0c0c0);margin:5px;font-size:8pt;font-family:Verdana;border-bottom:1px solid #d60000;">
                     <div class="col-md-3">Dibuat, <asp:label runat="server" ID="lblPemohonHp" text="" style="color:blue;"></asp:label> </div>
                     <div class="col-md-3">Disetujui, <asp:label runat="server" ID="lblSetujuHp" text="" style="color:blue;"></asp:label> </div>
                     <div class="col-md-3">Mengetahui, <asp:label runat="server" ID="lblHeadHp" text="<i class='glyphicon glyphicon-refresh'></i> Dalam proses anda saat ini.." style="color:blue;"></asp:label> </div>
                     <div class="col-md-3">Disetujui, <asp:label runat="server" text="<i class='glyphicon glyphicon-info-sign'></i> Menunggu.." style="color:blue;"></asp:label> </div>
                 </div>
         <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                         DataSourceID="SqlDataSource5" 
                         class="table table-bordered" style="margin:5px;font-size:9pt;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vendor" SortExpression="vendor">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("vendor") %>' style="font-size:9pt;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama Barang" SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("namaitem") %>' style="font-size:9pt;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Beli" SortExpression="tujuanitem">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("tujuanitem") %>' style="font-size:9pt;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Minta" SortExpression="tujuanitem">
                   <ItemTemplate>
                        <asp:Label ID="Label85" runat="server" Text='<%# Bind("kelompokisi") %>' style="font-size:9pt;"></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Pusat Biaya" SortExpression="pusatbiaya">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("pusatbiaya") %>' style="font-size:9pt;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qty" SortExpression="jumlahitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("jumlahitem") %>' style="font-size:9pt;font-family:Verdana;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("hargaitem","{0:0,0}") %>' style="font-size:9pt;font-family:Verdana;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total" SortExpression="Total" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("totl","{0:0,0}") %>' style="font-size:9pt;font-family:Verdana;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderStyle-Width="80">
                     <ItemTemplate>
                          <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl='<%# "viewmintabeli.aspx?app3=" + Eval("nobody") + "&&id=" + Eval("idbody") + "&&aks=headpur#barangheadpur"  %>' 
                             Target="_self" Text="<span class='glyphicon glyphicon-gift'></span>&nbsp;Barang" class="btn btn-info btn-xs" style="font-weight:bold;"></asp:HyperLink>
                             <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl='<%# "viewmintabeli.aspx?app3=" + Eval("nobody") + "&&id=" + Eval("idbody") + "&&aks=headpur#rejectheadpur"  %>' 
                             Target="_self" Text="<span class='glyphicon glyphicon-ban-circle'></span>&nbsp;Reject" class="btn btn-danger btn-xs" style="font-weight:bold;"></asp:HyperLink>
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
                         
                         SelectCommand="SELECT [idbody], case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [nobody], [namaitem], [vendor], [tujuanitem], [jumlahitem], [hargaitem], [reject], [alasanreject], [rejectoleh], [pusatbiaya], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody3) AND reject = 'APPROVE'">
                              <SelectParameters>
                             <asp:QueryStringParameter Name="nobody3" QueryStringField="app3" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                      <table style="width:70%;float:left;margin-left:5px;font-size:8pt;color:blue;font-family:Verdana;">
                      <tr><td>Note : Untuk pembelian diatas Rp. 2.000.000,- harus mendapat persetujuan dari Vice President Director</td>
                      </tr>
                        </table>
                     <table style="width:26%;float:right;border:1px solid #c0c0c0;" border="1">
                     <tr><td style="width:50%;padding:5px;text-align:right;font-weight:bold;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">TOTAL :</td>
                     <td style="width:50%;padding:5px;text-align:center;font-weight:bold;font-size:12pt;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">
                     <asp:Label ID="lblTotalHeadPur" runat="server" Text=""></asp:Label>
                     </td></tr></table>
    <table style="float:left;width:100%;font-family:Verdana;font-size:8pt;text-align:center;font-weight:bold;color:#c60000;"><tr><td>Daftar Barang yg ditolak</td></tr></table>
      <center> <div id="spoiler">
<div><input style="font-size: 11px; padding: 2px;" onclick="if (this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display != '') { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = ''; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = 'none'; this.innerText = ''; this.value = 'Sembunyikan'; } else { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = 'none'; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = ''; this.innerText = ''; this.value = 'Tampilkan'; }" name="button" type="button" value="Tampilkan" /></div>
<div id="show" style="border: 1px solid white; display: none; margin: 5px; padding: 2px; width: 98%;">
    <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="False" 
                         DataSourceID="SqlDataSource11" 
                         class="table table-bordered table-striped" style="margin:5px;font-size:8pt;" EnableModelValidation="True" CellPadding="2" ForeColor="#333333" GridLines="None">
             <AlternatingRowStyle BackColor="White" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vendor" SortExpression="vendor">
                     <ItemTemplate>
                         <asp:Label ID="Label61" runat="server" Text='<%# Bind("vendor") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama Barang" SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label62" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Beli" SortExpression="tujuanitem">
                     <ItemTemplate>
                         <asp:Label ID="Label63" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Minta" SortExpression="tujuanitem">
                   <ItemTemplate>
                        <asp:Label ID="Label86" runat="server" Text='<%# Bind("kelompokisi") %>' style="font-size:9pt;"></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Pusat Biaya" SortExpression="pusatbiaya">
                     <ItemTemplate>
                         <asp:Label ID="Label64" runat="server" Text='<%# Bind("pusatbiaya") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Status" SortExpression="reject" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label65" runat="server" Text='<%# Bind("reject") %>' style="font-family:tahoma;font-weight:bold;color:#c60000;"></asp:Label><br />
                           </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                 </asp:TemplateField>
                     <asp:TemplateField HeaderText="Reject oleh" SortExpression="reject" HeaderStyle-Width="100">
                     <ItemTemplate>
                          <asp:Label ID="Label66" runat="server" Text='<%# Eval("rejectoleh") + "," %>' style="color:Blue;font-size:8pt;"></asp:Label>
                        </ItemTemplate>

<HeaderStyle Width="100px"></HeaderStyle>
                 </asp:TemplateField>
                     <asp:TemplateField HeaderText="Alasan" SortExpression="reject" HeaderStyle-Width="200">
                     <ItemTemplate>
                           <asp:Label ID="Label67" runat="server" Text='<%# Eval("alasanreject")  %>' style="color:Blue;font-size:8pt;"></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="200px"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qty" SortExpression="jumlahitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label68" runat="server" Text='<%# Bind("jumlahitem") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label69" runat="server" Text='<%# Bind("hargaitem","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="12px"></HeaderStyle>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total" SortExpression="Total" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label70" runat="server" Text='<%# Bind("totl","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="12px"></HeaderStyle>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
         </asp:GridView>
         </div><div id="hide"></div></div>
      
                     <asp:SqlDataSource ID="SqlDataSource11" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT [idbody], case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [nobody], [namaitem], [vendor], [tujuanitem], [jumlahitem], [hargaitem], [reject], [alasanreject], [rejectoleh], [pusatbiaya], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody) AND reject = 'REJECT'">
                              <SelectParameters>
                             <asp:QueryStringParameter Name="nobody" QueryStringField="app3" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                     </div>
<div id="vpapp" runat="server">
<div class="kirih" style="float:left;width:25%;height:100px;padding:20px;">
         <asp:Image ID="Image4" runat="server" ImageUrl="~/img/hlogo.png" style="width:80px;height:60px;float:left;"/>
    </div>
    <div class="kirih" style="float:left;width:50%;height:100px;font-weight:bold;text-align:center;
    padding-top:50px;font-size:14pt;text-transform:uppercase;">
        <asp:Label ID="Label31" runat="server" Text="Permintaan Pembelian"></asp:Label> <br />
         <asp:Label ID="lblNoVpapp" runat="server" Text="" style="color:Blue;font-size:12pt;text-transform:normal;"></asp:Label>       
        </div>
        <div class="kirih" style="float:left;width:25%;height:100px;">
        <asp:Label ID="Label33" runat="server" Text="Honda Mugen" style="font-weight:bold;"></asp:Label><br />    
        <asp:Label ID="Label34" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:8pt;"></asp:Label><br />    
        <asp:Label ID="Label35" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label36" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label37" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label38" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:8pt;"></asp:Label>            
     </div>
         <asp:HyperLink ID="HyperLink16" runat="server" 
                 style="margin-left:5px;font-weight:bold;font-family:Tahoma;" 
                 class="btn btn-success btn-sm" NavigateUrl="#approvevpapp"><span class="glyphicon glyphicon-ok"></span> APPROVE</asp:HyperLink>
          <asp:HyperLink ID="HyperLink17" runat="server" style="margin-bottom:5px;margin-top:5px;font-weight:bold;font-family:Tahoma;" 
                 class="btn btn-danger btn-sm" NavigateUrl="#rejectallvpapp"><span class="glyphicon glyphicon-remove"></span> REJECT ALL</asp:HyperLink>
         <asp:HyperLink ID="HyperLink18" runat="server" style="margin-bottom:5px;margin-top:5px;font-weight:bold;font-family:Tahoma;" 
                 class="btn btn-warning btn-sm" NavigateUrl="#lampiranvpapp"><span class="glyphicon glyphicon-paperclip"></span> LAMPIRAN</asp:HyperLink>
        
                 <div class="row" style="background:linear-gradient(#f5f5f5, #c0c0c0);margin:5px;font-size:8pt;font-family:Verdana;border-bottom:1px solid #d60000;">
                     <div class="col-md-3">Dibuat, <asp:label runat="server" ID="lblVpappBuat" text="" style="color:blue;"></asp:label> </div>
                     <div class="col-md-3">Disetujui, <asp:label runat="server" ID="lblVpappSetuju" text="" style="color:blue;"></asp:label> </div>
                     <div class="col-md-3">Mengetahui, <asp:label runat="server" ID="lblVpappHeadPur" text="" style="color:blue;"></asp:label> </div>
                     <div class="col-md-3">Disetujui, <asp:label runat="server" text="<i class='glyphicon glyphicon-refresh'></i> Dalam proses anda saat ini.." style="color:blue;"></asp:label> </div>
                 </div>
         <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" 
                         DataSourceID="SqlDataSource7" 
                         class="table table-bordered" style="margin:5px;font-size:9pt;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vendor" SortExpression="vendor">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("vendor") %>' style="font-size:9pt;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama Barang" SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("namaitem") %>' style="font-size:9pt;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Beli" SortExpression="tujuanitem">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("tujuanitem") %>' style="font-size:9pt;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Minta" SortExpression="tujuanitem">
                   <ItemTemplate>
                        <asp:Label ID="Label87" runat="server" Text='<%# Bind("kelompokisi") %>' style="font-size:9pt;"></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Pusat Biaya" SortExpression="pusatbiaya">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("pusatbiaya") %>' style="font-size:9pt;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Status" SortExpression="reject" HeaderStyle-Width="180">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("reject") %>' style="font-family:tahoma;font-weight:bold;color:#c60000;font-size:8pt;"></asp:Label><br />
                         <asp:Label ID="Label8" runat="server" Text='<%# "(" + Eval("rejectoleh") + "," %>' style="color:Blue;font-size:8pt;"></asp:Label>
                         <asp:Label ID="Label9" runat="server" Text='<%# Eval("alasanreject") + ")" %>' style="color:Blue;font-size:8pt;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qty" SortExpression="jumlahitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("jumlahitem") %>' style="font-size:9pt;font-family:Verdana;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("hargaitem","{0:0,0}") %>' style="font-size:9pt;font-family:Verdana;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total" SortExpression="Total" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("totl","{0:0,0}") %>' style="font-size:9pt;font-family:Verdana;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderStyle-Width="80">
                     <ItemTemplate>
                             <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl='<%# "viewmintabeli.aspx?app4=" + Eval("nobody") + "&&id=" + Eval("idbody") + "&&aks=vpapp#rejectvpapp"  %>' 
                             Target="_self" Text="<span class='glyphicon glyphicon-ban-circle'></span>&nbsp;Reject" class="btn btn-danger btn-xs" style="font-weight:bold;"></asp:HyperLink>
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
         
                     <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT [idbody], case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [nobody], [namaitem], [vendor], [tujuanitem], [jumlahitem], [hargaitem], [reject], [alasanreject], [rejectoleh], [pusatbiaya], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody4) AND reject = 'APPROVE'">
                              <SelectParameters>
                             <asp:QueryStringParameter Name="nobody4" QueryStringField="app4" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                      <table style="width:70%;float:left;margin-left:5px;font-size:8pt;color:blue;font-family:Verdana;">
                      <tr><td>Note : Untuk pembelian diatas Rp. 2.000.000,- harus mendapat persetujuan dari Vice President Director</td>
                      </tr>
                        </table>
                     <table style="width:26%;float:right;border:1px solid #c0c0c0;" border="1">
                     <tr><td style="width:50%;padding:5px;text-align:right;font-weight:bold;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">TOTAL :</td>
                     <td style="width:50%;padding:5px;text-align:center;font-weight:bold;font-size:12pt;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">
                     <asp:Label ID="lblTotalVpapp" runat="server" Text=""></asp:Label>
                     </td></tr></table>
    <table style="float:left;width:100%;font-family:Verdana;font-size:8pt;text-align:center;font-weight:bold;color:#c60000;"><tr><td>Daftar Barang yg ditolak</td></tr></table>
      <center> <div id="spoiler">
<div><input style="font-size: 11px; padding: 2px;" onclick="if (this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display != '') { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = ''; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = 'none'; this.innerText = ''; this.value = 'Sembunyikan'; } else { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = 'none'; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = ''; this.innerText = ''; this.value = 'Tampilkan'; }" name="button" type="button" value="Tampilkan" /></div>
<div id="show" style="border: 1px solid white; display: none; margin: 5px; padding: 2px; width: 98%;">
    <asp:GridView ID="GridView12" runat="server" AutoGenerateColumns="False" 
                         DataSourceID="SqlDataSource12" 
                         class="table table-bordered table-striped" style="margin:5px;font-size:8pt;" EnableModelValidation="True" CellPadding="2" ForeColor="#333333" GridLines="None">
             <AlternatingRowStyle BackColor="White" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vendor" SortExpression="vendor">
                     <ItemTemplate>
                         <asp:Label ID="Label71" runat="server" Text='<%# Bind("vendor") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama Barang" SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label72" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Beli" SortExpression="tujuanitem">
                     <ItemTemplate>
                         <asp:Label ID="Label73" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan Minta" SortExpression="tujuanitem">
                   <ItemTemplate>
                        <asp:Label ID="Label88" runat="server" Text='<%# Bind("kelompokisi") %>' style="font-size:9pt;"></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Pusat Biaya" SortExpression="pusatbiaya">
                     <ItemTemplate>
                         <asp:Label ID="Label74" runat="server" Text='<%# Bind("pusatbiaya") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Status" SortExpression="reject" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label75" runat="server" Text='<%# Bind("reject") %>' style="font-family:tahoma;font-weight:bold;color:#c60000;"></asp:Label><br />
                           </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                 </asp:TemplateField>
                     <asp:TemplateField HeaderText="Reject oleh" SortExpression="reject" HeaderStyle-Width="100">
                     <ItemTemplate>
                          <asp:Label ID="Label76" runat="server" Text='<%# Eval("rejectoleh") + "," %>' style="color:Blue;font-size:8pt;"></asp:Label>
                        </ItemTemplate>

<HeaderStyle Width="100px"></HeaderStyle>
                 </asp:TemplateField>
                     <asp:TemplateField HeaderText="Alasan" SortExpression="reject" HeaderStyle-Width="200">
                     <ItemTemplate>
                           <asp:Label ID="Label77" runat="server" Text='<%# Eval("alasanreject")  %>' style="color:Blue;font-size:8pt;"></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="200px"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qty" SortExpression="jumlahitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label78" runat="server" Text='<%# Bind("jumlahitem") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label79" runat="server" Text='<%# Bind("hargaitem","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="12px"></HeaderStyle>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total" SortExpression="Total" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label80" runat="server" Text='<%# Bind("totl","{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="12px"></HeaderStyle>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
         </asp:GridView>
         </div><div id="hide"></div></div>
      
                     <asp:SqlDataSource ID="SqlDataSource12" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT [idbody], case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [nobody], [namaitem], [vendor], [tujuanitem], [jumlahitem], [hargaitem], [reject], [alasanreject], [rejectoleh], [pusatbiaya], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody) AND reject = 'REJECT'">
                              <SelectParameters>
                             <asp:QueryStringParameter Name="nobody" QueryStringField="app4" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                     </div>
                 </div>
                 
  <div id="lampiran">
 <div class="windowlampiran">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-paperclip"></span> Lampiran<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
 
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" 
                         class="table table-bordered" style="margin:5px;font-size:9pt;width:80%;position:relative;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Keterangan" SortExpression="keterangan">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("keterangan") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("keterangan") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                   <asp:TemplateField HeaderText="Penawaran" SortExpression="vendor">
                     <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("lokasifile") %>' 
                             Target="_blank" Text="Download" class="btn btn-info btn-xs" style="font-weight:bold;"></asp:HyperLink>
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
         
                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT * FROM [fmblamp] WHERE ([nohead] = @app1)">
                         <SelectParameters>
                             <asp:QueryStringParameter Name="app1" QueryStringField="app1" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
      
      <asp:GridView ID="GridView13" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource13" 
                         class="table table-bordered" style="margin:5px;font-size:9pt;width:80%;position:relative;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Keterangan" SortExpression="keterangan">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("keterangan") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("keterangan") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                   <asp:TemplateField HeaderText="Penawaran" SortExpression="vendor">
                     <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("lokasifile") %>' 
                             Target="_blank" Text="Download" class="btn btn-info btn-xs" style="font-weight:bold;"></asp:HyperLink>
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
         
                     <asp:SqlDataSource ID="SqlDataSource13" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT * FROM [fmblamp] inner join [fmbbody] on fmblamp.nohead = fmbbody.vendor WHERE ([nobody] = @app1)">
                         <SelectParameters>
                             <asp:QueryStringParameter Name="app1" QueryStringField="app1" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
  </div>
  </div>
 </div>
 </div>
  <div id="lampiranpurchasing">
 <div class="windowlampiranpurchasing">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-paperclip"></span> Lampiran<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
           <table>
   <tr>
    <td>
        <asp:Label ID="Label39" runat="server" Text="File"></asp:Label></td>
    <td>:</td>
    <td>
        <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" style="margin:5px;"/></td>
  </tr>
    <tr>
    <td>
        <asp:Label ID="Label40" runat="server" Text="Keterangan"></asp:Label></td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtKet" runat="server" class="form-control" style="margin:5px;" onkeyup="upper(this)" placeholder="keterangan lampiran..."></asp:TextBox></td>
  </tr>
  <tr>
    <td></td>
    <td></td>
    <td><asp:Button ID="Button6" class="btn btn-success btn-sm" 
            style="font-weight:bold;" runat="server" Text="UPLOAD" OnClick="Button6_Click" 
             /></td>
  </tr>
 <tr>
    <td></td>
    <td></td>
    <td>
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label></td>
  </tr>
  </table>
<asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" 
                         class="table table-bordered" style="margin:5px;font-size:9pt;width:80%;position:relative;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Keterangan" SortExpression="keterangan">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("keterangan") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("keterangan") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                   <asp:TemplateField HeaderText="Penawaran" SortExpression="vendor">
                     <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("lokasifile") %>' 
                             Target="_blank" Text="Download" class="btn btn-info btn-xs" style="font-weight:bold;"></asp:HyperLink>
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
         
                     <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT * FROM [fmblamp] WHERE ([nohead] = @app2)">
                         <SelectParameters>
                             <asp:QueryStringParameter Name="app2" QueryStringField="app2" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
      <asp:GridView ID="GridView14" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource14" 
                         class="table table-bordered" style="margin:5px;font-size:9pt;width:80%;position:relative;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Keterangan" SortExpression="keterangan">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("keterangan") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("keterangan") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                   <asp:TemplateField HeaderText="Penawaran" SortExpression="vendor">
                     <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("lokasifile") %>' 
                             Target="_blank" Text="Download" class="btn btn-info btn-xs" style="font-weight:bold;"></asp:HyperLink>
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
         
                     <asp:SqlDataSource ID="SqlDataSource14" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT * FROM [fmblamp] inner join [fmbbody] on fmblamp.nohead = fmbbody.vendor WHERE ([nobody] = @app2)">
                         <SelectParameters>
                             <asp:QueryStringParameter Name="app2" QueryStringField="app2" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
  </div>
  </div>
 </div>
 </div>
  <div id="lampiranheadpur">
 <div class="windowlampiranheadpur">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-paperclip"></span> Lampiran<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
<asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource6" 
                         class="table table-bordered" style="margin:5px;font-size:9pt;width:80%;position:relative;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Keterangan" SortExpression="keterangan">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("keterangan") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("keterangan") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                   <asp:TemplateField HeaderText="Penawaran" SortExpression="vendor">
                     <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("lokasifile") %>' 
                             Target="_blank" Text="Download" class="btn btn-info btn-xs" style="font-weight:bold;"></asp:HyperLink>
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
         
                     <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT * FROM [fmblamp] WHERE ([nohead] = @app3)">
                         <SelectParameters>
                             <asp:QueryStringParameter Name="app3" QueryStringField="app3" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
      <asp:GridView ID="GridView15" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource15" 
                         class="table table-bordered" style="margin:5px;font-size:9pt;width:80%;position:relative;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Keterangan" SortExpression="keterangan">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("keterangan") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("keterangan") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                   <asp:TemplateField HeaderText="Penawaran" SortExpression="vendor">
                     <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("lokasifile") %>' 
                             Target="_blank" Text="Download" class="btn btn-info btn-xs" style="font-weight:bold;"></asp:HyperLink>
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
         
                     <asp:SqlDataSource ID="SqlDataSource15" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT * FROM [fmblamp] inner join [fmbbody] on fmblamp.nohead = fmbbody.vendor WHERE ([nobody] = @app3)">
                         <SelectParameters>
                             <asp:QueryStringParameter Name="app3" QueryStringField="app3" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
  </div>
  </div>
 </div>
 </div>
  <div id="lampiranvpapp">
 <div class="windowlampiranvpapp">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-paperclip"></span> Lampiran<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
<asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource8" 
                         class="table table-bordered" style="margin:5px;font-size:9pt;width:80%;position:relative;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Keterangan" SortExpression="keterangan">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("keterangan") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("keterangan") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                   <asp:TemplateField HeaderText="Penawaran" SortExpression="vendor">
                     <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("lokasifile") %>' 
                             Target="_blank" Text="Download" class="btn btn-info btn-xs" style="font-weight:bold;"></asp:HyperLink>
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
         
                     <asp:SqlDataSource ID="SqlDataSource8" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT * FROM [fmblamp] WHERE ([nohead] = @app4)">
                         <SelectParameters>
                             <asp:QueryStringParameter Name="app4" QueryStringField="app4" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
      <asp:GridView ID="GridView16" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource16" 
                         class="table table-bordered" style="margin:5px;font-size:9pt;width:80%;position:relative;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Keterangan" SortExpression="keterangan">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("keterangan") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("keterangan") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                   <asp:TemplateField HeaderText="Penawaran" SortExpression="vendor">
                     <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("lokasifile") %>' 
                             Target="_blank" Text="Download" class="btn btn-info btn-xs" style="font-weight:bold;"></asp:HyperLink>
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
         
                     <asp:SqlDataSource ID="SqlDataSource16" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT * FROM [fmblamp] inner join [fmbbody] on fmblamp.nohead = fmbbody.vendor WHERE ([nobody] = @app4)">
                         <SelectParameters>
                             <asp:QueryStringParameter Name="app4" QueryStringField="app4" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
  </div>
  </div>
 </div>
 </div>
 
 <div id="approve">
 <div class="windowapprove">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-ok"></span> Approval<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table style="text-align:center;width:100%;">
    <tr>
        <td><asp:TextBox ID="txtAppApprove" runat="server" Visible="false"></asp:TextBox></td>
    </tr>
     <tr>
         <td><asp:Label ID="Label11" runat="server" Text="Yakin untuk melakukan approval ?"></asp:Label></td>
     </tr>
        <tr>
            <td><strong style="color:red;font-size:10px;">[NEW]</strong> <i style="color:blue;font-size:12px;">apakah anda membutuhkan approval dr pihak lain ? Jika ya pilih Nama yg dituju, bila tidak kosongkan.</i>
                <asp:dropdownlist runat="server" id="drpNamaApprove" DataSourceID="SqlDataSource20" class="form-control input-sm" style="width:60%;margin:0 auto;" DataTextField="username" DataValueField="username"><asp:ListItem>
            </asp:ListItem></asp:dropdownlist>
                <asp:SqlDataSource ID="SqlDataSource20" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [username] FROM [tb_user] ORDER BY [username]"></asp:SqlDataSource>
            </td>
        </tr>
     <tr>
         <td><asp:Button ID="Button2" runat="server" Text="APPROVE" 
                 class="btn btn-success btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="Button2_Click" />
                 <asp:HyperLink ID="HyperLink5" runat="server" class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" NavigateUrl="#">CANCEL</asp:HyperLink></td>
                  <tr>
         <td></td>
         <td></td>
         <td>
             <asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>
     </tr>
    </table>
  </div>
  </div>
 </div>
 </div>
 <div id="approvedivisi">
 <div class="windowapprovedivisi">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-ok"></span> Approval<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table style="text-align:center;width:100%;">
    <tr>
        <td><asp:TextBox ID="txtIdAppDiv" runat="server" Visible="false"></asp:TextBox></td>
    </tr>
     <tr>
         <td><asp:Label ID="Label90" runat="server" Text="Yakin untuk melakukan approval ?"></asp:Label></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnApproveDiv" runat="server" Text="APPROVE" 
                 class="btn btn-success btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnApproveDiv_Click" />
                 <asp:HyperLink ID="HyperLink24" runat="server" class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" NavigateUrl="#">CANCEL</asp:HyperLink></td>
                  <tr>
         <td></td>
         <td></td>
         <td>
             <asp:Label ID="Label97" runat="server" Text=""></asp:Label></td>
     </tr>
    </table>
  </div>
  </div>
 </div>
 </div>
 <div id="approvepurchasing">
 <div class="windowapprovepurchasing">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-ok"></span> Approval<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table style="text-align:center;width:100%;">
    <tr>
        <td><asp:TextBox ID="txtIdAppPurchasing" runat="server" Visible="False"></asp:TextBox></td>
    </tr>
     <tr>
         <td><asp:Label ID="Label13" runat="server" Text="Yakin untuk melakukan approval ?"></asp:Label></td>
     </tr>
     <tr>
         <td><asp:Button ID="Button3" runat="server" Text="APPROVE" 
                 class="btn btn-success btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="Button3_Click"  />
                 <asp:HyperLink ID="HyperLink10" runat="server" class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" NavigateUrl="#">CANCEL</asp:HyperLink></td>
                  
    </table>
  </div>
  </div>
 </div>
 </div>
 <div id="approveheadpur">
 <div class="windowapproveheadpur">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-qrcode"></span> Approval<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table style="text-align:center;width:100%;">
     <tr>
         <td><asp:Label ID="Label23" runat="server" Text="Yakin untuk melakukan approval ?"></asp:Label></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnApprovalHeadPur" runat="server" Text="APPROVE" 
                 class="btn btn-success btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnApprovalHeadPur_Click" />
                 <asp:HyperLink ID="HyperLink15" runat="server" class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" NavigateUrl="#">CANCEL</asp:HyperLink></td>
                  <tr>
         <td></td>
         <td></td>
         <td>
             <asp:Label ID="Label30" runat="server" Text=""></asp:Label></td>
     </tr>
    </table>
  </div>
  </div>
 </div>
 </div>
 <div id="approvevpapp">
 <div class="windowapprovevpapp">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-knight"></span> Approval<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table style="text-align:center;width:100%;">
     <tr>
         <td><asp:Label ID="Label32" runat="server" Text="Yakin untuk melakukan approval ?"></asp:Label></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnApprovalVpapp" runat="server" Text="APPROVE" 
                 class="btn btn-success btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnApprovalVpapp_Click" />
                 <asp:HyperLink ID="HyperLink19" runat="server" class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" NavigateUrl="#">CANCEL</asp:HyperLink></td>
     </tr>
    </table>
  </div>
  </div>
 </div>
 </div>
 
  <div id="reject">
 <div class="windowreject">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-ban-circle"></span> Reject Item<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
    <tr>
        <td><asp:TextBox ID="txtIdreject" runat="server" Visible="False"></asp:TextBox></td>
    </tr>
        <tr>
         <td>
           <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-dashboard"></span></div>
      <asp:TextBox ID="txtJumlahRejectHead" class="form-control" runat="server" onkeyup="Angka(this)" placeholder="Jumlah..." style="width:100px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td>
           <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></div>
      <asp:TextBox ID="txtAlasanReject" class="form-control" runat="server" onkeyup="upper(this)" placeholder="Alasan Reject..." style="width:280px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td><asp:Button ID="Button1" runat="server" Text="REJECT" 
                 class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="Button1_Click" /></td>
                  <tr>
         <td></td>
         <td></td>
         <td>
             <asp:Label ID="lblErrorReject" runat="server" Text=""></asp:Label></td>
     </tr>
    </table>
  </div>
  </div>
 </div>
 </div>
  <div id="rejectdivisi">
 <div class="windowrejectdivisi">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-ban-circle"></span> Reject Item<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
    <tr>
        <td><asp:TextBox ID="txtIdRejectDiv" runat="server" Visible="false"></asp:TextBox></td>
    </tr>
        <tr>
         <td>
           <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-dashboard"></span></div>
      <asp:TextBox ID="txtJumlahRejectDiv" class="form-control" runat="server" onkeyup="Angka(this)" placeholder="Jumlah..." style="width:100px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td>
           <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></div>
      <asp:TextBox ID="txtAlasanRejectDiv" class="form-control" runat="server" onkeyup="upper(this)" placeholder="Alasan Reject..." style="width:280px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnRejectDiv" runat="server" Text="REJECT" 
                 class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnRejectDiv_Click" /></td>
                  <tr>
         <td></td>
         <td></td>
         <td>
             <asp:Label ID="Label99" runat="server" Text=""></asp:Label></td>
     </tr>
    </table>
  </div>
  </div>
 </div>
 </div>
  <div id="rejectpurchasing">
 <div class="windowrejectpurchasing">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-ban-circle"></span> Reject Item<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
    <tr>
        <td><asp:TextBox ID="txtIdRejectPurchasing" runat="server" Visible="False"></asp:TextBox></td>
    </tr>
     <tr>
         <td>
           <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-dashboard"></span></div><asp:TextBox ID="txtJumlahRejectPurc" class="form-control" runat="server" onkeyup="Angka(this)" placeholder="Jumlah..." style="width:100px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td>
           <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></div><asp:TextBox ID="txtAlasanRejectPurchasing" class="form-control" runat="server" onkeyup="upper(this)" placeholder="Alasan Reject..." style="width:280px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td><asp:Button ID="Button4" runat="server" Text="REJECT" 
                 class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="Button4_Click" /></td>
                  <tr>
         <td></td>
         <td></td>
         <td>
             <asp:Label ID="Label20" runat="server" Text=""></asp:Label></td>
     </tr>
    </table>
  </div>
  </div>
 </div>
 </div>
  <div id="rejectheadpur">
 <div class="windowrejectheadpur">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-ban-circle"></span> Reject Item<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
         <tr>
        <td>  <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-dashboard"></span></div>
      <asp:TextBox ID="txtJumlahRejectHeadpur" class="form-control" runat="server" onkeyup="Angka(this)" placeholder="Jumlah..." style="width:100px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
        <td>  <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></div>
      <asp:TextBox ID="txtAlasanRejectHeadPur" class="form-control" runat="server" onkeyup="upper(this)" placeholder="Alasan Reject..." style="width:280px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
          <td><asp:Button ID="btnRejectHeadPur" runat="server" Text="REJECT" 
                 class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnRejectHeadPur_Click" /></td></tr>
    </table>
  </div>
  </div>
 </div>
 </div>
  <div id="rejectvpapp">
 <div class="windowrejectvpapp">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-ban-circle"></span> Reject Item<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
        <tr>
         <td>  <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-dashboard"></span></div>
      <asp:TextBox ID="txtJumlahRejectVpapp" class="form-control" runat="server" onkeyup="Angka(this)" placeholder="Jumlah..." style="width:100px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td>  <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></div>
      <asp:TextBox ID="txtAlasanRejectVpapp" class="form-control" runat="server" onkeyup="upper(this)" placeholder="Alasan Reject..." style="width:280px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnRejectVpapp" runat="server" Text="REJECT" 
                 class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnRejectVpapp_Click" /></td></tr>
    </table>
  </div>
  </div>
 </div>
 </div>
 
  <div id="rejectall">
 <div class="windowrejectall">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-remove"></span> Reject All<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
    <tr>
        <td><asp:TextBox ID="txtAppRejectAll" runat="server" Visible="False"></asp:TextBox></td>
    </tr>
     <tr>
         <td><div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></div>
      <asp:TextBox ID="txtAlasanRejectAll" class="form-control" runat="server" onkeyup="upper(this)" placeholder="Alasan Reject All..." style="width:280px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnRejectAll" runat="server" Text="REJECT ALL" 
                 class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnRejectAll_Click" /></td>
                  <tr>
         <td></td>
         <td></td>
         <td>
             <asp:Label ID="lblRejectAll" runat="server" Text=""></asp:Label></td>
     </tr>
    </table>
  </div>
  </div>
 </div>
 </div>
  <div id="rejectalldivisi">
 <div class="windowrejectalldivisi">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-remove"></span> Reject All<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
    <tr>
        <td><asp:TextBox ID="txtIdRejAllDiv" runat="server" Visible="false"></asp:TextBox></td>
    </tr>
     <tr>
         <td><div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></div>
      <asp:TextBox ID="txtAlasanRejectAllDiv" class="form-control" runat="server" onkeyup="upper(this)" placeholder="Alasan Reject All..." style="width:280px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnRejectAllDiv" runat="server" Text="REJECT ALL" 
                 class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnRejectAllDiv_Click" /></td>
                  <tr>
         <td></td>
         <td></td>
         <td>
             <asp:Label ID="Label98" runat="server" Text=""></asp:Label></td>
     </tr>
    </table>
  </div>
  </div>
 </div>
 </div>
  <div id="rejectallpurchasing">
 <div class="windowrejectallpurchasing">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-remove"></span> Reject All<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
    <tr>
        <td><asp:TextBox ID="txtIdRejectAllPurchasing" runat="server" Visible="False"></asp:TextBox></td>
    </tr>
     <tr>
         <td>   <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></div>
      <asp:TextBox ID="txtAlasanRejectAllPurchasing" class="form-control" runat="server" onkeyup="upper(this)" placeholder="Alasan Reject All..." style="width:280px;position:relative;"></asp:TextBox>
      </div></td>
     </tr>
     <tr>
         <td><asp:Button ID="Button5" runat="server" Text="REJECT ALL" 
                 class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="Button5_Click" /></td>
                  <tr>
         <td></td>
         <td></td>
         <td>
             <asp:Label ID="Label21" runat="server" Text=""></asp:Label></td>
     </tr>
    </table>
  </div>
  </div>
 </div>
 </div>
  <div id="rejectallheadpur">
 <div class="windowrejectallheadpur">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-remove"></span> Reject All<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
     <tr>
         <td>   <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></div>
      <asp:TextBox ID="txtAlasanRejectAllHeadPur" class="form-control" runat="server" onkeyup="upper(this)" placeholder="Alasan Reject All..." style="width:280px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnRejectAllHeadPur" runat="server" Text="REJECT ALL" 
                 class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnRejectAllHeadPur_Click"  /></td>
                 </tr>
    </table>
  </div>
  </div>
 </div>
 </div>
  <div id="rejectallvpapp">
 <div class="windowrejectallvpapp">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-remove"></span> Reject All<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
     <tr>
         <td>   <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></div>
      <asp:TextBox ID="txtAlasanRejectAllVpapp" class="form-control" runat="server" onkeyup="upper(this)" placeholder="Alasan Reject All..." style="width:280px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnRejectAllVpapp" runat="server" Text="REJECT ALL" 
                 class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnRejectAllVpapp_Click" /></td>
                 </tr>
    </table>
  </div>
  </div>
 </div>
 </div>

 <div id="price">
 <div class="windowprice">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-usd"></span> Change Harga<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
    <tr>
        <td><asp:TextBox ID="TextBox5" runat="server" Visible="False"></asp:TextBox></td>
    </tr>
     <tr>
         <td><div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon">Rp.</div>
      <asp:TextBox ID="txtHarga" class="form-control" runat="server" onkeyup="Angka(this)" placeholder="Harga..." style="width:210px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnHarga" runat="server" Text="SAVE HARGA" 
                 class="btn btn-warning btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnHarga_Click" /></td>
    </table>
  </div>
  </div>
 </div>
 </div>
        <div id="barang">
 <div class="windowbarang">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-gift"></span> Change Nama Barang<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
    <tr>
        <td><asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox></td>
    </tr>
     <tr>
         <td><div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-gift"></span></div>
      <asp:TextBox ID="txtNamaBarang" class="form-control" runat="server" onkeyup="upper(this)" placeholder="Nama Barang..." style="width:210px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnNama" runat="server" Text="SAVE Name" 
                 class="btn btn-info btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnNama_Click" /></td>
    </table>
  </div>
  </div>
 </div>
 </div>
          <div id="barangheadpur">
 <div class="windowbarangheadpur">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-gift"></span> Change Nama Barang<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
    <tr>
        <td><asp:TextBox ID="Te5xtbox1" runat="server" Visible="False"></asp:TextBox></td>
    </tr>
     <tr>
         <td><div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-gift"></span></div>
      <asp:TextBox ID="txtNamaBarangHeadpur" class="form-control" runat="server" onkeyup="upper(this)" placeholder="Nama Barang..." style="width:210px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnNamaHeadpur" runat="server" Text="SAVE Name" 
                 class="btn btn-info btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnNamaHeadpur_Click" /></td>
    </table>
  </div>
  </div>
 </div>
 </div>
 <div id="vendor">
 <div class="windowvendor">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-briefcase"></span> Change Vendor<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
     <tr>
         <td><div class="input-group" style="width:100%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-briefcase"></span></div>
             <asp:DropDownList ID="txtNamaVendor" CssClass="form-control" runat="server" DataSourceID="SqlDataSource17" DataTextField="vendor_nama" DataValueField="vendor_nama"></asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource17" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [vendor_id], [vendor_nama] FROM [dbvendor] ORDER BY [vendor_nama]"></asp:SqlDataSource>
             </div></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnSetVendor" runat="server" Text="SAVE VENDOR" 
                 class="btn btn-primary btn-sm" style="margin:5px;font-weight:bold;" 
                 onclick="btnSetVendor_Click" /></td>
    </table>
  </div>
  </div>
 </div>
 </div>
    <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
    </form>
</asp:Content>

