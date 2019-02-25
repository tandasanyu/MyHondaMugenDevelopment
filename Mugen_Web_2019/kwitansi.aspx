<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kwitansi.aspx.cs" Inherits="kwitansi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Honda Mugen - Kwitansi</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
     <link href="css/datepicker.css" rel="stylesheet" />
       <script type="text/javascript">
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
</head>
<body>
    <form id="form1" runat="server">
    <div id="input" runat="server">
        <center><span class="bg-success" style="padding:10px;">Kwitansi System</span></center>
    <table class="table" style="width:50%;margin:0 auto;">
        <tr><td>Nomor</td><td><asp:TextBox ID="txtNomor" class="form-control input-sm" Style="width:200px;font-weight:bold;color:blue;" onkeyup="upper(this)" runat="server"></asp:TextBox></td></tr>
        <tr><td>Terima dari</td><td><asp:TextBox ID="txtTerima" class="form-control input-sm" Style="font-weight:bold;color:#666;" onkeyup="upper(this)" runat="server"></asp:TextBox></td></tr>
        <tr><td>Untuk pembayaran</td><td><asp:TextBox ID="txtUntuk" class="form-control input-sm" Style="font-weight:bold;color:#666;" onkeyup="upper(this)" runat="server"></asp:TextBox></td></tr>
        <tr><td>Jumlah</td><td><asp:TextBox ID="txtJumlah" class="form-control input-sm" Style="font-weight:bold;color:#666;" value="Rp. " runat="server"></asp:TextBox></td></tr>
        <tr><td>Terbilang</td><td><asp:TextBox ID="txtTerbilang" class="form-control input-sm" Style="font-weight:bold;color:#666;" onkeyup="upper(this)" runat="server"></asp:TextBox></td></tr>
         <tr><center><td colspan="2"><asp:Button ID="Button1" CssClass="btn-sm btn-primary" runat="server" Text="Submit" OnClick="Button1_Click" /></td></center></tr>
         </table>
    </div>
        <div id="hasil" runat="server">
              <div class="header" style="width:100%;margin:0 auto;height:auto;">

                <div class="atas" style="width:97%;margin:5px auto;height:100px;position:relative;border-bottom:2px solid #c0c0c0;">
                    <div class="kirih" style="float:left;height:80px;font-size:10pt;font-family:Verdana;position:relative;top:0px;width:9%;">
                        <img src="img/hlogo.png" style="width:100%;height:75px;" />
                    </div>
                    <div class="kirih" style="left:1%;float:left;height:80px;font-size:0.85em;font-family:Verdana;position:relative;top:0px;width:56%;">
                        <span style="font-weight:bold;">Honda Mugen</span><br />
                        <span>PT. Mitrausaha Gentaniaga</span><br />
                        <span>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia</span><br />
                        <span>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)</span><br />
                        <span>Fax : (021) 797 3834, 798 4735</span><br />
                        <span>Website : www.hondamugen.co.id</span>
                    </div><!-- div baris atas kiri -->
                     <div class="kirih2" style="left:1%;top:10px;float:right;height:80px;font-size:1.85em;color:#666;font-family;:Verdana;position:relative;top:0px;width:16%;">
                        <span style="position:relative;bottom:-50px;font-weight:bold;">KWITANSI</span><br />
                    </div>
                </div><!-- div baris atas -->
        
            </div>
            <div class="isi" style="float:left;padding:0px;width:100%;margin:18px;font-family:Verdana;">
                <table>
                    <tr>
                        <td style="width:150px;">Nomor</td>
                        <td style="width:15px;">:</td>
                        <td><asp:Label ID="lblNoKw" runat="server" style="font-weight:bold;" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Terima dari</td>
                        <td>:</td>
                        <td><asp:Label ID="lblTerimaKw" runat="server" style="font-weight:bold;" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top;">Untuk pembayaran</td>
                        <td style="vertical-align:top;">:</td>
                        <td><asp:Label ID="lblUntukKw" runat="server" Style="font-size:8pt;" Text="Label"></asp:Label></td>
                    </tr>
                      <tr>
                        <td style="vertical-align:bottom;height:50px;">Terbilang</td>
                        <td style="vertical-align:bottom;height:50px;">:</td>
                        <td style="vertical-align:bottom;height:50px;"><asp:Label ID="lblTerbilangKw" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>
                </div>
             <div class="isi" style="float:left;font-weight:bold;font-size:10pt;padding:0px;width:20%;padding:2px;margin:0px 0px 0px 18px;font-family:Verdana;border:1px solid #555;">
                <table>
                    <tr>
                        <td><asp:Label ID="lblJumlahKw" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>
                </div>
              <div class="isi" style="float:right;font-size:9pt;padding:0px;width:40%;padding:2px;margin:18px 0px 0px 18px;font-family:Verdana;">
                <table style="float:right;text-align:right;margin-right:18px;">
                    <tr>
                        <td style="text-align:right;">Jakarta, 16 Agustus 2016</td>
                    </tr>
                     <tr>
                        <td style="text-align:right;">&nbsp; </td>
                    </tr>
                     <tr>
                        <td style="text-align:right;">&nbsp; </td>
                    </tr>
                     <tr>
                        <td style="text-align:right;">&nbsp; </td>
                    </tr>
                     <tr>
                        <td style="text-align:right;font-size:12pt;"><u><center>Fredian Yudianto</center></u></td>
                    </tr>
                     <tr>
                        <td style="text-align:right;font-size:8pt;"><center>Finance & Accounting Manager</center></td>
                    </tr>
                </table>
                </div>
            <div class="isi" style="float:left;font-size:9pt;padding:0px;width:100%;padding:2px;margin:5px 0px 0px 18px;font-family:Verdana;border-top:3px double #c0c0c0;;border-bottom:2px solid #c0c0c0;">
                <table>
                    <tr>
                        <td><u style="font-weight:bold;">Note:</u> <br />Pembayaran dgn Cek/Giro wajib mencantumkan Atas nama PT. MITRAUSAHA GENTANIAGA Bank BCA LINDETEVES No. Rekening 645-005-1-711</td>
                    </tr>
                </table>
                </div>
            </div>
            </div>
    </form>
</body>
</html>
