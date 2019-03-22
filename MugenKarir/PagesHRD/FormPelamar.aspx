<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPelamar.aspx.cs" Inherits="PagesHRD_FormPelamar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form Pelamar</title>
            <!-- Bootstrap -->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div id="Header" class="form-group" style="margin-top:5%; margin-bottom:6%">
            <div class="row">
                <div class="col-sm">
                    <asp:Image ID="ImageIcon" runat="server" src="../img/cropped-honda-icon.png" Height="200px" Width="200px" />
                </div>
                <div class="col-sm" style="text-align:center">
                    <h3><asp:Label ID="JudulForm" runat="server" Text="PT. MITRAUSAHA GENTANIAGA</br>(HONDA MUGEN)"></asp:Label></h3>
                </div>
                <div class="col-sm">
                    <asp:Image ID="ImagePelamar" runat="server"  Height="200px" Width="200px" />
                </div>
            </div>
        </div>
        <div id="DataPribadi" class="form-group">
            <h4><asp:Label ID="LblDataPribadi" runat="server" Text="Data Pribadi"></asp:Label></h4>
                        <div class="row">
                            <div class="col-4">Nama : </div>
                            <div class="col-8"><asp:Label ID="DPNama" runat="server" Text="Nama"></asp:Label></div>
                        </div>
                        <div class="row">
                            <div class="col-4">Tempat/Tanggal Lahir : </div>
                            <div class="col-8"><asp:Label ID="DPTTL" runat="server" Text="Nama"></asp:Label></div>
                        </div>
                        <div class="row">
                            <div class="col-4">Jenis Kelamin : </div>
                            <div class="col-8"><asp:Label ID="DPJenkel" runat="server" Text="Nama"></asp:Label></div>
                        </div>
                        <div class="row">
                            <div class="col-4">Agama : </div>
                            <div class="col-8"><asp:Label ID="DPAgama" runat="server" Text="Nama"></asp:Label></div>
                        </div>
                        <div class="row">
                            <div class="col-4">NPWP : </div>
                            <div class="col-8"><asp:Label ID="DPNPWP" runat="server" Text="Nama"></asp:Label></div>
                        </div>
                        <div class="row">
                            <div class="col-4">Jamsostek : </div>
                            <div class="col-8"><asp:Label ID="DPJamsos" runat="server" Text="Nama"></asp:Label></div>
                        </div>
                        <div class="row">
                            <div class="col-4">Alamat Tinggal : </div>
                            <div class="col-8"><asp:Label ID="DPAlm" runat="server" Text="Nama"></asp:Label></div>
                        </div>
                        <div class="row">
                            <div class="col-4">Alamat Sesuai KTP : </div>
                            <div class="col-8"><asp:Label ID="DPKTPAla" runat="server" Text="Nama"></asp:Label></div>
                        </div>
                        <div class="row">
                            <div class="col-4">Telpon Rumah : </div>
                            <div class="col-8"><asp:Label ID="DPTelpon" runat="server" Text="Nama"></asp:Label></div>
                        </div>
                        <div class="row">
                            <div class="col-4">Panggilan : </div>
                            <div class="col-8"><asp:Label ID="DPPanggil" runat="server" Text="Nama"></asp:Label></div>
                        </div>
                        <div class="row">
                            <div class="col-4">Usia : </div>
                            <div class="col-8"><asp:Label ID="DPUsia" runat="server" Text="Nama"></asp:Label></div>
                        </div>
                        <div class="row">
                            <div class="col-4">No. KTP : </div>
                            <div class="col-8"><asp:Label ID="DPKTP" runat="server" Text="Nama"></asp:Label></div>
                        </div>
                        <div class="row">
                            <div class="col-4">No.SIM : </div>
                            <div class="col-8"><asp:Label ID="DPNoSIM" runat="server" Text="Nama"></asp:Label><br />
                                <asp:Label ID="DPJenSim" runat="server" Text="Nama"></asp:Label>
                            </div>
                        </div>
            <div class="row">
                <div class="col-4">No. Rek. BCA : </div>
                <div class="col-8"><asp:Label ID="DPRek" runat="server" Text="Nama"></asp:Label></div>
            </div>
            <div class="row">
                <div class="col-4">Handphone : </div>
                <div class="col-8"><asp:Label ID="DPHp" runat="server" Text="Nama"></asp:Label></div>
            </div>
        </div>
        <div id="LatarBelakangKeluarga" class="form-group">
            <h4><asp:Label ID="LblLatarBelakangKeluarga" runat="server" Text="Latar Belakang Keluarga"></asp:Label></h4>
        </div>
        <div id="StatusPerkawinan" class="form-group">
            <h4><asp:Label ID="LblStatusPerkawinan" runat="server" Text="Status Perkawinan"></asp:Label></h4>
        </div>
        <div id="PendidikanFormal" class="form-group">
            <h4><asp:Label ID="LblPenFor" runat="server" Text="Pendidikan Formal"></asp:Label></h4>
        </div>
        <div id="PendidikanNon" class="form-group">
            <h4><asp:Label ID="LblPenNon" runat="server" Text="Pendidikan NonFormal"></asp:Label></h4>
        </div>
        <div id="BahasaAsing" class="form-group">
            <h4><asp:Label ID="LblBahasaA" runat="server" Text="Bahasa Asing"></asp:Label></h4>
        </div>
        <div id="PengalamanOrg" class="form-group">
            <h4><asp:Label ID="LblOrg" runat="server" Text="Pengalaman Organisasi"></asp:Label></h4>
        </div>
        <div id="RiwayatPekerjaan" class="form-group">
            <h4><asp:Label ID="LblRiwPek" runat="server" Text="Riwayat Pekerjaan"></asp:Label></h4>
        </div>
        <div id="Referensi" class="form-group">
            <h4><asp:Label ID="LblReferensi" runat="server" Text="Referensi"></asp:Label></h4>
        </div>
        <div id="Pertanyaan" class="form-group">
            <h4><asp:Label ID="LblPertanyaan" runat="server" Text="Pertanyaan"></asp:Label></h4>
        </div>
    </div>
    </form>
</body>
</html>
