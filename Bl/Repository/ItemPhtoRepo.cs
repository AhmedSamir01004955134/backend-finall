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
    public class ItemPhtoRepo : IitemPhtoRepo
    {
        private readonly FinallShopeContext db;
        private readonly IMapper mapper;

        public ItemPhtoRepo( FinallShopeContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void Add(ItemPhtoVm data)
        {
            var map = mapper.Map<ItemPhto>(data);
            db.ItemPhto.Add(map);
            db.SaveChanges();

        }

        public void Edit(ItemPhtoVm data)
        {
            var map = mapper.Map<ItemPhto>(data);
            db.Entry(map).State = Microsoft.
                EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public ItemPhtoVm GetItem(int id)
        {
            var data = db.ItemPhto.Where
                (a => a.Id == id).Select(a => new ItemPhtoVm
            {
                Id = a.Id,
                Url = a.Url
            }).FirstOrDefault();
            return data;
        }

        public IEnumerable<ItemPhtoVm> GetList()
        {
            var data = db.ItemPhto.Select(a => new ItemPhtoVm
            {
                Id = a.Id,
                Url = a.Url
            });
            return data;
        }

        public void Remove(int id)
        {
            var delet = db.ItemPhto.Find(id);
            db.ItemPhto.Remove(delet);
            db.SaveChanges();
          
        }
    }
}
