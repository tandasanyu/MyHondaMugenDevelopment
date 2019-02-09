<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ITBACKUP.aspx.vb" Inherits="ITBACKUP" title="Dokumen Backup Data Server" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <script src="js/jquery.min.js"></script>
	<script src="js/custom.js"></script>
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
    <asp:Label ID="LblUserName" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblAkses" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea1" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea2" Style="display:none" runat="server"></asp:Label>

    <div class="container">
         <ul class="breadcrumb">
            <li><a href="#"> <span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"> <i class="fa fa-desktop"></i></a> &nbsp <a href="#"> ISO</a> </li>
            <li class="active"><span class="glyphicon glyphicon-save"></span> &nbsp Form Backup</li>
        </ul>
        <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
            <asp:View ID="Viewerr00" runat="server">
                <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" ForeColor="Red" />
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
            <asp:View ID="View1Akses" runat="server">
                <div class="container">
                    <center>
                        <h2 style="font-family:Cooper Black;">BACKUP DATA SERVER<br />
                             (Monthly)
                        </h2>
                        <h4>005-FRM-IT.R1</h4>
                    </center>
	            </div>  
                <br /><br />
       
                <asp:Button ID="BtnMasterTabel" runat="server" Text="Tambah Data" class="button button4" />
                <br /><br />
                <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [BACKUP_NO], [BACKUP_TGLBACKUP], [BACKUP_NODISK], [BACKUP_KETERANGAN], [BACKUP_ITSTAFF], [BACKUP_TGLITSTAFF], [BACKUP_HEADIT], [BACKUP_TGLHEADIT] FROM [TRXN_BACKUP]"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailMaster" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="BACKUP_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Tanggal Backup</th>
                                <th style="text-align:center; color:white">Nomor Disk</th>
                                <th style="text-align:center; color:white">Validasi IT Staff</th>
                                <th style="text-align:center; color:white">Validasi Head IT</th>
                                <th style="text-align:center; color:white">Keterangan</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="10" runat="server">
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
                            <td><%#Eval("BACKUP_ITSTAFF")%><br />
                                <%#Eval("BACKUP_TGLITSTAFF")%>
                            </td>
                            <td><%#Eval("BACKUP_HEADIT")%><br />
                                <%#Eval("BACKUP_TGLHEADIT")%>
                            </td>
                            <td><%#Eval("BACKUP_KETERANGAN")%></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Backup Server Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Backup Server Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br />
            </asp:View> 
        </asp:MultiView> 
        <asp:MultiView ID="MultiViewNilaiProgressEntry" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
                <br />
                <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-save"></span> &nbsp <font style="color:#ffffff">Form Backup Data Server</font></div>
                        <div class="panel-body">
                            <center>
                                <h2 style="font-family:Cooper Black;">FORM BACKUP DATA SERVER<br />
                                    (MONTHLY)
                                </h2>
                                <h4>005-FRM-IT.R1</h4>
                            </center><br /><br />
	            
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label12" runat="server" Text="Tanggal Backup"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:TextBox ID="TxtBackupTgl" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" TabIndex ="13" />
                                        <asp:Label ID="lblBackupId" runat="server" Text="ID" style="display:none"></asp:Label>
                                        <asp:LinkButton ID="Button3"  runat="server" CssClass="btn btn-default" CausesValidation="False">
									        <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
								        </asp:LinkButton>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                            TargetControlID="TxtBackupTgl" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator3" runat="server"
                                            ControlExtender="MaskedEditExtender3" ControlToValidate="TxtBackupTgl" EmptyValueMessage="Date is required"
                                            InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                            EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TxtBackupTgl" PopupButtonID="Button3" />
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="LblBackupNoDisk" runat="server" Text="Nomor Disk"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtBackupNoDisk" runat="server" MaxLength="25" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label15" runat="server" Text="Keterangan"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtBackupKeterangan" runat="server" MaxLength="200" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>
                
                            <center>
                                <asp:Label ID="LblErrorSaveC" runat="server" Text="" ForeColor="Red"></asp:Label>           
                                <asp:Button ID="BtnNilaiSMSave" runat="server" Text="Simpan" class="btn btn-success" />
                            </center>
                        </div>
                    </div>
                </div><br />
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>

