<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="cariChecklist.aspx.vb" Inherits="cariChecklist" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <div class="container">
        <center>    
            <h2>Cari Form Ceklist</h2>
        </center>
	</div>
   
	<div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">
                  Cari Berdasarkan No Polisi
                </h4>
            </div>
		</div>	 
		
        <form id="form1" class="form-horizontal" runat="server">
         
		    <div class="form-group">
			    <label class="control-label col-sm-3" for="nopol">No Polisi</label>
                <div class="col-sm-4">
				    <asp:TextBox ID="nopol" style="text-transform: uppercase;" class="form-control required"  runat="server"></asp:TextBox>	
			    </div>
		    </div><br />
             <div class="form-group">
			    <label class="control-label col-sm-3" for="nopol">Tanggal Masuk </label>
                <div class="col-sm-4">
				    <asp:TextBox ID="tglMasuk" class="form-control required"  readonly="true" runat="server"></asp:TextBox>	
			    </div>
                <div class="col-sm-1">
                    <asp:Button ID="Button5" runat="server" onclick="Button5_Click" Text="..." /> 
	            </div>
		    </div>
                <asp:Calendar ID="Calendar1" style="margin-left:400px" class="datepicker" runat="server" onselectionchanged="Calendar1_SelectionChanged" />
           <center>  &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp 
            
                    <asp:Button ID="cari" runat="server" Class="btn btn-primary" Text="Cari" onclick="cari_Click" />
			    </center>
        </form>
        </div>

</asp:Content>

