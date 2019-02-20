<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style> 
#rcorners2 {
  border-radius: 25px;
  border: 2px solid #ff0000;
  padding: 20px; 
  width: 300px;
  height: 500px;  
}


</style>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:37%; margin-top:5%" >
        <div id="rcorners2">
            <div style="margin-left:25%" >
                <table>
                    <tr>
                        <td class="col-sm-4">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/cropped-honda-icon.png" Height="100px" Width="100px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="col-sm-4">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/img/honda-3-logo-png-transparent.png" Height="100px" Width="100px" />
                        </td>
                    </tr>
                </table>             
            </div>
           
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Username" class="display-8" runat="server" Text="Username:"></asp:Label></td>
                    <td>
                        <br />
                        <asp:TextBox ID="TxtUsername"  class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        runat="server" 
                        ErrorMessage="Username Wajib Di Isi"
                        ControlToValidate="TxtUsername"
                        ForeColor="Red"
                        ></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>

                        <asp:Label ID="Password" class="display-8" runat="server" Text="Password:"></asp:Label></td>
                    <td>
                        <br />
                        <asp:TextBox ID="TxtPas"  class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                        runat="server" 
                        ErrorMessage="Password Wajib di Isi"
                        ControlToValidate="TxtPas"
                            ForeColor="Red"
                        ></asp:RequiredFieldValidator>
                    </td>
               
                     </tr>
                <tr>
                    <td>
                    <br />
                        <asp:Button ID="BtnLoginHRD" class="btn btn-danger" runat="server" Text="Login" /></td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
