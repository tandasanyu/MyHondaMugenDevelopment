<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"    AutoEventWireup="false" CodeFile="Form0202StatusSPK02CustomerCallFriend.aspx.vb" Inherits="Form0202StatusSPK02CustomerCallFriend" %>

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

<br />
<br />
     
    <asp:MultiView ID="MultiViewForm" runat="server" Visible="TRUE">
         
        <asp:View ID="ViewForm3" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; Background-color:#CCCCFF;">
                   <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "99%" Text="Nomor Polisi"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtQueryServiceNopol" runat="server" text="" Width="10%" AutoPostBack="true" CssClass="uppercase"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Cari" />
                </td>
            </tr>
        </table> 
            
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label18" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama Service Ps Minggu"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="lblQueryServiceNamaPSM" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Rangka"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:Label ID="lblQueryServiceRangkaPSM" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    <asp:Label ID="Label20" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Rangkuman Service Ps Minggu"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:Label ID="lblQueryServiceHistPSM" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;Background-color:#CCCCFF; ">
                    <asp:Label ID="Label19" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Rangkuman Sales Ps Minggu"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:Label ID="lblQuerySalesHistPSM" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>

        </table> 
            
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label16" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama Service Puri"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="lblQueryServiceNamaPuri" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;Background-color:#CCCCFF; ">
                    <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Rangka"></asp:Label>
                </td>
                <td style="width: 75%;Background-color:#CCCCFF; ">
                    <asp:Label ID="lblQueryServiceRangkaPuri" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label17" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Rangkuman Service Puri"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="lblQueryServiceHistPuri" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;Background-color:#CCCCFF; ">
                    <asp:Label ID="Label21" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Rangkuman Sales Puri"></asp:Label>
                </td>
                <td style="width: 75%;Background-color:#CCCCFF; ">
                    <asp:Label ID="lblQuerySalesHistPuri" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama"></asp:Label>
                </td>
            </tr>

            </table> 
        </asp:View> 
    </asp:MultiView>
    


</asp:Content>
