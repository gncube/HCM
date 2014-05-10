<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="GND.Modules.HCM.View" %>

<button type="button" class="btn btn-success">
    <span class="glyphicon glyphicon-plus"></span>
    Add Starter
</button>
<button type="button" class="btn btn-primary">
    <span class="glyphicon glyphicon-th-list"></span>
    Existing Starters
</button>

<asp:Repeater ID="rptItemList" runat="server" OnItemDataBound="rptItemListOnItemDataBound" OnItemCommand="rptItemListOnItemCommand">
    <HeaderTemplate>
        <table>
            <thead>
                <th>Edit</th>
                <th>Delete</th>
                <th>Name</th>
                <th>Description</th>
                <th>Category</th>
                <th>Location</th>
                <th>IsDeleted</th>
            </thead>
            <tbody>
    </HeaderTemplate>

    <ItemTemplate>
        <tr>
            <td><asp:HyperLink ID="lnkEdit" runat="server" ResourceKey="EditItem.Text" Visible="false" Enabled="false" /></td>
            <td><asp:LinkButton ID="lnkDelete" runat="server" ResourceKey="DeleteItem.Text" Visible="false" Enabled="false" CommandName="Delete" /></td>
            <td><asp:Label ID="lblitemName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ItemName").ToString() %>' /></td>
            <td><asp:Label ID="lblItemDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ItemDescription").ToString() %>' CssClass="tm_td" /></td>
            <td><asp:Label ID="lblCategory" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CategoryId").ToString() %>' /></td>
            <td><asp:Label ID="lblLocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LocationId").ToString() %>' /></td>
            <td></td>
        </tr>
            <asp:Panel ID="pnlAdmin" runat="server" Visible="false">
            </asp:Panel>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>


