<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"    AutoEventWireup="false" CodeFile="Form0202StatusSPK.aspx.vb" Inherits="Form04PurchaseOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div>
            <center>
                <h2 style="font-family:Cooper Black;">SERVICE</h2>
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
    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Error Message</asp:Label>
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
            <asp:LinkButton ID="LinkButtonSvc0" runat="server" BackColor="White" 
                    ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0202StatusSPK00PersetujuaBukaFaktur.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">01. Persetujuan Buka Faktur</asp:LinkButton>
            </td>            
        </tr>

        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButton2" runat="server" BackColor="White" 
                    ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0202StatusSPK01AuditParts.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">02. Audit Suku Cadang</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br /> 
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonSvc2" runat="server" BackColor="White" 
                    ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0202StatusSPK02CustomerCallFriend.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">03. Status Kendaraan Call Friend</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br /> 
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:Label ID="Label55" runat="server" Font-Names="Arial" Font-Size="Large" 
                        height= "99%" Text="04 Laporan" Font-Bold="True" ForeColor="Blue"></asp:Label>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br /> 
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonSvc31" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0202StatusSPK0301LaporanSummaryTrxn.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">     01 Laporan Summary Transaksi Service</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br /> 
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButtonSvc32" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0202StatusSPK0302LaporanDetailTrxn.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">     02 Laporan Detail Transaksi Service</asp:LinkButton>
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <br /> 
            </td>            
        </tr>
        <tr>
            <td style="width: 100%;height:auto ">
            <asp:LinkButton ID="LinkButton1" runat="server" BackColor="White" ForeColor="Black" Height="100%" 
                PostBackUrl="~/Form0202StatusSPK0303LaporanPiutang.aspx" Width="99%" 
                BorderStyle="None" Font-Underline="True" Font-Size="Large">     03 Laporan Detail Piutang</asp:LinkButton>
            </td>            
        </tr>
     </table>
    </asp:View> 
    </asp:MultiView>

<br />
<br />
     

    


</asp:Content>
