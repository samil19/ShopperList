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
    public class CategoriesController : ControllerBase
    {
        public shopperlistContext _context;
        public ICategoryLogic _logic;
        public CategoriesController(shopperlistContext context, ICategoryLogic categoryLogic)
        {
            _context = context;
            _logic = categoryLogic;
        }
       
        [HttpPost]
        public ActionResult Create(Category category)
        {
            
            return Ok(_logic.SaveCategory(category));
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
        public ActionResult Update(Category category)
        {
            try
            {
                _logic.Update(category);
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
