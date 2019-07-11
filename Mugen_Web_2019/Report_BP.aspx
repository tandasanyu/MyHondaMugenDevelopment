﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_BP.aspx.cs" Inherits="Report_BP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="assets/js/bootstrap.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <%--<center><h4><asp:Label ID="LblJudul" runat="server" Text="AKTIVITAS PEKERJAAN BP" Font-Bold="true"></asp:Label></h4></center>--%>
        <div id="print" class="form-group" runat="server">

          
                            <asp:Label ID="Label2"  runat="server" Text="Honda Mugen" Font-Bold="true"></asp:Label><br />
                            <asp:Label ID="Label3"  runat="server" Text="PT Mitra Usaha Gentaniaga"  ></asp:Label><br />
                            <asp:Label ID="LblAlamat"  runat="server" Text="PT Mitra Usaha Gentaniaga"  ></asp:Label><br />
                            <asp:Label ID="Lbltelp"  runat="server" Text="PT Mitra Usaha Gentaniaga"  ></asp:Label><br />
                            <asp:Label ID="LblFax"  runat="server" Text="PT Mitra Usaha Gentaniaga" ></asp:Label><br />
                            <asp:Label ID="LblHttp" runat="server" Text="PT Mitra Usaha Gentaniaga"  ></asp:Label>
  
            <%--<br /><br /><br /><br /><br /><br />--%>
            <h3 align="center">AKTIVITAS PEKERJAAN BP</h3>
            <h4 align="center">No WO : <asp:Label ID="LblWo" runat="server" Text="Label" ></asp:Label></h4>
            <h5 align ="center">Tanggal Estimasi : <asp:Label ID="LblTanggalEstimasi" runat="server" Text="Label"></asp:Label></h5>
        <div class="row"><br />
            
         <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:serviceConnection %>" SelectCommand="SELECT [KERJABODY_NOWO], [KERJABODY_TANGGAL], [KERJABODY_USER], 
             case [KERJABODY_STATUS] 
		WHEN 1 THEN 'DISERAHKAN SA KE VENDOR'
        when 2 then 'DISERAHKAN SA KE DRIVER'  
		when 3 then 'DITERIMA' 
		when 4 then 'BONGKAR' 
		when 5 then 'KETOK' 
		when 6 then 'DEMPUL' 
		when 7 then 'CAT/OVEN' 
		when 8 then 'POLES' 
		when 9 then 'PEMASANGAN' 
		when 10 then 'FINISHING'  
		when 11 then 'PENILAIAN QC - OK'	
		when 12 then 'PENILAIAN QC - NOT OK' 
		when 13 then 'PENILAIAN QC - REWORK' 
		when 14 then 'PENILAIAN QC - REWORK - OK'  
		when 15 then 'PENILAIAN QC - REWORK - NOT OK' 
		when 16 then 'PENYERAHAN UNIT QC KE SA BP'   
             else 'UNCATEGORIZED' end AS statusval, case [KERJABODY_LOKASI] when 1 then 'lt. 1' when 2 then 'lt. 2' when 3 then 'lt. 3' when 4 then 'lt.4' when 5 then 'lt. 5' when 6 then 'lt. 6' when 7 then 'lt. 7' when 8 then 'lt. 8' when 9 then 'lt. 9' else '' END AS lokasimobil, [KERJABODY_CATATAN] FROM [TEMP_KERJABODY] WHERE ([KERJABODY_NOWO] = @KERJABODY_NOWO) ORDER BY KERJABODY_STATUS ASC">
             <SelectParameters>
                 <asp:QueryStringParameter Name="KERJABODY_NOWO" QueryStringField="qnowo" Type="String" />
             </SelectParameters>
         </asp:SqlDataSource>
            <asp:Label ID="NoWo" Visible="false" runat="server" Text="Label"></asp:Label>
            <asp:ListView ID="LvReportBP"  runat="server">
                <LayoutTemplate>
                    <table class="table" border="1">
                        <thead>
                            <tr>
                                            <th scope="col" style="text-align:center">User</th>
                                            <th scope="col" style="text-align:center">Tgl & Jam Kerja</th>
                                            <th scope="col" style="text-align:center">Status</th>
                                            <th scope="col"style="text-align:center">Lokasi</th>
                                            <th scope="col"  style="text-align:center">Catatan</th>
                            </tr>
                        </thead>
                     <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    Data Tidak Di Temukan
                </EmptyDataTemplate>
                <ItemTemplate>
                        <td><%#Eval("KERJABODY_USER")%></td>
                        <td><%#Eval("KERJABODY_TANGGAL" ,"{0:d}")%> / <%# Eval("KERJABODY_TANGGAL", "{0:HH:mm tt}") %></td>
                        <td><%#Eval("statusval")%> </td>
                        <td><%#Eval("lokasimobil")%> </td>
                        <td><%#Eval("KERJABODY_CATATAN")%> </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>Data Kosong</EmptyDataTemplate>
            </asp:ListView>
        </div>
        <div class="row">
            <div class="col">
                <div class="float-right">
                    <br />
                    <br />
                    <p align="right">Di Release oleh QC</p><br />
                    <p align="right"><%= DateTime.Now.ToLongTimeString() %></p>
                </div>
            </div>
        </div>
        </div>
        <div class="row">
            <asp:Label ID="Label1" runat="server" Text="Masukan Alamat Email Tujuan : "></asp:Label><br />
            <asp:TextBox ID="TxtEmailReciever" CssClass="form form-control"  Width="300px" runat="server" autocomplete="off"></asp:TextBox><br />
        </div>
        <div class="row">
            <asp:Label ID="Label4" runat="server" Text="Masukan Alamat Email Tujuan CC: "></asp:Label><br />
            <asp:TextBox ID="TxtEmailReciever2" CssClass="form form-control"  Width="300px" runat="server" autocomplete="off"></asp:TextBox><br />
        </div>
        <div class="row">
            <asp:Button ID="BtnKirimEmail" runat="server" Text="PDF - Email" CssClass="btn btn-danger" OnClick="BtnKirimEmail_Click" />
            <asp:Button ID="BtnDownload" runat="server" Text="PDF - Download" CssClass="btn btn-danger" OnClick="BtnDownload_Click"/>
        </div>
    </div>
    </form>
</body>
</html>
