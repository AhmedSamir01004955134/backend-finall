using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinallShope.Modals
{
    public class ItemVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descraption { get; set; }
        public decimal Price { get; set; }
        public string CatogryId { get; set; }
        public string ItemPhtoId { get; set; }
       
    }
}
