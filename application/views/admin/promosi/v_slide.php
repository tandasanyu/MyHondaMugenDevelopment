<div id="page-wrapper">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Banner Web Honda Mugen</h1>
        </div>
        <!-- /.col-lg-12 -->
				
		<!-- /.col-lg-6 -->
        <div class="col-lg-12">   
            <form class="form-horizontal" method="post" action="<?php echo base_url().'Promosi/simpanBanner'?>" enctype="multipart/form-data">
                <table>
                    <tr>
                        <td><b>Slide Banner</b></td>
                        <td><p style="margin-left:25px"><input id="filebutton" name="userfile" type="file"></p></td>
                        <td><input type="submit" class="btn btn-primary" value="Tambah"></td>
                    </tr>
                </table>
            </form>
            
            <!-- /.panel-heading -->
            <div class="panel-body">
               
                <div class="table-responsive">
                    <table class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
								<th>No</th>
                                <th class="col-md-9">Banner</th>
                                <th class="col-md-2">Aksi</th>
                            </tr>  
                        </thead>
                        <tbody>
						<?php $no=1; foreach ($slide as $b):   ?>
                            <tr>
								<td align="center"><?php echo $no ?></td>
								<td><img class="m_img" src="<?php echo base_url();?>image/<?php echo $b->path ?>" width="600" height="150"/></td>   
                                <td align="center">
                                    <?php 
                                        echo '&nbsp'. anchor('Promosi/hapusBanner/'.$b->id_slide, ' Hapus', array('class' => 'btn btn-danger btn-sm'));?>
                                </td> 
                            </tr
						<?php $no++; endforeach ?>     
                        </tbody>
                    </table>
                </div>
                <!-- /.table-responsive -->
            </div>
            <!-- /.panel-body -->
        </div>
        <!-- /.panel -->
    </div>
</div>
<!-- /#page-wrapper -->


