<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ITVERIFIKASI.aspx.vb" Inherits="ITVERIFIKASI" title="Dokumen Verifikasi Program" %>
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
     
    <asp:Label ID="LblUserName" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblAkses" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea1" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea2" Style="display:none" runat="server"></asp:Label>

    <div class="container">
        <ul class="breadcrumb">
            <li><a href="#"><span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"><i class="fa fa-desktop"></i></a> &nbsp <a href="#"> IT</a> </li>
            <li class="active"><span class="glyphicon glyphicon-saved"></span> &nbsp Form Verifikasi</li>
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
                        <h2 style="font-family:Cooper Black;">VERIFIKASI PROGRAM<br />
                             (Pengecekan per 1 tahun sekali)
                        </h2>
                        <h4>011-FRM-IT.R1</h4>
                    </center>
	            </div><br /><br />

                <asp:Button ID="BtnMasterTabel" runat="server" Text="Tambah Data" class="button button4" />
                <br /><br />
                <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [VERIFIKASI_NO], [VERIFIKASI_JADWAL], [VERIFIKASI_REALISASI], [VERIFIKASI_DEPARTEMEN], [VERIFIKASI_PROGRAM], [VERIFIKASI_HASIL], [VERIFIKASI_KETERANGAN], [VERIFIKASI_VALIDASIUSER], [VERIFIKASI_TGLVALIDASIUSER] FROM [TRXN_VERIFIKASI]"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailMaster" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="VERIFIKASI_NO">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered table-striped">
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white" rowspan="2">No.</th>
                                <th style="text-align:center; color:white" colspan="2">Hari/Tanggal</th>
                                <th style="text-align:center; color:white" rowspan="2">Departemen</th>
                                <th style="text-align:center; color:white" rowspan="2">Program</th>
                                <th style="text-align:center; color:white" rowspan="2">Hasil Akhir</th>
                                <th style="text-align:center; color:white" rowspan="2">Keterangan</th>
                                <th style="text-align:center; color:white"rowspan="2">Validasi User</th>
                                <th style="text-align:center; color:white" class="col-md-1" rowspan="2">Detail</th>
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
                            <td><p class="small"><%#Eval("VERIFIKASI_JADWAL")%></p></td>
                            <td><p class="small"><%#Eval("VERIFIKASI_REALISASI")%></p></td>
                            <td><p class="small"><%#Eval("VERIFIKASI_DEPARTEMEN")%></p></td>
                            <td><p class="small"><%#Eval("VERIFIKASI_PROGRAM")%></p></td>
                            <td><p class="small"><%#Eval("VERIFIKASI_HASIL")%></p></td>
                            <td><p class="small"><%#Eval("VERIFIKASI_KETERANGAN")%></p></td>
                            <td><p class="small"><%#Eval("VERIFIKASI_VALIDASIUSER")%><br />
                                <%#Eval("VERIFIKASI_TGLVALIDASIUSER")%></p>
                            </td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/close.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Verifikasi Program Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Verifikasi Program Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br />
            </asp:View> 
        </asp:MultiView> 
        <asp:MultiView ID="MultiViewNilaiProgressEntry" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
                <br />
                <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-saved"></span> &nbsp <font style="color:#ffffff">Form Jadwal Verifikasi Program</font></div>
                        <div class="panel-body">
                            <center>
                                <h2 style="font-family:Cooper Black;">FORM JADWAL VERIFIKASI PROGRAM</h2>
                                <h4>011-FRM-IT.R1</h4>
                            </center>
	                        <br />
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label12" runat="server" Text="Jadwal"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:TextBox ID="TxtJadwal" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" TabIndex ="13" />
                                        <asp:Label ID="lblVerifikasiId" runat="server" Text="ID" Style="display:none"></asp:Label>
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
                                    <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Department"></asp:Label></td>
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
                                    <td class="col-md-2"><asp:Label ID="label30" runat="server" Text="Program"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtProgram" runat="server" MaxLength="50" class="form-control" Text =""></asp:TextBox></td>
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

        <asp:MultiView ID="MultiViewHasil" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
                <br />
                <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-saved"></span> &nbsp <font style="color:#ffffff">Form Pengecekan Verifikasi Program</font></div>
                        <div class="panel-body">
                            <center>
                                <h2 style="font-family:Cooper Black;">FORM HASIL VERIFIKASI PROGRAM<br />
                                </h2>
                                <h4>011-FRM-IT.R1</h4>
                            </center>
	                        <br />
                            <table class="table table-borderless">
                                 <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label4" runat="server" Text="Departemen"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="lblDepartemen" runat="server" ReadOnly="true" class="form-control" Text=""></asp:Textbox>
                                         <asp:Label ID="Labelhead" runat="server" Text="" style="display:none"></asp:Label>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label6" runat="server" Text="Jadwal"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="lblJadwal" runat="server" ReadOnly="true" class="form-control" Text=""></asp:Textbox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label7" runat="server" Text="Program"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="lblProgram" runat="server" ReadOnly="true" MaxLength="200" class="form-control" Text =""></asp:Textbox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label15" runat="server" Text="Hasil Akhir"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtHasil" runat="server" MaxLength="200" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Keterangan"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtKeterangan" runat="server" MaxLength="200" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>

                            <center>
                                <asp:Label ID="Label14" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblID" runat="server" style="display:none" Text=""></asp:Label>
                                <asp:Button ID="BtnNilaiSMSave2" runat="server" Text="Simpan" class="btn btn-success" />
                            </center>
                        </div>
                    </div>
                </div><br />
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>


