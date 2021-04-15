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
    public class DescraptionItemVmsController : ControllerBase
    {
        private readonly IdescraptionItemRepo _context;

        public DescraptionItemVmsController(IdescraptionItemRepo context)
        {
            _context = context;
        }

        // GET: api/DescraptionItemVms
        [HttpGet]
        public  IEnumerable<DescraptionItemVm> GetDescraptionItemVm()
        {
          var get = _context.GetList();

            return get;
        }

        // GET: api/DescraptionItemVms/5
        [HttpGet("{id}")]
        public ActionResult<DescraptionItemVm> GetDescraptionItemVm(int id)
        {
            var descraptionItemVm = _context.GetItem(id);

            if (descraptionItemVm == null)
            {
                return NotFound();
            }

            return descraptionItemVm;
        }

        // PUT: api/DescraptionItemVms/5
        [HttpPut("{id}")]
        public IActionResult PutDescraptionItemVm(int id, DescraptionItemVm descraptionItemVm)
        {
            if (id != descraptionItemVm.Id)
            {
                return BadRequest();
            }

            _context.Edit(descraptionItemVm);

            return Ok(descraptionItemVm);
        }

        // POST: api/DescraptionItemVms

        [HttpPost]
        public ActionResult<DescraptionItemVm> PostDescraptionItemVm(DescraptionItemVm descraptionItemVm)
        {
            _context.Add(descraptionItemVm);
            
            return CreatedAtAction("GetDescraptionItemVm", new { id = descraptionItemVm.Id }, descraptionItemVm);
        }

        // DELETE: api/DescraptionItemVms/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDescraptionItemVm(int id, DescraptionItemVm descraptionItem)
        {
            if (id != descraptionItem.Id)
            {
                return NotFound("pleas Entar your requst id");
            }
            _context.Remove(id);
            return Ok();
        }

    }
}
