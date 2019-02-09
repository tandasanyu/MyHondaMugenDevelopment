<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HRDABSENSIPENILAIANKARYAWAN.aspx.vb" Inherits="ABSENSIKARYAWAN" title="ABSENSI KARYAWAN" %>
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
            <li class="active"><span class="glyphicon glyphicon-briefcase"></span> &nbsp Data Absensi Penilaian Karyawan</li>
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
                        <h2 style="font-family:Cooper Black;">DATA ABSENSI PENILAIAN KARYAWAN 2017</h2>
                    </center>
	            </div><br /><br />
                <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="select * from (SELECT staff_nama, kpi_nik, kpi_kodeitem, kpi_staff FROM trxn_kpidd, data_staff where kpi_staff is not NULL and kpi_nik=staff_nik) as a pivot (max (kpi_staff) for kpi_kodeitem in([AB1],[AB2],[AB3],[AB4],[AB5],[AB6])) as nilai" 
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="kpi_nik">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped data">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">NIK</th>
                                <th style="text-align:center; color:white">Nama Karyawan</th>
                                <th style="text-align:center; color:white">Alpha</th>
                                <th style="text-align:center; color:white">Sakit Tanpa Surat Dokter & Ijin</th>
                                <th style="text-align:center; color:white">Ijin Datang Siang</th>
                                <th style="text-align:center; color:white">Terlambat</th>
                                <th style="text-align:center; color:white">Ijin Pulang Cepat</th>
                                <th style="text-align:center; color:white">Tidak Absen Pulang / Pulang Cepat</th>
                                <th></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("KPI_NIK")%></td>
                            <td><%#Eval("STAFF_NAMA")%></td>
                            <td align="center"><%#Eval("AB1")%></td>
                            <td align="center"><%#Eval("AB2")%></td>
                            <td align="center"><%#Eval("AB3")%></td>
                            <td align="center"><%#Eval("AB4")%></td>
                            <td align="center"><%#Eval("AB5")%></td>
                            <td align="center"><%#Eval("AB6")%></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server"><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Absensi Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Absensi Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
            </asp:View> 
        </asp:MultiView> 
        <asp:MultiView ID="MultiViewNilaiStandardEntry" runat="server" Visible="TRUE">
            <asp:View ID="View4" runat="server">    
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Ubah Data Absensi</font></div>
                    <div class="panel-body">
                        <center>
                            <h3 style="font-family:Blunter;">FORM UBAH DATA ABSENSI</h3>
                        </center>
	                    <br /><br />
                        <table class="table table-borderless">
                            <tr>
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label55" runat="server" Text="NIK"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="TxtNIK" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:Label></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Nama"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="TxtNama" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:Label></td>
                                <td class="col-md-2"></td>
                            </tr>
                        </table> 
                        <table class="table table-bordered table-striped data">
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white">Alpha</th>
                                <th style="text-align:center; color:white">Sakit Tanpa Surat Dokter & Ijin</th>
                                <th style="text-align:center; color:white">Ijin Datang Siang</th>
                                <th style="text-align:center; color:white">Terlambat</th>
                                <th style="text-align:center; color:white">Ijin Pulang Cepat</th>
                                <th style="text-align:center; color:white">Tidak Absen Pulang / Pulang Cepat</th>
                            </tr>
                            <tr>
                                <td><asp:TextBox ID="AB1" runat="server" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="AB2" runat="server" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="AB3" runat="server" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="AB4" runat="server" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="AB5" runat="server" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="AB6" runat="server" class="form-control required"></asp:TextBox></td>
                            </tr>
                        </table><br />
                        <center>
                            <asp:Button ID="BtnStandardSave" runat="server" Text="Simpan" class="btn btn-success" />
                        </center>
                        <br /><br />
                    </div>
                </div>         
            </asp:View> 
        </asp:MultiView>     
           
    </div>
</asp:Content>

