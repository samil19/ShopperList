using shopperlist_backend.Common.DTOs;
using shopperlist_backend.DataAccess.Interfaces;
using shopperlist_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopperlist_backend.BussinessLogic.Interfaces
{
    public interface IScaleLogic
    {
        Scale SaveScale(Scale scale);
        List<Scale> GetAll();
        void Update(Scale scale);

        void Delete(int id);
    }
}
