 <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Undangan Interview</h1>
                </div>
                <!-- /.col-lg-12 -->
				
				<!-- /.col-lg-6 -->
                <div class="col-lg-12">
                    
                        
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                           <form class="form-horizontal" method="post" action="<?php echo base_url().'index.php/Hrd/kirimundangan'?>">
							<div class="form-group">
								<label class="control-label col-sm-2" for="nama">Nama Pelamar:</label>
								<div class="col-sm-5">
									<input type="text" class="form-control" id="nama" value="<?php echo $pelamar->nama?>" name="nama" readonly="readonly">
								</div>
							</div>
							<div class="form-group">
								<label class="control-label col-sm-2" for="email">Email:</label>
								<div class="col-sm-5"> 
									<input type="text" class="form-control" id="email" name="email" value="<?php echo $pelamar->email?>" readonly="readonly">
									<input type="hidden" class="form-control" id="noDaftar" name="noDaftar" value="<?php echo $pelamar->noDaftar?>">
								</div>
							</div>
							<div class="form-group">
								<label class="control-label col-sm-2" for="pesan">Pesan:</label>
								<div class="col-sm-8"> 
									<textarea name="pesan"> </textarea>
								</div>
							</div>
							<div class="form-group"> 
								<div class="col-sm-offset-5 col-sm-10">
									<input type="submit" class="btn btn-primary" value="Kirim">
								</div>
							</div>
						</form>
										
										
                            <!-- /.table-responsive -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
				
            
            
        </div>
        <!-- /#page-wrapper -->





