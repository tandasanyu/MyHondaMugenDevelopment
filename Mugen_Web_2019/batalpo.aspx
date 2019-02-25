<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="batalpo.aspx.cs" Inherits="batalpo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen :: Waiting Purchase Order</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
     <link href="css/datepicker.css" rel="stylesheet" />
    <script language=javascript>    
    function upper(ustr)
    {
        var str=ustr.value;
        ustr.value=str.toUpperCase();
    }
   
function Angka(a)
{
	if(!/^[0-9.]+$/.test(a.value))
	{
	a.value = a.value.substring(0,a.value.length-1000);
	}
}
</script>
    <style>
       #reject {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}

.windowreject
{
position:relative;	
width: 30%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}

#reject:target {
visibility: visible;
}
   
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <form id="form1" runat="server">
     <div class="container-fluid">
     <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
  <li><a href="mintabeli.aspx"><span class="glyphicon glyphicon-comment"></span>&nbsp;&nbsp;Form Permintaan Pembelian</a></li>
 <li><span class="glyphicon glyphicon-list-alt"></span>&nbsp;&nbsp;Purchase Order</li>
  <li><span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Batal Purchase Order</li>
</ol>
         <asp:TextBox ID="txtCariPo" Class="form-control input-sm" Style="width:50%;margin:2px;" placeholder="No. Purchase Order..." runat="server"></asp:TextBox>
         <asp:Button ID="btnCariPo" class="btn btn-primary btn-sm" Style="text-align:center;margin:2px;" runat="server" Text="Cari Item Purchase Order" OnClick="btnCariPo_Click" />
     
      <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource5" 
             class="table table-bordered" 
             style="width:100%;margin:0px;padding:0px;font-size:9pt;" CellPadding="4" 
             ForeColor="#333333" GridLines="None" EnableModelValidation="True">
          <RowStyle BackColor="#EFF3FB" />
          <Columns>
           <asp:TemplateField HeaderText="No." SortExpression="total" HeaderStyle-Width="5">
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="No. Purchase Order" SortExpression="nopurchaseorder">
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Bind("nopurchaseorder") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Nama Barang" SortExpression="namaitem">
                  <ItemTemplate>
                     </ul> <asp:Label ID="Label3" runat="server" Text='<%# Bind("namaitem") %>' style="font-size:8pt;"></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Tujuan Pembelian" SortExpression="tujuanitem">
                  <ItemTemplate>
                    </ul> <asp:Label ID="Label3" runat="server" Text='<%# Bind("tujuanitem") %>' style="font-size:8pt;"></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Pusat Biaya & Vendor" SortExpression="disetujui2fmb">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label17" runat="server" Text='<%# Bind("pusatbiaya") %>' style="font-size:8pt;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label18" runat="server" Text='<%# Bind("vendor") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Qty" SortExpression="disetujuifmb">
                  <ItemTemplate>
                     </ul> <asp:Label ID="Label3" runat="server" Text='<%# Bind("jumlahitem") %>' style="font-weight:bold;"></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Harga" SortExpression="total">
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("hargaitem", "{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Total" SortExpression="total">
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("total", "{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderStyle-Width="5">
                  <ItemTemplate>
                      <asp:HyperLink ID="HyperLink1" runat="server" 
                          NavigateUrl='<%# "batalpo.aspx?q=" + Eval("nopurchaseorder") + "&&idbody=" + Eval("idbody") + "&&nobody="  + Eval("nobody") + "#reject" %>' Target="_self" Text="<span class='glyphicon glyphicon-remove'></span>&nbsp;Batalkan" class="btn btn-danger btn-sm" style="font-weight:bold;"></asp:HyperLink>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditRowStyle BackColor="#2461BF" />
          <AlternatingRowStyle BackColor="White" />
      </asp:GridView>
       
      <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
          ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
         SelectCommand="SELECT *, jumlahitem * hargaitem AS total FROM fmbbody WHERE (nopurchaseorder = @nopo) AND rejectoleh IS NULL AND jumlahterima = '0'">
                <SelectParameters>
                    <asp:QueryStringParameter Name="nopo" QueryStringField="q" Type="String" />
                </SelectParameters>
      </asp:SqlDataSource>

           <div id="reject">
 <div class="windowreject">
 <div class="panel panel-primary" style="width:100%;margin:3px;text-align:center;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-remove"></span> Batal Purchase Order<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table>
    <tr>
        <td><asp:TextBox ID="txtIdRejectPurchasing" runat="server" Visible="False"></asp:TextBox></td>
    </tr>
     <tr>
         <td>
           <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-dashboard"></span></div><asp:TextBox ID="txtJumlahBatal" class="form-control" runat="server" onkeyup="Angka(this)" placeholder="Jumlah..." style="width:100px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td>
           <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></div><asp:TextBox ID="txtAlasanBatal" class="form-control" runat="server" onkeyup="upper(this)" placeholder="Alasan Reject..." style="width:280px;position:relative;"></asp:TextBox></div></td>
     </tr>
     <tr>
         <td><asp:Button ID="btnBtlPo" runat="server" Text="Batalkan" 
                 class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" OnClick="btnBtlPo_Click" /></td>
                  <tr>
         <td></td>
         <td></td>
         <td>
             <asp:Label ID="Label20" runat="server" Text=""></asp:Label></td>
     </tr>
    </table>
  </div>
  </div>
 </div>
 </div>
                     
                     </form>
                     </div>

                       <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
</asp:Content>

