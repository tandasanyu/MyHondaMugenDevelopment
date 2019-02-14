<title>Form Data Keluarga</title>
	<section id="content" style="background-color:#ffffff;">
		<div class="container">
			<div class="col-sm-12 col-lg-12"><br><br>
				<h1 style="text-align:center;  font-family:Cooper Black;">Form Data Keluarga</h1><br>
				<!-- Slider -->
			</div>
		</div>
<?php if($cekDataKeluarga==True){?>
		<br><br><div class="container">
			<div class="col-sm-12 col-lg-12">
				<h4 style="color:red; text-align:center;">Anda sudah mengisi data keluarga. Isian data keluarga hanya diperbolehkan 1x!</h4>
			</div>
		</div><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
<?php }else{ ?>
	<div class="container">
			<form class="form-horizontal" enctype="multipart/form-data"  id="frm-mhs" method="post" action="<?php echo base_url().'career/simpanDataKeluarga'?>">		
				<div class="col-sm-12 col-lg-12">
					<br><h4>Data Keluarga (termasuk diri anda):</h4><br>
					<div class="table-responsive">
						<table class="table table-striped table-bordered table-hover" id="Keluarga">
							<thead>
								<tr>
									<td></td>
									<td align="center"><b>Nama (<font color="red">*</font>)</b></td>
									<td align="center" class="col-sm-2"><b>Jenis Kelamin (<font color="red">*</font>)</b></td>
									<td align="center"><b>Usia (<font color="red">*</font>)</b></th>
									<td align="center"><b>Pendidikan (<font color="red">*</font>)</b></td>
									<td align="center"><b>Pekerjaan (<font color="red">*</font>)</b></td>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>Ayah</td> 
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="nmAyah" name="nmAyah">
										</div>		
									</td>
									<td>
										<div class="col-sm-12">
											Laki-Laki 
										</div>
									</td>	
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control" id="usiaAyah" name="usiaAyah">
										</div>
									</td>
									<td>
										<div class="col-sm-12">
											<select class="form-control" name="pendidikanAyah">
												<option value="">- Pilih Pendidikan-</option>
												<option value="Tidak Sekolah">Tidak Sekolah</option>
												<option value="SD">SD</option>
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
											<select class="form-control" class="form-control" name="pekerjaanAyah">
												<option value="">- Pilih Pekerjaan-</option>
												<option value="PNS">PNS</option>
												<option value="Swasta">Pegawai Swasta</option>
												<option value="Wirausaha">Wirausaha</option>
												<option value="Pensiunan">Pensiunan</option>
												<option value="Tidak Bekerja">Tidak Bekerja</option>
											</select>	
										</div>
									</td>
								</tr> 
										
								<tr>
									<td>Ibu</td> 
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="nmIbu" name="nmIbu">
										</div>		
									</td>
									<td>
										<div class="col-sm-12">
											Perempuan 
										</div>
									</td>	
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control" id="usiaIbu" name="usiaIbu">
										</div>
									</td>
									<td>
										<div class="col-sm-12">
											<select class="form-control" name="pendidikanIbu">
												<option value="">- Pilih Pendidikan-</option>
												<option value="Tidak Sekolah">Tidak Sekolah</option>
												<option value="SD">SD</option>
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
											<select class="form-control" class="form-control" name="pekerjaanIbu">
												<option value="">- Pilih Pekerjaan-</option>
												<option value="PNS">PNS</option>
												<option value="Swasta">Pegawai Swasta</option>
												<option value="Wirausaha">Wirausaha</option>
												<option value="Pensiunan">Pensiunan</option>
												<option value="Ibu Rumah Tangga">Ibu Rumah Tangga</option>
											</select>	
										</div>
									</td>
								</tr> 
						
								<tr>
									<td>Anak</td> 
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="nmSaudara[]" name="nmSaudara[]">
										</div>		
									</td>
									<td>
										<div class="col-sm-12">
											<select class="form-control" name="jkelSaudara[]">
												<option value="">- Pilih Jenis Kelamin -</option>
												<option value="1">Laki-Laki</option>
												<option value="2">Perempuan</option>
											</select>	 
										</div>
									</td>	
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control"  id="usiaSaudara[]" name="usiaSaudara[]">
										</div>
									</td>
									<td>
										<div class="col-sm-12">
											<select class="form-control" name="pendidikanSaudara[]">
												<option value="">- Pilih Pendidikan-</option>
												<option value="Tidak/Belum Sekolah">Tidak/Belum Sekolah</option>
												<option value="SD">SD</option>
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
											<select class="form-control" class="form-control" name="pekerjaanSaudara[]">
												<option value="">- Pilih Pekerjaan-</option>
												<option value="Mahasiswa">Mahasiswa</option>
												<option value="PNS">PNS</option>
												<option value="Swasta">Pegawai Swasta</option>
												<option value="Pelajar">Pelajar</option>
												<option value="PNS">Tidak Bekerja</option>
												<option value="Wirausaha">Wirausaha</option>
											</select>	
										</div>
									</td>
								</tr> 
							</tbody>
						</table>
						<center><input type="button" value="Tambah Data" class="btn btn-default plusbtn" /></center>				
					</div><br><br>
			
					<div class="form-group">
						<label class="control-label col-sm-2" for="status">Status Perkawinan (<font color="red">*</font>)</label>
						<div class="col-sm-8">
							<input type="radio" name="statusKawin" id="statusKawin" onclick="statusKawin1()" value="1"> Menikah &nbsp &nbsp &nbsp <input type="radio" id="statusKawin" name="statusKawin" onclick="statusKawin2()" value="2"> Belum Menikah &nbsp &nbsp &nbsp <input type="radio"  id="statusKawin" onclick="statusKawin3()" name="statusKawin" value="3"> Duda/Janda
						</div>
					</div><br>
								
					<div class="table-responsive" id="status" style="display:none;">
						<table class="table table-striped table-bordered table-hover" >
							<thead>
								<tr>
									<td></td>
									<td align="center"><b>Nama (<font color="red">*</font>)</b></td>
									<td align="center"><b>Usia (<font color="red">*</font>)</b></th>
									<td align="center"><b>Pendidikan (<font color="red">*</font>)</b></td>
									<td align="center"><b>Pekerjaan (<font color="red">*</font>)</b></td>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>Suami/Istri</td> 
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="nmPasangan" name="nmPasangan">
										</div>		
									</td>
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control" id="usiaPasangan" name="usiaPasangan">
										</div>
									</td>
									<td>
										<div class="col-sm-12">
											<select class="form-control" name="pendidikanPasangan">
												<option value="">- Pilih Pendidikan-</option>
												<option value="Tidak Sekolah">Tidak Sekolah</option>
												<option value="SD">SD</option>
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
											<select class="form-control" class="form-control" name="pekerjaanPasangan">
												<option value="">- Pilih Pekerjaan-</option>
												<option value="Mahasiswa">Mahasiswa</option>
												<option value="PNS">PNS</option>
												<option value="Swasta">Pegawai Swasta</option>
												<option value="Pelajar">Pelajar</option>
												<option value="PNS">Tidak Bekerja</option>
												<option value="Wirausaha">Wirausaha</option>
												<option value="Ibu Rumah Tangga">Ibu Rumah Tangga</option>
											</select>	
										</div>
									</td>
								</tr> 
							</tbody>	
						</table><br>
					</div>	
				
					<div class="form-group" id="tanyaAnak" style="display:none;">
						<label class="control-label col-sm-2" for="status">Punya Anak:</label>
						<div class="col-sm-8">
							<input type="radio" name="anak" id="anak" onclick="anak1()" value="1"> Punya &nbsp &nbsp &nbsp <input type="radio" id="anak" name="anak" onclick="anak2()" value="2"> Tidak Punya				
						</div>
					</div><br>
			
					<div class="table-responsive" id="punyaAnak" style="display:none;">
						<table class="table table-striped table-bordered table-hover" id="punyaAnak2">
							<thead>
								<tr>
									<td></td>
									<td align="center"><b>Nama (<font color="red">*</font>)</b></td>
									<td align="center" class="col-sm-2"><b>Jenis Kelamin (<font color="red">*</font>)</b></td>
									<td align="center"><b>Usia (<font color="red">*</font>)</b></th>
									<td align="center"><b>Pendidikan (<font color="red">*</font>)</b></td>
									<td align="center"><b>Pekerjaan (<font color="red">*</font>)</b></td>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>Anak</td> 
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="nmAnak[]" name="nmAnak[]">
										</div>		
									</td>
									<td>
										<div class="col-sm-12">
											<select class="form-control" name="jkelAnak[]">
												<option value="">- Pilih Jenis Kelamin -</option>
												<option value="1">Laki-Laki</option>
												<option value="2">Perempuan</option>
											</select>	  
										</div>
									</td>	
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control" id="usiaAnak[]" name="usiaAnak[]">
										</div>
									</td>
									<td>
										<div class="col-sm-12">
											<select class="form-control" name="pendidikanAnak[]">
												<option value="">- Pilih Pendidikan-</option>
												<option value="Tidak/Belum Sekolah">Tidak/Belum Sekolah</option>
												<option value="SD">SD</option>
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
											<select class="form-control" class="form-control" name="pekerjaanAnak[]">
												<option value="">- Pilih Pekerjaan-</option>
												<option value="Mahasiswa">Mahasiswa</option>
												<option value="PNS">PNS</option>
												<option value="Swasta">Pegawai Swasta</option>
												<option value="Pelajar">Pelajar</option>
												<option value="Tidak Bekerja">Tidak Bekerja</option>
												<option value="Wirausaha">Wirausaha</option>
											</select>	
										</div>
									</td>
								</tr> 
							</tbody>
						</table>	
						<center><input type="button" value="Tambah Data" class="btn btn-default plusbtn2" /></center><br><br>
					</div>
				</div>
				<center><input onclick="return confirm('Pengisian data hanya dilakukan 1x. Apakah anda sudah yakin dengan data yang anda isi?');" type="submit" value="Simpan" class="btn btn-primary"></center>	
			</form>
		</div>	
	<br><br>
	<?php } ?>	
</section>
		
	<script type="text/javascript" src="http://code.jquery.com/jquery.min.js"></script>
	
	<script>

		//Tambah Baris
		$('.plusbtn').click(function() {
			$("#Keluarga").append('<tr><td>Anak</td><td><div class="col-sm-12"><input type="text" class="form-control" id="nmSaudara[]" name="nmSaudara[]"></div></td><td><div class="col-sm-12"><select class="form-control" name="jkelSaudara[]"><option value="">- Pilih Jenis Kelamin -</option><option value="1">Laki-Laki</option><option value="2">Perempuan</option></select></div></td><td><div class="col-sm-12"><input type="text" class="form-control" id="usiaSaudara[]" name="usiaSaudara[]"></div></td><td><div class="col-sm-12"><select class="form-control" name="pendidikanSaudara[]"><option value="">- Pilih Pendidikan-</option><option value="Tidak/Belum Sekolah">Tidak/Belum Sekolah</option><option value="SD">SD</option><option value="SMP">SMP</option><option value="SMA/K">SMA/K</option><option value="S1">S1</option><option value="S2">S2</option><option value="S3">S3</option></select></div></td><td><div class="col-sm-12"><select class="form-control" class="form-control" name="pekerjaanSaudara[]"><option value="">- Pilih Pekerjaan-</option><option value="Mahasiswa">Mahasiswa</option><option value="PNS">PNS</option><option value="Swasta">Pegawai Swasta</option><option value="Pelajar">Pelajar</option><option value="PNS">Tidak Bekerja</option><option value="Wirausaha">Wirausaha</option></select></div></td><td><input id="button1" type="button" class="btn btn-danger btnDelete" value="Hapus" /></td></tr> ');
		});
	
		//Hapus Baris
		$(document).ready(function(){
			$("#Keluarga").on('click','.btnDelete',function(){
				$(this).closest('tr').remove();
			});
		});

		function statusKawin1() {
			document.getElementById('status').style.display = 'block';	
			document.getElementById('tanyaAnak').style.display = 'block';
		}
	
		function statusKawin2() {
			document.getElementById('status').style.display ='none';
			document.getElementById('tanyaAnak').style.display = 'none';
		}
	
		function statusKawin3() {
			document.getElementById('status').style.display = 'block';	
			document.getElementById('tanyaAnak').style.display = 'block';	
		}
      
		function anak1() {
			document.getElementById('punyaAnak').style.display = 'block';	
		}
	
		function anak2() {
			document.getElementById('punyaAnak').style.display ='none';
		}
	
		//Tambah Baris
		$('.plusbtn2').click(function() {
			$("#punyaAnak2").append('<tr><td>Anak</td><td><div class="col-sm-12"><input type="text" class="form-control" id="nmAnak[]" name="nmAnak[]"></div></td><td><div class="col-sm-12"><select class="form-control" name="jkelAnak[]"><option value="">- Pilih Jenis Kelamin -</option><option value="1">Laki-Laki</option><option value="2">Perempuan</option></select></div></td><td><div class="col-sm-12"><input type="text" class="form-control" id="usiaAnak[]" name="usiaAnak[]"></div></td><td><div class="col-sm-12"><select class="form-control required" name="pendidikanAnak[]"><option value="">- Pilih Pendidikan-</option><option value="Tidak/Belum Sekolah">Tidak/Belum Sekolah</option><option value="SD">SD</option><option value="SMP">SMP</option><option value="SMA/K">SMA/K</option><option value="S1">S1</option><option value="S2">S2</option><option value="S3">S3</option></select></div></td><td><div class="col-sm-12"><select class="form-control" class="form-control" name="pekerjaanAnak[]"><option value="">- Pilih Pekerjaan-</option><option value="Mahasiswa">Mahasiswa</option><option value="PNS">PNS</option><option value="Swasta">Pegawai Swasta</option><option value="Pelajar">Pelajar</option><option value="Tidak Bekerja">Tidak Bekerja</option><option value="Wirausaha">Wirausaha</option></select></div></td><td><input id="button1" type="button" class="btn btn-danger btnDelete2" value="Hapus" /></td></tr> ');
		});
	
		//Hapus Baris
		$(document).ready(function(){
			$("#punyaAnak2").on('click','.btnDelete2',function(){
				$(this).closest('tr').remove();
			});
		});
	</script>	