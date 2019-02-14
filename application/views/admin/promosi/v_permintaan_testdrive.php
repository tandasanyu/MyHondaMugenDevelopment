<div id="page-wrapper">
    <div class="row">
		<div class="col-lg-12"><br>
			<h1 class="page-header">Permintaan Test Drive</h1>
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
								<th>Tanggal Kunjungan</th>
								<th>Jam</th>
                                <th>Nama</th>
								<th>Jenis Kendaraan</th>
								<th>Lokasi</th>
								<th>Status</th>
								<th>Aksi</th>
                            </tr>
                        <thead>
                        <tbody>
							<?php $no=1; foreach  ($testdrive as $b): ?>
                            <tr>
								<td align="center"><?php echo $no ?></td>
								<td class="col-md-2"><?php echo $b->tgl ?></td>
								<td class="col-md-1"><?php echo $b->jam ?></td>
								<td class="col-md-2"><?php echo $b->nama ?></td>
								<td class="col-md-2">Honda <?php echo $b->kendaraan ?></td>
								<td class="col-md-2">Honda Mugen <?php echo $b->lokasi ?></td>
								<td class="col-md-1"><?php if($b->status==1){echo "<p style='color:green;'>Disetujui</p>";}
															elseif($b->status==2){echo "<p style='color:red;'>Ditolak</p>";}
															else{echo"Belum Ada Persetujuan";}?></td>
								<td class="col-md-3"><?php if($b->status==1||$b->status==2){
															echo ('<button class="btn btn-primary btn-sm" disabled=disabled>Setuju</button>'); 
															echo ('&nbsp <button class="btn btn-danger btn-sm" disabled=disabled>Tolak</button>');
													  }else{
															echo anchor('Promosi/persetujuan_testdrive/'.$b->id_testdrive, ' Setuju', array('class' => 'btn btn-primary btn-sm')); 
															echo '&nbsp'. anchor('Promosi/tolak_testdrive/'.$b->id_testdrive, ' Tolak', array('class' => 'btn btn-danger btn-sm'));
													  }?></td>
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