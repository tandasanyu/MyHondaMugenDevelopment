<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewreq.aspx.cs" Inherits="viewreq" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
         #buatpo {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}

.windowbuatpo
{
position:relative;	
width: 55%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}

#buatpo:target {
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
width: 35%;
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
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
<form id="form1" runat="server">
     <div class="container-fluid">
     <ol class="breadcrumb">
         <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
         <li><a href="mintabeli.aspx"><span class="glyphicon glyphicon-comment"></span>&nbsp;&nbsp;Form Permintaan Pembelian</a></li>
         <li><a href="outstandingpo.aspx"><span class="glyphicon glyphicon-list-alt"></span>&nbsp;&nbsp;Purchase Order</a></li>
         <li><span class="glyphicon glyphicon-transfer"></span>&nbsp;&nbsp;Waiting Purchase Order</li>
     </ol>
    <div class="kirih" style="float:left;width:25%;height:100px;padding:20px;">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/img/hlogo.png" style="width:80px;height:60px;float:left;"/>
    </div>
    <div class="kirih" style="float:left;width:50%;height:100px;font-weight:bold;text-align:center;padding-top:50px;font-size:14pt;text-transform:uppercase;">
       <u><asp:Label ID="Label12" runat="server" Text="Permintaan Pembelian"></asp:Label></u> <br />
          <asp:Label ID="lblNoBukti" runat="server" Text="" style="color:Blue;font-size:12pt;text-transform:normal;"></asp:Label>       
    </div>
    <div class="kirih" style="float:left;width:25%;height:100px;">
        <asp:Label ID="Label14" runat="server" Text="Honda Mugen" style="font-weight:bold;"></asp:Label><br />    
        <asp:Label ID="Label15" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:8pt;"></asp:Label><br />    
        <asp:Label ID="Label16" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label17" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label18" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label19" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:8pt;"></asp:Label>            
     </div>
     <asp:HyperLink ID="linkProsesPo" runat="server" style="margin-left:5px;font-weight:bold;font-family:Tahoma;" class="btn btn-danger btn-sm" NavigateUrl="#buatpo"><span class="glyphicon glyphicon-transfer"></span> Buat Purchase Order</asp:HyperLink>
       <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Timer ID="Timer1" runat="server" OnTick="GetTime" Interval="1000" />
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
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("kelompokisi") %>' style="font-size:9pt;"></asp:Label>
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
                 <asp:TemplateField HeaderText="Status" SortExpression="reject" HeaderStyle-Width="180">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("reject") %>' style="font-family:tahoma;font-weight:bold;color:green;font-size:8pt;"></asp:Label>
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
                 </Columns>
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="White" />
         </asp:GridView>
        </ContentTemplate>
</asp:UpdatePanel>
                     <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         SelectCommand="SELECT [idbody], case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [nobody], [namaitem], [vendor], [tujuanitem], [jumlahitem], [hargaitem], [reject], [alasanreject], [rejectoleh], [pusatbiaya], [nopurchaseorder], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody2) AND reject = 'APPROVE'">
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
                            <th style="text-align:center;">Mengetahui,</th>
                            <th style="text-align:center;">Disetujui,</th>
                            <th style="text-align:center;">Disetujui,</th>
                       </tr>
                       <tr>
                             <td><br /></td>
                             <td><br /></td>
                             <td><br /></td>
                             <td><br /></td>
                             <td><br /></td>
                       </tr>
                       <tr>
                             <td><br /></td>
                             <td><asp:Label ID="lblAppHead" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);-o-transform: rotate(-20deg);opacity: 0.3; "></asp:Label></td>
                             <td><asp:Label ID="lblAppPurc" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);opacity: 0.3;"></asp:Label></td>
                             <td><asp:Label ID="lblAppHeadPurc" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);opacity: 0.3;"></asp:Label></td>
                             <td><asp:Label ID="lblAppVicep" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);opacity: 0.3;"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><br /></td>
                            <td><br /></td>
                            <td><br /></td>
                            <td><br /></td>
                            <td><br /></td>
                        </tr>
                        <tr>
                            <td><u><asp:Label ID="lblNamaPemohon" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaHead" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaPurc" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaHeadPurc" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaVicep" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="font-size:9pt;color:Blue;">(Head Department)</td>
                            <td style="font-size:9pt;color:Blue;">(Purchasing)</td>
                            <td style="font-size:9pt;color:Blue;">(Head Purchasing)</td>
                            <td style="font-size:9pt;color:Blue;">(Vice President Director)</td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblTglPemohon" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                            <td><asp:Label ID="lblTglHead" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                            <td><asp:Label ID="lblTglPurc" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                            <td><asp:Label ID="lblTglHeadPurc" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                            <td><asp:Label ID="lblTglVicep" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                        </tr>
                     </table>
          </div>
<div id="lampiran">
    <div class="windowlampiran">
        <div class="panel panel-primary" style="width:100%;margin:3px;">
            <div class="panel-heading" style="text-align:left;">
                <span class="glyphicon glyphicon-paperclip"></span> Lampiran<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;">
                <span class="glyphicon glyphicon-remove"></span> CLOSE</a>
             </div>
                <div class="panel-body">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" class="table table-bordered" style="margin:5px;font-size:9pt;width:80%;position:relative;" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
                                <itemtemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                 <headerstyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Keterangan" SortExpression="keterangan">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("keterangan") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Penawaran" SortExpression="vendor">
                                 <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("lokasifile") %>' Target="_blank" Text="Download" class="btn btn-info btn-xs" style="font-weight:bold;"></asp:HyperLink>
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
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                          SelectCommand="SELECT * FROM [fmblamp] WHERE ([nohead] = @app1)">
                         <SelectParameters>
                            <asp:QueryStringParameter Name="app1" QueryStringField="q" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                   </div>
             </div>
       </div>
</div>
<div id="buatpo">
    <div class="windowbuatpo">
        <div class="panel panel-primary" style="width:100%;margin:3px;">
            <div class="panel-heading" style="text-align:left;">
                <span class="glyphicon glyphicon-transfer"></span> Buat Purchase Order<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;">
                <span class="glyphicon glyphicon-remove"></span> CLOSE</a>
             </div>
             <div class="panel-body">
             <table style="width:100%;">
             <tr>
                <td>No. Req</td>
                 <td>:</td>
                 <td>
                     <asp:TextBox ID="txtNoReq" runat="server" class="form-control" style="margin:5px;width:60%;float:left;" placeholder="Alamat e-Mail..."></asp:TextBox>
                 </td>
             </tr>
             <tr>
                <td>Vendor</td>
                 <td>:</td>
                 <td colspan="4">
                <asp:DropDownList ID="txtVendor" runat="server" 
                 DataSourceID="SqlDataSource1" DataTextField="isi" 
                 DataValueField="isi" class="form-control" style="margin:5px;">
                 <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                   SelectCommand="SELECT DISTINCT cast ([vendor] as VARCHAR(MAX)) AS isi FROM [fmbbody] WHERE reject = 'APPROVE' AND ([nobody] = @app1) AND nopurchaseorder IS NULL">
                   <SelectParameters>
                            <asp:QueryStringParameter Name="app1" QueryStringField="q" Type="String" />
                         </SelectParameters>
                 </asp:SqlDataSource>
                 </td>
             </tr>
              <tr>
                <td>
                    Ship to
                 <td>:</td>
                 <td colspan="4">
                     <asp:DropDownList ID="txtShipper" runat="server" class="form-control" style="margin:5px;width:100%;">
                         <asp:ListItem></asp:ListItem>
                         <asp:ListItem Value="112">HONDA MUGEN PASAR MINGGU</asp:ListItem>
                         <asp:ListItem Value="128">HONDA MUGEN PURI</asp:ListItem>
                 
                     </asp:DropDownList>
                 </td>
             </tr>
              <tr>
                <td style="font-size:0.75em;">Shipping Method</td>
                 <td>:</td>
                 <td>
                     <asp:DropDownList ID="txtShippingMethod" runat="server" class="form-control" style="margin:5px;width:80%;">
                         <asp:ListItem></asp:ListItem>
                         <asp:ListItem>DIKIRIM</asp:ListItem>
                         <asp:ListItem>DIAMBIL</asp:ListItem>
                         <asp:ListItem>LAIN-LAIN</asp:ListItem>
                     </asp:DropDownList>
                 </td>
               
             </tr>
              <tr>
                <td>Shipping Term</td>
                 <td>:</td>
                 <td colspan="4">
                     <asp:TextBox ID="txtShippingTerm" runat="server" class="form-control" onkeyup="upper(this)" style="margin:5px;" placeholder="Ketentuan Pengiriman..."></asp:TextBox>
                 </td>
             </tr>
             <tr>
                <td style="font-size:0.75em;">Term Of Payment</td>
                 <td>:</td>
                 <td colspan="4">
                     <asp:TextBox ID="txtTop" runat="server" class="form-control" onkeyup="upper(this)" style="margin:5px;" placeholder="Ketentuan Pembayaran..."></asp:TextBox>
                 </td>
             </tr>
              <tr>
                <td style="font-size:0.75em;"></td>
                 <td></td>
                 <td colspan="4" style="text-align:right;">
                     <asp:Button ID="Button1" runat="server" Text="PROSES PURCHASE ORDER" 
                         class="btn btn-primary btn-sm" style="margin:5px;font-family:Verdana;" 
                         onclick="Button1_Click" />
                 </td>
             </tr>
             </table>
             </div>
         </div>
     </div>
</div>
 </form>
                     
     <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
</asp:Content>

