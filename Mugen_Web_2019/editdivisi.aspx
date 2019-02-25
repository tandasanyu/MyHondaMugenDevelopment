<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="editdivisi.aspx.cs" Inherits="Default2" %>

<asp:Content ID="headBeranda" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Honda Mugen :: Divisi</title>
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
         tr.pager-row td
    {
        border-top:solid 2px #bbd9ee;
    }
    .pager
    {
        font-family:arial,sans-serif;
        text-align:center;
        padding:6px;
        font-size:18px;
    }
    .pager span.command,
    .pager span.current,
    .pager a.command,
    tr.pager-row td a
    {
        color:#5a90ce;
        padding:0px 5px;
        text-decoration:none;
        border:none;
    }
    .pager a.command:hover,
    tr.pager-row td a:hover
    {
        border:solid 2px #408BB6;
        background-color:#59A5D1;
        color:#fff;
        padding:0px 3px;
        text-decoration:none;
    }
    .pager span.current,
    tr.pager-row td span
    {
	    border:none;
        font-weight:bold;
        color:#3e3e3e;
        padding:0px 6px;
    }
    tr.pager-row td
    {
	    border-top:none;
	    text-align:center;
    }
     tr.pager-row table
    {
	    height:35px;
	    margin:0 auto 0 auto;
    }
  </style>
</asp:Content>
 <asp:Content ID="bodySesuaiHalaman" ContentPlaceHolderID="body" Runat="Server"> 
    <form id="form1" runat="server">

     <div class="container-fluid">
     <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
  <li><a href="#"><span class="glyphicon glyphicon-folder-open"></span>&nbsp;&nbsp;Database</a></li>
  <li><a href="divisi.aspx"><span class="glyphicon glyphicon-eye-open"></span>&nbsp;&nbsp;Divisi</a></li>
  <li><span class="glyphicon glyphicon-edit"></span>&nbsp;&nbsp;Edit Divisi</li>
</ol>
<div class="panel panel-primary" style="width:25%;margin:5px auto;">
  <div class="panel-heading"><span class="glyphicon glyphicon-plus-sign"></span> Edit data divisi</div>
  <div class="panel-body">
      <asp:Label ID="Label2" runat="server" Text="Kode Divisi :" style="margin:5px;font-family:Tahoma;font-size:10pt;"></asp:Label>
  <asp:TextBox ID="txtKode" class="form-control" style="margin:5px;" placeholder="Nama Divisi" onkeyup="upper(this)" runat="server" ReadOnly="TRUE"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Nama Divisi Sebelumnya:" style="margin:5px;font-family:Tahoma;font-size:10pt;"></asp:Label><br />
        <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Blue" 
          style="margin:5px;" Font-Italic="True"></asp:Label><br />
         <asp:Label ID="Label6" runat="server" Text="Nama Divisi Baru :" style="margin:5px;font-family:Tahoma;font-size:10pt;"></asp:Label><br />
        <asp:TextBox ID="txtNama" class="form-control" style="margin:5px;" placeholder="Nama Divisi Baru" onkeyup="upper(this)" runat="server"></asp:TextBox>
       <asp:Label ID="Label4" runat="server" Text="** Kode divisi tidak dapat diubah" style="margin:2px;font-size:8pt;color:#d60000;"></asp:Label>
      <center><asp:Button ID="Button1" runat="server" Text="SUBMIT" 
              class="btn btn-primary btn-sm" onclick="Button1_Click"/></center>
           <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Small" 
          ForeColor="Red"></asp:Label>
  </div>
</div>
       
    </div>
    <script src="js/jquery.min.js"></script>
     <script src="js/bootstrap.min.js"></script>
          
    </form> 
  </asp:Content>
