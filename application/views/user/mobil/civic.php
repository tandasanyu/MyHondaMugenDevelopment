	<title>Honda Civic</title>
	<section id="content"></section>
	<section id="content">
		<div class="container">
			<div class="col-sm-12 col-lg-12">
				<h2>Honda Civic</h2>
				<!-- Slider -->
				<div id="main-slider" class="main-slider flexslider">
					<ul class="slides">
					  <li>
						<img src="<?php echo base_url().'image/civic1.jpg'?>" alt="" />
					  </li>
					  <li>
						<img src="<?php echo base_url().'image/civic2.jpg'?>" alt="" />
					  </li>
					  <li>
						<img src="<?php echo base_url().'image/civic3.jpg'?>" alt="" />
					  </li>
					  <li>
						<img src="<?php echo base_url().'image/civic4.jpg'?>" alt="" />
					  </li>		
					  <li>
						<img src="<?php echo base_url().'image/civic5.jpg'?>" alt="" />
					  </li>	
					  <li>
						<img src="<?php echo base_url().'image/civic6.jpg'?>" alt="" />
					  </li>	
					</ul>
				</div>
			</div>
		</div>

		<!--Menu Tab -->	
		<div class="container">
			<div class="col-sm-12 col-lg-12">
				<ul class="nav nav-tabs">
					<li <?php if ($tab=='video'){echo 'class="active"';} else{echo '';}?>><a href="#video" data-toggle="tab">Video</a></li>
					<!--<li><a href="#preview" data-toggle="tab"><i class="icon-briefcase"></i>Preview</a></li>-->
					<li><a href="#spesifikasi" data-toggle="tab"><i class="icon-briefcase"></i> Spesifikasi</a></li>
					<li><a href="#harga" data-toggle="tab">Harga</a></li>
					<li  <?php if ($tab=='simulasi'){echo 'class="active"';} else{echo '';}?>><a href="#simulasi" data-toggle="tab">Simulasi Perhitungan Kredit</a></li>
					<li><a href="<?php echo base_url().'brosur/Civic.pdf'?>">Unduh Brosur</a></li>
				</ul>
						
				<div class="tab-content">
					<!--Tab Video-->					
					<div class="tab-pane <?php if ($tab=='video'){echo 'active';} else{echo '';}?>" id="video">
						<div class="video-container">		
							<iframe width="800" height="400" src="https://www.youtube.com/embed/F8Lu02DxMQg" frameborder="0" allowfullscreen></iframe>
						</div>	
					</div>
					
					<!--Tab Preview
					<div class="tab-pane" id="preview">
						<<div class="video-container">>		
							<iframe width="1000" height="400" src="http://www.honda-indonesia.com/H3D/civic.html" frameborder="0" allowfullscreen></iframe>
						</div>	
					</div>-->
					
					<!--Tab Spesifikasi-->
					<div class="tab-pane" id="spesifikasi">
						<div class="table table-responsive">
							<table class="table table-bordered table-hover">
								<tbody>	
									<!--Mesin-->
									<tr class="active">
										<td colspan="4" align="center"><b>Mesin</b></td>
									</tr>
									<tr>
										<th class="col-md-3"></th>
										<th class="col-md-3">Civic 1.8 L</th>	
										<th class="col-md-3">Civic 1.8 L A/T</th>
										<th class="col-md-3">Civic 2.0 L A/T</th>
									</tr>
									<tr>
										<th>Tipe</th>	
										<td>SOHC silinder segaris, 16 katup i-VTEC + DBW + DICT</td>
										<td>SOHC silinder segaris, 16 katup i-VTEC + DBW + DICT</td>
										<td>SOHC silinder segaris, 16 katup i-VTEC + DBW + DICT</td>
									</tr>
									<tr>
										<th>Sistem Suplai Bahan Bakar</th>	
										<td>PGM-FI</td>
										<td>PGM-FI</td>
										<td>PGM-FI</td>
									</tr>
									<tr>
										<th>Diameter x Langkah</th>	
										<td>81mm X 87,25mm</td>
										<td>81mm X 87,25mm</td>
										<td>81mm x 96,89mm</td>
									</tr>
									<tr>
										<th>Isi Silinder</th>
										<td>1798</td>
										<td>1798</td>
										<td>1997</td>
									</tr>
									<tr>
										<th>Perbandingan Kompresi</th>	
										<td>10,6:1</td>
										<td>10,6:1</td>
										<td>10,6:1</td>
									</tr>
									<tr>
										<th>Daya Maksimum</th>	
										<td>141 PS/6.500 rpm</td>
										<td>141 PS/6.500 rpm</td>
										<td>155 PS/6.500 rpm</td>
									</tr>			
									<tr>
										<th>Momen Puntir Maksimum</th>	
										<td>174 Nm/4.300 rpm</td>
										<td>174 Nm/4.300 rpm</td>
										<td>190 Nm/4.300 rpm</td>
									</tr>
										
									<!--Dimensi-->
									<tr class="active">
										<td colspan="4" align="center"><b>Dimensi</b></td>
									</tr>
									<tr>
										<th class="col-md-3"></th>
										<th class="col-md-3">Civic 1.8 L</th>	
										<th class="col-md-3">Civic 1.8 L A/T</th>
										<th class="col-md-3">Civic 2.0 L A/T</th>
									</tr>
									<tr>
										<th>Panjang x Lebar x Tinggi</th>	
										<td>4.540mm x 1.755mm x 1.435mm</td>
										<td>4.540mm x 1.755mm x 1.435mm</td>
										<td>4.540mm x 1.755mm x 1.435mm</td>
									</tr>
									<tr>
										<th>Jarak Sumbu Roda</th>	
										<td>2.7</td>
										<td>2.7</td>
										<td>2.7</td>
									</tr>
									<tr>
										<th>Jarak Pijak Depan / Belakang</th>	
										<td>1.500mm / 1.520mm</td>
										<td>1.500mm / 1.520mm</td>
										<td>1.500mm / 1.520mm</td>
									</tr>
									<tr>
										<th>Kapasitas Tangki</th>	
										<td>57</td>
										<td>57</td>
										<td>57</td>
									</tr>	
										
									<!--Transmisi-->
									<tr class="active">
										<td colspan="4" align="center"><b>Transmisi</b></td>
									</tr>
									<tr>
										<th class="col-md-3"></th>
										<th class="col-md-3">Civic 1.8 L</th>	
										<th class="col-md-3">Civic 1.8 L A/T</th>
										<th class="col-md-3">Civic 2.0 L A/T</th>
									</tr>
										
									<tr>
										<th>Tipe</th>
										<td>5 Speed</td>	
										<td>A/T</td>
										<td>A/T</td>
									</tr>
									<tr>
										<th>1</th>	
										<td>3,142</td>
										<td>2,666</td>
										<td>2,651</td>
									</tr>
									<tr>
										<th>2</th>	
										<td>1,869</td>
										<td>1,534</td>
										<td>1,516</td>	
									</tr>
									<tr>
										<th>3</th>	
										<td>1,235</td>
										<td>1,021</td>
										<td>1,081</td>
									</tr>
									<tr>
										<th>4</th>	
										<td>0,948</td>
										<td>0,720</td>
										<td>0,773</td>
									</tr>
									<tr>
										<th>5</th>	
										<td>0,727</td>
										<td>0,524</td>
										<td>0,566</td>
									</tr>
									<tr>
										<th>Reverse</th>	
										<td>3,307</td>
										<td>1,956</td>
										<td>2,000</td>
									</tr>
									<tr>
										<th>Final Gear</th>	
										<td>4,625</td>
										<td>4,437</td>
										<td>4,562</td>
									</tr>
										
									<!--Kemudi-->
									<tr class="active">
										<td colspan="4" align="center"><b>Sistem Kemudi</b></td>
									</tr>
									<tr>
										<th class="col-md-3"></th>
										<th class="col-md-3">Civic 1.8 L</th>	
										<th class="col-md-3">Civic 1.8 L A/T</th>
										<th class="col-md-3">Civic 2.0 L A/T</th>
									</tr>
									<tr>
										<th>Sistem</th>	
										<td>Rack & Pinion with Electric Power Steering (EPS)</td>
										<td>Rack & Pinion with Electric Power Steering (EPS)</td>
										<td>Rack & Pinion with Electric Power Steering (EPS)</td>
									</tr>
									<tr>
										<th>Tilt Steering</th>	
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>
									<tr>
										<th>Telescopic Steering</th>	
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>
										
									<!--Suspensi-->
									<tr class="active">
										<td colspan="4" align="center"><b>Sistem Suspensi</b></td>
									</tr>
									<tr>
										<th class="col-md-3"></th>
										<th class="col-md-3">Civic 1.8 L</th>	
										<th class="col-md-3">Civic 1.8 L A/T</th>
										<th class="col-md-3">Civic 2.0 L A/T</th>
									</tr>
									<tr>
										<th>Suspensi Depan</th>	
										<td>MacPherson Strut</td>
										<td>MacPherson Strut</td>
										<td>MacPherson Strut</td>
									</tr>
									<tr>
										<th>Suspensi Belakang</th>	
										<td>Double Wishbone</td>
										<td>Double Wishbone</td>
										<td>Double Wishbone</td>
									</tr>		
									
									<!--Rem-->
									<tr class="active">
										<td colspan="4" align="center"><b>Sistem Rem</b></td>
									</tr>
									<tr>
										<th class="col-md-3"></th>
										<th class="col-md-3">Civic 1.8 L</th>	
										<th class="col-md-3">Civic 1.8 L A/T</th>
										<th class="col-md-3">Civic 2.0 L A/T</th>
									</tr>
									<tr>
										<th>Brake Override System</th>
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>
									<tr>
										<th>ABS + EBD</th>	
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>
									<tr>
										<th>Brake Assist (BA)</th>	
										<td>NO</td>
										<td>NO</td>
										<td>YES</td>
									</tr>	
										
									<!--Ban-->
									<tr class="active">
										<td colspan="4" align="center"><b>Ban</b></td>
									</tr>
									<tr>
										<th class="col-md-3"></th>
										<th class="col-md-3">Civic 1.8 L</th>	
										<th class="col-md-3">Civic 1.8 L A/T</th>
										<th class="col-md-3">Civic 2.0 L A/T</th>
									</tr>	
									<tr>
										<th>Ban</th>	
										<td>205 / 55 R16</td>
										<td>205 / 55 R16</td>
										<td>215 / 45 R17</td>
									</tr>	
									<tr>
										<th>Roda</th>	
										<td>Alloy Wheel 16" x 6 1/2 J</td>
										<td>Trim Wheel 16" x 6 1/2 J</td>
										<td>Alloy Wheel 17" x 7j</td>
									</tr>	
											
									<!--Eksterior-->
									<tr class="active">
										<td colspan="4" align="center"><b>Eksterior</b></td>
									</tr>
									<tr>
										<th class="col-md-3"></th>
										<th class="col-md-3">Civic 1.8 L</th>	
										<th class="col-md-3">Civic 1.8 L A/T</th>
										<th class="col-md-3">Civic 2.0 L A/T</th>
									</tr>
									<tr>
										<th>Front Lamp</th>	
										<td>Halogen Projector Headlight</td>
										<td>Halogen Projector Headlight</td>
										<td>HID Projector Headlight</td>												
									</tr>			
									<tr>
										<th>Fog Lamp</th>	
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>	
									<tr>
										<th>Door Mirror</th>	
										<td>Body Color (Power Retractable w/ LED Turning Signal)</td>
										<td>Body Color (Power Retractable w/ LED Turning Signal)</td>
										<td>Body Color (Power Retractable w/ LED Turning Signal)</td>
									</tr>	
									<tr>
										<th>Door Handle</th>	
										<td>Chrome</td>
										<td>Chrome</td>
										<td>Chrome</td>
									</tr>
									<tr>
										<th>Led High Mount Stop Lamp</th>	
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>
									<tr>
										<th>Auto Off Headlight</th>	
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>
										
									<!--Interior-->
									<tr class="active">
										<td colspan="4" align="center"><b>Interior</b></td>
									</tr>
									<tr>
										<th class="col-md-3"></th>
										<th class="col-md-3">Civic 1.8 L</th>	
										<th class="col-md-3">Civic 1.8 L A/T</th>
										<th class="col-md-3">Civic 2.0 L A/T</th>
									</tr>
									<tr>
										<th>Audio</th>				
										<td>8,0" Touch Screen, Navigation, CD/DVD Player, MP3/WMA, AM/FM, Aux-In, USB Port, Clock Display, Made for iPod/iPhone, Remote Control</td>
										<td>8,0" Touch Screen, Navigation, CD/DVD Player, MP3/WMA, AM/FM, Aux-In, USB Port, Clock Display, Made for iPod/iPhone, Remote Control</td>
										<td>8,0" Touch Screen, Navigation, CD/DVD Player, MP3/WMA, AM/FM, HDMI Port, USB Port, Clock Display, Made for iPod/iPhone, Remote Control, Bluetooth</td>
									</tr>	
									<tr>
										<th>Multi Information LCD Display (MIL)</th>	
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>										
									<tr>
										<th>ECO Assist</th>
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>	
										
									<!--Keselamatan-->
									<tr class="active">
										<td colspan="4" align="center"><b>Fitur Keselamatan</b></td>
									</tr>
									<tr>
										<th class="col-md-3"></th>
										<th class="col-md-3">Civic 1.8 L</th>	
										<th class="col-md-3">Civic 1.8 L A/T</th>
										<th class="col-md-3">Civic 2.0 L A/T</th>
									</tr>
									<tr>
										<th>Struktur Rangka Bodi</th>	
										<td>G-CONE + ACE</td>
										<td>G-CONE + ACE</td>
										<td>G-CONE + ACE</td>
									</tr>	
									<tr>
										<th>Side Impact Beam</th>
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>	
									<tr>
										<th>Pedestrian Protection</th>
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>	
									<tr>
										<th>Dual Front SRS Airbags</th>	
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>
									<tr>
										<th>Motion Adaptive EPS</th>	
										<td>NO</td>
										<td>NO</td>
										<td>YES</td>
									</tr>
								
									<!--Keamanan-->
									<tr class="active">
										<td colspan="4" align="center"><b>Sistem Keamanan</b></td>
									</tr>
									<tr>
										<th class="col-md-3"></th>
										<th class="col-md-3">Civic 1.8 L</th>	
										<th class="col-md-3">Civic 1.8 L A/T</th>
										<th class="col-md-3">Civic 2.0 L A/T</th>
									</tr>
									<tr>
										<th>Key Type</th>	
										<td>Jack Knife Key</td>
										<td>Jack Knife Key</td>
										<td>Smart Key</td>
									</tr>
									<tr>
										<th>Keyless Entry</th>	
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>	
									<tr>
										<th>Immobilizer</th>	
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>										
									<tr>
										<th>Alarm System</th>
										<td>YES</td>
										<td>YES</td>
										<td>YES</td>
									</tr>	
								</tbody>
							</table>
						</div>
					</div>
							
					<!--Tab Harga -->
					<div class="tab-pane" id="harga">	
						<table class="table table-striped table-bordered table-hover">
							<thead>									
								<tr>
									<th class="col-md-1">Tipe</th>
									<th class="col-md-1">Harga</th>         
								</tr>
							</thead>
							<tbody>
								<input type ="hidden" id="jml_mobil" value="<?php echo $jml_mobil->jml_mobil?>"></td>
							    <?php $no=1; foreach  ($harga as $b):?>
								<tr>
									<td><?php echo $b->jns_mobil?>	
									<input type ="hidden" id="<?php echo 'jenis'.$no ;?>" value="<?php echo $b->jns_mobil?>"></td>	
									<td>Rp <?php echo number_format($b->harga,2,",",".")?>
									<input type ="hidden" id="<?php echo 'harga'.$no ;?>" value="Rp <?php echo number_format($b->harga,2,",",".")?>">
									<input type ="hidden" id="<?php echo 'harga1'.$no ;?>" value="<?php echo $b->harga?>"></td>
								</tr>
								<?php $no++; endforeach ?>
							</tbody>
						</table>
						<p style="font-size:14px;"><b>Keterangan:</b></p>
							<p style="font-size:10px;">Harga On The Road Jakarta per tanggal<b> <?php echo $tglUpdate->tglUpdate ?> </b> <br> 
							Harga bisa berubah sewaktu-waktu, tanpa ada pemberitahuan terlebih dahulu. Silakan menghubungi Dealer Honda Mugen 021 797 3000 (Pasar Minggu) atau 021 5835 8000 (Puri) <br>
						</p>
					</div>
					
					<!--Tab Spesifikasi -->
					<div class="tab-pane <?php if ($tab=='simulasi'){echo 'active';} else{echo '';}?>" id="simulasi">				
						<form action="<?php echo base_url().'civic'?>" method="post">
							<table align="center" style="height:250px">
								<tr>
									<td><label class="control-label" for="leasing">Leasing:</td> 
									<td>
										<div class="col-lg-12">
											<select class="form-control" id="leasing" name="leasing">
												<option value="none">-Pilih Leasing-</option>
												<?php foreach  ($leasing as $b):?>
												<option value="<?php echo $b->id_leasing?>"><?php echo $b->nm_leasing?></option>
												<?php endforeach ?>
											</select>
											
										</div>
									</td>	
								</tr>
								<tr>
									<td><label class="control-label" for="tipe">Tipe Mobil:</td> 
									<td>
										<div class="col-lg-12">
											<input type="hidden" value="0.75" id="batasAtas">
											<input type="hidden" value="0.3" id="batasBawah">
											<select class="form-control" id="tipe" name="tipe" onchange="harga()">
												<option value="none">-Pilih Tipe Mobil-</option>
												<?php foreach  ($harga as $b):?>
												<option value="<?php echo $b->jns_mobil?>"><?php echo $b->jns_mobil?></option>
												<?php endforeach ?>
											</select>
											
										</div>
									</td>	
								</tr>
								<tr>
									<td><label class="control-label" for="tipe">Harga:</td>
									<td>
										<div class="col-lg-12">
											<input class="form-control" name="hargaMobil" id="hargaMobil" readonly="readonly">
										</div>
									</td>
								</tr>
								<tr>
									<td><label class="control-label" for="tenor">Tenor:</td>
									<td>
										<div class="col-lg-12">
											<select  class="form-control col-sm-3" name="tenor">
												<option value="none">-Pilih Tenor-</option>
												<option value="12">12</option>
												<option value="24">24</option>
												<option value="36">36</option>
												<option value="48">48</option>
												<option value="60">60</option>
											</select>
										</div>
									</td>
								</tr>
								<tr>
									<td><label class="control-label" for="tipe">Bentuk DP:</td>
									<td><div class="col-lg-12">
											<select id="bentukDp" name="bentukDp" class="form-control col-sm-3" onchange="downpayment()">
												<option value="none">-Pilih Bentuk DP-</option>
												<option value="%">%</option>
												<option value="Rp">Rp</option>
											</select>
										</div>
									</td>
								</tr>
								<tr>	
								<td><label class="control-label" for="tipe">Nominal DP:</td>
									<td>
										<div class="col-lg-12">
											<div id="hasil"></div>
										</div>
									</td>
								</tr>
							</table>
							<center>
								<div id="box" class="box"><p style="text-align:left"><b>Keterangan:</b> <br>Nominal DP min 30% dan max 75% dari harga Mobil </p> </div>
							</center>
							<center><input type="submit" id="Submit" disabled="true" class="btn btn-primary" value="Hitung"></center>
						</form>	
					</div>
				</div>
			</div>
		</div>
	</section>
	
	<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.11.3/jquery.js"></script>
		<?php if($tipe==null && $tenor==null){
		echo ""; 
		}else{?>
			<style>
			#preloader {
			 position:fixed;
			 top:0;
			 left:0;
			 right:0;
			 bottom:0;
			 background-color:#fff; 
			 z-index:99; 
			}

			#loading {
			 width:200px;
			 height:200px;
			 position:absolute;
			 top: 60%;
			 left:50%;
			 background-image:url(image/loading.gif); 
			 background-repeat:no-repeat;
			 background-position:center;
			 margin:-100px 0 0 -100px; 
			}
			</style>
		
			<script>
				<!-- mulai coding modal -->
				$(window).load(function(){        
					$("#preloader").delay(500).fadeOut("slow");
					$('#myModal').modal('show');
				}); 
			</script>
			<div id="preloader">
				<div id="loading"></div>
			</div>
			<div class="modal fade bs-example-modal-lg" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
				<div class="modal-dialog modal-lg">
					<div class="modal-content">
						<br>
						<center><h3 style="color:#e01425"><?php echo $tipe?></h3></center>
						<table align="center">
							
							<tr>
								<td><b>Harga</b></td>
								<td>&nbsp :</td>
								<td>&nbsp <?php echo "Rp " . number_format($kredit['hargaMobil'],2,',','.');?></td>
							</tr>
							<tr>
								<td><b>Nominal DP</b></td>
								<td>&nbsp :</td>
								<td>&nbsp <?php echo $kredit['dp'];?></td>
							</tr>
							<tr>
								<td><b>Tenor</b></td>
								<td>&nbsp :</td>
								<td>&nbsp <?php echo $kredit['tenor']?> Bulan</td>
							</tr>
							<tr>
								<td><b>Angsuran</b></td>
								<td>&nbsp :</td>
								<td>&nbsp <?php echo "Rp " . number_format($kredit['apb'],2,',','.')." /bulan";?></td>
							</tr>
							<tr>
								<td><b>TDP</b></td>
								<td>&nbsp :</td>
								<td>&nbsp <?php echo "Rp " . number_format($kredit['tdp'],2,',','.');?></td>
							</tr>					
						</table>
						<p style="margin-left: 40px; font-size:12px;"><b>Keterangan:</b></p>
						<ul>
							<li style="margin-left: 40px; font-size:10px;">Harga yang digunakan adalah On The Road Jakarta per tanggal<b> <?php echo $tglUpdate->tglUpdate ?></b>.</li>
							<li style="margin-left: 40px; font-size:10px;">Simulasi perhitungan kredit berdasarkan rate <b><?php echo $data_leasing->nm_leasing?></b> periode <b><?php echo $data_leasing->tgl_update?></b> dengan kondisi Asuransi AllRisk.</li>
							<li style="margin-left: 40px; font-size:10px;">Simulasi perhitungan kredit ini tidak mengikat dan dapat berubah sewaktu-waktu tanpa pemberitahuan.</li>
							<li style="margin-left: 40px; font-size:10px;">Simulasi perhitungan kredit ini berupa asumsi dan untuk perhitungan riil silahkan menghubungi Dealer Honda Mugen 021 797 3000 (Pasar Minggu) atau 021 5835 8000 (Puri).</li>
						</ul>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
					</div>
				</div>
			</div>
			
		<?php }?>

<style>
.video-container {
	position:relative;
	padding-bottom:56.25%;
	padding-top:30px;
	height:0;
	overflow:hidden;
}

.video-container iframe, .video-container object, .video-container embed {
	position:absolute;
	top:0;
	left:0;
	width:100%;
	height:100%;
}
.box {
	  width: 400px;
      height: 80px;
      padding: 15px;
      border: 5px solid red;
      margin: 20px;
      background-color: yellow;
      display:none;
}
</style>

<script>

	function harga(){
		var tipe = document.getElementById('tipe').value;	
		for (i = 1; i <= document.getElementById('jml_mobil').value; i++) { 
			if (tipe == document.getElementById('jenis' + i).value){
			document.getElementById('hargaMobil').value = document.getElementById('harga' + i).value;
			}
		}
	}

	function downpayment() {
		var dp =document.getElementById('bentukDp').value;				
		if (dp=='Rp'){
			document.getElementById("Submit").disabled = true;
			abc='<input type="text" class="form-control" name="dp" id="dp" onchange="separator()">';
			document.getElementById("hasil").innerHTML= abc;
			document.getElementById("box").style.display = 'block';	
		}
		else if (dp=='%'){
			abc='<select id="dp" class="form-control col-sm-3" name="dp"><option value="30%">30%</option><option value="35%">35%</option><option value="40%">40%</option><option value="45%">45%</option><option value="50%">50%</option><option value="55%">55%</option><option value="60%">60%</option><option value="65%">65%</option><option value="70%">70%</option><option value="75%">75%</option></select>';
			document.getElementById("hasil").innerHTML= abc;
			document.getElementById("Submit").disabled = false;
			document.getElementById("box").style.display = 'none';	
		}
	}
	
	function separator(){
		
		var tipe = document.getElementById('tipe').value;	
		for (i = 1; i <= document.getElementById('jml_mobil').value; i++) { 
			if (tipe == document.getElementById('jenis' + i).value){
				var dp=document.getElementById('dp').value;	
				var hargaMobil = document.getElementById('harga1' + i).value;
				var batasAtas = 0.75 * hargaMobil;
				var batasBawah = 0.3 * hargaMobil;
				if (dp >= batasBawah && dp <= batasAtas){
					document.getElementById("Submit").disabled = false;
				}
				else{document.getElementById("Submit").disabled = true;}
			}
		}
		
		document.getElementById("dp").onblur =function (){    
		this.value = parseFloat(this.value.replace(/,/g, ""))
			//.toFixed(2)
			.toString()
            .replace(/\B(?=(\d{3})+(?!\d))/g, ".");
		}
	}
</script>