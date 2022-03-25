using shopperlist_backend.Common.DTOs;
using shopperlist_backend.DataAccess.Interfaces;
using shopperlist_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopperlist_backend.BussinessLogic.Interfaces
{
    public interface IShopLogic
    {
        Shop SaveShop(Shop shop);
        List<Shop> GetAll();
        void Update(Shop shop);

        void Delete(int id);
    }
}
