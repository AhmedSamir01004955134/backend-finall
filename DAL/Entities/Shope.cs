using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinallShope.DAL.Entities
{
    public class Shope
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
    
}
