<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="formhardsoft.aspx.cs" Inherits="formhardsoft" %>

<asp:Content ID="headBeranda" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen :: Form perbaikan hardware & software</title>
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
width: 35%;
height: auto;
top: 80px;
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
height: auto;
top: 80px;
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
  <li><span class="glyphicon glyphicon-wrench"></span>&nbsp;&nbsp;Keluhan IT / GA</li>
</ol>
         <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="formhardsoft.aspx#popup" class="btn btn-primary btn-sm" style="font-weight:bold;font-size:verdana;margin-left:6px;margin-bottom:8px;" ><span class="glyphicon glyphicon-edit"></span>&nbsp;PERMINTAAN BARU</asp:HyperLink>
          <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="deadlinehardsoft.aspx" class="btn btn-warning btn-sm" style="font-weight:bold;font-size:verdana;margin-bottom:8px;" ><span class="glyphicon glyphicon-list"></span>&nbsp;&nbsp;DAFTAR PERMINTAAN <span class="badge"><asp:Label ID="lblBtn1" runat="server" Text="0"></asp:Label></span></asp:HyperLink>
           <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="resulthardsoft.aspx" class="btn btn-danger btn-sm" style="font-weight:bold;font-size:verdana;margin-bottom:8px;" ><span class="glyphicon glyphicon-cog"></span>&nbsp;PROSES PERBAIKAN <span class="badge"><asp:Label ID="lblBtn2" runat="server" Text="0"></asp:Label></span></asp:HyperLink>
           <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="myformhardsoft.aspx" class="btn btn-info btn-sm" style="font-weight:bold;font-size:verdana;margin-bottom:8px;" ><span class="glyphicon glyphicon-tags"></span>&nbsp;&nbsp;PERMINTAAN SAYA</asp:HyperLink>          
    
         <div style="width:400px;margin:5px;background:linear-gradient(#c0c0c0, #ddd);padding:5px;border-radius:4px;-webkit-border-radius:4px;-o-border-radius:4px;-moz-border-radius:4px;">
          <table>
             <tr>
                 <td> <asp:Label ID="Label7" Style="margin:5px;font-weight:bold;font-size:8pt;font-family:Verdana;" runat="server" Text="<span class='glyphicon glyphicon-cog'></span> Detail View :"></asp:Label></td>
                <td>:</td>
                  <td><asp:DropDownList ID="drpView" CssClass="form-control input-sm" style="width:200px;color:#0080c0;font-weight:bold;font-family:Verdana;"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpView_SelectedIndexChanged">
                 <asp:ListItem></asp:ListItem>
                 <asp:ListItem Value="All">Belum Selesai</asp:ListItem>
                 <asp:ListItem Value="me">Sudah Selesai</asp:ListItem>
                 <asp:ListItem Value="rej">Ditolak</asp:ListItem>
             </asp:DropDownList>
                  </td>
             </tr>
         </table>
             </div>

         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
                     AutoGenerateColumns="False" CellPadding="4" DataKeyNames="idhardsoft" 
                     DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                 class="table table-bordered" style="width:99%;margin:0 auto;font-size:8pt;" PageSize="10">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:TemplateField HeaderText="No." InsertVisible="False" 
                SortExpression="idhardsoft" HeaderStyle-Width="5">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cab Asal" SortExpression="cabangasal" HeaderStyle-Width="5">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cabangasal") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("cabangasal") %>' style="font-weight:bold;font-family:Tahoma;color:#333;"></asp:Label>
                </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Cab Tujuan" SortExpression="cabangasal" HeaderStyle-Width="5">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("cabangtujuan") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("cabangtujuan") %>' style="font-weight:bold;font-family:Tahoma;color:#333;"></asp:Label>
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
            <asp:TemplateField HeaderText="User" SortExpression="namakaryawan">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("userpengaju") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("userpengaju") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Departemen" SortExpression="nmdivisi">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("nmdivisi") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("nmdivisi") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Unit Kerja" SortExpression="tujuandivisi">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("tujuandivisi") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("tujuandivisi") %>' CssClass="label label-info" style="font-family:Verdana;font-weight:bold;font-size:8pt;text-align:center;"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Masalah" SortExpression="masalah">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("masalah") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("masalah") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="Aktual" SortExpression="aktual">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("aktual") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("aktual") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Result" SortExpression="resulthardsoft">
                <ItemTemplate>
                    <asp:Label ID="Label8" CssClass="label label-danger" runat="server" Text='<%# Bind("resulthardsoft") %>' style="font-size:8pt;font-family:Verdana;"></asp:Label>
                    <br />
                    <asp:Label ID="Label9"  runat="server" Text='<%# Bind("selesai") %>' style="font-size:0.9em;color:gray;font-family:Verdana;"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tracking" HeaderStyle-Width="70">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%# "formhardsoft.aspx?q2=me&&idtrack=" + Eval("idhardsoft") + "#popup2" %>' Target="_self" Text="<span class='glyphicon glyphicon-info-sign'></span>&nbsp;View" class="btn btn-primary btn-xs" style="font-weight:bold;"></asp:HyperLink>
                </ItemTemplate>

<HeaderStyle Width="70px"></HeaderStyle>
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
                     
                     SelectCommand="SELECT convert(varchar, selesai, 106) AS selesai, formhardsoft.idhardsoft, formhardsoft.tujuandivisi,  convert(varchar, tglajukan, 106) as tglajukan, formhardsoft.userpengaju, formhardsoft.cabangasal, formhardsoft.cabangtujuan, tb_user.namakaryawan, divisi.nmdivisi, formhardsoft.masalah, convert(varchar, deadline, 106) AS deadline, convert(varchar, aktual, 106) as aktual, formhardsoft.resulthardsoft
FROM formhardsoft INNER JOIN tb_user ON formhardsoft.userhardsoft = tb_user.username INNER JOIN divisi ON tb_user.kddivisi = divisi.kddivisi WHERE (@q2 = 'All' AND resulthardsoft IS NULL AND @kdcabang = '112' AND cabangtujuan = '112') OR (@q2 = 'me' AND resulthardsoft = 'SELESAI' AND @kdcabang = '112' AND cabangtujuan = '112') OR (@q2 = 'rej' AND resulthardsoft = 'REJECTED' AND @kdcabang = '112' AND cabangtujuan = '112') OR (@q2 = 'All' AND resulthardsoft IS NULL AND @kdcabang = '128' AND cabangtujuan = '128') OR (@q2 = 'me' AND resulthardsoft = 'SELESAI' AND @kdcabang = '128' AND cabangtujuan = '128') OR (@q2 = 'rej' AND resulthardsoft = 'REJECTED' AND @kdcabang = '128' AND cabangtujuan = '128') OR (@q2 = 'All' AND resulthardsoft IS NULL AND @kdcabang = '000') OR (@q2 = 'me' AND resulthardsoft = 'SELESAI' AND @kdcabang = '000') OR (@q2 = 'rej' AND resulthardsoft = 'REJECTED' AND @kdcabang = '000') ORDER BY idhardsoft DESC">
                     <SelectParameters>
                         <asp:SessionParameter Name="kdcabang" SessionField="kdcabang" 
                             Type="String" />
                     </SelectParameters>
                     <SelectParameters>
          <asp:QueryStringParameter Name="q2" QueryStringField="q2" Type="String" />
      </SelectParameters>
 </asp:SqlDataSource>
   </div>
    
    
     <div id="popup">
 <div class="window">
 <div class="panel panel-primary" style="width:98%;margin:5px;">
  <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-edit"></span> Permintaan Baru<button class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</button></div>
  <div class="panel-body">
  
     <div class="input-group" style="width:35%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></div>
      <asp:TextBox ID="txtTanggal" class="form-control" runat="server" style="width:100px;" ReadOnly></asp:TextBox>
      </div>
      
      <div class="input-group" style="width:45%;margin:5px;float:left;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-user"></span></div>
       <asp:TextBox ID="txtUser" runat="server" class="form-control" placeholder="User Pemohon.." onkeyup="upper(this)"></asp:TextBox>
       </div>
       
        <div class="input-group" style="width:45%;margin:5px;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-flag"></span></div>
           <asp:DropDownList ID="txtTujuan" runat="server" class="form-control"> 
               <asp:ListItem>Pilih..</asp:ListItem>
               <asp:ListItem>IT</asp:ListItem>
               <asp:ListItem>GA</asp:ListItem>
               <asp:ListItem Value="IT &amp; GA">IT &amp; GA</asp:ListItem>
           </asp:DropDownList>
       </div>
       
          <div class="input-group" style="width:65%;margin:5px;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-bookmark"></span></div>
              <asp:DropDownList ID="txtCabang" runat="server" class="form-control">
                  <asp:ListItem Value="">Pilih Cabang Tujuan..</asp:ListItem>
                  <asp:ListItem Value="112">MUGEN Ps. Minggu</asp:ListItem>
                  <asp:ListItem Value="128">MUGEN PURI</asp:ListItem>
              </asp:DropDownList>
       </div>
       

  <div class="input-group" style="width:100%;margin:5px;">
      <div class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></div>
  <asp:TextBox ID="txtMasalah" class="form-control" placeholder="Tuliskan keluhan anda disini.." onkeyup="upper(this)" runat="server"></asp:TextBox>
     </div>
      <asp:Button ID="Button1" runat="server" Text="SUBMIT" 
          class="btn btn-success btn-sm" style="margin:5px;font-weight:bold;font-family:verdana;" onclick="Button1_Click" />
      <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Small" 
          ForeColor="Red"></asp:Label>
  </div>
</div>
</div>
</div>

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
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("usernote") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tanggal" SortExpression="tglnote" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("tglnote") %>' ></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Note" SortExpression="pesannote">
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
                         SelectCommand="SELECT [usernote], convert(varchar,tglnote,106) as tglnote, [pesannote] FROM [bodyhardsoft] WHERE ([idhardsoftbody] = @idhardsoftbody)">
                      <SelectParameters>
                             <asp:QueryStringParameter Name="idhardsoftbody" QueryStringField="idtrack" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
  </div>
</div></div></div>
    </form>
    
    <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
 
 </asp:Content>

