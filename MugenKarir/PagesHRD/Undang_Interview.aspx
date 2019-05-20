<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Undang_Interview.aspx.cs" Inherits="PagesHRD_Undang_Interview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!-- DATEPICKER RANGE -->
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <script src="../js/jquery-1.12.4.js"></script>
    <script src="../js/moment.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <link href="../css/jquery.timepicker.min.css" rel="stylesheet" />
    <script src="../js/jquery.timepicker.min.js"></script>
    <script type="text/javascript">
      $( function() {
          $("#<%= TxtHariTgl.ClientID %>").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: "dd/mm/yy",
              yearRange: "-90:+00"
          });
            $("#<%= TxtPukul.ClientID %>").timepicker({
                timeFormat: 'H:i',
                step: 15
                //minTime: '9:30am',
                //maxTime: '4:30pm',
                
            });
      } );
      </script>
    <div class="row">
        <div class="col">
            <asp:MultiView ID="MultiViewUndangInterview" runat="server">
                <asp:View ID="View1" runat="server">
                   <br />     
                    <h3 class="text-center">Template Undangan Interview Pelamar Baru</h3><br />
                    <b>Masukan Subject Email : </b><asp:TextBox ID="TxtSubject" CssClass="form-control" runat="server" Width="600px"></asp:TextBox><br />
                    <p>Selamat Siang Bapak/Ibu,</p>
                    <p>Kami telah mereview CV singkat anda dan ingin mengundang Anda untuk bisa menghadiri Interview posisi <asp:Label ID="LblPosisi" runat="server" Text="Label"></asp:Label> yang akan diselenggarakan pada :</p>
                    <br />    
                    <div class="row">
                        <div class="col-sm-1"><p>Hari / Tanggal :</p></div>
                        <div class="col"><asp:TextBox ID="TxtHariTgl" class="form-control" autocomplete="off"  Width="150px" runat="server"></asp:TextBox></div>
                    </div>
                    <div class="row">
                        <div class="col-sm-1"><p>Pukul : </p></div>
                        <div class="col-sm-1"><asp:TextBox ID="TxtPukul" autocomplete="off"  class="form-control" Width="100px" runat="server"></asp:TextBox></div>
                    </div>
                    <div class="row">
                        <div class="col-sm-1"><p>Alamat : </p></div>
                        <div class="col-sm-1">
                            <asp:DropDownList class="form-control" Width="650px" ID="DDAlamat" runat="server">
                                <asp:ListItem>Gd. Honda Mugen Puri, Jl. Lingkar Luar Barat Puri Kembangan Jakarta Barat 11610</asp:ListItem>
                                <asp:ListItem>Gd. Honda Mugen, Jl. Raya Pasar Minggu No 10 Jakarta Selatan 12740</asp:ListItem>
                            </asp:DropDownList></div>
                    </div>
                    <div class="row">   
                        <div class="col-sm-1"><p>Membawa : </p></div>
                        <div class="col-sm-1">CV Lengkap</div>
                    </div>
                    <div class="row">
                        <div class="col-sm-1"><p>Bertemu : </p></div>
                        <div class="col-sm-1">
                            <asp:TextBox ID="TxtBertemu" autocomplete="off"  Width="150px" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <p>Harap untuk membalas email ini untuk konfirmasi kehadiran anda, atau bisa menghubungi nomor What’s App berikut 089649750950</p>
                    <p>Terima Kasih</p>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <p>Regards, </p>
                    <b><p>Retno Syifa Fauziah</p></b>
                    <p>Staff Recruitment HONDA MUGEN</p>
                    <p>PT. Mitrausaha Gentaniaga</p>
                    <p>Jl. Raya Pasar Minggu No. 10 Jakarta Selatan 12740</p>
                    <p>Tlp. (021) 797 2000 (Bengkel), (021) 797 3000 (Showroom)</p>
                    <p>Ext. 167</p>
                    <p>Email : recruitment@hondamugen.co.id</p>
                    <div style="margin-top:10px">
                        <asp:Button ID="BtnPreview" CssClass="btn btn-danger" runat="server" Text="Preview" OnClick="BtnPreview_Click" />
                    </div>
                    <br />
                    <br />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <h3>Undangan Interview</h3>
                     <div id="webcontent" runat="server">
                     </div>
                    <div style="margin-top:10px">
                        <asp:Button ID="BtnKirim" CssClass="btn btn-success" runat="server" Text="Kirim Email" OnClick="BtnKirim_Click" />
                    </div>
                    <br />
                    <br />
                </asp:View>
            </asp:MultiView>
 
        </div>
    </div>
</asp:Content>

