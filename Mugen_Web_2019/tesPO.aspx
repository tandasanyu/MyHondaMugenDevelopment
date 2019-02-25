<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="tesPO.aspx.cs" Inherits="tesPO" Title="Untitled Page" %>


 
<asp:Content ID="headBeranda" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen :: Laporan PO</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
     <link href="css/datepicker.css" rel="stylesheet" />
</asp:Content>
 <asp:Content ID="bodySesuaiHalaman" ContentPlaceHolderID="body" Runat="Server"> 
 
        <form id="form1" runat="server">
   <div class="panel panel-primary" style="width:98%;margin:5px;">
  <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-list"></span> Laporan Purchase Order</div>
  <div class="panel-body">
  <table style="width:100%;">

<tr>
<td>Periode</td>
<td>:</td>
<td><asp:TextBox ID="txtAwal" runat="server" name="awal" data-provide="datepicker" class="form-control" style="width:150px;margin:5px;float:left;"></asp:TextBox><asp:TextBox ID="txtAkhir" runat="server" data-provide="datepicker" class="form-control" style="width:150px;margin:5px;float:left;"></asp:TextBox></td>
</tr>
<tr>
<td>Cabang</td>
<td>:</td>
<td>
    <asp:DropDownList ID="txtCabang" runat="server" class="form-control" style="margin:5px;">
        <asp:ListItem>
        </asp:ListItem>
        <asp:ListItem Value="112">Mugen Ps. Minggu</asp:ListItem>
        <asp:ListItem Value="128">Mugen Puri</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
<tr>
<td></td>
<td></td>
<td><asp:Button ID="btnSearch" runat="server" Text="Submit Laporan" OnClick="btnSearch_Click" class="btn btn-primary" style="margin:5px;font-weight:bold;font-size:9pt;font-family:Verdana;"/></td>
</tr>
<tr>
<td></td>
<td></td>
<td><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></td>
</tr>
</table>
<br />
  </form>

        </div>
</div>
         <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
  </asp:Content>
