using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Models
{
    public partial class Shop
    {
        public Shop()
        {
            ShopLists = new HashSet<ShopList>();
        }

        public int Id { get; set; }
        public string Supermarket { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<ShopList> ShopLists { get; set; }
    }
}
