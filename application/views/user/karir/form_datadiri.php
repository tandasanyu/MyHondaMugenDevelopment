	<title>Form Data Diri</title>
	<section id="content" style="background-color:#ffffff;">
		<div class="container">
			<div class="col-sm-12 col-lg-12"><br><br>
				<h1 style="text-align:center;  font-family:Cooper Black;">Form Data Diri</h1><br><br><br>
				<!-- Slider -->
			</div>
		</div><br>
<?php if($cekDataDiri==True){?>
		<div class="container">
			<div class="col-sm-12 col-lg-12">
				<h4 style="color:red; text-align:center;">Anda sudah mengisi data diri. Isian data diri hanya diperbolehkan 1x!</h4>
			</div>
		</div><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
<?php }else{ ?>
		<div class="container">
			<div class="col-sm-12 col-lg-12">
				<form class="form-horizontal" id="frm-mhs" method="post" action="<?php echo base_url().'career/simpanDataDiri'?>">		
					<div class="row">
						<div class="col-lg-6">
							<div class="form-group">
								<label class="control-label col-sm-4" for="nama">Nama Lengkap (<font color="red">*</font>)</label>
								<div class="col-sm-8">
									<input type="text" class="form-control required" id="nama" name="nama">
								</div>
							</div>
									
							<div class="form-group">
								<label class="control-label col-sm-4" for="tempatLahir">Tempat Lahir (<font color="red">*</font>)</label>
								<div class="col-sm-8">
									<input type="text" class="form-control required" id="tempatLahir" name="tempatLahir">
								</div>
							</div>
					
							<div class="form-group">
								<label class="control-label col-sm-4" for="jkel">Jenis Kelamin (<font color="red">*</font>)</label>
								<div class="col-sm-8">
									<input type="radio" name="jkel" value="1"> Pria &nbsp &nbsp &nbsp <input type="radio" name="jkel" value="2"> Wanita 
								</div>
							</div><br>
					
							<div class="form-group">
								<label class="control-label col-sm-4" for="alamatKtp">Alamat Sesuai KTP (<font color="red">*</font>)</label>
								<div class="col-sm-8">
									<textarea class="form-control required" id="alamatKtp" name="alamatKtp" rows="5"></textarea>
								</div>	
							</div>
					
							<div class="form-group">
								<label class="control-label col-sm-4" for="telp">Telepon Rumah</label>
								<div class="col-sm-8">
									<input type="text" class="form-control" id="telp" name="telp">
								</div>
							</div>
					
							<div class="form-group">
								<label class="control-label col-sm-4" for="hobi">Hobi</label>
								<div class="col-sm-8">
									<input type="text" class="form-control" id="hobi" name="hobi">
								</div>
							</div>
					
							<div class="form-group">
								<label class="control-label col-sm-4" for="ktp">No. KTP (<font color="red">*</font>)</label>
								<div class="col-sm-8">
									<input type="text" class="form-control required" id="ktp" name="ktp">
								</div>
							</div>
					
							<div class="form-group">
								<label class="control-label col-sm-4" for="jnsSim">Jenis SIM (<font color="red">*</font>)</label>
								<div class="col-sm-8">
									<input type="radio" name="jnsSim" onclick="jnsSim1()" value="1"> SIM A &nbsp &nbsp &nbsp <input type="radio" onclick="jnsSim2()" name="jnsSim" value="2"> SIM C &nbsp &nbsp &nbsp <input type="radio" onclick="jnsSim3()" name="jnsSim" value="3"> Tidak Punya 
								</div>
							</div>
							
							<div class="form-group">
								<label class="control-label col-sm-4" for="sim">No. SIM</label>
								<div class="col-sm-8">
									<input type="text" class="form-control" id="sim" name="sim" disabled="disabled">
								</div>
							</div>	
						</div>
				
						<div class="col-lg-6">	
							<div class="form-group">
								<label class="control-label col-sm-4" for="panggilan">Nama Panggilan (<font color="red">*</font>)</label>
								<div class="col-sm-8">
									<input type="text" class="form-control required" id="panggilan" name="panggilan">
								</div>
							</div>
										
							<div class="form-group">
								<label class="control-label col-sm-4" for="tglLahir">Tanggal Lahir (<font color="red">*</font>)</label>
								<div class="col-sm-8">
									<div class="input-group">
										<input type="text" class="form-control required" id="datepicker" name="tglLahir" placeholder="dd-mm-yyyy" readonly="readonly">
										<div class="input-group-addon">
											<i class="fa fa-calendar"></i>
										</div>
									</div>
								</div>
							</div>
									
							<div class="form-group">
								<label class="control-label col-sm-4" for="agama">Agama (<font color="red">*</font>)</label>
								<div class="col-sm-8">
									<input type="radio" name="agama" value="1"> Islam &nbsp &nbsp &nbsp
									<input type="radio" name="agama" value="2"> Kristen &nbsp &nbsp &nbsp
									<input type="radio" name="agama" value="3"> Katolik &nbsp &nbsp &nbsp 
									<input type="radio" name="agama" value="4"> Hindu &nbsp &nbsp &nbsp &nbsp &nbsp  
									<input type="radio" name="agama" value="5"> Budha &nbsp &nbsp
									<input type="radio" name="agama" value="6"> Konghucu
								</div>
							</div>
									
							<div class="form-group">
								<label class="control-label col-sm-4" for="alamat">Alamat Tinggal (<font color="red">*</font>)</label>
								&nbsp &nbsp <input type="radio" name="tinggal" onclick="tinggal1()" value="1"> Sesuai KTP &nbsp &nbsp <input type="radio" name="tinggal"  onclick="tinggal2()" value="2"> Berbeda Dengan KTP
								<div class="col-sm-8">
									<textarea class="form-control required" style="display:none;" id="alamatTinggal" name="alamatTinggal" rows="5"></textarea>
								</div>	
							</div>
									
							<div class="form-group">
								<label class="control-label col-sm-4" for="hp">Handphone (<font color="red">*</font>)</label>
								<div class="col-sm-8">
									<input type="text" class="form-control required" id="hp" name="hp">
								</div>
							</div>
									
							<div class="form-group">
								<label class="control-label col-sm-4" for="email">Email (<font color="red">*</font>)</label>
								<div class="col-sm-8">
									<input type="text" class="form-control required" id="email" name="email">
								</div>
							</div>
									
							<div class="form-group">
								<label class="control-label col-sm-4" for="npwp">NPWP</label>
								<div class="col-sm-8">
									<input type="text" class="form-control" id="npwp" name="npwp">
								</div>
							</div>
									
							<div class="form-group">
								<label class="control-label col-sm-4" for="jamsostek">No. Jamsostek</label>
								<div class="col-sm-8">
									<input type="text" class="form-control" id="jamsostek" name="jamsostek">
								</div>
							</div>
									
							<div class="form-group">
								<label class="control-label col-sm-4" for="bca">No Rek. BCA</label>
								<div class="col-sm-8">
									<input type="text" class="form-control" id="bca" name="bca">
								</div>
							</div>
						</div>	
					</div><br>
					<center><input onclick="return confirm('Apakah anda sudah yakin dengan data yang anda isi?');" type="submit" value="Simpan" class="btn btn-primary"></center>
				</form>
			</div>
		</div><br>
<?php } ?>
	</section>
	
	
	<script type="text/javascript" src="http://code.jquery.com/jquery.min.js"></script>
	<script>
	
		function jnsSim1() {
			document.getElementById('sim').disabled = false;	
		}
		
		function jnsSim2() {
			document.getElementById('sim').disabled = false;	
		}
		
		function jnsSim3() {
			document.getElementById('sim').disabled = true;	
			document.getElementById('sim').value="";	
		}
		
		function tinggal1() {
			document.getElementById('alamatTinggal').style.display = 'block';	
			document.getElementById('alamatTinggal').value=document.getElementById('alamatKtp').value;
			document.getElementById('alamatTinggal').readOnly = true;
		}
	
		function tinggal2() {
			document.getElementById('alamatTinggal').style.display ='block';
			document.getElementById('alamatTinggal').value="";
			document.getElementById('alamatTinggal').readOnly = false;
		}
	</script>