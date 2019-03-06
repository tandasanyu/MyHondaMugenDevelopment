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
body {
    font-family: "Lato", sans-serif;
}



.main-head{
    height: 150px;
    background: #FFF;
   
}

.sidenav {
    height: 100%;
    background-color: dimgrey;
    overflow-x: hidden;
    padding-top: 100px;
}


.main {
    padding: 0px 10px;
}

@media screen and (max-height: 450px) {
    .sidenav {padding-top: 15px;}
}

@media screen and (max-width: 450px) {
    .login-form{
        margin-top: 10%;
    }

    .register-form{
        margin-top: 10%;
    }
}

@media screen and (min-width: 768px){
    .main{
        margin-left: 40%; 
    }

    .sidenav{
        width: 40%;
        position: fixed;
        z-index: 1;
        top: 0;
        left: 0;
    }

    .login-form{
        margin-top: 50%;
    }

    .register-form{
        margin-top: 20%;
    }
}


.login-main-text{
    margin-top: 20%;
    padding: 60px;
    color: #fff;
}

.login-main-text h2{
    font-weight: 300;
}

.btn-black{
    background-color: red !important;
    color: #fff;
}

</style>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      <div class="sidenav">
         <div class="login-main-text">
            <h2>Honda Mugen<br/> Login Page</h2>
            <p>Silahkan Login untuk akses Menu</p>
         </div>
      </div>
      <div class="main">
         <div class="col-md-6 ">
            <div class="login-form">
                  <div class="form-group">
                    <img src="img/logo2.png" /><br /><br />
                     <label>User Name</label>
                            <asp:TextBox ID="TxtUsername" class="form-control" runat="server"></asp:TextBox>
                     <%--<input type="text" class="form-control" placeholder="User Name">--%>
                  </div>
                  <div class="form-group">
                     <label>Password</label>
                            <asp:TextBox ID="TxtPswd" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                    <%-- <input type="password" class="form-control" placeholder="Password">--%>
                  </div>
                    <asp:Button ID="BtnLogin"  class="btn btn-black" runat="server" Text="Login" OnClick="BtnLogin_Click" />
            </div>
         </div>
      </div>
    </form>
</body>
</html>
