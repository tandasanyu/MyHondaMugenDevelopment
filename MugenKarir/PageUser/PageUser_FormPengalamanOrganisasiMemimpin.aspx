<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageUser_FormPengalamanOrganisasiMemimpin.aspx.cs" Inherits="PageUser_PageUser_FormPengalamanOrganisasiMemimpin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form Organisasi dan Pengalaman Memimpin</title>
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
h2.FormOrganisasiMemimpin {
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
            //hide organisasi
            $("#Organisasi1").hide();
            $("#Organisasi2").hide();
            //hidememimpin
            $("#Memimpin1").hide();
            //Organisasi
            $('#RadioButtonListOrganisasi input').click(function () {
                var value = $("#RadioButtonListOrganisasi input:radio:checked").val();
                if (value == "1") {
                    $("#Organisasi1").show();
                    $("#Organisasi2").hide();
                }
                else if (value == "2") {
                    $("#Organisasi1").show();
                    $("#Organisasi2").show();
                }
                else if (value == "Tidak Ada") {
                    $("#Organisasi1").hide();
                    $("#Organisasi2").hide();
                }
            });
            //Memimpin
            $('#RadioButtonListMemimpin input').click(function () {
                var value = $("#RadioButtonListMemimpin input:radio:checked").val();
                if (value == "Tidak Ada") {
                    $("#Memimpin1").hide();
                }
                else if (value == "Ada") {
                    $("#Memimpin1").show();
                }
            });
        });        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom:100px">
            <div style="margin-left:1%">
                <h2 class="FormOrganisasiMemimpin">Form Organisasi dan Pengalaman Memimpin</h2>
                <br />
                <br />
                <div class="row">
                    <div class="col-lg-8">
                        <!-- Organisasi -->
                        <div class="form-group" id="Organisasi">
                          <asp:Label ID="Label4" runat="server" Text="Pilih Jumlah Pengalaman Organisasi Anda :" Font-Bold="true"></asp:Label>
                          <asp:RadioButtonList ID="RadioButtonListOrganisasi" RepeatDirection="Horizontal" runat="server" CellPadding="5">
                              <asp:ListItem>Tidak Ada</asp:ListItem>
                              <asp:ListItem>1</asp:ListItem>
                              <asp:ListItem>2</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                runat="server" 
                                ForeColor="red"
                                ErrorMessage="Pengalaman Organisasi Wajib Di Pilih"
                                ControlToValidate="RadioButtonListOrganisasi"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group" id="Organisasi1">
                            <asp:Label ID="Label3" runat="server" Text="Pengalaman Organisasi 1 :" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                    <tr>
                                        <th>Nama Organisasi</th>
                                        <th>Tahun</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>
                                            <asp:TextBox ID="TxtNamaOrganisasi1" class="form-control" runat="server" ></asp:TextBox>
                                        </th>
                                        <th>
                                            <asp:TextBox ID="TxtTahunOrganisasi1" class="form-control" runat="server" ></asp:TextBox>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group" id="Organisasi2">
                            <asp:Label ID="Label1" runat="server" Text="Pengalaman Organisasi 2 :" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <thead>
                                    <tr>
                                        <th>Nama Organisasi</th>
                                        <th>Tahun</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>
                                            <asp:TextBox ID="TxtNamaOrganisasi2" class="form-control" runat="server" ></asp:TextBox>
                                        </th>
                                        <th>
                                            <asp:TextBox ID="TxtTahunOrganisasi2" class="form-control" runat="server" ></asp:TextBox>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- Memimpin -->
                        <div class="form-group" id="Memimpin">
                          <asp:Label ID="Label2" runat="server" Text="Pilih Pengalaman Memimpin Anda :" Font-Bold="true"></asp:Label>
                          <asp:RadioButtonList ID="RadioButtonListMemimpin" RepeatDirection="Horizontal" runat="server" CellPadding="5">
                              <asp:ListItem>Ada</asp:ListItem>
                              <asp:ListItem>Tidak Ada</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                runat="server" 
                                ForeColor="red"
                                ErrorMessage="Pengalaman Memimpin Wajib Di Pilih"
                                ControlToValidate="RadioButtonListMemimpin"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group" id="Memimpin1">
                            <asp:Label ID="Label5" runat="server" Text="Pengalaman Memimpin :" Font-Bold="true"></asp:Label>
                            <table class="table table-bordered">
                                <tbody>
                                    <tr>
                                        <th>
                                            <asp:TextBox ID="TxtMemimpin1" class="form-control" runat="server" ></asp:TextBox>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>                        
                        </div>
                        <div class="form-group"><!-- Button -->
                          <div class="col-sm-8">
                              <asp:Button ID="BtnSubmitOrganisasiMemimpin" runat="server" Text="Simpan Data" class="btn btn-danger" OnClick="BtnSubmitOrganisasiMemimpin_Click"  />
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
