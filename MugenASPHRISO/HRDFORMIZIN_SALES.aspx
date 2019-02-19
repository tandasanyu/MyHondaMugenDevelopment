<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HRDFORMIZIN_SALES.aspx.vb" Inherits="HRDFORMIZIN_SALES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <!-- JS -->
    <script type="text/javascript">
        function saldo_berlaku() {
            var value = document.getElementById('<%= DropDownListOperasiSaldoSales.ClientID %>').options[document.getElementById('<%= DropDownListOperasiSaldoSales.ClientID %>').selectedIndex].value;
            var selectedvalue = value;
            if (selectedvalue == "4" ) {
                $("#DeadlinePendingCuti").show();
            } else {
                $("#DeadlinePendingCuti").hide();
            }      
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#myTable112 [id*=CheckBox112All]").click(function () {
                if ($(this).is(":checked")) {
                    $("#myTable112 [id*=CheckBox112]").attr("checked", "checked");
                } else {
                    $("#myTable112 [id*=CheckBox112]").removeAttr("checked");
                }
            });
            $("#myTable128 [id*=CheckBox128All]").click(function () {
                if ($(this).is(":checked")) {
                    $("#myTable128 [id*=CheckBox128]").attr("checked", "checked");
                } else {
                    $("#myTable128 [id*=CheckBox128]").removeAttr("checked");
                }
            });
        });
    </script>
    <script type="text/javascript"> 
        //keep the data table script first before the table build
        $(document).ready(function () {
                    $('.data').DataTable();
                    $('.data2').DataTable();
                    $("#myInput112").on("keyup", function () {
                        var value = $(this).val().toLowerCase();
                        $("#myTable112 tr").filter(function () {
                            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                        });
                    });
                    $("#myInput128").on("keyup", function () {
                        var value = $(this).val().toLowerCase();
                        $("#myTable128 tr").filter(function () {
                            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                        });
                    });

        });
        </script>
    <script type="text/javascript">
        $(function () {
            var dateToday = new Date()
            function DisableMonday(date) {
                var day = date.getDay();
                // If day == 1 then it is MOnday
                if (day == 0) {
                    return [false];
                } else {
                    return [true];
                }
            }
            //TxtDeadlinePendingCuti
   	        $("#<%= TxtDeadlinePendingCuti.ClientID %>").datepicker({
	            //dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            changeYear: true,
	            numberOfMonths: 1,
	            beforeShowDay: DisableMonday	           
	        });
	        $("#<%= TxtTglCariIzin3.ClientID %>").datepicker({
	            //dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            changeYear: true,
	            numberOfMonths: 1,
	            beforeShowDay: DisableMonday
	        });
	        $("#<%= TxtTglCariIzin4.ClientID %>").datepicker({
	            //dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            changeYear: true,
	            numberOfMonths: 1,
	            beforeShowDay: DisableMonday
	        });
        });
    </script>
    <!-- CSS -->
    <style>
        .after-box {
          clear: left;
        }
       #myTable128 {
           font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
           border-collapse: collapse;
           width: 100%;
       }

       #myTable128 td, #myTable128 th {
           border: 1px solid Silver;
           padding: 8px;
       }

       #myTable128 tr:nth-child(even){background-color: #f2f2f2;}

       #myTable128 tr:hover {background-color: #ddd;}

       #myTable128 th {
          padding-top: 12px;
          padding-bottom: 12px;
          text-align: left;
          background-color: #4CAF50;
          color: white;
       }
       /*******/
       #myTable112 {
           font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
           border-collapse: collapse;
           width: 100%;
       }

       #myTable112 td, #myTable112 th {
           border: 1px solid Silver;
           padding: 8px;
       }

       #myTable112 tr:nth-child(even){background-color: #f2f2f2;}

       #myTable112 tr:hover {background-color: #ddd;}

       #myTable112 th {
          padding-top: 12px;
          padding-bottom: 12px;
          text-align: left;
          background-color: #4CAF50;
          color: white;
       }
       /***Table scroll*/
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
          background:white;
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
        .box-centerside {
          float: left;
          min-height: 200px;
          width: 1000px;
        }
        span.a {
          display: inline; /* the default for span */
          width: 100px;
          height: 100px;
          padding: 5px;       
            
        }
        p.ex1 {
          border: 1px solid white; 
          padding-bottom: 300px;
          color:white;
        }

    </style>
    <div class="container">
        <div style="margin-bottom:10px;margin-top:20px;margin-left:0px;" runat="server" id="BtnMaster"><!--100px-->
            <span class ="a;">
            <asp:Button ID="BtnOperasiSaldoMaster" runat="server" Text="Operasi Saldo Izin" class="btn btn-info"/></span>
            <span class="a;">
            <asp:Button ID="BtnPembatalanLaporanIzinMaster" runat="server" Text="Pembatalan dan Laporan Izin" class="btn btn-default"/></span>
            <span class="a;">
            <asp:Button ID="BtnCekSaldoSalesBerjalan" runat="server" Text="Cek Saldo Sales Berjalan" class="btn btn-default"/></span>
            <span class="a;">
            <asp:Button ID="BtnKembali" runat="server" Text="Kembali" class="btn btn-primary"/></span>
        </div>
        <div style="margin-bottom:10px;margin-top:20px;margin-left:0px;" runat="server" id="btnoperasiSaldo"><!--100px-->
            <span class ="a;">
            <asp:Button ID="Btn112" runat="server" Text="Sales Pasar Minggu" class="btn btn-default"/></span>
            <span class="a;">
            <asp:Button ID="Btn128" runat="server" Text="Sales Puri" class="btn btn-default"/></span>
                        <span class="a;">
            <asp:Button ID="BtnHome" runat="server" Text="Kembali" class="btn btn-default"/></span>
        </div>
        <div style="margin-bottom:10px;margin-top:20px;margin-left:0px;" runat="server" id="PembatalanIzindanLaporanIzin"><!--100px-->
            <span class ="a;">
            <asp:Button ID="BtnPembatalanIzin" runat="server" Text="Pembatalan Izin Sales" class="btn btn-default"/></span>
            <span class="a;">
            <asp:Button ID="BtnLaporanIzin" runat="server" Text="Laporan Izin Sales" class="btn btn-default"/></span>
        </div>
        <asp:MultiView ID="MultiViewMainSales" runat="server" ActiveViewIndex="-1">
            <asp:View ID="View0" runat="server"><!-- Sales Psm -->
                    <div style="margin-left:0px"><!--100px-->
                            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Operasi Saldo Izin Sales Pasar Minggu</h3><br />
			                <asp:SqlDataSource ID="SqlDataSource112" runat="server"
			                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet5 %>"
			                SelectCommand="select * from data_salesman where sales_aktif = 0 and SALES_Jabatan in (4,3,2) and SALES_Email is not null and SALES_Email <> ''"
			                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet5.ProviderName %>">
			                    <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="SALES_Aktif" Type="String" />
                                </SelectParameters>
			                </asp:SqlDataSource> 
                            <table>
                                <tr>
                                    <td>
                                    	<asp:ListView ID="ListView112" runat="server" DataSourceID="SqlDataSource112" DataKeyNames ="sales_kode" enableviewstate="false">
					                        <LayoutTemplate><br /><div class ="box-centerside">
                                                <input id="myInput112"  type="text" placeholder="Ketik Nama yang akan di Cari!" class="form-control required" autocomplete="off">
                                                <br />
                                
                                                <div id="table-wrapper">
                                                  <div id="table-scroll">
						                        <table id="myTable112" class="search-table inner" align="left" >
							                        <thead style="background-color:#4877CF">
                                                        <!-- add checkbox -->
                                                        <th style="text-align:center; color:black">Check All<br /><asp:CheckBox ID="CheckBox112All" runat="server"  class="selectallAO"/></th>
                                                        <th style="text-align:center; color:black">ID</th>
								                        <th style="text-align:center; color:black">NAMA</th>                                                        
                                                        <th style="text-align:center; color:black">ATASAN</th>
                                                        <th style="text-align:center; color:black">JABATAN</th>
                                                        <th style="text-align:center; color:black">SUBJABATAN</th>
                                                        <th style="text-align:center; color:black">EMAIL</th>
                                        
							                        </thead>
							                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						                        </table></div>	</div>	</div>
					                        </LayoutTemplate>
					                        <ItemTemplate>
						                        <tr>               
                                                    <td >
                                                        <asp:CheckBox ID="CheckBox112" runat="server" value='<%# Eval("sales_kode") %>' class="checkboxAO"/> </td>
                                                    <td style="text-align:center; width="30%" ><%#Eval("sales_kode")%></td>
							                        <td style="text-align:center; width="30%" ><%#Eval("SALES_Nama")%></td>
                                                    <td style="text-align:center; width="30%" ><%#Eval("sales_group")%></td>
                                                    <td style="text-align:center; width="10%"><%#Eval("SALES_Jabatan")%></td>
                                                    <td style="text-align:center; width="20%"><%#Eval("SALES_SubJabatan")%></td>
                                                    <td style="text-align:center; width="10%"><%#Eval("SALES_Email")%></td>
                                                </tr>
					                        </ItemTemplate>
					                        <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					                        <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>              
				                        </asp:ListView>
                                        <br />  <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td><br />
                                         <asp:Button ID="BtnGet112"  visible="true" runat="server" Text="Get Data" class="btn btn-success"/>
                                    </td>
                                </tr>
                            </table>
                       
                        </div>
            </asp:View><!-- Sales PSM -->
            <asp:View ID="View1" runat="server">
            <div style="margin-left:0px"><!--100px-->
                <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Operasi Saldo Izin Sales Puri</h3><br />
			    <asp:SqlDataSource ID="SqlDataSource128" runat="server"
			    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet6 %>"
			    SelectCommand="select * from data_salesman where sales_aktif = 0 and SALES_Jabatan in (4,3,2) and SALES_Email is not null and SALES_Email <> ''"
			    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet5.ProviderName %>">
			        <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="SALES_Aktif" Type="String" />
                    </SelectParameters>
			    </asp:SqlDataSource> 
                            <table>
                                <tr>
                                    <td>
				            <asp:ListView ID="ListView128" runat="server" DataSourceID="SqlDataSource128" DataKeyNames ="sales_kode" enableviewstate="false">
					            <LayoutTemplate><br /><div class ="box-centerside">
                                    <input id="myInput128"  type="text" placeholder="Ketik Nama yang akan di Cari!" class="form-control required" autocomplete="off">
                                    <br />  
                                
                                    <div id="table-wrapper">
                                      <div id="table-scroll">
						            <table id="myTable128" class="search-table inner" align="left" >
							            <thead style="background-color:#4877CF">
                                            <!-- add checkbox -->
                                            <th style="text-align:center; color:black">Check All<br /><asp:CheckBox ID="CheckBox128All" runat="server"  class="selectallAO"/></th>
                                            <th style="text-align:center; color:black">ID</th>
								            <th style="text-align:center; color:black">NAMA</th>
                                            <th style="text-align:center; color:black">ATASAN</th>
                                            <th style="text-align:center; color:black">JABATAN</th>
                                            <th style="text-align:center; color:black">SUBJABATAN</th>
                                            <th style="text-align:center; color:black">EMAIL</th>
                                        
							            </thead>
							            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						            </table></div>	</div>	</div>
					            </LayoutTemplate>
					            <ItemTemplate>
						            <tr>               
                                        <td >
                                            <asp:CheckBox ID="CheckBox128" runat="server" value='<%# Eval("sales_kode") %>' class="checkboxAO"/> </td>
                                        <td style="text-align:center; width="30%" ><%#Eval("sales_kode")%></td>
							            <td style="text-align:center; width="30%" ><%#Eval("SALES_Nama")%></td>
                                        <td style="text-align:center; width="30%" ><%#Eval("sales_group")%></td>
                                        <td style="text-align:center; width="10%"><%#Eval("SALES_Jabatan")%></td>
                                        <td style="text-align:center; width="20%"><%#Eval("SALES_SubJabatan")%></td>
                                        <td style="text-align:center; width="10%"><%#Eval("SALES_Email")%></td>
                                    </tr>
					            </ItemTemplate>
					            <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					            <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>              
				            </asp:ListView>
                                        <br /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td><br />
                                         <asp:Button ID="BtnGet128"  visible="true" runat="server" Text="Get Data" class="btn btn-success"/>
                                    </td>
                                </tr>
                            </table>
            
                </div>
            </asp:View><!-- Sales Puri -->
            <asp:View ID="View2" runat="server"><!-- ListView Operasi Saldo -->
                <div style="margin-left:0px; margin-top:20px;" ><!--50px-->
                    <asp:Label ID="LblCabang" runat="server" Text="Label" Visible=" false"></asp:Label>
                    <table  align="left">
                        <tr>
                            <td >
                                <h3><asp:Label ID="Label1" runat="server" Text="List Data Terpilih : "></asp:Label></h3>
                                <div class="after-box">
                                <asp:GridView ID="GridViewListData" runat="server"></asp:GridView>
                                    
                                </div>
                            </td>
                            <td>
                                <br />
                                <!-- -->
                                <asp:GridView ID="GridViewLaporanIzinSales" runat="server" Visible="false"></asp:GridView>
                                <!-- -->
                                <asp:Button ID="TxtLaporanSaldoSales"  visible="false" runat="server" Text="Get Data Laporan Saldo Izin Sales" class="btn btn-success"/>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <br /><h3>
                                <asp:Label ID="Label2" runat="server" Text="Jenis Operasi : "></asp:Label></h3><br />
                                <asp:DropDownList ID="DropDownListOperasiSaldoSales" runat="server" class="form-control required" onchange="saldo_berlaku();">
                                    <asp:ListItem Value="1">Input Saldo Awal Tahun</asp:ListItem>
                                    <asp:ListItem Value="2">Cuti Hari Raya</asp:ListItem>
                                    <asp:ListItem Value="3">Cuti Besar</asp:ListItem>
                                    <asp:ListItem Value="4">Pending Cuti</asp:ListItem>
                                    <asp:ListItem Value="5">Hutang Cuti</asp:ListItem>
                                </asp:DropDownList><br />
                                <div id="DeadlinePendingCuti" style="display:none">
                                    <asp:Label ID="Label4" runat="server" Text="Masukan Tanggal deadline Pending Cuti" ForeColor="Red" Width="200px"></asp:Label><br />
                                    <asp:TextBox ID="TxtDeadlinePendingCuti" Visible="true" runat="server" class="form-control required" autocomplete="off"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <br />
                                <h3><asp:Label ID="Label3" runat="server" Text="Masukan Nominal : "></asp:Label></h3>
                                <br />
                                <asp:TextBox ID="TxtNominalSaldo" Visible="true" runat="server" class="form-control required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <br />
                                <h3><asp:Label ID="Label5" runat="server" Text="Masukan Tahun Berlaku : "></asp:Label></h3>
                                <br />
                                <asp:TextBox ID="TxtTahunBerlakuSaldo" Visible="true" runat="server" class="form-control required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <asp:Button ID="TxtGetDataOperasi"  visible="true" runat="server" Text="Get Data" class="btn btn-success"/>
                                <p class="ex1">A paragraph with a 25 pixels bottom padding.</p>
                            </td>
                        </tr>
                    </table>
                    
                </div>
            </asp:View><!-- proses add -->
            <asp:View ID="View3" runat="server">
                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Tabel List Izin Approved By Manager</h3>
	            <br />
                        <br /><br />
				        <asp:SqlDataSource ID="SqlDataSourcePembatalanIzinHRD" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
					        SelectCommand="SELECT DATA_IZIN_BODY_sales.IZIN_ID, DATA_IZIN_BODY_sales.IZIN_NIK, DATA_IZIN_BODY_sales.IZIN_ALASAN, DATA_IZIN_BODY_sales.IZIN_JENIS, DATA_IZIN_BODY_sales.IZIN_TGLPENGAJUAN, DATA_IZIN_BODY_sales.IZIN_STATUS, DATA_IZIN_HEADER_SALES.IZIN_NAMA, DATA_IZIN_HEADER_SALES.IZIN_NIK_APPVSPV, DATA_IZIN_HEADER_SALES.IZIN_NIK_APPVMNG,DATA_IZIN_BODY_sales.IZIN_TGLAPPVSPV, DATA_IZIN_BODY_sales.IZIN_TGLAPPVMNG FROM DATA_IZIN_HEADER_sales  JOIN DATA_IZIN_BODY_sales ON DATA_IZIN_HEADER_sales.IZIN_NIK = DATA_IZIN_BODY_sales.IZIN_NIK where IZIN_STATUS ='Disetujui Manajer'"
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				        </asp:SqlDataSource>   
                        <!-- ListView Detali Staff  form Izin-->                                   
				        <asp:ListView ID="ListViewHRDPembatalanIzin" runat="server" DataSourceID="SqlDataSourcePembatalanIzinHRD"  DataKeyNames ="IZIN_ID" enableviewstate="false">
					        <LayoutTemplate>
						        <table id="dataTable" class="table table-bordered striped data" align="left">
							        <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white">Id Izin</th>
                                       
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
						        </table>
			
					        </LayoutTemplate>
				
					        <ItemTemplate>
						        <tr> 
                                    <td><%#Eval("IZIN_ID")%></td>                                                                   
							        <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>   
                                    <td><%#Eval("IZIN_ALASAN")%></td> 
                                    <td><%#Eval("IZIN_TGLPENGAJUAN")%></td>
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
				        <br />
            </asp:View><!-- Proses Pembatalan Izin Sales -->
            <asp:View ID="View4" runat="server">
             <br /><h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Laporan Data Izin Sales</h3><br />                
                
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
                            </tr></table>                  
                <asp:Button ID="BtnFormIzinHRDLaporanIzin" visible="True" runat="server" Text="Download Laporan" class="btn btn-success" /><br /><br />
				* Data Laporan Berupa List Izin Detail (By ID Izin) berulang sesuai dengan banyak nya tgl pengajuan izin
                <div style="display:none"><%--style="display:none"   --%>  
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
					        SelectCommand="SELECT data_izin_body_sales.izin_id,data_izin_header_sales.izin_nik, 
data_izin_header_sales.izin_nama, data_izin_body_sales.izin_jenis, 
data_izin_detail_sales.izin_tgldetail, data_izin_body_sales.izin_alasan
,data_izin_body_sales.izin_jenis, data_izin_body_sales.izin_tglpengajuan,
data_izin_detail_sales.izin_tgldetail,data_izin_body_sales.izin_blnpengajuan, 
data_izin_body_sales.izin_thnpengajuan, data_izin_body_sales.izin_status, 
data_izin_header_sales.izin_nik_appvspv, data_izin_header_sales.izin_nik_appvmng,
data_izin_body_sales.izin_tglappvspv, data_izin_body_sales.izin_tglappvmng
FROM data_izin_header_sales  
INNER JOIN data_izin_body_sales  on data_izin_body_sales.izin_nik = data_izin_header_sales.izin_nik
INNER JOIN data_izin_detail_sales  on data_izin_detail_sales.izin_id= data_izin_body_sales.izin_id
WHERE  ([izin_tgldetail] between ? and ?)"
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtTglCariIzin3" Name="izin_tgldetail" PropertyName="Text" Type="DateTime" />
                                <asp:ControlParameter ControlID="TxtTglCariIzin4" Name="izin_tgldetail" PropertyName="Text" Type="DateTime" />
                            </SelectParameters>
                </asp:SqlDataSource>   
                <asp:ListView ID="ListViewIzinLaporan" runat="server"  Visible="true" DataSourceID="SqlDataSource1">
                    <LayoutTemplate>
                        <div style="width:800px;overflow-x:scroll">
                            <table id="table-a" border="1">
                                <thead style="background-color:#4877CF">
								        <th style="text-align:center; color:black">ID Izin</th>
								        <th style="text-align:center; color:black">NIK</th>
                                        <th style="text-align:center; color:black">Nama</th>
                                        <th style="text-align:center; color:black">Jenis Izin</th>
                                        <th style="text-align:center; color:black">Alasan </th>
                                        <th style="text-align:center; color:black">Tgl Pengajuan</th>
                                        <th style="text-align:center; color:black">Tgl Detail Pengajuan</th>    
                                        <th style="text-align:center; color:black">Bln Pengajuan</th>
                                        <th style="text-align:center; color:black">Tahun Pengajuan</th>
                                        <th style="text-align:center; color:black">NIK Approval Atasan1</th>
                                        <th style="text-align:center; color:black">NIK Approval Atasan2</th>
                                        <th style="text-align:center; color:black">Tgl Approval Atasan1</th>
                                        <th style="text-align:center; color:black">Tgl Approval Atasan2</th>
                                        <th style="text-align:center; color:black">Status Izin</th>                                           
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table>
			            </div>
					        </LayoutTemplate>				
					        <ItemTemplate>
						        <tr>                                   
							        <td style="text-align:center"><%# Eval("IZIN_ID") %></td>
							        <td><%#Eval("IZIN_NIK")%></td>
                                    <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>
                                    <td><%#Eval("IZIN_ALASAN")%></td>
                                    <td><%#Eval("IZIN_TGLPENGAJUAN")%></td>
                                    <td><%#Eval("IZIN_TGLDETAIL")%></td>
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
                </div>
            </asp:View><!-- Laporan Izin Sales -->
            <asp:View ID="View5" runat="server">
                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Detail Sales Cancel Izin </h3>
	            <br />
                <table class="table table-borderless" align="left">
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label33" runat="server" Text="Id Izin"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailStaffCancelIdIzin" Visible="true" runat="server" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2">
                            <asp:Label ID="Label7" runat="server" Text="Tanggal yang di Ajukan"></asp:Label>
                            <asp:Label ID="Label60" runat="server" Text="Tanggal Pengajuan Memotong Cuti Tahunan"></asp:Label></td>
                        <td class="col-md-4"><asp:GridView ID="GridViewCancel" runat="server"  EnableModelValidation="True" GridLines="None" Height="100px" ShowHeader="False" Width="100px" BorderStyle="None">

                                             </asp:GridView>
                            <!-- add chk list  -->

                        </td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label14" runat="server" Text="NIK"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailStaffCancelNIK" Visible="true" runat="server" class="form-control required"></asp:TextBox></td>
                       <td class="col-md-2">
                           <asp:Label ID="Label59" runat="server" Text="Tanggal Pengajuan Memotong Cuti Pending"></asp:Label></td>
                        <td class="col-md-4"><asp:GridView ID="GridViewCancelPend" runat="server" GridLines="None" Height="100px" ShowHeader="False" Width="100px" BorderStyle="None" EnableModelValidation="True"></asp:GridView></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label28" runat="server" Text="Nama"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailStaffCancelNama" Visible="true" runat="server" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2">
                           <asp:Label ID="Label64" runat="server" Text="Tanggal Pengajuan Keseluruhan"></asp:Label></td>                       
                        <td class="col-md-4">
                            <!-- Penambahan Code Baru -->
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                        </td>
                    
                    </tr>
                    <tr >
                        <td class="col-md-2">
                            <asp:Label ID="Label30" runat="server" Text="Jenis Izin"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailStaffCancelJenisIzin" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr >
                        <td class="col-md-2">
                            <asp:Label ID="Label6" runat="server" Text="Alasan Pengajuan"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtAlasanpengajuan" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr >
                        <td class="col-md-2">
                            <asp:Label ID="Label31" runat="server" Text="Tanggal Pengajuan"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailStaffCancelTglPengajuan" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>

                    <tr >
                        <td class="col-md-2">
                            <asp:Label ID="Label34" runat="server" Text="Izin Status"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="txtDetailStaffCancelIzinStatus" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>                      
                    </tr>
                 </table>
                <table >
                    <tr>
                        <asp:Label ID="Label61" runat="server" Visible="false" Text="Label" ForeColor="Red" >Data Izin Ini Sudah Anda Batalkan. Tidak Memiliki Tanggal Pengajuan </asp:Label>
                        <td>
                            <asp:Button ID="BtnDetailStaffHRDCancel" visible="True" runat="server" Text="Cancel Data Izin" class="btn btn-danger" /> 
                            <br />
                        </td>
                        <td>
                            <asp:Button ID="BtnDetailStaffHRDCancelTahunan" visible="false" runat="server" Text="Cancel Data Pengajuan Tahunan" class="btn btn-danger" /> 
                            <br />
                        </td>
                        <td>
                            <asp:Button ID="BtnDetailStaffHRDCancelPending" visible="false" runat="server" Text="Cancel Data Pengajuan Pending" class="btn btn-danger" /> 
                            <br />
                        </td>
                        <td>
                            <asp:Button ID="Button2" visible="True" runat="server" Text="Batalkan Tanggal Terpilih" class="btn btn-danger" /> 
                            <br />
                        </td>              
                    </tr>
                </table>
            </asp:View><!--  Detail Staff Cancel Izin -->
            <asp:View ID="View6" runat="server">
                <div style="margin-left:0px"><!--100px-->
                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> List Saldo Berjalan Sales </h3>
	            <br />
			    <asp:SqlDataSource ID="SqlDataSource2" runat="server"
			    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
			    SelectCommand=" select * from DATA_IZIN_HEADER_SALES"
			    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
			    </asp:SqlDataSource> 
                            <table>
                                <tr>
                                    <td>
				            <asp:ListView ID="ListViewListSaldoSales" runat="server" DataSourceID="SqlDataSource2" DataKeyNames ="izin_nik" enableviewstate="false">
					            <LayoutTemplate><br /><div class ="box-centerside">
                                    <input id="myInput128"  type="text" placeholder="Ketik Nama yang akan di Cari!" class="form-control required" autocomplete="off">
                                    <br />  
                                
                                    <div id="table-wrapper">
                                      <div id="table-scroll">
						            <table id="myTable128" class="search-table inner" align="left" >
							            <thead style="background-color:#4877CF">                                          
                                            <th style="text-align:center; color:black">NIK</th>
								            <th style="text-align:center; color:black">NAMA</th>
                                            <th style="text-align:center; color:black">SALDO IZIN TAHUNAN</th>
                                            <th style="text-align:center; color:black">SALDO IZIN BERLAKU</th>
                                            <th style="text-align:center; color:black">SALDO PENDING </th>
                                            <th style="text-align:center; color:black">SALDO PENDING BERLAKU</th>
                                            <th style="text-align:center; color:black">SALDO HUTANG CUTI</th>
                                            <th style="text-align:center; color:black">ATASAN</th>
                                            <th style="text-align:center; color:black">ATASAN 2</th>
                                            <th style="text-align:center; color:black">SALDO TAHUNAN AWAL INPUT</th>  
                                            <th style="text-align:center; color:black">SALDO TAHUN BERLAKU</th>                                      
							            </thead>
							            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						            </table></div>	</div>	</div>
					            </LayoutTemplate>
					            <ItemTemplate>
						            <tr>                                                 
                                        <td style="text-align:center; width="30%" ><%#Eval("IZIN_NIK")%></td>
							            <td style="text-align:center; width="30%" ><%#Eval("IZIN_NAMA")%></td>
                                        <td style="text-align:center; width="30%" ><%#Eval("IZIN_SALDO")%></td>
                                        <td style="text-align:center; width="10%"><%#Eval("IZIN_SALDO_CUTI_TAHUNAN_BERLAKU")%></td>
                                        <td style="text-align:center; width="20%"><%#Eval("IZIN_SALDO_PC")%></td>
                                        <td style="text-align:center; width="10%"><%#Eval("IZIN_SALDO_PC_BERLAKU")%></td>
                                        <td style="text-align:center; width="10%"><%#Eval("IZIN_SALDO_HC")%></td>
                                        <td style="text-align:center; width="10%"><%#Eval("IZIN_NIK_APPVSPV")%></td>
                                        <td style="text-align:center; width="10%"><%#Eval("IZIN_NIK_APPVMNG")%></td>
                                        <td style="text-align:center; width="10%"><%#Eval("IZIN_SALDO_AWAL")%></td>
                                        <td style="text-align:center; width="10%"><%#Eval("IZIN_TAHUN")%></td>
                                    </tr>
					            </ItemTemplate>
					            <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					            <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>              
				            </asp:ListView>
                                        <br /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td><br />
                                          
                                    </td>
                                </tr>
                            </table>
                </div>

            </asp:View><!-- Cek Saldo Berjalan Sales -->
        </asp:MultiView>
            <p class="ex1">A paragraph with a 25 pixels bottom padding.</p>
<%--        <asp:MultiView ID="MultiViewButtonMaster" runat="server" ActiveViewIndex="0">
            <asp:View ID="View3" runat="server">
                <div class="after-box">
                <asp:Button ID="Button1" runat="server" Text="Operasi Saldo Sales" />
                <asp:Button ID="Button3" runat="server" Text="Pembatalan Izin Sales" />
                <asp:Button ID="Button2" runat="server" Text="Laporan Izin Sales" />
                </div>
            </asp:View>
        </asp:MultiView>--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

</asp:Content>

