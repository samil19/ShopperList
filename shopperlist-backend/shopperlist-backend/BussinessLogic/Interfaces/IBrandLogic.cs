using shopperlist_backend.Common.DTOs;
using shopperlist_backend.DataAccess.Interfaces;
using shopperlist_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopperlist_backend.BussinessLogic.Interfaces
{
    public interface IBrandLogic
    {
        Brand SaveProductBrand(Brand brand);
        List<Brand> GetAll();
        void Update(Brand brand);

        void Delete(int id);
        List<Brand> Filter(string name);
    }
}
