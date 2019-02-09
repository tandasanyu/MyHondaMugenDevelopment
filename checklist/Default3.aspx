<%@ Page Language="VB"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default3.aspx.vb" Inherits="Default3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
<body>
   

    <form id="form1" runat="server" class="form-horizontal">
<div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">
                    Aksesoris Kendaraan 
                </h4>
            </div>
	    </div>	 
         <div style="margin-left:-40px">
	        <div class="table table-responsive">
                <asp:SqlDataSource ID="dataAksesoris" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet3 %>" SelectCommand="SELECT * FROM [DATA_MOBIL] WHERE ([noRangka] = ?)" ProviderName="<%$ ConnectionStrings:MyConnCloudDnet3.ProviderName %>">
                    <selectparameters>
                        <asp:ControlParameter ControlID="noRangka" Name="noRangka"       PropertyName= "Text" Type="String" />            
                       
                    </selectparameters>
                </asp:SqlDataSource>    

                <asp:ListView  runat="server" DataSourceID="dataAksesoris" >
	                <LayoutTemplate>
				        <table class="table table-bordered striped">
				            <thead  style="background-color:#E8E8E8">
						        <th align="center">No</th>
		                        <th class="col-md-4" align="center">No Rangka</th>
                                <th align="center">Tanggal</th>
		                        <th class="col-md-2" align="center">Status</th>
                                <th class="col-md-2" align="center">Keterangan</th>
				            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
				        </table>
			        </LayoutTemplate>
                     
			        <ItemTemplate>
				        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
					        <td><%#Eval("noRangka")%></td>
                            <td><%#Eval("tanggal")%></td>
                            <td><%#Eval("status")%></td>
                            <td><%#Eval("keterangan")%></td>
    
				        </tr>
			        </ItemTemplate>
		        </asp:ListView>
	        </div>
        </div>	

    <div class="row">
            <div class="col-lg-12">
                <h4 class="page-header">
                    Aksesoris Kendaraan
                </h4>
            </div>
	    </div>	 

        
   <div class="form-group">
			<label class="control-label col-sm-2" for="nopol">No Rangka</label>
            <div class="col-sm-4">
				<asp:TextBox ID="noRangka" class="form-control" readonly="true" runat="server"></asp:TextBox>	
			</div>
			<asp:Label ID="nopolNotice" runat="server" style="color:red"></asp:Label>
		</div>
        <div class="form-group">
			<label class="control-label col-sm-2" for="nopol">Tanggal(<font color="red">*</font>)</label>
            <div class="col-sm-4">
				<asp:TextBox ID="tglKedatangan" class="form-control"  ReadOnly="true" runat="server"></asp:TextBox>	
			</div>
		</div>

		<div class="form-group">
			<label class="control-label col-sm-2" for="nopol">Status</label>
			<div class="col-sm-4">
				<asp:DropDownList ID="status" class="form-control" runat="server">
                    <asp:ListItem Value="Masuk">Masuk</asp:ListItem>
                    <asp:ListItem Value="Keluar">Keluar</asp:ListItem>
                    <asp:ListItem Value="Pameran">Pameran</asp:ListItem>
                </asp:DropDownList>
			</div>
		</div>
</div>
    </form>
</asp:Content>

