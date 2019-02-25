<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="utility.aspx.cs" Inherits="utilty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Honda Mugen :: Utility</title>
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
#popup4 {
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
#popup2:target {
visibility: visible;
}
#popup3:target {
visibility: visible;
}
#popup4:target {
visibility: visible;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <form id="form1" runat="server">
     <div class="container-fluid">
     <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
  <li><a href="#"><span class="glyphicon glyphicon-folder-open"></span>&nbsp;&nbsp;Database</a></li>
  <li><span class="glyphicon glyphicon-eye-open"></span>&nbsp;&nbsp;Utilty</li>
</ol>
<!-- find username section below -->
                <div class="panel panel-primary" style="width:40%;float:left;margin:5px;">
                  <div class="panel-heading"><span class="glyphicon glyphicon-plus-sign"></span>  Pilih Username</div>
                  <div class="panel-body">
                      <asp:DropDownList ID="txtUsername" runat="server" DataSourceID="SqlDataSource3" DataTextField="username" DataValueField="username" Class="form-control"></asp:DropDownList>
                         <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [username] FROM [tb_userGeneral] ORDER BY [username]"></asp:SqlDataSource>
                         <asp:Button ID="Button1" class="btn btn-primary btn-sm" style="margin:5px;" 
                          runat="server" Text="Cari" OnClick="Button1_Click" />
                      <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Small" 
                          ForeColor="Red"></asp:Label>
                  </div>
                </div>
         <br style="clear:both;"/>
<!--Menu Tambah Hak Akses  -->
         <table>
             <tr>
                 <td>
                     <!-- Div hak Akses PO -->
                        <%--<div class="panel panel-success" style="width:55%;float:left;margin:5px;">--%>

                          <div class="panel-heading"><span class="glyphicon glyphicon-plus-sign"></span> Tambah Akses PO</div>
                          <%--<div class="panel-body">--%>
                          <asp:TextBox ID="txtHasilUsername" width="300px" class="form-control" style="margin:5px;" placeholder="Username" onkeyup="upper(this)" runat="server"></asp:TextBox>
                              <asp:dropdownlist runat="server" width="300px" ID="txtHakAkses" DataSourceID="SqlDataSource2" DataTextField="namaakses" DataValueField="namaakses" class="form-control" style="margin:5px;font-size:9pt;font-family:Verdana;font-weight:bold;color:#0080c0;" ></asp:dropdownlist>
                               <br />
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Visible="false">
                                    <asp:ListItem Text="Pasar Minggu" Value="112" />
                                    <asp:ListItem Text="Puri" Value="128" />
                                </asp:RadioButtonList>
                         <br />                         
                         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [kategoriakses], [namaakses] FROM [tb_userakses] ORDER BY [namaakses] ASC"></asp:SqlDataSource>
                               <asp:Button ID="Button2" class="btn btn-success btn-sm" style="margin:5px;" 
                                  runat="server" Text="Add" OnClick="Button2_Click" />
                              <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Small" 
                                  ForeColor="Red"></asp:Label>
            <%--              </div>
                        </div>--%>
                 </td>
                 <td>
                                 <!-- Div hak Akses Hrd -->
                        <%--<div class="panel panel-success" style="width:55%;float:left;margin:5px;">--%>
                          <div class="panel-heading"><span class="glyphicon glyphicon-plus-sign"></span> Tambah Akses HRD</div>
                          <%--<div class="panel-body">--%>
                          <asp:TextBox ID="txtHasilUsername2" width="300px" class="form-control" style="margin:5px;" placeholder="Username" onkeyup="upper(this)" runat="server"></asp:TextBox>
                              <asp:dropdownlist runat="server" width="300px" ID="TxtHakAksesHRD" DataSourceID="SqlDataSource4" DataTextField="namaakses" DataValueField="namaakses" class="form-control" style="margin:5px;font-size:9pt;font-family:Verdana;font-weight:bold;color:#0080c0;" ></asp:dropdownlist>
                              <br />
                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" Visible="false">
                                    <asp:ListItem Text="Pasar Minggu" Value="112" />
                                    <asp:ListItem Text="Puri" Value="128" />
                                </asp:RadioButtonList>
                         <br />         
                         <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:herlambangConnectionString %>" SelectCommand="SELECT [kategoriakses], [namaakses] FROM [tb_userakses] ORDER BY [namaakses] ASC"></asp:SqlDataSource>
                               <asp:Button ID="Button4" class="btn btn-success btn-sm" style="margin:5px;" 
                                  runat="server" Text="Add" OnClick="Button4_Click" />
                              <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="X-Small" 
                                  ForeColor="Red"></asp:Label>
            <%--              </div>
                        </div>--%>
                 </td>
             </tr>
             <tr>
                 <td>
                                 <!-- Div hak Akses Sales WareHouse -->
                        <%--<div class="panel panel-success" style="width:55%;float:left;margin:5px;">--%><br /><br />
                          <div class="panel-heading"><span class="glyphicon glyphicon-plus-sign"></span> Tambah Akses Sales Warehouse</div>
                          <%--<div class="panel-body">--%>
                          <asp:TextBox ID="txtHasilUsername3" width="300px" class="form-control" style="margin:5px;" placeholder="Username" onkeyup="upper(this)" runat="server"></asp:TextBox>
                              <asp:dropdownlist runat="server" width="300px" ID="TxtHakAksesSales" DataSourceID="SqlDataSource5" DataTextField="namaakses" DataValueField="namaakses" class="form-control" style="margin:5px;font-size:9pt;font-family:Verdana;font-weight:bold;color:#0080c0;" ></asp:dropdownlist>
                      
                                Pilih Cabang Hak Akses : <br />
                                <asp:RadioButtonList ID="RbCabang" runat="server">
                                    <asp:ListItem Text="Pasar Minggu" Value="112" />
                                    <asp:ListItem Text="Puri" Value="128" />
                                </asp:RadioButtonList>

                               
                         <br />      
                         <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:herlambangConnectionString2 %>" SelectCommand="SELECT [kategoriakses], [namaakses] FROM [tb_userakses] ORDER BY [namaakses] ASC"></asp:SqlDataSource>
                               <asp:Button ID="Button9" class="btn btn-success btn-sm" style="margin:5px;" 
                                  runat="server" Text="Add" OnClick="Button9_Click" />
                              <asp:Label ID="Label32" runat="server" Font-Bold="True" Font-Size="X-Small" 
                                  ForeColor="Red"></asp:Label>
            <%--              </div>
                        </div>--%>
                 </td>
                 <td>
                                 <!-- Div hak Akses Service [belum di ubah data ahaksesnya. Masih mengikuti menu sales warehouse]--> 
                        <%--<div class="panel panel-success" style="width:55%;float:left;margin:5px;">--%>
                          <div class="panel-heading"><span class="glyphicon glyphicon-plus-sign"></span> Tambah Akses Service</div>
                          <%--<div class="panel-body">--%>
                          <asp:TextBox ID="txtHasilUsername4" width="300px" class="form-control" style="margin:5px;" placeholder="Username" onkeyup="upper(this)" runat="server"></asp:TextBox>
                              <asp:dropdownlist runat="server" width="300px" ID="TxtHakAksesService" DataSourceID="SqlDataSource6" DataTextField="namaakses" DataValueField="namaakses" class="form-control" style="margin:5px;font-size:9pt;font-family:Verdana;font-weight:bold;color:#0080c0;" ></asp:dropdownlist>
                               <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:herlambangConnectionString2 %>" SelectCommand="SELECT [kategoriakses], [namaakses] FROM [tb_userakses] ORDER BY [namaakses] ASC"></asp:SqlDataSource>
                               <asp:Button ID="Button10" class="btn btn-success btn-sm" style="margin:5px;" 
                                  runat="server" Text="Add" OnClick="Button10_Click" />
                              <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="X-Small" 
                                  ForeColor="Red"></asp:Label><br />
            <%--              </div>
                        </div>--%>
                 </td>
             </tr>
         </table>
         <asp:Button ID="Button6" runat="server" Text="tESTfUNCTION" OnClick="Button6_Click" Visible ="false"/>        
         <br style="clear:both;"/>
<!-- section Gridview Below-->'
         <table>
             <tr>
                 <td>
                     <!-- gridvie po-->
                      <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> <asp:Label ID="Label12" runat="server" Text="Table Hak Akses Menu PO" ></asp:Label> </h3>
                     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
                               AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" 
                               ForeColor="#333333" GridLines="None" 
                               class="table table-bordered table-hovered" 
                               style="width: 70%;position:relative;top:5px;left:5px;" Font-Size="Small" PagerSettings-Mode="NumericFirstLast" PagerSettings-PageButtonCount="10" PagerSettings-Position="Bottom" EnableModelValidation="True" PageSize="5">
                         <RowStyle BackColor="#EFF3FB" />
                         <Columns>
                                <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
                    <itemtemplate>
                    <%# Container.DataItemIndex + 1 %>
                      </ItemTemplate>
                      <headerstyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                             <asp:TemplateField HeaderText="Username" SortExpression="username">
                                 <ItemTemplate>
                                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("username") %>' style="font-weight:bold;color:blue;"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Menu" SortExpression="username">
                                 <ItemTemplate>
                                     <asp:Label ID="Label5" runat="server" Text='<%# Bind("kategoriakses") %>' style="font-weight:bold;color:#666;font-size:8pt;"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Hak akses" SortExpression="hakakses">
                                 <ItemTemplate>
                                     <i><asp:Label ID="Label3" runat="server" Text='<%# Bind("hakakses") %>' style="font-weight:bold;color:#666;font-size:8pt;"></asp:Label></i>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderStyle-Width="5">
                                 <ItemTemplate>
                                     <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "utility.aspx?quser=" + Eval("username") + "&&id=" + Eval("idutility") + "&&username=" + Eval("username") + "#popup"%>' 
                                         Target="_self" Text="<span class='glyphicon glyphicon-floppy-remove'></span>&nbsp;&nbsp;Hapus Akses" class="btn btn-danger btn-xs"></asp:HyperLink>
                                 </ItemTemplate>

                            <HeaderStyle Width="5px"></HeaderStyle>
                             </asp:TemplateField>
                     
                         </Columns>
                         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" PageButtonCount="5"></PagerSettings>

                          <pagerstyle cssclass="gridview">

                            </pagerstyle>
                         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                         <EditRowStyle BackColor="#2461BF" />
                         <AlternatingRowStyle BackColor="White" />
                        <emptydatatemplate>
                                      
                            Data Tidak Ditemukan 
                
                        </emptydatatemplate> 
                     </asp:GridView>
                              <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>"                    
                                    SelectCommand="SELECT * FROM [tb_userutility] INNER JOIN [tb_userakses] ON tb_userutility.hakakses = tb_userakses.namaakses WHERE ([username] = @username) ORDER BY idakses ASC">
                                   <SelectParameters>
                                       <asp:QueryStringParameter Name="username" QueryStringField="quser" Type="String" />
                                   </SelectParameters>                   
                               </asp:SqlDataSource>     
                 </td>
                 <td>
                     <!-- Added Menu By Herlambang--> 
                           <asp:SqlDataSource ID="SqlDataSource5GrdViewAksesHRD" runat="server" 
                               ConnectionString="<%$ ConnectionStrings:herlambangConnectionString %>" 
                   
                               SelectCommand="SELECT * FROM [tb_userutility] INNER JOIN [tb_userakses] ON tb_userutility.hakakses = tb_userakses.namaakses WHERE ([username] = @username) ORDER BY idakses ASC">
                               <SelectParameters>
                                   <asp:QueryStringParameter Name="username" QueryStringField="quser" Type="String" />
                               </SelectParameters>                   
                               </asp:SqlDataSource>

                                <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> <asp:Label ID="Label18" runat="server" Text="Table Hak Akses Menu HRD" ></asp:Label> </h3>
                                 <asp:GridView ID="GridView2" runat="server"  AllowPaging="True" AllowSorting="True" 
                                           AutoGenerateColumns="False" DataSourceID="SqlDataSource5GrdViewAksesHRD" CellPadding="4" 
                                           ForeColor="#333333" GridLines="None" 
                                           class="table table-bordered table-hovered" 
                                           style="width: 70%;position:relative;top:5px;left:5px;" Font-Size="Small" PagerSettings-Mode="NumericFirstLast" PagerSettings-PageButtonCount="10" PagerSettings-Position="Bottom" EnableModelValidation="True" PageSize="5">
                                     <RowStyle BackColor="#EFF3FB" />
                                     <Columns>
                                            <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
                                <itemtemplate>
                                <%# Container.DataItemIndex + 1 %>
                                  </ItemTemplate>
                                  <headerstyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Username" SortExpression="username">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label2" runat="server" Text='<%# Bind("username") %>' style="font-weight:bold;color:blue;"></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Menu" SortExpression="username">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label5" runat="server" Text='<%# Bind("kategoriakses") %>' style="font-weight:bold;color:#666;font-size:8pt;"></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Hak akses" SortExpression="hakakses">
                                             <ItemTemplate>
                                                 <i><asp:Label ID="Label3" runat="server" Text='<%# Bind("hakakses") %>' style="font-weight:bold;color:#666;font-size:8pt;"></asp:Label></i>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Width="5">
                                             <ItemTemplate>
                                                 <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "utility.aspx?quser=" + Eval("username") + "&&id=" + Eval("idutility") + "&&username=" + Eval("username") + "#popup2"%>' 
                                                     Target="_self" Text="<span class='glyphicon glyphicon-floppy-remove'></span>&nbsp;&nbsp;Hapus Akses" class="btn btn-danger btn-xs"></asp:HyperLink>
                                             </ItemTemplate>

                        <HeaderStyle Width="5px"></HeaderStyle>
                                         </asp:TemplateField>
                     
                                     </Columns>
                                     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" PageButtonCount="5"></PagerSettings>

                                      <pagerstyle cssclass="gridview">

                        </pagerstyle>
                                     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                     <EditRowStyle BackColor="#2461BF" />
                                     <AlternatingRowStyle BackColor="White" />
                        <emptydatatemplate>
                                      
                            Data Tidak Ditemukan
                
                        </emptydatatemplate> 
                                 </asp:GridView>
                                 <!-- Added Menu By Herlambang--> 
                 </td>
             </tr>
             <tr>
                 <td>
                        <!-- Gridvie Menu Sales WareHouse -->
                     
                            <asp:SqlDataSource ID="SqlDataSourceGridViewSales" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:herlambangConnectionString2 %>"                    
                                SelectCommand="SELECT * FROM [tb_userutility] INNER JOIN [tb_userakses] ON tb_userutility.hakakses = tb_userakses.namaakses WHERE ([username] = @username) ORDER BY idakses ASC">
                               <SelectParameters>
                                   <asp:QueryStringParameter Name="username" QueryStringField="quser" Type="String" />
                               </SelectParameters>                   
                            </asp:SqlDataSource>

                            <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> <asp:Label ID="Label21" runat="server" Text="Table Hak Akses Sales Ware House" ></asp:Label> </h3>
                             <asp:GridView ID="GridView3" runat="server"  AllowPaging="True" AllowSorting="True" 
                                       AutoGenerateColumns="False" DataSourceID="SqlDataSourceGridViewSales" CellPadding="4" 
                                       ForeColor="#333333" GridLines="None" 
                                       class="table table-bordered table-hovered" 
                                       style="width: 70%;position:relative;top:5px;left:5px;" Font-Size="Small" PagerSettings-Mode="NumericFirstLast" PagerSettings-PageButtonCount="10" PagerSettings-Position="Bottom" EnableModelValidation="True" PageSize="5">
                                 <RowStyle BackColor="#EFF3FB" />
                                 <Columns>
                                        <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
                            <itemtemplate>
                            <%# Container.DataItemIndex + 1 %>
                              </ItemTemplate>
                              <headerstyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Username" SortExpression="username">
                                         <ItemTemplate>
                                             <asp:Label ID="Label2" runat="server" Text='<%# Bind("username") %>' style="font-weight:bold;color:blue;"></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Menu" SortExpression="username">
                                         <ItemTemplate>
                                             <asp:Label ID="Label5" runat="server" Text='<%# Bind("kategoriakses") %>' style="font-weight:bold;color:#666;font-size:8pt;"></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Hak akses" SortExpression="hakakses">
                                         <ItemTemplate>
                                             <i><asp:Label ID="Label3" runat="server" Text='<%# Bind("hakakses") %>' style="font-weight:bold;color:#666;font-size:8pt;"></asp:Label></i>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Cabang" SortExpression="hakakses">
                                         <ItemTemplate>
                                             <i><asp:Label ID="Label3" runat="server" Text='<%# Bind("cabang") %>' style="font-weight:bold;color:#666;font-size:8pt;"></asp:Label></i>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderStyle-Width="5">
                                         <ItemTemplate>
                                              <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "utility.aspx?quser=" + Eval("username") + "&&id=" + Eval("idutility") + "&&username=" + Eval("username") + "#popup3"%>' 
                                                 Target="_self" Text="<span class='glyphicon glyphicon-floppy-remove'></span>&nbsp;&nbsp;Hapus Akses" class="btn btn-danger btn-xs"></asp:HyperLink>
                                         </ItemTemplate>

                                <HeaderStyle Width="5px"></HeaderStyle>
                                     </asp:TemplateField>
                     
                                 </Columns>
                                 <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                                 <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" PageButtonCount="5"></PagerSettings>

                                  <pagerstyle cssclass="gridview">

                                  </pagerstyle>
                                 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                 <EditRowStyle BackColor="#2461BF" />
                                 <AlternatingRowStyle BackColor="White" />
                    <emptydatatemplate>
                                      
                        Data Tidak Ditemukan
                
                    </emptydatatemplate> 
                             </asp:GridView>

                         <!-- Gridvie Menu Sales WareHouse -->
                 </td>
                 <td>
                     <h3 style="font-family:Blunter;"><span class="glyphicon glyphicon-user"></span> <asp:Label ID="Label20" runat="server" Text="Table Hak Akses Service" ></asp:Label> </h3>
                 </td>
             </tr>
         </table>            
<br />
<br />
         <br />
         <br />
         <br />
         <br />                     




          <div id="popup">
 <div class="window">
 <div class="panel panel-primary" style="width:100%;margin:3px;">
 <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-floppy-remove"></span> Konfirmasi Hapus Data Hak Akses PO<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
  <div class="panel-body">
    <table style="text-align:center;width:100%;">
    <tr>
        <td><asp:TextBox ID="txtHapusAkses" runat="server" Visible="False"></asp:TextBox></td>
    </tr>
     <tr>
         <td><asp:Label ID="Label11" runat="server" Text="Apakah anda yakin ingin menghapus hak akses"></asp:Label>
             <asp:Label ID="Label7" runat="server" Text="dari user id"></asp:Label>
             <i><asp:Label ID="Label8" runat="server" Text="" style="color:blue;"></asp:Label></i>
             <asp:Label ID="Label9" runat="server" Text=" ?"></asp:Label>
         </td>
     </tr>
     <tr>
         <td><asp:Button ID="Button3" runat="server" Text="CONFIRM" 
                 class="btn btn-success btn-sm" style="margin:5px;font-weight:bold;" OnClick="Button3_Click"  />
                 <asp:HyperLink ID="HyperLink5" runat="server" class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" NavigateUrl="#">CANCEL</asp:HyperLink></td>
                  <tr>
         <td></td>
         <td></td>
         <td>
             <asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>
     </tr>
         </tr>
    </table>
  </div>
  </div>
 </div>
 </div>
         <!-- Added Menu By Herlambang -->
             <div id="popup2">
             <div class="window">
             <div class="panel panel-primary" style="width:100%;margin:3px;">
             <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-floppy-remove"></span> Konfirmasi Hapus Data Hak Akses HRD<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
              <div class="panel-body">
                <table style="text-align:center;width:100%;">
                <tr>
                    <td><asp:TextBox ID="txtHapusAkses2" runat="server" Visible="False"></asp:TextBox></td>
                </tr>
                 <tr>
                     <td><asp:Label ID="Label13" runat="server" Text="Apakah anda yakin ingin menghapus hak akses"></asp:Label>
                         <asp:Label ID="Label14" runat="server" Text="dari user id"></asp:Label>
                         <i><asp:Label ID="Label15" runat="server" Text="" style="color:blue;"></asp:Label></i>
                         <asp:Label ID="Label16" runat="server" Text=" ?"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td><asp:Button ID="Button5" runat="server" Text="CONFIRM" 
                             class="btn btn-success btn-sm" style="margin:5px;font-weight:bold;" OnClick="Button5_Click"  />
                             <asp:HyperLink ID="HyperLink2" runat="server" class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" NavigateUrl="#">CANCEL</asp:HyperLink></td>
                              <tr>
                     <td></td>
                     <td></td>
                     <td>
                         <asp:Label ID="Label17" runat="server" Text=""></asp:Label></td>
                 </tr>
                </table>
              </div>
              </div>
             </div>
             </div>
         <!-- Added Menu By Herlambang [Menu Sales WareHouse] -->
             <div id="popup3">
             <div class="window">
             <div class="panel panel-primary" style="width:100%;margin:3px;">
             <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-floppy-remove"></span> Konfirmasi Hapus Data Hak Akses Sales Ware House<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
              <div class="panel-body">
                <table style="text-align:center;width:100%;">
                <tr>
                    <td><asp:TextBox ID="txtHapusAkses3" runat="server" Visible="False"></asp:TextBox></td>
                </tr>
                 <tr>
                     <td><asp:Label ID="Label22" runat="server" Text="Apakah anda yakin ingin menghapus hak akses"></asp:Label>
                         <asp:Label ID="Label23" runat="server" Text="dari user id"></asp:Label>
                         <i><asp:Label ID="Label24" runat="server" Text="" style="color:blue;"></asp:Label></i>
                         <asp:Label ID="Label25" runat="server" Text=" ?"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td><asp:Button ID="Button7" runat="server" Text="CONFIRM" 
                             class="btn btn-success btn-sm" style="margin:5px;font-weight:bold;" OnClick="Button7_Click"  />
                             <asp:HyperLink ID="HyperLink3" runat="server" class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" NavigateUrl="#">CANCEL</asp:HyperLink></td>
                              <tr>
                     <td></td>
                     <td></td>
                     <td>
                         <asp:Label ID="Label26" runat="server" Text=""></asp:Label></td>
                 </tr>
                </table>
              </div>
              </div>
             </div>
             </div>
         <!-- Added Menu By Herlambang [Menu Service] -->
             <div id="popup4">
             <div class="window">
             <div class="panel panel-primary" style="width:100%;margin:3px;">
             <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-floppy-remove"></span> Konfirmasi Hapus Data Hak Akses Menu Service<a href="#" class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</a></div>
              <div class="panel-body">
                <table style="text-align:center;width:100%;">
                <tr>
                    <td><asp:TextBox ID="txtHapusAkses4" runat="server" Visible="False"></asp:TextBox></td>
                </tr>
                 <tr>
                     <td><asp:Label ID="Label27" runat="server" Text="Apakah anda yakin ingin menghapus hak akses"></asp:Label>
                         <asp:Label ID="Label28" runat="server" Text="dari user id"></asp:Label>
                         <i><asp:Label ID="Label29" runat="server" Text="" style="color:blue;"></asp:Label></i>
                         <asp:Label ID="Label30" runat="server" Text=" ?"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td><asp:Button ID="Button8" runat="server" Text="CONFIRM" 
                             class="btn btn-success btn-sm" style="margin:5px;font-weight:bold;" OnClick="Button5_Click"  />
                             <asp:HyperLink ID="HyperLink4" runat="server" class="btn btn-danger btn-sm" style="margin:5px;font-weight:bold;" NavigateUrl="#">CANCEL</asp:HyperLink></td>
                              <tr>
                     <td></td>
                     <td></td>
                     <td>
                         <asp:Label ID="Label31" runat="server" Text=""></asp:Label></td>
                 </tr>
                </table>
              </div>
              </div>
             </div>
             </div>

    <script src="js/jquery.min.js"></script>
     <script src="js/bootstrap.min.js"></script>
          
    </form>
</asp:Content>

