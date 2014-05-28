/*
' Copyright (c) 2013  GND Software Ltd
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Roles;
using DotNetNuke.Security.Roles.Internal;
using DotNetNuke.Services.Localization;
using DotNetNuke.Services.Messaging;
using DotNetNuke.Services.Social.Messaging;
using DotNetNuke.Services.Social.Notifications;
using GND.Modules.HCM.Components;
using DotNetNuke.Services.Exceptions;
using MessagingController = DotNetNuke.Services.Social.Messaging.MessagingController;

namespace GND.Modules.HCM
{
    /// -----------------------------------------------------------------------------
    /// <summary>   
    /// The Edit class is used to manage content
    /// 
    /// Typically your edit control would be used to create new content, or edit existing content within your module.
    /// The ControlKey for this control is "Edit", and is defined in the manifest (.dnn) file.
    /// 
    /// Because the control inherits from HCMModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Edit : HCMModuleBase
    {
        #region Private Methods

        /// <summary>
        /// Populates the drop downs.
        /// </summary>
        private void PopulateDropDownLists()
        {
            //get a list of users to assign the user to the Object
            RoleController rc = new RoleController();
            ArrayList administrators = rc.GetUsersByRoleName(PortalId, "Administrators");
            ArrayList lineManagers = rc.GetUsersByRoleName(PortalId, "Subscribers");

            ddlAssignedUser.DataSource = administrators;
            ddlAssignedUser.DataTextField = "DisplayName";
            ddlAssignedUser.DataValueField = "UserID";
            ddlAssignedUser.DataBind();
            ddlAssignedUser.Items.Insert(0, "Select Approving Manager");
            //ddlAssignedUser.SelectedValue = "Select User";

            ddlApprover.DataSource = lineManagers;
            ddlApprover.DataTextField = "DisplayName";
            ddlApprover.DataValueField = "UserID";
            ddlApprover.DataBind();
            ddlApprover.Items.Insert(0, "Select Line Manager");

            CategoryController cats = new CategoryController();
            drpCategory.DataSource = cats.ListCategories(ModuleId, false);
            drpCategory.DataTextField = "Name";
            drpCategory.DataValueField = "Id";
            drpCategory.DataBind();
            drpCategory.Items.Insert(0, "Select Category");

            drpLocation.Items.Clear();
            drpLocation.Items.Add(new ListItem(Localization.GetString("SelectLocation.Text", this.LocalResourceFile), "-1"));
            LocationController l = new LocationController();
            drpLocation.DataSource = l.GetLocations(ModuleId);
            drpLocation.DataTextField = "Name";
            drpLocation.DataValueField = "Id";
            drpLocation.DataBind();
            drpLocation.Items.Insert(0, "Select Location");

            DepartmentController dc = new DepartmentController();
            drpDepartment.DataSource = dc.GetDepartments(ModuleId);
            drpDepartment.DataTextField = "Name";
            drpDepartment.DataValueField = "Id";
            drpDepartment.DataBind();
            drpDepartment.Items.Insert(0, "Select Department");

        }

        private void SendNotification(string subject, string body, UserInfo recipient)
        {
            var notificationType = NotificationsController.Instance.GetNotificationType("HtmlNotification");
            var portalSettings = PortalController.GetCurrentPortalSettings();
            //var sender = UserController.GetUserById(portalSettings.PortalId, portalSettings.AdministratorId);
            var sender = UserController.GetCurrentUserInfo();

            var notification = new Notification { NotificationTypeID = notificationType.NotificationTypeId, Subject = subject, Body = body, IncludeDismissAction = true, SenderUserID = sender.UserID };
            NotificationsController.Instance.SendNotification(notification, portalSettings.PortalId, null,
                new List<UserInfo> {recipient});

            
        }


        private void SendMessage(string subject, string body, UserInfo recipient)
        {
            var sender = UserController.GetCurrentUserInfo();
            var message = new Message
            {
                Body = body,
                From = sender.Email,
                Subject = subject,
                SenderUserID = sender.UserID,
                To = recipient.Email
            };

            MessagingController.Instance.SendMessage(message, null, new List<UserInfo>{recipient}, null, recipient);

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Implement your edit logic for your module
                if (!Page.IsPostBack)
                {
                    PopulateDropDownLists();

                    //check if we have an ID passed in via a querystring parameter, if so, load that item to edit.
                    //ItemId is defined in the ItemModuleBase.cs file
                    if (ItemId > 0)
                    {
                        var tc = new StarterController();

                        var t = tc.GetStarter(ItemId, ModuleId);
                        if (t != null)
                        {
                            txtFirstName.Text = t.FirstName;
                            txtLastName.Text = t.LastName;
                            txtJobTitle.Text = t.JobTitle;
                            drpCategory.Items.FindByValue(t.CategoryId.ToString()).Selected = true;
                            ddlAssignedUser.Items.FindByValue(t.AssignedUserId.ToString()).Selected = true;
                            drpLocation.Items.FindByValue(t.LocationId.ToString()).Selected = true;
                            drpDepartment.Items.FindByValue(t.DepartmentId.ToString()).Selected = true;
                            dpStartDate.SelectedDate = t.StartDate;
                            dpEndDate.SelectedDate = t.EndDate;
                        }
                    }
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }




        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var t = new Components.Starter();
            var tc = new StarterController();
            var a = new Components.Approval();
            var ac = new ApprovalController();

            if (ItemId > 0)
            {
                t = tc.GetStarter(ItemId, ModuleId);
                
                t.FirstName = txtFirstName.Text.Trim();
                t.LastName = txtLastName.Text.Trim();
                t.JobTitle = txtJobTitle.Text.Trim();
                //t.DepartmentId = Convert.ToInt32(drpDepartment.SelectedValue);
                t.LastModifiedByUserId = UserId;
                t.LastModifiedOnDate = DateTime.Now;
                t.AssignedUserId = Convert.ToInt32(ddlAssignedUser.SelectedValue);
                t.CategoryId = Convert.ToInt32(drpCategory.SelectedValue);
                t.LocationId = Convert.ToInt32(drpLocation.SelectedValue);
                t.DepartmentId = Convert.ToInt32(drpDepartment.SelectedValue);
                t.StartDate = dpStartDate.SelectedDate;
                t.EndDate = dpEndDate.SelectedDate;
            }
            else
            {
                t = new Starter()
                {
                    AssignedUserId = Convert.ToInt32(ddlAssignedUser.SelectedValue),
                    CreatedByUserId = UserId,
                    CategoryId = Convert.ToInt32(drpCategory.SelectedValue),
                    LocationId = Convert.ToInt32(drpLocation.SelectedValue),
                    DepartmentId = Convert.ToInt32(drpDepartment.SelectedValue),
                    CreatedOnDate = DateTime.Now,
                    
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    JobTitle = txtJobTitle.Text.Trim(),
                    StartDate = dpStartDate.SelectedDate,
                    EndDate = dpEndDate.SelectedDate,

                };
            }

            t.LastModifiedOnDate = DateTime.Now;
            t.LastModifiedByUserId = UserId;
            t.ModuleId = ModuleId;

            if (t.Id > 0)
            {
                tc.UpdateStarter(t);

                SendNotification("Notification subject", "The following new user " + t.FirstName + " " + t.LastName + " has been updated.", UserController.GetUserById(PortalId, t.CreatedByUserId));

                SendNotification("Notification subject", "The following new user " + t.FirstName + " " + t.LastName + " has been updated.", UserController.GetUserById(PortalId, t.AssignedUserId));

                SendMessage("New starter added to you", "The following new user " + t.FirstName + " " + t.LastName + " has been updated.", UserController.GetUserById(PortalId, t.AssignedUserId));

                SendMessage("New starter added to you", "The following new user " + t.FirstName + " " + t.LastName + " has been updated.", UserController.GetUserById(PortalId, t.CreatedByUserId));
            }
            else
            {
                tc.CreateStarter(t);

                a = new Approval()
                {
                    StarterId = t.Id,
                    StatusId = 1,
                    Comment = "The starter has just been created, by " + UserController.GetCurrentUserInfo().DisplayName,
                    ModuleId = ModuleId,
                    CreatedByUserId = UserId,
                    CreatedOnDate = DateTime.Now,
                    LastModifiedByUserId = UserId,
                    LastModifiedOnDate = DateTime.Now,
                    IsDeleted = false,
                };

                ac.CreateApproval(a);

                SendNotification("Notification subject", "The following new user " + t.FirstName + " " + t.LastName + " has been created.", UserController.GetUserById(PortalId, t.CreatedByUserId));

                SendNotification("Notification subject", "The following new user " + t.FirstName + " " + t.LastName + " has been created.", UserController.GetUserById(PortalId, t.AssignedUserId));

                SendMessage("New starter added to you", "The following new user " + t.FirstName + " " + t.LastName + " has been created.",  UserController.GetUserById(PortalId, t.AssignedUserId));

                SendMessage("New starter added to you", "The following new user " + t.FirstName + " " + t.LastName + " has been created.", UserController.GetUserById(PortalId, t.CreatedByUserId));

            }
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }
    }
}