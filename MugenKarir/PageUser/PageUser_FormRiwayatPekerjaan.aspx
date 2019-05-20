<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageUser_FormRiwayatPekerjaan.aspx.cs" Inherits="PageUser_PageUser_FormRiwayatPekerjaan" %>

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
        function validate(s, args) {
        //var rad = document.getElementById('<%=RadioButtonListRiwayatPekerjaan.ClientID %>');
        //var radio = rad.getElementsByTagName("input");
        //for (var i=0;i<radio.length;i++){
               //if (radio[i].checked)
               //{
                   //your Code goes here....
                   //if (radio[i].value == "1") {
                       //ValidatorEnable(document.getElementById("RequiredFieldValidatorPT1"), true);
                   //}
                   //else {
                       //ValidatorEnable(document.getElementById("RequiredFieldValidatorPT1"), false);
                   //}
                   //alert("SelectedValue = " + radio[i].value);
               //}
            //}
            var list = document.getElementById('<%=RadioButtonListRiwayatPekerjaan.ClientID %>'); //Client ID of the radiolist
            var inputs = list.getElementsByTagName("input");
            var selected;
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].checked) {
                    selected = inputs[i];
                    break;
                }
            }
            if (selected == "Tidak Ada") {
                args.IsValid = false;
            }else if (selected =="1"){
                args.IsValid = true;
            }
        }
    </script>
    <script type="text/javascript">
      //Code to allow only Integers in a textbox Using Javascript
      function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;    
         return true;
      }
   </script>
    <script type="text/javascript">
      $( function() {
          $("#<%= TxtWaktuMasuk1.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "yy-mm-dd",
              yearRange: "-90:+00"
          });
          $("#<%= TxtWaktuKeluar1.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "yy-mm-dd",
              yearRange: "-90:+00"
          });
          //2
          $("#<%= TxtWaktuMasuk2.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "yy-mm-dd",
              yearRange: "-90:+00"
          });
          $("#<%= TxtWaktuKeluar2.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "yy-mm-dd",
              yearRange: "-90:+00"
          });
          //3
          $("#<%= TxtWaktuMasuk3.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "yy-mm-dd",
              yearRange: "-90:+00"
          });
          $("#<%= TxtWaktuKeluar3.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "yy-mm-dd",
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
                            <h2 ><small>Detail Riwayat Pekerjaan : </small></h2><br />
                            <h5 class="text-danger">*Di urutkan dari Pekerjaan Terakhir Anda</h5>
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
                        <div class="form-group" id="DetailRiwayatPekerjaan1" >
                          <h3 ><small>Detail Riwayat Pekerjaan 1: </small></h3>
                          <div class="row">
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label4" runat="server" Text="Nama Perusahaan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtNamaPerusahaan1" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                    runat="server" 
                                    ErrorMessage="Nama Hanya boleh Huruf"
                                    ForeColor="Red"
                                    ControlToValidate="TxtNamaPerusahaan1"
                                    ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                    ></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="Tanggal Masuk :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtWaktuMasuk1" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="Alamat Perusahaan :" Font-Bold="true"></asp:Label>
                                <textarea id="TxtAlamatPerusahaan1" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>                             
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
                                runat="server" 
                                ErrorMessage="Nama Hanya boleh Huruf"
                                ForeColor="Red"
                                ControlToValidate="TxtAlamatPerusahaan1"
                                ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                ></asp:RegularExpressionValidator>                           
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label3" runat="server" Text="Tanggal Keluar :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtWaktuKeluar1" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label5" runat="server" Text="Telpon Kantor :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtTelpKantor1" autocomplete="off" class="form-control" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label8" runat="server" Text="Jabatan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtJabatan1" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label9" runat="server" Text="Nama Atasan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtNamaAtasan1" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator4" 
                                runat="server" 
                                ErrorMessage="Nama Hanya boleh Huruf"
                                ForeColor="Red"
                                ControlToValidate="TxtAlamatPerusahaan1"
                                ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                ></asp:RegularExpressionValidator>        
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label10" runat="server" Text="Job Desk :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtJobDesk1" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label11" runat="server" Text="Gaji Awal :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtGajiAwal1" autocomplete="off" class="form-control" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label12" runat="server" Text="Gaji Akhir :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtGajiAkhir1" autocomplete="off" class="form-control" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label13" runat="server" Text="Alasan Keluar :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtAlasanKeluar1" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
                                runat="server" 
                                ErrorMessage="Nama Hanya boleh Huruf"
                                ForeColor="Red"
                                ControlToValidate="TxtAlamatPerusahaan1"
                                ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                ></asp:RegularExpressionValidator>        
                            </div>
                          </div>                       
                        </div>
                        <div class="form-group" id="DetailRiwayatPekerjaan2">
                        <h3 ><small>Detail Riwayat Pekerjaan 2: </small></h3>
                          <div class="row">
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label14" runat="server" Text="Nama Perusahaan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtNamaPerusahaan2" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator 
                                    ID="RegularExpressionValidator1" 
                                    runat="server" 
                                    ErrorMessage="RegularExpressionValidator"
                                    ValidationExpression="^([\sA-Za-z]+)$"
                                    ControlToValidate="TxtNamaPerusahaan2"
                                    ></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label15" runat="server" Text="Tanggal Masuk :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtWaktuMasuk2" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label16" runat="server" Text="Alamat Perusahaan :" Font-Bold="true"></asp:Label>
                                <textarea id="TxtAlamatPerusahaan2"  cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>                             
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator6" 
                                runat="server" 
                                ErrorMessage="Nama Hanya boleh Huruf"
                                ForeColor="Red"
                                ControlToValidate="TxtAlamatPerusahaan2"
                                ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                ></asp:RegularExpressionValidator>                                
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label17" runat="server" Text="Tanggal Keluar :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtWaktuKeluar2" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label18" runat="server" Text="Telpon Kantor :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtTelpKantor2" autocomplete="off" class="form-control" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label19" runat="server" Text="Jabatan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtJabatan2" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label20" runat="server" Text="Nama Atasan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtNamaAtasan2" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator7" 
                                runat="server" 
                                ErrorMessage="Nama Hanya boleh Huruf"
                                ForeColor="Red"
                                ControlToValidate="TxtNamaAtasan2"
                                ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                ></asp:RegularExpressionValidator>  
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label21" runat="server" Text="Job Desk :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtJobDesk2" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label22" runat="server" Text="Gaji Awal :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtGajiAwal2" autocomplete="off" class="form-control" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label23" runat="server" Text="Gaji Akhir :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtGajiAkhir2" autocomplete="off" class="form-control" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label24" runat="server" Text="Alasan Keluar :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtAlasanKeluar2" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator8" 
                                runat="server" 
                                ErrorMessage="Nama Hanya boleh Huruf"
                                ForeColor="Red"
                                ControlToValidate="TxtAlasanKeluar2"
                                ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                ></asp:RegularExpressionValidator>  
                            </div>
                          </div>                       
                        </div>
                        <div class="form-group" id="DetailRiwayatPekerjaan3">
                        <h3 ><small>Detail Riwayat Pekerjaan 3: </small></h3>
                          <div class="row">
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label25" runat="server" Text="Nama Perusahaan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtNamaPerusahaan3" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator9" 
                                runat="server" 
                                ErrorMessage="Nama Hanya boleh Huruf"
                                ForeColor="Red"
                                ControlToValidate="TxtNamaPerusahaan3"
                                ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                ></asp:RegularExpressionValidator>  
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label26" runat="server" Text="Tanggal Masuk :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtWaktuMasuk3" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label27" runat="server" Text="Alamat Perusahaan :" Font-Bold="true"></asp:Label>
                                <textarea id="TxtAlamatPerusahaan3"  cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>                             
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label28" runat="server" Text="Tanggal Keluar :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtWaktuKeluar3" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label29" runat="server" Text="Telpon Kantor :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtTelpKantor3" autocomplete="off" class="form-control" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label30" runat="server" Text="Jabatan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtJabatan3" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label31" runat="server" Text="Nama Atasan :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtNamaAtasan3" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator10" 
                                runat="server" 
                                ErrorMessage="Nama Hanya boleh Huruf"
                                ForeColor="Red"
                                ControlToValidate="TxtNamaAtasan3"
                                ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                ></asp:RegularExpressionValidator>  
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label32" runat="server" Text="Job Desk :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtJobDesk3" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label33" runat="server" Text="Gaji Awal :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtGajiAwal3" autocomplete="off" class="form-control" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label34" runat="server" Text="Gaji Akhir :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtGajiAkhir3" autocomplete="off" class="form-control" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                            <div class="col-sm-5" >
                                <br />
                                <asp:Label ID="Label35" runat="server" Text="Alasan Keluar :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TxtAlasanKeluar3" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator11" 
                                runat="server" 
                                ErrorMessage="Nama Hanya boleh Huruf"
                                ForeColor="Red"
                                ControlToValidate="TxtAlasanKeluar3"
                                ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                ></asp:RegularExpressionValidator>  
                            </div>
                          </div>                       
                        </div>
                        <!-- Referensi Pekerjaan -->
                        <div class="form-group" id="ReferensiPekerjaan">
                            <h2 ><small>Referensi (Seseorang yang Dapat memberikan Keterangan tentang Anda): </small></h2>
                            <asp:RadioButtonList ID="RadioButtonListReferensi" runat="server" RepeatDirection="Horizontal"  CellPadding="5">
                                <asp:ListItem>1</asp:ListItem>
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
                                            <asp:TextBox ID="TxtNamaReferensi1" autocomplete="off" class="form-control" runat="server" ></asp:TextBox>
                                           <asp:RegularExpressionValidator ID="RegularExpressionValidator12" 
                                            runat="server" 
                                            ErrorMessage="Nama Hanya boleh Huruf"
                                            ForeColor="Red"
                                            ControlToValidate="TxtNamaReferensi1"
                                            ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                            ></asp:RegularExpressionValidator>                                         
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtAlamatReferensi1" autocomplete="off" class="form-control" runat="server" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtNoTelpReferensi1" autocomplete="off" class="form-control" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
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
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="DetailReferensiPekerjaan2">
                            <asp:Label ID="Label37" runat="server" Text="Referensi Pekerjaan 2 :" Font-Bold="true"></asp:Label>
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
                                            <asp:TextBox ID="TxtNamaReferensi2" autocomplete="off" class="form-control" runat="server" ></asp:TextBox>
                                           <asp:RegularExpressionValidator ID="RegularExpressionValidator13" 
                                            runat="server" 
                                            ErrorMessage="Nama Hanya boleh Huruf"
                                            ForeColor="Red"
                                            ControlToValidate="TxtNamaReferensi2"
                                            ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                            ></asp:RegularExpressionValidator>                                               
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtAlamatReferensi2" autocomplete="off" class="form-control" runat="server" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtNoTelpReferensi2" autocomplete="off" class="form-control" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
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
                            <asp:Button ID="Button1" runat="server" Text="Simpan" class="btn btn-danger" OnClick="Button1_Click"/>
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
