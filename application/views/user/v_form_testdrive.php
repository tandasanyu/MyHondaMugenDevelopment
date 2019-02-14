<title>Form Test Drive</title>
<section id="content">
</section>
<section id="content">
	<div class="container">
		<div class="row">
			<div class="col-lg-8">
				<h2>Form Pengajuan Test Drive</h2><br>
				<form class="form-horizontal" id="frm-mhs" method="post" action="<?php echo base_url().'simpan_testdrive'?>">
					<div class="form-group">
						<label class="control-label col-sm-3" id="labelfrm" for="nama">Nama Lengkap:</label>
						<div class="col-sm-6">
							<input type="text" class="form-control required" id="nama" name="nama">
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="email">Email:</label>
						<div class="col-sm-6">
							<input type="text" class="form-control required" id="email" name="email">
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="nohp">No Handphone:</label>
						<div class="col-sm-6">
							<input type="text" class="form-control required" id="nohp" name="nohp">
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="alamat">Alamat:</label>
						<div class="col-sm-6"> 
							<textarea  class="form-control required" name="alamat" rows="6"> </textarea>
						</div>
					</div>
					
					
					<div class="form-group">
						<label class="control-label col-sm-3" for="tgl">Tanggal Kunjungan:</label>
						<div class="col-sm-6">
							<div class="input-group">
								<input type="text" class="form-control required" id="datepicker" name="tgl" placeholder="dd-mm-yyyy" readonly="readonly">
								<div class="input-group-addon">
									<i class="fa fa-calendar"></i>
								</div>
							</div>
						</div>
					<!-- /.input group -->
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="jam">Jam Kunjungan:</label>
						<div class="col-sm-6">
							<select class="form-control required" id="jam" name="jam">
								<option>- Pilih Jam Kunjungan -</option>
								<option value="09.00">09.00</option>
								<option value="10.00">10.00</option>
								<option value="11.00">11.00</option>
								<option value="13.00">13.00</option>
								<option value="14.00">14.00</option>
								<option value="15.00">15.00</option>
								<option value="16.00">16.00</option>
								<option value="17.00">17.00</option>
								<option value="18.00">18.00</option>
							</select>		
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="lokasi">Lokasi Test Drive</label>
						<div class="col-sm-6"> 
							<select class="form-control" id="lokasi" name="lokasi">
								<option value="none">- Pilih Lokasi -</option>
								<option value="Pasar Minggu">Honda Mugen Pasar Minggu</option>
								<option value="Puri">Honda Mugen Puri</option>
							</select>		
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="kendaraan">Tipe Kendaraan</label>
						<div class="col-sm-6"> 
							<select class="form-control required" id="kendaraan" name="kendaraan">
								<option>- Pilih Kendaraan -</option>
								<option value="Accord">Honda Accord</option>
								<option value="Brio">Honda Brio</option>
								<option value="City">Honda City</option>
								<option value="CRV">Honda CRV</option>
								<option value="Civic">Honda Civic</option>
								<option value="HRV">Honda HRV</option>
								<option value="Freed">Honda Freed</option>
								<option value="Jazz">Honda Jazz</option>
								<option value="Mobilio">Honda Mobilio</option>
								<option value="Odyssey">Honda Odyssey</option>
							</select>		
						</div>
					</div>
					<?php echo $script_captcha; // javascript recaptcha ?>
					<center>  <?php echo $captcha // tampilkan recaptcha ?></center><br>
					<div class="form-group"> 
						<div class="col-sm-offset-5 col-sm-10">
							<input type="submit" class="btn btn-primary" value="Kirim">
						</div>
					</div>	
				</form>
			</div>
			<!--Menampilkan Sidebar!-->
			<?php include('sidebar.php');?>	
		</div>
	</div>
</section>
