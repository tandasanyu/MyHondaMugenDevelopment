<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportPO.aspx.cs" Inherits="reportPO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laporan Purchase Order</title>
    <style>html body{ margin:0px;padding:0px;}
        .head {background:#c0c0c0;
        }
    </style>
    <script>
function myPrint() {
    window.print();
}
</script>
     <link href="css/bootstrap.min.css" rel="stylesheet" />
     <link href="css/datepicker.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
          <div class="header" style="width:100%;margin:0 auto;height:auto;">

        <div class="atas" style="width:97%;margin:5px auto;height:100px;position:relative;border-bottom:2px solid #c0c0c0;">
        <div class="kirih" style="float:left;height:80px;font-size:10pt;font-family:Verdana;position:relative;top:0px;width:9%;">
         <asp:Image ID="Image3" runat="server" ImageUrl="~/img/hlogo.png" style="width:100%;height:75px;"/>
        </div>
        <div class="kirih" style="left:1%;float:left;height:80px;font-size:0.85em;font-family:Verdana;position:relative;top:0px;width:56%;">
        <asp:Label ID="Label24" runat="server" Text="Honda Mugen" style="font-weight:bold;"></asp:Label><br />    
        <asp:Label ID="Label25" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:0.8em;"></asp:Label><br />    
        <asp:Label ID="Label26" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:0.8em;"></asp:Label><br />      
        <asp:Label ID="Label27" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:0.8em;"></asp:Label><br />      
        <asp:Label ID="Label28" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:0.8em;"></asp:Label><br />      
        <asp:Label ID="Label29" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:0.8em;"></asp:Label><br />         
 </div><!-- div baris atas kiri -->
             <div class="row" style="text-align:right;">
     <div class="col-md-12" style="position:relative;bottom:15px;">
         <a onclick="myPrint()" class="btn btn-primary btn-sm"><i class="glyphicon glyphicon-print"></i> Cetak Laporan</a>
         <a href="tesPO.aspx" class="btn btn-danger btn-sm"><i class="glyphicon glyphicon-ban-circle"></i> Tutup Laporan</a>
     </div>
 </div>
             </div><!-- div baris atas -->
              


  <table style="width:100%;margin:5px;font-family:Verdana;font-size:8pt;border-bottom:2px solid #ddd;"  class="table table-striped" >
      <tr>
          <th class="info" colspan="3"><center><span class="glyphicon glyphicon-info-sign"></span> Laporan Purchase Order</center></th>
      </tr>
     
       <tr>
          <td><span class="glyphicon glyphicon-calendar"></span> Periode</td>
           <td>:</td>
           <td><asp:Label ID="lblTawl" runat="server" Text=""></asp:Label> - <asp:Label ID="lblTakr" runat="server" Text=""></asp:Label></td>
      </tr>
       <tr>
          <td><span class="glyphicon glyphicon-random"></span> Cabang</td>
           <td>:</td>
           <td><asp:Label ID="lblCab" runat="server" Text=""></asp:Label></td>
      </tr>
  </table>
 
              <asp:GridView style="width:100%;margin:5px;font-family:Verdana;font-size:8pt;border-bottom:2px solid #ddd;" ID="GridView1" runat="server" class="table table-bordered table-striped" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableModelValidation="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                  <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                  <Columns>
                      <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
                         <itemtemplate>
                               <%# Container.DataItemIndex + 1 %>
                         </ItemTemplate>
                     </asp:TemplateField>
                      <asp:TemplateField HeaderText="Pemohon" SortExpression="pemohon"   HeaderStyle-Width="120">
                          <ItemTemplate>
                              <u><asp:Label ID="Label2" runat="server" Style="font-weight:bold;color:blue;" Text='<%# Bind("userfmb") %>'></asp:Label></u> <i>(<asp:Label ID="Label7" runat="server" Style="font-weight:bold;color:#333;" Text='<%# Bind("nmdivisi") %>'></asp:Label>)</i><br />
                              <i><asp:Label ID="Label1" runat="server" Style="color:#666;"  Text='<%# Bind("tglpemohonfmb") %>'></asp:Label></i>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="No PO" SortExpression="noBukti" HeaderStyle-Width="150">
                          <ItemTemplate>
                              <asp:Label ID="Label3" runat="server" Text='<%# Bind("nopurchaseorder") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Nama Item" SortExpression="namaItem">
                          <ItemTemplate>
                              <asp:Label ID="Label4" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                          <asp:TemplateField HeaderText="Vendor" SortExpression="vendor"  HeaderStyle-Width="120">
                          <ItemTemplate>
                              <asp:Label ID="Label4" runat="server" Text='<%# Bind("vendor") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Quantity" SortExpression="qty">
                          <ItemTemplate>
                              <asp:Label ID="Label6" runat="server" Text='<%# Bind("jumlahitem") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Harga" SortExpression="harga">
                          <ItemTemplate>
                              <asp:Label ID="Label9" runat="server" Text='<%# Bind("hargaitem") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Total" SortExpression="vendor">
                          <ItemTemplate>
                              <asp:Label ID="Label4" runat="server" Text='<%# Bind("total") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                     
                        <asp:TemplateField HeaderText="Deskripsi" SortExpression="deskripsi"  HeaderStyle-Width="120">
                          <ItemTemplate>
                              <asp:Label ID="Label5" runat="server" Text='<%# Bind("kelompokisi") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                         <asp:TemplateField HeaderText="Head Approval" SortExpression="disetujuifmb"  HeaderStyle-Width="120">
            <ItemTemplate>
                <u style="font-weight:bold;"><asp:Label ID="Label4" runat="server" Text='<%# Bind("disetujuifmb") %>'></asp:Label></u><br />
                <asp:Label ID="Label29" runat="server" Text='<%# Bind("tgldisetujuifmb") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="Head Purchase" SortExpression="approveheadpurc"  HeaderStyle-Width="120">
            <ItemTemplate>
                <u style="font-weight:bold;"><asp:Label ID="Label8" runat="server" Text='<%# Bind("approveheadpurc") %>'></asp:Label></u><br />
                  <asp:Label ID="Label5" runat="server" Text='<%# Bind("tglapproveheadpurc") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vice President (>2jt)" SortExpression="disetujui2fmb"  HeaderStyle-Width="120">
            <ItemTemplate>
                 <u style="font-weight:bold;"><asp:Label ID="Label9" runat="server" Text='<%# Bind("disetujui2fmb") %>'></asp:Label></u><br />
                 <asp:Label ID="Label33" runat="server" Text='<%# Bind("tgldisetujui2fmb") %>'></asp:Label>
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
                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [nobody],[nopurchaseorder], [namaitem], [userfmb], [vendor], [jumlahitem], [hargaitem], [pemohonfmb], [nmdivisi], [tglpemohonfmb], [nofmbhead],  [jumlahitem] * [hargaitem] AS total, case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [disetujuifmb], convert(varchar, tgldisetujuifmb,106) as tgldisetujuifmb, [mengetahuifmb], [tglmengetahuifmb],  [approveheadpurc], convert(varchar, tglapproveheadpurc,106) as tglapproveheadpurc, [disetujui2fmb], convert(varchar, tgldisetujui2fmb, 106) AS tgldisetujui2fmb FROM [fmbbody] INNER JOIN fmbhead ON fmbbody.nobody = fmbhead.nofmbhead INNER JOIN tb_user ON fmbhead.pemohonfmb = tb_user.username INNER JOIN divisi ON tb_user.kddivisi = divisi.kddivisi WHERE (kdcabang = @cab) AND (fmbhead.tglpemohonfmb between @tawl AND @takr)  AND fmbbody.nopurchaseorder<>'' ">
                   
                       <SelectParameters> 
                    
                  <asp:QueryStringParameter Name="tawl" QueryStringField="tawl" Type="String" />
                  <asp:QueryStringParameter Name="takr" QueryStringField="takr" Type="String" />
                  <asp:QueryStringParameter Name="cab" QueryStringField="cab" Type="String" />
                        </SelectParameters>
              </asp:SqlDataSource>
    </div>
    <div>
    
    </div>
    </form>
</body>
</html>
