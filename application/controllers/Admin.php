<?php
class Admin extends CI_Controller{
   function __construct()
	{
		parent::__construct();
		$this->load->model('M_admin');
		$this->is_logged_in(); //memanggil function is_logged_in
		
	}
   
	//fungsi untuk mengecek apakah session ada dan levelnya admin
	function is_logged_in()
	{
		$is_logged_in = $this->session->userdata('login');
		$level=$this->session->userdata('level');
		//jika session tidak ada atau levelnya bukan user maka akan menampilkan pesan error
		if(!isset($is_logged_in) ||  $is_logged_in != true || $level != 'admin' )
		{
			echo 'You don\'t have permission to access this page. <a href="login">Login</a>';
			die();
		}
	}

	function index()
	{
		$data['nama'] = $this->session->userdata('level');
		$this->load->view('admin/header');
		$this->load->view('admin/v_menuadmin');
		$this->load->view('admin/admin/v_beranda',$data);
		$this->load->view('admin/footer');
	}
	
	function tipe_mobil()
	{
		$config['base_url'] = base_url("Admin/tipe_mobil");
		$config['total_rows'] = $this->db->count_all('kode_mobil');
		$config['full_tag_open'] = '<div class="pagination">';
		$config['full_tag_close'] = '</div>';
		$config['cur_tag_open'] = '<a class="active">';
		$config['cur_tag_close'] = '</a>';
		$config['per_page'] = 12;
		$config['num_links'] = 2;
		$config['next_link'] = '>>';
		$config['prev_link'] = '<<';
		$offset=$this->uri->segment(3);
		$data['event'] = $this->M_admin->semuatipe($config['per_page'],$offset);
		$this->pagination->initialize($config);          
		//meload view bernama buku_view.php dengan data variable adalah $data
		$this->load->view('admin/header');
		$this->load->view('admin/v_menuadmin');
		$this->load->view('admin/admin/v_tipe_mobil',$data);
		$this->load->view('admin/footer');
	}		
			
	function form_tipe_mobil()
	{ 
		//meload view bernama buku_view.php dengan data variable adalah $data
		$this->load->view('admin/header');
		$this->load->view('admin/v_menuadmin');
		$this->load->view('admin/admin/v_form_tipe_mobil');
		$this->load->view('admin/footer');
	}		
			
	function simpan_tipe_mobil()
	{
		$this->M_admin->simpantipe();
		echo ("<script language='JavaScript'>
				window.alert('Tipe Mobil Berhasil Ditambah!')
				window.location.href='http://www.hondamugen.co.id/admin/tipe_mobil';
				</script>");
    }
	
	function jenis_mobil($kd_mobil)
	{
		$data['event'] = $this->M_admin->semuajenis($kd_mobil);    
		//meload view bernama buku_view.php dengan data variable adalah $data
		$data['no']=$kd_mobil;
		$this->load->view('admin/header');
		$this->load->view('admin/v_menuadmin');
		$this->load->view('admin/admin/v_jenis_mobil',$data);
		$this->load->view('admin/footer');
	}		
			
	function form_jenis_mobil($kd_mobil)
	{ 
		$data['no']=$kd_mobil;
		//meload view bernama buku_view.php dengan data variable adalah $data
		$this->load->view('admin/header');
		$this->load->view('admin/v_menuadmin');
		$this->load->view('admin/admin/v_form_jenis_mobil',$data);
		$this->load->view('admin/footer');
	}		
			
	function simpan_jenis_mobil()
	{
		$this->M_admin->simpanjenis();
		$kd_mobil=$this->input->post('kd_mobil');
		echo ("<script language='JavaScript'>
				window.alert('Jenis Mobil Berhasil Ditambah!')
				window.location.href='http://www.hondamugen.co.id/Admin/jenis_mobil/$kd_mobil';
				</script>");
    }
	
	function hapus_jenis($kd_jenis)
	{	
		$this->M_admin->hapusjenis($kd_jenis);
		$kd_mobil=$this->uri->segment(4);
		echo ("<script language='JavaScript'>
				window.alert('Jenis Mobil Berhasil Dihapus!')
				window.location.href='http://www.hondamugen.co.id/Admin/jenis_mobil/$kd_mobil';
				</script>");
	}
	
	function edit_jenis()
	{
	    $kd_jenis=$this->uri->segment(3);
		if($_POST==NULL)  {
        	$data['no'] = $this->M_admin->pilihjenis($kd_jenis);
			$this->load->view('admin/header');
			$this->load->view('admin/v_menuadmin');
            $this->load->view('admin/admin/v_form_edit_jenis',$data);
			$this->load->view('admin/footer');
        } else  {
			$kd_mobil=$this->uri->segment(4);
            $this->M_admin->editjenis($kd_jenis);
			echo ("<script language='JavaScript'>
					window.alert('Jenis Mobil Berhasil Diubah!')
					window.location.href='http://www.hondamugen.co.id/Admin/jenis_mobil/$kd_mobil';
					</script>");
        }

	}
	
	function leasing()
	{
		$data['leasing'] = $this->M_admin->semualeasing();    
		$this->load->view('admin/header');
		$this->load->view('admin/v_menuadmin');
		$this->load->view('admin/admin/v_leasing',$data);
		$this->load->view('admin/footer');
	}		
			
	function form_leasing()
	{ 
		//meload view bernama buku_view.php dengan data variable adalah $data
		$this->load->view('admin/header');
		$this->load->view('admin/v_menuadmin');
		$this->load->view('admin/admin/v_form_leasing');
		$this->load->view('admin/footer');
	}		
			
	function simpan_leasing()
	{
		$this->M_admin->simpanleasing();
		echo ("<script language='JavaScript'>
				window.alert('Data Leasing Berhasil Ditambah!')
				window.location.href='http://www.hondamugen.co.id/Admin/leasing';
				</script>");
    }
	
	function hapus_leasing($id_leasing)
	{	
		$this->M_admin->hapusleasing($id_leasing);
		$kd_mobil=$this->uri->segment(3);
		echo ("<script language='JavaScript'>
				window.alert('Data Leasing Berhasil Dihapus!')
				window.location.href='http://www.hondamugen.co.id/Admin/leasing';
				</script>");
	}
	
	function edit_leasing($id_leasing)
	{
		if($_POST==NULL)  {
        	$data['no'] = $this->M_admin->pilihleasing($id_leasing);
			$this->load->view('admin/header');
			$this->load->view('admin/v_menupromosi');
            $this->load->view('admin/admin/v_form_edit_leasing',$data);
			$this->load->view('admin/footer');
        } else  {
			$id_leasing=$this->uri->segment(3);
            $this->M_admin->editleasing($id_leasing);
			echo ("<script language='JavaScript'>
					window.alert('Data Leasing Berhasil Diubah!')
					window.location.href='http://www.hondamugen.co.id/Admin/leasing';
					</script>");
        }
	}
}
?>