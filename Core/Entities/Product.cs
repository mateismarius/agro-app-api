
using Core.Entities.Identity;

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
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public string? UserId { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
