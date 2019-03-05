<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tambah_Lowongan.aspx.cs" Inherits="PagesHRD_Tambah_Lowongan" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="https://tinymce.cachefly.net/4.0/tinymce.min.js"></script>
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
    
    <div >
        <div class="form-group">
            <div class="col-sm-8" style="margin-bottom:4%;margin-top:1%">
                <h2 >Form Tambah Lowongan Pekerjaan</h2>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-8"> 
                <asp:Label ID="Label4" runat="server" Text="Tanggal Posting : " Font-Bold="true"></asp:Label><br />
                <asp:TextBox ID="TxtTglPosting" ReadOnly="true" class="form-control" runat="server" Width="200px"></asp:TextBox>
            </div>
         </div>     
        <div class="form-group">
            <div class="col-sm-8"> 
                <asp:Label ID="Label5" runat="server" Text="Posisi : " Font-Bold="true"></asp:Label><br />
               <asp:TextBox ID="TxtPosisi" class="form-control" runat="server" Width="300px" AutoComplete="off"></asp:TextBox>
            </div>
         </div>  
        <div class="form-group">
            <div class="col-sm-8"> 
                <asp:Label ID="Label6" runat="server" Text="Kualifikasi : " Font-Bold="true"></asp:Label><br />
                <asp:TextBox ID="tbxTinymce" CssClass="mcetiny" runat="server"></asp:TextBox>
            </div>
         </div>     
        <div class="form-group">
            <div class="col-sm-8"> 
                <br />
                <asp:Button ID="btnSubmit" class="btn btn-danger" runat="server" Text="Simpan Data" OnClick="Submit" />
                <asp:Button ID="BtnOpencon" Visible="false" runat="server" Text="Open" OnClick="BtnOpencon_Click" />
                <asp:Button ID="BtnClosecon" Visible="false" runat="server" Text="Close" OnClick="BtnClosecon_Click" />
            </div>
         </div>    
        <div class="form-group">
            <asp:Label ID="Posisi" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="Hasil" runat="server" Text="Label" Visible="false"></asp:Label>
        </div>
    </div>


</asp:Content>

