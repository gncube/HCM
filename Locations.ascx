<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Locations.ascx.cs" Inherits="GND.Modules.HCM.Locations" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<div class="dnnForm dnnClear">
    <ul class="dnnActions dnnClear">
			<li>
				<asp:LinkButton ID="cmdAddNew" resourcekey="cmdAddNew" runat="server" CssClass="dnnPrimaryAction" CausesValidation="False"   /></li>
			<li>
				<asp:LinkButton ID="cmdGoBack" resourcekey="cmdGoBack" runat="server" CssClass="dnnSecondaryAction" CausesValidation="False"  /></li>
		</ul>
    
    <asp:Repeater ID="rptLocationList" runat="server">
    <HeaderTemplate>
        <ol class="tm_tl">
    </HeaderTemplate>

    <ItemTemplate>
        <li class="tm_t">
            <h3>
                <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Name").ToString() %>' />
            </h3>
            <asp:Label ID="lblDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Description").ToString() %>' CssClass="tm_td" />

            <asp:Panel ID="pnlAdmin" runat="server" Visible="false">
                <asp:HyperLink ID="lnkEdit" runat="server" ResourceKey="EditItem.Text" Visible="false" Enabled="false" />
                <asp:LinkButton ID="lnkDelete" runat="server" ResourceKey="DeleteItem.Text" Visible="false" Enabled="false" CommandName="Delete" />
            </asp:Panel>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ol>
    </FooterTemplate>
</asp:Repeater>
        
        <div>
            <div class="dnnFormItem">
				<dnn:Label ID="plName" runat="server" ControlName="CategoryEdit"></dnn:Label>
				<asp:TextBox ID="txtName" runat="server" MaxLength="100" CssClass="dnnFormRequired"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rqdName" runat="server" CssClass="dnnFormMessage dnnFormError" ErrorMessage="Category name is required" ControlToValidate="txtName" resourcekey="rqdName"></asp:RequiredFieldValidator>
			</div>
			<div class="dnnFormItem">
				<dnn:Label ID="plDescription" runat="server" ControlName="LocationEdit"></dnn:Label>
				<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" MaxLength="250" CssClass="dnnFormRequired"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rqdDescription" runat="server" CssClass="dnnFormMessage dnnFormError" ErrorMessage="Description is Required" ControlToValidate="txtDescription" resourcekey="rqdDescription"></asp:RequiredFieldValidator>
			</div>
			<ul class="dnnActions dnnClear">
				<li>
					<asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" runat="server" CssClass="dnnPrimaryAction" OnClick="cmdUpdate_Click" /></li>
				<li>
					<asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" runat="server" CssClass="dnnSecondaryAction"  CausesValidation="False" /></li>
				<li>
					<asp:LinkButton ID="cmdDelete" resourcekey="cmdDelete" runat="server" CssClass="dnnSecondaryAction"  /></li>
			</ul>
        </div>
</div>
