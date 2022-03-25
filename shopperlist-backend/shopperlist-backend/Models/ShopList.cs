using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Models
{
    public partial class ShopList
    {
        public int Id { get; set; }
        public int IdShop { get; set; }
        public int IdProductBrand { get; set; }

        public virtual Brand IdProductBrandNavigation { get; set; }
        public virtual Shop IdShopNavigation { get; set; }
    }
}
