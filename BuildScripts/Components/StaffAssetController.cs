/*
' Copyright (c) 2014 GND Software Ltd
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
using DotNetNuke.Data;

namespace GND.Modules.HCM.Components
{
    class StaffAssetController
    {
        public void CreateStaffAsset(StaffAsset sa)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<StaffAsset>();
                rep.Insert(sa);
            }
        }

        public void DeleteStaffAsset(int staffAssetId, int moduleId)
        {
            var sa = GetStaffAsset(staffAssetId, moduleId);
            DeleteStaffAsset(sa);
        }

        public void DeleteStaffAsset(StaffAsset sa)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<StaffAsset>();
                rep.Delete(sa);
            }
        }

        //public IEnumerable<StaffAsset> GetStaffAssets(int moduleId)
        //{
        //    IEnumerable<StaffAsset> sa;
        //    using (IDataContext ctx = DataContext.Instance())
        //    {
        //        var rep = ctx.GetRepository<StaffAsset>();
        //        sa = rep.Get(moduleId);
        //    }
        //    return sa;
        //}

        public IEnumerable<StaffAsset> GetStaffAssets(int starterId)
        {
            IEnumerable<StaffAsset> sa;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<StaffAsset>();
                //sa = rep.Get(starterId);
                sa = rep.Get(starterId);
            }
            return sa;
        }

        public StaffAsset GetStaffAsset(int staffAssetId, int moduleId)
        {
            StaffAsset sa;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<StaffAsset>();
                sa = rep.GetById(staffAssetId, moduleId);
            }
            return sa;
        }

        public void UpdateStaffAsset(StaffAsset sa)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<StaffAsset>();
                rep.Update(sa);
            }
        }

    }
}
