<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="jobcontrolforman.aspx.cs" Inherits="jobcontrolforman" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Honda Mugen :: Job Control Foreman</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
     <link href="css/datepicker.css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
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
    <style type="text/css">
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
width: 85%;
top: 20px;
height: 80%;
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
 #closing {
width: 100%;
height: 100%;
position: fixed;
background: rgba(0,0,0,.7);
top: 0;
left: 0;
z-index: 9999;
visibility: hidden;
}

 .windowclosing
{
position:relative;	
width: 85%;
top: 20px;
height: 80%;
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
#closing:target {
visibility: visible;
}

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
  
    <form runat="server">
          
       <ol class="breadcrumb">
  <li><a href="home.aspx"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Home</a></li>
  <li><a href="#"><span class="glyphicon glyphicon-tint"></span>&nbsp;&nbsp;Body & Paint</a></li>
  <li><span class="glyphicon glyphicon-list-alt"></span>&nbsp;&nbsp;Form Job Control Foreman</li>
</ol>
           
                 <div style="width:400px;margin:5px;background:linear-gradient(#c0c0c0, #ddd);padding:5px;border-radius:4px;-webkit-border-radius:4px;-o-border-radius:4px;-moz-border-radius:4px;">
         <div class="input-group" style="padding:2px;">
  <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-search"></span></span>
        <asp:TextBox ID="txtCari" runat="server" CssClass="form-control input-sm" onkeyup="upper(this)" placeholder="Tulis Nomor WO / NOPOL untuk mencari data .." style="width:220px;"></asp:TextBox>
             <asp:Button ID="Button1" runat="server" Text="CARI DATA" class="btn btn-sm btn-primary" style="font-family:Verdana;margin-left:5px;" OnClick="Button1_Click" />   </div>
        </div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
         <asp:Timer ID="Timer1" runat="server" OnTick="GetTime" Interval="500" />
         <asp:GridView ID="GridView6" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource8" EnableModelValidation="True" ForeColor="#333333" GridLines="None" class="table table-bordered table-stripped" style="width:98%;margin:5px;font-size:0.85em;font-family:verdana;color:#333;">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="No." SortExpression="kddivisi" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <center><asp:Label ID="Label2" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label></center>
                     </ItemTemplate>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="Work order (WO)" SortExpression="WOHDR_NO">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink2" target="_blank" NavigateUrl='<%# "jobcontrolformanedt.aspx?qnowo=" + Eval("WOHDR_NO") + "#popup"%>' runat="server"><u><asp:Label ID="Label8" runat="server" Text='<%# Bind("WOHDR_NO") %>' style="font-weight:bold;color:blue;"></asp:Label></u></asp:HyperLink><br />
                            <i><asp:Label ID="Label1" runat="server" Text='<%# Bind("WOHDR_TGWO") %>' style="font-size:0.85em;color:#888;font-family:Verdana;"></asp:Label></i>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="No. Polisi" SortExpression="WOHDR_FNOPOL">
                        <ItemTemplate>
                            <center><asp:Label ID="Label2" runat="server" Text='<%# Bind("WOHDR_FNOPOL") %>' style="font-size:1.0em;color:#333;font-family:Verdana;"></asp:Label></center>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rangka / Mesin" SortExpression="WOHDR_FNRK">
                        <ItemTemplate>
                            <u><asp:Label ID="Label4" runat="server" Text='<%# Bind("WOHDR_FNRK") %>' style="font-size:0.95em;color:#333;font-family:Verdana;"></asp:Label></u>
                         <br/>
                             <asp:Label ID="Label3" runat="server" Text='<%# Bind("WOHDR_FNMS") %>' style="font-size:0.95em;color:#888;font-family:Verdana;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nama pemilik" SortExpression="WOHDR_FORG">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("WOHDR_FORG") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bill to" SortExpression="WOHDR_KDTAGIH">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("WOHDR_KDTAGIH") %>'></asp:Label><br /> 
                             <asp:Label ID="Label9" runat="server" Text='<%# Bind("SUPPLIER_NAMA") %>' style="font-size:0.95em;color:#888;font-family:Verdana;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SA / Tgl estimasi" SortExpression="WOHDR_SA">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("WOHDR_SA") %>'></asp:Label><br />
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("CONTROLBR_TGLESELESAI") %>' style="font-size:0.95em;color:#888;font-family:Verdana;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Act" SortExpression="WOHDR_SA">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("statuskerja") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="" SortExpression="vendor" HeaderStyle-Width="5">
                     <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "jobcontrolformanclo.aspx?qnowo2=" + Eval("WOHDR_NO")%>' 
                             Target="_blank" Text="<span class='glyphicon glyphicon-floppy-saved'></span> Closing" class="btn btn-success btn-xs"></asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>

                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="5" />
                  <pagerstyle cssclass="gridview"></pagerstyle>
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
             <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:serviceConnection %>" SelectCommand="SELECT WOHDR_TGWO, WOHDR_FNOPOL, WOHDR_FNMS, WOHDR_FNRK, WOHDR_FORG, WOHDR_KDTAGIH, WOHDR_SA, 
WOHDR_NO, CONTROLBR_TGLESELESAI, 
case [CONTROLBR_KETOKNILAI] 
when 1  then 'DISERAHKAN SA KE VENDOR ' 
when 2 then 'DISERAHKAN SA KE DRIVER'
when 3 then 'DITERIMA' 
when 4 then 'BONGKAR' 
when 5 then 'KETOK' 
when 6 then 'DEMPUL' 
when 7 then 'CAT / OVEN' 
when 8 then 'POLES' 
when 9 then 'PEMASANGAN' 
WHEN 10 then 'FINISHING' 
when 11 then 'PENILAIAN QC - OK'	
when 12 then 'PENILAIAN QC - NOT OK' 
when 13 then 'PENILAIAN QC - REWORK' 
when 14 then 'PENILAIAN QC - REWORK - OK'  
when 15 then 'PENILAIAN QC - REWORK - NOT OK' 
when 16 then 'PENYERAHAN UNIT QC KE SA BP' 
else '' 
end AS statuskerja, 
SUPPLIER_NAMA 
FROM TRXN_WOHDR 
INNER JOIN TEMP_CONTROLBR ON TRXN_WOHDR.WOHDR_NO = TEMP_CONTROLBR.CONTROLBR_NOWO 
INNER JOIN DATA_SUPPLIER ON TRXN_WOHDR.WOHDR_KDTAGIH = DATA_SUPPLIER.SUPPLIER_KODE  WHERE (WOHDR_NO = @cari) OR (WOHDR_FNOPOL LIKE '%' + @cari + '%')">
                  <SelectParameters>
                     <asp:QueryStringParameter Name="cari" QueryStringField="q" />
                 </SelectParameters>
             </asp:SqlDataSource>
            
         <!-- This one works -->
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource3" EnableModelValidation="True" ForeColor="#333333" GridLines="None" class="table table-bordered table-stripped" style="width:98%;margin:5px;font-size:0.85em;font-family:verdana;color:#333;">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="No." SortExpression="kddivisi" HeaderStyle-Width="5">
                     <ItemTemplate>
                         <center><asp:Label ID="Label2" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label></center>
                     </ItemTemplate>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="Work order (WO)" SortExpression="WOHDR_NO">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "jobcontrolformanedt.aspx?qnowo=" + Eval("WOHDR_NO") + "#popup"%>' target="_blank" runat="server"><u><asp:Label ID="Label8" runat="server" Text='<%# Bind("WOHDR_NO") %>' style="font-weight:bold;color:blue;"></asp:Label></u></asp:HyperLink><br />
                            <i><asp:Label ID="Label1" runat="server" Text='<%# Bind("WOHDR_TGWO") %>' style="font-size:0.85em;color:#888;font-family:Verdana;"></asp:Label></i>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="No. Polisi" SortExpression="WOHDR_FNOPOL">
                        <ItemTemplate>
                            <center><asp:Label ID="Label2" runat="server" Text='<%# Bind("WOHDR_FNOPOL") %>' style="font-size:1.0em;color:#333;font-family:Verdana;"></asp:Label></center>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rangka / Mesin" SortExpression="WOHDR_FNRK">
                        <ItemTemplate>
                            <u><asp:Label ID="Label4" runat="server" Text='<%# Bind("WOHDR_FNRK") %>' style="font-size:0.95em;color:#333;font-family:Verdana;"></asp:Label></u>
                         <br/>
                             <asp:Label ID="Label3" runat="server" Text='<%# Bind("WOHDR_FNMS") %>' style="font-size:0.95em;color:#888;font-family:Verdana;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nama pemilik" SortExpression="WOHDR_FORG">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("WOHDR_FORG") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bill to" SortExpression="WOHDR_KDTAGIH">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("WOHDR_KDTAGIH") %>'></asp:Label><br /> 
                             <asp:Label ID="Label9" runat="server" Text='<%# Bind("SUPPLIER_NAMA") %>' style="font-size:0.95em;color:#888;font-family:Verdana;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SA / Tgl estimasi" SortExpression="WOHDR_SA">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("WOHDR_SA") %>'></asp:Label><br />
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("CONTROLBR_TGLESELESAI") %>' style="font-size:0.95em;color:#888;font-family:Verdana;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Act" SortExpression="WOHDR_SA">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("statuskerja") %>'></asp:Label><br />
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("tglAkhir") %>' style="font-size:0.95em;color:#888;font-family:Verdana;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="" SortExpression="vendor" HeaderStyle-Width="5">
                     <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "jobcontrolformanclo.aspx?qnowo2=" + Eval("WOHDR_NO")%>' 
                             Target="_blank" Text="<span class='glyphicon glyphicon-floppy-saved'></span> Closing" class="btn btn-success btn-xs"></asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>

                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="5" />
                  <pagerstyle cssclass="gridview"></pagerstyle>
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
             <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:serviceConnection %>" SelectCommand="SELECT WOHDR_TGWO, WOHDR_FNOPOL, WOHDR_FNMS, WOHDR_FNRK, WOHDR_FORG, WOHDR_KDTAGIH, 
WOHDR_SA, WOHDR_NO, CONTROLBR_TGLESELESAI, 
case [CONTROLBR_KETOKNILAI] 
when 1  then 'DISERAHKAN SA KE VENDOR ' 
when 2 then 'DISERAHKAN SA KE DRIVER'
when 3 then 'DITERIMA' 
when 4 then 'BONGKAR' 
when 5 then 'KETOK' 
when 6 then 'DEMPUL' 
when 7 then 'CAT / OVEN' 
when 8 then 'POLES' 
when 9 then 'PEMASANGAN' 
WHEN 10 then 'FINISHING' 
when 11 then 'PENILAIAN QC - OK'	
when 12 then 'PENILAIAN QC - NOT OK' 
when 13 then 'PENILAIAN QC - REWORK' 
when 14 then 'PENILAIAN QC - REWORK - OK'  
when 15 then 'PENILAIAN QC - REWORK - NOT OK' 
when 16 then 'PENYERAHAN UNIT QC KE SA BP' 
else '' end AS statuskerja, SUPPLIER_NAMA, 
(select max(KERJABODY_TANGGAL)  from TEMP_KERJABODY WHERE KERJABODY_NOWO =WOHDR_NO 
GROUP BY KERJABODY_NOWO) AS tglAkhir FROM TRXN_WOHDR , 
TEMP_CONTROLBR,DATA_SUPPLIER 
where WOHDR_NO = CONTROLBR_NOWO and WOHDR_KDTAGIH = SUPPLIER_KODE and CONTROLBR_TGLSELESAIA IS NULL"></asp:SqlDataSource>
     </ContentTemplate>
</asp:UpdatePanel>
      


        
            
     <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/bootstrap.min.js" type="text/javascript"></script>
    
    </form>
 
   
</asp:Content>

