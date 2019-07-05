<%@ Page Language="VB" MasterPageFile ="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0205Warehouse.aspx.vb" Inherits="Form0205Warehouse" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID%>");
            var printWindow = window.open('', '', 'letf=0,top=0,width=2200,height=1400,toolbar=0,scrollbars=0,status=0,dir=ltr');
            
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
                printWindow.resizeTo(100,100);
                printWindow.focus();
                printwindow.window.close();
            }, 500);
            return false;
        }


    </script>

        <center>
        <asp:Label ID="Label242" runat="server" Font-Names="Cooper Black"  
                Font-Size="XX-Large"  height= "30px" Text="WAREHOUSE" Font-Bold="True"></asp:Label>
        </center>
        <center>&nbsp; User&nbsp; : 
        <asp:Label ID="LblUserName" runat="server"></asp:Label>
        <asp:Label ID="lblAkses" runat="server"></asp:Label>
        &nbsp; Akses &nbsp; : 
        <asp:Label ID="lblArea1" runat="server"></asp:Label>
        <asp:Label ID="lblArea2" runat="server"></asp:Label></center>
        <asp:MultiView ID="MultiView1" runat="server" Visible="TRUE">
        <asp:View ID="View6"  runat="server">
    <table style="width: 100%; height:40px; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 20%; ">
               <asp:Button ID="BtnHal1" runat="server" Text="Jadwal Pengiriman" Width="99%" 
                    BackColor="Silver" Font-Bold="True" ForeColor="Black" Height="100%"  />
            </td>
            <td style="width: 20%; ">
               <asp:Button ID="BtnHal2" runat="server" Text="Status Perbaikan Kendaraan" Width="99%" 
                    BackColor="Silver" Font-Bold="True" ForeColor="Black" Height="100%" />
            </td>
            <td style="width: 20%; ">
               <asp:Button ID="BtnHal3" runat="server" Text="Stok dan Aksesoris" Width="99%" 
                    BackColor="Silver" Font-Bold="True" ForeColor="Black" Height="100%" />
            </td>
            <td style="width: 20%; ">
               <asp:Button ID="BtnHal4" runat="server" Text="Gesek Rangka Sudah DO" Width="99%" 
                    BackColor="Silver" Font-Bold="True" ForeColor="Black" Height="100%" />
            </td>
            <td style="width: 20%; ">
               <asp:Button ID="BtnHal5" runat="server" Text="DO Imora Unit Belum Terima" Width="99%" 
                    BackColor="Silver" Font-Bold="True" ForeColor="Black" Height="100%" />
            </td>

        </tr>
        <tr>
            <td style="width: 20%; ">
            </td>
            <td style="width: 20%; ">
            </td>
            <td style="width: 20%; ">
            </td>
            <td style="width: 20%; ">
               <asp:Button ID="BtnHal6" runat="server" Text="Periksa Input Rangka" Width="99%" 
                    BackColor="Silver" Font-Bold="True" ForeColor="Black" Height="100%" />
            </td>
            <td style="width: 20%; ">
               <asp:Button ID="Button2" runat="server" Text="PDI dan laporan" Width="99%" 
                    BackColor="Silver" Font-Bold="True" ForeColor="Black" Height="100%" />
            </td>

        </tr>

     </table>
     </asp:View> 
     </asp:MultiView>
      
    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
        <br />
        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="959px">error message</asp:Label>          
    </asp:View> 
    </asp:MultiView>
    
    <asp:MultiView ID="MultiViewWarehouse" runat="server" Visible="TRUE">
        <asp:View ID="View01Jadwal"  runat="server">
        <center>
        <asp:Label ID="Label239" runat="server" Font-Names="Cooper Black"  
                Font-Size="Medium" height= "21px" Text="Jadwal Tanggal Pengiriman" 
                ForeColor="Red"></asp:Label>
        </center>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
            <td style="width: 100%; ">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size:medium;">
            <tr>
            <td style="width: 25%; ">
               <asp:Label ID="Label17" runat="server" Font-Names="Arial" Font-Size="medium" height= "21px" Text="Jadwal Tanggal Pengiriman : "></asp:Label>
               <asp:Label ID="LblTglKirimDD" runat="server" Font-Names="Arial" Font-Size="medium" 
                    height= "21px" Text="DD"></asp:Label>
               <asp:Label ID="Label241" runat="server" Font-Names="Arial" Font-Size="medium" 
                    height= "21px" Text="/"></asp:Label>
               <asp:Label ID="LblTglKirimMM" runat="server" Font-Names="Arial" Font-Size="medium" 
                    height= "21px" Text="MM"></asp:Label>
               <asp:Label ID="Label243" runat="server" Font-Names="Arial" Font-Size="medium" 
                    height= "21px" Text="/"></asp:Label>
               <asp:Label ID="LblTglKirimYY" runat="server" Font-Names="Arial" Font-Size="medium" 
                    height= "21px" Text="YY"></asp:Label>
            </td>
            <td style="width: 25%; ">
                <asp:TextBox ID="txtTglKirim" runat="server" />
                <asp:Button ID="BtnCal1" runat="server" Text=".." Width="27px" />
                <div id="tanggalPopup">
                <asp:Calendar ID="Calendar1" runat="server" onselectionchanged="Calendar1_SelectionChanged" />
                </div>
            </td>
            <td style="width: 75%; ">
               <asp:Button ID="Button4" runat="server" Text=" &lt;---- Pencarian Jadwal Pengiriman Unit berdasarkan tanggal kirim" 
                    Width="413px" BackColor="#0033CC" Height="64px" />
            </td>
            </tr>
            </table> 
            <asp:MultiView ID="MultiV4Jadwal" runat="server" Visible="TRUE">
            <asp:View ID="V401" runat="server">

        <center>
        <asp:Label ID="Label20" runat="server" Font-Names="Cooper Black"  
                Font-Size="Medium" height= "21px" Text="Pengiriman sesuai dengan permohonan" 
                ForeColor="Red"></asp:Label>
                <br />
        <asp:Label ID="Label270" runat="server" Font-Names="Cooper Black"  
                Font-Size="Small"  height= "21px" Text="St(Status Kirim) 1.Ke Customer 2.Ke Pameran 3.Ke Showroom" 
                ForeColor="Red"></asp:Label>

        </center>

            <asp:SqlDataSource ID="sdsTabelJdw" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand = "SELECT TRXN_STOCKMKIRIM.STOCKM_NORANGKA, TRXN_STOCKMKIRIM.STOCKM_KDDEALER, TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM, TRXN_STOCKMKIRIM.STOCKM_TGLMOHONINPUT, TRXN_STOCKMKIRIM.STOCKM_BERITA, TRXN_STOCKMKIRIM.STOCKM_LEASE, TRXN_STOCKMKIRIM.STOCKM_USER, TRXN_STOCKMKIRIM.STOCKM_KIRIMTGLSETUJUI, TRXN_STOCKMKIRIM.STOCKM_SALES, TRXN_STOCKMKIRIM.STOCKM_APPTGLDO, TRXN_STOCKMKIRIM.STOCKM_APPUSRDO, TRXN_STOCK.STOCK_NoTTK, TRXN_STOCK.STOCK_TglTTK, TRXN_STOCK.STOCK_NoRangka, TRXN_STOCK.STOCK_NoMesin, TRXN_STOCK.STOCK_CdWarna, TRXN_STOCK.STOCK_CdType, TRXN_STOCK.STOCK_Versi, TRXN_STOCK.STOCK_NoKunci, TRXN_STOCK.STOCK_Tahun, TRXN_STOCK.STOCK_CdSuplier, TRXN_STOCK.STOCK_DoAuto, TRXN_STOCK.STOCK_TglAuto, TRXN_STOCK.STOCK_CdLokasi, TRXN_STOCK.STOCK_Keterangan, TRXN_STOCK.STOCK_StsUpdate, TRXN_STOCK.STOCK_TglUpdate, TRXN_STOCK.STOCK_Alasan, TRXN_STOCK.STOCK_Berita, TRXN_STOCK.STOCK_DoDealer, TRXN_STOCK.STOCK_TglDoDealer, TRXN_STOCK.STOCK_TglCtkDoDealer, TRXN_STOCK.STOCK_TglKirim, TRXN_STOCK.STOCK_TglTerima, TRXN_STOCK.STOCK_NOSPK, TRXN_STOCK.STOCK_DOSPKNama, TRXN_STOCK.STOCK_DOSPKKota, TRXN_STOCK.STOCK_DOTGLGESEKRGK, TRXN_STOCK.STOCK_DOTGLGESEKRGKI, TRXN_STOCK.STOCK_DOTGLGESEKRGKT, TRXN_STOCK.STOCK_NODEALER, TRXN_STOCK.STOCK_DOGESEKNOTE, TRXN_STOCK.STOCK_KIRIMMUGENKODE, TRXN_STOCK.STOCK_KIRIMMUGENTGL, TRXN_STOCK.STOCKK_KIRIMMUGENTGLI, TRXN_STOCK.STOCK_KIRIMMUGENSTS, TRXN_STOCK.STOCK_BUKUSERVICE, TRXN_STOCK.STOCK_TglSJ, TRXN_STOCK.STOCK_TglCtkDoDealerI, TRXN_STOCK.STOCK_TglDoImoraHPM, TRXN_STOCK.STOCK_KODEDEALER, TRXN_STOCK.STOCK_NAMA, TRXN_STOCK.STOCK_KOTA, TRXN_STOCK.STOCK_USER, TRXN_STOCK.STOCK_BlockPickup, TRXN_STOCK.STOCK_ValidTgl, TRXN_STOCK.STOCK_ValidUser, TRXN_STOCKKKIRIM.STOCKK_NORANGKA, TRXN_STOCKKKIRIM.STOCKK_DRIVER, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLKIRIM, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLTERIMA, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLPDI, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLSECURITY, TRXN_STOCKKKIRIM.STOCKK_KIRIMKETSECURITY, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLKIRIMI, TRXN_STOCKKKIRIM.STOCKK_STATUS, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLTERIMAI, TRXN_STOCKKKIRIM.STOCKK_KIRIMKETTERIMA, TRXN_STOCKKKIRIM.STOCKK_VALIDTGLPDI, TRXN_STOCKKKIRIM.STOCKK_DRIVERNM, TRXN_STOCKKKIRIM.STOCKK_NOKIRIM, TRXN_STOCKKKIRIM.STOCKK_BIAYA, TRXN_STOCKKKIRIM.STOCKK_JENIS, TRXN_STOCKKKIRIM.STOCKK_TOMUGEN FROM TRXN_STOCKMKIRIM LEFT OUTER JOIN TRXN_STOCK ON TRXN_STOCKMKIRIM.STOCKM_NORANGKA = TRXN_STOCK.STOCK_NoRangka FULL OUTER JOIN TRXN_STOCKKKIRIM ON TRXN_STOCK.STOCK_NoRangka = TRXN_STOCKKKIRIM.STOCKK_NORANGKA WHERE (DAY(TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM) = ?) AND (MONTH(TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM) = ?) AND (YEAR(TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM) = ?)"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblTglKirimDD"      Name="STOCKM_TGLMOHONKIRIM"       PropertyName= "Text" Type="String" DefaultValue="%"/>            
                <asp:ControlParameter ControlID="lblTglKirimMM"      Name="STOCKM_TGLMOHONKIRIM2"      PropertyName= "Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="lblTglKirimYY"       Name="STOCKM_TGLMOHONKIRIM3"      PropertyName= "Text" Type="String" DefaultValue="%"  />            

            </SelectParameters>

            
            </asp:SqlDataSource>                 
            <asp:ListView ID="lvKirimmUnit" runat="server" DataSourceID="sdsTabelJdw" DataKeyNames ="STOCKM_NORANGKA"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead  style="background-color:Silver; height:30px"><th>Nomor Rangka</th><th>Dealer</th><th>Sales</th><th>Tgl Input</th><th>Tgl Mohon</th><th>Tgl Kirim</th><th>Tgl SPJ</th><th>Terima</th><th>St</th><th>Keterangan</th><th>Berita</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="50" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate><tr>
                <td style="width:9%; font-size: small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("STOCKM_NORANGKA") %>' CommandName="Select" runat="server" /></td>
                <td style="width:5%; font-size: small"><%#Eval("STOCKM_KDDEALER")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKM_SALES")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKM_TGLMOHONINPUT")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKM_TGLMOHONKIRIM")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKM_KIRIMTGLSETUJUI")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKK_KIRIMTGLKIRIM")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKK_KIRIMTGLTERIMA")%></td>
                <td style="width:3%; font-size: small"><%#Eval("STOCKK_JENIS")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKK_KIRIMKETTERIMA")%></td>
                <td style="width:12%; font-size: small"><%#Eval("STOCKM_BERITA")%></td>
                </tr></ItemTemplate></asp:ListView>
             
<br />
        <center>
        <asp:Label ID="Label53" runat="server" Font-Names="Cooper Black"  
                Font-Size="Medium" height= "21px" Text="Pengiriman di Geser" 
                ForeColor="Red"></asp:Label>
        </center>

            <asp:SqlDataSource ID="SdsTabelJdwMove" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand = "SELECT * FROM TRXN_STOCKMKIRIM LEFT OUTER JOIN TRXN_STOCK ON TRXN_STOCKMKIRIM.STOCKM_NORANGKA = TRXN_STOCK.STOCK_NoRangka LEFT OUTER JOIN TRXN_STOCKKKIRIM ON TRXN_STOCK.STOCK_NoRangka = TRXN_STOCKKKIRIM.STOCKK_NORANGKA WHERE DATEDIFF(DAY,STOCKM_TGLMOHONKIRIM,TRXN_STOCKMKIRIM.STOCKM_KIRIMTGLSETUJUI) <> 0 AND (DAY(TRXN_STOCKMKIRIM.STOCKM_KIRIMTGLSETUJUI) = ?) AND (MONTH(TRXN_STOCKMKIRIM.STOCKM_KIRIMTGLSETUJUI) = ?) AND (YEAR(TRXN_STOCKMKIRIM.STOCKM_KIRIMTGLSETUJUI) = ?)"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblTglKirimDD"      Name="STOCKM_KIRIMTGLSETUJUI"       PropertyName= "Text" Type="String" DefaultValue="%"/>            
                <asp:ControlParameter ControlID="lblTglKirimMM"      Name="STOCKM_KIRIMTGLSETUJUI2"      PropertyName= "Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="lblTglKirimYY"       Name="STOCKM_KIRIMTGLSETUJUI3"      PropertyName= "Text" Type="String" DefaultValue="%"  />            

            </SelectParameters>

            </asp:SqlDataSource>                 
            <asp:ListView ID="LvKirimUnitMove" runat="server" DataSourceID="SdsTabelJdwMove" DataKeyNames ="STOCKM_NORANGKA"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead  style="background-color:Silver; height:30px"><th>Nomor Rangka</th><th>Dealer</th><th>Sales</th><th>Tgl Input</th><th>Tgl Mohon</th><th>Tgl Kirim</th><th>Tgl SPJ</th><th>Terima</th><th>Keterangan</th><th>Berita</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="50" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate><tr>
                <td style="width:9%; font-size: small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("STOCKM_NORANGKA") %>' CommandName="Select" runat="server" /></td>
                <td style="width:5%; font-size: small"><%#Eval("STOCKM_KDDEALER")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKM_SALES")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKM_TGLMOHONINPUT")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKM_TGLMOHONKIRIM")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKM_KIRIMTGLSETUJUI")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKK_KIRIMTGLKIRIM")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKK_KIRIMTGLTERIMA")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKK_KIRIMKETTERIMA")%></td>
                <td style="width:15%; font-size: small"><%#Eval("STOCKM_BERITA")%></td>
                </tr></ItemTemplate>
                <EmptyDataTemplate>
                <center>
                <asp:Label ID="Label262" runat="server" Font-Names="Cooper Black"  
                     Font-Size="small" height= "21px" Text="Tidak ada Data Rangka yang digeser" 
                     ForeColor="Black" ></asp:Label>
                </center>

                </EmptyDataTemplate> 
                <EmptyItemTemplate>
                <center>
                <asp:Label ID="Label262" runat="server" Font-Names="Cooper Black"  
                     Font-Size="small" height= "21px" Text="Tidak ada Data Rangka yang digeser" 
                     ForeColor="Black" ></asp:Label>
                </center>
                </EmptyItemTemplate> 

                </asp:ListView>

<br />
        <center>
        
        <asp:Label ID="Label261" runat="server" Font-Names="Cooper Black"  
                Font-Size="Medium" height= "21px" Text="Permohonan Kirim tapi belum dibuatkan SPJ" 
                ForeColor="Red"></asp:Label>
        </center>

            <asp:SqlDataSource ID="SdsTabelJdwNoSPJ" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand = "SELECT TRXN_STOCKMKIRIM.STOCKM_NORANGKA, TRXN_STOCKMKIRIM.STOCKM_KDDEALER, TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM, TRXN_STOCKMKIRIM.STOCKM_TGLMOHONINPUT, TRXN_STOCKMKIRIM.STOCKM_BERITA, TRXN_STOCKMKIRIM.STOCKM_LEASE, TRXN_STOCKMKIRIM.STOCKM_USER, TRXN_STOCKMKIRIM.STOCKM_KIRIMTGLSETUJUI, TRXN_STOCKMKIRIM.STOCKM_SALES, TRXN_STOCKMKIRIM.STOCKM_APPTGLDO, TRXN_STOCKMKIRIM.STOCKM_APPUSRDO, TRXN_STOCK.STOCK_NoTTK, TRXN_STOCK.STOCK_TglTTK, TRXN_STOCK.STOCK_NoRangka, TRXN_STOCK.STOCK_NoMesin, TRXN_STOCK.STOCK_CdWarna, TRXN_STOCK.STOCK_CdType, TRXN_STOCK.STOCK_Versi, TRXN_STOCK.STOCK_NoKunci, TRXN_STOCK.STOCK_Tahun, TRXN_STOCK.STOCK_CdSuplier, TRXN_STOCK.STOCK_DoAuto, TRXN_STOCK.STOCK_TglAuto, TRXN_STOCK.STOCK_CdLokasi, TRXN_STOCK.STOCK_Keterangan, TRXN_STOCK.STOCK_StsUpdate, TRXN_STOCK.STOCK_TglUpdate, TRXN_STOCK.STOCK_Alasan, TRXN_STOCK.STOCK_Berita, TRXN_STOCK.STOCK_DoDealer, TRXN_STOCK.STOCK_TglDoDealer, TRXN_STOCK.STOCK_TglCtkDoDealer, TRXN_STOCK.STOCK_TglKirim, TRXN_STOCK.STOCK_TglTerima, TRXN_STOCK.STOCK_NOSPK, TRXN_STOCK.STOCK_DOSPKNama, TRXN_STOCK.STOCK_DOSPKKota, TRXN_STOCK.STOCK_DOTGLGESEKRGK, TRXN_STOCK.STOCK_DOTGLGESEKRGKI, TRXN_STOCK.STOCK_DOTGLGESEKRGKT, TRXN_STOCK.STOCK_NODEALER, TRXN_STOCK.STOCK_DOGESEKNOTE, TRXN_STOCK.STOCK_KIRIMMUGENKODE, TRXN_STOCK.STOCK_KIRIMMUGENTGL, TRXN_STOCK.STOCKK_KIRIMMUGENTGLI, TRXN_STOCK.STOCK_KIRIMMUGENSTS, TRXN_STOCK.STOCK_BUKUSERVICE, TRXN_STOCK.STOCK_TglSJ, TRXN_STOCK.STOCK_TglCtkDoDealerI, TRXN_STOCK.STOCK_TglDoImoraHPM, TRXN_STOCK.STOCK_KODEDEALER, TRXN_STOCK.STOCK_NAMA, TRXN_STOCK.STOCK_KOTA, TRXN_STOCK.STOCK_USER, TRXN_STOCK.STOCK_BlockPickup, TRXN_STOCK.STOCK_ValidTgl, TRXN_STOCK.STOCK_ValidUser, TRXN_STOCKKKIRIM.STOCKK_NORANGKA, TRXN_STOCKKKIRIM.STOCKK_DRIVER, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLKIRIM, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLTERIMA, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLPDI, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLSECURITY, TRXN_STOCKKKIRIM.STOCKK_KIRIMKETSECURITY, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLKIRIMI, TRXN_STOCKKKIRIM.STOCKK_STATUS, TRXN_STOCKKKIRIM.STOCKK_KIRIMTGLTERIMAI, TRXN_STOCKKKIRIM.STOCKK_KIRIMKETTERIMA, TRXN_STOCKKKIRIM.STOCKK_VALIDTGLPDI, TRXN_STOCKKKIRIM.STOCKK_DRIVERNM, TRXN_STOCKKKIRIM.STOCKK_NOKIRIM, TRXN_STOCKKKIRIM.STOCKK_BIAYA, TRXN_STOCKKKIRIM.STOCKK_JENIS, TRXN_STOCKKKIRIM.STOCKK_TOMUGEN FROM TRXN_STOCKMKIRIM LEFT OUTER JOIN TRXN_STOCK ON TRXN_STOCKMKIRIM.STOCKM_NORANGKA = TRXN_STOCK.STOCK_NoRangka LEFT OUTER JOIN TRXN_STOCKKKIRIM ON TRXN_STOCK.STOCK_NoRangka = TRXN_STOCKKKIRIM.STOCKK_NORANGKA WHERE (YEAR(TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM) >= 2018) AND (DATEDIFF(DAY,TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM,GETDATE()) > 0) AND (TRXN_STOCKKKIRIM.STOCKK_NORANGKA IS NULL) ORDER BY TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM, TRXN_STOCKMKIRIM.STOCKM_KDDEALER"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">

            </asp:SqlDataSource>                 
            <asp:ListView ID="LvJdwNoSPJ" runat="server" DataSourceID="SdsTabelJdwNoSPJ" DataKeyNames ="STOCKM_NORANGKA"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead  style="background-color:Silver; height:30px"><th>Nomor Rangka</th><th>Dealer</th><th>Sales</th><th>Tgl Input</th><th>Tgl Mohon</th><th>Tgl Kirim</th><th>Tgl SPJ</th><th>Terima</th><th>Keterangan</th><th>Berita</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="50" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate><tr>
                <td style="width:9%; font-size: small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("STOCKM_NORANGKA") %>' CommandName="Select" runat="server" /></td>
                <td style="width:5%; font-size: small"><%#Eval("STOCKM_KDDEALER")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKM_SALES")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKM_TGLMOHONINPUT")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKM_TGLMOHONKIRIM")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKM_KIRIMTGLSETUJUI")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKK_KIRIMTGLKIRIM")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKK_KIRIMTGLTERIMA")%></td>
                <td style="width:8%; font-size: small"><%#Eval("STOCKK_KIRIMKETTERIMA")%></td>
                <td style="width:15%; font-size: small"><%#Eval("STOCKM_BERITA")%></td>
                </tr></ItemTemplate>
                <EmptyDataTemplate>
                <center>
                <asp:Label ID="Label262" runat="server" Font-Names="Cooper Black"  
                     Font-Size="small" height= "21px" Text="Tidak ada Data Rangka" 
                     ForeColor="Black" ></asp:Label>
                </center>

                </EmptyDataTemplate> 
                <EmptyItemTemplate>
                <center>
                <asp:Label ID="Label262" runat="server" Font-Names="Cooper Black"  
                     Font-Size="small" height= "21px" Text="Tidak ada Data Rangka" 
                     ForeColor="Black" ></asp:Label>
                </center>
                </EmptyItemTemplate> 

               </asp:ListView>

             
             
             
        </asp:View>
        </asp:MultiView>
            </td>
            </tr>
            </table>        
        </asp:View>

        <asp:View ID="View02StatusPerbaikan" runat="server">
        <center>
        <asp:Label ID="Label245" runat="server" Font-Names="Cooper Black"  
                Font-Size="Medium" height= "21px" Text="Status Perbaikan" 
                ForeColor="Red"></asp:Label>
        </center>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 100%; ">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 25%; ">
               <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Cari Nomor Rangka"></asp:Label>
            </td>
            <td style="width: 25%; ">
               <asp:TextBox ID="txtCariRangkaRepair" text="" runat="server" Width="250px" 
                    CssClass="uppercase"></asp:TextBox>
            </td>
            <td style="width: 75%; ">
               <asp:Button ID="btnfilter" runat="server" Text=" <---- Pencarian Pemasang Asesoris berdasarakan nomor rangka" 
                    Width="413px" BackColor="#0033CC" />
            </td>
        </tr>
        </table>
            <asp:SqlDataSource ID="sdsTabelRepair" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM [TRXN_STOCKAREPAIR] WHERE (TRXN_STOCKAREPAIR.ASSREPAIR_NORANGKA LIKE '%' + ? + '%') ORDER BY ASSREPAIR_TGLINPUT DESC"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>"
            >
                <SelectParameters>
                <asp:ControlParameter ControlID="txtCariRangkaRepair"  Name="ASSREPAIR_NORANGKA" PropertyName="Text" Type="String" DefaultValue="%"  />            
                </SelectParameters>
            </asp:SqlDataSource>   
            <asp:ListView ID="lvBerita" runat="server" DataSourceID="sdsTabelRepair" DataKeyNames ="ASSREPAIR_NORANGKA"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead style="background-color:Silver; height:30px"><th>Nomor Rangka</th><th>Input</th><th>Email</th><th>Setuju</th><th>WO</th><th>NO WO</th><th>Bengkel</th><th>Keterangan WO</th><th>Rincian Kerjaan</th><th>Jenis</th><th>Harga</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="15" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate>
                <tr><td style="width:10%; font-size: x-small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("ASSREPAIR_NORANGKA") %>' CommandName="Select" runat="server" /></td>
                <td style="width:8%; font-size: x-small"><%#Eval("ASSREPAIR_TGLINPUT")%></td>
                <td style="width:8%; font-size: x-small"><%#Eval("ASSREPAIR_TGLEMAIL")%></td>
                <td style="width:8%; font-size: x-small"><%#Eval("ASSREPAIR_TGLSETUJU")%></td>
                <td style="width:8%; font-size: x-small"><%#Eval("ASSREPAIR_TGLWO")%></td>
                <td style="width:6%; font-size: x-small"><%#Eval("ASSREPAIR_NOMOHON")%></td>
                <td style="width:6%; font-size: x-small"><%#Eval("ASSREPAIR_KODEDLR")%></td>
                <td style="width:20%; font-size: x-small"><%#Eval("ASSREPAIR_KETERANGAN")%></td>
                <td style="width:20%; font-size: x-small"><%#Eval("ASSREPAIR_RINCIAN")%></td>
                <td style="width:20%; font-size: x-small"><%#Eval("ASSREPAIR_KDASS")%></td>
                <td style="width:6%; font-size: x-small"><%#Eval("ASSREPAIR_HARGA")%></td>
                </tr></ItemTemplate></asp:ListView>
                </td>
            </tr>
            </table>
        </asp:View>                    

        <asp:View ID="View03Stok" runat="server">

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 25%; ">
               <asp:Button ID="BtnTTKClear" runat="server" Text="Bersihkan" Width="99%" 
                    BackColor="Gray" Font-Bold="True" ForeColor="Black" Height="50px"  />
            </td>
            <td style="width: 25%; ">
               <asp:Button ID="BtnTTKSave" runat="server" Text="Simpan" Width="99%" 
                    BackColor="Gray" Font-Bold="True" ForeColor="Black" Height="50px"  />
            </td>
            <td style="width: 25%; ">
               <asp:Button ID="BtnTTKBatal" runat="server" Text="Batal" Width="99%" 
                    BackColor="Red" Font-Bold="True" ForeColor="Yellow" Height="50px"  />
            </td>
            <td style="width: 25%; ">
                &nbsp;</td>
        </tr>
        </table>
        <br />
        <center>
        <asp:Label ID="Label246" runat="server" Font-Names="Cooper Black"  
                Font-Size="Medium" height= "21px" Text="Detail Stok" 
                ForeColor="Red"></asp:Label>
        </center>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%;background-color:#CCCCFF;">
                    <asp:Button ID="BtnF2NoTTK" runat="server" BorderStyle="None" 
                        Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" 
                        Font-Underline="True" ForeColor="#0000A0" Text="No TTK   " Width="99px" 
                        BackColor="#CCCCFF" />
                </td>
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:TextBox ID="TxtNoTTK" runat="server" text="" Width="99%" MaxLength="7" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 15%; background-color:#CCCCFF; ">
                    <asp:Label ID="lblNoTTKTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Visible="false"  Text="Tag"></asp:Label></td>
                <td style="width: 35%; background-color:#CCCCFF; ">
                    <asp:Button ID="ButtonCariTTK" runat="server" BackColor="Blue" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Perbarui Data" /></td> 
            </tr>
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl TTK"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="lblTGLTTK" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="No TTK"></asp:Label></td>
                <td style="width: 15%; ">
                    <asp:Label ID="NoBTL" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"  Visible="false" Text="NoBtl"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="DTglTemp" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"  Visible="false" Text="DTglTemp"></asp:Label></td>
            </tr>
        </table> 
        <asp:MultiView ID="MultiViewTabelStok" runat="server" Visible="TRUE">
        <asp:View ID="View21" runat="server">
            <asp:SqlDataSource ID="sdsTabelStok" runat="server" 
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
                SelectCommand="SELECT * FROM TRXN_STOCK WHERE ([STOCK_NOTTK] LIKE '%' + ? + '%') AND ([STOCK_NORANGKA] LIKE '%' + ? + '%')"                     
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                <SelectParameters>
                <asp:ControlParameter ControlID="TxtNoTTK" Name="STOCK_NOTTK" PropertyName="Text" Type="String" DefaultValue ="%"  />
                <asp:ControlParameter ControlID="TxtNoRangka" Name="STOCK_NORANGKA" PropertyName="Text" Type="String" DefaultValue ="%"  />
                </SelectParameters>
            </asp:SqlDataSource>                 
            <asp:ListView ID="LvDataTabelStok" runat="server" DataSourceID="sdsTabelStok" DataKeyNames ="STOCK_NOTTK"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead style="background-color:Silver; height:30px"><th>No TTK</th><th>Tgl TTK</th><th>Nomor Rangka</th><th>Tipe</th><th>Warna</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpAksesoris" PageSize="20" runat="server" ><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false"   /><asp:NumericPagerField  /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate><tr><td style="width:10%; font-size: x-small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("STOCK_NOTTK") %>' CommandName="Select" runat="server" /></td><td style="width:40%; font-size: x-small"><%#Eval("STOCK_TglTTK")%></td><td style="width:40%; font-size: x-small"><%#Eval("STOCK_NORANGKA")%></td><td style="width:40%; font-size: x-small"><%#Eval("STOCK_CDTYPE")%></td><td style="width:40%; font-size: x-small"><%#Eval("STOCK_CDWARNA")%></td></tr></ItemTemplate></asp:ListView>
        </asp:View> 
        </asp:MultiView>

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 17%; ">
               <asp:Button ID="BtnStok1" runat="server" Text="Detail" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Height="40px"  />
            </td>
            <td style="width: 17%; ">
               <asp:Button ID="BtnStok2" runat="server" Text="Pengiriman" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Height="40px"  />
            </td>
            <td style="width: 16%; ">
               <asp:Button ID="BtnStok3" runat="server" Text="Perbaikan" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Height="40px"  />
            </td>
            <td style="width: 16%; ">
               <asp:Button ID="BtnStok4" runat="server" Text="STCK" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Height="40px"  />
            </td>
            <td style="width: 17%; ">
               <asp:Button ID="BtnStok5" runat="server" Text="Aksesoris" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Height="40px"  />
            </td>
            <td style="width: 17%; ">
               <asp:Button ID="BtnStok6" runat="server" Text="History" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Height="40px"  />
            </td>

        </tr>
        </table>
        <br />
        <asp:MultiView ID="Multi03Stok" runat="server" Visible="TRUE">
        <asp:View ID="View03StokDetilRangka" runat="server">
        <center>
        <asp:Label ID="Label247" runat="server" Font-Names="Cooper Black"  
                Font-Size="Medium" height= "21px" Text="Spesifikasi" 
                ForeColor="Red"></asp:Label>
        </center>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 100%; ">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color:#CCCCFF;">
                    <asp:Button ID="BtnF2NoRangka" runat="server" BackColor="#CCCCFF" 
                        BorderStyle="None" Font-Bold="True" Font-Italic="True" Font-Overline="False" 
                        Font-Size="Small" Font-Underline="True" ForeColor="Blue" Text="No Rangka"   />
                </td>
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:TextBox ID="TxtNoRangka" runat="server" text="" Width="99%" MaxLength="20" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 15%; background-color:#CCCCFF">
                    &nbsp;</td> 
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:Label ID="lblNoRangkaTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"  Visible="false" Text="lblNoRangkaTag"></asp:Label></td>
            </tr>
            </table>
            <asp:MultiView ID="MultiViewStockImora" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
            <asp:SqlDataSource ID="SqlDataStockDoImora" runat="server" 
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
                SelectCommand="SELECT *, 
                              (SELECT STOCK_NOTTK FROM TRXN_STOCK WHERE STOCK_NoRangka = STOCKDO_NORANGKA) AS NoTTK 
                              FROM TRXN_STOCKDO WHERE ([STOCKDO_NORANGKA] LIKE '%' + ? + '%') ORDER BY STOCKDO_NOTTK,STOCKDO_KODEDLR"
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                <SelectParameters>
                <asp:ControlParameter ControlID="TxtNoRangka" Name="STOCKDO_NORANGKA" PropertyName="Text" Type="String"  DefaultValue ="%" />
                </SelectParameters>
            </asp:SqlDataSource>                 
            <asp:ListView ID="LvDataStockDoImora" runat="server" DataSourceID="SqlDataStockDoImora" DataKeyNames ="STOCKDO_NORANGKA"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead style="background-color:Silver; height:30px"><th>NO. Rangka</th><th>Dealer</th><th>No TTK</th><th>No DO Suplier</th><th>Tgl DO Suplier</th><th>Warna</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpAksesoris" PageSize="20" runat="server" ><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false"   /><asp:NumericPagerField  /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate><tr><td style="width:15%; font-size: x-small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("STOCKDO_NORANGKA") %>' CommandName="Select" runat="server" /></td><td style="width:5%; font-size: x-small"><%#Eval("STOCKDO_KODEDLR")%></td><td style="width:20%; font-size: x-small"><%#Eval("NoTTK")%></td><td style="width:20%; font-size: x-small"><%#Eval("STOCKDO_NODOSPL")%></td><td style="width:20%; font-size: x-small"><%#Eval("STOCKDO_TGDOSPL")%></td><td style="width:20%; font-size: x-small"><%#Eval("STOCKDO_WARNADOSPLDESC")%></td></tr></ItemTemplate></asp:ListView>
            </asp:View> 
            </asp:MultiView>

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%;">
                    <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="No Mesin"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtNoMesin" runat="server" text="" Width="99%" MaxLength="15" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 15%; ">
                    <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="No Kunci"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtNoKunci" runat="server" text="" Width="99%" MaxLength="6" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            </table> 
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Button ID="BtnF2Tipe" runat="server" BackColor="Black" BorderStyle="None" 
                        Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" 
                        Font-Underline="True" ForeColor="Blue" Text="Kode Tipe" />
                </td>
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:TextBox ID="TxtCdType" runat="server" text="" Width="20%" MaxLength="7" CssClass="uppercase"></asp:TextBox>
                    <asp:Label ID="lblCdTypeTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"  Visible="false" Text="lblCdTypeTag"></asp:Label></td>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama Tipe"></asp:Label></td>
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:Label ID="NamaType" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label></td>
            </tr>
            </table> 
            <asp:MultiView ID="MultiViewType" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
            <asp:SqlDataSource ID="SqlDataType" runat="server" 
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
                SelectCommand="SELECT * FROM DATA_TYPE WHERE ([TYPE_Nama] LIKE '%' + ? + '%') ORDER BY TYPE_Type"
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                <SelectParameters>
                <asp:ControlParameter ControlID="TxtCdType" Name="TYPE_Type" PropertyName="Text" Type="String"  DefaultValue ="%" />
                </SelectParameters>
            </asp:SqlDataSource>                 
            <asp:ListView ID="LvDataType" runat="server" DataSourceID="SqlDataType" DataKeyNames ="TYPE_Type"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead style="background-color:Silver; height:30px"><th>Kode </th><th>Tipe</th><th>Group</th><th>Key </th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpAksesoris" PageSize="20" runat="server" ><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false"   /><asp:NumericPagerField  /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate><tr><td style="width:10%; font-size: x-small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("TYPE_Type") %>' CommandName="Select" runat="server" /></td><td style="width:50%; font-size: x-small"><%#Eval("TYPE_Nama")%></td><td style="width:20%; font-size: x-small"><%#Eval("TYPE_CdGroup")%></td><td style="width:20%; font-size: x-small"><%#Eval("TYPE_CdRangka")%></td></tr></ItemTemplate></asp:ListView>
            </asp:View> 
            </asp:MultiView>
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #FFFF80;">
                    <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Definisi Tipe Imora"></asp:Label></td>
                <td style="width: 15%; background-color: #FFFF80;">
                    <asp:Label ID="KodeTypeImora" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label></td>
                <td style="width: 35%; background-color: #FFFF80;">
                    <asp:Label ID="NamaTypeImora" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label></td>
                <td style="width: 35%; background-color: #FFFF80;">
                    <asp:Label ID="lblMugenImoraType" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label></td>
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Button ID="BtnF2Warna" runat="server" BackColor="#CCCCFF" BorderStyle="None" 
                        Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" 
                        Font-Underline="True" ForeColor="Blue" Text="Kode Warna" />
                </td>
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:TextBox ID="TxtCdWarna" runat="server" text="" Width="20%" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    <asp:Label ID="lblCdWarnaTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Visible="false"  Text="lblCdWarnaTag"></asp:Label></td>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama Warna"></asp:Label></td>
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:Label ID="NamaWarna" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label></td>
            </tr>
            </table> 
            <asp:MultiView ID="MultiViewWarna" runat="server" Visible="TRUE">
            <asp:View ID="View3" runat="server">
            <asp:SqlDataSource ID="SqlDataWarna" runat="server" 
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
                SelectCommand="SELECT * FROM DATA_WARNA WHERE ([WARNA_Kode] LIKE '%' + ? + '%') ORDER BY WARNA_Kode"
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                <SelectParameters>
                <asp:ControlParameter ControlID="TxtCdWarna" Name="WARNA_Kode" PropertyName="Text" Type="String"  DefaultValue ="%" />
                </SelectParameters>
            </asp:SqlDataSource>                 
            <asp:ListView ID="LvWarna" runat="server" DataSourceID="SqlDataWarna" DataKeyNames ="WARNA_Kode"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead style="background-color:Silver; height:30px"><th>Kode </th><th>Kode HPM</th><th>Internal</th><th>External</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpAksesoris" PageSize="20" runat="server" ><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false"   /><asp:NumericPagerField  /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate><tr><td style="width:10%; font-size: x-small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("WARNA_Kode") %>' CommandName="Select" runat="server" /></td><td style="width:50%; font-size: x-small"><%#Eval("WARNA_KODEHPM")%></td><td style="width:20%; font-size: x-small"><%#Eval("WARNA_Int")%></td><td style="width:20%; font-size: x-small"><%#Eval("WARNA_Ext")%></td></tr></ItemTemplate></asp:ListView>
            </asp:View> 
            </asp:MultiView>
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #FFFF80;">
                    <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Definisi Warna Imora"></asp:Label></td>
                <td style="width: 15%; background-color: #FFFF80;">
                    <asp:Label ID="KodeWarnaImora" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label></td>
                <td style="width: 35%; background-color: #FFFF80;">
                    <asp:Label ID="KodeWarnaImoraTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label>
                    <asp:Label ID="NamaWarnaImora" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label></td>
                <td style="width: 35%; background-color: #FFFF80;">
                    <asp:Label ID="KodeWarnaImoraMugen" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label></td>
            </tr>
            </table> 
            <center>
        <asp:Label ID="Label248" runat="server" Font-Names="Cooper Black"  
                Font-Size="Medium" height= "21px" Text="Detail Suplier dan surat-surat" 
                ForeColor="Red"></asp:Label>
        </center>
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tahun"></asp:Label></td>
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:TextBox ID="TxtTahun" runat="server" text="" Width="99%" MaxLength="2" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl DO Imora"></asp:Label></td>
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:TextBox ID="TxtDtTglDoIm" runat="server" />
                    <asp:Button ID="BtnCal2" runat="server" Text=".." Width="27px" />
                    <div id="Div1">
                    <asp:Calendar ID="Calendar2" runat="server" onselectionchanged="Calendar2_SelectionChanged" />
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label50" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Surat Jalan"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtDtglSuratJln" runat="server" />
                    <asp:Button ID="BtnCal4" runat="server" Text=".." Width="27px" />
                    <div id="Div3">
                    <asp:Calendar ID="Calendar4" runat="server" onselectionchanged="Calendar4_SelectionChanged" />
                    </div>
                </td>
                <td style="width: 15%; ">
                    <asp:Label ID="Label51" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="No Surat Jalan"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtNoDO" runat="server" text="" Width="100%" MaxLength="10" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            </table> 
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Button ID="BtnF2Suplier" runat="server" BackColor="#CCCCFF" 
                        BorderStyle="None" Font-Bold="True" Font-Italic="True" Font-Overline="False" 
                        Font-Size="Small" Font-Underline="True" ForeColor="Blue" Text="Kode Suplier" />
                </td>
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:TextBox ID="TxtCdSuplier" runat="server" text="" Width="10%" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    <asp:Label ID="lblCdSuplierTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Faktur > Nama" Visible="false"  ></asp:Label>
                    <asp:Label ID="nmSuplier" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Width="90%" Text=""></asp:Label></td>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Terima Unit"></asp:Label></td>
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:TextBox ID="TxtDTglDO" runat="server" />
                    <asp:Button ID="BtnCal3" runat="server" Text=".." Width="27px" />
                    <div id="Div2">
                    <asp:Calendar ID="Calendar3" runat="server" onselectionchanged="Calendar3_SelectionChanged" />
                    </div>
                </td>
            </tr>
            </table> 
            <asp:MultiView ID="MultiViewSuplier" runat="server" Visible="TRUE">
            <asp:View ID="View4" runat="server">
            <asp:SqlDataSource ID="SqlDataSuplier" runat="server" 
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
                SelectCommand="SELECT * FROM DATA_SUPLIER WHERE [SUPLIER_Kode] LIKE 'S%' AND ([SUPLIER_Kode] LIKE '%' + ? + '%') ORDER BY SUPLIER_Kode"
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                <SelectParameters>
                <asp:ControlParameter ControlID="TxtCdSuplier" Name="SUPLIER_Kode" PropertyName="Text" Type="String"  DefaultValue ="%" />
                </SelectParameters>
            </asp:SqlDataSource>                 
            <asp:ListView ID="LvSuplier" runat="server" DataSourceID="SqlDataSuplier" DataKeyNames ="SUPLIER_Kode"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead style="background-color:Silver; height:30px"><th>Kode </th><th>Nama</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpAksesoris" PageSize="20" runat="server" ><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false"   /><asp:NumericPagerField  /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate><tr><td style="width:10%; font-size: x-small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("SUPLIER_Kode") %>' CommandName="Select" runat="server" /></td><td style="width:50%; font-size: x-small"><%#Eval("SUPLIER_Nama")%></td></tr></ItemTemplate></asp:ListView>
            </asp:View> 
            </asp:MultiView>
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; ">
                    <asp:Button ID="BtnF2Lokasi" runat="server" BackColor="White" 
                        BorderStyle="None" Font-Bold="True" Font-Italic="True" Font-Overline="False" 
                        Font-Size="Small" Font-Underline="True" ForeColor="Blue" Text="Kode Lokasi" />
                </td>
                <td style="width: 85%; ">
                    <asp:TextBox ID="TxtcdLokasi" runat="server" text="" Width="10%" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    <asp:Label ID="lblcdLokasiTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Faktur > Nama" Visible="false"  ></asp:Label>
                    <asp:Label ID="NamaLokasi" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label>
                    <asp:Label ID="Kodedealer" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label>
                    <asp:Label ID="KodedealerTag" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" Visible="False"></asp:Label>
                </td>
            </tr>
            </table> 
            <asp:MultiView ID="MultiViewLokasi" runat="server" Visible="TRUE">
            <asp:View ID="View5" runat="server">
            <asp:SqlDataSource ID="SqlDataLokasi" runat="server" 
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
                SelectCommand="SELECT * FROM DATA_LOKASI WHERE ([LOKASI_Kode] LIKE '%' + ? + '%') ORDER BY LOKASI_Kode"
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                <SelectParameters>
                <asp:ControlParameter ControlID="TxtcdLokasi" Name="LOKASI_Kode" PropertyName="Text" Type="String"  DefaultValue ="%" />
                </SelectParameters>
            </asp:SqlDataSource>                 
            <asp:ListView ID="LvLokasi" runat="server" DataSourceID="SqlDataLokasi" DataKeyNames ="LOKASI_Kode"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead style="background-color:Silver; height:30px"><th>Kode </th><th>Nama</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpAksesoris" PageSize="20" runat="server" ><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false"   /><asp:NumericPagerField  /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate><tr><td style="width:10%; font-size: x-small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("LOKASI_Kode") %>' CommandName="Select" runat="server" /></td><td style="width:50%; font-size: x-small"><%#Eval("LOKASI_Nama")%></td></tr></ItemTemplate></asp:ListView>
            </asp:View> 
            </asp:MultiView>
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Label ID="Label18" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Lokasi Cross seling"></asp:Label></td>
                <td style="width: 85%; background-color:#CCCCFF">
                    <asp:Label ID="LblCrsSellMugen" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label21" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Keterangan"></asp:Label></td>
                <td style="width: 85%; ">
                    <asp:TextBox ID="TxtKeterangan" runat="server" text="" Width="99%" 
                        MaxLength="25" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Label ID="Label22" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Alasan Batal TTK"></asp:Label></td>
                <td style="width: 85%; background-color:#CCCCFF">
                    <asp:TextBox ID="TxtAlasanBatal" runat="server" text="" Width="99%" 
                        MaxLength="50" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%;  height: 28px;">
                    <asp:Label ID="Label260" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Status Rangka"></asp:Label></td>
                <td style="width: 85%;  height: 28px;">
                    <asp:CheckBox ID="CheckBoxBlokSales" Text="UNIT SEDANG BERMASALAH TIDAK BOLEH DIJUAL"  runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 15%;  height: 28px;"></td>
                <td style="width: 85%;  height: 28px;">
                    <asp:CheckBox ID="CheckBoxBlokUnit" Text="UNIT SEDANG DIPERBAIKI BELUM DIBUAT TANDA TERIIMA HPM"  runat="server" />
                </td>
            </tr>

            <tr>
                <td style="width: 15%; background-color:#CCCCFF;">
                    <asp:Label ID="Label19" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Status"></asp:Label></td>
                <td style="width: 85%; background-color:#CCCCFF;">
                    <asp:Label ID="LblStatus" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px"></asp:Label>
                    <asp:Label ID="LblTagChekBlokSales1" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                    <asp:Label ID="LblTagChekBlokUnit1" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                    <asp:Label ID="LblTagLokasi" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                    <asp:Label ID="LblTagLokasi0" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label264" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Diperiksa Oleh"></asp:Label></td>
                <td style="width: 85%; ">                    
                    <asp:Button ID="BtnValidOkHead" runat="server" BackColor="Green" 
                        Font-Overline="False" Font-Size="Medium" Height="20px" 
                        Text="Ok  " ForeColor="White" Font-Bold="True" />
                    <asp:Label ID="Label268" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px">__/__</asp:Label>
                    <asp:Button ID="BtnValidNotOkHead" runat="server" BackColor="Red" 
                        Font-Overline="False" Font-Size="Medium" Height="20px" 
                        Text="No OK" ForeColor="White" Font-Bold="True" />

                    <asp:Label ID="LblPeriksaSpasi" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px">_______</asp:Label>

                    <asp:Label ID="LblPeriksaUser" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                    <asp:Label ID="LblPeriksaTglStrip" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"> / </asp:Label>
                    <asp:Label ID="LblPeriksaTgl" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </td>
            </tr>



            </table> 
            </td>
            </tr>
            </table>

        </asp:View>
        <asp:View ID="View03StokDetailPengirian" runat="server">
        <table style="padding: 3px; border: thin solid #000000; width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr> 
            <td style="width: 100%; ">
            <center>

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 30%; ">
                    <asp:Button ID="BtnAlmKirim" runat="server" BackColor="Olive" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="klik tampil Alamat Kirim" ForeColor="Yellow" />
                </td>
                <td style="width: 30%; ">
                    <asp:Button ID="BtnSPKKirim" runat="server" BackColor="Olive" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="klik tampil Alamat SPK" ForeColor="Yellow" />
                </td>
                <td style="width: 30%; ">
                    <asp:Button ID="BtnSTNKirim" runat="server" BackColor="Olive" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Klik tampil Alamat STNK" ForeColor="Yellow" />
                </td>

            </tr>
            
            </table> 
            
            
            <asp:Label ID="Label249" runat="server" Font-Names="Cooper Black"  
                Font-Size="Medium" height= "21px" Text="Alamat Pengiriman" 
                ForeColor="Red"></asp:Label>
            </center>
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; border-width: thin; border-style: none none solid none; border-color: #000000; background-color:#CCCCFF"></td>
                <td style="width: 35%; border-width: thin; border-style: none none solid none; border-color: #000000; background-color:#CCCCFF"></td>
                <td style="width: 15%; border-width: thin; border-style: none none solid none; border-color: #000000; background-color:#CCCCFF"></td>
                <td style="width: 35%; border-width: thin; border-style: none none solid none; border-color: #000000; background-color:#CCCCFF">
                    <asp:Button ID="ButtonCariTTK0" runat="server" BackColor="Yellow" 
                        Font-Overline="False" Font-Size="Small" Height="20px" Text="Ubah Alamat Kirim" 
                        ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Label ID="Label27" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:TextBox ID="TxtNama" runat="server" text="" Width="90%" MaxLength="35" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Label ID="Label24" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="No HP"></asp:Label></td>
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:TextBox ID="TxtNoHP" runat="server" text="" Width="90%" MaxLength="20" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; border-color: #000000; border-style: none; border-width: thin; ">
                    <asp:Label ID="Label25" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Alamat"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtAlamat" runat="server" text="" Width="90%" MaxLength="80" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 15%; ">
                    <asp:Label ID="Label61" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="No Phone"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtPhone" runat="server" text="" Width="90%" MaxLength="20" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Label ID="Label63" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Kota"></asp:Label></td>
                <td style="width: 35%; background-color:#CCCCFF">
                    <asp:TextBox ID="TxtKota" runat="server" text="" Width="90%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 15%; background-color:#CCCCFF"></td>
                <td style="width: 35%; background-color:#CCCCFF"></td>
            </tr>
            </table> 
            
            
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label29" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Berita"></asp:Label></td>
                <td style="width: 85%; ">
                    <asp:TextBox ID="TxtBerita" runat="server" text="" Width="100%" MaxLength="30" 
                        CssClass="uppercase"></asp:TextBox></td>
            </tr>
            </table> 
            
            <center>
        
        <asp:Label ID="Label250" runat="server" Font-Names="Cooper Black"  
                Font-Size="Medium" height= "21px" Text="Detail Pengiriman" 
                ForeColor="Red"></asp:Label>
        </center>

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">

            </table> 



            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style=" width: 15%; border: thin solid #000000;background-color:#CCCCFF">
                    <asp:Label ID="Label23" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "100%" Text="Tgl Mohon/Admin Stok" Width="100px" Font-Bold="False" 
                        ></asp:Label>
                </td>
                <td style="border: thin solid #000000; width: 85%; background-color:#CCCCFF">
                    <asp:Label ID="lblTglAdmin" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "100%" Text="99/99/99" ></asp:Label>
                    <asp:Label ID="Label252" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "100%" Text="/" ></asp:Label>
                    <asp:Label ID="LblUsrAdmin" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "100%" Text="User Pemohon" ></asp:Label>
                 </td> 
            </tr>
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; border: thin solid #000000;background-color:#CCCCFF">
                    <asp:Label ID="Label26" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "100%" Text="Nama Supir" ></asp:Label></td>
                <td style="border-style: solid none solid solid; border-width: thin; border-color: #000000; width: 65%;">
                    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                    <asp:Label ID="lblNmSupir" runat="server" Font-Names="Arial" Font-Size="Small" height= "100%" Text="Nama Supir"></asp:Label></td>
                <td style="border-style: solid none solid solid; border-width: thin; border-color: #000000; width: 10%; ">
                    <asp:Button ID="BtnSmp03" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" Width="99%" /></td> 
                <td style="border-style: solid solid solid none; border-width: thin; border-color: #000000; width: 10%; ">
                    &nbsp;</td> 
            </tr>
            </table>         
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td rowspan="2" style="width: 15%; background-color:#CCCCFF; border: thin solid #000000;background-color:#CCCCFF">Tgl Kirim Disetujui</td>
                <td style="border-width: thin; border-color: #000000; width: 25%; background-color:#CCCCFF; border-top-style: solid; border-left-style: solid;">Tgl Kirim Disetujui</td>
                <td style="border-width: thin; border-color: #000000; width: 40%; background-color:#CCCCFF; border-top-style: solid;">Alasan Ubah Tgl Kirim</td>
                <td style="border-style: solid none none solid; border-width: thin; border-color: #000000; width: 10%; background-color:#CCCCFF"></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; background-color:#CCCCFF; border-top-style: solid; border-right-style: solid;"></td>
            </tr>
            <tr>
                <td style="border-style: none none solid solid; border-width: thin; border-color: #000000; width: 25%; ">
                        <asp:TextBox ID="TxttglKirimSetujui" runat="server" />
                        <asp:Button ID="BtnCall5" runat="server" Text=".." Width="27px" />
                        <div id="Div4">
                        <asp:Calendar ID="Calendar5" runat="server" onselectionchanged="Calendar5_SelectionChanged" />
                        </div>
                </td>
                <td style="border-width: thin; border-color: #000000; width: 40%; border-bottom-style: solid;">
                        <asp:TextBox ID="TxtAlasanRubahTglKirim" runat="server" text="" Width="100%" MaxLength="50"                                 CssClass="uppercase"></asp:TextBox></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; border-left-style: solid; border-bottom-style: solid;">
                    <asp:Button ID="BtnSmp04" runat="server" BackColor="#80FF00"   Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan"                         Width="99%" /></td> 
                <td style="border-width: thin; border-color: #000000; width: 10%; border-bottom-style: solid; border-right-style: solid;">
                    <asp:Button ID="BtnBtl04" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal"                         Width="99%"  /></td> 
            </tr>
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td rowspan="3" style="width: 15%; border: thin solid #000000;background-color:#CCCCFF">Tgl PDI</td>
                <td style="border-width: thin; border-color: #000000; width: 25%; background-color:#CCCCFF; border-top-style: solid; border-left-style: solid;">Tgl PDI</td>
                <td style="border-width: thin; border-color: #000000; width: 40%; background-color:#CCCCFF; border-top-style: solid;">Alasan Ubah Tgl Kirim</td>
                <td style="border-width: thin; border-color: #000000; width: 10%; background-color:#CCCCFF; border-top-style: solid; border-left-style: solid;"></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; background-color:#CCCCFF; border-right-style: solid; border-top-style: solid;"></td>
            </tr>
            <tr>
                <td style="border-width: thin; border-color: #000000; width: 25%; border-left-style: solid;">
                        <asp:TextBox ID="TxttglPDI" runat="server" />
                        <asp:Button ID="BtnCall6" runat="server" Text=".." Width="27px" />
                        <div id="Div5">
                        <asp:Calendar ID="Calendar6" runat="server" onselectionchanged="Calendar6_SelectionChanged" />
                        </div>
                        </td>
                <td style="width: 40%;">
                        <asp:TextBox ID="TxttglPDINote" runat="server" text="" Width="99%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; border-left-style: solid;">
                <asp:Button ID="BtnSmp05" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" Width="99%" /></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; border-right-style: solid;">
                    <asp:Button ID="BtnBtl05" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" Width="99%"  /></td>
            </tr>
            <tr>
                <td style="border-width: thin; border-color: #000000; width: 25%; border-left-style: solid; border-bottom-style: solid;"></td>
                <td style="border-width: thin; border-color: #000000; width: 20%; border-bottom-style: solid;">
                    <asp:Button ID="btnPrintPDIR" runat="server" Text="Isi Data Print PDI" 
                        BackColor="Blue" Width="35%" />
                    <asp:Button ID="btnPrintPDI" runat="server" Text="Print PDI" 
                        OnClientClick = "return PrintPanel();" BackColor="Blue" Width="35%"/>
                </td>
                <td style="border-width: thin; border-color: #000000; width: 10%; border-bottom-style: solid; border-left-style: solid;"></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; border-right-style: solid; border-bottom-style: solid;"></td>
            </tr>
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td rowspan="3" style="width: 15%; background-color:#CCCCFF; border: thin solid #000000;background-color:#CCCCFF">Cetak DO (Disetju Admin)</td>
                <td style="border-width: thin; border-color: #000000; width: 25%; background-color:#CCCCFF; border-top-style: solid; border-left-style: solid;">Tgl Disetujui</td>
                <td style="border-width: thin; border-color: #000000; width: 60%; background-color:#CCCCFF; border-top-style: solid; border-right-style: solid;">Oleh</td>
            </tr>

            <tr>
                <td style="border-width: thin; border-color: #000000; width: 25%; border-left-style: solid;">
                    <asp:Label ID="LblCetakDOTgl" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="Tanggal"></asp:Label>
                </td>                 
                <td style="border-width: thin; border-color: #000000; width: 60%; border-right-style: solid;">
                    <asp:Label ID="LblCetakDOUsr" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="Admin"></asp:Label>
                </td>                 
            </tr>
            <tr>
                <td style="border-width: thin; border-color: #000000; width: 25%; border-left-style: solid; border-bottom-style: solid;"></td>
                <td style="border-width: thin; border-color: #000000; width: 60%; border-bottom-style: solid; border-right-style: solid;">
                        <asp:Button ID="btnGetdataDO" runat="server" Text="Isi Data Print DO" 
                            Width="35%" BackColor="Blue" />
                        <asp:Button ID="btnPrintDO" runat="server" Text="Print DO"   
                            OnClientClick = "return PrintPanel();" BackColor="Blue" Width="35%"/>
                </td>                 
            </tr>
            </table>             
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; border: thin solid #000000;background-color:#CCCCFF">
                    <asp:Label ID="Label37" runat="server" Font-Names="Arial" Font-Size="Small" height= "100%" Text="Tgl Aproval Cetak DO" Width="100%"></asp:Label></td>
                <td style="width: 65%;">
                    <asp:TextBox ID="TxttglCetakDO" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox>
                </td>                 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp12" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" Width="100%" /></td>                 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl12" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="100%"  /></td>                 
            </tr>
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td rowspan="2" style="width: 15%; background-color:#CCCCFF; border: thin solid #000000;background-color:#CCCCFF">Buku Service</td>
                <td style="border-style: solid none none solid; border-width: thin; border-color: #000000; width: 25%; background-color:#CCCCFF; ">Input Tgl Buku Service</td>
                <td style="border-width: thin; border-color: #000000; width: 40%; background-color:#CCCCFF; border-top-style: solid;">Keterangan</td>
                <td style="border-width: thin; border-color: #000000; width: 10%; background-color:#CCCCFF; border-top-style: solid; border-left-style: solid;"></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; background-color:#CCCCFF; border-top-style: solid; border-right-style: solid;"></td>
            </tr>
            <tr>
                <td style="border-width: thin; border-color: #000000; width: 25%; border-left-style: solid; border-bottom-style: solid;">
                        <asp:TextBox ID="TxtTglBukuSvc" runat="server" />
                        <asp:Button ID="BtnCall12" runat="server" Text=".." Width="27px" />
                        <div id="Div11">
                        <asp:Calendar ID="Calendar12" runat="server" onselectionchanged="Calendar12_SelectionChanged" />
                        </div>
                </td>
                <td style="border-width: thin; border-color: #000000; width: 40%; border-bottom-style: solid;">
                        <asp:TextBox ID="TxtBukuSvc" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; border-left-style: solid; border-bottom-style: solid;">
                    <asp:Button ID="BtnSmp14" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" Width="99%" /></td> 
                <td style="border-width: thin; border-color: #000000; width: 10%; border-right-style: solid; border-bottom-style: solid;">
                    <asp:Button ID="BtnBtl14" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td rowspan="2" style="width: 15%; border: thin solid #000000;background-color:#CCCCFF">Tgl Periksa Security</td>
                <td style="width: 25%; background-color:#CCCCFF; ">Input</td>
                <td style="width: 40%; background-color:#CCCCFF; ">Catatan</td>
                <td style="width: 10%; background-color:#CCCCFF"></td>
                <td style="width: 10%; background-color:#CCCCFF"></td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="TxtTglSecurity" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Periksa Security"></asp:Label></td>                  
                <td style="width: 40%; ">
                    <asp:Label ID="TxtTglSecurityNote" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Periksa Security"></asp:Label></td>                 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp07" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" Width="99%"/></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl07" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 

            
            
            <center>
            <asp:Label ID="Label58" runat="server" Font-Names="Cooper Black"  
                Font-Size="Medium" height= "21px" Text="Kendaraan Keluar Masuk dan Voucher bbm" 
                ForeColor="Red"></asp:Label>
            </center>



           <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td rowspan="3" style="width: 15%; background-color:#CCCCFF; border: thin solid #000000;background-color:#CCCCFF">Jenis Kirim Unit</td>
                <td style="width: 85%; background-color:#CCCCFF">
                <asp:Label ID="LblKirimJenis" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Periksa Security"></asp:Label>
                <asp:Label ID="Label30" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="    No Kirim.     "></asp:Label>
                <asp:Label ID="LblKirimNo" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="YYMM000"></asp:Label>
                <asp:Label ID="Label229" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="       Jika Belum pilih "></asp:Label>
                <asp:DropDownList ID="DropDownListJnsKirim" runat="server" Width="20%" AutoPostBack="true"  ></asp:DropDownList>		
                <asp:Label ID="LblKirimInputDanKirim" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="YYMM000"></asp:Label>
                </td>
            </tr>
            </table> 


           <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td rowspan="5" style="width: 15%; border: thin solid #000000;background-color:#CCCCFF">Kirim Unit/SPJ</td>
                <td style="border-width: thin; border-color: #000000; width: 25%; background-color:#CCCCFF; border-top-style: solid; border-left-style: solid;">Tgl Kirim </td>
                <td style="border-width: thin; border-color: #000000; width: 40%; background-color:#CCCCFF; border-top-style: solid;">Catatan</td>
                <td style="border-style: solid none none solid; border-width: thin; border-color: #000000; width: 10%; background-color:#CCCCFF"></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; background-color:#CCCCFF; border-top-style: solid; border-right-style: solid;"></td>
            </tr>

            <tr>
                <td style="border-width: thin; border-color: #000000; width: 25%; border-left-style: solid;">
                        <asp:TextBox ID="TxttglKeluar" runat="server" />
                        <asp:Button ID="BtnCall7" runat="server" Text=".." Width="27px"  />
                        <div id="Div6">
                        <asp:Calendar ID="Calendar7" runat="server" onselectionchanged="Calendar7_SelectionChanged" />
                        </div>
                </td>
                <td style="width: 40%;">
                        <asp:TextBox ID="TxttglKeluarNote" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; border-left-style: solid;">
                    <asp:Button ID="BtnSmp06" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" Width="99%" /></td> 
                <td style="border-width: thin; border-color: #000000; width: 10%; border-right-style: solid;">
                    <asp:Button ID="BtnBtl06" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 
            </tr>

            <tr>
                <td style="border-width: thin; border-color: #000000; width: 25%; border-left-style: solid;">
                <asp:Label ID="Label28" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Ongkos Kirim"></asp:Label>
                </td>
                <td style="width: 40%;">
                        <asp:TextBox ID="TxtKirimOngkos" runat="server" text="" Width="20%" MaxLength="17" CssClass="uppercase"></asp:TextBox></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; border-left-style: solid;"></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; border-right-style: solid;"></td>
            </tr>
            <tr>
                <td style="border-width: thin; border-color: #000000; width: 25%; border-left-style: solid;">
                <asp:Label ID="Label31" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Lokasi Showroom "></asp:Label>
                </td>
                <td style="width: 40%;">
                        <asp:TextBox ID="TxtKirimDealer" runat="server" text="" Width="20%" MaxLength="17" CssClass="uppercase"></asp:TextBox>
                <asp:Label ID="Label32" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="* Khusus pengiriman showrrom = SW12 pasar minggu SW28 puri kembangan"></asp:Label>
                </td>
                <td style="border-width: thin; border-color: #000000; width: 10%; border-left-style: solid;"></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; border-right-style: solid;"></td>
            </tr>
            <tr>
                <td style="border-width: thin; border-color: #000000; width: 25%; border-left-style: solid; border-bottom-style: solid;"></td>
                <td style="border-width: thin; border-color: #000000; width: 40%; border-bottom-style: solid;">
                    <asp:Button ID="btnPrintSPJR" runat="server" Text="Isi Data Print SPJ" 
                        Width="35%" BackColor="Blue" />
                    <asp:Button ID="btnPrintSPJ" runat="server" Text="Print SPJ"  Width="35%" 
                        OnClientClick = "return PrintPanel();" BackColor="Blue" />
                </td>
                <td style="border-width: thin; border-color: #000000; width: 10%; border-left-style: solid; border-bottom-style: solid;"></td>
                <td style="border-width: thin; border-color: #000000; width: 10%; border-right-style: solid; border-bottom-style: solid;"></td>
            </tr>
            </table> 
            
           <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">

            <tr>
                <td rowspan="2" style="width: 15%; background-color:#CCCCFF; border: thin solid #000000;background-color:#CCCCFF">Terima Customer</td>
                <td style="width: 25%; background-color:#CCCCFF; ">Tgl Terima</td>
                <td style="width: 40%; background-color:#CCCCFF; ">Input/Penerima</td>
                <td style="width: 10%; background-color:#CCCCFF"></td>
                <td style="width: 10%; background-color:#CCCCFF"></td>
            </tr>

            <tr>
                <td style="width: 25%; ">
                        <asp:TextBox ID="TxttglTerima" runat="server" />
                        <asp:Button ID="BtnCall10" runat="server" Text=".." Width="27px" />
                        <div id="Div9">
                        <asp:Calendar ID="Calendar10" runat="server" onselectionchanged="Calendar10_SelectionChanged" />
                        </div>
                </td>
                <td style="width: 40%; ">
                        <asp:Label ID="lbltglterimai" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Terima"></asp:Label>
                        <asp:TextBox ID="TxttglTerimaNote" runat="server" text="" Width="70%" MaxLength="30" CssClass="uppercase"></asp:TextBox>
                </td>
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp09" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl09" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 
           <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td rowspan="2" 
                    style="width: 15%; border: thin solid #000000;background-color:#FF0000">Batal Permohonannya Kirim</td>
                <td style="width: 25%; background-color:#CCCCFF; ">Tgl Input</td>
                <td style="width: 40%; background-color:#CCCCFF; ">Alasan</td>
                <td style="width: 10%; background-color:#CCCCFF"></td>
                <td style="width: 10%; background-color:#CCCCFF"></td>
            </tr>
            <tr>
                <td style="width: 25%; "> 
                    <asp:Label ID="LblTglInputHapusMohon" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Lokasi Showroom "></asp:Label></td>
                <td style="width: 40%; ">
                        <asp:TextBox ID="TxtTglBatalNote" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 10%; "></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp08" runat="server" BackColor="Red" Font-Overline="False" 
                        Font-Size="Small" Height="99%" Text="Hapus" Width="100%" /></td> 
             </tr>
            </table> 

           <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td rowspan="2" style="width: 15%;background-color:#CCCCFF; border: thin solid #000000;background-color:#CCCCFF">Catatan</td>
                <td style="width: 25%; background-color:#CCCCFF; ">Tgl Input</td>
                <td style="width: 40%; background-color:#CCCCFF; ">Catatan</td>
                <td style="width: 10%; background-color:#CCCCFF"></td>
                <td style="width: 10%; background-color:#CCCCFF"></td>
            </tr>

            <tr>
                <td style="width: 25%; "> 
                        <asp:TextBox ID="TxttglCatatan" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 40%; ">
                        <asp:TextBox ID="TxttglCatatanDsc" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp10" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl10" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 


            
            <asp:SqlDataSource ID="SdsDataStocKirim" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT [STOCKK_NORANGKA], [STOCKK_DRIVER], [STOCKK_KIRIMTGLKIRIM], 
                                  [STOCKK_KIRIMTGLTERIMA], [STOCKK_KIRIMTGLKIRIMI], [STOCKK_STATUS], 
                                  [STOCKK_KIRIMTGLTERIMAI], [STOCKK_KIRIMKETTERIMA], [STOCKK_DRIVERNM], 
                                  [STOCKK_NOKIRIM], [STOCKK_BIAYA], [STOCKK_JENIS], [STOCKK_TOMUGEN] 
                                  FROM [TRXN_STOCKKKIRIM] WHERE ([STOCKK_NORANGKA] = ?) ORDER BY STOCKK_KIRIMTGLKIRIM"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtNoRangka" Name="STOCKK_NORANGKA" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
            </asp:SqlDataSource>                 
            <asp:ListView ID="LvUnitKirimPerRangka" runat="server" DataKeyNames="STOCKK_NOKIRIM" DataSourceID="SdsDataStocKirim">
                <LayoutTemplate>
                    <table border="2" style="border-collapse:collapse;" width="100%">
                        <thead  style="background-color:Silver; height:30px">
                        <th>Nomor</th><th>Rangka</th><th>Driver</th><th>Jenis</th><th>Status</th>
                        <th>Kirim</th><th>Terima</th><th>Ongkos</th><th>Keterangan</th>
                        </thead>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
                    <asp:DataPager ID="dpBerita" runat="server" PageSize="5">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="true" 
                                ShowLastPageButton="false" ShowNextPageButton="false" 
                                ShowPreviousPageButton="true" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowFirstPageButton="false" 
                                ShowLastPageButton="true" ShowNextPageButton="true" 
                                ShowPreviousPageButton="false" />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                    <td style="width:8%; font-size:small">
                       <asp:LinkButton ID="LinkButton1" Text='<%# Eval("STOCKK_NOKIRIM") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:12%; font-size: small"><%#Eval("STOCKK_NORANGKA")%></td>
                    <td style="width:7%; font-size: small"><%#Eval("STOCKK_DRIVER")%></td>
                    <td style="width:7%; font-size: small"><%#Eval("STOCKK_JENIS")%></td>
                    <td style="width:7%; font-size: small"><%#Eval("STOCKK_STATUS")%></td>
                    <td style="width:12%; font-size: small"><%#Eval("STOCKK_KIRIMTGLKIRIM")%></td>
                    <td style="width:12%; font-size: small"><%#Eval("STOCKK_KIRIMTGLTERIMA")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("STOCKK_BIAYA")%></td>
                    <td style="width:25%; font-size: small"><%#Eval("STOCKK_DRIVERNM")%><%#Eval("STOCKK_KIRIMKETTERIMA")%><%#Eval("STOCKK_TOMUGEN")%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            





            <center>
            <asp:Label ID="Label40" runat="server" Font-Names="Cooper Black"  
                Font-Size="Medium" height= "21px" Text="Voucher BBM" 
                ForeColor="Red"></asp:Label>
            </center>

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
	            <td style="width: 15%; ">
                <asp:Label ID="Label253" runat="server" Font-Names="Arial" Font-Size="Small" height= "100%" width= "100%" Text="No BBM"  BackColor="Gray"></asp:Label></td>		
	            <td style="width: 15%; ">
                <asp:Label ID="Label254" runat="server" Font-Names="Arial" Font-Size="Small" height= "100%" width= "100%" Text="Tanggal" BackColor="Gray"></asp:Label></td>		
	            <td style="width: 15%; ">
                <asp:Label ID="Label255" runat="server" Font-Names="Arial" Font-Size="Small" height= "100%" width= "100%" Text="Jumlah" BackColor="Gray"></asp:Label></td>		
	            <td style="width: 20%; ">
                <asp:Label ID="Label256" runat="server" Font-Names="Arial" Font-Size="Small" height= "100%" width= "100%" Text="Tipe" BackColor="Gray"></asp:Label></td>		
	            <td style="width: 35%; ">
                <asp:Label ID="Label257" runat="server" Font-Names="Arial" Font-Size="Small" height= "100%" width= "100%" Text="Keterangan" BackColor="Gray"></asp:Label></td>		
            </tr>
            <tr>
	            <td style="width: 15%; ">
                <asp:TextBox ID="TxtNoVcrBBM" runat="server" text="" Width="100%" MaxLength="15" CssClass="uppercase"></asp:TextBox></td>
	            <td style="width: 15%; ">
                <asp:Label ID="LblBBMTg" runat="server" Font-Names="Arial" Font-Size="Small" height= "100%" width= "100%" Text="99-99-99"></asp:Label></td>		
	            <td style="width: 15%; ">
                <asp:Label ID="LblBBMJm" runat="server" Font-Names="Arial" Font-Size="Small" height= "100%" width= "100%" Text="999.999"></asp:Label></td>		
	            <td style="width: 20%; ">
                <asp:DropDownList ID="DDListBBMTp" runat="server" Width="70%" AutoPostBack="true"  >
                </asp:DropDownList></td>		
	            <td style="width: 35%; ">
                <asp:TextBox ID="TxtBBMCt" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
	            <td style="width: 15%; "></td>		
	            <td style="width: 15%; "></td>		
	            <td style="width: 15%; "></td>		
	            <td style="width: 20%; ">
                <asp:Label ID="Label36" runat="server" Font-Names="Arial" Font-Size="Small" height= "100%" width= "100%" Text="Alasan Batal"></asp:Label></td>		
	            <td style="width: 35%; ">
                <asp:TextBox ID="TxtBBMABt" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
            </tr>

            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">            
            <tr>
                <td style="width: 20%; ">
	            <asp:Button ID="BtnBBM1Clr" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="100%" Text="Bersih" Width="99%" />
	            </td> 
                <td style="width: 20%; ">
	            <asp:Button ID="BtnBBM2Add" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="100%" Text="Tambah" Width="99%" />
	            </td> 
                <td style="width: 20%; ">
	            <asp:Button ID="BtnBBM3Del" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="100%" Text="Hapus" Width="99%" />
	            </td> 
                <td style="width: 20%; ">
	            <asp:Button ID="BtnBBM4Fil" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="100%" Text="Isi Form" Width="99%" />
	            </td> 
                <td style="width: 20%; ">
                <asp:Button ID="BtnBBM5Ctk" runat="server" Text="Print Voucher"  Width="99%" 
                        OnClientClick = "return PrintPanel();" BackColor="Blue" />


	            </td> 

            </tr>
            </table> 

            <asp:ListView ID="LvTabelBBM" 
            OnSelectedIndexChanging="TblBBMView_SelectedIndexChanging" 
            OnPagePropertiesChanging="TblBBMView_PagePropertiesChanging" runat="server">
            <LayoutTemplate><table id="table-a"  border="2" width="100%" style="border-collapse:collapse;"><thead  style="background-color:Silver">
            <th>Pilih</th><th>No BBM</th><th>Tgl</th><th>Batal</th><th>Buat</th><th>TTT</th><th>Tgl</th><th>Jumlah</th><th>Tipe</th><th>Note</th>
            </thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="10" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate>
                <tr>
                <td style="width:1%; font-size: x-small"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" /></td>
                <td style="width:4%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_BBMNo" runat="server" Text='<%#Eval("Temp_BBMNo")%>'/></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_BBMTg" runat="server" Text='<%#Eval("Temp_BBMTg")%>' /></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_BBMBt" runat="server" Text='<%#Eval("Temp_BBMBt")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_BBMCr" runat="server" Text='<%#Eval("Temp_BBMCr")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_BBMTT" runat="server" Text='<%#Eval("Temp_BBMTT")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_BBMTTg" runat="server" Text='<%#Eval("Temp_BBMTTg")%>' /></td>
                <td style="width:15%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_BBMJm" runat="server" Text='<%#Eval("Temp_BBMJm")%>' /></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_BBMTp" runat="server" Text='<%#Eval("Temp_BBMTp")%>' /></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_BBMNt" runat="server" Text='<%#Eval("Temp_BBMNt")%>'/></td>
                </tr>
                </ItemTemplate><SelectedItemTemplate>
                <tr id="Tr1" runat="server" style="background-color:#ADD8E6">
                <td>&nbsp;</td>
                <td style="width:4%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_BBMNo" runat="server" Text='<%#Eval("Temp_BBMNo")%>' /></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_BBMTg" runat="server" Text='<%#Eval("Temp_BBMTg")%>' /></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_BBMBt" runat="server" Text='<%#Eval("Temp_BBMBt")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_BBMCr" runat="server" Text='<%#Eval("Temp_BBMCr")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_BBMTT" runat="server" Text='<%#Eval("Temp_BBMTT")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_BBMTTg" runat="server" Text='<%#Eval("Temp_BBMTTg")%>' /></td>
                <td style="width:15%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_BBMJm" runat="server" Text='<%#Eval("Temp_BBMJm")%>' /></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_BBMTp" runat="server" Text='<%#Eval("Temp_BBMTp")%>' /></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_BBMNt" runat="server" Text='<%#Eval("Temp_BBMNt")%>'/></td>
                </tr>
        </SelectedItemTemplate></asp:ListView>        




        <center>
        <asp:Label ID="Label251" runat="server" Font-Names="Cooper Black"  
                Font-Size="Medium" height= "21px" Text="Detail PDI" 
                ForeColor="Red"></asp:Label>
        </center>
        
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Label ID="Label41" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI No SPK"></asp:Label></td>
                <td style="width: 85%; background-color:#CCCCFF">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                    <td style="width: 70%; background-color:#CCCCFF">
                    <asp:TextBox ID="TxtPDISPK" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox>
                    </td>                 
                    <td style="width: 20%; background-color:#CCCCFF">
                    <asp:Button ID="BtnSmp16" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" Width="99%" /></td> 
                    <td style="width: 10%; background-color:#CCCCFF">
                    <asp:Button ID="BtnBtl16" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 
                    </tr>
                    </table> 
                 </td>                 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label42" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI Transmisi"></asp:Label></td>
                <td style="width: 85%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 70%; ">
                        <asp:TextBox ID="TxtPDITransmisiNote" runat="server" text="" Width="100%" 
                                MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 20%; ">
                    <asp:Button ID="BtnSmp17" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl17" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 
                                
                    </tr>
                    </table> </td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Label ID="Label43" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI Nama Supir"></asp:Label></td>
                <td style="width: 85%; background-color:#CCCCFF">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 70%; background-color:#CCCCFF"> 
                        <asp:TextBox ID="TxtPDISupirTgl" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 20%; background-color:#CCCCFF">
                    <asp:Button ID="BtnSmp18" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" Width="99%" /></td> 
                <td style="width: 10%; background-color:#CCCCFF">
                    <asp:Button ID="BtnBtl18" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="9%" Text="Batal" Width="99%"  /></td> 
                    </tr>
                    <tr>
                        <td style="width: 70%; background-color:#CCCCFF">
                        <asp:TextBox ID="TxtPDISupirNot" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 20%; background-color:#CCCCFF"></td>
                <td style="width: 10%; background-color:#CCCCFF"></td>
                    </tr>
                    </table> </td>                     
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label45" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI Plat MJS [Y]a [T]idak"></asp:Label></td>
                <td style="width: 85%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 70%; ">
                        <asp:TextBox ID="TxtPDIPlatMJSNot" runat="server" text="" Width="100%" 
                                MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 20%; ">
                    <asp:Button ID="BtnSmp19" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl19" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 
                    </tr>
                    </table> </td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color:#CCCCFF;">
                    <asp:Label ID="Label46" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI Keterangan"></asp:Label></td>
                <td style="width: 85%; background-color:#CCCCFF">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 70%; background-color:#CCCCFF"> 
                        <asp:TextBox ID="TxtPDIKetTgl" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 20%; background-color:#CCCCFF">
                    <asp:Button ID="BtnSmp20" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%;background-color:#CCCCFF ">
                    <asp:Button ID="BtnBtl20" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 
                    </tr>
                    <tr>
                        <td style="width: 70%; background-color:#CCCCFF">
                        <asp:TextBox ID="TxtPDIKetera" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 20%; background-color:#CCCCFF"></td>
                <td style="width: 10%; background-color:#CCCCFF"></td>
                    </tr>
                    </table> </td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label47" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI Gesekan Lakban"></asp:Label></td>
                <td style="width: 85%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 70%; ">
                        <asp:TextBox ID="TxtPDILakbanTgl" runat="server" />
                        <asp:Button ID="BtnCall13" runat="server" Text=".." Width="27px" />
                        <div id="Div12">
                        <asp:Calendar ID="Calendar13" runat="server" onselectionchanged="Calendar13_SelectionChanged" />
                        </div>
                        </td>
                <td style="width: 20%; ">
                    <asp:Button ID="BtnSmp21" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl21" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 

                    </tr>
                    <tr>
                        <td style="width: 70%; ">
                        <asp:TextBox ID="TxtPDILakbanNot" runat="server" text="" Width="100%" 
                                MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 20%; "></td>
                <td style="width: 10%; "></td>
                                
                    </tr>
                    </table> </td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color:#CCCCFF">
                    <asp:Label ID="Label48" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI Gesekan Polda"></asp:Label></td>
                <td style="width: 85%; background-color:#CCCCFF">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 70%; ">
                        <asp:TextBox ID="TxtPDIPoldaTgl" runat="server" />
                        <asp:Button ID="BtnCall14" runat="server" Text=".." Width="27px" />
                        <div id="Div13">
                        <asp:Calendar ID="Calendar14" runat="server" onselectionchanged="Calendar14_SelectionChanged" />
                        </div>
                        </td>
                <td style="width: 20%; background-color:#CCCCFF">
                    <asp:Button ID="BtnSmp22" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; background-color:#CCCCFF">
                    <asp:Button ID="BtnBtl22" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 

                    </tr>
                    <tr>
                        <td style="width: 70%; background-color:#CCCCFF">
                        <asp:TextBox ID="TxtPDIPoldaNot" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 20%; background-color:#CCCCFF"></td>
                <td style="width: 10%; background-color:#CCCCFF"></td>
                    </tr>
                    </table>
                </td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label49" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="No STCK"></asp:Label></td>
                <td style="width: 85%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                    <td style="width: 70%; ">
                    <asp:TextBox ID="TxtNoSTCK" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox>
                    </td>                 
                <td style="width: 20%; ">
                    <asp:Button ID="BtnSmp23" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl23" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 
                    </tr>
                    </table> 

                
                </td>
            </tr>
            </table> 
                </td>
            </tr>
        </table>

        
        </asp:View>
        <asp:View ID="View03StokPerbaikanRangka" runat="server">

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 100%; ">
           <div>
           <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: large;">Data SPK</h2>
           </center>
	       </div>

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label54" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="No SPK/No DO"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="lblnospkDO" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
                <td style="width: 15%; ">
                    <asp:Label ID="Dealer" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="HP SALESMAN"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="LblCdBranch" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label52" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Salesman"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="LblSalesman" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
                <td style="width: 15%; ">
                    <asp:Label ID="Label57" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Lease"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="lbllease" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
            </tr>
            </table> 
        <br />
           <div>
           <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: large;">Detail Perbaikan</h2>
           </center>
	       </div>

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 30%; background-color: Red;">
                    <asp:Label ID="Label59" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal Permohonan Perbaikan"></asp:Label></td>
                <td style="width: 70%; ">
                    <asp:Label ID="lblTglMohonRepair" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 30%; ">
                    <asp:Label ID="Label69" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Jenis Perbaikan"></asp:Label></td>
                <td style="width: 70%; ">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem>Sevice Repair</asp:ListItem>
                        <asp:ListItem>Body Repair</asp:ListItem>
                        <asp:ListItem>Service dan Bodyrepair</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; ">
                    <asp:Label ID="Label71" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Pekerjaan"></asp:Label></td>
                <td style="width: 70%; ">
                    <asp:TextBox ID="TxtRepairRemark" runat="server" text="" Width="100%" 
                        MaxLength="200" CssClass="uppercase" Height="37px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 30%; ">
                    <asp:Label ID="Label73" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggaungan Biaya"></asp:Label></td>
                <td style="width: 70%; ">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                        <asp:ListItem>Beban Kantor</asp:ListItem>
                        <asp:ListItem>Bukan Beban Kantor</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; ">
                    <asp:Label ID="Label85" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Keterangan WO"></asp:Label></td>
                <td style="width: 70%; ">
                    <asp:TextBox ID="TxtKetWO" runat="server" text="" Width="100%" MaxLength="30" 
                        CssClass="uppercase" Height="22px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 30%; ">
                    <asp:Label ID="Label75" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Estimasi Harga"></asp:Label></td>
                <td style="width: 70%; ">
                    <asp:TextBox ID="TxtHarga" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 30%; ">
                    <asp:Label ID="Label77" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tujuan Service"></asp:Label></td>
                <td style="width: 70%; ">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>U902-SERVICE &amp; BODYREPAIR PASAR MINGGU</asp:ListItem>
                        <asp:ListItem>U903-SERVICE &amp; BODYREPAIR PURI KEMBANGAN</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; ">
                    <asp:Label ID="Label79" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Status"></asp:Label></td>
                <td style="width: 70%; ">
                    <asp:Label ID="lblStRepair" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 30%; ">
                    <asp:Label ID="Label218" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Pengajuan Ulang"></asp:Label></td>
                <td style="width: 70%; ">
                    <asp:CheckBox ID="ChkBRepair" Text ="Jika sudah pernah mengajukan permohonan Check list untuk mengajukan ulang" runat="server" />
                </td>
            </tr>

            </table> 
                </td>
            </tr>
            </table>        
        </asp:View>
        <asp:View ID="View03StokDetailSTCK" runat="server">
                <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 

                <td style="width: 100%; ">
           <div>
           <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: large;">Detail STCK</h2>
           </center>
	       </div>
                
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label55" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="NO. STCK"></asp:Label></td>
                <td style="width: 85%; ">
                    <asp:TextBox ID="TxtSTCKNO" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox>
                    <asp:Label ID="TxtSTCKNOTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label60" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="No Polisi"></asp:Label></td>
                <td style="width: 85%; ">
                    <asp:TextBox ID="TxtSTCKNopol" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label64" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor Rangka"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="LblSTCKNRGK" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label66" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal Input"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="LblSTCKINPT" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label68" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal Kirim"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="TxtSTCKSEND" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="STNK"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label70" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Status"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="LblSTCKStatus" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label56" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Jumlah"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="TxtSTCKQTY" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label62" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Jumlah Stock STCK"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="LblJumlahSTOCKSTCK" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15%; ">
                    <asp:Label ID="Label67" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Catatan"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="TxtSTCKNOTE" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
            </tr>

            </table> 
                </td>
            </tr>
            </table>
        </asp:View>
        <asp:View ID="View03StokDetailAksesoris" runat="server">
        <div>
           <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: large;">Detail Aksesoris</h2>
           </center>
	    </div>

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 10%; background-color:#CCCCFF ">
                <asp:Label ID="Label219" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True">No WO</asp:Label>
            </td>
            <td style="width: 10%; background-color:#CCCCFF ">
                <asp:Label ID="Label220" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True">Pasang</asp:Label>
            </td>
            <td style="width: 5%; background-color:#CCCCFF ">
                <asp:Label ID="Label221" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True">Kode</asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF ">
                <asp:Label ID="Label224" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True">Nama</asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF ">
                <asp:Label ID="Label227" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True">Catatan</asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF ">
                <asp:Label ID="Label234" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True">Catatan Batal Pasang</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 10%;">
                <asp:Label ID="LblAksesorDlr" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True"></asp:Label>
                <asp:Label ID="Label105" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True">-</asp:Label>
                <asp:Label ID="LblAksesorWO" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True"></asp:Label>
            </td>
            <td style="width: 10%; ">
                <asp:Label ID="LblAksesorpsg" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True"></asp:Label>
            </td>
            <td style="width: 5%; ">
                <asp:Label ID="LblAksesorKode" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True"></asp:Label>
            </td>
            <td style="width: 25%; ">
                <asp:Label ID="LblAksesorNama" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True"></asp:Label>
            </td>
            <td style="width: 25%; ">
                <asp:Label ID="LblAksesorNote" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True"></asp:Label>
            </td>
            <td style="width: 25%; ">
                <asp:TextBox ID="TxtAksesorpsg" runat="server" AutoPostBack="true" CssClass="uppercase" text="" Width="100%" height= "27px"></asp:TextBox>
            </td>
            </tr>
        </table>  
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small">
            <tr>
            <td style="width: 80%;">
                <asp:Label ID="lblIsiTglPasang" runat="server" Font-Names="Arial" Font-Size="Small" height= "27px" Font-Bold="True">Isi Tanggal Pasang disini</asp:Label>
                <asp:TextBox ID="TxtIsiTglPasang" runat="server" />
                <asp:Button ID="BtnCall16" runat="server" Text=".." Width="27px" />
                <div id="Div15">
                        <asp:Calendar ID="Calendar16" runat="server" onselectionchanged="Calendar16_SelectionChanged" />
                </div>

            </td>
            
            <td style="width: 10%; ">
               <asp:Button ID="BtnPasangAss" runat="server" Text="Terpasang"  
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Width="99%" Height="30px" />
            </td>
            <td style="width: 10%; ">
               <asp:Button ID="BtnBtlPasangAss" runat="server" Text="Batal Pasang"  
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Width="99%" Height="30px" />
            </td>
            </tr>
        </table>          
        <br />


        
        <asp:ListView ID="LvTabelAksesoris" 
            OnSelectedIndexChanging="TblAksesorisView_SelectedIndexChanging" 
            OnPagePropertiesChanging="TblAksesorisView_PagePropertiesChanging"
            runat="server">
            <LayoutTemplate><table id="table-a"  border="2" width="100%" style="border-collapse:collapse;"><thead  style="background-color:Silver"><th>Pilih</th><th>Dlr</th><th>WO</th><th>Tgl WO</th><th>Tgl Email</th><th>Pasang</th><th>Suplier</th><th>Kode</th><th>Aksesoris</th><th>Note</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="10" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate>
            <ItemTemplate>
                <tr>
                <td style="width:1%; font-size: x-small"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" /></td>
                <td style="width:4%; font-size:x-small" valign="top"><asp:Label ID="Lbl_Judul" runat="server" Text='<%#Eval("Temp_Judul")%>'/></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_CREATE" runat="server" Text='<%#Eval("Temp_TANGGAL_CREATE")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PROSES" runat="server" Text='<%#Eval("Temp_TANGGAL_PROSES")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_NOMOHN" runat="server" Text='<%#Eval("Temp_NOMOR_MOHON")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_URUT" runat="server" Text='<%#Eval("Temp_URUT")%>' /></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SPL" runat="server" Text='<%#Eval("Temp_SPL")%>' /></td>
                <td style="width:4%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_USER" runat="server" Text='<%#Eval("Temp_MYUSER")%>' /></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SPV" runat="server" Text='<%#Eval("Temp_SPV")%>' /></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_APRVCODE" runat="server" Text='<%#Eval("Temp_APPROVALCODE")%>'/></td>
                </tr>
                </ItemTemplate>
                <SelectedItemTemplate>
                <tr id="Tr1" runat="server" style="background-color:#ADD8E6">
                <td>&nbsp;</td>
                <td style="width:4%; font-size:x-small" valign="top"><asp:Label ID="Lbl_Judul" runat="server" Text='<%#Eval("Temp_Judul")%>' /></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_CREATE" runat="server" Text='<%#Eval("Temp_TANGGAL_CREATE")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PROSES" runat="server" Text='<%#Eval("Temp_TANGGAL_PROSES")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_NOMOHN" runat="server" Text='<%#Eval("Temp_NOMOR_MOHON")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_URUT" runat="server" Text='<%#Eval("Temp_URUT")%>' /></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SPL" runat="server" Text='<%#Eval("Temp_SPL")%>' /></td>
                <td style="width:4%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_USER" runat="server" Text='<%#Eval("Temp_MYUSER")%>' /></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SPV" runat="server" Text='<%#Eval("Temp_SPV")%>' /></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_APRVCODE" runat="server" Text='<%#Eval("Temp_APPROVALCODE")%>'/></td>
                </tr>
                </SelectedItemTemplate>
        </asp:ListView>        


        </asp:View>
        <asp:View ID="View7" runat="server">
        <div>
           <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: large;">History Rangka</h2>
           </center>
	    </div>

        <asp:ListView ID="LvTabelHistoryRangka" 
            runat="server"><LayoutTemplate><table id="table-a"  border="2" width="100%" style="border-collapse:collapse;"><thead  style="background-color:Silver">
            <th>Rangka</th><th>User</th><th>Tgl</th><th>Catatan</th><th>Status</th>
            </thead>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                <td style="width:10%; font-size:x-small"  valign="top"><asp:Label   ID="Lbl_HistRgk"  runat="server" Text='<%#Eval("Temp_HistRgk")%>' /></td>
                <td style="width:8%; font-size:x-small"   valign="top"><asp:Label  ID="Lbl_HistTgl"  runat="server" Text='<%#Eval("Temp_HistTgl")%>'/></td>
                <td style="width:10%; font-size:x-small"  valign="top"><asp:Label   ID="Lbl_HistUser"  runat="server" Text='<%#Eval("Temp_HistUser")%>' /></td>
                <td style="width:67%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_HistNote"  runat="server" Text='<%#Eval("Temp_HistNote")%>'/></td>
                <td style="width:5%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_HistSts"  runat="server" Text='<%#Eval("Temp_HistSts")%>' /></td>

                </tr>
                </ItemTemplate><SelectedItemTemplate>
                <tr id="Tr1" runat="server" style="background-color:#ADD8E6">
                <td style="width:10%; font-size:x-small"  valign="top"><asp:Label   ID="Lbl_HistRgk"  runat="server" Text='<%#Eval("Temp_HistRgk")%>' /></td>
                <td style="width:8%; font-size:x-small"   valign="top"><asp:Label  ID="Lbl_HistTgl"  runat="server" Text='<%#Eval("Temp_HistTgl")%>'/></td>
                <td style="width:10%; font-size:x-small"  valign="top"><asp:Label   ID="Lbl_HistUser"  runat="server" Text='<%#Eval("Temp_HistUser")%>' /></td>
                <td style="width:67%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_HistNote"  runat="server" Text='<%#Eval("Temp_HistNote")%>'/></td>
                <td style="width:5%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_HistSts"  runat="server" Text='<%#Eval("Temp_HistSts")%>' /></td>
                </tr>
                </SelectedItemTemplate></asp:ListView>        



        </asp:View>
        

        </asp:MultiView> 

        </asp:View> 

        <asp:View ID="View04GesekRangka" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 25%; ">
               <asp:Label ID="Label206" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal DO Dealer : "></asp:Label>
               <asp:Label ID="LblDateGesekD" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="DD"></asp:Label>
               <asp:Label ID="Label44" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="/"></asp:Label>
               <asp:Label ID="LblDateGesekM" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="MM"></asp:Label>
               <asp:Label ID="Label236" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="/"></asp:Label>
               <asp:Label ID="LblDateGesekY" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="YY"></asp:Label>
            </td>
            <td style="width: 25%; ">
                <asp:TextBox ID="TxtDateGesek" runat="server" />
                <asp:Button ID="BtnGesek" runat="server" Text=".." Width="27px" />
                <div id="Div7">
                <asp:Calendar ID="Calendar8" runat="server" onselectionchanged="Calendar8_SelectionChanged" />
                </div>
            </td>
            <td style="width: 75%; ">
               <asp:Button ID="Button3" runat="server" Text=" &lt;----Update Tanggal DO Dealer semua cabang" 
                    Width="413px" BackColor="#0033CC" Height="64px" />
            </td>
            </tr>
            </table> 
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 25%; ">
               <asp:Label ID="Label216" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Gesek Rangka"></asp:Label>

            </td>
            <td style="width: 25%; ">
                <asp:TextBox ID="TxtGesekRangkaActual" runat="server" />
                <asp:Button ID="BtnCal15" runat="server" Text=".." Width="27px" />
                <div id="Div14">
                <asp:Calendar ID="Calendar15" runat="server" onselectionchanged="Calendar15_SelectionChanged" />
                </div>
            </td>
            <td style="width: 75%; ">
               <asp:Label ID="Label217" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Isi Tanggal Gesek Rangka ini digunakan untuk menginput tanggal gesek rangka"></asp:Label>
            </td>
            </tr>
            </table> 

            <asp:SqlDataSource ID="SqlDataGesek" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM TRXN_STOCK LEFT OUTER JOIN DATA_WARNA ON TRXN_STOCK.STOCK_CdWarna = DATA_WARNA.WARNA_Kode LEFT OUTER JOIN DATA_TYPE ON TRXN_STOCK.STOCK_CdType = DATA_TYPE.TYPE_Type WHERE (DAY(TRXN_STOCK.STOCK_TGLDODEALER) = ?) AND (MONTH(TRXN_STOCK.STOCK_TGLDODEALER) = ?) AND (YEAR(TRXN_STOCK.STOCK_TGLDODEALER) = ?) "
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblDateGesekD"      Name="STOCK_TGLDODEALER"       PropertyName= "Text" Type="String" DefaultValue="%"/>            
                <asp:ControlParameter ControlID="lblDateGesekM"      Name="STOCK_TGLDODEALER2"      PropertyName= "Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="lblDateGesekY"   Name="STOCK_TGLDODEALER3"      PropertyName= "Text" Type="String" DefaultValue="%"  />            

            </SelectParameters>

            </asp:SqlDataSource>   
            <asp:ListView ID="LVGesekRangka" runat="server" DataSourceID="SqlDataGesek" DataKeyNames ="STOCK_NORANGKA"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead style="background-color:Silver; height:30px"><th>Rangka</th><th>Tgl DO</th><th>Tgl Gesek</th><th>Terima</th><th>Catatan</th><th>Dlr</th><th>Tipe</th><th>Nama</th><th>Kota</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="15" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate><tr><td style="width:16%; font-size: x-small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("STOCK_NORANGKA") %>' CommandName="Select" runat="server" /></td><td style="width:7%; font-size: x-small"><%#Eval("STOCK_TglDoDealer")%></td><td style="width:7%; font-size: x-small"><%#Eval("STOCK_DOTGLGESEKRGK")%></td><td style="width:7%; font-size: x-small"><%#Eval("STOCK_DOTGLGESEKRGKT")%></td><td style="width:15%; font-size: x-small"><%#Eval("STOCK_DOGESEKNOTE")%></td><td style="width:5%; font-size: x-small"><%#Eval("STOCK_KODEDEALER")%></td><td style="width:10%; font-size: x-small"><%#Eval("TYPE_NAMA")%></td><td style="width:15%; font-size: x-small"><%#Eval("STOCK_NAMA")%></td><td style="width:12%; font-size: x-small"><%#Eval("STOCK_KOTA")%></td></tr></ItemTemplate></asp:ListView>

        
        </asp:View>                    

        <asp:View ID="View05DOImoraBelumTerima" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 25%; ">
               <asp:Label ID="Label205" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Cari Nomor Rangka"></asp:Label>
            </td>
            <td style="width: 25%; ">
               <asp:TextBox ID="TextBox1" text="" runat="server" Width="250px" CssClass="uppercase"></asp:TextBox>
            </td>
            <td style="width: 75%; ">
               <asp:Button ID="Button1" runat="server" Text=" <---- Pencarian Pemasang Asesoris berdasarakan nomor rangka" 
                    Width="413px" BackColor="#0033CC" />
            </td>
        </tr>
        </table>
            <asp:SqlDataSource ID="SqlDataDOImora" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM TRXN_STOCKDO WHERE (SELECT STOCK_NORANGKA FROM TRXN_STOCK WHERE STOCK_NORANGKA = STOCKDO_NORANGKA) IS NULL"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            </asp:SqlDataSource>   
            <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataDOImora" DataKeyNames ="STOCKDO_NORANGKA"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead style="background-color:Silver; height:30px"><th>Dealer</th><th>Rangka</th><th>Mesin</th><th>Do Suplier</th><th>Tgl Do Suplier</th><th>Input Do Suplier</th><th>Type</th><th>Waran</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="15" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate>
                <ItemTemplate>
                <tr>
                <td style="width:5%; font-size: x-small">
                <asp:LinkButton ID="lnkSelect" Text='<%# Eval("STOCKDO_KODEDLR") %>' CommandName="Select" runat="server" />
                </td>
                <td style="width:15%; font-size: x-small"><%#Eval("STOCKDO_NORANGKA")%></td><td style="width:10%; font-size: x-small"><%#Eval("STOCKDO_NOMESIN")%></td><td style="width:8%; font-size: x-small"><%#Eval("STOCKDO_NODOSPL")%></td><td style="width:8%; font-size: x-small"><%#Eval("STOCKDO_TGDOSPL")%></td><td style="width:8%; font-size: x-small"><%#Eval("STOCKDO_TGDOSPLI")%></td><td style="width:20%; font-size: x-small"><%#Eval("STOCKDO_TYPEDOSPL")%></td><td style="width:20%; font-size: x-small"><%#Eval("STOCKDO_WARNADOSPL")%></td></tr></ItemTemplate></asp:ListView>
        </asp:View>     
        
        <asp:View ID="View06MenuReport"  runat="server">
    <table style="width: 100%; height:auto ; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:Label ID="Label258" runat="server" Font-Names="Arial" Font-Size="Large" 
                        height= "99%" Text="Pilihan Menu (Klik yang ada garis bawahnya)"></asp:Label>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonSvc1" runat="server" BackColor="White" 
                    ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0202StatusSPK01AuditParts.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">01. PDI aksesoris</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonSvc2" runat="server" BackColor="White" 
                    ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0202StatusSPK02CustomerCallFriend.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">02. PDI Unit</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButton1" runat="server" BackColor="White" 
                    ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0202StatusSPK02CustomerCallFriend.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">03. Tanda Terima Tagihan</asp:LinkButton>
            </td>            
        </tr>

        <tr>
            <td style="width: 100%;height:auto ">
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:Label ID="Label259" runat="server" Font-Names="Arial" Font-Size="Large" 
                        height= "99%" Text="Laporan" Font-Bold="True" ForeColor="Blue"></asp:Label>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkBtnReport01" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0205WarehouseReport01.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">01 Laporan Kirim Kendaraan</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkBtnReport02" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0205WarehouseReport02.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">02 Laporan Gesekan Rangka</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            </td>            
        </tr>

        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButton4" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0205WarehouseReport03.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">03 Laporan Pasang 
                Aksesoris</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButton2" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0205WarehouseReport04.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">04 Laporan Delivery Order/DO Cabang</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButton3" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0205WarehouseReport05.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">05 Laporan History Kendaraan Berdasarkan rangka</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButton5" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0205WarehouseReport06.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">06 Laporan Kendaraan Berdasarkan Tanggal Input</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButton6" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0205WarehouseReport07.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">07 Laporan Kendaraan Stock Kendaraan</asp:LinkButton>
            </td>            
        </tr>

     </table>

        </asp:View>               

        <asp:View ID="View07ValidInputUnit" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 25%; ">
               <asp:Label ID="Label266" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Double Klik Untuk Isi Validasi Atau Membatalkan di Kolom paling Kiri"></asp:Label>
            </td>
            </tr>
            </table> 

            <asp:SqlDataSource ID="SqlDataValidInputUnit" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM TRXN_STOCK LEFT OUTER JOIN DATA_WARNA ON TRXN_STOCK.STOCK_CdWarna = DATA_WARNA.WARNA_Kode LEFT OUTER JOIN DATA_TYPE ON TRXN_STOCK.STOCK_CdType = DATA_TYPE.TYPE_Type WHERE (DAY(TRXN_STOCK.STOCK_TGLDODEALER) = ?) AND (MONTH(TRXN_STOCK.STOCK_TGLDODEALER) = ?) AND (YEAR(TRXN_STOCK.STOCK_TGLDODEALER) = ?) "
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblDateGesekD"      Name="STOCK_TGLDODEALER"       PropertyName= "Text" Type="String" DefaultValue="%"/>            
                <asp:ControlParameter ControlID="lblDateGesekM"      Name="STOCK_TGLDODEALER2"      PropertyName= "Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="lblDateGesekY"   Name="STOCK_TGLDODEALER3"      PropertyName= "Text" Type="String" DefaultValue="%"  />            

            </SelectParameters>

            </asp:SqlDataSource>   
            <asp:ListView ID="LvValidInputUnit" runat="server" DataSourceID="SqlDataValidInputUnit" DataKeyNames ="STOCK_NORANGKA"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead style="background-color:Silver; height:30px"><th>Rangka</th><th>Tgl DO</th><th>Tgl Gesek</th><th>Terima</th><th>Catatan</th><th>Dlr</th><th>Tipe</th><th>Nama</th><th>Kota</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="15" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate><tr><td style="width:16%; font-size: x-small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("STOCK_NORANGKA") %>' CommandName="Select" runat="server" /></td><td style="width:7%; font-size: x-small"><%#Eval("STOCK_TglDoDealer")%></td><td style="width:7%; font-size: x-small"><%#Eval("STOCK_DOTGLGESEKRGK")%></td><td style="width:7%; font-size: x-small"><%#Eval("STOCK_DOTGLGESEKRGKT")%></td><td style="width:15%; font-size: x-small"><%#Eval("STOCK_DOGESEKNOTE")%></td><td style="width:5%; font-size: x-small"><%#Eval("STOCK_KODEDEALER")%></td><td style="width:10%; font-size: x-small"><%#Eval("TYPE_NAMA")%></td><td style="width:15%; font-size: x-small"><%#Eval("STOCK_NAMA")%></td><td style="width:12%; font-size: x-small"><%#Eval("STOCK_KOTA")%></td></tr></ItemTemplate></asp:ListView>

        
        </asp:View>                    


    </asp:MultiView>


    <div id="PrintBBM" style ="display:none;  margin-left: 10px; margin-top: 10px;"   >
     <asp:Panel id="pnlContents" runat = "server"    >
        <asp:MultiView ID="MultiViewCetak" runat="server" Visible="TRUE">
        <asp:View ID="ViewCetakBBM" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
             <tr> 
                <td style="width: 100%; height:12px ">
            <center> <asp:Label ID="lblCetakBBMCompany" runat="server"   Text="PT. MITRAUSAHA GENTANIAGA" Width="100%"></asp:Label> </center>
                </td>
            </tr>
            <tr> 
                <td style="width: 100%; height:10px ">
            <center> <asp:Label ID="lblCetakBBMCompany1" runat="server"  Text="HONDA MUGEN PASAR MINGGU" Width="100%"></asp:Label> </center>
                </td>
            </tr>
            <tr> 
                <td style="width: 100%; height:10px ">
            <center> <asp:Label ID="lblCetakBBMCompany2" runat="server"  Text="VOUCHER BAHAN BAKAR" Width="100%"></asp:Label> </center>
                </td>
            </tr>
        </table>
            <hr />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 15%; height:12px ">
                <asp:Label ID="lblCetakBBMIsiColA1" runat="server"  Text="NO VOUCHER"  Font-Size="Smaller"       Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; height:12px ">
                <asp:Label ID="lblCetakBBMIsiColA2" runat="server"  Text="99999"       Font-Size="Smaller"      Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; height:12px ">
                <asp:Label ID="lblCetakBBMIsiColA3" runat="server"  Text="TANGGAL"     Font-Size="Smaller"      Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="lblCetakBBMIsiColA4" runat="server"  Text="99/99/9999"  Font-Size="Smaller"      Width="100%"></asp:Label>
                </td>
            </tr>
            </table>
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="lblCetakBBMIsiColB1" runat="server"  Text="NO RANGKA"         Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="lblCetakBBMIsiColB2" runat="server"  Text="99999"             Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="lblCetakBBMIsiColB3" runat="server"  Text="Kode Dealer"                  Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="lblCetakBBMIsiColB4" runat="server"  Text=""                  Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
            </tr>
            </table>            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="lblCetakBBMIsiColC1" runat="server"  Text="TYPE"              Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="lblCetakBBMIsiColC2" runat="server"  Text="99999"             Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="lblCetakBBMIsiColC3" runat="server"  Text="TANGGAL DIGUNAKAN" Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="lblCetakBBMIsiColC4" runat="server"  Text="99/99/9999"        Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
            </tr>
            </table>            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="lblCetakBBMIsiColD1" runat="server"  Text="WARNA"            Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="lblCetakBBMIsiColD2" runat="server"  Text="99999"            Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="lblCetakBBMIsiColD3" runat="server"  Text="TIPE PENGIRIMAN"  Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="lblCetakBBMIsiColD4" runat="server"  Text="99/99/9999"       Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
            </tr>
            </table>
            <hr />
            <center><asp:Label ID="lblCetakBBMIsiColE1" runat="server"  Text="Rp. 10.000.000" Font-Size="large" ></asp:Label></center>
            <hr />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: smaller;">
            <tr style="height :12px;" > 
                <td style="width: 100%; ">
            <asp:Label ID="Label2" runat="server"  Text="Syarat dan ketentuan"  Font-Size="Smaller"     ></asp:Label>
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 100%; ">
            <asp:Label ID="Label3" runat="server"  Text="- Hanya berlaku untuk Honda Mugen"  Font-Size="Smaller"     ></asp:Label>
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 100%; ">
            <asp:Label ID="Label9" runat="server"  Text="- Tdak dapat diuangkan"  Font-Size="Smaller"     ></asp:Label>
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 100%; ">
            <asp:Label ID="Label14" runat="server"  Text="- Tidak bisa dipindah tangankan (Digunakan sesuai data tercantum)"  Font-Size="Smaller"     ></asp:Label>
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 100%; ">
            <asp:Label ID="Label16" runat="server"  Text="- Asli (Tidak berlaku jika di fotocopy)"  Font-Size="Smaller"     ></asp:Label>
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 100%; ">
            <asp:Label ID="Label65" runat="server"  Text="- Tidak berlaku jika tidak terpotong"  Font-Size="Smaller"     ></asp:Label>
                </td>
            </tr>
            </table>
            <br />
            <asp:Label ID="lblCetakBBMIsiColf1" runat="server"  Text="Jakarta" Width="100%"  Font-Size="Smaller"     ></asp:Label>
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 30%; ">
            <asp:Label ID="Label74" runat="server"  Text="Supir"   Font-Size="Smaller"       Width="100%"></asp:Label>
                </td>
                <td style="width: 40%; ">
            <asp:Label ID="Label80" runat="server"  Text="Petugas"  Font-Size="Smaller"      Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label81" runat="server"  Text="Warehouse"   Font-Size="Smaller"       Width="100%"></asp:Label>
                </td>
            </tr>
            </table>
            <br />
            <br />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 30%; ">
            <asp:Label ID="Label76" runat="server"  Text="Tanggal"  Font-Size="Smaller"      Width="100%"></asp:Label>
                </td>
                <td style="width: 40%; ">
            <asp:Label ID="Label82" runat="server"  Text="Tanggal"  Font-Size="Smaller"      Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label83" runat="server"  Text="Tanggal"  Font-Size="Smaller"      Width="100%"></asp:Label>
                </td>
            </tr>
            </table>
            <asp:Label ID="Label78" runat="server"  Text="Lembaran Kuning untuk warehouse, putih utk SPBU, Merah untuk Admin stok"  Font-Size="Smaller"     ></asp:Label>
        </asp:View> 
        <asp:View ID="ViewCetakSPJ" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small">
            <tr> 
                <td style="width: 100%; height:12px ">
             <center> <asp:Label ID="Label86" runat="server"   Text="PT. MITRAUSAHA GENTANIAGA" Width="100%"></asp:Label>  </center>
                </td>
            </tr>
            <tr> 
                <td style="width: 100%; height:12px ">
             <center> <asp:Label ID="Label87" runat="server"  Text="HONDA MUGEN PASAR MINGGU" Width="100%"></asp:Label> </center>
                </td>
            </tr>
            <tr> 
                <td style="width: 100%; height:12px ">
             <center> <asp:Label ID="Label88" runat="server" Text="SPJ" Width="100%"></asp:Label> </center>
                </td>
            </tr>
            </table>
            <hr />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="Label89" runat="server"  Text="No Dokument Kirim"        Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="LblSPJ1NODoc" runat="server"  Text="99999"    Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="Label91" runat="server"  Text="No SPK/No DO"         Font-Size="Smaller"  Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="LblSPJ1NOSPK" runat="server"  Text="99999"    Font-Size="Smaller" Width="100%"></asp:Label>
            <asp:Label ID="Label38" runat="server"  Text=" / "    Font-Size="Smaller" Width="100%"></asp:Label>
            <asp:Label ID="LblSPJ1NODO" runat="server"  Text="99999" Font-Size="Smaller" Width="100%"></asp:Label>
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="Label94" runat="server"  Text="No Rangka"       Font-Size="Smaller"  Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="LblSPJ2RGK" runat="server"  Text="99999"         Font-Size="Smaller"    Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="Label95" runat="server"  Text="Nama Sales"       Font-Size="Smaller"           Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="LblSPJ2SALES" runat="server"  Text=""            Font-Size="Smaller"      Width="100%"></asp:Label>
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="Label97" runat="server"  Text="Type"          Font-Size="Smaller"     Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="LblSPJ3TIPE" runat="server"  Text="99999"     Font-Size="Smaller"         Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="Label99" runat="server"  Text="Tanggal Mohon" Font-Size="Smaller"  Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="LblSPJ3TGLM" runat="server"  Text="99/99/9999" Font-Size="Smaller"        Width="100%"></asp:Label>
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="Label101" runat="server"  Text="Warna"          Font-Size="Smaller"       Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="LblSPJ4WARNA" runat="server"  Text="99999"       Font-Size="Smaller"          Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="Label103" runat="server"  Text="Tanggal Kirim"  Font-Size="Smaller"      Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="LblSPJ4TGLK" runat="server"  Text="99/99/9999"    Font-Size="Smaller"        Width="100%"></asp:Label>
                </td>
            </tr>
            </table>
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 50%; ">
            <asp:Label ID="Label223" runat="server"  Text="Lokasi Pengiriman"   Font-Size="Smaller"              Width="100%"></asp:Label>
                </td>
                <td style="width: 50%; ">
            <asp:Label ID="Label225" runat="server"  Text="Alternatif Lokasi Pengiriman"   Font-Size="Smaller"         Width="100%"></asp:Label>
                </td>
            </tr>
            </table>
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="Label226" runat="server"  Text="Nama"     Font-Size="Smaller"       Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="LblSPJ5NAMA1" runat="server"  Text=""       Font-Size="Smaller"         Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="Label228" runat="server"  Text="Nama"         Font-Size="Smaller"            Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="LblSPJ5NAMA2" runat="server"  Text="_________________"           Font-Size="Smaller"          Width="100%"></asp:Label>
                </td>
            </tr>
            <tr style="height :15px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="Label230" runat="server"  Text="Alamat"       Font-Size="Smaller"          Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="LblSPJ6ALAMAT11" runat="server"  Text="99999"      Font-Size="Smaller"          Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="Label232" runat="server"  Text="Alamat" Width="100%"  Font-Size="Smaller"  ></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="LblSPJ6ALAMAT12" runat="server"  Text="_________________"    Font-Size="Smaller"       Width="100%"></asp:Label>
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="Label238" runat="server"  Text="Kota"         Font-Size="Smaller"        Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="LblSPJ7KOTA1" runat="server"  Text="99999"       Font-Size="Smaller"         Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="Label240" runat="server"  Text="Kota" Width="100%"  Font-Size="Smaller"  ></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="LblSPJ7KOTA2" runat="server"  Text="_________________"    Font-Size="Smaller"       Width="100%"></asp:Label>
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="Label231" runat="server"  Text="Telepon"         Font-Size="Smaller"        Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="Label233" runat="server"  Text="99999"       Font-Size="Smaller"         Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="Label235" runat="server"  Text="Telepon" Width="100%"  Font-Size="Smaller"  ></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label237" runat="server"  Text="_________________"    Font-Size="Smaller"       Width="100%"></asp:Label>
                </td>
            </tr>
            
            
            </table>
            <hr />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :15px;" > 
                <td style="width: 40%; ">
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label106" runat="server"  Text="Tanggal & Jam Keluar : __________"          Font-Size="Smaller"        Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label244" runat="server"  Text="Paraf Security: __________"     Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
            </tr>
            <tr style="height :15px;" > 
                <td style="width: 40%; ">
            <asp:Label ID="LblSPJ8Biaya" runat="server"  Text="Biaya Transportasi Rp....................."          Font-Size="Smaller"        Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label108" runat="server"  Text="Tanggal & Jam diterima: __________"          Font-Size="Smaller"        Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label222" runat="server"  Text="Paraf Pelanggan: __________"     Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
            </tr>
            </table>

            <hr />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 50%; ">
                </td>
                <td style="width: 50%; ">
            <asp:Label ID="LblSPJ12TGLSURAT" runat="server"  Text="Jakarta" Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
            </tr>
            </table>
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 30%; ">
            <asp:Label ID="Label113" runat="server"  Text="Supir"  Font-Size="Smaller"    Width="100%"></asp:Label>
                </td>
                <td style="width: 40%; ">
            <asp:Label ID="Label114a" runat="server"  Text="" Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label115a" runat="server"  Text="Kordinator Warehouse"  Font-Size="Smaller"    Width="100%"></asp:Label>
                </td>
            </tr>
            </table>
            <br />
            <br />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 30%; ">
            <asp:Label ID="Label116" runat="server"  Text="Tanggal"  Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
                <td style="width: 40%; ">
            <asp:Label ID="Label117" runat="server"  Text=""  Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label118" runat="server"  Text="Tanggal"  Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
            </tr>
            </table>
        </asp:View> 
        <asp:View ID="ViewCetakSTCK" runat="server">
            <center> <asp:Label ID="Label120" runat="server"   Text="PT. MITRAUSAHA GENTANIAGA" Width="100%"></asp:Label> </center>
            <br />
            <center> <asp:Label ID="Label121" runat="server"  
            Text="HONDA MUGEN PASAR MINGGU" Width="100%"></asp:Label> </center>
            <br />
            <center> <asp:Label ID="Label122" runat="server"  
            Text="VOUCHER BAHAN BAKAR" Width="100%"></asp:Label> </center>
            
            <hr />
            <br />
            <br />
            <br />
            <asp:Label ID="Label123" runat="server"  Text="No SPK"        Width="15%"></asp:Label>
            <asp:Label ID="lblSTCK01SPK" runat="server"  Text="99999"             Width="100%"></asp:Label>
            <asp:Label ID="Label125" runat="server"  Text="No Rangka"           Width="15%"></asp:Label>
            <asp:Label ID="lblSTCK02RGK" runat="server"  Text="99/99/9999"        Width="100%"></asp:Label>
            <asp:Label ID="Label127" runat="server"  Text="Tipe"         Width="15%"></asp:Label>
            <asp:Label ID="lblSTCK03TIPE" runat="server"  Text="99999"             Width="100%"></asp:Label>
            <asp:Label ID="Label129" runat="server"  Text="Tanggal Kirim"                  Width="15%"></asp:Label>
            <asp:Label ID="lblSTCK04TGLK" runat="server"  Text=""                  Width="100%"></asp:Label>
            <asp:Label ID="Label131b" runat="server"  Text="Tanggal Input STCK"              Width="15%"></asp:Label>
            <asp:Label ID="lblSTCK05TGLI" runat="server"  Text="99999"             Width="100%"></asp:Label>
             <br />
            <asp:Label ID="Label131a" runat="server"  Text="Alamat"              Width="15%"></asp:Label>
            <asp:Label ID="lblSTCK06ALAMAT" runat="server"  Text="99999"             Width="100%"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblSTCK07TGLSURAT" runat="server"  Text="Jakarta" Width="100%"></asp:Label>
            <br />
            <asp:Label ID="Label147" runat="server"  Text="Supir"    Width="30%"></asp:Label>
            <asp:Label ID="Label148" runat="server"  Text="Petugas"  Width="30%"></asp:Label>
            <asp:Label ID="Label149" runat="server"  Text="Warehouse"    Width="40%"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label150" runat="server"  Text="Tanggal"  Width="30%"></asp:Label>
            <asp:Label ID="Label151" runat="server"  Text="Tanggal"  Width="30%"></asp:Label>
            <asp:Label ID="Label152" runat="server"  Text="Tanggal"  Width="40%"></asp:Label>
            <br />
            <br />
            <br />
        </asp:View> 
        <asp:View ID="ViewCetakPDI" runat="server">
            <center> <asp:Label ID="Label165" runat="server"   Text="PT. MITRAUSAHA GENTANIAGA" Width="100%"></asp:Label> </center>
            <br />
            <center> <asp:Label ID="Label166" runat="server"  
            Text="HONDA MUGEN PASAR MINGGU" Width="100%"></asp:Label> </center>
            <br />
            <center> <asp:Label ID="Label167" runat="server"  
            Text="VOUCHER BAHAN BAKAR" Width="100%"></asp:Label> </center>
            
            <hr />
            <br />
            <br />
            <br />
            <asp:Label ID="Label168" runat="server"  Text="No SPK"        Width="15%"></asp:Label>
            <asp:Label ID="LbPDISPK" runat="server"  Text="99999"             Width="35%"></asp:Label>
            <asp:Label ID="Label169" runat="server"  Text="No DO"           Width="15%"></asp:Label>
            <asp:Label ID="LbPDIDO" runat="server"  Text="99/99/9999"        Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label170" runat="server"  Text="No Rangka"         Width="15%"></asp:Label>
            <asp:Label ID="LbPDIRGK" runat="server"  Text="99999"             Width="35%"></asp:Label>
            <asp:Label ID="Label171" runat="server"  Text="Nama Sales"                  Width="15%"></asp:Label>
            <asp:Label ID="LbPDISALES" runat="server"  Text=""                  Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label172" runat="server"  Text="Type"              Width="15%"></asp:Label>
            <asp:Label ID="LbPDITIPE" runat="server"  Text="99999"             Width="35%"></asp:Label>
            <asp:Label ID="Label173" runat="server"  Text="Tanggal Mohon" Width="15%"></asp:Label>
            <asp:Label ID="LbPDITGLM" runat="server"  Text="99/99/9999"        Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label174" runat="server"  Text="Warna"            Width="15%"></asp:Label>
            <asp:Label ID="LbPDIWARNA" runat="server"  Text="99999"            Width="35%"></asp:Label>
            <asp:Label ID="Label175" runat="server"  Text="Tanggal Kirim"  Width="15%"></asp:Label>
            <asp:Label ID="LbPDITGLK" runat="server"  Text="99/99/9999"       Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label176" runat="server"  Text=""        Width="15%"></asp:Label>
            <asp:Label ID="Label177" runat="server"  Text="*** Kebersihan dan Fungsi Interior Kendaraan"             Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label212" runat="server"  Text=""           Width="40%"></asp:Label>
            <asp:Label ID="Label213" runat="server"  Text="Supir"        Width="5%"></asp:Label>
            <asp:Label ID="Label214" runat="server"  Text="PDI"           Width="5%"></asp:Label>
            <asp:Label ID="Label215" runat="server"  Text="Catatan"        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label178" runat="server"  Text="Tempat duduk sudah dibersihkan"           Width="40%"></asp:Label>
            <asp:Label ID="Label179" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label187" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label188" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label72" runat="server"  Text="Pemasangan Karpet dasar sudah rapih"           Width="40%"></asp:Label>
            <asp:Label ID="Label84" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label90" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label92" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label93" runat="server"  Text="Tape dan Radio berfungsi dengan baik"           Width="40%"></asp:Label>
            <asp:Label ID="Label96" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label98" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label100" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label102" runat="server"  Text="Power window berfungsi dengan baik"           Width="40%"></asp:Label>
            <asp:Label ID="Label104" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label107" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label109" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label110" runat="server"  Text="Central Lock berfungsi dengan baik"           Width="40%"></asp:Label>
            <asp:Label ID="Label111" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label112" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label114" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label115" runat="server"  Text="Spion Electric Mirror berfungsi dengan baik"           Width="40%"></asp:Label>
            <asp:Label ID="Label119" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label124" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label126" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label128" runat="server"  Text="Wiper berfungsi dengan baik"           Width="40%"></asp:Label>
            <asp:Label ID="Label130" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label131" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label132" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label133" runat="server"  Text="Alarm berfungsi dengan baik"           Width="40%"></asp:Label>
            <asp:Label ID="Label134" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label135" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label136" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label137" runat="server"  Text="Km (Maksimal 35 Km) lebih dari harus konfirmasi"           Width="40%"></asp:Label>
            <asp:Label ID="Label138" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label139" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label140" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label141" runat="server"  Text="Sudah divacum clener"           Width="40%"></asp:Label>
            <asp:Label ID="Label142" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label143" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label144" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label145" runat="server"  Text="Antena sudah terpasang"           Width="40%"></asp:Label>
            <asp:Label ID="Label146" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label153" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label154" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label155" runat="server"  Text="Lampu meyala dengan baik"           Width="40%"></asp:Label>
            <asp:Label ID="Label156" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label157" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label158" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label159" runat="server"  Text="Body Kendaraan tidak ada cacat dan mengkilat"           Width="40%"></asp:Label>
            <asp:Label ID="Label160" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label161" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label162" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label163" runat="server"  Text="Ban dan Velg tidak ada cacat"           Width="40%"></asp:Label>
            <asp:Label ID="Label164" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label181" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label182" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label183" runat="server"  Text="Ketersediaan dongkrak di Bagasi"           Width="40%"></asp:Label>
            <asp:Label ID="Label189" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label190" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label191" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label192" runat="server"  Text="Toolkit Sudah lengkap"           Width="40%"></asp:Label>
            <asp:Label ID="Label193" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label194" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label195" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label196" runat="server"  Text="Ban Serep dan Velg Mulus dan tidak ada cacat"           Width="40%"></asp:Label>
            <asp:Label ID="Label197" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label198" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label199" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label200" runat="server"  Text="Kaca Film dalam kondisi Bagus (Tidak bergelembung dan bintik"           Width="40%"></asp:Label>
            <asp:Label ID="Label201" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label202" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label203" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label204" runat="server"  Text="Perlengkapan Aksesoris"           Width="40%"></asp:Label>
            <asp:Label ID="Label207" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <asp:Label ID="Label208" runat="server"  Text=""           Width="40%"></asp:Label>
            <asp:Label ID="Label209" runat="server"  Text="___"        Width="5%"></asp:Label>
            <asp:Label ID="Label210" runat="server"  Text="___"           Width="5%"></asp:Label>
            <asp:Label ID="Label211" runat="server"  Text="..............................................."        Width="50%"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label180" runat="server"  Text="Jakarta" Width="100%"></asp:Label>
            <br />
            <asp:Label ID="Label181a" runat="server"  Text="Supir"    Width="30%"></asp:Label>
            <asp:Label ID="Label182a" runat="server"  Text="PDI"  Width="30%"></asp:Label>
            <asp:Label ID="Label183a" runat="server"  Text="Kordinator Warehouse"    Width="40%"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label184" runat="server"  Text="Tanggal"  Width="30%"></asp:Label>
            <asp:Label ID="Label185" runat="server"  Text=""  Width="30%"></asp:Label>
            <asp:Label ID="Label186" runat="server"  Text="Tanggal"  Width="40%"></asp:Label>
            <br />
            <br />
            <br />
        </asp:View> 
        <asp:View ID="ViewCetakDO" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 66%; height:12px ">
                </td>
                <td style="width: 14%; height:12px ">
                <asp:Label ID="LblCetakDO_DONo" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 66px; height:12px ">
                </td>
                <td style="width: 14px; height:12px ">
                <asp:Label ID="LblCetakDO_DOTgl" runat="server"  Text="99/99/99"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                </td>
            </tr>
            <tr style="height :24px;" > 
                <td style="width: 66px; height:12px ">
                </td>
                <td style="width: 14px; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                </td>
            </tr>
                   </table>

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 10%; height:12px ">
                </td>
                <td style="width: 70%; height:12px ">
                <asp:Label ID="LblCetakDO_SPKNama" runat="server"  Text="Nama"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 10%; height:12px ">
                </td>
                <td style="width: 70%; height:12px ">
                <asp:Label ID="LblCetakDO_SPKAlamat1" runat="server"  Text="Alamat"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 10%; height:12px ">
                </td>
                <td style="width: 70%; height:12px ">
                <asp:Label ID="LblCetakDO_SPKAlamat2" runat="server"  Text="Alamat"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">

                </td>
            </tr>

       </table>

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">

            <tr style="height :12px;" > 
                <td style="width: 10%; height:12px ">
                </td>
                <td style="width: 28%; height:12px ">
                <asp:Label ID="LblCetakDO_SPKNPWP" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 14%; height:12px ">
                </td>
                <td style="width: 28%; height:12px ">
                 <asp:Label ID="Label282" runat="server"  Text="    "       Font-Size="Smaller"      ></asp:Label>
                 <asp:Label ID="LblCetakDO_SPKPIutang" runat="server"  Text="999,999,999"       Font-Size="Smaller"      ></asp:Label>
               </td>
                <td style="width: 20%; height:12px ">
                </td>
            </tr>
       </table>

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">

            <tr style="height :12px;" > 
                <td style="width: 10%; height:12px ">
                </td>
                <td style="width: 14%; height:12px ">
                </td>
                <td style="width: 14%; height:12px ">
                </td>
                <td style="width: 14%; height:12px ">
                </td>
                <td style="width: 14%; height:12px ">
                </td>
                <td style="width: 14%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                </td>

            </tr>
            <tr style="height :12px;" > 
                <td style="width: 10%; height:12px ">
                </td>
                <td style="width: 14%; height:12px ">
                <asp:Label ID="LblCetakDO_SPKNo" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 14%; height:12px ">
                <asp:Label ID="LblCetakDO_SPKTgl" runat="server"  Text="99/99/99"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 14%; height:12px ">
                </td>
                <td style="width: 28%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                </td>

            </tr>
            <tr style="height :20px;" > 
                <td style="width: 10%; height:12px ">
                </td>
                <td style="width: 14%; height:12px ">
                <asp:Label ID="LblCetakDO_SPKTTKNo" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 14%; height:12px ">
                <asp:Label ID="LblCetakDO_SPKTTKTgl" runat="server"  Text="99/99/99"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 14%; height:12px ">
                </td>
                <td style="width: 28%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                </td>
            </tr>
       </table>

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 10%; height:12px ">
                </td>
                <td style="width: 28%; height:12px ">
                <asp:Label ID="LblCetakDO_Sales" runat="server"  Text="Nama Sales"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 14%; height:12px ">
                </td>
                <td style="width: 28%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 10%; height:12px ">
                </td>
                <td style="width: 28%; height:12px ">
                <asp:Label ID="LblCetakDO_Lease" runat="server"  Text="Nama Leasing"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 14%; height:12px ">
                </td>
                <td style="width: 28%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                </td>
            </tr>
       </table>

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">

            <tr style="height :30px;" > 
                <td style="width: 10%; height:12px ">
                </td>
                <td style="width: 70%; height:12px ">
                <asp:Label ID="LblCetakDO_Terbilang" runat="server"  Text="Seratus Juta"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                </td>
            </tr>
       </table>

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">

            <tr style="height :12px;" > 
                <td style="width: 10%; height:12px ">
                </td>
                <td style="width: 28%; height:12px ">
                <asp:Label ID="LblCetakDO_Type" runat="server"  Text="Merk"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 14%; height:12px ">
                </td>
                <td style="width: 28%; height:12px ">
                <asp:Label ID="LblCetakDO_Rangka" runat="server"  Text="Rangka"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                </td>

            </tr>
            <tr style="height :12px;" > 
                <td style="width: 10%; height:12px ">
                </td>
                <td style="width: 28%; height:12px ">
                <asp:Label ID="LblCetakDO_Tipe" runat="server"  Text="Tipe"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 14%; height:12px ">
                </td>

                <td style="width: 28%; height:12px ">
                <asp:Label ID="LblCetakDO_Mesin" runat="server"  Text="Mesin"       Font-Size="Smaller"      ></asp:Label>
                </td>
               <td style="width: 20%; height:12px ">
                </td>

            </tr>
            <tr style="height :12px;" > 
                <td style="width: 10%; height:12px ">
                </td>
                <td style="width: 28%; height:12px ">
                <asp:Label ID="LblCetakDO_Warna" runat="server"  Text="Warna"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 14%; height:12px ">
                </td>

                <td style="width: 28%; height:12px ">
                <asp:Label ID="LblCetakDO_Surat" runat="server"  Text="Surat"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                </td>

            </tr>
       </table>

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">

            <tr style="height :12px;" > 
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                </td>
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                </td>
                <td style="width: 16%; height:12px ">
                </td>
            </tr>


            <tr style="height :12px;" > 
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass11" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass12" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass13" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass14" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 16%; height:12px ">
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass21" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass22" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass23" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass24" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 16%; height:12px ">
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass31" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass32" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass33" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass34" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 16%; height:12px ">
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass41" runat="server"  Text="999999"       Font-Size="Smaller" Width="99%"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass42" runat="server"  Text="999999"       Font-Size="Smaller"  Width="99%"       ></asp:Label>
                </td>
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass43" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass44" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 16%; height:12px ">
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass51" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass52" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass53" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass54" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 16%; height:12px ">
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass61" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass62" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass63" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass64" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 16%; height:12px ">
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass71" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass72" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass73" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass74" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 16%; height:12px ">
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass81" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass82" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass83" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass84" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 16%; height:12px ">
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass91" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass92" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 2%; height:12px ">
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass93" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 20%; height:12px ">
                <asp:Label ID="LblCetakDO_Ass94" runat="server"  Text="999999"       Font-Size="Smaller"      ></asp:Label>
                </td>
                <td style="width: 16%; height:12px ">
                </td>
            </tr>

       </table>

       </asp:View> 
        <asp:View ID="ViewCetakSPKNonCustomer" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small">
            <tr> 
                <td style="width: 100%; height:12px ">
             <center> <asp:Label ID="Label33" runat="server"   Text="PT. MITRAUSAHA GENTANIAGA" Width="100%"></asp:Label>  </center>
                </td>
            </tr>
            <tr> 
                <td style="width: 100%; height:12px ">
             <center> <asp:Label ID="Label34" runat="server"  Text="HONDA MUGEN PASAR MINGGU" Width="100%"></asp:Label> </center>
                </td>
            </tr>
            <tr> 
                <td style="width: 100%; height:12px ">
             <center> <asp:Label ID="Label35" runat="server" Text="SPJ" Width="100%"></asp:Label> </center>
                </td>
            </tr>
            </table>
            <hr />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="Label39" runat="server"  Text="No Dokumen Kirim"       Font-Size="Smaller"  Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="LblSPJNS1NoDoc" runat="server"  Text="99999"         Font-Size="Smaller"    Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
                </td>
                <td style="width: 30%; ">
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="Label263" runat="server"  Text="No Rangka"       Font-Size="Smaller"  Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="LblSPJNS1NoRangka" runat="server"  Text="99999"         Font-Size="Smaller"    Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="Label265" runat="server"  Text="No Mesin"       Font-Size="Smaller"           Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="LblSPJNS1NoMesin" runat="server"  Text=""            Font-Size="Smaller"      Width="100%"></asp:Label>
                </td>
            </tr>
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="Label267" runat="server"  Text="Type"          Font-Size="Smaller"     Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="LblSPJNS2Tipe" runat="server"  Text="99999"     Font-Size="Smaller"         Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="Label269" runat="server"  Text="Supir" Font-Size="Smaller"  Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="LblSPJNS2Supir" runat="server"  Text="99/99/9999" Font-Size="Smaller"        Width="100%"></asp:Label>
                </td>
            </tr>

            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="Label271" runat="server"  Text="Warna"          Font-Size="Smaller"       Width="100%"></asp:Label>
                </td>
                <td style="width: 35%; ">
            <asp:Label ID="LblSPJNS3Warna" runat="server"  Text="99999"       Font-Size="Smaller"          Width="100%"></asp:Label>
                </td>
                <td style="width: 20%; ">
            <asp:Label ID="Label273" runat="server"  Text="Tanggal Kirim"  Font-Size="Smaller"      Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="LblSPJNS3Kirim" runat="server"  Text="99/99/9999"    Font-Size="Smaller"        Width="100%"></asp:Label>
                </td>
            </tr>
            </table>

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 15%; ">
            <asp:Label ID="Label275" runat="server"  Text="Catatan"   Font-Size="Smaller"              Width="100%"></asp:Label>
                </td>
                <td style="width: 85%; ">
            <asp:Label ID="LblSPJNS4Catatan" runat="server"  Text=""   Font-Size="Smaller"         Width="100%"></asp:Label>
                </td>
            </tr>
            </table>

            <hr />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :15px;" > 
                <td style="width: 40%; ">
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label294" runat="server"  Text="Tanggal & Jam Keluar : __________"          Font-Size="Smaller"        Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label295" runat="server"  Text="Paraf Security: __________"     Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
            </tr>
            <tr style="height :15px;" > 
                <td style="width: 40%; ">
            <asp:Label ID="LblSPJNS4Ongkos" runat="server"  Text="Biaya Transportasi Rp....................."          Font-Size="Smaller"        Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label297" runat="server"  Text="Tanggal & Jam diterima: __________"          Font-Size="Smaller"        Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label298" runat="server"  Text="Paraf Penerima: __________"     Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
            </tr>
            </table>

            <hr />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 50%; ">
                </td>
                <td style="width: 50%; ">
            <asp:Label ID="LblSPJNSTGLSURAT" runat="server"  Text="Jakarta" Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
            </tr>
            </table>
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 30%; ">
            <asp:Label ID="Label300" runat="server"  Text="Supir"  Font-Size="Smaller"    Width="100%"></asp:Label>
                </td>
                <td style="width: 40%; ">
            <asp:Label ID="Label301" runat="server"  Text="Periksa PDI" Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label302" runat="server"  Text="Kordinator Warehouse"  Font-Size="Smaller"    Width="100%"></asp:Label>
                </td>
            </tr>
            </table>
            <br />
            <br />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr style="height :12px;" > 
                <td style="width: 30%; ">
            <asp:Label ID="Label303" runat="server"  Text="Tanggal"  Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
                <td style="width: 40%; ">
            <asp:Label ID="Label304" runat="server"  Text="Tanggal"  Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
                <td style="width: 30%; ">
            <asp:Label ID="Label305" runat="server"  Text="Tanggal"  Font-Size="Smaller"   Width="100%"></asp:Label>
                </td>
            </tr>
            </table>
        </asp:View> 
 


        </asp:MultiView> 
    </asp:Panel>
    </div>

    
</asp:Content>
