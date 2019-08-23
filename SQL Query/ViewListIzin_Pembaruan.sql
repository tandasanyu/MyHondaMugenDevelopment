 create view DetailIzin_Revisi as 
 
 SELECT Details.izin_id,
     b.izin_nik AS NIK,
	 h.IZIN_NAMA,
	 CASE 
		WHEN h.IZIN_NIK_APPVMNG ='--' THEN NULL
		WHEN h.IZIN_NIK_APPVMNG <>'--' THEN h.IZIN_NIK_APPVMNG 
		END as NIKMNG, 
	 h.IZIN_NIK_APPVSPV as NIKSPV,
	 (select staff_nama from data_staff where staff_nik = h.IZIN_NIK_APPVSPV) as Atasan1,
	 --b.IZIN_TGLAPPVSPV,
	 case 
		when  h.IZIN_NIK_APPVMNG = '--'
		then '--'
		when h.IZIN_NIK_APPVMNG <> '--'
		then (select staff_nama from data_staff where staff_nik = h.IZIN_NIK_APPVMNG)
		end as Atasan2
	 ,
	 --h.IZIN_NIK_APPVMNG,
	 b.IZIN_TGLAPPVMNG,
	 b.IZIN_TGLAPPVSPV,
	 Details.id_detail,
     b.izin_jenis,
     b.izin_alasan,
     Details.izin_tgldetail,
	 (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) as TglDeadline,
	 --Details.izin_status,
	 case 
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) < CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null 
		then 'Expired' -- untuk case expired
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null
		then 'Pending'
		--when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) < CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		--and Details.izin_status ='Pending'
		--then 'Expired'
		--when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) < CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		--and Details.izin_status ='Disetujui Atasan'
		--then 'Expired'
		--when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) < CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		--and Details.izin_status ='Disetujui Manajer'
		--then 'Expired'
		when Details.izin_status is not null
		then Details.izin_status
		end as Status_Izin,
     Details.Source,
     Details.Flag
   FROM DATA_IZIN_BODY b 
   JOIN 
          (SELECT izin_id, izin_nik, izin_tgldetail,  izin_status, izin_id_detail as id_detail
		   ,'DT' AS Source, FLAG
           FROM DATA_IZIN_DETAIL

           UNION ALL

          SELECT izin_id, izin_nik, izin_tgldetail, izin_status, izin_id_detailpc as id_detail
		   ,'PC' AS Source, FLAG
           FROM DATA_IZIN_DETAILPC) AS Details
   
   ON b.izin_id = Details.izin_id  
   join 
   data_izin_header h
   on b.izin_nik = h.IZIN_NIK 
   where Details.izin_id = '10441'
   where IZIN_NIK_APPVMNG = '16' or IZIN_NIK_APPVSPV = '16' 
   and IZIN_TGLDEADLINE >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
   order by IZIN_TGLDEADLINE desc

	 ----masih belum sempurna / ketika tgl appv mng ada status masih expired NIKMNG & NIKSPV = '462'
	    SELECT * FROM [DetailPengajuanIzin] 
   WHERE (([NIKMNG] = '462') OR ([NIKSPV] = '462'))  order by status_izin desc
   --
   --drop view DetailIzin_Revisi
   --
   select * from DetailIzin_Revisi
   where (NIKMNG ='16' OR NIKSPV = '16') AND 
   (TglDeadline >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime))
----

		-- untuk case expired untuk 1 atasan (selain cuti biasa) - berarti 
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) < CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null and b.IZIN_TGLAPPVSPV is null and b.IZIN_JENIS <> 'Cuti'
		then 'Expired Selain Cuti' 
		-- untuk case expired untuk 2 atasan (cuti biasa)
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) < CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null and (b.IZIN_TGLAPPVSPV is null or b.IZIN_TGLAPPVMNG is null) and b.IZIN_JENIS = 'Cuti'
		then 'Expired Cuti' 

-- *** HAMPIR SELESAI***
		-- ***UNTUK CASE EXPIRED *** DONE 17/7/2019
		-- untuk case expired cuti biasa 1 atasan
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) < CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null and b.IZIN_TGLAPPVSPV is null and b.IZIN_JENIS = 'Cuti'
		and h.IZIN_NIK_APPVMNG = '--'
		then 'Expired Cuti 1 Atasan' 
		-- untuk case expired cuti biasa 2 atasan (case atasan1 blm apprv)
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) < CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null and b.IZIN_TGLAPPVSPV is null and b.IZIN_JENIS = 'Cuti'
		and h.IZIN_NIK_APPVMNG <> '--'
		then 'Expired Cuti 2 Atasan -- ATASAN 1 BLM APPRV' 
		-- untuk case expired cuti biasa 2 atasan (case atasan2 blm apprv / atasan 1 sudah apprv)
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) < CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null and b.IZIN_TGLAPPVSPV is NOT null and b.IZIN_TGLAPPVMNG is null and b.IZIN_JENIS = 'Cuti'
		and h.IZIN_NIK_APPVMNG <> '--'
		then 'Expired Cuti 2 Atasan -- ATASAN 1 SDH APPV / ATASAN 2 BLM APPRV' 
		-- untuk case expired selain cuti biasa (hanya 1 atasan)
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) < CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null and b.IZIN_TGLAPPVSPV is null and b.IZIN_JENIS <> 'Cuti'
		then 'Expired Selain Cuti' 
		-- ***UNTUK CASE EXPIRED *** DONE 17/7/2019
		-- ***UNTUK CASE APPROVAL *** 
		--1. CASE APPROVE CUTI BIASA // 1 ATASAN // "DISETUJUI ATASAN LANGSUNG"
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null and b.IZIN_STATUS <>'Pending' AND h.IZIN_NIK_APPVMNG = '--'
		AND b.IZIN_TGLAPPVSPV is NOT null and b.IZIN_JENIS = 'Cuti'
		then 'Disetujui Atasan Langsung -- CUTI BIASA' 
		--2. CASE APPROVE CUTI BIASA // 2 ATASAN // "DISETUJUI ATASAN 1TK LEBIH TINGGI"
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null and b.IZIN_STATUS <>'Pending' AND h.IZIN_NIK_APPVMNG <> '--'
		AND b.IZIN_TGLAPPVSPV is NOT null and b.IZIN_TGLAPPVMNG is not null and b.IZIN_JENIS = 'Cuti'
		then 'Disetujui Atasan 1tk Lebih Tinggi -- CUTI BIASA' 
		--3. CASE APPROVE SELAIN CUTI BIASA // 1 ATASAN // DI SETUJUI ATASAN LANGSUNG
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null and b.IZIN_STATUS <>'Pending' /*AND h.IZIN_NIK_APPVMNG = '--'*/
		AND b.IZIN_TGLAPPVSPV is NOT null and b.IZIN_JENIS <> 'Cuti'
		then 'Disetujui Atasan Langsung -- SELAIN CUTI BIASA' 
		-- ***UNTUK CASE APPROVAL *** 

/*
buat 2 view
1. untuk jenis izin cuti dan alasan izin cuti
	1.a ) ketika izin cuti di tampilan atasan : where jenis_izin= 'cuti' and alasan_izin = 'cuti' and nikspv = ? or nikmng = ?
	2.b.) ketika izin cuti atasanya 
2. untuk jenis izin selain cuti dan alasan izin selain cuti

*/



