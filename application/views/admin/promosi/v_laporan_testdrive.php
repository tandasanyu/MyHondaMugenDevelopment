 <link href="<?php echo base_url().'plugin/vendor/bootstrap/css/bootstrap.min.css'?>" rel="stylesheet">


    <!-- Custom Fonts -->
    <link href="<?php echo base_url().'plugin/vendor/font-awesome/css/font-awesome.min.css'?>" rel="stylesheet" type="text/css">
                    <center><h2>Jadwal Test Drive</h2>
					<h4><?php echo $tanggal;?></h4></center>
					
                       
                                 <table class="table table-bordered">
                                        <tr>
											<td></td>
											<th align="center" class="col-md-1">No</th>
											<th class="col-md-1">Jam Kunjungan</th>
                                            <th class="col-md-2">Nama</th>
                                            <th class="col-md-3">Jenis Kendaraan</th>
											<th class="col-md-3">Lokasi</th>
											<th class="col-md-2">Tanda Tangan</th>
                                        </tr>
									<?php $no=1; foreach  ($testdrive as $b): ?>
                                        <tr>
											<td><?php echo $no ?></td>
											<td><?php echo $b->jam ?></td>
											<td><?php echo $b->nama ?></td>
											<td>Honda <?php echo $b->kendaraan ?></td>
											<td>Honda Mugen <?php echo $b->lokasi ?></td>
											<td></td>
                                        </tr>
										<?php $no++; endforeach ?>
                                </table>
								
                        