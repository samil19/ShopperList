using shopperlist_backend.Common.DTOs;
using shopperlist_backend.DataAccess.Interfaces;
using shopperlist_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopperlist_backend.BussinessLogic.Interfaces
{
    public interface IShopListLogic
    {
        ShopList SaveShopList(ShopList shopList);
        List<ShopList> GetAll();
        void Update(ShopList shopList);

        void Delete(int id);
    }
}
