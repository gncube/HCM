<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditApproval.ascx.cs" Inherits="GND.Modules.HCM.EditApproval" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>

<div class="row">
    <div class="form-horizontal">
        <div class="col-sm-6">
            <div class="form-group">
                <label class="col-sm-3 control-label">First Name</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <label class="col-sm-3 control-label">Assigned User</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtAssignedUser" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 control-label">Department</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 control-label">Start Date</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

        </div>
        <div class="col-sm-6">
            <div class="form-group">
                <label class="col-sm-3 control-label">Job Title</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 control-label">Work Base</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 control-label">Contract Type</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 control-label">End Date</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</div>

<div class="row">
    <div class="form-horizontal">
<<<<<<< HEAD
        <h3>New Starter Details </h3>
        <fieldset>
            <div class="form-group">
                <label for="txtUsername" class="col-sm-2 control-label">Username</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label for="txtPassword" class="col-sm-2 control-label">Password</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" />
                </div>
=======
        <h3>Approval of New Starter</h3>
        <div class="form-group">
            <label for="txtComments" class="col-sm-2 control-label">Comments</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtComments" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-1 col-sm-11">
                <div class="checkbox">
                    <asp:CheckBox ID="chkApprove" runat="server" Text="Authorize this new starter" />
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-1 col-sm-11">
                <asp:LinkButton ID="btnApprove" runat="server" Text="Approve" ResourceKey="ApproveStarter.Text" CssClass="btn btn-primary" OnClick="btnApprove_Click" />
                
                 <asp:LinkButton ID="btnDecline" runat="server" Text="Decline" ResourceKey="DeclineStarter.Text" CssClass="btn btn-warning" OnClick="btnDecline_Click" />
>>>>>>> origin/master
            </div>
        </fieldset>
        <footer>
            <asp:LinkButton ID="btnSubmit" runat="server"
                resourcekey="btnSubmit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
            <asp:LinkButton ID="btnCancel" runat="server"
                resourcekey="btnCancel" CssClass="btn btn-default" OnClick="btnCancel_Click" />
        </footer>
    </div>
</div>
