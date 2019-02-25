<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="chpass.aspx.cs" Inherits="chpass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen :: Approval Permintaan Pembelian</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
     <link href="css/datepicker.css" rel="stylesheet" />
    <script language=javascript>
    function upper(ustr)
    {
        var str=ustr.value;
        ustr.value=str.toUpperCase();
    }
   
function Angka(a)
{
	if(!/^[0-9.]+$/.test(a.value))
	{
	a.value = a.value.substring(0,a.value.length-1000);
	}
}
</script>
    <style>
    #popup {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}

.window 
{
position:relative;	
width: 90%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: center;
margin: 2% auto;
}

.close-button {
width: 20px;
height: 20px;
background: #000;
border-radius: 50%;
border: 3px solid #fff;
display: block;
text-align: center;
color: #fff;
text-decoration: none;
position: absolute;
top: -10px;
right: -10px;
}

#popup:target {
visibility: visible;
}

    #popup2 {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}

.window2 
{
position:relative;	
width: 90%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: center;
margin: 2% auto;
}

#popup2:target {
visibility: visible;
}

   #popup3 {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}

.window3 
{
position:relative;	
width: 90%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: center;
margin: 2% auto;
}

#popup3:target {
visibility: visible;
}
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
 
        <table class="table table-striped" style="border-radius:8px;padding:4px;width:500px;margin:10px auto;font-size:10pt;font-family:Verdana;">
            <tr>
                <th colspan="3" style="text-align:center;"><span class="glyphicon glyphicon-lock"></span>&nbsp;&nbsp;UBAH PASSWORD</th>
            </tr>
             <tr>
                <td>Username</td>
                <td>:</td>
                <td><asp:Label ID="lblUsername" runat="server" style="color:blue;font-weight:bold;" Text="U must be log in !"></asp:Label> <span style="font-size:8pt;color:#666;"><br /> <i class="glyphicon glyphicon-info-sign"></i> Username tidak dapat diganti</span></td>
            </tr>
            <tr>
                <td>Password lama</td>
                <td>:</td>
                <td><asp:TextBox ID="txtPassLama" runat="server" class="form-control input-sm" placeholder="Password lama" TextMode="Password"></asp:TextBox><asp:Label ID="lblPassLama" style="color:red;font-size:8pt;" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Password baru</td>
                <td>:</td>
                <td><asp:TextBox ID="txtPassBaru" runat="server" Style="color:#333;" class="form-control input-sm" placeholder="Password baru" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ulangi password</td>
                <td>:</td>
                <td><asp:TextBox ID="txtPassBaru2" runat="server" Style="color:#333;" class="form-control input-sm" placeholder="Ulang password baru" TextMode="Password"></asp:TextBox><asp:Label ID="lblPassBaru2" style="color:red;font-size:8pt;" runat="server" Text=""></asp:Label></td>
            </tr>
             <tr>
                <td></td>
                <td></td>
                <td><asp:Label ID="lblSukses" style="color:green;font-size:8pt;" runat="server" Text=""></asp:Label><br />
                    <asp:Button ID="btnChPass" CssClass="btn btn-primary btn-sm" runat="server" Text="Ubah Password" OnClick="btnChPass_Click" /></td>
            </tr>
        </table>
      <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
     </form>
</asp:Content>

