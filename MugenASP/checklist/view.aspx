<%@ Page Language="VB" AutoEventWireup="false" CodeFile="view.aspx.vb" Inherits="_Default" %>



<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Honda Mugen</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="css/modern-business.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>

<body>

    <!-- Navigation -->
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="index.html">Honda Mugen</a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="about.html">About</a>
                    </li>
                    <li>
                        <a href="services.html">Services</a>
                    </li>
                    <li>
                        <a href="contact.html">Contact</a>
                    </li>
                   
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>
	
	<div class="container">

        
          
			
            <center>    <h2>
                  FORM PEMERIKSAAN
                </h2>
				<h4>001-FRM-SV R.0</h4></center>
           
			
		
	</div>
   
	
	<div class="container">

        <!-- Marketing Icons Section -->
        <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">
                  Detail Kendaraan
                </h4>
            </div>
		</div>	


        <form runat="server">
		<div class="form-group">
			<label class="control-label col-sm-2" for="nopol">No Polisi (<font color="red">*</font>)</label>
            <div class="col-sm-4">
				<asp:TextBox ID="nopol1" readonly="true" class="form-control required"  runat="server"></asp:TextBox>	
			</div>
		</div>
           
           
		
		<div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">
                  Aksesoris Kendaraan
                </h4>
            </div>
		</div>	 


		
		<div class="table table-responsive">

               <asp:SqlDataSource ID="sdsTabelSPKG2" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet %>" 
            SelectCommand="SELECT * from TEMP_AKSESORIS where nopol= nopol1;"                     
            ProviderName="<%$ ConnectionStrings:MyConnCloudDnet.ProviderName %>">
                     <selectparameters>
                             <asp:controlparameter name="nopol1" controlid="nopol1" propertyname="Text" Type="String"/>
                     </selectparameters>
   
              
</asp:SqlDataSource>                         
        <asp:ListView  runat="server" DataSourceID="sdsTabelSPKG2" >
			<LayoutTemplate>
				<table class="table table-bordered striped">
					<thead  style="background-color:Silver">
						 <th align="center">No</th>
		                 <th class="col-md-5" align="center">Perlengkapan Kendaraan</th>
		                 <th class="col-md-6" align="center">Keterangan</th>
					</thead>
					<asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
				</table>
			
			</LayoutTemplate>
			<ItemTemplate>
				<tr>
                    <td> <%# Container.DataItemIndex + 1 %></td>
					<td><%#Eval("kode")%></td>
					<td><%#Eval("keterangan")%></td>
				</tr>
			</ItemTemplate>
		</asp:ListView>


	</div>
	</div>	

    <!-- Page Content -->
    <div class="container">

        <!-- Marketing Icons Section -->
        <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">
                   Kondisi Fisik Kendaraan
                </h4>
            </div>
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-down"></i> Bagian Depan <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4> 
                    </div>
					<div class="panel-body">
						<center>
							<div class="relative"><img src="accordDepan.png" class="img-responsive"> 
								<!-- Bemper Depan Atas -->
								<div class="depanAtas">
									<asp:Label ID="askDepanKiriAtas" runat="server"></asp:Label>
									
									<!-- Bemper Depan Tengah Atas -->
                                    <asp:Label style="margin-left:80px;" ID="askDepanTengahAtas" runat="server"></asp:Label>
									

									<!-- Bemper Depan Kanan Atas -->
									 <asp:Label style="margin-left:80px;" ID="askDepanKananAtas" runat="server"></asp:Label>
								</div>
								
								
								<!-- Bemper Depan Bawah -->
								<div class="depanBawah">
									<!-- Bemper Depan Kiri Bawah -->
                                    <asp:Label ID="askDepanKiriBawah" runat="server"></asp:Label>
									
									<!-- Bemper Depan Tengah Bawah -->	
                                    <asp:Label style="margin-left:90px;" ID="askDepanTengahBawah" runat="server"></asp:Label>
									
									<!-- Bemper Depan Kanan Bawah -->	
                                    <asp:Label style="margin-left:90px;" ID="askDepanKananBawah" runat="server"></asp:Label>
								</div>
							</div>
						</center>	
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-up"></i> Bagian Belakang  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                    <div class="panel-body">
                        <center>
							<div class="relative">
								<img src="accordBelakang.png" class="img-responsive">  
								<!-- Belakang Atas -->
								<div class="belakangAtas">
			
									<!-- Belakang Kiri Atas -->
                                     <asp:Label ID="askBelakangKiriAtas" runat="server"></asp:Label>
                                   
									
									<!-- Belakang Tengah Atas -->
                                    <asp:Label style="margin-left:95px;" ID="askBelakangTengahAtas" runat="server"></asp:Label>
									
									<!-- Belakang Kanan Atas -->
                                    <asp:Label style="margin-left:85px;" ID="askBelakangKananAtas" runat="server"></asp:Label>

								</div>
								
								<!-- Belakang Bawah -->
								<div class="belakangBawah">
								
									<!-- Belakang Kiri Bawah -->
                                    <asp:Label ID="askBelakangKiriBawah" runat="server"></asp:Label> 
                                   
									<!-- Belakang Tengah Bawah -->
                                    <asp:Label style="margin-left:95px;" ID="askBelakangTengahBawah" runat="server"></asp:Label> 
                                     
									<!-- Belakang Kanan Bawah -->
                                    <asp:Label style="margin-left:85px;" ID="askBelakangKananBawah" runat="server"></asp:Label>
 
								</div>
								
							</div>
						</center>	
                    </div>
                </div>
            </div>
          
			
			<div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-right"></i> Bagian Kanan  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                     <div class="panel-body">
                        <center>
						<div class="relative"><img src="accordKanan.png" class="img-responsive"> 
							<!-- Kanan Atas -->
							<div class="kananAtas">
                                 <asp:Label ID="askKananAtas" runat="server"></asp:Label>
							</div>
							
							<!-- Kanan Tengah -->
							<div class="kananTengah">
								
								<!-- Kanan Tengah 1 -->
                                <asp:Label style="margin-left:5px;" ID="askKananTengah1" runat="server"></asp:Label>
								
								<!-- Kanan Tengah 2 -->
                                <asp:Label style="margin-left:40px;" ID="askKananTengah2" runat="server"></asp:Label>
                                								
								<!-- Kanan Tengah 3 -->
                                 <asp:Label style="margin-left:15px;" ID="askKananTengah3" runat="server"></asp:Label>
                                								
								<!-- Kanan Tengah 4 -->
                                <asp:Label style="margin-left:15px;" ID="askKananTengah4" runat="server"></asp:Label>
                               								
								<!-- Kanan Tengah 5 -->
                                <asp:Label style="margin-left:15px;" ID="askKananTengah5" runat="server"></asp:Label>
                    								
								<!-- Kanan Tengah 6 -->
                                <asp:Label style="margin-left:20px;" ID="askKananTengah6" runat="server"></asp:Label>
                                
								<!-- Kanan Tengah 7 -->
                                 <asp:Label style="margin-left:20px;" ID="askKananTengah7" runat="server"></asp:Label>
                                
								<!-- Kanan Tengah 8 -->
                                 <asp:Label style="margin-left:25px;" ID="askKananTengah8" runat="server"></asp:Label>
							</div>
							
							<!-- Kanan Bawah -->
							<div class="kananBawah">
							
								<!-- Kanan Bawah 1 -->
                                 <asp:Label style="margin-left:10px;" ID="askKananBawah1" runat="server"></asp:Label>
                                								
								<!-- Kanan Bawah 2 -->
                                <asp:Label style="margin-left:90px;" ID="askKananBawah2" runat="server"></asp:Label>
                               								
								<!-- Kanan Bawah 3 -->
                                <asp:Label style="margin-left:20px;" ID="askKananBawah3" runat="server"></asp:Label>
                                								
								<!-- Kanan Bawah 4 -->
                                <asp:Label style="margin-left:20px;" ID="askKananBawah4" runat="server"></asp:Label>
                                								
								<!-- Kanan Bawah 5 -->
                                <asp:Label style="margin-left:20px;" ID="askKananBawah5" runat="server"></asp:Label>
                                								
								<!-- Kanan Bawah 6 -->
                                 <asp:Label style="margin-left:20px;" ID="askKananBawah6" runat="server"></asp:Label>
                                 								
								<!-- Kanan Bawah 7 -->
                                <asp:Label style="margin-left:80px;" ID="askKananBawah7" runat="server"></asp:Label>
                     
							</div>
						</div>
					</center>	
                    </div>
                </div>
            </div>
			
			<div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrow-circle-left"></i> Bagian Kiri  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                     <div class="panel-body">
                        <center>
						<div class="relative"><img src="accordKiri.png" class="img-responsive">  
							<!-- Kiri Atas -->
							<div class="kiriAtas">
                                <asp:Label ID="askKiriAtas" runat="server"></asp:Label>					
								
							</div>
							
							<!-- Kiri Tengah -->
							<div class="kiriTengah">
								
								<!-- Kiri Tengah 1 -->
                                <asp:Label style="margin-left:95px;" ID="askKiriTengah1" runat="server"></asp:Label>	 
                                
								<!-- Kiri Tengah 2 -->
                                <asp:Label style="margin-left:40px;" ID="askKiriTengah2" runat="server"></asp:Label>	
                                								
								<!-- Kiri Tengah 3 -->
                                <asp:Label style="margin-left:15px;" ID="askKiriTengah3" runat="server"></asp:Label>
                              								
								<!-- Kiri Tengah 4 -->
                                <asp:Label style="margin-left:20px;" ID="askKiriTengah4" runat="server"></asp:Label>
                                								
								<!-- Kiri Tengah 5 -->
                                <asp:Label style="margin-left:15px;" ID="askKiriTengah5" runat="server"></asp:Label>
                               								
								<!-- Kiri Tengah 6 -->
                                <asp:Label style="margin-left:20px;" ID="askKiriTengah6" runat="server"></asp:Label>
                               								
								<!-- Kiri Tengah 7 -->
                                <asp:Label style="margin-left:20px;" ID="askKiriTengah7" runat="server"></asp:Label>
                               								
								<!-- Kiri Tengah 8 -->
                                <asp:Label style="margin-left:25px;" ID="askKiriTengah8" runat="server"></asp:Label>
							</div>
							
							<!-- Kiri Bawah -->
							<div class="kiriBawah">
							
								<!-- Kiri Bawah 1 -->
                               <asp:Label style="margin-left:-15px;" ID="askKiriBawah1" runat="server"></asp:Label>
                                 								
								<!-- Kiri Bawah 2 -->
                                <asp:Label style="margin-left:80px;" ID="askKiriBawah2" runat="server"></asp:Label>
								
								<!-- Kiri Bawah 3 -->
                                <asp:Label style="margin-left:20px;" ID="askKiriBawah3" runat="server"></asp:Label>
                                 								
								<!-- Kiri Bawah 4 -->
                                <asp:Label style="margin-left:20px;" ID="askKiriBawah4" runat="server"></asp:Label>
                                								
								<!-- Kiri Bawah 5 -->
                                <asp:Label style="margin-left:20px;" ID="askKiriBawah5" runat="server"></asp:Label>
                                								
								<!-- Kiri Bawah 6 -->
                                <asp:Label style="margin-left:20px;" ID="askKiriBawah6" runat="server"></asp:Label>
                                								
								<!-- Kiri Bawah 7 -->
                                 <asp:Label style="margin-left:90px;" ID="askKiriBawah7" runat="server"></asp:Label>
                               
							</div>
						</div>
					</center>	
                    </div>
                </div>
            </div>
			
			<div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-arrows-alt"></i> Bagian Atas  <sub>(X : Penyok, V : Baret/Besor, O : Bintik)</sub></h4>
                    </div>
                     <div class="panel-body">
                        <center>
						<div class="relative"><img src="accordAtas.png" class="img-responsive">  
							<!-- Atas Kiri -->
							<div class="atasKiri">
								
								<!-- Atas Kiri 1 -->
                                <asp:Label ID="askAtasKiri1" runat="server"></asp:Label>
                                
								<!-- Atas Kiri 2 -->
                                <asp:Label style="margin-left:55px;" ID="askAtasKiri2" runat="server"></asp:Label>
                                
								<!-- Atas Kiri 3 -->
                                <asp:Label style="margin-left:35px;" ID="askAtasKiri3" runat="server"></asp:Label>
                               								
								<!-- Atas Kiri 4 -->
                                <asp:Label style="margin-left:35px;" ID="askAtasKiri4" runat="server"></asp:Label>
                              
								<!-- Atas Kiri 5 -->
                                 <asp:Label style="margin-left:100px;" ID="askAtasKiri5" runat="server"></asp:Label>
                               
							</div>
							
							<!-- Atas Kanan -->
							<div class="atasKanan">
							
								<!-- Atas Kanan 1 -->
                               <asp:Label ID="askAtasKanan1" runat="server"></asp:Label>
                               								
								<!-- Atas Kanan 2 -->
                                <asp:Label style="margin-left:65px;" ID="askAtasKanan2" runat="server"></asp:Label>
                                								
								<!-- Atas Kanan 3 -->
                                <asp:Label style="margin-left:35px;" ID="askAtasKanan3" runat="server"></asp:Label>
                                
								<!-- Atas Kanan 4 -->
                                <asp:Label style="margin-left:35px;" ID="askAtasKanan4" runat="server"></asp:Label>
                              								
								<!-- Atas Kanan 5 -->
                                <asp:Label style="margin-left:100px;" ID="askAtasKanan5" runat="server"></asp:Label>
                       
						</div>
					</center>	
                    </div>
                </div>
            </div>
           
        </div>
             <asp:Label ID="Label3" runat="server" ></asp:Label>
        

       
       </form>
      
        


      

        <hr>

        <!-- Footer -->
        <footer>
            <div class="row">
                <div class="col-lg-12">
                    <p>Copyright &copy; Your Website 2014</p>
                </div>
            </div>
        </footer>

    </div>
    <!-- /.container -->

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Script to Activate the Carousel -->
    <script>
    $('.carousel').carousel({
        interval: 5000 //changes the speed
    })
    </script>

</body>

</html>

	<style>
div.relative {
    position: relative;
    width: 400px;
    height: 250px;
   
} 


div.depanAtas {
    position: absolute;
    top: 115px;
    left: -25px;

    width: 450px;
   
}


div.depanBawah {
	position: absolute;
    bottom: 65px;
    left: 5px;
    width: 100%;
   
}



div.belakangBawah {
    position: absolute;
    bottom: 75px;
    left: -30px;
 
    width: 450px;

}

div.belakangAtas {
    position: absolute;
    bottom: 130px;
    left: -30px;

    width: 450px;

}


div.kananAtas {
    position: absolute;
    top: 85px;
    left: -140px;

    width: 450px;
   
}

div.kananTengah {
    position: absolute;
    top: 115px;
    left: -28px;

    width: 450px;
   
}

div.kananBawah {
    position: absolute;
    bottom: 85px;
    left: -20px;

    width: 450px;
   
}

div.kiriAtas {
    position: absolute;
    top: 85px;
    left: 85px;

    width: 450px;
   
}

div.kiriTengah {
    position: absolute;
    top: 115px;
    left: -80px;

    width: 450px;
   
}

div.kiriBawah {
    position: absolute;
    bottom: 85px;
    left: -28px;

    width: 450px;
   
}

div.atasKiri {
    position: absolute;
    top: 60px;
    left: -40px;

    width: 450px;
   
}

div.atasKanan {
    position: absolute;
    bottom:120px;
    left: -45px;

    width: 450px;
   
}



        .auto-style1 {
            height: 37px;
        }



    </style>
<script>
	//Ada & Tidak Ada	
		function depanKananAtas() {
			if (document.getElementById('askDepanKananAtas').checked) {
					document.getElementById('tampilDepanKananAtas').style.display = 'block';	
			} else { document.getElementById('tampilDepanKananAtas').style.display = 'none';	
			}
		}
		
		function depanTengahAtas() {
			if (document.getElementById('askDepanTengahAtas').checked) {
					document.getElementById('tampilDepanTengahAtas').style.display = 'block';	
			} else { document.getElementById('tampilDepanTengahAtas').style.display = 'none';	
			}
		}
		
		function depanKiriAtas() {
			if (document.getElementById('askDepanKiriAtas').checked) {
					document.getElementById('tampilDepanKiriAtas').style.display = 'block';	
			} else { document.getElementById('tampilDepanKiriAtas').style.display = 'none';	
			}
		}	
		
		function depanKiriBawah() {
			if (document.getElementById('askDepanKiriBawah').checked) {
					document.getElementById('tampilDepanKiriBawah').style.display = 'block';	
			} else { document.getElementById('tampilDepanKiriBawah').style.display = 'none';	
			}
		}	
		
		function depanKananBawah() {
			if (document.getElementById('askDepanKananBawah').checked) {
					document.getElementById('tampilDepanKananBawah').style.display = 'block';	
			} else { document.getElementById('tampilDepanKananBawah').style.display = 'none';	
			}
		}	
		
		function depanTengahBawah() {
			if (document.getElementById('askDepanTengahBawah').checked) {
					document.getElementById('tampilDepanTengahBawah').style.display = 'block';	
			} else { document.getElementById('tampilDepanTengahBawah').style.display = 'none';	
			}
		}	
			
			
		function belakangKiriAtas() {
			if (document.getElementById('askBelakangKiriAtas').checked) {
					document.getElementById('tampilBelakangKiriAtas').style.display = 'block';	
			} else { document.getElementById('tampilBelakangKiriAtas').style.display = 'none';	
			}
		}	
		
		function belakangTengahAtas() {
			if (document.getElementById('askBelakangTengahAtas').checked) {
					document.getElementById('tampilBelakangTengahAtas').style.display = 'block';	
			} else { document.getElementById('tampilBelakangTengahAtas').style.display = 'none';	
			}
		}	
			
		function belakangKananAtas() {
			if (document.getElementById('askBelakangKananAtas').checked) {
					document.getElementById('tampilBelakangKananAtas').style.display = 'block';	
			} else { document.getElementById('tampilBelakangKananAtas').style.display = 'none';	
			}
		}
		
		function belakangKiriBawah() {
			if (document.getElementById('askBelakangKiriBawah').checked) {
					document.getElementById('tampilBelakangKiriBawah').style.display = 'block';	
			} else { document.getElementById('tampilBelakangKiriBawah').style.display = 'none';	
			}
		}	
		
		function belakangTengahBawah() {
			if (document.getElementById('askBelakangTengahBawah').checked) {
					document.getElementById('tampilBelakangTengahBawah').style.display = 'block';	
			} else { document.getElementById('tampilBelakangTengahBawah').style.display = 'none';	
			}
		}	
			
		function belakangKananBawah() {
			if (document.getElementById('askBelakangKananBawah').checked) {
					document.getElementById('tampilBelakangKananBawah').style.display = 'block';	
			} else { document.getElementById('tampilBelakangKananBawah').style.display = 'none';	
			}
		}
		
		function kananAtas() {
			if (document.getElementById('askKananAtas').checked) {
					document.getElementById('tampilKananAtas').style.display = 'block';	
			} else { document.getElementById('tampilKananAtas').style.display = 'none';	
			}
		}
		
		function kananTengah1() {
			if (document.getElementById('askKananTengah1').checked) {
					document.getElementById('tampilKananTengah1').style.display = 'block';	
			} else { document.getElementById('tampilKananTengah1').style.display = 'none';	
			}
		}
		
		function kananTengah2() {
			if (document.getElementById('askKananTengah2').checked) {
					document.getElementById('tampilKananTengah2').style.display = 'block';	
			} else { document.getElementById('tampilKananTengah2').style.display = 'none';	
			}
		}
		
		function kananTengah3() {
			if (document.getElementById('askKananTengah3').checked) {
					document.getElementById('tampilKananTengah3').style.display = 'block';	
			} else { document.getElementById('tampilKananTengah3').style.display = 'none';	
			}
		}
		
		function kananTengah4() {
			if (document.getElementById('askKananTengah4').checked) {
					document.getElementById('tampilKananTengah4').style.display = 'block';	
			} else { document.getElementById('tampilKananTengah4').style.display = 'none';	
			}
		}
		
		function kananTengah5() {
			if (document.getElementById('askKananTengah5').checked) {
					document.getElementById('tampilKananTengah5').style.display = 'block';	
			} else { document.getElementById('tampilKananTengah5').style.display = 'none';	
			}
		}
		
		function kananTengah6() {
			if (document.getElementById('askKananTengah6').checked) {
					document.getElementById('tampilKananTengah6').style.display = 'block';	
			} else { document.getElementById('tampilKananTengah6').style.display = 'none';	
			}
		}
		
		function kananTengah7() {
			if (document.getElementById('askKananTengah7').checked) {
					document.getElementById('tampilKananTengah7').style.display = 'block';	
			} else { document.getElementById('tampilKananTengah7').style.display = 'none';	
			}
		}
		
		function kananTengah8() {
			if (document.getElementById('askKananTengah8').checked) {
					document.getElementById('tampilKananTengah8').style.display = 'block';	
			} else { document.getElementById('tampilKananTengah8').style.display = 'none';	
			}
		}
		
		function kananBawah1() {
			if (document.getElementById('askKananBawah1').checked) {
					document.getElementById('tampilKananBawah1').style.display = 'block';	
			} else { document.getElementById('tampilKananBawah1').style.display = 'none';	
			}
		}
		
		function kananBawah2() {
			if (document.getElementById('askKananBawah2').checked) {
					document.getElementById('tampilKananBawah2').style.display = 'block';	
			} else { document.getElementById('tampilKananBawah2').style.display = 'none';	
			}
		}
		
		function kananBawah3() {
			if (document.getElementById('askKananBawah3').checked) {
					document.getElementById('tampilKananBawah3').style.display = 'block';	
			} else { document.getElementById('tampilKananBawah3').style.display = 'none';	
			}
		}
		
		function kananBawah4() {
			if (document.getElementById('askKananBawah4').checked) {
					document.getElementById('tampilKananBawah4').style.display = 'block';	
			} else { document.getElementById('tampilKananBawah4').style.display = 'none';	
			}
		}
		
		function kananBawah5() {
			if (document.getElementById('askKananBawah5').checked) {
					document.getElementById('tampilKananBawah5').style.display = 'block';	
			} else { document.getElementById('tampilKananBawah5').style.display = 'none';	
			}
		}
		
		function kananBawah6() {
			if (document.getElementById('askKananBawah6').checked) {
					document.getElementById('tampilKananBawah6').style.display = 'block';	
			} else { document.getElementById('tampilKananBawah6').style.display = 'none';	
			}
		}
		
		function kananBawah7() {
			if (document.getElementById('askKananBawah7').checked) {
					document.getElementById('tampilKananBawah7').style.display = 'block';	
			} else { document.getElementById('tampilKananBawah7').style.display = 'none';	
			}
		}
		
		function kiriAtas() {
			if (document.getElementById('askKiriAtas').checked) {
					document.getElementById('tampilKiriAtas').style.display = 'block';	
			} else { document.getElementById('tampilKiriAtas').style.display = 'none';	
			}
		}
		
		function kiriTengah1() {
			if (document.getElementById('askKiriTengah1').checked) {
					document.getElementById('tampilKiriTengah1').style.display = 'block';	
			} else { document.getElementById('tampilKiriTengah1').style.display = 'none';	
			}
		}
		
		function kiriTengah2() {
			if (document.getElementById('askKiriTengah2').checked) {
					document.getElementById('tampilKiriTengah2').style.display = 'block';	
			} else { document.getElementById('tampilKiriTengah2').style.display = 'none';	
			}
		}
		function kiriTengah3() {
			if (document.getElementById('askKiriTengah3').checked) {
					document.getElementById('tampilKiriTengah3').style.display = 'block';	
			} else { document.getElementById('tampilKiriTengah3').style.display = 'none';	
			}
		}
		function kiriTengah4() {
			if (document.getElementById('askKiriTengah4').checked) {
					document.getElementById('tampilKiriTengah4').style.display = 'block';	
			} else { document.getElementById('tampilKiriTengah4').style.display = 'none';	
			}
		}
		
		function kiriTengah5() {
			if (document.getElementById('askKiriTengah5').checked) {
					document.getElementById('tampilKiriTengah5').style.display = 'block';	
			} else { document.getElementById('tampilKiriTengah5').style.display = 'none';	
			}
		}
		
		function kiriTengah6() {
			if (document.getElementById('askKiriTengah6').checked) {
					document.getElementById('tampilKiriTengah6').style.display = 'block';	
			} else { document.getElementById('tampilKiriTengah6').style.display = 'none';	
			}
		}
		
		function kiriTengah7() {
			if (document.getElementById('askKiriTengah7').checked) {
					document.getElementById('tampilKiriTengah7').style.display = 'block';	
			} else { document.getElementById('tampilKiriTengah7').style.display = 'none';	
			}
		}
		
		function kiriTengah8() {
			if (document.getElementById('askKiriTengah8').checked) {
					document.getElementById('tampilKiriTengah8').style.display = 'block';	
			} else { document.getElementById('tampilKiriTengah8').style.display = 'none';	
			}
		}
		
		
		function kiriBawah1() {
			if (document.getElementById('askKiriBawah1').checked) {
					document.getElementById('tampilKiriBawah1').style.display = 'block';	
			} else { document.getElementById('tampilKiriBawah1').style.display = 'none';	
			}
		}
		
		function kiriBawah2() {
			if (document.getElementById('askKiriBawah2').checked) {
					document.getElementById('tampilKiriBawah2').style.display = 'block';	
			} else { document.getElementById('tampilKiriBawah2').style.display = 'none';	
			}
		}
		
		function kiriBawah3() {
			if (document.getElementById('askKiriBawah3').checked) {
					document.getElementById('tampilKiriBawah3').style.display = 'block';	
			} else { document.getElementById('tampilKiriBawah3').style.display = 'none';	
			}
		}
		
		function kiriBawah4() {
			if (document.getElementById('askKiriBawah4').checked) {
					document.getElementById('tampilKiriBawah4').style.display = 'block';	
			} else { document.getElementById('tampilKiriBawah4').style.display = 'none';	
			}
		}
		
		function kiriBawah5() {
			if (document.getElementById('askKiriBawah5').checked) {
					document.getElementById('tampilKiriBawah5').style.display = 'block';	
			} else { document.getElementById('tampilKiriBawah5').style.display = 'none';	
			}
		}
		
		function kiriBawah6() {
			if (document.getElementById('askKiriBawah6').checked) {
					document.getElementById('tampilKiriBawah6').style.display = 'block';	
			} else { document.getElementById('tampilKiriBawah6').style.display = 'none';	
			}
		}
		
		function kiriBawah7() {
			if (document.getElementById('askKiriBawah7').checked) {
					document.getElementById('tampilKiriBawah7').style.display = 'block';	
			} else { document.getElementById('tampilKiriBawah7').style.display = 'none';	
			}
		}
		
		function atasKiri1() {
			if (document.getElementById('askAtasKiri1').checked) {
					document.getElementById('tampilAtasKiri1').style.display = 'block';	
			} else { document.getElementById('tampilAtasKiri1').style.display = 'none';	
			}
		}
		
		function atasKiri2() {
			if (document.getElementById('askAtasKiri2').checked) {
					document.getElementById('tampilAtasKiri2').style.display = 'block';	
			} else { document.getElementById('tampilAtasKiri2').style.display = 'none';	
			}
		}
		
		function atasKiri3() {
			if (document.getElementById('askAtasKiri3').checked) {
					document.getElementById('tampilAtasKiri3').style.display = 'block';	
			} else { document.getElementById('tampilAtasKiri3').style.display = 'none';	
			}
		}
		
		function atasKiri4() {
			if (document.getElementById('askAtasKiri4').checked) {
					document.getElementById('tampilAtasKiri4').style.display = 'block';	
			} else { document.getElementById('tampilAtasKiri4').style.display = 'none';	
			}
		}
		
		function atasKiri5() {
			if (document.getElementById('askAtasKiri5').checked) {
					document.getElementById('tampilAtasKiri5').style.display = 'block';	
			} else { document.getElementById('tampilAtasKiri5').style.display = 'none';	
			}
		}
		
		function atasKanan1() {
			if (document.getElementById('askAtasKanan1').checked) {
					document.getElementById('tampilAtasKanan1').style.display = 'block';	
			} else { document.getElementById('tampilAtasKanan1').style.display = 'none';	
			}
		}
		
		function atasKanan2() {
			if (document.getElementById('askAtasKanan2').checked) {
					document.getElementById('tampilAtasKanan2').style.display = 'block';	
			} else { document.getElementById('tampilAtasKanan2').style.display = 'none';	
			}
		}
		
		function atasKanan3() {
			if (document.getElementById('askAtasKanan3').checked) {
					document.getElementById('tampilAtasKanan3').style.display = 'block';	
			} else { document.getElementById('tampilAtasKanan3').style.display = 'none';	
			}
		}
		
		function atasKanan4() {
			if (document.getElementById('askAtasKanan4').checked) {
					document.getElementById('tampilAtasKanan4').style.display = 'block';	
			} else { document.getElementById('tampilAtasKanan4').style.display = 'none';	
			}
		}
		
		function atasKanan5() {
			if (document.getElementById('askAtasKanan5').checked) {
					document.getElementById('tampilAtasKanan5').style.display = 'block';	
			} else { document.getElementById('tampilAtasKanan5').style.display = 'none';	
			}
		}
	
		
		
		
</script>