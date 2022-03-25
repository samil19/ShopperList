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
    public class ShopLogic : IShopLogic
    {
        public readonly shopperlistContext _context;
        public readonly IShopRepository _repo;
        public ShopLogic(shopperlistContext context, IShopRepository repo)
        {
            _context = context;
            _repo = repo;
        }
        public Shop SaveShop(Shop shop)
        {

            return _repo.Insert(shop);
        }

        public List<Shop> GetAll()
        {
            return _repo.GetAll().ToList();
        }

        public void Update(Shop shop)
        {
            _repo.Update(shop);
            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            Shop shop = _repo.FirtsOrDefault(x => x.Id == id);
            
            DbSet<ShopList> shopListsDb = _context.Set<ShopList>();
            List<ShopList> shopLists = shopListsDb.Where(x => x.IdShop == shop.Id).ToList();

            shopListsDb.RemoveRange(shopLists);
            _repo.Delete(shop);
            _repo.SaveChanges();
        }
    }
}
