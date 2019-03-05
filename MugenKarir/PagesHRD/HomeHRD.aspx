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
        #table-wrapper table * {
          
          /*color:black;*/
         
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
}
    </style>
    <asp:MultiView ID="MultiViewHRD" runat="server">
        <asp:View ID="View0" runat="server"><!-- -->
        <div class="form-group">
            <div class="col-sm-8" style="margin-bottom:4%;margin-top:1%">
                <br />
		            <h2 style="font-family:Blunter;"><span ></span> Data Pelamar Baru </h2>
	            <br />
                </div>
            </div>
        </asp:View>
        <asp:View ID="View1" runat="server">
            <div >
                <br />
		            <h2 style="font-family:Blunter;"><span ></span> Data Lowongan Kerja </h2>
	            <br />
                <asp:SqlDataSource ID="SqlDataSourceViewListLowongan" 
                    runat="server"
                    ConnectionString="<%$ ConnectionStrings:MugenKarirConnection %>"
                    SelectCommand="select * from List_Lowongan"
					ProviderName="<%$ ConnectionStrings:MugenKarirConnection.ProviderName %>"                   
                    ></asp:SqlDataSource>
                    <br />
                    <input id="SearchLowongan"  type="text" placeholder="Ketik Posisi yang akan di Cari!" class="form-control required" autocomplete="off"/>
                    <br />  
                    <div class="table-responsive">
                        <div id="table-wrapper">
                            <div id="table-scroll">
                    <table id="ListLowongan" align="left" class="table" style="width:1300px">
                        <thead class="thead-dark">
                            <tr>
                                <th scope="col">Check</th>
                               <th scope="col">ID Lowongan</th>
                               <th scope="col">Posisi</th>
                                <th scope="col">Kualifikasi</th>
                                <th scope="col">Status</th>
                                <th scope="col">Tanggal Posting</th>
                                
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
		            <h2 style="font-family:Blunter;"><span ></span> Data Pelamar</h2>
	            <br />
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>

