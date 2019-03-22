<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageUser_HomePelamar.aspx.cs" Inherits="PageUser_PageUser_HomePelamar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
.footer {
   position: fixed;
   left: 0;
   bottom: 0;
   width: 100%;
   background-color: grey;
   color: white;
   text-align: center;
   height:50px;
   max-height:50px;
}
h2.FormDataDiri {
  text-align: center;
}
</style>
    <!-- Bootstrap -->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom:100px">
            <div style="margin-left:1%">
                <h2 class="FormDataDiri">Selamat Datang di Menu Pelamar</h2>
                <br />
                <br />
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Selamat Datang : "></asp:Label><br />
                    <asp:Label ID="LblNamaPelamar" runat="server" Text="NAMAUSER" Font-Bold="true"></asp:Label>
                    <br /><br />
                    <asp:Label ID="Label5" runat="server" Text="Posisi diLamar : "></asp:Label><br />
                    <asp:Label ID="LblPosisi" runat="server" Text="Posisi" Font-Bold="true"></asp:Label>
                    <br /><br />
                    <asp:Label ID="Label7" runat="server" Text="Nomor Lamaran : "></asp:Label><br />
                    <b>DFT</b><asp:Label ID="LblIdLamaran" runat="server" Text="NOMOR" Font-Bold="true"></asp:Label>
                </div>
                <div class="form-group" style="padding-right:20px">
                <table class="table table-bordered" >
                  <thead>
                    <tr>
                      <th scope="col"><center>No</center></th>
                      <th scope="col"><center>Dokumen</center></th>
                      <th scope="col"><center>Keterangan</center></th>
                      <th scope="col"><center>Aksi</center></th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <th scope="row">1</th>
                      <td style="width: 300px">Data Diri</td>
                      <td>Wajib Di Isi</td>
                      <td style="width: 300px"><asp:Button ID="Button1" runat="server" Text="Isi Data" class="btn btn-info" OnClick="Button1_Click"/><asp:Label ID="LblBtnDataDiri" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                      <th scope="row">2</th>
                      <td style="width: 300px">Data Keluarga</td>
                      <td>Wajib Di Isi</td>
                      <td><asp:Button ID="BtnDataKeluarga" runat="server" Text="Isi Data" class="btn btn-info" OnClick="BtnDataKeluarga_Click" /><asp:Label ID="LblBtnDataKel" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                      <th scope="row">3</th>
                      <%--<td colspan="2">Larry the Bird</td>--%>
                        <td style="width: 300px">
                            Riwayat Pendidikan</td>
                        <td>Wajib Di Isi</td>
                      <td><asp:Button ID="BtnRiwayatPendidikan" runat="server" Text="Isi Data" class="btn btn-info" OnClick="BtnRiwayatPendidikan_Click"  /><asp:Label ID="LblBtnRP" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                      <th scope="row">4</th>
                      <%--<td colspan="2">Larry the Bird</td>--%>
                        <td>
                            Pengalaman Organisasi & Memimpin</td>
                        <td style="color:green;font-weight:bold">Tidak Wajib</td>
                      <td><asp:Button ID="BtnPengalaman" runat="server" Text="Isi Data" class="btn btn-info" OnClick="BtnPengalaman_Click" /><asp:Label ID="LblBtnPengalaman" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                      <th scope="row">5</th>
                      <%--<td colspan="2">Larry the Bird</td>--%>
                        <td>
                            Riwayat Pekerjaan & Referensi</td>
                        <td>Wajib Di Isi</td>
                       <td><asp:Button ID="BtnPkjRef" runat="server" Text="Isi Data" class="btn btn-info" OnClick="BtnPkjRef_Click"  /><asp:Label ID="LblBtnPkjRef" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                      <th scope="row">6</th>
                      <%--<td colspan="2">Larry the Bird</td>--%>
                        <td>
                            Pertanyaan</td>
                        <td>Wajib Di Isi</td>
                      <td ><asp:Button ID="BtnPertanyaan" runat="server" Text="Isi Data" class="btn btn-info" OnClick="BtnPertanyaan_Click"  /><asp:Label ID="LblBtnPertanyaan" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                      <th scope="row">7</th>
                      <%--<td colspan="2">Larry the Bird</td>--%>
                        <td>
                            Unggah Foto</td>
                        <td>Wajib Di Isi</td>
                      <td ><asp:Button ID="BtnFoto" runat="server" Text="Isi Data" class="btn btn-info" OnClick="BtnFoto_Click"   /><asp:Label ID="LblBtnFoto" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                      <th scope="row">8</th>
                      <%--<td colspan="2">Larry the Bird</td>--%>
                        <td>
                            Unggah KTP</td>
                        <td>Wajib Di Isi</td>
                      <td ><asp:Button ID="BtnKtp" runat="server" Text="Isi Data" class="btn btn-info" OnClick="BtnKtp_Click"   /><asp:Label ID="LblBtnKtp" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                      <th scope="row">9</th>
                      <%--<td colspan="2">Larry the Bird</td>--%>
                        <td>
                            Unggah NPWP</td>
                        <td style="color:green;font-weight:bold">Tidak Wajib</td>
                      <td ><asp:Button ID="BtnNpwp" runat="server" Text="Isi Data" class="btn btn-info" OnClick="BtnNpwp_Click"   /><asp:Label ID="LblBtnNpwp" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                      <th scope="row">10</th>
                      <%--<td colspan="2">Larry the Bird</td>--%>
                        <td>
                            Unggah Kartu Keluarga</td>
                        <td>Wajib Di Isi</td>
                      <td ><asp:Button ID="BtnKK" runat="server" Text="Isi Data" class="btn btn-info" OnClick="BtnKK_Click"   /><asp:Label ID="LblBtnKK" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                      <th scope="row">11</th>
                      <%--<td colspan="2">Larry the Bird</td>--%>
                        <td>
                            Unggah Ijazah</td>
                        <td>Wajib Di Isi</td>
                      <td ><asp:Button ID="BtnIjz" runat="server" Text="Isi Data" class="btn btn-info" OnClick="BtnIjz_Click"   /><asp:Label ID="LblBtnIjz" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                      <th scope="row">12</th>
                      <%--<td colspan="2">Larry the Bird</td>--%>
                        <td>
                            Unggah Transkrip Nilai</td>
                        <td>Wajib Di Isi</td>
                      <td ><asp:Button ID="BtnNilai" runat="server" Text="Isi Data" class="btn btn-info" OnClick="BtnNilai_Click"   /><asp:Label ID="LblBtnNilai" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                      <th scope="row">13</th>
                      <%--<td colspan="2">Larry the Bird</td>--%>
                        <td>
                            Unggah Surat Lamaran</td>
                        <td>Wajib Di Isi</td>
                      <td ><asp:Button ID="BtnLamar" runat="server" Text="Isi Data" class="btn btn-info" OnClick="BtnLamar_Click"   /><asp:Label ID="LblBtnLamar" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                      <th scope="row">14</th>
                      <%--<td colspan="2">Larry the Bird</td>--%>
                        <td>
                            Unggah CV</td>
                        <td>Wajib Di Isi</td>
                      <td ><asp:Button ID="BtnCV" runat="server" Text="Isi Data" class="btn btn-info" OnClick="BtnCV_Click"   /><asp:Label ID="LblBtnCV" runat="server" Text="Data Sudah Ada" Font-Bold="true" Visible="false"></asp:Label></td>
                    </tr>
                  </tbody>
                </table>                    
                </div>
                <div class="form-group">
                    <div style="  float: left;
                                  width: 500px;
                                  height: 100px;
                                  margin: 1em;"
                        >
                    <asp:Button ID="BtnLogout" runat="server" Text="Logout"  class="btn btn-danger" OnClick="BtnLogout_Click"/>
                    <asp:Button ID="BtnKirimLamaran" runat="server" Text="Kirim Lamaran Anda"  class="btn btn-success" OnClick="BtnKirimLamaran_Click" />
                    </div>
                </div>
                <div class="form-group">
                    <br />
                </div>
            </div>   
        </div>
        <div class="footer">
            <div style="margin-top:1px">
                <asp:Label ID="Label1" runat="server" Text="Developed by IT Departement 2019 &#169;"></asp:Label>            
            </div>
            <div style="margin-top:1px">
                 <asp:Label ID="Label2" runat="server" Text="PT.Mitra Usaha Gentaniaga"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
