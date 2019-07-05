<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0203PerformanceSales06FakturJadi.aspx.vb" Inherits="Form0203PerformanceSales06FakturJadi" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">FAKTUR JADI</h2>
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
        <tr>
            <td style="width: 30%; ">
                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Tanggal Update Terakhir"></asp:Label>
            </td>
            <td style="width: 70%; ">
                <asp:CheckBox ID="CheckBoxPerbarui" Text="Perbarui report" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 30%; Background-color:#CCCCFF; ">
            </td>
            <td style="width: 70%; Background-color:#CCCCFF; ">
            <asp:Button ID="ButtonPsm" runat="server" 
                    Text="Klik Disini untuk menampilkan tabel sesuai dealer atau perbaharui" 
                    Width="71%" Height="100%"  
                    BackColor="White" Font-Bold="True" ForeColor="Black" BorderStyle="None" 
                    Font-Italic="True" Font-Underline="True" Style=" text-align:left" />
            </td>
        </tr>
        <tr>
            <td style="width: 30%; ">
                <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height="99%" Text="Status Proses Update"></asp:Label>
            </td>
            <td style="width: 70%; ">
            <asp:Label ID="lblProsesBox" runat="server" Font-Bold="True" 
                Font-Names="Arial" Font-Size="Small" height="40px" Width="99%" >Prosess</asp:Label>
            </td>
        </tr>
        </table>

    
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;"> 
        <tr>
            <td style="width: 30%; Background-color:#CCCCFF;">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Pencarian berdasarkan Sales</asp:Label>
            </td>
            <td style="width: 70%; Background-color:#CCCCFF;">
                <asp:TextBox ID="TxtCariFakturSales" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 30%; ">
                <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Pencarian berdasarkan SPV</asp:Label>
            </td>
            <td style="width: 70%; ">
                <asp:TextBox ID="TxtCariFakturSPV" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
            </td>
        </tr>
    </table>
        <asp:SqlDataSource ID="sdsTabelFaktur" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * FROM TEMP_NOTIFY WHERE NOTIFY_TYPE='FAKTUR' AND NOTIFY_AREA LIKE '%' + ? + '%' AND NOTIFY_SALES LIKE '%' + ? + '%'  AND NOTIFY_SPV LIKE '%' + ? + '%' ORDER BY NOTIFY_TGL1"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                <SelectParameters>
                <asp:ControlParameter ControlID="lblArea1"           Name="NOTIFY_AREA"              PropertyName="Text" Type="String" />            
                <asp:ControlParameter ControlID="TxtCariFakturSales" Name="NOTIFY_SALES"             PropertyName="Text" Type="String" DefaultValue="%"  />            
                <asp:ControlParameter ControlID="TxtCariFakturSPV" Name="NOTIFY_SPV"             PropertyName="Text" Type="String" DefaultValue="%"  />            
                </SelectParameters>
        </asp:SqlDataSource>    
        <asp:ListView ID="lvFaktur" runat="server" DataSourceID="sdsTabelFaktur" DataKeyNames ="NOTIFY_AREA">
        <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                    <thead style="background-color:Gray; font-size:small  ;height:50px" >
                      <th>Dealer</th><th>Tipe</th>
                      <th>SPK</th><th>Nama SPK</th><th>Nama Faktur/STNK</th>
                      <th>Sales</th><th>SPV</th>                                            
                      <th>Tgl Jadi</th><th>Tgl WO</th>                      
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            <asp:DataPager ID="dpBerita" PageSize="200" runat="server">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                ShowNextPageButton="false" ShowLastPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                ShowNextPageButton="true" ShowLastPageButton="true" />
            </Fields>
            </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
                <tr>
                    <td style="width:3%; font-size: x-small"><%#Eval("NOTIFY_AREA")%></td>
                    <td style="width:5%; font-size: x-small"><%#Eval("NOTIFY_TYPE")%></td>
                    <td style="width:5%; font-size: x-small"><%#Eval("NOTIFY_NOSPK")%></td>
                    <td style="width:19%; font-size: x-small"><%#Eval("NOTIFY_NAMA1")%></td>
                    <td style="width:19%; font-size: x-small"><%#Eval("NOTIFY_NAMA2")%></td>
                    <td style="width:20%; font-size: x-small"><%#Eval("NOTIFY_SALES")%></td>
                    <td style="width:5%; font-size: x-small"><%#Eval("NOTIFY_SPV")%></td>
                    <td style="width:12%; font-size: x-small"><%#Eval("NOTIFY_TGL1")%></td>
                    <td style="width:12%; font-size: x-small"><%#Eval("NOTIFY_TGL2")%></td>
                </tr>
        </ItemTemplate>
        </asp:ListView>

    </asp:View>

  </asp:MultiView>
</asp:Content>
