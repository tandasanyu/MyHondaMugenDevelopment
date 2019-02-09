<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HRDPENILAIANATASANSPV.aspx.vb" Inherits="HRDPENILAIANATASANSPV" title="Penilaian Atasan SPV" %>
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
    <asp:Label ID="TxtAB1" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtAB2" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtAB3" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtAB4" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtAB5" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtAB6" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtHead" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtHead2" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtNama" style="display:none;  text-transform: capitalize;" runat="server"></asp:Label>
    <div class="container">
        <ul class="breadcrumb">
            <li><a href="#"><span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"><i class="glyphicon glyphicon-user"></i></a> &nbsp <a href="#"> HRD</a> </li>
            <li class="active"><span class="glyphicon glyphicon-edit"></span> &nbsp Penilaian Karyawan </li>
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
                        <h2 style="font-family:Cooper Black;">Peilaian Karyawan terhadap Atasan<br /> (KPI)</h2>
                    </center>
                </div><br />
				<h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Data Diri</h3>
				<br />
			    <table class="table table-borderless" align="left">
				    <tr>
				        <td class="col-md-2"><asp:Label ID="Label66" runat="server" Text="NIK"></asp:Label></td>
			            <td class="col-md-4"><asp:Label ID="TxtStaffNIK" runat="server" Text="" class="form-control required"></asp:Label></td>
                        <td class="col-md-2"><asp:Label ID="Label9" runat="server" Text="Lokasi / Department"></asp:Label></td>
				        <td class="col-md-4"><asp:Label ID="TxtStatusKerjaTempat" runat="server" MaxLength="15" Text ="" class="form-control required"></asp:Label></td>
				    </tr>
				    <tr>
                        <td class="col-md-2"><asp:Label ID="Label8" runat="server" Text="Nama"></asp:Label></td>
				        <td class="col-md-4"><asp:Label ID="TxtStaffNama" runat="server" MaxLength="30" Text ="" class="form-control required"></asp:Label></td>
					    <td class="col-md-2"><asp:Label ID="Label29" runat="server" Text="Jabatan"></asp:Label></td>
					    <td class="col-md-4"><asp:Label ID="TxtStatusKerjaJabatan" runat="server" MaxLength="15" Text ="" class="form-control required"></asp:Label></td>
				    </tr>
				    <tr>
                        <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="Atasan"></asp:Label></td>
				        <td class="col-md-4"><asp:Label ID="lblAtasan" runat="server" Text="Dona"></asp:Label></td>
					    <td class="col-md-2"></td>
					    <td class="col-md-4"></td>
				    </tr>
			    </table><br />
                <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-calendar"></span> Tanggal Penting</h3>
                Deadline Pengisian PK :<font color="red"><b> 31 Maret 2018 </b></font> <br />
                Deadline Verifikasi Atasan Langsung :<font color="red"><b> 7 April 2018 </b></font><br />
                Deadline Verifikasi Atasan Dari Atasan Langsung :<font color="red"><b> 14 April 2018 </b></font><br /><br />
            </asp:View>
        </asp:MultiView>

        <asp:MultiView ID="MultiViewNilaiStandard" runat="server" Visible="TRUE">
        </asp:MultiView>                    
        <asp:MultiView ID="MultiViewNilaiStandardEntry" runat="server" Visible="TRUE">
            <asp:View ID="View4" runat="server">    
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Norma Penilaian Kinerja</font></div>
                    <div class="panel-body">
                        <center>
                            <h3 style="font-family:Blunter;">FORM PENILAIAN ATASAN</h3>
                        </center>
	                    <br /><br />
                        <table class="table table-borderless">
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label55" runat="server" Text="001"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label5" runat="server" Text="Mampu mengarahkan & menjadi panutan (Role Model) bagi anggota tim kerjanya untuk melaksanakan pekerjaan & peraturan perusahaan yang berlaku."></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton011" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton012" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton013" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton014" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton015" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton016" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label6" runat="server" Text="002"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label7" runat="server" Text="Mampu bertindak tegas & berani terhadap pelanggaran kerja yg dilakukan oleh anggota tim kerjanya."></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton021" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton022" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton023" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton024" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton025" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton026" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label10" runat="server" Text="003"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label11" runat="server" Text="Mudah dihubungi dan siap sedia saat dibutuhkan oleh anggota tim."></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton031" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton032" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton033" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton034" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton035" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton036" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label12" runat="server" Text="004"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label13" runat="server" Text="Bersikap jujur, adil, menghargai & terbuka terhadap anggota tim kerjanya."></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton041" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton042" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton043" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton044" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton045" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton046" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label14" runat="server" Text="005"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label15" runat="server" Text="Memberikan kesempatan anggota tim kerjanya untuk berkembang dengan memberikan pekerjaan tambahan di luar tanggung jawab hariannya."></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton051" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton052" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton053" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton054" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton055" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton056" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label16" runat="server" Text="006"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label17" runat="server" Text="Memberikan instruksi dan informasi penting untuk keberlangsungan / kesuksesan pelaksanaan pekerjaan tambahan."></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton061" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton062" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton063" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton064" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton065" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton066" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label18" runat="server" Text="007"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label19" runat="server" Text="Memberikan umpan balik terhadap hasil pekerjaan anggota tim kerja."></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton071" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton072" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton073" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton074" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton075" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton076" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label20" runat="server" Text="008"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label3" runat="server" Text="Meluangkan waktu untuk menggali potensi serta mengajari keterampilan2 & ilmu2 baru kepada anggota tim kerja"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton081" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton082" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton083" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton084" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton085" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton086" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label22" runat="server" Text="009"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label4" runat="server" Text="Melakukan briefing harian / mingguan untuk mengkomunikasikan pembagian & pengaturan kerja anggotanya."></asp:Label></td>
                            </tr>
                            <asp:RadioButton ID="RadioButton1" runat="server" />                        
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton091" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton092" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton093" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton094" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton095" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton096" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label24" runat="server" Text="010"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label21" runat="server" Text="Memberi arahan terhadap hambatan teknis pekerjaan anggota tim kerja."></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton101" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton102" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton103" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton104" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton105" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton106" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label26" runat="server" Text="011"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label23" runat="server" Text="Turut serta menyelesaikan hambatan teknis pekerjaan anggota tim kerja."></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton111" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton112" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton113" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton114" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton115" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton116" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label28" runat="server" Text="012"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label25" runat="server" Text="Sangat memahami prosedur & teknis pekerjaannya dan tim kerjanya"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton121" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton122" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton123" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton124" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton125" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton126" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label31" runat="server" Text="013"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label32" runat="server" Text="Mengambil alih pekerjaan tambahan di tengah2 proses karena anggota tim dirasa lamban atau tidak benar melaksanakannya."></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton131" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton132" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton133" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton134" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton135" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton136" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label35" runat="server" Text="014"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label27" runat="server" Text="Mampu menunjukkan rasa empati terhadap permasalahan yang dihadapi oleh anggota tim kerja & bersedia membantu memberikan alternatif solusi jika dibutuhkan."></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton141" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton142" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton143" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton144" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton145" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton146" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label33" runat="server" Text="015"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label30" runat="server" Text="Meluangkan waktu / kesempatan kepada anggota tim kerja untuk mengungkapkan opini, ide2 / usulan, terhadap suatu hal."></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton151" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton152" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton153" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton154" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton155" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton156" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label37" runat="server" Text="016"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label34" runat="server" Text="Mampu mendorong rasa percaya diri anggota tim kerja terhadap kemampuannya serta memotivasi untuk melakukan pekerjaan yang terbaik"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton161" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton162" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton163" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton164" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton165" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton166" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>

                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label36" runat="server" Text="017"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label38" runat="server" Text="Mampu mendeteksi terjadinya konflik & mengklarifikasikan penyebabnya serta mampu menunjukkan rasa empati kepada para pihak yg terlibat di tim kerjanya"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton171" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton172" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton173" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton174" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton175" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton176" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>

                                                        <tr>
                                <td class="col-md-2"><asp:Label ID="Label41" runat="server" Text="018"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label42" runat="server" Text="Menjadi penengah (mendamaikan) atas konflik yang terjadi pada tim kerjanya baik yang disebabkan oleh masalah antar personal maupun pemberlakuan kebijakan perusahaan"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton181" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton182" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton183" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton184" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton185" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton186" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>

                                                        <tr>
                                <td class="col-md-2"><asp:Label ID="Label43" runat="server" Text="019"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label44" runat="server" Text="Memberikan pengarahan kepada tim kerjanya untuk melaksanakan kebijakan perusahaan atau memberikan alternatif solusi terhadap konflik personal dalam timnya"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton191" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton192" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton193" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton194" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton195" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton196" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>

                                                        <tr>
                                <td class="col-md-2"><asp:Label ID="Label45" runat="server" Text="020"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label46" runat="server" Text="Bersikap adil & memberikan teguran yang membangun kepada para pihak yang terlibat dalam konflik"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                                     <asp:RadioButton ID="RadioButton201" Text ="Optimal" runat="server" />
                                                     <asp:RadioButton ID="RadioButton202" Text ="Sangat Mampu (Sangat Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton203" Text ="Mampu (Sering)" runat="server" />
                                                     <asp:RadioButton ID="RadioButton204" Text ="Mampu Terbatas (Jarang)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton205" Text ="Kurang Mampu (Terbatas)" runat="server" />                                  
                                                     <asp:RadioButton ID="RadioButton206" Text ="Tidak Mampu (Tidak Pernah)" runat="server" />                                  
                                </td>
                            </tr>




                            <tr>
                                <td class="col-md-2"><asp:Label ID="Label39" runat="server" Text="021"></asp:Label></td>
                                <td class="col-md-4"><asp:Label ID="Label40" runat="server" Text="Komentar"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-4">
                                    <asp:TextBox ID="TxtKomentar" runat="server" MaxLength="4" Text ="" class="form-control required"></asp:TextBox>
                                </td>
                            </tr>
                        </table> 
                        <center>
                            <asp:Label ID="LblErrorSaveStandard" runat="server" Text="" style="color:red"></asp:Label>
                            <asp:Button ID="BtnStandardSave" runat="server" Text="Simpan" class="btn btn-success" />
                        </center>
                        <br /><br />
                    </div>
                </div>         
            </asp:View> 
        </asp:MultiView>            

       
        <!-- A-Percobaaan -- B-STAFF,C-Leader d:SPV no tim E SPV With TEam -->

         <!-- E SPV With TEam -->

         <!-- B-STAFF,C-Leader -->
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

        <asp:Panel ID="Panel99" runat="server" CssClass="modal-dialog" align="center" style = "display:none">
        <!-- Modal content-->
            <div class="modal-content" style="max-height: 500px; margin-left:-200px; margin-top:-55px; min-width:1000px;overflow: auto;">
                <div class="modal-header">
                    <h4 class="modal-title">Penilaian Hasil Akhir</h4>
                </div>
                <div class="modal-body">
                    <table id="table-a" class="table table-bordered table-striped">
                        <tr style="background-color:#4877CF">
                            <td  style="text-align:center; color:white" colspan="6">Hasil Akhir</td>
                        </tr>
                        <tr style="background-color:#4877CF">
                            <td></td>
                            <td style="text-align:center; color:white">< 70</td>
                            <td style="text-align:center; color:white">70 - 80</td>
                            <td style="text-align:center; color:white">80 - 90</td>
                            <td style="text-align:center; color:white">91 - 95</td>
                            <td style="text-align:center; color:white">> 95</td>
                        </tr>
                        <tr>
                            <td><b>Kategori</b></td>
                            <td style="text-align:center">Kurang</td>
                            <td style="text-align:center">Cukup</td>
                            <td style="text-align:center">Baik</td>
                            <td style="text-align:center">Baik Sekali</td>
                            <td style="text-align:center">Istimewa</td>
                        </tr>
                        <tr>
                            <td><b>Keputusan</b></td>
                            <td style="text-align:center">Peringatan</td>
                            <td colspan="4" style="text-align:center">Tetap Menjadi Karyawan</td>
                        </tr>
                    </table>
                    <button type="button" class="btn btn-danger" ID="btnClose99" data-dismiss="modal">Tutup</button>
                    </div>
                </div>
            </div>
        </asp:Panel>        
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

