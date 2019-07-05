<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
      
        .boxlog 
        {   
        	position:relative;
        	width:25%;
        	border:1ox solid #333;
        	margin: 0 auto;
        	top: 100px;
        	background:#f5f5f5;
        	padding: 5px;
        	box-shadow: 1px 1px 1px 1px #c0c0c0;
        	border-radius: 8px;
        }
        </style>

</head>
<body>
    <form id="form1" runat="server">

   <div class="boxlog">
    <h1 style="color: #FF0000; text-align:center; background-color: #f5f5f5;font-family:Arial;">LOGIN</h1>
    
    <table style="width:100%;"  >


    <tr>
           <td style="font-size:10pt;font-family: Arial; font-weight: bold;">
               Nama Pemakai : </td>
           <td class="style2">
           <asp:TextBox ID="txtUserName" runat="server" Width="170px"></asp:TextBox>
           <asp:RequiredFieldValidator ControlToValidate="txtUserName"
           Display="Static" ErrorMessage="*" runat="server" 
           ID="vUserName" />
           </td>
    </tr>
    <tr>
           <td style="font-size:10pt;font-family: Arial; font-weight: bold;">Kata Kunci : </td>
           <td class="style2">
                <asp:TextBox ID="txtUserPass" runat="server" TextMode="Password" Width="170px"></asp:TextBox>
                <ASP:RequiredFieldValidator ControlToValidate="txtUserPass"
                Display="Static" ErrorMessage="*" runat="server" ID="vUserPass" />
           </td>
    </tr>
    <tr>
           <td style="font-family: Arial; font-weight: bold;font-size:10pt;">Persistent Cookie:</td>
           <td class="style2">
           <ASP:CheckBox id="CheckBox1" runat="server" autopostback="false" />
           </td>
    </tr>
    <tr>
           <td class="style2"></td>
           <td class="style2">
               <asp:Label ID="LblError" runat="server" Font-Size="Medium"></asp:Label>
           </td>
    </tr>
    
    </table>
    <p style ="text-align:center" > 
    
    <asp:Button ID="cmdLogin" runat="server" Text="Logon" Width="100px" Height="43px"    />
        <br />
        <br />
    <asp:Label id="lblMsg" Text="Tekan Log in untuk masuk"  ForeColor="red" runat="server" />
    </p>
    </form>
    </div>
</body>
</html>
