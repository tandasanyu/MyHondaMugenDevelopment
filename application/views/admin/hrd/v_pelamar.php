 <div id="page-wrapper">
            <div class="row">
			
			<div class="col-lg-12"><br>
				<form method="post" action="<?php echo base_url().'Hrd/pelamar'?>">
					<table align="right">
					<tr>
					<td><label class="control-label col-sm-12" for="posisi">Pilih Posisi:</label></td>
					<td><select class="form-control" id="posisi" name="posisi">
						<option value="">- Pilih Posisi -</option>
						<?php foreach ($posisi as $b): ?>
						<option value="<?php echo $b->posisi ?>"><?php echo $b->posisi ?></option>
						<?php endforeach ?>
						</select>
					</td>
					<td>&nbsp <input type="submit" class="btn btn-primary" value="cari"></td>
							</tr>
							</table>
						</form>	<br><br>
                   
					
                </div>
                <div class="col-lg-12">
                    <h1 class="page-header">Data Pelamar</h1>
                </div>
                <!-- /.col-lg-12 -->
				
				<!-- /.col-lg-6 -->
                <div class="col-lg-12">
                    
                        <?php if ($cekLamaran==TRUE){?>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover" id="dataTable">
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
									<?php 
										foreach ($pelamar as $b): ?>
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
												<td><?php if($b->statusUndangan==1){
														echo ('&nbsp <button class="btn btn-success btn-sm" disabled=disabled>Undang Interview</button>');
													}else{
														echo '&nbsp'. anchor('Hrd/undang_interview/'.$b->noDaftar, ' Undang Interview', array('class' => 'btn btn-success btn-sm'));
													}
												?>	
												</td>
										</tr>
										<?php endforeach ?>
                                       
                                    </tbody>
                                </table>
							<?php }?>
                            </div><td><?php ?></td>
                            <!-- /.table-responsive -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
				
            
            
        </div>
        <!-- /#page-wrapper -->





