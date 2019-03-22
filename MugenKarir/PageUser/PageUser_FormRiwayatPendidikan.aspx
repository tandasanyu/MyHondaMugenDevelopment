<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageUser_FormRiwayatPendidikan.aspx.cs" Inherits="PageUser_PageUser_FormRiwayatPendidikan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form Riwayat Pendidikan</title>
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
    <!-- DATEPICKER RANGE -->
    <script src="../js/jquery-1.12.4.js"></script>
    <!-- Bootstrap -->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#SMP").hide();
            $("#SMA").hide();
            $("#Sarjana1").hide();
            $("#Sarjana2").hide(); 
            //hide pendidikan non formal 
            $("#JenjangPendidikanNon1").hide();
            $("#JenjangPendidikanNon2").hide();
            $("#JenjangPendidikanNon3").hide();
            $('#RadioButtonListPendidikanFormal input').click(function () {
                var value = $("#RadioButtonListPendidikanFormal input:radio:checked").val();
                if (value == "SMP") {
                    $("#SMP").show();
                    $("#SMA").hide();
                    $("#Sarjana1").hide();
                    $("#Sarjana2").hide();
                }
                else if (value == "SMA") {
                    $("#SMP").show();
                    $("#SMA").show();
                    $("#Sarjana1").hide();
                    $("#Sarjana2").hide();
                }
                else if (value == "S1") {
                    $("#SMP").show();
                    $("#SMA").show();
                    $("#Sarjana1").show();
                    $("#Sarjana2").hide();
                }
                else if (value == "S2") {
                    $("#SMP").show();
                    $("#SMA").show();
                    $("#Sarjana1").show();
                    $("#Sarjana2").show();
                }
            });
            //Pendidikan Non Formal
            $('#RadioButtonListPendidikanNon input').click(function () {
                var value = $("#RadioButtonListPendidikanNon input:radio:checked").val();
                if (value == "Tidak Ada") {
                    $("#JenjangPendidikanNon1").hide();
                    $("#JenjangPendidikanNon2").hide();
                    $("#JenjangPendidikanNon3").hide();
                }
                else if (value == "1") {
                    $("#JenjangPendidikanNon1").show();
                    $("#JenjangPendidikanNon2").hide();
                    $("#JenjangPendidikanNon3").hide();
                }
                else if (value == "2") {
                    $("#JenjangPendidikanNon1").show();
                    $("#JenjangPendidikanNon2").show();
                    $("#JenjangPendidikanNon3").hide();
                }
                else if (value == "3") {
                    $("#JenjangPendidikanNon1").show();
                    $("#JenjangPendidikanNon2").show();
                    $("#JenjangPendidikanNon3").show();
                }
            });
            //Bahasa Asing  PenguasaanBahasAsing  BahasaAsing1
            $("#BahasaAsing1").hide();
            $("#BahasaAsing2").hide();
            $("#BahasaAsing3").hide();
            $('#PenguasaanBahasAsing input').click(function () {
                var value = $("#PenguasaanBahasAsing input:radio:checked").val();
                if (value == "Tidak Ada") {
                    $("#BahasaAsing1").hide();
                    $("#BahasaAsing2").hide();
                    $("#BahasaAsing3").hide();
                }
                else if (value == "1") {
                    $("#BahasaAsing1").show();
                    $("#BahasaAsing2").hide();
                    $("#BahasaAsing3").hide();
                }
                else if (value == "2") {
                    $("#BahasaAsing1").show();
                    $("#BahasaAsing2").show();
                    $("#BahasaAsing3").hide();
                }
                else if (value == "3") {
                    $("#BahasaAsing1").show();
                    $("#BahasaAsing2").show();
                    $("#BahasaAsing3").show();
                }
            });
        });        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom:100px">
            <div style="margin-left:1%">
                <h2 class="FormDataDiri">Form Riwayat Pendidikan</h2>
                <br />
                <br />
                <div class="row">
                    <div class="col-lg-8">
                        <!-- Jenjang Pendidikan Formal -->
                        <div class="form-group" id="JenjangPendidikan">
                          <asp:Label ID="Label4" runat="server" Text="Pilih  Pendidikan Formal Terakhir Anda :" Font-Bold="true"></asp:Label>
                          <asp:RadioButtonList ID="RadioButtonListPendidikanFormal" RepeatDirection="Horizontal" runat="server" CellPadding="5">
                              <asp:ListItem>SMP</asp:ListItem>
                              <asp:ListItem>SMA</asp:ListItem>
                              <asp:ListItem>S1</asp:ListItem>
                              <asp:ListItem>S2</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                runat="server" 
                                ForeColor="red"
                                ErrorMessage="Jenjang Pendidikan Wajib Di Pilih"
                                ControlToValidate="RadioButtonListPendidikanFormal"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group" id="SMP">
                        <asp:Label ID="Label3" runat="server" Text="Jenjang SMP :" Font-Bold="true"></asp:Label>
                        <table class="table table-bordered">
                            <thead>
                              <tr>
                                <th>Jenjang</th>
                                <th>Nama Instansi</th>
                                <th>Kota</th>
                                <th>Tahun Masuk</th>
                                <th>Tahun Keluar</th>
                                <th>Status Kelulusan</th>
                                <th>Jurusan</th>
                              </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TxtJenjangPendidikanSMP" class="form-control" runat="server" Text="SMP" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtNamaInstansiSMP" class="form-control" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="TxtKotaSMP" class="form-control" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="TxtTahunMasukSMP" class="form-control" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="TxtTahunKeluarSMP" class="form-control" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListStatusKelulusanSMP" class="form-control" runat="server">
                                            <asp:ListItem Value="1">Lulus</asp:ListItem>
                                            <asp:ListItem Value="2">Tidak Lulus</asp:ListItem>
                                        </asp:DropDownList>                                        
                                    </td>
                                    <td><asp:TextBox ID="TxtJurusanSMP" class="form-control" runat="server" Text="--" ReadOnly="true"></asp:TextBox></td>
                                </tr>
                            </tbody>
                        </table>
                        </div>
                        <div class="form-group" id="SMA">
                        <asp:Label ID="Label5" runat="server" Text="Jenjang SMA :" Font-Bold="true"></asp:Label>
                        <table class="table table-bordered">
                            <thead>
                              <tr>
                                <th>Jenjang</th>
                                <th>Nama Instansi</th>
                                <th>Kota</th>
                                <th>Tahun Masuk</th>
                                <th>Tahun Keluar</th>
                                <th>Status Kelulusan</th>
                                <th>Jurusan</th>
                              </tr>                              
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TxtJenjangPendidikanSMA" class="form-control" runat="server" Text="SMA" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtNamaInstansiSMA" class="form-control" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="TxtKotaSMA" class="form-control" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="TxtTahunMasukSMA" class="form-control" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="TxtTahunKeluarSMA" class="form-control" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListStatusKelulusanSMA" class="form-control" runat="server">
                                            <asp:ListItem Value="1">Lulus</asp:ListItem>
                                            <asp:ListItem Value="2">Tidak Lulus</asp:ListItem>
                                        </asp:DropDownList>                                        
                                    </td>
                                    <td><asp:TextBox ID="TxtJurusanSMA" class="form-control" runat="server"></asp:TextBox></td>
                                </tr>
                            </tbody>
                        </table>
                        </div>
                        <div class="form-group" id="Sarjana1">
                        <asp:Label ID="Label6" runat="server" Text="Jenjang Sarjana :" Font-Bold="true"></asp:Label>
                        <table class="table table-bordered">
                            <thead>
                              <tr>
                                <th>Jenjang</th>
                                <th>Nama Instansi</th>
                                <th>Kota</th>
                                <th>Tahun Masuk</th>
                                <th>Tahun Keluar</th>
                                <th>Status Kelulusan</th>
                                <th>Jurusan</th>
                              </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TxtJenjangPendidikanSarjana" class="form-control" runat="server" Text="Sarjana" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtNamaInstansiSarjana" class="form-control" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="TxtKotaSarjana" class="form-control" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="TxtTahunMasukSarjana" class="form-control" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="TxtTahunKeluarSarjana" class="form-control" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListStatusKelulusanSarjana" class="form-control" runat="server">
                                            <asp:ListItem Value="1">Lulus</asp:ListItem>
                                            <asp:ListItem Value="2">Tidak Lulus</asp:ListItem>
                                        </asp:DropDownList>                                        
                                    </td>
                                    <td><asp:TextBox ID="TxtJurusanSarjana" class="form-control" runat="server"></asp:TextBox></td>
                                </tr>
                            </tbody>
                        </table>
                        </div>
                        <div class="form-group" id="Sarjana2">
                        <asp:Label ID="Label7" runat="server" Text="Jenjang Magister  :" Font-Bold="true"></asp:Label>
                        <table class="table table-bordered">
                            <thead>
                              <tr>
                                <th>Jenjang</th>
                                <th>Nama Instansi</th>
                                <th>Kota</th>
                                <th>Tahun Masuk</th>
                                <th>Tahun Keluar</th>
                                <th>Status Kelulusan</th>
                                <th>Jurusan</th>
                              </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TxtJenjangPendidikanSarjana2" class="form-control" runat="server" Text="Magister" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtNamaInstansiSarjana2" class="form-control" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="TxtKotaSarjana2" class="form-control" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="TxtTahunMasukSarjana2" class="form-control" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="TxtTahunKeluarSarjana2" class="form-control" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListStatusKelulusanSarjana2" class="form-control" runat="server">
                                            <asp:ListItem Value="1">Lulus</asp:ListItem>
                                            <asp:ListItem Value="2">Tidak Lulus</asp:ListItem>
                                        </asp:DropDownList>                                        
                                    </td>
                                    <td><asp:TextBox ID="TxtJurusanSarjana2" class="form-control" runat="server"></asp:TextBox></td>
                                </tr>
                            </tbody>
                        </table>
                        </div>
                        <!-- Jenjang Pendidikan Non Formal -->
                        <div class="form-group" id="JenjangPendidikanNon">
                          <asp:Label ID="Label8" runat="server" Text="Pilih Jumlah Pendidikan Non Formal Anda :" Font-Bold="true"></asp:Label>
                          <asp:RadioButtonList ID="RadioButtonListPendidikanNon" RepeatDirection="Horizontal" runat="server" CellPadding="5">
                              <asp:ListItem>Tidak Ada</asp:ListItem>
                              <asp:ListItem>1</asp:ListItem>
                              <asp:ListItem>2</asp:ListItem>
                              <asp:ListItem>3</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                runat="server" 
                                ForeColor="red"
                                ErrorMessage="Jenjang Pendidikan Non Formal Wajib Di Pilih"
                                ControlToValidate="RadioButtonListPendidikanNon"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group" id="JenjangPendidikanNon1">
                          <asp:Label ID="Label9" runat="server" Text="Pendidikan Non Formal 1 :" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>                                   
                                    <th>Nama Instansi</th>                                   
                                    <th>Tahun Masuk</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td><asp:TextBox ID="TxtNamaInstansiNon1" class="form-control" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TxtTahunInstansiNon1" class="form-control" runat="server"></asp:TextBox></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="JenjangPendidikanNon2">
                          <asp:Label ID="Label10" runat="server" Text="Pendidikan Non Formal 2 :" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>                                   
                                    <th>Nama Instansi</th>                                   
                                    <th>Tahun Masuk</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td><asp:TextBox ID="TxtNamaInstansiNon2" class="form-control" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TxtTahunInstansiNon2" class="form-control" runat="server"></asp:TextBox></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="JenjangPendidikanNon3">
                          <asp:Label ID="Label11" runat="server" Text="Pendidikan Non Formal 3 :" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>                                   
                                    <th>Nama Instansi</th>                                   
                                    <th>Tahun Masuk</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td><asp:TextBox ID="TxtNamaInstansiNon3" class="form-control" runat="server"></asp:TextBox></td>
                                        <td><asp:TextBox ID="TxtTahunInstansiNon3" class="form-control" runat="server"></asp:TextBox></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- Penguasaan Bahasa Asing -->
                        <div class="form-group" id="PenguasaanBahasAsing">
                          <asp:Label ID="Label12" runat="server" Text="Pilih Jumlah Penguasaan Bahasa Asing Anda :" Font-Bold="true"></asp:Label>
                          <asp:RadioButtonList ID="RadioButtonListBahasa" RepeatDirection="Horizontal" runat="server" CellPadding="5">
                              <asp:ListItem>Tidak Ada</asp:ListItem>
                              <asp:ListItem>1</asp:ListItem>
                              <asp:ListItem>2</asp:ListItem>
                              <asp:ListItem>3</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                runat="server" 
                                ForeColor="red"
                                ErrorMessage="Penguasaan Bahasa Asing Wajib Di Pilih"
                                ControlToValidate="RadioButtonListBahasa"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group" id="BahasaAsing1">
                          <asp:Label ID="Label13" runat="server" Text="Bahasa Asing yang di Kuasai :" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>                                   
                                    <th>Jenis Bahasa</th>                                   
                                    <th>Tingkat Penguasaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td><asp:TextBox ID="TxtJenisBahasa1" class="form-control" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPenguasaanBahasa1" class="form-control" runat="server">
                                            <asp:ListItem Value="1">Baik</asp:ListItem>
                                            <asp:ListItem Value="2">Cukup</asp:ListItem>
                                            <asp:ListItem Value="3">Kurang</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="BahasaAsing2">
                          <asp:Label ID="Label14" runat="server" Text="Bahasa Asing yang di Kuasai :" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>                                   
                                    <th>Jenis Bahasa</th>                                   
                                    <th>Tingkat Penguasaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td><asp:TextBox ID="TxtJenisBahasa2" class="form-control" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPenguasaanBahasa2" class="form-control" runat="server">
                                            <asp:ListItem Value="1">Baik</asp:ListItem>
                                            <asp:ListItem Value="2">Cukup</asp:ListItem>
                                            <asp:ListItem Value="3">Kurang</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="BahasaAsing3">
                          <asp:Label ID="Label15" runat="server" Text="Bahasa Asing yang di Kuasai :" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>                                   
                                    <th>Jenis Bahasa</th>                                   
                                    <th>Tingkat Penguasaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td><asp:TextBox ID="TxtJenisBahasa3" class="form-control" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPenguasaanBahasa3" class="form-control" runat="server">
                                            <asp:ListItem Value="1">Baik</asp:ListItem>
                                            <asp:ListItem Value="2">Cukup</asp:ListItem>
                                            <asp:ListItem Value="3">Kurang</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <div class="form-group"><!-- Button -->
                          <div class="col-sm-8">
                              <asp:Button ID="BtnSubmitRiwayatPendidikan" runat="server" Text="Simpan Data" class="btn btn-danger" OnClick="BtnSubmitRiwayatPendidikan_Click"  />
                          </div>                        
                        </div>
                    </div>
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
