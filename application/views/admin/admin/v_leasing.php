 <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Data Leasing</h1>
                </div>
                <!-- /.col-lg-12 -->
				
				<!-- /.col-lg-6 -->
                <div class="col-lg-12">   
                    <a href="<?php echo base_url().'index.php/Admin/form_leasing'?>" class="btn btn-primary">Tambah Leasing</a>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
											<th rowspan="2">No</th>
                                            <th rowspan="2" class="col-md-3">Nama Leasing</th>
                                            <th rowspan="2">Bunga</th>
											<th colspan="5" style="text-align:center">Asuransi</th>
											<th rowspan="2">Provisi</th>
											<th rowspan="2">Administrasi</th>
                                            <th rowspan="2" class="col-md-3">Aksi</th>
                                        </tr>
										<tr>
											
											<th>OTR <= 125</th>
											<th>OTR > 125 - 200</th>
											<th>OTR > 200 - 400</th>
											<th>OTR > 400 - 800</th>
											<th>OTR > 800</th>
											
										</tr>
                                    </thead>
                                    <tbody>
									<?php $no=1; foreach  ($leasing as $b): ?>
                                        <tr>
											<td><?php echo $no ?></td>
											<td><?php echo $b->nm_leasing ?></td>
											<td><?php echo $b->bunga?>%</td>
											<td><?php echo $b->asuransi1?>%</td>
											<td><?php echo $b->asuransi2?>%</td>
											<td><?php echo $b->asuransi3?>%</td>
											<td><?php echo $b->asuransi4?>%</td>
											<td><?php echo $b->asuransi5?>%</td>
											<td><?php echo $b->provisi?>%</td>
											<td>Rp <?php echo number_format($b->admin,2,",",".")?></td>
											<td>
												<?php echo '&nbsp'. anchor('Admin/edit_leasing/'.$b->id_leasing, ' Ubah Leasing', array('class' => 'btn btn-warning btn-sm'));
												echo '&nbsp'. anchor('Admin/hapus_leasing/'.$b->id_leasing, ' Hapus Leasing', array('class' => 'btn btn-danger btn-sm'));?>
											</td>
										</tr>
										<?php $no++; endforeach ?>
                                    </tbody>
                                </table>
								
                            </div>
                            <!-- /.table-responsive -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
        </div>
        <!-- /#page-wrapper -->





