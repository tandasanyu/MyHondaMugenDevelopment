<%@ Page Language="VB" MasterPageFile ="~/MasterPage.master"  AutoEventWireup="false" CodeFile="Form0101ApprovalSPK.aspx.vb" Inherits="Default2" %>

<%@ MasterType virtualpath = "~/MasterPage.master"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    
    <div>
            <center>
                <h2 style="font-family:Cooper Black;">FORM PERSETUJUAN</h2>
            </center>
	</div>  
    <center>
    <p   style ="font-size: small" >
        &nbsp;User&nbsp; : 
        <asp:Label ID="LblUserName" runat="server"></asp:Label>
        <asp:Label ID="LblUserId" runat="server"></asp:Label>
        <asp:Label ID="lblAkses" runat="server"></asp:Label>
        &nbsp; Akses Dealer &nbsp; : 
        <asp:Label ID="lblArea1" runat="server"></asp:Label>
        <asp:Label ID="lblArea2" runat="server"></asp:Label>
        <asp:Label ID="LblTglSystem" runat="server"></asp:Label>
    </p>
            </center>
       
    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
    <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="95%">Error Message</asp:Label>
    </asp:View> 
    </asp:MultiView>

    <asp:MultiView ID="MultiView1" runat="server" Visible="TRUE">
    <asp:View ID="View15" runat="server">
    <asp:Label ID="Label45" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="95%">Error Message</asp:Label>
    </asp:View> 
    </asp:MultiView>



    <asp:MultiView ID="MultiView1a" runat="server" Visible="TRUE">
    <asp:View ID="View1" runat="server">
        
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 20%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label32" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px">Judul Permohonan</asp:Label>
                </td>
                <td style="width: 80%; ">
                    <asp:TextBox ID="TxtCariJudul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="95%" MaxLength="50" TabIndex ="7"  AutoPostBack="true" Text ="ENTRY"   ></asp:TextBox>
              </td>
            </tr>
            <tr>
                <td style="width: 20%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label22" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Kode SPV</asp:Label>
                </td>
                <td style="width: 80%; ">
                <asp:TextBox ID="TxtCariSPV" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="95%" MaxLength="3" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 20%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label29" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Nomor SPK</asp:Label>
                </td>
                <td style="width: 80%; ">
                <asp:TextBox ID="TxtCariNoSPK" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="95%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 20%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label40" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Posisi</asp:Label>
                </td>
                <td style="width: 80%; ">
                <asp:TextBox ID="TxtPosJab" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="12%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
                <asp:Label ID="Label41" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">[0]SPV [1]Sales Manager [2]Direktur [3]Vice Presiden [4]ADH 
                    [5]Accounting</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 20%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label39" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Kode Dealer</asp:Label>
                </td>
                <td style="width: 80%; ">
                <asp:TextBox ID="TxtDealerCD" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="6%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
                <asp:TextBox ID="TxtPosApv" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="6%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
                    <asp:Label ID="lblColomError" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </td>
            </tr>
        </table>     
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 20%; ">
                <asp:Button ID="Button8" runat="server" 
                        Text="HistoryChat" Width="90%" 
                    Font-Overline="False" Font-Size="Small" BackColor="#0033CC"   />    
                </td>
                <td style="width: 20%; ">
                <asp:Button ID="Button1" runat="server" 
                        Text="Klik untuk Persetujuan Data SPK" Width="90%" 
                    Font-Overline="False" Font-Size="Small" BackColor="#0033CC"   />    
                </td>
                <td style="width: 20%; ">
                <asp:Button ID="Button2" runat="server" 
                        Text="Klik untuk Persetujuan Data Aksesoris" Width="90%" 
                    Font-Overline="False" Font-Size="Small" BackColor="#0033CC"   />    
                </td>
                <td style="width: 20%; ">
                <asp:Button ID="Button7" runat="server" 
                        Text="Klik untuk Persetujuan Repair Unit" Width="90%" 
                    Font-Overline="False" Font-Size="Small" BackColor="#0033CC"   />    
                </td>
                <td style="width: 20%; ">
                    <asp:LinkButton ID="LinkButton1" PostBackUrl ="~/Form0102Aksesoris.aspx" 
                        runat="server" BackColor="Yellow" BorderStyle="Ridge" Width="90%">Permohonan Sales</asp:LinkButton>
                </td>
            </tr>
        </table>     
        <asp:MultiView ID="MultiView11a" runat="server" Visible="TRUE">
        <asp:View ID="View11a1" runat="server">        
        <asp:SqlDataSource ID="sdsTabelApv" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
            SelectCommand="SELECT TRXN_SPKAH.NOMOR_SPK, TRXN_SPKAH.JUDUL, TRXN_SPKAH.KETERANGAN, TRXN_SPKAH.TANGGAL_SETUJU, TRXN_SPKAH.TANGGAL_ENTRY, TRXN_SPKAH.TANGGAL_PROSES, TRXN_SPKAH.NOMOR_MOHON, TRXN_SPKAH.CABANG, TRXN_SPKAH.CATATAN, TRXN_SPKAH.STATUS, TRXN_SPKAH.APPROVALCODE, TRXN_SPKAH.NOMOR, TRXN_SPKAH.APPROVALCODEP, TRXN_SPKAH.RUPIAH, TRXN_SPKAH.CHANGE, TRXN_SPKAH.MYUSER, TRXN_SPKAH.MAIL, TRXN_SPKAH.CHANGE1, TRXN_SPKAH.CHANGE2, TRXN_SPKAH.CHANGE3, TRXN_SPKAH.SPV, TRXN_SPKAHERR.SPKAHERR_DESC, TRXN_SPKAHERR.SPKAHERR_DESCR 
                           FROM TRXN_SPKAH LEFT OUTER JOIN TRXN_SPKAHERR ON TRXN_SPKAH.NOMOR_MOHON = TRXN_SPKAHERR.SPKAHERR_NOM 
                           WHERE (NOT (TRXN_SPKAH.NOMOR_MOHON LIKE '%WB/APR/AS%')) AND (TRXN_SPKAH.JUDUL LIKE '%' + ? + '%') AND (TRXN_SPKAH.NOMOR_SPK LIKE '%' + ? + '%') AND (TRXN_SPKAH.CABANG LIKE '%' + ? + '%' OR TRXN_SPKAH.CABANG LIKE '%' + ? + '%') AND (TRXN_SPKAH.CABANG LIKE '%' + ? + '%') AND (TRXN_SPKAH.APPROVALCODE LIKE '%' + ? + '%') AND (TRXN_SPKAH.APPROVALCODEP LIKE '%' + ? + '%') AND (TRXN_SPKAH.SPV LIKE '%' + ? + '%') and (ISNULL(SPKAHERR_DESCR,'NULL') LIKE '%' + ? + '%') ORDER BY TRXN_SPKAH.CABANG, TRXN_SPKAH.NOMOR_SPK, TRXN_SPKAH.NOMOR_MOHON, TRXN_SPKAH.TANGGAL_PROSES"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCariJudul"  Name="JUDUL"        PropertyName="Text" Type="String" DefaultValue="%"/>            
                <asp:ControlParameter ControlID="TxtCariNoSPK"  Name="NOMOR_SPK"    PropertyName="Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="lblArea1"      Name="CABANG"       PropertyName= "Text" Type="String" DefaultValue="%"/>            
                <asp:ControlParameter ControlID="lblArea2"      Name="CABANG2"      PropertyName= "Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtDealerCD"   Name="CABANG3"      PropertyName= "Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="TxtPosJab"     Name="APPROVALCODE" PropertyName= "Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="TxtPosApv"     Name="APPROVALCODEP" PropertyName= "Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="TxtCariSPV"    Name="SPV"          PropertyName="Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="lblColomError" Name="SPKAHERR_DESCR"       PropertyName= "Text" Type="String" DefaultValue=""/>            
            </SelectParameters>
        </asp:SqlDataSource>                             
	<!-- Dataku  lvPersetujuan-->
        <asp:ListView ID="lvPersetujuan" runat="server" DataSourceID="sdsTabelApv"  
            DataKeyNames ="NOMOR_MOHON">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>Nomor</th><th>Tanggal Proses</th><th>SPK</th><th>Judul</th><th>Alasan</th><th>Tanggal Setuju</th><th>Pos #1</th><th>Pos #2</th><th>Dealer</th><th>SPV</th><th>User</th><th>Status</th><th>Catatan</th>
                </thead>
                <thead  style="background-color:Silver; height:30px "  >
                <th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th>Error</th>
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
                    <td rowspan="2" style="width:10%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("NOMOR_MOHON") %>' CommandName="Select" runat="server" />
                    </td>
                    <td rowspan="2" style="width:7%; font-size:x-small"><%#Eval("TANGGAL_PROSES")%></td>
                    <td rowspan="2" style="width:6%; font-size:x-small"><%#Eval("NOMOR_SPK")%></td>
                    <td rowspan="2" style="width:10%; font-size:x-small"><%#Eval("JUDUL")%></td>
                    <td rowspan="2" style="width:13%; font-size:x-small"><%#Eval("KETERANGAN")%></td>
                    <td rowspan="2" style="width:9%; font-size:x-small"><%#Eval("TANGGAL_SETUJU")%></td>
                    <td rowspan="2" style="width:4%; font-size:x-small"><%#Eval("APPROVALCODE")%></td>
                    <td rowspan="2" style="width:4%; font-size:x-small"><%#Eval("APPROVALCODEP")%></td>
                    <td rowspan="2" style="width:4%; font-size:x-small"><%#Eval("CABANG")%></td>
                    <td rowspan="2" style="width:3%; font-size:x-small"><%#Eval("SPV")%></td>
                    <td rowspan="2" style="width:4%; font-size:x-small"><%#Eval("MYUSER")%></td>
                    <td rowspan="2" style="width:4%; font-size:x-small"><%#Eval("STATUS")%></td>
                    <td style="width:22%; font-size:x-small"><%#Eval("CATATAN")%></td>
                </tr>
                
                <tr>
                    <td style="width:22%; font-size:x-small"><%#Eval("SPKAHERR_DESC")%><%#Eval("SPKAHERR_DESCR")%></td>                    
                </tr>

                
                
                
            </ItemTemplate>
        </asp:ListView>
        </asp:View> 
        
        <asp:View ID="View11a2" runat="server">
        <asp:SqlDataSource ID="sdsTabelApvAss0" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
            SelectCommand="SELECT TRXN_OPTPO.OPT_NODEALER, TRXN_OPTPO.OPT_USER, TRXN_OPTPO.OPT_TGL, TRXN_OPTPO.OPT_NOSPK, TRXN_OPTPO.OPT_TIPE, TRXN_OPTPO.OPT_CDASS, TRXN_OPTPO.OPT_STATUS, TRXN_OPTPO.OPT_HARGAJUAL, TRXN_OPTPO.OPT_HARGACUST, TRXN_OPTPO.OPT_KETERANGAN, TRXN_OPTPO.OPT_TGLAPPV1, TRXN_OPTPO.OPT_STATUSAPPV1, TRXN_OPTPO.OPT_CATATAN1, TRXN_OPTPO.OPT_TGLAPPV2, TRXN_OPTPO.OPT_STATUSAPPV2, TRXN_OPTPO.OPT_CATATAN2, TRXN_OPTPO.OPT_STATUSPROSES, TRXN_OPTPO.OPT_NOWO, TRXN_OPTPO.OPT_NOMORMOHON, TRXN_OPTPO.OPT_APPROVALCODE, TRXN_OPTPO.OPT_APPROVALCODEP, TRXN_OPTPO.OPT_SPV, TRXN_OPTPO.OPT_USERAPPV1, TRXN_OPTPO.OPT_USERAPPV2,TRXN_OPTPO.OPT_ERROR, TRXN_SPKAHERR.SPKAHERR_DESC, TRXN_SPKAHERR.SPKAHERR_DESCR, DATA_STANDARD.STANDARD_Nama 
                           FROM TRXN_OPTPO LEFT OUTER JOIN DATA_STANDARD ON TRXN_OPTPO.OPT_CDASS = DATA_STANDARD.STANDARD_Kode LEFT OUTER JOIN TRXN_SPKAHERR ON TRXN_OPTPO.OPT_NOMORMOHON = TRXN_SPKAHERR.SPKAHERR_NOM 
                           WHERE (TRXN_OPTPO.OPT_STATUSPROSES LIKE '%' + ? + '%') AND (TRXN_OPTPO.OPT_NOSPK LIKE '%' + ? + '%') AND (TRXN_OPTPO.OPT_NODEALER LIKE '%' + ? + '%' OR TRXN_OPTPO.OPT_NODEALER LIKE '%' + ? + '%' ) AND (TRXN_OPTPO.OPT_NODEALER LIKE '%' + ? + '%') AND (TRXN_OPTPO.OPT_APPROVALCODE LIKE '%' + ? + '%') AND (TRXN_OPTPO.OPT_APPROVALCODEP LIKE '%' + ? + '%') AND (TRXN_OPTPO.OPT_SPV LIKE '%' + ? + '%') AND (TRXN_OPTPO.OPT_STATUSAPPV2='' OR TRXN_OPTPO.OPT_STATUSAPPV2 IS NULL) AND (TRXN_OPTPO.OPT_NOWO='' OR TRXN_OPTPO.OPT_NOWO IS NULL) ORDER BY OPT_NODEALER,OPT_NOSPK" 
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCariJudul"  Name="OPT_STATUSPROSES" PropertyName="Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="TxtCariNoSPK"  Name="OPT_NOSPK"        PropertyName="Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="lblArea1"      Name="OPT_NODEALER"     PropertyName= "Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="lblArea2"      Name="OPT_NODEALER2"    PropertyName= "Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="TxtDealerCD"   Name="OPT_NODEALER3"    PropertyName= "Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="TxtPosJab"     Name="OPT_APPROVALCODE" PropertyName= "Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="TxtPosApv"     Name="OPT_APPROVALCODEP" PropertyName= "Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="LblUserId"    Name="OPT_SPV"          PropertyName="Text" Type="String" DefaultValue="%"  />            
            </SelectParameters>


        </asp:SqlDataSource>                     
	<!-- Dataku  LVPersetujuanAsesoris-->
        <asp:ListView ID="LVPersetujuanAsesoris" runat="server" DataSourceID="sdsTabelApvAss0"  
            DataKeyNames ="OPT_NOMORMOHON">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver ; height:30px" >
                <th>Nomor</th><th>Dealer</th><th>User</th><th>Tanggal</th><th>SPK</th>
                <th>Asesoris</th><th>Sts</th><th>Jual</th><th>Ps#1</th>
                <th>Sts Stj#1</th><th>User Stj#1</th>
                <th>Status</th><th>Catatan</th>
                </thead>

                <thead  style="background-color:Silver ; height:30px" >
                <th>Nomor</th><th>Dealer</th><th>SPV</th><th></th><th>Kode</th>
                <th></th><th></th><th></th><th>Ps#2</th>
                <th>Sts Stj#2</th><th>User Stj#2</th>
                <th>Status</th><th>Error</th>
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
                    <td rowspan="2"  style="width:10%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("OPT_NOMORMOHON") %>' CommandName="Select" runat="server" />
                    </td>
                    <td rowspan="2"  style="width:5%; font-size:x-small"><%#Eval("OPT_NODEALER")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("OPT_USER")%></td>
                    <td rowspan="2"  style="width:7%; font-size:x-small"><%#Format(Eval("OPT_TGL"), "dd-MM-yy HH:MM")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("OPT_NOSPK")%></td>
                    <td rowspan="2"  style="width:10%; font-size:x-small"><%#Eval("STANDARD_Nama")%></td>
                    <td rowspan="2"  style="width:5%; font-size:x-small"><%#Eval("OPT_STATUS")%></td>
                    <td rowspan="2"  style="width:6%; font-size:x-small"><%#Eval("OPT_HARGACUST")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("OPT_APPROVALCODE")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("OPT_STATUSAPPV1")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("OPT_USERAPPV1")%></td>
                    <td rowspan="2"  style="width:6%; font-size:x-small"><%#Eval("OPT_STATUSPROSES")%></td>
                    <td style="width:26%; font-size:x-small"><%#Eval("OPT_ERROR")%><%#Eval("SPKAHERR_DESC")%><%#Eval("SPKAHERR_DESCR")%></td>                    
                </tr>

                <tr>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_SPV")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_CDASS")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_APPROVALCODEP")%></td>                    
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_STATUSAPPV2")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_USERAPPV2")%></td>                    
                    <td style="width:10%; font-size:x-small"><%#Eval("OPT_ERROR")%><%#Eval("SPKAHERR_DESC")%><%#Eval("SPKAHERR_DESCR")%></td>                    
                </tr>



            </ItemTemplate>
        </asp:ListView>
        </asp:View> 

        <asp:View ID="View11a3" runat="server">        
        <asp:SqlDataSource ID="sdsTabelWH" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
            SelectCommand="SELECT ASSREPAIR_NORANGKA,LOKASI_KODEDLR,ASSREPAIR_TGLINPUT,ASSREPAIR_KODEDLR,ASSREPAIR_KETERANGAN,ASSREPAIR_KDASS,ASSREPAIR_HARGA,ASSREPAIR_RINCIAN FROM TRXN_STOCKAREPAIR,TRXN_STOCK,DATA_LOKASI WHERE ASSREPAIR_NORANGKA=STOCK_NORANGKA  AND STOCK_CDLOKASI=LOKASI_KODE AND (ASSREPAIR_TGLEMAIL IS NOT NULL AND (ASSREPAIR_NOSETUJU='' OR ASSREPAIR_NOSETUJU IS NULL) AND ASSREPAIR_TGLWO IS NULL) AND (DATA_LOKASI.LOKASI_KODEDLR LIKE '%' + ? + '%') ORDER BY ASSREPAIR_TGLINPUT"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblArea1"      Name="LOKASI_KODEDLR"     PropertyName= "Text" Type="String" />            
            </SelectParameters>
            
        </asp:SqlDataSource>                             
	<!-- Dataku  LVRepairWH-->
        <asp:ListView ID="LVRepairWH" runat="server" DataSourceID="sdsTabelWH"  
            DataKeyNames ="ASSREPAIR_NORANGKA">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>No Rangka</th><th>Dlr</th><th>Tanggal Mohon</th><th>Bengkel</th><th>Tanggungan</th><th>Kode As</th><th>Harga</th><th>Perbaikan</th>
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
                    <td style="width:11%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("ASSREPAIR_NORANGKA") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:5%; font-size:x-small; "><%#Eval("LOKASI_KODEDLR")%></td>
                    <td style="width:10%; font-size:x-small; "><%#Eval("ASSREPAIR_TGLINPUT")%></td>
                    <td style="width:7%; font-size:x-small"><%#Eval("ASSREPAIR_KODEDLR")%></td>
                    <td style="width:11%; font-size:x-small"><%#Eval("ASSREPAIR_KETERANGAN")%></td>
                    <td style="width:7%; font-size:x-small"><%#Eval("ASSREPAIR_KDASS")%></td>
                    <td style="width:9%; font-size:x-small"><%#Eval("ASSREPAIR_HARGA")%></td>
                    <td style="width:40%; font-size:x-small"><%#Eval("ASSREPAIR_RINCIAN")%></td>


                </tr>
            </ItemTemplate>
        </asp:ListView>
        </asp:View> 
        
        
        </asp:MultiView>

    </asp:View>
    <asp:View ID="View2" runat="server">
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
                <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Nomor SPK" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblNoSPK" runat="server" Text=""></asp:Label>
                    <asp:Label ID="LblNoSPK_KhususVA" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Dealer / Nomor / Posisi" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="lblDealer" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblNomorSetuju" runat="server"></asp:Label>
                    <asp:Label ID="lblPosSetuju" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                   <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal Input HMS [YYYY-MM-DD]" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblTglMHS" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal DO [YYYY-MM-DD]" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblTglDO" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                   <asp:Label ID="Label77" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal Buat SPK [YYYY-MM-DD]" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblTglCreateSPK" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label86" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal Setuju SM [YYYY-MM-DD]" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblTglSetujuSM" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            
            </table>   
        <div>
            <center>
                    <asp:Button ID="ButtonDataSPKPErmohonan" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Klik disin untuk melihat data SPK ketika data diajukan permohonan" 
                         />
            </center>
	    </div>  
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Data Pelanggan</h2>
            </center>
	    </div>  
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama SPK" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="LblNama" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama Sales" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF;">
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
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Data Kendaraan</h2>
            </center>
	    </div>  
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tipe" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblCdType" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblTipe" runat="server" Text="" ForeColor="Black"></asp:Label>
                    <asp:Label ID="lblGroupTipe" runat="server" ForeColor="Black" Text=""></asp:Label>
                </td>
                <td style="width: 25%; ">
                   <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Warna"  ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="lblWarna" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Rangka" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="lblNorangka" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tahun / Road" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%;background-color:Yellow;  color: #FFFFFF;">
                    <asp:Label ID="lblTahun" runat="server" ForeColor="Black"></asp:Label>
                    <asp:Label ID="lblRoad" runat="server" ForeColor="Black"></asp:Label>
                </td>
            </tr>
        </table>


        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Data H-Diary</h2>
            </center>
	    </div>  
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label136" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama Pemesan" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblHDiaryNama" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="Label138" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Catatan" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%;">
                    <asp:Label ID="LblHDiaryNote" runat="server" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label126" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jenis Pembayaran" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblHDiaryJenisByr" runat="server" ForeColor="Black" Text=""></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                   <asp:Label ID="Label133" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Asuransi"  ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblHDiaryAsuransi" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label130" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Aksesoris" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblHDiaryAksesoris" runat="server" ForeColor="Black" Text=""></asp:Label>
                </td>
                <td style="width: 25%; ">
                   <asp:Label ID="Label135" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Paket"  ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblHDiaryPaket" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label128" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblHDiaryHarga" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label139" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Potongan" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%;background-color:#CCCCFF;">
                    <asp:Label ID="LblHDiaryDisc" runat="server" ForeColor="Black"></asp:Label>
                </td>
            </tr>
        </table>
        
        
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Harga Jual</h2>
            </center>
	    </div>  
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
        </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Harga" ForeColor="Black"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblHarga" runat="server" Text=""></asp:Label>
                </td>
                
                <td style="width: 25%;background-color:Yellow;  color: #FFFFFF;">
                    <asp:Label ID="Label26" runat="server" Font-Names="Arial" Font-Size="Small" 
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
                    <asp:Label ID="Label100" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Selisih Harga beda tahun" ForeColor="Black"></asp:Label>
                    &nbsp;</td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblBedathn" runat="server" Text=""></asp:Label>
                </td>
            </tr>


            
            <tr>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label14" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Potongan" ForeColor="Black"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblDisc" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 25%; background-color: #FF0000;  color: #FFFFFF;">
                    <asp:Label ID="Label81" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Maksimum Potongan ?"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblMaxDisc" runat="server" Text=""></asp:Label>
            </td>
            </tr>
            
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label71" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Subsidi"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblSubsidi" runat="server" Text="" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color: #FF0000;  color: #FFFFFF;">
               <asp:Label ID="Label72" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Status Diskon" ForeColor="Black"></asp:Label> </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblNoteDiskon" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label76" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Komisi"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblKomisi" runat="server" Text="" ForeColor="Black"></asp:Label>
            </td>
            <td style="width: 25%; color: #FFFFFF;">
               
            </td>
            <td style="width: 25%;background-color:#CCCCFF;">
                <asp:Label ID="LblsetujuDiskon" runat="server"></asp:Label>
            </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total" ForeColor="Black"></asp:Label>     
                </td>
                <td style="width: 25%; ">
                <asp:Label ID="LblTotal" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; background-color: #FF0000;  color: #FFFFFF;">
                <asp:Label ID="Label105" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Keharusan Uang Muka" ForeColor="White"></asp:Label>     
                </td>
                <td style="width: 25%; ">
                <asp:Label ID="LblUangMuka" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Cara Bayar</h2>
            </center>
	    </div>  
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">

            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jenis Pembayaran" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblJns" runat="server" Text=""></asp:Label>
                    <asp:Label ID="LblJns0" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tenor" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="lblTnr" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
            <td style="width: 25%; ">
               <asp:Label ID="Label16" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total Bayar"></asp:Label>
            </td>
            <td style="width: 25%; ">
                <asp:Label ID="LblBayar" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 25%; ">
               <asp:Label ID="Label17" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total Piutang"></asp:Label>
            </td>
            <td style="width: 25%; ">
                <asp:Label ID="LblSisa" runat="server" Text=""></asp:Label>
            </td>
            </tr>
            </table>
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Informasi Tambahan</h2>
            </center>
	    </div>  
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 25%; background-color:#CCCCFF;">
               <asp:Label ID="Label20" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Data SPK [YYYY-MM-DD]"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="LblMohon" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
               <asp:Label ID="Label23" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Setuju [YYYY-MM-DD]"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="lblSetuju" runat="server" Text=""></asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 25%; ">
               <asp:Label ID="LblCustKirim" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Kirim Customer [YYYY-MM-DD]"></asp:Label>
            </td>
            <td style="width: 25%; ">
                <asp:Label ID="LblKirimCustomer" runat="server"></asp:Label>
            </td>
            <td style="width: 25%; ">
               <asp:Label ID="LblCustTerima" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Terima Customer [YYYY-MM-DD]"></asp:Label>
            </td>
            <td style="width: 25%; ">
                <asp:Label ID="LblTerimaCustomer" runat="server"></asp:Label>
            </td>
            </tr>
        </table>

        <asp:MultiView ID="MultiViewPindahDana" runat="server" Visible="TRUE">
        <asp:View ID="ViewPindahDana" runat="server">
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Informasi Pindah Dana</h2>
            </center>
	    </div>  
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 40%; background-color:#CCCCFF;">
               <asp:Label ID="Label103" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tipe"></asp:Label>
            </td>
            <td style="width: 10%; background-color:#CCCCFF;">
               <asp:Label ID="Label104" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Asal"></asp:Label>
            </td>
            <td style="width: 40%; background-color:#CCCCFF;">
               <asp:Label ID="Label134" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama Kwitansi"></asp:Label>
            </td>
            <td style="width: 10%; background-color:#CCCCFF;">
               <asp:Label ID="Label107" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tujuan"></asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 40%; background-color:#CCCCFF;">
               <asp:Label ID="LblPindahDanaTipe" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tipe"></asp:Label>
            </td>
            <td style="width: 10%; background-color:#CCCCFF;">
               <asp:Label ID="LblPindahDanaSPKAsal" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Asal"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
               <asp:Label ID="LblPindahDanaSPKNama" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama Kwitansi"></asp:Label>
            </td>
            <td style="width: 15%; background-color:#CCCCFF;">
               <asp:Label ID="LblPindahDanaSPKJuml" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nama Kwitansi"></asp:Label>
            </td>
            <td style="width: 10%; background-color:#CCCCFF;">
               <asp:Label ID="LblPindahDanaSPKTuju" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tujuan"></asp:Label>
            </td>
            </tr>
        </table>

        
	    
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
        </asp:View>
        </asp:MultiView>

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 50%; ">
                <asp:Button ID="Button6" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" 
                    Font-Underline="True" ForeColor="Red" Text="Klik untuk Update Data SPK" 
                    Width="372px" Visible="False" />
            </td>
            <td style="width: 50%; ">
                <asp:Label ID="LblStatusUpdateSPK" runat="server" Font-Names="Arial" 
                    Font-Size="Small" height="21px" Text="Status Update SPK" Font-Bold="True" 
                    Font-Strikeout="False" Width="483px"></asp:Label>
            </td>
            </tr>
        </table>
        
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
           <tr>
           <td style="width: 100%; background-color: #FF0000;  color: #FFFFFF;">
           <asp:Label ID="LblWarning" runat="server" Font-Names="Arial" Font-Size="Small" 
                   height= "21px" Width="90%"></asp:Label>
           </td>
           </tr>
           <tr>
           <td style="width: 100%; background-color: #FF0000;  color: #FFFFFF;">
           <asp:Label ID="LblBlockPesan" runat="server" Font-Names="Arial" Font-Size="Small" Text=""></asp:Label>
           </td>
           </tr>
           <tr>
           <td style="width: 100%; background-color: #FF0000;  color: #FFFFFF;">
           <asp:Label ID="LblBlockPesanR" runat="server" Font-Names="Arial" Font-Size="Small" Text=""></asp:Label>
           </td>
           </tr>
           <tr>
           <td style="width: 100%; background-color: #FF0000;  color: #FFFFFF;">
           <asp:Label ID="LblBlockPesanC" runat="server" Font-Names="Arial" Font-Size="Small" Text=""></asp:Label>
           </td>
           </tr>
        </table>

        
       <asp:MultiView ID="MultiViewENTRY" runat="server" Visible="TRUE">
           <asp:View ID="ViewViewENTRY1" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 15%; background-color: #808080;  color: #FFFFFF;">
                    <asp:Label ID="Label58" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Mohon/#Po1/#Pos2"></asp:Label>
                </td>
                <td style="width: 25%; background-color: #808080;  color: #FFFFFF;">
                    <asp:Label ID="Label60" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Judul"></asp:Label>
                </td>
                <td style="width: 26%; background-color: #808080;  color: #FFFFFF;">
                    <asp:Label ID="Label62" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Alasan"></asp:Label>
                </td>
                <td style="width: 8%; background-color: #808080;  color: #FFFFFF;">
                    <asp:Label ID="Label64" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nilai"></asp:Label>
                </td>

                <td style="width: 8%; background-color: #808080;  color: #FFFFFF;">
                    <asp:Label ID="Label66" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal"></asp:Label>
                </td>
                <td style="width: 8%; background-color: #808080;  color: #FFFFFF;">
                    <asp:Label ID="Label69" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="User"></asp:Label>
                </td>
                <td style="width: 10%; background-color: #808080;  color: #FFFFFF;">
                    <asp:Label ID="Label70" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Status"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl01Mhn" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px"></asp:Label>
                    <asp:Label ID="Label98" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl01Apv" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px"></asp:Label>
                    <asp:Label ID="Label108" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl01ApvP" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl01Judul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl01Alasan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl01Nilai" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                <div id="tanggalPopup">
                    <asp:Label ID="Lbl01Tanggal" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                    <asp:Label ID="Lbl01Nomor" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </div>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl01User" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:CheckBox ID="ChkBox1" runat="server" Text="Ok" Font-Size="Small" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl02Mhn" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                    <asp:Label ID="Label109" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl02Apv" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                    <asp:Label ID="Label110" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl02ApvP" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl02Judul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl02Alasan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl02Nilai" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                <div id="Div1">
                    <asp:Label ID="Lbl02Tanggal" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="16px"></asp:Label>
                    <asp:Label ID="Lbl02Nomor" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </div>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl02User" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:CheckBox ID="ChkBox2" runat="server" Text="Ok" Font-Size="Small"  />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl03Mhn" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                    <asp:Label ID="Label111" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl03Apv" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                    <asp:Label ID="Label112" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl03ApvP" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl03Judul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl03Alasan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl03Nilai" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                <div id="Div2">
                    <asp:Label ID="Lbl03Tanggal" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                    <asp:Label ID="Lbl03Nomor" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </div>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl03User" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:CheckBox ID="ChkBox3" runat="server" Text="Ok" Font-Size="Small" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl04Mhn" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                     <asp:Label ID="Label113" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                   <asp:Label ID="Lbl04Apv" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                    <asp:Label ID="Label114" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl04ApvP" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl04Judul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl04Alasan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl04Nilai" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                <div id="Div3">
                    <asp:Label ID="Lbl04Tanggal" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                    <asp:Label ID="Lbl04Nomor" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </div>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl04User" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:CheckBox ID="ChkBox4" runat="server" Text="Ok" Font-Size="Small"  />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl05Mhn" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                    <asp:Label ID="Label115" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl05Apv" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                    <asp:Label ID="Label116" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl05ApvP" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl05Judul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl05Alasan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl05Nilai" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                <div id="Div4">
                    <asp:Label ID="Lbl05Tanggal" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="16px"></asp:Label>
                    <asp:Label ID="Lbl05Nomor" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </div>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl05User" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:CheckBox ID="ChkBox5" runat="server" Text="Ok" Font-Size="Small"  />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl06Mhn" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                    <asp:Label ID="Label117" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl06Apv" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                    <asp:Label ID="Label118" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl06ApvP" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl06Judul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl06Alasan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl06Nilai" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                <div id="Div5">
                    <asp:Label ID="Lbl06Tanggal" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="16px"></asp:Label>
                    <asp:Label ID="Lbl06Nomor" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </div>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl06User" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:CheckBox ID="ChkBox6" runat="server" Text="Ok" Font-Size="Small"  />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl07Mhn" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                    <asp:Label ID="Label119" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl07Apv" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                    <asp:Label ID="Label120" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl07ApvP" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl07Judul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl07Alasan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl07Nilai" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                <div id="Div6">
                    <asp:Label ID="Lbl07Tanggal" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="16px"></asp:Label>
                    <asp:Label ID="Lbl07Nomor" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </div>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl07User" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:CheckBox ID="ChkBox7" runat="server" Text="Ok" Font-Size="Small"  />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl08Mhn" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                    <asp:Label ID="Label121" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl08Apv" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                    <asp:Label ID="Label122" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl08ApvP" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl08Judul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl08Alasan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl08Nilai" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                <div id="Div7">
                    <asp:Label ID="Lbl08Tanggal" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="16px"></asp:Label>
                    <asp:Label ID="Lbl08Nomor" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </div>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl08User" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:CheckBox ID="ChkBox8" runat="server" Text="Ok" Font-Size="Small"  />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl09Mhn" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                    <asp:Label ID="Label124" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl09Apv" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                    <asp:Label ID="Label125" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl09ApvP" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl09Judul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl09Alasan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl09Nilai" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                <div id="Div8">
                    <asp:Label ID="Lbl09Tanggal" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="16px"></asp:Label>
                    <asp:Label ID="Lbl09Nomor" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </div>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl09User" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:CheckBox ID="ChkBox9" runat="server" Text="Ok" Font-Size="Small"  />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl10Mhn" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                    <asp:Label ID="Label127" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl10Apv" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                    <asp:Label ID="Label129" runat="server" Font-Names="Arial" Font-Size="Small" height= "16px">/</asp:Label>
                    <asp:Label ID="Lbl10ApvP" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl10Judul" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl10Alasan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl10Nilai" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px"></asp:Label>
                </td>
                <td style="width: 15%;">
                <div id="Div9">
                    <asp:Label ID="Lbl10Tanggal" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="16px"></asp:Label>
                    <asp:Label ID="Lbl10Nomor" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="16px"></asp:Label>
                </div>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl10User" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="16px"></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:CheckBox ID="ChkBox10" runat="server" Text="Ok" Font-Size="Small"  />
                </td>
            </tr>
        </table>

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr> 
                <td style="width: 100%; height: 26px;">
                    <asp:Label ID="Label73" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "33px" 
                        
                        Text="Catatan : Pilih persetujuan/penolokan pada kolom paling kanan ( jika diberi tanda berarti sudah kepilih jika tandanya dihilangkan berarti tidak terpilih), Untuk melihat keberhasilan rubah datanya lihat di kolom paling kanan ada tulisan SETUJU/TOLAK" 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
        </table>
           </asp:View>

       <asp:View ID="ViewViewENTRY2" runat="server">
           
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Detail Permohonan</h2>
            </center>
	    </div>  
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 25%;background-color:#CCCCFF;" >
               <asp:Label ID="Label87" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Mohon"></asp:Label>
            </td>
            <td style="width: 75%;background-color:#CCCCFF;">
                <asp:Label ID="lblPolcyNomorMohon" runat="server"></asp:Label>
                <asp:Label ID="LblResultIdMohon" runat="server"></asp:Label>
                <asp:Label ID="LblResultNomor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
            <td style="width: 25%;">
               <asp:Label ID="Label89" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Judul"></asp:Label>
            </td>
            <td style="width: 75%;">
                <asp:Label ID="lblPolcyJudul" runat="server"></asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 25%;background-color:#CCCCFF;" >
               <asp:Label ID="Label95" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Alasan"></asp:Label>
            </td>
            <td style="width: 75%;background-color:#CCCCFF;" >
                <asp:Label ID="lblPolcyAlasan" runat="server"></asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 25%; " >
               <asp:Label ID="Label97" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Mohon"></asp:Label>
            </td>
            <td style="width: 75%;" >
                <asp:Label ID="lblPolcyTanggal" runat="server"></asp:Label>
                <asp:Label ID="LblResultTglDisetujui" runat="server"></asp:Label>
                <asp:Label ID="LblResultTglAmbilData" runat="server"></asp:Label>
                <asp:Label ID="LblResultPosSetujuCurrent" runat="server"></asp:Label>
                <asp:Label ID="LblResultPosSetuju" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
            <td style="width: 25%;background-color:#CCCCFF;" >
               <asp:Label ID="Label99" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="User"></asp:Label>
            </td>
            <td style="width: 75%;background-color:#CCCCFF;" >
                <asp:Label ID="lblPolcyUser" runat="server"></asp:Label>
                <asp:Label ID="LblResultKeputusan" runat="server"></asp:Label>
                <asp:Label ID="LblResultAlasan" runat="server"></asp:Label>
                <asp:Label ID="LblResultCatatanKeputusan" runat="server"></asp:Label>
            </td>
            </tr>
            </table>
            
        <asp:MultiView ID="MultiViewRubahHarga" runat="server" Visible="TRUE">
        <asp:View ID="View6" runat="server">
           <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">

           <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label18" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=" "></asp:Label>
                </td>
                <td style="width: 35%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label56" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Perubahan"></asp:Label>
                </td>
                <td style="width: 20%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label68" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Yang DiSetujui"></asp:Label>
                </td>
                <td style="width: 20%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label38" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="SPK HMS"></asp:Label>
                </td>
           </tr>

           <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label50" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Disetuju Tahun"></asp:Label>
                    &nbsp;</td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtDisetujuiTahun" runat="server" text="" Width="30%" 
                        MaxLength="2" AutoPostBack="true"  ></asp:TextBox>
                    <asp:CompareValidator ID="ChkTxtDisetujuiTahun" runat ="server"  
                      ErrorMessage ="harus numerik dua digit" ControlToValidate="TxtDisetujuiTahun" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 20%; ">
                    <asp:Label ID="lblPerubahanTahun" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="16" Width="95%" 
                        style="text-align: right"></asp:Label>
                </td>
                <td style="width: 20%; ">
                    <asp:Label ID="lblPengajuanTahun" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="16" Width="95%" 
                        style="text-align: right"></asp:Label>
                </td>
           </tr>


           <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label74" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Disetuju Harga Unit"></asp:Label>
                    &nbsp;</td>
                <td style="width: 35%; ">
                    <asp:Label ID="lblDisetujuiHrgUnit" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="" Width="30%"></asp:Label>
                    <asp:Label ID="TxtDisetujuiHrgDisc0" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px" Visible="False" Width="30%"></asp:Label>
                </td>
                <td style="width: 20%; ">
                    <asp:Label ID="LblPerubahanHargaUnit" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="16" Width="95%" 
                        style="text-align: right"></asp:Label>
                </td>
                <td style="width: 20%; ">
                    <asp:Label ID="LblPengajuanHargaUnit" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="0" Width="95%" 
                        style="text-align: right"></asp:Label>
                </td>
           </tr>
           <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label75" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Disetuju Harga Potongan"></asp:Label>
                    &nbsp;</td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtDisetujuiHrgDisc" runat="server" text="" Width="30%" AutoPostBack="true" ></asp:TextBox>
                    <asp:CompareValidator ID="ChkTxtDisetujuiHrgDisc" runat ="server"  
                      ErrorMessage ="Harus numerik tanpa koma atau titik" ControlToValidate="TxtDisetujuiHrgDisc" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 20%; ">
                    <asp:Label ID="LblPerubahanHargaDisc" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="16" Width="95%" 
                        style="text-align: right"></asp:Label>
                </td>
                <td style="width: 20%; ">
                    <asp:Label ID="LblPengajuanHargaDisc" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="0" Width="95%" 
                        style="text-align: right"></asp:Label>
                </td>
           </tr>
           <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label79" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Disetuju Harga Subsidi"></asp:Label>
                </td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtDisetujuiHrgSubs" runat="server" text="" Width="30%" AutoPostBack="true"></asp:TextBox>
                    <asp:CompareValidator ID="ChkTxtDisetujuiHrgSubs" runat ="server"  
                      ErrorMessage ="Harus numerik tanpa koma atau titik" ControlToValidate="TxtDisetujuiHrgSubs" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 20%; ">
                    <asp:Label ID="LblPerubahanHargaSubs" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="16" Width="95%" 
                        style="text-align: right"></asp:Label>
                </td>
                <td style="width: 20%; ">
                    <asp:Label ID="LblPengajuanHargaSubs" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="0" Width="95%" 
                        style="text-align: right"></asp:Label>
                </td>
           </tr>
           <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label84" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Disetuju Harga Komisi"></asp:Label>
                    &nbsp;</td>
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtDisetujuiHrgKoms" runat="server" text="" Width="30%" AutoPostBack="true" ></asp:TextBox>
                    <asp:CompareValidator ID="ChkTxtDisetujuiHrgKoms" runat ="server"  
                      ErrorMessage ="Harus numerik tanpa koma atau titik" ControlToValidate="TxtDisetujuiHrgKoms" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 20%; ">
                    <asp:Label ID="LblPerubahanHargaKoms" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="16" Width="95%" 
                        style="text-align: right"></asp:Label>
                </td>
                <td style="width: 20%; ">
                    <asp:Label ID="LblPengajuanHargaKoms" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="0" Width="95%" 
                        style="text-align: right"></asp:Label>
                </td>
           </tr>
           <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label52" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Perhitungan Diskon"></asp:Label>
                    &nbsp;</td>
                <td style="width: 35%; ">
                    <asp:Label ID="LblTotalSetuju" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total" Width="30%" Visible="False"></asp:Label>
                </td>
                <td style="width: 20%; ">
                    <asp:Label ID="LblTotalPerubahan" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="0" Width="95%" BorderColor="#00FF80" 
                        style="text-align: right"></asp:Label>
                </td>
                <td style="width: 20%; ">
                    <asp:Label ID="LblTotalPengajuan" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "21px" Text="0" Width="95%" 
                        style="text-align: right"></asp:Label>
                    </td>
           </tr>
           </table>
           
        <asp:MultiView ID="MultiViewHistoryChat" runat="server" Visible="TRUE">
        <asp:View ID="View9" runat="server">
           <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
           <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label92" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Nomor History Percakapan (Belum Selesai)"></asp:Label>
                    &nbsp;</td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtNoChat" runat="server" AutoPostBack="true" text="" 
                        Width="30%"></asp:TextBox>
                    <asp:Button ID="Button12" runat="server" Text="Simpan" Width="56px" />
                    <asp:Button ID="Button13" runat="server" Text="Cari" Width="56px" />
                </td>
           </tr>
           <tr>
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%; ">
        <asp:SqlDataSource ID="SqlDataSource2" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
            SelectCommand="SELECT ASSREPAIR_NORANGKA,LOKASI_KODEDLR,ASSREPAIR_TGLINPUT,ASSREPAIR_KODEDLR,ASSREPAIR_KETERANGAN,ASSREPAIR_KDASS,ASSREPAIR_HARGA,ASSREPAIR_RINCIAN FROM TRXN_STOCKAREPAIR,TRXN_STOCK,DATA_LOKASI WHERE ASSREPAIR_NORANGKA=STOCK_NORANGKA  AND STOCK_CDLOKASI=LOKASI_KODE AND (ASSREPAIR_TGLEMAIL IS NOT NULL AND (ASSREPAIR_NOSETUJU='' OR ASSREPAIR_NOSETUJU IS NULL) AND ASSREPAIR_TGLWO IS NULL) AND (DATA_LOKASI.LOKASI_KODEDLR LIKE '%' + ? + '%')"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblArea1"      Name="LOKASI_KODEDLR"     PropertyName= "Text" Type="String" />            
            </SelectParameters>
            
        </asp:SqlDataSource>                             
	<!-- Dataku  ListView2-->
        <asp:ListView ID="ListView2" runat="server" DataSourceID="sdsTabelWH"  
            DataKeyNames ="ASSREPAIR_NORANGKA">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>Tanggal</th><th>Nomor</th><th>User</th><th>Chat</th>
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
                    <td style="width:10%; font-size:x-small; "><%#Eval("LOKASI_KODEDLR")%></td>
                    <td style="width:10%; font-size:x-small; "><%#Eval("ASSREPAIR_TGLINPUT")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("ASSREPAIR_KODEDLR")%></td>
                    <td style="width:70%; font-size:x-small"><%#Eval("ASSREPAIR_KETERANGAN")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

                </td>
           </tr>
           </table>
        </asp:View>         
        </asp:MultiView> 
        
        </asp:View>         
        </asp:MultiView> 

        <asp:MultiView ID="MultiViewSetujuRangka" runat="server" Visible="TRUE">
        <asp:View ID="View11" runat="server">
           <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
           <tr>
                <td style="width: 25%; background-color: #FF0000;  color: #FFFFFF;">
                    <asp:Label ID="Label132" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Customer tunai ambil asuransi"></asp:Label>
                </td>
                    
                <td style="width: 75%; ">
                    <asp:Label ID="LblNoteAsuransi" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
           </tr>
          </table>

           <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
           <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label82" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Rangka Pengajuan DO"></asp:Label></td>
                    
                <td style="width: 35%; ">
                    <asp:TextBox ID="TxtDisetujuiNoRangka" runat="server" text="" Width="204px"></asp:TextBox>
                    <asp:Button ID="ButtonSimpan1" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" Text="Cari (Isi % Semua tampil)"  />
                </td>
                <td style="width: 40%; ">
                    <asp:Label ID="lblDisetujuiNoRangka" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Width="200px"></asp:Label>
                    <asp:Label ID="lblDisetujuiNoRangkaTmp" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Width="200px" Visible="False"></asp:Label>
                    <asp:Button ID="Button14" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" Text="Rubah Rangka"  />
                </td>
           </tr>
          </table>
          
            <asp:SqlDataSource ID="SdsDataStockDetail" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM DATA_TYPESTOCK,DATA_TYPE,DATA_WARNA WHERE TYPESTOCK_CDTYPE=TYPE_TYPE AND TYPESTOCK_CDWARNA=WARNA_KODE AND [TYPESTOCK_CDDEALER] LIKE '%' + ? + '%' AND [TYPESTOCK_NORANGKA] LIKE '%' + ? + '%' AND [TYPESTOCK_CDTYPE] LIKE '%' + ? + '%' AND [WARNA_int] LIKE '%' + ? + '%' ORDER BY TYPESTOCK_CDDEALER,TYPE_CdGroup,TYPE_TYPE,WARNA_KODE"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblArea1" Name="TYPESTOCK_CDDEALER" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TxtDisetujuiNoRangka" Name="TYPESTOCK_NORANGKA" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="LblCdType" Name="TYPESTOCK_CDTYPE" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="lblWarna" Name="WARNA_int" PropertyName="Text" Type="String" />
            </SelectParameters>
            </asp:SqlDataSource>                 
	<!-- Dataku  LvUnitStok-->
            <asp:ListView ID="LvUnitStok" runat="server" DataKeyNames="TYPESTOCK_NORANGKA" DataSourceID="SdsDataStockDetail">
                <LayoutTemplate>
                <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                        <thead  style="background-color:Silver ; height:30px" >
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
        <asp:MultiView ID="MultiViewSetujuFaktur" runat="server" Visible="TRUE">
        <asp:View ID="View12" runat="server">
           <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
           <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label91" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Data Faktur"></asp:Label>
                    &nbsp;</td>
                <td style="width: 75%; ">
                    <asp:Label ID="LblNamaFaktur" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height= "75px" Width="95%"></asp:Label>
                </td>
           </tr>
          </table>
        </asp:View>         
        </asp:MultiView> 
        <asp:MultiView ID="MultiViewKondisiSPK" runat="server" Visible="TRUE">
        <asp:View ID="View14" runat="server">
        </asp:View>         
        </asp:MultiView> 

        <asp:MultiView ID="MultiViewAsesorisHdiary" runat="server" Visible="TRUE">
        <asp:View ID="View8" runat="server">
           <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
           <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label42" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Text="Asesoirs Tercatat di H-Diary"></asp:Label>
                    &nbsp;</td>
                <td style="width: 75%; ">
                    <asp:Label ID="LblAksesorisHdiary" runat="server" Font-Names="Arial" 
                        Font-Size="Small" Width="95%"></asp:Label>
                </td>
           </tr>
          </table>
        </asp:View>         
        </asp:MultiView> 


        <asp:MultiView ID="MultiViewSetujuAsesoris" runat="server" Visible="TRUE">
        <asp:View ID="View5" runat="server">
        
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
           <tr> 
                <td style="width: 100%; height: 26px;">
                    <asp:Label ID="Label34" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    height= "33px" 
                        Text="Aksesoris Yang hendak dipasang, Status/Sts = [1]Bayar,[0]Tidak Bayar,.......Kode P#1/P#2=[0] persetujuan SPV, [1] persetujuan Sales Manager.................!!!..." 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
           <tr> 
                <td style="width: 100%; height: 26px;">
                    <asp:Label ID="Label35" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    height= "33px" 
                        Text="Double klik di Kolom Kode (Pilih Kode Aksesorisnya) untuk membatalkan aksesoris yang akan di pasang !!!..." 
                        ForeColor="Blue" Width="1021px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>

        <asp:SqlDataSource ID="SqlSPKDataAsesoris" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
            SelectCommand="SELECT (TRXN_OPTPO.OPT_CDASS+'/'+TRXN_OPTPO.OPT_STATUSPROSES) as mKodeStatusQuery,TRXN_OPTPO.OPT_NODEALER, TRXN_OPTPO.OPT_USER, TRXN_OPTPO.OPT_TGL, TRXN_OPTPO.OPT_NOSPK, TRXN_OPTPO.OPT_TIPE, TRXN_OPTPO.OPT_CDASS, TRXN_OPTPO.OPT_STATUS, TRXN_OPTPO.OPT_HARGAJUAL, TRXN_OPTPO.OPT_HARGACUST, TRXN_OPTPO.OPT_KETERANGAN, TRXN_OPTPO.OPT_TGLAPPV1, TRXN_OPTPO.OPT_STATUSAPPV1, TRXN_OPTPO.OPT_CATATAN1, TRXN_OPTPO.OPT_TGLAPPV2, TRXN_OPTPO.OPT_STATUSAPPV2, TRXN_OPTPO.OPT_CATATAN2, TRXN_OPTPO.OPT_STATUSPROSES, TRXN_OPTPO.OPT_NOWO, TRXN_OPTPO.OPT_NOMORMOHON, TRXN_OPTPO.OPT_APPROVALCODE, TRXN_OPTPO.OPT_APPROVALCODEP, TRXN_OPTPO.OPT_SPV, TRXN_OPTPO.OPT_USERAPPV1, TRXN_OPTPO.OPT_USERAPPV2,TRXN_OPTPO.OPT_ERROR, TRXN_SPKAHERR.SPKAHERR_DESC, TRXN_SPKAHERR.SPKAHERR_DESCR, DATA_STANDARD.STANDARD_Nama 
                           FROM TRXN_OPTPO LEFT OUTER JOIN DATA_STANDARD ON TRXN_OPTPO.OPT_CDASS = DATA_STANDARD.STANDARD_Kode LEFT OUTER JOIN TRXN_SPKAHERR ON TRXN_OPTPO.OPT_NOMORMOHON = TRXN_SPKAHERR.SPKAHERR_NOM 
                           WHERE (TRXN_OPTPO.OPT_STATUSPROSES LIKE '%' + ? + '%') 
                           AND (TRXN_OPTPO.OPT_NOMORMOHON LIKE '%' + ? + '%') 
                           AND ((TRXN_OPTPO.OPT_USERAPPV1 LIKE '%' + ? + '%' AND TRXN_OPTPO.OPT_TGLAPPV1 IS NULL) 
                             OR (TRXN_OPTPO.OPT_USERAPPV2 LIKE '%' + ? + '%' AND TRXN_OPTPO.OPT_TGLAPPV2 IS NULL)) ORDER BY OPT_NODEALER,OPT_NOSPK" 
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCariJudul"      Name="OPT_STATUSPROSES" PropertyName="Text" Type="String" />            
                <asp:ControlParameter ControlID="LblResultIdMohon"  Name="OPT_NOMORMOHON"        PropertyName="Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="LblUserName"       Name="OPT_USERAPPV1"       PropertyName= "Text" Type="String" />            
                <asp:ControlParameter ControlID="LblUserName"       Name="OPT_USERAPPV2"      PropertyName= "Text" Type="String" />            
            </SelectParameters>


        </asp:SqlDataSource>                     
	<!-- Dataku  LvAksesorisNonDO-->
        <asp:ListView ID="LvAksesorisNonDO" runat="server" DataSourceID="SqlSPKDataAsesoris"  
            DataKeyNames ="mKodeStatusQuery">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">

                <thead  style="background-color:Silver; height:30px" >
                <th>Kode</th><th>Nomor</th><th>Dealer</th><th>User</th><th>Tanggal</th>
                <th>Asesoris</th><th>Sts</th><th>Modal</th><th>P#1</th>
                <th>Sts Stj#1</th><th>User Stj#1</th>
                <th>Catatan</th>
                </thead>

                <thead  style="background-color:Silver; height:30px" >
                <th>.</th><th>.</th><th>.</th><th>SPV</th><th>SPK</th>
                <th>Asesoris</th><th>Sts</th><th>Jual</th><th>P#2</th>
                <th>Sts Stj#2</th><th>User Stj#2</th>
                <th>Error</th>
                </thead>

                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            <asp:DataPager ID="dpBerita" PageSize="10" runat="server">
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
                    <td rowspan="2" style="width:8%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("mKodeStatusQuery") %>' CommandName="Select" runat="server" />
                    </td>
                    <td rowspan="2" style="width:8%; font-size:x-small"><%#Eval("OPT_NOMORMOHON")%></td>
                    <td rowspan="2" style="width:4%; font-size:x-small"><%#Eval("OPT_NODEALER")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_USER")%></td>
                    <td style="width:7%; font-size:x-small"><%#Format(Eval("OPT_TGL"), "dd-MM-yy HH:MM")%></td>
                    <td rowspan="2" style="width:9%; font-size:x-small"><%#Eval("STANDARD_Nama")%></td>
                    <td rowspan="2" style="width:2%; font-size:x-small"><%#Eval("OPT_STATUS")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("OPT_HARGAJUAL")%></td>
                    <td style="width:2%; font-size:x-small"><%#Eval("OPT_APPROVALCODE")%></td>
                    
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_STATUSAPPV1")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("OPT_USERAPPV1")%></td>


                    <td style="width:7%; font-size:x-small"><%#Eval("OPT_KETERANGAN")%></td>                    
                </tr>
                <tr>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_SPV")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_NOSPK")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("OPT_HARGACUST")%></td>
                    <td style="width:2%; font-size:x-small"><%#Eval("OPT_APPROVALCODEP")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_STATUSAPPV2")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("OPT_USERAPPV2")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("OPT_ERROR")%><%#Eval("SPKAHERR_DESC")%><%#Eval("SPKAHERR_DESCR")%></td>                    
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </asp:View> 
    </asp:MultiView>
        <asp:MultiView ID="MultiViewSetujuAsesorisSPK" runat="server" Visible="TRUE">
        <asp:View ID="View7" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
           <tr> 
                <td style="width: 100%; height: 26px;">
                    <asp:Label ID="Label36" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    height= "33px" 
                        Text="Aksesoris Yang hendak dipasang, Status/Sts = [1]Bayar,[0]Tidak Bayar,.......Kode P#1/P#2=[0] persetujuan SPV, [1] persetujuan Sales Manager.................!!!..." 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
           <tr> 
                <td style="width: 100%; height: 26px;">
                    <asp:Label ID="Label37" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    height= "33px" 
                        Text="Double klik di Kolom Kode (Pilih Kode Aksesorisnya) untuk membatalkan aksesoris yang akan di pasang !!!..." 
                        ForeColor="Blue" Width="1021px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
           <tr> 
                <td style="width: 100%; height: 26px;">
                    <asp:CheckBox ID="CheckAksesoris" runat="server" Font-Size="Small" 
                        Text="   Persetujuan Pemasangan Aksesoris ditunda / Tidak diorder asesorisnya" 
                        BackColor="Blue" Font-Bold="True" ForeColor="White" />
                </td>
            </tr>
        </table>
        
        <asp:SqlDataSource ID="SqlSPKDataAsesorisDO" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
            SelectCommand="SELECT (TRXN_OPTPO.OPT_CDASS+'/'+TRXN_OPTPO.OPT_STATUSPROSES) as mKodeStatusQuery,TRXN_OPTPO.OPT_NODEALER, TRXN_OPTPO.OPT_USER, TRXN_OPTPO.OPT_TGL, TRXN_OPTPO.OPT_NOSPK, TRXN_OPTPO.OPT_TIPE, TRXN_OPTPO.OPT_CDASS, TRXN_OPTPO.OPT_STATUS, TRXN_OPTPO.OPT_HARGAJUAL, TRXN_OPTPO.OPT_HARGACUST, TRXN_OPTPO.OPT_KETERANGAN, TRXN_OPTPO.OPT_TGLAPPV1, TRXN_OPTPO.OPT_STATUSAPPV1, TRXN_OPTPO.OPT_CATATAN1, TRXN_OPTPO.OPT_TGLAPPV2, TRXN_OPTPO.OPT_STATUSAPPV2, TRXN_OPTPO.OPT_CATATAN2, TRXN_OPTPO.OPT_STATUSPROSES, TRXN_OPTPO.OPT_NOWO, TRXN_OPTPO.OPT_NOMORMOHON, TRXN_OPTPO.OPT_APPROVALCODE, TRXN_OPTPO.OPT_APPROVALCODEP, TRXN_OPTPO.OPT_SPV, TRXN_OPTPO.OPT_USERAPPV1, TRXN_OPTPO.OPT_USERAPPV2,TRXN_OPTPO.OPT_ERROR, TRXN_SPKAHERR.SPKAHERR_DESC, TRXN_SPKAHERR.SPKAHERR_DESCR, DATA_STANDARD.STANDARD_Nama 
                           FROM TRXN_OPTPO LEFT OUTER JOIN DATA_STANDARD ON TRXN_OPTPO.OPT_CDASS = DATA_STANDARD.STANDARD_Kode LEFT OUTER JOIN TRXN_SPKAHERR ON TRXN_OPTPO.OPT_NOMORMOHON = TRXN_SPKAHERR.SPKAHERR_NOM
                           WHERE (TRXN_OPTPO.OPT_NODEALER LIKE '%' + ? + '%') AND 
                                 (TRXN_OPTPO.OPT_NOSPK LIKE '%' + ? + '%') ORDER BY OPT_NODEALER,OPT_NOSPK" 
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblDealer"  Name="OPT_NODEALER"     PropertyName="Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="LblNoSPK"   Name="OPT_NOSPK"        PropertyName="Text" Type="String" DefaultValue="%"  />
            </SelectParameters>
        </asp:SqlDataSource>                     
	<!-- Dataku  LvDataAsesorisDO-->
        <asp:ListView ID="LvDataAsesorisDO" runat="server" DataSourceID="SqlSPKDataAsesorisDO"  
            DataKeyNames ="mKodeStatusQuery">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead style="background-color:Silver; height:30px" >
                <th>Kode</th><th>Nomor</th><th>Dealer</th><th>User</th><th>Tanggal</th>
                <th>Asesoris</th><th>Sts</th><th>Mugen</th><th>P#1</th>
                <th>Sts Stj#1</th><th>User Stj#1</th>
                <th>Catatan</th>
                </thead>
                <thead style="background-color:Silver; height:30px" >
                <th>.</th><th>.</th><th>.</th><th>SPV</th><th>SPK</th>
                <th>.</th><th>.</th><th>Jual</th><th>P#2</th>
                <th>Sts Stj#2</th><th>User Stj#2</th>
                <th>Error</th>
                </thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            <asp:DataPager ID="dpBerita" PageSize="10" runat="server">
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
                    <td rowspan="2"  style="width:9%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("mKodeStatusQuery") %>' CommandName="Select" runat="server" />
                    </td>
                    <td rowspan="2" style="width:9%; font-size:x-small"><%#Eval("OPT_NOMORMOHON")%></td>
                    <td rowspan="2" style="width:3%; font-size:x-small"><%#Eval("OPT_NODEALER")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_USER")%></td>
                    <td style="width:7%; font-size:x-small"><%#Format(Eval("OPT_TGL"), "dd-MM-yy HH:MM")%></td>
                    <td rowspan="2" style="width:10%; font-size:x-small"><%#Eval("STANDARD_Nama")%></td>
                    <td rowspan="2" style="width:2%; font-size:x-small"><%#Eval("OPT_STATUS")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("OPT_HARGAJUAL")%></td>
                    <td style="width:2%; font-size:x-small"><%#Eval("OPT_APPROVALCODE")%></td>
                    
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_STATUSAPPV1")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_USERAPPV1")%></td>

                    
                    <td style="width:7%; font-size:x-small"><%#Eval("OPT_KETERANGAN")%></td>
                </tr>
                <tr>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_SPV")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_NOSPK")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("OPT_HARGACUST")%></td>
                    <td style="width:2%; font-size:x-small"><%#Eval("OPT_APPROVALCODEP")%></td>
                    <td style="width:3%; font-size:x-small"><%#Eval("OPT_STATUSAPPV2")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("OPT_USERAPPV2")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("OPT_ERROR")%><%#Eval("SPKAHERR_DESC")%><%#Eval("SPKAHERR_DESCR")%></td>                    
                </tr>

            </ItemTemplate>
        </asp:ListView>
          
          
          
          
          
    </asp:View> 
    </asp:MultiView>

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
           <tr> 
                <td style="width: 100%; height: 26px;">
                    <asp:Label ID="Label43" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "33px" Text="Catatan : Untuk mengganti Nilai yang akan dirubah maka isi kotak yang berwarna hijau di kolom Perubahan, Nilai perubahan yang disetujui adalah nilai terakhir dari jenjang persetujuan !!! " 
                        ForeColor="#CC0000" Width="1021px"></asp:Label>
                </td>
            </tr>
        </table>


        <asp:MultiView ID="MultiViewHistoryPersetujuan" runat="server" Visible="TRUE">
        <asp:View ID="ViewHistorySetuju" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
           <tr> 
                <td style="width: 100%; height: 26px;">
                    <asp:Label ID="Label21" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "16px" 
                        Text="History Persetujuan dengan Kategori yang sama" 
                        ForeColor="#CC0000" Width="526px"></asp:Label>
                </td>
            </tr>
          </table>

        <asp:SqlDataSource ID="sdsTabelApv1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM [TRXN_SPKAH] WHERE NOT(JUDUL like 'ENTRY%') AND ([NOMOR_MOHON] LIKE '%' + ? + '%') ORDER BY TANGGAL_SETUJU"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblPolcyNomorMohon" Name="NOMOR_MOHON" PropertyName="Text" Type="String" />            
            </SelectParameters>
        </asp:SqlDataSource>                     

	<!-- Dataku  LVPersetujuan2-->
        <asp:ListView ID="LVPersetujuan2" runat="server" DataSourceID="sdsTabelApv1"  
            DataKeyNames ="NOMOR_MOHON">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead style="background-color:Silver; height:30px">
                <th>SPK</th><th>Judul</th><th>Alasan</th><th>Tanggal Setuju</th><th>Pos #1</th><th>Pos #2</th>
                <th>Change/Tahun</th><th>Potongan</th><th>Subsidi</th><th>Komisi</th><th>Catatan</th>
                </thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
    
            <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
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
                    <td style="width:8%; font-size:x-small"><%#Eval("NOMOR_SPK")%></td>
                    <td style="width:20%; font-size:x-small"><%#Eval("JUDUL")%></td>
                    <td style="width:20%; font-size:x-small"><%#Eval("KETERANGAN")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("TANGGAL_SETUJU")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("APPROVALCODE")%></td>
                    <td style="width:4%; font-size:x-small"><%#Eval("APPROVALCODEP")%></td>
                    <td style="width:7%; font-size:x-small"><%#Eval("CHANGE")%></td>
                    <td style="width:7%; font-size:x-small"><%#Eval("CHANGE1")%></td>
                    <td style="width:7%; font-size:x-small"><%#Eval("CHANGE2")%></td>
                    <td style="width:7%; font-size:x-small"><%#Eval("CHANGE3")%></td>
                    <td style="width:6%; font-size:x-small"><%#Eval("CATATAN")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
          
    </asp:View> 
    </asp:MultiView>


        </asp:View>
        </asp:MultiView> 
        
       <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%;">
                    <asp:Label ID="lblerrorTombolSPK" runat="server" Font-Names="Arial" 
                        Font-Size="Small" Font-Bold ="True" ForeColor="Red" height="21px" Text=""></asp:Label>
                </td>
            </tr>
       </table>
        
        
        <asp:MultiView ID="MultiView0S" runat="server" Visible="TRUE">
            <asp:View ID="View0S1" runat="server">
            <div>
            <center>
                <h1 style="font-family:Cooper Black; color: #000000; font-size: large;">Persetujuan SPV</h1>
            </center>
            <center>
                   <asp:Label ID="Label19" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red" Text="Tanggal Disetujui SPV / Nama"></asp:Label>
                   <asp:Label ID="Label44" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red" Text="__:__"></asp:Label>
                    <asp:Label ID="lblTglsetuju0" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red"></asp:Label>
            </center>
            </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label24" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Catatan SPV"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtCatatan0" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Height="50px" Width="95%" MaxLength="100" TabIndex ="7"  
                        AutoPostBack="true"   ></asp:TextBox>
                </td>
                </tr>
            </table>
            <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
                <tr>
                   <td style="width: 25%;  color: #FFFFFF;">&nbsp;</td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="ButtonSetuju0" runat="server" Text="Setuju" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="#004080" />                             
                        <div id="flyoutBS0" style="display: none; overflow: hidden; z-index: 2; background-color: #FFFFFF; border: solid 1px #D0D0D0;"></div>
                        <div id="infoBS0" style="display: none; width: 250px; z-index: 2; font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
                            <div id="btnCloseParentBS0" style="float: right; visibility :hidden">
                                <asp:LinkButton id="btnCloseBS0" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                                     Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
                            </div>
                            <div><p>Tunggu Sedang Sistem sedang melakukan proses simpan sampai pesan ini tidak tertampil..................</p><br />
                            </div>
                        </div>        
                        <ajaxToolkit:AnimationExtender id="OpenAnimationBS0" runat="server" TargetControlID="ButtonSetuju0">
                            <Animations>
                                <OnClick>
                                    <Sequence>
                                    <EnableAction Enabled="false" />
                                    <ScriptAction Script="Cover($get('ctl00_SampleContent_ButtonSetuju0'), $get('flyoutBS0'));" />
                                    <StyleAction AnimationTarget="flyoutBS0" Attribute="display" Value="block"/>
                                    <Parallel AnimationTarget="flyoutBS0" Duration=".3" Fps="25">
                                        <Move Horizontal="150" Vertical="-50" />
                                        <Resize Width="260" Height="280" />
                                        <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                                    </Parallel>
                                    <ScriptAction Script="Cover($get('flyoutBS0'), $get('infoBS0'), true);" />
                                    <StyleAction AnimationTarget="infoBS0" Attribute="display" Value="block"/>
                                    <FadeIn AnimationTarget="infoBS0" Duration=".2"/>
                                    <StyleAction AnimationTarget="flyoutBS0" Attribute="display" Value="none"/>
                                    <Parallel AnimationTarget="infoBS0" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                                        <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                                    </Parallel>
                                    <Parallel AnimationTarget="infoBS0" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                                        <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                                        <FadeIn AnimationTarget="btnCloseParentBS0" MaximumOpacity=".9" />
                                    </Parallel>
                                    </Sequence>
                                </OnClick>
                            </Animations>
                        </ajaxToolkit:AnimationExtender>
                        <ajaxToolkit:AnimationExtender id="CloseAnimationBS0" runat="server" TargetControlID="btnCloseBS0">        
                        <Animations>
                            <OnClick>
                            <Sequence AnimationTarget="infoBS0">
                            <StyleAction Attribute="overflow" Value="hidden"/>
                            <Parallel Duration=".3" Fps="15">
                                <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                                <FadeOut />
                            </Parallel>
                            <StyleAction Attribute="display" Value="none"/>
                            <StyleAction Attribute="width" Value="250px"/>
                            <StyleAction Attribute="height" Value=""/>
                            <StyleAction Attribute="fontSize" Value="12px"/>
                            <OpacityAction AnimationTarget="btnCloseParentBS0" Opacity="0" />
                            <EnableAction AnimationTarget="ButtonSetuju0" Enabled="true" />
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
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="BtnTolak0" runat="server" Text="Tolak" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="Red" />    
                   </td>
                </tr>
            </table>
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiView1S" runat="server" Visible="TRUE">
            <asp:View ID="View1S1" runat="server">
            <div>
            <center>
                <h1 style="font-family:Cooper Black; color: #000000; font-size: large;">Persetujuan 
                    SALES MANAGER</h1>
            </center>
            <center>
                   <asp:Label ID="Label25" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Disetujui Sales Manager / Nama"></asp:Label>
                   <asp:Label ID="Label54" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red" Text="__:__"></asp:Label>
                    <asp:Label ID="lblTglSetuju1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red"></asp:Label>
            </center>
            </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label27" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Catatan SM"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtCatatan1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Height="50px" Width="95%" MaxLength="100" TabIndex ="7"  
                        AutoPostBack="true"   ></asp:TextBox>
                </td>
                </tr>
            </table>
            <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
                <tr>
                   <td style="width: 25%;  color: #FFFFFF;">&nbsp;</td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="ButtonSetuju1" runat="server" Text="Setuju" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="#004080" />    
                        <div id="flyoutBS1" style="display: none; overflow: hidden; z-index: 2; background-color: #FFFFFF; border: solid 1px #D0D0D0;"></div>
                        <div id="infoBS1" style="display: none; width: 250px; z-index: 2; font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
                            <div id="btnCloseParentBS1" style="float: right; visibility :hidden">
                                <asp:LinkButton id="btnCloseBS1" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                                     Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
                            </div>
                            <div><p>Tunggu Sedang Sistem sedang melakukan proses simpan sampai pesan ini tidak tertampil..................</p><br />
                            </div>
                        </div>        
                        <ajaxToolkit:AnimationExtender id="OpenAnimationBS1" runat="server" TargetControlID="ButtonSetuju1">
                            <Animations>
                                <OnClick>
                                    <Sequence>
                                    <EnableAction Enabled="false" />
                                    <ScriptAction Script="Cover($get('ctl00_SampleContent_ButtonSetuju1'), $get('flyoutBS1'));" />
                                    <StyleAction AnimationTarget="flyoutBS1" Attribute="display" Value="block"/>
                                    <Parallel AnimationTarget="flyoutBS1" Duration=".3" Fps="25">
                                        <Move Horizontal="150" Vertical="-50" />
                                        <Resize Width="260" Height="280" />
                                        <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                                    </Parallel>
                                    <ScriptAction Script="Cover($get('flyoutBS1'), $get('infoBS1'), true);" />
                                    <StyleAction AnimationTarget="infoBS1" Attribute="display" Value="block"/>
                                    <FadeIn AnimationTarget="infoBS1" Duration=".2"/>
                                    <StyleAction AnimationTarget="flyoutBS1" Attribute="display" Value="none"/>
                                    <Parallel AnimationTarget="infoBS1" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                                        <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                                    </Parallel>
                                    <Parallel AnimationTarget="infoBS1" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                                        <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                                        <FadeIn AnimationTarget="btnCloseParentBS1" MaximumOpacity=".9" />
                                    </Parallel>
                                    </Sequence>
                                </OnClick>
                            </Animations>
                        </ajaxToolkit:AnimationExtender>
                        <ajaxToolkit:AnimationExtender id="CloseAnimationBS1" runat="server" TargetControlID="btnCloseBS1">        
                        <Animations>
                            <OnClick>
                            <Sequence AnimationTarget="infoBS1">
                            <StyleAction Attribute="overflow" Value="hidden"/>
                            <Parallel Duration=".3" Fps="15">
                                <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                                <FadeOut />
                            </Parallel>
                            <StyleAction Attribute="display" Value="none"/>
                            <StyleAction Attribute="width" Value="250px"/>
                            <StyleAction Attribute="height" Value=""/>
                            <StyleAction Attribute="fontSize" Value="12px"/>
                            <OpacityAction AnimationTarget="btnCloseParentBS1" Opacity="0" />
                            <EnableAction AnimationTarget="ButtonSetuju1" Enabled="true" />
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
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="BtnTolak1" runat="server" Text="Tolak" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="Red" />    
                   </td>
                </tr>
            </table>
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiView2S" runat="server" Visible="TRUE">
            <asp:View ID="View2S1" runat="server">
            <div>
            <center>
                <h1 style="font-family:Cooper Black; color: #000000; font-size: large;">Persetujuan 
                    DIREKTUR</h1>
            </center>
            <center>
                   <asp:Label ID="Label78" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Disetujui Direktur / Nama"></asp:Label>
                   <asp:Label ID="Label80" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red" Text="__:__"></asp:Label>
                    <asp:Label ID="lblTglSetuju2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red"></asp:Label>
            </center>
            </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label30" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Catatan Direktur"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtCatatan2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Height="50px" Width="95%" MaxLength="100" TabIndex ="7"  
                        AutoPostBack="true"   ></asp:TextBox>
                </td>
                </tr>
            </table>
            <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
                <tr>
                   <td style="width: 25%;  color: #FFFFFF;">&nbsp;</td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="ButtonSetuju2" runat="server" Text="Setuju" Width="321px" 
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
                        <ajaxToolkit:AnimationExtender id="OpenAnimationBS2" runat="server" TargetControlID="ButtonSetuju2">
                            <Animations>
                                <OnClick>
                                    <Sequence>
                                    <EnableAction Enabled="false" />
                                    <ScriptAction Script="Cover($get('ctl00_SampleContent_ButtonSetuju2'), $get('flyoutBS2'));" />
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
                            <EnableAction AnimationTarget="ButtonSetuju2" Enabled="true" />
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
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="BtnTolak2" runat="server" Text="Tolak" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="Red" />    
                   </td>
                </tr>
            </table>
        </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiView3S" runat="server" Visible="TRUE">
            <asp:View ID="View3S3" runat="server">
            <div>
            <center>
                <h1 style="font-family:Cooper Black; color: #000000; font-size: large;">Persetujuan Vice Presiden</h1>
            </center>
            <center>
                   <asp:Label ID="Label28" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Disetujui Vice Presiden / Nama"></asp:Label>
                   <asp:Label ID="Label83" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red" Text="__:__"></asp:Label>
                    <asp:Label ID="LblTglSetuju3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red"></asp:Label>
            </center>
            </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                <tr>
                    <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                        <asp:Label ID="Label33" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Catatan Vice Presiden"></asp:Label>
                    </td>
                    <td style="width: 75%; ">
                      <asp:TextBox ID="TxtCatatan3" runat="server" Font-Names="Arial" Font-Size="Small" 
                        Height="50px" Width="95%" MaxLength="100" TabIndex ="7"  
                            AutoPostBack="true"   ></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
                <tr>
                   <td style="width: 25%;  color: #FFFFFF;">&nbsp;</td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="ButtonSetuju3" runat="server" Text="Setuju" Width="300px" 
                         Font-Size="X-Large" Height="39px" BackColor="#004080" />   
                         
                        <div id="flyoutBS3" style="display: none; overflow: hidden; z-index: 2; background-color: #FFFFFF; border: solid 1px #D0D0D0;"></div>
                        <div id="infoBS3" style="display: none; width: 250px; z-index: 2; font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
                            <div id="btnCloseParentBS3" style="float: right; visibility :hidden">
                                <asp:LinkButton id="btnCloseBS3" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                                     Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
                            </div>
                            <div><p>Tunggu Sedang Sistem sedang melakukan proses simpan sampai pesan ini tidak tertampil..................</p><br />
                            </div>
                        </div>        
                        <ajaxToolkit:AnimationExtender id="OpenAnimationBS3" runat="server" TargetControlID="ButtonSetuju3">
                            <Animations>
                                <OnClick>
                                    <Sequence>
                                    <EnableAction Enabled="false" />
                                    <ScriptAction Script="Cover($get('ctl00_SampleContent_ButtonSetuju3'), $get('flyoutBS3'));" />
                                    <StyleAction AnimationTarget="flyoutBS3" Attribute="display" Value="block"/>
                                    <Parallel AnimationTarget="flyoutBS3" Duration=".3" Fps="25">
                                        <Move Horizontal="150" Vertical="-50" />
                                        <Resize Width="260" Height="280" />
                                        <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                                    </Parallel>
                                    <ScriptAction Script="Cover($get('flyoutBS3'), $get('infoBS3'), true);" />
                                    <StyleAction AnimationTarget="infoBS3" Attribute="display" Value="block"/>
                                    <FadeIn AnimationTarget="infoBS3" Duration=".2"/>
                                    <StyleAction AnimationTarget="flyoutBS3" Attribute="display" Value="none"/>
                                    <Parallel AnimationTarget="infoBS3" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                                        <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                                    </Parallel>
                                    <Parallel AnimationTarget="infoBS3" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                                        <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                                        <FadeIn AnimationTarget="btnCloseParentBS3" MaximumOpacity=".9" />
                                    </Parallel>
                                    </Sequence>
                                </OnClick>
                            </Animations>
                        </ajaxToolkit:AnimationExtender>
                        <ajaxToolkit:AnimationExtender id="CloseAnimationBS3" runat="server" TargetControlID="btnCloseBS3">        
                        <Animations>
                            <OnClick>
                            <Sequence AnimationTarget="infoBS3">
                            <StyleAction Attribute="overflow" Value="hidden"/>
                            <Parallel Duration=".3" Fps="15">
                                <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                                <FadeOut />
                            </Parallel>
                            <StyleAction Attribute="display" Value="none"/>
                            <StyleAction Attribute="width" Value="250px"/>
                            <StyleAction Attribute="height" Value=""/>
                            <StyleAction Attribute="fontSize" Value="12px"/>
                            <OpacityAction AnimationTarget="btnCloseParentBS3" Opacity="0" />
                            <EnableAction AnimationTarget="ButtonSetuju3" Enabled="true" />
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
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="BtnTolak3" runat="server" Text="Tolak" Width="300px" 
                         Font-Size="X-Large" Height="39px" BackColor="Red" />    
                   </td>
                </tr>
            </table>
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiView4S" runat="server" Visible="TRUE">
            <asp:View ID="View10" runat="server">
            <div>
            <center>
                <h1 style="font-family:Cooper Black; color: #000000; font-size: large;">Persetujuan ADMIN HEAD</h1>
            </center>
            <center>
                   <asp:Label ID="Label31" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Disetujui Admin Head / Nama"></asp:Label>
                   <asp:Label ID="Label85" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red" Text="__:__"></asp:Label>
                        <asp:Label ID="LblTglSetuju4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red"></asp:Label>
            </center>
            </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                <tr>
                    <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                        <asp:Label ID="Label102" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Catatan"></asp:Label>
                    </td>
                    <td style="width: 75%; ">
                      <asp:TextBox ID="TxtCatatan4" runat="server" Font-Names="Arial" Font-Size="Small" 
                        Height="50px" Width="95%" MaxLength="100" TabIndex ="7"  
                            AutoPostBack="true"   ></asp:TextBox>
                    </td>
                </tr>
                </table>
            <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
                <tr>
                   <td style="width: 25%;  color: #FFFFFF;">&nbsp;</td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="ButtonSetuju4" runat="server" Text="Setuju" Width="300px" 
                         Font-Size="X-Large" Height="39px" BackColor="#004080" />   
                         
                        <div id="flyoutBS4" style="display: none; overflow: hidden; z-index: 2; background-color: #FFFFFF; border: solid 1px #D0D0D0;"></div>
                        <div id="infoBS4" style="display: none; width: 250px; z-index: 2; font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
                            <div id="btnCloseParentBS4" style="float: right; visibility :hidden">
                                <asp:LinkButton id="btnCloseBS4" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                                     Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
                            </div>
                            <div><p>Tunggu Sedang Sistem sedang melakukan proses simpan sampai pesan ini tidak tertampil..................</p><br />
                            </div>
                        </div>        
                        <ajaxToolkit:AnimationExtender id="OpenAnimationBS4" runat="server" TargetControlID="ButtonSetuju4">
                            <Animations>
                                <OnClick>
                                    <Sequence>
                                    <EnableAction Enabled="false" />
                                    <ScriptAction Script="Cover($get('ctl00_SampleContent_ButtonSetuju4'), $get('flyoutBS4'));" />
                                    <StyleAction AnimationTarget="flyoutBS4" Attribute="display" Value="block"/>
                                    <Parallel AnimationTarget="flyoutBS4" Duration=".3" Fps="25">
                                        <Move Horizontal="150" Vertical="-50" />
                                        <Resize Width="260" Height="280" />
                                        <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                                    </Parallel>
                                    <ScriptAction Script="Cover($get('flyoutBS4'), $get('infoBS4'), true);" />
                                    <StyleAction AnimationTarget="infoBS4" Attribute="display" Value="block"/>
                                    <FadeIn AnimationTarget="infoBS4" Duration=".2"/>
                                    <StyleAction AnimationTarget="flyoutBS4" Attribute="display" Value="none"/>
                                    <Parallel AnimationTarget="infoBS4" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                                        <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                                    </Parallel>
                                    <Parallel AnimationTarget="infoBS4" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                                        <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                                        <FadeIn AnimationTarget="btnCloseParentBS4" MaximumOpacity=".9" />
                                    </Parallel>
                                    </Sequence>
                                </OnClick>
                            </Animations>
                        </ajaxToolkit:AnimationExtender>
                        <ajaxToolkit:AnimationExtender id="CloseAnimationBS4" runat="server" TargetControlID="btnCloseBS4">        
                        <Animations>
                            <OnClick>
                            <Sequence AnimationTarget="infoBS4">
                            <StyleAction Attribute="overflow" Value="hidden"/>
                            <Parallel Duration=".3" Fps="15">
                                <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                                <FadeOut />
                            </Parallel>
                            <StyleAction Attribute="display" Value="none"/>
                            <StyleAction Attribute="width" Value="250px"/>
                            <StyleAction Attribute="height" Value=""/>
                            <StyleAction Attribute="fontSize" Value="12px"/>
                            <OpacityAction AnimationTarget="btnCloseParentBS4" Opacity="0" />
                            <EnableAction AnimationTarget="ButtonSetuju4" Enabled="true" />
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
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="BtnTolak4" runat="server" Text="Tolak" Width="300px" 
                         Font-Size="X-Large" Height="39px" BackColor="Red" />    
                   </td>
                </tr>
                </table>
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiView5S" runat="server" Visible="TRUE">
            <asp:View ID="View13" runat="server">
            <div>
            <center>
                <h1 style="font-family:Cooper Black; color: #000000; font-size: large;">Persetujuan HEAD ACCOUNT & FINANCE</h1>
            </center>
            <center>
                   <asp:Label ID="Label123" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Disetujui Head Account & Finance / Nama"></asp:Label>
                   <asp:Label ID="Label131" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red" Text="__:__"></asp:Label>
                        <asp:Label ID="LblTglSetuju5" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red"></asp:Label>
            </center>
            </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                <tr>
                    <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                        <asp:Label ID="Label106" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Catatan Head Finance dan Account"></asp:Label>
                    </td>
                    <td style="width: 75%; ">
                      <asp:TextBox ID="TxtCatatan5" runat="server" Font-Names="Arial" Font-Size="Small" 
                        Height="50px" Width="95%" MaxLength="100" TabIndex ="7"  
                            AutoPostBack="true"   ></asp:TextBox>
                    </td>
                </tr>
                </table>
            <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
                <tr>
                
                
                   <td style="width: 25%;  color: #FFFFFF;">&nbsp;</td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="ButtonSetuju5" runat="server" Text="Setuju" Width="300px" 
                         Font-Size="X-Large" Height="39px" BackColor="#004080" />   
                         
                        <div id="flyoutBS5" style="display: none; overflow: hidden; z-index: 2; background-color: #FFFFFF; border: solid 1px #D0D0D0;"></div>
                        <div id="infoBS5" style="display: none; width: 250px; z-index: 2; font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
                            <div id="btnCloseParentBS5" style="float: right; visibility :hidden">
                                <asp:LinkButton id="btnCloseBS5" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                                     Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
                            </div>
                            <div><p>Tunggu Sedang Sistem sedang melakukan proses simpan sampai pesan ini tidak tertampil..................</p><br />
                            </div>
                        </div>        
                        <ajaxToolkit:AnimationExtender id="OpenAnimationBS5" runat="server" TargetControlID="ButtonSetuju5">
                            <Animations>
                                <OnClick>
                                    <Sequence>
                                    <EnableAction Enabled="false" />
                                    <ScriptAction Script="Cover($get('ctl00_SampleContent_ButtonSetuju5'), $get('flyoutBS5'));" />
                                    <StyleAction AnimationTarget="flyoutBS5" Attribute="display" Value="block"/>
                                    <Parallel AnimationTarget="flyoutBS5" Duration=".3" Fps="25">
                                        <Move Horizontal="150" Vertical="-50" />
                                        <Resize Width="260" Height="280" />
                                        <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                                    </Parallel>
                                    <ScriptAction Script="Cover($get('flyoutBS5'), $get('infoBS5'), true);" />
                                    <StyleAction AnimationTarget="infoBS5" Attribute="display" Value="block"/>
                                    <FadeIn AnimationTarget="infoBS5" Duration=".2"/>
                                    <StyleAction AnimationTarget="flyoutBS5" Attribute="display" Value="none"/>
                                    <Parallel AnimationTarget="infoBS5" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                                        <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                                    </Parallel>
                                    <Parallel AnimationTarget="infoBS5" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                                        <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                                        <FadeIn AnimationTarget="btnCloseParentBS5" MaximumOpacity=".9" />
                                    </Parallel>
                                    </Sequence>
                                </OnClick>
                            </Animations>
                        </ajaxToolkit:AnimationExtender>
                        <ajaxToolkit:AnimationExtender id="CloseAnimationBS5" runat="server" TargetControlID="btnCloseBS5">        
                        <Animations>
                            <OnClick>
                            <Sequence AnimationTarget="infoBS5">
                            <StyleAction Attribute="overflow" Value="hidden"/>
                            <Parallel Duration=".3" Fps="15">
                                <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                                <FadeOut />
                            </Parallel>
                            <StyleAction Attribute="display" Value="none"/>
                            <StyleAction Attribute="width" Value="250px"/>
                            <StyleAction Attribute="height" Value=""/>
                            <StyleAction Attribute="fontSize" Value="12px"/>
                            <OpacityAction AnimationTarget="btnCloseParentBS5" Opacity="0" />
                            <EnableAction AnimationTarget="ButtonSetuju5" Enabled="true" />
                            </Sequence>
                            </OnClick>
                            <OnMouseOver>
                            <Color Duration=".2" PropertyKey="color" StartValue="#FFFFFF" EndValue="#FF0000" />
                            </OnMouseOver>
                            <OnMouseOut>
                            <Color Duration=".2" PropertyKey="color" StartValue="#FF0000" EndValue="#FFFFFF" />
                            </OnMouseOut>
                        </Animations>
                        </ajaxToolkit:AnimationExtender>                   </td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="BtnTolak5" runat="server" Text="Tolak" Width="300px" 
                         Font-Size="X-Large" Height="39px" BackColor="Red" />    
                   </td>
           
           
           
           
                </tr>
                </table>
            </asp:View> 
        </asp:MultiView>         
         
         
        <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 100%;  color: #FFFFFF;">
                <asp:Button ID="BtnKembali1" runat="server" Text="Kembali" Width="95%" 
                    Font-Size="X-Large" Height="39px" />    
            </td>
            </tr>
        </table>

    </asp:View>
    <asp:View ID="View3" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="LabelWH45" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal Mohon  [YYYY-MM-DD]" ForeColor="White"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="LblWHTglMohon" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="LabelWH47" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal Input [YYYY-MM-DD]" ForeColor="White"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="LblWHTglInput" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                   <asp:Label ID="Label49" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal Persetujuan [YYYY-MM-DD]" ForeColor="White"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblWHTglSetuju" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="Label51" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal Work Order [YYYY-MM-DD]" ForeColor="White"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblWHTglWo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            </table>            
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr> 
                <td style="width: 25%; background-color:#CCCCFF;">
                   <asp:Label ID="Label53" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor Mohon"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF;">
                    <asp:Label ID="LblWHNoMohon" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label46" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Jenis Mohon"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="LblWHJenisMohon" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; background-color:#CCCCFF;">
                   <asp:Label ID="Label48" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Kepemilikan Unit"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF;">
                    <asp:Label ID="LblWHDealer" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label55" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Nomor Rangka"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="LblWHNoRangka" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label57" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tipe"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblWHTipe" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label59" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Warna"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblWHWarna" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%;">
                    <asp:Label ID="Label61" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Estimasi Harga Repair"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblWHHarga" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="Label63" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Bengkel/Service"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblWHBengkel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label65" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Keterangan"></asp:Label>
                </td>
                <td style="width: 75%; height: 42px;background-color:#CCCCFF;">
                    <asp:Label ID="LblWHKeterangan" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;  height: 81px;">
                   <asp:Label ID="Label67" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Detail Pekerjaan"></asp:Label>
                </td>
                <td style="width: 75%; height: 81px;">
                    <asp:Label ID="LblWHDetailKerjaan" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            </table>

        <asp:MultiView ID="MultiViewWH" runat="server" Visible="TRUE">
            <asp:View ID="ViewWH" runat="server">
                        <div>
            <center>
                <h1 style="font-family:Cooper Black; color: #000000; font-size: large;">Persetujuan 
                    SALES MANAGER</h1>
            </center>
            <center>
                   <asp:Label ID="Label88" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal Disetujui Sales Manager / Nama"></asp:Label>
                   <asp:Label ID="Label93" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red" Text="__:__"></asp:Label>
                    <asp:Label ID="lblWHSetujuOleh" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Label ID="LblWHNoMorSetuju" runat="server"></asp:Label>
            </center>
            </div>  

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label47" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Catatan Manager"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtWHCatatan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Height="50px" Width="95%" MaxLength="50" TabIndex ="7"  
                        AutoPostBack="true"   ></asp:TextBox>
                </td>
                </tr>
            </table>
            <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
                <tr>
                   <td style="width: 25%;  color: #FFFFFF;">&nbsp;</td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="Button3" runat="server" Text="Setuju" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="#00FFCC" />    
                   </td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="Button4" runat="server" Text="Tolak" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="Red" />    
                   </td>
                </tr>
            </table>
            </asp:View> 
        </asp:MultiView>
        <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 100%;  color: #FFFFFF;">
                <asp:Button ID="Button5" runat="server" Text="Selesai" Width="95%" 
                    Font-Size="X-Large" Height="39px" />    
            </td>
            </tr>
        </table>

    </asp:View>
    <asp:View ID="View4" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                   <asp:Label ID="Label90" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal "></asp:Label>
                    &nbsp;</td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="txtChatTanggal" runat="server" text="" Width="95%" MaxLength="100" CssClass="uppercase"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                   <asp:Label ID="Label96" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Chat"></asp:Label>
                    &nbsp;</td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="txtChatNo1" runat="server" text="" Width="20%" MaxLength="100" CssClass="uppercase"></asp:TextBox>
                    <asp:TextBox ID="txtChatNo2" runat="server" text="" Width="20%" MaxLength="100" CssClass="uppercase"></asp:TextBox>
                   <asp:Label ID="LblChatDlr" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                   <asp:Label ID="Label101" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="User"></asp:Label>
                    &nbsp;</td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="txtChatUser" runat="server" text="" Width="95%" MaxLength="100" CssClass="uppercase"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label94" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Percakapan"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtChatMsg" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Height="50px" Width="95%" MaxLength="50" TabIndex ="7"  
                        AutoPostBack="true"   ></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
            <tr>
                   <td style="width: 25%;  color: #FFFFFF;">
                        <asp:Button ID="Button11" runat="server" Text="Kembali Ke Menu" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="#00FFCC" />    
                   </td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="Button9" runat="server" Text="Mulai Percakapan" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="#00FFCC" />    
                   </td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="Button10" runat="server" Text="Pencarian" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="#00FFCC" />    
                   </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataCHAT" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
            SelectCommand="SELECT * FROM TRXN_SPKAHCHT WHERE (TRXN_SPKAHCHT.CHAT_DEALER LIKE '%' + ? + '%') ORDER BY CHAT_NO,CHAT_TGL"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblArea1"      Name="CHAT_DEALER"     PropertyName= "Text" Type="String" />            
            </SelectParameters>
            
        </asp:SqlDataSource>                             
	<!-- Dataku  LVChat-->
        <asp:ListView ID="LVChat" runat="server" DataSourceID="SqlDataCHAT" DataKeyNames ="CHAT_NO">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>Nomor</th><th>Dlr</th><th>Tanggal</th><th>User</th><th>Chat</th><th>No Mohon</th>
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
                    <td style="width:5%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("CHAT_NO") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:3%; font-size:x-small; "><%#Eval("CHAT_DEALER")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("CHAT_TGL")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("CHAT_USER")%></td>
                    <td style="width:70%; font-size:x-small"><%#Eval("CHAT_TEXT")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("CHAT_NOMOHON")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

    </asp:View> 


    </asp:MultiView>

</asp:Content>
