<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" ValidateRequest="false" Debug="true" CodeFile="ITLOGINOUTPUT.aspx.vb" Inherits="ITLOGINOUTPUT" title="DATA USER LOGIN SISTEM/EMAIL" %>
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

        <asp:MultiView ID="MultiViewDetailSDR" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
                <br /><br />
                 <div class="container">
                    <center>
                        <h3>PT. MITRAUSAHA GENTANIAGA<br /><br />
                            FORM USER LOGIN SISTEM/EMAIL <br />
                            SYSTEM INFORMASI SHOWROOM & SERVICE
                        </h3>
                        <h5>004-FRM-IT.R1</h5>
                    </center>
	                <br />

                    <table>
                        <tr style="height:30px">
                            <td>Nomor</td>
                            <td>&nbsp : &nbsp</td>
                            <td><asp:Label ID="no" runat="server" style="text-transform: uppercase;"></asp:Label></td>
                        </tr>
                        <tr style="height:30px">
                            <td>Status</td>
                            <td>&nbsp : &nbsp</td>
                            <td><asp:CheckBox ID="StatusA1" runat="server" Enabled="false"/> Tambah(Baru)</td>
                            <td style="width:25px"></td>
                            <td><asp:CheckBox ID="StatusA2" runat="server" Enabled="false"/> Rubah</td>
                            <td style="width:25px"></td>
                            <td><asp:CheckBox ID="StatusA3" runat="server" Enabled="false"/> Hapus</td>   
                        </tr>
                        <tr style="height:30px">
                            <td>Nama User</td>
                            <td>&nbsp : &nbsp</td>
                            <td><asp:Label ID="nmUser" runat="server" style="text-transform: uppercase;"></asp:Label></td>
                        </tr>
                        <tr style="height:30px">
                            <td>Waktu</td>
                            <td>&nbsp : &nbsp</td>
                            <td><asp:CheckBox ID="JWaktu1" runat="server" Enabled="false"/> Selamanya (Permanen)</td>
                            <td style="width:100px"></td>
                            <td><asp:CheckBox ID="JWaktu2" runat="server" Enabled="false"/> Dari tgl  <asp:Label ID="tgl1" runat="server" Text="....."></asp:Label> s/d tgl <asp:Label ID="tgl2" runat="server" Text="....."></asp:Label></td>
                        </tr>   
                        <tr style="height:30px">
                            <td>Tipe</td>
                            <td>&nbsp : &nbsp</td>
                            <td><asp:CheckBox ID="Jenis1" runat="server" Enabled="false"/> Login Sistem</td>
                            <td style="width:100px"></td>
                            <td><asp:CheckBox ID="Jenis2" runat="server" Enabled="false"/> Login Email</td>
                        </tr> 
                        <tr style="height:30px">
                            <td>Keterangan</td>
                            <td>&nbsp : &nbsp</td>
                        </tr>       
                    </table>
                            
                    <div class="well">     
                        <div class="container">
                            <asp:Label ID="tujuan" runat="server"></asp:Label>
                        </div>
                    </div>     
                     
                    <div class="well">     
                        <div class="container">
                            <b>Sudah dilakukan pengujian pada:</b><br />
                            <table>
                                <tr>
                                    <td>Tanggal :</td>
                                    <td><asp:Label ID="tglUji" runat="server"></asp:Label></td>
                                    <td style="width:450px"></td>
                                    <td>Status </td>
                                    <td>&nbsp : &nbsp</td>
                                    <td><asp:CheckBox ID="status1" runat="server" Enabled="false"/> Puas</td>
                                    <td style="width:25px"></td>
                                    <td><asp:CheckBox ID="status2" runat="server" Enabled="false"/> Tidak Puas</td>
                                </tr>
                            </table>
                            <br />Keterangan: <br />
                            <asp:Label ID="keterangan" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div> <br />
                     
                    <table style="width:100%;margin:8px;margin-left:-50px; text-align:center;font-family:Verdana;color:#333;">
                        <tr>
                            <th style="text-align:center;">Pemohon</th>
                            <th style="text-align:center;">Diketahui</th>
                            <th style="text-align:center;">Disetujui</th>
                            <th style="text-align:center;">Disetujui sudah diuji</th>
                       </tr>
                       <tr>
                             <td><br /></td>
                             <td><br /></td>
                             <td><br /></td>
                             <td><br /></td>
                       </tr>
                       <tr>
                             <td><br /></td>
                             <td><asp:Label ID="lblAppDiketahui" visible="false" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);-o-transform: rotate(-20deg);opacity: 0.3; "></asp:Label></td>
                             <td><asp:Label ID="lblAppDisetujui" visible="false" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);opacity: 0.3;"></asp:Label></td>
                             <td><asp:Label ID="lblAppDiuji" visible="false" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);opacity: 0.3;"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><br /></td>
                            <td><br /></td>
                            <td><br /></td>
                            <td><br /></td>
                        </tr>
                        <tr>
                            <td><u><asp:Label ID="lblNamaPemohon" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaDiketahui" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaDisetujui" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaDiuji" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="font-size:9pt;color:Blue;">(Head Department)</td>
                            <td style="font-size:9pt;color:Blue;">(IT Head Department)</td>
                            <td style="font-size:9pt;color:Blue;"></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblTglPemohon" runat="server" Text="" style="font-size:8pt;margin:0;color:#666"></asp:Label></td>
                            <td><asp:Label ID="lblTglDiketahui" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                            <td><asp:Label ID="lblTglDisetujui" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                            <td><asp:Label ID="lblTglDiuji" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                        </tr>

                        <tr style="height:60px">
                            <td><b>Tanggal perkiraan selesai:</b> <asp:Label ID="tglEstimasi" runat="server"></asp:Label></td>
                        </tr>
                    </table><br />
                    <center><asp:Button ID="BtnNilaiSMSave" runat="server" Text="Approve Permintaan Login System" visible="false" class="btn btn-success" /></center>  
                </div>
            </asp:View>
        </asp:MultiView>

        <!-- Approval Disetujui Form Login -->
        <asp:MultiView ID="MultiViewDisetujuiSDR" runat="server" Visible="TRUE">
            <asp:View ID="View7" runat="server">
                <br />
                 <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Head IT Approval Login System</font></div>
                        <div class="panel-body">
                            <center>
                                <h3 style="font-family:Georgia;">HEAD IT APPROVAL LOGIN SYSTEM</h3>
                            </center>
	                        <br />
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label13" runat="server" Text="Tanggal Estimasi selesai"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:TextBox ID="TxtSDREstimasiTgl" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"/>
                                        <asp:Button ID="Button4"  Text="..."  runat="server" CausesValidation="False" class="btn btn-default" />
                    
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server"
                                        TargetControlID="TxtSDREstimasiTgl" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator4" runat="server"
                                        ControlExtender="MaskedEditExtender4" ControlToValidate="TxtSDREstimasiTgl" EmptyValueMessage="Date is required"
                                        InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                        EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TxtSDREstimasiTgl" PopupButtonID="Button4" />
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>
                
                            <center>
                                <asp:Label ID="LblErrorSaveC" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:Button ID="BtnNilaiSM2Save" runat="server" Text="Approve" class="btn btn-success" /> 
                            </center><br />
                        </div>
                    </div>
                </div>
                <br />
            </asp:View>
        </asp:MultiView>

        <!-- Approval Diujui Form Login -->

         <asp:MultiView ID="MultiViewDiujiSDR" runat="server" Visible="TRUE">
            <asp:View ID="View8" runat="server">
                <br /><br />
                 <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Test Approval Login System</font></div>
                        <div class="panel-body">
                            <center>
                                <h3 style="font-family:Georgia;">TEST APPROVAL LOGIN SYSTEM</h3>
                            </center>
	                        <br /><br />
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label18" runat="server" Text="Status"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="DropDownList3" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Puas</asp:ListItem>
                                            <asp:ListItem>Tidak Puas</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label19" runat="server" Text="Catatan"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtSDRCatatan" runat="server" MaxLength="200" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>
                
                            <center>
                                <asp:Label ID="Label21" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:Button ID="BtnNilaiSM3Save" runat="server" Text="Approve" class="btn btn-success" />  
                            </center>
                        </div>
                    </div>
                </div>
                <br />
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>

