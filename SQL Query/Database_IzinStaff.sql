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