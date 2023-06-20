using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Highlight : BaseEntitiy
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string? Treatment { get; set; }
        public string? Description { get; set; }
        public DateTime AppliedAt { get; set; }
    }
}
