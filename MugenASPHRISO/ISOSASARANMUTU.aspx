<%@ Page Language="VB"  MasterPageFile ="~/MasterPage.master"  AutoEventWireup="false" CodeFile="ISOSASARANMUTU.aspx.vb" Inherits="ISOSASARANMUTU" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
        <asp:Label ID="LblUserName" runat="server" Style="display:none"></asp:Label>
        <asp:Label ID="lblAkses" runat="server" Style="display:none"></asp:Label>
        <asp:Label ID="lblArea1" runat="server" Style="display:none"></asp:Label>
        <asp:Label ID="lblArea2" runat="server" Style="display:none"></asp:Label>

    <div class="container">
        <ul class="breadcrumb">
            <li><a href="#"> <span class="glyphicon glyphicon-home"></span></a> &nbsp <a href="#">Beranda</a> </li>
            <li><a href="#"> <span class="glyphicon glyphicon-globe"></span></a> &nbsp <a href="#"> ISO</a> </li>
            <li class="active"><span class="glyphicon glyphicon-tasks"></span> &nbsp Sasaran Mutu </li>
        </ul>
    <asp:MultiView ID="MultiViewError" runat="server" Visible="TRUE">
        <asp:View ID="Viewerr00" runat="server">
            <asp:Label ID="lblMsgBox" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="Red" height="23px" Width="959px">Judul Permohonan</asp:Label> 
        </asp:View> 
    </asp:MultiView>

    <asp:MultiView ID="MultiViewAkses" runat="server" Visible="TRUE">
        <asp:View ID="View1Akses" runat="server">
            <div class="container">
                <center>
                    <h2 style="font-family:Cooper Black;">DATA SASARAN MUTU ISO</h2>
                </center>
	        </div>  <br /><br />
           
            <asp:Button ID="BtnA" runat="server"  Text="Tambah Sasaran Mutu" class="button button4"/>
            <br /><br />
            <asp:SqlDataSource ID="SqlDataMutuMaster" runat="server"
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                SelectCommand="SELECT [MUTU_ID], [MUTU_SASARANMUTU], [MUTU_DEPT], [MUTU_TARGET], [MUTU_ON], [MUTU_OFF], [MUTU_USER], [MUTU_CREATE] FROM [TRXN_ISOASM] ORDER BY [MUTU_ID] ASC"
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
            </asp:SqlDataSource>     
            <asp:ListView ID="LvDetailMaster" runat="server" DataSourceID="SqlDataMutuMaster" DataKeyNames ="MUTU_ID">                                        
                <LayoutTemplate>
                    <table id="table-a" class="table table-bordered striped data" align="left">
                        <thead style="background-color:#4877CF">
                            <th style="text-align:center; color:white" class="col-md-1">No.</th>
                            <th style="text-align:center; color:white">ID Dept.</th>
                            <th style="text-align:center; color:white">Departemen</th>
                            <th style="text-align:center; color:white">Sasaran Mutu</th>
                            <th style="text-align:center; color:white">Target</th>
                            <th style="text-align:center; color:white">User</th>
                            <th style="text-align:center; color:white" class="col-md-1">Detail</th>
                        </thead>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
                </LayoutTemplate>
        
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#Container.DataItemIndex + 1 %></td>
                        <td style="text-align:center"><%#Eval("MUTU_ID")%></td>
                        <td style="text-align:center"><%#Eval("MUTU_DEPT")%></td>
                        <td><%#Eval("MUTU_SASARANMUTU")%></td>
                        <td style="text-align:center"><%#Eval("MUTU_TARGET")%></td>
                        <td style="text-align:center"><%#Eval("MUTU_USER")%></td>
                        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/details.png" width="60px" height="50px" /></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>Data Sasaran Mutu Tidak diketemukan</EmptyDataTemplate> 
                <EmptyItemTemplate>Data Sasaran Mutu Tidak diketemukan</EmptyItemTemplate>              
            </asp:ListView>
            <br />
        </asp:View> 
    </asp:MultiView>
    <asp:MultiView ID="MultiViewAkses2" runat="server" Visible="TRUE">
        <asp:View ID="View12" runat="server">
            <div class="container">
                <center>
                    <h2 style="font-family:Cooper Black;">DATA SASARAN MUTU ISO</h2>
                </center>
	        </div>  <br /><br />
            <asp:SqlDataSource ID="SqlDataMutuMaster2" runat="server"
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                SelectCommand="SELECT [MUTU_ID], [MUTU_SASARANMUTU], [MUTU_DEPT], [MUTU_TARGET], [MUTU_ON], [MUTU_OFF], [MUTU_USER], [MUTU_CREATE] FROM [TRXN_ISOASM] WHERE ([MUTU_USER]=?) ORDER BY [MUTU_ID] ASC"
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                <selectparameters>           
		            <asp:ControlParameter ControlID="lblArea1" Name="lblArea1" PropertyName= "Text" Type="String" />
                 
                </selectparameters>
            </asp:SqlDataSource>     
            <asp:ListView ID="LvDetailMaster2" runat="server" DataSourceID="SqlDataMutuMaster2" DataKeyNames ="MUTU_ID">                                        
                <LayoutTemplate>
                    <table id="table-a" class="table table-bordered striped data" align="left">
                        <thead style="background-color:#4877CF">
                            <th style="text-align:center; color:white" class="col-md-1">No.</th>
                            <th style="text-align:center; color:white">ID Dept.</th>
                            <th style="text-align:center; color:white">Departemen</th>
                            <th style="text-align:center; color:white">Sasaran Mutu</th>
                            <th style="text-align:center; color:white">Target</th>
                            <th style="text-align:center; color:white">User</th>
                            <th style="text-align:center; color:white" class="col-md-1">Detail</th>
                        </thead>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
                </LayoutTemplate>
        
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#Container.DataItemIndex + 1 %></td>
                        <td style="text-align:center"><%#Eval("MUTU_ID")%></td>
                        <td style="text-align:center"><%#Eval("MUTU_DEPT")%></td>
                        <td><%#Eval("MUTU_SASARANMUTU")%></td>
                        <td style="text-align:center"><%#Eval("MUTU_TARGET")%></td>
                        <td style="text-align:center"><%#Eval("MUTU_USER")%></td>
                        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/details.png" width="60px" height="50px" /></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>Data Sasaran Mutu Tidak diketemukan</EmptyDataTemplate> 
                <EmptyItemTemplate>Data Sasaran Mutu Tidak diketemukan</EmptyItemTemplate>              
            </asp:ListView>
            <br />
        </asp:View> 
    </asp:MultiView>     
             
    <asp:MultiView ID="MultiViewMasterIsi" runat="server" Visible="TRUE">
        <asp:View ID="View3" runat="server">
            <div class="container">
                <div class="panel panel-default" style="margin-left:-25px">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Sasaran Mutu</font></div>
                    <div class="panel-body">
                        <center>
                            <h2 style="font-family:Blunter;">FORM SASARAN MUTU</h2>
                        </center>
	                    <br /><br />

                        <table class="table table-borderless" align="left">
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label66" runat="server" Text="ID Departemen"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtID" runat="server" class="form-control required"></asp:TextBox>
                                    <asp:Label ID="lblSMID" runat="server" Font-Names="Calibri" Font-Size="Medium" Text="" ForeColor="Black"></asp:Label>
                                </td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label29" runat="server" Text="Departemen" ></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:DropDownList ID="TxtSMDep" runat="server" class="form-control">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Admin Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>Admin Puri</asp:ListItem>
                                        <asp:ListItem>CC Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>CC Puri</asp:ListItem>
                                        <asp:ListItem>GA Puri</asp:ListItem>
                                        <asp:ListItem>HRD & GA Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>Internal Audit</asp:ListItem>
                                        <asp:ListItem>IT Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>IT Puri</asp:ListItem>
                                        <asp:ListItem>Purchasing</asp:ListItem>
                                        <asp:ListItem>Sales Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>Sales Puri</asp:ListItem>
                                        <asp:ListItem>Service Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>Service Puri</asp:ListItem>
                                        <asp:ListItem>Sparepart Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>Sparepart Puri</asp:ListItem>
                                        <asp:ListItem>Warehouse</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label39" runat="server" Text="Sasaran Mutu"></asp:Label></td>
                                <td class="col-md-2"><asp:TextBox ID="TxtSMDesc" TextMode ="MultiLine" runat="server" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Target"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtSMTarget" runat="server" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td>  
                                <td class="col-md-2"><asp:Label ID="Label1" runat="server" Text="User" ></asp:Label></td>
                                <td class="col-md-4">
                                     <asp:DropDownList ID="TxtSMUser" runat="server" class="form-control">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>ADH Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>ADH Puri</asp:ListItem>
                                        <asp:ListItem>CC Puri</asp:ListItem>
                                        <asp:ListItem>CC SPV</asp:ListItem>
                                        <asp:ListItem>GA Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>GA Puri</asp:ListItem>
                                        <asp:ListItem>HRD & GA Head</asp:ListItem>
                                        <asp:ListItem>Internal Auditor</asp:ListItem>
                                        <asp:ListItem>IT Head</asp:ListItem>
                                        <asp:ListItem>IT Puri</asp:ListItem>
                                        <asp:ListItem>Ka. Sparepart Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>Ka. Sparepart Puri</asp:ListItem>
                                        <asp:ListItem>Purchasing</asp:ListItem>
                                        <asp:ListItem>SM Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>SM Puri</asp:ListItem>
                                        <asp:ListItem>Service Manager Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>Service Manager Puri</asp:ListItem>
                                        <asp:ListItem>SPV Sales Ps. Minggu</asp:ListItem>
                                        <asp:ListItem>SPV Sales Puri</asp:ListItem>
                                        <asp:ListItem>WH Coordinator</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="col-md-2"></td> 
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label2" runat="server" Text="Pembuat"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtSMPembuat" runat="server" class="form-control required"></asp:TextBox></td>
                                <td class="col-md-2"></td> 
                            </tr>
                            <tr>
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label16" runat="server" Text="Tanggal Aktif"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:TextBox ID="TxtSMTglOn" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />   
                                    <asp:LinkButton ID="ButtonTgl02" runat="server" CssClass="btn btn-default" CausesValidation="False" >
                                    <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
                                    </asp:LinkButton>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExt02" runat="server"
                                        TargetControlID="TxtSMTglOn" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValid02" runat="server"
                                        ControlExtender="MaskedEditExt02" ControlToValidate="TxtSMTglOn" EmptyValueMessage="Date is required"
                                        InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                        EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExt02" runat="server" TargetControlID="TxtSMTglOn" PopupButtonID="ButtonTgl02" />
                                </td>
                                <td class="col-md-2"></td> 
                            </tr>
                            <tr>
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label4" runat="server"  Text="Tanggal Non Aktif Aktif"></asp:Label></td>
                                <td class="col-md-4">
                                    <asp:TextBox ID="TxtSMTglOff" runat="server" MaxLength="1" style="width: 130px; height: 35px; padding: 12px 10px;  box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" ValidationGroup="MKE" />    
                                    <asp:LinkButton ID="ButtonTgl03" runat="server" CssClass="btn btn-default" CausesValidation="False" >
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </asp:LinkButton>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExt03" runat="server"
                                        TargetControlID="TxtSMTglOff" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValid03" runat="server"
                                        ControlExtender="MaskedEditExt03" ControlToValidate="TxtSMTglOff" EmptyValueMessage="Date is required"
                                        InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                        EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExt03" runat="server" TargetControlID="TxtSMTglOff" PopupButtonID="ButtonTgl03" />
                                </td>
                                <td class="col-md-2"></td> 
                            </tr>
                        </table>
                        <center><asp:Label ID="LblErrorSaveA" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="" style="color: red;"></asp:Label></center>
                        <center>
                            <asp:Button ID="ButtonADel" runat="server" CssClass="btn btn-danger" Text="Hapus"  />
                            <asp:Button ID="ButtonASave" runat="server"  CssClass="btn btn-success" Text="Simpan" />
                        </center>
                        <br /><br />
                        </div>
                    </div>
                  </div>
            </asp:View>
        </asp:MultiView>
        <asp:MultiView ID="MultiViewActionPlane" runat="server" Visible="TRUE">
            <asp:View ID="View4" runat="server">
                <div style="margin-top:25px; border-top:2px dotted #ff0000;"></div>
                <br />
                <div class="container">
                    <center>
                        <h2 style="font-family:Blunter;">DATA ACTION PLAN</h2>
                    </center>
	            </div><br />
                <asp:Button ID="BtnB" runat="server" Text="Tambah Action Plan" class="button button4" />
                <br /><br />
                <asp:SqlDataSource ID="SqlDataPLAN" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [MUTUP_ID], [MUTUP_PLAN], [MUTUP_URUTAN]  FROM [TRXN_ISOBPLAN] WHERE ([MUTUP_ID] = '' + ? + '') ORDER BY [MUTUP_URUTAN] ASC"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtID" Name="MUTUP_ID" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>                                     
                <asp:ListView ID="LVActionPlane" runat="server" DataSourceID="SqlDataPLAN" DataKeyNames ="MUTUP_URUTAN">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped" align="left">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white" class="col-md-1">No.</th>
                                <th style="text-align:center; color:white">ID Departemen</th>
                                <th style="text-align:center; color:white">Action Plan</th>
                                <th style="text-align:center; color:white" class="col-md-1">Ubah</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Eval("MUTUP_URUTAN")%></td>
                            <td class="col-md-2" style="text-align:center"><%#Eval("MUTUP_ID")%></td>
                            <td class="col-md-8"><%#Eval("MUTUP_PLAN")%></td>
                            <td class="col-md-2" style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/edit3.png" width="50px" height="40px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Action Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Action Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                            
                        </td>
                    </tr>
                </table> 
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiViewActionPlane2" runat="server" Visible="TRUE">
            <asp:View ID="View13" runat="server">
                <br />
                <div class="container">
                    <center>
                        <h2 style="font-family:Blunter;">DATA ACTION PLAN</h2>
                    </center>
	            </div><br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [MUTUP_ID], [MUTUP_PLAN], [MUTUP_URUTAN]  FROM [TRXN_ISOBPLAN] WHERE ([MUTUP_ID] = '' + ? + '') ORDER BY [MUTUP_URUTAN] ASC"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtID" Name="MUTUP_ID" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>                                     
                <asp:ListView ID="LVActionPlane2" runat="server" DataSourceID="SqlDataPLAN" DataKeyNames ="MUTUP_URUTAN">
                    <LayoutTemplate>
                        <table id="table-a"  class="table table-bordered table-striped" align="left">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white" class="col-md-1">No.</th>
                                <th style="text-align:center; color:white">ID Departemen</th>
                                <th style="text-align:center; color:white">Action Plan</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Eval("MUTUP_URUTAN")%></td>
                            <td class="col-md-2" style="text-align:center"><%#Eval("MUTUP_ID")%></td>
                            <td class="col-md-8"><%#Eval("MUTUP_PLAN")%></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Data Action Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Data Action Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
                <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                    <tr>
                        <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                            
                        </td>
                    </tr>
                </table> 
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiViewActionPlaneENtry" runat="server" Visible="TRUE">
            <asp:View ID="View5" runat="server">
                <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Action Plane</font></div>
                            <div class="panel-body">
                            <center>
                                <h2 style="font-family:Blunter;">FORM ACTION PLAN</h2>
                            </center>
	                        <br /><br />
                            <table class="table table-borderless" align="left">
                                 <tr>
                                    <td class="col-md-2"></td> 
                                    <td class="col-md-2"><asp:Label ID="Label6" runat="server" Text="No"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtUrutan" class="form-control required" runat="server"></asp:TextBox></td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td> 
                                    <td class="col-md-2"><asp:Label ID="Label21" runat="server" Text="Action Plan"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtActionPlan" TextMode ="MultiLine" class="form-control required" runat="server"></asp:TextBox>
                                    <asp:Label ID="LblActionPlan" runat="server"></asp:Label></td>
                                    <td class="col-md-2"></td>
                                </tr>
                            </table>
               
                                   <center><asp:Label ID="LblErrorSaveB" runat="server" Text="" style="color: red;"></asp:Label></center> 
                  
                            <center>
                                <asp:Button ID="BtnBBack" runat="server" Text="Tutup Form" cssClass="btn btn-warning" />
                                <asp:Button ID="BtnBSave" runat="server" Text="Simpan" cssClass="btn btn-success" /> 
                                <asp:Button ID="ButtonBDel" runat="server" CssClass="btn btn-danger" Text="Hapus"  />
                            </center>
                        </div>
                    </div>
                </div>
            </asp:View> 
        </asp:MultiView>
    
        <asp:MultiView ID="MultiViewNilaiProgress" runat="server" Visible="TRUE">
            <asp:View ID="View1" runat="server">
                <div style="margin-top:25px; border-top:2px dotted #ff0000;"></div>
                <br />
                 <div class="container">
                    <center>
                        <h2 style="font-family:Blunter;">DATA PROGRESS</h2>
                    </center>
	            </div><br />
                <asp:Button ID="BtnNilaiSM" runat="server" Text="Tambah Progress" CssClass="button button4" />
                <br /><br />
                <asp:SqlDataSource ID="SqlDataSMutu" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [MUTUN_ID], [MUTUN_TARGET], [MUTUN_ACTUAL], [MUTUN_CARAHITUNG1], [MUTUN_CARAHITUNG2], [MUTUN_CREATEUSER], [MUTUN_PROGRESS], [MUTUN_CREATEMGMTGL], [MUTUN_CREATEMGM], [MUTUN_CREATEUSERTGL] FROM [TRXN_ISOENILAI] WHERE ([MUTUN_ID] = ?)"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtID" Name="MUTUN_ID" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>                                     
                <asp:ListView ID="LVNilaiSasaranMutu" runat="server" DataSourceID="SqlDataSMutu" DataKeyNames ="MUTUN_PROGRESS">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered table-striped" align="left">
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white" class="col-md-1">No.</th>
                                <th style="text-align:center; color:white" class="col-md-2">Progress</th>
                                <th style="text-align:center; color:white" class="col-md-1">Target</th>
                                <th style="text-align:center; color:white" class="col-md-1">Actual</th>
                                <th style="text-align:center; color:white" class="col-md-3">Cara Hitung</th>
                                <th style="text-align:center; color:white" class="col-md-2">Head</th>
                                <th style="text-align:center; color:white" class="col-md-2">Wakil Manajemen</th>
                                <th style="text-align:center; color:white" class="col-md-1">Detail</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
        
                    <ItemTemplate>
                        <tr>
                            <td align="center"><%#Container.DataItemIndex + 1 %></td>
                            <td style="text-align:center"><%#Eval("MUTUN_PROGRESS")%></td>
                            <td style="text-align:center"><%#Eval("MUTUN_TARGET")%>%</td>
                            <td style="text-align:center"><%#Eval("MUTUN_ACTUAL")%>%</td>
                            <td><%#Eval("MUTUN_CARAHITUNG1")%><%#Eval("MUTUN_CARAHITUNG2")%></td>
                            <td><%#Eval("MUTUN_CREATEUSER")%><br />
                                <%#Eval("MUTUN_CREATEUSERTGL")%>
                            </td>
                            <td><%#Eval("MUTUN_CREATEMGM")%><br />
                                <%#Eval("MUTUN_CREATEMGMTGL")%>
                            </td>
                            <td><asp:LinkButton ID="lnkSelect" Text='Detail' CommandName="Select" runat="server" ><img src="img/details.png" width="60px" height="50px" /></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>Progress Sasaran Mutu Tidak diketemukan</EmptyDataTemplate> 
                    <EmptyItemTemplate>Progress Sasaran Mutu Tidak diketemukan</EmptyItemTemplate>              
                </asp:ListView>
                <br /><br />
            </asp:View> 
        </asp:MultiView>
        <asp:MultiView ID="MultiViewNilaiProgressEntry" runat="server" Visible="TRUE">
            <asp:View ID="View2" runat="server">
                <div class="container">
                    <div class="panel panel-default" style="margin-left:-25px">
                        <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Progress</font></div>
                        <div class="panel-body">
                            <center>
                                <h2 style="font-family:Blunter;">FORM PROGRESS</h2>
                            </center>
	                        <br /><br />
                            <table class="table table-borderless" align="left">
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label20" runat="server" Text="Progress"></asp:Label></td>
                                    <td class="col-md-4"><asp:Label ID="lblSasaranMutuProgress" runat="server" Text="Progress"></asp:Label>
                                        <asp:TextBox ID="TxtSasaranMutuProgress" runat="server" MaxLength="1" ValidationGroup="MKE" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"/>
                                        <asp:LinkButton ID="Button1" runat="server" CssClass="btn btn-default" CausesValidation="False" >
                                            <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
                                        </asp:LinkButton>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                            TargetControlID="TxtSasaranMutuProgress" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                                            ControlExtender="MaskedEditExtender1" ControlToValidate="TxtSasaranMutuProgress" EmptyValueMessage="Date is required"
                                            InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                            EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtSasaranMutuProgress" PopupButtonID="Button1" />
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label5" runat="server" Text="Target"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtSasaranMutuTarget" runat="server" class="form-control required" />
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label7" runat="server" Text="Aktual"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtSasaranMutuActual" runat="server" class="form-control required" />
                                    </td>
                                    <td class="col-md-2"></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label8" runat="server" Text="Cara Hitung"></asp:Label></td>
                                    <td class="col-md-4"><asp:TextBox ID="TxtSasaranMutuHitung" runat="server"  class="form-control required" Text =""></asp:TextBox></td>  
                                    <td class="col-md-2"></td>
                                </tr>
                                <!--
                                <tr> 
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2"><asp:Label ID="Label9" runat="server" Text="Persetujuan Head"></asp:Label></td>
                                    <td class="col-md-4"><asp:Button ID="BtnNilaiSMSave0" cssClass="btn btn-info" runat="server" Text="Disetujui Head" /></td>
                                    <td class="col-md-2"></td>
                                </tr>-->
                            </table>
                
                            <center>
                                <asp:Label ID="LblErrorSaveC" runat="server" Font-Names="Arial" Font-Size="Small" height= "21px" Text="" style="color: red;"></asp:Label>
                                <asp:Button ID="BtnNilaiSMBack" runat="server" Text="Tutup Form" CssClass="btn btn-warning" />
                                <asp:Button ID="BtnNilaiSMSave" runat="server" Text="Simpan" cssClass="btn btn-success" />
                                <asp:Button ID="BtnNilaiSMSave1" visible="false" runat="server" Text="Disetujui Wakil Manajemen" CssClass="btn btn-info"/>
                                <asp:Button ID="BtnNilaiSMDel" runat="server"  Text="Hapus" cssClass="btn btn-danger" />
                            </center><br /><br />
                        </div>
                    </div>
                </div>
            </asp:View>            
        </asp:MultiView>
        
        <asp:MultiView ID="MultiViewMasalah" runat="server" Visible="TRUE">
            <asp:View ID="View6" runat="server">
                <div style="margin-top:25px; border-top:2px dotted #ff0000;"></div>
                <br />
                <div class="container">
                    <center>
                        <h2 style="font-family:Blunter;">DATA MASALAH</h2>
                    </center>
	            </div><br />
                <asp:Button ID="BtnD" runat="server" class="button button4" Text="Tambah Data Masalah" />
                <br /><br />
                <asp:SqlDataSource ID="SqlDataMasalah" runat="server"
                    ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                    SelectCommand="SELECT [MUTUM_ID], [MUTUM_PROGRESS], [MUTUM_MASALAH] FROM [TRXN_ISOCMASALAH] WHERE (([MUTUM_ID] = ?) AND ([MUTUM_PROGRESS] = ?))"
                    ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtID" Name="MUTUM_ID" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="lblSasaranMutuProgress" Name="MUTUM_PROGRESS" PropertyName="Text" Type="DateTime" />
                    </SelectParameters>
                </asp:SqlDataSource>                                     
                <asp:ListView ID="LvMasalah" runat="server" DataSourceID="SqlDataMasalah" DataKeyNames ="MUTUM_MASALAH">
                    <LayoutTemplate>
                        <table id="table-a" class="table table-bordered table-striped" align="left" >
                            <thead style="background-color:#4877CF">
                                <th style="text-align:center; color:white" class="col-md-1">No.</th>
                                <th style="text-align:center; color:white" class="col-md-10">Masalah</th>
                                <th style="text-align:center; color:white" class="col-md-1">Detail</th>
                            </thead>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </table>
    
                        <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowNextPageButton="true" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#Container.DataItemIndex + 1 %></td>
                        <td><%#Eval("MUTUM_MASALAH")%></td>
                        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='HAPUS' CommandName="Select" runat="server" ><img src="img/delete.png" width="60px" height="50px" /></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>Data Masalah Tidak diketemukan(1)</EmptyDataTemplate> 
                <EmptyItemTemplate>Data Masalah Tidak diketemukan(2)</EmptyItemTemplate>              
            </asp:ListView><br /><br />
        </asp:View> 
    </asp:MultiView>
    <asp:MultiView ID="MultiViewMasalahENtry" runat="server" Visible="TRUE">
        <asp:View ID="View7" runat="server"><br />
            <div class="container">
                <div class="panel panel-default" style="margin-left:-25px">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Data Masalah</font></div>
                    <div class="panel-body">
                        <center>
                            <h2 style="font-family:Blunter;">FORM DATA MASALAH</h2>
                        </center>
                        <br /><br />
                        <table class="table table-borderless" align="left">
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label10" runat="server" Text="Masalah"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtMasalahDesc" class="form-control required" runat="server" Text ="Mugen jaya"></asp:TextBox></td>
                                <td class="col-md-2"></td>
                             </tr>
                        </table>
                       <center><asp:Label ID="LblErrorSaveD" runat="server" Text="" style="color: red;"></asp:Label></center>
        
                        <center>
                            <asp:Button ID="BtnDBack" runat="server" Text="Tutup Form" cssClass="btn btn-warning" />
                            <asp:Button ID="BtnDSave" runat="server" Text="Simpan" cssClass="btn btn-success" />
                        </center>
                    </div>
                </div>
            </div>
        </asp:View> 
    </asp:MultiView>

    <asp:MultiView ID="MultiViewKoreksi" runat="server" Visible="TRUE">
        <asp:View ID="View8" runat="server">
            <div style="margin-top:25px; border-top:2px dotted #ff0000;"></div>
            <br />
            <div class="container">
                    <center>
                        <h2 style="font-family:Blunter;">DATA KOREKSI</h2>
                    </center>
	            </div><br />
            <asp:Button ID="BtnE" runat="server" class="button button4" Text="Tambah Data Koreksi"  />
            <br /><br />
            <asp:SqlDataSource ID="SqlDataKoreksi" runat="server"
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                SelectCommand="SELECT [MUTUT_ID], [MUTUT_PROGRESS], [MUTUT_TIPE], [MUTUT_TINDAKAN], [MUTUT_PIC], [MUTUT_DUE] FROM [TRXN_ISODTINDAKAN] WHERE (([MUTUT_ID] = ?) AND ([MUTUT_TIPE] = ?) AND ([MUTUT_PROGRESS] = ?))"
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">

                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtID" Name="MUTUT_ID" PropertyName="Text" Type="String" />
                    <asp:Parameter DefaultValue="A" Name="MUTUT_TIPE" Type="String" />
                    <asp:ControlParameter ControlID="lblSasaranMutuProgress" Name="MUTUT_PROGRESS" PropertyName="Text" Type="DateTime" />
                </SelectParameters>
            </asp:SqlDataSource>   
                                          
            <asp:ListView ID="LVKoreksi" runat="server" DataSourceID="SqlDataKoreksi" DataKeyNames ="MUTUT_TINDAKAN">
                <LayoutTemplate>
                    <table id="table-a"  class="table table-bordered table-striped" align="left">
                        <thead style="background-color:#4877CF">    
                            <th style="text-align:center; color:white;" class="col-md-1">No.</th>
                            <th style="text-align:center; color:white;" class="col-md-6">Koreksi</th>
                            <th style="text-align:center; color:white;" class="col-md-2">PIC</th>
                            <th style="text-align:center; color:white;" class="col-md-2">Due Date</th>
                            <th style="text-align:center; color:white;" class="col-md-1">Detail</th>
                        </thead>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
    
                    <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" ShowLastPageButton="false" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                            ShowNextPageButton="true" ShowLastPageButton="true" />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>
        
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#Container.DataItemIndex + 1 %></td>
                        <td><%#Eval("MUTUT_TINDAKAN")%></td>
                        <td style="text-align:center"><%#Eval("MUTUT_PIC")%></td>
                        <td style="text-align:center"><%#Eval("MUTUT_DUE")%></td>
                        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='Hapus' CommandName="Select" runat="server" ><img src="img/delete.png" width="60px" height="50px" /></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>Data Koreksi Tidak diketemukan</EmptyDataTemplate> 
                <EmptyItemTemplate>Data Koreksi Tidak diketemukan</EmptyItemTemplate>              
            </asp:ListView>
            <br />
            <table style="width: 100%; height:inherit; font-family: Arial; font-size: small;">
                <tr>
                    <td style="width: 100%; background-color: #000000;  color: #FFFFFF;">
                        
                    </td>
                </tr>
            </table> <br /><br />
        </asp:View> 
    </asp:MultiView>
    <asp:MultiView ID="MultiViewKoreksiEntry" runat="server" Visible="TRUE">
        <asp:View ID="View9" runat="server">
            <div class="container">
                <div class="panel panel-default" style="margin-left:-25px">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Data Koreksi</font></div>
                    <div class="panel-body">
                        <center>
                            <h2 style="font-family:Blunter;">FORM DATA KOREKSI</h2>
                        </center>
	                    <br /><br />
                        <table class="table table-borderless" align="left">
                            <tr>
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label13" runat="server" Text="Koreksi"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtKoreksiTindakan" class="form-control required" runat="server" MaxLength="200" Text ="Mugen jaya"></asp:TextBox></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label14" runat="server" Text="P I C" ></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtKoreksiPIC" class="form-control required" runat="server" MaxLength="10" Text ="Mugen jaya"   ></asp:TextBox></td>
                                <td class="col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label15" runat="server" Text="Due Date"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtKoreksiDue" runat="server" MaxLength="1" ValidationGroup="MKE" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;"/>
                                    <asp:LinkButton ID="Button4" runat="server" CssClass="btn btn-default" CausesValidation="False" >
                                        <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
                                    </asp:LinkButton>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server"
                                    TargetControlID="TxtKoreksiDue" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator4" runat="server"
                                    ControlExtender="MaskedEditExtender4" ControlToValidate="TxtKoreksiDue" EmptyValueMessage="Date is required"
                                    InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />

                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TxtKoreksiDue" PopupButtonID="Button4" />
                                </td>
                                <td class="col-md-2"></td> 
                            </tr>
                        </table>
                        <center><asp:Label ID="LblErrorSaveE" runat="server" Text="" style="color: red;"></asp:Label></center>
                        <center>
                                <asp:Button ID="BtnEBack" runat="server" Text="Tutup Form" cssClass="btn btn-warning" />
                                <asp:Button ID="BtnESave" runat="server" Text="Simpan" cssClass="btn btn-success" />
                         </center>
                    </div>
                </div>
            </div>
        </asp:View> 
    </asp:MultiView>
    
    <asp:MultiView ID="MultiViewPerbaikan" runat="server" Visible="TRUE">
        <asp:View ID="View10" runat="server">
            <div style="margin-top:25px; border-top:2px dotted #ff0000;"></div>
            <br />
            <div class="container">
                    <center>
                        <h2 style="font-family:Blunter;">DATA PERBAIKAN</h2>
                    </center>
	            </div><br />
            <asp:Button ID="BtnF" runat="server" Text="Tambah Data Perbaikan" class="button button4" />
            <br /><br />
            <asp:SqlDataSource ID="SqlDataPerbaik" runat="server"
                ConnectionString="<%$ ConnectionStrings:MyConnCloudDnet2 %>"
                SelectCommand="SELECT [MUTUT_ID], [MUTUT_PROGRESS], [MUTUT_TIPE], [MUTUT_TINDAKAN], [MUTUT_PIC], [MUTUT_DUE] FROM [TRXN_ISODTINDAKAN] WHERE (([MUTUT_ID] = ?) AND ([MUTUT_TIPE] = ?) AND ([MUTUT_PROGRESS] = ?))"
                ProviderName="<%$ ConnectionStrings:MyConnCloudDnet2.ProviderName %>">

                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtID" Name="MUTUT_ID" PropertyName="Text" Type="String" />
                    <asp:Parameter DefaultValue="B" Name="MUTUT_TIPE" Type="String" />
                    <asp:ControlParameter ControlID="lblSasaranMutuProgress" Name="MUTUT_PROGRESS" PropertyName="Text" Type="DateTime" />
                </SelectParameters>
            </asp:SqlDataSource>   
                                          
            <asp:ListView ID="LvPerbaikan" runat="server" DataSourceID="SqlDataPerbaik" DataKeyNames ="MUTUT_TINDAKAN">
                <LayoutTemplate>
                    <table class="table table-bordered table-striped" align="left">
                        <thead style="background-color:#4877CF">  
                            <th style="text-align:center; color:white" class="col-md-1">No.</th>  
                            <th style="text-align:center; color:white" class="col-md-6">Perbaikan</th>
                            <th style="text-align:center; color:white" class="col-md-2">PIC</th>
                            <th style="text-align:center; color:white" class="col-md-2">Due Date</th>
                            <th style="text-align:center; color:white" class="col-md-1">Detail</th>
                        </thead>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
    
                    <asp:DataPager ID="dpBerita" PageSize="5" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" ShowLastPageButton="false" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                            ShowNextPageButton="true" ShowLastPageButton="true" />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>
        
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#Container.DataItemIndex + 1 %></td>
                        <td style="text-align:center"><%# Eval("MUTUT_TINDAKAN") %></td>
                        <td style="text-align:center"><%#Eval("MUTUT_PIC")%></td>
                        <td style="text-align:center"><%#Eval("MUTUT_DUE")%></td>
                        <td style="text-align:center"><asp:LinkButton ID="lnkSelect" Text='HAPUS' CommandName="Select" runat="server" ><img src="img/delete.png" width="60px" height="50px" /></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>Data Tindakan Tidak diketemukan</EmptyDataTemplate> 
                <EmptyItemTemplate>Data Tindakan Tidak diketemukan</EmptyItemTemplate>              
            </asp:ListView>
            <br /><br /><br />
        </asp:View> 
    </asp:MultiView>
    <asp:MultiView ID="MultiViewPerbaikanEntry" runat="server" Visible="TRUE">
        <asp:View ID="View11" runat="server">
            <div class="container">
                <div class="panel panel-default" style="margin-left:-25px">
                    <div class="panel-heading" style="background-color:#2277B5"><span style="color:#ffffff" class="glyphicon glyphicon-duplicate"></span> &nbsp <font style="color:#ffffff">Form Progress</font></div>
                    <div class="panel-body">
                        <center>
                            <h2 style="font-family:Blunter;">DETAIL PERBAIKAN</h2>
                        </center>
	                    <br /><br />
                        <table class="table table-borderless" align="left">
                            <tr>
                                <td class="col-md-2"></td>   
                                <td class="col-md-2"><asp:Label ID="Label151" runat="server" Text="Koreksi"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtPerbaikanTindakan" class="form-control required" runat="server" MaxLength="200" Text ="Mugen jaya"></asp:TextBox></td>
                                <td class="col-md-2"></td> 
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td> 
                                <td class="col-md-2"><asp:Label ID="Label17" runat="server" Text="P I C"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtPerbaikanPIC" class="form-control required" runat="server" MaxLength="10" Text ="Mugen jaya" ></asp:TextBox></td>
                                <td class="col-md-2"></td> 
                            </tr>
                            <tr> 
                                <td class="col-md-2"></td>
                                <td class="col-md-2"><asp:Label ID="Label18" runat="server" Text="Due Date"></asp:Label></td>
                                <td class="col-md-4"><asp:TextBox ID="TxtPerbaikanDue" runat="server" style="width: 130px; height: 35px; padding: 12px 10px; box-sizing: border-box; border: 1px solid Silver; border-radius: 4px;" MaxLength="1" ValidationGroup="MKE" />
                                    <asp:LinkButton ID="Button5" runat="server" CssClass="btn btn-default" CausesValidation="False" >
                                        <span aria-hidden="true" class="glyphicon glyphicon-calendar"></span>
                                    </asp:LinkButton>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server"
                                    TargetControlID="TxtPerbaikanDue" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />

                                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator5" runat="server"
                                    ControlExtender="MaskedEditExtender5" ControlToValidate="TxtPerbaikanDue" EmptyValueMessage="Date is required"
                                    InvalidValueMessage="Date is invalid" Display="Dynamic" IsValidEmpty="false" TooltipMessage="Input a date"
                                    EmptyValueBlurredText="*" InvalidValueBlurredMessage="Format MM/DD/YYYY Bulan Tanggal Tahun" ValidationGroup="MKE" />

                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="TxtPerbaikanDue" PopupButtonID="Button5" />
                                </td>
                                <td class="col-md-2"></td>
                            </tr>
                        </table>
                        <center> 
                            <asp:Label ID="LblErrorSaveF" runat="server" Text="" style="color: red;"></asp:Label>                  
                            <asp:Button ID="BtnFBack" runat="server" Text="Tutup Form" cssClass="btn btn-warning" />
                            <asp:Button ID="BtnFSave" runat="server" Text="Simpan" CssClass="btn btn-success" />      
                        </center>
                    </div>
                </div>
            </div>
        </asp:View> 
    </asp:MultiView>
</div>
    <style>
        .table-borderless > tbody > tr > td,
        .table-borderless > tbody > tr > th,
        .table-borderless > tfoot > tr > td,
        .table-borderless > tfoot > tr > th,
        .table-borderless > thead > tr > td,
        .table-borderless > thead > tr > th {
            border: none;
        }

         .button {
            background-color: #4CAF50; /* Green */
            border-radius: 4px;
            border: none;
            color: white;
            padding: -10px 32px;
            width:160px;
            height:50px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 13px;
            margin: 4px 2px;
            -webkit-transition-duration: 0.4s; /* Safari */
            transition-duration: 0.4s;
            cursor: pointer;
        }

        .button4 {
            background-color: #9FB7E0;
            color: black;
            border: 2px solid #9FB7E0;
        }

        .button4:hover {
            background-color: #0071BB;
            color: white;
        }
    </style>

    <script type="text/javascript">
	    $(document).ready(function(){
	        $('.data').DataTable();
	    });
    </script>
</asp:Content>
