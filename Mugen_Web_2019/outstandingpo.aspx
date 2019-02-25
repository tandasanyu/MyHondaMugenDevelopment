<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="outstandingpo.aspx.cs" Inherits="outstandingpo" Title="Untitled Page" %>

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
         #price {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}

.windowprice
{
position:relative;	
width: 25%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}

#price:target {
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
  <li><span class="glyphicon glyphicon-transfer"></span>&nbsp;&nbsp;Waiting Purchase Order</li>
</ol>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Timer ID="Timer1" runat="server" OnTick="GetTime" Interval="1000" />
      <asp:GridView ID="GridView5" runat="server" AllowPaging="True" 
          AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource5" 
             class="table table-bordered" 
             style="width:100%;margin:0px;padding:0px;font-size:9pt;" CellPadding="4" 
             ForeColor="#333333" GridLines="None">
          <RowStyle BackColor="#EFF3FB" />
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
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Pemohon" SortExpression="pemohonfmb">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label3" runat="server" Text='<%# Bind("pemohonfmb") %>' style="font-weight:bold;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label4" runat="server" Text='<%# Bind("tglpemohonfmb") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Head Approval" SortExpression="disetujuifmb">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label3" runat="server" Text='<%# Bind("disetujuifmb") %>' style="font-weight:bold;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label4" runat="server" Text='<%# Bind("tgldisetujuifmb") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Head Purchasing" SortExpression="disetujuifmb">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label3" runat="server" Text='<%# Bind("approveheadpurc") %>' style="font-weight:bold;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label4" runat="server" Text='<%# Bind("tglapproveheadpurc") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
              
              <asp:TemplateField HeaderText="Vice President (>2jt)" SortExpression="disetujui2fmb">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label17" runat="server" Text='<%# Bind("disetujui2fmb") %>' style="font-weight:bold;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label18" runat="server" Text='<%# Bind("tgldisetujui2fmb") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Total" SortExpression="total">
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("total", "{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("total") %>'></asp:Label>
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderStyle-Width="5">
                  <ItemTemplate>
                      <asp:HyperLink ID="HyperLink1" runat="server" 
                          NavigateUrl='<%# "viewreq.aspx?q=" + Eval("nofmbhead") %>' Target="_self" Text="<span class='glyphicon glyphicon-exclamation-sign'></span>&nbsp;VIEW" class="btn btn-primary btn-sm" style="font-weight:bold;"></asp:HyperLink>
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
          
          
          SelectCommand="SELECT fmbhead.nofmbhead, convert(varchar,tglpemohonfmb,106) as tglpemohonfmb, fmbhead.disetujuifmb, fmbhead.approveheadpurc, convert(varchar, tglapproveheadpurc, 106) AS tglapproveheadpurc, convert(varchar, tgldisetujuifmb, 106) AS tgldisetujuifmb, fmbhead.disetujui2fmb, convert(varchar, tgldisetujui2fmb, 106) AS tgldisetujui2fmb, SUM(fmbbody.hargaitem*fmbbody.jumlahitem) AS total, fmbhead.pemohonfmb FROM fmbhead INNER JOIN fmbbody ON fmbhead.nofmbhead = fmbbody.nobody WHERE approveheadpurc IS NOT NULL AND rejecthead = 'N' AND fmbbody.reject = 'APPROVE' AND nopurchaseorder IS NULL GROUP BY fmbhead.nofmbhead, fmbhead.pemohonfmb, fmbhead.tglpemohonfmb, fmbhead.disetujuifmb, fmbhead.tgldisetujuifmb, fmbhead.disetujui2fmb, fmbhead.tgldisetujui2fmb, fmbhead.approveheadpurc, fmbhead.tglapproveheadpurc HAVING (SUM(fmbbody.hargaitem*fmbbody.jumlahitem) < 2000000)">
      </asp:SqlDataSource>
         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
          AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
             class="table table-bordered" 
             style="width:100%;margin-top:20px;padding:0px;font-size:9pt;" CellPadding="4" 
             ForeColor="#333333" GridLines="None">
          <RowStyle BackColor="#EFF3FB" />
          <Columns>
           <asp:TemplateField HeaderText="No." SortExpression="total" HeaderStyle-Width="5">
                  <ItemTemplate>
                      <asp:Label ID="Label5" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="No. Bukti" SortExpression="nofmbhead">
                  <ItemTemplate>
                      <asp:Label ID="Label6" runat="server" Text='<%# Bind("nofmbhead") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Pemohon" SortExpression="pemohonfmb">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label7" runat="server" Text='<%# Bind("pemohonfmb") %>' style="font-weight:bold;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label8" runat="server" Text='<%# Bind("tglpemohonfmb") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Head Approval" SortExpression="disetujuifmb">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label9" runat="server" Text='<%# Bind("disetujuifmb") %>' style="font-weight:bold;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label10" runat="server" Text='<%# Bind("tgldisetujuifmb") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Purchasing" SortExpression="disetujuifmb">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label11" runat="server" Text='<%# Bind("mengetahuifmb") %>' style="font-weight:bold;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label12" runat="server" Text='<%# Bind("tglmengetahuifmb") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Head Purchasing" SortExpression="disetujuifmb">
                  <ItemTemplate>
                     <u></ul> <asp:Label ID="Label13" runat="server" Text='<%# Bind("approveheadpurc") %>' style="font-weight:bold;"></asp:Label></u><br />
                     <i> <asp:Label ID="Label14" runat="server" Text='<%# Bind("tglapproveheadpurc") %>'></asp:Label></i>
                  </ItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Total" SortExpression="total">
                  <ItemTemplate>
                      <asp:Label ID="Label15" runat="server" Text='<%# Bind("total", "{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:Label ID="Label16" runat="server" Text='<%# Eval("total") %>'></asp:Label>
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderStyle-Width="5">
                  <ItemTemplate>
                      <asp:HyperLink ID="HyperLink2" runat="server" 
                          NavigateUrl='<%# "viewreq.aspx?q=" + Eval("nofmbhead") %>' Target="_self" Text="<span class='glyphicon glyphicon-exclamation-sign'></span>&nbsp;VIEW" class="btn btn-primary btn-sm" style="font-weight:bold;"></asp:HyperLink>
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
         </ContentTemplate>
</asp:UpdatePanel>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
          ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
          
          
          SelectCommand="SELECT fmbhead.nofmbhead, fmbhead.tglpemohonfmb, fmbhead.disetujuifmb, fmbhead.approveheadpurc, fmbhead.tglapproveheadpurc, fmbhead.tgldisetujuifmb, fmbhead.mengetahuifmb, fmbhead.tglmengetahuifmb, SUM(fmbbody.hargaitem*fmbbody.jumlahitem) AS total, fmbhead.pemohonfmb FROM fmbhead INNER JOIN fmbbody ON fmbhead.nofmbhead = fmbbody.nobody WHERE disetujui2fmb IS NOT NULL AND approveheadpurc IS NOT NULL AND disetujui2fmb IS NOT NULL AND rejecthead = 'N' AND fmbbody.reject = 'APPROVE' AND nopurchaseorder IS NULL GROUP BY fmbhead.nofmbhead, fmbhead.pemohonfmb, fmbhead.tglpemohonfmb, fmbhead.disetujuifmb, fmbhead.tgldisetujuifmb, fmbhead.mengetahuifmb, fmbhead.tglmengetahuifmb, fmbhead.approveheadpurc, fmbhead.tglapproveheadpurc HAVING (SUM(fmbbody.hargaitem*fmbbody.jumlahitem) > 1999999)">
      </asp:SqlDataSource>
                     
                     </form>
                     </div>
                       <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
</asp:Content>

