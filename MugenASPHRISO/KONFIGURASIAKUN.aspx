<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="KONFIGURASIAKUN.aspx.vb" Inherits="KONFIGURASIAKUN" title="Konfigurasi Akun" %>
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
                        <h2 style="font-family:Cooper Black;">KONFIGURASI</h2>
                    </center>
	            </div>  <br /><br />
                <ul class="nav nav-tabs">
                    <li class="active"><a data-toggle="tab" href="#akun">Akun</a></li>
                    <li><a data-toggle="tab" href="#divisi">Divisi</a></li>
                </ul>

                 <div class="tab-content">
                    <div id="akun" class="tab-pane fade in active">
                        <h3 style="font-family:Blunter;">Akun</h3>
                        <br />
                        <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
                            SelectCommand="select *, (SELECT headdivisi  FROM divisi where kddivisi collate SQL_Latin1_General_CP1_CI_AS = tb_user.kddivisi2 collate SQL_Latin1_General_CP1_CI_AS) as mn2, (SELECT headdivisi  FROM divisi where kddivisi collate SQL_Latin1_General_CP1_CI_AS = tb_user.kddivisi3 collate SQL_Latin1_General_CP1_CI_AS) as mn3 from tb_user order by namakaryawan asc" 
                            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                        </asp:SqlDataSource>                                             
                        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="kdkaryawan">
                            <LayoutTemplate>
                                <table id="table-a"  class="table table-bordered table-striped data">
                                    <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white">No.</th>
                                        <th style="text-align:center; color:white">NIK</th>
                                        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Username</th>
                                        <th style="text-align:center; color:white">Password</th>
                                        <th style="text-align:center; color:white">Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Atasan Dari Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Ubah</th>
                                    </thead>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </table>
                            </LayoutTemplate>
        
                            <ItemTemplate>
                                <tr>
                                    <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                                    <td align="center"><p class="small"><%#Eval("KDKARYAWAN")%></p></td>
                                    <td><p class="small"><%#Eval("NAMAKARYAWAN")%></p></td>
                                    <td><p class="small"><%#Eval("USERNAME")%></p></td>
                                    <td><p class="small"><%#Eval("PASSWORD")%></p></td>
                                    <td><p class="small"><%#Eval("kddivisi2")%></p></td>
                                    <td><p class="small"><%#Eval("kddivisi3")%></p></td>
                                    <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/edit3.png" width="50px" height="40px" /></asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                            <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
                        </asp:ListView>
                    </div>
                    
                     <div id="divisi" class="tab-pane fade">
                        <h3 style="font-family:Blunter;"> Divisi</h3>
                        <br />
                        <asp:SqlDataSource ID="SqlDataMutuMaster3" runat="server"
                            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
                            SelectCommand="select * from DIVISI where kddivisi not in ('')" 
                            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                        </asp:SqlDataSource>                                             
                        <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataMutuMaster3" DataKeyNames ="KDDIVISI">
                            <LayoutTemplate>
                                <table id="table-a"  class="table table-bordered table-striped data">
                                    <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white" class="col-md-1">No.</th>
                                        <th style="text-align:center; color:white" class="col-md-3">Kode Divisi</th>
                                        <th style="text-align:center; color:white" class="col-md-3">Nama Divisi</th>
                                        <th style="text-align:center; color:white" class="col-md-3">Email Divisi</th>
                                        <th style="text-align:center; color:white">Head</th>
                                        <th style="text-align:center; color:white">Ubah</th>
                                    </thead>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </table>
                            </LayoutTemplate>
        
                            <ItemTemplate>
                                <tr>
                                    <td><%#Container.DataItemIndex + 1 %></td>
                                    <td><%#Eval("KDDIVISI")%></td>
                                    <td><%#Eval("NMDIVISI")%></td>
                                    <td><%#Eval("EMAILDIVISI")%></td>
                                    <td><%#Eval("HEADDIVISI")%></td>
                                    <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/edit3.png" width="50px" height="40px" /></asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                            <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
                        </asp:ListView>
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
                                <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Username"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="TxtUsername" runat="server" MaxLength="10" Text ="" class="form-control required"></asp:Label></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Password"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="TxtPassword" runat="server" MaxLength="10" Text ="" class="form-control required"></asp:Label></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label56" runat="server" Text="Atasan Langsung"></asp:Label></td>
                                <td class="col-md-4"><asp:DropDownList ID="TxtAtasanLangsung" runat="server"  DataValueField="KDDIVISI"  DataValueText="KDDIVISI"  DataSourceID="SqlDataSource1" class="form-control required"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1"  runat="server"
                                        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
                                        SelectCommand="SELECT * FROM [DIVISI] Order By [KDDIVISI] ASC"
                                        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                                    </asp:SqlDataSource>
                                </td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label57" runat="server" Text="Atasan dari Atasan Langsung"></asp:Label></td>
                                <td class="col-md-4"><asp:DropDownList ID="TxtAtasanLangsung2" runat="server"  DataValueField="KDDIVISI"  DataValueText="KDDIVISI"  DataSourceID="SqlDataSource1"  class="form-control required"></asp:DropDownList></td>
                                <td class="col-md-2"></td>     
                            </tr>
                        </table> 
                        <center>
                            <asp:Button ID="BtnStandardDelete" OnClientClick="return confirm('Apakah anda yakin akan menghapus user ini?');" runat="server" Text="Hapus" class="btn btn-danger" />
                            <asp:Button ID="BtnStandardSave" runat="server" Text="Simpan" class="btn btn-success" />
                        </center>
                        <br /><br />
                    </div>
                </div>         
            </asp:View> 
        </asp:MultiView>     
         <asp:MultiView ID="MultiViewNilaiStandardEntry2" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">    
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Update Data Atasan</font></div>
                    <div class="panel-body">
                        <center>
                            <h3 style="font-family:Blunter;">FORM UPDATE DATA DIVISI</h3>
                        </center>
	                    <br /><br />
                        <table class="table table-borderless">
                            <tr>
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="Kode Divisi"></asp:Label></td>
                                <td class="col-md-4"><asp:label ID="TxtKode" runat="server" Text ="" class="form-control required"></asp:label></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label5" runat="server" Text="Nama Divisi"></asp:Label></td>
                                <td class="col-md-4"><asp:Textbox ID="TxtNmDivisi" runat="server" MaxLength="10" Text ="" class="form-control required"></asp:Textbox></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label7" runat="server" Text="Email Divisi"></asp:Label></td>
                                <td class="col-md-4"><asp:Textbox ID="TxtEmail" runat="server" MaxLength="10" Text ="" class="form-control required"></asp:Textbox></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label9" runat="server" Text="Head"></asp:Label></td>
                                <td class="col-md-4"><asp:Textbox ID="TxtHead" runat="server" MaxLength="10" Text ="" class="form-control required"></asp:Textbox></td>
                                <td class="col-md-2"></td>
                            </tr>
                        </table> 
                        <center>
                            <asp:Button ID="BtnStandardDelete2" OnClientClick="return confirm('Apakah anda yakin akan menghapus user ini?');" runat="server" Text="Hapus" class="btn btn-danger" />
                            <asp:Button ID="BtnStandardSave2" runat="server" Text="Simpan" class="btn btn-success" />
                        </center>
                        <br /><br />
                    </div>
                </div>         
            </asp:View> 
        </asp:MultiView>    
    </div>
</asp:Content>

