using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Models
{
    public partial class ShopList
    {
        public int Id { get; set; }
        public int IdShop { get; set; }
        public int IdRawProductBrand { get; set; }
        public double Price { get; set; }

        public virtual RawProductBrand IdRawProductBrandNavigation { get; set; }
        public virtual Shop IdShopNavigation { get; set; }
    }
}
