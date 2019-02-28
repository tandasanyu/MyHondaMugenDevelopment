-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Feb 28, 2019 at 02:33 PM
-- Server version: 5.7.25
-- PHP Version: 7.2.7

SET FOREIGN_KEY_CHECKS=0;
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hondamug_baru`
--
CREATE DATABASE IF NOT EXISTS `hondamug_baru` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `hondamug_baru`;

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` int(3) NOT NULL,
  `username` varchar(30) NOT NULL,
  `password` varchar(32) NOT NULL,
  `level` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `cicilan`
--

CREATE TABLE `cicilan` (
  `id_cicilan` int(3) NOT NULL,
  `tipe` varchar(60) NOT NULL,
  `tenor` int(11) NOT NULL,
  `angsuran` int(11) NOT NULL,
  `dp` int(11) NOT NULL,
  `harga` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_anak`
--

CREATE TABLE `data_anak` (
  `idAnak` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `nmAnak` varchar(60) NOT NULL,
  `jkelAnak` int(1) NOT NULL,
  `usiaAnak` int(3) NOT NULL,
  `pendidikanAnak` varchar(60) NOT NULL,
  `pekerjaanAnak` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_booking`
--

CREATE TABLE `data_booking` (
  `booking_id` varchar(10) NOT NULL,
  `booking_nama` varchar(30) NOT NULL,
  `booking_tlp` varchar(15) NOT NULL,
  `booking_email` varchar(50) NOT NULL,
  `booking_nopol` varchar(12) NOT NULL,
  `booking_tgl` varchar(20) NOT NULL,
  `booking_jam` varchar(11) NOT NULL,
  `booking_tipe` varchar(25) NOT NULL,
  `booking_lokasi` int(11) NOT NULL,
  `booking_status` int(11) NOT NULL,
  `booking_jadwal` varchar(20) NOT NULL,
  `booking_tahun` varchar(4) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_diri`
--

CREATE TABLE `data_diri` (
  `idDataDiri` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `nama` varchar(60) NOT NULL,
  `panggilan` varchar(30) NOT NULL,
  `tempatLahir` varchar(50) NOT NULL,
  `tglLahir` varchar(10) NOT NULL,
  `jkel` int(1) NOT NULL,
  `agama` int(1) NOT NULL,
  `alamatKtp` text NOT NULL,
  `alamatTinggal` text NOT NULL,
  `hp` varchar(15) NOT NULL,
  `email` varchar(50) NOT NULL,
  `telp` varchar(15) NOT NULL,
  `npwp` varchar(25) NOT NULL,
  `hobi` varchar(60) NOT NULL,
  `sim` varchar(12) NOT NULL,
  `ktp` varchar(16) NOT NULL,
  `bca` varchar(10) NOT NULL,
  `jnsSim` int(1) DEFAULT NULL,
  `jamsostek` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_keluarga`
--

CREATE TABLE `data_keluarga` (
  `idKeluarga` int(6) NOT NULL,
  `username` varchar(25) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `nmAyah` varchar(60) NOT NULL,
  `usiaAyah` int(3) NOT NULL,
  `pendidikanAyah` varchar(60) NOT NULL,
  `pekerjaanAyah` varchar(60) NOT NULL,
  `nmIbu` varchar(60) NOT NULL,
  `usiaIbu` int(3) NOT NULL,
  `pendidikanIbu` varchar(60) NOT NULL,
  `pekerjaanIbu` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_kemampuanbahasa`
--

CREATE TABLE `data_kemampuanbahasa` (
  `idBahasa` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `jnsBahasa` varchar(60) NOT NULL,
  `penguasaan` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_lamaran`
--

CREATE TABLE `data_lamaran` (
  `posisi` varchar(100) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `idLamaran` int(6) NOT NULL,
  `tglLamar` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `statusLamaran` int(1) NOT NULL,
  `statusUndangan` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_organisasi`
--

CREATE TABLE `data_organisasi` (
  `idOrganisasi` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `nmOrg` varchar(60) NOT NULL,
  `tahunOrg` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_pasangan`
--

CREATE TABLE `data_pasangan` (
  `idPasangan` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `statusKawin` int(1) NOT NULL,
  `nmPasangan` varchar(60) NOT NULL,
  `usiaPasangan` int(1) NOT NULL,
  `pendidikanPasangan` varchar(60) NOT NULL,
  `pekerjaanPasangan` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_pekerjaan`
--

CREATE TABLE `data_pekerjaan` (
  `idPekerjaan` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `nmPerusahaan` varchar(60) NOT NULL,
  `alamatPerusahaan` text NOT NULL,
  `telpPerusahaan` varchar(15) NOT NULL,
  `jabatan` varchar(60) NOT NULL,
  `nmAtasan` varchar(60) NOT NULL,
  `tugas` text NOT NULL,
  `wMasuk` varchar(10) NOT NULL,
  `wKeluar` varchar(10) NOT NULL,
  `gAwal` varchar(12) NOT NULL,
  `gAkhir` varchar(12) NOT NULL,
  `alasanKeluar` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_pendidikanformal`
--

CREATE TABLE `data_pendidikanformal` (
  `idFormal` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `jenjangPendidikan` varchar(60) NOT NULL,
  `nmInstansi` varchar(60) NOT NULL,
  `kotaInstansi` varchar(60) NOT NULL,
  `thnMasuk` varchar(4) NOT NULL,
  `thnKeluar` varchar(4) NOT NULL,
  `kelulusan` int(1) NOT NULL,
  `jurusan` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_pendidikannonformal`
--

CREATE TABLE `data_pendidikannonformal` (
  `idNonformal` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `nmInstansiNon` varchar(60) NOT NULL,
  `tahunNon` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_pengalamanmemimpin`
--

CREATE TABLE `data_pengalamanmemimpin` (
  `idPengalaman` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `pengalamanLeader` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_pertanyaan`
--

CREATE TABLE `data_pertanyaan` (
  `idPertanyaan` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `descSakit` text NOT NULL,
  `kelebihan` text NOT NULL,
  `kekurangan` text NOT NULL,
  `keahlian` text NOT NULL,
  `jobDesc` text NOT NULL,
  `harapanGaji` text NOT NULL,
  `tunjangan` text NOT NULL,
  `mulaiKerja` text NOT NULL,
  `penempatan` varchar(60) NOT NULL,
  `alasanGabung` text NOT NULL,
  `tentangMugen` text NOT NULL,
  `lingkunganKerja` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_referensi`
--

CREATE TABLE `data_referensi` (
  `idReferensi` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `nmReferensi` varchar(60) NOT NULL,
  `alamatReferensi` text NOT NULL,
  `telpReferensi` varchar(15) NOT NULL,
  `pekerjaanReferensi` varchar(60) NOT NULL,
  `hubunganReferensi` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_saudara`
--

CREATE TABLE `data_saudara` (
  `idSaudara` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `nmSaudara` varchar(60) NOT NULL,
  `jkelSaudara` int(1) NOT NULL,
  `usiaSaudara` int(3) NOT NULL,
  `pendidikanSaudara` varchar(60) NOT NULL,
  `pekerjaanSaudara` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `data_slide`
--

CREATE TABLE `data_slide` (
  `id_slide` int(11) NOT NULL,
  `path` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dokumen_cv`
--

CREATE TABLE `dokumen_cv` (
  `idCV` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `pathCV` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dokumen_foto`
--

CREATE TABLE `dokumen_foto` (
  `idFoto` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `pathFoto` varchar(255) NOT NULL,
  `statusFoto` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dokumen_ijazah`
--

CREATE TABLE `dokumen_ijazah` (
  `idIjazah` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `pathIjazah` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dokumen_kk`
--

CREATE TABLE `dokumen_kk` (
  `idKK` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `pathKK` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dokumen_ktp`
--

CREATE TABLE `dokumen_ktp` (
  `idKtp` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `pathKtp` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dokumen_nilai`
--

CREATE TABLE `dokumen_nilai` (
  `idNilai` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `pathNilai` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dokumen_npwp`
--

CREATE TABLE `dokumen_npwp` (
  `idNPWP` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `pathNPWP` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dokumen_surat`
--

CREATE TABLE `dokumen_surat` (
  `idSurat` int(6) NOT NULL,
  `noDaftar` varchar(11) NOT NULL,
  `username` varchar(25) NOT NULL,
  `pathSurat` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `event`
--

CREATE TABLE `event` (
  `id_event` int(3) NOT NULL,
  `nm_event` varchar(50) NOT NULL,
  `tgl_event` varchar(10) NOT NULL,
  `keterangan` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `jenis_mobil`
--

CREATE TABLE `jenis_mobil` (
  `kd_jenis` int(3) NOT NULL,
  `kd_mobil` varchar(5) NOT NULL,
  `jns_mobil` varchar(50) NOT NULL,
  `harga` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `kode_mobil`
--

CREATE TABLE `kode_mobil` (
  `id_kode` int(10) NOT NULL,
  `kd_mobil` varchar(5) NOT NULL,
  `keterangan` varchar(25) NOT NULL,
  `tglUpdate` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `lamaran`
--

CREATE TABLE `lamaran` (
  `nama` varchar(30) NOT NULL,
  `email` varchar(100) NOT NULL,
  `alamat` text NOT NULL,
  `posisi` varchar(30) NOT NULL,
  `pendidikan` varchar(10) NOT NULL,
  `lamaran` varchar(255) NOT NULL,
  `keterangan` text NOT NULL,
  `id_lamaran` int(5) NOT NULL,
  `tgl_lamar` varchar(10) NOT NULL,
  `jkel` int(1) NOT NULL,
  `nohp` varchar(15) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `leasing`
--

CREATE TABLE `leasing` (
  `id_leasing` int(4) NOT NULL,
  `nm_leasing` varchar(100) NOT NULL,
  `bunga` int(3) NOT NULL,
  `asuransi1` varchar(5) NOT NULL,
  `asuransi2` varchar(5) NOT NULL,
  `asuransi3` varchar(5) NOT NULL,
  `asuransi4` varchar(5) NOT NULL,
  `asuransi5` varchar(5) NOT NULL,
  `provisi` int(3) NOT NULL,
  `admin` int(8) NOT NULL,
  `tgl_update` varchar(25) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `lowongan`
--

CREATE TABLE `lowongan` (
  `id_lowongan` int(3) NOT NULL,
  `posisi` varchar(60) NOT NULL,
  `kualifikasi` text NOT NULL,
  `status` int(1) NOT NULL,
  `tgl_posting` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `temp_akun`
--

CREATE TABLE `temp_akun` (
  `id_akun` int(4) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(100) NOT NULL,
  `posisi` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `testdrive`
--

CREATE TABLE `testdrive` (
  `id_testdrive` int(5) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `jkel` int(1) NOT NULL,
  `nohp` varchar(15) NOT NULL,
  `email` varchar(100) NOT NULL,
  `alamat` text NOT NULL,
  `tgl` varchar(10) NOT NULL,
  `jam` varchar(10) NOT NULL,
  `lokasi` varchar(50) NOT NULL,
  `kendaraan` varchar(30) NOT NULL,
  `status` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `cicilan`
--
ALTER TABLE `cicilan`
  ADD PRIMARY KEY (`id_cicilan`);

--
-- Indexes for table `data_anak`
--
ALTER TABLE `data_anak`
  ADD PRIMARY KEY (`idAnak`);

--
-- Indexes for table `data_booking`
--
ALTER TABLE `data_booking`
  ADD PRIMARY KEY (`booking_id`);

--
-- Indexes for table `data_diri`
--
ALTER TABLE `data_diri`
  ADD PRIMARY KEY (`idDataDiri`);

--
-- Indexes for table `data_keluarga`
--
ALTER TABLE `data_keluarga`
  ADD PRIMARY KEY (`idKeluarga`);

--
-- Indexes for table `data_kemampuanbahasa`
--
ALTER TABLE `data_kemampuanbahasa`
  ADD PRIMARY KEY (`idBahasa`);

--
-- Indexes for table `data_lamaran`
--
ALTER TABLE `data_lamaran`
  ADD PRIMARY KEY (`idLamaran`);

--
-- Indexes for table `data_organisasi`
--
ALTER TABLE `data_organisasi`
  ADD PRIMARY KEY (`idOrganisasi`);

--
-- Indexes for table `data_pasangan`
--
ALTER TABLE `data_pasangan`
  ADD PRIMARY KEY (`idPasangan`);

--
-- Indexes for table `data_pekerjaan`
--
ALTER TABLE `data_pekerjaan`
  ADD PRIMARY KEY (`idPekerjaan`);

--
-- Indexes for table `data_pendidikanformal`
--
ALTER TABLE `data_pendidikanformal`
  ADD PRIMARY KEY (`idFormal`);

--
-- Indexes for table `data_pendidikannonformal`
--
ALTER TABLE `data_pendidikannonformal`
  ADD PRIMARY KEY (`idNonformal`);

--
-- Indexes for table `data_pengalamanmemimpin`
--
ALTER TABLE `data_pengalamanmemimpin`
  ADD PRIMARY KEY (`idPengalaman`);

--
-- Indexes for table `data_pertanyaan`
--
ALTER TABLE `data_pertanyaan`
  ADD PRIMARY KEY (`idPertanyaan`);

--
-- Indexes for table `data_referensi`
--
ALTER TABLE `data_referensi`
  ADD PRIMARY KEY (`idReferensi`);

--
-- Indexes for table `data_saudara`
--
ALTER TABLE `data_saudara`
  ADD PRIMARY KEY (`idSaudara`);

--
-- Indexes for table `data_slide`
--
ALTER TABLE `data_slide`
  ADD PRIMARY KEY (`id_slide`);

--
-- Indexes for table `dokumen_cv`
--
ALTER TABLE `dokumen_cv`
  ADD PRIMARY KEY (`idCV`);

--
-- Indexes for table `dokumen_foto`
--
ALTER TABLE `dokumen_foto`
  ADD PRIMARY KEY (`idFoto`);

--
-- Indexes for table `dokumen_ijazah`
--
ALTER TABLE `dokumen_ijazah`
  ADD PRIMARY KEY (`idIjazah`);

--
-- Indexes for table `dokumen_kk`
--
ALTER TABLE `dokumen_kk`
  ADD PRIMARY KEY (`idKK`);

--
-- Indexes for table `dokumen_ktp`
--
ALTER TABLE `dokumen_ktp`
  ADD PRIMARY KEY (`idKtp`);

--
-- Indexes for table `dokumen_nilai`
--
ALTER TABLE `dokumen_nilai`
  ADD PRIMARY KEY (`idNilai`);

--
-- Indexes for table `dokumen_npwp`
--
ALTER TABLE `dokumen_npwp`
  ADD PRIMARY KEY (`idNPWP`);

--
-- Indexes for table `dokumen_surat`
--
ALTER TABLE `dokumen_surat`
  ADD PRIMARY KEY (`idSurat`);

--
-- Indexes for table `event`
--
ALTER TABLE `event`
  ADD PRIMARY KEY (`id_event`);

--
-- Indexes for table `jenis_mobil`
--
ALTER TABLE `jenis_mobil`
  ADD PRIMARY KEY (`kd_jenis`);

--
-- Indexes for table `kode_mobil`
--
ALTER TABLE `kode_mobil`
  ADD PRIMARY KEY (`id_kode`);

--
-- Indexes for table `lamaran`
--
ALTER TABLE `lamaran`
  ADD PRIMARY KEY (`id_lamaran`);

--
-- Indexes for table `leasing`
--
ALTER TABLE `leasing`
  ADD PRIMARY KEY (`id_leasing`);

--
-- Indexes for table `lowongan`
--
ALTER TABLE `lowongan`
  ADD PRIMARY KEY (`id_lowongan`);

--
-- Indexes for table `temp_akun`
--
ALTER TABLE `temp_akun`
  ADD PRIMARY KEY (`id_akun`);

--
-- Indexes for table `testdrive`
--
ALTER TABLE `testdrive`
  ADD PRIMARY KEY (`id_testdrive`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(3) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `cicilan`
--
ALTER TABLE `cicilan`
  MODIFY `id_cicilan` int(3) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_anak`
--
ALTER TABLE `data_anak`
  MODIFY `idAnak` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_diri`
--
ALTER TABLE `data_diri`
  MODIFY `idDataDiri` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_keluarga`
--
ALTER TABLE `data_keluarga`
  MODIFY `idKeluarga` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_kemampuanbahasa`
--
ALTER TABLE `data_kemampuanbahasa`
  MODIFY `idBahasa` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_lamaran`
--
ALTER TABLE `data_lamaran`
  MODIFY `idLamaran` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_organisasi`
--
ALTER TABLE `data_organisasi`
  MODIFY `idOrganisasi` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_pasangan`
--
ALTER TABLE `data_pasangan`
  MODIFY `idPasangan` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_pekerjaan`
--
ALTER TABLE `data_pekerjaan`
  MODIFY `idPekerjaan` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_pendidikanformal`
--
ALTER TABLE `data_pendidikanformal`
  MODIFY `idFormal` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_pendidikannonformal`
--
ALTER TABLE `data_pendidikannonformal`
  MODIFY `idNonformal` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_pengalamanmemimpin`
--
ALTER TABLE `data_pengalamanmemimpin`
  MODIFY `idPengalaman` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_pertanyaan`
--
ALTER TABLE `data_pertanyaan`
  MODIFY `idPertanyaan` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_referensi`
--
ALTER TABLE `data_referensi`
  MODIFY `idReferensi` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_saudara`
--
ALTER TABLE `data_saudara`
  MODIFY `idSaudara` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `data_slide`
--
ALTER TABLE `data_slide`
  MODIFY `id_slide` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dokumen_cv`
--
ALTER TABLE `dokumen_cv`
  MODIFY `idCV` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dokumen_foto`
--
ALTER TABLE `dokumen_foto`
  MODIFY `idFoto` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dokumen_ijazah`
--
ALTER TABLE `dokumen_ijazah`
  MODIFY `idIjazah` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dokumen_kk`
--
ALTER TABLE `dokumen_kk`
  MODIFY `idKK` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dokumen_ktp`
--
ALTER TABLE `dokumen_ktp`
  MODIFY `idKtp` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dokumen_nilai`
--
ALTER TABLE `dokumen_nilai`
  MODIFY `idNilai` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dokumen_npwp`
--
ALTER TABLE `dokumen_npwp`
  MODIFY `idNPWP` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dokumen_surat`
--
ALTER TABLE `dokumen_surat`
  MODIFY `idSurat` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `event`
--
ALTER TABLE `event`
  MODIFY `id_event` int(3) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `jenis_mobil`
--
ALTER TABLE `jenis_mobil`
  MODIFY `kd_jenis` int(3) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `kode_mobil`
--
ALTER TABLE `kode_mobil`
  MODIFY `id_kode` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `lamaran`
--
ALTER TABLE `lamaran`
  MODIFY `id_lamaran` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `leasing`
--
ALTER TABLE `leasing`
  MODIFY `id_leasing` int(4) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `lowongan`
--
ALTER TABLE `lowongan`
  MODIFY `id_lowongan` int(3) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `temp_akun`
--
ALTER TABLE `temp_akun`
  MODIFY `id_akun` int(4) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `testdrive`
--
ALTER TABLE `testdrive`
  MODIFY `id_testdrive` int(5) NOT NULL AUTO_INCREMENT;
SET FOREIGN_KEY_CHECKS=1;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
