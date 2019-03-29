<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPelamar.aspx.cs" Inherits="PagesHRD_FormPelamar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form Pelamar</title>
            <!-- Bootstrap -->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .TableDataDiri {
        border-collapse: separate;
        border-left: 0;
        border-radius: 4px;
        border-spacing: 0px;
        background-color:#f1f1f1;
        table-layout:fixed;
        }
.box {
    background-color: none;
    width: 30%;
    display:inline-block;
    margin:1px 0;
    border-radius:1px;
}
/*.text {
    padding: 10px 0;
    color:white;
    font-weight:bold;
    text-align:center;
}*/
.xx {
    background-color: none;
    white-space:nowrap;
    text-align:center;
}
.b {
    background-color: none;
    width: 30%;
    display:inline-block;
    margin:1px 0;
    border-radius:1px;
}
.t {
    
    color:black;
    
    text-align:right;
}
.c {
    white-space:nowrap;
    text-align:center;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <asp:Label ID="LblIdLamaran" runat="server" Text="Label" Visible="false"></asp:Label>
        <div id="Header" class="form-group" style="margin-top:5%; margin-bottom:6%" >
            <div class="xx">
                <div class="box" style="padding-right:150px">
                    <asp:Image ID="ImageIcon" runat="server" src="../img/cropped-honda-icon - Copy.png" Height="200px" Width="200px" />
                </div>
                <div class="box">
                    <h3><asp:Label ID="JudulForm" runat="server" Text="PT. MITRAUSAHA GENTANIAGA</br>(HONDA MUGEN)" Font-Size="large"></asp:Label></h3>
                </div>
                <div class="box" style="padding-left:100px">
                    <asp:Image ID="ImagePelamar" runat="server"  Height="200px" Width="180px" />
                </div>
            </div>
        </div>
        <div id="DataPribadi" class="form-group">
            <h4><asp:Label ID="LblDataPribadi" runat="server" Text="Data Pribadi"></asp:Label></h4>
            <asp:SqlDataSource ID="SqlDataSourceDataPribadi" runat="server"
				ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
				SelectCommand="SELECT Id_DataDiri, Id_Lamaran, Nama_Lengkap, Nama_Panggilan, Tempat_Lahir, Tgl_Lahir, JenKel, Agama, Alamat_KTP, Alamat_Tinggal, No_Telp, No_HP, Email, Hobi, No_KTP, No_NPWP, No_Jamsos, Jen_SIM, No_SIM, NoRekBCA FROM Data_Diri WHERE (Id_Lamaran = @Param1)">
				<SelectParameters>
                    <asp:ControlParameter ControlID="LblIdLamaran" Name="Param1" PropertyName="Text" />
                </SelectParameters>
			</asp:SqlDataSource>   
            <asp:ListView ID="ListViewDataDiri" DataSourceID="SqlDataSourceDataPribadi" runat="server" DataKeyNames="Id_DataDiri">
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <span>Data Tidak Di Temukan</span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <table class="TableDataDiri">
                        <tr>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Nama : </div>
                                    <div class=""><asp:Label ID="DPNama" runat="server" Text='<%# Eval("Nama_Lengkap") !=null ? Eval("Nama_Lengkap"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                                 <div class="col">
                                    <div class="" style="font-weight:bold">Nama Panggilan : </div>
                                    <div class=""><asp:Label ID="DPPanggilan" runat="server" Text='<%# Eval("Nama_Panggilan") %>'></asp:Label></div>
                                </div>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Tempat / Tanggal Lahir : </div>
                                    <div class=""><asp:Label ID="DPTglLahir" runat="server" Text='<%# String.Format("{0} - {1}", Eval("Tempat_Lahir"), (Eval("Tgl_Lahir") != null ? Eval("Tgl_Lahir","{0:dd/MM/yyyy}") : "Not Available")) %>'></asp:Label></div>
                                </div>
                                 <div class="col">
                                    <div class="" style="font-weight:bold">Jenis Kelamin : </div>
                                    <div class=""><asp:Label ID="DPJenkel" runat="server" Text='<%# (int)Eval("JenKel") ==1 ? "Pria" :"Wanita"%>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">No HP : </div>
                                    <div class=""><asp:Label ID="No_HPLabel" runat="server" Text='<%# Eval("No_HP") !=null ? Eval("No_HP"): "Data Tidak Ada" %>'  /></div>
                                </div>
                                 <div class="col">
                                    <div class="" style="font-weight:bold">Email : </div>
                                    <div class=""><asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") !=null ? Eval("Email"): "Data Tidak Ada"  %>' /></div>
                                </div>
                                 <div class="col">
                                    <div class="" style="font-weight:bold">Hobi : </div>
                                    <div class=""><asp:Label ID="HobiLabel" runat="server" Text='<%# Eval("Hobi") !=null ? Eval("Hobi"): "Data Tidak Ada" %>' /></div>
                                </div>
                                <div class="col">
                                    <div class="" style="font-weight:bold">No KTP : </div>
                                    <div class=""><asp:Label ID="No_KTPLabel" runat="server" Text='<%# Eval("No_KTP") !=null ? Eval("No_KTP"): "Data Tidak Ada" %>' /></div>
                                </div>
                            </td>
                            <td>
                                 <div class="col">
                                    <div class="" style="font-weight:bold">No NPWP : </div>
                                    <div class=""><asp:Label ID="No_NPWPLabel" runat="server" Text='<%#  (string)Eval("No_NPWP") =="0" ? "Tidak Memiliki NPWP" : Eval("No_NPWP") %>' /></div>
                                </div>
                                 <div class="col" >
                                    <div class="" style="font-weight:bold">No Jamsostek : </div>
                                    <div class=""><asp:Label ID="No_JamsosLabel" runat="server" Text='<%#  (string)Eval("No_jamsos") =="0" ? "Tidak Memiliki Jamsostek" : Eval("No_jamsos") %>' /></div>
                                </div>
                                 <div class="col">
                                    <div class="" style="font-weight:bold">SIM : </div>
                                    <div class=""><asp:Label ID="Jen_SIMLabel" runat="server" Text='<%# Eval("Jen_sim")  !=null ? (int)Eval("Jen_sim")==1?"Sim A ":(int)Eval("Jen_sim")==2?"Sim B":"Tidak Ada Data": "Data Tidak Ada" %>' /><br />
                                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("No_SIM") !=null ? Eval("No_SIM"): "Data Tidak Ada"  %>'></asp:Label>
                                    </div>
                                </div>
                                 <div class="col">
                                    <div class="" style="font-weight:bold">No Rek BCA : </div>
                                    <div class=""><asp:Label ID="Label1" runat="server" Text='<%# (string)Eval("NoRekBCA") =="0" ? "Tidak Memiliki Rek BCA" : Eval("NoRekBCA") %>' /></div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div id="LatarBelakangKeluarga" class="form-group">
            <h4><asp:Label ID="LblLatarBelakangKeluarga" runat="server" Text="Latar Belakang Keluarga"></asp:Label></h4>
            <p><em>Data Orangtua</em></p>
            <asp:SqlDataSource ID="SqlDataSourceLBKel" runat="server"
				ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
				SelectCommand="SELECT* FROM Data_Keluarga WHERE (Id_Lamaran = @Param1)">
				<SelectParameters>
                    <asp:ControlParameter ControlID="LblIdLamaran" Name="Param1" PropertyName="Text" />
                </SelectParameters>
			</asp:SqlDataSource>
            <asp:ListView ID="ListViewLBKel" DataSourceID="SqlDataSourceLBKel" runat="server" DataKeyNames="Id_Keluarga" >
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <span>Data Tidak Di Temukan</span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <table class="TableDataDiri">
                        <tr>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Nama Ayah : </div>
                                    <div class=""><asp:Label ID="DPNama" runat="server" Text='<%# Eval("Nm_Ayah") !=null ? Eval("Nm_Ayah"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Nama Ibu : </div>
                                    <div class=""><asp:Label ID="Label2" runat="server" Text='<%# Eval("Nm_Ibu") !=null ? Eval("Nm_Ibu"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Pekerjaan Ayah : </div>
                                    <div class=""><asp:Label ID="Label5" runat="server" Text='<%# (int)Eval("Pekerjaan_Ayah")==1?"PNS":(int)Eval("Pekerjaan_Ayah")==2?"Pegawai Swasta":(int)Eval("Pekerjaan_Ayah")==3?"Wira Usaha":(int)Eval("Pekerjaan_Ayah")==4?"Pensiun":(int)Eval("Pekerjaan_Ayah")==5?"Tidak Bekerja":"Tidak Ada Data" %>'></asp:Label></div>
                                </div>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Pekerjaan Ibu : </div>
                                    <div class=""><asp:Label ID="Label8" runat="server" Text='<%# (int)Eval("Pekerjaan_Ibu")==1?"PNS":(int)Eval("Pekerjaan_Ibu")==2?"Pegawai Swasta":(int)Eval("Pekerjaan_Ibu")==3?"Wira Usaha":(int)Eval("Pekerjaan_Ibu")==4?"Pensiun":(int)Eval("Pekerjaan_Ibu")==5?"Tidak Bekerja":"Tidak Ada Data" %>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Pendidikan Ayah : </div>
                                    <div class=""><asp:Label ID="Label3" runat="server" Text='<%# (int)Eval("Pendidikan_Ayah") !=0 ? (int)Eval("Pendidikan_Ayah")==1?"SMP":(int)Eval("Pendidikan_Ayah")==2?"SMA":(int)Eval("Pendidikan_Ayah")==3?"Sarjana": "SMA":(int)Eval("Pendidikan_Ayah")==4?"Magister": "Tidak Ada Data" %>'></asp:Label></div>
                                </div>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Pendidikan Ibu : </div>
                                    <div class=""><asp:Label ID="Label7" runat="server" Text='<%# (int)Eval("Pendidikan_Ibu") !=0 ? (int)Eval("Pendidikan_Ibu")==1?"SMP":(int)Eval("Pendidikan_Ibu")==2?"SMA":(int)Eval("Pendidikan_Ibu")==3?"Sarjana": "SMA":(int)Eval("Pendidikan_Ibu")==4?"Magister": "Tidak Ada Data" %>'></asp:Label></div>                                   
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Usia Ayah : </div>
                                    <div class=""><asp:Label ID="Label4" runat="server" Text='<%# (int)Eval("Usia_Ayah") !=0 ? Eval("Usia_Ayah") :"Tidak Ada Data"%>'></asp:Label></div>
                                </div>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Usia Ibu : </div>
                                    <div class=""><asp:Label ID="Label6" runat="server" Text='<%# (int)Eval("Usia_Ibu") !=0 ? Eval("Usia_Ibu") :"Tidak Ada Data"%>'></asp:Label></div>                                  
                                </div>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:ListView>
            <br />
            <p><em>Data Saudara Kandung</em></p>
            <asp:SqlDataSource ID="SqlDataSourceSaudaraKandung" runat="server"
				ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
				SelectCommand="SELECT* FROM data_Saudara WHERE (Id_Lamaran = @Param1)">
				<SelectParameters>
                    <asp:ControlParameter ControlID="LblIdLamaran" Name="Param1" PropertyName="Text" />
                </SelectParameters>
			</asp:SqlDataSource>
            <asp:ListView ID="ListViewDataSaudaraKandung" DataSourceID="SqlDataSourceSaudaraKandung" runat="server">
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <span>Data Tidak Di Temukan</span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <table class="TableDataDiri">
                        <tr>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Nama Saudara : </div>
                                    <div class=""><asp:Label ID="DPNama" runat="server" Text='<%# Eval("Nm_Saudara") !=null ? Eval("Nm_Saudara"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">jenis Kelamin : </div>
                                    <div class=""><asp:Label ID="Label10" runat="server" Text='<%# (int)Eval("Jenkel_Saudara") !=0 ? (int)Eval("Jenkel_Saudara")==1?"Pria":"Wanita": "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Usia : </div>
                                    <div class=""><asp:Label ID="Label11" runat="server" Text='<%# (int)Eval("Usia_Saudara") !=0 ? Eval("Usia_Saudara") :"Tidak Ada Data"%>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Pendidikan : </div>
                                    <div class=""><asp:Label ID="Label12" runat="server" Text='<%# (int)Eval("Pendidikan_Saudara") !=0 ? (int)Eval("Pendidikan_Saudara")==1?"SMP":(int)Eval("Pendidikan_Saudara")==2?"SMA":(int)Eval("Pendidikan_Saudara")==3?"Sarjana": "SMA":(int)Eval("Pendidikan_Saudara")==4?"Magister": "Tidak Ada Data" %>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Pekerjaan : </div>
                                    <div class=""><asp:Label ID="Label13" runat="server" Text='<%# (int)Eval("Pekerjaan_Saudara")==1?"PNS":(int)Eval("Pekerjaan_Saudara")==2?"Pegawai Swasta":(int)Eval("Pekerjaan_Saudara")==3?"Wira Usaha":(int)Eval("Pekerjaan_Saudara")==4?"Pensiun":(int)Eval("Pekerjaan_Saudara")==5?"Tidak Bekerja":"Tidak Ada Data" %>'></asp:Label></div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div id="StatusPerkawinan" class="form-group">
            <h4><asp:Label ID="LblStatusPerkawinan" runat="server" Text="Status Perkawinan"></asp:Label></h4>
             <p><em>Data Pasangan</em></p>
            <asp:SqlDataSource ID="SqlDataSourceStatusPerkawinan" runat="server"
				ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
				SelectCommand="SELECT* FROM Data_Pasangan WHERE (Id_Lamaran = @Param1)">
				<SelectParameters>
                    <asp:ControlParameter ControlID="LblIdLamaran" Name="Param1" PropertyName="Text" />
                </SelectParameters>
			</asp:SqlDataSource>
            <asp:ListView ID="ListViewDataPasangan" DataSourceID="SqlDataSourceStatusPerkawinan" runat="server">
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <p><em>Belum Menikah</em></p>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <table class="TableDataDiri">
                        <tr>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Nama Pasangan : </div>
                                    <div class=""><asp:Label ID="DPNama" runat="server" Text='<%# Eval("Nm_Pasangan") !=null ? Eval("Nm_Pasangan"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Usia : </div>
                                    <div class=""><asp:Label ID="Label14" runat="server" Text='<%# Eval("usia_Pasangan") !=null ? Eval("usia_Pasangan"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Pendidikan : </div>
                                    <div class=""><asp:Label ID="Label15" runat="server" Text='<%# (int)Eval("Pendidikan_Pasangan") !=0 ? (int)Eval("Pendidikan_Pasangan")==1?"SMP":(int)Eval("Pendidikan_Pasangan")==2?"SMA":(int)Eval("Pendidikan_Pasangan")==3?"Sarjana": "SMA":(int)Eval("Pendidikan_Pasangan")==4?"Magister": "Tidak Ada Data" %>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Pekerjaan : </div>
                                    <div class=""><asp:Label ID="Label16" runat="server" Text='<%# (int)Eval("Pekerjaan_Pasangan")==1?"PNS":(int)Eval("Pekerjaan_Pasangan")==2?"Pegawai Swasta":(int)Eval("Pekerjaan_Pasangan")==3?"Wira Usaha":(int)Eval("Pekerjaan_Pasangan")==4?"Pensiun":(int)Eval("Pekerjaan_Pasangan")==5?"Tidak Bekerja":"Tidak Ada Data" %>'></asp:Label></div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:ListView>
            <br />
            <p><em>Data Anak</em></p>
            <asp:SqlDataSource ID="SqlDataSourceDataAnak" runat="server"
				ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
				SelectCommand="SELECT* FROM Data_Anak WHERE (Id_Lamaran = @Param1)">
				<SelectParameters>
                    <asp:ControlParameter ControlID="LblIdLamaran" Name="Param1" PropertyName="Text" />
                </SelectParameters>
			</asp:SqlDataSource>
            <asp:ListView ID="ListViewDataAnak" DataSourceID="SqlDataSourceDataAnak" runat="server">
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <p><em>Belum Memiliki Anak</em></p>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <table class="TableDataDiri">
                        <tr>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Nama Anak : </div>
                                    <div class=""><asp:Label ID="DPNama" runat="server" Text='<%# Eval("Nm_Anak") !=null ? Eval("Nm_Anak"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Jenis Kelamin : </div>
                                    <div class=""><asp:Label ID="Label17" runat="server" Text='<%# (int)Eval("Jenkel_anak") !=0 ? (int)Eval("Jenkel_anak")==1?"Pria":"Wanita": "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Usia : </div>
                                    <div class=""><asp:Label ID="Label18" runat="server" Text='<%# (int)Eval("Usia_anak") !=0 ? Eval("Usia_anak") :"Tidak Ada Data"%>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Pendidikan : </div>
                                    <div class=""><asp:Label ID="Label19" runat="server" Text='<%# (int)Eval("Pendidikan_anak") !=0 ? (int)Eval("Pendidikan_anak")==1?"SMP":(int)Eval("Pendidikan_anak")==2?"SMA":(int)Eval("Pendidikan_anak")==3?"Sarjana": "SMA":(int)Eval("Pendidikan_anak")==4?"Magister": "Tidak Ada Data" %>'></asp:Label></div>
                                </div>
                            </td>
                            <td>
                                <div class="col">
                                    <div class="" style="font-weight:bold">Pekerjaan  : </div>
                                    <div class=""><asp:Label ID="Label20" runat="server" Text='<%# (int)Eval("Pekerjaan_anak")==1?"PNS":(int)Eval("Pekerjaan_anak")==2?"Pegawai Swasta":(int)Eval("Pekerjaan_anak")==3?"Wira Usaha":(int)Eval("Pekerjaan_anak")==4?"Pensiun":(int)Eval("Pekerjaan_anak")==5?"Tidak Bekerja":"Tidak Ada Data" %>'></asp:Label></div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
             </asp:ListView>
        </div>
        <div id="PendidikanFormal" class="form-group">
            <h4><asp:Label ID="LblPenFor" runat="server" Text="Pendidikan Formal"></asp:Label></h4>
            <asp:SqlDataSource ID="SqlDataSourcePenFor" runat="server"
				ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
				SelectCommand="SELECT* FROM Data_PenFormal WHERE (Id_Lamaran = @Param1)">
				<SelectParameters>
                    <asp:ControlParameter ControlID="LblIdLamaran" Name="Param1" PropertyName="Text" />
                </SelectParameters>
			</asp:SqlDataSource>
            <asp:ListView ID="ListView1" DataSourceID="SqlDataSourcePenFor" runat="server">
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <p><em>Data Pendidikan Formal Tidak Ada</em></p>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <table class="TableDataDiri table-hover">
                        <thead>
                            <tr>
                                <td style="padding:10px"><div class="" style="font-weight:bold">Jenjang</div></td>
                                <td  style="padding:10px"><div class="" style="font-weight:bold">Nama Instansi</div></td>
                                <td  style="padding:10px"><div class="" style="font-weight:bold">Kota</div></td>
                                <td  style="padding:10px" colspan="2"><center><div class="" style="font-weight:bold">Tahun</div></center></td>
                                <td  style="padding:10px"><div class="" style="font-weight:bold">Status Kelulusan</div></td>
                                <td  style="padding:10px"><div class="" style="font-weight:bold">Jurusan</div></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td  style="padding:10px"><div class="" style="font-weight:bold">Masuk</div></td>
                                <td  style="padding:10px"><div class="" style="font-weight:bold">Keluar</div></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td  style="padding:10px">
                                <div class="col">
                                    <div class=""><asp:Label ID="DPNama" runat="server" Text='<%# Eval("Jenjang") !=null ? Eval("Jenjang"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                                </td>
                                <td  style="padding:10px">
                                <div class="col">
                                    <div class=""><asp:Label ID="Label21" runat="server" Text='<%# Eval("Nama_Instansi") !=null ? Eval("Nama_Instansi"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                                </td>
                                <td  style="padding:10px">
                                <div class="col">
                                    <div class=""><asp:Label ID="Label22" runat="server" Text='<%# Eval("Kota") !=null ? Eval("Kota"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                                </td>
                                <td  style="padding:10px">
                                <div class="col">
                                    <div class=""><asp:Label ID="Label23" runat="server" Text='<%# (int)Eval("Thn_masuk") !=0 ? Eval("Thn_masuk"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                                </td>
                                <td  style="padding:10px">
                                <div class="col">
                                    <div class=""><asp:Label ID="Label24" runat="server" Text='<%# (int)Eval("thn_kel") !=0 ? Eval("thn_kel"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                                </td>
                                <td  style="padding:10px">
                                    <center>
                                        <div class="col"><!-- harusnya Int -->
                                            <div class=""><asp:Label ID="Label25" runat="server" Text='<%# (string)Eval("Status_kel") == "1" ? "Lulus": "Tidak Lulus" %>'></asp:Label></div>
                                        </div>
                                    </center></td>
                                <td  style="padding:10px">
                                        <div class="col">
                                            <div class=""><asp:Label ID="Label26" runat="server" Text='<%# Eval("Jurusan") !=null ? Eval("Jurusan"): "Data Tidak Ada" %>'></asp:Label></div>
                                        </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>                  
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div id="PendidikanNon" class="form-group">
            <h4><asp:Label ID="LblPenNon" runat="server" Text="Pendidikan NonFormal"></asp:Label></h4>
            <asp:SqlDataSource ID="SqlDataSourcePenNon" runat="server"
				ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
				SelectCommand="SELECT* FROM Data_PenNon WHERE (Id_Lamaran = @Param1)">
				<SelectParameters>
                    <asp:ControlParameter ControlID="LblIdLamaran" Name="Param1" PropertyName="Text" />
                </SelectParameters>
			</asp:SqlDataSource>
            <asp:ListView ID="ListView2" DataSourceID="SqlDataSourcePenNon" runat="server">
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <p><em>Data Pendidikan Non Formal Tidak Ada</em></p>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <table class="TableDataDiri table-hover">
                        <thead>
                            <tr>
                                <td style="padding:10px"><div class="" style="font-weight:bold">Nama Instansi </div></td>
                                <td style="padding:10px"><div class="" style="font-weight:bold">Tahun </div></td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style="padding:10px">
                                    <div class=""><asp:Label ID="Label18" runat="server" Text='<%# (string)Eval("Nama_instansi") !=null ? Eval("Nama_instansi") :"Tidak Ada Data"%>'></asp:Label></div>
                                </td>
                                <td style="padding:10px">
                                    <div class=""><asp:Label ID="Label27" runat="server" Text='<%# (int)Eval("Tahun") !=0 ? Eval("tahun") :"Tidak Ada Data"%>'></asp:Label></div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div id="BahasaAsing" class="form-group">
            <h4><asp:Label ID="LblBahasaA" runat="server" Text="Bahasa Asing"></asp:Label></h4>
            <asp:SqlDataSource ID="SqlDataSourceBahasa" runat="server"
				ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
				SelectCommand="SELECT* FROM Data_Bahasa WHERE (Id_Lamaran = @Param1)">
				<SelectParameters>
                    <asp:ControlParameter ControlID="LblIdLamaran" Name="Param1" PropertyName="Text" />
                </SelectParameters>
			</asp:SqlDataSource>
            <asp:ListView ID="ListViewBahasaAsing" DataSourceID="SqlDataSourceBahasa" runat="server">
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <p><em>Data Tidak Ada</em></p>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <table class="TableDataDiri">
                        <thead>
                            <tr>
                                <td style="padding:10px"><div class="" style="font-weight:bold">Jenis Bahasa</div></td>
                                <td style="padding:10px"><div class="" style="font-weight:bold">Penguasaan </div></td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style="padding:10px">
                                    <div class=""><asp:Label ID="Label18" runat="server" Text='<%# (string)Eval("Jenis_bahasa") !=null ? Eval("Jenis_bahasa") :"Tidak Ada Data"%>'></asp:Label></div>
                                </td>
                                <td style="padding:10px"><!-- Seharusnya Int -->
                                    <div class=""><asp:Label ID="Label27" runat="server" Text='<%# (string)Eval("Penguasaan") !="0" ? (string)Eval("Penguasaan") == "1"?"Baik":(string)Eval("Penguasaan") == "2"?"Cukup":(string)Eval("Penguasaan") == "3"?"Kurang":"Tidak Ada Data":"Tidak Ada Data"%>'></asp:Label></div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div id="PengalamanOrg" class="form-group">
            <h4><asp:Label ID="LblOrg" runat="server" Text="Pengalaman Organisasi"></asp:Label></h4>
            <asp:SqlDataSource ID="SqlDataSourcePengalamanOrg" runat="server"
				ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
				SelectCommand="SELECT* FROM Data_Organisasi WHERE (Id_Lamaran = @Param1)">
				<SelectParameters>
                    <asp:ControlParameter ControlID="LblIdLamaran" Name="Param1" PropertyName="Text" />
                </SelectParameters>
			</asp:SqlDataSource>
            <asp:ListView ID="ListViewOrg" DataSourceID="SqlDataSourcePengalamanOrg" runat="server">
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <p><em>Data Tidak Ada</em></p>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <table class="TableDataDiri">
                        <thead>
                            <tr>
                                <td style="padding:10px"><div class="" style="font-weight:bold">Nama Organisasi</div></td>
                                <td style="padding:10px"><div class="" style="font-weight:bold">Tahun </div></td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style="padding:10px">
                                    <div class=""><asp:Label ID="Label18" runat="server" Text='<%# (string)Eval("Nama_org") !=null ? Eval("Nama_org") :"Tidak Ada Data"%>'></asp:Label></div>
                                </td>
                                <td style="padding:10px"><!-- Seharusnya Int -->
                                    <div class=""><asp:Label ID="Label27" runat="server" Text='<%# (int)Eval("Tahun") !=0 ? Eval("Tahun"):"Tidak Ada Data"%>'></asp:Label></div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:ListView><br />
            <p><em>Data Pengalaman Memimpin</em></p>
            <asp:SqlDataSource ID="SqlDataSourceLeader" runat="server"
				ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
				SelectCommand="SELECT* FROM Data_Leader WHERE (Id_Lamaran = @Param1)">
				<SelectParameters>
                    <asp:ControlParameter ControlID="LblIdLamaran" Name="Param1" PropertyName="Text" />
                </SelectParameters>
			</asp:SqlDataSource>
            <asp:ListView ID="ListViewLeader" DataSourceID="SqlDataSourceLeader" runat="server">
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <p><em>Data Tidak Ada</em></p>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <table class="TableDataDiri">
                            <tr>
                                <td style="padding:10px"><!-- Seharusnya Int -->
                                    <div class=""><asp:Label ID="Label27" runat="server" Text='<%# (string)Eval("Pengalaman") !=null ? Eval("Pengalaman"):"Tidak Ada Data"%>'></asp:Label></div>
                                </td>
                            </tr>
                    </table>
                </ItemTemplate>
            </asp:ListView><br />
        </div>
        <div id="RiwayatPekerjaan" class="form-group">
            <h4><asp:Label ID="LblRiwPek" runat="server" Text="Riwayat Pekerjaan"></asp:Label></h4>
            <asp:SqlDataSource ID="SqlDataSourcePekerjaan" runat="server"
				ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
				SelectCommand="SELECT* FROM Data_Pekerjaan WHERE (Id_Lamaran = @Param1)">
				<SelectParameters>
                    <asp:ControlParameter ControlID="LblIdLamaran" Name="Param1" PropertyName="Text" />
                </SelectParameters>
			</asp:SqlDataSource>
            <asp:ListView ID="ListView3" DataSourceID="SqlDataSourcePekerjaan" runat="server">
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <p><em>Data Tidak Ada</em></p>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <table class="TableDataDiri table-borderles">
                        <thead>
                            <tr>
                                <td style="padding:10px"><div class="" style="font-weight:bold"><center>Detail Perusahaan</center></div></td>
                                <td  style="padding:10px"><div class="" style="font-weight:bold"><center>Atasan & Jabatan</center></div></td>
                                <td  style="padding:10px" colspan="2"><center><div class="" style="font-weight:bold">Gaji</div></center></td>
                                <td  style="padding:10px" colspan="2"><center><div class="" style="font-weight:bold">Waktu</div></center></td>
                                <td  style="padding:10px"><div class="" style="font-weight:bold"><center>Alasan Keluar</center></div></td>
                                <td  style="padding:10px" colspan="3"><center><div class="" style="font-weight:bold">JobDesk</div></center></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td  style="padding:10px"><div class="" style="font-weight:bold">Awal</div></td>
                                <td  style="padding:10px"><div class="" style="font-weight:bold">Akhir</div></td>
                                <td  style="padding:10px"><div class="" style="font-weight:bold">Masuk</div></td>
                                <td  style="padding:10px"><div class="" style="font-weight:bold">Keluar</div></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td  style="padding:10px">
                                <div class="col">
                                    <div class="">
                                        <div class="" style="font-weight:bold">Nama Perusahaan : </div>
                                        <asp:Label ID="NamaPerusahaan" runat="server" Text='<%# Eval("Nama_Perusahaan") !=null ? Eval("Nama_Perusahaan"): "Data Tidak Ada" %>'></asp:Label></div><br />
                                    <div class="">
                                        <div class="" style="font-weight:bold">Alamat : </div>
                                        <asp:Label ID="Label28" runat="server" Text='<%# Eval("Alamat_Perusahaan") !=null ? Eval("Alamat_Perusahaan"): "Data Tidak Ada" %>'></asp:Label></div>
                                    <div class="">
                                        <div class="" style="font-weight:bold">Telpon : </div>
                                        <asp:Label ID="Label37" runat="server" Text='<%# Eval("Telp_Perusahaan") !=null ? Eval("Telp_Perusahaan"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                                </td>
                                <td  style="padding:10px">
                                <div class="col">
                                    <div class=""><asp:Label ID="Label35" runat="server" Text='<%# Eval("Nama_Atasan") !=null ? Eval("Nama_Atasan"): "Data Tidak Ada" %>'></asp:Label></div><br />
                                    <div class=""><asp:Label ID="Label31" runat="server" Text='<%# Eval("Jabatan") !=null ? Eval("Jabatan"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div>
                                </td>
                                <td  style="padding:10px">
                                    <div class=""><asp:Label ID="Label29" runat="server" Text='<%# Eval("Gaji_Awal") !=null ? Eval("Gaji_Awal", "{0:0,00}"): "Data Tidak Ada" %>'></asp:Label></div>
                                </td>
                                <td  style="padding:10px">
                                    <div class=""><asp:Label ID="Label30" runat="server" Text='<%# Eval("Gaji_Akhir") !=null ? Eval("Gaji_Akhir", "{0:0,00}"): "Data Tidak Ada" %>'></asp:Label></div>
                                </td>
                                <td  style="padding:10px">
                                    <div class=""><asp:Label ID="Label32" runat="server" Text='<%# Eval("Tgl_Masuk") !=null ? Eval("Tgl_Masuk", "{0:d}"): "Data Tidak Ada" %>'></asp:Label></div>
                                </td>
                                <td  style="padding:10px">
                                    <div class=""><asp:Label ID="Label33" runat="server" Text='<%# Eval("Tgl_Keluar") !=null ? Eval("Tgl_Keluar", "{0:d}"): "Data Tidak Ada" %>'></asp:Label></div>
                                </td>
                                <td  style="padding:10px">
                                     <div class=""><asp:Label ID="Label34" runat="server" Text='<%# Eval("Alasan_Keluar") !=null ? Eval("Alasan_Keluar"): "Data Tidak Ada" %>'></asp:Label></div>
                                </td>
                                <td><div class="" style="padding:1px"><asp:Label ID="Label36" runat="server" Text='<%# Eval("Jobdesk") !=null ? Eval("Jobdesk"): "Data Tidak Ada" %>'></asp:Label></div></td>
                            </tr>
                        </tbody>
                    </table><br />
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div id="Referensi" class="form-group">
            <h4><asp:Label ID="LblReferensi" runat="server" Text="Referensi"></asp:Label></h4>
            <asp:SqlDataSource ID="SqlDataSourceReferensi" runat="server"
				ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
				SelectCommand="SELECT* FROM Data_Referensi WHERE (Id_Lamaran = @Param1)">
				<SelectParameters>
                    <asp:ControlParameter ControlID="LblIdLamaran" Name="Param1" PropertyName="Text" />
                </SelectParameters>
			</asp:SqlDataSource>
            <asp:ListView ID="ListView4" DataSourceID="SqlDataSourceReferensi" runat="server">
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <p><em>Data Tidak Ada</em></p>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <table class="TableDataDiri">
                        <thead>
                            <tr>
                                <td style="padding:10px"><div class="" style="font-weight:bold"><center>Nama</center></div></td>
                                <td style="padding:10px"><div class="" style="font-weight:bold"><center>Alamat</center></div></td>
                                <td style="padding:10px"><div class="" style="font-weight:bold"><center>Pekerjaan</center></div></td>
                                <td style="padding:10px"><div class="" style="font-weight:bold"><center>Hubungan</center></div></td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                <div class="col">
                                    <div class="" style="padding:10px"><asp:Label ID="DPNama" runat="server" Text='<%# Eval("Nama_Referensi") !=null ? Eval("Nama_Referensi"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div></td>
                                <td>
                                <div class="col">
                                    <div class="" style="padding:10px"><asp:Label ID="Label38" runat="server" Text='<%# Eval("Alamat_Referensi") !=null ? Eval("Alamat_Referensi"): "Data Tidak Ada" %>'></asp:Label></div>
                                </div></td>
                                <td>
                                <div class="col">
                                    <div class="" style="padding:10px"><asp:Label ID="Label5" runat="server" Text='<%# (string)Eval("Pekerjaan_Referensi")=="1"?"PNS":(string)Eval("Pekerjaan_Referensi")=="2"?"Pegawai Swasta":(string)Eval("Pekerjaan_Referensi")=="3"?"Wira Usaha":(string)Eval("Pekerjaan_Referensi")=="4"?"Pensiun":(string)Eval("Pekerjaan_Referensi")=="5"?"Tidak Bekerja":"Tidak Ada Data" %>'></asp:Label></div>
                                </div></td>
                                <td>
                                <div class="col">
                                    <div class="" style="padding:10px"><asp:Label ID="Label39" runat="server" Text='<%# (int)Eval("Hubungan_Referensi") !=0 ? (int)Eval("Hubungan_Referensi")==1?"Atasan":(int)Eval("Hubungan_Referensi")==2?"Rekan Kerja":(int)Eval("Hubungan_Referensi")==3?"Teman":"Tidak Ada Data": "Tidak Ada Data" %>'></asp:Label></div>
                                </div></td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div id="Pertanyaan" class="form-group">
            <h4><asp:Label ID="LblPertanyaan" runat="server" Text="Pertanyaan"></asp:Label></h4>
            <asp:SqlDataSource ID="SqlDataSourceDataPertanyan" runat="server"
				ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
				SelectCommand="SELECT* FROM Data_Pertanyaan WHERE (Id_Lamaran = @Param1)">
				<SelectParameters>
                    <asp:ControlParameter ControlID="LblIdLamaran" Name="Param1" PropertyName="Text" />
                </SelectParameters>
			</asp:SqlDataSource>
            <asp:ListView ID="ListViewDataPertanyaan" DataSourceID="SqlDataSourceDataPertanyan" runat="server">
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <p><em>Data Tidak Ada</em></p>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <b><p><em>1. Apakah anda pernah sakit yang membutuhkan perawatan di rumah sakit?</em></p></b>
                    <div class="" style="padding:10px"><asp:Label ID="Label39" runat="server" 
                        Text='<%# Eval("Desc_Sakit") !=null ? Eval("Desc_Sakit"): "Data Tidak Ada" %>'></asp:Label>
                    </div>
                    <br />
                    <b><p><em>2. Sebutkan kelebihan diri anda!</em></p></b>
                        <div class="" style="padding:10px"><asp:Label ID="Label40" runat="server" 
                        Text='<%# Eval("Kelebihan") !=null ? Eval("Kelebihan"): "Data Tidak Ada" %>'></asp:Label>
                    </div>
                    <br />
                    <b><p><em>3. Sebutkan kekurangan diri anda!</em></p></b>
                        <div class="" style="padding:10px"><asp:Label ID="Label41" runat="server" 
                        Text='<%# Eval("Kekurangan") !=null ? Eval("Kekurangan"): "Data Tidak Ada" %>'></asp:Label>
                    </div>
                    <br />
                    <b><p><em>4. Keahlian apa saja yang anda miliki?</em></p></b>
                        <div class="" style="padding:10px"><asp:Label ID="Label42" runat="server" 
                        Text='<%# Eval("Keahlian") !=null ? Eval("Keahlian"): "Data Tidak Ada" %>'></asp:Label>
                    </div>
                    <br />
                    <b><p><em>5. Apa yang anda ketahui mengenai "Job Description" dari pekerjaan yang anda lamar ini?</em></p></b>
                        <div class="" style="padding:10px"><asp:Label ID="Label43" runat="server" 
                        Text='<%# Eval("JobDesc") !=null ? Eval("JobDesc"): "Data Tidak Ada" %>'></asp:Label>
                    </div>
                    <br />
                    <b><p><em>6. Berapa gaji yang anda harapkan? </em></p></b>
                        <div class="" style="padding:10px"><asp:Label ID="Label44" runat="server" 
                        Text='<%# Eval("HarapGaji") !=null ? Eval("HarapGaji", "{0:0,00}"): "Data Tidak Ada" %>'></asp:Label>
                    </div><br />
                    <b><p><em>7. Sebutkan tunjangan/fasilitas yang anda inginkan! </em></p></b>
                        <div class="" style="padding:10px"><asp:Label ID="Label45" runat="server" 
                        Text='<%# Eval("Tunjangan") !=null ? Eval("Tunjangan"): "Data Tidak Ada" %>'></asp:Label>
                    </div>
                    <br />
                    <b><p><em>8. Bila anda diterima, kapan anda siap bekerja di Honda Mugen? </em></p></b>
                        <div class="" style="padding:10px"><asp:Label ID="Label46" runat="server" 
                        Text='<%# Eval("SiapBekerja") !=null ? (int)Eval("SiapBekerja")==0?"Secepatnya":(int)Eval("SiapBekerja")==1?"1 Bulan Notifikasi":(int)Eval("SiapBekerja")==2?"1 Minggu Notifikasi":(int)Eval("SiapBekerja")==3?"2 Minggu Notifikasi":"Tidak Ada Data": "Tidak Ada Data" %>'></asp:Label>
                    </div>
                    <br />
                    <b><p><em>9. Apakah anda bersedia ditempatkan dimana saja sesuai dengan kebutuhan perusahaan?</em></p></b>
                        <div class="" style="padding:10px"><asp:Label ID="Label47" runat="server" 
                        Text='<%# Eval("Penempatan") !=null ? (int)Eval("Penempatan")==1?"Ya":(int)Eval("Penempatan")==2?"Tidak":"Tidak Ada Data": "Data Tidak Ada" %>'></asp:Label>
                    </div>
                    <br />
                    <b><p><em>10. Mengapa anda ingin bergabung dengan Honda Mugen?</em></p></b>
                        <div class="" style="padding:10px"><asp:Label ID="Label48" runat="server" 
                        Text='<%# Eval("AlasanBergabung") !=null ? Eval("AlasanBergabung"): "Data Tidak Ada" %>'></asp:Label>
                    </div>
                    <b><p><em>11. Apa yang anda ketahui tentang Honda Mugen?</em></p></b>
                        <div class="" style="padding:10px"><asp:Label ID="Label49" runat="server" 
                        Text='<%# Eval("tentangmugen") !=null ? Eval("tentangmugen"): "Data Tidak Ada" %>'></asp:Label>
                    </div>
                    <b><p><em>12. Anda senang bekerja pada lingkungan: </em></p></b>
                        <div class="" style="padding:10px"><asp:Label ID="Label50" runat="server" 
                        Text='<%# (string)Eval("LingkunganKerja") !="3" ? (string)Eval("LingkunganKerja")=="0"?"Di Dalam Kantor":(string)Eval("LingkunganKerja")=="1"?"Di Luar Kantor":(string)Eval("LingkunganKerja")=="2"?"Di Dalam Bengkel":"Lainya":"Data Tidak Ada" %>'></asp:Label><br />
                        <asp:Label ID="Label51" runat="server" Text='<%# Eval("LingkunganKerja") !=null ? Eval("LingkunganKerja"): "Data Tidak Ada" %>'></asp:Label>
                    </div>
                    <br />
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="c">
            <div class="b">
                <div class="t"></div>
            </div>
            <div class="b">
                <div class="t" ></div>
            </div>
            <div class="b">
                <div class="t" >
                    <asp:Label ID="Label52" runat="server" Text="Saya menyatakan apa yang ditulis adalah benar <br /> dan dapat di pertanggungjawabkan"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="LblTTD" runat="server" Text="Tidak Ada Data"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="LblDate" runat="server" Text="Tidak Ada Data"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
