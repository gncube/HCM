/*
' Copyright (c) 2014  GND Software Ltd
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
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using GND.Modules.HCM.Components;

namespace GND.Modules.HCM.Controls
{
    public partial class Assets : HCMModuleBase
    {
        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var ac = new AssetController();
                rptAssetList.DataSource = ac.GetAssets(ModuleId);
                rptAssetList.DataBind();
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }

        }
        #endregion

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            AssetController ac = new AssetController();
            Asset a = new Asset();
            PortalSecurity security = new PortalSecurity();

            // We do not allow for script or markup
            a.Name = security.InputFilter(txtName.Text,
                PortalSecurity.FilterFlag.NoMarkup | PortalSecurity.FilterFlag.NoScripting);
            a.Description = security.InputFilter(txtDescription.Text,
                PortalSecurity.FilterFlag.NoMarkup | PortalSecurity.FilterFlag.NoScripting);

            try
            {
                a.Level = 999;
                a.IsDeleted = false;
                a.ModuleId = ModuleId;
                a.ViewOrder = 999;
                a.CreatedOnDate = DateTime.Now;
                a.CreatedByUserId = UserId;
                a.LastModifiedByUserId = UserId;
                a.LastModifiedOnDate = DateTime.Now;
                ac.CreateAsset(a);
                //TODO Reorder
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exc)
            {
               Exceptions.ProcessModuleLoadException(this, exc);
            }
        }
    }
}