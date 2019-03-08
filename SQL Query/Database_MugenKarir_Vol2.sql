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
    User_Nama VARCHAR (255) NOT NULL, -- nama pelamar
    User_Posisi VARCHAR (50) NOT NULL, --posisi yang di apply
    No_Daftar VARCHAR (255) NULL, -- NoDaftar akan di isi ketika pelamar selesai upload semua dokumen [format DFT + IDLAMARAN]
    Id_Login INT NOT NULL, -- AKAN MENJADI fk DARI TB.lOGIN_uSER 
    Tgl_Lamar smalldatetime Default GETDATE() NOT NULL, 
    Status_Lamaran int DEFAULT 0 NOT NULL, -- diterima / ditolak [1/0]
    Status_Undangan int DEFAULT 0 NOT NULL --di undang interview/ tidak di undang interview [1/0] 
)

--case ketika registrasi******************************************
--[1]
--ketika regist pelamar, insert username, pswd, user_email, user_posisi,
-- user_status 1, user level pelamar, user_nama_login

--[2]
/*ketika itu juga, input Data_Lamaran (
    User_Nama,
    User_Posisi,
    Id_Login,
)*/

