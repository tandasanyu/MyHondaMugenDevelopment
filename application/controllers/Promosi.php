<?php
class Promosi extends CI_Controller{
   function __construct()
	{
		parent::__construct();
		$this->load->model('M_promosi');
		$this->load->library('upload');
		$this->is_logged_in(); //memanggil function is_logged_in
		
	}
   
	//fungsi untuk mengecek apakah session ada dan levelnya admin
	function is_logged_in()
	{
		$is_logged_in = $this->session->userdata('login');
		$level=$this->session->userdata('level');
		//jika session tidak ada atau levelnya bukan user maka akan menampilkan pesan error
		if(!isset($is_logged_in) ||  $is_logged_in != true || $level != 'promosi' )
		{
			$this->load->view('admin/notfound');
			die();
		}
	}

	function index()
	{
		$data['nama'] = $this->session->userdata('level');
		$this->load->view('admin/header');
		$this->load->view('admin/v_menupromosi');
		$this->load->view('admin/promosi/v_beranda',$data);
		$this->load->view('admin/footer');
	}
	
	function booking_pud()
	{
		$data['booking'] = $this->M_promosi->semuabookingpud();    
		$this->load->view('admin/header');
		$this->load->view('admin/v_menupromosi');
		$this->load->view('admin/promosi/v_bookingpud',$data);
		$this->load->view('admin/footer');
	}	
	
	function event()
	{
		$config['base_url'] = base_url("Promosi/event");
		$config['total_rows'] = $this->db->count_all('event');
		$config['full_tag_open'] = '<div class="pagination">';
		$config['full_tag_close'] = '</div>';
		$config['cur_tag_open'] = '<a class="active">';
		$config['cur_tag_close'] = '</a>';
		$config['per_page'] = 3;
		$config['num_links'] = 2;
		$config['next_link'] = '>>';
		$config['prev_link'] = '<<';
		$offset=$this->uri->segment(3);
		$data['event'] = $this->M_promosi->semuaevent($config['per_page'],$offset);
		$this->pagination->initialize($config);          
		//meload view bernama buku_view.php dengan data variable adalah $data
		$this->load->view('admin/header');
		$this->load->view('admin/v_menupromosi');
		$this->load->view('admin/promosi/v_event',$data);
		$this->load->view('admin/footer');
	}		
			
	function form_event()
	{ 
		//meload view bernama buku_view.php dengan data variable adalah $data
		$this->load->view('admin/header');
		$this->load->view('admin/v_menupromosi');
		$this->load->view('admin/promosi/v_form_event');
		$this->load->view('admin/footer');
	}		
			
	function simpan_event()
	{
		$this->M_promosi->simpanevent();
		echo ("<script language='JavaScript'>
				window.alert('Event Berhasil Ditambah!')
				window.location.href='http://www.hondamugen.co.id/index.php/promosi/event';
				</script>");
    }
	
	function hapus_event($id_event)
	{
		$this->M_promosi->hapusevent($id_event);
		echo ("<script language='JavaScript'>
				window.alert('Event Berhasil Dihapus!')
				window.location.href='http://www.hondamugen.co.id/index.php/promosi/event';
				</script>");
	}
	
	function edit_event($id_event)
	{
		if($_POST==NULL)  {
        	$data['no'] = $this->M_promosi->pilihevent($id_event);
			$this->load->view('admin/header');
			$this->load->view('admin/v_menupromosi');
            $this->load->view('admin/promosi/v_form_edit_event',$data);
			$this->load->view('admin/footer');
        } else  {
            $this->M_promosi->editevent($id_event);
			echo ("<script language='JavaScript'>
					window.alert('Event Berhasil Diubah!')
					window.location.href='http://www.hondamugen.co.id/index.php/promosi/event/';
					</script>");
        }

	}
	
	public function permintaan_testdrive()
	{	
		$data['testdrive']=$this->M_promosi->semuatestdrive();
		$this->load->view('admin/header');
		$this->load->view('admin/v_menupromosi');
		$this->load->view('admin/promosi/v_permintaan_testdrive',$data);
		$this->load->view('admin/footer');
	}
	
	public function testdrive()
	{	
		if($this->input->post('tgl')==null&&$this->input->post('lokasi')==null){
		$data['tanggal']=date('d-m-Y');	
		$data['testdrive']=$this->M_promosi->semuatestdrive();
		$this->load->view('admin/header');
		$this->load->view('admin/v_menupromosi');
		$this->load->view('admin/promosi/v_testdrive',$data);
		$this->load->view('admin/footer');
		}
		else{
			$tgl2=$this->input->post('tgl');
			$lokasi=$this->input->post('lokasi');
			$data['tanggal']=$tgl2;
			$data['testdrive']=$this->M_promosi->caritestdrive2($tgl2,$lokasi);
			$this->load->view('admin/header');
			$this->load->view('admin/v_menupromosi');
			$this->load->view('admin/promosi/v_testdrive',$data);
			$this->load->view('admin/footer');
		}
	}
	
	function laporan_testdrive($tanggal){
    // load dompdf

    $this->load->helper('dompdf');

    //load content html
	$tgl2=$tanggal;
	$data['tanggal']=$tgl2;
	$data['testdrive']=$this->M_promosi->caritestdrive($tgl2);
    $html = $this->load->view('admin/promosi/v_laporan_testdrive',$data, true);

    // create pdf using dompdf

    $filename = 'Laporan Testdrive';

    $paper = 'A4';

    $orientation = 'potrait';

    pdf_create($html, $filename, $paper, $orientation);

}

	public function persetujuan_testdrive($id_testdirve)
	{	
		$this->load->library('email');
		$testdrive=$this->M_promosi->datatestdrive($id_testdirve);
		$this->M_promosi->approvetestdrive($id_testdirve);
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
	
		$htmlContent = '<h1>Undangan Test Drive Honda Mugen '.$testdrive->lokasi.'</h1>';
		$htmlContent.= '<div>Berdasarkan permohonan test drive yang Bapak/Ibu '.$testdrive->nama.' ajukan untuk kendaraan Honda '.$testdrive->kendaraan.', maka kami mengundang Bapak/Ibu untuk
							melakukan test drive pada:<br><br><br>
							Tanggal: '.$testdrive->tgl.' <br>
							Jam    : '.$testdrive->jam.' <br>
							Lokasi : Honda Mugen '.$testdrive->lokasi.' <br>
							<br><br><br>
							Demikan undangan ini kami sampaikan. Kurang lebihnya kami ucapkan terima kasih.
							
							Hormat Kami,<br><br><br>
							
							Honda Mugen</div>';
			
		$config['mailtype'] = 'html';
		$this->email->initialize($config);
		$this->email->to($testdrive->email);
		$this->email->from('komanganom@gmail.com','Honda Mugen');
		$this->email->subject('Pemberitahuan Jadwal Testdrive');
		$this->email->message($htmlContent);
		if($this->email->send())
		{
				echo ("<script language='JavaScript'>
					window.alert('Email Pemberitahuan Berhasil Dikirim!')
					window.location.href='http://www.hondamugen.co.id/Promosi/permintaan_testdrive/';
					</script>");
		}else
		{
			echo ("<script language='JavaScript'>
					window.alert('Email Pemberitahuan Gagal Dikirim!')
					window.location.href='http://www.hondamugen.co.id/Promosi/permintaan_testdrive/';
					</script>");
		}
	}	
	
	public function tolak_testdrive($id_testdirve)
	{	
		$this->load->library('email');
		$testdrive=$this->M_promosi->datatestdrive($id_testdirve);
		$this->M_promosi->approvetestdrive($id_testdirve);
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
	
		$htmlContent = '<h1>Pemberitahuan Test Drive Honda Mugen</h1>';
		$htmlContent.= '<div>Dengan hormat, <br>
		Sehubungan atas permohonan test drive yang Bapak/Ibu '.$testdrive->nama.' ajukan, kami memohon maaf untuk jadwal tersebut tidak tersedia. 
		Mungkin Bapak/Ibu berkenan untuk mengajukan jadwal di hari atau jam lain. 
		 <br><br><br><br>
							Terima kasih atas perhatiannya.
							
							Hormat Kami,<br><br><br>
							
							Honda Mugen</div>';
			
		$config['mailtype'] = 'html';
		$this->email->initialize($config);
		$this->email->to($testdrive->email);
		$this->email->from('komanganom@gmail.com','Honda Mugen');
		$this->email->subject('Pemberitahuan Jadwal Testdrive');
		$this->email->message($htmlContent);
		if($this->email->send())
		{
				echo ("<script language='JavaScript'>
					window.alert('Email Pemberitahuan Berhasil Dikirim!')
					window.location.href='http://www.hondamugen.co.id/Promosi/permintaan_testdrive/';
					</script>");
		}else
		{
			echo ("<script language='JavaScript'>
					window.alert('Email Pemberitahuan Gagal Dikirim!')
					window.location.href='http://www.hondamugen.co.id/Promosi/permintaan_testdrive/';
					</script>");
		}
	}	
	
	function slide()
	{
		$data['slide'] = $this->M_promosi->semuaslide();     
		//meload view bernama buku_view.php dengan data variable adalah $data
		$this->load->view('admin/header');
		$this->load->view('admin/v_menupromosi');
		$this->load->view('admin/promosi/v_slide',$data);
		$this->load->view('admin/footer');
	}	
	
	public function simpanBanner()
	{
		$this->upload->initialize($this->setup_upload_option());
        if($this->upload->do_upload() == false){
            echo "<script>
	                alert('Gagal Menyimpan');
	                 window.location=('http://www.hondamugen.co.id/Promosi/slide/');
	            </script>";
	    } else {
	        $image 	= $this->upload->data();
	        $upload = $image['file_name'];	                    
            $this->M_promosi->simpanBanner($upload);
		    echo "<script>alert('Banner berhasil disimpan! ');
		        window.location=('http://www.hondamugen.co.id/Promosi/slide/');
					</script>"; 
		}
    }
    
    function hapusBanner($id_slide)
	{
	    $data=$this->M_promosi->pilihBanner($id_slide);
		$foto=$data->path;
		unlink("image/".$foto);
		$this->M_promosi->hapusBanner($id_slide);
		echo ("<script language='JavaScript'>
				window.alert('Banner Berhasil Dihapus!')
				window.location.href='http://www.hondamugen.co.id/index.php/promosi/slide';
				</script>");
	}
	
	
    private function setup_upload_option(){
        $config = array();
        $config['upload_path']      = './image';
        $config['allowed_types']    = 'jpg|png|jpeg';
        $config['overwrite']        = 'False';
        $config['max_size']         = '2048';
        return $config;
   	}
}
?>