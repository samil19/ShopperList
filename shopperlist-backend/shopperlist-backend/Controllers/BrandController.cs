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
    public class BrandController : ControllerBase
    {
        public shopperlistContext _context;
        public IBrandLogic _logic;
        public BrandController(shopperlistContext context, IBrandLogic logic)
        {
            _context = context;
            _logic = logic;
        }
       
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            
            return Ok(_logic.SaveProductBrand(brand));
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_logic.GetAll());
        }
        [HttpGet("name")]
        public ActionResult Search(string name)
        {
            return Ok(_logic.Filter(name));
        }

        [HttpPut]
        public ActionResult Update(Brand product)
        {
            try
            {
                _logic.Update(product);
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
