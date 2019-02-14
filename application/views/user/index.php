<title>Beranda</title>
<section id="content">
</section>
<section id="featured" class="bg">
<!-- start slider -->
	<div class="container">
		<div class="row">
			<div class="col-lg-12">
				<!-- Slider -->
				<div id="main-slider" class="main-slider flexslider">
					<ul class="slides">
					    <?php foreach ($slide as $b):?>
					    <li>
						    <img src="<?php echo base_url();?>image/<?php echo $b->path ?>" alt="" />
					    </li>
					    <?php endforeach ?>
					</ul>
				</div>
				<!-- end slider -->
			</div>
		</div>
	</div>	
</section>

<section id="content">
	<div class="container">
		<div class="row">
			<div class="col-lg-12">
				<div class="row">	
					<div id="tentangkami" style="display:none;">
						<div class="col-sm-8 col-lg-8">
					
							<center><h2>Tentang Kami</h2></center>
							<p style="text-align:center">
								PT Mitrausaha Gentaniaga, selama ini lebih dikenal dengan 
								nama HONDA MUGEN adalah Authorized Honda Dealer atau 
								perwakilan resmi Honda yang didirikan pada tanggal 20 
								November 1991 dan disahkan oleh Departemen Perdagangan 
								dengan diberikannya surat izin usaha perdagangan (SIUP) 
								313/F/09-04/PB/IX/93, NPWP 01.546.533.9-062.000 
								(Pasar Minggu) Dan NPWP 01.546.533.9-062.001 
								(Puri Kembangan).<a href="<?php echo base_url().'index.php/welcome/profile'?>"> Selanjutnya</a>
							</p>
							
						
						</div>
						<div class="col-sm-4 col-lg-4">
							<center>
								<img src="<?php echo base_url().'image/banner1.png'?>" class="img-responsive" width="250" height="200" />
							</center>
						</div>	
					</div>	
				</div>
			</div>
		</div>
	</div>
		
	<div id="layanankami" style="display:none;">	
		<!-- divider -->
		<div class="container">
			<div class="row">
				<div class="col-lg-12">
					<div class="dashedline">
					</div>
				</div>
			</div>
		</div>
		<!-- end divider -->
			
		<div class="container">
			<div class="row">
				<div class="col-sm-12 col-lg-12">
					<h2>Layanan Kami</h2>
				</div>
				<div class="col-lg-12">
					<div class="row">
						<div class="col-sm-3 col-md-3 col-lg-3">
							<div class="box">
								<div class="aligncenter">								
									<div class="icon">
										<center><img class="img-circle img-responsive img-center" src="<?php echo base_url().'image/testdrive.png'?>" height="150" width="150" alt=""></center>
									</div>
									<h4>Test Drive</h4>
									Kesempatan yang diberikan kepada konsumen untuk 
									mengetahui kemampuan mobil yang akan dibeli
								</div>
							</div>
						</div>
						<div class="col-sm-3 col-md-3 col-lg-3">
							<div class="box">
								<div class="aligncenter">								
									<div class="icon">
										<center><img class="img-circle img-responsive img-center" src="<?php echo base_url().'image/perbaikan.png'?>" height="150" width="150" alt=""></center>
									</div>
									<h4>Perawatan Umum dan Berkala</h4>
									 Mencegah penurunan performa kendaraan yang diakibatkan 
									 komponen yang aus dan berkarat
								</div>
							</div>
						</div>
						<div class="col-sm-3 col-md-3 col-lg-3">
							<div class="box">
								<div class="aligncenter">								
									<div class="icon">
										<center><img class="img-circle img-responsive img-center" src="<?php echo base_url().'image/painting.png'?>" height="150" width="150" alt=""></center>
									</div>
									<h4>Perbaikan Cat dan Body</h4>
									Pengecetan dan perbaikan body mobil dengan harga 
									terjangkau
								</div>
							</div>
						</div>
						<div class="col-sm-3 col-md-3 col-lg-3">
							<div class="box">
								<div class="aligncenter">								
									<div class="icon">
										<center><img class="img-circle img-responsive img-center" src="<?php echo base_url().'image/sistem.png'?>" height="150" width="150" alt=""></center>
									</div>
									<h4>Penjualan Suku Cadang</h4>
									Menyediakan sparepart resmi mobil Honda dengan harga 
									terjangkau
								</div>
							</div>
						</div>
					</div>
				</div>	
			
			</div>
		</div>
	</div>

	<div id="events" style="display:none;">		
		<!-- divider -->
		<div class="container">
			<div class="row">
				<div class="col-lg-12">
					<div class="dashedline">
					</div>
				</div>
			</div>
		</div>
		<!-- end divider -->
		
		<div class="container">
			<div class="row">
				<div class="col-lg-12">
					<div class="col-sm-12 col-lg-12">
						<h2>Events & Promosi</h2><br>
						    <div style="overflow-x:auto;">
							<?php foreach  ($event as $b): ?>
								<h3><?php echo $b->nm_event ?></h3>
									<p><?php echo date("d-m-Y", strtotime($b->day)) ?></p>
									<p><?php echo $b->keterangan ?></p>
							<?php endforeach ?>	
							
						</div>				
					</div>
				</div>
			</div>
		</div>	
	</div>	
	


</section>

