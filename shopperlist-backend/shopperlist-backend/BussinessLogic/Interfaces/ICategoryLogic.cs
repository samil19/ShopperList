using shopperlist_backend.Common.DTOs;
using shopperlist_backend.DataAccess.Interfaces;
using shopperlist_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopperlist_backend.BussinessLogic.Interfaces
{
    public interface ICategoryLogic
    {
        Category SaveCategory(Category category);
        void Update(Category category);
        List<Category> GetAll();

        void Delete(int id);
        List<Category> Filter(string name);
    }
}
