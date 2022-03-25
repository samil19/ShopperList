using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Models
{
    public partial class Scale
    {
        public Scale()
        {
            Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public int? Health { get; set; }
        public int? Cosmetic { get; set; }
        public int? Strength { get; set; }
        public int? Protein { get; set; }
        public int? Luxury { get; set; }
        public int? Needed { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
