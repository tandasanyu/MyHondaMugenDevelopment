<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomeHRD.aspx.cs" Inherits="PagesHRD_HomeHRD" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiViewHRD" runat="server">
        <asp:View ID="View0" runat="server"><!-- -->
            <div >
                <br />
		            <h3 style="font-family:Blunter;"><span ></span> Data Pelamar Baru </h3>
	            <br />
            </div>
        </asp:View>
        <asp:View ID="View1" runat="server">
            <div >
                <br />
		            <h3 style="font-family:Blunter;"><span ></span> Data Lowongan Kerja </h3>
	            <br />
                         <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
         <asp:Timer ID="Timer1" runat="server" OnTick="GetTime" Interval="500" />

     </ContentTemplate>
</asp:UpdatePanel>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Button ID="Button1" runat="server" Text="Button" Visible="false"/>  

            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div >
                <br />
		            <h3 style="font-family:Blunter;"><span ></span> Data Pelamar</h3>
	            <br />
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>

