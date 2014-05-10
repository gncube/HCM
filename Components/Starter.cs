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
using System.Web.Caching;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace GND.Modules.HCM.Components
{
    [TableName("HCM_Starter")]
    //setup the primary key for table
    [PrimaryKey("Id", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("Starters", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class Starter
    {
        ///<summary>
        /// The ID of your object with the name of the ItemName
        ///</summary>
        public int Id { get; set; }
        ///<summary>
        /// A string with the name of the ItemName
        ///</summary>
        public string FirstName { get; set; }

        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string LastName { get; set; }

        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string JobTitle { get; set; }

        ///<summary>
        /// An integer with the user id of the assigned user for the object
        ///</summary>
        public int CategoryId { get; set; }

        ///<summary>
        /// An integer with the user id of the assigned user for the object
        ///</summary>
        [IgnoreColumn] 
        public string CategoryName { get; set; }

        ///<summary>
        /// An integer with the user id of the assigned user for the object
        ///</summary>
        public int DepartmentId { get; set; }

        [IgnoreColumn]
        public string DepartmentName { get; set; }

        ///<summary>
        /// An integer with the user id of the assigned user for the object
        ///</summary>
        public int LocationId { get; set; }

        [IgnoreColumn]
        public string LocationName { get; set; }

        ///<summary>
        /// An integer with the user id of the assigned user for the object
        ///</summary>
        public int AssignedUserId { get; set; }

        ///<summary>
        /// The ModuleId of where the object was created and gets displayed
        ///</summary>
        public int ModuleId { get; set; }

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
        /// Gets or sets the visibility of the Faq-Item
        /// </summary>
        /// <value>The Deleted flag. </value>
        public Boolean IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the publish date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>The expiration date.</value>
        public DateTime? EndDate { get; set; }

        //public virtual Category Category { get; set; }
        //public virtual Department Department { get; set; }
        //public virtual Location Location { get; set; }
    }
}