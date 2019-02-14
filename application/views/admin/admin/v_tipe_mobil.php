 <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Data Tipe Mobil Honda</h1>
                </div>
                <!-- /.col-lg-12 -->
				
				<!-- /.col-lg-6 -->
                <div class="col-lg-12">   
                    <a href="<?php echo base_url().'index.php/Admin/form_tipe_mobil'?>" class="btn btn-primary">Tambah Tipe</a>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
											<th>No</th>
                                            <th>Tipe Mobil</th>
                                            <th>Tanggal Update Harga</th>
                                            <th>Aksi</th>
                                        </tr>
                                    </thead>
                                    <tbody>
									<?php $no=1; foreach  ($event as $b): ?>
                                        <tr>
											<td><?php echo $no ?></td>
											<td class="col-md-3"><?php echo $b->keterangan ?></td>
											<td class="col-md-3"><?php echo $b->tglUpdate ?></td>
											<td>
												<?php	echo '&nbsp'. anchor('Admin/jenis_mobil/'.$b->kd_mobil, ' Jenis Mobil', array('class' => 'btn btn-success btn-sm'));?>
											</td>
										</tr>
										<?php $no++; endforeach ?>
                                    </tbody>
                                </table>
								<center><?php echo $this->pagination->create_links();?></center>
                            </div>
                            <!-- /.table-responsive -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
        </div>
        <!-- /#page-wrapper -->





