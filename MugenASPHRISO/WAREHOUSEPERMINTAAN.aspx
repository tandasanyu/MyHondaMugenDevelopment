<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="WAREHOUSEPERMINTAAN.aspx.vb" Inherits="WAREHOUSEPERMINTAAN" title="Dokumen Permintaan Unit Untuk Pameran / Moving" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
	<style type="text/css">
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
            <li><a href="#"> <span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"> <i class="fa fa-desktop"></i></a> &nbsp <a href="#"> Warehouse</a> </li>
            <li class="active"><span class="glyphicon glyphicon-duplicate"></span> &nbsp Form Permintaan Unit</li>
        </ul>
        <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
            <asp:View ID="Viewerr00" runat="server">
                <asp:Label ID="lblMsgBox" runat="server" ForeColor="Red">Judul Permohonan</asp:Label>
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
            <asp:View ID="View1Akses" runat="server">
                <div class="container">
                    <center>
                        <h2 style="font-family:Cooper Black;">DATA PERMINTAAN UNIT <br />
                            UNTUK PAMERAN / MOVING
                        </h2>
                        <h4>012-FRM-WHS.R1</h4>
                    </center>
	            </div><br /><br />
       
                <asp:Button ID="BtnMasterTabel" runat="server" Text="Tambah Data" class="button button4" />
                <br /><br />
                <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [MINTA_NO], [MINTA_JNSEVENT], [MINTA_TGLEVENT], [MINTA_LOKASI], [MINTA_PJ], [MINTA_TGLTERIMA], [MINTA_TGLKEMBALI], [MINTA_TIPE], [MINTA_JENIS], [MINTA_WARNA], [MINTA_RANGKA], [MINTA_MESIN], [MINTA_PEMBUAT], [MINTA_TGLBUAT], [MINTA_DIKETAHUI], [MINTA_TGLDIKETAHUI] FROM [TRXN_PERMINTAAN]"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailMaster" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="MINTA_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped data">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Jenis Event</th>
                                <th style="text-align:center; color:white">Lokasi / Tgl Event</th>
                                <th style="text-align:center; color:white">PJ</th>
                                <th style="text-align:center; color:white">Tipe Mobil</th>
                                <th style="text-align:center; color:white">No Rangka / Mesin</th>
                                <th style="text-align:center; color:white">Tgl Serah Terima Unit</th>
                                <th style="text-align:center; color:white">Dibuat</th>
                                <th style="text-align:center; color:white">Diketahui</th>
                                <th style="text-align:center; color:white">Detail</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                            <td><p class="small"><%#Eval("MINTA_JNSEVENT")%></p></td>
                            <td><p class="small"><%#Eval("MINTA_LOKASI")%><br />
                                <%#Eval("MINTA_TGLEVENT")%></p></td>
                            <td><p class="small"><%#Eval("MINTA_PJ")%></p></td>
                            <td><p class="small"><%#Eval("MINTA_TIPE")%><br />
                                <%#Eval("MINTA_JENIS")%></p></td>
                            <td><p class="small"><%#Eval("MINTA_RANGKA")%><br />
                                <%#Eval("MINTA_MESIN")%></p></td>
                            <td><p class="small"><%#Eval("MINTA_TGLTERIMA")%></p></td>
                            <td><p class="small"><%#Eval("MINTA_PEMBUAT")%><br />
                                <%#Eval("MINTA_TGLBUAT")%></p></td>
                            <td><p class="small"><%#Eval("MINTA_DIKETAHUI")%><br />
                                <%#Eval("MINTA_TGLDIKETAHUI")%></p></td>
                             <td align="center"><a href="<%#"WAREHOUSEPERMINTAANOUTPUT.aspx?no=" + Eval("MINTA_NO")%>"><img src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Sasaran Mutu Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Sasaran Mutu Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br />
            </asp:View> 
        </asp:MultiView> 

        <asp:MultiView ID="MultiViewNilaiProgressEntry" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
                <br /><br />
                <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Permintaan Unit</font></div>
                        <div class="panel-body">
                            <center>
                                <h3 style="font-family:Blunter;">FORM PERMINTAAN UNIT <br />
                                    UNTUK PAMERAN / MOVING
                                </h3>
                                <h5>012-FRM-WHS.R0</h5>
                            </center>
	                        <br />
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label8" runat="server" Text="No"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="lblMintaNo" runat="server" Text="No"></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label7" runat="server" Text="Jenis Event"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Pameran</asp:ListItem>
                                            <asp:ListItem>Moving</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label6" runat="server" Text="Tanggal Event"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:TextBox ID="txt_TglEvent" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" TabIndex ="13" />
                                        <asp:Button ID="Button1"  Text="..."  runat="server" CausesValidation="False" class="btn btn-default" />
                    
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                            TargetControlID="txt_TglEvent" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
                                            ControlExtender="MaskedEditExtender3" ControlToValidate="txt_TglEvent" EmptyValueMessage="Date is required"
                                            InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                            EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_TglEvent" PopupButtonID="Button1" />
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label4" runat="server" Text="Lokasi Event"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="Txt_LokasiEvent" runat="server" MaxLength="15" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Penanggung Jawab"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="Txt_PenanggungJawab" runat="server" MaxLength="15" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label10" runat="server" Text="Perkiraan Tanggal Pengembalian Unit"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:TextBox ID="txt_TglKembali" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" TabIndex ="13" />
                                        <asp:Button ID="Button3"  Text="..."  runat="server" CausesValidation="False" class="btn btn-default" />
                    
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server"
                                            TargetControlID="txt_TglKembali" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator5" runat="server"
                                            ControlExtender="MaskedEditExtender3" ControlToValidate="txt_TglKembali" EmptyValueMessage="Date is required"
                                            InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                            EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_TglKembali" PopupButtonID="Button3" />
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Tipe Mobil"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Accord</asp:ListItem>
                                            <asp:ListItem>Brio</asp:ListItem>
                                            <asp:ListItem>BRV</asp:ListItem>
                                            <asp:ListItem>City</asp:ListItem>
                                            <asp:ListItem>Civic</asp:ListItem>
                                            <asp:ListItem>CRV</asp:ListItem>
                                            <asp:ListItem>CRZ</asp:ListItem>
                                            <asp:ListItem>HRV</asp:ListItem>
                                            <asp:ListItem>Jazz</asp:ListItem>
                                            <asp:ListItem>Mobilio</asp:ListItem>
                                            <asp:ListItem>Odyssey</asp:ListItem>
                                            <asp:ListItem>Freed</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="Jenis Mobil"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="txt_JnsMobil" runat="server" MaxLength="15" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label11" runat="server" Text="Warna Mobil"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="DropDownList3" runat="server" MaxLength="15" class="form-control"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label13" runat="server" Text="No Rangka"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="txt_NoRangka" runat="server" MaxLength="15" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label15" runat="server" Text="No Mesin"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="txt_NoMesin" runat="server" MaxLength="15" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label12" runat="server" Text="Tanggal Serah Terima Unit"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:TextBox ID="txt_TglTerimaUnit" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" TabIndex ="13" />
                                        <asp:Button ID="Button4"  Text="..."  runat="server" CausesValidation="False" class="btn btn-default" />
                    
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                            TargetControlID="txt_TglTerimaUnit" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator3" runat="server"
                                            ControlExtender="MaskedEditExtender3" ControlToValidate="txt_TglTerimaUnit" EmptyValueMessage="Date is required"
                                            InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                            EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_TglTerimaUnit" PopupButtonID="Button4" />
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>
                
                            <center>
                                <asp:Label ID="LblErrorSaveC" runat="server" Text="" style="color: red;"></asp:Label>
                                <asp:Button ID="BtnNilaiSMSave" runat="server" Text="Simpan" class="btn btn-primary" />
                            </center>
                        </div>
                    </div>
                </div><br />
            </asp:View>
        </asp:MultiView>    
    </div>
</asp:Content>

