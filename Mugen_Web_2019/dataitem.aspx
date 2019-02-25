<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="dataitem.aspx.cs" Inherits="dataitem" %>

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
width:40%;
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
#edit {
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

.windowedit
{
position:relative;	
width:65%;
height: auto;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
}

#edit:target {
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
  <li><a href="dataitem.aspx"><span class="glyphicon glyphicon-briefcase"></span>&nbsp;&nbsp;Data Barang</a></li>
</ol>
         <div class="input-group" style="width:25%;margin:8px;float:left;  ">
  <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-search"></span></span>
            <asp:TextBox ID="txtCari" runat="server" placeholder="Cari nama barang.." CssClass="form-control"></asp:TextBox>
</div> <asp:Button ID="Button1" runat="server" class="btn btn-primary btn-sm" style="float:left;margin-top:8px;" Text="Cari Barang" OnClick="Button1_Click" />
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-success btn-sm" Style="margin:8px;" NavigateUrl="#popup"><span class="glyphicon glyphicon-plus"></span>&nbsp;Barang Baru</asp:HyperLink>
        <asp:gridview runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" class="table table-bordered" style="font-size:9pt;">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
             <asp:TemplateField HeaderText="#" HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
            <asp:TemplateField HeaderText="Vendor" SortExpression="item_vendor">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("item_vendor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nama Item" SortExpression="item_nama">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("item_nama") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Harga" SortExpression="item_harga">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("item_harga","{0:0,0}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-Width="5">
                     <ItemTemplate>
                        
                         <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "?id=" + Eval("item_id") + "#edit" %>' 
                             Target="_self" class="btn btn-info btn-xs"><span class="glyphicon glyphicon-cog"></span> Edit</asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
        </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:gridview>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [item_id], [item_vendor], [item_nama], [item_harga] FROM [dbitem] WHERE ([item_nama] LIKE '%' + @item_nama + '%') OR ([item_vendor] LIKE '%' + @item_nama + '%') OR ([item_harga] LIKE '%' + @item_nama + '%')">
            <SelectParameters>
                <asp:QueryStringParameter Name="item_nama" QueryStringField="q" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" EnableModelValidation="True" class="table table-bordered" style="font-size:9pt;">
        <Columns>
             <asp:TemplateField HeaderText="#" HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
            <asp:TemplateField HeaderText="Vendor" SortExpression="item_vendor">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("item_vendor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nama Item" SortExpression="item_nama">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("item_nama") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Harga" SortExpression="item_harga">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("item_harga","{0:0,0}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-Width="5">
                     <ItemTemplate>
                        
                         <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "?id=" + Eval("item_id") + "#edit" %>' 
                             Target="_self" class="btn btn-info btn-xs"><span class="glyphicon glyphicon-cog"></span> Edit</asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
         <pagerstyle cssclass="gridview"></pagerstyle>
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [item_id], [item_vendor], [item_nama], [item_harga] FROM [dbitem]"></asp:SqlDataSource>
    

        <div id="popup">
 <div class="window">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
  <div class="panel-heading"><span class="glyphicon glyphicon-plus"></span> Tambah Barang Baru  href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">

      <table>
          <tr>
              <td>Vendor</td>
              <td>
                  <asp:DropDownList ID="drpVendor" runat="server" CssClass="form-control" style="margin:5px;" DataSourceID="SqlDataSource2" DataTextField="vendor_nama" DataValueField="vendor_nama"></asp:DropDownList>
                  <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [vendor_nama] FROM [dbvendor]"></asp:SqlDataSource>
              </td>
              
          </tr>
          <tr>
              <td>Nama</td>
              <td><asp:TextBox ID="txtNama" runat="server" onkeyup="upper(this)" CssClass="form-control" Style="float:left;width:250px;margin:5px;"></asp:TextBox></td>
          </tr>
          <tr>
              <td>Harga</td>
              <td>
                  <div class="input-group" style="margin:5px;">
  <span class="input-group-addon" id="basic-addon1">Rp.</span>
                  <asp:TextBox ID="txtHarga" runat="server" onkeyup="Angka(this)" CssClass="form-control" Style="float:left;width:150px;"></asp:TextBox></td>
          </div>
          </tr>
      </table>
      <center><asp:Button ID="Button2" runat="server" Text="SIMPAN" class="btn btn-primary" style="margin:5px;font-family:Verdana;" OnClick="Button2_Click" /></center>
      </div>
     </div>
     </div>

        <div id="edit">
 <div class="windowedit">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
  <div class="panel-heading"><span class="glyphicon glyphicon-cog"></span> Edit Data Barang <a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">

      <table class="table">
          <tr>
              <td colspan="3" style="background:#ddd;font-weight:bold;font-family:Verdana;border-left:3px solid #d60000;padding:4px;"><span class="glyphicon glyphicon-info-sign"></span> Vendor</td>
              </tr>
          <tr>
               <td style="width:45%;">
                   <asp:label ID="lblVendor" style="font-weight:bold;color:blue;" runat="server" text="null" ></asp:label><i style="font-size:8pt;color:#c0c0c0;"> (current)</i>
               </td>
              <td style="width:5%;"><span class="glyphicon glyphicon-arrow-right"></span></td>
              <td style="width:45%;">
                  <asp:DropDownList ID="drpVendorEdit" class="form-control" runat="server"  DataSourceID="SqlDataSource2" DataTextField="vendor_nama" DataValueField="vendor_nama"></asp:DropDownList>
                  <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [vendor_nama] FROM [dbvendor]"></asp:SqlDataSource>
              </td>
              
          </tr>
           <tr>
              <td colspan="3" style="background:#ddd;font-weight:bold;font-family:Verdana;border-left:3px solid #d60000;padding:4px;"><span class="glyphicon glyphicon-info-sign"></span> Nama Barang</td>
              </tr>
          <tr>
               <td style="width:45%;">
                   <asp:label ID="lblNama" style="font-weight:bold;color:blue;" runat="server" text="null" ></asp:label><i style="font-size:8pt;color:#c0c0c0;"> (current)</i>
               </td>
              <td style="width:5%;"><span class="glyphicon glyphicon-arrow-right"></span></td>
              <td style="width:45%;">
                 <div class="input-group">
  <span class="input-group-addon" id="basic-addon1">.....</span>
                  <asp:textbox ID="txtNamaEdit" class="form-control" runat="server" onkeyup="upper(this)"></asp:textbox>
                      </div> </td>
              
          </tr>
           <tr>
              <td colspan="3" style="background:#ddd;font-weight:bold;font-family:Verdana;border-left:3px solid #d60000;padding:4px;"><span class="glyphicon glyphicon-info-sign"></span> Harga</td>
              </tr>
          <tr>
               <td style="width:45%;">
                   <asp:label ID="lblHarga" style="font-weight:bold;color:blue;" runat="server" text="null" ></asp:label><i style="font-size:8pt;color:#c0c0c0;"> (current)</i>
               </td>
              <td style="width:5%;"><span class="glyphicon glyphicon-arrow-right"></span></td>
              <td style="width:45%;">
                  <div class="input-group">
  <span class="input-group-addon" id="basic-addon1">Rp.</span>
                  <asp:textbox ID="txtHargaEdit" class="form-control" runat="server" onkeyup="Angka(this)"></asp:textbox>
                      </div>
              </td>
              
          </tr>
          
       

         
      </table>
      <center>
          <h6 style="text-align:left;font-weight:bold;color:#d60000;font-size:10pt;font-family:Verdana;">Aksi Edit :</h6>
          <div class="input-group" style="float:left;">
              
  <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-cog"></span></span>
          <asp:dropdownlist ID="drpEdit" runat="server" class="form-control" style="width:200px;">
              <asp:ListItem>
            </asp:ListItem>
            <asp:ListItem Value="1">-- EDIT VENDOR --</asp:ListItem>
            <asp:ListItem Value="2">-- EDIT BARANG --</asp:ListItem>
            <asp:ListItem Value="3">-- EDIT HARGA --</asp:ListItem>
              <asp:ListItem Value="4">-- EDIT SEMUA --</asp:ListItem>
          </asp:dropdownlist></div>
          <asp:Button ID="btnEdit" runat="server" Text="SIMPAN" class="btn btn-primary" style="float:left;margin-top:5px;font-family:Verdana;" OnClick="btnEdit_Click" /></center>
      </div>
     </div>
     </div>
            </div>
        </form>

     <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
</asp:Content>

