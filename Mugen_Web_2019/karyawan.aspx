<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="karyawan.aspx.cs" Inherits="karyawan" %>

<asp:Content ID="headBeranda" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen :: Data Karyawan</title>
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
width: 55%;
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
 <asp:Content ID="bodySesuaiHalaman" ContentPlaceHolderID="body" Runat="Server">
     <form id="form1" runat="server">
     <div class="container-fluid">
     <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
  <li><a href="#"><span class="glyphicon glyphicon-folder-open"></span>&nbsp;&nbsp;Database</a></li>
  <li><span class="glyphicon glyphicon-eye-open"></span>&nbsp;&nbsp;Data Karyawan</li>
</ol>
         <asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-primary btn-sm" NavigateUrl="#popup"><span class="glyphicon glyphicon-plus"></span> Tambah DATA BARU</asp:HyperLink>
<div id="popup">
<div class="window">
<div class="panel panel-primary" style="width:100%;margin:5px;-ms-align-content:left;">
  <div class="panel-heading"><span class="glyphicon glyphicon-plus-sign"></span> Tambah Data Karyawan Baru</div>
  <div class="panel-body">
  <table>
  <tr>
   <td><asp:Label ID="Label1" runat="server" Text="NIK" style="margin:2px;font-size:8pt;color:#0080c0;"></asp:Label></td><td><asp:TextBox ID="txtNik" runat="server" class="form-control" style="margin:5px;width:80px;" onkeyup="Angka(this)"></asp:TextBox></td>
  </tr>
  <tr>
   <td><asp:Label ID="Label2" runat="server" Text="Username" style="margin:2px;font-size:8pt;color:#0080c0;"></asp:Label></td><td><asp:TextBox ID="txtUser" runat="server" class="form-control" style="margin:5px;width:200px;" onkeyup="upper(this)"></asp:TextBox></td>
   <td><asp:Label ID="Label3" runat="server" Text="Password" style="margin:2px;font-size:8pt;color:#0080c0;"></asp:Label></td><td><asp:TextBox ID="txtPass" runat="server" textmode="Password"  class="form-control" style="margin:5px;width:200px;" onkeyup="upper(this)"></asp:TextBox></td>
  </tr>
   <tr>
   <td><asp:Label ID="Label4" runat="server" Text="No KTP" style="margin:2px;font-size:8pt;color:#0080c0;"></asp:Label></td><td><asp:TextBox ID="txtKTP" runat="server" class="form-control" style="margin:5px;width:150px;" onkeyup="Angka(this)"></asp:TextBox></td>
    <td><asp:Label ID="Label16" runat="server" Text="Cabang" style="margin:2px;font-size:8pt;color:#0080c0;"></asp:Label></td><td>
        <asp:DropDownList ID="txtKodecabang" runat="server" CssClass="form-control">
            <asp:ListItem>
            </asp:ListItem>
            <asp:ListItem Value="112">PASAR MINGGU</asp:ListItem>
            <asp:ListItem Value="128">PURI</asp:ListItem>
        </asp:DropDownList>
    </td>
  </tr>
   <tr>
   <td><asp:Label ID="Label5" runat="server" Text="Nama" style="margin:2px;font-size:8pt;color:#0080c0;"></asp:Label></td><td><asp:TextBox ID="txtNama" runat="server" class="form-control" style="margin:5px;width:200px;" onkeyup="upper(this)"></asp:TextBox></td>
   <td><asp:Label ID="Label6" runat="server" Text="Divisi" style="margin:2px;font-size:8pt;color:#0080c0;"></asp:Label></td><td>
       <asp:DropDownList ID="txtDivisi" runat="server" 
           DataSourceID="SqlDataSource2" DataTextField="nmdivisi" 
           DataValueField="kddivisi" class="form-control">
           <asp:ListItem></asp:ListItem>
       </asp:DropDownList>
       <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
           ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
           SelectCommand="SELECT [kddivisi], [nmdivisi] FROM [divisi]">
       </asp:SqlDataSource>
   </td>
  </tr>
  <tr>
   <td><asp:Label ID="Label7" runat="server" Text="Alamat" style="margin:2px;font-size:8pt;width:450px;color:#0080c0;"></asp:Label></td>
   <td>
       <asp:TextBox ID="txtAlamat2" class="form-control" runat="server" style="margin:5px;" onkeyup="upper(this)"></asp:TextBox></td>
  </tr>
    <tr>
   <td><asp:Label ID="Label8" runat="server" Text="Tempat, Tgl lahir" style="margin:2px;font-size:8pt;color:#0080c0;"></asp:Label></td>
   <td> <asp:TextBox ID="txtTempatlahir" runat="server" class="form-control" style="margin:5px;width:200px;" onkeyup="upper(this)"></asp:TextBox></td>
  <td></td>
    <td><asp:TextBox ID="txtTgllahir" runat="server" class="form-control" style="margin:5px;width:100px;" data-provide="datepicker"></asp:TextBox></td>
  </tr>
   <tr>
   <td><asp:Label ID="Label9" runat="server" Text="Agama" style="margin:2px;font-size:8pt;color:#0080c0;"></asp:Label></td><td>
       <asp:DropDownList ID="txtAgama" runat="server" class="form-control" style="margin:5px;width:150px;">
           <asp:ListItem>-- PILIH --</asp:ListItem>
           <asp:ListItem>ISLAM</asp:ListItem>
           <asp:ListItem>KRISTEN</asp:ListItem>
           <asp:ListItem>KATOLIK</asp:ListItem>
           <asp:ListItem>BUDHA</asp:ListItem>
           <asp:ListItem>HINDU</asp:ListItem>
           <asp:ListItem>LAINNYA</asp:ListItem>
       </asp:DropDownList>
   </td>
   <td><asp:Label ID="Label10" runat="server" Text="Gender" style="margin:2px;font-size:8pt;color:#0080c0;"></asp:Label></td><td>
       <asp:DropDownList ID="txtGender" runat="server" class="form-control" style="margin:5px;width:150px;">
           <asp:ListItem>-- PILIH --</asp:ListItem>
           <asp:ListItem>LAKI-LAKI</asp:ListItem>
           <asp:ListItem>PEREMPUAN</asp:ListItem>
       </asp:DropDownList>
   </td>
  </tr>
    <tr>
   <td><asp:Label ID="Label11" runat="server" Text="Pendidikan" style="margin:2px;font-size:8pt;color:#0080c0;"></asp:Label></td><td>
       <asp:DropDownList ID="txtPendidikan" runat="server" class="form-control" style="margin:5px;width:150px;">
           <asp:ListItem>-- PILIH --</asp:ListItem>
           <asp:ListItem>SMA/SMK</asp:ListItem>
           <asp:ListItem>DIPLOMA 3 / D3</asp:ListItem>
           <asp:ListItem>STRATA 1 / S1</asp:ListItem>
           <asp:ListItem>STRATA 2 / S2</asp:ListItem>
       </asp:DropDownList>
   </td>
  <td>
      <asp:Label ID="Label12" runat="server" style="margin:2px;font-size:8pt;color:#0080c0;" Text="Tgl Join"></asp:Label></td>
    <td><asp:TextBox ID="txtJoin" runat="server" class="form-control" style="margin:5px;width:100px;" data-provide="datepicker"></asp:TextBox></td>
  </tr>
  <tr>
   <td><asp:Label ID="Label13" runat="server" Text="E-mail" style="margin:2px;font-size:8pt;color:#0080c0;"></asp:Label></td><td><asp:TextBox ID="txtEmail" runat="server" class="form-control" style="margin:5px;width:200px;" onkeyup="upper(this)"></asp:TextBox></td>
   <td><asp:Label ID="Label14" runat="server" Text="No. HP" style="margin:2px;font-size:8pt;color:#0080c0;"></asp:Label></td><td><asp:TextBox ID="txtHP" runat="server" class="form-control" style="margin:5px;width:200px;" onkeyup="Angka(this)"></asp:TextBox></td>
  </tr>
  <tr><td></td><td>
      <asp:Button ID="Button1" runat="server" Text="SUBMIT" onclick="Button1_Click" class="btn btn-primary" style="margin:5px;" />
      <td>
      <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Italic="True" 
              ForeColor="Red" Font-Size="X-Small"></asp:Label>
</td>
       </table>
  </div>
</div>
         </div></div>

    
  <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
               AutoGenerateColumns="False" CellPadding="4" DataKeyNames="username" 
               DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" class="table table-bordered table-striped" style="width:100%;margin:5px auto;font-size:8pt;" PageSize="6">
         <RowStyle BackColor="#EFF3FB" />
         <Columns>
             <asp:TemplateField HeaderText="NIK" SortExpression="kdkaryawan">
                 <ItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Cab." SortExpression="kdcabang">
                 <EditItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text='<%# Eval("kdcabang") %>'></asp:Label>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("kdcabang") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="NIK" SortExpression="kdkaryawan">
                 <EditItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text='<%# Eval("kdkaryawan") %>'></asp:Label>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("kdkaryawan") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Username" SortExpression="username">
                 <EditItemTemplate>
                     <asp:Label ID="Label2" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("username") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Nama" SortExpression="namakaryawan">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("namakaryawan") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label3" runat="server" Text='<%# Bind("namakaryawan") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Divisi" SortExpression="nmdivisi">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nmdivisi") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label4" runat="server" Text='<%# Bind("nmdivisi") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Alamat" SortExpression="alamatkaryawan">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("alamatkaryawan") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label5" runat="server" Text='<%# Bind("alamatkaryawan") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="e-Mail" SortExpression="email">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label6" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="No. Handphone" SortExpression="nohp">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("nohp") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label7" runat="server" Text='<%# Bind("nohp") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="3" />
          <pagerstyle cssclass="gridview">

</pagerstyle>
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <EditRowStyle BackColor="#2461BF" />
         <AlternatingRowStyle BackColor="White" />
     </asp:GridView>
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
               ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" 
               SelectCommand="SELECT divisi.nmdivisi, tb_user.kdkaryawan, tb_user.kdcabang, tb_user.username, tb_user.noktp, tb_user.namakaryawan, tb_user.alamatkaryawan, tb_user.tgljoin, tb_user.email, tb_user.nohp FROM divisi INNER JOIN tb_user ON divisi.kddivisi = tb_user.kddivisi">
           </asp:SqlDataSource>
         </div>
    </form>
    <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
</asp:Content>
