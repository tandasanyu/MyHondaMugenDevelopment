<?php
class Login extends CI_Controller {
	function __construct()
	{
		parent::__construct();
		$this->load->model('M_login');
	}
	
	function index()
	{
		//cek apakah sudah login
		if($this->session->userdata('login')==TRUE)
		{
			//jika login sebagai admin membuka halaman admin
			if($this->session->userdata('level')== 'admin')
			{
				redirect('admin');
			}
			//jika login sebagai user membuka halaman user
			elseif($this->session->userdata('level')== 'hrd')
			{
				redirect('Hrd');
			}
			elseif($this->session->userdata('level')== 'promosi')
			{
				redirect('Promosi');
			}
		}
		//tetapi jika belum login akan menampilkan halaman login
		else
		{
			$data['login']=$this->session->userdata('login');
			$data['pesan']="Anda Belum Login";
			$this->load->view('admin/v_login',$data);
		}
	}

	function proses()
	{
		//validasi inputan untuk username & password
		$this->form_validation->set_rules('username', 'Username', 'trim|required|min_length[4]');
		$this->form_validation->set_rules('password', 'Password', 'trim|required|min_length[4]|max_length[15]');
		//jika form validasi terpenuhi
		if($this->form_validation->run()==TRUE)
		{
			//mengambil inputan username dan password kemudian melakukan cek level
			$username=$this->input->post('username');
			$pass=md5($this->input->post('password'));
			$cek_level=$this->M_login->cek_level($username);
			$a=$this->M_login->cek_user($username,$pass);
			//jika username dan password terdapat di database serta levelnya admin, maka session di set sebagai admin dan akan membuka halaman admin
			if($this->M_login->cek_user($username,$pass)==TRUE && $cek_level->level == 'admin' )
			{
				$data=array(
				'user'=>$username,
				'level'=>$cek_level->level,
				'login'=>TRUE
				);
				$this->session->set_userdata($data);      
				redirect('admin');
			}
			//jika username dan password terdapat di database serta levelnya user, maka session di set sebagai user dan akan membuka halaman user
			elseif($this->M_login->cek_user($username,$pass)==TRUE && $cek_level->level == 'hrd' )
			{	
				$data=array(
					'user'=>$username,
					'level'=>$cek_level->level,
					'login'=>TRUE
					);
				$this->session->set_userdata($data);      
				redirect('Hrd');	
			}
			elseif($this->M_login->cek_user($username,$pass)==TRUE && $cek_level->level == 'promosi' )
			{	
				$data=array(
					'user'=>$username,
					'level'=>$cek_level->level,
					'login'=>TRUE
					);
				$this->session->set_userdata($data);      
				redirect('promosi');	
			}
			//jika username dan password tidak ada di database maka akan menampilkan pesan tidak cocok
			else
			{
				$data['pesan']="Username atau Password yang diinput tidak sesuai";
				$data['login']=$this->session->userdata('login');				
				$this->load->view('admin/v_login', $data);
			}
		}
		//jika form validasi tidak terpenuhi
		else
		{
			$data['pesan']="Silahkan Masukan Username dan Password";
			$data['login']=$this->session->userdata('login');
			$this->load->view('admin/v_login',$data);
		}
	}
	
	function logout()
	{
		//menghapus session dan menampilkan halaman login
		$this->session->sess_destroy();
		$this->session->unset_userdata('login');
		$data['pesan']="Anda telah logout";		
		$this->load->view('admin/v_login', $data);
	}
}
?>