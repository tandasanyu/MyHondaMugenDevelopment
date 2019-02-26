<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HRDFORMIZIN.aspx.vb" Inherits="HRDFORMIZIN" title="Form Izin" %>
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

    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('#staff').hide();
            $('#bawahan').hide();
            $('#btnstf').click(function () {
                $('#staff').show();
                $('#bawahan').hide();
            });
            $('#btnbwh').click(function () {
                $('#bawahan').show();
                $('#staff').hide();
            });
            //tombol baru
            $('#menuHrd1').hide();
            $('#menuHrd2').hide();
            $('#btnMenu1').click(function () {
                $('#menuHrd1').show();
                $('#menuHrd2').hide();
            });
            $('#btnMenu2').click(function () {
                $('#menuHrd2').show();
                $('#menuHrd1').hide();
            });
        });
    </script>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
    <script type="text/javascript">
        //Trim the input text
        function Trim(input) {
            var lre = /^\s*/;
            var rre = /\s*$/;
            input = input.replace(lre, "");
            input = input.replace(rre, "");
            return input;
        }
        function alasanTelatdanTerlambat() {
            var ValAlasan = document.getElementById('<%=TxtAlasanIzinPulangCepat.ClientID%>');
            if (ValAlasan ==""){
                alert("Alasan Wajib Di Isi!");
                file.focus();
                return false;
            }
            else {
                return true;
            }
        }
        //js untukcek apakah email staff kosong atau tidak
        function userValid() {
            var file = document.getElementById('<%=FileUpload1.ClientID%>');
            var fileName = file.value;
            //variable size validator
            var maxFileSize = 10 * 1024 * 1024; //1MB
            var actualFileSize = file.size;
            //Checking for file browsed or not 
            //DropDownListTidakMasuk -- && SelectedVal =='Sakit Surat Dokter'
            var e = document.getElementById('<%= DropDownListTidakMasuk.ClientID %>');
            //Read the inner text instead of value
            var SelectedVal = e.options[e.selectedIndex].innerText;
            if (SelectedVal=='Sakit Surat Dokter') {
                if (Trim(fileName) == '') {
                    alert("Please select a file to upload!!!");
                    file.focus();
                    return false;
                }
                if (actualFileSize > maxFileSize) {
                    alert("File Melebihi 1 Mb. Ulangi dengan file yang lebih kecil!!!");
                    file.focus();
                    return false;
                }
                //Setting the extension array for diff. type of text files 
                var extArray = new Array(".jpg", ".jpeg");

                //getting the file name
                while (fileName.indexOf("\\") != -1)
                    fileName = fileName.slice(fileName.indexOf("\\") + 1);

                //Getting the file extension                     
                var ext = fileName.slice(fileName.indexOf(".")).toLowerCase();

                //matching extension with our given extensions.
                for (var i = 0; i < extArray.length; i++) {
                    if (extArray[i] == ext) {
                        return true;
                    }
                }
                alert("File yang di izinkan untuk di upload hanya :  "
                  + (extArray.join("  ")) + "\nTolong pilih file anda kembali "
                  + "dan ulangi proses upload.");
                file.focus();
                return false;
            }
            else {
                return true;
            }  
        }
    </script>

    <script type="text/javascript">
        $(function () {

            //
            $('#DropDownListJmlTglCuti').change(function () {
                $("#<%= jmltglcuti.ClientID %>").val($('#DropDownListJmlTglCuti option:selected').attr("value"));
                console.log($('#DropDownListJmlTglCuti option:selected').data('id'));
            })
        $("#DropDownListJmlTglCuti").change(function () {
            if ($(this).val() == "1") {
                $("#dvtgl1").show();
                $("#dvtgl2").hide();
                $("#dvtgl3").hide();
                $("#dvtgl4").hide();
                $("#dvtgl5").hide();
                $("#dvtgl6").hide();
                $("#dvtgl7").hide();
                $("#dvtgl8").hide();
                $("#dvtgl9").hide();
                $("#dvtgl10").hide();
                $("#dvtgl11").hide();
                $("#dvtgl12").hide();
              
            } else if ($(this).val() == "2") {
                $("#dvtgl1").show();
                $("#dvtgl2").show();
                $("#dvtgl3").hide();
                $("#dvtgl4").hide();
                $("#dvtgl5").hide();
                $("#dvtgl6").hide();
                $("#dvtgl7").hide();
                $("#dvtgl8").hide();
                $("#dvtgl9").hide();
                $("#dvtgl10").hide();
                $("#dvtgl11").hide();
                $("#dvtgl12").hide();
            } else if ($(this).val() == "3") {
                $("#dvtgl1").show();
                $("#dvtgl2").show();
                $("#dvtgl3").show();
                $("#dvtgl4").hide();
                $("#dvtgl5").hide();
                $("#dvtgl6").hide();
                $("#dvtgl7").hide();
                $("#dvtgl8").hide();
                $("#dvtgl9").hide();
                $("#dvtgl10").hide();
                $("#dvtgl11").hide();
                $("#dvtgl12").hide();
            } else if ($(this).val() == "4") {
                $("#dvtgl1").show();
                $("#dvtgl2").show();
                $("#dvtgl3").show();
                $("#dvtgl4").show();
                $("#dvtgl5").hide();
                $("#dvtgl6").hide();
                $("#dvtgl7").hide();
                $("#dvtgl8").hide();
                $("#dvtgl9").hide();
                $("#dvtgl10").hide();
                $("#dvtgl11").hide();
                $("#dvtgl12").hide();
            } else if ($(this).val() == "5") {
                $("#dvtgl1").show();
                $("#dvtgl2").show();
                $("#dvtgl3").show();
                $("#dvtgl4").show();
                $("#dvtgl5").show();
                $("#dvtgl6").hide();
                $("#dvtgl7").hide();
                $("#dvtgl8").hide();
                $("#dvtgl9").hide();
                $("#dvtgl10").hide();
                $("#dvtgl11").hide();
                $("#dvtgl12").hide();
            } else if ($(this).val() == "6") {
                $("#dvtgl1").show();
                $("#dvtgl2").show();
                $("#dvtgl3").show();
                $("#dvtgl4").show();
                $("#dvtgl5").show();
                $("#dvtgl6").show();
                $("#dvtgl7").hide();
                $("#dvtgl8").hide();
                $("#dvtgl9").hide();
                $("#dvtgl10").hide();
                $("#dvtgl11").hide();
                $("#dvtgl12").hide();
            } else if ($(this).val() == "7") {
                $("#dvtgl1").show();
                $("#dvtgl2").show();
                $("#dvtgl3").show();
                $("#dvtgl4").show();
                $("#dvtgl5").show();
                $("#dvtgl6").show();
                $("#dvtgl7").show();
                $("#dvtgl8").hide();
                $("#dvtgl9").hide();
                $("#dvtgl10").hide();
                $("#dvtgl11").hide();
                $("#dvtgl12").hide();
            } else if ($(this).val() == "8") {
                $("#dvtgl1").show();
                $("#dvtgl2").show();
                $("#dvtgl3").show();
                $("#dvtgl4").show();
                $("#dvtgl5").show();
                $("#dvtgl6").show();
                $("#dvtgl7").show();
                $("#dvtgl8").show();
                $("#dvtgl9").hide();
                $("#dvtgl10").hide();
                $("#dvtgl11").hide();
                $("#dvtgl12").hide();
            } else if ($(this).val() == "9") {
                $("#dvtgl1").show();
                $("#dvtgl2").show();
                $("#dvtgl3").show();
                $("#dvtgl4").show();
                $("#dvtgl5").show();
                $("#dvtgl6").show();
                $("#dvtgl7").show();
                $("#dvtgl8").show();
                $("#dvtgl9").show();
                $("#dvtgl10").hide();
                $("#dvtgl11").hide();
                $("#dvtgl12").hide();
            } else if ($(this).val() == "10") {
                $("#dvtgl1").show();
                $("#dvtgl2").show();
                $("#dvtgl3").show();
                $("#dvtgl4").show();
                $("#dvtgl5").show();
                $("#dvtgl6").show();
                $("#dvtgl7").show();
                $("#dvtgl8").show();
                $("#dvtgl9").show();
                $("#dvtgl10").show();
                $("#dvtgl11").hide();
                $("#dvtgl12").hide();
            } else if ($(this).val() == "11") {
                $("#dvtgl1").show();
                $("#dvtgl2").show();
                $("#dvtgl3").show();
                $("#dvtgl4").show();
                $("#dvtgl5").show();
                $("#dvtgl6").show();
                $("#dvtgl7").show();
                $("#dvtgl8").show();
                $("#dvtgl9").show();
                $("#dvtgl10").show();
                $("#dvtgl11").show();
                $("#dvtgl12").hide();
            } else if ($(this).val() == "12") {
                $("#dvtgl1").show();
                $("#dvtgl2").show();
                $("#dvtgl3").show();
                $("#dvtgl4").show();
                $("#dvtgl5").show();
                $("#dvtgl6").show();
                $("#dvtgl7").show();
                $("#dvtgl8").show();
                $("#dvtgl9").show();
                $("#dvtgl10").show();
                $("#dvtgl11").show();
                $("#dvtgl12").show();
            } else if ($(this).val() == "0") {
                $("#dvtgl1").hide();
                $("#dvtgl2").hide();
                $("#dvtgl3").hide();
                $("#dvtgl4").hide();
                $("#dvtgl5").hide();
                $("#dvtgl6").hide();
                $("#dvtgl7").hide();
                $("#dvtgl8").hide();
                $("#dvtgl9").hide();
                $("#dvtgl10").hide();
                $("#dvtgl11").hide();
                $("#dvtgl12").hide();
            }
        });
    });
    </script>
    <script type="text/javascript">
        function saldo_berlaku() {
            var value = document.getElementById('<%= DDJenisOperasiSaldoCuti.ClientID %>').options[document.getElementById('<%= DDJenisOperasiSaldoCuti.ClientID %>').selectedIndex].value;
            var selectedvalue = value;
            if (selectedvalue == "4" ) {
                $("#RbJenisPending").show();
            } else {
                $("#RbJenisPending").hide();
            }      
        }
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#<%= TxtIzinPulangCepatJam.ClientID %>").timepicker({
                timeFormat: 'H:i',
                step : 1,
                minTime: '9:30am',
                maxTime: '4:30pm',
                
            });
            $("#<%= TxtIzinDatangTelatJam.ClientID %>").timepicker({
                timeFormat: 'H:i',
                step : 1,
                minTime: '7:00am',
                maxTime: '11:30am',
                
            });
        });
    </script>

    <script type="text/javascript"> 
        //keep the data table script first before the table build
        $(document).ready(function () {
                    $('.data').DataTable();
                    $('.data2').DataTable();
                    $("#myInput").on("keyup", function () {
                        var value = $(this).val().toLowerCase();
                        $("#myTable tr").filter(function () {
                            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                        });
                    });
                    //$('#dataTablex').DataTable({
                    //    //"scrollY": "200px",
                    //    //"scrollCollapse": true,
                    //    //"paging": false
                    //});
                });
	            function MinDateManipulation() {
                var e = document.getElementById('<%= DropDownJenisiIzin.ClientID %>');
                //Read the inner text instead of value
                var SelectedVal = e.options[e.selectedIndex].innerText;
                    if (SelectedVal == "Cuti") {
                        return mindt =7;
                    } else {
                        return mindt  =- 5;
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

                  from = $("#<%= TextBox1.ClientID %>").datepicker({
                
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
                  to = $("#<%= TextBox2.ClientID %>").datepicker({
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
	        $("#<%= TextBox3.ClientID %>").datepicker({
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
	           
	        });
	    });
    </script>

    <style>
        /**
         * GRIDVIEW STYLES
         **/
        .gridview {
                font-family:"arial";
                background-color:#FFFFFF;
                width: 100%;
                font-size: small;
        }
        .gridview th {
                background: #7AC142;
                padding: 5px;
                font-size:small;

        }
        .gridview th a{
                color: #003300;
                text-decoration: none;
        }
        .gridview th a:hover{
                color: #003300;
                text-decoration: underline;
        }
        .gridview td  {
                background: #D9EDC9;
                color: #333333;
                font: small "arial";
                padding: 4px;
        }
        .gridview tr.even td {
                background: #FFFFFF;
        }
        .gridview td a{
                color: #003300;
                font: bold small "arial";
                padding: 2px;
                text-decoration: none;
        }
        .gridview td a:hover {
                color: red;
                font-weight: bold;
                text-decoration:underline;     
        } 
    </style>
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

    <style>

       #myTable {
           font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
           border-collapse: collapse;
           width: 100%;
       }

       #myTable td, #myTable th {
           border: 1px solid Silver;
           padding: 8px;
       }

       #myTable tr:nth-child(even){background-color: #f2f2f2;}

       #myTable tr:hover {background-color: #ddd;}

       #myTable th {
          padding-top: 12px;
          padding-bottom: 12px;
          text-align: left;
          background-color: #4CAF50;
          color: white;
       }
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
          background:white;
          color:black;
         
        }
        #table-wrapper table thead th .text {
          position:absolute;   
          top:-20px;
          z-index:2;
          height:20px;
          width:35%;
          border:1px solid black;
        }
    </style>
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
    <!-- jmltglcuti -->
    <asp:Label ID="lbljmltglcuti" style="display:none;" runat="server"></asp:Label>
    <!-- txtNamaAtasan -->
    <asp:Label ID="TxtAtasan1" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="TxtAtasan2" style="display:none;" runat="server"></asp:Label>
    <!-- subjabatanvalue -->
    <asp:Label ID="TxtSubJab" style="display:none;" runat="server"></asp:Label>
    <!-- subjabatan dan departemen -->
    <asp:Label ID="DataSubJabatan" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="DataDepartemen" style="display:none;" runat="server"></asp:Label>
    <asp:Label ID="DataNama" style="display:none;" runat="server"></asp:Label>
    <!-- Nik Atasan2 dari detail staff izin -->
    <asp:Label ID="NikAtasan2DetailIzinStaff" style="display:none;" runat="server"></asp:Label>
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
        
	    <div class="well">  	
	        <div class="container">
		        <center>
			        <h2 style="font-family:Cooper Black;">FORM IZIN</h2>
			    </center>
		    </div>
	        <br /><br />
		    <div class="container">
		        <div class="row">
			        <div class="col-md-12">
			            <div class="row">
						    <div class="col-sm-3 col-md-3 col-lg-3">
						        <div class="box">
					                <div class="aligncenter">								
							            <div class="icon">
								            <center>
                                                <asp:LinkButton ID="LbIzin" runat="server">
                                                    <img class="img-responsive img-center" src="img/absenform.png" height="150" width="150" alt="">
                                                </asp:LinkButton>
								            </center>
									    </div>
								        <h4 style="text-align:center">List Izin</h4>
								    </div>
							    </div>
						    </div>
					        <div class="col-sm-3 col-md-3 col-lg-3">
						        <div class="box">
							        <div class="aligncenter">								
								        <div class="icon">
								            <center>
                                                <asp:LinkButton ID="LblListIzin" runat="server">
                                                    <img class="img-responsive img-center" src="img/absenlist.png" height="150" width="150" alt="">
                                                </asp:LinkButton>
								            </center>
									    </div>
									    <h4 style="text-align:center">Form Izin</h4>
								    </div>
							    </div>
						    </div>
					        <div class="col-sm-3 col-md-3 col-lg-3">
						        <div class="box">
							        <div class="aligncenter">								
								        <div class="icon">
								            <center>
                                                <asp:LinkButton ID="lblHrdFormIzin" runat="server">
                                                    <img class="img-responsive img-center" src="img/hrd_form_izin.png" height="150" width="150" alt="">
                                                </asp:LinkButton>
								            </center>
									    </div>
									    <h4 style="text-align:center">HRD</h4>
								    </div>
							    </div>
						    </div>
					        <div class="col-sm-3 col-md-3 col-lg-3">
						        <div class="box">
							        <div class="aligncenter">								
								        <div class="icon">
								            <center>
                                                <asp:LinkButton ID="lblLihatListIzin" runat="server">
                                                    <img class="img-responsive img-center" src="img/lihatabsen.png" height="150" width="150" alt="">
                                                </asp:LinkButton>
								            </center>
									    </div>
									    <h4 style="text-align:center">Lihat List Izin</h4>
								    </div>
							    </div>
						    </div>
					    </div>
				    </div>
			    </div>
		    </div>
	    </div>

        <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE" ActiveViewIndex="0">
			<asp:View ID="View0102Karyawan" runat="server">
                <div class="container">
                    <center>
                        <%--<h2 style="font-family:Cooper Black;">Form Pengajuan Izin</h2>--%>
                    </center>
                </div><br />
				<h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Data Diri</h3>
				<br />
			    <table class="table table-borderless" align="left">
				    <tr>
				        <td class="col-md-2"><asp:Label ID="Label66" runat="server" Text="NIK"></asp:Label></td>
			            <td class="col-md-4"><asp:Label ID="TxtStaffNIKMaster" runat="server" Text="" class="form-control required"></asp:Label>
                            <asp:TextBox ID="lblNikCounter" visible ="false" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtidizin" runat="server" Visible ="false"></asp:TextBox>
                            <asp:TextBox ID="TxtAppvHead1" visible ="false" runat="server"></asp:TextBox><%--TxtAppvHead--%>
                            <asp:TextBox ID="TxtAppvHead2" visible ="false" runat="server"></asp:TextBox><%--TxtAppvHead2--%>
         
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
				        <td class="col-md-4"><asp:Label ID="lblAtasan" runat="server" Text="" class="form-control required"></asp:Label></td>
					    <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="Atasan dari Atasan Langsung"></asp:Label></td>
					    <td class="col-md-4"><asp:Label ID="lblAtasan2" runat="server" MaxLength="15" Text ="" class="form-control required"></asp:Label></td>
				    
                    </tr>
                    
			    </table><br />

               
            </asp:View>
        </asp:MultiView>
        <br />



<!-- DIV DATA KARYAWAN BESERTA IZIN DAN APRV NYA -->
<%--                    <div class="col-md-6">   
                        <br /><br />
				        <asp:SqlDataSource ID="SqlDataIzin" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
					        SelectCommand="SELECT [IZIN_ID], [IZIN_NAMA], [IZIN_JENIS],[IZIN_APPRVSPV], [IZIN_APPRVMNG], [IZIN_APPRVSPVTGL], [IZIN_APPRVMNGTGL] FROM [DATA_IZIN]"
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				        </asp:SqlDataSource>   
                        <!-- ListView Detali Staff  form Izin-->                                   
				        <asp:ListView ID="LvDetailStaff" runat="server" DataSourceID="SqlDataIzin" DataKeyNames ="IZIN_ID" enableviewstate="false">
					        <LayoutTemplate>
						        <table id="dataTable" class="table table-bordered striped data" align="left">
							        <thead style="background-color:#4877CF">
                                    
								        <th style="text-align:center; color:white">ID Izin</th>
								        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Jenis Izin</th>
                                        <th style="text-align:center; color:white">Approval SPV</th>
                                        <th style="text-align:center; color:white">Approval Manager</th>
								        <th style="text-align:center; color:white">Lihat Detail</th>
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table>
			
					        </LayoutTemplate>
				
					        <ItemTemplate>
						        <tr>
                                    
							        <td style="text-align:center"><%# Eval("IZIN_ID") %></td>
							        <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>
                                    <td><%#Eval("IZIN_APPRVSPV")%><%#Eval("IZIN_APPRVSPVTGL")%></td>
                                    <td><%#Eval("IZIN_APPRVMNG")%><%#Eval("IZIN_APPRVMNGTGL")%></td>
                                    
							        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/detail.png" width="50px" height="50px" /></asp:LinkButton></td>
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					        <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>              
				        </asp:ListView>
				        <br />
                    </div>--%>

        
        <br />
<!-- DIV FORM IZIN -->
<asp:MultiView ID="MultiviewFormIzinDetail" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewFormIzinDetail" runat="server">
   
        <asp:MultiView ID="MultiViewTableListIzin" runat="server">
            <asp:View ID="ViewTabelListIzin1" runat="server">
                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Table Data List Izin </h3>
	            <br />

                        <button id="btnstf" type="button" class="btn btn-secondary" >Staff</button>
                        <button id="btnbwh" type="button" class="btn btn-secondary">Bawahan</button>
                        <div class="tab-content">
                        <div id="staff" class="tab-pane fade in active">
                        <asp:SqlDataSource ID="SqlDataSourceStaff" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
					        SelectCommand="SELECT * FROM [ListIzin] WHERE ([izin_nama] = ?)"
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtStaffNama" Name="izin_nama" PropertyName="Text" Type="String" />
                            </SelectParameters>
				        </asp:SqlDataSource>   
                        <!-- ListView Detali Staff  form Izin-->
                            <br />                                   
				        <asp:ListView ID="LvDetailStaff2" runat="server" DataSourceID="SqlDataSourceStaff"  DataKeyNames ="IZIN_ID" enableviewstate="false">
					        <LayoutTemplate>
						        <table id="dataTable" class="table table-bordered striped data" align="left">
							        <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white">Id Izin</th>                                       
								        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Jenis Izin</th>
								        <th style="text-align:center; color:white">Alasan Izin</th>
                                        <th style="text-align:center; color:white">Tgl Pengajuan</th>
                                        <th style="text-align:center; color:white">Persetujuan Atasan</th>
                                        <th style="text-align:center; color:white">Persetujuan Atasan dari Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Izin Status</th>
                                        <th style="text-align:center; color:white">Detail</th>
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table>
			
					        </LayoutTemplate>
				
					        <ItemTemplate>
						        <tr> 
                                    <td><%#Eval("IZIN_ID")%></td>                                                                   
							        <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>   
                                    <td><%#Eval("IZIN_ALASAN")%></td> 
                                    <td><%#Eval("IZIN_TGLPENGAJUAN", "{0:dd/MM/yyyy}")%></td>
                                    <td>
                                        <p class="small"><%#Eval("IZIN_NIK_APPVSPV")%><br />
                                        <%#Eval("IZIN_TGLAPPVSPV")%></p>
                                    </td>    
                                    <td>
                                        <p class="small"><%#Eval("IZIN_NIK_APPVMNG")%><br />
                                        <%#Eval("IZIN_TGLAPPVMNG")%></p>
                                    </td> 
                                    <td><%#Eval("IZIN_STATUS")%></td>                                
							        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/detail.png" width="50px" height="50px" /></asp:LinkButton></td>
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					        <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>              
				        </asp:ListView>
				        <br />
                        </div>
                        <div id="bawahan" class="tab-pane fade in active">
				        <asp:SqlDataSource ID="SqlDataIzin" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
					        SelectCommand="SELECT * FROM [ListIzin] WHERE (([izin_nik_appvmng] = ?) OR ([izin_nik_appvspv] = ?))"
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtStaffNIKMaster" Name="izin_nik_appvmng" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TxtStaffNIKMaster" Name="izin_nik_appvspv" PropertyName="Text" Type="String" />
                            </SelectParameters>
				        </asp:SqlDataSource>   
                        <!-- ListView Detali Staff  form Izin--> <br />                                  
				        <asp:ListView ID="LvDetailStaff" runat="server" DataSourceID="SqlDataIzin"  DataKeyNames ="IZIN_ID" enableviewstate="false">
					        <LayoutTemplate>
						        <table id="dataTable" class="table table-bordered striped data" align="left">
							        <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white">Id Izin</th>                                       
								        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Jenis Izin</th>
								        <th style="text-align:center; color:white">Alasan Izin</th>
                                        <th style="text-align:center; color:white">Tgl Pengajuan</th>
                                        <th style="text-align:center; color:white">Persetujuan Atasan</th>
                                        <th style="text-align:center; color:white">Persetujuan Atasan dari Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Izin Status</th>
                                        <th style="text-align:center; color:white">Detail</th>
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table>
			
					        </LayoutTemplate>
				
					        <ItemTemplate>
						        <tr> 
                                    <td><%#Eval("IZIN_ID")%></td>                                                                   
							        <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>   
                                    <td><%#Eval("IZIN_ALASAN")%></td> 
                                    <td><%#Eval("IZIN_TGLPENGAJUAN", "{0:dd/MM/yyyy}")%></td>
                                    <td>
                                        <p class="small"><%#Eval("IZIN_NIK_APPVSPV")%><br />
                                        <%#Eval("IZIN_TGLAPPVSPV")%></p>
                                    </td>    
                                    <td>
                                        <p class="small"><%#Eval("IZIN_NIK_APPVMNG")%><br />
                                        <%#Eval("IZIN_TGLAPPVMNG")%></p>
                                    </td> 
                                    <td><%#Eval("IZIN_STATUS")%></td>                                
							        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/detail.png" width="50px" height="50px" /></asp:LinkButton></td>
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					        <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>              
				        </asp:ListView></div>
                        </div>
				        <br />

            </asp:View>
        </asp:MultiView>
 <!-- Table data detail satu karyawan -->

<!-- DIV DATA KARYAWAN BESERTA IZIN DAN APRV NYA -->
        <asp:MultiView ID="MultiViewDetaildanAprrv" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewDetail" runat="server">
                <br /><h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Data Detail Izin Staff</h3><br />
                <table class="table table-borderless" align="left">
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label23" runat="server" Text="Id Izin"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailIdIzin" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                     <tr>
                        <td class="col-md-2">Tanggal Pengajuan </td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailTglPengajuanIzin" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label5" runat="server" Text="NIK"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailNik" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label22" runat="server" Text="Nama"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailNama" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label24" runat="server" Text="Jenis Izin"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="txtDetailJenisIzin" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">Jumlah Pengajuan</td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailJmlPengajuan" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">List Tanggal yang di Ajukan </td>
                        <td class="col-md-4">
                            <table>
                                <tr>

                                    <td >
                                       <asp:Label ID="Label57" runat="server" Text="Memotong Cuti Tahunan" Font-Bold ="true"></asp:Label><br />
                                        <asp:GridView ID="GridViewTglStaff"  runat="server" rowstyle-Height="20px" BorderColor="White" EnableModelValidation="True" HorizontalAlign="Center" ShowHeader="False" Height="100px" Width="100px">
                          
                                            <RowStyle Height="20px" />
                          
                                        </asp:GridView><br />
                                    </td>

                                    <td>
                                        <asp:Label ID="Label58" runat="server" Text="Memotong Cuti Pending" Font-Bold ="true"></asp:Label><br />
                                        <asp:GridView ID="GridViewTglPending" runat="server" rowstyle-Height="20px" BorderColor="White" EnableModelValidation="True" HorizontalAlign="Center" ShowHeader="False" Height="100px" Width="100px">

                                            <RowStyle Height="20px" />

                                        </asp:GridView><br />
                                    </td>
                                </tr>
                            </table>
                            
                            
                            <div id="divtgl1" runat="server">1. <asp:TextBox ID="TxtDetailTglPengajuan1" Visible="true" runat="server" class="form-control required"></asp:TextBox><br /></div>
                            <div id="divtgl2" runat="server">2. <asp:TextBox ID="TxtDetailTglPengajuan2" Visible="true" runat="server" class="form-control required"></asp:TextBox><br /></div>
                            <div id="divtgl3" runat="server">3. <asp:TextBox ID="TxtDetailTglPengajuan3" Visible="true" runat="server" class="form-control required"></asp:TextBox><br /></div>
                            <div id="divtgl4" runat="server">4. <asp:TextBox ID="TxtDetailTglPengajuan4" Visible="true" runat="server" class="form-control required"></asp:TextBox><br /></div>
                            <div id="divtgl5" runat="server">5. <asp:TextBox ID="TxtDetailTglPengajuan5" Visible="true" runat="server" class="form-control required"></asp:TextBox><br /></div>
                            <div id="divtgl6" runat="server">6. <asp:TextBox ID="TxtDetailTglPengajuan6" Visible="true" runat="server" class="form-control required"></asp:TextBox><br /></div>
                            <div id="divtgl7" runat="server">7. <asp:TextBox ID="TxtDetailTglPengajuan7" Visible="true" runat="server" class="form-control required"></asp:TextBox><br /></div>
                            <div id="divtgl8" runat="server">8. <asp:TextBox ID="TxtDetailTglPengajuan8" Visible="true" runat="server" class="form-control required"></asp:TextBox><br /></div>
                            <div id="divtgl9" runat="server">9. <asp:TextBox ID="TxtDetailTglPengajuan9" Visible="true" runat="server" class="form-control required"></asp:TextBox><br /></div>
                            <div id="divtgl10" runat="server">10. <asp:TextBox ID="TxtDetailTglPengajuan10" Visible="true" runat="server" class="form-control required"></asp:TextBox><br /></div>
                            <div id="divtgl11" runat="server">11. <asp:TextBox ID="TxtDetailTglPengajuan11" Visible="true" runat="server" class="form-control required"></asp:TextBox><br /></div>
                            <div id="divtgl12" runat="server">12. <asp:TextBox ID="TxtDetailTglPengajuan12" Visible="true" runat="server" class="form-control required"></asp:TextBox><br /></div>

                        </td><td></td>                    
                    </tr>
                     <tr>
                        <td class="col-md-2">
                            <asp:Label ID="LabelAlasanPengajuan" runat="server" Text="Alasan Pengajuan"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="AlasanCuti" Visible="false" runat="server" class="form-control required"></asp:TextBox>
                            <asp:TextBox ID="TxtDetailAlasanPengajuan" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                     <tr>
                        <td class="col-md-2">
                            <asp:Label ID="LabelDetailAlasanPengajuan2" runat="server" Text="Detail Alasan Pengajuan"></asp:Label></td>
                        <td class="col-md-4">                            
                            <asp:TextBox ID="TxtDetailAlasanPengajuan2" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                     <tr>
                        <td class="col-md-2">Status Pengajuan</td>
                        <td class="col-md-4">                            
                            <asp:TextBox ID="TxtDetailStatusPengajuan" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                     <tr>
                        <td class="col-md-2">Tgl Deadline Approval</td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailDeadline" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                     <tr>
                        <td class="col-md-2"><asp:Label ID="LabelJamPengajuan" runat="server" Text="Izin Jam yang Di Ajukan"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailJamPengajuan" Visible="true" runat="server" class="form-control required" autocomplete="off"></asp:TextBox></td><td></td>
                    </tr>
                     <tr>
                        <td class="col-md-2">Alasan Pembatalan / Persetujuan</td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailAlasanBtlStj" Visible="true" runat="server" class="form-control required" autocomplete="off"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="LabelBuktiSuratSakit" runat="server" Text="Download File Bukti " Visible="false"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:Button ID="BtnDownloadDetailFile"  runat="server" Text="Download File" class="btn btn-primary"/>
                            <asp:TextBox ID="TxtFileName" runat="server" Visible="false"></asp:TextBox>
                        </td><td></td>                        
                    </tr>
                    <tr>
                        <td class="col-md-2"></td>
                        <td class="col-md-4">               
                            <asp:Button ID="BtnSaveDetaildanApproval" visible="False" runat="server" Text="Approve Data" class="btn btn-success" />
                            <asp:Button ID="BtnDeclineDetaildanApproval" Visible="False" runat="server" Text="Decline Data" class="btn btn-danger"/>
                            <asp:Button ID="BtnBackDetaildanApproval" Visible="True" runat="server" Text="Kembali" class="btn btn-primary"/><br />
                            
                        </td><td></td>
                    </tr>
                    </table>
            </asp:View>
        </asp:MultiView>
        <!-- Menu HRD-->
        <!-- menu Hrd Master  -->
        <asp:MultiView ID="MultiViewHRDFormIzinMaster" runat="server" ActiveViewIndex="0">
            <asp:View ID="View4" runat="server">
                                                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Sub Menu HRD</h3>
	            <br />
                        <br /><br />
                <asp:Button ID="BtnOperasiSaldo" runat="server" Text="Operasi Saldo Izin" class="button button6"/>
                <asp:Button ID="BtnPembatalanIzin" runat="server" Text="Pembatalan Izin" class="button button5"/>
                <asp:Button ID="Btnlaporan" runat="server" Text="Laporan Izin" class="button button5"/>
                <asp:Button ID="BtnMenuSales" runat="server" Text="Menu Sales" class="button button1"/>
            </asp:View>
        </asp:MultiView>
        <!-- end menu Hrd Master  -->

        <asp:MultiView ID="MultiViewHRDFormIzin" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Table Data Staff </h3>
	            <br />
				        <asp:SqlDataSource ID="SqlDataStaffHRDFormIzin" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
					        SelectCommand="select data_staff.STAFF_NIK, data_staff.STAFF_NAMA, 
data_staff.STAFF_STATUSKERJAJABATAN, data_staff.STAFF_STATUSKERJADEPT, 
data_staff.STAFF_STATUSKERJALOKASI, data_izin_header.izin_saldo, data_izin_header.izin_saldo_cuti_tahunan_berlaku,
 DATA_IZIN_SALDO_PENDINGCUTI.IZIN_SALDO_PENDINGCUTI, DATA_IZIN_SALDO_PENDINGCUTI.IZIN_SALDO_PENDINGCUTI_BERLAKU,
DATA_IZIN_SALDO_HUTANGCUTI.IZIN_SALDO_HUTANGCUTI, data_izin_header.IZIN_SALDO_CUTI_TAHUNAN_BERLAKU from 
data_staff 
left join data_izin_header on data_staff.staff_nik = 
data_izin_header.izin_nik
left join DATA_IZIN_SALDO_PENDINGCUTI on data_staff.staff_nik = DATA_IZIN_SALDO_PENDINGCUTI .izin_nik
left join DATA_IZIN_SALDO_HUTANGCUTI on data_staff.staff_nik = DATA_IZIN_SALDO_HUTANGCUTI .izin_nik where STAFF_STATUSKERJATGLKELUAR IS  null and STAFF_STATUSKERJAALSKELUAR is  null
"
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				        </asp:SqlDataSource>   
                        <!-- ListView Detali Staff  form Izin-->                                   
				        <asp:ListView ID="ListViewHRDFormIzin" runat="server" DataSourceID="SqlDataStaffHRDFormIzin" DataKeyNames ="STAFF_NIK" enableviewstate="false">
					        <LayoutTemplate>
                                <input id="myInput"  type="text" placeholder="Ketik NIK yang akan di Cari!" class="form-control required" autocomplete="off">
                                <br />  
                                <div id="table-wrapper">
                                  <div id="table-scroll">
						        <table id="myTable" class="search-table inner" align="left" >
							        <thead style="background-color:#4877CF">
                                        <!-- add checkbox -->
                                        <th style="text-align:center; color:black">Check</th>
								        <th style="text-align:center; color:black">NIK</th>
								        <th style="text-align:center; color:black">Nama</th>
                                        <th style="text-align:center; color:black">Jabatan</th>
                                        <th style="text-align:center; color:black">Departemen</th>
                                        <th style="text-align:center; color:black">Lokasi</th>
                                        <th style="text-align:center; color:black">Jumlah Saldo Berjalan</th>
                                        <th style="text-align:center; color:black">Tahun Saldo Berjalan</th>
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table></div>	</div>	
					        </LayoutTemplate>
					        <ItemTemplate>
						        <tr>               
                                    <td >
                                        <asp:CheckBox ID="CheckBox1" runat="server" value='<%# Eval("STAFF_NIK") %>'/>
                                        <!--use a hiddenfield to record the id-->
                                        
                                    </td>
							        <td style="text-align:center" width="30%">
                                        <asp:Label ID="lxl" runat="server" Text='<%# Eval("STAFF_NIK")%>' ></asp:Label>
							        </td>
							        <td style="text-align:center; width="30%" ><%#Eval("STAFF_NAMA")%></td>
                                    <td style="text-align:center; width="10%"><%#Eval("STAFF_STATUSKERJAJABATAN")%></td>
                                    <td style="text-align:center; width="20%"><%#Eval("STAFF_STATUSKERJADEPT")%></td>
                                    <td style="text-align:center; width="10%"><%#Eval("STAFF_STATUSKERJALOKASI")%></td>
                                    <td style="text-align:center; width="10%"><%#Eval("izin_saldo")%></td>
						            <td style="text-align:center; width="10%"><%#Eval("izin_saldo_cuti_tahunan_berlaku", "{0:dd/MM/yyyy}")%></td>
                                </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					        <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>              
				        </asp:ListView>
                        <br />
                        <button id="btnMenu1" type="button" class="btn btn-secondary" >Operasi Saldo Staff Terpilih</button>
                        <button id="btnMenu2" type="button" class="btn btn-secondary">Operasi Saldo Seluruh Staff</button>
                        <br />
                        <div id="menuHrd1" class="tab-pane fade in active" >
                        <br />
		                    <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Operasi Update Saldo Staff Terpilih </h3>
	                    <br />
                        <asp:DropDownList ID="DropDownListHRD_" runat="server" class="form-control required" Width="300px" Visible =" false">
                                <asp:ListItem Value="1">Input Saldo Awal Tahun</asp:ListItem>
                                <asp:ListItem Value="2">Cuti Hari Raya</asp:ListItem>
                                <asp:ListItem Value="3">Cuti Besar</asp:ListItem>
                                <asp:ListItem Value="4">Pending Cuti</asp:ListItem>
                                <asp:ListItem Value="5">Hutang Cuti</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Button  ID="Button1"  visible="true" runat="server" OnClick="Button1_Click" OnClientClick="setValue()"  Text="Get Data" class="btn btn-success"/>
                        <br /></div>
                        <!-- New Add ListView  -->
                        
                        <!-- New Add ListView  -->
                        <div id="menuHrd2" class="tab-pane fade in active" ><br />
                        <div id="SaldoIzinSemua" runat="server"><br />
		                    <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Operasi Update Saldo Seluruh Staff </h3>
	                    <br />
                        <table class="table table-borderless" align="left">
                            <tr>
                                <td class="col-md-2">
                                    <asp:Label ID="Label43" runat="server" Text="Masukan Nominal Saldo : "></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:TextBox ID="TxtSaldoIzinSemua" autocomplete="off" onkeypress="return isNumberKey(event)" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                            </tr>
                            <tr>
                                <td class="col-md-2">
                                    <asp:Label ID="Label44" runat="server" Text="Masukan Tahun :"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:TextBox ID="TxtTahunIzinSemua" autocomplete="off" onkeypress="return isNumberKey(event)" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>              
                            </tr>
                            </table>
                            <br />
                            <asp:Button  ID="BtnSaldoIzinSemua" visible="True" runat="server"  Text="Simpan Data" class="btn btn-success" /></div>
                        </div>
            </asp:View>

        </asp:MultiView>
        <asp:MultiView ID="MultiViewHRDFormIzinDetail" runat="server" ActiveViewIndex="0">
            <asp:View ID="View2" runat="server">
                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Data Detail Staff  </h3>
	            <br />
                <table class="table table-borderless" align="left">
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label25" runat="server" Text="NIK"></asp:Label>
                        </td>
                        <td class="col-md-4">
                            <table>
                                <tr>
                                    <td>
                                        <asp:GridView   ID="GridView2"
                                                        runat="server"
                                                        CssClass="gridview"
                                                        AlternatingRowStyle-CssClass="even" ShowHeader="False"></asp:GridView>
                                    </td>
                                    <td>
                                        <asp:GridView   ID="GridView1"
                                                        runat="server"
                                                        CssClass="gridview"
                                                        AlternatingRowStyle-CssClass="even" ShowHeader="False"></asp:GridView>
                                    </td>
                                </tr>
                            </table>

                            <asp:TextBox ID="TxtHRDFormIzin_NIK" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                        <td class="col-md-2">
                            <asp:Label ID="Label35" runat="server" Text="Saldo Staff Saat Ini"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtHRDFormIzin_SaldoStaffSaatIni" Visible="false" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label26" runat="server" Text="Nama"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtHRDFormIzin_Nama" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label32" runat="server" Text="Pilih Jenis Operasi Saldo "></asp:Label></td>
                        <td class="col-md-4">
                            <asp:DropDownList ID="DDJenisOperasiSaldoCuti" runat="server" class="form-control required" onchange="saldo_berlaku();" >
                                <asp:ListItem Value="1">Input Saldo Awal Tahun</asp:ListItem>
                                <asp:ListItem Value="2">Cuti Hari Raya</asp:ListItem>
                                <asp:ListItem Value="3">Cuti Besar</asp:ListItem>
                                <asp:ListItem Value="4">Pending Cuti</asp:ListItem>
                                <asp:ListItem Value="5">Hutang Cuti</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <div id="RbJenisPending" style="display:none">
                                <p style="color:red">*Pilih Tanggal Akhir Masa Berlaku Pending Cuti</p>
                                <br />
                                <asp:TextBox ID="TextBox3" Visible="true" runat="server" class="form-control required" AutoComplete="off" style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:TextBox>
                                <br />
                                <asp:RadioButtonList ID="RadioButtonListPendingCuti" runat="server" Visible="false">
                                <asp:ListItem Text ="Januari" Value="1" />
                                <asp:ListItem Text ="Februari" Value="2" />
                            </asp:RadioButtonList></div>
                        </td><td></td>
                    </tr>
                    <tr >
                        <td class="col-md-2">
                            <asp:Label ID="Label27" runat="server" Text="Masukan Nominal"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtHRDFormIzin_OperasiSaldo" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr >
                        <td class="col-md-2">
                            <asp:Label ID="Label21" runat="server" Text="Masukan Tahun"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtHRDFormIzinTahun" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                 </table>
                <asp:SqlDataSource ID="SqlDataSourceHistorySaldo" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>" ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>" SelectCommand="SELECT * FROM DATA_IZIN_SALDO WHERE ([nik] = ?) order by id desc">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtHRDFormIzin_NIK" Name="nik" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <div style="display:none"><asp:ListView ID="ListViewHistorySaldo" runat="server"  Visible="true" DataSourceID="SqlDataSourceHistorySaldo">
                    <LayoutTemplate>
                        <div style="width:800px;overflow-x:scroll">
                            <table id="table-a" border="1">
                                <thead style="background-color:#4877CF">
                                    <th style="text-align:center; color:black">ID History</th>
								        <th style="text-align:center; color:black">NIK</th>
                                        <th style="text-align:center; color:black">Nominal Awal</th>
                                        <th style="text-align:center; color:black">Nominal Akhir</th>
                                        <th style="text-align:center; color:black">Keterangan</th>
                                        <th style="text-align:center; color:black">Tanggal</th>    
                                        <th style="text-align:center; color:black">Tahun</th>
                                         
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table>
			            </div>
					        </LayoutTemplate>				
					        <ItemTemplate>
						        <tr>       
                                    <td style="text-align:center"><%# Eval("id") %></td>                            
							        <td style="text-align:center"><%# Eval("nik") %></td>
							        <td><%#Eval("nominal_awal")%></td>
                                    <td><%#Eval("nominal_akhir")%></td>
                                    <td><%#Eval("ket")%></td>
                                    <td><%#Eval("tgl")%></td>
                                    <td><%#Eval("tahun")%></td>						       
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					        <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>  

                </asp:ListView></div>    
                <asp:Button ID="BtnSaveHRDFormIzin" visible="True" runat="server" Text="Simpan Data" class="btn btn-success" /> 
                <asp:Button ID="BtnDownloadHistorySaldo" visible="True" runat="server" Text="Download History Saldo Staff" class="btn btn-danger" /> 
            </asp:View>
        </asp:MultiView>
                <!-- Menu HRD Batal Status -->
        <asp:MultiView ID="MultiViewHRDFormIzinDecline" runat="server" ActiveViewIndex="0">
            <asp:View ID="View3" runat="server">
                                                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Tabel List Izin Approved By Manager</h3>
	            <br />
                        <br /><br />
				        <asp:SqlDataSource ID="SqlDataSourcePembatalanIzinHRD" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
					        SelectCommand="SELECT DATA_IZIN_BODY.IZIN_ID, DATA_IZIN_BODY.IZIN_NIK, DATA_IZIN_BODY.IZIN_ALASAN, DATA_IZIN_BODY.IZIN_JENIS, DATA_IZIN_BODY.IZIN_TGLPENGAJUAN, DATA_IZIN_BODY.IZIN_STATUS, DATA_IZIN_HEADER.IZIN_NAMA, DATA_IZIN_HEADER.IZIN_NIK_APPVSPV, DATA_IZIN_HEADER.IZIN_NIK_APPVMNG,DATA_IZIN_BODY.IZIN_TGLAPPVSPV, DATA_IZIN_BODY.IZIN_TGLAPPVMNG FROM DATA_IZIN_HEADER  JOIN DATA_IZIN_BODY ON DATA_IZIN_HEADER.IZIN_NIK = DATA_IZIN_BODY.IZIN_NIK where IZIN_STATUS ='Disetujui Manajer'"
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				        </asp:SqlDataSource>   
                        <!-- ListView Detali Staff  form Izin-->                                   
				        <asp:ListView ID="ListViewHRDPembatalanIzin" runat="server" DataSourceID="SqlDataSourcePembatalanIzinHRD"  DataKeyNames ="IZIN_ID" enableviewstate="false">
					        <LayoutTemplate>
						        <table id="dataTable" class="table table-bordered striped data" align="left">
							        <thead style="background-color:#4877CF">
                                        <th style="text-align:center; color:white">Id Izin</th>
                                       
								        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Jenis Izin</th>
								        <th style="text-align:center; color:white">Alasan Izin</th>
                                        <th style="text-align:center; color:white">Tgl Pengajuan</th>
                                        <th style="text-align:center; color:white">Persetujuan Atasan</th>
                                        <th style="text-align:center; color:white">Persetujuan Atasan dari Atasan Langsung</th>
                                        <th style="text-align:center; color:white">Izin Status</th>
                                        <th style="text-align:center; color:white">Detail</th>
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table>
			
					        </LayoutTemplate>
				
					        <ItemTemplate>
						        <tr> 
                                    <td><%#Eval("IZIN_ID")%></td>                                                                   
							        <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>   
                                    <td><%#Eval("IZIN_ALASAN")%></td> 
                                    <td><%#Eval("IZIN_TGLPENGAJUAN")%></td>
                                    <td>
                                        <p class="small"><%#Eval("IZIN_NIK_APPVSPV")%><br />
                                        <%#Eval("IZIN_TGLAPPVSPV")%></p>
                                    </td>    
                                    <td>
                                        <p class="small"><%#Eval("IZIN_NIK_APPVMNG")%><br />
                                        <%#Eval("IZIN_TGLAPPVMNG")%></p>
                                    </td> 
                                    <td><%#Eval("IZIN_STATUS")%></td>                                
							        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="img/detail.png" width="50px" height="50px" /></asp:LinkButton></td>
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					        <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>              
				        </asp:ListView>
				        <br />
            </asp:View>
        </asp:MultiView>
        <!-- end menu HRD  Batal Status-->
        <asp:MultiView ID="MultiViewHRDFormIzinDetail2" runat="server" ActiveViewIndex="0">
            <asp:View ID="View5" runat="server">
                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Detail Staff Cancel Izin </h3>
	            <br />
                <table class="table table-borderless" align="left">
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label33" runat="server" Text="Id Izin"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailStaffCancelIdIzin" Visible="true" runat="server" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2">
                            <asp:Label ID="Label60" runat="server" Text="Tanggal Pengajuan Memotong Cuti Tahunan"></asp:Label></td>
                        <td class="col-md-4"><asp:GridView ID="GridViewCancel" runat="server" EnableModelValidation="True" GridLines="None" Height="100px" ShowHeader="False" Width="100px" BorderStyle="None"></asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label14" runat="server" Text="NIK"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailStaffCancelNIK" Visible="true" runat="server" class="form-control required"></asp:TextBox></td>
                       <td class="col-md-2">
                           <asp:Label ID="Label59" runat="server" Text="Tanggal Pengajuan Memotong Cuti Pending"></asp:Label></td>
                        <td class="col-md-4"><asp:GridView ID="GridViewCancelPend" runat="server" GridLines="None" Height="100px" ShowHeader="False" Width="100px" BorderStyle="None" EnableModelValidation="True"></asp:GridView></td>
                    </tr>
                    <!-- Tanggal Keseluruhan -->
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label28" runat="server" Text="Nama"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailStaffCancelNama" Visible="true" runat="server" class="form-control required"></asp:TextBox></td>
                        <td class="col-md-2">
                           <asp:Label ID="Label64" runat="server" Text="Tanggal Pengajuan Keseluruhan"></asp:Label></td>                       
                        <td class="col-md-4">
                            <!-- Penambahan Code Baru -->
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr >
                        <td class="col-md-2">
                            <asp:Label ID="Label30" runat="server" Text="Jenis Izin"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailStaffCancelJenisIzin" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr >
                        <td class="col-md-2">
                            <asp:Label ID="Label31" runat="server" Text="Tanggal Pengajuan"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtDetailStaffCancelTglPengajuan" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr >
                        <td class="col-md-2">
                            <asp:Label ID="Label34" runat="server" Text="Izin Status"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="txtDetailStaffCancelIzinStatus" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                            <asp:TextBox ID="TxtDetailStaffCancelJmlPengajuan" Visible="false" runat="server" class="form-control required"></asp:TextBox>    
                       
                    </tr>
                 </table>
                <table >
                    <tr>
                        <asp:Label ID="Label61" runat="server" Visible="false" Text="Label" ForeColor="Red" >Data Izin Ini Sudah Anda Batalkan. Tidak Memiliki Tanggal Pengajuan </asp:Label>
                        <td>
                            <asp:Button ID="BtnDetailStaffHRDCancel" visible="True" runat="server" Text="Cancel Data Izin" class="btn btn-danger" /> 
                            <br />
                        </td>
                        <td>
                            <asp:Button ID="BtnDetailStaffHRDCancelTahunan" visible="false" runat="server" Text="Cancel Data Pengajuan Tahunan" class="btn btn-danger" /> 
                            <br />
                        </td>
                        <td>
                            <asp:Button ID="BtnDetailStaffHRDCancelPending" visible="false" runat="server" Text="Cancel Data Pengajuan Pending" class="btn btn-danger" /> 
                            <br />
                        </td>
                        <td>
                            <asp:Button ID="Button2" runat="server" Text="Batalkan Tanggal Terpilih" visible="false" class="btn btn-danger"/>
                            <br />
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
        <!-- end Menu HRD -->

        <!-- menu laporan izin HRD -->

        <asp:MultiView ID="MultiViewHRDFormIzinLaporan"  runat="server" ActiveViewIndex="0">
            <asp:View ID="View6" runat="server">
             <br /><h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Laporan Data Izin Staff</h3><br />                
                
                        <table class="table table-borderless" align="left">
                            <tr>
                                <td class="col-md-2">
                                    <asp:Label ID="Label52" runat="server" Text="Masukan Tanggal Pencarian"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:TextBox ID="TxtTglCariIzin3" Visible="true" runat="server" class="form-control required" autocomplete="off"></asp:TextBox><br /></td>
                                <td class="col-md-2">
                                    <asp:Label ID="Label53" runat="server" Text="Sampai Dengan"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:TextBox ID="TxtTglCariIzin4" Visible="true" runat="server" class="form-control required" autocomplete="off"></asp:TextBox><br /></td>
                            </tr>

                            <tr>
                                <td class="col-md-2">
                                    <asp:Button ID="BtnCariLaporanIzin" runat="server" Text="Cari Data" class="btn btn-primary"/></td>
                            </tr></table>                  
                <asp:Button ID="BtnFormIzinHRDLaporanIzin" visible="True" runat="server" Text="Download Laporan" class="btn btn-success" /><br /><br />
				* Data Laporan Berupa List Izin Detail (By ID Izin) berulang sesuai dengan banyak nya tgl pengajuan izin
                <div style="display:none"><%--style="display:none"   --%>  
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
					        SelectCommand="SELECT data_izin_body.izin_id,data_izin_header.izin_nik, data_izin_header.izin_nama, data_izin_body.izin_jenis, data_izin_detail.izin_tgldetail, data_izin_body.izin_alasan
,data_izin_body.izin_jenis, data_izin_body.izin_tglpengajuan,data_izin_detail.izin_tgldetail,data_izin_body.izin_blnpengajuan, data_izin_body.izin_thnpengajuan, data_izin_body.izin_status, data_izin_header.izin_nik_appvspv, data_izin_header.izin_nik_appvmng,
data_izin_body.izin_tglappvspv, data_izin_body.izin_tglappvmng
FROM data_izin_header  
INNER JOIN data_izin_body  on data_izin_body.izin_nik = data_izin_header.izin_nik
INNER JOIN data_izin_detail  on data_izin_detail.izin_id= data_izin_body.izin_id
WHERE  ([izin_tgldetail] between ? and ?)"
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtTglCariIzin3" Name="izin_tgldetail" PropertyName="Text" Type="DateTime" />
                                <asp:ControlParameter ControlID="TxtTglCariIzin4" Name="izin_tgldetail" PropertyName="Text" Type="DateTime" />
                            </SelectParameters>
                </asp:SqlDataSource>   
                <asp:ListView ID="ListViewIzinLaporan" runat="server"  Visible="true" DataSourceID="SqlDataSource1">
                    <LayoutTemplate>
                        <div style="width:800px;overflow-x:scroll">
                            <table id="table-a" border="1">
                                <thead style="background-color:#4877CF">
								        <th style="text-align:center; color:black">ID Izin</th>
								        <th style="text-align:center; color:black">NIK</th>
                                        <th style="text-align:center; color:black">Nama</th>
                                        <th style="text-align:center; color:black">Jenis Izin</th>
                                        <th style="text-align:center; color:black">Alasan </th>
                                        <th style="text-align:center; color:black">Tgl Pengajuan</th>
                                        <th style="text-align:center; color:black">Tgl Detail Pengajuan</th>    
                                        <th style="text-align:center; color:black">Bln Pengajuan</th>
                                        <th style="text-align:center; color:black">Tahun Pengajuan</th>
                                        <th style="text-align:center; color:black">NIK Approval Atasan1</th>
                                        <th style="text-align:center; color:black">NIK Approval Atasan2</th>
                                        <th style="text-align:center; color:black">Tgl Approval Atasan1</th>
                                        <th style="text-align:center; color:black">Tgl Approval Atasan2</th>
                                        <th style="text-align:center; color:black">Status Izin</th>                                           
							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table>
			            </div>
					        </LayoutTemplate>				
					        <ItemTemplate>
						        <tr>                                   
							        <td style="text-align:center"><%# Eval("IZIN_ID") %></td>
							        <td><%#Eval("IZIN_NIK")%></td>
                                    <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>
                                    <td><%#Eval("IZIN_ALASAN")%></td>
                                    <td><%#Eval("IZIN_TGLPENGAJUAN")%></td>
                                    <td><%#Eval("IZIN_TGLDETAIL")%></td>
                                    <td><%#Eval("IZIN_BLNPENGAJUAN")%></td>
                                    <td><%#Eval("IZIN_THNPENGAJUAN")%></td>
                                    <td><%#Eval("IZIN_NIK_APPVSPV")%></td>
                                    <td><%#Eval("IZIN_NIK_APPVMNG")%></td>
                                    <td><%#Eval("IZIN_TGLAPPVSPV")%></td>
                                    <td><%#Eval("IZIN_TGLAPPVMNG")%></td>
                                    <td><%#Eval("IZIN_STATUS")%></td>							       
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>Data Izin Karyawan Tidak diketemukan</EmptyDataTemplate> 
					        <EmptyItemTemplate>Data Izin Karyawan Tidak diketemukan</EmptyItemTemplate>  

                </asp:ListView>                
                </div>
            </asp:View>
        </asp:MultiView>
        <!-- end menu laporan izin HRD -->

        <asp:MultiView ID="MultiViewDDJenisIzin" runat="server" ActiveViewIndex ="0">
            <asp:View ID="ViewDDJenisIzin" runat="server">
                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Data Izin</h3>
	            <br />
            <table class="table table-borderless" align="left">
                <tr>
                    <td class="col-md-2">
                        <asp:Label ID="Label3" runat="server" Text="Jenis Izin"></asp:Label></td>
                    <td class="col-md-4">
                        <asp:DropDownList ID="DropDownJenisiIzin" Visible="true" runat="server"  class="form-control required" AutoPostBack="True">
                            <asp:ListItem Value="0">Cuti</asp:ListItem>
                            <asp:ListItem Value="1">Tidak Masuk Kantor</asp:ListItem>
                            <asp:ListItem Value="2">Izin Terlambat</asp:ListItem>
                            <asp:ListItem Value="3">Izin Keluar Kantor</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="TxtJenisIzin" Visible ="false" runat="server" MaxLength="1"  class="form-control required" ValidationGroup="MKE"></asp:TextBox>
                        <br />
                    </td><td></td><td></td>
                </tr>
            </table>
             </asp:View>
        </asp:MultiView>

        <asp:MultiView ID="MultiViewNilaiStandardEntry" runat="server" Visible="TRUE" ActiveViewIndex="0">
            <asp:View ID="ViewCuti" runat="server">
                <br /><h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span>
                    <asp:Label ID="LabelCuti" runat="server" Text="Cuti"></asp:Label><asp:Label ID="LabelTidakMasuk" runat="server" Text="Tidak Masuk Kantor"></asp:Label></h3><br />
                <table class="table table-borderless" align="left">
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label15" runat="server" Text="NIK"></asp:Label>
                        <td class="col-md-4">
                            <asp:TextBox ID="lblNIKDetail" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label16" runat="server" Text="Nama"></asp:Label>
                        <td class="col-md-4">
                            <asp:TextBox ID="lblNamaDetail" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2"><br />
                            <asp:Label ID="Label7" runat="server" Text="Tanggal Pengajuan"></asp:Label></td>
                        <td class="col-md-4">
                            <table>
                                <tr>
                                    <td><br /></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2">
                                        <asp:TextBox ID="TextBox1" Visible="true" runat="server" class="form-control required" AutoComplete="off" style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:TextBox>
                                    </td>
                                    <td>
                                        Hingga
                                    </td>
                                    <td class="col-md-4">
                                        <asp:TextBox ID="TextBox2" Visible="true" runat="server" class="form-control required" AutoComplete="off" style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                              <br />
                            
  
                            <asp:TextBox ID="jmltglcuti" runat="server" Visible="true" style="display:none"></asp:TextBox><br />
                            <div id="dvtgl1" style="display: none">1. 
                                <asp:TextBox  ID="TxtTglCuti1"   runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:TextBox><br /><br /></div>                            
                            <div id="dvtgl2" style="display: none">2. 
                                <asp:TextBox  ID="TxtTglCuti2"   runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl3" style="display: none">3. <asp:TextBox ID="TxtTglCuti3" runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl4" style="display: none">4. <asp:TextBox ID="TxtTglCuti4"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl5" style="display: none">5. <asp:TextBox ID="TxtTglCuti5"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl6" style="display: none">6. <asp:TextBox ID="TxtTglCuti6"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl7" style="display: none">7. <asp:TextBox ID="TxtTglCuti7"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl8" style="display: none">8. <asp:TextBox ID="TxtTglCuti8"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl9" style="display: none">9. <asp:TextBox ID="TxtTglCuti9"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl10" style="display: none">10. <asp:TextBox ID="TxtTglCuti10"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl11" style="display: none">11. <asp:TextBox ID="TxtTglCuti11" runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl12" style="display: none">12. <asp:TextBox ID="TxtTglCuti12"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>


                            <asp:LinkButton ID="LinkButton1"  Visible ="false" runat="server" CssClass="btn btn-default" CausesValidation="False">
							<span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
						    </asp:LinkButton>                             
                        </td><td></td>                 
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label4" runat="server" Text="Tahun Pengajuan"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtBulanCuti" runat="server" style ="display:none"></asp:TextBox>
                            <asp:TextBox ID="TxtTahunCuti" runat="server" ReadOnly="true" class="form-control required" ></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label36" runat="server" Text="Email Staff"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtEmailStaff" runat="server" class="form-control required" ></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label37" runat="server" Text="Saldo Izin"></asp:Label></td>
                        <td class="col-md-4">
                            <table>
                                <tr>
                                    <td >
                                        <asp:TextBox ID="TxtSaldoCuti" runat="server" class="form-control required"></asp:TextBox>
                                    </td>
                                    <td >/ </td>
                                    <td >
                                        <asp:TextBox ID="txtSaldoCutiBerlaku" runat="server" class="form-control required"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            
                            
                        </td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label55" runat="server" Text="Saldo Pending" Visible="true"></asp:Label></td>
                        <td class="col-md-4">
                            <table>
                                <tr>
                                    <td >
                                        <asp:TextBox ID="TxtSaldoPending" runat="server" class="form-control required" Visible="true" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td ><asp:Label ID="Label56" runat="server" Text=" / " Visible="true"></asp:Label></td>
                                    <td >
                                        <asp:TextBox ID="TxtSaldoPendingBerlaku" runat="server" class="form-control required" Visible="true" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            
                            
                        </td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label6" runat="server" Text="Alasan Pengajuan"></asp:Label></td>
                        <td class="col-md-4">
                            <div style=""><asp:DropDownList ID="DropDownListCuti"  runat="server"  class="form-control required">
                                <asp:ListItem Value="Cuti">Cuti</asp:ListItem>
                                <asp:ListItem Value="Cuti2">Cuti Melahirkan</asp:ListItem>
                                <asp:ListItem Value="Cuti3">Cuti Istimewa -- Menikah</asp:ListItem>
                                <asp:ListItem Value="Cuti4">Cuti Istimewa -- Orang Tua / Mertua Meninggal </asp:ListItem>
                                <asp:ListItem Value="Cuti5">Cuti Istimewa -- Bencana Alam</asp:ListItem>
                                <asp:ListItem Value="Cuti6">Cuti Istimewa -- Keluarga Meninggal SeAtap</asp:ListItem>
                                <asp:ListItem Value="Cuti7">Cuti Istimewa -- Khitanan / Baptisan Anak</asp:ListItem>
                                <asp:ListItem Value="Cuti8">Cuti Istimewa -- Pernikahan Anak</asp:ListItem>
                                

                            </asp:DropDownList></div>
                            <div><asp:DropDownList ID="DropDownListTidakMasuk" runat="server" class="form-control required" onchange="DDUpload()">
                                <asp:ListItem Value="Sakit Surat Dokter">Sakit Surat Dokter</asp:ListItem>
                                <asp:ListItem Value="Sakit Potong Gaji">Sakit Potong Gaji</asp:ListItem>
                                <asp:ListItem Value="Izin Potong Gaji">Izin Potong Gaji</asp:ListItem>
                                <asp:ListItem Value="Izin Potong Cuti">Izin Potong Cuti</asp:ListItem>
                                <asp:ListItem Value="Sakit Potong Cuti">Sakit Potong Cuti</asp:ListItem>
                                <asp:ListItem Value="Sakit Potong Gaji">Sakit Potong Gaji</asp:ListItem>
                            </asp:DropDownList></div>
                            <asp:TextBox ID="TxtAlasanIzin" Visible ="false" runat="server" MaxLength="1"  class="form-control required" ValidationGroup="MKE"></asp:TextBox>
                        </td>                        
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label45" runat="server" Text="Alasan Detail"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="TxtAlasanIzinDetail" MaxLength="50" autocomplete="off" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
					<tr> 
                        <td class="col-md-2">
                            <div id="UploadFileLabel"><asp:Label ID="Label47" runat="server" Text="Upload File"></asp:Label></div></td>
						<td class="col-md-4">
                            <asp:Label ID="AlertFileGambar" runat="server" Text="*Maksimal File Gambar 1 Mb" ForeColor="Red"></asp:Label>
							<div id="UploadFile" runat="server"><asp:FileUpload ID="FileUpload1"  runat="server" accept="image/*" multiple="false" BorderStyle="None" />
							<asp:RegularExpressionValidator ID="FileTypeValidator"  runat="server" ErrorMessage="File type not allowed: Accept JPG file type only" ValidationExpression="(.*png$)|(.*jpg$)|(.*jpeg$)" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator><br />
							</div>
						</td>
					</tr>
                </table>
                <!--TabelFormCuti-->
                <asp:Label ID="LblErrorSaveCuti" runat="server" Text="" style="color:red"></asp:Label>

                    
                    <asp:Button ID="BtnSaveCuti" visible="True" OnClientClick="return userValid()" runat="server" Text="Simpan Data" class="btn btn-success" /> 
                    
                    <asp:Button ID="BtnClear" Visible="false" runat="server" Text="Kembali" class="btn btn-primary"/>
               
            </asp:View>
            <asp:View ID="ViewTidakMasuk" runat="server">
                <br /><h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Izin Tidak Masuk Kantor</h3><br />
                <table class="table table-borderless" align="left">
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label17" runat="server" Text="NIK"></asp:Label>
                        <td class="col-md-4">
                            <asp:TextBox ID="lblNikTdkMasuk" Visible="true" runat="server" class="form-control required"></asp:TextBox></td>
                    </tr>
                    <tr>
                                                <td class="col-md-2">
                            <asp:Label ID="Label18" runat="server" Text="Nama"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="lblNamaTdkMasuk" Visible="true" runat="server" class="form-control required"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label10" runat="server" Text="Jumlah Pengajuan Tidak Masuk"></asp:Label></td>
                        <td class="col-md-4">
                            <select name="DDJmlTglTidakMasuk" id="DropDownListJmlTidakMasuk" class="form-control required">
                                <option value="0">Pilih Jumlah Tanggal Pengajuan</option>
                                <option value="1" data-id="1">1</option>
                                <%--<option value="1">1</option>--%>
                                <option value="2" data-id="2">2</option>
                                <option value="3" data-id="3">3</option>
                                <option value="4" data-id="4">4</option>
                                <option value="5" data-id="5">5</option>
                                <option value="6" data-id="6">6</option>
                                <option value="7" data-id="7">7</option>
                                <option value="8" data-id="8">8</option>
                                <option value="9" data-id="9">9</option>
                                <option value="10" data-id="10">10</option>
                                <option value="11" data-id="11">11</option>
                                <option value="12" data-id="12">12</option>
                            </select>
  
                            <asp:TextBox ID="jmltglTidakMasuk" runat="server" Visible="true" style="display:none"></asp:TextBox><br />
                            <div id="dvtgl1t" style="display: none">1. 
                                <asp:TextBox  ID="TxtTglTidakMasuk1"   runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE"></asp:TextBox><br /><br /></div>                            
                            <div id="dvtgl2t" style="display: none">2. 
                                <asp:TextBox  ID="TxtTglTidakMasuk2"   runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl3t" style="display: none">3. <asp:TextBox ID="TxtTglTidakMasuk3" runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl4t" style="display: none">4. <asp:TextBox ID="TxtTglTidakMasuk4"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl5t" style="display: none">5. <asp:TextBox ID="TxtTglTidakMasuk5"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl6t" style="display: none">6. <asp:TextBox ID="TxtTglTidakMasuk6"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl7t" style="display: none">7. <asp:TextBox ID="TxtTglTidakMasuk7"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl8t" style="display: none">8. <asp:TextBox ID="TxtTglTidakMasuk8"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl9t" style="display: none">9. <asp:TextBox ID="TxtTglTidakMasuk9"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl10t" style="display: none">10. <asp:TextBox ID="TxtTglTidakMasuk10"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl11t" style="display: none">11. <asp:TextBox ID="TxtTglTidakMasuk11" runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                            <div id="dvtgl12t" style="display: none">12. <asp:TextBox ID="TxtTglTidakMasuk12"  runat="server" MaxLength="1"  style="width: 140px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>


                            <asp:LinkButton ID="LinkButton2"  Visible ="false" runat="server" CssClass="btn btn-default" CausesValidation="False">
							<span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
						    </asp:LinkButton>                             
                        </td><td></td>                 
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label11" runat="server" Text="Alasan Tidak Masuk"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:DropDownList ID="DropDownAlasanTidakMasuk" runat="server"  class="form-control required">
                                <asp:ListItem Value="0">Sakit Surat Dokter</asp:ListItem>
                                <asp:ListItem Value="1">Sakit Potong Gaji</asp:ListItem>
                                <asp:ListItem Value="2">Izin Potong Gaji</asp:ListItem>
                                <asp:ListItem Value="3">Izin Potong Cuti</asp:ListItem>
                                <asp:ListItem Value="4">Sakit Potong Cuti</asp:ListItem>
                            </asp:DropDownList></td>
                        <td class="col-md-2"></td>
                        <td class="col-md-4"></td>
                   </tr>
                    <tr>
                        <td class="col-md-2"></td>
                        <td class="col-md-4"></td>
                        <td class="col-md-2"></td>
                        <td class="col-md-4"></td>
                   </tr>
                </table>
                <asp:Button ID="BtnSaveIzinTidakMasuk" visible="true" runat="server" Text="Simpan Data" class="btn btn-success" />
            </asp:View>
            <asp:View ID="ViewIzinSiang" runat="server">
                <br /><h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Izin Datang Siang</h3><br />
            </asp:View>
            <asp:View ID="ViewIzinPulang" runat="server">
                <br /><h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span>
                    <asp:Label ID="LabelDatangSiang" runat="server" Text="Izin Terlambat"></asp:Label>
                    <asp:Label ID="LabelPulangCepat" runat="server" Text="Izin Keluar Kantor"></asp:Label>
                      </h3><br />

                <table class="table table-borderless" align="left">

                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label19" runat="server" Text="NIK"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="lblNikPlgCepat" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label20" runat="server" Text="Nama"></asp:Label></td>
                        <td class="col-md-4">
                            <asp:TextBox ID="lblNamaPlgCepat" Visible="true" runat="server" class="form-control required"></asp:TextBox></td><td></td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label12" runat="server" Text="Tanggal Izin Keluar Kantor" ></asp:Label>
                            <asp:Label ID="Label40" runat="server" Text="Tanggal Izin Terlambat" ></asp:Label>
                        </td>
					    <td class="col-md-4">
                            <asp:TextBox ID="TxtIzinPulangCepat"  autocomplete="off" runat="server" MaxLength="1" style="padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />
				            <asp:TextBox ID="TxtIzinDatangTelat"  autocomplete="off" runat="server" MaxLength="1" style="padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />
                        </td>
                   </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label39" runat="server" Text="Pilih Waktu" ></asp:Label>
                            <asp:Label ID="Label41" runat="server" Text="Pilih Waktu" ></asp:Label>
                        </td>
					    <td class="col-md-4">
                            <asp:TextBox ID="TxtIzinPulangCepatJam"  autocomplete="off" runat="server" MaxLength="1" style="padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" /> 
				            <asp:TextBox ID="TxtIzinDatangTelatJam"  autocomplete="off" runat="server" MaxLength="1" style="padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />
                        </td>
                   </tr>
                    <tr>
                        <td>
                            
                        </td>
                        <td>
                            <asp:Label ID="LabelAlertIzinTerlambat" runat="server"  ForeColor="Red"></asp:Label>
                            <asp:Label ID="LabelAlertIzinKeluarKantor" runat="server"  ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label13" runat="server" Text="Alasan Keluar Kantor"></asp:Label>
                            <asp:Label ID="Label42" runat="server" Text="Alasan Terlambat"></asp:Label>
                        </td>
                        <td class="col-md-4">
<%--                            <div id ="alasankeluarkantor" runat="server"><select  id="DropDownList1" class="form-control required">
                                <option value="0">Pilih Alasan</option>
                                <option value="1">Ke Customer</option>
                                <option value="2" >Ke Pameran</option>
                                <option value="3" >Lain-Lain</option>
                            </select></div>--%>
<%--                            <asp:DropDownList ID="DropDownList1" runat="server"  class="form-control required" >
                                <asp:ListItem Value="0">Ke Customer</asp:ListItem>
                                <asp:ListItem Value="1">Ke Pameran</asp:ListItem>
                                <asp:ListItem Value="2">Lain-Lain</asp:ListItem>
                            </asp:DropDownList>--%>
                            <asp:TextBox ID="TxtAlasanIzinPulangCepat"    MaxLength="50" autocomplete="off" runat="server" class="form-control required"></asp:TextBox><br />
                            <div id="dvtPulangCepat" style="display:none"> <br /><asp:Label ID="Label46" runat="server" Text="Isi Alasan Detail Anda"></asp:Label><br /><br /><asp:TextBox ID="TxtIzinPulangCepatAlasan"  runat="server" AutoComplete="off"  style="width: 200px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px; " ValidationGroup="MKE"></asp:TextBox><br /><br /></div>
                        </td>
                   </tr>
					<tr> 
                        <td class="col-md-2">
                            <div id="UploadFileLabelTerlambat" runat="server"><asp:Label ID="Label54" runat="server" Text="Upload File"></asp:Label></div></td>
						<td class="col-md-4">
                            <asp:Label ID="LblNoteTerlambat" runat="server" Text="*Maksimal File Gambar 1 Mb" ForeColor="Red"></asp:Label>
							<div id="DivTerlambat" runat="server"><asp:FileUpload ID="FileUploadTerlambat" runat="server" accept="image/*" multiple="false" BorderStyle="None"/>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator1"  runat="server" ErrorMessage="File type not allowed: Accept JPG file type only" ValidationExpression="(.*png$)|(.*jpg$)|(.*jpeg$)" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator><br />
							</div>
						</td>
					</tr>
<%--                    <tr>
                        <td class="col-md-2">
                            <asp:Label ID="Label40" runat="server" Text="Alasan"></asp:Label></td>
                        <td class="col-md-4">
                         
                        </td>
                    </tr>--%>
                </table>
                <asp:Button ID="BtnSaveIzinDatangTelatPulangCepat" OnClientClick="return alasanTelatdanTerlambat()" visible="true" runat="server" Text="Simpan Data" class="btn btn-success" />
            </asp:View>
        </asp:MultiView>   
        <!-- Multiview lihat list izin -->
        <asp:MultiView ID="MultiViewLihatListIzin" runat="server" ActiveViewIndex="0" Visible="true">
            <asp:View ID="ViewLihatListIzin" runat="server">
                <asp:SqlDataSource ID="SqlDataSourceLihatListIzin" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
					        SelectCommand="SELECT * FROM [lihatizin] WHERE  ([izin_tgldetail] between ? and ?) "
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtTglCariIzin" Name="izin_tgldetail" PropertyName="Text" Type="DateTime" />
                                <asp:ControlParameter ControlID="TxtTglCariIzin2" Name="izin_tgldetail" PropertyName="Text" Type="DateTime" />
                            </SelectParameters>
				        </asp:SqlDataSource>   
                        <!-- ListView Detali Staff  form Izin--> <br /> 
                <br />
		            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> Pencarian List Izin </h3>
	            <br />
                        <table class="table table-borderless" align="left">
                            <tr>
                                <td class="col-md-2">
                                    <asp:Label ID="Label38" runat="server" Text="Masukan Tanggal Pencarian"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:TextBox ID="TxtTglCariIzin" Visible="true" runat="server" class="form-control required" autocomplete="off"></asp:TextBox><br /></td>
                                <td class="col-md-2">
                                    <asp:Label ID="Label48" runat="server" Text="Sampai Dengan"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:TextBox ID="TxtTglCariIzin2" Visible="true" runat="server" class="form-control required" autocomplete="off"></asp:TextBox><br /></td>
                            </tr>

                            <tr>
                                <td class="col-md-2">
                                    <asp:Button ID="BtnCariLihatListIzin" runat="server" Text="Cari Data" class="btn btn-primary"/></td>
                            </tr>
<%--                            <tr>
                                <td class="col-md-2">
                                    <asp:Button ID="BtnCetakCariList" runat="server" Text="Cetak" class="btn btn-primary"/></td>
                            </tr>--%>
                       </table><br /><br /><br />
                            <asp:Label ID="Label49" runat="server" Text="*Informasi : Pencarian wajib mengisi kedua tanggal pencarian."></asp:Label><br />
                            <asp:Label ID="Label50" runat="server" Text="*Informasi : Isi Kedua tanggal dengan nilai yang sama ketika ingin melakukan pencarian hanya 1 hari saja"></asp:Label>
                         <br /><asp:Label ID="Label63" runat="server" Text="Table Pengajuan Cuti Tahunan"></asp:Label>                             
				        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSourceLihatListIzin"  DataKeyNames ="IZIN_ID"  enableviewstate="false">
					        <LayoutTemplate>
						        <table id="dataTable" class="table table-bordered striped data" align="left">
							        <thead style="background-color:#4877CF">     
                                        <th style="text-align:center; color:white">Id Izin</th>                                 
								        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Jenis Izin</th>
								        <th style="text-align:center; color:white">Alasan Izin</th>
                                        <th style="text-align:center; color:white">Tgl Pengajuan</th>
                                        <th style="text-align:center; color:white">Izin Status</th>
                                        <th style="text-align:center; color:white">Download Detail</th>

							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table>
			
					        </LayoutTemplate>
				
					        <ItemTemplate>
						        <tr>     
                                    <td><%#Eval("IZIN_ID")%></td>                                                               
							        <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>   
                                    <td><%#Eval("IZIN_ALASAN")%></td> 
                                    <td><%#Eval("IZIN_TGLDETAIL")%></td>
                                    <td><%#Eval("IZIN_STATUS")%></td>                                
							        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='Download' CommandName="Select" runat="server" ><img src="img/detail.png" width="50px" height="50px" /></asp:LinkButton></td>
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>
                                <br /><br /><asp:Label ID="Label51" runat="server" Text="Data Izin Karyawan Tidak diketemukan" ForeColor="Red"></asp:Label>
					        </EmptyDataTemplate> 
                           
                                          
				        </asp:ListView>
                        <asp:SqlDataSource ID="SqlDataSourceLihatListIzin2" runat="server"
					        ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
					        SelectCommand="SELECT * FROM [lihatizin2] WHERE  ([izin_tgldetail] between ? and ?) "
					        ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
				            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtTglCariIzin" Name="izin_tgldetail" PropertyName="Text" Type="DateTime" />
                                <asp:ControlParameter ControlID="TxtTglCariIzin2" Name="izin_tgldetail" PropertyName="Text" Type="DateTime" />
                            </SelectParameters>
				        </asp:SqlDataSource>  
                <asp:Label ID="Label62" runat="server" Text="Table Pengajuan Pending Cuti"></asp:Label>
                		<asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSourceLihatListIzin2"  DataKeyNames ="IZIN_ID"  enableviewstate="false">
					        <LayoutTemplate>
						        <table id="dataTable" class="table table-bordered striped data" align="left">
							        <thead style="background-color:#4877CF">     
                                        <th style="text-align:center; color:white">Id Izin</th>                                 
								        <th style="text-align:center; color:white">Nama</th>
                                        <th style="text-align:center; color:white">Jenis Izin</th>
								        <th style="text-align:center; color:white">Alasan Izin</th>
                                        <th style="text-align:center; color:white">Tgl Pengajuan</th>
                                        <th style="text-align:center; color:white">Izin Status</th>
                                        <th style="text-align:center; color:white">Download Detail</th>

							        </thead>
							        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
						        </table>
			
					        </LayoutTemplate>
				
					        <ItemTemplate>
						        <tr>     
                                    <td><%#Eval("IZIN_ID")%></td>                                                               
							        <td><%#Eval("IZIN_NAMA")%></td>
                                    <td><%#Eval("IZIN_JENIS")%></td>   
                                    <td><%#Eval("IZIN_ALASAN")%></td> 
                                    <td><%#Eval("IZIN_TGLDETAIL")%></td>
                                    <td><%#Eval("IZIN_STATUS")%></td>                                
							        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='Download' CommandName="Select" runat="server" ><img src="img/detail.png" width="50px" height="50px" /></asp:LinkButton></td>
						        </tr>
					        </ItemTemplate>
					        <EmptyDataTemplate>
                                <br /><br /><asp:Label ID="Label51" runat="server" Text="Data Izin Karyawan Tidak diketemukan" ForeColor="Red"></asp:Label>
					        </EmptyDataTemplate> 
                           
                                          
				        </asp:ListView>
            </asp:View>
        </asp:MultiView>
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

