using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Models
{
    public partial class RawProductBrand
    {
        public int Id { get; set; }
        public int IdRawProduct { get; set; }
        public int IdBrand { get; set; }

        public virtual Brand IdBrandNavigation { get; set; }
        public virtual RawProduct IdRawProductNavigation { get; set; }
    }
}
