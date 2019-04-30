<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaguUser_FormDataKeluarga.aspx.cs" Inherits="PageUser_PaguUser_FormDataKeluarga" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form Data Keluarga</title>
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
            //untuk Kepemilikan Saudara***************
            $("#DivJmlAnak").hide();          
            $('#RadioButtonListPunyaAnak input').click(function () {
                var value = $("#RadioButtonListPunyaAnak input:radio:checked").val();              
                if (value == "Tidak") {
                    $("#DivJmlAnak").hide();
                    $("#DivJmlAnak1").hide();
                    $("#DivJmlAnak2").hide();
                    $("#DivJmlAnak3").hide();
                    $("#DivJmlAnak4").hide();
                    $("#DivJmlAnak5").hide();
                    $("#DivJmlAnak6").hide();
                    $("#DivJmlAnak7").hide();
                    $("#DivJmlAnak8").hide();
                    //var radiolist = $('#RadioButtonListJmlAnak').find('input:radio');
                    //radiolist.removeAttr('checked');
                }
                else {
                    $("#DivJmlAnak").show(); 
                    
                }
            });
            //untuk Jumlah Saudara*************
            $("#DivJmlAnak1").hide();
            $("#DivJmlAnak2").hide();
            $("#DivJmlAnak3").hide();
            $("#DivJmlAnak4").hide();
            $("#DivJmlAnak5").hide();
            $("#DivJmlAnak6").hide();
            $("#DivJmlAnak7").hide();
            $("#DivJmlAnak8").hide();
            $('#RadioButtonListJmlAnak input').click(function () {
                var value = $("#RadioButtonListJmlAnak input:radio:checked").val();
                if (value == 1) {
                    $("#DivJmlAnak1").show();
                    $("#DivJmlAnak2").hide();
                    $("#DivJmlAnak3").hide();
                    $("#DivJmlAnak4").hide();
                    $("#DivJmlAnak5").hide();
                    $("#DivJmlAnak6").hide();
                    $("#DivJmlAnak7").hide();
                    $("#DivJmlAnak8").hide();
                }
                else if (value == 2) {
                    $("#DivJmlAnak1").show();
                    $("#DivJmlAnak2").show();
                    $("#DivJmlAnak3").hide();
                    $("#DivJmlAnak4").hide();
                    $("#DivJmlAnak5").hide();
                    $("#DivJmlAnak6").hide();
                    $("#DivJmlAnak7").hide();
                    $("#DivJmlAnak8").hide();
                }
                else if (value == 3) {
                    $("#DivJmlAnak1").show();
                    $("#DivJmlAnak2").show();
                    $("#DivJmlAnak3").show();
                    $("#DivJmlAnak4").hide();
                    $("#DivJmlAnak5").hide();
                    $("#DivJmlAnak6").hide();
                    $("#DivJmlAnak7").hide();
                    $("#DivJmlAnak8").hide();
                }
                else if (value == 4) {
                    $("#DivJmlAnak1").show();
                    $("#DivJmlAnak2").show();
                    $("#DivJmlAnak3").show();
                    $("#DivJmlAnak4").show();
                    $("#DivJmlAnak5").hide();
                    $("#DivJmlAnak6").hide();
                    $("#DivJmlAnak7").hide();
                    $("#DivJmlAnak8").hide();
                }
                else if (value == 5) {
                    $("#DivJmlAnak1").show();
                    $("#DivJmlAnak2").show();
                    $("#DivJmlAnak3").show();
                    $("#DivJmlAnak4").show();
                    $("#DivJmlAnak5").show();
                    $("#DivJmlAnak6").hide();
                    $("#DivJmlAnak7").hide();
                    $("#DivJmlAnak8").hide();
                }
                else if (value == 6) {
                    $("#DivJmlAnak1").show();
                    $("#DivJmlAnak2").show();
                    $("#DivJmlAnak3").show();
                    $("#DivJmlAnak4").show();
                    $("#DivJmlAnak5").show();
                    $("#DivJmlAnak6").show();
                    $("#DivJmlAnak7").hide();
                    $("#DivJmlAnak8").hide();
                }
                else if (value == 7) {
                    $("#DivJmlAnak1").show();
                    $("#DivJmlAnak2").show();
                    $("#DivJmlAnak3").show();
                    $("#DivJmlAnak4").show();
                    $("#DivJmlAnak5").show();
                    $("#DivJmlAnak6").show();
                    $("#DivJmlAnak7").show();
                    $("#DivJmlAnak8").hide();
                }
                else if (value == 8) {
                    $("#DivJmlAnak1").show();
                    $("#DivJmlAnak2").show();
                    $("#DivJmlAnak3").show();
                    $("#DivJmlAnak4").show();
                    $("#DivJmlAnak5").show();
                    $("#DivJmlAnak6").show();
                    $("#DivJmlAnak7").show();
                    $("#DivJmlAnak8").show();
                }
            });
            //untuk perkawinan******************
            //proses rbList Status Perkawinan
            $('#RadioButtonListStatusPerkawinan input').click(function () {
                var value = $("#RadioButtonListStatusPerkawinan input:radio:checked").val();
                if (value == "Belum Menikah") {
                    $("#DivDataSuamiIstri").hide();
                    $("#DivDataAnak1").hide();
                    $("#DivDataAnak2").hide();
                    $("#DivDataAnak3").hide();
                }
                else {
                    $("#DivDataSuamiIstri").show();
                }
            });
            //*hide div jml anak
            $("#DivDataAnak1").hide();
            $("#DivDataAnak2").hide();
            $("#DivDataAnak3").hide();
            //*hide div data suami istri   DivDataSuamiIstri
            $("#DivDataSuamiIstri").hide()
            //untuk jumlah anak******************
            //RadioButtonListJumlahAnakPerKawinan  *** DivDataAnak1
            $("#DivDataAnak1").hide();
            $("#DivDataAnak2").hide();
            $("#DivDataAnak3").hide();
            $('#RadioButtonListJumlahAnakPerKawinan input').click(function () {
                var value = $("#RadioButtonListJumlahAnakPerKawinan input:radio:checked").val();
                if (value == "Tidak Ada") {
                    $("#DivDataAnak1").hide();
                    $("#DivDataAnak2").hide();
                    $("#DivDataAnak3").hide();
                }
                else if (value == "1") {
                    $("#DivDataAnak1").show();
                    $("#DivDataAnak2").hide();
                    $("#DivDataAnak3").hide();
                }
                else if (value == "2") {
                    $("#DivDataAnak1").show();
                    $("#DivDataAnak2").show();
                    $("#DivDataAnak3").hide();
                }
                else if (value == "3") {
                    $("#DivDataAnak1").show();
                    $("#DivDataAnak2").show();
                    $("#DivDataAnak3").show();
                }
            });
        });        
    </script>
   <script type="text/javascript">
   
      function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

         return true;
      }
       //-->
   </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom:100px">
            <div style="margin-left:1%">
                <h2 class="FormDataDiri">Form Data Keluarga</h2>
                <br />
                <br />
                <div class="row">
                    <div class="col-lg-8">
                      <h4><small>Data Diri (Termasuk Anda)</small></h4>
                      <table class="table table-bordered">
                        <thead>
                          <tr>
                            <th></th>
                            <th>Nama</th>
                            <th>Jenis Kelamin</th>
                            <th>Usia</th>
                            <th>Pendidikan</th>
                            <th>Pekerjaan</th>
                          </tr>
                        </thead>
                        <tbody>
                          <tr>
                            <td>Ayah</td>
                            <td>
                                <asp:TextBox ID="TxtNamaAyah" class="form-control"  autocomplete="off" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                    runat="server" 
                                    ErrorMessage="Wajib Di Isi"
                                    ControlToValidate="TxtNamaAyah"
                                    ForeColor="red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator 
                                    ID="RegularExpressionValidator1" 
                                    runat="server" 
                                    ErrorMessage="Wajib di Isi dengan Karakter!"
                                    ValidationExpression="[a-zA-Z ]*$"
                                    ControlToValidate="TxtNamaAyah"
                                    ForeColor="Red"
                                    ></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Label ID="LblJenkelAyah" runat="server" Text="Pria"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtUsiaAyah" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                    runat="server" 
                                    ErrorMessage="Wajib Di Isi"
                                    ControlToValidate="TxtUsiaAyah"
                                    ForeColor="red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListPendidikanAyah" class="form-control" runat="server">
                                    <asp:ListItem Value="0">Pilih Jenis Pendidikan</asp:ListItem>
                                    <asp:ListItem Value="1">SMP</asp:ListItem>
                                    <asp:ListItem Value="2">SMA</asp:ListItem>
                                    <asp:ListItem Value="3">S1</asp:ListItem>
                                    <asp:ListItem Value="4">S2</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                                    runat="server" 
                                    ErrorMessage="Wajib Di Isi"
                                    ControlToValidate="DropDownListPendidikanAyah"
                                    InitialValue="0"
                                    ForeColor="red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListPekerjaanAyah" class="form-control" runat="server">
                                    <asp:ListItem Value="0">Pilih Jenis Pekerjaan</asp:ListItem>
                                    <asp:ListItem Value="1">PNS</asp:ListItem>
                                    <asp:ListItem Value="2">Peg.Swasta</asp:ListItem>
                                    <asp:ListItem Value="3">Wira Usaha</asp:ListItem>
                                    <asp:ListItem Value="4">Pensiun</asp:ListItem>
                                    <asp:ListItem Value="5">Tidak Bekerja</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                                    runat="server" 
                                    ErrorMessage="Wajib Di Isi"
                                    ControlToValidate="DropDownListPekerjaanAyah"
                                    InitialValue="0"
                                    ForeColor="red"></asp:RequiredFieldValidator>
                            </td>
                          </tr>
                          <tr>
                            <td>Ibu</td>
                            <td>
                                <asp:TextBox ID="TxtNamaIbu" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                                    runat="server" 
                                    ErrorMessage="Wajib Di Isi"
                                    ControlToValidate="TxtNamaIbu"
                                    ForeColor="red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator 
                                    ID="RegularExpressionValidator2" 
                                    runat="server" 
                                    ErrorMessage="Wajib di Isi dengan Karakter!"
                                    ValidationExpression="[a-zA-Z ]*$"
                                    ControlToValidate="TxtNamaIbu"
                                    ForeColor="Red"
                                    ></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Label ID="LblJenkelIbu" runat="server" Text="Wanita"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtUsiaIbu" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                                    runat="server" 
                                    ErrorMessage="Wajib Di Isi"
                                    ControlToValidate="TxtUsiaIbu"
                                    ForeColor="red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListPendidikanIbu" class="form-control" runat="server">
                                    <asp:ListItem Value="0">Pilih Jenis Pendidikan</asp:ListItem>
                                    <asp:ListItem Value="1">SMP</asp:ListItem>
                                    <asp:ListItem Value="2">SMA</asp:ListItem>
                                    <asp:ListItem Value="3">S1</asp:ListItem>
                                    <asp:ListItem Value="4">S2</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" 
                                    runat="server" 
                                    ErrorMessage="Wajib Di Isi"
                                    ControlToValidate="DropDownListPendidikanIbu"
                                    InitialValue="0"
                                    ForeColor="red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListPekerjaanIbu" class="form-control" runat="server">
                                    <asp:ListItem Value="0">Pilih Jenis Pekerjaan</asp:ListItem>
                                    <asp:ListItem Value="1">PNS</asp:ListItem>
                                    <asp:ListItem Value="2">Peg.Swasta</asp:ListItem>
                                    <asp:ListItem Value="3">Wira Usaha</asp:ListItem>
                                    <asp:ListItem Value="4">Pensiun</asp:ListItem>
                                    <asp:ListItem Value="5">Tidak Bekerja</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" 
                                    runat="server" 
                                    ErrorMessage="Wajib Di Isi"
                                    ControlToValidate="DropDownListPekerjaanIbu"
                                    InitialValue="0"
                                    ForeColor="red"></asp:RequiredFieldValidator>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                      <div class="form-group"><!-- RBList -->
                      <asp:Label ID="Label3" runat="server" Text="Apakah Anda Memiliki Saudara Kandung :" Font-Bold="true"></asp:Label>
                      <asp:RadioButtonList ID="RadioButtonListPunyaAnak" runat="server">
                          <asp:ListItem>Ya</asp:ListItem>
                          <asp:ListItem>Tidak</asp:ListItem>
                        </asp:RadioButtonList>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                                  runat="server" 
                                  ErrorMessage="Saudara Kandung Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="RadioButtonListPunyaAnak"
                                  ></asp:RequiredFieldValidator>
                          
                        </div>
                      <div class="form-group" id="DivJmlAnak"><!-- Jumlah Anak -->
                      <asp:Label ID="Label4" runat="server" Text="Berapa Jumlah Saudara Kandung Anda :" Font-Bold="true"></asp:Label>
                      <asp:RadioButtonList ID="RadioButtonListJmlAnak" RepeatDirection="Horizontal" runat="server" CellPadding="5">
                          <asp:ListItem>1</asp:ListItem>
                          <asp:ListItem>2</asp:ListItem>
                          <asp:ListItem>3</asp:ListItem>
                          <asp:ListItem>4</asp:ListItem>
                          <asp:ListItem>5</asp:ListItem>
                          <asp:ListItem>6</asp:ListItem>
                          <asp:ListItem>7</asp:ListItem>
                          <asp:ListItem>8</asp:ListItem>
                        </asp:RadioButtonList>
                        </div>
                        <div class="form-group" id="DivJmlAnak1"><!-- Jumlah Anak 1-->
                            <asp:Label ID="Label5" runat="server" Text="Saudara Ke-1" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <th></th>
                                    <th>Nama</th>
                                    <th>Jenis Kelamin</th>
                                    <th>Usia</th>
                                    <th>Pendidikan</th>
                                    <th>Pekerjaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Saudara Kandung Ke-1</td>
                                        <td>
                                            <asp:TextBox ID="TxtNamaSK1" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator3" 
                                            runat="server" 
                                            ErrorMessage="Nama Hanya boleh Huruf" 
                                            ForeColor="Red"
                                            ControlToValidate="TxtNamaSK1"
                                            ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                            ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListJenisKelaminSK1" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Kelamin</asp:ListItem>
                                                <asp:ListItem Value="1">Pria</asp:ListItem>
                                                <asp:ListItem Value="2">Wanita</asp:ListItem>
                                            </asp:DropDownList>                                            
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtUsiaSK1" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                              <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                                                   runat="server" 
                                                  ErrorMessage="Wajib Angka"
                                                  ControlToValidate="TxtUsiaSK1"
                                                  ForeColor="Red"
                                                  ValidationExpression="\d+"
                                                  ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPendidikanSK1" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pendidikan</asp:ListItem>
                                                <asp:ListItem Value="1">SMP</asp:ListItem>
                                                <asp:ListItem Value="2">SMA</asp:ListItem>
                                                <asp:ListItem Value="3">S1</asp:ListItem>
                                                <asp:ListItem Value="4">S2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPekerjaanSK1" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pekerjaan</asp:ListItem>
                                                <asp:ListItem Value="1">PNS</asp:ListItem>
                                                <asp:ListItem Value="2">Peg.Swasta</asp:ListItem>
                                                <asp:ListItem Value="3">Wira Usaha</asp:ListItem>
                                                <asp:ListItem Value="4">Pensiun</asp:ListItem>
                                                <asp:ListItem Value="5">Tidak Bekerja</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="DivJmlAnak2"><!-- Jumlah Anak 2-->
                            <asp:Label ID="Label6" runat="server" Text="Saudara Ke-2" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <th></th>
                                    <th>Nama</th>
                                    <th>Jenis Kelamin</th>
                                    <th>Usia</th>
                                    <th>Pendidikan</th>
                                    <th>Pekerjaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Saudara Kandung Ke-2</td>
                                        <td>
                                            <asp:TextBox ID="TxtNamaSK2" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator5" 
                                            runat="server" 
                                            ErrorMessage="Nama Hanya boleh Huruf" 
                                            ForeColor="Red"
                                            ControlToValidate="TxtNamaSK2"
                                            ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                            ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListJenisKelaminSK2" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Kelamin</asp:ListItem>
                                                <asp:ListItem Value="1">Pria</asp:ListItem>
                                                <asp:ListItem Value="2">Wanita</asp:ListItem>
                                            </asp:DropDownList>                                            
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtUsiaSK2" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                              <asp:RegularExpressionValidator ID="RegularExpressionValidator6"
                                                   runat="server" 
                                                  ErrorMessage="Wajib Angka"
                                                  ControlToValidate="TxtUsiaSK2"
                                                  ForeColor="Red"
                                                  ValidationExpression="\d+"
                                                  ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPendidikanSK2" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pendidikan</asp:ListItem>
                                                <asp:ListItem Value="1">SMP</asp:ListItem>
                                                <asp:ListItem Value="2">SMA</asp:ListItem>
                                                <asp:ListItem Value="3">S1</asp:ListItem>
                                                <asp:ListItem Value="4">S2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPekerjaanSK2" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pekerjaan</asp:ListItem>
                                                <asp:ListItem Value="1">PNS</asp:ListItem>
                                                <asp:ListItem Value="2">Peg.Swasta</asp:ListItem>
                                                <asp:ListItem Value="3">Wira Usaha</asp:ListItem>
                                                <asp:ListItem Value="4">Pensiun</asp:ListItem>
                                                <asp:ListItem Value="5">Tidak Bekerja</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="DivJmlAnak3"><!-- Jumlah Anak 2-->
                            <asp:Label ID="Label7" runat="server" Text="Saudara Ke-3" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <th></th>
                                    <th>Nama</th>
                                    <th>Jenis Kelamin</th>
                                    <th>Usia</th>
                                    <th>Pendidikan</th>
                                    <th>Pekerjaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Saudara Kandung Ke-3</td>
                                        <td>
                                            <asp:TextBox ID="TxtNamaSK3"  class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator7" 
                                            runat="server" 
                                            ErrorMessage="Nama Hanya boleh Huruf" 
                                            ForeColor="Red"
                                            ControlToValidate="TxtNamaSK3"
                                            ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                            ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListJenisKelaminSK3" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Kelamin</asp:ListItem>
                                                <asp:ListItem Value="1">Pria</asp:ListItem>
                                                <asp:ListItem Value="2">Wanita</asp:ListItem>
                                            </asp:DropDownList>                                            
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtUsiaSK3" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator8"
                                               runat="server" 
                                              ErrorMessage="Wajib Angka"
                                              ControlToValidate="TxtUsiaSK3"
                                              ForeColor="Red"
                                              ValidationExpression="\d+"
                                              ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPendidikanSK3" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pendidikan</asp:ListItem>
                                                <asp:ListItem Value="1">SMP</asp:ListItem>
                                                <asp:ListItem Value="2">SMA</asp:ListItem>
                                                <asp:ListItem Value="3">S1</asp:ListItem>
                                                <asp:ListItem Value="4">S2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPekerjaanSK3" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pekerjaan</asp:ListItem>
                                                <asp:ListItem Value="1">PNS</asp:ListItem>
                                                <asp:ListItem Value="2">Peg.Swasta</asp:ListItem>
                                                <asp:ListItem Value="3">Wira Usaha</asp:ListItem>
                                                <asp:ListItem Value="4">Pensiun</asp:ListItem>
                                                <asp:ListItem Value="5">Tidak Bekerja</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="DivJmlAnak4"><!-- Jumlah Anak 2-->
                            <asp:Label ID="Label8" runat="server" Text="Saudara Ke-4" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <th></th>
                                    <th>Nama</th>
                                    <th>Jenis Kelamin</th>
                                    <th>Usia</th>
                                    <th>Pendidikan</th>
                                    <th>Pekerjaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Saudara Kandung Ke-4</td>
                                        <td>
                                            <asp:TextBox ID="TxtNamaSK4" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator9" 
                                            runat="server" 
                                            ErrorMessage="Nama Hanya boleh Huruf" 
                                            ForeColor="Red"
                                            ControlToValidate="TxtNamaSK4"
                                            ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                            ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListJenisKelaminSK4" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Kelamin</asp:ListItem>
                                                <asp:ListItem Value="1">Pria</asp:ListItem>
                                                <asp:ListItem Value="2">Wanita</asp:ListItem>
                                            </asp:DropDownList>                                            
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtUsiaSK4" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator10"
                                               runat="server" 
                                              ErrorMessage="Wajib Angka"
                                              ControlToValidate="TxtUsiaSK4"
                                              ForeColor="Red"
                                              ValidationExpression="\d+"
                                              ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPendidikanSK4" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pendidikan</asp:ListItem>
                                                <asp:ListItem Value="1">SMP</asp:ListItem>
                                                <asp:ListItem Value="2">SMA</asp:ListItem>
                                                <asp:ListItem Value="3">S1</asp:ListItem>
                                                <asp:ListItem Value="4">S2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPekerjaanSK4" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pekerjaan</asp:ListItem>
                                                <asp:ListItem Value="1">PNS</asp:ListItem>
                                                <asp:ListItem Value="2">Peg.Swasta</asp:ListItem>
                                                <asp:ListItem Value="3">Wira Usaha</asp:ListItem>
                                                <asp:ListItem Value="4">Pensiun</asp:ListItem>
                                                <asp:ListItem Value="5">Tidak Bekerja</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="DivJmlAnak5"><!-- Jumlah Anak 2-->
                            <asp:Label ID="Label9" runat="server" Text="Saudara Ke-5" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <th></th>
                                    <th>Nama</th>
                                    <th>Jenis Kelamin</th>
                                    <th>Usia</th>
                                    <th>Pendidikan</th>
                                    <th>Pekerjaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Saudara Kandung Ke-5</td>
                                        <td>
                                            <asp:TextBox ID="TxtNamaSK5" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator 
                                                ID="RegularExpressionValidator11" 
                                                runat="server" 
                                                ErrorMessage="Nama Hanya boleh Huruf" 
                                                ForeColor="Red"
                                                ControlToValidate="TxtNamaSK5"
                                                ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                                ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListJenisKelaminSK5" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Kelamin</asp:ListItem>
                                                <asp:ListItem Value="1">Pria</asp:ListItem>
                                                <asp:ListItem Value="2">Wanita</asp:ListItem>
                                            </asp:DropDownList>                                            
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtUsiaSK5" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator12"
                                               runat="server" 
                                              ErrorMessage="Wajib Angka"
                                              ControlToValidate="TxtUsiaSK5"
                                              ForeColor="Red"
                                              ValidationExpression="\d+"
                                              ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPendidikanSK5" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pendidikan</asp:ListItem>
                                                <asp:ListItem Value="1">SMP</asp:ListItem>
                                                <asp:ListItem Value="2">SMA</asp:ListItem>
                                                <asp:ListItem Value="3">S1</asp:ListItem>
                                                <asp:ListItem Value="4">S2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPekerjaanSK5" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pekerjaan</asp:ListItem>
                                                <asp:ListItem Value="1">PNS</asp:ListItem>
                                                <asp:ListItem Value="2">Peg.Swasta</asp:ListItem>
                                                <asp:ListItem Value="3">Wira Usaha</asp:ListItem>
                                                <asp:ListItem Value="4">Pensiun</asp:ListItem>
                                                <asp:ListItem Value="5">Tidak Bekerja</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="DivJmlAnak6"><!-- Jumlah Anak 2-->
                            <asp:Label ID="Label10" runat="server" Text="Saudara Ke-6" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <th></th>
                                    <th>Nama</th>
                                    <th>Jenis Kelamin</th>
                                    <th>Usia</th>
                                    <th>Pendidikan</th>
                                    <th>Pekerjaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Saudara Kandung Ke-6</td>
                                        <td>
                                            <asp:TextBox ID="TxtNamaSK6" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator13" 
                                            runat="server" 
                                            ErrorMessage="Nama Hanya boleh Huruf" 
                                            ForeColor="Red"
                                            ControlToValidate="TxtNamaSK6"
                                            ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                            ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListJenisKelaminSK6" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Kelamin</asp:ListItem>
                                                <asp:ListItem Value="1">Pria</asp:ListItem>
                                                <asp:ListItem Value="2">Wanita</asp:ListItem>
                                            </asp:DropDownList>                                            
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtUsiaSK6" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator14"
                                               runat="server" 
                                              ErrorMessage="Wajib Angka"
                                              ControlToValidate="TxtUsiaSK6"
                                              ForeColor="Red"
                                              ValidationExpression="\d+"
                                              ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPendidikanSK6" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pendidikan</asp:ListItem>
                                                <asp:ListItem Value="1">SMP</asp:ListItem>
                                                <asp:ListItem Value="2">SMA</asp:ListItem>
                                                <asp:ListItem Value="3">S1</asp:ListItem>
                                                <asp:ListItem Value="4">S2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPekerjaanSK6" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pekerjaan</asp:ListItem>
                                                <asp:ListItem Value="1">PNS</asp:ListItem>
                                                <asp:ListItem Value="2">Peg.Swasta</asp:ListItem>
                                                <asp:ListItem Value="3">Wira Usaha</asp:ListItem>
                                                <asp:ListItem Value="4">Pensiun</asp:ListItem>
                                                <asp:ListItem Value="5">Tidak Bekerja</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="DivJmlAnak7"><!-- Jumlah Anak 2-->
                            <asp:Label ID="Label11" runat="server" Text="Saudara Ke-7" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <th></th>
                                    <th>Nama</th>
                                    <th>Jenis Kelamin</th>
                                    <th>Usia</th>
                                    <th>Pendidikan</th>
                                    <th>Pekerjaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Saudara Kandung Ke-7</td>
                                        <td>
                                            <asp:TextBox ID="TxtNamaSK7" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator15" 
                                            runat="server" 
                                            ErrorMessage="Nama Hanya boleh Huruf" 
                                            ForeColor="Red"
                                            ControlToValidate="TxtNamaSK7"
                                            ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                            ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListJenisKelaminSK7" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Kelamin</asp:ListItem>
                                                <asp:ListItem Value="1">Pria</asp:ListItem>
                                                <asp:ListItem Value="2">Wanita</asp:ListItem>
                                            </asp:DropDownList>                                            
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtUsiaSK7" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator16"
                                               runat="server" 
                                              ErrorMessage="Wajib Angka"
                                              ControlToValidate="TxtUsiaSK7"
                                              ForeColor="Red"
                                              ValidationExpression="\d+"
                                              ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPendidikanSK7" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pendidikan</asp:ListItem>
                                                <asp:ListItem Value="1">SMP</asp:ListItem>
                                                <asp:ListItem Value="2">SMA</asp:ListItem>
                                                <asp:ListItem Value="3">S1</asp:ListItem>
                                                <asp:ListItem Value="4">S2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPekerjaanSK7" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pekerjaan</asp:ListItem>
                                                <asp:ListItem Value="1">PNS</asp:ListItem>
                                                <asp:ListItem Value="2">Peg.Swasta</asp:ListItem>
                                                <asp:ListItem Value="3">Wira Usaha</asp:ListItem>
                                                <asp:ListItem Value="4">Pensiun</asp:ListItem>
                                                <asp:ListItem Value="5">Tidak Bekerja</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="DivJmlAnak8"><!-- Jumlah Anak 2-->
                            <asp:Label ID="Label12" runat="server" Text="Saudara Ke-8" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <th></th>
                                    <th>Nama</th>
                                    <th>Jenis Kelamin</th>
                                    <th>Usia</th>
                                    <th>Pendidikan</th>
                                    <th>Pekerjaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Saudara Kandung Ke-8</td>
                                        <td>
                                            <asp:TextBox ID="TxtNamaSK8" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator17" 
                                            runat="server" 
                                            ErrorMessage="Nama Hanya boleh Huruf" 
                                            ForeColor="Red"
                                            ControlToValidate="TxtNamaSK8"
                                            ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                            ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListJenisKelaminSK8" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Kelamin</asp:ListItem>
                                                <asp:ListItem Value="1">Pria</asp:ListItem>
                                                <asp:ListItem Value="2">Wanita</asp:ListItem>
                                            </asp:DropDownList>                                            
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtUsiaSK8" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator18"
                                               runat="server" 
                                              ErrorMessage="Wajib Angka"
                                              ControlToValidate="TxtUsiaSK8"
                                              ForeColor="Red"
                                              ValidationExpression="\d+"
                                              ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPendidikanSK8" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pendidikan</asp:ListItem>
                                                <asp:ListItem Value="1">SMP</asp:ListItem>
                                                <asp:ListItem Value="2">SMA</asp:ListItem>
                                                <asp:ListItem Value="3">S1</asp:ListItem>
                                                <asp:ListItem Value="4">S2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPekerjaanSK8" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Pekerjaan</asp:ListItem>
                                                <asp:ListItem Value="1">PNS</asp:ListItem>
                                                <asp:ListItem Value="2">Peg.Swasta</asp:ListItem>
                                                <asp:ListItem Value="3">Wira Usaha</asp:ListItem>
                                                <asp:ListItem Value="4">Pensiun</asp:ListItem>
                                                <asp:ListItem Value="5">Tidak Bekerja</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>                        
                            <%--<h4><small>Data Perkawinan</small></h4>--%><!-- DATA PERKAWINAN MAKSIMAL 3 ANAK -->                                                                   
                        <br />
                        <div class="form-group" id="statusperkawinan" ><!-- Status Perkawinan-->
                            <asp:Label ID="Label13" runat="server" Text="Status Perkawinan Anda" Font-Bold="true"></asp:Label>
                            <asp:RadioButtonList ID="RadioButtonListStatusPerkawinan" CellPadding="5" RepeatDirection="Horizontal" runat="server">
                              <asp:ListItem>Menikah</asp:ListItem>
                              <asp:ListItem>Belum Menikah</asp:ListItem>
                              <asp:ListItem>Duda/Janda</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                  runat="server" 
                                  ErrorMessage="Status Perkawinan Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="RadioButtonListStatusPerkawinan"
                                  ></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group" id="DivDataSuamiIstri"><!-- Data Suami/Istri -->
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <th></th>
                                    <th>Nama</th>
                                    <th>Usia</th>
                                    <th>Pendidikan</th>
                                    <th>Pekerjaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                  <tr>
                                    <td>Suami / Istri</td>
                                    <td>
                                        <asp:TextBox ID="TxtNamaSuamiIstri" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator 
                                        ID="RegularExpressionValidator19" 
                                        runat="server" 
                                        ErrorMessage="Nama Hanya boleh Huruf" 
                                        ForeColor="Red"
                                        ControlToValidate="TxtNamaSuamiIstri"
                                        ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                        ></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                      <asp:TextBox ID="TxtUsiaSuamiIstri" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator20"
                                               runat="server" 
                                              ErrorMessage="Wajib Angka"
                                              ControlToValidate="TxtUsiaSuamiIstri"
                                              ForeColor="Red"
                                              ValidationExpression="\d+"
                                              ></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListPendidikanSuamiIstri" class="form-control" runat="server">
                                            <asp:ListItem Value="0">Pilih Jenis Pendidikan</asp:ListItem>
                                            <asp:ListItem Value="1">SMP</asp:ListItem>
                                            <asp:ListItem Value="2">SMA</asp:ListItem>
                                            <asp:ListItem Value="3">S1</asp:ListItem>
                                            <asp:ListItem Value="4">S2</asp:ListItem>
                                        </asp:DropDownList>                                
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListPekerjaanSuamiIstri" class="form-control" runat="server">
                                            <asp:ListItem Value="0">Pilih Jenis Pekerjaan</asp:ListItem>
                                            <asp:ListItem Value="1">Tidak Bekerja</asp:ListItem>
                                            <asp:ListItem Value="2">Wira Usaha</asp:ListItem>
                                            <asp:ListItem Value="3">Ibu Rumah Tangga</asp:ListItem>
                                            <asp:ListItem Value="4">PNS</asp:ListItem>
                                            <asp:ListItem Value="5">Peg.Swasta</asp:ListItem>
                                            <asp:ListItem Value="6">Mahasiswa</asp:ListItem>
                                            <asp:ListItem Value="7">Pelajar</asp:ListItem>
                                        </asp:DropDownList>  
                                    </td>
                                  </tr>
                                </tbody>
                            </table>
                            <br />
                            <asp:Label ID="Label14" runat="server" Text="Pilih Jumlah Anak Anda" Font-Bold="true"></asp:Label>
                            <asp:RadioButtonList ID="RadioButtonListJumlahAnakPerKawinan" runat="server">
                              <asp:ListItem Value="1">1</asp:ListItem>
                              <asp:ListItem Value="2">2</asp:ListItem>
                              <asp:ListItem Value="3">3</asp:ListItem>
                              <asp:ListItem Value ="0">Tidak Ada</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="form-group" id="DivDataAnak1"><!-- Data Anak -->
                            <asp:Label ID="Label15" runat="server" Text="Anak 1" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                   
                                    <th>Nama</th>
                                    <th>Usia</th>
                                    <th>Jenis Kelamin</th>
                                    <th>Pendidikan</th>
                                    <th>Pekerjaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td><asp:TextBox ID="TxtNamaAnak1" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator21" 
                                            runat="server" 
                                            ErrorMessage="Nama Hanya boleh Huruf" 
                                            ForeColor="Red"
                                            ControlToValidate="TxtNamaAnak1"
                                            ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                            ></asp:RegularExpressionValidator>
                                        </td>
                                        <td><asp:TextBox ID="TxtUsiaAnak1" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator22"
                                               runat="server" 
                                              ErrorMessage="Wajib Angka"
                                              ControlToValidate="TxtUsiaAnak1"
                                              ForeColor="Red"
                                              ValidationExpression="\d+"
                                              ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListJenisKelaminAnak1" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Kelamin</asp:ListItem>
                                                <asp:ListItem Value="1">Pria</asp:ListItem>
                                                <asp:ListItem Value="2">Wanita</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPendidikanAnak1" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Pendidikan</asp:ListItem>
                                                <asp:ListItem Value="1">SD</asp:ListItem>
                                                <asp:ListItem Value="2">SMP</asp:ListItem>
                                                <asp:ListItem Value="3">SMA</asp:ListItem>
                                                <asp:ListItem Value="4">Sarjana</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPekerjaanAnak1" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Pekerjaan</asp:ListItem>
                                                <asp:ListItem Value="1">Mahasiswa</asp:ListItem>
                                                <asp:ListItem Value="2">PNS</asp:ListItem>
                                                <asp:ListItem Value="3">Peg.Swasta</asp:ListItem>
                                                <asp:ListItem Value="4">Pelajar</asp:ListItem>
                                                <asp:ListItem Value="5">Tidak Bekerja</asp:ListItem>
                                                <asp:ListItem Value="6">Wira Usaha</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="DivDataAnak2"><!-- Data Anak -->
                            <asp:Label ID="Label16" runat="server" Text="Anak 2" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                   
                                    <th>Nama</th>
                                    <th>Usia</th>
                                    <th>Jenis Kelamin</th>
                                    <th>Pendidikan</th>
                                    <th>Pekerjaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td><asp:TextBox ID="TxtNamaAnak2" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator23" 
                                            runat="server" 
                                            ErrorMessage="Nama Hanya boleh Huruf" 
                                            ForeColor="Red"
                                            ControlToValidate="TxtNamaAnak2"
                                            ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                            ></asp:RegularExpressionValidator>
                                        </td>
                                        <td><asp:TextBox ID="TxtUsiaAnak2" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator24"
                                               runat="server" 
                                              ErrorMessage="Wajib Angka"
                                              ControlToValidate="TxtUsiaAnak2"
                                              ForeColor="Red"
                                              ValidationExpression="\d+"
                                              ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListJenisKelaminAnak2" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Kelamin</asp:ListItem>
                                                <asp:ListItem Value="1">Pria</asp:ListItem>
                                                <asp:ListItem Value="2">Wanita</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPendidikanAnak2" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Pendidikan</asp:ListItem>
                                                <asp:ListItem Value="1">SD</asp:ListItem>
                                                <asp:ListItem Value="2">SMP</asp:ListItem>
                                                <asp:ListItem Value="3">SMA</asp:ListItem>
                                                <asp:ListItem Value="4">Sarjana</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPekerjaanAnak2" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Pekerjaan</asp:ListItem>
                                                <asp:ListItem Value="1">Mahasiswa</asp:ListItem>
                                                <asp:ListItem Value="2">PNS</asp:ListItem>
                                                <asp:ListItem Value="3">Peg.Swasta</asp:ListItem>
                                                <asp:ListItem Value="4">Pelajar</asp:ListItem>
                                                <asp:ListItem Value="5">Tidak Bekerja</asp:ListItem>
                                                <asp:ListItem Value="6">Wira Usaha</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="DivDataAnak3"><!-- Data Anak -->
                            <asp:Label ID="Label17" runat="server" Text="Anak 3" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>                                   
                                    <th>Nama</th>
                                    <th>Usia</th>
                                    <th>Jenis Kelamin</th>
                                    <th>Pendidikan</th>
                                    <th>Pekerjaan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td><asp:TextBox ID="TxtNamaAnak3" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator25" 
                                            runat="server" 
                                            ErrorMessage="Nama Hanya boleh Huruf" 
                                            ForeColor="Red"
                                            ControlToValidate="TxtNamaAnak3"
                                            ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                            ></asp:RegularExpressionValidator>
                                        </td>
                                        <td><asp:TextBox ID="TxtUsiaAnak3" onKeypress="return isNumberKey(event)" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator26"
                                               runat="server" 
                                              ErrorMessage="Wajib Angka"
                                              ControlToValidate="TxtUsiaAnak3"
                                              ForeColor="Red"
                                              ValidationExpression="\d+"
                                              ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListJenisKelaminAnak3" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Jenis Kelamin</asp:ListItem>
                                                <asp:ListItem Value="1">Pria</asp:ListItem>
                                                <asp:ListItem Value="2">Wanita</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPendidikanAnak3" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Pendidikan</asp:ListItem>
                                                <asp:ListItem Value="1">SD</asp:ListItem>
                                                <asp:ListItem Value="2">SMP</asp:ListItem>
                                                <asp:ListItem Value="3">SMA</asp:ListItem>
                                                <asp:ListItem Value="4">Sarjana</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPekerjaanAnak3" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Pekerjaan</asp:ListItem>
                                                <asp:ListItem Value="1">Mahasiswa</asp:ListItem>
                                                <asp:ListItem Value="2">PNS</asp:ListItem>
                                                <asp:ListItem Value="3">Peg.Swasta</asp:ListItem>
                                                <asp:ListItem Value="4">Pelajar</asp:ListItem>
                                                <asp:ListItem Value="5">Tidak Bekerja</asp:ListItem>
                                                <asp:ListItem Value="6">Wira Usaha</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group"><!-- Button -->
                            <asp:Button ID="BtnSubmitFormDataKeluarga" runat="server" class="btn btn-danger"  Text="Simpan Data" OnClick="BtnSubmitFormDataKeluarga_Click" />
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
