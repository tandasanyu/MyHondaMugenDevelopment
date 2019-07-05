<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0204PerformanceUnit.aspx.vb" Inherits="Form05Keluhan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div>
            <center>
                <h2 style="font-family:Cooper Black;">S T O K</h2>
            </center>
	</div>  
    <center>
    <p   style ="font-size:small" >
        <asp:Label ID="Label44"  Text ="Performance Sales >> " runat="server"></asp:Label>
        &nbsp; Nama User&nbsp; : 
        <asp:Label ID="LblUserName" runat="server"></asp:Label>
        <asp:Label ID="lblAkses" runat="server"></asp:Label>
        &nbsp; Akses &nbsp; : 
        <asp:Label ID="lblArea1" runat="server"></asp:Label>
        <asp:Label ID="lblArea2" runat="server"></asp:Label>
    </p>
            </center>
       
    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
          
        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Judul 
        Permohonan</asp:Label>
          
    </asp:View> 
    </asp:MultiView>
       
    <asp:MultiView ID="MultiView1" runat="server" Visible="TRUE">
    <asp:View ID="View5" runat="server">
    <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 15%; ">
               <asp:Button ID="BtnOrder" runat="server" Text="Summary Stok" Width="73%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 15%; ">
               <asp:Button ID="Button1" runat="server" Text="Detail Stok" Width="80%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 30%; ">
               <asp:Button ID="Button3" runat="server" 
                    Text="Rangka DO Imora Belum Terima (Intrasit)" Width="90%" 
                    BackColor="Yellow" Font-Bold="True"  ForeColor="Black"  />
            </td>            
            <td style="width: 15%; ">
               <asp:Button ID="BtnTukarStok" runat="server" Text="Tukar Stok" Width="80%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 25%; ">
               <asp:Button ID="Btn" runat="server" Text="Kirim Stock Crossell" Width="80%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Visible="false"    />
            </td>
        </tr>
     </table>
    </asp:View> 
    </asp:MultiView>
       
  <asp:MultiView ID="MultiView1a" runat="server" Visible="TRUE">
    <asp:View ID="View1SummaryStok" runat="server">
        <div>
            <center>
                <h2 style="font-family:Cooper Black;">Laporan Summary Unit Stok</h2>
            </center>
    	</div>  

        <asp:SqlDataSource ID="sdsTabelUnit" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT 
                          (TYPEP_MUGEN+'-'+TYPEP_CDGROUP+'-'+TYPEP_TYPE) as mfNoKey,
                          TYPEP_NAMA,TYPEP_STOCK,TYPEP_STOCKTGL, 
                          TYPEP_JUAL01,TYPEP_JUAL02,TYPEP_JUAL03,TYPEP_JUAL04,TYPEP_JUAL05,
                          TYPEP_JUAL06,TYPEP_JUAL07,TYPEP_JUAL08,TYPEP_JUAL09,TYPEP_JUAL10,TYPEP_JUAL11,TYPEP_JUAL12 
                          FROM DATA_TYPEPERFORM 
                          WHERE TYPEP_STOCKTGL IS NOT NULL 
                          ORDER BY TYPEP_MUGEN,TYPEP_CDGROUP,TYPEP_TYPE"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">

        </asp:SqlDataSource>                 
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 13%; background-color: #000000;  color: #FFFFFF;">
            </td>
            <td style="width: 75%; ">
            </td>
        </tr>
        </table>            
        <asp:ListView ID="lvSummaryUnit" runat="server" DataSourceID="sdsTabelUnit" DataKeyNames ="mfNoKey">
        <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Gray; font-size:small  ;height:50px" >
                      <th>Kode</th><th>Nama</th>
                      <th>Stok</th><th>DiscMax 2019</th>
                      <th>Return</th><th>DN Blm Stok</th>
                      <th>DO Imora Intransit</th><th>Alokasi Imora</th>                                            
                      <th>DO Non SPJ</th><th>SPK</th>                                            
                      <th>Stok 2018</th><th>SPK 2018</th>
                      <th>Stok 2019</th><th>SPK 2019</th>
                      <th>Faktur</th><th>Tanggal</th>
                      
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
                    <!--<th>Kode</th><th>Nama</th>-->
                    <td style="width:12%; font-size: small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("mfNoKey") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:15%; font-size: small"><%#Eval("TYPEP_NAMA")%></td>
                    
                    <!--<th>Stok</th><th>DiscMax 2019</th>-->
                    <td style="width:5%; font-size: small; text-align:right ; background-color : Yellow"><%#Eval("TYPEP_STOCK")%></td>
                    <td style="width:5%; font-size: small; text-align:right ; background-color : Yellow"><%#Eval("TYPEP_JUAL12")%></td>
                    
                    <!--<th>Return</th><th>DN Blm Stok</th>-->
                    <td style="width:5%; font-size: small; text-align:right; background-color :#FF8080"><%#Eval("TYPEP_JUAL11")%></td>
                    <td style="width:5%; font-size: small; text-align:right; background-color : #FFFF80"><%#Eval("TYPEP_JUAL08")%></td>

                    <!--<th>DO Imora Intransit</th><th>Alokasi Imora</th>--> 
                    <td style="width:5%; font-size: small; text-align:right; background-color : #FFFF80"><%#Eval("TYPEP_JUAL10")%></td>
                    <td style="width:5%; font-size: small; text-align:right; background-color : #FFFF80"><%#Eval("TYPEP_JUAL09")%></td>

                    <!--<<th>DO Non SPJ</th><th>SPK</th>-->                     
                    <td style="width:5%; font-size: small; text-align:right"><%#Eval("TYPEP_JUAL07")%></td>
                    <td style="width:5%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("TYPEP_JUAL01")%></td>

                    <!--<th>Stok 2018</th><th>SPK 2018</th>-->
                    <td style="width:5%; font-size: small; text-align:right; background-color : Yellow"><%#Eval("TYPEP_JUAL02")%></td>
                    <td style="width:5%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("TYPEP_JUAL03")%></td>                    
                    
                    <!--<th>Stok 2019</th><th>SPK 2019</th>-->
                    <td style="width:5%; font-size: small; text-align:right; background-color : Yellow"><%#Eval("TYPEP_JUAL04")%></td>
                    <td style="width:5%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("TYPEP_JUAL05")%></td>
                    
                    <!--<th>Faktur</th><th>Tanggal</th>-->
                    <td style="width:5%; font-size: small; text-align:right"><%#Eval("TYPEP_JUAL06")%></td>
                    <td style="width:8%; font-size: small; text-align:right"><%#Format(Eval("TYPEP_STOCKTGL"), "dd-MM-yy HH")%></td>

                </tr>
        </ItemTemplate>
        </asp:ListView>
   </asp:View>    
    <asp:View ID="View2DetailStok" runat="server">        
        <div>
            <center>
                <h2 style="font-family:Cooper Black;">Laporan Detail Unit Stok</h2>
            </center>
    	</div>  
        <asp:SqlDataSource ID="SqlTabelUnitDetail" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT *,(ISNULL(TYPE_NAMA,'')+ISNULL(TYPESTOCK_DNTIPE,'')) as mNamaTipe,(ISNULL(WARNA_int,'')+ISNULL(TYPESTOCK_DNWARNA,'')) as NamaWarna FROM DATA_TYPESTOCK,DATA_TYPE,DATA_WARNA WHERE 
                          TYPESTOCK_CDTYPE=TYPE_TYPE AND TYPESTOCK_CDWARNA=WARNA_KODE AND 
                          [TYPESTOCK_CDDEALER] LIKE '%' + ? + '%' AND [TYPE_CDGROUP] LIKE '%' + ? + '%' AND [TYPE_TYPE] LIKE '%' + ? + '%'  AND [TYPESTOCK_UPDATE] LIKE '%' + ? + '%' 
                          ORDER BY TYPESTOCK_UPDATE,TYPESTOCK_CDDEALER,TYPE_CdGroup,TYPE_TYPE,TYPESTOCK_DNTIPE,WARNA_KODE,TYPESTOCK_DNWARNA,TYPESTOCK_TGLTERIMA,TYPESTOCK_NORANGKA"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblLokasi"         Name="TYPESTOCK_CDDEALER"        PropertyName= "Text" Type="String" />            
                <asp:ControlParameter ControlID="lblGroup"          Name="TYPE_CDGROUP"              PropertyName="Text" Type="String"  />            
                <asp:ControlParameter ControlID="LblTipeKode"       Name="TYPE_TYPE"                 PropertyName= "Text" Type="String" />            
                <asp:ControlParameter ControlID="LblKelompokTabel"  Name="TYPESTOCK_UPDATE"          PropertyName="Text" Type="String"  />                     
            </SelectParameters>

        </asp:SqlDataSource>                 
        <asp:ListView ID="LvStokDetail" 
        runat="server" DataSourceID="SqlTabelUnitDetail"  DataKeyNames ="TYPESTOCK_NORANGKA"
        OnSelectedIndexChanging="TblDetailStockView_SelectedIndexChanging" 
        OnPagePropertiesChanging="TblDetailStockView_PagePropertiesChanging"
        >
        <LayoutTemplate>
            <table id="table-a" border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px" >
                      <th></th><th>Dealer</th><th>Group</th><th>Kode</th><th>Nama</th><th>Warna</th><th>Rangka</th><th>SPK</th><th>Faktur</th><th>Tanggal</th><th>DO Imora</th><th>Catatan</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
                <tr>

                    <td style="width:3%; font-size: small">
                       <asp:LinkButton ID="lnkSelect" Text='Request' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:4%; font-size:  small" valign="top"><asp:Label ID="Lbl_Dealer" runat="server" Text='<%#Eval("TYPESTOCK_CDDEALER")%>'/></td>
                    <td style="width:4%; font-size:  small" valign="top"><asp:Label ID="Lbl_TipeGroup" runat="server" Text='<%#Eval("TYPE_CDGROUP")%>'/></td>
                    <td style="width:6%; font-size:  small" valign="top"><asp:Label ID="Lbl_TipeKode" runat="server" Text='<%#Eval("TYPE_TYPE")%>'/></td>
                    <td style="width:16%; font-size: small" valign="top"><asp:Label ID="Lbl_TipeNama" runat="server" Text='<%#Eval("mNamaTipe")%>'/></td>
                    <td style="width:14%; font-size: small" valign="top"><asp:Label ID="Lbl_Warna" runat="server" Text='<%#Eval("NamaWarna")%>'/></td>                    
                    <td style="width:4%; font-size:  small" valign="top"><asp:Label ID="Lbl_Rangka" runat="server" Text='<%#Eval("TYPESTOCK_NORANGKA")%>'/></td>
                    <td style="width:5%; font-size:  small" valign="top"><asp:Label ID="Lbl_SPK" runat="server" Text='<%#Eval("TYPESTOCK_NOSPK")%>'/></td>
                    <td style="width:5%; font-size:  small" valign="top"><asp:Label ID="Lbl_Faktur" runat="server" Text='<%#Eval("TYPESTOCK_NOSPKFAKTUR")%>'/></td>
                    <td style="width:8%; font-size:  small" valign="top"><asp:Label ID="Lbl_TglUnitTTK" runat="server" Text='<%#Format(Eval("TYPESTOCK_TGL"), "dd-MM-yy")%>'/></td>
                    <td style="width:8%; font-size:  small" valign="top"><asp:Label ID="Lbl_TglUnitTerima" runat="server" Text='<%#Eval("TYPESTOCK_TGLTERIMA")%>'/></td>
                    <td style="width:10%; font-size: small; text-align:right" valign="top"><asp:Label ID="Lbl_Note" runat="server" Text='<%#Eval("TYPESTOCK_CATATAN")%>'/></td>
                </tr>
        </ItemTemplate>
        <SelectedItemTemplate>
                <tr id="Tr1" runat="server" style="background-color:#ADD8E6">
                    <td>&nbsp;</td>
                    <td style="width:4%; font-size:  small" valign="top"><asp:Label ID="Lbl_Dealer" runat="server" Text='<%#Eval("TYPESTOCK_CDDEALER")%>'/></td>
                    <td style="width:4%; font-size:  small" valign="top"><asp:Label ID="Lbl_TipeGroup" runat="server" Text='<%#Eval("TYPE_CDGROUP")%>'/></td>
                    <td style="width:6%; font-size:  small" valign="top"><asp:Label ID="Lbl_TipeKode" runat="server" Text='<%#Eval("TYPE_TYPE")%>'/></td>
                    <td style="width:16%; font-size: small" valign="top"><asp:Label ID="Lbl_TipeNama" runat="server" Text='<%#Eval("mNamaTipe")%>'/></td>
                    <td style="width:14%; font-size: small" valign="top"><asp:Label ID="Lbl_Warna" runat="server" Text='<%#Eval("NamaWarna")%>'/></td>                    
                    <td style="width:4%; font-size:  small" valign="top"><asp:Label ID="Lbl_Rangka" runat="server" Text='<%#Eval("TYPESTOCK_NORANGKA")%>'/></td>
                    <td style="width:5%; font-size:  small" valign="top"><asp:Label ID="Lbl_SPK" runat="server" Text='<%#Eval("TYPESTOCK_NOSPK")%>'/></td>
                    <td style="width:5%; font-size:  small" valign="top"><asp:Label ID="Lbl_Faktur" runat="server" Text='<%#Eval("TYPESTOCK_NOSPKFAKTUR")%>'/></td>
                    <td style="width:8%; font-size:  small" valign="top"><asp:Label ID="Lbl_TglUnitTTK" runat="server" Text='<%#Format(Eval("TYPESTOCK_TGL"), "dd-MM-yy")%>'/></td>
                    <td style="width:8%; font-size:  small" valign="top"><asp:Label ID="Lbl_TglUnitTerima" runat="server" Text='<%#Eval("TYPESTOCK_TGLTERIMA")%>'/></td>
                    <td style="width:10%; font-size: small; text-align:right" valign="top"><asp:Label ID="Lbl_Note" runat="server" Text='<%#Eval("TYPESTOCK_CATATAN")%>'/></td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
    </asp:View>
    <asp:View ID="View3InTransit" runat="server">
        <div>
            <center>
                <h2 style="font-family:Cooper Black;">Laporan Intrasit (ada jadwal DO imora tapi unit belum terima)</h2>
            </center>
    	</div>  

        <asp:SqlDataSource ID="sdsTabelMasterAlokasi" runat="server" 
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
                SelectCommand="SELECT [STOCKDO_NORANGKA], [STOCKDO_KODEDLR], [STOCKDO_TGDOSPL], [STOCKDO_NODOSPL], [STOCKDO_TYPEDOSPL], [STOCKDO_WARNADOSPLDESC], [STOCKDO_NOTTK] FROM [TRXN_STOCKDO] WHERE ISNUMERIC(STOCKDO_NODOSPL)<>0 AND  (STOCKDO_NOTTK='' OR STOCKDO_NOTTK IS NULL) ORDER BY STOCKDO_KODEDLR,STOCKDO_TYPEDOSPL,STOCKDO_NORANGKA"                     
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                </asp:SqlDataSource>                 
        <asp:ListView ID="LVAlokasi" runat="server" DataSourceID="sdsTabelMasterAlokasi" DataKeyNames ="STOCKDO_NORANGKA">
                <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Silver; height:30px">
                      <th>Dealer</th><th>Rangka</th><th>Tipe</th><th>Warna</th><th>Tanggal Alokasi</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
                <asp:DataPager ID="dpalokasi" PageSize="200" runat="server" >
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
                    <td style="width:5%; font-size: small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("STOCKDO_KODEDLR") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:5%; font-size: small"><%#Eval("STOCKDO_NORANGKA")%></td>
                    <td style="width:15%; font-size: small"><%#Eval("STOCKDO_TYPEDOSPL")%></td>
                    <td style="width:15%; font-size: small"><%#Eval("STOCKDO_WARNADOSPLDESC")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("STOCKDO_TGDOSPL")%></td>
                </tr>
                </ItemTemplate>
                </asp:ListView>
    </asp:View>
    <asp:View ID="View4AmbilRangka" runat="server">
        <div>
            <center>
                <h2 style="font-family:Cooper Black;">Laporan Ambil Unit antar Dealer Mugen</h2>
            </center>
    	</div>  
        <asp:MultiView ID="MultiViewENTRY" runat="server" Visible="TRUE">
        <asp:View ID="ViewViewENTRYRequestDN" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px">Nomor Rangka Yang diinginkan</asp:Label>
                </td>
                <td style="width: 35%; ">
                    <asp:Label ID="LblNomorRangka" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px"></asp:Label>
                    <asp:Label ID="LblNoRequest" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px"></asp:Label>
                    
                </td>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px">Lokasi/Tahun Rangka</asp:Label>
                </td>
                <td style="width: 35%; ">
                    <asp:Label ID="LblLokasi" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text ="/"></asp:Label>
                    <asp:Label ID="LblTahun" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"></asp:Label>
                    <asp:Label ID="LblTahunNumerik" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label22" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Tipe</asp:Label>
                </td>
                <td style="width: 35%; ">
                    <asp:Label ID="LblTipeKode" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"></asp:Label>
                    <asp:Label ID="LblTipeNama" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"></asp:Label>
                </td>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Warna</asp:Label>
                </td>
                <td style="width: 35%; ">
                    <asp:Label ID="LblWarnaKode" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"></asp:Label>
                    <asp:Label ID="LblWarnaNama" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"></asp:Label>
                    <asp:Label ID="LblGroup" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"></asp:Label>
                    <asp:Label ID="LblKelompokTabel" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"></asp:Label>
                </td>
            </tr>
            </table> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label40" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Untuk SPK</asp:Label>
                </td>
                <td style="width: 85%; ">
                <asp:TextBox ID="TxtPemohonSPK" runat="server" Font-Names="Arial" Font-Size="Small" 
                        Width="13%" MaxLength="6" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label29" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Catatan Pemohon</asp:Label>
                </td>
                <td style="width: 85%; ">
                <asp:TextBox ID="TxtPemohonNote" runat="server" Font-Names="Arial" Font-Size="Small" Width="99%" MaxLength="50" TabIndex ="7" AutoPostBack="true"   ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Nomor Rangka Yang Disediakan</asp:Label>
                </td>
                <td style="width: 85%; ">
                    <asp:Label ID="LblNorangkaTersedia" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"></asp:Label>
                    <asp:Label ID="LblNorangkaTersediaDPP" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Visible="False"></asp:Label>
                    <asp:Label ID="LblNorangkaTersediaPPN" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Visible="False"></asp:Label>
                    <asp:Label ID="LblNorangkaTersediaDN" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Visible="False"></asp:Label>
                    <asp:Label ID="LblNorangkaTersediaTGLDN" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Visible="False"></asp:Label>
                    <asp:Label ID="LblNorangkaTersediaNOTTK" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" Visible="False"></asp:Label>
                </td>
            </tr>
        </table> 
            <br />
            <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%;  color: #FFFFFF;">
                        <asp:Button ID="BtnStockReq" runat="server" Text="Perbaharui Data Stok " Width="100%" 
                            Font-Size="Large" Height="27px" BackColor="Gray" />    
                </td>
                <td style="width: 25%;  color: #FFFFFF;">
                        <asp:Button ID="BtnPickupReq" runat="server" Text="Ambil Rangka" Width="100%" 
                            Font-Size="Large" Height="27px" BackColor="Gray" />    
                </td>
                <td style="width: 25%;  color: #FFFFFF;">
                        <asp:Button ID="BtnPickupSedia" runat="server" Text="Periksa ketersediaan stok" Width="100%" 
                            Font-Size="Large" Height="27px" BackColor="Gray" />    
                </td>
                <td style="width: 20%;  color: #FFFFFF;">
                        <asp:Button ID="BtnPickupTutup" runat="server" Text="Tutup form" Width="100%" 
                            Font-Size="Large" Height="27px" BackColor="Red" />    
                </td>
            </tr>
        </table>     
        <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 100%">
                    <asp:Label ID="LblWarningPickup1" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100%">
                    <asp:Label ID="LblWarningPickup2" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px"></asp:Label>
                </td>
            </tr>
            </table>    
            <br />
            <br />
            <br />
        
        </asp:View>        
        </asp:MultiView>
        <asp:SqlDataSource ID="SqlDataRequestSTok" runat="server" 
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
                SelectCommand="SELECT *, DATA_WARNA.WARNA_Int, DATA_TYPE.TYPE_Nama FROM TRXN_REQUESTSTOK LEFT OUTER JOIN DATA_WARNA ON TRXN_REQUESTSTOK.REQSTK_MHNCDWARNA = DATA_WARNA.WARNA_Kode LEFT OUTER JOIN DATA_TYPE ON TRXN_REQUESTSTOK.REQSTK_MHNCDTIPE = DATA_TYPE.TYPE_Type ORDER BY REQSTK_TGL DESC"                     
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                </asp:SqlDataSource>                 
        <asp:ListView ID="LvRequestSTok" runat="server" DataSourceID="SqlDataRequestSTok" DataKeyNames ="REQSTK_MHNDEALER">
                <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">

                    <thead style="background-color:Red  ; height:30px" >
                      <th>No Mohon</th><th>Tanggal</th><th>Pemohon</th><th>Dealer</th><th>No SPK</th><th>Note</th><th>Tipe</th><th>Warna</th><th>Rangka Dealer </th><th>Rangka</th><th>Tgl DN</th><th>No DN Asal</th><th>No TTK tujuan</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
                <asp:DataPager ID="dpalokasi" PageSize="200" runat="server" >
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
                    <td style="width:5%; font-size: small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("REQSTK_MHNDEALER") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:5%; font-size: small"><%#Eval("REQSTK_TGL")%></td>
                    <td style="width:15%; font-size: small"><%#Eval("REQSTK_MHNUSER")%></td>
                    <td style="width:4%; font-size: small"><%#Eval("REQSTK_MHNDEALER")%></td>
                    <td style="width:5%; font-size: small"><%#Eval("REQSTK_MHNNOSPK")%></td>
                    <td style="width:15%; font-size: small"><%#Eval("REQSTK_NOTE")%></td>

                    <td style="width:10%; font-size: small"><%#Eval("TYPE_Nama")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("WARNA_Int")%></td>
                                        
                    <td style="width:4%; font-size: small"><%#Eval("REQSTK_STJDEALER")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("REQSTK_STJNORANGKA")%></td>
                    <td style="width:8%; font-size: small"><%#Eval("REQSTK_DNTGL")%></td>
                    <td style="width:5%; font-size: small"><%#Eval("REQSTK_DN")%></td>
                    <td style="width:4%; font-size: small"><%#Eval("REQSTK_NOTTK")%></td>
                </tr>
                </ItemTemplate>
                </asp:ListView>
    </asp:View>


    </asp:MultiView>

</asp:Content>
