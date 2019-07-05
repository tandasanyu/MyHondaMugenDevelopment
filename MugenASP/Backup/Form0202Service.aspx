<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"    AutoEventWireup="false" CodeFile="Form0202Service.aspx.vb" Inherits="Form04PurchaseOrder" %>

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


    <asp:MultiView ID="MultiViewMenu" runat="server" Visible="TRUE">
    <asp:View ID="View16" runat="server">
    <table style="width: 100%; height:auto ; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 20%;height:auto ">
               <asp:Button ID="BtnServce1" runat="server" Text="Service"  
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Width="95%" Height="35px" />
            </td>
            <td style="width: 20%;height:auto ">
               <asp:Button ID="BtnServce2" runat="server" Text="Piutang" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Width="95%" Height="35px" />
            </td>
            <td style="width: 20%;height:auto ">
               <asp:Button ID="BtnServce3" runat="server" Text="Audit" 
                    BackColor="#808040" Font-Bold="True" ForeColor="White" Width="95%" Height="35px" />
            </td>
            <td style="width: 20%;height:auto ">
            </td>
            <td style="width: 20%;height:auto ">
            </td>            
        </tr>
     </table>
    </asp:View> 
    </asp:MultiView>

<br />
<br />
     
    <asp:MultiView ID="MultiViewForm" runat="server" Visible="TRUE">
        <asp:View ID="ViewForm0" runat="server">
        </asp:View> 
        <asp:View ID="ViewForm1" runat="server">
        </asp:View> 
        <asp:View ID="ViewForm2" runat="server">
            <asp:MultiView ID="MultiViewForm21Query" runat="server" Visible="TRUE">
            <asp:View ID="ViewForm21Query" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr> 
                <td style="width: 25%; Background-color:#CCCCFF;">
                   <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="Nomor Suku Cadang"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtPartsNO" runat="server" text="" Width="10%" AutoPostBack="true" CssClass="uppercase"></asp:TextBox>
                    <asp:Button ID="ButtonTabelPartsGO" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Perbarui Tabel" />
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label36" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nama Suku Cadang"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtPartsNama" runat="server" text="" Width="652px" MaxLength="100" CssClass="uppercase"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Lantai"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtPartsLantaiKu" runat="server" text="" Width="20%" MaxLength="100" CssClass="uppercase"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="70%" AutoPostBack="true"  >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; "></td>
                <td style="width: 75%; "></td>
            </tr>
            </table> 
            </asp:View> 
            </asp:MultiView>
            
            <asp:MultiView ID="MultiViewForm22Audit" runat="server" Visible="TRUE">
            <asp:View ID="View12" runat="server">            
            <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Hasil Audit</h2>
            </center>
	        </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nomor Suku Cadang</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="LblPartsNo" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">....</asp:Label>
            </td>
            </tr>

            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nama Suku Cadang</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:Label ID="LblPartsNama" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Stok</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="LblPartsStk" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Pickup</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:Label ID="LblPartsPickup" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Stok Actual</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="LblPartsActual" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Audit</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:TextBox ID="TxtPartsAuditQty" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="10" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
                <asp:Label ID="lblTempPartsAuditQty" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Visible="false"  >...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label14" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Catatan</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtPartsAuditNote" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Labellt2" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Lantai</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:TextBox ID="TxtPartsLantai" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="8" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>

            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Auditor</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:Label ID="LblPartsUserNma" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Labeltgla2" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Tanggal Audit</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="LblPartsUserTgl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Tanggal Stok</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:Label ID="LblPartsStokTgl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>

            </table>   
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 50%; ">
               <asp:Button ID="BtnAuditSimpan" runat="server" Text="Simpan" Width="73%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 50%; ">
               <asp:Button ID="BtnAuditBack" runat="server" Text="Kembali Ke Tabel Utama" 
                    Width="73%" BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            </tr>
            </table>

            </asp:View> 
            </asp:MultiView>

            <asp:MultiView ID="MultiViewTabelStokPart112" runat="server" Visible="TRUE">
            <asp:View ID="View19" runat="server">            

            <asp:SqlDataSource ID="sdsTabelStock112" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnetSvcs112 %>" 
            SelectCommand="SELECT [PARTS_NO], [PARTS_NAMA], [PARTS_STOCK],(ISNULL([PARTS_STOCK],0)-ISNULL([PARTS_QYPESAN],0)) as QtySTok, [PARTS_QYPESAN], [PARTS_LOKASI], [PARTS_QTYAUDIT], [PARTS_TGLAUDIT] FROM [DATA_PARTS] WHERE ([PARTS_LOKASI] LIKE '%' + ? + '%')  AND ([PARTS_NO] LIKE '%' + ? + '%') AND ([PARTS_NAMA] LIKE '%' + ? + '%') ORDER BY PARTS_NO"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnetSvcs112.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtPartsLantai"           Name="DATA_PARTS.PARTS_LOKASI" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsNO"               Name="DATA_PARTS.PARTS_NO" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsNama"             Name="DATA_PARTS.PARTS_NAMA" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
            </SelectParameters>
            </asp:SqlDataSource>                     
            <asp:ListView ID="lvStockPart" runat="server" DataSourceID="sdsTabelStock112" DataKeyNames ="PARTS_NO">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver">
                <th>Part No</th>
                <th>Nama</th>
                <th>Lokasi</th>
                <th>Stok</th>
                <th>Pickup</th>
                <th>Stock</th>
                <th>Audit</th>
                <th>Qty</th>
                </thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
    
            <asp:DataPager ID="dpBerita" PageSize="1500" runat="server">
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
                    <td style="width:15%; height:30px;  font-size: small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("PARTS_NO") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:20%; font-size:small"><%#Eval("PARTS_NAMA")%></td>
                    <td style="width:10%; font-size:small"><%#Eval("PARTS_LOKASI")%></td>
                    <td style="width:9%; font-size:small"><%#Eval("PARTS_STOCK")%></td>
                    <td style="width:9%; font-size:small"><%#Eval("PARTS_QYPESAN")%></td>
                    <td style="width:9%; font-size:small"><%#Eval("QtySTok")%></td>
                    <td style="width:10%; font-size:small"><%#Eval("PARTS_TGLAUDIT")%></td>
                    <td style="width:9%; font-size:small"><%#Eval("PARTS_QTYAUDIT")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>


            </asp:View> 
            </asp:MultiView>

            <asp:MultiView ID="MultiViewTabelStokPart128" runat="server" Visible="TRUE">
            <asp:View ID="View20" runat="server">            
            </asp:View> 
            </asp:MultiView>

              <asp:MultiView ID="MultiViewTabelAudit112" runat="server" Visible="TRUE">
            <asp:View ID="View22" runat="server">   
                        <asp:SqlDataSource ID="SqlDataAdudit112" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnetSvcs112 %>" 
            SelectCommand="SELECT DATA_PARTS.PARTS_NO, DATA_PARTS.PARTS_NAMA,(ISNULL([AUDITPART_STOK],0)-ISNULL([AUDITPART_PICKUP],0)) as QtySTok, DATA_PARTS.PARTS_STOCK, DATA_PARTS.PARTS_QYPESAN, DATA_PARTS.PARTS_LOKASI, DATA_PARTS.PARTS_QTYAUDIT, DATA_PARTS.PARTS_TGLAUDIT, TEMP_AUDITPART.AUDITPART_NO, TEMP_AUDITPART.AUDITPART_TGL, TEMP_AUDITPART.AUDITPART_USER, TEMP_AUDITPART.AUDITPART_STOK, TEMP_AUDITPART.AUDITPART_PICKUP, TEMP_AUDITPART.AUDITPART_QTY, TEMP_AUDITPART.AUDITPART_CATATAN FROM DATA_PARTS RIGHT OUTER JOIN TEMP_AUDITPART ON DATA_PARTS.PARTS_NO = TEMP_AUDITPART.AUDITPART_NO WHERE (DATA_PARTS.PARTS_NO LIKE '%' + ? + '%') ORDER BY DATA_PARTS.PARTS_NO"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnetSvcs112.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="LblPartsNo"           Name="DATA_PARTS.PARTS_NO" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
            </SelectParameters>
            </asp:SqlDataSource>                     
            <asp:ListView ID="LVDataAdudit" runat="server" DataSourceID="SqlDataAdudit112" DataKeyNames ="PARTS_NO">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver">
                <th>Part No</th>
                <th>Nama</th>
                <th>Tgl Audit</th>
                <th>User</th>
                <th>Stok</th>
                <th>Pickup</th>
                <th>Actual</th>
                <th>Qty</th>
                <th>Catatan</th>
                </thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
    
            <asp:DataPager ID="dpBerita" PageSize="15" runat="server">
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
                    <td style="width:15%; height:30px;  font-size: small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("PARTS_NO") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:20%; font-size:small"><%#Eval("PARTS_NAMA")%></td>
                    <td style="width:9%; font-size:small"><%#Eval("AUDITPART_TGL")%></td>
                    <td style="width:9%; font-size:small"><%#Eval("AUDITPART_USER")%></td>
                    <td style="width:9%; font-size:small"><%#Eval("AUDITPART_STOK")%></td>
                    <td style="width:9%; font-size:small"><%#Eval("AUDITPART_PICKUP")%></td>
                    <td style="width:9%; font-size:small"><%#Eval("QtySTok")%></td>
                    <td style="width:10%; font-size:small"><%#Eval("AUDITPART_QTY")%></td>
                    <td style="width:10%; font-size:small"><%#Eval("AUDITPART_CATATAN")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
         
            </asp:View> 
            </asp:MultiView>

            <asp:MultiView ID="MultiViewTabelAudit128" runat="server" Visible="TRUE">
            <asp:View ID="View23" runat="server">            
            </asp:View> 
            </asp:MultiView>         
        </asp:View> 
    </asp:MultiView>
    
    
    
    

    
</asp:Content>
