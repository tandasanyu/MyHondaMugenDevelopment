<html lang="en">
<head>
	<link href='<?php echo base_url().'image/honda.png'?>' rel='shortcut icon'>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<meta name="description" content="Bootstrap 3 template for corporate business" />
	<!-- css -->
	<link href="<?php echo base_url().'pluginuser/css/bootstrap.min.css'?>" rel="stylesheet" />
	<title>Booking Service</title>
</head>

<body><br><br><br>
	<div class="container">
        <center>
        <h2>Jadwal Campaign PUD Ps. Minggu</h2>
        <h4><?php
							$tgl=date('d M Y');
							$hari   = date('l');
							$hari_indonesia = array('Monday'  => 'Senin',
													'Tuesday'  => 'Selasa',
													'Wednesday' => 'Rabu',
													'Thursday' => 'Kamis',
													'Friday' => 'Jumat',
													'Saturday' => 'Sabtu',
													'Sunday' => 'Minggu');?>
							<?php echo $hari_indonesia[$hari]?>,<?php echo $tgl;?> <p id="clock"></p></h4></center><br>
        <div class="table-responsive">
            <table class="table table-striped table-bordered table-hover">
                <thead>
                    <tr>
			            <th>No</th>
				        <th>Jam Kunjungan</th>
				        <th>Nama</th>
                        <th>Tipe Mobil</th>
                        <th>No Polisi</th>
                    </tr>
                </thead>
		        <tbody>
			        <?php $no=1; foreach  ($booking1 as $b): ?>
                    <tr>
				        <td align="center" class="col-md-1"><?php echo $no ?></td>
				        <td class="col-md-1"><?php echo $b->booking_jam ?></td>
					    <td class="col-md-3"><?php echo $b->booking_nama ?></td>
					    <td class="col-md-3">Honda <?php echo $b->booking_tipe ?></td>
					    <td class="col-md-2"><?php echo $b->booking_nopol ?></td>
                    </tr>
				    <?php $no++; endforeach ?>
		        </tbody>
            </table>
        </div>	
    </div>
  <script type="text/javascript">
<!--
function showTime() {
    var a_p = "";
    var today = new Date();
    var curr_hour = today.getHours();
    var curr_minute = today.getMinutes();
    var curr_second = today.getSeconds();
    if (curr_hour < 12) {
        a_p = "AM";
    } else {
        a_p = "PM";
    }
    if (curr_hour == 0) {
        curr_hour = 12;
    }
    if (curr_hour > 12) {
        curr_hour = curr_hour - 12;
    }
    curr_hour = checkTime(curr_hour);
    curr_minute = checkTime(curr_minute);
    curr_second = checkTime(curr_second);
 document.getElementById('clock').innerHTML=curr_hour + ":" + curr_minute + ":" + curr_second + " " + a_p;
    }

function checkTime(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}
setInterval(showTime, 500);
//-->
</script>

</body>
</html>
