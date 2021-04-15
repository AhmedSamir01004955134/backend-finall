using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinallShope.DAL.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descraption { get; set; }
        public decimal Price { get; set; }
        public int CatogryId { get; set; }
        [ForeignKey("CatogryId")]
        public Category Category { get; set; }
        public int ItemPhtoId { get; set; }
        [ForeignKey("ItemPhtoId")]
        public ItemPhto ItemPhto { get; set; }
        public virtual ICollection<DescraptionItem> DescraptionItems { get; set; }
    }
}
