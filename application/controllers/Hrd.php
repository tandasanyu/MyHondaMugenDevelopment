<?php
class Hrd extends CI_Controller{
   function __construct()
	{
		parent::__construct();
		$this->load->model('M_hrd');
		$this->is_logged_in(); //memanggil function is_logged_in
	}
   
	//fungsi untuk mengecek apakah session ada dan levelnya admin
	function is_logged_in()
	{
		$is_logged_in = $this->session->userdata('login');
		$level=$this->session->userdata('level');
		//jika session tidak ada atau levelnya bukan user maka akan menampilkan pesan error
		if(!isset($is_logged_in) ||  $is_logged_in != true || $level != 'hrd' )
		{
			echo 'You don\'t have permission to access this page. <a href="../backend">Login</a>';
			die();
		}
	}

	function index()
	{
		//$config['base_url'] = base_url("Hrd/");
		//$config['total_rows'] = $this->db->count_all('event');
		//$config['full_tag_open'] = '<div class="pagination">';
		//$config['full_tag_close'] = '</div>';
		//$config['cur_tag_open'] = '<a class="active">';
		//$config['cur_tag_close'] = '</a>';
		//$config['per_page'] = 20;
		//$config['num_links'] = 2;
		//$config['next_link'] = '>>';
		//$config['prev_link'] = '<<';
		//$offset=$this->uri->segment(3);
		$data = array('nama'=> $this->session->userdata('level'),
		              'cekLamaran'=> $this->M_hrd->cekLamaran(),
		              'pelamar'=> $this->M_hrd->lamaranMasuk());
		//$cekLamaran=$this->M_hrd->cekLamaran();
		//echo $cekLamaran; die();
		//$this->pagination->initialize($config);   
		$this->load->view('admin/header');
		$this->load->view('admin/v_menuhrd');
		$this->load->view('admin/hrd/v_beranda',$data);
		$this->load->view('admin/footer');
	}
	
	function lowongan()
	{
		$data['lowongan'] = $this->M_hrd->semualowongan();      
		//meload view bernama buku_view.php dengan data variable adalah $data
		$this->load->view('admin/header');
		$this->load->view('admin/v_menuhrd');
		$this->load->view('admin/hrd/v_lowongan',$data);
		$this->load->view('admin/footer');
	}		
			
	function form_lowongan()
	{
		$data['lowongan'] = $this->M_hrd->semualowongan();      
		//meload view bernama buku_view.php dengan data variable adalah $data
		$this->load->view('admin/header');
		$this->load->view('admin/v_menuhrd');
		$this->load->view('admin/hrd/v_form_lowongan');
		$this->load->view('admin/footer');
	}		
			
	function simpan_lowongan()
	{
		$this->M_hrd->simpanlowongan();
		echo ("<script language='JavaScript'>
				window.alert('Info Lowongan Kerja Berhasil Ditambah!')
				window.location.href='http://www.hondamugen.co.id/hondamugen/index.php/Hrd/lowongan/';
				</script>");
    }
	
	function hapus_lowongan($id_lowongan)
	{
		$this->M_hrd->hapuslowongan($id_lowongan);
		echo ("<script language='JavaScript'>
				window.alert('Info Lowongan Kerja Berhasil Dihapus!')
				window.location.href='http://www.hondamugen.co.id/index.php/Hrd/lowongan/';
				</script>");
	}
	
	function edit_status($id_lowongan,$status)
	{
		$this->M_hrd->editstatus($id_lowongan,$status);
		if($status==1){
			echo ("<script language='JavaScript'>
					window.alert('Info Lowongan Kerja Berhasil Tidak Ditampilkan!')
					window.location.href='http://www.hondamugen.co.id/index.php/Hrd/lowongan/';
					</script>");
		}else{
			echo ("<script language='JavaScript'>
					window.alert('Info Lowongan Kerja Berhasil Ditampilkan!')
					window.location.href='http://www.hondamugen.co.id/index.php/Hrd/lowongan/';
					</script>");
		}
	}
	
	function edit_lowongan($id_lowongan)
	{
		if($_POST==NULL)  {
        	$data['no'] = $this->M_hrd->pilihlowongan($id_lowongan);
			$this->load->view('admin/header');
			$this->load->view('admin/v_menuhrd');
            $this->load->view('admin/hrd/v_form_edit_lowongan',$data);
			$this->load->view('admin/footer');
        } else  {
            $this->M_hrd->editlowongan($id_lowongan);
			echo ("<script language='JavaScript'>
					window.alert('Info Lowongan Kerja Berhasil Diubah!')
					window.location.href='http://www.hondamugen.co.id/index.php/Hrd/lowongan/';
					</script>");
        }

	}
	
	function pelamar()
	{ 	
		//menampilkan pelamar semua posisi
		if ($this->input->post('posisi')==null){
		$config['base_url'] = base_url("Hrd/pelamar");
		$config['total_rows'] = $this->db->count_all('event');
		$config['full_tag_open'] = '<div class="pagination">';
		$config['full_tag_close'] = '</div>';
		$config['cur_tag_open'] = '<a class="active">';
		$config['cur_tag_close'] = '</a>';
		$config['per_page'] = 10;
		$config['num_links'] = 2;
		$config['next_link'] = '>>';
		$config['prev_link'] = '<<';
		$offset=$this->uri->segment(3);
		$data=array('posisi'=> $this->M_hrd->semuaLowongan(),
					'pelamar' => $this->M_hrd->infoPelamar($config['per_page'],$offset),
					'cekLamaran' => $this->M_hrd->cekLamaran2());  
		$this->pagination->initialize($config);    
		$this->load->view('admin/header');
		$this->load->view('admin/v_menuhrd');
		$this->load->view('admin/hrd/v_pelamar',$data);
		$this->load->view('admin/footer');
		}else{
		//melampirkan pelamar sesuai posisi
		$posisi=$this->input->post('posisi');
		$config['base_url'] = base_url("Hrd/pelamar");
		$config['total_rows'] = $this->db->count_all('event');
		$config['full_tag_open'] = '<div class="pagination">';
		$config['full_tag_close'] = '</div>';
		$config['cur_tag_open'] = '<a class="active">';
		$config['cur_tag_close'] = '</a>';
		$config['per_page'] = 10;
		$config['num_links'] = 2;
		$config['next_link'] = '>>';
		$config['prev_link'] = '<<';
		$offset=$this->uri->segment(3);
		$data=array('posisi'=> $this->M_hrd->semuaLowongan(),
					'pelamar' => $this->M_hrd->pelamarsesuaiposisi($config['per_page'],$offset,$posisi),
						'cekLamaran' => $this->M_hrd->cekLamaran3($posisi));  
		$this->load->view('admin/header');
		$this->load->view('admin/v_menuhrd');
		$this->load->view('admin/hrd/v_pelamar',$data);
		$this->load->view('admin/footer');
			
		}
	}	
	
	function undang_interview($noDaftar)
	{
		$data['pelamar'] = $this->M_hrd->pilihpelamar($noDaftar);      
		//meload view bernama buku_view.php dengan data variable adalah $data
		$this->load->view('admin/header');
		$this->load->view('admin/v_menuhrd');
		$this->load->view('admin/hrd/v_undang_interview',$data);
		$this->load->view('admin/footer');
	}	
	
		public function kirimundangan()
	{	
		$this->load->library('email');
		$email=$this->input->post('email');
		$id_lamaran=$this->input->post('id_lamaran');
		$this->M_hrd->ubahstatuslamaran($id_lamaran);
		$config['protocol'] = 'smtp';
		$config['smtp_host'] = 'ssl://mail.hondamugen.co.id';
		$config['smtp_port'] = '465';
		$config['smtp_timeout'] = '7';
		$config['smtp_user'] = 'komang@hondamugen.co.id';
		$config['smtp_pass'] = 'komang112';
		$config['charset'] = 'utf-8';
		$config['newline'] = "\r\n";
		$config['mailtype'] = 'html';
		$config['validation'] = TRUE;
		$this->email->initialize($config);
	
		$htmlContent= $this->input->post('pesan');
			
		$config['mailtype'] = 'html';
		$this->email->initialize($config);
		$this->email->to($email);
		$this->email->from('komanganom@gmail.com','Honda Mugen');
		$this->email->subject('Undangan Interview Honda Mugen');
		$this->email->message($htmlContent);
		if($this->email->send())
		{
				echo ("<script language='JavaScript'>
					window.alert('Email Pemberitahuan Berhasil Dikirim!')
					window.location.href='http://www.hondamugen.co.id/Hrd/pelamar/';
					</script>");
		}else
		{
			echo ("<script language='JavaScript'>
					window.alert('Email Pemberitahuan Gagal Dikirim!')
					window.location.href='http://www.hondamugen.co.id/Hrd/pelamar//';
					</script>");
		}
	}	

		public function cv($noDaftar)
	{
		//$anak=$noDaftar;
		//$this->M_hrd->cekNonFormal($noDaftar);
		//echo $anak; die();
		
		$data= array('cekDataDiri'=>$this->M_hrd->cekDataDiri2($noDaftar),
					 'cekFoto'=>$this->M_hrd->cekFoto2($noDaftar),
					 'dokumenFoto'=>$this->M_hrd->dokumenFoto($noDaftar),
					 'dataPelamar'=>$this->M_hrd->pilihpelamar($noDaftar),
					 'dataDiri'=>$this->M_hrd->dataDiri($noDaftar),
					 'dataKeluarga'=>$this->M_hrd->dataKeluarga($noDaftar),
					 'dataSaudara'=>$this->M_hrd->dataSaudara($noDaftar),
					 'cekStatusKawin'=>$this->M_hrd->cekStatusKawin($noDaftar),
					 'dataPasangan'=>$this->M_hrd->dataPasangan($noDaftar),
					 'cekAnak'=>$this->M_hrd->cekAnak($noDaftar),
					 'dataAnak'=>$this->M_hrd->dataAnak($noDaftar),
					 'dataPendidikanFormal'=>$this->M_hrd->dataPendidikanFormal($noDaftar),
					 'cekNonFormal'=>$this->M_hrd->cekNonFormal($noDaftar),
					 'dataPendidikanNonFormal'=>$this->M_hrd->dataPendidikanNonFormal($noDaftar),
					 'cekBahasa'=>$this->M_hrd->cekBahasa($noDaftar),
					 'dataKemampuanBahasa'=>$this->M_hrd->dataKemampuanBahasa($noDaftar),
					 'cekOrganisasi'=>$this->M_hrd->cekOrganisasi($noDaftar),
					 'dataOrganisasi'=>$this->M_hrd->dataOrganisasi($noDaftar),
					 'cekLeader'=>$this->M_hrd->cekLeader($noDaftar),
					 'cekPertanyaan'=>$this->M_hrd->cekPertanyaan($noDaftar),
					 'dataPengalamanMemimpin'=>$this->M_hrd->dataPengalamanMemimpin($noDaftar),
					 'cekKerja'=>$this->M_hrd->cekKerja($noDaftar),
					 'dataPekerjaan'=>$this->M_hrd->dataPekerjaan($noDaftar),
					 'dataReferensi'=>$this->M_hrd->dataReferensi($noDaftar),
					 'dataPertanyaan'=>$this->M_hrd->dataPertanyaan($noDaftar),
					 'dataLamaran'=>$this->M_hrd->dataLamaran($noDaftar),);
		$this->load->view('admin/hrd/v_cv',$data);
	}
	
	function tolak($noDaftar){
		$data=$this->M_hrd->lamaranMasuk2();
		$foto=$data->pathFoto;
		$ktp=$data->pathKtp;
		$ijazah=$data->pathIjazah;
		$surat=$data->pathSurat;
		$nilai=$data->pathNilai;
		if ($this->M_hrd->cekFoto2($noDaftar)==TRUE){
			unlink("lamaran/".$foto);
		}
		if ($this->M_hrd->cekKTP2($noDaftar)==TRUE){
			unlink("lamaran/".$ktp);
		}
		if ($this->M_hrd->cekIjazah2($noDaftar)==TRUE){
			unlink("lamaran/".$ijazah);
		}
		if ($this->M_hrd->cekSurat2($noDaftar)==TRUE){
			unlink("lamaran/".$surat);
		}
		if ($this->M_hrd->cekNilai2($noDaftar)==TRUE){
			unlink("lamaran/".$nilai);
		}
		if ($this->M_hrd->cekNPWP2($noDaftar)==TRUE){
			unlink("lamaran/".$nilai);
		}
		if ($this->M_hrd->cekKK2($noDaftar)==TRUE){
			unlink("lamaran/".$nilai);
		}
		if ($this->M_hrd->cekCV2($noDaftar)==TRUE){
			unlink("lamaran/".$nilai);
		}
		
		$this->M_hrd->lamaranDitolak($noDaftar);
		
		echo ("<script language='JavaScript'>
				window.alert('CV Telah Ditolak')
				window.location.href='http://www.hondamugen.co.id/hrd';
				</script>");
	}
	
	function terima($noDaftar){
		$this->M_hrd->lamaranDiterima($noDaftar);
		echo ("<script language='JavaScript'>
				window.alert('CV Akan Diproses')
				window.location.href='http://www.hondamugen.co.id/hrd';
				</script>");
	}
			
}
?>