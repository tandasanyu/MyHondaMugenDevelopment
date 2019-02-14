<?php IF ($id_lowongan!=$lowongan->id_lowongan){echo ("<script language='JavaScript'>
					window.alert('Maaf Posisi Yang Anda Inginkan Tidak Tersedia!')
					window.location.href='http://localhost:8080/hondamugen/karir/';
					</script>");}else{?>
<title>Daftar Akun Lamaran Kerja</title>
<section id="content">
</section>
<section id="content">
	<div class="container">
		<div class="row">
			<div class="col-lg-8">
				<h2>Form Pendaftaran Akun Lamaran Kerja</h2><br>
				<form class="form-horizontal" id="frm-mhs" method="post" action="<?php echo base_url().'welcome/simpanAkun'?>">
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
						<label class="control-label col-sm-3" for="Username">Username:</label>
						<div class="col-sm-6">
							<input type="text" class="form-control required" id="username" name="username">
							<h5 class="panel-title"><font color="red"><?php echo $pesan;?></font></h5>
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="password">Password:</label>
						<div class="col-sm-6">
							<input type="password" class="form-control required" id="password" name="password">
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-sm-3" for="email">Email:</label>
						<div class="col-sm-6">
							<input type="text" class="form-control required" id="email" name="email">
						</div>
					</div>
					<input type="hidden" value="<?php echo $lowongan->id_lowongan?>" name="id_lowongan">
					<?php echo $script_captcha; // javascript recaptcha ?>
					<center>  <?php echo $captcha // tampilkan recaptcha ?></center><br>
					<div class="form-group"> 
						<div class="col-sm-offset-5 col-sm-10">
							<input type="submit" class="btn btn-primary" value="Daftar">
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