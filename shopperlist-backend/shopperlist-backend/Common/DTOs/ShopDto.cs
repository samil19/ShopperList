using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Common.DTOs
{
    public partial class ShopDto
    {

        public int Id { get; set; }
        public string Supermarket { get; set; }
        public DateTime Date { get; set; }

    }
}
