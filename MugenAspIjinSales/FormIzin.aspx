<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FormIzin.aspx.vb" Inherits="FormIzin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <style>
        .centered {
          display: flex;
          width: 100vw;
          height: 100vh;
          justify-content: center;
          align-items: center;
        }
        h1.headertekst {
          text-align: center;
          
        }
        /*.centeredbtm {
            height: 50vh;
            }*/
        p.ex1 {
          border: 1px solid white; 
          padding-bottom: 300px;
          color:white;
        }
        </style>
    <script type="text/javascript"> 
        //keep the data table script first before the table build
        $(document).ready(function () {
                    //$('.data').DataTable();
                    //$('.data2').DataTable();
                    //$("#myInput").on("keyup", function () {
                    //    var value = $(this).val().toLowerCase();
                    //    $("#myTable tr").filter(function () {
                    //        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                    //    });
                    //});
                });
	    function MinDateManipulation() {
	        var e = document.getElementById('<%= LabelJenisIzin.ClientID %>').innerText;;
                //Read the inner text instead of value
	        var SelectedVal = e;
                //e.options[e.selectedIndex].innerText;
            if (SelectedVal == "Cuti") {
                return mindt =7;
            } else {
               return mindt  =-5;
            }
        }
        
        var dateToday = new Date()
        function DisableMonday(date) {
            var day = date.getDay();
            // If day == 1 then it is MOnday
            if (day == 0) {
                return [false];
            } else {
                return [true];
            }
        }
        //get current year
        //var year = currentTime.getFullYear() + 1
        $(function () {
            //date picker range 
            $(function () {         
                var dateFormat = "mm/dd/yy",

                  from = $("#<%= txtCutiPengajuan1.ClientID %>").datepicker({
                
                        //defaultDate: "+1w",
                        changeMonth: true,
                        minDate: MinDateManipulation(),
                        beforeShowDay: DisableMonday,
                        //maxDate: new Date(2018, 12, 31),
                        numberOfMonths:1
                    })
                    .on("change", function () {
                        to.datepicker("option", "minDate", getDate(this));
                    
                    }),
                  to = $("#<%= txtCutiPengajuan2.ClientID %>").datepicker({
                      //defaultDate: "+1w",
                      changeMonth: true,
                      beforeShowDay: DisableMonday,
                      //maxDate: new Date(2018, 12, 31),
                      numberOfMonths:1
                  })
                  .on("change", function () {
                      from.datepicker("option", "maxDate", getDate(this));
                  });
                function getDate(element) {
                    var date;
                    try {
                        date = $.datepicker.parseDate(dateFormat, element.value);
                    } catch (error) {
                        date = null;
                    }

                    return date;
                }
            });

            //pending cuti 
<%--	        $("#<%= TextBox3.ClientID %>").datepicker({
	            //dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            //enabledHours: [9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20],
	            //minDate: -5,
                changeYear:true,
	            numberOfMonths: 1,
	            //beforeShowDay: DisableMonday                	           
	        });
	        //izin pulang cepat
	        $("#<%= TxtIzinPulangCepat.ClientID %>").datepicker({
	            //dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            //enabledHours: [9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20],
	            minDate: -5,
	            numberOfMonths: 1,
	            beforeShowDay: DisableMonday                	           
	        });
	        $("#<%= TxtIzinDatangTelat.ClientID %>").datepicker({
	            //dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            //enabledHours: [9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20],
	            minDate: -5,
	            numberOfMonths: 1,
	            beforeShowDay: DisableMonday                	           
	        });
	        $("#<%= TxtTglCariIzin.ClientID %>").datepicker({
	            //dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            changeYear: true,
	            numberOfMonths: 1,
	            beforeShowDay: DisableMonday
	           
	        });
	        $("#<%= TxtTglCariIzin2.ClientID %>").datepicker({
	            //dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            changeYear: true,
	            numberOfMonths: 1,
	            beforeShowDay: DisableMonday
	           
	        });
	        $("#<%= TxtTglCariIzin3.ClientID %>").datepicker({
	            //dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            changeYear: true,
	            numberOfMonths: 1,
	            beforeShowDay: DisableMonday
	           
	        });
	        $("#<%= TxtTglCariIzin4.ClientID %>").datepicker({
	            //dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            changeYear: true,
	            numberOfMonths: 1,
	            beforeShowDay: DisableMonday
	           
	        });--%>
	    });
    </script>
      <script>
      $( function() {
          $("#<%= TxtTerlambatkeluarTanggal.ClientID %>").datepicker(); 

      } );
      </script>
    <script>
        $(function () {
            $("#<%= TxtTerlambatkeluarWaktuKeluar.ClientID %>").timepicker({
                timeFormat: 'H:i',
                step : 1,
                minTime: '9:30am',
                maxTime: '4:30pm',
                
            });
            $("#<%= TxtTerlambatkeluarWaktuTerlambat.ClientID %>").timepicker({
                timeFormat: 'H:i',
                step : 1,
                minTime: '7:00am',
                maxTime: '11:30am',
                
            });
        });
    </script>
            <div id="divCheckbox" style="display:none">
            <asp:Label ID="cabang" runat="server" Text="Label" ></asp:Label><br /> <!-- 112VYE -->
            <asp:Label ID="kodesales" runat="server" Text="Label" ></asp:Label><br /><!-- VYE -->
            <asp:Label ID="nama" runat="server" Text="Label" ></asp:Label><br />
            <asp:Label ID="jabatan" runat="server" Text="Label" ></asp:Label><br />
            <asp:Label ID="grup" runat="server" Text="Label" ></asp:Label><br />
            <asp:Label ID="subjabatan" runat="server" Text="Label" ></asp:Label><br />
            <asp:Label ID="email" runat="server" Text="Label" ></asp:Label><br />
            <asp:Label ID="emailatasan" runat="server" Text="Label" ></asp:Label></div>
    <div class="container" >
          <h1 class="headertekst">FORM PENGAJUAN IZIN</h1><br /><br /><br />
        <div class="form-group">
          <%--<label for="email">Pilih Jenis Izin</label><br />--%>
            <asp:Button ID="Button5" runat="server" Text="Cuti" class="btn btn-info"/>
            <asp:Button ID="Button6" runat="server" Text="Tidak Masuk Kantor" class="btn btn-info"/>
            <asp:Button ID="Button3" runat="server" Text="Izin Terlambat" class="btn btn-info" />
            <asp:Button ID="Button4" runat="server" Text="Izin Keluar Kantor" class="btn btn-info"/>
        </div>
        </div>
    <asp:Label ID="LabelJenisIzin" runat="server" Text="Label" Visible="true" ForeColor="white"></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server"><!-- Menu Cuti dan Tidak Masuk Kantor -->
            <div class="container">
              <h3>
                  <asp:Label ID="lblCuti" runat="server" Text="Izin Cuti"></asp:Label>
                  <asp:Label ID="lblTidakMasukKantor" runat="server" Text="Izin Tidak Masuk Kantor"></asp:Label>
              </h3>
                <div class="form-group">
                  <label for="email">Nama : </label>
                    <asp:TextBox ID="TxtCutiNama" runat="server"  class="form-control"   Width="200px" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label for="pwd">Tanggal Pengajuan :</label>
                    <table>
                        <tr>
                            <td><asp:TextBox ID="txtCutiPengajuan1" runat="server" class="form-control"  Width="200px" AutoCompleteType="Disabled"></asp:TextBox> </td>
                            <td> -- </td>
                            <td><asp:TextBox ID="TxtCutiPengajuan2" runat="server" class="form-control"  Width="200px" AutoCompleteType="Disabled"></asp:TextBox></td>
                        </tr>
                    </table>               
                </div>
                <div class="form-group">
                  <label for="email">Tahun Pengajuan : </label>
                     <asp:TextBox ID="TxtBulanCuti" runat="server" style ="display:none"></asp:TextBox>
                    <asp:TextBox ID="TxtCutiTahun" runat="server"  class="form-control"  Width="200px" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label for="email">Email Staff : </label>
                    <asp:TextBox ID="TxtCutiEmail" runat="server"  class="form-control"  Width="200px"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label for="pwd">Saldo Izin :</label>
                    <table>
                        <tr>
                            <td><asp:TextBox ReadOnly="true" ID="TxtCutiSaldoIzin" runat="server" class="form-control"  Width="200px"></asp:TextBox> </td>
                            <td> -- </td>
                            <td><asp:TextBox ReadOnly="true" ID="TxtCutiSaldoIzinBerlaku" runat="server" class="form-control"  Width="200px"></asp:TextBox></td>
                        </tr>
                    </table>               
                </div>
                <div class="form-group">
                  <label for="pwd">Saldo Pending Cuti :</label>
                    <table>
                        <tr>
                            <td><asp:TextBox ReadOnly="true" ID="TxtCutiSaldoPending" runat="server" class="form-control"  Width="200px"></asp:TextBox> </td>
                            <td> -- </td>
                            <td><asp:TextBox ReadOnly="true" ID="TxtCutiSaldoPendingBerlaku" runat="server" class="form-control"  Width="200px"></asp:TextBox></td>
                        </tr>
                    </table>               
                </div>
                <div class="form-group">
                  <label id="alasancuti" for="email" runat="server">Alasan Pengajuan : </label>
                            <asp:DropDownList ID="DropDownListCutiAlasan"  runat="server"  class="form-control required" Width="200px">
                                <asp:ListItem Value="Cuti">Cuti</asp:ListItem>
                                <asp:ListItem Value="Cuti2">Cuti Melahirkan</asp:ListItem>
                                <asp:ListItem Value="Cuti3">Cuti Istimewa -- Menikah</asp:ListItem>
                                <asp:ListItem Value="Cuti4">Cuti Istimewa -- Orang Tua / Mertua Meninggal </asp:ListItem>
                                <asp:ListItem Value="Cuti5">Cuti Istimewa -- Bencana Alam</asp:ListItem>
                                <asp:ListItem Value="Cuti6">Cuti Istimewa -- Keluarga Meninggal SeAtap</asp:ListItem>
                                <asp:ListItem Value="Cuti7">Cuti Istimewa -- Khitanan / Baptisan Anak</asp:ListItem>
                                <asp:ListItem Value="Cuti8">Cuti Istimewa -- Pernikahan Anak</asp:ListItem>
                             </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListTidakMasukKantor" runat="server"  class="form-control required" Width="200px">
                                <asp:ListItem Value="Sakit Surat Dokter">Sakit Surat Dokter</asp:ListItem>
                                <asp:ListItem Value="Sakit Potong Gaji">Sakit Potong Gaji</asp:ListItem>
                                <asp:ListItem Value="Izin Potong Gaji">Izin Potong Gaji</asp:ListItem>
                                <asp:ListItem Value="Izin Potong Cuti">Izin Potong Cuti</asp:ListItem>
                                <asp:ListItem Value="Sakit Potong Cuti">Sakit Potong Cuti</asp:ListItem>
                                <asp:ListItem Value="Sakit Potong Gaji">Sakit Potong Gaji</asp:ListItem>
                            </asp:DropDownList>
                </div>
                <div class="form-group">
                  <label for="email">Alasan Detail : </label>
                    <asp:TextBox ID="TxtCutiAlasanDetail" runat="server"  class="form-control"  placeholder="Alasan Detail" Width="200px"></asp:TextBox>
                </div>
                <div class="form-group" id="uploadfile" runat="server">
                  <label for="email">Upload File : </label>
					<div id="Div1" runat="server">
                        <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" multiple="false" BorderStyle="None" class="btn btn-default"/>
					</div>
                </div>
                <div class="form-group">
                  <label for="email">Password : </label>
                    <asp:TextBox ID="TxtPswdValidCuti" runat="server"  class="form-control"  placeholder="Masukan Password" Width="200px" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button ID="BtnCuti" runat="server" Text="Submit" class="btn btn-default"/>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server"><!-- Menu Izin Terlambat dan Keluar Kantor -->
            <div class="container">
              <h3>
                  <asp:Label ID="LblTerlambat" runat="server" Text="Izin Terlambat"></asp:Label>
                  <asp:Label ID="LblKeluarKantor" runat="server" Text="Izin Keluar Kantor"></asp:Label>
              </h3>
                <div class="form-group">
                  <label for="Nama">Nama : </label> 
                    <asp:TextBox ID="TxtTerlambatkeluarNama" runat="server"  class="form-control"   Width="200px" readonly="true"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label for="pwd">Tanggal Pengajuan :</label>
                    <table>
                        <tr>
                            <td><asp:TextBox ID="TxtTerlambatkeluarTanggal" runat="server" class="form-control"  Width="200px" AutoCompleteType="Disabled"></asp:TextBox> </td>
                        </tr>
                    </table>               
                </div>
                <div class="form-group">
                  <label for="email">Waktu Pengajuan : </label>
                    <asp:TextBox ID="TxtTerlambatkeluarWaktuTerlambat" runat="server"  class="form-control"  Width="200px" ></asp:TextBox>
                    <asp:TextBox ID="TxtTerlambatkeluarWaktuKeluar" runat="server"  class="form-control"  Width="200px" ></asp:TextBox>
                </div>
                <div class="form-group">
                  
					<div id="Div2" runat="server">
                        <label for="UploadFile">Upload File : </label>
                        <asp:FileUpload ID="FileUpload2" runat="server" accept="image/*" multiple="false" BorderStyle="None" class="btn btn-default"/>
					</div>                    
                </div>
                <div class="form-group">
                  <label for="AlasanKeluarTidakMasuk">Alasan Pengajuan:</label>
                    <table>
                        <tr>
                            <td><asp:TextBox ID="TxtTerlambatKeluarAlasan" runat="server" class="form-control"  Width="200px"></asp:TextBox> </td>
                        </tr>
                    </table>               
                </div>
                <div class="form-group">
                  <label for="email">Password : </label>
                    <asp:TextBox ID="TxtPswdValidKeluar" runat="server"  class="form-control"  placeholder="Masukan Password" Width="200px" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button ID="BtnTerlambat" runat="server" Text="Submit" class="btn btn-default"/>
            </div>
        </asp:View>

    </asp:MultiView>
    <p class="ex1">A paragraph with a 25 pixels bottom padding.</p>
<%--        <div class="centeredbtm" style="visibility:hidden">
        
    </div>--%>

</asp:Content>

