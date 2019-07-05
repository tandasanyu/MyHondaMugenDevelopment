<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0205WarehouseReport03.aspx.vb" Inherits="Form0205WarehouseReport03" %>
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
                <asp:DropDownList ID="DropDownListGroupLokasi" runat="server">
                    <asp:ListItem>112</asp:ListItem>
                    <asp:ListItem>128</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 30%;  ">
                <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Pencarian Tanggal Berdasarkan"></asp:Label>
            </td>
            <td style="width: 70%; ">
                <asp:DropDownList ID="DropDownListGroupCari" runat="server">
                    <asp:ListItem>Tanggal Kirim</asp:ListItem>
                    <asp:ListItem>Tanggal Email Suplier</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        </table>
        
        <table style="width: 100%; height:inherit ; font-family: Arial; font-size: small; border-top-color: red; border-top-style: solid; border-top-width: thin; border-bottom-color: red; border-bottom-style: solid; border-bottom-width: thin; border-left-color: red; border-left-style: solid; border-left-width: thin; border-right-color: red; border-right-style: solid; border-right-width: thin;">
        <tr>
            <td style="width: 30%; Background-color:#CCCCFF;">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Tanggal Mulai"></asp:Label>
            </td>
            <td style="width: 30%;Background-color:#CCCCFF; ">
                <asp:TextBox ID="txtTglStart" Enabled="true"   runat="server" />
                <asp:Button ID="BtnCal1Start" runat="server" Text=".." Width="27px" />
                <div id="tanggalPopup">
                <asp:Calendar ID="Calendar1" runat="server" onselectionchanged="Calendar1_SelectionChanged" />
                </div>
            </td>
            <td style="width: 10%;Background-color:#CCCCFF; ">
                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text=" Sampai dengan "></asp:Label>
            </td>
            <td style="width: 30%;Background-color:#CCCCFF; ">
                <asp:TextBox ID="txtTglEnd" Enabled="true"   runat="server" />
                <asp:Button ID="BtnCal1End" runat="server" Text=".." Width="27px" />
                <div id="Div1">
                <asp:Calendar ID="Calendar2" runat="server" onselectionchanged="Calendar2_SelectionChanged" />
                </div>
            </td>
        </tr>
        </table>
        <br />
        <br />
        
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
            <th>No WO</th><th>Aksesoris</th><th>Tipe</th><th>Rangka</th><th>Suplier</th>
            <th>Tgl WO</th><th>Email</th><th>Tgl Pasang</th><th>Input Pasang</th><th>Unit Kirim</th><th>Unit Terima</th>
            <th>Dlr</th><th>SPK</th>
            </thead>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_PsgAksesorisNoWO"  runat="server" Text='<%#Eval("Temp_PsgAksesorisNoWo")%>'/></td>
                <td style="width:13%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PsgAksesorisNmAs"  runat="server" Text='<%#Eval("Temp_PsgAksesorisNmAs")%>' /></td>
                <td style="width:13%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PsgAksesorisTipe"  runat="server" Text='<%#Eval("Temp_PsgAksesorisTipe")%>' /></td>
                <td style="width:13%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_PsgAksesorisRngk"  runat="server" Text='<%#Eval("Temp_PsgAksesorisRngk")%>'/></td>
                <td style="width:13%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_PsgAksesorisSupl"  runat="server" Text='<%#Eval("Temp_PsgAksesorisSupl")%>' /></td>
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_PsgAksesorisTgWo"  runat="server" Text='<%#Eval("Temp_PsgAksesorisTgWo")%>' /></td>
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_PsgAksesorisTgEm"  runat="server" Text='<%#Eval("Temp_PsgAksesorisTgEm")%>' /></td>
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_PsgAksesorisTgPg"  runat="server" Text='<%#Eval("Temp_PsgAksesorisTgPg")%>' /></td>
                <td style="width:6%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_PsgAksesorisInPg"  runat="server" Text='<%#Eval("Temp_PsgAksesorisInPg")%>' /></td>
                <td style="width:6%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_PsgAksesorisTgKm"  runat="server" Text='<%#Eval("Temp_PsgAksesorisTgKm")%>'/></td>
                <td style="width:6%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_PsgAksesorisTgTr"  runat="server" Text='<%#Eval("Temp_PsgAksesorisTgTr")%>'/></td>
                <td style="width:3%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_PsgAksesorisDler"  runat="server" Text='<%#Eval("Temp_PsgAksesorisDler")%>'/></td>
                <td style="width:4%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_PsgAksesorisNoSP"  runat="server" Text='<%#Eval("Temp_PsgAksesorisNoSP")%>'/></td>
                </tr>
                </ItemTemplate><SelectedItemTemplate>
                <tr id="Tr1" runat="server" style="background-color:#ADD8E6">
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_PsgAksesorisNoWO"  runat="server" Text='<%#Eval("Temp_PsgAksesorisNoWo")%>'/></td>
                <td style="width:13%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PsgAksesorisNmAs"  runat="server" Text='<%#Eval("Temp_PsgAksesorisNmAs")%>' /></td>
                <td style="width:13%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PsgAksesorisTipe"  runat="server" Text='<%#Eval("Temp_PsgAksesorisTipe")%>' /></td>
                <td style="width:13%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_PsgAksesorisRngk"  runat="server" Text='<%#Eval("Temp_PsgAksesorisRngk")%>'/></td>
                <td style="width:13%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_PsgAksesorisSupl"  runat="server" Text='<%#Eval("Temp_PsgAksesorisSupl")%>' /></td>
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_PsgAksesorisTgWo"  runat="server" Text='<%#Eval("Temp_PsgAksesorisTgWo")%>' /></td>
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_PsgAksesorisTgEm"  runat="server" Text='<%#Eval("Temp_PsgAksesorisTgEm")%>' /></td>
                <td style="width:6%; font-size:x-small"  valign="top"><asp:Label  ID="Lbl_PsgAksesorisTgPg"  runat="server" Text='<%#Eval("Temp_PsgAksesorisTgPg")%>' /></td>
                <td style="width:6%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_PsgAksesorisInPg"  runat="server" Text='<%#Eval("Temp_PsgAksesorisInPg")%>' /></td>
                <td style="width:6%; font-size:x-small" valign="top"><asp:Label   ID="Lbl_PsgAksesorisTgKm"  runat="server" Text='<%#Eval("Temp_PsgAksesorisTgKm")%>'/></td>
                <td style="width:6%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_PsgAksesorisTgTr"  runat="server" Text='<%#Eval("Temp_PsgAksesorisTgTr")%>'/></td>
                <td style="width:3%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_PsgAksesorisDler"  runat="server" Text='<%#Eval("Temp_PsgAksesorisDler")%>'/></td>
                <td style="width:4%; font-size:x-small" valign="top"><asp:Label  ID="Lbl_PsgAksesorisNoSP"  runat="server" Text='<%#Eval("Temp_PsgAksesorisNoSP")%>'/></td>
                </tr>
                </SelectedItemTemplate></asp:ListView>        

    </asp:View>

  </asp:MultiView>
</asp:Content>
