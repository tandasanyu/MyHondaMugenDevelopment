<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="datavendor.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/datepicker.js" type="text/javascript"></script>
    <title>Honda Mugen :: Data Vendor</title>
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
  <li><a href="datavendor.aspx"><span class="glyphicon glyphicon-copy"></span>&nbsp;&nbsp;Data Vendor</a></li>
</ol>
        <div class="input-group" style="width:25%;margin:8px;float:left;  ">
  <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-search"></span></span>
            <asp:TextBox ID="txtCari" runat="server" placeholder="Cari Nama, telepon atau lainnya.." CssClass="form-control"></asp:TextBox>
</div> <asp:Button ID="Button1" runat="server" class="btn btn-primary btn-sm" style="float:left;margin-top:8px;" Text="Cari Vendor" OnClick="Button1_Click" />
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-success btn-sm" Style="margin:8px;" NavigateUrl="#popup"><span class="glyphicon glyphicon-plus"></span>&nbsp;Vendor Baru</asp:HyperLink>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource2" EnableModelValidation="True" class="table table-bordered" style="width:100%;font-size:9pt;margin-left:8px;" ForeColor="Black" GridLines="Vertical">
              <AlternatingRowStyle BackColor="White" />
              <Columns>
                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
                <asp:TemplateField HeaderText="Nama Vendor" SortExpression="vendor_nama">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("vendor_nama") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telepon" SortExpression="vendor_telp">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("vendor_telp") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fax" SortExpression="vendor_fax">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("vendor_fax") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status Pajak" SortExpression="vendor_pkp">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("vendor_pkp") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="e-Mail" SortExpression="vendor_email">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("vendor_email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [vendor_nama], [vendor_telp], [vendor_email], [vendor_fax], [vendor_pkp] FROM [dbvendor] WHERE ([vendor_nama] LIKE '%' + @vendor_email + '%') OR ([vendor_telp] LIKE '%' + @vendor_email + '%') OR ([vendor_fax] LIKE '%' + @vendor_email + '%') OR ([vendor_email] LIKE '%' + @vendor_email + '%')">
            <SelectParameters>
                <asp:QueryStringParameter Name="vendor_email" QueryStringField="q" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableModelValidation="True" class="table table-striped table-bordered" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" style="font-size:9pt;">
            <Columns>
                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
                <asp:TemplateField HeaderText="Nama Vendor" SortExpression="vendor_nama">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("vendor_nama") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telepon" SortExpression="vendor_telp">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("vendor_telp") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fax" SortExpression="vendor_fax">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("vendor_fax") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status Pajak" SortExpression="vendor_pkp">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("vendor_pkp") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="e-Mail" SortExpression="vendor_email">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("vendor_email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Keterangan" SortExpression="vendor_keterangan">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("vendor_keterangan") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" SortExpression="vendor_nama">
                    <ItemTemplate>
                         <asp:HyperLink ID="HyperLink2" runat="server" 
                        NavigateUrl='<%# "?id=" + Eval("vendor_id") + "#edit" %>' Target="_self" Text="<span class='glyphicon glyphicon-cog'></span>&nbsp;Ubah" class="btn btn-primary btn-xs" style="font-weight:bold;"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
             <pagerstyle cssclass="gridview">

</pagerstyle>
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [vendor_keterangan], [vendor_id], [vendor_nama], [vendor_telp], [vendor_fax], [vendor_pkp], [vendor_email] FROM [dbvendor]"></asp:SqlDataSource>

    </div>

        <div id="popup">
 <div class="window">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
  <div class="panel-heading"><span class="glyphicon glyphicon-plus"></span> Tambah Vendor Baru <a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">

      <table>
          <tr>
              <td>Nama</td>
              <td><asp:TextBox ID="txtNama" runat="server" CssClass="form-control" Style="width:250px;margin:5px;float:left;" onkeyup="upper(this)"></asp:TextBox></td>
              <td>
                  <asp:DropDownList ID="drpBadan" runat="server" CssClass="form-control" Style="width:70px;float:left;margin:5px;">
                      <asp:ListItem></asp:ListItem>
                      <asp:ListItem>PT</asp:ListItem>
                      <asp:ListItem>CV</asp:ListItem>
                      <asp:ListItem>TB</asp:ListItem>
                      <asp:ListItem>TK</asp:ListItem>
                      <asp:ListItem>UD</asp:ListItem>
                  </asp:DropDownList></td>
          </tr>
           <tr>
              <td>Telepon</td>
              <td><asp:TextBox ID="txtKodet" runat="server" CssClass="form-control" Style="float:left;width:54px;margin:5px;" onkeyup="Angka(this)"></asp:TextBox>
                  <asp:TextBox ID="txtTelp" runat="server" CssClass="form-control" Style="float:left;width:156px;margin:5px;" onkeyup="Angka(this)"></asp:TextBox>
              </td>
               </tr>
          <tr>
              <td>Fax</td>
              <td><asp:TextBox ID="txtKodef" runat="server" CssClass="form-control" Style="float:left;width:54px;margin:5px;" onkeyup="Angka(this)"></asp:TextBox>
                  <asp:TextBox ID="txtFax" runat="server" CssClass="form-control" Style="float:left;width:156px;margin:5px;" onkeyup="Angka(this)"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>e-Mail</td>
              <td><asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Style="float:left;width:250px;margin:5px;"></asp:TextBox></td>
          </tr>
          <tr>
              <td>Status Pajak</td>
              <td>
                  <asp:DropDownList ID="drpStatus" runat="server" class="form-control" style="margin:5px;width:100px;">
                      <asp:ListItem></asp:ListItem>
                      <asp:ListItem>NON PKP</asp:ListItem>
                      <asp:ListItem>PKP</asp:ListItem>
                  </asp:DropDownList>
          </tr>
           <tr>
              <td>Keterangan</td>
              <td><asp:TextBox ID="txtKeteranganVendor" runat="server" CssClass="form-control" Style="float:left;width:250px;margin:5px;"></asp:TextBox></td>
          </tr>
      </table>
      <center><asp:Button ID="Button2" runat="server" Text="SIMPAN" class="btn btn-primary" style="margin:5px;font-family:Verdana;" OnClick="Button2_Click"/></center>
      </div>
     </div>
     </div>
            </div>

        <div id="edit">
 <div class="windowedit">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
  <div class="panel-heading"><span class="glyphicon glyphicon-cog"></span> Edit Data Vendor <a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">

      <table class="table">
          <tr>
              <td colspan="3" style="text-align:center;font-weight:bold;font-family:Verdana;color:#666;">
                  <asp:label runat="server" ID="lblNamaV"></asp:label>
              </td>
              </tr>
          <tr>
              <td colspan="3" style="background:#ddd;font-family:Verdana;border-left:3px solid #d60000;padding:3px;"><span class="glyphicon glyphicon-info-sign"></span> eMail Vendor</td>
              </tr>
          <tr>
               <td style="width:45%;">
                   <asp:label ID="lblEmailV" style="color:blue;" runat="server" text="null" ></asp:label><i style="font-size:8pt;color:#c0c0c0;"> (current)</i>
               </td>
              <td style="width:5%;"><span class="glyphicon glyphicon-arrow-right"></span></td>
              <td style="width:45%;">
                  <div class="input-group">
  <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-envelope"></span></span>
                  <asp:textbox runat="server" ID="txtEmailVEdit" class="form-control input-sm"></asp:textbox>
                      </div>
              </td>
              
          </tr>
           <tr>
              <td colspan="3" style="background:#ddd;font-family:Verdana;border-left:3px solid #d60000;padding:4px;"><span class="glyphicon glyphicon-info-sign"></span> Telpon Vendor</td>
              </tr>
          <tr>
               <td style="width:45%;">
                   <asp:label ID="lblTelpV" style="color:blue;" runat="server" text="null" ></asp:label><i style="font-size:8pt;color:#c0c0c0;"> (current)</i>
               </td>
              <td style="width:5%;"><span class="glyphicon glyphicon-arrow-right"></span></td>
              <td style="width:45%;">
                 <div class="input-group">
  <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-phone-alt"></span></span>
                  <asp:textbox ID="txtTelVEdit" class="form-control input-sm" runat="server" onkeyup="upper(this)"></asp:textbox>
                      </div> </td>
              
          </tr>
           <tr>
              <td colspan="3" style="background:#ddd;font-family:Verdana;border-left:3px solid #d60000;padding:4px;"><span class="glyphicon glyphicon-info-sign"></span> Fax Vendor</td>
              </tr>
          <tr>
               <td style="width:45%;">
                   <asp:label ID="lblFaxV" style="color:blue;" runat="server" text="null" ></asp:label><i style="font-size:8pt;color:#c0c0c0;"> (current)</i>
               </td>
              <td style="width:5%;"><span class="glyphicon glyphicon-arrow-right"></span></td>
              <td style="width:45%;">
                  <div class="input-group">
  <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-duplicate"></span></span>
                  <asp:textbox ID="txtFaxVEdit" class="form-control input-sm" runat="server"></asp:textbox>
                      </div>
              </td>
              
          </tr>
             <tr>
              <td colspan="3" style="background:#ddd;font-family:Verdana;border-left:3px solid #d60000;padding:4px;"><span class="glyphicon glyphicon-info-sign"></span> Keterangan Vendor</td>
              </tr>
          <tr>
               <td style="width:45%;">
                   <asp:label ID="lblKetV" style="color:blue;" runat="server" text="null" ></asp:label><i style="font-size:8pt;color:#c0c0c0;"> (current)</i>
               </td>
              <td style="width:5%;"><span class="glyphicon glyphicon-arrow-right"></span></td>
              <td style="width:45%;">
                  <div class="input-group">
  <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-duplicate"></span></span>
                  <asp:textbox ID="txtKetVEdit" class="form-control input-sm" runat="server"></asp:textbox>
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
            <asp:ListItem Value="1">-- EDIT EMAIL --</asp:ListItem>
            <asp:ListItem Value="2">-- EDIT TELP --</asp:ListItem>
            <asp:ListItem Value="3">-- EDIT FAX --</asp:ListItem>
            <asp:ListItem Value="5">-- EDIT KETERANGAN --</asp:ListItem>
              <asp:ListItem Value="4">-- EDIT SEMUA --</asp:ListItem>
          </asp:dropdownlist></div>
          <asp:Button ID="btnEdit" runat="server" Text="SIMPAN" class="btn btn-primary" style="float:left;margin-top:5px;font-family:Verdana;" onClick="btnEdit_Click"/></center>
      </div>
     </div>
     </div>
            </div>
     <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
    </form>
</asp:Content>

