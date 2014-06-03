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
using DotNetNuke.Services.Exceptions;
using GND.Modules.HCM.Components;

namespace GND.Modules.HCM.Controls
{
    public partial class AddAsset : HCMModuleBase
    {
        #region Private Methods

        /// <summary>
        /// Populates the checklist
        /// </summary>
        private void PopulateCheckList()
        {
            //get a list of assets
            AssetController ac = new AssetController();
            ddlAssets.DataSource = ac.GetAssets(ModuleId);
            ddlAssets.DataTextField = "Name";
            ddlAssets.DataValueField = "Id";
            ddlAssets.DataBind();
            ddlAssets.Items.Insert(0, "Select an asset");

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                 //Implement your edit logic for your module
                if (!Page.IsPostBack)
                {
                    PopulateCheckList();

                    //check if we have an ID passed in via a querystring parameter, if so, load that item to edit.
                    //ItemId is defined in the HCMModuleBase.cs file
                    if (ItemId > 0)
                    {
                        
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