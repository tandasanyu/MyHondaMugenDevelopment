<%@ Page Language="VB" MasterPageFile ="~/MasterPage.master"  AutoEventWireup="false" CodeFile="Form0101HRD.aspx.vb" Inherits="Default2" %>
<%@ MasterType virtualpath = "~/MasterPage.master"  %>
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
    
    <asp:Label ID="LblUserName" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="LblUserId" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="lblAkses" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="lblArea1" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="lblArea2" style="display:none;" runat="server"></asp:Label>

    <div class="container">
        <ul class="breadcrumb">
            <li><a href="#"><span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"><i class="fa fa-desktop"></i></a> &nbsp <a href="#"> IT</a> </li>
            <li class="active"><span class="glyphicon glyphicon-user"></span> &nbsp Form Verifikasi</li>
        </ul>
		<asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
			<asp:View ID="Viewerr00" runat="server">
				<asp:Label ID="lblMsgBox" runat="server">Judul Permohonan</asp:Label>
			</asp:View> 
		</asp:MultiView>
		<asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
			<asp:View ID="View0101Tabel" runat="server">
                <div class="container">
                    <center>
                        <h2 style="font-family:Cooper Black;">DATA KARYAWAN</h2>
                    </center>
	            </div><br /><br />
				<div class="form-horizontal">
					<div class="form-group">
						<asp:Label ID="LabelNIK" class="control-label col-sm-2" runat="server">Nomor Induk Karyawan</asp:Label>
						<div class="col-sm-4">
							<asp:TextBox ID="TxtCariNIK" runat="server" class="form-control required"></asp:TextBox>	
						</div>
					</div>

					<div class="form-group">
						<asp:Label ID="Label22" class="control-label col-sm-2" runat="server">Nama Karyawan</asp:Label>
						<div class="col-sm-4">
							<asp:TextBox ID="TxtCariNama" runat="server" class="form-control required"></asp:TextBox>	
						</div>
					</div>

					<div class="form-group" id="Div2" runat="server">
						<div class="col-md-5"></div>
						<div class="col-sm-2">
							<asp:Button ID="BtnMasterTabel" runat="server"  Text="Cari" />
						</div>
					</div>
				</div>
				<br />
				<asp:Button ID="Button40" runat="server"  Text="Tambah Karyawan" class="button button4"/>
				<br /><br />
				<asp:SqlDataSource ID="SqlDataSTaff" runat="server"
					ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
					SelectCommand="SELECT [STAFF_NIK], [STAFF_NAMA], [STAFF_STATUSKERJALOKASI], [STAFF_STATUSKERJADIVISI], [STAFF_STATUSKERJADEPT] FROM [DATA_STAFF] 
								   WHERE [STAFF_NIK] LIKE '%' + ? + '%' OR [STAFF_NAMA] LIKE '%' + ? + '%'"
					ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
					<SelectParameters>
						<asp:ControlParameter ControlID="TxtCariNIK"   Name="STAFF_NIK"   PropertyName="Text" Type="String" DefaultValue="%" />            
						<asp:ControlParameter ControlID="TxtCariNama"  Name="STAFF_NAMA"  PropertyName="Text" Type="String" DefaultValue="%" />            
					</SelectParameters>
				</asp:SqlDataSource>                                     
				<asp:ListView ID="LvDetailStaff" runat="server" DataSourceID="SqlDataSTaff" DataKeyNames ="STAFF_NIK" enableviewstate="false">
					<LayoutTemplate>
						<table id="table-a" class="table table-bordered striped" align="left">
							<thead style="background-color:#4877CF">
								<th style="text-align:center; color:white">NIK</th>
								<th style="text-align:center; color:white">Nama</th>
								<th style="text-align:center; color:white">Lokasi</th>
								<th style="text-align:center; color:white">Divisi</th>
								<th style="text-align:center; color:white">Departemen</th>
								<th style="text-align:center; color:white">Lihat Detail</th>
							</thead>
							<asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						</table>
			
						<asp:DataPager ID="dpBerita" PageSize="20" runat="server">
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
							<td style="text-align:center"><%# Eval("STAFF_NIK") %></td>
							<td><%#Eval("STAFF_NAMA")%></td>
							<td><%#Eval("STAFF_STATUSKERJALOKASI")%></td>
							<td><%#Eval("STAFF_STATUSKERJADIVISI")%></td>
							<td><%#Eval("STAFF_STATUSKERJADEPT")%></td>
							<td style="text-align:center">
							   <asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/detail.png" width="50px" height="50px" /></asp:LinkButton></td>
							</td>
						</tr>
					</ItemTemplate>
					<EmptyDataTemplate>Data Karyawan Tidak diketemukan</EmptyDataTemplate> 
					<EmptyItemTemplate>Data Karyawan Tidak diketemukan</EmptyItemTemplate>              
				</asp:ListView>
				<br />
			</asp:View> 
			<asp:View ID="View0102Karyawan" runat="server">
				<h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Data Diri</h3>
				<br />
			    <table class="table table-borderless" align="left">
				    <tr>
				        <td class="col-md-2"><asp:Label ID="Label66" runat="server" Text="NIK"></asp:Label></td>
			            <td class="col-md-4">
					        <asp:TextBox ID="TxtStaffNIK" runat="server" MaxLength="10" Text ="" class="form-control required"></asp:TextBox>
					        <asp:Label ID="lblStaffNIK" runat="server" Text="462" Visible="false"></asp:Label>
				        </td>
					    <td class="col-md-2"><asp:Label ID="Label8" runat="server" Text="No. Handphone"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStaffNoHP" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:TextBox></td>
				    </tr>
				    <tr>
					    <td class="col-md-2"><asp:Label ID="Label29" runat="server" Text="Nama"></asp:Label></td>
					    <td class="col-md-4"><asp:TextBox ID="TxtStaffNama" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:TextBox></td>
				        <td class="col-md-2"><asp:Label ID="Label9" runat="server" Text="Telepon Rumah"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStaffNoTelepon" runat="server" MaxLength="15" Text ="" class="form-control required"></asp:TextBox></td>
				    </tr>
			        <tr>
				        <td class="col-md-2"><asp:Label ID="Label39" runat="server" Text="Tempat/Tanggal Lahir"></asp:Label></td>
					    <td class="col-md-4"><asp:TextBox ID="TxtStaffLahirTmp" runat="server" MaxLength="20" Text ="" style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox> / 
					        <asp:TextBox ID="TxtStaffLahirTgl" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />
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
				        <td class="col-md-2"><asp:Label ID="Label10" runat="server" Text="Nomor Kontak Darurat"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStaffNoContact" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:TextBox></td>
			        </tr>
			        <tr>
			            <td class="col-md-2"><asp:Label ID="Label32" runat="server" Text="Status Nikah"></asp:Label></td>
				        <td class="col-md-4">
				            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control required">
                                <asp:ListItem></asp:ListItem>
					            <asp:ListItem>TK</asp:ListItem>
						        <asp:ListItem>TK1</asp:ListItem>
						        <asp:ListItem>K0</asp:ListItem>
						        <asp:ListItem>K1</asp:ListItem>
						        <asp:ListItem>K2</asp:ListItem>
						        <asp:ListItem>K3</asp:ListItem>
                                <asp:ListItem>K4</asp:ListItem>
                                <asp:ListItem>S</asp:ListItem>
                                <asp:ListItem>S1</asp:ListItem>
                                <asp:ListItem>S2</asp:ListItem>
					        </asp:DropDownList>
			            </td>
				        <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="No. KTP"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStaffNoKtp" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:TextBox></td>       
				    </tr>
			        <tr>
				        <td class="col-md-2"><asp:Label ID="Label40" runat="server" Text="Alamat"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStaffJalan" runat="server" MaxLength="80" Text ="" class="form-control required"></asp:TextBox></td>
					    <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Jenis/No. SIM"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStaffSIMType" runat="server" MaxLength="2" TabIndex ="7" Text ="" style="width: 145px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox> /
					        <asp:TextBox ID="TxtStaffSIMNomor" runat="server" MaxLength="20" TabIndex ="7" Text ="" style="width: 145px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
				        </td>    
			        </tr>
				    <tr>
				        <td class="col-md-2"><asp:Label ID="Label41" runat="server" Text="RT/RW"></asp:Label></td>
				        <td class="col-md-4">
				            <asp:TextBox ID="TxtStaffRT" runat="server" MaxLength="3" Text ="" style="width: 145px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox> /
					        <asp:TextBox ID="TxtStaffRW" runat="server" MaxLength="3" Text ="" style="width: 145px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
				        </td>
			            <td class="col-md-2"><asp:Label ID="Label6" runat="server" Text="NPWP"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStaffNPWP" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:TextBox></td>
			        </tr>
			        <tr>
				        <td class="col-md-2"><asp:Label ID="Label90" runat="server" Text="Kelurahan"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStaffKel" runat="server" MaxLength="25" Text ="" class="form-control required"></asp:TextBox></td>
				        <td class="col-md-2"><asp:Label ID="Label7" runat="server" Text="No. Rekening BCA"></asp:Label></td>
			            <td class="col-md-4"><asp:TextBox ID="TxtStaffBCA" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:TextBox></td>
				    </tr>
			        <tr>
				        <td class="col-md-2"><asp:Label ID="Label92" runat="server" Text="Kabupaten/Kotamadya"></asp:Label></td>
			            <td class="col-md-4"><asp:TextBox ID="TxtStaffKota" runat="server" MaxLength="25" Text ="" class="form-control required"></asp:TextBox></td>
			            <td class="col-md-2"><asp:Label ID="Label4" runat="server" Text="No. BPJS Ketenagakerjaan"></asp:Label></td>
		                <td class="col-md-4"><asp:TextBox ID="TxtStaffBPJSKerja" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:TextBox></td>  
			        </tr>
			        <tr>
					    <td class="col-md-2"><asp:Label ID="Label93" runat="server" Text="Kode Pos"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStaffKodePos" runat="server" MaxLength="5" Text ="" class="form-control required"></asp:TextBox></td>
				        <td class="col-md-2"><asp:Label ID="Label5" runat="server" Text="No. BPJS Kesehatan"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStaffBPJSSehat" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:TextBox></td>
				    </tr>
			        <tr>
				        <td><asp:Label ID="Label1" runat="server" Text="Email" ></asp:Label></td>
				        <td><asp:TextBox ID="TxtStaffEmail" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
				    </tr>
			    </table>
		        <br />
			    <hr />
			    <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-briefcase"></span> Data Pekerjaan</h3>
			    <br />
			    <table class="table table-borderless" align="left">
			        <tr> 
				        <td class="col-md-2"><asp:Label ID="Label31" runat="server" Text="Tanggal Masuk kerja"></asp:Label></td>
					    <td class="col-md-4">
					        <asp:TextBox ID="TxtStatusKerjaMasuk" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />
					        <asp:LinkButton ID="ButtonTgl02"  runat="server" CssClass="btn btn-default" CausesValidation="False">
						        <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
						    </asp:LinkButton>
						    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExt02" runat="server"
						        TargetControlID="TxtStatusKerjaMasuk" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
						        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
								<ajaxToolkit:MaskedEditValidator ID="MaskedEditValid02" runat="server"
								ControlExtender="MaskedEditExt02" ControlToValidate="TxtStatusKerjaMasuk" EmptyValueMessage="Date is required"
								InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
								EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
								<ajaxToolkit:CalendarExtender ID="CalendarExt02" runat="server" TargetControlID="TxtStatusKerjaMasuk" PopupButtonID="ButtonTgl02" />
				        </td>
					    <td class="col-md-2"><asp:Label ID="Label34" runat="server" Text="Departemen/Divisi"></asp:Label></td>
					    <td class="col-md-4">
					        <asp:TextBox ID="TxtStatusKerjaDept" runat="server" MaxLength="50" Text ="" style="width: 175px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox> /
					        <asp:TextBox ID="TxtStatusKerjaDivis" runat="server" MaxLength="50" Text ="" style="width: 175px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
					    </td>
				    </tr>
		            <tr>
				        <td class="col-md-2"><asp:Label ID="Label35" runat="server" Text="Lokasi Penempatan"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStatusKerjaTempat" runat="server" MaxLength="10" Text ="" class="form-control required"></asp:TextBox></td>
				        <td class="col-md-2"><asp:Label ID="Label33" runat="server" Text="Jabatan"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStatusKerjaJabatan" runat="server" MaxLength="30" class="form-control required" Text =""></asp:TextBox></td>
				    </tr>
			    </table> 
			    <hr />
			    <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-stats"></span> Status Pekerjaan</h3>
			    <br />
			    <table class="table table-borderless">
				    <tr>
					    <td class="col-md-2"><asp:Label ID="Label36" runat="server"  Text="Status Kerja Magang"></asp:Label></td>
					    <td class="col-md-4">
					        <asp:DropDownList ID="DropDownList2" runat="server" class="form-control required">
                                <asp:ListItem></asp:ListItem>
							    <asp:ListItem>03</asp:ListItem>
							    <asp:ListItem>06</asp:ListItem>
							    <asp:ListItem>12</asp:ListItem>
						    </asp:DropDownList>
				        </td>
				        <td class="col-md-2"><asp:Label ID="Label98" runat="server" Text="Tgl Akhir Kerja Magang" ></asp:Label></td>
				        <td class="col-md-4">
				            <asp:TextBox ID="TxtStatusKerjaMagangTglAkhir" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />                   
					        <asp:LinkButton ID="ButtonTgl03"  runat="server" CssClass="btn btn-default" CausesValidation="False">
					            <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
						    </asp:LinkButton>
					        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExt03" runat="server"
						        TargetControlID="TxtStatusKerjaMagangTglAkhir" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
								OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
								<ajaxToolkit:MaskedEditValidator ID="MaskedEditValid03" runat="server"
								ControlExtender="MaskedEditExt03" ControlToValidate="TxtStatusKerjaMagangTglAkhir" EmptyValueMessage="Date is required"
								InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
								EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
					        <ajaxToolkit:CalendarExtender ID="CalendarExt03" runat="server" TargetControlID="TxtStatusKerjaMagangTglAkhir" PopupButtonID="ButtonTgl03" />
				        </td>
				    </tr>
				    <tr>
					    <td class="col-md-2"><asp:Label ID="Label37" runat="server" Text="Status Kerja Percobaan"></asp:Label></td>
					    <td class="col-md-4">
			                <asp:DropDownList ID="DropDownList3" runat="server" class="form-control required">
						        <asp:ListItem></asp:ListItem>
						        <asp:ListItem>03</asp:ListItem>
					            <asp:ListItem>06</asp:ListItem>
						        <asp:ListItem>12</asp:ListItem>
					        </asp:DropDownList>
				        </td>
				        <td class="col-md-2"><asp:Label ID="Label99" runat="server" Text="Tgl Akhir Percobaan"></asp:Label></td>
					    <td class="col-md-4">
					        <asp:TextBox ID="TxtStatusKerjaCobaTglAkhir" runat="server" MaxLength="1"  style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />
						    <asp:LinkButton ID="ButtonTgl04"  runat="server" CssClass="btn btn-default" CausesValidation="False">
						        <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
						    </asp:LinkButton>
						    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExt04" runat="server"
						        TargetControlID="TxtStatusKerjaCobaTglAkhir" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
								OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
						    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValid04" runat="server"
								ControlExtender="MaskedEditExt04" ControlToValidate="TxtStatusKerjaCobaTglAkhir" EmptyValueMessage="Date is required"
								InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
								EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
						    <ajaxToolkit:CalendarExtender ID="CalendarExt04" runat="server" TargetControlID="TxtStatusKerjaCobaTglAkhir" PopupButtonID="ButtonTgl04" /> 
					    </td>
				    </tr>
				    <tr>
				        <td class="col-md-2"><asp:Label ID="Label38" runat="server" Text="Status Kerja Kontrak I"></asp:Label></td>
				        <td class="col-md-4">
					        <asp:DropDownList ID="DropDownList4" runat="server" class="form-control required">
					            <asp:ListItem></asp:ListItem>
					            <asp:ListItem>03</asp:ListItem>
						        <asp:ListItem>06</asp:ListItem>
					            <asp:ListItem>12</asp:ListItem>
						    </asp:DropDownList>
					    </td>
				        <td class="col-md-2"><asp:Label ID="Label100" runat="server" Text="Tgl Akhir Kerja Kontrak I"></asp:Label></td>
				        <td class="col-md-4">
					        <asp:TextBox ID="TxtStatusKerjaKontrak1TglAkhir" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />
				            <asp:LinkButton ID="ButtonTgl05"  runat="server" CssClass="btn btn-default" CausesValidation="False">
						        <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
					        </asp:LinkButton>
					        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExt05" runat="server"
						        TargetControlID="TxtStatusKerjaKontrak1TglAkhir" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
								OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
								<ajaxToolkit:MaskedEditValidator ID="MaskedEditValid05" runat="server"
								ControlExtender="MaskedEditExt05" ControlToValidate="TxtStatusKerjaKontrak1TglAkhir" EmptyValueMessage="Date is required"
								InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
								EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
						    <ajaxToolkit:CalendarExtender ID="CalendarExt05" runat="server" TargetControlID="TxtStatusKerjaKontrak1TglAkhir" PopupButtonID="ButtonTgl05" />      
					    </td>
				    </tr>
				    <tr>
					    <td class="col-md-2"><asp:Label ID="Label42" runat="server" Text="Status Kerja Kontrak II"></asp:Label></td>
					    <td class="col-md-4">
					        <asp:DropDownList ID="DropDownList5" runat="server" class="form-control required">
						        <asp:ListItem></asp:ListItem>
						        <asp:ListItem>03</asp:ListItem>
							    <asp:ListItem>06</asp:ListItem>
						        <asp:ListItem>12</asp:ListItem>
						    </asp:DropDownList>
					    </td>
					    <td class="col-md-2"><asp:Label ID="Label101" runat="server" Text="Tgl Akhir Kerja Kontrak II"></asp:Label></td>
					    <td class="col-md-2">
					        <asp:TextBox ID="TxtStatusKerjaKontrak2TglAkhir" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />
						    <asp:LinkButton ID="ButtonTgl07"  runat="server" CssClass="btn btn-default" CausesValidation="False">
						        <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
						    </asp:LinkButton>
						    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExt07" runat="server"
						        TargetControlID="TxtStatusKerjaKontrak2TglAkhir" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
								OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
						    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValid07" runat="server"
								ControlExtender="MaskedEditExt07" ControlToValidate="TxtStatusKerjaKontrak2TglAkhir" EmptyValueMessage="Date is required"
								InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
								EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
						    <ajaxToolkit:CalendarExtender ID="CalendarExt07" runat="server" TargetControlID="TxtStatusKerjaKontrak2TglAkhir" PopupButtonID="ButtonTgl07" />
					    </td>
				    </tr>
				    <tr>
					    <td class="col-md-2"><asp:Label ID="Label43" runat="server" Text="Status Kerja Keagenan"></asp:Label></td>
					    <td class="col-md-4">
					        <asp:DropDownList ID="DropDownList6" runat="server" class="form-control required">
					            <asp:ListItem></asp:ListItem>
						        <asp:ListItem>03</asp:ListItem>
					            <asp:ListItem>06</asp:ListItem>
						        <asp:ListItem>12</asp:ListItem>
					        </asp:DropDownList>
				        </td>
			            <td class="col-md-2"><asp:Label ID="Label102" runat="server" Text="Tgl Akhir Keagenan"></asp:Label></td>
				        <td class="col-md-4">
				            <asp:TextBox ID="TxtStatusKerjaAgenTglAkhir" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />
					        <asp:LinkButton ID="ButtonTgl08"  runat="server" CssClass="btn btn-default" CausesValidation="False">
					            <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
						    </asp:LinkButton>
				            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExt08" runat="server"
					            TargetControlID="TxtStatusKerjaAgenTglAkhir" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
						        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
				            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValid08" runat="server"
								ControlExtender="MaskedEditExt08" ControlToValidate="TxtStatusKerjaAgenTglAkhir" EmptyValueMessage="Date is required"
								InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
								EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
					        <ajaxToolkit:CalendarExtender ID="CalendarExt08" runat="server" TargetControlID="TxtStatusKerjaAgenTglAkhir" PopupButtonID="ButtonTgl08" />
					    </td>
			        </tr>
			    </table>
		        <hr />
			    <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-calendar"></span> History Karyawan</h3>
			    <br />
			    <table class="table table-borderless">
			        <tr>
			            <td style="width:10%"><asp:Label ID="Label45" runat="server" Font-Names="Arial" Text="Tgl Pengangkatan Karyawan Tetap"></asp:Label></td>
						<td class="col-md-4">
							<asp:TextBox ID="TxtStatusKerjaTetap" runat="server" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" MaxLength="1" ValidationGroup="MKE" />
							<asp:LinkButton ID="ButtonTgl09"  runat="server" CssClass="btn btn-default" CausesValidation="False">
								<span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
							</asp:LinkButton>
							<ajaxToolkit:MaskedEditExtender ID="MaskedEditExt09" runat="server"
							TargetControlID="TxtStatusKerjaTetap" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
							OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
							<ajaxToolkit:MaskedEditValidator ID="MaskedEditValid09" runat="server"
							ControlExtender="MaskedEditExt09" ControlToValidate="TxtStatusKerjaTetap" EmptyValueMessage="Date is required"
							InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
							EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
							<ajaxToolkit:CalendarExtender ID="CalendarExt09" runat="server" TargetControlID="TxtStatusKerjaTetap" PopupButtonID="ButtonTgl09" />
						</td>
					</tr>
					<tr>
						<td style="width:10%"><asp:Label ID="Label46" runat="server" Text="Tanggal Keluar"></asp:Label></td>
						<td class="col-md-4">
						<asp:TextBox ID="TxtStatusKerjaKeluar" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />
							<asp:LinkButton ID="ButtonTgl10"  runat="server" CssClass="btn btn-default" CausesValidation="False">
								<span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
							</asp:LinkButton>
							<ajaxToolkit:MaskedEditExtender ID="MaskedEditExt10" runat="server"
							TargetControlID="TxtStatusKerjaKeluar" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
							OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
							<ajaxToolkit:MaskedEditValidator ID="MaskedEditValid10" runat="server"
							ControlExtender="MaskedEditExt10" ControlToValidate="TxtStatusKerjaKeluar" EmptyValueMessage="Date is required"
							InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
							EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
							<ajaxToolkit:CalendarExtender ID="CalendarExt10" runat="server" TargetControlID="TxtStatusKerjaKeluar" PopupButtonID="ButtonTgl10" />
						</td>
					</tr>
					<tr>
						<td style="width:10%"><asp:Label ID="Label47" runat="server" Text="Alasan Keluar"></asp:Label></td>
						<td class="col-md-4"><asp:TextBox ID="TxtStatusKerjaAlasan" runat="server" MaxLength="50" class="form-control required" Text =""></asp:TextBox></td>
                    </tr>
				</table>        
				<hr />
				<h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-camera"></span> Foto Karyawan</h3>
				<br />
				<table class="table table-borderless">
					<tr> 
						<td style="width:10%">
                            <asp:Image ID="Image1" runat="server" src="WEBDOWNLOAD\FOTOKARYAWAN\icon.png" Width="180" Height="220" /><br /><br />
							<asp:FileUpload ID="FileUpload1" runat="server"/>
							<asp:RegularExpressionValidator ID="FileTypeValidator" runat="server" ErrorMessage="File type not allowed: Accept JPG file type only" ValidationExpression="(.*png$)|(.*jpg$)|(.*jpeg$)" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator><br />
							<asp:Button ID="ButtonA1Upload" runat="server" Text="Upload Foto" />
						</td>
					</tr>
				</table> 
				<center><asp:Label ID="LblErrorSaveA1" runat="server" Text="" style="color:red"></asp:Label></center><br /><br />
				<center>
					<asp:Button ID="ButtonA1Back" runat="server" Text="Kembali Ke Menu Awal" class="btn btn-warning" />
					<asp:Button ID="ButtonA1Save" runat="server" Text="Simpan" class="btn btn-success" />
							<asp:Button ID="ButtonA1Del" runat="server" Text="Hapus" class="btn btn-danger" />
				</center>    
				<br />
				<br />
				<br />
				<br />  
	            <div class="container">
		            <div class="well">  	
			            <div class="container">
				            <center>
					            <h3 style="font-family:Cooper Black;">DETAIL INFO KARYAWAN</h3>
				            </center>
			            </div>
			            <br /><br />
			            <div class="container">
				            <div class="row">
					            <div class="col-md-12">
						            <div class="row">
							            <div class="col-sm-3 col-md-3 col-lg-3">
								            <div class="box">
									            <div class="aligncenter">								
										            <div class="icon">
											            <center><asp:LinkButton ID="Tab01" runat="server" Text="Pendidikan"><img class="img-responsive img-center" src="img/pendidikan.png" height="150" width="150" alt=""></asp:LinkButton></center>
										            </div>
										            <h4 style="text-align:center">Pendidikan</h4>
									            </div>
								            </div>
							            </div>
							            <div class="col-sm-3 col-md-3 col-lg-3">
								            <div class="box">
									            <div class="aligncenter">								
										            <div class="icon">
											            <center><asp:LinkButton ID="Tab02" runat="server" Text="Pengalaman Kerja"><img class="img-responsive img-center" src="img/kerja.png" height="150" width="150" alt=""></asp:LinkButton></center>
										            </div>
										            <h4 style="text-align:center">Pengalaman Kerja</h4>
									            </div>
								            </div>
							            </div>
							            <div class="col-sm-3 col-md-3 col-lg-3">
								            <div class="box">
									            <div class="aligncenter">								
										            <div class="icon">
											            <center><asp:LinkButton ID="Tab04" runat="server" Text="Pelatihan"><img class="img-responsive img-center" src="img/pelatihan.png" height="150" width="150" alt=""></asp:LinkButton></center>
										            </div>
										            <h4 style="text-align:center">Pelatihan</h4>
									            </div>
								            </div>
							            </div>
							            <div class="col-sm-3 col-md-3 col-lg-3">
								            <div class="box">
									            <div class="aligncenter">								
										            <div class="icon">
											            <asp:LinkButton ID="Tab05" runat="server" Text="Penilaian"><img class="img-responsive img-center" src="img/penilaian.png" height="150" width="150" alt=""></asp:LinkButton>
										            </div>
										            <h4>&nbsp &nbsp Penilaian Kerja</h4>
									            </div>
								            </div>
							            </div>
						            </div>
					            </div>
				            </div>
			            </div>
		            </div>
	            </div>
                <br />
                <br />
            </asp:View> 
        </asp:MultiView>
    </div>
    <div class="container">    
        <asp:MultiView ID="MultiView102Detail" runat="server" Visible="TRUE">
            <asp:View ID="View10201PendidikanFormal" runat="server">    
                <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">DATA PENDIDIKAN FORMAL</h3>
                    </center>
	            </div><br />
                <asp:Button ID="BtnA110Master1" runat="server" Text="(+) Tambah Pendidikan Formal" class="btn btn-primary" />
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSTaffPendidikan" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [STAFFFO_NIK], [STAFFFO_TINGKAT], [STAFFFO_NAMA], [STAFFFO_JURUSAN], [STAFFFO_TAHUN], [STAFFFO_KET], [STAFFFO_IJAZAH], [STAFFFO_TIPE] FROM [DATA_STAFFFO] WHERE (([STAFFFO_TIPE] = ?) AND ([STAFFFO_NIK] = ?))"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="F" Name="STAFFFO_TIPE" Type="String" />
                        <asp:ControlParameter ControlID="TxtStaffNIK"  Name="STAFFFO_NIK"  PropertyName="Text" Type="String" />            
                    </SelectParameters>
                </asp:SqlDataSource>                             
                <asp:ListView ID="LVPendidikanFormal" runat="server" DataSourceID="SqlDataSTaffPendidikan"  DataKeyNames ="STAFFFO_TINGKAT">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered striped" align="left">
                            <thead style="background-color:#E8E8E8">
                                <th style="text-align:center" class="col-md-1">No.</th>
                                <th style="text-align:center">Tingkat</th>
                                <th style="text-align:center">Institusi</th>
                                <th style="text-align:center">Jurusan</th>
                                <th style="text-align:center">Thn Lulus</th>
                                <th style="text-align:center">Keterangan</th>
                                <th style="text-align:center">Ijazah</th>
                                <th style="text-align:center" class="col-md-1">Lihat Detail</th>
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
                            <td style="text-align:center"><%# Eval("STAFFFO_TINGKAT") %></td>
                            <td><%#Eval("STAFFFO_NAMA")%></td>
                            <td><%#Eval("STAFFFO_JURUSAN")%></td>
                            <td style="text-align:center"><%#Eval("STAFFFO_TAHUN")%></td>
                            <td><%#Eval("STAFFFO_KET")%></td>
                            <td><%#Eval("STAFFFO_IJAZAH")%></td>
                            <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Pendidikan Formal Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Pendidikan Formal Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>    
                <br />
                              
                <asp:MultiView ID="MultiView10201DidikFormalENtry" runat="server" Visible="TRUE">
                    <asp:View ID="View110201Detail" runat="server"> 
                        <div class="container">
                            <center>
                                <h3 style="font-family:Blunter;">DETAIL PENDIDIKAN FORMAL</h3>
                            </center>
	                    </div><br /><br />   
                        <table class="table table-borderless">
                            <tr>
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label11" runat="server" Text="Tingkat Pendidikan"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtPendidikanTingkat" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label12" runat="server" Text="Nama Institusi"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtPendidikanNama" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label13" runat="server" Text="Jurusan"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtPendidikanJurusan" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td> 
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>  
                                <td class="col-md-2"><asp:Label ID="Label14" runat="server" Text="Tahun Kelulusan"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtPendidikanTahun" runat="server" MaxLength="4" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td> 
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>  
                                <td class="col-md-2"><asp:Label ID="Label15" runat="server" Text="Keterangan"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtPendidikanKet" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td> 
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>  
                                <td class="col-md-2"><asp:Label ID="Label68" runat="server" Text="Status Ijazah"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtPendidikanIjazah" runat="server" MaxLength="1" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td> 
                            </tr>
                        </table> 

                        <center>
                            <asp:Label ID="LblErrorSaveA111" runat="server" Text="" style="color:red"></asp:Label>
                        </center>

                        <center>
                            <asp:Button ID="BtnA111Back" runat="server" Text="Kembali Ke Tabel" class="btn btn-warning" />
                            <asp:Button ID="BtnA111Save" runat="server" Text="Simpan" class="btn btn-success" />
                            <asp:Button ID="BtnA111Del" runat="server" Text="Hapus" class="btn btn-danger" />
                        </center>  <br /><br />         
                    </asp:View> 
                </asp:MultiView>  
            <div class="container">
                <center>
                    <h3 style="font-family:Blunter;">DATA PENDIDIKAN</h3>
                </center>
	        </div><br />
            <table class="table table-borderless">
                <tr>
                    <td class="col-md-2"></td> 
                    <td class="col-md-2"><asp:Label ID="Label21" runat="server" Text="Sedang Melanjutkan Pendidikan"></asp:Label></td>
                    <td class="col-md-4"><asp:TextBox ID="TxtPendidikanLanjutYN" runat="server" MaxLength="1" Text ="" class="form-control required"></asp:TextBox></td>
                    <td class="col-md-2"></td>
                </tr>
                <tr>
                    <td class="col-md-2"></td> 
                    <td class="col-md-2"><asp:Label ID="Label23" runat="server" Text="Nama Institusi"></asp:Label></td>
                    <td class="col-md-4"><asp:TextBox ID="TxtPendidikanLanjutNama" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:TextBox></td>
                    <td class="col-md-2"></td>
                </tr>
                <tr>
                    <td class="col-md-2"></td> 
                    <td class="col-md-2"><asp:Label ID="Label24" runat="server" Text="Semester"></asp:Label></td>
                    <td class="col-md-4"><asp:TextBox ID="TxtPendidikanLanjutJurusan" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                    <td class="col-md-2"></td>
                </tr>
                <tr>
                    <td class="col-md-2"></td> 
                    <td class="col-md-2"><asp:Label ID="Label25" runat="server" Text="Jurusan"></asp:Label></td>
                    <td class="col-md-4"><asp:TextBox ID="TxtPendidikanLanjutSMS" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                    <td class="col-md-2"></td>
                </tr>
            </table> 
            <center>
                <asp:Label ID="LblErrorSaveA112" runat="server" Text="" style="color:red"></asp:Label>
            </center>
            <center>
                <asp:Button ID="BtnA112Del" runat="server" Text="Hapus" class="btn btn-danger" />
                <asp:Button ID="BtnA112Save" runat="server" Text="Simpan" class="btn btn-success" />    
            </center> <br /><br />
                               
            <div class="container">
                <center>
                    <h3 style="font-family:Blunter;">DATA PENDIDIKAN NON FORMAL</h3>
                </center>
	        </div><br />
            <asp:Button ID="BtnA110Master2" runat="server" Text="(+) Tambah Pendidikan Non Formal" class="btn btn-primary" />
            <br /><br />
            <asp:SqlDataSource ID="SqlDataSTaffPendidikanNonFormal" runat="server"
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                SelectCommand="SELECT * FROM [DATA_STAFFFO] WHERE (([STAFFFO_TIPE] = ?) AND ([STAFFFO_NIK] = ?))"
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                <SelectParameters>
                    <asp:Parameter DefaultValue="N" Name="STAFFFO_TIPE" Type="String" />
                    <asp:ControlParameter ControlID="TxtStaffNIK"   Name="STAFFFO_NIK"  PropertyName="Text" Type="String" DefaultValue ="" />            
                </SelectParameters>
            </asp:SqlDataSource>                             
            <asp:ListView ID="LVPendidikanNonFormal" runat="server" DataSourceID="SqlDataSTaffPendidikanNonFormal" DataKeyNames ="STAFFFO_TINGKAT">
            <LayoutTemplate>
                <table id="table-a" class="table table-bordered striped" align="left">
                    <thead style="background-color:#E8E8E8">
                        <th style="text-align:center" class="col-md-1">No.</th>
                        <th style="text-align:center">No. Training</th>
                        <th style="text-align:center">Nama Pelatihan</th>
                        <th style="text-align:center">Instusi</th>
                        <th style="text-align:center">Tahun</th>
                        <th style="text-align:center" class="col-md-1">Lihat Detail</th>
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
                    <td style="text-align:center"><%# Eval("STAFFFO_TINGKAT") %></td>
                    <td><%#Eval("STAFFFO_JURUSAN")%></td>
                    <td><%#Eval("STAFFFO_NAMA")%></td>
                    <td style="text-align:center"><%#Eval("STAFFFO_TAHUN")%></td>
                    <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>Data Pendidikan Non Formal Tidak diketemukan</EmptyDataTemplate> 
            <EmptyItemTemplate>Data Pendidikan Non Formal Tidak diketemukan</EmptyItemTemplate>              
        </asp:ListView>
        <br />

        <asp:MultiView ID="MultiView10202DidikNonFormalEntry" runat="server" Visible="TRUE">
            <asp:View ID="View110202Detail" runat="server">  
                <div class="container">
                <center>
                    <h3 style="font-family:Blunter;">DETAIL PENDIDIKAN NON FORMAL</h3>
                </center>
	        </div><br /><br />  
                <table class="table table-borderless">
                    <tr>
                        <td class="col-md-2"></td>  
                        <td class="col-md-2"><asp:Label ID="Label17" runat="server" Text="Nomor Training"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtDidikNonFormalTingkat" runat="server" MaxLength="2" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td> 
                    </tr>
                    <tr>
                        <td class="col-md-2"></td>  
                        <td class="col-md-2"><asp:Label ID="Label18" runat="server" Text="Nama Pelatihan"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtDidikNonFormalJudul" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td> 
                    </tr>
                    <tr>
                        <td class="col-md-2"></td>  
                        <td class="col-md-2"><asp:Label ID="Label19" runat="server" Text="Institusi"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtDidikNonFormalNama" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td> 
                    </tr>
                    <tr>
                        <td class="col-md-2"></td>  
                        <td class="col-md-2"><asp:Label ID="Label20" runat="server" Text="Tahun Pelatihan"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtDidikNonFormalTahun" runat="server" MaxLength="4" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td> 
                    </tr>
                </table> 

                <center>
                    <asp:Label ID="LblErrorSaveA113" runat="server" Text="" style="color:red"></asp:Label>
                </center>

                <center>
                    <asp:Button ID="BtnA113Back" runat="server" Text="Kembali Ke Tabel" class="btn btn-warning" />
                    <asp:Button ID="BtnA113Save" runat="server" Text="Simpan" class="btn btn-success" />
                    <asp:Button ID="BtnA113Del" runat="server" Text="Hapus" class="btn btn-danger" />
                </center>         
            </asp:View> 
        </asp:MultiView>            
    </asp:View> 

    <asp:View ID="View10202Pengalaman" runat="server"> 
        <div class="container">
                <center>
                    <h3 style="font-family:Blunter;">DATA PENGALAMAN KERJA</h3>
                </center>
	        </div><br />  
        <asp:Button ID="BtnA120Master" runat="server" Text="(+) Tambah Pengalaman Kerja" class="btn btn-primary"/>
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataPengalanKerja" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT * FROM [DATA_STAFFKR] WHERE ([STAFFKR_NIK] = ?)"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblStaffNIK" Name="STAFFKR_NIK" PropertyName="Text" Type="String" />            
            </SelectParameters>
        </asp:SqlDataSource>                             
        <asp:ListView ID="LVPengalamanKerja" runat="server" DataSourceID="SqlDataPengalanKerja" DataKeyNames ="STAFFKR_NAMA">
            <LayoutTemplate>
                 <table id="table-a" class="table table-bordered striped" align="left">
                    <thead style="background-color:#E8E8E8">
                        <th style="text-align:center" class="col-md-1">No.</th>
                        <th style="text-align:center">Perusahaan</th>
                        <th style="text-align:center">Alamat</th>
                        <th style="text-align:center">Jabatan</th>
                        <th style="text-align:center">Masuk</th>
                        <th style="text-align:center">Keluar</th>
                        <th style="text-align:center" class="col-md-1">Lihat Detail</th>
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
                    <td><%# Eval("STAFFKR_NAMA") %></td>
                    <td><%#Eval("STAFFKR_ALAMAT")%></td>
                    <td><%#Eval("STAFFKR_JABATAN")%></td>
                    <td><%#Eval("STAFFKR_MASUK")%></td>
                    <td><%#Eval("STAFFKR_KELUAR")%></td>
                    <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>Data Pengalaman Tidak diketemukan</EmptyDataTemplate> 
            <EmptyItemTemplate>Data Pengalaman Tidak diketemukan</EmptyItemTemplate>              
        </asp:ListView>
        <br /><br />
        
                
                
        <asp:MultiView ID="MultiViewKerjaEntry" runat="server" Visible="TRUE">
            <asp:View ID="View11020201" runat="server"> 
                <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">DETAIL PENGALAMAN KERJA</h3>
                    </center>
	            </div><br /><br />   
                <table class="table table-borderless">
                    <tr>
                        <td class="col-md-2"></td> 
                        <td class="col-md-2"><asp:Label ID="Label26" runat="server" Text="Nama Perusahaan"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtCompanyNama" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label58" runat="server" Text="Alamat Perusahaan"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtCompanyAlamat" runat="server" MaxLength="80" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label27" runat="server" Text="Jabatan"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtCompanyJabatan" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label28" runat="server" Text="Tanggal Masuk"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtCompanyMasuk" runat="server" MaxLength="15" Text ="" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:TextBox>    
                                            <asp:LinkButton ID="ButtonTgl20"  runat="server" CssClass="btn btn-default" CausesValidation="False">
                                                <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
                                            </asp:LinkButton>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                            TargetControlID="TxtCompanyMasuk" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                                            ControlExtender="MaskedEditExt10" ControlToValidate="TxtCompanyMasuk" EmptyValueMessage="Date is required"
                                            InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                            EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtCompanyMasuk" PopupButtonID="ButtonTgl20" />
                        </td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label30" runat="server" Text="Tanggal Keluar"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtCompanyKeluar" runat="server" MaxLength="15" Text ="" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:TextBox>
                                            <asp:LinkButton ID="ButtonTgl21"  runat="server" CssClass="btn btn-default" CausesValidation="False">
                                                <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
                                            </asp:LinkButton>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                            TargetControlID="TxtCompanyKeluar" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
                                            ControlExtender="MaskedEditExt10" ControlToValidate="TxtCompanyKeluar" EmptyValueMessage="Date is required"
                                            InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                            EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TxtCompanyKeluar" PopupButtonID="ButtonTgl21" />
                        </td>
                        <td class="col-md-2"></td>
                    </tr>
                </table> 
                <center>
                    <asp:Label ID="LblErrorSaveA12" runat="server" Text="" style="color:red"></asp:Label>
                </center><br />
                <center> 
                    <asp:Button ID="BtnA12Back" runat="server" Text="Kembali Ke Tabel" class="btn btn-warning" />     
                    <asp:Button ID="BtnA12Save" runat="server" Text="Simpan" class="btn btn-success" />
                    <asp:Button ID="BtnA12Del" runat="server" Text="Hapus" class="btn btn-danger" />
                </center>           
            </asp:View> 
        </asp:MultiView>      
    </asp:View> 
 
    <asp:View ID="View10204Pelatihan" runat="server">   
        <div class="container">
            <center>
                <h3 style="font-family:Blunter;">DATA PELATIHAN</h3>
            </center>
        </div><br />
        <asp:Button ID="BtnA130Master" runat="server" Text="(+) Tambah Data Pelatihan" class="btn btn-primary" />
        <br />
        <br /> 
        <asp:SqlDataSource ID="SqlDataPelatihan" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT * FROM [DATA_STAFFPL] WHERE ([STAFFPL_NIK] = ?)"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblStaffNIK" Name="STAFFPL_NIK" PropertyName="Text" Type="String" />            
            </SelectParameters>
        </asp:SqlDataSource>                             
        <asp:ListView ID="LVPelatihan" runat="server" DataSourceID="SqlDataPelatihan" DataKeyNames ="STAFFPL_PELATIHAN">
            <LayoutTemplate>
                <table id="table-a" class="table table-bordered striped" align="left">
                    <thead style="background-color:#E8E8E8">
                        <th style="text-align:center" class="col-md-1">No.</th>
                        <th style="text-align:center">Nama</th>
                        <th style="text-align:center">Jenis</th>
                        <th style="text-align:center">Instutusi</th>
                        <th style="text-align:center">Tgl Pelatihan</th>
                        <th style="text-align:center">Biaya</th>
                        <th style="text-align:center">Hasil/Nilai</th>
                        <th style="text-align:center" class="col-md-1">Lihat Detail</th>
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
                    <td><%#Eval("STAFFPL_PELATIHAN") %></td>
                    <td><%#Eval("STAFFPL_JENIS")%></td>
                    <td><%#Eval("STAFFPL_NAMA")%></td>
                    <td><%#Eval("STAFFPL_TGL")%></td>
                    <td>Rp <%#Eval("STAFFPL_BIAYA", "{0:N}")%></td>
                    <td style="text-align:center"><%#Eval("STAFFPL_HASIL")%></td>
                    <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>Data Karyawan Tidak diketemukan</EmptyDataTemplate> 
            <EmptyItemTemplate>Data Karyawan Tidak diketemukan</EmptyItemTemplate>              
        </asp:ListView>
        <br />
            
            <asp:MultiView ID="MultiViewPelatihanEntry" runat="server" Visible="TRUE">
                <asp:View ID="View1" runat="server">   
                    <br /> 
                    <div class="container">
                        <center>
                            <h3 style="font-family:Blunter;">DETAIL PELATIHAN</h3>
                        </center>
	                </div><br /><br />
                    <table class="table table-borderless">
                        <tr>
                            <td class="col-md-2"></td> 
                            <td class="col-md-2"><asp:Label ID="Label48" runat="server" Text="Nama Pelatihan"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtLatihPelatih" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label49" runat="server" Text="Jenis Pelatihan"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtLatihJenis" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label50" runat="server" Text="Nama Institusi"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtLatihNama" runat="server" MaxLength="50"  Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label51" runat="server" Text="Tanggal Pelatihan"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtLatihTgl" runat="server" MaxLength="50" Text ="" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:TextBox>
                                                 <asp:LinkButton ID="ButtonTgl22"  runat="server" CssClass="btn btn-default" CausesValidation="False">
                                                <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
                                            </asp:LinkButton>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                            TargetControlID="TxtLatihTgl" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator3" runat="server"
                                            ControlExtender="MaskedEditExt10" ControlToValidate="TxtLatihTgl" EmptyValueMessage="Date is required"
                                            InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                            EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TxtLatihTgl" PopupButtonID="ButtonTgl22" />
                            </td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label52" runat="server" Text="Biaya"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtLatihBiaya" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label53" runat="server" Text="Hasil"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtLatihHasil" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                    </table> 
                    <center>
                        <asp:Label ID="LblErrorSaveA13" runat="server" Text="" style="color:red"></asp:Label>
                    </center><br />
                    <center>
                        <asp:Button ID="BtnA13Back" runat="server" Text="Kembali Ke Tabel" class="btn btn-warning" />
                        <asp:Button ID="BtnA13Save" runat="server" Text="Simpan" class="btn btn-success" />
                        <asp:Button ID="BtnA13Del" runat="server" Text="Hapus" class="btn btn-danger" />
                    </center>          
                </asp:View> 
            </asp:MultiView>                    
        </asp:View> 

        <asp:View ID="View10205PenilaianKerja" runat="server">    
            <asp:MultiView ID="MultiViewNilaiStandard" runat="server" Visible="TRUE">
                <asp:View ID="ViewNilaiStandard" runat="server">  
                    <div class="container">
                        <center>
                            <h3 style="font-family:Blunter;">DATA PENILAIAN KERJA</h3>
                        </center>
                        </div><br />
                    <asp:Button ID="BtnStandard" runat="server" Text="(+) Tambah Data Penilaian" class="btn btn-primary"/>
                    <br /><br />
                    <asp:SqlDataSource ID="SqlDataKPIN" runat="server"
                        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                        SelectCommand="SELECT [KPIN_TIPE], [KPIN_JUDUL], [KPIN_DESC], [KPIN_NILAI], [KPIN_GROUP] FROM [DATA_KPIN]"
                        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    </asp:SqlDataSource>                                     
                    <asp:ListView ID="LVNilaiStandard" runat="server" DataSourceID="SqlDataKPIN" DataKeyNames ="KPIN_TIPE">
                        <LayoutTemplate>
                            <table id="table-a" class="table table-bordered striped" align="left">
                                <thead style="background-color:#E8E8E8">
                                    <th style="text-align:center" class="col-md-1">No.</th>
                                    <th style="text-align:center">Kode</th>
                                    <th style="text-align:center">Group</th>
                                    <th style="text-align:center">Judul</th>
                                    <th style="text-align:center">Keterangan</th>
                                    <th style="text-align:center">Nilai</th>
                                    <th style="text-align:center" class="col-md-1">Lihat Detail</th>
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
                                <td style="text-align:center"><%# Eval("KPIN_TIPE") %></td>
                                <td style="text-align:center"><%#Eval("KPIN_GROUP")%></td>
                                <td style="text-align:center"><%#Eval("KPIN_JUDUL")%></td>
                                <td><%#Eval("KPIN_DESC")%></td>
                                <td style="text-align:center"><%#Eval("KPIN_NILAI")%></td>
                                <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='Text' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>Data Nilai Standard Tidak diketemukan</EmptyDataTemplate> 
                        <EmptyItemTemplate>Data Nilai Standard Tidak diketemukan</EmptyItemTemplate>              
                    </asp:ListView>
                     <br />
                </asp:View> 
            </asp:MultiView>            
            <asp:MultiView ID="MultiViewNilaiStandardEntry" runat="server" Visible="TRUE">
                <asp:View ID="View4" runat="server">    
                     <div class="container">
                        <center>
                            <h3 style="font-family:Blunter;">DETAIL PENILAIAN KERJA</h3>
                        </center>
                        </div><br />
                    <table class="table table-borderless">
                        <tr>
                            <td class="col-md-2"></td> 
                            <td class="col-md-2"><asp:Label ID="Label55" runat="server" Text="Kode"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtStandardKode" runat="server" MaxLength="4" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label67" runat="server" Text="Group"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtStandardGroup" runat="server" MaxLength="10" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label56" runat="server" Text="Judul"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtStandardJudul" runat="server" MaxLength="200" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label57" runat="server" Text="Keterangan"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtStandardKet" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>     
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label62" runat="server" Text="Nilai"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtStandardNilai" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                    </table> 
                    <center>
                        <asp:Label ID="LblErrorSaveStandard" runat="server" Text="" style="color:red"></asp:Label>
                    </center>
                    <center>
                        <asp:Button ID="BtnStandardBack" runat="server" Text="Kembali Ke Tabel" class="btn btn-warning" />
                        <asp:Button ID="BtnStandardSave" runat="server" Text="Simpan" class="btn btn-success" />
                        <asp:Button ID="BtnStandardDel" runat="server" Text="Hapus" class="btn btn-danger" />
                    </center>         
                </asp:View> 
            </asp:MultiView>            

            <asp:MultiView ID="MultiViewKpiMaster" runat="server" Visible="TRUE">
                <asp:View ID="ViewTampilKpiMasterSumary" runat="server">  
                    <br />
                    <div class="container">
                        <center>
                            <h3 style="font-family:Blunter;">DATA KEY PERFORMANCE INDICATOR (KPI)</h3>
                        </center>
	                </div><br />
                     <asp:Button ID="BtnStandardTabel" runat="server" Text="Buka Tabel Nilai Standard" class="btn btn-default"/>
                    <asp:Button ID="BtnKpi40Master" runat="server" Text="(+) Tambah Data KPI" class="btn btn-primary"/>
                    <br /><br />
                    <asp:SqlDataSource ID="SqlDataKpiMasterSumary" runat="server"
                        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                        SelectCommand="SELECT [KPIH_NIK], [KPIH_TAHUN], [KPIH_TIPEA], [KPIH_TIPEB], [KPIH_NILAI], [KPIH_ABJAD], [KPIH_APPVHRDTGL], [KPIH_APPVUSERTGL], [KPIH_APPVUSER], [KPIH_APPVHEAD], [KPIH_APPVHEADTGL], [KPIH_APPVHRD] FROM [TRXN_KPIH] WHERE ([KPIH_NIK] = ?)"
                        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TxtStaffNIK" Name="KPIH_NIK" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>                                     
                    <asp:ListView ID="LvKpiMasterSummary" runat="server" DataSourceID="SqlDataKpiMasterSumary" DataKeyNames ="KPIH_TAHUN">
                        <LayoutTemplate>
                            <table id="table-a" class="table table-bordered striped" align="left">
                                <thead style="background-color:#E8E8E8">
                                    <th style="text-align:center" class="col-md-1">No.</th>
                                    <th style="text-align:center">Tahun</th>
                                    <th style="text-align:center">Jenis Karyawan1</th>
                                    <th style="text-align:center">Jenis Karyawan2</th>
                                    <th style="text-align:center">HRD Disetujui</th>
                                    <th style="text-align:center">Nilai</th>
                                    <th style="text-align:center">Grade</th>
                                    <th style="text-align:center" class="col-md-1">Aksi</th>
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
                                <td style="text-align:center"><%# Eval("KPIH_TAHUN") %></td>
                                <td><%#Eval("KPIH_TIPEA")%></td>
                                <td><%#Eval("KPIH_TIPEB")%></td>
                                <td><%#Eval("KPIH_APPVHRDTGL")%></td>
                                <td style="text-align:center"><%#Eval("KPIH_NILAI")%></td>
                                <td style="text-align:center"><%#Eval("KPIH_ABJAD")%></td>
                                <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>Data KPI Tahunan Tidak diketemukan</EmptyDataTemplate> 
                        <EmptyItemTemplate>Data KPI Tahunan Tidak diketemukan</EmptyItemTemplate>              
                    </asp:ListView>

                </asp:View> 
            </asp:MultiView> 
            <asp:MultiView ID="MultiViewKpiMasterEntry" runat="server" Visible="TRUE">
                <asp:View ID="View3" runat="server">  
                    <div class="container">
                        <center>
                            <h3 style="font-family:Blunter;">DETAIL KEY PERFORMANCE INDICATOR (KPI)</h3>
                        </center>
	                </div><br />
                    <table class="table table-borderless">
                        <tr>
                            <td class="col-md-2"></td> 
                            <td class="col-md-2"><asp:Label ID="Label69" runat="server" Text="Tahun Berikutnya"></asp:Label></td>
                            <td class="col-md-4">
                                <asp:TextBox ID="TxtKpiSummaryTahun" runat="server" MaxLength="4" Text ="" class="form-control required"></asp:TextBox>
                                <asp:Label ID="lblKpiSummaryTahun" runat="server" Text="Tipe"></asp:Label>
                            </td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label71" runat="server" Text="Tipe [A]Percobaan [B]Karyawan"></asp:Label></td>
                            <td class="col-md-4">
                                <asp:TextBox ID="TxtKpiSummaryPosA" runat="server" MaxLength="1" Text ="" class="form-control required"></asp:TextBox>
                                <asp:Label ID="lblKpiSummaryPosA" runat="server" Text="Tipe"></asp:Label>
                            </td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label59" runat="server" Text="Level [A]Staff [B]Atasan/SPV"></asp:Label></td>
                            <td class="col-md-4">
                                <asp:TextBox ID="TxtKpiSummaryPosB" runat="server" MaxLength="1" Text ="" class="form-control required"></asp:TextBox>
                                <asp:Label ID="lblKpiSummaryPosB" runat="server" Text="Tipe"></asp:Label>
                            </td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label72" runat="server" Text="Copy Ke Tahun Tahun"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtKpiSummaryTahunNext" runat="server" MaxLength="4" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                    </table> 
                    <center>
                        <asp:Label ID="Label126" runat="server" Text=""></asp:Label>
                    </center>
                    <center>
                        <asp:Button ID="BtnKpi40MasterCopy" runat="server" Text="Copy" class="btn btn-default" />
                        <asp:Button ID="BtnKpi40MasterNew" runat="server"  Text="Buat Baru" class="btn btn-success" />
                        <asp:Button ID="BtnKpi40MasterDel" runat="server" Text="Hapus" class="btn btn-danger" />
                        <asp:Button ID="BtnKpi40MasterBack" runat="server" Text="Kembali Ke Tabel" class="btn btn-warning" />
                    </center>              
                </asp:View> 
            </asp:MultiView> 

            <asp:MultiView ID="MultiViewKPIMasterDetail" runat="server" Visible="TRUE">
                <asp:View ID="ViewTampilKpiMasterDetail" runat="server">  
                    <br /><br />
                    <div class="container">
                        <center>
                            <h3 style="font-family:Blunter;">DATA PENCAPAIAN TAHUNAN</h3>
                        </center>
	                </div><br />
                    <asp:Button ID="BtnKpi40" runat="server" Text="(+) Tambah Pencapaian Tahunan" class="btn btn-primary"/>
                    <br /><br />
                    <asp:SqlDataSource ID="SqlDataKpiMaster" runat="server"
                        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                        SelectCommand="SELECT [KPID_NIK], [KPID_TAHUN],[KPID_ITEM],[KPID_TARGET], [KPID_PRESTASI], [KPID_TYPEA],[KPID_BULAN01],  [KPID_BULAN02], [KPID_BULAN03], [KPID_BULAN04], [KPID_BULAN05], [KPID_BULAN07], [KPID_BULAN06], [KPID_BULAN08], [KPID_BULAN09], [KPID_BULAN10], [KPID_BULAN11], [KPID_BULAN12] FROM [TRXN_KPID] WHERE ([KPID_NIK] = ?) AND ([KPID_TAHUN] = ?)"
                        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TxtStaffNIK" Name="KPID_NIK" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="TxtKpiSummaryTahun" Name="KPID_TAHUN" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>                                     
                    <asp:ListView ID="LvKPIMasterDetail" runat="server" DataSourceID="SqlDataKpiMaster" DataKeyNames ="KPID_ITEM">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered striped" align="left">
                            <tr style="background-color:#E8E8E8">
                                <th rowspan="2" style="text-align:center" class="col-md-1">No.</th>
                                <th rowspan="2" style="text-align:center">Item</th>
                                <th rowspan="2" style="text-align:center">Tahun</th>
                                <th rowspan="2" style="text-align:center">Target</th>
                                <th rowspan="2" style="text-align:center">Prestasi</th>
                                <th colspan="12">Bulan</th>
                                <th rowspan="2" style="text-align:center" class="col-md-1">Aksi</th>
                            </tr>         
                            <tr style="background-color:#E8E8E8">
                                <th style="text-align:center">1</th>
                                <th style="text-align:center">2</th>
                                <th style="text-align:center">3</th>
                                <th style="text-align:center">4</th>
                                <th style="text-align:center">5</th>
                                <th style="text-align:center">6</th>
                                <th style="text-align:center">7</th>
                                <th style="text-align:center">8</th>
                                <th style="text-align:center">9</th>
                                <th style="text-align:center">10</th>
                                <th style="text-align:center">11</th>
                                <th style="text-align:center">12</th>
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
                        <td><%# Eval("KPID_ITEM") %></td>
                        <td style="text-align:center"><%#Eval("KPID_TAHUN")%></td>
                        <td style="text-align:center"><%#Eval("KPID_TARGET")%></td>
                        <td style="text-align:center"><%#Eval("KPID_PRESTASI")%></td>
                        <td style="text-align:center"><%#Eval("KPID_BULAN01")%></td>
                        <td style="text-align:center"><%#Eval("KPID_BULAN02")%></td>
                        <td style="text-align:center"><%#Eval("KPID_BULAN03")%></td>
                        <td style="text-align:center"><%#Eval("KPID_BULAN04")%></td>
                        <td style="text-align:center"><%#Eval("KPID_BULAN05")%></td>
                        <td style="text-align:center"><%#Eval("KPID_BULAN06")%></td>
                        <td style="text-align:center"><%#Eval("KPID_BULAN07")%></td>
                        <td style="text-align:center"><%#Eval("KPID_BULAN08")%></td>
                        <td style="text-align:center"><%#Eval("KPID_BULAN09")%></td>
                        <td style="text-align:center"><%#Eval("KPID_BULAN10")%></td>
                        <td style="text-align:center"><%#Eval("KPID_BULAN11")%></td>
                        <td style="text-align:center"><%#Eval("KPID_BULAN12")%></td>
                        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>Item Kpi Tahunan Tidak diketemukan</EmptyDataTemplate> 
                <EmptyItemTemplate>Item Kpi Tahunan Tidak diketemukan</EmptyItemTemplate>              
            </asp:ListView>
            <br />    
           </asp:View> 
        </asp:MultiView> 
        <asp:MultiView ID="MultiViewKPIMasterDetailENtry" runat="server" Visible="TRUE">
            <asp:View ID="ViewKPIMasterENtry" runat="server">  
                <br />
                <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">DETAIL PENCAPAIAN TAHUNAN</h3>
                    </center>
	            </div><br />  
                <table class="table table-borderless">
                    <tr>
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label91" runat="server" Text="Item"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiItem" runat="server" MaxLength="200" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label60" runat="server" Text="Target"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiTarget" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label61" runat="server" Text="Prestasi"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiPrestasi" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label78" runat="server" Text="Nilai Bulan 1"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiBln01" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label79" runat="server" Text="Nilai Bulan 2"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiBln02" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label80" runat="server" Text="Nilai Bulan 3"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiBln03" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label81" runat="server" Text="Nilai Bulan 4"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiBln04" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label82" runat="server" Text="Nilai Bulan 5"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiBln05" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label83" runat="server" Text="Nilai Bulan 6"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiBln06" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label84" runat="server" Text="Nilai Bulan 7"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiBln07" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label85" runat="server" Text="Nilai Bulan 8"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiBln08" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td><asp:Label ID="Label86" runat="server" Text="Nilai Bulan 9"></asp:Label></td>
                        <td><asp:TextBox ID="TxtMasterKpiBln09" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label87" runat="server" Text="Nilai Bulan 10"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiBln10" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label88" runat="server" height= "21px" Text="Nilai Bulan 11"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiBln11" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label89" runat="server" Text="Nilai Bulan 12"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiBln12" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                </table> 
                <center>
                    <asp:Label ID="LblErrorSaveKpi40" runat="server" Text="" style="color:red"></asp:Label>
                </center>
                <center>
                    <asp:Button ID="BtnKpi40Back" runat="server" Text="Kembali Ke Tabel" class="btn btn-warning" />
                    <asp:Button ID="BtnKpi40Save" runat="server" Text="Simpan" class="btn btn-success" />
                    <asp:Button ID="BtnKpi40Del" runat="server" Text="Hapus" class="btn btn-danger" />
                </center><br /><br />          
            </asp:View> 
        </asp:MultiView>            
      
        <asp:MultiView ID="MultiKPISkillATabel" runat="server" Visible="TRUE">
            <asp:View ID="ViewSkillATabel" runat="server">  
                <br />
                 <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">DATA TARGET KPI</h3>
                    </center>
	            </div><br />
                <asp:Button ID="BtnKpi41A" runat="server" Text="(+) Tambah Data Target KPI" class="btn btn-primary" />
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSkillA" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [KPID_NIK], [KPID_TAHUN], [KPID_ITEM], [KPID_TARGET], [KPID_PRESTASI], [KPID_TYPEA], [KPID_NILAISTAFF], [KPID_NILAIATASAN], [KPID_NILAIAKHIR] FROM [TRXN_KPID] WHERE ([KPID_NIK] = ?)"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtStaffNIK" Name="KPID_NIK" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>                                     
                <asp:ListView ID="LvSkillA" runat="server" DataSourceID="SqlDataSkillA" DataKeyNames ="KPID_ITEM">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered striped" align="left">
                            <thead style="background-color:#E8E8E8">
                                <th style="text-align:center" class="col-md-1">No.</th>
                                <th style="text-align:center">Item</th>
                                <th style="text-align:center">Target</th>
                                <th style="text-align:center">Staff</th>
                                <th style="text-align:center">Atasan</th>
                                <th style="text-align:center">Akhir</th>
                                <th style="text-align:center" class="col-md-1">Aksi</th>
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
                            <td><%# Eval("KPID_ITEM") %></td>
                            <td style="text-align:center"><%#Eval("KPID_TARGET")%></td>
                            <td style="text-align:center"><%#Eval("KPID_NILAISTAFF")%></td>
                            <td style="text-align:center"><%#Eval("KPID_NILAIATASAN")%></td>
                            <td style="text-align:center"><%#Eval("KPID_NILAIAKHIR")%></td>
                            <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Skill A Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Skill A Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br />
            </asp:View> 
        </asp:MultiView>            
        <asp:MultiView ID="MultiKPISkillAEntry" runat="server" Visible="TRUE">
            <asp:View ID="ViewKPISkillAEntry" runat="server">  
                <br />
                 <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">DETAIL TARGET KPI</h3>
                    </center>
	            </div><br />  
                <table class="table table-borderless">
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label104" runat="server" Text="Item"></asp:Label></td>
                        <td class="col-md-4"><asp:Label ID="LblSkillAItem" runat="server" Text="Item" ForeColor="Black"></asp:Label></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label105" runat="server" Text="Target"></asp:Label></td>
                        <td class="col-md-4"><asp:Label ID="lblSkillATarget" runat="server" Text="Item"></asp:Label></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label106" runat="server" Text="Nilai Staff"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtSkillASTaff" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label107" runat="server" Text="Atasan"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtSkillAAtasan" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label108" runat="server" Text="Nilai Akhir"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtSkillAkhir" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                </table> 
                <center>
                    <asp:Label ID="LblErrorSaveKpi41A" runat="server" Text="" style="color:red"></asp:Label>
                </center>
                <center>
                    <asp:Button ID="BtnKpi41ABack" runat="server" Text="Kembali" class="btn btn-warning" />
                    <asp:Button ID="BtnKpi41ASave" runat="server" Text="Simpan" class="btn btn-success" />  
                 </center><br />         
            </asp:View> 
        </asp:MultiView>  

        <asp:MultiView ID="MultiKpiSkillBTabel" runat="server" Visible="TRUE">
            <asp:View ID="ViewKPISkillB" runat="server">  
                <br />
                 <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">DATA HASIL KPI</h3>
                    </center>
	            </div><br />
                <asp:Button ID="BtnKpi41B" runat="server" Text="(+) Tambah Hasil Item KPI" class="btn btn-primary" />
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSkillB" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [KPID_NIK], [KPID_TAHUN], [KPID_ITEM], [KPID_TARGET], [KPID_PRESTASI], [KPID_TYPEA], [KPID_NILAISTAFF], [KPID_NILAIATASAN], [KPID_NILAIAKHIR] FROM [TRXN_KPID] WHERE (([KPID_NIK] = ?) AND ([KPID_TAHUN] = ?))"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtStaffNIK" Name="KPID_NIK" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="lblKpiSummaryTahun" Name="KPID_TAHUN" 
                            PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>                                     
                <asp:ListView ID="LvSkillB" runat="server" DataSourceID="SqlDataSkillB" DataKeyNames ="KPID_ITEM">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered striped" align="left">
                            <thead style="background-color:#E8E8E8">
                                <th style="text-align:center" class="col-md-1">No.</th>
                                <th style="text-align:center">Item</th>
                                <th style="text-align:center">Bobot</th>
                                <th style="text-align:center">Prestasi</th>
                                <th style="text-align:center">Nilai</th>
                                <th style="text-align:center" class="col-md-1">Aksi</th>
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
                            <td style="text-align:center"><%# Eval("KPID_ITEM") %></td>
                            <td style="text-align:center"><%#Eval("KPID_NILAISTAFF")%></td>
                            <td style="text-align:center"><%#Eval("KPID_NILAIATASAN")%></td>
                            <td style="text-align:center"><%#Eval("KPID_NILAIAKHIR")%></td>
                            <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Skill B Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Skill B Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                    <br />
            </asp:View> 
        </asp:MultiView>            
        <asp:MultiView ID="MultiKpiSkillBENtry" runat="server" Visible="TRUE">
            <asp:View ID="ViewKPISkillBENtry" runat="server">    
                <table class="table table-borderless">
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label109" runat="server" Text="Item"></asp:Label></td>
                        <td class="col-md-4"><asp:Label ID="LblSkilBItem" runat="server" Text="Item"></asp:Label></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label110" runat="server" Text="Bobot"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtSkilBBobot" runat="server" MaxLength="200" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label111" runat="server" Text="Prestasi"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtSkilBPrestasi" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label112" runat="server" Text="Nilai"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtSkilBNilai" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                </table> 
                <center>
                    <asp:Label ID="LblErrorSaveKpi41B" runat="server" Text="" style="color:red"></asp:Label>
                </center>
                <center>
                        <asp:Button ID="BtnKpi41BBack" runat="server" Text="Kembali" class="btn btn-warning" />
                        <asp:Button ID="BtnKpi41BSave" runat="server" Text="Simpan" class="btn btn-success" />  
                 </center><br />          
            </asp:View> 
        </asp:MultiView>  

        <asp:MultiView ID="MultiViewProsesTabel" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">  
                <br />
                 <div class="container">
                        <center>
                            <h3 style="font-family:Blunter;">DATA HASIL ITEM PROSES</h3>
                        </center>
	                </div><br /><br />
                    <asp:Button ID="BtnKpi42A" runat="server" Text="(+) Tambah Hasil Item Proses" class="btn btn-primary" />
                    <br /><br />
                 <asp:SqlDataSource ID="SqlDataProses" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT DATA_KPIN.KPIN_JUDUL, TRXN_KPIDD.KPI_NIK, TRXN_KPIDD.KPI_TARGET, TRXN_KPIDD.KPI_STAFF, TRXN_KPIDD.KPI_ATASAN, TRXN_KPIDD.KPI_TIPEA, TRXN_KPIDD.KPI_AKHIR, TRXN_KPIDD.KPI_TAHUN, TRXN_KPIDD.KPI_KODEITEM FROM TRXN_KPIDD LEFT OUTER JOIN DATA_KPIN ON TRXN_KPIDD.KPI_KODEITEM = DATA_KPIN.KPIN_TIPE WHERE (TRXN_KPIDD.KPI_TIPEA = 'A') AND (TRXN_KPIDD.KPI_NIK = ?) AND (TRXN_KPIDD.KPI_TAHUN = ?)"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtStaffNIK" Name="KPI_NIK" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="TxtKpiSummaryTahun" Name="KPI_TAHUN" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>                                     
                <asp:ListView ID="LVProses" runat="server" DataSourceID="SqlDataProses" DataKeyNames ="KPI_KODEITEM">
                    <LayoutTemplate>
                        <table id="table-a"   class="table table-bordered striped" align="left">
                            <thead style="background-color:#E8E8E8">
                                <th style="text-align:center" class="col-md-1">No.</th>
                                <th style="text-align:center">Kode</th>
                                <th style="text-align:center">Item</th>
                                <th style="text-align:center">Staff</th>
                                <th style="text-align:center">Atasan</th>
                                <th style="text-align:center">Akhir</th>
                                <th style="text-align:center" class="col-md-1">Lihat Detail</th>
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
                            <td style="text-align:center"><%# Eval("KPI_KODEITEM") %></td>
                            <td><%#Eval("KPIN_JUDUL")%></td>
                            <td style="text-align:center"><%#Eval("KPI_STAFF")%></td>
                            <td style="text-align:center"><%#Eval("KPI_ATASAN")%></td>
                            <td style="text-align:center"><%#Eval("KPI_AKHIR")%></td>
                            <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Proses Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Proses Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br />
               
            </asp:View> 
        </asp:MultiView>            
        <asp:MultiView ID="MultiViewProsesEntry" runat="server" Visible="TRUE">
            <asp:View ID="ViewKerjaAEntry" runat="server">   
                <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">DETAIL HASIL ITEM PROSES</h3>
                    </center>
	            </div><br /><br /> 
                <table class="table table-borderless">
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label63" runat="server" Text="Item"></asp:Label></td>
                        <td class="col-md-4"><asp:Label ID="LblProsesKodeItem" runat="server" Text="Item"></asp:Label>
                            <asp:Label ID="LblProsesJudulJudul" runat="server" Text="Item"></asp:Label>
                        </td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label64" runat="server" Text="Nilai Staff"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtProsesStaff" runat="server" MaxLength="5" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label65" runat="server" Text="Nilai Atasan"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtProsesHead" runat="server" MaxLength="5" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label113" runat="server" Text="Akhir"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtProsesAkhir" runat="server" MaxLength="5" Text ="" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2"></td>
                    </tr>
                </table> 
                <center>
                    <asp:Label ID="LblErrorSaveKpi42A" runat="server" Text="" style="color:red"></asp:Label>
                </center>
                <center>
                    <asp:Button ID="BtnKpi42ABack" runat="server" Text="Kembali Ke Tabel" class="btn btn-warning" />
                    <asp:Button ID="BtnKpi42ASave" runat="server" Text="Simpan" class="btn btn-success" />
               </center><br />          
            </asp:View> 
        </asp:MultiView>  

        <asp:MultiView ID="MultiViewPeopleTabel" runat="server" Visible="TRUE">
            <asp:View ID="ViewKerjaBT" runat="server">  
                <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">DATA HASIL ITEM PEOPLE MANAGEMENT</h3>
                    </center>
	            </div><br />
                <asp:Button ID="BtnKpi42" runat="server" Text="(+) Tambah Hasil Item People Management" class="btn btn-primary" />
               <br /><br />
                <asp:SqlDataSource ID="SqlDataPeople" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT DATA_KPIN.KPIN_JUDUL, TRXN_KPIDD.KPI_NIK, TRXN_KPIDD.KPI_TARGET, TRXN_KPIDD.KPI_STAFF, TRXN_KPIDD.KPI_ATASAN, TRXN_KPIDD.KPI_TIPEA, TRXN_KPIDD.KPI_AKHIR, TRXN_KPIDD.KPI_TAHUN, TRXN_KPIDD.KPI_KODEITEM FROM TRXN_KPIDD LEFT OUTER JOIN DATA_KPIN ON TRXN_KPIDD.KPI_KODEITEM = DATA_KPIN.KPIN_TIPE WHERE (TRXN_KPIDD.KPI_TIPEA = 'C') AND (TRXN_KPIDD.KPI_NIK = ?) AND (TRXN_KPIDD.KPI_TAHUN = ?)"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtStaffNIK" Name="KPI_NIK" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="TxtKpiSummaryTahun" Name="KPI_TAHUN" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>                                     
                <asp:ListView ID="LVPeople" runat="server" DataSourceID="SqlDataPeople" DataKeyNames ="KPI_KODEITEM">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered striped" align="left">
                            <thead style="background-color:#E8E8E8">
                                <th style="text-align:center" class="col-md-1">No.</th>
                                <th style="text-align:center">Kode</th>
                                <th style="text-align:center">Item</th>
                                <th style="text-align:center">Staff</th>
                                <th style="text-align:center">Atasan</th>
                                <th style="text-align:center">Akhir</th>
                                <th style="text-align:center" class="col-md-1">Lihat Detail</th>
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
                            <td><%# Eval("KPI_KODEITEM") %></td>
                            <td><%#Eval("KPIN_JUDUL")%></td>
                            <td><%#Eval("KPI_STAFF")%></td>
                            <td><%#Eval("KPI_ATASAN")%></td>
                            <td><%#Eval("KPI_AKHIR")%></td>
                            <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data People Management Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data People Management Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br />

                </asp:View> 
            </asp:MultiView>            
            <asp:MultiView ID="MultiViewPeopleEntry" runat="server" Visible="TRUE">
                <asp:View ID="ViewKpiKerjaBE" runat="server">    
                    <br />
                    <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">DETAIL HASIL ITEM PEOPLE MANAGEMENT</h3>
                    </center>
	            </div><br />
                    <table class="table table-borderless">
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label115" runat="server" Text="Item"></asp:Label></td>
                            <td class="col-md-4">
                               <asp:Label ID="LblPeopleKode" runat="server" Text="Item"></asp:Label>
                               <asp:Label ID="LblPeopleJudul" runat="server" Text="Item"></asp:Label>
                            </td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label117" runat="server" Text="Staff"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtPeopleStaff" runat="server" MaxLength="5" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label118" runat="server" Text="Atasan"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtPeopleAtasan" runat="server" MaxLength="5" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label114" runat="server" Text="Akhir"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtPeopleAKhir" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                    </table> 
                    <center>
                        <asp:Label ID="LblErrorSaveKpi42B" runat="server"  Text="" style="color:red"></asp:Label>
                    </center>
                    <center>
                        <asp:Button ID="BtnKpi42BBack" runat="server" Text="Kembali Ke Tabel" class="btn btn-warning" />
                        <asp:Button ID="BtnKpi42BSave" runat="server" Text="Simpan" class="btn btn-success" />
                    
                    </center>                
                </asp:View> 
            </asp:MultiView>  

            <asp:MultiView ID="MultiViewDisiplin" runat="server" Visible="TRUE">
                <asp:View ID="ViewDisiplin" runat="server">
                    <div class="container">
                        <center>
                            <h3 style="font-family:Blunter;">DATA HASIL ITEM DISIPLIN</h3>
                        </center>
	                </div><br />         
                    <asp:Button ID="BtnKpi43" runat="server" Text="(+) Tambah Hasil Item Disiplin" class="btn btn-primary" />    
                    <br /><br />
                    <asp:SqlDataSource ID="SqlDataDisiplin" runat="server"
                        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                        SelectCommand="SELECT DATA_KPIN.KPIN_JUDUL, TRXN_KPIDD.KPI_NIK, TRXN_KPIDD.KPI_TARGET, TRXN_KPIDD.KPI_STAFF, TRXN_KPIDD.KPI_ATASAN, TRXN_KPIDD.KPI_TIPEA, TRXN_KPIDD.KPI_AKHIR, TRXN_KPIDD.KPI_TAHUN, TRXN_KPIDD.KPI_KODEITEM FROM TRXN_KPIDD LEFT OUTER JOIN DATA_KPIN ON TRXN_KPIDD.KPI_KODEITEM = DATA_KPIN.KPIN_TIPE WHERE (TRXN_KPIDD.KPI_TIPEA = 'C') AND (TRXN_KPIDD.KPI_NIK = ?) AND (TRXN_KPIDD.KPI_TAHUN = ?)"
                        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TxtStaffNIK" Name="KPI_NIK" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="TxtKpiSummaryTahun" Name="KPI_TAHUN" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>                                     
                    <asp:ListView ID="LvDisiplin" runat="server" DataSourceID="SqlDataDisiplin" DataKeyNames ="KPI_KODEITEM">
                        <LayoutTemplate>
                            <table id="table-a" class="table table-bordered striped" align="left">
                                <thead style="background-color:#E8E8E8">
                                    <th style="text-align:center" class="col-md-1">No.</th>
                                    <th style="text-align:center">Kode</th>
                                    <th>Item</th>
                                    <th>Frekwensi</th>
                                    <th style="text-align:center" class="col-md-1">Lihat Detail</th>
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
                                <td style="text-align:center"><%# Eval("KPI_KODEITEM") %></td>
                                <td><%#Eval("KPIN_JUDUL")%></td>
                                <td style="text-align:center"><%#Eval("KPI_AKHIR")%></td>
                                <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL'  CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>Data Karyawan Tidak diketemukan</EmptyDataTemplate> 
                        <EmptyItemTemplate>Data Karyawan Tidak diketemukan</EmptyItemTemplate>              
                    </asp:ListView>
                    <br />
                       
                </asp:View> 
            </asp:MultiView>            
            
            <asp:MultiView ID="MultiViewDisplinEntry" runat="server" Visible="TRUE">
                <asp:View ID="ViewDisplinE" runat="server">   
                    <div class="container">
                        <center>
                            <h3 style="font-family:Blunter;">DETAIL HASIL ITEM DISIPLIN</h3>
                        </center>
	                </div><br />     
                    <table class="table table-borderless">
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label119" runat="server" Text="Item"></asp:Label></td>
                            <td class="col-md-4">
                               <asp:Label ID="lblDisiplinKode" runat="server" Text="Item"></asp:Label>
                               <asp:Label ID="lblDisiplinJudul" runat="server" Text="Item"></asp:Label>
                            </td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label120" runat="server" Text="Bobot"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtDisiplinNilai" runat="server" MaxLength="200" Text ="" class="form-control required"></asp:TextBox></td>
                            <td class="col-md-2"></td>
                        </tr>
                    </table> 
                    <center>
                        <asp:Label ID="LblErrorSaveKpi43" runat="server" Text="" style="color:red"></asp:Label>
                    </center>
                    <center>
                        <asp:Button ID="BtnKpi43Save" runat="server" Text="Simpan" class="btn btn-success"/>
                        <asp:Button ID="BtnKpi43Back" runat="server" Text="Hapus" class="btn btn-danger" />
                    </center><br />             
                </asp:View> 
            </asp:MultiView>  


            <asp:MultiView ID="MultiViewOthers" runat="server" Visible="TRUE">
                <asp:View ID="View8" runat="server">    
                    <div class="container">
                        <center>
                            <h3 style="font-family:Blunter;">DETAIL PERHITUNGAN</h3>
                        </center>
	                </div><br />  
                    <table class="table table-borderless">
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label121" runat="server" Text="Total Nilai A"></asp:Label></td>
                            <td class="col-md-4"><asp:TextBox ID="TxtKpiPercenNilai1" runat="server" MaxLength="4" Text ="" style="width: 140px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                                <asp:Label ID="Label76" runat="server" Text=" X  "></asp:Label>
                                <asp:TextBox ID="TxtKpiTotalNilai1" runat="server" MaxLength="4" Text ="" style="width: 140px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                                <asp:Label ID="LblNiaiAkhir1" runat="server" Text="0" ForeColor="Black"></asp:Label>
                            </td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label70" runat="server" Text="Total Nilai B"></asp:Label></td>
                            <td class="col-md-4">
                                <asp:TextBox ID="TxtKpiPercenNilai2" runat="server" MaxLength="4" Text ="" style="width: 140px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                                <asp:Label ID="Label77" runat="server" Text=" X  "></asp:Label>
                                <asp:TextBox ID="TxtKpiTotalNilai2" runat="server" MaxLength="4" Text ="" style="width: 140px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                                <asp:Label ID="LblNiaiAkhir2" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label73" runat="server" Text="Total Nilai C"></asp:Label></td>
                            <td class="col-md-4">
                                <asp:TextBox ID="TxtKpiPercenNilai3" runat="server" MaxLength="4" Text ="" style="width: 140px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                                <asp:Label ID="Label95" runat="server" Text=" X  "></asp:Label>
                                <asp:TextBox ID="TxtKpiTotalNilai3" runat="server" MaxLength="4" Text ="" style="width: 140px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                                <asp:Label ID="LblNiaiAkhir3" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label74" runat="server" Text="Total Nilai Akhir A+B+C"></asp:Label></td>
                            <td class="col-md-4"><asp:Label ID="LblNiaiAkhir4" runat="server" Text="0"></asp:Label></td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label122" runat="server" Text="Pemberian Sangsi"></asp:Label></td>
                            <td class="col-md-4">
                                <asp:TextBox ID="TxtNilaiSP" runat="server" MaxLength="200" Text ="" style="width: 140px; height: 40px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                                <asp:DropDownList ID="DropDownList7" runat="server" style="width: 140px; height: 40px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;">
                                    <asp:ListItem>SP1 - 0.5</asp:ListItem>
                                    <asp:ListItem>SP2 - 1.0</asp:ListItem>
                                    <asp:ListItem>SP3 - 1.5</asp:ListItem>
                                </asp:DropDownList>
                               <asp:Label ID="LblNiaiAkhir5" runat="server" Text="Total Nilai Akhir A+B+C"></asp:Label>
                            </td>
                            <td class="col-md-2"></td>
                        </tr>
                        <tr> 
                            <td class="col-md-2"></td>
                            <td class="col-md-2"><asp:Label ID="Label75" runat="server" Text="Total Akhir / Grade"></asp:Label></td>
                            <td class="col-md-4">
                               <asp:Label ID="LblNiaiAkhir6" runat="server" Text="Total Nilai Akhir A+B+C"></asp:Label>
                               <asp:Label ID="LblNiaiAkhir7" runat="server" Text="Total Nilai Akhir A+B+C"></asp:Label>
                            </td>
                            <td class="col-md-2"></td>
                        </tr>
                    </table> 
                    <center>
                        <asp:Label ID="LblErrorSaveKpi44" runat="server" Text="" style="color:red"></asp:Label>
                    </center>
                    <center>
                        <asp:Button ID="BtnKpi44Setuju1" runat="server" Text="Setuju Staff" class="btn btn-success" />
                        <asp:Button ID="BtnKpi44Setuju2" runat="server" Text="Setuju Head" class="btn btn-success" />
                        <asp:Button ID="BtnKpi44Setuju3" runat="server" Text="Setuju HRD" class="btn btn-success" />
                    </center>
                </asp:View> 
            </asp:MultiView>  
            </div>
        </asp:View> 
    </asp:MultiView>    

</asp:Content>