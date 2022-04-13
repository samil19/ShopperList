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
    public class BrandLogic : IBrandLogic
    {
        public readonly shopperlistContext _context;
        public readonly IBrandRepository _repo;
        public BrandLogic(shopperlistContext context, IBrandRepository repo)
        {
            _context = context;
            _repo = repo;
        }
        public Brand SaveProductBrand(Brand brand)
        {

            return _repo.Insert(brand);
        }

        public List<Brand> GetAll()
        {
            return _repo.GetAll().ToList();
        }

        public void Update(Brand brand)
        {
            _repo.Update(brand);
            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            Brand brand = _repo.FirtsOrDefault(x => x.Id == id);
            DbSet<RawProductBrand> rawProductBrandDb = _context.Set<RawProductBrand>();
            List<RawProductBrand> productsBrands = rawProductBrandDb.Where(x => x.IdBrand == brand.Id).ToList();
            DbSet<BrandCategory> brandCategoriesDb = _context.Set<BrandCategory>();
            List<BrandCategory> brandCategories = brandCategoriesDb.Where(x => x.IdBrand == brand.Id).ToList();
            rawProductBrandDb.RemoveRange(productsBrands);
            brandCategoriesDb.RemoveRange(brandCategories);
            _repo.Delete(brand);
            _repo.SaveChanges();
        }
        public List<Brand> Filter(string name)
        {
            return _repo.VerifyAnd(x => x.Name.Contains(name), name).ToList();
        }
    }
}
