<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="editpassword.aspx.vb" Inherits="editpassword" title="Form Edit Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
        <asp:Label ID="Label1" runat="server" style="display:none;"></asp:Label>
        <asp:Label ID="lblAkses" runat="server" style="display:none;"></asp:Label>
        <asp:Label ID="lblArea1" runat="server" style="display:none;"></asp:Label>
        <asp:Label ID="lblArea2" runat="server" style="display:none;"></asp:Label>


    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
          
        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Judul 
        Permohonan</asp:Label>
          
    </asp:View> 
    </asp:MultiView>

        <div class="container">
      
            <br /><br /><br />
           <table class="table table-striped" style="border-radius:8px;padding:4px;width:500px;margin:10px auto;font-size:10pt;font-family:Verdana;">
                <tr>
                    <th colspan="3" style="text-align:center;"><span class="glyphicon glyphicon-lock"></span>&nbsp;&nbsp;UBAH PASSWORD</th>
                </tr>
                <tr>
                    <td>Username</td>
                    <td>:</td>
                    <td><asp:Label ID="lblUsername" runat="server" style="color:blue;font-weight:bold;" Text="U must be log in !"></asp:Label> <span style="font-size:8pt;color:#666;"><br /> <i class="glyphicon glyphicon-info-sign"></i> Username tidak dapat diganti</span></td>
                </tr>
                <tr>
                    <td>Password lama</td>
                    <td>:</td>
                    <td><asp:TextBox ID="txtPassLama" runat="server" class="form-control input-sm" placeholder="Password lama" TextMode="Password"></asp:TextBox><asp:Label ID="lblPassLama" style="color:red;font-size:8pt;" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Password baru</td>
                    <td>:</td>
                    <td><asp:TextBox ID="txtPassBaru" runat="server" Style="color:#333;" class="form-control input-sm" placeholder="Password baru" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Ulangi password</td>
                    <td>:</td>
                    <td><asp:TextBox ID="txtPassBaru2" runat="server" Style="color:#333;" class="form-control input-sm" placeholder="Ulang password baru" TextMode="Password"></asp:TextBox><asp:Label ID="lblPassBaru2" style="color:red;font-size:8pt;" runat="server" Text=""></asp:Label></td>
                </tr>
                 <tr>
                    <td></td>
                    <td></td>
                    <td><asp:Label ID="lblSukses" style="color:green;font-size:8pt;" runat="server" Text=""></asp:Label><br />
                    <asp:Button ID="simpan" CssClass="btn btn-primary btn-sm" runat="server" Text="Ubah Password" OnClick="simpan_Click" /></td>
                </tr>
            </table>
        <br /><br /><br />
    </div>
    <!-- /.container -->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

