<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Starters.ascx.cs" Inherits="GND.Modules.HCM.Starters" %>

<div class="row">
    <asp:HyperLink runat="server" CssClass="btn btn-success" ID="lnkNewStarter">
    <span class="glyphicon glyphicon-plus"></span>
    Add Starter
    </asp:HyperLink>

    <asp:HyperLink runat="server" CssClass="btn btn-primary" ID="lnkCompleted" Visible="False">
        <span class="glyphicon glyphicon-th-list"></span>
        Awaiting IT </asp:HyperLink>
    
    <asp:HyperLink runat="server" CssClass="btn btn-warning" ID="lnkApprovals" Visible="False">
        <span class="glyphicon glyphicon-tasks"></span>
        Pending Approvals
    </asp:HyperLink>

</div>

<div class="row">
    <asp:Repeater runat="server" ID="rptStarterList" OnItemCommand="rptStarterList_ItemCommand" OnItemDataBound="rptStarterList_ItemDataBound">
        <HeaderTemplate>
            <table class="table table-hover table-striped">
                <thead>
                    <tr>
                        <th></th>
                        <th>Starter Name</th>
                        <th>Job Title</th>
                        <th>Category</th>
                        <th>Department</th>
                        <th>Location</th>
                        <th>Start Date</th>

                        <th></th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td></td>
                <td><asp:Label runat="server" ID="lblDisplayName" Text='<%# String.Format("{0} {1}", DataBinder.Eval(Container.DataItem, "FirstName").ToString(), DataBinder.Eval(Container.DataItem, "LastName").ToString()) %>'></asp:Label></td>
                
                <td>
                    <asp:Label ID="lblJobTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"JobTitle").ToString() %>' /></td>
                <td>
                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLocation" runat="server"></asp:Label>
                </td>
                <td>
<<<<<<< HEAD
                    <asp:Label ID="lblStartDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StartDate", "{0:d}")!= null ? DataBinder.Eval(Container.DataItem,"StartDate", "{0:d}").ToString() : ""  %>' />
=======
                    <asp:Label ID="lblStartDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StartDate")!= null ? DataBinder.Eval(Container.DataItem,"StartDate", "{0:d/M/yy}") : ""  %>' />
>>>>>>> origin/master
                </td>

                <td>
                    <asp:HyperLink ID="lnkEdit" CssClass="btn btn-info btn-xs" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id").ToString() %>' ResourceKey="EditItem.Text" Visible="false" Enabled="false" />
                    <asp:HyperLink ID="lnkApprove" CssClass="btn btn-success btn-xs" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id").ToString() %>' ResourceKey="ApproveItem.Text" Visible="true" Enabled="false" />
                    <asp:LinkButton ID="lnkDelete" CssClass="btn btn-warning btn-xs" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id").ToString() %>' ResourceKey="DeleteItem.Text" Visible="false" Enabled="false" CommandName="Delete" />

                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
        </table>
        </FooterTemplate>
    </asp:Repeater>

</div>
