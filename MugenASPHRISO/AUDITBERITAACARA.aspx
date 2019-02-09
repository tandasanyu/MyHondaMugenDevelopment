<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AUDITBERITAACARA.aspx.vb" Inherits="AUDITBERITAACARA" title="Laporan dan Berita Acara Audit/Stockopname" %>
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
    <script type="text/javascript">
	    $(document).ready(function(){
	        $('.data').DataTable();
	        $('.data2').DataTable();
	        $('.data3').DataTable();
	    });
    </script>

    <asp:Label ID="LblUserName" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblAkses" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea1" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea2" Style="display:none" runat="server"></asp:Label>

    <div class="container">
        <ul class="breadcrumb">
          <li><a href="#"> <span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
          <li class="active"><span class="glyphicon glyphicon-paperclip"></span> &nbsp Laporan dan Berita Acara Audit/Stockopname</li>
        </ul>
        <asp:Button ID="BtnMasterTabel" runat="server" Text="Tambah Data" class="button button4" />
        <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
            <asp:View ID="Viewerr00" runat="server">
                <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Judul Permohonan</asp:Label>
            </asp:View> 
        </asp:MultiView>
        
        <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
            <asp:View ID="View1Akses" runat="server">
                <div class="container">
                    <center>
                        <h2 style="font-family:Cooper Black;">DOKUMEN LAPORAN DAN BERITA ACARA <br /> AUDIT/STOCKOPNAME</h2>
                    </center>
	            </div>  <br /><br />

                <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_CABANG], [DOKUMEN_TGLDIBUAT], [DOKUMEN_RINCIAN], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_DIKETAHUI2], [DOKUMEN_TGLDIKETAHUI2], [DOKUMEN_DISETUJUI], [DOKUMEN_TGLDISETUJUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE  [DOKUMEN_JENIS]='D'"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                  
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailMaster" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered table-striped data">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
                                <th style="text-align:center; color:white">Cabang</th>
                                <th style="text-align:center; color:white">Dibuat</th>
                                <th style="text-align:center; color:white">Diketahui I</th>
                                <th style="text-align:center; color:white">Diketahui II</th>
                                <th style="text-align:center; color:white">Disetujui</th>
                                <th style="text-align:center; color:white" class="col-md-1">Lihat Laporan</th>
                                <th style="text-align:center; color:white">Lihat Rincian</th>
                                <th style="text-align:center; color:white" class="col-md-1">Edit</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_NAMA")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_CABANG")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_DIKETAHUI")%><br />
                                <%#Eval("DOKUMEN_TGLDIKETAHUI")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_DIKETAHUI2")%><br />
                                <%#Eval("DOKUMEN_TGLDIKETAHUI2")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_DISETUJUI")%><br />
                                <%#Eval("DOKUMEN_TGLDISETUJUI")%></p></td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                             <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_RINCIAN")%>"><img alt="" src="img/dokumen3.png" width="35px" height="40px" /></a></td>
                            <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img alt="" src="img/edit2.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Berita Acara diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Berita Acara Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
            </asp:View> 
        </asp:MultiView> 
        <br />
        <asp:MultiView ID="MultiViewUploadDokumen" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
                <br />
                <div class="container">
                    <div class="panel panel-default">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-paperclip"></span> &nbsp <font style="color:#ffffff">Form Laporan Dan Berita Acara Audit/Stockopname</font></div>
                        <div class="panel-body">
                            <center>
                                <h2 style="font-family:Cooper Black;">FORM LAPORAN DAN BERITA ACARA <br /> AUDIT/STOCKOPNAME</h2>
                            </center>
	                    </div><br />
                        <table class="table table-borderless">
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label8" runat="server" Text="ID"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="lblBeritaAcaraId" runat="server" Text="ID"></asp:Label></td>
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
                                <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="Cabang"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>Puri</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label19" runat="server" Text="Diketahui 1"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:CheckBox ID="D1" runat="server" Text="&nbsp Admin Piutang B/P Ps.Minggu"/><br />
                                    <asp:CheckBox ID="D2" runat="server" Text="&nbsp Admin Piutang B/P Puri" /><br />
                                    <asp:CheckBox ID="D3" runat="server" Text="&nbsp Admin Piutang Service Ps.Minggu"/><br />
                                    <asp:CheckBox ID="D4" runat="server" Text="&nbsp Admin Piutang Service Puri"/><br />
                                    <asp:CheckBox ID="D5" runat="server" Text="&nbsp Admin Piutang Showroom Ps.Minggu"/><br />
                                    <asp:CheckBox ID="D6" runat="server" Text="&nbsp Admin Piutang Showroom Puri"/><br />
                                    <asp:CheckBox ID="D7" runat="server" Text="&nbsp Admin Faktur Ps.Minggu"/><br />
                                    <asp:CheckBox ID="D8" runat="server" Text="&nbsp Admin Faktur Puri" /><br />
                                    <asp:CheckBox ID="D9" runat="server" Text="&nbsp WH Coordinator"/><br />
                                    <asp:CheckBox ID="D10" runat="server" Text="&nbsp Staff Spareparts"/>
                                </td>
                                <td class="col-md-2"></td>
                            </tr>    
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Diketahui 2"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:CheckBox ID="D11" runat="server" Text="&nbsp ADH Ps.Minggu" /><br />
                                    <asp:CheckBox ID="D12" runat="server" Text="&nbsp ADH Puri"/><br />
                                    <asp:CheckBox ID="D13" runat="server" Text="&nbsp SM PS. Minggu" /><br />
                                    <asp:CheckBox ID="D14" runat="server" Text="&nbsp SM Puri"/><br /> 
                                    <asp:CheckBox ID="D15" runat="server" Text="&nbsp Service Manager Ps.Minggu"/><br />
                                    <asp:CheckBox ID="D16" runat="server" Text="&nbsp Service Manager Puri"/><br />
                                    <asp:CheckBox ID="D17" runat="server" Text="&nbsp Ka. Sparepart Ps. Minggu"/><br />
                                    <asp:CheckBox ID="D18" runat="server" Text="&nbsp Ka. Sparepart Puri"/> 
                                </td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
						        <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Upload Dokumen Utama"></asp:Label></td>
						        <td class="col-md-4">
                                    <asp:FileUpload ID="FileUpload1" runat="server"/>
							        <asp:RegularExpressionValidator ID="FileTypeValidator" runat="server" ErrorMessage="File type not allowed: Accept PDF,DOC,XLS file type only" ValidationExpression="(.*pdf$)|(.*doc$)|(.*docx$)|(.*xls$)|(.*xlsx$)" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator><br />
						        </td>
                                <td class="col-md-2"></td>
					        </tr>
                            <tr> 
						        <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label4" runat="server" Text="Upload Dokumen Rincian"></asp:Label></td>
						        <td class="col-md-4">
                                    <asp:FileUpload ID="FileUpload2" runat="server"/>
							        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="File type not allowed: Accept PDF,DOC,XLS file type only" ValidationExpression="(.*pdf$)|(.*doc$)|(.*docx$)|(.*xls$)|(.*xlsx$)" ControlToValidate="FileUpload2"></asp:RegularExpressionValidator><br />
						        </td>
                                <td class="col-md-2"></td>
					        </tr>
                        </table>
                        <center>
                            <asp:Label ID="LblErrorSaveC" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <asp:Button ID="BtnNilaiSMSave" runat="server" Text="Simpan" class="btn btn-success" /> 
                        </center><br />
                    </div>
                </div>     
            </asp:View>
        </asp:MultiView>

         
        <asp:MultiView ID="MultiViewData" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
                <div class="container">
                    <center>
                        <h2 style="font-family:Cooper Black;">DOKUMEN LAPORAN DAN BERITA ACARA <br />AUDIT/STOCKOPNAME</h2>
                    </center>
	            </div><br /><br />

                <asp:SqlDataSource ID="SqlDataView" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_RINCIAN], [DOKUMEN_CABANG], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_DIKETAHUI2], [DOKUMEN_TGLDIKETAHUI2], [DOKUMEN_DISETUJUI], [DOKUMEN_TGLDISETUJUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE  ([DOKUMEN_DIKETAHUI] = ? OR [DOKUMEN_DIKETAHUI2] = ?)  AND [DOKUMEN_JENIS]='D'"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="lblArea1" Name="lblArea1" PropertyName= "Text" Type="String" />      
                        <asp:ControlParameter ControlID="lblArea2" Name="lblArea2" PropertyName= "Text" Type="String" />      
			        </selectparameters>
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailData" runat="server" DataSourceID="SqlDataView" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-b"  class="table table-bordered table-striped data2">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
                                <th style="text-align:center; color:white">Cabang</th>
                                <th style="text-align:center; color:white">Dibuat</th>
                                <th style="text-align:center; color:white">Diketahui I</th>
                                <th style="text-align:center; color:white">Diketahui II</th>
                                <th style="text-align:center; color:white">Disetujui</th>
                                <th style="text-align:center; color:white" class="col-md-1">Lihat Laporan</th>
                                <th style="text-align:center; color:white">Lihat Rincian</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_NAMA")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_CABANG")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_DIKETAHUI")%><br />
                                <%#Eval("DOKUMEN_TGLDIKETAHUI")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_DIKETAHUI2")%><br />
                                <%#Eval("DOKUMEN_TGLDIKETAHUI2")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_DISETUJUI")%><br />
                                <%#Eval("DOKUMEN_TGLDISETUJUI")%></p></td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_RINCIAN")%>"><img alt=""  src="img/dokumen3.png" width="35px" height="40px" /></a></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Berita Acara diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Berita Acara Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
            </asp:View> 
        </asp:MultiView> 
        
        <asp:MultiView ID="MultiViewData2" runat="server" Visible="TRUE">
            <asp:View ID="View3" runat="server">
                <div class="container">
                    <center>
                        <h2 style="font-family:Cooper Black;">DOKUMEN LAPORAN DAN BERITA ACARA <br />AUDIT/STOCKOPNAME</h2>
                    </center>
	            </div><br /><br />

                <asp:SqlDataSource ID="SqlDataView2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIBUAT], [DOKUMEN_RINCIAN], [DOKUMEN_CABANG], [DOKUMEN_TGLDIBUAT], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_DIKETAHUI2], [DOKUMEN_TGLDIKETAHUI2], [DOKUMEN_DISETUJUI], [DOKUMEN_TGLDISETUJUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN] WHERE  [DOKUMEN_TGLDIKETAHUI] IS NOT NULL AND [DOKUMEN_TGLDIKETAHUI2] IS NOT NULL AND [DOKUMEN_DISETUJUI] IS NOT NULL  AND [DOKUMEN_JENIS]='D'"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="lblArea1" Name="lblArea1" PropertyName= "Text" Type="String" />      
                        <asp:ControlParameter ControlID="lblArea2" Name="lblArea2" PropertyName= "Text" Type="String" />      
			        </selectparameters>
                </asp:SqlDataSource>                                             
                <asp:ListView ID="LvDetailData2" runat="server" DataSourceID="SqlDataView2" DataKeyNames ="DOKUMEN_NO">
                    <LayoutTemplate>
                        <table id="table-c"  class="table table-bordered table-striped data3">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white">Dokumen</th>
                                <th style="text-align:center; color:white">Cabang</th>
                                <th style="text-align:center; color:white">Dibuat</th>
                                <th style="text-align:center; color:white">Diketahui I</th>
                                <th style="text-align:center; color:white">Diketahui II</th>
                                <th style="text-align:center; color:white">Disetujui</th>
                                <th style="text-align:center; color:white" class="col-md-1">Lihat Laporan</th>
                                <th style="text-align:center; color:white">Lihat Rincian</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_NAMA")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_CABANG")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_DIBUAT")%><br />
                                <%#Eval("DOKUMEN_TGLDIBUAT")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_DIKETAHUI")%><br />
                                <%#Eval("DOKUMEN_TGLDIKETAHUI")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_DIKETAHUI2")%><br />
                                <%#Eval("DOKUMEN_TGLDIKETAHUI2")%></p></td>
                            <td><p class="small"><%#Eval("DOKUMEN_DISETUJUI")%><br />
                                <%#Eval("DOKUMEN_TGLDISETUJUI")%></p></td>
                            <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>"><img alt="" src="img/dokumen1.png" width="35px" height="40px" /></a></td>
                             <td align="center"><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_RINCIAN")%>"><img alt="" src="img/dokumen3.png" width="35px" height="40px" /></a></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Berita Acara diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Berita Acara Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
            </asp:View> 
        </asp:MultiView> 
    
    </div>
</asp:Content>

