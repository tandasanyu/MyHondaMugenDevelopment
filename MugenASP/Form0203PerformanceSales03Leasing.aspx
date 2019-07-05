<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0203PerformanceSales03Leasing.aspx.vb" Inherits="Form0203PerformanceSales03Leasing" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <div>
            <center>
                <h2 style="font-family:Cooper Black;">PENJUALAN PER CARA BAYAR</h2>
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
    
    <asp:View ID="View4" runat="server">
      
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 100%; Background-color:#CCCCFF; ">
            <asp:Button ID="ButtonPsm" runat="server" 
                    Text="Klik Disini untuk menampilkan tabel Data Terbaru" Width="30%" Height="100%"  
                    BackColor="White" Font-Bold="True" ForeColor="Black" BorderStyle="None" 
                    Font-Italic="True" Font-Underline="True" Style=" text-align:left" />
            </td>
        </tr>
        </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
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
	  
        <asp:SqlDataSource ID="sdsTabelLeasPerformance" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>" 
            SelectCommand="SELECT * FROM  REPORT_SPKLEASE ORDER BY SPKLEASE_DEALER,SPKLEASE_KODE">
        </asp:SqlDataSource>
        <asp:ListView ID="LvPerolehanLeasing" runat="server" 
            DataKeyNames="SPKLEASE_KODE" DataSourceID="sdsTabelLeasPerformance">
            <LayoutTemplate>
                <table id="table-a" border="2" style="border-collapse:collapse;" width="100%">
                    <thead style="background-color:Red  ; height:30px">
                        <th>
                            DLR</th>
                        <th>
                            KODE</th>
                        <th>
                            NAMA LEASING</th>
                        <th>
                            BLN 01</th>
                        <th>
                            BLN 02</th>
                        <th>
                            BLN 03</th>
                        <th>
                            BLN 04</th>
                        <th>
                            BLN 05</th>
                        <th>
                            BLN 06</th>
                        <th>
                            BLN 07</th>
                        <th>
                            BLN 08</th>
                        <th>
                            BLN 09</th>
                        <th>
                            BLN 10</th>
                        <th>
                            BLN 11</th>
                        <th>
                            BLN 12</th>
                        <th>
                            TOT</th>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width:3%; font-size: small">
                        <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" 
                            Text='<%# Eval("SPKLEASE_DEALER") %>' />
                    </td>
                    <td style="width:10%; font-size: small">
                        <%#Eval("SPKLEASE_KODE")%></td>
                    <td style="width:35%; font-size: small">
                        <%#Eval("SPKLEASE_NAMA")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF ">
                        <%#Eval("SPKLEASE_CNT01")%></td>
                    <td style="width:4%; font-size: small; text-align:right">
                        <%#Eval("SPKLEASE_CNT02")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF">
                        <%#Eval("SPKLEASE_CNT03")%></td>
                    <td style="width:4%; font-size: small; text-align:right">
                        <%#Eval("SPKLEASE_CNT04")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF">
                        <%#Eval("SPKLEASE_CNT05")%></td>
                    <td style="width:4%; font-size: small; text-align:right">
                        <%#Eval("SPKLEASE_CNT06")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF">
                        <%#Eval("SPKLEASE_CNT07")%></td>
                    <td style="width:4%; font-size: small; text-align:right">
                        <%#Eval("SPKLEASE_CNT08")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF">
                        <%#Eval("SPKLEASE_CNT09")%></td>
                    <td style="width:4%; font-size: small; text-align:right">
                        <%#Eval("SPKLEASE_CNT10")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF">
                        <%#Eval("SPKLEASE_CNT11")%></td>
                    <td style="width:4%; font-size: small; text-align:right">
                        <%#Eval("SPKLEASE_CNT12")%></td>
                    <td style="width:4%; font-size: small; text-align:right; background-color : #CCCCFF">
                        <%#Eval("SPKLEASE_CNT")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </asp:View>

    <asp:View ID="View7" runat="server">
    </asp:View>
    
  </asp:MultiView>
</asp:Content>
