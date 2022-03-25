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
    public class CategoryLogic : ICategoryLogic
    {
        public readonly shopperlistContext _context;
        public readonly ICategoryRepository _repo;
        public CategoryLogic(shopperlistContext context, ICategoryRepository repo)
        {
            _context = context;
            _repo = repo;
        }
        public Category SaveCategory(Category category)
        {
            
            return _repo.Insert(category);
        }

        public List<Category> GetAll()
        {
            return _repo.GetAll().ToList();
        }

        public void Update(Category category)
        {
            _repo.Update(category);
            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = _repo.FirtsOrDefault(x => x.Id == id);
            DbSet<RawProductCategory> rawProductCategoryDb = _context.Set<RawProductCategory>();
            List<RawProductCategory> productCategories = rawProductCategoryDb.Where(x => x.IdCategory == category.Id).ToList();
            DbSet<BrandCategory> brandCategoryDb = _context.Set<BrandCategory>();
            List<BrandCategory> brandCategories = brandCategoryDb.Where(x => x.IdCategory == category.Id).ToList();
            _repo.Delete(category);
            rawProductCategoryDb.RemoveRange(productCategories);
            brandCategoryDb.RemoveRange(brandCategories);
            _repo.SaveChanges();
        }
        public List<Category> Filter(string name)
        {
            return _repo.VerifyAnd(x => x.Name == name, name).ToList();
        }
    }
}
