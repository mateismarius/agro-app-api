namespace API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Barcode { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? InventoryNo { get; set; }
        public string? SerialNo { get; set; }
        public decimal ProductValue { get; set; }
        public string? Employee { get; set; }
        public string? ProductLocation { get; set; }
    }
}
