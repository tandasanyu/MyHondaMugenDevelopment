<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="headBeranda" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Honda Mugen :: Home</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="bodySesuaiHalaman" ContentPlaceHolderID="body" Runat="Server"> 
    <form id="form1" runat="server">
     <div class="container-fluid">
     <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
</ol>
<!-- Apply any bg-* class to to the info-box to color it -->
 <div style="float:left;width:30px;height:50px;background:#B22222;color:#f5f5f5;padding:8px;">
  <span class="glyphicon glyphicon-user"></span>  <span class="info-box-number" style="font-weight:bold;">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></span>
  </div>
<div class="info-box bg-red" style="font-family:verdana;float:left;background:#800000;width:150px;height:50px;color:#f5f5f5;padding:8px;">
  <div class="info-box-content">
    <span class="info-box-text">Online User</span><br />
  
    <!-- The progress section is optional -->
   <div class="progress" style="height:10px;">
  <div class="progress-bar progress-bar-striped progress-bar-danger active" role="progressbar" aria-valuenow="45" aria-valuemin="0" aria-valuemax="100" style="width: 75%;" runat="server">
  </div>
</div>
  </div><!-- /.info-box-content -->
</div><!-- /.info-box -->

         <asp:gridview runat="server" AutoGenerateColumns="False" style="left:5px;" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="username" DataSourceID="SqlDataSource1" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical">
             <AlternatingRowStyle BackColor="White" />
             <Columns>
                   <asp:TemplateField HeaderText="No." HeaderStyle-Width="5">
        <itemtemplate>
        <%# Container.DataItemIndex + 1 %>
          </ItemTemplate>
          <headerstyle HorizontalAlign="Center" />
        </asp:TemplateField>
                 <asp:TemplateField HeaderText="User" SortExpression="username">
                     <ItemTemplate>
                         <asp:Label ID="Label1" style="padding:5px;color:#333;font-size:9pt;" runat="server" Text='<%# Bind("username") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Last Login" SortExpression="lastlogin">
                     <ItemTemplate>
                         <asp:Label ID="Label2" style="color:blue;padding:5px;font-size:8pt;"  runat="server" Text='<%# Bind("lastlogin") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#CCCC99" />
             <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
             <RowStyle BackColor="#F7F7DE" />
             <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
         </asp:gridview>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [username], [lastlogin] FROM [tb_user] WHERE ([online] = @online) ORDER BY [username]">
             <SelectParameters>
                 <asp:Parameter DefaultValue="Y" Name="online" Type="String" />
             </SelectParameters>
         </asp:SqlDataSource>
    </div>
    </form>
    <script src="js/jquery.min.js"></script>
     <script src="js/bootstrap.min.js"></script>
</asp:Content>
