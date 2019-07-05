<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0203PerformanceSales12Wifi.aspx.vb" Inherits="Form0203PerformanceSales12Wifi" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">Password Wifi Sales</h2>
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

            
            <asp:SqlDataSource ID="SdsDataWifiDetail112" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet112 %>" 
            SelectCommand="SELECT [HotSpot_Password], [HotSpot_User], [HotSpot_Used], [HotSpot_TglUsed], [HotSpot_Status] FROM [DATA_HOTSPOT] WHERE ([HotSpot_TglUsed] IS NULL) ORDER BY [HotSpot_Password]"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet112.ProviderName %>">
            </asp:SqlDataSource>                 
            <asp:ListView ID="LvWifi112" runat="server" DataKeyNames="HotSpot_Password" DataSourceID="SdsDataWifiDetail112">
                <LayoutTemplate>
                    <table border="2" style="border-collapse:collapse;" width="100%">
                        <thead  style="background-color:Silver; height:30px">
                        <th>Kata Kunci</th><th>Status</th><th>Dipergunakan</th>
                        </thead>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
                    <asp:DataPager ID="dpBerita" runat="server" PageSize="5">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="true" 
                                ShowLastPageButton="false" ShowNextPageButton="false" 
                                ShowPreviousPageButton="true" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowFirstPageButton="false" 
                                ShowLastPageButton="true" ShowNextPageButton="true" 
                                ShowPreviousPageButton="false" />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                    <td style="width:20%; font-size:small">
                       <asp:LinkButton ID="LinkButton1" Text='<%# Eval("HotSpot_Password") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:40%; font-size: small"><%#Eval("HotSpot_Status")%></td>
                    <td style="width:40%; font-size: small"><%#Eval("HotSpot_TglUsed")%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            


    </asp:View>

  </asp:MultiView>
</asp:Content>
