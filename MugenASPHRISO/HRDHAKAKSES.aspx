<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HRDHAKAKSES.aspx.vb" Inherits="HRDHAKAKSES" title="HRD HAK AKSES" %>
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
	        $('.data').DataTable();
	        $('.data2').DataTable();
	    });
    </script>

    <asp:Label ID="LblUserName" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblAkses" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea1" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea2" Style="display:none" runat="server"></asp:Label>

    <div class="container">
        <ul class="breadcrumb">
            <li><a href="#"><span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"><i class="glyphicon glyphicon-user"></i></a> &nbsp <a href="#"> HRD</a> </li>
            <li class="active"><span class="glyphicon glyphicon-lock"></span> &nbsp Hak Akses Karyawan</li>
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
                        <h2 style="font-family:Cooper Black;">Hak Akses Karyawan</h2>
                    </center>
	            </div><br />
                 <ul class="nav nav-tabs">
                    <li class="active"><a data-toggle="tab" href="#HA1">Pemberian & Pencabutan Hak Akses</a></li>
                    <li><a data-toggle="tab" href="#HA2">Penjelasan Hak Akses</a></li>
                </ul><br /><br />
                 <div class="tab-content">
                    <div id="HA1" class="tab-pane fade in active">
                        <b>Petunjuk:</b><br />
                        1. Pilih nama user <br />
                        2. Jika ingin menambahkan hak akses, pilih hak akses kemudian tekan simpan <br />
                        3. Jika ingin mencabut hak akses, tekan icon delete pada hak akses yang ingin dihilangkan <br /><br /><br>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="panel panel-default">
                                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-user"></span> &nbsp <font style="color:#ffffff">Pilih Username</font></div>
                                    <div class="panel-body">
                                        <table class="table table-borderless" align="left">
                                            <tr> 
                                                <td width="30%"><asp:Label ID="Label56" runat="server" Text="Pilih User"></asp:Label></td>
                                                <td><asp:DropDownList ID="Lbluser" runat="server" OnTextChanged="cariUsername" autopostback="true" DataValueField="username"  DataValueText="username"  DataSourceID="SqlDataSource3" class="form-control required"></asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource3"  runat="server"
                                                        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
                                                        SelectCommand="SELECT * from tb_user Order By [username] ASC"
                                                        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                                                    </asp:SqlDataSource>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="panel panel-default">
                                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-lock"></span> &nbsp <font style="color:#ffffff">Tambah Hak Akses</font></div>
                                    <div class="panel-body">
                                        <table class="table table-borderless" align="left">
                                            <tr> 
                                                <td width="30%"><asp:Label ID="Label2" runat="server" Text="Nama User"></asp:Label></td>
                                                <td><asp:Label ID="txtUsername" runat="server" class="form-control required"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td width="30%"><asp:Label ID="Label1" runat="server" Text="Hak Akses"></asp:Label></td>
                                                <td><asp:DropDownList ID="txtHakakses" runat="server" DataValueField="namaakses"  DataValueText="namaakses"  DataSourceID="SqlDataSourceAkses" class="form-control required"></asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSourceAkses"  runat="server"
                                                        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
                                                        SelectCommand="SELECT * from tb_userakses where kategoriakses='HRD' Order By [namaakses] ASC"
                                                        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                                                    </asp:SqlDataSource>
                                                    <%--where kategoriakses='HRD'--%>
                                                </td>
                                            </tr>
                                        </table>
                                        <center>
                                            <asp:Button ID="simpanAkses" runat="server" Text="Simpan" class="btn btn-success" />
                                        </center>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br /><br />
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
                            SelectCommand="SELECT *  FROM tb_userutility, tb_userakses WHERE (username = ?) and namaakses = hakakses and kategoriakses='HRD' order by hakakses asc" 
                            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtUsername" Name="username" DefaultValue="" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>                                             
                        <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSource2" DataKeyNames ="idutility">
                            <LayoutTemplate>
                                <table id="table-a"  class="table table-bordered table-striped data">
                                    <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white">No.</th>
                                        <th style="text-align:center; color:white">Username</th>
                                        <th style="text-align:center; color:white">Hak Akses</th>
                                        <th style="text-align:center; color:white">Hapus Hak Akses</th>
                                    </thead>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td align="center"><%#Container.DataItemIndex + 1 %></td>
                                    <td align="center"><p style="text-transform: uppercase;"><%#Eval("username")%></p></td>
                                    <td><%#Eval("hakakses")%></td>
                                    <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server"  OnClientClick="return confirm('Apakah anda yakin akan menghapus hak akses untuk user ini?');"><img src="img/delete.png" width="50px" height="40px" /></asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>Data Hak Akses Tidak diketemukan</EmptyDataTemplate> 
                            <EmptyItemTemplate>Data Hak Akses Tidak diketemukan</EmptyItemTemplate>              
                        </asp:ListView>
                        </div>
                    <div id="HA2" class="tab-pane fade">
                        <table class="table table-bordered data">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">Nama Hak Akses</th>
                                <th style="text-align:center; color:white">Deskripsi</th>
                                <th style="text-align:center; color:white">Head HRD</th>
                                <th style="text-align:center; color:white">SPV HRD</th>
                                <th style="text-align:center; color:white">Staff HRD</th>
                                <th style="text-align:center; color:white">Direksi</th>
                                <th style="text-align:center; color:white">Head Dept.</th>
                                <th style="text-align:center; color:white">Karyawan</th>
                            </thead>
                            <tr>
                                <td class="col-md-3">DATABASE KARYAWAN -- KONFIGURASI </td>
                                <td class="col-md-3">Hak untuk melakukan penambahan, penghapusan, dan perubahan data identitas seluruh karyawan</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">DATABASE KARYAWAN -- VIEW DATA </td>
                                <td class="col-md-3">Hak untuk melihat seluruh data identitas karyawan</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">FORM FPTK -- DIKETAHUI </td>
                                <td class="col-md-3">Hak Head HRD untuk melakukan verifikasi FPTK</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">FORM FPTK -- DISETUJUI </td>
                                <td class="col-md-3">Hak Direksi untuk melakukan verifikasi FPTK setelah FPTK diverifikasi oleh Head HRD</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">FORM FPTK -- EDIT MPP </td>
                                <td class="col-md-3">Hak untuk melakukan perubahan data MPP</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">FORM FPTK -- VIEW DATA </td>
                                <td class="col-md-3">Hak Head Department untuk melihat history FPTK yang pernah diajukan</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">FORM FPTK -- VIEW MENU </td>
                                <td class="col-md-3">Hak untuk dapat mengakses dan melakukan pengajuan FPTK</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">FORM FPTK -- VIEW SEMUA DATA </td>
                                <td class="col-md-3">Hak untuk melihat semua history FPTK yang pernah diajukan oleh seluruh Head Department</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                             <tr>
                                <td class="col-md-3">PENILAIAN KARYAWAN -- DOWNLOAD KOMENTAR BAWAHAN KE ATASAN </td>
                                <td class="col-md-3">Hak untuk mendownload komentar bawahan ke atasan dalam bentuk Excel</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span>(Optional)</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">PENILAIAN KARYAWAN -- DOWNLOAD REPORT KPI </td>
                                <td class="col-md-3">Hak untuk mendownload laporan KPI dalam bentuk Excel</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span>(Optional)</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">PENILAIAN KARYAWAN -- DOWNLOAD REPORT PK </td>
                                <td class="col-md-3">Hak untuk mendownload laporan PK dalam bentuk Excel</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span>(Optional)</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                             <tr>
                                <td class="col-md-3">PENILAIAN KARYAWAN -- DOWNLOAD REPORT PENILAIAN BAWAHAN KE ATASAN (LEADER) </td>
                                <td class="col-md-3">Hak untuk mendownload laporan penilaian bawahan ke atasan (LEADER) dalam bentuk Excel</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span>(Optional)</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">PENILAIAN KARYAWAN -- DOWNLOAD REPORT PENILAIAN BAWAHAN KE ATASAN (SPV) </td>
                                <td class="col-md-3">Hak untuk mendownload laporan penilaian bawahan ke atasan (SPV) dalam bentuk Excel</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span>(Optional)</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">PENILAIAN KARYAWAN -- HRD HEAD EDIT </td>
                                <td class="col-md-3">Hak verifikasi dan edit PK point (A) untuk semua level karyawan yang telah di verifikasi atasan langsung atau atasan dari atasan langsung</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">PENILAIAN KARYAWAN -- KONFIGURASI </td>
                                <td class="col-md-3">Hak untuk menambahkan, menghapus, dan merubah item KPI dan Norma PK</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span> (Optional)</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">PENILAIAN KARYAWAN -- PENILAIAN ATASAN KE BAWAHAN </td>
                                <td class="col-md-3">Hak seorang atasan langsung ataupun atasan dari atasan langsung untuk melakukan penilaian terhadap karyawan yang termasuk dibawahannya</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">PENILAIAN KARYAWAN -- PENILAIAN BAWAHAN KE ATASAN (LEADER) </td>
                                <td class="col-md-3">Hak seorang karyawan untuk melakukan penilaian terhadap atasannya yang berkategori Leader</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                            </tr>
                            <tr>
                                <td class="col-md-3">PENILAIAN KARYAWAN -- PENILAIAN BAWAHAN KE ATASAN (SPV) </td>
                                <td class="col-md-3">Hak seorang karyawan untuk melakukan penilaian terhadap atasannya yang berkategori SPV</td>
                                <td align="center">-</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                            </tr>
                            <tr>
                                <td class="col-md-3">PENILAIAN KARYAWAN -- SETTING PK </td>
                                <td class="col-md-3">Hak untuk membuat PK, Reset verifikasi atasan langsung dan atasan dari atasan langsung, copy PK tahun sebelumnya, hapus PK dan setting deadline PK Karyawan</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span>(Optional)</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">PENILAIAN KARYAWAN -- SPV HRD EDIT </td>
                                <td class="col-md-3">Hak verifikasi dan edit PK point (A) untuk sub jabatan karyawan level Staff dan SPV yang telah di verifikasi atasan langsung atau atasan dari atasan langsung</td>
                                <td align="center">-</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>
                                <td class="col-md-3">PENILAIAN KARYAWAN -- STAFF HRD EDIT </td>
                                <td class="col-md-3">Hak verifikasi dan edit PK point (A) untuk sub jabatan karyawan level Operator dan Leader yang telah di verifikasi atasan langsung atau atasan dari atasan langsung</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>            
                                <td class="col-md-3">PENILAIAN KARYAWAN -- VIEW PK </td>
                                <td class="col-md-3">Melihat Detail Seluruh PK Karyawan</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                            <tr>            
                                <td class="col-md-3">PENILAIAN KARYAWAN -- VIEW REPORT </td>
                                <td class="col-md-3">Melihat Report PK Karyawan</td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span></td>
                                <td align="center"><span class="glyphicon glyphicon-ok"></span> (Optional)</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                                <td align="center">-</td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:View> 
        </asp:MultiView> 
    </div>
</asp:Content>