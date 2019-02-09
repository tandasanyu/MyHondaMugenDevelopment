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

        span.radio {
            padding: 0px;
        }

        span.radio > input[type="radio"] {
            margin: 5px 5px 7px 0px;
        }

        span.radio > label {
            float: left;
            margin-right: 10px;
            padding: 0px 15px 0px 20px;
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
				        <td class="col-md-4"><asp:Label ID="lblAtasan" runat="server" Text=""  MaxLength="30" class="form-control required"></asp:Label></td>
					    <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Tahun Penilaian"></asp:Label></td>
					    <td class="col-md-4"><asp:Label ID="TahunPenilaian" runat="server" MaxLength="15" Text ="" class="form-control required"></asp:Label></td>
				    </tr>
			    </table><br />
                <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-calendar"></span> Tanggal Penting</h3>
                Deadline Pengisian PK :<font color="red"><b> 31 Maret 2018 </b></font> <br />
                Deadline Verifikasi Atasan Langsung :<font color="red"><b> 7 April 2018 </b></font><br />
                Deadline Verifikasi Atasan Dari Atasan Langsung :<font color="red"><b> 14 April 2018 </b></font><br /><br />
            </asp:View>
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
                        <h4>Keterangan Skala Penilaian</h4>
                       <table class="table table-bordered striped">
                            <tr style="background-color:#4877CF"> 
                                <th style="text-align:center; color:white" width ="10%">10</th>
                                <th style="text-align:center; color:white" width ="10%">9</th>
                                <th style="text-align:center; color:white" width ="10%">8</th>
                                <th style="text-align:center; color:white" width ="10%">7</th>
                                <th style="text-align:center; color:white" width ="10%">6</th>
                                <th style="text-align:center; color:white" width ="10%">5</th>
                            </tr>
                            <tr>
                                <td style="text-align:center"><p class="small">Optimal</p></td>
                                <td><p class="small">Sangat Mampu (Sangat Sering)</p></td>
                                <td style="text-align:center"><p class="small">Mampu (Sering)</p></td>
                                <td style="text-align:center"><p class="small">Mampu Terbatas (Jarang)</p></td>
                                <td style="text-align:center"><p class="small">Kurang Mampu (Terbatas)</p></td>
                                <td style="text-align:center"><p class="small">Tidak Mampu (Tidak Pernah)</p></td>
                            </tr>
                        </table>
                        <br /><br />
                        <b><asp:Label ID="Label55" runat="server" Text="001 Mampu mengarahkan & menjadi panutan (Role Model) bagi anggota tim kerjanya untuk melaksanakan pekerjaan & peraturan perusahaan yang berlaku."></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton01" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label6" runat="server" Text="002 Mampu bertindak tegas & berani terhadap pelanggaran kerja yg dilakukan oleh anggota tim kerjanya."></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton02" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label10" runat="server" Text="003 Mudah dihubungi dan siap sedia saat dibutuhkan oleh anggota tim."></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton03" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label12" runat="server" Text="004 Bersikap jujur, adil, menghargai & terbuka terhadap anggota tim kerjanya."></asp:Label></b>
                         <asp:RadioButtonList ID="RadioButton04" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label14" runat="server" Text="005 Memberikan kesempatan anggota tim kerjanya untuk berkembang dengan memberikan pekerjaan tambahan di luar tanggung jawab hariannya."></asp:Label></b>
                         <asp:RadioButtonList ID="RadioButton05" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label16" runat="server" Text="006 Memberikan instruksi dan informasi penting untuk keberlangsungan / kesuksesan pelaksanaan pekerjaan tambahan."></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton06" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label18" runat="server" Text="007 Memberikan umpan balik terhadap hasil pekerjaan anggota tim kerja."></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton07" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label20" runat="server" Text="008 Meluangkan waktu untuk menggali potensi serta mengajari keterampilan2 & ilmu2 baru kepada anggota tim kerja"></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton08" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label22" runat="server" Text="009 Melakukan briefing harian / mingguan untuk mengkomunikasikan pembagian & pengaturan kerja anggotanya."></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton09" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label24" runat="server" Text="010 Memberi arahan terhadap hambatan teknis pekerjaan anggota tim kerja."></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton10" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label26" runat="server" Text="011 Turut serta menyelesaikan hambatan teknis pekerjaan anggota tim kerja."></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton11" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label28" runat="server" Text="012 Sangat memahami prosedur & teknis pekerjaannya dan tim kerjanya"></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton12" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label31" runat="server" Text="013 Mengambil alih pekerjaan tambahan di tengah2 proses karena anggota tim dirasa lamban atau tidak benar melaksanakannya."></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton13" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label35" runat="server" Text="014 Mampu menunjukkan rasa empati terhadap permasalahan yang dihadapi oleh anggota tim kerja & bersedia membantu memberikan alternatif solusi jika dibutuhkan."></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton14" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label33" runat="server" Text="015 Meluangkan waktu / kesempatan kepada anggota tim kerja untuk mengungkapkan opini, ide2 / usulan, terhadap suatu hal."></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton15" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />
     
                        <b><asp:Label ID="Label37" runat="server" Text="016 Mampu mendorong rasa percaya diri anggota tim kerja terhadap kemampuannya serta memotivasi untuk melakukan pekerjaan yang terbaik"></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton16" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label36" runat="server" Text="017 Mampu mendeteksi terjadinya konflik & mengklarifikasikan penyebabnya serta mampu menunjukkan rasa empati kepada para pihak yg terlibat di tim kerjanya"></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton17" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />
                        
                        <b><asp:Label ID="Label41" runat="server" Text="018 Menjadi penengah (mendamaikan) atas konflik yang terjadi pada tim kerjanya baik yang disebabkan oleh masalah antar personal maupun pemberlakuan kebijakan perusahaan"></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton18" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />
                        
                        <b><asp:Label ID="Label43" runat="server" Text="019 Memberikan pengarahan kepada tim kerjanya untuk melaksanakan kebijakan perusahaan atau memberikan alternatif solusi terhadap konflik personal dalam timnya"></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton19" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />
                        
                        <b><asp:Label ID="Label45" runat="server" Text="020 Bersikap adil & memberikan teguran yang membangun kepada para pihak yang terlibat dalam konflik"></asp:Label></b>
                        <asp:RadioButtonList ID="RadioButton20" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem>10</asp:ListItem>
						    <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label39" runat="server" Text="021 Komentar"></asp:Label></b><br />
                        <asp:TextBox ID="TxtKomentar" runat="server" MaxLength="200" Text ="" class="form-control required"></asp:TextBox><br /><br />

                        <center>
                            <asp:Label ID="LabelError" runat="server" Text="" style="color:red"></asp:Label>
                            <asp:Button ID="BtnStandardSave" runat="server" Text="Simpan" class="btn btn-success" />
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

