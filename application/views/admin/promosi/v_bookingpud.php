 <?php if($this->session->flashdata('msg')): ?>
    <p><?php echo $this->session->flashdata('msg'); ?></p>
<?php endif; ?>

 <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Data Booking Service PUD</h1>
                </div>
                <!-- /.col-lg-12 -->
				
				<!-- /.col-lg-6 -->
                <div class="col-lg-12">   
					<!-- /.panel-heading -->
					<div class="panel-body">
						<div class="table-responsive">
							<table class="table table-striped table-bordered table-hover">
								<thead>
									<tr>
										<th>No</th>
										<th>Tanggal Booking</th>
										<th>Nama</th>
										<th>Email</th>
										<th>No Handphone</th>
										<th>No Polisi</th>
										<th>Tipe Kendaraan</th>
										<th>Jadwal Kunjungan</th>
										<th>Jam Kunjungan</th>
										<th>Aksi</th>
									</tr>
								</thead>
								<tbody>
									<?php $no=1; foreach  ($booking as $b): ?>
                                        <tr>
											<td><?php echo $no ?></td>
											<td class="col-md-2"><?php echo date("d-m-Y", strtotime($b->day)) ?></td>
											<td class="col-md-2"><?php echo $b->booking_nama ?></td>
											<td><?php echo $b->booking_email ?></td>
											<td><?php echo $b->booking_tlp ?></td>
											<td><?php echo $b->booking_nopol ?></td>
											<td>Honda <?php echo $b->booking_tipe ?></td>
											<td><?php echo $b->booking_jadwal ?></td>
											<td><?php echo $b->booking_jam ?></td>
											<td><?php echo '&nbsp'. anchor('booking/hapus_booking/'.$b->booking_id, ' Hapus', array('class' => 'btn btn-danger btn-sm')); ?></td>
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





