<title>Form Unggah Foto</title>
	<section id="content" style="background-color:#ffffff;">
		<div class="container">
			<div class="col-sm-12 col-lg-12"><br><br>
				<h1 style="text-align:center;  font-family:Cooper Black;">Form Unggah Surat Lamaran</h1>
			</div>
		</div><br><br><br><br>
<?php if($cekSurat==True){?>
		<div class="container">
			<div class="col-sm-12 col-lg-12">
				<h4 style="color:red; text-align:center;">Anda sudah mengunggah Surat Lamaran. Unggah Surat Lamaran hanya diperbolehkan 1x!</h4>
			</div>
		</div><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
<?php }else{ ?>
		<div class="container">
			<div class="col-sm-12 col-lg-12">
				<form class="form-horizontal" enctype="multipart/form-data"  id="frm-mhs" method="post" action="<?php echo base_url().'career/simpanSurat'?>">		
					<br>	
					<div class="form-group">
						<label class="control-label col-sm-4" for="uploadFoto">Unggah Surat Lamaran</label>
						<div class="col-sm-5">
							<input type="file" class="form-control required" id="uploadFoto" name="userfile">
							<p style="font-size:12px;">
								<b><font color="red">* File Surat Lamaran tidak boleh lebih dari 500kb <br> 
													 &nbsp Format penamaan file Surat Lamaran: LAMARAN_NAMA ANDA <br> 
													 &nbsp Format File Surat Lamaran berupa .pdf  </font></b>	
							</p>
						</div>	
					</div>
				<br><center><input onclick="return confirm('Apakah anda sudah yakin dengan data yang anda isi?');" type="submit" value="Simpan" class="btn btn-primary"></center>	
				</form>	
			</div>
		</div><br><br><br><br><br><br><br><br>
<?php } ?>
	</section>
	
	<script type="text/javascript" src="http://code.jquery.com/jquery.min.js"></script>