<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0203PerformanceSales.aspx.vb" Inherits="Form0203PerformanceSales" %>
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

    <asp:MultiView ID="MultiViewMenu" runat="server" Visible="TRUE">
    <asp:View ID="View16" runat="server">
      <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Pilihan Menu (Klik yang ada garis bawahnya)</h2>
            </center>
	  </div>  
    <table style="width: 100%; height:auto ; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonPerfomrSls01" runat="server" BackColor="White" 
                    ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0203PerformanceSales01Salesman.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">01. Performance Salesman</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br />
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonPerfomrSls02" runat="server" BackColor="White" 
                    ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0203PerformanceSales02PiutangSPK.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">02. Piutang</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br />
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonPerfomrSls03" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0203PerformanceSales03Leasing.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">03. Sales per leasing</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br />
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonPerfomrSls04" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0203PerformanceSales04SuratSurat.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">04. Surat-Surat</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br />
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonPerfomrSls05" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0203PerformanceSales05UangMuka.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">05. Uang Muka</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br />
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonPerfomrSls06" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0203PerformanceSales06FakturJadi.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">06. Faktur Jadi</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br />
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonPerfomrSls07" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0203PerformanceSales07DOTenor.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">07. Do Tenor</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br />
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonPerfomrSls08" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0203PerformanceSales08JTPAsuransi.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">08. Asuransi Jatuh Tempo</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br />
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonPerfomrSls09" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0203PerformanceSales09BeliUnit.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">09. Stok Terakhir</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br />
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonPerfomrSls10" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0203PerformanceSales10Sales.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">10. Penjualan Unit</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br />
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonPerfomrSls11" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0203PerformanceSales11SuratFakturSTNKBPKB.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">11. Surat-surat Faktur/STNK/BPKB</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br />
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonPerfomrSls12" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0203PerformanceSales12Wifi.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">12. Wifi Sales Password</asp:LinkButton>
            </td>            
        </tr>


     </table>
    </asp:View> 
    </asp:MultiView>
</asp:Content>
