<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="myformhardsoft.aspx.cs" Inherits="myformhardsoft" %>

<asp:Content ID="headBeranda" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen ::  Form Perbaikan Hardware & Software</title>
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
top: 100px;
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
width: 55%;
top: 100px;
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
  <li><span class="glyphicon glyphicon-tag"></span>&nbsp;&nbsp;Permintaan Saya</li>
</ol>
 <div id="popup">
 <div class="window">
 <div class="panel panel-primary" style="margin:5px;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-cog"></span> Aktual <button class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</button></div>
  <div class="panel-body">
  
  <div class="input-group" style="width:35%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-search"></span></div>
      <asp:TextBox ID="txtKode" class="form-control" runat="server" style="width:100px;" placeholder="Pilih ID..." ReadOnly></asp:TextBox>
      </div>
    
      <asp:Button ID="Button1" runat="server" Text="RE-CLOSING" 
          class="btn btn-primary btn-sm" 
          style="margin:5px;font-family:Verdana;font-weight:bold;" 
          onclick="Button1_Click" />
      <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Small" 
          ForeColor="Red"></asp:Label>
  </div>
</div></div></div>
                 </div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
                     AutoGenerateColumns="False" CellPadding="4" 
                     DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                  class="table table-bordered" style="width:97%;margin:0 auto;font-size:8pt;" PageSize="5">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
        <asp:TemplateField HeaderText="No." SortExpression="tglajukan">
                <ItemTemplate>
                    <asp:Label ID="Label0" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tgl Pengajuan" SortExpression="tglajukan">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("tglajukan") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("tglajukan") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Cab.Asal" SortExpression="cabangasal">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("cabangasal") %>' style="font-weight:bold;color:#333;font-family:Tahoma;"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cabangasal") %>' style="font-weight:bold;color:#333;font-family:Tahoma;"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Cab.Tujuan" SortExpression="cabangtujuan">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("cabangtujuan") %>' style="font-weight:bold;color:#333;font-family:Tahoma;"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cabangtujuan") %>' style="font-weight:bold;color:#333;font-family:Tahoma;"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User" SortExpression="userhardsoft">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("userpengaju") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("userpengaju") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Unit Kerja" SortExpression="tujuandivisi">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("tujuandivisi") %>' class="label label-info" style="font-family:Verdana;font-size:8pt;"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("tujuandivisi") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Masalah" SortExpression="masalah">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("masalah") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("masalah") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Deadline" SortExpression="deadline">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("deadline") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("deadline") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Aktual" SortExpression="aktual">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("aktual") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("aktual") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Result" SortExpression="resulthardsoft">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" class="label label-danger" Text='<%# Bind("resulthardsoft") %>' Style="font-size:1.0em;"></asp:Label>
                    <br />
                    <i><asp:Label ID="Label9"  runat="server" Text='<%# Bind("selesai") %>' style="font-size:1.0em;color:gray;font-family:Verdana;"></asp:Label></i>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl=<%# "myformhardsoft.aspx?id=" + Eval("idhardsoft") + "#popup" %> Target="_self" Text="<span class='glyphicon glyphicon-cog'></span>&nbsp;re-Closing" class="btn btn-danger btn-xs" style="font-family:Verdana;"></asp:HyperLink>
                         <asp:HyperLink ID="HyperLink2" runat="server" 
                        NavigateUrl=<%# "myformhardsoft.aspx?idtrack=" + Eval("idhardsoft") + "#popup2" %> Target="_self" Text="<span class='glyphicon glyphicon-info-sign'></span>&nbsp;Tracking" class="btn btn-primary btn-xs" style="font-family:Verdana;"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="5" />
         <pagerstyle cssclass="gridview">

</pagerstyle>
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                     ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                     
                     
                  SelectCommand="SELECT [selesai], [idhardsoft], [tglajukan], [userhardsoft], [userpengaju], [cabangasal], [cabangtujuan], [tujuandivisi], [masalah], [deadline], [aktual], [resulthardsoft] FROM [formhardsoft] WHERE ([userhardsoft] = @userhardsoft) ORDER BY idhardsoft DESC">
                     <SelectParameters>
                         <asp:SessionParameter Name="userhardsoft" SessionField="username" 
                             Type="String" />
                     </SelectParameters>
              </asp:SqlDataSource>
    <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
           <script>
function readOnly() {
    document.getElementById("txtTanggal").readOnly = true;
}
</script>
<div id="popup2">
 <div class="window2">
 <div class="panel panel-primary" style="width:100%;margin:5px;">
  <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-info-sign"></span> Tracking History<button class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</button></div>
  <div class="panel-body">
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" 
                         AutoGenerateColumns="False" CellPadding="4"
                         DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" class="table table-bordered" style="margin:5px;width:98%;font-size:8pt;">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
                 <asp:TemplateField HeaderText="No." InsertVisible="False" 
                     SortExpression="ID" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="PIC" SortExpression="usernote" HeaderStyle-Width="10">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("usernote") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("usernote") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tanggal" SortExpression="tglnote" HeaderStyle-Width="150">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("tglnote") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("tglnote") %>' ></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Note" SortExpression="pesannote">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("pesannote") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("pesannote") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <pagerstyle cssclass="gridview">

</pagerstyle>
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="White" />
         </asp:GridView>
                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         SelectCommand="SELECT [usernote], [tglnote], [pesannote] FROM [bodyhardsoft] WHERE ([idhardsoftbody] = @idhardsoftbody)">
                      <SelectParameters>
                             <asp:QueryStringParameter Name="idhardsoftbody" QueryStringField="idtrack" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
  </div>
</div></div></div>
    </form>
      </asp:Content>
