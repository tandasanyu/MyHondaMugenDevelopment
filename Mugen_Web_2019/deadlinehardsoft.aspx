<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="deadlinehardsoft.aspx.cs" Inherits="deadlinehardsoft" %>

<asp:Content ID="headBeranda" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen :: Deadline Form Perbaikan Hardware & Software</title>
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
}

.window 
{
position:relative;	
width: 25%;
top:100px;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: center;
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
}

.window2 
{
position:relative;	
width: 25%;
top:100px;
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

  </style>
</asp:Content>
 <asp:Content ID="bodySesuaiHalaman" ContentPlaceHolderID="body" Runat="Server"> 
     <form id="form1" runat="server">
     <div class="container-fluid">
      <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
  <li><a href="#"><span class="glyphicon glyphicon-book"></span>&nbsp;&nbsp;IT / GA & PO</a></li>
  <li><a href="formhardsoft.aspx"><span class="glyphicon glyphicon-wrench"></span>&nbsp;&nbsp;Keluhan IT / GA</a></li>
  <li><span class="glyphicon glyphicon-list"></span>&nbsp;&nbsp;Daftar Permintaan</li>
</ol>

 <div id="popup">
 <div class="window">
 <div class="panel panel-primary" style="width:100%;margin:5px;">
  <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-cog"></span> Set Deadline <button class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</button></div>
  <div class="panel-body">
  
     <div class="input-group" style="width:35%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-search"></span></div>
      <asp:TextBox ID="txtKode" class="form-control" runat="server" style="width:100px;" placeholder="Pilih ID..." ReadOnly></asp:TextBox>
      </div>
    
  <div class="input-group" style="width:100%;margin:5px;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></div>
  <asp:TextBox ID="txtTanggal" class="form-control" 
          placeholder="Pilih tgl deadline anda disini.." data-provide="datepicker" 
          runat="server" onkeyup="readOnly()"></asp:TextBox>
     </div>
      <asp:Button ID="Button1" runat="server" Text="Set Deadline" style="font-weight:bold;margin:5px;" 
          class="btn btn-primary btn-sm" onclick="Button1_Click"/>
      <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Small" 
          ForeColor="Red"></asp:Label>
  </div></div>
  </div></div>
  
  
 <div id="popup2">
 <div class="window2">
  <div class="panel panel-primary" style="margin:5px;">
<div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-sort"></span> Swap Unit Kerja <button class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</button></div>
  <div class="panel-body">
  
     <div class="input-group" style="width:100%;margin:5px;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-search"></span></div>
      <asp:TextBox ID="txtSwap" class="form-control" runat="server" style="width:100px;" placeholder="Pilih ID..." ReadOnly></asp:TextBox>
      </div>
      <div class="input-group" style="width:100%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-flag"></span></div>
          <asp:DropDownList ID="drpUnitkerja" runat="server" class="form-control" style="width:100%;">
              <asp:ListItem>
              </asp:ListItem>
              <asp:ListItem>IT</asp:ListItem>
              <asp:ListItem>GA</asp:ListItem>
              <asp:ListItem Value="IT &amp; GA">IT &amp; GA</asp:ListItem>
          </asp:DropDownList>
      </div>
      <asp:Button ID="Button2" runat="server" Text="Swap Unit Kerja" style="margin:5px;font-weight:bold;" 
          class="btn btn-warning btn-sm" onclick="Button2_Click"/>
      <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="X-Small" 
          ForeColor="Red"></asp:Label>
  </div>
</div></div></div>
  
   
         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
                         AutoGenerateColumns="False" DataKeyNames="idhardsoft" 
                         DataSourceID="SqlDataSource1" class="table table-bordered" CellPadding="4" 
                         ForeColor="#333333" GridLines="None" style="font-size:8pt;width:97%;margin:5px;" PageSize="5">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
                 <asp:TemplateField HeaderText="No." InsertVisible="False" 
                     SortExpression="idhardsoft" HeaderStyle-Width="3">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="3px"></HeaderStyle>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Cab" SortExpression="cabangasal" HeaderStyle-Width="5">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cabangasal") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("cabangasal") %>' style="font-family:Tahoma;font-weight:bold;"></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tgl Diajukan" SortExpression="tglajukan">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("tglajukan") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("tglajukan") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="User" SortExpression="userpengaju">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("userpengaju") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("userpengaju") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Unit Kerja" SortExpression="tujuandivisi">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("tujuandivisi") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("tujuandivisi") %>' CssClass="label label-info" style="font-weight:bold;font-size:8pt;text-align:center;font-family:verdana;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Masalah" SortExpression="masalah">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("masalah") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("masalah") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Deadline" SortExpression="deadline">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("deadline") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label5" runat="server" Text='<%# Bind("deadline") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderStyle-Width="250">
                     <ItemTemplate>
                         <asp:HyperLink ID="HyperLink1" runat="server" 
                             NavigateUrl='<%# "deadlinehardsoft.aspx?id=" + Eval("idhardsoft") + "#popup" %>' Target="_self" Text="<span class='glyphicon glyphicon-cog'></span>&nbsp;Set Deadline" class="btn btn-primary btn-xs" style="font-weight:bold;"></asp:HyperLink>
                              <asp:HyperLink ID="HyperLink3" runat="server" 
                             NavigateUrl='<%# "deadlinehardsoft.aspx?swapid=" + Eval("idhardsoft") + "#popup2" %>' Target="_self" Text="<span class='glyphicon glyphicon-sort'></span>&nbsp;Swap" class="btn btn-warning btn-xs" style="font-weight:bold;"></asp:HyperLink>
                               <asp:HyperLink ID="HyperLink2" runat="server" 
                             NavigateUrl='<%# "deadlinehardsoft.aspx?rejId=" + Eval("idhardsoft") %>' Target="_self" Text="<span class='glyphicon glyphicon-thumbs-down'></span>&nbsp;Reject" class="btn btn-danger btn-xs" style="font-weight:bold;"></asp:HyperLink>
                     </ItemTemplate>

<HeaderStyle Width="250px"></HeaderStyle>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <PagerSettings PageButtonCount="5" FirstPageText="First" LastPageText="Last" />
              <pagerstyle cssclass="gridview">

</pagerstyle>
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="White" />
         </asp:GridView>
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         SelectCommand="SELECT [idhardsoft], convert(varchar, tglajukan , 9) as tglajukan, [userhardsoft], [cabangasal], [userpengaju], [masalah], [deadline], [tujuandivisi], [resulthardsoft] FROM [formhardsoft] WHERE ([resulthardsoft] IS NULL) AND ([cabangtujuan] = @kdcabang) AND ([deadline] IS NULL) AND (@username = 'GA128' AND tujuandivisi <> 'IT' OR @username = 'IT128' AND tujuandivisi <> 'GA' OR  @username <> 'IT128' AND @username <> 'GA128' AND tujuandivisi IN ('IT', 'GA', 'IT & GA')) AND (@username = 'GA112' AND tujuandivisi <> 'IT' OR @username = 'IT112' AND tujuandivisi <> 'GA' OR  @username <> 'IT112' AND @username <> 'GA112' AND tujuandivisi IN ('IT', 'GA', 'IT & GA')) ORDER BY [idhardsoft]">
                     <SelectParameters>
                         <asp:SessionParameter Name="username" SessionField="username" 
                             Type="String" />
                             <asp:SessionParameter Name="kdcabang" SessionField="kdcabang" 
                             Type="String" />
                     </SelectParameters>
                     </asp:SqlDataSource>
                 </div>
<script type="text/javascript">
function readOnly() {
    document.getElementById("txtTanggal").setAttribute("readonly", "true");
}
</script>
    <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
    </form> 
  </asp:Content>
