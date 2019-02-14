<title>Form Pengalaman Organisasi</title>
	<section id="content" style="background-color:#ffffff;">
		<div class="container">
			<div class="col-sm-12 col-lg-12"><br><br>
				<h1 style="text-align:center;  font-family:Cooper Black;">Form Pengalaman Organisasi & Memimpin</h1><br><br>
				<!-- Slider -->
			</div>
		</div>
<?php if($cekDataOrganisasi==True){?>
		<br><br><div class="container">
			<div class="col-sm-12 col-lg-12">
				<h4 style="color:red; text-align:center;">Anda sudah mengisi data pengalaman organisasi & memimpin. Isian data organisasi & memimpin hanya diperbolehkan 1x!</h4>
			</div>
		</div><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
<?php }else{ ?>
		<div class="container">
			<div class="col-sm-12 col-lg-12">
				<form class="form-horizontal" enctype="multipart/form-data"  id="frm-mhs" method="post" action="<?php echo base_url().'career/simpanDataOrganisasi'?>">			
					<h4>Pengalaman Organisasi:</h4>
					<div class="col-sm-8">
						<input type="radio" name="org" id="org" onclick="org1()" value="1"> Ada &nbsp &nbsp &nbsp <input type="radio" id="org" name="org" onclick="org2()" value="2"> Tidak Ada 
					</div>	<br>
					<div class="table-responsive col-sm-12" id="pengalamanOrg" style="display:none;">
						<br><table class="table table-striped table-bordered table-hover" id="pengalamanOrganisasi">
							<thead>
								<tr>
									<td align="center"><b>Nama Organisasi (<font color="red">*</font>)</b></td>
									<td align="center"><b>Tahun (<font color="red">*</font>)</b></td>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="nmOrg[]" name="nmOrg[]">
										</div>		
									</td>
									<td>
										<div class="col-sm-12">
											<input type="text" class="form-control required" id="tahunOrg[]" name="tahunOrg[]">
										</div>
									</td>
								</tr> 
							</tbody>
						</table>
						<center><input type="button" value="Tambah Data" class="btn btn-default plusbtn4" /></center><br><br>
					</div>
			
					<br>	
					<h4>Pengalaman Memimpin:</h4>
					<div class="col-sm-8">
						<input type="radio" name="leader" id="leader" onclick="leader1()" value="1"> Ada &nbsp &nbsp &nbsp <input type="radio" id="leader" name="leader" onclick="leader2()" value="2"> Tidak Ada 
					</div>	<br><br>					
					<textarea id="pengalamanLeader" name="pengalamanLeader" style="display:none;" class="form-control required" rows="5"></textarea>
					<br><br><center><input onclick="return confirm('Apakah anda sudah yakin dengan data yang anda isi?');" type="submit" value="Simpan" class="btn btn-primary"></center>
				</form>
			</div>
		</div><br><br>
<?php } ?>		
	</section>
	
	<script type="text/javascript" src="http://code.jquery.com/jquery.min.js"></script>

	<script>
	
		//Ada & Tidak Ada
		function org1() {
			document.getElementById('pengalamanOrg').style.display = 'block';	
		}
	
		function org2() {
			document.getElementById('pengalamanOrg').style.display ='none';
		}
		
		//Tambah Baris
		$('.plusbtn4').click(function() {
			$("#pengalamanOrganisasi").append('<tr><td><div class="col-sm-12"><input type="text" class="form-control required" id="nmOrg[]" name="nmOrg[]"></div></td><td><div class="col-sm-12"><input type="text" class="form-control required" id="tahunOrg[]" name="tahunOrg[]"></div></td><td><input id="button1" type="button" class="btn btn-danger btnDelete4" value="Hapus" /></td></tr>');
		});
	
		//Hapus Baris
		$(document).ready(function(){
			$("#pengalamanOrganisasi").on('click','.btnDelete4',function(){
				$(this).closest('tr').remove();
			});
		});
		
		//Pengalaman Memimpin
	
		//Ada & Tidak Ada
		function leader1() {
			document.getElementById('pengalamanLeader').style.display = 'block';	
		}
		
		function leader2() {
			document.getElementById('pengalamanLeader').style.display ='none';
		}

	</script>	