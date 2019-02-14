<?php
defined('BASEPATH') OR exit('No direct script access allowed');
error_reporting(0);
class Welcome extends CI_Controller {
	function __construct()
	{
		parent::__construct();
		$this->load->model('M_hrd');
		$this->load->model('M_promosi');
		$this->load->model('M_admin');
		$config['upload_path'] = './cv/';
		$config['allowed_types'] = 'doc|docx|pdf|';
		$config['max_size']	= '500';
		$config['max_width']  = '10000';
		$config['max_height']  = '10000';		
		$this->load->library('upload', $config);
	}
	
	//Fungsi untuk menampilkan halaman beranda
	public function index()
	{
		$data2['page']='index';
		$data['event'] = $this->M_promosi->eventindex();    
		$this->load->view('user/header',$data2);
		$this->load->view('user/index',$data);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman profil
	public function profile()
	{
		$data['page']='profile';
		$this->load->view('user/header',$data);
		$this->load->view('user/profile');
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman fasilitas
	public function fasilitas()
	{
		$data['page']='profile';
		$this->load->view('user/header',$data);
		$this->load->view('user/divisi');
		$this->load->view('user/footer');
	}
	
	/*|--------------------------------------------------|
	  |	   Kumpulan fungsi untuk menampilkan halaman     |
	  |	                 produk honda					 |
      ----------------------------------------------------*/	  
	
	//Fungsi untuk menampilkan halaman accord
    public function accord()
	{
		$data['page']='produk';
		$data2['tipe']=$this->input->post('tipe');
		$data2['tenor']=$this->input->post('tenor');
		if ($this->kredit()==null){
			$data2['tab']='video';
			}else{$data2['tab']='simulasi';
			}
		$id_leasing=$this->input->post('leasing');
		$data2['data_leasing']=$this->M_admin->pilihleasing($id_leasing);
		//print_r($data2); die();
		$data2['kredit']=$this->kredit();
		$kd_mobil='ACC';
		//data buat looping di view, nanganin javascript
		$data2['jml_mobil']=$this->M_admin->hitungjenis($kd_mobil);
		$data2['leasing']=$this->M_admin->semualeasing();
		$data2['harga']=$this->M_admin->semuajenis($kd_mobil);
		$data2['tglUpdate']=$this->M_admin->tglUpdate($kd_mobil);
		$this->load->view('user/header',$data);
		$this->load->view('user/mobil/accord',$data2);
		$this->load->view('user/footer');
		
	}
	
	//Fungsi untuk menampilkan halaman brio
	public function brio()
	{
		$data['page']='produk';
		$data2['tipe']=$this->input->post('tipe');
		$data2['tenor']=$this->input->post('tenor');
		if ($this->kredit()==null){
			$data2['tab']='video';
			}else{$data2['tab']='simulasi';
			}
		$id_leasing=$this->input->post('leasing');
		$data2['data_leasing']=$this->M_admin->pilihleasing($id_leasing);
		//print_r($data2); die();
		$data2['kredit']=$this->kredit();
		$kd_mobil='BRI';
		//data buat looping di view, nanganin javascript
		$data2['jml_mobil']=$this->M_admin->hitungjenis($kd_mobil);
		$data2['leasing']=$this->M_admin->semualeasing();
		$data2['harga']=$this->M_admin->semuajenis($kd_mobil);
		$data2['tglUpdate']=$this->M_admin->tglUpdate($kd_mobil);
		$this->load->view('user/header',$data);
		$this->load->view('user/mobil/brio',$data2);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman brv
	public function brv()
	{
		$data['page']='produk';
		$data2['tipe']=$this->input->post('tipe');
		$data2['tenor']=$this->input->post('tenor');
		if ($this->kredit()==null){
			$data2['tab']='video';
			}else{$data2['tab']='simulasi';
			}
		$id_leasing=$this->input->post('leasing');
		$data2['data_leasing']=$this->M_admin->pilihleasing($id_leasing);
		//print_r($data2); die();
		$data2['kredit']=$this->kredit();
		$kd_mobil='BRV';
		//data buat looping di view, nanganin javascript
		$data2['jml_mobil']=$this->M_admin->hitungjenis($kd_mobil);
		$data2['leasing']=$this->M_admin->semualeasing();
		$data2['harga']=$this->M_admin->semuajenis($kd_mobil);
		$data2['tglUpdate']=$this->M_admin->tglUpdate($kd_mobil);
		$this->load->view('user/header',$data);
		$this->load->view('user/mobil/brv',$data2);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman city
	public function city()
	{
		$data['page']='produk';
		$data2['tipe']=$this->input->post('tipe');
		$data2['tenor']=$this->input->post('tenor');
		if ($this->kredit()==null){
			$data2['tab']='video';
			}else{$data2['tab']='simulasi';
			}
		$id_leasing=$this->input->post('leasing');
		$data2['data_leasing']=$this->M_admin->pilihleasing($id_leasing);
		//print_r($data2); die();
		$data2['kredit']=$this->kredit();
		$kd_mobil='CIT';
		//data buat looping di view, nanganin javascript
		$data2['jml_mobil']=$this->M_admin->hitungjenis($kd_mobil);
		$data2['leasing']=$this->M_admin->semualeasing();
		$data2['harga']=$this->M_admin->semuajenis($kd_mobil);
		$data2['tglUpdate']=$this->M_admin->tglUpdate($kd_mobil);
		$this->load->view('user/header',$data);
		$this->load->view('user/mobil/city',$data2);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman city
	public function civic()
	{
		$data['page']='produk';
		$data2['tipe']=$this->input->post('tipe');
		$data2['tenor']=$this->input->post('tenor');
		if ($this->kredit()==null){
			$data2['tab']='video';
			}else{$data2['tab']='simulasi';
			}
		$id_leasing=$this->input->post('leasing');
		$data2['data_leasing']=$this->M_admin->pilihleasing($id_leasing);
		//print_r($data2); die();
		$data2['kredit']=$this->kredit();
		$kd_mobil='CIV';
		//data buat looping di view, nanganin javascript
		$data2['jml_mobil']=$this->M_admin->hitungjenis($kd_mobil);
		$data2['leasing']=$this->M_admin->semualeasing();
		$data2['harga']=$this->M_admin->semuajenis($kd_mobil);
		$data2['tglUpdate']=$this->M_admin->tglUpdate($kd_mobil);
		$this->load->view('user/header',$data);
		$this->load->view('user/mobil/civic',$data2);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman crv
	public function crv()
	{
		$data['page']='produk';
		$data2['tipe']=$this->input->post('tipe');
		$data2['tenor']=$this->input->post('tenor');
		if ($this->kredit()==null){
			$data2['tab']='video';
			}else{$data2['tab']='simulasi';
			}
		$id_leasing=$this->input->post('leasing');
		$data2['data_leasing']=$this->M_admin->pilihleasing($id_leasing);
		//print_r($data2); die();
		$data2['kredit']=$this->kredit();
		$kd_mobil='CRV';
		//data buat looping di view, nanganin javascript
		$data2['jml_mobil']=$this->M_admin->hitungjenis($kd_mobil);
		$data2['leasing']=$this->M_admin->semualeasing();
		$data2['harga']=$this->M_admin->semuajenis($kd_mobil);
		$data2['tglUpdate']=$this->M_admin->tglUpdate($kd_mobil);
		$this->load->view('user/header',$data);
		$this->load->view('user/mobil/crv',$data2);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman crz
	public function crz()
	{
		$data['page']='produk';
		$data2['tipe']=$this->input->post('tipe');
		$data2['tenor']=$this->input->post('tenor');
		if ($this->kredit()==null){
			$data2['tab']='video';
			}else{$data2['tab']='simulasi';
			}
		$id_leasing=$this->input->post('leasing');
		$data2['data_leasing']=$this->M_admin->pilihleasing($id_leasing);
		//print_r($data2); die();
		$data2['kredit']=$this->kredit();
		$kd_mobil='CRZ';
		//data buat looping di view, nanganin javascript
		$data2['jml_mobil']=$this->M_admin->hitungjenis($kd_mobil);
		$data2['leasing']=$this->M_admin->semualeasing();
		$data2['harga']=$this->M_admin->semuajenis($kd_mobil);
		$data2['tglUpdate']=$this->M_admin->tglUpdate($kd_mobil);
		$this->load->view('user/header',$data);
		$this->load->view('user/mobil/crz',$data2);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman freed
	public function freed()
	{
		$data['page']='produk';
		$data2['tipe']=$this->input->post('tipe');
		$data2['tenor']=$this->input->post('tenor');
		if ($this->kredit()==null){
			$data2['tab']='video';
			}else{$data2['tab']='simulasi';
			}
		$id_leasing=$this->input->post('leasing');
		$data2['data_leasing']=$this->M_admin->pilihleasing($id_leasing);
		//print_r($data2); die();
		$data2['kredit']=$this->kredit();
		$kd_mobil='FRD';
		//data buat looping di view, nanganin javascript
		$data2['jml_mobil']=$this->M_admin->hitungjenis($kd_mobil);
		$data2['leasing']=$this->M_admin->semualeasing();
		$data2['harga']=$this->M_admin->semuajenis($kd_mobil);
		$data2['tglUpdate']=$this->M_admin->tglUpdate($kd_mobil);
		$this->load->view('user/header',$data);
		$this->load->view('user/mobil/freed',$data2);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman hrv
	public function hrv()
	{
		$data['page']='produk';
		$data2['tipe']=$this->input->post('tipe');
		$data2['tenor']=$this->input->post('tenor');
		if ($this->kredit()==null){
			$data2['tab']='video';
			}else{$data2['tab']='simulasi';
			}
		$id_leasing=$this->input->post('leasing');
		$data2['data_leasing']=$this->M_admin->pilihleasing($id_leasing);
		//print_r($data2); die();
		$data2['kredit']=$this->kredit();
		$kd_mobil='HRV';
		//data buat looping di view, nanganin javascript
		$data2['jml_mobil']=$this->M_admin->hitungjenis($kd_mobil);
		$data2['leasing']=$this->M_admin->semualeasing();
		$data2['harga']=$this->M_admin->semuajenis($kd_mobil);
		$data2['tglUpdate']=$this->M_admin->tglUpdate($kd_mobil);
		$this->load->view('user/header',$data);
		$this->load->view('user/mobil/hrv',$data2);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman jazz
	public function jazz()
	{
		$data['page']='produk';
		$data2['tipe']=$this->input->post('tipe');
		$data2['tenor']=$this->input->post('tenor');
		if ($this->kredit()==null){
			$data2['tab']='video';
			}else{$data2['tab']='simulasi';
			}
		$id_leasing=$this->input->post('leasing');
		$data2['data_leasing']=$this->M_admin->pilihleasing($id_leasing);
		//print_r($data2); die();
		$data2['kredit']=$this->kredit();
		$kd_mobil='JAZ';
		//data buat looping di view, nanganin javascript
		$data2['jml_mobil']=$this->M_admin->hitungjenis($kd_mobil);
		$data2['leasing']=$this->M_admin->semualeasing();
		$data2['harga']=$this->M_admin->semuajenis($kd_mobil);
		$data2['tglUpdate']=$this->M_admin->tglUpdate($kd_mobil);
		$this->load->view('user/header',$data);
		$this->load->view('user/mobil/jazz',$data2);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman mobilio
	public function mobilio()
	{
		$data['page']='produk';
		$data2['tipe']=$this->input->post('tipe');
		$data2['tenor']=$this->input->post('tenor');
		if ($this->kredit()==null){
			$data2['tab']='video';
			}else{$data2['tab']='simulasi';
			}
		$id_leasing=$this->input->post('leasing');
		$data2['data_leasing']=$this->M_admin->pilihleasing($id_leasing);
		//print_r($data2); die();
		$data2['kredit']=$this->kredit();
		$kd_mobil='MOB';
		//data buat looping di view, nanganin javascript
		$data2['jml_mobil']=$this->M_admin->hitungjenis($kd_mobil);
		$data2['leasing']=$this->M_admin->semualeasing();
		$data2['harga']=$this->M_admin->semuajenis($kd_mobil);
		$data2['tglUpdate']=$this->M_admin->tglUpdate($kd_mobil);
		$this->load->view('user/header',$data);
		$this->load->view('user/mobil/mobilio',$data2);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman mobiliors
	public function mobiliors()
	{
		$data['page']='produk';
		$data2['tipe']=$this->input->post('tipe');
		$data2['tenor']=$this->input->post('tenor');
		if ($this->kredit()==null){
			$data2['tab']='video';
			}else{$data2['tab']='simulasi';
			}
		$id_leasing=$this->input->post('leasing');
		$data2['data_leasing']=$this->M_admin->pilihleasing($id_leasing);
		//print_r($data2); die();
		$data2['kredit']=$this->kredit();
		$kd_mobil='MOBRS';
		//data buat looping di view, nanganin javascript
		$data2['jml_mobil']=$this->M_admin->hitungjenis($kd_mobil);
		$data2['leasing']=$this->M_admin->semualeasing();
		$data2['harga']=$this->M_admin->semuajenis($kd_mobil);
		$data2['tglUpdate']=$this->M_admin->tglUpdate($kd_mobil);
		$this->load->view('user/header',$data);
		$this->load->view('user/mobil/mobilio-rs',$data2);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman odyssey
	public function odyssey()
	{
		$data['page']='produk';
		$data2['tipe']=$this->input->post('tipe');
		$data2['tenor']=$this->input->post('tenor');
		if ($this->kredit()==null){
			$data2['tab']='video';
			}else{$data2['tab']='simulasi';
			}
		$id_leasing=$this->input->post('leasing');
		$data2['data_leasing']=$this->M_admin->pilihleasing($id_leasing);
		//print_r($data2); die();
		$data2['kredit']=$this->kredit();
		$kd_mobil='ODY';
		//data buat looping di view, nanganin javascript
		$data2['jml_mobil']=$this->M_admin->hitungjenis($kd_mobil);
		$data2['leasing']=$this->M_admin->semualeasing();
		$data2['harga']=$this->M_admin->semuajenis($kd_mobil);
		$data2['tglUpdate']=$this->M_admin->tglUpdate($kd_mobil);
		$this->load->view('user/header',$data);
		$this->load->view('user/mobil/odyssey',$data2);
		$this->load->view('user/footer');
	}
	
	
	/*|--------------------------------------------------|
	  |	   Kumpulan fungsi untuk menampilkan halaman     |
	  |	                    Test drive			     	 |
      ----------------------------------------------------*/	  
	
	//Fungsi untuk menampilkan halaman jadwal test drive
	public function testdrive()
	{	
		if($this->input->post('tgl')==null){
		$data['tanggal']=date('d-m-Y');	
		$data['testdrive']=$this->M_promosi->semuatestdriveindex();
		$data2['page']='testdrive';
		$this->load->view('user/header',$data2);
		$this->load->view('user/testdrive',$data);
		$this->load->view('user/footer');
		}
		else{
			$tgl2=$this->input->post('tgl');
			$data['tanggal']=$tgl2;
			$data['testdrive']=$this->M_promosi->caritestdrive($tgl2);
			$data2['page']='testdrive';
			$this->load->view('user/header',$data2);
			$this->load->view('user/testdrive',$data);
			$this->load->view('user/footer');
		}
	}
	
	//Fungsi untuk menampilkan form pengajuan test drive
	public function form_testdrive()
	{	
		$data['page']='testdrive';
		$data['captcha'] = $this->recaptcha->getWidget(); 
        $data['script_captcha'] = $this->recaptcha->getScriptTag();
		$this->load->view('user/header',$data);
		$this->load->view('user/v_form_testdrive');
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menyimpan pengajuan test drive ke table
	public function simpan_testdrive()
	{
		$recaptcha = $this->input->post('g-recaptcha-response');
		//echo $recaptcha; die();
        $response = $this->recaptcha->verifyResponse($recaptcha);
	
			$this->M_promosi->simpantestdrive();
			
			$this->load->library('email');
			$email=$this->input->post('email');
			//$id_lamaran=$this->input->post('id_lamaran');
			//$this->M_hrd->ubahstatuslamaran($id_lamaran);
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
		
			$htmlContent= 'Ada permohonan Test Drive Baru, <a href="https://www.hondamugen.co.id/login">mohon ditinjau</a> <br><br><br>
						   Terima kasih';
				
			$config['mailtype'] = 'html';
			$this->email->initialize($config);
			$this->email->to('ivan.hondamugen@gmail.com');
			$this->email->from('komang@hondamugen.co.id','Honda Mugen');
			$this->email->subject('Permohonan Test Drive');
			$this->email->message($htmlContent);
			$this->email->send();
			echo ("<script language='JavaScript'>
				window.alert('Terimakasih, permintaan anda akan segera kami proses!')
				window.location.href='http://www.hondamugen.co.id/testdrive';
				</script>");
				
	}
	
	
	/*|--------------------------------------------------|
	  |	   Kumpulan fungsi untuk menampilkan halaman     |
	  |	                    Karir				     	 |
      ----------------------------------------------------*/	  
	
	//Fungsi untuk menampilkan halaman karir
	public function karir()
	{
		$data2['page']='karir';
		$data['lowongan'] = $this->M_hrd->lowonganuser();
		$this->load->view('user/header',$data2);
		$this->load->view('user/karir',$data);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman form lamaran 
	public function lamaran()
	{
		$data2['page']='karir';
		$id_lowongan=$this->uri->segment('2');
		$data['id_lowongan']=$this->uri->segment('2');
		$data['lowongan']=$this->M_hrd->pilihlowongan($id_lowongan);
		$data['captcha'] = $this->recaptcha->getWidget(); 
        $data['script_captcha'] = $this->recaptcha->getScriptTag();
		$this->load->view('user/header',$data2);
		$this->load->view('user/v_form_lamaran',$data);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menyimpan data lamaran ke table
	public function simpanlamaran()
	{
		$id_lowongan = $this->input->post('id_lowongan');
		$recaptcha = $this->input->post('g-recaptcha-response');
        $response = $this->recaptcha->verifyResponse($recaptcha);
		
			if ( ! $this->upload->do_upload())
			{
				$pesan= $this->upload->display_errors();
				echo ("<script language='JavaScript'>
				window.alert('$pesan')
				window.location.href='http://hondamugen.co.id/lamaran/$id_lowongan';
				</script>");	
			} else 
			{
				$image_data = $this->upload->data();
				$upload=$image_data['file_name'];//echo $nm_file;die();
				$this->M_hrd->simpanlamaran($upload);
				
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
			
				$htmlContent= 'Ada lamaran baru, <a href="https://www.hondamugen.co.id/login">mohon ditinjau</a> <br><br><br>
							   Terima kasih';
					
				$config['mailtype'] = 'html';
				$this->email->initialize($config);
				$this->email->to('recruitmentmugen@gmail.com');
				$this->email->from('komang@hondamugen.co.id','Honda Mugen');
				$this->email->subject('Lamaran Baru');
				$this->email->message($htmlContent);
				$this->email->send();
			
				echo ("<script language='JavaScript'>
				window.alert('Terimakasih, lamaran anda akan segera kami proses!')
				window.location.href='http://hondamugen.co.id/karir/';
				</script>");	 					
			}
        
	}

	//Fungsi untuk menampilkan halaman lokasi kami
	public function lokasi()
	{	
		$data['page']='lokasi';
		$this->load->view('user/header',$data);
		$this->load->view('user/lokasi');
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk menampilkan halaman karir
	public function event()
	{
		$data2['page']='event';
		
		$config['base_url'] = base_url("event");
		$config['total_rows'] = $this->db->count_all('event');
		$config['full_tag_open'] = '<div class="pagination">';
		$config['full_tag_close'] = '</div>';
		$config['cur_tag_open'] = '<a class="active">';
		$config['cur_tag_close'] = '</a>';
		$config['per_page'] = 5;
		$config['num_links'] = 2;
		$config['next_link'] = '>>';
		$config['prev_link'] = '<<';
		$offset=$this->uri->segment(2);
		$data['event'] = $this->M_promosi->semuaevent($config['per_page'],$offset);
		$this->pagination->initialize($config);      
		$this->load->view('user/header',$data2);
		$this->load->view('user/event',$data);
		$this->load->view('user/footer');
	}
	
	//Fungsi untuk halaman not found
    public function notfound()
    {
        $this->load->view('user/notfound');
    }
	
	//Fungsi untuk hitung kredit
    public function kredit()
    {
		$pembulatanRupiah=str_replace(',00', '',$this->input->post('hargaMobil'));
		$clearRupiah=str_replace('Rp', '',$pembulatanRupiah);
		$hargaMobil=str_replace('.', '',$clearRupiah);
		$tipe=$this->input->post('tipe');
		if ($hargaMobil <= 125000000){
			$asuransi=1;}
		elseif ($hargaMobil > 125000000 && $hargaMobil <= 200000000){
			$asuransi=2;}
		elseif($hargaMobil > 200000000 && $hargaMobil <= 400000000){
			$jw=3;}
		elseif($hargaMobil > 400000000 && $hargaMobil <= 800000000){
			$jw=4;}
		elseif($hargaMobil > 800000000){
			$jw=5;}
		$tenor=$this->input->post('tenor');
		if ($this->input->post('leasing')!=null){
		$id_leasing=$this->input->post('leasing');
		$data_leasing=$this->M_admin->pilihleasing($id_leasing);
		$bunga= $data_leasing->bunga;
		$provisi=$data_leasing->provisi;
		
		$admin=$data_leasing->admin;
	
		if ($hargaMobil <= 125000000){
			$asuransi=$data_leasing->asuransi1;}
		elseif ($hargaMobil > 125000000 && $hargaMobil <= 200000000){
			$asuransi=$data_leasing->asuransi2;}
		elseif($hargaMobil > 200000000 && $hargaMobil <= 400000000){
			$asuransi=$data_leasing->asuransi3;}
		elseif($hargaMobil > 400000000 && $hargaMobil <= 800000000){
			$asuransi=$data_leasing->asuransi4;}
		elseif($hargaMobil > 800000000){
			$asuransi=$data_leasing->asuransi5;}
		
		if ($tenor == 12){
			$jw=1;$asuransi=$asuransi*1;}
		elseif ($tenor == 24){
			$jw=2;$asuransi=$asuransi*2;}
		elseif($tenor == 36){
			$jw=3;$asuransi=$asuransi*3;}
		elseif($tenor == 48){
			$jw=4;$asuransi=$asuransi*4;}
		elseif($tenor == 60){
			$jw=5;$asuransi=$asuransi*5;}
		}
		
		if ($this->input->post('bentukDp')=='%'){
			$tipe=$this->input->post('tipe');
		
			//filter_var($this->input->post('hargaMobil'), FILTER_SANITIZE_NUMBER_INT);
			$dp=$this->input->post('dp');
			$um= ($dp/100) * $hargaMobil;
			$pk= $hargaMobil - $um;
			$apb=round((((($bunga/100) * $jw) + 1) * $pk)/((($jw*12)/1000)*1000));
			$asuransi=($asuransi/100)*$hargaMobil;
			$provisi = $provisi/100 * $pk;
			$tdp=$um+$apb+$asuransi+$provisi+$admin;
			
			$data= array('tipe'=>$tipe, 
						  'dp'=>$dp, 
						  'hargaMobil'=>$hargaMobil, 
						  'tenor'=>$tenor,
						  'apb'=>$apb,
						  'tdp'=>$tdp);
			return ($data);
		} elseif ($this->input->post('bentukDp')=='Rp'){

		//filter_var($this->input->post('hargaMobil'), FILTER_SANITIZE_NUMBER_INT);
		$um=str_replace('.', '',$this->input->post('dp'));
		$dp= "Rp " . number_format($um,2,',','.');
		$pk= $hargaMobil - $um;
		$apb=round(((((5/100) * $jw) + 1) * $pk)/((($jw*12)/1000)*1000));
		$asuransi=(6/100)*$hargaMobil;
		$provisi = 1/100 * $pk;
		$tdp=$um+$apb+$asuransi+$provisi+$admin;
			
		$data= array('tipe'=>$tipe, 
						  'dp'=>$dp, 
						  'hargaMobil'=>$hargaMobil, 
						  'tenor'=>$tenor,
						  'apb'=>$apb,
						  'tdp'=>$tdp);
		return ($data);
		}
    }
    
    //Fungsi untuk menampilkan halaman faq
	public function faq()
	{	
		$data['page']='faq';
		$this->load->view('user/header',$data);
		$this->load->view('user/faq');
		$this->load->view('user/footer');
	}
	
	  //Fungsi untuk menampilkan halaman faq
	public function survey()
	{	
		$this->load->view('user/header',$data);
		$this->load->view('user/survey');
		$this->load->view('user/footer');
	}
	
	
	
}
?>