--alter table Data_izin_detail
ALTER TABLE DATA_IZIN_DETAIL
ADD IZIN_STATUS varchar(20);

ALTER TABLE DATA_IZIN_DETAILPC
ADD IZIN_STATUS varchar(20);

ALTER TABLE DATA_IZIN_DETAILPC
ADD IZIN_ID_DETAILPC int IDENTITY (1,1) 

ALTER TABLE DATA_IZIN_DETAIL
ADD IZIN_ID_DETAIL int IDENTITY (1,1) 

ALTER TABLE data_history_chat
 ALTER COLUMN JENIS_CHAT INT
 
 UPDATE DATA_HISTORY_CHAT
 SET JENIS_CHAT = NULL

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

CREATE TABLE DATA_HISTORY_CHAT(
    ID_CHAT int IDENTITY (1,1) PRIMARY KEY, 
	ID_CHAT2 int, 
    USER_CHAT NVARCHAR (100) NOT NULL, --fk ke data_izin_body
    ISI_CHAT NVARCHAR (255) not null, --fk ke data_izin_header
    TGL_CHAT smalldatetime not null,
    NOWO_CHAT NVARCHAR (100) , 
    PROSES_CHAT NVARCHAR (30) not null
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


ALTER TABLE TEMP_KERJABODY
        ADD KERJABODY_DETAILCATATAN nvarchar(100) null
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

/*
Menghapus PO // mugensupport
delete from fmbhead where nofmbhead = '2019/INQ/07-00004'
delete from fmbbody where nobody = '2019/INQ/07-00004'

	2019/INQ/07-00007

*/

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

/*
cara mendapatkan id terbaru di PO 

SELECT count(nofmbhead) FROM fmbhead 
WHERE DATEPART(month, tglpemohonfmb) = month(GETDATE())
AND DATEPART(year, tglpemohonfmb) = year(GETDATE())
*/
-- 

UPDATE TEMP_CONTROLBR
SET CONTROLBR_KETOKNILAI = 16
WHERE CONTROLBR_NOWO = 155369

select * from TEMP_CONTROLBR where CONTROLBR_NOWO = 481028

select * from TEMP_KERJABODY where KERJABODY_NOWO = 481034 order by CONVERT (int, KERJABODY_STATUS) asc

--update TEMP_CONTROLBR
--set Flag = 'Puri'
--where CONTROLBR_NOWO = 481028

update TEMP_KERJABODY
set KERJABODY_STATUS = 09
where kerjabody_nowo = 481034 AND IDkrj_body =  2614

update TEMP_KERJABODY
set KERJABODY_STATUS = 02
where kerjabody_nowo = 481034 AND IDkrj_body =  2613

--insert into TEMP_KERJABODY (KERJABODY_NOWO, KERJABODY_TANGGAL, KERJABODY_USER, KERJABODY_STATUS, KERJABODY_LOKASI) 
--values ('481028', '2019-07-18 01:30:00', 'ROBYPURI', 02, 5)

delete from temp_kerjabody where kerjabody_nowo = 156701 and idkrj_body = 1261

select * from trxn_wohdr where wohdr_Fnopol like '%SYI%'

SELECT * FROM TEMP_KERJABODY WHERE KERJABODY_NOWO = 155403
select * from TEMP_CONTROLBR where controlbr_nowo = 155403

untuk update bodyrepair
*/


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
ALTER TABLE TEMP_CONTROLBR
ADD CONTROLBR_EMAILREPORT smalldatetime null

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
ALTER TABLE table_name
ALTER COLUMN column_name datatype;


Gagal ! Status yang Anda Pilih Tidak Bisa di Proses. Karena WO sudah masuk / melewati tahap finishing !
*/

/*
case PK ketika mau atasan 1 tk menilai bawahan 
bangkit / 
tglappvgead2 : 2019-07-16 10:22:00
 update TRXN_KPIH
set KPIH_APPVHEADTGL2 = null
where kpih_nik = 1043 and KPIH_TAHUN = 2018

erlin / 

exsan / 

 select KPIH_APPVHEADTGL2, KPIH_TAHUN from TRXN_KPIH where kpih_nik = 273
 select KPIH_APPVHEADTGL2, KPIH_TAHUN from TRXN_KPIH where kpih_nik = 1043
  select KPIH_APPVHEADTGL2, KPIH_TAHUN from TRXN_KPIH where kpih_nik = 765

*/

/*
/*
UPDATE TEMP_CONTROLBR
SET CONTROLBR_KETOKNILAI = 16
WHERE CONTROLBR_NOWO = 155369


select * from TEMP_KERJABODY where KERJABODY_NOWO = 155369

select * from TEMP_CONTROLBR where CONTROLBR_NOWO = 155369

update TEMP_KERJABODY
set KERJABODY_STATUS = 11
where kerjabody_nowo = 155369 AND IDkrj_body =  829

update TEMP_KERJABODY
set KERJABODY_STATUS = 16
where kerjabody_nowo = 155369 AND IDkrj_body =  830


*/

testing menu BP

 -- 476384
 
select * from TEMP_CONTROLBR WHERE CONTROLBR_NOWO = 476384
SELECT * FROM TEMP_KERJABODY WHERE KERJABODY_NOWO = 476384

--UPDATE TEMP_CONTROLBR
--SET CONTROLBR_KETOKNILAI = NULL
--WHERE CONTROLBR_NOWO = 478133

--DELETE FROM TEMP_KERJABODY
--WHERE KERJABODY_NOWO = 478133

delete from data_history_chat where nowo_chat = 145303 and id_chat = 16

UPDATE TEMP_CONTROLBR
SET CONTROLBR_KETOKNILAI = 09
WHERE CONTROLBR_NOWO = 145303

DELETE FROM TEMP_KERJABODY
WHERE KERJABODY_NOWO = 145303 and kerjabody_status = 06

SELECT * FROM TEMP_CONTROLBR WHERE CONTROLBR_NOWO = 145303
SELECT * FROM TEMP_KERJABODY WHERE KERJABODY_NOWO = 145303

SELECT KERJABODY_STATUS FROM TEMP_KERJABODY WHERE KERJABODY_NOWO = 

478133



145303

"SELECT [KERJABODY_NOWO], [KERJABODY_TANGGAL], [KERJABODY_USER],case [KERJABODY_STATUS]  
		WHEN 1 THEN 'DISERAHKAN SA KE VENDOR / PURI'
		when 2 then 'SERAH TERIMA UNIT' 
		when 3 then 'BONGKAR' 
		when 4 then 'KETOK' 
		when 5 then 'DEMPUL' 
		when 6 then 'CAT/OVEN' 
		when 7 then 'POLES' 
		when 8 then 'PEMASANGAN' 
		when 9 then 'FINISHING'  
		when 10 then 'UNIT SELESAI OLEH VENDOR'	
        when 11 then 'PENILAIAN QC - OK'	
		when 12 then 'PENILAIAN QC - NOT OK' 
		when 13 then 'PENILAIAN QC - REWORK' 
		when 14 then 'PENILAIAN QC - REWORK - OK'  
		when 15 then 'PENILAIAN QC - REWORK - NOT OK' 
		when 16 then 'PENYERAHAN UNIT QC KE SA BP'  
else 'UNCATEGORIZED' end AS statusval, 
case [KERJABODY_LOKASI] when 1 then 'lt. 1' when 2 then 'lt. 2' when 3 then 'lt. 3' when 4 then 'lt. 4' when 5 then 'lt. 5' when 6 then 'lt. 6' when 7 then 'lt. 7' when 8 then 'lt. 8' when 9 then 'lt. 9'  else '' END AS lokasimobil, [KERJABODY_CATATAN] FROM [TEMP_KERJABODY] WHERE ([KERJABODY_NOWO] = " + wo + ") AND KERJABODY_STATUS < 17 ORDER BY KERJABODY_STATUS ASC";


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

       
		      1 'DISERAHKAN SA KE VENDOR'                              (SELURUH SA BP – PSM / PURI) == budi/roby    
			  2.'DISERAHKAN SA KE DRIVER'  
		      3. 'DITERIMA'                                            (BUDI / ROBY) ==
              4. 'BONGKAR'                                            (BUDI / ROBY)
              5. 'KETOK'                                              (BUDI / ROBY)
              6. 'DEMPUL'                                             (BUDI / ROBY)
              7. 'CAT/OVEN'                                           (BUDI / ROBY)
              8. 'POLES'                                              (BUDI / ROBY)
              9. 'PEMASANGAN'                                         (BUDI / ROBY)
              10. 'FINISHING'                                          (BUDI / ROBY) ---------------------→ JIKA OK, LANGSUNG KE NOMOR 14 DST
              11.'PENILAIAN QC - OK'                                  (MUCHLIS / REGIANSYAH)
			  12. 'PENILAIAN QC - NOT OK'                             (MUCHLIS / REGIANSYAH)
              13. 'PENILAIAN QC - REWORK'                             (MUCHLIS / REGIANSYAH)
			  14. 'PENILAIAN QC - REWORK - OK'                        (MUCHLIS / REGIANSYAH)
			  15. 'PENILAIAN QC - REWORK - NOT OK'                    (MUCHLIS / REGIANSYAH)
              16. 'PENYERAHAN UNIT QC KE SA BP'                       (MUCHLIS / REGIANSYAH)
              
			  17.    QC KLIK TOMBOL SEND EMAIL KE VENDOR              (MUCHLIS / REGIANSYAH)     

			  1-8 : budi / roby
			  9-12 : muchlis / REGIANSYAH
			  13 : budi /roby
			  14 - 15: muchlis/REGIANSYAH
			  16 : ke sa terkait

			  /*
			  NO WO YANG DI GUNAKAN UNTUK TESTING : 154495

			  EMAIL OTOMATIS MASIH BERANTAKAN, CEK LAGI //DONE

			  KETIKA SUDAH MASUK TAHAP REWORK DIA TIDAK BISA MEMILIH TAHAP QC OK

			  tanya bu linda ketika sudah tahap rework ok / not ok apakah langsung ke tahap akhir 
			  */
			  BAHRUR NAMA USERNYA



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

/*
Query untuk update table pekerjaan bp

 delete from TEMP_KERJABODY where KERJABODY_NOWO = 479029 and KERJABODY_USER = 'BUDI'
 

  
  UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = '01' WHERE CONTROLBR_NOWO = 479029

  delete from TEMP_KERJABODY where KERJABODY_NOWO = 152186   
UPDATE TEMP_CONTROLBR SET CONTROLBR_KETOKNILAI = null WHERE CONTROLBR_NOWO = 152186


*/


idbody	nobody	namaitem	tujuanitem	jumlahitem	hargaitem	pusatbiaya	reject	alasanreject	rejectoleh	vendor	nopurchaseorder	jumlahterima	jumlahkeluar	kelompok
4985	2019/INQ/05-00023	STAND PAMERAN	PAMERAN DI MALL DAAN MOGOT TGL 25 APRIL - 01 MEI 2019	1	27310000	SHOWROOM	APPROVE	NULL	NULL	WIN INTI PROMOSINDO, CV	2019/PO/05-00016	0	0	1

/*
MAIN RULE 
1. BUAT STEP BARU SA MENYERAHKAN MOBIL KE DRIVER //done
2. LENGKAPI KEBUTUHAN DI SETIAP FUNCTION TERHADAP STEP BARU 
3. BUAT USER QC PSM PURI // BAHRUL  
4. BUAT USER BP PSM PURI // ROBY2 -- MEMPUNYAI HAK AKSES UNTUK MENGISI BP DI PSM DENGAN STEP KHUSUS. //done

INFOKAN KE MUCHLIS & BUDI

STEP BARU BERNILAI 20


TESTING OK : 479817

user nya robypuri/roby128
lanjut testing ke bp budi
*/




select * from tb_user where username like '%ROBY%'
select * from tb_userutility where username like '%budi%'

insert into tb_user (username, password, kdcabang, kddivisi, online, banned) 
values ('BAHRUL', 'BAHRUL112', 112, 'SERVICE112', 'N','N')

INSERT INTO tb_userutility
(username, hakakses)
--VALUES ('ROBYPURI', 'FORM JOB CONTROL FORMAN -- VIEW MENU'),
--VALUES ('ROBYPURI', 'FORM JOB CONTROL FOREMAN -- ADD HISTORY'),
--VALUES ('ROBYPURI', 'FORM JOB CONTROL FOREMAN -- DELETE HISTORY'),
--VALUES ('ROBYPURI', 'FORM JOB CONTROL FOREMAN -- CLOSING'),
--VALUES ('ROBYPURI', 'FORM JOB CONTROL FOREMAN -- UNCLOSING'),
--VALUES ('ROBYPURI', 'BODY & PAINT -- VIEW MENU')


/*
====== testing pembuatan detail izin 15/7/2019
use HRDWEB

select * from DATA_IZIN_BODY 
where IZIN_STATUS <> 'Pending' and izin_status <> 'Disetujui Manajer'
and izin_status <> 'Disetujui Atasan'

-- 10185 / di batalkan staff

--- desain view untuk detail
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
		-- untuk case expired
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) < CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null 
		then 'Expired' 
		-- untuk case pending
		when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		and Details.izin_status is null and b.IZIN_STATUS ='Pending'
		then 'Pending' 
		---- untuk case dibatalkan staff
		--when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		--and Details.izin_status is null and b.IZIN_STATUS ='Dibatalkan Staff'
		--then 'Dibatalkan Staff' 
		---- untuk case di batalkan hrd
		--when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		--and Details.izin_status is null and b.IZIN_STATUS ='Dibatalkan HRD'
		--then 'Dibatalkan HRD' 
		---- untuk case di batalkan Manajer
		--when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		--and Details.izin_status is null and b.IZIN_STATUS ='Dibatalkan Manajer'
		--then 'Dibatalkan Manajer' 
		---- untuk case di batalkan Atasan
		--when (select izin_tgldeadline from data_izin_body where izin_id = Details.izin_id) >= CAST(CONVERT (CHAR(8),GETDATE(), 112) AS smalldatetime)
		--and Details.izin_status is null and b.IZIN_STATUS ='Dibatalkan Atasan'
		--then 'Dibatalkan Atasan' 
		else 
		b.IZIN_STATUS
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
/*
	ORDER BY JAM DENGAN RANGE 
	   SELECT 
    IZIN_NIK as [Sum], 
    Datepart(hour, IZIN_TGLAPPVSPV) AS [Hour]
FROM
    DATA_IZIN_BODY
ORDER BY
    CASE 
	WHEN Datepart(hour, IZIN_TGLAPPVSPV) >= 13 THEN Datepart(hour, IZIN_TGLAPPVSPV)  
        --WHEN Datepart(hour, IZIN_TGLAPPVSPV) >= 6 THEN Datepart(hour, IZIN_TGLAPPVSPV) 
        --ELSE Datepart(hour, IZIN_TGLAPPVSPV) + 24 
    END
	DESC
*/

/*
RULE UNTUK TAMPILAN APPRV IZIN

ketika atasan 1 apprv maka update status keseluruhan dan update status detail menjadi disetujui atasan
ketika atasan 2 apprv maka update status keseluruhan dan update status detail menjadi disetujui manajer 
manajer bisa mengurangi pengajuan
kenapa di pisah antara izin cuti dan izin selain cuti karena mau menerapkan rule kalo tampilan di manajer yang wajib dia approve saja makanya di pisah
cuti dan selain cuti dengan kondisi where ()
1. MANAJER
	-- tampilan apprv manajer
	Tampilan hanya yang NIKMNG / NIKSPV nya dia. dan status Pengajuan = Pending / disetujui Atasan order by status pengajuan desc
2. SPV
*/


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
			then 'Disetujui Atasan 1tk Lebih Tinggi -- CUTI BIASA / DELAY' 
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
			end as Status_Izin
		,
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
   --ORDER BY B.IZIN_TGLDEADLINE DESC
where b.IZIN_NIK = 107



--***

select * from ApprovalIzinDetail
where izin_jenis = 'Cuti' and izin_alasan='Cuti' and (nikspv=289 or nikmng =289)
ORDER BY status_izin desc

select * from ApprovalIzinDetail
where  izin_alasan<>'Cuti' and nikspv=289 
ORDER BY status_izin desc

select * from ApprovalIzinDetail where NIKSPV = 289 and izin_alasan<>'Cuti' 
and izin_tgldetail >='2019-07-17 00:00:00' and  izin_tgldetail <= '2019-07-19 00:00:00'
ORDER BY status_izin desc

SELECT * FROM [ApprovalIzinDetail] 
WHERE (([NIKMNG] = 147) OR ([NIKSPV] = 147))
and atasan2 <> '--' and izin_jenis = 'Cuti' and izin_jenis = 'cuti'
order by status_izin desc

SELECT * FROM DATA_STAFF WHERE STAFF_NAMA LIKE '%WIWIT%'

SELECT * FROM DATA_IZIN_BODY WHERE IZIN_ID = 10713
SELECT * FROM DATA_IZIN_DETAIL WHERE IZIN_ID = 10713

use MugenKarir
select * from Data_Pekerjaan where Id_Lamaran= 68
select * from Data_Referensi where Id_Lamaran= 68

use HRDWEB
select * from trxn_sdr where sdrlog_no= 'SDR20190710'

select * from ApprovalIzinDetail where NIK = 1070 
ORDER BY STATUS_IZIN DESC

select * from DATA_IZIN_HEADER
where izin_nama like '%azis%'


select STAFF_STATUSKERJATGLKELUAR from data_staff
where staff_nama like '%komang%'

INSERT INTO DATA_IZIN_HEADER 
(IZIN_NIK, IZIN_NAMA,IZIN_NIK_APPVSPV, IZIN_NIK_APPVMNG)
SELECT STAFF_NIK, staff_nama, STAFF_ATASAN1,STAFF_ATASAN2
FROM data_staff
WHERE staff_nik = 1036;

select data_staff.STAFF_NIK, data_staff.STAFF_NAMA, 
data_staff.STAFF_STATUSKERJAJABATAN, data_staff.STAFF_STATUSKERJADEPT, 
data_staff.STAFF_STATUSKERJALOKASI, data_izin_header.izin_saldo, data_izin_header.izin_saldo_cuti_tahunan_berlaku,
 DATA_IZIN_SALDO_PENDINGCUTI.IZIN_SALDO_PENDINGCUTI, DATA_IZIN_SALDO_PENDINGCUTI.IZIN_SALDO_PENDINGCUTI_BERLAKU,
DATA_IZIN_SALDO_HUTANGCUTI.IZIN_SALDO_HUTANGCUTI, data_izin_header.IZIN_SALDO_CUTI_TAHUNAN_BERLAKU from 
data_staff 
left join data_izin_header on data_staff.staff_nik = 
data_izin_header.izin_nik
--left join DATA_IZIN_SALDO_PENDINGCUTI on data_staff.staff_nik = DATA_IZIN_SALDO_PENDINGCUTI .izin_nik
--left join DATA_IZIN_SALDO_HUTANGCUTI on data_staff.staff_nik = DATA_IZIN_SALDO_HUTANGCUTI .izin_nik 
where STAFF_STATUSKERJATGLKELUAR IS  null 

/*
        '** split by ,**
        'For Each item In IDs
        '    Dim s As String = item
        '    ' Split string based on comma
        '    Dim words As String() = s.Split(New Char() {","c})

        '    ' Use For Each loop over words and display them

        '    Dim word As String
        '    For Each word In words
        '        Response.Write("<script>alert('Value : " + word + "')</script>")
        '    Next
        'Next
        '** split by ,**
        'For Each item In IDs
        '    words = item.Split(","c)
        'Next
        'For Each word As String In words
        '    Response.Write("<script>alert('Value : " + word + "')</script>")
        'Next
        '** split by ,**
*/