<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Honda Mugen :: Login</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
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
        body 
        {
        	background: #ccc;
            background-size: cover;
        }
       
        .boxlogin
        {
            position:relative;
            width: 300px;
            height:auto;
            margin: 0 auto;
            font-family:Verdana;
        }
    
        .boxlogin2
        {
            position:relative;
            width: 300PX;
            height:10%;
            top: 40px;
            margin: 0 auto;
            background: rgba(0,0,0,0.3);
            font-family:Rockwell;
        }
    
        .textnya 
        {
            position:relative;
            width: 300px;
            height:auto;
            margin: 0 auto;
            top:30px;
            font-family:Verdana;
        }
    </style>
    <script type="text/javascript">
        function showTime() {
            var a_p = "";
            var today = new Date();
            var curr_hour = today.getHours();
            var curr_minute = today.getMinutes();
            var curr_second = today.getSeconds();
            if (curr_hour < 12) {
                a_p = "AM";
            } else {
                a_p = "PM";
            }
            if (curr_hour == 0) {
                curr_hour = 12;
            }
            if (curr_hour > 12) {
                curr_hour = curr_hour - 12;
            }
            curr_hour = checkTime(curr_hour);
            curr_minute = checkTime(curr_minute);
            curr_second = checkTime(curr_second);
            document.getElementById('time').innerHTML=curr_hour + ":" + curr_minute + ":" + curr_second + " " + a_p;
        }
             
        function checkTime(i) {
            if (i < 10) {
                i = "0" + i;
            }
                return i;
        }
        setInterval(showTime, 500);         
    </script>

</head>
<body>
    <form id="form1" runat="server">

	<!-- Wrapper for slides -->
    <div class="textnya">
        <center><img src="img/hlogo.png" style="width:80px;height:70px;padding:0px;margin:0px;"/></center>
        <span style="position:relative;color:#333;font-family:Verdana;"><h3><center>Honda Mugen <small> | Login Akses</small></center></h3></span>
    </div>
   
	<div class="boxlogin">
		<div class="wraptengah" style="border-bottom:2px solid #d60000;top:30px;height:auto;position:relative;box-shadow:0px 3px 3px #c0c0c0;background:#f5f5f5;padding:10px;border-radius:4px;-moz-border-radius:4px;-webkit-border-radius:4px;-o-border-radius:4px;">
            <span style="margin:0 auto;color:#888;font-size:8pt;"><span class="glyphicon glyphicon-info-sign"></span> Silahkan masuk dengan akun anda.</span>
            <div class="input-group" style="width:100%;">
				<div class="input-group-addon" Style="background: linear-gradient(#f5f5f5, #ccc);">
					<span class="glyphicon glyphicon-user"></span>
				</div>
				<asp:TextBox ID="txtUserName" class="form-control input-sm" runat="server" Style="color:#333;font-weight:bold;" placeholder="Username" onkeyup="upper(this)"></asp:TextBox>
			    
            </div>
			
			<div class="input-group" style="width:100%;margin-top:5px;">
				<div class="input-group-addon" Style="background: linear-gradient(#f5f5f5, #ccc);">
					<span class="glyphicon glyphicon-lock"></span>
				</div>
				<asp:TextBox ID="txtUserPass" runat="server" TextMode="Password" Style="color:#333;font-weight:bold;" class="form-control input-sm" placeholder="Password"></asp:TextBox>
                <ASP:RequiredFieldValidator ControlToValidate="txtUserPass" Display="Static" runat="server" ID="vUserPass" />
			</div>	
			
			<div class="input-group" style="width:100%;margin-top:5px;">
				<ASP:CheckBox id="CheckBox1" runat="server" autopostback="false" />
                Persistent Cookie
			</div>	
			<asp:Button ID="cmdLogin" runat="server" style="margin:5px;font-weight:bold;font-family:Tahoma;" class="btn btn-success btn-sm" Text="MASUK"  />
            <asp:Label ID="LblError" runat="server" Font-Italic="True" Font-Size="Small" Font-Strikeout="False" ForeColor="Red"></asp:Label>
            <span style="position:relative;margin-bottom:25px;color:#a0a0a0;font-size:10pt;"><u>Lupa password</u> ? Hubungi IT</span>
		</div>	
    </div>
	<div class="boxlogin2" style="color:#f5f5f5;font-size:1.3em;">
		<span class="glyphicon glyphicon-calendar" style="margin:5px;"></span> <span id="date" style="margin:5px;"></span><br /> <span class="glyphicon glyphicon-time" style="margin:5px;"></span> <span id="time" style="margin:5px;"></span>
	</div>
	<script>
		var months = ['Januari', 'Februari', 'Maret', 'April', 'Mei', 'Juni', 'Juli', 'Agustus', 'September', 'Oktober', 'November', 'Desember'];
		var hari = ['Mingggu', 'Senin', 'Selasa', 'Rabu', 'Kamis', 'Jumat', 'Sabtu'];
		var date = new Date();
		var day = date.getDate();
		var month = date.getMonth();
		var year = date.getFullYear();
		var hariini = date.getDay();
		document.getElementById("date").innerHTML =" " + hari[hariini] + ", "+ day + " " + months[month] + " " + year;
	</script>
    </form>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
