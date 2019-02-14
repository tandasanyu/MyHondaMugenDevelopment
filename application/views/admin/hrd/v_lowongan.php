
 <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Data Lowongan Kerja</h1>
                </div>
                <!-- /.col-lg-12 -->
				
				<!-- /.col-lg-6 -->
                <div class="col-lg-12">   
                    <a href="<?php echo base_url().'index.php/Hrd/form_lowongan'?>" class="btn btn-primary">Tambah Lowongan</a>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
											<th>No</th>
                                            <th>Posisi</th>
                                            <th>Kualifikasi</th>
                                            <th>Status</th>
                                            <th>Aksi</th>
                                        </tr>
                                    </thead>
                                    <tbody>
									<?php $no=1; foreach  ($lowongan as $b): ?>
                                        <tr>
											<td><?php echo $no ?></td>
											<td class="col-md-3"><?php echo $b->posisi ?></td>
											<td class="col-md-3"><?php echo $b->kualifikasi ?></td>
											<td><?php if($b->status==1){echo "Published";}else{echo"Unpublished";} ?></td>
											<td><?php if($b->status==1){
															echo anchor('Hrd/edit_status/'.$b->id_lowongan.'/'.$b->status, ' Unpublished', array('class' => 'btn btn-success btn-sm'));
															echo ('&nbsp <button class="btn btn-warning btn-sm" disabled=disabled>Ubah</button>'); 
															echo ('&nbsp <button class="btn btn-danger btn-sm" disabled=disabled>Hapus</button>');
													  }else{
															echo anchor('Hrd/edit_status/'.$b->id_lowongan.'/'.$b->status, ' Published', array('class' => 'btn btn-info btn-sm'));  
															echo '&nbsp'. anchor('Hrd/edit_lowongan/'.$b->id_lowongan, ' Ubah', array('class' => 'btn btn-warning btn-sm'));
															echo '&nbsp'. anchor('Hrd/hapus_lowongan/'.$b->id_lowongan, ' Hapus', array('class' => 'btn btn-danger btn-sm'));
													  }?>
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





