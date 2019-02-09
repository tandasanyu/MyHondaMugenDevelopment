<%@ Page Language="VB" MasterPageFile ="~/MasterPage.master"  AutoEventWireup="false" CodeFile="HRDKARYAWAN.aspx.vb" Inherits="HRDKARYAWAN" title="Data Karyawan" %>
<%@ MasterType virtualpath = "~/MasterPage.master"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <script type="text/javascript" language="javascript">
		function Cover(bottom, top, ignoreSize) {
			var location = Sys.UI.DomElement.getLocation(bottom);
			top.style.position = 'absolute';
			top.style.top = location.y + 'px';
			top.style.left = location.x + 'px';
			if (!ignoreSize) {
				top.style.height = bottom.offsetHeight + 'px';
				top.style.width = bottom.offsetWidth + 'px';
			}
		}
    </script> 
  	
	<style>
        .table-borderless > tbody > tr > td,
        .table-borderless > tbody > tr > th,
        .table-borderless > tfoot > tr > td,
        .table-borderless > tfoot > tr > th,
        .table-borderless > thead > tr > td,
        .table-borderless > thead > tr > th {
            border: none;
        }

        hr {
		  border:none;
		  border-top:1px dotted #f00;
		  color:#fff;
		  background-color:#fff;
		  height:1px;
		  width:100%;
		}

        .button {
            background-color: #4CAF50; /* Green */
            border-radius: 4px;
            border: none;
            color: white;
            padding: -10px 32px;
            width:160px;
            height:50px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 13px;
            margin: 4px 2px;
            -webkit-transition-duration: 0.4s; /* Safari */
            transition-duration: 0.4s;
            cursor: pointer;
        }
        
        .button4 {
            background-color: #9FB7E0;
            color: black;
            border: 2px solid #9FB7E0;
        }

        .button4:hover {
            background-color: #0071BB;
            color: white;
        }
    </style>       
    <script type="text/javascript">
	    $(document).ready(function(){
		    $('.data').DataTable();
	    });
    </script>
    <asp:Label ID="LblUserName" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="LblUserId" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="lblAkses" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="lblArea1" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="lblArea2" style="display:none;" runat="server"></asp:Label>

    <div class="container">
        <ul class="breadcrumb">
            <li><a href="#"><span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"><i class="glyphicon glyphicon-user"></i></a> &nbsp <a href="#"> HRD</a> </li>
            <li class="active"><span class="glyphicon glyphicon-duplicate"></span> &nbsp Data Karyawan</li>
        </ul>
		<asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
			<asp:View ID="Viewerr00" runat="server">
				<asp:Label ID="lblMsgBox" runat="server">Judul Permohonan</asp:Label>
			</asp:View> 
		</asp:MultiView>
		<asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
			<asp:View ID="View0101Tabel" runat="server">
                <div class="container">
                    <center>
                        <h2 style="font-family:Cooper Black;">DATA KARYAWAN</h2>
                    </center>
	            </div>
				
				<br /><br /><br />
                
                <div class="row">
                    <div class="col-md-6">
				        <asp:Button ID="Button40" runat="server"  Text="Tambah Karyawan" class="button button4"/>
				        <br /><br />
				        <asp:SqlDataSource ID="SqlDataSTaff" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
					        SelectCommand="SELECT [STAFF_NIK], [STAFF_NAMA], [STAFF_STATUSKERJALOKASI], [STAFF_STATUSKERJAJABATAN], [STAFF_STATUSKERJADEPT] FROM [DATA_STAFF] WHERE [STAFF_NIK] NOT LIKE '%[^0-9]%'"
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				        </asp:SqlDataSource>    
                        <!-- ListView Detali Staff -->                                 
				        <asp:ListView ID="LvDetailStaff" runat="server" DataSourceID="SqlDataSTaff" DataKeyNames ="STAFF_NIK" enableviewstate="false">
					        <LayoutTemplate>
						        <table id="dataTable" class="table table-bordered striped data" align="left">
							        <thead style="background-color:#4877CF">
								        <th style="text-align:center; color:white">NIK</th>
								        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Jabatan</th>
                                        <th style="text-align:center; color:white">Penilaian Karyawan</th>
								        <th style="text-align:center; color:white">Lihat Detail</th>
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table>
			
					        </LayoutTemplate>
				
					        <ItemTemplate>
						        <tr>
							        <td style="text-align:center"><%# Eval("STAFF_NIK") %></td>
							        <td><%#Eval("STAFF_NAMA")%></td>
                                    <td><%#Eval("STAFF_STATUSKERJAJABATAN")%></td>
                                    <td style="text-align:center"><a href="<%#"HRDPENILAIANKARYAWAN.aspx?no=" + Eval("STAFF_NIK")%>"><img src="img/dokumen1.png" width="35px" height="40px" /></a></td>
							        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/detail.png" width="50px" height="50px" /></asp:LinkButton></td>
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>Data Karyawan Tidak diketemukan</EmptyDataTemplate> 
					        <EmptyItemTemplate>Data Karyawan Tidak diketemukan</EmptyItemTemplate>              
				        </asp:ListView>
				        <br />
                    </div>
                    <div class="col-md-6">
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#datadiri">Data Diri</a></li>
                            <li><a data-toggle="tab" href="#datapekerjaan">Data Pekerjaan</a></li>
                            <li><a data-toggle="tab" href="#datapendidikan">Pendidikan & Pelatihan</a></li>
                            <li><a data-toggle="tab" href="#riwayatkerja">Riwayat Kerja</a></li>
                        </ul>

                        <div class="tab-content">
                            <div id="datadiri" class="tab-pane fade in active">
                                <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Data Diri</h3>
                                <br />
                                <table class="table table-borderless">
                                    <tr>
						                <td class="col-md-2"><asp:Label ID="Label66" runat="server" Text="NIK"></asp:Label></td>
						                <td class="col-md-8"><asp:Label ID="TxtStaffNIK" runat="server" MaxLength="10" Text ="" class="form-control required"></asp:Label>
					                        <asp:Label ID="lblStaffNIK" runat="server" Text="462" Visible="false"></asp:Label>	
						                </td>
                                    </tr>     
                                    <tr>
					                    <td class="col-md-2"><asp:Label ID="Label29" runat="server" Text="Nama"></asp:Label></td>
					                    <td class="col-md-4"><asp:Label ID="TxtStaffNama" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:Label></td>
				                    </tr>
                                    <tr>
                                        <td class="col-md-2"><asp:Label ID="Label21" runat="server" Text="Jenis Kelamin"></asp:Label></td>
                                        <td class="col-md-4"><asp:Label ID="TxtJkel" runat="server" class="form-control required"></asp:Label></td>
                                    </tr>
                                    <tr>
				                        <td class="col-md-2"><asp:Label ID="Label39" runat="server" Text="Tempat/Tanggal Lahir"></asp:Label></td>
					                    <td class="col-md-4"><asp:Label ID="TxtStaffLahir" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="col-md-2"><asp:Label ID="Label16" runat="server" Text="Agama"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtAgama" runat="server" class="form-control required"></asp:Label></td>
			                        </tr>
                                    <tr>
                                        <td class="col-md-2"><asp:Label ID="Label22" runat="server" Text="Golongan Darah"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtDarah" runat="server" class="form-control required"></asp:Label></td>
                                    </tr>
                                    <tr>
				                        <td class="col-md-2"><asp:Label ID="Label40" runat="server" Text="Alamat"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStaffJalan" runat="server" MaxLength="80" Text ="" class="form-control required"></asp:Label></td>
					                </tr>
                                    <tr>
				                        <td class="col-md-2"><asp:Label ID="Label41" runat="server" Text="RT/RW"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStaffRT" runat="server" MaxLength="3" Text ="" class="form-control required"></asp:Label></td>
                                    </tr>
                                    <tr>
				                        <td class="col-md-2"><asp:Label ID="Label90" runat="server" Text="Kelurahan"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStaffKel" runat="server" MaxLength="25" Text ="" class="form-control required"></asp:Label></td>
				                    </tr>
                                     <tr>
					                    <td class="col-md-2"><asp:Label ID="Label93" runat="server" Text="Kode Pos"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStaffKodePos" runat="server" MaxLength="5" Text ="" class="form-control required"></asp:Label></td>
				                    </tr>
                                    <tr>
				                        <td class="col-md-2"><asp:Label ID="Label92" runat="server" Text="Kabupaten/Kotamadya"></asp:Label></td>
			                            <td class="col-md-4"><asp:Label ID="TxtStaffKota" runat="server" MaxLength="25" Text ="" class="form-control required"></asp:Label></td>
			                        </tr>
                                    <tr>
                                        <td class="col-md-2"><asp:Label ID="Label8" runat="server" Text="No. Handphone"></asp:Label></td>
                                        <td class="col-md-8"><asp:Label ID="TxtStaffNoHP" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:Label></td>    
                                    </tr>
				                    
                                    <tr>   
                                         <td class="col-md-2"><asp:Label ID="Label9" runat="server" Text="Telepon Rumah"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStaffNoTelepon" runat="server" MaxLength="15" Text ="" class="form-control required"></asp:Label></td>
				                    </tr>

                                    <tr>
				                        <td class="col-md-2"><asp:Label ID="Label10" runat="server" Text="Nomor Kontak Darurat"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStaffNoContact" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:Label></td>
			                        </tr>
                                    <tr>
				                        <td><asp:Label ID="Label1" runat="server" Text="Email" ></asp:Label></td>
				                        <td><asp:Label ID="TxtStaffEmail" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:Label></td>
				                    </tr>
			                        <tr>
			                            <td class="col-md-2"><asp:Label ID="Label32" runat="server"  Text="Status Nikah"></asp:Label></td>
				                        <td class="col-md-4">
				                            <asp:Label ID="DropDownList1" runat="server" class="form-control required"></asp:Label>
			                            </td>
                                    </tr>
                                    <tr>
				                        <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="No. KTP"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStaffNoKtp" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:Label></td>       
				                    </tr>
                                    <tr>    
                                        <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Jenis/No. SIM"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStaffSIM" runat="server" MaxLength="2" TabIndex ="7" Text ="" class="form-control required"></asp:Label></td>    
			                        </tr>
				                    
                                    <tr>
			                            <td class="col-md-2"><asp:Label ID="Label6" runat="server" Text="NPWP"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStaffNPWP" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:Label></td>
			                        </tr>
			                   
                                    <tr>      
                                        <td class="col-md-2"><asp:Label ID="Label7" runat="server" Text="No. Rekening BCA"></asp:Label></td>
			                            <td class="col-md-4"><asp:Label ID="TxtStaffBCA" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:Label></td>
				                    </tr>
			             
                                    <tr>
                                        <td class="col-md-2"><asp:Label ID="Label4" runat="server" Text="No. BPJS Ketenagakerjaan"></asp:Label></td>
		                                <td class="col-md-4"><asp:Label ID="TxtStaffBPJSKerja" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:Label></td>  
			                        </tr>
			                       
                                    <tr>
                                        <td class="col-md-2"><asp:Label ID="Label5" runat="server" Text="No. BPJS Kesehatan"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStaffBPJSSehat" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:Label></td>
				                    </tr>
			                    </table>

                                <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-camera"></span> Foto Karyawan</h3>
				                <br />
				                <table class="table table-borderless">
					                <tr> 
						                <td style="width:10%"><asp:Image ID="Image1" runat="server" src="WEBDOWNLOAD\FOTOKARYAWAN\icon.png" Width="180" Height="220" /></td>
					                </tr>
				                </table>
                            </div>

                            <div id="datapekerjaan" class="tab-pane fade">
                                <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-briefcase"></span> Data Pekerjaan</h3>
			                    <br />
			                    <table class="table table-borderless" align="left">
			                        <tr> 
				                        <td class="col-md-2"><asp:Label ID="Label31" runat="server" Text="Tanggal Masuk kerja"></asp:Label></td>
					                    <td class="col-md-4"><asp:Label ID="TxtStatusKerjaMasuk" runat="server" MaxLength="1" class="form-control required"></asp:Label></td>
                                    </tr>
                                    <tr>
					                    <td class="col-md-2"><asp:Label ID="Label34" runat="server" Text="Department"></asp:Label></td>
					                    <td class="col-md-4"><asp:Label ID="TxtStatusKerjaDept" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:Label></td>
				                    </tr>
		                            <tr>
				                        <td class="col-md-2"><asp:Label ID="Label35" runat="server" Text="Lokasi Penempatan"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStatusKerjaTempat" runat="server" MaxLength="10" Text ="" class="form-control required"></asp:Label></td>
				                    </tr>
                                    <tr>     
                                        <td class="col-md-2"><asp:Label ID="Label33" runat="server" Text="Jabatan"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStatusKerjaJabatan" runat="server" MaxLength="30" class="form-control required" Text =""></asp:Label></td>
				                    </tr>
                                     <tr>     
                                        <td class="col-md-2"><asp:Label ID="Label11" runat="server" Text="Sub Jabatan"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStatusKerjaSubJabatan" runat="server" MaxLength="30" class="form-control required" Text =""></asp:Label></td>
				                    </tr>
			                    </table> 

                                <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-stats"></span> Status Pekerjaan</h3>
			                    <br />
			                    <table class="table table-borderless">
				                    <tr>
					                    <td class="col-md-2"><asp:Label ID="Label36" runat="server"  Text="Status Kerja Magang"></asp:Label></td>
					                    <td class="col-md-4"><asp:Label ID="DropDownList2" runat="server" class="form-control required"></asp:Label></td>
                                    </tr>
                                    <tr>
				                        <td class="col-md-2"><asp:Label ID="Label98" runat="server" Text="Tgl Akhir Kerja Magang" ></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStatusKerjaMagangTglAkhir" runat="server" MaxLength="1" class="form-control required"/></td>
				                    </tr>
				                    <tr>
					                    <td class="col-md-2"><asp:Label ID="Label37" runat="server" Text="Status Kerja Percobaan"></asp:Label></td>
					                    <td class="col-md-4"><asp:Label ID="DropDownList3" runat="server" class="form-control required"></asp:Label></td>
                                    </tr>
                                    <tr>
				                        <td class="col-md-2"><asp:Label ID="Label99" runat="server" Text="Tgl Akhir Percobaan"></asp:Label></td>
					                    <td class="col-md-4"><asp:Label ID="TxtStatusKerjaCobaTglAkhir" runat="server" MaxLength="1" class="form-control required" /></td>
				                    </tr>
				                    <tr>
				                        <td class="col-md-2"><asp:Label ID="Label38" runat="server" Text="Status Kerja Kontrak I"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="DropDownList4" runat="server" class="form-control required"></asp:Label></td>
                                    </tr>
                                    <tr>
				                        <td class="col-md-2"><asp:Label ID="Label100" runat="server" Text="Tgl Akhir Kerja Kontrak I"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStatusKerjaKontrak1TglAkhir" runat="server" MaxLength="1" class="form-control required" /></td>
				                    </tr>
				                    <tr>
					                    <td class="col-md-2"><asp:Label ID="Label42" runat="server" Text="Status Kerja Kontrak II"></asp:Label></td>
					                    <td class="col-md-4"><asp:Label ID="DropDownList5" runat="server" class="form-control required"></asp:Label></td>
                                    </tr>
                                    <tr>
					                    <td class="col-md-2"><asp:Label ID="Label101" runat="server" Text="Tgl Akhir Kerja Kontrak II"></asp:Label></td>
					                    <td class="col-md-2"><asp:Label ID="TxtStatusKerjaKontrak2TglAkhir" runat="server" MaxLength="1" class="form-control required" /></td>
				                    </tr>
				                    <tr>
					                    <td class="col-md-2"><asp:Label ID="Label43" runat="server" Text="Status Kerja Keagenan"></asp:Label></td>
					                    <td class="col-md-4"><asp:Label ID="DropDownList6" runat="server" class="form-control required"></asp:Label></td>
                                    </tr>
                                    <tr>
			                            <td class="col-md-2"><asp:Label ID="Label102" runat="server" Text="Tgl Akhir Keagenan"></asp:Label></td>
				                        <td class="col-md-4"><asp:Label ID="TxtStatusKerjaAgenTglAkhir" runat="server" MaxLength="1"  class="form-control required" /></td>
			                        </tr>
			                    </table>

                                <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-calendar"></span> History Karyawan</h3>
			                    <br />
			                    <table class="table table-borderless">
			                        <tr>
			                            <td class="col-md-2"><asp:Label ID="Label45" runat="server" Font-Names="Arial" Text="Tgl Pengangkatan Karyawan Tetap"></asp:Label></td>
						                <td class="col-md-4"><asp:Label ID="TxtStatusKerjaTetap" runat="server"  class="form-control required" /></td>  
					                </tr>
					                <tr>
						                <td class="col-md-2"><asp:Label ID="Label46" runat="server" Text="Tanggal Keluar"></asp:Label></td>
						                <td class="col-md-4"><asp:Label ID="TxtStatusKerjaKeluar" runat="server" MaxLength="1" class="form-control required" /></td>
					                </tr>
					                <tr>
						                <td class="col-md-2"><asp:Label ID="Label47" runat="server" Text="Alasan Keluar"></asp:Label></td>
						                <td class="col-md-4"><asp:Label ID="TxtStatusKerjaAlasan" runat="server" MaxLength="50" class="form-control required" Text =""></asp:Label></td>
                                    </tr>
				                </table>      
                            </div>

                            <div id="datapendidikan" class="tab-pane fade">
                                <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-education"></span> Pendidikan Formal</h3>
			                    <br />
                                <asp:SqlDataSource ID="SqlDataSTaffPendidikan" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                                    SelectCommand="SELECT [STAFFFO_NIK], [STAFFFO_TINGKAT], [STAFFFO_NAMA], [STAFFFO_JURUSAN], [STAFFFO_TAHUN], [STAFFFO_KET], [STAFFFO_IJAZAH], [STAFFFO_TIPE] FROM [DATA_STAFFFO] WHERE (([STAFFFO_TIPE] = ?) AND ([STAFFFO_NIK] = ?))"
                                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="F" Name="STAFFFO_TIPE" Type="String" />
                                        <asp:ControlParameter ControlID="TxtStaffNIK"  Name="STAFFFO_NIK"  PropertyName="Text" Type="String" />            
                                    </SelectParameters>
                                </asp:SqlDataSource>                             
                                <asp:ListView ID="LVPendidikanFormal" runat="server" DataSourceID="SqlDataSTaffPendidikan"  DataKeyNames ="STAFFFO_TINGKAT">
                                    <LayoutTemplate>
                                        <table id="table-a" class="table table-bordered striped" align="left">
                                            <thead style="background-color:#4877CF">
                                                <th style="text-align:center" class="col-md-1"><font color="white">No.</font></th>
                                                <th style="text-align:center"><font color="white">Tingkat</font></th>
                                                <th style="text-align:center"><font color="white">Institusi</font></th>
                                                <th style="text-align:center"><font color="white">Jurusan</font></th>
                                                <th style="text-align:center"><font color="white">Thn Lulus</font></th>
                                                <th style="text-align:center"><font color="white">Keterangan</font></th>
                                                <th style="text-align:center"><font color="white">Ijazah</font></th>
                                            </thead>
                                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                        </table>
                                    </LayoutTemplate>
        
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                                            <td style="text-align:center"><%# Eval("STAFFFO_TINGKAT") %></td>
                                            <td><%#Eval("STAFFFO_NAMA")%></td>
                                            <td><%#Eval("STAFFFO_JURUSAN")%></td>
                                            <td style="text-align:center"><%#Eval("STAFFFO_TAHUN")%></td>
                                            <td><%#Eval("STAFFFO_KET")%></td>
                                            <td><%#Eval("STAFFFO_IJAZAH")%></td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>Data Pendidikan Formal Tidak diketemukan</EmptyDataTemplate> 
                                    <EmptyItemTemplate>Data Pendidikan Formal Tidak diketemukan</EmptyItemTemplate>              
                                </asp:ListView>    
                                
                                <br /><br />
                                <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-book"></span> Pendidikan Non Formal</h3>
			                    <br />
                                <asp:SqlDataSource ID="SqlDataSTaffPendidikanNonFormal" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                                    SelectCommand="SELECT * FROM [DATA_STAFFFO] WHERE (([STAFFFO_TIPE] = ?) AND ([STAFFFO_NIK] = ?))"
                                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="N" Name="STAFFFO_TIPE" Type="String" />
                                        <asp:ControlParameter ControlID="TxtStaffNIK"   Name="STAFFFO_NIK"  PropertyName="Text" Type="String" DefaultValue ="" />            
                                    </SelectParameters>
                                </asp:SqlDataSource>                             
                                <asp:ListView ID="LVPendidikanNonFormal" runat="server" DataSourceID="SqlDataSTaffPendidikanNonFormal" DataKeyNames ="STAFFFO_TINGKAT">
                                    <LayoutTemplate>
                                        <table id="table-a" class="table table-bordered striped" align="left">
                                            <thead style="background-color:#4877CF">
                                                <th style="text-align:center" class="col-md-1"><font color="white">No.</font></th>
                                                <th style="text-align:center"><font color="white">No. Training</font></th>
                                                <th style="text-align:center"><font color="white">Nama Pelatihan</font></th>
                                                <th style="text-align:center"><font color="white">Instusi</font></th>
                                                <th style="text-align:center"><font color="white">Tahun</font></th>
                                            </thead>
                                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                        </table>
                                    </LayoutTemplate>
        
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                                            <td style="text-align:center"><%# Eval("STAFFFO_TINGKAT") %></td>
                                            <td><%#Eval("STAFFFO_JURUSAN")%></td>
                                            <td><%#Eval("STAFFFO_NAMA")%></td>
                                            <td style="text-align:center"><%#Eval("STAFFFO_TAHUN")%></td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>Data Pendidikan Non Formal Tidak diketemukan</EmptyDataTemplate> 
                                    <EmptyItemTemplate>Data Pendidikan Non Formal Tidak diketemukan</EmptyItemTemplate>              
                                </asp:ListView>

                                <br /><br />
                                <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-list-alt"></span> Pelatihan</h3>
			                    <br />
                                <asp:SqlDataSource ID="SqlDataPelatihan" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                                    SelectCommand="SELECT * FROM [DATA_STAFFPL] WHERE ([STAFFPL_NIK] = ?)"
                                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblStaffNIK" Name="STAFFPL_NIK" PropertyName="Text" Type="String" />            
                                    </SelectParameters>
                                </asp:SqlDataSource>                             
                                <asp:ListView ID="LVPelatihan" runat="server" DataSourceID="SqlDataPelatihan" DataKeyNames ="STAFFPL_PELATIHAN">
                                    <LayoutTemplate>
                                        <table id="table-a" class="table table-bordered striped" align="left">
                                            <thead style="background-color:#4877CF">
                                                <th style="text-align:center" class="col-md-1"><font color="white">No.</font></th>
                                                <th style="text-align:center"><font color="white">Nama</font></th>
                                                <th style="text-align:center"><font color="white">Jenis</font></th>
                                                <th style="text-align:center"><font color="white">Instutusi</font></th>
                                                <th style="text-align:center"><font color="white">Tgl Pelatihan</font></th>
                                                <th style="text-align:center"><font color="white">Biaya</font></th>
                                                <th style="text-align:center"><font color="white">Hasil/Nilai</font></th>
                                            </thead>
                                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                                            <td><%#Eval("STAFFPL_PELATIHAN") %></td>
                                            <td><%#Eval("STAFFPL_JENIS")%></td>
                                            <td><%#Eval("STAFFPL_NAMA")%></td>
                                            <td><%#Eval("STAFFPL_TGL")%></td>
                                            <td>Rp <%#Eval("STAFFPL_BIAYA", "{0:N}")%></td>
                                            <td style="text-align:center"><%#Eval("STAFFPL_HASIL")%></td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>Data Pelatihan Tidak diketemukan</EmptyDataTemplate> 
                                    <EmptyItemTemplate>Data Pelatihan Tidak diketemukan</EmptyItemTemplate>              
                                </asp:ListView><br /><br /><br /><br /><br />
                            </div>
                            <div id="riwayatkerja" class="tab-pane fade">
                                <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-folder-open"></span> Riwayat Pekerjaan</h3>
                                <br />
                                <asp:SqlDataSource ID="SqlDataPengalanKerja" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                                    SelectCommand="SELECT * FROM [DATA_STAFFKR] WHERE ([STAFFKR_NIK] = ?)"
                                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblStaffNIK" Name="STAFFKR_NIK" PropertyName="Text" Type="String" />            
                                    </SelectParameters>
                                </asp:SqlDataSource>                             
                                <asp:ListView ID="LVPengalamanKerja" runat="server" DataSourceID="SqlDataPengalanKerja" DataKeyNames ="STAFFKR_NAMA">
                                    <LayoutTemplate>
                                         <table id="table-a" class="table table-bordered striped" align="left">
                                            <thead style="background-color:#4877CF">
                                                <th style="text-align:center"><font color="white">No.</font></th>
                                                <th style="text-align:center"><font color="white">Perusahaan</font></th>
                                                <th style="text-align:center"><font color="white">Alamat</font></th>
                                                <th style="text-align:center"><font color="white">Jabatan</font></th>
                                                <th style="text-align:center"><font color="white">Masuk</font></th>
                                                <th style="text-align:center"><font color="white">Keluar</font></th>
                                            </thead>
                                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                        </table>
                                    </LayoutTemplate>
        
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                                            <td><%# Eval("STAFFKR_NAMA") %></td>
                                            <td><%#Eval("STAFFKR_ALAMAT")%></td>
                                            <td><%#Eval("STAFFKR_JABATAN")%></td>
                                            <td><%#Eval("STAFFKR_MASUK")%></td>
                                            <td><%#Eval("STAFFKR_KELUAR")%></td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>Data Pengalaman Kerja Tidak diketemukan</EmptyDataTemplate> 
                                    <EmptyItemTemplate>Data Pengalaman Kerja Tidak diketemukan</EmptyItemTemplate>              
                                </asp:ListView><br /><br /><br /><br /><br />
                            </div>

                            <div id="historykaryawan" class="tab-pane fade">
                                <hr />
				                   
                            </div>
                            <center><asp:Label ID="LblErrorSaveA1" runat="server" Text="" style="color:red"></asp:Label>
					           <asp:Button ID="ButtonA1" runat="server" Text="Ubah" class="btn btn-warning" />
                                <asp:Button ID="ButtonA2" runat="server" Text="Penilaian Karyawan" class="btn btn-info" />
                                <!--
					            <asp:Button ID="ButtonA1Save" runat="server" Text="Simpan" class="btn btn-success" />
							    <asp:Button ID="ButtonA1Del" runat="server" Text="Hapus" class="btn btn-danger" />-->
				            </center> 
                        </div>
                    </div>
                </div>          
            </asp:View> 
        </asp:MultiView>  
    </div>          
</asp:Content>