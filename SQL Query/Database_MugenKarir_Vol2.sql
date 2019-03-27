--Dokumentasi Databse dan Table Mugen Karir V.2

--truncate namaTb // untuk menghapus data di table dan mengulang autoincrement

/*Tb.List Lowongan*/
create table List_Lowongan(
	Id_Lowongan int IDENTITY(1,1) Primary Key, 
	Posisi varchar (20) not null,
	Kualifikasi varchar(200) not null, 
	Status_Lowongan int not null, 
	Tgl_Post smalldatetime Default GETDATE() NOT NULL
)
/*Tb. Login*/
create table Login_User (
    Id_Login int IDENTITY(1,1) PRIMARY KEY , -- id data luser login
	User_Nama_Login varchar(100) NOT NULL, 
    Username_Login varchar (100) UNIQUE Not null, -- username pengguna
    Password_Login varchar (100)not NULL, -- paswd pengguna
    User_Email varchar (50)  NULL, --email pengguna
    User_Posisi VARCHAR (50)  NULL, --posisi yang di apply
    Create_Date smalldatetime DEFAULT GETDATE() , --otomatis , kapan user tsb di create
    User_Status int NOT NULL, -- AKtif / Non [1/0]
    User_Level varchar (10) NOT NULL -- status pengguna [Pelamar, HRD, Master]
)
/*tB.Data_Lamaran*/
create table Data_Lamaran (
    Id_Lamaran int IDENTITY (1,1) PRIMARY KEY,-- id lamaran
    User_Nama VARCHAR (255) NOT NULL, -- nama pelamar relasi dari User_Nama_Login table Login_User
    User_Posisi VARCHAR (50) NOT NULL, --posisi yang di apply
    No_Daftar VARCHAR (255) NULL, -- NoDaftar akan di isi ketika pelamar selesai upload semua dokumen [format DFT + IDLAMARAN]
    Id_Login INT NOT NULL, -- AKAN MENJADI fk DARI TB.lOGIN_uSER 
    Tgl_Lamar smalldatetime Default GETDATE() NOT NULL, 
    Status_Lamaran int DEFAULT 0 NOT NULL, -- diterima / ditolak [1/0]
    Status_Undangan int DEFAULT 0 NOT NULL --di undang interview/ tidak di undang interview [1/0] 
)
/*
ketika kirim lamaran (Halaman Home Pelamar), Update Data_lamaran -> Status_Lamaran = 1, Status_Undangan = 0
dan Login_User-> User_Status = 0
*/

/*
Data lamaran yang di tampilkan di menu hrd adalah yg Status_Lamaran = 1  
DATA PELAMAR (dATA YG SUDAH DI TERIMA)
HOME (DATA YG BARU / BELUM DI TERIMA)
*/


/*Tb.Data Diri*/ -- hanya rekBCA yg bisa Null
create table Data_Diri (
    Id_DataDiri int IDENTITY (1,1) PRIMARY KEY, 
    Id_Lamaran int UNIQUE NOT NULL, -- fk relasi ke tb.Data_lamaran [Id_Lamaran] + unique
    Nama_Lengkap varchar (255) NOT NULL, 
    Nama_Panggilan varchar (255) NOT NULL, 
    Tempat_Lahir varchar (100) NOT NULL, 
    Tgl_Lahir smalldatetime NOT NULL, 
    JenKel int NOT NULL, -- 1 = pria, 2=wanita
    Agama int NOT NULL, -- 1= islam, 2=kristen, 3=katolik, 4=hindu, 5=budha, 6=konghucu
    Alamat_KTP varchar (255) NOT NULL, 
    Alamat_Tinggal varchar (255) NOT NULL, 
    No_Telp varchar (100) NOT  NULL, 
    No_HP varchar (100) NOT NULL, 
    Email varchar(100), 
    Hobi varchar (100), 
    No_KTP varchar (100) NOT NULL, 
    No_NPWP varchar (100) NOT NULL, 
    No_Jamsos varchar (100) not null, 
    Jen_SIM int NOT NULL, 
    No_SIM varchar (100) NOT NULL, 
    NoRekBCA varchar (100)  NULL
)

/*Tb.Data Keluarga mempunyai beberapa table 
1.Data_Keluarga (isinya ayah ibu)
2.Data_Saudara (isinya saudara kandung // jika ada)
3.Data_Pasangan (isinya istri / suami // jika ada)
4.Data_Anak (isinya anak // jika ada)
*/
--**Tb data_keluarga
create table Data_Keluarga (
    Id_Keluarga int IDENTITY (1,1) PRIMARY KEY, 
    Id_Lamaran int UNIQUE NOT NULL, -- fk relasi ke tb.Data_lamaran [Id_Lamaran] + unique
    Nm_Ayah varchar (100) NOT NULL, 
    Nm_Ibu varchar (100) NOT NULL, 
    Pendidikan_Ayah int NOT NULL,
    Usia_Ayah int NOT NULL, 
    Pekerjaan_Ayah int NOT NULL, 
    Pendidikan_Ibu int NOT NULL,
    Usia_Ibu int NOT NULL, 
    Pekerjaan_Ibu int NOT NULL
)

--** Tb data_Saudara
create table Data_Saudara(
    Id_Saudara int IDENTITY (1,1) PRIMARY KEY, 
    Id_Lamaran int NOT NULL, -- fk relasi ke tb.Data_lamaran [Id_Lamaran] 
    Nm_Saudara VARCHAR (100) NOT NULL, 
    JenKel_Saudara int NOT NULL, 
    Usia_Saudara Int NOT NULL, 
    Pendidikan_Saudara Int NOT NULL, 
    Pekerjaan_Saudara Int NOT NULL
)

--**Tb Pasangan
create table Data_Pasangan (
    Id_pasangan int IDENTITY (1,1) PRIMARY KEY, 
    Id_lamaran INT UNIQUE NOT NULL, 
    Nm_pasangan varchar (100) NOT NULL, 
    Usia_Pasangan INT NOT NULL,
    Pendidikan_Pasangan INT NOT NULL, 
    Pekerjaan_Pasangan INT NOT NULL
)

--**Tb Data_Anak
create table Data_Anak (
    Id_Anak int IDENTITY (1,1) PRIMARY KEY, 
    Id_lamaran INT NOT NULL, 
    Nm_Anak varchar (100) NOT NULL, 
    JenKel_Anak int NOT NULL,
    Usia_Anak int NOT NULL, 
    Pendidikan_Anak int NOT NULL,
    Pekerjaan_Anak int NOT NULL
)

--Tb Pertanyaan

create table Data_Pertanyaan (
    Id_Pertanyaan int IDENTITY (1,1) PRIMARY KEY, 
    Id_lamaran INT NOT NULL, 
    Desc_Sakit varchar (100) , 
    Kelebihan varchar (100) NOT NULL, 
    Kekurangan varchar (100) NOT NULL, 
    Keahlian varchar (100) NOT NULL, 
    JobDesc varchar (100) NOT NULL, 
    HarapGaji money NOT NULL, 
    Tunjangan varchar (100) NOT NULL, 
    SiapBekerja int NOT NULL, 
    Penempatan int NOT NULL, 
    AlasanBergabung varchar (100) NOT NULL, 
    TentangMugen varchar (100) NOT NULL, 
    LingkunganKerja varchar(100) NOT NULL
)

--TB UploadFoto
create table Data_UploadFoto (
    Id_Foto int IDENTITY (1,1) PRIMARY KEY, 
    Id_lamaran int not null, 
    Path_Foto varchar (50) not null
)
--TB UploadKTP
create table Data_UploadKTP (
    Id_Ktp int IDENTITY (1,1) PRIMARY KEY, 
    Id_lamaran int not null, 
    Path_Foto varchar (50) not null
)
--TB UploadNPWP
create table Data_UploadNPWP (
    Id_Npwp int IDENTITY (1,1) PRIMARY KEY, 
    Id_lamaran int not null, 
    Path_Foto varchar (50) not null
)
--TB UploadKK
create table Data_UploadKK (
    Id_KK int IDENTITY (1,1) PRIMARY KEY, 
    Id_lamaran int not null, 
    Path_Foto varchar (50) not null
)
--TB UploadNPWP
create table Data_UploadIjazah (
    Id_Ijazah int IDENTITY (1,1) PRIMARY KEY, 
    Id_lamaran int not null, 
    Path_Foto varchar (50) not null
)
--TB UploadNPWP
create table Data_UploadTranskrip (
    Id_Transkrip int IDENTITY (1,1) PRIMARY KEY, 
    Id_lamaran int not null, 
    Path_Foto varchar (50) not null
)
--TB UploadNPWP
create table Data_UploadSLamaran (
    Id_SLamaran int IDENTITY (1,1) PRIMARY KEY, 
    Id_lamaran int not null, 
    Path_Foto varchar (50) not null
)
--TB UploadNPWP

create table Data_UploadCV (
    Id_CV int IDENTITY (1,1) PRIMARY KEY, 
    Id_lamaran int not null, 
    Path_Foto varchar (50) not null,
	Date_Upload smalldatetime default getdate()
)

--case ketika registrasi******************************************
/*
[1]
ketika regist pelamar, insert username, pswd, user_email, user_posisi,
 user_status 1, user level pelamar, user_nama_login

[2]
ketika itu juga, input Data_Lamaran (
    User_Nama,
    User_Posisi,
    Id_Login,
)
[3]
kemudian kirim email berisi username dan password
[4]
kemudian, insert row pada semua table detil pelamar [Id_Lamaran] fk di setiap table detil
*/

/*
Untuk case pengisian detail data pelamar, mencari id_lamaran berdasarkan namauser [usernama] 
yang di passing dari halaman home pelamar
*/

