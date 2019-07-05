<%@ Page Language="VB" MasterPageFile ="~/MasterPage.master"  AutoEventWireup="false" CodeFile="Form0202StatusSPK00PersetujuaBukaFaktur.aspx.vb" Inherits="Form0202StatusSPK00PersetujuaBukaFaktur" %>

<%@ MasterType virtualpath = "~/MasterPage.master"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    
    <div>
            <center>
                <h2 style="font-family:Cooper Black;">FORM PERSETUJUAN</h2>
            </center>
	</div>  
    <center>
    <p   style ="font-size: small" >
        &nbsp;User&nbsp; : 
        <asp:Label ID="LblUserNameLvl1" runat="server"></asp:Label>
        <asp:Label ID="LblUserIdLvl1" runat="server"></asp:Label>
        <asp:Label ID="lblAksesLvl1" runat="server"></asp:Label>
        &nbsp; Akses Dealer &nbsp; : 
        <asp:Label ID="lblArea1Lvl1" runat="server"></asp:Label>
        <asp:Label ID="lblArea2Lvl1" runat="server"></asp:Label>
        <asp:Label ID="LblTglSystemLvl1" runat="server"></asp:Label>
    </p>
            </center>
       
    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
    <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="95%">Error Message</asp:Label>
    </asp:View> 
    </asp:MultiView>

    <asp:MultiView ID="MultiView1" runat="server" Visible="TRUE">
    <asp:View ID="View15" runat="server">
    <asp:Label ID="Label45" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="95%">Error Message</asp:Label>
    </asp:View> 
    </asp:MultiView>



    <asp:MultiView ID="MultiViewUtama" runat="server" Visible="TRUE">
    <asp:View ID="View1" runat="server">
        
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 20%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label40" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Posisi</asp:Label>
                </td>
                <td style="width: 80%; ">
                <asp:TextBox ID="TxtPosJab" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="12%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
                <asp:Label ID="Label41" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">[0]Kepala Suku Cadang [1]Service Manager</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 20%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label39" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Kode Dealer</asp:Label>
                </td>
                <td style="width: 80%; ">
                <asp:TextBox ID="TxtDealerCD" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="6%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
                <asp:TextBox ID="TxtPosApv" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="6%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
                    <asp:Label ID="lblColomError" runat="server" Font-Names="Arial" 
                        Font-Size="Small" height="21px"></asp:Label>
                </td>
            </tr>
        </table>     
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
            <tr>
                <td style="width: 100%; ">
                <asp:Button ID="Button1" runat="server" 
                        Text="Klik untuk Melihat Tabel Permohonan Batal" Width="90%" 
                    Font-Overline="False" Font-Size="Small" BackColor="#0033CC"   />    
                </td>
            </tr>
        </table>     
        
        <asp:MultiView ID="MultiView11a" runat="server" Visible="TRUE">
        
        
        <asp:View ID="View11a1" runat="server">        
        
        <asp:ListView ID="LvTabelMohon" 
            OnSelectedIndexChanging="TblMohonView_SelectedIndexChanging" 
            OnPagePropertiesChanging="TblMohonView_PagePropertiesChanging"
            runat="server">
            <LayoutTemplate>
                <table id="table-a"  border="2" width="100%" style="border-collapse:collapse;">
                <thead  style="background-color:Silver">
                <th>Detail</th><th>Nomor</th><th>Tanggal Input</th><th>WO</th><th>Judul</th><th>Alasan</th><th>Setuju</th><th>Batal</th><th>Pos #1</th><th>Pos #2</th><th>Pemohon</th><th>Dlr</th>
                </thead>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            
            <asp:DataPager ID="dpBerita" PageSize="10" runat="server">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" ShowLastPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false" ShowNextPageButton="true" ShowLastPageButton="true" />
            </Fields>
            </asp:DataPager>
            </LayoutTemplate>
            
            <ItemTemplate>
                    <tr>
                    <td style="width:6%; font-size: x-small">
                    <asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" /></td>
                    <td style="width:10%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_WEBAPPV_NOMOHON" runat="server" Text='<%#Eval("Temp_WEBAPPV_NOMOHON")%>'/></td>
                    <td style="width:8%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WEBAPPV_INPUT" runat="server" Text='<%#Eval("Temp_WEBAPPV_INPUT")%>' /></td>
                    <td style="width:8%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WEBAPPV_NOWO" runat="server" Text='<%#Eval("Temp_WEBAPPV_NOWO")%>' /></td>
                    <td style="width:15%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_WEBAPPV_JUDUL" runat="server" Text='<%#Eval("Temp_WEBAPPV_JUDUL")%>' /></td>
                    <td style="width:15%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_WEBAPPV_ALASAN" runat="server" Text='<%#Eval("Temp_WEBAPPV_ALASAN")%>' /></td>
                    <td style="width:8%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WEBAPPV_SETUJU" runat="server" Text='<%#Eval("Temp_WEBAPPV_SETUJU")%>' /></td>
                    <td style="width:8%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WEBAPPV_BATAL" runat="server" Text='<%#Eval("Temp_WEBAPPV_BATAL")%>' /></td>
                    <td style="width:5%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WEBAPPV_APPROVED" runat="server" Text='<%#Eval("Temp_WEBAPPV_APPROVED")%>' /></td>
                    <td style="width:5%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WEBAPPV_APPROVEDP" runat="server" Text='<%#Eval("Temp_WEBAPPV_APPROVEDP")%>'/></td>
                    <td style="width:8%; font-size:x-small"   valign="top"><asp:Label ID="lbl_WEBAPPV_USER" runat="server" Text='<%#Eval("Temp_WEBAPPV_USER")%>'/></td>
                    <td style="width:4%; font-size:x-small"   valign="top"><asp:Label ID="lbl_WEBAPPV_DLR" runat="server" Text='<%#Eval("Temp_WEBAPPV_DLR")%>'/></td>
                    </tr>
            </ItemTemplate>

            <SelectedItemTemplate>
                    <tr id="Tr1" runat="server" style="background-color:#ADD8E6">
                    <td>&nbsp;</td>
                    <td style="width:10%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_WEBAPPV_NOMOHON" runat="server" Text='<%#Eval("Temp_WEBAPPV_NOMOHON")%>'/></td>
                    <td style="width:8%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WEBAPPV_INPUT" runat="server" Text='<%#Eval("Temp_WEBAPPV_INPUT")%>' /></td>
                    <td style="width:8%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WEBAPPV_NOWO" runat="server" Text='<%#Eval("Temp_WEBAPPV_NOWO")%>' /></td>
                    <td style="width:15%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_WEBAPPV_JUDUL" runat="server" Text='<%#Eval("Temp_WEBAPPV_JUDUL")%>' /></td>
                    <td style="width:15%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_WEBAPPV_ALASAN" runat="server" Text='<%#Eval("Temp_WEBAPPV_ALASAN")%>' /></td>
                    <td style="width:8%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WEBAPPV_SETUJU" runat="server" Text='<%#Eval("Temp_WEBAPPV_SETUJU")%>' /></td>
                    <td style="width:8%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WEBAPPV_BATAL" runat="server" Text='<%#Eval("Temp_WEBAPPV_BATAL")%>' /></td>
                    <td style="width:5%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WEBAPPV_APPROVED" runat="server" Text='<%#Eval("Temp_WEBAPPV_APPROVED")%>' /></td>
                    <td style="width:5%; font-size:x-small"   valign="top"><asp:Label ID="Lbl_WEBAPPV_APPROVEDP" runat="server" Text='<%#Eval("Temp_WEBAPPV_APPROVEDP")%>'/></td>
                    <td style="width:8%; font-size:x-small"   valign="top"><asp:Label ID="lbl_WEBAPPV_USER" runat="server" Text='<%#Eval("Temp_WEBAPPV_USER")%>'/></td>
                    <td style="width:4%; font-size:x-small"   valign="top"><asp:Label ID="lbl_WEBAPPV_DLR" runat="server" Text='<%#Eval("Temp_WEBAPPV_DLR")%>'/></td>
                    </tr>
            </SelectedItemTemplate>
            </asp:ListView>        

        
        </asp:View>         
        </asp:MultiView>

    </asp:View>
    <asp:View ID="View2" runat="server">
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Data Faktur</h2>
            </center>
	    </div>  
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Nomor Mohon" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF;">
                    <asp:Label ID="LblMohonNomor" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Label8" runat="server" Text=" / Pemohon : "></asp:Label>
                    <asp:Label ID="LblMohonUser" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Label16" runat="server" Text=" / Tanggal : "></asp:Label>
                    <asp:Label ID="LblMohonTgl" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                <asp:Label ID="Label23" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Judul" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="LblMohonJudul" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="Label17" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Alasan" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF;">
                    <asp:Label ID="LblMohonAlasan" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#FF0000;">
                <asp:Label ID="Label20" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Masalah" ForeColor="White"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="LblMohonMasalah" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="Label35" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Kode Jabatan" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF;">
                    <asp:Label ID="Label36" runat="server" Text="Kode 0 dan 1 adalah Head Parts dan Kode 2 adalah Kepala Suku Cadang"></asp:Label>
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
                <asp:Label ID="Label30" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Yg Hrs Menyetujui Kode " ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblApproved" runat="server"></asp:Label>
                </td>
                <td style="width: 25%; ">
                <asp:Label ID="Label33" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Proses Menyetuju sdh sampai" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblApprovedP" runat="server" Text=""></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Nomor Faktur" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblNoFaktur" runat="server"></asp:Label>
                    <asp:Label ID="LblNoFakturP" runat="server"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Dealer" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="lblDealer" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                   <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Work Order [YYYY-MM-DD]" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblTglInput" runat="server"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Tanggal Faktur [YYYY-MM-DD]" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblTglFaktur" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                   <asp:Label ID="Label77" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Proses Parts [YYYY-MM-DD]" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblTglPartInput" runat="server"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label86" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Faktur Parts [YYYY-MM-DD]" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblTglPartFaktur" runat="server"></asp:Label>
                </td>
            </tr>
            
            </table>           
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Data Pelanggan dan kendaraan</h2>
            </center>
	    </div>  
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Nomor Polisi" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="LblFakturNopol" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px"></asp:Label>
                    <asp:Label ID="LblFakturNama" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Kode Tagih" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF;">
                    <asp:Label ID="LblFakturTagihNo" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ></asp:Label>
                    <asp:Label ID="LblFakturTagihNama" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height="21px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label29" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jenis Pekerjaan" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; background-color:#CCCCFF;">
                    <asp:Label ID="LblKerja" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ></asp:Label>
                </td>
            </tr>

            <tr> 
                <td style="width: 25%; ">
                   <asp:Label ID="Label18" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Service Advisor" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Label ID="LblFakturSA" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px"></asp:Label>
                </td>
            </tr>

            </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Nomor Rangka" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="lblFakturNorangka" runat="server"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tahun" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="lblFakturTahun" runat="server" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Tipe" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblFakturCdType" runat="server"></asp:Label>
                    <asp:Label ID="LblFakturTipe" runat="server" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                   <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="Small" 
                        height= "21px" Text="Warna"  ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblFakturWarna" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Harga</h2>
            </center>
	    </div>  
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
        </table>
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">

            <tr>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label31" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total Item Jasa" ForeColor="Black"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblJasaItem" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label34" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total Item Suku Cadang"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblPartsItem" runat="server" Text=""></asp:Label>
            </td>
            </tr>

            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total Jasa" ForeColor="Black"></asp:Label></td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblRpJasa" runat="server" Text=""></asp:Label>
                </td>
                
                <td style="width: ">
                    <asp:Label ID="Label26" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Qty Suku Cadang" ForeColor="Black" Width="224px" ></asp:Label></td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblPartsQty" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label14" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Potongan Jasa" ForeColor="Black"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblRpDisc" runat="server" Text=""></asp:Label>
            </td>
            
            
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label81" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total Parts"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblPartsTotal" runat="server"></asp:Label>
            </td>
            </tr>
            
            <tr>
                <td style="width: 25%; ">
                    <asp:Label ID="Label71" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Suku Cadang"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    <asp:Label ID="LblRpParts" runat="server" ForeColor="Black"></asp:Label>
                </td>
                <td style="width: 25%; ">
               <asp:Label ID="Label72" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Potongan" ForeColor="Black"></asp:Label> </td>
                <td style="width: 25%; ">
                <asp:Label ID="LblPartsDisc" runat="server"></asp:Label>
                <asp:Label ID="LblPartsDisc0" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label76" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="DPP"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="LblRpDPP" runat="server" ForeColor="Black"></asp:Label>
            </td>
            <td style="width: 25%; background-color:#CCCCFF;">
                    <asp:Label ID="Label21" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="DPP"></asp:Label>

            </td>
            <td style="width: 25%;background-color:#CCCCFF;">
                <asp:Label ID="LblPartsDPP" runat="server"></asp:Label>
            </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="PPN" ForeColor="Black"></asp:Label>     
                </td>
                <td style="width: 25%; ">
                <asp:Label ID="LblRpPPN" runat="server"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    &nbsp;</td>
                <td style="width: 25%; ">
                </td>
            </tr>
            <tr>
                <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="Label22" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Total" ForeColor="Black"></asp:Label>     
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                <asp:Label ID="LblRpTotal" runat="server"></asp:Label>
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                </td>
                <td style="width: 25%; background-color:#CCCCFF;">
                </td>
            </tr>
        </table>


        <asp:MultiView ID="MultiViewPekerjaan" runat="server" Visible="TRUE">
        <asp:View ID="ViewPekerjaan" runat="server">
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Detail Pekerjaan</h2>
            </center>
	    </div>  
        <asp:ListView ID="LvTabelPekerjaan" runat="server">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%" style="border-collapse:collapse;">
            <thead  style="background-color:Silver">
            <th>Kode</th><th>Keterangan</th><th>Harga</th>
            </thead>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                <td style="width:5%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PekerjaanKode"  runat="server" Text='<%#Eval("Tmp_PekerjaanKode")%>'/></td>
                <td style="width:10%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PekerjaanDesc"   runat="server" Text='<%#Eval("Tmp_PekerjaanDesc")%>'/></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PekerjaanHarga"  runat="server" Text='<%#Eval("Tmp_PekerjaanHarga")%>'/></td>
                </tr>
            </ItemTemplate>
            </asp:ListView>        
        </asp:View>
        </asp:MultiView>
        <asp:MultiView ID="MultiViewParts" runat="server" Visible="TRUE">
        <asp:View ID="ViewParts" runat="server">
        <div>
            <center>
                <h2 style="font-family:Cooper Black; color: #FF0000; font-size: x-large;">Detail Suku Cadang</h2>
            </center>
	    </div>  
            <asp:ListView ID="LvTabelParts" runat="server">
            <LayoutTemplate>
            <table id="table-a"  border="2" width="100%" style="border-collapse:collapse;">
            <thead  style="background-color:Silver">
            <th>Kode</th><th>Nama Parts</th><th>Qty</th><th>Harga</th><th>Total</th>
            </thead>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                <td style="width:05%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PartsKode"  runat="server" Text='<%#Eval("Tmp_Partskode")%>'/></td>
                <td style="width:35%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PartsNama"   runat="server" Text='<%#Eval("Tmp_PartsNama")%>'/></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PartsQty"  runat="server" Text='<%#Eval("Tmp_PartsQty")%>'/></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PartsHrg" runat="server" Text='<%#Eval("Tmp_PartsHrg")%>' /></td>
                <td style="width:20%; font-size:x-small"  valign="top"><asp:Label ID="Lbl_PartsTot" runat="server" Text='<%#Eval("Tmp_PartsTot")%>' /></td>
                </tr>
            </ItemTemplate>
            </asp:ListView>        
        </asp:View>
        </asp:MultiView>
        
        <asp:MultiView ID="MultiView0S" runat="server" Visible="TRUE">
            <asp:View ID="View0S1" runat="server">
            <div>
            <center>
                <h1 style="font-family:Cooper Black; color: #000000; font-size: large;">Persetujuan Kepala Suku Cadang</h1>
            </center>
            <center>
                   <asp:Label ID="Label19" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Disetujui Head Suku Cadang oleh "></asp:Label>
                   <asp:Label ID="lblUserSetuju0" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red"></asp:Label>
                   <asp:Label ID="Label44" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="   Tanggal "></asp:Label>
                   <asp:Label ID="lblTglsetuju0" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red"></asp:Label>
            </center>
            </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label24" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Hasil/Catatan"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtCatatan0" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Height="50px" Width="95%" MaxLength="100" TabIndex ="7"  
                        AutoPostBack="true"   ></asp:TextBox>
                </td>
                </tr>
            </table>
            <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
                <tr>
                   <td style="width: 25%;  color: #FFFFFF;">&nbsp;</td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="ButtonSetuju0" runat="server" Text="Setuju" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="#004080" />                             
                        <div id="flyoutBS0" style="display: none; overflow: hidden; z-index: 2; background-color: #FFFFFF; border: solid 1px #D0D0D0;"></div>
                        <div id="infoBS0" style="display: none; width: 250px; z-index: 2; font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
                            <div id="btnCloseParentBS0" style="float: right; visibility :hidden">
                                <asp:LinkButton id="btnCloseBS0" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                                     Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
                            </div>
                            <div><p>Tunggu Sedang Sistem sedang melakukan proses simpan sampai pesan ini tidak tertampil..................</p><br />
                            </div>
                        </div>        
                        <ajaxToolkit:AnimationExtender id="OpenAnimationBS0" runat="server" TargetControlID="ButtonSetuju0"><Animations>
                                <OnClick>
                                    <Sequence>
                                    <EnableAction Enabled="false" />
                                    <ScriptAction Script="Cover($get('ctl00_SampleContent_ButtonSetuju0'), $get('flyoutBS0'));" />
                                    <StyleAction AnimationTarget="flyoutBS0" Attribute="display" Value="block"/>
                                    <Parallel AnimationTarget="flyoutBS0" Duration=".3" Fps="25">
                                        <Move Horizontal="150" Vertical="-50" />
                                        <Resize Width="260" Height="280" />
                                        <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                                    </Parallel>
                                    <ScriptAction Script="Cover($get('flyoutBS0'), $get('infoBS0'), true);" />
                                    <StyleAction AnimationTarget="infoBS0" Attribute="display" Value="block"/>
                                    <FadeIn AnimationTarget="infoBS0" Duration=".2"/>
                                    <StyleAction AnimationTarget="flyoutBS0" Attribute="display" Value="none"/>
                                    <Parallel AnimationTarget="infoBS0" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                                        <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                                    </Parallel>
                                    <Parallel AnimationTarget="infoBS0" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                                        <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                                        <FadeIn AnimationTarget="btnCloseParentBS0" MaximumOpacity=".9" />
                                    </Parallel>
                                    </Sequence>
                                </OnClick>
                            </Animations></ajaxToolkit:AnimationExtender>
                        <ajaxToolkit:AnimationExtender id="CloseAnimationBS0" runat="server" TargetControlID="btnCloseBS0"><Animations>
                            <OnClick>
                            <Sequence AnimationTarget="infoBS0">
                            <StyleAction Attribute="overflow" Value="hidden"/>
                            <Parallel Duration=".3" Fps="15">
                                <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                                <FadeOut />
                            </Parallel>
                            <StyleAction Attribute="display" Value="none"/>
                            <StyleAction Attribute="width" Value="250px"/>
                            <StyleAction Attribute="height" Value=""/>
                            <StyleAction Attribute="fontSize" Value="12px"/>
                            <OpacityAction AnimationTarget="btnCloseParentBS0" Opacity="0" />
                            <EnableAction AnimationTarget="ButtonSetuju0" Enabled="true" />
                            </Sequence>
                            </OnClick>
                            <OnMouseOver>
                            <Color Duration=".2" PropertyKey="color" StartValue="#FFFFFF" EndValue="#FF0000" />
                            </OnMouseOver>
                            <OnMouseOut>
                            <Color Duration=".2" PropertyKey="color" StartValue="#FF0000" EndValue="#FFFFFF" />
                            </OnMouseOut>
                        </Animations></ajaxToolkit:AnimationExtender>
                   </td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="BtnTolak0" runat="server" Text="Tolak" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="Red" />    
                   </td>
                </tr>
            </table>
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiView1S" runat="server" Visible="TRUE">
            <asp:View ID="View1S1" runat="server">
            <div>
            <center>
                <h1 style="font-family:Cooper Black; color: #000000; font-size: large;">Persetujuan Service Manager</h1>
            </center>
            <center>
                   <asp:Label ID="Label25" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Disetujui Sales Manager Oleh "></asp:Label>
                    
                   <asp:Label ID="lblUserSetuju1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red" Text="__:__"></asp:Label>
                   <asp:Label ID="Label28" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text=" Tanggal "></asp:Label>
                    <asp:Label ID="lblTglSetuju1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" ForeColor="Red"></asp:Label>
            </center>
            </div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                <tr>
                <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                    <asp:Label ID="Label27" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Catatan SM"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:TextBox ID="TxtCatatan1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    Height="50px" Width="95%" MaxLength="100" TabIndex ="7"  
                        AutoPostBack="true"   ></asp:TextBox>
                </td>
                </tr>
            </table>
            <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
                <tr>
                   <td style="width: 25%;  color: #FFFFFF;">&nbsp;</td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="ButtonSetuju1" runat="server" Text="Setuju" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="#004080" />    
                        <div id="flyoutBS1" style="display: none; overflow: hidden; z-index: 2; background-color: #FFFFFF; border: solid 1px #D0D0D0;"></div>
                        <div id="infoBS1" style="display: none; width: 250px; z-index: 2; font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
                            <div id="btnCloseParentBS1" style="float: right; visibility :hidden">
                                <asp:LinkButton id="btnCloseBS1" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                                     Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
                            </div>
                            <div><p>Tunggu Sedang Sistem sedang melakukan proses simpan sampai pesan ini tidak tertampil..................</p><br />
                            </div>
                        </div>        
                        <ajaxToolkit:AnimationExtender id="OpenAnimationBS1" runat="server" TargetControlID="ButtonSetuju1"><Animations>
                                <OnClick>
                                    <Sequence>
                                    <EnableAction Enabled="false" />
                                    <ScriptAction Script="Cover($get('ctl00_SampleContent_ButtonSetuju1'), $get('flyoutBS1'));" />
                                    <StyleAction AnimationTarget="flyoutBS1" Attribute="display" Value="block"/>
                                    <Parallel AnimationTarget="flyoutBS1" Duration=".3" Fps="25">
                                        <Move Horizontal="150" Vertical="-50" />
                                        <Resize Width="260" Height="280" />
                                        <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                                    </Parallel>
                                    <ScriptAction Script="Cover($get('flyoutBS1'), $get('infoBS1'), true);" />
                                    <StyleAction AnimationTarget="infoBS1" Attribute="display" Value="block"/>
                                    <FadeIn AnimationTarget="infoBS1" Duration=".2"/>
                                    <StyleAction AnimationTarget="flyoutBS1" Attribute="display" Value="none"/>
                                    <Parallel AnimationTarget="infoBS1" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                                        <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                                    </Parallel>
                                    <Parallel AnimationTarget="infoBS1" Duration=".5">
                                        <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                                        <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                                        <FadeIn AnimationTarget="btnCloseParentBS1" MaximumOpacity=".9" />
                                    </Parallel>
                                    </Sequence>
                                </OnClick>
                            </Animations></ajaxToolkit:AnimationExtender>
                        <ajaxToolkit:AnimationExtender id="CloseAnimationBS1" runat="server" TargetControlID="btnCloseBS1"><Animations>
                            <OnClick>
                            <Sequence AnimationTarget="infoBS1">
                            <StyleAction Attribute="overflow" Value="hidden"/>
                            <Parallel Duration=".3" Fps="15">
                                <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                                <FadeOut />
                            </Parallel>
                            <StyleAction Attribute="display" Value="none"/>
                            <StyleAction Attribute="width" Value="250px"/>
                            <StyleAction Attribute="height" Value=""/>
                            <StyleAction Attribute="fontSize" Value="12px"/>
                            <OpacityAction AnimationTarget="btnCloseParentBS1" Opacity="0" />
                            <EnableAction AnimationTarget="ButtonSetuju1" Enabled="true" />
                            </Sequence>
                            </OnClick>
                            <OnMouseOver>
                            <Color Duration=".2" PropertyKey="color" StartValue="#FFFFFF" EndValue="#FF0000" />
                            </OnMouseOver>
                            <OnMouseOut>
                            <Color Duration=".2" PropertyKey="color" StartValue="#FF0000" EndValue="#FFFFFF" />
                            </OnMouseOut>
                        </Animations></ajaxToolkit:AnimationExtender>
                   </td>
                   <td style="width: 30%;  color: #FFFFFF;">
                        <asp:Button ID="BtnTolak1" runat="server" Text="Tolak" Width="321px" 
                         Font-Size="X-Large" Height="39px" BackColor="Red" />    
                   </td>
                </tr>
            </table>
            </asp:View> 
        </asp:MultiView>
         
         
        <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 100%;  color: #FFFFFF;">
                <asp:Button ID="BtnKembali1" runat="server" Text="Kembali" Width="95%" 
                    Font-Size="X-Large" Height="39px" />    
            </td>
            </tr>
        </table>

    </asp:View>
    </asp:MultiView>

</asp:Content>
