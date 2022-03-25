using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Models
{
    public partial class BrandCategory
    {
        public int Id { get; set; }
        public int IdBrand { get; set; }
        public int IdCategory { get; set; }

        public virtual Brand IdBrandNavigation { get; set; }
        public virtual Category IdCategoryNavigation { get; set; }
    }
}
