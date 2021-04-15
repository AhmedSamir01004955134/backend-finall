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
    public class ShopeRepo : IshopeRep
    {
        private readonly FinallShopeContext db;
        private readonly IMapper mapper;

        public ShopeRepo(FinallShopeContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void Add(ShopeVm Shop)
        {
            //mapping
            var data = mapper.Map<Shope>(Shop);
            db.Shope.Add(data);
            db.SaveChanges();

        }

        public void Edit(ShopeVm Shop)
        {
            //mapping 
            var data = mapper.Map<Shope>(Shop);
            db.Entry(data).State = Microsoft.
            EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public ShopeVm GetItem(int id)
        {
            var data = db.Shope.Where(a=>a.Id==id)
                .Select(a => new ShopeVm
            {
                Id = a.Id,
                Name = a.Name
            }).FirstOrDefault();
            return data;
        }

        public IEnumerable<ShopeVm> GetList()
        {
            var data = db.Shope.Select(a => new ShopeVm
            {
                Id = a.Id,
                Name = a.Name

            });
            return data;
        }

        public void Remove(int id)
        {
            var data = db.Shope.Find(id);
            db.Shope.Remove(data);
            db.SaveChanges();
        }

       
    }
}
