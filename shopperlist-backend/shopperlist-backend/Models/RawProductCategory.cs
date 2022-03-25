using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Models
{
    public partial class RawProductCategory
    {
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public int IdRawProduct { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual RawProduct IdRawProductNavigation { get; set; }
    }
}
