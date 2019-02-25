<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="divisi.aspx.cs" Inherits="Default2" %>

<asp:Content ID="headBeranda" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Honda Mugen :: Divisi</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
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
  </style>
</asp:Content>
<asp:Content ID="bodySesuaiHalaman" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
     <div class="container-fluid">
           <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
  <li><a href="#"><span class="glyphicon glyphicon-folder-open"></span>&nbsp;&nbsp;Database</a></li>
  <li><span class="glyphicon glyphicon-eye-open"></span>&nbsp;&nbsp;Divisi</li>
</ol>
        
<div class="wrapper" style="border-top:3px solid #0080c0;background:#f5f5f5;width:100%;height:auto;padding: 4px;border-radius:4px;-webkit-border-radius:4px;-o-border-radius:4px;">
    <div class="panel panel-primary" style="width:25%;float:left;margin:5px;">
  <div class="panel-heading"><span class="glyphicon glyphicon-plus-sign"></span> Tambah Data Divisi Baru</div>
  <div class="panel-body">
  <asp:TextBox ID="txtKode" class="form-control" style="margin:5px;" placeholder="Kode Divisi" onkeyup="upper(this)" runat="server"></asp:TextBox>
         <asp:TextBox ID="txtNama" class="form-control" style="margin:5px;" placeholder="Nama Divisi" onkeyup="upper(this)" runat="server"></asp:TextBox>
         <asp:TextBox ID="txtEmail" class="form-control" style="margin:5px;" placeholder="e-Mail Divisi" runat="server"></asp:TextBox>
         <asp:Button ID="Button1" class="btn btn-primary btn-sm" style="margin:5px;" 
          runat="server" Text="Simpan" onclick="Button1_Click" />
      <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Small" 
          ForeColor="Red"></asp:Label>
  </div>
</div>

         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
                   AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" 
                   ForeColor="#333333" GridLines="None" 
                   class="table table-bordered table-hovered" 
                   style="width: 70%;position:relative;top:5px;left:5px;" Font-Size="Small" PagerSettings-Mode="NumericFirstLast" PagerSettings-PageButtonCount="10" PagerSettings-Position="Bottom" PageSize="5">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
                 <asp:TemplateField HeaderText="No." SortExpression="kddivisi">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Kode Divisi" SortExpression="kddivisi">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("kddivisi") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("kddivisi") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Nama Divisi" SortExpression="nmdivisi">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("nmdivisi") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nmdivisi") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="e-Mail Divisi" SortExpression="nmdivisi">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("emaildivisi") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("emaildivisi") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "editdivisi.aspx?reqid=" + Eval("kddivisi") %>'
                             Target="_SELF Text="EDIT" class="btn btn-danger btn-xs"></asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
                     
             </Columns>
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

<PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="&gt;" PageButtonCount="5" PreviousPageText="&lt;"></PagerSettings>

             <pagerstyle cssclass="gridview">

</pagerstyle>
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="white" />
         </asp:GridView>
               <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                   
                   SelectCommand="SELECT [iddivisi], [kddivisi], [nmdivisi], [emaildivisi] FROM [divisi] ORDER BY [nmdivisi]">
                   
                   </asp:SqlDataSource>
             </div>
    </div>
    <script src="js/jquery.min.js"></script>
     <script src="js/bootstrap.min.js"></script>
          
    </form>
</asp:Content>
