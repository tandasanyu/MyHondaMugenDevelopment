﻿<%@ Page Language="VB" MasterPageFile ="~/MasterPage.master"  AutoEventWireup="false" CodeFile="HRDPENILAIANKARYAWAN.aspx.vb" Inherits="HRDPENILAIANKARYAWAN" title="Penilaian Karyawan" %>
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
        
        <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
			<asp:View ID="View0102Karyawan" runat="server">
                <div class="container">
                    <center>
                        <h2 style="font-family:Cooper Black;">DATA KEY PERFORMANCE INDICATOR <br /> (KPI)</h2>
                    </center>
                </div><br />
				<h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Data Diri</h3>
				<br />
			    <table class="table table-borderless" align="left">
				    <tr>
				        <td class="col-md-2"><asp:Label ID="Label66" runat="server" Text="NIK"></asp:Label></td>
			            <td class="col-md-4"><asp:Label ID="TxtStaffNIK" runat="server" Text="" class="form-control required"></asp:Label></td>
                        <td class="col-md-2"><asp:Label ID="Label29" runat="server" Text="Department / Jabatan"></asp:Label></td>
					    <td class="col-md-4"><asp:Label ID="TxtStatusKerjaDept" runat="server" MaxLength="15" Text ="" class="form-control required"></asp:Label></td>
					    
				    </tr>
				    <tr>
                        <td class="col-md-2"><asp:Label ID="Label8" runat="server" Text="Nama"></asp:Label></td>
				        <td class="col-md-4"><asp:Label ID="TxtStaffNama" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:Label></td>
					    <td class="col-md-2"><asp:Label ID="Label9" runat="server" Text="Lokasi"></asp:Label></td>
				        <td class="col-md-4"><asp:Label ID="TxtStatusKerjaTempat" runat="server" MaxLength="15" Text ="" class="form-control required"></asp:Label></td>
				    </tr>
			    </table><br /><br /><br /><br /><br /><br />
            </asp:View>
        </asp:MultiView>

        <asp:MultiView ID="MultiViewNilaiStandard" runat="server" Visible="TRUE">
            <asp:View ID="ViewNilaiStandard" runat="server">  
                <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">NORMA PENILAIAN KINERJA</h3>
                    </center>
                </div><br />
                 <asp:Button ID="BtnStandardTabel2" runat="server" Text="Tutup Tabel Norma" class="btn btn-default"/>
                <asp:Button ID="BtnStandard" runat="server" Text="Tambah Data" class="button button4"/>
                <br /><br />
                <asp:SqlDataSource ID="SqlDataKPIN" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [KPIN_TIPE], [KPIN_JUDUL], [KPIN_DESC], [KPIN_NILAI10], [KPIN_NILAI9], [KPIN_NILAI8], [KPIN_NILAI7], [KPIN_NILAI6], [KPIN_GROUP] FROM [DATA_KPIN]"
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
                            <td><p class="small"><%#Eval("KPIN_JUDUL")%> <br /><br />
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
                                <td class="col-md-4"><asp:TextBox ID="TxtStandardJudul" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
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
                            <asp:Button ID="BtnStandardBack" runat="server" Text="Kembali Ke Tabel" class="btn btn-warning" />
                            <asp:Button ID="BtnStandardSave" runat="server" Text="Simpan" class="btn btn-success" />
                            <asp:Button ID="BtnStandardDel" runat="server" Text="Hapus" class="btn btn-danger" />
                        </center>
                        <br /><br />
                    </div>
                </div>         
            </asp:View> 
        </asp:MultiView>            

        <asp:MultiView ID="MultiViewKpiMaster" runat="server" Visible="TRUE">
            <asp:View ID="ViewTampilKpiMasterSumary" runat="server">  
                <br /><br />
                
                <asp:Button ID="BtnStandardTabel" runat="server" Text="Buka Tabel Norma" class="btn btn-default"/>
                <asp:Button ID="BtnKpi40Master" runat="server" Text="Tambah Data KPI" class="button button4"/>
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
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white" class="col-md-1">No.</th>
                                <th style="text-align:center; color:white">Tahun</th>
                                <th style="text-align:center; color:white">Jenis Karyawan1</th>
                                <th style="text-align:center; color:white">Jenis Karyawan2</th>
                                <th style="text-align:center; color:white">HRD Disetujui</th>
                                <th style="text-align:center; color:white">Nilai</th>
                                <th style="text-align:center; color:white">Grade</th>
                                <th style="text-align:center; color:white" class="col-md-1">Aksi</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="9" runat="server">
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

                        <div class="panel panel-default">
                            <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Data Key Performance Indicator (KPI)</font></div>
                            <div class="panel-body">
                                <center>
                                    <h3 style="font-family:Blunter;">DATA KEY PERFORMANCE INDICATOR (KPI)</h3>
                                </center>
	                        <br /><br />
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td> 
                                    <td class="col-md-2"><asp:Label ID="Label69" runat="server" Text="Tahun Penilaian"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:TextBox ID="TxtKpiSummaryTahun" runat="server" MaxLength="4" Text ="" class="form-control required"></asp:TextBox>
                                        <asp:Label ID="lblKpiSummaryTahun" runat="server" Text="" style="display:none;"></asp:Label>
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label71" runat="server" Text="Tipe"></asp:Label></td>
                                    <td class="col-md-4">
                                        <asp:TextBox ID="TxtKpiSummaryPosA" runat="server" MaxLength="1" Text ="" class="form-control required"></asp:TextBox><br />
                                        <p class="small">[A] Percobaan &nbsp [B] Staff &nbsp [C] Manager &nbsp [D] SPV No Team &nbsp [E] SPV With Team </p>
                                        <asp:Label ID="lblKpiSummaryPosA" runat="server" Text="" style="display:none;"></asp:Label>
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
                                <asp:Button ID="BtnKpi40MasterCopy" runat="server" Text="Copy" class="btn btn-default" />
                                <asp:Button ID="BtnKpi40MasterNew" runat="server"  Text="Buat Baru" class="btn btn-success" />
                                <asp:Button ID="BtnKpi40MasterDel" runat="server" Text="Hapus" class="btn btn-danger" />
                                
                            </center>     
                            <br /><br />
                        </div>
                    </div>
                </asp:View> 
            </asp:MultiView> 

            <asp:MultiView ID="MultiViewKPIMasterDetail" runat="server" Visible="TRUE">
                <asp:View ID="ViewTampilKpiMasterDetail" runat="server">  
                    <div style="margin-top:25px; border-top:2px dotted #ff0000;"></div>
                    <br /><br />
                    <div class="container">
                        <center>
                            <h3 style="font-family:Blunter;">RAPORT KEY PERFORMANCE INDICATOR</h3>
                        </center>
	                </div><br />
                    <asp:Button ID="BtnKpi40" runat="server" Text="Tambah Data" class="button button4"/>
                    <br /><br />
                    <asp:SqlDataSource ID="SqlDataKpiMaster" runat="server"
                        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                        SelectCommand="SELECT [KPID_NIK], [KPID_BOBOT], [KPID_NILAISTAFF], [KPID_NILAIAKHIR], [KPID_ITEM],[KPID_TARGET], [KPID_PRESTASI], [KPID_TYPEA],[KPID_BULAN01],  [KPID_BULAN02], [KPID_BULAN03], [KPID_BULAN04], [KPID_BULAN05], [KPID_BULAN07], [KPID_BULAN06], [KPID_BULAN08], [KPID_BULAN09], [KPID_BULAN10], [KPID_BULAN11], [KPID_BULAN12] FROM [TRXN_KPID] WHERE ([KPID_NIK] = ?) AND ([KPID_TAHUN] = ?)"
                        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TxtStaffNIK" Name="KPID_NIK" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="TxtKpiSummaryTahun" Name="KPID_TAHUN" PropertyName="Text" Type="String" />
                        </SelectParameters>
                       
                    </asp:SqlDataSource>                                     
                    <asp:ListView ID="LvKPIMasterDetail" runat="server" DataSourceID="SqlDataKpiMaster" DataKeyNames ="KPID_ITEM">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered striped" align="left">
                            <tr style="background-color:#4877CF">
                                <th rowspan="2" style="text-align:center; color:white" class="col-md-1">No.</th>
                                <th rowspan="2" style="text-align:center; color:white">Item KPI</th>
                                <th rowspan="2" style="text-align:center; color:white">Bobot (B)</th>
                                <th rowspan="2" style="text-align:center; color:white">Target (T)</th>
                                <th colspan="12" style="text-align:center; color:white">Bulan</th>
                           
                                <th rowspan="2" style="text-align:center; color:white">Prestasi(P)</th>
                                <th rowspan="2" class="col-md-1" style="text-align:center; color:white">Nilai <br /> (B x P)</th>
                                <th rowspan="2" style="text-align:center; color:white" class="col-md-1"></th>
                            </tr>         
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white">1</th>
                                <th style="text-align:center; color:white">2</th>
                                <th style="text-align:center; color:white">3</th>
                                <th style="text-align:center; color:white">4</th>
                                <th style="text-align:center; color:white">5</th>
                                <th style="text-align:center; color:white">6</th>
                                <th style="text-align:center; color:white">7</th>
                                <th style="text-align:center; color:white">8</th>
                                <th style="text-align:center; color:white">9</th>
                                <th style="text-align:center; color:white">10</th>
                                <th style="text-align:center; color:white">11</th>
                                <th style="text-align:center; color:white">12</th>
                            </tr>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                        <asp:DataPager ID="dpBerita" PageSize="9" runat="server">
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
                        <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                        <td><p class="small"><%# Eval("KPID_ITEM") %></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_BOBOT")%>%</p></td>
                        <td><p class="small"><%#Eval("KPID_TARGET")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_BULAN01")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_BULAN02")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_BULAN03")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_BULAN04")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_BULAN05")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_BULAN06")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_BULAN07")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_BULAN08")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_BULAN09")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_BULAN10")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_BULAN11")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_BULAN12")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_NILAISTAFF")%></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPID_NILAIAKHIR")%></p></td>
                        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
              
                <EmptyDataTemplate>Report Key Performance Indicator Tidak diketemukan</EmptyDataTemplate> 
                <EmptyItemTemplate>Report Key Performance Indicator Tidak diketemukan</EmptyItemTemplate>              
            </asp:ListView>
           </asp:View> 
        </asp:MultiView> <br /><br />

        <asp:MultiView ID="MultiViewKPIMasterDetailENtry" runat="server" Visible="TRUE">
            <asp:View ID="ViewKPIMasterENtry" runat="server">  
                <br />
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Raport Key Performance Indicator</font></div>
                    <div class="panel-body">
                        <center>
                            <h3 style="font-family:Blunter;">FORM RAPORT KEY PERFORMANCE INDICATOR</h3>
                        </center>
	                    <br /><br />
                         <table class="table table-borderless">
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label91" runat="server" Text="Item KPI"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiItem" TextMode ="MultiLine" rows="3" runat="server" MaxLength="200" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"><asp:Label ID="Label6" runat="server" Text="Bobot"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtMasterBobot" runat="server" TextMode ="MultiLine" rows="3" MaxLength="200" Text ="" class="form-control required"></asp:TextBox></td>
                            </tr>
                            <tr id="kolom14" runat="server"> 
                                <td class="col-md-2"><asp:Label ID="Label61" runat="server" Text="Perhitungan"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiPrestasi" TextMode ="MultiLine" rows="3" runat="server" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"><asp:Label ID="Label60" runat="server" Text="Target"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtMasterKpiTarget" runat="server" TextMode ="MultiLine" rows="3" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                            </tr>
                        </table>
                        <div id="penilaianbulanan" runat="server">
                        <font color="red"><b>Notes:</b></font> <br />
                         1. Jika tidak ada permintaan dalam bulan tertentu isi dengan "N/A" <br />
                         2. Koma menggunakan "." (Titik) <br />
                         3. Pembulatan desimal 2 angka dibelakang koma <br /><br />
                        <table class="table table-bordered striped" >
                            <tr style="background-color:#4877CF">
                                 <th colspan="12" style="text-align:center; color:white"><asp:Label ID="Label78" runat="server" Text="Bulan"></asp:Label></th>
                            </tr>
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white"><asp:Label ID="Label22" runat="server" Text="1"></asp:Label></th>
                                <th style="text-align:center; color:white"><asp:Label ID="Label11" runat="server" Text="2"></asp:Label></th>
                                <th style="text-align:center; color:white"><asp:Label ID="Label12" runat="server" Text="3"></asp:Label></th>
                                <th style="text-align:center; color:white"><asp:Label ID="Label13" runat="server" Text="4"></asp:Label></th>
                                <th style="text-align:center; color:white"><asp:Label ID="Label14" runat="server" Text="5"></asp:Label></th>
                                <th style="text-align:center; color:white"><asp:Label ID="Label15" runat="server" Text="6"></asp:Label></th>
                                <th style="text-align:center; color:white"><asp:Label ID="Label16" runat="server" Text="7"></asp:Label></th>
                                <th style="text-align:center; color:white"><asp:Label ID="Label17" runat="server" Text="8"></asp:Label></th>
                                <th style="text-align:center; color:white"><asp:Label ID="Label18" runat="server" Text="9"></asp:Label></th>
                                <th style="text-align:center; color:white"><asp:Label ID="Label19" runat="server" Text="10"></asp:Label></th>
                                <th style="text-align:center; color:white"><asp:Label ID="Label20" runat="server" Text="11"></asp:Label></th>
                                <th style="text-align:center; color:white"><asp:Label ID="Label21" runat="server" Text="12"></asp:Label></th>
                            </tr>
                            <tr>
                                <td><asp:TextBox ID="TxtMasterKpiBln01" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="TxtMasterKpiBln02" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="TxtMasterKpiBln03" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="TxtMasterKpiBln04" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="TxtMasterKpiBln05" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="TxtMasterKpiBln06" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="TxtMasterKpiBln07" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="TxtMasterKpiBln08" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="TxtMasterKpiBln09" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="TxtMasterKpiBln10" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="TxtMasterKpiBln11" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                                <td><asp:TextBox ID="TxtMasterKpiBln12" runat="server" MaxLength="50" Text ="" class="form-control required"></asp:TextBox></td>
                            </tr>
                        </table> 
                            </div>
                        <center>
                            <asp:Label ID="LblErrorSaveKpi40" runat="server" Text="" style="color:red"></asp:Label>
                            <asp:Button ID="BtnKpi40Back" runat="server" Text="Kembali Ke Tabel" class="btn btn-warning" />
                            <asp:Button ID="BtnKpi40Save" runat="server" Text="Simpan" class="btn btn-success" />
                            <asp:Button ID="BtnKpi40Del" runat="server" Text="Hapus" class="btn btn-danger" />
                        </center><br /><br /> 
                    </div>
                </div> 
            </asp:View> 
        </asp:MultiView>            
      
       
        <!-- A-Percobaaan -- B-STAFF,C-Leader d:SPV no tim E SPV With TEam -->
        <asp:MultiView ID="MultiViewProsesTabel" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">  
                <div style="margin-top:25px; border-top:2px dotted #ff0000;"></div>
                <br />
                <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">PROSES</h3>
                    </center>
	            </div><br /><br />
                <asp:Button ID="btnShow2" runat="server" Text="Norma Penilaian" class="button button2" />    
                <br /><br />
                <asp:SqlDataSource ID="SqlDataProses" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT DATA_KPIN.KPIN_JUDUL, TRXN_KPIDD.KPI_NIK, TRXN_KPIDD.KPI_TARGET, TRXN_KPIDD.KPI_STAFF, TRXN_KPIDD.KPI_ATASAN, TRXN_KPIDD.KPI_TIPEA, TRXN_KPIDD.KPI_KOMENTAR, TRXN_KPIDD.KPI_TAHUN, TRXN_KPIDD.KPI_KODEITEM FROM TRXN_KPIDD LEFT OUTER JOIN DATA_KPIN ON TRXN_KPIDD.KPI_KODEITEM = DATA_KPIN.KPIN_TIPE WHERE (TRXN_KPIDD.KPI_TIPEA = 'A') AND (TRXN_KPIDD.KPI_NIK = ?) AND (TRXN_KPIDD.KPI_TAHUN = ?) ORDER BY [KPI_KODEITEM]"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtStaffNIK" Name="KPI_NIK" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="TxtKpiSummaryTahun" Name="KPI_TAHUN" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>                                     
                <asp:ListView ID="LVProses" runat="server" DataSourceID="SqlDataProses" DataKeyNames ="KPI_KODEITEM">
                    <LayoutTemplate>
                        <table id="table-a"   class="table table-bordered striped" align="left">
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white" class="col-md-1" rowspan="2">No.</th>
                                <th style="text-align:center; color:white" rowspan="2">Kode</th>
                                <th style="text-align:center; color:white" rowspan="2">Aspect</th>
                                <th style="text-align:center; color:white" colspan="3">Performance Value</th>
                                <th style="text-align:center; color:white" class="col-md-1"rowspan="2"></th>
                            </tr>
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white">Self</th>
                                <th style="text-align:center; color:white">SPV</th>
                                <th style="text-align:center; color:white">Komentar</th>
                            </tr>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                        <asp:DataPager ID="dpBerita" PageSize="9" runat="server">
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
                            <td style="text-align:center"><%#Eval("KPI_KOMENTAR")%></td>
                            <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Proses Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Proses Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
            </asp:View> 
        </asp:MultiView>             
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel2" TargetControlID="btnShow2"
            CancelControlID="btnClose2" BackgroundCssClass="ModalPopupBG">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="Panel2" runat="server" CssClass="modal-dialog" align="center" style = "display:none">
        <!-- Modal content-->
            <div class="modal-content" style="max-height: 500px; margin-left:-200px; margin-top:-55px; min-width:1000px;overflow: auto;">
                <div class="modal-header">
                    <h4 class="modal-title">Penilaian Standard Proses</h4>
                </div>
                <div class="modal-body">
                    <asp:SqlDataSource ID="SqlDataKPIN3" runat="server"
                        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                        SelectCommand="SELECT [KPIN_TIPE], [KPIN_JUDUL], [KPIN_DESC], [KPIN_NILAI10], [KPIN_NILAI9], [KPIN_NILAI8], [KPIN_NILAI7], [KPIN_NILAI6], [KPIN_GROUP] FROM [DATA_KPIN] WHERE [KPIN_GROUP] IN ('HEAD','PROCESS') order by [KPIN_TIPE] asc"
                        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    </asp:SqlDataSource>                                     
                    <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataKPIN3" DataKeyNames ="KPIN_TIPE">
                        <LayoutTemplate>
                            <table id="table-a" class="table table-bordered table-striped">
                                <tr style="background-color:#4877CF">
                                    <td style="text-align:center; color:white" rowspan="2">No.</td>
                                    <td style="text-align:center; color:white" rowspan="2" class="col-md-3">Kriteria</td>
                                    <td style="text-align:center; color:white" colspan="5">Nilai</td>
                                </tr>
                                <tr style="background-color:#4877CF">
                                    <td style="text-align:center; color:white">100</td>
                                    <td style="text-align:center; color:white">90</td>
                                    <td style="text-align:center; color:white">80</td>
                                    <td style="text-align:center; color:white">70</td>
                                    <td style="text-align:center; color:white">60</td>
                                </tr>
                                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                                <td><p class="small"><%#Eval("KPIN_JUDUL")%></p></td>
                                <td><p class="small"><%#Eval("KPIN_NILAI10")%></p></td>
                                <td><p class="small"><%#Eval("KPIN_NILAI9")%></p></td>
                                <td><p class="small"><%#Eval("KPIN_NILAI8")%></p></td>
                                <td><p class="small"><%#Eval("KPIN_NILAI7")%></p></td>
                                <td><p class="small"><%#Eval("KPIN_NILAI6")%></p></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>Data Nilai Standard Tidak diketemukan</EmptyDataTemplate> 
                        <EmptyItemTemplate>Data Nilai Standard Tidak diketemukan</EmptyItemTemplate>              
                    </asp:ListView><br />
                     <button type="button" class="btn btn-danger" ID="btnClose2" data-dismiss="modal">Tutup</button>
                </div>
            </div>
        </asp:Panel>
        <asp:MultiView ID="MultiViewProsesEntry" runat="server" Visible="TRUE">
            <asp:View ID="ViewKerjaAEntry" runat="server">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Proses</font></div>
                        <div class="panel-body">
                            <center>
                                <h2 style="font-family:Blunter;">FORM PROSES</h2>
                            </center>
	                        <br /><br />   
                            <table class="table table-borderless">
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label63" runat="server" Text="Aspect"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="LblProsesKodeItem" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="LblProsesJudulJudul" runat="server" Text=""></asp:Label>
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
                                    <td class="col-md-2"><asp:Label ID="Label113" runat="server" Text="Komentar Atasan"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtProsesKomentar" runat="server" TextMode ="MultiLine" rows="5" Text ="" class="form-control required"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table> 
                            <center>
                                <asp:Label ID="LblErrorSaveKpi42A" runat="server" Text="" style="color:red"></asp:Label><br />
                                <asp:Button ID="BtnKpi42ABack" runat="server" Text="Kembali Ke Tabel" class="btn btn-warning" />
                                <asp:Button ID="BtnKpi42ASave" runat="server" Text="Simpan" class="btn btn-success" />
                            </center><br />     
                        </div>
                    </div>
             
            </asp:View> 
        </asp:MultiView>  

         <!-- E SPV With TEam -->
        <asp:MultiView ID="MultiViewPeopleTabel" runat="server" Visible="TRUE">
            <asp:View ID="ViewKerjaBT" runat="server">  
                <div style="margin-top:25px; border-top:2px dotted #ff0000;"></div>
                <br />
                <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">PEOPLE MANAGEMENT</h3>
                    </center>
	            </div><br />
                <asp:Button ID="btnShow3" runat="server" Text="Norma Penilaian" class="button button2" />  
                <br /><br />
                <asp:SqlDataSource ID="SqlDataPeople" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT DATA_KPIN.KPIN_JUDUL, TRXN_KPIDD.KPI_NIK, TRXN_KPIDD.KPI_TARGET, TRXN_KPIDD.KPI_STAFF, TRXN_KPIDD.KPI_ATASAN, TRXN_KPIDD.KPI_TIPEA, TRXN_KPIDD.KPI_KOMENTAR, TRXN_KPIDD.KPI_TAHUN, TRXN_KPIDD.KPI_KODEITEM FROM TRXN_KPIDD LEFT OUTER JOIN DATA_KPIN ON TRXN_KPIDD.KPI_KODEITEM = DATA_KPIN.KPIN_TIPE WHERE (TRXN_KPIDD.KPI_TIPEA = 'C') AND (TRXN_KPIDD.KPI_NIK = ?) AND (TRXN_KPIDD.KPI_TAHUN = ?) ORDER BY [KPI_KODEITEM]"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtStaffNIK" Name="KPI_NIK" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="TxtKpiSummaryTahun" Name="KPI_TAHUN" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>                                     
                <asp:ListView ID="LVPeople" runat="server" DataSourceID="SqlDataPeople" DataKeyNames ="KPI_KODEITEM">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered striped" align="left">
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white" class="col-md-1" rowspan="2">No.</th>
                                <th style="text-align:center; color:white" rowspan="2">Kode</th>
                                <th style="text-align:center; color:white" rowspan="2">Aspect</th>
                                <th style="text-align:center; color:white" colspan="3">Performance Value</th>
                                <th style="text-align:center; color:white" class="col-md-1" rowspan="2"></th>
                            </tr>
                            <tr style="background-color:#4877CF">
                                <th style="text-align:center; color:white">Self</th>
                                <th style="text-align:center; color:white">SPV</th>
                                <th style="text-align:center; color:white">Komentar Atasan</th>
                            </tr>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="9" runat="server">
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
                            <td><%#Eval("KPI_KOMENTAR")%></td>
                            <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/details.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data People Management Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data People Management Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br />
            </asp:View> 
        </asp:MultiView>   
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel4" TargetControlID="btnShow3"
            CancelControlID="btnClose3" BackgroundCssClass="ModalPopupBG">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="Panel4" runat="server" CssClass="modal-dialog" align="center" style = "display:none">
        <!-- Modal content-->
            <div class="modal-content" style="max-height: 500px; margin-left:-200px; margin-top:-55px; min-width:1000px;overflow: auto;">
                <div class="modal-header">
                    <h4 class="modal-title">Penilaian Standard Leadership</h4>
                </div>
                <div class="modal-body">
                    <asp:SqlDataSource ID="SqlDataKPIN4" runat="server"
                        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                        SelectCommand="SELECT [KPIN_TIPE], [KPIN_JUDUL], [KPIN_DESC], [KPIN_NILAI10], [KPIN_NILAI9], [KPIN_NILAI8], [KPIN_NILAI7], [KPIN_NILAI6], [KPIN_GROUP] FROM [DATA_KPIN] WHERE [KPIN_GROUP] IN ('HEAD','PROCESS') order by [KPIN_TIPE] asc"
                        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    </asp:SqlDataSource>                                     
                    <asp:ListView ID="ListView3" runat="server" DataSourceID="SqlDataKPIN4" DataKeyNames ="KPIN_TIPE">
                        <LayoutTemplate>
                            <table id="table-a" class="table table-bordered table-striped">
                                <tr style="background-color:#4877CF">
                                    <td style="text-align:center; color:white" rowspan="2">No.</td>
                                    <td style="text-align:center; color:white" rowspan="2" class="col-md-3">Kriteria</td>
                                    <td style="text-align:center; color:white" colspan="5">Nilai</td>
                                </tr>
                                <tr style="background-color:#4877CF">
                                    <td style="text-align:center; color:white">100</td>
                                    <td style="text-align:center; color:white">90</td>
                                    <td style="text-align:center; color:white">80</td>
                                    <td style="text-align:center; color:white">70</td>
                                    <td style="text-align:center; color:white">60</td>
                                </tr>
                                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                            </table>
                        </LayoutTemplate>
        
                        <ItemTemplate>
                            <tr>
                                <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                                <td><p class="small"><%#Eval("KPIN_JUDUL")%></p></td>
                                <td><p class="small"><%#Eval("KPIN_NILAI10")%></p></td>
                                <td><p class="small"><%#Eval("KPIN_NILAI9")%></p></td>
                                <td><p class="small"><%#Eval("KPIN_NILAI8")%></p></td>
                                <td><p class="small"><%#Eval("KPIN_NILAI7")%></p></td>
                                <td><p class="small"><%#Eval("KPIN_NILAI6")%></p></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>Data Nilai Standard Tidak diketemukan</EmptyDataTemplate> 
                        <EmptyItemTemplate>Data Nilai Standard Tidak diketemukan</EmptyItemTemplate>              
                    </asp:ListView><br />
                     <button type="button" class="btn btn-danger" ID="btnClose3" data-dismiss="modal">Tutup</button>
                </div>
            </div>
        </asp:Panel>
        <asp:MultiView ID="MultiViewPeopleEntry" runat="server" Visible="TRUE">
            <asp:View ID="ViewKpiKerjaBE" runat="server">    
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form People Management</font></div>
                    <div class="panel-body">
                        <center>
                            <h2 style="font-family:Blunter;">FORM PEOPLE MANAGEMENT</h2>
                        </center>
	                    <br /><br />
               
                        <table class="table table-borderless">
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label115" runat="server" Text="Aspect"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:Label ID="LblPeopleKode" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="LblPeopleJudul" runat="server" Text=""></asp:Label>
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
                                <td class="col-md-4"><asp:TextBox ID="TxtPeopleKomentar" runat="server" TextMode ="MultiLine" rows="5" Text ="" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td>
                            </tr>
                        </table> 
                        <center>
                            <asp:Label ID="LblErrorSaveKpi42B" runat="server"  Text="" style="color:red"></asp:Label><br />
                            <asp:Button ID="BtnKpi42BBack" runat="server" Text="Kembali Ke Tabel" class="btn btn-warning" />
                            <asp:Button ID="BtnKpi42BSave" runat="server" Text="Simpan" class="btn btn-success" />
                        </center>   
                    </div>
                </div>            
            </asp:View> 
        </asp:MultiView>  

         <!-- B-STAFF,C-Leader -->
        <asp:MultiView ID="MultiViewDisiplin" runat="server" Visible="TRUE">
            <asp:View ID="ViewDisiplin" runat="server">
                <div style="margin-top:25px; border-top:2px dotted #ff0000;"></div><br />
                <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">DISIPLIN</h3>
                    </center>
	            </div><br />           
                <asp:Button ID="btnShow" runat="server" Text="Norma Penilaian" class="button button2" />
                <br /><br />
                <asp:SqlDataSource ID="SqlDataDisiplin" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT DATA_KPIN.KPIN_JUDUL, TRXN_KPIDD.KPI_NIK, TRXN_KPIDD.KPI_TARGET, TRXN_KPIDD.KPI_STAFF, TRXN_KPIDD.KPI_ATASAN, TRXN_KPIDD.KPI_TIPEA, TRXN_KPIDD.KPI_AKHIR, TRXN_KPIDD.KPI_TAHUN, TRXN_KPIDD.KPI_KODEITEM FROM TRXN_KPIDD LEFT OUTER JOIN DATA_KPIN ON TRXN_KPIDD.KPI_KODEITEM = DATA_KPIN.KPIN_TIPE WHERE (TRXN_KPIDD.KPI_TIPEA = 'C') AND (TRXN_KPIDD.KPI_NIK = ?) AND (TRXN_KPIDD.KPI_TAHUN = ?) ORDER BY [KPI_KODEITEM]"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtStaffNIK" Name="KPI_NIK" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="TxtKpiSummaryTahun" Name="KPI_TAHUN" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>                                     
                <asp:ListView ID="LvDisiplin" runat="server" DataSourceID="SqlDataDisiplin" DataKeyNames ="KPI_KODEITEM">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered striped" align="left">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white" class="col-md-1">No.</th>
                                <th style="text-align:center; color:white">Kode</th>
                                <th style="text-align:center; color:white">Keterangan</th>
                                <th style="text-align:center; color:white">Nilai</th>
                                <th style="text-align:center; color:white" class="col-md-1">Lihat Detail</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                        <asp:DataPager ID="dpBerita" PageSize="9" runat="server">
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
                <br /><br /><br />
            </asp:View> 
        </asp:MultiView>            
        <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
            CancelControlID="btnClose" BackgroundCssClass="ModalPopupBG">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="Panel1" runat="server" CssClass="modal-dialog" align="center" style = "display:none">
        <!-- Modal content-->
            <div style="overflow: auto; margin-left:-200px; margin-top:-55px; min-width:1000px; min-height:150px;">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Penilaian Standard Disiplin</h4>
                    </div>
                    <div class="modal-body">
                        <asp:SqlDataSource ID="SqlDataKPIN2" runat="server"
                            ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                            SelectCommand="SELECT [KPIN_TIPE], [KPIN_JUDUL], [KPIN_DESC], [KPIN_NILAI10], [KPIN_NILAI9], [KPIN_NILAI8], [KPIN_NILAI7], [KPIN_NILAI6], [KPIN_GROUP] FROM [DATA_KPIN] WHERE [KPIN_GROUP]='ABSEN' order by [KPIN_TIPE] asc"
                            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                        </asp:SqlDataSource>                                     
                        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataKPIN2" DataKeyNames ="KPIN_TIPE">
                            <LayoutTemplate>
                                <table id="table-a" class="table table-bordered table-striped">
                                    <tr style="background-color:#4877CF">
                                        <td style="text-align:center; color:white" rowspan="2">No.</td>
     
                                        <td style="text-align:center; color:white" rowspan="2" class="col-md-3">Kriteria</td>
                                        <td style="text-align:center; color:white" colspan="5">Nilai</td>
                                        </tr>
                                    <tr style="background-color:#4877CF">
                                    
                                        <td style="text-align:center; color:white">90</td>
                                        <td style="text-align:center; color:white">80</td>
                                        <td style="text-align:center; color:white">70</td>
                                        <td style="text-align:center; color:white">60</td>
                                        <td style="text-align:center; color:white">50</td>
                                    </tr>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </table>
                            </LayoutTemplate>
        
                            <ItemTemplate>
                                <tr>
                                    <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                                    <td><p class="small"><%#Eval("KPIN_JUDUL")%></p></td>
                                    <td><p class="small"><%#Eval("KPIN_NILAI10")%></p></td>
                                    <td><p class="small"><%#Eval("KPIN_NILAI9")%></p></td>
                                    <td><p class="small"><%#Eval("KPIN_NILAI8")%></p></td>
                                    <td><p class="small"><%#Eval("KPIN_NILAI7")%></p></td>
                                    <td><p class="small"><%#Eval("KPIN_NILAI6")%></p></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>Data Nilai Standard Tidak diketemukan</EmptyDataTemplate> 
                            <EmptyItemTemplate>Data Nilai Standard Tidak diketemukan</EmptyItemTemplate>              
                        </asp:ListView><br />
                        <button type="button" class="btn btn-danger" ID="btnClose" data-dismiss="modal">Tutup</button>
                    </div>
                </div>
            </div>
        </asp:Panel>        
        <asp:MultiView ID="MultiViewDisplinEntry" runat="server" Visible="TRUE">
            <asp:View ID="ViewDisplinE" runat="server">   
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Disiplin</font></div>
                    <div class="panel-body">
                        <center>
                            <h2 style="font-family:Blunter;">FORM DISIPLIN</h2>
                        </center>
	                    <br /><br />
                        <table class="table table-borderless">
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label119" runat="server" Text="Keterangan"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:Label ID="lblDisiplinKode" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblDisiplinJudul" runat="server" Text=""></asp:Label>
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
                            <asp:Button ID="BtnKpi43Save" runat="server" Text="Simpan" class="btn btn-success"/>
                            <asp:Button ID="BtnKpi43Back" runat="server" Text="Hapus" class="btn btn-danger" />
                        </center><br />    
                    </div>
                </div>         
            </asp:View> 
        </asp:MultiView>  

        <asp:MultiView ID="MultiViewOthers" runat="server" Visible="TRUE">
            <asp:View ID="View8" runat="server">    
                <div class="container">
                    <center>
                        <h3 style="font-family:Blunter;">HASIL</h3>
                    </center>
	            </div><br />  
                <table class="table table-borderless">
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label121" runat="server" Text="Total Nilai A"></asp:Label></td>
                        <td class="col-md-4"><asp:TextBox ID="TxtKpiPercenNilai1" runat="server" MaxLength="4" Text ="" style="width: 70px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                            <asp:Label ID="Label76" runat="server" Text=" x  "></asp:Label>
                            <asp:TextBox ID="TxtKpiTotalNilai1" runat="server" MaxLength="4" Text ="0" style="width: 70px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                            <asp:Label ID="Label5" runat="server" Text=" =  "></asp:Label>
                            <asp:TextBox ID="LblNiaiAkhir1" runat="server" Text="" style="width: 70px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ForeColor="Black"></asp:TextBox>
                        </td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label70" runat="server" Text="Total Nilai B"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtKpiPercenNilai2" runat="server" MaxLength="4" Text ="" style="width: 70px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                            <asp:Label ID="Label77" runat="server" Text=" x  "></asp:Label>
                            <asp:TextBox ID="TxtKpiTotalNilai2" runat="server" MaxLength="4" Text ="0" style="width: 70px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                            <asp:Label ID="Label7" runat="server" Text=" =  "></asp:Label>
                            <asp:Textbox ID="LblNiaiAkhir2" runat="server" style="width: 70px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" Text=""></asp:Textbox>
                        </td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr id="nilaic" runat="server"> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="Label73" runat="server" Text="Total Nilai C"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtKpiPercenNilai3" runat="server" MaxLength="4" Text ="" style="width: 70px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                            <asp:Label ID="Label95" runat="server" Text=" x  "></asp:Label>
                            <asp:TextBox ID="TxtKpiTotalNilai3" runat="server" MaxLength="4" Text ="0" style="width: 70px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                            <asp:Label ID="Label10" runat="server" Text=" =  "></asp:Label>
                            <asp:TextBox ID="LblNiaiAkhir3" runat="server" Text="" style="width: 70px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox>
                        </td>
                        <td class="col-md-2"></td>
                    </tr>
                    <tr id="total" runat="server"> 
                        <td class="col-md-2"></td>
                        <td class="col-md-2"><asp:Label ID="LblTotal" runat="server" Text=""></asp:Label></td>
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
                    <asp:Button ID="BtnKpi44Setuju1" runat="server" Text="Setuju Staff" class="btn btn-success" />
                    <asp:Button ID="BtnKpi44Setuju2" runat="server" Text="Setuju Head" class="btn btn-success" />
                    <asp:Button ID="BtnKpi44Setuju3" runat="server" Text="Setuju HRD" class="btn btn-success" />
                </center>
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