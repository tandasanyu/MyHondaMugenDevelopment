<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageUser_HomePelamar.aspx.cs" Inherits="PageUser_PageUser_HomePelamar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
.footer {
   position: fixed;
   left: 0;
   bottom: 0;
   width: 100%;
   background-color: grey;
   color: white;
   text-align: center;
   height:50px;
   max-height:50px;
}
h2.FormDataDiri {
  text-align: center;
}
</style>
    <!-- Bootstrap -->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom:100px">
            <div style="margin-left:1%">
                <h2 class="FormDataDiri">Selamat Datang di Menu Pelamar</h2>
                <br />
                <br />
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Selamat Datang : "></asp:Label><br />
                    <asp:Label ID="LblNamaPelamar" runat="server" Text="NAMAUSER" Font-Bold="true"></asp:Label>
                    <br /><br />
                    <asp:Label ID="Label5" runat="server" Text="Posisi diLamar : "></asp:Label><br />
                    <asp:Label ID="LblPosisi" runat="server" Text="Posisi" Font-Bold="true"></asp:Label>
                    <br /><br />
                    <asp:Label ID="Label7" runat="server" Text="Nomor Lamaran : "></asp:Label><br />
                    <b>DFT</b><asp:Label ID="LblIdLamaran" runat="server" Text="NOMOR" Font-Bold="true"></asp:Label>
                </div>
                <div class="form-group" style="padding-right:20px">
                <table class="table table-bordered" >
                  <thead>
                    <tr>
                      <th scope="col">No</th>
                      <th scope="col">Dokumen</th>
                      <th scope="col">Keterangan</th>
                      <th scope="col">Aksi</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <th scope="row">1</th>
                      <td style="width: 300px">Data Diri</td>
                      <td>Wajib Di Isi</td>
                      <td><asp:Button ID="Button1" runat="server" Text="Isi Data" class="btn btn-info" OnClick="Button1_Click"/></td>
                    </tr>
                    <tr>
                      <th scope="row">2</th>
                      <td>Jacob</td>
                      <td>Thornton</td>
                      <td>@fat</td>
                    </tr>
                    <tr>
                      <th scope="row">3</th>
                      <%--<td colspan="2">Larry the Bird</td>--%>
                        <td>
                            @twitter</td>
                        <td>@twitter</td>
                      <td style="width: 150px">@twitter</td>
                    </tr>
                  </tbody>
                </table>                    
                </div>
                <div class="form-group">
                    <asp:Button ID="BtnLogout" runat="server" Text="Logout"  class="btn btn-danger" OnClick="BtnLogout_Click"/>
                </div>
            </div>   
        </div>
        <div class="footer">
            <div style="margin-top:1px">
                <asp:Label ID="Label1" runat="server" Text="Developed by IT Departement 2019 &#169;"></asp:Label>            
            </div>
            <div style="margin-top:1px">
                 <asp:Label ID="Label2" runat="server" Text="PT.Mitra Usaha Gentaniaga"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
