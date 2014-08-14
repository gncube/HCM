using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DotNetNuke.Data;

namespace GND.Modules.HCM.Components
{
    public class LocationController
    {
        public void CreateLocation(Location l)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Location>();
                rep.Insert(l);
            }
        }

        public void DeleteLocation(int locationId, int moduleId)
        {
            var l = GetLocation(locationId, moduleId);
            DeleteLocation(l);
        }

        public void DeleteLocation(Location l)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Location>();
                rep.Delete(l);
            }
        }

        /// <summary>
        /// Retrieves all or only used categories for a module (unsorted).
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <param name="onlyUsedLocations">true if only locations should be returned that are used</param>
        /// <returns>IEnumerable of Location objects</returns>
        public IEnumerable<Location> ListLocations(int moduleId, bool onlyUsedLocations)
        {
            IEnumerable<Location> locations;
            string sql = "SELECT [Id], [ModuleId]," +
                         //" CASE WHEN [CategoryParentId] IS NULL THEN 0 ELSE [CategoryParentId] END AS [CategoryParentId]," +
                         " [Name], [Description],0 As [Level],[ViewOrder]" +
                         " FROM {databaseOwner}[{objectQualifier}HCM_Location] " +
                         " WHERE [ModuleId] = @0";
            //" AND ([Id] IN (SELECT CategoryId FROM {databaseOwner}[{objectQualifier}FAQs]) OR @1=0)";

            using (IDataContext ctx = DataContext.Instance())
            {
                locations = ctx.ExecuteQuery<Location>(CommandType.Text, sql, moduleId, onlyUsedLocations);
            }
            return locations;
        }

        public IEnumerable<Location> GetLocations(int moduleId)
        {
            IEnumerable<Location> l;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Location>();
                l = rep.Get(moduleId);
            }
            return l;
        }

        public Location GetLocation(int locationId, int moduleId)
        {
            Location l;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Location>();
                l = rep.GetById(locationId, moduleId);
            }
            return l;
        }

        public void UpdateLocation(Location l)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Location>();
                rep.Update(l);
            }
        }
    }
}