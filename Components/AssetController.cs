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
using System.Data;
using DotNetNuke.Data;

namespace GND.Modules.HCM.Components
{
    class AssetController
    {
        public void CreateAsset(Asset a)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Asset>();
                rep.Insert(a);
            }
        }

        public void DeleteAsset(int assetId, int moduleId)
        {
            var a = GetAsset(assetId, moduleId);
            DeleteAsset(a);
        }

        public void DeleteAsset(Asset a)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Asset>();
                rep.Delete(a);
            }
        }

        public IEnumerable<Asset> GetAssets(int moduleId)
        {
            IEnumerable<Asset> a;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Asset>();
                a = rep.Get(moduleId);
            }
            return a;
        }

        public Asset GetAsset(int assetId, int moduleId)
        {
            Asset a;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Asset>();
                a = rep.GetById(assetId, moduleId);
            }
            return a;
        }

        public void UpdateAsset(Asset a)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Asset>();
                rep.Update(a);
            }
        }
    }
}