<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0203PerformanceSales02PiutangSPK.aspx.vb" Inherits="Form0203PerformanceSales02PiutangSPK" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">PIUTANG CUSTOMER</h2>
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

    <asp:MultiView ID="MultiViewQuerySpv" runat="server" Visible="TRUE">
    <asp:View ID="ViewSearch" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 30%; Background-color:#CCCCFF; ">
                <asp:Label ID="Label74" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Lokasi Dealer"></asp:Label>
            </td>
            <td style="width: 70%; Background-color:#CCCCFF; ">
                <asp:DropDownList ID="DropDownListGroupTipe" runat="server">
                    <asp:ListItem>112</asp:ListItem>
                    <asp:ListItem>128</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 30%; ">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Tanggal Update Terakhir"></asp:Label>
            </td>
            <td style="width: 70%; ">
                <asp:CheckBox ID="CheckBoxPerbarui" Text="Perbarui report" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 30%; Background-color:#CCCCFF; ">
            </td>
            <td style="width: 70%; Background-color:#CCCCFF; ">
            <asp:Button ID="ButtonPsm" runat="server" 
                    Text="Klik Disini untuk menampilkan tabel sesuai dealer atau perbaharui" Width="60%" Height="100%"  
                    BackColor="White" Font-Bold="True" ForeColor="Black" BorderStyle="None" 
                    Font-Italic="True" Font-Underline="True" Style=" text-align:left" />
            </td>
        </tr>
        <tr>
            <td style="width: 30%; ">
                <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Status Proses Update"></asp:Label>
            </td>
            <td style="width: 70%; ">
            <asp:Label ID="lblProsesBox" runat="server" Font-Bold="True" 
                Font-Names="Arial" Font-Size="Small" height="40px" Width="99%" >Prosess</asp:Label>
            </td>
        </tr>


        <tr>
            <td style="width: 30%; Background-color:#CCCCFF;">
                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Kode Spv</asp:Label>
            </td>
            <td style="width: 70%; Background-color:#CCCCFF;">
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
    <asp:MultiView ID="MultiView1Menu" runat="server" Visible="TRUE">

    <asp:View ID="View3" runat="server">

      <asp:SqlDataSource ID="SqlARSTOCK" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM  DATA_ARSTOCK,DATA_TYPE WHERE ARSTOCK_CDTYPE=TYPE_TYPE AND ([ARSTOCK_DEALER] LIKE '%' + ? + '%') AND ([ARSTOCK_KDSPV] LIKE '%' + ? + '%') ORDER BY ARSTOCK_DEALER,ARSTOCK_KDSPV"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
           <SelectParameters>
                <asp:ControlParameter ControlID="DropDownListGroupTipe" Name="ARSTOCK_DEALER" 
                    PropertyName="SelectedValue" Type="String" DefaultValue="%" />            
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

  </asp:MultiView>
</asp:Content>
