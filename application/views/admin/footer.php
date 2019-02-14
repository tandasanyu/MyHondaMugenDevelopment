
    <!-- jQuery -->
    <script src="<?php echo base_url().'plugin/vendor/jquery/jquery.min.js'?>"></script>
	<script type="text/javascript" src="<?php echo base_url().'plugin/js/datatables/jquery.dataTables.js'?>"></script>
    <script type="text/javascript" src="<?php echo base_url().'plugin/js/datatables/dataTables.bootstrap4.js'?>"></script>
     <script type="text/javascript" src="<?php echo base_url().'plugin/js/datatables/sb-admin-datatables.min.js'?>"></script>

    <link rel="stylesheet" type="text/css" href="<?php echo base_url().'plugin/js/datatables/dataTables.bootstrap4.css'?>" />

	
	
    <!-- Bootstrap Core JavaScript -->
    <script src="<?php echo base_url().'plugin/vendor/bootstrap/js/bootstrap.min.js'?>"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="<?php echo base_url().'plugin/vendor/metisMenu/metisMenu.min.js'?>"></script>

    <!-- Custom Theme JavaScript -->
    <script src="<?php echo base_url().'plugin/dist/js/sb-admin-2.js'?>"></script>

	<script src="<?php echo base_url().'plugin/js/tinymce/tinymce.min.js'?>"></script>

	<script type="text/javascript">
		  tinymce.init({
			width:"700",
			height:"200",
			selector : "textarea",
			plugins : ["advlist autolink lists link image charmap print preview anchor", "searchreplace visualblocks code fullscreen", "insertdatetime media table contextmenu paste"],
			toolbar : "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image"
		  }); 
		</script>
<link rel="stylesheet" href="<?php echo base_url().'plugin/css/jquery-ui.css'?>" type="text/css"/>

<script src="<?php echo base_url().'plugin/js/jquery-ui.js'?>" type="text/javascript"></script>
<script>
  $(function() {
    $( "#datepicker" ).datepicker({
	  changeMonth: true,
        changeYear: true,
		dateFormat: "dd-mm-yy",
		todayHighlight: true
		});
  });
</script>
</body>

</html>

<!--CSS Pagination-->
<style>
	.pagination {
		display: inline-block;
	}

	.pagination a {
		color: black;
		float: left;
		padding: 8px 16px;
		text-decoration: none;
	}

	.pagination a.active {
		background-color: #4CAF50;
		color: white;
		border-radius: 5px;
	}

	.pagination a:hover:not(.active) {
		background-color: #ddd;
		border-radius: 5px;
	}
</style>