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
using System.Linq;
using System.Web;
using DotNetNuke.Data;

namespace GND.Modules.HCM.Components
{
    public class ApprovalController
    {
        public void CreateApproval(Approval a)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Approval>();
                rep.Insert(a);
            }
        }

        public void DeleteApproval(int ApprovalId, int moduleId)
        {
            var a = GetApproval(ApprovalId, moduleId);
            DeleteApproval(a);
        }

        public void DeleteApproval(Approval a)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Approval>();
                rep.Delete(a);
            }
        }

        public IEnumerable<Approval> GetApprovals(int moduleId)
        {
            IEnumerable<Approval> a;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Approval>();
                a = rep.Get(moduleId);
            }
            return a;
        }

        public Approval GetApproval(int ApprovalId, int moduleId)
        {
            Approval a;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Approval>();
                a = rep.GetById(ApprovalId, moduleId);
            }
            return a;
        }

        public void UpdateApproval(Approval a)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Approval>();
                rep.Update(a);
            }
        }
    }
}