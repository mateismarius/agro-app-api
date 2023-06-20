using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class FarmerProfile : BaseEntitiy
    {
        public string UserId { get; set; }
        public AppUser? AppUser { get; set; }
        public string? PictureUrl { get; set; }
        public string? Description { get; set; }
    }
}
