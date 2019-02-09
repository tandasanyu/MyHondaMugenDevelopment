<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0104Diskontypemaksimal.aspx.vb" Inherits="SALES_Form0104Diskontypemaksimal" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p   style ="font-size:smaller" >
        <asp:Label ID="Label44"  Text ="Informasi Diskon Kendaraan >> " runat="server"></asp:Label>
        &nbsp; Nama User&nbsp; : 
        <asp:Label ID="LblUserName" runat="server"></asp:Label>
        <asp:Label ID="lblAkses" runat="server"></asp:Label>
        &nbsp; Akses &nbsp; : 
        <asp:Label ID="lblArea1" runat="server"></asp:Label>
        <asp:Label ID="lblArea2" runat="server"></asp:Label>
    </p>

    <asp:SqlDataSource ID="sdsTabelTipe" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT *,(1945 + ASCII(SUBSTRING(DATA_TYPED.TYPED_RANGKA,7,1))) as DATA_TYPED_TAHUN  FROM  DATA_TYPED,DATA_TYPE WHERE DATA_TYPED.TYPED_Type = DATA_TYPE.TYPE_Type AND DATA_TYPED.TYPED_ST='' AND (([TYPE_Aktif] LIKE '%' + ? + '%') AND ([TYPE_CdGroup] LIKE '%' + ? + '%') AND ([TYPE_Nama] LIKE '%' + ? + '%')) ORDER BY TYPE_CdGroup,TYPE_Aktif,TYPE_TYPE,TYPED_RANGKA,TYPED_TANGGAL"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCariAktifTipe" Name="DATA_TYPE.TYPE_Aktif" 
                    PropertyName="Text" Type="String" DefaultValue="0" />            
                <asp:ControlParameter ControlID="TxtCariGroupTipe" Name="DATA_TYPE.TYPE_CdGroup" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtCariNamaTipe" Name="DATA_TYPE.TYPE_Nama" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
            </SelectParameters>

    </asp:SqlDataSource>                     

    <asp:SqlDataSource ID="sdsTabelGroupTipe" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT *,(1945 + ASCII(SUBSTRING(DATA_TYPEDTEMP.TYPED_RANGKA,7,1))) as DATA_TYPEDTEMP_TAHUN   FROM  DATA_TYPEDTEMP,DATA_TYPE WHERE DATA_TYPEDTEMP.TYPED_Type = DATA_TYPE.TYPE_Type AND DATA_TYPEDTEMP.TYPED_ST='' AND (([TYPE_Aktif] LIKE '%' + ? + '%') AND ([TYPE_CdGroup] LIKE '%' + ? + '%') AND ([TYPE_Nama] LIKE '%' + ? + '%') AND ([TYPED_RANGKA] LIKE '______' + ? + '%'))  ORDER BY TYPE_CdGroup,TYPE_Aktif,TYPE_TYPE,TYPED_RANGKA,TYPED_TANGGAL"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCariAktifTipeSummary" Name="TYPE_Aktif" 
                    PropertyName="Text" Type="String" DefaultValue="0" />            
                <asp:ControlParameter ControlID="TxtCariGroupTipeSummary" Name="TYPE_CdGroup" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtCariNamaTipeSummary" Name="TYPE_Nama" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtCariKodeTahunSUmmary" Name="TYPED_RANGKA" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
            </SelectParameters>
    </asp:SqlDataSource>                     

    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
    <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Judul Permohonan</asp:Label>
    </asp:View> 
    </asp:MultiView>

    <asp:MultiView ID="MultiView1a" runat="server" Visible="TRUE">
    <asp:View ID="View1" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 22%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Tampilan [1:Summary 0:Detail]</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtTampilan" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true" Text ="1"   ></asp:TextBox>
            </td>
        </tr>
        </table>

    
        <asp:MultiView ID="MultiView2a" runat="server" Visible="TRUE">
            <asp:View ID="View21" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 22%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Group" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Group</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtCariGroupTipe" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 22%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Nama Tipe</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtCariNamaTipe" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 22%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Status (0:Aktif / 1:Tidak Aktif </asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtCariAktifTipe" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true" Text ="0"   ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 22%; background-color: #000000;  color: #FFFFFF;">
                &nbsp;</td>
            <td style="width: 75%; ">
                <asp:Button ID="Button1" runat="server" Text="Klik untukPencarian Data" Width="394px" 
                    Font-Overline="False" Font-Size="Medium" BackColor="#33CCFF"   />    
            </td>
        </tr>
        </table>            

            <asp:ListView ID="lvBerita" runat="server" DataSourceID="sdsTabelTipe" DataKeyNames ="TYPE_Type">
            <LayoutTemplate>
            <table border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver">
                <th>Kode D</th>
                <th>Tipe</th>
                <th>Group</th>
                <th>Aktif</th>
                <th>Key Rangka</th>
                <th>Kode Tahun</th>
                <th>Maksimal Diskon</th>
                <th>Mulai Berlaku</th>
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
                    <td style="width:5%; height:30px;  font-size: xx-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("TYPE_Type") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:15%; font-size:xx-small"><%#Eval("TYPE_Nama")%></td>
                    <td style="width:5%; font-size:xx-small"><%#Eval("TYPE_CdGroup")%></td>
                    <td style="width:5%; font-size:xx-small"><%#Eval("TYPE_Aktif")%></td>
                    <td style="width:5%; font-size:xx-small"><%#Eval("TYPED_RANGKA")%></td>
                    <td style="width:5%; font-size:xx-small"><%#Eval("DATA_TYPED_TAHUN")%></td>
                    <td style="width:5%; font-size:xx-small"><%#Eval("TYPED_Jumlah")%></td>
                    <td style="width:5%; font-size:xx-small"><%#format(Eval("TYPED_Tanggal"), "dd-MM-yy HH:MM")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
            </asp:View>
            <asp:View ID="View22" runat="server">

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 22%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Group</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtCariGroupTipeSummary" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 22%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Nama Tipe</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtCariNamaTipeSummary" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 22%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Status (0:Aktif / 1:Tidak Aktif </asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtCariAktifTipeSummary" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true" Text ="0"   ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 22%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Kode Tahun</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtCariKodeTahunSUmmary" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="10%" MaxLength="50" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>

                <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="90%" >Dimulai Huruf A=2010, B=2011, C=2012, D=2013, E=2014, F=2015, G=2016 ...dan seterusnya </asp:Label>
            </td>
        </tr>

        
        <tr>
            <td style="width: 22%; background-color: #000000;  color: #FFFFFF;">
                &nbsp;</td>
            <td style="width: 75%; ">
                <asp:Button ID="Button2" runat="server" Text="Klik untukPencarian Data" Width="394px" 
                    Font-Overline="False" Font-Size="Medium" BackColor="#33CCFF"   />    
            </td>
        </tr>
        </table>            


            <asp:ListView ID="LVGroup" runat="server" DataSourceID="sdsTabelGroupTipe" DataKeyNames ="TYPE_Type">
            <LayoutTemplate>
            <table border="2" width="100%"  style="border-collapse:collapse;">
                <thead  style="background-color:Silver">
                <th>Kode S</th>
                <th>Tipe</th>
                <th>Group</th>
                <th>Aktif</th>
                <th>Key Rangka</th>
                <th>Kode Tahun</th>
                <th>Maksimal Diskon</th>
                <th>Mulai Berlaku</th>
                </thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
    
            <asp:DataPager ID="dpGroup" PageSize="15" runat="server">
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
                    <td style="width:5%; height:30px;  font-size: xx-small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("TYPE_Type") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:15%; font-size:xx-small"><%#Eval("TYPE_Nama")%></td>
                    <td style="width:5%; font-size:xx-small"><%#Eval("TYPE_CdGroup")%></td>
                    <td style="width:5%; font-size:xx-small"><%#Eval("TYPE_Aktif")%></td>
                    <td style="width:5%; font-size:xx-small"><%#Eval("TYPED_RANGKA")%></td>
                    <td style="width:5%; font-size:xx-small"><%#Eval("DATA_TYPEDTEMP_TAHUN")%></td>
                    <td style="width:5%; font-size:xx-small"><%#Eval("TYPED_Jumlah")%></td>
                    <td style="width:5%; font-size:xx-small"><%#format(Eval("TYPED_Tanggal"),"dd-MM-yy HH:MM")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>        
        </asp:View>
        </asp:MultiView>
    </asp:View>
    <asp:View ID="View2" runat="server">
            
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr> 
                <td style="width: 30%; background-color: #000000;  color: #FFFFFF; height: 26px;">
                   <asp:Label ID="Label42" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Kode"></asp:Label>
                </td>
                <td style="width: 70%; height: 26px;">
                    <asp:Label ID="lblTipeKode" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label34" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Tipe"></asp:Label>
                </td>
                <td style="width: 70%; ">
                    <asp:Label ID="lblTipeNama" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Group"></asp:Label>
                </td>
                <td style="width: 70%; ">
                    <asp:Label ID="lblGroup" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Aktif"></asp:Label>
                </td>
                <td style="width: 70%; ">
                    <asp:Label ID="LblAktif" runat="server"></asp:Label>
                </td>
            </tr>

        </table>


        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr> 
                <td style="width: 100%; height: 26px;">
                    "DATA DISKON PERUBAHNNYA"
                </td>
            </tr>
        </table>
        
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 10%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Key 1"></asp:Label>
                </td>
                <td style="width: 10%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label17" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Thn"></asp:Label>
                </td>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Max Diskon"></asp:Label>
                </td>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Mulai Aktif"></asp:Label>
                </td>

                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label18" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Max Diskon"></asp:Label>
                </td>
                <td style="width: 15%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label19" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Mulai Aktif"></asp:Label>
                </td>
                <td style="width: 10%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label20" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Satu Tipe"></asp:Label>
                </td>
                <td style="width: 10%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label21" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Satu Group"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl01NewKey1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl01NewThn" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl01OldMax" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl01OldTgl" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:TextBox ID="Txt01NewMax" runat="server" text="" Width="150px"></asp:TextBox>
                </td>
                <td style="width: 15%;">
                
                <asp:TextBox ID="Txt01NewTgl" runat="server" Width="80" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" />
                <asp:ImageButton ID="ImgBntCalc" runat="server" CausesValidation="False" BackColor="Yellow" Height="20px" ImageUrl="~/calendar.png" />
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                 TargetControlID="Txt01NewTgl" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                 OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="None" AcceptNegative="Left" ErrorTooltipEnabled="True" />               
                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                ControlExtender="MaskedEditExtender1" ControlToValidate="Txt01NewTgl" EmptyValueMessage="Date is required"
                InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                EmptyValueBlurredText="*" 
                        InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" 
                        ValidationGroup="MKE" >
                </ajaxToolkit:MaskedEditValidator>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Txt01NewTgl" PopupButtonID="ImgBntCalc" />
                
                </td>
                <td style="width: 10%;">
                    <asp:Button ID="Button11" runat="server" Text="Simpan" />
                </td>
                <td style="width: 10%;">
                    <asp:Button ID="Button12" runat="server" Text="Simpan" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl02NewKey1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl02NewThn" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl02OldMax" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl02OldTgl" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>

                <td style="width: 15%;">
                    <asp:TextBox ID="Txt02NewMax" runat="server" text="" Width="150px"></asp:TextBox>
                </td>
                <td style="width: 15%;">
                <asp:TextBox ID="Txt02NewTgl" runat="server" Width="80" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" />
                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" BackColor="Yellow" Height="20px" ImageUrl="~/calendar.png" />
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                 TargetControlID="Txt02NewTgl" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                 OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="None" AcceptNegative="Left" ErrorTooltipEnabled="True" />               
                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
                ControlExtender="MaskedEditExtender2" ControlToValidate="Txt02NewTgl" EmptyValueMessage="Date is required"
                InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                EmptyValueBlurredText="*" 
                        InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" 
                        ValidationGroup="MKE" >
                </ajaxToolkit:MaskedEditValidator>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Txt02NewTgl" PopupButtonID="ImgBntCalc" />
                </td>
                <td style="width: 10%;">
                    <asp:Button ID="Button21" runat="server" Text="Simpan" />
                </td>
                <td style="width: 10%;">
                    <asp:Button ID="Button22" runat="server" Text="Simpan" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl03NewKey1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl03NewThn" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl03OldMax" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl03OldTgl" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:TextBox ID="Txt03NewMax" runat="server" text="" Width="150px"></asp:TextBox>
                </td>
                <td style="width: 15%;">
                <asp:TextBox ID="Txt03NewTgl" runat="server" Width="80" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" />
                <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" BackColor="Yellow" Height="20px" ImageUrl="~/calendar.png" />
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server"
                 TargetControlID="Txt03NewTgl" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                 OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="None" AcceptNegative="Left" ErrorTooltipEnabled="True" />               
                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator4" runat="server"
                ControlExtender="MaskedEditExtender4" ControlToValidate="Txt03NewTgl" EmptyValueMessage="Date is required"
                InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                EmptyValueBlurredText="*" 
                        InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" 
                        ValidationGroup="MKE" >
                </ajaxToolkit:MaskedEditValidator>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="Txt03NewTgl" PopupButtonID="ImgBntCalc" />
                </td>
                <td style="width: 10%;">
                    <asp:Button ID="Button31" runat="server" Text="Simpan" />
                </td>
                <td style="width: 10%;">
                    <asp:Button ID="Button32" runat="server" Text="Simpan" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl04NewKey1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 10%;">
                    <asp:Label ID="Lbl04NewThn" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl04OldMAx" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>
                <td style="width: 15%;">
                    <asp:Label ID="Lbl04OldTgl" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=""></asp:Label>
                </td>

                <td style="width: 15%;">
                    <asp:TextBox ID="Txt04NewMax" runat="server" text="" Width="150px"></asp:TextBox>
                </td>
                <td style="width: 15%;">
                <asp:TextBox ID="Txt04NewTgl" runat="server" Width="80" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" />
                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" BackColor="Yellow" Height="20px" ImageUrl="~/calendar.png" />
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                 TargetControlID="Txt04NewTgl" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                 OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="None" AcceptNegative="Left" ErrorTooltipEnabled="True" />               
                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator3" runat="server"
                ControlExtender="MaskedEditExtender3" ControlToValidate="Txt04NewTgl" EmptyValueMessage="Date is required"
                InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                EmptyValueBlurredText="*" 
                        InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" 
                        ValidationGroup="MKE" >
                </ajaxToolkit:MaskedEditValidator>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="Txt04NewTgl" PopupButtonID="ImgBntCalc" />
                </td>
                <td style="width: 10%;">
                    <asp:Button ID="Button41" runat="server" Text="Simpan" />
                </td>
                <td style="width: 10%;">
                    <asp:Button ID="Button42" runat="server" Text="Simpan" />
                </td>
            </tr>
        </table>

        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr> 
                <td style="width: 100%; height: 26px;">
                    <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "58px" 
                        Text="Catatan : Jika Pilih Simpan pada kolom Satu Tipe berarti Hanya satu tipe yang ditambah kalau Satu Group akan menyebabkan penambahan Diskon Maksimal dalam satu group"></asp:Label>
                </td>
            </tr>
        </table>
        
        <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 100%;  color: #FFFFFF;">
                <asp:Button ID="BtnKembali1" runat="server" Text="Kembali" Width="100%" 
                    Font-Size="X-Large" Height="39px" />    
            </td>
            </tr>
        </table>

       
    </asp:View>
    </asp:MultiView>

</asp:Content>

