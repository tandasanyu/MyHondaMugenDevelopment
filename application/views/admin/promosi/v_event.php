 <?php if($this->session->flashdata('msg')): ?>
    <p><?php echo $this->session->flashdata('msg'); ?></p>
<?php endif; ?>

 <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Data Event Honda Mugen</h1>
                </div>
                <!-- /.col-lg-12 -->
				
				<!-- /.col-lg-6 -->
                <div class="col-lg-12">   
                    <a href="<?php echo base_url().'index.php/Promosi/form_event'?>" class="btn btn-primary">Tambah Event</a>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
											<th>No</th>
                                            <th>Nama Event</th>
                                            <th>Tanggal Event</th>
                                            <th>Keterangan</th>
                                            <th>Aksi</th>
                                        </tr>
                                    </thead>
                                    <tbody>
									<?php $no=1; foreach  ($event as $b): ?>
                                        <tr>
											<td><?php echo $no ?></td>
											<td class="col-md-3"><?php echo $b->nm_event ?></td>
											<td class="col-md-3"><?php echo date("d-m-Y", strtotime($b->day)) ?></td>
											<td class="col-md-3"><?php echo $b->keterangan ?></td>
											<td>
												<?php	echo '&nbsp'. anchor('Promosi/edit_event/'.$b->id_event, ' Ubah', array('class' => 'btn btn-warning btn-sm'));
														echo '&nbsp'. anchor('Promosi/hapus_event/'.$b->id_event, ' Hapus', array('class' => 'btn btn-danger btn-sm'));
												?>
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





