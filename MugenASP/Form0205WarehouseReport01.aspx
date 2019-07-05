<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0205WarehouseReport01.aspx.vb" Inherits="Form0205WarehouseReport01" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">Laporan Kirim Kendaraan</h2>
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
                    height="99%" Text="Pencarian Dari Tanggal Kirim"></asp:Label>
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
                <asp:Button ID="Button2" runat="server" BackColor="#003399" 
                    Font-Overline="False" Font-Size="Small" Height="20px" Text="TAMPILAN" 
                    Width="107px" />
                <asp:Label ID="LblProses" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="                   "></asp:Label>
               <asp:Button ID="BtnCetak" runat="server" Text="Export to Excel" 
                    BackColor="#003399" 
                    Height="20px" Font-Overline="False" Font-Size="Small" />

            </td>
        </tr>
        </table>

        <asp:ListView ID="LvTabelBBM" 
            runat="server"><LayoutTemplate><table id="table-a"  border="2" width="100%" style="border-collapse:collapse;"><thead  style="background-color:Silver">
            <th>Rangka</th><th>Input Mohon</th><th>Mohon</th><th>Setuju</th><th>Kirim</th><th>Terima</th><th>Input Terima</th><th>Dlr</th>
            <th>Tipe</th><th>Sales</th><th>SPK</th><th>DO</th><th>Lokasi Unit</th><th>Hp/Telepon</th><th>Pembeli</th><th>Alamat</th><th>Keterangan</th>
            </thead>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_KirimRangka"  runat="server" Text='<%#Eval("Temp_KirimRangka")%>'/></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_KirimInput"  runat="server" Text='<%#Eval("Temp_KirimInput")%>'/></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_KirimMohon"  runat="server" Text='<%#Eval("Temp_KirimMohon")%>' /></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_KirimSetuj"  runat="server" Text='<%#Eval("Temp_KirimSetuj")%>' /></td>
                <td style="width:8%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_KirimActual" runat="server" Text='<%#Eval("Temp_KirimActual", "{0:C}")%>'/></td>
                <td style="width:8%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_KirimTerima" runat="server" Text='<%#Eval("Temp_KirimTerima")%>' /></td>
                <td style="width:8%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_KirimTrmInp" runat="server" Text='<%#Eval("Temp_KirimTrmInp")%>' /></td>
                <td style="width:8%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimDlr"    runat="server" Text='<%#Eval("Temp_KirimDlr")%>' /></td>
                <td style="width:7%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimTipe"   runat="server" Text='<%#Eval("Temp_KirimTipe")%>'/></td>
                <td style="width:9%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_KirimSales"  runat="server" Text='<%#Eval("Temp_KirimSales")%>'/></td>
                <td style="width:8%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_KirimSPK"    runat="server" Text='<%#Eval("Temp_KirimSPK")%>'/></td>
                <td style="width:5%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimDO"     runat="server" Text='<%#Eval("Temp_KirimDO")%>'/></td>
                <td style="width:5%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimHP"     runat="server" Text='<%#Eval("Temp_KirimHP")%>'/></td>
                <td style="width:5%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimPHONE"  runat="server" Text='<%#Eval("Temp_KirimPHONE")%>'/></td>
                <td style="width:5%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimCust"   runat="server" Text='<%#Eval("Temp_KirimCust")%>'/></td>
                <td style="width:5%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimAlamat" runat="server" Text='<%#Eval("Temp_KirimAlamat")%>'/></td>
                <td style="width:5%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimNote"   runat="server" Text='<%#Eval("Temp_KirimNote")%>'/></td>
                </tr>
                </ItemTemplate><SelectedItemTemplate>
                <tr id="Tr1" runat="server" style="background-color:#ADD8E6">
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_KirimRangka"  runat="server" Text='<%#Eval("Temp_KirimRangka")%>'/></td>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_KirimInput"  runat="server" Text='<%#Eval("Temp_KirimInput")%>'/></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_KirimMohon"  runat="server" Text='<%#Eval("Temp_KirimMohon")%>' /></td>
                <td style="width:12%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_KirimSetuj"  runat="server" Text='<%#Eval("Temp_KirimSetuj")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_KirimActual" runat="server" Text='<%#Eval("Temp_KirimActual", "{0:C}")%>'/></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_KirimTerima" runat="server" Text='<%#Eval("Temp_KirimTerima")%>' /></td>
                <td style="width:9%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_KirimTrmInp" runat="server" Text='<%#Eval("Temp_KirimTrmInp")%>' /></td>
                <td style="width:8%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimDlr"    runat="server" Text='<%#Eval("Temp_KirimDlr")%>' /></td>
                <td style="width:7%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimTipe"   runat="server" Text='<%#Eval("Temp_KirimTipe")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_KirimSales"  runat="server" Text='<%#Eval("Temp_KirimSales")%>'/></td>
                <td style="width:12%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_KirimSPK"    runat="server" Text='<%#Eval("Temp_KirimSPK")%>'/></td>
                <td style="width:5%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimDO"     runat="server" Text='<%#Eval("Temp_KirimDO")%>'/></td>
                <td style="width:5%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimHP"     runat="server" Text='<%#Eval("Temp_KirimHP")%>'/></td>
                <td style="width:5%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimPHONE"  runat="server" Text='<%#Eval("Temp_KirimPHONE")%>'/></td>
                <td style="width:5%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimCust"   runat="server" Text='<%#Eval("Temp_KirimCust")%>'/></td>
                <td style="width:5%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimAlamat" runat="server" Text='<%#Eval("Temp_KirimAlamat")%>'/></td>
                <td style="width:5%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_KirimNote"   runat="server" Text='<%#Eval("Temp_KirimNote")%>'/></td>
                </tr>
                </SelectedItemTemplate></asp:ListView>        


    </asp:View>

  </asp:MultiView>
</asp:Content>
