using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntitiy
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = String.Empty;
        public ProductType? ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand? ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}
