<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tambah_Lowongan.aspx.cs" Inherits="PagesHRD_Tambah_Lowongan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="https://tinymce.cachefly.net/4.0/tinymce.min.js"></script>
    <script type="text/javascript">
        tinymce.init({
            selector: ".mcetiny",
            theme: "modern",
            plugins: [
             " autolink lists link  charmap  preview hr anchor pagebreak",
             "searchreplace wordcount visualblocks visualchars code fullscreen",
             "insertdatetime  nonbreaking save table contextmenu directionality",
             "emoticons template paste textcolor"
            ],
            toolbar1: " undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent |  ",
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
			<label class="control-label col-sm-2" for="kualifikasi"></label>
				<div class="col-sm-8"> 
                    <br />
                    <asp:TextBox ID="tbxTinymce" CssClass="mcetiny" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="Submit" />
				</div>
		</div>
    </div>


</asp:Content>

