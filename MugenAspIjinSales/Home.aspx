<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Head Section -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--    <script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.js"></script> 
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap.min.js"></script>--%>
    <script type="text/javascript" src="js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable();

        });
    </script>
    <style>
        .centered {
          display: flex;
          width: 100vw;
          height: 30vh;
          justify-content: center;
          align-items: center;
        }

    </style>
    <div class="centered">
        <br />
            <h3 style="font-family:Blunter;"><span >Username Login : <asp:Label ID="LblUsername_Home" runat="server" Text="Username"></asp:Label> </span></h3>
        <br />
    </div>
    <div class="centered">
    <table >
        <tr>
            <td style="text-align:center">
                <asp:ImageButton ID="FormPengajuanIzin" runat="server" imageurl="img/absenform.png" height="150px" Width="150px" /> 
                <br />
                <span>
                    <asp:Label ID="LabelPengajuanIzin" runat="server" Text="Form Pengajuan Izin"></asp:Label></span>
            </td>
            <td><br /></td>
            <td style="text-align:center">
                <asp:ImageButton ID="ListPengajuanIzin" runat="server" imageurl="img/absenlist.png" height="150px" Width="150px" />
                <br />
                <span><asp:Label ID="Label1" runat="server" Text="List Izin"></asp:Label></span>
            </td>
            <td style="text-align:center">
                <asp:ImageButton ID="LihatListIzin" runat="server" imageurl="img/Search-Doc-Icon-1.png" height="150px" Width="150px" />
                <br />
                <span><asp:Label ID="Label2" runat="server" Text="Lihat Status Izin"></asp:Label></span>
            </td>
        </tr>
    </table>
    </div>
    <asp:Label ID="lblusername" runat="server" Text="Label" Visible="false"></asp:Label>
    <asp:Label ID="lblatasan" runat="server" Text="Label"  Visible="false"></asp:Label>
</asp:Content>

