<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"   CodeFile="Edit_Lowongan.aspx.cs" Inherits="PagesHRD_Edit_Lowongan" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="https://tinymce.cachefly.net/4.0/tinymce.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script type="text/javascript">
        tinymce.init({
            //encoding: 'xml' ,
            selector: ".mcetiny",
            theme: "modern",
            plugins: [
             " autolink lists link  charmap  preview hr anchor pagebreak",
             "searchreplace wordcount visualblocks visualchars code fullscreen",
             "insertdatetime  nonbreaking save  contextmenu directionality",
             "emoticons template paste textcolor"
            ],
            toolbar1: " undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify |  numlist outdent indent |  ", //bullist
            toolbar2: "print preview  | forecolor backcolor emoticons",
            image_advtab: true,
            templates: [
                { title: 'Test template 1', content: 'Test 1' },
                { title: 'Test template 2', content: 'Test 2' }
            ]
        });
</script> 
    <script type="text/javascript">
        $(document).ready(function () {
            //$('#Div1').click(function () {
             //   tinymce.triggerSave();
              //  document.getElementById('<%= btnSubmit.ClientID %>').click()
            //});
            //just for testing, if i call trigger save first then btn click asp
            $("p").click(function () {
                tinymce.triggerSave();
                document.getElementById('<%= btnSubmit.ClientID %>').click()
            });
            var posisi = document.getElementById('<%=Label2.ClientID%>').innerText;
            var detail = document.getElementById('<%=Label1.ClientID%>').innerHTML;
            $("#btnCopy").click(function () {
                //alert(detail);
                document.getElementById('<%=TxtPosisi.ClientID %>').value = posisi;
                //document.getElementById('<%=TextBox1.ClientID %>').value = detail;
                //document.getElementById("#TxtPosisi").value = document.getElementById("#Label2").innerHTML;
                });
        });
</script>
    <div class="row">
        <div class="col-sm-11">
            <div class="form-group">
                <div class="col-sm-8" style="margin-bottom:4%;margin-top:1%">
                    <h2 class="display-4">Form Edit Lowongan Pekerjaan</h2>
                </div>
            </div>
        </div>
        <div class="col-sm-5">
            
        </div>
    </div>
    <div class="row">
        <div class="col-5">
            <div class="form-group">
                <div class="col-sm-8"> 
                    <asp:Label ID="Label4" runat="server" Text="Tanggal Posting : " Font-Bold="true"></asp:Label><br />
                    <asp:TextBox ID="TxtTglPosting" ReadOnly="true" class="form-control" runat="server" Width="200px"></asp:TextBox>
                </div>
             </div>  
        </div>
        <div class="col-5">
            <br />
            <input type="button" class="btn" id="btnCopy" value="Copy Data Posisi Lama" />
        </div>  
    </div>
    <div class="row">
        <div class="col-5">
        <div class="form-group">
            <div class="col-sm-8"> 
                <asp:Label ID="Label5" runat="server" Text="Posisi : " Font-Bold="true"></asp:Label>             
                <asp:Label ID="Label2" CssClass="form-control" runat="server" Text="Label"></asp:Label>
            </div>
         </div>  
        </div>
        <div class="col-5">
            <asp:Label ID="Label3" runat="server" Text="Masukan Posisi Baru : " Font-Bold="true"></asp:Label>      
            <asp:TextBox ID="TxtPosisi" class="form-control" runat="server" Width="300px" AutoComplete="off"></asp:TextBox>
        </div>      
    </div>
    <div class="row">
        <div class="col-5">
        <div class="form-group">
            <div class="col-sm-8"> 
                <asp:Label ID="Label6" runat="server" Visible="true" Text="Data Lama : " Font-Bold="true"></asp:Label>
                <asp:TextBox ID="tbxTinymce" Visible="false" CssClass="mcetiny" runat="server"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="col-sm-8"> 
                
            </div>
         </div>    
        </div>  
        <div class="col-5">
            <asp:Label ID="Label7" runat="server" Visible="true" Text="Data Baru : " Font-Bold="true"></asp:Label>
            <asp:TextBox ID="TextBox1" CssClass="mcetiny" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-5">
        <div class="form-group">
            <div class="col-sm-8"> 
                <br />
                
            </div>
         </div>   
        </div>
        <div class="col-5">
            <br />
            <asp:Button ID="btnSubmit" class="btn btn-danger"  runat="server" Text="Simpan Data" OnClick="Submit"/>
            <br />
            <br />
        </div>
    </div>
</asp:Content>

