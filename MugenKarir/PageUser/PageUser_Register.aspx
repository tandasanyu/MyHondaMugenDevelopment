<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageUser_Register.aspx.cs" Inherits="PagesUser_PageUser_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Daftar Akun</title>
<style>
#rcorners4 {
  border-radius: 15px;
  background: #cacaca;
  padding: 20px; 
  width: 600px;
  height: 800px; 
} 
#container2 {
width: 960px; 
position: relative;
margin:0 auto;
line-height: 1.4em;
}

@media only screen and (max-width: 479px){
    #container2 { width: 90%; }
}
</style>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container2">
            <div id="rcorners4" style="margin-left:20%;margin-top:1%;margin-bottom:1%">
                <div style="margin-left:33%;">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Untitled-1 copy.png" Width="200px" Height="200px" />
                </div>
                <div style="margin-left:5%;margin-bottom:1%">
                    <asp:Label ID="Label6" class="display-4" runat="server" Text="Form Pendaftaran Akun Lamaran Kerja" Font-Size="XX-Large"></asp:Label>
                </div>
                <table style="width: 100%;">

                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Posisi : "></asp:Label></td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtPosisi" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                runat="server" 
                                ErrorMessage="Posisi Tidak Boleh Kosong"
                                ForeColor="Red"
                                ControlToValidate="TxtPosisi"
                                ></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="Nama Lengkap : "></asp:Label></td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtNama" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                runat="server" 
                                ErrorMessage="Nama Wajib di Isi"
                                ForeColor="Red"
                                ControlToValidate="TxtNama"
                                ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                runat="server" 
                                ErrorMessage="Nama Hanya boleh Huruf."
                                ForeColor="Red"
                                ControlToValidate="TxtNama"
                                ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
                                ></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Username : "></asp:Label></td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtUsername" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                runat="server" 
                                ErrorMessage="Username Wajib Di Isi"
                                ForeColor="Red"
                                ControlToValidate="TxtUsername"
                                ></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label4" runat="server" Text="Password : "></asp:Label></td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtPswd" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                                runat="server" 
                                ErrorMessage="Password Wajib di Isi"
                                ForeColor="Red"
                                ControlToValidate="TxtPswd"
                                ></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label5" runat="server" Text="Email : "></asp:Label></td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtEmail" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                                runat="server" 
                                ErrorMessage="Email Wajib di Isi"
                                ForeColor="Red"
                                ControlToValidate="TxtEmail"
                                ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                runat="server" 
                                ErrorMessage="Format Email Salah"
                                ForeColor="Red"
                                ControlToValidate="TxtEmail"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                ></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <br />
                            <asp:Button ID="BtnDaftar"  runat="server" Text="Simpan" class="btn btn-danger"/></td>
                    </tr>
                </table>
            </div>
        </div>

    </form>
</body>
</html>
