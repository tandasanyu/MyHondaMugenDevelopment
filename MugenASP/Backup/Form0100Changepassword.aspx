<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0100Changepassword.aspx.vb" Inherits="Form0100Changepassword" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
       <p   style ="font-size:smaller" >
        <asp:Label ID="Label44"  Text ="Permohonan Persetujuan >> " runat="server"></asp:Label>
        &nbsp; Nama User&nbsp; : 
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:Label ID="lblAkses" runat="server"></asp:Label>
        &nbsp; Akses &nbsp; : 
        <asp:Label ID="lblArea1" runat="server"></asp:Label>
        <asp:Label ID="lblArea2" runat="server"></asp:Label>
       </p>

    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
          
        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Judul 
        Permohonan</asp:Label>
          
    </asp:View> 
    </asp:MultiView>

        
        <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
        <tr>
            <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                   <asp:Label ID="Label26" runat="server" Font-Names="Arial" Font-Size="Small" 
                    height= "21px">User name</asp:Label>
            </td>
            <td style="width: 75%; ">
            <asp:Label ID="lblusername" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label32" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Kata kunci Lama</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="Txtkuncilama" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true" Text =""   ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 25%; background-color: #000000;  color: #FFFFFF;">
                <asp:Label ID="Label29" runat="server" Font-Names="Arial" Font-Size="Small" 
                height= "21px">Kata kunci baru</asp:Label>
            </td>
            <td style="width: 75%; ">
                <asp:TextBox ID="Txtkuncibaru" runat="server" Font-Names="Arial" Font-Size="Small" 
                Width="100%" MaxLength="50" TabIndex ="7"  AutoPostBack="true"   ></asp:TextBox>
            </td>
        </tr>
      </table>    
       <br />
        <br />
        <table style="width: 100%; height:59px; font-family: Arial; font-size: small;">
            <tr>
            <td style="width: 25%;  color: #FFFFFF;">
                <asp:Button ID="BtnSetuju" runat="server" Text="Ubah" Width="321px" 
                    Height="35px" Font-Overline="False" Font-Size="X-Large" />    
            </td>
            <td style="width: 25%;  color: #FFFFFF;">
                &nbsp;</td>
            <td style="width: 25%;  color: #FFFFFF;">
                <asp:Button ID="BtnKembali" runat="server" Text="Kembali" Width="322px" 
                    Font-Size="X-Large" Height="35px" />    
            </td>
            </tr>
            </table>

        

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

