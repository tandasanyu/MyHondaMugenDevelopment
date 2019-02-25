<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printpo.aspx.cs" Inherits="printpo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Purchase Order</title>
    <style>html body{ margin:0px;padding:0px;}
        .head {background:#c0c0c0;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="header" style="width:100%;margin:0 auto;height:auto;">

        <div class="atas" style="width:97%;margin:5px auto;height:auto;position:relative;">
        <div class="kirih" style="float:left;height:80px;font-size:10pt;font-family:Verdana;position:relative;top:0px;width:9%;">
         <asp:Image ID="Image3" runat="server" ImageUrl="../img/hlogo.png" style="width:100%;height:75px;"/>
        </div>
        <div class="kirih" style="left:1%;float:left;height:80px;font-size:0.85em;font-family:Verdana;position:relative;top:0px;width:56%;">
        <asp:Label ID="Label24" runat="server" Text="Honda Mugen" style="font-weight:bold;"></asp:Label><br />    
        <asp:Label ID="Label25" runat="server" Text="PT. Mitrausaha Gentaniaga" style="font-size:0.8em;"></asp:Label><br />    
        <asp:Label ID="Label26" runat="server" Text="Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia" style="font-size:0.8em;"></asp:Label><br />      
        <asp:Label ID="Label27" runat="server" Text="Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)" style="font-size:0.8em;"></asp:Label><br />      
        <asp:Label ID="Label28" runat="server" Text="Fax : (021) 797 3834, 798 4735" style="font-size:0.8em;"></asp:Label><br />      
        <asp:Label ID="Label29" runat="server" Text="Website : www.hondamugen.co.id" style="font-size:0.8em;"></asp:Label>            
 </div>
 
        <div class="kirih" style="width:30%;float:left;height:auto;;font-size:0.85em;font-family:Verdana;">
          <table style="width:90%;position:relative;top:10px;float:right;">
            <tr>
                <th colspan="1" style="border:1px solid #333;background:#000;color:#fff;font-size:1.0em;font-family:Verdana;padding:2px;">PURCHASE ORDER</th>
            </tr>
              <tr> 
               <td style="border:1px solid #333;color:#333;font-size:1.2em;font-family:Tahoma;padding:2px;text-align:center;">
                   <asp:Label ID="lblNoPo" runat="server" Text=""></asp:Label></td>
            </tr>
             </table>
             <table style="width:90%;position:relative;top:10px;float:right;font-size:0.85em;font-family:tahoma;">
            <tr>
                <td>Req No.</td><td>:</td><td><asp:Label ID="lblReqNo" runat="server" Text=""></asp:Label></td>
            </tr>
              <tr> 
              <td>Tgl PO</td><td>:</td><td><asp:Label ID="lblTglPo" runat="server" Text=""></asp:Label></td>
            </tr>
             </table>
             </div>
             </div>
      <div class="header" style="width:95%;margin:0 auto;height:auto;position:relative;top:10px;">
       
        <div class="vendor" style="width:48%;border:1px solid #666;min-height:120px;float:left;margin:5px;">
        <table style="font-size:0.8em;font-family:Verdana;padding:5px;color:#333;">
           <tr><td style="font-weight:bold;"><u>Vendor :</u></td></tr>
            <tr><td><asp:Label ID="lblNamaVendor" runat="server" Text=""></asp:Label></td></tr>
            <tr><td><asp:Label ID="lblAlamatVendor" runat="server" Text=""></asp:Label></td></tr>
             <tr><td>Telp : <asp:Label ID="lblTelpVendor" runat="server" Text=""></asp:Label></td></tr>
              <tr><td>Fax : <asp:Label ID="lblFaxVendor" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>e-Mail :<asp:Label ID="lblEmailVendor" runat="server" Text=""></asp:Label></td></tr>
        </table>
        </div>
            
         <div class="vendor" style="width:48%;border:1px solid #666;min-height:120px;float:left;margin:5px;">
        <table style="font-size:0.8em;font-family:Verdana;padding:5px;color:#333;">
          <tr><td style="font-weight:bold;"><u>Ship to :</u></td></tr>
           <tr><td><asp:Label ID="lblNamaShipper" runat="server" Text=""></asp:Label></td></tr>
            <tr><td>Telp : <asp:Label ID="lblTelpShipper" runat="server" Text=""></asp:Label></td></tr>
             <tr><td>Fax : <asp:Label ID="lblFaxShipper" runat="server" Text=""></asp:Label></td></tr>
              <tr><td>e-Mail : <asp:Label ID="lblEmailShipper" runat="server" Text=""></asp:Label></td></tr>
        </table>
        </div>
    </div>
     <div class="header" style="width:95%;margin:0 auto;height:auto;position:relative;top:10px;">
       
        <div class="vendor" style="width:97%;border:1px solid #666;height:auto;float:left;margin:5px;">
        <table style="width:100%;font-size:0.8em;font-family:Verdana;padding:5px;color:#333;text-align:center;">
        <tr>
            <td style="font-weight:bold;"><u>Request by :</u></td>
             <td style="font-weight:bold;"><u>Approved by :</u></td>
              <td style="font-weight:bold;"><u>Purchasing :</u></td>
               <td style="font-weight:bold;"><u>Head Purchasing :</u></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPemohon" runat="server" Text=""></asp:Label></td>
             <td><asp:Label ID="lblHeaddiv" runat="server" Text=""></asp:Label></td>
              <td><asp:Label ID="lblPurc" runat="server" Text=""></asp:Label></td>
               <td><asp:Label ID="lblHeadPurc" runat="server" Text=""></asp:Label></td>
        </tr>
        </table>
        </div>
    </div>
    <div class="header" style="width:95%;margin:0 auto;height:auto;position:relative;top:10px;">
       
        <div class="vendor" style="width:97%;height:auto;float:left;margin:5px;">
        <table border="1" style="border:1px solid #666;border-collapse:collapse;width:100%;font-family:Verdana;padding:5px;color:#333;text-align:center;">
        <tr>
            <td style="background:#f5f5f5;width:20%;font-size:0.7em;">Cara Penyampaian</td>
             <td style="background:#f5f5f5;font-size:0.7em;">Ketentuan Penyampaian Barang</td>
              <td style="background:#f5f5f5;width:15%;font-size:0.7em;">Tgl Pengiriman</td>  
        </tr>
        <tr>
            <td style="height:30px;font-size:0.8em;"><asp:Label ID="lblShippingMethod" runat="server" Text=""></asp:Label></td>
             <td style="text-align:left;padding-left:5px;font-size:0.8em;"><asp:Label ID="lblShippingTerm" runat="server" Text=""></asp:Label></td>
              <td style="font-size:0.8em;"><asp:Label ID="lblShippingDate" runat="server" Text=""></asp:Label></td>  
        </tr>
        </table>
        </div>
    </div>
    <div class="header" style="width:95%;margin:0 auto;height:auto;position:relative;top:0px;">
       
        <div class="vendor" style="width:97%;height:auto;float:left;margin:5px;">
        <table style="width:100%;font-size:0.8em;font-family:Verdana;padding:5px;color:#333;text-align:left;">
        
        </table>
        </div>
    </div>
    <div class="header" style="width:95%;margin:0 auto;height:auto;position:relative;top:0px;">
       
        <div class="vendor" style="width:97%;height:auto;float:left;margin:5px;">
        <table border="1" style="border:1px solid #666;border-collapse:collapse;width:100%;font-size:0.70em;font-family:Verdana;padding:5px;color:#333;text-align:center;">
      <tr>
            <td style="text-align:left;padding-left:5px;">Tolong bantu kami untuk memenuhi beberapa barang yang kami perlukan, segabai berikut</td>
        </tr>
        
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableModelValidation="True" DataMember="DefaultView" Width="100%" Font-Size="Small">
                <Columns>
              <asp:TemplateField HeaderText="No." HeaderStyle-Width="5" HeaderStyle-BackColor="#f5f5f5">
                 <itemtemplate>
                    <center style="font-size:0.85em;font-family:Verdana;"> <%# Container.DataItemIndex + 1 %></center>
                 </ItemTemplate>
                 <headerstyle HorizontalAlign="Center" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Nama Barang" SortExpression="namaitem" HeaderStyle-BackColor="#f5f5f5">
                  <ItemTemplate>
                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("namaitem") %>' style="font-size:0.85em;font-family:Verdana;padding-left:5px;"></asp:Label>
                  </ItemTemplate>
               </asp:TemplateField>
                       <asp:TemplateField HeaderText="Tujuan Barang" SortExpression="namaitem" HeaderStyle-BackColor="#f5f5f5" HeaderStyle-Width="150">
                  <ItemTemplate>
                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("tujuanitem") %>' style="font-size:0.85em;font-family:Verdana;padding-left:5px;"></asp:Label>
                  </ItemTemplate>
               </asp:TemplateField>
                     <asp:TemplateField HeaderText="Pusat Biaya" SortExpression="namaitem" HeaderStyle-BackColor="#f5f5f5" HeaderStyle-Width="5">
                  <ItemTemplate>
                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("pusatbiaya") %>' style="font-size:0.85em;font-family:Verdana;padding-left:5px;"></asp:Label>
                  </ItemTemplate>
               </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qty" SortExpression="jumlahitem" HeaderStyle-Width="5" HeaderStyle-BackColor="#f5f5f5">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("jumlahitem") %>' style="font-size:0.85em;font-family:Verdana;padding-left:5px;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Harga" SortExpression="hargaitem" HeaderStyle-Width="100" HeaderStyle-BackColor="#f5f5f5">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("hargaitem","{0:0,0}") %>' style="font-size:0.85em;font-family:Verdana;padding-left:5px;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total" SortExpression="Total" HeaderStyle-Width="100" HeaderStyle-BackColor="#f5f5f5">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("total","{0:0,0}") %>' style="font-size:0.85em;font-family:Verdana;padding-left:5px;"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:setiawanConnectionString1 %>" SelectCommand="SELECT [pusatbiaya], [tujuanitem], [nobody], [namaitem], [jumlahitem], [hargaitem], [jumlahitem] * [hargaitem] as total FROM [fmbbody] WHERE ([nopurchaseorder] = @nopurchaseorder) AND rejectoleh IS NULL">
                <SelectParameters>
                    <asp:QueryStringParameter Name="nopurchaseorder" QueryStringField="q" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </table>
        </div>
    </div>
     <div class="header" style="width:95%;margin:0 auto;height:auto;position:relative;top:0px;">
       
        <div class="vendor" style="width:97%;height:auto;float:left;margin:5px;">
        <table border="1" style="border:1px solid #666;border-collapse:collapse;width:100%;font-size:0.70em;font-family:Verdana;padding:5px;color:#333;text-align:center;">
        <tr>
            <td style="text-align:right;padding-right:5px;font-weight:bold;">Dasar Pengenaan Pajak (DPP)</td>
            <td style="width:11%;"><asp:Label ID="lblTotalDpp" runat="server" Text=""></asp:Label></td>
        </tr>
         <tr>
            <td style="text-align:right;padding-right:5px;font-weight:bold;">PPN</td>
            <td style=""><asp:Label ID="lblTotalPpn" runat="server" Text=""></asp:Label></td>
        </tr>
         <tr>
            <td style="text-align:right;padding-right:5px;font-weight:bold;">Summary Total</td>
            <td style=""><asp:Label ID="lblTotalSum" runat="server" Text=""></asp:Label></td>
        </tr>
        </table>
        </div>
    </div>
    <div class="header" style="width:95%;margin:0 auto;height:auto;position:relative;top:10px;">
       
        <div class="vendor" style="width:48%;border:1px solid #666;min-height:120px;float:left;margin:5px;">
        <table style="font-size:0.8em;font-family:Verdana;padding:5px;color:#333;">
        <tr><td style="font-weight:bold;"><u>Ketentuan Pembayaran :</u></td></tr>
        <tr><td style="font-size:0.85em;"><asp:Label ID="lblTermOfPayment" runat="server" Text=""></asp:Label></td></tr>
        </table>
        </div>
            
         <div class="vendor" style="width:48%;min-height:120px;float:left;margin:5px;">
        <table style="font-size:0.8em;font-family:Verdana;padding:5px;color:#333;">
        <tr><td style="font-weight:bold;"></td></tr>
        <tr><td></td></tr>
        </table>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
