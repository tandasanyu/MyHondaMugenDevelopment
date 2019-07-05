<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="formChecklistSUV.aspx.vb" Inherits="formChecklistSUV" %>


<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <div class="container">
        <center>
            <h2>FORM PEMERIKSAAN</h2>
            <h4>001-FRM-SV R.0</h4>
        </center>
	</div>
   
	<div class="container">
        <!-- Marketing Icons Section -->
        <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">
                    Detail Kendaraan
                </h4>
            </div>
		</div>	
       
    <form runat="server"  class="form-horizontal">
          <div class="form-group">
			<label class="control-label col-sm-2" for="nopol">No Polisi (<font color="red">*</font>)</label>
            <div class="col-sm-4">
				<asp:TextBox ID="nopol" class="form-control required"  OnTextChanged="cariNopol" AutoPostBack="true" style="text-transform: uppercase;" placeholder="c/: B 1234 AB" runat="server"></asp:TextBox>	
			</div>
            <label id="txt_peringatan" runat="server" style="display:none;" for="txt_textwarning"><font color="red">Customer Belum Terdaftar</font></label>
			<asp:Label ID="nopolNotice" runat="server" style="color:red"></asp:Label>
		</div>

       <div id="txt_nmCustomer"  runat="server" style="display:none;" class="form-group">
			<label class="control-label col-sm-2"  for="txt_nmCustomer">Nama Customer</label>
			<div class="col-sm-4">
				<asp:TextBox ID="nmCustomer" class="form-control required" ReadOnly="true" runat="server"></asp:TextBox>	
			</div>
		</div>
         <div id="txt_norangka"  runat="server" style="display:none;" class="form-group">
			<label class="control-label col-sm-2"  for="txt_nmCustomer">No Rangka</label>
			<div class="col-sm-4">
				<asp:TextBox ID="noRangka" class="form-control required" ReadOnly="true" runat="server"></asp:TextBox>	
			</div>
		</div>

          <div class="form-group" id="txt_typeMobil" style="display:none;" runat="server">
			<label class="control-label col-sm-2" for="txt_typeMobil">Tipe Mobil</label>
			<div class="col-sm-4">
				<asp:TextBox ID="typeMobil" class="form-control required" ReadOnly="true" runat="server"></asp:TextBox>	
			</div>
		</div>

        <div id="txt_textwarning"  runat="server" style="display:none;" class="form-group">
			<label class="control-label col-sm-2"  for="txt_textwarning">Peringatan</label>
			<div class="col-sm-4">
				<asp:TextBox ID="textwarning" class="form-control required" style="color: red;" ReadOnly="true" runat="server"></asp:TextBox>	
			</div>
		</div>

        <div class="form-group">
			<label class="control-label col-sm-2" for="nopol">Tanggal Kedatangan (<font color="red">*</font>)</label>
            <div class="col-sm-4">
				<asp:TextBox ID="tglMasuk" class="form-control required"  ReadOnly="true" runat="server"></asp:TextBox>	
			</div>
		</div>

		<div class="form-group">
			<label class="control-label col-sm-2" for="nopol">Ordometer (<font color="red">*</font>)</label>
			<div class="col-sm-4">
				<asp:TextBox ID="ordometer" class="form-control required" runat="server"></asp:TextBox>	
			</div>
			<asp:Label ID="ordometerNotice" runat="server" style="color:red"></asp:Label>
		</div>
         
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
						<td>
							<asp:RadioButtonList ID="kondisiBanDepanKiri" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem> Baik</asp:ListItem>
								<asp:ListItem> Tidak Baik</asp:ListItem>
							</asp:RadioButtonList>
						</td>
						<td>
							<asp:RadioButtonList ID="kondisiBanDepanKanan" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
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
								<asp:ListItem Value="Tidak Baik"> Tidak Baik</asp:ListItem>
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
							<td><asp:TextBox ID="stnk" runat="server"  class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Cassette, CD, VCD, DVD</td>
							<td align="center"><asp:CheckBox ID="kasetMasuk" onclick="kasetMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="kaset" runat="server" class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Uang</td>
							<td align="center"><asp:CheckBox ID="uangMasuk" onclick="uangMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="uang" runat="server"  class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Pemantik Api / Charger</td>
							<td align="center"><asp:CheckBox ID="pemantikApiMasuk" onclick="pemantikApiMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="pemantikApi" runat="server"  class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Karpet (Jumlah)</td>
							<td align="center"><asp:CheckBox ID="karpetMasuk" onclick="karpetMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="karpet" runat="server"  class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Buku Service</td>
							<td align="center"><asp:CheckBox ID="bukuServiceMasuk" onclick="bukuServiceMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="bukuService" runat="server"  class="form-control" style="display:none;"></asp:TextBox> </td>
						</tr>
						<tr>
							<td>Dop Roda / Velg</td>
							<td align="center"><asp:CheckBox ID="velgMasuk" onclick="velgMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="velg" runat="server"  class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Buku / Dokumen / Surat / Koran</td>
							<td align="center"><asp:CheckBox ID="bukuMasuk" onclick="bukuMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="buku"  class="form-control" runat="server" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Tool Kit Set</td>
							<td align="center"><asp:CheckBox ID="toolKitMasuk" onclick="toolKitMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="toolKit" runat="server"  class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Dongkrak</td>
							<td align="center"><asp:CheckBox ID="dongkrakMasuk" onclick="dongkrakMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="dongkrak" runat="server"  class="form-control" style="display:none;"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Ban Cadangan</td>
							<td align="center"><asp:CheckBox ID="banMasuk" onclick="banMasuk1()" runat="server" /></td>
							<td><asp:TextBox ID="ban" runat="server"  class="form-control" style="display:none;"></asp:TextBox></td>
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
        <!-- Marketing Icons Section -->
        <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">Kondisi Fisik Kendaraan</h4>
            </div>
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-down"></i> Bagian Depan <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4> 
                    </div>
					<div class="panel-body">
                        <center>
                            <div class="relative"><img src="image/depanCRV.png" class="img-responsive" /> 
                                <!-- Bemper Depan Atas -->
								<div class="depanAtas">
                                    <asp:CheckBox  name="askDepanAtas1" ID="askDepanAtas1" onclick="depanAtas1()" runat="server" />
									<!-- Bemper Depan Atas 1 -->
									&nbsp;<asp:DropDownList style="position:absolute; margin-left:100px; margin-top:-50px; display:none;" ID="depanAtas10" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Atas 2 -->
									<asp:CheckBox style="margin-left:25px;" name="askDepanAtas2" value="1" ID="askDepanAtas2" onclick="depanAtas2()" runat="server" />
                                    &nbsp;<asp:DropDownList ID="depanAtas20" style="position:absolute; margin-left:155px; margin-top:-50px;  display:none;  " runat="server">
                                            <asp:ListItem Value="X">X</asp:ListItem>
                                            <asp:ListItem Value="V">V</asp:ListItem>
                                            <asp:ListItem Value="O">O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Atas 3 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanAtas3" id="askDepanAtas3" onclick="depanAtas3()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:205px; margin-top:-50px; display:none;" ID="depanAtas30" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                               
                                	<!-- Bemper Depan Atas 4 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanAtas4" id="askDepanAtas4" onclick="depanAtas4()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:255px; margin-top:-50px; display:none;" ID="depanAtas40" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                	<!-- Bemper Depan Atas 5 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanAtas5" id="askDepanAtas5" onclick="depanAtas5()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:305px; margin-top:-50px; display:none;" ID="depanAtas50" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <!-- Bemper Depan Tengah 1-->
								<div class="depanTengah">
                                    <asp:CheckBox  name="askDepanTengah1" ID="askDepanTengah1" onclick="depanTengah1()" runat="server" />
									<!-- Bemper Depan Atas 1 -->
									&nbsp;<asp:DropDownList style="position:absolute; margin-left:130px; margin-top:-40px; display:none;" ID="depanTengah10" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Tengah 2 -->
									<asp:CheckBox style="margin-left:25px;" name="askDepanTengah2" ID="askDepanTengah2" onclick="depanTengah2()" runat="server" />
                                    &nbsp;<asp:DropDownList ID="depanTengah20" style="position:absolute; margin-left:180px; margin-top:-40px;  display:none;  " runat="server">
                                            <asp:ListItem Value="X">X</asp:ListItem>
                                            <asp:ListItem Value="V">V</asp:ListItem>
                                            <asp:ListItem Value="O">O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Tengah 3 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanTengah3" id="askDepanTengah3" onclick="depanTengah3()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:230px; margin-top:-40px; display:none;" ID="depanTengah30" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                               
                                	<!-- Bemper Depan Tengah 4 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanTengah4" id="askDepanTengah4" onclick="depanTengah4()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:280px; margin-top:-40px; display:none;" ID="depanTengah40" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                              
                                	<!-- Bemper Depan Tengah 5 -->
									<asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanTengah5" id="askDepanTengah5" onclick="depanTengah5()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute; margin-left:330px; margin-top:-40px; display:none;" ID="depanTengah50" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
							
								<!-- Bemper Depan Bawah -->
								<div class="depanBawah">
									<!-- Bemper Depan Bawah 1 -->
                                    <asp:CheckBox runat="server" name="askDepanBawah1" id="askDepanBawah1" onclick="depanBawah1()" value="1"/>
						            &nbsp;<asp:DropDownList ID="depanBawah10" runat="server"  style="position:absolute; margin-left:75px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
	
									<!-- Bemper Depan Bawah 2 -->	
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanBawah2" id="askDepanBawah2" onclick="depanBawah2()" value="1"/>
								    &nbsp;<asp:DropDownList ID="depanBawah20"  style="position:absolute; margin-left:125px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
									
									<!-- Bemper Depan Bawah 3 -->	
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanBawah3" id="askDepanBawah3" onclick="depanBawah3()" value="1"/>								
                                    &nbsp;<asp:DropDownList ID="depanBawah30"  style="position:absolute; margin-left:175px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Bemper Depan Bawah 4 -->	
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanBawah4" id="askDepanBawah4" onclick="depanBawah4()" value="1"/>								
                                    &nbsp;<asp:DropDownList ID="depanBawah40"  style="position:absolute; margin-left:225px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Bemper Depan Bawah 5 -->	
                                    <asp:CheckBox runat="server" style="margin-left:25px;" name="askDepanBawah5" id="askDepanBawah5" onclick="depanBawah5()" value="1"/>								
                                    &nbsp;<asp:DropDownList ID="depanBawah50"  style="position:absolute; margin-left:275px; display:none;" runat="server">
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

            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-up"></i> Bagian Belakang  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                    <div class="panel-body">
                        <center>
							<div class="relative">
								<img src="image/crvBelakang.png" class="img-responsive" />  
								<!-- Belakang Atas -->
								<div class="belakangAtas">
									<!-- Belakang Atas 1 -->
                                    <asp:CheckBox runat="server" name="askBelakangAtas1" id="askBelakangAtas1" onclick="belakangAtas1()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangAtas10" style="position:absolute; margin-left:100px; margin-top:-45px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Atas 2 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangAtas2" id="askBelakangAtas2" onclick="belakangAtas2()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangAtas20" style="position:absolute; margin-left:150px; margin-top:-45px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Atas 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangAtas3" id="askBelakangAtas3" onclick="belakangAtas3()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangAtas30" style="position:absolute; margin-left:190px; margin-top:-45px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Atas 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangAtas4" id="askBelakangAtas4" onclick="belakangAtas4()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangAtas40" style="position:absolute; margin-left:230px; margin-top:-45px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Atas 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangAtas5" id="askBelakangAtas5" onclick="belakangAtas5()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangAtas50" style="position:absolute; margin-left:270px; margin-top:-45px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Atas 6 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangAtas6" id="askBelakangAtas6" onclick="belakangAtas6()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangAtas60" style="position:absolute; margin-left:310px; margin-top:-45px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
			
								</div>

                                <div class="belakangTengah2">
									<!-- Belakang Tengah 1 -->
                                    <asp:CheckBox runat="server" name="askBelakangTengah1" id="askBelakangTengah1" onclick="belakangTengah1()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangTengah10" style="position:absolute; margin-left:100px; margin-top:-5px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Tengah 2 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangTengah2" id="askBelakangTengah2" onclick="belakangTengah2()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangTengah20" style="position:absolute; margin-left:150px; margin-top:-5px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Tengah 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangTengah3" id="askBelakangTengah3" onclick="belakangTengah3()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangTengah30" style="position:absolute; margin-left:190px; margin-top:-5px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Tengah 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangTengah4" id="askBelakangTengah4" onclick="belakangTengah4()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangTengah40" style="position:absolute; margin-left:230px; margin-top:-5px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Tengah 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangTengah5" id="askBelakangTengah5" onclick="belakangTengah5()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangTengah50" style="position:absolute; margin-left:270px; margin-top:-5px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Tengah 6 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangTengah6" id="askBelakangTengah6" onclick="belakangTengah6()" /> 
			                        &nbsp;<asp:DropDownList ID="belakangTengah60" style="position:absolute; margin-left:310px; margin-top:-5px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
								</div>

								<!-- Belakang Bawah -->
								<div class="belakangBawah2">
									<!-- Belakang Bawah 1 -->
                                    <asp:CheckBox runat="server"  name="askBelakangBawah1" id="askBelakangBawah1" onclick="belakangBawah1()" value="1"/> 
	                                &nbsp;<asp:DropDownList ID="belakangBawah10"  style="position:absolute; margin-left:100px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Bawah 2 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangBawah2" id="askBelakangBawah2" onclick="belakangBawah2()" value="1"/> 
	                                &nbsp;<asp:DropDownList ID="belakangBawah20"  style="position:absolute; margin-left:150px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Bawah 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangBawah3" id="askBelakangBawah3" onclick="belakangBawah3()" value="1"/> 
	                                &nbsp;<asp:DropDownList ID="belakangBawah30" style="position:absolute; margin-left:190px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Bawah 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangBawah4" id="askBelakangBawah4" onclick="belakangBawah4()" value="1"/> 
	                                &nbsp;<asp:DropDownList ID="belakangBawah40" style="position:absolute; margin-left:230px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Bawah 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askBelakangBawah5" id="askBelakangBawah5" onclick="belakangBawah5()" value="1"/> 
	                                &nbsp;<asp:DropDownList ID="belakangBawah50" style="position:absolute; margin-left:270px; display:none;" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Belakang Bawah 6 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;"  name="askBelakangBawah6" id="askBelakangBawah6" onclick="belakangBawah6()" value="1"/> 
	                                &nbsp;<asp:DropDownList ID="belakangBawah60"  style="position:absolute; margin-left:310px; display:none;" runat="server">
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
			
			<div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-right"></i> Bagian Kanan  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                    <div class="panel-body">
                        <center>
						    <div class="relative"><img src="image/kananCRV.png" class="img-responsive" /> 
							    <!-- Kanan Atas -->
							    <div class="kananAtas">
                                    <asp:CheckBox runat="server" name="askKananAtas" id="askKananAtas" onclick="kananAtas()" value="1"/> 
                                    &nbsp;<asp:DropDownList style="position:absolute; margin-left:205px; margin-top:-45px; display:none;" ID="kananAtas1" runat="server">
                                            <asp:ListItem>X</asp:ListItem>
                                            <asp:ListItem>V</asp:ListItem>
                                            <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							    </div>
							
							    <!-- Kanan Tengah -->
							    <div class="kananTengah">
								    <!-- Kanan Tengah 1 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah1" id="askKananTengah1" onclick="kananTengah1()" value="1"/> 
							        &nbsp;<asp:DropDownList ID="kananTengah10"  style="position:absolute; margin-left:40px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
								
								    <!-- Kanan Tengah 2 -->
                                    <asp:CheckBox runat="server" style="margin-left:15px;" name="askKananTengah2" id="askKananTengah2" onclick="kananTengah2()" value="1"/> 
							        &nbsp;<asp:DropDownList ID="kananTengah20" style="position:absolute; margin-left:100px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
			
								    <!-- Kanan Tengah 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah3" id="askKananTengah3" onclick="kananTengah3()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah30" style="position:absolute; margin-left:135px; margin-top:-70px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

								
								    <!-- Kanan Tengah 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah4" id="askKananTengah4" onclick="kananTengah4()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah40" style="position:absolute; margin-left:160px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
		
                                    <!-- Kanan Tengah 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah5" id="askKananTengah5" onclick="kananTengah5()" value="1"/>
                                    &nbsp;<asp:DropDownList  style="position:absolute;  margin-left:190px; margin-top:-70px;  display:none;" ID="kananTengah50" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
						
								    <!-- Kanan Tengah 6 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah6" id="askKananTengah6" onclick="kananTengah6()" value="1"/>
                                    &nbsp;<asp:DropDownList style="position:absolute; margin-left:220px; margin-top:-45px; display:none;" ID="kananTengah60" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
								    <!-- Kanan Tengah 7 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah7" id="askKananTengah7" onclick="kananTengah7()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah70"  style="position:absolute; margin-left:250px; margin-top:-70px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
								
								    <!-- Kanan Tengah 8 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananTengah8" id="askKananTengah8" onclick="kananTengah8()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah80" style="position:absolute; margin-left:280px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Kanan Tengah 9 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askKananTengah9" id="askKananTengah9" onclick="kananTengah9()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah90" style="position:absolute; margin-left:310px; margin-top:-70px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Kanan Tengah 10 -->
                                    <asp:CheckBox runat="server" style="margin-left:15px;" name="askKananTengah10" id="askKananTengah10" onclick="kananTengah10()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananTengah100" style="position:absolute; margin-left:350px; margin-top:-45px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							    </div>
							
							    <!-- Kanan Bawah -->
							    <div class="kananBawah">
								    <!-- Kanan Bawah 1 -->
                                    <asp:CheckBox runat="server" name="askKananBawah1" id="askKananBawah1" onclick="kananBawah1()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananBawah10"  style="position:absolute; margin-left:40px; margin-top:0px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
								
								    <!-- Kanan Bawah 2 -->
                                    <asp:CheckBox runat="server" style="margin-left:20px;" name="askKananBawah2" id="askKananBawah2" onclick="kananBawah2()" value="1"/>
                                    &nbsp;<asp:DropDownList ID="kananBawah20"  style="position:absolute; margin-left:90px; margin-top:0px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
						
								    <!-- Kanan Bawah 3 -->
                                    <asp:CheckBox runat="server" style="margin-left:20px;" name="askKananBawah3" id="askKananBawah3" onclick="kananBawah3()" value="1"/>
                                    &nbsp;<asp:DropDownList style="position:absolute; margin-left:135px; margin-top:20px; display:none;" ID="kananBawah30" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
								    <!-- Kanan Bawah 4 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askKananBawah4" id="askKananBawah4" onclick="kananBawah4()" value="1"/> 
                                    &nbsp;<asp:DropDownList ID="kananBawah40" runat="server" style="position:absolute; margin-left:170px; margin-top:0px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
	
								    <!-- Kanan Bawah 5 -->
                                    <asp:CheckBox runat="server" style="margin-left:5px;" name="askKananBawah5" id="askKananBawah5" onclick="kananBawah5()" value="1"/> 
                                    &nbsp;<asp:DropDownList ID="kananBawah50" style="position:absolute; margin-left:195px; margin-top:25px; display:none;" runat="server">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
                                    <!-- Kanan Bawah 6 -->
                                    <asp:CheckBox runat="server"  style="margin-left:5px;" name="askKananBawah6" id="askKananBawah6" onclick="kananBawah6()" value="1"/> 
                                    &nbsp;<asp:DropDownList ID="kananBawah60" runat="server"  style="position:absolute; margin-left:230px; margin-top:0px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>
							
								    <!-- Kanan Bawah 7 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askKananBawah7" id="askKananBawah7" onclick="kananBawah7()" value="1"/> 
								    &nbsp;<asp:DropDownList ID="kananBawah70" runat="server" style="position:absolute; margin-left:260px; margin-top:25px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Kanan Bawah 8 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askKananBawah8" id="askKananBawah8" onclick="kananBawah8()" value="1"/> 
								    &nbsp;<asp:DropDownList ID="kananBawah80" runat="server" style="position:absolute; margin-left:295px; margin-top:0px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Kanan Bawah 9 -->
                                    <asp:CheckBox runat="server" style="margin-left:10px;" name="askKananBawah9" id="askKananBawah9" onclick="kananBawah9()" value="1"/> 
								    &nbsp;<asp:DropDownList ID="kananBawah90" runat="server" style="position:absolute; margin-left:335px; margin-top:25px; display:none;">
                                        <asp:ListItem>X</asp:ListItem>
                                        <asp:ListItem>V</asp:ListItem>
                                        <asp:ListItem>O</asp:ListItem>
                                    </asp:DropDownList>

                                    <!-- Kanan Bawah 10 -->
                                    <asp:CheckBox runat="server" style="margin-left:15px;" name="askKananBawah10" id="askKananBawah10" onclick="kananBawah10()" value="1"/> 
								    &nbsp;<asp:DropDownList ID="kananBawah100" runat="server" style="position:absolute; margin-left:375px; margin-top:0px; display:none;">
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
			
			<div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-left"></i> Bagian Kiri  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                     <div class="panel-body">
                        <center>
						    <div class="relative"><img src="image/kiriCRV.png" class="img-responsive" />  
							<!-- Kiri Atas -->
							<div class="kiriAtas">
                                <asp:CheckBox runat="server" ID="askKiriAtas" onclick="kiriAtas()" value="1"/> 
							    &nbsp;<asp:DropDownList ID="kiriAtas1" runat="server" style="position:absolute; margin-left:215px; margin-top:-45px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							</div>
							
							<!-- Kiri Tengah -->
							<div class="kiriTengah">
								<!-- Kiri Tengah 1 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah1" id="askKiriTengah1" onclick="kiriTengah1()" value="1"/> 
					            &nbsp;<asp:DropDownList ID="kiriTengah10" style="position:absolute; margin-left:60px; margin-top:-55px; display:none" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Tengah 2 -->
                                <asp:CheckBox runat="server" style="margin-left:20px;" name="askKiriTengah2" id="askKiriTengah2" onclick="kiriTengah2()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah20" runat="server"  style="position:absolute; margin-left:100px; margin-top:-80px; display:none">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
                                <!-- Kiri Tengah 3 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askKiriTengah3" id="askKiriTengah3" onclick="kiriTengah3()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah30" runat="server" style="position:absolute; margin-left:135px; margin-top:-55px; display:none">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							
								<!-- Kiri Tengah 4 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah4" id="askKiriTengah4" onclick="kiriTengah4()" value="1"/> 					
						        &nbsp;<asp:DropDownList ID="kiriTengah40" runat="server"  style="position:absolute; margin-left:160px; margin-top:-80px; display:none">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							
								<!-- Kiri Tengah 5 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah5" id="askKiriTengah5" onclick="kiriTengah5()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah50" runat="server"  style="position:absolute; margin-left:195px; margin-top:-55px; display:none">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Tengah 6 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah6" id="askKiriTengah6" onclick="kiriTengah6()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah60" runat="server"  style="position:absolute; margin-left:220px;  margin-top:-80px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
                                <!-- Kiri Tengah 7 -->
                                <asp:CheckBox runat="server" style="margin-left:3px;" name="askKiriTengah7" id="askKiriTengah7" onclick="kiriTengah7()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah70"  style="position:absolute; margin-left:260px;  margin-top:-55px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
                                <!-- Kiri Tengah 8 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriTengah8" id="askKiriTengah8" onclick="kiriTengah8()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah80" style="position:absolute; margin-left:290px; margin-top:-80px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                 <!-- Kiri Tengah 9 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriTengah9" id="askKiriTengah9" onclick="kiriTengah9()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah90" style="position:absolute; margin-left:320px; margin-top:-105px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                  <!-- Kiri Tengah 10 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriTengah10" id="askKiriTengah10" onclick="kiriTengah10()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriTengah100" style="position:absolute; margin-left:370px; margin-top:-45px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							</div>
							
							<!-- Kiri Bawah -->
							<div class="kiriBawah">
								<!-- Kiri Bawah 1 -->
                                <asp:CheckBox runat="server" name="askKiriBawah1" id="askKiriBawah1" onclick="kiriBawah1()" value="1"/> 
							    &nbsp;<asp:DropDownList ID="kiriBawah10" style="position:absolute; margin-left:35px; margin-top:0px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 2 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriBawah2" id="askKiriBawah2" onclick="kiriBawah2()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah20" runat="server" style="position:absolute; margin-left:85px; margin-top:0px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							
								<!-- Kiri Bawah 3 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriBawah3" id="askKiriBawah3" onclick="kiriBawah3()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah30" style="position:absolute; margin-left:125px; margin-top:25px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 4 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askKiriBawah4" id="askKiriBawah4" onclick="kiriBawah4()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah40" style="position:absolute;  margin-left:150px; margin-top:0px;  display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 5 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriBawah5" id="askKiriBawah5" onclick="kiriBawah5()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah50" style="position:absolute; margin-left:185px; margin-top:25px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 6 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriBawah6" id="askKiriBawah6" onclick="kiriBawah6()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah60"  style="position:absolute; margin-left:215px; margin-top:0px;display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Kiri Bawah 7 -->
                                <asp:CheckBox runat="server" style="margin-left:5px;" name="askKiriBawah7" id="askKiriBawah7" onclick="kiriBawah7()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah70"  style="position:absolute; margin-left:250px; margin-top:25px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                <!-- Kiri Bawah 8 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askKiriBawah8" id="askKiriBawah8" onclick="kiriBawah8()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah80"  style="position:absolute; margin-left:280px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                <!-- Kiri Bawah 9 -->
                                <asp:CheckBox runat="server" style="margin-left:15px;" name="askKiriBawah9" id="askKiriBawah9" onclick="kiriBawah9()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah90"  style="position:absolute; margin-left:320px; margin-top:25px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                 <!-- Kiri Bawah 10 -->
                                <asp:CheckBox runat="server" style="margin-left:25px;" name="askKiriBawah10" id="askKiriBawah10" onclick="kiriBawah10()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="kiriBawah100"  style="position:absolute; margin-left:380px; margin-top:0px; display:none;" runat="server">
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
			
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                    <h4><i class="fa fa-arrows-alt"></i> Bagian Atas  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                </div>
                <div class="panel-body">
                    <center>
					    <div class="relative"><img src="image/atasCRV.png" class="img-responsive" />  
				            <!-- Atas Kiri -->
							<div class="atasKiri">
								<!-- Atas Kiri 1 -->
                                <asp:CheckBox runat="server" name="askAtasKiri1" id="askAtasKiri1" onclick="atasKiri1()" value="1"/> 
						        &nbsp;<asp:DropDownList ID="atasKiri10" style="position:absolute; margin-left:60px; margin-top:-45px; display:none;" runat="server">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kiri 2 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKiri2" id="askAtasKiri2" onclick="atasKiri2()" value="1"/>
                                &nbsp;<asp:DropDownList ID="atasKiri20" runat="server" style="position:absolute; margin-left:105px; margin-top:-75px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kiri 3 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKiri3" id="askAtasKiri3" onclick="atasKiri3()" value="1"/>
                                &nbsp;<asp:DropDownList ID="atasKiri30" runat="server" style="position:absolute; margin-left:140px; margin-top:-45px;  display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kiri 4 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKiri4" id="askAtasKiri4" onclick="atasKiri4()" value="1"/>
                                &nbsp;<asp:DropDownList ID="atasKiri40" runat="server" style="position:absolute; margin-left:175px; margin-top:-75px;  display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kiri 5 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKiri5" id="askAtasKiri5" onclick="atasKiri5()" value="1"/>
                                &nbsp;<asp:DropDownList ID="atasKiri50" runat="server" style="position:absolute; margin-left:210px; margin-top:-45px;  display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                <!-- Atas Kiri 6 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKiri6" id="askAtasKiri6" onclick="atasKiri6()" value="1"/>
                                &nbsp;<asp:DropDownList ID="AtasKiri60" runat="server" style="position:absolute; margin-left:245px; margin-top:-75px;  display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

                                	<!-- Atas Kiri 7 -->
                                <asp:CheckBox runat="server" style="margin-left:65px;" name="askAtasKiri7" id="askAtasKiri7" onclick="atasKiri7()" value="1"/>
                                &nbsp;<asp:DropDownList ID="AtasKiri70" runat="server" style="position:absolute; margin-left:350px; margin-top:-45px;  display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							</div>
							
							<!-- Atas Kanan -->
							<div class="atasKanan">
								<!-- Atas Kanan 1 -->
                                <asp:CheckBox runat="server" name="askAtasKanan1" id="askAtasKanan1" onclick="atasKanan1()" value="1"/> 
						        &nbsp;<asp:DropDownList ID="atasKanan10" runat="server" style="position:absolute; margin-left:65px; margin-top:5px;  display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>

								<!-- Atas Kanan 2 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKanan2" id="askAtasKanan2" onclick="atasKanan2()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan20" runat="server" style="position:absolute; margin-left:105px; margin-top:30px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kanan 3 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKanan3" id="askAtasKanan3" onclick="atasKanan3()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan30" runat="server" style="position:absolute; margin-left:145px; margin-top:5px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
							
								<!-- Atas Kanan 4 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKanan4" id="askAtasKanan4" onclick="atasKanan4()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan40" runat="server"  style="position:absolute; margin-left:180px; margin-top:30px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>
								
								<!-- Atas Kanan 5 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKanan5" id="askAtasKanan5" onclick="atasKanan5()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan50" runat="server" style="position:absolute; margin-left:210px; margin-top:5px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>	

                                <!-- Atas Kanan 6 -->
                                <asp:CheckBox runat="server" style="margin-left:10px;" name="askAtasKanan6" id="askAtasKanan6" onclick="atasKanan6()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan60" runat="server" style="position:absolute; margin-left:250px; margin-top:30px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>	

                                <!-- Atas Kanan 5 -->
                                <asp:CheckBox runat="server" style="margin-left:65px;" name="askAtasKanan7" id="askAtasKanan7" onclick="atasKanan7()" value="1"/> 
                                &nbsp;<asp:DropDownList ID="atasKanan70" runat="server" style="position:absolute; margin-left:340px; margin-top:5px; display:none;">
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>O</asp:ListItem>
                                </asp:DropDownList>	
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
          
			<div class="row"  style="margin-left:10px">
                <div class="col-lg-12">
                <h4 class="page-header">
                    Diagnostik Noise
                </h4>
            </div>
        </div>	
        <div style="margin-left:20px">    
        <div class="form-group">
            <label for="kelebihan">1. Jenis keluhan atau suara yang terdengar (contoh: menggelitik atau benturan bensin)?</label>
            <asp:TextBox ID="Q1" class="form-control required" maxlength="50" runat="server"></asp:TextBox>
		</div>  
		<div class="form-group">
		    <label for="kelebihan">2. Bagaimana kecepatan mobil saat keluhan atau suara-suara itu terdengar</label>
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
            <asp:CheckBoxList style="margin-left:20px" ID="Q3" runat="server">
                <asp:ListItem Value="1"> &nbsp Maju</asp:ListItem>
                <asp:ListItem Value="2"> &nbsp Mundur</asp:ListItem>
                <asp:ListItem Value="3"> &nbsp Di pinggir jalan / belokan</asp:ListItem>
            </asp:CheckBoxList>
	    </div>  
        <div class="form-group">
		    <label for="kelebihan">4. Keadaan kecepatan (berkendara)</label>
            <asp:CheckBoxList style="margin-left:20px" ID="Q4" runat="server">
                <asp:ListItem Value="1"> &nbsp Saat menginjak gas</asp:ListItem>
                <asp:ListItem Value="2"> &nbsp Saat mengerem/melambat</asp:ListItem>
                <asp:ListItem Value="3"> &nbsp Saat melaju pada kecepatan tetap</asp:ListItem>
            </asp:CheckBoxList>
	    </div>  
        <div class="form-group">
            <label for="kelebihan">5. Kondisi jalan</label>
            <asp:CheckBoxList style="margin-left:20px" ID="Q5" runat="server">
                <asp:ListItem Value="1"> &nbsp Daerah tengah kota</asp:ListItem>
                <asp:ListItem Value="2"> &nbsp Jalan tol</asp:ListItem>
                <asp:ListItem Value="3"> &nbsp Jalan rusak/bergelombang</asp:ListItem>
                <asp:ListItem Value="4"> &nbsp Tanjakan/turunan</asp:ListItem>
            </asp:CheckBoxList>
	    </div>  
        <div class="form-group">
	        <label for="kelebihan">6. Bagian mobil tempat darimana suara itu terdengar (Kiri) (Kanan) (Tandai bila tahu)</label>
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
            <asp:CheckBoxList style="margin-left:20px" ID="Q7" runat="server">
                <asp:ListItem Value="1"> &nbsp A/C menyala</asp:ListItem>
                <asp:ListItem Value="2"> &nbsp Saat setir diputar</asp:ListItem>
                <asp:ListItem Value="3"> &nbsp Lain-lain</asp:ListItem>
            </asp:CheckBoxList>
        </div>  
        <div class="form-group">
		    <label for="kelebihan">8. Seberapa sering suara/noise terdengar?</label>
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
		    <asp:TextBox ID="Q10" class="form-control required" runat="server"></asp:TextBox>
	    </div>  
       </div> <br /> 
        <div class="form-group">
           <center> <asp:Button ID="simpan" class="btn btn-success btn-sm"  runat="server" Text="Simpan" OnClick="simpan_Click" /> </center>
        </div>
    </form>

    </div>
    <!-- /.container -->


	<style>
div.relative {
    position: relative;
    width: 400px;
    height: 250px;
   
} 


div.depanAtas {
    position: absolute;
    top: 105px;
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
    bottom: 150px;
    left: -20px;

    width: 450px;

}

div.belakangTengah {
    position: absolute;
    bottom: 110px;
    left: -20px;

    width: 450px;

}

div.belakangBawah {
    position: absolute;
    bottom: 65px;
    left: -20px;
 
    width: 450px;

}

div.belakangTengah2 {
    position: absolute;
    bottom: 120px;
    left: -20px;

    width: 450px;

}

div.belakangBawah2 {
    position: absolute;
    bottom: 85px;
    left: -20px;
 
    width: 450px;

}


div.kananAtas {
    position: absolute;
    top: 75px;
    left: -175px;

    width: 450px;
   
}

div.kananTengah {
    position: absolute;
    top: 105px;
    left: -40px;

    width: 450px;
   
}

div.kananBawah {
    position: absolute;
    bottom: 85px;
    left: -15px;

    width: 450px;
   
}

div.kiriAtas {
    position: absolute;
    top: 75px;
    left: 135px;

    width: 450px;
   
}

div.kiriTengah {
    position: absolute;
    top: 105px;
    left: 0px;

    width: 450px;
   
}

div.kiriBawah {
    position: absolute;
    bottom: 80px;
    left: -25px;

    width: 450px;
   
}

div.atasKiri {
    position: absolute;
    top: 65px;
    left: -45px;

    width: 450px;
   
}

div.atasKanan {
    position: absolute;
    bottom:115px;
    left: -45px;

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

    function kasetMasuk1() {
        if (document.getElementById('<%= kasetMasuk.ClientID %>').checked) {
            document.getElementById('<%= kaset.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= kaset.ClientID %>').style.display = 'none';
        }
    }

    function stnkMasuk1() {
        if (document.getElementById('<%= stnkMasuk.ClientID %>').checked) {
            document.getElementById('<%= stnk.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= stnk.ClientID %>').style.display = 'none';
        }
    }

    function uangMasuk1() {
        if (document.getElementById('<%= uangMasuk.ClientID %>').checked) {
            document.getElementById('<%= uang.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= uang.ClientID %>').style.display = 'none';
        }
    }

    function karpetMasuk1() {
        if (document.getElementById('<%= karpetMasuk.ClientID %>').checked) {
            document.getElementById('<%= karpet.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= karpet.ClientID %>').style.display = 'none';
        }
    }

    function velgMasuk1() {
        if (document.getElementById('<%= velgMasuk.ClientID %>').checked) {
            document.getElementById('<%= velg.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= velg.ClientID %>').style.display = 'none';
        }
    }

    function bukuMasuk1() {
        if (document.getElementById('<%= bukuMasuk.ClientID %>').checked) {
            document.getElementById('<%= buku.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= buku.ClientID %>').style.display = 'none';
        }
    }

    function toolKitMasuk1() {
        if (document.getElementById('<%= toolKitMasuk.ClientID %>').checked) {
            document.getElementById('<%= toolKit.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= toolKit.ClientID %>').style.display = 'none';
        }
    }

    function dongkrakMasuk1() {
        if (document.getElementById('<%= dongkrakMasuk.ClientID %>').checked) {
            document.getElementById('<%= dongkrak.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= dongkrak.ClientID %>').style.display = 'none';
        }
    }

    function pemantikApiMasuk1() {
        if (document.getElementById('<%= pemantikApiMasuk.ClientID %>').checked) {
            document.getElementById('<%= pemantikApi.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= pemantikApi.ClientID %>').style.display = 'none';
        }
    }

    function banMasuk1() {
        if (document.getElementById('<%= banMasuk.ClientID %>').checked) {
            document.getElementById('<%= ban.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= ban.ClientID %>').style.display = 'none';
        }
    }

    function coverBanMasuk1() {
        if (document.getElementById('<%= coverBanMasuk.ClientID %>').checked) {
            document.getElementById('<%= coverBan.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= coverBan.ClientID %>').style.display = 'none';
        }
    }

    function panelMasuk1() {
        if (document.getElementById('<%= panelMasuk.ClientID %>').checked) {
            document.getElementById('<%= panel.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= panel.ClientID %>').style.display = 'none';
        }
    }

    function bukuServiceMasuk1() {
        if (document.getElementById('<%= bukuServiceMasuk.ClientID %>').checked) {
            document.getElementById('<%= bukuService.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= bukuService.ClientID %>').style.display = 'none';
        }
    }

    function powerWindowMasuk1() {
        if (document.getElementById('<%= powerWindowMasuk.ClientID %>').checked) {
            document.getElementById('<%= powerWindow.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= powerWindow.ClientID %>').style.display = 'none';
        }
    }

    function centralLockMasuk1() {
        if (document.getElementById('<%= centralLockMasuk.ClientID %>').checked) {
            document.getElementById('<%= centralLock.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= centralLock.ClientID %>').style.display = 'none';
        }
    }

    function wiperMasuk1() {
        if (document.getElementById('<%= wiperMasuk.ClientID %>').checked) {
            document.getElementById('<%= wiper.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= wiper.ClientID %>').style.display = 'none';
        }
    }

    function radioMasuk1() {
        if (document.getElementById('<%= radioMasuk.ClientID %>').checked) {
            document.getElementById('<%= radio.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= radio.ClientID %>').style.display = 'none';
        }
    }

    function cdMasuk1() {
        if (document.getElementById('<%= cdMasuk.ClientID %>').checked) {
            document.getElementById('<%= cd.ClientID %>').style.display = 'block';
        } else {
            document.getElementById('<%= cd.ClientID %>').style.display = 'none';
        }
    }

    function acMasuk1() {
        if (document.getElementById('<%= acMasuk.ClientID %>').checked) {
            document.getElementById('<%= ac.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= ac.ClientID %>').style.display = 'none';
        }
    }

    function remTanganMasuk1() {
        if (document.getElementById('<%= remTanganMasuk.ClientID %>').checked) {
            document.getElementById('<%= remTangan.ClientID %>').style.display = 'block';
            } else {
            document.getElementById('<%= remTangan.ClientID %>').style.display = 'none';
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
    function depanAtas1() {
        if (document.getElementById('<%= askDepanAtas1.ClientID %>').checked) {
            document.getElementById('<%= depanAtas10.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas10.ClientID %>').style.display = 'none';	
        }
    }	

    function depanAtas2() {
        if (document.getElementById('<%= askDepanAtas2.ClientID %>').checked) {
            document.getElementById('<%= depanAtas20.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas20.ClientID %>').style.display = 'none';	
        }
    }

    function depanAtas3() {
        if (document.getElementById('<%= askDepanAtas3.ClientID %>').checked) {
            document.getElementById('<%= depanAtas30.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas30.ClientID %>').style.display = 'none';	
        }
    }

    function depanAtas4() {
        if (document.getElementById('<%= askDepanAtas4.ClientID %>').checked) {
            document.getElementById('<%= depanAtas40.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas40.ClientID %>').style.display = 'none';	
        }
    }

    function depanAtas5() {
        if (document.getElementById('<%= askDepanAtas5.ClientID %>').checked) {
            document.getElementById('<%= depanAtas50.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanAtas50.ClientID %>').style.display = 'none';	
        }
    }

     function depanTengah1() {
        if (document.getElementById('<%= askDepanTengah1.ClientID %>').checked) {
            document.getElementById('<%= depanTengah10.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah10.ClientID %>').style.display = 'none';	
        }
    }	

    function depanTengah2() {
        if (document.getElementById('<%= askDepanTengah2.ClientID %>').checked) {
            document.getElementById('<%= depanTengah20.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah20.ClientID %>').style.display = 'none';	
        }
    }

    function depanTengah3() {
        if (document.getElementById('<%= askDepanTengah3.ClientID %>').checked) {
            document.getElementById('<%= depanTengah30.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah30.ClientID %>').style.display = 'none';	
        }
    }

    function depanTengah4() {
        if (document.getElementById('<%= askDepanTengah4.ClientID %>').checked) {
            document.getElementById('<%= depanTengah40.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah40.ClientID %>').style.display = 'none';	
        }
    }

    function depanTengah5() {
        if (document.getElementById('<%= askDepanTengah5.ClientID %>').checked) {
            document.getElementById('<%= depanTengah50.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanTengah50.ClientID %>').style.display = 'none';	
        }
    }	

    function depanBawah1() {
        if (document.getElementById('<%= askDepanBawah1.ClientID %>').checked) {
            document.getElementById('<%= depanBawah10.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah10.ClientID %>').style.display = 'none';	
        }
    }

    function depanBawah2() {
        if (document.getElementById('<%= askDepanBawah2.ClientID %>').checked) {
            document.getElementById('<%= depanBawah20.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah20.ClientID %>').style.display = 'none';	
        }
    }

    function depanBawah3() {
        if (document.getElementById('<%= askDepanBawah3.ClientID %>').checked) {
            document.getElementById('<%= depanBawah30.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah30.ClientID %>').style.display = 'none';	
        }
    }

    function depanBawah4() {
        if (document.getElementById('<%= askDepanBawah4.ClientID %>').checked) {
            document.getElementById('<%= depanBawah40.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah40.ClientID %>').style.display = 'none';	
        }
    }

    function depanBawah5() {
        if (document.getElementById('<%= askDepanBawah5.ClientID %>').checked) {
            document.getElementById('<%= depanBawah50.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= depanBawah50.ClientID %>').style.display = 'none';	
        }
    }
						
      function belakangAtas1() {
        if (document.getElementById('<%= askBelakangAtas1.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas10.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas10.ClientID %>').style.display = 'none';	
        }
    }	
		
    function belakangAtas2() {
        if (document.getElementById('<%= askBelakangAtas2.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas20.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas20.ClientID %>').style.display = 'none';	
        }
    }	
			
    function belakangAtas3() {
        if (document.getElementById('<%= askBelakangAtas3.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas30.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas30.ClientID %>').style.display = 'none';	
        }
    }

    function belakangAtas4() {
        if (document.getElementById('<%= askBelakangAtas4.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas40.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas40.ClientID %>').style.display = 'none';	
        }
    }

    function belakangAtas5() {
        if (document.getElementById('<%= askBelakangAtas5.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas50.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas50.ClientID %>').style.display = 'none';	
        }
    }

    function belakangAtas6() {
        if (document.getElementById('<%= askBelakangAtas6.ClientID %>').checked) {
            document.getElementById('<%= belakangAtas60.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangAtas60.ClientID %>').style.display = 'none';	
        }
    }
		
    function belakangTengah1() {
        if (document.getElementById('<%= askBelakangTengah1.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah10.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah10.ClientID %>').style.display = 'none';	
        }
    }

    function belakangTengah2() {
        if (document.getElementById('<%= askBelakangTengah2.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah20.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah20.ClientID %>').style.display = 'none';	
        }
      }

    function belakangTengah3() {
        if (document.getElementById('<%= askBelakangTengah3.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah30.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah30.ClientID %>').style.display = 'none';	
        }
      }

    function belakangTengah4() {
        if (document.getElementById('<%= askBelakangTengah4.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah40.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah40.ClientID %>').style.display = 'none';	
        }
      }

    function belakangTengah5() {
        if (document.getElementById('<%= askBelakangTengah5.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah50.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah50.ClientID %>').style.display = 'none';	
        }
    }

    function belakangTengah6() {
        if (document.getElementById('<%= askBelakangTengah6.ClientID %>').checked) {
            document.getElementById('<%= belakangTengah60.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangTengah60.ClientID %>').style.display = 'none';	
        }
    }

    function belakangBawah1() {
        if (document.getElementById('<%= askBelakangBawah1.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah10.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah10.ClientID %>').style.display = 'none';	
        }
    }	
		
    function belakangBawah2() {
        if (document.getElementById('<%= askBelakangBawah2.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah20.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah20.ClientID %>').style.display = 'none';	
        }
    }	
			
    function belakangBawah3() {
        if (document.getElementById('<%= askBelakangBawah3.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah30.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah30.ClientID %>').style.display = 'none';	
        }
    }

    function belakangBawah4() {
        if (document.getElementById('<%= askBelakangBawah4.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah40.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah40.ClientID %>').style.display = 'none';	
        }
      }

    function belakangBawah5() {
        if (document.getElementById('<%= askBelakangBawah5.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah50.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah50.ClientID %>').style.display = 'none';	
        }
    }

    function belakangBawah6() {
        if (document.getElementById('<%= askBelakangBawah6.ClientID %>').checked) {
            document.getElementById('<%= belakangBawah60.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= belakangBawah60.ClientID %>').style.display = 'none';	
        }
    }
			
    function kananAtas() {
        if (document.getElementById('<%= askKananAtas.ClientID %>').checked) {
            document.getElementById('<%= kananAtas1.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananAtas1.ClientID %>').style.display = 'none';	
        }
    }
	
    function kananTengah1() {
        if (document.getElementById('<%= askKananTengah1.ClientID %>').checked) {
            document.getElementById('<%= kananTengah10.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah10.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah2() {
        if (document.getElementById('<%= askKananTengah2.ClientID %>').checked) {
            document.getElementById('<%= kananTengah20.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah20.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah3() {
        if (document.getElementById('<%= askKananTengah3.ClientID %>').checked) {
            document.getElementById('<%= kananTengah30.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah30.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah4() {
        if (document.getElementById('<%= askKananTengah4.ClientID %>').checked) {
            document.getElementById('<%= kananTengah40.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah40.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah5() {
        if (document.getElementById('<%= askKananTengah5.ClientID %>').checked) {
            document.getElementById('<%= kananTengah50.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah50.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah6() {
        if (document.getElementById('<%= askKananTengah6.ClientID %>').checked) {
            document.getElementById('<%= kananTengah60.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah60.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah7() {
        if (document.getElementById('<%= askKananTengah7.ClientID %>').checked) {
            document.getElementById('<%= kananTengah70.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah70.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah8() {
        if (document.getElementById('<%= askKananTengah8.ClientID %>').checked) {
            document.getElementById('<%= kananTengah80.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah80.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah9() {
        if (document.getElementById('<%= askKananTengah9.ClientID %>').checked) {
            document.getElementById('<%= kananTengah90.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah90.ClientID %>').style.display = 'none';	
        }
    }

    function kananTengah10() {
        if (document.getElementById('<%= askKananTengah10.ClientID %>').checked) {
            document.getElementById('<%= kananTengah100.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananTengah100.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah1() {
        if (document.getElementById('<%= askKananBawah1.ClientID %>').checked) {
            document.getElementById('<%= kananBawah10.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah10.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah2() {
        if (document.getElementById('<%= askKananBawah2.ClientID %>').checked) {
            document.getElementById('<%= kananBawah20.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah20.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah3() {
        if (document.getElementById('<%= askKananBawah3.ClientID %>').checked) {
            document.getElementById('<%= kananBawah30.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah30.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah4() {
        if (document.getElementById('<%= askKananBawah4.ClientID %>').checked) {
            document.getElementById('<%= kananBawah40.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah40.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah5() {
        if (document.getElementById('<%= askKananBawah5.ClientID %>').checked) {
            document.getElementById('<%= kananBawah50.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah50.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah6() {
        if (document.getElementById('<%= askKananBawah6.ClientID %>').checked) {
            document.getElementById('<%= kananBawah60.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah60.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah7() {
        if (document.getElementById('<%= askKananBawah7.ClientID %>').checked) {
            document.getElementById('<%= kananBawah70.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah70.ClientID %>').style.display = 'none';	
        }
    }

    function kananBawah8() {
        if (document.getElementById('<%= askKananBawah8.ClientID %>').checked) {
            document.getElementById('<%= kananBawah80.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah80.ClientID %>').style.display = 'none';	
        }
      }

    function kananBawah9() {
        if (document.getElementById('<%= askKananBawah9.ClientID %>').checked) {
            document.getElementById('<%= kananBawah90.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah90.ClientID %>').style.display = 'none';	
        }
    }

   function kananBawah10() {
        if (document.getElementById('<%= askKananBawah10.ClientID %>').checked) {
            document.getElementById('<%= kananBawah100.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kananBawah100.ClientID %>').style.display = 'none';	
        }
    }
  
	  function kiriAtas() {
        if (document.getElementById('<%= askKiriAtas.ClientID %>').checked) {
            document.getElementById('<%= kiriAtas1.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriAtas1.ClientID %>').style.display = 'none';	
        }
    }
	
    function kiriTengah1() {
        if (document.getElementById('<%= askKiriTengah1.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah10.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah10.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah2() {
        if (document.getElementById('<%= askKiriTengah2.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah20.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah20.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah3() {
        if (document.getElementById('<%= askKiriTengah3.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah30.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah30.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah4() {
        if (document.getElementById('<%= askKiriTengah4.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah40.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah40.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah5() {
        if (document.getElementById('<%= askKiriTengah5.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah50.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah50.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah6() {
        if (document.getElementById('<%= askKiriTengah6.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah60.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah60.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah7() {
        if (document.getElementById('<%= askKiriTengah7.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah70.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah70.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah8() {
        if (document.getElementById('<%= askKiriTengah8.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah80.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah80.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah9() {
        if (document.getElementById('<%= askKiriTengah9.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah90.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah90.ClientID %>').style.display = 'none';	
        }
    }

    function kiriTengah10() {
        if (document.getElementById('<%= askKiriTengah10.ClientID %>').checked) {
            document.getElementById('<%= kiriTengah100.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriTengah100.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah1() {
        if (document.getElementById('<%= askKiriBawah1.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah10.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah10.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah2() {
        if (document.getElementById('<%= askKiriBawah2.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah20.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah20.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah3() {
        if (document.getElementById('<%= askKiriBawah3.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah30.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah30.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah4() {
        if (document.getElementById('<%= askKiriBawah4.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah40.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah40.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah5() {
        if (document.getElementById('<%= askKiriBawah5.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah50.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah50.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah6() {
        if (document.getElementById('<%= askKiriBawah6.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah60.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah60.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah7() {
        if (document.getElementById('<%= askKiriBawah7.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah70.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah70.ClientID %>').style.display = 'none';	
        }
    }

    function kiriBawah8() {
        if (document.getElementById('<%= askKiriBawah8.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah80.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah80.ClientID %>').style.display = 'none';	
        }
     }

     function kiriBawah9() {
        if (document.getElementById('<%= askKiriBawah9.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah90.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah90.ClientID %>').style.display = 'none';	
        }
     }

     function kiriBawah10() {
        if (document.getElementById('<%= askKiriBawah10.ClientID %>').checked) {
            document.getElementById('<%= kiriBawah100.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= kiriBawah100.ClientID %>').style.display = 'none';	
        }
    }

	
    function atasKiri1() {
        if (document.getElementById('<%= askAtasKiri1.ClientID %>').checked) {
            document.getElementById('<%= atasKiri10.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri10.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri2() {
        if (document.getElementById('<%= askAtasKiri2.ClientID %>').checked) {
            document.getElementById('<%= atasKiri20.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri20.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri3() {
        if (document.getElementById('<%= askAtasKiri3.ClientID %>').checked) {
            document.getElementById('<%= atasKiri30.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri30.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri4() {
        if (document.getElementById('<%= askAtasKiri4.ClientID %>').checked) {
            document.getElementById('<%= atasKiri40.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri40.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri5() {
        if (document.getElementById('<%= askAtasKiri5.ClientID %>').checked) {
            document.getElementById('<%= atasKiri50.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri50.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri6() {
        if (document.getElementById('<%= askAtasKiri6.ClientID %>').checked) {
            document.getElementById('<%= atasKiri60.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri60.ClientID %>').style.display = 'none';	
        }
    }

    function atasKiri7() {
        if (document.getElementById('<%= askAtasKiri7.ClientID %>').checked) {
            document.getElementById('<%= atasKiri70.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKiri70.ClientID %>').style.display = 'none';	
        }
    }

    function atasKanan1() {
        if (document.getElementById('<%= askAtasKanan1.ClientID %>').checked) {
            document.getElementById('<%= atasKanan10.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan10.ClientID %>').style.display = 'none';	
        }
    }

     function atasKanan2() {
        if (document.getElementById('<%= askAtasKanan2.ClientID %>').checked) {
            document.getElementById('<%= atasKanan20.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan20.ClientID %>').style.display = 'none';	
        }
     }

     function atasKanan3() {
        if (document.getElementById('<%= askAtasKanan3.ClientID %>').checked) {
            document.getElementById('<%= atasKanan30.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan30.ClientID %>').style.display = 'none';	
        }
     }

     function atasKanan4() {
        if (document.getElementById('<%= askAtasKanan4.ClientID %>').checked) {
            document.getElementById('<%= atasKanan40.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan40.ClientID %>').style.display = 'none';	
        }
     }

     function atasKanan5() {
        if (document.getElementById('<%= askAtasKanan5.ClientID %>').checked) {
            document.getElementById('<%= atasKanan50.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan50.ClientID %>').style.display = 'none';	
        }
     }

     function atasKanan6() {
        if (document.getElementById('<%= askAtasKanan6.ClientID %>').checked) {
            document.getElementById('<%= atasKanan60.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan60.ClientID %>').style.display = 'none';	
        }
     }

     function atasKanan7() {
        if (document.getElementById('<%= askAtasKanan7.ClientID %>').checked) {
            document.getElementById('<%= atasKanan70.ClientID %>').style.display = 'block';	
            } else { document.getElementById('<%= atasKanan70.ClientID %>').style.display = 'none';	
        }
    }

</script>

<script type="text/javascript"> 

function stopRKey(evt) { 
  var evt = (evt) ? evt : ((event) ? event : null); 
  var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null); 
  if ((evt.keyCode == 13) && (node.type=="text"))  {return false;} 
} 

document.onkeypress = stopRKey; 

</script>

</asp:Content>