<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" ValidateRequest="false" Debug="true" CodeFile="HRDFPTKOUTPUT.aspx.vb" Inherits="HRDFPTKOUTPUT" title="Dokumen System Development/Fault Request" %>
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
    </style>
<script type="text/javascript">
      $( function() {
          $("#<%= form_datetime.ClientID %>").datepicker({
              //changeMonth: true,
              //changeYear: true,
              //dateFormat: "YY-MM-DD",
              //yearRange: "-90:+00"
          });

      } );
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

        <asp:MultiView ID="MultiViewDetailFPTK" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
                <br /><br />
                 <div class="container">
                    <table>
			            <tr>
				            <td align="center"><img src="img/hlogo.png" width="150" height="150" alt="" /></td>
				             <td style="width:400px"></td>
                            <td><b> Honda Mugen </b> <br>
					            PT. Mitrausaha Gentaniaga<br/>
                                Jl. Lingkar Luar Barat Puri Kembangan Jakarta Barat 11610 <br />
                                Telp. : (021) 58359000 Bengkel - (021) 58358000 Showroom<br />
                                Fax &nbsp : (021) 58357942 <br />
                                web &nbsp : http://www.hondamugen.co.id
                               </td>
			            </tr>
		            </table><br/>
                     <center><h3>FORMULIR PERMINTAAN TENAGA KERJA</h3>
                        <h5>001-FRM-HRD&GA R.1</h5></center>
              <br />
                     <u><h4>1. Detail Permohonan</h4></u>
                    <table>
                        <tr style="height:25px">
                            <td>No. PTK</td>
                            <td>&nbsp : &nbsp </td>
                            <td><asp:Label ID="ptk_id" runat="server" Text="Label"></asp:Label></td>
                            <td style="width:250px"></td>
                            <td>Tgl. Permintaan</td>
                            <td>&nbsp : &nbsp </td>
                            <td><asp:Label ID="ptk_tglmohon" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr style="height:25px">
                            <td>Jabatan yg dibutuhkan</td>
                            <td>&nbsp : &nbsp </td>
                            <td><asp:Label ID="ptk_jabatan" runat="server" Text="Label"></asp:Label></td>
                            <td style="width:100px"></td>
                            <td>Tgl. Dibutuhkan</td>
                            <td>&nbsp : &nbsp </td>
                            <td><asp:Label ID="ptk_tglbutuh" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr style="height:25px">
                            <td>Dept/Cabang</td>
                            <td>&nbsp : &nbsp </td>
                            <td><asp:Label ID="ptk_dept" runat="server" Text="Label"></asp:Label> / <asp:Label ID="ptk_cabang" runat="server" Text="Label"></asp:Label></td>
                            <td style="width:100px"></td>
                            <td>Jumlah yg dibutuhkan</td>
                            <td>&nbsp : &nbsp </td>
                            <td><asp:Label ID="ptk_jumlah" runat="server" Text="Label"></asp:Label> Orang</td>
                        </tr>
                    </table>

                    Status Karyawan &nbsp &nbsp &nbsp &nbsp &nbsp : <asp:CheckBox style="margin-left:5px;" ID="ptk_statuskaryawan1" runat="server" /> Tetap <asp:CheckBox style="margin-left:80px;" ID="ptk_statuskaryawan2" runat="server" /> Kontrak <br />
                    Alasan Permintaan &nbsp &nbsp &nbsp &nbsp: <asp:CheckBox style="margin-left:5px;" ID="ptk_alasan1" runat="server" /> Replacement <asp:CheckBox style="margin-left:30px;" ID="ptk_alasan2" runat="server" /> Penambahan sesuai MPP <asp:CheckBox style="margin-left:30px;" ID="ptk_alasan3" runat="server" /> Penambahan diluar MPP <br style="margin-top:25px"/>
                    Penjelasan &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp : <asp:Label ID="ptk_alasandetail" runat="server" Text="Label"></asp:Label> <br />
                    <br />
                    
                     <u><h4>2. Kualifikasi Jabatan</h4></u> 
                     <table>
                        <tr style="height:25px">
                            <td>Jenis Kelamin</td> 
                            <td>&nbsp : &nbsp</td>
                            <td><asp:Label ID="ptk_jkel" runat="server" Text=""></asp:Label></td>
                            <td style="width:300px"></td>
                            <td>Umur</td>
                            <td>&nbsp : &nbsp</td>
                            <td><asp:Label ID="ptk_umur" runat="server" Text=""></asp:Label> tahun</td>
                        </tr>
                        <tr>
                            <td>Pendidikan Terakhir &nbsp &nbsp </td> 
                            <td>&nbsp : &nbsp</td>
                            <td><asp:Label ID="ptk_pendidikan" runat="server" Text=""></asp:Label></td>
                            <td style="width:300px"></td>
                            <td>Fakultas/Jurusan &nbsp &nbsp &nbsp &nbsp</td> 
                            <td>&nbsp : &nbsp</td> 
                            <td><asp:Label ID="ptk_jurusan" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Indeks Prestasi</td>
                            <td>&nbsp : &nbsp</td> 
                            <td><asp:Label ID="ptk_ipk" runat="server" Text=""></asp:Label></td>
                            <td style="width:300px"></td>
                            <td>Pengalaman Kerja</td>                             
                            <td>&nbsp : &nbsp</td>  
                            <td><asp:Label ID="ptk_pengalaman" runat="server" Text=""></asp:Label> tahun</td>
                        </tr>
                    </table>
                    
                     Level Entry &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp: <asp:CheckBox ID="ptk_level1" style="margin-left:5px;" runat="server" /> Manager <asp:CheckBox ID="ptk_level2" style="margin-left:55px;" runat="server" /> Supervisor <asp:CheckBox ID="ptk_level3" style="margin-left:55px;" runat="server" /> Staff <asp:CheckBox ID="ptk_level4" style="margin-left:55px;" runat="server" /> Operator <br />
                     
                     Syarat/Ketrampilan khusus yang diperlukan : 
                     <asp:Label ID="ptk_ketrampilan" runat="server" Text="Label"></asp:Label> 
                     <br />
                     <u><h4>3. Calon Tenaga Kerja</h4></u>
                     Apakah ada calon yang disarankan? <asp:CheckBox ID="ptk_calon1" style="margin-left:5px;" runat="server" /> Ya <asp:CheckBox style="margin-left:15px;" ID="ptk_calon2" runat="server" /> Tidak <br />
                     Apabila Ya, Jelaskan : <asp:Label ID="ptk_sarancalon" runat="server" Text=""></asp:Label> <br />
                    <br /><br />
                   <table style="width:100%;margin:8px;margin-left:-50px; text-align:center;font-family:Verdana;color:#333;">
                        <tr>
                            <th style="text-align:center;">Diajukan oleh,</th>
                            <th style="text-align:center;">Diketahui oleh,</th>
                            <th style="text-align:center;">Disetujui oleh,</th>
                       </tr>
                       <tr>
                             <td><br /></td>
                             <td><br /></td>
                             <td><br /></td>
                       </tr>
                       <tr>
                             <td></td>
                             <td><asp:Label ID="lblAppDiketahui" visible="false" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);-o-transform: rotate(-20deg);opacity: 0.3; "></asp:Label></td>
                             <td><asp:Label ID="lblAppDisetujui" visible="false" runat="server" Text="APPROVE" style="font-weight:bold;color:#d60000;border:3px double #d60000;padding:4px;transform: rotate(-20deg);-webkit-transform: rotate(-20deg);-ms-transform: rotate(-20deg);-moz-transform: rotate(-20deg);opacity: 0.3;"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><br /></td>
                            <td><br /></td>
                            <td><br /></td>
                        </tr>
                        <tr>
                            <td><u><asp:Label ID="ptk_pemohon" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="ptk_diketahui" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                            <td><u><asp:Label ID="ptk_disetujui" runat="server" Text="" style="font-size:10pt;"></asp:Label></u></td>
                        </tr>
                        <tr>
                            <td style="font-size:9pt;color:Blue;">Dept. Head/Div. Head</td>
                            <td style="font-size:9pt;color:Blue;">HRD & GA Dept. Head</td>
                            <td style="font-size:9pt;color:Blue;">Direksi</td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lbl_tglmohon" runat="server" Text="" style="font-size:8pt;margin:0;color:#666"></asp:Label></td>
                            <td><asp:Label ID="lbl_tgldiketahui" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                            <td><asp:Label ID="lbl_tgldisetujui" runat="server" Text="" style="font-size:8pt;margin:0;color:#666;"></asp:Label></td>
                        </tr>
                    </table><br /><br />

                     Data Karyawan sesuai jabatan yang diminta
                     <table border="1">
                         <tr>
                             <td width="200px"> &nbsp MPP</td>
                             <td width="200px"> &nbsp <asp:Label ID="lblmpp" runat="server" Text="-"></asp:Label></td>
                         </tr>
                         <tr>
                             <td> &nbsp Aktual sampai saat ini</td>
                             <td> &nbsp <asp:Label ID="lblaktual" runat="server" Text="-"></asp:Label></td>
                         </tr>
                         <tr>
                             <td> &nbsp Kurang/Tambah</td>
                             <td> &nbsp <asp:Label ID="lblkurang" runat="server" Text="-"></asp:Label></td>
                         </tr>
                     </table>
                     <br /><br />
                    <center><asp:Button ID="BtnNilaiSMSave" runat="server" Text="Approve Permintaan" visible="false" class="btn btn-success" /></center>
                     <center><asp:Button ID="BtnNilaiSMSave2" runat="server" Text="Approve Permintaan" visible="false" class="btn btn-success" /></center>  
                </div>
            </asp:View>
        </asp:MultiView>

        <!-- Data MPP -->

        <asp:MultiView ID="MultiViewMPP" runat="server" Visible="TRUE">
            <asp:View ID="View8" runat="server">
                <br /><br />
                 <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Data MPP</font></div>
                        <div class="panel-body">
                            <center>
                                <h3 style="font-family:Georgia;">FORM DATA MPP</h3>
                            </center>
	                        <br /><br />
                            <table class="table table-borderless">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label19" runat="server" Text="MPP"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtMPP" runat="server" MaxLength="200" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Aktual sampai saat ini"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtAktual" runat="server" MaxLength="200" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="Kurang/Tambah"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtKurang" runat="server" MaxLength="200" class="form-control" Text =""></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>
                            
                            <center>
                                <asp:Label ID="Label21" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:Button ID="BtnNilaiSMSave3" runat="server" Text="Simpan" class="btn btn-success" />  
                            </center>
                        </div>
                    </div>
                   <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Data MPP</font></div>
                        <div class="panel-body">
                            <center>
                                <h3 style="font-family:Georgia;">Update Tanggal di Butuhkan</h3>
                            </center>
                            <center>
                                No PTK : <asp:Label ID="LblNoPTK" runat="server" Text="Label"></asp:Label>
                            </center>
                            <center>
                                <asp:TextBox ID="form_datetime" class="form-control" runat="server" Width="500px"></asp:TextBox><br />
                            </center>
                            <center>
                                <asp:Button ID="BtnUpdateTgldibutuhkan" runat="server" Text="Simpan" class="btn btn-success" /> 
                            </center>
                        </div>
                   </div>
                </div>
                <br />
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>

