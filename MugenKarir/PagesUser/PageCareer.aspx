<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageCareer.aspx.cs" Inherits="PagesUser_PageCareer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bergabunglah Bersama Honda Mugen</title>
<style>
.footer {
   position: fixed;
   left: 0;
   bottom: 0;
   width: 100%;
   background-color: dimgrey;
   color: white;
   text-align: center;
}
#content{
    margin-left:10px;
}
#content2 {


}
</style>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/jquery-3.3.1.min.js"></script>
    <script src="../js/jquery-3.3.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
            

        <div class="row">
        <div id ="content" class="col-sm-6" >
            <h1><asp:Label ID="Label1" runat="server" Text="Bergabunglah Bersama Kami"></asp:Label></h1>
            <br />
            <p>Honda Mugen adalah perwakilan dealer resmi mobil Honda dengan skala 3S (Sales, Service, Spare Part) yang bernaung di bawah PT. Mitrausaha Gentaniaga. Honda Mugen berlokasi di Pasar Minggu, Jakarta Selatan dan telah melayani dan memenuhi kebutuhan pelanggan sejak tahun 1991. Seiring dengan pesatnya perkembangan perusahaan, pada tahun 2008 dibuka cabang baru di Puri Kembangan, Jakarta Barat. Dan saat ini, kami membuka kesempatan bagi anda untuk bergabung menjadi bagian dari perjalanan kami menjadi dealer resmi Honda nomor 1 di Indonesia. </p>
        </div>
        <div id="content2" class="col-sm-4">
            <div class="row">
            <div class="col-sm-6">
                <h2>Unduh Brosur</h2>
                <br />
                <asp:Menu ID="Menu1" runat="server">
                    <Items>
                        <asp:MenuItem Text="Honda Accord" Value="New Item"></asp:MenuItem>
                        <asp:MenuItem Text="Honda Brio" Value="New Item"></asp:MenuItem>
                        <asp:MenuItem Text="Honda BRV" Value="New Item"></asp:MenuItem>
                        <asp:MenuItem Text="Honda City" Value="New Item"></asp:MenuItem>
                        <asp:MenuItem Text="Honda Civic" Value="New Item"></asp:MenuItem>
                        <asp:MenuItem Text="Honda CRV" Value="New Item"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </div>
            <div class="col-sm-6" style="margin-top:80px">
                <asp:Menu ID="Menu2" runat="server">
                    <Items>
                        <asp:MenuItem Text="Honda CRZ" Value="New Item"></asp:MenuItem>
                        <asp:MenuItem Text="Honda HRV" Value="New Item"></asp:MenuItem>
                        <asp:MenuItem Text="Honda Jazz" Value="New Item"></asp:MenuItem>
                        <asp:MenuItem Text="Honda Mobilio" Value="New Item"></asp:MenuItem>
                        <asp:MenuItem Text="Honda Odyssey" Value="New Item"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </div>
            </div>
        </div>
         </div>
        <div class="footer">
          <p>Develop By IT Honda Mugen &#169;</p>
        </div>
    </form>
</body>
</html>
