<title>Events</title>
<section id="content">
</section>
<section id="content">
	<div class="container">
		<div class="row">
			<div class="col-lg-8">
				<h2>Events & Promosi</h2><br>
				    <div style="overflow-x:auto;">
						<?php foreach  ($event as $b): ?>
							<h4><?php echo $b->nm_event ?></h4>
							<?php echo date("d-m-Y", strtotime($b->day)) ?>
							<?php echo $b->keterangan ?>
						<?php endforeach ?>	

						</tbody>
					</table>
					<center><?php echo $this->pagination->create_links();?></center>
		        </div>
		    </div>
			<!--Menampilkan Sidebar!-->
			<?php include('sidebar.php');?>
		</div>
	</div>
</section>