using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Models
{
    public partial class Brand
    {
        public Brand()
        {
            BrandCategories = new HashSet<BrandCategory>();
            RawProductBrands = new HashSet<RawProductBrand>();
        }

        public int Id { get; set; }
        public string Details { get; set; }
        public string Name { get; set; }
        public DateTime DateInsert { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        public virtual ICollection<BrandCategory> BrandCategories { get; set; }
        public virtual ICollection<RawProductBrand> RawProductBrands { get; set; }
    }
}
