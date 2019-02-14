	<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Form Event Honda Mugen</h1>
            </div>
			<!-- /.col-lg-12 -->
				
			<!-- /.col-lg-12 -->
            <div class="col-lg-12">
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="col-md-12">
						<form class="form-horizontal" method="post" action="">
							<div class="form-group">
								<label class="control-label col-sm-2" for="nm_event">Nama Event:</label>
								<div class="col-sm-5"> 
									<input type="text" class="form-control" id="nm_event" name="nm_event" value="<?php echo $no->nm_event?>">
								</div>
							</div>
							
							<div class="form-group">
								<label class="control-label col-sm-2" for="tgl_event">Tanggal Event:</label>
								<div class="col-sm-5"> 
									<input class="form-control datepicker" name="tgl_event" data-date-format="mm/dd/yyyy" value="<?php echo $no->tgl_event?>">
								</div>
							</div>
							<div class="form-group">
								<label class="control-label col-sm-2" for="keterangan">Keterangan:</label>
								<div class="col-sm-8"> 
									<textarea name="keterangan"><?php echo $no->keterangan?></textarea>
								</div>
							</div>
							<div class="form-group">
                
              
				<input type="hidden" id="dtp_input2" value="" /><br/>
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