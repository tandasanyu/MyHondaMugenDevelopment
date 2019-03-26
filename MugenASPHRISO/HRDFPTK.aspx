<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" ValidateRequest="false" Debug="true" CodeFile="HRDFPTK.aspx.vb" Inherits="HRDFPTK" title="Dokumen Formulir Permintaan Tenaga Kerja" %>
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

        hr {
		  border:none;
		  border-top:1px dotted #f00;
		  color:#fff;
		  background-color:#fff;
		  height:1px;
		  width:100%;
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
        $(document).ready(function () {
            $('#table-a').DataTable();
	        //$('.data').DataTable();
	        //$('.data2').DataTable();
	    });

	    tinymce.init({
	        width: "700",
	        height: "200",
	        mode: "textareas",
	        plugins: ["advlist autolink lists link image charmap print preview anchor", "searchreplace visualblocks code fullscreen", "insertdatetime media table contextmenu paste"],
	        toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image"
	    });

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            
            $("#myInputBawahan").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#table-ax tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
    </script>


    <asp:Label ID="LblUserName" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblAkses" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea1" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea2" Style="display:none" runat="server"></asp:Label>
  
    <div class="container">
        <ul class="breadcrumb">
            <li><a href="#"> <span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"> <i class="fa fa-desktop"></i></a> &nbsp <a href="#"> HRD</a> </li>
            <li class="active"><span class="glyphicon glyphicon-duplicate"></span> &nbsp Form FPTK</li>
        </ul>
        <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
            <asp:View ID="Viewerr00" runat="server">
                <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" ForeColor="Red" height="23px" Width="959px">Judul Permohonan</asp:Label>
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiViewJudul" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
                 <div class="container">
                    <center>
                        <h2 style="font-family:Cooper Black;">DATA PERMINTAAN TENAGA KERJA</h2>
                        <h4>001-FRM-HRD&GA R.1</h4>
                    </center>
	            </div><br /><br />
        
                <asp:Button ID="BtnMasterTabel" runat="server" Text="Tambah Permintaan" class="button button4" />
                <br /><br />
            </asp:View>
        </asp:MultiView>
        <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
            <asp:View ID="View1Akses" runat="server">
                <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [PTK_ID], [PTK_JABATAN], [PTK_DEPT], [PTK_CABANG], [PTK_PEMOHON], [PTK_DIKETAHUI], [PTK_TGLDIKETAHUI],  [PTK_TGLDISETUJUI], [PTK_DISETUJUI], [PTK_MPP], [PTK_AKTUAL], [PTK_KURANG] FROM [TRXN_PTK] order by PTK_TGLMOHON DESC"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>    
                <br />
                 <input id="myInputBawahan"  type="text" placeholder="Ketik yang akan di Cari!" style="width:900px;" class="form-control required" autocomplete="off">
                <br />                                         
                <asp:ListView ID="LvDetailMaster" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="PTK_ID">
                    <LayoutTemplate>
                    <div style="width:1100px; height:900px; overflow:auto;">
                        <table id="table-ax"  class="table table-bordered table-striped data">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Check</th>
                                <th style="text-align:center; color:white">ID</th>
                                <th style="text-align:center; color:white">Posisi Yang Dibutuhkan</th>
                                <th style="text-align:center; color:white">Pemohon</th>
                                <th style="text-align:center; color:white">Diketahui</th>
                                <th style="text-align:center; color:white">Disetujui</th>
                                <th style="text-align:center; color:white">MPP</th>
                                <th style="text-align:center; color:white">Aktual</th>
                                <th style="text-align:center; color:white">Kurang/Tambah</th>
                                <th style="text-align:center; color:white" class="col-md-1">Detail</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table></div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                            <td><asp:CheckBox ID="CheckBox112" runat="server" value='<%# Eval("PTK_ID") %>' class="checkboxAO"/></td>
                            <td><p class="small"><%#Eval("PTK_ID")%></p></td>
                            <td><p class="small"><%#Eval("PTK_JABATAN")%><br />
                           <%#Eval("PTK_DEPT")%><br />
                            <%#Eval("PTK_CABANG")%></p></td>
                            <td><p class="small"><%#Eval("PTK_PEMOHON")%></p></td>
                            <td><p class="small"><%#Eval("PTK_DIKETAHUI")%><br />
                                <%#Eval("PTK_TGLDIKETAHUI")%></p></td>
                            <td><p class="small"><%#Eval("PTK_DISETUJUI")%><br />
                                 <%#Eval("PTK_TGLDISETUJUI")%></p></td></p></td>
                            <td><p class="small"><%#Eval("PTK_MPP")%></p></td>
                            <td><p class="small"><%#Eval("PTK_AKTUAL")%></p></td>
                            <td><p class="small"><%#Eval("PTK_KURANG")%></p></td>
                            <td align="center"><a href="<%#"HRDFPTKOUTPUT.aspx?no=" + Eval("PTK_ID")%>"><img src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/close.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data PTK Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data PTK Mutu Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br />
                <asp:Button ID="BtnDelete" runat="server" Text="Delete Data" class="btn btn-danger" />
                <br />
                <br />
            </asp:View> 
        </asp:MultiView> 

        <asp:MultiView ID="MultiViewNilaiProgressEntry" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
                <br /><br />
                 <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Permintaan Tenaga Kerja</font></div>
                        <div class="panel-body">
                            <center>
                                <h3 style="font-family:Blunter;">FORM PERMINTAAN TENAGA KERJA</h3>
                                <h5>001-FRM-HRD&GA R.1</h5>
                            </center>
	                        <br /><br />
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label8" runat="server" Text="ID"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="ptk_id" runat="server" Text=""></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label5" runat="server" Text="Jabatan Yang Dibutuhkan"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="ptk_jabatan" runat="server" class="form-control" Text=""></asp:Textbox>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label9" runat="server" Text="Department"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="ptk_dept" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Accounting</asp:ListItem>
                                            <asp:ListItem>Internal Audit</asp:ListItem>
                                            <asp:ListItem>CCO</asp:ListItem>
                                            <asp:ListItem>GA</asp:ListItem>
                                            <asp:ListItem>HRD</asp:ListItem>
                                            <asp:ListItem>ISO</asp:ListItem>
                                            <asp:ListItem>IT</asp:ListItem>
                                            <asp:ListItem>Purchasing</asp:ListItem>
                                            <asp:ListItem>Sales</asp:ListItem>
                                            <asp:ListItem>Service</asp:ListItem>
                                            <asp:ListItem>Showroom</asp:ListItem>
                                            <asp:ListItem>Warehouse</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label11" runat="server" Text="Cabang"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="ptk_cabang" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Ps. Minggu</asp:ListItem>
                                            <asp:ListItem>Puri</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                 <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Tgl. Permintaan"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="ptk_tglminta" runat="server" Text="" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:Textbox>
                                            <asp:Button ID="Button3"  Text="..."  runat="server" CausesValidation="False" class="btn btn-default" />
                    
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                            TargetControlID="ptk_tglminta" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                                            ControlExtender="MaskedEditExtender3" ControlToValidate="ptk_tglminta" EmptyValueMessage="Date is required"
                                            InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                            EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />

                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="ptk_tglminta" PopupButtonID="Button3" />
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label14" runat="server" Text="Tgl. Dibutuhkan"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="ptk_tglbutuh" runat="server" Text="" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:Textbox>
                                            <asp:Button ID="Button2"  Text="..."  runat="server" CausesValidation="False" class="btn btn-default" />
                    
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                            TargetControlID="ptk_tglbutuh" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
                                            ControlExtender="MaskedEditExtender2" ControlToValidate="ptk_tglbutuh" EmptyValueMessage="Date is required"
                                            InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                            EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />

                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="ptk_tglbutuh" PopupButtonID="Button2" />
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label16" runat="server" Text="Jumlah yang dibutuhkan"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="ptk_jumlah" style="width: 80px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" runat="server" Text=""></asp:Textbox> Orang
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label18" runat="server" Text="Status Karyawan"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="ptk_statuskaryawan" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem Value="1">Tetap</asp:ListItem>
                                            <asp:ListItem Value="2">Kontrak</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label20" runat="server" Text="Alasan Permintaan"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="ptk_alasan" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem Value="1">Replacement</asp:ListItem>
                                            <asp:ListItem Value="2">Penambahan sesuai MPP</asp:ListItem>
                                            <asp:ListItem Value="3">Penambahan diluar MPP</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label22" runat="server" Text="Penjelasan"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="ptk_alasandetail" class="form-control" runat="server" Text="ptk_alasandetail"></asp:Textbox>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label24" runat="server" Text="Jenis Kelamin"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="ptk_jkel" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem Value="1">Laki-Laki</asp:ListItem>
                                            <asp:ListItem Value="2">Perempuan</asp:ListItem>
                                            <asp:ListItem Value="3">Laki-laki / Perempuan</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label26" runat="server" Text="Indeks Prestasi"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="ptk_ipk" class="form-control" runat="server" Text=""></asp:Textbox>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label17" runat="server" Text="Pendidikan Terakhir"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="ptk_pendidikan" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem Value="1">SMA/K</asp:ListItem>
                                            <asp:ListItem Value="2">D1</asp:ListItem>
                                            <asp:ListItem Value="3">D2</asp:ListItem>
                                            <asp:ListItem Value="4">D3</asp:ListItem>
                                            <asp:ListItem Value="5">S1</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label30" runat="server" Text="Jurusan"></asp:Label></td>
                                    <td class="col-md-4">
                                         <asp:DropDownList ID="ptk_jurusan" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Akuntansi, Finance, Manajemen</asp:ListItem>
                                            <asp:ListItem>Teknik Mesin, Teknik Otomotif</asp:ListItem>
                                            <asp:ListItem>Sistem Informasi, Teknik Informatika, Sistem Komputer</asp:ListItem>
                                            <asp:ListItem>Psikologi, Teknologi Industri</asp:ListItem>
                                            <asp:ListItem>Komunikasi, Publik Relation</asp:ListItem>
                                            <asp:ListItem>IPA</asp:ListItem>
                                            <asp:ListItem>IPS</asp:ListItem>
                                            <asp:ListItem>Semua Jurusan</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label32" runat="server" Text="Umur"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="ptk_umur" style="width: 80px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" runat="server" Text=""></asp:Textbox> Tahun
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label34" runat="server" Text="Level Entry"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="ptk_level" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem Value="1">Manager</asp:ListItem>
                                            <asp:ListItem Value="2">Supervisor</asp:ListItem>
                                            <asp:ListItem Value="3">Staff</asp:ListItem>
                                            <asp:ListItem Value="4">Operator</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label7" runat="server" Text="Pengalaman Kerja"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="ptk_pengalaman" style="width: 80px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" runat="server" Text=""></asp:Textbox> Tahun
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label10" runat="server" Text="Ketrampilan yang diperlukan"></asp:Label></td>
                                    <td class="col-md-4"><asp:Textbox ID="ptk_ketrampilan" class="form-control"  TextMode ="MultiLine" runat="server" Text=""></asp:Textbox>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label13" runat="server" Text="Apakah Ada Calon"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="ptk_calon" runat="server" class="form-control" OnTextChanged="calon" AutoPostBack="true">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Ya</asp:ListItem>
                                            <asp:ListItem>Tidak</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>
                            <div style="margin-left:215px; margin-top:-15px;">
                                <table style="display:none" id="sarancalon"  class="table table-borderless" runat="server">  
                                    <tr>
                                        <td class="col-md-2"></td>
                                        <td class="col-md-2"><asp:Label ID="Label15" runat="server" Text="Jelaskan"></asp:Label></td>
                                        <td class="col-md-4"><asp:Textbox ID="ptk_sarancalon" class="form-control" runat="server" Text=""></asp:Textbox>
                                        </td>
                                        <td class="col-md-2"></td>
                                    </tr>
                                </table>     
                            </div>
                        
                            <center>
                                <asp:Label ID="LblErrorSaveC" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:Button ID="BtnNilaiSMSave" runat="server" Text="Simpan" class="btn btn-success" />
                            </center>
                        </div>
                    </div>
                </div><br />
            </asp:View>
        </asp:MultiView>

         <asp:MultiView ID="MultiViewAkses2" runat="server" Visible="TRUE">
            <asp:View ID="View3" runat="server">
                <asp:SqlDataSource ID="SqlDataSDR" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [PTK_ID], [PTK_JABATAN], [PTK_DEPT], [PTK_CABANG], [PTK_PEMOHON], [PTK_TGLDIKETAHUI],  [PTK_TGLDISETUJUI], [PTK_DIKETAHUI], [PTK_DISETUJUI], [PTK_MPP], [PTK_AKTUAL], [PTK_KURANG] FROM [TRXN_PTK] WHERE  ([PTK_PEMOHON] = ?)"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="LblUserName" Name="LblUserName" PropertyName= "Text" Type="String" />            
                    </selectparameters>
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailSDR" runat="server" DataSourceID="SqlDataSDR" DataKeyNames ="PTK_ID">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped data">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">ID</th>
                                <th style="text-align:center; color:white">Posisi Yang Dibutuhkan</th>
                                <th style="text-align:center; color:white">Pemohon</th>
                                <th style="text-align:center; color:white">Diketahui</th>
                                <th style="text-align:center; color:white">Disetujui</th>
                                <th style="text-align:center; color:white">MPP</th>
                                <th style="text-align:center; color:white">Aktual</th>
                                <th style="text-align:center; color:white">Kurang/Tambah</th>
                                <th style="text-align:center; color:white" class="col-md-1">Detail</th>
                                <th style="text-align:center; color:white" class="col-md-1"></th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                             <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                            <td><p class="small"><%#Eval("PTK_ID")%></p></td>
                            <td><p class="small"><%#Eval("PTK_JABATAN")%><br />
                           <%#Eval("PTK_DEPT")%><br />
                            <%#Eval("PTK_CABANG")%></p></td>
                            <td><p class="small"><%#Eval("PTK_PEMOHON")%></p></td>
                            <td><p class="small"><%#Eval("PTK_DIKETAHUI")%><br />
                                <%#Eval("PTK_TGLDIKETAHUI")%></p></td>
                            <td><p class="small"><%#Eval("PTK_DISETUJUI")%><br />
                                 <%#Eval("PTK_TGLDISETUJUI")%></p></td></p></td>
                            <td><p class="small"><%#Eval("PTK_MPP")%></p></td>
                            <td><p class="small"><%#Eval("PTK_AKTUAL")%></p></td>
                            <td><p class="small"><%#Eval("PTK_KURANG")%></p></td>
                            <td align="center"><a href="<%#"HRDFPTKOUTPUT.aspx?no=" + Eval("PTK_ID")%>"><img src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/close.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data PTK Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data PTK Mutu Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br />
            </asp:View> 
        </asp:MultiView> 
    </div>
</asp:Content>

