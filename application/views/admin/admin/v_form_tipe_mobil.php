	<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Form Tipe Mobil</h1>
            </div>
			<!-- /.col-lg-12 -->
				
			<!-- /.col-lg-12 -->
            <div class="col-lg-12">
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="col-md-12">
						<form class="form-horizontal" method="post" action="<?php echo base_url().'Admin/simpan_tipe_mobil'?>">
							<div class="form-group">
								<label class="control-label col-sm-2" for="kd_mobil">Kode Mobil:</label>
								<div class="col-sm-5"> 
									<input type="text" class="form-control" id="kd_mobil" name="kd_mobil">
								</div>
							</div>
							<div class="form-group">
								<label class="control-label col-sm-2" for="keterangan">Keterangan:</label>
								<div class="col-sm-5"> 
									<input type="text" class="form-control" id="keterangan" name="keterangan">
								</div>
							</div>
							<div class="form-group"> 
								<div class="col-sm-offset-5 col-sm-10">
									<input type="submit" class="btn btn-primary" value="Simpan">
								</div>
							</div>
						</form>
					</div>
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>            
    </div>
    <!-- /#page-wrapper -->