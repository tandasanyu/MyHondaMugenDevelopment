<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="resulthardsoft.aspx.cs" Inherits="resulthardsoft" %>

<asp:Content ID="headBeranda" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen :: Result Form Perbaikan Hardware & Software</title>
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
height: auto;
top:100px;
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
width: 30%;
height: auto;
top:100px;
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
width: 50%;
height: auto;
top:15px;
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
  <li><span class="glyphicon glyphicon-cog"></span>&nbsp;&nbsp;Proses Perbaikan</li>
</ol>
<div id="popup">
 <div class="window">
 <div class="panel panel-primary" style="width:100%;margin:5px;">
  <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-check"></span> Closing Selesai <button class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</button></div>
  <div class="panel-body">
     <div class="input-group" style="width:35%;margin:5px;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-search"></span></div>
      <asp:TextBox ID="txtKode" class="form-control" runat="server" style="width:200px;" placeholder="Pilih ID..." ReadOnly></asp:TextBox>
      </div>
      <asp:Button ID="Button1" runat="server" Text="PROSES CLOSING" class="btn btn-success btn-sm" 
          style="margin:5px;font-weight:bold;font-family:Verdana;" onclick="Button1_Click"/>
      <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Small" 
          ForeColor="Red"></asp:Label>
  </div>
</div></div></div>


<div id="popup3">
 <div class="window3">
 <div class="panel panel-primary" style="width:100%;margin:5px;">
  <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-time"></span> Pending<button class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</button></div>
  <div class="panel-body">
  
     <div class="input-group" style="width:25%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-search"></span></div>
      <asp:TextBox ID="txtIdpending" class="form-control" runat="server" style="width:100px;" placeholder="Pilih ID..." ReadOnly></asp:TextBox>
      </div>
      
       <div class="input-group" style="width:35%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></div>
      <asp:TextBox ID="txtTglpending" class="form-control" runat="server" style="width:100px;" data-provide="datepicker" placeholder="Deadline"></asp:TextBox>
      </div>
      <br/>
      <asp:Button ID="btnPending" runat="server" Text="PROSES PENDING" class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;font-family:Verdana;" onclick="btnPending_Click" />
      <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="X-Small" 
          ForeColor="Red"></asp:Label>
  </div>
</div></div></div>


<div id="popup2">
 <div class="window2">
 <div class="panel panel-primary" style="width:100%;margin:5px;">
  <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-pencil"></span> History<button class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</button></div>
  <div class="panel-body">
  
     <div class="input-group" style="width:25%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-search"></span></div>
      <asp:TextBox ID="txtIdmemo" class="form-control" runat="server" style="width:100px;" placeholder="Pilih ID..." ReadOnly></asp:TextBox>
      </div>
      
      <div class="input-group" style="width:35%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></div>
      <asp:TextBox ID="txtTanggal" class="form-control" runat="server" style="width:100px;" ReadOnly></asp:TextBox>
      </div>
      
      <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-user"></span></div>
       <asp:TextBox ID="txtUser" runat="server" class="form-control" onkeyup="upper(this)" ReadOnly></asp:TextBox>
       </div>
           
  <div class="input-group" style="width:100%;margin:5px;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></div>
  <asp:TextBox ID="txtResult" class="form-control" 
          placeholder="Tuliskan result perbaikan anda disini.." onkeyup="upper(this)"
          runat="server"></asp:TextBox>
     </div>
      <br/>
      <asp:Button ID="Button2" runat="server" Text="SUBMIT" 
          class="btn btn-primary btn-sm" 
          style="margin:5px;font-weight:bold;font-family:Verdana;" 
          onclick="Button2_Click"  />
      <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="X-Small" 
          ForeColor="Red"></asp:Label>
          
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
             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="White" />
         </asp:GridView>
                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         SelectCommand="SELECT [usernote], [tglnote], [pesannote] FROM [bodyhardsoft] WHERE ([idhardsoftbody] = @idhardsoftbody)">
                      <SelectParameters>
                             <asp:QueryStringParameter Name="idhardsoftbody" QueryStringField="idmemo" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
  </div>
</div></div></div>

         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
                         AutoGenerateColumns="False" CellPadding="4" DataKeyNames="idhardsoft" 
                         DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" class="table table-bordered" style="margin:5px;width:98%;font-size:8pt;" PageSize="5">
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
                 <asp:TemplateField HeaderText="No." InsertVisible="False" 
                     SortExpression="ID" HeaderStyle-Width="3">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="3px"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Cab" SortExpression="cabangasal" HeaderStyle-Width="5">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cabangasal") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("cabangasal") %>' style="font-family:Tahoma;font-weight:bold;"></asp:Label>
                     </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tgl Ajukan" SortExpression="tglajukan">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("tglajukan") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("tglajukan") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="User" SortExpression="userhardsoft">
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
                         <asp:Label ID="Label3" runat="server" CssClass="label label-info" Text='<%# Bind("tujuandivisi") %>' style="font-size:8pt;font-family:Verdana;"></asp:Label>
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
                             NavigateUrl='<%# "resulthardsoft.aspx?idpend=" + Eval("idhardsoft") + "#popup3"%>' Target="_self" Text="<span class='glyphicon glyphicon-time'></span>&nbsp;Pending" class="btn btn-danger btn-xs" style="font-weight:bold;"></asp:HyperLink>
                             <asp:HyperLink ID="HyperLink3" runat="server" 
                             NavigateUrl='<%# "resulthardsoft.aspx?idmemo=" + Eval("idhardsoft") + "#popup2" %>' Target="_self" Text="<span class='glyphicon glyphicon-pencil'></span>&nbsp;History" class="btn btn-primary btn-xs" style="font-weight:bold;"></asp:HyperLink>
                             <asp:HyperLink ID="HyperLink2" runat="server" 
                             NavigateUrl='<%# "resulthardsoft.aspx?id=" + Eval("idhardsoft") + "#popup" %>' Target="_self" Text="<span class='glyphicon glyphicon-check'></span>&nbsp;Closing" class="btn btn-success btn-xs" style="font-weight:bold;"></asp:HyperLink>
                     </ItemTemplate>

<HeaderStyle Width="250px"></HeaderStyle>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
             <pagerstyle cssclass="gridview">

</pagerstyle>
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="White" />
         </asp:GridView>
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
                         SelectCommand="SELECT idhardsoft, convert(varchar, tglajukan, 9) as tglajukan, userpengaju, cabangasal, tujuandivisi, masalah, convert(varchar, deadline, 106) as deadline FROM formhardsoft WHERE (deadline IS NOT NULL) AND (resulthardsoft IS NULL) AND ([cabangtujuan] = @kdcabang) AND (@username = 'GA128' AND tujuandivisi <> 'IT' OR @username = 'IT128' AND tujuandivisi <> 'GA' OR  @username <> 'IT128' AND @username <> 'GA128' AND tujuandivisi IN ('IT', 'GA', 'IT & GA')) AND (@username = 'GA112' AND tujuandivisi <> 'IT' OR @username = 'IT112' AND tujuandivisi <> 'GA' OR  @username <> 'IT112' AND @username <> 'GA112' AND tujuandivisi IN ('IT', 'GA', 'IT & GA')) ORDER BY deadline ASC">
                      <SelectParameters>
                         <asp:SessionParameter Name="username" SessionField="username" 
                             Type="String" />
                              <asp:SessionParameter Name="kdcabang" SessionField="kdcabang" 
                             Type="String" />
                     </SelectParameters>
                     </asp:SqlDataSource>
                 </div>
                 
    <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
    </form>
  </asp:Content>
