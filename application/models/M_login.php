<?php
class m_login extends CI_Model
{
	//melakukan pengecekan user dan password di tabel latihan_login, jika data ada mengembalikan nilai dengan true
	
	function cek_user($username,$password)
	{
		$this->db->where('username',$username);
		$this->db->where('password',$password);
		$query=$this->db->get('admin');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
 

	//melakukan pengecekan level berdasarkan username
	function cek_level($username)
	{
        return $this->db->get_where('admin', array('username'=>$username))->row();
	}
	
	function cek_akunPelamar($username,$password)
	{
		$this->db->where('username',$username);
		$this->db->where('password',$password);
		$query=$this->db->get('temp_akun');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
 }
 ?>