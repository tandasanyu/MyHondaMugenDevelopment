<%@ Page Language="VB" MasterPageFile ="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0205Warehouse.aspx.vb" Inherits="Form0205Warehouse" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID%>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }


    </script>
    <br />
    <p   style ="font-size:smaller" >
        <asp:Label ID="Label44"  Text ="Informasi Pemasangan Aksesoris >> " runat="server"></asp:Label>
        &nbsp; Nama User&nbsp; : 
        <asp:Label ID="LblUserName" runat="server"></asp:Label>
        <asp:Label ID="lblAkses" runat="server"></asp:Label>
        &nbsp; Akses &nbsp; : 
        <asp:Label ID="lblArea1" runat="server"></asp:Label>
        <asp:Label ID="lblArea2" runat="server"></asp:Label>
    </p>
    <br />
    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
          
        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Judul 
        Permohonan</asp:Label>
          
    </asp:View> 
    </asp:MultiView>

    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 34%; ">
               <asp:Button ID="BtnHal1" runat="server" Text="Jadwal Pengiriman" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 33%; ">
               <asp:Button ID="BtnHal2" runat="server" Text="Pasang Aksesoris" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 33%; ">
               <asp:Button ID="BtnHal3" runat="server" Text="Stok" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
        </tr>
     </table>


    <asp:MultiView ID="MultiViewWarehouse" runat="server" Visible="TRUE">
        <asp:View ID="View01Jadwal" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 25%; ">
               <asp:Label ID="Label17" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Jadwal Tanggal Pengiriman"></asp:Label>
            </td>
            <td style="width: 25%; ">
                <asp:TextBox ID="txtDate" runat="server" />
                <asp:Button ID="BtnCal1" runat="server" Text=".." Width="27px" />
                <div id="tanggalPopup">
                <asp:Calendar ID="Calendar1" runat="server" onselectionchanged="Calendar1_SelectionChanged" />
                </div>
            </td>
            <td style="width: 75%; ">
               <asp:Button ID="Button4" runat="server" Text=" &lt;---- Pencarian Jadwal Pengiriman Unit berdasarkan tanggal kirim" 
                    Width="413px" BackColor="#0033CC" />
            </td>
            </tr>
            </table> 
            <asp:MultiView ID="MultiV4Jadwal" runat="server" Visible="TRUE">
            <asp:View ID="V401" runat="server">

            <asp:SqlDataSource ID="sdsTabelJdw" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand = "SELECT * FROM TRXN_STOCKMKIRIM LEFT OUTER JOIN TRXN_STOCK ON TRXN_STOCKMKIRIM.STOCKM_NORANGKA = TRXN_STOCK.STOCK_NoRangka LEFT OUTER JOIN TRXN_STOCKKKIRIM ON TRXN_STOCK.STOCK_NoRangka = TRXN_STOCKKKIRIM.STOCKK_NORANGKA WHERE (TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM = ?)"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
            <asp:ControlParameter ControlID="txtDate" Name="STOCKM_TGLMOHONKIRIM" PropertyName="Text" Type="String" />
            </SelectParameters>

            
            </asp:SqlDataSource>                 
            <asp:ListView ID="lvKirimmUnit" runat="server" DataSourceID="sdsTabelJdw" DataKeyNames ="STOCKM_NORANGKA">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead  style="background-color:Silver; height:30px">
                      <th>Dealer</th><th>Sales</th><th>Nomor Rangka</th><th>Tgl Input</th><th>Tgl Mohon</th><th>Tgl Kirim</th><th>Tgl SPJ</th><th>Terima</th><th>Keterangan</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            <asp:DataPager ID="dpBerita" PageSize="50" runat="server">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" />
            </Fields>
            </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
                <tr>
                    <td style="width:5%; font-size: small"><%#Eval("STOCKM_KDDEALER")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("STOCKM_SALES")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("STOCKM_NORANGKA")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("STOCKM_TGLMOHONINPUT")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("STOCKM_TGLMOHONKIRIM")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("STOCKM_KIRIMTGLSETUJUI")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("STOCKK_KIRIMTGLKIRIM")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("STOCKK_KIRIMTGLTERIMA")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("STOCKK_KIRIMKETTERIMA")%></td>
                </tr>
                </ItemTemplate>
        </asp:ListView>
        </asp:View>
        </asp:MultiView>
        </asp:View>

        <asp:View ID="ViewPasangAksesoris" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 25%; ">
               <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Permohonan Nomor Rangka"></asp:Label>
            </td>
            <td style="width: 25%; ">
               <asp:TextBox ID="txtjudul" text="" runat="server" Width="250px" CssClass="uppercase"></asp:TextBox>
            </td>
            <td style="width: 75%; ">
               <asp:Button ID="btnfilter" runat="server" Text=" <---- Pencarian Pemasang Asesoris berdasarakan nomor rangka" 
                    Width="413px" BackColor="#0033CC" />
            </td>
        </tr>
        </table>
        <asp:MultiView ID="MultiV1WAss" runat="server" Visible="TRUE">
        <asp:View ID="V1A" runat="server">

            <asp:SqlDataSource ID="sdsTabelAksesorisWarehouse" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT TRXN_STOCKAKSESORIS.STOCKA_NORANGKA, TRXN_STOCKAKSESORIS.STOCKA_NAMA, DATA_SUPLIER.SUPLIER_Nama, TRXN_STOCKAKSESORIS.STOCKA_TGLSUPLIER, TRXN_STOCKAKSESORIS.STOCKA_TGLPSG, TRXN_STOCKAKSESORIS.STOCKA_BERITA, TRXN_STOCKAKSESORIS.STOCKA_ALASAN, DATA_TYPE.TYPE_Nama, DATA_WARNA.WARNA_Int FROM TRXN_STOCKAKSESORIS LEFT OUTER JOIN DATA_SUPLIER ON TRXN_STOCKAKSESORIS.STOCKA_KDSUPLIER = DATA_SUPLIER.SUPLIER_Kode LEFT OUTER JOIN TRXN_STOCK LEFT OUTER JOIN DATA_WARNA ON TRXN_STOCK.STOCK_CdWarna = DATA_WARNA.WARNA_Kode LEFT OUTER JOIN DATA_TYPE ON TRXN_STOCK.STOCK_CdType = DATA_TYPE.TYPE_Type ON TRXN_STOCKAKSESORIS.STOCKA_NORANGKA = TRXN_STOCK.STOCK_NoRangka WHERE ([STOCKA_NORANGKA] LIKE '%' + ? + '%')"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
            <asp:ControlParameter ControlID="txtjudul" Name="STOCKA_NORANGKA" PropertyName="Text" Type="String" />
            </SelectParameters>
            </asp:SqlDataSource>            
            <asp:ListView ID="lvBerita" runat="server" DataSourceID="sdsTabelAksesorisWarehouse" DataKeyNames ="STOCKA_NORANGKA">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px">
                      <th>Nomor Rangka</th><th>Nama</th><th>Suplier</th><th>Tanggal Order</th><th>Tanggal Pasang</th><th>Berita</th><th>Keterangan</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            <asp:DataPager ID="dpBerita" PageSize="15" runat="server">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" />
            </Fields>
            </asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width:15%; font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("STOCKA_NORANGKA") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:20%; font-size: x-small"><%#Eval("STOCKA_NAMA")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("SUPLIER_Nama")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("STOCKA_TGLSUPLIER")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("STOCKA_TGLPSG")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("STOCKA_BERITA")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("STOCKA_ALASAN")%></td>
                </tr>
            </ItemTemplate>
            </asp:ListView>
            </asp:View>
            </asp:MultiView>
        </asp:View>                    

        <asp:View ID="View03Stok" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 34%; ">
               <asp:Button ID="BtnTTKClear" runat="server" Text="Bersihkan" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 33%; ">
               <asp:Button ID="BtnTTKSave" runat="server" Text="Simpan" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 33%; ">
               <asp:Button ID="BtnTTKBatal" runat="server" Text="Batal" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
        </tr>
     </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Button ID="BtnF2NoTTK" runat="server" BackColor="Black" BorderStyle="None" 
                        Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" 
                        Font-Underline="True" ForeColor="Blue" Text="No TTK" Width="99px" />
                </td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtNoTTK" runat="server" text="" Width="99%" MaxLength="7" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 15%; ">
                    <asp:Label ID="lblNoTTKTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Visible="false"  Text="Tag"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Button ID="ButtonCariTTK" runat="server" BackColor="Blue" 
                        Font-Overline="False" Font-Size="Small" Height="20px" Text="Perbarui Tabel" /></td> 
            </tr>
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
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
            <asp:ListView ID="LvDataTabelStok" runat="server" DataSourceID="sdsTabelStok" DataKeyNames ="STOCK_NOTTK">
                <LayoutTemplate>
                <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px">
                      <th>No TTK</th><th>Tgl TTK</th><th>Nomor Rangka</th><th>Tipe</th><th>Warna</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
                <asp:DataPager ID="dpAksesoris" PageSize="20" runat="server" >
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false"   />

                    <asp:NumericPagerField  />

                    <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" />
                </Fields>
                </asp:DataPager>
                
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                    <td style="width:10%; font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("STOCK_NOTTK") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:40%; font-size: x-small"><%#Eval("STOCK_TglTTK")%></td>
                    <td style="width:40%; font-size: x-small"><%#Eval("STOCK_NORANGKA")%></td>
                    <td style="width:40%; font-size: x-small"><%#Eval("STOCK_CDTYPE")%></td>
                    <td style="width:40%; font-size: x-small"><%#Eval("STOCK_CDWARNA")%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </asp:View> 
        </asp:MultiView>

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 25%; ">
               <asp:Button ID="BtnStok1" runat="server" Text="Detail Kendaran" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 25%; ">
               <asp:Button ID="BtnStok2" runat="server" Text="Detail Pengiriman" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 25%; ">
               <asp:Button ID="BtnStok3" runat="server" Text="Detail Perbaikan" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 25%; ">
               <asp:Button ID="BtnStok4" runat="server" Text="Detail STCK" Width="99%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
        </tr>
        </table>
        <asp:MultiView ID="Multi03Stok" runat="server" Visible="TRUE">
        <asp:View ID="View03Stoka" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Button ID="BtnF2NoRangka" runat="server" BackColor="Black" 
                        BorderStyle="None" Font-Bold="True" Font-Italic="True" Font-Overline="False" 
                        Font-Size="Small" Font-Underline="True" ForeColor="Blue" Text="No Rangka" />
                </td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtNoRangka" runat="server" text="" Width="99%" MaxLength="20" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 15%; ">
                    &nbsp;</td> 
                <td style="width: 35%; ">
                    <asp:Label ID="lblNoRangkaTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"  Visible="false" Text="lblNoRangkaTag"></asp:Label></td>
            </tr>
            </table>
            <asp:MultiView ID="MultiViewStockImora" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
            <asp:SqlDataSource ID="SqlDataStockDoImora" runat="server" 
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
                SelectCommand="SELECT *, 
                              (SELECT STOCK_NOTTK FROM TRXN_STOCK WHERE STOCK_NoRangka = STOCKDO_NORANGKA) AS NoTTK 
                              FROM TRXN_STOCKDO WHERE ([STOCKDO_NORANGKA] LIKE '%' + ? + '%') ORDER BY STOCKDO_NORANGKA"
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                <SelectParameters>
                <asp:ControlParameter ControlID="TxtNoRangka" Name="STOCKDO_NORANGKA" PropertyName="Text" Type="String"  DefaultValue ="%" />
                </SelectParameters>
            </asp:SqlDataSource>                 
            <asp:ListView ID="LvDataStockDoImora" runat="server" DataSourceID="SqlDataStockDoImora" DataKeyNames ="STOCKDO_NORANGKA">
                <LayoutTemplate>
                <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px">
                      <th>NO. Rangka</th><th>Dealer</th><th>No TTK</th><th>No DO Suplier</th><th>Tgl DO Suplier</th><th>Warna</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
                <asp:DataPager ID="dpAksesoris" PageSize="20" runat="server" >
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false"   />

                    <asp:NumericPagerField  />

                    <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" />
                </Fields>
                </asp:DataPager>
                
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                    <td style="width:15%; font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("STOCKDO_NORANGKA") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:5%; font-size: x-small"><%#Eval("STOCKDO_KODEDLR")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("NoTTK")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("STOCKDO_NODOSPL")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("STOCKDO_TGDOSPL")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("STOCKDO_WARNADOSPLDESC")%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            </asp:View> 
            </asp:MultiView>

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
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
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Button ID="BtnF2Tipe" runat="server" BackColor="Black" BorderStyle="None" 
                        Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" 
                        Font-Underline="True" ForeColor="Blue" Text="Kode Tipe" />
                </td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtCdType" runat="server" text="" Width="20%" MaxLength="7" CssClass="uppercase"></asp:TextBox>
                    <asp:Label ID="lblCdTypeTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"  Visible="false" Text="lblCdTypeTag"></asp:Label></td>
                <td style="width: 15%; ">
                    <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama Tipe"></asp:Label></td>
                <td style="width: 35%; ">
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
            <asp:ListView ID="LvDataType" runat="server" DataSourceID="SqlDataType" DataKeyNames ="TYPE_Type">
                <LayoutTemplate>
                <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px">
                      <th>Kode </th><th>Tipe</th><th>Group</th><th>Key </th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
                <asp:DataPager ID="dpAksesoris" PageSize="20" runat="server" >
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false"   />

                    <asp:NumericPagerField  />

                    <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" />
                </Fields>
                </asp:DataPager>
                
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                    <td style="width:10%; font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("TYPE_Type") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:50%; font-size: x-small"><%#Eval("TYPE_Nama")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("TYPE_CdGroup")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("TYPE_CdRangka")%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            </asp:View> 
            </asp:MultiView>
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
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
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Button ID="BtnF2Warna" runat="server" BackColor="Black" BorderStyle="None" 
                        Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" 
                        Font-Underline="True" ForeColor="Blue" Text="Kode Warna" />
                </td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtCdWarna" runat="server" text="" Width="20%" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    <asp:Label ID="lblCdWarnaTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Visible="false"  Text="lblCdWarnaTag"></asp:Label></td>
                <td style="width: 15%; ">
                    <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama Warna"></asp:Label></td>
                <td style="width: 35%; ">
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
            <asp:ListView ID="LvWarna" runat="server" DataSourceID="SqlDataWarna" DataKeyNames ="WARNA_Kode">
                <LayoutTemplate>
                <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px">
                      <th>Kode </th><th>Kode HPM</th><th>Internal</th><th>External</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
                <asp:DataPager ID="dpAksesoris" PageSize="20" runat="server" >
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false"   />

                    <asp:NumericPagerField  />

                    <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" />
                </Fields>
                </asp:DataPager>
                
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                    <td style="width:10%; font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("WARNA_Kode") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:50%; font-size: x-small"><%#Eval("WARNA_KODEHPM")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("WARNA_Int")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("WARNA_Ext")%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            </asp:View> 
            </asp:MultiView>
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
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
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tahun"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtTahun" runat="server" text="" Width="99%" MaxLength="2" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 15%; ">
                    <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl DO Imora"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtDtTglDoIm" runat="server" />
                    <asp:Button ID="BtnCal2" runat="server" Text=".." Width="27px" />
                    <div id="Div1">
                    <asp:Calendar ID="Calendar2" runat="server" onselectionchanged="Calendar2_SelectionChanged" />
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
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
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Button ID="BtnF2Suplier" runat="server" BackColor="Black" 
                        BorderStyle="None" Font-Bold="True" Font-Italic="True" Font-Overline="False" 
                        Font-Size="Small" Font-Underline="True" ForeColor="Blue" Text="Kode Suplier" />
                </td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtCdSuplier" runat="server" text="" Width="10%" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    <asp:Label ID="lblCdSuplierTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Faktur > Nama" Visible="false"  ></asp:Label>
                    <asp:Label ID="nmSuplier" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Width="90%" Text=""></asp:Label></td>
                <td style="width: 15%; ">
                    <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Terima Unit"></asp:Label></td>
                <td style="width: 35%; ">
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
                SelectCommand="SELECT * FROM DATA_SUPLIER WHERE ([SUPLIER_Kode] LIKE '%' + ? + '%') ORDER BY SUPLIER_Kode"
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                <SelectParameters>
                <asp:ControlParameter ControlID="TxtCdSuplier" Name="SUPLIER_Kode" PropertyName="Text" Type="String"  DefaultValue ="%" />
                </SelectParameters>
            </asp:SqlDataSource>                 
            <asp:ListView ID="LvSuplier" runat="server" DataSourceID="SqlDataSuplier" DataKeyNames ="SUPLIER_Kode">
                <LayoutTemplate>
                <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px">
                      <th>Kode </th><th>Nama</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
                <asp:DataPager ID="dpAksesoris" PageSize="20" runat="server" >
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false"   />

                    <asp:NumericPagerField  />

                    <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" />
                </Fields>
                </asp:DataPager>
                
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                    <td style="width:10%; font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("SUPLIER_Kode") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:50%; font-size: x-small"><%#Eval("SUPLIER_Nama")%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            </asp:View> 
            </asp:MultiView>
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Button ID="BtnF2Lokasi" runat="server" BackColor="Black" 
                        BorderStyle="None" Font-Bold="True" Font-Italic="True" Font-Overline="False" 
                        Font-Size="Small" Font-Underline="True" ForeColor="Blue" Text="Kode Lokasi" />
                </td>
                <td style="width: 85%; ">
                    <asp:TextBox ID="TxtcdLokasi" runat="server" text="" Width="10%" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    <asp:Label ID="lblcdLokasiTag" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Faktur > Nama" Visible="false"  ></asp:Label>
                    <asp:Label ID="NamaLokasi" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label>
                    <asp:Label ID="Kodedealer" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label></td>
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
            <asp:ListView ID="LvLokasi" runat="server" DataSourceID="SqlDataLokasi" DataKeyNames ="LOKASI_Kode">
                <LayoutTemplate>
                <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px">
                      <th>Kode </th><th>Nama</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
                <asp:DataPager ID="dpAksesoris" PageSize="20" runat="server" >
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false"   />

                    <asp:NumericPagerField  />

                    <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" />
                </Fields>
                </asp:DataPager>
                
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                    <td style="width:10%; font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("LOKASI_Kode") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:50%; font-size: x-small"><%#Eval("LOKASI_Nama")%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            </asp:View> 
            </asp:MultiView>
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label18" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Lokasi Cross seling"></asp:Label></td>
                <td style="width: 85%; ">
                    <asp:Label ID="LblCrsSellMugen" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Width="10%" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label21" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Keterangan"></asp:Label></td>
                <td style="width: 85%; ">
                    <asp:TextBox ID="TxtKeterangan" runat="server" text="" Width="99%" 
                        MaxLength="25" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label22" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Isi Alasan Batal TTK"></asp:Label></td>
                <td style="width: 85%; ">
                    <asp:TextBox ID="TxtAlasanBatal" runat="server" text="" Width="99%" 
                        MaxLength="50" CssClass="uppercase"></asp:TextBox></td>
            </tr>

            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label19" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Status"></asp:Label></td>
                <td style="width: 85%; ">
                    <asp:Label ID="LblStatus" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Width="10%" Text=""></asp:Label></td>
            </tr>
            </table> 
        </asp:View>
        <asp:View ID="View03StokB" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 50%; ">
                    <asp:Label ID="Label20" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Alamat Pengiriman"></asp:Label></td>
                <td style="width: 50%; ">
                    <asp:Button ID="ButtonCariTTK0" runat="server" BackColor="Yellow" 
                        Font-Overline="False" Font-Size="Small" Height="20px" Text="Ubah Alama" />
                </td>
            </tr>
            
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label27" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtNama" runat="server" text="" Width="90%" MaxLength="35" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 15%; ">
                    <asp:Label ID="Label24" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="No HP"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtNoHP" runat="server" text="" Width="90%" MaxLength="20" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label25" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Alamat"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtAlamat" runat="server" text="" Width="90%" MaxLength="80" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 15%; ">
                    <asp:Label ID="Label61" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="No Phone"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtPhone" runat="server" text="" Width="90%" MaxLength="20" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label63" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Kota"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtKota" runat="server" text="" Width="90%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 15%; "></td>
                <td style="width: 35%; "></td>
            </tr>
            </table> 
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label29" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Berita"></asp:Label></td>
                <td style="width: 65%; ">
                    <asp:TextBox ID="TxtBerita" runat="server" text="" Width="100%" MaxLength="30" 
                        CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp01" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl01" runat="server" BackColor="Red" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" 
                        Width="99%"  /></td> 
            </tr>
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label23" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "100%" Text="Tgl Permohonan Admin Stok" Width="100px"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxtTglAdmin" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td> 
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF; height: 24px;">
                        <asp:TextBox ID="TxtUsrAdmin" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    </table></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp02" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="100%"  Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl02" runat="server" BackColor="Red" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" 
                        Width="99%"  /></td> 
            </tr>
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label26" runat="server" Font-Names="Arial" Font-Size="Small" height= "100%" Text="Nama Supir"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 90%; background-color: #000000;  color: #FFFFFF;">
                            <asp:DropDownList ID="DropDownList2" runat="server">
                            </asp:DropDownList>
                        <asp:Label ID="lblNmSupir" runat="server" Font-Names="Arial" Font-Size="Small" height= "100%" Text="Nama Supir"></asp:Label></td>
                    </tr>
                    </table></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp03" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl03" runat="server" BackColor="Red" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" 
                        Width="99%"  /></td> 
            </tr>
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label28" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Kirim Disetujui"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; ">
                        <asp:TextBox ID="TxttglKirimSetujui" runat="server" />
                        <asp:Button ID="BtnCall5" runat="server" Text=".." Width="27px" />
                        <div id="Div4">
                        <asp:Calendar ID="Calendar5" runat="server" onselectionchanged="Calendar5_SelectionChanged" />
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxtAlasanRubahTglKirim" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    </table>
                </td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp04" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl04" runat="server" BackColor="Red" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" 
                        Width="99%"  /></td> 
            </tr>
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label30" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl PDI"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; ">
                        <asp:TextBox ID="TxttglPDI" runat="server" />
                        <asp:Button ID="BtnCall6" runat="server" Text=".." Width="27px" />
                        <div id="Div5">
                        <asp:Calendar ID="Calendar6" runat="server" onselectionchanged="Calendar6_SelectionChanged" />
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxttglPDINote" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:Button ID="btnPrintPDIR" runat="server" Text="Ready Print PDI" />
                        <asp:Button ID="btnPrintPDI" runat="server" Text="Print PDI" 
                                OnClientClick = "return PrintPanel();" />
                        </td>
                    </tr>

                    </table></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp05" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl05" runat="server" BackColor="Red" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" 
                        Width="99%"  /></td> 
            </tr>
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label31" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Keluar"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%;">
                        <asp:TextBox ID="TxttglKeluar" runat="server" />
                        <asp:Button ID="BtnCall7" runat="server" Text=".." Width="27px" />
                        <div id="Div6">
                        <asp:Calendar ID="Calendar7" runat="server" onselectionchanged="Calendar7_SelectionChanged" />
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxttglKeluarNote" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:Button ID="btnPrintSPJR" runat="server" Text="Ready Print SPJ" />
                        <asp:Button ID="btnPrintSPJ" runat="server" Text="Print SPJ" 
                                OnClientClick = "return PrintPanel();" />
                        </td>
                    </tr>
                    </table>
                </td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp06" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl06" runat="server" BackColor="Red" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" 
                        Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label32" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Periksa Security"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; ">
                        <asp:TextBox ID="TxtTglSecurity" runat="server" />
                        <asp:Button ID="BtnCall8" runat="server" Text=".." Width="27px" />
                        <div id="Div7">
                        <asp:Calendar ID="Calendar8" runat="server" onselectionchanged="Calendar8_SelectionChanged" />
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxtTglSecurityNote" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    </table>
                </td>                 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp07" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl07" runat="server" BackColor="Red" Font-Overline="False" 
                        Font-Size="Small" Height="100%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label33" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Batal Kirim"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; "> 
                        <asp:TextBox ID="TxtTglBatal" runat="server" />
                        <asp:Button ID="BtnCall9" runat="server" Text=".." Width="27px" />
                        <div id="Div8">
                        <asp:Calendar ID="Calendar9" runat="server" onselectionchanged="Calendar9_SelectionChanged" />
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxtTglBatalNote" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    </table> </td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp08" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" 
                        Width="100%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl08" runat="server" BackColor="Red" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" 
                        Width="100%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label34" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Terima"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; ">
                        <asp:TextBox ID="TxttglTerima" runat="server" />
                        <asp:Button ID="BtnCall10" runat="server" Text=".." Width="27px" />
                        <div id="Div9">
                        <asp:Calendar ID="Calendar10" runat="server" onselectionchanged="Calendar10_SelectionChanged" />
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxttglTerimaNote" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    </table> </td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp09" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl09" runat="server" BackColor="Red" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" 
                        Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label35" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Catatan"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;"> 
                        <asp:TextBox ID="TxttglCatatan" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxttglCatatanDsc" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    </table> </td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp10" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl10" runat="server" BackColor="Red" 
                        Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" 
                        Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">            
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label36" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Voucher BBM"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;"> 
                        <asp:Label ID="LblBBMVcr" runat="server" Font-Names="Arial" Font-Size="Small" 
                                height= "21px" Text="Tgl Voucher BBM"></asp:Label>
                            <asp:Label ID="LblBBMNilai" runat="server" Font-Names="Arial" Font-Size="Small" 
                                height="21px" Text="Tgl Voucher BBM"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                            <asp:Label ID="LblBBMAlasan" runat="server" Font-Names="Arial" 
                                Font-Size="Small" height="21px" Text="Tgl Voucher BBM"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:Button ID="BtnPrintBBMR" runat="server" Text="Ready Print BBM" />
                        <asp:Button ID="BtnPrintBBM" runat="server" Text="Print BBM" 
                                OnClientClick = "return PrintPanel();" />
                        </td>
                    </tr>
                    </table> </td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp11" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" 
                        Width="100%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl11" runat="server" BackColor="Red" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" 
                        Width="100%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label37" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "100%" Text="Tgl Aproval Cetak DO" Width="100%"></asp:Label></td>
                <td style="width: 65%; ">
                    <asp:TextBox ID="TxttglCetakDO" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp12" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" Width="100%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl12" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="100%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label38" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Kirim Mugen"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%;"> 
                        <asp:TextBox ID="TxtTglKirimMgn" runat="server" />
                        <asp:Button ID="BtnCall11" runat="server" Text=".." Width="27px" />
                        <div id="Div10">
                        <asp:Calendar ID="Calendar11" runat="server" onselectionchanged="Calendar11_SelectionChanged" />
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxtNotKirimMgn" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:Button ID="BtnPrintBBMDR" runat="server" Text="Ready Print BBM Dealer" />
                        <asp:Button ID="BtnPrintBBMD" runat="server" Text="Print BBM Dealer" 
                                OnClientClick = "return PrintPanel();" />
                        </td>
                    </tr>

                    </table>
                </td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp13" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" Width="100%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl13" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="100%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label39" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Buku Service"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%;">
                        <asp:TextBox ID="TxtTglBukuSvc" runat="server" />
                        <asp:Button ID="BtnCall12" runat="server" Text=".." Width="27px" />
                        <div id="Div11">
                        <asp:Calendar ID="Calendar12" runat="server" onselectionchanged="Calendar12_SelectionChanged" />
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxtBukuSvc" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    </table> </td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp14" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl14" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label40" runat="server" Font-Names="Arial" Font-Size="Small" height= "100%" width= "100%" Text="Tgl Vcr BBM CROSS-SELL"></asp:Label></td>
                <td style="width: 65%; ">
                     <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:Label ID="LblBBMCSVcr" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tgl Voucher BBM"></asp:Label>
                            <asp:Label ID="LblBBMCSNil" runat="server" Font-Names="Arial" Font-Size="Small" 
                                height="21px" Text="Tgl Voucher BBM"></asp:Label>
                        </td> 
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                            <asp:Label ID="LblBBMCSAlasan" runat="server" Font-Names="Arial" 
                                Font-Size="Small" height="21px" Text="Tgl Voucher BBM"></asp:Label>
                        </td>
                    </tr>
                    </table> </td>                    
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp15" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="100%" Text="Simpan" Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl15" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="100%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label41" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI No SPK"></asp:Label></td>
                <td style="width: 65%; ">
                    <asp:TextBox ID="TxtPDISPK" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp16" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl16" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label42" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI Transmisi"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxtPDITransmisiNote" runat="server" text="" Width="100%" 
                                MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    </table> </td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp17" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl17" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label43" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI Nama Supir"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;"> 
                        <asp:TextBox ID="TxtPDISupirTgl" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxtPDISupirNot" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    </table> </td>                     
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp18" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl18" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="9%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label45" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI Plat MJS [Y]a [T]idak"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxtPDIPlatMJSNot" runat="server" text="" Width="100%" 
                                MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    </table> </td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp19" runat="server" BackColor="#80FF00" Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl19" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label46" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI Keterangan"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 65%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;"> 
                        <asp:TextBox ID="TxtPDIKetTgl" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxtPDIKetera" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    </table> </td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp20" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl20" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label47" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI Gesekan Lakban"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; ">
                        <asp:TextBox ID="TxtPDILakbanTgl" runat="server" />
                        <asp:Button ID="BtnCall13" runat="server" Text=".." Width="27px" />
                        <div id="Div12">
                        <asp:Calendar ID="Calendar13" runat="server" onselectionchanged="Calendar13_SelectionChanged" />
                        </div>
                        </td>

                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxtPDILakbanNot" runat="server" text="" Width="100%" 
                                MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    </table> </td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp21" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl21" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label48" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="PDI Gesekan Polda"></asp:Label></td>
                <td style="width: 65%; ">
                    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; ">
                        <asp:TextBox ID="TxtPDIPoldaTgl" runat="server" />
                        <asp:Button ID="BtnCall14" runat="server" Text=".." Width="27px" />
                        <div id="Div13">
                        <asp:Calendar ID="Calendar14" runat="server" onselectionchanged="Calendar14_SelectionChanged" />
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        <asp:TextBox ID="TxtPDIPoldaNot" runat="server" text="" Width="100%" MaxLength="30" 
                                CssClass="uppercase"></asp:TextBox></td>
                    </tr>
                    </table>
                </td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp22" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl22" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label49" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="No STCK"></asp:Label></td>
                <td style="width: 65%; ">
                    <asp:TextBox ID="TxtNoSTCK" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
                <td style="width: 10%; ">
                    <asp:Button ID="BtnSmp23" runat="server" BackColor="#80FF00" 
                        Font-Overline="False" Font-Size="Small" Height="99%" Text="Simpan" 
                        Width="99%" /></td> 
                <td style="width: 10%; ">
                    <asp:Button ID="BtnBtl23" runat="server" BackColor="Red" Font-Overline="False" Font-Size="Small" Height="99%" Text="Batal" Width="99%"  /></td> 
            </tr>
            </table> 

        
        </asp:View>
        <asp:View ID="View03StokC" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label54" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="No SPK/No DO"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="lblNoDO" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label>
                    <asp:Label ID="lblnospk" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
                <td style="width: 15%; ">
                    <asp:Label ID="Dealer" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="No HP"></asp:Label></td>
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
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label53" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Data SPK"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="LblIdSPK" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="STNK"></asp:Label></td>
                <td style="width: 15%; ">
                    <asp:Label ID="Label58" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Data STNK"></asp:Label></td>
                <td style="width: 35%; ">
                    <asp:Label ID="LblIdSTNK" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama"></asp:Label></td>
            </tr>
            </table> 
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
                        <asp:ListItem>Service dan Bodyrepair
                        </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label71" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Pekerjaan"></asp:Label></td>
                <td style="width: 70%; ">
                    <asp:TextBox ID="TxtRepairRemark" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 30%; ">
                    <asp:Label ID="Label73" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggaungan Biaya"></asp:Label></td>
                <td style="width: 70%; ">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                        <asp:ListItem>Beban Kantor</asp:ListItem>
                        <asp:ListItem>Bukan BebanKantor</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; ">
                    <asp:Label ID="Label85" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Keterangan WO"></asp:Label></td>
                <td style="width: 70%; ">
                    <asp:TextBox ID="TxtKetWO" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
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

            </table> 
        </asp:View>
        <asp:View ID="View03StokD" runat="server">
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
        </asp:View>
        
        </asp:MultiView> 

        </asp:View> 
    </asp:MultiView>


    <div id="PrintBBM" style="display:none"  >
     <asp:Panel id="pnlContents" runat = "server"    >
        <asp:MultiView ID="MultiViewCetak" runat="server" Visible="TRUE">
        <asp:View ID="ViewCetakBBM" runat="server">
            <center> <asp:Label ID="lblCetakBBMCompany" runat="server"   Text="PT. MITRAUSAHA GENTANIAGA" Width="100%"></asp:Label> </center>
            <br />
            <center> <asp:Label ID="lblCetakBBMCompany1" runat="server"  
            Text="HONDA MUGEN PASAR MINGGU" Width="100%"></asp:Label> </center>
            <br />
            <center> <asp:Label ID="lblCetakBBMCompany2" runat="server"  
            Text="VOUCHER BAHAN BAKAR" Width="100%"></asp:Label> </center>
            
            <hr />
            <br />
            <br />
            <br />
            <asp:Label ID="lblCetakBBMIsiColA1" runat="server"  Text="NO VOUCHER"        Width="15%"></asp:Label>
            <asp:Label ID="lblCetakBBMIsiColA2" runat="server"  Text="99999"             Width="35%"></asp:Label>
            <asp:Label ID="lblCetakBBMIsiColA3" runat="server"  Text="TANGGAL"           Width="15%"></asp:Label>
            <asp:Label ID="lblCetakBBMIsiColA4" runat="server"  Text="99/99/9999"        Width="35%"></asp:Label>
            <br />
            <asp:Label ID="lblCetakBBMIsiColB1" runat="server"  Text="NO RANGKA"         Width="15%"></asp:Label>
            <asp:Label ID="lblCetakBBMIsiColB2" runat="server"  Text="99999"             Width="35%"></asp:Label>
            <asp:Label ID="lblCetakBBMIsiColB3" runat="server"  Text=""                  Width="15%"></asp:Label>
            <asp:Label ID="lblCetakBBMIsiColB4" runat="server"  Text=""                  Width="35%"></asp:Label>
            <br />
            <asp:Label ID="lblCetakBBMIsiColC1" runat="server"  Text="TYPE"              Width="15%"></asp:Label>
            <asp:Label ID="lblCetakBBMIsiColC2" runat="server"  Text="99999"             Width="35%"></asp:Label>
            <asp:Label ID="lblCetakBBMIsiColC3" runat="server"  Text="TANGGAL DIGUNAKAN" Width="15%"></asp:Label>
            <asp:Label ID="lblCetakBBMIsiColC4" runat="server"  Text="99/99/9999"        Width="35%"></asp:Label>
            <br />
            <asp:Label ID="lblCetakBBMIsiColD1" runat="server"  Text="WARNA"            Width="15%"></asp:Label>
            <asp:Label ID="lblCetakBBMIsiColD2" runat="server"  Text="99999"            Width="35%"></asp:Label>
            <asp:Label ID="lblCetakBBMIsiColD3" runat="server"  Text="TIPE PENGIRIMAN"  Width="15%"></asp:Label>
            <asp:Label ID="lblCetakBBMIsiColD4" runat="server"  Text="99/99/9999"       Width="35%"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblCetakBBMIsiColE1" runat="server"  Text="Rp. 10.000.000"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server"  Text="Syarat dan ketentuan"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server"  Text="- Hanya berlaku untuk Honda Mugen"></asp:Label>
            <br />
            <asp:Label ID="Label9" runat="server"  Text="- Tdak dapat diuangkan"></asp:Label>
            <br />
            <asp:Label ID="Label14" runat="server"  Text="- Tidak bisa dipindah tangankan (Digunakan sesuai data tercantum)"></asp:Label>
            <br />
            <asp:Label ID="Label16" runat="server"  Text="- Asli (Tidak berlaku jika di fotocopy)"></asp:Label>
            <br />
            <asp:Label ID="Label65" runat="server"  Text="- Tidak berlaku jika tidak terpotong"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="lblCetakBBMIsiColf1" runat="server"  Text="Jakarta" Width="100%"></asp:Label>
            <br />
            <asp:Label ID="Label74" runat="server"  Text="Supir"    Width="30%"></asp:Label>
            <asp:Label ID="Label80" runat="server"  Text="Petugas"  Width="30%"></asp:Label>
            <asp:Label ID="Label81" runat="server"  Text="Warehouse"    Width="40%"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label76" runat="server"  Text="Tanggal"  Width="30%"></asp:Label>
            <asp:Label ID="Label82" runat="server"  Text="Tanggal"  Width="30%"></asp:Label>
            <asp:Label ID="Label83" runat="server"  Text="Tanggal"  Width="40%"></asp:Label>
            <br />
            <asp:Label ID="Label78" runat="server"  Text="Lembaran Kuning untuk warehouse, putih utk SPBU, Merah untuk Admin stok"></asp:Label>

            <br />
            <br />
        </asp:View> 
        <asp:View ID="ViewCetakSPJ" runat="server">
            <center> <asp:Label ID="Label86" runat="server"   Text="PT. MITRAUSAHA GENTANIAGA" Width="100%"></asp:Label> </center>
            <br />
            <center> <asp:Label ID="Label87" runat="server"  
            Text="HONDA MUGEN PASAR MINGGU" Width="100%"></asp:Label> </center>
            <br />
            <center> <asp:Label ID="Label88" runat="server"  
            Text="VOUCHER BAHAN BAKAR" Width="100%"></asp:Label> </center>
            
            <hr />
            <br />
            <br />
            <br />
            <asp:Label ID="Label89" runat="server"  Text="No SPK"        Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ1NOSPK" runat="server"  Text="99999"             Width="35%"></asp:Label>
            <asp:Label ID="Label91" runat="server"  Text="No DO"           Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ1NODO" runat="server"  Text="99/99/9999"        Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label94" runat="server"  Text="No Rangka"         Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ2RGK" runat="server"  Text="99999"             Width="35%"></asp:Label>
            <asp:Label ID="Label95" runat="server"  Text="Nama Sales"                  Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ2SALES" runat="server"  Text=""                  Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label97" runat="server"  Text="Type"              Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ3TIPE" runat="server"  Text="99999"             Width="35%"></asp:Label>
            <asp:Label ID="Label99" runat="server"  Text="Tanggal Mohon" Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ3TGLM" runat="server"  Text="99/99/9999"        Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label101" runat="server"  Text="Warna"            Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ4WARNA" runat="server"  Text="99999"            Width="35%"></asp:Label>
            <asp:Label ID="Label103" runat="server"  Text="Tanggal Kirim"  Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ4TGLK" runat="server"  Text="99/99/9999"       Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label222" runat="server"  Text=""        Width="15%"></asp:Label>
            <asp:Label ID="Label223" runat="server"  Text="Lokasi Pengiriman"             Width="35%"></asp:Label>
            <asp:Label ID="Label224" runat="server"  Text=""           Width="15%"></asp:Label>
            <asp:Label ID="Label225" runat="server"  Text="Alternatif Lokasi Pengiriman"        Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label226" runat="server"  Text="Nama"         Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ5NAMA1" runat="server"  Text=""             Width="35%"></asp:Label>
            <asp:Label ID="Label228" runat="server"  Text="Nama"                  Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ5NAMA2" runat="server"  Text=""                  Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label230" runat="server"  Text="Alamat"              Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ6ALAMAT11" runat="server"  Text="99999"             Width="35%"></asp:Label>
            <asp:Label ID="Label232" runat="server"  Text="Alamat" Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ6ALAMAT12" runat="server"  Text="99/99/9999"        Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label234" runat="server"  Text="Alamat1"            Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ7ALAMAT21" runat="server"  Text="99999"            Width="35%"></asp:Label>
            <asp:Label ID="Label236" runat="server"  Text="Alamat1"  Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ7ALAMAT22" runat="server"  Text="99/99/9999"       Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label238" runat="server"  Text="Kota"              Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ7KOTA1" runat="server"  Text="99999"             Width="35%"></asp:Label>
            <asp:Label ID="Label240" runat="server"  Text="Kota" Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ7KOTA2" runat="server"  Text="99/99/9999"        Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label242" runat="server"  Text="Tlp/Hp"            Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ8PHONE1" runat="server"  Text="99999"            Width="35%"></asp:Label>
            <asp:Label ID="Label2441" runat="server"  Text="Tlp/HP"  Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ8PHONE2" runat="server"  Text="99/99/9999"       Width="35%"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label105" runat="server"  Text="Biaya Transport"></asp:Label>
            <asp:Label ID="LblSPJ9BIAYA" runat="server"  Text="Biaya Transport"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label106" runat="server"  Text="Tanggal & Jam Keluar"            Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ10TGLJAMK" runat="server"  Text="99999"            Width="35%"></asp:Label>
            <asp:Label ID="Label244" runat="server"  Text="Paraf Security"  Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ10PARAFS" runat="server"  Text="99/99/9999"       Width="35%"></asp:Label>
            <br />
            <asp:Label ID="Label108" runat="server"  Text="Tanggal & Jam Diterima"  Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ11TGLJAMT" runat="server"  Text="99/99/9999"       Width="35%"></asp:Label>
            <asp:Label ID="Label244b" runat="server"  Text="Paraf Pelanggan"  Width="15%"></asp:Label>
            <asp:Label ID="LblSPJ11PARAFP" runat="server"  Text="99/99/9999"       Width="35%"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="LblSPJ12TGLSURAT" runat="server"  Text="Jakarta" Width="100%"></asp:Label>
            <br />
            <asp:Label ID="Label113" runat="server"  Text="Supir"    Width="30%"></asp:Label>
            <asp:Label ID="Label114a" runat="server"  Text=""  Width="30%"></asp:Label>
            <asp:Label ID="Label115a" runat="server"  Text="Kordinator Warehouse"    Width="40%"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label116" runat="server"  Text="Tanggal"  Width="30%"></asp:Label>
            <asp:Label ID="Label117" runat="server"  Text=""  Width="30%"></asp:Label>
            <asp:Label ID="Label118" runat="server"  Text="Tanggal"  Width="40%"></asp:Label>
            <br />
            <br />
            <br />
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

        </asp:MultiView> 
    </asp:Panel>
    </div>

    
</asp:Content>
