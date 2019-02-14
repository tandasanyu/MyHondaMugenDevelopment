

 <div id="page-wrapper">
            <div class="row">
			
                <div class="col-lg-12"><br>
				<form method="post" action="<?php echo base_url().'index.php/promosi/testdrive'?>">
					<table align="right">
					<tr>
					<td><label class="control-label col-sm-8" for="nama">Tanggal:</label></td>
					<td><input type="text" class="form-control" id="datepicker" name="tgl" readonly="readonly" placeholder="dd-mm-yyyy"></td>
					<td><label class="control-label col-sm-8" for="nama">Lokasi:</label></td>
					<td><select class="form-control" id="lokasi" name="lokasi">
						<option value="">- Pilih Lokasi -</option>
						<option value="Pasar Minggu">Honda Mugen Pasar Minggu</option>
						<option value="Puri">Honda Mugen Puri</option>
						</select>
					</td>
					<td>&nbsp <input type="submit" class="btn btn-primary" value="cari"></td>
							</tr>
							</table>
						</form>	<br><br>
                    <h2>Jadwal Test Drive</h2>
					<h4><?php echo $tanggal;?></h4>
					
					
                </div>
                <!-- /.col-lg-12 -->
				
				<!-- /.col-lg-6 -->
                <div class="col-lg-12">   
                  
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
							<a align="right" href="<?php echo base_url().'index.php/Promosi/laporan_testdrive/'.$tanggal?>">Download PDF</a>
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
											<th>No</th>
											<th>Jam Kunjungan</th>
                                            <th>Nama</th>
                                            <th>Jenis Kendaraan</th>
											<th>Lokasi</th>
                                        </tr>
                                    </thead>
                                    <tbody>
									<?php $no=1; foreach  ($testdrive as $b): ?>
                                        <tr>
											<td align="center" class="col-md-1"><?php echo $no ?></td>
											<td class="col-md-2"><?php echo $b->jam ?></td>
											<td class="col-md-2"><?php echo $b->nama ?></td>
											<td class="col-md-3">Honda <?php echo $b->kendaraan ?></td>
											<td class="col-md-3">Honda Mugen <?php echo $b->lokasi ?></td>
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





