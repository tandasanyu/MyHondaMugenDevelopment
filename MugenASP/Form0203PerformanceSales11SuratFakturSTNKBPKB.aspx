<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0203PerformanceSales11SuratFakturSTNKBPKB.aspx.vb" Inherits="Form0203PerformanceSales11SuratFakturSTNKBPKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">SURAT-SURAT</h2>
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
            <td style="width: 100%; ">
                <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    height="99%" 
                    Text="Isi kriteria pencarian yang diinginkan jika tidak kosongkan" 
                    Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        </table>

        
        <table style="width: 100%; height:inherit ; font-family: Arial; font-size: small; border-top-color: red; border-top-style: solid; border-top-width: thin; border-bottom-color: red; border-bottom-style: solid; border-bottom-width: thin; border-left-color: red; border-left-style: solid; border-left-width: thin; border-right-color: red; border-right-style: solid; border-right-width: thin;">



        <tr>
            <td style="width: 30%; ">
                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Tanggal Mulai"></asp:Label>
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
                    height="99%" Text=" Sampai dengan "></asp:Label>
            </td>
            <td style="width: 30%; ">
                <asp:TextBox ID="txtTglEnd" Enabled="true"   runat="server" />
                <asp:Button ID="BtnCal1End" runat="server" Text=".." Width="27px" />
                <div id="Div1">
                <asp:Calendar ID="Calendar2" runat="server" onselectionchanged="Calendar2_SelectionChanged" />
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 30%; Background-color:#CCCCFF;">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Nomor SPK"></asp:Label>
            </td>
            <td style="width: 30%;Background-color:#CCCCFF; ">
                <asp:TextBox ID="TxtNoSPK" Enabled="true"   runat="server" />
            </td>
            <td style="width: 10%;Background-color:#CCCCFF; ">
            </td>
            <td style="width: 30%;Background-color:#CCCCFF; ">
            </td>
        </tr>
        <tr>
            <td style="width: 30%; ">
                <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Sales Kode"></asp:Label>
            </td>
            <td style="width: 30%; ">
                <asp:TextBox ID="TxtCdSales" Enabled="true"   runat="server" />
            </td>
            <td style="width: 10%; ">
            </td>
            <td style="width: 30%; ">
            </td>
        </tr>
        <tr>
            <td style="width: 30%; Background-color:#CCCCFF;">
                <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="SPV Kode"></asp:Label>
            </td>
            <td style="width: 30%;Background-color:#CCCCFF; ">
                <asp:TextBox ID="TxtCdSSales" Enabled="true"   runat="server" />
            </td>
            <td style="width: 10%;Background-color:#CCCCFF; ">
            </td>
            <td style="width: 30%;Background-color:#CCCCFF; ">
            </td>
        </tr>
        <tr>
            <td style="width: 30%;">
                <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Proses Ambil Data"></asp:Label>
            </td>
            <td style="width: 30%;">
                <asp:Label ID="LblProses" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Proses Ambil Data"></asp:Label>
            </td>
            <td style="width: 10%;">
            </td>
            <td style="width: 30%;">
            </td>
        </tr>

        </table>
        
        
        <table style="width: 100%; height:inherit ; font-family: Arial; font-size: small; border-top-color: red; border-top-style: solid; border-top-width: thin; border-bottom-color: red; border-bottom-style: solid; border-bottom-width: thin; border-left-color: red; border-left-style: solid; border-left-width: thin; border-right-color: red; border-right-style: solid; border-right-width: thin;">
        <tr>
            <td style="width: 30%; Background-color:#CCCCFF;">
                <asp:Button ID="ButtonSuratFaktur" runat="server" Text="Tampil Faktur" Width="90%" />
            </td>
            <td style="width: 30%;Background-color:#CCCCFF; ">
                <asp:Button ID="ButtonSuratSTNK" runat="server" Text="Tampil S T N K" Width="90%" />
            </td>
            <td style="width: 30%;Background-color:#CCCCFF; ">
                <asp:Button ID="ButtonSuratBPKB" runat="server" Text="Tampil B P K B" Width="90%" />
            </td>
        </tr>
        </table>


        
        <br />
        <br />



        <asp:ListView ID="LvTabelBBM" 
            runat="server"><LayoutTemplate><table id="table-a"  border="2" width="100%" style="border-collapse:collapse;"><thead  style="background-color:Silver">
            <th>Judul</th><th>SPK</th><th>Nama</th><th>Sales</th><th>SPV</th><th>Nomor</th><th>Tgl Proses</th><th>Tgl Input</th><th>Piutang</th><th>Keterangan</th>
            </thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table>
            </LayoutTemplate><ItemTemplate>
                <tr>
                <td style="width:13%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_JUD"  runat="server" Text='<%#Eval("Temp_JUD")%>' /></td>
                <td style="width:05%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SPK"  runat="server" Text='<%#Eval("Temp_SPK")%>'/></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_NAM"  runat="server" Text='<%#Eval("Temp_NAM")%>' /></td>
                <td style="width:05%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SAL"  runat="server" Text='<%#Eval("Temp_SAL")%>' /></td>
                <td style="width:05%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_SPV"  runat="server" Text='<%#Eval("Temp_SPV")%>' /></td>
                <td style="width:10%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_NOM"  runat="server" Text='<%#Eval("Temp_NOM")%>' /></td>
                <td style="width:09%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_TGJ"  runat="server" Text='<%#Eval("Temp_TGJ")%>' /></td>
                <td style="width:09%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_TGI"  runat="server" Text='<%#Eval("Temp_TGI")%>' /></td>
                <td style="width:09%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PIU"  runat="server" Text='<%#Eval("Temp_PIU")%>'/></td>
                <td style="width:15%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_KET"  runat="server" Text='<%#Eval("Temp_KET")%>'/></td>
                </tr>
                </ItemTemplate>
                </asp:ListView>        

    </asp:View>

  </asp:MultiView>
</asp:Content>
