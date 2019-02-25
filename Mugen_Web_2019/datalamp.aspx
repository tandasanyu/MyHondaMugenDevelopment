<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="datalamp.aspx.cs" Inherits="datalamp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen :: Permintaan Pembelian</title>
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
        .gridview{
    background-color:#507CD1;
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
      -o-box-shadow:0px 1px 1px #666;
      -moz-box-shadow:0px 1px 1px #666;
      -webkit-box-shadow:0px 1px 1px #666;
      box-shadow:0px 1px 1px #666;
     
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
width: 45%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
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
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <form id="form1" runat="server">
     <div class="container-fluid">
     <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
  <li><a href="#"><span class="glyphicon glyphicon-edit"></span>&nbsp;&nbsp;Apply Form</a></li>
  <li><a href="mintabeli.aspx"><span class="glyphicon glyphicon-comment"></span>&nbsp;&nbsp;Form Permintaan Pembelian</a></li>
  <li><a href="datalamp.aspx"><span class="glyphicon glyphicon-paperclip"></span>&nbsp;&nbsp;Data Lampiran</a></li>
</ol>
         <div class="input-group" style="width:25%;margin:8px;float:left;  ">
  <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-search"></span></span>
            <asp:TextBox ID="txtCari" runat="server" placeholder="Cari nama barang.." CssClass="form-control"></asp:TextBox>
</div> <asp:Button ID="Button1" runat="server" class="btn btn-primary btn-sm" style="float:left;margin-top:8px;" Text="Cari Lampiran" OnClick="Button1_Click" />
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-success btn-sm" Style="margin:8px;" NavigateUrl="#popup"><span class="glyphicon glyphicon-plus"></span>&nbsp;Lampiran Baru</asp:HyperLink>
         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource3" EnableModelValidation="True" GridLines="None" class="table table-bordered" style="font-size:9pt;" ForeColor="#333333">
             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <Columns>
                 <asp:TemplateField HeaderText="#" HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
                 <asp:TemplateField HeaderText="Vendor" SortExpression="nohead">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("nohead") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="lokasi file" SortExpression="lokasifile">
                     <ItemTemplate>
                         <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# Eval("lokasifile")  %>' 
                             Target="_blank" class="btn btn-info btn-xs"><span class="glyphicon glyphicon-search"></span> View</asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="keterangan" SortExpression="keterangan">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("keterangan") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
             <EditRowStyle BackColor="#999999" />
             <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
             <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
             <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
         </asp:GridView>

         <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [nohead], [lokasifile], [keterangan] FROM [fmblamp] WHERE ([proses] LIKE '0') AND ([nohead] LIKE '%' + @q + '%') OR ([keterangan] LIKE '%' + @q + '%')">
             <SelectParameters>
                <asp:QueryStringParameter Name="q" QueryStringField="q" Type="String" />
            </SelectParameters>
         </asp:SqlDataSource>

         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource2" EnableModelValidation="True" GridLines="Vertical" class="table table-bordered" style="font-size:9pt;">
             <AlternatingRowStyle BackColor="#DCDCDC" />
             <Columns>
                 <asp:TemplateField HeaderText="#" HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
                 <asp:TemplateField HeaderText="Vendor" SortExpression="nohead">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("nohead") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="lokasi file" SortExpression="lokasifile">
                     <ItemTemplate>
                         <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# Eval("lokasifile")  %>' 
                             Target="_blank" class="btn btn-info btn-xs"><span class="glyphicon glyphicon-search"></span> View</asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="keterangan" SortExpression="keterangan">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("keterangan") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
             <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
             <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
             <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
         </asp:GridView>

         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [nohead], [lokasifile], [keterangan] FROM [fmblamp] WHERE ([proses] LIKE '0')"></asp:SqlDataSource>

         <div id="popup">
 <div class="window">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-paperclip"></span> Lampiran<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
           <table>
               <tr>
    <td>
        Vendor</td>
    <td>:</td>
    <td>
        <asp:DropDownList ID="drpVendor" runat="server" DataSourceID="SqlDataSource1" DataTextField="vendor_nama" DataValueField="vendor_nama" style="margin:5px;" CssClass="form-control"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [vendor_nama] FROM [dbvendor]"></asp:SqlDataSource>
                   </td>
  </tr>
   <tr>
    <td>
        <asp:Label ID="Label39" runat="server" Text="File"></asp:Label></td>
    <td>:</td>
    <td>
        <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" style="margin:5px;"/></td>
  </tr>
    <tr>
    <td>
        <asp:Label ID="Label40" runat="server" Text="Keterangan"></asp:Label></td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtKet" runat="server" class="form-control" style="margin:5px;" onkeyup="upper(this)" placeholder="keterangan lampiran..."></asp:TextBox></td>
  </tr>
  <tr>
    <td></td>
    <td></td>
    <td><asp:Button ID="Button6" class="btn btn-success btn-sm" 
            style="font-weight:bold;" runat="server" Text="UPLOAD" OnClick="Button6_Click" 
             /></td>
  </tr>
 <tr>
    <td></td>
    <td></td>
    <td>
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label></td>
  </tr>
  </table>

  </div>
  </div>
 </div>
 </div>
          </form>
    <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
</asp:Content>

