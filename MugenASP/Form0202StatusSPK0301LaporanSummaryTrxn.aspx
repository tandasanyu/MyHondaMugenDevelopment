<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"    AutoEventWireup="false" CodeFile="Form0202StatusSPK0301LaporanSummaryTrxn.aspx.vb" Inherits="Form0202StatusSPK0301LaporanSummaryTrxn" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div>
            <center>
                <h2 style="font-family:Cooper Black;">SERVICE</h2>
            </center>
	</div>  
    <center>
    <p   style ="font-size: small" > 
        &nbsp;User&nbsp; : 
        <asp:Label ID="LblUserName" runat="server"></asp:Label>
        <asp:Label ID="lblAkses" runat="server"></asp:Label>
        &nbsp; Akses &nbsp; : 
        <asp:Label ID="lblArea1" runat="server"></asp:Label>
        <asp:Label ID="lblArea2" runat="server"></asp:Label>
    </p>
    </center>

    <br />
    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
          
        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Error Message</asp:Label>
          
    </asp:View> 
    </asp:MultiView>


   <asp:MultiView ID="MultiViewSuport" runat="server" Visible="TRUE">
    <asp:View ID="View29" runat="server">
        <asp:Label ID="Label22" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px" Font-Bold="True" Font-Italic="True" 
        ForeColor="#0000A0">Pilih Lokasi Cabang Dealer Mugen</asp:Label>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
        <tr>
            <td style="width: 10%; ">
                <asp:Label ID="Label74" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Lokasi Dealer"></asp:Label>
            </td>
            <td style="width: 90%; ">
                <asp:DropDownList ID="DropDownListGroupTipe" runat="server">
                    <asp:ListItem>112</asp:ListItem>
                    <asp:ListItem>128</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
        <tr>
            <td style="width: 100%; ">
            <center>  <asp:Label ID="lblProsesBox" runat="server" Font-Bold="True" 
                Font-Names="Arial" Font-Size="Small" height="40px"  
                Width="99%" >Prosess</asp:Label></center>
            </td>
        </tr>
        </table>
        
                <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
        <tr>
            <td style="width: 10%; ">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Tampilkan"></asp:Label>
            </td>
            <td style="width: 90%; ">
                <asp:DropDownList ID="DropDownListGroupTipeReport" runat="server">
                    <asp:ListItem>Summary Keseluruhan</asp:ListItem>
                    <asp:ListItem>Summary Per-Sales Advisor</asp:ListItem>
                    <asp:ListItem>Summary Per-Mekanik</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        </table>
        <table style="width: 100%; height:inherit ; font-family: Arial; font-size: small; border-top-color: red; border-top-style: solid; border-top-width: thin; border-bottom-color: red; border-bottom-style: solid; border-bottom-width: thin; border-left-color: red; border-left-style: solid; border-left-width: thin; border-right-color: red; border-right-style: solid; border-right-width: thin;">
        <tr>
            <td style="width: 30%; ">
                <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Pencarian Dari Tanggal Input Unit / TTK"></asp:Label>
            </td>
            <td style="width: 30%; ">
                <asp:TextBox ID="txtTglStart" Enabled="true"   runat="server" />
                <asp:Button ID="BtnCal1Start" runat="server" Text=".." Width="27px" />
                <div id="tanggalPopup">
                <asp:Calendar ID="Calendar1" runat="server" onselectionchanged="Calendar1_SelectionChanged" />
                </div>
            </td>
            <td style="width: 10%; ">
                <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Sampai dengan"></asp:Label>
            </td>
            <td style="width: 30%; ">
                <asp:TextBox ID="txtTglEnd" Enabled="true"   runat="server" />
                <asp:Button ID="BtnCal1End" runat="server" Text=".." Width="27px" />
                <div id="Div1">
                <asp:Calendar ID="Calendar2" runat="server" onselectionchanged="Calendar2_SelectionChanged" />
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 30%; ">
            </td>
            <td style="width: 30%; ">
                <asp:Button ID="Button1" runat="server" Text="Tampilkan Dilayar" Width="80%" />
            </td>
            <td style="width: 10%; ">
            </td>
            <td style="width: 30%; ">
                <asp:Button ID="Button2" runat="server" Text="Tampilkan Excel" Width="80%" />
            </td>
        </tr>

        </table>

        
    </asp:View> 
    </asp:MultiView>


<br />
<br />
     
    <asp:MultiView ID="MultiViewForm" runat="server" Visible="TRUE">
        <asp:View ID="ViewForm0" runat="server">
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Summary Penerimaan Service</h2>
            </center>
	    </div>  
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 16%; Background-color:#CCCCFF;">
                   <asp:Label ID="Label25" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Keterangan"></asp:Label>
                </td>
                <td style="width: 14%; Background-color:#CCCCFF;">
                   <asp:Label ID="Label26" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Jumlah WO"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label41" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Jumlah Faktur"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label42" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Total Faktur Jasa DPP"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label43" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Total Faktur Jasa Disc"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label29" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Total Faktur Jasa"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label28" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Total Faktur Parts"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 16%; ">
                    <asp:Label ID="Label48" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="  - Service PM"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPM1" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPM2" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPM3" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPM4" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPM5" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPM6" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 16%; ">
                    <asp:Label ID="Label66" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="  - Service PM+R"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPMR1" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPMR2" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPMR3" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPMR4" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPMR5" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPMR6" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 16%; ">
                    <asp:Label ID="Label73" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="  - Service Repair"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcRpr1" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcRpr2" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcRpr3" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcRpr4" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcRpr5" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcRpr6" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 16%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label32" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Service"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalSvc1" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalSvc2" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalSvc3" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalSvc4" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalSvc5" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalSvc6" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 16%; ">
                    <asp:Label ID="Label44" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Bodyrepair"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalBdy1" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalBdy2" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalBdy3" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalBdy4" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalBdy5" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalBdy6" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 16%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label27" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Total"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalAll1" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalAll2" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalAll3" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalAll4" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalAll5" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalAll6" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" style="text-align: right;" Text="0" 
                        Width="100%"></asp:Label>
                </td>
            </tr>
            </table> 
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 40%; background-color:#CCCCFF;">
                    <asp:Label ID="Label30" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Keterangan"></asp:Label>
                </td>
                <td style="width: 30%; background-color:#CCCCFF;">
                    <asp:Label ID="Label31" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Quantity"></asp:Label>
                </td>
                <td style="width: 30%; background-color:#CCCCFF;">
                    <asp:Label ID="Label33" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jumlah"></asp:Label>
                </td>
            </tr>
            
            
            <tr>
                <td style="width: 16%; ">
                    <asp:Label ID="Label46" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Part Sales Counter"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblPartSalesC1" runat="server" Font-Names="Arial" 
                        Font-Size="Small"  height= "21px" Text="0" Width="100%"  
                        style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblPartSalesC2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 16%; background-color: #CCCCFF;">
                    <asp:Label ID="Label53" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Part Sales Dealer/Retail"></asp:Label>
                </td>
                <td style="width: 14%; background-color: #CCCCFF;">
                    <asp:Label ID="LblPartSalesD1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; background-color: #CCCCFF;">
                    <asp:Label ID="LblPartSalesD2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
            </tr>

            </table> 
        </asp:View> 
        <asp:View ID="ViewForm1" runat="server">
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Summary Penerimaan Per Service Advisor</h2>
            </center>
	    </div>  
        <asp:ListView ID="LvTabelSummarySA" 
            runat="server">
            <LayoutTemplate><table id="table-a"  border="2" width="100%" style="border-collapse:collapse;"><thead  style="background-color:Silver">
            <th>Group Customer</th><th>Buka WO</th><th>Unit</th>
            <th>Jasa Service</th><th>Potongan</th><th>Suku Cadang</th>
            <th>Chemical</th><th>Akseoris</th><th>Engine Oil</th>
            <th>Total</th>
            </thead>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_SACust"  runat="server" Text='<%#Eval("Temp_SACus")%>'/></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SAWO"  runat="server" Text='<%#Eval("Temp_SAWO")%>' /></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SAUnit"  runat="server" Text='<%#Eval("Temp_SAUnit")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_SAJasa"   runat="server" Text='<%#Eval("Temp_SAJasa")%>'/></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_SAPotong" runat="server" Text='<%#Eval("Temp_SAPotong")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_SAParts"  runat="server" Text='<%#Eval("Temp_SAParts")%>' /></td>
                <td style="width:8%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_SAChemi" runat="server" Text='<%#Eval("Temp_SAChemi")%>' /></td>
                <td style="width:7%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_SAAkses" runat="server" Text='<%#Eval("Temp_SAAkses")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_SAOil" runat="server" Text='<%#Eval("Temp_SAOil")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_SATotal" runat="server" Text='<%#Eval("Temp_SATotal")%>'/></td>
                </tr>
                </ItemTemplate>
            <SelectedItemTemplate>
                <tr id="Tr1" runat="server" style="background-color:#ADD8E6">
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_SACust"  runat="server" Text='<%#Eval("Temp_SACus")%>'/></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SAWO"  runat="server" Text='<%#Eval("Temp_SAWO")%>' /></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SAUnit"  runat="server" Text='<%#Eval("Temp_SAUnit")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_SAJasa"   runat="server" Text='<%#Eval("Temp_SAJasa")%>'/></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_SAPotong" runat="server" Text='<%#Eval("Temp_SAPotong")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_SAParts"  runat="server" Text='<%#Eval("Temp_SAParts")%>' /></td>
                <td style="width:8%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_SAChemi" runat="server" Text='<%#Eval("Temp_SAChemi")%>' /></td>
                <td style="width:7%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_SAAkses" runat="server" Text='<%#Eval("Temp_SAAkses")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_SAOil" runat="server" Text='<%#Eval("Temp_SAOil")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_SATotal" runat="server" Text='<%#Eval("Temp_SATotal")%>'/></td>
                </tr>
                </SelectedItemTemplate></asp:ListView>        

        </asp:View> 
        
        <asp:View ID="ViewForm2" runat="server">
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Summary Penerimaan Per Mekanik</h2>
            </center>
	    </div>  
        <asp:ListView ID="LvTabelSummaryMekanik" 
            runat="server">
            <LayoutTemplate><table id="table-a"  border="2" width="100%" style="border-collapse:collapse;"><thead  style="background-color:Silver">
            <th>Nama Tekhnisi</th><th>Posisi</th><th>Buka WO</th>
            <th>Jasa Service</th><th>Potongan</th><th>Suku Cadang</th>
            <th>Chemical</th><th>Akseoris</th><th>Engine Oil</th>
            <th>Total</th>
            </thead>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_TekhnisName"  runat="server" Text='<%#Eval("Temp_TekhnisName")%>'/></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_TekhnisPos"  runat="server" Text='<%#Eval("Temp_TekhnisPos")%>' /></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_TekhnisWO"  runat="server" Text='<%#Eval("Temp_TekhnisWO")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_TekhnisJasa"   runat="server" Text='<%#Eval("Temp_TekhnisJasa")%>'/></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_TekhnisPotong" runat="server" Text='<%#Eval("Temp_TekhnisPotong")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_TekhnisParts"  runat="server" Text='<%#Eval("Temp_TekhnisParts")%>' /></td>
                <td style="width:8%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_TekhnisChemi" runat="server" Text='<%#Eval("Temp_TekhnisChemi")%>' /></td>
                <td style="width:7%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_TekhnisAkses" runat="server" Text='<%#Eval("Temp_TekhnisAkses")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_TekhnisOil" runat="server" Text='<%#Eval("Temp_TekhnisOil")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_TekhnisTotal" runat="server" Text='<%#Eval("Temp_TekhnisTotal")%>'/></td>
                </tr>
                </ItemTemplate>
            <SelectedItemTemplate>
                <tr id="Tr1" runat="server" style="background-color:#ADD8E6">
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_TekhnisName"  runat="server" Text='<%#Eval("Temp_TekhnisName")%>'/></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_TekhnisPos"  runat="server" Text='<%#Eval("Temp_TekhnisPos")%>' /></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_TekhnisWO"  runat="server" Text='<%#Eval("Temp_TekhnisWO")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_TekhnisJasa"   runat="server" Text='<%#Eval("Temp_TekhnisJasa")%>'/></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_TekhnisPotong" runat="server" Text='<%#Eval("Temp_TekhnisPotong")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_TekhnisParts"  runat="server" Text='<%#Eval("Temp_TekhnisParts")%>' /></td>
                <td style="width:8%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_TekhnisChemi" runat="server" Text='<%#Eval("Temp_TekhnisChemi")%>' /></td>
                <td style="width:7%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_TekhnisAkses" runat="server" Text='<%#Eval("Temp_TekhnisAkses")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_TekhnisOil" runat="server" Text='<%#Eval("Temp_TekhnisOil")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_TekhnisTotal" runat="server" Text='<%#Eval("Temp_TekhnisTotal")%>'/></td>
                </tr>
                </SelectedItemTemplate></asp:ListView>        

        </asp:View> 

         
    </asp:MultiView>
    


</asp:Content>
