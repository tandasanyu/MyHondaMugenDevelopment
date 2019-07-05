<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"    AutoEventWireup="false" CodeFile="Form0202StatusSPK0302LaporanDetailTrxn.aspx.vb" Inherits="Form0202StatusSPK0302LaporanDetailTrxn" %>

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
    <asp:MultiView ID="MultiViewSearching" runat="server" Visible="TRUE">
    <asp:View ID="View29" runat="server">
        <asp:Label ID="Label22" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px" Font-Bold="True" Font-Italic="True" 
        ForeColor="#0000A0">Pilih Lokasi Cabang Dealer Mugen</asp:Label>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
        <tr>
            <td style="width: 10%; ">
                <asp:Label ID="Label74" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Lokasi Dealer"></asp:Label>
            </td>
            <td style="width: 80%; ">
                <asp:DropDownList ID="DropDownListGroupTipe" runat="server">
                    <asp:ListItem>112</asp:ListItem>
                    <asp:ListItem>128</asp:ListItem>
                </asp:DropDownList>
               <asp:Button ID="ButtonPsm" runat="server" 
                    Text="Klik Disini untuk menampilkan tabel sesuai dealer" Width="54%" Height="100%"  
                    BackColor="White" Font-Bold="True" ForeColor="Black" BorderStyle="None" 
                    Font-Italic="True" Font-Underline="True" Style=" text-align:left" />
                <asp:CheckBox ID="CheckBox1" Text="Perbarui source program" runat="server" />
            </td>
        </tr>
        </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
        <tr>
            <td style="width: 100%; ">
            <center>  <asp:Label ID="lblProsesBox" runat="server" Font-Bold="True" 
                Font-Names="Arial" Font-Size="Small" height="40px"  
                Width="99%" >Prosess</asp:Label></center>
            </td>
        </tr>
        </table>
    </asp:View> 
    </asp:MultiView>
    
    <asp:MultiView ID="MultiViewForm0" runat="server" Visible="TRUE">
        <asp:View ID="ViewForm01" runat="server">
            <asp:SqlDataSource ID="SqlDataSvcWO" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT [WEBREPORT_DEALER], [WEBREPORT_DEPT], [WEBREPORT_GROUP], [WEBREPORT_NAMA], WEBREPORT_TGL,[WEBREPORT_01QTY], [WEBREPORT_04QTY], [WEBREPORT_03RP], [WEBREPORT_03QTY], [WEBREPORT_02RP], [WEBREPORT_02QTY], [WEBREPORT_01RP], [WEBREPORT_04RP], [WEBREPORT_05QTY], [WEBREPORT_05RP], [WEBREPORT_06QTY], [WEBREPORT_06RP], [WEBREPORT_07QTY], [WEBREPORT_07RP], [WEBREPORT_11QTY], [WEBREPORT_08QTY], [WEBREPORT_08RP], [WEBREPORT_09QTY], [WEBREPORT_09RP], [WEBREPORT_10QTY], [WEBREPORT_12RP], [WEBREPORT_12QTY], [WEBREPORT_11RP], [WEBREPORT_10RP] FROM [TEMP_WEBREPORT] WHERE SUBSTRING(WEBREPORT_GROUP,1,1)='A' AND ([WEBREPORT_DEALER] LIKE '%' + ? + '%') ORDER BY WEBREPORT_DEALER,WEBREPORT_GROUP"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
           <SelectParameters>
                <asp:ControlParameter ControlID="DropDownListGroupTipe" Name="WEBREPORT_DEALER" 
                    PropertyName="SelectedValue" Type="String" />            
            </SelectParameters>
        </asp:SqlDataSource>   
        
        <asp:ListView ID="LvWO" runat="server" DataSourceID="SqlDataSvcWO" DataKeyNames ="WEBREPORT_DEALER">
        <LayoutTemplate>
            <table id="table-a" border="2" style="border-collapse:collapse;">
                <thead style="background-color:Red  ; height:30px" ><th>DLR</th><th>KETERANGAN</th><th >BULAN 01</th><th >BULAN 02</th><th >BULAN 03</th><th >BULAN 04</th><th >BULAN 05</th><th >BULAN 06</th><th >BULAN 07</th><th >BULAN 08</th><th >BULAN 09</th><th >BULAN 10</th><th >BULAN 11</th><th >BULAN 12</th><th>UPDATE</th></thead>
                <thead  style="background-color:Red ; height:30px"><th></th><th></th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th>Unit</th><th></th></thead>
                <thead  style="background-color:Red ; height:30px"><th></th><th></th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th>Rupiah</th><th></th></thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
        </LayoutTemplate>
        <ItemTemplate>
        <tr>
        <td rowspan="2" style="width:2%; font-size:small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("WEBREPORT_DEALER") %>' CommandName="Select" runat="server" /></td>
        <td rowspan="2" style="width:20%; font-size:small"><%#Eval("WEBREPORT_NAMA")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_01QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_02QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_03QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_04QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_05QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_06QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_07QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_08QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_09QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_10QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_11QTY", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right"><%#Eval("WEBREPORT_12QTY", "{0:N0}")%></td>
        <td rowspan="2" style="width:6%; font-size: small"><%#Eval("WEBREPORT_TGL")%></td>
        </tr>

        <tr>
        <td style="width:6%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("WEBREPORT_01RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("WEBREPORT_02RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("WEBREPORT_03RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right ; background-color : Silver"><%#Eval("WEBREPORT_04RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_05RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_06RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_07RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_08RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_09RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_10RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_11RP", "{0:N0}")%></td>
        <td style="width:6%; font-size: small; text-align:right; background-color : Silver"><%#Eval("WEBREPORT_12RP", "{0:N0}")%></td>
        </tr>


        </ItemTemplate>
        </asp:ListView>
        
        
        
        </asp:View> 
    </asp:MultiView>


</asp:Content>
