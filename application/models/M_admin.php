<?php
class M_admin extends CI_Model{

	/*|-----------------------------------------------------------------|
	  |   	           Fungsi Buat kode mobil                           |
	  |                                                                 |
	  ------------------------------------------------------------------|*/

	//Menampilkan semua kode mobil
    function semuatipe($num,$offset)
	{
		$this->db->order_by("kd_mobil","asc"); 
		return $this->db->get('kode_mobil',$num,$offset)->result();
	}
  
	//Menyimpan kode mobil
	function simpantipe()
	{
		$kd_mobil = $this->input->post('kd_mobil');
		$keterangan = $this->input->post('keterangan');
		$data = array('kd_mobil'=>$kd_mobil, 
					  'keterangan'=>$keterangan);
		$this->db->insert('kode_mobil',$data);	
	}

	
	/*|-----------------------------------------------------------------|
	  |   	              Fungsi Jenis Mobil    	                    |
	  |                                                                 |
	  ------------------------------------------------------------------|*/	
	
	function semuajenis($kd_mobil)
	{
		$this->db->order_by("jns_mobil","asc"); 
		$this->db->where('kd_mobil',$kd_mobil);
		return $this->db->get('jenis_mobil')->result();
	}
	
	function hitungjenis($kd_mobil)
	{
		$this->db->select('count(jns_mobil) as jml_mobil');
		$this->db->from('jenis_mobil');
		$this->db->order_by('jns_mobil','asc'); 
		$this->db->where('kd_mobil',$kd_mobil);
		return $this->db->get()->row();
	}
	
	function simpanjenis()
	{
		$kd_mobil = $this->input->post('kd_mobil');
		$jns_mobil = $this->input->post('jns_mobil');
		$harga = $this->input->post('harga');
		$data = array('kd_mobil'=>$kd_mobil, 
					  'jns_mobil'=>$jns_mobil,
					  'harga'=>$harga);
		$this->db->insert('jenis_mobil',$data);	
	}
	
	//menghapus jenis mobil
	function hapusjenis($kd_jenis)
	{
        $this->db->delete('jenis_mobil', array('kd_jenis'=>$kd_jenis));
	}
	
	//mengedit jenis mobil
	function editjenis($kd_jenis)
	{
		$kd_mobil = $this->input->post('kd_mobil');
		$jns_mobil = $this->input->post('jns_mobil');
		$harga = $this->input->post('harga');
		$data = array('kd_mobil'=>$kd_mobil, 
					  'jns_mobil'=>$jns_mobil,
					  'harga'=>$harga);
        $this->db->where('kd_jenis',$kd_jenis)->update('jenis_mobil', $data);
        date_default_timezone_set("Asia/Bangkok");
        $tgl_update= date('d-m-Y H:i:s');
        $data2 = array('tglUpdate'=>$tgl_update);
         $this->db->where('kd_mobil',$kd_mobil)->update('kode_mobil', $data2);
	}
	
	function pilihjenis($kd_jenis)
	{
        return $this->db->get_where('jenis_mobil', array('kd_jenis'=>$kd_jenis))->row();
    }
	
	function tglUpdate($kd_mobil)
	{
	    return $this->db->get_where('kode_mobil', array('kd_mobil'=>$kd_mobil))->row();
	}
	
	/*|-----------------------------------------------------------------|
	  |   	                   Fungsi Leasing         	                |
	  |                                                                 |
	  ------------------------------------------------------------------|*/	
	
	function semualeasing()
	{
		$this->db->order_by("id_leasing","asc"); 
		return $this->db->get('leasing')->result();
	}
	
	function simpanleasing()
	{
		$nm_leasing = $this->input->post('nm_leasing');
		$bunga = $this->input->post('bunga');
		$asuransi1 = $this->input->post('asuransi1');
		$asuransi2 = $this->input->post('asuransi2');
		$asuransi3 = $this->input->post('asuransi3');
		$asuransi4 = $this->input->post('asuransi4');
		$asuransi5 = $this->input->post('asuransi5');
		$provisi = $this->input->post('provisi');
		$admin = $this->input->post('admin');
		date_default_timezone_set("Asia/Bangkok");
        $tgl_update= date('M Y');
		$data = array('nm_leasing'=>$nm_leasing,
		              'bunga'=>$bunga, 
					  'asuransi1'=>$asuransi1,
					  'asuransi2'=>$asuransi2,
					  'asuransi3'=>$asuransi3,
					  'asuransi4'=>$asuransi4,
					  'asuransi5'=>$asuransi5,
					  'provisi'=>$provisi,
					  'admin'=>$admin,
					  'tgl_update'=>$tgl_update);
		$this->db->insert('leasing',$data);	
	}
	
	//menghapus jenis mobil
	function hapusleasing($id_leasing)
	{
        $this->db->delete('leasing', array('id_leasing'=>$id_leasing));
	}
	
	//mengedit jenis mobil
	function editleasing($id_leasing)
	{
		$nm_leasing = $this->input->post('nm_leasing');
		$bunga = $this->input->post('bunga');
		$asuransi1 = $this->input->post('asuransi1');
		$asuransi2 = $this->input->post('asuransi2');
		$asuransi3 = $this->input->post('asuransi3');
		$asuransi4 = $this->input->post('asuransi4');
		$asuransi5 = $this->input->post('asuransi5');
		$provisi = $this->input->post('provisi');
		$admin = $this->input->post('admin');
		date_default_timezone_set("Asia/Bangkok");
        $tgl_update= date('M Y');
		$data = array('nm_leasing'=>$nm_leasing,
		              'bunga'=>$bunga, 
					  'asuransi1'=>$asuransi1,
					  'asuransi2'=>$asuransi2,
					  'asuransi3'=>$asuransi3,
					  'asuransi4'=>$asuransi4,
					  'asuransi5'=>$asuransi5,
					  'provisi'=>$provisi,
					  'admin'=>$admin,
					  'tgl_update'=>$tgl_update);
        $this->db->where('id_leasing',$id_leasing)->update('leasing', $data);
	}
	
	function pilihleasing($id_leasing)
	{
        return $this->db->get_where('leasing', array('id_leasing'=>$id_leasing))->row();
    }

}
?>
