--alter table Data_izin_detail
ALTER TABLE DATA_IZIN_DETAIL
ADD IZIN_STATUS varchar(20);

ALTER TABLE DATA_IZIN_DETAILPC
ADD IZIN_STATUS varchar(20);

ALTER TABLE DATA_IZIN_DETAILPC
ADD IZIN_ID_DETAILPC int IDENTITY (1,1) 

ALTER TABLE DATA_IZIN_DETAIL
ADD IZIN_ID_DETAIL int IDENTITY (1,1) 

-- revisi table menyimpan izin. untuk PC & tahunan di satukan
-- tambah kolom SPV MNG, TGLSPV MNG, DEADLINE ACC
CREATE TABLE DATA_IZIN_TANGGAL(
    Id_tanggal int IDENTITY (1,1) PRIMARY KEY, 
    izin_nik NVARCHAR (20) NOT NULL, --fk ke data_izin_body
    izin_id NVARCHAR (20) not null, --fk ke data_izin_header
    izin_tgldetail smalldatetime not null,
    izin_jamdetail NVARCHAR (10) , 
    izin_tglstatus NVARCHAR (20) not null, 
    izin_spv nvarchar (20) not null,
    izin_mng nvarchar (20) not null, 
    izin_spvtgl smalldatetime not null, 
    izin_mngtgl smalldatetime not null,
    tgl_deadline smalldatetime not null,
    izin_flag int default null -- [1 untuk tahunan/ 2 untuk pc]
)

insert into DATA_IZIN_TANGGAL (IZIN_ID, izin_tgldetail, IZIN_NIK, izin_jamdetail, izin_tglstatus) values

CREATE VIEW JoinDetailTgl AS
select  t.id_tanggal as Id, t.izin_nik as NIK, h.IZIN_NAMA as Nama,t.izin_id as IzinID, t.izin_tgldetail as TglDet,
 t.izin_jamdetail as JamDet, b.izin_jenis +'/'+ b.izin_alasan as Detail  ,
t.izin_mng as NIKMNG, t.izin_spv as NIKSPV,
t.izin_spvtgl as SPV , t.izin_mngtgl as MNG  ,
t.tgl_deadline as Deadline,
 t.izin_tglstatus as Status  , b.izin_tglpengajuan as TglPeng
from data_izin_tanggal t
inner join data_izin_header h on h.izin_nik = t.izin_nik
inner join DATA_IZIN_BODY b on t.izin_id=b.izin_id 

--create view terbaru 29/4/2019

create view ListIzin_new as
SELECT        dbo.DATA_IZIN_BODY.IZIN_ID, dbo.DATA_IZIN_HEADER.IZIN_NAMA, dbo.DATA_IZIN_BODY.IZIN_ALASAN, dbo.DATA_IZIN_BODY.IZIN_TGLPENGAJUAN, 
						(select staff_nama from data_staff where staff_nik = dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVSPV)  as IZIN_NIK_APPVSPV,  dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVSPV AS NIKSPV,
                         case 
						 when dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVMNG = '--'
						 then '--'
						 ELSE (SELECT STAFF_NAMA FROM DATA_STAFF WHERE STAFF_NIK = dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVMNG) 
						 end as IZIN_NIK_APPVMNG, 
						 dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVMNG AS NIKMNG,
						 dbo.DATA_IZIN_BODY.IZIN_TGLAPPVSPV, dbo.DATA_IZIN_BODY.IZIN_TGLAPPVMNG, 
						 --dbo.DATA_IZIN_BODY.IZIN_STATUS ,
						 --case when dbo.DATA_IZIN_BODY.IZIN_STATUS  ='Disetujui Manajer' 
						 --and dbo.DATA_IZIN_BODY.IZIN_JENIS <>'Cuti'
						 --then 'Disetujui Atasan' end as IZIN_STATUS,
						 case 
						 when dbo.DATA_IZIN_BODY.IZIN_STATUS ='Disetujui Manajer'
						 and dbo.DATA_IZIN_BODY.IZIN_JENIS <>'Cuti'
						 then 'Disetujui Atasan Langsung'
						 when dbo.DATA_IZIN_BODY.IZIN_STATUS ='Disetujui Manajer'
						 and dbo.DATA_IZIN_BODY.IZIN_JENIS ='Cuti' AND  dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVMNG <> '--'
						 then 'Disetujui Atasan 1tk Lebih Tinggi'	
						 when dbo.DATA_IZIN_BODY.IZIN_STATUS ='Disetujui Manajer'
						 and dbo.DATA_IZIN_BODY.IZIN_JENIS ='Cuti' AND  dbo.DATA_IZIN_HEADER.IZIN_NIK_APPVMNG = '--'
						 then 'Disetujui Atasan Langsung'	
						 when dbo.DATA_IZIN_BODY.IZIN_STATUS ='Disetujui Atasan'
						 and dbo.DATA_IZIN_BODY.IZIN_JENIS ='Cuti'
						 then 'Disetujui Atasan Langsung'	
						 when dbo.DATA_IZIN_BODY.IZIN_STATUS ='Dibatalkan Atasan'
						 and dbo.DATA_IZIN_BODY.IZIN_JENIS <>'Cuti'
						 then 'Dibatalkan Atasan Langsung'			
						 when dbo.DATA_IZIN_BODY.IZIN_STATUS = 'Pending' and dbo.DATA_IZIN_BODY.IZIN_TGLDEADLINE < getdate() then 'Expired'		  				 
						 else dbo.DATA_IZIN_BODY.IZIN_STATUS end as IZIN_STATUS,
						 dbo.DATA_IZIN_BODY.IZIN_JENIS, 
                         dbo.DATA_STAFF.STAFF_SUBJABATAN, dbo.DATA_STAFF.STAFF_STATUSKERJADEPT
						
FROM            dbo.DATA_IZIN_BODY INNER JOIN
                         dbo.DATA_IZIN_HEADER ON dbo.DATA_IZIN_HEADER.IZIN_NIK = dbo.DATA_IZIN_BODY.IZIN_NIK INNER JOIN
                         dbo.DATA_STAFF ON dbo.DATA_IZIN_HEADER.IZIN_NIK = dbo.DATA_STAFF.STAFF_NIK


--view untuk request pak guguk 
/*
Menampilkan Izin Bawahn dg daterange dan sesuai where spv or mng = 16
*/
select * from DetailIzinBawahan 
where
 CAST(IZIN_TGLDETAIL as date) BETWEEN 
'2019-04-22 00:00:00' AND '2019-04-25 00:00:00' AND (
 IZIN_NIK_APPVMNG = '16' or IZIN_NIK_APPVSPV = '16' )

 create view DetailIzinBawahan as  -- untuk tampilan bawahan list izin sesuai request pak guguk

SELECT h.IZIN_NIK,h.IZIN_NAMA, d.IZIN_TGLDETAIL, b.IZIN_JENIS, b.IZIN_ALASAN,
 h.IZIN_NIK_APPVSPV, h.IZIN_NIK_APPVMNG, 
 						 case 
						 when b.IZIN_STATUS ='Disetujui Manajer'
						 and b.IZIN_JENIS <>'Cuti'
						 then 'Disetujui Atasan Langsung'
						 when b.IZIN_STATUS ='Disetujui Manajer'
						 and b.IZIN_JENIS ='Cuti' AND  h.IZIN_NIK_APPVMNG <> '--'
						 then 'Disetujui Atasan 1tk Lebih Tinggi'	
						 when b.IZIN_STATUS ='Disetujui Manajer'
						 and b.IZIN_JENIS ='Cuti' AND  h.IZIN_NIK_APPVMNG = '--'
						 then 'Disetujui Atasan Langsung'	
						 when b.IZIN_STATUS ='Disetujui Atasan'
						 and b.IZIN_JENIS ='Cuti'
						 then 'Disetujui Atasan Langsung'	
						 when b.IZIN_STATUS ='Dibatalkan Atasan'
						 and b.IZIN_JENIS <>'Cuti'
						 then 'Dibatalkan Atasan Langsung'					  				 
						 else b.IZIN_STATUS end as IZIN_STATUS
FROM data_izin_detail d
INNER JOIN data_izin_body b ON b.IZIN_ID = d.IZIN_ID
inner join data_izin_header h on h.IZIN_NIK = b.IZIN_NIK
 -- PROJECT BARU ADA DI BACKUP FORM IZIN

 --drop constarint default
/*Jalamkam drp[ kolom. error nya menunjukan nama constrain default*/

 ALTER TABLE DATA_IZIN_DETAILPC DROP COLUMN Flag

ALTER TABLE DATA_IZIN_DETAILPC DROP CONSTRAINT DF__DATA_IZIN___Flag__2180FB33

--
ALTER TABLE DATA_IZIN_DETAIL
        ADD Flag int not null  --Or NOT NULL.
 CONSTRAINT FlagDt --When Omitted a Default-Constraint Name is autogenerated.
    DEFAULT 1--Optional Default-Constraint.
WITH VALUES 
-- cara mencari PO 
/*
SELECT case tb_user.kdcabang when '112' then 'Ps.Minggu' when '128' then 'Puri' else 'Ps. Minggu' 
end AS cab, divisi.nmdivisi, fmbhead.nofmbhead, fmbhead.userfmb, 
convert(varchar, tglpemohonfmb,106) as tglpemohonfmb , fmbhead.disetujuifmb, 
convert(varchar, tgldisetujuifmb,106) as tgldisetujuifmb, fmbhead.mengetahuifmb, fmbhead.tglmengetahuifmb, 
	case fmbhead.rejecthead 
	when 'N' then '<strong style=color:green;>Tersedia</strong>' 
	when 'Y' then '<strong style=color:red;>Ditolak</strong>' 
	end AS stat, fmbhead.approveheadpurc, 
convert(varchar, tglapproveheadpurc,106) as tglapproveheadpurc, 
SUM(fmbbody.hargaitem*fmbbody.jumlahitem) AS total, fmbhead.disetujui2fmb, 
convert(varchar, tgldisetujui2fmb, 106) AS tgldisetujui2fmb , 
fmbbody.namaitem as nama_barang, 
fmbbody.tujuanitem as Tujuan_Barang, 
fmbbody.jumlahitem as Jumlah_Item
FROM fmbhead 
INNER JOIN fmbbody ON fmbhead.nofmbhead = fmbbody.nobody 
INNER JOIN tb_user ON fmbhead.pemohonfmb = tb_user.username 
INNER JOIN divisi ON tb_user.kddivisi = divisi.kddivisi 
WHERE pemohonfmb = 'IT128' 
--WHERE (@q2 = 'me' AND pemohonfmb = 'IT128' OR @q2 = 'me' 
--AND disetujuifmb = @ses OR @q2 = 'me' AND approveheadpurc = @ses OR @q2 = 'me' 
--AND disetujui2fmb = @ses) OR (@q2 = 'All' AND rejectoleh IS NULL) OR (@q2 = 'Rej' 
--AND rejectoleh IS NOT NULL) 
GROUP BY fmbhead.disetujui2fmb, fmbhead.tgldisetujui2fmb, fmbhead.nofmbhead, fmbhead.userfmb, fmbhead.tglpemohonfmb, fmbhead.disetujuifmb, fmbhead.tgldisetujuifmb, fmbhead.mengetahuifmb, fmbhead.tglmengetahuifmb, fmbhead.approveheadpurc, fmbhead.tglapproveheadpurc, fmbhead.rejecthead, divisi.nmdivisi, tb_user.kdcabang, fmbbody.rejectoleh,fmbbody.namaitem ,fmbbody.tujuanitem,fmbbody.jumlahitem  ORDER BY nofmbhead DESC

*/
-- ada masaslah di pk nilai kalkulasi akhir tidak muncul 
/*
**********************************************************SCRIPT UNTUK UPDATE IZIN: TAMPILAN DETAIL 

 SELECT Details.izin_id,
     b.izin_nik AS NIK,
	 h.IZIN_NAMA,
	 h.IZIN_NIK_APPVSPV,b.IZIN_TGLAPPVSPV,
	 h.IZIN_NIK_APPVSPV,b.IZIN_TGLAPPVMNG,
	 Details.id_detail,
     b.izin_jenis,
     b.izin_alasan,
     Details.izin_tgldetail,
     Details.izin_status,
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

****TAMBAJAM
-Jika izin status null maka : 
1.ketika null dan tgl 
*/

/*
proses kalkulasi Bagian A : nilai bobot KPI di PK Staff
GetData_NILAIA (....)
=============
Query untuk menampilkan tb nilai kpi di setiap pk staff
A.  RAPORT KEY PERFORMANCE INDICATOR

SELECT TRXN_KPID.KPID_NIK, TRXN_KPID.KPID_BOBOT, TRXN_KPID.KPID_NILAISTAFF, 
Round(((DATA_KPIT.KPIT_BOBOT * TRXN_KPID.KPID_NILAISTAFF ) / 100),2) 
as NILAIAKHIR, DATA_KPIT.KPIT_ITEM, DATA_KPIT.KPIT_BOBOT, DATA_KPIT.KPIT_TIPE,  
DATA_KPIT.KPIT_TARGET, TRXN_KPID.KPID_PRESTASI, TRXN_KPID.KPID_TYPEA, TRXN_KPID.KPID_BULAN01,  
TRXN_KPID.KPID_BULAN02, TRXN_KPID.KPID_BULAN03, TRXN_KPID.KPID_BULAN04, TRXN_KPID.KPID_BULAN05, 
TRXN_KPID.KPID_BULAN07, TRXN_KPID.KPID_BULAN06, TRXN_KPID.KPID_BULAN08, TRXN_KPID.KPID_BULAN09, 
TRXN_KPID.KPID_BULAN10, TRXN_KPID.KPID_BULAN11, TRXN_KPID.KPID_BULAN12 FROM TRXN_KPID, DATA_KPIT 
WHERE (TRXN_KPID.KPID_NIK = 462) AND (TRXN_KPID.KPID_TAHUN = 2018) AND TRXN_KPID.KPID_ITEM = DATA_KPIT.KPIT_TIPE

=============== KPIT (ITEM)
KPID & KPIDD PK

di halaman ITEMPENILAIANKARYAWAN -- BtnStandardSave_Click kalo data ada maka update bobot (tambah isian tahun)

select * FROM DATA_KPIT WHERE KPIT_TIPE = 'SPS8'

SELECT * FROM TRXN_KPID WHERE KPID_TYPEA = 'SPS5' and KPID_NIK = 462

*/

WO : 148834  TEST : 14

SELECT [KERJABODY_NOWO], [KERJABODY_TANGGAL], [KERJABODY_USER], case [KERJABODY_STATUS] 
when 1 then 'DITERIMA' when 2 then 'BONGKAR' when 3 then 'KETOK' when 4 then 'DEMPUL' when 5 then 'CAT/OVEN' 
when 6 then 'POLES' when 7 then 'PEMASANGAN' when 8 then 'FINISHING' when 0 then 'CLOSING' when 9 then 'ANTRIAN' 
when 10 then 'PENILAIAN QC - OK' when 11 then 'PENILAIAN QC - REOWRK' when 12 then 'CATATAN' when 13 then 'PENYERAHAN UNIT KE QC' 
when 14 then 'PENERIMAAN UNIT OLEH QC'  else 'UNCATEGORIZED' end AS statusval, case [KERJABODY_LOKASI] when 1 then 'lt. 1' 
when 2 then 'lt. 2' when 3 then 'lt. 3' when 4 then 'lt.4' when 5 then 'lt. 5' when 6 then 'lt. 6' when 7 then 'lt. 7' 
when 8 then 'lt. 8' when 9 then 'lt. 9' else '' END AS lokasimobil, [KERJABODY_CATATAN] FROM [TEMP_KERJABODY] 
WHERE ([KERJABODY_NOWO] = 148834)


/*
SP UNTUK STATUS PERKAWINAN


CREATE PROCEDURE SP_StatusPernikahan @idLamaran nvarchar(30)
AS
		  SELECT 
			id_pasangan as id, id_lamaran as id_l, nm_pasangan as nama , pendidikan_pasangan as pendidikan, 
			pekerjaan_pasangan as pekerjaan, status_pernikahan as status_per, 'Pasangan' as status_data,
			case when (select jenkel from data_diri where id_lamaran = @idLamaran) = 1 then 
			2 
			when (select jenkel from data_diri where id_lamaran = @idLamaran) = 2 then 
			1
			end as jenkel,
			Usia_Pasangan as usia
			from Data_Pasangan where id_lamaran = @idLamaran
		  
		   UNION ALL
			
		   SELECT 
			id_anak as id, Id_lamaran as id_l, nm_anak as nm , pendidikan_anak as pendidikan,
			pekerjaan_anak as pekerjaan,'' as status_per, 'Anak' as status_data, jenkel_anak as jenkel, usia_anak as usia
			from Data_Anak where Id_lamaran = @idLamaran

GO
*/


/*
QUERY GRIDVIEW HISTORY BP

SELECT [KERJABODY_NOWO], [KERJABODY_TANGGAL], [KERJABODY_USER], 
	case [KERJABODY_STATUS] 
		when 1 then 'DITERIMA' 
		when 2 then 'BONGKAR' 
		when 3 then 'KETOK' 
		when 4 then 'DEMPUL' 
		when 5 then 'CAT/OVEN' 
		when 6 then 'POLES' 
		when 7 then 'PEMASANGAN' 
		when 8 then 'FINISHING'  
		when 9 then 'ANTRIAN' 
		when 10 then 'PENILAIAN QC - OK'	
		when 11 then 'PENILAIAN QC - REWORK' 
		when 12 then 'PENILAIAN QC - HASIL REWORK -- GOOD' 
		when 13 then 'PENILAIAN QC - HASIL REWORK -- NOT GOOD' 
		when 14 then 'PENILAIAN QC - HASIL REWORK -- LAIN-LAIN' 
		when 15 then 'PENILAIAN QC - HASIL REWORK -- CATATAN'  
		when 16 then 'PENYERAHAN UNIT VENDOR KE QC' 
		when 17 then 'PENERIMAAN UNIT QC DARI VENDOR'  
		when 18 then 'PENILAIAN QC - OK - PENYERAHAN UNIT KE SA BP'
		else 'UNCATEGORIZED' end AS statusval, 
	case [KERJABODY_LOKASI] 
		when 1 then 'lt. 1' 
		when 2 then 'lt. 2' 
		when 3 then 'lt. 3' 
		when 4 then 'lt.4' 
		when 5 then 'lt. 5' 
		when 6 then 'lt. 6' 
		when 7 then 'lt. 7' 
		when 8 then 'lt. 8' 
		when 9 then 'lt. 9' 
		else '' END AS lokasimobil, [KERJABODY_CATATAN] FROM [TEMP_KERJABODY] WHERE ([KERJABODY_NOWO] = @KERJABODY_NOWO) 
		ORDER BY KERJABODY_STATUS ASC

*/
/*
FLOW : KETIKA SELESAI PILIH RUANGAN, MAKA BISA PILIH MULTIPLE SUB BLOCK RUANGAN . KEMUDIAN BISA PILIH MULTIPLE POIN PENILAIAN DAN MEMILIH  
*/

/*
TAMBAH KOLOM INI DI TRXN_kpin
ALTER TABLE TRXN_KPIN
ADD KPIN_NAMA varchar(255); --nama

ALTER TABLE TRXN_KPIN
ADD KPIN_DEPT varchar(100); -- sales

ALTER TABLE TRXN_KPIN
ADD KPIN_SUBJAB varchar(20); -- a

ALTER TABLE TRXN_KPIN
ADD KPIN_KODES varchar(30); --112 / 128

STATE AKHIR PENGERJAAN : KONEKSI KE 180 UNTUK DAPAT NAMA SALES BERDASARKAN NKODE., NANTINYA AKAN DI SAVE KETIKA SAVE PENILAIAN SALES KE ATSAN

PAKE PIVOT
*/

/*
===========QUERY UNTUK MENAMPILKAN PENGAJUAN IZIN DETAIL , BERIKUT LOGIC STATUS NYA (FIX/10/6/19)
note : di tampilkan yg pending saja . yang expired tampilkan ke bu okta 

 SELECT Details.izin_id,
     b.izin_nik AS NIK,
	 h.IZIN_NAMA,
	 h.IZIN_NIK_APPVSPV,b.IZIN_TGLAPPVSPV,
	 h.IZIN_NIK_APPVMNG,b.IZIN_TGLAPPVMNG,
	 Details.id_detail,
     b.izin_jenis,
     b.izin_alasan,
     Details.izin_tgldetail,
	 (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) as TglDeadline,
	 --Details.izin_status,
	 case 
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) < GETDATE()
		and Details.izin_status is null
		then 'Expired' -- untuk case expired
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= GETDATE()
		and Details.izin_status is null
		then 'Pending'
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= GETDATE()
		and Details.izin_status is not null
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

	 =====REVISI==================
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

	 ----masih belum sempurna / ketika tgl appv mng ada status masih expired NIKMNG & NIKSPV = '462'
	    SELECT * FROM [DetailPengajuanIzin] 
   WHERE (([NIKMNG] = '462') OR ([NIKSPV] = '462'))  order by status_izin desc
*/
--good code / hanya menampilkan yg pending

--NOTE : 
/*
	jika ingin menambahkan user baru untuk PO, 88. maka masukan ke mugensupport ->tb_user. 
	dan masukan juga ke tb_userGeneral (jika bukan staff / venor luar)
	untuk bisa login ke sistem. berikan hak akses di menu utility
*/
--good code 
/*
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
	 --/status yang pending saja yang di tampilkan 
	 case
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null and b.IZIN_TGLAPPVSPV is null and b.izin_jenis <> 'Cuti'
		or 
		(select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null and b.IZIN_TGLAPPVMNG is null and b.izin_jenis <> 'Cuti'
		then 'Pending'

		else null
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
   order by TglDeadline DESC
*/


-- bad code
--/Kondisi ketika expired (2 atasan namun baru di setujui 1 atasan) //masuknya expired
/*		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) 
		< CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
			and Details.izin_status is null 
			and h.IZIN_NIK_APPVMNG <> '--' 
			and b.izin_jenis = 'Cuti'
			and b.IZIN_TGLAPPVSPV is not null
			and b.IZIN_TGLAPPVMNG is null
			then 'Expired'
	--/Kondisi ketika expired (1 atasan belum menyetujui) //masuknya expired
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) 
		< CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
			and Details.izin_status is null 
			and h.IZIN_NIK_APPVMNG <> '--' 
			and b.izin_jenis = 'Cuti'
			and b.IZIN_TGLAPPVSPV is null
			then 'Expired'
*/

select KERJABODY_STATUS from TEMP_KERJABODY 
where KERJABODY_STATUS = 16 and KERJABODY_NOWO = '152186'

SELECT * FROM TEMP_KERJABODY
WHERE KERJABODY_NOWO = '152186'

-- YANG BARU

                  <asp:ListItem Value="01">DISERAHKAN SA KE VENDOR</asp:ListItem>
                  <asp:ListItem Value="02">DITERIMA</asp:ListItem>
                  <asp:ListItem Value="03">BONGKAR</asp:ListItem>
                  <asp:ListItem Value="04">KETOK</asp:ListItem>
                  <asp:ListItem Value="05">DEMPUL</asp:ListItem>
                  <asp:ListItem Value="06">CAT / OVEN</asp:ListItem>
                  <asp:ListItem Value="07">POLES</asp:ListItem>
                  <asp:ListItem Value="08">PEMASANGAN</asp:ListItem>
                  <asp:ListItem Value="09">FINISHING</asp:ListItem>
                  <asp:ListItem Value="10">PENILAIAN QC - OK</asp:ListItem>
                  <asp:ListItem Value="11">PENILAIAN QC - REWORK</asp:ListItem>
                  <asp:ListItem Value="12">PENILAIAN QC - HASIL REWORK -- GOOD</asp:ListItem>
                  <asp:ListItem Value="13">PENILAIAN QC - HASIL REWORK -- NOT GOOD</asp:ListItem>
                  <asp:ListItem Value="14">PENILAIAN QC - HASIL REWORK -- LAIN-LAIN</asp:ListItem>
                  <asp:ListItem Value="15">JIKA HASIL REWORK LAIN2, CATATAN DARI QC</asp:ListItem>
                  <asp:ListItem Value="16">PENYERAHAN UNIT DARI VENDOR KE QC</asp:ListItem>
                  <asp:ListItem Value="17">PENERIMAAN UNIT QC DARI VENDOR</asp:ListItem>
                  <asp:ListItem Value="18">PENILAIAN QC KE SA BP</asp:ListItem>

       
		      1 'DISERAHKAN SA KE VENDOR                              (SELURUH SA BP – PSM / PURI) == budi/roby      
		      2. DITERIMA'                                            (BUDI / ROBY) ==
              3. 'BONGKAR'                                            (BUDI / ROBY)
              4. 'KETOK'                                              (BUDI / ROBY)
              5. 'DEMPUL'                                             (BUDI / ROBY)
              6. 'CAT/OVEN'                                           (BUDI / ROBY)
              7. 'POLES'                                              (BUDI / ROBY)
              8. 'PEMASANGAN'                                         (BUDI / ROBY)
              9. 'FINISHING'                                          (BUDI / ROBY) ---------------------→ JIKA OK, LANGSUNG KE NOMOR 14 DST
              10.'PENILAIAN QC - OK'                                  (MUCHLIS / REGIANSYAH)
              11. 'PENILAIAN QC - REWORK'                             (MUCHLIS / REGIANSYAH)
              12. 'PENILAIAN QC - HASIL REWORK – GOOD/NOT GOOD/LAIN2  (MUCHLIS / REGIANSYAH)
              13.  JIKA HASIL REWORK LAIN2, CATATAN DARI QC'          (MUCHLIS / REGIANSYAH)
              ==============================================================================14. 'PENYERAHAN UNIT DARI VENDOR KE QC'                 (BUDI / ROBY)
              ==============================================================================15. 'PENERIMAAN UNIT QC DARI VENDOR'                    (MUCHLIS / REGIANSYAH)
              16. 'PENYERAHAN UNIT QC KE SA BP'                       (MUCHLIS / REGIANSYAH)
              
			  17.    QC KLIK TOMBOL SEND EMAIL KE VENDOR              (MUCHLIS / REGIANSYAH)     

			  1-8 : budi / roby
			  9-12 : muchlis / REGIANSYAH
			  13 : budi /roby
			  14 - 15: muchlis/REGIANSYAH
			  16 : ke sa terkait

			  // tanya bu linda, ketika penilaian qc butuh catatan atau tidak



SELECT * FROM TEMP_KERJABODY
WHERE KERJABODY_NOWO = '153093'


			  RULES : 
			  /*
			  1. Muchlis bisa isi [10] / [11] ketika di database nilai tertinggi proses = 9
			  2. Siapapun ketika mengisi, jika nilai tertinggi [10] maka hanya bisa isi [14] - [16]. Lainya tidak bisa
			  3. SA di beri Akses : FORM JOB CONTROL FOREMAN -- ADD HISTORY & FORM JOB CONTROL FORMAN -- VIEW MENU

			  
			  4. Ketika delete, hanya bisa di status paling terakhir. jika delete yg lain tidak bisa
			  5. setelah delete update status_ketok ke state sebelum data yg di hapus 
			  6. yg bisa delete adalah yg masukin status terakhir 
			  	-ada 2 test case : 
				  	a. jika status 01, ketika delete maka update ke ketok menjadi null
					b. jika status di atas 01 ketika delete maka update ke ketok menjadi satus satu tingkat di bawahnya (select max)
			  7.setiap isi status , email ke user terkait
			  */     
			  

			-- ganti user wahyusa menjadi wahyu
			/*
			Case temuan : 
			1. Problem : ketika delete history pengerjaan, update yang di lakukan tidak sesuai data history. [karena history -1]
			harusnya delete dulu, kemudian di update berdasarkan select max di history bp
			*/

			  --CEK PSM USER SA
SELECT * FROM tb_userutility 
WHERE username IN (
'AGUS','SANDY','SUWANDI'
) ORDER BY username DESC

-- FORM JOB CONTROL FOREMAN -- ADD HISTORY
-- FORM JOB CONTROL FORMAN -- VIEW MENU

--INSERT INTO tb_userutility
--VALUES (
--'AGUS',
--'FORM JOB CONTROL FOREMAN -- ADD HISTORY')

--INSERT INTO tb_userutility
--VALUES (
--'SUWANDI',
--'FORM JOB CONTROL FOREMAN -- ADD HISTORY')

/*
Query untuk update Tanggal Form SDR

  UPDATE [TRXN_SDR]
  SET SDRLOG_TGLCLOSE = '2019-01-07 14:39:00', SDRLOG_UJITGL = '2019-01-07 14:34:00'
    WHERE SDRLOG_NO = 'SDR2018115'

*/


idbody	nobody	namaitem	tujuanitem	jumlahitem	hargaitem	pusatbiaya	reject	alasanreject	rejectoleh	vendor	nopurchaseorder	jumlahterima	jumlahkeluar	kelompok
4985	2019/INQ/05-00023	STAND PAMERAN	PAMERAN DI MALL DAAN MOGOT TGL 25 APRIL - 01 MEI 2019	1	27310000	SHOWROOM	APPROVE	NULL	NULL	WIN INTI PROMOSINDO, CV	2019/PO/05-00016	0	0	1



