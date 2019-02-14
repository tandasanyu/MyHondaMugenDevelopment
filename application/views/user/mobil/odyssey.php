	<title>Honda Odyssey</title>
	<section id="content"></section>
	<section id="content">
		<div class="container">
			<div class="col-sm-12 col-lg-12">
				<h2>Honda Odyssey 2.4L Prestige</h2>
				<!-- Slider -->
				<div id="main-slider" class="main-slider flexslider">
					<ul class="slides">
					  <li>
						<img src="<?php echo base_url().'image/Odyseey.jpg'?>" alt="" />
					  </li>
					  <li>
						<img src="<?php echo base_url().'image/Odyseey2.jpg'?>" alt="" />
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
					<li><a href="<?php echo base_url().'brosur/Odyssey.pdf'?>">Unduh Brosur</a></li>
				</ul>
						
				<div class="tab-content">
					<!--Tab Video-->					
					<div class="tab-pane <?php if ($tab=='video'){echo 'active';} else{echo '';}?>" id="video">
						<div class="video-container">		
							<iframe width="800" height="400" src="https://www.youtube.com/embed/pDLacwa0Dhc" frameborder="0" allowfullscreen></iframe>
						</div>	
					</div>
					
					<!--Tab Preview
					<div class="tab-pane" id="preview">
						<div class="video-container">		
							<iframe width="1000" height="400" src="https://www.honda-indonesia.com/model/type-r" frameborder="0" allowfullscreen></iframe>
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
										<th class="col-md-3">Tipe</th>	
										<td>2.4L 4 Silinder Segaris, i-VTEC DOHC, 16 Katup + DBW</td>
									</tr>
									<tr>
										<th class="col-md-3">Sistem Suplai Bahan Bakar</th>	
										<td>PGM-FI</td>
									</tr>
									<tr>
										<th class="col-md-3">Diameter x Langkah</th>	
										<td>87mm x 99,1mm</td>
									</tr>
									<tr>
										<th class="col-md-3">Isi Silinder</th>
										<td>2.356</td>
									</tr>
									<tr>
										<th class="col-md-3">Perbandingan Kompresi</th>	
										<td>10,1:1</td>
									</tr>
									<tr>
										<th class="col-md-3">Daya Maksimum</th>	
										<td>175 PS / 6.200 rpm</td>	
									</tr>			
									<tr>
										<th class="col-md-3">Momen Puntir Maksimum</th>	
										<td>23 kg.m / 4.000 rpm</td>
									</tr>
										
									<!--Dimensi-->
									<tr class="active">
										<td colspan="4" align="center"><b>Dimensi</b></td>
									</tr>
									<tr>
										<th>Panjang x Lebar x Tinggi</th>	
										<td>4.830mm x 1.820mm x 1.695mm</td>
									</tr>
									<tr>
										<th>Jarak Sumbu Roda</th>	
										<td>2.900mm</td>
									</tr>
									<tr>
										<th>Jarak Pijak Depan / Belakang</th>	
										<td>1.560mm / 1.560mm</td>		
									</tr>
									<tr>
										<th>Ground Clearance</th>	
										<td>150mm</td>		
									</tr>
									<tr>
										<th>Radius Putar</th>	
										<td>5,4m</td>		
									</tr>
									<tr>
										<th>Kapasitas Tangki</th>	
										<td>55L</td>		
									</tr>
									<tr>
										<th>Berat Kosong</th>	
										<td>1.855</td>		
									</tr>
										
									<!--Transmisi-->
									<tr class="active">
										<td colspan="4" align="center"><b>Transmisi</b></td>
									</tr>
									<tr>
										<th>Tipe</th>
										<td>CVT</td>	
									</tr>
										
									<!--Kemudi-->
									<tr class="active">
										<td colspan="4" align="center"><b>Sistem Kemudi</b></td>
									</tr>
									<tr>
										<th>Sistem</th>	
										<td>Rack & Pinion</td>
									</tr>
									<tr>
										<th>Electronic Power Steering (EPS)</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Tilt Steering</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Telescopic Steering</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
										
									<!--Suspensi-->
									<tr class="active">
										<td colspan="4" align="center"><b>Sistem Suspensi</b></td>
									</tr>
									<tr>
										<th>Suspensi Depan</th>	
										<td>MacPherson Strut</td>
									</tr>
									<tr>
										<th>Suspensi Belakang</th>	
										<td>Torsion Beam</td>
									</tr>
									<tr>
										<th>Sporty Tuned Suspension</th>	
										<td></td>
									</tr>									

									<!--Rem-->
									<tr class="active">
										<td colspan="4" align="center"><b>Sistem Rem</b></td>
									</tr>
									<tr>
										<th>Rem Depan</th>
										<td>Ventilated Disc</td>		
									</tr>
									<tr>
										<th>Rem Belakang</th>
										<td>Solid Disc (Drum in Disc)</td>			
									</tr>
									<tr>
										<th>ABS + EBD</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Brake Assist (BA)</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
										
									<!--Ban-->
									<tr class="active">
										<td colspan="4" align="center"><b>Ban</b></td>
									</tr>
									<tr>
										<th>Ban</th>	
										<td>215/55 R17</td>
									</tr>	
									<tr>
										<th>Velg</th>	
										<td>17x7J</td>
									</tr>	
											
									<!--Eksterior-->
									<tr class="active">
										<td colspan="4" align="center"><b>Eksterior</b></td>
									</tr>
									<tr>
										<th>Head Lamp</th>
										<td>LED Projector</td>
									</tr>
									<tr>
										<th>Daytime Running Light</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Fog Lamp</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Auto Leveling</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Auto On/Off Headlights</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Heat Rejecting Green Tinted Glass</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Power Retractable Door Mirror</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Rear Parking Camera</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Aero Kit</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Rear Combi Stop Lamp</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>LED High Mount Stop Lamp</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
							
									<!--Interior-->
									<tr class="active">
										<td colspan="4" align="center"><b>Interior</b></td>
									</tr>
									<tr>
										<th>Audio</th>				
										<td>7,0" Capacitive Touchscreen Monitor, CD/DVD, USB Port, HDMI Port, Made for iPod & iPhone, Clock Display, Cooperated with Smartphone (need Cable), Corresponding to Multi View Camera Assist (MVA)/Cross Traffic Monitor (CTM) / Smart Parking Assist System <br><br>

											*Untuk beberapa model dan/atau tipe mobil Honda yang dilengkapi Sistem Navigasi, dibutuhkan update map secara berkala dengan keseluruhan biaya ditanggung oleh konsumen</td>	
									</tr>
									<tr>
										<th>Tweeter Speaker</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>One Push Ignition System</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Audio Steering Switch</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Paddle Shift</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Cruise Control</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>ECON Mode</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Seat Adjustment Driver</th>	
										<td>8 Way + Memory</td>
									</tr>
									<tr>
										<th>Seat Adjustment Passenger</th>	
										<td>4 Way</td>
									</tr>
									<tr>
										<th>Interior Color</th>	
										<td>Black</td>
									</tr>
									<tr>
										<th>Seat Material</th>	
										<td>Leather</td>
									</tr>
									<tr>
										<th>Sunroof</th>	
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
										
									<!--Keselamatan-->
									<tr class="active">
										<td colspan="4" align="center"><b>Fitur Keselamatan</b></td>
									</tr>
									<tr>
										<th>Dual Front i-SRS Airbags</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Side Airbags</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Side Curtain Airbags</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Sabuk Keselamatan (Baris Pertama)</th>
										<td>3P ELR (x2)</td>
									</tr>	
									<tr>
										<th>Sabuk Keselamatan (Baris Kedua)</th>
										<td>3P ELR (x2)</td>
									</tr>	
									<tr>
										<th>Sabuk Keselamatan (Baris Ketiga)</th>
										<td>3P ELR (x3)</td>
									</tr>	
									<tr>
										<th>Seatbelt Reminder</th>
										<td>Driver + Front Passanger</td>
									</tr>	
									<tr>
										<th>Pretensioner with Load Limiter Seatbelt</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>ISOFIX & Tether</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Vehicle Stability Assist (VSA)</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Hill Start Assist (HSA)</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Emergency Stop Signal (ESS)</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Brake Override System</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>
									<tr>
										<th>Smart Parking Assist System</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	

									<!--Keamanan-->
									<tr class="active">
										<td colspan="4" align="center"><b>Sistem Keamanan</b></td>
									</tr>
									<tr>
										<th>Alarm System</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Auto Door Lock by Speed</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Immobilizer</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Smart Key</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Rear Trunk Opener</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
									</tr>	
									<tr>
										<th>Keyless Entry</th>
										<td><i class="fa fa-check" aria-hidden="true"></i></td>
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