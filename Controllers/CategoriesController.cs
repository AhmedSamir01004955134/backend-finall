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
    public class CategoriesController : ControllerBase
    {
        private readonly IcategoryRepo _repo;

        public CategoriesController(IcategoryRepo repo)
        {
            _repo = repo;
        }

        // GET: api/Categories
        [HttpGet]
        public  IEnumerable <CategoryVm> GetList()
        {
            var cato= _repo.GetList();

            return cato;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<CategoryVm> GetCategory(int id)
        {
            var category = _repo.GetItem( id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, CategoryVm category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            try
            {
                _repo.Edit(category);
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<CategoryVm> PostCategory(CategoryVm category)
        {
            _repo.Add(category);
            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id, CategoryVm category)
        {
            if (id != category.Id)
            {
                return NotFound("pleas Entar your requst id");
            }
            _repo.Remove(id);
            return Ok();
        }
    }

        //private bool CategoryExists(int id)
        //{
        //    return _context.Category.Any(e => e.Id == id);
        //}
    
}
