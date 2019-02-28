<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageUser_UploadFoto.aspx.cs" Inherits="PageUser_PageUser_UploadFoto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Foto Pribadi</title>
<style>
    .blue-square {
  
  width: 400px;
  height: 100px;
  display: inline-block;
  margin-top:13%;

}
    .blue-square-container {
  text-align: center;
}
    .footer {
   position: fixed;
   left: 0;
   bottom: 0;
   width: 100%;
   background-color: grey;
   color: white;
   text-align: center;
   height:50px;
   max-height:50px;
}
h2.FormUploadFoto {
  text-align: center;
}

</style>
    <!-- DATEPICKER RANGE -->
    <script src="../js/jquery-1.12.4.js"></script>
    <!-- Bootstrap -->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
<script type="text/javascript">
    var validFiles = ["jpg", "jpeg"];
    function setUploadButtonState() {
        var obj = document.getElementById("<%=FileUpload1.ClientID%>");
          var source=obj.value;
          var ext=source.substring(source.lastIndexOf(".")+1,source.length).toLowerCase();
          for (var i=0; i<validFiles.length; i++)
          {
              if (validFiles[i]==ext)
                    break;
          }
              if (i>=validFiles.length)
              {
                  alert("File Harus di Pilih / File yang Dapat Di Upload Hanya Jenis :\n" + validFiles.join(", "));
                return false;
              }
            //BARU-------------
              var maxFileSize = 1048576; // 4MB -> 4 * 1024 * 1024
              var fileUpload = $('#FileUpload1');

              if (fileUpload.val() == '') {
                  return false;
              }
              else {
                  if (fileUpload[0].files[0].size < maxFileSize) {

                      return true;
                  } else {
                      alert("File Terlalu Besar, Lebih dari 1 MB");
                      return false;
                  }
              }
          //return true;
        //var maxFileSize = 1048576; // 4MB -> 4 * 1024 * 1024
        //var fileUpload = $('#FileUpload1');

        //if (fileUpload.val() == '') {
        //    return false;
        //}
        //else {
        //    if (fileUpload[0].files[0].size < maxFileSize) {
                
        //        return true;
        //    } else {
        //        alert("File Terlalu Besar, Lebih dari 1 MB");
        //        return false;
        //    }
        //}

    }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom:100px">
                <div style="margin-left:1%">
                    <h2 class="FormUploadFoto">Form Upload Foto Anda</h2>
                    <br />
                    <br />
                </div>              
                <div class="blue-square-container">
                  <div class="blue-square">
                            <!-- Upload Foto Pribadi -->
                            <div class="form-group" id="Foto Pribadi">
                                 <div style="margin-left:1%" >
                                    <asp:Label ID="Label1" runat="server" Text="Upload File Foto Anda" Font-Bold="true"></asp:Label>
                                 <asp:FileUpload ID="FileUpload1" runat="server" /><br />
<%--                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                         runat="server" 
                                         ErrorMessage="File Wajib di Upload"
                                         ForeColor="Red"
                                         ControlToValidate="FileUpload1"
                                         ></asp:RequiredFieldValidator>--%>
<%--                                 <asp:RegularExpressionValidator ID="FileTypeValidator"  
                                     runat="server" 
                                     ErrorMessage="Hanya bisa upload File .JPG / .Jpeg" 
                                     ForeColor="red"
                                     ValidationExpression="(.*jpg$)|(.*jpeg$)" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator>--%>
                                 <div style="margin-top:5px;margin-bottom:10px" class="row">
                                     <asp:Label ID="Label3" runat="server" Text="*File Wajib Format .JPG / .JPEG" ForeColor="red"></asp:Label>
                                     <asp:Label ID="Label4" runat="server" Text="*File Maksimal 1 MB untuk di Upload" ForeColor="red"></asp:Label>
                                 </div>                                     
                                 </div>

                                <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label><br />
                                <asp:Button ID="SubmitFoto" class="btn btn-secondary" runat="server" Text="Upload File" OnClick="SubmitFoto_Click" OnClientClick="return setUploadButtonState();"  />
                            </div>
                  </div>
                </div>
        </div>
        <div class="footer">
            <div style="margin-top:1px">
                <asp:Label ID="Label6" runat="server" Text="Developed by IT Departement 2019 &#169;"></asp:Label>            
            </div>
            <div style="margin-top:1px">
                 <asp:Label ID="Label7" runat="server" Text="PT.Mitra Usaha Gentaniaga"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
