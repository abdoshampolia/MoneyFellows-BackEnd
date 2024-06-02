using MoneyFellows.Application.Dtos.ProductOrders;

namespace MoneyFellows.Application.Dtos.Products
{
    public class ProductDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Image { get; set; }
        public double? Price { get; set; }
        public string? Merchant { get; set; }
        public ICollection<ProductOrderDto>? ProductsOrder { get; set; }
    }
}
