using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinallShope.DAL.Entities
{
    public class DescraptionItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
