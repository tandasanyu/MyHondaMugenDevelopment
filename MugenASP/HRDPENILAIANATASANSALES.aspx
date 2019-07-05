<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HRDPENILAIANATASANSALES.aspx.vb" Inherits="HRDPENILAIANATASANSALES" title="Penilaian Atasan Sales" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

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
    <asp:Label ID="nama" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="jabatan" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="grup" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="subjabatan" style="display:none;" runat="server"></asp:Label>
    <div class="container">
		<asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
			<asp:View ID="Viewerr00" runat="server">
				<asp:Label ID="lblMsgBox" runat="server">Judul Permohonan</asp:Label>
			</asp:View> 
		</asp:MultiView>
        
        <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
			<asp:View ID="View0102Karyawan" runat="server">
                <div class="container">
                    <center>
                        <Font size="6" style="font-family:Cooper Black;">Penilaian Sales terhadap SPV<br /> (KPI)</Font>
                    </center>
                </div><br /><br /><br />
				<div style="margin-left:30px">
				<br />
				<font size="2">
			    <table class="table table-borderless" align="left" height="100px" width="600px">
				    <tr>
				        <td><asp:Label ID="Label66" runat="server" Text="Kode Sales"></asp:Label></td>
			            <td><asp:Label ID="TxtStaffNIK" runat="server" Text="" style="width: 150px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:Label></td>
                        <td><asp:Label ID="Label9" runat="server" Text="Tahun Penilaian"></asp:Label></td>
				        <td ><asp:Label ID="TahunPenilaian" runat="server" MaxLength="15" Text ="" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:Label></td>
				    </tr>
				    <tr>
                        <td ><asp:Label ID="Label8" runat="server" Text="Atasan"></asp:Label></td>
				        <td ><asp:DropDownList ID="lblAtasan" runat="server" style="width: 130px; height: 45px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" > 
                                <asp:ListItem>- Pilih Nama Atasan -</asp:ListItem>
                                <asp:ListItem>AKHMAD FAIZ</asp:ListItem>
                                <asp:ListItem>HELMI MUHAMAD</asp:ListItem>    
                                <asp:ListItem>MICHAEL</asp:ListItem>                           
				                <asp:ListItem>MOHAMAD IVAN ARIEFIANSYAH</asp:ListItem>
				                <asp:ListItem>RONI PATINASARONI</asp:ListItem>
			                    <asp:ListItem>SYAHRUL FAUJI</asp:ListItem>                                
                                <asp:ListItem>BAYU KURNIAWAN</asp:ListItem>
                                <asp:ListItem>DHARMAWAN JULIUS</asp:ListItem>
                                <asp:ListItem>MEGAH SURYA MURTABA</asp:ListItem>
                                <asp:ListItem>NAHRAWI SUGAMA</asp:ListItem> 
                                <asp:ListItem>RUDI FERDIANSYAH</asp:ListItem>                             
                            </asp:DropDownList>
                    </td>
				    </tr>
				  
			    </table>
				</div>
				</font><br />
                <br /><br /><br /><br /><br /><br /><br /><br />
            </asp:View>
        </asp:MultiView>
              
        <asp:MultiView ID="MultiViewNilaiStandardEntry" runat="server" Visible="TRUE">
            <asp:View ID="View4" runat="server">    

	                     <br /><br />
                        <b><Font size="4">Keterangan Skala Penilaian</Font></b>
						<font size="2">
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
                                <td style="text-align:center">Optimal</td>
                                <td style="text-align:center">Sangat Mampu (Sangat Sering)</td>
                                <td style="text-align:center">Mampu (Sering)</td>
                                <td style="text-align:center">Mampu Terbatas (Jarang)</td>
                                <td style="text-align:center">Kurang Mampu (Terbatas)</td>
                                <td style="text-align:center">Tidak Mampu (Tidak Pernah)</td>
                            </tr>
						</font>
                        </table>
                        <br /><br />
						<font size="2">
						<div style="margin-left:30px">
                        <b><asp:Label ID="Label55" runat="server" Text="001 Mampu mengarahkan & menjadi panutan (Role Model) bagi anggota tim kerjanya untuk melaksanakan pekerjaan & peraturan perusahaan yang berlaku."></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton01" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label6" runat="server" Text="002 Mampu bertindak tegas & berani terhadap pelanggaran kerja yg dilakukan oleh anggota tim kerjanya."></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton02" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label10" runat="server" Text="003 Mudah dihubungi dan siap sedia saat dibutuhkan oleh anggota tim."></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton03" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label12" runat="server" Text="004 Bersikap jujur, adil, menghargai & terbuka terhadap anggota tim kerjanya."></asp:Label></b><br><br>
                         <asp:RadioButtonList ID="RadioButton04" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label14" runat="server" Text="005 Memberikan kesempatan anggota tim kerjanya untuk berkembang dengan memberikan pekerjaan tambahan di luar tanggung jawab hariannya."></asp:Label></b><br><br>
                         <asp:RadioButtonList ID="RadioButton05" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label16" runat="server" Text="006 Memberikan instruksi dan informasi penting untuk keberlangsungan / kesuksesan pelaksanaan pekerjaan tambahan."></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton06" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label18" runat="server" Text="007 Memberikan umpan balik terhadap hasil pekerjaan anggota tim kerja."></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton07" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label20" runat="server" Text="008 Meluangkan waktu untuk menggali potensi serta mengajari keterampilan2 & ilmu2 baru kepada anggota tim kerja"></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton08" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label22" runat="server" Text="009 Melakukan briefing harian / mingguan untuk mengkomunikasikan pembagian & pengaturan kerja anggotanya."></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton09" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label24" runat="server" Text="010 Memberi arahan terhadap hambatan teknis pekerjaan anggota tim kerja."></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton10" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label26" runat="server" Text="011 Turut serta menyelesaikan hambatan teknis pekerjaan anggota tim kerja."></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton11" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label28" runat="server" Text="012 Sangat memahami prosedur & teknis pekerjaannya dan tim kerjanya"></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton12" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label31" runat="server" Text="013 Mengambil alih pekerjaan tambahan di tengah2 proses karena anggota tim dirasa lamban atau tidak benar melaksanakannya."></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton13" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label35" runat="server" Text="014 Mampu menunjukkan rasa empati terhadap permasalahan yang dihadapi oleh anggota tim kerja & bersedia membantu memberikan alternatif solusi jika dibutuhkan."></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton14" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label33" runat="server" Text="015 Meluangkan waktu / kesempatan kepada anggota tim kerja untuk mengungkapkan opini, ide2 / usulan, terhadap suatu hal."></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton15" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />
     
                        <b><asp:Label ID="Label37" runat="server" Text="016 Mampu mendorong rasa percaya diri anggota tim kerja terhadap kemampuannya serta memotivasi untuk melakukan pekerjaan yang terbaik"></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton16" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label36" runat="server" Text="017 Mampu mendeteksi terjadinya konflik & mengklarifikasikan penyebabnya serta mampu menunjukkan rasa empati kepada para pihak yg terlibat di tim kerjanya"></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton17" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />
                        
                        <b><asp:Label ID="Label41" runat="server" Text="018 Menjadi penengah (mendamaikan) atas konflik yang terjadi pada tim kerjanya baik yang disebabkan oleh masalah antar personal maupun pemberlakuan kebijakan perusahaan"></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton18" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />
                        
                        <b><asp:Label ID="Label43" runat="server" Text="019 Memberikan pengarahan kepada tim kerjanya untuk melaksanakan kebijakan perusahaan atau memberikan alternatif solusi terhadap konflik personal dalam timnya"></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton19" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />
                        
                        <b><asp:Label ID="Label45" runat="server" Text="020 Bersikap adil & memberikan teguran yang membangun kepada para pihak yang terlibat dalam konflik"></asp:Label></b><br><br>
                        <asp:RadioButtonList ID="RadioButton20" style="margin-left:30px" runat="server" CssClass="radio" RepeatLayout="Flow" RepeatDirection="Horizontal">
						    <asp:ListItem style="margin-left:30px">10</asp:ListItem>
						    <asp:ListItem style="margin-left:30px">9</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">8</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">7</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">6</asp:ListItem>
                            <asp:ListItem style="margin-left:30px">5</asp:ListItem>
				        </asp:RadioButtonList><br /><br /><br />

                        <b><asp:Label ID="Label39" runat="server" Text="021 Komentar"></asp:Label></b><br /><br><br>
                        <asp:TextBox ID="TxtKomentar" runat="server" TextMode ="MultiLine" row="3" MaxLength="200" Text ="" style="width: 100%; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"></asp:TextBox><br /><br />
						</div>
						</font>
                        <center>
                            <asp:Label ID="LabelError" runat="server" Text="" style="color:red"></asp:Label><br>
                            <asp:Button ID="BtnStandardSave" runat="server" Text="Simpan" class="button button4" />
                        </center>
                        <br /><br />      
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

