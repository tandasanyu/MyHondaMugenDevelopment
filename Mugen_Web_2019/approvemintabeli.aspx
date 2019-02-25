<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="approvemintabeli.aspx.cs" Inherits="approvemintabeli" %>

<asp:Content ID="headBeranda" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen :: Approval Permintaan Pembelian</title>
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
    #popup {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}

.window 
{
position:relative;	
width: 90%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: center;
margin: 2% auto;
}

.close-button {
width: 20px;
height: 20px;
background: #000;
border-radius: 50%;
border: 3px solid #fff;
display: block;
text-align: center;
color: #fff;
text-decoration: none;
position: absolute;
top: -10px;
right: -10px;
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
}

.window2 
{
position:relative;	
width: 90%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: center;
margin: 2% auto;
}

#popup2:target {
visibility: visible;
}

   #popup3 {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}

.window3 
{
position:relative;	
width: 90%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: center;
margin: 2% auto;
}

#popup3:target {
visibility: visible;
}
  </style>
</asp:Content>
 <asp:Content ID="bodySesuaiHalaman" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
     <div class="container-fluid">
     <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
  <li><a href="#"><span class="glyphicon glyphicon-book"></span>&nbsp;&nbsp;IT / GA & PO</a></li>
  <li><a href="mintabeli.aspx"><span class="glyphicon glyphicon-usd"></span>&nbsp;&nbsp;Permintaan Pembelian (Purchase Order)</a></li>
  <li><span class="glyphicon glyphicon-ok"></span>&nbsp;&nbsp;Approval Form Permintaan Pembelian</li>
</ol>

  <div class="panel panel-primary" style="width:50%;margin:0px;" ID="divisiApproval" runat="server">
  <div class="panel-heading"><span class="glyphicon glyphicon-ok"></span> Division Maintenance Approval</div>
  <div class="panel-body" style="padding:0px;">
      <asp:GridView ID="GridView8" runat="server" AllowPaging="True" 
          AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource8" class="table table-bordered" style="width:100%;margin:0px;padding:0px;font-size:9pt;">
          <Columns>
          <asp:TemplateField HeaderText="No." SortExpression="nofmbhead" HeaderStyle-Width="5">
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                  </ItemTemplate>
                 
              </asp:TemplateField>
              <asp:TemplateField HeaderText="No. Bukti" SortExpression="nofmbhead">
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Bind("nofmbhead") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nofmbhead") %>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Pemohon" SortExpression="pemohonfmb">
                  <ItemTemplate>
                      <asp:Label ID="Label3" runat="server" Text='<%# Bind("userfmb") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("userfmb") %>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Total" SortExpression="total" HeaderStyle-Width="12">
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("total", "{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("total") %>'></asp:Label>
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderStyle-Width="5">
                  <ItemTemplate >
                      <asp:HyperLink ID="HyperLink1" runat="server" 
                          NavigateUrl='<%# "viewmintabeli.aspx?app0=" + Eval("nofmbhead") + "&&aks=divisiapproval" %>' Target="_self" Text="<i class='glyphicon glyphicon-eye-open'></i> Lihat Secara Detail" class="btn btn-success btn-xs" style="font-weight:bold;"></asp:HyperLink>
                           
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource8" runat="server" 
          ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
          
          SelectCommand="SELECT fmbhead.nofmbhead, SUM(fmbbody.hargaitem*fmbbody.jumlahitem) AS total, fmbhead.userfmb FROM fmbhead INNER JOIN fmbbody ON fmbhead.nofmbhead = fmbbody.nobody INNER JOIN tb_user ON fmbhead.pemohonfmb = tb_user.username INNER JOIN divisi ON tb_user.kddivisi = divisi.kddivisi WHERE (namadivisi = @ses AND rejecthead = 'N' AND divisiapprove IS NULL) AND rejectoleh IS NULL GROUP BY fmbhead.nofmbhead, fmbhead.userfmb">
     <SelectParameters>
              <asp:SessionParameter Name="ses" SessionField="username" Type="String" />
          </SelectParameters>
           </asp:SqlDataSource>
  </div>
</div>  

   <div class="panel panel-primary" style="width:50%;margin:0px;" ID="headApproval" runat="server">
  <div class="panel-heading"><span class="glyphicon glyphicon-ok"></span> Head Approval</div>
  <div class="panel-body" style="padding:0px;">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Timer ID="Timer1" runat="server" OnTick="GetTime" Interval="1000" />
      <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
          AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" class="table table-bordered" style="width:100%;margin:0px;padding:0px;font-size:9pt;">
          <Columns>
          <asp:TemplateField HeaderText="No." SortExpression="nofmbhead" HeaderStyle-Width="5">
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                  </ItemTemplate>
                 
              </asp:TemplateField>
              <asp:TemplateField HeaderText="No. Bukti" SortExpression="nofmbhead">
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Bind("nofmbhead") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nofmbhead") %>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Pemohon" SortExpression="pemohonfmb">
                  <ItemTemplate>
                      <asp:Label ID="Label3" runat="server" Text='<%# Bind("userfmb") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("userfmb") %>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Total" SortExpression="total" HeaderStyle-Width="12">
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("total", "{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("total") %>'></asp:Label>
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderStyle-Width="5">
                  <ItemTemplate >
                      <asp:HyperLink ID="HyperLink1" runat="server" 
                          NavigateUrl='<%# "viewmintabeli.aspx?app1=" + Eval("nofmbhead") + "&&aks=headapproval" %>' Target="_self" Text="<i class='glyphicon glyphicon-eye-open'></i> Lihat Secara Detail" class="btn btn-success btn-xs" style="font-weight:bold;"></asp:HyperLink>
                           
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
      </asp:GridView>
          </ContentTemplate>
</asp:UpdatePanel>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
          ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
          
          SelectCommand="SELECT fmbhead.nofmbhead, SUM(fmbbody.hargaitem*fmbbody.jumlahitem) AS total, fmbhead.userfmb FROM fmbhead INNER JOIN fmbbody ON fmbhead.nofmbhead = fmbbody.nobody INNER JOIN tb_user ON fmbhead.pemohonfmb = tb_user.username INNER JOIN divisi ON tb_user.kddivisi = divisi.kddivisi WHERE (headdivisi = @ses AND disetujuifmb IS NULL AND rejecthead = 'N') AND rejectoleh IS NULL GROUP BY fmbhead.nofmbhead, fmbhead.userfmb, fmbbody.rejectoleh">
     <SelectParameters>
              <asp:SessionParameter Name="ses" SessionField="username" Type="String" />
          </SelectParameters>
           </asp:SqlDataSource>
  </div>
</div>  

<div class="panel panel-primary" style="width:100%;margin-top:10px;" ID="purChasing" runat="server">
  <div class="panel-heading"><span class="glyphicon glyphicon-barcode"></span> Purchasing Approval</div>
  <div class="panel-body" style="padding:0px;">
      <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
          AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" class="table table-bordered" style="width:100%;margin:0px;padding:0px;font-size:9pt;">
          <Columns>
          <asp:TemplateField HeaderText="No." SortExpression="nofmbhead">
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="No. Bukti" SortExpression="nofmbhead">
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Bind("nofmbhead") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nofmbhead") %>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Pemohon" SortExpression="pemohonfmb">
                  <ItemTemplate>
                      <asp:Label ID="Label3" runat="server" Text='<%# Bind("userfmb") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("userfmb") %>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Total" SortExpression="total">
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("total", "{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("total") %>'></asp:Label>
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                  <ItemTemplate>
                      <asp:HyperLink ID="HyperLink1" runat="server" 
                          NavigateUrl='<%# "viewmintabeli.aspx?app2=" + Eval("nofmbhead") + "&&aks=purchasing" %>' Target="_self" Text="<i class='glyphicon glyphicon-eye-open'></i> Lihat Secara Detail" class="btn btn-success btn-xs" style="font-family:Verdana;"></asp:HyperLink>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
          ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
          
          SelectCommand="SELECT fmbhead.nofmbhead, SUM(fmbbody.hargaitem*fmbbody.jumlahitem) AS total, fmbhead.userfmb FROM fmbhead INNER JOIN fmbbody ON fmbhead.nofmbhead = fmbbody.nobody WHERE (disetujuifmb IS NOT NULL AND divisiapprove IS NULL AND (namadivisi IS NULL or namadivisi='') AND mengetahuifmb IS NULL AND rejecthead = 'N') OR (disetujuifmb IS NOT NULL AND divisiapprove IS NOT NULL AND namadivisi IS NOT NULL AND mengetahuifmb IS NULL AND rejecthead = 'N') AND rejectoleh IS NULL GROUP BY fmbhead.nofmbhead, fmbhead.userfmb">
      </asp:SqlDataSource>
  </div>
</div>

<div class="panel panel-primary" style="width:100%;margin-top:10px;" ID="headPur" runat="server">
  <div class="panel-heading"><span class="glyphicon glyphicon-qrcode"></span> Head Purchasing Approval</div>
  <div class="panel-body" style="padding:0px;">
      <asp:GridView ID="GridView7" runat="server" AllowPaging="True" 
          AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource7" class="table table-bordered" style="width:100%;margin:0px;padding:0px;font-size:9pt;">
          <Columns>
          <asp:TemplateField HeaderText="No." SortExpression="nofmbhead" HeaderStyle-Width="5">
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="No. Bukti" SortExpression="nofmbhead">
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Bind("nofmbhead") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nofmbhead") %>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Pemohon" SortExpression="pemohonfmb">
                  <ItemTemplate>
                      <asp:Label ID="Label3" runat="server" Text='<%# Bind("userfmb") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("userfmb") %>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
              
              <asp:TemplateField HeaderText="Total" SortExpression="total">
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("total", "{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("total") %>'></asp:Label>
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                  <ItemTemplate>
                      <asp:HyperLink ID="HyperLink1" runat="server" 
                          NavigateUrl='<%# "viewmintabeli.aspx?app3=" + Eval("nofmbhead") + "&&aks=headpur" %>' Target="_self" Text="<i class='glyphicon glyphicon-eye-open'></i> Lihat Secara Detail" class="btn btn-success btn-xs" style="font-family:Verdana;"></asp:HyperLink>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
          ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
          
          SelectCommand="SELECT fmbhead.nofmbhead, SUM(fmbbody.hargaitem*fmbbody.jumlahitem) AS total, fmbhead.userfmb, fmbbody.rejectoleh FROM fmbhead INNER JOIN fmbbody ON fmbhead.nofmbhead = fmbbody.nobody WHERE disetujuifmb IS NOT NULL AND mengetahuifmb IS NOT NULL AND approveheadpurc IS NULL AND rejecthead = 'N' AND rejectoleh IS NULL  GROUP BY fmbhead.nofmbhead, fmbhead.userfmb, fmbbody.rejectoleh ORDER BY nofmbhead ASC">
      </asp:SqlDataSource>
  </div>
</div>

<div class="panel panel-primary" style="width:100%;" ID="vicePresident" runat="server">
  <div class="panel-heading"><span class="glyphicon glyphicon-knight"></span> Menyetujui Vice President</div>
  <div class="panel-body" style="padding:0px;">
      <asp:GridView ID="GridView5" runat="server" AllowPaging="True" 
          AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource5" class="table table-bordered" style="width:100%;margin:0px;padding:0px;font-size:9pt;">
          <Columns>
           <asp:TemplateField HeaderText="No." SortExpression="total" HeaderStyle-Width="5">
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="No. Bukti" SortExpression="nofmbhead">
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Bind("nofmbhead") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nofmbhead") %>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
             
              <asp:TemplateField HeaderText="Pemohon" SortExpression="pemohonfmb">
                  <ItemTemplate>
                      <asp:Label ID="Label3" runat="server" Text='<%# Bind("userfmb") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("userfmb") %>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Total" SortExpression="total">
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("total", "{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("total") %>'></asp:Label>
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                  <ItemTemplate>
                      <asp:HyperLink ID="HyperLink1" runat="server" 
                          NavigateUrl='<%# "viewmintabeli.aspx?app4=" + Eval("nofmbhead") + "&&aks=vpapp" %>' Target="_self" Text="<i class='glyphicon glyphicon-eye-open'></i> Lihat Secara Detail" class="btn btn-success btn-xs" style="font-weight:bold;"></asp:HyperLink>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
          ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
          
          
          SelectCommand="SELECT fmbhead.nofmbhead, SUM(fmbbody.hargaitem*fmbbody.jumlahitem) AS total, fmbhead.userfmb FROM fmbhead INNER JOIN fmbbody ON fmbhead.nofmbhead = fmbbody.nobody WHERE (fmbhead.approveheadpurc IS NOT NULL) AND (fmbhead.mengetahuifmb IS NOT NULL) AND (fmbhead.disetujui2fmb IS NULL) AND rejectoleh IS NULL  GROUP BY fmbhead.nofmbhead, fmbbody.rejectoleh, fmbhead.userfmb HAVING (SUM(fmbbody.hargaitem*fmbbody.jumlahitem) &gt; 1999999)">
      </asp:SqlDataSource>
  </div>
</div>

      <div id="popup">
 <div class="window">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
  <div class="panel-heading"><span class="glyphicon glyphicon-ok"></span> Approval</div>
  <div class="panel-body">
      <div class="kirih" style="float:left;width:25%;height:100px;padding:20px;">
         <asp:Image ID="Image1" runat="server" ImageUrl="~/img/hlogo.png" style="width:80px;height:60px;float:left;"/>
    </div>
    <div class="kirih" style="float:left;width:50%;height:100px;font-weight:bold;text-align:center;
    padding-top:50px;font-size:14pt;text-transform:uppercase;">
        <asp:Label ID="Label1" runat="server" Text="Permintaan Pembelian"></asp:Label>    
        </div>
        <div class="kirih" style="float:left;width:25%;height:100px;">
        <asp:Label ID="Label2" runat="server" Text="Honda Mugen" style="font-weight:bold;"></asp:Label><br />    
        <asp:Label ID="Label3" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:8pt;"></asp:Label><br />    
        <asp:Label ID="Label4" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label5" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label6" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label7" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:8pt;"></asp:Label>            
     </div>
         <asp:Button ID="btnTambah" runat="server" Text="Approve" class="btn btn-success btn-sm" 
                         style="margin:5px;font-weight:bold;font-family:Tahoma;" 
          onclick="btnTambah_Click" />
         <asp:Button ID="btnSelesai" runat="server" Text="Close" 
                         class="btn btn-danger btn-sm" 
          style="font-weight:bold;font-family:Tahoma;" onclick="btnSelesai_Click" />
                 
         <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" 
                         class="table table-bordered" 
          style="margin:5px;font-size:9pt;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
              <asp:TemplateField HeaderText="No" SortExpression="namaitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label0" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama Item" SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("namaitem") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan" SortExpression="tujuanitem">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Pusat Biaya" SortExpression="pusatbiaya" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("pusatbiaya") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("pusatbiaya") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qty" SortExpression="jumlahitem" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("jumlahitem") %> '></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("jumlahitem") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("hargaitem", "{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("hargaitem") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                   <asp:TemplateField HeaderText="Total" SortExpression="totl" HeaderStyle-Width="12">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("totl", "{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("totl") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="White" />
         </asp:GridView>
         
                     <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         
          SelectCommand="SELECT [namaitem], [tujuanitem], [jumlahitem], [hargaitem], [pusatbiaya], [jumlahitem] * [hargaitem] AS totl FROM [fmbbody] WHERE ([nobody] = @nobody)">
                         <SelectParameters>
                             <asp:QueryStringParameter Name="nobody" QueryStringField="app1" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                      <table style="width:70%;float:left;margin-left:5px;font-size:8pt;color:blue;font-family:Verdana;">
                      <tr><td>Note : Untuk pembelian diatas Rp. 2.000.000,- harus mendapat persetujuan dari Vice President Director</td></tr>
                        </table>
                     <table style="width:26%;float:right;border:1px solid #c0c0c0;" border="1">
                     <tr><td style="width:50%;padding:5px;text-align:right;font-weight:bold;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">TOTAL :</td>
                     <td style="width:50%;padding:5px;text-align:center;font-weight:bold;font-size:12pt;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">
                     <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                     </td></tr></table>
                  
  </div>
  </div>
 </div>
 </div>    
 
 
  <div id="popup2">
 <div class="window2">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
  <div class="panel-heading"><span class="glyphicon glyphicon-ok"></span> Approval</div>
  <div class="panel-body">
      <div class="kirih" style="float:left;width:25%;height:100px;padding:20px;">
         <asp:Image ID="Image2" runat="server" ImageUrl="~/img/hlogo.png" style="width:80px;height:60px;float:left;"/>
    </div>
    <div class="kirih" style="float:left;width:50%;height:100px;font-weight:bold;text-align:center;
    padding-top:50px;font-size:14pt;text-transform:uppercase;">
        <asp:Label ID="Label8" runat="server" Text="Permintaan Pembelian"></asp:Label>    
        </div>
        <div class="kirih" style="float:left;width:25%;height:100px;">
        <asp:Label ID="Label9" runat="server" Text="Honda Mugen" style="font-weight:bold;"></asp:Label><br />    
        <asp:Label ID="Label10" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:8pt;"></asp:Label><br />    
        <asp:Label ID="Label11" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label12" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label13" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label14" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:8pt;"></asp:Label>            
     </div>
         <asp:Button ID="Button1" runat="server" Text="Approve" class="btn btn-success btn-sm" 
                         style="margin:5px;font-weight:bold;font-family:Tahoma;" 
          onclick="Button1_Click"  />
         <asp:Button ID="Button2" runat="server" Text="Close" 
                         class="btn btn-danger btn-sm" 
          style="font-weight:bold;font-family:Tahoma;" onclick="Button2_Click" />
                 
         <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" 
                         class="table table-bordered" 
          style="margin:5px;font-size:9pt;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
             <asp:TemplateField HeaderText="No." SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label0" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama" SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("namaitem") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan" SortExpression="tujuanitem">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Jumlah" SortExpression="jumlahitem">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("jumlahitem") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("jumlahitem") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("hargaitem", "{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("hargaitem") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Total" SortExpression="totl2">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("totl2", "{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("totl2") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="White" />
         </asp:GridView>
         
                     <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         
          SelectCommand="SELECT [namaitem], [tujuanitem], [jumlahitem], [hargaitem], [jumlahitem] * [hargaitem] AS totl2 FROM [fmbbody] WHERE ([nobody] = @nobody)">
                         <SelectParameters>
                             <asp:QueryStringParameter Name="nobody" QueryStringField="app2" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                      <table style="width:70%;float:left;margin-left:5px;font-size:8pt;color:blue;font-family:Verdana;">
                      <tr><td>Note : Untuk pembelian diatas Rp. 2.000.000,- harus mendapat persetujuan dari Vice President Director</td></tr>
                        </table>
                     <table style="width:26%;float:right;border:1px solid #c0c0c0;" border="1">
                     <tr><td style="width:50%;padding:5px;text-align:right;font-weight:bold;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">TOTAL :</td>
                     <td style="width:50%;padding:5px;text-align:center;font-weight:bold;font-size:12pt;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">
                     <asp:Label ID="lblTotal2" runat="server" Text=""></asp:Label>
                     </td></tr></table>
  </div>
  </div>
 </div>
 </div>        
 
 <div id="popup3">
 <div class="window3">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
  <div class="panel-heading"><span class="glyphicon glyphicon-ok"></span> Approval</div>
  <div class="panel-body">
      <div class="kirih" style="float:left;width:25%;height:100px;padding:20px;">
         <asp:Image ID="Image3" runat="server" ImageUrl="~/img/hlogo.png" style="width:80px;height:60px;float:left;"/>
    </div>
    <div class="kirih" style="float:left;width:50%;height:100px;font-weight:bold;text-align:center;
    padding-top:50px;font-size:14pt;text-transform:uppercase;">
        <asp:Label ID="Label15" runat="server" Text="Permintaan Pembelian"></asp:Label>    
        </div>
        <div class="kirih" style="float:left;width:25%;height:100px;">
        <asp:Label ID="Label16" runat="server" Text="Honda Mugen" style="font-weight:bold;"></asp:Label><br />    
        <asp:Label ID="Label17" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:8pt;"></asp:Label><br />    
        <asp:Label ID="Label18" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label19" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label20" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:8pt;"></asp:Label><br />      
        <asp:Label ID="Label21" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:8pt;"></asp:Label>            
     </div>
         <asp:Button ID="Button3" runat="server" Text="Approve" class="btn btn-success btn-sm" 
                         style="margin:5px;font-weight:bold;font-family:Tahoma;" 
          onclick="Button3_Click" />
         <asp:Button ID="Button4" runat="server" Text="Close" 
                         class="btn btn-danger btn-sm" 
          style="font-weight:bold;font-family:Tahoma;" onclick="Button4_Click"  />
                 
         <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource6" 
                         class="table table-bordered" 
          style="margin:5px;font-size:9pt;" CellPadding="4" 
                         ForeColor="#333333" GridLines="None">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
             <asp:TemplateField HeaderText="No." SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label0" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama" SortExpression="namaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("namaitem") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("namaitem") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tujuan" SortExpression="tujuanitem">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("tujuanitem") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Jumlah" SortExpression="jumlahitem">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("jumlahitem") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("jumlahitem") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("hargaitem", "{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("hargaitem") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Total" SortExpression="totl2">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("totl3", "{0:0,0}") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("totl3") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="White" />
         </asp:GridView>
         
                     <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         
                         
          SelectCommand="SELECT [namaitem], [tujuanitem], [jumlahitem], [hargaitem], [jumlahitem] * [hargaitem] AS totl3 FROM [fmbbody] WHERE ([nobody] = @nobody)">
                         <SelectParameters>
                             <asp:QueryStringParameter Name="nobody" QueryStringField="app3" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                      <table style="width:70%;float:left;margin-left:5px;font-size:8pt;color:blue;font-family:Verdana;">
                      <tr><td>Note : Untuk pembelian diatas Rp. 2.000.000,- harus mendapat persetujuan dari Vice President Director</td></tr>
                        </table>
                     <table style="width:26%;float:right;border:1px solid #c0c0c0;" border="1">
                     <tr><td style="width:50%;padding:5px;text-align:right;font-weight:bold;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">TOTAL :</td>
                     <td style="width:50%;padding:5px;text-align:center;font-weight:bold;font-size:12pt;background:#f5f5f5;font-family:Tahoma;border-bottom: 3px double #c0c0c0;border-top: 3px double #c0c0c0;">
                     <asp:Label ID="lblTotal4" runat="server" Text=""></asp:Label>
                     </td></tr></table>
  </div>
  </div>
 </div>
 </div> 
    <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
    </form>
   </asp:Content>
