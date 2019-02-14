	</div>
	<div style="background-color: #bdbdbd; ">
			<br><p align="center">
			Copyright © 2017 Honda Mugen    <br>
			V.1.2017 Powered by IT Department</p><br>
			</div>
<style>
	.my-error-class {
		color:#FF0000;  /* red */
	}

	.my-valid-class {
		color:#000000; /* black */
	}
</style>	
	  <!-- jQuery -->
    <script src="<?php echo base_url().'plugin/vendor/jquery/jquery.min.js'?>"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="<?php echo base_url().'plugin/vendor/bootstrap/js/bootstrap.min.js'?>"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="<?php echo base_url().'plugin/vendor/metisMenu/metisMenu.min.js'?>"></script>

    <!-- Custom Theme JavaScript -->
    <script src="<?php echo base_url().'plugin/dist/js/sb-admin-2.js'?>"></script>
	
	<script type="text/javascript" src="<?php echo base_url().'pluginuser/js/jquery.validate.min.js'?>"></script>
	
	<script type="text/javascript">
	$(document).ready(function() {
		$('#frm-mhs').validate({
			errorClass: "my-error-class",
			validClass: "my-valid-class",
			rules: {
				
				nama: {
					accept: "[a-zA-Z]+"
				},
				
				panggilan: {
					accept: "[a-zA-Z]+"
				},
				
				tempatLahir: {
					accept: "[a-zA-Z]+"
				},
				
				hp: {
					digits: true,
					minlength:10,
					maxlength:13
				}, 
				
				telp: {
					digits: true,
					minlength:7,
					maxlength:13
				}, 
				
				bca: {
					digits: true,
					minlength:10,
					maxlength:10
				}, 
				
				jamsostek: {
					digits: true,
					minlength:16,
					maxlength:16
				},
				
				ktp: {
					digits: true,
					minlength:16,
					maxlength:16
				},
				
				npwp: {
					digits: true,
					minlength:16,
					maxlength:16
				},
				
				sim: {
					digits: true,
					minlength:12,
					maxlength:12
				},
				
				email: {
					email: true
				},
				
				nmAyah: {
					accept: "[a-zA-Z]+"
				},
				
				usiaAyah: {
					digits: true,
					minlength:2,
					maxlength:3
				},
				
				nmIbu: {
					accept: "[a-zA-Z]+"
				},
				
				usiaIbu: {
					digits: true,
					minlength:2,
					maxlength:3
				},
				
				"nmSaudara[]": {
					accept: "[a-zA-Z]+"
				},
				
				"usiaSaudara[]": {
					digits: true,
					minlength:1,
					maxlength:2
				},
				
				nmPasangan: {
					accept: "[a-zA-Z]+"
				},
				
				usiaPasangan: {
					digits: true,
					minlength:2,
					maxlength:3
				},
				
				"nmAnak[]": {
					accept: "[a-zA-Z]+"
				},
				
				"usiaAnak[]": {
					digits: true,
					minlength:2,
					maxlength:3
				},
				
				"nmInstansi[]": {
					maxlength:50
				},
				
				"kotaInstansi[]": {
					accept: "[a-zA-Z]+",
					maxlength:50
				},
				
				"thnMasuk[]": {
					digits: true,
					minlength:4,
					maxlength:4
				},
				
				"thnKeluar[]": {
					digits: true,
					minlength:4,
					maxlength:4
				},
				
				"jurusan[]": {
					accept: "[a-zA-Z]+"
				},
				
				"nmInstansiNon[]": {
					maxlength:50
				},
				
				"tahunNon[]": {
					digits: true,
					minlength:4,
					maxlength:4
				},
				
				"jnsBahasa[]": {
					accept: "[a-zA-Z]+",
					maxlength:50
				},
				
				"nmOrg[]": {
					maxlength:50
				},
				
				"tahunOrg[]": {
					digits: true,
					minlength:4,
					maxlength:4
				},
				
				"nmPerusahaan[]": {
					maxlength:50
				},
				
				"telpPerusahaan[]": {
					digits: true,
					minlength:7,
					maxlength:13
				}, 
				
				"jabatan[]": {
					accept: "[a-zA-Z]+",
					maxlength:50
				},
				
				"nmAtasan[]": {
					accept: "[a-zA-Z]+",
					maxlength:50
				},
				
				"tugas[]": {
					maxlength:50
				},
				
				"gAwal[]": {
					digits: true,
					minlength:6,
					maxlength:12
				},
				
				"gAkhir[]": {
					digits: true,
					minlength:6,
					maxlength:12
				},
				
				"nmReferensi[]": {
					accept: "[a-zA-Z]+",
					maxlength:50
				},
				
				"telpReferensi[]": {
					digits: true,
					minlength:7,
					maxlength:13
				},
				
				"hubunganReferensi[]": {
					accept: "[a-zA-Z]+",
					maxlength:50
				}
			},
			messages: {
				nama: {
					required: "Nama Lengkap harus diisi",
					accept: "Format Nama harus berupa karakter"
				},
					
				panggilan: {
					required: "Nama Panggilan harus diisi",
					accept: "Format Nama Panggilan harus berupa karakter"
				},
				
				tempatLahir: {
					required: "Tempat lahir harus diisi",
					accept: "Format Tempat lahir harus berupa karakter"
				},
				
				hp: {
					required: "No HP harus diisi",
					digits:"Format No Hp harus berupa angka",
					minlength: "Minimal No Hp 10 digit",
					maxlength: "No Hp melebihi digit maksimal"
				},
				
				ktp: {
					required: "No KTP harus diisi",
					digits:"Format No KTP harus berupa angka",
					minlength: "No KTP tidak memenuhi format",
					maxlength: "No KTP tidak memenuhi format"
				},
				
				sim: {
					required: "No SIM Wajib Diisi",
					digits:"Format No SIM harus berupa angka",
					minlength: "No SIM tidak memenuhi format",
					maxlength: "No SIM tidak memenuhi format"
				},
				
				bca: {
					digits:"Format Rekening BCA harus berupa angka",
					minlength: "Format Rekening BCA kurang dari digit minimal",
					maxlength: "Format Rekening BCA melebihi digit maksimal"
				},
				npwp: {
					digits:"Format NPWP harus berupa angka",
					minlength: "Format NPWP kurang dari digit minimal",
					maxlength: "Format NPWP melebihi digit maksimal"
				},
				bca: {
					digits:"Format Rekening BCA harus berupa angka",
					minlength: "Format Rekening BCA kurang dari digit minimal",
					maxlength: "Format Rekening BCA melebihi digit maksimal"
				},
				
				jamsostek: {
					digits:"Format Jamsostek harus berupa angka",
					minlength: "Format Jamsostek kurang dari digit minimal",
					maxlength: "Format Jamsostek melebihi digit maksimal"
				},
				
				telp: {
					required: "No Telp harus diisi",
					digits:"Format No Telp harus berupa angka",
					minlength: "Minimal No Telp 10 digit",
					maxlength: "No Telp melebihi digit maksimal"
				},
					
				email: {
					required: "Email harus diisi",
					email: "Format email tidak valid"
				},
					
				alamat: {
					required: "Alamat harus diisi"
				},
				
				alamatKtp: {
					required: "Alamat harus diisi"
				},
					
				tgl: {
					required: "Pilih tanggal kunjungan"
				},
				
				nmAyah: {
					required: "Nama Ayah harus diisi",
					accept: "Format Nama Ayah harus berupa karakter"
				},
				
				usiaAyah: {
					required: "Usia Ayah harus diisi",
					digits:"Format Usia Ayah harus berupa angka",
					minlength: "Minimal 2 digit",
					maxlength: "Maksimal 3 digit"
				},
				
				nmIbu: {
					required: "Nama Ibu harus diisi",
					accept: "Format Nama Ibu harus berupa karakter"
				},
				
				usiaIbu: {
					required: "Usia Ibu harus diisi",
					digits:"Format Usia Ibu harus berupa angka",
					minlength: "Minimal 2 digit",
					maxlength: "Maksimal 3 digit"
				},
				
				"nmSaudara[]": {
					required: "Nama Saudara harus diisi",
					accept: "Format Nama Saudara harus berupa karakter"
				},
				
				"usiaSaudara[]": {
					required: "Usia Saudara harus diisi",
					digits:"Format Usia Saudara harus berupa angka",
					minlength: "Minimal 2 digit",
					maxlength: "Maksimal 3 digit"
				},
				
				nmPasangan: {
					required: "Nama Pasangan harus diisi",
					accept: "Format Nama Pasangan harus berupa karakter"
				},
				
				usiaPasangan: {
					required: "Usia Pasangan harus diisi",
					digits:"Format Usia Pasangan harus berupa angka",
					minlength: "Minimal 2 digit",
					maxlength: "Maksimal 3 digit"
				},
				
				"nmAnak[]": {
					required: "Nama Anak harus diisi",
					accept: "Format Nama Anak harus berupa karakter"
				},
				
				"usiaAnak[]": {
					required: "Usia Anak harus diisi",
					digits:"Format Usia Anak harus berupa angka",
					minlength: "Minimal 2 digit",
					maxlength: "Maksimal 3 digit"
				},
				
				"nmInstansi[]": {
					required: "Nama Instansi harus diisi",
					maxlength:"Maksimal 50 karakter"
				},
				
				"kotaInstansi[]": {
					required: "Kota Instansi harus diisi",
					accept: "Format kota Instansi harus berupa karakter",
					maxlength:"Maksimal 50 karakter"
				},
				
				"thnMasuk[]": {
					required: "Tahun masuk harus diisi",
					digits:"Format tahun masuk harus berupa angka",
					minlength: "Minimal 4 digit",
					maxlength: "Maksimal 4 digit"
				},
				
				"thnKeluar[]": {
					required: "Tahun keluar harus diisi",
					digits:"Format tahun keluar harus berupa angka",
					minlength: "Minimal 4 digit",
					maxlength: "Maksimal 4 digit"
				},
				
				"jurusan[]": {
					accept: "Format jurusan harus berupa karakter"
				},
				
				"nmInstansiNon[]": {
					required: "Nama Instansi Non Formal harus diisi",
					maxlength:"Maksimal 50 karakter"
				},
				
				"tahunNon[]": {
					required: "Tahun harus diisi",
					digits:"Format tahun harus berupa angka",
					minlength: "Minimal 4 digit",
					maxlength: "Maksimal 4 digit"
				},
				
				"jnsBahasa[]": {
					required: "Jenis bahasa harus diisi",
					accept: "Format jenis bahasa harus berupa karakter",
					maxlength:"Maksimal 50 karakter"
				},
				
				"nmOrg[]": {
					required: "Nama Organisasi harus diisi",
					maxlength:"Maksimal 50 karakter"
				},
				
				"tahunOrg[]": {
					required: "Tahun harus diisi",
					digits:"Format tahun harus berupa angka",
					minlength: "Minimal 4 digit",
					maxlength: "Maksimal 4 digit"
				},
				
				"nmPerusahaan[]": {
					required: "Nama Perusahaan Wajib diisi",
					maxlength: "Maksimal 50 karakter"
				},
				
				"alamatPerusahaan[]": {
					required: "Alamat Perusahaan Wajib diisi"
				},
				
				"telpPerusahaan[]": {
					digits:"Format telepon harus berupa angka",
					minlength: "Minimal 7 digit",
					maxlength: "Maksimal 13 digit"
				}, 
				
				"jabatan[]": {
					required: "Jabatan harus diisi",
					accept: "Format jabatan harus berupa karakter",
					maxlength:"Maksimal 50 karakter"
				},
				
				"nmAtasan[]": {
					required: "Nama atasan harus diisi",
					accept: "Format Nama atasan harus berupa karakter",
					maxlength:"Maksimal 50 karakter"
				},
				
				"tugas[]": {
					required: "Tugas harus diisi",
					maxlength:"Maksimal 50 karakter"
				},
				
				"gAwal[]": {
					digits:"Format Gaji Awal harus berupa angka",
					minlength: "Minimal 6 digit",
					maxlength: "Maksimal 12 digit"
				},
				
				"gAkhir[]": {
					digits:"Format Gaji Akhir harus berupa angka",
					minlength: "Minimal 6 digit",
					maxlength: "Maksimal 12 digit"
				},
				
				"alasanKeluar[]": {
					required: "Alasan Keluar harus diisi"
				},
				
				"nmReferensi[]": {
					required: "Nama referensi harus diisi",
					accept: "Format Nama referensi harus berupa karakter",
					maxlength:"Maksimal 50 karakter"
				},
				
				"alamatReferensi[]": {
					required: "Alamat Referensi Wajib diisi"
				},
				
				"telpReferensi[]": {
					required: "No Telp Referensi Wajib diisi",
					digits:"Format telepon referensi harus berupa angka",
					minlength: "Minimal 7 digit",
					maxlength: "Maksimal 13 digit"
				},
				
				"hubunganReferensi[]": {
					required: "Hubungan referensi harus diisi",
					accept: "Format hubungan referensi harus berupa karakter",
					maxlength:"Maksimal 50 karakter"
				}
			}
		});
	});
		
	$.validator.addMethod(
		"indonesianDate",
		function(value, element) {
			// put your own logic here, this is just a (crappy) example
			return value.match(/^\d\d?\/\d\d?\/\d\d\d\d$/);
		},
		"Please enter a date in the format DD/MM/YYYY"
	);	
</script>

<!--Date Picker-->
<script>
  $(function() {
    $( "#datepicker" ).datepicker({
	  changeMonth: true,
        changeYear: true,
		dateFormat: "dd-mm-yy",
		//minDate:0,
		yearRange: 'c-50:c+10',
		todayHighlight: true
		});
  });
</script>


<link rel="stylesheet" href="<?php echo base_url().'plugin/css/jquery-ui.css'?>" type="text/css"/>
<script src="<?php echo base_url().'plugin/js/jquery-ui.js'?>" type="text/javascript"></script>

</body>
</html>