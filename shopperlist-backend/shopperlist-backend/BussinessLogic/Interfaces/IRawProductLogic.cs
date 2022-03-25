using shopperlist_backend.Common.DTOs;
using shopperlist_backend.DataAccess.Interfaces;
using shopperlist_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopperlist_backend.BussinessLogic.Interfaces
{
    public interface IRawProductLogic
    {
        RawProduct SaveProduct(RawProduct product);
        List<RawProduct> GetAll();
        void Update(RawProduct rawProduct);

        void Delete(int id);
        List<RawProduct> Filter(string name);
    }
}
