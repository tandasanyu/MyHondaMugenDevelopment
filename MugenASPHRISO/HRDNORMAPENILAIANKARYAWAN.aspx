<%@ Page Language="VB" MasterPageFile ="~/MasterPage.master"  AutoEventWireup="false" CodeFile="HRDNORMAPENILAIANKARYAWAN.aspx.vb" Inherits="HRDNORMAPENILAIANKARYAWAN" title="Norma Penilaian Karyawan" %>
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

    <div class="container">
        <ul class="breadcrumb">
            <li><a href="#"><span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"><i class="glyphicon glyphicon-user"></i></a> &nbsp <a href="#"> HRD</a> </li>
            <li class="active"><span class="glyphicon glyphicon-edit"></span> &nbsp Penilaian Karyawan</li>
        </ul>
		<asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
			<asp:View ID="Viewerr00" runat="server">
				<asp:Label ID="lblMsgBox" runat="server">Judul Permohonan</asp:Label>
			</asp:View> 
		</asp:MultiView>
        
        <asp:MultiView ID="MultiViewNilaiStandard" runat="server" Visible="TRUE">
            <asp:View ID="ViewNilaiStandard" runat="server">  
                <div class="container">
                    <center>
						<h2 style="font-family:Cooper Black;">NORMA PENILAIAN KINERJA</h2>
                    </center>
                </div><br />
                <asp:Button ID="BtnStandard" runat="server" Text="Tambah Data" class="button button4"/>
                <br /><br />
                <asp:SqlDataSource ID="SqlDataKPIN" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [KPIN_TIPE], [KPIN_JUDUL], [KPIN_DESC], [KPIN_NILAI10], [KPIN_NILAI9], [KPIN_NILAI8], [KPIN_NILAI7], [KPIN_NILAI6], [KPIN_GROUP] FROM [DATA_KPIN] order by [KPIN_TIPE] ASC, [KPIN_GROUP] DESC"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                </asp:SqlDataSource>                                     
                <asp:ListView ID="LVNilaiStandard" runat="server" DataSourceID="SqlDataKPIN" DataKeyNames ="KPIN_TIPE">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered striped data" align="left">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white">No.</th>
                                <th style="text-align:center; color:white" class="col-md-3">Judul</th>
                                <th style="text-align:center; color:white">Nilai 10</th>
                                <th style="text-align:center; color:white">Nilai 9</th>
                                <th style="text-align:center; color:white">Nilai 8</th>
                                <th style="text-align:center; color:white">Nilai 7</th>
                                <th style="text-align:center; color:white">Nilai 6</th>
                                <th style="text-align:center; color:white" class="col-md-1">Lihat Detail</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table> 
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                            <td><p class="small"><%#Eval("KPIN_TIPE")%>. <%#Eval("KPIN_JUDUL")%> <br /><br />
                                <i><b>Def.</b></i> <%#Eval("KPIN_DESC")%></p></td>
                            <td><p class="small"><%#Eval("KPIN_NILAI10")%></p></td>
                            <td><p class="small"><%#Eval("KPIN_NILAI9")%></p></td>
                            <td><p class="small"><%#Eval("KPIN_NILAI8")%></p></td>
                            <td><p class="small"><%#Eval("KPIN_NILAI7")%></p></td>
                            <td><p class="small"><%#Eval("KPIN_NILAI6")%></p></td>
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
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Norma Penilaian Kinerja</font></div>
                    <div class="panel-body">
                        <center>
                            <h3 style="font-family:Blunter;">FORM NORMA PENILAIAN KINERJA</h3>
                        </center>
	                    <br /><br />
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
                                <td class="col-md-4"><asp:TextBox ID="TxtStandardJudul" runat="server" MaxLength="100" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label57" runat="server" Text="Keterangan"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtStandardKet" runat="server" MaxLength="200" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td>     
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label62" runat="server" Text="Nilai 100"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtStandardNilai10" TextMode ="MultiLine" rows="5" runat="server" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Nilai 90"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtStandardNilai9" TextMode ="MultiLine" rows="5" runat="server" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="Nilai 80"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtStandardNilai8" TextMode ="MultiLine" runat="server" rows="5" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Nilai 70"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtStandardNilai7" TextMode ="MultiLine" runat="server" rows="5"  Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label4" runat="server" Text="Nilai 60"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtStandardNilai6" TextMode ="MultiLine" runat="server" rows="5"  Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td>
                            </tr>
                        </table> 
                        <center>
                            <asp:Label ID="LblErrorSaveStandard" runat="server" Text="" style="color:red"></asp:Label>
                            <asp:Button ID="BtnStandardSave" runat="server" Text="Simpan" class="btn btn-success" />
                            <asp:Button ID="BtnStandardDel" runat="server" Text="Hapus" class="btn btn-danger" OnClientClick="return confirm('Apakah anda yakin akan menghapus norma penilaian ini?');"/>
                        </center>
                        <br /><br />
                    </div>
                </div>         
            </asp:View> 
        </asp:MultiView>
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