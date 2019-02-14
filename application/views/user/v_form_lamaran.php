<?php IF ($id_lowongan!=$lowongan->id_lowongan){echo ("<script language='JavaScript'>
					window.alert('Maaf Posisi Yang Anda Inginkan Tidak Tersedia!')
					window.location.href='http://www.hondamugen.co.id/karir/';
					</script>");}else{?>
<title>Form Lamaran</title>
<section id="content">
</section>
<section id="content">
	<div class="container">
		<div class="row">
			<div class="col-lg-8">
				<h2>Form Lamaran</h2><br>
				<form class="form-horizontal" id="frm-mhs" enctype="multipart/form-data" method="post" action="<?php echo base_url().'index.php/welcome/simpanlamaran'?>">
					<div class="form-group">
						<label class="control-label col-sm-3" for="tgl_apply">Tanggal Apply:</label>
						<div class="col-sm-6">
							<input type="text" class="form-control" id="tgl_apply" value="<?php echo date('d-m-Y')?>" name="tgl_apply" readonly="readonly">
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="posisi">Posisi:</label>
						<div class="col-sm-6"> 
							<input type="text" class="form-control" id="posisi" name="posisi" value="<?php echo $lowongan->posisi?>" readonly="readonly">
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="nama">Nama Lengkap:</label>
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
						<label class="control-label col-sm-3" for="pendidikan">Pendidikan Terakhir</label>
						<div class="col-sm-6"> 
							<select class="form-control" id="pendidikan" name="pendidikan">
								<option>- Pilih Pendidikan -</option>
								<option value="SMP">SMP</option>
								<option value="SMA/K">SMA/K</option>
								<option value="D3">D3</option>
								<option value="S1">S1</option>
								<option value="S2">S2</option>
							</select>		
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="cv">Unggah CV:</label>
						<div class="col-sm-6">
							<input type="file" class="form-control" id="cv" name="userfile">
							<p style="font-size:12px;">
									<b><font color="red">*File cv tidak boleh lebih dari 500kb <br> 
														 Format file CV berupa .doc / .docx / .pdf  </font></b>	
							</p>
						</div>
					</div>
					<input type="hidden" value="<?php echo $lowongan->id_lowongan?>" name="id_lowongan">
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
<?php } ?>