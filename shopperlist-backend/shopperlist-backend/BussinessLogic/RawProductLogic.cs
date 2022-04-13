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
    public class RawProductLogic : IRawProductLogic
    {
        public readonly shopperlistContext _context;
        public readonly IRawProductRepository _repo;
        public RawProductLogic(shopperlistContext context, IRawProductRepository repo)
        {
            _context = context;
            _repo = repo;
        }
        public RawProduct SaveProduct(RawProduct rawProduct)
        {

            return _repo.Insert(rawProduct);
        }

        public List<RawProduct> GetAll()
        {
            return _repo.GetAll().ToList();
        }

        public void Update(RawProduct rawProduct)
        {
            _repo.Update(rawProduct);
            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            DbSet<RawProductBrand> rawProductBrandDb = _context.Set<RawProductBrand>();
            DbSet<RawProductCategory> rawProductCategoryDb = _context.Set<RawProductCategory>();
            RawProduct rawProduct = _repo.FirtsOrDefault(x => x.Id == id);
            List<RawProductBrand> productsBrands = rawProductBrandDb.Where(x => x.IdRawProduct == rawProduct.Id).ToList();
            List<RawProductCategory> productCategories = rawProductCategoryDb.Where(x => x.IdRawProduct == rawProduct.Id).ToList();
            rawProductBrandDb.RemoveRange(productsBrands);
            rawProductCategoryDb.RemoveRange(productCategories);
            _repo.Delete(rawProduct);
            _repo.SaveChanges();
        }
        public List<RawProduct> Filter(string name)
        {
            return _repo.VerifyAnd(x => x.Name.Contains(name), name).ToList();
        }
    }
}
