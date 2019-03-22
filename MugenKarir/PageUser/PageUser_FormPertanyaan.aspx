<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageUser_FormPertanyaan.aspx.cs" Inherits="PageUser_PageUser_FormPertanyaan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form Pertanyaan</title>
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
h2.FormPertanyaan {
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
            //hideTxtAreaSakit
            $("#TxtAreaSakit1").hide();
            $('#RadioButtonListSakit input').click(function () {
                var value = $("#RadioButtonListSakit input:radio:checked").val();
                if (value == "Ya") {
                    $("#TxtAreaSakit1").show();
                }
                else if (value == "Tidak") {
                    $("#TxtAreaSakit1").hide();
                }
            });
            //hide text area
            $("#textarealingkungankerja").hide();
            $('#RadioButtonListLingkunganKerja input').click(function () {
                var value = $("#RadioButtonListLingkunganKerja input:radio:checked").val();
                if (value == "Lainya") {
                    $("#textarealingkungankerja").show();
                }
                else {
                    $("#textarealingkungankerja").hide();
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom:100px">
            <div style="margin-left:1%">
                <h2 class="FormPertanyaan">Form Pertanyaan</h2>
                <br />
                <br />
                <div class="row">
                    <div class="col-lg-8">
                        <!-- Pertanyaan 1 -->
                        <div class="form-group" id="Pertanyaan1">
                            <asp:Label ID="Label4" runat="server" Text="Apakah anda pernah sakit yang membutuhkan perawatan di rumah sakit?" Font-Bold="true"></asp:Label>
                            <asp:RadioButtonList ID="RadioButtonListSakit" RepeatDirection="Horizontal" runat="server" CellPadding="5">
                                <asp:ListItem>Ya</asp:ListItem>
                                <asp:ListItem>Tidak</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                runat="server" 
                                ForeColor="red"
                                ErrorMessage="Riwayat Sakit Wajib Di Pilih"
                                ControlToValidate="RadioButtonListSakit"></asp:RequiredFieldValidator>
                            <div id="TxtAreaSakit1">
                                <textarea id="TxtAreaSakit" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>
                            </div>                         
                        </div>
                        <!-- Pertanyaan 2 -->
                        <div class="form-group" id="Pertanyaan2">
                            <asp:Label ID="Label1" runat="server" Text="Sebutkan Kelebihan diri Anda!" Font-Bold="true"></asp:Label>
                            <textarea id="TxtAreaKelebihan" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                                runat="server" 
                                ForeColor="red"
                                ErrorMessage="Kelebihan Diri Anda Wajib Di Isi"
                                ControlToValidate="TxtAreaKelebihan"></asp:RequiredFieldValidator>                            
                        </div>
                        <!-- Pertanyaan 3 -->
                        <div class="form-group" id="Pertanyaan3">
                            <asp:Label ID="Label2" runat="server" Text="Sebutkan Kekurangan Diri Anda!" Font-Bold="true"></asp:Label>
                            <textarea id="TxtAreaKekurangan" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                                runat="server" 
                                ForeColor="red"
                                ErrorMessage="Kekurangan Diri Anda Wajib Di Isi"
                                ControlToValidate="TxtAreaKekurangan"></asp:RequiredFieldValidator>                           
                        </div>
                        <!-- Pertanyaan 4 -->
                        <div class="form-group" id="Pertanyaan4">
                            <asp:Label ID="Label3" runat="server" Text="Keahlian Apa saja yang Anda Miliki?" Font-Bold="true"></asp:Label>
                            <textarea id="TxtAreaKeahlian" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                                runat="server" 
                                ForeColor="red"
                                ErrorMessage="Keahlian Diri Anda Wajib Di Isi"
                                ControlToValidate="TxtAreaKeahlian"></asp:RequiredFieldValidator>        
                        </div>
                        <!-- Pertanyaan 5 -->
                        <div class="form-group" id="Pertanyaan5">
                            <asp:Label ID="Label5" runat="server" Text="Apa yang anda ketahui mengenai Job Description	dari pekerjaan yang anda lamar ini?" Font-Bold="true"></asp:Label>
                            <textarea id="TxtAreaJobDesc" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                                runat="server" 
                                ForeColor="red"
                                ErrorMessage="Job Desc Wajib Di Isi"
                                ControlToValidate="TxtAreaJobDesc"></asp:RequiredFieldValidator>  
                        </div>
                        <!-- Pertanyaan 6 -->
                        <div class="form-group" id="Pertanyaan6">
                            <asp:Label ID="Label8" runat="server" Text="Berapa gaji yang anda harapkan?" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="TxtGaji" runat="server" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" 
                                runat="server" 
                                ErrorMessage="*Gaji Wajib Di Isi" 
                                ControlToValidate="TxtGaji" 
                                ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                runat="server" 
                                ErrorMessage="Gaji Wajib Angka"
                                ControlToValidate="TxtGaji"
                                ForeColor="red"
                                ValidationExpression="^\d+$"
                                ></asp:RegularExpressionValidator>
                        </div>
                        <!-- Pertanyaan 7 -->
                        <div class="form-group" id="Pertanyaan7">
                            <asp:Label ID="Label9" runat="server" Text="Sebutkan tunjangan/fasilitas yang anda inginkan!" Font-Bold="true"></asp:Label>
                            <textarea id="TextareaTunjangan" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" 
                                runat="server" 
                                ForeColor="red"
                                ErrorMessage="Tunjangan dan Fasilitas Wajib Di Isi"
                                ControlToValidate="TextareaTunjangan"></asp:RequiredFieldValidator>  
                        </div>
                        <!-- Pertanyaan 8 -->
                        <div class="form-group" id="Pertanyaan8">
                            <asp:Label ID="Label10" runat="server" Text="Bila anda diterima, kapan anda siap bekerja di Honda Mugen?" Font-Bold="true"></asp:Label>
                            <asp:RadioButtonList ID="RadioButtonListSiapBekerja" RepeatDirection="Horizontal" runat="server" CellPadding="5">
                              <asp:ListItem>Secepatnya</asp:ListItem>
                              <asp:ListItem>1 Bulan Notifikasi</asp:ListItem>
                              <asp:ListItem>1 Minggu Notifikasi</asp:ListItem>
                              <asp:ListItem>2 Minggu Notifikasi</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                runat="server" 
                                ErrorMessage="Keisapan Bekerja Wajib di Isi"
                                ControlToValidate="RadioButtonListSiapBekerja"
                                ForeColor="red"
                                ></asp:RequiredFieldValidator>
                        </div>
                        <!-- Pertanyaan 9 -->
                        <div class="form-group" id="Pertanyaan9">
                            <asp:Label ID="Label11" runat="server" Text="Apakah anda bersedia ditempatkan dimana saja sesuai dengan kebutuhan perusahaan? " Font-Bold="true"></asp:Label>
                            <asp:RadioButtonList ID="RadioButtonListPenempatan" RepeatDirection="Horizontal" runat="server" CellPadding="5">
                              <asp:ListItem>Ya</asp:ListItem>
                              <asp:ListItem>Tidak</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                runat="server" 
                                ErrorMessage="Penempatan Bekerja Wajib di Isi"
                                ControlToValidate="RadioButtonListPenempatan"
                                ForeColor="Red"
                                ></asp:RequiredFieldValidator>                        
                        </div>
                        <!-- Pertanyaan 10 -->
                        <div class="form-group" id="Pertanyaan10">
                            <asp:Label ID="Label12" runat="server" Text="Mengapa anda ingin bergabung dengan Honda Mugen?" Font-Bold="true"></asp:Label>
                            <textarea id="TxtAreaAlasanBergabung" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" 
                                runat="server" 
                                ErrorMessage="Alasan Bergabung Wajib di Isi"
                                ControlToValidate="TxtAreaAlasanBergabung"
                                ForeColor="Red"
                                ></asp:RequiredFieldValidator>   
                        </div>
                        <!-- Pertanyaan 11 -->
                        <div class="form-group" id="Pertanyaan11">
                            <asp:Label ID="Label13" runat="server" Text="Apa yang anda ketahui tentang Honda Mugen?" Font-Bold="true"></asp:Label>
                            <textarea id="TxtAreaPengetahuanHonda" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" 
                                runat="server" 
                                ErrorMessage="Pengetahuan terhadap Perusahaan Wajib di Isi"
                                ControlToValidate="TxtAreaPengetahuanHonda"
                                ForeColor="Red"
                                ></asp:RequiredFieldValidator>                          
                        </div>
                        <!-- Pertanyaan 12 -->
                        <div class="form-group" id="Pertanyaan12">
                            <asp:Label ID="Label14" runat="server" Text="Anda senang bekerja pada lingkungan?" Font-Bold="true"></asp:Label>
                            <asp:RadioButtonList ID="RadioButtonListLingkunganKerja" RepeatDirection="Horizontal" runat="server" CellPadding="5">
                              <asp:ListItem>Di Dalam Kantor</asp:ListItem>
                              <asp:ListItem>Di Luar Kantor</asp:ListItem>
                              <asp:ListItem>Di Dalam Bengkel</asp:ListItem>
                              <asp:ListItem>Lainya</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                                runat="server" 
                                ErrorMessage="Penempatan Bekerja Wajib di Isi"
                                ControlToValidate="RadioButtonListLingkunganKerja"
                                ForeColor="red"
                                ></asp:RequiredFieldValidator>  
                            <div id="textarealingkungankerja">
                                <textarea id="TextAreaLingkunganKerja" cols="20" rows="2" runat="server" class="form-control" autocomplete="off"></textarea>
                            </div>    
                        </div>
                        <div class="form-group"><!-- Button -->
                          <div class="col-sm-8">
                              <asp:Button ID="BtnSubmitPertanyaan" runat="server" Text="Simpan Data" class="btn btn-danger" OnClick="BtnSubmitPertanyaan_Click"  />
                          </div>                        
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
