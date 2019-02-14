<title>Booking Service</title>
<section id="content">
</section>
<section id="content">
	<div class="container">
		<div class="row">
			<div class="col-lg-8">
				<form method="post" action="<?php echo base_url().'jadwalpud'?>">
					<table>
						<tr>
							<td><label class="control-label col-sm-8" for="tanggal">Tanggal:</label></td>
							<td><div class="input-group">
									<input type="text" class="form-control" id="datepicker2" name="booking_tgl" readonly="readonly" placeholder="dd-mm-yyyy">
									
									</div>
								
							</td>
							<td>&nbsp <input type="submit" class="btn btn-info" value="cari"></td>
						</tr>
					</table>
				</form>	<br>
				
				
				<h3>Estimasi Waktu Tersedia Untuk Campaign PUD Ps. Minggu</h3>
				<h4><?php echo $tanggal; ?></h4><br>
				<?php if ($hitungbooking1 < 5 and $tanggal != date("d-m-Y")){ ?>
				<form action="<?php echo base_url().'form_bookingpud'?>" method="post">
					<input type="hidden" name="tanggal" value="<?php echo $tanggal?>">
					<input type="hidden" name="lokasi" value="Ps. Minggu">					
					<input type="submit" class="btn btn-primary" value="Pengajuan Jadwal PUD">
				</form>
					<?php }else{?><a class="btn btn-primary" href="#" disabled="true">Pengajuan Jadwal PUD</a><?php }?><br><br>
				<div class="table-responsive">
					<table class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
								<th>No</th>
								<th>Jam Kunjungan</th>
								<th>Nama</th>
                                <th>Tipe Mobil</th>
                            </tr>
                        </thead>
						<tbody>
						<?php $no=1; foreach  ($booking1 as $b): ?>
                            <tr>
								<td align="center" class="col-md-1"><?php echo $no ?></td>
								<td class="col-md-2"><?php echo $b->booking_jam ?></td>
								<td class="col-md-2"><?php echo $b->booking_nama ?></td>
								<td class="col-md-3">Honda <?php echo $b->booking_tipe ?></td>
                            </tr>
						<?php $no++; endforeach ?>
						</tbody>
                    </table>
					<font color="red">* Pemeriksaan dan pergantian parts jika tersedia<br>
									  ** Request Campaign PUD tidak dapat dilakukan pada hari H</font>
				</div>		<br><br>

				<h3>Estimasi Waktu Tersedia Untuk Campaign PUD Puri</h3>
				<h4><?php echo $tanggal; ?></h4><br>
				<?php if ($hitungbooking2 < 5 and $tanggal != date("d-m-Y")){ ?>
				<form action="<?php echo base_url().'form_bookingpud'?>" method="post">
					<input type="hidden" name="tanggal" value="<?php echo $tanggal?>">		
					<input type="hidden" name="lokasi" value="Puri">		
					<input type="submit" class="btn btn-primary" value="Pengajuan Jadwal PUD">
				</form>
					<?php }else{?><a class="btn btn-primary" href="#" disabled="true">Pengajuan Jadwal PUD</a><?php }?><br><br>
				<div class="table-responsive">
					<table class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
								<th>No</th>
								<th>Jam Kunjungan</th>
								<th>Nama</th>
                                <th>Tipe Mobil</th>
                            </tr>
                        </thead>
						<tbody>
						<?php $no=1; foreach  ($booking2 as $b): ?>
                            <tr>
								<td align="center" class="col-md-1"><?php echo $no ?></td>
								<td class="col-md-2"><?php echo $b->booking_jam ?></td>
								<td class="col-md-2"><?php echo $b->booking_nama ?></td>
								<td class="col-md-3">Honda <?php echo $b->booking_tipe ?></td>
                            </tr>
						<?php $no++; endforeach ?>
						</tbody>
                    </table>
					<font color="red">* Pemeriksaan dan pergantian parts jika tersedia<br>
									  ** Request Campaign PUD tidak dapat dilakukan pada hari H</font>
				</div>	
			</div>
			<!--Menampilkan Sidebar!-->
			<?php include('sidebar.php');?>
		</div>
	</div>
</section>