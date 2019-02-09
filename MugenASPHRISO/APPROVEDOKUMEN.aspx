<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="APPROVEDOKUMEN.aspx.vb" Inherits="APPROVEDOKUMEN" title="Approval Dokumen" %>
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
    <asp:Label ID="LblArea1" runat="server" Style="display:none"></asp:Label>
    <asp:Label ID="lblArea2" runat="server" Style="display:none"></asp:Label>
    <asp:Label ID="Label4" runat="server" Style="display:none"></asp:Label>

    <div class="container">
        <ul class="breadcrumb">
            <li><a href="#"> <span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"> <span class="glyphicon glyphicon-globe"></span></a> &nbsp <a href="#"> ISO</a> </li>
            <li class="active"><span class="glyphicon glyphicon-check"></span> &nbsp Approval</li>
        </ul>
        <br />
        <center><h2 style="font-family:Georgia;">APPROVAL DOKUMEN<br /><br /></h2></center>
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
                    <h4 style="font-family:Georgia;">APPROVAL DOKUMEN PANDUAN MUTU<br /></h4>
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

         <!-- Approval Dibuat SOP -->
        <asp:MultiView ID="MultiViewSOP" runat="server" Visible="TRUE">
            <asp:View ID="View201" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">APPROVAL DOKUMEN STANDARD OPERASIONAL PROSEDUR (SOP)<br /></h4>
	            </div>  
                <br /><br />

                <asp:SqlDataSource ID="SqlDataSOP" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_KETERANGAN], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE  ([DOKUMEN_DIBUAT] = ? AND [DOKUMEN_TGLDIBUAT] IS NULL AND [DOKUMEN_JENIS]='B')"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="lblArea1" Name="lblArea1" PropertyName= "Text" Type="String" />            
			        </selectparameters>
                </asp:SqlDataSource>     
                                                    
                <asp:ListView ID="LvDetailSOP" runat="server" DataSourceID="SqlDataSOP" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
								<th style="text-align:center; color:white">Keterangan</th>
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
							<td><%#Eval("DOKUMEN_KETERANGAN")%><br />
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

		<!-- Approval Dibuat SOP -->
        <asp:MultiView ID="MultiViewSOP3" runat="server" Visible="TRUE">
            <asp:View ID="View20" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">APPROVAL DOKUMEN STANDARD OPERASIONAL PROSEDUR (SOP)<br /></h4>
	            </div>  
                <br /><br />

                <asp:SqlDataSource ID="SqlDataSOP4" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_KETERANGAN], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE  ([DOKUMEN_DIBUAT2] = ? AND [DOKUMEN_TGLDIBUAT2] IS NULL AND [DOKUMEN_JENIS]='B')"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="lblArea1" Name="lblArea1" PropertyName= "Text" Type="String" />            
			        </selectparameters>
                </asp:SqlDataSource>     
                                                    
                <asp:ListView ID="LvDetailSOP3" runat="server" DataSourceID="SqlDataSOP4" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
								<th style="text-align:center; color:white">Keterangan</th>
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
							<td><%#Eval("DOKUMEN_KETERANGAN")%></td>
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

        <!-- Approval Diketahui SOP -->
        <asp:MultiView ID="MultiViewSOP1" runat="server" Visible="TRUE">
            <asp:View ID="View9" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">QMR APPROVAL DOKUMEN STANDARD OPERASIONAL PROSEDUR (SOP)<br /></h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSOP1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_KETERANGAN], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='B' AND [DOKUMEN_DIKETAHUI] IS NULL AND [DOKUMEN_DIBUAT] IS NOT NULL AND [DOKUMEN_TGLDIBUAT] IS NOT NULL AND [DOKUMEN_DEPARTMENT] NOT IN ('Service','Spare part')"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailSOP1" runat="server" DataSourceID="SqlDataSOP1" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
								<th style="text-align:center; color:white">Keterangan</th>
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
							<td><%#Eval("DOKUMEN_KETERANGAN")%></td>
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

        <asp:MultiView ID="MultiViewSOP5" runat="server" Visible="TRUE">
            <asp:View ID="View23" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">QMR APPROVAL DOKUMEN STANDARD OPERASIONAL PROSEDUR (SOP) Service dan Spare Part<br /></h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSOP5SS" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_DIBUAT2], [DOKUMEN_NAMA],  [DOKUMEN_KETERANGAN], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_TGLDIBUAT2], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_DEPARTMENT] IN ('Service', 'Spare part') AND [DOKUMEN_JENIS]='B' AND [DOKUMEN_DIKETAHUI] IS NULL AND [DOKUMEN_TGLDIBUAT] IS NOT NULL AND [DOKUMEN_TGLDIBUAT2] IS NOT NULL"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailSOP5" runat="server" DataSourceID="SqlDataSOP5SS" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
								<th style="text-align:center; color:white">Keterangan</th>
                                <th style="text-align:center; color:white">Dibuat</th>
								<th style="text-align:center; color:white">Dibuat2</th>
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
							<td><%#Eval("DOKUMEN_KETERANGAN")%></td>
                            <td><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td><%#Eval("DOKUMEN_DIBUAT2")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT2")%></td>
							<td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" CssClass="btn btn-success" Text='Approve' CommandName="Select" runat="server"></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Data Approval Untuk Dokumen SOP pada Service dan Spare Part</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Data Item Approval Untuk Dokumen SOP pada Service dan Spare Part</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 
		
		<!-- Approval Diketahui SOP4 -->
        <asp:MultiView ID="MultiViewSOP4" runat="server" Visible="TRUE">
            <asp:View ID="View90" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">QMR APPROVAL DOKUMEN STANDARD OPERASIONAL PROSEDUR (SOP)<br /></h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSOP5" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_DIBUAT2], [DOKUMEN_NAMA],  [DOKUMEN_KETERANGAN], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='B' AND [DOKUMEN_DIKETAHUI] IS NULL AND [DOKUMEN_DIBUAT] IS NOT NULL AND [DOKUMEN_TGLDIBUAT] IS NOT NULL  AND [DOKUMEN_DIBUAT2] IS NULL"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailSOP4" runat="server" DataSourceID="SqlDataSOP5" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
								<th style="text-align:center; color:white">Keterangan</th>
                                <th style="text-align:center; color:white">Dibuat</th>
								<th style="text-align:center; color:white">Dibuat2</th>
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
							<td><%#Eval("DOKUMEN_KETERANGAN")%></td>
                            <td><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td><%#Eval("DOKUMEN_DIBUAT2")%></td>
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
                    <h4 style="font-family:Georgia;">DIREKSI APPROVAL DOKUMEN STANDARD OPERASIONAL PROSEDUR (SOP)<br /></h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSOP2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_KETERANGAN], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='B' AND [DOKUMEN_DISETUJUI] IS NULL AND [DOKUMEN_DIKETAHUI] IS NOT NULL"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailSOP2" runat="server" DataSourceID="SqlDataSOP2" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
								<th style="text-align:center; color:white">Keterangan</th>
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
							<td><%#Eval("DOKUMEN_KETERANGAN")%></td>
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

        <!-- Approval Dibuat Instruksi Kerja -->
        <asp:MultiView ID="MultiViewInstruksiKerja1" runat="server" Visible="TRUE">
            <asp:View ID="View21" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">APPROVAL DOKUMEN INSTRUKSI KERJA<br /></h4>
	            </div>  
                <br /><br />

                <asp:SqlDataSource ID="SqlDataInstruksiKerja1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_KETERANGAN], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE  ([DOKUMEN_DIBUAT] = ? AND [DOKUMEN_TGLDIBUAT] IS NULL AND [DOKUMEN_JENIS]='C')"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="lblArea1" Name="lblArea1" PropertyName= "Text" Type="String" />            
			        </selectparameters>
                </asp:SqlDataSource>     
                                                    
                <asp:ListView ID="LvDetailInstruksi1" runat="server" DataSourceID="SqlDataInstruksiKerja1" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
								<th style="text-align:center; color:white">Keterangan</th>
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
							<td><%#Eval("DOKUMEN_KETERANGAN")%><br />
                            <td><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
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

		<!-- Approval Dibuat Instruksi Kerja -->
        <asp:MultiView ID="MultiViewInstruksiKerja2" runat="server" Visible="TRUE">
            <asp:View ID="View22" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">APPROVAL DOKUMEN INSTRUKSI KERJA<br /></h4>
	            </div>  
                <br /><br />

                <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_KETERANGAN], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE  ([DOKUMEN_DIBUAT2] = ? AND [DOKUMEN_TGLDIBUAT2] IS NULL AND [DOKUMEN_JENIS]='C')"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="lblArea1" Name="lblArea1" PropertyName= "Text" Type="String" />            
			        </selectparameters>
                </asp:SqlDataSource>     
                                                    
                <asp:ListView ID="LvDetailInstruksi2" runat="server" DataSourceID="SqlDataSOP4" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
								<th style="text-align:center; color:white">Keterangan</th>
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
							<td><%#Eval("DOKUMEN_KETERANGAN")%></td>
                            <td><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
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

        <!-- Approval Diketahui Instruksi Kerja -->
        <asp:MultiView ID="MultiViewInstruksiKerja3" runat="server" Visible="TRUE">
            <asp:View ID="View11" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">QMR APPROVAL DOKUMEN INSTRUKSI KERJA<br /></h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataInstruksi" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='C' AND [DOKUMEN_DIKETAHUI] IS NULL AND [DOKUMEN_TGLDIBUAT] IS NOT NULL"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailInstruksi3" runat="server" DataSourceID="SqlDataInstruksi" DataKeyNames ="DOKUMEN_NO">
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
                    <EmptyDataTemplate>Tidak Ada Data Approval Untuk Dokumen Instruksi Kerja</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Data Approval Untuk Dokumen Instruksi Kerja</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 

        <!-- Approval Disetujui Instruksi Kerja -->
        <asp:MultiView ID="MultiViewInstruksiKerja4" runat="server" Visible="TRUE">
            <asp:View ID="View12" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">DIREKSI APPROVAL DOKUMEN INSTRUKSI KERJA<br /></h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataInstruksi2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DISETUJUI], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='C' AND [DOKUMEN_DISETUJUI] IS NULL AND [DOKUMEN_DIKETAHUI] IS NOT NULL"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailInstruksi4" runat="server" DataSourceID="SqlDataInstruksi2" DataKeyNames ="DOKUMEN_NO">
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
                    <h4 style="font-family:Georgia;">APPROVAL BACKUP DATA SERVER<br /></h4>
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
                    <h4 style="font-family:Georgia;">APPROVAL JADWAL & HASIL MAINTENANCE SOFTWARE DAN HARDWARE</h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataMaintenance" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [MAINTENANCE_ID], [MAINTENANCE_NO], [MAINTENANCE_NMPC], [MAINTENANCE_IP], [MAINTENANCE_DEPT], [MAINTENANCE_JADWAL], [MAINTENANCE_REALISASI], [MAINTENANCE_KEGIATAN], [MAINTENANCE_HASIL], [MAINTENANCE_TINDAKAN], [MAINTENANCE_VALIDASISTAFF], [MAINTENANCE_TGLVALIDASISTAFF] FROM [TRXN_MAINTENANCE] WHERE [MAINTENANCE_VALIDASIHEADIT] IS NULL AND [MAINTENANCE_TGLVALIDASIHEADIT] IS NULL AND [MAINTENANCE_REALISASI] IS NOT NULL AND [MAINTENANCE_HASIL] IS NOT NULL AND [MAINTENANCE_TINDAKAN] IS NOT NULL"
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
                    <h4 style="font-family:Georgia;">APPROVAL VERIFIKASI PROGRAM </h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataVerifikasi" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [VERIFIKASI_NO], [VERIFIKASI_JADWAL], [VERIFIKASI_REALISASI], [VERIFIKASI_DEPARTEMEN], [VERIFIKASI_PROGRAM], [VERIFIKASI_HASIL], [VERIFIKASI_KETERANGAN], [VERIFIKASI_VALIDASIUSER], [VERIFIKASI_TGLVALIDASIUSER] FROM [TRXN_VERIFIKASI] WHERE ([VERIFIKASI_VALIDASIUSER2] = ? AND [VERIFIKASI_VALIDASIUSER] IS NULL AND [VERIFIKASI_TGLVALIDASIUSER] IS NULL)"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                     <selectparameters>
                        <asp:ControlParameter ControlID="Label4" Name="Label4" PropertyName= "Text" Type="String" />            
			        </selectparameters>
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
                    <h4 style="font-family:Georgia;">HEAD APPROVAL SDR</h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSDR1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_JENIS], [SDRLOG_LAMPIRAN], [SDRLOG_PERMANEN], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] where ([SDRLOG_KETAHUINAMA] = ? AND [SDRLOG_KETAHUITGL] IS NULL AND [SDRLOG_JENIS] NOT in ('Login Email','Login Sistem'))"
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
                                </td>
                            <td><a href="<%#"ITSDROUTPUT.aspx?no=" + Eval("SDRLOG_NO")%>" class="btn btn-success">Lihat Secara Detail</a></td>
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
                    <h4 style="font-family:Georgia;">HEAD IT APPROVAL FORM SDR/SFR</h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSDR2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_JENIS], [SDRLOG_LAMPIRAN], [SDRLOG_PERMANEN], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] where [SDRLOG_KETAHUITGL] IS NOT NULL and [SDRLOG_KETAHUINAMA] IS NOT NULL AND [SDRLOG_SETUJUNAMA] IS NULL AND [SDRLOG_SETUJUTGl] IS NULL AND [SDRLOG_JENIS] NOT in ('Login Email','Login Sistem')"
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
                                <%#Eval("SDRLOG_PEMOHONTGL")%></td>
                          <td><a href="<%#"ITSDROUTPUT.aspx?no=" + Eval("SDRLOG_NO")%>" class="btn btn-success">Lihat Secara Detail</a></td>
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

        <!-- Approval Diuji SDR -->
        <asp:MultiView ID="MultiViewDiujiSDR" runat="server" Visible="TRUE">
            <asp:View ID="View6" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia">TEST APPROVAL SDR</h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSDR3" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_JENIS], [SDRLOG_LAMPIRAN], [SDRLOG_TGLCLOSE], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] WHERE ([SDRLOG_PEMOHONNAMA] = ? AND [SDRLOG_KETAHUITGL] IS NOT NULL and [SDRLOG_KETAHUINAMA] IS NOT NULL AND [SDRLOG_SETUJUNAMA] IS NOT NULL AND [SDRLOG_SETUJUTGl] IS NOT NULL AND [SDRLOG_UJINAMA] IS NULL AND [SDRLOG_UJITGL] IS NULL AND [SDRLOG_TGLCLOSE] IS NOT NULL AND [SDRLOG_JENIS] NOT in ('Login Email','Login Sistem'))"
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
                                <th style="text-align:center; color:white">Pemohon</th>
                                <th style="text-align:center; color:white">Target</th>
                                <th style="text-align:center; color:white">Selesai</th>
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
                            <td><%#Eval("SDRLOG_TARGETR1")%></td>
                            <td><%#Eval("SDRLOG_TGLCLOSE")%></td>
                            <td><a href="<%#"ITSDROUTPUT.aspx?no=" + Eval("SDRLOG_NO")%>" class="btn btn-success">Lihat Secara Detail</a></td>    
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

        <!-- Approval Diketahui Login -->
        <asp:MultiView ID="MultiViewDiketahuiLogin" runat="server" Visible="TRUE">
            <asp:View ID="View7" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">HEAD APPROVAL FORM LOGIN</h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataLogin1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_NMUSER], [SDRLOG_JENIS], [SDRLOG_PERMANEN], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] where ([SDRLOG_KETAHUINAMA] = ? AND [SDRLOG_KETAHUITGL] IS NULL AND [SDRLOG_JENIS] in ('Login Email','Login Sistem'))"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="lblArea2" Name="lblArea2" PropertyName= "Text" Type="String" />            
			        </selectparameters>
                </asp:SqlDataSource>                                             
                <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataLogin1" DataKeyNames ="SDRLOG_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">ID</th>
                                <th style="text-align:center; color:white">Tipe</th>
                                <th style="text-align:center; color:white">Nama User</th>
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
                            <td><%#Eval("SDRLOG_JENIS")%><br />
                               (<%#Eval("SDRLOG_TIPE")%>)</td>
                            <td><%#Eval("SDRLOG_NMUSER")%></td>
                            <td><%#Eval("SDRLOG_PEMOHONNAMA")%><br />
                                <%#Eval("SDRLOG_PEMOHONTGL")%>
                            </td>
                            <td><a href="<%#"ITLOGINOUTPUT.aspx?no=" + Eval("SDRLOG_NO")%>" class="btn btn-success">Lihat Secara Detail</a></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Approval Untuk Pengajuan Akses Login</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Approval Untuk Pengajuan Akses Login</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 
        <br />

        <!-- Approval Disetujui Login -->
        <asp:MultiView ID="MultiViewDisetujuiLogin" runat="server" Visible="TRUE">
            <asp:View ID="View8" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">HEAD IT APPROVAL FORM LOGIN</h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataLogin2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_NMUSER], [SDRLOG_JENIS], [SDRLOG_PERMANEN], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] where [SDRLOG_KETAHUITGL] IS NOT NULL and [SDRLOG_KETAHUINAMA] IS NOT NULL AND [SDRLOG_SETUJUNAMA] IS NULL AND [SDRLOG_SETUJUTGl] IS NULL AND [SDRLOG_JENIS] in ('Login Email','Login Sistem')"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataLogin2" DataKeyNames ="SDRLOG_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">ID</th>
                                <th style="text-align:center; color:white">Tipe</th>
                                <th style="text-align:center; color:white">Nama User</th>
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
                            <td><%#Eval("SDRLOG_JENIS")%><br />
                               (<%#Eval("SDRLOG_TIPE")%>)</td>
                            <td><%#Eval("SDRLOG_NMUSER")%></td>
                            <td><%#Eval("SDRLOG_PEMOHONNAMA")%><br />
                                <%#Eval("SDRLOG_PEMOHONTGL")%>
                            </td>
                            <td><a href="<%#"ITLOGINOUTPUT.aspx?no=" + Eval("SDRLOG_NO")%>" class="btn btn-success">Lihat Secara Detail</a></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Approval Untuk Data Pengajuan Akses Login</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Approval Untuk Data Pengajuan Akses Login</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
            </asp:View> 
        </asp:MultiView> 

        <!-- Approval Diuji Login -->
        <asp:MultiView ID="MultiViewDiujiLogin" runat="server" Visible="TRUE">
            <asp:View ID="View16" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia">TEST APPROVAL FORM LOGIN</h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataLogin3" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_NMUSER], [SDRLOG_JENIS], [SDRLOG_TGLCLOSE], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR] WHERE ([SDRLOG_PEMOHONNAMA] = ? AND [SDRLOG_KETAHUITGL] IS NOT NULL and [SDRLOG_KETAHUINAMA] IS NOT NULL AND [SDRLOG_SETUJUNAMA] IS NOT NULL AND [SDRLOG_SETUJUTGl] IS NOT NULL AND [SDRLOG_UJINAMA] IS NULL AND [SDRLOG_UJITGL] IS NULL AND [SDRLOG_TGLCLOSE] IS NOT NULL AND [SDRLOG_JENIS] in ('Login Email','Login Sistem'))"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="LblUserName" Name="LblUserName" PropertyName= "Text" Type="String" />            
			        </selectparameters>
                </asp:SqlDataSource>                                             
                <asp:ListView ID="ListView3" runat="server" DataSourceID="SqlDataLogin3" DataKeyNames ="SDRLOG_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">ID</th>
                                <th style="text-align:center; color:white">Tipe</th>
                                <th style="text-align:center; color:white">Nama User</th>
                                <th style="text-align:center; color:white">Pemohon</th>
                                <th style="text-align:center; color:white">Target</th>
                                <th style="text-align:center; color:white">Selesai</th>
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
                            <td><%#Eval("SDRLOG_JENIS")%><br />
                               (<%#Eval("SDRLOG_TIPE")%>)</td>
                            <td><%#Eval("SDRLOG_NMUSER")%></td>
                            <td><%#Eval("SDRLOG_PEMOHONNAMA")%><br />
                                <%#Eval("SDRLOG_PEMOHONTGL")%>
                            </td>
                            <td><%#Eval("SDRLOG_TARGETR1")%></td>
                            <td><%#Eval("SDRLOG_TGLCLOSE")%></td>
                            <td><a href="<%#"ITLOGINOUTPUT.aspx?no=" + Eval("SDRLOG_NO")%>" class="btn btn-success">Lihat Secara Detail</a></td>    
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Approval Untuk Data Pengajuan Akses Login</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Approval Untuk Data Pengajuan Akses Login</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
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
                    <h4 style="font-family:Georgia;">APPROVAL DOKUMEN LAPORAN DAN BERITA ACARA AUDIT/STOCKOPNAME</h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataBeritaAcara1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE  ([DOKUMEN_DIKETAHUI] = ? AND [DOKUMEN_JENIS]='D' AND [DOKUMEN_TGLDIKETAHUI] IS NULL)"
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
                    <h4 style="font-family:Georgia;">APPROVAL LAPORAN DAN DOKUMEN BERITA ACARA AUDIT/STOCKOPNAME</h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataDiketahuiBeritaAcara2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE ([DOKUMEN_DIKETAHUI2] = ? AND [DOKUMEN_JENIS]='D' AND [DOKUMEN_TGLDIKETAHUI2] IS NULL)"
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
                    <h4 style="font-family:Georgia;">APPROVAL DOKUMEN LAPORAN DAN BERITA ACARA AUDIT/STOCKOPNAME</h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataBeritaAcara3" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_LINK], [DOKUMEN_DIKETAHUI2], [DOKUMEN_TGLDIKETAHUI2] FROM [TRXN_DOKUMEN] WHERE  [DOKUMEN_JENIS]='D' AND [DOKUMEN_TGLDISETUJUI] IS NULL AND [DOKUMEN_DISETUJUI] IS NULL"
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

         <!-- -----------------------------------------------------------------------
          |                           Approval Warehouse                            | 
          ----------------------------------------------------------------------- -->

        <!-- Approval Permintaan Unit -->
        <asp:MultiView ID="MultiViewPermintaan" runat="server" Visible="TRUE">
            <asp:View ID="View17" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">APPROVAL PERMINTAAN UNIT</h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataPermintaan" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [MINTA_NO], [MINTA_JNSEVENT], [MINTA_TGLEVENT], [MINTA_LOKASI], [MINTA_PJ], [MINTA_TGLTERIMA], [MINTA_TGLKEMBALI], [MINTA_TIPE], [MINTA_JENIS], [MINTA_WARNA], [MINTA_RANGKA], [MINTA_MESIN], [MINTA_PEMBUAT], [MINTA_TGLBUAT], [MINTA_DIKETAHUI], [MINTA_TGLDIKETAHUI] FROM [TRXN_PERMINTAAN] WHERE [MINTA_DIKETAHUI] IS NULL AND [MINTA_TGLDIKETAHUI] IS NULL"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="ListView4" runat="server" DataSourceID="SqlDataPermintaan" DataKeyNames ="MINTA_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Jenis Event</th>
                                <th style="text-align:center; color:white">Lokasi / Tgl Event</th>
                                <th style="text-align:center; color:white">Tipe Mobil</th>
                                <th style="text-align:center; color:white">No Rangka / Mesin</th>
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
                            <td><%#Eval("MINTA_JNSEVENT")%></td>
                            <td><%#Eval("MINTA_LOKASI")%><br />
                                <%#Eval("MINTA_TGLEVENT")%></td>
                            <td><%#Eval("MINTA_TIPE")%> <%#Eval("MINTA_JENIS")%></td>
                            <td><%#Eval("MINTA_RANGKA")%> /<br />
                                <%#Eval("MINTA_MESIN")%></td>
                            <td><a href="<%#"WAREHOUSEPERMINTAANOUTPUT.aspx?no=" + Eval("MINTA_NO")%>" class="btn btn-success">Lihat Secara Detail</a></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Approval Untuk Data Permintaan Unit</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Approval Untuk Data Permintaan Unit</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 
        <br />

         <!-- -----------------------------------------------------------------------
          |                           Approval HRD                                  | 
          ----------------------------------------------------------------------- -->
        <!-- Approval Diketahui FPTK -->
        <asp:MultiView ID="MultiViewFPTK1" runat="server" Visible="TRUE">
            <asp:View ID="View18" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">HRD&GA APPROVAL FPTK</h4>
	            </div>  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataFPTK1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [PTK_ID], [PTK_JABATAN], [PTK_DEPT], [PTK_CABANG], [PTK_PEMOHON], [PTK_TGLMOHON] FROM [TRXN_PTK] where [PTK_DIKETAHUI] IS NULL AND [PTK_TGLDIKETAHUI] IS NULL"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="ListView5" runat="server" DataSourceID="SqlDataFPTK1" DataKeyNames ="PTK_ID">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">ID</th>
                                <th style="text-align:center; color:white">Jabatan</th>
                                <th style="text-align:center; color:white">Department</th>
                                <th style="text-align:center; color:white">Cabang</th>
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
                            <td><%#Eval("PTK_ID")%></td>
                            <td><%#Eval("PTK_JABATAN")%></td>
                            <td><%#Eval("PTK_DEPT")%></td>
                            <td><%#Eval("PTK_CABANG")%></td>
                            <td><%#Eval("PTK_PEMOHON")%><br />
                                <%#Eval("PTK_TGLMOHON")%>
                                </td>
                            <td><a href="<%#"HRDFPTKOUTPUT.aspx?no=" + Eval("PTK_ID")%>" class="btn btn-success">Lihat Secara Detail</a></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Approval Untuk Data FPTK</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Approval Untuk Data FPTK</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 
        <br />

        <!-- Approval Disetujui FPTK -->
        <asp:MultiView ID="MultiViewFPTK2" runat="server" Visible="TRUE">
            <asp:View ID="View19" runat="server">
                <div class="container">
                    <h4 style="font-family:Georgia;">DIREKSI APPROVAL FPTK</h4>
	            </div>  
                <br /><br />

                 <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [PTK_ID], [PTK_JABATAN], [PTK_DEPT], [PTK_CABANG], [PTK_PEMOHON], [PTK_TGLMOHON] FROM [TRXN_PTK] where [PTK_DIKETAHUI] IS NOT NULL AND [PTK_TGLDIKETAHUI] IS NOT NULL AND [PTK_DISETUJUI] IS NULL AND [PTK_TGLDISETUJUI] IS NULL" 
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="ListView7" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="PTK_ID">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped data">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">ID</th>
                                <th style="text-align:center; color:white">Jabatan</th>
                                <th style="text-align:center; color:white">Department</th>
                                <th style="text-align:center; color:white">Cabang</th>
                                <th style="text-align:center; color:white">Pemohon</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td><%#Eval("PTK_ID")%></td>
                            <td><%#Eval("PTK_JABATAN")%></td>
                            <td><%#Eval("PTK_DEPT")%></td>
                            <td><%#Eval("PTK_CABANG")%></td>
                            <td><%#Eval("PTK_PEMOHON")%><br />
                                <%#Eval("PTK_TGLMOHON")%>
                            </td>
                            <td><a href="<%#"HRDFPTKOUTPUT.aspx?no=" + Eval("PTK_ID")%>" class="btn btn-success">Lihat Secara Detail</a></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Tidak Ada Approval Untuk Data FPTK</EmptyDataTemplate> 
                    <EmptyItemTemplate>Tidak Ada Approval Untuk Data FPTK</EmptyItemTemplate>             
                </asp:ListView>
                <br /><br />
                <div style="border-bottom:2px dotted #ff0000;"></div>
                <br />
            </asp:View> 
        </asp:MultiView> 
        <br />
    </div>
</asp:Content>

