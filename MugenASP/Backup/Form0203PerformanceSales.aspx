<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0203PerformanceSales.aspx.vb" Inherits="Form05Keluhan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">PERFORMANCE SALES & SERVICE</h2>
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



   <asp:MultiView ID="MultiView2" runat="server" Visible="TRUE">
    <asp:View ID="View29" runat="server">
        <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" 
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
                    Text="Klik Disini Performance Pasar Minggu" Width="45%" Height="100%"  
                    BackColor="White" Font-Bold="True" ForeColor="Black" BorderStyle="None" 
                    Font-Italic="True" Font-Underline="True" />
               <asp:Button ID="ButtonPuri" runat="server" Text="Klik Disini Performance Puri" 
                    Width="45%" Height="100%"  
                    BackColor="White" Font-Bold="True" ForeColor="Black" BorderStyle="None" 
                    Font-Italic="True" Font-Underline="True" />
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
            <td style="width: 95%; ">
            <center>  <asp:Label ID="lblProsesBox" runat="server" Font-Bold="True" 
                Font-Names="Arial" Font-Size="Small" height="40px"  
                Width="99%" >Prosess</asp:Label></center>
            </td>
            </tr>

           </table>

        <br />
        <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px" Font-Bold="True" Font-Italic="True" 
        ForeColor="#0000A0">Pilih Kategori performance</asp:Label>
        <table style="width: 100%; height:100px; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
        <tr>
            <td style="width: 12%;">
            <asp:Button ID="BtnLaporanSalesman" runat="server" Text="Perform&#10;Sales" 
                    Width="100%" Height="100%" BackColor="Silver" Font-Bold="True" 
                    ForeColor="Black"  CssClass=""     />
            </td>
            <td style="width: 12%;"  >
               <asp:Button ID="BtnLaporanInsentive" runat="server" Text="Insentive" 
                    Width="100%" Height="100%"
                    BackColor="Silver" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 12%; ">
               <asp:Button ID="BtnLaporanPiutangSales" runat="server" Text="Piutang SPK" 
                    Width="100%" Height="100%"
                    BackColor="Silver" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 12%; ">
               <asp:Button ID="BtnLaporanLeasing" runat="server" Text="Sales&#10;Per Leasing" 
                    Width="100%" Height="100%"
                    BackColor="Silver" Font-Bold="True" ForeColor="Black" 
                    Font-Overline="False"  />
            </td>
            <td style="width: 12%; ">
               <asp:Button ID="BtnLaporanSurat" runat="server" Text="Surat&#10;Surat" 
                    Width="100%" Height="100%"
                    BackColor="Silver" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 12%; ">
               <asp:Button ID="BtnLaporanUmurUangMuka" runat="server" Text="Umur Uang Muka" 
                    Width="100%" Height="100%"  
                    BackColor="Silver" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 12%;">
            <asp:Button ID="BtnSPK" runat="server" Text="SPK" Width="100%" Height="100%" BackColor="Silver" Font-Bold="True" ForeColor="Black"  CssClass=""     />
            </td>
            <td style="width: 12%;"  >
               <asp:Button ID="BtnFakturJadi" runat="server" Text="Faktur Jadi" Width="100%" Height="100%"
                    BackColor="Silver" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 4%; ">
                &nbsp;</td>
       </tr>
    </table>

    </asp:View> 
    </asp:MultiView>


    <asp:MultiView ID="MultiView1" runat="server" Visible="TRUE">
    <asp:View ID="ViewSearch" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 22%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Kode Spv</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtGroup" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="41%" MaxLength="50" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
        </tr>
        </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr> 
                <td style="width: 100%; height: 26px;">
                    <asp:Label ID="Label43" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "33px" 
                        Text="SPV 112 : SC=Sales Counter, FD=Fitriyadi, HA=Hafidz Abduh, HM=Helmi, MA=Ivan, NP=Novianti, RP=Roni, KW=Tim KARAWACI " 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 100%; height: 26px;">
                    <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "33px" 
                        Text="SPV 128  : SC=Sales Counter, BY=Bayu, DH=David Hutabarat, MG=Megah, FW=Fendy Wijaya" 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
        </table>

    </asp:View> 
    </asp:MultiView> 


    <asp:MultiView ID="MultiView1a" runat="server" Visible="TRUE">
    <asp:View ID="View1" runat="server">
      <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Perform Per Sales</h2>
            </center>
	  </div>  
      <asp:SqlDataSource ID="sdsTabelPerformance" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM  DATA_SALESPERFORM WHERE ([SALES_MUGEN] LIKE '%' + ? + '%') AND ([SALES_GROUP] LIKE '%' + ? + '%')  ORDER BY SALES_MUGEN,SALES_GROUP"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
           <SelectParameters>
                <asp:ControlParameter ControlID="TxtCabang" Name="SALES_MUGEN" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtGroup" Name="SALES_GROUP" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
            </SelectParameters>

         </asp:SqlDataSource>                 
      <asp:ListView ID="lvSPK" runat="server" DataSourceID="sdsTabelPerformance" DataKeyNames ="SALES_KODE">
        <LayoutTemplate>
        <table border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Red  ; height:30px" >
                      <th>KODE</th><th>SALES</th><th>GROUP</th><th>MUGEN</th>
                      <th colspan="3" >BULAN 01</th>
                      <th colspan="3" >BULAN 02</th>
                      <th colspan="3" >BULAN 03</th>
                      <th colspan="3" >BULAN 04</th>
                      <th colspan="3" >BULAN 05</th>
                      <th colspan="3" >BULAN 06</th>
                      <th colspan="3" >BULAN 07</th>
                      <th colspan="3" >BULAN 08</th>
                      <th colspan="3" >BULAN 09</th>
                      <th colspan="3" >BULAN 10</th>
                      <th colspan="3" >BULAN 11</th>
                      <th colspan="3" >BULAN 12</th>
                    </thead>
                    <thead  style="background-color:Red ; height:30px">
                      <th></th><th></th><th></th><th></th>
                      <th>SPK</th><th>DO </th><th>FKT</th>
                      <th>SPK</th><th>DO </th><th>FKT</th>
                      <th>SPK</th><th>DO </th><th>FKT</th>
                      <th>SPK</th><th>DO </th><th>FKT</th>
                      <th>SPK</th><th>DO </th><th>FKT</th>
                      <th>SPK</th><th>DO </th><th>FKT</th>
                      <th>SPK</th><th>DO </th><th>FKT</th>
                      <th>SPK</th><th>DO </th><th>FKT</th>
                      <th>SPK</th><th>DO </th><th>FKT</th>
                      <th>SPK</th><th>DO </th><th>FKT</th>
                      <th>SPK</th><th>DO </th><th>FKT</th>
                      <th>SPK</th><th>DO </th><th>FKT</th>
                    </thead>
                    
                    
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
                <tr>
                    <td style="width:3%; font-size: smaller">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("SALES_KODE") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:10%; font-size: smaller"><%#Eval("SALES_NAMA")%></td>
                    <td style="width:3%; font-size: smaller"><%#Eval("SALES_GROUP")%></td>
                    <td style="width:3%; font-size: smaller"><%#Eval("SALES_MUGEN")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right ; background-color : Silver"><%#Eval("SALES_01SP")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_01DO")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_01FK")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right; background-color : Silver"><%#Eval("SALES_02SP")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_02DO")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_02FK")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right; background-color : Silver"><%#Eval("SALES_03SP")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_03DO")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_03FK")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right; background-color : Silver"><%#Eval("SALES_04SP")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_04DO")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_04FK")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right; background-color : Silver"><%#Eval("SALES_05SP")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_05DO")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_05FK")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right; background-color : Silver"><%#Eval("SALES_06SP")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_06DO")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_06FK")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right; background-color : Silver"><%#Eval("SALES_07SP")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_07DO")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_07FK")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right; background-color : Silver"><%#Eval("SALES_08SP")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_08DO")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_08FK")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right; background-color : Silver"><%#Eval("SALES_09SP")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_09DO")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_09FK")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right; background-color : Silver"><%#Eval("SALES_10SP")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_10DO")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_10FK")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right; background-color : Silver"><%#Eval("SALES_11SP")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_11DO")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_11FK")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right; background-color : Silver"><%#Eval("SALES_12SP")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_12DO")%></td>
                    <td style="width:2%; font-size: smaller; text-align:right"><%#Eval("SALES_12FK")%></td>
                </tr>
        </ItemTemplate>
      </asp:ListView>
    </asp:View>
    
    <asp:View ID="View2" runat="server">
      <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Insentive Per Sales</h2>
            </center>
	  </div>  
        <asp:ListView ID="LVInsentive" runat="server" DataSourceID="sdsTabelPerformance" DataKeyNames ="SALES_KODE">
            <LayoutTemplate>
            <table border="2" width="100%"  style="border-collapse:collapse;">
                    <thead  style="background-color:Red  ; height:30px">
                      <th>KODE</th><th>NAMA SALES</th><th>GROUP</th><th>MUGEN</th>
                      <th>BULAN 01</th>
                      <th>BULAN 02</th>
                      <th>BULAN 03</th>
                      <th>BULAN 04</th>
                      <th>BULAN 05</th>
                      <th>BULAN 06</th>
                      <th>BULAN 07</th>
                      <th>BULAN 08</th>
                      <th>BULAN 09</th>
                      <th>BULAN 10</th>
                      <th>BULAN 11</th>
                      <th>BULAN 12</th>
                     </thead>
                    <thead  style="background-color:Red ; height:30px">
                      <th></th><th></th><th></th><th></th>
                      <th>INSENTIVE</th>
                      <th>INSENTIVE</th>
                      <th>INSENTIVE</th>
                      <th>INSENTIVE</th>
                      <th>INSENTIVE</th>
                      <th>INSENTIVE</th>
                      <th>INSENTIVE</th>
                      <th>INSENTIVE</th>
                      <th>INSENTIVE</th>
                      <th>INSENTIVE</th>
                      <th>INSENTIVE</th>
                      <th>INSENTIVE</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width:3%; font-size: small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("SALES_KODE") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:10%; font-size: small"><%#Eval("SALES_NAMA")%></td>
                    <td style="width:3%; font-size: small"><%#Eval("SALES_GROUP")%></td>
                    <td style="width:3%; font-size: small"><%#Eval("SALES_MUGEN")%></td>
                    <td style="width:6%; font-size: small; text-align:right; background-color : Gray "><%#Eval("SALES_01IN")%></td>
                    <td style="width:6%; font-size: small; text-align:right"><%#Eval("SALES_02IN")%></td>
                    <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("SALES_03IN")%></td>
                    <td style="width:6%; font-size: small; text-align:right"><%#Eval("SALES_04IN")%></td>
                    <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("SALES_05IN")%></td>
                    <td style="width:6%; font-size: small; text-align:right"><%#Eval("SALES_06IN")%></td>
                    <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("SALES_07IN")%></td>
                    <td style="width:6%; font-size: small; text-align:right"><%#Eval("SALES_08IN")%></td>
                    <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("SALES_09IN")%></td>
                    <td style="width:6%; font-size: small; text-align:right"><%#Eval("SALES_10IN")%></td>
                    <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("SALES_11IN")%></td>
                    <td style="width:6%; font-size: small; text-align:right"><%#Eval("SALES_12IN")%></td>
                </tr>
        </ItemTemplate>
        </asp:ListView>
    </asp:View>

    <asp:View ID="View3" runat="server">
      <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Piutang Customer</h2>
            </center>
	  </div>  

      <asp:SqlDataSource ID="SqlARSTOCK" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM  DATA_ARSTOCK,DATA_TYPE WHERE ARSTOCK_CDTYPE=TYPE_TYPE AND ([ARSTOCK_DEALER] LIKE '%' + ? + '%') AND ([ARSTOCK_KDSPV] LIKE '%' + ? + '%') ORDER BY ARSTOCK_DEALER,ARSTOCK_KDSPV"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
           <SelectParameters>
                <asp:ControlParameter ControlID="TxtCabang" Name="ARSTOCK_DEALER" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtGroup" Name="ARSTOCK_KDSPV" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
            </SelectParameters>

        </asp:SqlDataSource>    
        <asp:ListView ID="LvAR" runat="server" DataSourceID="SqlARSTOCK" DataKeyNames ="ARSTOCK_DEALER">
        <LayoutTemplate>
            <table id="table-a"  border="2" width="150%"  style="border-collapse:collapse;">
                    <thead  style="background-color:Red ; height:30px">
                      <th>Dlr</th><th>SLS</th><th>SPV</th>
                      <th>SPK</th><th>Nama</th><th>Tgl SPK</th><th>Tgl DO</th><th>Tgl Terima</th>
                      <th>Tipe</th><th>Tahun</th><th>Lease</th><th>Tempo</th><th>Hari</th>
                      <th>Current</th><th>Minggu I</th><th>Minggu II</th><th>Minggu III</th><th>Minggu IV</th><th>Lebih</th>
                      <th>Piutang Unit</th><th>Piutang Ass</th>
                      <th>Keterangan</th><th>Posisi</th>
                     </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
                <tr>
                    <td style="width:2%; font-size:x-small"><%#Eval("ARSTOCK_DEALER")%></td>
                    <td style="width:2%; font-size:x-small"><%#Eval("ARSTOCK_KDSLS")%></td>
                    <td style="width:2%; font-size:x-small"><%#Eval("ARSTOCK_KDSPV")%></td>
                    
                    <td style="width:3%; font-size:x-small"><%#Eval("ARSTOCK_NOSPK")%></td>
                    <td style="width:8%; font-size:x-small"><%#Eval("ARSTOCK_NAMA")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("ARSTOCK_TGLSPK")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("ARSTOCK_TGLDO")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("ARSTOCK_TGLTERIMA")%></td>

                    <td style="width:3%; font-size:x-small"><%#Eval("ARSTOCK_CDTYPE")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("ARSTOCK_TAHUN")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("ARSTOCK_LEASE")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("ARSTOCK_TEMPO")%></td>
                    <td style="width:2%; font-size:x-small; text-align:right"><%#Eval("ARSTOCK_HARI")%></td>


                    <td style="width:4%; font-size:x-small; text-align:right; background-color : Silver"><%#Format(Eval("ARSTOCK_ARCURR"), "###,###,##0")%></td>
                    <td style="width:4%; font-size:x-small; text-align:right"><%#Format(Eval("ARSTOCK_ARWK01"), "###,###,##0")%></td>
                    <td style="width:4%; font-size:x-small; text-align:right; background-color : Silver"><%#Format(Eval("ARSTOCK_ARWK02"), "###,###,##0")%></td>
                    <td style="width:4%; font-size:x-small; text-align:right"><%#Format(Eval("ARSTOCK_ARWK03"), "###,###,##0")%></td>
                    <td style="width:4%; font-size:x-small; text-align:right; background-color : Silver"><%#Format(Eval("ARSTOCK_ARWK04"), "###,###,##0")%></td>
                    <td style="width:4%; font-size:x-small; text-align:right"><%#Format(Eval("ARSTOCK_ARWK99"), "###,###,##0")%></td>
                    <td style="width:4%; font-size:x-small; text-align:right; background-color :Yellow"><%#Format(Eval("ARSTOCK_PIUTANGU") - Eval("ARSTOCK_BAYARU"), "###,###,##0")%></td>
                    <td style="width:4%; font-size:x-small; text-align:right; background-color :Yellow"><%#Format(Eval("ARSTOCK_PIUTANGA") - Eval("ARSTOCK_BAYARA"), "###,###,##0")%></td>
                    <td style="width:12%; font-size:x-small"><%#Eval("ARSTOCK_KETERANGAN")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("ARSTOCK_TGL")%></td>
                </tr>
        </ItemTemplate>
        </asp:ListView>
    </asp:View>

    <asp:View ID="View4" runat="server">
      <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Sales per Leasing</h2>
            </center>
	  </div>  

      <asp:SqlDataSource ID="sdsTabelLeasPerformance" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM  REPORT_SPKLEASE ORDER BY SPKLEASE_DEALER,SPKLEASE_KODE"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
        </asp:SqlDataSource>                 
        <asp:ListView ID="LvPerolehanLeasing" runat="server" DataSourceID="sdsTabelLeasPerformance" DataKeyNames ="SPKLEASE_KODE">
        <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead  style="background-color:Red  ; height:30px">
                      <th>DLR</th><th>KODE</th><th>NAMA LEASING</th>
                      <th>BLN 01</th>
                      <th>BLN 02</th>
                      <th>BLN 03</th>
                      <th>BLN 04</th>
                      <th>BLN 05</th>
                      <th>BLN 06</th>
                      <th>BLN 07</th>
                      <th>BLN 08</th>
                      <th>BLN 09</th>
                      <th>BLN 10</th>
                      <th>BLN 11</th>
                      <th>BLN 12</th>
                      <th>TOT</th>
                     </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
                <tr>
                    <td style="width:3%; font-size: small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("SPKLEASE_DEALER") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:10%; font-size: small"><%#Eval("SPKLEASE_KODE")%></td>
                    <td style="width:35%; font-size: small"><%#Eval("SPKLEASE_NAMA")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF "><%#Eval("SPKLEASE_CNT01")%></td>
                    <td style="width:4%; font-size: small; text-align:right"><%#Eval("SPKLEASE_CNT02")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF"><%#Eval("SPKLEASE_CNT03")%></td>
                    <td style="width:4%; font-size: small; text-align:right"><%#Eval("SPKLEASE_CNT04")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF"><%#Eval("SPKLEASE_CNT05")%></td>
                    <td style="width:4%; font-size: small; text-align:right"><%#Eval("SPKLEASE_CNT06")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF"><%#Eval("SPKLEASE_CNT07")%></td>
                    <td style="width:4%; font-size: small; text-align:right"><%#Eval("SPKLEASE_CNT08")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF"><%#Eval("SPKLEASE_CNT09")%></td>
                    <td style="width:4%; font-size: small; text-align:right"><%#Eval("SPKLEASE_CNT10")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF"><%#Eval("SPKLEASE_CNT11")%></td>
                    <td style="width:4%; font-size: small; text-align:right"><%#Eval("SPKLEASE_CNT12")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF"><%#Eval("SPKLEASE_CNT")%></td>
                </tr>
        </ItemTemplate>
        </asp:ListView>
    </asp:View>

    <asp:View ID="View5" runat="server">
      <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Summary Surat-Surat</h2>
            </center>
	  </div>  

        <asp:SqlDataSource ID="SqlDataSurat" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT [WEBREPORT_DEALER], [WEBREPORT_DEPT], [WEBREPORT_GROUP], [WEBREPORT_NAMA], [WEBREPORT_01QTY], [WEBREPORT_04QTY], [WEBREPORT_03RP], [WEBREPORT_03QTY], [WEBREPORT_02RP], [WEBREPORT_02QTY], [WEBREPORT_01RP], [WEBREPORT_04RP], [WEBREPORT_05QTY], [WEBREPORT_05RP], [WEBREPORT_06QTY], [WEBREPORT_06RP], [WEBREPORT_07QTY], [WEBREPORT_07RP], [WEBREPORT_11QTY], [WEBREPORT_08QTY], [WEBREPORT_08RP], [WEBREPORT_09QTY], [WEBREPORT_09RP], [WEBREPORT_10QTY], [WEBREPORT_12RP], [WEBREPORT_12QTY], [WEBREPORT_11RP], [WEBREPORT_10RP] FROM [TEMP_WEBREPORT] WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='C' ORDER BY WEBREPORT_DEALER,WEBREPORT_GROUP"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
           <SelectParameters>
                <asp:ControlParameter ControlID="TxtCabang" Name="WEBREPORT_DEALER" 
                    PropertyName="Text" Type="String" />            
            </SelectParameters>
        </asp:SqlDataSource>   
        <asp:ListView ID="LvSuratSurat" runat="server" DataSourceID="SqlDataSurat" 
            DataKeyNames ="WEBREPORT_DEALER">
        <LayoutTemplate>
            <table id="table-a" border="2" width="100%"  style="border-collapse:collapse;">
                    <thead  style="background-color:Red ; height:30px">
                      <th>KODE</th><th>KETERANGAN</th>
                      <th>BLN 01</th><th>BLN 02</th><th>BLN 03</th>
                      <th>BLN 04</th><th>BLN 05</th><th>BLN 06</th>
                      <th>BLN 07</th><th>BLN 08</th><th>BLN 09</th>
                      <th>BLN 10</th><th>BLN 11</th><th>BLN 12</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
                <tr>
                    <td style="width:3%; font-size: small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("WEBREPORT_DEALER") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:25%; font-size: small"><%#Eval("WEBREPORT_NAMA")%></td>
                    <td style="width:6%; font-size: small"><%#Eval("WEBREPORT_01QTY")%></td>
                    <td style="width:6%; font-size: small"><%#Eval("WEBREPORT_02QTY")%></td>
                    <td style="width:6%; font-size: small"><%#Eval("WEBREPORT_03QTY")%></td>
                    <td style="width:6%; font-size: small"><%#Eval("WEBREPORT_04QTY")%></td>
                    <td style="width:6%; font-size: small"><%#Eval("WEBREPORT_05QTY")%></td>
                    <td style="width:6%; font-size: small"><%#Eval("WEBREPORT_06QTY")%></td>
                    <td style="width:6%; font-size: small"><%#Eval("WEBREPORT_07QTY")%></td>
                    <td style="width:6%; font-size: small"><%#Eval("WEBREPORT_08QTY")%></td>
                    <td style="width:6%; font-size: small"><%#Eval("WEBREPORT_09QTY")%></td>
                    <td style="width:6%; font-size: small"><%#Eval("WEBREPORT_10QTY")%></td>
                    <td style="width:6%; font-size: small"><%#Eval("WEBREPORT_11QTY")%></td>
                    <td style="width:6%; font-size: small"><%#Eval("WEBREPORT_12QTY")%></td>
                </tr>
        </ItemTemplate>
        </asp:ListView>
    </asp:View>
    
    <asp:View ID="View6" runat="server">
      <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Umur SPK Batal</h2>
            </center>
	  </div>  

        <asp:SqlDataSource ID="SqlDataUmurBatal" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT TEMP_REPORTBATALDANA.BATALDANA_DEALER, TEMP_REPORTBATALDANA.BATALDANA_NOSPK, TEMP_REPORTBATALDANA.BATALDANA_NAMA, TEMP_REPORTBATALDANA.BATALDANA_TYPE, TEMP_REPORTBATALDANA.BATALDANA_WARNA, TEMP_REPORTBATALDANA.BATALDANA_THN, TEMP_REPORTBATALDANA.BATALDANA_ALASAN, TEMP_REPORTBATALDANA.BATALDANA_UMUR, TEMP_REPORTBATALDANA.BATALDANA_TGL, TEMP_REPORTBATALDANA.BATALDANA_UPDATE, TEMP_REPORTBATALDANA.BATALDANA_JUMLAH, TEMP_REPORTBATALDANA.BATALDANA_SALES, TEMP_REPORTBATALDANA.BATALDANA_SPV, TEMP_REPORTBATALDANA.BATALDANA_TARGET, DATA_TYPE.TYPE_Nama, DATA_WARNA.WARNA_Int FROM TEMP_REPORTBATALDANA LEFT OUTER JOIN DATA_WARNA ON TEMP_REPORTBATALDANA.BATALDANA_WARNA = DATA_WARNA.WARNA_Kode LEFT OUTER JOIN DATA_TYPE ON TEMP_REPORTBATALDANA.BATALDANA_TYPE = DATA_TYPE.TYPE_Type WHERE (TEMP_REPORTBATALDANA.BATALDANA_DEALER = ?) ORDER BY BATALDANA_SPV,BATALDANA_NAMA"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
           <SelectParameters>
                <asp:ControlParameter ControlID="TxtCabang" Name="BATALDANA_DEALER" 
                    PropertyName="Text" Type="String" />            
            </SelectParameters>
        </asp:SqlDataSource>   
        <asp:ListView ID="LvUmurBatal" runat="server" DataSourceID="SqlDataUmurBatal" 
            DataKeyNames ="BATALDANA_DEALER">
        <LayoutTemplate>
            <table id="table-a" border="2" width="100%"  style="border-collapse:collapse;">
                    <thead  style="background-color:Red ; height:30px">
                      <th>Dealer</th><th>SPV</th><th>Sales</th>
                      <th>No SPK</th><th>Nama</th><th>Thn</th><th>Tipe</th><th>Warna</th>
                      <th>Alasan</th><th>Tgl Batal</th>
                      <th>Umur</th><th>Maksimal Umur</th><th>Jumlah</th><th>Tgl Report</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
                <tr>
                    <td style="width:3%; font-size:x-small "><%#Eval("BATALDANA_DEALER")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("BATALDANA_SPV")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("BATALDANA_SALES")%></td>

                    <td style="width:4%; font-size:x-small"><%#Eval("BATALDANA_NOSPK")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("BATALDANA_NAMA")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("BATALDANA_THN")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("TYPE_Nama")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("WARNA_Int")%></td>

                    <td style="width:16%; font-size:x-small"><%#Eval("BATALDANA_ALASAN")%></td>
                    <td style="width:9%; font-size:x-small"><%#Eval("BATALDANA_TGL")%></td>
                    <td style="width:4%; font-size: x-small; text-align:right"><%#Eval("BATALDANA_UMUR", "{0:N0}")%></td>
                    <td style="width:4%; font-size: x-small; text-align:right"><%#Eval("BATALDANA_TARGET", "{0:N0}")%></td>
                    <td style="width:5%; font-size: x-small; text-align:right"><%#Eval("BATALDANA_JUMLAH", "{0:N0}")%></td>

                    <td style="width:9%; font-size:x-small"><%#Eval("BATALDANA_UPDATE")%></td>
                </tr>
        </ItemTemplate>
        </asp:ListView>
    </asp:View>
    <asp:View ID="View7" runat="server">
        <asp:MultiView ID="MultiView1SPK" runat="server" Visible="TRUE">
        <asp:View ID="View11" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 13%; background-color:#CCCCFF">
                <asp:Label ID="LabelSPK8" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Nomor SPK</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF">
                <asp:TextBox ID="TxtNOSPK" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 13%; ">
                <asp:Label ID="Label29" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">SPV</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtCariSPV" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 13%;">
                &nbsp;</td>
            <td style="width: 75%;">
                <asp:Button ID="Button6" runat="server" Text="Pencarian Data" Width="273px" 
                    Font-Overline="False" Font-Size="Medium" BackColor="#0000A0" 
                    Font-Bold="True"    />    
            </td>
        </tr>
        </table>
        <asp:SqlDataSource ID="sdsTabelSPKG" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT 
                           (TRXN_SPKG.SPK_Cabang + '-' + TRXN_SPKG.SPK_No)as mDlrSPKNO,
                           (DATEDIFF(day,TRXN_SPKG.SPK_TGLSPK,GETDATE())) as mJumlah1,
                           (DATEDIFF(day,TRXN_SPKG.SPK_WarningTgl,GETDATE())) as mJumlah2,
                           DATA_WARNA.WARNA_Int, DATA_WARNA.WARNA_Ext, TRXN_SPKG.*, DATA_TYPE.TYPE_Nama FROM TRXN_SPKG,DATA_WARNA,DATA_TYPE WHERE TRXN_SPKG.SPK_CdWarna = DATA_WARNA.WARNA_Kode AND TRXN_SPKG.SPK_CdType = DATA_TYPE.TYPE_Type 
                           AND (TRXN_SPKG.SPK_WarningStatusHms IS NULL OR NOT(TRXN_SPKG.SPK_WarningStatusHms = '9')) AND (TRXN_SPKG.SPK_Cabang LIKE '%' + ? + '%' OR TRXN_SPKG.SPK_Cabang LIKE '%' + ? + '%') AND TRXN_SPKG.SPK_CdSSales LIKE '%' + ? + '%'  
                           ORDER BY SPK_CdSSales,DATEDIFF(day,TRXN_SPKG.SPK_WarningTgl,GETDATE())"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblArea1"      Name="SPK_Cabang"   PropertyName= "Text" Type="String" />            
                <asp:ControlParameter ControlID="lblArea2"      Name="SPK_Cabang2"  PropertyName= "Text" Type="String" />            
                <asp:ControlParameter ControlID="TxtCariSPV"    Name="SPV"          PropertyName="Text" Type="String" DefaultValue="%"  />            
            </SelectParameters>

        </asp:SqlDataSource>                         
        <asp:ListView ID="lvStatusSPK" runat="server" DataSourceID="sdsTabelSPKG" DataKeyNames ="mDlrSPKNO"><LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
            <thead  style="background-color:Silver">
            <th>Spk</th><th>H-Diary Input</th><th>H-Diary Setuju</th><th>Nama SPK</th><th>Nama Sales</th><th>SPV</th><th>Cara Bayar</th><th>Harga</th><th>Uang Muka</th><th>Tanggal</th><th>Riwayat Terakhir</th><th>Jml Riwayat</th><th>Umur SPK</th><th>Umur Riwayat</th>
            </thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="100" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate><tr><td style="width:7%; font-size:x-small  "><asp:LinkButton ID="lnkSelect" Text='<%#Eval("mDlrSPKNO") %>' CommandName="Select" runat="server" /></td><td style="width:6%; font-size: x-small"><%#Format(Eval("SPK_Tanggal"), "dd-MM-yy")%></td><td style="width:6%; font-size: x-small"><%#Format(Eval("SPK_TGLSPK"), "dd-MM-yy")%></td><td style="width:12%; font-size: x-small"><%#Eval("SPK_Nama1")%></td><td style="width:12%; font-size: x-small"><%#Eval("SPK_NmSales")%></td><td style="width:3%; font-size: x-small"><%#Eval("SPK_CdSSales")%></td><td style="width:12%; font-size: x-small"><%#Eval("SPK_NmLease")%></td><td style="width:6%; font-size: x-small"><%#Eval("SPK_Piutang")%></td><td style="width:6%; font-size: x-small"><%#Eval("SPK_UM")%></td><td style="width:6%; font-size: x-small"><%#Format(Eval("SPK_WarningTgl"), "dd-MM-yy")%></td><td style="width:12%; font-size: x-small"><%#Eval("SPK_WarningCatatan")%></td><td style="width:4%; font-size: x-small"><%#Eval("[SPK_WarningKali]")%></td><td style="width:4%; font-size: x-small"><%#Eval("[mJumlah1]")%></td><td style="width:4%; font-size: x-small"><%#Eval("[mJumlah2]")%></td></tr></ItemTemplate></asp:ListView>
    </asp:View>    
        <asp:View ID="View12" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 20%; background-color:#CCCCFF ;">
               <asp:Label ID="LabelSPK7" runat="server" Font-Names="Calibri" Font-Size="Medium"
                    height= "21px" Text="Kode Dealer"></asp:Label>
            </td>
            <td style="width: 80%; background-color:#CCCCFF ;">
                <asp:Label ID="LblDealer" runat="server" Text="" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        </table>
        <table style="width: 100%; height:inherit; font-family: Calibri; font-size: Medium;">
        <tr>
            <td style="width: 20%; ">
               <asp:Label ID="Label4" runat="server" Text="No. SPK" ></asp:Label>
            </td>
            <td style="width: 30%; ">
                <asp:Label ID="LblNoSPK" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 20%; ">
               <asp:Label ID="LabelSPK17" runat="server"  
                    height= "21px" Text="Nama SPK" ></asp:Label>
            </td>
            <td style="width: 30%; ">
                <asp:Label ID="LblNama" runat="server"></asp:Label>
            </td>
        </tr>        
        <tr>
            <td style="width: 20%; background-color:#CCCCFF ;">
               <asp:Label ID="Label8" runat="server" height= "21px" Text="Input HDiary [YYYY-MM-DD]" ></asp:Label>
            </td>
            <td style="width:30%; background-color:#CCCCFF ;">
                <asp:Label ID="LblTglHDiaryI" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; background-color:#CCCCFF ;">
               <asp:Label ID="Label9" runat="server" height= "21px" Text="Setujui HDiary [YYYY-MM-DD]" ></asp:Label>
            </td>
            <td style="width: 30%; background-color:#CCCCFF ;">
                <asp:Label ID="LblTglHDiaryA" runat="server"></asp:Label>
            </td>
        </tr>

        </table>
        <table style="width: 100%; height:inherit; font-family: Calibri; font-size: Medium;">

        <tr>
            <td style="width: 20%; ">
               <asp:Label ID="Label10" runat="server" height= "21px" Text="Tipe" ></asp:Label>
            </td>
            <td style="width: 80%">
                <asp:Label ID="LblTipe" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 20%; background-color:#CCCCFF ;">
               <asp:Label ID="Label11" runat="server" height= "21px" Text="Warna" ></asp:Label>
            </td>
            <td style="width: 80%; background-color:#CCCCFF ;">
                <asp:Label ID="LblWarna" runat="server"></asp:Label>
            </td>
        </tr>       
        <tr>
            <td style="width: 20%; ">
               <asp:Label ID="Label13" runat="server" height= "21px" Text="Cara Bayar" ></asp:Label>
            </td>
            <td style="width: 80%; ">
                <asp:Label ID="LblLease" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 20%; background-color:#CCCCFF ;">
               <asp:Label ID="Label19" runat="server" height= "21px" Text="Harga" ></asp:Label>
            </td>
            <td style="width: 80%; background-color:#CCCCFF ;">
                <asp:Label ID="LblRpHarga" runat="server"></asp:Label>
            </td>
        </tr>        
        <tr>
            <td style="width: 20%; ">
               <asp:Label ID="Label14" runat="server" height= "21px" Text="Potongan"></asp:Label>
            </td>
            <td style="width: 80%; ">
                <asp:Label ID="LblRpPotongan" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 20%; background-color:#CCCCFF ;">
               <asp:Label ID="Label1SPK15" runat="server" height= "21px" Text="Subsidi" ></asp:Label>
            </td>
            <td style="width: 80%; background-color:#CCCCFF ;">
                <asp:Label ID="LblRpSubsidi" runat="server"></asp:Label>
            </td>
        </tr>       
        <tr>
            <td style="width: 20%; ">
               <asp:Label ID="Label17" runat="server" height= "21px" Text="Komisi" ></asp:Label>
            </td>
            <td style="width: 80%; ">
                <asp:Label ID="LblRpKomisi" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 20%; background-color:#CCCCFF ;">
               <asp:Label ID="Label21" runat="server" height= "21px" Text="Aksesoris" ></asp:Label>
            </td>
            <td style="width: 80%; background-color:#CCCCFF ;">
                <asp:Label ID="LblRpAksesoris" runat="server"></asp:Label>
            </td>
        </tr>        
        <tr>
            <td style="width: 20%; ">
               <asp:Label ID="Label23" runat="server" height= "21px" Text="Uang Muka" ></asp:Label>
            </td>
            <td style="width: 80%; ">
                <asp:Label ID="LblRpUangMuka" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
        <table style="width: 100%; height:inherit; font-family: Calibri; font-size: Medium;">
         <tr>
            <td style="width: 20%; background-color:#CCCCFF ;">
               <asp:Label ID="Label35" runat="server" height= "21px" Text="Sales"></asp:Label>
            </td>
            <td style="width: 30%; background-color:#CCCCFF ;">
                <asp:Label ID="LblSales" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; background-color:#CCCCFF ;">
               <asp:Label ID="Label37" runat="server" height= "21px" Text="Supervisor" ></asp:Label>
            </td>
            <td style="width: 30%; background-color:#CCCCFF ;">
                <asp:Label ID="LblSPV" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
        <table style="width: 100%; height:inherit; font-family: Calibri; font-size: Medium;">
        <tr>
            <td style="width: 20%; ">
               <asp:Label ID="Label39" runat="server" height= "21px" Text="Catatan" ></asp:Label>
            </td>
            <td style="width: 80%; ">
                <asp:Label ID="LblCatatan" runat="server"></asp:Label>
            </td>
        </tr>        
        <tr>
            <td style="width: 20%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label45" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Status" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 80%; ">
                <asp:DropDownList ID="DropDownStatus4" runat="server" Width="350px">
                    <asp:ListItem Value="1">DITERUSKAN</asp:ListItem>
                    <asp:ListItem Value="2">DIBATALKAN UANG MUKA DIKEMBALIKAN KE PEMBELI</asp:ListItem>
                    <asp:ListItem Value="3">DIBATALKAN UANG MUKA TIDAK DIKEMBALIKAN KE PEMBELI</asp:ListItem>
                    <asp:ListItem Value="4">DIBATALKAN UANG MUKA TIDAK DIKEMBALIKAN KE PEMBELI PERSENTASI</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 20%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label47" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Catatan" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 80%; ">
                <asp:TextBox ID="TxtCatatan" runat="server" Width="788px" MaxLength="100"></asp:TextBox>
            </td>
        </tr>        
        <tr>
            <td style="width: 20%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Ringkasan Status" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 80%; ">
                <asp:Label ID="lblSummaryStatus" runat="server"></asp:Label>
                
            </td>
        </tr>        

        </table>
        <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%;">
                    <asp:Label ID="lblerrorTombolSPK" runat="server" Font-Names="Arial" 
                        Font-Size="Small" Font-Bold ="True" ForeColor="Red" height="21px" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
                <tr>
                   <td style="width: 25%;  color: #FFFFFF;">&nbsp;</td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="BtnSetuju" runat="server" Text="Simpan" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="Lime" />    
                   </td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="BtnTolak0" runat="server" Text="Kembali ke Tabel" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="Red" />    
                   </td>
                </tr>
                </table>
        <br />
        <br />
        <asp:SqlDataSource ID="sdsTabelriwayat" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT 
                           TRXN_SPKGR.SPKGR_User, TRXN_SPKGR.SPKGR_TglWarning, TRXN_SPKGR.SPKGR_Status, TRXN_SPKGR.SPKGR_Catatan
                           FROM TRXN_SPKGR 
                           WHERE (TRXN_SPKGR.SPKGR_Cabang LIKE '%' + ? + '%' AND TRXN_SPKGR.SPKGR_No LIKE '%' + ? + '%')   
                           ORDER BY SPKGR_TglWarning"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblDealer"  Name="SPKGR_Cabang"  PropertyName= "Text" Type="String" />            
                <asp:ControlParameter ControlID="LblNoSPK"   Name="SPKGR_No"      PropertyName= "Text" Type="String" />            
            </SelectParameters>

        </asp:SqlDataSource>                         
        <asp:ListView ID="LvRiwayat" runat="server" DataSourceID="sdsTabelriwayat" 
            DataKeyNames ="SPKGR_User">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
            <thead  style="background-color:Silver"><th>User</th><th>Tanggal Input</th><th>Status</th><th>Riwayat</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="100" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate><ItemTemplate><tr><td style="width:8%; font-size:x-small  "><asp:LinkButton ID="lnkSelect" Text='<%#Eval("SPKGR_User") %>' CommandName="Select" runat="server" /></td><td style="width:7%; font-size: x-small"><%#Format(Eval("SPKGR_TglWarning"), "dd-MM-yy")%></td><td style="width:5%; font-size: x-small"><%#Eval("SPKGR_STATUS")%></td><td style="width:80%; font-size: x-small"><%#Eval("SPKGR_Catatan")%></td></tr></ItemTemplate></asp:ListView>
         
    </asp:View>
    </asp:MultiView>

    </asp:View>
    <asp:View ID="View8" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;"> 
        <tr>
            <td style="width: 50%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Pencarian berdasarkan Sales</asp:Label>
            </td>
            <td style="width: 50%; ">
                <asp:TextBox ID="TxtCariFakturSales" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 50%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Pencarian berdasarkan SPV</asp:Label>
            </td>
            <td style="width: 50%; ">
                <asp:TextBox ID="TxtCariFakturSPV" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
            </td>
        </tr>
    </table>
        <asp:SqlDataSource ID="sdsTabelFaktur" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM TEMP_NOTIFY WHERE NOTIFY_TYPE='FAKTUR' AND NOTIFY_AREA LIKE '%' + ? + '%' AND NOTIFY_SALES LIKE '%' + ? + '%'  AND NOTIFY_SPV LIKE '%' + ? + '%' ORDER BY NOTIFY_TGL1"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                <SelectParameters>
                <asp:ControlParameter ControlID="lblArea1"           Name="NOTIFY_AREA"              PropertyName="Text" Type="String" />            
                <asp:ControlParameter ControlID="TxtCariFakturSales" Name="NOTIFY_SALES"             PropertyName="Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="TxtCariFakturSPV" Name="NOTIFY_SPV"             PropertyName="Text" Type="String" DefaultValue="%"  />            
                </SelectParameters>
        </asp:SqlDataSource>    
        <asp:ListView ID="lvFaktur" runat="server" DataSourceID="sdsTabelFaktur" DataKeyNames ="NOTIFY_AREA">
        <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Gray; font-size:small  ;height:50px" >
                      <th>Dealer</th><th>Tipe</th>
                      <th>SPK</th><th>Nama SPK</th><th>Nama Faktur/STNK</th>
                      <th>Sales</th><th>SPV</th>                                            
                      <th>Tgl Jadi</th><th>Tgl WO</th>                      
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            <asp:DataPager ID="dpBerita" PageSize="200" runat="server">
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
                    <td style="width:3%; font-size: x-small"><%#Eval("NOTIFY_AREA")%></td>
                    <td style="width:5%; font-size: x-small"><%#Eval("NOTIFY_TYPE")%></td>
                    <td style="width:5%; font-size: x-small"><%#Eval("NOTIFY_NOSPK")%></td>
                    <td style="width:19%; font-size: x-small"><%#Eval("NOTIFY_NAMA1")%></td>
                    <td style="width:19%; font-size: x-small"><%#Eval("NOTIFY_NAMA2")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("NOTIFY_SALES")%></td>
                    <td style="width:5%; font-size: x-small"><%#Eval("NOTIFY_SPV")%></td>
                    <td style="width:12%; font-size: x-small"><%#Eval("NOTIFY_TGL1")%></td>
                    <td style="width:12%; font-size: x-small"><%#Eval("NOTIFY_TGL2")%></td>
                </tr>
        </ItemTemplate>
        </asp:ListView>

    </asp:View>

  </asp:MultiView>
</asp:Content>
