<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HRDPENILAIANBAWAHAN.aspx.vb" Inherits="HRDPENILAIANBAWAHAN" title="Penilaian Bawahan" %>
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
            <li class="active"><span class="glyphicon glyphicon-edit"></span> &nbsp Penilaian Karyawan</li>
        </ul>
        <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
            <asp:View ID="Viewerr00" runat="server">
                <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" ForeColor="Red">Judul Permohonan</asp:Label>
            </asp:View> 
        </asp:MultiView>
        <div class="container">
            <center>
                <h2 style="font-family:Cooper Black;">DAFTAR BAWAHAN</h2>
            </center>
	    </div><br /><br />
        <b>Perhatian:</b><br />
            1. Jika Anda Sebagai Atasan Langsung, Penilaian dapat dilakukan setelah karyawan Ybs melakukan verifikasi <br />
            2. Jika Anda Sebagai Atasan dari Atasan Langsung, Penilaian dapat dilakukan setelah Atasan Langsung dari karyawan Ybs melakukan verifikasi <br />
            3. Untuk mengetahui PK telah diverifikasi dapat dilihat pada masing-masing kolom verifikasi, pada bagian dibawah nama sudah menampilkan tanggal verifikasi atau belum <br /><br /><br>

        <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
            <asp:View ID="View1Akses" runat="server">
                <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT kpih_nik, staff_nama, kpih_appvuser, kpih_appvusertgl, kpih_appvhead, kpih_appvheadtgl, kpih_appvhead2, kpih_appvheadtgl2  FROM trxn_kpih INNER JOIN DATA_STAFF ON trxn_kpih.KPIH_NIK = DATA_STAFF.staff_nik WHERE (kpih_appvhead = ?) OR (KPIH_APPVHEAD2 = ?) ORDER BY STAFF_NAMA ASC" 
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="LblUserName" Name="kpih_appvhead" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="LblUserName" Name="kpih_appvhead2" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailMaster" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="kpih_nik">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped data">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">NIK</th>
                                <th style="text-align:center; color:white">Nama Karyawan</th>
                                <th style="text-align:center; color:white">Verifikasi Karyawan Ybs</th>
                                <th style="text-align:center; color:white">Verifikasi Atasan Langsung</th>
                                <th style="text-align:center; color:white">Verifikasi Atasan dari Atasan Langsung</th>
                                <th style="text-align:center; color:white">Detail</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td align="center"><%#Eval("kpih_nik")%></td>
                            <td><p style="text-transform: uppercase;"><%#Eval("staff_nama")%></p></td>
                            <td><p class="small"><%#Eval("KPIH_APPVUSERTGL")%></p>
                            </td>
                            <td><p class="small"><%#Eval("KPIH_APPVHEAD")%><br />
                                <%#Eval("KPIH_APPVHEADTGL")%></p>
                            </td>
                            <td><p class="small"><%#Eval("KPIH_APPVHEAD2")%><br />
                                <%#Eval("KPIH_APPVHEADTGL2")%></p>
                            </td>
                            <td align="center"><a href="<%#"HRDPENILAIANKARYAWAN.aspx?no=" + Eval("kpih_nik")%>"><img src="img/penilaian.png" width="70px" height="60px" /></a></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
            </asp:View> 
        </asp:MultiView> 
        
        <asp:MultiView ID="MultiViewAkses2" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
                <table class="table table-borderless" align="left">
                    <tr> 
                        <td width="15%"><asp:Label ID="Label56" runat="server" Text="Nama Atasan"></asp:Label></td>
                        <td><asp:DropDownList ID="TxtAtasan" runat="server" autopostback="true" DataValueField="HEADDIVISI"  DataValueText="HEADDIVISI"  DataSourceID="SqlDataSource3" style="width: 300px; height: 45px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource3"  runat="server"
                                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>"
                                SelectCommand="SELECT distinct(HEADDIVISI) as HEADDIVISI FROM [DIVISI] Order By [HEADDIVISI] ASC"
                                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
                <br /><br /><br /><br /><br />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT kpih_nik, staff_nama, kpih_appvuser, kpih_appvusertgl, kpih_appvhead, kpih_appvheadtgl, kpih_appvhead2, kpih_appvheadtgl2  FROM trxn_kpih INNER JOIN DATA_STAFF ON trxn_kpih.KPIH_NIK = DATA_STAFF.staff_nik WHERE (kpih_appvhead = ?) OR (KPIH_APPVHEAD2 = ?) ORDER BY STAFF_NAMA ASC" 
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtAtasan" Name="kpih_appvhead" DefaultValue="TINI" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="TxtAtasan" Name="kpih_appvhead2" DefaultValue="TINI" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>                                             
                <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSource2" DataKeyNames ="kpih_nik">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped data">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">NIK</th>
                                <th style="text-align:center; color:white">Nama Karyawan</th>
                                <th style="text-align:center; color:white">Verifikasi Karyawan Ybs</th>
                                <th style="text-align:center; color:white">Verifikasi Atasan Langsung</th>
                                <th style="text-align:center; color:white">Verifikasi Atasan dari Atasan Langsung</th>
                                <th style="text-align:center; color:white">Detail</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td align="center"><%#Eval("kpih_nik")%></td>
                            <td><p style="text-transform: uppercase;"><%#Eval("staff_nama")%></p></td>
                            <td><p class="small"><%#Eval("KPIH_APPVUSERTGL")%></p>
                            </td>
                            <td><p class="small"><%#Eval("KPIH_APPVHEAD")%><br />
                                <%#Eval("KPIH_APPVHEADTGL")%></p>
                            </td>
                            <td><p class="small"><%#Eval("KPIH_APPVHEAD2")%><br />
                                <%#Eval("KPIH_APPVHEADTGL2")%></p>
                            </td>
                            <td align="center"><a href="<%#"HRDPENILAIANKARYAWAN.aspx?no=" + Eval("kpih_nik")%>"><img src="img/penilaian.png" width="70px" height="60px" /></a></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
            </asp:View> 
        </asp:MultiView> 
    </div>
</asp:Content>