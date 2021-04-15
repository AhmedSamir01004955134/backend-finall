using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinallShope.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int ShopeId { get; set; }
        [ForeignKey("ShopeId")]
        public Shope Shope { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
