<%@ Page Language="VB" AutoEventWireup="false"  CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <style type="text/css">
        .table-borderless > tbody > tr > td,
        .table-borderless > tbody > tr > th,
        .table-borderless > tfoot > tr > td,
        .table-borderless > tfoot > tr > th,
        .table-borderless > thead > tr > td,
        .table-borderless > thead > tr > th {
            border: none;
        }
    </style>    
    

    <asp:Label ID="LblUserName" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblAkses" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea1" Style="display:none" runat="server"></asp:Label>
    <asp:Label ID="lblArea2" Style="display:none" runat="server"></asp:Label>
    <div class="container">
                <br /><br />
                 <div class="container">
                    <center>
                        <h3>PT. MITRAUSAHA GENTANIAGA<br />
                            PENILAIAN KINERJA KARYAWAN <asp:Label ID="TxtKpiSummaryTahun" runat="server" MaxLength="15" Text ="2017" class="form-control required"></asp:Label><br />
                            (SDR/SFR)
                        </h3>
                        <h5>049-FRM-HRD&GA R.0</h5>
                    </center>
	                <br />
                   
                    <table align="left">
				        <tr style="height:30px">
                            <td><asp:Label ID="Label8" runat="server" Text="Nama"></asp:Label></td>
                            <td style="width:10px">:</td>
				            <td><asp:Label ID="TxtStaffNama" runat="server" MaxLength="30" Text ="Komang Anom Budi Utama" class="form-control required"></asp:Label></td>
                            <td style="width:125px"></td>
                            <td><asp:Label ID="Label29" runat="server" Text="Jabatan / Sub Jabatan"></asp:Label></td>
					        <td style="width:10px">:</td>
                            <td><asp:Label ID="TxtStatusKerjaJabatan" runat="server" MaxLength="15" Text ="Programmer / A" class="form-control required"></asp:Label></td>
				        </tr>
				        <tr style="height:30px">
                            <td><asp:Label ID="Label66" runat="server" Text="NIK"></asp:Label></td>
			                <td style="width:10px">:</td>
                            <td><asp:Label ID="TxtStaffNIK" runat="server" Text="355" class="form-control required"></asp:Label></td>
					        <td style="width:125px"></td>
                            <td><asp:Label ID="Label9" runat="server" Text="Department"></asp:Label></td>
				            <td style="width:10px">:</td>
                            <td><asp:Label ID="TxtStatusKerjaDept" runat="server" MaxLength="15" Text ="Purchasing" class="form-control required"></asp:Label></td>
				        </tr>
                        <tr style="height:30px">
                            <td><asp:Label ID="Label1" runat="server" Text="Lokasi"></asp:Label></td>
				            <td style="width:10px">:</td>
                            <td><asp:Label ID="TxtStatusKerjaTempat" runat="server" MaxLength="15" Text ="" class="form-control required"></asp:Label></td>
                            <td style="width:125px"></td>
                            <td><asp:Label ID="Label26" runat="server" Text="Tanggal Masuk"></asp:Label></td>
				            <td style="width:10px">:</td>
                            <td><asp:Label ID="TxtTglMasuk" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:Label></td>
				        </tr> 
			        </table><br /><br /><br /><br /><br /><br />

                    <b>A. Professional Skill</b><br />
                    
                      <asp:SqlDataSource ID="SqlDataKpiMaster" runat="server"
                        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                        SelectCommand="SELECT TRXN_KPID.KPID_NIK, TRXN_KPID.KPID_BOBOT, TRXN_KPID.KPID_NILAISTAFF, Round(((DATA_KPIT.KPIT_BOBOT * TRXN_KPID.KPID_NILAISTAFF ) / 100),2) as NILAIAKHIR, DATA_KPIT.KPIT_ITEM, DATA_KPIT.KPIT_BOBOT, DATA_KPIT.KPIT_TIPE,  DATA_KPIT.KPIT_TARGET, TRXN_KPID.KPID_PRESTASI, TRXN_KPID.KPID_TYPEA, TRXN_KPID.KPID_BULAN01,  TRXN_KPID.KPID_BULAN02, TRXN_KPID.KPID_BULAN03, TRXN_KPID.KPID_BULAN04, TRXN_KPID.KPID_BULAN05, TRXN_KPID.KPID_BULAN07, TRXN_KPID.KPID_BULAN06, TRXN_KPID.KPID_BULAN08, TRXN_KPID.KPID_BULAN09, TRXN_KPID.KPID_BULAN10, TRXN_KPID.KPID_BULAN11, TRXN_KPID.KPID_BULAN12 FROM TRXN_KPID, DATA_KPIT WHERE (TRXN_KPID.KPID_NIK = ?) AND (TRXN_KPID.KPID_TAHUN = ?) AND TRXN_KPID.KPID_ITEM = DATA_KPIT.KPIT_TIPE"
                        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TxtStaffNIK" Name="KPID_NIK" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="TxtKpiSummaryTahun" Name="KPID_TAHUN" PropertyName="Text" Type="String" />
                        </SelectParameters>
                       
                    </asp:SqlDataSource>                                     
                    <asp:ListView ID="LvKPIMasterDetail" runat="server" DataSourceID="SqlDataKpiMaster" DataKeyNames ="KPIT_TIPE">
                    <LayoutTemplate>
                        <table id="table-a" border="2" align="left">
                            <tr style="background-color:#4877CF">
                                <th rowspan="2" style="text-align:center; color:white">No.</th>
                                <th rowspan="2" style="text-align:center; color:white">Item KPI</th>
                                <th rowspan="2" style="text-align:center; color:white">Bobot (B)</th>
                                <th rowspan="2" style="text-align:center; color:white">Target (T)</th>
                                <th colspan="12" style="text-align:center; color:white">Bulan</th>
                           
                                <th rowspan="2" style="text-align:center; color:white">Prestasi(P)</th>
                                <th rowspan="2" class="col-md-1" style="text-align:center; color:white">Nilai <br /> (B x P)</th>
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
                        <td style="width:50px" align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                        <td style="width:500px"><p class="small"><%# Eval("KPIT_ITEM") %></p></td>
                        <td style="text-align:center"><p class="small"><%#Eval("KPIT_BOBOT")%>%</p></td>
                        <td><p class="small"><%#Eval("KPIT_TARGET")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("KPID_BULAN01")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("KPID_BULAN02")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("KPID_BULAN03")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("KPID_BULAN04")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("KPID_BULAN05")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("KPID_BULAN06")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("KPID_BULAN07")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("KPID_BULAN08")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("KPID_BULAN09")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("KPID_BULAN10")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("KPID_BULAN11")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("KPID_BULAN12")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("KPID_NILAISTAFF")%></p></td>
                        <td style="text-align:center; width:50px"><p class="small"><%#Eval("NILAIAKHIR")%></p></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView><br />
                   <p style="text-align:right">Total Nilai Performance Indicator: <b><font size="5"><asp:Label ID="nilaiPerforma" runat="server" Text="0"></asp:Label></font></b></p>
                     
                     
                     
                     <asp:Label ID="tujuan" runat="server"></asp:Label>
                    
                            <br /><br />
                          
                            <br /><br />
                            <b>Format Program yang Diinginkan (Gambarkan dengan detail)</b><br />
                            <asp:Label ID="detail" runat="server"></asp:Label><br />
							<font color="red"><asp:Label ID="lampiran" runat="server"></asp:Label></font>
                         
                     
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
                    </table><br />
                    <center><asp:Button ID="BtnNilaiSMSave" runat="server" Text="Approve SDR" visible="false" class="btn btn-success" /></center>  
                </div>


    </div>


    </form>
</body>
</html>
