<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportkeluhan.aspx.cs" Inherits="reportkeluhan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laporan keluhan IT/GA Honda Mugen</title>
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
        <asp:Label ID="Label29" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:0.8em;"></asp:Label>            
 </div><!-- div baris atas kiri -->
             <div class="row" style="text-align:right;">
     <div class="col-md-12" style="position:relative;bottom:15px;">
         <a onclick="myPrint()" class="btn btn-primary btn-sm"><i class="glyphicon glyphicon-print"></i> Cetak Laporan</a>
         <a href="tes.aspx" class="btn btn-danger btn-sm"><i class="glyphicon glyphicon-ban-circle"></i> Tutup Laporan</a>
     </div>
 </div>
             </div><!-- div baris atas -->
              


  <table style="width:100%;margin:5px;font-family:Verdana;font-size:8pt;border-bottom:2px solid #ddd;"  class="table table-striped" >
      <tr>
          <th class="info" colspan="3"><center><span class="glyphicon glyphicon-info-sign"></span> Keluhan Hardware & Software</center></th>
      </tr>
      <tr>
          <td><span class="glyphicon glyphicon-home"></span> Departmen</td>
           <td>:</td>
           <td> <asp:Label ID="lblDep" runat="server" Text=""></asp:Label></td>
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
                      <asp:TemplateField HeaderText="Pengajuan" SortExpression="tglajukan"  >
                          <ItemTemplate>
                              <u><asp:Label ID="Label2" runat="server" Style="font-weight:bold;color:blue;" Text='<%# Bind("userpengaju") %>'></asp:Label></u> <i>(<asp:Label ID="Label7" runat="server" Style="font-weight:bold;color:#333;" Text='<%# Bind("nmdivisi") %>'></asp:Label>)</i><br />
                              <i><asp:Label ID="Label1" runat="server" Style="color:#666;"  Text='<%# Bind("tglajukan") %>'></asp:Label></i>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Masalah" SortExpression="masalah" HeaderStyle-Width="300">
                          <ItemTemplate>
                              <asp:Label ID="Label3" runat="server" Text='<%# Bind("masalah") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Deadline" SortExpression="deadline">
                          <ItemTemplate>
                              <asp:Label ID="Label4" runat="server" Text='<%# Bind("deadline") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Aktual" SortExpression="aktual">
                          <ItemTemplate>
                              <asp:Label ID="Label5" runat="server" Text='<%# Bind("aktual") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Hasil" SortExpression="resulthardsoft">
                          <ItemTemplate>
                              <asp:Label ID="Label6" runat="server" Text='<%# Bind("resulthardsoft") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Tgl & Waktu Selesai" SortExpression="selesai">
                          <ItemTemplate>
                              <asp:Label ID="Label9" runat="server" Text='<%# Bind("selesai") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tindakan" SortExpression="selesai" HeaderStyle-Width="300">
                          <ItemTemplate>
                              <asp:Label ID="Label9" runat="server" Text='<%# Bind("pesannote") %>'></asp:Label>
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
               <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [pesannote], [nmdivisi], [tglajukan], [userhardsoft], [masalah], convert(varchar, deadline, 106) AS deadline, convert(varchar, aktual, 106) AS aktual, [resulthardsoft], [userpengaju], [tujuandivisi], [selesai] FROM [formhardsoft] INNER JOIN tb_user ON formhardsoft.userhardsoft = tb_user.username INNER JOIN divisi ON tb_user.kddivisi = divisi.kddivisi INNER JOIN bodyhardsoft ON formhardsoft.idhardsoft = bodyhardsoft.idhardsoftbody WHERE (tujuandivisi = @dep) AND (cabangtujuan = @cab) AND (tglajukan between convert(DATETIME,@tawl ,101)  AND convert(DATETIME,@takr,101))">
                   <SelectParameters> 
                  <asp:QueryStringParameter Name="dep" QueryStringField="dep" Type="String" />
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
<!-- SelectCommand="SELECT [pesannote], [nmdivisi], [tglajukan], [userhardsoft], [masalah], convert(varchar, deadline, 106) AS deadline, convert(varchar, aktual, 106) AS aktual, [resulthardsoft], [userpengaju], [tujuandivisi], [selesai] FROM [formhardsoft] INNER JOIN tb_user ON formhardsoft.userhardsoft = tb_user.username INNER JOIN divisi ON tb_user.kddivisi = divisi.kddivisi INNER JOIN bodyhardsoft ON formhardsoft.idhardsoft = bodyhardsoft.idhardsoftbody WHERE (tujuandivisi = @dep) AND (cabangtujuan = @cab) AND (tglajukan between convert(DATETIME,@tawl ,101)  AND convert(DATETIME,@takr,101)) -->

