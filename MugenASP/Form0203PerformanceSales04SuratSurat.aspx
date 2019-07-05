<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0203PerformanceSales04SuratSurat.aspx.vb" Inherits="Form0203PerformanceSales04SuratSurat" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">SUMMARY SURAT-SURAT</h2>
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

    <asp:View ID="View5" runat="server">
	  <br />   
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 100%; Background-color:#CCCCFF; ">
            <asp:Button ID="ButtonPsm" runat="server" 
                    Text="Klik Disini untuk menampilkan tabel Data Terbaru" Width="30%" Height="100%"  
                    BackColor="White" Font-Bold="True" ForeColor="Black" BorderStyle="None" 
                    Font-Italic="True" Font-Underline="True" Style=" text-align:left" />
            </td>
        </tr>
        </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
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
        </table>

	  <br />   

        <asp:SqlDataSource ID="SqlDataSurat" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT [WEBREPORT_DEALER], [WEBREPORT_DEPT], [WEBREPORT_GROUP], [WEBREPORT_NAMA], [WEBREPORT_01QTY], [WEBREPORT_04QTY], [WEBREPORT_03RP], [WEBREPORT_03QTY], [WEBREPORT_02RP], [WEBREPORT_02QTY], [WEBREPORT_01RP], [WEBREPORT_04RP], [WEBREPORT_05QTY], [WEBREPORT_05RP], [WEBREPORT_06QTY], [WEBREPORT_06RP], [WEBREPORT_07QTY], [WEBREPORT_07RP], [WEBREPORT_11QTY], [WEBREPORT_08QTY], [WEBREPORT_08RP], [WEBREPORT_09QTY], [WEBREPORT_09RP], [WEBREPORT_10QTY], [WEBREPORT_12RP], [WEBREPORT_12QTY], [WEBREPORT_11RP], [WEBREPORT_10RP] FROM [TEMP_WEBREPORT] WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='C' ORDER BY WEBREPORT_DEALER,WEBREPORT_GROUP"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
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

  </asp:MultiView>
</asp:Content>
