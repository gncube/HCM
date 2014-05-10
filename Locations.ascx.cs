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

using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GND.Modules.HCM.Components;

namespace GND.Modules.HCM
{
    public partial class Locations : HCMModuleBase
    {
        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var tc = new LocationController();
                rptLocationList.DataSource = tc.GetLocations(ModuleId);
                rptLocationList.DataBind();
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }
        #endregion

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            LocationController locationController = new LocationController();
            Location location = new Location();
            PortalSecurity objSecurity = new PortalSecurity();

            // We do not allow for script or markup
            location.Name = objSecurity.InputFilter(txtName.Text,
                PortalSecurity.FilterFlag.NoMarkup | PortalSecurity.FilterFlag.NoScripting);
            location.Description = objSecurity.InputFilter(txtDescription.Text,
                PortalSecurity.FilterFlag.NoMarkup | PortalSecurity.FilterFlag.NoScripting);
            location.ModuleId = ModuleId;
            
            try
            {
                location.ViewOrder = 999;
                location.IsDeleted = false;
                locationController.CreateLocation(location);
                // TO DO Reorder
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

    }
}