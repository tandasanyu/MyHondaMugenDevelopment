<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"   AutoEventWireup="false" CodeFile="Form0103Jadwal.aspx.vb" Inherits="Form02Jadwal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p   style ="font-size:smaller" >
        <asp:Label ID="Label44"  Text ="Informasi Jadwal Kendaraan >> " runat="server"></asp:Label>
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
            <td>
               <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Pengiriman"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="txtDate" runat="server" />
                <asp:Button ID="Button1" runat="server" Text=".." Width="27px" />
                <div id="tanggalPopup">
                <asp:Calendar ID="cDate" runat="server" onselectionchanged="cDate_SelectionChanged" />
                </div>
            </td>
        </tr>
     </table>
<br />
        <asp:Button ID="btnfilter" runat="server" Text="Lakukan Pencarian Data" />
<br />
        <asp:SqlDataSource ID="sdsTabelJdw" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM TRXN_STOCKMKIRIM LEFT OUTER JOIN TRXN_STOCK ON TRXN_STOCKMKIRIM.STOCKM_NORANGKA = TRXN_STOCK.STOCK_NoRangka LEFT OUTER JOIN TRXN_STOCKKKIRIM ON TRXN_STOCK.STOCK_NoRangka = TRXN_STOCKKKIRIM.STOCKK_NORANGKA WHERE (TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM = ?)"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtDate" Name="STOCKM_TGLMOHONKIRIM" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
            
        </asp:SqlDataSource>                 


        <asp:MultiView ID="MultiView1a" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">

        <asp:ListView ID="lvBerita" runat="server" DataSourceID="sdsTabelJdw" DataKeyNames ="STOCKM_NORANGKA">
        <LayoutTemplate>
            <table border="2" width="100%"  style="border-collapse:collapse;">
                    <thead>
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
                    <td style="width:5%; font-size: smaller "><%#Eval("STOCKM_KDDEALER")%></td>
                    <td style="width:10%; font-size: smaller"><%#Eval("STOCKM_SALES")%></td>
                    <td style="width:10%; font-size: smaller"><%#Eval("STOCKM_NORANGKA")%></td>
                    <td style="width:10%; font-size: smaller"><%#Eval("STOCKM_TGLMOHONINPUT")%></td>
                    <td style="width:10%; font-size: smaller"><%#Eval("STOCKM_TGLMOHONKIRIM")%></td>
                    <td style="width:10%; font-size: smaller"><%#Eval("STOCKM_KIRIMTGLSETUJUI")%></td>
                    <td style="width:10%; font-size: smaller"><%#Eval("STOCKK_KIRIMTGLKIRIM")%></td>
                    <td style="width:10%; font-size: smaller"><%#Eval("STOCKK_KIRIMTGLTERIMA")%></td>
                    <td style="width:10%; font-size: smaller"><%#Eval("STOCKK_KIRIMKETTERIMA")%></td>
                </tr>
                </ItemTemplate>
        </asp:ListView>
            </asp:View>
        </asp:MultiView>

</asp:Content>

