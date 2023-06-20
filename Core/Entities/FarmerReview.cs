using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class FarmerReview : BaseEntitiy
    {
        public int ReviewPropsId { get; set; }
        public ReviewProps? ReviewProps { get; set; }
        public string? FarmerId { get; set; }
        public AppUser? Farmer { get; set; }
    }
}
