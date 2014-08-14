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

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DotNetNuke.Data;

namespace GND.Modules.HCM.Components
{
    public class StarterController
    {
        #region Standard Methods
        public void CreateStarter(Starter s)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Starter>();
                rep.Insert(s);
            }
        }

        public void DeleteStarter(int starterId, int moduleId)
        {
            var s = GetStarter(starterId, moduleId);
            DeleteStarter(s);
        }

        public void DeleteStarter(Starter s)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Starter>();
                rep.Delete(s);
            }
        }

        public IEnumerable<Starter> GetStarters(int moduleId)
        {
            IEnumerable<Starter> s;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Starter>();
                s = rep.Get(moduleId);
            }
            
            return s;
        }

        public Starter GetStarter(int starterId, int moduleId)
        {
            Starter s;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Starter>();
                s = rep.GetById(starterId, moduleId);
            }
            
            return s;
        }

        public void UpdateStarter(Starter s)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Starter>();
                rep.Update(s);
            }
        }

        #endregion

        #region Custom Methods
        /// <summary>
        /// Lists the Starters.
        /// </summary>
        /// <param name="moduleId">List FAQs for this specific module id (scope)</param>
        /// <param name="orderBy">Order result by.</param>
        /// <param name="showHidden">if true, show definitely all FAQs (Admin)</param>
        /// <returns>Arrarylist of Starters</returns>
        public IEnumerable<Starter> ListStarters(int moduleId, int orderBy, bool showHidden)
        {
            IEnumerable<Starter> s;
            string sql =
                "SELECT TOP 1000 s.Id ,FirstName ,LastName ,JobTitle ,c.Name As Category ,d.Name As Department, " +
                "   l.Name As Location ,AssignedUserId ,s.ModuleId ,CreatedOnDate ,CreatedByUserId ,LastModifiedOnDate ," +
                "   LastModifiedByUserId ,s.IsDeleted ,StartDate ,EndDate " +
                "FROM {databaseOwner}{objectQualifier}HCM_Starter s " +
                "   JOIN {databaseOwner}{objectQualifier}HCM_Category c ON s.CategoryId = c.Id " +
                "   JOIN {databaseOwner}{objectQualifier}HCM_Department d ON s.DepartmentId = d.Id " +
                "   JOIN {databaseOwner}{objectQualifier}HCM_Location l ON s.LocationId = l.Id " +
                "   WHERE s.ModuleId = @0 " +
                "   AND @2 = 1 " +
                "ORDER BY" +
                "  CASE WHEN @1=0 THEN s.LastModifiedOnDate END DESC," +
                "  CASE WHEN @1=1 THEN s.LastModifiedOnDate END ASC, " +
                //"  CASE WHEN @1=2 THEN s.ViewCount END DESC," +
                //"  CASE WHEN @1=3 THEN s.ViewCount END ASC," +
                "  CASE WHEN @1=4 THEN s.CreatedOnDate END DESC," +
                "  CASE WHEN @1=5 THEN s.CreatedOnDate END ASC";
                //"  CASE WHEN @1=6 THEN s.ViewOrder END ASC";

            using (IDataContext ctx = DataContext.Instance())
            {
                //faqs = ctx.ExecuteQuery<FAQsInfo>(CommandType.Text, sql, moduleID, orderBy, showHidden);
                //return faqs;
                s = ctx.ExecuteQuery<Starter>(CommandType.Text, sql, moduleId, orderBy, showHidden);
            }
            return s;
        }
        #endregion
    }
}