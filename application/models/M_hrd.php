<?php
class M_hrd extends CI_Model{

	/*|-----------------------------------------------------------------|
	  |   	           Fungsi Buat Lowongan Pekerjaan                   |
	  |                                                                 |
	  ------------------------------------------------------------------|*/

	//Menampilkan semua lowongan
    function semualowongan()
	{
		$this->db->order_by("tgl_posting","asc"); 
		return $this->db->get('lowongan')->result();
	}
	
	//Menampilkan semua lowongan user
    function lowonganuser()
	{
	    $this->db->select('posisi,kualifikasi,id_lowongan,str_to_date(tgl_posting, "%d-%m-%Y") day',false);
		$this->db->order_by("day","desc"); 
		$this->db->where('status','1');
		return $this->db->get('lowongan')->result();
	}
  
	//Menyimpan lowongan baru
	function simpanlowongan()
	{
		$tgl_posting = $this->input->post('tgl_posting');
		$posisi = $this->input->post('posisi');
		$kualifikasi=$this->input->post('kualifikasi');
		$status=1;
		$data = array('tgl_posting'=>$tgl_posting, 
					  'posisi'=>$posisi, 
					  'kualifikasi'=>$kualifikasi, 
					  'status'=>$status);
		$this->db->insert('lowongan',$data);	
	}

	//menghapus lowongan
	function hapuslowongan($id_lowongan)
	{
        $this->db->delete('lowongan', array('id_lowongan'=>$id_lowongan));
	}
	
	//mengedit status lowongan
	function editstatus($id_lowongan,$status)
	{
		if($status==1){
			$this->db->where('id_lowongan',$id_lowongan)->update('lowongan', array('status'=>0));
		}
		else{
			$this->db->where('id_lowongan',$id_lowongan)->update('lowongan', array('status'=>1));
			
			//Hapus data pelamar 
			//$this->db->delete('temp_akun', array('posisi'=>$posisi));
			//$this->db->delete('data_diri', array('username'=>$id_lowongan));
		}
	}

	//mengedit data lowongan
	function editlowongan($id_lowongan)
	{
		$tgl_posting = $this->input->post('tgl_posting');
		$posisi = $this->input->post('posisi');
		$nama = $this->input->post('nama');
		$kualifikasi=$this->input->post('kualifikasi');
		$data = array('tgl_posting'=>$tgl_posting, 
					  'posisi'=>$posisi, 
					  'kualifikasi'=>$kualifikasi);
        $this->db->where('id_lowongan',$id_lowongan)->update('lowongan', $data);
	}

	//memilih data lowongan
	function pilihlowongan($id_lowongan)
	{
        return $this->db->get_where('lowongan', array('id_lowongan'=>$id_lowongan))->row();
    }
	
	/*|-----------------------------------------------------------------|
	  |   	              Fungsi Lihat Data Pelamar	                    |
	  |                                                                 |
	  ------------------------------------------------------------------|*/	
	
	function cekUsername($username)
	{
		$this->db->select('*');
		$this->db->from('temp_akun');
		$this->db->where('username',$username);
		$query = $this->db->get();
		//echo $query->num_rows(); die();
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekLamaran()
	{
		$this->db->select('*');
		$this->db->from('data_lamaran');
		$this->db->where('statusLamaran',0);
		$query = $this->db->get();
		//echo $query->num_rows(); die();
		if ($query->num_rows()>=1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekLamaran2()
	{
		$this->db->select('*');
		$this->db->from('data_lamaran');
		$this->db->where('statusLamaran',1);
		$query = $this->db->get();
		//echo $query->num_rows(); die();
		if ($query->num_rows()>=1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	//sesuai posisi
	function cekLamaran3($posisi)
	{
		$this->db->select('*');
		$this->db->from('data_lamaran');
		$this->db->where('statusLamaran',1);
		$this->db->where('posisi',$posisi);
		$query = $this->db->get();
		//echo $query->num_rows(); die();
		if ($query->num_rows()>=1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	
	//Menampilkan semua data pelamar yang belum diproses di beranda
	function lamaranMasuk()
	{
		$this->db->select('a.noDaftar,a.posisi, b.nama, b.email, b.hp, c.pathIjazah, d.pathNilai, e.pathSurat, f.pathKtp, g.pathNPWP, h.pathKK, i.pathCV, DATE_FORMAT(a.tglLamar, "%d-%m-%Y") day',false);//select your colum as new column name wich is converted as str ot date
		//yo can do select more.
		//$this->db->from('data_lamaran a'); 
		$this->db->join('data_diri b', 'b.noDaftar=a.noDaftar', 'left');		
		$this->db->join('dokumen_ijazah c', 'c.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_nilai d', 'd.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_surat e', 'e.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_ktp f', 'f.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_npwp g', 'g.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_kk h', 'h.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_cv i', 'i.noDaftar=a.noDaftar', 'left');
		$this->db->where('statusLamaran',0);
		$this->db->order_by('tglLamar','DESC');
		
		$query = $this->db->get('data_lamaran a'); 
        if($query->num_rows() != 0)
        {
            return $query->result();
        }
        else
        {
            return false;
        }
	}
	
    //Menampilkan semua data pelamar yang belum diproses di beranda
	function lamaranMasuk2()
	{
		$this->db->select('a.noDaftar,a.posisi, b.nama, b.email, b.hp, c.pathIjazah, d.pathNilai, e.pathSurat, f.pathKtp, g.pathNPWP, h.pathKK, i.pathCV, j.pathFoto, DATE_FORMAT(a.tglLamar, "%d-%m-%Y") day',false);//select your colum as new column name wich is converted as str ot date
		//yo can do select more.
		//$this->db->from('data_lamaran a'); 
		$this->db->join('data_diri b', 'b.noDaftar=a.noDaftar', 'left');		
		$this->db->join('dokumen_ijazah c', 'c.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_nilai d', 'd.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_surat e', 'e.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_ktp f', 'f.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_npwp g', 'g.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_kk h', 'h.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_cv i', 'i.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_foto j', 'j.noDaftar=j.noDaftar', 'left');
		$this->db->where('statusLamaran',0);
		$this->db->order_by('tglLamar','DESC');
		
		$query = $this->db->get('data_lamaran a'); 
        if($query->num_rows() != 0)
        {
            return $query->result();
        }
        else
        {
            return false;
        }
	}
	
	//Menampilkan data pelamar yang akan diproses
	function infoPelamar($num,$offset)
	{
	$this->db->select('a.noDaftar,a.posisi, a.statusUndangan, b.nama, b.email, b.hp, c.pathIjazah, d.pathNilai, e.pathSurat, f.pathKtp, g.pathNPWP, h.pathKK, i.pathCV,  DATE_FORMAT(a.tglLamar, "%d-%m-%Y") day',false);//select your colum as new column name wich is converted as str ot date
		//yo can do select more.
		$this->db->from('data_lamaran a'); 
		$this->db->join('data_diri b', 'b.noDaftar=a.noDaftar', 'left');		
		$this->db->join('dokumen_ijazah c', 'c.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_nilai d', 'd.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_surat e', 'e.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_ktp f', 'f.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_npwp g', 'g.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_kk h', 'h.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_cv i', 'i.noDaftar=a.noDaftar', 'left');
		$this->db->where('statusLamaran',1);
		$this->db->order_by('day','DESC');
		$query = $this->db->get(); 
            if($query->num_rows() != 0)
            {
                return $query->result();
            }
            else
            {
                return false;
            }
	}
	
	//Mengubah status lamaran diterima
	function lamaranDiterima($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar)->update('data_lamaran', array('statusLamaran'=>1));
	}
	
	//Mengubah status lamaran ditolak
	function lamaranDitolak($noDaftar)
	{
		$this->db->delete('data_lamaran', array('noDaftar'=>$noDaftar));
		$this->db->delete('data_diri', array('noDaftar'=>$noDaftar));
		$this->db->delete('data_keluarga', array('noDaftar'=>$noDaftar));
		$this->db->delete('data_saudara', array('noDaftar'=>$noDaftar));
		$this->db->delete('data_anak', array('noDaftar'=>$noDaftar));
		$this->db->delete('data_pasangan', array('noDaftar'=>$noDaftar));
		$this->db->delete('data_pendidikanformal', array('noDaftar'=>$noDaftar));
		$this->db->delete('data_pendidikannonformal', array('noDaftar'=>$noDaftar));
		$this->db->delete('data_kemampuanbahasa', array('noDaftar'=>$noDaftar));
        $this->db->delete('data_organisasi', array('noDaftar'=>$noDaftar));
		$this->db->delete('data_pengalamanmemimpin', array('noDaftar'=>$noDaftar));
        $this->db->delete('data_pekerjaan', array('noDaftar'=>$noDaftar));
        $this->db->delete('data_referensi', array('noDaftar'=>$noDaftar));
        $this->db->delete('data_pertanyaan', array('noDaftar'=>$noDaftar));
        $this->db->delete('dokumen_foto', array('noDaftar'=>$noDaftar));
        $this->db->delete('dokumen_ktp', array('noDaftar'=>$noDaftar));
		$this->db->delete('dokumen_ijazah', array('noDaftar'=>$noDaftar));
        $this->db->delete('dokumen_nilai', array('noDaftar'=>$noDaftar));
        $this->db->delete('dokumen_surat', array('noDaftar'=>$noDaftar));
        $this->db->delete('dokumen_npwp', array('noDaftar'=>$noDaftar));
        $this->db->delete('dokumen_kk', array('noDaftar'=>$noDaftar));
        $this->db->delete('dokumen_cv', array('noDaftar'=>$noDaftar));
	}
	
	//Mengubah status undangan
	function ubahStatusUndangan($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar)->update('data_lamaran', array('statusUndangan'=>1));
	}
	
	//Memfilter Pelamar sesuai posisi
	function pelamarsesuaiposisi($num,$offset,$posisi)
	{
		$this->db->select('a.noDaftar,a.posisi, a.statusUndangan, b.nama, b.email, b.hp, c.pathIjazah, d.pathNilai, e.pathSurat, f.pathKtp, g.pathNPWP, h.pathKK, i.pathCV,  DATE_FORMAT(a.tglLamar, "%d-%m-%Y") day',false);//select your colum as new column name wich is converted as str ot date
		//yo can do select more.
		$this->db->from('data_lamaran a'); 
		$this->db->join('data_diri b', 'b.noDaftar=a.noDaftar', 'left');		
		$this->db->join('dokumen_ijazah c', 'c.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_nilai d', 'd.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_surat e', 'e.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_ktp f', 'f.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_npwp g', 'g.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_kk h', 'h.noDaftar=a.noDaftar', 'left');
		$this->db->join('dokumen_cv i', 'i.noDaftar=a.noDaftar', 'left');
		$this->db->where('statusLamaran',1);
		$this->db->where('posisi',$posisi);
		$this->db->order_by('day','DESC');
		$query = $this->db->get(); 
            if($query->num_rows() != 0)
            {
                return $query->result();
            }
            else
            {
                return false;
            }
	}
	
	function pilihpelamar($noDaftar)
	{
		 return $this->db->get_where('data_diri', array('noDaftar'=>$noDaftar))->row();
	}
	

	/*|-----------------------------------------------------------------|
	  |   	             Fungsi Simpan Data Pelamar                     |
	  |                                                                 |
	  ------------------------------------------------------------------|*/

//Fungsi Simpan Data Pelamar	
	
	function simpanlamaran($upload)
	{
		$tgl_apply = $this->input->post('tgl_apply');
		$posisi = $this->input->post('posisi');
		$nama = $this->input->post('nama');
		$email=$this->input->post('email');
		$nohp = $this->input->post('nohp');
		$alamat = $this->input->post('alamat');
		$pendidikan = $this->input->post('pendidikan');
		$data = array('tglLamar'=>$tgl_apply, 
					  'posisi'=>$posisi, 
					  'nama'=>$nama, 
					  'email'=>$email,
					  'nohp'=>$nohp,
					  'alamat'=>$alamat,
					  'pendidikan'=>$pendidikan,
					  'lamaran'=>$upload);
		$this->db->insert('lamaran',$data);	
	}
	
	//tambahan
	
	function dataLamaran($noDaftar)
	{
		//return $this->db->get('data_diri')->row();
		 return $this->db->get_where('data_lamaran', array('noDaftar'=>$noDaftar))->row();
	}
	
	function dokumenFoto($noDaftar)
	{
		//return $this->db->get('data_diri')->row();
		 return $this->db->get_where('dokumen_foto', array('noDaftar'=>$noDaftar))->row();
	} 
	
	function dataDiri($noDaftar)
	{
		//return $this->db->get('data_diri')->row();
		 return $this->db->get_where('data_diri', array('noDaftar'=>$noDaftar))->row();
	}
	
	function dataKeluarga($noDaftar)
	{
		//return $this->db->get('data_keluarga')->row();
		 return $this->db->get_where('data_keluarga', array('noDaftar'=>$noDaftar))->row();
	}
	
	function dataSaudara($noDaftar)
	{
		//return $this->db->get('data_saudara')->result();
		return $this->db->get_where('data_saudara', array('noDaftar'=>$noDaftar))->result();
	}
	
	function cekAnak($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('data_anak');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function dataAnak($noDaftar)
	{
		//return $this->db->get('data_saudara')->result();
		return $this->db->get_where('data_anak', array('noDaftar'=>$noDaftar))->result();
	}
	
	
	function cekStatusKawin($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('data_pasangan');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function dataPasangan($noDaftar)
	{
		//return $this->db->get('data_pasangan')->row();
		 return $this->db->get_where('data_pasangan', array('noDaftar'=>$noDaftar))->row();
	}
	
	function dataPendidikanFormal($noDaftar)
	{
		//return $this->db->get('data_pendidikanformal')->result();
		 return $this->db->get_where('data_pendidikanformal', array('noDaftar'=>$noDaftar))->result();
	}
	
	function cekNonFormal($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('data_pendidikannonformal');
		$data_anak=$noDaftar;
		if ($query->num_rows()>=1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function dataPendidikanNonFormal($noDaftar)
	{
		//return $this->db->get('data_pendidikannonformal')->result();
		 return $this->db->get_where('data_pendidikannonformal', array('noDaftar'=>$noDaftar))->result();
	}
	
	
	function cekBahasa($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('data_kemampuanbahasa');
		if ($query->num_rows()>=1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function dataKemampuanBahasa($noDaftar)
	{
		//return $this->db->get('data_kemampuanbahasa')->result();
		 return $this->db->get_where('data_kemampuanbahasa', array('noDaftar'=>$noDaftar))->result();
	}
	
	function cekOrganisasi($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('data_organisasi');
		if ($query->num_rows()>=1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function dataOrganisasi($noDaftar)
	{
		//return $this->db->get('data_organisasi')->result();
		 return $this->db->get_where('data_organisasi', array('noDaftar'=>$noDaftar))->result();
	}
	
	function cekLeader($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('data_pengalamanmemimpin');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function dataPengalamanMemimpin($noDaftar)
	{
		//return $this->db->get('data_pengalamanmemimpin')->row();
		return $this->db->get_where('data_pengalamanmemimpin', array('noDaftar'=>$noDaftar))->row();
	}
	
	function cekKerja($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('data_pekerjaan');
		if ($query->num_rows()>=1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	
	function dataPekerjaan($noDaftar)
	{
		//return $this->db->get('data_pekerjaan')->result();
		 return $this->db->get_where('data_pekerjaan', array('noDaftar'=>$noDaftar))->result();
	}
	
	function dataReferensi($noDaftar)
	{
		//return $this->db->get('data_referensi')->result();
		return $this->db->get_where('data_referensi', array('noDaftar'=>$noDaftar))->result();
	}
	
	function cekPertanyaan($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('data_pertanyaan');
		if ($query->num_rows()>=1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function dataPertanyaan($noDaftar)
	{
		//return $this->db->get('data_pertanyaan')->row();
		 return $this->db->get_where('data_pertanyaan', array('noDaftar'=>$noDaftar))->row();
	}
	
	//baru
	
	function simpanAkun()
	{	
		$posisi = $this->input->post('posisi');
		$nama = $this->input->post('nama');
		$username = $this->input->post('username');
		$password = md5($this->input->post('password'));
		$email=$this->input->post('email');
		$data = array('posisi'=>$posisi, 
					  'nama'=>$nama, 
					  'username'=>$username,
					  'password'=>$password,
					  'email'=>$email);
		$this->db->insert('temp_akun',$data);	
	}
	
	//Simpan Data Diri
	function simpanDataDiri($username){
	    $cek = $this->input->post('jnsSim');
		if($this->input->post('jnsSim')==3){
			$sim="";
		} else{
			$sim=$this->input->post('sim');
		}
		
		$dataDiri = array(
			'username'=>$username,
			'nama' =>$this->input->post('nama'),
			'panggilan' =>$this->input->post('panggilan'),
			'tempatLahir' =>$this->input->post('tempatLahir'),
			'tglLahir' =>$this->input->post('tglLahir'),
			'jkel' =>$this->input->post('jkel'),
			'agama' =>$this->input->post('agama'),
			'alamatKtp' =>$this->input->post('alamatKtp'),
			'alamatTinggal' =>$this->input->post('alamatTinggal'),
			'hp' =>$this->input->post('hp'),
			'email' =>$this->input->post('email'),
			'telp' =>$this->input->post('telp'),
			'npwp' =>$this->input->post('npwp'),
			'hobi' =>$this->input->post('hobi'),
			'sim' =>$sim,
			'ktp' =>$this->input->post('ktp'),
			'bca' =>$this->input->post('bca'),
			'jnsSim' =>$this->input->post('jnsSim'),
			'jamsostek' =>$this->input->post('jamsostek')			
		);
		
		$this->db->insert('data_diri',$dataDiri);	
	}
	
//Simpan Data Keluarga, Saudara, pasangan, dan data_anak	
	function simpanDataKeluarga($username){
		
		//data keluarga
		$dataKeluarga = array(
			'username'=>$username,
			'nmAyah' =>$this->input->post('nmAyah'),
			'usiaAyah' =>$this->input->post('usiaAyah'),
			'pendidikanAyah' =>$this->input->post('pendidikanAyah'),
			'pekerjaanAyah' =>$this->input->post('pekerjaanAyah'),
			'nmIbu' =>$this->input->post('nmIbu'),
			'usiaIbu' =>$this->input->post('usiaIbu'),
			'pendidikanIbu' =>$this->input->post('pendidikanIbu'),
			'pekerjaanIbu' =>$this->input->post('pekerjaanIbu')				
		);
		$this->db->insert('data_keluarga',$dataKeluarga);	
		
		//data saudara
		$dataSaudara = array();
		for($a = 0; $a < count($_POST['nmSaudara']); $a++)
        {
            if($_POST['nmSaudara'][$a] != '')
            {
                $dataSaudara[] = array('username' => $username,
							            'nmSaudara' => $_POST['nmSaudara'][$a],
							            'jkelSaudara' => $_POST['jkelSaudara'][$a],
										'usiaSaudara'=>$_POST['usiaSaudara'][$a],
										'pendidikanSaudara'=>$_POST['pendidikanSaudara'][$a],
										'pekerjaanSaudara'=>$_POST['pekerjaanSaudara'][$a]);
            }
        }
        $this->db->insert_batch('data_saudara', $dataSaudara);
		
		//data pasangan
		if ($this->input->post('statusKawin')==1 || $this->input->post('statusKawin')==3){
			$dataKawin = array(
				'username' =>$username,
				'statusKawin' =>$this->input->post('statusKawin'),
				'nmPasangan' =>$this->input->post('nmPasangan'),
				'usiaPasangan' =>$this->input->post('usiaPasangan'),
				'pendidikanPasangan' =>$this->input->post('pendidikanPasangan'),
				'pekerjaanPasangan' =>$this->input->post('pekerjaanPasangan')			
			);
			$this->db->insert('data_pasangan', $dataKawin);
		}
		
		//data data_anak
		if ($this->input->post('anak')==1){
			$dataAnak = array();
			for($b = 0; $b < count($_POST['nmAnak']); $b++)
			{
				if($_POST['nmAnak'][$b] != '')
				{
					$dataAnak[] = array('username' => $username,
									'nmAnak' => $_POST['nmAnak'][$b],
									'jkelAnak' => $_POST['jkelAnak'][$b],
									'usiaAnak'=>$_POST['usiaAnak'][$b],
									'pendidikanAnak'=>$_POST['pendidikanAnak'][$b],
									'pekerjaanAnak'=>$_POST['pekerjaanAnak'][$b]);
				}
			}
			$this->db->insert_batch('data_anak', $dataAnak);
		} 
	}

//Fungsi Simpan Data Pendidikan Formal, Non Formal & Kemampuan Bahasa	
	function simpanDataPendidikan($username){	
		
		//pendidikan formal
		$pendidikanFormal = array();
		for($c = 0; $c < count($_POST['jenjangPendidikan']); $c++)
        {
            if($_POST['jenjangPendidikan'][$c] != '')
            {
                $pendidikanFormal[] = array('username' => $username,
							            'jenjangPendidikan' => $_POST['jenjangPendidikan'][$c],
							            'nmInstansi' => $_POST['nmInstansi'][$c],
										'kotaInstansi'=>$_POST['kotaInstansi'][$c],
										'thnMasuk'=>$_POST['thnMasuk'][$c],
										'thnKeluar'=>$_POST['thnKeluar'][$c],
										'kelulusan'=>$_POST['kelulusan'][$c],
										'jurusan'=>$_POST['jurusan'][$c]);
            }
        }
        $this->db->insert_batch('data_pendidikanformal', $pendidikanFormal);		
	
		//pendidikan non formal
		if($this->input->post('nonFormal')==1){
			$pendidikanNonFormal = array();
			for($d = 0; $d < count($_POST['nmInstansiNon']); $d++)
			{
				if($_POST['nmInstansiNon'][$d] != '')
				{
					$pendidikanNonFormal[] = array('username' => $username,
													'nmInstansiNon' => $_POST['nmInstansiNon'][$d],
													'tahunNon' => $_POST['tahunNon'][$d]);
				}
			}
			$this->db->insert_batch('data_pendidikannonformal', $pendidikanNonFormal);
		}
		
		//kemampuan bahasa
		if($this->input->post('bahasa')==1){
			$kemampuanBahasa = array();
			for($e = 0; $e < count($_POST['jnsBahasa']); $e++)
			{
				if($_POST['jnsBahasa'][$e] != '')
				{
					$kemampuanBahasa[] = array('username' => $username,
												'jnsBahasa' => $_POST['jnsBahasa'][$e],
												'penguasaan' => $_POST['penguasaan'][$e]);
				}
			}
			$this->db->insert_batch('data_kemampuanbahasa', $kemampuanBahasa);
		}
	}


//Fungsi Simpan Data data_organisasi	
	function simpanDataOrganisasi($username){	
		
		//data data_organisasi	
		if($this->input->post('org')==1){
			$data_organisasi = array();
			for($f = 0; $f < count($_POST['nmOrg']); $f++)
			{
				if($_POST['nmOrg'][$f] != '')
				{
					$data_organisasi[] = array('username' => $username,
											'nmOrg' => $_POST['nmOrg'][$f],
											'tahunOrg' => $_POST['tahunOrg'][$f]);
				}
			}
			$this->db->insert_batch('data_organisasi', $data_organisasi);
		}
		
		//data_pengalamanmemimpin
		if($this->input->post('leader')==1){
			$pengalamanLeader = array('username' =>$username,
									  'pengalamanLeader' =>$this->input->post('pengalamanLeader'));
				$this->db->insert('data_pengalamanmemimpin', $pengalamanLeader);
		}
	}
		
		
//Fungsi Simpan Data Riwayat Pekerjaan & data_referensi	
	function simpanDataPekerjaan($username){	
		//riwayat pekerjaan
		if($this->input->post('riwayat')==1){
			$riwayatKerja  = array();
			for($g = 0; $g < count($_POST['nmPerusahaan']); $g++)
			{
				if($_POST['nmPerusahaan'][$g] != '')
				{
					$riwayatKerja[] = array('username' => $username,
										'nmPerusahaan' => $_POST['nmPerusahaan'][$g],
										'alamatPerusahaan' => $_POST['alamatPerusahaan'][$g],
										'telpPerusahaan' => $_POST['telpPerusahaan'][$g],
										'jabatan' => $_POST['jabatan'][$g],
										'nmAtasan' => $_POST['nmAtasan'][$g],
										'tugas' => $_POST['tugas'][$g],
										'wMasuk' => $_POST['wMasuk'][$g],
										'wKeluar' => $_POST['wKeluar'][$g],
										'gAwal' => $_POST['gAwal'][$g],
										'gAkhir' => $_POST['gAkhir'][$g],
										'alasanKeluar' => $_POST['alasanKeluar'][$g]);
				}
			}
			$this->db->insert_batch('data_pekerjaan', $riwayatKerja);
		}	
		
		//data_referensi
		$data_referensi  = array();
		for($h = 0; $h < count($_POST['nmReferensi']); $h++)
        {
            if($_POST['nmReferensi'][$h] != '')
            {
                $data_referensi[] = array('username' => $username,
							        'nmReferensi' => $_POST['nmReferensi'][$h],
							        'alamatReferensi' => $_POST['alamatReferensi'][$h],
									'telpReferensi' => $_POST['telpReferensi'][$h],
									'pekerjaanReferensi' => $_POST['pekerjaanReferensi'][$h],
									'hubunganReferensi' => $_POST['hubunganReferensi'][$h]);
            }
        }
		$this->db->insert_batch('data_referensi', $data_referensi);
	}
	

//Fungsi Simpan Data data_pertanyaan	
	function simpanDataPertanyaan($username){
		if($this->input->post('sakit')==1){
			$descSakit=$this->input->post('descSakit');
		}else{ $descSakit="";}
	
		$data_pertanyaan = array(
			'username' =>$username,
			'descSakit' =>$descSakit,
			'kelebihan' =>$this->input->post('kelebihan'),
			'kekurangan' =>$this->input->post('kekurangan'),
			'keahlian' =>$this->input->post('keahlian'),
			'jobDesc' =>$this->input->post('jobDesc'),
			'harapanGaji' =>$this->input->post('harapanGaji'),
			'tunjangan' =>$this->input->post('tunjangan'),
			'mulaiKerja' =>$this->input->post('mulaiKerja'),
			'penempatan' =>$this->input->post('penempatan'),
			'alasanGabung' =>$this->input->post('alasanGabung'),
			'tentangMugen' =>$this->input->post('tentangMugen'),
			'lingkunganKerja' =>$this->input->post('lingkunganKerja')
		);
		$this->db->insert('data_pertanyaan', $data_pertanyaan);
	}
	
	function simpanFoto($upload,$username)
    {
        //echo $upload; die();
        $data=array('username'=>$username,
        'pathFoto'=>$upload);
        $this->db->insert('dokumen_foto',$data);
    }
	
	function simpanKTP($upload,$username)
    {
        //echo $upload; die();
        $data=array('username'=>$username,
        'pathKTP'=>$upload);
        $this->db->insert('dokumen_ktp',$data);
    }
	
	function simpanIjazah($upload,$username)
    {
        //echo $upload; die();
        $data=array('username'=>$username,
        'pathIjazah'=>$upload);
        $this->db->insert('dokumen_ijazah',$data);
    }
	
	function simpanNilai($upload,$username)
    {
        //echo $upload; die();
        $data=array('username'=>$username,
        'pathNilai'=>$upload);
        $this->db->insert('dokumen_nilai',$data);
    }
	
	function simpanSurat($upload,$username)
    {
        //echo $upload; die();
        $data=array('username'=>$username,
        'pathSurat'=>$upload);
        $this->db->insert('dokumen_surat',$data);
    }
	
	function simpanNPWP($upload,$username)
    {
        //echo $upload; die();
        $data=array('username'=>$username,
        'pathNPWP'=>$upload);
        $this->db->insert('dokumen_npwp',$data);
    }
	
	function simpanCV($upload,$username)
    {
        //echo $upload; die();
        $data=array('username'=>$username,
        'pathCV'=>$upload);
        $this->db->insert('dokumen_cv',$data);
    }
	
	function simpanKK($upload,$username)
    {
        //echo $upload; die();
        $data=array('username'=>$username,
        'pathKK'=>$upload);
        $this->db->insert('dokumen_kk',$data);
    }
	
	function cekPosisi($username)
	{
		return $this->db->get_where('temp_akun', array('username'=>$username))->row();
	}
	
	function cekDataDiri($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('data_diri');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekDataDiri2($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('data_diri');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekDataKeluarga($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('data_keluarga');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekDataPendidikan($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('data_pendidikanformal');
		if ($query->num_rows()>=1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekDataOrganisasi($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('data_organisasi');
		if ($query->num_rows()>=1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekDataPekerjaan($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('data_pekerjaan');
		if ($query->num_rows()>=1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekDataReferensi($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('data_referensi');
		if ($query->num_rows()>=1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekDataPertanyaan($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('data_pertanyaan');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekFoto($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('dokumen_foto');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekFoto2($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('dokumen_foto');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekKTP($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('dokumen_ktp');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekKTP2($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('dokumen_ktp');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekIjazah($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('dokumen_ijazah');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
    function cekIjazah2($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('dokumen_ijazah');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekNilai($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('dokumen_nilai');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekNilai2($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('dokumen_nilai');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekSurat($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('dokumen_surat');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
    function cekSurat2($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('dokumen_surat');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekNPWP($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('dokumen_npwp');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekNPWP2($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('dokumen_npwp');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}

	
	function cekKK($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('dokumen_kk');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekKK2($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('dokumen_kk');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	
	function cekCV($username)
	{
		$this->db->where('username',$username);
		$query=$this->db->get('dokumen_cv');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	function cekCV2($noDaftar)
	{
		$this->db->where('noDaftar',$noDaftar);
		$query=$this->db->get('dokumen_cv');
		if ($query->num_rows()==1)
		{
			return TRUE;
		} else {
			return FALSE;
		}
	}
	
	
	//membuat generate kode noDaftar
	function generateIdLamaran()
	{
		$query = $this->db->query("SELECT concat(IF(count(tglLamar) >=0 and count(tglLamar<=9),'0',''),
    cast(count(tglLamar) as char(3))) as id2 FROM data_lamaran WHERE day(tglLamar) = DAY(CURDATE()) and month(tglLamar) = MONTH(CURDATE()) and YEAR(tglLamar) = YEAR(CURDATE())");
		return $query->row();			  
	} 
	
	function simpanDataLamaran($noDaftar,$posisi){	
		
		$lamaran = array(
			
			'posisi' =>$posisi,
			'tglLamar' =>date("Y-m-d H:i:s"),
			'noDaftar'=>$noDaftar);

		$this->db->insert('data_lamaran', $lamaran);
	}
	
	//fungsi cek no daftar eksis****************************************
	function cekNoDaftar ($noDaftar){
		$this->db->select('noDaftar');
		$this->db->from('data_lamaran');
		$this->db->where('noDaftar',$noDaftar);
		$query = $this->db->get();
		//echo $query->num_rows(); die();
		if ($query->num_rows()=0)
		{
			return TRUE;
		} else {
			return FALSE;
		}
		
	}
	
	function cekPosisi($username)
	{
		return $this->db->get_where('temp_akun', array('username'=>$username))->row();
	}
	
	
	function ubahDataLamaran($username, $noDaftar)
	{
		$data = array('noDaftar'=>$noDaftar, 
					  'username'=>'');
        $this->db->where('username',$username)->update('data_diri', $data);
		
        $this->db->where('username',$username)->update('data_keluarga', $data);
		
		$this->db->where('username',$username)->update('data_saudara', $data);
		
        $this->db->where('username',$username)->update('data_anak', $data);
		
        $this->db->where('username',$username)->update('data_pasangan', $data);
		
        $this->db->where('username',$username)->update('data_pendidikanformal', $data);
	
        $this->db->where('username',$username)->update('data_pendidikannonformal', $data);
		
        $this->db->where('username',$username)->update('data_kemampuanbahasa', $data);
		
        $this->db->where('username',$username)->update('data_organisasi', $data);
		
        $this->db->where('username',$username)->update('data_pengalamanmemimpin', $data);	
		
        $this->db->where('username',$username)->update('data_pekerjaan', $data);
		
        $this->db->where('username',$username)->update('data_referensi', $data);
		
        $this->db->where('username',$username)->update('data_pertanyaan', $data);
		
        $this->db->where('username',$username)->update('dokumen_foto', $data);
		
		$this->db->where('username',$username)->update('dokumen_ktp', $data);
				
        $this->db->where('username',$username)->update('dokumen_ijazah', $data);
				
        $this->db->where('username',$username)->update('dokumen_nilai', $data);
		
		$this->db->where('username',$username)->update('dokumen_surat', $data);
		
		$this->db->where('username',$username)->update('dokumen_npwp', $data);
		
		$this->db->where('username',$username)->update('dokumen_cv', $data);
		
		$this->db->where('username',$username)->update('dokumen_kk', $data);
	}
	
	function hapusAkun($username)
	{
        $this->db->delete('temp_akun', array('username'=>$username));
	}
}
?>
