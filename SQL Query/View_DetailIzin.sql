create view  ApprovalIzinDetail  as
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
		-- *** untuk case pending / DIBATALKAN STAFF / DIBATALKAN HRD
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null and b.IZIN_STATUS ='Pending'
		then 'Pending' 
		when b.IZIN_STATUS ='Dibatalkan Staff'
		then 'Dibatalkan Staff' 
		when b.IZIN_STATUS ='Dibatalkan HRD'
		then 'Dibatalkan HRD' 
		-- *** untuk case pending / DIBATALKAN STAFF / DIBATALKAN HRD
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
		when /*(select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and*/ Details.izin_status is null and b.IZIN_STATUS <>'Pending' AND h.IZIN_NIK_APPVMNG = '--'
		AND b.IZIN_TGLAPPVSPV is NOT null and b.IZIN_JENIS = 'Cuti'
		then 'Disetujui Atasan Langsung -- CUTI BIASA' 
		--2. CASE APPROVE CUTI BIASA // 2 ATASAN // "DISETUJUI ATASAN 1TK LEBIH TINGGI"
		when /*(select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and*/ Details.izin_status is null and b.IZIN_STATUS <>'Pending' AND h.IZIN_NIK_APPVMNG <> '--'
		AND b.IZIN_TGLAPPVSPV is NOT null and b.IZIN_TGLAPPVMNG is not null and b.IZIN_JENIS = 'Cuti'
		then 'Disetujui Atasan 1tk Lebih Tinggi -- CUTI BIASA' 
		--3. CASE APPROVE CUTI BIASA // 2 ATASAN // "DISETUJUI ATASAN 1TK LEBIH TINGGI"
		when /*(select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and*/ Details.izin_status is null and b.IZIN_STATUS <>'Pending' AND h.IZIN_NIK_APPVMNG <> '--'
		AND b.IZIN_TGLAPPVSPV is NOT null and b.IZIN_TGLAPPVMNG is null and b.IZIN_JENIS = 'Cuti'
		then 'Disetujui Atasan Langsung -- CUTI BIASA / DELAY' 
		--4. CASE APPROVE SELAIN CUTI BIASA // 1 ATASAN // DI SETUJUI ATASAN LANGSUNG
		when /*(select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) < CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and*/ Details.izin_status is null and b.IZIN_STATUS <>'Pending' 
		--AND h.IZIN_NIK_APPVMNG = '--'
		AND b.IZIN_TGLAPPVSPV is NOT null and b.IZIN_JENIS <> 'Cuti'
		then 'Disetujui Atasan Langsung -- SELAIN CUTI BIASA' 
		-- ***UNTUK CASE APPROVAL *** 
		else NULL
		/*b.IZIN_STATUS*/
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
   ORDER BY B.IZIN_TGLDEADLINE DESC

/*

SELECT        
Details.IZIN_ID, 
b.IZIN_NIK AS NIK, 
h.IZIN_NAMA, 
    CASE 
        WHEN h.IZIN_NIK_APPVMNG = '--' THEN NULL 
        WHEN h.IZIN_NIK_APPVMNG <> '--' THEN h.IZIN_NIK_APPVMNG 
        END AS NIKMNG,
h.IZIN_NIK_APPVSPV AS NIKSPV,
(SELECT STAFF_NAMA FROM dbo.DATA_STAFF WHERE (STAFF_NIK = h.IZIN_NIK_APPVSPV)) AS Atasan1, 
    CASE 
        WHEN h.IZIN_NIK_APPVMNG = '--' THEN '--' 
        WHEN h.IZIN_NIK_APPVMNG <> '--' THEN (SELECT staff_nama FROM data_staff WHERE staff_nik = h.IZIN_NIK_APPVMNG) 
        END AS Atasan2,
b.IZIN_TGLAPPVMNG, 
b.IZIN_TGLAPPVSPV, 
Details.id_detail, 
b.IZIN_JENIS, 
b.IZIN_ALASAN, 
b.IZIN_ALASANDETAIL,
Details.IZIN_TGLDETAIL,
b.IZIN_STATUS,
(SELECT IZIN_TGLDEADLINE FROM dbo.DATA_IZIN_BODY WHERE (IZIN_ID = Details.IZIN_ID)) AS TglDeadline, 
CASE 
    WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) 
        AND Details.izin_status IS NULL AND b.IZIN_STATUS = 'Pending' THEN 'Pending' 
    WHEN b.IZIN_STATUS = 'Dibatalkan Staff' THEN 'Dibatalkan Staff' 
    WHEN b.IZIN_STATUS = 'Dibatalkan HRD' THEN 'Dibatalkan HRD' 
    WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) 
        AND Details.izin_status IS NULL AND b.IZIN_TGLAPPVSPV IS NULL AND b.IZIN_JENIS = 'Cuti' AND h.IZIN_NIK_APPVMNG = '--' THEN 'Expired Cuti 1 Atasan'
    WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) 
        AND Details.izin_status IS NULL AND b.IZIN_TGLAPPVSPV IS NULL AND b.IZIN_JENIS = 'Cuti' AND h.IZIN_NIK_APPVMNG <> '--' THEN 'Expired Cuti 2 Atasan -- ATASAN 1 BLM APPRV' 
    WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) 
        AND Details.izin_status IS NULL AND b.IZIN_TGLAPPVSPV IS NOT NULL AND b.IZIN_TGLAPPVMNG IS NULL AND b.IZIN_JENIS = 'Cuti' AND h.IZIN_NIK_APPVMNG <> '--' THEN 'Expired Cuti 2 Atasan -- ATASAN 1 SDH APPV / ATASAN 2 BLM APPRV' 
    WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) 
        AND Details.izin_status IS NULL AND b.IZIN_TGLAPPVSPV IS NULL AND b.IZIN_JENIS <> 'Cuti' THEN 'Expired Selain Cuti' 
    WHEN Details.izin_status IS NULL AND b.IZIN_STATUS <> 'Pending' AND h.IZIN_NIK_APPVMNG = '--' AND b.IZIN_TGLAPPVSPV IS NOT NULL AND b.IZIN_JENIS = 'Cuti' THEN 'Disetujui Atasan Langsung -- CUTI BIASA' 
    WHEN Details.izin_status IS NULL AND b.IZIN_STATUS <> 'Pending' AND h.IZIN_NIK_APPVMNG <> '--' AND b.IZIN_TGLAPPVSPV IS NOT NULL AND b.IZIN_TGLAPPVMNG IS NOT NULL AND b.IZIN_JENIS = 'Cuti' THEN 'Disetujui Atasan 1tk Lebih Tinggi -- CUTI BIASA' 
    WHEN Details.izin_status IS NULL AND b.IZIN_STATUS <> 'Pending' AND h.IZIN_NIK_APPVMNG <> '--' AND b.IZIN_TGLAPPVSPV IS NOT NULL AND b.IZIN_TGLAPPVMNG IS NULL AND b.IZIN_JENIS = 'Cuti' THEN 'Disetujui Atasan Langsung -- CUTI BIASA / DELAY' 
    WHEN Details.izin_status IS NULL AND b.IZIN_STATUS <> 'Pending' AND b.IZIN_TGLAPPVSPV IS NOT NULL AND b.IZIN_JENIS <> 'Cuti' THEN 'Disetujui Atasan Langsung -- SELAIN CUTI BIASA' 
    ELSE NULL 
    END AS Status_Izin, 
Details.Source, 
Details.Flag
FROM dbo.DATA_IZIN_BODY AS b INNER JOIN 
    (SELECT IZIN_ID, IZIN_NIK, IZIN_TGLDETAIL, IZIN_STATUS, IZIN_ID_DETAIL AS id_detail, 'DT' AS Source, Flag FROM dbo.DATA_IZIN_DETAIL
     UNION ALL
    SELECT IZIN_ID, IZIN_NIK, IZIN_TGLDETAIL, IZIN_STATUS, IZIN_ID_DETAILPC AS id_detail, 'PC' AS Source, Flag FROM dbo.DATA_IZIN_DETAILPC) 
    AS Details ON b.IZIN_ID = Details.IZIN_ID INNER JOIN dbo.DATA_IZIN_HEADER AS h ON b.IZIN_NIK = h.IZIN_NIK
*/