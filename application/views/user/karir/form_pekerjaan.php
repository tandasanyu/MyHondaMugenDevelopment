<title>Form Riwayat Pekerjaan</title>
	<section id="content" style="background-color:#ffffff;">
		<div class="container">
			<div class="col-sm-12 col-lg-12"><br><br>
				<h1 style="text-align:center;  font-family:Cooper Black;">Form Riwayat Pekerjaan & Referensi</h1>	
			</div>
			
		</div><br><br>
<?php if($cekDataPekerjaan==True || $cekDataReferensi==True ){?>
		<br><div class="container">
			<div class="col-sm-12 col-lg-12">
				<h4 style="color:red; text-align:center;">Anda sudah mengisi data riwayat pekerjaan & referensi. Isian data pekerjaan & referensi hanya diperbolehkan 1x!</h4>
			</div>
		</div><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
<?php }else{ ?>
		<div class="container">
			<form class="form-horizontal" enctype="multipart/form-data"  id="frm-mhs" method="post" action="<?php echo base_url().'career/simpanDataPekerjaan'?>">	
				<div class="col-sm-12 col-lg-12">	
					<h4>Detail Riwayat Pekerjaan:</h4><br>
						<div class="col-sm-8">
							<input type="radio" name="riwayat" id="riwayat" onclick="riwayat1()" value="1"> Ada &nbsp &nbsp &nbsp <input type="radio" id="riwayat" name="riwayat" onclick="riwayat2()" value="2"> Tidak Ada 
						</div>	<br><br><br>
					<div id="kerja" style="display:none;">
						<div id="exercises">
							<div class="exercise">
								<div class="row">
									<div class="col-lg-6">
										<div class="form-group">
											<label class="control-label col-sm-4" for="nmPerusahaan">Nama Perusahaan (<font color="red">*</font>)</label>
											<div class="col-sm-8">
												<input type="text" class="form-control required" id="nmPerusahaan[]" name="nmPerusahaan[]">
											</div>
										</div>
												
										<div class="form-group">
											<label class="control-label col-sm-4" for="alamatPerusahaan">Alamat Perusahaan (<font color="red">*</font>)</label>
											<div class="col-sm-8">
												<textarea class="form-control required" id="alamatPerusahaan[]" name="alamatPerusahaan[]" rows="5"></textarea>
											</div>	
										</div>
												
										<div class="form-group">
											<label class="control-label col-sm-4" for="telpPerusahaan">Telepon </label>
											<div class="col-sm-8">
												<input type="text" class="form-control" id="telpPerusahaan[]" name="telpPerusahaan[]">
											</div>
										</div>
												
										<div class="form-group">
											<label class="control-label col-sm-4" for="jabatan">Jabatan (<font color="red">*</font>)</label>
											<div class="col-sm-8">
												<input type="text" class="form-control required" id="jabatan[]" name="jabatan[]">
											</div>
										</div>
												
										<div class="form-group">
											<label class="control-label col-sm-4" for="nmAtasan">Nama Atasan (<font color="red">*</font>)</label>
											<div class="col-sm-8">
												<input type="text" name="nmAtasan[]"  class="form-control require" id="nmatasan[]"> 
											</div>
										</div>
												
										<div class="form-group">
											<label class="control-label col-sm-4" for="tugas">Tugas-Tugas (<font color="red">*</font>)</label>
											<div class="col-sm-8">
												<input type="text" class="form-control required" id="tugas[]" name="tugas[]">
											</div>
										</div>
									</div>
											
									<div class="col-lg-6">	
										<div class="form-group">
											<label class="control-label col-sm-4" for="wMasuk">Waktu Masuk (<font color="red">*</font>)</label>
											<div class="col-sm-8">
												<input type="text" name="wMasuk[]" placeholder="mm-yyyy" class="form-control required" id="wMasuk[]">  
											</div>
										</div>
												
										<div class="form-group">
											<label class="control-label col-sm-4" for="wKeluar">Waktu Keluar (<font color="red">*</font>)</label>
											<div class="col-sm-8">
												<input type="text" class="form-control required" placeholder="mm-yyyy" id="wKeluar[]" name="wKeluar[]">
											</div>	
										</div>
												
										<div class="form-group">
											<label class="control-label col-sm-4" for="gAwal">Gaji Awal (<font color="red">*</font>)</label>
											<div class="col-sm-8">
												<input type="text" class="form-control required" id="gAwal[]" name="gAwal[]">
											</div>
										</div>
										
										<div class="form-group">
											<label class="control-label col-sm-4" for="gAkhir">Gaji Akhir (<font color="red">*</font>)</label>
											<div class="col-sm-8">
												<input type="text" class="form-control required" id="gAkhir[]" name="gAkhir[]">
											</div>
										</div>
												
										<div class="form-group">
											<label class="control-label col-sm-4" for="alasanKeluar">Alasan Keluar (<font color="red">*</font>)</label>
											<div class="col-sm-8">
												<textarea class="form-control required" id="alasanKeluar[]" name="alasanKeluar[]" rows="5"></textarea>
											</div>
										</div>
									</div>	
								</div>	
							</div>
						</div>   
						<center><button id="add_exercise" class="btn btn-default">Tambah Data</button></center><br>
					</div><br>	
					
					<h4>Referensi (Seseorang yang dapat memberikan keterangan tentang anda):</h4><br>
					<div class="table-responsive">
						<table class="table table-striped table-bordered table-hover" id="referensiKeluarga">
							<thead>
								<tr>
									<td align="center" rowspan="2"><b>Nama</b> (<font color="red">*</font>)</td>
									<td align="center" rowspan="2"><b>Alamat</b> (<font color="red">*</font>)</td>
									<td align="center" rowspan="2"><b>No. Telp</b> (<font color="red">*</font>)</th>
									<td align="center" rowspan="2"><b>Pekerjaan</b> (<font color="red">*</font>)</td>
									<td align="center" rowspan="2"><b>Hubungan</b> (<font color="red">*</font>)</td>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="nmReferensi[]" name="nmReferensi[]">
										</div>		
									</td>	
									<td>
										<div class="col-sm-12">
											<textarea class="form-control required" id="alamatReferensi[]" name="alamatReferensi[]"></textarea>
										</div>		
									</td>	
									<td>
										<div class="col-sm-12">
										<input type="text" class="form-control required" id="telpReferensi[]" name="telpReferensi[]">
									</div>		
									</td>
									<td>
										<div class="col-sm-12">
											<select class="form-control required" id="pekerjaanReferensi[]" name="pekerjaanReferensi[]">
												<option value="">- Pilih Pekerjaan-</option>
												<option value="PNS">PNS</option>
												<option value="Swasta">Pegawai Swasta</option>
												<option value="Wirausaha">Wirausaha</option>
												<option value="Pensiunan">Pensiunan</option>
												<option value="Ibu Rumah Tangga">Ibu Rumah Tangga</option>
											</select>	
										</div>
									</td>
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="hubunganReferensi[]" name="hubunganReferensi[]">
										</div>		
									</td>	
								</tr> 	
							</tbody>
						</table>
						<center><input type="button" value="Tambah Data" class="btn btn-default referensi" /></center><br><br>
					</div>
				</div>
				<center><input onclick="return confirm('Apakah anda sudah yakin dengan data yang anda isi?');" type="submit" value="Simpan" class="btn btn-primary"></center>	
			</form>
		</div><br>
<?php } ?>
	</section>
	
	
	<script type="text/javascript" src="http://code.jquery.com/jquery.min.js"></script>
	
	<script>
	
	//Pengalaman Kerja
	
		//Ada & Tidak Ada
		function riwayat1() {
			document.getElementById('kerja').style.display = 'block';	
		}
		
		function riwayat2() {
			document.getElementById('kerja').style.display ='none';
		}
		
		$('#add_exercise').on('click', function() { 
			$('#exercises').append('<div class="exercise"><div class="row"><br><h4>&nbsp &nbsp <u>Detail Riwayat Pekerjaan:</u></h4><br><div class="col-lg-6"><div class="form-group"><label class="control-label col-sm-4" for="nmPerusahaan">Nama Perusahaan (<font color="red">*</font>)</label><div class="col-sm-8"><input type="text" class="form-control required" id="nmPerusahaan[]" name="nmPerusahaan[]"></div></div><div class="form-group"><label class="control-label col-sm-4" for="alamatPerusahaan">Alamat Perusahaan (<font color="red">*</font>)</label><div class="col-sm-8"><textarea class="form-control required" id="alamatPerusahaan[]" name="alamatPerusahaan[]" rows="5"></textarea></div></div><div class="form-group"><label class="control-label col-sm-4" for="telpPerusahaan">Telepon</label><div class="col-sm-8"><input type="text" class="form-control" id="telpPerusahaan[]" name="telpPerusahaan[]"></div></div><div class="form-group"><label class="control-label col-sm-4" for="jabatan">Jabatan (<font color="red">*</font>)</label><div class="col-sm-8"><input type="text" class="form-control required" id="jabatan[]" name="jabatan[]"></div></div><div class="form-group"><label class="control-label col-sm-4" for="nmAtasan">Nama Atasan (<font color="red">*</font>)</label><div class="col-sm-8"><input type="text" name="nmAtasan[]"  class="form-control required" id="nmatasan[]"> </div></div><div class="form-group"><label class="control-label col-sm-4" for="tugas">Tugas-Tugas (<font color="red">*</font>)</label><div class="col-sm-8"><input type="text" class="form-control required" id="tugas[]" name="tugas[]"></div></div></div><div class="col-lg-6"><div class="form-group"><label class="control-label col-sm-4" for="wMasuk">Waktu Masuk (<font color="red">*</font>)</label><div class="col-sm-8"><input type="text" name="wMasuk[]" placeholder="mm-yyyy" class="form-control required" id="wMasuk[]"></div></div><div class="form-group"><label class="control-label col-sm-4" for="wKeluar">Waktu Keluar (<font color="red">*</font>)</label><div class="col-sm-8"><input type="text" class="form-control required" placeholder="mm-yyyy" id="wKeluar[]" name="wKeluar[]"></div></div><div class="form-group"><label class="control-label col-sm-4" for="gAwal">Gaji Awal (<font color="red">*</font>)</label><div class="col-sm-8"><input type="text" class="form-control required" id="gAwal[]" name="gAwal[]"></div></div><div class="form-group"><label class="control-label col-sm-4" for="gAkhir">Gaji Akhir (<font color="red">*</font>)</label><div class="col-sm-8"><input type="text" class="form-control required" id="gAkhir[]" name="gAkhir[]"></div></div><div class="form-group"><label class="control-label col-sm-4" for="alasanKeluar">Alasan Keluar (<font color="red">*</font>)</label><div class="col-sm-8"><textarea class="form-control required" id="alasanKeluar[]" name="alasanKeluar[]" rows="5"></textarea></div></div></div>&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp <button class="btn btn-danger remove">Hapus</button></div>');
			return false; //prevent form submission
		});

		$('#exercises').on('click', '.remove', function() {
			$(this).parent().remove();
			return false; //prevent form submission
		});
		
	//Tambah Baris
		$('.referensi').click(function() {
			$("#referensiKeluarga").append('<tr><td><div class="col-sm-12"><input type="text" class="form-control required" id="nmReferensi[]" name="nmReferensi[]"></div>		</td>	<td><div class="col-sm-12"><textarea class="form-control required" id="alamatReferensi[]" name="alamatReferensi[]"></textarea></div></td><td><div class="col-sm-12"><input type="text" class="form-control required" id="telpReferensi[]" name="telpReferensi[]"></div>		</td><td><div class="col-sm-12"><select class="form-control required" id="pekerjaanReferensi[]" name="pekerjaanReferensi[]"><option value="">- Pilih Pekerjaan-</option><option value="PNS">PNS</option><option value="Swasta">Pegawai Swasta</option><option value="Wirausaha">Wirausaha</option><option value="Pensiunan">Pensiunan</option><option value="Ibu Rumah Tangga">Ibu Rumah Tangga</option></select></div></td><td><div class="col-sm-12"><input type="text" class="form-control required" id="hubunganReferensi[]" name="hubunganReferensi[]"></div></td><td><input id="button1" type="button" class="btn btn-danger btnDelete" value="Hapus" /></td></tr>');
		});
		
		//Hapus Baris
		$(document).ready(function(){
			$("#referensiKeluarga").on('click','.btnDelete',function(){
				$(this).closest('tr').remove();
			});
		});
	</script>
	
	