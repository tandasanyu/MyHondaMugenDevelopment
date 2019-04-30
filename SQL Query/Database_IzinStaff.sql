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