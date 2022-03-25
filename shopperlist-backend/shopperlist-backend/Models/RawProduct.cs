using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Models
{
    public partial class RawProduct
    {
        public RawProduct()
        {
            RawProductBrands = new HashSet<RawProductBrand>();
            RawProductCategories = new HashSet<RawProductCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateInsert { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        public virtual ICollection<RawProductBrand> RawProductBrands { get; set; }
        public virtual ICollection<RawProductCategory> RawProductCategories { get; set; }
    }
}
