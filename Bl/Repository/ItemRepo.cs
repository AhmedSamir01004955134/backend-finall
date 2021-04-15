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
    public class ItemRepo : Iitem
    {
        private readonly FinallShopeContext db;
        private readonly IMapper mapper;

        public ItemRepo(FinallShopeContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void Add(ItemVm data)
        {
            var dat = mapper.Map<Item>(data);
            db.Item.Add(dat);
            db.SaveChanges();
        
        }

        public void Edit(ItemVm data)
        {
            var dat = mapper.Map<Item>(data);
            db.Entry(dat).State = Microsoft.
                EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

        }

        public ItemVm GetItem(int id)
        {
            var git = db.Item.Where(a => a.Id == id).Select(a => new ItemVm
            {
                Id = a.Id,
                Name = a.Name,
                Price = a.Price,
                Descraption = a.Descraption,
                CatogryId = a.Category.Name,
                ItemPhtoId = a.ItemPhto.Url
            }).FirstOrDefault();
            return git;
        }

        public IEnumerable<ItemVm> GetList()
        {
            var git = db.Item.Select(a => new ItemVm
            {
                Id = a.Id,
                Name = a.Name,
                Price = a.Price,
                Descraption = a.Descraption,
                CatogryId = a.Category.Name,
                ItemPhtoId = a.ItemPhto.Url
            });

            return git;
        }

        public void Remove(int id)
        {
            var delet = db.Item.Find(id);
            db.Item.Remove(delet);
            db.SaveChanges();
            
        }
    }
}
