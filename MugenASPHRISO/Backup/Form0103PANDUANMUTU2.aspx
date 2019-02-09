<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Form0103PANDUANMUTU.aspx.vb" Inherits="SALES_Form0104PANDUANMUTU" title="Untitled Page" %>
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
    </style>    
    <p   style ="font-size:smaller" >
        <asp:Label ID="Label44"  Text ="&nbsp Informasi Akun >> " runat="server"></asp:Label>
        &nbsp; Nama User&nbsp; : 
        <asp:Label ID="LblUserName" runat="server"></asp:Label>
        <asp:Label ID="lblAkses" Style="display:none" runat="server"></asp:Label>
        &nbsp; Akses &nbsp; : 
        <asp:Label ID="lblArea1" runat="server"></asp:Label>
        <asp:Label ID="lblArea2" runat="server"></asp:Label>
    </p>

    <div class="container">

    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
    <asp:View ID="Viewerr00" runat="server">
    <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Judul Permohonan</asp:Label>
    </asp:View> 
    </asp:MultiView>
    <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
    <asp:View ID="View1Akses" runat="server">
        <div class="container">
            <center>
                <h2 style="font-family:Cooper Black;">DOKUMEN PANDUAN MUTU</h2>
            </center>
	    </div>  <br /><br />
        <table class="table table-borderless">
            <tr>
                <td class="col-md-2"></td>
                <td class="col-md-2"><asp:Label ID="LabelNIK" runat="server">ID</asp:Label></td>
                <td class="col-md-4"><asp:TextBox ID="TxtCariID" runat="server" MaxLength="10" class="form-control"></asp:TextBox></td>
                <td class="col-md-2"></td>
            </tr>
            <tr>
                <td class="col-md-2"></td>
                <td class="col-md-2"><asp:Label ID="Label22" runat="server">Nama Karyawan</asp:Label></td>
                <td class="col-md-4"><asp:TextBox ID="TxtDept" runat="server"  MaxLength="30" class="form-control"></asp:TextBox></td>
                <td class="col-md-2"></td>
            </tr>
        </table> 
        <br />
 
        <asp:Button ID="BtnMasterTabel" runat="server" Text="(+) Tambah Data" class="btn btn-primary" />
        <br /><br />
        <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
            SelectCommand="SELECT [DOKUMEN_NO], [DOKUMEN_NAMA], [DOKUMEN_DIKETAHUI], [DOKUMEN_TGLDIKETAHUI], [DOKUMEN_DISETUJUI], [DOKUMEN_TGLDISETUJUI], [DOKUMEN_LINK] FROM [TRXN_DOKUMEN]"
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
        </asp:SqlDataSource>                                             
        <asp:ListView ID="LvDetailMaster" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="DOKUMEN_NO">
            <LayoutTemplate>
            <table id="table-a"  class="table table-bordered table-striped">
                <thead style="background-color:#E8E8E8">
                    <th style="text-align:center">No.</th>
                    <th style="text-align:center">Dokumen</th>
                    <th style="text-align:center">Diketahui</th>
                    <th style="text-align:center">Disetujui</th>
                    <th style="text-align:center">Detail Dokumen</th>
                    <th style="text-align:center" class="col-md-1">Detail</th>
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
                    <td><%#Eval("DOKUMEN_DIKETAHUI")%><br />
                        <%#Eval("DOKUMEN_TGLDIKETAHUI")%></td>
                    <td><%#Eval("DOKUMEN_DISETUJUI")%><br />
                        <%#Eval("DOKUMEN_TGLDISETUJUI")%>
                    </td>
                    <td><a target="_blank" href="webdownload/dokumeniso/<%#Eval("DOKUMEN_LINK")%>">Link</a></td>
                    <td align="center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>Data Sasaran Mutu Tidak diketemukan</EmptyDataTemplate> 
            <EmptyItemTemplate>Data Sasaran Mutu Tidak diketemukan</EmptyItemTemplate>              
        </asp:ListView>
        <br />
        <asp:MultiView ID="MultiViewNilaiProgressEntry" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
                <br /><br />
                <div class="container">
                        <center>
                            <h3 style="font-family:Blunter;">FORM PANDUAN MUTU</h3>
                        </center>
	            </div><br />
                <table class="table table-borderless">
                    <tr>
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label8" runat="server" Text="ID"></asp:Label></td>
                        <td class="col-md-4"><asp:Label ID="lblBackupId" runat="server" Text="ID"></asp:Label></td>
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
                        <td class="col-md-2"><asp:Label ID="Label14" runat="server" Text="Disetujui"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtSDRSetuju" runat="server" MaxLength="10" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" Text =""></asp:TextBox>
                            <asp:Label ID="lblSDRSetuju" runat="server" Text="99/99/99"></asp:Label>
                            <asp:Button ID="BtnNilaiSMSave2" runat="server" Text="Klik disini" CssClass="btn btn-success" />
                        </td>
                        <td class="col-md-2"></td>
                    </tr>
                  
                    <tr>
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label19" runat="server" Text="Distribusi"></asp:Label></td>
                        <td class="col-md-2">
                            <asp:CheckBox ID="D1" runat="server" Text="&nbsp Direksi" /><br />
                            <asp:CheckBox ID="D2" runat="server" Text="&nbsp Oprational Support Manager"/><br />
                            <asp:CheckBox ID="D3" runat="server" Text="&nbsp SM PS. Minggu" /><br />
                            <asp:CheckBox ID="D4" runat="server" Text="&nbsp SM Puri"/><br /> 
                            <asp:CheckBox ID="D5" runat="server" Text="&nbsp Service Manager Ps.Minggu"/><br />
                            <asp:CheckBox ID="D6" runat="server" Text="&nbsp Service Manager Puri"/><br />
                            <asp:CheckBox ID="D7" runat="server" Text="&nbsp HRD & GA Head"/><br />
                            <asp:CheckBox ID="D8" runat="server" Text="&nbsp GA Puri"/><br />
                            <asp:CheckBox ID="D9" runat="server" Text="&nbsp Ka. Sparepart Ps. Minggu"/><br />
                            <asp:CheckBox ID="D10" runat="server" Text="&nbsp Ka. Sparepart Puri"/>
                        </td>
                        <td>
                            <asp:CheckBox ID="D11" runat="server" Text="&nbsp QMR"/><br />
                            <asp:CheckBox ID="D12" runat="server" Text="&nbsp ADH Ps.Minggu"/><br />
                            <asp:CheckBox ID="D13" runat="server" Text="&nbsp ADH Puri" /><br />
                            <asp:CheckBox ID="D14" runat="server" Text="&nbsp CC SPV"/><br />
                            <asp:CheckBox ID="D15" runat="server" Text="&nbsp CC Puri"/><br />
                            <asp:CheckBox ID="D16" runat="server" Text="&nbsp Internal Auditor"/><br />
                            <asp:CheckBox ID="D17" runat="server" Text="&nbsp WH Coordinator"/><br />
                            <asp:CheckBox ID="D18" runat="server" Text="&nbsp IT Head"/><br />
                            <asp:CheckBox ID="D19" runat="server" Text="&nbsp IT Puri" /><br />
                            <asp:CheckBox ID="D20" runat="server" Text="&nbsp Purchasing"/>
                        </td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
						<td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Upload Dokumen"></asp:Label></td>
						<td class="col-md-4">
                        <asp:FileUpload ID="FileUpload1" runat="server"/>
							<asp:RegularExpressionValidator ID="FileTypeValidator" runat="server" ErrorMessage="File type not allowed: Accept JPG file type only" ValidationExpression="^.+.((jpg))$" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator><br />
						</td>
                        <td class="col-md-2"></td>
					</tr>
            </table>
                
            <center>
                <asp:Label ID="LblErrorSaveC" runat="server" Text="" ForeColor="Red"></asp:Label>
            </center>
        
            <center>
                <asp:Button ID="BtnNilaiSMBack" runat="server" Text="Kembali Ke Menu Awal" class="btn btn-warning" />
                <asp:Button ID="BtnNilaiSMSave" runat="server" Text="Simpan" class="btn btn-primary" />
                <asp:Button ID="BtnNilaiSMDel" runat="server" Text="Hapus" class="btn btn-danger" />    
            </center>
            </asp:View>
        </asp:MultiView>
    </asp:View> 
    </asp:MultiView> 
</asp:Content>

