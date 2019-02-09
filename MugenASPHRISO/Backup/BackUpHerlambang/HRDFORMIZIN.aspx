<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HRDFORMIZIN.aspx.vb" Inherits="HRDFORMIZIN" title="Form Izin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <script type="text/javascript" language="javascript">
		function Cover(bottom, top, ignoreSize) {
			var location = Sys.UI.DomElement.getLocation(bottom);
			top.style.position = 'absolute';
			top.style.top = location.y + 'px';
			top.style.left = location.x + 'px';
			if (!ignoreSize) {
				top.style.height = bottom.offsetHeight + 'px';
				top.style.width = bottom.offsetWidth + 'px';
			}
		}
    </script>
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

        .button2 {
            background-color: #FFC88F; 
            color: black; 
            border: 2px solid #FFC88F;
        }

        .button2:hover {
            background-color: #FF9121;
            color: white;
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

        .ModalPopupBG
        {
            background-color: #E8E8E8;
            filter: alpha(opacity=75);
            opacity: 0.7;
        }

        span.radio {
            padding: 0px;
        }

        span.radio > input[type="radio"] {
            margin: 5px 5px 7px 0px;
        }

        span.radio > label {
            float: left;
            margin-right: 10px;
            padding: 0px 15px 0px 20px;
        }
    </style>
    <script type="text/javascript">
	    $(document).ready(function(){
	        $('.data').DataTable();
	        $('.data2').DataTable();
	    });
    </script>

    <asp:Label ID="LblUserName" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="LblUserId" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="lblAkses" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="lblArea1" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="lblArea2" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtAB1" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtAB2" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtAB3" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtAB4" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtAB5" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtAB6" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtHead" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtHead2" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtNama" style="display:none;  text-transform: capitalize;" runat="server"></asp:Label>
    <div class="container">
        <ul class="breadcrumb">
            <li><a href="#"><span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"><i class="glyphicon glyphicon-user"></i></a> &nbsp <a href="#"> HRD</a> </li>
            <li class="active"><span class="glyphicon glyphicon-edit"></span> &nbsp Penilaian Karyawan </li>
        </ul>
		<asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
			<asp:View ID="Viewerr00" runat="server">
				<asp:Label ID="lblMsgBox" runat="server">Judul Permohonan</asp:Label>
			</asp:View> 
		</asp:MultiView>
        
        <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
			<asp:View ID="View0102Karyawan" runat="server">
                <div class="container">
                    <center>
                        <h2 style="font-family:Cooper Black;">Form Pengajuan Izin</h2>
                    </center>
                </div><br />
				<h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Data Diri</h3>
				<br />
			    <table class="table table-borderless" align="left">
				    <tr>
				        <td class="col-md-2"><asp:Label ID="Label66" runat="server" Text="NIK"></asp:Label></td>
			            <td class="col-md-4"><asp:Label ID="TxtStaffNIK" runat="server" Text="" class="form-control required"></asp:Label></td>
                        <td class="col-md-2"><asp:Label ID="Label9" runat="server" Text="Lokasi / Department"></asp:Label></td>
				        <td class="col-md-4"><asp:Label ID="TxtStatusKerjaTempat" runat="server" MaxLength="15" Text ="" class="form-control required"></asp:Label></td>
				    </tr>
				    <tr>
                        <td class="col-md-2"><asp:Label ID="Label8" runat="server" Text="Nama"></asp:Label></td>
				        <td class="col-md-4"><asp:Label ID="TxtStaffNama" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:Label></td>
					    <td class="col-md-2"><asp:Label ID="Label29" runat="server" Text="Jabatan"></asp:Label></td>
					    <td class="col-md-4"><asp:Label ID="TxtStatusKerjaJabatan" runat="server" MaxLength="15" Text ="" class="form-control required"></asp:Label></td>
				    </tr>
				    <tr>
                        <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Atasan"></asp:Label></td>
				        <td class="col-md-4"><asp:Label ID="lblAtasan" runat="server" Text="" class="form-control required"></asp:Label></td>
					    <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="Tahun Penilaian"></asp:Label></td>
					    <td class="col-md-4"><asp:Label ID="TahunPenilaian" runat="server" MaxLength="15" Text ="" class="form-control required"></asp:Label></td>
				    </tr>
			    </table><br />
            </asp:View>
        </asp:MultiView>
        <br />
        <hr />
<!-- DIV DATA KARYAWAN BESERTA IZIN DAN APRV NYA -->
                    <div class="col-md-6">
				        <!--<asp:Button ID="BtnAjukanIzin" runat="server"  Text="Ajukan Izin" class="button button4"/>-->
				        <br /><br />
				        <asp:SqlDataSource ID="SqlDataIzin" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
					        SelectCommand="SELECT [IZIN_NIK], [IZIN_NAMA], [IZIN_JENIS], [IZIN_APPRVSPVTGL], [IZIN_APPRVMNGTGL] FROM [DATA_IZIN]"
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				        </asp:SqlDataSource>   
                        <!-- ListView Detali Staff  form Izin-->                                   
				        <asp:ListView ID="LvDetailStaff" runat="server" DataSourceID="SqlDataIzin" DataKeyNames ="IZIN_NIK" enableviewstate="false">
					        <LayoutTemplate>
						        <table id="dataTable" class="table table-bordered striped data" align="left">
							        <thead style="background-color:#4877CF">
								        <th style="text-align:center; color:white">NIK</th>
								        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Jenis Izin</th>
                                        <th style="text-align:center; color:white">Approval SPV</th>
                                        <th style="text-align:center; color:white">Approval Manager</th>
								        <th style="text-align:center; color:white">Lihat Detail</th>
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table>
			
					        </LayoutTemplate>
				
					        <ItemTemplate>
						        <tr>
							        <td style="text-align:center"><%# Eval("IZIN_NIK") %></td>
							        <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>
                                    <td><%#Eval("IZIN_APPRVSPVTGL")%></td>
                                    <td><%#Eval("IZIN_APPRVMNGTGL")%></td>
                                    
							        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/detail.png" width="50px" height="50px" /></asp:LinkButton></td>
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>Data Karyawan Tidak diketemukan</EmptyDataTemplate> 
					        <EmptyItemTemplate>Data Karyawan Tidak diketemukan</EmptyItemTemplate>              
				        </asp:ListView>
				        <br />
                    </div>
<!-- DIV DATA KARYAWAN BESERTA IZIN DAN APRV NYA -->
        <br />
<!-- DIV FORM IZIN -->
        <div class="col-md-6">
        <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Jenis Izin</h3><br />
        <table class="table table-borderless" align="left">
            <tr>
                <td class="col-md-2">
                    <asp:Label ID="Label3" runat="server" Text="Jenis Izin"></asp:Label></td>
                <td class="col-md-4">
                    <asp:DropDownList ID="DropDownJenisiIzin" runat="server"  class="form-control required" AutoPostBack="True">
                        <asp:ListItem Value="0">Cuti</asp:ListItem>
                        <asp:ListItem Value="1">Tidak Masuk Kantor</asp:ListItem>
                        <asp:ListItem Value="2">Datang Siang</asp:ListItem>
                        <asp:ListItem Value="3">Pulang Cepat</asp:ListItem>
                    </asp:DropDownList></td>

            </tr>
            <!--<tr>
                <td class="col-md-2">&nbsp;</td>
                <td class="col-md-4">&nbsp;</td>
            </tr>
            <tr>
                <td class="col-md-2">&nbsp;</td>
                <td class="col-md-4">&nbsp;</td>
            </tr>-->
        </table>
        <!--</div>-->
        <asp:MultiView ID="MultiViewNilaiStandardEntry" runat="server" Visible="TRUE" ActiveViewIndex="0">
            <asp:View ID="ViewCuti" runat="server">
                <br /><h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Izin Cuti</h3><br />
                <table class="table table-borderless" align="left">
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label7" runat="server" Text="Tanggal Cuti"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtTglCuti1" runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:TextBox>
						    <asp:LinkButton ID="LinkButton1"  runat="server" CssClass="btn btn-default" CausesValidation="False">
							<span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
						    </asp:LinkButton> 
					        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
						        TargetControlID="TxtTglCuti1" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
						        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />                
						    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
						        ControlExtender="MaskedEditExt01" ControlToValidate="TxtTglCuti1" EmptyValueMessage="Date is required"
						        InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
						        EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
				            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtTglCuti1" PopupButtonID="LinkButton1" />                              
                        </td><td></td>
                        <td class="col-md-2">
                            <asp:Label ID="Label5" runat="server" Text="Sampai Dengan "></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtTglCuti2" runat="server"   style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
						    <asp:LinkButton ID="LinkButton2"  runat="server" CssClass="btn btn-default" CausesValidation="False">
							<span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
						    </asp:LinkButton> 
					        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
						        TargetControlID="TxtTglCuti2" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
						        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />                
						    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
						        ControlExtender="MaskedEditExt01" ControlToValidate="TxtTglCuti2" EmptyValueMessage="Date is required"
						        InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
						        EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
				            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TxtTglCuti2" PopupButtonID="LinkButton2" />  
                        </td>                   
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label4" runat="server" Text="Tahun Cuti"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtTahunCuti" runat="server"  MaxLength="4" style="width: 130px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ></asp:TextBox></td><td></td>
                        <td class="col-md-2">
                            <asp:Label ID="Label14" runat="server" Text="Saldo Cuti"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtSaldoCuti" runat="server" MaxLength="999" style="width: 130px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label6" runat="server" Text="Alasan Pengajuan Cuti"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:DropDownList ID="DropDownListCuti" runat="server"  class="form-control required">
                                <asp:ListItem Value="Libur Bersama">Cuti / Libur Bersama</asp:ListItem>
                                <asp:ListItem Value="Cuti Tahunan">Cuti Tahunan</asp:ListItem>
                                <asp:ListItem Value="Cuti Melahirkan">Cuti Melahirkan</asp:ListItem>
                                <asp:ListItem Value="Cuti Menikiah">Cuti Menikah</asp:ListItem>
                                <asp:ListItem Value="Cuti Kedukaan">Cuti Kedukaan</asp:ListItem>
                                <asp:ListItem Value="Cuti Bencana">Cuti Bencana</asp:ListItem>
                                <asp:ListItem Value="Cuti Ibadah Haji">Cuti Ibadah Haji</asp:ListItem>
                                <asp:ListItem Value="Cuti Keguguran">Cuti Keguguran</asp:ListItem>
                            </asp:DropDownList></td>
                        
                    </tr>
                </table>
                <asp:Label ID="LblErrorSaveCuti" runat="server" Text="" style="color:red"></asp:Label>
                <center><asp:Button ID="BtnSaveCuti" visible="True" runat="server" Text="Simpan Data" class="btn btn-success" /> <asp:Button ID="BtnApprv" visible="true" runat="server" Text="Approve" class="btn btn-primary" /></center>
               
            </asp:View>
            <asp:View ID="ViewTidakMasuk" runat="server">
                <br /><h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Izin Tidak Masuk Kantor</h3><br />
                <table class="table table-borderless" align="left">
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label10" runat="server" Text="Tanggal Tidak Masuk"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TglTidakMasuk1" runat="server"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox> -
					        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
						        TargetControlID="TglTidakMasuk1" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
						        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />                
						    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator3" runat="server"
						        ControlExtender="MaskedEditExt01" ControlToValidate="TglTidakMasuk1" EmptyValueMessage="Date is required"
						        InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
						        EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
				            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TglTidakMasuk1"  /> 
					        
                            <asp:TextBox ID="TglTidakMasuk2" runat="server"  style="width: 130px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"  />
					        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server"
						        TargetControlID="TglTidakMasuk2" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
						        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />                
						    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator4" runat="server"
						        ControlExtender="MaskedEditExt01" ControlToValidate="TglTidakMasuk2" EmptyValueMessage="Date is required"
						        InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
						        EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
				            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TglTidakMasuk2"  /> 
                        </td><!--<td></td>-->
                   </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label11" runat="server" Text="Alasan Tidak Masuk"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:DropDownList ID="DropDownAlasanCuti" runat="server"  class="form-control required">
                                <asp:ListItem Value="0">Sakit Surat Dokter</asp:ListItem>
                                <asp:ListItem Value="1">Sakit Potong Gaji</asp:ListItem>
                                <asp:ListItem Value="2">Ijin Potong Gaji</asp:ListItem>
                                <asp:ListItem Value="3">Ijin Potong Cuti</asp:ListItem>
                                <asp:ListItem Value="4">Sakit Potong Cuti</asp:ListItem>
                            </asp:DropDownList></td>
                   </tr>
                    <!--<tr>
                        <td class="col-md-2"></td>
                        <td class="col-md-4"></td>
                   </tr>-->
                </table>
                <asp:Button ID="Button1" visible="true" runat="server" Text="Simpan Data" class="btn btn-success" />
            </asp:View>
            <asp:View ID="ViewIzinSiang" runat="server">
                <br /><h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Izin Datang Siang</h3><br />
            </asp:View>
            <asp:View ID="ViewIzinPulang" runat="server">
                <br /><h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Izin Pulang Cepat</h3><br />
                <table class="table table-borderless" align="left">
                    <tr>
                        <td class="col-md-2"><asp:Label ID="Label12" runat="server" Text="Tanggal Izin Pulang Cepat"></asp:Label></td>
					    <td class="col-md-4"><asp:TextBox ID="TxtStaffLahirTgl" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />
						    <asp:LinkButton ID="ButtonTgl01"  runat="server" CssClass="btn btn-default" CausesValidation="False">
							    <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
						    </asp:LinkButton>
					        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExt01" runat="server"
						        TargetControlID="TxtStaffLahirTgl" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
						        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />                
						    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValid01" runat="server"
						        ControlExtender="MaskedEditExt01" ControlToValidate="TxtStaffLahirTgl" EmptyValueMessage="Date is required"
						        InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
						        EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
				            <ajaxToolkit:CalendarExtender ID="CalendarExt01" runat="server" TargetControlID="TxtStaffLahirTgl" PopupButtonID="ButtonTgl01" />
				        </td>
                            <!--<asp:TextBox ID="TextBox3" runat="server"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>-->
					    <!--<td></td>-->
                   </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label13" runat="server" Text="Alasan Keluar Kantor"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:DropDownList ID="DropDownList1" runat="server"  class="form-control required">
                                <asp:ListItem Value="0">Ke Customer</asp:ListItem>
                                <asp:ListItem Value="1">Ke Pameran</asp:ListItem>
                                <asp:ListItem Value="2">Lain-Lain</asp:ListItem>
                            </asp:DropDownList></td>
                   </tr>
                    <!--<tr>
                        <td class="col-md-2"></td>
                        <td class="col-md-4"></td>
                   </tr>-->
                </table>
                <asp:Button ID="Button2" visible="true" runat="server" Text="Simpan Data" class="btn btn-success" />
            </asp:View>
        </asp:MultiView>
        </div>   
    </div>
    <script type="text/javascript"> 

    function stopRKey(evt) { 
      var evt = (evt) ? evt : ((event) ? event : null); 
      var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null); 
      if ((evt.keyCode == 13) && (node.type=="text"))  {return false;} 
    } 

    document.onkeypress = stopRKey; 

</script>
</asp:Content>

