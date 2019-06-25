SELECT        dbo.DATA_IZIN_BODY.IZIN_ID, dbo.DATA_IZIN_HEADER.IZIN_NAMA, dbo.DATA_IZIN_BODY.IZIN_ALASAN, dbo.DATA_IZIN_BODY.IZIN_TGLPENGAJUAN,
                             (SELECT        STAFF_NAMA
                               FROM            dbo.DATA_STAFF
                               WHERE        (STAFF_NIK = dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVSPV)) AS IZIN_NIK_APPVSPV, dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVSPV AS NIKSPV, 
                         CASE WHEN dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVMNG = '--' THEN '--' ELSE
                             (SELECT        STAFF_NAMA
                               FROM            DATA_STAFF
                               WHERE        STAFF_NIK = dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVMNG) END AS IZIN_NIK_APPVMNG, dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVMNG AS NIKMNG, dbo.DATA_IZIN_BODY.IZIN_TGLAPPVSPV, 
                         dbo.DATA_IZIN_BODY.IZIN_TGLAPPVMNG, 
						 CASE 
							WHEN dbo.DATA_IZIN_BODY.IZIN_STATUS = 'Disetujui Manajer' AND 
							dbo.DATA_IZIN_BODY.IZIN_JENIS <> 'Cuti' THEN 'Disetujui Atasan Langsung' 
							WHEN dbo.DATA_IZIN_BODY.IZIN_STATUS = 'Disetujui Manajer' AND dbo.DATA_IZIN_BODY.IZIN_JENIS = 'Cuti' AND 
							dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVMNG <> '--' THEN 'Disetujui Atasan 1tk Lebih Tinggi' 
							WHEN dbo.DATA_IZIN_BODY.IZIN_STATUS = 'Disetujui Manajer' AND dbo.DATA_IZIN_BODY.IZIN_JENIS = 'Cuti' AND 
							dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVMNG = '--' THEN 'Disetujui Atasan Langsung' 
							WHEN dbo.DATA_IZIN_BODY.IZIN_STATUS = 'Disetujui Atasan' AND 
							dbo.DATA_IZIN_BODY.IZIN_JENIS = 'Cuti' THEN 'Disetujui Atasan Langsung' 
							WHEN dbo.DATA_IZIN_BODY.IZIN_STATUS = 'Dibatalkan Atasan' AND 
							dbo.DATA_IZIN_BODY.IZIN_JENIS <> 'Cuti' THEN 'Dibatalkan Atasan Langsung' 
							WHEN dbo.DATA_IZIN_BODY.IZIN_STATUS = 'Pending' AND 
							dbo.DATA_IZIN_BODY.IZIN_TGLDEADLINE < CAST(CONVERT(CHAR(8), GETDATE(), 112) AS smalldatetime) THEN 'Expired' ELSE dbo.DATA_IZIN_BODY.IZIN_STATUS END AS IZIN_STATUS, 
							dbo.DATA_IZIN_BODY.IZIN_JENIS, dbo.DATA_STAFF.STAFF_SUBJABATAN, dbo.DATA_STAFF.STAFF_STATUSKERJADEPT
FROM            dbo.DATA_IZIN_BODY INNER JOIN
                         dbo.DATA_IZIN_HEADER ON dbo.DATA_IZIN_HEADER.IZIN_NIK = dbo.DATA_IZIN_BODY.IZIN_NIK INNER JOIN
                         dbo.DATA_STAFF ON dbo.DATA_IZIN_HEADER.IZIN_NIK = dbo.DATA_STAFF.STAFF_NIK