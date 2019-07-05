<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"    AutoEventWireup="false" CodeFile="Form0202StatusSPK00Asli.aspx.vb" Inherits="Form0202StatusSPK00Asli" %>

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
   <asp:MultiView ID="MultiViewSuportLaporan1dan2" runat="server" Visible="TRUE">
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
            <td style="width: 5%; ">
                <asp:TextBox ID="TxtCabang" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="90%" MaxLength="3" TabIndex ="7"  AutoPostBack="true" Text ="112" 
                    Enabled="False"   ></asp:TextBox>
            </td>
            <td style="width: 70%; ">
               <asp:Button ID="ButtonPsm" runat="server" 
                    Text="Klik Disini Kode dealer" Width="23%" Height="100%"  
                    BackColor="White" Font-Bold="True" ForeColor="Black" BorderStyle="None" 
                    Font-Italic="True" Font-Underline="True" Style=" text-align:left" />
            </td>
            <td style="width: 25%; ">
                <asp:CheckBox ID="CheckBoxPerbarui" runat="server" Text="Perbaharui Tabel" 
                    Font-Bold="True" Font-Size="Small" />
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
    </asp:View> 
    </asp:MultiView>


    <asp:MultiView ID="MultiViewMenu" runat="server" Visible="TRUE">
    <asp:View ID="View16" runat="server">
    <table style="width: 100%; height:auto ; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 20%;height:auto ">
               <asp:Button ID="BtnLaporanServiceUnit" runat="server" Text="Laporan Service Unit Masuk"  
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Width="95%" 
                    Height="35px" />
            </td>
            <td style="width: 20%;height:auto ">
               <asp:Button ID="BtnLaporanServicePiutang" runat="server" Text="Laporan Piutang" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Width="95%" Height="35px" />
            </td>
            <td style="width: 20%;height:auto ">
               <asp:Button ID="BtnAudit" runat="server" Text="Audit" 
                    BackColor="#808040" Font-Bold="True" ForeColor="White" Width="95%" 
                    Height="35px" />
            </td>
            <td style="width: 20%;height:auto ">
               <asp:Button ID="BtnStatusMobil" runat="server" Text="Status Kendaraan" 
                    BackColor="#808040" Font-Bold="True" ForeColor="White" Width="95%" 
                    Height="35px" />
            </td>
            <td style="width: 20%;height:auto ">
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
        <table style="width: 100%; height:auto ; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 50%;height:auto ">
               <asp:Button ID="BtnForm01" runat="server" Text="Summary Detail"  
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Width="95%" 
                    Height="35px" />
            </td>
            <td style="width: 50%;height:auto ">
               <asp:Button ID="BtnForm02" runat="server" Text="Summary Total" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Width="95%" 
                    Height="35px" />
            </td>
        </tr>
        </table>
        
        <asp:MultiView ID="MultiViewForm0" runat="server" Visible="TRUE">
        <asp:View ID="ViewForm01" runat="server">
            <asp:SqlDataSource ID="SqlDataSvcWO" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT [WEBREPORT_DEALER], [WEBREPORT_DEPT], [WEBREPORT_GROUP], [WEBREPORT_NAMA], WEBREPORT_TGL,[WEBREPORT_01QTY], [WEBREPORT_04QTY], [WEBREPORT_03RP], [WEBREPORT_03QTY], [WEBREPORT_02RP], [WEBREPORT_02QTY], [WEBREPORT_01RP], [WEBREPORT_04RP], [WEBREPORT_05QTY], [WEBREPORT_05RP], [WEBREPORT_06QTY], [WEBREPORT_06RP], [WEBREPORT_07QTY], [WEBREPORT_07RP], [WEBREPORT_11QTY], [WEBREPORT_08QTY], [WEBREPORT_08RP], [WEBREPORT_09QTY], [WEBREPORT_09RP], [WEBREPORT_10QTY], [WEBREPORT_12RP], [WEBREPORT_12QTY], [WEBREPORT_11RP], [WEBREPORT_10RP] FROM [TEMP_WEBREPORT] WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='A' AND ([WEBREPORT_DEALER] LIKE '%' + ? + '%') ORDER BY WEBREPORT_DEALER,WEBREPORT_GROUP"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
           <SelectParameters>
                <asp:ControlParameter ControlID="TxtCabang" Name="WEBREPORT_DEALER" 
                    PropertyName="Text" Type="String" />            
            </SelectParameters>
        </asp:SqlDataSource>   
        
        <asp:ListView ID="LvWO" runat="server" DataSourceID="SqlDataSvcWO" DataKeyNames ="WEBREPORT_DEALER">
        <LayoutTemplate>
            <table id="table-a" border="2" style="border-collapse:collapse;">
                <thead style="background-color:Red  ; height:30px" ><th>DLR</th><th>KETERANGAN</th><th >BULAN 01</th><th >BULAN 02</th><th >BULAN 03</th><th >BULAN 04</th><th >BULAN 05</th><th >BULAN 06</th><th >BULAN 07</th><th >BULAN 08</th><th >BULAN 09</th><th >BULAN 10</th><th >BULAN 11</th><th >BULAN 12</th><th>UPDATE</th></thead>
                <thead  style="background-color:Red ; height:30px"><th></th><th></th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th></th></thead>
                <thead  style="background-color:Red ; height:30px"><th></th><th></th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th></th></thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
        </LayoutTemplate>
        <ItemTemplate>
        <tr>
        <td rowspan="2" style="width:2%; font-size:small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("WEBREPORT_DEALER") %>' CommandName="Select" runat="server" /></td>
        <td rowspan="2" style="width:20%; font-size:small"><%#Eval("WEBREPORT_NAMA")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_01QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_02QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_03QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_04QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_05QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_06QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_07QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_08QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_09QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_10QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_11QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_12QTY", "{0:N0}")%></td>
        <td rowspan="2" style="width:6%; font-size: small"><%#Eval("WEBREPORT_TGL")%></td>
        </tr>

        <tr>
        <td style="width:6%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("WEBREPORT_01RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("WEBREPORT_02RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("WEBREPORT_03RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("WEBREPORT_04RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_05RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_06RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_07RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_08RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_09RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_10RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_11RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_12RP", "{0:N0}")%></td>
        </tr>


        </ItemTemplate>
        </asp:ListView>
        
        
        
        </asp:View> 
        <asp:View ID="ViewForm02" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; Background-color:#CCCCFF;">
                   <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "99%" Text="Bulan / Tahun"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtSummaryServiceBln" runat="server" text="" Width="5%" AutoPostBack="true" CssClass="uppercase"></asp:TextBox>
                   <asp:Label ID="Label40" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="    /    "></asp:Label>
                    <asp:TextBox ID="TxtSummaryServiceThn" runat="server" text="" Width="5%" AutoPostBack="true" CssClass="uppercase"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Cari" />
                </td>
            </tr>
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 16%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label25" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Keterangan"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label26" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jumlah WO"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label41" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jumlah Faktur"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label42" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total Faktur Jasa DPP"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label43" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total Faktur Jasa Disc"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label29" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total Faktur Jasa"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label28" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total Faktur Parts"></asp:Label>
                </td>
            </tr>
            
            
            <tr>
                <td style="width: 16%; ">
                    <asp:Label ID="Label48" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="  - Service PM"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPM1" runat="server" Font-Names="Arial" 
                        Font-Size="Small"  height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPM2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPM3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPM4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPM5" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPM6" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 16%; ">
                    <asp:Label ID="Label66" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="  - Service PM+R"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPMR1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPMR2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPMR3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPMR4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPMR5" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%" style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcPMR6" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 16%; ">
                    <asp:Label ID="Label73" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="  - Service Repair"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcRpr1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcRpr2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcRpr3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcRpr4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcRpr5" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalSvcRpr6" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
            </tr>
            
            
            <tr>
                <td style="width: 16%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label32" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Service"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalSvc1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalSvc2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalSvc3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalSvc4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalSvc5" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalSvc6" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 16%; ">
                    <asp:Label ID="Label44" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Bodyrepair"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalBdy1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalBdy2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalBdy3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalBdy4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalBdy5" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblTotalBdy6" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 16%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label27" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalAll1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalAll2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalAll3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalAll4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalAll5" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblTotalAll6" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
            </tr>

            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 40%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label30" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Keterangan"></asp:Label>
                </td>
                <td style="width: 30%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label31" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Quantity"></asp:Label>
                </td>
                <td style="width: 30%; background-color:#CCCCFF ;">
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
                    <asp:Label ID="LblPartSalesC1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; ">
                    <asp:Label ID="LblPartSalesC2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 16%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label53" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Part Sales Dealer/Retail"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblPartSalesD1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
                <td style="width: 14%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblPartSalesD2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="0" Width="100%"  style="text-align: right;"></asp:Label>
                </td>
            </tr>

            </table> 


        </asp:View> 
        </asp:MultiView>

        </asp:View> 
        <asp:View ID="ViewForm1" runat="server">
              <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Summary Piutang Service</h2>
            </center>
	  </div>  

        <asp:SqlDataSource ID="SqlDataSvcPiutang" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT [WEBREPORT_DEALER], [WEBREPORT_DEPT], [WEBREPORT_GROUP], [WEBREPORT_NAMA], WEBREPORT_TGL,[WEBREPORT_01QTY], [WEBREPORT_04QTY], [WEBREPORT_03RP], [WEBREPORT_03QTY], [WEBREPORT_02RP], [WEBREPORT_02QTY], [WEBREPORT_01RP], [WEBREPORT_04RP], [WEBREPORT_05QTY], [WEBREPORT_05RP], [WEBREPORT_06QTY], [WEBREPORT_06RP], [WEBREPORT_07QTY], [WEBREPORT_07RP], [WEBREPORT_11QTY], [WEBREPORT_08QTY], [WEBREPORT_08RP], [WEBREPORT_09QTY], [WEBREPORT_09RP], [WEBREPORT_10QTY], [WEBREPORT_12RP], [WEBREPORT_12QTY], [WEBREPORT_11RP], [WEBREPORT_10RP] FROM [TEMP_WEBREPORT] WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='B' AND ([WEBREPORT_DEALER] LIKE '%' + ? + '%')  ORDER BY WEBREPORT_DEALER,WEBREPORT_GROUP"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
           <SelectParameters>
                <asp:ControlParameter ControlID="TxtCabang" Name="WEBREPORT_DEALER" 
                    PropertyName="Text" Type="String" />            
            </SelectParameters>
        </asp:SqlDataSource>   
        <asp:ListView ID="LVWOPiutang" runat="server" DataSourceID="SqlDataSvcPiutang" 
            DataKeyNames ="WEBREPORT_DEALER"><LayoutTemplate><table id="table-a" border="2" width="100%"  style="border-collapse:collapse;"><thead  style="background-color:Red ; height:30px"><th>Dealer</th><th>Nama</th><th>SA</th><th>Current</th><th>Minggu 1</th><th>Minggu 2</th><th>Minggu 3</th><th>Minggu 4</th><th>Minggu >4</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table></LayoutTemplate><ItemTemplate><tr><td style="width:2%; font-size:small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("WEBREPORT_DEALER") %>' CommandName="Select" runat="server" /></td><td style="width:20%; font-size:small"><%#Eval("WEBREPORT_NAMA")%></td><td style="width:15%; font-size:small"><%#Eval("WEBREPORT_GROUP")%></td><td style="width:10%; font-size: small; text-align:right"><%#Eval("WEBREPORT_01RP", "{0:N0}")%></td><td style="width:10%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("WEBREPORT_02RP", "{0:N0}")%></td><td style="width:10%; font-size: small; text-align:right"><%#Eval("WEBREPORT_03RP", "{0:N0}")%></td><td style="width:10%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("WEBREPORT_04RP", "{0:N0}")%></td><td style="width:10%; font-size: small; text-align:right"><%#Eval("WEBREPORT_05RP", "{0:N0}")%></td><td style="width:10%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("WEBREPORT_06RP", "{0:N0}")%></td></tr></ItemTemplate></asp:ListView>

        </asp:View> 
        <asp:View ID="ViewForm2" runat="server">
            <asp:MultiView ID="MultiViewForm21Query" runat="server" Visible="TRUE">
            <asp:View ID="ViewForm21Query" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; Background-color:#CCCCFF;">
                   <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="Nomor Suku Cadang"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtPartsNO" runat="server" text="" Width="10%" AutoPostBack="true" CssClass="uppercase"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label36" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama Suku Cadang"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtPartsNama" runat="server" text="" Width="652px" MaxLength="100" CssClass="uppercase"></asp:TextBox>
                </td>
            </tr>            
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Lantai"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtPartsLantai" runat="server" text="" Width="20%" MaxLength="100" CssClass="uppercase"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jumlah Stok lebih besar sama dengan"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtPartsStok" runat="server" text="-10" Width="20%" MaxLength="100" CssClass="uppercase"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                   <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="Tampilkan Suku Cadang"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Button ID="ButtonTabelPartsGO" runat="server" BackColor="#003399" Font-Overline="False" Font-Size="Small" Height="20px" Text="Cari Data berdasarkan Data Stok" />
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%; ">
                    <asp:Button ID="ButtonTabelPartsSM" runat="server" BackColor="#003399" Font-Overline="False" Font-Size="Small" Height="20px" Text="Cari Data berdasarkan Hasil Audit" />
                </td>
            </tr>

            </table> 
            </asp:View> 
            </asp:MultiView>
            

            <asp:MultiView ID="MultiViewForm22Audit" runat="server" Visible="TRUE">
            <asp:View ID="View12" runat="server">            
            <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Hasil Audit</h2>
            </center>
	        </div>  

           <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 22%;background-color:#CCCCFF ;  ">
                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nomor Suku Cadang</asp:Label>
            </td>
            <td style="width: 75%;background-color:#CCCCFF ;  ">
                <asp:Label ID="LblPartsNo" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">....</asp:Label>
                <asp:Label ID="Label34" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">  Nama Suku Cadang  </asp:Label>
                <asp:Label ID="LblPartsNama" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Stok</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="LblPartsStk" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Pickup</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:Label ID="LblPartsPickup" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Stok Actual</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="LblPartsActual" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            </table>  
             
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">

            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Audit</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:TextBox ID="TxtPartsAuditQty" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="10%" MaxLength="10" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label14" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Catatan</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtPartsAuditNote" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="90%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Labellt2" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Lantai</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:TextBox ID="TxtPartsLantaiku" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="20%" MaxLength="8" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>

            <tr>
            <td style="width: 22%;  ">
                <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Auditor / Tgl Audit / Tgl Stok</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="LblPartsUserNma" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:Label ID="Label23" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">../..</asp:Label>
                <asp:Label ID="LblPartsUserTgl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:Label ID="Label24" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">../..</asp:Label>
                <asp:Label ID="LblPartsStokTgl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%;background-color:#CCCCFF ; ">
                <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Status simpan</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ;">
                <asp:Label ID="LblPartsStatusSimpan" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>

            <tr>
            <td style="width: 22%;  ">
                <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Setelah Tersimpan langsung keluar</asp:Label>
            </td>
            <td style="width: 75%;  ">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Ya" />
            </td>
            </tr>


            </table>   
            </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewForm22AuditTombol" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 50%; ">
               <asp:Button ID="BtnAuditSimpan" runat="server" Text="Simpan hasil Audit" Width="73%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Height="31px"  />
            </td>
            <td style="width: 50%; ">
               <asp:Button ID="BtnAuditBack" runat="server" Text="Kembali Ke Tabel Utama" 
                    Width="73%" Height="31px" BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            </tr>
            </table>
            </asp:View> 
            </asp:MultiView>
            
            <div><center><h2 style="font-family:Cooper Black;">Penilaian/Adjusment Auditor</h2></center></div>  
            <asp:MultiView ID="MultiViewForm22AuditNote2" runat="server" Visible="TRUE">
            <asp:View ID="View3" runat="server">            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label57" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Adjusment</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:TextBox ID="TxtAuditorAdjemsnt" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="50" MaxLength="10" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
                <asp:Label ID="Label58" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Visible="false"  >...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label59" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Catatan Auditor</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtAuditorNote" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="190%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label61" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nama/Tanggal</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:Label ID="LblAuditorUser" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:Label ID="LblAuditorTgl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            </table>   
            </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewForm22AuditNote2Tombol" runat="server" Visible="TRUE">
            <asp:View ID="View5" runat="server">            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 50%; ">
               <asp:Button ID="BtnAdditorSave" runat="server" Text="Simpan Catatan SPV Auditor" Width="73%"  Height="31px"
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 50%; ">
               <asp:Button ID="BtnAdditorBack" runat="server" Text="Kembali Ke Tabel Utama" 
                    Width="73%" Height="31px" BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            </tr>
            </table>
            </asp:View> 
            </asp:MultiView>
            
            <div><center><h2 style="font-family:Cooper Black;">Penilaian Head Parts</h2></center></div>  
            <asp:MultiView ID="MultiViewForm22HeadPartsNote1" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label35" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Catatan Dept Suku Cadang</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtHeadPartsNote" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="90%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label38" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nama/Tanggal Note</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:Label ID="lblHeadPartsUser" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Width="16px">...</asp:Label>
                <asp:Label ID="Label37" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">.../...</asp:Label>
                <asp:Label ID="lblHeadPartsTgl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>            
                <asp:Label ID="Label39" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:CheckBox ID="CheckBoxHeadParts" runat="server" Text ="Menyetujui hasil Auditor dan Penambahan dan pengurangan Parts Stok" />
                </td>
            </tr>
            </table>   
            </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewForm22HeadPartsNote1Tombol" runat="server" Visible="TRUE">
            <asp:View ID="View4" runat="server">            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 50%; ">
               <asp:Button ID="BtnHeadPartsSave" runat="server" Text="Simpan Catatan Head Parts" Width="73%" Height="31px" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 50%; ">
               <asp:Button ID="BtnHeadPartsBack" runat="server" Text="Kembali Ke Tabel Utama" 
                    Width="73%" Height="31px" BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            </tr>
            </table>
            </asp:View> 
            </asp:MultiView>


            <div><center><h2 style="font-family:Cooper Black;">Penilaian Service Manager</h2></center></div>  
            <asp:MultiView ID="MultiViewForm22SM" runat="server" Visible="TRUE">
            <asp:View ID="View6" runat="server">            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label45" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Catatan Sales Manager</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtHeadSMNote" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="90%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label47" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nama/Tanggal Note</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:Label ID="lblHeadSMUser" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:Label ID="Label49" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">.../...</asp:Label>
                <asp:Label ID="lblHeadSMTgl" runat="server" Font-Names="Arial" 
                    Font-Size="Small" height= "21px">...</asp:Label>            
                <asp:Label ID="Label51" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:CheckBox ID="CheckBoxHeadSM" runat="server" Text ="Menyetujui hasil Auditor dan Penambahan dan pengurangan Parts Stok" />
                </td>
            </tr>
            </table>   
            </asp:View> 
            </asp:MultiView>            
            <asp:MultiView ID="MultiViewForm22SMTombol" runat="server" Visible="TRUE">
            <asp:View ID="View7" runat="server">            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 50%; ">
               <asp:Button ID="BtnHeadSMSave" runat="server" Text="Simpan Catatan Service Mgr" Width="73%" Height="31px" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 50%; ">
               <asp:Button ID="BtnHeadSMBack" runat="server" Text="Kembali Ke Tabel Utama" 
                    Width="73%" Height="31px" BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            </tr>
            </table>
            </asp:View> 
            </asp:MultiView>

            <div><center><h2 style="font-family:Cooper Black;">Penilaian Accounting dan Finance</h2></center></div>  
            <asp:MultiView ID="MultiViewForm22ACCFIN" runat="server" Visible="TRUE">
            <asp:View ID="View8" runat="server">            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label52" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Catatan Account/Finance</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtHeadAcctNote" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="90%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label54" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nama/Tanggal Note</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:Label ID="lblHeadAccUser" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:Label ID="Label56" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">.../...</asp:Label>
                <asp:Label ID="lblHeadAccTgl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>            
                <asp:Label ID="Label62" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:CheckBox ID="CheckBoxHeadAcct" runat="server" Text ="Menyetujui hasil Auditor dan Penambahan dan pengurangan Parts Stok" />
                </td>
            </tr>
            </table>   
            </asp:View> 
            </asp:MultiView>            
            <asp:MultiView ID="MultiViewForm22ACCFINTombol" runat="server" Visible="TRUE">
            <asp:View ID="View9" runat="server">            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 50%; ">
               <asp:Button ID="BtnHeadAccSave" runat="server" Text="Simpan Catatan Account" Width="73%" Height="31px" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 50%; ">
               <asp:Button ID="BtnHeadAccBack" runat="server" Text="Kembali Ke Tabel Utama" 
                    Width="73%" Height="31px" BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            </tr>
            </table>
            </asp:View> 
            </asp:MultiView>



            <asp:MultiView ID="MultiViewTabelStokPart112" runat="server" Visible="TRUE">
            <asp:View ID="View19" runat="server">            

            <asp:SqlDataSource ID="sdsTabelStock112" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnetSvcs112 %>" 
            SelectCommand="SELECT [PARTS_NO], [PARTS_NAMA], [PARTS_STOCK],(ISNULL([PARTS_STOCK],0)-ISNULL([PARTS_QYPESAN],0)) as QtySTok, [PARTS_QYPESAN], [PARTS_LOKASI], [PARTS_QTYAUDIT], [PARTS_TGLAUDIT] FROM [DATA_PARTS] WHERE ([PARTS_LOKASI] LIKE '%' + ? + '%')  AND ([PARTS_NO] LIKE '%' + ? + '%') AND ([PARTS_NAMA] LIKE '%' + ? + '%') AND PARTS_STOCK >= ?  ORDER BY PARTS_LOKASI,PARTS_NO"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnetSvcs112.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtPartsLantai"           Name="DATA_PARTS.PARTS_LOKASI" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsNO"               Name="DATA_PARTS.PARTS_NO" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsNama"             Name="DATA_PARTS.PARTS_NAMA" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsStok"             Name="DATA_PARTS.PARTS_STOCK" 
                    PropertyName="Text" Type="Int64"  DefaultValue="-10" />            
            </SelectParameters>
            </asp:SqlDataSource>                     
            <asp:ListView ID="lvStockPart" runat="server" DataSourceID="sdsTabelStock112" DataKeyNames ="PARTS_NO">
            <LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
            <thead  style="background-color:Silver">
            <th>Part No</th><th>Nama</th><th>Lokasi</th><th>Stok</th><th>Pickup</th><th>Stock</th><th>Audit</th><th>Qty</th>
            </thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="1500" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate>
            <ItemTemplate><tr><td style="width:15%; height:30px;  font-size: small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("PARTS_NO") %>' CommandName="Select" runat="server" /></td><td style="width:29%; font-size:small"><%#Eval("PARTS_NAMA")%></td><td style="width:10%; font-size:small"><%#Eval("PARTS_LOKASI")%></td><td style="width:9%; font-size:small"><%#Eval("PARTS_STOCK")%></td><td style="width:9%; font-size:small"><%#Eval("PARTS_QYPESAN")%></td><td style="width:9%; font-size:small"><%#Eval("QtySTok")%></td><td style="width:10%; font-size:small"><%#Eval("PARTS_TGLAUDIT")%></td><td style="width:9%; font-size:small"><%#Eval("PARTS_QTYAUDIT")%></td></tr>
            </ItemTemplate>
            </asp:ListView>


            </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewTabelStokPart128" runat="server" Visible="TRUE">
            <asp:View ID="View20" runat="server">            
            <asp:SqlDataSource ID="sdsTabelStock128" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnetSvcs128 %>" 
            SelectCommand="SELECT [PARTS_NO], [PARTS_NAMA], [PARTS_STOCK],(ISNULL([PARTS_STOCK],0)-ISNULL([PARTS_QYPESAN],0)) as QtySTok, [PARTS_QYPESAN], [PARTS_LOKASI], [PARTS_QTYAUDIT], [PARTS_TGLAUDIT] FROM [DATA_PARTS] WHERE ([PARTS_LOKASI] LIKE '%' + ? + '%')  AND ([PARTS_NO] LIKE '%' + ? + '%') AND ([PARTS_NAMA] LIKE '%' + ? + '%') AND PARTS_STOCK >= ?  ORDER BY PARTS_LOKASI,PARTS_NO"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnetSvcs112.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtPartsLantai"           Name="DATA_PARTS.PARTS_LOKASI" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsNO"               Name="DATA_PARTS.PARTS_NO" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsNama"             Name="DATA_PARTS.PARTS_NAMA" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsStok"             Name="DATA_PARTS.PARTS_STOCK" 
                    PropertyName="Text" Type="Int64"  DefaultValue="-10" />            
            </SelectParameters>
            </asp:SqlDataSource>                     
            <asp:ListView ID="lvStockPart128" runat="server" DataSourceID="sdsTabelStock128" DataKeyNames ="PARTS_NO">
            <LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead  style="background-color:Silver"><th>Part No</th><th>Nama</th><th>Lokasi</th><th>Stok</th><th>Pickup</th><th>Stock</th><th>Audit</th><th>Qty</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="1500" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate>
            <ItemTemplate><tr><td style="width:15%; height:30px;  font-size: small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("PARTS_NO") %>' CommandName="Select" runat="server" /></td><td style="width:29%; font-size:small"><%#Eval("PARTS_NAMA")%></td><td style="width:10%; font-size:small"><%#Eval("PARTS_LOKASI")%></td><td style="width:9%; font-size:small"><%#Eval("PARTS_STOCK")%></td><td style="width:9%; font-size:small"><%#Eval("PARTS_QYPESAN")%></td><td style="width:9%; font-size:small"><%#Eval("QtySTok")%></td><td style="width:10%; font-size:small"><%#Eval("PARTS_TGLAUDIT")%></td><td style="width:9%; font-size:small"><%#Eval("PARTS_QTYAUDIT")%></td></tr>
            </ItemTemplate>
            </asp:ListView>

            </asp:View> 
            </asp:MultiView>

            <asp:MultiView ID="MultiViewTabelAudit112" runat="server" Visible="TRUE">
            <asp:View ID="View22" runat="server">   
            <asp:SqlDataSource ID="SqlDataAdudit112" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnetSvcs112 %>" 
            SelectCommand="SELECT DATA_PARTS.PARTS_NO, DATA_PARTS.PARTS_NAMA, ISNULL(TEMP_AUDITPART.AUDITPART_STOK, 0) - ISNULL(TEMP_AUDITPART.AUDITPART_PICKUP, 0) AS QtySTok, DATA_PARTS.PARTS_STOCK, DATA_PARTS.PARTS_QYPESAN, DATA_PARTS.PARTS_LOKASI, DATA_PARTS.PARTS_QTYAUDIT, DATA_PARTS.PARTS_TGLAUDIT, TEMP_AUDITPART.AUDITPART_NO, TEMP_AUDITPART.AUDITPART_TGL, TEMP_AUDITPART.AUDITPART_USER, TEMP_AUDITPART.AUDITPART_STOK, TEMP_AUDITPART.AUDITPART_PICKUP, TEMP_AUDITPART.AUDITPART_QTY, TEMP_AUDITPART.AUDITPART_CATATAN, TEMP_AUDITPART.AUDITPART_NOTE1, TEMP_AUDITPART.AUDITPART_NOTE2, TEMP_AUDITPART.AUDITPART_NOTE1TGL, TEMP_AUDITPART.AUDITPART_NOTE1USR, TEMP_AUDITPART.AUDITPART_NOTE2TGL, TEMP_AUDITPART.AUDITPART_NOTE2USR, TEMP_AUDITPART.AUDITPART_NOTE2ADJ FROM DATA_PARTS RIGHT OUTER JOIN TEMP_AUDITPART ON DATA_PARTS.PARTS_NO = TEMP_AUDITPART.AUDITPART_NO WHERE (DATA_PARTS.PARTS_NO LIKE '%' + ? + '%') ORDER BY DATA_PARTS.PARTS_NO"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnetSvcs112.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="LblPartsNo"           Name="DATA_PARTS.PARTS_NO" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
            </SelectParameters>
            </asp:SqlDataSource>                     
            <asp:ListView ID="LVDataAdudit" runat="server" DataSourceID="SqlDataAdudit112" DataKeyNames ="PARTS_NO"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
            <thead  style="background-color:Silver">
            <th>Part No</th><th>Nama</th><th>Tgl Audit</th><th>User</th><th>Stok</th><th>Pickup</th><th>Actual</th><th>Qty</th><th>Catatan</th><th>Adj</th><th>Note Auditor</th><th>Note Parts</th>
            </thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="15" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate>
                    <tr>
                    <td style="width:11%; height:30px;  font-size: small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("PARTS_NO") %>' CommandName="Select" runat="server" /></td>
                    <td style="width:20%; font-size:small"><%#Eval("PARTS_NAMA")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("AUDITPART_TGL")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("AUDITPART_USER")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("AUDITPART_STOK")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("AUDITPART_PICKUP")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("QtySTok")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("AUDITPART_QTY")%></td>
                    <td style="width:10%; font-size:small"><%#Eval("AUDITPART_CATATAN")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("AUDITPART_NOTE2ADJ")%></td>
                    <td style="width:9%; font-size:small"><%#Eval("AUDITPART_NOTE2")%></td>
                    <td style="width:9%; font-size:small"><%#Eval("AUDITPART_NOTE1")%></td>
                    </tr>
                    </ItemTemplate></asp:ListView>
         
            </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewTabelAudit128" runat="server" Visible="TRUE">
            <asp:View ID="View23" runat="server">            
            <asp:SqlDataSource ID="SqlDataAdudit128" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnetSvcs128 %>" 
            SelectCommand="SELECT DATA_PARTS.PARTS_NO, DATA_PARTS.PARTS_NAMA, ISNULL(TEMP_AUDITPART.AUDITPART_STOK, 0) - ISNULL(TEMP_AUDITPART.AUDITPART_PICKUP, 0) AS QtySTok, DATA_PARTS.PARTS_STOCK, DATA_PARTS.PARTS_QYPESAN, DATA_PARTS.PARTS_LOKASI, DATA_PARTS.PARTS_QTYAUDIT, DATA_PARTS.PARTS_TGLAUDIT, TEMP_AUDITPART.AUDITPART_NO, TEMP_AUDITPART.AUDITPART_TGL, TEMP_AUDITPART.AUDITPART_USER, TEMP_AUDITPART.AUDITPART_STOK, TEMP_AUDITPART.AUDITPART_PICKUP, TEMP_AUDITPART.AUDITPART_QTY, TEMP_AUDITPART.AUDITPART_CATATAN, TEMP_AUDITPART.AUDITPART_NOTE1, TEMP_AUDITPART.AUDITPART_NOTE2, TEMP_AUDITPART.AUDITPART_NOTE1TGL, TEMP_AUDITPART.AUDITPART_NOTE1USR, TEMP_AUDITPART.AUDITPART_NOTE2TGL, TEMP_AUDITPART.AUDITPART_NOTE2USR, TEMP_AUDITPART.AUDITPART_NOTE2ADJ FROM DATA_PARTS RIGHT OUTER JOIN TEMP_AUDITPART ON DATA_PARTS.PARTS_NO = TEMP_AUDITPART.AUDITPART_NO WHERE (DATA_PARTS.PARTS_NO LIKE '%' + ? + '%') ORDER BY DATA_PARTS.PARTS_NO"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnetSvcs128.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="LblPartsNo"           Name="DATA_PARTS.PARTS_NO" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
            </SelectParameters>
            </asp:SqlDataSource>                     
            <asp:ListView ID="LVDataAdudit128" runat="server" DataSourceID="SqlDataAdudit128" DataKeyNames ="PARTS_NO"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
            <thead  style="background-color:Silver">
            <th>Part No</th><th>Nama</th><th>Tgl Audit</th><th>User</th><th>Stok</th><th>Pickup</th><th>Actual</th><th>Qty</th><th>Catatan</th><th>Adj</th><th>Note Auditor</th><th>Note Parts</th>
            </thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="15" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate>
                    <tr>
                    <td style="width:11%; height:30px;  font-size: small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("PARTS_NO") %>' CommandName="Select" runat="server" /></td>
                    <td style="width:20%; font-size:small"><%#Eval("PARTS_NAMA")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("AUDITPART_TGL")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("AUDITPART_USER")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("AUDITPART_STOK")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("AUDITPART_PICKUP")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("QtySTok")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("AUDITPART_QTY")%></td>
                    <td style="width:10%; font-size:small"><%#Eval("AUDITPART_CATATAN")%></td>
                    <td style="width:6%; font-size:small"><%#Eval("AUDITPART_NOTE2ADJ")%></td>
                    <td style="width:9%; font-size:small"><%#Eval("AUDITPART_NOTE2")%></td>
                    <td style="width:9%; font-size:small"><%#Eval("AUDITPART_NOTE1")%></td>
                    </tr>
                    </ItemTemplate></asp:ListView>
                    
            </asp:View> 
            </asp:MultiView>         
        </asp:View>         
        <asp:View ID="ViewForm3" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; Background-color:#CCCCFF;">
                   <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "99%" Text="Nomor Polisi"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtQueryServiceNopol" runat="server" text="" Width="10%" AutoPostBack="true" CssClass="uppercase"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Cari" />
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label18" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama Service Ps Minggu"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="lblQueryServiceNamaPSM" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;Background-color:#CCCCFF; ">
                    <asp:Label ID="Label20" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Rangkuman Service Ps Minggu"></asp:Label>
                </td>
                <td style="width: 75%;Background-color:#CCCCFF; ">
                    <asp:Label ID="lblQueryServiceHistPSM" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label19" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Rangkuman Sales Ps Minggu"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="lblQuerySalesHistPSM" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="width: 25%;Background-color:#CCCCFF; ">
                    <asp:Label ID="Label16" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama Service Puri"></asp:Label>
                </td>
                <td style="width: 75%;Background-color:#CCCCFF; ">
                    <asp:Label ID="lblQueryServiceNamaPuri" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label17" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Rangkuman Service Puri"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="lblQueryServiceHistPuri" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;Background-color:#CCCCFF; ">
                    <asp:Label ID="Label21" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Rangkuman Sales Puri"></asp:Label>
                </td>
                <td style="width: 75%;Background-color:#CCCCFF; ">
                    <asp:Label ID="lblQuerySalesHistPuri" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>

            </table> 
        </asp:View> 
    </asp:MultiView>
    


</asp:Content>
