<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ITMAINTENANCE.aspx.vb" Inherits="ITMAINTENANCE" title="Jadwal & Hasil Maintenance Software dan Hardware" %>
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
            <li><a href="#"> <i class="fa fa-desktop"></i></a> &nbsp <a href="#"> IT</a> </li>
            <li class="active"><span class="glyphicon glyphicon-wrench"></span> &nbsp Form Maintenance</li>
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
                        <h2 style="font-family:Cooper Black;">JADWAL & HASIL MAINTENANCE <br />
                             SOFTWARE & HARDWARE</h2>
                        <h4>006-FRM-IT.R3</h4>
                    </center>
	            </div>  <br /><br />
       
                <asp:Button ID="BtnMasterTabel" runat="server" Text="Tambah Data" class="button button4" />
                <br /><br />
                <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [MAINTENANCE_ID], [MAINTENANCE_NO], [MAINTENANCE_NMPC], [MAINTENANCE_IP], [MAINTENANCE_DEPT], [MAINTENANCE_JADWAL], [MAINTENANCE_REALISASI], [MAINTENANCE_KEGIATAN], [MAINTENANCE_HASIL], [MAINTENANCE_TINDAKAN], [MAINTENANCE_VALIDASISTAFF], [MAINTENANCE_TGLVALIDASISTAFF], [MAINTENANCE_VALIDASIHEADIT], [MAINTENANCE_TGLVALIDASIHEADIT] FROM [TRXN_MAINTENANCE]"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailMaster" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="MAINTENANCE_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white" rowspan="2">No.</th>
                                <th style="text-align:center; color:white" rowspan="2">ID PC</th>
                                <th style="text-align:center; color:white" rowspan="2">IP PC</th>
                                <th style="text-align:center; color:white" rowspan="2">Nama Computer</th>
                                <th style="text-align:center; color:white" rowspan="2">Departemen</th>
                                <th style="text-align:center; color:white" colspan="2">Tanggal</th>
                                <th style="text-align:center; color:white" rowspan="2">Kegiatan</th>
                                <th style="text-align:center; color:white" rowspan="2">Hasil</th>
                                <th style="text-align:center; color:white" rowspan="2">Tindakan Perbaikan</th>
                                <th style="text-align:center; color:white" rowspan="2">Dibuat</th>
                                <th style="text-align:center; color:white" rowspan="2">Diketahui</th>
                                <th style="text-align:center; color:white" rowspan="2">Detail</th>
                            </tr>
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white">Jadwal</th>
                                <th style="text-align:center; color:white">Realisasi</th>
                            </tr>
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
                            <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                            <td><p class="small"><%#Eval("MAINTENANCE_ID")%></p></td>
                            <td><p class="small"><%#Eval("MAINTENANCE_IP")%></p></td>
                            <td><p class="small"><%#Eval("MAINTENANCE_NmPc")%></p></td>
                            <td><p class="small"><%#Eval("MAINTENANCE_DEPT")%></p></td>
                            <td><p class="small"><%#Eval("MAINTENANCE_JADWAL")%></p></td>
                            <td><p class="small"><%#Eval("MAINTENANCE_REALISASI")%></p></td>
                            <td><p class="small"><%#Eval("MAINTENANCE_KEGIATAN")%></p></td>
                            <td><p class="small"><%#Eval("MAINTENANCE_HASIL")%></p></td>
                            <td><p class="small"><%#Eval("MAINTENANCE_TINDAKAN")%></p></td>
                            <td><p class="small"><%#Eval("MAINTENANCE_VALIDASISTAFF")%><br />
                                <%#Eval("MAINTENANCE_TGLVALIDASISTAFF")%></p>
                            </td>
                            <td><p class="small"><%#Eval("MAINTENANCE_VALIDASIHEADIT")%><br />
                                <%#Eval("MAINTENANCE_TGLVALIDASIHEADIT")%></p>
                            </td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/close.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Maintenance Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Maintenance Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
            </asp:View> 
        </asp:MultiView> 

        <asp:MultiView ID="MultiViewNilaiProgressEntry" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
                <br />
                <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-wrench"></span> &nbsp <font style="color:#ffffff">Form Jadwal Maintenance Software dan Hardware</font></div>
                        <div class="panel-body">
                            <center>
                                <h2 style="font-family:Cooper Black;">FORM JADWAL MAINTENANCE <br />
                                     SOFTWARE DAN HARDWARE</h2>
                                <h4>006-FRM-IT.R3</h4>
                            </center>
	                        <br />
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label8" runat="server" Text="No"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="lblMaintenanceNo" runat="server" Text="No"></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label6" runat="server" Text="Nomor ID"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="TxtID" runat="server" class="form-control" Text=""></asp:Textbox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Nomor IP"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtNoIp" runat="server" MaxLength="15" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="Nama Computer"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtNmComputer" runat="server" MaxLength="20" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Departemen"></asp:Label></td>
                                    <td class="col-md-4">
                                         <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Accounting</asp:ListItem>
                                            <asp:ListItem>Internal Audit</asp:ListItem>
                                            <asp:ListItem>CCO</asp:ListItem>
                                            <asp:ListItem>CCO128</asp:ListItem>
                                            <asp:ListItem>GA112</asp:ListItem>
                                            <asp:ListItem>GA128</asp:ListItem>
                                            <asp:ListItem>HRD</asp:ListItem>
                                            <asp:ListItem>ISO</asp:ListItem>
                                            <asp:ListItem>IT</asp:ListItem>
                                            <asp:ListItem>Purchasing</asp:ListItem>
                                            <asp:ListItem>Sales112</asp:ListItem>
                                            <asp:ListItem>Sales128</asp:ListItem>
                                            <asp:ListItem>Service112</asp:ListItem>
                                            <asp:ListItem>Service128</asp:ListItem>
                                            <asp:ListItem>Showroom112</asp:ListItem>
                                            <asp:ListItem>Showroom128</asp:ListItem>
                                            <asp:ListItem>Warehouse</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label12" runat="server" Text="Jadwal"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:TextBox ID="TxtJadwal" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" TabIndex ="13" />
                                        <asp:LinkButton ID="Button3"  runat="server" CssClass="btn btn-default" CausesValidation="False">
									        <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
								        </asp:LinkButton>
                    
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                        TargetControlID="TxtJadwal" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator3" runat="server"
                                        ControlExtender="MaskedEditExtender3" ControlToValidate="TxtJadwal" EmptyValueMessage="Date is required"
                                        InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                        EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TxtJadwal" PopupButtonID="Button3" />
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="LblKegiatan" runat="server" Text="Kegiatan"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtKegiatan" runat="server" MaxLength="200" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>
                            <center>
                                <asp:Label ID="LblErrorSaveC" runat="server" Text="" style="color: red;"></asp:Label>
                                <asp:Button ID="BtnNilaiSMSave" runat="server" Text="Simpan" class="btn btn-success" />
                            </center>
                        </div>
                    </div>
                </div><br />
            </asp:View>
        </asp:MultiView>

         <asp:MultiView ID="MultiViewHasil" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
                <br />
                <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-wrench"></span> &nbsp <font style="color:#ffffff">Form Hasil Maintenance Software dan Hardware</font></div>
                        <div class="panel-body">
                            <center>
                                <h2 style="font-family:Cooper Black;">FORM HASIL MAINTENANCE <br />
                                     SOFTWARE DAN HARDWARE</h2>
                                <h4>006-FRM-IT.R3</h4>
                            </center>
	                        <br />
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label14" runat="server" Text="Departemen"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="lblDepartemen" runat="server" ReadOnly="true" class="form-control" Text=""></asp:Textbox> </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label15" runat="server" Text="Jadwal"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="lblJadwal" runat="server" ReadOnly="true" class="form-control" Text=""></asp:Textbox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label7" runat="server" Text="Kegiatan"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="lblKeg" runat="server" ReadOnly="true" MaxLength="200" class="form-control" Text =""></asp:Textbox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="LblHasil" runat="server" Text="Hasil"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtHasil" runat="server" MaxLength="200" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label5" runat="server" Text="Tindakan Perbaikan"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtPerbaikan" runat="server" MaxLength="200" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>
                            <center>
                                <asp:Label ID="Label20" runat="server" Text="" style="color: red;"></asp:Label>
                                <asp:Label ID="lblNO" runat="server" style="display:none" Text=""></asp:Label>
                                <asp:Button ID="BtnNilaiSMSave2" runat="server" Text="Simpan" class="btn btn-success" />
                            </center>
                        </div>
                    </div>
                </div><br />
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>

