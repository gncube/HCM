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

using System;
using System.Web.Caching;
using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;

namespace GND.Modules.HCM.Components
{
    [TableName("HCM_Asset")]
    //setup the primary key for table
    [PrimaryKey("Id", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("Assets", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class Asset
    {
        /// <summary>
        /// Gets or sets the Asset parent id.
        /// </summary>
        /// <value>The Asset parent id.</value>
        public int? AssetParentId { get; set; }

        /// <summary>
        /// Gets or sets the Asset id.
        /// </summary>
        /// <value>The Asset id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the module id.
        /// </summary>
        /// <value>The module id.</value>
        public int ModuleId { get; set; }

        /// <summary>
        /// Gets or sets the name of the Asset.
        /// </summary>
        /// <value>The name of the Asset.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Asset description.
        /// </summary>
        /// <value>The Asset description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the module hierarchical level.
        /// </summary>
        /// <value>The module hierarchical level.</value>
        [IgnoreColumn]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the view order between children of one node.
        /// </summary>
        /// <value>The view order.</value>
        public int ViewOrder { get; set; }

        ///<summary>
        /// An integer for the user id of the user who created the object
        ///</summary>
        public int CreatedByUserId { get; set; }

        ///<summary>
        /// An integer for the user id of the user who last updated the object
        ///</summary>
        public int LastModifiedByUserId { get; set; }

        ///<summary>
        /// The date the object was created
        ///</summary>
        public DateTime CreatedOnDate { get; set; }

        ///<summary>
        /// The date the object was updated
        ///</summary>
        public DateTime LastModifiedOnDate { get; set; }

        /// <summary>
        /// Gets or sets the view order between children of one node.
        /// </summary>
        /// <value>The view order.</value>
        public bool IsDeleted { get; set; }
    }
}