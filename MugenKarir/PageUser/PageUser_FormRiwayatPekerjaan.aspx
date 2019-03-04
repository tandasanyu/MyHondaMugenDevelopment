﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageUser_FormRiwayatPekerjaan.aspx.cs" Inherits="PageUser_PageUser_FormRiwayatPekerjaan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form Riwayat Pekerjaan</title>
    <!-- DATEPICKER RANGE -->
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <script src="../js/jquery-1.12.4.js"></script>
    <script src="../js/moment.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <link href="../css/jquery.timepicker.min.css" rel="stylesheet" />
    <script src="../js/jquery.timepicker.min.js"></script>
    <!-- Bootstrap -->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript">
      $( function() {
          $("#<%= TxtWaktuMasuk1.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "dd/mm/yy",
              yearRange: "-90:+00"
          });
          $("#<%= TxtWaktuKeluar1.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "dd/mm/yy",
              yearRange: "-90:+00"
          });
          //2
          $("#<%= TxtWaktuMasuk2.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "dd/mm/yy",
              yearRange: "-90:+00"
          });
          $("#<%= TxtWaktuKeluar2.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "dd/mm/yy",
              yearRange: "-90:+00"
          });
          //3
          $("#<%= TxtWaktuMasuk3.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "dd/mm/yy",
              yearRange: "-90:+00"
          });
          $("#<%= TxtWaktuKeluar3.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "dd/mm/yy",
              yearRange: "-90:+00"
          });
      }); 

      </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //hide riwatar pekerjaan
            $("#DetailRiwayatPekerjaan1").hide();
            $("#DetailRiwayatPekerjaan2").hide();
            $("#DetailRiwayatPekerjaan3").hide();
            $('#RadioButtonListRiwayatPekerjaan input').click(function () {
                var value = $("#RadioButtonListRiwayatPekerjaan input:radio:checked").val();
                if (value == "Tidak Ada") {
                    $("#DetailRiwayatPekerjaan1").hide();
                    $("#DetailRiwayatPekerjaan2").hide();
                    $("#DetailRiwayatPekerjaan3").hide();
                }
                else if (value == "1") {
                    $("#DetailRiwayatPekerjaan1").show();
                    $("#DetailRiwayatPekerjaan2").hide();
                    $("#DetailRiwayatPekerjaan3").hide();
                }
                else if (value == "2") {
                    $("#DetailRiwayatPekerjaan1").show();
                    $("#DetailRiwayatPekerjaan2").show();
                    $("#DetailRiwayatPekerjaan3").hide();
                }
                else if (value == "3") {
                    $("#DetailRiwayatPekerjaan1").show();
                    $("#DetailRiwayatPekerjaan2").show();
                    $("#DetailRiwayatPekerjaan3").show();
                }
            });
            //hide referemsi DetailReferensiPekerjaan2 RadioButtonListReferensi
            $("#DetailReferensiPekerjaan1").hide();
            $("#DetailReferensiPekerjaan2").hide();
            $('#RadioButtonListReferensi input').click(function () {
                var value = $("#RadioButtonListReferensi input:radio:checked").val();
                if (value == "1") {
                    $("#DetailReferensiPekerjaan1").show();
                    $("#DetailReferensiPekerjaan2").hide();
                }
                else if (value == "2") {
                    $("#DetailReferensiPekerjaan1").show();
                    $("#DetailReferensiPekerjaan2").show();
                }
            });
        });
    </script>
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
    h2.RiwayatPekerjaan {
      text-align: center;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom:100px">
            <div style="margin-left:1%">
                <h2 class="RiwayatPekerjaan">Form Riwayat Pekerjaan & Referensi</h2>
                <br />
                <br />
                <div class="row">
                    <div class="col-lg-8">
                        <!-- Riwayat Pekerjaan -->
                        <div class="form-group" id="RiwayatPekerjaan">
                            <h2 ><small>Detail Riwayat Pekerjaan : </small></h2>
                            <asp:RadioButtonList ID="RadioButtonListRiwayatPekerjaan" runat="server" RepeatDirection="Horizontal"  CellPadding="5">
                                <asp:ListItem>Tidak Ada</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                runat="server" 
                                ErrorMessage="Riwayat Pekerjaan Wajib Di Isi"
                                ForeColor="Red"
                                ControlToValidate="RadioButtonListRiwayatPekerjaan"
                                ></asp:RequiredFieldValidator>
                        </div>
                        <!-- Detail Riwayat Pekerjaan 1-->
                        <div class="form-group" id="DetailRiwayatPekerjaan1" style="background:">
                          <h3 ><small>Detail Riwayat Pekerjaan 1: </small></h3>
                          <div class="row">
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label4" runat="server" Text="Nama Perusahaan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtNamaPerusahaan1" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="Tanggal Masuk :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtWaktuMasuk1" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="Alamat Perusahaan :" Font-Bold="true"></asp:Label>
                                <textarea id="TxtAlamatPerusahaan1" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>                             
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label3" runat="server" Text="Tanggal Keluar :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtWaktuKeluar1" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label5" runat="server" Text="Telpon Kantor :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtTelpKantor1" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label8" runat="server" Text="Jabatan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtJabatan1" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label9" runat="server" Text="Nama Atasan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtNamaAtasan1" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label10" runat="server" Text="Job Desk :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtJobDesk1" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label11" runat="server" Text="Gaji Awal :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtGajiAwal1" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label12" runat="server" Text="Gaji Akhri :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtGajiAkhir1" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label13" runat="server" Text="Alasan Keluar :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtAlasanKeluar1" class="form-control" runat="server"></asp:TextBox>
                            </div>
                          </div>                       
                        </div>
                        <div class="form-group" id="DetailRiwayatPekerjaan2">
                        <h3 ><small>Detail Riwayat Pekerjaan 2: </small></h3>
                          <div class="row">
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label14" runat="server" Text="Nama Perusahaan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtNamaPerusahaan2" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label15" runat="server" Text="Tanggal Masuk :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtWaktuMasuk2" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label16" runat="server" Text="Alamat Perusahaan :" Font-Bold="true"></asp:Label>
                                <textarea id="TxtAlamatPerusahaan2" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>                             
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label17" runat="server" Text="Tanggal Keluar :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtWaktuKeluar2" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label18" runat="server" Text="Telpon Kantor :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtTelpKantor2" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label19" runat="server" Text="Jabatan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtJabatan2" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label20" runat="server" Text="Nama Atasan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtNamaAtasan2" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label21" runat="server" Text="Job Desk :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtJobDesk2" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label22" runat="server" Text="Gaji Awal :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtGajiAwal2" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label23" runat="server" Text="Gaji Akhri :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtGajiAkhir2" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label24" runat="server" Text="Alasan Keluar :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtAlasanKeluar2" class="form-control" runat="server"></asp:TextBox>
                            </div>
                          </div>                       
                        </div>
                        <div class="form-group" id="DetailRiwayatPekerjaan3">
                        <h3 ><small>Detail Riwayat Pekerjaan 3: </small></h3>
                          <div class="row">
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label25" runat="server" Text="Nama Perusahaan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtNamaPerusahaan3" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label26" runat="server" Text="Tanggal Masuk :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtWaktuMasuk3" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label27" runat="server" Text="Alamat Perusahaan :" Font-Bold="true"></asp:Label>
                                <textarea id="TxtAlamatPerusahaan3" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>                             
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label28" runat="server" Text="Tanggal Keluar :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtWaktuKeluar3" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label29" runat="server" Text="Telpon Kantor :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtTelpKantor3" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label30" runat="server" Text="Jabatan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtJabatan3" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label31" runat="server" Text="Nama Atasan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtNamaAtasan3" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label32" runat="server" Text="Job Desk :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtJobDesk3" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label33" runat="server" Text="Gaji Awal :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtGajiAwal3" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label34" runat="server" Text="Gaji Akhri :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtGajiAkhir3" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label35" runat="server" Text="Alasan Keluar :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtAlasanKeluar3" class="form-control" runat="server"></asp:TextBox>
                            </div>
                          </div>                       
                        </div>
                        <!-- Referensi Pekerjaan -->
                        <div class="form-group" id="ReferensiPekerjaan">
                            <h2 ><small>Referesi (Seseorang yang Dapat memberikan Keterangan tentang Anda): </small></h2>
                            <asp:RadioButtonList ID="RadioButtonListReferensi" runat="server" RepeatDirection="Horizontal"  CellPadding="5">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                runat="server" 
                                ErrorMessage="Referensi Pekerjaan Wajib Di Isi"
                                ForeColor="Red"
                                ControlToValidate="RadioButtonListReferensi"
                                ></asp:RequiredFieldValidator>
                        </div>
                        <!-- Detail Referensi Pekerjaan -->
                        <div class="form-group" id="DetailReferensiPekerjaan1">
                            <asp:Label ID="Label36" runat="server" Text="Referensi Pekerjaan 1 :" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <th>Nama</th>
                                    <th>Alamat</th>
                                    <th>Nomor Telpon</th>
                                    <th>Pekerjaan</th>
                                    <th>Hubungan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TxtNamaReferensi1" class="form-control" runat="server" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtAlamatReferensi1" class="form-control" runat="server" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtNoTelpReferensi1" class="form-control" runat="server" ></asp:TextBox>
                                        </td>
                                        <td>
                                        <asp:DropDownList ID="DropDownListPekerjaan1" class="form-control" runat="server">
                                            <asp:ListItem Value="0">Pilih Pekerjaan</asp:ListItem>
                                            <asp:ListItem Value="1">PNS</asp:ListItem>
                                            <asp:ListItem Value="2">Peg.Swasta</asp:ListItem>
                                            <asp:ListItem Value="3">Wira Usaha</asp:ListItem>
                                            <asp:ListItem Value="4">Pensiunan</asp:ListItem>
                                            <asp:ListItem Value="5">Ibu Rumah Tangga</asp:ListItem>
                                        </asp:DropDownList>  
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListHubungan1" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Hubungan</asp:ListItem>
                                                <asp:ListItem Value="1">Atasan</asp:ListItem>
                                                <asp:ListItem Value="2">Rekan kerja</asp:ListItem>
                                                <asp:ListItem Value="2">Teman</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="DetailReferensiPekerjaan2">
                            <asp:Label ID="Label37" runat="server" Text="Referensi Pekerjaan 1 :" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <th>Nama</th>
                                    <th>Alamat</th>
                                    <th>Nomor Telpon</th>
                                    <th>Pekerjaan</th>
                                    <th>Hubungan</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TxtNamaReferensi2" class="form-control" runat="server" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtAlamatReferensi2" class="form-control" runat="server" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtNoTelpReferensi2" class="form-control" runat="server" ></asp:TextBox>
                                        </td>
                                        <td>
                                        <asp:DropDownList ID="DropDownListPekerjaan2" class="form-control" runat="server">
                                            <asp:ListItem Value="0">Pilih Pekerjaan</asp:ListItem>
                                            <asp:ListItem Value="1">PNS</asp:ListItem>
                                            <asp:ListItem Value="2">Peg.Swasta</asp:ListItem>
                                            <asp:ListItem Value="3">Wira Usaha</asp:ListItem>
                                            <asp:ListItem Value="4">Pensiunan</asp:ListItem>
                                            <asp:ListItem Value="5">Ibu Rumah Tangga</asp:ListItem>
                                        </asp:DropDownList>  
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListHubungan2" class="form-control" runat="server">
                                                <asp:ListItem Value="0">Pilih Hubungan</asp:ListItem>
                                                <asp:ListItem Value="1">Atasan</asp:ListItem>
                                                <asp:ListItem Value="2">Rekan kerja</asp:ListItem>
                                                <asp:ListItem Value="2">Teman</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- Button -->
                        <div class="form-group" id="Button">
                            <asp:Button ID="Button1" runat="server" Text="Simpan" class="btn btn-danger"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="footer">
            <div style="margin-top:1px">
                <asp:Label ID="Label6" runat="server" Text="Developed by IT Departement 2019 &#169;"></asp:Label>            
            </div>
            <div style="margin-top:1px">
                 <asp:Label ID="Label7" runat="server" Text="PT.Mitra Usaha Gentaniaga"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>