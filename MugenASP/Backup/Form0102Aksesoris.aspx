<%@ Page Language="VB"  MasterPageFile ="~/MasterPage.master"  AutoEventWireup="false" CodeFile="Form0102Aksesoris.aspx.vb" Inherits="Form02Aksesoris" %>
<%@ MasterType virtualpath = "~/MasterPage.master"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    
    <div>
            <center>
                <h2 style="font-family:Cooper Black;">PERMOHONAN SALES</h2>
            </center>
	</div>  
	
    <div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div>
 


	
    <center>
    <p   style ="font-size: small" > 
        &nbsp;User&nbsp; : 
        <asp:Label ID="LblUserName" runat="server"></asp:Label>
        <asp:Label ID="lblAkses" runat="server"></asp:Label>
        &nbsp; Akses &nbsp; : 
        <asp:Label ID="lblArea1" runat="server"></asp:Label>
        <asp:Label ID="lblArea2" runat="server"></asp:Label>
        <asp:Label ID="LblTglSystem" runat="server"></asp:Label>
    </p>
    </center>

    <br />
    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
          
        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Error Message</asp:Label>
          
    </asp:View> 
    </asp:MultiView>

    <asp:MultiView ID="MultiView3" runat="server" Visible="TRUE">
    <asp:View ID="View16" runat="server">
    <table style="width: 100%; height:auto ; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 20%;height:auto ">
               <asp:Button ID="BtnOrderAss" runat="server" Text="Aksesoris"  
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Width="95%" Height="35px" />
            </td>
            <td style="width: 20%;height:auto ">
               <asp:Button ID="BtnRubahSPK" runat="server" Text="Perubahan Data SPK" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Width="95%" Height="35px" />
            </td>
            <td style="width: 20%;height:auto ">
               <asp:Button ID="BtnLihatAss" runat="server" Text="Aksesoris di Warehouse" 
                    BackColor="#808040" Font-Bold="True" ForeColor="White" Width="95%" Height="35px" />
            </td>
            <td style="width: 20%;height:auto ">
                &nbsp;</td>
            <td style="width: 20%;height:auto ">
               <asp:Button ID="BtnVirtualAccount" runat="server" Text="Virtual Account"  
                    BackColor="#808040" Font-Bold="True" ForeColor="White" Width="95%" 
                    Height="35px" />
                </td>
            
        </tr>
     </table>
        <table style="width: 100%; height:auto ; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 100%;height:auto ">
            <center>
               <asp:Button ID="Button2" runat="server" Text="Ijin Kehadiran"  
                    BackColor="#808040" Font-Bold="True" ForeColor="White" Width="100%" 
                    Height="25px" />
                    </center>
            </td>
        </tr>

        <tr>
            <td style="width: 100%;height:auto ">
            <center>
                    <asp:LinkButton ID="LinkButton2" PostBackUrl ="~/HRDPENILAIANATASANSALES.aspx" 
                        runat="server" BackColor="Red" Width="100%" ForeColor="Yellow" 
                        Height="25px">Penilaian Atasan</asp:LinkButton>
            </center>
            </td>
        </tr>

     </table>
 
    </asp:View> 
    </asp:MultiView>

<br />
<br />
     
    <asp:MultiView ID="MultiView1a" runat="server" Visible="TRUE">
        <asp:View ID="V0FormPasangAksesoris" runat="server">
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Monitor Pemasangan Aksesors</h2>
            </center>
	    </div>  

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 25%; ">
               <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Permohonan Nomor Rangka"></asp:Label>
            </td>
            <td style="width: 25%; ">
               <asp:TextBox ID="txtjudul" text="" runat="server" Width="90%" CssClass="uppercase"></asp:TextBox>
            </td>
            <td style="width: 50%; ">
               <asp:Button ID="btnfilter" runat="server" Text=" <---- Pencarian Pemasang Asesoris berdasarakan nomor rangka" 
                    Width="90%" BackColor="#0033CC" />
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
        <asp:View ID="V1FormVirtualAccount" runat="server">
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Pembuatan 
                    Virtual Account</h2>
            </center>
	    </div>  

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr> 
                <td style="width: 25%; Background-color:#CCCCFF;">
                   <asp:Label ID="Label44" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="Nomor SPK"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtVANoSPK" runat="server" text="" Width="10%" 
                        AutoPostBack="true" CssClass="uppercase" MaxLength="6"></asp:TextBox>
                    <asp:Button ID="Button13" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" Text="Cari Data SPK" />
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label48" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="Nama SPK"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtVANama" runat="server" text="" Width="78%" 
                        AutoPostBack="true" CssClass="uppercase" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; Background-color:#CCCCFF;">
                   <asp:Label ID="Label110" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="Jumlah Uang Muka"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtVAJumlah" runat="server" text="" Width="149px" 
                        MaxLength="17" ></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator2" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik tanpa koma atau titik" ControlToValidate="TxtVAJumlah" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label111" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="Email"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtVAEmail" runat="server" text="" Width="78%" 
                        AutoPostBack="true" CssClass="uppercase" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; Background-color:#CCCCFF;">
                   <asp:Label ID="Label112" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="Nomor Handphone"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtVANoHP" runat="server" text="" Width="50%" 
                        AutoPostBack="true" CssClass="uppercase" MaxLength="20"></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label113" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="Nomor Virtual Account"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="LblVANomor" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="No Acc"></asp:Label>
                    <asp:Label ID="LblVANomor0" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="99%" Text=" Jumlah Rp."></asp:Label>
                    <asp:Label ID="LblVANomor1" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="99%" Text="0"></asp:Label>
                </td>
            </tr>
            </table> 

            <br />            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small; margin-bottom: 36px;">
            <tr>
                <td style="width: 100%;">
                    <asp:Label ID="LblVAError" runat="server" Font-Names="Arial" 
                        Font-Size="Small" Font-Bold ="True" ForeColor="Red" height="53px" 
                        Text="?"></asp:Label>
                </td>
            </tr>
            </table>
            <br />            

    <asp:MultiView ID="MultiViewTabelVA" runat="server" Visible="TRUE">
            <asp:View ID="View112" runat="server">
            <asp:SqlDataSource ID="SqlDataSourceVA112" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet112 %>" 
            SelectCommand="SELECT [VIRTUAL_NO], [VIRTUAL_TGL], [VIRTUAL_ACCOUNT], [VIRTUAL_JUMLAH], [VIRTUAL_TGLPYMT], [VIRTUAL_HMSDOCTGL], [VIRTUAL_STATUS] FROM [TRXN_VIRTUALACC] WHERE ([VIRTUAL_NO] = ?) order by VIRTUAL_STATUS,VIRTUAL_TGL"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet112.ProviderName %>">
            <SelectParameters>
            <asp:ControlParameter ControlID="TxtVANoSPK" Name="VIRTUAL_NO" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>
            </asp:SqlDataSource>            
            <asp:ListView ID="ListViewVA112" runat="server" DataSourceID="SqlDataSourceVA112" DataKeyNames ="VIRTUAL_NO">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px">
                      <th>No SPK</th><th>Tanggal</th><th>VA</th><th>Jumlah</th><th>Status</th><th>Tgl Payment</th><th>Tgl DOC</th>
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
                    <td style="width:10%; font-size: x-small"><%#Eval("VIRTUAL_NO")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("VIRTUAL_TGL")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("VIRTUAL_ACCOUNT")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("VIRTUAL_JUMLAH")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("VIRTUAL_STATUS")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("VIRTUAL_TGLPYMT")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("VIRTUAL_HMSDOCTGL")%></td>
                </tr>
            </ItemTemplate>
            </asp:ListView>
            </asp:View>
            <asp:View ID="View128" runat="server">
            <asp:SqlDataSource ID="SqlDataSourceVA128" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet128 %>" 
            SelectCommand="SELECT [VIRTUAL_NO], [VIRTUAL_TGL], [VIRTUAL_ACCOUNT], [VIRTUAL_JUMLAH], [VIRTUAL_TGLPYMT], [VIRTUAL_HMSDOCTGL], [VIRTUAL_STATUS] FROM [TRXN_VIRTUALACC] WHERE ([VIRTUAL_NO] = ?) order by VIRTUAL_STATUS,VIRTUAL_TGL"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet128.ProviderName %>">
            <SelectParameters>
            <asp:ControlParameter ControlID="TxtVANoSPK" Name="VIRTUAL_NO" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>
            </asp:SqlDataSource>            
            <asp:ListView ID="ListViewVA128" runat="server" DataSourceID="SqlDataSourceVA128" DataKeyNames ="VIRTUAL_NO">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px">
                      <th>No SPK</th><th>Tanggal</th><th>VA</th><th>Jumlah</th><th>Status</th><th>Tgl Payment</th><th>Tgl DOC</th>
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
                    <td style="width:10%; font-size: x-small"><%#Eval("VIRTUAL_NO")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("VIRTUAL_TGL")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("VIRTUAL_ACCOUNT")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("VIRTUAL_JUMLAH")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("VIRTUAL_STATUS")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("VIRTUAL_TGLPYMT")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("VIRTUAL_HMSDOCTGL")%></td>
                </tr>
            </ItemTemplate>
            </asp:ListView>
            </asp:View>


    </asp:MultiView>

            <br />            
            <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; ">
                <asp:Button ID="BtnVASave" runat="server" Text="Buat Virtual Account" Width="250px" 
                    Height="34px" Font-Overline="False" Font-Size="Medium"  
                    BackColor="#004080" ForeColor="Yellow" Font-Bold="True"  />                       
                </td>
                <td style="width: 25%; ">
                <asp:Button ID="BtnVACheck" runat="server" BackColor="#004080" Font-Bold="True" 
                        Font-Overline="False" Font-Size="Medium" ForeColor="Yellow" Height="34px" 
                        Text="Periksa Virtual Account" Width="250px" />
                </td>
                <td style="width: 25%; ">
                <asp:Button ID="BtnVAEmail" runat="server" Text="Email Virtual Account" Width="250px" 
                    Font-Size="Medium"  Height="34px" BackColor="#FF9900" />    
                </td>
                <td style="width: 25%; ">
                <asp:Button ID="BtnVAClear" runat="server" Text="Selesai" Width="250px" 
                    Font-Size="Medium"  Height="34px" BackColor="#FF9900" />    
                </td>
            </tr>
            </table>
            <br />

        </asp:View>
        <asp:View ID="V2FormUpdateSPKdanAksesoris" runat="server">
            <asp:MultiView ID="MultiViewMhnMaster" runat="server" Visible="TRUE">
            <asp:View ID="ViewMaster" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr> 
                <td style="width: 25%; Background-color:#CCCCFF;">
                   <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="Nomor SPK"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="Txt_NoSPKMohon" runat="server" text="" Width="10%" AutoPostBack="true" CssClass="uppercase"></asp:TextBox>
                    <asp:Button ID="ButtonSPKrefresh" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Perbarui Tabel" />
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tipe permohonan"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="70%" AutoPostBack="true"  >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label36" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Alasan"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="txtalasanmohon" runat="server" text="" Width="652px" MaxLength="100" CssClass="uppercase"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; "></td>
                <td style="width: 75%; "></td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView>
            
            <asp:MultiView ID="MultiViewMhnDetail" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                   <asp:Label ID="lblDealer" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Nomor SPK"></asp:Label>
                   <asp:Label ID="Label117" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="-"></asp:Label>
                   <asp:Label ID="lblMohonDetailSPK" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            </table>  
            <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Data SPK</h2>
            </center>
	        </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label23" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Nama SPK" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:Label ID="LblNama" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                    height= "21px" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF ; ">
                    <asp:Label ID="Label24" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama Sales" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblSales" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ></asp:Label>
                    <asp:Label ID="LblSalesSPV" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px"></asp:Label>
                    <asp:Label ID="LblSalesSPV0" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </td>
            </tr>
            </table>
            <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Detail Kendaraan</h2>
            </center>
	        </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label25" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tipe" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblCdType" runat="server" Text=""></asp:Label>
                    <asp:Label ID="LblCdTypeNamaDetail" runat="server" Text="" ForeColor="Black"></asp:Label>
                    <asp:Label ID="lblGroupTipeNamaDetail" runat="server" ForeColor="Black" Text=""></asp:Label>
                </td>
                <td style="width: 25%; ">
                   <asp:Label ID="Label28" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Warna"  ForeColor="Black" BorderColor="#FF9966"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblWarnaNamaDetail" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label30" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Rangka" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="lblNorangka" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label31" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tahun/Road[N] Offroad[F]" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="lblTahun" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblRoad" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
            <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Detail Harga</h2>
            </center>
	        </div>
	          
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label32" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga" ForeColor="Black"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblHarga" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%;background-color:Yellow;  color: #FFFFFF;">
                    <asp:Label ID="Label119" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga Paket Cermat" ForeColor="Black"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblPaketCermat" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                </td>
                <td style="width: 25%; ">
                </td>
                <td style="width: 25%;background-color:Yellow;  color: #FFFFFF;">
                    <asp:Label ID="Label122" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Selisih Harga Beda Tahun" ForeColor="Black"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblBedaThn" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
            <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label33" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Potongan" ForeColor="Black"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblDisc" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF ;">
            </td>
            <td style="width: 25%; background-color:#CCCCFF ;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label71" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Subsidi" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblSubsidi" runat="server" Text="" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                </td>
                <td style="width: 25%; ">
                </td>
            </tr>
            <tr>
            <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label76" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Komisi" ForeColor="Black"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblKomisi" runat="server" Text="" ForeColor="Black"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF ;">               
            </td>
            <td style="width: 25%; background-color: silver">
                &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                <asp:Label ID="Label39" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total" ForeColor="Black"></asp:Label>     
                </td>
                <td style="width: 25%; ">
                <asp:Label ID="LblTotal" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; ">
                </td>
                <td style="width: 25%; ">
                </td>
            </tr>
        </table>
            <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Detail Cara Bayar</h2>
            </center>
	        </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label40" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jenis Pembayaran" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="LblJns" runat="server" Text=""></asp:Label>
                    <asp:Label ID="LblJns0" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label41" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tenor" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="lblTnr" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
            <td style="width: 25%; ">
               <asp:Label ID="Label43" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total Bayar"></asp:Label>
            </td>
            <td style="width: 25%; ">
                <asp:Label ID="LblBayar" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 25%; ">
               <asp:Label ID="Label50" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Keharusan Uang Muka (Berdasarkan PO leasing)"></asp:Label>
            </td>
            <td style="width: 25%; ">
                <asp:Label ID="LblBayarUM" runat="server" Text=""></asp:Label>
            </td>
            </tr>
            </table>
            <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Detail Permohonan</h2>
            </center>
	        </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; background-color:#CCCCFF ;">
                   <asp:Label ID="Label16" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal Mohon"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                   <asp:Label ID="lblMohonDetailTgl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label18" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Kode Mohon"></asp:Label>
                </td>
                <td style="width: 75%;">
                   <asp:Label ID="LblNomormohon" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;background-color:#CCCCFF;">
                    <asp:Label ID="Label46" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Mohon"></asp:Label>
                </td>
                <td style="width: 75%;background-color:#CCCCFF;">
                   <asp:Label ID="LblNomor" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            
             <tr>
                <td style="width: 25%;">
                    <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Judul permohonan"></asp:Label>
                </td>
                <td style="width: 75%;">
                   <asp:Label ID="lblMohonDetailTipe" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="width: 25%;background-color:#CCCCFF;">
                    <asp:Label ID="Label14" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Alasan"></asp:Label>
                </td>
                <td style="width: 75%;background-color:#CCCCFF;">
                   <asp:Label ID="lblMohonDetailAlasan" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    <asp:Label ID="lblMohonDetailJudul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Proses Persetujuan"></asp:Label>
                </td>
                <td style="width: 75%;">
                   <asp:Label ID="lblMohonDetailProsesPersetujuan" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;background-color:#CCCCFF;">
                    <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Posisi Persetujuan Terakhir"></asp:Label>
                </td>
                <td style="width: 75%;background-color:#CCCCFF;">
                   <asp:Label ID="lblMohonDetailProsesPersetujuanAkhir" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    <asp:Label ID="Label109" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Status terakhir"></asp:Label>
                </td>
                <td style="width: 75%;">
                   <asp:Label ID="LblStatusAkhir" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            </table> 

            <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Perubahan yang dikehendaki</h2>
            </center>
	        </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 25%;background-color:#CCCCFF;">
                    <asp:Label ID="lblMohonDetailJudul1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nilai perubahan"></asp:Label>
                </td>
                <td style="width: 75%;background-color:#CCCCFF;">
                   <asp:Label ID="lblMohonDetailNilai1" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    <asp:Label ID="lblMohonDetailJudul2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nilai perubahan"></asp:Label>
                </td>
                <td style="width: 75%; ">
                   <asp:Label ID="lblMohonDetailNilai2" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    <asp:Label ID="lblMohonDetailJudul3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nilai perubahan"></asp:Label>
                </td>
                <td style="width: 75%; ">
                   <asp:Label ID="lblMohonDetailNilai3" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="lblMohonDetailJudul4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nilai perubahan"></asp:Label>
                </td>
                <td style="width: 75%; ">
                   <asp:Label ID="lblMohonDetailNilai4" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label20" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Update Data SPK"></asp:Label>
                </td>
                <td style="width: 75%; ">
                   <asp:Label ID="LblUpdateDataSPK" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            </table> 
            <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Data Pindah Dana</h2>
            </center>
	        </div>  

            <asp:ListView ID="LvTabelPindahDana" runat="server">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%" style="border-collapse:collapse;">
            <thead  style="background-color:Silver">
            <th>Tipe</th><th>No SPK</th><th>Keterangan</th><th>Nilai</th>
            </thead>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PindahDanaTipe"  runat="server" Text='<%#Eval("Temp_PindahDanaTipe")%>'/></td>
                <td style="width:10%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PindahDanaSpk"   runat="server" Text='<%#Eval("Temp_PindahDanaSpk")%>'/></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PindahDanaNama"  runat="server" Text='<%#Eval("Temp_PindahDanaNama")%>'/></td>
                <td style="width:50%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PindahDanaNilai" runat="server" Text='<%#Eval("Temp_PindahDanaNilai")%>' /></td>
                </tr>
            </ItemTemplate>
            </asp:ListView>        



            <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">History Persetujuan</h2>
            </center>
	        </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label45" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Proses SPV"></asp:Label>
                </td>
                <td style="width: 75%; ">
                   <asp:Label ID="LblAskSPV" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label47" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Proses Sales Manager"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF;">
                   <asp:Label ID="LblAskSM" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label49" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Proses Operasional Sales Manager"></asp:Label>
                </td>
                <td style="width: 75%; ">
                   <asp:Label ID="LblAskOSM" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label51" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Proses Direktur"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF;">
                   <asp:Label ID="LblAskDIR" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>

        </table>
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small">
            <tr>
                <td style="width: 100%; ">
                <asp:Button ID="Button6" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Medium"  
                    Font-Underline="True" ForeColor="Red" Text="Klik disini untuk Update Data SPK yang hanya judul di depanya Entry" 
                    Width="99%" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; ">
                <asp:Label ID="LblStatusUpdateSPK" runat="server" Font-Names="Arial" 
                    Font-Size="Small" height="21px" Text="Status Update SPK" Font-Bold="True" 
                    Font-Strikeout="False" Width="99%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; ">
                <asp:Button ID="Button7" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Medium" 
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menghapus validasi error &quot;ADA PERMOHONAN RUBAH DATA DI HMS SDH DISETUJUI TAPI BLM DIRUBAH&quot;" 
                    Width="99%" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; ">
                    <asp:Label ID="Label5" runat="server" font-Names="Arial" 
                        Font-Size="Small" Font-Bold="True"                          
                        Text="Perhatian !!!! Sebelum melakukan penghapusan 'ADA PERMOHONAN RUBAH DATA DI HMS SDH DISETUJUI TAPI BLM DIRUBAH' periksa terlebih dahulu di sistem mugen perubahan data-data yang diinginkan sales sudah berubah sesuai dengan yang dimaksud, ini PENTING !!! karena jika sudah DO maka perubahan perubahan data SPK tidak diijinkan ......" 
                        ForeColor="Blue" BorderStyle="Dotted" Width="99%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; ">
                    <asp:Button ID="ButtonSimpan2" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Tutup Form Detail" Width="99%" />
                </td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView>

            <asp:MultiView ID="MultiViewAdmin" runat="server" Visible="TRUE">
            <asp:View ID ="TombolAdmin" runat ="server">

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;"> 
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                    <asp:CheckBox ID="CheckBoxUpdateSPK" runat="server" Text ="" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                    <asp:CheckBox ID="CheckBoxUpdateSPK1" runat="server" Text ="" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                    <asp:CheckBox ID="CheckBoxUpdateSPK2" runat="server" Text ="" />
                </td>
            </tr>

            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="ButtonAdmin" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Medium" 
                    Font-Underline="True" ForeColor="blue" 
                    Text="Admin Akan membuka Status open untuk proses HMS" 
                    Width="99%" />
                </td>
            </tr> 
            </table>
            </asp:View>
            </asp:MultiView>

            <asp:MultiView ID="MultiViewMhnInpDO" runat="server" Visible="TRUE">
            <asp:View ID="ViewMohonDO" runat="server">
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label88" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="No Rangka"></asp:Label>
                    &nbsp;</td>
                <td style="width: 50%; ">
                    <asp:TextBox ID="TxtChangeNorangka" runat="server" text="" Width="235px"  CssClass="uppercase"></asp:TextBox>
                    <asp:Label ID="Label90" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" 
                        Text=" " ForeColor="Red"></asp:Label>
                    <asp:Button ID="ButtonSimpan1" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Cari Rangka (Isi % Semua tampil)" Width="225px" />
                </td>
                <td style="width: 25%; color: #FF0000;" >
                    &lt;---Isi Nomor Rangka yand ada pada stok</td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label53" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Apakah Customer Ambil Asuransi"></asp:Label>
                    &nbsp;</td>
                <td style="width: 50%; ">
                    <asp:RadioButton ID="RadioBtnAsrNo" Text="Tidak" runat="server" />
                    <asp:RadioButton ID="RadioBtnAsrYs" Text="Ya, Jika ya isi berapa nilai Asuransi Rp. " runat="server" />
                    <asp:TextBox ID="TxtDOAsr" runat="server" text="" Width="145px"  
                        CssClass="uppercase"></asp:TextBox>
                </td>
                <td style="width: 25%; color: #FF0000;" >
                </td>
            </tr>

            </table> 
            
            <asp:SqlDataSource ID="SdsDataStockDetail" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM DATA_TYPESTOCK,DATA_TYPE,DATA_WARNA WHERE 
                          TYPESTOCK_CDTYPE=TYPE_TYPE AND TYPESTOCK_CDWARNA=WARNA_KODE AND 
                          (TYPESTOCK_UPDATE IS NULL OR TYPESTOCK_UPDATE='' OR TYPESTOCK_UPDATE='C') AND 
                          [TYPESTOCK_CDDEALER] LIKE '%' + ? + '%' AND [TYPESTOCK_NORANGKA] LIKE '%' + ? + '%' ORDER BY TYPESTOCK_CDDEALER,TYPE_CdGroup,TYPE_TYPE,WARNA_KODE"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblArea1" Name="TYPESTOCK_CDDEALER" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TxtChangeNorangka" Name="TYPESTOCK_NORANGKA" PropertyName="Text" Type="String" />
            </SelectParameters>
            </asp:SqlDataSource>                 
            <asp:ListView ID="LvUnitStok" runat="server" DataKeyNames="TYPESTOCK_NORANGKA" DataSourceID="SdsDataStockDetail">
                <LayoutTemplate>
                    <table border="2" style="border-collapse:collapse;" width="100%">
                        <thead  style="background-color:Silver; height:30px">
                        <th>Rangka</th><th>Dealer</th><th>Group</th><th>Kode</th><th>Nama</th><th>Warna</th><th>Tanggal</th><th>Terima Stk</th>
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
                    <td style="width:12%; font-size:small">
                       <asp:LinkButton ID="LinkButton1" Text='<%# Eval("TYPESTOCK_NORANGKA") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:5%; font-size: small"><%#Eval("TYPESTOCK_CDDEALER")%></td>
                    <td style="width:5%; font-size: small"><%#Eval("TYPE_CDGROUP")%></td>
                    <td style="width:9%; font-size: small"><%#Eval("TYPE_TYPE")%></td>
                    <td style="width:20%; font-size: small"><%#Eval("TYPE_NAMA")%></td>
                    <td style="width:20%; font-size: small"><%#Eval("WARNA_int")%></td>
                    <td style="width:14%; font-size: small"><%#Eval("TYPESTOCK_TGL")%></td>
                    <td style="width:14%; font-size: small"><%#Eval("TYPESTOCK_TGLTERIMA")%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            
            </asp:View> 
            </asp:MultiView>
            
            <asp:MultiView ID="MultiViewMhnInpFaktur" runat="server" Visible="TRUE">
            <asp:View ID="ViewMohonFaktur" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label104" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Dokument Yg Dilampirkan"></asp:Label></td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:CheckBox ID="CheckFktLamp1" runat="server" Font-Size="Small" Text="Form STNK  " />
                    <asp:CheckBox ID="CheckFktLamp2" runat="server" Font-Size="Small" Text="FotoCoptKTP  " />
                    <asp:CheckBox ID="CheckFktLamp3" runat="server" Font-Size="Small" Text="Surat Kuasa Perusahaan  " />
                    <asp:CheckBox ID="CheckFktLamp4" runat="server" Font-Size="Small" Text="Siup NPWP  " />
                    <asp:CheckBox ID="CheckFktLamp5" runat="server" Font-Size="Small" Text="Kontrak  " />
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label92" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Nama"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtFakturNama" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label102" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > No KTP"></asp:Label></td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtFakturNoKTP" runat="server" text="" Width="100%" MaxLength="20"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label93" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Alamat"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtFakturAlamat" runat="server" text="" Width="100%" 
                        Height="73px" MaxLength="80"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label94" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Kota"></asp:Label></td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtFakturKota" runat="server" text="" Width="100%" 
                        MaxLength="20"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label96" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Kode Pos"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtFakturPos" runat="server" text="" Width="100%" 
                        MaxLength="5"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label98" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > No Handphone"></asp:Label></td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtFakturNoHP" runat="server" text="" Width="100%" 
                        MaxLength="20"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label101" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Tanggal Lahir"></asp:Label></td>
                <td style="width: 75%; ">
                <asp:TextBox ID="TxtTglLahir" runat="server" Width="22%"  height= "21px" />
                <asp:Button ID="BtnCalenderLahir" runat="server" Text=".." Width="3%" height= "21px" />
                <div id="Div10">
                <asp:Calendar ID="CalenderLahir" runat="server"  SelectedDate="<%# DateTime.Now %>" onselectionchanged="CalenderLahir_SelectionChanged" Font-Size="Smaller" />
                </div>

                </td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label100" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Agama"></asp:Label></td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="true" 
                        Width="167px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label103" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Pilih Nomor Polisi"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtFakturNoPolisi" runat="server" text="" Width="100%" 
                        MaxLength="10"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label107" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Catatan"></asp:Label></td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtNOTE" runat="server" text="" Width="100%" 
                        MaxLength="50"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView>
            
            <asp:MultiView ID="MultiViewMhnInpHrgUnit" runat="server" Visible="TRUE">
            <asp:View ID="ViewMohonHrgUnit" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga Unit"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:TextBox ID="TxtChangeHargaUnit" runat="server" text="" Width="149px" ></asp:TextBox></td>
                    <asp:CompareValidator ID="ChkTxtChangeHargaUnit" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik tanpa koma atau titik" ControlToValidate="TxtChangeHargaUnit" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                <td style="width: 50%; color: #FF0000;" >
                    &lt;---Isi harga perubahannya dengan angka tanpa ada titik, koma atau abjad</td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewMhnInpHrgDisc" runat="server" Visible="TRUE">
            <asp:View ID="ViewMohonHrgDisc" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label79" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Alasan Diskon"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:CheckBox ID="ChkDiskonLuckDp" Text="Diskon Lucky Deep Showroom Event" runat="server" />
                </td>
                <td style="width: 50%; color: #FF0000;" >
                    &lt;---Jika dipilih maka alasan akan disisikan dengan alasan tersebut</td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga Potongan"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:TextBox ID="TxtChangeHargaDisc" runat="server" text="" Width="149px"></asp:TextBox>
                    <asp:CompareValidator ID="ChkTxtChangeHargaDisc" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik tanpa koma atau titik" ControlToValidate="TxtChangeHargaDisc" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 50%; color: #FF0000;" >
                    &lt;---Isi harga perubahannya dengan angka tanpa ada titik, koma atau abjad</td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewMhnInpHrgSubs" runat="server" Visible="TRUE">
            <asp:View ID="ViewMohonHrgSubs" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label37" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga Subsidi"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:TextBox ID="TxtChangeHargaSubs" runat="server" text="" Width="149px"></asp:TextBox>
                    <asp:CompareValidator ID="ChkTxtChangeHargaSubs" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik tanpa koma atau titik" ControlToValidate="TxtChangeHargaSubs" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 50%; color: #FF0000;" >
                    &lt;---Isi harga perubahannya dengan angka tanpa ada titik, koma atau abjad</td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView> 
                   
            <asp:MultiView ID="MultiViewMhnInpHrgKoms" runat="server" Visible="TRUE">
            <asp:View ID="ViewMohonHrgKoms" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label52" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga Komisi"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:TextBox ID="TxtChangeHargaKoms" runat="server" text="" Width="149px"></asp:TextBox>
                    <asp:CompareValidator ID="ChkTxtChangeHargaKoms" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik tanpa koma atau titik" ControlToValidate="TxtChangeHargaKoms" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 50%; color: #FF0000;" >
                    &lt;---Isi harga perubahannya dengan angka tanpa ada titik, koma atau abjad</td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView>   
                 
            <asp:MultiView ID="MultiViewMhnNumerik" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="LblJudulNumerik" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Diisi"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:TextBox ID="TxtChangeNilaiNum" runat="server" text="" Width="149px" 
                        MaxLength="2"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik dua digit" ControlToValidate="TxtChangeNilaiNum" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 50%; color: #FF0000;" >
                    &lt;---Isi harga perubahannya dengan angka sebanyak 2 digit angka sebelah Kanan tahun  </td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView>   

            <asp:MultiView ID="MultiViewMhnTglKirim" runat="server" Visible="TRUE">
            <asp:View ID="ViewMhnTglKirim1" runat="server">
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr >
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jadwal Tanggal Kirim"></asp:Label></td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtKirimTgl" runat="server" Width="22%"  height= "21px" />
                    <asp:Button ID="BtnCalenderKirim" runat="server" Text=".." Width="3%" height= "21px" />
                    <div id="Div1">
                    <asp:Calendar ID="Calendar1Kirim" runat="server"  SelectedDate="<%# DateTime.Now %>" onselectionchanged="Calendar1Kirim_SelectionChanged" Font-Size="Smaller" />
                    </div>
                </td>
            </tr>
            </table>             
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label54" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jam Kirim Unit"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:DropDownList ID="DpDJamKirim" runat="server">
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 50%; color: #FF0000;" >
                    &lt;---Isi Jam dari Jam 8 sampai dengan jam 16  </td>
            </tr>
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label57" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Alamat Pengiriman"></asp:Label></td>
                <td style="width: 75%; Background-color:#CCCCFF;">

                    <asp:Button ID="BtnKirimAlamatSPK" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Alamat Sesuai dengan SPK" Width="225px" />
                    <asp:Button ID="BtnKirimAlamatSTNK" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Alamat Sesuai dengan STNK" Width="225px" />

                </td>
            </tr>

            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label58" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtKirimNama" runat="server" text="" Width="100%" 
                        MaxLength="40" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label60" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Alamat"></asp:Label></td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtKirimAlamat" runat="server" text="" Width="100%" 
                        Height="73px" MaxLength="80"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label61" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Kota"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtKirimKota" runat="server" text="" Width="100%" 
                        MaxLength="25"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label63" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="No Handphone"></asp:Label></td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtKirimNamaHP" runat="server" text="" Width="100%" 
                        MaxLength="20"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label67" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jenis"></asp:Label></td>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="LblKirimJenis" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="No Handphone"></asp:Label></td>

                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label80" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal DO"></asp:Label></td>

                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="LblKirimTglDO" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="No Handphone"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label64" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Rangka"></asp:Label></td>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="LblKirimRangka" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="No Handphone"></asp:Label></td>

                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label66" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="No DO"></asp:Label></td>

                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="LblKirimNoDO" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="No Handphone"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label65" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tipe"></asp:Label></td>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="LblKirimTipe" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="No Handphone"></asp:Label></td>

                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label68" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Warna"></asp:Label></td>

                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="LblKirimWarna" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="No Handphone"></asp:Label></td>
            </tr>

            </table> 




            </asp:View> 
            </asp:MultiView>   

            <asp:MultiView ID="MultiViewMhnTglKirimPameran" runat="server" Visible="TRUE">
            <asp:View ID="View20" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label59" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Pameran / Moving"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtKirimMoveTgl" runat="server" Width="22%"  height= "21px" />
                    <asp:Button ID="BtnKirimMove" runat="server" Text=".." Width="3%" height= "21px" />
                    <div id="Div2">
                    <asp:Calendar ID="CalendarKirimMove" runat="server"  SelectedDate="<%# DateTime.Now %>" onselectionchanged="CalendarKirimMove_SelectionChanged" Font-Size="Smaller" />
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label62" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Lokasi"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtKirimMoveLok" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label69" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Serah Terima"></asp:Label>
                    &nbsp;</td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtKirimMoveTerima" runat="server" Width="22%"  height= "21px" />
                    <asp:Button ID="BtnMoveTerima" runat="server" Text=".." Width="3%" height= "21px" />
                    <div id="Div3">
                    <asp:Calendar ID="CalendarMoveTerima" runat="server"  SelectedDate="<%# DateTime.Now %>" onselectionchanged="CalendarMoveTerima_SelectionChanged" Font-Size="Smaller" />
                    </div>

                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label70" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Perkiraan Tanggal Pengembalian Unit"></asp:Label>
                    &nbsp;</td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtKirimMoveKembali" runat="server" Width="22%"  height= "21px" />
                    <asp:Button ID="BtnMoveKembali" runat="server" Text=".." Width="3%" height= "21px" />
                    <div id="Div4">
                    <asp:Calendar ID="CalendarMoveKembali" runat="server"  SelectedDate="<%# DateTime.Now %>" onselectionchanged="CalendarMoveKembali_SelectionChanged" Font-Size="Smaller" />
                    </div>

                </td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label72" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama Sales"></asp:Label></td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtKirimMoveNmSl" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label73" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama SPV"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtKirimMoveNmSp" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label74" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Penanggung Jawab Pameran / Moving"></asp:Label></td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtKirimMoveNmTjb" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label75" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Rangka"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtKirimMoveRgk" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox>
                    <asp:Label ID="Lbl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=" Nomor Mesin "></asp:Label>
                    <asp:Label ID="LblKirimmoveMsn" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=" Nomor Mesin "></asp:Label>
                    </td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label77" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tipe/Warna"></asp:Label></td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:Label ID="LblKirimmoveTpy" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=" Nomor Mesin "></asp:Label>
                    <asp:Label ID="Label78" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=" Nomor Mesin "></asp:Label>
                    <asp:Label ID="LblKirimmoveWrn" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=" Nomor Mesin "></asp:Label>
                    </td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView>  



            <asp:MultiView ID="MultiViewMhnInpSwitch" runat="server" Visible="TRUE">
            <asp:View ID="View18" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label124" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor SPK yang akan menjadi Tujuan Transaksinya"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:TextBox ID="txtNoSPKSWTuju" runat="server" text="" Width="149px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator4" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik " ControlToValidate="txtNoSPKSWTuju" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 50%; color: #FF0000;" >&lt;---Isi Nomor SPK</td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label125" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jumlah Transaksinya (Rupiah)"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:TextBox ID="txtNoSPKSWNom" runat="server" text="" Width="149px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator5" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik " ControlToValidate="txtNoSPKSWNom" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 50%; color: #FF0000;" >&lt;---Isi Rupiah</td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView>   

            <asp:MultiView ID="MultiViewMhnInpBatalSPKHMS" runat="server" Visible="TRUE">
            <asp:View ID="View17" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label121" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor SPK yang dibatalkan"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:TextBox ID="TxtChangeSPKBatal" runat="server" text="" Width="149px"></asp:TextBox>
                </td>
                <td style="width: 50%; color: #FF0000;" >&lt;---Isi No SPK Yang Akan Dibatalkan</td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView>   
            
            <asp:MultiView ID="MultiViewMhnInpSubsidiSales" runat="server" Visible="TRUE">
            <asp:View ID="View15" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label118" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga Subsidi Sales"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:TextBox ID="TxtChangeSubsidiSales" runat="server" text="" Width="149px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidatorSubsidiSales" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik" ControlToValidate="TxtSubsidiSales" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 50%; color: #FF0000;" >&lt;---Isi harga Subsidi Sales </td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView>   
                 
            <asp:MultiView ID="MultiViewMhnInpLease" runat="server" Visible="TRUE">
            <asp:View ID="View19" runat="server">
            <table id="table1"  border="2" width="100%"  style="border-collapse:collapse;">
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label55" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Kode Lease"></asp:Label>
                    &nbsp;</td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtCdLease" runat="server" text="" Width="100px"  CssClass="uppercase"></asp:TextBox>
                    <asp:Label ID="Label56" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" 
                        Text=" " ForeColor="Red"></asp:Label>
                    <asp:Button ID="Button10" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Cari Kode Lease" Width="225px" />
                    <asp:Label ID="LblNamaLease" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama Lease"></asp:Label>

                </td>
            </tr>
            </table> 
            
            <asp:SqlDataSource ID="SqlDataSourceLease" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet112 %>" 
            SelectCommand="SELECT [LEASE_Nama], [LEASE_Kode], [LEASE_Singkatan], [LEASE_NamaCP] FROM [DATA_LEASE] WHERE ([LEASE_Nama] LIKE '%' + ? + '%')"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet112.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCdLease" Name="LEASE_Nama" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
            </asp:SqlDataSource>                 
            <asp:ListView ID="LVLeasing" runat="server" DataKeyNames="LEASE_Kode" DataSourceID="SqlDataSourceLease">
                <LayoutTemplate>
                    <table border="2" style="border-collapse:collapse;" width="100%">
                        <thead  style="background-color:Silver; height:30px">
                        <th>Kode</th><th>Nama</th><th>Singkatan</th>
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
                    <td style="width:20%; font-size:small">
                       <asp:LinkButton ID="LinkButton1" Text='<%# Eval("LEASE_Kode") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:70%; font-size: small"><%#Eval("LEASE_Nama")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("LEASE_Singkatan")%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            
            </asp:View> 
            </asp:MultiView>
                 
                 
                 
                 
                 
                 
            <asp:MultiView ID="MultiViewMhnInpLain" runat="server" Visible="TRUE">
            <asp:View ID="View10" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label22" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Selain Perubahan Harga"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:TextBox ID="TxtNilaiBaru" runat="server" text="" Width="149px"  CssClass="uppercase"></asp:TextBox>
                </td>
                <td style="width: 50%; color: #FF0000;" >
                    &lt;---Isi Nilai perubahannya</td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView>
            
            <asp:MultiView ID="MultiViewMhnDataPemohon" runat="server" Visible="TRUE">
            <asp:View ID="View3" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
             <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label38" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Pemohon"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="lblPemohon" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Pemohon"></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label35" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Pemohon"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="lblTglMohonUser" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
            </asp:View> 
            </asp:MultiView>

            <asp:MultiView ID="MultiViewAssInputSPK" runat="server" Visible="TRUE">
            <asp:View ID="View6" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr> 
                <td style="width: 25%; Background-color:#CCCCFF;">
                   <asp:Label ID="Label42" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="txtnospk" runat="server" text="" Width="104px" AutoPostBack="true"   CssClass="uppercase"></asp:TextBox>
                    
                    <asp:Button ID="ButtonRefreshAsesoris" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Perbarui Tabel" />
                        
                    <asp:Label ID="LblNoMohon" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="No Mohon" Width="118px"></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label34" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tipe Kendaraan"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="104px" AutoPostBack="true"  >
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtCariNamaAssesoris" runat="server" text="" Width="265px" 
                        AutoPostBack="true"  CssClass="uppercase"></asp:TextBox>
                    
                    <asp:Button ID="ButtonSimpan0" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Cari Aksesoris (Isi % Semua tampil)" />
                    <asp:Label ID="LblTipe" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Visible="False" Text="NON"></asp:Label>
                </td>
            </tr>
            </table>
            </asp:View> 
            </asp:MultiView>
            
            <asp:MultiView ID="MultiViewAssTblStandard" runat="server" Visible="TRUE">
                <asp:View ID="View21" runat="server">
                
                <asp:SqlDataSource ID="sdsTabelAksesorisMaster" runat="server" 
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
                SelectCommand="SELECT DATA_STANDARDH.STANDARDH_GroupType, DATA_STANDARD.STANDARD_Nama, DATA_STANDARD.STANDARD_Desc, DATA_STANDARDH.STANDARDH_CdAss FROM DATA_STANDARDH LEFT OUTER JOIN DATA_STANDARD ON DATA_STANDARDH.STANDARDH_CdAss = DATA_STANDARD.STANDARD_Kode WHERE (STANDARD_Aktif=0 OR STANDARD_Aktif IS NULL) AND ([STANDARDH_GroupType] = ?) AND ([STANDARD_Nama] LIKE '%' + ? + '%')  GROUP BY DATA_STANDARDH.STANDARDH_GroupType, DATA_STANDARD.STANDARD_Nama, DATA_STANDARD.STANDARD_Desc, DATA_STANDARDH.STANDARDH_CdAss ORDER BY DATA_STANDARD.STANDARD_Nama"                     
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                <SelectParameters>
                <asp:ControlParameter ControlID="LblTipe" Name="STANDARDH_GroupType" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TxtCariNamaAssesoris" Name="STANDARD_Nama" PropertyName="Text" Type="String" />
                </SelectParameters>
                </asp:SqlDataSource>                 
                <asp:ListView ID="LvDataMasterAss" runat="server" DataSourceID="sdsTabelAksesorisMaster" DataKeyNames ="STANDARDH_CdAss">
                <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px">
                      <th>Kode</th><th>Nama</th><th>Keterangan</th><th>Tipe</th>
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
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("STANDARDH_CdAss") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:40%; font-size: x-small"><%#Eval("STANDARD_Nama")%></td>
                    <td style="width:40%; font-size: x-small"><%#Eval("STANDARD_Desc")%></td>
                    <td style="width:10%; font-size: x-small"><%#Eval("STANDARDH_GroupType")%></td>
                </tr>
                </ItemTemplate>
                </asp:ListView>
                
                </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewAssData" runat="server" Visible="TRUE">
            <asp:View ID="View7" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">            
            <tr>
                <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="lblJudul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Kode Aksesoris"></asp:Label>
                </td>
                <td style="width: 75%; background-color :#CCCCFF ">
                    <asp:Label ID="LblAksesorisKode" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Kode Aksesoris"></asp:Label>
                    <asp:Label ID="LblApproved" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Tipe Kendaraan" Visible="False"></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="LblJudulAksesorisNama" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama Aksesoris"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="LblAksesorisNama" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Tipe Kendaraan"></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label27" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Catatan"></asp:Label>
                </td>
                <td style="width: 75%; background-color :#CCCCFF">
                    <asp:Label ID="LblAksesorisDesc" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Catatan"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Status"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="148px" 
                        AutoPostBack="true"  >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label29" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jumlah"></asp:Label>
                    &nbsp;</td>
                <td style="width: 75%; background-color :#CCCCFF">
                    <asp:TextBox ID="TxtAksesorisQty" runat="server" text="" Width="148px"></asp:TextBox>
                    <asp:CompareValidator ID="CVTxtAksesorisQty" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik tanpa koma atau titik" ControlToValidate="TxtAksesorisQty" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>

                    <asp:Label ID="LblAksesorisQty" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" 
                        Text=" " ForeColor="Red" Width="16px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label21" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga Jual Mugen"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="LblalertChangeHargaUnit" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" 
                        Text=" " ForeColor="Red"></asp:Label>
                    <asp:Label ID="LblAksesorisModal" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" Text="Tipe Kendaraan"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label26" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga Jual "></asp:Label>
                </td>
                <td style="width: 75%; background-color :#CCCCFF">
                    <asp:TextBox ID="TxtHargaAss" runat="server" text="" Width="208px"></asp:TextBox>
                    <asp:CompareValidator ID="CVTxtHargaAss" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik tanpa koma atau titik" ControlToValidate="TxtHargaAss" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                      
                    <asp:Label ID="LblAlertChangeHargaDisc" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" 
                        Text=" " ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Keterangan"></asp:Label>
                    &nbsp;</td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtCatatan" runat="server" text="" Width="727px" 
                        MaxLength="45"  CssClass="uppercase"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    &nbsp;</td>
                <td style="width: 75%; background-color :#CCCCFF">
                    <asp:Label ID="LblWarna" runat="server" Font-Names="Arial" 
                        Font-Size="Medium" height="21px" 
                        Text="WARNA HARUS DISISI" ForeColor="Red" Font-Bold="True"></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%;">
                <asp:Button ID="Button1" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" 
                    Font-Underline="True" ForeColor="Red" 
                        Text="Klik untuk Update Data SPK yang hanya judul di depannya Entry" 
                        Width="434px" />
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                </td>
                <td style="width: 75%; background-color :#CCCCFF">
                <asp:Label ID="LblNomorMohonOPT" runat="server" Font-Names="Arial" 
                    Font-Size="Small" Font-Bold="True" 
                    Font-Strikeout="False" ></asp:Label>
                <asp:Label ID="LblStatusUpdateOPT" runat="server" Font-Names="Arial" 
                    Font-Size="Small" height="21px" Text="Status Update SPK" Font-Bold="True" 
                    Font-Strikeout="False" Width="483px"></asp:Label>
                </td>
            </tr>
            </table>
            </asp:View> 
            </asp:MultiView>
            
            <asp:MultiView ID="MultiUpdateDataAksesoris" runat="server" Visible="TRUE">
            <asp:View ID ="View13" runat ="server">

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;"> 
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                    <asp:CheckBox ID="CheckBoxUpdateAss" runat="server" Text ="" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                    <asp:CheckBox ID="CheckBoxUpdateAss1" runat="server" Text ="" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                    <asp:CheckBox ID="CheckBoxUpdateAss2" runat="server" Text ="" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="Button12" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Medium" 
                    Font-Underline="True" ForeColor="blue" 
                    Text="Administrator Akan membuka Status open untuk proses Akseoris yang sudah disetujui" 
                    Width="100%" />
                </td>
            </tr> 
            </table>
            </asp:View>
            </asp:MultiView>
            
            <asp:MultiView ID="MultiViewAssTombol" runat="server" Visible="TRUE">
            <asp:View ID="View8" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%;">
                    <asp:Label ID="LblErrorSave" runat="server" Font-Names="Arial" 
                        Font-Size="Small" Font-Bold ="True" ForeColor="Red" height="21px" 
                        Text="?"></asp:Label>
                </td>
            </tr>
            </table>
            <br />
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%;">
                    <asp:Label ID="lblErrorTombolAsesoris" runat="server" Font-Names="Arial" 
                        Font-Size="Small" Font-Bold ="True" ForeColor="Red" height="21px" Text=""></asp:Label>
                </td>
            </tr>
            </table>
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; ">
                <asp:Button ID="ButtonSimpan" runat="server" Text="Tambah Asesoris" Width="250px" 
                    Height="34px" Font-Overline="False" Font-Size="Medium"  
                    BackColor="#004080" ForeColor="Yellow" Font-Bold="True"  />                       
                </td>
                <td style="width: 25%; ">
                <asp:Button ID="ButtonHapus" runat="server" Text="Hapus Asesoris" Width="250px" 
                    Height="34px" Font-Overline="False" Font-Size="Medium" BackColor="Red"   />    
                </td>
                <td style="width: 25%; ">
                </td>
                <td style="width: 25%; ">
                <asp:Button ID="BtnKembali2" runat="server" Text="Selesai" Width="250px" 
                    Font-Size="Medium"  Height="34px" BackColor="#FF9900" Visible="False" />    
                </td>
            </tr>
            </table>
            <br />
            </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewAssTabel" runat="server" Visible="TRUE">
            <asp:View ID="View9" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
           <tr> 
                <td style="width: 100%; height: 26px;">
                    <asp:Label ID="Label19" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "33px" 
                        Text="Aksesoris Yang hendak dipasang, Status = [1]Bayar,[0]Tidak Bayar,.......Status=0 untuk persetujuan SPV, Status=1 untuk persetujuan Sales Manager,.......Double klik untuk merubah status sesuai wewenang !!!..." 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
        </table>            
            <asp:SqlDataSource ID="sdsTabelPOAksesoris" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
             
            SelectCommand="SELECT TRXN_OPTPO.OPT_NODEALER, TRXN_OPTPO.OPT_USER, TRXN_OPTPO.OPT_TGL, TRXN_OPTPO.OPT_NOSPK, TRXN_OPTPO.OPT_TIPE, TRXN_OPTPO.OPT_CDASS, TRXN_OPTPO.OPT_STATUS, TRXN_OPTPO.OPT_HARGAJUAL, TRXN_OPTPO.OPT_HARGACUST, TRXN_OPTPO.OPT_KETERANGAN, TRXN_OPTPO.OPT_TGLAPPV1, TRXN_OPTPO.OPT_STATUSAPPV1, TRXN_OPTPO.OPT_CATATAN1, TRXN_OPTPO.OPT_TGLAPPV2, TRXN_OPTPO.OPT_STATUSAPPV2, TRXN_OPTPO.OPT_CATATAN2, TRXN_OPTPO.OPT_STATUSPROSES, TRXN_OPTPO.OPT_NOWO, TRXN_OPTPO.OPT_NOMORMOHON, TRXN_OPTPO.OPT_APPROVALCODE, TRXN_OPTPO.OPT_APPROVALCODEP, TRXN_OPTPO.OPT_SPV, TRXN_OPTPO.OPT_USERAPPV1, TRXN_OPTPO.OPT_USERAPPV2,TRXN_OPTPO.OPT_ERROR, TRXN_SPKAHERR.SPKAHERR_DESC, TRXN_SPKAHERR.SPKAHERR_DESCR, DATA_STANDARD.STANDARD_Nama 
                          FROM TRXN_OPTPO LEFT OUTER JOIN DATA_STANDARD ON TRXN_OPTPO.OPT_CDASS = DATA_STANDARD.STANDARD_Kode LEFT OUTER JOIN TRXN_SPKAHERR ON TRXN_OPTPO.OPT_NOMORMOHON = TRXN_SPKAHERR.SPKAHERR_NOM 
                          WHERE ([OPT_NOSPK] = ?) AND ([OPT_NODEALER] = ?)"                     
                          
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtnospk" Name="OPT_NOSPK" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="lblArea1" Name="OPT_NODEALER" PropertyName="Text" Type="String" />
            </SelectParameters>
            </asp:SqlDataSource>                 
            <asp:ListView ID="LvPO" runat="server" DataSourceID="sdsTabelPOAksesoris"  DataKeyNames ="OPT_CDASS">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead style="background-color:Silver; height:30px">
                <th>Kode</th><th>Tipe</th><th>Tanggal</th><th>Dealer</th><th>User</th>
                <th>Asesoris</th><th>Sts</th><th>Harga</th><th>Ps#1</th>
                <th>Sts Stj#1</th><th>User Stj#1</th>
                <th>Status</th><th>Catatan</th>
                </thead>

                <thead style="background-color:Silver; height:30px">
                <th></th><th></th><th>No WO</th><th>SPK</th><th>SPV</th>
                <th></th><th></th><th>Jual</th><th>Ps#2</th>
                <th>Sts Stj#2</th><th>User Stj#2</th>
                <th></th><th>Errr</th>
                </thead>

                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
    
            <asp:DataPager ID="dpPO" PageSize="20" runat="server">
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
                    <td rowspan="2" style="width:5%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("OPT_CDASS") %>' CommandName="Select" runat="server" />
                    </td>
                    <td rowspan="2" style="width:4%; font-size:x-small"><%#Eval("OPT_TIPE")%></td>
                    <td style="width:7%; font-size:x-small"><%#Format(Eval("OPT_TGL"), "dd-MM-yy hh:mm")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_NODEALER")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_USER")%></td>
                    
                    <td rowspan="2" style="width:10%; font-size:x-small"><%#Eval("STANDARD_Nama")%></td>
                    <td rowspan="2" style="width:3%; font-size:x-small"><%#Eval("OPT_STATUS")%></td>
                    <td rowspan="2" style="width:5%; font-size:x-small"><%#Eval("OPT_HARGACUST")%></td>
                    
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_APPROVALCODE")%></td>
                    
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_STATUSAPPV1")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_USERAPPV1")%></td>

                    
                    <td rowspan="2" style="width:6%; font-size:x-small"><%#Eval("OPT_STATUSPROSES")%></td>
                    <td style="width:7%; font-size:x-small"><%#Eval("OPT_KETERANGAN")%></td>
                </tr>
                <tr>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_NOWO")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_NOSPK")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_SPV")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_APPROVALCODEP")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_STATUSAPPV2")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_USERAPPV2")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("OPT_ERROR")%><%#Eval("SPKAHERR_DESC")%><%#Eval("SPKAHERR_DESCR")%></td>                    
                </tr>
                
            </ItemTemplate>
            </asp:ListView>
            </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewAssInpTabel" runat="server" Visible="TRUE">
            <asp:View ID="View11" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small">
            <tr>
                <td style="width: 100%; background-color: silver;  color: #FFFFFF;">
                 <asp:Button ID="Button8" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" 
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menambah asesoris" 
                    Width="100%" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; background-color: silver;  color: #FFFFFF;">
                 <asp:Button ID="Button9" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" 
                    Font-Underline="True" ForeColor="Green" 
                    Text="Tambah asesoris selesai" 
                    Width="100%" />
                </td>
            </tr>
            </table>

            
            </asp:View> 
            </asp:MultiView>

            <asp:MultiView ID="MultiViewTombolSPK" runat="server" Visible="TRUE">
            <asp:View ID="View4" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%;">
                    <asp:Label ID="lblerrorTombolSPK" runat="server" Font-Names="Arial" 
                        Font-Size="Small" Font-Bold ="True" ForeColor="Red" height="21px" Text=""></asp:Label>
                </td>
            </tr>
            </table>
            <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 50%;  color: #FFFFFF;">
            <asp:Button ID="BtnSaveMohon" runat="server" Text="Setuju" Width="321px" 
            Font-Size="X-Large" Height="39px" BackColor="#004080" />   
            <div id="flyoutBS2" style="display: none; overflow: hidden; z-index: 2; background-color: #FFFFFF; border: solid 1px #D0D0D0;"></div>
            <div id="infoBS2" style="display: none; width: 250px; z-index: 2; font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
            <div id="btnCloseParentBS2" style="float: right; visibility :hidden">
                                <asp:LinkButton id="btnCloseBS2" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                                     Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
                            </div>
                            <div><p>Tunggu Sedang Sistem sedang melakukan proses simpan sampai pesan ini tidak tertampil..................</p><br />
                            </div>
                        </div>        
                        <ajaxToolkit:AnimationExtender id="OpenAnimationBS2" runat="server" TargetControlID="BtnSaveMohon">
                            <Animations>
                                <OnClick>
                                    <Sequence>
                                    <EnableAction Enabled="false" />
                                    <ScriptAction Script="Cover($get('ctl00_SampleContent_BtnSaveMohon'), $get('flyoutBS2'));" />
                                    <StyleAction AnimationTarget="flyoutBS2" Attribute="display" Value="block"/>
                                    <Parallel AnimationTarget="flyoutBS2" Duration=".3" Fps="25">
                                        <Move Horizontal="150" Vertical="-50" />
                                        <Resize Width="260" Height="280" />
                                        <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                                    </Parallel>
                                    <ScriptAction Script="Cover($get('flyoutBS2'), $get('infoBS2'), true);" />
                                    <StyleAction AnimationTarget="infoBS2" Attribute="display" Value="block"/>
                                    <FadeIn AnimationTarget="infoBS2" Duration=".2"/>
                                    <StyleAction AnimationTarget="flyoutBS2" Attribute="display" Value="none"/>
                                    <Parallel AnimationTarget="infoBS2" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                                        <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                                    </Parallel>
                                    <Parallel AnimationTarget="infoBS2" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                                        <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                                        <FadeIn AnimationTarget="btnCloseParentBS2" MaximumOpacity=".9" />
                                    </Parallel>
                                    </Sequence>
                                </OnClick>
                            </Animations>
                        </ajaxToolkit:AnimationExtender>
                        <ajaxToolkit:AnimationExtender id="CloseAnimationBS2" runat="server" TargetControlID="btnCloseBS2">        
                        <Animations>
                            <OnClick>
                            <Sequence AnimationTarget="infoBS2">
                            <StyleAction Attribute="overflow" Value="hidden"/>
                            <Parallel Duration=".3" Fps="15">
                                <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                                <FadeOut />
                            </Parallel>
                            <StyleAction Attribute="display" Value="none"/>
                            <StyleAction Attribute="width" Value="250px"/>
                            <StyleAction Attribute="height" Value=""/>
                            <StyleAction Attribute="fontSize" Value="12px"/>
                            <OpacityAction AnimationTarget="btnCloseParentBS2" Opacity="0" />
                            <EnableAction AnimationTarget="BtnSaveMohon" Enabled="true" />
                            </Sequence>
                            </OnClick>
                            <OnMouseOver>
                            <Color Duration=".2" PropertyKey="color" StartValue="#FFFFFF" EndValue="#FF0000" />
                            </OnMouseOver>
                            <OnMouseOut>
                            <Color Duration=".2" PropertyKey="color" StartValue="#FF0000" EndValue="#FFFFFF" />
                            </OnMouseOut>
                        </Animations>
                        </ajaxToolkit:AnimationExtender>
            </td>
            <td style="width: 50%;  color: #FFFFFF;">
                <asp:Button ID="Button3" runat="server" Text="Selesai" Width="322px" 
                    Font-Size="X-Large" Height="39px" BackColor="#FF9900" Visible="False" />    
            </td>
            </tr>
            </table>
            </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewMhnTabelUbahSPK" runat="server" Visible="TRUE">
            <asp:View ID="View5" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr> 
                <td style="width: 100%; ">
                    <asp:Label ID="Label108" runat="server" Font-Names="Arial" Font-Size="Small" 
                        Text="Permohonan persetujuan yang sedang diajukan lihat di tabel bawah ini !!!..." 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 100%; ">
                    <asp:Label ID="Label81" runat="server" Font-Names="Arial" Font-Size="Small"  
                        Text="Catatan : Pos#1 adalah Kode persetujuan yang harus dilalui dan Pos#2 adalah Tahapan persetujuannya, hasil terakhir adalah POS1# sama dengan POS#2" 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 100%; ">
                    <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small"  
                        Text="Penjelasan dari kode Pos# : 0:Sales SPV  1:Sales Manager 2:Direktur 3:Vice President 4:Admin Head 5:Head Acconting" 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 100%; ">
                    <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small"  
                        Text="Contoh POS#1=01 artinya yg hrs menyetuji sales spv dan sm POS#2 =0 Artinya baru SPV dan Sales manager belum menyetujui" 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 100%; ">
                    <asp:Label ID="Label17" runat="server" Font-Names="Arial" Font-Size="Small"  
                        Text="Untuk melihat detail data SPK pilih kolom ''tipe permohonan'' yang mau dilihat / dikolom paling kiri" 
                        ForeColor="Blue" Width="100%" Font-Bold="True" Font-Strikeout="False" 
                        Font-Underline="True"></asp:Label>
                </td>
            </tr>
            </table>
                    
            </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewMhnTabelUbahSPKR1" runat="server" Visible="TRUE">
            <asp:View ID="View14" runat="server">
            
            
            <asp:ListView ID="LvTabelPermohoanan" 
            OnSelectedIndexChanging="TblPermohoananView_SelectedIndexChanging" 
            OnPagePropertiesChanging="TblPermohoananView_PagePropertiesChanging"
            runat="server">
            <LayoutTemplate>
                <table id="table-a"  border="2" width="100%" style="border-collapse:collapse;">
                    <thead  style="background-color:Silver">
                    <th>.</th><th>Tipe Permohonan</th><th>Buat</th><th>Proses</th><th>Nomor</th><th>No Urut</th><th>Dibuat</th><th>SPV</th>
                    <th>Pos #1</th><th>Pos #2</th><th>Detail Pemohonan</th><th>Alasan</th><th>Error</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width:1%; font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:14%; font-size:x-small" valign="top"><asp:Label ID="Lbl_Judul" runat="server" Text='<%#Eval("Temp_Judul")%>'/></td>
                    <td style="width:7%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_CREATE" runat="server" Text='<%#Eval("Temp_TANGGAL_CREATE")%>' /></td>
                    <td style="width:6%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PROSES" runat="server" Text='<%#Eval("Temp_TANGGAL_PROSES")%>' /></td>
                    <td style="width:6%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_NOMOHN" runat="server" Text='<%#Eval("Temp_NOMOR_MOHON")%>' /></td>
                    <td style="width:6%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_URUT" runat="server" Text='<%#Eval("Temp_URUT")%>' /></td>
                    <td style="width:3%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_USER" runat="server" Text='<%#Eval("Temp_MYUSER")%>' /></td>
                    <td style="width:3%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SPV" runat="server" Text='<%#Eval("Temp_SPV")%>' /></td>
                    <td style="width:2%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_APRVCODE" runat="server" Text='<%#Eval("Temp_APPROVALCODE")%>'/></td>
                    <td style="width:2%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_APRVCODEP" runat="server" Text='<%#Eval("Temp_APPROVALCODEP")%>'/></td>
                    <td style="width:22%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_CHANGE" runat="server" Text='<%#Eval("Temp_CHANGE")%>'/></td>
                    <td style="width:14%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_KETERANGAN" runat="server" Text='<%#Eval("Temp_KETERANGAN")%>'/></td>
                    <td style="width:14%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_ERROR" runat="server" Text='<%#Eval("Temp_SPKAHERR_DESC")%>'/></td>

                </tr>
            </ItemTemplate>
            <SelectedItemTemplate>
                <tr id="Tr1" runat="server" style="background-color:#ADD8E6">
                    <td>&nbsp;</td>
                    <td style="width:14%; font-size:x-small" valign="top"><asp:Label ID="Lbl_Judul" runat="server" Text='<%#Eval("Temp_Judul")%>' /></td>
                    <td style="width:7%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_CREATE" runat="server" Text='<%#Eval("Temp_TANGGAL_CREATE")%>' /></td>
                    <td style="width:6%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PROSES" runat="server" Text='<%#Eval("Temp_TANGGAL_PROSES")%>' /></td>
                    <td style="width:6%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_NOMOHN" runat="server" Text='<%#Eval("Temp_NOMOR_MOHON")%>' /></td>
                    <td style="width:6%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_URUT" runat="server" Text='<%#Eval("Temp_URUT")%>' /></td>
                    <td style="width:3%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_USER" runat="server" Text='<%#Eval("Temp_MYUSER")%>' /></td>
                    <td style="width:3%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SPV" runat="server" Text='<%#Eval("Temp_SPV")%>' /></td>
                    <td style="width:2%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_APRVCODE" runat="server" Text='<%#Eval("Temp_APPROVALCODE")%>'/></td>
                    <td style="width:2%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_APRVCODEP" runat="server" Text='<%#Eval("Temp_APPROVALCODEP")%>'/></td>
                    <td style="width:22%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_CHANGE" runat="server" Text='<%#Eval("Temp_CHANGE")%>'/></td>
                    <td style="width:14%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_KETERANGAN" runat="server" Text='<%#Eval("Temp_KETERANGAN")%>'/></td>
                    <td style="width:14%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_ERROR" runat="server" Text='<%#Eval("Temp_SPKAHERR_DESC")%>'/></td>
                </tr>
            </SelectedItemTemplate>
            </asp:ListView>        

            </asp:View> 
            </asp:MultiView>
            
            <br />
            <br />
            <br />
        </asp:View>
    </asp:MultiView>

</asp:Content>
