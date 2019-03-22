<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageUser_UploadCV.aspx.cs" Inherits="PageUser_PageUser_UploadCV" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload CV</title>
    <!-- DATEPICKER RANGE -->
    <script src="../js/jquery-1.12.4.js"></script>
    <!-- Bootstrap -->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
<script type ="text/javascript">
        var validFiles=["jpg","jpeg", "pdf"];
        function OnUpload()
        {
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
         }
    </script>
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
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom:100px">
                <div style="margin-left:1%">
                    <h2 class="FormUploadFoto">Form Upload CV Anda</h2>
                    <br />
                    <br />
                </div>              
                <div class="blue-square-container">
                  <div class="blue-square">
                            <!-- Upload Foto Pribadi -->
                            <div class="form-group" id="Foto Pribadi">
                                 <div style="margin-left:1%" >
                                      <asp:Label ID="Label1" runat="server" Text="Upload File CV Anda" Font-Bold="true"></asp:Label>
                                     <asp:FileUpload ID="FileUpload1" class="form-control-file"  runat="server" /><br />                                     
                                     <div style="margin-bottom:20px"><asp:Label ID="Label2" runat="server" Text="File yang dapat di Upload hanya (.JPG, .JPEG, .PDF)" ForeColor="Red" Font-Size="Medium"></asp:Label>
                                     </div><asp:Button ID="BtnSubmitCV" OnClientClick ="return OnUpload();" runat="server" Text="Upload File" class="btn btn-secondary" OnClick="BtnSubmitCV_Click"/>   
                                 </div>
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
