using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinallShope.DAL.Entities
{
    public class ItemPhto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
