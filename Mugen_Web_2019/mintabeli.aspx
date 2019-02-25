<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="mintabeli.aspx.cs" Inherits="Default2" %>

<asp:Content ID="headBeranda" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen :: Permintaan Pembelian</title>
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
    #popup {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;

overflow: auto;
}

.window 
{
position:relative;	
width: 95%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}

.close-button {
width: 20px;
height: 20px;
background: #000;
border-radius: 50%;
border: 3px solid #fff;
display: block;
text-align: center;
color: #fff;
text-decoration: none;
position: absolute;
top: -10px;
right: -10px;
}

#popup:target {
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

overflow: auto;
}

.windowlampiran
{
position:relative;	
width: 95%;
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
  </style>
</asp:Content>
 <asp:Content ID="bodySesuaiHalaman" ContentPlaceHolderID="body" Runat="Server"> 
 
    <form id="form1" runat="server">
     <div class="container-fluid">
     <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
  <li><a href="#"><span class="glyphicon glyphicon-book"></span>&nbsp;&nbsp;IT / GA & PO</a></li>
  <li><span class="glyphicon glyphicon-usd"></span>&nbsp;&nbsp;Permintaan Pembelian (Purchase Order)</li>
</ol>
         <asp:Button ID="Button1" runat="server" Text="PERMINTAAN BARU" 
                         style="margin:5px;font-weight:bold;" class="btn btn-primary btn-sm" 
                         onclick="Button1_Click" />
<!-- Single button -->
<div class="btn-group">
  <button type="button" class="btn btn-danger btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="font-weight:bold;">
  <span class="glyphicon glyphicon-thumbs-up"></span> APPROVAL <span class="caret"></span>
  </button>
  <ul class="dropdown-menu">
       <li id="mnDivisiApp" runat="server"><a href="approvemintabeli.aspx?q=divisiapproval"><span class="glyphicon glyphicon-flag"></span> 
        <asp:Label ID="Label36" runat="server" Text="Divisi Approval"></asp:Label></a></li>
    <li id="mnHeadApp" runat="server"><a href="approvemintabeli.aspx?q=headapproval"><span class="glyphicon glyphicon-asterisk"></span> 
        <asp:Label ID="Label11" runat="server" Text="Head Approval"></asp:Label></a></li>
    <li id="mnPurcApp" runat="server"><a href="approvemintabeli.aspx?q=purchasing"><span class="glyphicon glyphicon-barcode"></span>  <asp:Label ID="Label12" runat="server" Text="Purchasing Approval"></asp:Label></a></li>
    <li id="mnHPurcApp" runat="server"><a href="approvemintabeli.aspx?q=headpur"><span class="glyphicon glyphicon-qrcode"></span>  <asp:Label ID="Label13" runat="server" Text="Head Purchasing Approval"></asp:Label></a></li>
    <li role="separator" class="divider"></li>
    <li id="mnVpApp" runat="server"><a href="approvemintabeli.aspx?q=vpapp"><span class="glyphicon glyphicon-knight"></span>  <asp:Label ID="Label14" runat="server" Text="Vice President Approval"></asp:Label></a></li>
  </ul>
</div>
<!-- Single button -->
<div class="btn-group">
  <button type="button" class="btn btn-success btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="font-weight:bold;">
  <span class="glyphicon glyphicon-list-alt"></span> &nbsp;PURCHASE ORDER <span class="caret"></span>
  </button>
  <ul class="dropdown-menu">
    <li id="mnNewPo" runat="server"><a href="outstandingpo.aspx"><span class="glyphicon glyphicon-transfer"></span> <asp:Label ID="Label17" runat="server" Text="Buat Purchase Order"></asp:Label></a></li>
      <li id="nmBtlPo" runat="server"><a href="batalpo.aspx"><span class="glyphicon glyphicon-remove"></span> <asp:Label ID="Label34" runat="server" Text="Batal Purchase Order"></asp:Label></a></li>
     <li id="mnDaftarPO" runat="server"><a href="daftarpo.aspx" target="_self"><span class="glyphicon glyphicon-list-alt"></span>  <asp:Label ID="Label30" runat="server" Text="Daftar Purchase Order"></asp:Label></a></li>
     <li id="mnDaftarPoBatal" runat="server"><a href="daftarpobatal.aspx" target="_self"><span class="glyphicon glyphicon-list-alt"></span>  <asp:Label ID="Label35" runat="server" Text="Daftar Purchase Order Batal"></asp:Label></a></li>
    <li id="mnTerimaBarang" runat="server"><a href="listpo.aspx" target="_blank"><span class="glyphicon glyphicon-gift"></span>  <asp:Label ID="Label18" runat="server" Text="Terima Barang"></asp:Label></a></li>
    <li role="separator" class="divider"></li>
    <li id="mnViewStok" runat="server"><a href="liststok.aspx" target="_blank"><span class="glyphicon glyphicon-check"></span>  <asp:Label ID="Label19" runat="server" Text="Daftar Stok"></asp:Label></a></li>
  </ul>

</div>
         <div class="btn-group">
  <button type="button" id="mnMaster" runat="server" class="btn btn-info btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="font-weight:bold;">
  <span class="glyphicon glyphicon-oil"></span> &nbsp;MASTER DATA<span class="caret"></span>
  </button>
  <ul class="dropdown-menu">
    <li id="Li1" runat="server"><a href="datavendor.aspx"><span class="glyphicon glyphicon-copy"></span> 
        <asp:Label ID="Label25" runat="server" Text="Data Vendor"></asp:Label></a></li>
      <li id="Li2" runat="server"><a href="dataitem.aspx"><span class="glyphicon glyphicon-briefcase"></span> 
        <asp:Label ID="Label26" runat="server" Text="Data Barang"></asp:Label></a></li>
        <li id="Li3" runat="server"><a href="datalamp.aspx"><span class="glyphicon glyphicon-paperclip"></span> 
        <asp:Label ID="Label27" runat="server" Text="Data Lampiran"></asp:Label></a></li>
   
  </ul>
</div>
          <div style="width:400px;margin:5px;background:linear-gradient(#c0c0c0, #ddd);padding:5px;border-radius:4px;-webkit-border-radius:4px;-o-border-radius:4px;-moz-border-radius:4px;">
         <table>
             <tr>
                 <td> <asp:Label ID="Label7" Style="margin:5px;font-weight:bold;font-size:8pt;font-family:Verdana;" runat="server" Text="<span class='glyphicon glyphicon-cog'></span> Detail View :"></asp:Label></td>
                  <td><asp:DropDownList ID="drpView" CssClass="form-control input-sm" style="width:200px;color:#0080c0;font-weight:bold;font-family:Verdana;" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                 <asp:ListItem></asp:ListItem>
                 <asp:ListItem Value="All">Lihat Semua</asp:ListItem>
                 <asp:ListItem Value="me">Punya Saya</asp:ListItem>
                      <asp:ListItem Value="Rej">Ditolak</asp:ListItem>
             </asp:DropDownList></td>

             </tr>
         </table>
              </div>
        
             
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" class="table table-bordered" style="margin:5px;font-size:9pt;font-size:tahoma;" PageSize="10">
    <RowStyle BackColor="#EFF3FB"  />
    <Columns>
     <asp:TemplateField HeaderText="No." SortExpression="nofmbhead">
            <ItemTemplate>
                <asp:Label ID="LabelNo" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Cab." SortExpression="kdcabang">
            <ItemTemplate>
                <asp:Label ID="Label6" runat="server" Text='<%# Bind("cab") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="No. Bukti" SortExpression="nofmbhead">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("nofmbhead") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
          <asp:TemplateField HeaderText="Status" SortExpression="stat">
            <ItemTemplate>
                <asp:Label ID="Label28" runat="server" Text='<%# Bind("stat") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Total" SortExpression="total">
            <ItemTemplate>
                <asp:Label ID="Label10" runat="server" Text='<%# Bind("total", "{0:0,0}") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Pemohon" SortExpression="userfmb">
            <ItemTemplate>
                <u style="font-weight:bold;"><asp:Label ID="Label2" runat="server" Text='<%# Bind("userfmb") %>'></asp:Label></u> (  <asp:Label ID="Label31" runat="server" Text='<%# Bind("nmdivisi") %>'> </asp:Label> )<br />
                    <asp:Label ID="Label32" runat="server" Text='<%# Bind("tglpemohonfmb") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Head Approval" SortExpression="disetujuifmb">
            <ItemTemplate>
                <u style="font-weight:bold;"><asp:Label ID="Label4" runat="server" Text='<%# Bind("disetujuifmb") %>'></asp:Label></u><br />
                <asp:Label ID="Label29" runat="server" Text='<%# Bind("tgldisetujuifmb") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="Head Purchase" SortExpression="approveheadpurc">
            <ItemTemplate>
                <u style="font-weight:bold;"><asp:Label ID="Label8" runat="server" Text='<%# Bind("approveheadpurc") %>'></asp:Label></u><br />
                  <asp:Label ID="Label5" runat="server" Text='<%# Bind("tglapproveheadpurc") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vice President (>2jt)" 
            SortExpression="disetujui2fmb">
            <ItemTemplate>
                 <u style="font-weight:bold;"><asp:Label ID="Label9" runat="server" Text='<%# Bind("disetujui2fmb") %>'></asp:Label></u><br />
                 <asp:Label ID="Label33" runat="server" Text='<%# Bind("tgldisetujui2fmb") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "mintabeli.aspx?q2=All&q=" + Eval("nofmbhead") + "#lampiran" %>'
                    Target="_self" Text="Lampiran" class="btn btn-info btn-xs" style="font-family:Verdana;"></asp:HyperLink>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "mintabeli.aspx?q2=All&q=" + Eval("nofmbhead") + "#popup" %>'
                    Target="_self" Text="Lihat" class="btn btn-primary btn-xs" style="font-family:Verdana;"></asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="5" />
     <pagerstyle cssclass="gridview">

</pagerstyle>
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
    
             SelectCommand="SELECT case tb_user.kdcabang when '112' then 'Ps.Minggu' when '128' then 'Puri' else 'Ps. Minggu' end AS cab, divisi.nmdivisi, fmbhead.nofmbhead, fmbhead.userfmb, convert(varchar, tglpemohonfmb,106) as tglpemohonfmb , fmbhead.disetujuifmb, convert(varchar, tgldisetujuifmb,106) as tgldisetujuifmb, fmbhead.mengetahuifmb, fmbhead.tglmengetahuifmb, case fmbhead.rejecthead when 'N' then '<strong style=color:green;>Tersedia</strong>' when 'Y' then '<strong style=color:red;>Ditolak</strong>' end AS stat, fmbhead.approveheadpurc, convert(varchar, tglapproveheadpurc,106) as tglapproveheadpurc, SUM(fmbbody.hargaitem*fmbbody.jumlahitem) AS total, fmbhead.disetujui2fmb, convert(varchar, tgldisetujui2fmb, 106) AS tgldisetujui2fmb  FROM fmbhead INNER JOIN fmbbody ON fmbhead.nofmbhead = fmbbody.nobody INNER JOIN tb_user ON fmbhead.pemohonfmb = tb_user.username INNER JOIN divisi ON tb_user.kddivisi = divisi.kddivisi WHERE (@q2 = 'me' AND pemohonfmb = @ses OR @q2 = 'me' AND disetujuifmb = @ses OR @q2 = 'me' AND approveheadpurc = @ses OR @q2 = 'me' AND disetujui2fmb = @ses) OR (@q2 = 'All' AND rejectoleh IS NULL) OR (@q2 = 'Rej' AND rejectoleh IS NOT NULL) GROUP BY fmbhead.disetujui2fmb, fmbhead.tgldisetujui2fmb, fmbhead.nofmbhead, fmbhead.userfmb, fmbhead.tglpemohonfmb, fmbhead.disetujuifmb, fmbhead.tgldisetujuifmb, fmbhead.mengetahuifmb, fmbhead.tglmengetahuifmb, fmbhead.approveheadpurc, fmbhead.tglapproveheadpurc, fmbhead.rejecthead, divisi.nmdivisi, tb_user.kdcabang, fmbbody.rejectoleh  ORDER BY nofmbhead DESC ">
 <SelectParameters>
          <asp:QueryStringParameter Name="q2" QueryStringField="q2" Type="String" />
      </SelectParameters>
    <SelectParameters>
              <asp:SessionParameter Name="ses" SessionField="username" Type="String" />
      </SelectParameters>
</asp:SqlDataSource>
   
                 
                 
                 <div id="popup">
 <div class="window">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
  <div class="panel-heading"><span class="glyphicon glyphicon-search"></span> View Permintaan Pembelian <a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
      <div class="kirih" style="float:left;width:25%;height:100px;padding:20px;">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/img/hlogo.png" style="width:80px;height:60px;float:left;"/>
    </div>
    <div class="kirih" style="float:left;width:50%;height:100px;font-weight:bold;text-align:center;padding-top:50px;font-size:14pt;text-transform:uppercase;">
       <u><asp:Label ID="Label15" runat="server" Text="Permintaan Pembelian"></asp:Label></u> <br />
          <asp:Label ID="lblNoBukti" runat="server" Text="" style="color:Blue;font-size:12pt;text-transform:normal;"></asp:Label>       
    </div>
    <div class="kirih" style="float:left;width:25%;height:100px;">
        <asp:Label ID="Label16" runat="server" Text="Honda Mugen" style="font-weight:bold;"></asp:Label><br />    
        <asp:Label ID="Label20" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:8pt;"></asp:Label><br />    
        <asp:Label ID="Label21" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label22" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label23" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label24" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:8pt;"></asp:Label>            
     </div>
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" class="table table-bordered" style="margin:5px;font-size:9pt;" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("kelompokisi") %>' style="font-size:9pt;"></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pusat Biaya" SortExpression="pusatbiaya">
                    <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("pusatbiaya") %>' style="font-size:9pt;"></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="No. PO" SortExpression="nopurchaseorder" HeaderStyle-Width="8">
                    <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("nopurchaseorder") %>' style="font-size:8pt;"></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qty" SortExpression="jumlahitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("jumlahitem") %>' style="font-size:9pt;font-family:Verdana;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Rcv" SortExpression="jumlahitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("jumlahterima") %>' style="font-size:9pt;font-family:Verdana;"></asp:Label>
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
                 </Columns>
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <pagerstyle cssclass="gridview">

</pagerstyle>
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="White" />
         </asp:GridView>
                     <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         SelectCommand="SELECT [idbody], case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [nobody], [namaitem], [vendor], [tujuanitem], [jumlahterima], [jumlahitem], [hargaitem], [reject], [alasanreject], [rejectoleh], [pusatbiaya], [nopurchaseorder], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody2) AND reject = 'APPROVE'">
                              <SelectParameters>
                                    <asp:QueryStringParameter Name="nobody2" QueryStringField="q" Type="String" />
                               </SelectParameters>
                     </asp:SqlDataSource>
                    
                    <table style="width:70%;float:left;margin-left:5px;font-size:8pt;color:blue;font-family:Verdana;">
                      <tr>
                            <td>Note : Untuk pembelian diatas Rp. 2.000.000,- harus mendapat persetujuan dari Vice President Director</td>
                      </tr>
                    </table>
                    
                    <table style="width:26%;float:right;border:1px solid #c0c0c0;" border="1">
                       <tr>
                            <td style="width:50%;padding:5px;text-align:right;font-weight:bold;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">TOTAL :</td>
                            <td style="width:50%;padding:5px;text-align:center;font-weight:bold;font-size:12pt;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;"><asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></td>
                       </tr>
                    </table>
                    
                    <table style="width:100%;float:left;margin:8px;text-align:center;font-family:Verdana;color:#333;">
                       <tr>
                            <th style="text-align:center;">Dibuat,</th>
                            <th style="text-align:center;">Disetujui,</th>
                            <th style="text-align:center;">Disetujui,</th>
                            <th style="text-align:center;">Disetujui,</th>
                       </tr>
                       <tr>
                             <td><br /></td>
                             <td><br /></td>
                             <td><br /></td>
                             <td><br /></td>
                       </tr>
                       <tr>
                             <td><br /></td>
                             <td><asp:Label ID="lblAppHead" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);-o-transform: rotate(-20deg);opacity: 0.3; "></asp:Label></td>
                             <td><asp:Label ID="lblAppHeadPurc" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);opacity: 0.3;"></asp:Label></td>
                             <td><asp:Label ID="lblAppVicep" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);opacity: 0.3;"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><br /></td>
                            <td><br /></td>
                            <td><br /></td>
                            <td><br /></td>
                        </tr>
                        <tr>
                            <td><u><asp:Label ID="lblNamaPemohon" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaHead" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaHeadPurc" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaVicep" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="font-size:9pt;color:Blue;">(Head Department)</td>
                            <td style="font-size:9pt;color:Blue;">(Head Purchasing)</td>
                            <td style="font-size:9pt;color:Blue;">(Vice President Director)</td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblTglPemohon" runat="server" Text="" style="font-size:8pt;margin:0;color:#666"></asp:Label></td>
                            <td><asp:Label ID="lblTglHead" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                            <td><asp:Label ID="lblTglHeadPurc" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                            <td><asp:Label ID="lblTglVicep" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                        </tr>
                     </table>
      <table style="float:left;width:100%;font-family:Verdana;font-size:8pt;text-align:center;font-weight:bold;color:#c60000;"><tr><td>Daftar Barang yg ditolak</td></tr></table>
      <table><tr><td><div id="spoiler">
<div><input style="font-size: 11px; padding: 2px;" onclick="if (this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display != '') { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = ''; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = 'none'; this.innerText = ''; this.value = 'Sembunyikan'; } else { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = 'none'; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = ''; this.innerText = ''; this.value = 'Tampilkan'; }" name="button" type="button" value="Tampilkan yang di-tolak" /></div></td></tr>
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
         </asp:GridView>  </table>
         </div><div id="hide"></div></div>
    
                     <asp:SqlDataSource ID="SqlDataSource11" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         SelectCommand="SELECT [idbody], [nobody], [namaitem], [vendor], [tujuanitem], [jumlahitem], [hargaitem], [reject], [alasanreject], [rejectoleh], [pusatbiaya], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody) AND reject = 'REJECT'">
                              <SelectParameters>
                             <asp:QueryStringParameter Name="nobody" QueryStringField="q" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
          </div>
  
  </div>
 </div>
 </div>   
                     </div> 
        <div id="lampiran">
 <div class="windowlampiran">
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
                             <asp:QueryStringParameter Name="app2" QueryStringField="q" Type="String" />
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
    </form>
    <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
</asp:Content>
