<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HalamanChat.aspx.cs" Inherits="HalamanChat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Halaman Chat</title>
    <!-- CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <!-- JS -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery-1.12.4_2.js"></script>
    <script src="js/jquery-ui_2.js"></script>
      <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
    <style>
        #rcorners1 {
      border-radius: 25px;
      background: #73AD21;
      padding: 20px; 
      width: 200px;
      height: 150px;  
        }
        .ghost {
          display: none;
        }
    </style>
<script>
    $(document).ready(function () {
        $( "#<%= DropDownListID.ClientID %>" ).change(function () {
            var color = $(this);
            //alert(color.val());
            $('#<%=TextBoxID.ClientID %>').val(color.val());
        });
        $('#TxtIsiChat').keyup(function () {
            max = this.getAttribute("maxlength");
            var len = $(this).val().length;
            if (len >= max) {
                $('#charNum').text('Anda Mencapai Batas Limit Karakter untuk Chat');
            } else {
                var char = max - len;
                $('#charNum').text(char + ' Karakter Tersisa');
            }
        });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
        <br />
    <div class="container" style="background-color: lightgrey;  border-radius: 25px;  padding: 20px;">
        <div class="row">
            <div class="col"></div><div class="col"></div>
            <div class="col"><h4>Halaman Chat</h4></div>
            <div class="col"></div><div class="col"></div>
        </div>
        <div class="row">
            <div class="col">
                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col">
            <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="ID Terpilih  :  "></asp:Label>
            <asp:DropDownList ID="DropDownListID" CssClass="form-control" width ="30%" runat="server"></asp:DropDownList><br />
            <asp:TextBox ID="TextBoxID" class="ghost" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <br />
        </div>
        <div class="row">
            <div class="col">
            <textarea id="TxtIsiChat" name ="TxtIsiChat" maxlength="200" style="width:100%" runat="server" class="form-control" cols="2" rows="5"></textarea><br />
            
            </div>
            <div class="col">
                <span id="charNum"></span>
            </div>
        </div>
        <div class="row">
            <br />
        </div>
        <div class="row">
            <div class="col">
            <asp:Button ID="BtnSimpan" CssClass="btn btn-danger" runat="server" Text="Balas" OnClick="BtnSimpan_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col">
                            <br />
            History Chat : 
            <br />
            </div>
        </div>
        <div class="row">
            <div class="col"  style="overflow-y:auto;overflow-x:auto;height:400px;width:70%">
            <asp:ListView ID="LvChat" runat="server">
                <LayoutTemplate>
                   <table  class="table  table-bordered  table-hover" style="background-color:white" id="test">
			            <thead>
                            <tr style="background-color:red;color:white;">
                                <th align="center" rowspan="2"><b >ID</b></th>
                                <th align="center" rowspan="2"><b>Jawaban</b></th>
                                <th align="center" rowspan="2"><b>User</b></th>
					            <th align="center" rowspan="2"><b>Isi Chat</b></th>
                            </tr>
				            <tr>
                        </thead>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                   </table>
                </LayoutTemplate>
                <ItemTemplate>   
				            <tr>
                                <td>
						            <div class="col-sm-12">
                                        <asp:Label ID="LblID" runat="server" Text='<%# Eval("ID_CHAT") !=null ? Eval("ID_CHAT"): "Data Tidak Ada" %>'></asp:Label>
						            </div>
                                </td>
                                <td>
						            <div class="col-sm-12">
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("JENIS_CHAT") !=null ? Eval("JENIS_CHAT"): "Data Tidak Ada" %>'></asp:Label>
						            </div>
                                </td>
					            <td>
						            <div class="col-sm-12">
                                        <asp:Label ID="DPNama" runat="server" Text='<%# Eval("USER_CHAT") !=null ? Eval("USER_CHAT"): "Data Tidak Ada" %>'></asp:Label>
						            </div>
					            </td>
					            <td>
						            <div class="col-sm-12">
                                        <asp:Label ID="Label3" runat="server" Font-Size="X-Small"  Text='<%# Eval("TGL_CHAT") !=null ? Eval("TGL_CHAT"): "Data Tidak Ada" %>'></asp:Label><br />
                                        <asp:Label ID="Label21" runat="server" Text='<%# Eval("ISI_CHAT") !=null ? Eval("ISI_CHAT"): "Data Tidak Ada" %>'></asp:Label>
						            </div>		
					            </td>
                            </tr>
                </ItemTemplate>
            </asp:ListView>
            </div>
<%--            <div class="col">
                <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Catatan :"></asp:Label><br />
                <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="1. Kolom Jawaban Merupakan, Kolom yang berisi Jawaban Terkait Chat berdasarkan Id chat nya"></asp:Label><br />
                <asp:Label ID="Label7" runat="server" Font-Bold="true" Text="2. Cocokan Angka pada Kolom Jawaban Sesuai dengan Angka pada Kolom ID Chat"></asp:Label><br />
            </div>--%>
        </div>
    </div>
    </form>
</body>
</html>
