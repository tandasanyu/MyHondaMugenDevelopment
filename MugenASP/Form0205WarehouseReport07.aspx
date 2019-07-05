<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0205WarehouseReport07.aspx.vb" Inherits="Form0205WarehouseReport07" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">Laporan Stock</h2>
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
<br />
   <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
        <center>  <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" 
                Font-Names="Arial" Font-Size="Small" ForeColor="Yellow" height="40px"  
                Width="100%" BackColor="Red">Error Massage</asp:Label></center>
    </asp:View> 
    </asp:MultiView>





    <asp:MultiView ID="MultiView1menu" runat="server" Visible="TRUE">
    <asp:View ID="View8" runat="server">
        
        
        <table style="width: 100%; height:inherit ; font-family: Arial; font-size: small; border-top-color: red; border-top-style: solid; border-top-width: thin; border-bottom-color: red; border-bottom-style: solid; border-bottom-width: thin; border-left-color: red; border-left-style: solid; border-left-width: thin; border-right-color: red; border-right-style: solid; border-right-width: thin;">
        <tr>
            <td style="width: 30%; background-color: #CCCCFF;">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Tampilan "></asp:Label>
            </td>
            <td style="width: 70%; background-color: #CCCCFF;">
               <asp:Button ID="Button1" runat="server" Text="TAMPILAN" 
                    BackColor="#003399" 
                    Height="20px" Font-Overline="False" Font-Size="Small" Width="107px" />

                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="                   "></asp:Label>

            </td>
        </tr>
        <tr>
            <td style="width: 30%; background-color: #CCCCFF;">
                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Lokasi Pasar Minggu"></asp:Label>
            </td>
            <td style="width: 70%; background-color: #CCCCFF;">
               <asp:Button ID="Button2" runat="server" Text="TAMPILAN" 
                    BackColor="#003399" 
                    Height="20px" Font-Overline="False" Font-Size="Small" Width="107px" />

                <asp:Label ID="LblProses" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="                   "></asp:Label>

                <asp:Button ID="BtnCetak" runat="server" BackColor="#003399" 
                    Font-Overline="False" Font-Size="Small" Height="20px" Text="Export to Excel" />
            </td>
        </tr>
        <tr>
            <td style="width: 30%; background-color: #CCCCFF;">
                <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Lokasi Puri"></asp:Label>
            </td>
            <td style="width: 70%; background-color: #CCCCFF;">
               <asp:Button ID="Button4" runat="server" Text="TAMPILAN" 
                    BackColor="#003399" 
                    Height="20px" Font-Overline="False" Font-Size="Small" Width="107px" />

                <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="                   "></asp:Label>

                <asp:Button ID="Button5" runat="server" BackColor="#003399" 
                    Font-Overline="False" Font-Size="Small" Height="20px" Text="Export to Excel" />
            </td>
        </tr>

        </table>

        <asp:MultiView ID="MultiVStock" runat="server" Visible="TRUE">

            <asp:View ID="ViewPSM" runat="server">
            <div>
            <center>
                <h2 style="font-family:Cooper Black;">Stock Pasar Minggu</h2>
            </center>
	        </div>  
            <asp:SqlDataSource ID="sdsTabelStockPSM" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet112 %>" 
            SelectCommand="SELECT TRXN_STOCK.STOCK_NoTTK, TRXN_STOCK.STOCK_NoRangka, TRXN_STOCK.STOCK_NoMesin, TRXN_STOCK.STOCK_NoKunci, TRXN_STOCK.STOCK_CdWarna, DATA_WARNA.WARNA_Int, TRXN_STOCK.STOCK_CdType, DATA_TYPE.TYPE_Nama, TRXN_STOCK.STOCK_CdSuplier, DATA_SUPLIER.SUPLIER_Nama, TRXN_STOCK.STOCK_CdLokasi, DATA_LOKASI.LOKASI_Nama, TRXN_STOCK.STOCK_KirimTGLTerima, DATA_TYPE.TYPE_Group, TRXN_SPK.SPK_TglDO FROM DATA_TYPE RIGHT OUTER JOIN DATA_LOKASI RIGHT OUTER JOIN TRXN_STOCK LEFT OUTER JOIN TRXN_SPK ON TRXN_STOCK.STOCK_NoRangka = TRXN_SPK.SPK_NoRangka LEFT OUTER JOIN DATA_SUPLIER ON TRXN_STOCK.STOCK_CdSuplier = DATA_SUPLIER.SUPLIER_Kode ON DATA_LOKASI.LOKASI_Kode = TRXN_STOCK.STOCK_CdLokasi ON DATA_TYPE.TYPE_Type = TRXN_STOCK.STOCK_CdType LEFT OUTER JOIN DATA_WARNA ON TRXN_STOCK.STOCK_CdWarna = DATA_WARNA.WARNA_Kode RIGHT OUTER JOIN TEMP_STOCKWAREHOSE ON TRXN_STOCK.STOCK_NoRangka = TEMP_STOCKWAREHOSE.STOCKWAREHOSE_NORANGKA ORDER BY TRXN_STOCK.STOCK_CDLOKASI,DATA_TYPE.TYPE_Group, TRXN_STOCK.STOCK_CdType,TRXN_STOCK.STOCK_CdWarna, TRXN_STOCK.STOCK_NoTTK"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet112.ProviderName %>">
            </asp:SqlDataSource>            
            <asp:ListView ID="LVSTOCKPSM" runat="server" DataSourceID="sdsTabelStockPSM" DataKeyNames ="STOCK_NoRangka">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px">
                      <th>No TTK</th><th>Rangka</th><th>Mesin</th><th>Kunci</th><th>Warna</th><th>Tipe</th><th>Suplier</th><th>Lokasi</th><th>Tgl DO</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width:5%; font-size: x-small"><%#Eval("STOCK_NoTTK")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("STOCK_NoRangka")%></td>
                    <td style="width:8%; font-size: x-small"><%#Eval("STOCK_NoMesin")%></td>
                    <td style="width:5%; font-size: x-small"><%#Eval("STOCK_NoKunci")%></td>
                    <td style="width:16%; font-size: x-small"><%#Eval("WARNA_Int")%></td>
                    <td style="width:16%; font-size: x-small"><%#Eval("TYPE_Nama")%></td>
                    <td style="width:15%; font-size: x-small"><%#Eval("SUPLIER_Nama")%></td>
                    <td style="width:15%; font-size: x-small"><%#Eval("LOKASI_Nama")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("SPK_TglDO")%></td>
                </tr>
            </ItemTemplate>
            </asp:ListView>
            </asp:View>

            <asp:View ID="View1" runat="server">
            <div>
            <center>
                <h2 style="font-family:Cooper Black;">Puri Kembangan</h2>
            </center>
	        </div>  
            <asp:SqlDataSource ID="SqlDataSourcePURI" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet128%>" 
            SelectCommand="SELECT TRXN_STOCK.STOCK_NoTTK, TRXN_STOCK.STOCK_NoRangka, TRXN_STOCK.STOCK_NoMesin, TRXN_STOCK.STOCK_NoKunci, TRXN_STOCK.STOCK_CdWarna, DATA_WARNA.WARNA_Int, TRXN_STOCK.STOCK_CdType, DATA_TYPE.TYPE_Nama, TRXN_STOCK.STOCK_CdSuplier, DATA_SUPLIER.SUPLIER_Nama, TRXN_STOCK.STOCK_CdLokasi, DATA_LOKASI.LOKASI_Nama, TRXN_STOCK.STOCK_KirimTGLTerima, DATA_TYPE.TYPE_Group, TRXN_SPK.SPK_TglDO FROM DATA_TYPE RIGHT OUTER JOIN DATA_LOKASI RIGHT OUTER JOIN TRXN_STOCK LEFT OUTER JOIN TRXN_SPK ON TRXN_STOCK.STOCK_NoRangka = TRXN_SPK.SPK_NoRangka LEFT OUTER JOIN DATA_SUPLIER ON TRXN_STOCK.STOCK_CdSuplier = DATA_SUPLIER.SUPLIER_Kode ON DATA_LOKASI.LOKASI_Kode = TRXN_STOCK.STOCK_CdLokasi ON DATA_TYPE.TYPE_Type = TRXN_STOCK.STOCK_CdType LEFT OUTER JOIN DATA_WARNA ON TRXN_STOCK.STOCK_CdWarna = DATA_WARNA.WARNA_Kode RIGHT OUTER JOIN TEMP_STOCKWAREHOSE ON TRXN_STOCK.STOCK_NoRangka = TEMP_STOCKWAREHOSE.STOCKWAREHOSE_NORANGKA ORDER BY TRXN_STOCK.STOCK_CDLOKASI,DATA_TYPE.TYPE_Group, TRXN_STOCK.STOCK_CdType,TRXN_STOCK.STOCK_CdWarna, TRXN_STOCK.STOCK_NoTTK"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet128.ProviderName %>">
            </asp:SqlDataSource>            
            <asp:ListView ID="LVSTOCKPURI" runat="server" DataSourceID="SqlDataSourcePURI" DataKeyNames ="STOCK_NoRangka">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px">
                      <th>No TTK</th><th>Rangka</th><th>Mesin</th><th>Kunci</th><th>Warna</th><th>Tipe</th><th>Suplier</th><th>Lokasi</th><th>Tgl DO</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width:5%; font-size: x-small"><%#Eval("STOCK_NoTTK")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("STOCK_NoRangka")%></td>
                    <td style="width:8%; font-size: x-small"><%#Eval("STOCK_NoMesin")%></td>
                    <td style="width:5%; font-size: x-small"><%#Eval("STOCK_NoKunci")%></td>
                    <td style="width:16%; font-size: x-small"><%#Eval("WARNA_Int")%></td>
                    <td style="width:16%; font-size: x-small"><%#Eval("TYPE_Nama")%></td>
                    <td style="width:15%; font-size: x-small"><%#Eval("SUPLIER_Nama")%></td>
                    <td style="width:15%; font-size: x-small"><%#Eval("LOKASI_Nama")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("SPK_TglDO")%></td>
                </tr>
            </ItemTemplate>
            </asp:ListView>
            </asp:View>

        </asp:MultiView>



    </asp:View>

  </asp:MultiView>
</asp:Content>
