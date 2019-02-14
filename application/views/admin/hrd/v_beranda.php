	<div id="page-wrapper">
        <div class="row">
           
			<!-- /.col-lg-12 -->
				
			<!-- /.col-lg-12 -->
            <div class="col-lg-12">
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="col-md-12">
						<h2><marquee>Selamat Datang <?php echo $nama?></marquee></h2>
					</div>
					
					<div class="col-lg-12">
						<?php if ($cekLamaran==TRUE){?>
						<h2 class="page-header" style="color:red;">Lamaran Baru!</h2>
				
					
					<div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
											<th>Tanggal</th>
											<th>No Daftar</th>
											<th>Posisi</th>
                                            <th>Nama</th>
                                            <th>Form</th>
											<th>KTP</th>
											<th>KK</th>
											<th>NPWP</th>
											<th>Lamaran</th>
											<th>CV</th>
											<th>Ijazah</th>
											<th>Nilai</th>
											<th class="col-md-2">Aksi</th>
                                        </tr>
                                    </thead>
                                    <tbody>
									<?php foreach ($pelamar as $b): ?>
                                        <tr>
											<td><?php echo date("d M", strtotime($b->day)) ?></td>
											<td><?php echo $b->noDaftar ?></td>
											<td><?php echo $b->posisi ?></td>
											<td><?php echo $b->nama ?></td>
												<td><a href="<?php echo base_url().'hrd/cv/'.$b->noDaftar ?>"><img src="<?php echo base_url().'image/cv.png'?>" width="50" height="50"></a></td>
											<td><?php if ($b->pathKtp==NULL){echo "<center>-</center>";}else{?><a href="<?php echo base_url().'lamaran/'.$b->pathKtp ?>"><img src="<?php echo base_url().'image/idcard.png'?>" width="50" height="50"></a><?php }?></td>
										<td><?php if ($b->pathKK==NULL){echo "<center>-</center>";}else{?><a href="<?php echo base_url().'lamaran/'.$b->pathKK ?>"><img src="<?php echo base_url().'image/KK.png'?>" width="50" height="50"></a><?php }?></td>
										<td><?php if ($b->pathNPWP==NULL){echo "<center>-</center>";}else{?><a href="<?php echo base_url().'lamaran/'.$b->pathNPWP ?>"><img src="<?php echo base_url().'image/npwp.png'?>" width="50" height="50"></a><?php }?></td>
										<td><?php if ($b->pathSurat==NULL){echo "-";}else{?><a href="<?php echo base_url().'lamaran/'.$b->pathSurat ?>"><img src="<?php echo base_url().'image/suratlamaran.png'?>" width="50" height="50"></a><?php } ?></td>
										<td><?php if ($b->pathCV==NULL){echo "<center>-</center>";}else{?><a href="<?php echo base_url().'lamaran/'.$b->pathCV ?>"><img src="<?php echo base_url().'image/dataDiri.png'?>" width="60" height="60"></a><?php }?></td>
										<td><?php if ($b->pathIjazah==NULL){echo "<center>-</center>";}else{?><a href="<?php echo base_url().'lamaran/'.$b->pathIjazah ?>"><img src="<?php echo base_url().'image/ijazah.png'?>" width="50" height="50"></a><?php } ?></td>
										<td><?php if ($b->pathNilai==NULL){echo "<center>-</center>";}else{?><a href="<?php echo base_url().'lamaran/'.$b->pathNilai ?>"><img src="<?php echo base_url().'image/nilai.png'?>" width="50" height="50"></a><?php } ?></td>
										<td><?php echo '&nbsp'. anchor('hrd/terima/'.$b->noDaftar, 'Proses', array('class' => 'btn btn-primary btn-sm','onclick'=>"return confirm('Apakah Anda Yakin Menerima Lamaran Ini?')"));
													  echo '&nbsp'. anchor('hrd/tolak/'.$b->noDaftar, 'Tolak', array('class' => 'btn btn-danger btn-sm','onclick'=>"return confirm('Apakah Anda Yakin Menolak Lamaran Ini?')"));						
												?></td>
										</tr>
										<?php endforeach ?>
                                       
                                    </tbody>
                                </table>
						<?php }?>
                            </div>
                            <!-- /.table-responsive -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>            
    </div>