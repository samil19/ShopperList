using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopperlist_backend.BussinessLogic;
using shopperlist_backend.BussinessLogic.Interfaces;
using shopperlist_backend.Common.DTOs;
using shopperlist_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopperlist_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopListController : ControllerBase
    {
        public shopperlistContext _context;
        public IShopListLogic _logic;
        public ShopListController(shopperlistContext context, IShopListLogic logic)
        {
            _context = context;
            _logic = logic;
        }
       
        [HttpPost]
        public ActionResult Create(ShopList shopList)
        {
            
            return Ok(_logic.SaveShopList(shopList));
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_logic.GetAll());
        }

        [HttpPut]
        public ActionResult Update(ShopList shopList)
        {
            try
            {
                _logic.Update(shopList);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException.Message, null, null, ex.Message);
            }
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                _logic.Delete(id);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException.Message, null, null, ex.Message);
            }
            return Ok();
        }

    }
}
