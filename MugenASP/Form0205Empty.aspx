<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"    AutoEventWireup="false" CodeFile="Form0205Empty.aspx.vb" Inherits="Form03IjinKerja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p   style ="font-size:smaller" >
        <asp:Label ID="Label44"  Text ="Ijin Keluar/Cuti >> " runat="server"></asp:Label>
        &nbsp; Nama User&nbsp; : 
        <asp:Label ID="LblUserName" runat="server"></asp:Label>
        <asp:Label ID="lblAkses" runat="server"></asp:Label>
        &nbsp; Akses &nbsp; : 
        <asp:Label ID="lblArea1" runat="server"></asp:Label>
        <asp:Label ID="lblArea2" runat="server"></asp:Label>
    </p>
       
  <asp:SqlDataSource ID="sdsTabelIjin" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>" 
            SelectCommand="SELECT * FROM [ABSEN_KERJA]"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>"></asp:SqlDataSource>                 
       
  <asp:SqlDataSource ID="sdsTabelIjin0" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>" 
            SelectCommand="SELECT * FROM [ABSEN_KERJA]"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>"></asp:SqlDataSource>                 
  <asp:MultiView ID="MultiView1a" runat="server" Visible="TRUE">
    <asp:View ID="View1" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 13%; background-color: #000000;  color: #FFFFFF;">
                   <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px">Tanggal permohonan</asp:Label>
            </td>
            <td style="width: 75%; ">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 13%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Judul Permohonan</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtCariJudul" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true" Text ="ENTRY"   ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 13%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label29" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Nomor Rangka</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtCariNoRangka" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 13%; background-color: #000000;  color: #FFFFFF;">
                <asp:Button ID="Button2" runat="server" Font-Overline="False" Font-Size="Small" 
                    Text="PERMOHONAN BARU" Width="222px" />
            </td>
            <td style="width: 75%; ">
                <asp:Button ID="Button1" runat="server" Text="Pencarian Data" Width="394px" 
                    Font-Overline="False" Font-Size="Larger"   />    
            </td>
        </tr>
        </table>            
        <asp:ListView ID="lvBerita" runat="server" DataSourceID="sdsTabelIjin" DataKeyNames ="KERJA_NOMOR">
        <LayoutTemplate>
            <table border="2" width="100%"  style="border-collapse:collapse;">
                    <thead>
                      <th>Nomor</th><th>Tanggal Ijin Mulai</th><th>Tanggal Ijin Selesai</th><th>Jenis</th><th>Pemohon</th><th>Posisi</th><th>Dept</th><th>Tanggal Mohon</th><th>Status Ijin Atasan 1</th><th>Status Ijin Atasan 2</th><th>Alasan</th>
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
                    <td style="width:10%; font-size: small">
                       <asp:LinkButton ID="lnkSelect" Text='<%# Eval("KERJA_NOMOR") %>' CommandName="Select" runat="server" />
                    </td>
                    <td style="width:10%; font-size: small"><%#Eval("KERJA_IJIN1")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("KERJA_IJIN2")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("KERJA_JENIS")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("KERJA_USER")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("KERJA_POSISI")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("KERJA_DEPT")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("KERJA_TGLMOHHON")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("KERJA_USERSETUJUASTATUS")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("KERJA_USERSETUJUBSTATUS")%></td>
                    <td style="width:10%; font-size: small"><%#Eval("KERJA_CATATAN")%></td>
                </tr>
        </ItemTemplate>
        </asp:ListView>
            </asp:View>
    
    <asp:View ID="View2" runat="server">
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="lblNomor" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="Pemohon" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal mohon [YYYY-MM-DD]" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="LblTglSPK" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Departement" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
            
                <asp:DropDownList ID="DropDownDept" runat="server" Width="276px">
                    <asp:ListItem Value="1">HRD</asp:ListItem>
                    <asp:ListItem>IT</asp:ListItem>
                    <asp:ListItem>ACCOUTING</asp:ListItem>
                    <asp:ListItem>WAREHOUSE</asp:ListItem>
                    <asp:ListItem Value="SALES">ADM SALES</asp:ListItem>
                    <asp:ListItem>ADM SERVICE</asp:ListItem>
                    <asp:ListItem>SALES</asp:ListItem>
                    <asp:ListItem>SERVICE</asp:ListItem>
                </asp:DropDownList>
            
            </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Posisi" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
            
                <asp:DropDownList ID="DropDownList1" runat="server" Width="276px">
                    <asp:ListItem Value="1">Staff</asp:ListItem>
                    <asp:ListItem>SPV</asp:ListItem>
                    <asp:ListItem>MANAGER</asp:ListItem>
                </asp:DropDownList>
            
            </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label24" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal masuk [YYYY-MM-DD]" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtTglMasuk" runat="server" />
                <asp:Button ID="ButtonMasuk" runat="server" Text="K" Width="27px" />
                <div id="tanggalPopup">
                <asp:Calendar ID="CalenderMasuk" runat="server" 
                        onselectionchanged="Masuk_SelectionChanged" />
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label26" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Sisa cuti" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtJmlharicuti" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label32" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jenis ijin" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                 <asp:DropDownList ID="DropDownIjin" runat="server" Width="276px">
                    <asp:ListItem Value="1">TIDAK MASUK KERJA</asp:ListItem>
                    <asp:ListItem>KELUAR KANTOR</asp:ListItem>
                </asp:DropDownList>
                        </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label28" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Ijin mulai tanggal [YYYY-MM-DD]" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtTglMulai" runat="server" />
                <asp:Button ID="ButtonCalendar1" runat="server" Text="K" Width="27px" />
                <div id="Div1">
                <asp:Calendar ID="Calendar1" runat="server" onselectionchanged="DateStart_SelectionChanged" />
                </div>            
            </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label30" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Ijin berAkhir tanggal [YYYY-MM-DD]" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtTglAkhir" runat="server" />
                <asp:Button ID="ButtonCalendar2" runat="server" Text="K" Width="27px" />
                <div id="Div2">
                <asp:Calendar ID="Calendar2" runat="server" onselectionchanged="DateEnd_SelectionChanged" />
                </div>            
             </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Catatan" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtCatatann" runat="server" Width="536px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Persetujuan Tingkat 1" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="Lblusertingkat1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
         <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="LblTanggaltingkat1" runat="server" Text=""></asp:Label>
            </td>
        </tr>       
                <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Status" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:DropDownList ID="DropDownStatus1" runat="server" Width="276px">
                    <asp:ListItem Value="1">SETUJUI</asp:ListItem>
                    <asp:ListItem>DITOLAK</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label19" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Catatan" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtCatatantingkat1" runat="server" Width="542px"></asp:TextBox>
            </td>
        </tr>        
                <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Persetujuan Tingkat 2" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="Lblusertingkat2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
         <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tanggal" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="LblTanggaltingkat2" runat="server" Text=""></asp:Label>
            </td>
        </tr>       
                <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label17" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Status" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:DropDownList ID="DropDownStatus2" runat="server" Width="276px">
                    <asp:ListItem Value="1">SETUJUI</asp:ListItem>
                    <asp:ListItem>DITOLAK</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: Black;">
               <asp:Label ID="Label21" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Catatan" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtCatatantingkat2" runat="server" Width="529px"></asp:TextBox>
            </td>
        </tr>        
        
        </table>
        



<br />
<br />

    <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 25%; background-color: Green ;  color: #FFFFFF;">
                <asp:Button ID="BtnSetuju" runat="server" Text="Setuju" Width="202px" 
                    Height="26px" />    
            </td>
            <td style="width: 25%; background-color: Red  ;  color: #FFFFFF;">
                <asp:Button ID="BtnTolak" runat="server" Text="Tolak" Width="200px" />    
            </td>
            <td style="width: 25%; background-color: Green;  color: #FFFFFF;">
                <asp:Button ID="BtnKembali" runat="server" Text="Kembali" Width="201px" />    
            </td>
        </tr>
    </table>

            </asp:View>
        </asp:MultiView>

</asp:Content>
