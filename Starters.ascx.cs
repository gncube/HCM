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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Utilities;
using GND.Modules.HCM.Components;

namespace GND.Modules.HCM
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from HCMModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Starters : HCMModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var sc = new StarterController();
                rptStarterList.DataSource = sc.GetStarters(ModuleId);
                //rptStarterList.DataSource = sc.ListStarters(ModuleId, 1, true);

                lnkNewStarter.NavigateUrl = EditUrl();
                lnkApprovals.NavigateUrl = EditUrl("Approvals");
                
                rptStarterList.DataBind();
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                ModuleActionCollection actions = new ModuleActionCollection();
                actions.Add(GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                actions.Add(GetNextActionID(), Localization.GetString("ManageCategories", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("Categories"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                actions.Add(GetNextActionID(), Localization.GetString("ManageLocations", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("Locations"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                actions.Add(GetNextActionID(), Localization.GetString("ManageDepartments", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("Departments"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                actions.Add(GetNextActionID(), Localization.GetString("ManageAssets", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("Assets"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                return actions;
            }
        }

        protected void rptStarterList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect(EditUrl(string.Empty, string.Empty, "Edit", "tid=" + e.CommandArgument));
            }

            if (e.CommandName == "Delete")
            {
                var sc = new StarterController();
                sc.DeleteStarter(Convert.ToInt32(e.CommandArgument), ModuleId);
            }
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

        protected void rptStarterList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var lnkEdit = e.Item.FindControl("lnkEdit") as HyperLink;
                var lnkApprove = e.Item.FindControl("lnkApprove") as HyperLink;
                var lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;
                var lblCategory = e.Item.FindControl("lblCategory") as Label;
                var lblDepartment = e.Item.FindControl("lblDepartment") as Label;
                var lblLocation = e.Item.FindControl("lblLocation") as Label;

                var t = (Starter) e.Item.DataItem;
                var cc = new CategoryController();
                var lc = new LocationController();
                var dc = new DepartmentController();
                
                lblCategory.Text = cc.GetCategory(t.CategoryId, ModuleId).Name;
                lblDepartment.Text = dc.GetDepartment(t.DepartmentId, ModuleId).Name;
                lblLocation.Text = lc.GetLocation(t.LocationId, ModuleId).Name;
                //lnkEdit.Text = t.Id.ToString();
                //lnkEdit.Enabled = true;

                if (lnkEdit != null)
                {
                    lnkEdit.Enabled = lnkEdit.Visible = true;
                    lnkEdit.Text = t.Id.ToString();
                    lnkEdit.NavigateUrl = EditUrl(string.Empty, string.Empty, string.Empty, "tid=" + t.Id);
                    //lnkEdit.NavigateUrl = EditUrl(string.Empty, string.Empty, string.Empty, "tid=" + t.Id);
                }

                if (lnkApprove != null)
                {
                    lnkApprove.Enabled = lnkApprove.Visible = true;
                    //lnkApprove.Text = t.Id.ToString();
                    lnkApprove.Text = "Approve";
                    //lnkApprove.NavigateUrl = EditUrl(string.Empty, string.Empty, string.Empty, "tid=" + t.Id);
                    lnkApprove.NavigateUrl = EditUrl(string.Empty, string.Empty, "EditApproval", "tid=" + t.Id);
                }

                if (IsEditable && lnkDelete != null)
                {
                    lnkDelete.CommandArgument = t.Id.ToString();
                    lnkDelete.Enabled = lnkDelete.Visible = true;

                    ClientAPI.AddButtonConfirm(lnkDelete, Localization.GetString("ConfirmDelete", LocalResourceFile));
                }
                
            }
        }

        protected void lnkNewStarter_Click(object sender, EventArgs e)
        {
            var url = ModuleContext.EditUrl();
            //var title = Localization.GetString(ModuleAction.AddContent, LocalResourceFile);

            lnkNewStarter.NavigateUrl = url;
        }

        protected void lnkApprovals_Click(object sender, EventArgs e)
        {
            var url = ModuleContext.EditUrl("Approvals");

            lnkApprovals.NavigateUrl = url;
        }
    }
}