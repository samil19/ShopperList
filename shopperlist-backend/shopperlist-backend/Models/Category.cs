using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Models
{
    public partial class Category
    {
        public Category()
        {
            BrandCategories = new HashSet<BrandCategory>();
            RawProductCategories = new HashSet<RawProductCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? IdScale { get; set; }

        public virtual Scale IdScaleNavigation { get; set; }
        public virtual ICollection<BrandCategory> BrandCategories { get; set; }
        public virtual ICollection<RawProductCategory> RawProductCategories { get; set; }
    }
}
