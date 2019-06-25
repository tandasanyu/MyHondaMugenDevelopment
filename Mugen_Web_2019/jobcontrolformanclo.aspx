<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobcontrolformanclo.aspx.cs" Inherits="jobcontrolformanclo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>:: CLOSING</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
<style>
    h1 {font-size:12pt;padding:4px;margin:0px;font-weight:bold;}
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
opacity:0.7;
}
</style>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
</head>
<body>
    <div id="page-loader"></div>
    <form id="form1" runat="server">
    <div>
    
             
      <div id="hakAksesclosing" runat="server">
          <h1><span class="glyphicon glyphicon-floppy-saved"></span> Closing Job Control</h1>
        <table style="font-size:1.0em;width:100%;"><tr><td><center style="background:#c0c0c0;">Data Proses</center>
         <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource5" style="width:100%;float:left;">
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
             <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:serviceConnection %>" SelectCommand="SELECT WOHDR_TGWO, WOHDR_FNOPOL, WOHDR_FNMS, WOHDR_FNRK, WOHDR_FORG, WOHDR_KDTAGIH, WOHDR_SA, WOHDR_NO FROM TRXN_WOHDR WHERE (WOHDR_NO = @WOHDR_FNOPOL2)">
                 <SelectParameters>
                     <asp:QueryStringParameter Name="WOHDR_FNOPOL2" QueryStringField="qnowo2" Type="String" />
                 </SelectParameters>
            </asp:SqlDataSource>
      <table style="font-size:1.0em;width:100%;"><tr><td><center style="background:#c0c0c0;">Daftar Keluhan</center>
            <asp:GridView ID="GridView4" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource6" EnableModelValidation="True" style="width:100%;float:left;font-family:Verdana;font-size:0.8em;" class="table table-striped"  PageSize="100" CellPadding="4" ForeColor="#333333" GridLines="None">
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
             <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:serviceConnection %>" SelectCommand="SELECT WOKELUH_NOWO, WOKELUH_KELUH FROM TRXN_WOKELUH INNER JOIN TRXN_WOHDR ON TRXN_WOKELUH.WOKELUH_NOWO = TRXN_WOHDR.WOHDR_NO WHERE (WOHDR_NO = @qkey2) ORDER BY WOKELUH_KELUH">
                 <SelectParameters>
                     <asp:QueryStringParameter Name="qkey2" QueryStringField="qnowo2" />
                 </SelectParameters>
            </asp:SqlDataSource>
           </td></tr></table>
          <div id="spoiler">
<div><input style="font-size: 11px; padding: 2px;" onclick="if (this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display != '') { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = ''; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = 'none'; this.innerText = ''; this.value = 'Sembunyikan'; } else { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = 'none'; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = ''; this.innerText = ''; this.value = 'Tampilkan'; }" name="button" type="button" value="Buka Gambar Terakhir" /></div>
<div id="show" style="border: 1px solid white; display: none; margin: 5px; padding: 2px; width: 98%;">
    <asp:Image ID="Image2" runat="server"  Style="width:600px;height:400px;"/>
</div><div id="hide"></div></div>
        <table style="font-size:0.85em;float:left;width:100%;"><tr><td><center style="background:#c0c0c0;">History Pengerjaan                                                            </center>
      <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource7" EnableModelValidation="True" class="table table-striped" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
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
               <asp:TemplateField HeaderText="Catatan" SortExpression="KERJABODY_CATATAN">
                   <ItemTemplate>
                       <asp:Label ID="Label5" runat="server" Text='<%# Bind("KERJABODY_CATATAN") %>'></asp:Label>
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
         <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:serviceConnection %>" SelectCommand="SELECT [KERJABODY_NOWO], [KERJABODY_TANGGAL], [KERJABODY_USER], case [KERJABODY_STATUS] when 1 then 'DISERAHKAN SA KE VENDOR' when 2 then 'DITERIMA' when 3 then 'BONGKAR' when 4 then 'KETOK' when 5 then 'DEMPUL' when 6 then 'CAT/OVEN' when 7 then 'POLES' when 8 then 'PEMASANGAN' when 9 then 'FINISHING' when 10 then 'PENILAIAN QC - OK' when 11 then 'PENILAIAN QC - REWORK' when 12 then 'PENILAIAN QC - HASIL REWORK – GOOD/NOT GOOD/LAIN2' when 13 then 'JIKA HASIL REWORK LAIN2, CATATAN DARI QC' when 14 then 'PENYERAHAN UNIT DARI VENDOR KE QC' when 15 then 'PENERIMAAN UNIT QC DARI VENDOR' when 16 then 'PENYERAHAN UNIT QC KE SA BP'  else 'UNCATEGORIZED' end AS statusval, case [KERJABODY_LOKASI] when 1 then 'lt. 1' when 2 then 'lt. 2' when 3 then 'lt. 3' when 4 then 'lt.4' when 5 then 'lt. 5' when 6 then 'lt. 6' when 7 then 'lt. 7' when 8 then 'lt. 8' when 9 then 'lt. 9' else '' END AS lokasimobil, [KERJABODY_CATATAN] FROM [TEMP_KERJABODY] WHERE ([KERJABODY_NOWO] = @KERJABODY_NOWO2) ORDER BY KERJABODY_STATUS ASC">
             <SelectParameters>
                 <asp:QueryStringParameter Name="KERJABODY_NOWO2" QueryStringField="qnowo2" Type="String" />
             </SelectParameters>
         </asp:SqlDataSource>
      <center><asp:Button ID="btnClosing" runat="server" Text="Closing" CssClass="btn btn-success btn-sm" OnClick="btnClosing_Click"/></center>
      </div>
      <div id="hakAksesClosingTolak" runat="server">
          <asp:label runat="server" text="Anda tidak memiliki Hak Akses untuk melakukan Closing"></asp:label>
      </div>
  </div>
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
