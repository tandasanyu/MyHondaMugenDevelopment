<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"    AutoEventWireup="false" CodeFile="Form0202StatusSPK01AuditParts.aspx.vb" Inherits="Form0202StatusSPK01AuditParts" %>

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
   <asp:MultiView ID="MultiViewSuportLaporan1dan2" runat="server" Visible="TRUE">
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
            <td style="width: 5%; ">
                <asp:TextBox ID="TxtCabang" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="90%" MaxLength="3" TabIndex ="7"  AutoPostBack="true" Text ="112" 
                    Enabled="False"   ></asp:TextBox>
            </td>
            <td style="width: 70%; ">
               <asp:Button ID="ButtonPsm" runat="server" 
                    Text="Klik Disini Kode dealer" Width="23%" Height="100%"  
                    BackColor="White" Font-Bold="True" ForeColor="Black" BorderStyle="None" 
                    Font-Italic="True" Font-Underline="True" Style=" text-align:left" />
            </td>
            <td style="width: 25%; ">
                <asp:CheckBox ID="CheckBoxPerbarui" runat="server" Text="Perbaharui Tabel" 
                    Font-Bold="True" Font-Size="Small" />
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
<br />
<br />
     
    <asp:MultiView ID="MultiViewForm" runat="server" Visible="TRUE">
        <asp:View ID="ViewForm2" runat="server">
            <asp:MultiView ID="MultiViewForm21Query" runat="server" Visible="TRUE">
            <asp:View ID="ViewForm21Query" runat="server">
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
                <td style="width: 25%; Background-color:#CCCCFF;">
                   <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="Nomor Suku Cadang"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtPartsNO" runat="server" text="" Width="10%" AutoPostBack="true" CssClass="uppercase"></asp:TextBox>
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
                    <asp:TextBox ID="TxtPartsLantai" runat="server" text="" Width="20%" MaxLength="100" CssClass="uppercase"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; Background-color:#CCCCFF;">
                    <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px" Text="Jumlah Stok lebih besar sama dengan"></asp:Label>
                </td>
                <td style="width: 75%; Background-color:#CCCCFF;">
                    <asp:TextBox ID="TxtPartsStok" runat="server" text="-10" Width="20%" MaxLength="100" CssClass="uppercase"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                   <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="Small" height= "99%" Text="Tampilkan Suku Cadang"></asp:Label>
                </td>
                <td style="width: 75%; ">
                    <asp:Button ID="ButtonTabelPartsGO" runat="server" BackColor="#003399" Font-Overline="False" Font-Size="Small" Height="20px" Text="Cari Data berdasarkan Data Stok" />
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                </td>
                <td style="width: 75%; ">
                    <asp:Button ID="ButtonTabelPartsSM" runat="server" BackColor="#003399" 
                        Font-Overline="False" Font-Size="Small" Height="20px" 
                        Text="Cari Data berdasarkan Hasil Audit Selisih" />
                </td>
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

           <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 22%;background-color:#CCCCFF ;  ">
                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nomor Suku Cadang</asp:Label>
            </td>
            <td style="width: 75%;background-color:#CCCCFF ;  ">
                <asp:Label ID="LblPartsNo" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">....</asp:Label>
                <asp:Label ID="Label34" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">  Nama Suku Cadang  </asp:Label>
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
            </table>  
             
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">

            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Audit</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:TextBox ID="TxtPartsAuditQty" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="10%" MaxLength="10" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label14" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Catatan</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtPartsAuditNote" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="90%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Labellt2" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Lantai</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:TextBox ID="TxtPartsLantaiku" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="20%" MaxLength="8" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>

            <tr>
            <td style="width: 22%;  ">
                <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Auditor / Tgl Audit / Tgl Stok</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:Label ID="LblPartsUserNma" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:Label ID="Label23" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">../..</asp:Label>
                <asp:Label ID="LblPartsUserTgl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:Label ID="Label24" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">../..</asp:Label>
                <asp:Label ID="LblPartsStokTgl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%;background-color:#CCCCFF ; ">
                <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Status simpan</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ;">
                <asp:Label ID="LblPartsStatusSimpan" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>

            <tr>
            <td style="width: 22%;  ">
                <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Setelah Tersimpan langsung keluar</asp:Label>
            </td>
            <td style="width: 75%;  ">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Ya" />
            </td>
            </tr>


            </table>   
            </asp:View> 
            </asp:MultiView>



            <asp:MultiView ID="MultiViewForm22AuditTombol" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 50%; ">
               <asp:Button ID="BtnAuditSimpan" runat="server" Text="Simpan hasil Audit" Width="73%" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black" Height="31px"  />
            </td>
            <td style="width: 50%; ">
               <asp:Button ID="BtnAuditBack" runat="server" Text="Kembali Ke Tabel Utama" 
                    Width="73%" Height="31px" BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            </tr>
            </table>
            </asp:View> 
            </asp:MultiView>
                        
            <asp:MultiView ID="MultiViewForm22AuditNote2Tombol" runat="server" Visible="TRUE">
            <asp:View ID="View5" runat="server">            
            <div><center><h2 style="font-family:Cooper Black;">Penilaian/Adjusment Auditor</h2></center></div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label57" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Adjusment</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:TextBox ID="TxtAuditorAdjemsnt" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="50" MaxLength="10" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
                <asp:Label ID="Label58" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Visible="false"  >...</asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label59" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Catatan Auditor</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtAuditorNote" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="190%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label61" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nama/Tanggal</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:Label ID="LblAuditorUser" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:Label ID="LblAuditorTgl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
            </td>
            </tr>
            </table>   
            <br /> 
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 50%; ">
               <asp:Button ID="BtnAdditorSave" runat="server" Text="Simpan Catatan SPV Auditor" Width="73%"  Height="31px"
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 50%; ">
               <asp:Button ID="BtnAdditorBack" runat="server" Text="Kembali Ke Tabel Utama" 
                    Width="73%" Height="31px" BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            </tr>
            </table>
            </asp:View> 
            </asp:MultiView>
            
            <asp:MultiView ID="MultiViewForm22HeadPartsNote1Tombol" runat="server" Visible="TRUE">
            <asp:View ID="View4" runat="server">          
            <div><center><h2 style="font-family:Cooper Black;">Penilaian Head Parts</h2></center></div>  

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label35" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Catatan Dept Suku Cadang</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtHeadPartsNote" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="90%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label38" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nama/Tanggal Note</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:Label ID="lblHeadPartsUser" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Width="16px">...</asp:Label>
                <asp:Label ID="Label37" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">.../...</asp:Label>
                <asp:Label ID="lblHeadPartsTgl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>            
                <asp:Label ID="Label39" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:CheckBox ID="CheckBoxHeadParts" runat="server" Text ="Menyetujui hasil Auditor dan Penambahan dan pengurangan Parts Stok" />
                </td>
            </tr>
            </table>   
            <br />  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 50%; ">
               <asp:Button ID="BtnHeadPartsSave" runat="server" Text="Simpan Catatan Head Parts" Width="73%" Height="31px" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 50%; ">
               <asp:Button ID="BtnHeadPartsBack" runat="server" Text="Kembali Ke Tabel Utama" 
                    Width="73%" Height="31px" BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            </tr>
            </table>
            </asp:View> 
            </asp:MultiView>

            <asp:MultiView ID="MultiViewForm22SMTombol" runat="server" Visible="TRUE">
            <asp:View ID="View7" runat="server">   
            <div><center><h2 style="font-family:Cooper Black;">Penilaian Service Manager</h2></center></div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label45" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Catatan 
                Service Manager</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtHeadSMNote" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="90%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label47" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nama/Tanggal Note</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:Label ID="lblHeadSMUser" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:Label ID="Label49" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">.../...</asp:Label>
                <asp:Label ID="lblHeadSMTgl" runat="server" Font-Names="Arial" 
                    Font-Size="Small" height= "21px">...</asp:Label>            
                <asp:Label ID="Label51" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:CheckBox ID="CheckBoxHeadSM" runat="server" Text ="Menyetujui hasil Auditor dan Penambahan dan pengurangan Parts Stok" />
                </td>
            </tr>
            </table>   
            <br />         
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 50%; ">
               <asp:Button ID="BtnHeadSMSave" runat="server" Text="Simpan Catatan Service Mgr" Width="73%" Height="31px" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 50%; ">
               <asp:Button ID="BtnHeadSMBack" runat="server" Text="Kembali Ke Tabel Utama" 
                    Width="73%" Height="31px" BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            </tr>
            </table>
            </asp:View> 
            <asp:View ID="View10" runat="server">            
                <asp:Label ID="LblBlockApprovedSM" runat="server" Font-Names="Arial" 
                    Font-Size="Medium" height= "21px" BackColor="White" Font-Bold="True" 
                    ForeColor="Red">Belum Semua Hasil Audir disetujui oleh Head Parts</asp:Label>
            </asp:View> 
            
            
            </asp:MultiView>

            <asp:MultiView ID="MultiViewForm22ACCFINTombol" runat="server" Visible="TRUE">
            <asp:View ID="View9" runat="server">            
            <div><center><h2 style="font-family:Cooper Black;">Penilaian Accounting dan Finance</h2></center></div>  
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 22%; ">
                <asp:Label ID="Label52" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Catatan Account/Finance</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="TxtHeadAcctNote" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="90%" MaxLength="200" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 22%; background-color:#CCCCFF ; ">
                <asp:Label ID="Label54" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">Nama/Tanggal Note</asp:Label>
            </td>
            <td style="width: 75%; background-color:#CCCCFF ; ">
                <asp:Label ID="lblHeadAccUser" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:Label ID="Label56" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">.../...</asp:Label>
                <asp:Label ID="lblHeadAccTgl" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>            
                <asp:Label ID="Label62" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px">...</asp:Label>
                <asp:CheckBox ID="CheckBoxHeadAcct" runat="server" Text ="Menyetujui hasil Auditor dan Penambahan dan pengurangan Parts Stok" />
                </td>
            </tr>
            </table>   
            
            
            
            
            <br />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr>
            <td style="width: 50%; ">
               <asp:Button ID="BtnHeadAccSave" runat="server" Text="Simpan Catatan Account" Width="73%" Height="31px" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            <td style="width: 50%; ">
               <asp:Button ID="BtnHeadAccBack" runat="server" Text="Kembali Ke Tabel Utama" 
                    Width="73%" Height="31px" BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            </tr>
            </table>
            </asp:View> 
           <asp:View ID="View11" runat="server">            
                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Medium" 
                    height= "21px" Font-Bold="True" ForeColor="Red">Belum Semua Hasil Audir disetujui oleh SM</asp:Label>
            </asp:View> 

            </asp:MultiView>



            <asp:MultiView ID="MultiViewTabelStokPart112" runat="server" Visible="TRUE">
            <asp:View ID="View19" runat="server">            



            <asp:SqlDataSource ID="sdsTabelStock112" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnetSvcs112 %>" 
            SelectCommand="SELECT [PARTS_NO], [PARTS_NAMA], [PARTS_STOCK],(ISNULL([PARTS_STOCK],0)-ISNULL([PARTS_QYPESAN],0)) as QtySTok, [PARTS_QYPESAN], [PARTS_LOKASI], [PARTS_QTYAUDIT], [PARTS_TGLAUDIT] FROM [DATA_PARTS] WHERE ([PARTS_LOKASI] LIKE '%' + ? + '%')  AND ([PARTS_NO] LIKE '%' + ? + '%') AND ([PARTS_NAMA] LIKE '%' + ? + '%') AND PARTS_STOCK >= ?  ORDER BY PARTS_LOKASI,PARTS_NO"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnetSvcs112.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtPartsLantai"           Name="DATA_PARTS.PARTS_LOKASI" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsNO"               Name="DATA_PARTS.PARTS_NO" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsNama"             Name="DATA_PARTS.PARTS_NAMA" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsStok"             Name="DATA_PARTS.PARTS_STOCK" 
                    PropertyName="Text" Type="Int64"  DefaultValue="-10" />            
            </SelectParameters>
            </asp:SqlDataSource>                     
            <asp:ListView ID="lvStockPart" runat="server" DataSourceID="sdsTabelStock112" DataKeyNames ="PARTS_NO">
            <LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
            <thead  style="background-color:Silver">
            <th>Part No</th><th>Nama</th><th>Lokasi</th><th>Stok</th><th>Pickup</th><th>Stock</th><th>Audit</th><th>Qty</th>
            </thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="1500" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate>
            <ItemTemplate><tr>
            <td style="width:15%; height:30px;  font-size: small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("PARTS_NO") %>' CommandName="Select" runat="server" /></td>
            <td style="width:29%; font-size:small"><%#Eval("PARTS_NAMA")%></td>
            <td style="width:10%; font-size:small"><%#Eval("PARTS_LOKASI")%></td>
            <td style="width:9%; font-size:small"><%#Eval("PARTS_STOCK")%></td>
            <td style="width:9%; font-size:small"><%#Eval("PARTS_QYPESAN")%></td>
            <td style="width:9%; font-size:small"><%#Eval("QtySTok")%></td>
            <td style="width:10%; font-size:small"><%#Eval("PARTS_TGLAUDIT")%></td>
            <td style="width:9%; font-size:small"><%#Eval("PARTS_QTYAUDIT")%></td>
            </tr></ItemTemplate>
            </asp:ListView>


            </asp:View> 
            </asp:MultiView>
            <asp:MultiView ID="MultiViewTabelStokPart128" runat="server" Visible="TRUE">
            <asp:View ID="View20" runat="server">            
            <asp:SqlDataSource ID="sdsTabelStock128" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnetSvcs128 %>" 
            SelectCommand="SELECT [PARTS_NO], [PARTS_NAMA], [PARTS_STOCK],(ISNULL([PARTS_STOCK],0)-ISNULL([PARTS_QYPESAN],0)) as QtySTok, [PARTS_QYPESAN], [PARTS_LOKASI], [PARTS_QTYAUDIT], [PARTS_TGLAUDIT] FROM [DATA_PARTS] WHERE ([PARTS_LOKASI] LIKE '%' + ? + '%')  AND ([PARTS_NO] LIKE '%' + ? + '%') AND ([PARTS_NAMA] LIKE '%' + ? + '%') AND PARTS_STOCK >= ?  ORDER BY PARTS_LOKASI,PARTS_NO"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnetSvcs112.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtPartsLantai"           Name="DATA_PARTS.PARTS_LOKASI" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsNO"               Name="DATA_PARTS.PARTS_NO" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsNama"             Name="DATA_PARTS.PARTS_NAMA" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
                <asp:ControlParameter ControlID="TxtPartsStok"             Name="DATA_PARTS.PARTS_STOCK" 
                    PropertyName="Text" Type="Int64"  DefaultValue="-10" />            
            </SelectParameters>
            </asp:SqlDataSource>                     
            <asp:ListView ID="lvStockPart128" runat="server" DataSourceID="sdsTabelStock128" DataKeyNames ="PARTS_NO">
            <LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;"><thead  style="background-color:Silver"><th>Part No</th><th>Nama</th><th>Lokasi</th><th>Stok</th><th>Pickup</th><th>Stock</th><th>Audit</th><th>Qty</th></thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table><asp:DataPager ID="dpBerita" PageSize="1500" runat="server"><Fields><asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                    ShowNextPageButton="false" ShowLastPageButton="false" /><asp:NumericPagerField /><asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                    ShowNextPageButton="true" ShowLastPageButton="true" /></Fields></asp:DataPager></LayoutTemplate>
            <ItemTemplate><tr>
            <td style="width:15%; height:30px;  font-size: small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("PARTS_NO") %>' CommandName="Select" runat="server" /></td>
            <td style="width:29%; font-size:small"><%#Eval("PARTS_NAMA")%></td>
            <td style="width:10%; font-size:small"><%#Eval("PARTS_LOKASI")%></td>
            <td style="width:9%; font-size:small"><%#Eval("PARTS_STOCK")%></td>
            <td style="width:9%; font-size:small"><%#Eval("PARTS_QYPESAN")%></td>
            <td style="width:9%; font-size:small"><%#Eval("QtySTok")%></td>
            <td style="width:10%; font-size:small"><%#Eval("PARTS_TGLAUDIT")%></td>
            <td style="width:9%; font-size:small"><%#Eval("PARTS_QTYAUDIT")%></td>
            </tr></ItemTemplate>
            </asp:ListView>

            </asp:View> 
            </asp:MultiView>

            <asp:MultiView ID="MultiViewTabelAudit112" runat="server" Visible="TRUE">
            <asp:View ID="View22" runat="server">   
            
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
            <td style="width: 100%; ">
               <asp:Button ID="ButtonExprotMutas112" runat="server" Text="Export ke dalam format Excel" Height="31px" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            </tr>
            </table>

            
            <asp:SqlDataSource ID="SqlDataAdudit112" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnetSvcs112 %>" 
            SelectCommand="SELECT DATA_PARTS.PARTS_NO, DATA_PARTS.PARTS_NAMA, ISNULL(TEMP_AUDITPART.AUDITPART_STOK, 0) - ISNULL(TEMP_AUDITPART.AUDITPART_PICKUP, 0) AS QtySTok, DATA_PARTS.PARTS_STOCK, DATA_PARTS.PARTS_QYPESAN, DATA_PARTS.PARTS_LOKASI, DATA_PARTS.PARTS_QTYAUDIT, DATA_PARTS.PARTS_TGLAUDIT, TEMP_AUDITPART.AUDITPART_NO, TEMP_AUDITPART.AUDITPART_TGL, TEMP_AUDITPART.AUDITPART_USER, TEMP_AUDITPART.AUDITPART_STOK, TEMP_AUDITPART.AUDITPART_PICKUP, TEMP_AUDITPART.AUDITPART_QTY, TEMP_AUDITPART.AUDITPART_CATATAN, TEMP_AUDITPART.AUDITPART_NOTE1, TEMP_AUDITPART.AUDITPART_NOTE2, TEMP_AUDITPART.AUDITPART_NOTE1TGL, TEMP_AUDITPART.AUDITPART_NOTE1USR, TEMP_AUDITPART.AUDITPART_NOTE2TGL, TEMP_AUDITPART.AUDITPART_NOTE2USR, TEMP_AUDITPART.AUDITPART_NOTE2ADJ, TEMP_AUDITPART.AUDITPART_NOTE3, TEMP_AUDITPART.AUDITPART_NOTE4, DATA_PARTS.PARTS_HGBELIAKHIR,ISNULL(TEMP_AUDITPART.AUDITPART_NOTE2ADJ, 0) * ISNULL(DATA_PARTS.PARTS_HGBELIAKHIR, 0) AS TotMutasi FROM DATA_PARTS RIGHT OUTER JOIN TEMP_AUDITPART ON DATA_PARTS.PARTS_NO = TEMP_AUDITPART.AUDITPART_NO WHERE (DATA_PARTS.PARTS_NO LIKE '%' + ? + '%') AND (ISNULL(TEMP_AUDITPART.AUDITPART_STOK, 0) - ISNULL(TEMP_AUDITPART.AUDITPART_PICKUP, 0) - ISNULL(TEMP_AUDITPART.AUDITPART_QTY, 0) &lt;&gt; 0) ORDER BY DATA_PARTS.PARTS_NO"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnetSvcs112.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="LblPartsNo"           Name="DATA_PARTS.PARTS_NO" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
            </SelectParameters>
            </asp:SqlDataSource>                     
            <asp:ListView ID="LVDataAdudit" runat="server" DataSourceID="SqlDataAdudit112" DataKeyNames ="PARTS_NO"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
            <thead  style="background-color:Silver">
            <th>Part No</th><th>Nama</th><th>Tgl Audit</th><th>User</th><th>Stok</th><th>Pickup</th><th>Actual</th><th>Audit</th><th>Mutasi +/-</th><th>Harga</th><th>Total Mutasi</th><th>User</th><th>Catatan</th>
            </thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table>
            </LayoutTemplate>
            <ItemTemplate>
            
                    <tr>
                    <td rowspan="5" style="width:11%; height:30px;  font-size: small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("PARTS_NO") %>' CommandName="Select" runat="server" /></td>
                    <td rowspan="5" style="width:14%; font-size:small"><%#Eval("PARTS_NAMA")%></td>
                    <td rowspan="5" style="width:6%; font-size:small"><%#Eval("AUDITPART_TGL")%></td>
                    <td rowspan="5" style="width:5%; font-size:small"><%#Eval("AUDITPART_USER")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("AUDITPART_STOK")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("AUDITPART_PICKUP")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("QtySTok")%></td>
                    <td rowspan="5" style="width:4%; font-size:small; background-color : #FFFF80"><%#Eval("AUDITPART_QTY")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("AUDITPART_NOTE2ADJ")%></td>
                    <td rowspan="5" style="width:6%; font-size:small"><%#Eval("PARTS_HGBELIAKHIR")%></td>
                    <td rowspan="5" style="width:6%; font-size:small"><%#Eval("TotMutasi")%></td>
                    <td style="width:9%; font-size:small">Pencatat</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_CATATAN")%></td>
                    </tr>

                    <tr>
                    <td style="width:9%; font-size:small">Auditor</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE2")%></td>
                    </tr>                    <tr>
                    <td style="width:9%; font-size:small">Head Part</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE1")%></td>
                    </tr>
                    <tr>
                    <td style="width:9%; font-size:small">SM</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE3")%></td>
                    </tr>

                    <tr>
                    <td style="width:9%; font-size:small">Account</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE4")%></td>
                    </tr>
                    
                    </ItemTemplate></asp:ListView>

            <asp:ListView ID="LVDataAduditExport" runat="server" DataSourceID="SqlDataAdudit112" DataKeyNames ="PARTS_NO"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
            <thead  style="background-color:Silver">
            <th>Part No</th><th>Nama</th><th>Tgl Audit</th><th>User</th><th>Stok</th><th>Pickup</th><th>Actual</th><th>Audit</th><th>Mutasi +/-</th><th>Harga</th><th>Total Mutasi</th><th>User</th><th>Catatan</th>
            </thead><asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table>
            </LayoutTemplate>
            <ItemTemplate>
            
                    <tr>
                    <td rowspan="5" style="width:14%; font-size:small"><%#Eval("PARTS_NO")%></td>
                    <td rowspan="5" style="width:14%; font-size:small"><%#Eval("PARTS_NAMA")%></td>
                    <td rowspan="5" style="width:6%; font-size:small"><%#Eval("AUDITPART_TGL")%></td>
                    <td rowspan="5" style="width:5%; font-size:small"><%#Eval("AUDITPART_USER")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("AUDITPART_STOK")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("AUDITPART_PICKUP")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("QtySTok")%></td>
                    <td rowspan="5" style="width:4%; font-size:small; background-color : #FFFF80"><%#Eval("AUDITPART_QTY")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("AUDITPART_NOTE2ADJ")%></td>
                    <td rowspan="5" style="width:6%; font-size:small"><%#Eval("PARTS_HGBELIAKHIR")%></td>
                    <td rowspan="5" style="width:6%; font-size:small"><%#Eval("TotMutasi")%></td>
                    <td style="width:9%; font-size:small">Pencatat</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_CATATAN")%></td>
                    </tr>

                    <tr>
                    <td style="width:9%; font-size:small">Auditor</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE2")%></td>
                    </tr>                    <tr>
                    <td style="width:9%; font-size:small">Head Part</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE1")%></td>
                    </tr>
                    <tr>
                    <td style="width:9%; font-size:small">SM</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE3")%></td>
                    </tr>

                    <tr>
                    <td style="width:9%; font-size:small">Account</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE4")%></td>
                    </tr>
                    
                    </ItemTemplate></asp:ListView>
         
            </asp:View> 
            </asp:MultiView>
            
            
            <asp:MultiView ID="MultiViewTabelAudit128" runat="server" Visible="TRUE">
            <asp:View ID="View23" runat="server">            

            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;
                   border-top-color :red; border-top-style:solid  ; border-top-width:thin;
                   border-bottom-color :red; border-bottom-style:solid  ; border-bottom-width:thin;
                   border-left-color :red; border-left-style:solid  ; border-left-width:thin;
                   border-right-color :red; border-right-style:solid  ; border-right-width:thin">
            <tr> 
            <td style="width: 100%; ">
               <asp:Button ID="ButtonExprotMutas128" runat="server" Text="Export ke dalam format Excel" Height="31px" 
                    BackColor="Yellow" Font-Bold="True" ForeColor="Black"  />
            </td>
            </tr>
            </table>


            <asp:SqlDataSource ID="SqlDataAdudit128" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnetSvcs128 %>" 
            SelectCommand="SELECT DATA_PARTS.PARTS_NO, DATA_PARTS.PARTS_NAMA, ISNULL(TEMP_AUDITPART.AUDITPART_STOK, 0) - ISNULL(TEMP_AUDITPART.AUDITPART_PICKUP, 0) AS QtySTok, DATA_PARTS.PARTS_STOCK, DATA_PARTS.PARTS_QYPESAN, DATA_PARTS.PARTS_LOKASI, DATA_PARTS.PARTS_QTYAUDIT, DATA_PARTS.PARTS_TGLAUDIT, TEMP_AUDITPART.AUDITPART_NO, TEMP_AUDITPART.AUDITPART_TGL, TEMP_AUDITPART.AUDITPART_USER, TEMP_AUDITPART.AUDITPART_STOK, TEMP_AUDITPART.AUDITPART_PICKUP, TEMP_AUDITPART.AUDITPART_QTY, TEMP_AUDITPART.AUDITPART_CATATAN, TEMP_AUDITPART.AUDITPART_NOTE1, TEMP_AUDITPART.AUDITPART_NOTE2, TEMP_AUDITPART.AUDITPART_NOTE1TGL, TEMP_AUDITPART.AUDITPART_NOTE1USR, TEMP_AUDITPART.AUDITPART_NOTE2TGL, TEMP_AUDITPART.AUDITPART_NOTE2USR, TEMP_AUDITPART.AUDITPART_NOTE2ADJ, TEMP_AUDITPART.AUDITPART_NOTE3, TEMP_AUDITPART.AUDITPART_NOTE4, DATA_PARTS.PARTS_HGBELIAKHIR,ISNULL(TEMP_AUDITPART.AUDITPART_NOTE2ADJ, 0) * ISNULL(DATA_PARTS.PARTS_HGBELIAKHIR, 0) AS TotMutasi FROM DATA_PARTS RIGHT OUTER JOIN TEMP_AUDITPART ON DATA_PARTS.PARTS_NO = TEMP_AUDITPART.AUDITPART_NO WHERE (DATA_PARTS.PARTS_NO LIKE '%' + ? + '%') AND (ISNULL(TEMP_AUDITPART.AUDITPART_STOK, 0) - ISNULL(TEMP_AUDITPART.AUDITPART_PICKUP, 0) - ISNULL(TEMP_AUDITPART.AUDITPART_QTY, 0) &lt;&gt; 0) ORDER BY DATA_PARTS.PARTS_NO"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnetSvcs128.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="LblPartsNo"           Name="DATA_PARTS.PARTS_NO" 
                    PropertyName="Text" Type="String" DefaultValue="%" />            
            </SelectParameters>
            </asp:SqlDataSource>                     
            <asp:ListView ID="LVDataAdudit128" runat="server" DataSourceID="SqlDataAdudit128" DataKeyNames ="PARTS_NO"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
            <thead  style="background-color:Silver">
            <th>Part No</th><th>Nama</th><th>Tgl Audit</th><th>User</th><th>Stok</th><th>Pickup</th><th>Actual</th><th>Audit</th><th>Mutasi +/-</th><th>Harga</th><th>Total Mutasi</th><th>User</th><th>Catatan</th>
            </thead>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table>
            </LayoutTemplate>
            <ItemTemplate>
                    <tr>
                    <td rowspan="5" style="width:11%; height:30px;  font-size: small"><asp:LinkButton ID="lnkSelect" Text='<%# Eval("PARTS_NO") %>' CommandName="Select" runat="server" /></td>
                    <td rowspan="5" style="width:14%; font-size:small"><%#Eval("PARTS_NAMA")%></td>
                    <td rowspan="5" style="width:6%; font-size:small"><%#Eval("AUDITPART_TGL")%></td>
                    <td rowspan="5" style="width:5%; font-size:small"><%#Eval("AUDITPART_USER")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("AUDITPART_STOK")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("AUDITPART_PICKUP")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("QtySTok")%></td>
                    <td rowspan="5" style="width:4%; font-size:small; background-color : #FFFF80"><%#Eval("AUDITPART_QTY")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("AUDITPART_NOTE2ADJ")%></td>
                    <td rowspan="5" style="width:6%; font-size:small"><%#Eval("PARTS_HGBELIAKHIR")%></td>
                    <td rowspan="5" style="width:6%; font-size:small"><%#Eval("TotMutasi")%></td>
                    <td style="width:9%; font-size:small">Pencatat</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_CATATAN")%></td>
                    </tr>
                    
                    <tr>
                    <td style="width:9%; font-size:small">Auditor</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE2")%></td>
                    </tr>                    <tr>
                    <td style="width:9%; font-size:small">Head Part</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE1")%></td>
                    </tr>
                    <tr>
                    <td style="width:9%; font-size:small">SM</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE3")%></td>
                    </tr>

                    <tr>
                    <td style="width:9%; font-size:small">Account</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE4")%></td>
                    </tr>
                    
                    </ItemTemplate></asp:ListView>

            <asp:ListView ID="LVDataAdudit128Export" runat="server" DataSourceID="SqlDataAdudit128" DataKeyNames ="PARTS_NO"><LayoutTemplate><table id="table-a"  border="2" width="100%"  style="border-collapse:collapse;">
            <thead  style="background-color:Silver">
            <th>Part No</th><th>Nama</th><th>Tgl Audit</th><th>User</th><th>Stok</th><th>Pickup</th><th>Actual</th><th>Audit</th><th>Mutasi +/-</th><th>Harga</th><th>Total Mutasi</th><th>User</th><th>Catatan</th>
            </thead>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" /></table>
            </LayoutTemplate>
            <ItemTemplate>
                    <tr>
                    <td rowspan="5" style="width:14%; font-size:small"><%#Eval("PARTS_NO")%></td>
                    <td rowspan="5" style="width:14%; font-size:small"><%#Eval("PARTS_NAMA")%></td>
                    <td rowspan="5" style="width:6%; font-size:small"><%#Eval("AUDITPART_TGL")%></td>
                    <td rowspan="5" style="width:5%; font-size:small"><%#Eval("AUDITPART_USER")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("AUDITPART_STOK")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("AUDITPART_PICKUP")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("QtySTok")%></td>
                    <td rowspan="5" style="width:4%; font-size:small; background-color : #FFFF80"><%#Eval("AUDITPART_QTY")%></td>
                    <td rowspan="5" style="width:4%; font-size:small"><%#Eval("AUDITPART_NOTE2ADJ")%></td>
                    <td rowspan="5" style="width:6%; font-size:small"><%#Eval("PARTS_HGBELIAKHIR")%></td>
                    <td rowspan="5" style="width:6%; font-size:small"><%#Eval("TotMutasi")%></td>
                    <td style="width:9%; font-size:small">Pencatat</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_CATATAN")%></td>
                    </tr>
                    
                    <tr>
                    <td style="width:9%; font-size:small">Auditor</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE2")%></td>
                    </tr>                    <tr>
                    <td style="width:9%; font-size:small">Head Part</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE1")%></td>
                    </tr>
                    <tr>
                    <td style="width:9%; font-size:small">SM</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE3")%></td>
                    </tr>

                    <tr>
                    <td style="width:9%; font-size:small">Account</td>
                    <td style="width:23%; font-size:small"><%#Eval("AUDITPART_NOTE4")%></td>
                    </tr>
                    
                    </ItemTemplate></asp:ListView>
                    
            </asp:View> 
            </asp:MultiView>         
        </asp:View>         
    </asp:MultiView>
    


</asp:Content>
