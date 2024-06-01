using MoneyFellows.Application.Dtos.ProductOrders;

namespace MoneyFellows.Application.Dtos.Products
{
    public class ProductDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; }
        public string? Description { get;  }
        public string? ImageUrl { get;  }
        public byte[]? Image { get; } 
        public decimal? Price { get; }
        public string? Merchant { get;  }
        public ICollection<ProductOrderDto>? ProductsOrder { get; }
    }
}
