using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinallShope.DAL.Entities;
using FinallShope.Bl.Intarface;
using FinallShope.Modals;

namespace FinallShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopesController : ControllerBase
    {
        private readonly IshopeRep _context;

        public ShopesController(IshopeRep context)
        {
            _context = context;
        }

        // GET: api/Shopes
        [HttpGet]
        public  IEnumerable<ShopeVm> GetShope()
        {
            return _context.GetList();
        }

        // GET: api/Shopes/5
        [HttpGet("{id}")]
        public ActionResult<ShopeVm> GetShope(int id)
        {
            var shope = _context.GetItem(id);

            if (shope == null)
            {
                return NotFound("Please enter the correct Id");
            }

            return shope;
        }

        // PUT: api/Shopes/5
        [HttpPut("{id}")]
        public IActionResult PutShope(int id, ShopeVm shope)
        {
            if (id != shope.Id)
            {
                return BadRequest();
            }           
                _context.Edit(shope);
            return NoContent();
        }

        // POST: api/Shopes
        [HttpPost]
        public ActionResult<ShopeVm> PostShope(ShopeVm shope)
        {
            _context.Add(shope);
            

            return CreatedAtAction("GetShope", new { id = shope.Id }, shope);
        }

        // DELETE: api/Shopes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteShope(int id)
        {
            
            
            _context.Remove(id);
            return Ok();
        }

        
    }
}
