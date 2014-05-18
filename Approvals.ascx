﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Approvals.ascx.cs" Inherits="GND.Modules.HCM.Approvals" %>

<div class="row">
    <asp:HyperLink runat="server" CssClass="btn btn-success" ID="lnkNewStarter">
    <span class="glyphicon glyphicon-plus"></span>
    Add Starter
    </asp:HyperLink>

    <button type="button" class="btn btn-primary">
        <span class="glyphicon glyphicon-th-list"></span>
        Existing Starters</button>

    <button type="button" class="btn btn-warning">
        <span class="glyphicon glyphicon-tasks"></span>
        Pending Approvals
    </button>
</div>

<div class="form">
    <div class="form-group">
        <label for="exampleInputEmail1">Email address</label>
        <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Enter email">
    </div>
    <div class="form-group">
        <label for="exampleInputPassword1">Password</label>
        <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
    </div>
    <div class="form-group">
        <label for="exampleInputFile">File input</label>
        <input type="file" id="exampleInputFile">
        <p class="help-block">Example block-level help text here.</p>
    </div>
    <div class="checkbox">
        <label>
            <input type="checkbox">
            Check me out
        </label>
    </div>
    <button type="submit" class="btn btn-default">Submit</button>
</div>

<div class="row">
    <asp:Repeater runat="server" ID="rptStarterList">
        <HeaderTemplate>
            <table class="table table-hover table-striped">
                <thead>
                    <tr>
                        <th></th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Job Title</th>
                        <th>Line Manager</th>
                        <th>Contract Type</th>
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
                <td>First Name
                </td>
                <td>Last Name

                </td>
                <td>
                Job Title
                <td>Line Manager
                </td>
                <td>Contract Type
                </td>
                <td>Department
                </td>
                <td>Location
                </td>
                <td>Start Date
                </td>

                <td>
                    <%--<asp:HyperLink ID="lnkEdit" CssClass="btn btn-success" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id").ToString() %>' ResourceKey="EditItem.Text" Visible="false" Enabled="false" />
                    <asp:LinkButton ID="lnkDelete" CssClass="btn btn-danger" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id").ToString() %>' ResourceKey="DeleteItem.Text" Visible="false" Enabled="false" CommandName="Delete" />
                    --%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
        </table>
        </FooterTemplate>
    </asp:Repeater>
</div>

