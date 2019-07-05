<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="editChecklist.aspx.vb" Inherits="editChecklist" %>

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
                <td><asp:Label ID="nopol" runat="server"></asp:Label></td>
            </tr>
            <tr height="30px">
                <td><b>Nama Customer</b></td>
                <td>&nbsp : &nbsp</td>
                <td><asp:Label ID="nmCustomer" runat="server"></asp:Label></td>
            </tr>
               <tr height="30px">
                <td><b>No Rangka</b></td>
                <td>&nbsp : &nbsp</td>
                <td><asp:Label ID="noRangka" runat="server"></asp:Label>	</td>
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
                <td><asp:TextBox ID="ordometer" class="form-control required" runat="server">
                    </asp:TextBox><asp:Label ID="ordometerNotice" runat="server" style="color:red"></asp:Label>
                </td>
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
							<asp:DropDownList ID="bensin" runat="server">
								<asp:ListItem>0%</asp:ListItem>
								<asp:ListItem>5%</asp:ListItem>
								<asp:ListItem>10%</asp:ListItem>
								<asp:ListItem>15%</asp:ListItem>
								<asp:ListItem>20%</asp:ListItem>
								<asp:ListItem>25%</asp:ListItem>
								<asp:ListItem>30%</asp:ListItem>
								<asp:ListItem>35%</asp:ListItem>
								<asp:ListItem>40%</asp:ListItem>
								<asp:ListItem>45%</asp:ListItem>
								<asp:ListItem>50%</asp:ListItem>
								<asp:ListItem>55%</asp:ListItem>
								<asp:ListItem>60%</asp:ListItem>
								<asp:ListItem>65%</asp:ListItem>
								<asp:ListItem>70%</asp:ListItem>
								<asp:ListItem>75%</asp:ListItem>
								<asp:ListItem>80%</asp:ListItem>
								<asp:ListItem>85%</asp:ListItem>
								<asp:ListItem>90%</asp:ListItem>
								<asp:ListItem>95%</asp:ListItem>
								<asp:ListItem>100%</asp:ListItem>
							</asp:DropDownList> 
						</td>
                    </tr>    
                    <tr>
                        <th class="col-md-2" style="text-align:center"><br />Battery</th>
                        <td colspan="3">
							<asp:RadioButtonList ID="kondisiBaterai" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
							<asp:ListItem> Good</asp:ListItem>
							<asp:ListItem> Good &amp; Recharge</asp:ListItem>
							<asp:ListItem> Bad &amp; Replace</asp:ListItem>
							</asp:RadioButtonList>
						</td>
                    </tr>    
                    <tr>
                        <th rowspan="9" class="col-md-2" style="text-align:center"><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Ban</th>
                        <td rowspan="3" class="text-center">Depan</td>
                        <td style="text-align:center"><strong>Kiri</strong></td>
                        <td style="text-align:center"><strong>Kanan</strong></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="banDepanKiri" class="form-control" runat="server" placeholder="mm"></asp:TextBox></td>
						<td><asp:TextBox ID="banDepanKanan" class="form-control" runat="server" placeholder="mm"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:RadioButtonList ID="kondisiBanDepanKiri" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem> Baik</asp:ListItem>
								<asp:ListItem> Tidak Baik</asp:ListItem>
							</asp:RadioButtonList>
                        </td>
                        <td><asp:RadioButtonList ID="kondisiBanDepanKanan" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem> Baik</asp:ListItem>
								<asp:ListItem> Tidak Baik</asp:ListItem>
							</asp:RadioButtonList>
                       </td>
                    </tr>
                    <tr>
                        <td align="center">Keterangan</td>
                        <td colspan="2"><asp:TextBox ID="keteranganBanDepan" class="form-control" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="center" rowspan="3">Belakang</td>
                        <td style="text-align:center"><strong>Kiri</strong></td>
                        <td style="text-align:center"><strong>Kanan</strong></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="banBelakangKiri" class="form-control" runat="server" placeholder="mm"></asp:TextBox></td>
						<td><asp:TextBox ID="banBelakangKanan" class="form-control" runat="server" placeholder="mm"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:RadioButtonList ID="kondisiBanBelakangKiri" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem> Baik</asp:ListItem>
								<asp:ListItem> Tidak Baik</asp:ListItem>
							</asp:RadioButtonList>
                        </td>
                        <td><asp:RadioButtonList ID="kondisiBanBelakangKanan" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem> Baik</asp:ListItem>
								<asp:ListItem> Tidak Baik</asp:ListItem>
							</asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">Keterangan</td>
                        <td colspan="2"><asp:TextBox ID="keteranganBanBelakang"  class="form-control" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                       <td align="center" colspan="3" style="background-color:#E8E8E8"><b>Standard Minimum 1.6 mm</b></td>
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
				<table class="table table-bordered striped" align="left">
					<thead style="background-color:#E8E8E8">
						<th style="text-align:center">Kelengkapan</th>
						<th style="text-align:center">Ada / Tidak Ada</th>
						<th style="text-align:center">Keterangan</th>
					</thead>
					<tbody>
						<tr>
							<td>STNK</td>
							<td align="center"><asp:CheckBox ID="stnkMasuk" onclick="stnkMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="stnk" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Cassette, CD, VCD, DVD</td>
							<td align="center"><asp:CheckBox ID="kasetMasuk" onclick="kasetMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="kaset" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Uang</td>
							<td align="center"><asp:CheckBox ID="uangMasuk" onclick="uangMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="uang" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Pemantik Api / Charger</td>
							<td align="center"><asp:CheckBox ID="pemantikApiMasuk" onclick="pemantikApiMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="pemantikApi" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Karpet (Jumlah)</td>
							<td align="center"><asp:CheckBox ID="karpetMasuk" onclick="karpetMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="karpet" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Buku Service</td>
							<td align="center"><asp:CheckBox ID="bukuServiceMasuk" onclick="bukuServiceMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="bukuService" runat="server" class="form-control" style="display:none;"></asp:TextBox> </td>
						</tr>
						<tr>
							<td>Dop Roda / Velg</td>
							<td align="center"><asp:CheckBox ID="velgMasuk" onclick="velgMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="velg" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Buku / Dokumen / Surat / Koran</td>
							<td align="center"><asp:CheckBox ID="bukuMasuk" onclick="bukuMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="buku"  class="form-control" runat="server" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Tool Kit Set</td>
							<td align="center"><asp:CheckBox ID="toolKitMasuk" onclick="toolKitMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="toolKit" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Dongkrak</td>
							<td align="center"><asp:CheckBox ID="dongkrakMasuk" onclick="dongkrakMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="dongkrak" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Ban Cadangan</td>
							<td align="center"><asp:CheckBox ID="banMasuk" onclick="banMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="ban" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Cover Ban Cadangan</td>
							<td align="center"><asp:CheckBox ID="coverBanMasuk" onclick="coverBanMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="coverBan" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Instrumen Panel</td>
							<td align="center"><asp:CheckBox ID="panelMasuk" onclick="panelMasuk1()" runat="server" /></td>
							<td><asp:RadioButtonList ID="panel" runat="server" style="display:none;" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
							    <asp:ListItem> Berfungsi</asp:ListItem>
							    <asp:ListItem> Tidak Berfungsi</asp:ListItem>
							    </asp:RadioButtonList>
                            </td>
						</tr>
						<tr>
							<td>Power Window</td>
							<td align="center"><asp:CheckBox ID="powerWindowMasuk" onclick="powerWindowMasuk1()" runat="server" /></td>
							<td><asp:RadioButtonList ID="powerWindow" runat="server" style="display:none;" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
							    <asp:ListItem> Berfungsi</asp:ListItem>
							    <asp:ListItem> Tidak Berfungsi</asp:ListItem>
							    </asp:RadioButtonList>
                            </td>
						</tr>
						<tr>
							<td>Central Lock / Alarm</td>
							<td align="center"><asp:CheckBox ID="centralLockMasuk" onclick="centralLockMasuk1()" runat="server" /></td>
							<td><asp:RadioButtonList ID="centralLock" runat="server" style="display:none;" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
							    <asp:ListItem> Berfungsi</asp:ListItem>
							    <asp:ListItem> Tidak Berfungsi</asp:ListItem>
							    </asp:RadioButtonList></td>
						</tr>
						<tr>
							<td>Wiper</td>
							<td align="center"><asp:CheckBox ID="wiperMasuk" onclick="wiperMasuk1()" runat="server" /></td>
							<td><asp:RadioButtonList ID="wiper" runat="server" style="display:none;" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
							    <asp:ListItem> Berfungsi</asp:ListItem>
							    <asp:ListItem> Tidak Berfungsi</asp:ListItem>
							    </asp:RadioButtonList>
                            </td>
						</tr>
						<tr>
							<td>Radio / Tape</td>
							<td align="center"><asp:CheckBox ID="radioMasuk" onclick="radioMasuk1()" runat="server" /></td>
							<td><asp:RadioButtonList ID="radio" runat="server" style="display:none;" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
							    <asp:ListItem> Berfungsi</asp:ListItem>
							    <asp:ListItem> Tidak Berfungsi</asp:ListItem>
							    </asp:RadioButtonList>
                            </td>
						</tr>
						<tr>
							<td>CD Charger / TV</td>
							<td align="center"><asp:CheckBox ID="cdMasuk" onclick="cdMasuk1()" runat="server" /></td>
							<td><asp:RadioButtonList ID="cd" runat="server" style="display:none;" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
							    <asp:ListItem> Berfungsi</asp:ListItem>
							    <asp:ListItem> Tidak Berfungsi</asp:ListItem>
							    </asp:RadioButtonList>
                            </td>
						</tr>
						<tr>
							<td>Air Conditioner</td>
							<td align="center"><asp:CheckBox ID="acMasuk" onclick="acMasuk1()" runat="server" /></td>
							<td><asp:RadioButtonList ID="ac" runat="server" style="display:none;" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
							    <asp:ListItem> Berfungsi</asp:ListItem>
							    <asp:ListItem> Tidak Berfungsi</asp:ListItem>
							    </asp:RadioButtonList>
                            </td>
						</tr>
						<tr>
							<td>Rem Tangan</td>
							<td align="center"><asp:CheckBox ID="remTanganMasuk" onclick="remTanganMasuk1()" runat="server" /></td>
							<td><asp:RadioButtonList ID="remTangan" runat="server" style="display:none;" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
							    <asp:ListItem> Berfungsi</asp:ListItem>
							    <asp:ListItem> Tidak Berfungsi</asp:ListItem>
							    </asp:RadioButtonList>
                            </td>
						</tr>
                         <tr>
							<td>Lain-lain 1</td>
							<td align="center"><asp:CheckBox ID="Lain1" onclick="lain1()" runat="server" /></td>
							<td><asp:TextBox ID="keteranganLain1" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
                        <tr>
							<td>Lain-lain 2</td>
							<td align="center"><asp:CheckBox ID="Lain2" onclick="lain2()" runat="server" /></td>
							<td><asp:TextBox ID="keteranganLain2" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
                        <tr>
							<td>Lain-lain 3</td>
							<td align="center"><asp:CheckBox ID="Lain3" onclick="lain3()" runat="server" /></td>
							<td><asp:TextBox ID="keteranganLain3" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
					</tbody>
				</table>
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
					            <!-- Bemper Depan Atas -->
								<div class="depanAtasA">
                                    <asp:CheckBox  name="askDepanAtas1" ID="askDepanAtas1A" onclick="depanAtas1A()" runat="server" />
									<!-- Bemper Depan Atas 1 -->
									&nbsp;<asp:DropDownList style="position:absolute; margin-left:100px; margin-top:-50px; display:none;" ID="depanAtas1A" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Atas 2 -->
									<asp:CheckBox style="margin-left:25px;" name="askDepanAtas2" value="1" ID="askDepanAtas2A" onclick="depanAtas2A()" runat="server" />
                                    &nbsp;<asp:DropDownList ID="depanAtas2A" style="position:absolute; margin-left:155px; margin-top:-50px; display:none;  " runat="server">
                                            <asp:ListItem Value="X">X</asp:ListItem>
                                            <asp:ListItem Value="V">V</asp:ListItem>
                                            <asp:ListItem Value="O">O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Atas 3 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanAtas3" id="askDepanAtas3A" onclick="depanAtas3A()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:205px; margin-top:-50px; display:none;" ID="depanAtas3A" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                               
                                	<!-- Bemper Depan Atas 4 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanAtas4" id="askDepanAtas4A" onclick="depanAtas4A()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:255px; margin-top:-50px; display:none;" ID="depanAtas4A" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                	<!-- Bemper Depan Atas 5 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanAtas5" id="askDepanAtas5A" onclick="depanAtas5A()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:305px; margin-top:-50px; display:none;" ID="depanAtas5A" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <!-- Bemper Depan Tengah 1-->
								<div class="depanTengahA">
                                    <asp:CheckBox  name="askDepanTengah1" ID="askDepanTengah1A" onclick="depanTengah1A()" runat="server" />
									<!-- Bemper Depan Atas 1 -->
									&nbsp;<asp:DropDownList style="position:absolute; margin-left:130px; margin-top:-40px; display:none;" ID="depanTengah1A" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Tengah 2 -->
									<asp:CheckBox style="margin-left:25px;" name="askDepanTengah2" ID="askDepanTengah2A" onclick="depanTengah2A()" runat="server" />
                                    &nbsp;<asp:DropDownList ID="depanTengah2A" style="position:absolute; margin-left:180px; margin-top:-40px;  display:none;  " runat="server">
                                            <asp:ListItem Value="X">X</asp:ListItem>
                                            <asp:ListItem Value="V">V</asp:ListItem>
                                            <asp:ListItem Value="O">O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Tengah 3 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanTengah3" id="askDepanTengah3A" onclick="depanTengah3A()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:230px; margin-top:-40px; display:none;" ID="depanTengah3A" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                               
                                	<!-- Bemper Depan Tengah 4 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanTengah4" id="askDepanTengah4A" onclick="depanTengah4()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:280px; margin-top:-40px; display:none;" ID="depanTengah4A" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                              
                                	<!-- Bemper Depan Tengah 5 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanTengah5" id="askDepanTengah5A" onclick="depanTengah5A()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:330px; margin-top:-40px; display:none;" ID="depanTengah5A" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
							
								<!-- Bemper Depan Bawah -->
								<div class="depanBawahA">
									<!-- Bemper Depan Bawah 1 -->
                                    <asp:CheckBox runat="server" name="askDepanBawah1" id="askDepanBawah1A" onclick="depanBawah1A()" value="1"/>
						            &nbsp;<asp:DropDownList ID="depanBawah1A" runat="server"  style="position:absolute; margin-left:75px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
	
									<!-- Bemper Depan Bawah 2 -->	
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanBawah2" id="askDepanBawah2A" onclick="depanBawah2A()" value="1"/>
								    &nbsp;<asp:DropDownList ID="depanBawah2A"  style="position:absolute; margin-left:125px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Bawah 3 -->	
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanBawah3" id="askDepanBawah3A" onclick="depanBawah3A()" value="1"/>								
                                    &nbsp;<asp:DropDownList ID="depanBawah3A"  style="position:absolute; margin-left:175px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Bemper Depan Bawah 4 -->	
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanBawah4" id="askDepanBawah4A" onclick="depanBawah4A()" value="1"/>								
                                    &nbsp;<asp:DropDownList ID="depanBawah4A"  style="position:absolute; margin-left:225px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Bemper Depan Bawah 5 -->	
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanBawah5" id="askDepanBawah5A" onclick="depanBawah5A()" value="1"/>								
                                    &nbsp;<asp:DropDownList ID="depanBawah5A"  style="position:absolute; margin-left:275px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
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
								<div class="belakangAtasA">
									<!-- Belakang Atas 1 -->
                                    <asp:CheckBox runat="server" name="askBelakangAtas1" id="askBelakangAtas1A" onclick="belakangAtas1A()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangAtas1A" style="position:absolute; margin-left:100px; margin-top:-45px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Atas 2 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangAtas2" id="askBelakangAtas2A" onclick="belakangAtas2A()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangAtas2A" style="position:absolute; margin-left:150px; margin-top:-45px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Atas 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangAtas3" id="askBelakangAtas3A" onclick="belakangAtas3A()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangAtas3A" style="position:absolute; margin-left:190px; margin-top:-45px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Atas 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangAtas4" id="askBelakangAtas4A" onclick="belakangAtas4A()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangAtas4A" style="position:absolute; margin-left:230px; margin-top:-45px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Atas 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangAtas5" id="askBelakangAtas5A" onclick="belakangAtas5A()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangAtas5A" style="position:absolute; margin-left:270px; margin-top:-45px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Atas 6 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangAtas6" id="askBelakangAtas6A" onclick="belakangAtas6A()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangAtas6A" style="position:absolute; margin-left:310px; margin-top:-45px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
			
								</div>

                                <div class="belakangTengahA">
									<!-- Belakang Tengah 1 -->
                                    <asp:CheckBox runat="server" name="askBelakangTengah1" id="askBelakangTengah1A" onclick="belakangTengah1A()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangTengah1A" style="position:absolute; margin-left:100px; margin-top:-5px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Tengah 2 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangTengah2" id="askBelakangTengah2A" onclick="belakangTengah2A()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangTengah2A" style="position:absolute; margin-left:150px; margin-top:-5px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Tengah 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangTengah3" id="askBelakangTengah3A" onclick="belakangTengah3A()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangTengah3A" style="position:absolute; margin-left:190px; margin-top:-5px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Tengah 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangTengah4" id="askBelakangTengah4A" onclick="belakangTengah4A()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangTengah4A" style="position:absolute; margin-left:230px; margin-top:-5px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Tengah 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangTengah5" id="askBelakangTengah5A" onclick="belakangTengah5A()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangTengah5A" style="position:absolute; margin-left:270px; margin-top:-5px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Tengah 6 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangTengah6" id="askBelakangTengah6A" onclick="belakangTengah6A()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangTengah6A" style="position:absolute; margin-left:310px; margin-top:-5px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
								</div>

								<!-- Belakang Bawah -->
								<div class="belakangBawahA">
									<!-- Belakang Bawah 1 -->
                                    <asp:CheckBox runat="server"  name="askBelakangBawah1" id="askBelakangBawah1A" onclick="belakangBawah1A()" value="1"/> 
	                                &nbsp;<asp:DropDownList ID="belakangBawah1A"  style="position:absolute; margin-left:100px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Bawah 2 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangBawah2" id="askBelakangBawah2A" onclick="belakangBawah2A()" value="1"/> 
	                                &nbsp;<asp:DropDownList ID="belakangBawah2A"  style="position:absolute; margin-left:150px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Bawah 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangBawah3" id="askBelakangBawah3A" onclick="belakangBawah3A()" value="1"/> 
	                                &nbsp;<asp:DropDownList ID="belakangBawah3A" style="position:absolute; margin-left:190px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Bawah 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangBawah4" id="askBelakangBawah4A" onclick="belakangBawah4A()" value="1"/> 
	                                &nbsp;<asp:DropDownList ID="belakangBawah4A" style="position:absolute; margin-left:230px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Bawah 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangBawah5" id="askBelakangBawah5A" onclick="belakangBawah5A()" value="1"/> 
	                                &nbsp;<asp:DropDownList ID="belakangBawah5A" style="position:absolute; margin-left:270px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Bawah 6 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;"  name="askBelakangBawah6" id="askBelakangBawah6A" onclick="belakangBawah6A()" value="1"/> 
	                                &nbsp;<asp:DropDownList ID="belakangBawah6A"  style="position:absolute; margin-left:310px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
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
							    <div class="kananAtasA">
                                    <asp:CheckBox runat="server" name="askKananAtas" id="askKananAtasA" onclick="kananAtasA()" value="1"/> 
                                    &nbsp;<asp:DropDownList style="position:absolute; margin-left:205px; margin-top:-45px; display:none;" ID="kananAtasA" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							    </div>
							
							    <!-- Kanan Tengah -->
							    <div class="kananTengahA">
								    <!-- Kanan Tengah 1 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah1" id="askKananTengah1A" onclick="kananTengah1A()" value="1"/> 
							        &nbsp;<asp:DropDownList ID="kananTengah1A"  style="position:absolute; margin-left:40px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
								
								    <!-- Kanan Tengah 2 -->
                                    <asp:CheckBox runat="server" style="margin-left:15px;" name="askKananTengah2" id="askKananTengah2A" onclick="kananTengah2A()" value="1"/> 
							        &nbsp;<asp:DropDownList ID="kananTengah2A" style="position:absolute; margin-left:100px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
			
								    <!-- Kanan Tengah 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah3" id="askKananTengah3A" onclick="kananTengah3A()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah3A" style="position:absolute; margin-left:135px; margin-top:-70px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

								
								    <!-- Kanan Tengah 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah4" id="askKananTengah4A" onclick="kananTengah4A()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah4A" style="position:absolute; margin-left:160px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
		
                                    <!-- Kanan Tengah 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah5" id="askKananTengah5A" onclick="kananTengah5A()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute;  margin-left:190px; margin-top:-70px;  display:none;" ID="kananTengah5A" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
						
								    <!-- Kanan Tengah 6 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah6" id="askKananTengah6A" onclick="kananTengah6A()" value="1"/>
                                    &nbsp;<asp:DropDownList style="position:absolute; margin-left:220px; margin-top:-45px; display:none;" ID="kananTengah6A" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
								    <!-- Kanan Tengah 7 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah7" id="askKananTengah7A" onclick="kananTengah7A()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah7A"  style="position:absolute; margin-left:250px; margin-top:-70px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
								
								    <!-- Kanan Tengah 8 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah8" id="askKananTengah8A" onclick="kananTengah8A()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah8A" style="position:absolute; margin-left:280px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Kanan Tengah 9 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askKananTengah9" id="askKananTengah9A" onclick="kananTengah9A()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah9A" style="position:absolute; margin-left:310px; margin-top:-70px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Kanan Tengah 10 -->
                                    <asp:CheckBox runat="server" style="margin-left:15px;" name="askKananTengah10" id="askKananTengah10A" onclick="kananTengah10A()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah10A" style="position:absolute; margin-left:350px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							    </div>
							
							    <!-- Kanan Bawah -->
							    <div class="kananBawahA">
								    <!-- Kanan Bawah 1 -->
                                    <asp:CheckBox runat="server" name="askKananBawah1" id="askKananBawah1A" onclick="kananBawah1A()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananBawah1A"  style="position:absolute; margin-left:40px; margin-top:0px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
								
								    <!-- Kanan Bawah 2 -->
                                    <asp:CheckBox runat="server" style="margin-left:20px;" name="askKananBawah2" id="askKananBawah2A" onclick="kananBawah2A()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananBawah2A"  style="position:absolute; margin-left:90px; margin-top:0px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
						
								    <!-- Kanan Bawah 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:20px;" name="askKananBawah3" id="askKananBawah3A" onclick="kananBawah3A()" value="1"/>
                                    &nbsp;<asp:DropDownList style="position:absolute; margin-left:135px; margin-top:20px; display:none;" ID="kananBawah3A" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
								    <!-- Kanan Bawah 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askKananBawah4" id="askKananBawah4A" onclick="kananBawah4A()" value="1"/> 
                                    &nbsp;<asp:DropDownList ID="kananBawah4A" runat="server" style="position:absolute; margin-left:170px; margin-top:0px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
	
								    <!-- Kanan Bawah 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananBawah5" id="askKananBawah5A" onclick="kananBawah5A()" value="1"/> 
                                    &nbsp;<asp:DropDownList ID="kananBawah5A" style="position:absolute; margin-left:195px; margin-top:25px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
                                    <!-- Kanan Bawah 6 -->
                                    <asp:CheckBox runat="server"  style="margin-left:5px;" name="askKananBawah6" id="askKananBawah6A" onclick="kananBawah6A()" value="1"/> 
                                    &nbsp;<asp:DropDownList ID="kananBawah6A" runat="server"  style="position:absolute; margin-left:230px; margin-top:0px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
								    <!-- Kanan Bawah 7 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askKananBawah7" id="askKananBawah7A" onclick="kananBawah7A()" value="1"/> 
								    &nbsp;<asp:DropDownList ID="kananBawah7A" runat="server" style="position:absolute; margin-left:260px; margin-top:25px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Kanan Bawah 8 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askKananBawah8" id="askKananBawah8A" onclick="kananBawah8A()" value="1"/> 
								    &nbsp;<asp:DropDownList ID="kananBawah8A" runat="server" style="position:absolute; margin-left:295px; margin-top:0px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Kanan Bawah 9 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askKananBawah9" id="askKananBawah9A" onclick="kananBawah9A()" value="1"/> 
								    &nbsp;<asp:DropDownList ID="kananBawah9A" runat="server" style="position:absolute; margin-left:335px; margin-top:25px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Kanan Bawah 10 -->
                                    <asp:CheckBox runat="server" style="margin-left:15px;" name="askKananBawah10" id="askKananBawah10A" onclick="kananBawah10A()" value="1"/> 
								    &nbsp;<asp:DropDownList ID="kananBawah10A" runat="server" style="position:absolute; margin-left:375px; margin-top:0px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
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
							<div class="kiriAtasA">
                                <asp:CheckBox runat="server" ID="askKiriAtasA" onclick="kiriAtasA()" value="1"/> 
							    &nbsp;<asp:DropDownList ID="kiriAtasA" runat="server" style="position:absolute; margin-left:215px; margin-top:-45px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							</div>
							
							<!-- Kiri Tengah -->
							<div class="kiriTengahA">
								<!-- Kiri Tengah 1 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah1" id="askKiriTengah1A" onclick="kiriTengah1A()" value="1"/> 
					            &nbsp;<asp:DropDownList ID="kiriTengah1A" style="position:absolute; margin-left:60px; margin-top:-55px; display:none" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Tengah 2 -->
                                <asp:CheckBox runat="server" style="margin-left:20px;" name="askKiriTengah2" id="askKiriTengah2A" onclick="kiriTengah2A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah2A" runat="server"  style="position:absolute; margin-left:100px; margin-top:-80px; display:none">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
                                <!-- Kiri Tengah 3 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askKiriTengah3" id="askKiriTengah3A" onclick="kiriTengah3A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah3A" runat="server" style="position:absolute; margin-left:135px; margin-top:-55px; display:none">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							
								<!-- Kiri Tengah 4 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah4" id="askKiriTengah4A" onclick="kiriTengah4A()" value="1"/> 					
						        &nbsp;<asp:DropDownList ID="kiriTengah4A" runat="server"  style="position:absolute; margin-left:160px; margin-top:-80px; display:none">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							
								<!-- Kiri Tengah 5 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah5" id="askKiriTengah5A" onclick="kiriTengah5A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah5A" runat="server"  style="position:absolute; margin-left:195px; margin-top:-55px; display:none">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Tengah 6 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah6" id="askKiriTengah6A" onclick="kiriTengah6A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah6A" runat="server"  style="position:absolute; margin-left:220px;  margin-top:-80px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
                                <!-- Kiri Tengah 7 -->
                                <asp:CheckBox runat="server" style="margin-left:3px;" name="askKiriTengah7" id="askKiriTengah7A" onclick="kiriTengah7A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah7A"  style="position:absolute; margin-left:260px;  margin-top:-55px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
                                <!-- Kiri Tengah 8 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah8" id="askKiriTengah8A" onclick="kiriTengah8A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah8A" style="position:absolute; margin-left:290px; margin-top:-80px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                 <!-- Kiri Tengah 9 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriTengah9" id="askKiriTengah9A" onclick="kiriTengah9A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah9A" style="position:absolute; margin-left:320px; margin-top:-105px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                  <!-- Kiri Tengah 10 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriTengah10" id="askKiriTengah10A" onclick="kiriTengah10A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah10A" style="position:absolute; margin-left:370px; margin-top:-45px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							</div>
							
							<!-- Kiri Bawah -->
							<div class="kiriBawahA">
								<!-- Kiri Bawah 1 -->
                                <asp:CheckBox runat="server" name="askKiriBawah1" id="askKiriBawah1A" onclick="kiriBawah1A()" value="1"/> 
							    &nbsp;<asp:DropDownList ID="kiriBawah1A" style="position:absolute; margin-left:35px; margin-top:0px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 2 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriBawah2" id="askKiriBawah2A" onclick="kiriBawah2A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah2A" runat="server" style="position:absolute; margin-left:85px; margin-top:0px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							
								<!-- Kiri Bawah 3 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriBawah3" id="askKiriBawah3A" onclick="kiriBawah3A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah3A" style="position:absolute; margin-left:125px; margin-top:25px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 4 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askKiriBawah4" id="askKiriBawah4A" onclick="kiriBawah4A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah4A" style="position:absolute;  margin-left:150px; margin-top:0px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 5 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriBawah5" id="askKiriBawah5A" onclick="kiriBawah5A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah5A" style="position:absolute; margin-left:185px; margin-top:25px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 6 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriBawah6" id="askKiriBawah6A" onclick="kiriBawah6A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah6A" style="position:absolute; margin-left:215px; margin-top:0px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 7 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriBawah7" id="askKiriBawah7A" onclick="kiriBawah7A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah7A" style="position:absolute; margin-left:250px; margin-top:25px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                <!-- Kiri Bawah 8 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askKiriBawah8" id="askKiriBawah8A" onclick="kiriBawah8A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah8A"  style="position:absolute; margin-left:280px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                <!-- Kiri Bawah 9 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriBawah9" id="askKiriBawah9A" onclick="kiriBawah9A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah9A"  style="position:absolute; margin-left:320px; margin-top:25px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                 <!-- Kiri Bawah 10 -->
                                <asp:CheckBox runat="server" style="margin-left:25px;" name="askKiriBawah10" id="askKiriBawah10A" onclick="kiriBawah10A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah10A"  style="position:absolute; margin-left:380px; margin-top:0px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
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
							<div class="atasKiriA">
								<!-- Atas Kiri 1 -->
                                <asp:CheckBox runat="server" name="askAtasKiri1" id="askAtasKiri1A" onclick="atasKiri1A()" value="1"/> 
						        &nbsp;<asp:DropDownList ID="atasKiri1A" style="position:absolute; margin-left:60px; margin-top:-45px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kiri 2 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKiri2" id="askAtasKiri2A" onclick="atasKiri2A()" value="1"/>
                                &nbsp;<asp:DropDownList ID="atasKiri2A" runat="server" style="position:absolute; margin-left:105px; margin-top:-75px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kiri 3 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKiri3" id="askAtasKiri3A" onclick="atasKiri3A()" value="1"/>
                                &nbsp;<asp:DropDownList ID="atasKiri3A" runat="server" style="position:absolute; margin-left:140px; margin-top:-45px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kiri 4 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKiri4" id="askAtasKiri4A" onclick="atasKiri4A()" value="1"/>
                                &nbsp;<asp:DropDownList ID="atasKiri4A" runat="server" style="position:absolute; margin-left:175px; margin-top:-75px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kiri 5 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKiri5" id="askAtasKiri5A" onclick="atasKiri5A()" value="1"/>
                                &nbsp;<asp:DropDownList ID="atasKiri5A" runat="server" style="position:absolute; margin-left:210px; margin-top:-45px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                <!-- Atas Kiri 6 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKiri6" id="askAtasKiri6A" onclick="atasKiri6A()" value="1"/>
                                &nbsp;<asp:DropDownList ID="AtasKiri6A" runat="server" style="position:absolute; margin-left:245px; margin-top:-75px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                	<!-- Atas Kiri 7 -->
                                <asp:CheckBox runat="server" style="margin-left:65px;" name="askAtasKiri7" id="askAtasKiri7A" onclick="atasKiri7A()" value="1"/>
                                &nbsp;<asp:DropDownList ID="AtasKiri7A" runat="server" style="position:absolute; margin-left:350px; margin-top:-45px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							</div>
							
							<!-- Atas Kanan -->
							<div class="atasKananA">
								<!-- Atas Kanan 1 -->
                                <asp:CheckBox runat="server" name="askAtasKanan1" id="askAtasKanan1A" onclick="atasKanan1A()" value="1"/> 
						        &nbsp;<asp:DropDownList ID="atasKanan1A" runat="server" style="position:absolute; margin-left:65px; margin-top:5px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

								<!-- Atas Kanan 2 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKanan2" id="askAtasKanan2A" onclick="atasKanan2()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan2A" runat="server" style="position:absolute; margin-left:105px; margin-top:30px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kanan 3 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKanan3" id="askAtasKanan3A" onclick="atasKanan3A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan3A" runat="server" style="position:absolute; margin-left:145px; margin-top:5px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							
								<!-- Atas Kanan 4 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKanan4" id="askAtasKanan4A" onclick="atasKanan4A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan4A" runat="server"  style="position:absolute; margin-left:180px; margin-top:30px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kanan 5 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKanan5" id="askAtasKanan5A" onclick="atasKanan5A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan5A" runat="server" style="position:absolute; margin-left:210px; margin-top:5px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>	

                                <!-- Atas Kanan 6 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKanan6" id="askAtasKanan6A" onclick="atasKanan6A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan6A" runat="server" style="position:absolute; margin-left:250px; margin-top:30px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>	

                                <!-- Atas Kanan 7 -->
                                <asp:CheckBox runat="server" style="margin-left:65px;" name="askAtasKanan7" id="askAtasKanan7A" onclick="atasKanan7A()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan7A" runat="server" style="position:absolute; margin-left:340px; margin-top:5px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>	
						    </div>
                            </div>
					    </center>	
                    </div>
                </div>
            </div>

             <!-- SEDAN --> 

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
					            <!-- Bemper Depan Atas -->
								<div class="depanAtasB">
                                    <asp:CheckBox  name="askDepanAtas1" ID="askDepanAtas1B" onclick="depanAtas1B()" runat="server" />
									<!-- Bemper Depan Atas 1 -->
									&nbsp;<asp:DropDownList style="position:absolute; margin-left:100px; margin-top:-50px; display:none;" ID="depanAtas1B" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Atas 2 -->
									<asp:CheckBox style="margin-left:25px;" name="askDepanAtas2" value="1" ID="askDepanAtas2B" onclick="depanAtas2B()" runat="server" />
                                    &nbsp;<asp:DropDownList ID="depanAtas2B" style="position:absolute; margin-left:155px; margin-top:-50px;  display:none;  " runat="server">
                                            <asp:ListItem Value="X">X</asp:ListItem>
                                            <asp:ListItem Value="V">V</asp:ListItem>
                                            <asp:ListItem Value="O">O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Atas 3 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanAtas3" id="askDepanAtas3B" onclick="depanAtas3B()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:205px; margin-top:-50px; display:none;" ID="depanAtas3B" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                               
                                	<!-- Bemper Depan Atas 4 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanAtas4" id="askDepanAtas4B" onclick="depanAtas4B()" value="1"/>
                                    &nbsp;<asp:DropDownList style="position:absolute; margin-left:255px; margin-top:-50px; display:none;" ID="depanAtas4B" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                	<!-- Bemper Depan Atas 5 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanAtas5" id="askDepanAtas5B" onclick="depanAtas5B()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:305px; margin-top:-50px; display:none;" ID="depanAtas5B" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <!-- Bemper Depan Tengah 1-->
								<div class="depanTengahB">
                                    <asp:CheckBox  name="askDepanTengah1" ID="askDepanTengah1B" onclick="depanTengah1B()" runat="server" />
									<!-- Bemper Depan Atas 1 -->
									&nbsp;<asp:DropDownList style="position:absolute; margin-left:130px; margin-top:-40px; display:none;" ID="depanTengah1B" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Tengah 2 -->
									<asp:CheckBox style="margin-left:25px;" name="askDepanTengah2" ID="askDepanTengah2B" onclick="depanTengah2B()" runat="server" />
                                    &nbsp;<asp:DropDownList ID="depanTengah2B" style="position:absolute; margin-left:180px; margin-top:-40px;  display:none;  " runat="server">
                                            <asp:ListItem Value="X">X</asp:ListItem>
                                            <asp:ListItem Value="V">V</asp:ListItem>
                                            <asp:ListItem Value="O">O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Tengah 3 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanTengah3" id="askDepanTengah3B" onclick="depanTengah3B()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:230px; margin-top:-40px; display:none;" ID="depanTengah3B" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                               
                                	<!-- Bemper Depan Tengah 4 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanTengah4" id="askDepanTengah4B" onclick="depanTengah4B()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:280px; margin-top:-40px; display:none;" ID="depanTengah4B" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                              
                                	<!-- Bemper Depan Tengah 5 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanTengah5" id="askDepanTengah5B" onclick="depanTengah5B()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:330px; margin-top:-40px; display:none;" ID="depanTengah5B" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
							
								<!-- Bemper Depan Bawah -->
								<div class="depanBawahB">
									<!-- Bemper Depan Bawah 1 -->
                                    <asp:CheckBox runat="server" name="askDepanBawah1" id="askDepanBawah1B" onclick="depanBawah1B()" value="1"/>
						            &nbsp;<asp:DropDownList ID="depanBawah1B" runat="server"  style="position:absolute; margin-left:75px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
	
									<!-- Bemper Depan Bawah 2 -->	
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanBawah2" id="askDepanBawah2B" onclick="depanBawah2B()" value="1"/>
								    &nbsp;<asp:DropDownList ID="depanBawah2B"  style="position:absolute; margin-left:125px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Bawah 3 -->	
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanBawah3" id="askDepanBawah3B" onclick="depanBawah3B()" value="1"/>								
                                    &nbsp;<asp:DropDownList ID="depanBawah3B"  style="position:absolute; margin-left:175px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Bemper Depan Bawah 4 -->	
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanBawah4" id="askDepanBawah4B" onclick="depanBawah4B()" value="1"/>								
                                    &nbsp;<asp:DropDownList ID="depanBawah4B"  style="position:absolute; margin-left:225px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Bemper Depan Bawah 5 -->	
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanBawah5" id="askDepanBawah5B" onclick="depanBawah5B()" value="1"/>								
                                    &nbsp;<asp:DropDownList ID="depanBawah5B"  style="position:absolute; margin-left:275px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
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
                                    <asp:CheckBox runat="server" name="askBelakangAtas1" id="askBelakangAtas1B" onclick="belakangAtas1B()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangAtas1B" style="position:absolute; margin-left:100px; margin-top:-50px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Belakang Atas 2 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askBelakangAtas2" id="askBelakangAtas2B" onclick="belakangAtas2B()" value="1"/> 
	                                &nbsp;<asp:DropDownList ID="belakangAtas2B" style="position:absolute; display:none; margin-left:155px; margin-top:-50px;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
														
									<!-- Belakang Atas 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askBelakangAtas3" id="askBelakangAtas3B" onclick="belakangAtas3B()" value="1"/> 
									&nbsp;<asp:DropDownList ID="belakangAtas3B" style="position:absolute; margin-left:205px; margin-top:-50px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
									<!-- Belakang Atas 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askBelakangAtas4" id="askBelakangAtas4B" onclick="belakangAtas4B()" value="1"/> 
									&nbsp;<asp:DropDownList ID="belakangAtas4B" style="position:absolute; margin-left:250px; margin-top:-50px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
									<!-- Belakang Atas 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askBelakangAtas5" id="askBelakangAtas5B" onclick="belakangAtas5B()" value="1"/> 
									&nbsp;<asp:DropDownList ID="belakangAtas5B" style="position:absolute; margin-left:300px; margin-top:-50px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
								</div>
								
                                <!-- Belakang Tengah -->
								<div class="belakangTengahB">
									<!-- Belakang Tengah 1 -->
                                    <asp:CheckBox runat="server" name="askBelakangTengah1" id="askBelakangTengah1B" onclick="belakangTengah1B()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangTengah1B" style="position:absolute; margin-left:130px; margin-top:-40px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Belakang Tengah 2 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askBelakangTengah2" id="askBelakangTengah2B" onclick="belakangTengah2B()" /> 
	                                &nbsp;<asp:DropDownList ID="belakangTengah2B" style="position:absolute; display:none; margin-left:180px; margin-top:-40px;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
													
									<!-- Belakang Tengah 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askBelakangTengah3" id="askBelakangTengah3B" onclick="belakangTengah3B()"/> 
									&nbsp;<asp:DropDownList ID="belakangTengah3B" style="position:absolute; margin-left:230px; margin-top:-40px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
									<!-- Belakang Tengah 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askBelakangTengah4" id="askBelakangTengah4B" onclick="belakangTengah4B()" value="1"/> 
									&nbsp;<asp:DropDownList ID="belakangTengah4B" style="position:absolute; margin-left:280px; margin-top:-40px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>						

                                <!-- Belakang Tengah 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askBelakangTengah5" id="askBelakangTengah5B" onclick="belakangTengah5B()" value="1"/> 
									&nbsp;<asp:DropDownList ID="belakangTengah5B" style="position:absolute; margin-left:330px; margin-top:-40px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
								</div>

								<!-- Belakang Bawah -->
								<div class="belakangBawahB">
									<!-- Belakang Bawah 1 -->
                                    <asp:CheckBox runat="server"  name="askBelakangBawah1" id="askBelakangBawah1B" onclick="belakangBawah1B()" /> 
	                                &nbsp;<asp:DropDownList ID="belakangBawah1B" style="position:absolute; margin-left:100px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Belakang Bawah 2-->
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askBelakangBawah2" id="askBelakangBawah2B" onclick="belakangBawah2B()" value="1"/> 
                                    &nbsp;<asp:DropDownList ID="belakangBawah2B" style="position:absolute; display:none; margin-left:150px;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Belakang Bawah 3-->
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askBelakangBawah3" id="askBelakangBawah3B" onclick="belakangBawah3B()" /> 
                                    &nbsp;<asp:DropDownList style="position:absolute; margin-left:200px; display:none;" ID="belakangBawah3B" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Bawah 4-->
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askBelakangBawah4" id="askBelakangBawah4B" onclick="belakangBawah4B()" /> 
                                    &nbsp;<asp:DropDownList style="position:absolute; margin-left:250px; display:none;" ID="belakangBawah4B" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Bawah 5-->
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askBelakangBawah5" id="askBelakangBawah5B" onclick="belakangBawah5B()" value="1"/> 
                                    &nbsp;<asp:DropDownList style="position:absolute; margin-left:300px; display:none;" ID="belakangBawah5B" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
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
                                    <asp:CheckBox runat="server" name="askKananAtas" id="askKananAtasB" onclick="kananAtasB()" value="1"/> 
                                    &nbsp;<asp:DropDownList style="position:absolute; margin-left:205px; margin-top:-45px; display:none;" ID="kananAtasB" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							    </div>
							
							    <!-- Kanan Tengah -->
							    <div class="kananTengahB">
								    <!-- Kanan Tengah 1 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah1" id="askKananTengah1B" onclick="kananTengah1B()" value="1"/> 
							        &nbsp;<asp:DropDownList ID="kananTengah1B"  style="position:absolute; margin-left:60px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
								
								    <!-- Kanan Tengah 2 -->
                                    <asp:CheckBox runat="server" style="margin-left:20px;" name="askKananTengah2" id="askKananTengah2B" onclick="kananTengah2B()" value="1"/> 
							        &nbsp;<asp:DropDownList ID="kananTengah2B" style="position:absolute; margin-left:130px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
			
								    <!-- Kanan Tengah 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askKananTengah3" id="askKananTengah3B" onclick="kananTengah3B()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah3B" style="position:absolute; margin-left:165px; margin-top:-70px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

								
								    <!-- Kanan Tengah 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah4" id="askKananTengah4B" onclick="kananTengah4B()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah4B" style="position:absolute; margin-left:190px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
		
                                    <!-- Kanan Tengah 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah5" id="askKananTengah5B" onclick="kananTengah5B()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute;  margin-left:220px; margin-top:-70px;  display:none;" ID="kananTengah5B" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
						
								    <!-- Kanan Tengah 6 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah6" id="askKananTengah6B" onclick="kananTengah6B()" value="1"/>
                                    &nbsp;<asp:DropDownList style="position:absolute; margin-left:250px; margin-top:-45px; display:none;" ID="kananTengah6B" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
								    <!-- Kanan Tengah 7 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah7" id="askKananTengah7B" onclick="kananTengah7B()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah7B"  style="position:absolute; margin-left:280px; margin-top:-70px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
								
								    <!-- Kanan Tengah 8 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah8" id="askKananTengah8B" onclick="kananTengah8B()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah8B" style="position:absolute; margin-left:320px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Kanan Tengah 9 -->
                                    <asp:CheckBox runat="server" style="margin-left:15px;" name="askKananTengah9" id="askKananTengah9B" onclick="kananTengah9B()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah9B" style="position:absolute; margin-left:340px; margin-top:-70px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							    </div>
							
							    <!-- Kanan Bawah -->
							    <div class="kananBawahB">
								    <!-- Kanan Bawah 1 -->
                                    <asp:CheckBox runat="server" name="askKananBawah1" id="askKananBawah1B" onclick="kananBawah1B()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananBawah1B"  style="position:absolute; margin-left:45px; margin-top:0px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
								
								    <!-- Kanan Bawah 2 -->
                                    <asp:CheckBox runat="server" style="margin-left:15px;" name="askKananBawah2" id="askKananBawah2B" onclick="kananBawah2B()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananBawah2B"  style="position:absolute; margin-left:95px; margin-top:0px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
						
								    <!-- Kanan Bawah 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:15px;" name="askKananBawah3" id="askKananBawah3B" onclick="kananBawah3B()" value="1"/>
                                    &nbsp;<asp:DropDownList style="position:absolute; margin-left:135px; margin-top:25px; display:none;" ID="kananBawah3B" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
								    <!-- Kanan Bawah 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askKananBawah4" id="askKananBawah4B" onclick="kananBawah4B()" value="1"/> 
                                    &nbsp;<asp:DropDownList ID="kananBawah4B" runat="server" style="position:absolute; margin-left:175px; margin-top:0px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
	
								    <!-- Kanan Bawah 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananBawah5" id="askKananBawah5B" onclick="kananBawah5B()" value="1"/> 
                                    &nbsp;<asp:DropDownList ID="kananBawah5B" style="position:absolute; margin-left:200px; margin-top:25px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
                                    <!-- Kanan Bawah 6 -->
                                    <asp:CheckBox runat="server"  style="margin-left:5px;" name="askKananBawah6" id="askKananBawah6B" onclick="kananBawah6B()" value="1"/> 
                                    &nbsp;<asp:DropDownList ID="kananBawah6B" runat="server"  style="position:absolute; margin-left:235px; margin-top:0px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
								    <!-- Kanan Bawah 7 -->
                                    <asp:CheckBox runat="server" style="margin-left:15px;" name="askKananBawah7" id="askKananBawah7B" onclick="kananBawah7B()" value="1"/> 
								    &nbsp;<asp:DropDownList ID="kananBawah7B" runat="server" style="position:absolute; margin-left:265px; margin-top:25px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Kanan Bawah 8 -->
                                    <asp:CheckBox runat="server" style="margin-left:15px;" name="askKananBawah8" id="askKananBawah8B" onclick="kananBawah8B()" value="1"/> 
								    &nbsp;<asp:DropDownList ID="kananBawah8B" runat="server" style="position:absolute; margin-left:300px; margin-top:0px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Kanan Bawah 9 -->
                                    <asp:CheckBox runat="server" style="margin-left:20px;" name="askKananBawah9" id="askKananBawah9B" onclick="kananBawah9B()" value="1"/> 
								    &nbsp;<asp:DropDownList ID="kananBawah9B" runat="server" style="position:absolute; margin-left:350px; margin-top:25px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
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
                                <asp:CheckBox runat="server" ID="askKiriAtasB" onclick="kiriAtasB()" value="1"/> 
							    &nbsp;<asp:DropDownList ID="kiriAtasB" runat="server" style="position:absolute; margin-left:220px; margin-top:-45px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							</div>
							
							<!-- Kiri Tengah -->
							<div class="kiriTengahB">
								<!-- Kiri Tengah 1 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah1" id="askKiriTengah1B" onclick="kiriTengah1B()" value="1"/> 
					            &nbsp;<asp:DropDownList ID="kiriTengah1B" style="position:absolute; margin-left:60px; margin-top:-55px; display:none" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Tengah 2 -->
                                <asp:CheckBox runat="server" style="margin-left:20px;" name="askKiriTengah2" id="askKiriTengah2B" onclick="kiriTengah2B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah2B" runat="server" style="position:absolute; margin-left:130px; margin-top:-80px; display:none">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
                                <!-- Kiri Tengah 3 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askKiriTengah3" id="askKiriTengah3B" onclick="kiriTengah3B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah3B" runat="server" style="position:absolute; margin-left:165px; margin-top:-55px; display:none">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							
								<!-- Kiri Tengah 4 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah4" id="askKiriTengah4B" onclick="kiriTengah4B()" value="1"/> 					
						        &nbsp;<asp:DropDownList ID="kiriTengah4B" runat="server" style="position:absolute; margin-left:190px; margin-top:-80px; display:none">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							
								<!-- Kiri Tengah 5 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah5" id="askKiriTengah5B" onclick="kiriTengah5B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="KiriTengah5B" runat="server" style="position:absolute; margin-left:220px; margin-top:-55px; display:none">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Tengah 6 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah6" id="askKiriTengah6B" onclick="kiriTengah6B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah6B" runat="server" style="position:absolute; margin-left:250px;  margin-top:-80px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
                                <!-- Kiri Tengah 7 -->
                                <asp:CheckBox runat="server" style="margin-left:3px;" name="askKiriTengah7" id="askKiriTengah7B" onclick="kiriTengah7B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah7B" style="position:absolute; margin-left:280px; margin-top:-55px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
                                <!-- Kiri Tengah 8 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah8" id="askKiriTengah8B" onclick="kiriTengah8B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah8B" style="position:absolute; margin-left:340px; margin-top:-40px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                 <!-- Kiri Tengah 9 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriTengah9" id="askKiriTengah9B" onclick="kiriTengah9B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah9B" style="position:absolute; margin-left:380px; margin-top:-30px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							</div>
							
							<!-- Kiri Bawah -->
							<div class="kiriBawahB">
								<!-- Kiri Bawah 1 -->
                                <asp:CheckBox runat="server" name="askKiriBawah1" id="askKiriBawah1B" onclick="kiriBawah1B()" value="1"/> 
							    &nbsp;<asp:DropDownList ID="kiriBawah1B" style="position:absolute; margin-left:45px; margin-top:0px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 2 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriBawah2" id="askKiriBawah2B" onclick="kiriBawah2B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah2B" runat="server" style="position:absolute; margin-left:95px; margin-top:0px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							
								<!-- Kiri Bawah 3 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriBawah3" id="askKiriBawah3B" onclick="kiriBawah3B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah3B" style="position:absolute; margin-left:135px; margin-top:25px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 4 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriBawah4" id="askKiriBawah4B" onclick="kiriBawah4B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah4B" style="position:absolute;  margin-left:175px; margin-top:0px;  display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 5 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askKiriBawah5" id="askKiriBawah5B" onclick="kiriBawah5B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah5B" style="position:absolute; margin-left:210px; margin-top:25px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 6 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriBawah6" id="askKiriBawah6B" onclick="kiriBawah6B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah6B" style="position:absolute; margin-left:245px; margin-top:0px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 7 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriBawah7" id="askKiriBawah7B" onclick="kiriBawah7B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah7B" style="position:absolute; margin-left:275px; margin-top:25px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                <!-- Kiri Bawah 8 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriBawah8" id="askKiriBawah8B" onclick="kiriBawah8B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah8B" style="position:absolute; margin-left:310px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                <!-- Kiri Bawah 9 -->
                                <asp:CheckBox runat="server" style="margin-left:20px;" name="askKiriBawah9" id="askKiriBawah9B" onclick="kiriBawah9B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah9B"  style="position:absolute; margin-left:360px; margin-top:25px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
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
                                <asp:CheckBox runat="server" name="askAtasKiri1" id="askAtasKiri1B" onclick="atasKiri1B()" value="1"/> 
						        &nbsp;<asp:DropDownList ID="atasKiri1B" style="position:absolute; margin-left:60px; margin-top:-45px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kiri 2 -->
                                <asp:CheckBox runat="server" style="margin-left:50px;" name="askAtasKiri2" id="askAtasKiri2B" onclick="atasKiri2B()" value="1"/>
                                &nbsp;<asp:DropDownList ID="atasKiri2B" runat="server" style="position:absolute; margin-left:135px; margin-top:-45px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kiri 3 -->
                                <asp:CheckBox runat="server" style="margin-left:35px;" name="askAtasKiri3" id="askAtasKiri3B" onclick="atasKiri3B()" value="1"/>
                                &nbsp;<asp:DropDownList ID="atasKiri3B" runat="server" style="position:absolute; margin-left:185px; margin-top:-45px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kiri 4 -->
                                <asp:CheckBox runat="server" style="margin-left:35px;" name="askAtasKiri4" id="askAtasKiri4B" onclick="atasKiri4B()" value="1"/>
                                &nbsp;<asp:DropDownList ID="atasKiri4B" runat="server" style="position:absolute; margin-left:240px; margin-top:-45px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kiri 5 -->
                                <asp:CheckBox runat="server" style="margin-left:80px;" name="askAtasKiri5" id="askAtasKiri5B" onclick="atasKiri5B()" value="1"/>
                                &nbsp;<asp:DropDownList ID="atasKiri5B" runat="server" style="position:absolute; margin-left:355px; margin-top:-45px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							</div>
							
							<!-- Atas Kanan -->
							<div class="atasKananB">
								<!-- Atas Kanan 1 -->
                                <asp:CheckBox runat="server" name="askAtasKanan1" id="askAtasKanan1B" onclick="atasKanan1B()" value="1"/> 
						        &nbsp;<asp:DropDownList ID="atasKanan1B" runat="server" style="position:absolute; margin-left:55px; margin-top:5px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

								<!-- Atas Kanan 2 -->
                                <asp:CheckBox runat="server" style="margin-left:60px;" name="askAtasKanan2" id="askAtasKanan2B" onclick="atasKanan2B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan2B" runat="server" style="position:absolute; margin-left:135px; margin-top:5px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kanan 3 -->
                                <asp:CheckBox runat="server" style="margin-left:35px;" name="askAtasKanan3" id="askAtasKanan3B" onclick="atasKanan3B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan3B" runat="server" style="position:absolute; margin-left:190px; margin-top:5px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							
								<!-- Atas Kanan 4 -->
                                <asp:CheckBox runat="server" style="margin-left:35px;" name="askAtasKanan4" id="askAtasKanan4B" onclick="atasKanan4B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan4B" runat="server"  style="position:absolute; margin-left:240px; margin-top:5px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kanan 5 -->
                                <asp:CheckBox runat="server" style="margin-left:90px;" name="askAtasKanan5" id="askAtasKanan5B" onclick="atasKanan5B()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan5B" runat="server" style="position:absolute; margin-left:360px; margin-top:5px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>	
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
                <asp:TextBox ID="catatan" maxlength="200" placeholder="Panjang catatan maksimal 200 karakter" class="form-control required" runat="server"></asp:TextBox>
            </div>
        </div>  

            <div class="row" style="margin-left:5px">
                <div class="col-lg-12">
                    <h4 class="page-header">
                        Diagnostik Noise
                    </h4>
                </div>
            </div>	
            <div style="margin-left:30px">
                <div class="form-group">
                    <label for="kelebihan">1. Jenis keluhan atau suara yang terdengar (contoh: menggelitik atau benturan bensin)?</label>
                    <asp:Label ID="Q11" style="color:red" runat="server"></asp:Label>
                    <asp:TextBox ID="Q1" maxlength="50" class="form-control required" runat="server"></asp:TextBox>
		        </div>  
		
                <div class="form-group">
		            <label for="kelebihan">2. Bagaimana kecepatan mobil saat keluhan atau suara-suara itu terdengar</label>
                    <asp:Label ID="Q22" style="color:red" runat="server"></asp:Label>
                    <asp:CheckBoxList style="margin-left:20px" ID="Q2" runat="server">
                        <asp:ListItem Value="1"> &nbsp (Saat pemanasan) 0 km/h</asp:ListItem>
                        <asp:ListItem Value="2"> &nbsp (Kecepatan sedang) 20-80 km/h</asp:ListItem>
                        <asp:ListItem Value="3"> &nbsp (Saat distarter) 0-5 km/h</asp:ListItem>
                        <asp:ListItem Value="4"> &nbsp (Kecepatan tinggi) &gt; 80 km/h</asp:ListItem>
                        <asp:ListItem Value="5"> &nbsp (Kecepatan rendah) 5-20 km/h</asp:ListItem>
                        <asp:ListItem Value="6"> &nbsp Kecepatan tertentu</asp:ListItem>
                    </asp:CheckBoxList>
                </div>  
                <div class="form-group">
	                <label for="kelebihan">3. Arah saat berkendara</label>
                    <asp:Label ID="Q33" style="color:red" runat="server"></asp:Label>
                    <asp:CheckBoxList style="margin-left:20px" ID="Q3" runat="server">
                        <asp:ListItem Value="1"> &nbsp Maju</asp:ListItem>
                        <asp:ListItem Value="2"> &nbsp Mundur</asp:ListItem>
                        <asp:ListItem Value="3"> &nbsp Di pinggir jalan / belokan</asp:ListItem>
                    </asp:CheckBoxList>
	            </div>  
                <div class="form-group">
		            <label for="kelebihan">4. Keadaan kecepatan (berkendara)</label>
                    <asp:Label ID="Q44" style="color:red" runat="server"></asp:Label>
                    <asp:CheckBoxList style="margin-left:20px" ID="Q4" runat="server">
                        <asp:ListItem Value="1"> &nbsp Saat menginjak gas</asp:ListItem>
                        <asp:ListItem Value="2"> &nbsp Saat mengerem/melambat</asp:ListItem>
                        <asp:ListItem Value="3"> &nbsp Saat melaju pada kecepatan tetap</asp:ListItem>
                    </asp:CheckBoxList>
	            </div>  
                <div class="form-group">
                    <label for="kelebihan">5. Kondisi jalan</label>
                    <asp:Label ID="Q55" style="color:red" runat="server"></asp:Label>
                    <asp:CheckBoxList style="margin-left:20px" ID="Q5" runat="server">
                        <asp:ListItem Value="1"> &nbsp Daerah tengah kota</asp:ListItem>
                        <asp:ListItem Value="2"> &nbsp Jalan tol</asp:ListItem>
                        <asp:ListItem Value="3"> &nbsp Jalan rusak/bergelombang</asp:ListItem>
                        <asp:ListItem Value="4"> &nbsp Tanjakan/turunan</asp:ListItem>
                    </asp:CheckBoxList>
	            </div>  
                <div class="form-group">
	                <label for="kelebihan">6. Bagian mobil tempat darimana suara itu terdengar (Kiri) (Kanan) (Tandai bila tahu)</label>
                    <asp:Label ID="Q66" style="color:red" runat="server"></asp:Label>
                    <asp:CheckBoxList style="margin-left:20px" ID="Q6" runat="server">
                        <asp:ListItem Value="1"> &nbsp Depan/Kompartemen mesin (Ki)(Ka)</asp:ListItem>
                        <asp:ListItem Value="2"> &nbsp Belakang/Interior (Ki)(Ka)</asp:ListItem>
                        <asp:ListItem Value="3"> &nbsp Depan/Interior (Ki)(Ka)</asp:ListItem>
                        <asp:ListItem Value="4"> &nbsp Belakang/Bagian Bawah (Ki)(Ka)</asp:ListItem>
                        <asp:ListItem Value="5"> &nbsp Depan/Bagian Bawah (Ki)(Ka)</asp:ListItem>
                        <asp:ListItem Value="6"> &nbsp Getaran</asp:ListItem>
                        <asp:ListItem Value="7"> &nbsp Suara angin</asp:ListItem>
                    </asp:CheckBoxList>
                </div>  
                <div class="form-group">
	                <label for="kelebihan">7. Kondisi-kondisi pengendaraan lain</label>
                    <asp:Label ID="Q77" style="color:red" runat="server"></asp:Label>
                    <asp:CheckBoxList style="margin-left:20px" ID="Q7" runat="server">
                        <asp:ListItem Value="1"> &nbsp A/C menyala</asp:ListItem>
                        <asp:ListItem Value="2"> &nbsp Saat setir diputar</asp:ListItem>
                        <asp:ListItem Value="3"> &nbsp Lain-lain</asp:ListItem>
                    </asp:CheckBoxList>
                </div>  
                <div class="form-group">
		            <label for="kelebihan">8. Seberapa sering suara/noise terdengar?</label>
                    <asp:Label ID="Q88" style="color:red" runat="server"></asp:Label>
                    <asp:CheckBoxList style="margin-left:20px" ID="Q8" runat="server">
                        <asp:ListItem Value="1"> &nbsp Terus-menerus</asp:ListItem>
                        <asp:ListItem Value="2"> &nbsp Makin keras saat kecepatan mobil bertambah</asp:ListItem>
                        <asp:ListItem Value="3"> &nbsp Kadang-kadang</asp:ListItem>
                        <asp:ListItem Value="4"> &nbsp Hanya sekali</asp:ListItem>
                        <asp:ListItem Value="5"> &nbsp Makin keras saat putaran mesin tambah cepat</asp:ListItem>
                    </asp:CheckBoxList>
	            </div>  
                <div class="form-group">
	                <label for="kelebihan">9. Bagaimana kondisi cuacanya?</label>
                    <asp:Label ID="Q99" style="color:red" runat="server"></asp:Label>
                    <asp:CheckBoxList style="margin-left:20px" ID="Q9" runat="server">
                        <asp:ListItem Value="1"> &nbsp Terdengar saat mesin hidup di pagi hari</asp:ListItem>
                        <asp:ListItem Value="2"> &nbsp Hujan</asp:ListItem>
                        <asp:ListItem Value="3"> &nbsp Siang</asp:ListItem>
                        <asp:ListItem Value="4"> &nbsp Sore</asp:ListItem>
                        <asp:ListItem Value="5"> &nbsp Malam</asp:ListItem>
                        <asp:ListItem Value="5"> &nbsp Dingin karena AC</asp:ListItem>
                    </asp:CheckBoxList>
                </div>  
                <div class="form-group">
	                <label for="kelebihan">10. Berapa banyak penumpang dalam mobil saat noise terdengar?</label>
		            <asp:Label ID="Q100" style="color:red" runat="server"></asp:Label>
                    <asp:TextBox ID="Q10" class="form-control required" runat="server"></asp:TextBox>
	            </div>  
            <br /><br />
                <asp:Label runat="server" ID="nm_petugas" Style="display:none"></asp:Label><br /><br />
                <center><asp:Button ID="Simpan" runat="server" Text="Simpan" class="btn btn-success"/></center>
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

div.depanAtasA {
    position: absolute;
    top: 105px;
    left: -25px;
    width: 450px;
}

div.depanTengahA {
    position: absolute;
    top: 140px;
    left: -25px;
    width: 450px;
   
}


div.depanBawahA {
	position: absolute;
    bottom: 50px;
    left: 0px;
    width: 100%;
}

div.belakangAtasA {
    position: absolute;
    bottom: 150px;
    left: -20px;
    width: 450px;
}

div.belakangTengahA {
    position: absolute;
    bottom: 120px;
    left: -20px;
    width: 450px;
}

div.belakangBawahA {
    position: absolute;
    bottom: 85px;
    left: -20px;
    width: 450px;
}

div.kananAtasA {
    position: absolute;
    top: 75px;
    left: -175px;
    width: 450px;
   
}

div.kananTengahA {
    position: absolute;
    top: 105px;
    left: -40px;
    width: 450px;
}

div.kananBawahA {
    position: absolute;
    bottom: 85px;
    left: -15px;
    width: 450px; 
}

div.kiriAtasA {
    position: absolute;
    top: 75px;
    left: 135px;
    width: 450px;
}

div.kiriTengahA {
    position: absolute;
    top: 105px;
    left: 0px;
    width: 450px;
}

div.kiriBawahA {
    position: absolute;
    bottom: 80px;
    left: -25px;
    width: 450px;
}

div.atasKiriA {
    position: absolute;
    top: 65px;
    left: -45px;
    width: 450px;
}

div.atasKananA {
    position: absolute;
    bottom:115px;
    left: -45px;
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
    left: -38px;
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
    left: -40px;
    width: 450px; 
}

span.radio {
    padding: 0px;
}

span.radio > input[type="radio"] {
    margin: 5px 5px 7px 0px;
}

span.radio > label {
    float: left;
    margin-right: 10px;
    padding: 0px 15px 0px 20px;
}
</style>

    <script>

   function stnkMasuk1() {
        if (document.getElementById('<%= stnkMasuk.ClientID %>').checked) {
            document.getElementById('<%= stnk.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= stnk.ClientID %>').style.display = 'none';
            document.getElementById('<%= stnk.ClientID %>').value = '';
        }
    }

    function kasetMasuk1() {
     if (document.getElementById('<%= kasetMasuk.ClientID %>').checked)  {
            document.getElementById('<%= kaset.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= kaset.ClientID %>').style.display = 'none';
            document.getElementById('<%= kaset.ClientID %>').value = '';
        }
    }

    function uangMasuk1() {
        if (document.getElementById('<%= uangMasuk.ClientID %>').checked) {
            document.getElementById('<%= uang.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= uang.ClientID %>').style.display = 'none';
            document.getElementById('<%= uang.ClientID %>').value = '';
        }
    }

    function karpetMasuk1() {
        if (document.getElementById('<%= karpetMasuk.ClientID %>').checked) {
            document.getElementById('<%= karpet.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= karpet.ClientID %>').style.display = 'none';
            document.getElementById('<%= karpet.ClientID %>').value = '';
        }
    }

    function velgMasuk1() {
        if (document.getElementById('<%= velgMasuk.ClientID %>').checked) {
            document.getElementById('<%= velg.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= velg.ClientID %>').style.display = 'none';
            document.getElementById('<%= velg.ClientID %>').value = '';
        }
    }

    function bukuMasuk1() {
        if (document.getElementById('<%= bukuMasuk.ClientID %>').checked) {
            document.getElementById('<%= buku.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= buku.ClientID %>').style.display = 'none';
            document.getElementById('<%= buku.ClientID %>').value = '';
        }
    }

    function toolKitMasuk1() {
        if (document.getElementById('<%= toolKitMasuk.ClientID %>').checked) {
            document.getElementById('<%= toolKit.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= toolKit.ClientID %>').style.display = 'none';
            document.getElementById('<%= toolKit.ClientID %>').style.display = '';
        }
    }

    function dongkrakMasuk1() {
        if (document.getElementById('<%= dongkrakMasuk.ClientID %>').checked) {
            document.getElementById('<%= dongkrak.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= dongkrak.ClientID %>').style.display = 'none';
            document.getElementById('<%= dongkrak.ClientID %>').value = '';
        }
    }

    function pemantikApiMasuk1() {
        if (document.getElementById('<%= pemantikApiMasuk.ClientID %>').checked) {
            document.getElementById('<%= pemantikApi.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= pemantikApi.ClientID %>').style.display = 'none';
            document.getElementById('<%= pemantikApi.ClientID %>').value = '';
        }
    }

    function banMasuk1() {
        if (document.getElementById('<%= banMasuk.ClientID %>').checked) {
            document.getElementById('<%= ban.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= ban.ClientID %>').style.display = 'none';
            document.getElementById('<%= ban.ClientID %>').value = '';
        }
    }

    function coverBanMasuk1() {
        if (document.getElementById('<%= coverBanMasuk.ClientID %>').checked) {
            document.getElementById('<%= coverBan.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= coverBan.ClientID %>').style.display = 'none';
            document.getElementById('<%= coverBan.ClientID %>').value = '';
        }
    }

    function panelMasuk1() {
        if (document.getElementById('<%= panelMasuk.ClientID %>').checked) {
            document.getElementById('<%= panel.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= panel.ClientID %>').style.display = 'none';
            document.getElementById('<%= panel.ClientID %>').value = '';
        }
    }

    function bukuServiceMasuk1() {
        if (document.getElementById('<%= bukuServiceMasuk.ClientID %>').checked) {
            document.getElementById('<%= bukuService.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= bukuService.ClientID %>').style.display = 'none';
            document.getElementById('<%= bukuService.ClientID %>').value = '';
        }
    }

    function powerWindowMasuk1() {
        if (document.getElementById('<%= powerWindowMasuk.ClientID %>').checked) {
            document.getElementById('<%= powerWindow.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= powerWindow.ClientID %>').style.display = 'none';
            document.getElementById('<%= powerWindow.ClientID %>').value = '';
        }
    }

    function centralLockMasuk1() {
        if (document.getElementById('<%= centralLockMasuk.ClientID %>').checked) {
            document.getElementById('<%= centralLock.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= centralLock.ClientID %>').style.display = 'none';
            document.getElementById('<%= centralLock.ClientID %>').value = '';
        }
    }

    function wiperMasuk1() {
        if (document.getElementById('<%= wiperMasuk.ClientID %>').checked) {
            document.getElementById('<%= wiper.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= wiper.ClientID %>').style.display = 'none';
            document.getElementById('<%= wiper.ClientID %>').value = '';
        }
    }

    function radioMasuk1() {
        if (document.getElementById('<%= radioMasuk.ClientID %>').checked) {
            document.getElementById('<%= radio.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= radio.ClientID %>').style.display = 'none';
            document.getElementById('<%= radio.ClientID %>').value = '';
        }
    }

    function cdMasuk1() {
        if (document.getElementById('<%= cdMasuk.ClientID %>').checked) {
            document.getElementById('<%= cd.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= cd.ClientID %>').style.display = 'none';
            document.getElementById('<%= cd.ClientID %>').value = '';
        }
    }

    function acMasuk1() {
        if (document.getElementById('<%= acMasuk.ClientID %>').checked) {
            document.getElementById('<%= ac.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= ac.ClientID %>').style.display = 'none';
            document.getElementById('<%= ac.ClientID %>').value = '';
        }
    }

    function remTanganMasuk1() {
        if (document.getElementById('<%= remTanganMasuk.ClientID %>').checked) {
            document.getElementById('<%= remTangan.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= remTangan.ClientID %>').style.display = 'none';
            document.getElementById('<%= remTangan.ClientID %>').value = '';
        }
    }

   function lain1() {
        if (document.getElementById('<%= Lain1.ClientID %>').checked) {
            document.getElementById('<%= keteranganLain1.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= keteranganLain1.ClientID %>').style.display = 'none';
        }
    }

    function lain2() {
        if (document.getElementById('<%= Lain2.ClientID %>').checked) {
            document.getElementById('<%= keteranganLain2.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= keteranganLain2.ClientID %>').style.display = 'none';
        }
    }

    function lain3() {
        if (document.getElementById('<%= Lain3.ClientID %>').checked) {
            document.getElementById('<%= keteranganLain3.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= keteranganLain3.ClientID %>').style.display = 'none';
        }
    }
        
      //Ada & Tidak Ada	
    function depanAtas1A() {
        if (document.getElementById('<%= askDepanAtas1A.ClientID %>').checked) {
            document.getElementById('<%= depanAtas1A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas1A.ClientID %>').style.display = 'none';	
        }
    }	

    function depanAtas2A() {
        if (document.getElementById('<%= askDepanAtas2A.ClientID %>').checked) {
            document.getElementById('<%= depanAtas2A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas2A.ClientID %>').style.display = 'none';	
        }
    }

    function depanAtas3A() {
        if (document.getElementById('<%= askDepanAtas3A.ClientID %>').checked) {
            document.getElementById('<%= depanAtas3A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas3A.ClientID %>').style.display = 'none';	
        }
    }

    function depanAtas4A() {
        if (document.getElementById('<%= askDepanAtas4A.ClientID %>').checked) {
            document.getElementById('<%= depanAtas4A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas4A.ClientID %>').style.display = 'none';	
        }
    }

    function depanAtas5A() {
        if (document.getElementById('<%= askDepanAtas5A.ClientID %>').checked) {
            document.getElementById('<%= depanAtas5A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas5A.ClientID %>').style.display = 'none';	
        }
    }

     function depanTengah1A() {
        if (document.getElementById('<%= askDepanTengah1A.ClientID %>').checked) {
            document.getElementById('<%= depanTengah1A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah1A.ClientID %>').style.display = 'none';	
        }
    }	

    function depanTengah2A() {
        if (document.getElementById('<%= askDepanTengah2A.ClientID %>').checked) {
            document.getElementById('<%= depanTengah2A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah2A.ClientID %>').style.display = 'none';	
        }
    }

    function depanTengah3A() {
        if (document.getElementById('<%= askDepanTengah3A.ClientID %>').checked) {
            document.getElementById('<%= depanTengah3A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah3A.ClientID %>').style.display = 'none';	
        }
    }

    function depanTengah4A() {
        if (document.getElementById('<%= askDepanTengah4A.ClientID %>').checked) {
            document.getElementById('<%= depanTengah4A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah4A.ClientID %>').style.display = 'none';	
        }
    }

    function depanTengah5A() {
        if (document.getElementById('<%= askDepanTengah5A.ClientID %>').checked) {
            document.getElementById('<%= depanTengah5A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah5A.ClientID %>').style.display = 'none';	
        }
    }	

    function depanBawah1A() {
        if (document.getElementById('<%= askDepanBawah1A.ClientID %>').checked) {
            document.getElementById('<%= depanBawah1A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah1A.ClientID %>').style.display = 'none';	
        }
    }

    function depanBawah2A() {
        if (document.getElementById('<%= askDepanBawah2A.ClientID %>').checked) {
            document.getElementById('<%= depanBawah2A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah2A.ClientID %>').style.display = 'none';	
        }
    }

    function depanBawah3A() {
        if (document.getElementById('<%= askDepanBawah3A.ClientID %>').checked) {
            document.getElementById('<%= depanBawah3A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah3A.ClientID %>').style.display = 'none';	
        }
    }

    function depanBawah4A() {
        if (document.getElementById('<%= askDepanBawah4A.ClientID %>').checked) {
            document.getElementById('<%= depanBawah4A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah4A.ClientID %>').style.display = 'none';	
        }
    }

    function depanBawah5A() {
        if (document.getElementById('<%= askDepanBawah5A.ClientID %>').checked) {
            document.getElementById('<%= depanBawah5A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah5A.ClientID %>').style.display = 'none';	
        }
    }
						
      function belakangAtas1A() {
        if (document.getElementById('<%= askBelakangAtas1A.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas1A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas1A.ClientID %>').style.display = 'none';	
        }
    }	
		
    function belakangAtas2A() {
        if (document.getElementById('<%= askBelakangAtas2A.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas2A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas2A.ClientID %>').style.display = 'none';	
        }
    }	
			
    function belakangAtas3A() {
        if (document.getElementById('<%= askBelakangAtas3A.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas3A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas3A.ClientID %>').style.display = 'none';	
        }
    }

    function belakangAtas4A() {
        if (document.getElementById('<%= askBelakangAtas4A.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas4A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas4A.ClientID %>').style.display = 'none';	
        }
    }

    function belakangAtas5A() {
        if (document.getElementById('<%= askBelakangAtas5A.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas5A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas5A.ClientID %>').style.display = 'none';	
        }
    }

    function belakangAtas6A() {
        if (document.getElementById('<%= askBelakangAtas6A.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas6A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas6A.ClientID %>').style.display = 'none';	
        }
    }
		
    function belakangTengah1A() {
        if (document.getElementById('<%= askBelakangTengah1A.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah1A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah1A.ClientID %>').style.display = 'none';	
        }
    }

    function belakangTengah2A() {
        if (document.getElementById('<%= askBelakangTengah2A.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah2A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah2A.ClientID %>').style.display = 'none';	
        }
      }

    function belakangTengah3A() {
        if (document.getElementById('<%= askBelakangTengah3A.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah3A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah3A.ClientID %>').style.display = 'none';	
        }
      }

    function belakangTengah4A() {
        if (document.getElementById('<%= askBelakangTengah4A.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah4A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah4A.ClientID %>').style.display = 'none';	
        }
      }

    function belakangTengah5A() {
        if (document.getElementById('<%= askBelakangTengah5A.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah5A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah5A.ClientID %>').style.display = 'none';	
        }
    }

    function belakangTengah6A() {
        if (document.getElementById('<%= askBelakangTengah6A.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah6A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah6A.ClientID %>').style.display = 'none';	
        }
    }

    function belakangBawah1A() {
        if (document.getElementById('<%= askBelakangBawah1A.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah1A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah1A.ClientID %>').style.display = 'none';	
        }
    }	
		
    function belakangBawah2A() {
        if (document.getElementById('<%= askBelakangBawah2A.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah2A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah2A.ClientID %>').style.display = 'none';	
        }
    }	
			
    function belakangBawah3A() {
        if (document.getElementById('<%= askBelakangBawah3A.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah3A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah3A.ClientID %>').style.display = 'none';	
        }
    }

    function belakangBawah4A() {
        if (document.getElementById('<%= askBelakangBawah4A.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah4A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah4A.ClientID %>').style.display = 'none';	
        }
      }

    function belakangBawah5A() {
        if (document.getElementById('<%= askBelakangBawah5A.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah5A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah5A.ClientID %>').style.display = 'none';	
        }
    }

    function belakangBawah6A() {
        if (document.getElementById('<%= askBelakangBawah6A.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah6A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah6A.ClientID %>').style.display = 'none';	
        }
    }
			
    function kananAtasA() {
        if (document.getElementById('<%= askKananAtasA.ClientID %>').checked) {
            document.getElementById('<%= kananAtasA.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananAtasA.ClientID %>').style.display = 'none';	
        }
    }
	
    function kananTengah1A() {
        if (document.getElementById('<%= askKananTengah1A.ClientID %>').checked) {
            document.getElementById('<%= kananTengah1A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah1A.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah2A() {
        if (document.getElementById('<%= askKananTengah2A.ClientID %>').checked) {
            document.getElementById('<%= kananTengah2A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah2A.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah3A() {
        if (document.getElementById('<%= askKananTengah3A.ClientID %>').checked) {
            document.getElementById('<%= kananTengah3A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah3A.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah4A() {
        if (document.getElementById('<%= askKananTengah4A.ClientID %>').checked) {
            document.getElementById('<%= kananTengah4A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah4A.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah5A() {
        if (document.getElementById('<%= askKananTengah5A.ClientID %>').checked) {
            document.getElementById('<%= kananTengah5A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah5A.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah6A() {
        if (document.getElementById('<%= askKananTengah6A.ClientID %>').checked) {
            document.getElementById('<%= kananTengah6A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah6A.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah7A() {
        if (document.getElementById('<%= askKananTengah7A.ClientID %>').checked) {
            document.getElementById('<%= kananTengah7A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah7A.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah8A() {
        if (document.getElementById('<%= askKananTengah8A.ClientID %>').checked) {
            document.getElementById('<%= kananTengah8A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah8A.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah9A() {
        if (document.getElementById('<%= askKananTengah9A.ClientID %>').checked) {
            document.getElementById('<%= kananTengah9A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah9A.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah10A() {
        if (document.getElementById('<%= askKananTengah10A.ClientID %>').checked) {
            document.getElementById('<%= kananTengah10A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah10A.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah1A() {
        if (document.getElementById('<%= askKananBawah1A.ClientID %>').checked) {
            document.getElementById('<%= kananBawah1A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah1A.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah2A() {
        if (document.getElementById('<%= askKananBawah2A.ClientID %>').checked) {
            document.getElementById('<%= kananBawah2A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah2A.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah3A() {
        if (document.getElementById('<%= askKananBawah3A.ClientID %>').checked) {
            document.getElementById('<%= kananBawah3A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah3A.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah4A() {
        if (document.getElementById('<%= askKananBawah4A.ClientID %>').checked) {
            document.getElementById('<%= kananBawah4A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah4A.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah5A() {
        if (document.getElementById('<%= askKananBawah5A.ClientID %>').checked) {
            document.getElementById('<%= kananBawah5A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah5A.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah6A() {
        if (document.getElementById('<%= askKananBawah6A.ClientID %>').checked) {
            document.getElementById('<%= kananBawah6A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah6A.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah7A() {
        if (document.getElementById('<%= askKananBawah7A.ClientID %>').checked) {
            document.getElementById('<%= kananBawah7A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah7A.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah8A() {
        if (document.getElementById('<%= askKananBawah8A.ClientID %>').checked) {
            document.getElementById('<%= kananBawah8A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah8A.ClientID %>').style.display = 'none';	
        }
      }

    function kananBawah9A() {
        if (document.getElementById('<%= askKananBawah9A.ClientID %>').checked) {
            document.getElementById('<%= kananBawah9A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah9A.ClientID %>').style.display = 'none';	
        }
    }

   function kananBawah10A() {
        if (document.getElementById('<%= askKananBawah10A.ClientID %>').checked) {
            document.getElementById('<%= kananBawah10A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah10A.ClientID %>').style.display = 'none';	
        }
    }
  
	  function kiriAtasA() {
        if (document.getElementById('<%= askKiriAtasA.ClientID %>').checked) {
            document.getElementById('<%= kiriAtasA.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriAtasA.ClientID %>').style.display = 'none';	
        }
    }
	
    function kiriTengah1A() {
        if (document.getElementById('<%= askKiriTengah1A.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah1A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah1A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah2A() {
        if (document.getElementById('<%= askKiriTengah2A.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah2A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah2A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah3A() {
        if (document.getElementById('<%= askKiriTengah3A.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah3A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah3A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah4A() {
        if (document.getElementById('<%= askKiriTengah4A.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah4A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah4A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah5A() {
        if (document.getElementById('<%= askKiriTengah5A.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah5A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah5A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah6A() {
        if (document.getElementById('<%= askKiriTengah6A.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah6A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah6A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah7A() {
        if (document.getElementById('<%= askKiriTengah7A.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah7A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah7A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah8A() {
        if (document.getElementById('<%= askKiriTengah8A.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah8A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah8A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah9A() {
        if (document.getElementById('<%= askKiriTengah9A.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah9A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah9A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah10A() {
        if (document.getElementById('<%= askKiriTengah10A.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah10A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah10A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah1A() {
        if (document.getElementById('<%= askKiriBawah1A.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah1A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah1A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah2A() {
        if (document.getElementById('<%= askKiriBawah2A.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah2A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah2A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah3A() {
        if (document.getElementById('<%= askKiriBawah3A.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah3A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah3A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah4A() {
        if (document.getElementById('<%= askKiriBawah4A.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah4A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah4A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah5A() {
        if (document.getElementById('<%= askKiriBawah5A.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah5A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah5A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah6A() {
        if (document.getElementById('<%= askKiriBawah6A.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah6A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah6A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah7A() {
        if (document.getElementById('<%= askKiriBawah7A.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah7A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah7A.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah8A() {
        if (document.getElementById('<%= askKiriBawah8A.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah8A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah8A.ClientID %>').style.display = 'none';	
        }
     }

     function kiriBawah9A() {
        if (document.getElementById('<%= askKiriBawah9A.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah9A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah9A.ClientID %>').style.display = 'none';	
        }
     }

     function kiriBawah10A() {
        if (document.getElementById('<%= askKiriBawah10A.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah10A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah10A.ClientID %>').style.display = 'none';	
        }
    }

	
    function atasKiri1A() {
        if (document.getElementById('<%= askAtasKiri1A.ClientID %>').checked) {
            document.getElementById('<%= atasKiri1A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri1A.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri2A() {
        if (document.getElementById('<%= askAtasKiri2A.ClientID %>').checked) {
            document.getElementById('<%= atasKiri2A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri2A.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri3A() {
        if (document.getElementById('<%= askAtasKiri3A.ClientID %>').checked) {
            document.getElementById('<%= atasKiri3A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri3A.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri4A() {
        if (document.getElementById('<%= askAtasKiri4A.ClientID %>').checked) {
            document.getElementById('<%= atasKiri4A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri4A.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri5A() {
        if (document.getElementById('<%= askAtasKiri5A.ClientID %>').checked) {
            document.getElementById('<%= atasKiri5A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri5A.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri6A() {
        if (document.getElementById('<%= askAtasKiri6A.ClientID %>').checked) {
            document.getElementById('<%= atasKiri6A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri6A.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri7A() {
        if (document.getElementById('<%= askAtasKiri7A.ClientID %>').checked) {
            document.getElementById('<%= atasKiri7A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri7A.ClientID %>').style.display = 'none';	
        }
    }

    function atasKanan1A() {
        if (document.getElementById('<%= askAtasKanan1A.ClientID %>').checked) {
            document.getElementById('<%= atasKanan1A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan1A.ClientID %>').style.display = 'none';	
        }
    }

     function atasKanan2A() {
        if (document.getElementById('<%= askAtasKanan2A.ClientID %>').checked) {
            document.getElementById('<%= atasKanan2A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan2A.ClientID %>').style.display = 'none';	
        }
     }

     function atasKanan3A() {
        if (document.getElementById('<%= askAtasKanan3A.ClientID %>').checked) {
            document.getElementById('<%= atasKanan3A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan3A.ClientID %>').style.display = 'none';	
        }
     }

     function atasKanan4A() {
        if (document.getElementById('<%= askAtasKanan4A.ClientID %>').checked) {
            document.getElementById('<%= atasKanan4A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan4A.ClientID %>').style.display = 'none';	
        }
     }

     function atasKanan5A() {
        if (document.getElementById('<%= askAtasKanan5A.ClientID %>').checked) {
            document.getElementById('<%= atasKanan5A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan5A.ClientID %>').style.display = 'none';	
        }
     }

     function atasKanan6A() {
        if (document.getElementById('<%= askAtasKanan6A.ClientID %>').checked) {
            document.getElementById('<%= atasKanan6A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan6A.ClientID %>').style.display = 'none';	
        }
     }

     function atasKanan7A() {
        if (document.getElementById('<%= askAtasKanan7A.ClientID %>').checked) {
            document.getElementById('<%= atasKanan7A.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan7A.ClientID %>').style.display = 'none';	
        }
     }


            //Ada & Tidak Ada	
    function depanAtas1B() {
        if (document.getElementById('<%= askDepanAtas1B.ClientID %>').checked) {
            document.getElementById('<%= depanAtas1B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas1B.ClientID %>').style.display = 'none';	
        }
    }	

    function depanAtas2B() {
        if (document.getElementById('<%= askDepanAtas2B.ClientID %>').checked) {
            document.getElementById('<%= depanAtas2B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas2B.ClientID %>').style.display = 'none';	
        }
    }

    function depanAtas3B() {
        if (document.getElementById('<%= askDepanAtas3B.ClientID %>').checked) {
            document.getElementById('<%= depanAtas3B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas3B.ClientID %>').style.display = 'none';	
        }
    }

    function depanAtas4B() {
        if (document.getElementById('<%= askDepanAtas4B.ClientID %>').checked) {
            document.getElementById('<%= depanAtas4B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas4B.ClientID %>').style.display = 'none';	
        }
    }

    function depanAtas5B() {
        if (document.getElementById('<%= askDepanAtas5B.ClientID %>').checked) {
            document.getElementById('<%= depanAtas5B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas5B.ClientID %>').style.display = 'none';	
        }
    }

     function depanTengah1B() {
        if (document.getElementById('<%= askDepanTengah1B.ClientID %>').checked) {
            document.getElementById('<%= depanTengah1B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah1B.ClientID %>').style.display = 'none';	
        }
    }	

    function depanTengah2B() {
        if (document.getElementById('<%= askDepanTengah2B.ClientID %>').checked) {
            document.getElementById('<%= depanTengah2B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah2B.ClientID %>').style.display = 'none';	
        }
    }

    function depanTengah3B() {
        if (document.getElementById('<%= askDepanTengah3B.ClientID %>').checked) {
            document.getElementById('<%= depanTengah3B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah3B.ClientID %>').style.display = 'none';	
        }
    }

    function depanTengah4B() {
        if (document.getElementById('<%= askDepanTengah4B.ClientID %>').checked) {
            document.getElementById('<%= depanTengah4B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah4B.ClientID %>').style.display = 'none';	
        }
    }

    function depanTengah5B() {
        if (document.getElementById('<%= askDepanTengah5B.ClientID %>').checked) {
            document.getElementById('<%= depanTengah5B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah5B.ClientID %>').style.display = 'none';	
        }
    }	

    function depanBawah1B() {
        if (document.getElementById('<%= askDepanBawah1B.ClientID %>').checked) {
            document.getElementById('<%= depanBawah1B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah1B.ClientID %>').style.display = 'none';	
        }
    }

    function depanBawah2B() {
        if (document.getElementById('<%= askDepanBawah2B.ClientID %>').checked) {
            document.getElementById('<%= depanBawah2B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah2B.ClientID %>').style.display = 'none';	
        }
    }

    function depanBawah3B() {
        if (document.getElementById('<%= askDepanBawah3B.ClientID %>').checked) {
            document.getElementById('<%= depanBawah3B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah3B.ClientID %>').style.display = 'none';	
        }
    }

    function depanBawah4B() {
        if (document.getElementById('<%= askDepanBawah4B.ClientID %>').checked) {
            document.getElementById('<%= depanBawah4B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah4B.ClientID %>').style.display = 'none';	
        }
    }

    function depanBawah5B() {
        if (document.getElementById('<%= askDepanBawah5B.ClientID %>').checked) {
            document.getElementById('<%= depanBawah5B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah5B.ClientID %>').style.display = 'none';	
        }
    }
						
      function belakangAtas1B() {
        if (document.getElementById('<%= askBelakangAtas1B.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas1B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas1B.ClientID %>').style.display = 'none';	
        }
    }	
		
    function belakangAtas2B() {
        if (document.getElementById('<%= askBelakangAtas2B.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas2B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas2B.ClientID %>').style.display = 'none';	
        }
    }	
			
    function belakangAtas3B() {
        if (document.getElementById('<%= askBelakangAtas3B.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas3B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas3B.ClientID %>').style.display = 'none';	
        }
    }

    function belakangAtas4B() {
        if (document.getElementById('<%= askBelakangAtas4B.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas4B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas4B.ClientID %>').style.display = 'none';	
        }
    }

    function belakangAtas5B() {
        if (document.getElementById('<%= askBelakangAtas5B.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas5B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas5B.ClientID %>').style.display = 'none';	
        }
    }

    function belakangTengah1B() {
        if (document.getElementById('<%= askBelakangTengah1B.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah1B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah1B.ClientID %>').style.display = 'none';	
        }
    }

    function belakangTengah2B() {
        if (document.getElementById('<%= askBelakangTengah2B.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah2B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah2B.ClientID %>').style.display = 'none';	
        }
      }

    function belakangTengah3B() {
        if (document.getElementById('<%= askBelakangTengah3B.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah3B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah3B.ClientID %>').style.display = 'none';	
        }
      }

    function belakangTengah4B() {
        if (document.getElementById('<%= askBelakangTengah4B.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah4B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah4B.ClientID %>').style.display = 'none';	
        }
      }

    function belakangTengah5B() {
        if (document.getElementById('<%= askBelakangTengah5B.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah5B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah5B.ClientID %>').style.display = 'none';	
        }
    }

    function belakangBawah1B() {
        if (document.getElementById('<%= askBelakangBawah1B.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah1B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah1B.ClientID %>').style.display = 'none';	
        }
    }	
		
    function belakangBawah2B() {
        if (document.getElementById('<%= askBelakangBawah2B.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah2B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah2B.ClientID %>').style.display = 'none';	
        }
    }	
			
    function belakangBawah3B() {
        if (document.getElementById('<%= askBelakangBawah3B.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah3B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah3B.ClientID %>').style.display = 'none';	
        }
    }

    function belakangBawah4B() {
        if (document.getElementById('<%= askBelakangBawah4B.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah4B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah4B.ClientID %>').style.display = 'none';	
        }
      }

    function belakangBawah5B() {
        if (document.getElementById('<%= askBelakangBawah5B.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah5B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah5B.ClientID %>').style.display = 'none';	
        }
    }
	
    function kananAtasB() {
        if (document.getElementById('<%= askKananAtasB.ClientID %>').checked) {
            document.getElementById('<%= kananAtasB.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananAtasB.ClientID %>').style.display = 'none';	
        }
    }
	
    function kananTengah1B() {
        if (document.getElementById('<%= askKananTengah1B.ClientID %>').checked) {
            document.getElementById('<%= kananTengah1B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah1B.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah2B() {
        if (document.getElementById('<%= askKananTengah2B.ClientID %>').checked) {
            document.getElementById('<%= kananTengah2B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah2B.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah3B() {
        if (document.getElementById('<%= askKananTengah3B.ClientID %>').checked) {
            document.getElementById('<%= kananTengah3B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah3B.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah4B() {
        if (document.getElementById('<%= askKananTengah4B.ClientID %>').checked) {
            document.getElementById('<%= kananTengah4B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah4B.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah5B() {
        if (document.getElementById('<%= askKananTengah5B.ClientID %>').checked) {
            document.getElementById('<%= kananTengah5B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah5B.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah6B() {
        if (document.getElementById('<%= askKananTengah6B.ClientID %>').checked) {
            document.getElementById('<%= kananTengah6B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah6B.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah7B() {
        if (document.getElementById('<%= askKananTengah7B.ClientID %>').checked) {
            document.getElementById('<%= kananTengah7B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah7B.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah8B() {
        if (document.getElementById('<%= askKananTengah8B.ClientID %>').checked) {
            document.getElementById('<%= kananTengah8B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah8B.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah9B() {
        if (document.getElementById('<%= askKananTengah9B.ClientID %>').checked) {
            document.getElementById('<%= kananTengah9B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah9B.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah1B() {
        if (document.getElementById('<%= askKananBawah1B.ClientID %>').checked) {
            document.getElementById('<%= kananBawah1B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah1B.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah2B() {
        if (document.getElementById('<%= askKananBawah2B.ClientID %>').checked) {
            document.getElementById('<%= kananBawah2B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah2B.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah3B() {
        if (document.getElementById('<%= askKananBawah3B.ClientID %>').checked) {
            document.getElementById('<%= kananBawah3B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah3B.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah4B() {
        if (document.getElementById('<%= askKananBawah4B.ClientID %>').checked) {
            document.getElementById('<%= kananBawah4B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah4B.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah5B() {
        if (document.getElementById('<%= askKananBawah5B.ClientID %>').checked) {
            document.getElementById('<%= kananBawah5B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah5B.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah6B() {
        if (document.getElementById('<%= askKananBawah6B.ClientID %>').checked) {
            document.getElementById('<%= kananBawah6B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah6B.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah7B() {
        if (document.getElementById('<%= askKananBawah7B.ClientID %>').checked) {
            document.getElementById('<%= kananBawah7B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah7B.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah8B() {
        if (document.getElementById('<%= askKananBawah8B.ClientID %>').checked) {
            document.getElementById('<%= kananBawah8B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah8B.ClientID %>').style.display = 'none';	
        }
      }

    function kananBawah9B() {
        if (document.getElementById('<%= askKananBawah9B.ClientID %>').checked) {
            document.getElementById('<%= kananBawah9B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah9B.ClientID %>').style.display = 'none';	
        }
    }

	function kiriAtasB() {
        if (document.getElementById('<%= askKiriAtasB.ClientID %>').checked) {
            document.getElementById('<%= kiriAtasB.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriAtasB.ClientID %>').style.display = 'none';	
        }
    }
	
    function kiriTengah1B() {
        if (document.getElementById('<%= askKiriTengah1B.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah1B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah1B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah2B() {
        if (document.getElementById('<%= askKiriTengah2B.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah2B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah2B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah3B() {
        if (document.getElementById('<%= askKiriTengah3B.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah3B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah3B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah4B() {
        if (document.getElementById('<%= askKiriTengah4B.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah4B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah4B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah5B() {
        if (document.getElementById('<%= askKiriTengah5B.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah5B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah5B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah6B() {
        if (document.getElementById('<%= askKiriTengah6B.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah6B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah6B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah7B() {
        if (document.getElementById('<%= askKiriTengah7B.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah7B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah7B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah8B() {
        if (document.getElementById('<%= askKiriTengah8B.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah8B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah8B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah9B() {
        if (document.getElementById('<%= askKiriTengah9B.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah9B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah9B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah1B() {
        if (document.getElementById('<%= askKiriBawah1B.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah1B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah1B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah2B() {
        if (document.getElementById('<%= askKiriBawah2B.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah2B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah2B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah3B() {
        if (document.getElementById('<%= askKiriBawah3B.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah3B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah3B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah4B() {
        if (document.getElementById('<%= askKiriBawah4B.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah4B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah4B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah5B() {
        if (document.getElementById('<%= askKiriBawah5B.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah5B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah5B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah6B() {
        if (document.getElementById('<%= askKiriBawah6B.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah6B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah6B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah7B() {
        if (document.getElementById('<%= askKiriBawah7B.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah7B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah7B.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah8B() {
        if (document.getElementById('<%= askKiriBawah8B.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah8B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah8B.ClientID %>').style.display = 'none';	
        }
     }

     function kiriBawah9B() {
        if (document.getElementById('<%= askKiriBawah9B.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah9B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah9B.ClientID %>').style.display = 'none';	
        }
     }

    function atasKiri1B() {
        if (document.getElementById('<%= askAtasKiri1B.ClientID %>').checked) {
            document.getElementById('<%= atasKiri1B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri1B.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri2B() {
        if (document.getElementById('<%= askAtasKiri2B.ClientID %>').checked) {
            document.getElementById('<%= atasKiri2B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri2B.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri3B() {
        if (document.getElementById('<%= askAtasKiri3B.ClientID %>').checked) {
            document.getElementById('<%= atasKiri3B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri3B.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri4B() {
        if (document.getElementById('<%= askAtasKiri4B.ClientID %>').checked) {
            document.getElementById('<%= atasKiri4B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri4B.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri5B() {
        if (document.getElementById('<%= askAtasKiri5B.ClientID %>').checked) {
            document.getElementById('<%= atasKiri5B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri5B.ClientID %>').style.display = 'none';	
        }
    }

    function atasKanan1B() {
        if (document.getElementById('<%= askAtasKanan1B.ClientID %>').checked) {
            document.getElementById('<%= atasKanan1B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan1B.ClientID %>').style.display = 'none';	
        }
    }

     function atasKanan2B() {
        if (document.getElementById('<%= askAtasKanan2B.ClientID %>').checked) {
            document.getElementById('<%= atasKanan2B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan2B.ClientID %>').style.display = 'none';	
        }
     }

     function atasKanan3B() {
        if (document.getElementById('<%= askAtasKanan3B.ClientID %>').checked) {
            document.getElementById('<%= atasKanan3B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan3B.ClientID %>').style.display = 'none';	
        }
     }

     function atasKanan4B() {
        if (document.getElementById('<%= askAtasKanan4B.ClientID %>').checked) {
            document.getElementById('<%= atasKanan4B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan4B.ClientID %>').style.display = 'none';	
        }
     }

     function atasKanan5B() {
        if (document.getElementById('<%= askAtasKanan5B.ClientID %>').checked) {
            document.getElementById('<%= atasKanan5B.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan5B.ClientID %>').style.display = 'none';	
        }
     }

</script>
</asp:Content>
