<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobcontrolformanedtpuri.aspx.cs" Inherits="jobcontrolformanedtpuri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Honda Mugen :: Job Control Foreman</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <style>
        #popup2 {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}

.window2 
{
position:relative;	
width: 30%;
top: 20px;
height:25%;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
overflow:auto;
            left: 0px;
        }


#popup2:target {
visibility: visible;
}
    #page-loader{
position:fixed !important;
top:0;
right:0;
bottom:0;
left:0;
z-index:9999;
background:Black url('img/loading.gif') no-repeat 50% 50%;
font:0/0;
text-shadow:none;
padding:1em 1.2em;
display:none;
opacity: 0.7;
}
    </style>
     <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
</head>
<body>
       <div id="page-loader"></div>
    <form id="form1" runat="server">
    <div>
    <table style="font-size:1.0em;width:100%;"><tr><td><center style="background:#c0c0c0;">Data Proses</center>
         <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" style="width:100%;float:left;">
                <ItemTemplate>
                    <table style="width:100%;font-family:Verdana;font-size:0.9em;" class="table table-striped">
                        <tr><td style="width:30%;">No. WO</td><td>:</td><td style="font-weight:bold;color:blue;"> <asp:Label ID="WOHDR_NOLabel" runat="server" Text='<%# Eval("WOHDR_NO") %>' /></td></tr>
                        <tr><td>Tgl. WO</td><td>:</td><td> <asp:Label ID="WOHDR_TGWOLabel" runat="server" Text='<%# Eval("WOHDR_TGWO") %>' /></td></tr>
                        <tr><td>No. Polisi</td><td>:</td><td style="font-weight:bold;color:#333;"> <asp:Label ID="WOHDR_FNOPOLLabel" runat="server" Text='<%# Eval("WOHDR_FNOPOL") %>' /></td></tr>
                        <tr><td>No. Rangka</td><td>:</td><td> <asp:Label ID="Label1" runat="server" Text='<%# Eval("WOHDR_FNRK") %>' /></td></tr>
                        <tr><td>No. Mesin</td><td>:</td><td> <asp:Label ID="Label2" runat="server" Text='<%# Eval("WOHDR_FNMS") %>' /></td></tr>
                        <tr><td>Nama Pemilik</td><td>:</td><td> <asp:Label ID="Label3" runat="server" Text='<%# Eval("WOHDR_FORG") %>' /></td></tr>
                        <tr><td>Kode Tagih</td><td>:</td><td>  <asp:Label ID="Label4" runat="server" Text='<%# Eval("WOHDR_KDTAGIH") %>' /></td></tr>
                        <tr><td>Service Advisor (SA)</td><td>:</td><td> <asp:Label ID="Label5" runat="server" Text='<%# Eval("WOHDR_SA") %>' /></td></tr>
                        </table>
                </ItemTemplate>
            </asp:DataList>
            </td></tr></table>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:service128Connection %>" SelectCommand="SELECT WOHDR_TGWO, WOHDR_FNOPOL, WOHDR_FNMS, WOHDR_FNRK, WOHDR_FORG, WOHDR_KDTAGIH, WOHDR_SA, WOHDR_NO FROM TRXN_WOHDR WHERE (WOHDR_NO = @WOHDR_FNOPOL)">
                 <SelectParameters>
                     <asp:QueryStringParameter Name="WOHDR_FNOPOL" QueryStringField="qnowo" Type="String" />
                 </SelectParameters>
            </asp:SqlDataSource>
      <table style="font-size:1.0em;width:100%;"><tr><td><center style="background:#c0c0c0;">Daftar Keluhan</center>
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" EnableModelValidation="True" style="width:100%;float:left;font-family:Verdana;font-size:0.8em;" class="table table-striped"  PageSize="100" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Keluhan" SortExpression="WOKELUH_KELUH">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("WOKELUH_KELUH") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PageButtonCount="1" PreviousPageText="Prev" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
             <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:service128Connection %>" SelectCommand="SELECT WOKELUH_NOWO, WOKELUH_KELUH FROM TRXN_WOKELUH INNER JOIN TRXN_WOHDR ON TRXN_WOKELUH.WOKELUH_NOWO = TRXN_WOHDR.WOHDR_NO WHERE (WOHDR_NO = @qkey) ORDER BY WOKELUH_KELUH">
                 <SelectParameters>
                     <asp:QueryStringParameter Name="qkey" QueryStringField="qnowo" />
                 </SelectParameters>
            </asp:SqlDataSource>
           </td></tr></table>
          <div id="spoiler">
<div><input style="font-size: 11px; padding: 2px;" onclick="if (this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display != '') { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = ''; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = 'none'; this.innerText = ''; this.value = 'Sembunyikan'; } else { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = 'none'; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = ''; this.innerText = ''; this.value = 'Tampilkan'; }" name="button" type="button" value="Buka Gambar Terakhir" /></div>
<div id="show" style="border: 1px solid white; display: none; margin: 5px; padding: 2px; width: 98%;">
    <asp:Image ID="Image1" runat="server"  Style="width:600px;height:400px;"/>
</div><div id="hide"></div></div>
      
    
          <table style="font-size:0.85em;float:left;width:100%;"><tr><td><center style="background:#c0c0c0;">History Pengerjaan                                                            </center>
      <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" EnableModelValidation="True" class="table table-striped" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" style="width:100%;">
          <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
          <Columns>
               <asp:TemplateField HeaderText="User" SortExpression="KERJABODY_USER">
                   <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("KERJABODY_USER") %>'></asp:Label>
                   </ItemTemplate>
                   <HeaderStyle Width="200px" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Tgl Kerja" SortExpression="KERJABODY_TANGGAL">
                   <ItemTemplate>
                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("KERJABODY_TANGGAL") %>'></asp:Label>
                   </ItemTemplate>
                   <HeaderStyle Width="150px" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Status" SortExpression="KERJABODY_STATUS">
                   <ItemTemplate>
                       <asp:Label ID="Label3" runat="server" Text='<%# Bind("statusval") %>'></asp:Label>
                   </ItemTemplate>
                   <HeaderStyle Width="5px" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Lokasi" SortExpression="KERJABODY_LOKASI">
                   <ItemTemplate>
                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("lokasimobil") %>'></asp:Label>
                   </ItemTemplate>
                   <HeaderStyle Width="5px" />
               </asp:TemplateField>
               <asp:TemplateField  HeaderText="Catatan" SortExpression="KERJABODY_CATATAN">
                   <ItemTemplate>
                       <asp:Label ID="Label5" runat="server" Text='<%# Bind("KERJABODY_CATATAN") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="" SortExpression="vendor" HeaderStyle-Width="5">
                     <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "jobcontrolformanedtpuri.aspx?qnowodel=" +  Eval("KERJABODY_NOWO") + "&&qtgldel=" + Eval("KERJABODY_TANGGAL") + "#popup2"%>' 
                             Target="_self" Text="<span class='glyphicon glyphicon-trash'></span> Delete" class="btn btn-danger btn-xs"></asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
               </Columns>
          <EditRowStyle BackColor="#999999" />
          <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
         </asp:GridView>
         </td></tr></table>
         <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:service128Connection %>" SelectCommand="SELECT [KERJABODY_NOWO], [KERJABODY_TANGGAL], [KERJABODY_USER], 
	case [KERJABODY_STATUS] 
		when 1 then 'DITERIMA' 
		when 2 then 'BONGKAR' 
		when 3 then 'KETOK' 
		when 4 then 'DEMPUL' 
		when 5 then 'CAT/OVEN' 
		when 6 then 'POLES' 
		when 7 then 'PEMASANGAN' 
		when 8 then 'FINISHING'  
		when 9 then 'ANTRIAN' 
		when 10 then 'PENILAIAN QC - OK'	
		when 11 then 'PENILAIAN QC - REWORK' 
		when 12 then 'PENILAIAN QC - HASIL REWORK -- GOOD' 
		when 13 then 'PENILAIAN QC - HASIL REWORK -- NOT GOOD' 
		when 14 then 'PENILAIAN QC - HASIL REWORK -- LAIN-LAIN' 
		when 15 then 'PENILAIAN QC - HASIL REWORK -- CATATAN'  
		when 16 then 'PENYERAHAN UNIT VENDOR KE QC' 
		when 17 then 'PENERIMAAN UNIT QC DARI VENDOR'  
		when 18 then 'PENYERAHAN UNIT KE SA BP'
		else 'UNCATEGORIZED' end AS statusval, 
	case [KERJABODY_LOKASI] 
		when 1 then 'lt. 1' 
		when 2 then 'lt. 2' 
		when 3 then 'lt. 3' 
		when 4 then 'lt.4' 
		when 5 then 'lt. 5' 
		when 6 then 'lt. 6' 
		when 7 then 'lt. 7' 
		when 8 then 'lt. 8' 
		when 9 then 'lt. 9' 
		else '' END AS lokasimobil, [KERJABODY_CATATAN] FROM [TEMP_KERJABODY] WHERE ([KERJABODY_NOWO] = @KERJABODY_NOWO) 
		ORDER BY KERJABODY_STATUS ASC">
             <SelectParameters>
                 <asp:QueryStringParameter Name="KERJABODY_NOWO" QueryStringField="qnowo" Type="String" />
             </SelectParameters>
         </asp:SqlDataSource>
        <asp:Button ID="BtnReportBPPuri" runat="server" CssClass="btn btn-danger" Text="Cetak Report" OnClick="BtnReportBPPuri_Click"  />
      <div id="addHistory" runat="server">
      <table style="width:100%;" id="inputHistory" runat="server">
          <tr>
          <td style="width:15%;">Catatan</td>
          <td>:</td>
          <td> <asp:TextBox ID="txtCatatan" runat="server" CssClass="form-control input-sm" placeholder="Catatan..." style="margin:5px;"></asp:TextBox></td></tr>
        <tr>
          <td>Lokasi Mobil Lantai</td>
          <td>:</td>
          <td> <asp:DropDownList ID="txtLokasi" runat="server" style="margin:5px;" CssClass="form-control input-sm">
              <asp:ListItem></asp:ListItem>
              <asp:ListItem Value="1">Lantai 1</asp:ListItem>
              <asp:ListItem Value="2">Lantai 2</asp:ListItem>
              <asp:ListItem Value="3">Lantai 3</asp:ListItem>
              <asp:ListItem Value="4">Lantai 4</asp:ListItem>
              <asp:ListItem Value="5">Lantai 5</asp:ListItem>
              <asp:ListItem Value="6">Lantai 6</asp:ListItem>
              <asp:ListItem Value="7">Lantai 7</asp:ListItem>
              <asp:ListItem Value="8">Lantai 8</asp:ListItem>
              <asp:ListItem Value="9">Lantai 9</asp:ListItem>
              </asp:DropDownList></td></tr>
          <tr>
          <td>Status</td>
          <td>:</td>
          <td> 
              <asp:DropDownList ID="txtStatus" runat="server" class="form-control input-sm" style="margin:5px;">
                  <asp:ListItem></asp:ListItem>
                  <asp:ListItem Value="01">DITERIMA</asp:ListItem>
                  <asp:ListItem Value="02">BONGKAR</asp:ListItem>
                  <asp:ListItem Value="03">KETOK</asp:ListItem>
                  <asp:ListItem Value="04">DEMPUL</asp:ListItem>
                  <asp:ListItem Value="05">CAT / OVEN</asp:ListItem>
                  <asp:ListItem Value="06">POLES</asp:ListItem>
                  <asp:ListItem Value="07">PEMASANGAN</asp:ListItem>
                  <asp:ListItem Value="08">FINISHING</asp:ListItem>
                  <asp:ListItem Value="09">ANTRIAN</asp:ListItem>
                  <asp:ListItem Value="10">PENILAIAN QC - OK</asp:ListItem>
                  <asp:ListItem Value="11">PENILAIAN QC - REWORK</asp:ListItem>
                  <asp:ListItem Value="12">PENILAIAN QC - HASIL REWORK -- GOOD</asp:ListItem>
                  <asp:ListItem Value="13">PENILAIAN QC - HASIL REWORK -- NOT GOOD</asp:ListItem>
                  <asp:ListItem Value="14">PENILAIAN QC - HASIL REWORK -- LAIN-LAIN</asp:ListItem>
                  <asp:ListItem Value="15">PENILAIAN QC - HASIL REWORK -- CATATAN</asp:ListItem>
                  <asp:ListItem Value="16">PENYERAHAN UNIT VENDOR KE QC</asp:ListItem>
                  <asp:ListItem Value="17">PENERIMAAN UNIT QC DARI VENDOR</asp:ListItem>
                  <asp:ListItem Value="18">PENILAIAN QC - OK - PENYERAHAN UNIT KE SA BP</asp:ListItem>
              </asp:DropDownList>
          </td></tr>
            <tr>
          <td>Foto</td>
          <td>:</td>
          <td>
              <asp:FileUpload ID="txtFoto" runat="server" style="margin:5px;" class="form-control input-sm" /></td>
      </tr>
          <tr>
          <td></td>
          <td></td>
          <td><asp:Button ID="btnProses" runat="server" Text="SUBMIT" CssClass="btn btn-success btn-sm" style="margin:5px;" OnClick="btnProses_Click" /> </td></tr>
    </table>
          </div>
     <center><asp:Button ID="btnUnclosing" runat="server" Text="Unclosing" CssClass="btn btn-danger btn-sm" style="margin:5px;" OnClick="btnUnclosing_Click" /></center>
    </div>
        
        <div id="popup2">
                 <div class="window2">
                      <div class="panel panel-primary" style="width:100%;margin:2px;">
   <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-trash"></span> Delete History<button class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</button></div>
  <div class="panel-body"> <center>
      <asp:label ID="lblPesanBisa" runat="server" text="Anda yakin ingin menghapus history ?"></asp:label>
       <asp:label ID="lblPesanGagal" runat="server" text="Anda tidak memiliki hak akses untuk menghapus history"></asp:label><br />
      <asp:Button ID="Button2" runat="server" Text="CONFIRM" CssClass="btn btn-success btn-sm" OnClick="Button2_Click"/>
      <asp:Button ID="Button3" runat="server" Text="CANCEL" class="btn btn-danger btn-sm" OnClick="Button3_Click"/></center>
      </div> </div> </div> </div>
    </form>
       <script type="text/javascript">
//<![CDATA[
// Menyisipkan markup tabir animasi
$(document.body).append('<div id="page-loader"></div>');
// Saat halaman terpicu untuk berpindah/keluar menuju halaman lain...
$(window).on("beforeunload", function() {
    // ... tampilkan tabir animasi dengan efek `.fadeIn()`
    $('#page-loader').fadeIn(1000).delay(8000).fadeOut(1000);
});
//]]>
</script>
</body>
</html>
