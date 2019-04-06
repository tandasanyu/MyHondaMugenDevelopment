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
CREATE TABLE DATA_IZIN_TANGGAL(
    Id_tanggal int IDENTITY (1,1) PRIMARY KEY, 
    izin_nik NVARCHAR (20) NOT NULL, --fk ke data_izin_body
    izin_id NVARCHAR (20) not null, --fk ke data_izin_header
    izin_tgldetail smalldatetime not null,
    izin_jamdetail NVARCHAR (10) , 
    izin_tglstatus NVARCHAR (20) not null, 
    izin_flag int default null -- [1 untuk tahunan/ 2 untuk pc]
)

insert into DATA_IZIN_TANGGAL (IZIN_ID, izin_tgldetail, IZIN_NIK, izin_jamdetail, izin_tglstatus) values

CREATE VIEW JoinDetailTgl AS
select  t.id_tanggal as Id, t.izin_nik as NIK, h.IZIN_NAMA as Nama,t.izin_id as IzinID, t.izin_tgldetail as TglDet,
 t.izin_jamdetail as JamDet, b.izin_alasan +'/'+ b.izin_alasan as Detail  ,
h.izin_nik_appvmng as NIKMNG, h.izin_nik_appvspv as NIKSPV,
b.izin_tglappvspv as SPV , b.izin_tglappvmng as MNG  , t.izin_tglstatus as Status  , b.izin_tglpengajuan as TglPeng
from data_izin_tanggal t
inner join data_izin_header h on h.izin_nik = t.izin_nik
inner join DATA_IZIN_BODY b on t.izin_id=b.izin_id 
 where h.izin_nama = 'HERLAMBANG RIZKY RAMADHAN'