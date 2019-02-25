<%@ Page Language="C#" AutoEventWireup="true" CodeFile="liststok.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
     <link href="css/datepicker.css" rel="stylesheet" />
    <title>List Stok</title>
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
    <style type="text/css">
        .gridview{
    background-color:#FFCC66;
   padding:2px;
   margin:5px auto;  
   font-family:Tahoma;
}
        .gridview a{
  margin:auto 1%;
  border-left: 1px solid #c0c0c0;
      background-color:#EFF3FB;
      padding:2px 7px 2px 7px;
      color:#333;
      text-decoration:none;
      -o-box-shadow:0px 1px 1px #c0c0c0;
      -moz-box-shadow:0px 1px 1px #c0c0c0;
      -webkit-box-shadow:0px 1px 1px #c0c0c0;
      box-shadow:0px 1px 1px #c0c0c0;
     
}
        .gridview a:hover{
    background-color:#c0c0c0;
    color:#fff;
}
        .gridview span{
    background-color:#c0c0c0;
    color:#fff;
     -o-box-shadow:1px 1px 1px #333;
      -moz-box-shadow:1px 1px 1px #333;
      -webkit-box-shadow:1px 1px 1px #333;
      box-shadow:1px 1px 1px #333;
      padding:2px 7px 2px 7px;
}
         #popup {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;

overflow: auto;
}

.window 
{
position:relative;	
width: 35%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}

#popup:target {
visibility: visible;
}
    #popup2 {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;

overflow: auto;
}

.window2 
{
position:relative;	
width: 35%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}

#popup2:target {
visibility: visible;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       

<!-- Modal -->

<div class="modal fade primar" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
  <div class="modal-dialog" role="document" style="width:55%;position:relative;">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="exampleModalLabel"><span class="glyphicon glyphicon-share-alt"></span>&nbsp;&nbsp;Hand Over</h4>
      </div>
      <div class="modal-body">
          <div class="form-group">
              <asp:TextBox ID="txtIdKeluar" runat="server" CssClass="form-control" Style="width:50px;"></asp:TextBox>
          </div>
          <div class="form-group">
              Jumlah :
             <asp:TextBox ID="txtJumlahKeluar" class="form-control" onkeyup="Angka(this)" Style="width:100px;" placeholder="Jumlah.." runat="server" ></asp:TextBox>
          </div>
          <div class="form-group">
              Nama Penerima :
             <asp:TextBox ID="txtNamaKeluar" class="form-control" onkeyup="upper(this)" placeholder="Nama yang menerima.." runat="server" ></asp:TextBox>
          </div>
          
          <div class="form-group">
              Departemen :
              <asp:DropDownList ID="txtDivisi" class="form-control" runat="server">
                             <asp:ListItem></asp:ListItem>
                             <asp:ListItem Value="ACC">Accounting</asp:ListItem>
                             <asp:ListItem Value="SRV">Service</asp:ListItem>
                             <asp:ListItem Value="HRD">HRD &amp; GA</asp:ListItem>
                             <asp:ListItem>IT</asp:ListItem>
                             <asp:ListItem Value="SLS">Showroom</asp:ListItem>
                             <asp:ListItem Value="PRC">Purchasing</asp:ListItem>
                             <asp:ListItem Value="ADM">Admin</asp:ListItem>
                             <asp:ListItem Value="CCO">Customer Care Officer</asp:ListItem>
                             <asp:ListItem Value="AUD">Auditor</asp:ListItem>
                             <asp:ListItem>ISO</asp:ListItem>
                         </asp:DropDownList>
          </div>
         <center> <asp:Button ID="btnKeluar" runat="server" Text="SERAHKAN" class="btn btn-primary btn-sm" Style="font-weight:bold;" OnClick="btnKeluar_Click" /></center>
        <center><asp:Label ID="lblAlert" runat="server" Text="Anda tidak memiliki Akses untuk mengeluarkan stok, terimakasih." Class="alert alert-danger" Style="margin:10px;"></asp:Label></center>
      </div>
    </div>
  </div>
</div>
        <div class="kirih" style="float:left;width:20%;height:100px;padding:20px;">
         <asp:Image ID="Image1" runat="server" ImageUrl="~/img/hlogo.png" style="width:80px;height:60px;float:left;"/>
    </div>
    <div class="kirih" style="float:left;width:48%;height:100px;font-weight:bold;text-align:center;margin-right:20px;
    padding-top:50px;font-size:14pt;text-transform:uppercase;">
       <u> <asp:Label ID="Label1" runat="server" Text="Daftar Stok" style="font-size:1.0em;"></asp:Label></u>  <br />
        <asp:Label ID="Label8" runat="server" Text="Daftar barang yg sudah diterima dari Vendor dan siap di hand over ke user" style="font-size:0.65em;font-weight:normal;"></asp:Label>    
        </div>
        <div class="kirih" style="float:right;width:25%;height:100px;margin-bottom:25px;">
        <asp:Label ID="Label2" runat="server" Text="Honda Mugen" style="font-weight:bold;font-size:1.0em;"></asp:Label><br />    
        <asp:Label ID="Label3" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:0.8em;"></asp:Label><br />    
        <asp:Label ID="Label4" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:0.8em;"></asp:Label><br />      
        <asp:Label ID="Label5" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:0.8em;"></asp:Label><br />      
        <asp:Label ID="Label6" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:0.8em;"></asp:Label><br />      
        <asp:Label ID="Label7" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:0.8em;"></asp:Label>            
     </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Timer ID="Timer1" runat="server" OnTick="GetTime" Interval="500" />
         <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" EnableModelValidation="True" ForeColor="#333333" GridLines="None" PageSize="5" Style="position:relative;width:60%;margin:10px;padding:0;font-size:0.85em;font-family:arial;" class="table table-bordered" AllowSorting="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                  <asp:TemplateField HeaderText="No." SortExpression="nofmbhead" HeaderStyle-Width="5">
                  <ItemTemplate>
                     <center><asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label></center> 
                  </ItemTemplate>
              </asp:TemplateField>
                  <asp:TemplateField HeaderText="Barang" SortExpression="namaitem">
                      <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Jumlah" SortExpression="pofmbout_jumlahkeluar" HeaderStyle-Width="5">
                      <ItemTemplate>
                         <center><asp:Label ID="Label2" runat="server" Text='<%# Bind("pofmbout_jumlahkeluar") %>'></asp:Label></center> 
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Tgl Minta" SortExpression="pofmbout_tglkeluar">
                      <ItemTemplate>
                          <asp:Label ID="Label3" runat="server" Text='<%# Bind("pofmbout_tglkeluar") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="User Pemohon" SortExpression="pofmbout_diserahkan">
                      <ItemTemplate>
                          <asp:Label ID="Label4" runat="server" Text='<%# Bind("pofmbout_diserahkan") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Departmen" SortExpression="pofmbout_departemen">
                      <ItemTemplate>
                          <asp:Label ID="Label5" runat="server" Text='<%# Bind("pofmbout_departemen") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Approval" SortExpression="pofmbout_approval"  HeaderStyle-Width="180">
                      <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "liststok.aspx?q=" + Eval("pofmbout_idpo") + "&&q2=" + Eval("pofmbout_idbody") + "&&q3=" + Eval("pofmbout_jumlahkeluar") + "#popup" %>'
                    Target="_self" Text="<span class='glyphicon glyphicon-ok'></span> APPROVE" class="btn btn-success btn-xs" style="font-family:Verdana;"></asp:HyperLink>
                     
                          <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "liststok.aspx?q=" + Eval("pofmbout_idpo") + "&&q2=" + Eval("pofmbout_idbody") + "#popup2" %>'
                    Target="_self" Text="<span class='glyphicon glyphicon-remove'></span> REJECT" class="btn btn-danger btn-xs" style="font-family:Verdana;"></asp:HyperLink>
                      </ItemTemplate>
                  </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <pagerstyle cssclass="gridview">

</pagerstyle>
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        </asp:GridView>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="2" DataSourceID="SqlDataSource1" EnableModelValidation="True" ForeColor="#333333" GridLines="None" PageSize="50" Style="position:relative;margin-top:10px;padding:0;font-size:0.85em;font-family:arial;" class="table table-bordered">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                  <asp:TemplateField HeaderText="No." SortExpression="nofmbhead" HeaderStyle-Width="5">
                  <ItemTemplate>
                     <center><asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label></center> 
                  </ItemTemplate>
              </asp:TemplateField>
                <asp:TemplateField HeaderText="Nomor PO" SortExpression="POFMB_no_po" HeaderStyle-Width="130">
                    <ItemTemplate>
                        <u><asp:Label ID="Label1" runat="server" Text='<%# Bind("POFMB_no_po") %>' style="color:blue;font-weight:bold;"></asp:Label></u><br />
                        <i><asp:Label ID="Label2" runat="server" Text='<%# Bind("POFMB_tgl_po") %>' style="font-size:8pt;color:#666;"></asp:Label></i>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vendor" SortExpression="POFMB_nama_vendor" HeaderStyle-Width="180">
                    <ItemTemplate>
                        <u><asp:Label ID="Label3" runat="server" Text='<%# Bind("POFMB_nama_vendor") %>' Style="font-size:1.0em;"></asp:Label></u><br />
                        <i>Tel:<asp:Label ID="Label2" runat="server" Text='<%# Bind("vendor_telp") %>' style="font-size:8pt;color:#666;"></asp:Label></i>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pemohon" SortExpression="POFMB_nama_shipper" HeaderStyle-Width="180">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("pemohonfmb") %>' Style="font-size:1.0em;"></asp:Label><br />
                       <i> <asp:Label ID="Label9" runat="server" Text='<%# Bind("tglpemohonfmb") %>' Style="font-size:8pt;color:#666;"></asp:Label></i>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pusat Biaya -- Nama Barang" SortExpression="namaitem">
                    <ItemTemplate>
                        <u><asp:Label ID="Label10" runat="server" Text='<%# "(" + Eval("pusatbiaya") + ")"%>' Style="font-weight:bold;color:#d60000;"></asp:Label></u><br />
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tujuan Beli" SortExpression="namaitem">
                    <ItemTemplate>
                       <asp:Label ID="Label6" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Stok" SortExpression="jumlah" HeaderStyle-Width="5">
                    <ItemTemplate>
                        <center><asp:Label ID="Label7" runat="server" Text='<%# Bind("jumlah") %>' style="font-weight:bold;color:#d60000;font-size:1.35em;"></asp:Label></center>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" HeaderStyle-Width="50">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server"  data-toggle="modal" data-target="#exampleModal" data-val='<%# Eval("idbody")  %>' Text="<span class='glyphicon glyphicon-share-alt'></span>&nbsp;&nbsp;Hand Over" class="btn btn-primary btn-xs" style="font-weight:bold;"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
         </ContentTemplate>
</asp:UpdatePanel>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT vendor_telp, pusatbiaya, tujuanitem, pemohonfmb, tglpemohonfmb, POFMB_no_po, POFMB_tgl_po, POFMB_nama_vendor, jumlahitem, POFMB_nama_shipper, SUM(jumlahterima - jumlahkeluar) AS jumlah, POFMB_shipping_method, namaitem,  idbody, POFMB_shipping_term, jumlahterima FROM fmbbody INNER JOIN pofmb ON pofmb.POFMB_no_po = fmbbody.nopurchaseorder INNER JOIN fmbhead ON fmbbody.nobody = fmbhead.nofmbhead INNER JOIN dbvendor ON pofmb.pofmb_nama_vendor = dbvendor.vendor_nama GROUP BY POFMB_no_po, jumlahitem, POFMB_tgl_po, POFMB_nama_vendor, POFMB_nama_shipper, POFMB_shipping_method, namaitem,  idbody, vendor_telp, POFMB_shipping_term, jumlahterima, pemohonfmb, tglpemohonfmb, pusatbiaya, tujuanitem HAVING(SUM(jumlahitem - jumlahterima) IS NULL OR SUM(jumlahterima - jumlahkeluar) > 0)"></asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT fmbbody.namaitem, pofmbout.pofmbout_jumlahkeluar, pofmbout.pofmbout_idpo, pofmbout.pofmbout_idbody, pofmbout.pofmbout_tglkeluar, pofmbout.pofmbout_diserahkan, pofmbout.pofmbout_departemen, pofmbout.pofmbout_approval FROM fmbbody INNER JOIN pofmbout ON fmbbody.idbody = pofmbout.pofmbout_idbody WHERE (pofmbout.pofmbout_approval IS NULL) ORDER BY pofmbout_tglkeluar DESC"></asp:SqlDataSource>
    </div>
        <div id="popup">
 <div class="window">
 <div class="panel panel-primary" style="width:100%;margin:5px;">
  <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-ok"></span> Approval<button class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</button></div>
  <div class="panel-body">
      <center>
  Apa anda yakin ingin melakukan approval ? Apabila anda melakukan approval stok akan langsung berkurang !
     <asp:Button ID="Button1" runat="server" CssClass="btn btn-success btn-sm" style="font-weight:bold;font-family:Verdana;" Text="Confirm" OnClick="Button1_Click" />
      <asp:Button ID="Button2" runat="server" CssClass="btn btn-danger btn-sm" style="font-weight:bold;font-family:Verdana;" Text="Cancel" /></center> 
      <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="X-Small" 
          ForeColor="Red"></asp:Label>
  </div>
</div></div></div>

         <div id="popup2">
 <div class="window">
 <div class="panel panel-primary" style="width:100%;margin:5px;">
  <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-remove"></span> Reject<button class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</button></div>
  <div class="panel-body">
      <center>
  Apa anda yakin ingin melakukan Reject ?<br />
     <asp:Button ID="Button3" runat="server" CssClass="btn btn-success btn-sm" style="font-weight:bold;font-family:Verdana;" Text="Confirm" OnClick="Button3_Click" />
      <asp:Button ID="Button4" runat="server" CssClass="btn btn-danger btn-sm" style="font-weight:bold;font-family:Verdana;" Text="Cancel" /></center> 
      <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="X-Small" 
          ForeColor="Red"></asp:Label>
  </div>
</div></div></div>
     
    </form>
       <center><asp:Label ID="lblNotif" runat="server" Text="Anda tidak memiliki hak untuk meng-akses menu ini, terimakasih." Class="alert alert-danger" Style="position:relative;top:50px;text-align:center;"></asp:Label></center>
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $('#exampleModal').on('show.bs.modal', function (event) {
            var button = $(event.relatedTarget) // Button that triggered the modal
            var recipient = button.data('val') // Extract info from data-* attributes
            var modal = $(this)
            modal.find('.modal-body #txtIdKeluar').val(recipient)
        })
    </script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>

