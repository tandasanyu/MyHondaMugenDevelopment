<title>Form Riwayat Pendidikan</title>
	<section id="content" style="background-color:#ffffff;">
		<div class="container">
			<div class="col-sm-12 col-lg-12"><br><br>
				<h1 style="text-align:center;  font-family:Cooper Black;">Form Riwayat Pendidikan</h1><br><br>
				<!-- Slider -->
			</div>
		</div><br>
<?php if($cekDataPendidikan==True){?>
		<div class="container">
			<div class="col-sm-12 col-lg-12">
				<h4 style="color:red; text-align:center;">Anda sudah mengisi data pendidikan. Isian data pendidikan hanya diperbolehkan 1x!</h4>
			</div>
		</div><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
<?php }else{ ?>
			<div class="container">
			<form class="form-horizontal" enctype="multipart/form-data"  id="frm-mhs" method="post" action="<?php echo base_url().'career/simpanDataPendidikan'?>">		
			<div class="col-sm-12 col-lg-12">
				<div class="tab-content">
					<h4>Pendidikan Formal (urutkan dari pendidikan paling terakhir):</h4><br>
					<div class="table-responsive">
						<table class="table table-striped table-bordered table-hover" id="pendidikanFormal">
							<thead>
								<tr>
									<td align="center" rowspan="2"><b>Jenjang</b> (<font color="red">*</font>)</td>
									<td align="center" rowspan="2"><b>Nama Instansi</b> (<font color="red">*</font>)</td>
									<td align="center" rowspan="2"><b>Kota</b> (<font color="red">*</font>)</th>
									<td align="center" colspan="2"><b>Tahun</b></td>
									<td align="center" class="col-md-2" rowspan="2"><b>Lulus/Tidak</b> (<font color="red">*</font>)</td>
									<td align="center" rowspan="2"><b>Jurusan</b></td>
								</tr>
								<tr>
									<td align="center"><b>Masuk (<font color="red">*</font>)</b></td>
									<td align="center"><b>Keluar (<font color="red">*</font>)</b></td>
								</tr>	
							</thead>
							<tbody>
								<tr>
									<td>
										<div class="col-sm-12">
											<select class="form-control required" name="jenjangPendidikan[]">
												<option value="">- Pilih Jenjang-</option>
												<option value="SMP">SMP</option>
												<option value="SMA/K">SMA/K</option>
												<option value="S1">S1</option>
												<option value="S2">S2</option>
												<option value="S3">S3</option>
												</select>	
										</div>
									</td>
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="nmInstansi[]" name="nmInstansi[]">
										</div>		
										</td>	
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="kotaInstansi[]" name="kotaInstansi[]">
										</div>		
									</td>	
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="thnMasuk[]" name="thnMasuk[]">
										</div>
									</td>
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="thnKeluar[]" name="thnKeluar[]">
										</div>
									</td>
									<td>
										<div class="col-sm-12">
											<select class="form-control" name="kelulusan[]">
												<option value="">- Pilih Kelulusan -</option>
												<option value="1">Lulus</option>
												<option value="2">Tidak Lulus</option>
											</select>	  
										</div>
									</td>	
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control" id="jurusan[]" name="jurusan[]">
										</div>
									</td>
								</tr> 	
							</tbody>
						</table>
						<center><input type="button" value="Tambah Data" class="btn btn-default plusbtn" /></center>
					</div>
							
					<br>				
					<h4>Pendidikan Non Formal (kursus/seminar):</h4><br>
					<div class="col-sm-8">
						<input type="radio" name="nonFormal" id="nonFormal" onclick="nonFormal1()" value="1"> Ada &nbsp &nbsp &nbsp <input type="radio" id="nonFormal" name="nonFormal" onclick="nonFormal2()" value="2"> Tidak Ada 
					</div><br>					
					<div class="table-responsive col-sm-12" id="pendidikanNon" style="display:none;">
						<br><table class="table table-striped table-bordered table-hover" id="pendidikanNonFormal">
							<thead>
								<tr>
									<td align="center"><b>Nama Instansi (<font color="red">*</font>)</b></td>
									<td align="center"><b>Tahun (<font color="red">*</font>)</b></td>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="nmInstansiNon[]" name="nmInstansiNon[]">
										</div>		
									</td>
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="tahunNon[]" name="tahunNon[]">
										</div>
									</td>	
								</tr> 
							</tbody>
						</table>
						<center><input type="button" value="Tambah Data" class="btn btn-default plusbtn2" /></center><br>
					</div>
				
					<br><br>				
					<h4>Bahasa Asing Yang Dikuasai:</h4><br>
					<div class="col-sm-8">
						<input type="radio" name="bahasa" id="bahasa" onclick="bahasa1()" value="1"> Ada &nbsp &nbsp &nbsp <input type="radio" id="bahasa" name="bahasa" onclick="bahasa2()" value="2"> Tidak Ada 
					</div><br>					
					<div class="table-responsive col-sm-12" id="penguasaanBahasa" align="left" style="display:none;">
						<br><table class="table table-striped table-bordered table-hover" id="skillBahasa">
							<thead>
								<tr>
									<td align="center"><b>Jenis Bahasa (<font color="red">*</font>)</b></td>
									<td align="center"><b>Tingkat Penguasaan (<font color="red">*</font>)</b></td>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="jnsBahasa[]" name="jnsBahasa[]">
										</div>		
									</td>
									<td>
										<div class="col-sm-12">
											<select class="form-control" name="penguasaan[]">
												<option value="">- Pilih Penguasaan -</option>
												<option value="1">Baik</option>
												<option value="2">Cukup</option>
												<option value="2">Kurang</option>
											</select>	
										</div>
									</td>	
								</tr> 
							</tbody>
						</table>
						<center><input type="button" value="Tambah Data" class="btn btn-default plusbtn3" /></center><br><br>
					</div>
					<br><br><center><input onclick="return confirm('Pengisian data hanya dilakukan 1x. Apakah anda sudah yakin dengan data yang anda isi?');" type="submit" value="Simpan" class="btn btn-primary"></center>	
				</div><br><br>
			</form>
		</div><br>
<?php } ?>	
	</section>
	
	
	<script type="text/javascript" src="http://code.jquery.com/jquery.min.js"></script>
	
	<script>
	//Pendidikan Formal

		//Tambah Baris
		$('.plusbtn').click(function() {
			$("#pendidikanFormal").append('<tr><td><div class="col-sm-12"><select class="form-control required" name="jenjangPendidikan[]"><option value="">- Pilih Jenjang-</option><option value="SMP">SMP</option><option value="SMA/K">SMA/K</option><option value="S1">S1</option><option value="S2">S2</option><option value="S3">S3</option></select></div></td><td><div class="col-sm-12"><input type="text" class="form-control required" id="nmInstansi[]" name="nmInstansi[]"></div></td><td><div class="col-sm-12"><input type="text" class="form-control required" id="kotaInstansi[]" name="kotaInstansi[]"></div></td><td><div class="col-sm-12"><input type="text" class="form-control required" id="thnMasuk[]" name="thnMasuk[]"></div></td><td><div class="col-sm-12"><input type="text" class="form-control required" id="thnKeluar[]" name="thnKeluar[]"></div></td><td><div class="col-sm-12"><select class="form-control" name="kelulusan[]"><option value="">- Pilih Kelulusan -</option><option value="1">Lulus</option><option value="2">Tidak Lulus</option></select></div></td><td><div class="col-sm-12"><input type="text" class="form-control" id="jurusan[]" name="jurusan[]"></div></td><td><input id="button1" type="button" class="btn btn-danger btnDelete" value="Hapus" /></td></tr>');
		});
		
		//Hapus Baris
		$(document).ready(function(){
			$("#pendidikanFormal").on('click','.btnDelete',function(){
				$(this).closest('tr').remove();
			});
		});

	//Pendidikan Non Formal

		//Ada & Tidak Ada
		function nonFormal1() {
			document.getElementById('pendidikanNon').style.display = 'block';	
		}
		
		function nonFormal2() {
			document.getElementById('pendidikanNon').style.display ='none';
		}
		
		//Tambah Baris
		$('.plusbtn2').click(function() {
			$("#pendidikanNonFormal").append('<tr><td><div class="col-sm-12"><input type="text" class="form-control" id="nmInstansiNon[] name="nmInstansiNon[]"></div></td><td><div class="col-sm-12"><input type="text" class="form-control" id="tahunNon[]" name="tahunNon[]"></div></td><td><input id="button1" type="button" class="btn btn-danger btnDelete2" value="Hapus" /></td></tr>');
		});
		
		//Hapus Baris
		$(document).ready(function(){
			$("#pendidikanNonFormal").on('click','.btnDelete2',function(){
				$(this).closest('tr').remove();
			});
		});

	//Kemampuan Bahasa
	
		//Ada & Tidak Ada	
		function bahasa1() {
			document.getElementById('penguasaanBahasa').style.display = 'block';	
		}
	
		function bahasa2() {
			document.getElementById('penguasaanBahasa').style.display ='none';
		}
		
		//Tambah Baris
		$('.plusbtn3').click(function() {
			$("#skillBahasa").append('<tr><td><div class="col-sm-12"><input type="text" class="form-control" id="jnsBahasa[]" name="jnsBahasa[]"></div></td><td><div class="col-sm-12"><select class="form-control" name="penguasaan[]"><option value="">- Pilih Penguasaan -</option><option value="1">Baik</option><option value="2">Cukup</option><option value="2">Kurang</option></select></div></td><td><input id="button1" type="button" class="btn btn-danger btnDelete3" value="Hapus" /></td></tr>');
		});
	
		//Hapus Baris
		$(document).ready(function(){
			$("#skillBahasa").on('click','.btnDelete3',function(){
				$(this).closest('tr').remove();
			});
		});

	</script>