<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="listmintabeli.aspx.cs" Inherits="mintabeli" %>
<asp:Content ID="headBeranda" ContentPlaceHolderID="head" Runat="Server">
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
  </style>
</asp:Content>
 <asp:Content ID="bodySesuaiHalaman" ContentPlaceHolderID="body" Runat="Server"> 
     <form id="form1" runat="server">
     <div class="container-fluid">
     <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
  <li><a href="#"><span class="glyphicon glyphicon-edit"></span>&nbsp;&nbsp;Apply Form</a></li>
  <li><span class="glyphicon glyphicon-comment"></span>&nbsp;&nbsp;Form Permintaan Pembelian</li>
</ol>
         
<div class="kirih" style="float:left;width:25%;height:100px;padding:20px;">
         <asp:Image ID="Image1" runat="server" ImageUrl="~/img/hlogo.png" style="width:80px;height:60px;float:left;"/>
    </div>
    <div class="kirih" style="float:left;width:50%;height:100px;font-weight:bold;text-align:center;
    padding-top:50px;font-size:14pt;text-transform:uppercase;">
        <asp:Label ID="Label1" runat="server" Text="Permintaan Pembelian"></asp:Label>    
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
                 class="btn btn-primary btn-sm" NavigateUrl="#popup"><span class="glyphicon glyphicon-edit"></span> TAMBAH ITEM</asp:HyperLink>
         <asp:HyperLink ID="HyperLink3" runat="server" style="margin-bottom:5px;margin-top:5px;font-weight:bold;font-family:Tahoma;" 
                 class="btn btn-warning btn-sm" NavigateUrl="#lampiran"><span class="glyphicon glyphicon-paperclip"></span> LAMPIRAN</asp:HyperLink>
         <asp:Button ID="btnSelesai" runat="server" Text="SELESAI PROSES" 
                         class="btn btn-danger btn-sm" style="font-weight:bold;font-family:Tahoma;" 
                         onclick="btnSelesai_Click" /><BR />
         <div style="width:400px;margin:5px;background:linear-gradient(#c0c0c0, #ddd);padding:2px;border-radius:4px;-webkit-border-radius:4px;-o-border-radius:4px;-moz-border-radius:4px;">
         <asp:label style="margin:5px;font-weight:bold;font-family:Verdana;font-size:8pt;" runat="server" text="User yg mengajukan :"></asp:label> <asp:textbox ID="txtNama" onkeyup="upper(this)" placeholder="Tulis nama anda disini.." class="form-control input-sm" style="font-weight:bold;width:350px;margin:5px;" runat="server"></asp:textbox>
        </div>
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                         DataKeyNames="idfmb" DataSourceID="SqlDataSource1" 
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
                         <asp:Label ID="Label26" runat="server" Text='<%# Bind("kelompokisi") %>'></asp:Label>
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
                         <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "listmintabeli.aspx?id=" + Eval("idfmb") %>' 
                             Target="_self" Text="X" class="btn btn-danger btn-xs"></asp:HyperLink>
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
                         
                         SelectCommand="SELECT [idfmb], case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [namaitem], [vendor], [tujuanitem], [jumlahitem], [pusatbiaya], [hargaitem], [hargaitem] * [jumlahitem] AS totl FROM [fmb] WHERE ([username] = @username) ORDER BY [idfmb]">
                         <SelectParameters>
                             <asp:SessionParameter Name="username" SessionField="username" Type="String" />
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
                 </div>
                 
                 <div id="popup">
 <div class="window">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-edit"></span> Tambah Item<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    
    
  <table>
  <tr>
    <td>
        <asp:Label ID="Label8" runat="server" Text="Nama Barang"></asp:Label></td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtBarang" runat="server" class="form-control input-sm" style="margin:5px;width:250px;" onkeyup="upper(this)" placeholder="Nama Barang..."></asp:TextBox></td>
      <asp:TextBox ID="txtUser" runat="server" Visible="False"></asp:TextBox>
  </tr>
  <tr>
    <td>
        <asp:Label ID="Label9" runat="server" Text="Tujuan Beli"></asp:Label></td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtTujuan" runat="server" class="form-control input-sm" style="margin:5px;width:400px;" onkeyup="upper(this)" placeholder="Tujuan Beli..."></asp:TextBox></td>
  </tr>
   <tr>
    <td>
        <asp:Label ID="Label10" runat="server" Text="Jumlah"></asp:Label></td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtJumlah" runat="server" class="form-control input-sm" style="margin:5px;width:50px;" onkeyup="Angka(this)"></asp:TextBox></td>
  </tr>
      <tr>
                   <td>
        <asp:Label ID="Label25" runat="server" Text="Tujuan Permintaan"></asp:Label></td>
    <td>:</td><td>
        <asp:DropDownList ID="DrpTuj" runat="server" 
            style="margin:5px;width:300px;font-weight:bold;color:#0080c0;" class="form-control input-sm">
            <asp:ListItem>
            </asp:ListItem>
            <asp:ListItem Value="01">Pengadaan Baru</asp:ListItem>
            <asp:ListItem Value="02">Penggantian</asp:ListItem>
            <asp:ListItem Value="03">Perbaikan</asp:ListItem>
            <asp:ListItem Value="04">Uji Coba</asp:ListItem>
        </asp:DropDownList>
    </td></tr>
   <tr>
    <td>
        <asp:Label ID="Label13" runat="server" Text="Pusat Biaya"></asp:Label></td>
    <td>:</td>
    <td>
        <asp:DropDownList ID="txtPusat" runat="server" 
            style="margin:5px;font-weight:bold;color:#0080c0;" class="form-control input-sm">
            <asp:ListItem>
            </asp:ListItem>
            <asp:ListItem Value="SHOWROOM">Showroom</asp:ListItem>
            <asp:ListItem Value="SERVICE">Service</asp:ListItem>
            <asp:ListItem Value="HEAD OFFICE">Head Office</asp:ListItem>
            <asp:ListItem Value="SHOWROOM &amp; SERVICE">Showroom &amp; Service</asp:ListItem>
        </asp:DropDownList>
    </td>
  </tr>
 <tr>
    <td>
        <asp:Label ID="Label11" runat="server" Text="Harga"></asp:Label></td>
    <td>:</td>
    <td> <div style="margin:5px;background:linear-gradient(#c0c0c0, #ddd);padding:5px;border-radius:4px;-webkit-border-radius:4px;-o-border-radius:4px;-moz-border-radius:4px;">
        <asp:TextBox ID="txtHarga" runat="server" class="form-control input-sm" style="width:150px;float:left;" onkeyup="Angka(this)" placeholder="Harga.."></asp:TextBox>
       <asp:Label ID="Label27" style="font-size:8pt;font-family:Verdana;color:blue;margin-left:5px;" runat="server" Text="<span class='glyphicon glyphicon-info-sign'></span> <u style='font-weight:bold;'>INFO:</u><br/>Harga Sudah Termasuk PPN (Bila ada PPN)."></asp:Label>
    </div>
            </td>
  </tr>
  <tr>
    <td></td>
    <td></td>
    <td>
        <asp:Button ID="Button1" runat="server" Text="Simpan" class="btn btn-success" 
            style="font-weight:bold;" onclick="Button1_Click1" /></td>
  </tr>
    <tr>
    <td></td>
    <td></td>
    <td>
        <asp:Label ID="Label12" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label></td>
  </tr>
  </table>
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
        <asp:Label ID="Label15" runat="server" Text="File"></asp:Label></td>
    <td>:</td>
    <td>
        <asp:FileUpload ID="FileUpload1" runat="server" class="form-control input-sm" style="margin:5px;"/></td>
  </tr>
    <tr>
    <td>
        <asp:Label ID="Label16" runat="server" Text="Keterangan"></asp:Label></td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtKet" runat="server" class="form-control input-sm" style="margin:5px;" onkeyup="upper(this)" placeholder="keterangan lampiran..."></asp:TextBox></td>
  </tr>
  <tr>
    <td></td>
    <td></td>
    <td><asp:Button ID="Button2" class="btn btn-success btn-sm" 
            style="font-weight:bold;" runat="server" Text="UPLOAD" 
            onclick="Button2_Click" /></td>
  </tr>
 <tr>
    <td></td>
    <td></td>
    <td>
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label></td>
  </tr>
  </table>
  
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
                         
                         SelectCommand="SELECT * FROM [templamp] WHERE ([username] = @username) ORDER BY [idlampiran]">
                         <SelectParameters>
                             <asp:SessionParameter Name="username" SessionField="username" Type="String" />
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
