using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security;
using DotNetNuke.Security.Roles;
using DotNetNuke.Security.Roles.Internal;
using DotNetNuke.Services.Localization;
using GND.Modules.HCM.Components;
using DotNetNuke.Services.Exceptions;
using Telerik.Web.UI;

namespace GND.Modules.HCM
{
    public partial class Categories : HCMModuleBase
    {
        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    BindData();
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion

        #region Private Methods

        private void BindData()
        {
            CategoryController categoryController = new CategoryController();
            IEnumerable<Category> cats = categoryController.ListCategoriesHierarchical(ModuleId, false);

            treeCategories.Nodes.Clear();
            treeCategories.DataTextField = "Name";
            treeCategories.DataFieldID = "Id";
            treeCategories.DataFieldParentID = "CategoryParentId";
            treeCategories.DataSource = cats;
            treeCategories.DataBind();
            if (!IsPostBack && treeCategories.Nodes.Count > 0)
                treeCategories.Nodes[0].Selected = true;
        }
        private void EditCategory(int categoryId)
        {
            CategoryController categoryController = new CategoryController();
            panelAddEdit.Visible = true;
            PopulateCategoriesDropDown(categoryId);
            Category categoryItem = categoryController.GetCategory(categoryId, ModuleId);
            int? parentCategoryId = categoryItem.CategoryParentId;
            drpParentCategory.SelectedValue = (parentCategoryId == null ? "-1" : parentCategoryId.ToString());
            txtCategoryName.Text = categoryItem.Name;
            txtCategoryDescription.Text = categoryItem.Description;
        }

        /// <summary>
        /// Populates the (Parent-)categories drop down.
        /// </summary>
        private void PopulateCategoriesDropDown(int categoryId)
        {
            drpParentCategory.Items.Clear();
            drpParentCategory.Items.Add(new ListItem(Localization.GetString("SelectParentCategory.Text", this.LocalResourceFile), "-1"));
            CategoryController categoryController = new CategoryController();
            foreach (Category category in categoryController.ListCategoriesHierarchical(ModuleId, false))
            {
                if (categoryId != category.Id)
                    drpParentCategory.Items.Add(new ListItem(new string('.', category.Level * 3) + category.Name, category.Id.ToString()));
            }
        }
        #endregion

        protected void cmdAddNew_Click(object sender, EventArgs e)
        {
            panelAddEdit.Visible = true;
            txtCategoryDescription.Text = "";
            txtCategoryName.Text = "";
            PopulateCategoriesDropDown(-1);
            treeCategories.UnselectAllNodes();
            cmdDelete.Visible = false;
        }

        protected void cmdGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Globals.NavigateURL());
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            CategoryController categoryController = new CategoryController();
            Category categoryItem = new Category();
            PortalSecurity objSecurity = new PortalSecurity();

            int parentCategoryId = Convert.ToInt32(drpParentCategory.SelectedValue);
            if (parentCategoryId < 0)
                parentCategoryId = 0;

            // We do not allow for script or markup
            categoryItem.CategoryParentId = parentCategoryId;
            categoryItem.Name = objSecurity.InputFilter(txtCategoryName.Text, PortalSecurity.FilterFlag.NoMarkup | PortalSecurity.FilterFlag.NoScripting);
            categoryItem.Description = objSecurity.InputFilter(txtCategoryDescription.Text, PortalSecurity.FilterFlag.NoScripting | PortalSecurity.FilterFlag.NoMarkup);
            categoryItem.ModuleId = ModuleId;

            try
            {
                RadTreeNode node = treeCategories.SelectedNode;
                if (node != null)
                {
                    categoryItem.Id = Convert.ToInt32(node.Value);
                    Category originalCategoryItem = categoryController.GetCategory(categoryItem.Id);
                    categoryItem.ViewOrder = originalCategoryItem.ViewOrder;
                    categoryController.UpdateCategory(categoryItem);
                }
                else
                {
                    categoryItem.ViewOrder = 999;
                    categoryController.CreateCategory(categoryItem);
                }
                categoryController.ReorderCategory(categoryItem.CategoryParentId, ModuleId);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }
    }
}