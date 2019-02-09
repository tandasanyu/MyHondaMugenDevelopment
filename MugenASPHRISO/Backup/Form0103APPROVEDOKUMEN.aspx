<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0103APPROVEDOKUMEN.aspx.vb" Inherits="SALES_Form0104APPROVEDOKUMEN" title="Approval Dokumen" %>
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
    </style>
    <asp:Label ID="LblUserName" runat="server" Style="display:none"></asp:Label>
    <asp:Label ID="lblAkses" runat="server" Style="display:none"></asp:Label>
    <asp:Label ID="lblArea1" runat="server" Style="display:none"></asp:Label>
    <asp:Label ID="lblArea2" runat="server" Style="display:none"></asp:Label>

    <div class="container">
        <ul class="breadcrumb">
            <li><a href="#"> <span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"> <span class="glyphicon glyphicon-globe"></span></a> &nbsp <a href="#"> ISO</a> </li>
            <li class="active"><span class="glyphicon glyphicon-check"></span> &nbsp Approval</li>
        </ul>
        <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
            <asp:View ID="Viewerr00" runat="server">
                <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Judul Permohonan</asp:Label> 
            </asp:View> 
        </asp:MultiView>

        <!-- -----------------------------------------------------------------------
            |                        Approval ISO                                   | 
             ----------------------------------------------------------------------- -->

        <!-- Approval Panduan Mutu -->
        <asp:MultiView ID="MultiViewPanduanMutu" runat="server" Visible="TRUE">
            <asp:View ID="View1Akses" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia;">APPROVAL DOKUMEN PANDUAN MUTU<br /></h3>
	            </div>  
                <br />
                <asp:SqlDataSource ID="SqlDataPanduanMutu" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='A' AND [DOKUMEN_STATUS]=1 AND [DOKUMEN_DISETUJUI] IS NULL OR [DOKUMEN_DISETUJUI] =''"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailPanduanMutu" runat="server" DataSourceID="SqlDataPanduanMutu" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
                                <th style="text-align:center; color:white">Dibuat</th>
                                <th style="text-align:center; color:white">Detail Dokumen</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("DOKUMEN_NAMA")%></td>
                            <td><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Data Approval Untuk Dokumen Panduan Mutu</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Data Approval Untuk Dokumen Panduan Mutu</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 

        <!-- Approval Diketahui SOP -->
        <asp:MultiView ID="MultiViewSOP" runat="server" Visible="TRUE">
            <asp:View ID="View9" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia;">APPROVAL DOKUMEN STANDARD OPERASIONAL PROSEDUR (SOP)<br /></h3>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSOP" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='B' AND [DOKUMEN_DIKETAHUI] IS NULL"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailSOP" runat="server" DataSourceID="SqlDataSOP" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
                                <th style="text-align:center; color:white">Dibuat</th>
                                <th style="text-align:center; color:white">Detail Dokumen</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("DOKUMEN_NAMA")%></td>
                            <td><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Data Approval Untuk Dokumen SOP</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Data Approval Untuk Dokumen SOP</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 

        <!-- Approval Disetujui SOP -->
        <asp:MultiView ID="MultiViewSOP2" runat="server" Visible="TRUE">
            <asp:View ID="View10" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia;">APPROVAL DOKUMEN STANDARD OPERASIONAL PROSEDUR (SOP)<br /></h3>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSOP2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='B' AND [DOKUMEN_DISETUJUI] IS NULL AND [DOKUMEN_DIKETAHUI] IS NOT NULL"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailSOP2" runat="server" DataSourceID="SqlDataSOP2" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
                                <th style="text-align:center; color:white">Dibuat</th>
                                <th style="text-align:center; color:white">Diketahui</th>
                                <th style="text-align:center; color:white">Detail Dokumen</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("DOKUMEN_NAMA")%></td>
                            <td><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td><%#Eval("DOKUMEN_DIKETAHUI")%><br />
                                <%#Eval("DOKUMEN_TGLDIKETAHUI")%></td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Data Approval Untuk Dokumen SOP</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Data Approval Untuk Dokumen SOP</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 

        <!-- Approval Diketahui Instruksi Kerja -->
        <asp:MultiView ID="MultiViewInstruksi" runat="server" Visible="TRUE">
            <asp:View ID="View11" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia;">APPROVAL DOKUMEN INSTRUKSI KERJA<br /></h3>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataInstruksi" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='C' AND [DOKUMEN_DIKETAHUI] IS NULL"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailInstruksi" runat="server" DataSourceID="SqlDataInstruksi" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
                                <th style="text-align:center; color:white">Dibuat</th>
                                <th style="text-align:center; color:white">Detail Dokumen</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("DOKUMEN_NAMA")%></td>
                            <td><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Data Approval Untuk Dokumen Instruksi Kerja</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Data Approval Untuk Dokumen Instruksi Kerja</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 

        <!-- Approval Disetujui Instruksi Kerja -->
        <asp:MultiView ID="MultiViewInstruksi2" runat="server" Visible="TRUE">
            <asp:View ID="View12" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia;">APPROVAL DOKUMEN INSTRUKSI KERJA<br /></h3>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataInstruksi2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='C' AND [DOKUMEN_DISETUJUI] IS NULL AND [DOKUMEN_DIKETAHUI] IS NOT NULL"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailInstruksi2" runat="server" DataSourceID="SqlDataInstruksi2" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
                                <th style="text-align:center; color:white">Dibuat</th>
                                <th style="text-align:center; color:white">Diketahui</th>
                                <th style="text-align:center; color:white">Detail Dokumen</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("DOKUMEN_NAMA")%></td>
                            <td><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td><%#Eval("DOKUMEN_DIKETAHUI")%><br />
                                <%#Eval("DOKUMEN_TGLDIKETAHUI")%></td>
                            <td><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Data Approval Untuk Dokumen Instruksi Kerja</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Data Approval Untuk Dokumen Instruksi Kerja</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 

       <!-- -----------------------------------------------------------------------
           |                        Approval IT                                    | 
            ----------------------------------------------------------------------- -->

        <!-- Approval Backup -->
        <asp:MultiView ID="MultiViewBackup" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia;">APPROVAL BACKUP DATA SERVER<br /></h3>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataBackup" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [BACKUP_NO], [BACKUP_TGLBACKUP], [BACKUP_NODISK], [BACKUP_KETERANGAN], [BACKUP_ITSTAFF], [BACKUP_TGLITSTAFF] FROM [TRXN_BACKUP] WHERE [BACKUP_TGLHEADIT] IS NULL AND [BACKUP_HEADIT] IS NULL "
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailBackup" runat="server" DataSourceID="SqlDataBackup" DataKeyNames ="BACKUP_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Tanggal Backup</th>
                                <th style="text-align:center; color:white">Nomor Disk</th>
                                <th style="text-align:center; color:white">Keterangan</th>
                                <th style="text-align:center; color:white">Validasi IT Staff</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("BACKUP_TGLBACKUP")%></td>
                            <td><%#Eval("BACKUP_NODISK")%></td>
                            <td><%#Eval("BACKUP_KETERANGAN")%></td>
                            <td><%#Eval("BACKUP_ITSTAFF")%><br />
                                <%#Eval("BACKUP_TGLITSTAFF")%>
                            </td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Data Approval Untuk Data Backup</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Data Approval Untuk Data Backup</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br /> 
            </asp:View> 
        </asp:MultiView> 
        <br />
        
        <!-- Approval Maintenance -->
        <asp:MultiView ID="MultiViewMaintenance" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia;">APPROVAL JADWAL & HASIL MAINTENANCE SOFTWARE DAN HARDWARE</h3>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataMaintenance" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [MAINTENANCE_ID], [MAINTENANCE_NO], [MAINTENANCE_NMPC], [MAINTENANCE_IP], [MAINTENANCE_DEPT], [MAINTENANCE_JADWAL], [MAINTENANCE_REALISASI], [MAINTENANCE_KEGIATAN], [MAINTENANCE_HASIL], [MAINTENANCE_TINDAKAN], [MAINTENANCE_VALIDASISTAFF], [MAINTENANCE_TGLVALIDASISTAFF] FROM [TRXN_MAINTENANCE] WHERE [MAINTENANCE_VALIDASIHEADIT] IS NULL AND [MAINTENANCE_TGLVALIDASIHEADIT] IS NULL "
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailMaintenance" runat="server" DataSourceID="SqlDataMaintenance" DataKeyNames ="MAINTENANCE_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white" rowspan="2">No.</th>
                                <th style="text-align:center; color:white" rowspan="2">ID</th>
                                <th style="text-align:center; color:white" rowspan="2">Nomor IP</th>
                                <th style="text-align:center; color:white" rowspan="2">Nama Computer</th>
                                <th style="text-align:center; color:white" rowspan="2">Departemen</th>
                                <th style="text-align:center; color:white" colspan="2">Tanggal</th>
                                <th style="text-align:center; color:white" rowspan="2">Kegiatan</th>
                                <th style="text-align:center; color:white" rowspan="2">Hasil</th>
                                <th style="text-align:center; color:white" rowspan="2">Tindakan Perbaikan</th>
                                <th style="text-align:center; color:white" rowspan="2">Dibuat</th>
                                <th style="text-align:center; color:white" rowspan="2" class="col-md-1"></th>
                            </tr>
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white">Jadwal</th>
                                <th style="text-align:center; color:white">Realisasi</th>
                            </tr>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("MAINTENANCE_ID")%></td>
                            <td><%#Eval("MAINTENANCE_IP")%></td>
                            <td><%#Eval("MAINTENANCE_NmPc")%></td>
                            <td><%#Eval("MAINTENANCE_DEPT")%></td>
                            <td><%#Eval("MAINTENANCE_JADWAL")%></td>
                            <td><%#Eval("MAINTENANCE_REALISASI")%></td>
                            <td><%#Eval("MAINTENANCE_KEGIATAN")%></td>
                            <td><%#Eval("MAINTENANCE_HASIL")%></td>
                            <td><%#Eval("MAINTENANCE_TINDAKAN")%></td>
                            <td><%#Eval("MAINTENANCE_VALIDASISTAFF")%><br />
                                <%#Eval("MAINTENANCE_TGLVALIDASISTAFF")%>
                            </td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Data Approval Untuk Data Maintenance</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Data Approval Untuk Data Maintenance</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView>
        
        <!-- Approval Verifikasi -->
        <asp:MultiView ID="MultiViewVerifikasi" runat="server" Visible="TRUE">
            <asp:View ID="View3" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia;">APPROVAL VERIFIKASI PROGRAM </h3>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataVerifikasi" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [VERIFIKASI_NO], [VERIFIKASI_JADWAL], [VERIFIKASI_REALISASI], [VERIFIKASI_DEPARTEMEN], [VERIFIKASI_PROGRAM], [VERIFIKASI_HASIL], [VERIFIKASI_KETERANGAN], [VERIFIKASI_VALIDASIUSER], [VERIFIKASI_TGLVALIDASIUSER] FROM [TRXN_VERIFIKASI] WHERE [VERIFIKASI_VALIDASIUSER] IS NULL AND [VERIFIKASI_TGLVALIDASIUSER] IS NULL "
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailVerifikasi" runat="server" DataSourceID="SqlDataVerifikasi" DataKeyNames ="VERIFIKASI_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                             <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white" rowspan="2">No.</th>
                                <th style="text-align:center; color:white" colspan="2">Hari/Tanggal</th>
                                <th style="text-align:center; color:white" rowspan="2">Departemen</th>
                                <th style="text-align:center; color:white" rowspan="2">Program</th>
                                <th style="text-align:center; color:white" rowspan="2">Hasil Akhir</th>
                                <th style="text-align:center; color:white" rowspan="2">Keterangan</th>
                                <th style="text-align:center; color:white" class="col-md-1" rowspan="2">Detail</th>
                            </tr>
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white">Jadwal</th>
                                <th style="text-align:center; color:white">Realisasi</th>
                            </tr>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("VERIFIKASI_JADWAL")%></td>
                            <td><%#Eval("VERIFIKASI_REALISASI")%></td>
                            <td><%#Eval("VERIFIKASI_DEPARTEMEN")%></td>
                            <td><%#Eval("VERIFIKASI_PROGRAM")%></td>
                            <td><%#Eval("VERIFIKASI_HASIL")%></td>
                            <td><%#Eval("VERIFIKASI_KETERANGAN")%></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Data Approval Untuk Verifikasi Program</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Data Approval Untuk Verifikasi Program</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br /> 
            </asp:View> 
        </asp:MultiView> 

        <!-- Approval Diketahui SDR -->
        <asp:MultiView ID="MultiViewDiketahuiSDR" runat="server" Visible="TRUE">
            <asp:View ID="View4" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia;">APPROVAL SDR DIKETAHUI<br /></h3>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSDR1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_JENIS], [SDRLOG_PERMANEN], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] where ([SDRLOG_KETAHUINAMA] = ? AND [SDRLOG_KETAHUITGL] IS NULL)"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="lblArea2" Name="lblArea2" PropertyName= "Text" Type="String" />            
			        </selectparameters>
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailDiketahuiSDR" runat="server" DataSourceID="SqlDataSDR1" DataKeyNames ="SDRLOG_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">ID</th>
                                <th style="text-align:center; color:white">Jenis</th>
                                <th style="text-align:center; color:white">Tujuan</th>
                                <th style="text-align:center; color:white">Pemohon</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("SDRLOG_NO")%></td>
                            <td><%#Eval("SDRLOG_JENIS")%></td>
                            <td><%#Eval("SDRLOG_TUJUAN")%></td>
                            <td><%#Eval("SDRLOG_PEMOHONNAMA")%><br />
                                <%#Eval("SDRLOG_PEMOHONTGL")%>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Approval Untuk Data SDR</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Approval Untuk Data SDR</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 
        <br />

        <!-- Approval Disetujui SDR -->
        <asp:MultiView ID="MultiViewDisetujuiSDR" runat="server" Visible="TRUE">
            <asp:View ID="View5" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia;">APPROVAL SDR DISETUJUI<br /></h3>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSDR2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_JENIS], [SDRLOG_PERMANEN], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] where [SDRLOG_KETAHUITGL] IS NOT NULL and [SDRLOG_KETAHUINAMA] IS NOT NULL AND [SDRLOG_SETUJUNAMA] IS NULL AND [SDRLOG_SETUJUTGl] IS NULL"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailDisetujuiSDR" runat="server" DataSourceID="SqlDataSDR2" DataKeyNames ="SDRLOG_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">ID</th>
                                <th style="text-align:center; color:white">Jenis</th>
                                <th style="text-align:center; color:white">Tujuan</th>
                                <th style="text-align:center; color:white">Pemohon</th>
                                <th style="text-align:center; color:white">Diketahui</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("SDRLOG_NO")%></td>
                            <td><%#Eval("SDRLOG_JENIS")%></td>
                            <td><%#Eval("SDRLOG_TUJUAN")%></td>
                            <td><%#Eval("SDRLOG_PEMOHONNAMA")%><br />
                                <%#Eval("SDRLOG_PEMOHONTGL")%>
                            </td>
                            <td><%#Eval("SDRLOG_KETAHUINAMA")%><br />
                                <%#Eval("SDRLOG_KETAHUITGL")%>
                            </td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Approval Untuk Data SDR</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Approval Untuk Data SDR</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 
        <br />

        <!-- Approval Disetujui SDR -->
        <asp:MultiView ID="MultiViewDisetujuiSDR2" runat="server" Visible="TRUE">
            <asp:View ID="View7" runat="server">
                <br /><br />
                 <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Pengecekan Verifikasi Program</font></div>
                        <div class="panel-body">
                            <center>
                                <h3 style="font-family:Blunter;">FORM SYSTEM DEVELOPMENT/FAULT REQUEST<br />
                                    (SDR/FR)
                                </h3>
                                <h5>001-FRM-IT.R2</h5>
                            </center>
	                        <br /><br />
                            <table class="table table-borderless">
                               <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label8" runat="server" Text="ID"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="lblSDRId" runat="server"></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Jenis"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="LblJns" runat="server"></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label9" runat="server" Text="Pemohon" ForeColor="Black"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="LblPemohon" runat="server"></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label5" runat="server" Text="Tujuan" ForeColor="Black"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="LblTujuan" runat="server"></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label7" runat="server" Text="Detail" ForeColor="Black"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="LblDetail" runat="server"></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label13" runat="server" Text="Tanggal Estimasi selesai"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:TextBox ID="TxtSDREstimasiTgl" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"/>
                                        <asp:Button ID="Button4"  Text="..."  runat="server" CausesValidation="False" class="btn btn-default" />
                    
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server"
                                        TargetControlID="TxtSDREstimasiTgl" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator4" runat="server"
                                        ControlExtender="MaskedEditExtender4" ControlToValidate="TxtSDREstimasiTgl" EmptyValueMessage="Date is required"
                                        InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                        EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TxtSDREstimasiTgl" PopupButtonID="Button4" />
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>
                
                            <center>
                                <asp:Label ID="LblErrorSaveC" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:Button ID="BtnNilaiSMSave" runat="server" Text="Simpan" class="btn btn-primary" /> 
                            </center>
                        </div>
                    </div>
                </div>
                <br />
            </asp:View>
        </asp:MultiView>

         <!-- Approval Diuji SDR -->
        <asp:MultiView ID="MultiViewDiujiSDR" runat="server" Visible="TRUE">
            <asp:View ID="View6" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia">APPROVAL SDR DIUJI<br /></h3>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSDR3" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_JENIS], [SDRLOG_TGLCLOSE], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] WHERE ([SDRLOG_PEMOHONNAMA] = ? AND [SDRLOG_KETAHUITGL] IS NOT NULL and [SDRLOG_KETAHUINAMA] IS NOT NULL AND [SDRLOG_SETUJUNAMA] IS NOT NULL AND [SDRLOG_SETUJUTGl] IS NOT NULL AND [SDRLOG_UJINAMA] IS NULL AND [SDRLOG_UJITGL] IS NULL AND [SDRLOG_TGLCLOSE] IS NOT NULL)"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="LblUserName" Name="LblUserName" PropertyName= "Text" Type="String" />            
			        </selectparameters>
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailDiujiSDR" runat="server" DataSourceID="SqlDataSDR3" DataKeyNames ="SDRLOG_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">ID</th>
                                <th style="text-align:center; color:white">Jenis</th>
                                <th style="text-align:center; color:white">Tujuan</th>
                                <th style="text-align:center; color:white">Target</th>
                                <th style="text-align:center; color:white">Selesai</th>
                                <th style="text-align:center; color:white">Pemohon</th>
                                <th style="text-align:center; color:white">Diketahui</th>
                                <th style="text-align:center; color:white">Disetujui</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("SDRLOG_NO")%></td>
                            <td><%#Eval("SDRLOG_JENIS")%></td>
                            <td><%#Eval("SDRLOG_TUJUAN")%></td>
                            <td><%#Eval("SDRLOG_TARGETR1")%></td>
                            <td><%#Eval("SDRLOG_TGLCLOSE")%></td>
                            <td><%#Eval("SDRLOG_PEMOHONNAMA")%><br />
                                <%#Eval("SDRLOG_PEMOHONTGL")%>
                            </td>
                            <td><%#Eval("SDRLOG_KETAHUINAMA")%><br />
                                <%#Eval("SDRLOG_KETAHUITGL")%>
                            </td>
                            <td><%#Eval("SDRLOG_SETUJUNAMA")%><br />
                                <%#Eval("SDRLOG_SETUJUTGL")%>
                            </td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Approval Untuk Data SDR</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Approval Untuk Data SDR</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 
        <br />

        <!-- Approval Diujui SDR -->

         <asp:MultiView ID="MultiViewDiujiSDR2" runat="server" Visible="TRUE">
            <asp:View ID="View8" runat="server">
                <br /><br />
                 <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Pengecekan Verifikasi Program</font></div>
                        <div class="panel-body">
                            <center>
                                <h3 style="font-family:Bookman Old Style;">FORM SYSTEM DEVELOPMENT/FAULT REQUEST<br />
                                    (SDR/FR) DIUJI
                                </h3>
                                <h5>001-FRM-IT.R2</h5>
                            </center>
	                        <br /><br />
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="ID"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="lblSDRId1" runat="server"></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label4" runat="server" Text="Jenis"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="lblJns1" runat="server"></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Tujuan"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="lblTujuan1" runat="server"></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label6" runat="server" Text="Detail"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="lblDetail1" runat="server"></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label18" runat="server" Text="Status"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="DropDownList3" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Puas</asp:ListItem>
                                            <asp:ListItem>Tidak Puas</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label19" runat="server" Text="Catatan"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtSDRCatatan" runat="server" MaxLength="200" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>
                
                            <center>
                                <asp:Label ID="Label21" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:Button ID="BtnNilaiSMSave2" runat="server" Text="Simpan" class="btn btn-primary" />  
                            </center>
                        </div>
                    </div>
                </div>
                <br />
            </asp:View>
        </asp:MultiView>

         <!-- -----------------------------------------------------------------------
             |                           Approval Audit                              | 
              ----------------------------------------------------------------------- -->

        <!-- Approval Diketahui1 Berita Acara -->
        <asp:MultiView ID="MultiViewBeritaAcara1" runat="server" Visible="TRUE">
            <asp:View ID="View13" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia;">APPROVAL DOKUMEN LAPORAN DAN BERITA ACARA AUDIT/STOCKOPNAME</h3>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataBeritaAcara1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE  ([DOKUMEN_DIKETAHUI] = ? AND [DOKUMEN_JENIS]='E' AND [DOKUMEN_TGLDIKETAHUI] IS NULL)"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="lblArea1" Name="lblArea1" PropertyName= "Text" Type="String" />            
			        </selectparameters>
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailDiketahuiBeritaAcara" runat="server" DataSourceID="SqlDataBeritaAcara1" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
                                <th style="text-align:center; color:white">Dibuat</th>
                                <th style="text-align:center; color:white">Lihat</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("DOKUMEN_NAMA")%></td>
                            <td><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Data Approval Untuk Dokumen Berita Acara</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Data Approval Untuk Dokumen Berita Acara</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 

         <!-- Approval Diketahui2 Berita Acara -->
        <asp:MultiView ID="MultiViewBeritaAcara2" runat="server" Visible="TRUE">
            <asp:View ID="View15" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia;">APPROVAL LAPORAN DAN DOKUMEN BERITA ACARA AUDIT/STOCKOPNAME</h3>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataDiketahuiBeritaAcara2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE ([DOKUMEN_DIKETAHUI2] = ? AND [DOKUMEN_JENIS]='E' AND [DOKUMEN_TGLDIKETAHUI2] IS NULL)"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="lblArea1" Name="lblArea1" PropertyName= "Text" Type="String" />            
			        </selectparameters>
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailDiketahui2BeritaAcara" runat="server" DataSourceID="SqlDataDiketahuiBeritaAcara2" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
                                <th style="text-align:center; color:white">Dibuat</th>
                                <th style="text-align:center; color:white">Diketahui I</th>
                                <th style="text-align:center; color:white">Lihat</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("DOKUMEN_NAMA")%></td>
                            <td><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td><%#Eval("DOKUMEN_DIKETAHUI")%><br />
                                <%#Eval("DOKUMEN_TGLDIKETAHUI")%></td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Data Approval Untuk Dokumen Berita Acara</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Data Approval Untuk Dokumen Berita Acara</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView>

        <!-- Approval Disetujui Berita Acara -->
        <asp:MultiView ID="MultiViewBeritaAcara3" runat="server" Visible="TRUE">
            <asp:View ID="View14" runat="server">
                <div class="container">
                    <h3 style="font-family:Georgia;">APPROVAL DOKUMEN LAPORAN DAN BERITA ACARA AUDIT/STOCKOPNAME</h3>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataBeritaAcara3" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK], [DOKUMEN_DIKETAHUI2], [DOKUMEN_TGLDIKETAHUI2] FROM [TRXN_DOKUMEN] WHERE  [DOKUMEN_JENIS]='E' AND [DOKUMEN_TGLDISETUJUI] IS NULL AND [DOKUMEN_DISETUJUI] IS NULL"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailDisetujuiBeritaAcara" runat="server" DataSourceID="SqlDataBeritaAcara3" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
                                <th style="text-align:center; color:white">Dibuat</th>
                                <th style="text-align:center; color:white">Diketahui I</th>
                                <th style="text-align:center; color:white">Diketahui II</th>
                                <th style="text-align:center; color:white">Lihat</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("DOKUMEN_NAMA")%></td>
                            <td><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td><%#Eval("DOKUMEN_DIKETAHUI")%><br />
                                <%#Eval("DOKUMEN_TGLDIKETAHUI")%></td>
                            <td><%#Eval("DOKUMEN_DIKETAHUI2")%><br />
                                <%#Eval("DOKUMEN_TGLDIKETAHUI2")%></td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Data Approval Untuk Dokumen SOP</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Data Approval Untuk Dokumen SOP</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 
    </div>
</asp:Content>

