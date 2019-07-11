﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobcontrolformanedtpuri.aspx.cs" Inherits="jobcontrolformanedtpuri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Honda Mugen :: Job Control Foreman</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <style>
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
.rcorners1 {
  border-radius: 25px;
  background: #DDDDDD;
  padding: 20px; 
  width: 200px;
  height: 150px;  
  position:relative;
}
.ThisDiv {
  position:absolute;
  top:30%;
  left:50%;
  transform: translateX(-50%);
  -webkit-transform: translateX(-50%);
        }
.window2 
{
position:relative;	
width: 30%;
top: 20px;
height:25%;
background: #fff;
border-radius: 8px;
position: relative;
padding: 10px;
box-shadow: 0 0 5px rgba(0,0,0,.4);
text-align: left;
margin: 2% auto;
overflow:auto;
            left: 0px;
        }


#popup2:target {
visibility: visible;
}
    #page-loader{
position:fixed !important;
top:0;
right:0;
bottom:0;
left:0;
z-index:9999;
background:Black url('img/loading.gif') no-repeat 50% 50%;
font:0/0;
text-shadow:none;
padding:1em 1.2em;
display:none;
opacity: 0.7;
}
    </style>
        <!-- Related Script -->
    <!-- CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <!-- JS -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
     <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <!-- Related JS -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#Div1').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "01";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div2').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "02";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div3').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "03";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div4').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "04";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div5').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "05";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div6').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "06";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div7').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "07";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div8').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "08";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div9').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "09";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div10').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "10";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div11').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "11";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div12').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "12";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div13').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "13";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div14').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "14";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            $('#Div15').click(function () {
                document.getElementById('<%=txtStatus.ClientID %>').value = "15";
                document.getElementById('<%= btnProses.ClientID %>').click()
            });
            //document.getElementById("dew").style.background = "#FF00FF";
            if (document.getElementById('<%=RB1.ClientID %>').checked) {
                document.getElementById("Div1").style.background = "#FFDC00";
            } else if (document.getElementById('<%=RB2.ClientID %>').checked){
                document.getElementById("Div2").style.background = "#FFDC00";
            }else if (document.getElementById('<%=RB3.ClientID %>').checked){
                document.getElementById("Div3").style.background = "#FFDC00";
            }else if (document.getElementById('<%=RB4.ClientID %>').checked){
                document.getElementById("Div4").style.background = "#FFDC00";
            }else if (document.getElementById('<%=RB5.ClientID %>').checked){
                document.getElementById("Div5").style.background = "#FFDC00";
            }else if (document.getElementById('<%=RB6.ClientID %>').checked){
                document.getElementById("Div6").style.background = "#FFDC00";
            }else if (document.getElementById('<%=RB7.ClientID %>').checked){
                document.getElementById("Div7").style.background = "#FFDC00";
            }else if (document.getElementById('<%=RB8.ClientID %>').checked){
                document.getElementById("Div8").style.background = "#FFDC00";
            }else if (document.getElementById('<%=RB9.ClientID %>').checked){
                document.getElementById("Div9").style.background = "#FFDC00";
            }else if (document.getElementById('<%=RB10.ClientID %>').checked){
                document.getElementById("Div10").style.background = "#FFDC00";
            }else if (document.getElementById('<%=RB11.ClientID %>').checked){
                document.getElementById("Div11").style.background = "#FFDC00";
            }else if (document.getElementById('<%=RB12.ClientID %>').checked){
                document.getElementById("Div12").style.background = "#FFDC00";
            }else if (document.getElementById('<%=RB13.ClientID %>').checked){
                document.getElementById("Div13").style.background = "#FFDC00";
            }else if (document.getElementById('<%=RB14.ClientID %>').checked){
                document.getElementById("Div14").style.background = "#FFDC00";
            }else if (document.getElementById('<%=RB15.ClientID %>').checked){
                document.getElementById("Div15").style.background = "#FFDC00";
            }
        });
    </script>
</head>
<body>
       <div id="page-loader"></div>
    <form id="form1" runat="server">
    <div>
        <div class="container">
            <div class="row">
                <div class="col">
                    <table style="font-size:1.0em;width:100%;"><tr><td><center style="background:#c0c0c0;">Data Proses</center>
                         <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" style="width:100%;float:left;">
                                <ItemTemplate>
                                    <table style="width:100%;font-family:Verdana;font-size:0.9em;" class="table table-striped">
                                        <tr><td style="width:30%;">No. WO</td><td>:</td><td style="font-weight:bold;color:blue;"> <asp:Label ID="WOHDR_NOLabel" runat="server" Text='<%# Eval("WOHDR_NO") %>' /></td></tr>
                                        <tr><td>Tgl. WO</td><td>:</td><td> <asp:Label ID="WOHDR_TGWOLabel" runat="server" Text='<%# Eval("WOHDR_TGWO") %>' /></td></tr>
                                        <tr><td>No. Polisi</td><td>:</td><td style="font-weight:bold;color:#333;"> <asp:Label ID="WOHDR_FNOPOLLabel" runat="server" Text='<%# Eval("WOHDR_FNOPOL") %>' /></td></tr>
                                        <tr><td>No. Rangka</td><td>:</td><td> <asp:Label ID="Label1" runat="server" Text='<%# Eval("WOHDR_FNRK") %>' /></td></tr>
                                        <tr><td>No. Mesin</td><td>:</td><td> <asp:Label ID="Label2" runat="server" Text='<%# Eval("WOHDR_FNMS") %>' /></td></tr>
                                        <tr><td>Nama Pemilik</td><td>:</td><td> <asp:Label ID="Label3" runat="server" Text='<%# Eval("WOHDR_FORG") %>' /></td></tr>
                                        <tr><td>Kode Tagih</td><td>:</td><td>  <asp:Label ID="Label4" runat="server" Text='<%# Eval("WOHDR_KDTAGIH") %>' /></td></tr>
                                        <tr><td>Service Advisor (SA)</td><td>:</td><td> <asp:Label ID="Label5" runat="server" Text='<%# Eval("WOHDR_SA") %>' /></td></tr>
                                        </table>
                                </ItemTemplate>
                            </asp:DataList>
                            </td></tr>
                    </table>
                </div>
                <div class="col">
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:service128Connection %>" SelectCommand="SELECT WOHDR_TGWO, WOHDR_FNOPOL, WOHDR_FNMS, WOHDR_FNRK, WOHDR_FORG, WOHDR_KDTAGIH, WOHDR_SA, WOHDR_NO FROM TRXN_WOHDR WHERE (WOHDR_NO = @WOHDR_FNOPOL)">
                         <SelectParameters>
                             <asp:QueryStringParameter Name="WOHDR_FNOPOL" QueryStringField="qnowo" Type="String" />
                         </SelectParameters>
                    </asp:SqlDataSource>
                  <table style="font-size:1.0em;width:100%;"><tr><td><center style="background:#c0c0c0;">Daftar Keluhan</center>
                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" EnableModelValidation="True" style="width:100%;float:left;font-family:Verdana;font-size:0.8em;" class="table table-striped"  PageSize="100" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Keluhan" SortExpression="WOKELUH_KELUH">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("WOKELUH_KELUH") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PageButtonCount="1" PreviousPageText="Prev" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:service128Connection %>" SelectCommand="SELECT WOKELUH_NOWO, WOKELUH_KELUH FROM TRXN_WOKELUH INNER JOIN TRXN_WOHDR ON TRXN_WOKELUH.WOKELUH_NOWO = TRXN_WOHDR.WOHDR_NO WHERE (WOHDR_NO = @qkey) ORDER BY WOKELUH_KELUH">
                             <SelectParameters>
                                 <asp:QueryStringParameter Name="qkey" QueryStringField="qnowo" />
                             </SelectParameters>
                        </asp:SqlDataSource>
                       </td></tr></table>
                </div>
            </div>
        </div>
          <div id="spoiler">
<div><input style="font-size: 11px; padding: 2px;" onclick="if (this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display != '') { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = ''; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = 'none'; this.innerText = ''; this.value = 'Sembunyikan'; } else { this.parentNode.parentNode.getElementsByTagName('div')['show'].style.display = 'none'; this.parentNode.parentNode.getElementsByTagName('div')['hide'].style.display = ''; this.innerText = ''; this.value = 'Tampilkan'; }" name="button" type="button" value="Buka Gambar Terakhir" /></div>
<div id="show" style="border: 1px solid white; display: none; margin: 5px; padding: 2px; width: 98%;">
    <asp:Image ID="Image1" runat="server"  Style="width:600px;height:400px;"/>
</div><div id="hide"></div></div>
      
     <!-- Gridview tidak terpakai -->
          <table style="font-size:0.85em;float:left;width:100%;"><tr><td><center style="background:#c0c0c0;">History Pengerjaan                                                            </center>
      <asp:GridView ID="GridView3" runat="server" Visible="false" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" EnableModelValidation="True" class="table table-striped" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" style="width:100%;">
          <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
          <Columns>
               <asp:TemplateField HeaderText="User" SortExpression="KERJABODY_USER">
                   <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("KERJABODY_USER") %>'></asp:Label>
                   </ItemTemplate>
                   <HeaderStyle Width="200px" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Tgl Kerja" SortExpression="KERJABODY_TANGGAL">
                   <ItemTemplate>
                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("KERJABODY_TANGGAL") %>'></asp:Label>
                   </ItemTemplate>
                   <HeaderStyle Width="150px" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Status" SortExpression="KERJABODY_STATUS">
                   <ItemTemplate>
                       <asp:Label ID="Label3" runat="server" Text='<%# Bind("statusval") %>'></asp:Label>
                   </ItemTemplate>
                   <HeaderStyle Width="5px" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Lokasi" SortExpression="KERJABODY_LOKASI">
                   <ItemTemplate>
                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("lokasimobil") %>'></asp:Label>
                   </ItemTemplate>
                   <HeaderStyle Width="5px" />
               </asp:TemplateField>
               <asp:TemplateField  HeaderText="Catatan" SortExpression="KERJABODY_CATATAN">
                   <ItemTemplate>
                       <asp:Label ID="Label5" runat="server" Text='<%# Bind("KERJABODY_CATATAN") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="" SortExpression="vendor" HeaderStyle-Width="5">
                     <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "jobcontrolformanedtpuri.aspx?qnowodel=" +  Eval("KERJABODY_NOWO") + "&&qtgldel=" + Eval("KERJABODY_TANGGAL") + "#popup2"%>' 
                             Target="_self" Text="<span class='glyphicon glyphicon-trash'></span> Delete" class="btn btn-danger btn-xs"></asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
               </Columns>
          <EditRowStyle BackColor="#999999" />
          <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
         </asp:GridView>
         </td></tr></table>
        <!-- Gridview tidak terpakai -->
         <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:service128Connection %>" SelectCommand="SELECT [KERJABODY_NOWO], [KERJABODY_TANGGAL], [KERJABODY_USER], 
	case [KERJABODY_STATUS] 
		WHEN 1 THEN 'DISERAHKAN SA KE VENDOR'
		when 2 then 'DITERIMA' 
		when 3 then 'BONGKAR' 
		when 4 then 'KETOK' 
		when 5 then 'DEMPUL' 
		when 6 then 'CAT/OVEN' 
		when 7 then 'POLES' 
		when 8 then 'PEMASANGAN' 
		when 9 then 'FINISHING'  
		when 10 then 'PENILAIAN QC - OK'	
		when 11 then 'PENILAIAN QC - NOT OK' 
		when 12 then 'PENILAIAN QC - REWORK' 
		when 13 then 'PENILAIAN QC - REWORK - OK'  
		when 14 then 'PENILAIAN QC - REWORK - NOT OK' 
		when 15 then 'PENYERAHAN UNIT QC KE SA BP'  
		else 'UNCATEGORIZED' end AS statusval, 
	case [KERJABODY_LOKASI] 
		when 1 then 'lt. 1' 
		when 2 then 'lt. 2' 
		when 3 then 'lt. 3' 
		when 4 then 'lt.4' 
		when 5 then 'lt. 5' 
		when 6 then 'lt. 6' 
		when 7 then 'lt. 7' 
		when 8 then 'lt. 8' 
		when 9 then 'lt. 9' 
		else '' END AS lokasimobil,[IDkrj_body], [KERJABODY_CATATAN] FROM [TEMP_KERJABODY] WHERE ([KERJABODY_NOWO] = @KERJABODY_NOWO) 
		ORDER BY KERJABODY_STATUS ASC">
             <SelectParameters>
                 <asp:QueryStringParameter Name="KERJABODY_NOWO" QueryStringField="qnowo" Type="String" />
             </SelectParameters>
         </asp:SqlDataSource>
    <!-- Menambah Kumpulan Radio Button -->
        <div id="example">
        <table id="singlechoice" align="center" style="display:none">
            <tr>
                <td style="padding:10px"><div runat="server" id="qq1" class="rcorners1" style="width:160px;height:160px;background-color:red;"><div runat="server" class="ThisDiv" ><asp:RadioButton GroupName="A" ID="RB1"  value="1" runat="server" />
                </div></div></td>
                <td style="padding:10px"><div id="qq2"  runat="server" class="rcorners1" style="width:160px;height:160px;background-color:red;"><div runat="server" class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB2"  runat="server" /></div></div></td>
                <td style="padding:10px"><div class="rcorners1" style="width:160px;height:160px;background-color:red;"><div runat="server" class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB3" runat="server" /></div></div></td>
                <td style="padding:10px"><div class="rcorners1" style="width:160px;height:160px;background-color:red;"><div runat="server" class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB4" runat="server" /></div></div></td>
            </tr>
            <tr>
                <td style="padding:10px"><div class="rcorners1" style="width:160px;height:160px;background-color:red;"><div runat="server" class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB5" runat="server" /></div></div></td>
                <td style="padding:10px"><div class="rcorners1" style="width:160px;height:160px;background-color:red;"><div runat="server" class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB6" runat="server" /></div></div></td>
                <td style="padding:10px"><div class="rcorners1" style="width:160px;height:160px;background-color:red;"><div runat="server" class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB7" runat="server" /></div></div></td>
                <td style="padding:10px"><div class="rcorners1" style="width:160px;height:160px;background-color:red;"><div runat="server" class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB8" runat="server" /></div></div></td>
            </tr>
            <tr>
                <td style="padding:10px"><div class="rcorners1" style="width:160px;height:160px;background-color:red;"><div runat="server" class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB9" runat="server" /></div></div></td>
                <td style="padding:10px"><div class="rcorners1" style="width:160px;height:160px;background-color:red;"><div runat="server" class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB10" runat="server" /></div></div></td>
                <td style="padding:10px"><div class="rcorners1" style="width:160px;height:160px;background-color:red;"><div class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB11" runat="server" /></div></div></td>
                <td style="padding:10px"><div class="rcorners1" style="width:160px;height:160px;background-color:red;"><div class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB12" runat="server" /></div></div></td>
            </tr>
            <tr>
                <td style="padding:10px"><div class="rcorners1" style="width:160px;height:160px;background-color:red;"><div class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB13" runat="server" /></div></div></td>
                <td style="padding:10px"><div class="rcorners1" style="width:160px;height:160px;background-color:red;"><div class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB14" runat="server" /></div></div></td>
                <td style="padding:10px"><div class="rcorners1" style="width:160px;height:160px;background-color:red;"><div class="ThisDiv"><asp:RadioButton GroupName="A" ID="RB15" runat="server" /></div></div></td>
            </tr>
        </table>
        <hr />
        <br />
            
        <br />
        </div>
        <div class="row">
            <div class="col">
                <div class="d-flex justify-content-center align-items-center" >
                    <table align="center">
                        <tr>
                            <td style="padding:10px"><div id="Div1" class="rcorners1" runat="server"><h2 style="align-self:center">DISERAHKAN SA KE VENDOR</h2></div></td>
                            <td style="padding:10px"><div id="Div2" class="rcorners1" runat="server"><h2 style="align-self:center">DITERIMA</h2></div></td>
                            <td style="padding:10px"><div id="Div3" class="rcorners1" runat="server"><h2 style="align-self:center">BONGKAR</h2></div></td>
                            <td style="padding:10px"><div id="Div4" class="rcorners1" runat="server"><h2 style="align-self:center">KETOK</h2></div></td>
                        </tr>
                        <tr>
                            <td style="padding:10px"><div id="Div5" class="rcorners1" runat="server"><h2 style="align-self:center">DEMPUL</h2></div></td>
                            <td style="padding:10px"><div id="Div6" class="rcorners1" runat="server"><h2 style="align-self:center">CAT/OVEN</h2></div></td>
                            <td style="padding:10px"><div id="Div7" class="rcorners1" runat="server"><h2 style="align-self:center">POLES</h2></div></td>
                            <td style="padding:10px"><div id="Div8" class="rcorners1" runat="server"><h2 style="align-self:center">PEMASANGAN</h2></div></td>
                        </tr>
                        <tr>
                            <td style="padding:10px"><div id="Div9" class="rcorners1" runat="server"><h2 style="align-self:center">FINISHING</h2></div></td>
                            <td style="padding:10px"><div id="Div10" class="rcorners1" runat="server"><h2 style="align-self:center">PENILAIAN QC - OK</h2></div></td>
                            <td style="padding:10px"><div id="Div11" class="rcorners1" runat="server"><h2 style="align-self:center">PENILAIAN QC - NOT OK</h2></div></td>
                            <td style="padding:10px"><div id="Div12" class="rcorners1" runat="server"><h2 style="align-self:center">PENILAIAN QC - REWORK</h2></div></td>
                        </tr>
                        <tr>
                            <td style="padding:10px"><div id="Div13" class="rcorners1" runat="server"><h2 style="align-self:center">PENILAIAN QC - REWORK - OK</h2></div></td>
                            <td style="padding:10px"><div id="Div14" class="rcorners1" runat="server"><h2 style="align-self:center">PENILAIAN QC - REWORK - NOT OK</h2></div></td>
                            <td style="padding:10px"><div id="Div15" class="rcorners1" runat="server"><h2 style="align-self:center">PENYERAHAN UNIT QC KE SA BP</h2></div></td>
                        </tr>
                    </table>
                    <div class="form-group">
                        <asp:TextBox ID="TextBox1" CssClass="hidden" AutoComplete="no" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="Button1" CssClass="hidden" runat="server"  Text="Button"  />
                    </div>
                </div>
            </div>
            <div class="col">
             <asp:ListView ID="ListViewHistoryPengerjaan" DataKeyNames ="IDkrj_body" DataSourceID="SqlDataSource4" runat="server" OnSelectedIndexChanged="ListViewHistoryPengerjaan_SelectedIndexChanged" >
                      <LayoutTemplate>
                          <table class="table table-hover text-centered">
                              <thead>
                                  <tr>
                                      <th>ID</th>
                                      <th>USER</th>
                                      <th>TANGGAL KERJA</th>
                                      <th>STATUS</th>
                                      <th>LOKASI</th>
                                      <th>CATATAN</th>
                                      <th>Aksi</th>
                                  </tr>
                              </thead>
                              <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                          </table>
                      </LayoutTemplate>
                      <ItemTemplate>
                        <tr>
                            <td><%#Eval("IDkrj_body")%></td>
                            <td><%#Eval("KERJABODY_USER")%></td>
                            <td><%#Eval("KERJABODY_TANGGAL","{0:dd/MM/yyyy}")%></td>
                            <td><%#Eval("statusval")%></td>
                            <td><%#Eval("lokasimobil")%></td>
                            <td><%#Eval("KERJABODY_CATATAN")%></td>
                            <td>
                                <asp:LinkButton ID="lnkSelect" Text='DETAIL' CommandName="Select" runat="server" ><img src="delete.png" width="80px" height="50px" /></asp:LinkButton>
                            </td>
                        </tr>
                      </ItemTemplate>
                      <EmptyDataTemplate>
                          DATA TIDAK DI TEMUKAN
                      </EmptyDataTemplate>
                  </asp:ListView>
                <div class="form-group">
                  <div id="addHistory" runat="server">
                  <table style="width:100%;" id="inputHistory" runat="server">
                      <tr>
                      <td style="width:15%;">Catatan</td>
                      <td>:</td>
                      <td> <asp:TextBox ID="txtCatatan" runat="server" CssClass="form-control input-sm" placeholder="Catatan..." style="margin:5px;"></asp:TextBox></td></tr>
                    <tr>
                      <td>Lokasi Mobil Lantai</td>
                      <td>:</td>
                      <td> <asp:DropDownList ID="txtLokasi" runat="server" style="margin:5px;" CssClass="form-control input-sm">
                          <asp:ListItem></asp:ListItem>
                          <asp:ListItem Value="1">Lantai 1</asp:ListItem>
                          <asp:ListItem Value="2">Lantai 2</asp:ListItem>
                          <asp:ListItem Value="3">Lantai 3</asp:ListItem>
                          <asp:ListItem Value="4">Lantai 4</asp:ListItem>
                          <asp:ListItem Value="5">Lantai 5</asp:ListItem>
                          <asp:ListItem Value="6">Lantai 6</asp:ListItem>
                          <asp:ListItem Value="7">Lantai 7</asp:ListItem>
                          <asp:ListItem Value="8">Lantai 8</asp:ListItem>
                          <asp:ListItem Value="9">Lantai 9</asp:ListItem>
                          </asp:DropDownList></td></tr>
                      <tr>
                        <td style="display:none">Status</td>
                        <td style="display:none">:</td>
                        <td style="display:none"> 
                          <asp:DropDownList ID="txtStatus" runat="server" class="form-control input-sm" style="margin:5px;">
                              <asp:ListItem></asp:ListItem>
                              <asp:ListItem Value="01">DISERAHKAN SA KE VENDOR</asp:ListItem>
                              <asp:ListItem Value="02">DITERIMA</asp:ListItem>
                              <asp:ListItem Value="03">BONGKAR</asp:ListItem>
                              <asp:ListItem Value="04">KETOK</asp:ListItem>
                              <asp:ListItem Value="05">DEMPUL</asp:ListItem>
                              <asp:ListItem Value="06">CAT / OVEN</asp:ListItem>
                              <asp:ListItem Value="07">POLES</asp:ListItem>
                              <asp:ListItem Value="08">PEMASANGAN</asp:ListItem>
                              <asp:ListItem Value="09">FINISHING</asp:ListItem>
                              <asp:ListItem Value="10">PENILAIAN QC - OK</asp:ListItem>
                              <asp:ListItem Value="11">PENILAIAN QC - REWORK</asp:ListItem>
                              <asp:ListItem Value="12">PENILAIAN QC - HASIL REWORK -- GOOD/NOT GOOD/LAIN2</asp:ListItem>
                              <asp:ListItem Value="13">JIKA HASIL REWORK LAIN2, CATATAN DARI QC</asp:ListItem>
                              <asp:ListItem Value="14">PENYERAHAN UNIT DARI VENDOR KE QC</asp:ListItem>
                              <asp:ListItem Value="15">PENERIMAAN UNIT QC DARI VENDOR</asp:ListItem>
                              <asp:ListItem Value="16">PENYERAHAN UNIT QC KE SA BP</asp:ListItem>
                          </asp:DropDownList>
                      </td></tr>
                        <tr>
                      <td style="display:none">Foto</td>
                      <td style="display:none">:</td>
                      <td style="display:none">
                          <asp:FileUpload ID="txtFoto" runat="server" style="margin:5px;" class="form-control input-sm" /></td>
                  </tr>
                      <tr>
                      <td></td>
                      <td></td>
                      <td style="display:none"><asp:Button ID="btnProses" runat="server" Text="SUBMIT" CssClass="btn btn-success btn-sm" style="margin:5px;" OnClick="btnProses_Click" /> </td></tr>
                </table>
                      </div>
                </div>
                <div class="form-group">
                    <asp:Button ID="BtnReportBPPuri" runat="server" CssClass="btn btn-danger" Text="Cetak Report" OnClick="BtnReportBPPuri_Click"  />
                </div>
            </div>
        </div>
        
            <div class="form-row text-center">
                <div class="col-12">
                    <asp:Button ID="BtnDelete" Visible="false" runat="server" class="btn btn-danger btn-xs" Text="Delete Data Terpilih" />
                </div>
             </div>   
        

     <center><asp:Button ID="btnUnclosing" runat="server" Text="Unclosing" CssClass="btn btn-danger btn-sm" style="margin:5px;" OnClick="btnUnclosing_Click" /></center>
    </div>
        
        <div id="popup2">
                 <div class="window2">
                      <div class="panel panel-primary" style="width:100%;margin:2px;">
   <div class="panel-heading" style="text-align:left;"><span class="glyphicon glyphicon-trash"></span> Delete History<button class="btn btn-danger btn-sm" style="float:right;padding:3px;margin:-2px;font-weight:bold;font-family:Verdana;font-size:8pt;"><span class="glyphicon glyphicon-remove"></span> CLOSE</button></div>
  <div class="panel-body"> <center>
      <asp:label ID="lblPesanBisa" runat="server" text="Anda yakin ingin menghapus history ?"></asp:label>
       <asp:label ID="lblPesanGagal" runat="server" text="Anda tidak memiliki hak akses untuk menghapus history"></asp:label><br />
      <asp:Button ID="Button2" runat="server" Text="CONFIRM" CssClass="btn btn-success btn-sm" OnClick="Button2_Click"/>
      <asp:Button ID="Button3" runat="server" Text="CANCEL" class="btn btn-danger btn-sm" OnClick="Button3_Click"/></center>
      </div> </div> </div> </div>
    </form>
       <script type="text/javascript">
//<![CDATA[
// Menyisipkan markup tabir animasi
$(document.body).append('<div id="page-loader"></div>');
// Saat halaman terpicu untuk berpindah/keluar menuju halaman lain...
$(window).on("beforeunload", function() {
    // ... tampilkan tabir animasi dengan efek `.fadeIn()`
    $('#page-loader').fadeIn(1000).delay(8000).fadeOut(1000);
});
//]]>
</script>
</body>
</html>
