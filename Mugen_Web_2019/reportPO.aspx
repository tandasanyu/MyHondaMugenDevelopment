<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportPO.aspx.cs" Inherits="reportPO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laporan Purchase Order</title>
    <style>
        html body{ 
            margin:0px;padding:0px;
        }
        .head {
            background:#c0c0c0;
        }
    </style>
    <script>
        function myPrint() {
            window.print();
        }
    </script>

   
    <script type="text/javascript" src="assets/DataTables/media/js/jquery.js"></script>
	<script type="text/javascript" src="assets/DataTables/media/js/jquery.dataTables.js"></script>

	<link rel="stylesheet" type="text/css" href="assets/css/bootstrap.css" />
	<link rel="stylesheet" type="text/css" href="assets/DataTables/media/css/jquery.dataTables.css" />
	<link rel="stylesheet" type="text/css" href="assets/DataTables/media/css/dataTables.bootstrap.css" />
    <script src="js/bootstrap.min.js"></script>
  <script type="text/javascript">
	    $(document).ready(function(){
	        $('.data').DataTable();
	    });
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
                    <a href="tes.aspx" class="btn btn-danger btn-sm"><i class="glyphicon glyphicon-ban-circle"></i> Tutup Laporan</a>
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
 
        <asp:SqlDataSource ID="SqlDataSTaff" runat="server"
	        ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1  %>"
		    SelectCommand="SELECT [nobody],[nopurchaseorder], [namaitem], [userfmb], [vendor], [jumlahitem], [hargaitem], [pemohonfmb], [nmdivisi], [tglpemohonfmb], [nofmbhead],  [jumlahitem] * [hargaitem] AS total, case [kelompok] when '01' then 'Pengadaan Baru' when '02' then 'Penggantian' when '03' then 'Perbaikan' when '04' then 'Uji Coba' else '' end AS kelompokisi, [disetujuifmb], convert(varchar, tgldisetujuifmb,106) as tgldisetujuifmb, [mengetahuifmb], [tglmengetahuifmb],  [approveheadpurc], convert(varchar, tglapproveheadpurc,106) as tglapproveheadpurc, [disetujui2fmb], convert(varchar, tgldisetujui2fmb, 106) AS tgldisetujui2fmb FROM [fmbbody] INNER JOIN fmbhead ON fmbbody.nobody = fmbhead.nofmbhead INNER JOIN tb_user ON fmbhead.pemohonfmb = tb_user.username INNER JOIN divisi ON tb_user.kddivisi = divisi.kddivisi WHERE (kdcabang = @cab) AND (fmbhead.tglpemohonfmb between @tawl AND @takr)  AND fmbbody.nopurchaseorder<>'' "
	        ProviderName="<%$ ConnectionStrings:setiawanConnectionString1.ProviderName %>">
	        <SelectParameters>
			    <asp:QueryStringParameter Name="tawl" QueryStringField="tawl" Type="String" />
                <asp:QueryStringParameter Name="takr" QueryStringField="takr" Type="String" />
                <asp:QueryStringParameter Name="cab" QueryStringField="cab" Type="String" />
		    </SelectParameters>
	    </asp:SqlDataSource>                                     
	    <asp:ListView ID="LvDetailStaff" runat="server" DataSourceID="SqlDataSTaff" DataKeyNames ="nofmbhead" enableviewstate="false" >
	        <LayoutTemplate>
		        <table id="table-a" class="table table-striped table-bordered data" align="left">
		            <thead style="background-color:#5D7B9D">
			            <th style="text-align:center; color:white">No</th>
					    <th style="text-align:center; color:white" class="col-md-2">Pemohon</th>
					    <th style="text-align:center; color:white" class="col-md-2">No PO</th>
                        <th style="text-align:center; color:white" class="col-md-2">Nama Item</th>
					    <th style="text-align:center; color:white" class="col-md-2">Vendor</th>
                        <th style="text-align:center; color:white">Quantity</th>
                        <th style="text-align:center; color:white">Harga</th>
                        <th style="text-align:center; color:white">Total</th>
                        <th style="text-align:center; color:white" class="col-md-2">Deskripsi</th>
                        <th style="text-align:center; color:white">Head Approval</th>
                        <th style="text-align:center; color:white">Head Purchase</th>
                        <th style="text-align:center; color:white">Vice Precident (>2jt)</th>
			        </thead>
			        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
			    </table>
            </LayoutTemplate>
				
	        <ItemTemplate>
			    <tr>
				    <td style="text-align:center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
				    <td><p class="small"><u><asp:Label ID="Label2" runat="server" Style="font-weight:bold;color:blue;" Text='<%#Eval("pemohonfmb") %>'></asp:Label></u> <i>(<asp:Label ID="Label7" runat="server" Style="font-weight:bold;color:#333;" Text='<%#Eval("nmdivisi") %>'></asp:Label>)</i><br />
                              <i><asp:Label ID="Label1" runat="server" Style="color:#666;"  Text='<%#Eval("tglpemohonfmb") %>'></asp:Label></i></p>
				    </td>
				    <td><p class="small"><%#Eval("nopurchaseorder")%></p></td>
                    <td><p class="small"><%#Eval("namaitem")%></p></td>
                     <td><p class="small"><%#Eval("vendor")%></p></td>
                     <td><p class="small"><%#Eval("jumlahitem")%></p></td>
                     <td><p class="small"><%#Eval("hargaitem")%></p></td>
                     <td><p class="small"><%#Eval("total")%></p></td>
                     <td><p class="small"><%#Eval("kelompokisi")%></p></td>
                    <td><p class="small"><u><b><%#Eval("disetujuifmb") %></b></u> <br />
                        <%#Eval("tgldisetujuifmb") %></p>
				    </td>
                    <td><p class="small"><u><b><%#Eval("approveheadpurc") %> </b></u><br />
                        <%#Eval("tglapproveheadpurc") %></p>
				    </td>
                    <td><p class="small"><u><b><%#Eval("disetujui2fmb") %></b></u> <br />
                        <%#Eval("tgldisetujui2fmb") %></p>
				    </td>
	            </tr>
		    </ItemTemplate>
		    <EmptyDataTemplate>Data Karyawan Tidak diketemukan</EmptyDataTemplate> 
		    <EmptyItemTemplate>Data Karyawan Tidak diketemukan</EmptyItemTemplate>              
	    </asp:ListView>
    </div>
    <div>
    
    </div>
    </form>
</body>
</html>