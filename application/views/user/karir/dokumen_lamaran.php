<title>Dokumen Lamaran</title>

		<section id="content" style="background-color:#ffffff;">
			<div class="container">
				<div class="row">
					<div class="col-lg-2">
					</div>
					<div class="col-lg-8"><br><br>
						<h2 style="font-family:cambria;">Berkas Lamaran Posisi: <?php echo $posisi->posisi?></h2>
						<h5><?php
							$tgl=date('d M Y');
							$hari   = date('l');
							$hari_indonesia = array('Monday'  => 'Senin',
													'Tuesday'  => 'Selasa',
													'Wednesday' => 'Rabu',
													'Thursday' => 'Kamis',
													'Friday' => 'Jumat',
													'Saturday' => 'Sabtu',
													'Sunday' => 'Minggu');?>
							<?php echo $hari_indonesia[$hari]?>,<?php echo $tgl;?> <p id="clock"></p></h5><br>
						<div class="table-responsive">
							<table class="table table-striped table-bordered table-hover">
								<thead>
									<tr>
										<th class="col-md-1"><center>No</center></th>
										<th class="col-md-6"><center>Dokumen</center></th>
										<th class="col-md-3"><center>Keterangan</center></th>
										<th class="col-md-2"><center>Aksi</center></th>
									</tr>
								</thead>
								<tbody>
									<tr>
										<td align="center">1</td>
										<td>Data Diri</td>
										<td></td>
										<td  align="center"><?php if($cekDataDiri==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dataDiri'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
									<tr>
										<td align="center" class="col-md-1">2</td>
										<td>Data Keluarga</td>
										<td></td>
										<td align="center"><?php if($cekDataKeluarga==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dataKeluarga'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
									<tr>
										<td align="center" class="col-md-1">3</td>
										<td>Riwayat Pendidikan</td>
										<td></td>
										<td align="center"><?php if($cekDataPendidikan==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dataPendidikan'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
									<tr>
										<td align="center" class="col-md-1">4</td>
										<td>Pengalaman Organisasi & Memimpin</td>
										<td>Lewati jika tidak ada</td>
										<td align="center"><?php if($cekDataOrganisasi==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dataOrganisasi'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
									<tr>
										<td align="center" class="col-md-1">5</td>
										<td>Riwayat Pekerjaan & Referensi</td>
										<td>Referensi wajib diisi</td>
										<td align="center"><?php if($cekDataPekerjaan==True || $cekDataReferensi==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dataPekerjaan'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
									<tr>
										<td align="center" class="col-md-1">6</td>
										<td>Pertanyaan</td>
										<td></td>
										<td align="center"><?php if($cekDataPertanyaan==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dataPertanyaan'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
									<tr>
										<td align="center" class="col-md-1">7</td>
										<td>Unggah Foto</td>
										<td></td>
										<td align="center"><?php if($cekFoto==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dokumenFoto'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
									<tr>
										<td align="center" class="col-md-1">8</td>
										<td>Unggah KTP</td>
										<td></td>
										<td align="center"><?php if($cekKTP==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dokumenKTP'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
									<tr>
										<td align="center" class="col-md-1">9</td>
										<td>Unggah NPWP</td>
										<td>Lewati jika tidak ada</td>
										<td align="center"><?php if($cekNPWP==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dokumenNPWP'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
									<tr>
										<td align="center" class="col-md-1">10</td>
										<td>Unggah Kartu Keluarga</td>
										<td></td>
										<td align="center"><?php if($cekKK==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dokumenKK'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
									<tr>
										<td align="center" class="col-md-1">11</td>
										<td>Unggah Ijazah</td>
										<td></td>
										<td align="center"><?php if($cekIjazah==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dokumenIjazah'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
									<tr>
										<td align="center" class="col-md-1">12</td>
										<td>Unggah Transkrip Nilai</td>
										<td></td>
										<td align="center"><?php if($cekNilai==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dokumenNilai'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
									<tr>
										<td align="center" class="col-md-1">13</td>
										<td>Unggah Surat Lamaran</td>
										<td></td>
										<td align="center"><?php if($cekSurat==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dokumenSuratLamaran'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
									<tr>
										<td align="center" class="col-md-1">14</td>
										<td>Unggah CV</td>
										<td></td>
										<td align="center"><?php if($cekCV==True){echo '<i class="fa fa-check" aria-hidden="true"></i>';}else{?><a href="<?php echo base_url().'dokumenCV'?>" class="btn btn-primary btn-sm">Lengkapi</a><?php }?> 
										</td>
									</tr>
								</tbody>
							</table>
							<a href="<?php echo base_url().'career/kirimLamaran'?>" class="col-md-12 btn btn-success btn-sm" onclick="return confirm('Apakah anda sudah yakin dengan data yang anda isi?');">Kirim Lamaran</a>
						</div>
						<div class="col-lg-2">
						</div>
					</div>
				</div>
			</div><br><br>
		</section>
<script type="text/javascript">
<!--
function showTime() {
    var a_p = "";
    var today = new Date();
    var curr_hour = today.getHours();
    var curr_minute = today.getMinutes();
    var curr_second = today.getSeconds();
    if (curr_hour < 12) {
        a_p = "AM";
    } else {
        a_p = "PM";
    }
    if (curr_hour == 0) {
        curr_hour = 12;
    }
    if (curr_hour > 12) {
        curr_hour = curr_hour - 12;
    }
    curr_hour = checkTime(curr_hour);
    curr_minute = checkTime(curr_minute);
    curr_second = checkTime(curr_second);
 document.getElementById('clock').innerHTML=curr_hour + ":" + curr_minute + ":" + curr_second + " " + a_p;
    }

function checkTime(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}
setInterval(showTime, 500);
//-->
</script>