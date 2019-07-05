<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0203PerformanceSales05UangMuka.aspx.vb" Inherits="Form0203PerformanceSales05UangMuka" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">UANG MUKA JATUH TEMPO </h2>
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
    <asp:MultiView ID="MultiView1Menu" runat="server" Visible="TRUE">
    
    <asp:View ID="View6" runat="server">
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
        </table>

        <asp:SqlDataSource ID="SqlDataUmurBatal" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT TEMP_REPORTBATALDANA.BATALDANA_DEALER, TEMP_REPORTBATALDANA.BATALDANA_NOSPK, TEMP_REPORTBATALDANA.BATALDANA_NAMA, TEMP_REPORTBATALDANA.BATALDANA_TYPE, TEMP_REPORTBATALDANA.BATALDANA_WARNA, TEMP_REPORTBATALDANA.BATALDANA_THN, TEMP_REPORTBATALDANA.BATALDANA_ALASAN, TEMP_REPORTBATALDANA.BATALDANA_UMUR, TEMP_REPORTBATALDANA.BATALDANA_TGL, TEMP_REPORTBATALDANA.BATALDANA_UPDATE, TEMP_REPORTBATALDANA.BATALDANA_JUMLAH, TEMP_REPORTBATALDANA.BATALDANA_SALES, TEMP_REPORTBATALDANA.BATALDANA_SPV, TEMP_REPORTBATALDANA.BATALDANA_TARGET, DATA_TYPE.TYPE_Nama, DATA_WARNA.WARNA_Int FROM TEMP_REPORTBATALDANA LEFT OUTER JOIN DATA_WARNA ON TEMP_REPORTBATALDANA.BATALDANA_WARNA = DATA_WARNA.WARNA_Kode LEFT OUTER JOIN DATA_TYPE ON TEMP_REPORTBATALDANA.BATALDANA_TYPE = DATA_TYPE.TYPE_Type WHERE (TEMP_REPORTBATALDANA.BATALDANA_DEALER = ?) ORDER BY BATALDANA_SPV,BATALDANA_NAMA"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
           <SelectParameters>
                <asp:ControlParameter ControlID="lblArea1" Name="BATALDANA_DEALER" 
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

  </asp:MultiView>
</asp:Content>
