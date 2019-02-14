<title>Form Pertanyaan</title>
	<section id="content" style="background-color:#ffffff;">
		<div class="container">
			<div class="col-sm-12 col-lg-12"><br><br>
				<h1 style="text-align:center;  font-family:Cooper Black;">Form Pertanyaan</h1>
				<!-- Slider -->
			</div>
		</div><br><br>
<?php if($cekDataPertanyaan==True){?>
		<br><div class="container">
			<div class="col-sm-12 col-lg-12">
				<h4 style="color:red; text-align:center;">Anda sudah mengisi data pertanyaan. Isian data pertanyaan hanya diperbolehkan 1x!</h4>
			</div>
		</div><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
<?php }else{ ?>
		<div class="container">
			<div class="col-sm-12 col-lg-12">
				<form class="form-horizontal" enctype="multipart/form-data"  id="frm-mhs" method="post" action="<?php echo base_url().'career/simpanDataPertanyaan'?>">		
					<div class="tab-content">	
						<br>	
						<div class="form-group">
							<label for="sakit">&nbsp &nbsp 1. Apakah anda pernah sakit yang membutuhkan perawatan di rumah sakit? (<font color="red">*</font>)</label><br>
							<br> &nbsp &nbsp <input type="radio" name="sakit" onclick="descSakit1()" value="1"> Ya &nbsp &nbsp <input type="radio" name="sakit"  onclick="descSakit2()" value="2"> Tidak
							<br><textarea id="descSakit" style="display:none;" name="descSakit" class="form-control required" rows="5"></textarea>	
						</div>
			
						<br>
						<div class="form-group">
							<label for="kelebihan">&nbsp &nbsp 2. Sebutkan kelebihan diri anda! (<font color="red">*</font>)</label>
							<textarea name="kelebihan" class="form-control required" rows="5"></textarea>
						</div>
			
						<br>
						<div class="form-group">
							<label for="kekurangan">&nbsp &nbsp 3. Sebutkan kekurangan diri anda! (<font color="red">*</font>)</label>
							<textarea name="kekurangan" class="form-control required" rows="5"></textarea>
						</div>
			
						<br>
						<div class="form-group">
							<label for="keahlian">&nbsp &nbsp 4. Keahlian apa saja yang anda miliki? (<font color="red">*</font>)</label>
							<textarea name="keahlian" class="form-control required" rows="5"></textarea>	
						</div>
			
						<br>
						<div class="form-group">
							<label for="jobDesc">&nbsp &nbsp 5. Apa yang anda ketahui mengenai "Job Description"	dari pekerjaan yang anda lamar ini? (<font color="red">*</font>)</label>
							<textarea name="jobDesc" class="form-control required" rows="5"></textarea>
						</div>
			
						<br>
						<div class="form-group">
							<label for="harapanGaji">&nbsp &nbsp 6. Berapa gaji yang anda harapkan?	(<font color="red">*</font>)</label>
							<textarea name="harapanGaji" class="form-control required" rows="5"></textarea>	
						</div>
			
						<br>
						<div class="form-group">
							<label for="tunjangan">&nbsp &nbsp 7. Sebutkan tunjangan/fasilitas yang anda inginkan! (<font color="red">*</font>)</label>
							<textarea name="tunjangan" class="form-control required" rows="5"></textarea>	
						</div>
			
						<br>
						<div class="form-group">
							<label for="mulaiKerja">&nbsp &nbsp 8. Bila anda diterima, kapan anda siap bekerja di Honda Mugen? (<font color="red">*</font>)</label>
							<textarea name="mulaiKerja" class="form-control required" rows="5"></textarea>	
						</div>
			
						<br>
						<div class="form-group">
							<label for="penempatan">&nbsp &nbsp 9. Apakah anda bersedia ditempatkan dimana saja sesuai dengan kebutuhan perusahaan? (<font color="red">*</font>)</label>
							&nbsp &nbsp <input type="radio" name="penempatan" value="1"> Ya &nbsp &nbsp <input type="radio" name="penempatan" value="2"> Tidak
						</div>
			
						<br>
						<div class="form-group">
							<label for="alasanGabung">&nbsp &nbsp 10. Mengapa anda ingin bergabung dengan Honda Mugen? (<font color="red">*</font>)</label> 
							<textarea name="alasanGabung" class="form-control required" rows="5"></textarea>	
						</div>
			
						<br>
						<div class="form-group">
							<label for="tentangMugen">&nbsp &nbsp 11. Apa yang anda ketahui tentang Honda Mugen? (<font color="red">*</font>)</label>  
							<textarea name="tentangMugen" class="form-control required" rows="5"></textarea>	
						</div>
			
						<br>
						<div class="form-group">
							<label for="lingkunganKerja">&nbsp &nbsp 12. Anda senang bekerja pada lingkungan (<font color="red">*</font>)</label>
							&nbsp &nbsp <input type="radio" name="lingkunganKerja" value="1"> di dalam kantor &nbsp &nbsp <input type="radio" name="lingkunganKerja" value="2"> di luar kantor	&nbsp &nbsp <input type="radio" name="lingkunganKerja" value="3"> di dalam bengkel &nbsp &nbsp <input type="radio" name="lingkunganKerja" value="4"> lainnya		
						</div>
					</div>
					<br><br><center><input onclick="return confirm('Apakah anda sudah yakin dengan data yang anda isi?');" type="submit" value="Simpan" class="btn btn-primary"></center>	
				</form>
			</div>
		</div><br><br>
<?php } ?>
	</section>
	
	
	<script type="text/javascript" src="http://code.jquery.com/jquery.min.js"></script>
	
	<script>

	function descSakit1() {
		document.getElementById('descSakit').style.display = 'block';	
	}
	
	function descSakit2() {
		document.getElementById('descSakit').style.display ='none';
	}

	</script>	