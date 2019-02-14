<title>Login User</title>
<section id="content">
</section>
<section id="content">
	<div class="container">
		<div class="col-md-4 col-md-offset-4">
			<div class="login-panel panel panel-default">
				<center>
					<img src="<?php echo base_url().'image/honda2.png'?>" height="200" width="200" class="img-responsive">
				</center>
				<div class="panel-heading">
					<h3 class="panel-title"><font color="red"><?php echo $pesan;?></font></h3>
				</div>
				<div class="panel-body">
					<form role="form" action="<?php echo base_url();?>index.php/welcome/proses" method="post">
						<fieldset>
							<div class="form-group">
								<input class="form-control" placeholder="Username" name="username" type="text" onFocus="this.value=''" value="username">
							</div>
							<div class="form-group">
								<input class="form-control" placeholder="Password" name="password" type="password"  onFocus="this.value=''" value="password">
							</div>
							<!-- Change this to a button or input when using this as a form -->
							<input type="submit" class="btn btn-lg btn-success btn-block" value="Login">
						</fieldset>
					</form>
				</div>
			</div>
		</div>
    </div>
</section>