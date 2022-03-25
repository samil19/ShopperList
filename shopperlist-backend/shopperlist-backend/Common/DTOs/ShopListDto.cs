using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Common.DTOs
{
    public partial class ShopListDto
    {
        public int Id { get; set; }
        public int IdShop { get; set; }
        public int IdProductBrand { get; set; }

    }
}
