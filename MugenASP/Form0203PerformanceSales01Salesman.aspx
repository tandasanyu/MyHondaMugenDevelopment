<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0203PerformanceSales01Salesman.aspx.vb" Inherits="Form0203PerformanceSales01Salesman" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">PERFORMANCE SALES</h2>
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



   <asp:MultiView ID="MultiViewQueryDlr" runat="server" Visible="TRUE">
    <asp:View ID="View29" runat="server">
        <table style="width: 100%; height:100px; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
        <tr>
            <td style="width: 50%;">
            <asp:Button ID="BtnLaporanSalesman" runat="server" Text="Perform&#10;Sales" 
                    Width="100%" Height="100%" BackColor="Silver" Font-Bold="True" 
                    ForeColor="Black"  CssClass=""     />
            </td>
            <td style="width: 50%;"  >
               <asp:Button ID="BtnLaporanInsentive" runat="server" Text="Insentive" 
                    Width="100%" Height="100%"
                    BackColor="Silver" Font-Bold="True" ForeColor="Black"  />
            </td>
       </tr>
    </table>
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
    <asp:View ID="View1" runat="server">
      <asp:SqlDataSource ID="sdsTabelPerformance" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM  DATA_SALESPERFORM WHERE ([SALES_MUGEN] LIKE '%' + ? + '%') AND ([SALES_GROUP] LIKE '%' + ? + '%')  ORDER BY SALES_MUGEN,SALES_GROUP"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
           <SelectParameters>
                <asp:ControlParameter ControlID="DropDownListGroupTipe" Name="SALES_MUGEN" 
                    PropertyName="SelectedValue" Type="String" DefaultValue="%" />            
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


  </asp:MultiView>
</asp:Content>
