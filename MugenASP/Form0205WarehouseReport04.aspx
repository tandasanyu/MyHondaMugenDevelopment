<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0205WarehouseReport04.aspx.vb" Inherits="Form0205WarehouseReport04" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">Laporan Pasang Aksesoris</h2>
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





    <asp:MultiView ID="MultiView1menu" runat="server" Visible="TRUE">
    <asp:View ID="View8" runat="server">
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
        
        <table style="width: 100%; height:inherit ; font-family: Arial; font-size: small; border-top-color: red; border-top-style: solid; border-top-width: thin; border-bottom-color: red; border-bottom-style: solid; border-bottom-width: thin; border-left-color: red; border-left-style: solid; border-left-width: thin; border-right-color: red; border-right-style: solid; border-right-width: thin;">
        <tr>
            <td style="width: 30%; ">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Pencarian Dari Tanggal DO "></asp:Label>
            </td>
            <td style="width: 30%; ">
                <asp:TextBox ID="txtTglStart" Enabled="true"   runat="server" />
                <asp:Button ID="BtnCal1Start" runat="server" Text=".." Width="27px" />
                <div id="tanggalPopup">
                <asp:Calendar ID="Calendar1" runat="server" onselectionchanged="Calendar1_SelectionChanged" />
                </div>
            </td>
            <td style="width: 10%; ">
                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Sampai dengan"></asp:Label>
            </td>
            <td style="width: 30%; ">
                <asp:TextBox ID="txtTglEnd" Enabled="true"   runat="server" />
                <asp:Button ID="BtnCal1End" runat="server" Text=".." Width="27px" />
                <div id="Div1">
                <asp:Calendar ID="Calendar2" runat="server" onselectionchanged="Calendar2_SelectionChanged" />
                </div>
            </td>
        </tr>
        </table>
        
        <table style="width: 100%; height:inherit ; font-family: Arial; font-size: small; border-top-color: red; border-top-style: solid; border-top-width: thin; border-bottom-color: red; border-bottom-style: solid; border-bottom-width: thin; border-left-color: red; border-left-style: solid; border-left-width: thin; border-right-color: red; border-right-style: solid; border-right-width: thin;">
        <tr>
            <td style="width: 30%; background-color: #CCCCFF;">
                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Tampilkan"></asp:Label>
            </td>
            <td style="width: 70%; background-color: #CCCCFF;">
               <asp:Button ID="Button2" runat="server" Text="TAMPILAN" 
                    BackColor="#003399" 
                    Height="20px" Font-Overline="False" Font-Size="Small" Width="107px" />

                <asp:Label ID="LblProses" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="                   "></asp:Label>

                <asp:Button ID="BtnCetak" runat="server" BackColor="#003399" 
                    Font-Overline="False" Font-Size="Small" Height="20px" Text="Export to Excel" />
            </td>
        </tr>
        </table>


    </asp:View>

  </asp:MultiView>
    <asp:MultiView ID="MultiView1" runat="server" Visible="TRUE">
    <asp:View ID="View1" runat="server">
        <asp:ListView ID="LvTabelSPK" 
            runat="server"
        OnSelectedIndexChanging="TblDetailStockView_SelectedIndexChanging" 
        OnPagePropertiesChanging="TblDetailStockView_PagePropertiesChanging"
            >
        <LayoutTemplate><table id="table-a"  border="2" width="100%" style="border-collapse:collapse;"><thead  style="background-color:Silver">
            <th>.....</th><th>Rangka</th><th>SPK</th><th>Dealer</th><th>Tgl DO</th><th>SPJ</th><th>Terima</th>
            <th>Nama SPK</th><th>Sales</th><th>SPV</th><th>Tipe</th><th>Warna</th>
            </thead>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width:10%; font-size: small">
                       <asp:LinkButton ID="lnkSelect" Text='Detail Asesoris' CommandName="Select" runat="server" />
                    </td>
                <td style="width:11%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_DORgk"  runat="server" Text='<%#Eval("Temp_DORgk")%>' /></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label   ID="Lbl_DOSpk"  runat="server" Text='<%#Eval("Temp_DOSpk")%>' /></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_DODlr"  runat="server" Text='<%#Eval("Temp_DODlr")%>'/></td>
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_DOTgl"  runat="server" Text='<%#Eval("Temp_DOTgl")%>' /></td>
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_DOSpj"  runat="server" Text='<%#Eval("Temp_DOSpj")%>' /></td>
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_DOTrm"  runat="server" Text='<%#Eval("Temp_DOTrm")%>' /></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_DONam"  runat="server" Text='<%#Eval("Temp_DONam")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_DOSls"  runat="server" Text='<%#Eval("Temp_DOSls")%>' /></td>
                <td style="width:3%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_DOSpv"  runat="server" Text='<%#Eval("Temp_DOSpv")%>' /></td>
                <td style="width:12%; font-size:x-small"   valign="top"><asp:Label  ID="Lbl_DOTip"  runat="server" Text='<%#Eval("Temp_DOTip")%>' /></td>
                <td style="width:12%; font-size:x-small"   valign="top"><asp:Label  ID="Lbl_DOWar"  runat="server" Text='<%#Eval("Temp_DOWar")%>' /></td>
                </tr>
                </ItemTemplate><SelectedItemTemplate>
                    <td>&nbsp;</td>
                <tr id="Tr1" runat="server" style="background-color:#ADD8E6">
                <td style="width:11%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_DORgk"  runat="server" Text='<%#Eval("Temp_DORgk")%>' /></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label   ID="Lbl_DOSpk"  runat="server" Text='<%#Eval("Temp_DOSpk")%>' /></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_DODlr"  runat="server" Text='<%#Eval("Temp_DODlr")%>'/></td>
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_DOTgl"  runat="server" Text='<%#Eval("Temp_DOTgl")%>' /></td>
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_DOSpj"  runat="server" Text='<%#Eval("Temp_DOSpj")%>' /></td>
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_DOTrm"  runat="server" Text='<%#Eval("Temp_DOTrm")%>' /></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_DONam"  runat="server" Text='<%#Eval("Temp_DONam")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_DOSls"  runat="server" Text='<%#Eval("Temp_DOSls")%>' /></td>
                <td style="width:3%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_DOSpv"  runat="server" Text='<%#Eval("Temp_DOSpv")%>' /></td>
                <td style="width:12%; font-size:x-small"   valign="top"><asp:Label  ID="Lbl_DOTip"  runat="server" Text='<%#Eval("Temp_DOTip")%>' /></td>
                <td style="width:12%; font-size:x-small"   valign="top"><asp:Label  ID="Lbl_DOWar"  runat="server" Text='<%#Eval("Temp_DOWar")%>' /></td>

                </tr>
                </SelectedItemTemplate></asp:ListView>        
    </asp:View>
    <asp:View ID="View2" runat="server">
         <asp:Button ID="Button1" runat="server" Text="<---- Kembali ke halaman SPK" 
         BackColor="Red"  
         Height="20px" Font-Overline="False" Font-Size="Small" Width="274px" />

    
        <asp:ListView ID="LvTabelASS" 
            runat="server"><LayoutTemplate><table id="table-a"  border="2" width="100%" style="border-collapse:collapse;"><thead  style="background-color:Silver">
            <th>SPK</th><th>Dealer</th><th>No WO</th><th>Nama Asesoris</th>
            <th>Sales</th><th>SPV</th><th>Suplier</th>
            </thead>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label   ID="Lbl_WOSpk"  runat="server" Text='<%#Eval("Temp_DOSpk")%>' /></td>
                <td style="width:6%; font-size:x-small"   valign="top"><asp:Label  ID="Lbl_WODlr"  runat="server" Text='<%#Eval("Temp_DODlr")%>'/></td>
                <td style="width:8%; font-size:x-small"  valign="top"><asp:Label   ID="Lbl_WONom"  runat="server" Text='<%#Eval("Temp_DOTgl")%>' /></td>
                <td style="width:15%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WONam"  runat="server" Text='<%#Eval("Temp_DONam")%>'/></td>
                <td style="width:15%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WOSls"  runat="server" Text='<%#Eval("Temp_DOSls")%>' /></td>
                <td style="width:15%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WOSpv"  runat="server" Text='<%#Eval("Temp_DOSpv")%>' /></td>
                <td style="width:15%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WOSup"  runat="server" Text='<%#Eval("Temp_DOTip")%>' /></td>

                </tr>
                </ItemTemplate><SelectedItemTemplate>
                <tr id="Tr1" runat="server" style="background-color:#ADD8E6">
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label   ID="Lbl_WOSpk"  runat="server" Text='<%#Eval("Temp_DOSpk")%>' /></td>
                <td style="width:6%; font-size:x-small"   valign="top"><asp:Label  ID="Lbl_WODlr"  runat="server" Text='<%#Eval("Temp_DODlr")%>'/></td>
                <td style="width:8%; font-size:x-small"  valign="top"><asp:Label   ID="Lbl_WONom"  runat="server" Text='<%#Eval("Temp_DOTgl")%>' /></td>
                <td style="width:15%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WONam"  runat="server" Text='<%#Eval("Temp_DONam")%>'/></td>
                <td style="width:15%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WOSls"  runat="server" Text='<%#Eval("Temp_DOSls")%>' /></td>
                <td style="width:15%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WOSpv"  runat="server" Text='<%#Eval("Temp_DOSpv")%>' /></td>
                <td style="width:15%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WOSup"  runat="server" Text='<%#Eval("Temp_DOTip")%>' /></td>
                </tr>
                </SelectedItemTemplate></asp:ListView>        
    </asp:View>

  </asp:MultiView>

</asp:Content>
