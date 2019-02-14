	<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Form Edit Data Leasing</h1>
            </div>
			<!-- /.col-lg-12 -->
				
			<!-- /.col-lg-12 -->
            <div class="col-lg-12">
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="col-md-12">
						<form class="form-horizontal" method="post" action="">
							<div class="form-group">
								<label class="control-label col-sm-2" for="nm_leasing">nm_leasing:</label>
								<div class="col-sm-5"> 
									<input type="text" class="form-control" id="nm_leasing" name="nm_leasing" value="<?php echo $no->nm_leasing?>">
								</div>
							</div>
							<div class="form-group">
								<label class="control-label col-sm-2" for="bunga">Bunga:</label>
								<div class="col-sm-5"> 
									<select class="form-control" id="bunga" name="bunga">
										<option value="<?php echo $no->bunga?>"><?php echo $no->bunga?>%</option>
										<option value="1">1%</option>
										<option value="2">2%</option>
										<option value="3">3%</option>
										<option value="4">4%</option>
										<option value="5">5%</option>
										<option value="6">6%</option>
										<option value="7">7%</option>
										<option value="8">8%</option>
										<option value="9">9%</option>
										<option value="10">10%</option>
									</select>
								</div>
							</div>
							<div class="form-group">
								<label class="control-label col-sm-2" for="asuransi1">Asuransi OTR <= 125 Jt :</label>
								<div class="col-sm-5"> 
									<input type="text" class="form-control" id="asuransi1" name="asuransi1" value="<?php echo $no->asuransi1?>">
								</div>
							</div>
							<div class="form-group">
								<label class="control-label col-sm-2" for="asuransi2">Asuransi OTR > 125 Jt - 200 Jt :</label>
								<div class="col-sm-5"> 
									<input type="text" class="form-control" id="asuransi2" name="asuransi2" value="<?php echo $no->asuransi2?>">
								</div>
							</div>
							<div class="form-group">
								<label class="control-label col-sm-2" for="asuransi3">Asuransi OTR > 200 Jt - 400 Jt :</label>
								<div class="col-sm-5"> 
									<input type="text" class="form-control" id="asuransi3" name="asuransi3" value="<?php echo $no->asuransi3?>">
								</div>
							</div>
							<div class="form-group">
								<label class="control-label col-sm-2" for="asuransi4">Asuransi OTR > 400 Jt - 800 Jt :</label>
								<div class="col-sm-5"> 
									<input type="text" class="form-control" id="asuransi4" name="asuransi4" value="<?php echo $no->asuransi4?>">
								</div>
							</div>
							<div class="form-group">
								<label class="control-label col-sm-2" for="asuransi5">Asuransi OTR > 800 Jt :</label>
								<div class="col-sm-5"> 
									<input type="text" class="form-control" id="asuransi5" name="asuransi5" value="<?php echo $no->asuransi5?>">
								</div>
							</div>
							
							<div class="form-group">
								<label class="control-label col-sm-2" for="provisi">Provisi:</label>
								<div class="col-sm-5"> 
									<select class="form-control" id="provisi" name="provisi">
										<option value="<?php echo $no->provisi?>"><?php echo $no->provisi?>%</option>
										<option value="1">1%</option>
										<option value="2">2%</option>
										<option value="3">3%</option>
										<option value="4">4%</option>
										<option value="5">5%</option>
										<option value="6">6%</option>
										<option value="7">7%</option>
										<option value="8">8%</option>
										<option value="9">9%</option>
										<option value="10">10%</option>
									</select>
								</div>
							</div>
							
							<div class="form-group">
								<label class="control-label col-sm-2" for="admin">Biaya Admin:</label>
								<div class="col-sm-5"> 
									<input type="text" class="form-control" id="admin" name="admin" value="<?php echo $no->admin?>">
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