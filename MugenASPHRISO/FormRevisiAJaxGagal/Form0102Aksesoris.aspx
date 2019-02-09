<%@ Page Language="VB"  MasterPageFile ="~/MasterPage.master"  AutoEventWireup="false" CodeFile="Form0102Aksesoris.aspx.vb" Inherits="Form02Aksesoris" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
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

    <table style="width: 100%; height:auto ; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 20%;height:auto ">
               <asp:Button ID="BtnOrderAss" runat="server" Text="Pemasangan Aksesoris"  
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
               <asp:Button ID="BtnLihatJdwl" runat="server" Text="Jadwal Kirim Unit Warehouse"  
                    BackColor="#808040" Font-Bold="True" ForeColor="White" Width="95%" Height="35px" />
            </td>
            <td style="width: 20%;height:auto ">
                &nbsp;</td>
            
        </tr>
     </table>
    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 100%; " valign="middle">
            </td>
        </tr>
        <tr>
            <td style="width: 100%; background:Green ;" >
                &nbsp;</td>
        </tr>
     </table>
<br />
<br />

    <asp:MultiView ID="MultiView1a" runat="server" Visible="TRUE">
        <asp:View ID="V1WAss" runat="server">
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
            <table border="2" width="100%"  style="border-collapse:collapse;">
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
        <asp:View ID="V2SPKBaru" runat="server">
        </asp:View>
        <asp:View ID="V3SPK" runat="server">
            <asp:MultiView ID="MultiViewMhnMaster" runat="server" Visible="TRUE">
            <asp:View ID="ViewMaster" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr> 
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                   <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="Txt_NoSPKMohon" runat="server" text="" Width="134px" AutoPostBack="true" CssClass="uppercase"></asp:TextBox>
                    <asp:Button ID="ButtonSPKrefresh" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Perbarui Tabel" />
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tipe permohonan"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="500px" AutoPostBack="true"  >
                    </asp:DropDownList>
                </td>
            </tr>
            
             <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label36" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Alasan"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="txtalasanmohon" runat="server" text="" Width="652px" MaxLength="100" CssClass="uppercase"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;"></td>
                <td style="width: 75%; ">
                    &nbsp;</td>
            </tr>
        
            </table> 
            </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewMhnDetail" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small">
            <tr> 
                <td style="width: 25%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                   <asp:Label ID="lblMohonDetailSPK" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
        </table>             
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small">
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
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small">
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
        </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small">
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
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small">
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label32" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga" ForeColor="Black"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblHarga" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; ">
                    &nbsp;</td>
                <td style="width: 25%; ">

                </td>
            </tr>
            </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small">
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
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small">
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
            </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small">
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
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
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
                    <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tipe permohonan"></asp:Label>
                </td>
                <td style="width: 75%; ">
                   <asp:Label ID="lblMohonDetailTipe" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td style="width: 25%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label14" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Alasan"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                   <asp:Label ID="lblMohonDetailAlasan" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    <asp:Label ID="lblMohonDetailJudul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Proses Persetujuan"></asp:Label>
                </td>
                <td style="width: 75%; ">
                   <asp:Label ID="lblMohonDetailProsesPersetujuan" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Posisi Persetujuan Terakhir"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF;">
                   <asp:Label ID="lblMohonDetailProsesPersetujuanAkhir" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="width: 25%;">
                    <asp:Label ID="lblMohonDetailJudul1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nilai perubahan"></asp:Label>
                </td>
                <td style="width: 75%;">
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
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label18" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Mohon"></asp:Label>
                </td>
                <td style="width: 75%;background-color:#CCCCFF;">
                   <asp:Label ID="LblNomormohon" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
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

            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label46" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Mohon"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF;">
                   <asp:Label ID="LblNomor" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
            </tr>

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
                    Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" 
                    Font-Underline="True" ForeColor="Red" Text="Klik disini untuk Update Data SPK yang hanya judul di depanya Entry" 
                    Width="100%" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; ">
                <asp:Label ID="LblStatusUpdateSPK" runat="server" Font-Names="Arial" 
                    Font-Size="Small" height="21px" Text="Status Update SPK" Font-Bold="True" 
                    Font-Strikeout="False" Width="100%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; ">
                <asp:Button ID="Button7" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" 
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menghapus validasi &quot;ADA PERMOHONAN RUBAH DATA DI HMS SDH DISETUJUI TAPI BLM DIRUBAH&quot;" 
                    Width="100%" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; ">
                    <asp:Label ID="Label5" runat="server" font-Names="Arial" 
                        Font-Size="Small" Font-Bold="True"                          
                        Text="Perhatian !!!! Sebelum melakukan penghapusan 'ADA PERMOHONAN RUBAH DATA DI HMS SDH DISETUJUI TAPI BLM DIRUBAH' periksa terlebih dahulu di sistem mugen perubahan data-data yang diinginkan sales sudah berubah sesuai dengan yang dimaksud, ini PENTING !!! karena jika sudah DO maka perubahan perubahan data SPK tidak diijinkan ......" 
                        ForeColor="Blue" BorderStyle="Dotted"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; ">
                    <asp:Button ID="ButtonSimpan2" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Tutup Form Detail" Width="100%" />
                </td>
            </tr>
            </table> 
            </asp:View> 
            
            </asp:MultiView>
            <asp:MultiView ID="MultiViewMhnInpDO" runat="server" Visible="TRUE">
            <asp:View ID="ViewMohonDO" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
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
            </table> 
            
            <asp:SqlDataSource ID="SdsDataStockDetail" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM DATA_TYPESTOCK,DATA_TYPE,DATA_WARNA WHERE (TYPESTOCK_UPDATE IS NULL OR TYPESTOCK_UPDATE='') AND TYPESTOCK_CDTYPE=TYPE_TYPE AND TYPESTOCK_CDWARNA=WARNA_KODE AND [TYPESTOCK_CDDEALER] LIKE '%' + ? + '%' AND [TYPESTOCK_NORANGKA] LIKE '%' + ? + '%' ORDER BY TYPESTOCK_CDDEALER,TYPE_CdGroup,TYPE_TYPE,WARNA_KODE"                     
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
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label104" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Dokument Yg Dilampirkan"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:CheckBox ID="CheckFktLamp1" runat="server" Font-Size="Small" Text="Form STNK  " />
                    <asp:CheckBox ID="CheckFktLamp2" runat="server" Font-Size="Small" Text="FotoCoptKTP  " />
                    <asp:CheckBox ID="CheckFktLamp3" runat="server" Font-Size="Small" Text="Surat Kuasa Perusahaan  " />
                    <asp:CheckBox ID="CheckFktLamp4" runat="server" Font-Size="Small" Text="Siup NPWP  " />
                    <asp:CheckBox ID="CheckFktLamp5" runat="server" Font-Size="Small" Text="Kontrak  " />
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label92" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Nama"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtFakturNama" runat="server" text="" Width="100%" MaxLength="30" CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label102" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > No KTP"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtFakturNoKTP" runat="server" text="" Width="100%" MaxLength="20"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label93" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Alamat"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtFakturAlamat" runat="server" text="" Width="100%" 
                        Height="73px" MaxLength="80"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label94" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Kota"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtFakturKota" runat="server" text="" Width="100%" 
                        MaxLength="20"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label96" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Kode Pos"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtFakturPos" runat="server" text="" Width="100%" 
                        MaxLength="5"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label98" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > No Handphone"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtFakturNoHP" runat="server" text="" Width="100%" 
                        MaxLength="20"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label101" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Tanggal Lahir"></asp:Label></td>
                <td style="width: 75%; ">
                <asp:TextBox ID="TxtTglLahir" runat="server" Width="22%"  height= "21px" />
                <asp:Button ID="Btn1" runat="server" Text=".." Width="3%" height= "21px" />
                <div id="Div10">
                <asp:Calendar ID="cDate" runat="server"  SelectedDate="<%# DateTime.Now %>" onselectionchanged="cDate_SelectionChanged" Font-Size="Smaller" />
                </div>

                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label100" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Agama"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="true" 
                        Width="167px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label103" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Pilih Nomor Polisi"></asp:Label></td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtFakturNoPolisi" runat="server" text="" Width="100%" 
                        MaxLength="10"  CssClass="uppercase"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label107" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Faktur > Catatan"></asp:Label></td>
                <td style="width: 75%; ">
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
            <asp:MultiView ID="MultiViewMhnInpTahun" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label48" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tahun Unit"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:TextBox ID="TxtChangeTahun" runat="server" text="" Width="149px" 
                        MaxLength="2"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik dua digit" ControlToValidate="TxtChangeTahun" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 50%; color: #FF0000;" >
                    &lt;---Isi harga perubahannya dengan angka sebanyak 2 digit angka sebelah Kanan tahun  </td>
            </tr>
            </table> 
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
                <td style="width: 25%; background-color :Gray ;  color: #FFFFFF;">
                   <asp:Label ID="Label42" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
                <td style="width: 75%; background-color : silver">
                    <asp:TextBox ID="txtnospk" runat="server" text="" Width="104px" AutoPostBack="true"   CssClass="uppercase"></asp:TextBox>
                    
                    <asp:Button ID="ButtonRefreshAsesoris" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Perbarui Tabel" />
                        
                    <asp:Label ID="LblNoMohon" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="No Mohon" Width="118px"></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="width: 25%; background-color: Gray;  color: #FFFFFF;">
                    <asp:Label ID="Label34" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tipe Kendaraan"></asp:Label>
                </td>
                <td style="width: 75%; background-color : silver">
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
                <table border="2" width="100%"  style="border-collapse:collapse;">
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
                <td style="width: 25%; background-color: Gray;  color: #FFFFFF;">
                    <asp:Label ID="lblJudul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Kode Aksesoris"></asp:Label>
                </td>
                <td style="width: 75%; background-color : silver ">
                    <asp:Label ID="LblAksesorisKode" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Kode Aksesoris"></asp:Label>
                    <asp:Label ID="LblApproved" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Tipe Kendaraan" Visible="False"></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="width: 25%; background-color: Gray;  color: #FFFFFF;">
                    <asp:Label ID="LblJudulAksesorisNama" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama Aksesoris"></asp:Label>
                </td>
                <td style="width: 75%; background-color : silver ">
                    <asp:Label ID="LblAksesorisNama" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Tipe Kendaraan"></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="width: 25%; background-color: Gray;  color: #FFFFFF;">
                    <asp:Label ID="Label27" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Catatan"></asp:Label>
                </td>
                <td style="width: 75%; background-color : silver ">
                    <asp:Label ID="LblAksesorisDesc" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px" Text="Catatan"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: Gray;  color: #FFFFFF;">
                    <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Status"></asp:Label>
                </td>
                <td style="width: 75%; background-color : silver ">
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="148px" 
                        AutoPostBack="true"  >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: Gray;  color: #FFFFFF;">
                    <asp:Label ID="Label29" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jumlah"></asp:Label>
                    &nbsp;</td>
                <td style="width: 75%; background-color : silver ">
                    <asp:TextBox ID="TxtAksesorisQty" runat="server" text="" Width="148px"></asp:TextBox>
                    <asp:CompareValidator ID="CVTxtAksesorisQty" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik tanpa koma atau titik" ControlToValidate="TxtAksesorisQty" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>

                    <asp:Label ID="LblAksesorisQty" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" 
                        Text=" " ForeColor="Red" Width="16px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: Gray;  color: #FFFFFF;">
                    <asp:Label ID="Label21" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga Jual Mugen"></asp:Label>
                </td>
                <td style="width: 75%; background-color : silver ">
                    <asp:Label ID="LblalertChangeHargaUnit" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" 
                        Text=" " ForeColor="Red"></asp:Label>
                    <asp:Label ID="LblAksesorisModal" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" Text="Tipe Kendaraan"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: Gray;  color: #FFFFFF;">
                    <asp:Label ID="Label26" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga Jual "></asp:Label>
                </td>
                <td style="width: 75%; background-color : silver ">
                    <asp:TextBox ID="TxtHargaAss" runat="server" text="" Width="208px"></asp:TextBox>
                    <asp:CompareValidator ID="CVTxtHargaAss" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik tanpa koma atau titik" ControlToValidate="TxtHargaAss" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                      
                    <asp:Label ID="LblAlertChangeHargaDisc" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" 
                        Text=" " ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: Gray;  color: #FFFFFF;">
                    <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Keterangan"></asp:Label>
                    &nbsp;</td>
                <td style="width: 75%; background-color : silver ">
                    <asp:TextBox ID="TxtCatatan" runat="server" text="" Width="727px" 
                        MaxLength="45"  CssClass="uppercase"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: Gray;  color: #FFFFFF;">
                    &nbsp;</td>
                <td style="width: 75%; background-color : silver ">
                    <asp:Label ID="LblWarna" runat="server" Font-Names="Arial" 
                        Font-Size="Medium" height="21px" 
                        Text="WARNA HARUS DISISI" ForeColor="Red" Font-Bold="True"></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="width: 25%; background-color: Gray;  color: #FFFFFF;">
                </td>
                <td style="width: 75%; background-color : silver ">
                <asp:Button ID="Button1" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" 
                    Font-Underline="True" ForeColor="Red" 
                        Text="Klik untuk Update Data SPK yang hanya judul di depannya Entry" 
                        Width="434px" />
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: Gray;  color: #FFFFFF;">
                </td>
                <td style="width: 75%; background-color : silver ">
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
                    BackColor="#00CC00"  />    
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
            <table border="2" width="100%"  style="border-collapse:collapse;">
                <thead style="background-color:Silver; height:30px">
                <th>Kode</th><th>No WO</th><th>Tipe</th><th>Dealer</th><th>User</th><th>SPV</th><th>Tanggal</th><th>SPK</th>
                <th>Asesoris</th><th>Sts</th><th>Jual</th><th>Ps#1</th><th>Ps#2</th>
                <th>Sts Stj#1</th><th>User Stj#1</th><th>Sts Stj#2</th><th>User Stj#2</th>
                <th>Status</th><th>Catatan</th><th>Error</th>
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
                    <td style="width:5%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("OPT_CDASS") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_NOWO")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_TIPE")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_NODEALER")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_USER")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_SPV")%></td>
                    <td style="width:7%; font-size:x-small"><%#Format(Eval("OPT_TGL"), "dd-MM-yy HH:MM")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_NOSPK")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("STANDARD_Nama")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_STATUS")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("OPT_HARGACUST")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_APPROVALCODE")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_APPROVALCODEP")%></td>
                    
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_STATUSAPPV1")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_USERAPPV1")%></td>

                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_STATUSAPPV2")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_USERAPPV2")%></td>
                    
                    <td style="width:6%; font-size:x-small"><%#Eval("OPT_STATUSPROSES")%></td>
                    <td style="width:7%; font-size:x-small"><%#Eval("OPT_KETERANGAN")%></td>
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

            <asp:MultiView ID="MultiViewMobilBekas" runat="server" Visible="TRUE">
            <asp:View ID="View12" runat="server">
            <table style="width: 100%; height:inherit; font-family: Calibri; font-size: Medium">
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label53" runat="server" height= "21px" Text="Nomor SPK"></asp:Label>
                </td>
                <td style="width: 85%; background-color:#CCCCFF ;">
                   <asp:Label ID="LblMobkasNoSPK" runat="server" Width="100%" Text=""></asp:Label>
                </td>
            </tr>            
            <tr> 
                <td style="width: 15%; " >
                   <asp:Label ID="Label54" runat="server" height= "21px" Text="Nama SPK"></asp:Label>
                </td>
                <td style="width: 85%; ">
                    <asp:TextBox ID="TxtMobkasNama" runat="server" text="" Width="50%" MaxLength="30" CssClass="uppercase"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator2" runat ="server"  
                      ErrorMessage ="Isian Karakter" ControlToValidate="TxtMobkasKota" Operator="DataTypeCheck" Type="String"></asp:CompareValidator>
                </td>
            </tr>
            <tr> 
                <td style="width: 10%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label55" runat="server" height= "21px" Text="Alamat"></asp:Label>
                </td>
                <td style="width: 90%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasAlamat" runat="server" text="AAAAAAAAAFAAAAAAAAAFAAAAAAAAAFAAAAAAAAAFAAAAAAAAAFAAAAAAAAAFAAAAAAAAAFAAAAAAAAAF" Width="85%" MaxLength="80"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValid_MobkasAlamat" runat ="server"  
                      ErrorMessage ="Isian Karakter" ControlToValidate="TxtMobkasAlamat" Operator="DataTypeCheck" Type="String"></asp:CompareValidator>
                </td>
            </tr>
            </table>             

            <table style="width: 100%; height:inherit; font-family: Calibri; font-size: Medium">
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ; " >
                   <asp:Label ID="Label56" runat="server" height= "21px" Text="Kota"></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasKota" runat="server" text="" Width="70%" MaxLength="30"  CssClass="uppercase"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValid_MobkasKota" runat ="server"  
                      ErrorMessage ="Isian Karakter" ControlToValidate="TxtMobkasKota" Operator="DataTypeCheck" Type="String"></asp:CompareValidator>
                </td>
                <td style="width: 15%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label95" runat="server" height= "21px" Text="Kode Pos "></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasPos" runat="server" text="" Width="50%" MaxLength="6" ></asp:TextBox>
                    <asp:CompareValidator ID="CompareValid_TxtMobkasPos" runat ="server"  
                      ErrorMessage ="Isian Angka" ControlToValidate="TxtMobkasPos" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>                      
                </td>
            </tr>
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label57" runat="server" height= "21px" Text="Tanggal Lahir"></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;" >
                <asp:TextBox ID="TxtMobkasTglLahir" runat="server" Width="130px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" />
                <asp:ImageButton ID="ImgBntCalc" runat="server" CausesValidation="False" />
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server"
                 TargetControlID="TxtMobkasTglLahir" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                 OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                
                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator5" runat="server"
                ControlExtender="MaskedEditExtender5" ControlToValidate="TxtMobkasTglLahir" EmptyValueMessage="Date is required"
                InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtMobkasTglLahir" PopupButtonID="ImgBntCalc" />
                </td>
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label58" runat="server" height= "21px" Text="Agama"></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:DropDownList ID="DropDownListAgama" runat="server" AutoPostBack="true" 
                        Width="50%">
                        <asp:ListItem>ISLAM</asp:ListItem>
                        <asp:ListItem>KATHOLIK</asp:ListItem>
                        <asp:ListItem>KRISTEN</asp:ListItem>
                        <asp:ListItem>BUDHA</asp:ListItem>
                        <asp:ListItem>BUDHA</asp:ListItem>
                        <asp:ListItem>LAIN-LAIN</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label59" runat="server" height= "21px" Text="Nomor telepon"></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasPhone" runat="server" text="" Width="50%" MaxLength="20"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat ="server" ErrorMessage ="Format Salah" 
                    ControlToValidate ="TxtMobkasPhone" 
                    ValidationExpression ="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$">
                    </asp:RegularExpressionValidator>

                </td>
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label60" runat="server" height= "21px" Text="Nomor Handphone"></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasHp" runat="server" text="" Width="50%" MaxLength="20"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat ="server" ErrorMessage ="Format Salah" 
                    ControlToValidate ="TxtMobkasHp" 
                    ValidationExpression ="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            </table>             

            <table style="width: 100%; height:inherit; font-family: Calibri; font-size: Medium">
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label61" runat="server" height= "21px" Text="Email"></asp:Label>
                </td>
                <td style="width: 85%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasEmail" runat="server" text="" Width="60%" MaxLength="50"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="reEmail" runat ="server" ErrorMessage ="Format Email tdk tepat" 
                    ControlToValidate ="TxtMobkasEmail" 
                    ValidationExpression ="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$">
                    </asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr> 
                <td style="width: 15%; " >
                   <asp:Label ID="Label70" runat="server" height= "21px" Text="Status Pembeli"></asp:Label>
                </td>
                <td style="width: 85%; ">
                    <asp:DropDownList ID="DropDownListStatus" runat="server" AutoPostBack="true" 
                        Width="50%">
                        <asp:ListItem>DIRECT / PERORANGAN</asp:ListItem>
                        <asp:ListItem>INDIRECT / SHOOWROOM UMUM</asp:ListItem>
                        <asp:ListItem>ORGANIZATION / PERUSAHAAN
                        </asp:ListItem>
                        <asp:ListItem>MEDIATOR</asp:ListItem>
                        <asp:ListItem>DIRECT / CROSS SELL HONDA</asp:ListItem>
                        <asp:ListItem>FIKTIF (SPK KOSONG)</asp:ListItem>
                        <asp:ListItem>H-DIARY / INFO</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            </table>             

            <table style="width: 100%; height:inherit; font-family: Calibri; font-size: Medium">            
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label62" runat="server" height= "21px" Text="Tipe"></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasTipe" runat="server" text="" Width="10%" MaxLength="7" CssClass="uppercase" ></asp:TextBox>
                    
                    <asp:TextBox ID="TxtMobkasTipeN" runat="server" text="" Width="68%" MaxLength="7" CssClass="uppercase" ></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidTxtMobkasTipe" runat ="server"  
                      ErrorMessage ="Isian Salah" ControlToValidate="TxtMobkasTipe" Operator="DataTypeCheck" Type="String" ></asp:CompareValidator>
                </td>
                
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label63" runat="server" height= "21px" Text="Warna"></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasWarna" runat="server" text="" Width="10%" MaxLength="4"></asp:TextBox>
                    <asp:TextBox ID="TxtMobkasWarnaN" runat="server" text="" Width="60%" MaxLength="4"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidTxtMobkasWarna" runat ="server"  
                      ErrorMessage ="Isian Salah" ControlToValidate="TxtMobkasWarna" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>    
            </table>             

            <asp:MultiView ID="MultiView1" runat="server" Visible="TRUE">

            </asp:MultiView>
            <asp:MultiView ID="MultiView2" runat="server" Visible="TRUE">

            </asp:MultiView>
            

            <table style="width: 100%; height:inherit; font-family: Calibri; font-size: Medium">                    
            <tr> 
                <td style="width: 15%; " >
                   <asp:Label ID="Label64" runat="server" height= "21px" Text="Tahun"></asp:Label>
                </td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtMobkasTahun" runat="server" text="" Width="15%" MaxLength="2"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValid_TxtMobkasTahun" runat ="server"  
                      ErrorMessage ="Isian Data Salah" ControlToValidate="TxtMobkasTahun" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 15%;" >
                   <asp:Label ID="Label67" runat="server" height= "21px" Text="On/Of Road"></asp:Label>
                </td>
                <td style="width: 35%; ">
                    <asp:DropDownList ID="DropDownRoad" runat="server" AutoPostBack="true" 
                        Width="50%">
                        <asp:ListItem>On Road</asp:ListItem>
                        <asp:ListItem>Off Road</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label69" runat="server" height= "21px" Text="Nomor Rangka"></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasRangka" runat="server" text="" Width="50%" MaxLength="20"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValid_TxtMobkasRangka" runat ="server"  
                      ErrorMessage ="Isian Data Salah" ControlToValidate="TxtMobkasRangka" Operator="DataTypeCheck" Type="String"></asp:CompareValidator>
                </td>
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label68" runat="server" height= "21px" Text="Nomor Mesin"></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasMesin" runat="server" text="" Width="50%" MaxLength="15"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValid_TxtMobkasMesin" runat ="server"  
                      ErrorMessage ="Isian Data Salah" ControlToValidate="TxtMobkasMesin" Operator="DataTypeCheck" Type="String"></asp:CompareValidator>
                </td>
            </tr>
            <tr> 
                <td style="width: 15%; " >
                   <asp:Label ID="Label65" runat="server" height= "21px" Text="Sales Kode"></asp:Label>
                </td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtMobkasSales" runat="server" text="" Width="10%" MaxLength="3"></asp:TextBox>
                    <asp:Label ID="lblMobkasSales" runat="server" Width="60%"  Text=""></asp:Label>
                    <asp:CompareValidator ID="CompareValidTxtMobkasSales" runat ="server"  
                      ErrorMessage ="Isian Salah" ControlToValidate="TxtMobkasSales" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 15%; " >
                   <asp:Label ID="Label66" runat="server" height= "21px" Text="SPV"></asp:Label>
                </td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtMobkasSPV" runat="server" text="" Width="10%" MaxLength="3"></asp:TextBox>
                    <asp:Label ID="lblMobkasSPV" runat="server" Width="60%"  Text=""></asp:Label>
                    <asp:CompareValidator ID="CompareValidTxtMobkasSPV" runat ="server"  
                      ErrorMessage ="Isian Salah" ControlToValidate="TxtMobkasSPV" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label72" runat="server" height= "21px" Text="Harga Jual"></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasHrgJual" runat="server" Width="130px" Height="16px" ValidationGroup = "MKE" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                    TargetControlID="TxtMobkasHrgJual" Mask="99,999,999,999" MessageValidatorTip="true"
                    OnFocusCssClass="MaskedEditFocus"  OnInvalidCssClass="MaskedEditError" MaskType="Number"
                    InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left"
                    ErrorTooltipEnabled="True" />
                    
                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
                    ControlExtender="MaskedEditExtender2" ControlToValidate="TxtMobkasHrgJual" IsValidEmpty="false"
                    MaximumValue="99000000000" EmptyValueMessage="Number is required" InvalidValueMessage="Number is invalid"
                    MaximumValueMessage="Number &gt; 99000000000" MinimumValueMessage="Number &lt; 0"
                    MinimumValue="0" Display="Dynamic" TooltipMessage="Input a number from 0 to 99000000000"
                    EmptyValueBlurredText="*"
                    InvalidValueBlurredMessage="*"
                    MaximumValueBlurredMessage="*"
                    MinimumValueBlurredText="*"
                    ValidationGroup="MKE" />
                </td>
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label77" runat="server" height= "21px" Text="Harga Jual Aksesoris"></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasHrgAks" runat="server" Width="130px" Height="16px" ValidationGroup="MKE" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                    TargetControlID="TxtMobkasHrgAks" Mask="99,999,999,999" MessageValidatorTip="true"
                    OnFocusCssClass="MaskedEditFocus"  OnInvalidCssClass="MaskedEditError" MaskType="Number"
                    InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left"
                    ErrorTooltipEnabled="True" />
                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                    ControlExtender="MaskedEditExtender2" ControlToValidate="TxtMobkasHrgAks" IsValidEmpty="false"
                    MaximumValue="99000000000" EmptyValueMessage="Number is required" InvalidValueMessage="Number is invalid"
                    MaximumValueMessage="Number &gt; 99000000000" MinimumValueMessage="Number &lt; 0"
                    MinimumValue="0" Display="Dynamic" TooltipMessage="Input a number from 0 to 99000000000"
                    EmptyValueBlurredText="*"
                    InvalidValueBlurredMessage="*"
                    MaximumValueBlurredMessage="*"
                    MinimumValueBlurredText="*"
                    ValidationGroup="MKE" />
                </td>
            </tr>
            <tr> 
                <td style="width: 15%;  background-color:#CCCCFF ;" >
                   <asp:Label ID="Label73" runat="server" height= "21px" Text="Potongan"></asp:Label>
                </td>
                <td style="width: 35%;  background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasHrgPot" runat="server" Width="130px" Height="16px" ValidationGroup="MKE" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                    TargetControlID="TxtMobkasHrgPot" Mask="99,999,999,999" MessageValidatorTip="true"
                    OnFocusCssClass="MaskedEditFocus"  OnInvalidCssClass="MaskedEditError" MaskType="Number"
                    InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left"
                    ErrorTooltipEnabled="True" />
                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator3" runat="server"
                    ControlExtender="MaskedEditExtender2" ControlToValidate="TxtMobkasHrgPot" IsValidEmpty="false"
                    MaximumValue="99000000000" EmptyValueMessage="Number is required" InvalidValueMessage="Number is invalid"
                    MaximumValueMessage="Number &gt; 99000000000" MinimumValueMessage="Number &lt; 0"
                    MinimumValue="0" Display="Dynamic" TooltipMessage="Input a number from 0 to 99000000000"
                    EmptyValueBlurredText="*"
                    InvalidValueBlurredMessage="*"
                    MaximumValueBlurredMessage="*"
                    MinimumValueBlurredText="*"
                    ValidationGroup="MKE" />
                </td>
                <td style="width: 15%; background-color:#CCCCFF ;" >
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                </td>
            </tr>
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label74" runat="server" height= "21px" Text="Komisi"></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasHrgKomisi" runat="server" Width="130px" Height="16px" ValidationGroup="MKE" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server"
                    TargetControlID="TxtMobkasHrgKomisi" Mask="99,999,999,999" MessageValidatorTip="true"
                    OnFocusCssClass="MaskedEditFocus"  OnInvalidCssClass="MaskedEditError" MaskType="Number"
                    InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left"
                    ErrorTooltipEnabled="True" />
                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator4" runat="server"
                    ControlExtender="MaskedEditExtender2" ControlToValidate="TxtMobkasHrgKomisi" IsValidEmpty="false"
                    MaximumValue="99000000000" EmptyValueMessage="Number is required" InvalidValueMessage="Number is invalid"
                    MaximumValueMessage="Number &gt; 99000000000" MinimumValueMessage="Number &lt; 0"
                    MinimumValue="0" Display="Dynamic" TooltipMessage="Input a number from 0 to 99000000000"
                    EmptyValueBlurredText="*"
                    InvalidValueBlurredMessage="*"
                    MaximumValueBlurredMessage="*"
                    MinimumValueBlurredText="*"
                    ValidationGroup="MKE" />
                </td>
                <td style="width: 15%; background-color:#CCCCFF ;" >
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                </td>
            </tr>
            <tr> 
                <td style="width: 15%;  background-color:#CCCCFF ;" >
                   <asp:Label ID="Label75" runat="server" height= "21px" Text="Subsidi"></asp:Label>
                </td>
                <td style="width: 35%;  background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasHrgSubsidi" runat="server" Width="130px" Height="16px" ValidationGroup="MKE" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender6" runat="server"
                    TargetControlID="TxtMobkasHrgSubsidi" Mask="99,999,999,999" MessageValidatorTip="true"
                    OnFocusCssClass="MaskedEditFocus"  OnInvalidCssClass="MaskedEditError" MaskType="Number"
                    InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left"
                    ErrorTooltipEnabled="True" />
                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator6" runat="server"
                    ControlExtender="MaskedEditExtender2" ControlToValidate="TxtMobkasHrgSubsidi" IsValidEmpty="false"
                    MaximumValue="99000000000" EmptyValueMessage="Number is required" InvalidValueMessage="Number is invalid"
                    MaximumValueMessage="Number &gt; 99000000000" MinimumValueMessage="Number &lt; 0"
                    MinimumValue="0" Display="Dynamic" TooltipMessage="Input a number from 0 to 99000000000"
                    EmptyValueBlurredText="*"
                    InvalidValueBlurredMessage="*"
                    MaximumValueBlurredMessage="*"
                    MinimumValueBlurredText="*"
                    ValidationGroup="MKE" />
                </td>
                <td style="width: 15%; background-color:#CCCCFF ;" >
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                </td>
            </tr>
            <tr> 
                <td style="width: 15%;  background-color:#CCCCFF ;" >
                   <asp:Label ID="Label106" runat="server" height= "21px" Text="Total"></asp:Label>
                </td>
                <td style="width: 35%;  background-color:#CCCCFF ;">
                   <asp:Label ID="LblMobKasTotalJual" runat="server" height= "21px"></asp:Label>
                </td>
                <td style="width: 15%; background-color:#CCCCFF ;" >
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    &nbsp;</td>
            </tr>
            <tr> 
                <td style="width: 15%; " >
                   <asp:Label ID="Label82" runat="server" height= "21px" Text="Cara Bayar/Leasing"></asp:Label>
                </td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtMobkasLease" runat="server" text="" Width="10%" MaxLength="4"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidTxtMobkasLease" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik tanpa koma atau titik" ControlToValidate="TxtMobkasLease" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 15%; " >
                   <asp:Label ID="Label83" runat="server" height= "21px" Text="Jangka Waktu"></asp:Label>
                </td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtMobkasLeaseJangka" runat="server" text="" Width="15%" MaxLength="2"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidTxtMobkasLeaseJangka" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik tanpa koma atau titik" ControlToValidate="TxtMobkasLeaseJangka" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            </table>             

            <table style="width: 100%; height:inherit; font-family: Calibri; font-size: Medium">
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label84" runat="server" height= "21px" Text="Tempo dalam Hari"></asp:Label>
                </td>
                <td style="width: 85%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasJTP" runat="server" text="" Width="8%" MaxLength="2"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidTxtMobkasJTP" runat ="server"  
                      ErrorMessage ="Tipe data harus numerik tanpa koma atau titik" ControlToValidate="TxtMobkasJTP" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr> 
                <td style="width: 15%; " >
                   <asp:Label ID="Label78" runat="server" height= "21px" Text="Keterangan"></asp:Label>
                </td>
                <td style="width: 85%; ">
                    <asp:TextBox ID="TxtMobkasKeterangan" runat="server" text="" Width="80%" MaxLength="40"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidTxtMobkasKeterangan" runat ="server"  
                      ErrorMessage ="Isian Salah" ControlToValidate="TxtMobkasKeterangan" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label81" runat="server" height= "21px" Text="Faktur Nama"></asp:Label>
                </td>
                <td style="width: 85%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasFNama" runat="server" text="" Width="80%" MaxLength="30"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidTxtMobkasFNama" runat ="server"  
                      ErrorMessage ="Isian Salah" ControlToValidate="TxtMobkasFNama" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label97" runat="server" height= "21px" Text="Faktur Alamat"></asp:Label>
                </td>
                <td style="width: 85%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasFAlamat" runat="server" text="" Width="80%" MaxLength="80"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidTxtMobkasFAlamat" runat ="server"  
                      ErrorMessage ="Isian Salah" ControlToValidate="TxtMobkasFAlamat" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            </table>             

            <table style="width: 100%; height:inherit; font-family: Calibri; font-size: Medium">
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label86" runat="server" height= "21px" Text="Faktur Kota"></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasFKota" runat="server" text="" Width="50%" MaxLength="30"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidTxtMobkasFKota" runat ="server"  
                      ErrorMessage ="Isian Salah" ControlToValidate="TxtMobkasFKota" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 15%; background-color:#CCCCFF ;">
                    <asp:Label ID="Label87" runat="server" height= "21px" Text="Kode Pos "></asp:Label>
                </td>
                <td style="width: 35%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasFPos" runat="server" text="" Width="50%" MaxLength="6"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidTxtMobkasFPos" runat ="server"  
                      ErrorMessage ="Isian Salah" ControlToValidate="TxtMobkasFPos" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>                      
                </td>
            </tr>
            <tr> 
                <td style="width: 10%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label89" runat="server" height= "21px" 
                        Text="Faktur Tanggal Lahir"></asp:Label>
                </td>
                <td style="width: 40%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasFTglLahir" runat="server" Width="130px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" />
                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender9" runat="server"
                    TargetControlID="TxtMobkasFTglLahir" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                
                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator9" runat="server"
                    ControlExtender="MaskedEditExtender5" ControlToValidate="TxtMobkasFTglLahir" EmptyValueMessage="Date is required"
                    InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TxtMobkasFTglLahir" PopupButtonID="ImgBntCalc" />
                </td>
                <td style="width: 10%;  background-color:#CCCCFF ;" >
                   <asp:Label ID="Label91" runat="server" height= "21px" Text="Agama"></asp:Label>
                </td>
                <td style="width: 40%;  background-color:#CCCCFF ;">
                    <asp:DropDownList ID="DropDownListFagama" runat="server" AutoPostBack="true" 
                        Width="50%">
                        <asp:ListItem>ISLAM</asp:ListItem>
                        <asp:ListItem>KATHOLIK</asp:ListItem>
                        <asp:ListItem>KRISTEN</asp:ListItem>
                        <asp:ListItem>BUDHA</asp:ListItem>
                        <asp:ListItem>BUDHA</asp:ListItem>
                        <asp:ListItem>LAIN-LAIN</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr> 
                <td style="width: 10%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label99" runat="server" height= "21px" Text="Faktur telepon"></asp:Label>
                </td>
                <td style="width: 40%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasFPhone" runat="server" text="" Width="50%" MaxLength="20"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidTxtMobkasFPhone" runat ="server"  
                      ErrorMessage ="Isian Salah" ControlToValidate="TxtMobkasFPhone" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 10%;  background-color:#CCCCFF ;" >
                   <asp:Label ID="Label105" runat="server" height= "21px" Text="Nomor Handphone"></asp:Label>
                </td>
                <td style="width: 40%;  background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasFHp" runat="server" text="" Width="50%" MaxLength="20"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidTxtMobkasFHp" runat ="server"  
                      ErrorMessage ="Isian Salah" ControlToValidate="TxtMobkasFHp" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            </table>             
            <table style="width: 100%; height:inherit; font-family: Calibri; font-size: Medium">
            <tr> 
                <td style="width: 15%; " >
                   <asp:Label ID="Label85" runat="server" height= "21px" Text="Harga Beli"></asp:Label>
                </td>
                <td style="width: 85%; ">
                    <asp:TextBox ID="TxtMobkasModal" runat="server" Width="130px" Height="16px" ValidationGroup="MKE" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender7" runat="server"
                    TargetControlID="TxtMobkasModal" Mask="99,999,999,999" MessageValidatorTip="true"
                    OnFocusCssClass="MaskedEditFocus"  OnInvalidCssClass="MaskedEditError" MaskType="Number"
                    InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left"
                    ErrorTooltipEnabled="True" />
                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator7" runat="server"
                    ControlExtender="MaskedEditExtender2" ControlToValidate="TxtMobkasModal" IsValidEmpty="false"
                    MaximumValue="99000000000" EmptyValueMessage="Number is required" InvalidValueMessage="Number is invalid"
                    MaximumValueMessage="Number &gt; 99000000000" MinimumValueMessage="Number &lt; 0"
                    MinimumValue="0" Display="Dynamic" TooltipMessage="Input a number from 0 to 99000000000"
                    EmptyValueBlurredText="*"
                    InvalidValueBlurredMessage="*"
                    MaximumValueBlurredMessage="*"
                    MinimumValueBlurredText="*"
                    ValidationGroup="MKE" />
                </td>
            </tr>            
            <tr> 
                <td style="width: 15%; background-color:#CCCCFF ;" >
                   <asp:Label ID="Label80" runat="server" height= "21px" Text="PPN"></asp:Label>
                </td>
                <td style="width: 85%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtMobkasModalPPN" runat="server" Width="130px" Height="16px" ValidationGroup="MKE" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender8" runat="server"
                    TargetControlID="TxtMobkasModalPPN" Mask="99,999,999,999" MessageValidatorTip="true"
                    OnFocusCssClass="MaskedEditFocus"  OnInvalidCssClass="MaskedEditError" MaskType="Number"
                    InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left"
                    ErrorTooltipEnabled="True" />
                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator8" runat="server"
                    ControlExtender="MaskedEditExtender2" ControlToValidate="TxtMobkasModalPPN" IsValidEmpty="false"
                    MaximumValue="99000000000" EmptyValueMessage="Number is required" InvalidValueMessage="Number is invalid"
                    MaximumValueMessage="Number &gt; 99000000000" MinimumValueMessage="Number &lt; 0"
                    MinimumValue="0" Display="Dynamic" TooltipMessage="Input a number from 0 to 99000000000"
                    EmptyValueBlurredText="*"
                    InvalidValueBlurredMessage="*"
                    MaximumValueBlurredMessage="*"
                    MinimumValueBlurredText="*"
                    ValidationGroup="MKE" />
                </td>
            </tr>
            <tr> 
                <td style="width: 15%; " >
                   <asp:Label ID="Label79" runat="server" height= "21px" Text="Suplier"></asp:Label>
                </td>
                <td style="width: 85%; ">
                   <asp:TextBox ID="TxtMobkasSuplier" runat="server" text="" Width="5%" MaxLength="30"></asp:TextBox>
                   <asp:Label ID="LblMobkasSuplier" runat="server" height= "21px" Text=""></asp:Label>
                    <asp:CompareValidator ID="CompareValidTxtMobkasSuplier" runat ="server"  
                      ErrorMessage ="Isian Salah" ControlToValidate="TxtMobkasSuplier" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            </table>  
            <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 25%;  color: #FFFFFF;">
                <asp:Button ID="Button10" runat="server" Text="Simpan" Width="321px" 
                    Height="43px" Font-Overline="False" Font-Size="X-Large" 
                    BackColor="#00FFCC"  />    
            </td>
            <td style="width: 25%;  color: #FFFFFF;">
                <asp:Button ID="Button11" runat="server" Text="Selesai" Width="322px" 
                    Font-Size="X-Large" Height="39px" BackColor="#FF9900" Visible="False" />    
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
            <td style="width: 25%;  color: #FFFFFF;">
                <asp:Button ID="Button2" runat="server" Text="Simpan" Width="321px" 
                    Height="43px" Font-Overline="False" Font-Size="X-Large" 
                    BackColor="#00FFCC"  />    
            </td>
            <td style="width: 25%;  color: #FFFFFF;">
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
                    <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small"  
                        Text="Pos 1# : Posisi yang akan menyetujui (0=SPV 1=Sales Manager 2=OPS 3=Direktur) : Contoh 01 harus disetujui oleh SPV dan Sales Manager" 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 100%; ">
                    <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small"  
                        Text="Pos 2# : Status Sudah disetujui oleh ? , Contoh 0 artinya sudah disetujui oleh SPV, contoh 01 artinya sudah disetujui oleh SPV dan sales Manager" 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 100%; ">
                    <asp:Label ID="Label17" runat="server" Font-Names="Arial" Font-Size="Small"  
                        Text="Untuk melihat detail prosess persetujuannya pilih tanggal entry yang mau dilihat kolom sebelah kiri" 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
            </table>
            <asp:SqlDataSource ID="sdsTabelPermohonan" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT (TRXN_SPKAH.TANGGAL_ENTRY) as mJudul,TRXN_SPKAH.NOMOR_SPK, TRXN_SPKAH.JUDUL, TRXN_SPKAH.KETERANGAN, TRXN_SPKAH.TANGGAL_SETUJU, TRXN_SPKAH.TANGGAL_ENTRY, TRXN_SPKAH.TANGGAL_PROSES, TRXN_SPKAH.NOMOR_MOHON, TRXN_SPKAH.CABANG, TRXN_SPKAH.CATATAN, TRXN_SPKAH.STATUS, TRXN_SPKAH.APPROVALCODE, TRXN_SPKAH.NOMOR, TRXN_SPKAH.APPROVALCODEP, TRXN_SPKAH.RUPIAH, TRXN_SPKAH.CHANGE, TRXN_SPKAH.MYUSER, TRXN_SPKAH.MAIL, TRXN_SPKAH.CHANGE1, TRXN_SPKAH.CHANGE2, TRXN_SPKAH.CHANGE3, TRXN_SPKAH.SPV, TRXN_SPKAHERR.SPKAHERR_DESC, TRXN_SPKAHERR.SPKAHERR_DESCR 
                          FROM TRXN_SPKAH LEFT OUTER JOIN TRXN_SPKAHERR ON TRXN_SPKAH.NOMOR_MOHON = TRXN_SPKAHERR.SPKAHERR_NOM 
                          WHERE (TRXN_SPKAH.NOMOR_SPK LIKE '%' + ? + '%') AND ((TRXN_SPKAH.CABANG LIKE '%' + ? + '%') OR (TRXN_SPKAH.CABANG LIKE '%' + ? + '%')) ORDER BY TANGGAL_ENTRY DESC"                     

            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="Txt_NoSPKMohon" Name="NOMOR_SPK" PropertyName="Text" Type="String"/>            
                <asp:ControlParameter ControlID="lblArea1" Name="CABANG" PropertyName= "Text" Type="String" />            
                <asp:ControlParameter ControlID="lblArea2" Name="CABANG2" PropertyName= "Text" Type="String" />            
            </SelectParameters>
            </asp:SqlDataSource>                     
            <asp:ListView ID="LvPermohonan" runat="server" DataSourceID="sdsTabelPermohonan" DataKeyNames ="mJudul">
            <LayoutTemplate>
            <table border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px">
                <th>Buat</th><th>Proses</th><th>Nomor</th><th>Dibuat</th><th>SPV</th><th>Tipe Permohonan</th><th>Pos #1</th><th>Pos #2</th>
                <th>Change/Hrg Unit</th><th>Potongan</th><th>Subsidi</th><th>Komisi</th><th>Alasan</th><th>Error</th>
                </thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
    
            <asp:DataPager ID="dpBerita" PageSize="8" runat="server">
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
                    <td style="width:7%; font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("mJudul") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:6%; font-size:x-small"><%#Eval("TANGGAL_PROSES")%></td>
                    <td style="width:6%; font-size:x-small"><%#Eval("NOMOR_MOHON")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("MYUSER")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("SPV")%></td>
                    <td style="width:9%; font-size:x-small"><%#Eval("JUDUL")%></td>
                    <td style="width:2%; font-size:x-small"><%#Eval("APPROVALCODE")%></td>
                    <td style="width:2%; font-size:x-small"><%#Eval("APPROVALCODEP")%></td>

                    <td style="width:6%; font-size:x-small"><%#Eval("CHANGE")%></td>
                    <td style="width:6%; font-size:x-small"><%#Eval("CHANGE1")%></td>
                    <td style="width:6%; font-size:x-small"><%#Eval("CHANGE2")%></td>
                    <td style="width:6%; font-size:x-small"><%#Eval("CHANGE3")%></td>

                    <td style="width:9%; font-size:x-small"><%#Eval("KETERANGAN")%></td>
                    <td style="width:9%; font-size:x-small"><%#Eval("SPKAHERR_DESC")%><%#Eval("SPKAHERR_DESCR")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
            </asp:View> 
            </asp:MultiView>
            
            <br />
            <br />
            <br />
            
            
       
        </asp:View>
        <asp:View ID="V4Jadwal" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 25%; ">
               <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jadwal Tanggal Pengiriman"></asp:Label>
            </td>
            <td style="width: 25%; ">
                <asp:TextBox ID="txtDate" runat="server" />
                <asp:Button ID="Button5" runat="server" Text=".." Width="27px" />
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
            SelectCommand="SELECT * FROM TRXN_STOCKMKIRIM LEFT OUTER JOIN TRXN_STOCK ON TRXN_STOCKMKIRIM.STOCKM_NORANGKA = TRXN_STOCK.STOCK_NoRangka LEFT OUTER JOIN TRXN_STOCKKKIRIM ON TRXN_STOCK.STOCK_NoRangka = TRXN_STOCKKKIRIM.STOCKK_NORANGKA WHERE (TRXN_STOCKMKIRIM.STOCKM_TGLMOHONKIRIM = ?)"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtDate" Name="STOCKM_TGLMOHONKIRIM" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
            
            </asp:SqlDataSource>                 
            <asp:ListView ID="lvKirimmUnit" runat="server" DataSourceID="sdsTabelJdw" DataKeyNames ="STOCKM_NORANGKA">
            <LayoutTemplate>
            <table border="2" width="100%"  style="border-collapse:collapse;">
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
    </asp:MultiView>

</asp:Content>
