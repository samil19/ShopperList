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
    public class ScaleLogic : IScaleLogic
    {
        public readonly shopperlistContext _context;
        public readonly IScaleRepository _repo;
        public ScaleLogic(shopperlistContext context, IScaleRepository repo)
        {
            _context = context;
            _repo = repo;
        }
        public Scale SaveScale(Scale scale)
        {

            return _repo.Insert(scale);
        }

        public List<Scale> GetAll()
        {
            return _repo.GetAll().ToList();
        }

        public void Update(Scale scale)
        {
            _repo.Update(scale);
            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            _repo.Delete(_repo.FirtsOrDefault(x => x.Id == id));
            _repo.SaveChanges();
        }
    }
}
