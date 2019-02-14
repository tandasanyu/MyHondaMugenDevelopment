<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"><!-- Optional theme --><link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css"><!-- Latest compiled and minified JavaScript -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.11.3/jquery.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>



	<div class="container">
			<div class="col-sm-12 col-lg-12">
				<h2 style="color:#e01425">Simulasi Perhitungan Kredit</h2>
				<div class="col-lg-12"><br>
				<form action="<?php echo base_url().'welcome/coba'?>" method="post">
					<table align="center">
						<tr>
							<td><label class="control-label" for="tipe">Tipe Mobil:</td> 
							<td>
								<div class="col-lg-12">
									<select class="form-control" name="tipe">
										<option value="none">-Pilih Tipe Mobil-</option>
										<option value="Honda Accord 2.4 VTi-L ES AT">Honda Accord 2.4 VTi-L ES AT</option>
									</select>
								</div>
							</td>	
							<td><label class="control-label" for="tenor">Tenor:</td>
							<td>
								<div class="col-lg-12">
									<select  class="form-control col-sm-3" name="tenor">
										<option value="none">-Pilih Tenor-</option>
										<option name="12">12</option>
										<option name="24">24</option>
										<option name="36">36</option>
										<option name="48">48</option>
										<option name="60">60</option>
									</select>
								</div>
							</td>
							<td><input type="submit" id="Submit" class="btn btn-primary"></td> 
						</tr>
					</table>	
				</form>	
				</div>
			<?php if($tipe==null && $tenor==null){
			echo ""; }else{?>
			
		<script>
<!-- mulai coding modal -->
  $(window).load(function(){        
   $('#myModal').modal('show');
    }); 
</script>
<div class="modal fade bs-example-modal-lg" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
	<table align="center">
									<tr>
										<td><b>Tipe</b></td>
										<td>&nbsp :</td>
										<td>&nbsp <?php echo $kredit->tipe?></td>
									</tr>
									<tr>
										<td><b>Tenor</b></td>
										<td>&nbsp :</td>
										<td>&nbsp <?php echo $kredit->tenor?> Bulan</td>
									</tr>
									<tr>
										<td><b>Harga</b></td>
										<td>&nbsp :</td>
										<td>&nbsp <?php  echo  "Rp " . number_format($kredit->harga,2,',','.');?></td>
									</tr>
									<tr>
										<td><b>DP</b></td>
										<td>&nbsp :</td>
										<td>&nbsp <?php echo "Rp " . number_format($kredit->dp,2,',','.');?></td>
									</tr>					
									<tr>
										<td><b>Angsuran</b></td>
										<td>&nbsp :</td>
										<td>&nbsp <?php echo "Rp " . number_format($kredit->angsuran,2,',','.')." /bulan";?></td>
									</tr>
								</table>
								<p style="font-size:14px;"><b>Keterangan:</b></p>
								<p style="font-size:10px;">Harga yang digunakan adalah On The Road Jakarta.<br>
									Simulasi perhitungan kredit berdasarkan rate Mega Auto Finance periode Februari 2017 dengan kondisi Asuransi AllRisk.<br>
									Simulasi perhitungan kredit ini tidak mengikat dan dapat berubah sewaktu-waktu tanpa pemberitahuan.<br>
									Simulasi perhitungan kredit ini berupa asumsi dan untuk perhitungan riil silahkan menghubungi dealer terdekat.
								</p>	
	</div>
    <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
  </div>
  
</div>
			  
			<?php }?>
				
			</div>
		</div>


