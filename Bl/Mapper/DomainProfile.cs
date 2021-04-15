using AutoMapper;
using FinallShope.DAL.Entities;
using FinallShope.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinallShope.Bl.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Category, CategoryVm>();
            CreateMap<CategoryVm, Category>();

            CreateMap<Item, ItemVm>();
            CreateMap<ItemVm, Item>();

            CreateMap<DescraptionItem, DescraptionItemVm>();
            CreateMap<DescraptionItemVm, DescraptionItem>();

            CreateMap<ItemPhto, ItemPhtoVm>();
            CreateMap<ItemPhtoVm, ItemPhto>();

            CreateMap<Shope, ShopeVm>();
            CreateMap<ShopeVm, Shope>();
        }
    }
}
