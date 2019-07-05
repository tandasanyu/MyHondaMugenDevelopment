<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0203PerformanceSales09BeliUnit.aspx.vb" Inherits="Form0203PerformanceSales09BeliUnit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">STOK TERAKHIR</h2>
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
            <td style="width: 30%; background-color: #CCCCFF;">
                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Bulan / Tahun"></asp:Label>
            </td>
            <td style="width: 70%; background-color: #CCCCFF;">
                <asp:DropDownList ID="DropDownListTxtBln" runat="server">
                </asp:DropDownList>
                <asp:Label ID="Label40" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="    /    "></asp:Label>
                <asp:DropDownList ID="DropDownListTxtThn" runat="server">
                </asp:DropDownList>
               <asp:Button ID="BtnTampilkan" runat="server" Text="Tampilkan" 
                    BackColor="#003399" 
                    Height="20px" Font-Overline="False" Font-Size="Small" />
                <asp:Label ID="LblProses" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="                   "></asp:Label>
                <asp:Button ID="BtnCetak" runat="server" BackColor="#003399" 
                    Font-Overline="False" Font-Size="Small" Height="20px" Text="Export to Excel" />

            </td>
        </tr>
        </table>



        <asp:ListView ID="LvTabelBBM" 
            runat="server"><LayoutTemplate><table id="table-a"  border="2" width="100%" style="border-collapse:collapse;"><thead  style="background-color:Silver">
            <th>SPK</th><th>NORANGKA</th><th>Polis:Nama STNK</th><th>HP</th><th>NOWO</th><th>TGL WO</th><th>JATU TEMPO</th><th>ASURANSI</th><th>Sales</th><th>SPV</th>
            </thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table>
            </LayoutTemplate><ItemTemplate>
                <tr>
                <td style="width:4%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SPK"  runat="server" Text='<%#Eval("Temp_SPK")%>'/></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_RGK"  runat="server" Text='<%#Eval("Temp_RGK")%>' /></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_NAMA" runat="server" Text='<%#Eval("Temp_NAMA")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_NOHP" runat="server" Text='<%#Eval("Temp_NOHP")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_NOWO" runat="server" Text='<%#Eval("Temp_NOWO")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_TGWO" runat="server" Text='<%#Eval("Temp_TGWO")%>' /></td>
                <td style="width:15%; font-size:x-small" valign="top"><asp:Label ID="Lbl_JTPA" runat="server" Text='<%#Eval("Temp_JTPA")%>' /></td>
                <td style="width:15%; font-size:x-small" valign="top"><asp:Label ID="Lbl_ASUR" runat="server" Text='<%#Eval("Temp_ASUR")%>'/></td>
                <td style="width:15%; font-size:x-small" valign="top"><asp:Label ID="Lbl_NSLS" runat="server" Text='<%#Eval("Temp_NSLS")%>' /></td>
                <td style="width:10%; font-size:x-small" valign="top"><asp:Label ID="Lbl_NSPV" runat="server" Text='<%#Eval("Temp_NSPV")%>' /></td>
                </tr>
                </ItemTemplate>
                </asp:ListView>        

    </asp:View>

  </asp:MultiView>
</asp:Content>
