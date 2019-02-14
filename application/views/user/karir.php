<title>Karir</title>
<section id="content">
</section>
<section id="content">
	<div class="container">
		<div class="row">
			<div class="col-lg-8">
				<h2>Bergabunglah Bersama Kami</h2>
				<p>	Honda Mugen adalah perwakilan dealer resmi mobil Honda dengan skala 3S 
					(Sales, Service, Spare Part) yang bernaung di bawah PT. Mitrausaha Gentaniaga. 
					Honda Mugen berlokasi di Pasar Minggu, Jakarta Selatan dan telah melayani dan memenuhi kebutuhan 
					pelanggan sejak tahun 1991. Seiring dengan pesatnya perkembangan perusahaan, 
					pada tahun 2008 dibuka cabang baru di Puri Kembangan, Jakarta Barat. <br><br>
				
					Dan saat ini, kami membuka kesempatan bagi anda untuk bergabung menjadi 
					bagian dari perjalanan kami menjadi dealer resmi Honda nomor 1 di Indonesia.
					<br><br>
				</p>
				<h4>Posisi Yang Kami Tawarkan</h4>
				<div class="table-responsive">
					<table class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
								<th>No</th>
								<th>Tanggal Posting</th>
                                <th>Posisi</th>
                                <th>Detail</th>
								<th>Aksi</th>
                            </tr>
                        </thead>
						<tbody>
							<?php $no=1; foreach  ($lowongan as $b): ?>
                            <tr>
								<td align="center" class="col-md-1"><?php echo $no ?></td>
								<td class="col-md-2"><?php echo date("d-m-Y", strtotime($b->day)) ?></td>
								<td class="col-md-2"><?php echo $b->posisi ?></td>
								<td class="col-md-3"><?php echo $b->kualifikasi ?></td>
								<td class="col-md-1"><?php echo '&nbsp'. anchor('buatAkun/'.$b->id_lowongan, ' Lamar', array('class' => 'btn btn-primary btn-sm'));?></td>
                            </tr>
							<?php $no++; endforeach ?>
						</tbody>
					</table>
				</div>
				<!--<p style="text-align:center">
					Anda juga dapat mengirimkan Surat Lamaran, CV, fotocopy KTP, Ijazah, transkrip nilai terakhir dan 
					foto terbaru ukuran 3x4 dengan menuliskan posisi yang dilamar di pojok kanan atas amplop dan 
					kirimkan ke:<br><br>

					<b>Honda Mugen Pasar Minggu:</b> Jl. Raya Pasar Minggu No. 10 Jakarta Selatan, 12740<br>
					<b>Honda Mugen Puri:</b> Jl. Lingkar Luar Barat Puri Kembangan Jakarta Barat, 11610<br><br>
					Atau dapat mengirimkan melalui email ke:<br>
					<a href="mailto:recruitmentmugen@gmail.com">recruitmentmugen@gmail.com</a>
				</p>-->
			</div>
			<!--Menampilkan Sidebar!-->
			<?php include('sidebar.php');?>
		</div>
	</div>
</section>