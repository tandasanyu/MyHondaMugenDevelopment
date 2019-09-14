SELECT        Details.IZIN_ID, b.IZIN_NIK AS NIK, h.IZIN_NAMA, 
  CASE 
    WHEN h.IZIN_NIK_APPVMNG = '--' THEN NULL 
    WHEN h.IZIN_NIK_APPVMNG <> '--' THEN h.IZIN_NIK_APPVMNG 
  END AS NIKMNG, h.IZIN_NIK_APPVSPV AS NIKSPV,
   (SELECT STAFF_NAMA FROM dbo.DATA_STAFF WHERE (STAFF_NIK = h.IZIN_NIK_APPVSPV)) AS Atasan1, 
      CASE 
        WHEN h.IZIN_NIK_APPVMNG = '--' or h.IZIN_NIK_APPVMNG is null THEN '--' 
        WHEN h.IZIN_NIK_APPVMNG <> '--' THEN
          (SELECT staff_nama FROM data_staff WHERE staff_nik = h.IZIN_NIK_APPVMNG) 
      END AS Atasan2, b.IZIN_TGLAPPVMNG, b.IZIN_TGLAPPVSPV, Details.id_detail, b.IZIN_JENIS, b.IZIN_ALASAN, 
      b.IZIN_ALASANDETAIL, Details.IZIN_TGLDETAIL, b.IZIN_STATUS, 
      (SELECT IZIN_TGLDEADLINE FROM  dbo.DATA_IZIN_BODY WHERE (IZIN_ID = Details.IZIN_ID)) AS TglDeadline, 
      
      CASE
	  -- CASE EXPIRED
			----***UNTUK CUTI BIASA 1 ATASAN EXPIRED
			WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime)
			AND b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN = 'Cuti'
			AND (h.IZIN_NIK_APPVMNG = '--' OR h.IZIN_NIK_APPVMNG IS NULL)
			AND B.IZIN_TGLAPPVSPV IS NULL 
			AND (b.IZIN_STATUS = 'Pending' OR Details.izin_status = 'Pending')
			THEN 'EXPIRED 1 ATASAN BLM APPRV - CUTI BIASA'
			----***UNTUK CUTI BIASA 2 ATASAN EXPIRED (SPV BLM APPROVE)
			WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime)
			AND b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN = 'Cuti'
			AND (h.IZIN_NIK_APPVMNG <> '--' OR h.IZIN_NIK_APPVMNG IS NOT NULL)
			AND B.IZIN_TGLAPPVSPV IS NULL 
			AND (b.IZIN_STATUS = 'Pending' OR Details.izin_status = 'Pending')
			THEN 'EXPIRED 2 ATASAN SPV BLM APPRV - CUTI BIASA'
			----***UNTUK CUTI BIASA 2 ATASAN EXPIRED (SPV SUDAH & MNG BLM APPROVE)
			WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime)
			AND b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN = 'Cuti'
			AND (h.IZIN_NIK_APPVMNG <> '--' OR h.IZIN_NIK_APPVMNG IS NOT NULL)
			AND B.IZIN_TGLAPPVSPV IS NOT NULL AND B.IZIN_TGLAPPVMNG IS NULL 
			AND (b.IZIN_STATUS = 'Disetujui Atasan' OR Details.izin_status = 'Disetujui Atasan')
			THEN 'EXPIRED 2 ATASAN MNG BLM APPRV - CUTI BIASA'
			----***UNTUK CUTI ISTIMEWA (HANYA 1 ATASAN APPRV) JADI EXPIRED JIKA SPV BLM APPRV
			----***UNTUK CUTI BIASA 2 ATASAN EXPIRED (SPV SUDAH & MNG BLM APPROVE)
			WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime)
			AND b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN <> 'Cuti'
			--AND h.IZIN_NIK_APPVMNG <> '--' 
			AND B.IZIN_TGLAPPVSPV IS NULL
			AND (b.IZIN_STATUS = 'Pending' OR Details.izin_status = 'Pending')
			THEN 'EXPIRED 1 ATASAN SPV BLM APPRV - CUTI SPESIAL'
			----***UNTUK EXPIRED SELAIN CUTI
			WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime)
			AND b.IZIN_JENIS <> 'Cuti'
			--AND h.IZIN_NIK_APPVMNG <> '--' 
			AND B.IZIN_TGLAPPVSPV IS NULL
			AND (b.IZIN_STATUS = 'Pending' OR Details.izin_status =  'Pending')
			THEN 'EXPIRED 1 ATASAN SPV BLM APPRV - SELAIN CUTI BIASA'
		-- CASE PENDING
			-- *** UNTUK CASE PENDING
			WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime)
			AND (b.IZIN_STATUS = 'Pending' OR Details.izin_status =  'Pending')
			THEN 'Pending' 
			-- *** UNTUK CASE PENDING CUTI 1 ATASAN (FOKUS KE SPV & MNG [--])
			WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime)
			AND b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN = 'Cuti'
			AND (h.IZIN_NIK_APPVMNG = '--' OR h.IZIN_NIK_APPVMNG IS NULL)
			AND B.IZIN_TGLAPPVSPV IS NULL 
			AND (b.IZIN_STATUS = 'Pending' OR Details.izin_status = 'Pending')
			THEN 'PENDING 1 ATASAN BLM APPRV - CUTI BIASA'
			-- *** UNTUK CASE PENDING CUTI 2 ATASAN (CASE 1: ATASAN 1 BLM APPRV)
			WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime)
			AND b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN = 'Cuti'
			AND (h.IZIN_NIK_APPVMNG <> '--' OR h.IZIN_NIK_APPVMNG IS NOT NULL)
			AND B.IZIN_TGLAPPVSPV IS NULL 
			AND (b.IZIN_STATUS = 'Pending' OR Details.izin_status = 'Pending')
			THEN 'PENDING 2 ATASAN. SPV BLM APPRV - CUTI BIASA'
			-- *** UNTUK CASE PENDING CUTI 2 ATASAN (CASE 2: ATASAN 2 BLM APPRV)
			WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime)
			AND b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN = 'Cuti'
			AND (h.IZIN_NIK_APPVMNG <> '--' OR h.IZIN_NIK_APPVMNG IS NOT NULL)
			AND B.IZIN_TGLAPPVSPV IS NOT NULL  AND B.IZIN_TGLAPPVMNG IS NULL
			AND (b.IZIN_STATUS = 'Disetujui Atasan' OR Details.izin_status = 'Disetujui Atasan')
			THEN 'PENDING 2 ATASAN. MNG BLM APPRV - CUTI BIASA'
			-- *** UNTUK CASE CUTI ISTIMEWA (HANYA FOKUS APPRV SPV)
			WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime)
			AND b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN <> 'Cuti'
			--AND (h.IZIN_NIK_APPVMNG <> '--' OR h.IZIN_NIK_APPVMNG IS NOT NULL)
			AND B.IZIN_TGLAPPVSPV IS NULL
			AND (b.IZIN_STATUS = 'Pending' OR Details.izin_status = 'Pending')
			THEN 'PENDING 1 ATASAN. SPV BLM APPRV - CUTI ISTIMEWA'
			-- *** UNTUK CASE Selain Cuti (HANYA FOKUS APPRV SPV)
			WHEN (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime)
			AND b.IZIN_JENIS <> 'Cuti'
			AND B.IZIN_TGLAPPVSPV IS NULL
			AND (b.IZIN_STATUS = 'Pending' OR Details.izin_status = 'Pending')
			THEN 'PENDING 1 ATASAN. SPV BLM APPRV - SELAIN CUTI BIASA'
		-- CASE APPROVE
			-- *** UNTUK CASE CUTI BIASA - 1 ATASAN
			WHEN ((SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) <= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) OR (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime))
			AND b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN = 'Cuti'
			AND (h.IZIN_NIK_APPVMNG = '--' OR h.IZIN_NIK_APPVMNG IS NULL)
			AND B.IZIN_TGLAPPVSPV IS NOT NULL 
			AND(b.IZIN_STATUS = 'Disetujui Manajer' OR Details.izin_status = 'Disetujui Manajer')
			THEN 'Disetujui Atasan Langsung -- CUTI BIASA 1 ATASAN'
			-- *** UNTUK CASE CUTI BIASA - 2 ATASAN
			WHEN ((SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) <= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) OR (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime))
			AND b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN = 'Cuti'
			AND (h.IZIN_NIK_APPVMNG <> '--' OR h.IZIN_NIK_APPVMNG IS NOT NULL)
			AND B.IZIN_TGLAPPVSPV IS NOT NULL AND B.IZIN_TGLAPPVMNG IS NOT NULL
			AND(b.IZIN_STATUS = 'Disetujui Manajer' OR Details.izin_status = 'Disetujui Manajer')
			THEN 'Disetujui Atasan 1tk Lebih Tinggi -- CUTI BIASA'
			-- *** UNTUK CASE CUTI ISTIMEWA (FOKUS APPRV SPV)
			WHEN ((SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) <= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) OR (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime))
			AND b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN <> 'Cuti'
			--AND (h.IZIN_NIK_APPVMNG = '--' OR h.IZIN_NIK_APPVMNG IS NULL)
			AND B.IZIN_TGLAPPVSPV IS NOT NULL AND (B.IZIN_STATUS = 'Disetujui Manajer' OR B.IZIN_STATUS = 'Disetujui Atasan')
			THEN 'Disetujui Atasan Langsung -- CUTI ISTIMEWA 1 ATASAN'
			-- *** UNTUK CASE SELAIN CUTI
			WHEN ((SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) <= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) OR (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime))
			AND b.IZIN_JENIS <> 'Cuti' -- AND b.IZIN_ALASAN <> 'Cuti'
			--AND (h.IZIN_NIK_APPVMNG = '--' OR h.IZIN_NIK_APPVMNG IS NULL)
			AND B.IZIN_TGLAPPVSPV IS NOT NULL AND (B.IZIN_STATUS = 'Disetujui Manajer' OR B.IZIN_STATUS = 'Disetujui Atasan')
			THEN 'Disetujui Atasan Langsung -- SELAIN CUTI BIASA 1 ATASAN'
		-- UNTUK CASE DIBATALKAN
			WHEN ((SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) <= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) OR (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime))
			AND 
			(b.IZIN_STATUS = 'Dibatalkan Staff' OR Details.izin_status = 'Dibatalkan Staff')
			THEN 'Di Batalkan Staff'
			WHEN ((SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) <= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) OR (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime))
			AND 
			(b.IZIN_STATUS = 'Dibatalkan HRD' OR Details.izin_status = 'Dibatalkan HRD')
			THEN 'Di Batalkan HRD'
			WHEN ((SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) <= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) OR (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime))
			AND 
			(b.IZIN_STATUS = 'Dibatalkan Manajer' OR Details.izin_status = 'Dibatalkan Manajer')
			THEN 'Dibatalkan Manajer'
			WHEN ((SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) <= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) OR (SELECT izin_tgldeadline FROM data_izin_body WHERE izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime))
			AND 
			(b.IZIN_STATUS = 'Dibatalkan Atasan' OR Details.izin_status = 'Dibatalkan Atasan')
			THEN 'Dibatalkan Atasan'
		ELSE 
		'***'
	  END AS Status_Izin, 
	  Details.Source, Details.Flag
FROM dbo.DATA_IZIN_BODY AS b INNER JOIN 
  (SELECT IZIN_ID, IZIN_NIK, IZIN_TGLDETAIL, IZIN_STATUS, IZIN_ID_DETAIL AS id_detail, 'DT' AS Source, Flag
    FROM dbo.DATA_IZIN_DETAIL
    UNION ALL
  SELECT IZIN_ID, IZIN_NIK, IZIN_TGLDETAIL, IZIN_STATUS, IZIN_ID_DETAILPC AS id_detail, 'PC' AS Source, Flag
    FROM dbo.DATA_IZIN_DETAILPC) 
  AS Details ON b.IZIN_ID = Details.IZIN_ID INNER JOIN dbo.DATA_IZIN_HEADER AS h ON b.IZIN_NIK = h.IZIN_NIK



  order by b.IZIN_TGLDEADLINE DESC
  --where h.IZIN_NIK_APPVMNG = '1070' or h.IZIN_NIK_APPVSPV = '1070' or h.IZIN_NIK = '1070'


-- ** YANG SUDAH 
-- UNTUK CUTI BIASA 1 ATASAN EXPIRED
  			 b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN = 'Cuti'
			AND h.IZIN_NIK_APPVMNG = '--' 
			AND B.IZIN_TGLAPPVSPV IS NULL 
			AND b.IZIN_STATUS = 'Pending'

-- UNTUK CUTI BIASA 2 ATASAN (SPV BLM APPRV)
			 b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN = 'Cuti'
			AND h.IZIN_NIK_APPVMNG = '--' 
			AND B.IZIN_TGLAPPVSPV IS NULL 
			AND b.IZIN_STATUS = 'Pending'
-- UNTUK CUTI BIASA 2 ATASAN (SPV APPRV MNG BLM APPRV)
			--***UNTUK CUTI BIASA 2 ATASAN EXPIRED (SPV SUDAH & MNG BLM APPROVE)
			 b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN = 'Cuti'
			AND h.IZIN_NIK_APPVMNG <> '--' 
			AND B.IZIN_TGLAPPVSPV IS NOT NULL AND B.IZIN_TGLAPPVMNG IS NOT NULL 
			AND b.IZIN_STATUS = 'Disetujui Atasan'
-- UNTUK CUTI SPESIAL, FOKUS HANYA DI SATU ATASAN SAJA. JADI JIKA SPV BELUM APPROVE DAN STATUS PENDING MAKA HASILNYA EXPIRED JIKA MELEWATI TANGGAL DEADLINE 
			 b.IZIN_JENIS = 'Cuti' AND b.IZIN_ALASAN <> 'Cuti'
			--AND h.IZIN_NIK_APPVMNG <> '--' 
			AND B.IZIN_TGLAPPVSPV IS NULL
			AND b.IZIN_STATUS = 'Pending'
-- UNTUK EXPIRED SELAIN CUTI
			AND b.IZIN_JENIS <> 'Cuti'
			--AND h.IZIN_NIK_APPVMNG <> '--' 
			AND B.IZIN_TGLAPPVSPV IS NULL
			AND b.IZIN_STATUS = 'Pending'
-- UNTUK PENDING MURNI (KETIKA DEADLINE MASIH JAUH)
			AND (b.IZIN_STATUS = 'Pending' OR Details.izin_status =  'Pending')


/*

UPDATE
    DATA_IZIN_DETAIL 
SET
    DATA_IZIN_DETAIL.IZIN_STATUS = b.IZIN_STATUS
FROM
    DATA_IZIN_DETAIL d
INNER JOIN
    DATA_IZIN_BODY b
ON 
    d.IZIN_ID = b.IZIN_ID;


*/