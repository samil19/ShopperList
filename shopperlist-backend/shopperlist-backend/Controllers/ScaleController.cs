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
    public class ScaleController : ControllerBase
    {
        public shopperlistContext _context;
        public IScaleLogic _logic;
        public ScaleController(shopperlistContext context, IScaleLogic logic)
        {
            _context = context;
            _logic = logic;
        }
       
        [HttpPost]
        public ActionResult Create(Scale scale)
        {
            
            return Ok(_logic.SaveScale(scale));
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_logic.GetAll());
        }

        [HttpPut]
        public ActionResult Update(Scale scale)
        {
            try
            {
                _logic.Update(scale);
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
