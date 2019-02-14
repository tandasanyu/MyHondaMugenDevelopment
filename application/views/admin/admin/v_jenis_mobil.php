 <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Data Jenis Mobil Honda</h1>
                </div>
                <!-- /.col-lg-12 -->
				
				<!-- /.col-lg-6 -->
                <div class="col-lg-12">   
                    <a href="<?php echo base_url().'index.php/Admin/form_jenis_mobil/'.$no?>" class="btn btn-primary">Tambah Jenis Mobil</a>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
											<th>No</th>
                                            <th>Jenis Mobil</th>
                                            <th>Harga</th>
                                            <th>Aksi</th>
                                        </tr>
                                    </thead>
                                    <tbody>
									<?php $no=1; foreach  ($event as $b): ?>
                                        <tr>
											<td><?php echo $no ?></td>
											<td class="col-md-3"><?php echo $b->jns_mobil ?></td>
											<td class="col-md-3">Rp <?php echo number_format($b->harga,2,",",".")?></td>
											<td>
												<?php echo '&nbsp'. anchor('Admin/edit_jenis/'.$b->kd_jenis.'/'.$b->kd_mobil, ' Ubah Data Mobil', array('class' => 'btn btn-warning btn-sm'));
												echo '&nbsp'. anchor('Admin/hapus_jenis/'.$b->kd_jenis.'/'.$b->kd_mobil, ' Hapus Data Mobil', array('class' => 'btn btn-danger btn-sm'));?>
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





