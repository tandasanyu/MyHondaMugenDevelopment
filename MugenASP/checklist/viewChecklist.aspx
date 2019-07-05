<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="viewChecklist.aspx.vb" Inherits="viewChecklist" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <div class="container">
        <center>    
            <h2>FORM PEMERIKSAAN</h2>
		    <h4>001-FRM-SV R.0</h4>
        </center>
	</div>
    
    <form runat="server" id="form1" class="form-horizontal">
        <asp:Label ID="peringatan" runat="server"></asp:Label>
	<div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">
                    Detail Kendaraan
                </h4>
            </div>
        </div>	

        <table>
            <tr height="30px">
                <td><b>No Polisi</b></td>
                <td>&nbsp : &nbsp</td>
                <td><asp:Label ID="nopol" runat="server" style="text-transform: uppercase;"></asp:Label></td>
            </tr>
            <tr height="30px">
                <td><b>Nama Customer</b></td>
                <td>&nbsp : &nbsp</td>
                <td><asp:Label ID="nmCustomer" runat="server"></asp:Label></td>
            </tr>
             <tr height="30px">
                <td><b>No Rangka</b></td>
                <td>&nbsp : &nbsp</td>
                <td><asp:Label ID="noRangka" runat="server"></asp:Label></td>
            </tr>
            <tr height="30px">
                <td><b>Tipe Mobil</b></td>
                <td>&nbsp : &nbsp</td>
                <td><asp:Label ID="typeMobil" runat="server"></asp:Label>	</td>
            </tr>
             <tr height="30px">
                <td><b>Peringatan</b></td>
                <td>&nbsp : &nbsp</td>
                <td><asp:Label ID="textwarning" style="color: red;" runat="server"></asp:Label>	</td>
            </tr>
             <tr height="30px">
                <td><b>Tanggal Kedatangan</b></td>
                <td>&nbsp : &nbsp</td>
                <td><asp:Label ID="tglMasuk" runat="server"></asp:Label>	</td>
            </tr>
            <tr height="30px">
                <td><b>Ordometer</b></td>
                <td>&nbsp : &nbsp</td>
                <td><asp:Label ID="ordometer" runat="server"></asp:Label>	</td>
            </tr>
        </table>

        <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">
                    Kondisi Bensin, Battery dan Ban
                </h4>
            </div>
        </div>	      
        
        <div style="margin-left:-40px">
            <div class="table table-responsive">
                <table class="table table-bordered">
                    <tr>
                        <th class="col-md-2" style="text-align:center">Bensin</th>
                        <td colspan="3">
                            <div class="progress">
                                <div class="progress-bar progress-bar-info progress-bar-striped" id="bensin" runat="server" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100" >
                                    <span class="sr-only"></span><asp:Label ID="textBensin" runat="server"></asp:Label>
                                </div>
                            </div>
                        </td>
                    </tr>    
                    <tr>
                        <th class="col-md-2" style="text-align:center"><br />Battery</th>
                        <td colspan="3"><asp:Label ID="kondisiBaterai" runat="server"></asp:Label></td>
                    </tr>    
                    <tr>
                        <th rowspan="9" class="col-md-2" style="text-align:center"><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Ban</th>
                        <td rowspan="3" class="text-center">Depan</td>
                        <td style="text-align:center"><strong>Kiri</strong></td>
                        <td style="text-align:center"><strong>Kanan</strong></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="banDepanKiri" runat="server" Text="-"></asp:Label> mm</td>
                        <td><asp:Label ID="banDepanKanan" runat="server" Text="-"></asp:Label> mm</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="kondisiBanDepanKiri" runat="server"></asp:Label></td>
                        <td><asp:Label ID="kondisiBanDepanKanan" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="center">Keterangan</td>
                        <td colspan="2"><asp:Label ID="keteranganBanDepan" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="center" rowspan="3">Belakang</td>
                        <td style="text-align:center"><strong>Kiri</strong></td>
                        <td style="text-align:center"><strong>Kanan</strong></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="banBelakangKiri" runat="server" Text="-"></asp:Label> mm</td>
                        <td><asp:Label ID="banBelakangKanan" runat="server" Text="-"></asp:Label> mm</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="kondisiBanBelakangKiri" runat="server"></asp:Label></td>
                        <td><asp:Label ID="kondisiBanBelakangKanan" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="center">Keterangan</td>
                        <td colspan="2"><asp:Label ID="keteranganBanBelakang" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3" style="background-color: #E8E8E8"><b>Standard Minimum 1.6 mm</b></td>
                    </tr>
                </table>
            </div>
        </div>

	    <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">
                    Aksesoris Kendaraan
                </h4>
            </div>
	    </div>	 

        <div style="margin-left:-40px">
	        <div class="table table-responsive">
                <asp:SqlDataSource ID="dataAksesoris" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" SelectCommand="SELECT * FROM [TEMP_CHECKLISTD], [DATA_CHECKLIST] WHERE ([nopol] = ?) and (DATEDIFF(day,tglMasuk,?)=0) and TEMP_CHECKLISTD.kode in ('AKS1','AKS2','AKS3','AKS4','AKS5','AKS6','AKS7','AKS8','AKS9','AKS10','AKS11','AKS12','AKS13','AKS14','AKS15','AKS16','AKS17','AKS18','AKS19','AKS20','AKS21','AKS22','AKS23') AND TEMP_CHECKLISTD.kode=DATA_CHECKLIST.kode" ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="nopol" Name="nopol"       PropertyName= "Text" Type="String" />            
                        <asp:ControlParameter ControlID="tglMasuk" Name="tglMasuk"      PropertyName= "Text" Type="String" />  
                    </selectparameters>
                </asp:SqlDataSource>    

                <asp:ListView  runat="server" DataSourceID="dataAksesoris" >
	                <LayoutTemplate>
				        <table class="table table-bordered striped">
				            <thead  style="background-color:#E8E8E8">
						        <th align="center">No</th>
		                        <th class="col-md-4" align="center">Perlengkapan Kendaraan</th>
                                <th align="center">Kondisi</th>
		                        <th class="col-md-6" align="center">Keterangan</th>
				            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
				        </table>
			        </LayoutTemplate>
                     
			        <ItemTemplate>
				        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
					        <td><%#Eval("deskripsi")%></td>
                            <td align="center"><i class="fa fa-check" aria-hidden="true"></i></td>
                            <td><%#Eval("keterangan")%>
					        </td>
                            
				        </tr>
			        </ItemTemplate>
		        </asp:ListView>
	        </div>
        </div>	
    </div>

    <!-- Page Content -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">
                    Kondisi Fisik Kendaraan
                </h4>
            </div>

                 <!-- SUV -->

             <div class="col-md-6" id="depanCRV" runat="server">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-down"></i> Bagian Depan <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4> 
                    </div>
		            <div class="panel-body">
		                <center>
			                <div class="relative" >
                                <asp:Image ImageUrl="image/depanCRV.png" runat="server" class="img-responsive"></asp:Image>
					            <!-- Bemper Depan Atas 1-->
					            <div class="depanAtas">
					                <asp:Label ID="depanAtas1" runat="server" Text="..."></asp:Label>
						            <!-- Bemper Depan Atas 2 -->
                                    <asp:Label style="margin-left:35px;" ID="depanAtas2" runat="server" Text="..."></asp:Label>
							        <!-- Bemper Depan Atas 3 -->
							        <asp:Label style="margin-left:35px;" ID="depanAtas3" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Atas 4 -->
							        <asp:Label style="margin-left:35px;" ID="depanAtas4" runat="server" Text="..."></asp:Label>
                                     <!-- Bemper Depan Atas 5 -->
							        <asp:Label style="margin-left:35px;" ID="depanAtas5" runat="server" Text="..."></asp:Label>
						        </div>

                                 <!-- Bemper Depan Tengah -->
				                <div class="depanTengah">
					                <!-- Bemper Depan Tengah 1 -->
                                    <asp:Label ID="depanTengah1" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Tengah 2 -->	
                                    <asp:Label style="margin-left:35px;" ID="depanTengah2" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Tengah 3 -->	
                                    <asp:Label style="margin-left:35px;" ID="depanTengah3" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Tengah 4 -->	
                                    <asp:Label style="margin-left:35px;" ID="depanTengah4" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Tengah 5 -->	
                                    <asp:Label style="margin-left:35px;" ID="depanTengah5" runat="server" Text="..."></asp:Label>
					            </div>
								
						        <!-- Bemper Depan Bawah -->
				                <div class="depanBawah">
					                <!-- Bemper Depan Bawah 1 -->
                                    <asp:Label ID="depanBawah1" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Bawah 2 -->	
                                    <asp:Label style="margin-left:35px;" ID="depanBawah2" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Bawah 3 -->	
                                    <asp:Label style="margin-left:35px;" ID="depanBawah3" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Bawah 4 -->	
                                    <asp:Label style="margin-left:35px;" ID="depanBawah4" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Bawah 5 -->	
                                    <asp:Label style="margin-left:35px;" ID="depanBawah5" runat="server" Text="..."></asp:Label>
					            </div>
			                </div>
			            </center>	
                    </div>
                </div>
            </div>

            <div class="col-md-6" id="belakangCRV" runat="server">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-up"></i> Bagian Belakang <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                    <div class="panel-body">
                        <center>
				            <div class="relative">
						        <img src="image/crvBelakang.png" class="img-responsive">  
						        <!-- Belakang Atas -->
						        <div class="belakangAtas">
							        <!-- Belakang Atas 1 -->
                                    <asp:Label ID="belakangAtas1" runat="server" Text="..."></asp:Label> 
                                   
                                    <!-- Belakang Atas 2 -->
                                    <asp:Label style="margin-left:20px;" ID="belakangAtas2" runat="server" Text="..."></asp:Label>

                                    <!-- Belakang Atas 3 -->
                                    <asp:Label style="margin-left:20px;" ID="belakangAtas3" runat="server" Text="..."></asp:Label>
                                  
                                    <!-- Belakang Atas 4 -->
                                    <asp:Label style="margin-left:20px;" ID="belakangAtas4" runat="server" Text="..."></asp:Label>
                                   
                                    <!-- Belakang Atas 5 -->
                                    <asp:Label style="margin-left:20px;" ID="belakangAtas5" runat="server" Text="..."></asp:Label>
                                   
                                    <!-- Belakang Atas 6 -->
                                    <asp:Label style="margin-left:20px;" ID="belakangAtas6" runat="server" Text="..."></asp:Label>
			
						        </div>

                                <div class="belakangTengah">
						            <!-- Belakang Tengah 1 -->
                                    <asp:Label ID="belakangTengah1" runat="server" Text="..."></asp:Label>

                                    <!-- Belakang Tengah 2 -->
                                    <asp:Label style="margin-left:25px;" ID="belakangTengah2" runat="server" Text="..."></asp:Label>
                                   
                                    <!-- Belakang Tengah 3 -->
                                    <asp:Label style="margin-left:25px;" ID="belakangTengah3" runat="server" Text="..."></asp:Label>

                                    <!-- Belakang Tengah 4 -->
                                    <asp:Label style="margin-left:25px;" ID="belakangTengah4" runat="server" Text="..."></asp:Label>

                                    <!-- Belakang Tengah 5 -->
                                    <asp:Label style="margin-left:20px;" ID="belakangTengah5" runat="server" Text="..."></asp:Label>

                                    <!-- Belakang Tengah 6 -->
                                    <asp:Label style="margin-left:20px;" ID="belakangTengah6" runat="server" Text="..."></asp:Label>
							    </div>

							    <!-- Belakang Bawah -->
							    <div class="belakangBawah">
							        <!-- Belakang Bawah 1 -->
                                    <asp:Label ID="belakangBawah1" runat="server" Text="..."></asp:Label>

                                    <!-- Belakang Bawah 2 -->
                                    <asp:Label style="margin-left:25px;" ID="belakangBawah2" runat="server" Text="..."></asp:Label>

                                    <!-- Belakang Bawah 3 -->
                                    <asp:Label style="margin-left:25px;" ID="belakangBawah3" runat="server" Text="..."></asp:Label>

                                    <!-- Belakang Bawah 4 -->
                                    <asp:Label style="margin-left:25px;" ID="belakangBawah4" runat="server" Text="..."></asp:Label>
                                    
                                    <!-- Belakang Bawah 5 -->
                                    <asp:Label style="margin-left:20px;" ID="belakangBawah5" runat="server" Text="..."></asp:Label>
                                    
                                    <!-- Belakang Bawah 6 -->
                                    <asp:Label style="margin-left:20px;" ID="belakangBawah6" runat="server" Text="..."></asp:Label>
                                </div>
						    </div>
					    </center>	
                    </div>
                </div>
            </div>

            <div class="col-md-6" id="kananCRV" runat="server">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-right"></i> Bagian Kanan  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                    <div class="panel-body">
                        <center>
			                <div class="relative">
                                <asp:Image ImageUrl="image/kananCRV.png" runat="server" class="img-responsive"></asp:Image>
				            <!-- Kanan Atas -->
				                <div class="kananAtas">
                                    <asp:Label ID="kananAtas" runat="server" Text="..."></asp:Label>
						        </div>
                                
                                <!-- Kanan Tengah -->
						        <div class="kananTengah">
						            <!-- Kanan Tengah 1 -->
                                    <asp:Label ID="kananTengah1" runat="server" Text="..."></asp:Label>
							        <!-- Kanan Tengah 2 -->
                                    <asp:Label style="margin-left:20px;" ID="kananTengah2" runat="server" Text="..."></asp:Label>						
							        <!-- Kanan Tengah 3 -->
                                    <asp:Label style="margin-left:15px;" ID="kananTengah3" runat="server" Text="..."></asp:Label>						
							        <!-- Kanan Tengah 4 -->
                                    <asp:Label style="margin-left:15px;" ID="kananTengah4" runat="server" Text="..."></asp:Label>				
						            <!-- Kanan Tengah 5 -->
                                    <asp:Label style="margin-left:15px;" ID="kananTengah5" runat="server" Text="..."></asp:Label>		
							        <!-- Kanan Tengah 6 -->
                                    <asp:Label style="margin-left:20px;" ID="kananTengah6" runat="server" Text="..."></asp:Label>
						            <!-- Kanan Tengah 7 -->
                                    <asp:Label style="margin-left:15px;" ID="kananTengah7" runat="server" Text="..."></asp:Label>
						            <!-- Kanan Tengah 8 -->
                                    <asp:Label style="margin-left:20px;" ID="kananTengah8" runat="server" Text="..."></asp:Label>
                                    <!-- Kanan Tengah 9 -->
                                    <asp:Label style="margin-left:20px;" ID="kananTengah9" runat="server" Text="..."></asp:Label>
                                    <!-- Kanan Tengah 10 -->
                                    <asp:Label style="margin-left:20px;" ID="kananTengah10" runat="server" Text="..."></asp:Label>
					            </div>
							
					            <!-- Kanan Bawah -->
					            <div class="kananBawah">
							        <!-- Kanan Bawah 1 -->
                                    <asp:Label ID="kananBawah1" runat="server" Text="..."></asp:Label>							
							        <!-- Kanan Bawah 2 -->
                                    <asp:Label style="margin-left:30px;" ID="kananBawah2" runat="server" Text="..."></asp:Label>					
								    <!-- Kanan Bawah 3 --> 
                                    <asp:Label style="margin-left:30px;" ID="kananBawah3" runat="server" Text="..."></asp:Label>     								
							        <!-- Kanan Bawah 4 -->
                                    <asp:Label style="margin-left:20px;" ID="kananBawah4" runat="server" Text="..."></asp:Label>						
								    <!-- Kanan Bawah 5 -->
                                    <asp:Label style="margin-left:20px;" ID="kananBawah5" runat="server" Text="..."></asp:Label>						
								    <!-- Kanan Bawah 6 -->
                                    <asp:Label style="margin-left:20px;" ID="kananBawah6" runat="server" Text="..."></asp:Label>						
								    <!-- Kanan Bawah 7 -->
                                    <asp:Label style="margin-left:20px;" ID="kananBawah7" runat="server" Text="..."></asp:Label>
                                    <!-- Kanan Bawah 8 -->
                                    <asp:Label style="margin-left:15px;" ID="kananBawah8" runat="server" Text="..."></asp:Label>
                                    <!-- Kanan Bawah 9 -->
                                    <asp:Label style="margin-left:20px;" ID="kananBawah9" runat="server" Text="..."></asp:Label>
                                    <!-- Kanan Bawah 10 -->
                                    <asp:Label style="margin-left:20px;" ID="kananBawah10" runat="server" Text="..."></asp:Label>
							    </div>
					        </div>
				        </center>	
                    </div>
                </div>
            </div>
			
		    <div class="col-md-6" id="kiriCRV" runat="server">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-left"></i> Bagian Kiri  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                    <div class="panel-body">
                        <center>
				            <div class="relative">
                                <asp:Image ImageUrl="image/kiriCRV.png" runat="server" class="img-responsive"></asp:Image>
				            <!-- Kiri Atas -->
				                <div class="kiriAtas">
                                    <asp:Label ID="kiriAtas" runat="server" Text="..."></asp:Label>					
						        </div>
							    
                                <!-- Kiri Tengah -->
				                <div class="kiriTengah">
						            <!-- Kiri Tengah 1 -->
                                    <asp:Label ID="kiriTengah1" runat="server" Text="..."></asp:Label>	 
					                <!-- Kiri Tengah 2 -->
                                    <asp:Label style="margin-left:30px;" ID="kiriTengah2" runat="server" Text="..."></asp:Label>								
						            <!-- Kiri Tengah 3 -->
                                    <asp:Label style="margin-left:15px;" ID="kiriTengah3" runat="server" Text="..."></asp:Label>						
						            <!-- Kiri Tengah 4 -->
                                    <asp:Label style="margin-left:15px;" ID="kiriTengah4" runat="server" Text="..."></asp:Label>						
						            <!-- Kiri Tengah 5 -->
                                    <asp:Label style="margin-left:15px;" ID="kiriTengah5" runat="server" Text="..."></asp:Label>				
							        <!-- Kiri Tengah 6 -->
                                    <asp:Label style="margin-left:20px;" ID="kiriTengah6" runat="server" Text="..."></asp:Label>					
							        <!-- Kiri Tengah 7 -->
                                    <asp:Label style="margin-left:15px;" ID="kiriTengah7" runat="server" Text="..."></asp:Label>					
					                <!-- Kiri Tengah 8 -->
                                    <asp:Label style="margin-left:20px;" ID="kiriTengah8" runat="server" Text="..."></asp:Label>
                                    <!-- Kiri Tengah 9 -->
                                    <asp:Label style="margin-left:20px;" ID="kiriTengah9" runat="server" Text="..."></asp:Label>
                                    <!-- Kiri Tengah 10 -->
                                    <asp:Label style="margin-left:20px;" ID="kiriTengah10" runat="server" Text="..."></asp:Label>
					            </div>
							
					            <!-- Kiri Bawah -->
					            <div class="kiriBawah">
						            <!-- Kiri Bawah 1 -->
                                    <asp:Label ID="kiriBawah1" runat="server" Text="..."></asp:Label>						
						            <!-- Kiri Bawah 2 -->
                                    <asp:Label style="margin-left:30px;" ID="kiriBawah2" runat="server" Text="..."></asp:Label>
							        <!-- Kiri Bawah 3 -->
                                    <asp:Label style="margin-left:25px;" ID="kiriBawah3" runat="server" Text="..."></asp:Label>						
						            <!-- Kiri Bawah 4 -->
                                    <asp:Label style="margin-left:20px;" ID="kiriBawah4" runat="server" Text="..."></asp:Label>						
							        <!-- Kiri Bawah 5 -->
                                    <asp:Label style="margin-left:15px;" ID="kiriBawah5" runat="server" Text="..."></asp:Label>						
							        <!-- Kiri Bawah 6 -->
                                    <asp:Label style="margin-left:15px;" ID="kiriBawah6" runat="server" Text="..."></asp:Label>					
								    <!-- Kiri Bawah 7 -->
                                    <asp:Label style="margin-left:20px;" ID="kiriBawah7" runat="server" Text="..."></asp:Label>
                                    <!-- Kiri Bawah 8 -->
                                    <asp:Label style="margin-left:20px;" ID="kiriBawah8" runat="server" Text="..."></asp:Label>
                                    <!-- Kiri Bawah 9 -->
                                    <asp:Label style="margin-left:25px;" ID="kiriBawah9" runat="server" Text="..."></asp:Label>
                                    <!-- Kiri Bawah 10 -->
                                    <asp:Label style="margin-left:25px;" ID="kiriBawah10" runat="server" Text="..."></asp:Label>
					            </div>
					        </div>
				        </center>	
                    </div>
                </div>
            </div>
			
            <div class="col-md-6" id="atasCRV" runat="server">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrows-alt"></i> Bagian Atas  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                    <div class="panel-body">
                        <center>
			                <div class="relative">
                                <asp:Image ImageUrl="image/atasCRV.png" runat="server" class="img-responsive"></asp:Image> 
					            <!-- Atas Kiri -->
					            <div class="atasKiri">
						            <!-- Atas Kiri 1 -->
                                    <asp:Label ID="atasKiri1" runat="server" Text="..."></asp:Label>
							        <!-- Atas Kiri 2 -->
                                    <asp:Label style="margin-left:20px;" ID="atasKiri2" runat="server" Text="..."></asp:Label>
							        <!-- Atas Kiri 3 -->
                                    <asp:Label style="margin-left:20px;" ID="atasKiri3" runat="server" Text="..."></asp:Label>				
							        <!-- Atas Kiri 4 -->
                                    <asp:Label style="margin-left:20px;" ID="atasKiri4" runat="server" Text="..."></asp:Label>
						            <!-- Atas Kiri 5 -->
                                    <asp:Label style="margin-left:20px;" ID="atasKiri5" runat="server" Text="..."></asp:Label>
                                    <!-- Atas Kiri 6 -->
                                    <asp:Label style="margin-left:20px;" ID="atasKiri6" runat="server" Text="..."></asp:Label>
                                    <!-- Atas Kiri 7 -->
                                    <asp:Label style="margin-left:100px;" ID="atasKiri7" runat="server" Text="..."></asp:Label>
				                </div>
							
						        <!-- Atas Kanan -->
						        <div class="atasKanan">
					                <!-- Atas Kanan 1 -->
                                    <asp:Label ID="atasKanan1" runat="server" Text="..."></asp:Label>					
						            <!-- Atas Kanan 2 -->
                                    <asp:Label style="margin-left:20px;" ID="atasKanan2" runat="server" Text="..."></asp:Label>					
							        <!-- Atas Kanan 3 -->
                                    <asp:Label style="margin-left:20px;" ID="atasKanan3" runat="server" Text="..."></asp:Label>
							        <!-- Atas Kanan 4 -->
                                    <asp:Label style="margin-left:20px;" ID="atasKanan4" runat="server" Text="..."></asp:Label>				
						            <!-- Atas Kanan 5 -->
                                    <asp:Label style="margin-left:20px;" ID="atasKanan5" runat="server" Text="..."></asp:Label>
                                    <!-- Atas Kanan 6 -->
                                    <asp:Label style="margin-left:20px;" ID="atasKanan6" runat="server" Text="..."></asp:Label>
                                    <!-- Atas Kanan 7 -->
                                    <asp:Label style="margin-left:100px;" ID="atasKanan7" runat="server" Text="..."></asp:Label>
					            </div>
                            </div>
					    </center>	
                    </div>
                </div>
            </div>

            <!-- Sedan-->

            <!-- Bemper Depan Atas 1-->
            <div class="col-md-6" id="depanAccord" runat="server">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-down"></i> Bagian Depan <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4> 
                    </div>
		            <div class="panel-body">
		                <center>
			                <div class="relative" >
                                <asp:Image ImageUrl="image/depanAccord.png" runat="server" class="img-responsive"></asp:Image>
					            <!-- Bemper Depan Atas 1-->
					            <div class="depanAtasB">
					                <asp:Label ID="askDepanAtas1" runat="server" Text="..."></asp:Label>
						            <!-- Bemper Depan Atas 2 -->
                                    <asp:Label style="margin-left:35px;" ID="askDepanAtas2" runat="server" Text="..."></asp:Label>
							        <!-- Bemper Depan Atas 3 -->
							        <asp:Label style="margin-left:35px;" ID="askDepanAtas3" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Atas 4 -->
							        <asp:Label style="margin-left:35px;" ID="askDepanAtas4" runat="server" Text="..."></asp:Label>
                                     <!-- Bemper Depan Atas 5 -->
							        <asp:Label style="margin-left:35px;" ID="askDepanAtas5" runat="server" Text="..."></asp:Label>
						        </div>

                                 <!-- Bemper Depan Tengah -->
				                <div class="depanTengahB">
					                <!-- Bemper Depan Tengah 1 -->
                                    <asp:Label ID="askDepanTengah1" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Tengah 2 -->	
                                    <asp:Label style="margin-left:35px;" ID="askDepanTengah2" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Tengah 3 -->	
                                    <asp:Label style="margin-left:35px;" ID="askDepanTengah3" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Tengah 4 -->	
                                    <asp:Label style="margin-left:35px;" ID="askDepanTengah4" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Tengah 5 -->	
                                    <asp:Label style="margin-left:35px;" ID="askDepanTengah5" runat="server" Text="..."></asp:Label>
					            </div>
								
						        <!-- Bemper Depan Bawah -->
				                <div class="depanBawahB">
					                <!-- Bemper Depan Bawah 1 -->
                                    <asp:Label ID="askDepanBawah1" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Bawah 2 -->	
                                    <asp:Label style="margin-left:35px;" ID="askDepanBawah2" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Bawah 3 -->	
                                    <asp:Label style="margin-left:35px;" ID="askDepanBawah3" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Bawah 4 -->	
                                    <asp:Label style="margin-left:35px;" ID="askDepanBawah4" runat="server" Text="..."></asp:Label>
                                    <!-- Bemper Depan Bawah 5 -->	
                                    <asp:Label style="margin-left:35px;" ID="askDepanBawah5" runat="server" Text="..."></asp:Label>
					            </div>
			                </div>
			            </center>	
                    </div>
                </div>
            </div>

            <div class="col-md-6" id="belakangAccord" runat="server">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-up"></i> Bagian Belakang <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                    <div class="panel-body">
                        <center>
                            <div class="relative">
                                <asp:Image ImageUrl="image/belakangAccord.png" runat="server" class="img-responsive"></asp:Image>                  
					            <!-- Belakang Atas -->
					            <div class="belakangAtasB">
                                    <!-- Belakang Atas 1 -->
                                    <asp:Label ID="askBelakangAtas1" runat="server" Text="..."></asp:Label>
							        <!-- Belakang Atas 2 -->
                                    <asp:Label style="margin-left:30px;" ID="askBelakangAtas2" runat="server" Text="..."></asp:Label>
                                    <!-- Belakang Atas 3 -->
                                    <asp:Label style="margin-left:30px;" ID="askBelakangAtas3" runat="server" Text="..."></asp:Label>
                                    <!-- Belakang Atas 4 -->
                                    <asp:Label style="margin-left:30px;" ID="askBelakangAtas4" runat="server" Text="..."></asp:Label>
                                    <!-- Belakang Atas 5 -->
                                    <asp:Label style="margin-left:30px;" ID="askBelakangAtas5" runat="server" Text="..."></asp:Label>
				                </div>

                                <!-- Belakang Tengah -->
					            <div class="belakangTengahB">
                                    <!-- Belakang Atas 1 -->
                                    <asp:Label ID="askBelakangTengah1" runat="server" Text="..."></asp:Label>
						            <!-- Belakang Atas 2 -->
                                    <asp:Label style="margin-left:30px;" ID="askBelakangTengah2" runat="server" Text="..."></asp:Label>
                                    <!-- Belakang Atas 3 -->
                                    <asp:Label style="margin-left:30px;" ID="askBelakangTengah3" runat="server" Text="..."></asp:Label>
                                    <!-- Belakang Atas 4 -->
                                    <asp:Label style="margin-left:30px;" ID="askBelakangTengah4" runat="server" Text="..."></asp:Label>
                                    <!-- Belakang Atas 5 -->
                                    <asp:Label style="margin-left:30px;" ID="askBelakangTengah5" runat="server" Text="..."></asp:Label>
				                </div>
								
                                <!-- Belakang Bawah -->
                                <div class="belakangBawahB">
                                    <!-- Belakang Bawah 1 -->
                                    <asp:Label ID="askBelakangBawah1" runat="server" Text="..."></asp:Label> 
                                    <!-- Belakang Bawah 2 -->
                                    <asp:Label style="margin-left:30px;" ID="askBelakangBawah2" runat="server" Text="..."></asp:Label> 
                                    <!-- Belakang Bawah 3 -->
                                    <asp:Label style="margin-left:30px;" ID="askBelakangBawah3" runat="server" Text="..."></asp:Label>
                                    <!-- Belakang Bawah 4 -->
                                    <asp:Label style="margin-left:30px;" ID="askBelakangBawah4" runat="server" Text="..."></asp:Label>
                                    <!-- Belakang Bawah 5 -->
                                    <asp:Label style="margin-left:30px;" ID="askBelakangBawah5" runat="server" Text="..."></asp:Label>
                                </div>
                            </div>
			            </center>	
                    </div>
                </div>
            </div>

            <div class="col-md-6" id="kananAccord" runat="server">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-right"></i> Bagian Kanan  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                    <div class="panel-body">
                        <center>
			                <div class="relative">
                                <asp:Image ImageUrl="image/kananAccord.png" runat="server" class="img-responsive"></asp:Image>
				            <!-- Kanan Atas -->
				                <div class="kananAtasB">
                                    <asp:Label ID="askKananAtas" runat="server" Text="..."></asp:Label>
						        </div>
                                
                                <!-- Kanan Tengah -->
						        <div class="kananTengahB">
						            <!-- Kanan Tengah 1 -->
                                    <asp:Label ID="askKananTengah1" runat="server" Text="..."></asp:Label>
							        <!-- Kanan Tengah 2 -->
                                    <asp:Label style="margin-left:30px;" ID="askKananTengah2" runat="server" Text="..."></asp:Label>						
							        <!-- Kanan Tengah 3 -->
                                    <asp:Label style="margin-left:15px;" ID="askKananTengah3" runat="server" Text="..."></asp:Label>						
							        <!-- Kanan Tengah 4 -->
                                    <asp:Label style="margin-left:15px;" ID="askKananTengah4" runat="server" Text="..."></asp:Label>				
						            <!-- Kanan Tengah 5 -->
                                    <asp:Label style="margin-left:15px;" ID="askKananTengah5" runat="server" Text="..."></asp:Label>		
							        <!-- Kanan Tengah 6 -->
                                    <asp:Label style="margin-left:20px;" ID="askKananTengah6" runat="server" Text="..."></asp:Label>
						            <!-- Kanan Tengah 7 -->
                                    <asp:Label style="margin-left:15px;" ID="askKananTengah7" runat="server" Text="..."></asp:Label>
						            <!-- Kanan Tengah 8 -->
                                    <asp:Label style="margin-left:20px;" ID="askKananTengah8" runat="server" Text="..."></asp:Label>
                                    <!-- Kanan Tengah 9 -->
                                    <asp:Label style="margin-left:20px;" ID="askKananTengah9" runat="server" Text="..."></asp:Label>
					            </div>
							
					            <!-- Kanan Bawah -->
					            <div class="kananBawahB">
							        <!-- Kanan Bawah 1 -->
                                    <asp:Label ID="askKananBawah1" runat="server" Text="..."></asp:Label>							
							        <!-- Kanan Bawah 2 -->
                                    <asp:Label style="margin-left:30px;" ID="askKananBawah2" runat="server" Text="..."></asp:Label>					
								    <!-- Kanan Bawah 3 --> 
                                    <asp:Label style="margin-left:25px;" ID="askKananBawah3" runat="server" Text="..."></asp:Label>     								
							        <!-- Kanan Bawah 4 -->
                                    <asp:Label style="margin-left:20px;" ID="askKananBawah4" runat="server" Text="..."></asp:Label>						
								    <!-- Kanan Bawah 5 -->
                                    <asp:Label style="margin-left:20px;" ID="askKananBawah5" runat="server" Text="..."></asp:Label>						
								    <!-- Kanan Bawah 6 -->
                                    <asp:Label style="margin-left:20px;" ID="askKananBawah6" runat="server" Text="..."></asp:Label>						
								    <!-- Kanan Bawah 7 -->
                                    <asp:Label style="margin-left:25px;" ID="askKananBawah7" runat="server" Text="..."></asp:Label>
                                    <!-- Kanan Bawah 8 -->
                                    <asp:Label style="margin-left:25px;" ID="askKananBawah8" runat="server" Text="..."></asp:Label>
                                    <!-- Kanan Bawah 9 -->
                                    <asp:Label style="margin-left:30px;" ID="askKananBawah9" runat="server" Text="..."></asp:Label>
							    </div>
					        </div>
				        </center>	
                    </div>
                </div>
            </div>
			
		    <div class="col-md-6" id="kiriAccord" runat="server">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-left"></i> Bagian Kiri  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                    <div class="panel-body">
                        <center>
				            <div class="relative">
                                <asp:Image ImageUrl="image/kiriAccord.png" runat="server" class="img-responsive"></asp:Image>
				            <!-- Kiri Atas -->
				                <div class="kiriAtasB">
                                    <asp:Label ID="askKiriAtas" runat="server" Text="..."></asp:Label>					
						        </div>
							    
                                <!-- Kiri Tengah -->
				                <div class="kiriTengahB">
						            <!-- Kiri Tengah 1 -->
                                    <asp:Label ID="askKiriTengah1" runat="server" Text="..."></asp:Label>	 
					                <!-- Kiri Tengah 2 -->
                                    <asp:Label style="margin-left:30px;" ID="askKiriTengah2" runat="server" Text="..."></asp:Label>								
						            <!-- Kiri Tengah 3 -->
                                    <asp:Label style="margin-left:15px;" ID="askKiriTengah3" runat="server" Text="..."></asp:Label>						
						            <!-- Kiri Tengah 4 -->
                                    <asp:Label style="margin-left:15px;" ID="askKiriTengah4" runat="server" Text="..."></asp:Label>						
						            <!-- Kiri Tengah 5 -->
                                    <asp:Label style="margin-left:15px;" ID="askKiriTengah5" runat="server" Text="..."></asp:Label>				
							        <!-- Kiri Tengah 6 -->
                                    <asp:Label style="margin-left:20px;" ID="askKiriTengah6" runat="server" Text="..."></asp:Label>					
							        <!-- Kiri Tengah 7 -->
                                    <asp:Label style="margin-left:15px;" ID="askKiriTengah7" runat="server" Text="..."></asp:Label>					
					                <!-- Kiri Tengah 8 -->
                                    <asp:Label style="margin-left:20px;" ID="askKiriTengah8" runat="server" Text="..."></asp:Label>
                                    <!-- Kiri Tengah 9 -->
                                    <asp:Label style="margin-left:20px;" ID="askKiriTengah9" runat="server" Text="..."></asp:Label>
					            </div>
							
					            <!-- Kiri Bawah -->
					            <div class="kiriBawahB">
						            <!-- Kiri Bawah 1 -->
                                    <asp:Label ID="askKiriBawah1" runat="server" Text="..."></asp:Label>						
						            <!-- Kiri Bawah 2 -->
                                    <asp:Label style="margin-left:30px;" ID="askKiriBawah2" runat="server" Text="..."></asp:Label>
							        <!-- Kiri Bawah 3 -->
                                    <asp:Label style="margin-left:25px;" ID="askKiriBawah3" runat="server" Text="..."></asp:Label>						
						            <!-- Kiri Bawah 4 -->
                                    <asp:Label style="margin-left:20px;" ID="askKiriBawah4" runat="server" Text="..."></asp:Label>						
							        <!-- Kiri Bawah 5 -->
                                    <asp:Label style="margin-left:15px;" ID="askKiriBawah5" runat="server" Text="..."></asp:Label>						
							        <!-- Kiri Bawah 6 -->
                                    <asp:Label style="margin-left:15px;" ID="askKiriBawah6" runat="server" Text="..."></asp:Label>					
								    <!-- Kiri Bawah 7 -->
                                    <asp:Label style="margin-left:25px;" ID="askKiriBawah7" runat="server" Text="..."></asp:Label>
                                    <!-- Kiri Bawah 8 -->
                                    <asp:Label style="margin-left:25px;" ID="askKiriBawah8" runat="server" Text="..."></asp:Label>
                                    <!-- Kiri Bawah 9 -->
                                    <asp:Label style="margin-left:30px;" ID="askKiriBawah9" runat="server" Text="..."></asp:Label>
					            </div>
					        </div>
				        </center>	
                    </div>
                </div>
            </div>
			
             <div class="col-md-6" id="atasAccord" runat="server">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrows-alt"></i> Bagian Atas  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                    <div class="panel-body">
                        <center>
			                <div class="relative">
                                <asp:Image ImageUrl="image/atasAccord.png" runat="server" class="img-responsive"></asp:Image>
					            <!-- Atas Kiri -->
					            <div class="atasKiriB">
						            <!-- Atas Kiri 1 -->
                                    <asp:Label ID="askAtasKiri1" runat="server" Text="..."></asp:Label>
							        <!-- Atas Kiri 2 -->
                                    <asp:Label style="margin-left:55px;" ID="askAtasKiri2" runat="server" Text="..."></asp:Label>
							        <!-- Atas Kiri 3 -->
                                    <asp:Label style="margin-left:35px;" ID="askAtasKiri3" runat="server" Text="..."></asp:Label>				
							        <!-- Atas Kiri 4 -->
                                    <asp:Label style="margin-left:35px;" ID="askAtasKiri4" runat="server" Text="..."></asp:Label>
						            <!-- Atas Kiri 5 -->
                                    <asp:Label style="margin-left:100px;" ID="askAtasKiri5" runat="server" Text="..."></asp:Label>
				                </div>
							
						        <!-- Atas Kanan -->
						        <div class="atasKananB">
					                <!-- Atas Kanan 1 -->
                                    <asp:Label ID="askAtasKanan1" runat="server" Text="..."></asp:Label>					
						            <!-- Atas Kanan 2 -->
                                    <asp:Label style="margin-left:65px;" ID="askAtasKanan2" runat="server" Text="..."></asp:Label>					
							        <!-- Atas Kanan 3 -->
                                    <asp:Label style="margin-left:35px;" ID="askAtasKanan3" runat="server" Text="..."></asp:Label>
							        <!-- Atas Kanan 4 -->
                                    <asp:Label style="margin-left:35px;" ID="askAtasKanan4" runat="server" Text="..."></asp:Label>				
						            <!-- Atas Kanan 5 -->
                                    <asp:Label style="margin-left:100px;" ID="askAtasKanan5" runat="server" Text="..."></asp:Label>
					            </div>
                            </div>
					    </center>	
                    </div>
                </div>
            </div>

             <div class="row"  style="margin-left:10px">
                <div class="col-lg-12">
                    <h4 class="page-header">
                        Catatan
                    </h4>
                </div>
            </div>	
            <div style="margin-left:20px">    
                <div class="form-group">
                    <asp:Label style="margin-left:20px" ID="catatan" runat="server"></asp:Label>
                </div>
            </div> 

            <div class="row" style="margin-left:5px">
                <div class="col-lg-12">
                    <h4 class="page-header">
                        Diagnosa Jenis Keluhan Suara 
                    </h4>
                </div>
            </div>	
            <div style="margin-left:30px">
                <div class="form-group">
				    <label for="kelebihan">1. Jenis keluhan atau suara yang terdengar (contoh: menggelitik atau benturan bensin)?</label><br>
				       
                    <asp:Label style="margin-left:20px" ID="Q1" runat="server"></asp:Label>
			    </div>  
                <div class="form-group">
				    <label for="kelebihan">2. Bagaimana kecepatan mobil saat keluhan atau suara-suara itu terdengar</label><br />
                     <asp:Label style="margin-left:10px" ID="Q2" runat="server"></asp:Label>
                
			    </div>  
                 <div class="form-group">
				    <label for="kelebihan">3. Arah saat berkendara</label><br />
                    <asp:Label style="margin-left:10px" ID="Q3" runat="server"></asp:Label>
			    </div>  
                <div class="form-group">
				    <label for="kelebihan">4. Keadaan kecepatan (berkendara)</label><br />
                     <asp:Label style="margin-left:10px" ID="Q4" runat="server"></asp:Label>
			    </div>  
                 <div class="form-group">
				    <label for="kelebihan">5. Kondisi jalan</label><br />
                    <asp:Label style="margin-left:10px" ID="Q5" runat="server"></asp:Label>
			    </div>  
                 <div class="form-group">
				    <label for="kelebihan">6. Bagian mobil tempat darimana suara itu terdengar (Kiri) (Kanan) (Tandai bila tahu)</label><br />
                        <asp:Label style="margin-left:10px" ID="Q6" runat="server"></asp:Label>
			    </div>  
                <div class="form-group">
				    <label for="kelebihan">7. Kondisi-kondisi pengendaraan lain</label><br />
                     <asp:Label style="margin-left:10px" ID="Q7" runat="server"></asp:Label>
			    </div>  
                 <div class="form-group">
				    <label for="kelebihan">8. Seberapa sering suara/noise terdengar?</label><br />
                     <asp:Label style="margin-left:10px" ID="Q8" runat="server"></asp:Label>
			    </div>  
                     <div class="form-group">
				    <label for="kelebihan">9. Bagaimana kondisi cuacanya?</label><br />
                     <asp:Label style="margin-left:10px" ID="Q9" runat="server"></asp:Label>
			    </div>  
                <div class="form-group">
				    <label for="kelebihan">10. Berapa banyak penumpang dalam mobil saat noise terdengar?</label><br />
				     <asp:Label style="margin-left:20px" ID="Q10" runat="server"></asp:Label>
			    </div>  
            <br /><br />
            <asp:Label runat="server" Text="Petugas Checklist,"></asp:Label><br /><br />
            <asp:Label runat="server" ID="nm_petugas"></asp:Label><br /><br />

                <div class="box" id="box" runat="server">
                   <b>Catatan:</b><br />
                     <asp:Label ID="keterangan" runat="server" Text="Label"></asp:Label>
                </div>
                <center><asp:Button ID="update" runat="server" Text="Ubah" style="display:none;" CssClass="btn btn-warning" /></center>
                </div>
        </div>
    </div>          
    </form>


<style>

div.relative {
    position: relative;
    width: 400px;
    height: 250px;
   
} 

div.depanAtas {
    position: absolute;
    top: 100px;
    left: -25px;
    width: 450px;   
}

div.depanTengah {
    position: absolute;
    top: 140px;
    left: -25px;
    width: 450px; 
}

div.depanBawah {
	position: absolute;
    bottom: 50px;
    left: 0px;
    width: 100%;
}

div.belakangAtas {
    position: absolute;
    bottom: 160px;
    left: -20px;
    width: 450px;
}

div.belakangTengah {
    position: absolute;
    bottom: 125px;
    left: -20px;
    width: 450px;
}

div.belakangBawah {
    position: absolute;
    bottom: 90px;
    left: -20px;
    width: 450px;
}

div.kananAtas {
    position: absolute;
    top: 80px;
    left: -180px;
    width: 450px;
}

div.kananTengah {
    position: absolute;
    top: 110px;
    left: -40px;
    width: 450px;
}

div.kananBawah {
    position: absolute;
    bottom: 80px;
    left: -20px;
    width: 450px;
}

div.kiriAtas {
    position: absolute;
    top: 75px;
    left: 130px;
    width: 450px;
}

div.kiriTengah {
    position: absolute;
    top: 110px;
    left: -5px;
    width: 450px;
}

div.kiriBawah {
    position: absolute;
    bottom: 80px;
    left: -30px;
    width: 450px;
}

div.atasKiri {
    position: absolute;
    top: 70px;
    left: -40px;
    width: 450px;
}

div.atasKanan {
    position: absolute;
    bottom:120px;
    left: -40px;
    width: 450px;
}

div.depanAtasB {
    position: absolute;
    top: 110px;
    left: -25px;
    width: 450px;   
}

div.depanTengahB {
    position: absolute;
    top: 140px;
    left: -25px;
    width: 450px; 
}

div.depanBawahB {
	position: absolute;
    bottom: 60px;
    left: 0px;
    width: 100%;
}

div.belakangAtasB {
    position: absolute;
    bottom: 150px;
    left: -20px;
    width: 450px;
}

div.belakangTengahB {
    position: absolute;
    bottom: 110px;
    left: -20px;
    width: 450px;
}

div.belakangBawahB {
    position: absolute;
    bottom: 65px;
    left: -20px;
    width: 450px;
}

div.kananAtasB {
    position: absolute;
    top: 85px;
    left: -140px;
    width: 450px;
}

div.kananTengahB {
    position: absolute;
    top: 110px;
    left: -40px;
    width: 450px;
}

div.kananBawahB {
    position: absolute;
    bottom: 80px;
    left: -5px;
    width: 450px;
}

div.kiriAtasB {
    position: absolute;
    top: 85px;
    left: 85px;
    width: 450px;
}

div.kiriTengahB {
    position: absolute;
    top: 110px;
    left: -15px;
    width: 450px;
}

div.kiriBawahB {
    position: absolute;
    bottom: 80px;
    left: -40px;
    width: 450px;
}

div.atasKiriB {
    position: absolute;
    top: 60px;
    left: -40px;
    width: 450px;
}

div.atasKananB {
    position: absolute;
    bottom:120px;
    left: -45px;
    width: 450px;
}


.box {
      width: 600px;
      height: 80px;
      padding: 15px;
      border: 5px solid red;
      margin: 20px;
      background-color: yellow;
      display:none;
}

</style>
</asp:Content>