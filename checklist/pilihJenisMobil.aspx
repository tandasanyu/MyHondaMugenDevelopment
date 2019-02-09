<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="pilihJenisMobil.aspx.vb" Inherits="pilihJenisMobil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
       <!-- Page Content -->
    <div class="container">
        <!-- Marketing Icons Section -->
        <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">Pilih Jenis Kendaraan</h4>
            </div>
            <form id="form1" runat="server">
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>SUV</h4> 
                    </div>
					<div class="panel-body">
                        <center>
                            <div class="relative"><a href="formChecklistSUV.aspx" class="suv"></a> 
							</div>
						</center>	
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                    <h4>SEDAN</h4>
                </div>
                <div class="panel-body">
                    <center>
					    <div class="relative"><a href="formChecklist.aspx" class="accord"></a>  
					    </center>	
                    </div>
                </div>
            </div>
			
		
    </form>

    </div>
    <!-- /.container -->

<style>
.suv {
    margin-bottom: 10px;
    width: 402px;
    height:270px;
    display:block;
    background:transparent url('image/crv1.png') center top no-repeat;
}

.suv:hover {
    background-image: url('image/crv2.png');
}

.accord {
    margin-bottom: 10px;
     width: 402px;
     height:270px;
     display:block;
     background:transparent url('image/accord1.png') center top no-repeat;
}

.accord:hover {
   background-image: url('image/accord2.png');
}
</style>

</asp:Content>