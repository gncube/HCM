<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddAsset.ascx.cs" Inherits="GND.Modules.HCM.Controls.AddAsset" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>


 <h2>Add Assets</h2>
<div class="dnnForm">
    <fieldset>
        <div class="dnnFormItem">
            <dnn:label runat="server" ControlName="cblAssets" Text="Select Asset" HelpText="It's the name of the thing" />
            <asp:DropDownList ID="cblAssets" runat="server"></asp:DropDownList>
        </div>
    </fieldset>
</div>
