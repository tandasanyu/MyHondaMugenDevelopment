
<%@ Page Language="VB" MasterPageFile ="~/MasterPage.master"  AutoEventWireup="false" CodeFile="HRDFORMKARYAWAN.aspx.vb" Inherits="HRDFORMKARYAWAN" title="Form Karyawan" %>
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
    <script type="text/javascript" src="js/jquery.min.js"></script>
	<script type="text/javascript" src="js/custom.js"></script>
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

        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
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
            <li><a href="#"><i class="glyphicon glyphicon-user"></i></a> &nbsp <a href="#"> HRD</a> </li>
            <li class="active"><span class="glyphicon glyphicon-duplicate"></span> &nbsp Data Karyawan</li>
        </ul>
    
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
								            <center><asp:LinkButton ID="Tab05" runat="server" Text="Data Karyawan"><img class="img-responsive img-center" src="img/karyawan.png" height="150" width="150" alt=""></asp:LinkButton></center>
									    </div>
								        <h4 style="text-align:center">Data Karyawan</h4>
								    </div>
							    </div>
						    </div>
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
								            <asp:LinkButton ID="Tab04" runat="server" Text="Pelatihan"><img class="img-responsive img-center" src="img/pelatihan.png" height="150" width="150" alt=""></asp:LinkButton>
								        </div>
									    <h4>&nbsp &nbsp &nbsp &nbsp Pelatihan</h4>
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

		<asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
			<asp:View ID="Viewerr00" runat="server">
				<asp:Label ID="lblMsgBox" runat="server">Judul Permohonan</asp:Label>
			</asp:View> 
		</asp:MultiView>
		<asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
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
                        <td class="col-md-2"><asp:Label ID="Label21" runat="server" Text="Jenis Kelamin"></asp:Label></td>
                        <td class="col-md-4">
				            <asp:DropDownList ID="TxtJkel" runat="server" class="form-control required">
                                <asp:ListItem></asp:ListItem>
					            <asp:ListItem>L</asp:ListItem>
						        <asp:ListItem>P</asp:ListItem>
					        </asp:DropDownList>
			            </td>
				        <td class="col-md-2"><asp:Label ID="Label10" runat="server" Text="Nomor Kontak Darurat"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStaffNoContact" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:TextBox></td>
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
                        <td><asp:Label ID="Label1" runat="server" Text="Email" ></asp:Label></td>
				        <td><asp:TextBox ID="TxtStaffEmail" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
       
				    </tr>
			        <tr>
                        <td class="col-md-2"><asp:Label ID="Label16" runat="server" Text="Agama"></asp:Label></td>
				        <td class="col-md-4">
				            <asp:DropDownList ID="TxtAgama" runat="server" class="form-control required">
                                <asp:ListItem></asp:ListItem>
					            <asp:ListItem>Islam</asp:ListItem>
						        <asp:ListItem>Kristen</asp:ListItem>
						        <asp:ListItem>Katolik</asp:ListItem>
						        <asp:ListItem>Hindu</asp:ListItem>
						        <asp:ListItem>Budha</asp:ListItem>
						        <asp:ListItem>Konghucu</asp:ListItem>
					        </asp:DropDownList>
			            </td>
				        <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="No. KTP"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStaffNoKtp" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:TextBox></td>
			        </tr>
				    <tr>
                        <td class="col-md-2"><asp:Label ID="Label22" runat="server" Text="Golongan Darah"></asp:Label></td>
				        <td class="col-md-4">
				            <asp:DropDownList ID="TxtDarah" runat="server" class="form-control required">
                                <asp:ListItem></asp:ListItem>
					            <asp:ListItem>A</asp:ListItem>
						        <asp:ListItem>B</asp:ListItem>
                                <asp:ListItem>AB</asp:ListItem>
                                <asp:ListItem>O</asp:ListItem>
					        </asp:DropDownList>
			            </td>
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
			        </tr>
			        <tr>
                        <td class="col-md-2"><asp:Label ID="Label40" runat="server" Text="Alamat"></asp:Label></td>
				        <td class="col-md-4"><asp:TextBox ID="TxtStaffJalan" runat="server" MaxLength="80" Text ="" class="form-control required"></asp:TextBox></td>
				        <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Jenis/No. SIM"></asp:Label></td>
				        <td class="col-md-4"><asp:DropDownList ID="TxtStaffSIMType" runat="server" style="width: 145px; height: 40px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" MaxLength="2" TabIndex ="7"> 
                                <asp:ListItem></asp:ListItem>
					            <asp:ListItem>A</asp:ListItem>
						        <asp:ListItem>B1</asp:ListItem>
						        <asp:ListItem>B2</asp:ListItem>
						        <asp:ListItem>C</asp:ListItem>
						        <asp:ListItem>D</asp:ListItem>
					        </asp:DropDownList> /
                            <asp:TextBox ID="TxtStaffSIMNomor" runat="server" MaxLength="20" TabIndex ="7" Text ="" style="width: 145px; height: 40px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
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
					    <td class="col-md-2"><asp:Label ID="Label34" runat="server" Text="Department"></asp:Label></td>
					    <td class="col-md-4">
                            <asp:DropDownList ID="TxtStatusKerjaDept" runat="server" class="form-control required">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Administrasi</asp:ListItem>
					            <asp:ListItem>Internal Audit</asp:ListItem>
						        <asp:ListItem>CC</asp:ListItem>
						        <asp:ListItem>HRD&GA</asp:ListItem>
                                <asp:ListItem>ISO</asp:ListItem>
                                <asp:ListItem>IT</asp:ListItem>
                                <asp:ListItem>Direksi</asp:ListItem>
                                <asp:ListItem>Operation Support</asp:ListItem>
                                <asp:ListItem>Purchasing</asp:ListItem>
                                <asp:ListItem>Sales</asp:ListItem>
                                <asp:ListItem>Service</asp:ListItem>
                                <asp:ListItem>Sparepart</asp:ListItem>
                                <asp:ListItem>Warehouse</asp:ListItem>
					        </asp:DropDownList>
					    </td>
				    </tr>
		            <tr>
				        <td class="col-md-2"><asp:Label ID="Label35" runat="server" Text="Lokasi Penempatan"></asp:Label></td>
				        <td class="col-md-4"> <asp:DropDownList ID="TxtStatusKerjaTempat" runat="server" class="form-control required">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Cikupa</asp:ListItem>
					            <asp:ListItem>Ciledug</asp:ListItem>
						        <asp:ListItem>Dadap</asp:ListItem>
						        <asp:ListItem>HO</asp:ListItem>
                                <asp:ListItem>Meruya</asp:ListItem>
                                <asp:ListItem>Mugen Ps. Minggu</asp:ListItem>
                                <asp:ListItem>Mugen Puri</asp:ListItem>
					        </asp:DropDownList>
                        </td> 
				        <td class="col-md-2"><asp:Label ID="Label33" runat="server" Text="Jabatan"></asp:Label></td>
				        <td class="col-md-4"><asp:DropDownList ID="TxtStatusKerjaJabatan" runat="server" class="form-control" > 
                                <asp:ListItem></asp:ListItem>
								<asp:ListItem>Admin Faktur</asp:ListItem>
								<asp:ListItem>Admin Head</asp:ListItem>
								<asp:ListItem>Admin Hutang</asp:ListItem>
								<asp:ListItem>Admin Piutang Service</asp:ListItem>
								<asp:ListItem>Admin Piutang Showroom</asp:ListItem>
								<asp:ListItem>Admin Piutang B/P</asp:ListItem>
								<asp:ListItem>Admin Stock</asp:ListItem>
								<asp:ListItem>Admin Warehouse</asp:ListItem>
								<asp:ListItem>Asisten GA</asp:ListItem>
								<asp:ListItem>Collector</asp:ListItem>
								<asp:ListItem>Director</asp:ListItem>
								<asp:ListItem>Driver Service</asp:ListItem>
								<asp:ListItem>Driver Warehouse</asp:ListItem>
								<asp:ListItem>Final Inspection</asp:ListItem>
								<asp:ListItem>Foreman GR</asp:ListItem>
								<asp:ListItem>HRD & GA Head</asp:ListItem>
								<asp:ListItem>Internal Audit</asp:ListItem>
								<asp:ListItem>IT Head</asp:ListItem>
								<asp:ListItem>IT Staff</asp:ListItem>
								<asp:ListItem>Junior Sales Executive</asp:ListItem>
								<asp:ListItem>Kasir Service</asp:ListItem>
								<asp:ListItem>Kasir Showroom</asp:ListItem>
								<asp:ListItem>Kepala Sparepart</asp:ListItem>
								<asp:ListItem>Komisaris</asp:ListItem>
								<asp:ListItem>Koord. Sales</asp:ListItem>
								<asp:ListItem>Koord. Warehouse</asp:ListItem>
								<asp:ListItem>Leader Quick Service</asp:ListItem>
								<asp:ListItem>Management Representative</asp:ListItem>
								<asp:ListItem>OB Freelance</asp:ListItem>
								<asp:ListItem>Office Boy</asp:ListItem>
								<asp:ListItem>Operational Support Manager</asp:ListItem>
								<asp:ListItem>PJS. SPV Accounting</asp:ListItem>
								<asp:ListItem>PJS. SPV HRD</asp:ListItem>
								<asp:ListItem>PJS. Staff Warehouse</asp:ListItem>
								<asp:ListItem>Programmer</asp:ListItem>
								<asp:ListItem>Quality Control BP</asp:ListItem>
								<asp:ListItem>Sales Counter A</asp:ListItem>
								<asp:ListItem>Sales Counter B</asp:ListItem>
								<asp:ListItem>Sales Counter Trn</asp:ListItem>
								<asp:ListItem>Sales Executive</asp:ListItem>
								<asp:ListItem>Sales Manager</asp:ListItem>
								<asp:ListItem>Sales Supervisor</asp:ListItem>
								<asp:ListItem>Salvage</asp:ListItem>
								<asp:ListItem>Senior Sales Counter</asp:ListItem>
								<asp:ListItem>Service Advisor BP</asp:ListItem>
								<asp:ListItem>Service Advisor GR</asp:ListItem>
								<asp:ListItem>Service Manager</asp:ListItem>
								<asp:ListItem>SPV Customer Care</asp:ListItem>
								<asp:ListItem>SPV Finance</asp:ListItem>
								<asp:ListItem>SPV GA</asp:ListItem>
								<asp:ListItem>Staff Accounting</asp:ListItem>
								<asp:ListItem>Staff Aksesoris</asp:ListItem>
								<asp:ListItem>Staff Care Center</asp:ListItem>
								<asp:ListItem>Staff Customer Care</asp:ListItem>
								<asp:ListItem>Staff Customer Relation</asp:ListItem>
								<asp:ListItem>Staff GA</asp:ListItem>
								<asp:ListItem>Staff HRD</asp:ListItem>
								<asp:ListItem>Staff ISO</asp:ListItem>
								<asp:ListItem>Staff Jurnal Bank</asp:ListItem>
								<asp:ListItem>Staff Jurnal Kas</asp:ListItem>
								<asp:ListItem>Staff Pajak</asp:ListItem>
								<asp:ListItem>Staff PDI</asp:ListItem>
								<asp:ListItem>Staff People Dev.</asp:ListItem>
								<asp:ListItem>Staff Purchase</asp:ListItem>
								<asp:ListItem>Staff Rekrutmen</asp:ListItem>
								<asp:ListItem>Staff Sparepart</asp:ListItem>
								<asp:ListItem>Staff Warehouse</asp:ListItem>
								<asp:ListItem>Teknisi</asp:ListItem>    
								<asp:ListItem>Teknisi Aksesoris</asp:ListItem>  
								<asp:ListItem>Vice President Director</asp:ListItem>  
                            </asp:DropDownList>
				        </td>
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
			    <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-bookmark"></span> Pendidikan Yang Sedang Dijalani</h3> 
			    <br />
                <table class="table table-borderless" align="left">
                    <tr>
                        <td style="width:10%"><asp:Label ID="Label23" runat="server" Text="Nama Institusi"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtPendidikanLanjutNama" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:10%"><asp:Label ID="Label24" runat="server" Text="Semester"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtPendidikanLanjutSemester" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:10%"><asp:Label ID="Label25" runat="server" Text="Jurusan"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtPendidikanLanjutJurusan" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
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
				<center><asp:Label ID="LblErrorSaveA1" runat="server" Text="" style="color:red"></asp:Label>
                   
					<asp:Button ID="ButtonA1Save" runat="server" Text="Simpan" class="btn btn-success" />
		          
				</center>    
				<br />
				<br />
				<br />
				<br />  
	            
            </asp:View> 
        </asp:MultiView>
    </div>
    
    <div class="container">    
        <asp:MultiView ID="MultiView102Detail" runat="server" Visible="TRUE">
            <asp:View ID="View10201PendidikanFormal" runat="server">    
                
                <br />
			    <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-education"></span> Data Pendidikan Formal</h3>
			    <br />
                <asp:Button ID="btnShow" runat="server" Text="Tambah Data" class="button button4" />
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
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white" class="col-md-1">No.</th>
                                <th style="text-align:center; color:white">Tingkat</th>
                                <th style="text-align:center; color:white">Institusi</th>
                                <th style="text-align:center; color:white">Jurusan</th>
                                <th style="text-align:center; color:white">Thn Lulus</th>
                                <th style="text-align:center; color:white">Keterangan</th>
                                <th style="text-align:center; color:white">Ijazah</th>
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
                            <td style="text-align:center"><%# Eval("STAFFFO_TINGKAT") %></td>
                            <td><%#Eval("STAFFFO_NAMA")%></td>
                            <td><%#Eval("STAFFFO_JURUSAN")%></td>
                            <td style="text-align:center"><%#Eval("STAFFFO_TAHUN")%></td>
                            <td><%#Eval("STAFFFO_KET")%></td>
                            <td><%#Eval("STAFFFO_IJAZAH")%></td>
                            <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" OnClientClick="return confirm('Apakah anda yakin akan menghapus data ini?');"><img src="img/delete.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Pendidikan Formal Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Pendidikan Formal Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>    
                <br />

                <!-- ModalPopupExtender -->
                <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
                    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Panel ID="Panel1" runat="server" CssClass="modal-dialog" align="center" style = "display:none">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" ID="btnClose" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Form Pendidikan Formal</h4>
                        </div>
                        <div class="modal-body">
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-3"><asp:Label ID="Label11" runat="server" Text="Tingkat Pendidikan"></asp:Label></td>
                                    <td class="col-md-6"><asp:DropDownList ID="TxtPendidikanTingkat" runat="server" class="form-control required">
					                        <asp:ListItem></asp:ListItem>
						                    <asp:ListItem>SMA/K</asp:ListItem>
					                        <asp:ListItem>D1</asp:ListItem>
						                    <asp:ListItem>D2</asp:ListItem>
                                            <asp:ListItem>D3</asp:ListItem>
                                            <asp:ListItem>S1</asp:ListItem>
                                            <asp:ListItem>S2</asp:ListItem>
					                    </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-3"><asp:Label ID="Label12" runat="server" Text="Nama Institusi"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtPendidikanNama" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-3"><asp:Label ID="Label13" runat="server" Text="Jurusan"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtPendidikanJurusan" runat="server" MaxLength="20" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-3"><asp:Label ID="Label14" runat="server" Text="Tahun Kelulusan"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtPendidikanTahun" runat="server" MaxLength="4" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-3"><asp:Label ID="Label15" runat="server" Text="Keterangan"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtPendidikanKet" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-3"><asp:Label ID="Label68" runat="server" Text="Status Ijazah"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtPendidikanIjazah" runat="server" MaxLength="1" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table> 

                            <center>
                                <asp:Label ID="LblErrorSaveA111" runat="server" Text="" style="color:red"></asp:Label>
                                <asp:Button ID="BtnA111Save" runat="server" Text="Simpan" class="btn btn-success" />
                            </center> <br /><br />  
                        </div>
                    </div>
                </asp:Panel>

                <br />
                <hr />
			    <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-book"></span> Data Pendidikan Non Formal</h3>
		        <br />                       
                <asp:Button ID="btnShow2" runat="server" Text="Tambah Data" class="button button4" />
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
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white" class="col-md-1">No.</th>
                                <th style="text-align:center; color:white">Nama Pelatihan</th>
                                <th style="text-align:center; color:white">Instusi</th>
                                <th style="text-align:center; color:white">Tahun</th>
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
                            <td><%#Eval("STAFFFO_JURUSAN")%></td>
                            <td><%#Eval("STAFFFO_NAMA")%></td>
                            <td style="text-align:center"><%#Eval("STAFFFO_TAHUN")%></td>
                            <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" OnClientClick="return confirm('Apakah anda yakin akan menghapus data ini?');"><img src="img/delete.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Pendidikan Non Formal Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Pendidikan Non Formal Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br />

                <!-- ModalPopupExtender -->
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel2" TargetControlID="btnShow2"
                    CancelControlID="btnClose2" BackgroundCssClass="modalBackground">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Panel ID="Panel2" runat="server" CssClass="modal-dialog" align="center" style = "display:none">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" ID="btnClose2" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Form Pendidikan Non Formal</h4>
                        </div>
                        <div class="modal-body">
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td>  
                                    <td class="col-md-3"><asp:Label ID="Label17" runat="server" Text="Nomor Training"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtDidikNonFormalTingkat" runat="server" MaxLength="2" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td> 
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>  
                                    <td class="col-md-3"><asp:Label ID="Label18" runat="server" Text="Nama Pelatihan"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtDidikNonFormalJudul" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td> 
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>  
                                    <td class="col-md-3"><asp:Label ID="Label19" runat="server" Text="Institusi"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtDidikNonFormalNama" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td> 
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>  
                                    <td class="col-md-3"><asp:Label ID="Label20" runat="server" Text="Tahun Pelatihan"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtDidikNonFormalTahun" runat="server" MaxLength="4" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td> 
                                </tr>
                            </table> 

                            <center>
                                <asp:Label ID="LblErrorSaveA113" runat="server" Text="" style="color:red"></asp:Label>
                                <asp:Button ID="BtnA113Save" runat="server" Text="Simpan" class="btn btn-success" />
                            </center>           
                        </div>
                    </div>
                </asp:Panel>      
            </asp:View> 

            <asp:View ID="View10202Pengalaman" runat="server"> 
                <br />
			    <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-folder-open"></span> Data Pengalaman Kerja</h3>
			    <br />
                <asp:Button ID="BtnShow3" runat="server" Text="Tambah Data" class="button button4" />
                <br />
                <br />
                <asp:SqlDataSource ID="SqlDataPengalanKerja" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [STAFFKR_NIK], [STAFFKR_NAMA], [STAFFKR_ALAMAT], [STAFFKR_JABATAN], CONVERT(varchar,[STAFFKR_KELUAR],105) AS [STAFFKR_KELUAR], CONVERT(varchar,[STAFFKR_MASUK],105) AS [STAFFKR_MASUK] FROM [DATA_STAFFKR] WHERE ([STAFFKR_NIK] = ?)"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblStaffNIK" Name="STAFFKR_NIK" PropertyName="Text" Type="String" />            
                    </SelectParameters>
                </asp:SqlDataSource>                             
                <asp:ListView ID="LVPengalamanKerja" runat="server" DataSourceID="SqlDataPengalanKerja" DataKeyNames ="STAFFKR_NAMA">
                    <LayoutTemplate>
                         <table id="table-a" class="table table-bordered striped" align="left">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white" class="col-md-1">No.</th>
                                <th style="text-align:center; color:white">Perusahaan</th>
                                <th style="text-align:center; color:white">Alamat</th>
                                <th style="text-align:center; color:white">Jabatan</th>
                                <th style="text-align:center; color:white">Masuk</th>
                                <th style="text-align:center; color:white">Keluar</th>
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
                            <td><%# Eval("STAFFKR_NAMA") %></td>
                            <td><%#Eval("STAFFKR_ALAMAT")%></td>
                            <td><%#Eval("STAFFKR_JABATAN")%></td>
                            <td><%#Eval("STAFFKR_MASUK")%></td>
                            <td><%#Eval("STAFFKR_KELUAR")%></td>
                            <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='' CommandName="Select" runat="server" OnClientClick="return confirm('Apakah anda yakin akan menghapus data ini?');"><img src="img/delete.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Riwayat Pekerjaan Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Riwayat Pekerjaan Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
        
        
                <!-- ModalPopupExtender -->
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel3" TargetControlID="btnShow3"
                    CancelControlID="btnClose3" BackgroundCssClass="modalBackground">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Panel ID="Panel3" runat="server" CssClass="modal-dialog" align="center" style = "display:none">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" ID="btnClose3" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Form Pengalaman Kerja</h4>
                        </div>
                        <div class="modal-body">
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td> 
                                    <td class="col-md-3"><asp:Label ID="Label26" runat="server" Text="Nama Perusahaan"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtCompanyNama" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-3"><asp:Label ID="Label58" runat="server" Text="Alamat Perusahaan"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtCompanyAlamat" runat="server" MaxLength="80" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-3"><asp:Label ID="Label27" runat="server" Text="Jabatan"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtCompanyJabatan" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-3"><asp:Label ID="Label28" runat="server" Text="Tanggal Masuk"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtCompanyMasuk" runat="server" MaxLength="15" Text ="" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:TextBox>    
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
                                    <td class="col-md-3"><asp:Label ID="Label30" runat="server" Text="Tanggal Keluar"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtCompanyKeluar" runat="server" MaxLength="15" Text ="" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:TextBox>
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
                                <asp:Button ID="BtnA12Save" runat="server" Text="Simpan" class="btn btn-success" />
                            </center>
                        </div>
                    </div>
                </asp:Panel>        
            </asp:View> 
 
            <asp:View ID="View10204Pelatihan" runat="server">   
                <br />
			    <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-list-alt"></span> Data Pelatihan</h3>
			    <br />
                    <asp:Button ID="btnShow4" runat="server" Text="Tambah Data" class="button button4" />
                <br />
                <br />
       
                <asp:SqlDataSource ID="SqlDataPelatihan" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [STAFFPL_NIK], [STAFFPL_PELATIHAN], [STAFFPL_JENIS], [STAFFPL_NAMA], CONVERT(varchar,[STAFFPL_TGL],105) AS [STAFFPL_TGL], [STAFFPL_BIAYA], [STAFFPL_HASIL] FROM [DATA_STAFFPL] WHERE ([STAFFPL_NIK] = ?)"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblStaffNIK" Name="STAFFPL_NIK" PropertyName="Text" Type="String" />            
                    </SelectParameters>
                </asp:SqlDataSource>                             
                <asp:ListView ID="LVPelatihan" runat="server" DataSourceID="SqlDataPelatihan" DataKeyNames ="STAFFPL_PELATIHAN">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered striped" align="left">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white" class="col-md-1">No.</th>
                                <th style="text-align:center; color:white">Nama</th>
                                <th style="text-align:center; color:white">Jenis</th>
                                <th style="text-align:center; color:white">Instutusi</th>
                                <th style="text-align:center; color:white">Tgl Pelatihan</th>
                                <th style="text-align:center; color:white">Biaya</th>
                                <th style="text-align:center; color:white">Hasil/Nilai</th>
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
                            <td><%#Eval("STAFFPL_PELATIHAN") %></td>
                            <td><%#Eval("STAFFPL_JENIS")%></td>
                            <td><%#Eval("STAFFPL_NAMA")%></td>
                            <td><%#Eval("STAFFPL_TGL")%></td>
                            <td>Rp <%#Eval("STAFFPL_BIAYA", "{0:N}")%></td>
                            <td style="text-align:center"><%#Eval("STAFFPL_HASIL")%></td>
                            <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" OnClientClick="return confirm('Apakah anda yakin akan menghapus data ini?');"><img src="img/delete.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Pelatihan Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Pelatihan Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br />
            
                <!-- ModalPopupExtender -->
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panel4" TargetControlID="btnShow4"
                    CancelControlID="btnClose4" BackgroundCssClass="modalBackground">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Panel ID="Panel4" runat="server" CssClass="modal-dialog" align="center" style = "display:none">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" ID="btnClose4" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Form Pelatihan</h4>
                        </div>
                        <div class="modal-body">
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td> 
                                    <td class="col-md-3"><asp:Label ID="Label48" runat="server" Text="Nama Pelatihan"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtLatihPelatih" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-3"><asp:Label ID="Label49" runat="server" Text="Jenis Pelatihan"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtLatihJenis" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-3"><asp:Label ID="Label50" runat="server" Text="Nama Institusi"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtLatihNama" runat="server" MaxLength="50"  Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-3"><asp:Label ID="Label51" runat="server" Text="Tanggal Pelatihan"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtLatihTgl" runat="server" MaxLength="50" Text ="" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:TextBox>
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
                                    <td class="col-md-3"><asp:Label ID="Label52" runat="server" Text="Biaya"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtLatihBiaya" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-3"><asp:Label ID="Label53" runat="server" Text="Hasil"></asp:Label></td>
                                    <td class="col-md-6"><asp:TextBox ID="TxtLatihHasil" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table> 
                            <center>
                                <asp:Label ID="LblErrorSaveA13" runat="server" Text="" style="color:red"></asp:Label>
                                <asp:Button ID="BtnA13Save" runat="server" Text="Simpan" class="btn btn-success" />
                            </center>    
                        </div>
                    </div>
                </asp:Panel>      
            </asp:View> 
        </asp:MultiView> 
    </div>                
</asp:Content>