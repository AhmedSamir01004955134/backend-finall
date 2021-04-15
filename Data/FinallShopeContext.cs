using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinallShope.DAL.Entities;
using FinallShope.Modals;


    public class FinallShopeContext : DbContext
    {
        public FinallShopeContext (DbContextOptions<FinallShopeContext> options)
            : base(options)
        {
        }

        public DbSet<FinallShope.DAL.Entities.Shope> Shope { get; set; }
        public DbSet<FinallShope.DAL.Entities.Item> Item { get; set; }
        public DbSet<FinallShope.DAL.Entities.ItemPhto> ItemPhto { get; set; }
        public DbSet<FinallShope.DAL.Entities.DescraptionItem> DescraptionItem { get; set; }
        public DbSet<FinallShope.DAL.Entities.Category> Category { get; set; }
        public DbSet<FinallShope.Modals.ItemVm> ItemVm { get; set; }
        public DbSet<FinallShope.Modals.DescraptionItemVm> DescraptionItemVm { get; set; }
        public DbSet<FinallShope.Modals.ItemPhtoVm> ItemPhtoVm { get; set; }
}
