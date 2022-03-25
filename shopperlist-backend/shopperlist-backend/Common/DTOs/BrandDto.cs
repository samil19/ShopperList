using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Common.DTOs
{
    public partial class BrandDto
    {

        public int Id { get; set; }
        public int IdProduct { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public int? IdCategoria { get; set; }
        public string Brand { get; set; }

    }
}
