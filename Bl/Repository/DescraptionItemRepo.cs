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
    public class DescraptionItemRepo : IdescraptionItemRepo
    {
        private readonly FinallShopeContext db;
        private readonly IMapper mapper;

        public DescraptionItemRepo(FinallShopeContext db,IMapper mapper )
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void Add(DescraptionItemVm data)
        {
            var dat = mapper.Map<DescraptionItem>(data);
            db.DescraptionItem.Add(dat);
            db.SaveChanges();
           
        }

        public void Edit(DescraptionItemVm data)
        {
            var map = mapper.Map<DescraptionItem>(data);
            db.Entry(map).State = Microsoft.EntityFrameworkCore
                .EntityState.Modified;
            db.SaveChanges();
        }

        public DescraptionItemVm GetItem(int id)
        {
            var data = db.DescraptionItem.Where(a => a.Id == id)
            .Select(a => new DescraptionItemVm
            {
                Id = a.Id,
                Name = a.Name,
                Photo = a.Photo,
                ItemId = a.Item.Name
            }).FirstOrDefault();
            return data;
        }

        public IEnumerable<DescraptionItemVm> GetList()
        {
            var data = db.DescraptionItem.Select(a =>
            new DescraptionItemVm 
            {
                Id = a.Id,
                Name = a.Name,
                Photo = a.Photo,
                ItemId = a.Item.Name
            });
            return data;
            
        }

        public void Remove(int id)
        {
            var delat = db.DescraptionItem.Find(id);
            db.DescraptionItem.Remove(delat);
            db.SaveChanges();
            
        }
    }
}
