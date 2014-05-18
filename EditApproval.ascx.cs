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
using System.ComponentModel;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Roles;
using DotNetNuke.Security.Roles.Internal;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.UserControls;
using GND.Modules.HCM.Components;
using DotNetNuke.Services.Exceptions;

namespace GND.Modules.HCM
{
    public partial class EditApproval : HCMModuleBase
    {
        #region Private Methods

        /// <summary>
        /// Populates the drop downs.
        /// </summary>
        private void PopulateDropDownLists()
        {

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Implement your edit logic for your module
                if (!Page.IsPostBack)
                {
                    //PopulateDropDownLists();

                    //check if we have an ID passed in via a querystring parameter, if so, load that item to edit.
                    //ItemId is defined in the ItemModuleBase.cs file
                    if (ItemId > 0)
                    {
                        var tc = new StarterController();
                        var cc = new CategoryController();
                        var lc = new LocationController();
                        var dc = new DepartmentController();

                        var t = tc.GetStarter(ItemId, ModuleId);
                        if (t != null)
                        {
                            txtFirstName.Text = t.FirstName + ' ' + t.LastName;
                            
                            txtJobTitle.Text = t.JobTitle;
                            txtCategory.Text = cc.GetCategory(t.CategoryId, ModuleId).Name;
                            txtAssignedUser.Text = UserController.GetUserById(PortalId, t.AssignedUserId).DisplayName;
                            txtLocation.Text = lc.GetLocation(t.LocationId, ModuleId).Name;
                            txtDepartment.Text = dc.GetDepartment(t.DepartmentId, ModuleId).Name;
                            txtStartDate.Text = t.StartDate.ToString();
                            txtEndDate.Text = t.EndDate.ToString();
                        }
                    }
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }
    }
}