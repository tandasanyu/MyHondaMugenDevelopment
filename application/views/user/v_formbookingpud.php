<?php if ($tanggal != NULL or $tanggal != ""){?>

<title>Form Booking PUD</title>
<section id="content">
</section>
<section id="content">
	<div class="container">
		<div class="row">
			<div class="col-lg-8">
				<h2>Form Booking Service</h2><br>
				<form class="form-horizontal" id="frm-mhs" method="post" action="<?php echo base_url().'simpan_bookingservice'?>">
					<div class="form-group">
						<label class="control-label col-sm-3" for="tgl">Tanggal Booking:</label>
						<div class="col-sm-6">
							<input type="text" class="form-control required" readonly="readonly" value="<?php echo $tanggal ?>" id="booking_tgl" name="booking_tgl">
						</div>
					<!-- /.input group -->
					</div>
					
					<div class="form-group">
						<label class="control-label col-sm-3" for="tgl">Lokasi Booking:</label>
						<div class="col-sm-6">
							<input type="text" class="form-control required" readonly="readonly" value="Honda Mugen <?php echo $lokasi ?>" id="booking_lokasi" name="booking_lokasi">
						</div>
					<!-- /.input group -->
					</div>
					
					<div class="form-group">
						<label class="control-label col-sm-3" id="labelfrm" for="nama">Nama Lengkap:</label>
						<div class="col-sm-6">
							<input type="text" class="form-control required" id="nama" name="booking_nama">
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="email">Email:</label>
						<div class="col-sm-6">
							<input type="text" class="form-control required" id="email" name="booking_email">
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="nohp">No Handphone:</label>
						<div class="col-sm-6">
							<input type="text" class="form-control required" id="nohp" name="booking_tlp">
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="nohp">No Polisi</label>
						<div class="col-sm-6">
							<input type="text" class="form-control required" id="nopol" name="booking_nopol">
						</div>
					</div>
					
					<div class="form-group">
						<label class="control-label col-sm-3" for="kendaraan">Tipe Kendaraan</label>
						<div class="col-sm-6"> 
							<select class="form-control required" id="booking_tipe" name="booking_tipe">
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

					<div class="form-group">
						<label class="control-label col-sm-3" for="jam">Jam Kunjungan:</label>
						<div class="col-sm-6">
							<select class="form-control required" id="booking_jam" name="booking_jam">
								<option>- Pilih Jam Kunjungan -</option>
								<?php if ($jambooking1 < 5){?>
								<option value="13.00">13.00</option>
								<?php }?>
								<?php if ($jambooking2 < 5){?>
								<option value="14.00">14.00</option>
								<?php }?>
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
<?php } else {
    	echo ("<script language='JavaScript'>
				window.alert('Maaf, Anda Harus Memilih Tanggal Booking Terlebih Dahulu!')
				window.location.href='http://www.hondamugen.co.id/bookingpud';
				</script>");
}?>
}
