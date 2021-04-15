using AutoMapper;
using FinallShope.Bl.Intarface;
using FinallShope.DAL.Entities;
using FinallShope.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinallShope.Bl.Repository
{
    public class CategoryRepo : IcategoryRepo
    {
        private readonly FinallShopeContext db;
        private readonly IMapper mapper;

        public CategoryRepo(FinallShopeContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void Add(CategoryVm data)
        {
            var map = mapper.Map<Category>(data);
            db.Category.Add(map);
            db.SaveChanges();
           
        }

        public void Edit(CategoryVm data)
        {
            var map = mapper.Map<Category>(data);
            db.Entry(map).State = Microsoft
            .EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
           
        }

        public CategoryVm GetItem(int id)
        {
            var data = db.Category.Where(a => a.Id == id).Select(a => new CategoryVm
            {
                Id = a.Id,
                Name = a.Name,
                Img = a.Img,
                ShopeId = a.Shope.Name
            }).FirstOrDefault();

            return data;
        }

        public IEnumerable<CategoryVm> GetList()
        {
            var data = db.Category.Select(a => new CategoryVm
            {
                Id = a.Id,
                Name = a.Name,
                Img = a.Img,
                ShopeId = a.Shope.Name
            });
            return data;
        }

        public void Remove(int id)
        {
            var delat = db.Category.Find(id);
            db.Category.Remove(delat);
            db.SaveChanges();
           
        }
    }
}
