<%@ Page Language="VB"  MasterPageFile ="~/MasterPage.master"  AutoEventWireup="false" CodeFile="Form0101ISO.aspx.vb" Inherits="Form02Aksesoris" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <p   style ="font-size:smaller" >
        <asp:Label ID="Label44"  Text ="Informasi Pemasangan Aksesoris >> " runat="server"></asp:Label>
        &nbsp; Nama User&nbsp; : 
        <asp:Label ID="LblUserName" runat="server"></asp:Label>
        <asp:Label ID="lblAkses" runat="server"></asp:Label>
        &nbsp; Akses &nbsp; : 
        <asp:Label ID="lblArea1" runat="server"></asp:Label>
        <asp:Label ID="lblArea2" runat="server"></asp:Label>
    </p>
    <br />
    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
          
        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Judul 
        Permohonan</asp:Label>
          
    </asp:View> 
    </asp:MultiView>
<br />
<br />

    <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
    <asp:View ID="View1Akses" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 20%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="LabelNIK" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">ID</asp:Label>
                </td>
                <td style="width: 80%; ">
                    <asp:TextBox ID="TxtCariID" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="100%" MaxLength="10" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
              </td>
            </tr>
            <tr>
                <td style="width: 20%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label22" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nama Karyawan</asp:Label>
                </td>
                <td style="width: 80%; ">
                    <asp:TextBox ID="TxtDept" runat="server" Font-Names="Arial" Font-Size="Small" Width="100%" MaxLength="30" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
                </td>
            </tr>
        </table> 
        <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="BtnMasterTabel" runat="server" BackColor="White" BorderStyle="None" Font-Bold="True" Font-Italic="True" Font-Size="Small"  Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk melihat Tabel Sasaran Mutu" Width="100%" />
                </td>
            </tr>
        </table> 
        <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT [MUTU_ID], [MUTU_SASARANMUTU], [MUTU_DEPT], [MUTU_TARGET], [MUTU_ON], [MUTU_OFF], [MUTU_USER], [MUTU_CREATE] FROM [TRXN_ISOASM] 
                          WHERE [MUTU_ID] LIKE '%' + ? + '%' OR [MUTU_DEPT] LIKE '%' + ? + '%'"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCariID"   Name="MUTU_ID"   PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtDept"     Name="MUTU_DEPT"  PropertyName="Text" Type="String" DefaultValue="%" />            
            </SelectParameters>
        </asp:SqlDataSource>                                             
        <asp:ListView ID="LvDetailMaster" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="MUTU_ID">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>Id</th><th>Dept</th><th>Sasaran Mutu</th><th>Target</th><th>User</th>
                </thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
    
            <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
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
                    <td style="width:10%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("MUTU_ID") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTU_DEPT")%></td>
                    <td style="width:50%; font-size:x-small"><%#Eval("MUTU_SASARANMUTU")%></td>
                    <td style="width:20%; font-size:x-small"><%#Eval("MUTU_TARGET")%></td>
                    <td style="width:20%; font-size:x-small"><%#Eval("MUTU_USER")%></td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>Data Sasaran Mutu Tidak diketemukan</EmptyDataTemplate> 
            <EmptyItemTemplate>Data Sasaran Mutu Tidak diketemukan</EmptyItemTemplate>              
        </asp:ListView>
        <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="BtnA" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Size="Small"  
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menambah data atau klik kolom ID untuk Merubah/melihat/Hapus Sasaran Mutu" 
                    Width="100%" />
                </td>
            </tr>
        </table>         
        <asp:MultiView ID="MultiViewMasterIsi" runat="server" Visible="TRUE">
        <asp:View ID="View3" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; background-color:#CCCCFF;">
                   <asp:Label ID="Label66" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="ID" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtID" runat="server" Font-Names="Arial" Font-Size="Small" Width="95%" MaxLength="5" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
                   <asp:Label ID="lblSMID" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label29" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Dept" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSMDep" runat="server" Font-Names="Arial" Font-Size="Small" Width="95%" MaxLength="20" TabIndex ="8"  AutoPostBack="true" Text =""   ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label39" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Sasaran Mutu" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtSMDesc" runat="server" Font-Names="Arial" Font-Size="Small" Width="95%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Target" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSMTarget" runat="server" Font-Names="Arial" Font-Size="Small" Width="95%" MaxLength="17" TabIndex ="10"  AutoPostBack="true" Text =""   ></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="User" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSMUser" runat="server" Font-Names="Arial" Font-Size="Small" Width="95%" MaxLength="10" TabIndex ="11"  AutoPostBack="true" Text =""   ></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Pembuat" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSMPembuat" runat="server" Font-Names="Arial" Font-Size="Small" Width="95%" MaxLength="10" TabIndex ="12"  AutoPostBack="true" Text =""   ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label16" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal Aktif" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtSMTglOn" runat="server" Width="130px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" TabIndex ="13" />
                    <asp:Button ID="ButtonTgl02"  Text="..."  runat="server" CausesValidation="False" Height="19px" Width="25px" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExt02" runat="server"
                    TargetControlID="TxtSMTglOn" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValid02" runat="server"
                    ControlExtender="MaskedEditExt02" ControlToValidate="TxtSMTglOn" EmptyValueMessage="Date is required"
                    InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExt02" runat="server" TargetControlID="TxtSMTglOn" PopupButtonID="ButtonTgl02" />

                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Tanggal Non Aktif Aktif" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                
                    <asp:TextBox ID="TxtSMTglOff" runat="server" Width="130px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" TabIndex ="14" />                   
                    <asp:Button ID="ButtonTgl03"  Text="..."  runat="server" CausesValidation="False" Height="19px" Width="25px" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExt03" runat="server"
                    TargetControlID="TxtSMTglOff" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValid03" runat="server"
                    ControlExtender="MaskedEditExt03" ControlToValidate="TxtSMTglOff" EmptyValueMessage="Date is required"
                    InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExt03" runat="server" TargetControlID="TxtSMTglOff" PopupButtonID="ButtonTgl03" />

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
                <asp:Label ID="LblErrorSaveA" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Error" ForeColor="Black"></asp:Label>
                </td>
            </tr>
        </table> 
        
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%;">
                    <asp:Button ID="ButtonASave" runat="server" BackColor="Gray" Font-Bold="True" 
                        ForeColor="Black" Text="Simpan" Width="20%" />
                    <asp:Button ID="ButtonADel" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Hapus" Width="20%" />
                    <asp:Button ID="ButtonABack" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Kembali Ke Menu Awal" Width="20%" />
                </td>
            </tr>
        </table> 

        </asp:View> 
    </asp:MultiView>

        <asp:MultiView ID="MultiViewActionPlane" runat="server" Visible="TRUE">
        <asp:View ID="View4" runat="server">
            <asp:SqlDataSource ID="SqlDataPLAN" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT [MUTUP_ID], [MUTUP_PLAN] FROM [TRXN_ISOBPLAN] WHERE ([MUTUP_ID] = '' + ? + '')"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtID" Name="MUTUP_ID" PropertyName="Text" Type="String" />
            </SelectParameters>

            </asp:SqlDataSource>                                     
            <asp:ListView ID="LVActionPlane" runat="server" DataSourceID="SqlDataPLAN" DataKeyNames ="MUTUP_PLAN">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>Id</th><th>Action Plan</th>
                </thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
    
            <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
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
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUP_ID")%></td>
                    <td style="width:90%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("MUTUP_PLAN") %>' CommandName="Select" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>Data Action Tidak diketemukan</EmptyDataTemplate> 
            <EmptyItemTemplate>Data Action Tidak diketemukan</EmptyItemTemplate>              

            </asp:ListView>
            <br />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="BtnB" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Size="Small"  
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menambah data atau klik kolom Action Plan untuk menghapus data" 
                    Width="100%" />
                </td>
            </tr>
            </table> 
        </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiViewActionPlaneENtry" runat="server" Visible="TRUE">
        <asp:View ID="View5" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Action Plan" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtActionPlan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="30" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
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
                <asp:Label ID="LblErrorSaveB" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Error" ForeColor="Black"></asp:Label>
                </td>
            </tr>
        </table> 
        
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%;">
                    <asp:Button ID="BtnBSave" runat="server" BackColor="Gray" Font-Bold="True" 
                        ForeColor="Black" Text="Simpan" Width="20%" />
                    <asp:Button ID="BtnBBack" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Kembali Ke Menu Awal" Width="37%" />
                </td>
            </tr>
        </table> 

        </asp:View> 
    </asp:MultiView>
    
        <asp:MultiView ID="MultiViewNilaiProgress" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
            <asp:SqlDataSource ID="SqlDataSMutu" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT [MUTUN_ID], [MUTUN_TARGET], [MUTUN_ACTUAL], [MUTUN_CARAHITUNG1], [MUTUN_CARAHITUNG2], [MUTUN_CREATEUSER], [MUTUN_PROGRESS], [MUTUN_CREATEMGMTGL], [MUTUN_CREATEMGM], [MUTUN_CREATEUSERTGL] FROM [TRXN_ISOENILAI] WHERE ([MUTUN_ID] = ?)"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">

            <SelectParameters>
                <asp:ControlParameter ControlID="TxtID" Name="MUTUN_ID" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>

            </asp:SqlDataSource>                                     
            <asp:ListView ID="LVNilaiSasaranMutu" runat="server" DataSourceID="SqlDataSMutu" DataKeyNames ="MUTUN_PROGRESS">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>Progress</th><th>Target</th><th>Actual</th><th>Cara Hitung</th><th>Head</th><th>Tanggal</th><th>Wakil Manajemen</th><th>Tanggal</th>
                </thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
    
            <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
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
                    <td style="width:9%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("MUTUN_PROGRESS") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:5%; font-size:x-small"><%#Eval("MUTUN_TARGET")%></td>
                    <td style="width:5%; font-size:x-small"><%#Eval("MUTUN_ACTUAL")%></td>
                    <td style="width:43%; font-size:x-small"><%#Eval("MUTUN_CARAHITUNG1")%><%#Eval("MUTUN_CARAHITUNG2")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUN_CREATEUSER")%></td>
                    <td style="width:9%; font-size:x-small"><%#Eval("MUTUN_CREATEUSERTGL")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUN_CREATEMGM")%></td>
                    <td style="width:9%; font-size:x-small"><%#Eval("MUTUN_CREATEMGMTGL")%></td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>Progress Sasaran Mutu Tidak diketemukan</EmptyDataTemplate> 
            <EmptyItemTemplate>Progress Sasaran Mutu Tidak diketemukan</EmptyItemTemplate>              

            </asp:ListView>
            <br />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="BtnNilaiSM" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Size="Small"  
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menambah data atau klik kolom Progress untuk Merubah/melihat/Hapus sasaran mutu" 
                    Width="100%" />
                </td>
            </tr>
            </table> 
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiViewNilaiProgressEntry" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
                <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
                <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label20" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Progress" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                    <asp:Label ID="lblSasaranMutuProgress" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Progress" ForeColor="Black"></asp:Label>
                    <asp:TextBox ID="TxtSasaranMutuProgress" runat="server" Width="130px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" TabIndex ="13" />
                    <asp:Button ID="Button1"  Text="..."  runat="server" CausesValidation="False" Height="19px" Width="25px" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                    TargetControlID="TxtSasaranMutuProgress" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                    ControlExtender="MaskedEditExtender1" ControlToValidate="TxtSasaranMutuProgress" EmptyValueMessage="Date is required"
                    InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtSasaranMutuProgress" PopupButtonID="Button1" />

                </td>
                </tr>
                <tr> 
                <td style="width: 25%; background-color:#CCCCFF;">
                   <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Target" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSasaranMutuTarget" runat="server" Width="130px" ValidationGroup = "MKE" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender11" runat="server"
                    TargetControlID="TxtSasaranMutuTarget" Mask="999,99" MessageValidatorTip="true"
                    OnFocusCssClass="MaskedEditFocus"  OnInvalidCssClass="MaskedEditError" MaskType="Number"
                    InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="None" ErrorTooltipEnabled="True" />
                    
                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator11" runat="server"
                    ControlExtender="MaskedEditExtender11" ControlToValidate="TxtSasaranMutuTarget" IsValidEmpty="false"
                    MaximumValue="100" EmptyValueMessage="Number is required" InvalidValueMessage="Number is invalid"
                    MaximumValueMessage="Number &gt; 100" MinimumValueMessage="Number &lt; 0"
                    MinimumValue="0" Display="Dynamic" TooltipMessage="Input a number from 0 to 100"
                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" MaximumValueBlurredMessage="*"
                    MinimumValueBlurredText="*" ValidationGroup="MKE" />



                </td>
                </tr>
                <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Aktual" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSasaranMutuActual" runat="server" Width="130px" ValidationGroup = "MKE" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender12" runat="server"
                    TargetControlID="TxtSasaranMutuActual" Mask="99,999,999,999" MessageValidatorTip="true"
                    OnFocusCssClass="MaskedEditFocus"  OnInvalidCssClass="MaskedEditError" MaskType="Number"
                    InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="None" ErrorTooltipEnabled="True" />
                    
                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator12" runat="server"
                    ControlExtender="MaskedEditExtender12" ControlToValidate="TxtSasaranMutuActual" IsValidEmpty="false"
                    MaximumValue="100" EmptyValueMessage="Number is required" InvalidValueMessage="Number is invalid"
                    MaximumValueMessage="Number &gt; 100" MinimumValueMessage="Number &lt; 0"
                    MinimumValue="0" Display="Dynamic" TooltipMessage="Input a number from 0 to 100"
                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="*" MaximumValueBlurredMessage="*"
                    MinimumValueBlurredText="*" ValidationGroup="MKE" />
                </td>
                </tr>
                <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Cara Hitung" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtSasaranMutuHitung" runat="server" Font-Names="Arial" Font-Size="Small" Width="95%" MaxLength="200" TabIndex ="7" AutoPostBack="true" Text =""   ></asp:TextBox>
                </td>
                </tr>
                
                <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tanggal Persetujuan Head" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtSasaranMutuStjATgl" runat="server" Width="130px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" TabIndex ="13" />
                    <asp:Button ID="Button2"  Text="..."  runat="server" CausesValidation="False" Height="19px" Width="25px" />
                    
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                    TargetControlID="TxtSasaranMutuStjATgl" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
                    ControlExtender="MaskedEditExtender2" ControlToValidate="TxtSasaranMutuStjATgl" EmptyValueMessage="Date is required"
                    InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />

                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TxtSasaranMutuStjATgl" PopupButtonID="Button2" />

                </td>
                </tr>
                <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Persetujuan Head" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSasaranMutuStjAUser" runat="server" Font-Names="Arial" 
                        Font-Size="Small" Width="27%" MaxLength="10" TabIndex ="10"  
                        AutoPostBack="true" Text =""   ></asp:TextBox>
                    <asp:Button ID="BtnNilaiSMSave0" runat="server" BackColor="Gray" 
                        Font-Bold="True" ForeColor="Black" Height="21px" Text="Disetujui Head" 
                        Width="29%" />
                </td>
                </tr>

                <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Progress" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtSasaranMutuStjBTgl" runat="server" Width="130px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" TabIndex ="13" />
                    <asp:Button ID="Button3"  Text="..."  runat="server" CausesValidation="False" Height="19px" Width="25px" />
                    
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                    TargetControlID="TxtSasaranMutuStjBTgl" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator3" runat="server"
                    ControlExtender="MaskedEditExtender3" ControlToValidate="TxtSasaranMutuStjBTgl" EmptyValueMessage="Date is required"
                    InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TxtSasaranMutuStjBTgl" PopupButtonID="Button3" />

                </td>
                </tr>
                <tr>
                <td style="width: 25%; ">
                   <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Persetujuan Wakil Manajemen" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSasaranMutuStjBUser" runat="server" Font-Names="Arial" 
                        Font-Size="Small" Width="27%" MaxLength="10" TabIndex ="11" AutoPostBack="true" 
                        Text =""   ></asp:TextBox>
                    <asp:Button ID="BtnNilaiSMSave1" runat="server" BackColor="Gray" 
                        Font-Bold="True" ForeColor="Black" Height="21px" 
                        Text="Disetujui Wakil Manajemen" Width="28%" />
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
                <asp:Label ID="LblErrorSaveC" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Error" ForeColor="Black"></asp:Label>
                </td>
                </tr>
                </table> 
        
                <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
                <tr> 
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%;">
                    <asp:Button ID="BtnNilaiSMSave" runat="server" BackColor="Gray" Font-Bold="True" ForeColor="Black" Text="Simpan" Width="20%" />
                    <asp:Button ID="BtnNilaiSMDel" runat="server" BackColor="#FF8080" Font-Bold="True" ForeColor="Black" Text="Hapus" Width="20%" />
                    <asp:Button ID="BtnNilaiSMBack" runat="server" BackColor="#FF8080" Font-Bold="True" ForeColor="Black" Text="Kembali Ke Menu Awal" Width="20%" />
                </td>
                </tr>
                </table> 
                
            </asp:View>
            
        </asp:MultiView>
        
        <asp:MultiView ID="MultiViewMasalah" runat="server" Visible="TRUE">
        <asp:View ID="View6" runat="server">
        <asp:SqlDataSource ID="SqlDataMasalah" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT [MUTUM_ID], [MUTUM_PROGRESS], [MUTUM_MASALAH] FROM [TRXN_ISOCMASALAH] WHERE (([MUTUM_ID] = ?) AND ([MUTUM_PROGRESS] = ?))"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">

            <SelectParameters>
                <asp:ControlParameter ControlID="TxtID" Name="MUTUM_ID" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="lblSasaranMutuProgress" Name="MUTUM_PROGRESS" PropertyName="Text" Type="DateTime" />
            </SelectParameters>

        </asp:SqlDataSource>                                     
        <asp:ListView ID="LvMasalah" runat="server" DataSourceID="SqlDataMasalah" DataKeyNames ="MUTUM_MASALAH">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>Masalah</th>
                </thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
    
            <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
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
                    <td style="width:90%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("MUTUM_MASALAH") %>' CommandName="Select" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>Data Masalah Tidak diketemukan(1)</EmptyDataTemplate> 
            <EmptyItemTemplate>Data Masalah Tidak diketemukan(2)</EmptyItemTemplate>              

        </asp:ListView>
        <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="BtnD" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Size="Small"  
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menambah data atau klik kolom Maslah untuk menghapus" 
                    Width="100%" />
                </td>
            </tr>
        </table> 
    </asp:View> 
    </asp:MultiView>
        <asp:MultiView ID="MultiViewMasalahENtry" runat="server" Visible="TRUE">
        <asp:View ID="View7" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Masalah" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtMasalahDesc" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="30" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
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
                <asp:Label ID="LblErrorSaveD" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Error" ForeColor="Black"></asp:Label>
                </td>
            </tr>
        </table> 
        
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%;">
                    <asp:Button ID="BtnDSave" runat="server" BackColor="Gray" Font-Bold="True" 
                        ForeColor="Black" Text="Simpan" Width="20%" />
                    <asp:Button ID="BtnDBack" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Kembali Ke Menu Awal" Width="34%" />
                </td>
            </tr>
        </table> 

        </asp:View> 
        </asp:MultiView>

        <asp:MultiView ID="MultiViewKoreksi" runat="server" Visible="TRUE">
        <asp:View ID="View8" runat="server">
        <asp:SqlDataSource ID="SqlDataKoreksi" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT [MUTUT_ID], [MUTUT_PROGRESS], [MUTUT_TIPE], [MUTUT_TINDAKAN], [MUTUT_PIC], [MUTUT_DUE] FROM [TRXN_ISODTINDAKAN] WHERE (([MUTUT_ID] = ?) AND ([MUTUT_TIPE] = ?) AND ([MUTUT_PROGRESS] = ?))"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">

            <SelectParameters>
                <asp:ControlParameter ControlID="TxtID" Name="MUTUT_ID" PropertyName="Text" Type="String" />
                <asp:Parameter DefaultValue="A" Name="MUTUT_TIPE" Type="String" />
                <asp:ControlParameter ControlID="lblSasaranMutuProgress" Name="MUTUT_PROGRESS" PropertyName="Text" Type="DateTime" />
            </SelectParameters>
        </asp:SqlDataSource>   
                                          
        <asp:ListView ID="LVKoreksi" runat="server" DataSourceID="SqlDataKoreksi" DataKeyNames ="MUTUT_TINDAKAN">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>Koreksi</th><th>PIC</th><th>Due Date</th>
                </thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
    
            <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
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
                    <td style="width:80%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("MUTUT_TINDAKAN") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUT_PIC")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUT_DUE")%></td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>Data Koreksi Tidak diketemukan</EmptyDataTemplate> 
            <EmptyItemTemplate>Data Koreksi Tidak diketemukan</EmptyItemTemplate>              

        </asp:ListView>
        <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="BtnE" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Size="Small"  
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menambah data atau klik kolom Koreksi untuk menghapus" 
                    Width="100%" />
                </td>
            </tr>
        </table> 
    </asp:View> 
    </asp:MultiView>
        <asp:MultiView ID="MultiViewKoreksiEntry" runat="server" Visible="TRUE">
        <asp:View ID="View9" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Koreksi" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtKoreksiTindakan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="P I C" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtKoreksiPIC" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="10" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                </td>
            </tr>

            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label15" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Due Date" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtKoreksiDue" runat="server" Width="130px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" TabIndex ="13" />
                    <asp:Button ID="Button4"  Text="..."  runat="server" CausesValidation="False" Height="19px" Width="25px" />
                    
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server"
                    TargetControlID="TxtKoreksiDue" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator4" runat="server"
                    ControlExtender="MaskedEditExtender4" ControlToValidate="TxtKoreksiDue" EmptyValueMessage="Date is required"
                    InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />

                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TxtKoreksiDue" PopupButtonID="Button4" />

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
                <asp:Label ID="LblErrorSaveE" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Error" ForeColor="Black"></asp:Label>
                </td>
            </tr>
        </table> 
        
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%;">
                    <asp:Button ID="BtnESave" runat="server" BackColor="Gray" Font-Bold="True" 
                        ForeColor="Black" Text="Simpan" Width="20%" />
                    <asp:Button ID="BtnEBack" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Kembali Ke Menu Awal" Width="34%" />
                </td>
            </tr>
        </table> 

        </asp:View> 
    </asp:MultiView>
    
        <asp:MultiView ID="MultiViewPerbaikan" runat="server" Visible="TRUE">
        <asp:View ID="View10" runat="server">
        <asp:SqlDataSource ID="SqlDataPerbaik" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT [MUTUT_ID], [MUTUT_PROGRESS], [MUTUT_TIPE], [MUTUT_TINDAKAN], [MUTUT_PIC], [MUTUT_DUE] FROM [TRXN_ISODTINDAKAN] WHERE (([MUTUT_ID] = ?) AND ([MUTUT_TIPE] = ?) AND ([MUTUT_PROGRESS] = ?))"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">

            <SelectParameters>
                <asp:ControlParameter ControlID="TxtID" Name="MUTUT_ID" PropertyName="Text" Type="String" />
                <asp:Parameter DefaultValue="B" Name="MUTUT_TIPE" Type="String" />
                <asp:ControlParameter ControlID="lblSasaranMutuProgress" Name="MUTUT_PROGRESS" PropertyName="Text" Type="DateTime" />
            </SelectParameters>
        </asp:SqlDataSource>   
                                          
        <asp:ListView ID="LvPerbaikan" runat="server" DataSourceID="SqlDataPerbaik" DataKeyNames ="MUTUT_TINDAKAN">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>Perbaikan</th><th>PIC</th><th>Due Date</th>
                </thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
    
            <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
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
                    <td style="width:80%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("MUTUT_TINDAKAN") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUT_PIC")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUT_DUE")%></td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>Data Tindakan Tidak diketemukan</EmptyDataTemplate> 
            <EmptyItemTemplate>Data Tindakan Tidak diketemukan</EmptyItemTemplate>              

        </asp:ListView>
        <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="BtnF" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Size="Small"  
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menambah data atau klik perbaikan untuk menghapus" 
                    Width="100%" />
                </td>
            </tr>
        </table> 
    </asp:View> 
    </asp:MultiView>
        <asp:MultiView ID="MultiViewPerbaikanEntry" runat="server" Visible="TRUE">
        <asp:View ID="View11" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label151" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Koreksi" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtPerbaikanTindakan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label17" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="P I C" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtPerbaikanPIC" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="10" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                </td>
            </tr>

            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label18" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Due Date" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtPerbaikanDue" runat="server" Width="130px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" TabIndex ="13" />
                    <asp:Button ID="Button5"  Text="..."  runat="server" CausesValidation="False" Height="19px" Width="25px" />
                    
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server"
                    TargetControlID="TxtPerbaikanDue" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator5" runat="server"
                    ControlExtender="MaskedEditExtender5" ControlToValidate="TxtPerbaikanDue" EmptyValueMessage="Date is required"
                    InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />

                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="TxtPerbaikanDue" PopupButtonID="Button5" />

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
                <asp:Label ID="LblErrorSaveF" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Error" ForeColor="Black"></asp:Label>
                </td>
            </tr>
        </table> 
        
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%;">
                    <asp:Button ID="BtnFSave" runat="server" BackColor="Gray" Font-Bold="True" 
                        ForeColor="Black" Text="Simpan" Width="20%" />
                    <asp:Button ID="BtnFBack" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Kembali Ke Menu Awal" Width="34%" />
                </td>
            </tr>
        </table> 

        </asp:View> 
    </asp:MultiView>


    </asp:View> 
    </asp:MultiView> 
</asp:Content>
