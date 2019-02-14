<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Honda Mugen</title>

    <!-- Bootstrap Core CSS -->
    <link href="<?php echo base_url().'plugin/vendor/bootstrap/css/bootstrap.min.css'?>" rel="stylesheet">

    <!-- MetisMenu CSS -->
    <link href="<?php echo base_url().'plugin/vendor/metisMenu/metisMenu.min.css'?>" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="<?php echo base_url().'plugin/dist/css/sb-admin-2.css'?>" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="<?php echo base_url().'plugin/vendor/font-awesome/css/font-awesome.min.css'?>" rel="stylesheet" type="text/css">
</head>

<section>
	<br><br><br><br><br>
    <!-- Page Content -->
    <div class="container">
				
		<table>
			<tr>
				<td width="300" align="left"><img src="<?php echo base_url().'image/honda.png'?>" width="150" height="150" alt="" /></td>
				<td width="600" align="center"><p style="font-size: 135%;"><b> &nbsp &nbsp &nbsp PT. MITRAUSAHA GENTANIAGA <br>
					&nbsp &nbsp &nbsp (HONDA MUGEN)<br><br>
					&nbsp &nbsp &nbsp FORMULIR LAMARAN KERJA<br>
					&nbsp &nbsp &nbsp <?php echo $dataLamaran->posisi?></p></b>
					&nbsp &nbsp &nbsp 002 - FRM - HRD&GA R.2<br></td>
				<td width="300"> &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp <img align="right" src="<?php if ($cekFoto==TRUE){ echo base_url().'lamaran/'.$dokumenFoto->pathFoto; } else { echo base_url().'lamaran/unnamed.png';}?>" width="113" height="170" alt="" /></td>		
			</tr>
		</table><br>
		
		<br><br>
        <h4>Data Pribadi</h4>
        <div class="well">
			
               
                   	 <table>
						<tr>
						
							<td>&nbsp &nbsp &nbsp Nama </td>
							<td>&nbsp : &nbsp </td>
							<td><?php if ($cekDataDiri==TRUE){ echo $dataDiri->nama; } else { echo '-';}?></td>
							<td width="200"></td>
							<td>Panggilan </td>
							<td>&nbsp : &nbsp </td>
							<td><?php if ($cekDataDiri==TRUE){ echo  $dataDiri->panggilan; } else { echo '-';}?></td>
						</tr>	
						<tr>
							<td>&nbsp &nbsp &nbsp Tempat/Tanggal Lahir</td>
							<td>&nbsp : &nbsp </td>
							<td><?php if ($cekDataDiri==TRUE){ echo $dataDiri->tempatLahir; } else { echo '-';}?>, <?php if ($cekDataDiri==TRUE){ echo $dataDiri->tglLahir; } else { echo '-';}?></td>
							<td width="200"></td>
							<td>Usia</td>
							<td>&nbsp : &nbsp </td>
							<td><?php if ($cekDataDiri==TRUE){ $tglLahir = $dataDiri->tglLahir; } else { $tglLahir = date('Y');} 
								$rubah = date_format(date_create($tglLahir), 'Y');
								$thn_skrg = date('Y');
								$usia = $thn_skrg - $rubah;
								echo $usia;?> Tahun
							</td>
						</tr>
						<tr>
							<td>&nbsp &nbsp &nbsp Jenis Kelamin </td>
							<td>&nbsp : &nbsp </td>
							<td><?php  if ($cekDataDiri==TRUE){ $jkel = $dataDiri->jkel;}  else { $jkel = 0;} ?><input type="checkbox" <?php if ($jkel==1) {?> checked="checked"<?php }elseif ($jkel==0) {?>disabled="disabled"<?php } else {?>disabled="disabled"<?php }?>> Laki-Laki &nbsp &nbsp <input type="checkbox" <?php if ($jkel==2) {?> checked="checked"<?php }elseif ($jkel==0)  {?>disabled="disabled"<?php } else {?>disabled="disabled"<?php }?>> Perempuan </td></td>
							<td width="200"></td>
							<td>No. KTP </td>
							<td>&nbsp : &nbsp </td>
							<td><?php if ($cekDataDiri==TRUE){ echo  $dataDiri->ktp; } else { echo '-';}?></td>
						</tr>	

						<tr>
						    <td>&nbsp &nbsp &nbsp Agama </td>
							<td>&nbsp : &nbsp </td>
							<td><?php if ($cekDataDiri==TRUE){ $agama = $dataDiri->agama;}  else { $agama = 0;}
										if ($agama==1){
											echo "Islam";}
										elseif ($agama==2){
											echo "Kristen";}
										elseif ($agama==3){
											echo "Katolik";}
										elseif ($agama==4){
											echo "Hindu";}
										elseif ($agama==5){
											echo "Budha";}
										elseif ($agama==0){
											echo "-";}
										else {echo "Konghucu";}		
							?></td>
							<td width="200"></td>
								<td>No. SIM <?php if ($cekDataDiri==TRUE){ $jnsSim = $dataDiri->jnsSim;}  else { $jnsSim = 0;}
								if ($jnsSim==1){
									echo "A";}
									elseif ($jnsSim==2){
									echo "C";}
									elseif ($jnsSim==0){
									echo "-";}
									else{echo "-";}?>
							</td>
							<td>&nbsp : &nbsp </td>
							<td><?php if ($cekDataDiri==TRUE){ $sim = $dataDiri->jnsSim;}  else { $sim = 0;} 
										if ($sim==3){ echo "-";} elseif ($sim==0){ echo "-";} else { echo $dataDiri->sim; }?></td>
						</tr>

						<tr>
							<td>&nbsp &nbsp &nbsp NPWP</td>
							<td>&nbsp : &nbsp </td>
							<td><?php if ($cekDataDiri==TRUE){ echo  $dataDiri->npwp; } else { echo '-';}?></td>
							<td width="200"></td>
						    <td>No. Rek. BCA</td>
							<td>&nbsp : &nbsp</td>
							<td><?php if ($cekDataDiri==TRUE){ echo  $dataDiri->bca; } else { echo '-';} ?></td>
						</tr>	
						<tr>
							<td>&nbsp &nbsp &nbsp No. Jamsostek</td>
							<td>&nbsp : &nbsp </td>
							<td><?php if ($cekDataDiri==TRUE){ echo  $dataDiri->jamsostek; } else { echo '-';}?></td>

						</tr>	
					</table>	
                
			<table><br>
				<tr>
					<td>&nbsp &nbsp &nbsp Alamat Tinggal</td>
					<td>&nbsp &nbsp &nbsp : &nbsp </td>
					<td><?php if ($cekDataDiri==TRUE){ echo  $dataDiri->alamatTinggal; } else { echo '-';}?></td>
				</tr>	
				<tr>
					<td>&nbsp &nbsp &nbsp Alamat Sesuai KTP</td>
					<td>&nbsp &nbsp &nbsp : &nbsp </td>
					<td><?php if ($cekDataDiri==TRUE){ echo  $dataDiri->alamatKtp; } else { echo '-';}?></td>
				</tr>	
			</table>
			<table>
				<tr>
				    <td>&nbsp &nbsp &nbsp Telepon Rumah</td>
				    <td>&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp : &nbsp </td>
				    <td><?php if ($cekDataDiri==TRUE){ echo  $dataDiri->telp; } else { echo '-';} ?> </td>
				    <td width="280"></td>
			        <td>Handphone</td>
				    <td>&nbsp &nbsp &nbsp &nbsp : &nbsp </td>
    	            <td><?php if ($cekDataDiri==TRUE){ echo  $dataDiri->hp; } else { echo '-';}?></td>
			    </tr>	
			   
			</table>
		</div>
		
		<br>
		<h4>Latar Belakang Keluarga</h4>
		<table class="table table-striped table-bordered table-hover" id="Keluarga">
            <thead>
                <tr>
					<td></td>
                    <td align="center"><b>Nama</b></td>
					<td align="center" class="col-sm-2"><b>Jenis Kelamin</b></td>
                    <td align="center"><b>Usia</b></th>
                    <td align="center"><b>Pendidikan</b></td>
					<td align="center"><b>Pekerjaan</b></td>
                </tr>
            </thead>
           
			<tbody>
				<tr>
					<td>Ayah</td> 
					<td>
						<div class="col-sm-12">
							<?php echo $dataKeluarga->nmAyah?>
						</div>		
					</td>
					<td>
						<div class="col-sm-12">
							Laki-Laki
						</div>
					</td>	
					<td>
						<div class="col-sm-12">
							<?php echo $dataKeluarga->usiaAyah?>
						</div>
					</td>
					<td>
						<div class="col-sm-12">
							<?php echo $dataKeluarga->pendidikanAyah?>
						</div>
					</td>
					<td>
						<div class="col-sm-12">
							<?php echo $dataKeluarga->pekerjaanAyah?>
						</div>
					</td>
				</tr> 
				<tr>
					<td>Ibu</td> 
					<td>
						<div class="col-sm-12">
							<?php echo $dataKeluarga->nmIbu?>
						</div>		
					</td>
					<td>
						<div class="col-sm-12">
							Perempuan
						</div>
					</td>	
					<td>
						<div class="col-sm-12">
							<?php echo $dataKeluarga->usiaIbu?>
						</div>
					</td>
					<td>
						<div class="col-sm-12">
							<?php echo $dataKeluarga->pendidikanIbu?>
						</div>
					</td>
					<td>
						<div class="col-sm-12">
							<?php echo $dataKeluarga->pekerjaanIbu?>	
						</div>
					</td>
				</tr> 
				<?php foreach ($dataSaudara as $b): ?>
				<tr>
					<td>Anak</td> 
					<td>
						<div class="col-sm-12">
							<?php echo $b->nmSaudara ?>
						</div>		
					</td>
					<td>
						<div class="col-sm-12">
							<?php if($b->jkelSaudara==1){echo "Laki-Laki";}else{echo "Perempuan";} ?> 
						</div>
					</td>	
					<td>
						<div class="col-sm-12">
							<?php echo $b->usiaSaudara ?>
						</div>
					</td>
					<td>
						<div class="col-sm-12">
							<?php echo $b->pendidikanSaudara ?>
						</div>
					</td>
					<td>
						<div class="col-sm-12">
							<?php echo $b->pekerjaanSaudara ?>
						</div>
					</td>
				</tr> 
					<?php endforeach ?>
            </tbody>
        </table>
				
		<br>
		<h4>Status Perkawinan</h4>
		<input type="checkbox" <?php if ($cekStatusKawin==TRUE && $dataPasangan->statusKawin==1) {?> checked="checked"<?php }else {?>disabled="disabled"<?php }?>> Menikah &nbsp &nbsp <input type="checkbox" <?php if ($cekStatusKawin != TRUE) {?> checked="checked"<?php }else {?>disabled="disabled"<?php }?>> Belum Menikah &nbsp &nbsp <input type="checkbox" <?php if ($cekStatusKawin==TRUE && $dataPasangan->statusKawin==3) {?> checked="checked"<?php }else {?>disabled="disabled"<?php }?>> Duda/Janda <br><br>
		
			<?php if ($cekStatusKawin==TRUE) {?>
			<table class="table table-striped table-bordered table-hover" id="Keluarga">
				<thead>
					<tr>
						<td align="center" class="col-sm-2"><b>Hubungan Keluarga</b></td>
						<td align="center"><b>Nama</b></td>
						<td align="center"><b>Jenis Kelamin</b></td>
						<td align="center"><b>Usia</b></th>
						<td align="center"><b>Pendidikan</b></td>
						<td align="center"><b>Pekerjaan</b></td>
					</tr>
				</thead>
						
				<tbody>
					<tr>
						<td><?php if ($dataDiri->jkel==1) {?>Istri <?php }else{ ?> Suami <?php }?> </td> 
						<td>
							<div class="col-sm-12">
								<?php echo $dataPasangan->nmPasangan ?>
							</div>		
						</td>
						<td>
							<div class="col-sm-12">
								<?php if ($dataDiri->jkel==1) {?>Perempuan <?php }else{ ?> Laki-Laki <?php }?>
							</div>
						</td>	
						<td>
							<div class="col-sm-12">
								<?php echo $dataPasangan->usiaPasangan ?>
							</div>
						</td>
						<td>
							<div class="col-sm-12">
								<?php echo $dataPasangan->pendidikanPasangan ?>
							</div>
						</td>
						<td>
							<div class="col-sm-12">
								<?php echo $dataPasangan->pekerjaanPasangan ?>
							</div>
						</td>
					</tr> 
					<?php //if ($cekAnak==TRUE) {
						foreach ($dataAnak as $b): ?>
					<tr>
						<td>Anak</td> 
						<td>
							<div class="col-sm-12">
								<?php echo $b->nmAnak ?>
							</div>		
						</td>
						<td>
							<div class="col-sm-12">
								<?php if($b->jkelAnak==1){echo "Laki-Laki";}else{echo "Perempuan";} ?>  
							</div>
						</td>	
						<td>
							<div class="col-sm-12">
								<?php echo $b->usiaAnak ?>
							</div>
						</td>
						<td>
							<div class="col-sm-12">
								<?php echo $b->pendidikanAnak ?>
							</div>
						</td>
						<td>
							<div class="col-sm-12">
								<?php echo $b->pekerjaanAnak ?>
							</div>
						</td>
					</tr> 
						<?php endforeach; 
					//}?>
				</tbody>
			</table>
		<?php }?>
		<br>		
		<h4> Pendidikan Formal</h4>
        <table class="table table-striped table-bordered table-hover" id="test">
			<thead>
                <tr>
                    <td align="center" rowspan="2"><b>Jenjang</b></td>
					<td align="center" rowspan="2"><b>Nama Instansi</b></td>
                    <td align="center" rowspan="2"><b>Kota</b></th>
                    <td align="center" colspan="2"><b>Tahun</b></td>
					<td align="center" class="col-md-2" rowspan="2"><b>Lulus/Tidak</b></td>
					<td align="center" rowspan="2"><b>Jurusan</b></td>
                </tr>
				<tr>
					<td align="center"><b>Masuk</b></td>
					<td align="center"><b>Keluar</b></td>
				</tr>	
            </thead>
            <tbody>
				<?php foreach ($dataPendidikanFormal as $b): ?>
				<tr>
					<td>
						<div class="col-sm-12">
							<?php echo $b->jenjangPendidikan ?>
						</div>
					</td>
					<td>
						<div class="col-sm-12">
							<?php echo $b->nmInstansi ?>	
						</div>		
					</td>	
					<td>
						<div class="col-sm-12">
							<?php echo $b->kotaInstansi ?>
						</div>		
					</td>	
					<td>
						<div class="col-sm-12">
							<?php echo $b->thnMasuk ?>		
						</div>
					</td>
					<td>
						<div class="col-sm-12">
							<?php echo $b->thnKeluar ?>	
						</div>
					</td>
					<td>
						<div class="col-sm-12">
							<?php if($b->kelulusan==1){echo "Lulus";}else{echo "Tidak Lulus";} ?> 	
						</div>
					</td>	
					<td>
						<div class="col-sm-12">
							<?php echo $b->jurusan ?>	
						</div>
					</td>
				</tr> 
					<?php endforeach ?>
            </tbody>
        </table>
		
		<?php if ($cekNonFormal==True){?>	
		<br>
		<h4>Pendidikan Non Formal (kursus/seminar)</h4>		
		<table class="table table-striped table-bordered table-hover">
            <thead>
                <tr>
					<td align="center"><b>Nama Instansi</b></td>
					<td align="center"><b>Tahun</b></td>
                </tr>
            </thead>
			<tbody>
				<?php foreach ($dataPendidikanNonFormal as $b): ?>
				<tr>
					<td>
						<div class="col-sm-12">
							<?php echo $b->nmInstansiNon ?>	
						</div>		
					</td>
					<td>
						<div class="col-sm-12">
							<?php echo $b->tahunNon ?>		
						</div>
					</td>
				</tr> 
				<?php endforeach ?>
            </tbody>
        </table>
		<?php }?>
		
		<?php if ($cekBahasa==True){?>		
		<br>
		<h4>Bahasa Asing Yang Dikuasai:</h4>	
		<table class="table table-striped table-bordered table-hover">
            <thead>
                <tr>
                    <td align="center"><b>Jenis Bahasa</b></td>
					<td align="center"><b>Tingkat Penguasaan</b></td>
                </tr>
            </thead>
            <tbody>
				<?php foreach ($dataKemampuanBahasa as $b): ?>
				<tr>
					<td>
						<div class="col-sm-12">
							<?php echo $b->jnsBahasa ?>		
						</div>		
					</td>
					<td>
						<div class="col-sm-12">
							<center>
								<input type="checkbox" name="penguasaan" <?php if ($b->penguasaan==1) {?> checked="checked"<?php }else {?>disabled="disabled"<?php }?>  > Baik &nbsp &nbsp &nbsp <input type="checkbox" name="penguasaan" <?php if ($b->penguasaan==2) {?> checked="checked"<?php }else {?>disabled="disabled"<?php }?>  >  Cukup &nbsp &nbsp &nbsp <input type="checkbox" name="penguasaan" <?php if ($b->penguasaan==3) {?> checked="checked"<?php }else {?>disabled="disabled"<?php }?>  >  Kurang
							</center>
						</div>
					</td>	
				</tr> 
				<?php endforeach ?>
            </tbody>
        </table>
		<?php }?>
        <?php if ($cekOrganisasi==True){?>
		<br>
		<h4>Pengalaman Organisasi:</h4>	
        <table class="table table-striped table-bordered table-hover">
            <thead>
                <tr>
                    <td align="center"><b>Nama Organisasi</b></td>
					<td align="center"><b>Tahun</b></td>
                </tr>
            </thead>
            <tbody>
				<?php foreach ($dataOrganisasi as $b): ?>
				<tr>
					<td>
						<div class="col-sm-12">
							<?php echo $b->nmOrg ?>	
						</div>		
					</td>
					<td>
						<div class="col-sm-12">
							<?php echo $b->tahunOrg ?>			
						</div>
					</td>
				</tr> 
				<?php endforeach?>
            </tbody>
        </table>
		<?php } ?>
		
		<?php if ($cekLeader==True){?>
			<br>
			<h4>Pengalaman Memimpin:</h4>	
			 <div class="well">	
				<?php echo $dataPengalamanMemimpin->pengalamanLeader ?>		
			</div>	
		<?php }?>
		
		<?php if ($cekKerja==True){?>
			<br>
			<h4>Riwayat Pekerjaan:</h4>
			<?php foreach ($dataPekerjaan as $b): ?>
			  <table class="table table-striped table-bordered table-hover">
				<thead>
					<tr>
						<td align="center" rowspan="2"><b><u>Nama Perusahaan</u></b><br><br><?php echo $b->nmPerusahaan ?></td>
						<td align="center" rowspan="2"><b>Jabatan</b></td>
						<td align="center" colspan="2"><b>Waktu</b></td>
						<td align="center" colspan="2"><b>Gaji</b></td>
						<td align="center" rowspan="2"><b>Alasan Keluar</b></td>
					</tr>
					<tr>
						<td align="center"><b>Masuk</b></td>
						<td align="center"><b>Keluar</b></td>
						<td align="center"><b>Awal</b></td>
						<td align="center"><b>Akhir</b></td>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td><b>Alamat:</b> <?php echo $b->alamatPerusahaan ?></td>
						<td rowspan="3"><div class="col-sm-12"><?php echo $b->jabatan ?></div></td>
						<td rowspan="3"><div class="col-sm-12"><?php echo $b->wMasuk?></div></td>
						<td rowspan="3"><div class="col-sm-12"><?php echo $b->wKeluar ?></div></td>
						<td rowspan="3"><div class="col-sm-12"><?php echo $b->gAwal ?></div></td>
						<td rowspan="3"><div class="col-sm-12"><?php echo $b->gAkhir ?></div></td>
						<td rowspan="4"><div class="col-sm-12"><?php echo $b->alasanKeluar ?></div></td>
					</tr>
					<tr>
						<td><b>Telp:</b> <?php echo $b->telpPerusahaan ?></td>
					</tr>
					<tr>
						<td><b>Nama Atasan Langsung:</b> <?php echo $b->nmAtasan ?></td>
					</tr>
					<tr>
						<td colspan="6"><b>Tugas-tugas:</b> <?php echo $b->tugas ?></td>
					</tr>
				</tbody>	
			</table>	
			<?php endforeach; 
		} ?>
		
		<br>
		<h4>Referensi:</h4>	
        <table class="table table-striped table-bordered table-hover">
            <thead>
                <tr>
                    <td align="center"><b>Nama</b></td>
					<td align="center"><b>Alamat</b></td>
					<td align="center"><b>No. Telepon</b></td>
					<td align="center"><b>Pekerjaan</b></td>
					<td align="center"><b>Hubungan</b></td>
                </tr>
            </thead>
			<tbody>
				<?php foreach ($dataReferensi as $b): ?>
				<tr>
					<td><div class="col-sm-12"><?php echo $b->nmReferensi ?></div></td>
					<td><div class="col-sm-12"><?php echo $b->alamatReferensi ?></div> </td>
					<td><div class="col-sm-12"><?php echo $b->telpReferensi ?></div></td>
					<td><div class="col-sm-12"><?php echo $b->pekerjaanReferensi ?></div></td>
					<td><div class="col-sm-12"><?php echo $b->hubunganReferensi ?></div></td>
				</tr>
				<?php endforeach?>
			</tbody>
		</table>
		<?php if ($cekPertanyaan==True){?>
		<br><br>
		<h4>1. Apakah anda pernah sakit yang membutuhkan perawatan di rumah sakit?</h4>	
		<div class="well">	
			<?php if ($dataPertanyaan->descSakit!=""){?>
			Ya, <?php echo $dataPertanyaan->descSakit; } else{?> Tidak<?php }?>		
		</div><br>
		
		<h4>2. Sebutkan kelebihan diri anda!</h4>	
		<div class="well">	
			<?php echo $dataPertanyaan->kelebihan ?>		
		</div><br>
		
		<h4>3. Sebutkan kekurangan diri anda!</h4>	
		<div class="well">	
			<?php echo $dataPertanyaan->kekurangan ?>		
		</div><br>
			
		<h4>4. Keahlian apa saja yang anda miliki?</h4>	
		<div class="well">	
			<?php echo $dataPertanyaan->keahlian ?>		
		</div><br>
		
		<h4>5. Apa yang anda ketahui mengenai "Job Description"	dari pekerjaan yang anda lamar ini?</h4>	
		<div class="well">	
			<?php echo $dataPertanyaan->jobDesc ?>		
		</div><br>	
		
		<h4>6. Berapa gaji yang anda harapkan?	</h4>	
		<div class="well">	
			<?php echo $dataPertanyaan->harapanGaji ?>		
		</div><br>		
	
		<h4>7. Sebutkan tunjangan/fasilitas yang anda inginkan!	</h4>	
		<div class="well">	
			<?php echo $dataPertanyaan->tunjangan ?>		
		</div><br>		
		
		<h4>8. Bila anda diterima, kapan anda siap bekerja di Honda Mugen?	</h4>	
		<div class="well">	
			<?php echo $dataPertanyaan->mulaiKerja ?>		
		</div><br>		
		
		<h4>9. Apakah anda bersedia ditempatkan dimana saja sesuai dengan kebutuhan perusahaan?</h4>	
		<div class="well">	
				<?php if ($dataPertanyaan->penempatan==1) {?> Ya, saya bersedia <?php }else {?>Saya tidak bersedia<?php }?>	
		</div><br>	

		<h4>10. Mengapa anda ingin bergabung dengan Honda Mugen?</h4>	
		<div class="well">	
			<?php echo $dataPertanyaan->alasanGabung ?>		
		</div><br>			
	
		<h4>11. Apa yang anda ketahui tentang Honda Mugen?</h4>	
		<div class="well">	
			<?php echo $dataPertanyaan->tentangMugen ?>		
		</div><br>			
		
		<div class="form-group">
			<label for="lingkunganKerja">12. Anda senang bekerja pada lingkungan:</label>
			&nbsp &nbsp <input type="checkbox" <?php if ($dataPertanyaan->lingkunganKerja==1) {?> checked="checked"<?php }else {?>disabled="disabled"<?php }?>  > di dalam kantor &nbsp &nbsp <input type="checkbox" <?php if ($dataPertanyaan->lingkunganKerja==2) {?> checked="checked"<?php }else {?>disabled="disabled"<?php }?>  > di luar kantor	&nbsp &nbsp <input type="checkbox" <?php if ($dataPertanyaan->lingkunganKerja==3) {?> checked="checked"<?php }else {?>disabled="disabled"<?php }?>  > di dalam bengkel &nbsp &nbsp <input type="checkbox" <?php if ($dataPertanyaan->lingkunganKerja==4) {?> checked="checked"<?php }else {?>disabled="disabled"<?php }?>  > lainnya		
		</div>
		<?php }?>
		<br><br>	
		<p align="right">Saya menyatakan apa yang ditulis adalah benar<br>
		<?php echo  date('d M Y H:i:s', strtotime($dataLamaran->tglLamar)); ?><br><br><br><br>
		
		<?php if ($cekDataDiri==TRUE){ echo $dataDiri->nama; } else { echo '-';}?></p>
		
				
	</div>

	
</section>
</body>

</html>