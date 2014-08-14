/*
' Copyright (c) 2013 GND Software Ltd
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/
using System.Collections.Generic;
using System.Data;
using DotNetNuke.Data;

namespace GND.Modules.HCM.Components
{
    class CategoryController
    {
        public void CreateCategory(Category c)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Category>();
                rep.Insert(c);
            }
        }

        public void DeleteCategory(int categoryId, int moduleId)
        {
            var c = GetCategory(categoryId, moduleId);
            DeleteCategory(c);
        }

        public void DeleteCategory(Category c)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Category>();
                rep.Delete(c);
            }
        }

        public IEnumerable<Category> GetCategorys(int moduleId)
        {
            IEnumerable<Category> c;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Category>();
                c = rep.Get(moduleId);
            }
            return c;
        }

        /// <summary>
        /// Gets a category.
        /// </summary>
        /// <param name="categoryId">The id of the category to return.</param>
        /// <returns>Category info object</returns>
        public Category GetCategory(int? categoryId)
        {
            Category category;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Category>();
                category = rep.GetById(categoryId);
            }
            return category;
        }

        public Category GetCategory(int categoryId, int moduleId)
        {
            Category c;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Category>();
                c = rep.GetById(categoryId, moduleId);
            }
            return c;
        }

        /// <summary>
        /// Retrieves all or only used categories for a module (unsorted).
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <param name="onlyUsedCategories">true if only categories should be returned that are used in Faq's</param>
        /// <returns>IEnumerable of CategoryInfo objects</returns>
        public IEnumerable<Category> ListCategories(int moduleId, bool onlyUsedCategories)
        {
            IEnumerable<Category> categories;
            string sql = "SELECT [Id], [ModuleId]," +
                         " CASE WHEN [CategoryParentId] IS NULL THEN 0 ELSE [CategoryParentId] END AS [CategoryParentId]," +
                         " [Name], [Description],0 As [Level],[ViewOrder]" +
                         " FROM {databaseOwner}[{objectQualifier}HCM_Category] " +
                         " WHERE [ModuleId] = @0";
                         //" AND ([Id] IN (SELECT CategoryId FROM {databaseOwner}[{objectQualifier}FAQs]) OR @1=0)";

            using (IDataContext ctx = DataContext.Instance())
            {
                categories = ctx.ExecuteQuery<Category>(CommandType.Text, sql, moduleId, onlyUsedCategories);
            }
            return categories;
        }

        /// <summary>
        /// Retrieves all or only used categories hierarchical (additional level info, sorted).
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <param name="onlyUsedCategories">true if only categories are returned that are used in Faq's</param>
        /// <returns>IEnumerable of CategoryInfo objects</returns>
        public IEnumerable<Category> ListCategoriesHierarchical(int moduleId, bool onlyUsedCategories)
        {
            IEnumerable<Category> categories;
            string sql = "{objectQualifier}HCM_CategoryListHierarchical";

            using (IDataContext ctx = DataContext.Instance())
            {
                categories = ctx.ExecuteQuery<Category>(CommandType.StoredProcedure, sql, moduleId, onlyUsedCategories);
            }
            return categories;
        }

        /// <summary>
        /// Renumbering the vieworder field for one specific parent category
        /// </summary>
        /// <param name="parentCategoryId">ID of parent category, whos childs should be renumbered</param>
        /// <param name="moduleId">The Module id</param>
        public void ReorderCategory(int? parentCategoryId, int moduleId)
        {
            string sql = "WITH tmpReorder(ViewOrder,Id) AS" +
                         " (" +
                         "  SELECT TOP 1000 row_number() OVER (ORDER BY f.ViewOrder) as rank, f.Id" +
                         "  FROM {databaseOwner}[{objectQualifier}HCM_Category] f" +
                         "  WHERE f.ModuleId = @0" +
                         "  AND f.CategoryParentId " + (parentCategoryId == 0 ? " IS NULL" : " = @1") +
                         "  ORDER BY rank " +
                         " )" +
                         " UPDATE {databaseOwner}[{objectQualifier}HCM_Category] " +
                         " SET ViewOrder = (SELECT ViewOrder FROM tmpReorder r WHERE r.Id = {databaseOwner}[{objectQualifier}HCM_Category].Id)" +
                         " WHERE ModuleId = @0" +
                         " AND CategoryParentId " + (parentCategoryId == 0 ? " IS NULL" : " = @1");

            using (IDataContext ctx = DataContext.Instance())
            {
                ctx.Execute(CommandType.Text, sql, moduleId, parentCategoryId);
            }
        }

        public void UpdateCategory(Category c)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Category>();
                rep.Update(c);
            }
        }

    }
}
