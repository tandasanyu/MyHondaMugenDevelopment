<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageUser_ListLowongan2.aspx.cs" Inherits="PageUser_PageUser_ListLowongan2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Berkarir Bersama Hoda Mugen</title>
    <!-- Bootstrap -->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />

    <script src="../js/jquery-1.12.4.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#show_hide').click(function () {
                $(this).next('.slidingDiv').slideToggle();
                return false;
            });
        });
    </script>
  <style>
.slidingDiv {
     display: none;   
}
blockquote {
    max-width:390px;
    text-align: center; 
    border-left: 3px solid #897860; 
    padding-left: 5px;
    margin:0 auto;
    width:auto;
    display:table
}
  body {
      position: relative; 
  }
  .masthead {
  height: 100vh;
  min-height: 500px;
  background-image: url('https://images.pexels.com/photos/872955/pexels-photo-872955.jpeg?auto=compress&cs=tinysrgb&h=650&w=940');
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
    opacity: 0.5;
  filter: alpha(opacity=50);
}
  table {
    border-collapse: separate;
    border-spacing: 0;
}
table, td {
    border: 1px thin grey;
    border-radius: 5px;
    -moz-border-radius: 5px;
    padding: 5px;
}
/**/


.masthead:hover {
  opacity: 1.0;
  filter: alpha(opacity=100); /* For IE8 and earlier */
}
  </style>
</head>

<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-sm  navbar-dark fixed-top" >  <!-- bg-secondary tanpa ini menjadi trasnparan -->
          <ul class="navbar-nav">
            <li class="nav-item">
              <a class="nav-link" href="#mh" >
                  <img src="../img/logo2.png" width="140px" height="40px"/></a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#section2" style="color:red;font-weight:bold">Awali Karir Anda di Sini!</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#section3" style="color:red;font-weight:bold">Peluang Karir</a>
            </li> <!-- section42 -->
            <li class="nav-item">
              <a class="nav-link" href="#section42" style="color:red;font-weight:bold">Hubungi Kami</a>
            </li> 
          </ul>
        </nav>
        <header class="masthead" id="mh">
          <div class="container h-100">
            <div class="row h-100 align-items-center">
              <div class="col-12 text-center">
                <h1 class="font-weight-light" style="color:white">Berkarirlah Bersama Kami!</h1>
                <p class="lead" style="color:white">PT. Mitra Usaha Gentaniaga</p>
              </div>
            </div>
          </div>
        </header>
        <div id="section2" class="container-fluid bg-light" style="padding-top:70px;padding-bottom:70px;">
          <h1>Awali Karir Anda Bersama Kami !</h1>
          <div style="text-align:justify; text-justify:inter-word">Honda Mugen adalah perwakilan dealer resmi mobil Honda dengan 
                skala 3S (Sales, Service, Spare Part) yang bernaung di bawah PT. Mitrausaha Gentaniaga. 
                Honda Mugen berlokasi di Pasar Minggu, Jakarta Selatan dan telah melayani dan memenuhi 
                kebutuhan pelanggan sejak tahun 1991. Seiring dengan pesatnya perkembangan perusahaan, 
                pada tahun 2008 dibuka cabang baru di Puri Kembangan, Jakarta Barat. Dan saat ini, kami 
                membuka kesempatan bagi anda untuk bergabung menjadi bagian dari perjalanan kami menjadi 
                dealer resmi Honda nomor 1 di Indonesia.<br /><br /><br /><br />
            <blockquote class="blockquote" >
              <p class="mb-0">“A company is most clearly defined not by its people or its history, but by it’s products.” </p>
              <footer class="blockquote-footer">Soichiro Honda<cite title="Source Title"></cite></footer>
            </blockquote>
          </div>
        </div>
        <div id="section21" class="container-fluid bg-light" style="padding-top:70px;padding-bottom:70px;">
            <button type="button" id="show_hide" class="btn">Unduh Brosur</button>
            
            <div class="slidingDiv container-fluid bg-light" style="margin-top:10px">
              <ul class="list-group" style="width:300px">
                <li class="list-group-item">Accord</li>
                <li class="list-group-item">Brio</li>
                <li class="list-group-item">City</li>
              </ul>
            </div>
        </div>
        <div id="section3" class="container-fluid bg-light" style="padding-top:70px;padding-bottom:70px">
          <h1>Peluang Karir</h1>
                <asp:SqlDataSource ID="SqlDataSourceViewListLowongan" 
                    runat="server"
                    ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
                    SelectCommand="select * from List_Lowongan where Status_Lowongan=1"
					ProviderName="<%$ ConnectionStrings:MugenKarirConnection.ProviderName %>"                   
                    ></asp:SqlDataSource>
<%--                    <br />
                    <input id="SearchLowongan"  type="text" placeholder="Ketik Lowongan yang akan di Cari!" class="form-control required" autocomplete="off" style="width:400px"/>
                    <br />  --%>

                    <asp:ListView ID="ListView1" runat="server" DataKeyNames ="Posisi" DataSourceID="SqlDataSourceViewListLowongan" ItemPlaceholderID="litPlaceHolder" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">
                    <LayoutTemplate>
                        <div class="table-responsive">
                            <table id="tb1" class="table table-borderless table-hover">
                                <thead >
                                    <tr class="table-secondary">
                                       <th scope="col">No</th>
                                       <th scope="col">Posisi</th>
                                        <th  scope="col">Detail</th>
                                        <th  scope="col">Tanggal Posting</th>
                                        <th style="text-align:center" scope="col">Aksi</th>
                                     </tr>
                                </thead>
                                <asp:Literal ID="litPlaceHolder" runat="server" />
                            </table>
                        </div>
                    </LayoutTemplate>  
                    <ItemTemplate>
                        <tr class="table-light">
                            <td style="width:10px"><%#Eval("id_lowongan")%>
                                
                            </td>
                            <td   style="width:100px"><%#Eval("Posisi")%></td>
                            <td  style="width:100px"><%#Eval("Kualifikasi")%></td>
                            <td style="width:100px"><%#Eval("Tgl_post", "{0:dd/MM/yyyy}")%></td>
                            <td  style="width:80px;text-align:center">                          
                             <asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="../img/ApplyNow-04.png" height="90px" width="90px"/></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>  
                                <EmptyDataTemplate>
                                    Data List Lowongan Tidak Di temukan
                                </EmptyDataTemplate>
                    </asp:ListView>

        </div>
        <div id="section41" class="container-fluid bg-light" style="padding-top:70px;padding-bottom:70px">
          <h1></h1>
          <p></p>
        </div>
        <div id="section42" class="container-fluid bg-secondary" style="padding-top:70px;padding-bottom:70px">
            <div class="row">
              <div class="col bg-secondary" >
                  <h5>Jam Operasional</h5>
                  <asp:Label ID="Label1" runat="server" Text="Showroom" Font-Bold="true"></asp:Label>                  
                  <br />
                  <p>Senin-Jumat: 08.30 s/d 19.00 WIB<br />
                  Sabtu: 08.30 s/d 15.00 WIB<br />
                  Minggu: 10.00 s/d 15.00 WIB</p>
                  <br />
                  <asp:Label ID="Label2" runat="server" Text="Service dan Suku Cadang" Font-Bold="true"></asp:Label>
                  <br />
                  <p>Senin-Jumat: 07.00 s/d 18.00 WIB<br />
                  Sabtu: 07.00 s/d 16.00 WIB<br />
                  Senin-Jumat 07.00 s/d 16.30 WIB (Puri)<br />
                  Sabtu 07.00 s/d 15.00 WIB (Puri)<br />
                  Minggu / Hari Libur Nasional: Tutup</p>
                  <br />
                  <h5><asp:Label ID="Label4" runat="server" Text="Body Repair" Font-Bold="true" Visible="false"></asp:Label></h5><br />
                  <asp:Label ID="Label3" runat="server" Text="Body Repair" Font-Bold="true"></asp:Label>
                  <br />
                  <p>Senin-Jumat: 08.30 s/d 16.30 WIB<br />
                  Sabtu: 08.30 s/d 15.00 WIB<br />
                  Minggu / Hari Libur Nasional: Tutup</p>
                  <br />  
              </div>
              <div class="col bg-secondary" >
                  <h5>Hubungi Kami</h5>
                  <asp:Label ID="Label5" runat="server" Text="Kantor Pusat" Font-Bold="true"></asp:Label>
                  <br />
                  <p>Jl. Raya Pasar Minggu No.10 <br />Jakarta Selatan 12740 - Indonesia Showroom (021) 797 3000<br /><br /> Bengkel 021 - 797 2000 <br />Fax (021) 797 3834 SMS 081585123000 <br />WHATSAPP 08119228112<br />
                  Sabtu: 08.30 s/d 15.00 WIB<br />
                  Minggu / Hari Libur Nasional: Tutup</p>
                  <br />   
              </div>
              <div class="col bg-secondary" >
                  <h5><asp:Label ID="Label6" runat="server" Text="Body Repair" Font-Bold="true" Visible="false"></asp:Label></h5><br />
                  <asp:Label ID="Label7" runat="server" Text="Kantor Cabang (Puri) " Font-Bold="true"></asp:Label>
                <p>
                    Jl. Lingkar Luar Barat, Puri Kembangan<br />
                    Jakarta Barat 11610 - Indonesia<br />
                    Showroom (021) 5835 8000<br />
                    Bengkel (021) 5835 9000<br />
                    Fax (021) 5835 7942 <br />
                    SMS 081519398000 <br />
                    WHATSAPP 08119515128 
                </p>
              </div>
              <div class="col bg-secondary" >
                  <h5><asp:Label ID="Label8" runat="server" Text="Sertifikasi " style="margin-left:20px"></asp:Label></h5>
                  <br />
                  <img src="../img/iso.png" height="100px" width="130px" />
              </div>
            </div>
            <div class="row">
              <div class="col bg-secondary" >
                  
              </div>
            </div>
        </div>
        <div id="section43LastFooter" class="container-fluid bg-dark" style="padding-top:70px;padding-bottom:70px">
            <p style="color:white;text-align:center">
                Copyright © 2019 PT. Mitrausaha Gentaniaga<br />
                All Right Reserved <br />
                Developed by IT Department
            </p>
        </div>
    </form>
</body>
</html>
