<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0102ISO.aspx.vb" Inherits="SALES_Form0104Diskontypemaksimal" title="Untitled Page" %>

<%@ MasterType virtualpath = "~/MasterPage.master"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />

    <p   style ="font-size:smaller" >
        <asp:Label ID="Label44"  Text ="Informasi Diskon Kendaraan >> " runat="server"></asp:Label>
        &nbsp; Nama User&nbsp; : 
        <asp:Label ID="LblUserName" runat="server"></asp:Label>
        <asp:Label ID="lblAkses" runat="server"></asp:Label>
        &nbsp; Akses &nbsp; : 
        <asp:Label ID="lblArea1" runat="server"></asp:Label>
        <asp:Label ID="lblArea2" runat="server"></asp:Label>
    </p>



    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
    <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Judul Permohonan</asp:Label>
    </asp:View> 
    </asp:MultiView>

    <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
    <asp:View ID="View1Akses" runat="server">
    <asp:MultiView ID="MultiViewMasterTabel" runat="server" Visible="TRUE">
        <asp:View ID="View0101Tabel" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 20%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="LabelNIK" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">NIK</asp:Label>
                </td>
                <td style="width: 80%; ">
                    <asp:TextBox ID="TxtCariNIK" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="100%" MaxLength="10" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
              </td>
            </tr>
            <tr>
                <td style="width: 20%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label22" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nama Karyawan</asp:Label>
                </td>
                <td style="width: 80%; ">
                    <asp:TextBox ID="TxtCariNama" runat="server" Font-Names="Arial" Font-Size="Small" Width="100%" MaxLength="30" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
                </td>
            </tr>
        </table> 
        <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT [MUTU_ID], [MUTU_SASARANMUTU], [MUTU_DEPT], [MUTU_TARGET], [MUTU_ON], [MUTU_OFF], [MUTU_USER], [MUTU_CREATE] FROM [TRXN_ISOASM]"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">

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
        </asp:ListView>
        <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="BtnA" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Size="Small"  
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menambah data atau klik kolom NIK untuk Merubah/melihat/Hapus data Karyawan" 
                    Width="100%" />
                </td>
            </tr>
        </table> 
    </asp:View> 
    </asp:MultiView>
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
                    <asp:TextBox ID="TxtID" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="50%" MaxLength="10" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                   <asp:Label ID="lblSMID" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label29" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Dept" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSMDep" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="30" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label39" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Sasaran Mutu" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                    <asp:TextBox ID="TxtSMDesc" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="20%" MaxLength="20" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>

                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Target" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSMTarget" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="30" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="User" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSMUser" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="30" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Pembuat" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSMPembuat" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="30" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label16" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Tanggal Aktif" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                
                <asp:TextBox ID="TxtSMTglOn" runat="server" Width="130px" MaxLength="1" 
                        style="text-align:justify" ValidationGroup="MKE" />

                <asp:Button ID="ButtonTgl01"  Text="..."  runat="server" CausesValidation="False" Height="19px" Width="25px" />

                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Tanggal Non Aktif Aktif" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF ;">
                
                <asp:TextBox ID="TxtSMTglOff" runat="server" Width="130px" MaxLength="1" 
                        style="text-align:justify" ValidationGroup="MKE" />

                <asp:Button ID="Button1"  Text="..."  runat="server" CausesValidation="False" Height="19px" Width="25px" />

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
                    <asp:Button ID="ButtonA1Save" runat="server" BackColor="Gray" Font-Bold="True" 
                        ForeColor="Black" Text="Simpan" Width="20%" />
                    <asp:Button ID="ButtonA1Del" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Hapus" Width="20%" />
                    <asp:Button ID="ButtonA1Back" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Kembali Ke Menu Awal" Width="20%" />
                </td>
            </tr>
        </table> 

        </asp:View> 
    </asp:MultiView>
    
 
    
    <asp:MultiView ID="MultiViewActionPlane" runat="server" Visible="TRUE">
        <asp:View ID="View4" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT [MUTUP_ID], [MUTUP_PLAN] FROM [TRXN_ISOBPLAN] WHERE ([MUTUP_ID] LIKE '%' + ? + '%')"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">

            <SelectParameters>
                <asp:ControlParameter ControlID="TxtID" Name="MUTUP_ID" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>

        </asp:SqlDataSource>                                     
        <asp:ListView ID="LVActionPlane" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="MUTU_ID">
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
                    <td style="width:10%; height:30px;  font-size: x-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("MUTUP_ID") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUP_PLAN")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="BtnAP" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Size="Small"  
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menambah data atau klik kolom NIK untuk Merubah/melihat/Hapus data Karyawan" 
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
                <td style="width: 25%; background-color:#CCCCFF;">
                   <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="ID" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtActionPlanID" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="50%" MaxLength="10" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                   <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="" ForeColor="Black"></asp:Label>
                </td>
            </tr>
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
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%;">
                    <asp:Button ID="BtnAPSave" runat="server" BackColor="Gray" Font-Bold="True" 
                        ForeColor="Black" Text="Simpan" Width="20%" />
                    <asp:Button ID="BtnAPDel" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Hapus" Width="20%" />
                    <asp:Button ID="BtnAPBack" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Kembali Ke Menu Awal" Width="20%" />
                </td>
            </tr>
        </table> 

        </asp:View> 
    </asp:MultiView>
    
    <asp:MultiView ID="MultiViewNilaiSasaranMutuTabel" runat="server" Visible="TRUE">
        <asp:View ID="View1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource2" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT [MUTUN_ID], [MUTUN_PROGRESS], [MUTUN_TARGET], [MUTUN_ACTUAL], [MUTUN_CARAHITUNG1], [MUTUN_CARAHITUNG2], [MUTUN_CREATEUSER], [MUTUN_CREATEUSERTGL], [MUTUN_CREATEMGM], [MUTUN_CREATEMGMTGL] FROM [TRXN_ISOENILAI] WHERE ([MUTUN_ID] LIKE '%' + ? + '%')"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">

            <SelectParameters>
                <asp:ControlParameter ControlID="TxtActionPlan" Name="MUTUN_ID" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>

        </asp:SqlDataSource>                                     
        <asp:ListView ID="LVNilaiSasaranMutu" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="MUTUN_PROGRESS">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>Progress</th><th>Target</th><th>Actual</th><th>Cara Hitung</th>
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
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("MUTUN_PROGRESS") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUN_TARGET")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUN_ACTUAL")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUN_CARAHITUNG1")%><%#Eval("MUTUN_CARAHITUNG2")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="BtnNilaiSM" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Size="Small"  
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menambah data atau klik kolom NIK untuk Merubah/melihat/Hapus data Karyawan" 
                    Width="100%" />
                </td>
            </tr>
        </table> 
    </asp:View> 
    </asp:MultiView>
    <asp:MultiView ID="MultiViewNilaiSasaranMutuEntry" runat="server" Visible="TRUE">
        <asp:View ID="View2" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; background-color:#CCCCFF;">
                   <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Progress" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSMNilaiProgress" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="50%" MaxLength="10" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                   <asp:Label ID="Label6" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Target" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSMNilaiTarget" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="30" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Actual" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSMNilaiActual" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="30" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Cara Hitung" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtSMNilaiCara" runat="server" Font-Names="Arial" Font-Size="Small" 
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
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%;">
                    <asp:Button ID="BtnNilaiSMSave" runat="server" BackColor="Gray" Font-Bold="True" 
                        ForeColor="Black" Text="Simpan" Width="20%" />
                    <asp:Button ID="BtnNilaiSMDel" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Hapus" Width="20%" />
                    <asp:Button ID="BtnNilaiSMBack" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Kembali Ke Menu Awal" Width="20%" />
                </td>
            </tr>
        </table> 

        </asp:View> 
    </asp:MultiView>
    
    <asp:MultiView ID="MultiViewMasalah" runat="server" Visible="TRUE">
        <asp:View ID="View6" runat="server">
        <asp:SqlDataSource ID="SqlDataMasalah" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT [MUTUM_ID], [MUTUM_PROGRESS], [MUTUM_MASALAH] FROM [TRXN_ISOCMASALAH] WHERE (([MUTUM_ID] LIKE '%' + ? + '%') AND ([MUTUM_PROGRESS] = ?))"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">

            <SelectParameters>
                <asp:ControlParameter ControlID="TxtActionPlan" Name="MUTUM_ID" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="TxtSMDep" Name="MUTUM_PROGRESS" 
                    PropertyName="Text" Type="DateTime" />
            </SelectParameters>

        </asp:SqlDataSource>                                     
        <asp:ListView ID="LvMasalah" runat="server" DataSourceID="SqlDataMasalah" DataKeyNames ="MUTUM_PROGRESS">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>Progress</th><th>Masalah</th>
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
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("MUTUN_PROGRESS") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUN_TARGET")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="BtnMasalah" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Size="Small"  
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menambah data atau klik kolom NIK untuk Merubah/melihat/Hapus data Karyawan" 
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
                <td style="width: 25%; background-color:#CCCCFF;">
                   <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Progress" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtMasalahProgres" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="50%" MaxLength="10" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                   <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Medium" 
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
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%;">
                    <asp:Button ID="BtnMasalahSave" runat="server" BackColor="Gray" Font-Bold="True" 
                        ForeColor="Black" Text="Simpan" Width="20%" />
                    <asp:Button ID="BtnMasalahDel" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Hapus" Width="20%" />
                    <asp:Button ID="BtnMasalahBack" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Kembali Ke Menu Awal" Width="20%" />
                </td>
            </tr>
        </table> 

        </asp:View> 
    </asp:MultiView>

    <asp:MultiView ID="MultiViewKoreksi" runat="server" Visible="TRUE">
        <asp:View ID="View8" runat="server">
        <asp:SqlDataSource ID="SqlDataKoreksi" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT [MUTUT_ID], [MUTUT_PROGRESS], [MUTUT_TIPE], [MUTUT_TINDAKAN], [MUTUT_PIC], [MUTUT_DUE] FROM [TRXN_ISODTINDAKAN] WHERE MUTUT_TIPE='A' AND ([MUTUT_PROGRESS] = ?)"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">

            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCariNIK" Name="MUTUT_PROGRESS" PropertyName="Text" 
                    Type="DateTime" />
            </SelectParameters>

        </asp:SqlDataSource>                                     
        <asp:ListView ID="LVKoreksi" runat="server" DataSourceID="SqlDataKoreksi" DataKeyNames ="MUTUT_PROGRESS">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>Tindakan</th><th>PIC</th><th>Due Date</th>
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
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("MUTUT_TINDAKAN") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUT_PIC")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUT_DUE")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="BtnKoreksi" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Size="Small"  
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menambah data atau klik kolom NIK untuk Merubah/melihat/Hapus data Karyawan" 
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
                <td style="width: 25%; background-color:#CCCCFF;">
                   <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Tindakan Koreksi" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtKoreksiTindakan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="50%" MaxLength="10" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                   <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label15" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="PIC" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtKoreksiPIC" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="30" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label17" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Due Date" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtKoreksiDue" runat="server" Font-Names="Arial" Font-Size="Small" 
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
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%;">
                    <asp:Button ID="BtnKoreksiSave" runat="server" BackColor="Gray" Font-Bold="True" 
                        ForeColor="Black" Text="Simpan" Width="20%" />
                    <asp:Button ID="BtnKoreksiDel" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Hapus" Width="20%" />
                    <asp:Button ID="BtnKoreksiBack" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Kembali Ke Menu Awal" Width="20%" />
                </td>
            </tr>
        </table> 

        </asp:View> 
    </asp:MultiView>
    
    <asp:MultiView ID="MultiViewPerbaikan" runat="server" Visible="TRUE">
        <asp:View ID="View10" runat="server">
        <asp:SqlDataSource ID="SqlDataPerbaikan" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT [MUTUT_ID], [MUTUT_PROGRESS], [MUTUT_TIPE], [MUTUT_TINDAKAN], [MUTUT_PIC], [MUTUT_DUE] FROM [TRXN_ISODTINDAKAN] WHERE MUTUT_TIPE='B' AND ([MUTUT_PROGRESS] = ?)"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">

            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCariNIK" Name="MUTUT_PROGRESS" PropertyName="Text" 
                    Type="DateTime" />
            </SelectParameters>

        </asp:SqlDataSource>                                     
        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataPerbaikan" DataKeyNames ="MUTUT_PROGRESS">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver; height:30px "  >
                <th>Tindakan</th><th>PIC</th><th>Due Date</th>
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
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("MUTUT_TINDAKAN") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUT_PIC")%></td>
                    <td style="width:10%; font-size:x-small"><%#Eval("MUTUT_DUE")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="BtnPerbaikan" runat="server" BackColor="White" BorderStyle="None" 
                    Font-Bold="True" Font-Italic="True" Font-Size="Small"  
                    Font-Underline="True" ForeColor="Green" 
                    Text="Klik disini untuk menambah data atau klik kolom NIK untuk Merubah/melihat/Hapus data Karyawan" 
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
                <td style="width: 25%; background-color:#CCCCFF;">
                   <asp:Label ID="Label18" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Tindakan Perbaikan" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtPerbaikanTindakan" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="50%" MaxLength="10" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                   <asp:Label ID="Label23" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label24" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                        height= "21px" Text="Due Date" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtPerbaikanPIC" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Width="90%" MaxLength="30" TabIndex ="7"  AutoPostBack="true" 
                        Text ="Mugen jaya"   ></asp:TextBox>
                </td>
            </tr>
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Medium" height= "21px" Text="Target" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%;">
                    <asp:TextBox ID="TxtPerbaikanDue" runat="server" Font-Names="Arial" Font-Size="Small" 
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
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%;">
                    <asp:Button ID="BtnPerbaikanSave" runat="server" BackColor="Gray" Font-Bold="True" 
                        ForeColor="Black" Text="Simpan" Width="20%" />
                    <asp:Button ID="BtnPerbaikanDel" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Hapus" Width="20%" />
                    <asp:Button ID="BtnPerbaikanBack" runat="server" BackColor="#FF8080" Font-Bold="True" 
                        ForeColor="Black" Text="Kembali Ke Menu Awal" Width="20%" />
                </td>
            </tr>
        </table> 

        </asp:View> 
    </asp:MultiView>
    </asp:View> 
    </asp:MultiView>

    
</asp:Content>

