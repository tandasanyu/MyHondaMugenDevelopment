<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" ValidateRequest="false" Debug="true" CodeFile="WAREHOUSEPERMINTAANOUTPUT.aspx.vb" Inherits="WAREHOUSEPERMINTAANOUTPUT" title="Dokumen System Development/Fault Request" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
	<style type="text/css">
        .table-borderless > tbody > tr > td,
        .table-borderless > tbody > tr > th,
        .table-borderless > tfoot > tr > td,
        .table-borderless > tfoot > tr > th,
        .table-borderless > thead > tr > td,
        .table-borderless > thead > tr > th {
            border: none;
        }
    </style>    
    

    <asp:Label ID="LblUserName" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblAkses" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea1" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea2" Style="display:none" runat="server"></asp:Label>
  
    <div class="container">
        <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
            <asp:View ID="Viewerr00" runat="server">
                <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" ForeColor="Red" height="23px" Width="959px">Judul Permohonan</asp:Label>
            </asp:View> 
        </asp:MultiView>

        <asp:MultiView ID="MultiViewDetailPermintaan" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
                <br /><br />
                 <div class="container">
                    <table>
			            <tr>
				            <td align="left"><img src="img/hlogo.png" width="100" height="75" alt="" /></td>
				             <td style="width:300px"></td>
                            <td align="center"><h2 style="font-family:Arial Bold;"> PERMINTAAN UNIT <br>
					            UNTUK <asp:Label ID="jnsEvent1" runat="server" Text="Label" style="text-transform: uppercase;"></asp:Label><br/></h2>
					           <h4>012-FRM-WHS R.0</h4><br/></td>
			            </tr>
		            </table><br/>
	                <br />
                    <table>
                        <tr>
                            <td>Kepada Yth</td>
                            <td>&nbsp : &nbsp </td>
                            <td>Dept. Warehouse</td>
                        </tr>
                        <tr>
                            <td>Dari</td>
                            <td>&nbsp : &nbsp </td>
                            <td>Dept. Sales</td>
                        </tr>
                    </table><br />

                    Tolong disiapkan unit mobil untuk <asp:Label ID="jnsEvent2" runat="server" Text="Label"></asp:Label> dengan spesifikasi sebagai berikut: <br />
                    <table border="1" width="100%">
                        <tr style="height:30px">
                            <td class="col-md-6"><b>Tanggal <asp:Label ID="jnsEvent3" runat="server" Text="Label"></asp:Label></b></td>
                            <td class="col-md-6"><asp:Label ID="txt_TglEvent" runat="server" style="text-transform: uppercase;"></asp:Label></td>
                        </tr>
                        <tr style="height:30px">
                            <td class="col-md-6"><b>Lokasi <asp:Label ID="jnsEvent4" runat="server" Text="Label"></asp:Label></b></td>
                            <td class="col-md-6"><asp:Label ID="Txt_LokasiEvent" runat="server" style="text-transform: uppercase;"></asp:Label></td>
                        </tr>
                        <tr style="height:30px">
                            <td class="col-md-6"><b>Penanggung Jawab <asp:Label ID="jnsEvent5" runat="server"></asp:Label></b></td>
                            <td class="col-md-6"><asp:Label ID="Txt_PenanggungJawab" runat="server" style="text-transform: uppercase;"></asp:Label></td>
                        </tr>    
                        <tr style="height:30px">
                            <td class="col-md-6"><b>Perkiraan Tanggal Pengembalian Unit</b></td>
                            <td class="col-md-6"><asp:Label ID="txt_TglKembali" runat="server" style="text-transform: uppercase;"></asp:Label></td>
                        </tr> 
                        <tr style="height:30px">
                            <td class="col-md-6"><b>Type Mobil</b></td>
                            <td class="col-md-6"><asp:Label ID="txt_TipeMobil" runat="server" style="text-transform: uppercase;"></asp:Label><asp:Label ID="txt_JnsMobil" runat="server" style="text-transform: uppercase;"></asp:Label></td>
                        </tr>    
                        <tr style="height:30px">
                            <td class="col-md-6"><b>Warna Mobil</b></td>
                            <td class="col-md-6"><asp:Label ID="DropDownList3" runat="server" style="text-transform: uppercase;"></asp:Label></td>
                        </tr>  
                        <tr style="height:30px">
                            <td class="col-md-6"><b>No. Rangka</b></td>
                            <td class="col-md-6"><asp:Label ID="txt_NoRangka" runat="server" style="text-transform: uppercase;"></asp:Label></td>
                        </tr> 
                        <tr style="height:30px">
                            <td class="col-md-6"><b>No. Mesin</b></td>
                            <td class="col-md-6"><asp:Label ID="txt_NoMesin" runat="server" style="text-transform: uppercase;"></asp:Label></td>
                        </tr> 
                        <tr style="height:30px">
                            <td class="col-md-6"><b>Tanggal Serah Terima Unit</b></td>
                            <td class="col-md-6"><asp:Label ID="txt_TglTerimaUnit" runat="server" style="text-transform: uppercase;"></asp:Label>
                                <asp:Label ID="no" runat="server" style="display: none;"></asp:Label>
                            </td>
                        </tr> 
                    </table> <br /><br />
                   
                    <table style="width:100%;margin:8px;margin-left:-50px; text-align:center;font-family:Verdana;color:#333;">
                        <tr>
                            <th style="text-align:center;">Dibuat Oleh</th>
                            <th style="text-align:center;">Disetujui Oleh</th>
                        </tr>
                        <tr>
                             <td><br /></td>
                             <td><br /></td>
                        </tr>
                        <tr>
                             <td></td>
                             <td><asp:Label ID="lblAppDiketahui" visible="false" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);opacity: 0.3;"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><br /></td>
                            <td><br /></td>
                        </tr>
                        <tr>
                            <td><u><asp:Label ID="lblNamaDibuat" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaDiketahui" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                        </tr>
                        <tr>
                            <td style="font-size:9pt;color:Blue;">(SPV. Sales)</td>
                            <td style="font-size:9pt;color:Blue;">(Sales Manager)</td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblTglDibuat" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                            <td><asp:Label ID="lblTglDiketahui" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                        </tr>
                    </table><br />
                    <center><asp:Button ID="BtnNilaiSMSave" runat="server" Text="Approve Permintaan" visible="false" class="btn btn-success" /></center>  
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>

