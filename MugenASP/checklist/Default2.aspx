<%@ Page Language="VB"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
<body><form id="form1" runat="server">
    <iframe width="1200" height="350" src="https://zxing.org/w/decode.jspx" frameborder="0" allowfullscreen></iframe>
	<br><br>
    
    <div>
        <div class="container">
         <div class="form-group">
			<label class="control-label col-sm-2" for="nopol">No Rangka</label>
            <div class="col-sm-4">
				<asp:TextBox ID="noRangka" class="form-control" runat="server"></asp:TextBox>
                <asp:TextBox ID="result" class="form-control" text="MHRDG1850HJ604101" runat="server"></asp:TextBox>	
			</div>
			<asp:Label ID="nopolNotice" runat="server" style="color:red"></asp:Label>
		</div>
	  <asp:Button ID="cari" runat="server" Class="btn btn-primary" Text="Cari" onclick="cari_Click" />
    </div>
        </div>
    </form>
    <script>

    document.getElementById('<%= form1.ClientID %>').onload = function () { myFunction() };
        function myFunction() {
            var coba = document.getElementById('<%= result.ClientID %>');
        alert("hey");
    }
   
</script>
</asp:Content>

