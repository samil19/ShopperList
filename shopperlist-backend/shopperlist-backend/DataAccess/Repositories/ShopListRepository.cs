using Microsoft.EntityFrameworkCore;
using shopperlist_backend.DataAccess.Interfaces;
using shopperlist_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopperlist_backend.DataAccess.Repositories
{
    public class ShopListRepository : Repository<ShopList>, IShopListRepository
    {
        public ShopListRepository(shopperlistContext context) : base(context)
        {
        }

    }
}
