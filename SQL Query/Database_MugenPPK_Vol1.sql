create table Master_Ruangan(
    Kode_Ruangan int IDENTITY(1,1) Primary Key, 
    Nama_Ruangan varchar (200) not null 
)

create table Sub_Ruangan(
    Kode_SubRuangan int IDENTITY(1,1) Primary Key, 
    Kode_Ruangan int not null, -- fk ke Master_Ruangan
    Nama_SubRuangan VARCHAR (200) not null
)

create TABLE Master_ItemPenilaian(
    Kode_ItemPenilaian int IDENTITY(1,1) Primary Key, 
    Item_Penilaian VARCHAR (200) not null
)

create TABLE Point_Penilaian (
    Kode_PoinPenilaian int IDENTITY(1,1) Primary Key, 
    Kode_Ruangan int not null, -- fk ke Master_Ruangan
    Kode_ItemPenilaian int not null, -- fk ke Master_ItemPenilaian
    Kode_SubRuangan int not null , -- fk ke Sub_Ruangan
    NIK VARCHAR (200) not null,
    Img_Path VARCHAR (200) not null, 
    Nilai VARCHAR (10) not null, -- 1-5
    Note VARCHAR (200) not null
)

--sending notifikasi ketika selesai poin penilaian ke  atasan langsung. 
-- RULES 
/*
1. cco bisa input (master)
2. atasan dan staff yg dinilai hanya bisa melihat report
3. Nantinya jika dibutuhkan departemen, cari di data_staff - STAFF_STATUSKERJADEPT
4. nik atasan (point penilaian) cari di data_staff (atasan 1 saja)

CONTOH JOIN 2 TABLE DARI 2 DATABASE BERBEDA 1 SERVER
Select STAFF_NAMA, NIK from HRDWEB.[dbo].DATA_STAFF tab1
join MugenPPK.[dbo].Point_Penilaian tab2 on tab1.STAFF_NIK = tab2.NIK
*/