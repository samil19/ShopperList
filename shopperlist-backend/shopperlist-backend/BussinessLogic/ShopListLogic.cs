using Microsoft.EntityFrameworkCore;
using shopperlist_backend.BussinessLogic.Interfaces;
using shopperlist_backend.Common.DTOs;
using shopperlist_backend.DataAccess.Interfaces;
using shopperlist_backend.DataAccess.Repositories;
using shopperlist_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopperlist_backend.BussinessLogic
{
    public class ShopListLogic : IShopListLogic
    {
        public readonly shopperlistContext _context;
        public readonly IShopListRepository _repo;
        public ShopListLogic(shopperlistContext context, IShopListRepository repo)
        {
            _context = context;
            _repo = repo;
        }
        public ShopList SaveShopList(ShopList shopList)
        {

            return _repo.Insert(shopList);
        }

        public List<ShopList> GetAll()
        {
            return _repo.GetAll().ToList();
        }

        public void Update(ShopList shopList)
        {
            _repo.Update(shopList);
            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            _repo.Delete(_repo.FirtsOrDefault(x => x.Id == id));
            _repo.SaveChanges();
        }
    }
}
