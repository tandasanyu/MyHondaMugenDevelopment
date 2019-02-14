<?php
class M_promosi extends CI_Model{

	function semuaevent($num,$offset)
	{
		$this->db->select('nm_event,id_event,keterangan,str_to_date(tgl_event, "%d-%m-%Y") day',false);//select your colum as new column name wich is converted as str ot date
		//yo can do select more.
		$this->db->order_by('day','DESC'); 
		return $this->db->get('event',$num,$offset)->result();
	}
	
	function eventindex()
	{
		$this->db->select('nm_event,keterangan,str_to_date(tgl_event, "%d-%m-%Y") day',false);//select your colum as new column name wich is converted as str ot date
		//yo can do select more.
		$this->db->order_by('day','DESC');
		return $this->db->get('event',3)->result();
		
		//$this->db->order_by("tgl_event","desc"); 
		//return $this->db->get('event',3)->result();
	}
      
	function simpanevent()
	{
		$nm_event=$this->input->post('nm_event');
		$tgl_event = $this->input->post('tgl_event');
		$keterangan = $this->input->post('keterangan');
		$data = array('nm_event'=>$nm_event, 
					  'tgl_event'=>$tgl_event, 
					  'keterangan'=>$keterangan);
		$this->db->insert('event',$data);	
	}

	function hapusevent($id_event)
	{
        $this->db->delete('event', array('id_event'=>$id_event));
	}
	
	function editevent($id_event)
	{
		$this->db->where('id_event',$id_event)->update('event', $_POST);
	}

	function pilihevent($id_event)
	{
        return $this->db->get_where('event', array('id_event'=>$id_event))->row();
    }
	
	function simpantestdrive()
	{
		$nama = $this->input->post('nama');
		$nohp = $this->input->post('nohp');
		$email = $this->input->post('email');
		$alamat=$this->input->post('alamat');
		$tgl = $this->input->post('tgl');
		$jam = $this->input->post('jam');
		$lokasi = $this->input->post('lokasi');
		$kendaraan = $this->input->post('kendaraan');
		$data = array('nama'=>$nama, 
					  'nohp'=>$nohp, 
					  'email'=>$email,
					  'alamat'=>$alamat,
					  'tgl'=>$tgl,
					  'jam'=>$jam,
					  'lokasi'=>$lokasi,
					  'kendaraan'=>$kendaraan);
		$this->db->insert('testdrive',$data);	
	}
	
	function semuatestdrive()
	{
		$this->db->order_by("tgl","desc"); 
		return $this->db->get('testdrive')->result();
	}
	
	function semuatestdriveindex()
	{
		$tgl=date('d-m-Y');	
		$this->db->order_by("jam","asc"); 
		return $this->db->get_where('testdrive', array('tgl'=>$tgl,'status'=>1))->result();
	}
	
	function caritestdrive($tgl2)
	{
		$this->db->order_by("jam","asc"); 
		return $this->db->get_where('testdrive', array('tgl'=>$tgl2,'status'=>1))->result();
	}
	function caritestdrive2($tgl2,$lokasi)
	{
		$this->db->order_by("jam","asc"); 
		return $this->db->get_where('testdrive', array('tgl'=>$tgl2,'lokasi'=>$lokasi,'status'=>1))->result();
	}
	
	function datatestdrive($id_testdrive)
	{
		return $this->db->get_where('testdrive', array('id_testdrive'=>$id_testdrive))->row();
	}
	
	function approvetestdrive($id_testdrive)
	{
		$this->db->where('id_testdrive',$id_testdrive)->update('testdrive', array('status'=>1));
	}

	function kredit($tipe,$tenor)
	{
		//$tipe=$this->input->post('tipe');
	
		//$harga=$this->input->post('harga');
		//$tenor=$this->input->post('tenor');
        return $this->db->get_where('cicilan', array('tipe'=>$tipe,'tenor'=>$tenor))->row();
    }
    
    function simpanbookingpud()
	{
	    $booking_tgl = Date('d-m-y');
		$booking_nama = $this->input->post('booking_nama');
		$booking_nopol = $this->input->post('booking_nopol');
		$booking_tlp = $this->input->post('booking_tlp');
		$booking_tipe = $this->input->post('booking_tipe');
		$booking_email = $this->input->post('booking_email');
		$booking_jadwal = $this->input->post('booking_jadwal');
		$booking_jam = $this->input->post('booking_jam');
		$noacak=(rand(1000,9999));
		$booking_id = 'SRV'.date('dmy').$noacak;
		if ($this->input->post('booking_lokasi')=="Honda Mugen Ps. Minggu"){
		    $booking_lokasi=1;
		}elseif ($this->input->post('booking_lokasi')=="Honda Mugen Puri"){
		    $booking_lokasi=2;
		}
		$data = array('booking_jadwal'=>$booking_jadwal, 
		              'booking_id'=>$booking_id, 
					  'booking_nama'=>$booking_nama, 
					  'booking_tlp'=>$booking_tlp, 
					  'booking_nopol'=>$booking_nopol, 
					  'booking_email'=>$booking_email,
					  'booking_tgl'=>$booking_tgl,
					  'booking_jam'=>$booking_jam,
					  'booking_lokasi'=>$booking_lokasi);
		$this->db->insert('data_booking',$data);	
	}
	
	function semuaBookingPUDPasmingIndex()
	{
		$tgl=date('d-m-Y');	
		$this->db->order_by("booking_jam","asc"); 
		return $this->db->get_where('data_booking', array('booking_jadwal'=>$tgl,'booking_lokasi'=>1))->result();
	}
	
	function semuaBookingPUDPuriIndex()
	{
		$tgl=date('d-m-Y');	
		$this->db->order_by("booking_jam","asc"); 
		return $this->db->get_where('data_booking', array('booking_jadwal'=>$tgl,'booking_lokasi'=>2))->result();
	}
	
	function hitungBookingPUDPasming($tgl2)
	{
		$this->db->where('booking_jadwal',$tgl2);
		$this->db->where('booking_lokasi','1');
		$num = $this->db->count_all_results('data_booking');
		return $num;
	}
	
	function hitungBookingPUDPuri($tgl2)
	{
		$this->db->where('booking_jadwal',$tgl2);
		$this->db->where('booking_lokasi','2');
		$num = $this->db->count_all_results('data_booking');
		return $num;
	}
	
	function hitungJamBookingPUD1($tgl2,$lokasi)
	{
		$this->db->where('booking_jadwal',$tgl2);
		$this->db->where('booking_lokasi',$lokasi);
		$this->db->where('booking_jam','13.00');	
		$num = $this->db->count_all_results('data_booking');
		return $num;
	}
	
	function hitungJamBookingPUD2($tgl2,$lokasi)
	{
		$this->db->where('booking_jadwal',$tgl2);
		$this->db->where('booking_lokasi',$lokasi);
		$this->db->where('booking_jam','14.00');	
		$num = $this->db->count_all_results('data_booking');
		return $num;
	}
	
	function caribookingPUDPasming($tgl2)
	{
		$this->db->order_by("booking_jam","asc"); 
		return $this->db->get_where('data_booking', array('booking_jadwal'=>$tgl2,'booking_lokasi'=>1))->result();
	}
	
	function caribookingPUDPuri($tgl2)
	{
		$this->db->order_by("booking_jam","asc"); 
		return $this->db->get_where('data_booking', array('booking_jadwal'=>$tgl2,'booking_lokasi'=>2))->result();
	}
	
	function databookingpud($booking_id)
	{
		return $this->db->get_where('data_booking', array('booking_id'=>$booking_id))->row();
	}
	
	function approvebookingService($booking_id)
	{
		$this->db->where('booking_id',$booking_id)->update('data_booking', array('booking_status'=>1));
	}
	
	function semuabookingpud()
	{
		$this->db->select('booking_id, booking_nama, booking_tipe, booking_jam, booking_email, booking_jadwal, booking_tlp, booking_nopol, str_to_date(booking_tgl, "%d-%m-%Y") day',false);//select your colum as new column name wich is converted as str ot date
		//yo can do select more.
		$this->db->order_by('day','DESC'); 
		return $this->db->get('data_booking')->result();
	}
	
	function semuaslide()
	{
		$this->db->order_by("id_slide","desc"); 
		return $this->db->get('data_slide')->result();
	}
	
    function simpanBanner($upload)
    {
        //echo $upload; die();
        $data=array('path'=>$upload);
        $this->db->insert('data_slide',$data);
    }
    
    function hapusBanner($id_slide)
	{
        $this->db->delete('data_slide', array('id_slide'=>$id_slide));
	}
	
	function pilihBanner($id_slide)
	{
        return $this->db->get_where('data_slide', array('id_slide'=>$id_slide))->row();
    }
}
?>
