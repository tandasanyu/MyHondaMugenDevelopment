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
            $("#SearchLowongan").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#ListLowongan tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
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
            <%--<div class="row">--%>
                <div class="col-9" style="overflow:auto">
                    <div class="form-group">
                        <div class="col" style="margin-bottom:4%;margin-top:1%">
                    	        <asp:SqlDataSource ID="SqlPelamarBaru" runat="server"
					                ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
					                SelectCommand="select Id_lamaran, User_nama, User_Posisi from Data_Lamaran where status_lamaran = 1  order by Tgl_Lamar DESC"
					                ProviderName="<%$ ConnectionStrings:MugenKarirConnection.ProviderName %>">
				                </asp:SqlDataSource>   
                            <asp:ListView ID="LvPelamarBaru" runat="server" DataSourceID="SqlPelamarBaru" DataKeyNames ="Id_lamaran" enableviewstate="false"  >
                                <LayoutTemplate>
                                    <table class="table table-bordered striped data" align="left">
                                        <thead>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">No</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">ID Lamaran</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Nama Pelamar</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Posisi</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Form</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download Photo</th>
                                            <th style="text-align:center; color:red; background-color:#a9a9a9">Download ID Card</th>
                                        </thead>
                                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center"><p class="small"><%#Container.DataItemIndex + 1 %></p></td>
                                        <td><%#Eval("Id_Lamaran")%>
                                        </td>
                                        <td><%#Eval("User_nama")%></td>
                                        <td><%#Eval("User_posisi")%></td>
                                        <td>
                                            <asp:LinkButton ID="LinkButtonForm" class="btn btn-mybutton" runat="server" OnClick="LinkButtonForm_Click">Lihat Form</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButtonFoto" class="btn btn-mybutton" runat="server" OnClick="LinkButtonFoto_Click">Download Photo</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButtonKTP" class="btn btn-mybutton" runat="server" OnClick="LinkButtonKTP_Click">Download KTP</asp:LinkButton>
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
                                    Data List Lowongan Tidak Di temukan
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
                    </div> 
                    <br />
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div >
                <br />
		            <h2 class="display-4"><span ></span> Data Pelamar</h2>
	            <br />
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>

