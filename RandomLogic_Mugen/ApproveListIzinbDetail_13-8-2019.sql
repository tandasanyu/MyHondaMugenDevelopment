SELECT        Details.IZIN_ID, b.IZIN_NIK AS NIK, h.IZIN_NAMA, CASE WHEN h.IZIN_NIK_APPVMNG = '--' THEN NULL WHEN h.IZIN_NIK_APPVMNG <> '--' THEN h.IZIN_NIK_APPVMNG END AS NIKMNG, 
                         h.IZIN_NIK_APPVSPV AS NIKSPV,
                             (SELECT        STAFF_NAMA
                               FROM            dbo.DATA_STAFF
                               WHERE        (STAFF_NIK = h.IZIN_NIK_APPVSPV)) AS Atasan1, CASE WHEN h.IZIN_NIK_APPVMNG = '--' THEN '--' WHEN h.IZIN_NIK_APPVMNG <> '--' THEN
                             (SELECT        staff_nama
                               FROM            data_staff
                               WHERE        staff_nik = h.IZIN_NIK_APPVMNG) END AS Atasan2, b.IZIN_TGLAPPVMNG, b.IZIN_TGLAPPVSPV, Details.id_detail, b.IZIN_JENIS, b.IZIN_ALASAN, b.IZIN_ALASANDETAIL, Details.IZIN_TGLDETAIL, 
                         b.IZIN_STATUS,
                             (SELECT        IZIN_TGLDEADLINE
                               FROM            dbo.DATA_IZIN_BODY
                               WHERE        (IZIN_ID = Details.IZIN_ID)) AS TglDeadline, CASE WHEN
                             (SELECT        izin_tgldeadline
                               FROM            data_izin_body
                               WHERE        izin_id = Details.izin_id) >= CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) AND Details.izin_status IS NULL AND 
                         b.IZIN_STATUS = 'Pending' THEN 'Pending' WHEN b.IZIN_STATUS = 'Dibatalkan Staff' THEN 'Dibatalkan Staff' WHEN b.IZIN_STATUS = 'Dibatalkan HRD' THEN 'Dibatalkan HRD' WHEN
                             (SELECT        izin_tgldeadline
                               FROM            data_izin_body
                               WHERE        izin_id = Details.izin_id) < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) AND Details.izin_status IS NULL AND b.IZIN_TGLAPPVSPV IS NULL AND b.IZIN_JENIS = 'Cuti' AND 
                         h.IZIN_NIK_APPVMNG = '--' THEN 'Expired Cuti 1 Atasan' WHEN
                             (SELECT        izin_tgldeadline
                               FROM            data_izin_body
                               WHERE        izin_id = Details.izin_id) < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) AND Details.izin_status IS NULL AND b.IZIN_TGLAPPVSPV IS NULL AND b.IZIN_JENIS = 'Cuti' AND 
                         h.IZIN_NIK_APPVMNG <> '--' THEN 'Expired Cuti 2 Atasan -- ATASAN 1 BLM APPRV' WHEN
                             (SELECT        izin_tgldeadline
                               FROM            data_izin_body
                               WHERE        izin_id = Details.izin_id) < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) AND Details.izin_status IS NULL AND b.IZIN_TGLAPPVSPV IS NOT NULL AND b.IZIN_TGLAPPVMNG IS NULL 
                         AND b.IZIN_JENIS = 'Cuti' AND h.IZIN_NIK_APPVMNG <> '--' THEN 'Expired Cuti 2 Atasan -- ATASAN 1 SDH APPV / ATASAN 2 BLM APPRV' WHEN
                             (SELECT        izin_tgldeadline
                               FROM            data_izin_body
                               WHERE        izin_id = Details.izin_id) < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) AND Details.izin_status IS NULL AND b.IZIN_TGLAPPVSPV IS NULL AND 
                         b.IZIN_JENIS <> 'Cuti' THEN 'Expired Selain Cuti' WHEN Details.izin_status IS NULL AND b.IZIN_STATUS <> 'Pending' AND h.IZIN_NIK_APPVMNG = '--' AND b.IZIN_TGLAPPVSPV IS NOT NULL AND 
                         b.IZIN_JENIS = 'Cuti' THEN 'Disetujui Atasan Langsung -- CUTI BIASA' WHEN Details.izin_status IS NULL AND b.IZIN_STATUS <> 'Pending' AND h.IZIN_NIK_APPVMNG <> '--' AND 
                         b.IZIN_TGLAPPVSPV IS NOT NULL AND b.IZIN_TGLAPPVMNG IS NOT NULL AND b.IZIN_JENIS = 'Cuti' THEN 'Disetujui Atasan 1tk Lebih Tinggi -- CUTI BIASA' WHEN Details.izin_status IS NULL AND 
                         b.IZIN_STATUS <> 'Pending' AND h.IZIN_NIK_APPVMNG <> '--' AND b.IZIN_TGLAPPVSPV IS NOT NULL AND b.IZIN_TGLAPPVMNG IS NULL AND 
                         b.IZIN_JENIS = 'Cuti' THEN 'Disetujui Atasan Langsung -- CUTI BIASA / DELAY' WHEN Details.izin_status IS NULL AND b.IZIN_STATUS <> 'Pending' AND b.IZIN_TGLAPPVSPV IS NOT NULL AND 
                         b.IZIN_JENIS <> 'Cuti' THEN 'Disetujui Atasan Langsung -- SELAIN CUTI BIASA' ELSE NULL END AS Status_Izin, Details.Source, Details.Flag
FROM            dbo.DATA_IZIN_BODY AS b INNER JOIN
                             (SELECT        IZIN_ID, IZIN_NIK, IZIN_TGLDETAIL, IZIN_STATUS, IZIN_ID_DETAIL AS id_detail, 'DT' AS Source, Flag
                               FROM            dbo.DATA_IZIN_DETAIL
                               UNION ALL
                               SELECT        IZIN_ID, IZIN_NIK, IZIN_TGLDETAIL, IZIN_STATUS, IZIN_ID_DETAILPC AS id_detail, 'PC' AS Source, Flag
                               FROM            dbo.DATA_IZIN_DETAILPC) AS Details ON b.IZIN_ID = Details.IZIN_ID INNER JOIN
                         dbo.DATA_IZIN_HEADER AS h ON b.IZIN_NIK = h.IZIN_NIK