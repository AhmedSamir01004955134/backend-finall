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
    public class ItemVmsController : ControllerBase
    {
        private readonly Iitem _context;

        public ItemVmsController(Iitem context)
        {
            _context = context;
        }

        // GET: api/ItemVms
        [HttpGet]
        public IEnumerable<ItemVm> GetItemVm()
        {
           var getItem=  _context.GetList();
            return (getItem);
        }

        // GET: api/ItemVms/5
        [HttpGet("{id}")]
        public ActionResult<ItemVm> GetItemVm(int id)
        {
            var itemVm = _context.GetItem(id);

            if (itemVm == null)
            {
                return NotFound();
            }

            return itemVm;
        }

        // PUT: api/ItemVms/5
        [HttpPut("{id}")]
        public IActionResult PutItemVm(int id, ItemVm itemVm)
        {
            if (id != itemVm.Id)
            {
                return BadRequest("Not Found Id");
            }

            _context.Edit(itemVm);

            return Ok();
        }

        // POST: api/ItemVms
        [HttpPost]
        public ActionResult<ItemVm> PostItemVm(ItemVm itemVm)
        {
            _context.Add(itemVm);            
            return CreatedAtAction("GetItemVm", new { id = itemVm.Id }, itemVm);
        }

        // DELETE: api/ItemVms/5
        [HttpDelete("{id}")]
        public IActionResult DeleteItemVm(int id, ItemVm itemVm)
        {
            if (id != itemVm.Id)
            {
                return NotFound("pleas Entar your requst id");
            }
            _context.Remove(id);
            return Ok();
        }

        
    }
}
