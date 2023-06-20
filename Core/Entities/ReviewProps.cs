using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ReviewProps : BaseEntitiy
    {
        public int Rating { get; set; }
        public string? Content { get; set; }
        public string Author { get; set; } = string.Empty;
       
    }
}
