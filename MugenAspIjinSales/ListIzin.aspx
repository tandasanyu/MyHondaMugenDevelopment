<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListIzin.aspx.vb" Inherits="ListIzin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Script Section -->
    <script>
        $(document).ready(function () {
            $('#tbBawahan').DataTable();
            $("#myInputBawahan").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#myTableBawahan tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
    </script>
    <style>
                /***************/
        p.ex1 {
          border: 1px solid white; 
          padding-bottom: 300px;
          color:white;
        }
       #table-wrapper {
          position:relative;

        }
        #table-scroll {
          height:300px;
          overflow:auto;  
          margin-top:20px;
        }
        #table-wrapper table {
          width:100%;
        
        }
        #table-wrapper table * {
          
          color:black;
         
        }
        #table-wrapper table thead th .text {
          position:absolute;   
          top:-20px;
          z-index:2;
          height:20px;
          width:35%;
          border:1px solid black;
        }
    </style>
    <!-- 2 View -->
    <div class="container">
        <div id="divCheckbox" >
        <asp:Label ID="LabelUsernameLogin" runat="server" Visible="false" Text="LabelUsernameLogin"  ForeColor="red"></asp:Label>
        <asp:Label ID="LabelUsernameLoginID" runat="server" Visible="false" Text="LabelUsernameLoginID"  ForeColor="Yellow"></asp:Label>
        <asp:Label ID="LabelNama" runat="server" Visible="false" Text="LabelNama"  ForeColor="green"></asp:Label></div>
        <asp:MultiView ID="MultiViewListIzin" runat="server" ActiveViewIndex="0">
        <asp:View ID="View0" runat="server"> <!-- VIEW STAFF -->
                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Table Data List Izin Sales</h3>
	            <br />
                    <div>
            <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath><br />
        </div>
                        <asp:SqlDataSource ID="SqlDataSourceSales" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                            SelectCommand="select * from data_izin_body_sales 
join data_izin_header_sales on data_izin_header_sales.izin_nik = data_izin_body_sales.izin_nik WHERE  ([izin_nama] = ?) order by IZIN_ID ASC "
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				            <SelectParameters>
                                <asp:ControlParameter ControlID="LabelNama" Name="izin_nama" PropertyName="Text" Type="String" />
                            </SelectParameters>
				        </asp:SqlDataSource> 
				        <asp:ListView ID="ListViewSales" runat="server" DataSourceID="SqlDataSourceSales"  DataKeyNames ="IZIN_ID" enableviewstate="false">
					        <LayoutTemplate>
                                <br />
                                <input id="myInputBawahan"  type="text" placeholder="Ketik Nama yang akan di Cari!" class="form-control required" autocomplete="off">
                                <br />  
                                <div id="table-wrapper">
                                  <div id="table-scroll">
						            <table id="myTableBawahan" class="table table-bordered striped data" align="left">
							        <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white">Id Izin</th> 
                                        <th style="text-align:center; color:white">NIK</th>                                      
								        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Jenis Izin</th>
								        <th style="text-align:center; color:white">Alasan Izin</th>
                                        <th style="text-align:center; color:white">Tgl Pengajuan</th>
                                        <th style="text-align:center; color:white">Persetujuan Atasan</th>
                                        <th style="text-align:center; color:white">Persetujuan Atasan dari Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Izin Status</th>
                                        <th style="text-align:center; color:white">Detail</th>
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table></div>	</div>	
			
					        </LayoutTemplate>
				
					        <ItemTemplate>
						        <tr> 
                                    <td><%#Eval("IZIN_ID")%></td>   
                                    <td><%#Eval("IZIN_NIK")%></td>                                                                
							        <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>   
                                    <td><%#Eval("IZIN_ALASAN")%></td> 
                                    <td><%#Eval("IZIN_TGLPENGAJUAN", "{0:dd/MM/yyyy}")%></td>
                                    <td>
                                        <p class="small"><%#Eval("IZIN_NIK_APPVSPV")%><br />
                                        <%#Eval("IZIN_TGLAPPVSPV")%></p>
                                    </td>    
                                    <td>
                                        <p class="small"><%#Eval("IZIN_NIK_APPVMNG")%><br />
                                        <%#Eval("IZIN_TGLAPPVMNG")%></p>
                                    </td> 
                                    <td><%#Eval("IZIN_STATUS")%></td>                                
							        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/detail.png" width="50px" height="50px" /></asp:LinkButton></td>
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					        <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>              
				        </asp:ListView>
        </asp:View>
        <asp:View ID="View1" runat="server"><!-- VIEW BAWAHAN -->
                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Table Data List Izin Bawahan</h3>
	            <br />
                                <div>
            <asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath><br />
        </div>
                        <asp:SqlDataSource ID="SqlDataSourceBawahan" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                            SelectCommand="select * from data_izin_body_sales 
join data_izin_header_sales on data_izin_header_sales.izin_nik = data_izin_body_sales.izin_nik WHERE (([izin_nik_appvmng] = ?) ) or (([izin_nik_appvspv] = ?) ) order by IZIN_ID ASC"
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				            <SelectParameters>
                                <asp:ControlParameter ControlID="LabelUsernameLogin" Name="izin_nik_appvmng" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="LabelUsernameLogin" Name="izin_nik_appspv" PropertyName="Text" Type="String" />
                            </SelectParameters>
				        </asp:SqlDataSource>   
            <!-- ListView Detali Bawahan  form Izin Sales-->
				        <asp:ListView ID="LvDetailBawahan" runat="server" DataSourceID="SqlDataSourceBawahan"  DataKeyNames ="IZIN_ID" enableviewstate="false">
					        <LayoutTemplate>
                                <br />
                                <input id="myInputBawahan"  type="text" placeholder="Ketik Nama yang akan di Cari!" class="form-control required" autocomplete="off">
                                <br />  
                                <div id="table-wrapper">
                                  <div id="table-scroll">
						            <table id="myTableBawahan" class="table table-bordered striped data" align="left">
							        <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white">Id Izin</th> 
                                        <th style="text-align:center; color:white">NIK</th>                                      
								        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Jenis Izin</th>
								        <th style="text-align:center; color:white">Alasan Izin</th>
                                        <th style="text-align:center; color:white">Tgl Pengajuan</th>
                                        <th style="text-align:center; color:white">Persetujuan Atasan</th>
                                        <th style="text-align:center; color:white">Persetujuan Atasan dari Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Izin Status</th>
                                        <th style="text-align:center; color:white">Detail</th>
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table></div>	</div>	
			
					        </LayoutTemplate>
				
					        <ItemTemplate>
						        <tr> 
                                    <td><%#Eval("IZIN_ID")%></td>   
                                    <td><%#Eval("IZIN_NIK")%></td>                                                                
							        <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>   
                                    <td><%#Eval("IZIN_ALASAN")%></td> 
                                    <td><%#Eval("IZIN_TGLPENGAJUAN", "{0:dd/MM/yyyy}")%></td>
                                    <td>
                                        <p class="small"><%#Eval("IZIN_NIK_APPVSPV")%><br />
                                        <%#Eval("IZIN_TGLAPPVSPV")%></p>
                                    </td>    
                                    <td>
                                        <p class="small"><%#Eval("IZIN_NIK_APPVMNG")%><br />
                                        <%#Eval("IZIN_TGLAPPVMNG")%></p>
                                    </td> 
                                    <td><%#Eval("IZIN_STATUS")%></td>                                
							        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/detail.png" width="50px" height="50px" /></asp:LinkButton></td>
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					        <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>              
				        </asp:ListView>
        </asp:View>
        <asp:View ID="View2" runat="server"><!-- VIEW SPV -->
                                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Table Data List Izin Bawahan SPV</h3>
	            <br />
                                <div>
            <asp:SiteMapPath ID="SiteMapPath3" runat="server"></asp:SiteMapPath><br />
        </div>
                        <asp:SqlDataSource ID="SqlDataSourceBawahanSPV" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                            SelectCommand="select * from data_izin_body_sales 
join data_izin_header_sales on data_izin_header_sales.izin_nik = data_izin_body_sales.izin_nik WHERE  ([izin_nik_appvspv] = ?) order by IZIN_ID ASC"
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				            <SelectParameters>
                                <asp:ControlParameter ControlID="LabelUsernameLoginID" Name="izin_nik_appvspv" PropertyName="Text" Type="String" />
                            </SelectParameters>
				        </asp:SqlDataSource>   
            <!-- ListView Detali Bawahan  form Izin Sales-->
				        <asp:ListView ID="ListViewDetailBawahanSPV" runat="server" DataSourceID="SqlDataSourceBawahanSPV"  DataKeyNames ="IZIN_ID" enableviewstate="false">
					        <LayoutTemplate>
                                <br />
                                <input id="myInputBawahan"  type="text" placeholder="Ketik Nama yang akan di Cari!" class="form-control required" autocomplete="off">
                                <br />  
                                <div id="table-wrapper">
                                  <div id="table-scroll">
						            <table id="myTableBawahan" class="table table-bordered striped data" align="left">
							        <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white">Id Izin</th> 
                                        <th style="text-align:center; color:white">NIK</th>                                      
								        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Jenis Izin</th>
								        <th style="text-align:center; color:white">Alasan Izin</th>
                                        <th style="text-align:center; color:white">Tgl Pengajuan</th>
                                        <th style="text-align:center; color:white">Persetujuan Atasan</th>
                                        <th style="text-align:center; color:white">Persetujuan Atasan dari Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Izin Status</th>
                                        <th style="text-align:center; color:white">Detail</th>
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table></div>	</div>	
			
					        </LayoutTemplate>
				
					        <ItemTemplate>
						        <tr> 
                                    <td><%#Eval("IZIN_ID")%></td>   
                                    <td><%#Eval("IZIN_NIK")%></td>                                                                
							        <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>   
                                    <td><%#Eval("IZIN_ALASAN")%></td> 
                                    <td><%#Eval("IZIN_TGLPENGAJUAN", "{0:dd/MM/yyyy}")%></td>
                                    <td>
                                        <p class="small"><%#Eval("IZIN_NIK_APPVSPV")%><br />
                                        <%#Eval("IZIN_TGLAPPVSPV")%></p>
                                    </td>    
                                    <td>
                                        <p class="small"><%#Eval("IZIN_NIK_APPVMNG")%><br />
                                        <%#Eval("IZIN_TGLAPPVMNG")%></p>
                                    </td> 
                                    <td><%#Eval("IZIN_STATUS")%></td>                                
							        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/detail.png" width="50px" height="50px" /></asp:LinkButton></td>
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					        <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>              
				        </asp:ListView>
            </asp:View>
        <asp:View ID="View3" runat="server"><!--detail pengajuan izin sales -->
            <br /><h3 style="font-family:Blunter;">
            <span class="glyphicon glyphicon-user"></span>
                <asp:Label ID="LabelJudul" runat="server" Text="Data Detail Izin Sales"></asp:Label>---
                <asp:Label ID="LabelUserLogin" runat="server" Text="Label"></asp:Label>
                  </h3><br />
            <table class="table table-borderless" align="left">
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label23" runat="server" Text="Id Izin"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailIdIzinSales" Visible="true" runat="server" class="form-control required" ReadOnly="true"></asp:TextBox></td><td></td>
                    </tr>
                     <tr>
                        <td class="col-md-2">Tanggal Pengajuan </td>
                        <td class="col-md-4">
                            <asp:TextBox ReadOnly="true" ID="TxtDetailTglPengajuanIzin" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label5" runat="server" Text="NIK"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ReadOnly="true" ID="TxtDetailNik" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label22" runat="server" Text="Nama"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ReadOnly="true" ID="TxtDetailNama" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label24" runat="server" Text="Jenis Izin"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ReadOnly="true" ID="txtDetailJenisIzin" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">Jumlah Pengajuan</td>
                        <td class="col-md-4">
                            <asp:TextBox ReadOnly="true" ID="TxtDetailJmlPengajuan" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">List Tanggal yang di Ajukan </td>
                        <td class="col-md-4">
                            <table>
                                <tr>

                                    <td >
                                       <asp:Label ID="Label57" runat="server" Text="Memotong Cuti Tahunan" Font-Bold ="true"></asp:Label><br />
                                        <asp:GridView ID="GridViewTglSales"  runat="server" rowstyle-Height="20px" BorderColor="White" EnableModelValidation="True" HorizontalAlign="Center" ShowHeader="False" Height="100px" Width="100px">
                          
                                            <RowStyle Height="20px" />
                          
                                        </asp:GridView>
                                        <asp:Label ID="TglAjuSales" runat="server" Text="Label" Visible="false"></asp:Label><br />
                                        <br />
                                    </td>

                                    <td>
                                        <asp:Label ID="Label58" runat="server" Text="Memotong Cuti Pending" Font-Bold ="true"></asp:Label><br />
                                        <asp:GridView ID="GridViewTglPending" runat="server" rowstyle-Height="20px" BorderColor="White" EnableModelValidation="True" HorizontalAlign="Center" ShowHeader="False" Height="100px" Width="100px">

                                            <RowStyle Height="20px" />

                                        </asp:GridView><br />
                                    </td>
                                </tr>
                            </table>                                                    
                        </td><td></td>                    
                    </tr>
                     <tr>
                        <td class="col-md-2">
                            <asp:Label ID="LabelAlasanPengajuan" runat="server" Text="Alasan Pengajuan"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="AlasanCuti" Visible="false" runat="server" class="form-control required"></asp:TextBox>
                            <asp:TextBox ReadOnly="true" ID="TxtDetailAlasanPengajuan" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                     <tr>
                        <td class="col-md-2">
                            <asp:Label ID="LabelDetailAlasanPengajuan2" runat="server" Text="Detail Alasan Pengajuan"></asp:Label></td>
                        <td class="col-md-4">                            
                            <asp:TextBox ID="TxtDetailAlasanPengajuan2" ReadOnly="true" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                     <tr>
                        <td class="col-md-2">Status Pengajuan</td>
                        <td class="col-md-4">                            
                            <asp:TextBox ReadOnly="true" ID="TxtDetailStatusPengajuan" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                     <tr>
                        <td class="col-md-2">Tgl Deadline Approval</td>
                        <td class="col-md-4">
                            <asp:TextBox ReadOnly="true" ID="TxtDetailDeadline" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                     <tr>
                        <td class="col-md-2"><asp:Label ID="LabelJamPengajuan" runat="server" Text="Izin Jam yang Di Ajukan"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailJamPengajuan" ReadOnly="true" Visible="true" runat="server" class="form-control required" autocomplete="off"></asp:TextBox></td><td></td>
                    </tr>
                     <tr>
                        <td class="col-md-2">Alasan Pembatalan / Persetujuan</td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailAlasanBtlStj" Visible="true" runat="server" class="form-control required" autocomplete="off"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="LabelBuktiSuratSakit" runat="server" Text="Download File Bukti " Visible="false"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:Button ID="BtnDownloadDetailFile"  runat="server" Text="Download File" class="btn btn-primary"/>
                            <asp:TextBox ID="TxtFileName" runat="server" Visible="false"></asp:TextBox>
                        </td><td></td>                        
                    </tr>
                    <tr>
                        <td class="col-md-2"></td>
                        <td class="col-md-4">               
                            <asp:Button ID="BtnSaveDetaildanApproval" visible="False" runat="server" Text="Approve Data" class="btn btn-success" />
                            <asp:Button ID="BtnDeclineDetaildanApproval" Visible="False" runat="server" Text="Decline Data" class="btn btn-danger"/>
                            <asp:Button ID="BtnBackDetaildanApproval" Visible="True" runat="server" Text="Kembali" class="btn btn-primary"/><br />
                            
                        </td><td></td>
                    </tr>
            </table>
        </asp:View>
    </asp:MultiView>
            <p class="ex1">A paragraph with a 25 pixels bottom padding.</p>
    </div>   
</asp:Content>

