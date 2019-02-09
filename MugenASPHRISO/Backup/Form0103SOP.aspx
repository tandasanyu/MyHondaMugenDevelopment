<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0103SOP.aspx.vb" Inherits="SALES_Form0104SOP" title="Untitled Page" %>
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

        span.radio {
            padding: -10px;
            margin-top: 0px;
        }

        span.radio > input[type="radio"] {
            margin: 5px 5px 0px 0px;
        }

        span.radio > label {
            float: left;
            margin-right: 10px;
            padding: 0px 15px 0px 20px;
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

        .button1 {
            background-color: #B7DD90; 
            color: black; 
            border: 2px solid #B7DD90;
        }

        .button1:hover {
            background-color: #84CA46;
            color: white;
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

        .button3 {
            background-color: #FEAE96; 
            color: black; 
            border: 2px solid #FEAE96;
        }

        .button3:hover {
            background-color: #F80021;
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

    </style>    
    
    <asp:Label ID="LblUserName" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblAkses" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea1" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea2" Style="display:none" runat="server"></asp:Label>

    <div class="container">
        <ul class="breadcrumb">
          <li><a href="#"> <span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
          <li><a href="#"> <span class="glyphicon glyphicon-globe"></span></a> &nbsp <a href="#"> ISO</a> </li>
          <li class="active"><span class="glyphicon glyphicon-warning-sign"></span> &nbsp SOP</li>
        </ul>

        <asp:Button ID="BtnMasterSop" runat="server" Text="Dokumen SOP" class="button button1" />
        <asp:Button ID="BtnMasterObsolete" runat="server" Text="Dokumen Obsolete" class="button button3" />
        <asp:Button ID="BtnMasterTabel" runat="server" Text="Tambah Dokumen" class="button button4" />
        <asp:Button ID="BtnMasterUpdate" runat="server" Text="Update Dokumen" class="button button2" />

        <br />
        <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
            <asp:View ID="Viewerr00" runat="server">
                <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Judul Permohonan</asp:Label>
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
            <asp:View ID="View1Akses" runat="server">
                <div class="container">
                    <br />
                    <center>
                        <h2 style="font-family:Cooper Black;">DOKUMEN STANDARD OPERASIONAL PROSEDUR (SOP)</h2>
                    </center>
	            </div>  <br /><br />

                <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_DISETUJUI], [DOKUMEN_TGLDISETUJUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='B'"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailMaster" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                    <table id="table-a"  class="table table-bordered table-striped">
                        <thead style="background-color:#4877CF">
                            <th style="text-align:center; color:white">No.</th>
                            <th style="text-align:center; color:white">Dokumen</th>
                            <th style="text-align:center; color:white">Dibuat</th>
                            <th style="text-align:center; color:white">Diketahui</th>
                            <th style="text-align:center; color:white">Disetujui</th>
                            <th style="text-align:center; color:white">Lihat</th>
                            <th style="text-align:center; color:white" class="col-md-1">Distribusi</th>
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
                            <td><%#Eval("DOKUMEN_DISETUJUI")%><br />
                                <%#Eval("DOKUMEN_TGLDISETUJUI")%>
                            </td>
                            <td><center><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img src="img/dokumen1.png" width="35px" height="40px" /></a></center></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/share.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data SOP Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data SOP Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
            </asp:View> 
        </asp:MultiView> 

        <br />
        <asp:MultiView ID="MultiViewUploadDokumen" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
                <br /><br />
                <div class="container">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-warning-sign"></span> &nbsp <font style="color:#ffffff">Form Standar Operasional Prosedur (SOP)</font></div>
                        <div class="panel-body">
                            <center>
                                <h2 style="font-family:Cooper Black;">FORM STANDARD OPERASIONAL PROSEDUR (SOP)</h2>
                            </center>
	                        <br /><br />
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label8" runat="server" Text="ID"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="lblBackupId" runat="server" Text="ID"></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label6" runat="server" Text="Status Dokumen"></asp:Label></td>
                                    <td class="col-md-4">   
                                        <asp:RadioButtonList ID="status" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
							                <asp:ListItem> Baru</asp:ListItem>
							                <asp:ListItem> Obsolete Dokumen</asp:ListItem>
							            </asp:RadioButtonList>
                                    </td>     
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="LblNamaDokumen" runat="server" Text="Nama Dokumen"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtNamaDokumen" runat="server" MaxLength="25" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                        
                                <tr> 
						            <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Upload Dokumen"></asp:Label></td>
						            <td class="col-md-4">
                                        <asp:FileUpload ID="FileUpload1" runat="server"/>
							            <asp:RegularExpressionValidator ID="FileTypeValidator" runat="server" ErrorMessage="File type not allowed: Accept PDF file type only" ValidationExpression="^.+.((pdf))$" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator><br />
						            </td>
                                    <td class="col-md-2"></td>
					            </tr>
                            </table>
                                       
                            <center>
                                <asp:Label ID="LblErrorSaveC" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:Button ID="BtnNilaiSMBack" runat="server" Text="Kembali Ke Menu Awal" class="btn btn-warning" />
                                <asp:Button ID="BtnNilaiSMSave" runat="server" Text="Simpan" class="btn btn-primary" />  
                            </center>
                        </div>
                    </div>   
                </div>         
            </asp:View>
        </asp:MultiView>

        <asp:MultiView ID="MultiViewDistribusiDokumen" runat="server" Visible="TRUE">
            <asp:View ID="View4" runat="server">
                <br /><br />
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-book"></span> &nbsp <font style="color:#ffffff">Form Distribusi Standar Operasional Prosedur (SOP)</font></div>
                    <div class="panel-body">
                        <center><h2 style="font-family:Cooper Black;">FORM DISTRIBUSI STANDARD OPERASIONAL PROSEDUR</h2></center>
                        <br /><br />
                        <table class="table table-borderless">
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="ID"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="lblDokumenId" runat="server" Text="ID"></asp:Label></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label4" runat="server" Text="Nama Dokumen"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="NmDokumen" runat="server" MaxLength="25" Text =""></asp:Label></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label5" runat="server" Text="Distribusi"></asp:Label></td>
                                <td class="col-md-2">
                                    <asp:CheckBox ID="D1" runat="server" Text="&nbsp Direksi" /><br />
                                    <asp:CheckBox ID="D2" runat="server" Text="&nbsp Operational Support Manager"/><br />
                                    <asp:CheckBox ID="D3" runat="server" Text="&nbsp SM Ps. Minggu" /><br />
                                    <asp:CheckBox ID="D4" runat="server" Text="&nbsp SM Puri"/><br /> 
                                    <asp:CheckBox ID="D5" runat="server" Text="&nbsp Service Manager Ps. Minggu"/><br />
                                    <asp:CheckBox ID="D6" runat="server" Text="&nbsp Service Manager Puri"/><br />
                                    <asp:CheckBox ID="D7" runat="server" Text="&nbsp Internal Auditor"/><br />
                                    <asp:CheckBox ID="D8" runat="server" Text="&nbsp WH Coordinator"/><br />
                                    <asp:CheckBox ID="D9" runat="server" Text="&nbsp Ka. Sparepart Ps. Minggu"/><br />
                                    <asp:CheckBox ID="D10" runat="server" Text="&nbsp Ka. Sparepart Puri"/><br />
                                    <asp:CheckBox ID="D11" runat="server" Text="&nbsp SPV Sales Ps. Minggu"/><br />
                                    <asp:CheckBox ID="D12" runat="server" Text="&nbsp SPV Sales Puri"/><br />
                                </td>
                                <td>
                                    <asp:CheckBox ID="D13" runat="server" Text="&nbsp QMR"/><br />
                                    <asp:CheckBox ID="D14" runat="server" Text="&nbsp ADH Ps. Minggu"/><br />
                                    <asp:CheckBox ID="D15" runat="server" Text="&nbsp ADH Puri" /><br />
                                    <asp:CheckBox ID="D16" runat="server" Text="&nbsp CC SPV"/><br />
                                    <asp:CheckBox ID="D17" runat="server" Text="&nbsp CC Puri"/><br />
                                    <asp:CheckBox ID="D18" runat="server" Text="&nbsp HRD & GA Head"/><br />
                                    <asp:CheckBox ID="D19" runat="server" Text="&nbsp GA Puri"/><br />
                                    <asp:CheckBox ID="D20" runat="server" Text="&nbsp SPV HRD"/><br />
                                    <asp:CheckBox ID="D21" runat="server" Text="&nbsp SPV GA"/><br />
                                    <asp:CheckBox ID="D22" runat="server" Text="&nbsp IT Head"/><br />
                                    <asp:CheckBox ID="D23" runat="server" Text="&nbsp IT Puri" /><br />
                                    <asp:CheckBox ID="D24" runat="server" Text="&nbsp Purchasing"/>
                                </td>
                                <td class="col-md-2"></td>
                            </tr>
                        </table>
                        <center>
                            <asp:Label ID="Label7" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <br />
                            <asp:Button ID="BtnNilaiSM2Back" runat="server" Text="Kembali Ke Menu Awal" class="btn btn-warning" />
                            <asp:Button ID="BtnNilaiSM2Save" runat="server" Text="Simpan" class="btn btn-primary" />
                        </center>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>

        <asp:MultiView ID="MultiViewEditSOP" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
                <div class="container">
                    <br />
                    <center>
                        <h2 style="font-family:Cooper Black;">HISTORY DOKUMEN STANDARD OPERASIONAL PROSEDUR</h2>
                    </center>
	            </div><br /><br />
       
                <asp:SqlDataSource ID="SqlDataEditPanduan" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_LINK], [DOKUMEN_LINKOBSOLETE], [DOKUMEN_TGLDIBUAT], [DOKUMEN_TGLDIBUATPERTAMA] FROM [TRXN_DOKUMEN] WHERE [DOKUMEN_JENIS]='B' AND [DOKUMEN_DIBUAT] = ? ORDER BY [DOKUMEN_TGLDIBUAT] DESC"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="LblUserName" Name="LblUserName" PropertyName= "Text" Type="String" />            
                    </selectparameters>
                </asp:SqlDataSource>                                          
                <asp:ListView ID="LvEdit" runat="server" DataSourceID="SqlDataEditPanduan" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white" rowspan="2">No.</th>
                                <th style="text-align:center; color:white" rowspan="2" class="col-md-5">Dokumen</th>
                                <th style="text-align:center; color:white" colspan="2">Dokumen Baru</th>
                                <th style="text-align:center; color:white" colspan="2">Dokumen Obsolete</th>
                                <th style="text-align:center; color:white" rowspan="2" class="col-md-1">Detail</th>
                            </tr>
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white" class="col-md-1">Lihat</th>
                                <th style="text-align:center; color:white" class="col-md-2">Tanggal Dibuat</th>
                                <th style="text-align:center; color:white" class="col-md-1">Lihat</th>
                                <th style="text-align:center; color:white" class="col-md-2">Tanggal Tidak Berlaku</th>
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
                            <td><%#Eval("DOKUMEN_NAMA")%><br />
                                <i>No Ref. <%#Eval("DOKUMEN_No")%></i>
                            </td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                            <td><%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINKOBSOLETE")%>"><img src="img/dokumen3.png" width="35px" height="40px" /></a></td>
                            <td><%#Eval("DOKUMEN_TGLDIBUATPERTAMA")%></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/edit2.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data SOP Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data SOP Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
            </asp:View>
        </asp:MultiView>

         <asp:MultiView ID="MultiViewFormEditDokumen" runat="server" Visible="TRUE">
            <asp:View ID="View3" runat="server">
                <br /><br />
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-book"></span> &nbsp <font style="color:#ffffff">Form Update Dokumen Panduan Mutu</font></div>
                    <div class="panel-body">
                        <center><h2 style="font-family:Cooper Black;">FORM UPDATE DOKUMEN STANDARD OPERASIONAL PROSEDUR</h2></center>
	                    <br /><br />
                        <table class="table table-borderless">
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="ID"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="lblID" runat="server" Text="ID"></asp:Label></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label9" runat="server" Text="Nama Dokumen"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="lblNama" runat="server" MaxLength="25" Text =""></asp:Label></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
						        <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label10" runat="server" Text="Upload Dokumen"></asp:Label>
                                </td>
						        <td class="col-md-4">
                                    <asp:FileUpload ID="FileUpload2" runat="server"/>
							        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="File type not allowed: Accept PDF file type only" ValidationExpression="^.+.((pdf))$" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator><br />
						        </td>
                                <td class="col-md-2"></td>
					        </tr>
                        </table>
                        <asp:Label ID="dokumenAwal" runat="server" style="display:none"/>
                        <asp:Label ID="tglAwal" runat="server" style="display:none"/>
                        <center>
                            <asp:Label ID="Label11" runat="server" Text="" ForeColor="Red"></asp:Label>

                            <asp:Button ID="BtnNilaiSM3Back" runat="server" Text="Kembali Ke Menu Awal" class="btn btn-warning" />
                            <asp:Button ID="BtnNilaiSM3Save" runat="server" Text="Simpan" class="btn btn-primary" />
                        </center><br />
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>

        <asp:MultiView ID="MultiViewObsolete" runat="server" Visible="TRUE">
            <asp:View ID="View5" runat="server">
                <div class="container">
                    <br />
                    <center>
                        <h2 style="font-family:Cooper Black;">DOKUMEN OBSOLETE STANDARD OPERASIONAL PROSEDUR</h2>
                    </center>
	            </div><br /><br />
       
                <asp:SqlDataSource ID="SqlDataObsolete" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMENO_NAMA], [DOKUMENO_TGLTIDAKBERLAKU], [DOKUMENO_LINK], [DOKUMENO_JENIS] FROM [TRXN_DOKUMENO] WHERE [DOKUMENO_JENIS]='B' ORDER BY [DOKUMENO_TGLTIDAKBERLAKU] DESC"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="lblArea1" Name="lblArea1" PropertyName= "Text" Type="String" />            
                    </selectparameters>
                </asp:SqlDataSource>                                             
                <asp:ListView ID="ListObsolete" runat="server" DataSourceID="SqlDataObsolete" DataKeyNames ="DOKUMENO_NAMA">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
                                <th style="text-align:center; color:white">Tanggal Tidak Berlaku</th>
                                <th style="text-align:center; color:white" class="col-md-1">Lihat</th>
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
                            <td><%#Eval("DOKUMENO_NAMA")%></td>
                            <td><%#Eval("DOKUMENO_TGLTIDAKBERLAKU")%></td>
                            <td><center><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMENO_LINK")%>"><img src="img/dokumen1.png" width="35px" height="40px" /></a></center></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Dokumen Obsolete SOP Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Dokumen Obsolete SOP Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
            </asp:View>
        </asp:MultiView>

        <asp:MultiView ID="MultiViewSOP" runat="server" Visible="TRUE">
            <asp:View ID="View6" runat="server">
                <div class="container">
                    <center style="margin-top:0px">
                        <h2 style="font-family:Cooper Black;">DOKUMEN STANDARD OPERASIONAL PROSEDUR (SOP)</h2>
                    </center>
	            </div><br /><br />
                <asp:SqlDataSource ID="SqlDataView" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_DISETUJUI], [DOKUMEN_TGLDISETUJUI], [DOKUMEN_LINK], [DOKUMEND_DISTRIBUSI] FROM [TRXN_DOKUMEN] INNER JOIN [TRXN_DOKUMEND] ON [DOKUMEND_NO] = [DOKUMEN_NO] WHERE ([DOKUMEND_DISTRIBUSI] = ? AND [DOKUMEN_JENIS]='B')"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
			        <selectparameters>
                        <asp:ControlParameter ControlID="lblArea1" Name="lblArea1" PropertyName= "Text" Type="String" />            
			        </selectparameters>
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailView" runat="server" DataSourceID="SqlDataView" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                    <table id="table-a"  class="table table-bordered table-striped">
                        <thead style="background-color:#4877CF">
                            <th style="text-align:center; color:white">No.</th>
                            <th style="text-align:center; color:white">Dokumen</th>
                            <th style="text-align:center; color:white">Dibuat</th>
                            <th style="text-align:center; color:white">Diketahui</th>
                            <th style="text-align:center; color:white">Disetujui</th>
                            <th style="text-align:center; color:white" class="col-md-1">Lihat</th>
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
                            <td><%#Eval("DOKUMEN_NAMA")%><br />
                                <i>No Ref. <%#Eval("DOKUMEN_No")%></i>
                            </td>
                            <td><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></td>
                            <td><%#Eval("DOKUMEN_DIKETAHUI")%><br />
                                <%#Eval("DOKUMEN_TGLDIKETAHUI")%></td>
                            <td><%#Eval("DOKUMEN_DISETUJUI")%><br />
                                <%#Eval("DOKUMEN_TGLDISETUJUI")%>
                            </td>
                            <td><center><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img src="img/dokumen1.png" width="35px" height="40px" /></a></center></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Dokumen SOP Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Dokumen SOP Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
