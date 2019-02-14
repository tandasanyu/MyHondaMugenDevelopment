<title>Test Drive</title>
<section id="content">
</section>
<section id="content">
	<div class="container">
		<div class="row">
			<div class="col-lg-8">
				<div class="row">
					<div class="col-lg-4">
						<a class="btn btn-primary" href="<?php echo base_url().'form_testdrive'?>">Request Test Drive</a><br><br>
					</div>
					<div class="col-lg-8">
						<form method="post" action="<?php echo base_url().'testdrive'?>">
							<table align="right">
								<tr>
									<td><label class="control-label col-sm-8" for="tanggal">Tanggal:</label></td>
									<td><div class="input-group">
											<input type="text" class="form-control" id="datepicker" name="tgl" readonly="readonly" placeholder="dd-mm-yyyy">
											<div class="input-group-addon">
												<i class="fa fa-calendar"></i>
											</div>
										</div>
									</td>
									<td>&nbsp <input type="submit" class="btn btn-primary" value="cari"></td>
								</tr>
							</table>
						</form>	
					</div>
				</div>	
				
				<h2>Jadwal Test Drive</h2>
				<h4><?php echo $tanggal;?></h4>
				<div class="table-responsive">
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
			</div>
			<!--Menampilkan Sidebar!-->
			<?php include('sidebar.php');?>
		</div>
	</div>
</section>