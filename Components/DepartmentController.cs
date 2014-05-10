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
    public class DepartmentController
    {
        public void CreateDepartment(Department d)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Department>();
                rep.Insert(d);
            }
        }

        public void DeleteDepartment(int departmentId, int moduleId)
        {
            var d = GetDepartment(departmentId, moduleId);
            DeleteDepartment(d);
        }

        public void DeleteDepartment(Department d)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Department>();
                rep.Delete(d);
            }
        }

        public IEnumerable<Department> GetDepartments(int moduleId)
        {
            IEnumerable<Department> d;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Department>();
                d = rep.Get(moduleId);
            }
            return d;
        }

        public Department GetDepartment(int departmentId, int moduleId)
        {
            Department d;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Department>();
                d = rep.GetById(departmentId, moduleId);
            }
            return d;
        }

        public void UpdateDepartment(Department d)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Department>();
                rep.Update(d);
            }
        }

        public IEnumerable<Department> ListDepartments(int moduleId, bool onlyUsedDepartments)
        {
            IEnumerable<Department> d;
            string sql = "SELECT [Id], [ModuleId], " +
                         " [Name], [Description], 0 As [Level], [ViewOrder]" +
                         " FROM {databaseOwner}[{objectQualifier}HCM_Department] " +
                         " WHERE [ModuleId] = @0";

            using (IDataContext ctx = DataContext.Instance())
            {
                d = ctx.ExecuteQuery<Department>(CommandType.Text, sql, moduleId, onlyUsedDepartments);
            }
            return d;
        }
    }
}