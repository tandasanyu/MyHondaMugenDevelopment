<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="editPassword.aspx.vb" Inherits="editPassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <div class="container">
        <form runat="server" id="checklist" class="form-horizontal">
            <br /><br /><br /><br />
            <table class="table table-striped" style="border-radius:8px;padding:4px;width:500px;margin:10px auto;font-size:10pt;font-family:Verdana;">
                <tr>
                    <th colspan="3" style="text-align:center;"><span class="glyphicon glyphicon-lock"></span>&nbsp;&nbsp;UBAH PASSWORD</th>
                </tr>
                <tr>
                    <td>Username</td>
                    <td>:</td>
                    <td><asp:Label ID="lblUsername" runat="server" style="color:blue;font-weight:bold;" Text="U must be log in !"></asp:Label> <span style="font-size:8pt;color:#666;"><br /> <i class="glyphicon glyphicon-info-sign"></i> Username tidak dapat diganti</span></td>
                </tr>
                <tr>
                    <td>Password lama</td>
                    <td>:</td>
                    <td><asp:TextBox ID="txtPassLama" runat="server" class="form-control input-sm" placeholder="Password lama" TextMode="Password"></asp:TextBox><asp:Label ID="lblPassLama" style="color:red;font-size:8pt;" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Password baru</td>
                    <td>:</td>
                    <td><asp:TextBox ID="txtPassBaru" runat="server" Style="color:#333;" class="form-control input-sm" placeholder="Password baru" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Ulangi password</td>
                    <td>:</td>
                    <td><asp:TextBox ID="txtPassBaru2" runat="server" Style="color:#333;" class="form-control input-sm" placeholder="Ulang password baru" TextMode="Password"></asp:TextBox><asp:Label ID="lblPassBaru2" style="color:red;font-size:8pt;" runat="server" Text=""></asp:Label></td>
                </tr>
                 <tr>
                    <td></td>
                    <td></td>
                    <td><asp:Label ID="lblSukses" style="color:green;font-size:8pt;" runat="server" Text=""></asp:Label><br />
                    <asp:Button ID="simpan" CssClass="btn btn-primary btn-sm" runat="server" Text="Ubah Password" OnClick="simpan_Click" /></td>
                </tr>
            </table>
        </form><br /><br />
    </div>
    <!-- /.container -->

    <script type="text/javascript"> 

        function stopRKey(evt) { 
          var evt = (evt) ? evt : ((event) ? event : null); 
          var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null); 
          if ((evt.keyCode == 13) && (node.type=="text"))  {return false;} 
        } 

        document.onkeypress = stopRKey; 

    </script>

    <style>
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

        .window {
            position:relative;	
            width: 90%;
            height: auto;
            background: #fff;
            border-radius: 8px;
            position: relative;
            padding: 10px;
            box-shadow: 0 0 5px rgba(0,0,0,.4);
            text-align: center;
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
            width: 90%;
            height: auto;
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

        .window3 
        {
            position:relative;	
            width: 90%;
            height: auto;
            background: #fff;
            border-radius: 8px;
            position: relative;
            padding: 10px;
            box-shadow: 0 0 5px rgba(0,0,0,.4);
            text-align: center;
            margin: 2% auto;
        }

        #popup3:target {
            visibility: visible;
        }
    </style>
</asp:Content>