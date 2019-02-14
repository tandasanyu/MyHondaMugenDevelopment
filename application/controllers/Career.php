<?php
class career extends CI_Controller{
  function __construct()
	{
		parent::__construct();
		$this->load->model('M_hrd');
		$this->load->library('upload');
		$this->is_logged_in(); //memanggil function is_logged_in
	}
   
	//fungsi untuk mengecek apakah session ada dan levelnya admin
	function is_logged_in()
	{
		$is_logged_in = $this->session->userdata('login');
		$level=$this->session->userdata('level');
		//jika session tidak ada atau levelnya bukan user maka akan menampilkan pesan error
		if(!isset($is_logged_in) ||  $is_logged_in != true )
		{
			echo 'You don\'t have permission to access this page. <a href="login">Login</a>';
			die();
		}
	}

	function index()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'posisi'=>$this->M_hrd->cekPosisi($username),
					'cekDataDiri'=>$this->M_hrd->cekDataDiri($username),
					'cekDataKeluarga'=>$this->M_hrd->cekDataKeluarga($username),
					'cekDataPendidikan'=>$this->M_hrd->cekDataPendidikan($username),
					'cekDataOrganisasi'=>$this->M_hrd->cekDataOrganisasi($username),
					'cekDataPekerjaan'=>$this->M_hrd->cekDataPekerjaan($username),
					'cekDataPertanyaan'=>$this->M_hrd->cekDataPertanyaan($username),
					'cekDataReferensi'=>$this->M_hrd->cekDataReferensi($username),
					'cekFoto'=>$this->M_hrd->cekFoto($username),
					'cekKTP'=>$this->M_hrd->cekKTP($username),
					'cekIjazah'=>$this->M_hrd->cekIjazah($username),
					'cekNilai'=>$this->M_hrd->cekNilai($username),
					'cekKK'=>$this->M_hrd->cekKK($username),
					'cekNPWP'=>$this->M_hrd->cekNPWP($username),
					'cekCV'=>$this->M_hrd->cekCV($username),
					'cekSurat'=>$this->M_hrd->cekSurat($username));
	
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/dokumen_lamaran',$data);
		$this->load->view('user/karir/footerCareer');
	}
	
	//Fungsi untuk menampilkan halaman profil
	public function formDataDiri()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekDataDiri'=>$this->M_hrd->cekDataDiri($username));
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_datadiri',$data);
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanDataDiri()
	{
		$username = $this->session->userdata('user');
		$cekDataDiri=$this->M_hrd->cekDataDiri($username);
		if ($cekDataDiri==TRUE){
			echo "<script>alert('Anda hanya diperbolehkan mengisi data diri 1x!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
		}
		else{
			$this->M_hrd->simpanDataDiri($username);
				echo "<script>alert('Data Diri anda sudah disimpan!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
		}
	}
	
	public function formDataKeluarga()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekDataKeluarga'=>$this->M_hrd->cekDataKeluarga($username));
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_keluarga',$data);
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanDataKeluarga()
	{
		$username = $this->session->userdata('user');
		$cekDataKeluarga=$this->M_hrd->cekDataKeluarga($username);
		if ($cekDataKeluarga==TRUE){
			echo "<script>alert('Anda hanya diperbolehkan mengisi data keluarga 1x!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
		}
		else{
			$this->M_hrd->simpanDataKeluarga($username);
			echo "<script>alert('Data Keluarga anda sudah disimpan!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
		}
	}
	
	public function formDataPendidikan()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekDataPendidikan'=>$this->M_hrd->cekDataPendidikan($username));
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_pendidikan');
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanDataPendidikan()
	{	
		$username = $this->session->userdata('user');
		$cekDataPendidikan=$this->M_hrd->cekDataPendidikan($username);
		if ($cekDataPendidikan==TRUE){
			echo "<script>alert('Anda hanya diperbolehkan mengisi data pendidikan 1x!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
		}
		else{
			$this->M_hrd->simpanDataPendidikan($username);
			echo "<script>alert('Data Pendidikan anda sudah disimpan!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
		}
	}
	
	public function formDataOrganisasi()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekDataOrganisasi'=>$this->M_hrd->cekDataOrganisasi($username));
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_organisasi');
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanDataOrganisasi()
	{
		$username = $this->session->userdata('user');
		$cekDataOrganisasi=$this->M_hrd->cekDataOrganisasi($username);
		if ($cekDataOrganisasi==TRUE){
			echo "<script>alert('Anda hanya diperbolehkan mengisi data organisasi 1x!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
		}
		else{
			$this->M_hrd->simpanDataOrganisasi($username);
			echo "<script>alert('Data Organisasi anda sudah disimpan!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
		}
	}
	
	public function formDataPekerjaan()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekDataPekerjaan'=>$this->M_hrd->cekDataPekerjaan($username),
					'cekDataReferensi'=>$this->M_hrd->cekDataReferensi($username),);
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_pekerjaan');
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanDataPekerjaan()
	{
		$username = $this->session->userdata('user');
		$cekDataPekerjaan=$this->M_hrd->cekDataPekerjaan($username);

		if ($cekDataPekerjaan==TRUE){
			echo "<script>alert('Anda hanya diperbolehkan mengisi data pekerjaan 1x!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
		}
		else{
			$this->M_hrd->simpanDataPekerjaan($username);
			echo "<script>alert('Data Pekerjaan anda berhasil disimpan!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
		}
	}
	
	public function formDataPertanyaan()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekDataPertanyaan'=>$this->M_hrd->cekDataPertanyaan($username));
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_pertanyaan');
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanDataPertanyaan()
	{
		$username = $this->session->userdata('user');
		$cekDataPertanyaan=$this->M_hrd->cekDataPertanyaan($username);
		if ($cekDataPertanyaan==TRUE){
			echo "<script>alert('Anda hanya diperbolehkan mengisi jawaban pertanyaan 1x!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
		}
		else{
			$this->M_hrd->simpanDataPertanyaan($username);
			echo "<script>alert('Jawaban Pertanyaan anda sudah disimpan!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
		}
	}
	
	public function formFoto()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekFoto'=>$this->M_hrd->cekFoto($username));
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_foto');
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanFoto()
	{
		$this->upload->initialize($this->setup_upload_option());
        if($this->upload->do_upload() == false){
            echo "<script>
	                alert('Gagal Menyimpan');
	            </script>";
	    } else {
	        $image 	= $this->upload->data();
	        $upload = $image['file_name'];	                    
			$username = $this->session->userdata('user');
			$cekFoto=$this->M_hrd->cekFoto($username);
			if ($cekFoto==TRUE){
				echo "<script>alert('Anda hanya diperbolehkan mengunggah Foto 1x!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
			}
			else{
				$this->M_hrd->simpanFoto($upload, $username);
				echo "<script>alert('Dokumen foto anda berhasil disimpan!');
					window.location=('http://www.hondamugen.co.id/daftar');
				</script>"; 
			}
		}
	}		
	
	public function formKTP()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekKTP'=>$this->M_hrd->cekKTP($username));
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_ktp');
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanKTP()
	{
		$this->upload->initialize($this->setup_upload_option());
        if($this->upload->do_upload() == false){
            echo "<script>
	                alert('Gagal Menyimpan');
	            </script>";
	    } else {
	        $image 	= $this->upload->data();
	        $upload = $image['file_name'];	                    
			$username = $this->session->userdata('user');
			$cekKTP=$this->M_hrd->cekKTP($username);
			if ($cekKTP==TRUE){
				echo "<script>alert('Anda hanya diperbolehkan mengunggah KTP 1x!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
			}
			else{				
				$this->M_hrd->simpanKTP($upload, $username);
				echo "<script>alert('Dokumen KTP berhasil disimpan!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
			}
		}
	}
	
	public function formIjazah()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekIjazah'=>$this->M_hrd->cekIjazah($username));
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_ijazah');
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanIjazah()
	{
		$this->upload->initialize($this->setup_upload_option());
        if($this->upload->do_upload() == false){
            echo "<script>
	                alert('Gagal Menyimpan');
	            </script>";
	    } else {
	        $image 	= $this->upload->data();
	        $upload = $image['file_name'];	                    
			$username = $this->session->userdata('user');
			$cekIjazah=$this->M_hrd->cekIjazah($username);
			if ($cekIjazah==TRUE){
				echo "<script>alert('Anda hanya diperbolehkan mengunggah Ijazah 1x!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
			}
			else{
				$this->M_hrd->simpanIjazah($upload, $username);
				echo "<script>alert('Dokumen Ijazah anda berhasil disimpan!');
					window.location=('http://www.hondamugen.co.id/daftar');
				</script>"; 
			}
		}
	}
	
	public function formNilai()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekNilai'=>$this->M_hrd->cekNilai($username));
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_nilai');
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanNilai()
	{
		$this->upload->initialize($this->setup_upload_option());
        if($this->upload->do_upload() == false){
            echo "<script>
	                alert('Gagal Menyimpan');
	            </script>";
	    } else {
	        $image 	= $this->upload->data();
	        $upload = $image['file_name'];	                    
			$username = $this->session->userdata('user');
			$cekNilai=$this->M_hrd->cekNilai($username);
			if ($cekNilai==TRUE){
				echo "<script>alert('Anda hanya diperbolehkan mengunggah rangkuman nilai 1x!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
			}
			else{
				$this->M_hrd->simpanNilai($upload, $username);
				echo "<script>alert('Dokumen Rangkuman Nilai anda berhasil disimpan!');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
			}
		}
	}
	
	public function formSurat()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekSurat'=>$this->M_hrd->cekSurat($username));
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_surat');
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanSurat()
	{
		$this->upload->initialize($this->setup_upload_option());
        if($this->upload->do_upload() == false){
            echo "<script>
	                alert('Gagal Menyimpan');
	            </script>";
	    } else {
	        $image 	= $this->upload->data();
	        $upload = $image['file_name'];	                    
			$username = $this->session->userdata('user');
			$cekSurat=$this->M_hrd->cekSurat($username);
			if ($cekSurat==TRUE){
				echo "<script>alert('Anda hanya diperbolehkan mengunggah surat lamaran 1x!');
						window.location=('http://www.hondamugen.co.id/career');
					</script>"; 
			}
			else{
				$this->M_hrd->simpanSurat($upload, $username);
				echo "<script>alert('Dokumen surat lamaran berhasil disimpan! ');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
			}
		}
	}
	
	public function formNPWP()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekNPWP'=>$this->M_hrd->cekNPWP($username));
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_npwp');
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanNPWP()
	{
		$this->upload->initialize($this->setup_upload_option());
        if($this->upload->do_upload() == false){
            echo "<script>
	                alert('Gagal Menyimpan');
	            </script>";
	    } else {
	        $image 	= $this->upload->data();
	        $upload = $image['file_name'];	                    
			$username = $this->session->userdata('user');
			$cekNPWP=$this->M_hrd->cekNPWP($username);
			if ($cekNPWP==TRUE){
				echo "<script>alert('Anda hanya diperbolehkan mengunggah NPWP 1x!');
						window.location=('http://www.hondamugen.co.id/career');
					</script>"; 
			}
			else{
				$this->M_hrd->simpanNPWP($upload, $username);
				echo "<script>alert('NPWP berhasil disimpan! ');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
			}
		}
	}
	
	public function formCV()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekCV'=>$this->M_hrd->cekCV($username));
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_cv');
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanCV()
	{
		$this->upload->initialize($this->setup_upload_option());
        if($this->upload->do_upload() == false){
            echo "<script>
	                alert('Gagal Menyimpan');
	            </script>";
	    } else {
	        $image 	= $this->upload->data();
	        $upload = $image['file_name'];	                    
			$username = $this->session->userdata('user');
			$cekCV=$this->M_hrd->cekCV($username);
			if ($cekCV==TRUE){
				echo "<script>alert('Anda hanya diperbolehkan mengunggah CV 1x!');
						window.location=('http://www.hondamugen.co.id/career');
					</script>"; 
			}
			else{
				$this->M_hrd->simpanCV($upload, $username);
				echo "<script>alert('CV berhasil disimpan! ');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
			}
		}
	}
	
	public function formKK()
	{
		$username = $this->session->userdata('user');
		$data=array('username' => $this->session->userdata('user'),
					'cekKK'=>$this->M_hrd->cekKK($username));
		$this->load->view('user/karir/headerCareer',$data);
		$this->load->view('user/karir/form_kk');
		$this->load->view('user/karir/footerCareer');
	}
	
	public function simpanKK()
	{
		$this->upload->initialize($this->setup_upload_option());
        if($this->upload->do_upload() == false){
            echo "<script>
	                alert('Gagal Menyimpan');
	            </script>";
	    } else {
	        $image 	= $this->upload->data();
	        $upload = $image['file_name'];	                    
			$username = $this->session->userdata('user');
			$cekKK=$this->M_hrd->cekKK($username);
			if ($cekKK==TRUE){
				echo "<script>alert('Anda hanya diperbolehkan mengunggah Kartu Keluarga 1x!');
						window.location=('http://www.hondamugen.co.id/career');
					</script>"; 
			}
			else{
				$this->M_hrd->simpanKK($upload, $username);
				echo "<script>alert('Kartu Keluarga berhasil disimpan! ');
						window.location=('http://www.hondamugen.co.id/daftar');
					</script>"; 
			}
		}
	}
	
	public function kirimLamaran()
	{
		$username = $this->session->userdata('user');
		$cekposisi = $this->M_hrd->cekPosisi($username);
		$posisi = $cekposisi->posisi;	
		$noacak=(rand(1000,9999));
		$noDaftar = 'DFT'.date('dmy').$noacak;
		//tambah logic untuk cek nodaftar *******************************************************************************
		$noacak_e = $this->M_hrd->cekNoDaftar($noDaftar);
		if ($noacak_e==TRUE){
			$this->M_hrd->simpanDataLamaran($noDaftar,$posisi);//insert posisi, tgl lamar, no daftar di data_lamaran
			$this->M_hrd->ubahDataLamaran($username,$noDaftar);// PROSES SET USERNAME ='' DAN INSERT NO DAFTAR di semua table
			$this->M_hrd->hapusAkun($username);//hapus akun username yg bersangkutan di temp_akun
			$this->session->sess_destroy();
			$this->session->unset_userdata('login');
			//$this->load->library('email');
				//	$email=$this->input->post('email');
				//	$config['protocol'] = 'smtp';
				//	$config['smtp_host'] = 'ssl://mail.hondamugen.co.id';
				//	$config['smtp_port'] = '587';
				//	$config['smtp_timeout'] = '7';
				//	$config['smtp_user'] = 'komang@hondamugen.co.id';
				//	$config['smtp_pass'] = 'komang112';
				//	$config['charset'] = 'utf-8';
				//	$config['newline'] = "\r\n";
				//	$config['mailtype'] = 'html';
				//	$config['validation'] = TRUE;
				//	$this->email->initialize($config);
				
				//	$htmlContent= 'Ada lamaran baru, <a href="https://www.hondamugen.co.id/backend">mohon ditinjau</a> <br><br><br>
				//				   Terima kasih';
						
				//	$config['mailtype'] = 'html';
				//		$this->email->initialize($config);
				//	$this->email->to('hrd.recruitmentmugen@gmail.com');
				//	$this->email->from('komang@hondamugen.co.id','Honda Mugen');
				//	$this->email->subject('Lamaran Baru');
				//	$this->email->message($htmlContent);
				//	$this->email->send();
				
					echo ("<script language='JavaScript'>
					window.alert('Terimakasih, lamaran anda akan segera kami proses!')
					window.location.href='http://hondamugen.co.id/karir/';
					</script>");			
		}
		else{
				echo "<script>alert('Gagal Menyimpan Data! ');
						window.location.href='http://hondamugen.co.id/karir/';
					</script>"; 				
		}

	}
	
	private function setup_upload_option(){
        $config = array();
        $config['upload_path']      = './lamaran';
        $config['allowed_types']    = 'jpg|png|jpeg|pdf';
        $config['overwrite']        = 'False';
        $config['max_size']         = '2048';
        return $config;
   	}
}
?>