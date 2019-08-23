<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomeHRD.aspx.cs" Inherits="PagesHRD_HomeHRD" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- DataTable -->
    <script src="../js/jquery-3.3.1.js"></script>
    <script src="../js/jquery.dataTables.min.js"></script>
    <script src="../js/dataTables.bootstrap4.min.js"></script>
    <!-- DataTable -->
    <script>
        $(document).ready(function () {
            //pelamar terposes
            $("#SearchPelamarter").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#ListPelamarter tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
            //menu pelamar baru
            $("#SearchPelamarBaru").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#ListPelamarBaru tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
            $("#SearchLowongan").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#ListLowongan tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
            //$('#ListPelamarBaru').DataTable();
        });
    </script>

    <style>
                /***************/
       #table-wrapper {
          position:relative;
        }
        #table-scroll {
          height:300px;
          overflow:auto;  
          margin-top:20px;
        }
        #table-wrapper table {
          width:100%;
        
        }
        #table-wrapper table thead th .text {
          position:absolute;   
          top:-20px;
          z-index:2;
          height:20px;
          width:35%;
          border:1px solid black;
        }
#outer
{
    width:100%;
    text-align: center;
}
.inner
{
    display: inline-block;
    margin: 1em;
}
.btn-mybutton {
  color: #000;
  background-color: #cccccc;
  border-color: #cccccc;
}
    </style>
    <asp:MultiView ID="MultiViewHRD" runat="server">
        <asp:View ID="View0" runat="server"><!-- -->
            <div class="form-group">
                <div class="col-sm-8" style="margin-bottom:4%;margin-top:1%">
                    <br />
		                <h2 class="display-4"><span ></span> Data Pelamar Baru </h2>
	                <br />
                </div>
            </div>
                            <br />
                            <input id="SearchPelamarBaru"  type="text" placeholder="Ketik yang akan di Cari!" class="form-control required" autocomplete="off" style="width:300px"/>
                            <br /> 
            <%--<div class="row">--%>
                    <div class="col" style="margin-bottom:4%;margin-top:1%">                            
                        <div id="table-scroll" class="table-scroll">
                          <div class="table-wrap">
                    	        <asp:SqlDataSource ID="SqlPelamarBaru" runat="server"
					                ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
					                SelectCommand="select Id_lamaran, User_nama, User_Posisi from Data_Lamaran where status_lamaran = 1 and Status_undangan = 0  order by Tgl_Lamar DESC"
					                ProviderName="<%$ ConnectionStrings:MugenKarirConnection.ProviderName %>">
				                </asp:SqlDataSource>   
                            <asp:ListView ID="LvPelamarBaru" runat="server" DataSourceID="SqlPelamarBaru" DataKeyNames ="Id_lamaran" enableviewstate="false"  >
                                <LayoutTemplate>
                                    <table  id="ListPelamarBaru" class="table table-bordered striped data" align="left">
                                        <thead>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">No</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">ID Lamaran</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Nama Pelamar</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Posisi</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Form</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download Photo</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download ID Card / KTP</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download NPWP</th><!-- JPG -->
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download Kartu Keluarga</th><!-- JPG, PDF -->
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download Ijazah</th><!-- JPG, PDF -->
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download Transkrip Nilai</th><!-- JPG, PDF -->
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download Surat Lamaran</th><!-- JPG, PDF -->
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download CV</th><!-- JPG, PDF -->
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Aksi</th><!-- JPG, PDF -->
                                        </thead>
                                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                    </table>
                                </LayoutTemplate>
                                <EmptyDataTemplate>
                                    <%--<p><em>Data Tidak Ada</em></p>--%>
                                    <div class="text-center" style="margin-left:5%">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/NoRecordFound.png"/>
                                    </div>                                  
                                </EmptyDataTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center" style="padding-top:40px"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                                        <td style="padding-top:40px"><center>DFT - <%#Eval("Id_Lamaran")%></center>
                                        </td>
                                        <td style="padding-top:40px"><%#Eval("User_nama")%></td>
                                        <td style="padding-top:40px"><%#Eval("User_posisi")%></td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonForm" class="btn btn-mybutton" runat="server" OnClick="LinkButtonForm_Click">Lihat Form</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonFoto" class="btn btn-mybutton" runat="server" OnClick="LinkButtonFoto_Click">Download Photo</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonKTP" class="btn btn-mybutton" runat="server" OnClick="LinkButtonKTP_Click">Download KTP</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonNPWP" class="btn btn-mybutton" runat="server" OnClick="LinkButtonNPWP_Click">Download NPWP</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonKK" class="btn btn-mybutton" runat="server" OnClick="LinkButtonKK_Click">Download KK</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonIjazah" class="btn btn-mybutton" runat="server" OnClick="LinkButtonIjazah_Click">Download Ijazah</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonNilai" class="btn btn-mybutton" runat="server" OnClick="LinkButtonNilai_Click">Download Transkrip Nilai</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonLamaran" class="btn btn-mybutton" runat="server" OnClick="LinkButtonLamaran_Click">Download Surat Lamaran</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonCV" class="btn btn-mybutton" runat="server" OnClick="LinkButtonCV_Click">Download CV</asp:LinkButton>
                                        </td>
                                        <td><div style="padding:5px">
                                             <asp:LinkButton ID="LinkButtonProses" class="btn btn-success" runat="server" OnClick="LinkButtonProses_Click">Proses</asp:LinkButton><br /></div><div style="padding:5px">
                                             <asp:LinkButton ID="LinkButtonTolak" class="btn btn-danger" runat="server" OnClick="LinkButtonTolak_Click">Tolak</asp:LinkButton></div><div style="padding:5px">
                                            <asp:LinkButton ID="LinkButtonUndang" class="btn btn-dark" OnClick="LinkButtonUndang_Click" runat="server">Undang Interview</asp:LinkButton></div><div style="padding:5px">
                                            <asp:LinkButton ID="LinkButtonUndangPsiko" class="btn btn-secondary" OnClick="LinkButtonUndangpsikotest_Click"  runat="server">Undang Psikotest</asp:LinkButton></div>
                                                                                                                                                                                    
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                          </div>
                        </div>
                    </div>
           <%-- </div>--%>

        </asp:View>
        <asp:View ID="View1" runat="server">
            <div>
                <br />
		            <h2  class="display-4"><span ></span> Data Lowongan Kerja </h2>
	            <br />
                    <asp:SqlDataSource ID="SqlDataSourceViewListLowongan" 
                    runat="server"
                    ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
                    SelectCommand="select * from List_Lowongan"
					ProviderName="<%$ ConnectionStrings:MugenKarirConnection.ProviderName %>"                   
                    ></asp:SqlDataSource>
                    <br />
                    <input id="SearchLowongan"  type="text" placeholder="Ketik Posisi yang akan di Cari!" class="form-control required" autocomplete="off" style="width:300px"/>
                    <br />  
                    <div class="table-responsive">
                        <div id="table-wrapper">
                            <div id="table-scroll">
                            <table id="ListLowongan" align="left" class="table table-hover" style="width:1300px">
                                <thead style="color:#f1f1f1;">
                                    <tr>
                                        <th style="color:red" scope="col">Check</th>
                                        <th style="color:red" scope="col">ID Lowongan</th>
                                        <th style="color:red" scope="col">Posisi</th>
                                        <th style="color:red" scope="col">Kualifikasi</th>
                                        <th style="color:red" scope="col">Status</th>
                                        <th style="color:red" scope="col">Tanggal Posting</th>
                               
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:ListView ID="LvListLowongan" 
                                DataSourceID="SqlDataSourceViewListLowongan" 
                                DataKeyNames="Id_Lowongan"
                                runat="server">
                                <LayoutTemplate>
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                </LayoutTemplate>
                                <ItemTemplate>
                                      <tr>
                                          <td>
                                                <asp:CheckBox ID="CheckBoxListLowongan" runat="server" value='<%# Eval("id_lowongan") %>' /> 
                                          </td>
                                          <td><%#Eval("id_lowongan")%></td>
                                          <td><%#Eval("Posisi")%></td>
                                          <td><%#Eval("Kualifikasi")%></td>
                                          <td><%# Eval("Status_Lowongan").ToString() == "1" ? "Aktif" : "NonAktif" %></td>
                                          <td><%#Eval("Tgl_post")%></td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <div class="text-center" style="margin-left:35%">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/NoRecordFound.png"/>
                                    </div>           
                                </EmptyDataTemplate>
                            </asp:ListView>
                                </tbody>
                            </table>
                            </div>
                            </div>
                        </div>
                    <br /> 
                    <div id="outer">
                            <div class="inner">
                                <asp:Button ID="BtnHapus" runat="server" Text="Hapus Lowongan" class="btn btn-danger" OnClick="BtnHapus_Click" /></div>
                            <div class="inner">
                                <asp:Button ID="BtnNonAktif" runat="server" Text="NonAktifkan Lowongan" class="btn btn-warning" OnClick="BtnNonAktif_Click" /></div>
                            <div class="inner">
                                <asp:Button ID="BtnAktif" runat="server" Text="Aktifkan Lowongan" class="btn btn-success" OnClick="BtnAktif_Click"/></div>
                            <div class="inner">
                                <asp:Button ID="BtnUpdate" runat="server" Text="Perbarui Lowongan" class="btn btn-success" OnClick="BtnUpdate_Click"/></div>                    
                    </div> 
                    <br />
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div >
                <br />
		            <h2 class="display-4"><span ></span> Data Pelamar Terproses</h2>
	            <br />
                            <br />
                            <input id="SearchPelamarter"  type="text" placeholder="Ketik yang akan di Cari!" class="form-control required" autocomplete="off" style="width:300px"/>
                            <br /> 
                <div class="col-12" style="overflow:auto">
                    <div class="form-group">
                        <div class="col" style="margin-bottom:4%;margin-top:1%">
                    	        <asp:SqlDataSource ID="SqlDataSourceterposes" runat="server"
					                ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
					                SelectCommand="select Id_lamaran, User_nama, User_Posisi from Data_Lamaran where status_lamaran = 1 and Status_undangan = 1  order by Tgl_Lamar DESC"
					                ProviderName="<%$ ConnectionStrings:MugenKarirConnection.ProviderName %>">
				                </asp:SqlDataSource>   
                            <asp:ListView ID="ListViewPelamarTerproses" runat="server" DataSourceID="SqlDataSourceterposes" DataKeyNames ="Id_lamaran" enableviewstate="false"  >
                                <LayoutTemplate>
                                    <table  id="ListPelamarter" class="table table-bordered striped data" align="left">
                                        <thead>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">No</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">ID Lamaran</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Nama Pelamar</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Posisi</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Form</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download Photo</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download ID Card / KTP</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download NPWP</th><!-- JPG -->
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download Kartu Keluarga</th><!-- JPG, PDF -->
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download Ijazah</th><!-- JPG, PDF -->
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download Transkrip Nilai</th><!-- JPG, PDF -->
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download Surat Lamaran</th><!-- JPG, PDF -->
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download CV</th><!-- JPG, PDF -->
                                        </thead>
                                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                    </table>
                                </LayoutTemplate>
                                <EmptyDataTemplate>
                                    <div class="text-center" style="margin-left:35%">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/NoRecordFound.png"/>
                                    </div>           
                                </EmptyDataTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center" style="padding-top:40px"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                                        <td style="padding-top:40px"><center><%#Eval("Id_Lamaran")%></center>
                                        </td>
                                        <td style="padding-top:40px"><%#Eval("User_nama")%></td>
                                        <td style="padding-top:40px"><%#Eval("User_posisi")%></td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonForm" class="btn btn-mybutton" runat="server" OnClick="LinkButtonForm2_Click">Lihat Form</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonFoto" class="btn btn-mybutton" runat="server" OnClick="LinkButtonFoto2_Click">Download Photo</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonKTP" class="btn btn-mybutton" runat="server" OnClick="LinkButtonKTP2_Click">Download KTP</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonNPWP" class="btn btn-mybutton" runat="server" OnClick="LinkButtonNPWP2_Click">Download NPWP</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonKK" class="btn btn-mybutton" runat="server" OnClick="LinkButtonKK2_Click">Download KK</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonIjazah" class="btn btn-mybutton" runat="server" OnClick="LinkButtonIjazah2_Click">Download Ijazah</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonNilai" class="btn btn-mybutton" runat="server" OnClick="LinkButtonNilai2_Click">Download Transkrip Nilai</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonLamaran" class="btn btn-mybutton" runat="server" OnClick="LinkButtonLamaran2_Click">Download Surat Lamaran</asp:LinkButton>
                                        </td>
                                        <td style="padding-top:40px">
                                            <asp:LinkButton ID="LinkButtonCV" class="btn btn-mybutton" runat="server" OnClick="LinkButtonCV2_Click">Download CV</asp:LinkButton>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>

