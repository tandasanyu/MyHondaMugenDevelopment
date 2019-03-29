<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageUser_FormDataDiri.aspx.cs" Inherits="PageUser_PageUser_FormDataDiri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form Data Diri</title>
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
<script>
$(function() {
    $( "#<%= TxtTglLahir.ClientID %>" ).datepicker();
});
</script>
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
          $("#<%= TxtTglLahir.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "dd/mm/yy",
              yearRange: "-90:+00"
          });

      } );
      </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //untuk rbList Sim 
            $('#RadioButtonListSIM input').change(function () {
                if ($(this).val() != "Tidak Ada") {
                    $("#TxtNomorSIM").css("display", "block");
                }
                else {
                    $("#TxtNomorSIM").css("display", "none");
                }
            });
            //untuk rbList Ktp
            $('#RadioButtonListAlamatTinggal input').change(function () {
                if ($(this).val() == "Berbeda dengan KTP") {
                    $("#TextAreaAamatKTP").css("display", "block");
                }
                else {
                    $("#TextAreaAamatKTP").css("display", "none");
                }
            });
            //untuk rb npwp
            $('#RadioButtonListNPWP input').change(function () {
                if ($(this).val() != "Tidak Ada") {
                    $("#TxtNPWP").css("display", "block");
                }
                else {
                    $("#TxtNPWP").css("display", "none");
                }
            });
            //untuk rb jamoso
            $('#RadioButtonListJamsostek input').change(function () {
                if ($(this).val() != "Tidak Ada") {
                    $("#TxtJamsos").css("display", "block");
                }
                else {
                    $("#TxtJamsos").css("display", "none");
                }
            });
            //untuk rb bca
            $('#RadioButtonListBCA input').change(function () {
                if ($(this).val() != "Tidak Ada") {
                    $("#TxtRekBca").css("display", "block");
                }
                else {
                    $("#TxtRekBca").css("display", "none");
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom:100px">
            <div style="margin-left:1%">
                <h2 class="FormDataDiri">Form Data Diri</h2>
                <br />
                <br />
                <div class="row">
                    <div class="col-lg-6">
                      <div class="form-group"><!-- Nama Lengkap -->
                          <asp:Label ID="Label3" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Nama Lengkap"></asp:Label>
                          <div class="col-sm-8">
                              <asp:TextBox ID="TxtNamaLengkap" class="form-control" runat="server" autocomplete="off"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidatorNama" 
                                  runat="server" 
                                  ErrorMessage="Nama Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="TxtNamaLengkap"
                                  ></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                runat="server" 
                                ErrorMessage="Nama Hanya boleh Huruf"
                                ForeColor="Red"
                                ControlToValidate="TxtNamaLengkap"
                                ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                ></asp:RegularExpressionValidator>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- Tempat Lahir -->
                          <asp:Label ID="Label5" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Tempat Lahir"></asp:Label>
                          <div class="col-sm-8">
                              <asp:TextBox ID="TxtTempatLahir" class="form-control" runat="server" autocomplete="off"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                  runat="server" 
                                  ErrorMessage="Tempat Lahir Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="TxtTempatLahir"
                                  ></asp:RequiredFieldValidator>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- Jenis Kelamin -->
                          <asp:Label ID="Label7" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Jenis Kelamin"></asp:Label>
                          <div class="col-sm-8">
                              <asp:RadioButtonList ID="RadioButtonListJenisKelamin" runat="server">
                                  <asp:ListItem>Pria</asp:ListItem>
                                  <asp:ListItem>Wanita</asp:ListItem>
                              </asp:RadioButtonList>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                                  runat="server" 
                                  ErrorMessage="Jenis Kelamin Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="RadioButtonListJenisKelamin"
                                  ></asp:RequiredFieldValidator>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- Alamat KTP -->
                          <asp:Label ID="Label9" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Alamat Sesuai KTP" ></asp:Label>
                          <div class="col-sm-8">
                              <textarea id="TextAreaAlamatKTP" name="TextAreaAlamatKTP" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                                  runat="server" 
                                  ErrorMessage="Alamat Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="TextAreaAlamatKTP"
                                  ></asp:RequiredFieldValidator>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- Telfon Rumah -->
                          <asp:Label ID="Label11" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Telepon Rumah"></asp:Label>
                          <div class="col-sm-8">
                              <asp:TextBox ID="TxtTeleponRumah" class="form-control" runat="server" autocomplete="off"></asp:TextBox>
<%--                              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                                  runat="server" 
                                  ErrorMessage="Telpon Rumah Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="TxtTeleponRumah"
                                  ></asp:RequiredFieldValidator>--%>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                                   runat="server" 
                                  ErrorMessage="Wajib Angka"
                                  ControlToValidate="TxtTeleponRumah"
                                  ForeColor="Red"
                                  ValidationExpression="\d+"
                                  ></asp:RegularExpressionValidator>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- Hobi -->
                          <asp:Label ID="Label13" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Hobi"></asp:Label>
                          <div class="col-sm-8">
                              <asp:TextBox ID="TxtHobi" class="form-control" runat="server" autocomplete="off"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator10" 
                                  runat="server" 
                                  ErrorMessage="Hobi Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="TxtHobi"
                                  ></asp:RequiredFieldValidator>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- KTP -->
                          <asp:Label ID="Label15" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Nomor KTP"></asp:Label>
                          <div class="col-sm-8">
                              <asp:TextBox ID="TxtNoKTP" class="form-control" runat="server" autocomplete="off"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator12" 
                                  runat="server" 
                                  ErrorMessage="Nomor KTP Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="TxtNoKTP"
                                  ></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator5"
                                   runat="server" 
                                  ErrorMessage="Wajib Angka"
                                  ControlToValidate="TxtNoKTP"
                                  ForeColor="Red"
                                  ValidationExpression="\d+"
                                  ></asp:RegularExpressionValidator>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- Jenis SIM -->
                          <asp:Label ID="Label19" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Jenis SIM"></asp:Label>
                          <div class="col-sm-8">
                              <asp:RadioButtonList ID="RadioButtonListSIM" onclick="Radio_Click()" runat="server">
                                  <asp:ListItem>SIM A</asp:ListItem>
                                  <asp:ListItem>SIM C</asp:ListItem>
                                  <asp:ListItem>Tidak Ada</asp:ListItem>
                              </asp:RadioButtonList>
                              <asp:Label ID="Label20" runat="server" Text="Nomor SIM" Font-Bold="true"></asp:Label>
                              <asp:TextBox ID="TxtNomorSIM" class="form-control" runat="server" autocomplete="off"></asp:TextBox>
<%--                              <asp:RequiredFieldValidator ID="RequiredFieldValidator15" 
                                  runat="server" 
                                  ErrorMessage="Kepemilikan SIM Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="RadioButtonListSIM"
                                  ></asp:RequiredFieldValidator>--%>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator9"
                                   runat="server" 
                                  ErrorMessage="Wajib Angka"
                                  ControlToValidate="TxtNomorSIM"
                                  ForeColor="Red"
                                  ValidationExpression="\d+"
                                  ></asp:RegularExpressionValidator>
                          </div>                         
                      </div>

                    </div>
                    <!-- ***************************************************************************8 -->
                    <div class="col-lg-6">
                      <div class="form-group"><!-- Nama Panggilan -->
                          <asp:Label ID="Label4" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Nama Panggilan"></asp:Label>
                          <div class="col-sm-8">
                              <asp:TextBox ID="TxtNamaPanggilan" class="form-control" runat="server" autocomplete="off"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                  runat="server" 
                                  ErrorMessage="Nama Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="TxtNamaPanggilan"
                                  ></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                runat="server" 
                                ErrorMessage="Nama Hanya boleh Huruf"
                                ForeColor="Red"
                                ControlToValidate="TxtNamaPanggilan"
                                ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                ></asp:RegularExpressionValidator>                         
                          </div>                         
                      </div>
                      <div class="form-group"><!-- Tgl Lahir -->
                          <asp:Label ID="Label6" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Tanggal Lahir" ></asp:Label>
                          <div class="col-sm-8">
                              <asp:TextBox ID="TxtTglLahir" class="form-control" runat="server" autocomplete="off"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                  runat="server" 
                                  ErrorMessage="Tanggal Lahir Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="TxtTglLahir"
                                  ></asp:RequiredFieldValidator>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- Agama -->
                          <asp:Label ID="Label8" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Pilih Agama"></asp:Label>
                          <div class="col-sm-8">
                              <asp:RadioButtonList ID="RadioButtonListAgama" runat="server">
                                  <asp:ListItem>Islam</asp:ListItem>
                                  <asp:ListItem>Kristen</asp:ListItem>
                                  <asp:ListItem>Katolik</asp:ListItem>
                                  <asp:ListItem>Hindu</asp:ListItem>
                                  <asp:ListItem>Budha</asp:ListItem>
                                  <asp:ListItem>Konghucu</asp:ListItem>
                              </asp:RadioButtonList>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                                  runat="server" 
                                  ErrorMessage="Agama Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="RadioButtonListAgama"
                                  ></asp:RequiredFieldValidator>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- Alamat Tinggal -->
                          <asp:Label ID="Label10" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Alamat Tinggal" ></asp:Label>
                          <div class="col-sm-8">
                              <asp:RadioButtonList ID="RadioButtonListAlamatTinggal" runat="server">
                                  <asp:ListItem>Sesuai KTP</asp:ListItem>
                                  <asp:ListItem>Berbeda dengan KTP</asp:ListItem>
                              </asp:RadioButtonList>
                              <textarea id="TextAreaAamatKTP" name="TextAreaAamatKTP" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                                  runat="server" 
                                  ErrorMessage="Wajib Di pilih Jenis Alamat Anda"
                                  ForeColor="Red"
                                  ControlToValidate="RadioButtonListAlamatTinggal"
                                  ></asp:RequiredFieldValidator>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- Telfon Pribadi -->
                          <asp:Label ID="Label12" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Handphone"></asp:Label>
                          <div class="col-sm-8">
                              <asp:TextBox ID="TxtHandphone" class="form-control" runat="server" autocomplete="off"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator9" 
                                  runat="server" 
                                  ErrorMessage="Nomor Handphone Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="TxtHandphone"
                                  ></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                                   runat="server" 
                                  ErrorMessage="Wajib Angka"
                                  ControlToValidate="TxtHandphone"
                                  ForeColor="Red"
                                  ValidationExpression="\d+"
                                  ></asp:RegularExpressionValidator>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- Email -->
                          <asp:Label ID="Label14" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Email"></asp:Label>
                          <div class="col-sm-8">
                              <asp:TextBox ID="TxtEmail" class="form-control" runat="server" autocomplete="off"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator11" 
                                  runat="server" 
                                  ErrorMessage="Email Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="TxtEmail"
                                  ></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator6" 
                                runat="server" 
                                ErrorMessage="Format Email Salah"
                                ForeColor="Red"
                                ControlToValidate="TxtEmail"
                                SetFocusOnError="True"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ></asp:RegularExpressionValidator>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- NPWP -->
                          <asp:Label ID="Label16" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="NPWP"></asp:Label>
                              <asp:RadioButtonList ID="RadioButtonListNPWP" repeatdirection="Horizontal" TextAlign="Right" CellPadding="9"  runat="server">
                                  <asp:ListItem>Ada</asp:ListItem>
                                  <asp:ListItem>Tidak Ada</asp:ListItem>
                              </asp:RadioButtonList>       
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                                  runat="server" 
                                  ErrorMessage="Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="RadioButtonListNPWP"
                                  ></asp:RequiredFieldValidator>                                          
                          <div class="col-sm-8">
                              <p style="color:red">NPWP wajib 15 Angka</p>
                              <asp:TextBox ID="TxtNPWP" class="form-control" runat="server" autocomplete="off"></asp:TextBox>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- Jamsostek -->
                          <asp:Label ID="Label17" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Nomor Jamsostek"></asp:Label>
                          <asp:RadioButtonList ID="RadioButtonListJamsostek" repeatdirection="Horizontal" TextAlign="Right" CellPadding="9"  runat="server">
                                  <asp:ListItem>Ada</asp:ListItem>
                                  <asp:ListItem>Tidak Ada</asp:ListItem>
                          </asp:RadioButtonList>                     
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator13" 
                                  runat="server" 
                                  ErrorMessage="Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="RadioButtonListJamsostek"
                                  ></asp:RequiredFieldValidator>  
                          <div class="col-sm-8">
                              <p style="color:red">NPWP wajib 13 Angka</p>
                              <asp:TextBox ID="TxtJamsos" class="form-control" runat="server" autocomplete="off"></asp:TextBox>
                          </div>                         
                      </div>
                      <div class="form-group"><!-- REK BCA -->
                          <asp:Label ID="Label18" CssClass="col-sm-4" runat="server" Font-Bold="true" Text="Nomor Rek.BCA"></asp:Label>
                          <asp:RadioButtonList ID="RadioButtonListBCA" repeatdirection="Horizontal" TextAlign="Right" CellPadding="9"  runat="server">
                                  <asp:ListItem>Ada</asp:ListItem>
                                  <asp:ListItem>Tidak Ada</asp:ListItem>
                          </asp:RadioButtonList>            
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator14" 
                                  runat="server" 
                                  ErrorMessage="Wajib Di Isi"
                                  ForeColor="Red"
                                  ControlToValidate="RadioButtonListBCA"
                                  ></asp:RequiredFieldValidator>          
                          <div class="col-sm-8">
                              <asp:TextBox ID="TxtRekBca" class="form-control" runat="server" autocomplete="off"></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator7"
                                   runat="server" 
                                  ErrorMessage="Wajib Angka"
                                  ControlToValidate="TxtRekBca"
                                  ForeColor="Red"
                                  ValidationExpression="\d+"
                                  ></asp:RegularExpressionValidator>
                          </div>                         
                      </div>
                        <asp:Label ID="LblUserNama" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>
                      <div class="form-group"><!-- Button -->
                          <div class="col-sm-8">
                              <asp:Button ID="BtnSubmitFormDataDiri" runat="server" Text="Simpan Data" class="btn btn-danger" OnClick="BtnSubmitFormDataDiri_Click" />
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
