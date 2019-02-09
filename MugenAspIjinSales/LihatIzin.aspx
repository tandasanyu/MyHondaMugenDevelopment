<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="LihatIzin.aspx.vb" Inherits="LihatIzin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Script -->
        <style>
                /***************/
        p.ex1 {
          border: 1px solid white; 
          padding-bottom: 300px;
          color:white;
        }
            </style>
<%--      <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.0/css/jquery.dataTables.css">
      <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.0/css/jquery.dataTables_themeroller.css">


        <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.1.min.js"></script>
        <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.0/jquery.dataTables.min.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#myTableBawahan').dataTable({ "sPaginationType": "full_numbers" });
            $("#<%= TxtTglCariIzin3.ClientID %>").datepicker({
	            //dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            changeYear: true,
	            numberOfMonths: 1
	            //beforeShowDay: DisableMonday
	           
	        });
	        $("#<%= TxtTglCariIzin4.ClientID %>").datepicker({
	            //dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            changeYear: true,
	            numberOfMonths: 1
	            //beforeShowDay: DisableMonday
	           
	        });
        });
    </script>
    <div class="container">
        <asp:MultiView ID="MultiViewLihatIzin" runat="server" ActiveViewIndex="0">
            <asp:View ID="View0" runat="server"><!-- View Table List Izin -->
                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Table Data List Izin Sales</h3>
	            <br />
                <div runat="server" visible="true">
                        <table class="table table-borderless" align="left">
                            <tr>
                                <td class="col-md-2">
                                    <asp:Label ID="Label52" runat="server" Text="Masukan Tanggal Pencarian"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:TextBox ID="TxtTglCariIzin3" Visible="true" runat="server" class="form-control required" autocomplete="off"></asp:TextBox><br /></td>
                                <td class="col-md-2">
                                    <asp:Label ID="Label53" runat="server" Text="Sampai Dengan"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:TextBox ID="TxtTglCariIzin4" Visible="true" runat="server" class="form-control required" autocomplete="off"></asp:TextBox><br /></td>
                            </tr>

                            <tr>
                                <td class="col-md-2">
                                    <asp:Button ID="BtnCariLaporanIzin" runat="server" Text="Cari Data" class="btn btn-primary"/></td>
                            </tr></table>   </div>

                        <asp:SqlDataSource ID="SqlDataSourceSales" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                            SelectCommand="SELECT DATA_IZIN_BODY_SALES.izin_id,DATA_IZIN_HEADER_SALES.izin_nik,
 DATA_IZIN_HEADER_SALES.izin_nama, DATA_IZIN_BODY_SALES.izin_jenis, 
 DATA_IZIN_DETAIL_SALES.izin_tgldetail, DATA_IZIN_BODY_SALES.izin_alasan
,data_izin_body_sales.izin_jenis, data_izin_body_sales.izin_tglpengajuan,
DATA_IZIN_DETAIL_SALES.izin_tgldetail,DATA_IZIN_BODY_SALES.izin_blnpengajuan,
 data_izin_body_sales.izin_thnpengajuan, DATA_IZIN_BODY_SALES.izin_status, 
 data_izin_header_sales.izin_nik_appvspv, data_izin_header_sales.izin_nik_appvmng,
data_izin_body_sales.izin_tglappvspv, data_izin_body_sales.izin_tglappvmng
FROM data_izin_header_sales  
INNER JOIN data_izin_body_sales  on data_izin_body_sales.izin_nik = DATA_IZIN_HEADER_SALES.izin_nik
INNER JOIN data_izin_detail_sales  on data_izin_detail_sales.izin_id= data_izin_body_sales.izin_id where ([izin_tgldetail] between ? and ?)"
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtTglCariIzin3" Name="izin_tgldetail" PropertyName="Text" Type="DateTime" />
                                <asp:ControlParameter ControlID="TxtTglCariIzin4" Name="izin_tgldetail" PropertyName="Text" Type="DateTime" />                                
                            </SelectParameters>
				        </asp:SqlDataSource> 
				        <asp:ListView ID="ListViewSales" runat="server" DataSourceID="SqlDataSourceSales"  DataKeyNames ="IZIN_ID" enableviewstate="false">
					        <LayoutTemplate>
                                <br />
                                <%--<input id="myInputBawahan"  type="text" placeholder="Ketik Nama yang akan di Cari!" class="form-control required" autocomplete="off">--%>
                                <br />  
                                <div id="table-wrapper">
                                  <div id="table-scroll">
						            <table id="myTableBawahan" class="table table-bordered striped data" align="left">
                                <thead style="background-color:#4877CF">
								        <th style="text-align:center; color:white">ID Izin</th>
								        <th style="text-align:center; color:white">NIK</th>
                                        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Jenis Izin</th>
                                        <th style="text-align:center; color:white">Alasan </th>
                                        <th style="text-align:center; color:white">Tgl Pengajuan</th>
                                        <th style="text-align:center; color:white">Tgl Detail Pengajuan</th>    
                                        <th style="text-align:center; color:white">Bln Pengajuan</th>
                                        <th style="text-align:center; color:white">Tahun Pengajuan</th>
                                        <th style="text-align:center; color:white">NIK Approval Atasan1</th>
                                        <th style="text-align:center; color:white">NIK Approval Atasan2</th>
                                        <th style="text-align:center; color:white">Tgl Approval Atasan1</th>
                                        <th style="text-align:center; color:white">Tgl Approval Atasan2</th>
                                        <th style="text-align:center; color:white">Status Izin</th>                                           
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table></div>	</div>	
			
					        </LayoutTemplate>
				
					        <ItemTemplate>
						        <tr>                                   
							        <td style="text-align:center"><%# Eval("IZIN_ID") %></td>
							        <td><%#Eval("IZIN_NIK")%></td>
                                    <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>
                                    <td><%#Eval("IZIN_ALASAN")%></td>
                                    <td><%#Eval("IZIN_TGLPENGAJUAN", "{0:dd/MM/yyyy}")%></td>
                                    <td><%#Eval("IZIN_TGLDETAIL", "{0:dd/MM/yyyy}")%></td>
                                    <td><%#Eval("IZIN_BLNPENGAJUAN")%></td>
                                    <td><%#Eval("IZIN_THNPENGAJUAN")%></td>
                                    <td><%#Eval("IZIN_NIK_APPVSPV")%></td>
                                    <td><%#Eval("IZIN_NIK_APPVMNG")%></td>
                                    <td><%#Eval("IZIN_TGLAPPVSPV")%></td>
                                    <td><%#Eval("IZIN_TGLAPPVMNG")%></td>
                                    <td><%#Eval("IZIN_STATUS")%></td>							       
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					        <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>              
				        </asp:ListView>
            </asp:View>
            <asp:View ID="View1" runat="server"><!-- View Detail -->
                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Table Data List Izin Sales</h3>
	            <br />
            </asp:View>
        </asp:MultiView>
        <p class="ex1">A paragraph with a 25 pixels bottom padding.</p>
    </div>
</asp:Content>

