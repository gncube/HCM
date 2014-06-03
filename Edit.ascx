<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="GND.Modules.HCM.Edit" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register Src="Controls/AddAsset.ascx" TagName="AddAsset" TagPrefix="uc1" %>
<div class="dnnForm dnnEditBasicSettings" id="dnnEditBasicSettings">
    <div class="dnnFormExpandContent dnnRight "><a href="" class="hidden"><%=LocalizeString("ExpandAll")%></a></div>

    <h2 id="dnnSitePanel-BasicSettings" class="dnnFormSectionHead dnnClear hidden">
        <a href="" class="dnnSectionExpanded">
            <%=LocalizeString("BasicSettings")%></a></h2>
    <fieldset>
        <div class="form-inline">
            <div class="col-md-6">
                <div class="dnnFormItem">
                    <dnn:label ID="lblFirstName" runat="server" controlname="txtFirstName" />
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control col-md-6" />
                    <asp:RequiredFieldValidator ID="valRequiredFirstName" runat="server" resourcekey="valRequiredFirstName" ControlToValidate="txtFirstName" ErrorMessage="First name is required" CssClass="dnnFormMessage dnnFormError"></asp:RequiredFieldValidator>
                </div>
                <div class="dnnFormItem">
                    <dnn:label ID="lblJobTitle" runat="server" controlname="txtJobTitle" />
                    <asp:TextBox ID="txtJobTitle" runat="server" />
                    <asp:RequiredFieldValidator ID="valRequiredJobTitle" runat="server" resourcekey="valRequiredJobTitle" ControlToValidate="txtJobTitle" ErrorMessage="Job title is required" CssClass="dnnFormMessage dnnFormError"></asp:RequiredFieldValidator>
                </div>

                <div class="dnnFormItem">
                    <dnn:label ID="lblAssignedUser" runat="server" />
                    <asp:DropDownList ID="ddlAssignedUser" runat="server" />
                </div>
                <div class="dnnFormItem">
                    <dnn:label ID="lblApprover" runat="server" />
                    <asp:DropDownList ID="ddlApprover" runat="server" />
                </div>
                <div class="dnnFormItem">
                    <dnn:Label ID="lblStartDate" runat="server" ControlName="dpStartDate" />
                    <dnn:DnnDatePicker ID="dpStartDate" runat="server" />
                    &nbsp;
       
                    <asp:CompareValidator ID="valStartDate" resourcekey="valStartDate.ErrorMessage" Operator="DataTypeCheck" Type="Date" runat="server" Display="Dynamic" ControlToValidate="dpStartDate" CssClass="dnnFormMessage dnnFormError" />
                </div>

            </div>

            <div class="col-md-6">
                <div class="dnnFormItem">
                    <dnn:label ID="lblLastName" class="col-md-6 pull-left" runat="server" controlname="txtLastName" />
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control col-md-6" />
                    <asp:RequiredFieldValidator ID="valRequiredLastName" runat="server" resourcekey="valRequiredLastName" ControlToValidate="txtLastName" ErrorMessage="Surname is required" CssClass="dnnFormMessage dnnFormError"></asp:RequiredFieldValidator>
                </div>
                <div class="dnnFormItem">
                    <dnn:Label id="plLocation" runat="server" controlname="drpLocation">
                    </dnn:Label>
                    <asp:DropDownList ID="drpLocation" runat="server">
                        <asp:ListItem Value="-1" resourcekey="SelectLocation">Select Location</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="dnnFormItem">
                    <dnn:Label id="plCategoryField" runat="server" controlname="drpCategory">
                    </dnn:Label>
                    <asp:DropDownList ID="drpCategory" runat="server">
                        <asp:ListItem Value="-1" resourcekey="SelectCategory">Select Category</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="dnnFormItem">
                    <dnn:Label id="lblDepartment" runat="server" controlname="drpDepartment">
                    </dnn:Label>
                    <asp:DropDownList ID="drpDepartment" runat="server">
                        <asp:ListItem Value="-1" resourcekey="SelectDepartment">Select Department</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="dnnFormItem">
                    <dnn:Label ID="lblEndDate" runat="server" ControlName="dpEndDate" />
                    <dnn:DnnDatePicker ID="dpEndDate" runat="server" />
                    &nbsp;
       
                    <asp:CompareValidator ID="valEndDate" resourcekey="valEndDate.ErrorMessage" Operator="DataTypeCheck" Type="Date" runat="server" Display="Dynamic" ControlToValidate="dpEndDate" CssClass="dnnFormMessage dnnFormError" />
                    <asp:CompareValidator ID="val2EndDate" resourcekey="val2EndDate.ErrorMessage" Operator="GreaterThanEqual" Type="Date" runat="server" Display="Dynamic" ControlToValidate="dpEndDate" ControlToCompare="dpStartDate" CssClass="dnnFormMessage dnnFormError" />
                </div>

            </div>

        </div>
        <asp:Panel runat="server" ID="pnlAssets" Visible="false">
            <div class="col-md-6">
                <h2>Add Assets</h2>
                <asp:Repeater runat="server" ID="rptAssets">
                    <HeaderTemplate>
                        <ul class="nav nav-pills">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li class="active">
                            <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AssetId").ToString() %>' />
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-6">
                
                <div class="dnnForm">
                    <fieldset>
                        <div class="dnnFormItem">
                            <dnn:label runat="server" ControlName="cblAssets" Text="Select Asset" HelpText="It's the name of the thing" />
                            <asp:DropDownList ID="ddlAssets" runat="server"></asp:DropDownList>
                            <asp:LinkButton ID="cmdAddAsset" runat="server" CssClass="btn btn-success" OnClick="cmdAddAsset_Click">Add</asp:LinkButton>
                            <%--<asp:SqlDataSource ID="sqlAssets" runat="server" ConnectionString="<%$ ConnectionStrings:SiteSqlServer %>" SelectCommand="SELECT [Id], [Name], [Description] FROM [HCM_Asset]"></asp:SqlDataSource>--%>
                        </div>
                    </fieldset>
                </div>
            </div>

        </asp:Panel>
    </fieldset>
</div>
<asp:LinkButton ID="btnSubmit" runat="server"
    OnClick="btnSubmit_Click" resourcekey="btnSubmit" CssClass="dnnPrimaryAction" />
<asp:LinkButton ID="btnCancel" runat="server"
    OnClick="btnCancel_Click" resourcekey="btnCancel" CssClass="dnnSecondaryAction" />




<script language="javascript" type="text/javascript">
    /*globals jQuery, window, Sys */
    (function ($, Sys) {
        function dnnEditBasicSettings() {
            $('#dnnEditBasicSettings').dnnPanels();
            $('#dnnEditBasicSettings .dnnFormExpandContent a').dnnExpandAll({ expandText: '<%=Localization.GetString("ExpandAll", LocalResourceFile)%>', collapseText: '<%=Localization.GetString("CollapseAll", LocalResourceFile)%>', targetArea: '#dnnEditBasicSettings' });
        }

        $(document).ready(function () {
            dnnEditBasicSettings();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                dnnEditBasicSettings();
            });
        });

    }(jQuery, window.Sys));
</script>
