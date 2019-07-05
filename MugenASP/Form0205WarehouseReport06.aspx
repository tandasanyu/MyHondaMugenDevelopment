<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0205WarehouseReport06.aspx.vb" Inherits="Form0205WarehouseReport06" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">Laporan Unit Masuk berdasrkan Tanggal TTK</h2>
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
        
        <table style="width: 100%; height:inherit ; font-family: Arial; font-size: small; border-top-color: red; border-top-style: solid; border-top-width: thin; border-bottom-color: red; border-bottom-style: solid; border-bottom-width: thin; border-left-color: red; border-left-style: solid; border-left-width: thin; border-right-color: red; border-right-style: solid; border-right-width: thin;">
        <tr>
            <td style="width: 30%; ">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Pencarian Dari Tanggal Input Unit / TTK"></asp:Label>
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

        <asp:ListView ID="LvTabelBBM" 
            runat="server"><LayoutTemplate><table id="table-a"  border="2" width="100%" style="border-collapse:collapse;"><thead  style="background-color:Silver">
            <th>Tgl TTK</th><th>No TTK</th><th>Warna</th><th>Tipe</th><th>Rangka</th><th>Mesin</th><th>Lokasi</th>
            <th>Suplier</th><th>Tgl Terima</th>
            </thead>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_GesekNoTTK"  runat="server" Text='<%#Eval("Temp_GesekNoTTK")%>'/></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_GesekTgTTK"  runat="server" Text='<%#Eval("Temp_GesekTgTTK")%>' /></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_GesekWarna"  runat="server" Text='<%#Eval("Temp_GesekWarna")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_GesekTipe"   runat="server" Text='<%#Eval("Temp_GesekTipe")%>'/></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_GesekRangka" runat="server" Text='<%#Eval("Temp_GesekRangka")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_GesekMesin"  runat="server" Text='<%#Eval("Temp_GesekMesin")%>' /></td>
                <td style="width:8%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_GesekLokasi" runat="server" Text='<%#Eval("Temp_GesekLokasi")%>' /></td>
                <td style="width:7%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_GesekSuplier" runat="server" Text='<%#Eval("Temp_GesekTglInp")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_GesekTglTrm" runat="server" Text='<%#Eval("Temp_GesekTglTrm")%>'/></td>
                </tr>
                </ItemTemplate><SelectedItemTemplate>
                <tr id="Tr1" runat="server" style="background-color:#ADD8E6">
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_GesekNoTTK"  runat="server" Text='<%#Eval("Temp_GesekNoTTK")%>'/></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_GesekTgTTK"  runat="server" Text='<%#Eval("Temp_GesekTgTTK")%>' /></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_GesekWarna"  runat="server" Text='<%#Eval("Temp_GesekWarna")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_GesekTipe"   runat="server" Text='<%#Eval("Temp_GesekTipe")%>'/></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_GesekRangka" runat="server" Text='<%#Eval("Temp_GesekRangka")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_GesekMesin"  runat="server" Text='<%#Eval("Temp_GesekMesin")%>' /></td>
                <td style="width:8%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_GesekLokasi" runat="server" Text='<%#Eval("Temp_GesekLokasi")%>' /></td>
                <td style="width:7%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_GesekTglInp" runat="server" Text='<%#Eval("Temp_GesekTglInp")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_GesekTglTrm" runat="server" Text='<%#Eval("Temp_GesekTglTrm")%>'/></td>
                </tr>
                </SelectedItemTemplate></asp:ListView>        


    </asp:View>

  </asp:MultiView>
</asp:Content>
