<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" ValidateRequest="false" Debug="true" CodeFile="Form0103SDR.aspx.vb" Inherits="SALES_Form0104Diskontypemaksimal" title="Dokumen System Development/Fault Request" %>
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
	    $(document).ready(function(){
	        $('.data').DataTable();
	    });

	    tinymce.init({
	        width: "700",
	        height: "200",
	        mode: "textareas",
	        plugins: ["advlist autolink lists link image charmap print preview anchor", "searchreplace visualblocks code fullscreen", "insertdatetime media table contextmenu paste"],
	        toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image"
	    });

    </script>

    <asp:Label ID="LblUserName" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblAkses" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea1" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea2" Style="display:none" runat="server"></asp:Label>
  
    <div class="container">
        
        <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
            <asp:View ID="Viewerr00" runat="server">
                <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" ForeColor="Red" height="23px" Width="959px">Judul Permohonan</asp:Label>
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
            <asp:View ID="View1Akses" runat="server">
                <ul class="breadcrumb">
            <li><a href="#"> <span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"> <i class="fa fa-desktop"></i></a> &nbsp <a href="#"> ISO</a> </li>
            <li class="active"><span class="glyphicon glyphicon-duplicate"></span> &nbsp Form SDR</li>
        </ul>
                <div class="container">
                    <center>
                        <h2 style="font-family:Cooper Black;">DATA SYSTEM DEVELOPMENT/FAULT REQUEST<br />
                            (SDR/FR)
                        </h2>
                        <h4>001-FRM-IT.R2</h4>
                    </center>
	            </div><br /><br />
        
                <asp:Button ID="BtnMasterTabel" runat="server" Text="Tambah Permintaan" class="button button4" />
                <br /><br />
                <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [SDRLOG_NO], [SDRLOG_TIPE], [SDRLOG_JENIS], [SDRLOG_DETAIL], [SDRLOG_TGLCLOSE], [SDRLOG_PERMANEN], [SDRLOG_WAKTUMULAI], [SDRLOG_TESTNOTE], [SDRLOG_TESTSTATUS], [SDRLOG_TESTTGL], [SDRLOG_DETAIL], [SDRLOG_TUJUAN], [SDRLOG_TARGET], [SDRLOG_WAKTUSELESAI], [SDRLOG_PEMOHONNAMA], [SDRLOG_PEMOHONTGL], [SDRLOG_KETAHUINAMA], [SDRLOG_KETAHUITGL], [SDRLOG_SETUJUNAMA], [SDRLOG_SETUJUTGL], [SDRLOG_UJITGL], [SDRLOG_UJINAMA], [SDRLOG_TARGETR1] FROM [TRXN_SDR]"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailMaster" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="SDRLOG_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped data">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">ID</th>
                                <th style="text-align:center; color:white">Jenis</th>
                                <th style="text-align:center; color:white">Tujuan</th>
                                <th style="text-align:center; color:white">Detail</th>
                                <th style="text-align:center; color:white">Pemohon</th>
                                <th style="text-align:center; color:white">Diketahui</th>
                                <th style="text-align:center; color:white">Disetujui</th>
                                <th style="text-align:center; color:white">Diuji</th>
                                <th style="text-align:center; color:white">Target</th>
                                <th style="text-align:center; color:white">Selesai</th>
                                <th style="text-align:center; color:white" class="col-md-1">Detail</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                            <td><p class="small"><%#Eval("SDRLOG_NO")%></p></td>
                            <td><p class="small"><%#Eval("SDRLOG_JENIS")%></p></td>
                            <td><p class="small"><%#Eval("SDRLOG_TUJUAN")%></p></td>
                            <td><p class="small"><%#Eval("SDRLOG_DETAIL")%></p></td>
                            <td><p class="small"><%#Eval("SDRLOG_PEMOHONNAMA")%><br />
                                <%#Eval("SDRLOG_PEMOHONTGL")%></p></td>
                            <td><p class="small"><%#Eval("SDRLOG_KETAHUINAMA")%><br />
                                <%#Eval("SDRLOG_KETAHUITGL")%></p></td>
                            <td><p class="small"><%#Eval("SDRLOG_SETUJUNAMA")%><br />
                                <%#Eval("SDRLOG_SETUJUTGL")%></p></td>
                            <td><p class="small"><%#Eval("SDRLOG_UJINAMA")%><br />
                                <%#Eval("SDRLOG_UJITGL")%></p></td>
                            <td><p class="small"><%#Eval("SDRLOG_TARGETR1")%></p></td>
                            <td><p class="small"><%#Eval("SDRLOG_TGLCLOSE")%></p></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data SDR Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data SDR Mutu Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br />
            </asp:View> 
        </asp:MultiView> 

        <asp:MultiView ID="MultiViewNilaiProgressEntry" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
                <ul class="breadcrumb">
            <li><a href="#"> <span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"> <i class="fa fa-desktop"></i></a> &nbsp <a href="#"> ISO</a> </li>
            <li class="active"><span class="glyphicon glyphicon-duplicate"></span> &nbsp Form SDR</li>
        </ul>
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
                                    <td class="col-md-4"><asp:Label ID="lblSDRId" runat="server" Text="ID"></asp:Label><br />
                                        <asp:Label ID="lblSDRHead" style="display:none" runat="server" Text="Head"></asp:Label>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Jenis"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Pengembangan Sistem</asp:ListItem>
                                            <asp:ListItem>Perbaikan Sistem</asp:ListItem>
                                            <asp:ListItem>Pengembangan Website</asp:ListItem>
                                            <asp:ListItem>Perbaikan Website</asp:ListItem>
                                            <asp:ListItem>User Login Sistem</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="Jangka Waktu"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" OnTextChanged="jWaktu" AutoPostBack="true">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Permanen</asp:ListItem>
                                            <asp:ListItem>Temporary</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>
                            <div style="margin-left:228px; margin-top:-15px;">
                                <table style="display:none" id="tanggal"  class="table table-borderless" runat="server">
                                    <tr>
                                        <td><asp:Label ID="Label6" runat="server" Text="Dari Tanggal"></asp:Label></td>
                                        <td class="col-md-9">
                                            &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
                                            <asp:TextBox ID="TxtSDRTglmulai" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />
                                            <asp:Button ID="Button2"  Text="..."  runat="server" CausesValidation="False" class="btn btn-default" />
                    
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                            TargetControlID="TxtSDRTglmulai" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
                                            ControlExtender="MaskedEditExtender2" ControlToValidate="TxtSDRTglmulai" EmptyValueMessage="Date is required"
                                            InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                            EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />

                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TxtSDRTglmulai" PopupButtonID="Button2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="Label12" runat="server" Text="Selesai Tanggal"></asp:Label></td>
                                        <td class="col-md-9">
                                            &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                                            <asp:TextBox ID="TxtSDRTglSelesai" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" TabIndex ="13" />
                                            <asp:Button ID="Button3"  Text="..."  runat="server" CausesValidation="False" class="btn btn-default" />
                    
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                            TargetControlID="TxtSDRTglSelesai" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator3" runat="server"
                                            ControlExtender="MaskedEditExtender3" ControlToValidate="TxtSDRTglSelesai" EmptyValueMessage="Date is required"
                                            InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                            EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TxtSDRTglSelesai" PopupButtonID="Button3" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <table class="table table-borderless" style="margin-top:-15px">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Tujuan"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtSDRTujuan" TextMode ="MultiLine" runat="server" MaxLength="200" class="form-control"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label4" runat="server" Text="Detail"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtSDRDetail" TextMode = "MultiLine" runat="server" MaxLength="200" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>
                
                            <center>
                                <asp:Label ID="LblErrorSaveC" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:Button ID="BtnNilaiSMSave" runat="server" Text="Simpan" class="btn btn-primary" />
                            </center>
                        </div>
                    </div>
                </div><br />
            </asp:View>
        </asp:MultiView>

        <asp:MultiView ID="MultiViewDetailSDR" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
                <br /><br />
                 <div class="container">
                    <center>
                        <h3>PT. MITRAUSAHA GENTANIAGA<br />
                            FORM SYSTEM DEVELOPMENT/FAULT REQUEST <br />
                            (SDR/FR)
                        </h3>
                        <h5>001-FRM-IT.R2</h5>
                    </center>
	                <br />

                    <table>
                        <tr style="height:30px">
                            <td>Nomor</td>
                            <td>&nbsp : &nbsp</td>
                            <td><asp:Label ID="no" runat="server" style="text-transform: uppercase;"></asp:Label></td>
                        </tr>
                        <tr style="height:30px">
                            <td>Jenis</td>
                            <td>&nbsp : &nbsp</td>
                            <td><asp:CheckBox ID="Jenis1" runat="server" Enabled="false"/> Permohonan pengembangan sistem<br />
                                <asp:CheckBox ID="Jenis2" runat="server" Enabled="false"/> Permohonan pengembangan website
                            </td>
                            <td style="width:100px"></td>
                            <td><asp:CheckBox ID="Jenis3" runat="server" Enabled="false"/> Permohonan perbaikan sistem<br />
                                <asp:CheckBox ID="Jenis4" runat="server" Enabled="false"/> Permohonan perbaikan website
                            </td>
                        </tr>
                         <tr style="height:30px">
                            <td>Jangka Waktu</td>
                            <td>&nbsp : &nbsp</td>
                            <td><asp:CheckBox ID="JWaktu1" runat="server" Enabled="false"/> Selamanya (Permanen)</td>
                            <td style="width:100px"></td>
                            <td><asp:CheckBox ID="JWaktu2" runat="server" Enabled="false"/> Dari tgl  <asp:Label ID="tgl1" runat="server" Text="....."></asp:Label> s/d tgl <asp:Label ID="tgl2" runat="server" Text="....."></asp:Label></td>
                        </tr>       
                    </table> <br /><br />
                            
                    <div class="well">     
                        <div class="container">
                            <b>Alasan dan Tujuan Pengajuan Program</b><br />
                            <asp:Label ID="tujuan" runat="server"></asp:Label>
                    
                            <br /><br />
                          
                            <br /><br />
                            <b>Format Program yang Diinginkan (Gambarkan dengan detail)</b><br />
                            <asp:Label ID="detail" runat="server"></asp:Label>
                        </div>
                    </div>     
                     
                    <div class="well">     
                        <div class="container">
                            <b>Sudah dilakukan pengujian pada:</b><br />
                            <table>
                                <tr>
                                    <td>Tanggal :</td>
                                    <td><asp:Label ID="tglUji" runat="server"></asp:Label></td>
                                    <td style="width:450px"></td>
                                    <td>Status </td>
                                    <td>&nbsp : &nbsp</td>
                                    <td><asp:CheckBox ID="status1" runat="server" Enabled="false"/> Puas</td>
                                    <td style="width:25px"></td>
                                    <td><asp:CheckBox ID="status2" runat="server" Enabled="false"/> Tidak Puas</td>
                                </tr>
                            </table>
                            <br />Keterangan: <br />
                            <asp:Label ID="keterangan" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div> <br />
                     
                    <table style="width:100%;margin:8px;margin-left:-50px; text-align:center;font-family:Verdana;color:#333;">
                        <tr>
                            <th style="text-align:center;">Pemohon</th>
                            <th style="text-align:center;">Diketahui</th>
                            <th style="text-align:center;">Disetujui</th>
                            <th style="text-align:center;">Disetujui sudah diuji</th>
                       </tr>
                       <tr>
                             <td><br /></td>
                             <td><br /></td>
                             <td><br /></td>
                             <td><br /></td>
                       </tr>
                       <tr>
                             <td><br /></td>
                             <td><asp:Label ID="lblAppDiketahui" visible="false" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);-o-transform: rotate(-20deg);opacity: 0.3; "></asp:Label></td>
                             <td><asp:Label ID="lblAppDisetujui" visible="false" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);opacity: 0.3;"></asp:Label></td>
                             <td><asp:Label ID="lblAppDiuji" visible="false" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);opacity: 0.3;"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><br /></td>
                            <td><br /></td>
                            <td><br /></td>
                            <td><br /></td>
                        </tr>
                        <tr>
                            <td><u><asp:Label ID="lblNamaPemohon" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaDiketahui" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaDisetujui" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="lblNamaDiuji" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="font-size:9pt;color:Blue;">(Head Department)</td>
                            <td style="font-size:9pt;color:Blue;">(IT Head Department)</td>
                            <td style="font-size:9pt;color:Blue;"></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblTglPemohon" runat="server" Text="" style="font-size:8pt;margin:0;color:#666"></asp:Label></td>
                            <td><asp:Label ID="lblTglDiketahui" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                            <td><asp:Label ID="lblTglDisetujui" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                            <td><asp:Label ID="lblTglDiuji" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                        </tr>

                        <tr style="height:60px">
                            <td><b>Tanggal perkiraan selesai:</b> <asp:Label ID="tglEstimasi" runat="server"></asp:Label></td>
                        </tr>
                    </table><br /><br />
                    <center><asp:Button ID="ButtonClose" runat="server" Text="Close" class="btn btn-primary" /></center>  
                </div><br />
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>

