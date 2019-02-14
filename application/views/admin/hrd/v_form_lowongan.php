	<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Form Lowongan Pekerjaan</h1>
            </div>
			<!-- /.col-lg-12 -->
				
			<!-- /.col-lg-12 -->
            <div class="col-lg-12">
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="col-md-12">
						<form class="form-horizontal" method="post" action="<?php echo base_url().'Hrd/simpan_lowongan'?>">
							<div class="form-group">
								<label class="control-label col-sm-2" for="tgl_posting">Tanggal Posting:</label>
								<div class="col-sm-5">
									<input type="text" class="form-control" id="tgl_posting" value="<?php echo date('d-m-Y')?>" name="tgl_posting" readonly="readonly">
								</div>
							</div>
							<div class="form-group">
								<label class="control-label col-sm-2" for="posisi">Posisi:</label>
								<div class="col-sm-5"> 
									<input type="text" class="form-control" id="posisi" name="posisi">
								</div>
							</div>
							<div class="form-group">
								<label class="control-label col-sm-2" for="kualifikasi">Kualifikasi:</label>
								<div class="col-sm-8"> 
									<textarea name="kualifikasi"> </textarea>
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