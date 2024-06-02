using MoneyFellows.Application.Dtos.Products;
using MoneyFellows.Core.Entities;

namespace MoneyFellows.Application.Dtos.ProductOrders
{
    public class ProductOrderDto
    {
        public Guid Id { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public int Quantity { get; set; }
        //public Order? Order { get; set; }
        public ProductDto? Product { get; set; }
    }
}
