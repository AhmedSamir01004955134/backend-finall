using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinallShope.Modals;
using FinallShope.Bl.Intarface;

namespace FinallShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPhtoVmsController : ControllerBase
    {
        private readonly IitemPhtoRepo _context;

        public ItemPhtoVmsController(IitemPhtoRepo context)
        {
            _context = context;
        }

        // GET: api/ItemPhtoVms
        [HttpGet]
        public IEnumerable<ItemPhtoVm> GetItemPhtoVm()
        {
            var ok = _context.GetList();
            return (ok);
        }

        // GET: api/ItemPhtoVms/5
        [HttpGet("{id}")]
        public ActionResult<ItemPhtoVm> GetItemPhtoVm(int id)
        {
            var itemPhtoVm = _context.GetItem(id);

            if (itemPhtoVm == null)
            {
                return NotFound();
            }

            return itemPhtoVm;
        }

        // PUT: api/ItemPhtoVms/5
        [HttpPut("{id}")]
        public IActionResult PutItemPhtoVm(int id, ItemPhtoVm itemPhtoVm)
        {
            if (id != itemPhtoVm.Id)
            {
                return BadRequest("Id Not Found");
            }

            _context.Edit(itemPhtoVm);

            return Ok();
        }

        // POST: api/ItemPhtoVms
        [HttpPost]
        public ActionResult<ItemPhtoVm> PostItemPhtoVm(ItemPhtoVm itemPhtoVm)
        {
            _context.Add(itemPhtoVm);
         

            return CreatedAtAction("GetItemPhtoVm", new { id = itemPhtoVm.Id }, itemPhtoVm);
        }

        // DELETE: api/ItemPhtoVms/5
        [HttpDelete("{id}")]
        public IActionResult DeleteItemPhtoVm(int id)
        {
            
            _context.Remove(id);
            return Ok();
        }
    }
}
