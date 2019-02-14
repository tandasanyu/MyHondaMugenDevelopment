<title>Form Unggah NPWP</title>
	<section id="content" style="background-color:#ffffff;">
		<div class="container">
			<div class="col-sm-12 col-lg-12"><br><br>
				<h1 style="text-align:center;  font-family:Cooper Black;">Form Unggah NPWP</h1>
			</div>
		</div><br><br><br>
<?php if($cekNPWP==True){?>
		<div class="container">
			<div class="col-sm-12 col-lg-12">
				<h4 style="color:red; text-align:center;">Anda sudah mengunggah NPWP. Unggah NPWP hanya diperbolehkan 1x!</h4>
			</div>
		</div><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
<?php }else{ ?>

		<div class="container">
			<div class="col-sm-12 col-lg-12">
				<form class="form-horizontal" enctype="multipart/form-data"  id="frm-mhs" method="post" action="<?php echo base_url().'career/simpanNPWP'?>">		
					<br>	
					<div class="form-group">
						<label class="control-label col-sm-4" for="uploadFoto">Unggah NPWP</label>
						<div class="col-sm-5">
								<input type="file" class="form-control required" id="uploadFoto" name="userfile">
									<p style="font-size:12px;">
									<b><font color="red">* File NPWP tidak boleh lebih dari 500kb <br> 
														 &nbsp Format penamaan file NPWP: NPWP_NAMA ANDA<br>   
														 &nbsp Format file NPWP berupa .jpg / .jpeg   <br></font></b>	
									</p>
						</div>	
					</div>
				<br><center><input onclick="return confirm('Apakah anda sudah yakin dengan data yang anda isi?');" type="submit" value="Simpan" class="btn btn-primary"></center>	
				</form>	
			</div>
		</div><br><br><br><br><br><br><br><br><br>
<?php } ?>
	</section>
	
	<script type="text/javascript" src="http://code.jquery.com/jquery.min.js"></script>