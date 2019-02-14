<!DOCTYPE html>
<html lang="en">
<head>
	<link href='<?php echo base_url().'image/honda.png'?>' rel='shortcut icon'>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<meta name="description" content="Bootstrap 3 template for corporate business" />
	<!-- css -->
	<link href="<?php echo base_url().'pluginuser/css/bootstrap.min.css'?>" rel="stylesheet" />
	<link href="<?php echo base_url().'pluginuser/plugins/flexslider/flexslider.css'?>" rel="stylesheet" media="screen" />	
	<link href="<?php echo base_url().'pluginuser/css/cubeportfolio.min.css'?>" rel="stylesheet" />
	<link href="<?php echo base_url().'pluginuser/css/style.css'?>" rel="stylesheet" />
	<!-- Theme skin -->
	<link id="t-colors" href="<?php echo base_url().'pluginuser/skins/default.css'?>" rel="stylesheet" />
	<!-- boxed bg -->
	<link id="bodybg" href="<?php echo base_url().'pluginuser/bodybg/bg1.css'?>" rel="stylesheet" type="text/css" />
	<title>Honda Mugen</title>
</head>
<body>
	<div id="wrapper">
	<!-- start header -->
		<header>
		 
			<div class="navbar navbar-default navbar-fixed-top" role="navigation">
				<div class="container">
					<div class="navbar-header">
						<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
							<span class="icon-bar"></span>
							<span class="icon-bar"></span>
							<span class="icon-bar"></span>
						</button>
						<a class="navbar-brand" href="<?php echo base_url()?>"><img src="<?php echo base_url().'image/logo2.png'?>" alt="" width="150" height="40" /></a>
					</div>
					<div class="navbar-collapse collapse ">
						<ul class="nav navbar-nav">
							<li class="<?php if ($page=='index'){echo 'active';} else{echo '';} ?>">
								<a href="<?php echo base_url()?>">Beranda </a>
							</li>

							<li class="dropdown <?php if ($page=='profile'){echo 'active';} else{echo '';}?>">
								<a href="#" class="dropdown-toggle " data-toggle="dropdown" data-hover="dropdown" data-delay="0" data-close-others="false">Tentang Kami <i class="fa fa-angle-down"></i></a>
								<ul class="dropdown-menu">
									<li><a href="<?php echo base_url().'profile'?>">Profil Kami</a></li>
									<li><a href="<?php echo base_url().'fasilitas'?>">Fasilitas dan Layanan Divisi</a></li>
								</ul>
							</li>
							<li class="<?php if ($page=='produk'){echo 'active';} else{echo '';} ?>">
								<a href="<?php echo base_url().'produk'?>">Produk </a>
							</li>
							<li class="<?php if ($page=='Booking PUD'){echo 'active';} else{echo '';}?>"><a href="<?php echo base_url().'jadwalpud'?>">Recall PUD</a></li>
							<li class="<?php if ($page=='event'){echo 'active';} else{echo '';}?>"><a href="<?php echo base_url().'event'?>">Events & Promosi</a></li>
							<li class="<?php if ($page=='karir'){echo 'active';} else{echo '';}?>"><a href="<?php echo base_url().'karir'?>">Karir</a></li>
							<li class="<?php if ($page=='faq'){echo 'active';} else{echo '';}?>"><a href="<?php echo base_url().'faq'?>">FAQ</a></li>
							<li class="<?php if ($page=='lokasi'){echo 'active';} else{echo '';}?>"><a href="<?php echo base_url().'lokasi'?>">Lokasi Dealer</a></li>
							<li class="<?php if ($page=='login'){echo 'active';} else{echo '';}?>"><a href="<?php echo base_url().'login'?>">Login</a></li>
						</ul>
					</div>
				</div>
			</div>

		</header>
		<!-- end header -->
	</div>
	
	<script type='text/javascript'>
//<![CDATA[
$(document).ready(function() {
    // Menentukan elemen yang dijadikan sticky yaitu .nav
    var stickyNavTop = $('.nav').offset().top; 
    var stickyNav = function(){
        var scrollTop = $(window).scrollTop();  
        // Kondisi jika discroll maka menu akan selalu diatas, dan sebaliknya        
        if (scrollTop > stickyNavTop) { 
            $('.nav').css({ 'position': 'fixed', 'top':0, 'z-index':9999 });
        } else {
            $('.nav').css({ 'position': 'relative' });
        }
    };
    // Jalankan fungsi
    stickyNav();
    $(window).scroll(function() {
        stickyNav();
    });
});
//]]>
</script>
	