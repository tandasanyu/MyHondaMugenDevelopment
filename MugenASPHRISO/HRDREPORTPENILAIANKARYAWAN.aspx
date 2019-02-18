<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HRDREPORTPENILAIANKARYAWAN.aspx.vb" Inherits="HRDREPORTPENILAIANKARYAWAN" title="Report Penilaian Karyawan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
	<style>
        .table-borderless > tbody > tr > td,
        .table-borderless > tbody > tr > th,
        .table-borderless > tfoot > tr > td,
        .table-borderless > tfoot > tr > th,
        .table-borderless > thead > tr > td,
        .table-borderless > thead > tr > th {
            border: none;
        }

        hr {
		  border:none;
		  border-top:1px dotted #f00;
		  color:#fff;
		  background-color:#fff;
		  height:1px;
		  width:100%;
		}

        .button {
            background-color: #4CAF50; /* Green */
            border-radius: 4px;
            border: none;
            color: white;
            padding: -10px 32px;
            width:160px;
            height:50px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 13px;
            margin: 4px 2px;
            -webkit-transition-duration: 0.4s; /* Safari */
            transition-duration: 0.4s;
            cursor: pointer;
        }

        .button4 {
            background-color: #9FB7E0;
            color: black;
            border: 2px solid #9FB7E0;
        }

        .button4:hover {
            background-color: #0071BB;
            color: white;
        }
    </style>    
    <script type="text/javascript">
	    $(document).ready(function(){
		    $('.data').DataTable( {
				"pageLength": 100
			});
	    });
    </script>
    <asp:Label ID="LblUserName" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblAkses" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea1" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea2" Style="display:none" runat="server"></asp:Label>
    <!-- label datetimenow -->
    <asp:Label ID="LabelThn" Style="display:none" runat="server"></asp:Label>

    <div class="container">
         <ul class="breadcrumb">
            <li><a href="#"><span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"><i class="glyphicon glyphicon-user"></i></a> &nbsp <a href="#"> HRD</a> </li>
            <li class="active"><span class="glyphicon glyphicon-edit"></span> &nbsp Penilaian Karyawan</li>
        </ul>
        <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
            <asp:View ID="Viewerr00" runat="server">
                <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" ForeColor="Red">Judul Permohonan</asp:Label>
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
            <asp:View ID="View1Akses" runat="server">
                <div class="container">
                    <center>
                        <h2 style="font-family:Cooper Black;">REPORT PK </h2>
                    </center>
	            </div>  <br /><br />
                <ul class="nav nav-tabs">
                    <li class="active"><a data-toggle="tab" href="#HO">Head Office</a></li>
                    <li><a data-toggle="tab" href="#meruya">Meruya</a></li>
                    <li><a data-toggle="tab" href="#psminggu">Mugen Ps. Minggu</a></li>
                    <li><a data-toggle="tab" href="#puri">Mugen Puri & Dadap</a></li> 
                    <li><a data-toggle="tab" href="#download">Download Report</a></li> 
                </ul><br /><br />
                
                 <div class="tab-content">
                    <div id="HO" class="tab-pane fade in active">
                        <h3 style="font-family:Blunter;">Head Office</h3>
                        <br />
                        <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                            SelectCommand="select * from TRXN_KPIH, DATA_STAFF where KPIH_NIK = STAFF_NIK AND STAFF_STATUSKERJALOKASI='HO' order by STAFF_STATUSKERJADEPT ASC, STAFF_STATUSKERJAJABATAN ASC, STAFF_STATUSKERJALOKASI DESC" 
                            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                        </asp:SqlDataSource>                                             
                        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="KPIH_NIK">
                            <LayoutTemplate>
                                <table id="table-a"  class="table table-bordered table-striped data">
                                    <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white">No.</th>
                                        <th style="text-align:center; color:white">NIK</th>
                                        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Department</th>
                                        <th style="text-align:center; color:white">Jabatan</th>
                                        <th style="text-align:center; color:white">Status</th>
                                        <th style="text-align:center; color:white">A</th>
                                        <th style="text-align:center; color:white">B</th>
                                        <th style="text-align:center; color:white">C</th>
                                        <th style="text-align:center; color:white">Total</th>
                                        <th style="text-align:center; color:white">Verifikasi Karyawan Ybs</th>
                                        <th style="text-align:center; color:white">Verifikasi Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Verifikasi Atasan dari Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Verifikasi HRD</th>
                                        <th style="text-align:center; color:white">Detail PK</th>
                                        <th style="text-align:center; color:white">Ubah</th>
                                    </thead>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </table>
                            </LayoutTemplate>
        
                            <ItemTemplate>
                                <tr>
                                    <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NIK")%></p></td>
                                    <td><p class="small"><%#Eval("STAFF_NAMA")%></p></td>
                                    <td><p class="small"><%#Eval("STAFF_STATUSKERJADEPT")%></p></td>
                                    <td><p class="small"><%#Eval("STAFF_STATUSKERJAJABATAN")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_TIPEA")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI1")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI2")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI3")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI")%></p></td>
                                    <td><p class="small"><%#Eval("KPIH_APPVUSER")%><br />
                                        <%#Eval("KPIH_APPVUSERTGL")%></p>
                                    </td>
                                    <td><p class="small"><%#Eval("KPIH_APPVHEAD")%><br />
                                        <%#Eval("KPIH_APPVHEADTGL")%></p>
                                    </td>
                                    <td><p class="small"><%#Eval("KPIH_APPVHEAD2")%><br />
                                        <%#Eval("KPIH_APPVHEADTGL2")%></p>
                                    </td>
                                    <td><p class="small"><%#Eval("KPIH_APPVHRD")%><br />
                                        <%#Eval("KPIH_APPVHRDTGL")%></p>
                                    </td>
                                     <td align="center"><a href="<%#"HRDPENILAIANKARYAWAN.aspx?no=" + Eval("KPIH_NIK")%>"><img src="img/details.png" width="70px" height="60px" /></a></td>
                                    <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/edit3.png" width="50px" height="40px" /></asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                            <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
                        </asp:ListView>
                    </div>
                    <div id="meruya" class="tab-pane fade">
                        <h3 style="font-family:Blunter;">Meruya</h3>
                        <br />
                        <asp:SqlDataSource ID="SqlDataMutuMaster2" runat="server"
                            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                            SelectCommand="select * from TRXN_KPIH, DATA_STAFF where KPIH_NIK = STAFF_NIK AND STAFF_STATUSKERJALOKASI='MERUYA' order by STAFF_STATUSKERJADEPT ASC, STAFF_STATUSKERJAJABATAN ASC, STAFF_STATUSKERJALOKASI DESC" 
                            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                        </asp:SqlDataSource>                                             
                        <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataMutuMaster2" DataKeyNames ="KPIH_NIK">
                            <LayoutTemplate>
                                <table id="table-a"  class="table table-bordered table-striped data">
                                    <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white">No.</th>
                                        <th style="text-align:center; color:white">NIK</th>
                                        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Department</th>
                                        <th style="text-align:center; color:white">Jabatan</th>
                                        <th style="text-align:center; color:white">Status</th>
                                        <th style="text-align:center; color:white">A</th>
                                        <th style="text-align:center; color:white">B</th>
                                        <th style="text-align:center; color:white">C</th>
                                        <th style="text-align:center; color:white">Total</th>
                                        <th style="text-align:center; color:white">Verifikasi Karyawan Ybs</th>
                                        <th style="text-align:center; color:white">Verifikasi Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Verifikasi Atasan dari Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Verifikasi HRD</th>
                                        <th style="text-align:center; color:white">Detail PK</th>
                                        <th style="text-align:center; color:white">Ubah</th>
                                    </thead>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </table>
                            </LayoutTemplate>
        
                            <ItemTemplate>
                                <tr>
                                    <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NIK")%></p></td>
                                    <td><p class="small"><%#Eval("STAFF_NAMA")%></p></td>
                                    <td><p class="small"><%#Eval("STAFF_STATUSKERJADEPT")%></p></td>
                                    <td><p class="small"><%#Eval("STAFF_STATUSKERJAJABATAN")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_TIPEA")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI1")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI2")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI3")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI")%></p></td>
                                    <td><p class="small"><%#Eval("KPIH_APPVUSER")%><br />
                                        <%#Eval("KPIH_APPVUSERTGL")%></p>
                                    </td>
                                    <td><p class="small"><%#Eval("KPIH_APPVHEAD")%><br />
                                        <%#Eval("KPIH_APPVHEADTGL")%></p>
                                    </td>
                                    <td><p class="small"><%#Eval("KPIH_APPVHEAD2")%><br />
                                        <%#Eval("KPIH_APPVHEADTGL2")%></p>
                                    </td>
                                    <td><p class="small"><%#Eval("KPIH_APPVHRD")%><br />
                                        <%#Eval("KPIH_APPVHRDTGL")%></p>
                                    </td>
                                     <td align="center"><a href="<%#"HRDPENILAIANKARYAWAN.aspx?no=" + Eval("KPIH_NIK")%>"><img src="img/details.png" width="70px" height="60px" /></a></td>
                                     <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/edit3.png" width="50px" height="40px" /></asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                            <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
                        </asp:ListView>
                    </div>
                     <div id="psminggu" class="tab-pane fade">
                        <h3 style="font-family:Blunter;"> Mugen Ps. Minggu</h3>
                        <br />
                        <asp:SqlDataSource ID="SqlDataMutuMaster3" runat="server"
                            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                            SelectCommand="select * from TRXN_KPIH, DATA_STAFF where KPIH_NIK = STAFF_NIK AND STAFF_STATUSKERJALOKASI='Mugen Ps. Minggu' order by STAFF_STATUSKERJADEPT ASC, STAFF_STATUSKERJAJABATAN ASC, STAFF_STATUSKERJALOKASI DESC" 
                            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                        </asp:SqlDataSource>                                             
                        <asp:ListView ID="ListView3" runat="server" DataSourceID="SqlDataMutuMaster3" DataKeyNames ="KPIH_NIK">
                            <LayoutTemplate>
                                <table id="table-a"  class="table table-bordered table-striped data">
                                    <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white">No.</th>
                                        <th style="text-align:center; color:white">NIK</th>
                                        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Department</th>
                                        <th style="text-align:center; color:white">Jabatan</th>
                                        <th style="text-align:center; color:white">Status</th>
                                        <th style="text-align:center; color:white">A</th>
                                        <th style="text-align:center; color:white">B</th>
                                        <th style="text-align:center; color:white">C</th>
                                        <th style="text-align:center; color:white">Total</th>
                                        <th style="text-align:center; color:white">Verifikasi Karyawan Ybs</th>
                                        <th style="text-align:center; color:white">Verifikasi Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Verifikasi Atasan dari Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Verifikasi HRD</th>
                                        <th style="text-align:center; color:white">Detail PK</th>
                                        <th style="text-align:center; color:white">Ubah</th>
                                    </thead>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </table>
                            </LayoutTemplate>
        
                            <ItemTemplate>
                                <tr>
                                    <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NIK")%></p></td>
                                    <td><p class="small"><%#Eval("STAFF_NAMA")%></p></td>
                                    <td><p class="small"><%#Eval("STAFF_STATUSKERJADEPT")%></p></td>
                                    <td><p class="small"><%#Eval("STAFF_STATUSKERJAJABATAN")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_TIPEA")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI1")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI2")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI3")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI")%></p></td>
                                    <td><p class="small"><%#Eval("KPIH_APPVUSER")%><br />
                                        <%#Eval("KPIH_APPVUSERTGL")%></p>
                                    </td>
                                    <td><p class="small"><%#Eval("KPIH_APPVHEAD")%><br />
                                        <%#Eval("KPIH_APPVHEADTGL")%></p>
                                    </td>
                                    <td><p class="small"><%#Eval("KPIH_APPVHEAD2")%><br />
                                        <%#Eval("KPIH_APPVHEADTGL2")%></p>
                                    </td>
                                    <td><p class="small"><%#Eval("KPIH_APPVHRD")%><br />
                                        <%#Eval("KPIH_APPVHRDTGL")%></p>
                                    </td>
                                     <td align="center"><a href="<%#"HRDPENILAIANKARYAWAN.aspx?no=" + Eval("KPIH_NIK")%>"><img src="img/details.png" width="70px" height="60px" /></a></td>
                                     <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/edit3.png" width="50px" height="40px" /></asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                            <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
                        </asp:ListView>
                    </div>
                     <div id="puri" class="tab-pane fade">
                        <h3 style="font-family:Blunter;">Mugen Puri & Dadap</h3>
                        <br />
                        <asp:SqlDataSource ID="SqlDataMutuMaster4" runat="server"
                            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                            SelectCommand="select * from TRXN_KPIH, DATA_STAFF where KPIH_NIK = STAFF_NIK AND STAFF_STATUSKERJALOKASI in ('Mugen Puri', 'DADAP') order by STAFF_STATUSKERJADEPT ASC, STAFF_STATUSKERJAJABATAN ASC, STAFF_STATUSKERJALOKASI DESC" 
                            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                        </asp:SqlDataSource>                                             
                        <asp:ListView ID="ListView4" runat="server" DataSourceID="SqlDataMutuMaster4" DataKeyNames ="KPIH_NIK">
                            <LayoutTemplate>
                                <table id="table-a"  class="table table-bordered table-striped data">
                                    <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white">No.</th>
                                        <th style="text-align:center; color:white">NIK</th>
                                        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Department</th>
                                        <th style="text-align:center; color:white">Jabatan</th>
                                        <th style="text-align:center; color:white">Status</th>
                                        <th style="text-align:center; color:white">A</th>
                                        <th style="text-align:center; color:white">B</th>
                                        <th style="text-align:center; color:white">C</th>
                                        <th style="text-align:center; color:white">Total</th>
                                        <th style="text-align:center; color:white">Verifikasi Karyawan Ybs</th>
                                        <th style="text-align:center; color:white">Verifikasi Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Verifikasi Atasan dari Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Verifikasi HRD</th>
                                        <th style="text-align:center; color:white">Detail PK</th>
                                        <th style="text-align:center; color:white">Ubah</th>
                                    </thead>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </table>
                            </LayoutTemplate>
        
                            <ItemTemplate>
                                <tr>
                                    <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NIK")%></p></td>
                                    <td><p class="small"><%#Eval("STAFF_NAMA")%></p></td>
                                    <td><p class="small"><%#Eval("STAFF_STATUSKERJADEPT")%></p></td>
                                    <td><p class="small"><%#Eval("STAFF_STATUSKERJAJABATAN")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_TIPEA")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI1")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI2")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI3")%></p></td>
                                    <td align="center"><p class="small"><%#Eval("KPIH_NILAI")%></p></td>
                                    <td><p class="small"><%#Eval("KPIH_APPVUSER")%><br />
                                        <%#Eval("KPIH_APPVUSERTGL")%></p>
                                    </td>
                                    <td><p class="small"><%#Eval("KPIH_APPVHEAD")%><br />
                                        <%#Eval("KPIH_APPVHEADTGL")%></p>
                                    </td>
                                    <td><p class="small"><%#Eval("KPIH_APPVHEAD2")%><br />
                                        <%#Eval("KPIH_APPVHEADTGL2")%></p>
                                    </td>
                                    <td><p class="small"><%#Eval("KPIH_APPVHRD")%><br />
                                        <%#Eval("KPIH_APPVHRDTGL")%></p>
                                    </td>
                                     <td align="center"><a href="<%#"HRDPENILAIANKARYAWAN.aspx?no=" + Eval("KPIH_NIK")%>"><img src="img/details.png" width="70px" height="60px" /></a></td>
                                     <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/edit3.png" width="50px" height="40px" /></asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                            <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
                        </asp:ListView>
                    </div>
                    <div id="download" class="tab-pane fade">
                        <h3 style="font-family:Blunter;">Download Report</h3>
                        <br />
                        <asp:Button ID="btnKPI" visible="false" runat="server" class="btn btn-primary" Text="Download Report KPI" onclick="btnKPI_Click" /> <asp:Button ID="btnPK" visible="false" runat="server" class="btn btn-primary" Text="Download Report PK" onclick="btnPK_Click" /><br /><br />
                        <asp:Button ID="btnSPV" visible="false" runat="server" class="btn btn-primary" Text="Download Report Penilaian Bawahan ke Atasan (SPV)" onclick="btnSPV_Click" /> <asp:Button ID="btnLD" visible="false" runat="server" class="btn btn-primary" Text="Download Report Penilaian Bawahan ke Atasan (Leader)" onclick="btnLD_Click" /> <asp:Button ID="btnKomen" visible="false" runat="server" class="btn btn-primary" Text="Download Komentar Bawahan ke Atasan" onclick="btnKomen_Click" /><br /><br />
                    </div>
                </div>
            </asp:View> 
        </asp:MultiView> 
        <asp:MultiView ID="MultiViewNilaiStandardEntry" runat="server" Visible="TRUE">
            <asp:View ID="View4" runat="server">    
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Update Data Atasan</font></div>
                    <div class="panel-body">
                        <center>
                            <h3 style="font-family:Blunter;">FORM UPDATE DATA ATASAN</h3>
                        </center>
	                    <br /><br />
                        <table class="table table-borderless">
                            <tr>
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label55" runat="server" Text="NIK"></asp:Label></td>
                                <td class="col-md-4"><asp:label ID="TxtNIK" runat="server" MaxLength="4" Text ="" class="form-control required"></asp:label></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label67" runat="server" Text="Nama"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="TxtNama" runat="server" MaxLength="10" Text ="" class="form-control required"></asp:Label></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label56" runat="server" Text="Atasan Langsung"></asp:Label></td>
                                <td class="col-md-4"><asp:DropDownList ID="TxtAtasanLangsung" runat="server" class="form-control required">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>AGUSSETIADI</asp:ListItem>
                                        <asp:ListItem>DARSONO</asp:ListItem>
                                        <asp:ListItem>DIDI</asp:ListItem>
                                        <asp:ListItem>DJUNIARTO</asp:ListItem>
                                        <asp:ListItem>EBNU</asp:ListItem>
                                        <asp:ListItem>EKO</asp:ListItem>
                                        <asp:ListItem>FAIZ</asp:ListItem>
                                        <asp:ListItem>FIA</asp:ListItem>
                                        <asp:ListItem>GUGUK</asp:ListItem>
                                        <asp:ListItem>HETTY</asp:ListItem>
                                        <asp:ListItem>ITA</asp:ListItem>
                                        <asp:ListItem>JAFAR</asp:ListItem>
                                        <asp:ListItem>LINDA</asp:ListItem>
                                        <asp:ListItem>LUKAS</asp:ListItem>
                                        <asp:ListItem>MAKHFUD</asp:ListItem>
                                        <asp:ListItem>NANI</asp:ListItem>
                                        <asp:ListItem>PARMONO</asp:ListItem>
                                        <asp:ListItem>RACHMAD</asp:ListItem>
                                        <asp:ListItem>RATNO</asp:ListItem>
                                        <asp:ListItem>SANTO</asp:ListItem>
                                        <asp:ListItem>SUGIYARTO</asp:ListItem>
                                        <asp:ListItem>TINI</asp:ListItem>
                                        <asp:ListItem>UGAM</asp:ListItem>
                                        <asp:ListItem>UNTUNG</asp:ListItem>
                                        <asp:ListItem>WAHONO</asp:ListItem>
                                        <asp:ListItem>WAHYU</asp:ListItem>
                                        <asp:ListItem>YUSUF</asp:ListItem>
										<asp:ListItem>SUTRIANINGSIH</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label57" runat="server" Text="Atasan dari Atasan Langsung"></asp:Label></td>
                                <td class="col-md-4"><asp:DropDownList ID="TxtAtasanLangsung2" runat="server" class="form-control required">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>AGUSSETIADI</asp:ListItem>
                                        <asp:ListItem>DARSONO</asp:ListItem>
                                        <asp:ListItem>DIDI</asp:ListItem>
                                        <asp:ListItem>DJUNIARTO</asp:ListItem>
                                        <asp:ListItem>EBNU</asp:ListItem>
                                        <asp:ListItem>EKO</asp:ListItem>
                                        <asp:ListItem>FAIZ</asp:ListItem>
                                        <asp:ListItem>FIA</asp:ListItem>
                                        <asp:ListItem>GUGUK</asp:ListItem>
                                        <asp:ListItem>HETTY</asp:ListItem>
                                        <asp:ListItem>ITA</asp:ListItem>
                                        <asp:ListItem>JAFAR</asp:ListItem>
                                        <asp:ListItem>LINDA</asp:ListItem>
                                        <asp:ListItem>LUKAS</asp:ListItem>
                                        <asp:ListItem>MAKHFUD</asp:ListItem>
                                        <asp:ListItem>NANI</asp:ListItem>
                                        <asp:ListItem>PARMONO</asp:ListItem>
                                        <asp:ListItem>RACHMAD</asp:ListItem>
                                        <asp:ListItem>RATNO</asp:ListItem>
                                        <asp:ListItem>SANTO</asp:ListItem>
                                        <asp:ListItem>SUGIYARTO</asp:ListItem>
                                        <asp:ListItem>TINI</asp:ListItem>
                                        <asp:ListItem>UGAM</asp:ListItem>
                                        <asp:ListItem>UNTUNG</asp:ListItem>
                                        <asp:ListItem>WAHONO</asp:ListItem>
                                        <asp:ListItem>WAHYU</asp:ListItem>
                                        <asp:ListItem>YUSUF</asp:ListItem>
										<asp:ListItem>SUTRIANINGSIH</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td class="col-md-2"></td>     
                            </tr>
                        </table> 
                        <center>
                            <asp:Button ID="BtnStandardSave" runat="server" Text="Simpan" class="btn btn-success" />
                        </center>
                        <br /><br />
                    </div>
                </div>         
            </asp:View> 
        </asp:MultiView>   
        <div style="display:none;">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                SelectCommand="SELECT KPIH_NIK, staff_nama, staff_statuskerjadept, staff_statuskerjajabatan, kpih_nilai1, kpih_nilai, CONVERT(varchar, staff_statuskerjamasukk, 103) as staff_statuskerjamasukk, CONVERT(varchar, staff_statuskerjatglangkat, 103) as staff_statuskerjatglangkat,  CASE  WHEN kpih_appvhrdtgl <> '' THEN 'Verified by HRD' WHEN kpih_appvheadtgl2 <> '' THEN 'Verified by Atasan dari Atasan Langsung' WHEN kpih_appvheadtgl <> '' THEN 'Verified by Atasan Langsung' WHEN kpih_appvusertgl <> '' THEN 'Verified by Karyawan Ybs' ELSE 'Not Verified by Karyawan Ybs'END AS verification_by FROM trxn_kpih, data_staff where kpih_nik=staff_nik order by staff_nama asc" 
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
            </asp:SqlDataSource>                                             
            <asp:ListView ID="ListViewKPI" runat="server" DataSourceID="SqlDataSource1" DataKeyNames ="KPIH_NIK">
                <LayoutTemplate>
                    <table id="table-a" border="1">
                        <thead style="background-color:#4877CF">
                            <th style="text-align:center;" >No.</th>
                            <th style="text-align:center;" >NIK</th>
                            <th style="text-align:center;">Nama Karyawan</th>
                            <th style="text-align:center;">Department</th>
                            <th style="text-align:center;">Jabatan</th>
                            <th style="text-align:center;">Tanggal Masuk <br /> (dd/mm/yyyy)</th>
                            <th style="text-align:center;">Tanggal Karyawan Tetap <br /> (dd/mm/yyyy)</th>
                            <th style="text-align:center;">Nilai KPI</th>
                            <th style="text-align:center;">Nilai Total PK</th>
                            <th style="text-align:center;">Verification By</th>
                        </thead>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
                </LayoutTemplate>
        
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#Container.DataItemIndex + 1 %></td>
                        <td align="center"><%#Eval("KPIH_NIK")%></td>
                        <td><%#Eval("STAFF_NAMA")%></p></td>
                        <td><%#Eval("STAFF_STATUSKERJADEPT")%></td>
                        <td><%#Eval("STAFF_STATUSKERJAJABATAN")%></td>
                        <td align="right"><%#Eval("staff_statuskerjamasukk")%></td>
                        <td align="right"><%#Eval("staff_statuskerjatglangkat")%></td>
                        <td align="center"><%#Eval("KPIH_NILAI1")%></td>
                        <td align="center"><%#Eval("KPIH_NILAI")%></td>
                        <td><%#Eval("verification_by")%></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
            </asp:ListView>
        </div>
        <div style="display:none;">
            <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                SelectCommand="select * from (SELECT KPIH_NIK,KPIH_TAHUN, staff_nama, STAFF_STATUSKERJALOKASI, staff_statuskerjadept, kpih_sp, staff_statuskerjajabatan, kpih_nilai1, kpih_nilai, kpi_kodeitem, kpi_atasan, CONVERT(varchar, staff_statuskerjamasukk, 103) as staff_statuskerjamasukk, CONVERT(varchar, staff_statuskerjatglangkat, 103) as staff_statuskerjatglangkat, CASE  WHEN kpih_appvhrdtgl <> '' THEN 'Verified by HRD' WHEN kpih_appvheadtgl2 <> '' THEN 'Verified by Atasan dari Atasan Langsung' WHEN kpih_appvheadtgl <> '' THEN 'Verified by Atasan Langsung' WHEN kpih_appvusertgl <> '' THEN 'Verified by Karyawan Ybs' ELSE 'Not Verified by Karyawan Ybs'END AS verification_by, CASE  WHEN staff_subjabatan = '0' THEN 'Operator' WHEN staff_subjabatan = '1' THEN 'Staff' WHEN STAFF_SUBJABATAN = '2' THEN 'Leader' WHEN STAFF_SUBJABATAN = '3' THEN 'SPV' WHEN STAFF_SUBJABATAN = '4' THEN 'Ast. Manager' ELSE 'Manager' END AS level_jabatan FROM trxn_kpih, data_staff, trxn_kpidd  where kpih_nik=staff_nik and kpih_nik = kpi_nik) as a pivot (max (kpi_atasan) for kpi_kodeitem in([PR1],[PR2],[PR3],[PR4],[PR5],[PR6],[PR7],[HD1],[HD2],[HD3],[HD4],[HD5])) as nilai " 
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">

            </asp:SqlDataSource>        
            <!-- LabelThn -->                                     
            <asp:ListView ID="ListViewPK" runat="server" DataSourceID="SqlDataSource2" DataKeyNames ="KPIH_NIK">
                <LayoutTemplate>
                    <table id="table-a" border="1">
                        <thead>
                            <th style="text-align:center;" rowspan ="2">No.</th>
                            <th style="text-align:center;" rowspan ="2">NIK</th>
                            <th style="text-align:center;" rowspan ="2">Nama Karyawan</th>
                            <th style="text-align:center;" rowspan ="2">Tahun PK</th>
                            <th style="text-align:center;" rowspan ="2">Lokasi</th>
                            <th style="text-align:center;" rowspan ="2">Department</th>
                            <th style="text-align:center;" rowspan ="2">Jabatan</th>
                            <th style="text-align:center;" rowspan ="2">Level</th>
                            <th style="text-align:center;" rowspan ="2">Tanggal Masuk <br /> (dd/mm/yyyy)</th>
                            <th style="text-align:center;" rowspan ="2">Tanggal Karyawan Tetap <br /> (dd/mm/yyyy)</th>
                            <th style="text-align:center;" rowspan ="2">KPI (A)</th>
                            <th style="text-align:center;" colspan="7">Proses (B)</th>
                            <th style="text-align:center;" colspan="5">People Management (C)</th>
                            <th style="text-align:center;" rowspan ="2">SP</th>
                            <th style="text-align:center;" rowspan ="2">Nilai Total PK</th>
                            <th style="text-align:center;" rowspan ="2">Verification By</th>
                        </thead>
                        <tr>
                            <th style="text-align:center;">Dorongan Untuk Berprestasi</th>
                            <th style="text-align:center;">Orientasi Kepuasan Pelanggan</th>
                            <th style="text-align:center;">Integritas</th>
                            <th style="text-align:center;">Hubungan Interpersonal</th>
                            <th style="text-align:center;">Cara Menyelesaikan Tugas</th>
                            <th style="text-align:center;">Kemampuan Komunikasi</th>
                            <th style="text-align:center;">Kepemimpinan (Leader)</th>
                            <th style="text-align:center;">Kepemimpinan</th>
                            <th style="text-align:center;">Coaching & Counseling</th>
                            <th style="text-align:center;">Conflict Management</th>
                            <th style="text-align:center;">Planning & Organization</th>
                            <th style="text-align:center;">Analytical Thinking, Problem Solving, & Decision</th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
                </LayoutTemplate>
        
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#Container.DataItemIndex + 1 %></td>
                        <td align="center"><%#Eval("KPIH_NIK")%></td>                        
                        <td><%#Eval("STAFF_NAMA")%></p></td>
                        <td><%#Eval("KPIH_TAHUN")%></p></td>
                        <td><%#Eval("STAFF_STATUSKERJALOKASI")%></td>
                        <td><%#Eval("STAFF_STATUSKERJADEPT")%></td>
                        <td><%#Eval("STAFF_STATUSKERJAJABATAN")%></td>
                        <td><%#Eval("LEVEL_JABATAN")%></td>
                        <td align="right"><%#Eval("staff_statuskerjamasukk")%></td>
                        <td align="right"><%#Eval("staff_statuskerjatglangkat")%></td>
                        <td align="center"><%#Eval("KPIH_NILAI1")%></td>
                        <td align="center"><%# Eval("PR1", "{0:N2}") %></td>
                        <td align="center"><%# Eval("PR2", "{0:N2}") %></td>
                        <td align="center"><%# Eval("PR3", "{0:N2}") %></td>
                        <td align="center"><%# Eval("PR4", "{0:N2}") %></td>
                        <td align="center"><%# Eval("PR5", "{0:N2}") %></td>
                        <td align="center"><%# Eval("PR6", "{0:N2}") %></td>
                        <td align="center"><%# Eval("PR7", "{0:N2}") %></td>
                        <td align="center"><%#Eval("HD1")%></td>
                        <td align="center"><%#Eval("HD2")%></td>
                        <td align="center"><%#Eval("HD3")%></td>
                        <td align="center"><%#Eval("HD4")%></td>
                        <td align="center"><%#Eval("HD5")%></td>
                        <td align="center"><%#Eval("KPIH_SP")%></td>
                        <td align="center"><%#Eval("KPIH_NILAI")%></td>
                        <td><%#Eval("verification_by")%></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
            </asp:ListView>
        </div>     
        <div style="display:none;">
            <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                SelectCommand="select * from (SELECT staff_NIK, staff_nama, staff_statuskerjadept, staff_statuskerjajabatan,staff_statuskerjalokasi, kpin_atasan, kpin_nilai, kpin_kode FROM trxn_kpin, data_staff where (staff_nama=kpin_user or staff_nik=kpin_nik) and KPIN_GROUP='2') as a pivot (max (kpin_nilai) for kpin_kode in([001],[002],[003],[004],[005],[006],[007],[008],[009],[010],[011],[012],[013],[014],[015],[016],[017],[018],[019],[020])) as nilai" 
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
            </asp:SqlDataSource>                                             
            <asp:ListView ID="ListViewSPV" runat="server" DataSourceID="SqlDataSource3" DataKeyNames ="STAFF_NIK">
                <LayoutTemplate>
                    <table id="table-a" border="1">
                        <thead>
                            <th style="text-align:center;" rowspan ="2">No.</th>
                            <th style="text-align:center;" rowspan ="2">NIK</th>
                            <th style="text-align:center;" rowspan ="2">Nama Karyawan</th>
                            <th style="text-align:center;" rowspan ="2">Jabatan</th>
                            <th style="text-align:center;" rowspan ="2">Nama Atasan</th>
                            <th style="text-align:center;" rowspan ="2">Lokasi</th>
                            <th style="text-align:center;" rowspan ="2">Department</th>
                            <th style="text-align:center;" rowspan ="2">Form</th>
                            <th style="text-align:center;" colspan="4">Kepemimpinan</th>
                            <th style="text-align:center;" colspan="4">Coaching & Counseling</th>
                            <th style="text-align:center;" colspan="4">Conflict Management</th>
                            <th style="text-align:center;" colspan="4">Planning & Organization</th>
                            <th style="text-align:center;" colspan="4">Analytical Thinking, Problem Solving & Decision Making</th>
                        </thead>
                        <tr>
                            <th style="text-align:center;">1</th>
                            <th style="text-align:center;">2</th>
                            <th style="text-align:center;">3</th>
                            <th style="text-align:center;">4</th>
                            <th style="text-align:center;">13</th>
                            <th style="text-align:center;">14</th>
                            <th style="text-align:center;">15</th>
                            <th style="text-align:center;">16</th>
                            <th style="text-align:center;">17</th>
                            <th style="text-align:center;">18</th>
                            <th style="text-align:center;">19</th>
                            <th style="text-align:center;">20</th>
                            <th style="text-align:center;">5</th>
                            <th style="text-align:center;">6</th>
                            <th style="text-align:center;">7</th>
                            <th style="text-align:center;">8</th>
                            <th style="text-align:center;">9</th>
                            <th style="text-align:center;">10</th>
                            <th style="text-align:center;">11</th>
                            <th style="text-align:center;">12</th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
                </LayoutTemplate>
        
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#Container.DataItemIndex + 1 %></td>
                        <td align="center"><%#Eval("STAFF_NIK")%></td>
                        <td><%#Eval("STAFF_NAMA")%></p></td>
                        <td><%#Eval("STAFF_STATUSKERJAJABATAN")%></td>
                        <td><%#Eval("KPIN_ATASAN")%></td>
                        <td><%#Eval("STAFF_STATUSKERJALOKASI")%></td>
                        <td><%#Eval("STAFF_STATUSKERJADEPT")%></td>
                        <td align="center">SPV With Team</td>
                        <td align="center"><%#Eval("001")%></td>
                        <td align="center"><%#Eval("002")%></td>
                        <td align="center"><%#Eval("003")%></td>
                        <td align="center"><%#Eval("004")%></td>
                        <td align="center"><%#Eval("013")%></td>
                        <td align="center"><%#Eval("014")%></td>
                        <td align="center"><%#Eval("015")%></td>
                        <td align="center"><%#Eval("016")%></td>
                        <td align="center"><%#Eval("017")%></td>
                        <td align="center"><%#Eval("018")%></td>
                        <td align="center"><%#Eval("019")%></td>
                        <td align="center"><%#Eval("020")%></td>
                        <td align="center"><%#Eval("005")%></td>
                        <td align="center"><%#Eval("006")%></td>
                        <td align="center"><%#Eval("007")%></td>
                        <td align="center"><%#Eval("008")%></td>
                        <td align="center"><%#Eval("009")%></td>
                        <td align="center"><%#Eval("010")%></td>
                        <td align="center"><%#Eval("011")%></td>
                        <td align="center"><%#Eval("012")%></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
            </asp:ListView>
        </div>     
        <div style="display:none;">
            <asp:SqlDataSource ID="SqlDataSource4" runat="server"
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                SelectCommand="select kpin_atasan, STAFF_STATUSKERJALOKASI, STAFF_STATUSKERJADEPT, round((AVG(cast (KPIN_NILAI as float))*10),2) as average from trxn_kpin, DATA_STAFF where STAFF_NAMA = trxn_kpin.kpin_atasan and kpin_group ='1' and kpin_atasan = staff_nama and kpin_kode in ('001','002','003','004','005','006','007','008','009','010','011','012','013','014','015','016') group by trxn_kpin.kpin_atasan, STAFF_STATUSKERJALOKASI, STAFF_STATUSKERJADEPT" 
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
            </asp:SqlDataSource>                                             
            <asp:ListView ID="ListViewLD" runat="server" DataSourceID="SqlDataSource4" DataKeyNames ="KPIN_ATASAN">
                <LayoutTemplate>
                    <table id="table-a" border="1">
                        <thead>
                            <th style="text-align:center;">No.</th>
                            <th style="text-align:center;">Nama Atasan</th>
                            <th style="text-align:center;">Lokasi</th>
                            <th style="text-align:center;">Department</th>
                            <th style="text-align:center;">Form</th>
                            <th style="text-align:center;">Rata-Rata Kepemimpinan</th>
                        </thead>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
                </LayoutTemplate>
        
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#Container.DataItemIndex + 1 %></td>
                        <td><%#Eval("KPIN_ATASAN")%></td>
                        <td><%#Eval("STAFF_STATUSKERJALOKASI")%></p></td>
                        <td><%#Eval("STAFF_STATUSKERJADEPT")%></td>
                        <td align="center">Leader</td>
                        <td align="center"><%#Eval("AVERAGE")%></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
            </asp:ListView>
        </div>  
        <div style="display:none;">
            <asp:SqlDataSource ID="SqlDataSource5" runat="server"
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                SelectCommand="select  kpin_atasan, kpin_note from trxn_kpin, DATA_STAFF where kpin_atasan = staff_nama and kpin_note <>'' group by kpin_atasan, kpin_note" 
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
            </asp:SqlDataSource>                                             
            <asp:ListView ID="ListViewKomen" runat="server" DataSourceID="SqlDataSource5" DataKeyNames ="KPIN_ATASAN">
                <LayoutTemplate>
                    <table id="table-a" border="1">
                        <thead>
                            <th style="text-align:center;">No.</th>
                            <th style="text-align:center;">Nama Atasan</th>
                            <th style="text-align:center;">Komentar Bawahan</th>
                        </thead>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
                </LayoutTemplate>
        
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#Container.DataItemIndex + 1 %></td>
                        <td><%#Eval("KPIN_ATASAN")%></td>
                        <td><%#Eval("KPIN_NOTE")%></p></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
            </asp:ListView>
        </div>   
    </div>
</asp:Content>

